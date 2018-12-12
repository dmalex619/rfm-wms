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
	public partial class frmOutputsConfirm : RFMFormChild
	{
		private int ID;
		private Output oOutput;
		private DataTable tTablePieceGoods, tTableWeightGoods;
		private bool bWeightingTry = false;
		private bool bValidOK = true;

		bool bWeightEnter = false;

		public frmOutputsConfirm(int? _ID)
		{
			oOutput = new Output();
			if (oOutput.ErrorNumber != 0) 
				IsValid = false;
			if (IsValid)
			{
				InitializeComponent();

				if (_ID.HasValue)
					ID = (int)_ID;
			}
		}

		private void frmOutputsConfirm_Load(object sender, EventArgs e)
		{
			oOutput.ID = ID;
			oOutput.FillTableOutputsGoods(oOutput.ID);
			if (oOutput.ErrorNumber != 0)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о расходе...");
				Dispose();
			}
			if (oOutput.TableOutputsGoods.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Нет товаров в расходе...");
				Dispose();
			}

			if  (!dgvPieceGoods_Restore() || !dgvWeightGoods_Restore())
			{
				RFMMessage.MessageBoxError("Ошибка получения данных о товарах в расходе...");
				Dispose();
			}
			btnCalc.Enabled = false;
			oOutput.ClearError();
			oOutput.FillData();

			if (oOutput.ErrorNumber != 0 || oOutput.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о расходе...");
				Dispose();
			}

			DataRow r = oOutput.MainTable.Rows[0];

			if (Convert.IsDBNull(oOutput.MainTable.Rows[0]["CellID"]))
			{
				RFMMessage.MessageBoxError("Не задана ячейка отгрузки для расхода...");
				Dispose();
			}

			txtID.Text = r["ID"].ToString();
			txtErpCode.Text = r["ErpCode"].ToString();
			txtDateOutput.Text = r["DateOutput"].ToString().Substring(0, 10);
			txtOutputBarCode.Text = r["BarCode"].ToString();

			txtOwnerName.Text = r["OwnerName"].ToString();
			txtPartnerName.Text = r["PartnerName"].ToString();

			txtGoodStateName.Text = r["GoodStateName"].ToString();
			txtOutputTypeName.Text = r["OutputTypeName"].ToString();
			txtCellAdress.Text = r["CellAddress"].ToString();
	
			ShowStrikes();
			ShowHumanStrikes();

			tcGoods.Init();
			dgvPieceGoods.ReadOnly = dgvWeightGoods.ReadOnly = false ;
			if (dgvPieceGoods.Rows.Count > 0)
			{
				foreach (DataGridViewColumn dgvc in dgvPieceGoods.Columns)
				{
					dgvc.ReadOnly = !(dgvc.Name.Contains("Confirmed"));
				}
				// встать на первую строку, в ячейку "Коробок Факт"
				dgvPieceGoods.Select();
				dgvPieceGoods.CurrentCell = dgvPieceGoods.Rows[0].Cells["dgvcBoxConfirmed1"];
			}

			if (dgvWeightGoods.Rows.Count > 0)
			{
				foreach (DataGridViewColumn dgvc in dgvWeightGoods.Columns)
				{
					dgvc.ReadOnly = !(dgvc.Name.Contains("Confirmed"));
				}
				dgvWeightGoods.Select();
				dgvWeightGoods.CurrentCell = dgvWeightGoods.Rows[0].Cells["dgvcQntConfirmed2"];

			}
			else
				tabWeight.Enabled = false;
			btnCalc.Enabled = false;
		}

		#region Restore

		private bool dgvPieceGoods_Restore()
		{
			foreach (DataRow droRow in oOutput.TableOutputsGoods.Rows)
			{
//				droRow["BoxConfirmed"] = droRow["BoxSelected"];
//				droRow["QntConfirmed"] = droRow["QntSelected"];
				// предлагаемое значение - собранное в ячейке отгрузки (Picked), но не больше заказанного (Wished) - old
				// предлагаемое значение - собранное в ячейке отгрузки (Picked), но не больше заказанного (WisOdd) - new
			if (Convert.ToDecimal(droRow["QntPicked"]) > Convert.ToDecimal(droRow["QntWished"]) &&
					!Convert.ToBoolean(droRow["Weighting"]) && !Convert.ToBoolean(droRow["HalfStuff"])) 
				{
					droRow["BoxConfirmed"] = droRow["BoxWished"];
					droRow["QntConfirmed"] = droRow["QntWished"];
				}
			else
				{
					droRow["BoxConfirmed"] = droRow["BoxPicked"];
					droRow["QntConfirmed"] = droRow["QntPicked"];
				}
			}
         //tTablePieceGoods = CopyTable(oOutput.TableOutputsGoods, "tTablePieceGoods", "NOT Weighting", "StoreZoneName, GoodGroupName, GoodAlias");
			tTablePieceGoods = CopyTable(oOutput.TableOutputsGoods, "tTablePieceGoods", "NOT Weighting", "StoreZoneName, GoodGroupName, Rank, CLine, Address, GoodAlias");
			oOutput.TableOutputsGoods.PrimaryKey = new DataColumn[] { oOutput.TableOutputsGoods.Columns["OutputGoodID"] };
			dgvPieceGoods.Restore(tTablePieceGoods);
			ShowHumanStrikes();
			return (true);
		}

		private bool dgvWeightGoods_Restore()
		{
			//tTableWeightGoods = CopyTable(oOutput.TableOutputsGoods, "tTableWeightGoods", "Weighting", "StoreZoneName, GoodGroupName, GoodAlias");
			tTableWeightGoods = CopyTable(oOutput.TableOutputsGoods, "tTableWeightGoods", "Weighting", "StoreZoneName, GoodGroupName, Rank, CLine, Address, GoodAlias");
			if (tTableWeightGoods.Rows.Count > 0)
			{
				dgvWeightGoods.Restore(tTableWeightGoods);
				ShowHumanStrikes();
			}
			return (true);
		}

		#endregion

		#region Cell...

		private void dgvPieceGoods_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			RFMDataGridView dgv = dgvPieceGoods;
			
			if (dgv.DataSource == null || dgv.CurrentRow == null || dgv.RowCount == 0)
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

			if ((decimal)dgvr.Cells["dgvcQntConfirmed1"].Value < (decimal)dgvr.Cells["dgvcQntWished1"].Value)
			{
				if (ColName == "dgvcQntConfirmed1" || ColName == "dgvcBoxConfirmed1")
				{
					if ((decimal)dgvr.Cells["dgvcQntConfirmed1"].Value == 0)
					{
						dgvr.Cells["dgvcGoodAlias1"].Style.Font = new Font(e.CellStyle.Font, FontStyle.Strikeout);
						e.CellStyle.BackColor = Color.FromArgb(250, 200, 200);
					}
					else
					{
						if ((decimal)dgvr.Cells["dgvcQntConfirmed1"].Value != (decimal)dgvr.Cells["dgvcQntWished1"].Value)
						{
							e.CellStyle.BackColor = Color.FromArgb(250, 200, 200);
						}
						if ((decimal)dgvr.Cells["dgvcQntConfirmed1"].Value != (decimal)dgvr.Cells["dgvcQntSelected1"].Value)
						{
							e.CellStyle.BackColor = Color.FromArgb(255, 255, 128);
						}
					}
				}
			}
		}

		private void dgvWeightGoods_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			RFMDataGridView dgv = dgvWeightGoods;

			if (dgv.DataSource == null || dgv.CurrentRow == null || dgv.RowCount == 0)
				return;

			string ColName = dgv.Columns[e.ColumnIndex].Name;

			DataGridViewRow dgvr = dgv.Rows[e.RowIndex];

			if ((decimal)dgvr.Cells["dgvcQntConfirmed2"].Value < (decimal)dgvr.Cells["dgvcQntWished2"].Value)
			{
				if (ColName == "dgvcQntConfirmed2" || ColName == "dgvcBoxConfirmed2")
				{
					if ((decimal)dgvr.Cells["dgvcQntConfirmed2"].Value == 0)
					{
						dgvr.Cells["dgvcGoodAlias2"].Style.Font = new Font(e.CellStyle.Font, FontStyle.Strikeout);
						e.CellStyle.BackColor = Color.FromArgb(250, 200, 200);
					}
					else
					{
						if ((decimal)dgvr.Cells["dgvcQntConfirmed2"].Value != (decimal)dgvr.Cells["dgvcQntWished2"].Value)
						{
							e.CellStyle.BackColor = Color.FromArgb(250, 200, 200);
						}
						if ((decimal)dgvr.Cells["dgvcQntConfirmed2"].Value != (decimal)dgvr.Cells["dgvcQntSelected2"].Value)
						{
							e.CellStyle.BackColor = Color.FromArgb(255, 255, 128);
						}
					}
				}
			}
		}

		private void dgvPieceGoods_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
			if (dgvPieceGoods.Columns[e.ColumnIndex].Name.Contains("Qnt"))
			{
				DataRow dr = ((DataRowView)((DataGridViewRow)dgvPieceGoods.CurrentRow).DataBoundItem).Row;
				decimal nInBox = (decimal)dr["InBox"];
				((RFMDataGridViewTextBoxNumericColumn)dgvPieceGoods.Columns[e.ColumnIndex]).DecimalPlaces =
					(nInBox != (int)nInBox || (bool)dr["Weighting"]) ? 3 : 0;
			}
		}

		private void dgvPieceGoods_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if (dgvPieceGoods.IsRestoring)
				return;

			RFMDataGridView dgv = dgvPieceGoods;

			if (dgv.DataSource == null || dgv.CurrentRow == null || dgv.RowCount == 0)
				return;

			string ColName = dgv.Columns[e.ColumnIndex].Name;

			if (ColName == "dgvcQntConfirmed1" || ColName == "dgvcBoxConfirmed1")
			{
				DataGridViewRow dgrv = dgv.Rows[e.RowIndex];
				decimal nInBox = (decimal)dgrv.Cells["dgvcInBox1"].Value;

				if (ColName == "dgvcQntConfirmed1")
					dgrv.Cells["dgvcBoxConfirmed1"].Value = (decimal)dgrv.Cells["dgvcQntConfirmed1"].Value / nInBox;
				else
				{
					if (nInBox == (int)nInBox)
						dgrv.Cells["dgvcQntConfirmed1"].Value = decimal.Ceiling(decimal.Round((decimal)dgrv.Cells["dgvcBoxConfirmed1"].Value * nInBox, 1));
					else
						dgrv.Cells["dgvcQntConfirmed1"].Value = (decimal)dgrv.Cells["dgvcBoxConfirmed1"].Value * nInBox;
				}
				DataRow dr = oOutput.TableOutputsGoods.Rows.Find(dgrv.Cells["dgvcID1"].Value);
				if (dr != null)
				{
					dr["BoxConfirmed"] = dgrv.Cells["dgvcBoxConfirmed1"].Value;
					dr["QntConfirmed"] = dgrv.Cells["dgvcQntConfirmed1"].Value;
				}
				ShowHumanStrikes();
			}
		}

		private void dgvWeightGoods_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if  (!bWeightEnter) return;

			RFMDataGridView dgv = dgvWeightGoods;

			if (dgv.DataSource == null || dgv.CurrentRow == null || dgv.RowCount == 0 || e.ColumnIndex < 0)
				return;

			string ColName = dgv.Columns[e.ColumnIndex].Name;

			if (ColName == "dgvcQntConfirmed2" || ColName == "dgvcBoxConfirmed2")
			{
				DataGridViewRow dgrv = dgv.Rows[e.RowIndex];
				decimal nInBox = (decimal)dgrv.Cells["dgvcInBox2"].Value;

                // Проверка ошибочного ввода (вместо точки ввели запятую - стандартная ошибка)
                decimal nQntWished, nQntConfirmed;
                nQntWished = Convert.ToDecimal(dgv.Rows[e.RowIndex].Cells["dgvcQntWished2"].Value);
                nQntConfirmed = Convert.ToDecimal(dgv.Rows[e.RowIndex].Cells["dgvcQntConfirmed2"].Value);
                if (nQntConfirmed > nQntWished * 10)
                {
                    if (RFMMessage.MessageBoxYesNo("Фактическое количество существенно превышает заказанное. Продолжить?", false) == DialogResult.No)
                    {
						dgrv.Cells["dgvcQntConfirmed2"].Value = (decimal)dgrv.Cells["dgvcQntPicked2"].Value; //dgvcQntSelected2
						dgrv.Cells["dgvcBoxConfirmed2"].Value = (decimal)dgrv.Cells["dgvcQntPicked2"].Value / nInBox; // dgvcQntSelected2
                        return;
                    }
                }
                // Конец проверки

                if (ColName == "dgvcQntConfirmed2")
					dgrv.Cells["dgvcBoxConfirmed2"].Value = (decimal)dgrv.Cells["dgvcQntConfirmed2"].Value / nInBox;
				else
					dgrv.Cells["dgvcQntConfirmed2"].Value = (decimal)dgrv.Cells["dgvcBoxConfirmed2"].Value * nInBox;

				DataRow dr = oOutput.TableOutputsGoods.Rows.Find(dgrv.Cells["dgvcID2"].Value);
				if (dr != null)
				{
					dr["BoxConfirmed"] = dgrv.Cells["dgvcBoxConfirmed2"].Value;
					dr["QntConfirmed"] = dgrv.Cells["dgvcQntConfirmed2"].Value;
				}
				ShowHumanStrikes();
			}
		}

		private void dgvPieceGoods_CellValidated(object sender, DataGridViewCellEventArgs e)
		{
			if (dgvPieceGoods.IsRestoring)
				return;

			RFMDataGridView dgv = dgvPieceGoods;
			string ColName = dgv.Columns[e.ColumnIndex].Name;
			DataGridViewRow dgvr = dgv.Rows[e.RowIndex];

			if (ColName == "dgvcQntConfirmed1" &&
					!(bool)dgvr.Cells["dgvcHalfStuff1"].Value &&
					!(bool)dgvr.Cells["dgvcWeighting1"].Value && 
					(dgvr.Cells["dgvcQntConfirmed1"].Value == DBNull.Value ||
					((decimal)dgvr.Cells["dgvcQntConfirmed1"].Value > (decimal)dgvr.Cells["dgvcQntWished1"].Value)))
			{
				if (dgvr.Cells["dgvcQntConfirmed1"].Value == DBNull.Value)
				{
					dgvr.Cells["dgvcQntConfirmed1"].Value = 0;
				}
				else
				{
					RFMMessage.MessageBoxError("Введено число больше допустимого!");
					dgvr.Cells["dgvcQntConfirmed1"].Value = dgvr.Cells["dgvcQntWished1"].Value;
				}
				bValidOK = false;
			}

			if (ColName == "dgvcBoxConfirmed1" &&
					!(bool)dgvr.Cells["dgvcHalfStuff1"].Value &&
					!(bool)dgvr.Cells["dgvcWeighting1"].Value && (
					dgvr.Cells["dgvcBoxConfirmed1"].Value == DBNull.Value ||
					((decimal)dgvr.Cells["dgvcBoxConfirmed1"].Value > (decimal)dgvr.Cells["dgvcBoxWished1"].Value)))
			{
				if (dgvr.Cells["dgvcBoxConfirmed1"].Value == DBNull.Value)
				{
					dgvr.Cells["dgvcBoxConfirmed1"].Value = 0;
				}
				else
				{
					RFMMessage.MessageBoxError("Введено число больше допустимого!");
					dgvr.Cells["dgvcBoxConfirmed1"].Value = dgvr.Cells["dgvcBoxWished1"].Value;
				}
				bValidOK = false;
			}
        }

		#endregion

		#region CalcStrikes

        private void ShowStrikes()
        {
            // вычерки автоматические: подбор по отношению к заказу! QntSelected vs. QntWished - old
			// вычерки автоматические: подбор по отношению к заказу! QntSelected vs. QntOdd    - new
			int nStrikePositions = 0;
            decimal nStrikeBoxes = 0;
				foreach (DataRow r in oOutput.TableOutputsGoods.Rows)
            {
				//if (Convert.ToDecimal(r["QntSelected"]) != Convert.ToDecimal(r["QntWished"]))
				if (Convert.ToDecimal(r["QntSelected"]) == (decimal)0)
				{
					nStrikePositions++;
					nStrikeBoxes += Math.Round((Convert.ToDecimal(r["QntWished"]) - Convert.ToDecimal(r["QntSelected"])) / Convert.ToDecimal(r["InBox"]), 1);
				}
			}
			lblStrikePositionsData.Text = nStrikePositions.ToString("# ##0");
			lblStrikeBoxesData.Text = nStrikeBoxes.ToString("# ##0.0");
        }
				
		private void ShowHumanStrikes()
		{
			// вычерки по отношению к заказу! QntConfirmed vs. QntWished - old
			// вычерки по отношению к заказу! QntConfirmed vs. QntOdd    - new
			int nStrikePositions = 0;
			decimal nStrikeBoxes = 0;
			foreach (DataRow r in oOutput.TableOutputsGoods.Rows)
			{ 
				/*
				if (Convert.ToDecimal(r["QntConfirmed"]) == 0)
				{
					nStrikePositions++;
				}
				*/
				//if (Convert.ToDecimal(r["QntConfirmed"]) != Convert.ToDecimal(r["QntWished"]))
				if (Convert.ToDecimal(r["QntConfirmed"]) < Convert.ToDecimal(r["QntWished"]))
				{
					nStrikePositions++;
					nStrikeBoxes += Math.Round((Convert.ToDecimal(r["QntWished"]) - Convert.ToDecimal(r["QntConfirmed"])) / Convert.ToDecimal(r["InBox"]), 1);
				}
			}
			lblStrikeHumanPositionsData.Text = nStrikePositions.ToString("# ##0");
			lblStrikeHumanBoxesData.Text = nStrikeBoxes.ToString("# ##0.0");
		}

		#endregion 

		#region Buttons
		
		private void btnExit_Click(object sender, EventArgs e)
		{
			Dispose();
		}

		private void btnHelp_Click(object sender, EventArgs e)
		{
			RFMHelpUtilities.HelpShow(this, hpHelp);
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			bool bFoundConfirmed, bWGoodsConfirmed;
			bFoundConfirmed = bWGoodsConfirmed = false;
			bool bHasWeights = (tTableWeightGoods.Rows.Count > 0);
			DataGridViewCellEventArgs oDgvcea;
			oDgvcea = new DataGridViewCellEventArgs(LastGrid.CurrentCell.ColumnIndex, LastGrid.CurrentRow.Index);
			if (LastGrid.IsCurrentCellDirty)
			{
				bValidOK = true;
				LastGrid.CommitChanges();
				if (lastGrid == dgvPieceGoods)
				{
					dgvPieceGoods_CellValidated(dgvPieceGoods, oDgvcea);
					dgvPieceGoods_CellEndEdit(dgvPieceGoods, oDgvcea);
				}
				else
				{
					dgvWeightGoods_CellEndEdit(dgvWeightGoods, oDgvcea);
				}
				if (!bValidOK)
				{
					LastGrid.CurrentRow.Cells[LastGrid.CurrentCell.ColumnIndex].Selected = true;
					return;
				}
			}
			if (bHasWeights)
			{
				foreach (DataRow dr in tTableWeightGoods.Rows)
				{
					if ((decimal)dr["QntConfirmed"] > 0)
					{
						bWGoodsConfirmed = bFoundConfirmed = true;
						break;
					}
				}
			}
			if (!bWGoodsConfirmed)
			{
				foreach (DataRow dr in oOutput.TableOutputsGoods.Rows)
				{
					if ((decimal)dr["QntConfirmed"] > 0)
					{
						bFoundConfirmed = true;
						break;
					}
				}
			}
			if (!bFoundConfirmed)
			{ 
				if (RFMMessage.MessageBoxYesNo("Внимание!\n\nНе подтверждено ни одного товара.\n\nВсе-таки подтвердить расход?") != DialogResult.Yes) 
					return;
			}
			if (bHasWeights && !bWeightingTry)
			{
				RFMMessage.MessageBoxAttention("В накладной имеется весовой товар!");
				tcGoods.SelectedTab = tabWeight;
				dgvWeightGoods.Select();
				return;
			}
			if (bHasWeights && !bWGoodsConfirmed)
			{
				if (RFMMessage.MessageBoxYesNo("Внимание!\n\nНе подтверждено ни одного весового товара.\n\nВсе-таки подтвердить расход?") != DialogResult.Yes)
				{
					dgvWeightGoods.Select();
					return;
				}
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

			Cell oCell = new Cell();
			oCell.ID = (int)oOutput.MainTable.Rows[0]["CellID"];
			oCell.FillTableCellsContents(oCell.ID, true);
			StringBuilder sbCellLess   = new StringBuilder("");
			StringBuilder sbCellAbsent = new StringBuilder("");
			StringBuilder sbWished     = new StringBuilder("");
			StringBuilder sbSelected   = new StringBuilder("");
			StringBuilder sbPicked	   = new StringBuilder("");
			Boolean bInOut;
			int nGoodStateID = (int)oOutput.MainTable.Rows[0]["GoodStateID"];
			int nOwnerID    = (int)oOutput.MainTable.Rows[0]["OwnerID"];
			foreach (DataRow droOutGoods in oOutput.TableOutputsGoods.Rows)
			{
				bInOut = false;
				foreach (DataRow droCellGoods in oCell.TableCellsContents.Rows)
				{
					if ((bool)oOutput.MainTable.Rows[0]["SeparatePicking"])
					{
						if ((int)droCellGoods["PackingID"] == (int)droOutGoods["PackingID"] &&
							(int)droCellGoods["GoodStateID"] == nGoodStateID) 
//							&& 		(int)droCellGoods["OwnerID"] == nOwnerID)
						{
							bInOut = true;
							if ((decimal)droCellGoods["Qnt"] < (decimal)droOutGoods["QntConfirmed"])
								sbCellLess = sbCellLess.Append(droOutGoods["GoodAlias"].ToString() + "\r\n");
						}
					}
					else
					{
						if ((int)droCellGoods["PackingID"] == (int)droOutGoods["PackingID"] &&
							(int)droCellGoods["GoodStateID"] == nGoodStateID &&
                            Convert.IsDBNull(droCellGoods["OwnerID"]))
						{
							bInOut = true;
							if ((decimal)droCellGoods["Qnt"] < (decimal)droOutGoods["QntConfirmed"])
								sbCellLess = sbCellLess.Append(droOutGoods["GoodAlias"].ToString() + "\r\n");
						}
					}
				}
				if (!bInOut && (decimal)droOutGoods["QntConfirmed"] > 0) 
					sbCellAbsent = sbCellAbsent.Append(droOutGoods["GoodAlias"].ToString() + "\r\n");
				if (((decimal)droOutGoods["QntConfirmed"] > 0) && 
						((decimal)droOutGoods["QntConfirmed"] != (decimal)droOutGoods["QntWished"]))
					sbWished = sbWished.Append(droOutGoods["GoodAlias"].ToString() + "\r\n");

				if (((decimal)droOutGoods["QntConfirmed"] > 0) && 
					((decimal)droOutGoods["QntConfirmed"] != (decimal) droOutGoods["QntSelected"]))
					sbSelected = sbSelected.Append(droOutGoods["GoodAlias"].ToString() + "\r\n");

				if (((decimal)droOutGoods["QntConfirmed"] > 0) &&
					((decimal)droOutGoods["QntConfirmed"] != (decimal)droOutGoods["QntPicked"]))
					sbPicked = sbPicked.Append(droOutGoods["GoodAlias"].ToString() + "\r\n");
			}
			
			if (!bEasyConfirm)
            {
                if (sbCellAbsent.Length > 0)
                {
                    //if (RFMMessage.MessageBoxYesNo("В ячейке отгрузки отсутствуют товары:\r\n" +
                    //	sbCellAbsent + "Все-таки подтвердить расход?") == DialogResult.No)
                    RFMMessage.MessageBoxError("В ячейке отгрузки отсутствуют товары:\r\n" +
                        sbCellAbsent +
                        "Подтверждение расхода невозможно.");
                    return;
                }
                if (sbCellLess.Length > 0)
                {
                    //if (RFMMessage.MessageBoxYesNo("Для следующих товаров:\r\n" + sbCellLess + "количество в ячейке отгрузки меньше, чем подтверждаемое количество.\r\n" +
                    //	"Все-таки подтвердить расход?") == DialogResult.No)
                    RFMMessage.MessageBoxError("Для следующих товаров:\r\n" + sbCellLess + "количество в ячейке отгрузки меньше, чем подтверждаемое количество.\r\n" +
                        "Подтверждение расхода невозможно.");
                    return;
                }
                if (sbWished.Length > 0)
                {
                    if (RFMMessage.MessageBoxYesNo("Для следующих товаров:\r\n" + sbWished + "подтверждаемое количество не равно заказанному.\r\n" +
                        "Все-таки подтвердить расход?") == DialogResult.No)
                        return;
                }
                if (sbSelected.Length > 0)
                {
                    if (RFMMessage.MessageBoxYesNo("Для следующих товаров:\r\n" + sbSelected + "подтверждаемое количество не равно подобранному.\r\n" +
                        "Все-таки подтвердить расход?") == DialogResult.No)
                        return;
                }
                if (sbPicked.Length > 0)
                {
                    if (RFMMessage.MessageBoxYesNo("Для следующих товаров:\r\n" + sbPicked + "подтверждаемое количество не равно собранному в ячейке отгрузки для этого расхода.\r\n" +
                        "Все-таки подтвердить расход?") == DialogResult.No)
                        return;
                }

                if (RFMMessage.MessageBoxYesNo("Подтвердить расход?") != DialogResult.Yes)
                    return;
            }
            else
            {
				/*
                if (sbPicked.Length > 0)
                {
                    if (RFMMessage.MessageBoxYesNo("Для следующих товаров:\r\n" + sbPicked + "подтверждаемое количество не равно собранному в ячейке отгрузки для этого расхода.\r\n" +
                        "Все-таки подтвердить расход?") == DialogResult.No)
                        return;
                }
				*/ 

				if (RFMMessage.MessageBoxYesNo("Подтвердить расход?") != DialogResult.Yes)
                    return;

                // выполняем автоматическое исправление состояния ячейки отгрузки
                foreach (DataRow droOutGoods in oOutput.TableOutputsGoods.Rows)
                {
                    int nPackingID = (int)droOutGoods["PackingID"];
                    decimal nQntConfirmed = 0;
                    for (int j = 0; j < oOutput.TableOutputsGoods.Rows.Count; j++)
                    {
                        DataRow dr = oOutput.TableOutputsGoods.Rows[j];
                        if ((int)dr["PackingID"] == nPackingID)
                            nQntConfirmed += (decimal)dr["QntConfirmed"];
                    }
                    decimal nQntInCell = 0;
                    bool bFoundInCell = false;
                    foreach (DataRow droCellGoods in oCell.TableCellsContents.Rows)
                    {
                        if ((bool)oOutput.MainTable.Rows[0]["SeparatePicking"])
                        {
                            if ((int)droCellGoods["PackingID"] == nPackingID &&
                                (int)droCellGoods["GoodStateID"] == nGoodStateID &&
                                (int)droCellGoods["OwnerID"] == nOwnerID)
                            {
                                bFoundInCell = true;
                                nQntInCell = (decimal)droCellGoods["Qnt"];
                                if (nQntInCell < nQntConfirmed)
                                {
                                    oCell.MedicationDirect((int)oCell.ID, nGoodStateID, nOwnerID, nPackingID, nQntConfirmed - nQntInCell, 
                                        ((RFMFormMain)Application.OpenForms[0]).UserID, "Исправление состояния ячейки для подтверждения расхода с кодом " + oOutput.ID.ToString());
                                }
								break; //
                            }
                        }
                        else
                        {
                            if ((int)droCellGoods["PackingID"] == (int)droOutGoods["PackingID"] &&
                                (int)droCellGoods["GoodStateID"] == nGoodStateID &&
                                Convert.IsDBNull(droCellGoods["OwnerID"]))
                            {
                                bFoundInCell = true;
                                nQntInCell = (decimal)droCellGoods["Qnt"];
                                if (nQntInCell < nQntConfirmed)
                                {
                                    oCell.MedicationDirect((int)oCell.ID, nGoodStateID, null, nPackingID, nQntConfirmed - nQntInCell,
                                        ((RFMFormMain)Application.OpenForms[0]).UserID, "Исправление состояния ячейки для подтверждения расхода с кодом " + oOutput.ID.ToString());
                                }
								break; //
							}
                        }
                    }
                    if (!bFoundInCell)
                    {
                        // вообще нет товара в ячейке отгрузки
                        if ((bool)oOutput.MainTable.Rows[0]["SeparatePicking"])
                        {
                            oCell.MedicationDirect((int)oCell.ID, nGoodStateID, nOwnerID, nPackingID, nQntConfirmed,
                                ((RFMFormMain)Application.OpenForms[0]).UserID, "Исправление состояния ячейки для подтверждения расхода с кодом " + oOutput.ID.ToString());
                        }
                        else
                        {
                            oCell.MedicationDirect((int)oCell.ID, nGoodStateID, null, nPackingID, nQntConfirmed,
                                ((RFMFormMain)Application.OpenForms[0]).UserID, "Исправление состояния ячейки для подтверждения расхода с кодом " + oOutput.ID.ToString());
                        }
                    }
                }
            }

			Refresh();
			WaitOn(this);
			oOutput.ClearError();
			bool bResult = oOutput.ConfirmData(ID,
					((RFMFormBase)Application.OpenForms[0]).UserInfo.UserID,
					oOutput.TableOutputsGoods);
			WaitOff(this);
			if (bResult && oOutput.ErrorNumber == 0)
			{
				RFMMessage.MessageBoxInfo("Расход подтвержден.");
				DialogResult = DialogResult.Yes;
				Dispose();
			}
			else
			{
				RFMMessage.MessageBoxError("Ошибка подтверждения расхода...");
				// не выходить из формы
			}
		}

		#endregion

		private void tcGoods_Selected(object sender, TabControlEventArgs e)
		{
			if (tcGoods.SelectedTab == tabPiece)
			{
				dgvPieceGoods.Select();
				btnCalc.Enabled = false;
			}
			else
				dgvWeightGoods.Select();
		}

		private void tabWeight_Enter(object sender, EventArgs e)
		{
			if (!bWeightingTry)
				bWeightingTry = true;
		}

		private void btnCalc_Click(object sender, EventArgs e)
		{
			RFMDataGridView dgv = dgvWeightGoods;
			if (dgv.Rows.Count == 0 || dgv.CurrentRow == null)
				return;

			DataGridViewRow dgrv = dgv.CurrentRow;

			if (StartProgram.ParamStore != null)
            {
                for (int i = 0; i < StartProgram.ParamStore.GetLength(0); i++)
                {
                    StartProgram.ParamStore.SetValue(null, i);
                }
            }
            
            if (new frmCounter(false, 3, dgrv.Cells["dgvcGoodAlias2"].Value.ToString(), "").ShowDialog() == DialogResult.Yes)
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
					decimal nInBox = (decimal)dgrv.Cells["dgvcInBox2"].Value;
					dgrv.Cells["dgvcQntConfirmed2"].Value = nQnt;
					dgrv.Cells["dgvcBoxConfirmed2"].Value = nQnt / nInBox;
					DataRow dr = oOutput.TableOutputsGoods.Rows.Find(dgrv.Cells["dgvcID2"].Value);
					if (dr != null)
					{
						dr["BoxConfirmed"] = dgrv.Cells["dgvcBoxConfirmed2"].Value;
						dr["QntConfirmed"] = dgrv.Cells["dgvcQntConfirmed2"].Value;
					}
					ShowHumanStrikes();
			    }

                if (StartProgram.ParamStore.GetValue(0) == null)
                {
                    StartProgram.ParamStore.SetValue("", 0);
                }
				
				dgvWeightGoods.Select();
            }

			if (StartProgram.ParamStore != null)
            {
                for (int i = 0; i < StartProgram.ParamStore.GetLength(0); i++)
                {
                    StartProgram.ParamStore.SetValue(null, i);
                }
            }
		}

		private void dgvWeightGoods_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			RFMDataGridView dgv = dgvWeightGoods;
			if (dgv.DataSource == null || e.RowIndex == -1 || e.ColumnIndex == -1)
				return;
			string ColName = dgv.Columns[e.ColumnIndex].Name;
			if (ColName == "dgvcQntConfirmed2")
				btnCalc.Enabled = true;
			else
				btnCalc.Enabled = false;

		}

		private void frmOutputsConfirm_KeyDown(object sender, KeyEventArgs e)
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

		private void tcGoods_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tcGoods.SelectedTab == tabWeight)
				bWeightEnter = true;
		}

	}
}
