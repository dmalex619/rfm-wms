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
	public partial class frmFrames: RFMFormChild
	{
		private Frame oFrameList;
		private Frame oFrameCur;

		// для фильтров
		private Good oGood;
		private TrafficFrame oTrafficFrame;

		public int? _SelectedID;
		public string _SelectedIDList;
		public string _SelectedText;

		private string sSelectedGoodsStatesIDList = "";
		private string sSelectedOwnersIDList = "";

		public string _SelectedPackingIDList;
		public string _SelectedPackingAliasText;
		private string sSelectedPackingsIDList = "";

		public string _SelectedCellsIDList;
		public string _SelectedCellAddressText;
		private string sSelectedCellsIDList = "";

		
		public frmFrames()
		{
			oFrameList = new Frame();
			oFrameCur = new Frame();
			if (oFrameList.ErrorNumber != 0 ||
				oFrameCur.ErrorNumber != 0)
			{
				IsValid = false;
			}
			else
			{
				oGood = new Good();
				oTrafficFrame = new TrafficFrame();
				if (oGood.ErrorNumber != 0 || 
					oTrafficFrame.ErrorNumber != 0)
				{
					IsValid = false;
				}
			}

			if (IsValid)
			{
				InitializeComponent();
			}
		}

		private void frmFrames_Load(object sender, EventArgs e)
		{
			RFMCursorWait.Set(true);

			bool lResult = cboPalletsTypes_Restore();
			if (!lResult)
			{
				RFMCursorWait.Set(false);
				RFMMessage.MessageBoxError("Ошибка при получении фильтров (контейнеры)...");
				Dispose();
			}

			grcQntFramesContents.AgrType = 
			grcBoxQntFramesContents.AgrType = 
			grcPalQntFramesContents.AgrType =
			grcFramesHistoryQnt.AgrType =
			grcFramesHistoryBoxQnt.AgrType = 
			grcFramesHistoryPalQnt.AgrType =
			grcFrameWeight.AgrType =  
			grcFrames_Qnt.AgrType = 
			grcFrames_BoxQnt.AgrType =  
				EnumAgregate.Sum;

			btnClearTerms_Click(null, null);
			
			tcList.Init();

			txtBarCode.Select();

			RFMCursorWait.Set(false);
		}

		#region Tab Restore

		private bool tabTerms_Restore()
		{
			btnAdd.Enabled = 
			btnEdit.Enabled = 
			btnMedication.Enabled = 
			btnDelete.Enabled = 
			btnGo.Enabled = 
			btnPrint.Enabled = 
			btnService.Enabled = false;
			txtBarCode.Select();
			return true;
		}

		private bool tabFrames_Restore()
		{
			grdData_Restore();
			btnAdd.Enabled = true;
			if (grdData.Rows.Count > 0)
			{
				btnPrint.Enabled =
				btnService.Enabled = true;
			}
			else
			{
				btnPrint.Enabled =
				btnService.Enabled = false;
			}
			grdData.Select();
			return true;
		}

		#region Bottom Tab Restore

		private bool tabFramesContents_Restore()
		{
			return grdFramesContents_Restore();
		}

		private bool tabFramesHistory_Restore()
		{
			return grdFramesHistory_Restore();
		}

		private bool tabFramesTraffics_Restore()
		{
			return grdFramesTraffics_Restore();
		}

		#endregion bottom Tab Restore

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

		#endregion empty Tab Restore

		#endregion Tab Restore

	#region Prepare IDList

		public void FramePrepareIDList(Frame oFrame, bool bMultiSelect)
		{
			oFrame.ID = null;
			oFrame.IDList = null;
			int? nFrameID = 0;
			if (bMultiSelect && grdData.IsCheckerShow)
			{
				oFrame.IDList = "";

				DataView dMarked = new DataView(oFrameList.MainTable);
				dMarked.RowFilter = "IsMarked = true";
				dMarked.Sort = grdData.GridSource.Sort;
				foreach (DataRowView r in dMarked)
				{
					if (!Convert.IsDBNull(r["ID"]))
					{
						nFrameID = (int)r["ID"];
						oFrame.IDList = oFrame.IDList + nFrameID.ToString() + ",";
					}
				}
			}
			else
			{
				oFrame.ID = Convert.ToInt32(grdData.CurrentRow.Cells["grcID"].Value);
			}
		}

		public int CalcMarkedRows()
		{
			int nCnt = 0;
			if (grdData.IsCheckerShow)
			{
				DataView dMarked = new DataView(oFrameList.MainTable);
				dMarked.RowFilter = "IsMarked = true";
				nCnt = dMarked.Count;
			}
			return (nCnt);
		}
	
	#endregion Prepare IDList 

	#region Buttons

		private void btnAdd_Click(object sender, EventArgs e)
		{
			// создание новых контейнеров и этикеток

			if (StartForm(new frmInputBoxNumeric("Укажите количество контейнеров:", 10)) == DialogResult.Yes)
			{
				Refresh();
				int cnt = Convert.ToInt32(GotParam[0]);
				if (cnt > 0)
				{
					Frame oNewFrames = new Frame();
					if (oNewFrames.AddFramesEmpty(cnt))
					{
						Refresh();
						// печать 
						StartForm(new frmBarCodeLabelPrint(this, oNewFrames.MainTable, "FR", "Zebra"));
						grdData_Restore();
					}
				}
			}
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			if (grdData.CurrentRow == null)
				return;
			if (grdData.IsStatusRow(grdData.CurrentRow.Index))
				return;

			Frame oFrameEdit = new Frame();
			int nMarkedCnt = CalcMarkedRows();
			if (nMarkedCnt > 0 &&
				RFMMessage.MessageBoxYesNo("Отмечено контейнеров: " + nMarkedCnt.ToString() + "\r\n" +
						"Изменить параметры для всех отмеченных контейнеров?") != DialogResult.Yes)
				return;

			Refresh();
			FramePrepareIDList(oFrameEdit, nMarkedCnt > 0);
			oFrameEdit.FillData();
			if (oFrameEdit.MainTable.Rows.Count == 0)
				return;

			if (StartForm(new frmFramesEdit(oFrameEdit)) == DialogResult.Yes)
			{
				grdData_Restore();
			}
		}

		private void btnMedication_Click(object sender, EventArgs e)
		{
			if (grdData.CurrentRow == null)
				return;
			if (grdData.IsStatusRow(grdData.CurrentRow.Index))
				return;

			oFrameCur.ID = Convert.ToInt32(grdData.CurrentRow.Cells["grcID"].Value);

			// нет ли невыполненных транспортировок?
			TrafficFrame oTrafficTemp = new TrafficFrame();
			oTrafficTemp.FilterFramesList = oFrameCur.ID.ToString();
			oTrafficTemp.FilterConfirmed = false;
			oTrafficTemp.FillData();
			if (oTrafficTemp.ErrorNumber != 0 || oTrafficTemp.MainTable == null)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о транспортировках контейнера...");
				return;
			}
			if (oTrafficTemp.MainTable.Rows.Count > 0)
			{
				DataRow r = oTrafficTemp.MainTable.Rows[0];
				RFMMessage.MessageBoxError("Для контейнера с кодом " + oFrameCur.ID.ToString() + " существуют невыполненные транспортировки\n" +
					"(из ячейки " + r["CellSourceAddress"].ToString() + " в ячейку " + r["CellTargetAddress"] + ").\n\n" +
					"Исправление состояния контейнера невозможно.");
				return;
			}

			if (StartForm(new frmFramesMedication(Convert.ToInt32(oFrameCur.ID))) == DialogResult.Yes)
			{
				grdData_Restore();
			}
		}

		private void btnGo_Click(object sender, EventArgs e)
		{
			if (grdData.CurrentRow == null)
				return;
			if (grdData.IsStatusRow(grdData.CurrentRow.Index))
				return;

			oFrameCur.ID = Convert.ToInt32(grdData.CurrentRow.Cells["grcID"].Value);

			MessageBox.Show("Не используется...\nКонтейнер " + oFrameCur.ID.ToString());
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (grdData.CurrentRow == null)
				return;
			if (grdData.IsStatusRow(grdData.CurrentRow.Index))
				return;

			Frame oFrameDelete = new Frame();
			int nMarkedCnt = CalcMarkedRows();
			if (nMarkedCnt > 0)
			{ 
				if (RFMMessage.MessageBoxYesNo("Отмечено контейнеров: " + nMarkedCnt.ToString() + "\r\n" +
						"Удалить все отмеченные контейнеры (только пустые)?") != DialogResult.Yes)
					return;
			}
			else 
			{
				if (RFMMessage.MessageBoxYesNo("Удалить контейнер с кодом " + grdData.CurrentRow.Cells["grcID"].Value.ToString().Trim() + "?") != DialogResult.Yes)
					return;
			}

			Refresh();
			FramePrepareIDList(oFrameDelete, nMarkedCnt > 0);
			oFrameDelete.FillData();
			if (oFrameDelete.MainTable.Rows.Count == 0)
				return;

			foreach (DataRow r in oFrameDelete.MainTable.Rows)
			{
				int nFrameID = Convert.ToInt32(r["ID"]);
				if (!Convert.IsDBNull(r["HasFrameContent"]) &&
					Convert.ToBoolean(r["HasFrameContent"]))
				{
					RFMMessage.MessageBoxError("Контейнер с кодом " + nFrameID.ToString() + " не пуст и не может быть удален...");
				}
				else
				{
					oFrameDelete.DeleteOne(nFrameID);
				}
			}
			grdData_Restore();
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
				btnService.Enabled = true;

			tabFramesContents.IsNeedRestore =
				tabFramesHistory.IsNeedRestore =
				tabFramesTraffics.IsNeedRestore = true;

			if (grdData.IsStatusRow(rowIndex))
			{
				oFrameCur.ID = 0;
				btnEdit.Enabled =
					btnGo.Enabled =
					btnMedication.Enabled =
					btnDelete.Enabled = false;
			}
			else
			{
				oFrameCur.ID = Convert.ToInt32(grdData.Rows[rowIndex].Cells["grcID"].Value);
				btnGo.Enabled = false; // не исп.
				btnEdit.Enabled =
				btnMedication.Enabled =
				btnDelete.Enabled = 
					true;
			}

			tcFramesRelations.SetAllNeedRestore(true);
		}

		private void grdData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (grdData.DataSource == null)
				return;

			if (grdData.IsStatusRow(e.RowIndex))
			{
				e.CellStyle.BackColor = Color.Silver;
				e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);

				switch (grdData.Columns[e.ColumnIndex].Name)
				{
					case "grcLockedImage":
					case "grcHasFrameContentImage":
					case "grcStereoImage":
						e.Value = Properties.Resources.Empty;
						break;
				}
				return;
			}

			DataGridViewRow r = grdData.Rows[e.RowIndex];
			switch (grdData.Columns[e.ColumnIndex].Name)
			{
				case "grcHasFrameContentImage":
					if (!Convert.IsDBNull(r.Cells["grcHasFrameContent"].Value) &&
						Convert.ToBoolean(r.Cells["grcHasFrameContent"].Value))
						e.Value = Properties.Resources.Box_open;
					else
						e.Value = Properties.Resources.Empty;
					break;
				case "grcLockedImage":
					if ((bool)r.Cells["grcLocked"].Value)
						e.Value = Properties.Resources.Lock1;
					else
						e.Value = Properties.Resources.Empty;
					break;
				case "grcStereoImage":
					if (!Convert.IsDBNull(r.Cells["grcStereo"].Value) &&
						Convert.ToBoolean(r.Cells["grcStereo"].Value))
						e.Value = Properties.Resources.Sum;
					else
						e.Value = Properties.Resources.Empty;
					break;
				case "grcFrames_InBox":
				case "grcFrames_Qnt":
					if (optMono.Checked)
					{
						if (!Convert.IsDBNull(r.Cells["grcFrames_Weighting"].Value) &&
							Convert.ToBoolean(r.Cells["grcFrames_Weighting"].Value) ||
							!Convert.IsDBNull(e.Value) && Convert.ToDecimal(e.Value) != Convert.ToInt32(e.Value))
							e.CellStyle.Format = "### ### ### ##0.000";
						else
							e.CellStyle.Format = "### ### ### ##0";
					}
					break;
			}

			if ((grdData.Columns[e.ColumnIndex].Name.Contains("Height") ||
				 grdData.Columns[e.ColumnIndex].Name.Contains("Weight")) &&
				grdData.Columns[e.ColumnIndex].DefaultCellStyle.Format.Contains("N"))
			{
				if (Convert.IsDBNull(e.Value) || Convert.ToDecimal(e.Value) == 0)
				{
					e.Value = "";
				}
			}
		}

		private void grdFramesContents_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			RFMDataGridView grd = ((RFMDataGridView)sender); 
			if (grd.DataSource == null)
				return;

			if (grd.IsStatusRow(e.RowIndex))
			{
				e.CellStyle.BackColor = Color.Silver;
				e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);

				switch (grd.Columns[e.ColumnIndex].Name)
				{
					case "grcQntFramesContents":
					case "grcInBox":
						e.CellStyle.Format = "### ### ### ###";
						break;
				}
				return;
			}

			DataGridViewRow r = grd.Rows[e.RowIndex];
			switch (grd.Columns[e.ColumnIndex].Name)
			{
				case "grcQntFramesContents":
				case "grcInBox":
					if (!Convert.IsDBNull(r.Cells["grcFramesContentsWeighting"].Value) &&
						Convert.ToBoolean(r.Cells["grcFramesContentsWeighting"].Value) ||
						!Convert.IsDBNull(e.Value) && Convert.ToDecimal(e.Value) != Convert.ToInt32(e.Value))
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

		private void grdFramesHistory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			RFMDataGridView grd = ((RFMDataGridView)sender);
			if (grd.DataSource == null)
				return;

			if (grd.IsStatusRow(e.RowIndex))
			{
				e.CellStyle.BackColor = Color.Silver;
				e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);

				switch (grd.Columns[e.ColumnIndex].Name)
				{
					case "grcFramesHistoryQnt":
					case "grcFramesHistoryInBox":
						e.CellStyle.Format = "### ### ### ###";
						break;
					case "grcFramesHistoryTypeImage":
					case "grcFramesHistoryProblemImage":
						e.Value = Properties.Resources.Empty;
						break;
				}
				return;
			}

			DataGridViewRow r = grd.Rows[e.RowIndex];
			switch (grd.Columns[e.ColumnIndex].Name)
			{
				case "grcFramesHistoryTypeImage":
					switch ((string)r.Cells["grcFramesHistoryOperationType"].Value)
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
				case "grcFramesHistoryProblemImage":
					if (!Convert.IsDBNull(r.Cells["grcFramesHistoryProblem"].Value) && 
						Convert.ToBoolean(r.Cells["grcFramesHistoryProblem"].Value))
						e.Value = Properties.Resources.Exclamation;
					else
						e.Value = Properties.Resources.Empty;
					break;
				case "grcFramesHistoryQnt":
				case "grcFramesHistoryInBox":
					if (!Convert.IsDBNull(r.Cells["grcFramesHistoryWeighting"].Value) &&
						Convert.ToBoolean(r.Cells["grcFramesHistoryWeighting"].Value) ||
						!Convert.IsDBNull(e.Value) && Convert.ToDecimal(e.Value) != Convert.ToInt32(e.Value))
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

		private void grdFramesTraffics_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			RFMDataGridView grd = ((RFMDataGridView)sender);
			if (grd.DataSource == null)
				return;

			if (grd.IsStatusRow(e.RowIndex))
			{
				switch (grd.Columns[e.ColumnIndex].Name)
				{
					case "grcTrafficsConfirmedImage":
						e.Value = Properties.Resources.Empty;
						break;
				}
				return;
			}

			DataGridViewRow r = grd.Rows[e.RowIndex];
			switch (grd.Columns[e.ColumnIndex].Name)
			{
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

			oFrameCur.ID = null;

			oFrameList.ClearError();
			oFrameList.ClearFilters();
			oFrameList.ClearFramesContentsFilters();
			oFrameList.ID = null;
			oFrameList.IDList = null; 

			// собираем условия

			// штрих-код
			if (txtBarCode.Text.Trim().Length > 0)
			{
				oFrameList.BarCode = txtBarCode.Text.Trim();
			}
            // ID прихода
            if (txtInputID.Text.Trim().Length > 0)
            {
                int inputID;
                if (Int32.TryParse(txtInputID.Text.Trim(), out inputID)) oFrameList.FilterInputID = inputID;
                else oFrameList.FilterInputID = null;
            }
            else oFrameList.FilterInputID = null;
            // состояния товара
            if (sSelectedGoodsStatesIDList.Length > 0)
            {
                oFrameList.FilterGoodsStatesList = sSelectedGoodsStatesIDList;
            }
			// хранители
			if (sSelectedOwnersIDList.Length > 0)
			{
				oFrameList.FilterOwnersList = sSelectedOwnersIDList;
			}

			// актуальность 
			/*
			if (optActual_Any.Checked)
			{
				if (grdData.IsActualOnly)
				{
					oFrameList.FilterActual = true;
				}
			}
			*/ 
			if (optActualYes.Checked)
			{
				//grdData.IsActualOnly = true;
				oFrameList.FilterActual = true;
			}
			if (optActualNo.Checked)
			{
				//grdData.IsActualOnly = false;
				oFrameList.FilterActual = false;
			}
			// блокированные?
			if (optLockedYes.Checked)
			{
				oFrameList.FilterLocked = true;
			}
			if (optLockedNo.Checked)
			{
				oFrameList.FilterLocked = false;
			}

			// выбранные ячейки
			if (sSelectedCellsIDList.Length > 0)
			{
				oFrameList.FramesContents_FilterCellsList = sSelectedCellsIDList;
			}

			// состояние контейнеров
			if (optFrameI.Checked)
			{
				oFrameList.FilterFramesStatesStr = "I";
			}
			if (optFrameT.Checked)
			{
				oFrameList.FilterFramesStatesStr = "T";
			}
			if (optFrameS.Checked)
			{
				oFrameList.FilterFramesStatesStr = "S";
			}
			if (optFrame_.Checked)
			{
				oFrameList.FilterFramesStatesStr = " ";
			}

			// содержимое (моно-стерео) 
			if (optMono.Checked)
			{
				oFrameList.FilterStereo = false;
				// показать колонки
				grcFrames_DateValid.Visible =
				grcFrames_BoxQnt.Visible =
				grcFrames_GoodAlias.Visible =
				grcFrames_InBox.Visible =
				grcFrames_Qnt.Visible =
				grcFrames_Weighting.Visible =
					true;
			}
			else
			{
				grcFrames_DateValid.Visible =
				grcFrames_BoxQnt.Visible =
				grcFrames_GoodAlias.Visible =
				grcFrames_InBox.Visible =
				grcFrames_Qnt.Visible =
				grcFrames_Weighting.Visible =
					false;
			}
			if (optStereo.Checked)
			{
				oFrameList.FilterStereo = true;
			}
			if (optEmpty.Checked)
			{
				oFrameList.FilterHasFrameContent = false;
			}


			// tabTerms

			// выбранные товары
			if (sSelectedPackingsIDList.Length > 0)
			{
				oFrameList.FramesContents_FilterPackingsList = sSelectedPackingsIDList;
			}

			// срок годности
			if (chkDateValid.Checked && !dtpDateValidLess.IsEmpty)
			{
				oFrameList.FramesContents_FilterDateValidLess = dtpDateValidLess.Value.Date;
			}
			
			// геометрия
			if (!nurFrameHeight.nudBegSpinner.IsEmpty && nurFrameHeight.nudBegSpinner.Value > 0)
			{
				oFrameList.FilterHeightBeg = nurFrameHeight.nudBegSpinner.Value;
			}
			if (!nurFrameHeight.nudEndSpinner.IsEmpty && nurFrameHeight.nudEndSpinner.Value > 0)
			{
				oFrameList.FilterHeightEnd = nurFrameHeight.nudEndSpinner.Value;
			}

			if (!nurFrameWeight.nudBegSpinner.IsEmpty && nurFrameWeight.nudBegSpinner.Value > 0)
			{
				oFrameList.FilterWeightBeg = nurFrameWeight.nudBegSpinner.Value;
			}
			if (!nurFrameWeight.nudEndSpinner.IsEmpty && nurFrameWeight.nudEndSpinner.Value > 0)
			{
				oFrameList.FilterWeightEnd = nurFrameWeight.nudEndSpinner.Value;
			}

			if (cboPalletsTypes.SelectedValue != null && cboPalletsTypes.SelectedIndex >= 0)
			{
				oFrameList.FilterPalletsTypesList = cboPalletsTypes.SelectedValue.ToString();
			}

			// дата посл.операции
			if (!dtrDatesLastOperation.dtpBegDate.IsEmpty)
			{
				oFrameList.FilterDateLastOperationBeg = dtrDatesLastOperation.dtpBegDate.Value.Date;
			}
			if (!dtrDatesLastOperation.dtpEndDate.IsEmpty)
			{
				oFrameList.FilterDateLastOperationEnd = dtrDatesLastOperation.dtpEndDate.Value.Date;
			}
			// 

			grdFramesContents.DataSource = null;
			grdFramesHistory.DataSource = null;
			grdData.GetGridState();

			oFrameList.FillData();

			grdData.IsLockRowChanged = true;
			grdData.Restore(oFrameList.MainTable);
			tmrRestore.Enabled = true;

			RFMCursorWait.LockWindowUpdate(IntPtr.Zero);
			RFMCursorWait.Set(false);

			return (oFrameList.ErrorNumber == 0);
		}

		private bool grdFramesContents_Restore()
		{
			grdFramesContents.GetGridState();
			grdFramesContents.DataSource = null;
			if (grdData.Rows.Count == 0 ||
				oFrameCur.ID == null ||
				grdData.CurrentRow != null && grdData.IsStatusRow(grdData.CurrentRow.Index))
				return (true);

			oFrameList.FillTableFramesContents(Convert.ToInt32(oFrameCur.ID));
			grdFramesContents.Restore(oFrameList.TableFramesContents);
			return (oFrameList.ErrorNumber == 0);
		}

		private bool grdFramesHistory_Restore()
		{
			grdFramesHistory.GetGridState();
			grdFramesHistory.DataSource = null;
			if (grdData.Rows.Count == 0 ||
				oFrameCur.ID == null ||
				grdData.CurrentRow != null && grdData.IsStatusRow(grdData.CurrentRow.Index))
				return (true);

			oFrameList.ClearFramesHistoryFilters();
			if (!dtrFramesHistoryDates.dtpBegDate.IsEmpty)
			{
				oFrameList.FramesHistory_FilterDateBeg = dtrFramesHistoryDates.dtpBegDate.Value.Date;
			}
			if (!dtrFramesHistoryDates.dtpEndDate.IsEmpty)
			{
				oFrameList.FramesHistory_FilterDateEnd = dtrFramesHistoryDates.dtpEndDate.Value.Date;
			}
			oFrameList.FillTableFramesHistory(Convert.ToInt32(oFrameCur.ID));
			grdFramesHistory.Restore(oFrameList.TableFramesHistory);
			return (oFrameList.ErrorNumber == 0);
		}

		private bool grdFramesTraffics_Restore()
		{
			grdFramesTraffics.GetGridState();
			grdFramesTraffics.DataSource = null;
			if (grdData.Rows.Count == 0 ||
				oFrameCur.ID == null ||
				grdData.CurrentRow != null && grdData.IsStatusRow(grdData.CurrentRow.Index))
				return (true);

			oTrafficFrame.ClearError();
			oTrafficFrame.ClearFilters();

			if (!dtrFramesHistoryDates.dtpBegDate.IsEmpty)
			{
				oTrafficFrame.FilterDateBeg = dtrFramesHistoryDates.dtpBegDate.Value.Date;
			}
			if (!dtrFramesHistoryDates.dtpEndDate.IsEmpty)
			{
				oTrafficFrame.FilterDateEnd = dtrFramesHistoryDates.dtpEndDate.Value.Date;
			}
			oTrafficFrame.FilterFramesList = oFrameCur.ID.ToString();
			oTrafficFrame.FillData();
			grdFramesTraffics.Restore(oTrafficFrame.MainTable);
			return (oTrafficFrame.ErrorNumber == 0);
		}

	#endregion

	#region Filters

		#region GoodsStates

		private void btnGoodsStatesChoose_Click(object sender, EventArgs e)
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
					btnGoodsStatesClear_Click(null, null);
					return;
				}

				sSelectedGoodsStatesIDList = "," + _SelectedIDList;

				txtGoodsStatesChoosen.Text = _SelectedText;
				ttToolTip.SetToolTip(txtGoodsStatesChoosen, txtGoodsStatesChoosen.Text);

				tabFrames.IsNeedRestore = true;
			}

			_SelectedIDList = null;
			_SelectedText = "";
		}

		private void btnGoodsStatesClear_Click(object sender, EventArgs e)
		{
			tabFrames.IsNeedRestore = true;

			ttToolTip.SetToolTip(txtGoodsStatesChoosen, "не выбраны");
			sSelectedGoodsStatesIDList = "";
			txtGoodsStatesChoosen.Text = "";
		}

		#endregion GoodsStates

		#region Owners

		private void btnOwnersChoose_Click(object sender, EventArgs e)
		{
			_SelectedIDList = null;
			_SelectedText = "";

			Partner oOwner = new Partner();
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

			if (StartForm(new frmSelectID(this, oOwner.MainTable, "Name,Actual", "Владелец,Акт.", true)) == DialogResult.Yes)
			{
				if (_SelectedIDList == null || !_SelectedIDList.Contains(","))
				{
					btnOwnersClear_Click(null, null);
					return;
				}

				sSelectedOwnersIDList = "," + _SelectedIDList;

				txtOwnersChoosen.Text = _SelectedText;
				ttToolTip.SetToolTip(txtOwnersChoosen, txtOwnersChoosen.Text);

				tabFrames.IsNeedRestore = true;
			}

			_SelectedIDList = null;
			_SelectedText = "";
		}

		private void btnOwnersClear_Click(object sender, EventArgs e)
		{
			tabFrames.IsNeedRestore = true;

			ttToolTip.SetToolTip(txtOwnersChoosen, "не выбраны");
			sSelectedOwnersIDList = "";
			txtOwnersChoosen.Text = "";
		}

		#endregion

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

				tabFrames.IsNeedRestore = true;
			}

			_SelectedPackingIDList = null;
			_SelectedPackingAliasText = "";
		}

		private void btnPackingsClear_Click(object sender, EventArgs e)
		{
			tabFrames.IsNeedRestore = true;

			ttToolTip.SetToolTip(txtPackingsChoosen, "не выбраны");
			sSelectedPackingsIDList = "";
			txtPackingsChoosen.Text = "";
		}

		#endregion

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

				tabFrames.IsNeedRestore = true;
			}

			_SelectedCellsIDList = null;
			_SelectedCellAddressText = "";
		}

		private void btnCellsClear_Click(object sender, EventArgs e)
		{
			tabFrames.IsNeedRestore = true;

			ttToolTip.SetToolTip(txtCellsChoosen, "не выбраны");
			sSelectedCellsIDList = "";
			txtCellsChoosen.Text = "";
		}

		#endregion Cells

		private void chkDateValid_CheckedChanged(object sender, EventArgs e)
		{
			dtpDateValidLess.Enabled = chkDateValid.Checked;
		}
	
	#endregion Filters

	#region Menu Print

		private void btnPrint_Click(object sender, EventArgs e)
		{
			mnuPrint.Show(btnPrint, new Point());
		}

		private void btnPrint_MouseClick(object sender, MouseEventArgs e)
		{
			mnuPrint.Show(btnPrint, new Point(e.X, e.Y));
		}

		private void mniPrintFrameBarCodeLabel_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			// список контейнеров
			Frame oFrameBCL = new Frame();
			int nMarkedCnt = CalcMarkedRows();
			if (nMarkedCnt > 0 &&
				RFMMessage.MessageBoxYesNo("Отмечено записей: " + nMarkedCnt.ToString() + "\r\n" +
						"Формировать этикетки для всех отмеченных записей?") != DialogResult.Yes)
				return;

			Refresh();
			WaitOn(this);
			FramePrepareIDList(oFrameBCL, nMarkedCnt > 0);
			oFrameBCL.FillData();
			WaitOff(this);
			if (oFrameBCL.MainTable.Rows.Count == 0)
				return;

			StartForm(new frmBarCodeLabelPrint(this, oFrameBCL.MainTable, "FR", "Zebra"));
		}

		private void mniPrintFrameLabel_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			repFrameLabel rd = new repFrameLabel();
			PrintFrameLabel((DataDynamics.ActiveReports.ActiveReport3)rd);
		}

		private void PrintFrameLabel(DataDynamics.ActiveReports.ActiveReport3 rpReport)
		{
			Frame oFrameLabel = new Frame();
			int nMarkedCnt = CalcMarkedRows();
			if (nMarkedCnt > 0 &&
				RFMMessage.MessageBoxYesNo("Отмечено записей: " + nMarkedCnt.ToString() + "\r\n" +
						"Формировать этикетки для всех отмеченных записей?") != DialogResult.Yes)
				return;
			
			Refresh();
			WaitOn(this);
			FramePrepareIDList(oFrameLabel, nMarkedCnt > 0);
			oFrameLabel.FillData();
			WaitOff(this); 
			if (oFrameLabel.MainTable.Rows.Count == 0)
				return;

			// печать 
			StartForm(new frmActiveReport(oFrameLabel.MainTable, rpReport));
		}

	#endregion 

	#region Menu Service

		private void btnService_Click(object sender, EventArgs e)
		{
			mnuService.Show(btnService, new Point());
		}

		private void btnService_MouseClick(object sender, MouseEventArgs e)
		{
			mnuService.Show(btnService, new Point(e.X, e.Y));
		}

		private void mniServiceFramesTrafficManual_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.CurrentRow == null)
				return;

			oFrameCur.ID = Convert.ToInt32(grdData.CurrentRow.Cells["grcID"].Value);
			if (StartForm(new frmTrafficsFramesManual(Convert.ToInt32(oFrameCur.ID))) == DialogResult.Yes)
			{
				grdData_Restore();
			}
		}

		#region Lock

		private void mniServiceFrameLock_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			FrameLock(true);
		}

		private void mniServiceFrameUnLock_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			FrameLock(false);
		}

		private bool FrameLock(bool bLock)
		{
			if (grdData.CurrentRow == null)
				return (false);

			if (grdData.IsStatusRow(grdData.CurrentRow.Index))
				return (false);

			int nMarkedCnt = CalcMarkedRows();
			if (nMarkedCnt == 0 || !grdData.IsCheckerShow)
			{
				// один контейнер
				bool bLockOld = (bool)grdData.CurrentRow.Cells["grcLocked"].Value;
				if (bLockOld && bLock)
				{
					RFMMessage.MessageBoxInfo("Контейнер уже блокирован.");
					return (false);
				}
				if (!bLockOld && !bLock)
				{
					RFMMessage.MessageBoxInfo("Контейнер не был блокирован.");
					return (false);
				}

				oFrameCur.ClearError();
				oFrameCur.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
				oFrameCur.SetLock(oFrameCur.ID, bLock);
				if (oFrameCur.ErrorNumber == 0)
					RFMMessage.MessageBoxInfo("Контейнер " + (!bLock ? "раз" : "") + "блокирован.");
			}
			else
			{
				// несколько ячеек 
				if (RFMMessage.MessageBoxYesNo("Отмечено записей: " + nMarkedCnt.ToString() + "\r\n" +
						"Изменить блокировку для всех отмеченных контейнеров?") != DialogResult.Yes)
					return (false);

				WaitOn(this);
				DataView dMarked = new DataView(oFrameList.MainTable);
				dMarked.RowFilter = "IsMarked = true";
				foreach (DataRowView r in dMarked)
				{
					if (!Convert.IsDBNull(r["ID"]))
					{
						oFrameCur.ClearError();
						oFrameCur.ID = (int)r["ID"];
						oFrameCur.SetLock(oFrameCur.ID, bLock);
						if (oFrameCur.ErrorNumber != 0)
							break;
					}
				}
				WaitOff(this);
			}
			grdData_Restore();
			return (oFrameCur.ErrorNumber == 0);
		}


		#endregion Lock

	#endregion

	#region Terms clear

		private void btnClearTerms_Click(object sender, EventArgs e)
		{
			txtBarCode.Text = "";

			//optActual_Any.Checked = true;
			optActualYes.Checked = true;
			//optLocked_Any.Checked = true;
			optLockedNo.Checked = true;

			optStereoMono.Checked = true;

			btnGoodsStatesClear_Click(null, null);
			btnOwnersClear_Click(null, null);

			btnCellsClear_Click(null, null);

			optFrame_.Checked = true;
			
			// tabTerms
			optFrame_Any.Checked = true;
			chkDateValid.Checked = false;
			chkDateValid_CheckedChanged(null, null);
			btnPackingsClear_Click(null, null);

			nurFrameHeight.nudBegSpinner.HideControl(false);
			nurFrameHeight.nudEndSpinner.HideControl(false);
			nurFrameWeight.nudBegSpinner.HideControl(false);
			nurFrameWeight.nudEndSpinner.HideControl(false);
			cboPalletsTypes.SelectedIndex = -1;

			dtrFramesHistoryDates.dtpBegDate.Value = DateTime.Now.Date.AddMonths(-3);
			dtrFramesHistoryDates.dtpEndDate.Value = DateTime.Now.Date;
			dtrDatesLastOperation.dtpBegDate.HideControl(false);
			dtrDatesLastOperation.dtpEndDate.HideControl(false);
			//

			if (Control.ModifierKeys == Keys.Shift)
			{
				optActual_Any.Checked = true;
				optLocked_Any.Checked = true;
			}

			oFrameList.ClearFilters();
			oFrameList.ClearError();

			tabFrames.IsNeedRestore = true;
		}

	#endregion

	}
}