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
	public partial class frmCellsContentsSnapshots : RFMFormChild
	{
		private CellContentSnapshot oCellContentSnapshotList; //список внутр.перемещений
		private CellContentSnapshot oCellContentSnapshotCur; //текущее внутр.перемещение

		// для фильтров
		public int? _SelectedID;
		public string _SelectedIDList;
		public string _SelectedText;

		public string _SelectedPackingIDList;
		public string _SelectedPackingAliasText;
		private string sSelectedPackingIDList = "";

		public string _SelectedCellsIDList;
		public string _SelectedCellAddressText;
		private string sSelectedCellsIDList = "";

		private string sSelectedGoodsStatesIDList = "";
		private string sSelectedOwnersIDList = "";

		public frmCellsContentsSnapshots()
		{
			oCellContentSnapshotList = new CellContentSnapshot();
			oCellContentSnapshotCur = new CellContentSnapshot();
			if (oCellContentSnapshotList.ErrorNumber != 0 ||
				oCellContentSnapshotCur.ErrorNumber != 0)
			{
				IsValid = false;
			}

			if (IsValid)
			{
				InitializeComponent();
			}
		}

		private void frmCellsContentsSnapshots_Load(object sender, EventArgs e)
		{
			RFMCursorWait.Set(true);

			grcDetailBeg_Qnt.AgrType =
			grcDetailBeg_BoxQnt.AgrType = 
			grcDetailBeg_PalQnt.AgrType =
			grcDetailEnd_Qnt.AgrType =
			grcDetailEnd_BoxQnt.AgrType =
			grcDetailEnd_PalQnt.AgrType =
			grcDetailGroupByCells_Qnt_Beg.AgrType =
			grcDetailGroupByCells_BoxQnt_Beg.AgrType =
			grcDetailGroupByCells_PalQnt_Beg.AgrType =
			grcDetailGroupByCells_Qnt_End.AgrType =
			grcDetailGroupByCells_BoxQnt_End.AgrType =
			grcDetailGroupByCells_PalQnt_End.AgrType =
			grcDetailGroupAll_Qnt_Beg.AgrType =
			grcDetailGroupAll_BoxQnt_Beg.AgrType =
			grcDetailGroupAll_PalQnt_Beg.AgrType =
			grcDetailGroupAll_Qnt_End.AgrType =
			grcDetailGroupAll_BoxQnt_End.AgrType =
			grcDetailGroupAll_PalQnt_End.AgrType =
			grcInventoriesCells_QntWished.AgrType =
			grcInventoriesCells_QntConfirmed.AgrType =
			grcInventoriesCells_QntDiff.AgrType =
			grcInventoriesCells_BoxWished.AgrType =
			grcInventoriesCells_BoxConfirmed.AgrType =
			grcInventoriesCells_BoxDiff.AgrType =
				EnumAgregate.Sum;

			btnClearTerms_Click(null, null);

			tcList.Init();

			RFMCursorWait.Set(false);
		}

		#region Tab Restore

		private bool tabTerms_Restore()
		{
			btnCreate.Enabled =
			btnClose.Enabled =
			btnPrint.Enabled =
			btnService.Enabled = 
				false;
			return (true);
		}

		private bool tabData_Restore()
		{
			grdData_Restore();
			btnCreate.Enabled = 
			btnService.Enabled = 
				true;
			if (grdData.Rows.Count > 0)
			{
				btnClose.Enabled =
				btnPrint.Enabled =
					true;
			}
			else
			{
				btnClose.Enabled =
				btnPrint.Enabled =
					false;
			}
			return (true);
		}

		private void tcList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tcList.SelectedTab.Name.ToUpper().Contains("TERMS"))
			{
				btnCreate.Enabled =
				btnClose.Enabled =
				btnPrint.Enabled =
				btnService.Enabled = 
					false;
			}

			if (tcList.SelectedTab.Name.ToUpper().Contains("DATA"))
			{
				btnCreate.Enabled = 
				btnService.Enabled = 
					true;
				grdData.Select();

				if (grdData.Rows.Count > 0 && grdData.CurrentRow != null)
				{
					btnPrint.Enabled = true;
				
					if (!tabData.IsNeedRestore)
					{
						if (!grdData.IsStatusRow(grdData.CurrentRow.Index))
						{
							DataRow r = ((DataRowView)grdData.CurrentRow.DataBoundItem).Row;
							oCellContentSnapshotCur.ID = Convert.ToInt32(r["ID"]);
							SetButtonStatus(r);
						}
					}
				}
			}
		}

		#region Bottom Tab Restore

		private bool tabDetailBeg_Restore()
		{
			return grdDetailBeg_Restore();
		}

		private bool tabDetailEnd_Restore()
		{
			return grdDetailEnd_Restore();
		}

		private bool tabDetailGroupByCells_Restore()
		{
			return grdDetailGroupByCells_Restore();
		}

		private bool tabDetailGroupAll_Restore()
		{
			return grdDetailGroupAll_Restore();
		}

		private bool tabInventories_Restore()
		{
			return grdInventories_Restore();
		}

		private bool tabInventoriesCells_Restore()
		{
			return grdInventoriesCells_Restore();
		}

		#endregion Bottom Tab Restore

		#endregion Tab Restore

		#region Buttons

		private void btnCreate_Click(object sender, EventArgs e)
		{
			// проверить, нет ли уже незакрытой копии 
			CellContentSnapshot oCellContentSnapshotTemp = new CellContentSnapshot();
			oCellContentSnapshotTemp.FilterIsClosed = false;
			oCellContentSnapshotTemp.FillData();
			if (oCellContentSnapshotTemp.ErrorNumber != 0 || oCellContentSnapshotTemp.MainTable == null)
			{
				RFMMessage.MessageBoxError("Ошибка при проверке существующих копий...");
				return;
			}
			if (oCellContentSnapshotTemp.MainTable.Rows.Count > 0)
			{
				RFMMessage.MessageBoxError("Существуют незакрытые копии...\n\rОткрытие новой копии невозможно.");
				return;
			}

			if (RFMMessage.MessageBoxYesNo("Открыть новую копию?") != DialogResult.Yes)
				return;

			oCellContentSnapshotTemp.ClearFilters();
			string sNote = "";
			if (StartForm(new frmInputBoxString("Примечание для копии:", sNote)) == DialogResult.Yes)
			{
				Refresh();
				sNote = GotParam[0].ToString();
				if (oCellContentSnapshotTemp.Create(0, ((RFMFormMain)Application.OpenForms[0]).UserID, sNote))
				{
					grdData_Restore();
					if (oCellContentSnapshotTemp.ID.HasValue && oCellContentSnapshotTemp.ID > 0)
					{
						grdData.GridSource.Position = grdData.GridSource.Find(oCellContentSnapshotList.ColumnID, Convert.ToInt32(oCellContentSnapshotTemp.ID));
					}
				}
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			if (grdData.CurrentRow == null)
				return;

			int nID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			
			// проверить, не закрыта ли уже копия
			CellContentSnapshot oCellContentSnapshotTemp = new CellContentSnapshot();
			oCellContentSnapshotTemp.ID = nID;
			oCellContentSnapshotTemp.FillData();
			if (oCellContentSnapshotTemp.ErrorNumber != 0 || oCellContentSnapshotTemp.MainTable == null || oCellContentSnapshotTemp.MainTable.Rows.Count != 1)
			{
				RFMMessage.MessageBoxError("Ошибка при проверке копии...");
				return;
			}
			if (!Convert.IsDBNull(oCellContentSnapshotTemp.MainTable.Rows[0]["DateEnd"]))
			{
				RFMMessage.MessageBoxError("Копия уже закрыта...");
				return;
			}

			// проверить состояние ревизий
			Inventory oInventory = new Inventory();

			// нет ли незакрытых ревизий среди привязанных?
			oInventory.FilterCellContentSnapshotID = nID;
			oInventory.FilterConfirmed = false;
			oInventory.FillData();
			if (oInventory.ErrorNumber != 0 || oInventory.MainTable == null)
			{
				RFMMessage.MessageBoxError("Ошибка при проверке незавершенных ревизий...");
				return;
			}
			if (oInventory.MainTable.Rows.Count > 0)
			{
				if (RFMMessage.MessageBoxYesNo("Обнаружены незавершенные ревизии, связанные с текущей копией остатков......\n" +
					"Все-таки закрыть текущую копию остатков?") != DialogResult.Yes)
					return;
			}

			// нет ли неоткрытых ревизий, подготовленных в ближайшем прошлом
			oInventory.ClearFilters();
			oInventory.FilterStarted = false;
			oInventory.FilterDateBeg = DateTime.Now.Date.AddDays(-7);  
			oInventory.FillData();
			if (oInventory.ErrorNumber != 0 || oInventory.MainTable == null)
			{
				RFMMessage.MessageBoxError("Ошибка при необработанных ревизий...");
				return;
			}
			if (oInventory.MainTable.Rows.Count > 0)
			{
				if (RFMMessage.MessageBoxYesNo("Обнаружены необработанные ревизии, оформленные в ближайший прошедший период...\n" + 
					"Все-таки закрыть текущую копию остатков?") != DialogResult.Yes)
					return;
			}
			//
			// все проверили, можно закрывать

			if (RFMMessage.MessageBoxYesNo("Закрыть текущую копию?") != DialogResult.Yes)
				return;

			if (oCellContentSnapshotTemp.Close(nID, ((RFMFormMain)Application.OpenForms[0]).UserID))
			{
				grdData_Restore();
			}
		}

        private void btnPrepareAct_Click(object sender, EventArgs e)
        {
            if (grdData.CurrentRow == null)
                return;

            int nID = (int)grdData.CurrentRow.Cells["grcID"].Value;

            // проверить, закрыта ли уже копия
            CellContentSnapshot oCellContentSnapshotTemp = new CellContentSnapshot();
            oCellContentSnapshotTemp.ID = nID;
            oCellContentSnapshotTemp.FillData();
            if (oCellContentSnapshotTemp.ErrorNumber != 0 || oCellContentSnapshotTemp.MainTable == null || oCellContentSnapshotTemp.MainTable.Rows.Count != 1)
            {
                RFMMessage.MessageBoxError("Ошибка при проверке копии...");
                return;
            }
            if (Convert.IsDBNull(oCellContentSnapshotTemp.MainTable.Rows[0]["DateEnd"]))
            {
                RFMMessage.MessageBoxError("Копия еще не закрыта...");
                return;
            }

            StartForm(new frmCCSPrepareInventoryAct(nID));
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
			if (grdData.IsLockRowChanged)
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

			if (grdData.IsStatusRow(rowIndex))
			{
				oCellContentSnapshotCur.ID = 0;
				btnClose.Enabled =
					false;
			}
			else
			{
				//DataGridViewRow r = grdData.Rows[rowIndex];
				DataRow r = ((DataRowView)grdData.Rows[rowIndex].DataBoundItem).Row;
				oCellContentSnapshotCur.ID = Convert.ToInt32(r["ID"]);
				SetButtonStatus(r);
			}

			tcCellsContentsSnapshotsDetails.SetAllNeedRestore(true);
		}

		private void grdData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (grdData.DataSource == null)
				return;

			if (grdData.IsStatusRow(e.RowIndex))
			{
				switch (grdData.Columns[e.ColumnIndex].Name)
				{
					case "grcIsClosedImage":
						e.Value = Properties.Resources.Empty;
						break;
				}
				return;
			}

			DataGridViewRow r = grdData.Rows[e.RowIndex];
			switch (grdData.Columns[e.ColumnIndex].Name)
			{
				case "grcIsClosedImage":
					if ((bool)r.Cells["grcIsClosed"].Value)
						e.Value = Properties.Resources.Check;
					else
						e.Value = Properties.Resources.Empty;
					break;
			}
		}

		private void grdCellsContentsSnapshotsDetail_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			RFMDataGridView grd = (RFMDataGridView)sender;

			if (grd.DataSource == null)
				return;

			if (grd.IsStatusRow(e.RowIndex))
			{
				if (grd.Columns[e.ColumnIndex].Name.Contains("Image"))
					e.Value = Properties.Resources.Empty;
				return;
			}

			DataRow r = ((DataRowView)grd.Rows[e.RowIndex].DataBoundItem).Row;
			switch (grd.Columns[e.ColumnIndex].Name)
			{
				case "grcDetailGroupByCells_IsDiffImage":
				case "grcDetailGroupAll_IsDiffImage":
					if (Convert.ToBoolean(r["IsDiff"]))
						e.Value = Properties.Resources.Exclamation;
					else
						e.Value = Properties.Resources.Empty;
					break;
				case "grcDetailBeg_LockedImage":
				case "grcDetailEnd_LockedImage":
					if (Convert.ToBoolean(r["Locked"]))
						e.Value = Properties.Resources.Lock1;
					else
						e.Value = Properties.Resources.Empty;
					break;
				case "grcDetailGroupByCells_LockedImage_Beg":
					if (!Convert.IsDBNull(r["Locked_Beg"]) && Convert.ToBoolean(r["Locked_Beg"]))
						e.Value = Properties.Resources.Lock1;
					else
						e.Value = Properties.Resources.Empty;
					break;
				case "grcDetailGroupByCells_LockedImage_End":
					if (!Convert.IsDBNull(r["Locked_End"]) && Convert.ToBoolean(r["Locked_End"]))
						e.Value = Properties.Resources.Lock1;
					else
						e.Value = Properties.Resources.Empty;
					break;
				case "grcDetailBeg_Qnt":
				case "grcDetailBeg_InBox":
				case "grcDetailEnd_Qnt":
				case "grcDetailEnd_InBox":
				case "grcDetailGroupAll_Qnt_Beg":
				case "grcDetailGroupAll_InBox_Beg":
				case "grcDetailGroupAll_Qnt_End":
				case "grcDetailGroupAll_InBox_End":
					if ((!Convert.IsDBNull(r["Weighting"]) && Convert.ToBoolean(r["Weighting"])) ||
						!Convert.IsDBNull(e.Value) && Convert.ToDecimal(e.Value) != Convert.ToInt32(e.Value))
						e.CellStyle.Format = "### ### ### ###.000";
					else
						e.CellStyle.Format = "### ### ### ###";
					break;
				case "grcDetailGroupByCells_Qnt_Beg":
				case "grcDetailGroupByCells_InBox_Beg":
 					if ((!Convert.IsDBNull(r["Weighting_Beg"]) && Convert.ToBoolean(r["Weighting_Beg"])) ||
						!Convert.IsDBNull(e.Value) && Convert.ToDecimal(e.Value) != Convert.ToInt32(e.Value))
						e.CellStyle.Format = "### ### ### ###.000";
					else
						e.CellStyle.Format = "### ### ### ###";
					break;
				case "grcDetailGroupByCells_Qnt_End":
				case "grcDetailGroupByCells_InBox_End":
					if ((!Convert.IsDBNull(r["Weighting_End"]) && Convert.ToBoolean(r["Weighting_End"])) ||
						!Convert.IsDBNull(e.Value) && Convert.ToDecimal(e.Value) != Convert.ToInt32(e.Value) )
						e.CellStyle.Format = "### ### ### ###.000";
					else
						e.CellStyle.Format = "### ### ### ###";
					break;
			}

			if ((grd.Columns[e.ColumnIndex].Name.Contains("Qnt") ||
				 grd.Columns[e.ColumnIndex].Name.Contains("Box") ||
				 grd.Columns[e.ColumnIndex].Name.Contains("Pal")) &&
				grd.Columns[e.ColumnIndex].DefaultCellStyle.Format.Contains("N"))
			{
				if (Convert.IsDBNull(e.Value) || Convert.ToDecimal(e.Value) == 0)
				{
					e.Value = "";
				}
			}
		}

		private void grdInventories_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			RFMDataGridView grd = (RFMDataGridView)sender; // grdInventories

			if (grd.DataSource == null)
				return;

			if (grd.IsStatusRow(e.RowIndex))
			{
				if (grd.Columns[e.ColumnIndex].Name.Contains("Image"))
					e.Value = Properties.Resources.Empty;
				return;
			}

			DataRow r = ((DataRowView)grd.Rows[e.RowIndex].DataBoundItem).Row;
			switch (grd.Columns[e.ColumnIndex].Name)
			{
				case "grcInventories_IsConfirmedImage":
					if (Convert.ToBoolean(r["IsConfirmed"]))
						e.Value = Properties.Resources.Check;
					else
						e.Value = Properties.Resources.Empty;
					break;
			}
		}

		private void grdInventoriesCells_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			RFMDataGridView grd = (RFMDataGridView)sender; // grdInventoriesCells

			if (grd.DataSource == null)
				return;

			if (grd.IsStatusRow(e.RowIndex))
			{
				if (grd.Columns[e.ColumnIndex].Name.Contains("Image"))
					e.Value = Properties.Resources.Empty;
				return;
			}

			DataRow r = ((DataRowView)grd.Rows[e.RowIndex].DataBoundItem).Row;
			switch (grd.Columns[e.ColumnIndex].Name)
			{
				case "grcInventoriesCells_IsCellSuccessImage":
					if (Convert.IsDBNull(r["Success"]))
						e.Value = Properties.Resources.Empty;
					else
					{
						if (Convert.ToBoolean(r["Success"]))
							e.Value = Properties.Resources.Check;
						else
							e.Value = Properties.Resources.CheckRed;
					}
					break;
				case "grcInventoriesCells_InBox":
				case "grcInventoriesCells_QntWished":
				case "grcInventoriesCells_QntConfirmed":
				case "grcInventoriesCells_QntDiff":
					if (Convert.IsDBNull(r["GoodWeighting"]) ||
						Convert.ToBoolean(r["GoodWeighting"]) ||
						!Convert.IsDBNull(e.Value) && Convert.ToDecimal(e.Value) != Convert.ToInt32(e.Value))
						e.CellStyle.Format = "### ### ### ##0.000";
					else
						e.CellStyle.Format = "### ### ### ###";
					break;
				case "grcInventoriesCells_BoxWished":
				case "grcInventoriesCells_BoxConfirmed":
				case "grcInventoriesCells_BoxDiff":
					if (!Convert.IsDBNull(e.Value) && Convert.ToDecimal(e.Value) == 0)
						e.Value = "";
					break;
			}
		}

		#endregion

		#region SetButtonStatus

		private void SetButtonStatus(DataRow r)
		{
			if (r == null)
			{
				btnClose.Enabled = btnPrepareAct.Enabled = false;
				return;
			}

			bool bIsClosed = Convert.ToBoolean(r["IsClosed"]);
			btnClose.Enabled = !bIsClosed;
            btnPrepareAct.Enabled = bIsClosed;
			return;
		}

		#endregion SetButtonStatus

		#region Restore

		private bool grdData_Restore()
		{
			RFMCursorWait.Set(true);
			RFMCursorWait.LockWindowUpdate(FindForm().Handle);

			oCellContentSnapshotCur.ID = null;

			oCellContentSnapshotList.ClearError();
			oCellContentSnapshotList.ClearFilters();
			oCellContentSnapshotList.ID = null;
			oCellContentSnapshotList.IDList = null;

			// собираем условия

			// даты
			if (!dtrDates.dtpBegDate.IsEmpty)
			{
				oCellContentSnapshotList.FilterDateBeg = dtrDates.dtpBegDate.Value.Date;
			}
			if (!dtrDates.dtpEndDate.IsEmpty)
			{
				oCellContentSnapshotList.FilterDateEnd = dtrDates.dtpEndDate.Value.Date;
			}
			// владельцы
			if (sSelectedOwnersIDList.Length > 0)
			{
				oCellContentSnapshotList.FilterOwnersList = sSelectedOwnersIDList;
			}
			// состояния
			if (sSelectedGoodsStatesIDList.Length > 0)
			{
				oCellContentSnapshotList.FilterGoodsStatesList = sSelectedGoodsStatesIDList;
			}
			// ячейки
			if (sSelectedCellsIDList.Length > 0)
			{
				oCellContentSnapshotList.FilterCellsList = sSelectedCellsIDList;
			}
			// товары
			if (sSelectedPackingIDList.Length > 0)
			{
				oCellContentSnapshotList.FilterPackingsList = sSelectedPackingIDList;
			}

			// подтверждение
			if (optIsClosed.Checked)
			{
				oCellContentSnapshotList.FilterIsClosed = true;
			}
			if (optIsClosedNot.Checked)
			{
				oCellContentSnapshotList.FilterIsClosed = false;
			}
			// 

			grdDetailBeg.DataSource = null;
			grdDetailEnd.DataSource = null;
			grdDetailGroupByCells.DataSource = null;
			grdDetailGroupAll.DataSource = null;

			grdData.GetGridState();

			oCellContentSnapshotList.FillData();

			grdData.IsLockRowChanged = true;
			grdData.Restore(oCellContentSnapshotList.MainTable);
			tmrRestore.Enabled = true;

			RFMCursorWait.LockWindowUpdate(IntPtr.Zero);
			RFMCursorWait.Set(false);

			return (oCellContentSnapshotList.ErrorNumber == 0);
		}

		private bool grdDetailBeg_Restore()
		{
			grdDetailBeg.GetGridState();
			grdDetailBeg.DataSource = null;
			if (grdData.Rows.Count == 0 ||
				oCellContentSnapshotCur.ID == null ||
				grdData.CurrentRow != null && grdData.IsStatusRow(grdData.CurrentRow.Index))
				return (true);

			RFMCursorWait.Set(true);
			RFMCursorWait.LockWindowUpdate(FindForm().Handle);

			oCellContentSnapshotList.ClearError();
			oCellContentSnapshotList.FillTableCellsContentsSnapshotsDetails((int)oCellContentSnapshotCur.ID, 0, 
				false, false, 
				false, chkInInventoryOnly.Checked);
			DataTable tableCellContentSnapshotsDetailsBeg = oCellContentSnapshotList.TableCellsContentsSnapshotsDetails;
			grdDetailBeg.Restore(tableCellContentSnapshotsDetailsBeg);
			
			RFMCursorWait.LockWindowUpdate(IntPtr.Zero);
			RFMCursorWait.Set(false);
			return (oCellContentSnapshotList.ErrorNumber == 0);
		}

		private bool grdDetailEnd_Restore()
		{
			grdDetailEnd.GetGridState();
			grdDetailEnd.DataSource = null;
			if (grdData.Rows.Count == 0 ||
				oCellContentSnapshotCur.ID == null ||
				grdData.CurrentRow != null && grdData.IsStatusRow(grdData.CurrentRow.Index))
				return (true);

			RFMCursorWait.Set(true);
			RFMCursorWait.LockWindowUpdate(FindForm().Handle);
			
			oCellContentSnapshotList.ClearError();
			oCellContentSnapshotList.FillTableCellsContentsSnapshotsDetails((int)oCellContentSnapshotCur.ID, 1, 
				false, false,
				false, chkInInventoryOnly.Checked);
			DataTable tableCellContentSnapshotsDetailsEnd = oCellContentSnapshotList.TableCellsContentsSnapshotsDetails;
			grdDetailEnd.Restore(tableCellContentSnapshotsDetailsEnd);
			
			RFMCursorWait.LockWindowUpdate(IntPtr.Zero);
			RFMCursorWait.Set(false);
			return (oCellContentSnapshotList.ErrorNumber == 0);
		}

		private bool grdDetailGroupByCells_Restore()
		{
			grdDetailGroupByCells.GetGridState();
			grdDetailGroupByCells.DataSource = null;
			if (grdData.Rows.Count == 0 ||
				oCellContentSnapshotCur.ID == null ||
				grdData.CurrentRow != null && grdData.IsStatusRow(grdData.CurrentRow.Index))
				return (true);

			RFMCursorWait.Set(true);
			RFMCursorWait.LockWindowUpdate(FindForm().Handle);

			// не показываем для незакрытых копий
			oCellContentSnapshotCur.FillData();
			if (oCellContentSnapshotCur.ErrorNumber != 0 ||
				oCellContentSnapshotCur.MainTable == null ||
				oCellContentSnapshotCur.MainTable.Rows.Count != 1 ||
				Convert.IsDBNull(oCellContentSnapshotCur.MainTable.Rows[0]["DateEnd"]))
			{
				RFMCursorWait.LockWindowUpdate(IntPtr.Zero);
				RFMCursorWait.Set(false);
				return (true);
			}

			oCellContentSnapshotList.ClearError();
			oCellContentSnapshotList.FillTableCellsContentsSnapshotsDetails((int)oCellContentSnapshotCur.ID, 2,
				false, chkExcludeLostFoundEndGroupByCells.Checked, 
				chkDiffOnly.Checked, chkInInventoryOnly.Checked);
			DataTable tableCellContentSnapshotsDetailsGroupByCells = oCellContentSnapshotList.TableCellsContentsSnapshotsDetails;
			grdDetailGroupByCells.Restore(tableCellContentSnapshotsDetailsGroupByCells);
			
			RFMCursorWait.LockWindowUpdate(IntPtr.Zero);
			RFMCursorWait.Set(false);
			return (oCellContentSnapshotList.ErrorNumber == 0);
		}

		private bool grdDetailGroupAll_Restore()
		{
			grdDetailGroupAll.GetGridState();
			grdDetailGroupAll.DataSource = null;
			if (grdData.Rows.Count == 0 ||
				oCellContentSnapshotCur.ID == null ||
				grdData.CurrentRow != null && grdData.IsStatusRow(grdData.CurrentRow.Index))
				return (true);

			RFMCursorWait.Set(true);
			RFMCursorWait.LockWindowUpdate(FindForm().Handle);

			// не показываем для незакрытых копий
			oCellContentSnapshotCur.FillData();
			if (oCellContentSnapshotCur.ErrorNumber != 0 ||
				oCellContentSnapshotCur.MainTable == null ||
				oCellContentSnapshotCur.MainTable.Rows.Count != 1 ||
				Convert.IsDBNull(oCellContentSnapshotCur.MainTable.Rows[0]["DateEnd"]))
			{
				RFMCursorWait.LockWindowUpdate(IntPtr.Zero);
				RFMCursorWait.Set(false);
				return (true);
			}

			oCellContentSnapshotList.ClearError();
			oCellContentSnapshotList.FillTableCellsContentsSnapshotsDetails((int)oCellContentSnapshotCur.ID, 3, 
				false, chkExcludeLostFoundEndGroupAll.Checked, 
				chkDiffOnly.Checked, chkInInventoryOnly.Checked);
			DataTable tableCellContentSnapshotsDetailsGroupAll = oCellContentSnapshotList.TableCellsContentsSnapshotsDetails;
			grdDetailGroupAll.Restore(tableCellContentSnapshotsDetailsGroupAll);
			
			RFMCursorWait.LockWindowUpdate(IntPtr.Zero);
			RFMCursorWait.Set(false);
			return (oCellContentSnapshotList.ErrorNumber == 0);
		}

		private bool grdInventories_Restore()
		{
			grdInventories.GetGridState();
			grdInventories.DataSource = null;
			if (grdData.Rows.Count == 0 ||
				oCellContentSnapshotCur.ID == null ||
				grdData.CurrentRow != null && grdData.IsStatusRow(grdData.CurrentRow.Index))
				return (true);

			RFMCursorWait.Set(true);
			RFMCursorWait.LockWindowUpdate(FindForm().Handle);

			Inventory oInventory = new Inventory();
			oInventory.FilterCellContentSnapshotID = (int)oCellContentSnapshotCur.ID;
			oInventory.FillData();
			grdInventories.Restore(oInventory.MainTable);

			RFMCursorWait.LockWindowUpdate(IntPtr.Zero);
			RFMCursorWait.Set(false);
			return (oInventory.ErrorNumber == 0);
		}

		private bool grdInventoriesCells_Restore()
		{
			grdInventoriesCells.GetGridState();
			grdInventoriesCells.DataSource = null;
			if (grdData.Rows.Count == 0 ||
				oCellContentSnapshotCur.ID == null ||
				grdData.CurrentRow != null && grdData.IsStatusRow(grdData.CurrentRow.Index))
				return (true);

			RFMCursorWait.Set(true);
			RFMCursorWait.LockWindowUpdate(FindForm().Handle);

			Inventory oInventoryCell = new Inventory();
			oInventoryCell.FilterCellContentSnapshotID = (int)oCellContentSnapshotCur.ID;
			if (sSelectedCellsIDList != null && sSelectedCellsIDList.Length > 0)
				oInventoryCell.FilterCellsList = sSelectedCellsIDList;
			oInventoryCell.FillData();
			DataTable dtInventoriesCellsTemp = null;
			DataTable dtInventoriesCells = null;
			if (oInventoryCell.MainTable.Rows.Count > 0)
			{
				foreach (DataRow r in oInventoryCell.MainTable.Rows)
				{
					oInventoryCell.FillTableInventoriesCells((int)r["ID"]);
					if (dtInventoriesCellsTemp == null)
					{
						dtInventoriesCellsTemp = oInventoryCell.TableInventoriesCells.Copy();
					}
					else
					{
						dtInventoriesCellsTemp.Merge(oInventoryCell.TableInventoriesCells);
					}
				}

				string sFilter = "";
				if (sSelectedPackingIDList != null && sSelectedPackingIDList.Length > 0)
				{
					if (sSelectedPackingIDList.Substring(0, 1) == ",")
						sSelectedPackingIDList = sSelectedPackingIDList.Substring(1, sSelectedPackingIDList.Length - 1);
					if (sSelectedPackingIDList.Substring(sSelectedPackingIDList.Length - 1, 1) == ",")
						sSelectedPackingIDList = sSelectedPackingIDList.Substring(0, sSelectedPackingIDList.Length - 1);
					sFilter = "PackingID in (" + sSelectedPackingIDList + ")";
				}
				dtInventoriesCells = CopyTable(dtInventoriesCellsTemp, "dtInventoriesCells", sFilter, "Address, GoodAlias");
				grdInventoriesCells.Restore(dtInventoriesCells);
			}

			RFMCursorWait.LockWindowUpdate(IntPtr.Zero);
			RFMCursorWait.Set(false);
			return (oInventoryCell.ErrorNumber == 0);
		}

		#endregion Restore

		#region Filters

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
				tcCellsContentsSnapshotsDetails.SetAllNeedRestore(true); 
			}

			_SelectedCellsIDList = null;
			_SelectedCellAddressText = "";
		}

		private void btnCellsClear_Click(object sender, EventArgs e)
		{
			tabData.IsNeedRestore = true;
			tcCellsContentsSnapshotsDetails.SetAllNeedRestore(true); 

			ttToolTip.SetToolTip(txtCellsChoosen, "не выбраны");
			sSelectedCellsIDList = "";
			txtCellsChoosen.Text = "";
		}

		#endregion Cells

		#region Owners

		private void btnOwnersChoose_Click(object sender, EventArgs e)
		{
			_SelectedIDList = null;
			_SelectedText = "";

			Partner oOwner = new Partner();
			oOwner.FilterOwner = true;
			oOwner.FilterActual = true;
			oOwner.FillDataOwners();
			if (oOwner.ErrorNumber != 0 || oOwner.MainTable == null)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных...");
				return;
			}
			if (oOwner.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Нет данных...");
				return;
			}

			if (StartForm(new frmSelectID(this, oOwner.MainTable, "Name,Actual", "Хранитель,Акт.", true)) == DialogResult.Yes)
			{
				if (_SelectedIDList == null || !_SelectedIDList.Contains(","))
				{
					btnOwnersClear_Click(null, null);
					return;
				}

				sSelectedOwnersIDList = "," + _SelectedIDList;

				txtOwnersChoosen.Text = _SelectedText;
				ttToolTip.SetToolTip(txtOwnersChoosen, txtOwnersChoosen.Text);

				tabData.IsNeedRestore = true;
				tcCellsContentsSnapshotsDetails.SetAllNeedRestore(true);
			}

			_SelectedIDList = null;
			_SelectedText = "";
		}

		private void btnOwnersClear_Click(object sender, EventArgs e)
		{
			tabData.IsNeedRestore = true;
			tcCellsContentsSnapshotsDetails.SetAllNeedRestore(true); 

			ttToolTip.SetToolTip(txtOwnersChoosen, "не выбраны");
			sSelectedOwnersIDList = "";
			txtOwnersChoosen.Text = "";
		}

		#endregion

		#region GoodsStates

		private void btnGoodsStatesChoose_Click(object sender, EventArgs e)
		{
			_SelectedIDList = null;
			_SelectedText = "";

			GoodState oGoodState = new GoodState();
			oGoodState.FillData();
			if (oGoodState.ErrorNumber != 0 || oGoodState.MainTable == null)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных...");
				return;
			}
			if (oGoodState.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Нет данных...");
				return;
			}

			if (StartForm(new frmSelectID(this, oGoodState.MainTable, "Name", "Состояние товара", true)) == DialogResult.Yes)
			{
				if (_SelectedIDList == null || !_SelectedIDList.Contains(","))
				{
					btnGoodsStatesClear_Click(null, null);
					return;
				}

				sSelectedGoodsStatesIDList = "," + _SelectedIDList;

				txtGoodsStatesChoosen.Text = _SelectedText;
				ttToolTip.SetToolTip(txtGoodsStatesChoosen, txtGoodsStatesChoosen.Text);

				tabData.IsNeedRestore = true;
				tcCellsContentsSnapshotsDetails.SetAllNeedRestore(true);
			}

			_SelectedIDList = null;
			_SelectedText = "";
		}

		private void btnGoodsStatesClear_Click(object sender, EventArgs e)
		{
			tabData.IsNeedRestore = true;
			tcCellsContentsSnapshotsDetails.SetAllNeedRestore(true); 

			ttToolTip.SetToolTip(txtGoodsStatesChoosen, "не выбраны");
			sSelectedGoodsStatesIDList = "";
			txtGoodsStatesChoosen.Text = "";
		}


		private void btnGoodsStatesNewChoose_Click(object sender, EventArgs e)
		{
			_SelectedIDList = null;
			_SelectedText = "";

			GoodState oGoodStateNew = new GoodState();
			oGoodStateNew.FillData();
			if (oGoodStateNew.ErrorNumber != 0 || oGoodStateNew.MainTable == null)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных...");
				return;
			}
			if (oGoodStateNew.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Нет данных...");
				return;
			}

			if (StartForm(new frmSelectID(this, oGoodStateNew.MainTable, "Name", "Состояние товара", true)) == DialogResult.Yes)
			{
				if (_SelectedIDList == null || !_SelectedIDList.Contains(","))
				{
					btnGoodsStatesNewClear_Click(null, null);
					return;
				}

				sSelectedGoodsStatesIDList = "," + _SelectedIDList;

				txtGoodsStatesChoosen.Text = _SelectedText;
				ttToolTip.SetToolTip(txtGoodsStatesChoosen, txtGoodsStatesChoosen.Text);

				tabData.IsNeedRestore = true;
				tcCellsContentsSnapshotsDetails.SetAllNeedRestore(true);
			}

			_SelectedIDList = null;
			_SelectedText = "";
		}

		private void btnGoodsStatesNewClear_Click(object sender, EventArgs e)
		{
			tabData.IsNeedRestore = true;
			tcCellsContentsSnapshotsDetails.SetAllNeedRestore(true); 

			ttToolTip.SetToolTip(txtGoodsStatesChoosen, "не выбраны");
			sSelectedGoodsStatesIDList = "";
			txtGoodsStatesChoosen.Text = "";
		}

		#endregion GoodsStates

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

				sSelectedPackingIDList = "," + _SelectedPackingIDList;
				txtPackingsChoosen.Text = _SelectedPackingAliasText;
				ttToolTip.SetToolTip(txtPackingsChoosen, txtPackingsChoosen.Text);

				tabData.IsNeedRestore = true;
				tcCellsContentsSnapshotsDetails.SetAllNeedRestore(true);
			}

			_SelectedPackingIDList = null;
			_SelectedPackingAliasText = "";
		}

		private void btnPackingsClear_Click(object sender, EventArgs e)
		{
			tabData.IsNeedRestore = true;
			tcCellsContentsSnapshotsDetails.SetAllNeedRestore(true); 

			ttToolTip.SetToolTip(txtPackingsChoosen, "не выбраны");
			sSelectedPackingIDList = "";
			txtPackingsChoosen.Text = "";
		}

		#endregion

		#endregion Filters

		#region Menu Print

		private void btnPrint_Click(object sender, EventArgs e)
		{
			btnPrint.ShortCutSet(mnuPrint);
		}

		#endregion

		#region Menu Service

		private void btnService_Click(object sender, EventArgs e)
		{
			btnService.ShortCutSet(mnuService);
			btnService.ShortCutShow(mnuService);
		}

		private void mniService_CellsForInputsClear_Click(object sender, EventArgs e)
		{
			if (RFMMessage.MessageBoxYesNo("Выполнить \"очистку\" ячеек прихода\n" +
				"(все товары без контейнеров, зарегистрированные в приходных ячейках, " +
				"будут \"перенесены\" в виртуальную ячейку Lost&Found)?") != DialogResult.Yes)
				return;

			if (RFMMessage.MessageBoxYesNo("ВНИМАНИЕ!\n\n" +
				"Операция \"очистки\" приходных ячеек является необратимой!\n\n" +
				"Все-таки выполнить \"очистку\" приходных ячеек?") != DialogResult.Yes)
				return;

			WaitOn(this);
			if (oCellContentSnapshotList.CellsForInputsClear(((RFMFormBase)Application.OpenForms[0]).UserInfo.UserID))
			{
				WaitOff(this);
				RFMMessage.MessageBoxInfo("Операция \"очистки\" приходных ячеек выполнена.");
			}
			WaitOff(this);
		}

		private void mniService_CellsForOutputsClear_Click(object sender, EventArgs e)
		{
			if (RFMMessage.MessageBoxYesNo("Выполнить \"очистку\" ячеек отгрузки\n" +
				"(все товары без контейнеров, зарегистрированные в ячейках отгрузки и не предназначенные для выдачи, " +
				"будут \"перенесены\" в виртуальную ячейку Lost&Found)?") != DialogResult.Yes)
				return;

			if (RFMMessage.MessageBoxYesNo("ВНИМАНИЕ!\n\n" +
				"Операция \"очистки\" ячеек отгрузки является необратимой!\n\n" +
				"Все-таки выполнить \"очистку\" ячеек отгрузки?") != DialogResult.Yes)
				return;

			WaitOn(this);
			if (oCellContentSnapshotList.CellsForOutputsClear(((RFMFormBase)Application.OpenForms[0]).UserInfo.UserID))
			{
				WaitOff(this);
				RFMMessage.MessageBoxInfo("Операция \"очистки\" ячеек отгрузки выполнена.");
			}
			WaitOff(this);
		}

		#endregion

		#region Terms clear

		private void btnClearTerms_Click(object sender, EventArgs e)
		{
			dtrDates.dtpBegDate.Value = DateTime.Now.AddDays(-7).Date;
			dtrDates.dtpEndDate.Value = DateTime.Now.Date;

			optIsClosedNot.Checked = true;

			btnCellsClear_Click(null, null);
			btnGoodsStatesClear_Click(null, null);
			btnOwnersClear_Click(null, null);
			btnPackingsClear_Click(null, null);

			chkExcludeLostFoundEndGroupByCells.Checked =
			chkExcludeLostFoundEndGroupAll.Checked =
				true;
			chkDiffOnly.Checked =
			chkInInventoryOnly.Checked =
				false;

			if (Control.ModifierKeys == Keys.Shift)
			{
				optIsClosedAny.Checked = true;
				dtrDates.dtpBegDate.HideControl(false);
				dtrDates.dtpEndDate.HideControl(false);
			}

			tabData.IsNeedRestore = true;
		}

		#endregion

	}
}