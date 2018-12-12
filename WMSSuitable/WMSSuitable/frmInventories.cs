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
	public partial class frmInventories : RFMFormChild
	{
		private Inventory oInventoryList; //список приходов
		private Inventory oInventoryCur;  //текущий приход

		// для фильтров
		public string _SelectedIDList;
		public string _SelectedText;
		public int? _SelectedID;

		private string sSelectedUsersIDList = "";

		public string _SelectedCellsIDList;
		public string _SelectedCellAddressText;
		private string sSelectedCellsIDList = "";

		public string _SelectedPackingIDList;
		public string _SelectedPackingAliasText;
		private string sSelectedPackingsIDList = "";

		public frmInventories()
		{
			oInventoryList = new Inventory();
			oInventoryCur = new Inventory();
			if (oInventoryList.ErrorNumber != 0 ||
				oInventoryCur.ErrorNumber != 0)
			{
				IsValid = false;
			}

			if (IsValid)
			{
				InitializeComponent();
			}
		}

		private void frmInventories_Load(object sender, EventArgs e)
		{
			RFMCursorWait.Set(true);

			grcBoxWished.AgrType =
			grcBoxConfirmed.AgrType =
			grcBoxDiff.AgrType =
			grcQntWished.AgrType =
			grcQntConfirmed.AgrType =
			grcQntDiff.AgrType =  
				EnumAgregate.Sum;

			btnClearTerms_Click(null, null);

			tcList.Init();
			tcInventoriesCells.Init();

			txtBarCode.Select();

			RFMCursorWait.Set(false);
		}

		#region Tab Restore 

		private bool tabTerms_Restore()
		{
			btnAdd.Enabled =
			btnEdit.Enabled =
			btnDelete.Enabled =
			//btnMedication.Enabled =
			//btnMedicationNotFrames.Enabled =
			btnConfirm.Enabled =
			btnPrint.Enabled =
			btnService.Enabled = false;
			return true;
		}

		private bool tabData_Restore()
		{
			grdData_Restore();
			btnAdd.Enabled = true;
			if (grdData.Rows.Count > 0)
			{
				btnEdit.Enabled =
				btnDelete.Enabled =
				//btnMedication.Enabled =
				//btnMedicationNotFrames.Enabled =
				btnConfirm.Enabled =
				btnPrint.Enabled =
				btnService.Enabled = true;
			}
			else
			{
				btnEdit.Enabled =
				btnDelete.Enabled =
				//btnMedication.Enabled =
				//btnMedicationNotFrames.Enabled =
				btnConfirm.Enabled =
				btnPrint.Enabled =
				btnService.Enabled = false;
			}
			grdData.Select();
			return true;
		}

		private bool tabInventoriesCells_Restore()
		{
			return grdInventoriesCells_Restore();
		}

		private void tcList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tcList.SelectedTab.Name.ToUpper().Contains("TERMS"))
			{
				btnAdd.Enabled =
				btnEdit.Enabled =
				btnDelete.Enabled =
				//btnMedication.Enabled =
				//btnMedicationNotFrames.Enabled =
				btnConfirm.Enabled =
				btnPrint.Enabled =
				btnService.Enabled = false;
			}

			if (tcList.SelectedTab.Name.ToUpper().Contains("DATA"))
			{
				btnAdd.Enabled = true;
				grdData.Select();
			}
		}

		#endregion Tab Restore

		#region PrepareIDList

		public void InventoryPrepareIDList(Inventory oInventory, bool bMultiSelect)
		{
			oInventory.ID = null;
			oInventory.IDList = null;
			int? nInventoryID = 0;
			if (bMultiSelect && grdData.IsCheckerShow)
			{
				oInventory.IDList = "";

				DataView dMarked = new DataView(oInventoryList.MainTable);
				dMarked.RowFilter = "IsMarked = true";
				//dMarked.Sort = ((DataView)((WMSBindingSource)grdData.DataSource).DataSource).Sort; 
				dMarked.Sort = grdData.GridSource.Sort;
				foreach (DataRowView r in dMarked)
				{
					if (!Convert.IsDBNull(r["ID"]))
					{
						nInventoryID = (int)r["ID"];
						oInventory.IDList = oInventory.IDList + nInventoryID.ToString() + ",";
					}
				}
			}
			else
			{
				nInventoryID = (int?)grdData.CurrentRow.Cells["grcID"].Value;
				if (nInventoryID.HasValue)
				{
					oInventory.ID = nInventoryID;
				}
			}
		}
		
		#endregion PrepareIDList

		#region Buttons

		private void btnAdd_Click(object sender, EventArgs e)
		{
			if (StartForm(new frmInventoriesAdd(0)) == DialogResult.Yes)
			{
				int nInventoryID = (int)GotParam.GetValue(0);
				grdData_Restore();
				if (nInventoryID > 0)
				{
					grdData.GridSource.Position = grdData.GridSource.Find(oInventoryList.ColumnID, nInventoryID);
				}
			}
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			if (grdData.CurrentRow == null)
				return;

			if (Convert.IsDBNull(grdData.CurrentRow.Cells["grcID"].Value))
				return;

			oInventoryCur.ClearError();
			oInventoryCur.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;

			// обработка начата? 
			oInventoryCur.FillData();
			if (oInventoryCur.ErrorNumber != 0 || oInventoryCur.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о текущей ревизии...");
				return;
			}
			DataRow ri = oInventoryCur.MainTable.Rows[0];
			if (!Convert.IsDBNull(ri["DateConfirm"]))
			{
				RFMMessage.MessageBoxError("Ревизия уже подтверждена...");
				return;
			}
			Refresh();

			if (StartForm(new frmInventoriesAdd((int)oInventoryCur.ID)) == DialogResult.Yes)
			{
				grdData_Restore();
			}
		}

		private void btnConfirm_Click(object sender, EventArgs e)
		{
			if (grdData.CurrentRow == null)
				return;

			if (Convert.IsDBNull(grdData.CurrentRow.Cells["grcID"].Value))
				return;

			int nInventoryConfirmID = (int)grdData.CurrentRow.Cells["grcID"].Value;

			Inventory oInventoryConfirm = new Inventory();
			oInventoryConfirm.ID = nInventoryConfirmID;
			oInventoryConfirm.FillData();
			if (oInventoryConfirm.ErrorNumber != 0 || oInventoryConfirm.MainTable == null || oInventoryConfirm.MainTable.Rows.Count != 1)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о ревизии с кодом " + nInventoryConfirmID.ToString() + "...");
				return;
			}

			oInventoryConfirm.FillTableInventoriesCells(nInventoryConfirmID);
			if (oInventoryConfirm.ErrorNumber != 0 || oInventoryConfirm.TableInventoriesCells == null)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о ячейках в ревизии с кодом " + nInventoryConfirmID.ToString() + "...");
				return;
			}

			DataRow ri = oInventoryConfirm.MainTable.Rows[0];

			// уже подтверждена? 
			if (!Convert.IsDBNull(ri["DateConfirm"]))
			{
				RFMMessage.MessageBoxError("Ревизия уже подтверждена...");
				return;
			}
			if (Convert.IsDBNull(ri["DateStart"]))
			{
				RFMMessage.MessageBoxError("Обработка ревизии еще не начата...");
				return;
			}

			// по ячейкам - все ли обработано?
			// по ошибочно обработанным ячейкам - все ли фактические состояния указаны?
			foreach (DataRow ric in oInventoryConfirm.TableInventoriesCells.Rows)
			{
				if (Convert.IsDBNull(ric["Success"]))
				{
					RFMMessage.MessageBoxError("Некоторые ячейки еще не обработаны...");
					return;
				}
			}

			if (RFMMessage.MessageBoxYesNo("Подтвердить выполнение ревизии?") == DialogResult.Yes)
			{
				if (oInventoryConfirm.ConfirmEasy(nInventoryConfirmID, ((RFMFormMain)Application.OpenForms[0]).UserID))
				{
					grdData_Restore();
				}
			}
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (grdData.CurrentRow == null)
				return;
			if (Convert.IsDBNull(grdData.CurrentRow.Cells["grcID"].Value))
				return;

			int nInventoryDeleteID = (int)grdData.CurrentRow.Cells["grcID"].Value;

			Inventory oInventoryDelete = new Inventory();
			oInventoryDelete.ID = nInventoryDeleteID;
			oInventoryDelete.FillData();
			if (oInventoryDelete.ErrorNumber != 0 || oInventoryDelete.MainTable == null || oInventoryDelete.MainTable.Rows.Count != 1)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о ревизии с кодом " + nInventoryDeleteID.ToString() + "...");
				return;
			}

			oInventoryDelete.FillTableInventoriesCells(nInventoryDeleteID);
			if (oInventoryDelete.ErrorNumber != 0 || oInventoryDelete.TableInventoriesCells == null)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о ячейках в ревизии с кодом " + nInventoryDeleteID.ToString() + "...");
				return;
			}

			DataRow ri = oInventoryDelete.MainTable.Rows[0];
			switch (LastGrid.Name)
			{
				case "grdData":
					// верхний 
					if (!Convert.IsDBNull(ri["DateConfirm"]))
					{
						RFMMessage.MessageBoxError("Ревизия уже подтверждена...");
						return;
					}
					if (!Convert.IsDBNull(ri["DateStart"]))
					{
						RFMMessage.MessageBoxError("Обработка ревизии уже начата...");
						return;
					}

					// по ячейкам - не обрабатывается ли уже что?
					foreach (DataRow ric in oInventoryDelete.TableInventoriesCells.Rows)
					{
						if (!Convert.IsDBNull(ric["Success"]))
						{
							RFMMessage.MessageBoxError("Некоторые ячейки уже обработаны...");
							return;
						}
					}

					if (RFMMessage.MessageBoxYesNo("Удалить ревизию с кодом " + nInventoryDeleteID.ToString() + " ?") != DialogResult.Yes)
						return;

					// все проверено. можно удалять всю ревизию целиком 
					oInventoryDelete.DeleteData(nInventoryDeleteID);
					if (oInventoryDelete.ErrorNumber == 0)
					{
						grdData_Restore();
					}
					break;

				case "grdInventoriesCells":
					// нижний, ячейки
					if (grdInventoriesCells.CurrentRow == null)
						return;
					if (Convert.IsDBNull(grdInventoriesCells.CurrentRow.Cells["grcCellID"].Value))
						return;

					int nCellID = (int)grdInventoriesCells.CurrentRow.Cells["grcCellID"].Value;
					string sCellAddress = "";
					bool bFoundCell = false;
					foreach (DataRow ric in oInventoryDelete.TableInventoriesCells.Rows)
					{
						if (!Convert.IsDBNull(ric["CellID"]) && Convert.ToInt32(ric["CellID"]) == nCellID)
						{
							bFoundCell = true;
							sCellAddress = ric["Address"].ToString();
							if (!Convert.IsDBNull(ric["Success"]))
							{
								RFMMessage.MessageBoxError("Ячейка " + sCellAddress + " уже обработана...");
								return;
							}
						}
					}
					if (!bFoundCell)
					{
						RFMMessage.MessageBoxError("Ячейка " + sCellAddress + " не найдена в списке ревизии...");
						return;
					}

					if (RFMMessage.MessageBoxYesNo("Удалить ячейку " + sCellAddress + " из списка ревизии с кодом " + nInventoryDeleteID.ToString() + " ?") != DialogResult.Yes)
						return;

					// все проверено. можно удалять эту ячейку в ревизии
					oInventoryDelete.DeleteData(nInventoryDeleteID, nCellID);
					if (oInventoryDelete.ErrorNumber == 0)
					{
						grdInventoriesCells_Restore();
					}
					break;
			}
		}

		private void btnHelp_Click(object sender, EventArgs e)
		{
			RFMHelpUtilities.HelpShow(this, hpHelp);
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

		#endregion

		#region TimerTick, CellFormatting

		private void grdData_CurrentRowChanged(object sender)
		{
			if (grdData.IsRestoring)
				return;

			tmrRestore.Enabled = true;
		}

		private void tmrRestore_Tick(object sender, EventArgs e)
		{
			tmrRestore.Enabled = false;

			if (grdData.CurrentRow == null)
				return;

			int rowIndex = grdData.CurrentRow.Index;

			btnPrint.Enabled =
			btnService.Enabled = 
				true;
			//btnMedication.Enabled = false;

			bool bDeleteEnabled = true;

			if (grdData.IsStatusRow(rowIndex))
			{
				oInventoryCur.ID = 0;
				btnEdit.Enabled =
				btnDelete.Enabled =
				//btnMedication.Enabled =
				//btnMedicationNotFrames.Enabled =
				btnConfirm.Enabled =
					false;
				bDeleteEnabled = false;
			}
			else
			{
				DataGridViewRow r = grdData.Rows[rowIndex];
				oInventoryCur.ID = (int)r.Cells["grcID"].Value;
				DataRow dr = ((DataRowView)r.DataBoundItem).Row;
				bool bIsConfirmed = Convert.ToBoolean(dr["IsConfirmed"]);
				bool bIsStarted = Convert.ToBoolean(dr["IsStarted"]);
				btnEdit.Enabled = 
				//btnMedicationNotFrames.Enabled =
					!bIsConfirmed;
				btnConfirm.Enabled = !bIsConfirmed && bIsStarted;
				btnDelete.Enabled = bDeleteEnabled = !bIsConfirmed && !bIsStarted;
			}
			btnDelete.Enabled = bDeleteEnabled;

			tcInventoriesCells.SetAllNeedRestore(true);
		}

		private void grdInventoriesCells_RowEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (e == null || e.RowIndex < 0 || grdData.CurrentRow == null || LastGrid.Name.ToUpper().Contains("DATA"))
				return;

			bool bDeleteEnabled = true;
			if (grdInventoriesCells.IsStatusRow(e.RowIndex))
			{
				bDeleteEnabled = false;
			}
			else
			{
				DataGridViewRow r = grdData.Rows[grdData.CurrentRow.Index];
				DataRow dr = ((DataRowView)r.DataBoundItem).Row;
				DataGridViewRow cr = grdInventoriesCells.Rows[e.RowIndex];
				DataRow cdr = ((DataRowView)cr.DataBoundItem).Row;

				if (Convert.ToBoolean(dr["IsConfirmed"]) || !Convert.IsDBNull(cdr["Success"]))
				{
					bDeleteEnabled = false;
				}
			}
			btnDelete.Enabled = bDeleteEnabled;
		}

		private void grdData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (grdData.DataSource == null)
				return;

			if (grdData.IsStatusRow(e.RowIndex))
			{
				switch (grdData.Columns[e.ColumnIndex].Name)
				{
					case "grcIsConfirmedImage":
						e.Value = Properties.Resources.Empty;
						break;
				}
				return;
			}

			DataRow dr = ((DataRowView)grdData.Rows[e.RowIndex].DataBoundItem).Row;
			switch (grdData.Columns[e.ColumnIndex].Name)
			{
				case "grcIsConfirmedImage":
					if (Convert.ToBoolean(dr["IsConfirmed"]))
						e.Value = Properties.Resources.Check;
					else
						e.Value = Properties.Resources.Empty;
					break;
			}
		}

		private void grdInventoriesCells_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			RFMDataGridView grd = grdInventoriesCells;

			if (grd.DataSource == null)
				return;

			if (grd.IsStatusRow(e.RowIndex))
			{
				switch (grd.Columns[e.ColumnIndex].Name)
				{
					case "grcIsCellConfirmedImage":
					case "grcIsCellSuccessImage":
						e.Value = Properties.Resources.Empty;
						break;
				}
				return;
			}

			DataRow dr = ((DataRowView)grd.Rows[e.RowIndex].DataBoundItem).Row;
			switch (grd.Columns[e.ColumnIndex].Name)
			{
				case "grcIsCellSuccessImage":
					if (Convert.IsDBNull(dr["Success"]))
					{
						e.Value = Properties.Resources.Empty;
					}
					else
					{
						if (Convert.ToBoolean(dr["Success"]))
						{
							e.Value = Properties.Resources.Check;
						}
						else
						{
							e.Value = Properties.Resources.CheckRed;
						}
					}
					break;
				case "grcInBox":
				case "grcQntWished":
				case "grcQntConfirmed":
				case "grcQntDiff":
					if (Convert.IsDBNull(dr["GoodWeighting"]) || 
						Convert.ToBoolean(dr["GoodWeighting"]) ||
						!Convert.IsDBNull(e.Value) && Convert.ToDecimal(e.Value) != Convert.ToInt32(e.Value))
					{
						e.CellStyle.Format = "### ### ### ##0.000";
					}
					else
					{
						e.CellStyle.Format = "### ### ### ###";
					}
					break;
				case "grcBoxWished":
				case "grcBoxConfirmed":
				case "grcBoxDiff":
					if (!Convert.IsDBNull(e.Value) && Convert.ToDecimal(e.Value) == 0)
					{
						e.Value = "";
					}
					break;
			}
		}

		#endregion

		#region Restore

		private bool grdData_Restore()
		{
			RFMCursorWait.Set(true);
			RFMCursorWait.LockWindowUpdate(FindForm().Handle);

			oInventoryCur.ClearError();
			oInventoryCur.ID = null;

			oInventoryList.ClearError();
			oInventoryList.ClearFilters();
			oInventoryList.ID = null;
			oInventoryList.IDList = null;

			// собираем условия

			// штрих-код
			if (txtBarCode.Text.Trim().Length > 0)
			{
				oInventoryList.BarCode = txtBarCode.Text.Trim();
			}
			// даты
			if (!dtrDates.dtpBegDate.IsEmpty)
			{
				oInventoryList.FilterDateBeg = dtrDates.dtpBegDate.Value.Date;
			}
			if (!dtrDates.dtpEndDate.IsEmpty)
			{
				oInventoryList.FilterDateEnd = dtrDates.dtpEndDate.Value.Date;
			}

			// выбранные ячейки
			if (sSelectedCellsIDList.Length > 0)
			{
				oInventoryList.FilterCellsList = sSelectedCellsIDList;
			}

			// выбранные товары 
			if (sSelectedPackingsIDList.Length > 0)
			{
				oInventoryList.FilterPackingsList = sSelectedPackingsIDList;
			}

			// пользователи
			if (sSelectedUsersIDList.Length > 0)
			{
				oInventoryList.FilterUsersList = sSelectedUsersIDList;
			}

			// состояние прихода: начало обработки, подтверждение 
			if (optIsNotConfirmed.Checked)
			{
				oInventoryList.FilterConfirmed = false;
				// начало обработки
				if (optNotStarted.Checked)
				{
					oInventoryList.FilterStarted = false;
				}
				if (optStartedNotConfirmed.Checked)
				{
					oInventoryList.FilterStarted = true;
				}
			}
			if (optIsConfirmed.Checked)
			{
				oInventoryList.FilterConfirmed = true;
				// даты
				if (!dtrDatesConfirm.dtpBegDate.IsEmpty)
				{
					oInventoryList.FilterDateConfirmBeg = dtrDatesConfirm.dtpBegDate.Value.Date;
				}
				if (!dtrDatesConfirm.dtpEndDate.IsEmpty)
				{
					oInventoryList.FilterDateConfirmEnd = dtrDatesConfirm.dtpEndDate.Value.Date;
				}
			}
			//
			grdInventoriesCells.DataSource = null;
			grdData.GetGridState();

			oInventoryList.FillData();

			grdData.IsLockRowChanged = true;
			grdData.Restore(oInventoryList.MainTable);
			tmrRestore.Enabled = true;

			RFMCursorWait.LockWindowUpdate(IntPtr.Zero);
			RFMCursorWait.Set(false);

			return (oInventoryList.ErrorNumber == 0);
		}

		private bool grdInventoriesCells_Restore()
		{
			grdInventoriesCells.GetGridState();
			grdInventoriesCells.DataSource = null;
			if (grdData.Rows.Count == 0 ||
				oInventoryCur.ID == null ||
				(grdData.CurrentRow != null && grdData.IsStatusRow(grdData.CurrentRow.Index)))
				return (true);

			oInventoryList.FillTableInventoriesCells((int)oInventoryCur.ID);

			if (chkShowSelectedGoodsOnly.Enabled && chkShowSelectedGoodsOnly.Checked &&
				sSelectedPackingsIDList != null && sSelectedPackingsIDList.Length > 0)
			{
				DataTable dt = CopyTable(oInventoryList.TableInventoriesCells, "dt",
					"PackingID in (" + RFMPublic.RFMUtilities.NormalizeList(sSelectedPackingsIDList) + ")",
					"StoreZoneName, Rank, Address, ID");
				oInventoryList.TableInventoriesCells.Clear();
				oInventoryList.TableInventoriesCells.Merge(dt);
			}

			grdInventoriesCells.Restore(oInventoryList.TableInventoriesCells);
			return (oInventoryList.ErrorNumber == 0);
		}

		#endregion

		#region Menu Print

		private void btnPrint_Click(object sender, EventArgs e)
		{
			mnuPrint.Show(btnPrint, new Point());
		}

		private void btnPrint_MouseClick(object sender, MouseEventArgs e)
		{
			mnuPrint.Show(btnPrint, new Point(e.X, e.Y));
		}

		private void mniPrintInventoryEmpty_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.CurrentRow == null)
				return;

			RFMCursorWait.Set(true);

			int nPages = 1;
			if (StartForm(new frmInputBoxNumeric("Страниц:", nPages)) == DialogResult.Yes)
			{
				Refresh();
				nPages = Convert.ToInt32(GotParam[0]);
			}

			Inventory oInventoryPrint = new Inventory();

			// получение данных 
			oInventoryPrint.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			oInventoryPrint.FillData();
			if (oInventoryPrint.ErrorNumber != 0 || oInventoryPrint.MainTable == null || oInventoryPrint.MainTable.Rows.Count != 1)
			{
				RFMCursorWait.Set(false);
				RFMMessage.MessageBoxError("Нет данных о ревизии...");
				return;
			}

			if (nPages > 1)
			{
				oInventoryPrint.MainTable.PrimaryKey = null;
				oInventoryPrint.MainTable.Columns["ID"].Unique = false;
				DataRow r = oInventoryPrint.MainTable.Rows[0];
				for (int i = 1; i < nPages; i++)
				{
					oInventoryPrint.MainTable.ImportRow(r);
				}
			}

			RFMCursorWait.Set(false);

			// отчет
			repInventoryEmpty rep = new repInventoryEmpty();
			StartForm(new frmActiveReport(oInventoryPrint.MainTable, rep));
		}

		private void mniPrintInventoryBillContents_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.CurrentRow == null)
				return;

			RFMCursorWait.Set(true);

			Inventory oInventoryPrint = new Inventory();

			// получение данных 
			oInventoryPrint.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			oInventoryPrint.FillData();
			if (oInventoryPrint.ErrorNumber != 0)
			{
				RFMCursorWait.Set(false);
				return;
			}
			if (oInventoryPrint.MainTable.Rows.Count == 0)
			{
				RFMCursorWait.Set(false);
				RFMMessage.MessageBoxError("Нет данных о ревизии...");
				return;
			}

			oInventoryPrint.FillTableInventoriesCells(oInventoryCur.ID);
			if (oInventoryPrint.ErrorNumber != 0)
			{
				RFMCursorWait.Set(false);
				return;
			}
			if (oInventoryPrint.TableInventoriesCells.Rows.Count == 0)
			{
				RFMCursorWait.Set(false);
				RFMMessage.MessageBoxError("Нет данных о ячейках ревизии...");
				return;
			}

			// заполняем текущим состоянием ячеек
			Cell oCellTemp = new Cell();
			foreach (DataRow dr in oInventoryPrint.TableInventoriesCells.Rows)
			{
				oCellTemp.ClearError();
				if (!Convert.IsDBNull(dr["CellID"]))
				{
					oCellTemp.FillTableCellsContents(Convert.ToInt32(dr["CellID"]), true);
					if (oCellTemp.ErrorNumber == 0)
					{
						if (oCellTemp.TableCellsContents.Rows.Count > 0)
						{
							DataRow ccr = oCellTemp.TableCellsContents.Rows[0];
							/*
							decimal nQnt, nInBox; int nBoxQnt;
							nQnt = 0; nInBox = 1; nBoxQnt = 0;
							nInBox = Convert.ToDecimal(ccr["InBox"]);
							dr["InBox"] = nInBox;
							
							if (!Convert.IsDBNull(ccr["QntWished"]))
							{
								nQnt = Convert.ToDecimal(ccr["QntWished"]);
								nBoxQnt = Convert.ToInt32(ccr["BoxWished"]);
								nQnt = nQnt - nBoxQnt * nInBox;
							}
							dr["QntWished"] = nQnt;
							dr["BoxWished"] = nBoxQnt;

							nQnt = 0; nInBox = 1; nBoxQnt = 0;
							if (!Convert.IsDBNull(ccr["QntConfirmed"]))
							{
								nQnt = Convert.ToDecimal(ccr["QntConfirmed"]);
								nBoxQnt = Convert.ToInt32(ccr["BoxConfirmed"]);
								nQnt = nQnt - nBoxQnt * nInBox;
							}
							dr["QntConfirmed"] = nQnt;
							dr["BoxConfirmed"] = nBoxQnt;
							*/ 

							dr["PackingID"] = ccr["PackingID"];
							dr["GoodID"] = ccr["GoodID"];
	
							dr["FrameID"] = ccr["FrameID"];
							dr["GoodStateID"] = ccr["GoodStateID"];
							dr["GoodStateName"] = ccr["GoodStateName"];
							dr["OwnerID"] = ccr["OwnerID"];
							dr["OwnerName"] = ccr["OwnerName"];

							dr["PackingAlias"] = ccr["PackingAlias"];
							dr["PackingName"] = ccr["PackingAlias"];
							dr["GoodAlias"] = ccr["GoodAlias"];
							dr["GoodName"] = ccr["GoodName"];
							dr["GoodBarCode"] = ccr["GoodBarCode"];
							dr["GoodArticul"] = ccr["Articul"];
							dr["GoodWeighting"] = ccr["Weighting"];
							dr["GoodGroupName"] = ccr["GoodGroupName"];
							dr["GoodBrandName"] = ccr["GoodBrandName"];
						}
					}
				}
			}

			// все нужные поля - в одну таблицу
			oInventoryPrint.DS.Relations.Add("r1", oInventoryPrint.MainTable.Columns["InventoryID"],
				oInventoryPrint.TableInventoriesCells.Columns["InventoryID"]);
			// добавляем нужные поля в таблицу-источник
			RepTableColumnAdd(oInventoryPrint.TableInventoriesCells);
			DataTable dt = CopyTable(oInventoryPrint.TableInventoriesCells, "dt", "", "StoreZoneName, Rank, Address");

			RFMCursorWait.Set(false);

			DataDynamics.ActiveReports.ActiveReport3 rep = new repInventoryBillContents();
			StartForm(new frmActiveReport(dt, rep));
		}

		private void mniPrintInventoryBillBlank_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.CurrentRow == null)
				return;

			RFMCursorWait.Set(true);

			Inventory oInventoryPrint = new Inventory();

			// получение данных 
			oInventoryPrint.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			oInventoryPrint.FillData();
			if (oInventoryPrint.ErrorNumber != 0)
			{
				RFMCursorWait.Set(false);
				return;
			}
			if (oInventoryPrint.MainTable.Rows.Count == 0)
			{
				RFMCursorWait.Set(false);
				RFMMessage.MessageBoxError("Нет данных о ревизии...");
				return;
			}

			oInventoryPrint.FillTableInventoriesCells(oInventoryCur.ID);
			if (oInventoryPrint.ErrorNumber != 0)
			{
				RFMCursorWait.Set(false);
				return;
			}
			if (oInventoryPrint.TableInventoriesCells.Rows.Count == 0)
			{
				RFMCursorWait.Set(false);
				RFMMessage.MessageBoxError("Нет данных о ячейках ревизии...");
				return;
			}

			// есть подтвержденные с проблемами?
			foreach (DataRow r in oInventoryPrint.TableInventoriesCells.Rows)
			{
				if (!Convert.IsDBNull(r["Success"]) && !Convert.ToBoolean(r["Success"]))
				{
					if (RFMMessage.MessageBoxYesNo("Печатать только ячейки с несоответствиями?") == DialogResult.Yes)
					{
						Refresh();
						oInventoryPrint.FilterCellsStarted = true;
						oInventoryPrint.FilterSuccess = false;
						oInventoryPrint.FillTableInventoriesCells(oInventoryCur.ID);
					}
					break;
				}
			}

			// все нужные поля - в одну таблицу
			oInventoryPrint.DS.Relations.Add("r1", oInventoryPrint.MainTable.Columns["InventoryID"],
				oInventoryPrint.TableInventoriesCells.Columns["InventoryID"]);
			// добавляем нужные поля в таблицу-источник
			RepTableColumnAdd(oInventoryPrint.TableInventoriesCells);
			DataTable dt = CopyTable(oInventoryPrint.TableInventoriesCells, "dt", "", "StoreZoneName,Address");

			RFMCursorWait.Set(false);

			// отчет
			DataDynamics.ActiveReports.ActiveReport3 rep;
			if (((ToolStripMenuItem)sender).Name.ToUpper().Contains("FULL"))
			{
				foreach (DataRow dr in dt.Rows)
				{
					decimal nInBox, nQnt, nQntWished, nQntConfirmed; int nBoxQnt; bool bWeighting, bIsNegative;
					nInBox = 1;
					nQnt = 0; nBoxQnt = 0;
					nQntWished = 0; nQntConfirmed = 0;
					if (!Convert.IsDBNull(dr["InBox"]))
					{
						nInBox = Convert.ToDecimal(dr["InBox"]);
						bWeighting = Convert.ToBoolean(dr["GoodWeighting"]);

						if (!bWeighting)
						{
							if (!Convert.IsDBNull(dr["QntWished"]))
							{
								nQntWished = nQnt = Convert.ToDecimal(dr["QntWished"]);
								nBoxQnt = Convert.ToInt32(Math.Floor(Convert.ToDecimal(dr["BoxWished"])));
								nQnt = nQnt - nBoxQnt * nInBox;
							}
							dr["QntWished"] = nQnt;
							dr["BoxWished"] = nBoxQnt;

							nQnt = 0; nBoxQnt = 0;
							if (!Convert.IsDBNull(dr["QntConfirmed"]))
							{
								nQntConfirmed = nQnt = Convert.ToDecimal(dr["QntConfirmed"]);
								nBoxQnt = Convert.ToInt32(Math.Floor(Convert.ToDecimal(dr["BoxConfirmed"])));
								nQnt = nQnt - nBoxQnt * nInBox;
							}
							dr["QntConfirmed"] = nQnt;
							dr["BoxConfirmed"] = nBoxQnt;

							nQnt = 0; nBoxQnt = 0; bIsNegative = false;
							nQnt = nQntConfirmed - nQntWished;
							if (nQnt < 0)
							{
								bIsNegative = true;
								nQnt = -nQnt;
							}
							nBoxQnt = Convert.ToInt32(Math.Floor(nQnt / nInBox));
							nQnt = nQnt - nBoxQnt * nInBox;
							dr["QntDiff"] = nQnt * ((bIsNegative) ? -1 : 1);
							dr["BoxDiff"] = nBoxQnt * ((bIsNegative) ? -1 : 1);
						}
						else
						{
							dr["BoxWished"] = 0;
							dr["BoxConfirmed"] = 0;
							dr["QntDiff"] = Convert.ToDecimal(dr["QntConfirmed"]) - Convert.ToDecimal(dr["QntWished"]); 
							dr["BoxDiff"] = 0;
						}
					}
				}

				rep = new repInventoryBillFull();
			}
			else
			{
				rep = new repInventoryBillBlank();
			}
			StartForm(new frmActiveReport(dt, rep));
		}

		private void RepTableColumnAdd(DataTable tTable)
		{
			tTable.Columns.Add("DateInventory");
			tTable.Columns["DateInventory"].Expression = "Parent([r1]).DateInventory";
			tTable.Columns.Add("DateConfirm");
			tTable.Columns["DateConfirm"].Expression = "Parent([r1]).DateConfirm";
			tTable.Columns.Add("DateStart");
			tTable.Columns["DateStart"].Expression = "Parent([r1]).DateStart";
			tTable.Columns.Add("Note");
			tTable.Columns["Note"].Expression = "Parent([r1]).Note";
			tTable.Columns.Add("BarCode");
			tTable.Columns["BarCode"].Expression = "Parent([r1]).BarCode";
			tTable.Columns.Add("ErpCode");
			tTable.Columns["ErpCode"].Expression = "Parent([r1]).ErpCode";
		}

		private void mniPrintInventoryTotalReport_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.CurrentRow == null)
				return;

			RFMCursorWait.Set(true);

			Inventory oInventoryPrint = new Inventory();
			InventoryPrepareIDList(oInventoryPrint, true);
			if (oInventoryPrint.IDList == null || oInventoryPrint.IDList.Length == 0)
			{
				RFMMessage.MessageBoxError("Не отмечены записи для отчета...");
				return; 
			}
			oInventoryPrint.FillData();
			if (oInventoryPrint.MainTable == null || oInventoryPrint.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных по отмеченным записям...");
				return; 
			}

			RFMCursorWait.Set(false);

			StartForm(new frmInventoriesTotalReport(oInventoryPrint));
		}

		#endregion

		#region Menu Service

		private void btnService_Click(object sender, EventArgs e)
		{

		}

		#endregion

		#region Filters Choose

		#region Cells

		private void btnCellsChoose_Click(object sender, EventArgs e)
		{
			_SelectedCellsIDList = null;
			_SelectedCellAddressText = "";

			if (StartForm(new frmSelectOneCell(this, true)) == DialogResult.Yes)
			{
				if (_SelectedCellsIDList == null || !_SelectedCellsIDList.Contains(","))
				{
					btnCellsClear_Click(null, null);
					return;
				}

				sSelectedCellsIDList = "," + _SelectedCellsIDList;

				txtCellsChoosen.Text = _SelectedCellAddressText;
				ttToolTip.SetToolTip(txtCellsChoosen, txtCellsChoosen.Text);

				tabData.IsNeedRestore = true;
			}

			_SelectedCellsIDList = null;
			_SelectedCellAddressText = "";
		}

		private void btnCellsClear_Click(object sender, EventArgs e)
		{
			tabData.IsNeedRestore = true;

			ttToolTip.SetToolTip(txtCellsChoosen, "не выбраны");
			sSelectedCellsIDList = "";
			txtCellsChoosen.Text = "";
		}

		#endregion Cells

		#region Packings

		private void btnPackingsChoose_Click(object sender, EventArgs e)
		{
			_SelectedPackingIDList = null;
			_SelectedPackingAliasText = "";

			if (StartForm(new frmSelectOnePacking(this, true)) == DialogResult.Yes)
			{
				if (_SelectedPackingIDList == null || !_SelectedPackingIDList.Contains(","))
				{
					btnPackingsClear_Click(null, null);
					return;
				}

				sSelectedPackingsIDList = "," + _SelectedPackingIDList;
				txtPackingsChoosen.Text = _SelectedPackingAliasText;
				ttToolTip.SetToolTip(txtPackingsChoosen, txtPackingsChoosen.Text);

				chkShowSelectedGoodsOnly.Enabled = true;
				
				tabData.IsNeedRestore = true;
			}

			_SelectedPackingIDList = null;
			_SelectedPackingAliasText = "";
		}

		private void btnPackingsClear_Click(object sender, EventArgs e)
		{
			tabData.IsNeedRestore = true;

			chkShowSelectedGoodsOnly.Checked =
			chkShowSelectedGoodsOnly.Enabled =
				false;

			ttToolTip.SetToolTip(txtPackingsChoosen, "не выбраны");
			sSelectedPackingsIDList = "";
			txtPackingsChoosen.Text = "";
		}

		#endregion

		#region Users

		private void btnUsersChoose_Click(object sender, EventArgs e)
		{
			_SelectedIDList = null;
			//sSelectedUsersIDList = "";

			User oUser = new User();
			oUser.FillDataTree(false);
			if (oUser.ErrorNumber != 0 || oUser.DS.Tables["TableDataTree"] == null)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных...");
				return;
			}
			if (oUser.DS.Tables["TableDataTree"].Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Нет данных...");
				return;
			}

			if (StartForm(new frmSelectTreeID(this, oUser.DS.Tables["TableDataTree"], true)) == DialogResult.Yes)
			{
				if (_SelectedIDList == null || !_SelectedIDList.Contains(","))
				{
					btnUsersClear_Click(null, null);
					return;
				}

				sSelectedUsersIDList = "," + _SelectedIDList;

				oUser.ClearError();
				oUser.IDList = sSelectedUsersIDList;
				oUser.FillData();
				if (oUser.ErrorNumber != 0)
				{
					btnUsersClear_Click(null, null);
					return;
				}

				int nCntChoosen = oUser.MainTable.Rows.Count;
				if (nCntChoosen == 0)
				{
					btnUsersClear_Click(null, null);
					return;
				}

				string sSelectedDataText = "";
				int i = 0;
				foreach (DataRow r in oUser.MainTable.Rows)
				{
					i++;
					if (i > 3)
					{
						sSelectedDataText += "...";
						break;
					}
					sSelectedDataText += ", " + r["Name"].ToString().Trim();
				}
				if (sSelectedDataText.StartsWith(","))
				{
					sSelectedDataText = sSelectedDataText.Substring(1).Trim();
				}

				txtUsersChoosen.Text = "(" + nCntChoosen.ToString().Trim() + "): " + sSelectedDataText;
				ttToolTip.SetToolTip(txtUsersChoosen, txtUsersChoosen.Text);

				tabData.IsNeedRestore = true;
			}
			_SelectedIDList = null;
		}

		private void btnUsersClear_Click(object sender, EventArgs e)
		{
			tabData.IsNeedRestore = true;

			ttToolTip.SetToolTip(txtUsersChoosen, "не выбраны");
			sSelectedUsersIDList = "";
			txtUsersChoosen.Text = "";
		}

		#endregion

		private void optAll_CheckedChanged(object sender, EventArgs e)
		{
			dtrDatesConfirm.Enabled = (optIsConfirmed.Checked);
			dtrDatesConfirm.dtpBegDate.HideControl(optIsConfirmed.Checked);
			dtrDatesConfirm.dtpEndDate.HideControl(optIsConfirmed.Checked);
		}

		#endregion Filters Choose

		#region Terms clear

		private void btnClearTerms_Click(object sender, EventArgs e)
		{
			txtBarCode.Text = "";

			dtrDates.dtpBegDate.Value = DateTime.Now.AddDays(-1).Date;
			dtrDates.dtpEndDate.Value = DateTime.Now.AddDays(1).Date;

			btnUsersClear_Click(null, null);
			btnCellsClear_Click(null, null);
			btnPackingsClear_Click(null, null);

			optStartedAll.Checked = true;
			optIsNotConfirmed.Checked = true;
			optAll_CheckedChanged(null, null);

			dtrDatesConfirm.dtpBegDate.Value = DateTime.Now.AddDays(-1).Date;
			dtrDatesConfirm.dtpEndDate.Value = DateTime.Now.Date;
			dtrDatesConfirm.dtpBegDate.HideControl(false);
			dtrDatesConfirm.dtpEndDate.HideControl(false);

			if (Control.ModifierKeys == Keys.Shift)
			{
				optAll.Checked = true;
				dtrDates.dtpBegDate.HideControl(false);
				dtrDates.dtpEndDate.HideControl(false);
			}

			tabData.IsNeedRestore = true;
		}

		#endregion

	}
}