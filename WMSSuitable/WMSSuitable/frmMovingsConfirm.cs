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
	public partial class frmMovingsConfirm : RFMFormChild
	{
		private int nMovingID;
		private Moving oMoving;
		
		public frmMovingsConfirm(int? _nMovingID)
		{
			oMoving = new Moving();
			if (oMoving.ErrorNumber != 0)
			{
				IsValid = false;
			}

			if (IsValid)
			{
				InitializeComponent();

				nMovingID = (int)_nMovingID;
			}
		}

		private void frmMovingsConfirm_Load(object sender, EventArgs e)
		{
			oMoving.ID = nMovingID;
			oMoving.FillData();
			if (oMoving.ErrorNumber != 0 || oMoving.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о перемещении...");
				Dispose();
			}

			DataRow r = oMoving.MainTable.Rows[0];
			Text += " (" + r["ID"].ToString().Trim() + ")";

			txtDateMoving.Text = Convert.ToDateTime(r["DateMoving"]).ToString("dd.MM.yyyy");
			txtMovingTypeName.Text = r["MovingTypeName"].ToString();
			txtOwnerName.Text = r["OwnerName"].ToString();
			txtGoodStateName.Text = r["GoodStateName"].ToString();
            txtGoodStateNewName.Text = r["GoodStateNewName"].ToString();
            txtCellSourceAdress.Text = r["CellSourceAddress"].ToString();

			bool blResult = dgvOuputsGoods_Restore();
			if (!blResult)
			{
				RFMMessage.MessageBoxError("Ошибка получения данных о товарах в перемещении...");
				Dispose();
			}

			dgvMovingGoods.ReadOnly = false;
			foreach (DataGridViewColumn c in dgvMovingGoods.Columns)
			{
				c.ReadOnly = !(c.Name.Contains("Check") || c.Name.Contains("Confirmed"));
			}
			
			if (dgvMovingGoods.Rows.Count > 0)
			{
				// встать на первую строку, в ячейку "Коробок Факт"
				dgvMovingGoods.CurrentCell = dgvMovingGoods.Rows[0].Cells["dgrcBoxConfirmed"];
			}

		}

		#region Restore

		private bool dgvOuputsGoods_Restore()
		{
			oMoving.ID = this.nMovingID;
			oMoving.ClearError();
			oMoving.FillTableMovingsGoods(oMoving.ID);
			oMoving.TableMovingsGoods.PrimaryKey = new DataColumn[] { oMoving.TableMovingsGoods.Columns["MovingGoodID"] };
			foreach (DataRow droRow in oMoving.TableMovingsGoods.Rows)
			{
				droRow["BoxConfirmed"] = droRow["BoxWished"];
				droRow["QntConfirmed"] = droRow["QntWished"];
			}
			dgvMovingGoods.Restore(oMoving.TableMovingsGoods);
			return (oMoving.ErrorNumber == 0);
		}

		#endregion

		#region Cell...

		private void dgvMovingGoods_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (dgvMovingGoods.DataSource == null || dgvMovingGoods.CurrentRow == null)
				return;
			DataRow droRow = oMoving.TableMovingsGoods.Rows.Find((int)dgvMovingGoods.Rows[e.RowIndex].Cells["dgrcID"].Value);

			if (droRow == null)
				return;
			if (droRow["QntConfirmed"] == DBNull.Value)
				droRow["QntConfirmed"] = 0;

			if ((decimal)droRow["QntConfirmed"] < (decimal)droRow["QntWished"])
			{
				if (dgvMovingGoods.Columns[e.ColumnIndex].Name == "dgrcQntConfirmed" ||
					dgvMovingGoods.Columns[e.ColumnIndex].Name == "dgrcBoxConfirmed")
				{
					if ((decimal)droRow["QntConfirmed"] == 0)
						e.CellStyle.BackColor = Color.FromArgb(250, 200, 200);
					else
						e.CellStyle.BackColor = Color.FromArgb(255, 255, 128);
				}
			}

			switch (dgvMovingGoods.Columns[e.ColumnIndex].Name)
			{
				case "dgrcInBox":
				case "dgrcQntWished":
				case "dgrcQntConfirmed":
					if (!Convert.IsDBNull(droRow["Weighting"]) &&
						Convert.ToBoolean(droRow["Weighting"]) ||
						!Convert.IsDBNull(e.Value) && Convert.ToDecimal(e.Value) != Convert.ToInt32(e.Value))
						e.CellStyle.Format = "### ### ### ###.000";
					else
						e.CellStyle.Format = "### ### ### ###";
					break;
			}
		}

		private void dgvMovingGoods_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
			if (dgvMovingGoods.Columns[e.ColumnIndex].Name.Contains("Qnt"))
			{
				DataRow dr = ((DataRowView)((DataGridViewRow)dgvMovingGoods.CurrentRow).DataBoundItem).Row;
				decimal nInBox = (decimal)dr["InBox"];
				((RFMDataGridViewTextBoxNumericColumn)dgvMovingGoods.Columns[e.ColumnIndex]).DecimalPlaces =
					(nInBox != (int)nInBox || (bool)dr["Weighting"]) ? 3 : 0;
			}
		}

		private void dgvMovingGoods_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if (oMoving.TableMovingsGoods.Rows.Count == 0)
				return;

			if (dgvMovingGoods.Columns[e.ColumnIndex].Name == "dgrcQntConfirmed" ||
				dgvMovingGoods.Columns[e.ColumnIndex].Name == "dgrcBoxConfirmed")
			{
				DataRow droRow = oMoving.TableMovingsGoods.Rows.Find((int)dgvMovingGoods.Rows[e.RowIndex].Cells["dgrcID"].Value);
				if (droRow != null)
				{
					decimal nInBox = (decimal)droRow["InBox"];
					if (dgvMovingGoods.Columns[e.ColumnIndex].Name == "dgrcQntConfirmed")
					{ 
						// меняем штуки
						droRow["BoxConfirmed"] = (decimal)dgvMovingGoods.Rows[e.RowIndex].Cells["dgrcQntConfirmed"].Value / nInBox; 
					}
					if (dgvMovingGoods.Columns[e.ColumnIndex].Name == "dgrcBoxConfirmed")
					{
						// меняем коробки
						if ((bool)dgvMovingGoods.Rows[e.RowIndex].Cells["dgrcWeighting"].Value ||
							(int)nInBox != nInBox)
						{
							droRow["QntConfirmed"] = (decimal)dgvMovingGoods.Rows[e.RowIndex].Cells["dgrcBoxConfirmed"].Value * nInBox;
						}
						else
						{
							droRow["QntConfirmed"] = decimal.Ceiling(decimal.Round((decimal)dgvMovingGoods.Rows[e.RowIndex].Cells["dgrcBoxConfirmed"].Value * nInBox, 1));
						}
					}
					dgvMovingGoods.Refresh();
				}
			}
		}

		private void dgvMovingGoods_CellValidated(object sender, DataGridViewCellEventArgs e)
		{
			DataGridViewRow r = dgvMovingGoods.Rows[e.RowIndex];
			if (dgvMovingGoods.Columns[e.ColumnIndex].Name == "dgrcQntConfirmed" &&
					!(bool)r.Cells["dgrcWeighting"].Value && 
					(r.Cells["dgrcQntConfirmed"].Value == DBNull.Value ||
					((decimal)r.Cells["dgrcQntConfirmed"].Value > (decimal)r.Cells["dgrcQntWished"].Value)))
			{
				if (r.Cells["dgrcQntConfirmed"].Value == DBNull.Value)
				{
					r.Cells["dgrcQntConfirmed"].Value = 0;
				}
				else
				{
					RFMMessage.MessageBoxError("Введено число больше допустимого!");
					r.Cells["dgrcQntConfirmed"].Value = r.Cells["dgrcQntWished"].Value;
				}
			}

			if (dgvMovingGoods.Columns[e.ColumnIndex].Name == "dgrcBoxConfirmed" &&
					!(bool)r.Cells["dgrcWeighting"].Value && 
					(r.Cells["dgrcBoxConfirmed"].Value == DBNull.Value ||
					(Math.Round((decimal)r.Cells["dgrcBoxConfirmed"].Value, 1) > Math.Round((decimal)r.Cells["dgrcBoxWished"].Value, 1))))
			{
				if (r.Cells["dgrcBoxConfirmed"].Value == DBNull.Value)
				{
					r.Cells["dgrcBoxConfirmed"].Value = 0;
				}
				else
				{
					RFMMessage.MessageBoxError("Введено число больше допустимого!");
					r.Cells["dgrcBoxConfirmed"].Value = r.Cells["dgrcBoxWished"].Value;
				}
			}
			dgvMovingGoods.Refresh();
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

		private void btnSave_Click(object sender, EventArgs e)
		{
			Cell oCell = new Cell();
			oCell.ID = (int)oMoving.MainTable.Rows[0]["CellSourceID"];
			oCell.FillTableCellsContents(oCell.ID, true);
			StringBuilder sbCellLess   = new StringBuilder("");
			StringBuilder sbCellAbsent = new StringBuilder("");
			StringBuilder sbWished     = new StringBuilder("");
			StringBuilder sbZero       = new StringBuilder("");
            int nCellLess = 0, nCellAbsent = 0, nWished = 0, nZero = 0;
            const int nCount = 5;

			bool bInOut;
			int nGoodStateID = (int)oMoving.MainTable.Rows[0]["GoodStateID"];
            int nGoodStateNewID = (int)oMoving.MainTable.Rows[0]["GoodStateNewID"];
            int? nOwnerID = null;
			if (!Convert.IsDBNull(oMoving.MainTable.Rows[0]["OwnerID"]))
				nOwnerID = Convert.ToInt32(oMoving.MainTable.Rows[0]["OwnerID"]);

			foreach (DataRow droOutGoods in oMoving.TableMovingsGoods.Rows)
			{
				if ((decimal)droOutGoods["QntConfirmed"] == 0)
				{
                    if (++nZero <= nCount)
					    sbZero = sbZero.Append(droOutGoods["GoodAlias"].ToString() + "\n");
					continue;
				}

				bInOut = false;
				foreach (DataRow droCellGoods in oCell.TableCellsContents.Rows)
				{
					if ((int)droCellGoods["PackingID"] == (int)droOutGoods["PackingID"] &&
						(int)droCellGoods["GoodStateID"] == nGoodStateID &&
						(!nOwnerID.HasValue && Convert.IsDBNull(droCellGoods["OwnerID"]) || 
						nOwnerID.HasValue && !Convert.IsDBNull(droCellGoods["OwnerID"]) && Convert.ToInt32(droCellGoods["OwnerID"]) == nOwnerID) ) 
					{
						bInOut = true;
						if ((decimal)droCellGoods["Qnt"] < (decimal)droOutGoods["QntConfirmed"])
						{
                            if (++nCellLess <= nCount)
							    sbCellLess = sbCellLess.Append(droOutGoods["GoodAlias"].ToString() + "\n");
						}
					}
				}
				if (!bInOut && (decimal)droOutGoods["QntConfirmed"] > 0)
				{
                    if (++nCellAbsent <= nCount)
					    sbCellAbsent = sbCellAbsent.Append(droOutGoods["GoodAlias"].ToString() + "\n");
				}

				if (((decimal)droOutGoods["QntConfirmed"] > 0) &&
					((decimal)droOutGoods["QntConfirmed"] != (decimal)droOutGoods["QntWished"]))
				{
                    if (++nWished <= nCount)
					    sbWished = sbWished.Append(droOutGoods["GoodAlias"].ToString() + "\n");
				}
			}

			if (sbCellAbsent.Length > 0)
			{
                if (nCellAbsent > nCount) 
                    sbCellAbsent.Append("...\n");
				if (RFMMessage.MessageBoxYesNo(nCellAbsent.ToString() + " товар(ов):\n" + sbCellAbsent + 
					"отсутствуют в исходной ячейке.\n\n" + 
					"Все-таки подтвердить перемещение?") != DialogResult.Yes)
					return;
			}
			if (sbCellLess.Length > 0)
			{
                if (nCellLess > nCount)
                    sbCellLess.Append("...\n");
				if (RFMMessage.MessageBoxYesNo("Для " + nCellLess.ToString() + " товар(ов):\n" + sbCellLess + 
					"количество в исходной ячейке меньше, чем подтверждаемое количество.\n\n" +
					"Все-таки подтвердить перемещение?") != DialogResult.Yes)
					return;
			}
			if (sbWished.Length > 0)
			{
                if (nWished > nCount)
                    sbWished.Append("...\n");
				if (RFMMessage.MessageBoxYesNo("Для " + nWished.ToString() + " товар(ов):\n" + sbWished + 
					"подтверждаемое количество не равно заказанному.\n\n" +
					"Все-таки подтвердить перемещение?") != DialogResult.Yes)
					return;
			}
			if (sbZero.Length > 0)
			{
                if (nZero > nCount)
                    sbZero.Append("...\n");
				if (RFMMessage.MessageBoxYesNo(nZero.ToString() + " товар(ов):\n" + sbZero +
					"не подтверждаются и считаются недоставленными в целевую ячейку.\n\n" +
					"Все-таки подтвердить перемещение?") != DialogResult.Yes)
					return;
			}

			if (RFMMessage.MessageBoxYesNo("Подтвердить перемещение товара между ячейками?") == DialogResult.Yes)
			{
				Refresh();
				WaitOn(this);
				oMoving.ClearError();
				bool bResult = oMoving.ConfirmData(nMovingID, 
						((RFMFormBase)Application.OpenForms[0]).UserInfo.UserID);
				WaitOff(this);
				if (bResult && oMoving.ErrorNumber == 0)
				{
					RFMMessage.MessageBoxInfo("Перемещение подтверждено.");
					DialogResult = DialogResult.Yes;
					Dispose();
				}
				else
				{
					RFMMessage.MessageBoxError("Ошибка подтверждения перемещения...");
					// не выходить из формы
				}
			}
		}
	}
}
