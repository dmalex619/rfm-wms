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
		private DataTable tTable; // источник grid 

		private int nGoodStateID;
		private int nOwnerID;
		private bool bSeparatePicking;

		private int nLostFoundID = 0;
		private string sLostFoundAddress = "";

		private bool bLoaded = false;


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

				dgvOutputGoodsShipment.ReadOnly = false;
				foreach (DataGridViewColumn c in dgvOutputGoodsShipment.Columns)
				{
					c.ReadOnly = !(c.Name.Contains("Check") || c.Name.Contains("Confirmed"));
				}
			}
		}

		private void frmOutputEdit_Load(object sender, EventArgs e)
		{
			bool blResult = cboStoresZones_Restore() &&
							cboHeavers_Restore();
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
			DataRow r = oOutput.MainTable.Rows[0];
			txtID.Text = r["ID"].ToString();
			txtErpCode.Text = r["ErpCode"].ToString();
			txtDateOutput.Text = r["DateOutput"].ToString().Substring(0, 10);
			txtOutputBarCode.Text = r["BarCode"].ToString();

			txtOwnerName.Text = r["OwnerName"].ToString();
			txtPartnerName.Text = r["PartnerName"].ToString();

			txtGoodStateName.Text = r["GoodStateName"].ToString();
			txtOutputTypeName.Text = r["OutputTypeName"].ToString();
			txtCellAdress.Text = r["CellAddress"].ToString();

			nGoodStateID = Convert.ToInt32(r["GoodStateID"]);
			nOwnerID = Convert.ToInt32(r["OwnerID"]);
			bSeparatePicking = Convert.ToBoolean(r["SeparatePicking"]);

			// заполнение таблицы
			if (ForLoad(false) == 0)
			{
				Dispose();
				return;
			}

			ShowStrikes();

            cboHeavers.SelectedIndex = -1;
			if (oStoresZones.MainTable.Rows.Count == 1)
			{
				cboStoresZones.SelectedIndex = 0;
				btnSelect_Click(null, null);
				dgvOutputGoodsShipment.Select();
			}
			else
			{
				cboStoresZones.SelectedIndex = -1;
				dgvOutputGoodsShipment.DataSource = null;
				cboStoresZones.Select();
			}

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
			for (int i = oStoresZones.MainTable.Rows.Count - 1; i >= 0; i--)
			{
				DataView dv = new DataView(oOutput.TableOutputsTrafficsGoods);
				dv.RowFilter = "StoreZoneSourceID = " + oStoresZones.MainTable.Rows[i]["ID"].ToString();
				if (chkUnConfirmed.Checked)
				{
					dv.RowFilter += " and IsConfirmed = false";
				}
				if (dv.Count == 0)
				{
					oStoresZones.MainTable.Rows.Remove(oStoresZones.MainTable.Rows[i]);
				}
			}
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
				dvlf.RowFilter += " and IsConfirmed = false";
			}
			if (dvlf.Count > 0)
			{
				// найдем эту зону и добавим ее в список
				StoreZone oStoreZoneVirtual = new StoreZone();
				oStoreZoneVirtual.FillData(); 
				foreach(DataRow sz in oStoreZoneVirtual.MainTable.Rows)
				{
					if (Convert.ToBoolean(sz["Special"]))
					{
						sz["Name"] = "_неизвестен";
						oStoresZones.MainTable.ImportRow(sz);
					}
				}
			}

			/*
			if (oStoresZones.MainTable.Rows.Count <= 1)
			{
				cboStoresZones.Enabled = false;
			}
			*/ 

			btnSelect_Click(null, null);

			if (dgvOutputGoodsShipment.Rows.Count > 0)
			{
				// стать на первую строку, в ячейку "Коробок Факт"
				dgvOutputGoodsShipment.CurrentCell = dgvOutputGoodsShipment.Rows[0].Cells["dgrcBoxConfirmed"];
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

		private void btnSelect_Click(object sender, EventArgs e)
		{
			if (!dgvOuputsShipment_Restore())
			{
				RFMMessage.MessageBoxError("Ошибка получения данных о перемещениях коробок/штук...");
				Dispose();
			}
		}

		private void cboStoresZones_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboStoresZones.SelectedIndex >= 0 && cboStoresZones.SelectedValue != null &&
				tTable != null)
			{
				btnSelect_Click(null, null);
			}
		}

		#region Restore

		private bool dgvOuputsShipment_Restore()
		{
			RFMCursorWait.LockWindowUpdate(dgvOutputGoodsShipment.Handle);

			/*
			oTrafficsGoods.FilterOutputsList = ID.ToString();
			if (cboStoresZones.SelectedValue != null)
			{
				oTrafficsGoods.FilterStoresZonesSourceList = cboStoresZones.SelectedValue.ToString();
			}
			oTrafficsGoods.FillData();
			oTrafficsGoods.MainTable.PrimaryKey = new DataColumn[] { oTrafficsGoods.MainTable.Columns["TrafficID"] };
			dgvOutputGoodsShipment.DataSource = oTrafficsGoods.MainTable;
			*/

			dgvOutputGoodsShipment.DataSource = null;
			tTable = null;
			oOutput.ClearError();

			if (cboStoresZones.SelectedValue != null)
			{
				DataView dvz = new DataView(oOutput.TableOutputsTrafficsGoods);
				dvz.RowFilter = "StoreZoneSourceID = " + cboStoresZones.SelectedValue.ToString();
				tTable = dvz.ToTable();
				tTable.PrimaryKey = new DataColumn[] { tTable.Columns["ID"] };
			}
			else
			{
				tTable = oOutput.TableOutputsTrafficsGoods;
			}

			dgvOutputGoodsShipment.GridSource = new RFMBindingSource(tTable);
			if (chkUnConfirmed.Checked)
			{
				dgvOutputGoodsShipment.GridSource.Filter = "IsConfirmed = false";
			}
			dgvOutputGoodsShipment.Restore(dgvOutputGoodsShipment.GridSource);

			ShowStrikes(); 

			RFMCursorWait.LockWindowUpdate(IntPtr.Zero);
			return (oOutput.ErrorNumber == 0);
		}

		private bool cboStoresZones_Restore()
		{
			oStoresZones.FilterStoreZoneTypeForPicking = true;
			oStoresZones.FillData();
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

		private void dgvOutputGoodsShipment_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (dgvOutputGoodsShipment.DataSource == null || dgvOutputGoodsShipment.CurrentRow == null)
				return;
			
			DataRow droRow = tTable.Rows.Find((int)dgvOutputGoodsShipment.Rows[e.RowIndex].Cells["dgrcID"].Value);
			if (droRow == null)
				return;

			if ((bool)droRow["IsConfirmed"])
				e.CellStyle.BackColor = Color.FromArgb(250, 200, 200);
			else
			{
				if ((decimal)droRow["ForQntConfirmed"] != (decimal)droRow["QntWished"])
				{
					if (dgvOutputGoodsShipment.Columns[e.ColumnIndex].Name == "dgrcQntConfirmed" || 
						dgvOutputGoodsShipment.Columns[e.ColumnIndex].Name == "dgrcBoxConfirmed")
					e.CellStyle.BackColor = Color.FromArgb(255, 255, 128);
				}
			}

			switch (dgvOutputGoodsShipment.Columns[e.ColumnIndex].Name)
			{
				case "dgrcInBox":
				case "dgrcQntWished":
				case "dgrcQntConfirmed":
					if ( (!Convert.IsDBNull(droRow["Weighting"]) && Convert.ToBoolean(droRow["Weighting"])) ||
						  !Convert.IsDBNull(e.Value) && Convert.ToDecimal(e.Value) != Convert.ToInt32(e.Value) )
						e.CellStyle.Format = "### ### ### ###.000";
					else
						e.CellStyle.Format = "### ### ### ###";
					break;
			}
		}

		private void dgvOutputGoodsShipment_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
		{
			if (dgvOutputGoodsShipment.DataSource == null || e.RowIndex == -1 || e.ColumnIndex == -1)
				return;

			DataRow droRow = tTable.Rows.Find((int)dgvOutputGoodsShipment.Rows[e.RowIndex].Cells["dgrcID"].Value);
			if (droRow == null)
				return;

			if ((bool)droRow["IsConfirmed"] &&
				dgvOutputGoodsShipment.Columns["dgrcCheck"].Index == e.ColumnIndex)
			{
				using (
						Brush gridBrush = new SolidBrush(this.dgvOutputGoodsShipment.GridColor),
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

		private void dgvOutputGoodsShipment_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (dgvOutputGoodsShipment.DataSource == null || e.RowIndex == -1 || e.ColumnIndex == -1)
				return;
			if (dgvOutputGoodsShipment.Columns[e.ColumnIndex].Name == "dgrcQntConfirmed" ||
				dgvOutputGoodsShipment.Columns[e.ColumnIndex].Name == "dgrcBoxConfirmed" ||
				dgvOutputGoodsShipment.Columns[e.ColumnIndex].Name == "dgrcCheck")
			{
				DataRow droRow = tTable.Rows.Find((int)dgvOutputGoodsShipment.Rows[e.RowIndex].Cells["dgrcID"].Value);

				if (droRow == null)
					return;

				if ((bool)droRow["IsConfirmed"])
				{
					dgrcCheck.ReadOnly = true;
					dgrcQntConfirmed.ReadOnly = 
					dgrcBoxConfirmed.ReadOnly = true;
				}
				else
				{
					dgrcCheck.ReadOnly = false;
					if ((bool)dgvOutputGoodsShipment.Rows[e.RowIndex].Cells["dgrcCheck"].Value)
					{
						dgrcQntConfirmed.ReadOnly = 
						dgrcBoxConfirmed.ReadOnly = false;
					}
					else
					{
						dgrcQntConfirmed.ReadOnly = 
						dgrcBoxConfirmed.ReadOnly = true;
					}
					dgvOutputGoodsShipment.BeginEdit(true);
				}
			}
		}

		private void dgvOutputGoodsShipment_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if (tTable.Rows.Count == 0 || tTable == null)
				return;

			if (dgvOutputGoodsShipment.Columns[e.ColumnIndex].Name == "dgrcQntConfirmed" ||
				dgvOutputGoodsShipment.Columns[e.ColumnIndex].Name == "dgrcBoxConfirmed" ||
				dgvOutputGoodsShipment.Columns[e.ColumnIndex].Name == "dgrcCheck")
			{
				DataRow droRow = tTable.Rows.Find((int?)dgvOutputGoodsShipment.Rows[e.RowIndex].Cells["dgrcID"].Value);
				if (droRow != null)
				{
					droRow["Checked"] = (bool)dgvOutputGoodsShipment.Rows[e.RowIndex].Cells["dgrcCheck"].Value;

					decimal nInbox = (decimal)droRow["InBox"];
					if (dgvOutputGoodsShipment.Columns[e.ColumnIndex].Name == "dgrcQntConfirmed")
					{ 
						// меняем штуки
						droRow["ForQntConfirmed"] = (decimal)dgvOutputGoodsShipment.Rows[e.RowIndex].Cells["dgrcQntConfirmed"].Value;
						droRow["ForBoxConfirmed"] = (decimal)dgvOutputGoodsShipment.Rows[e.RowIndex].Cells["dgrcQntConfirmed"].Value / nInbox;
						dgvOutputGoodsShipment.Rows[e.RowIndex].Cells["dgrcBoxConfirmed"].Value = (decimal)droRow["ForBoxConfirmed"];
					}
					if (dgvOutputGoodsShipment.Columns[e.ColumnIndex].Name == "dgrcBoxConfirmed")
					{
						// меняем коробки
						droRow["ForBoxConfirmed"] = (decimal)dgvOutputGoodsShipment.Rows[e.RowIndex].Cells["dgrcBoxConfirmed"].Value;
						if ((bool)dgvOutputGoodsShipment.Rows[e.RowIndex].Cells["dgrcWeighting"].Value)
							droRow["ForQntConfirmed"] = (decimal)dgvOutputGoodsShipment.Rows[e.RowIndex].Cells["dgrcBoxConfirmed"].Value * nInbox;
						else
							droRow["ForQntConfirmed"] = (decimal.Ceiling)((decimal)dgvOutputGoodsShipment.Rows[e.RowIndex].Cells["dgrcBoxConfirmed"].Value * nInbox);
							dgvOutputGoodsShipment.Rows[e.RowIndex].Cells["dgrcQntConfirmed"].Value = (decimal)droRow["ForQntConfirmed"];
					}
					ShowStrikes();
					dgvOutputGoodsShipment.Refresh();
				}
			}
		}

		private void dgvOutputGoodsShipment_CellValidated(object sender, DataGridViewCellEventArgs e)
		{
			if (!bLoaded)
				return;

			RFMCursorWait.LockWindowUpdate(FindForm().Handle);

			DataGridViewRow r = dgvOutputGoodsShipment.Rows[e.RowIndex];
			if (dgvOutputGoodsShipment.Columns[e.ColumnIndex].Name == "dgrcQntConfirmed")
			{
				if (r.Cells["dgrcQntConfirmed"].Value == DBNull.Value)
				{
					r.Cells["dgrcQntConfirmed"].Value = 0;
				}
				if (!(bool)r.Cells["dgrcWeighting"].Value && 
					((decimal)r.Cells["dgrcQntConfirmed"].Value > (decimal)r.Cells["dgrcQntWished"].Value))
				{
					RFMMessage.MessageBoxError("Введено число больше допустимого!");
					r.Cells["dgrcQntConfirmed"].Value = (decimal)r.Cells["dgrcQntWished"].Value;
				}
			}

			if (dgvOutputGoodsShipment.Columns[e.ColumnIndex].Name == "dgrcBoxConfirmed")
			{
				if (r.Cells["dgrcBoxConfirmed"].Value == DBNull.Value)
				{
					r.Cells["dgrcBoxConfirmed"].Value = 0;
				}
				if (!(bool)r.Cells["dgrcWeighting"].Value && 
					((decimal)r.Cells["dgrcBoxConfirmed"].Value > (decimal)r.Cells["dgrcBoxWished"].Value))
				{
					RFMMessage.MessageBoxError("Введено число больше допустимого!");
					r.Cells["dgrcBoxConfirmed"].Value = (decimal)r.Cells["dgrcBoxWished"].Value;
				}
			}
			ShowStrikes();
			dgvOutputGoodsShipment.Refresh();

			RFMCursorWait.LockWindowUpdate(IntPtr.Zero);
		}

		private void dgvOutputGoodsShipment_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			e.Control.KeyDown += delegate(object pressSender, KeyEventArgs e_keypress)
			{
				if ((e_keypress.KeyCode < Keys.D0) || (e_keypress.KeyCode > Keys.D9))
				{
					// не цифры
					if (!(e_keypress.KeyCode == Keys.Oemcomma ||
						e_keypress.KeyCode == Keys.Shift ||
						e_keypress.KeyCode == Keys.Left ||
						e_keypress.KeyCode == Keys.Right ||
						e_keypress.KeyCode == Keys.Tab ||
						e_keypress.KeyCode == Keys.Back ||
						e_keypress.KeyCode == Keys.Delete ||
						e_keypress.KeyCode == Keys.End ||
						e_keypress.KeyCode == Keys.Home ||
						e_keypress.KeyCode == Keys.Decimal ||
						((e_keypress.KeyCode >= Keys.NumPad0) && (e_keypress.KeyCode <= Keys.NumPad9)) ) )
					{
						e_keypress.SuppressKeyPress = true;
					}
				}
			};
		}

		#endregion

		#region CalcStrikes

		private void ShowStrikes()
		{
			// вычерки по отношению к подобранному (в данном случае это TrafficsGoods.QntWished)! 
			int nStrikePositions = 0;
			decimal nStrikeBoxes = 0;
			if (tTable != null && tTable.Rows.Count > 0)
			{
				foreach (DataRow r in tTable.Rows)
				{
					if (!Convert.ToBoolean(r["IsConfirmed"]))
					{
                        /*
						if (Convert.ToDecimal(r["ForQntConfirmed"]) == 0)
						{
							nStrikePositions++;
						}
                        */ 
						if (Convert.ToDecimal(r["ForQntConfirmed"]) != Convert.ToDecimal(r["QntWished"]))
						{
                            nStrikePositions++;
							nStrikeBoxes += Math.Round((Convert.ToDecimal(r["QntWished"]) - Convert.ToDecimal(r["ForQntConfirmed"])) / Convert.ToDecimal(r["InBox"]), 1);
						}
					}
				}
			}
			lblStrikePositionsData.Text = nStrikePositions.ToString("# ##0");
			lblStrikeBoxesData.Text = nStrikeBoxes.ToString("# ##0.0");
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
			if (dgvOutputGoodsShipment.Rows.Count == 0)
				return;

			RFMCursorWait.LockWindowUpdate(FindForm().Handle);

            if (dgvOutputGoodsShipment.CurrentCell.ColumnIndex == dgrcCheck.Index)
            {
                dgvOutputGoodsShipment.CurrentCell = dgvOutputGoodsShipment.Rows[dgvOutputGoodsShipment.CurrentRow.Index].Cells[dgrcCheck.Index + 1];
            }

            for (int i = 0; i < tTable.Rows.Count; i++)
            {
                tTable.Rows[i]["Checked"] = isChecked;
            }
            
            for (int i = 0; i < dgvOutputGoodsShipment.RowCount; i++)
			{
                dgvOutputGoodsShipment.Rows[i].Cells["dgrcCheck"].Value = isChecked;
            }
			dgvOutputGoodsShipment.Refresh();

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

			bool lChecked = false;
			foreach (DataRow r in tTable.Rows)
			{
				if ((bool)r["Checked"] && !(bool)r["IsConfirmed"])
					lChecked = true;
			}
			if (!lChecked)
			{
				RFMMessage.MessageBoxError("Не отмечено ни одного перемещения...");
				return;
			}

            // подтверждение с прямым исправлением остатков в ячейке отгрузки?
            Setting oSet = new Setting();
            string sIfEasyConfirm = oSet.FillVariable("bEasyConfirm");
            bool bEasyConfirm = false;
            if (sIfEasyConfirm != null && sIfEasyConfirm.Length > 0)
            {
                try
                {
                    bEasyConfirm = Convert.ToBoolean(sIfEasyConfirm);
                }
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

				foreach (DataRow r in tTable.Rows)
				{
					if (!Convert.ToBoolean(r["Checked"]) || Convert.ToBoolean(r["IsConfirmed"]))
						continue;

					bIsEnough = false;
					nPackingID = Convert.ToInt32(r["PackingID"]);
					nInCell = 0;
					nDeficit = 0;

					oCellTemp.ClearError();

					oCellTemp.ID = Convert.ToInt32(r["CellSourceID"]);
					oCellTemp.FillData();
					// привязки
					DataRow rCell = oCellTemp.MainTable.Rows[0];
					if (!Convert.IsDBNull(rCell["FixedPackingID"]) && 
						Convert.ToInt32(rCell["FixedPackingID"]) != nPackingID)
					{ 
						RFMMessage.MessageBoxError("Ячейка " + rCell["Address"].ToString() + " имеет фиксированную привязку к другому товару...");
						continue;
					}
                    if (!Convert.IsDBNull(rCell["FixedGoodStateID"]) &&
                        Convert.ToInt32(rCell["FixedGoodStateID"]) != nGoodStateID)
                    {
                        RFMMessage.MessageBoxError("Ячейка " + rCell["Address"].ToString() + " имеет фиксированную привязку к другому состоянию...");
                        continue;
                    }
                    if ( 
                        (bSeparatePicking && 
                          (
                          (!Convert.IsDBNull(rCell["FixedOwnerID"]) && Convert.ToInt32(rCell["FixedOwnerID"]) != nOwnerID) ||
                          Convert.IsDBNull(rCell["FixedOwnerID"]) 
                          )
                        )
                        ||
                        (!bSeparatePicking &&
                         !Convert.IsDBNull(rCell["FixedOwnerID"])) 
                       )
                    {
                        RFMMessage.MessageBoxError("Ячейка " + rCell["Address"].ToString() + " имеет фиксированную привязку к другому хранителю...");
                        continue;
                    }

					oCellTemp.FillTableCellsContents(oCellTemp.ID, true);
					foreach (DataRow cc in oCellTemp.TableCellsContents.Rows)
					{
						if (bSeparatePicking)
						{
							if (Convert.ToInt32(cc["PackingID"]) == nPackingID &&
								Convert.ToInt32(cc["GoodStateID"]) == nGoodStateID &&
								!Convert.IsDBNull(cc["OwnerID"]) &&
								Convert.ToInt32(cc["OwnerID"]) == nOwnerID)
							{
								if (Convert.ToDecimal(cc["Qnt"]) >= Convert.ToDecimal(r["ForQntConfirmed"]))
								{
									bIsEnough = true;
								}
								else
								{
									nInCell += Convert.ToDecimal(cc["Qnt"]);
								}
							}
						}
						else
						{
							if (Convert.ToInt32(cc["PackingID"]) == nPackingID &&
								Convert.ToInt32(cc["GoodStateID"]) == nGoodStateID &&
								Convert.IsDBNull(cc["OwnerID"]))
							{
								if (Convert.ToDecimal(cc["Qnt"]) >= Convert.ToDecimal(r["ForQntConfirmed"]))
								{
									bIsEnough = true;
								}
								else
								{
									nInCell += Convert.ToDecimal(cc["Qnt"]);
								}
							}
						}
						if (bIsEnough)
						{
							break;
						}
					}
					// прошли содержимое ячейки. товара не хватает
                    if (!bIsEnough)
					{
                        nDeficit = Convert.ToDecimal(r["ForQntConfirmed"]) - nInCell;

                        if (!bEasyConfirm)
                        {
                            // есть ли в нее трафики?
                            oTrafficFrameTemp.FilterCellsTargetList = oCellTemp.ID.ToString();
                            oTrafficFrameTemp.FilterConfirmed = false;
                            oTrafficFrameTemp.FillData();
                            if (oTrafficFrameTemp.MainTable.Rows.Count > 0)
                            {
                                /*RFMMessage.MessageBoxAttention("ВНИМАНИЕ!\n" +
                                    "В ячейке " + rCell["Address"].ToString() + " недостаточно товара (" + Convert.ToDecimal(nDeficit).ToString("# ##0").Trim() + " шт.)\n" +
                                    r["GoodAlias"].ToString() + ".\n\n" +
                                    "Есть невыполненные операции транспортировки паллет в эту ячейку (контейнер " + oTrafficFrameTemp.MainTable.Rows[0]["FrameID"] + ") .");*/
                                RFMMessage.MessageBoxAttention("ВНИМАНИЕ!\n" +
                                    "В ячейке " + rCell["Address"].ToString() + " недостаточно товара\n" +
                                    r["GoodAlias"].ToString() + ".\n\n" +
                                    "Есть невыполненные операции транспортировки паллет в эту ячейку (контейнер " + oTrafficFrameTemp.MainTable.Rows[0]["FrameID"] + ") .");
                                continue;
                            }
                            else
                            {
                                // трафиков нет. сами изменим состояние ячейки
                                /*string sDeficitText = (Convert.ToBoolean(r["Weighting"])) ?
                                        (Convert.ToDecimal(nDeficit).ToString("# ##0.000").Trim() + " кг") :
                                        RFMPublic.RFMUtilities.Declen(Convert.ToInt32(Math.Floor(nDeficit)), "штук", "штук", "штук");*/
                                string sDeficitText;
                                if (Convert.ToBoolean(r["Weighting"]))
                                {
                                    sDeficitText = Convert.ToDecimal(nDeficit).ToString("# ##0.000").Trim() + " кг";
                                }
                                else
                                {
                                    decimal nInBox = Convert.ToDecimal(r["InBox"]);
                                    int nFullBoxes = Convert.ToInt32(Math.Floor(nDeficit / nInBox));
                                    int nPieces = Convert.ToInt32(nDeficit - nFullBoxes * nInBox);

                                    sDeficitText = nFullBoxes.ToString() + " кор.";
                                    if (nPieces != 0) sDeficitText = sDeficitText + "+" + nPieces.ToString() + " шт.";
                                }
                                if (RFMMessage.MessageBoxYesNo("ВНИМАНИЕ!\n" +
                                    "В ячейке " + rCell["Address"].ToString() + " не хватает товара (" + sDeficitText + ").\n" +
                                    r["GoodAlias"].ToString() + "\n\n" +
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
                        {
                            oCellTemp.MedicationDirect((int)oCellTemp.ID, nGoodStateID, nOwnerID,
                                nPackingID, nDeficit, ((RFMFormMain)Application.OpenForms[0]).UserID,
                                "Исправление состояния ячейки для подтверждения перемещений по расходу с кодом " + oOutput.ID.ToString());
                        }
					}
				}
				// прошли все товары 

				Refresh();
				WaitOn(this);
				oOutput.ClearError();
				bool bResult = oOutput.ConfirmTraffics(ID, false, chkMinusAllowed.Checked, (int)cboHeavers.SelectedValue, tTable);
				WaitOff(this);
				if (bResult && oOutput.ErrorNumber == 0)
				{
					RFMMessage.MessageBoxInfo("Подтверждены перемещения коробок/штук.");
					DialogResult = DialogResult.Yes;
					Dispose();
					/*
					if (ForLoad(true) == 0)
					{
						DialogResult = DialogResult.Yes;
						Dispose();
					}
					*/ 
				}
				else
				{
					RFMMessage.MessageBoxError("Ошибка подтверждения перемещения коробок/штук...");
				}
			}
		}

        private void txtTabNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtTabNumber.Text.Trim().Length == 3)
            {
                string sTabNumber = txtTabNumber.Text.Trim();
                bool bFound = false;
                foreach (DataRow r in oUsers.MainTable.Rows)
                { 
                    string sBarCode = r["BarCode"].ToString();
                    if (sBarCode.Substring(sBarCode.Length - 3, 3) == sTabNumber)
                    {
                        cboHeavers.SelectedValue = Convert.ToInt32(r["ID"]);
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
	}
}
