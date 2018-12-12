using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RFMBaseClasses;
using WMSBizObjects;
using RFMPublic;

namespace WMSSuitable
{
	public partial class frmOutputsGoodsConfirm : RFMFormChild
	{
		private int ID;
		private Output oOutput;
		private StoreZone oStoresZones;
		private User oUsers;

		private int nGoodStateID;
		private int nOwnerID;
		private bool bSeparatePicking;

		private int nLostFoundID = 0;
		private string sLostFoundAddress = "";

		private bool bLoaded = false;
		private bool bWeightingTry = false;


		public frmOutputsGoodsConfirm(int? _ID)
		{
			oOutput = new Output();
			oStoresZones = new StoreZone();
			oUsers = new User();
			if (oOutput.ErrorNumber != 0 ||
				oStoresZones.ErrorNumber != 0 ||
				oUsers.ErrorNumber != 0)
			{
				IsValid = false;
			}

			if (IsValid)
			{
				InitializeComponent();

				if (_ID.HasValue)
					ID = (int)_ID;

				dgvPieceShipment.MultiSelect =
				dgvWeightShipment.MultiSelect =
				btnApplyFilter.Enabled =
					chkMultiSelectAllow.Checked;
				if (chkMultiSelectAllow.Checked)
					dgvPieceShipment.SelectionMode = dgvWeightShipment.SelectionMode =
						DataGridViewSelectionMode.FullRowSelect;
				else
					dgvPieceShipment.SelectionMode = dgvWeightShipment.SelectionMode =
						DataGridViewSelectionMode.CellSelect;
				dgvPieceShipment.ReadOnly = false;
				foreach (DataGridViewColumn dgvc in dgvPieceShipment.Columns)
					dgvc.ReadOnly = !(dgvc.Name.Contains("IsChecked") || dgvc.Name.Contains("IsConfirmed"));

				dgvWeightShipment.ReadOnly = false;
				foreach (DataGridViewColumn dgvc in dgvWeightShipment.Columns)
					dgvc.ReadOnly = !(dgvc.Name.Contains("IsChecked") || dgvc.Name.Contains("IsConfirmed"));
			}
		}

		private void frmOutputEdit_Load(object sender, EventArgs e)
		{
			bool blResult = cboStoresZones_Restore() && cboHeavers_Restore();
			if (!blResult)
			{
				RFMMessage.MessageBoxError("Ошибка получения общих данных (классификаторы)...");
				Dispose();
				return;
			}

			if (cboStoresZones.Items.Count == 0)
			{
				RFMMessage.MessageBoxError("Нет зон пикинга...");
				Dispose();
				return;
			}

			// сам расход
			oOutput.ID = ID;
			oOutput.FillData();
			if (oOutput.ErrorNumber != 0 || oOutput.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о расходе...");
				Dispose();
				return;
			}

			// шапка формы 
			DataRow dr = oOutput.MainTable.Rows[0];
			txtID.Text = dr["ID"].ToString();
			txtErpCode.Text = dr["ErpCode"].ToString();
			txtDateOutput.Text = dr["DateOutput"].ToString().Substring(0, 10);
			txtOutputBarCode.Text = dr["BarCode"].ToString();

			txtOwnerName.Text = dr["OwnerName"].ToString();
			txtPartnerName.Text = dr["PartnerName"].ToString();

			txtGoodStateName.Text = dr["GoodStateName"].ToString();
			txtOutputTypeName.Text = dr["OutputTypeName"].ToString();
			txtCellAdress.Text = dr["CellAddress"].ToString();

			nGoodStateID = Convert.ToInt32(dr["GoodStateID"]);
			nOwnerID = Convert.ToInt32(dr["OwnerID"]);
			bSeparatePicking = Convert.ToBoolean(dr["SeparatePicking"]);

			// заполнение таблицы
			if (ForLoad(false) == 0)
			{
				Dispose();
				return;
			}

			cboHeavers.SelectedIndex = -1;
			if (oStoresZones.MainTable.Rows.Count == 1)
			{
				cboStoresZones.SelectedIndex = 0;
				btnSelect_Click(null, null);
				dgvPieceShipment.Select();
			}
			else
			{
				cboStoresZones.SelectedIndex = -1;
				cboStoresZones.Select();
			}

			ShowStrikes();
			
			tbcGoods.Init();

			bLoaded = true;
		}

		private int ForLoad(bool bAgain)
		{
			oOutput.ClearError();

			// перемещения коробок/штук в расходе
			oOutput.FillTableOutputsTraffics(ID, false);
			if (oOutput.ErrorNumber != 0)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о перемещениях коробок/штук для расхода...");
				return (0);
			}
			if (oOutput.TableOutputsTrafficsGoods.Rows.Count == 0)
			{
				if (!bAgain)
				{
					RFMMessage.MessageBoxInfo("Для расхода не создано перемещений коробок/штук.\n\r" +
						"Нечего подтверждать...");
				}
				return (0);
			}
			// оставить в списке зон только те, которые есть среди перемещений
			cboStoresZones.Enabled = true;

            // добавить виртуальную зону для перемещений из Lost&Found
			Setting oSet = new Setting();
			sLostFoundAddress = oSet.FillVariable("sLostFoundAddress");
			if (sLostFoundAddress != null && sLostFoundAddress.Length > 0)
			{
				Cell oCellLostFound = new Cell();
				oCellLostFound.FilterAddress = sLostFoundAddress;
				oCellLostFound.FillData();
				if (oCellLostFound.MainTable.Rows.Count > 0)
				{
					DataRow rclf = oCellLostFound.MainTable.Rows[0];
					if (rclf != null)
					{
						nLostFoundID = (int)rclf["ID"];
					}
				}
			}
			DataView dvlf = new DataView(oOutput.TableOutputsTrafficsGoods);
			dvlf.RowFilter = "CellSourceID = " + nLostFoundID.ToString();
			if (chkUnConfirmed.Checked)
			{
				dvlf.RowFilter += " AND NOT IsConfirmed";
			}
			if (dvlf.Count > 0)
			{
				// найдем эту зону и добавим ее в список
				StoreZone oStoreZoneVirtual = new StoreZone();
				oStoreZoneVirtual.FillData();
				foreach (DataRow drz in oStoreZoneVirtual.MainTable.Rows)
				{
					if (Convert.ToBoolean(drz["Special"]))
					{
						drz["Name"] = "_неизвестен";
						oStoresZones.MainTable.ImportRow(drz);
					}
				}
			}

