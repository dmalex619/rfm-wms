using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Threading;

using RFMBaseClasses;
using WMSBizObjects;
using RFMPublic;

namespace WMSSuitable
{
	public partial class frmCells : RFMFormChild
	{
		private Cell oCellList;
		private Cell oCellCur;

		// для фильтров
		private Good oGood;
		private Cell oCellAddress;
		private TrafficFrame oTrafficFrame;

		public string _SelectedCellsIDList;
		public string _SelectedCellAddressText;
		private string sSelectedCellsIDList = "";

		public string _SelectedPackingIDList;
		public string _SelectedPackingAliasText;
		private string sSelectedPackingsIDList = "";

		public int? _SelectedID;
		public string _SelectedIDList;
		public string _SelectedText;

		private string sSelectedFixedGoodsStatesIDList = "";
		private string sSelectedFixedOwnersIDList = "";
		private string sSelectedFixedPackingsIDList = "";

		private string sSelectedStoresZonesIDList = "";
		private string sSelectedStoresZonesTypesIDList = "";

		// для спец.ячейки Lost&Found
		protected string sLostFoundAddress = null;
		protected int nLostFoundID = 0;


		public frmCells()
		{
			oCellList = new Cell();
			oCellCur = new Cell();
			if (oCellList.ErrorNumber != 0 ||
				oCellCur.ErrorNumber != 0)
			{
				IsValid = false;
			}
			else
			{
				oGood = new Good();
				oCellAddress = new Cell();
				oTrafficFrame = new TrafficFrame();
				if (oGood.ErrorNumber != 0 ||
					oCellAddress.ErrorNumber != 0 ||
					oTrafficFrame.ErrorNumber != 0)
				{
					IsValid = false;
				}
			}

			if (IsValid)
			{
				InitializeComponent();

				// для работы с виртуальной ячейкой Lost&Found
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
			}
		}

		private void frmCells_Load(object sender, EventArgs e)
		{
			RFMCursorWait.Set(true);

			bool lResult = 	cboPalletsTypes_Restore();
			if (!lResult)
			{
				RFMCursorWait.Set(false);
				RFMMessage.MessageBoxError("Ошибка при получении фильтров (ячейки)...");
				Dispose();
			}

			lResult = cboCBuilding_Restore() &&
						cboCLine_Restore() &&
						cboCLevel_Restore() &&
						cboCRack_Restore() &&
						cboCPlace_Restore();
			if (!lResult)
			{
				RFMCursorWait.Set(false);
				RFMMessage.MessageBoxError("Ошибка при заполнении существующих значений параметров адреса...");
				return;
			}

			grcBox.AgrType =
			grcPal.AgrType =
			grcQnt.AgrType =
			grcCellsHistoryBoxQnt.AgrType =
			grcCellsHistoryPalQnt.AgrType =
			grcCellsHistoryQnt.AgrType =
				EnumAgregate.Sum;

			btnClearTerms_Click(null, null);

			tcList.Init();

			txtBarCode.Select();

			RFMCursorWait.Set(false);
		}

		#region Tab Restore

		private bool tabTerms_Restore()
		{
			btnAddSpecial.Enabled =
			btnAddRange.Enabled =
			btnEdit.Enabled =
			btnFixedEdit.Enabled =
			btnGeometryEdit.Enabled =
			btnMedication.Enabled =
			btnDelete.Enabled =
			btnPrint.Enabled =
			btnService.Enabled = false;
			txtBarCode.Select();
			return true;
		}

		private bool tabCells_Restore()
		{
			grdData_Restore();
			btnAddSpecial.Enabled =
			btnAddRange.Enabled =
			btnPrint.Enabled = true;

			if (grdData.Rows.Count > 0)
			{
				//btnEdit.Enabled = false;
				//btnDelete.Enabled = false;
				//btnFixedEdit.Enabled =
				//btnGeometryEdit.Enabled =
				//btnMedication.Enabled =
				//btnService.Enabled = true;
				btnEdit.Enabled = 
				btnFixedEdit.Enabled = 
				btnGeometryEdit.Enabled = 
				btnMedication.Enabled = 
				btnDelete.Enabled = 
				btnService.Enabled = true;
			}
			else
			{
				btnEdit.Enabled =
				btnFixedEdit.Enabled =
				btnGeometryEdit.Enabled =
				btnMedication.Enabled =
				btnDelete.Enabled =
				btnService.Enabled = false;
			}

			grdData.Select();
			return true;
		}

		private void tcList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tcList.SelectedTab.Name.ToUpper().Contains("TERMS"))
			{
				btnAddSpecial.Enabled =
				btnAddRange.Enabled =
				btnEdit.Enabled =
				btnFixedEdit.Enabled =
				btnGeometryEdit.Enabled =
				btnMedication.Enabled =
				btnDelete.Enabled =
				btnPrint.Enabled =
				btnService.Enabled = false;
			}