            StoreZonesClear();	

			/*
			if (oStoresZones.MainTable.Rows.Count <= 1)
			{
				cboStoresZones.Enabled = false;
			}
			*/

			btnSelect_Click(null, null);

			if (dgvPieceShipment.Rows.Count > 0)
			{
				// стать на первую строку, в ячейку "Коробок Факт"
				dgvPieceShipment.CurrentCell = dgvPieceShipment.Rows[0].Cells["dgvcBoxConfirmed1"];
			}

			if (oStoresZones.MainTable.Rows.Count == 0)
			{
				if (!bAgain)
				{
					RFMMessage.MessageBoxInfo("Для расхода нет неподтвержденных перемещений коробок/штук.\n\r" +
						"Нечего подтверждать...");
				}
			}

			return (oStoresZones.MainTable.Rows.Count);
		}

		public bool pagPiece_Restore()
		{
			return (dgvPieceShipment_Restore());
		}

		public bool pagWeight_Restore()
		{
			return (dgvWeightShipment_Restore());
		}

		private void btnSelect_Click(object sender, EventArgs e)
		{
			if (oOutput.TableOutputsTrafficsGoods == null || cboStoresZones.SelectedIndex <= -1 
					|| cboStoresZones.SelectedValue == null)
				return;

			tbcGoods.SetAllNeedRestore(true);
			pagPiece.Enabled = true;
			LastGrid.Select();
			for (int i = oStoresZones.MainTable.Rows.Count - 1; i >= 0; i--)
			{
				if ((int)oStoresZones.MainTable.Rows[i]["ID"] == (int)cboStoresZones.SelectedValue)
				{
					pagWeight.Enabled = (bool)oStoresZones.MainTable.Rows[i]["HasWGoods"];
					break;
				}
			}
			if (chkMultiSelectAllow.Checked)
			{
				btnApplyFilter.Enabled = true;
				chkMultiSelectAllow_CheckedChanged(null, null);
			}

			//if (dgvPieceShipment_Restore())
			//{
			//   dgvPieceShipment.Select();

			//   if (!btnApplyFilter.Enabled)
			//      btnApplyFilter.Enabled = true;
			//}
			//else
			//{
			//   RFMMessage.MessageBoxError("Ошибка получения данных о перемещениях коробок/штук...");
			//   Dispose();
			//}
		}

		private void cboStoresZones_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboStoresZones.SelectedIndex > -1 && cboStoresZones.SelectedValue != null)
			{
				btnSelect_Click(null, null);
				lastGrid.Select();
			}

		}

		#region Restore

		private bool dgvPieceShipment_Restore()
		{
			RFMCursorWait.LockWindowUpdate(dgvPieceShipment.Handle);

			oOutput.ClearError();

			RFMDataGridView dgv = dgvPieceShipment;
			dgv.Restore(CopyTable(oOutput.TableOutputsTrafficsGoods, "dtPiece", "NOT Weighting", ""));
			dgv.GridSource.Filter = (cboStoresZones.SelectedValue == null ?
					"false" :
					"StoreZoneSourceID = " + cboStoresZones.SelectedValue.ToString()) +
				(chkUnConfirmed.Checked ?
					" AND NOT IsConfirmed" :
					"");

			ShowStrikes();

			RFMCursorWait.LockWindowUpdate(IntPtr.Zero);
			return (oOutput.ErrorNumber == 0);
		}

		private bool dgvWeightShipment_Restore()
		{
			RFMCursorWait.LockWindowUpdate(dgvPieceShipment.Handle);
			
			oOutput.ClearError();

			RFMDataGridView dgv = dgvWeightShipment;
			dgv.Restore(CopyTable(oOutput.TableOutputsTrafficsGoods, "dtWeight", "Weighting", ""));
			dgv.GridSource.Filter = (cboStoresZones.SelectedValue == null ?
					"false" :
					"StoreZoneSourceID = " + cboStoresZones.SelectedValue.ToString()) +
				(chkUnConfirmed.Checked ?
					" AND NOT IsConfirmed" :
					"");
	
			ShowStrikes();

			RFMCursorWait.LockWindowUpdate(IntPtr.Zero);
			return (oOutput.ErrorNumber == 0);
		}

		private bool cboStoresZones_Restore()
		{
			oStoresZones.FilterStoreZoneTypeForPicking = true;
			oStoresZones.FillData();

			//
			DataColumn dc = new DataColumn(); 
			dc.DataType = System.Type.GetType("System.Boolean"); 
			dc.AllowDBNull = false; 
			dc.ColumnName = "HasWGoods"; 
			dc.DefaultValue = false;
			oStoresZones.MainTable.Columns.Add(dc); 
			//

			cboStoresZones.ValueMember = oStoresZones.ColumnID;
			cboStoresZones.DisplayMember = oStoresZones.MainTable.Columns[("Name")].ToString();
			cboStoresZones.DataSource = oStoresZones.MainTable;
			return (oStoresZones.ErrorNumber == 0);
		}

		private bool cboHeavers_Restore()
		{
			oUsers.FillData();
			cboHeavers.ValueMember = oUsers.ColumnID;
			cboHeavers.DisplayMember = oUsers.MainTable.Columns[("Name")].ToString();
			cboHeavers.DataSource = oUsers.MainTable;
			return (oUsers.ErrorNumber == 0);
		}

		#endregion

		#region GridCell...

		private void dgvPieceShipment_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			RFMDataGridView dgv = dgvPieceShipment;
			if (dgv.DataSource == null || dgv.CurrentRow == null)
				return;

			string ColName = dgv.Columns[e.ColumnIndex].Name;
			DataGridViewRow dgvr = dgv.Rows[e.RowIndex];

			bool lDecimalFormat = ((bool)dgvr.Cells["dgvcWeighting1"].Value
					|| (Convert.ToDecimal(dgvr.Cells["dgvcInBox1"].Value) != Convert.ToInt32(dgvr.Cells["dgvcInBox1"].Value)));
			switch (ColName.ToLower())
			{
				case "dgvcqntwished1":
				case "dgvcqntconfirmed1":
				case "dgvcinbox1":
					if (lDecimalFormat)
						e.CellStyle.Format = "### ### ### ###.000";
					else
						e.CellStyle.Format = "### ### ### ###";
					break;
			}


			if ((bool)dgvr.Cells["dgvcIsConfirmed1"].Value)
				e.CellStyle.BackColor = Color.FromArgb(250, 200, 200);
			else
			{
				if ((decimal)dgvr.Cells["dgvcQntConfirmed1"].Value != (decimal)dgvr.Cells["dgvcQntWished1"].Value)
				{
					if (ColName == "dgvcQntConfirmed1" || ColName == "dgvcBoxConfirmed1")
						e.CellStyle.BackColor = Color.FromArgb(255, 255, 128);
				}
			}
		}

		private void dgvWeightShipment_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			RFMDataGridView dgv = dgvWeightShipment;
			if (dgv.DataSource == null || dgv.CurrentRow == null)
				return;

			string ColName = dgv.Columns[e.ColumnIndex].Name;
			DataGridViewRow dgvr = dgv.Rows[e.RowIndex];

			if ((bool)dgvr.Cells["dgvcIsConfirmed2"].Value)
				e.CellStyle.BackColor = Color.FromArgb(250, 200, 200);
			else
			{
				if ((decimal)dgvr.Cells["dgvcQntConfirmed2"].Value != (decimal)dgvr.Cells["dgvcQntWished2"].Value)
				{
					if (ColName == "dgvcQntConfirmed2" || ColName == "dgvcBoxConfirmed2")
						e.CellStyle.BackColor = Color.FromArgb(255, 255, 128);
				}
			}
		}

		private void dgvPieceShipment_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
			if (dgvPieceShipment.Columns[e.ColumnIndex].Name.Contains("Qnt"))
			{
				DataRow dr = ((DataRowView)((DataGridViewRow)dgvPieceShipment.CurrentRow).DataBoundItem).Row;
				decimal nInbox = (decimal)dr["InBox"];
				((RFMDataGridViewTextBoxNumericColumn)dgvPieceShipment.Columns[e.ColumnIndex]).DecimalPlaces =
					(nInbox != (int)nInbox || (bool)dr["Weighting"]) ? 3 : 0;
			}
		}

		private void dgvPieceShipment_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
		{
			RFMDataGridView dgv = dgvPieceShipment;
			if (dgv.DataSource == null || e.RowIndex == -1 || e.ColumnIndex == -1)
				return;

			if ((bool)((DataRowView)dgv.Rows[e.RowIndex].DataBoundItem)["IsConfirmed"] &&
				dgv.Columns["dgvcIsChecked1"].Index == e.ColumnIndex)
			
			{
				using (
						Brush gridBrush = new SolidBrush(dgv.GridColor),
						backColorBrush = new SolidBrush(e.CellStyle.BackColor))
				{
					using (Pen gridLinePen = new Pen(gridBrush))
					{
						e.Graphics.FillRectangle(backColorBrush, e.CellBounds);

						e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left,
							e.CellBounds.Bottom - 1, e.CellBounds.Right - 1,
							e.CellBounds.Bottom - 1);

						e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1,
							e.CellBounds.Top, e.CellBounds.Right - 1,
							e.CellBounds.Bottom);
						e.Handled = true;
					}
				}
			}
		}

		private void dgvWeightShipment_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
		{
			RFMDataGridView dgv = dgvWeightShipment;
			if (dgv.DataSource == null || e.RowIndex == -1 || e.ColumnIndex == -1)
				return;

			if ((bool)((DataRowView)dgv.Rows[e.RowIndex].DataBoundItem)["IsConfirmed"] &&
				dgv.Columns["dgvcIsChecked2"].Index == e.ColumnIndex)
			{
				using (
						Brush gridBrush = new SolidBrush(dgv.GridColor),
						backColorBrush = new SolidBrush(e.CellStyle.BackColor))
				{
					using (Pen gridLinePen = new Pen(gridBrush))
					{
						e.Graphics.FillRectangle(backColorBrush, e.CellBounds);

						e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left,
							e.CellBounds.Bottom - 1, e.CellBounds.Right - 1,
							e.CellBounds.Bottom - 1);

						e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1,
							e.CellBounds.Top, e.CellBounds.Right - 1,
							e.CellBounds.Bottom);
						e.Handled = true;
					}
				}
			}
		}

		private void dgvPieceShipment_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			RFMDataGridView dgv = dgvPieceShipment;
			if (dgv.DataSource == null || e.RowIndex == -1 || e.ColumnIndex == -1)
				return;

			string ColName = dgv.Columns[e.ColumnIndex].Name;
			if (ColName == "dgvcQntConfirmed1" || ColName == "dgvcBoxConfirmed1" || ColName == "dgvcIsChecked1")
			{
				if ((bool)((DataRowView)dgv.CurrentRow.DataBoundItem)["IsConfirmed"])
					dgvcIsChecked1.ReadOnly = dgvcQntConfirmed1.ReadOnly = dgvcBoxConfirmed1.ReadOnly = true;
				else
				{
					dgvcIsChecked1.ReadOnly = false;
					dgvcQntConfirmed1.ReadOnly = dgvcBoxConfirmed1.ReadOnly = !(bool)dgv.Rows[e.RowIndex].Cells["dgvcIsChecked1"].Value;
				}
			}
		}

		private void dgvWeightShipment_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			RFMDataGridView dgv = dgvWeightShipment;
			if (dgv.DataSource == null || e.RowIndex == -1 || e.ColumnIndex == -1)
				return;

			string ColName = dgv.Columns[e.ColumnIndex].Name;
            if (ColName == "dgvcQntConfirmed2")
                btnCalc.Enabled = true;
            else
                btnCalc.Enabled = false;
			if (ColName == "dgvcQntConfirmed2" || ColName == "dgvcBoxConfirmed2" || ColName == "dgvcIsChecked2")
			{
				if ((bool)((DataRowView)dgv.CurrentRow.DataBoundItem)["IsConfirmed"])
					dgvcIsChecked2.ReadOnly = dgvcQntConfirmed2.ReadOnly = dgvcBoxConfirmed2.ReadOnly = true;
				else
				{
//					dgvcIsChecked2.ReadOnly = false;
//					dgvcQntConfirmed2.ReadOnly = dgvcBoxConfirmed2.ReadOnly = !(bool)dgv.Rows[e.RowIndex].Cells["dgvcIsChecked2"].Value;
// изменено 5.11.08
					dgvcIsChecked2.ReadOnly = dgvcQntConfirmed2.ReadOnly = dgvcBoxConfirmed2.ReadOnly = false;
				}
			}
		}

		private void dgvPieceShipment_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			RFMDataGridView dgv = dgvPieceShipment;
			string ColName = dgv.Columns[e.ColumnIndex].Name;

			if (ColName == "dgvcQntConfirmed1" || ColName == "dgvcBoxConfirmed1")
			{
				DataRowView drv = (DataRowView)dgv.CurrentRow.DataBoundItem;
				decimal nInbox = (decimal)drv["InBox"];

				if (ColName == "dgvcQntConfirmed1")
					drv["ForBoxConfirmed"] = (decimal)dgv.Rows[e.RowIndex].Cells["dgvcQntConfirmed1"].Value / nInbox;
				else
				{
					if (nInbox == (int)nInbox)
						drv["ForQntConfirmed"] = decimal.Ceiling(decimal.Round((decimal)dgv.Rows[e.RowIndex].Cells["dgvcBoxConfirmed1"].Value * nInbox, 1));
					else
						drv["ForQntConfirmed"] =(decimal)dgv.Rows[e.RowIndex].Cells["dgvcBoxConfirmed1"].Value * nInbox;
				}
				DataRow dr = oOutput.TableOutputsTrafficsGoods.Rows.Find(drv["ID"]);
				if (dr != null)
				{
					dr["ForBoxConfirmed"] = drv["ForBoxConfirmed"];
					dr["ForQntConfirmed"] = drv["ForQntConfirmed"];
				}
				
				ShowStrikes();
			}
		}

		private void dgvWeightShipment_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			RFMDataGridView dgv = dgvWeightShipment;
			string ColName = dgv.Columns[e.ColumnIndex].Name;

			if (ColName == "dgvcQntConfirmed2" || ColName == "dgvcBoxConfirmed2")
			{
				DataRowView drv = (DataRowView)dgv.CurrentRow.DataBoundItem;
				decimal nInBox = (decimal)drv["InBox"];

                // Проверка ошибочного ввода (вместо точки ввели запятую - стандартная ошибка)
                decimal nQntWished, nQntConfirmed;
                nQntWished = Convert.ToDecimal(dgv.Rows[e.RowIndex].Cells["dgvcQntWished2"].Value);
                nQntConfirmed = Convert.ToDecimal(dgv.Rows[e.RowIndex].Cells["dgvcQntConfirmed2"].Value);
                if (nQntConfirmed > nQntWished * 10)
                {
                    if (RFMMessage.MessageBoxYesNo("Фактическое количество в разы превышает заказанное. Продолжить?", false) == DialogResult.No)
                    {
                        drv["ForQntConfirmed"] = drv["ForBoxConfirmed"] = (decimal)0;
                        return;
                    }
                }
                // Конец проверки

				if (ColName == "dgvcQntConfirmed2")
					drv["ForBoxConfirmed"] = (decimal)dgv.Rows[e.RowIndex].Cells["dgvcQntConfirmed2"].Value / nInBox;
				else
					drv["ForQntConfirmed"] = (decimal)dgv.Rows[e.RowIndex].Cells["dgvcBoxConfirmed2"].Value * nInBox;

				DataRow dr = oOutput.TableOutputsTrafficsGoods.Rows.Find(drv["ID"]);
				if (dr != null)
				{
					dr["ForBoxConfirmed"] = drv["ForBoxConfirmed"];
					dr["ForQntConfirmed"] = drv["ForQntConfirmed"];
					// изменено 5.11.08
					if ((decimal)drv["ForQntConfirmed"] > 0)
					{
						dr["IsChecked"] = true;
						drv["IsChecked"] = true;
					}
				}
			}
		}

		private void dgvPieceShipment_CellValidated(object sender, DataGridViewCellEventArgs e)
		{
			if (!bLoaded)
				return;

			RFMDataGridView dgv = dgvPieceShipment;
			string ColName = dgv.Columns[e.ColumnIndex].Name;

			DataGridViewRow dgvr = dgv.Rows[e.RowIndex];
			if (ColName == "dgvcQntConfirmed1")
			{
				if (dgvr.Cells["dgvcQntConfirmed1"].Value == DBNull.Value)
					dgvr.Cells["dgvcQntConfirmed1"].Value = 0;

				if (!(bool)dgvr.Cells["dgvcWeighting1"].Value &&
					((decimal)dgvr.Cells["dgvcQntConfirmed1"].Value > (decimal)dgvr.Cells["dgvcQntWished1"].Value))
				{
					RFMMessage.MessageBoxError("Введено число больше допустимого!");
					dgvr.Cells["dgvcQntConfirmed1"].Value = (decimal)dgvr.Cells["dgvcQntWished1"].Value;
				}
			}

			if (ColName == "dgvcBoxConfirmed1")
			{
				if (dgvr.Cells["dgvcBoxConfirmed1"].Value == DBNull.Value)
					dgvr.Cells["dgvcBoxConfirmed1"].Value = 0;

				if (!(bool)dgvr.Cells["dgvcWeighting1"].Value &&
					(Math.Round((decimal)dgvr.Cells["dgvcBoxConfirmed1"].Value, 1) > Math.Round((decimal)dgvr.Cells["dgvcBoxWished1"].Value, 1)))
				{
					RFMMessage.MessageBoxError("Введено число больше допустимого!");
					dgvr.Cells["dgvcBoxConfirmed1"].Value = (decimal)dgvr.Cells["dgvcBoxWished1"].Value;
				}
			}
		}

		private void dgvWeightShipment_CellValidated(object sender, DataGridViewCellEventArgs e)
		{
			if (!bLoaded)
				return;

			RFMDataGridView dgv = dgvWeightShipment;
			string ColName = dgv.Columns[e.ColumnIndex].Name;
			DataGridViewRow dgvr = dgv.Rows[e.RowIndex];
			
			if (ColName == "dgvcQntConfirmed2")
			{
				if (dgvr.Cells["dgvcQntConfirmed2"].Value == DBNull.Value)
					dgvr.Cells["dgvcQntConfirmed2"].Value = 0;

				if (!(bool)dgvr.Cells["dgvcWeighting2"].Value &&
					((decimal)dgvr.Cells["dgvcQntConfirmed2"].Value > (decimal)dgvr.Cells["dgvcQntWished2"].Value))
				{
					RFMMessage.MessageBoxError("Введено число больше допустимого!");
					dgvr.Cells["dgvcQntConfirmed2"].Value = (decimal)dgvr.Cells["dgvcQntWished2"].Value;
				}
			}

			if (ColName == "dgvcBoxConfirmed2")
			{
				if (dgvr.Cells["dgvcBoxConfirmed2"].Value == DBNull.Value)
					dgvr.Cells["dgvcBoxConfirmed2"].Value = 0;

				if (!(bool)dgvr.Cells["dgvcWeighting2"].Value &&
					((decimal)dgvr.Cells["dgvcBoxConfirmed2"].Value > (decimal)dgvr.Cells["dgvcBoxWished2"].Value))
				{
					RFMMessage.MessageBoxError("Введено число больше допустимого!");
					dgvr.Cells["dgvcBoxConfirmed2"].Value = (decimal)dgvr.Cells["dgvcBoxWished2"].Value;
				}
			}
			ShowStrikes();
		}

		#endregion

		#region CalcStrikes

		private void ShowStrikes()
		{
			int rowCount = 0;
			decimal boxCount = 0;
			
			if (oOutput.TableOutputsTrafficsGoods != null)
			{
				DataView dv = new DataView(oOutput.TableOutputsTrafficsGoods);
				dv.RowFilter = "ForQntConfirmed < QntWished AND " +  
				(cboStoresZones.SelectedValue == null ?
				"false": "  StoreZoneSourceID = " + cboStoresZones.SelectedValue.ToString());
	
				rowCount = dv.Count;

				for (int i = 0; i < dv.Count; i++)
				{
					if ((decimal)dv[i].Row["ForQntConfirmed"] < (decimal)dv[i].Row["QntWished"])
						boxCount += Math.Round((decimal)dv[i].Row["BoxWished"] - (decimal)dv[i].Row["ForBoxConfirmed"], 1);
				}
				lblStrikePositionsData.Text = rowCount.ToString("# ##0");
				lblStrikeBoxesData.Text = boxCount.ToString("# ##0.0");
			}
			return;
		}

		#endregion

		private void btnExit_Click(object sender, EventArgs e)
		{
			Dispose();
		}

		private void btnHelp_Click(object sender, EventArgs e)
		{
			RFMHelpUtilities.HelpShow(this, hpHelp);
		}

		private void btnCheckAll_Click(object sender, EventArgs e)
		{
			CheckAll(true);
		}

		private void btnUnCheckAll_Click(object sender, EventArgs e)
		{
			CheckAll(false);
		}

		private void CheckAll(bool isChecked)
		{
			RFMDataGridView dgv = tbcGoods.SelectedTab.Name == "pagPiece" ? dgvPieceShipment : dgvWeightShipment;
			if (dgv.Rows.Count == 0)
				return;

			RFMCursorWait.LockWindowUpdate(dgv.Handle);

			for (int i = 0; i < dgv.RowCount; i++)
				((DataRowView)dgv.Rows[i].DataBoundItem)["IsChecked"] = isChecked;
			dgv.CommitChanges();
			
			RFMCursorWait.LockWindowUpdate(IntPtr.Zero);
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (cboStoresZones.SelectedIndex < 0 || cboStoresZones.SelectedValue == null)
			{
				RFMMessage.MessageBoxError("Не указана зона пикинга...");
				return;
			}

			if (cboHeavers.SelectedIndex < 0 || cboHeavers.SelectedValue == null)
			{
				RFMMessage.MessageBoxError("Не указан грузчик...");
				return;
			}

			DataTable dt = ((DataTable)dgvPieceShipment.GridSource.DataSource).DefaultView.ToTable();
			dt.Merge(dgvWeightShipment.GridSource == null ?
				CopyTable(oOutput.TableOutputsTrafficsGoods, "", "Weighting AND NOT IsConfirmed", "") :
				((DataTable)dgvWeightShipment.GridSource.DataSource).DefaultView.ToTable());

			RFMBindingSource bs = new RFMBindingSource(dt);
			bs.Filter = "IsChecked AND NOT IsConfirmed AND StoreZoneSourceID = " + cboStoresZones.SelectedValue.ToString();

			if (bs.Count == 0)
			{
				RFMMessage.MessageBoxError("Не отмечено ни одного перемещения...");
				return;
			}
			if (pagWeight.Enabled)
			{
				if (!bWeightingTry)
				{
					RFMMessage.MessageBoxAttention("Для выбранной зоны пикинга в накладной присутствует весовой товар!");
					tbcGoods.SelectedTab = pagWeight;
					dgvWeightShipment.Select();
					return;
				}
				DataTable dtW = ((DataTable)dgvWeightShipment.GridSource.DataSource).DefaultView.ToTable();
				RFMBindingSource bsW = new RFMBindingSource(dtW);
				bsW.Filter = "IsChecked AND NOT IsConfirmed AND StoreZoneSourceID = " + cboStoresZones.SelectedValue.ToString();
				if (bsW.Count == 0)
				{
					if (RFMMessage.MessageBoxYesNo("Не отмечено ни одного перемещения весового товара..\n\nВсе-таки подтвердить набор?") != DialogResult.Yes)
					{
						tbcGoods.SelectedTab = pagWeight;
						dgvWeightShipment.Select();
						return;
					}
				}
			}
//SERG
			//bool lChecked = false;
			//foreach (DataRow dr in tTable.Rows)
			//{
			//   if ((bool)dr["IsChecked"] && !(bool)dr["IsConfirmed"])
			//   {
			//      lChecked = true;
			//      break;
			//   }
			//}
			//if (!lChecked)
			//{
			//   RFMMessage.MessageBoxError("Не отмечено ни одного перемещения...");
			//   return;
			//}

			// подтверждение с прямым исправлением остатков в ячейке отгрузки?
			Setting oSet = new Setting();
			string sIfEasyConfirm = oSet.FillVariable("bEasyConfirm");
			bool bEasyConfirm = false;
			if (sIfEasyConfirm != null && sIfEasyConfirm.Length > 0)
			{
				try { bEasyConfirm = Convert.ToBoolean(sIfEasyConfirm); }
				catch { }
			}


			if (RFMMessage.MessageBoxYesNo("Подтвердить перемещения коробок/штук?") == DialogResult.Yes)
			{
				// и вот тут начинается большая песня с проверками
				int nPackingID;
				bool bIsEnough;
				decimal nDeficit = 0;
				decimal nInCell = 0;
				Cell oCellTemp = new Cell();
				TrafficFrame oTrafficFrameTemp = new TrafficFrame();

				bs.MoveFirst();
				DataRowView drv;
				for (int i = 0; i < bs.Count; i++)
				{
					drv = (DataRowView)bs.Current;

					bIsEnough = false;
					nPackingID = Convert.ToInt32(drv["PackingID"]);
					nInCell = 0;
					nDeficit = 0;

					oCellTemp.ClearError();

					oCellTemp.ID = Convert.ToInt32(drv["CellSourceID"]);

					if ((int)oCellTemp.ID == nLostFoundID)
					{
						bs.MoveNext();
						continue;
					}
					
					oCellTemp.FillData();

					// привязки
					DataRow drCell = oCellTemp.MainTable.Rows[0];
					if (!Convert.IsDBNull(drCell["FixedPackingID"]) && Convert.ToInt32(drCell["FixedPackingID"]) != nPackingID)
					{
						RFMMessage.MessageBoxError(drv["GoodAlias"] + ":\nЯчейка " + drCell["Address"].ToString() + " имеет фиксированную привязку к другому товару...");
						bs.MoveNext();
						continue;
					}
					if (!Convert.IsDBNull(drCell["FixedGoodStateID"]) && Convert.ToInt32(drCell["FixedGoodStateID"]) != nGoodStateID)
					{
						RFMMessage.MessageBoxError(drv["GoodAlias"] + ":\nЯчейка " + drCell["Address"].ToString() + " имеет фиксированную привязку к другому состоянию...");
						bs.MoveNext();
						continue;
					}
					if ((bSeparatePicking && ((!Convert.IsDBNull(drCell["FixedOwnerID"]) && Convert.ToInt32(drCell["FixedOwnerID"]) != nOwnerID) || Convert.IsDBNull(drCell["FixedOwnerID"])))
						|| (!bSeparatePicking && !Convert.IsDBNull(drCell["FixedOwnerID"])))
					{
						RFMMessage.MessageBoxError(drv["GoodAlias"] + ":\nЯчейка " + drCell["Address"].ToString() + " имеет фиксированную привязку к другому хранителю...");
						bs.MoveNext();
						continue;
					}

					// всего требуется данного товара
					decimal nQntConfirmed = 0;
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
						DataRow dr = dt.Rows[j];
						if ((int)dr["PackingID"] == nPackingID)
                            nQntConfirmed += (decimal)dr["ForQntConfirmed"];
                    }

					// сейчас в ячейке-источнике данного товара
					oCellTemp.FillTableCellsContents(oCellTemp.ID, true);
					foreach (DataRow drContent in oCellTemp.TableCellsContents.Rows)
					{
						if (bSeparatePicking)
						{
							if (Convert.ToInt32(drContent["PackingID"]) == nPackingID &&
									Convert.ToInt32(drContent["GoodStateID"]) == nGoodStateID &&
									!Convert.IsDBNull(drContent["OwnerID"]) &&
									Convert.ToInt32(drContent["OwnerID"]) == nOwnerID)
							{
								if (Convert.ToDecimal(drContent["Qnt"]) >= nQntConfirmed)
									bIsEnough = true;
								else
									nInCell += Convert.ToDecimal(drContent["Qnt"]);
							}
						}
						else
						{
							if (Convert.ToInt32(drContent["PackingID"]) == nPackingID &&
									Convert.ToInt32(drContent["GoodStateID"]) == nGoodStateID &&
									Convert.IsDBNull(drContent["OwnerID"]))
							{
								if (Convert.ToDecimal(drContent["Qnt"]) >= nQntConfirmed)
									bIsEnough = true;
								else
									nInCell += Convert.ToDecimal(drContent["Qnt"]);
							}
						}

						if (nInCell >= nQntConfirmed)
							bIsEnough = true;

						if (bIsEnough)
							break;
					}

					// прошли все содержимое ячейки. товара не хватает
					if (!bIsEnough)
					{
//						nDeficit = Convert.ToDecimal(drv["ForQntConfirmed"]) - nInCell;
                        nDeficit = nQntConfirmed - nInCell;
						if (!bEasyConfirm)
						{
							// есть ли в нее трафики?
							oTrafficFrameTemp.FilterCellsTargetList = oCellTemp.ID.ToString();
							oTrafficFrameTemp.FilterConfirmed = false;
							oTrafficFrameTemp.FillData();
							if (oTrafficFrameTemp.MainTable.Rows.Count > 0)
							{
								//RFMMessage.MessageBoxAttention("ВНИМАНИЕ!\n" +
								//   "В ячейке " + drCell["Address"].ToString() + " недостаточно товара (" + Convert.ToDecimal(nDeficit).ToString("# ##0").Trim() + " шт.)\n" +
								//   dr["GoodAlias"].ToString() + ".\n\n" +
								//   "Есть невыполненные операции транспортировки паллет в эту ячейку (контейнер " + oTrafficFrameTemp.MainTable.Rows[0]["FrameID"] + ") .");*/
								RFMMessage.MessageBoxAttention("ВНИМАНИЕ!\n" +
									 "В ячейке " + drCell["Address"].ToString() + " недостаточно товара\n" +
									 drv["GoodAlias"].ToString() + ".\n\n" +
									 "Есть невыполненные операции транспортировки паллет в эту ячейку (контейнер " + oTrafficFrameTemp.MainTable.Rows[0]["FrameID"] + ") .");
								bs.MoveNext();
								continue;
							}
							else
							{
								// трафиков нет. сами изменим состояние ячейки
								//string sDeficitText = (Convert.ToBoolean(dr["Weighting"])) ?
								//  (Convert.ToDecimal(nDeficit).ToString("# ##0.000").Trim() + " кг") :
								//  RFMPublic.RFMUtilities.Declen(Convert.ToInt32(Math.Floor(nDeficit)), "штук", "штук", "штук");
								string sDeficitText;
								if (Convert.ToBoolean(drv["Weighting"]))
									sDeficitText = Convert.ToDecimal(nDeficit).ToString("# ##0.000").Trim() + " кг";
								else
								{
									decimal nInBox = Convert.ToDecimal(drv["InBox"]);
									int nFullBoxes = Convert.ToInt32(Math.Floor(nDeficit / nInBox));
									int nPieces = Convert.ToInt32(nDeficit - nFullBoxes * nInBox);

									sDeficitText = nFullBoxes.ToString() + " кор.";
									if (nPieces != 0) sDeficitText = sDeficitText + "+" + nPieces.ToString() + " шт.";
								}
								if (RFMMessage.MessageBoxYesNo("ВНИМАНИЕ!\n" +
									 "В ячейке " + drCell["Address"].ToString() + " не хватает товара (" + sDeficitText + ").\n" +
									 drv["GoodAlias"].ToString() + "\n\n" +
									 "Невыполненных операций транспортировки паллет в эту ячейку нет.\n\n" +
									 "Выполнить исправление состояния ячейки на " + sDeficitText + "?", false) == DialogResult.Yes)
								{
									oCellTemp.MedicationDirect((int)oCellTemp.ID, nGoodStateID, nOwnerID,
										 nPackingID, nDeficit, ((RFMFormMain)Application.OpenForms[0]).UserID,
										 "Исправление состояния ячейки для подтверждения перемещений по расходу с кодом " + oOutput.ID.ToString());
								}
							}
						}
						else
							oCellTemp.MedicationDirect((int)oCellTemp.ID, nGoodStateID, nOwnerID,
								 nPackingID, nDeficit, ((RFMFormMain)Application.OpenForms[0]).UserID,
								 "Исправление состояния ячейки для подтверждения перемещений по расходу с кодом " + oOutput.ID.ToString());
					}
					
					bs.MoveNext();
				}
				Refresh();
				WaitOn(this);
				oOutput.ClearError();
				bool bResult = oOutput.ConfirmTraffics(ID, false, chkMinusAllowed.Checked, (int)cboHeavers.SelectedValue, ((DataTable)bs.DataSource).DefaultView.ToTable());
				WaitOff(this);
				if (bResult && oOutput.ErrorNumber == 0)
				{
					RFMMessage.MessageBoxInfo("Подтверждены перемещения коробок/штук.");
					if (chkMultiSelectAllow.Checked && !(btnApplyFilter.Enabled)) 
					{
						btnApplyFilter.Enabled = true;
						oOutput.FillTableOutputsTraffics(ID, false);
						if (oOutput.ErrorNumber != 0)
							RFMMessage.MessageBoxError("Ошибка при получении данных о перемещениях коробок/штук для расхода...");
						else
						{
							dgvWeightShipment_Restore();
							if (((DataTable)dgvWeightShipment.GridSource.DataSource).Rows.Count > 0)
								pagWeight.Enabled = true;

							dgvPieceShipment_Restore();
							dgvPieceShipment.Select();
						}
					}						
					else
					{
						DialogResult = DialogResult.Yes;
						Dispose();
					}
				}
				else
					RFMMessage.MessageBoxError("Ошибка подтверждения перемещения коробок/штук...");
			}
		}

		private void txtTabNumber_TextChanged(object sender, EventArgs e)
		{
			if (txtTabNumber.Text.Trim().Length == 3)
			{
				string sTabNumber = txtTabNumber.Text.Trim();
				bool bFound = false;
				foreach (DataRow dr in oUsers.MainTable.Rows)
				{
					string sBarCode = dr["BarCode"].ToString();
					if (sBarCode.Substring(sBarCode.Length - 3, 3) == sTabNumber)
					{
						cboHeavers.SelectedValue = Convert.ToInt32(dr["ID"]);
						bFound = true;
						break;
					}
				}
				if (!bFound)
				{
					cboHeavers.SelectedIndex = -1;
				}
			}
		}

		private void btnApplyFilter_Click(object sender, EventArgs e)
		{
			btnApplyFilter.Enabled = false;
			if (tbcGoods.CurrentPage.Name.ToLower() == "pagpiece")
			{
				SetGoodsFilter(ref dgvPieceShipment);
				pagWeight.Enabled = false;
			}
			else
			{
				SetGoodsFilter(ref dgvWeightShipment);
				pagPiece.Enabled = true;				
			}
			tbcGoods.SetAllNeedRestore(false);
			ShowStrikes();
		}

		private void SetGoodsFilter(ref RFMDataGridView dgv)
		{
			DataTable dt = oOutput.TableOutputsTrafficsGoods.Clone();

			int rowCount = dgv.SelectedRows.Count;
			if (rowCount > 0)
			{
				for (int i = 0; i < rowCount; i++)
					dt.ImportRow(((DataRowView)dgv.SelectedRows[i].DataBoundItem).Row);

			}
			dgv.Restore(dt);
			if (dt.Rows.Count > 0)
				dgv.GridSource.Filter = "NOT IsConfirmed";
		}

		private void tbcGoods_Selected(object sender, TabControlEventArgs e)
		{
			if (tbcGoods.SelectedTab == pagPiece)
				dgvPieceShipment.Select();
			else
			{
				dgvWeightShipment.Select();
				if  (!bWeightingTry)
					bWeightingTry = true;
			}
		}

		private void dgvWeightShipment_Enter(object sender, EventArgs e)
		{
			RFMDataGridView dgv = dgvWeightShipment;
			if (dgv.DataSource == null || dgv.CurrentRow == null)
				return;

			if (!dgv.CurrentCell.OwningColumn.Name.ToLower().Contains("confirmed"))
				dgv.CurrentCell = dgv.CurrentRow.Cells["dgvcQntConfirmed2"];
		}

		private void dgvPieceShipment_Enter(object sender, EventArgs e)
		{
			RFMDataGridView dgv = dgvPieceShipment;
			if (dgv.DataSource == null || dgv.CurrentRow == null)
				return;

			if (!dgv.CurrentCell.OwningColumn.Name.ToLower().Contains("confirmed"))
				dgv.CurrentCell = dgv.CurrentRow.Cells["dgvcBoxConfirmed1"];
		}

		private void chkMultiSelectAllow_CheckedChanged(object sender, EventArgs e)
		{
			dgvWeightShipment.MultiSelect = dgvPieceShipment.MultiSelect =
				btnApplyFilter.Enabled = chkMultiSelectAllow.Checked;

			if (chkMultiSelectAllow.Checked)
				dgvPieceShipment.SelectionMode = dgvWeightShipment.SelectionMode =
				DataGridViewSelectionMode.FullRowSelect;
			else
				dgvPieceShipment.SelectionMode = dgvWeightShipment.SelectionMode =
					DataGridViewSelectionMode.CellSelect;
			lastGrid.Refresh();

		}

		private void StoreZonesClear()
		{
			DataView dv = new DataView(oOutput.TableOutputsTrafficsGoods);
			DataRow dr;
			for (int i = oStoresZones.MainTable.Rows.Count - 1; i >= 0; i--)
			{
				dv.RowFilter = "StoreZoneSourceID = " + oStoresZones.MainTable.Rows[i]["ID"].ToString();
				if (chkUnConfirmed.Checked)
					dv.RowFilter += " AND NOT IsConfirmed";
				if (dv.Count == 0)
					oStoresZones.MainTable.Rows.Remove(oStoresZones.MainTable.Rows[i]);
				else
				{
					dv.RowFilter += " AND Weighting";
					if (dv.Count != 0)
					{
						dr = oStoresZones.MainTable.Rows[i];
						dr["HasWGoods"] = true;
					}
				}
			}
		}

        private void btnCalc_Click(object sender, EventArgs e)
        {
			if (dgvWeightShipment.Rows.Count == 0 || dgvWeightShipment.CurrentRow == null)
				return;

			DataRowView drv = (DataRowView)dgvWeightShipment.CurrentRow.DataBoundItem;
			
			if (StartProgram.ParamStore != null)
            {
                for (int i = 0; i < StartProgram.ParamStore.GetLength(0); i++)
                {
                    StartProgram.ParamStore.SetValue(null, i);
                }
            }
            
            if (new frmCounter(false, 3, drv["GoodAlias"].ToString(), "").ShowDialog() == DialogResult.Yes)
            {
                if (StartProgram.ParamStore.GetValue(1) == null)
                {
                    StartProgram.ParamStore.SetValue(0, 1);
                }

                // само значение
                decimal nQnt = 0;
                bool bResult = decimal.TryParse(StartProgram.ParamStore.GetValue(1).ToString(), out nQnt);
                if (bResult) // && nQnt > 0
                {
                    decimal nInbox = (decimal)drv["InBox"];
                    drv["ForQntConfirmed"] = nQnt;

                    drv["ForBoxConfirmed"] = nQnt / nInbox;
		
		    		DataRow dr = oOutput.TableOutputsTrafficsGoods.Rows.Find(drv["ID"]);
			    	if (dr != null)
				    {
					    dr["ForBoxConfirmed"] = drv["ForBoxConfirmed"];
					    dr["ForQntConfirmed"] = drv["ForQntConfirmed"];
    					if ((decimal)drv["ForQntConfirmed"] > 0)
	    				{
		    				dr["IsChecked"] = true;
			    			drv["IsChecked"] = true;
				    	}
				    }
			    }

				if (StartProgram.ParamStore.GetValue(0) == null)
                {
                    StartProgram.ParamStore.SetValue("", 0);
                }
                
				dgvWeightShipment.Select();
            }

			if (StartProgram.ParamStore != null)
            {
                for (int i = 0; i < StartProgram.ParamStore.GetLength(0); i++)
                {
                    StartProgram.ParamStore.SetValue(null, i);
                }
            }
        }

        private void frmOutputsGoodsConfirm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.U && e.Modifiers == Keys.Control)
            {
                if (btnCalc.Enabled)
                {
                    btnCalc_Click(null, null);
                    return;
                }
            }
        }

        private void tbcGoods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!tbcGoods.SelectedTab.Name.ToLower().Contains("weight"))
                btnCalc.Enabled = false;
        }

        //private void btnApplyFilter_Click(object sender, EventArgs e)
		//{
		//   int nSelectedRowCount = dgvPieceShipment.Rows.GetRowCount(DataGridViewElementStates.Selected);
		//   if (nSelectedRowCount > 0)
		//   {
		//      btnApplyFilter.Enabled = false;

		//      tSelectedTable = tTable.Clone();

		//      DataRow dr;
		//      for (int _i = 0; _i < nSelectedRowCount; _i++)
		//      {
		//         dr = tTable.Rows.Find(((int)dgvPieceShipment.SelectedRows[_i].Cells["dgvcID1"].Value));
		//         if (dr != null)
		//            tSelectedTable.ImportRow(dr);
		//      }
		//      tTable.Clear();
		//      //tTable = tSelectedTable.Copy();
		//      tTable = CopyTable(tSelectedTable, "tTable", "", "CellSourceRank, CellSourceAddress, GoodAlias");
		//      tTable.PrimaryKey = new DataColumn[] { tTable.Columns["ID"] };

		//      dgvPieceShipment.GridSource = new RFMBindingSource(tTable);
		//      if (chkUnConfirmed.Checked)
		//         dgvPieceShipment.GridSource.Filter = "NOT IsConfirmed";
				
		//      dgvPieceShipment.Restore(dgvPieceShipment.GridSource);
		//      ShowStrikes();
		//   }
		//}
	}
}