			if (tcList.SelectedTab.Name.ToUpper().Contains("CELLS"))
			{
				grdData.Select();

				if (grdData.Rows.Count > 0 && grdData.CurrentRow != null)
				{
					btnPrint.Enabled =
					btnService.Enabled =
						true;
				
					if (!tabCells.IsNeedRestore)
					{
						if (!grdData.IsStatusRow(grdData.CurrentRow.Index))
						{
							tmrRestore_Tick(null, null);
						}
					}
				}
			}
		}

		#region Bottom Tab Restore

		private bool tabCellsContents_Restore()
		{
			return grdCellsContents_Restore();
		}

		private bool tabCellsHistory_Restore()
		{
			return grdCellsHistory_Restore();
		}

		private bool tabCellsTraffics_Restore()
		{
			return grdCellsTraffics_Restore();
		}

		#endregion Bottom Tab Restore

		#region empty Tab Restore

		private bool tabTermsCurState_Restore()
		{
			return (true);
		}

		private bool tabTermsGeometry_Restore()
		{
			return (true);
		}

		private bool tabTermsHistory_Restore()
		{
			return (true);
		}

		private bool tabTermsDateValid_Restore()
		{
			return (true);
		}

		#endregion empty Tab Restore

		#endregion Tab Restore

		#region Prepare IDList

		public void CellPrepareIDList(Cell oCell, bool bMultiSelect)
		{
			oCell.ID = null;
			oCell.IDList = null;
			int? nCellID = 0;
			if (bMultiSelect && grdData.IsCheckerShow)
			{
				oCell.IDList = "";

				DataView dMarked = new DataView(oCellList.MainTable);
				dMarked.RowFilter = "IsMarked = true";
				dMarked.Sort = grdData.GridSource.Sort;
				foreach (DataRowView r in dMarked)
				{
					if (!Convert.IsDBNull(r["ID"]))
					{
						nCellID = (int)r["ID"];
						if (nCellID == nLostFoundID)
						{
							RFMMessage.MessageBoxError("Виртуальная ячейка " + sLostFoundAddress + " не может быть обработана!");
							nCellID = -100;
						}
						oCell.IDList = oCell.IDList + nCellID.ToString() + ",";
					}
				}
			}
			else
			{
				nCellID = (int?)grdData.CurrentRow.Cells["grcID"].Value;
				if (nCellID.HasValue)
				{
					if (nCellID == nLostFoundID)
					{
						RFMMessage.MessageBoxError("Виртуальная ячейка " + sLostFoundAddress + " не может быть обработана!");
						nCellID = -100;
					}
					oCell.ID = nCellID;
				}
			}
		}

		public int CalcMarkedRows()
		{
			int nCnt = 0;
			if (grdData.IsCheckerShow)
			{
				DataView dMarked = new DataView(oCellList.MainTable);
				dMarked.RowFilter = "IsMarked = true";
				nCnt = dMarked.Count;
			}
			return (nCnt);
		}

		#endregion Prepare IDList

		#region Buttons

		private void btnEdit_Click(object sender, EventArgs e)
		{
			if (grdData.CurrentRow == null) // нет данных в grid
				return;
			if (grdData.IsStatusRow(grdData.CurrentRow.Index)) // это итоговая строка 
				return;

			int? nCellID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			if (!nCellID.HasValue) // ID is null
				return;
			if (nCellID == nLostFoundID) // это ячейка Lost&Found
			{
				RFMMessage.MessageBoxError("Виртуальная ячейка " + sLostFoundAddress + " не может быть обработана!");
				return;
			}

			Cell oCellAddress = new Cell();
			oCellAddress.ID = (int)nCellID;
			oCellAddress.FillData();
			if (oCellAddress.MainTable.Rows.Count == 0)
				return;

			if (StartForm(new frmCellsAddressEdit(oCellAddress)) == DialogResult.Yes)
			{
				grdData_Restore();
			}
		}

		private void btnFixedEdit_Click(object sender, EventArgs e)
		{
			if (grdData.CurrentRow == null)
				return;
			if (grdData.IsStatusRow(grdData.CurrentRow.Index))
				return;

			Cell oCellFixed = new Cell();
			int nMarkedCnt = CalcMarkedRows();
			if (nMarkedCnt > 0 &&
				RFMMessage.MessageBoxYesNo("Отмечено записей: " + nMarkedCnt.ToString() + "\r\n" +
						"Изменить фиксированные закрепления для всех отмеченных ячеек?") != DialogResult.Yes)
				return;

			WaitOn(this);
			CellPrepareIDList(oCellFixed, nMarkedCnt > 0);
			oCellFixed.FillData();
			WaitOff(this);
			if (oCellFixed.MainTable.Rows.Count == 0)
				return;


			if (StartForm(new frmCellsFixedEdit(oCellFixed)) == DialogResult.Yes)
			{
				grdData_Restore();
			}
		}

		private void btnGeometryEdit_Click(object sender, EventArgs e)
		{
			if (grdData.CurrentRow == null)
				return;

			if (grdData.IsStatusRow(grdData.CurrentRow.Index))
				return;

			Cell oCellGeometry = new Cell();
			int nMarkedCnt = CalcMarkedRows();
			if (nMarkedCnt > 0 &&
				RFMMessage.MessageBoxYesNo("Отмечено записей: " + nMarkedCnt.ToString() + "\r\n" +
						"Изменить параметры для всех отмеченных ячеек?") != DialogResult.Yes)
				return;

			WaitOn(this);
			CellPrepareIDList(oCellGeometry, nMarkedCnt > 0);
			oCellGeometry.FillData();
			WaitOff(this);
			if (oCellGeometry.MainTable.Rows.Count == 0)
				return;

			if (StartForm(new frmCellsGeometryEdit(oCellGeometry)) == DialogResult.Yes)
			{
				grdData_Restore();
			}
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (grdData.CurrentRow == null)
				return;
			if (grdData.IsStatusRow(grdData.CurrentRow.Index))
				return;

			Cell oCellDelete = new Cell();
			int nMarkedCnt = CalcMarkedRows();
			if (nMarkedCnt > 0)
			{
				if (RFMMessage.MessageBoxYesNo("Отмечено записей: " + nMarkedCnt.ToString() + "\r\n" +
						"Удалить все (только пустые) отмеченные ячейки?") != DialogResult.Yes)
					return;
			}

			WaitOn(this);
			CellPrepareIDList(oCellDelete, nMarkedCnt > 0);
			oCellDelete.FillData();
			WaitOff(this);
			if (oCellDelete.MainTable.Rows.Count == 0)
				return;

			if (StartForm(new frmCellsDelete(oCellDelete)) == DialogResult.Yes)
			{
				grdData_Restore();
			}
		}

		private void btnAddSpecial_Click(object sender, EventArgs e)
		{
			if (StartForm(new frmCellsAddSpecial()) == DialogResult.Yes)
			{
				int nCellID = (int)GotParam.GetValue(0);
				grdData_Restore();
				if (nCellID > 0)
				{
					grdData.GridSource.Position = grdData.GridSource.Find(oCellList.ColumnID, nCellID);
				}
			}
		}

		private void btnAddRange_Click(object sender, EventArgs e)
		{
			if (StartForm(new frmCellsAddRange()) == DialogResult.Yes)
			{
				grdData_Restore();
			}
		}

		#region Medication

		private void btnMedication_Click(object sender, EventArgs e)
		{
			if (grdData.CurrentRow == null)
				return;
			if (grdData.IsStatusRow(grdData.CurrentRow.Index))
				return;

			int? nCellID = Convert.ToInt32(grdData.CurrentRow.Cells["grcID"].Value);
			if (!nCellID.HasValue)
				return;
			if (nCellID == nLostFoundID)
			{
				RFMMessage.MessageBoxError("Виртуальная ячейка " + sLostFoundAddress + " не может быть обработана!");
				return;
			}

			// ячейки для контейнеров или для товаров россыпью?
			bool? bForFrames = null;
			bool? bGoodsMono = null;

			DataRow r = oCellList.MainTable.Rows.Find(nCellID);
			if (r == null)
			{
				return;
			}
			if (r["ForFrames"] != DBNull.Value)
			{
				bForFrames = (bool)r["ForFrames"];
			}
			if (r["GoodsMono"] != DBNull.Value)
			{
				bGoodsMono = (bool)r["GoodsMono"];
			}

			bool bResult = false;
			if (bForFrames == null)
			{
				mnuMedication.Show(btnMedication, new Point());
			}
			else
			{
				if ((bool)bForFrames)
				{
					bResult = CellsMedicationFrames((int)nCellID);
					grdData_Restore();
				}
				else
				{
					mnuMedication.Show(btnMedication, new Point());
					/*
					if (bGoodsMono != null && (bool)bGoodsMono)
					{
						bResult = CellsMedicationNotFrames((int)nCellID);
					}
					else
					{
						bResult = CellsMassMedicationNotFrames((int)nCellID);
					}
					*/ 
				}
			}
		}

		private void mniMedicationForFrames_Click(object sender, EventArgs e)
		{
			int nCellID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			if (CellsMedicationFrames(nCellID))
			{
				grdData_Restore();
			}
		}

		private void mniMedicationNotFrames_Click(object sender, EventArgs e)
		{
			int nCellID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			if (CellsMedicationNotFrames(nCellID))
			{
				grdData_Restore();
			}
		}

		private void mniMassMedicationNotFrames_Click(object sender, EventArgs e)
		{
			int nCellID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			if (CellsMassMedicationNotFrames(nCellID))
			{
				grdData_Restore();
			}
		}

		private bool CellsMedicationFrames(int nCellID)
		{
			Cell oCellTemp = new Cell();
			oCellTemp.ID = nCellID;
			oCellTemp.FillData();
			if (oCellTemp.ErrorNumber != 0 || oCellTemp.MainTable == null || oCellTemp.MainTable.Rows.Count != 1)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о ячейке...");
				return (false);
			}
			// для ячейки вместимостью 1 контейнер проверим наличие невыполненных транспортировок в ячейку / из ячейки
			DataRow cr = oCellTemp.MainTable.Rows[0];
			if (!Convert.IsDBNull(cr["MaxPalletQnt"]) && Convert.ToInt32(cr["MaxPalletQnt"]) == 1)
			{
				TrafficFrame oTrafficTemp = new TrafficFrame();
				oTrafficTemp.FilterConfirmed = false;

				oTrafficTemp.FilterCellsSourceList = nCellID.ToString();
				oTrafficTemp.FillData();
				if (oTrafficTemp.ErrorNumber != 0 || oTrafficTemp.MainTable == null)
				{
					RFMMessage.MessageBoxError("Ошибка при получении данных о транспортировках из ячейки...");
					return (false);
				}
				if (oTrafficTemp.MainTable.Rows.Count > 0)
				{
					DataRow r = oTrafficTemp.MainTable.Rows[0];
					RFMMessage.MessageBoxError("Существуют невыполненные транспортировки из ячейки " + r["CellSourceAddress"].ToString() + "\n" +
						"(контейнер с кодом " + r["FrameID"].ToString() + ").\n\n" +
						"Исправление состояния ячейки невозможно.");
					return (false);
				}

				oTrafficTemp.FilterCellsSourceList = null;
				oTrafficTemp.FilterCellsTargetList = nCellID.ToString();
				oTrafficTemp.FillData();
				if (oTrafficTemp.ErrorNumber != 0 || oTrafficTemp.MainTable == null)
				{
					RFMMessage.MessageBoxError("Ошибка при получении данных о транспортировках в ячейки...");
					return (false);
				}
				if (oTrafficTemp.MainTable.Rows.Count > 0)
				{
					DataRow r = oTrafficTemp.MainTable.Rows[0];
					RFMMessage.MessageBoxError("Существуют невыполненные транспортировки в ячейку " + r["CellTargetAddress"].ToString() + "\n" +
						"(контейнер с кодом " + r["FrameID"].ToString() + ").\n\n" +
						"Исправление состояния ячейки невозможно.");
					return (false);
				}
			}

			return (StartForm(new frmCellsMedicationFrames((int)nCellID)) == DialogResult.Yes);
		}

		private bool CellsMedicationNotFrames(int nCellID)
		{
			return (StartForm(new frmCellsMedicationNotFrames((int)nCellID)) == DialogResult.Yes);
		}

		private bool CellsMassMedicationNotFrames(int nCellID)
		{
			return (StartForm(new frmCellsMassMedicationNotFrames((int)nCellID)) == DialogResult.Yes);
		}

		#endregion

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
				oCellCur.ID = 0;
				btnEdit.Enabled = 
				btnFixedEdit.Enabled = 
				btnGeometryEdit.Enabled = 
				btnMedication.Enabled = 
				btnDelete.Enabled = false;
				return;
			}
			else
			{
				oCellCur.ID = (int)grdData.Rows[rowIndex].Cells["grcID"].Value;
				bool bHasContent = (bool)grdData.Rows[rowIndex].Cells["grcHasCellContent"].Value;
				btnEdit.Enabled = 
				btnFixedEdit.Enabled = 
				btnDelete.Enabled = !bHasContent;
				btnGeometryEdit.Enabled = 
				btnMedication.Enabled = true;

			}

			tcCellsRelations.SetAllNeedRestore(true);
		}

		private void grdData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (grdData.DataSource == null) return;

			if (grdData.IsStatusRow(e.RowIndex))
			{
				if (grdData.Columns[e.ColumnIndex].Name.Contains("Image"))
				{
					e.Value = Properties.Resources.Empty;
				}
				return;
			}

			DataGridViewRow r = grdData.Rows[e.RowIndex];
			switch (grdData.Columns[e.ColumnIndex].Name)
			{
				case "grcCellStateImage":
					if ((bool)r.Cells["grcHasCellContent"].Value)
						e.Value = Properties.Resources.Box_full;
					else
						e.Value = Properties.Resources.Empty;
					break;
				case "grcCellFullImage":
					if ((bool)r.Cells["grcCellIsFull"].Value)
						e.Value = Properties.Resources.FolderClosed;
					else
						e.Value = Properties.Resources.Empty;
					break;
				case "grcLockedImage":
					if ((bool)r.Cells["grcLocked"].Value)
						e.Value = Properties.Resources.Lock1;
					else
						e.Value = Properties.Resources.Empty;
					break;
				case "grcForFrames":
					if (r.Cells["grcIsForFrames"].Value == DBNull.Value)
					{
						e.CellStyle.BackColor = Color.Silver;
						e.CellStyle.ForeColor = Color.Silver;
					}
					break;
				case "grcFixedPackingAlias":
					if (r.Cells["grcFixedGoodAndPackingActual"].Value != DBNull.Value && !(bool)r.Cells["grcFixedGoodAndPackingActual"].Value)
					{
						e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Italic);
						e.CellStyle.ForeColor = Color.Gray;
					}
					break;
			}
		}

		private void grdCellsContents_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			RFMDataGridView grd = ((RFMDataGridView)sender);
			if (grd.DataSource == null)
				return;

			if (grd.IsStatusRow(e.RowIndex))
			{
				switch (grd.Columns[e.ColumnIndex].Name)
				{
					case "grcQnt":
					case "grcInBox":
						e.CellStyle.Format = "### ### ### ###";
						break;
				}
				return;
			}

			DataGridViewRow r = grd.Rows[e.RowIndex];
			switch (grd.Columns[e.ColumnIndex].Name)
			{
				case "grcQnt":
				case "grcInBox":
					if (!Convert.IsDBNull(r.Cells["grcWeighting"].Value) &&
						Convert.ToBoolean(r.Cells["grcWeighting"].Value) ||
						!Convert.IsDBNull(e.Value) && Convert.ToDecimal(e.Value) != Convert.ToInt32(e.Value))
						e.CellStyle.Format = "### ### ### ##0.000";
					else
						e.CellStyle.Format = "### ### ### ###";
					break;
				case "grcGoodAlias":
					if (r.Cells["grcGoodAndPackingActual"].Value != DBNull.Value && !(bool)r.Cells["grcGoodAndPackingActual"].Value)
					{
						e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Italic);
						e.CellStyle.ForeColor = Color.Gray;
					}
					break;
			}
		}

		private void grdCellsHistory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			RFMDataGridView grd = ((RFMDataGridView)sender);
			if (grd.DataSource == null)
				return;

			if (grd.IsStatusRow(e.RowIndex))
			{
				switch (grd.Columns[e.ColumnIndex].Name)
				{
					case "grcCellsHistoryQnt":
					case "grcCellsHistoryInBox":
						e.CellStyle.Format = "### ### ### ###";
						break;
					case "grcCellsHistoryTypeImage":
					case "grcCellsHistoryProblemImage":
						e.Value = Properties.Resources.Empty;
						break;
				}
				return;
			}

			DataGridViewRow r = grd.Rows[e.RowIndex];
			switch (grd.Columns[e.ColumnIndex].Name)
			{
				case "grcCellsHistoryTypeImage":
					switch ((string)r.Cells["grcCellsHistoryOperationType"].Value)
					{
						case "I":
							e.Value = Properties.Resources.Plus;
							break;
						case "O":
							e.Value = Properties.Resources.Minus;
							break;
						case "S":
							e.Value = Properties.Resources.Medication;
							break;
						default:
							e.Value = Properties.Resources.Empty;
							break;
					}
					break;
				case "grcCellsHistoryProblemImage":
					if ((bool)r.Cells["grcCellsHistoryProblem"].Value)
						e.Value = Properties.Resources.Exclamation;
					else
						e.Value = Properties.Resources.Empty;
					break;
				case "grcCellsHistoryQnt":
				case "grcCellsHistoryInBox":
					if (!Convert.IsDBNull(r.Cells["grcCellsHistoryWeighting"].Value) &&
						Convert.ToBoolean(r.Cells["grcCellsHistoryWeighting"].Value) ||
						!Convert.IsDBNull(e.Value) && Convert.ToDecimal(e.Value) != Convert.ToInt32(e.Value))
						e.CellStyle.Format = "### ### ### ##0.000";
					else
						e.CellStyle.Format = "### ### ### ###";
					break;
			}
		}

		private void grdCellsTraffics_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			RFMDataGridView grd = ((RFMDataGridView)sender);
			if (grd.DataSource == null)
				return;

			if (grd.IsStatusRow(e.RowIndex))
			{
				switch (grd.Columns[e.ColumnIndex].Name)
				{
					case "grcTrafficsImage":
					case "grcTrafficsConfirmedImage":
						e.Value = Properties.Resources.Empty;
						break;
				}
				return;
			}

			DataGridViewRow r = grd.Rows[e.RowIndex];
			switch (grd.Columns[e.ColumnIndex].Name)
			{
				case "grcTrafficsImage":
					if (oCellCur.ID == Convert.ToInt32(r.Cells["grcTrafficsCellSourceID"].Value))
					{
						e.Value = Properties.Resources.Minus;
					}
					else
					{
						if (oCellCur.ID == Convert.ToInt32(r.Cells["grcTrafficsCellTargetID"].Value))
						{
							e.Value = Properties.Resources.Plus;
						}
						else
						{
							e.Value = Properties.Resources.Empty;
						}
					}
					break;
				case "grcTrafficsConfirmedImage":
					if (grd.Rows[e.RowIndex].Cells["grcTrafficsDateConfirm"].Value.ToString().Length == 0)
						e.Value = Properties.Resources.Empty;
					else
						if ((bool)grd.Rows[e.RowIndex].Cells["grcTrafficsSuccess"].Value)
							e.Value = Properties.Resources.Check;
						else
							e.Value = Properties.Resources.CheckRed;
					break;

			}

			if ((grd.Columns[e.ColumnIndex].Name.Contains("Height") ||
				 grd.Columns[e.ColumnIndex].Name.Contains("Weight")) &&
				 grd.Columns[e.ColumnIndex].DefaultCellStyle.Format.Contains("N"))
			{
				if (Convert.IsDBNull(e.Value) || Convert.ToDecimal(e.Value) == 0)
				{
					e.Value = "";
				}
			}
		}

		#endregion

		#region Restore

		private bool cboCBuilding_Restore()
		{
			oCellAddress.FillAddressPartTables("CBuilding");
			cboCBuilding.ValueMember = oCellAddress.TableAddressPartCBuilding.Columns[0].Caption;
			cboCBuilding.DisplayMember = oCellAddress.TableAddressPartCBuilding.Columns[1].Caption;
			cboCBuilding.DataSource = oCellAddress.TableAddressPartCBuilding;
			return (oCellAddress.ErrorNumber == 0);
		}
		private bool cboCLine_Restore()
		{
			oCellAddress.FillAddressPartTables("CLine");
			cboCLine.ValueMember = oCellAddress.TableAddressPartCLine.Columns[0].Caption;
			cboCLine.DisplayMember = oCellAddress.TableAddressPartCLine.Columns[1].Caption;
			cboCLine.DataSource = oCellAddress.TableAddressPartCLine;
			return (oCellAddress.ErrorNumber == 0);
		}
		private bool cboCRack_Restore()
		{
			oCellAddress.FillAddressPartTables("CRack");
			cboCRack.ValueMember = oCellAddress.TableAddressPartCRack.Columns[0].Caption;
			cboCRack.DisplayMember = oCellAddress.TableAddressPartCRack.Columns[1].Caption;
			cboCRack.DataSource = new DataView(oCellAddress.TableAddressPartCRack);
			return (oCellAddress.ErrorNumber == 0);
		}
		private bool cboCLevel_Restore()
		{
			oCellAddress.FillAddressPartTables("CLevel");
			cboCLevel.ValueMember = oCellAddress.TableAddressPartCLevel.Columns[0].Caption;
			cboCLevel.DisplayMember = oCellAddress.TableAddressPartCLevel.Columns[1].Caption;
			cboCLevel.DataSource = new DataView(oCellAddress.TableAddressPartCLevel);
			return (oCellAddress.ErrorNumber == 0);
		}
		private bool cboCPlace_Restore()
		{
			oCellAddress.FillAddressPartTables("CPlace");
			cboCPlace.ValueMember = oCellAddress.TableAddressPartCPlace.Columns[0].Caption;
			cboCPlace.DisplayMember = oCellAddress.TableAddressPartCPlace.Columns[1].Caption;
			cboCPlace.DataSource = new DataView(oCellAddress.TableAddressPartCPlace);
			return (oCellAddress.ErrorNumber == 0);
		}

		private bool cboPalletsTypes_Restore()
		{
			oGood.FillTablePalletsTypes();
			cboPalletsTypes.ValueMember = oGood.TablePalletsTypes.Columns[0].Caption;
			cboPalletsTypes.DisplayMember = oGood.TablePalletsTypes.Columns[1].Caption;
			cboPalletsTypes.DataSource = new DataView(oGood.TablePalletsTypes);
			return (oGood.ErrorNumber == 0);
		}


		private bool grdData_Restore()
		{
			RFMCursorWait.Set(true);
			RFMCursorWait.LockWindowUpdate(FindForm().Handle);

			oCellCur.ID = null;

			oCellList.ClearError();
			oCellList.ClearFilters();
			oCellList.ID = null;
			oCellList.IDList = null;

			// собираем условия

			// штрих-код
			if (txtBarCode.Text.Trim().Length > 0)
			{
				oCellList.BarCode = txtBarCode.Text.Trim();
			}

			// закрепление: хранители
			if (sSelectedFixedOwnersIDList.Length > 0)
			{
				oCellList.FilterFixedOwnersList = sSelectedFixedOwnersIDList;
			}

			// закрепление: состояния товара
			if (sSelectedFixedGoodsStatesIDList.Length > 0)
			{
				oCellList.FilterFixedGoodsStatesList = sSelectedFixedGoodsStatesIDList;
			}

			// закрепление: товары
			if (sSelectedFixedPackingsIDList.Length > 0)
			{
				oCellList.FilterFixedPackingsList = sSelectedFixedPackingsIDList;
			}

			// зоны
			if (sSelectedStoresZonesIDList.Length > 0)
			{
				oCellList.FilterStoresZonesList = sSelectedStoresZonesIDList;
			}
			if (sSelectedStoresZonesTypesIDList.Length > 0)
			{
				oCellList.FilterStoresZonesTypesList = sSelectedStoresZonesTypesIDList;
			}

			// адрес
			if (txtAddress.Text.Trim().Length > 0)
			{
				if (chkAddressContext.Checked)
				{
					oCellList.FilterAddressContext = txtAddress.Text.Trim();
				}
				else
				{
					oCellList.FilterAddress = txtAddress.Text.Trim();
				}
			}
			if (txtCBuilding.Text.Trim().Length > 0)
			{
				oCellList.FilterCBuilding = txtCBuilding.Text.Trim();
			}
			if (txtCLine.Text.Trim().Length > 0)
			{
				oCellList.FilterCLine = txtCLine.Text.Trim();
			}
			if (txtCRack.Text.Trim().Length > 0)
			{
				oCellList.FilterCRack = txtCRack.Text.Trim();
			}
			if (txtCLevel.Text.Trim().Length > 0)
			{
				oCellList.FilterCLevel = txtCLevel.Text.Trim();
			}
			if (txtCPlace.Text.Trim().Length > 0)
			{
				oCellList.FilterCPlace = txtCPlace.Text.Trim();
			}

			// блокированные?
			if (optLockedYes.Checked)
			{
				oCellList.FilterLocked = true;
			}
			if (optLockedNo.Checked)
			{
				oCellList.FilterLocked = false;
			}

			// актуальные?
			/*
			if (optActual_Any.Checked)
			{
				if (grdData.IsActualOnly)
				{
					oCellList.FilterActual = true;
				}
			}
			*/ 
			if (optActualYes.Checked)
			{
				//grdData.IsActualOnly = true;
				oCellList.FilterActual = true;
			}
			if (optActualNo.Checked)
			{
				//grdData.IsActualOnly = false;
				oCellList.FilterActual = false;
			}

			// для контейнеров/коробок?
			if (optForFrames.Checked)
			{
				oCellList.FilterForFrames = true;
			}
			if (optForGoods.Checked)
			{
				oCellList.FilterForFrames = false;
			}

			// выбранные ячейки
			if (sSelectedCellsIDList.Length > 0)
			{
				oCellList.IDList = sSelectedCellsIDList;
			}

			// состояние ячеек
			if (optCell_Empty.Checked)
			{
				oCellList.FilterHasCellContent = false;
			}
			if (optCell_NotEmpty.Checked)
			{
				oCellList.FilterHasCellContent = true;
			}
			if (optCell_Full.Checked)
			{
				oCellList.FilterHasCellContent = true;
				oCellList.FilterIsFull = true;
			}
			if (optCell_NotFull.Checked)
			{
				oCellList.FilterHasCellContent = true;
				oCellList.FilterIsFull = false;
			}
			// по наличию невып.транспортировок
			if (optTrafficsToYes.Checked)
			{
				oCellList.FilterTrafficsToExists = true;
			}
			if (optTrafficsToNo.Checked)
			{
				oCellList.FilterTrafficsToExists = false;
			}
			if (optTrafficsFromYes.Checked)
			{
				oCellList.FilterTrafficsFromExists = true;
			}
			if (optTrafficsFromNo.Checked)
			{
				oCellList.FilterTrafficsFromExists = false;
			}

			// выбранные товары -  в ячейках
			if (sSelectedPackingsIDList.Length > 0)
			{
				oCellList.CellsContents_FilterPackingsList = sSelectedPackingsIDList;
			}

			// геометрия
			if (!nurMaxWeight.nudBegSpinner.IsEmpty && nurMaxWeight.nudBegSpinner.Value > 0)
			{
				oCellList.FilterMaxWeightBeg = nurMaxWeight.nudBegSpinner.Value;
			}
			if (!nurMaxWeight.nudEndSpinner.IsEmpty && nurMaxWeight.nudEndSpinner.Value > 0)
			{
				oCellList.FilterMaxWeightEnd = nurMaxWeight.nudEndSpinner.Value;
			}
			if (!nurCellHeight.nudBegSpinner.IsEmpty && nurCellHeight.nudBegSpinner.Value > 0)
			{
				oCellList.FilterCellHeightBeg = nurCellHeight.nudBegSpinner.Value;
			}
			if (!nurCellHeight.nudEndSpinner.IsEmpty && nurCellHeight.nudEndSpinner.Value > 0)
			{
				oCellList.FilterCellHeightEnd = nurCellHeight.nudEndSpinner.Value;
			}
			if (!nurCellWidth.nudBegSpinner.IsEmpty && nurCellWidth.nudBegSpinner.Value > 0)
			{
				oCellList.FilterCellWidthBeg = nurCellWidth.nudBegSpinner.Value;
			}
			if (!nurCellWidth.nudEndSpinner.IsEmpty && nurCellWidth.nudEndSpinner.Value > 0)
			{
				oCellList.FilterCellWidthEnd = nurCellWidth.nudEndSpinner.Value;
			}
			if (cboPalletsTypes.SelectedValue != null && cboPalletsTypes.SelectedIndex >= 0)
			{
				oCellList.FilterPalletsTypesList = cboPalletsTypes.SelectedValue.ToString();
			}

			// сроки годности
			if (optDateValidLost.Checked)
			{
				oCellList.CellsContents_FilterCheckDateValid = -1;
			}
			if (optDateValidMore.Checked)
			{
				oCellList.CellsContents_FilterCheckDateValid = -2;
			}
			if (optDateValidPercent.Checked)
			{
				oCellList.CellsContents_FilterCheckDateValid = Convert.ToInt32(numDateValidPercent.Value);
			}

			// собрали условия

			grdCellsContents.DataSource = null;
			grdCellsHistory.DataSource = null;
			grdCellsTraffics.DataSource = null;
			grdData.GetGridState(); 
			
			oCellList.FillData();

			grdData.IsLockRowChanged = true;
			grdData.Restore(oCellList.MainTable);

			// сюда можно добавить условия, которых нет в бизнес-объекте
			grdData.GridSource.Filter = "1 = 1";
			if (optBufferCell_Yes.Checked)
			{
				grdData.GridSource.Filter = grdData.GridSource.Filter + " and IsNull(BufferCellID, 0) > 0 or IsNull(ID, 0) = 0";
			}
			if (optBufferCell_No.Checked)
			{
				grdData.GridSource.Filter = grdData.GridSource.Filter + " and IsNull(BufferCellID, 0) = 0 or IsNull(ID, 0) = 0";
			}

			tmrRestore.Enabled = true;

			RFMCursorWait.LockWindowUpdate(IntPtr.Zero);
			RFMCursorWait.Set(false);

			return (oCellList.ErrorNumber == 0);
		}

		private bool grdCellsContents_Restore()
		{
			grdCellsContents.GetGridState(); 
			grdCellsContents.DataSource = null;
			if (grdData.Rows.Count == 0 ||
				oCellCur.ID == null ||
				grdData.CurrentRow != null && grdData.IsStatusRow(grdData.CurrentRow.Index))
				return (true);

			oCellList.ClearError();
			oCellList.FillTableCellsContents((int)oCellCur.ID, false);

			if (chkShowSelectedGoodsOnly.Enabled && chkShowSelectedGoodsOnly.Checked &&
				sSelectedPackingsIDList != null && sSelectedPackingsIDList.Length > 0)
			{
				DataTable dt = CopyTable(oCellList.TableCellsContents, "dt",
					"PackingID in (" + RFMPublic.RFMUtilities.NormalizeList(sSelectedPackingsIDList) + ")",
					"CellBarCode, GoodAlias, CellID");
				oCellList.TableCellsContents.Clear();
				oCellList.TableCellsContents.Merge(dt);
			}

			grdCellsContents.Restore(oCellList.TableCellsContents);

			return (oCellList.ErrorNumber == 0);
		}

		private bool grdCellsHistory_Restore()
		{
			grdCellsHistory.GetGridState(); 
			grdCellsHistory.DataSource = null;
			if (grdData.Rows.Count == 0 ||
				oCellCur.ID == null ||
				grdData.CurrentRow != null && grdData.IsStatusRow(grdData.CurrentRow.Index))
				return (true);

			oCellList.ClearError();
			oCellList.ClearCellsHistoryFilters();
			
			if (!dtrCellsHistoryDatesDates.dtpBegDate.IsEmpty)
			{
				oCellList.CellsHistory_FilterDateBeg = dtrCellsHistoryDatesDates.dtpBegDate.Value.Date;
			}
			if (!dtrCellsHistoryDatesDates.dtpEndDate.IsEmpty)
			{
				oCellList.CellsHistory_FilterDateEnd = dtrCellsHistoryDatesDates.dtpEndDate.Value.Date;
			}

			RFMCursorWait.Set(true);

			oCellList.FillTableCellsHistory((int)oCellCur.ID);

			if (chkShowSelectedGoodsOnly.Enabled && chkShowSelectedGoodsOnly.Checked &&
				sSelectedPackingsIDList != null && sSelectedPackingsIDList.Length > 0)
			{
				DataTable dt = CopyTable(oCellList.TableCellsHistory, "dt",
					"PackingID in (" + RFMPublic.RFMUtilities.NormalizeList(sSelectedPackingsIDList) + ")",
					"CellID, DateOper desc");
				oCellList.TableCellsHistory.Clear();
				oCellList.TableCellsHistory.Merge(dt);
			}
			
			grdCellsHistory.Restore(oCellList.TableCellsHistory);

			RFMCursorWait.Set(false);

			return (oCellList.ErrorNumber == 0);
		}

		private bool grdCellsTraffics_Restore()
		{
			grdCellsTraffics.GetGridState(); 
			grdCellsTraffics.DataSource = null;
			if (grdData.Rows.Count == 0 ||
				oCellCur.ID == null ||
				grdData.CurrentRow != null && grdData.IsStatusRow(grdData.CurrentRow.Index))
				return (true);

			oTrafficFrame.ClearError();
			oTrafficFrame.ClearFilters();

			if (!dtrCellsHistoryDatesDates.dtpBegDate.IsEmpty)
			{
				oTrafficFrame.FilterDateBeg = dtrCellsHistoryDatesDates.dtpBegDate.Value.Date;
			}
			if (!dtrCellsHistoryDatesDates.dtpEndDate.IsEmpty)
			{
				oTrafficFrame.FilterDateEnd = dtrCellsHistoryDatesDates.dtpEndDate.Value.Date;
			}
			oTrafficFrame.FilterCellsTargetList = null;
			oTrafficFrame.FilterCellsSourceList = oCellCur.ID.ToString();
			oTrafficFrame.FillData();
			DataTable tableTraffics = oTrafficFrame.MainTable.Copy();
			oTrafficFrame.FilterCellsSourceList = null;
			oTrafficFrame.FilterCellsTargetList = oCellCur.ID.ToString();
			oTrafficFrame.FillData();
			tableTraffics.Merge(oTrafficFrame.MainTable);
			
			grdCellsTraffics.Restore(tableTraffics);
			
			return (oTrafficFrame.ErrorNumber == 0);
		}

		#endregion

		#region Составляющие адреса

		private void cboCBuilding_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtCBuilding.Text = cboCBuilding.Text;
		}

		private void cboCLine_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtCLine.Text = cboCLine.Text;
		}

		private void cboCRack_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtCRack.Text = cboCRack.Text;
		}

		private void cboCLevel_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtCLevel.Text = cboCLevel.Text;
		}

		private void cboCPlace_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtCPlace.Text = cboCPlace.Text;
		}

		#endregion

		#region Filters

		#region FixedGoodsStates

		private void btnFixedGoodsStatesChoose_Click(object sender, EventArgs e)
		{
			_SelectedIDList = null;
			_SelectedText = "";

			GoodState oGoodState = new GoodState();
			oGoodState.FillData();
			if (oGoodState.ErrorNumber != 0 || oGoodState.MainTable == null)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о состояниях товаров...");
				return;
			}
			if (oGoodState.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Нет данных о состояниях товаров...");
				return;
			}

			if (StartForm(new frmSelectID(this, oGoodState.MainTable, "Name", "Состояние товара", true)) == DialogResult.Yes)
			{
				if (_SelectedIDList == null || !_SelectedIDList.Contains(","))
				{
					btnFixedGoodsStatesClear_Click(null, null);
					return;
				}

				sSelectedFixedGoodsStatesIDList = "," + _SelectedIDList;

				txtFixedGoodsStatesChoosen.Text = _SelectedText;
				ttToolTip.SetToolTip(txtFixedGoodsStatesChoosen, txtFixedGoodsStatesChoosen.Text);

				tabCells.IsNeedRestore = true;
			}

			_SelectedIDList = null;
			_SelectedText = "";
		}

		private void btnFixedGoodsStatesClear_Click(object sender, EventArgs e)
		{
			tabCells.IsNeedRestore = true;

			ttToolTip.SetToolTip(txtFixedGoodsStatesChoosen, "не выбраны");
			sSelectedFixedGoodsStatesIDList = "";
			txtFixedGoodsStatesChoosen.Text = "";
		}

		#endregion FixedGoodsStates

		#region FixedOwners

		private void btnFixedOwnersChoose_Click(object sender, EventArgs e)
		{
			_SelectedIDList = null;
			_SelectedText = "";

			Partner oOwner = new Partner();
			oOwner.FillDataOwners();
			if (oOwner.ErrorNumber != 0 || oOwner.MainTable == null)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о хранителях...");
				return;
			}
			if (oOwner.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Нет данных о хранителях...");
				return;
			}

			if (StartForm(new frmSelectID(this, oOwner.MainTable, "Name,Actual", "Владелец,Акт.", true)) == DialogResult.Yes)
			{
				if (_SelectedIDList == null || !_SelectedIDList.Contains(","))
				{
					btnFixedOwnersClear_Click(null, null);
					return;
				}

				sSelectedFixedOwnersIDList = "," + _SelectedIDList;

				txtFixedOwnersChoosen.Text = _SelectedText;
				ttToolTip.SetToolTip(txtFixedOwnersChoosen, txtFixedOwnersChoosen.Text);

				tabCells.IsNeedRestore = true;
			}

			_SelectedIDList = null;
			_SelectedText = "";
		}

		private void btnFixedOwnersClear_Click(object sender, EventArgs e)
		{
			tabCells.IsNeedRestore = true;

			ttToolTip.SetToolTip(txtFixedOwnersChoosen, "не выбраны");
			sSelectedFixedOwnersIDList = "";
			txtFixedOwnersChoosen.Text = "";
		}

		#endregion FixedOwners

		#region FixedPackings

		private void btnFixedPackingsChoose_Click(object sender, EventArgs e)
		{
			_SelectedPackingIDList = null;
			_SelectedPackingAliasText = "";

			if (StartForm(new frmSelectOnePacking(this, true)) == DialogResult.Yes)
			{
				if (_SelectedPackingIDList == null || !_SelectedPackingIDList.Contains(","))
				{
					btnFixedPackingsClear_Click(null, null);
					return;
				}

				sSelectedFixedPackingsIDList = "," + _SelectedPackingIDList;

				txtFixedPackingsChoosen.Text = _SelectedPackingAliasText;
				ttToolTip.SetToolTip(txtFixedPackingsChoosen, txtFixedPackingsChoosen.Text);

				tabCells.IsNeedRestore = true;
			}

			_SelectedPackingIDList = null;
			_SelectedPackingAliasText = "";
		}

		private void btnFixedPackingsClear_Click(object sender, EventArgs e)
		{
			tabCells.IsNeedRestore = true;

			ttToolTip.SetToolTip(txtFixedPackingsChoosen, "не выбраны");
			sSelectedFixedPackingsIDList = "";
			txtFixedPackingsChoosen.Text = "";
		}

		#endregion FixedPackings

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

				tabCells.IsNeedRestore = true;
			}

			_SelectedCellsIDList = null;
			_SelectedCellAddressText = "";
		}

		private void btnCellsClear_Click(object sender, EventArgs e)
		{
			tabCells.IsNeedRestore = true;

			ttToolTip.SetToolTip(txtCellsChoosen, "не выбраны");
			sSelectedCellsIDList = "";
			txtCellsChoosen.Text = "";
		}

		#endregion Cells

		#region StoresZones

		private void btnStoresZonesChoose_Click(object sender, EventArgs e)
		{
			_SelectedIDList = null;
			_SelectedText = "";

			StoreZone oStoreZone = new StoreZone();
			oStoreZone.FillData();
			if (oStoreZone.ErrorNumber != 0 || oStoreZone.MainTable == null)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о зонах склада...");
				return;
			}
			if (oStoreZone.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Нет данных о зонах склада...");
				return;
			}

			if (StartForm(new frmSelectID(this, oStoreZone.MainTable, "Name,Actual", "Зона склада,Акт.", true)) == DialogResult.Yes)
			{
				if (_SelectedIDList == null || !_SelectedIDList.Contains(","))
				{
					btnStoresZonesClear_Click(null, null);
					return;
				}

				sSelectedStoresZonesIDList = "," + _SelectedIDList;

				txtStoresZonesChoosen.Text = _SelectedText;
				ttToolTip.SetToolTip(txtStoresZonesChoosen, txtStoresZonesChoosen.Text);

				tabCells.IsNeedRestore = true;
			}

			_SelectedIDList = null;
			_SelectedText = "";
		}

		private void btnStoresZonesClear_Click(object sender, EventArgs e)
		{
			tabCells.IsNeedRestore = true;

			ttToolTip.SetToolTip(txtStoresZonesChoosen, "не выбраны");
			sSelectedStoresZonesIDList = "";
			txtStoresZonesChoosen.Text = "";
		}

		#endregion StoresZones

		#region StoresZonesTypes

		private void btnStoresZonesTypesChoose_Click(object sender, EventArgs e)
		{
			_SelectedIDList = null;
			_SelectedText = "";

			StoreZone oStoreZone = new StoreZone();
			oStoreZone.FillTableStoresZonesTypes();
			if (oStoreZone.ErrorNumber != 0 || oStoreZone.TableStoresZonesTypes == null)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о типах зон склада...");
				return;
			}
			if (oStoreZone.TableStoresZonesTypes.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Нет данных о типах зон склада...");
				return;
			}

			if (StartForm(new frmSelectID(this, oStoreZone.TableStoresZonesTypes, "Name", "Тип скл.зоны", true)) == DialogResult.Yes)
			{
				if (_SelectedIDList == null || !_SelectedIDList.Contains(","))
				{
					btnStoresZonesTypesClear_Click(null, null);
					return;
				}

				sSelectedStoresZonesTypesIDList = "," + _SelectedIDList;

				txtStoresZonesTypesChoosen.Text = _SelectedText;
				ttToolTip.SetToolTip(txtStoresZonesTypesChoosen, txtStoresZonesTypesChoosen.Text);

				tabCells.IsNeedRestore = true;
			}

			_SelectedIDList = null;
			_SelectedText = "";
		}

		private void btnStoresZonesTypesClear_Click(object sender, EventArgs e)
		{
			tabCells.IsNeedRestore = true;

			ttToolTip.SetToolTip(txtStoresZonesTypesChoosen, "не выбраны");
			sSelectedStoresZonesTypesIDList = "";
			txtStoresZonesTypesChoosen.Text = "";
		}

		#endregion StoresZonesTypes

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

				tabCells.IsNeedRestore = true;
			}

			_SelectedPackingIDList = null;
			_SelectedPackingAliasText = "";
		}

		private void btnPackingsClear_Click(object sender, EventArgs e)
		{
			tabCells.IsNeedRestore = true;

			chkShowSelectedGoodsOnly.Checked =
			chkShowSelectedGoodsOnly.Enabled =
				false;

			ttToolTip.SetToolTip(txtPackingsChoosen, "не выбраны");
			sSelectedPackingsIDList = "";
			txtPackingsChoosen.Text = "";
		}

		#endregion Packings

		private void optDateValidPercent_CheckedChanged(object sender, EventArgs e)
		{
			numDateValidPercent.Enabled = optDateValidPercent.Checked;
		}

		#endregion

		#region текстовые поля - фильтры

		private void txtText_TextChanged(object sender, EventArgs e)
		{
			RFMTextBox txtField = (RFMTextBox)sender;
			txtField.Text = txtField.Text.ToUpper();
			txtField.Select(txtField.Text.Length, 0);
		}

		#endregion

		#region Menu Print

		private void btnPrint_Click(object sender, EventArgs e)
		{
			switch (tcList.SelectedTab.Name)
			{
				case "tabCells":
					mnuPrint.Show(btnPrint, new Point());
					break;
				default:
					break;
			}
		}

		private void btnPrint_MouseClick(object sender, MouseEventArgs e)
		{
			switch (tcList.SelectedTab.Name)
			{
				case "tabCells":
					mnuPrint.Show(btnPrint, new Point(e.X, e.Y));
					break;
				default:
					break;
			}
		}

		private void mniPrintBarCodeLabel_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			// список ячеек
			Cell oCellBCL = new Cell();
			int nMarkedCnt = CalcMarkedRows();
			if (nMarkedCnt > 0 &&
				RFMMessage.MessageBoxYesNo("Отмечено записей: " + nMarkedCnt.ToString() + "\r\n" +
						"Формировать этикетки для всех отмеченных записей?") != DialogResult.Yes)
				return;

			Refresh();
			WaitOn(this);
			CellPrepareIDList(oCellBCL, nMarkedCnt > 0);
			oCellBCL.FillData();
			WaitOff(this);
			if (oCellBCL.MainTable.Rows.Count == 0)
				return;

			StartForm(new frmBarCodeLabelPrint(this, oCellBCL.MainTable, "CL", "Zebra"));
		}

		private void mniPrintCellLabel_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			repCellLabel rd = new repCellLabel();
			PrintCellLabel((DataDynamics.ActiveReports.ActiveReport3)rd);
		}

		private void mniPrintCellLabelA4_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			repCellLabelA4 rd = new repCellLabelA4();
			PrintCellLabel((DataDynamics.ActiveReports.ActiveReport3)rd);
		}

		private void PrintCellLabel(DataDynamics.ActiveReports.ActiveReport3 rpReport)
		{
			Cell oCellLabel = new Cell();
			int nMarkedCnt = CalcMarkedRows();
			if (nMarkedCnt > 0 &&
				RFMMessage.MessageBoxYesNo("Отмечено записей: " + nMarkedCnt.ToString() + "\r\n" +
						"Формировать этикетки для всех отмеченных записей?") != DialogResult.Yes)
				return;

			Refresh();
			WaitOn(this);
			CellPrepareIDList(oCellLabel, nMarkedCnt > 0);
			oCellLabel.FillData();
			WaitOff(this);
			if (oCellLabel.MainTable.Rows.Count == 0)
				return;

			// печать 
			StartForm(new frmActiveReport(oCellLabel.MainTable, rpReport));
		}

		private void mniPrintReportFixedErrors_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			Cell oCellReport = new Cell();
			oCellReport.ReportFixedErrors();
			repCellsFixedErrors rd = new repCellsFixedErrors();
			StartForm(new frmActiveReport(oCellReport.TableReport, rd));
		}

		private void mniPrintOldCellsContents_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			// Получение данных о "старых" паллетах
			WaitOn(this);
			OldCellsContents oOldCellsContents = new OldCellsContents();
			oOldCellsContents.FillData();

			repOldCellsContents rd = new repOldCellsContents();
			WaitOff(this);

			if (oOldCellsContents.MainTable.Rows.Count > 0)
				StartForm(new frmActiveReport(oOldCellsContents.MainTable, rd));
			else
			{
				MessageBox.Show("Нет данных о старых паллетах!\r\nОбратитесь к администратору!", "Внимание");
				return;
			}
		}

		private void mniPrintCellsContentsList_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			WaitOn(this);
			Cell oCellReport = new Cell();
			oCellReport.IDList = "";
			foreach (DataGridViewRow gr in grdData.Rows)
			{
				oCellReport.IDList += gr.Cells["grcID"].Value.ToString().Trim() + ",";
			}
			WaitOff(this);
			if (oCellReport.IDList.Length == 0 || !oCellReport.IDList.Contains(","))
				return;

			oCellReport.FillTableCellsContentsList(oCellReport.IDList);
 
			StartForm(new frmSelectID(this, oCellReport.TableCellsContents,
                "Address, OwnerName, GoodStateName, GoodAlias, InBox#3, BoxQnt#1, Qnt#3, QntNetto#3, DateValidText, DateValidPercent#1, IsCalcDateValid, FrameBarCode, Cost#2",
				"Адрес, Владелец, Состояние, Товар, В кор., Кол-во кор., Кол-во шт./кг, Нетто, Срок.годн., % СГ, Расч. СГ, ШК контейнера, Себестоимость", 
				"Содержимое ячеек"));
		}

        private void mniPrintCellsFreeOccupied_Click(object sender, EventArgs e)
        {
            RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

            WaitOn(this);
            Cell oCellReport = new Cell();
            oCellReport.IDList = "";
            foreach (DataGridViewRow gr in grdData.Rows)
            {
                oCellReport.IDList += gr.Cells["grcID"].Value.ToString().Trim() + ",";
            }
            WaitOff(this);
            if (oCellReport.IDList.Length == 0 || !oCellReport.IDList.Contains(","))
                return;

            if (oCellReport.ReportCellsFreeOccupied(oCellReport.IDList))
            {
                StartForm(new frmBrowse(oCellReport.TableReport, "Отчет о заполненности ячеек"));
            }
            else
            {
                MessageBox.Show("Нет данных о заполненности ячеек!", "Внимание");
                return;
            }
        }

        #endregion

		#region Menu Service

		private void btnService_Click(object sender, EventArgs e)
		{
			switch (tcList.SelectedTab.Name)
			{
				case "tabCells":
					mnuService.Show(btnService, new Point());
					break;
				default:
					break;
			}
		}

		private void btnService_MouseClick(object sender, MouseEventArgs e)
		{
			switch (tcList.SelectedTab.Name)
			{
				case "tabCells":
					mnuService.Show(btnService, new Point(e.X, e.Y));
					break;
				default:
					break;
			}
		}

		private void mniCellLock_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			CellLock(true);
		}

		private void mniCellUnLock_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			CellLock(false);
		}

        private void mniCellNote_Click(object sender, EventArgs e)
        {
            if (grdData.CurrentRow == null)
                return;

            if (grdData.IsStatusRow(grdData.CurrentRow.Index))
                return;

            Cell oCellNote = new Cell();
            int nMarkedCnt = CalcMarkedRows();

            WaitOn(this);
            CellPrepareIDList(oCellNote, nMarkedCnt > 0);
            oCellNote.FillData();
            WaitOff(this);
            if (oCellNote.MainTable.Rows.Count == 0)
                return;

            if (StartForm(new frmCellsNoteEdit(oCellNote)) == DialogResult.Yes)
            {
                grdData_Restore();
            }
        }

        private bool CellLock(bool bLock)
		{
			if (grdData.CurrentRow == null)
				return (false);

			if (grdData.IsStatusRow(grdData.CurrentRow.Index))
				return (false);

			int nMarkedCnt = CalcMarkedRows();
			if (nMarkedCnt == 0 || !grdData.IsCheckerShow)
			{
				// одна ячейка
				bool bLockOld = (bool)grdData.CurrentRow.Cells["grcLocked"].Value;
				if (bLockOld && bLock)
				{
					RFMMessage.MessageBoxInfo("Ячейка уже блокирована.");
					return (false);
				}
				if (!bLockOld && !bLock)
				{
					RFMMessage.MessageBoxInfo("Ячейка не была блокирована.");
					return (false);
				}

				oCellCur.ClearError();
				oCellCur.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
				oCellCur.SetLock(oCellCur.ID, bLock);
				if (oCellCur.ErrorNumber == 0)
					RFMMessage.MessageBoxInfo("Ячейка " + (!bLock ? "раз" : "") + "блокирована.");
			}
			else
			{
				// несколько ячеек 
				if (RFMMessage.MessageBoxYesNo("Отмечено записей: " + nMarkedCnt.ToString() + "\r\n" +
						"Изменить блокировку для всех отмеченных ячеек?") != DialogResult.Yes)
					return (false);

				WaitOn(this);
				DataView dMarked = new DataView(oCellList.MainTable);
				dMarked.RowFilter = "IsMarked = true";
				foreach (DataRowView r in dMarked)
				{
					if (!Convert.IsDBNull(r["ID"]))
					{
						oCellCur.ClearError();
						oCellCur.ID = (int)r["ID"];
						oCellCur.SetLock(oCellCur.ID, bLock);
						if (oCellCur.ErrorNumber != 0)
							break;
					}
				}
				WaitOff(this);
			}
			grdData_Restore();
			return (oCellCur.ErrorNumber == 0);
		}


		private void mniCellActual_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			CellActual(true);
		}

		private void mniCellNotActual_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			CellActual(false);
		}

		private bool CellActual(bool bActual)
		{
			if (grdData.CurrentRow == null)
				return (false);

			if (grdData.IsStatusRow(grdData.CurrentRow.Index))
				return (false);

			int nMarkedCnt = CalcMarkedRows();

			if (nMarkedCnt == 0 || !grdData.IsCheckerShow)
			{
				// одна ячейка
				bool bActualOld = (bool)grdData.CurrentRow.Cells["grcActual"].Value;
				if (bActualOld && bActual)
				{
					RFMMessage.MessageBoxInfo("Ячейка является актуальной.");
					return (false);
				}
				if (!bActualOld && !bActual)
				{
					RFMMessage.MessageBoxInfo("Ячейка не является актуальной.");
					return (false);
				}

				oCellCur.ClearError();
				oCellCur.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
				oCellCur.SetActual(oCellCur.ID, bActual);
				if (oCellCur.ErrorNumber == 0)
					RFMMessage.MessageBoxInfo("Ячейка " + (!bActual ? "не" : "") + " актуальна.");
			}
			else
			{
				// несколько ячеек 
				if (RFMMessage.MessageBoxYesNo("Отмечено записей: " + nMarkedCnt.ToString() + "\r\n" +
						"Изменить актуальность для всех отмеченных ячеек?") != DialogResult.Yes)
					return (false);

				WaitOn(this);
				DataView dMarked = new DataView(oCellList.MainTable);
				dMarked.RowFilter = "IsMarked = true";
				foreach (DataRowView r in dMarked)
				{
					if (!Convert.IsDBNull(r["ID"]))
					{
						oCellCur.ClearError();
						oCellCur.ID = (int)r["ID"];
						oCellCur.SetActual(oCellCur.ID, bActual);
						if (oCellCur.ErrorNumber != 0)
							break;
					}
				}
				WaitOff(this);
			}
			grdData_Restore();
			return (oCellCur.ErrorNumber == 0);
		}

		private void mniSetBufferCell_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.CurrentRow == null)
				return;

			if (grdData.IsStatusRow(grdData.CurrentRow.Index))
				return;

			Cell oCellBuf = new Cell();
			string sShortCode = "";
			string sAddress = "";
			int nCellID = 0;
			int nMarkedCnt = CalcMarkedRows();
			if (nMarkedCnt == 0 || !grdData.IsCheckerShow)
			{
				// одна ячейка
				nCellID = (int)grdData.CurrentRow.Cells["grcID"].Value;
				DataRow r = (DataRow)oCellList.MainTable.Rows.Find(nCellID);
				if (r != null)
				{
					sShortCode = r["StoreZoneTypeShortCode"].ToString();
					if (sShortCode.Contains("BUF"))
					{
						sAddress = r["Address"].ToString();
						RFMMessage.MessageBoxError("Ячейка с кодом " + nCellID.ToString() + " (" + sAddress + ") сама является буферной.");
						return;
					}
					oCellBuf.ID = nCellID;
				}
			}
			else
			{
				if (RFMMessage.MessageBoxYesNo("Отмечено записей: " + nMarkedCnt.ToString() + "\r\n" +
						  "Установить буферную ячейку для всех отмеченных ячеек?") == DialogResult.Yes)
				{
					WaitOn(this);
					string sShortCodeOld = "";
					oCellBuf.IDList = "";

					DataView dMarked = new DataView(oCellList.MainTable);
					dMarked.RowFilter = "IsMarked = true";
					foreach (DataRowView r in dMarked)
					{
						if (!Convert.IsDBNull(r["ID"]))
						{
							nCellID = (int)r["ID"];
							DataRow rd = (DataRow)oCellList.MainTable.Rows.Find(nCellID);
							sShortCode = rd["StoreZoneTypeShortCode"].ToString();
							if (sShortCodeOld.Length > 0 && sShortCode != sShortCodeOld)
							{
								RFMMessage.MessageBoxError("Отмечены ячейки из разных типов зон!\nОбщая буферная ячейка не может быть назначена...");
								return;
							}
							else
							{
								if (sShortCode.Contains("BUF"))
								{
									sAddress = rd["Address"].ToString();
									RFMMessage.MessageBoxError("Ячейка с кодом " + nCellID.ToString() + " (" + sAddress + ") сама является буферной.");
								}
								else
								{
									oCellBuf.IDList = oCellBuf.IDList + nCellID.ToString() + ",";
									sShortCodeOld = sShortCode;
								}
							}
						}
						WaitOff(this);
					}
				}
				else
				{
					// только для текущей
					if (RFMMessage.MessageBoxYesNo("Установить буферную ячейку только для текущей ячейки?") == DialogResult.Yes)
					{
						nCellID = (int)grdData.CurrentRow.Cells["grcID"].Value;
						DataRow r = (DataRow)oCellList.MainTable.Rows.Find(nCellID);
						if (r != null)
						{
							sShortCode = r["StoreZoneTypeShortCode"].ToString();
							if (sShortCode.Contains("BUF"))
							{
								sAddress = r["Address"].ToString();
								RFMMessage.MessageBoxError("Ячейка с кодом " + nCellID.ToString() + " (" + sAddress + ") сама является буферной.");
								return;
							}
							oCellBuf.ID = nCellID;
						}
					}
					else
					{
						return;
					}
				}
			}
			oCellBuf.FillData();
			if (oCellBuf.MainTable.Rows.Count == 0)
				return;

			if (StartForm(new frmCellsBuffer(oCellBuf)) == DialogResult.Yes)
				grdData_Restore();

			return;
		}

		private void mniServiceNewFrameCollect_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.CurrentRow == null)
				return;

			if (grdData.IsStatusRow(grdData.CurrentRow.Index))
				return;

			if ((int)grdData.CurrentRow.Cells["grcID"].Value == nLostFoundID)
			{
				RFMMessage.MessageBoxError("Виртуальная ячейка " + sLostFoundAddress + " не может быть обработана!");
				return;
			}

			oCellCur.ClearError();
			oCellCur.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			oCellCur.FillData();
			if (oCellCur.ErrorNumber != 0 || oCellCur.MainTable.Rows.Count == 0)
				return;
			// исходная ячейка должна позволять размещение коробок (чтобы было что собирать)
			if (oCellCur.MainTable.Rows[0]["ForFrames"] != DBNull.Value && Convert.ToBoolean(oCellCur.MainTable.Rows[0]["ForFrames"]))
			{
				RFMMessage.MessageBoxError("Ячейка предназначена для контейнеров...");
				return;
			}

			// список содержимого ячейки
			oCellCur.FillTableCellsContents((int)oCellCur.ID, false);
			if (oCellCur.ErrorNumber != 0)
				return;

			DataTable tCellContent = oCellCur.TableCellsContents.Clone();
			foreach (DataRow r in oCellCur.TableCellsContents.Rows)
			{
				if (r["FrameID"] == DBNull.Value && Convert.ToDecimal(r["Qnt"]) > 0)
				{
					tCellContent.ImportRow(r);
				}
			}
			if (tCellContent.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("В ячейке нет товаров, которые можно собрать в контейнер...");
				return;
			}

			if (StartForm(new frmCellsNewFrameCollect((int)oCellCur.ID, tCellContent)) == DialogResult.Yes)
			{
				grdData_Restore();
			}
			return;
		}

		private void mniUnMarkIsFull_Click(object sender, EventArgs e)
		{
			if (grdData.CurrentRow == null)
				return;
			DataGridViewRow drCell = grdData.CurrentRow;
			string cAddress = drCell.Cells["grcAddress"].Value.ToString().Trim();

			if ((bool)drCell.Cells["grcCellIsFull"].Value == false)
			{
				RFMMessage.MessageBoxInfo("Ячейка " + cAddress + " не отмечена как заполненная...");
				return;
			}
			if (RFMMessage.MessageBoxYesNo("Снять признак заполненности с ячейки " + cAddress + "?") == DialogResult.Yes)
			{
				oCellCur.UnMarkCellIsFull((int)drCell.Cells["grcID"].Value);
				if (oCellCur.ErrorNumber == 0)
				{
					RFMMessage.MessageBoxInfo("Признак заполненности с ячейки " + cAddress + " снят");
					grdData_Restore();
				}

			}
		}

		private void mniServiceTrafficFrameCreate_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			bool bReturn = false;
			if (tcList.CurrentPage.Name.ToUpper() != tabCells.Name.ToUpper())
				bReturn = true;
			if (!bReturn &&
				lastGrid.Name.ToUpper() != grdCellsContents.Name.ToUpper())
				bReturn = true;
			if (!bReturn &&
				(grdData.DataSource == null ||
				grdData.Rows.Count == 0 ||
				grdData.CurrentRow == null ||
				grdData.IsStatusRow(grdData.CurrentRow.Index)))
				bReturn = true;
			if (!bReturn &&
				(tcCellsRelations.CurrentPage != null &&
				tcCellsRelations.CurrentPage.Name.ToUpper() != tabCellsContents.Name.ToUpper()))
				bReturn = true;
			if (!bReturn &&
				(grdCellsContents.DataSource == null ||
				grdCellsContents.Rows.Count == 0 ||
				grdCellsContents.CurrentRow == null ||
				grdCellsContents.IsStatusRow(grdCellsContents.CurrentRow.Index)))
				bReturn = true;
			if (!bReturn &&
				(grdCellsContents.CurrentRow.Cells["grcFrameID"].Value == null ||
				grdCellsContents.CurrentRow.Cells["grcFrameID"].Value == DBNull.Value))
				bReturn = true;
			if (bReturn)
			{
				RFMMessage.MessageBoxError("Для вызова операции перейдите в нижнюю таблицу на странице [Содержимое] и установите активную строку на запись о контейнере.");
				return;
			}

			int nFrameID = Convert.ToInt32(grdCellsContents.CurrentRow.Cells["grcFrameID"].Value);
			TrafficFrame oTrafficTemp = new TrafficFrame();
			oTrafficTemp.FilterFramesList = nFrameID.ToString();
			oTrafficTemp.FilterConfirmed = false;
			oTrafficTemp.FillData();
			if (oTrafficTemp.ErrorNumber != 0)
				return;
			if (oTrafficTemp.MainTable.Rows.Count > 0)
			{
				RFMMessage.MessageBoxError("Для контейнера с кодом " + nFrameID.ToString() + " существуют невыполненные операции транспортировки...");
				return;
			}

			if (StartForm(new frmTrafficsFramesManual(nFrameID)) == DialogResult.Yes)
			{
				grdData_Restore();
			}
		}

		private void mniCellFixedChange_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.CurrentRow == null)
				return;
			if (grdData.IsStatusRow(grdData.CurrentRow.Index))
				return;

			oCellCur.ClearError();
			oCellCur.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			oCellCur.FillData();
			if (oCellCur.ErrorNumber != 0 || oCellCur.MainTable.Rows.Count == 0)
				return;

			DataRow c = oCellCur.MainTable.Rows[0];
			if (Convert.IsDBNull(c["FixedPackingID"]))
			{
				RFMMessage.MessageBoxError("Ячейка не имеет закрепления за товаром...");
				return;
			}
			if (!Convert.ToBoolean(c["ForStorage"]) || !Convert.ToBoolean(c["ForPicking"]))
			{
				RFMMessage.MessageBoxError("Ячейка имеет другой тип...");
				return;
			}

			if (StartForm(new frmCellsFixedChanges(null, (int)oCellCur.ID)) == DialogResult.Yes)
			{
				grdData_Restore();
			}
			return;
		}

		private void mniCellReorder_Click(object sender, EventArgs e)
		{
			StartForm(new frmCellsReorder());
		}

		#endregion

		#region Terms clear

		private void btnClearTerms_Click(object sender, EventArgs e)
		{
			txtBarCode.Text = "";
			txtAddress.Text = "";
			txtCBuilding.Text = "";
			txtCLine.Text = "";
			txtCRack.Text = "";
			txtCLevel.Text = "";
			txtCPlace.Text = "";

			cboCBuilding.SelectedIndex = -1;
			cboCLine.SelectedIndex = -1;
			cboCRack.SelectedIndex = -1;
			cboCLevel.SelectedIndex = -1;
			cboCPlace.SelectedIndex = -1;

			_SelectedCellsIDList = null;
			_SelectedPackingIDList = null;
			_SelectedID = null;

			btnCellsClear_Click(null, null);
			btnStoresZonesClear_Click(null, null);
			btnStoresZonesTypesClear_Click(null, null);

			btnFixedGoodsStatesClear_Click(null, null);
			btnFixedOwnersClear_Click(null, null);
			btnFixedPackingsClear_Click(null, null);

			btnPackingsClear_Click(null, null);

			//optActual_Any.Checked = true;
			optActualYes.Checked = true;
			//optLocked_any.Checked = true;
			optLockedNo.Checked = true;

			optForAny.Checked = true;

			// тек.состояние 
			optCell_All.Checked = true;
			optTrafficsFromAny.Checked = true;
			optTrafficsToAny.Checked = true;

			// геометрия
			nurMaxWeight.nudBegSpinner.Value = nurMaxWeight.nudEndSpinner.Value = 0;
			nurCellHeight.nudBegSpinner.Value = nurCellHeight.nudEndSpinner.Value = 0;
			nurCellWidth.nudBegSpinner.Value = nurCellWidth.nudEndSpinner.Value = 0;
			cboPalletsTypes.SelectedIndex = -1;
			optBufferCell_Any.Checked = true;

			// срок годн.
			optDateValidAny.Checked = true;
			optDateValidPercent_CheckedChanged(null, null);

			// история
			dtrCellsHistoryDatesDates.dtpBegDate.Value = DateTime.Now.Date.AddMonths(-3);
			dtrCellsHistoryDatesDates.dtpEndDate.Value = DateTime.Now.Date;

			if (Control.ModifierKeys == Keys.Shift)
			{
				optActual_Any.Checked = true;
				optLocked_any.Checked = true;
			}

			oCellList.ClearFilters();
			oCellList.ClearError();

			tabCells.IsNeedRestore = true;
		}

		#endregion

	}
}