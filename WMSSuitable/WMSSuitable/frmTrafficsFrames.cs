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
	public partial class frmTrafficsFrames : RFMFormChild
	{
		private TrafficFrame oTrafficList;
		private TrafficFrame oTrafficCur;
		private Frame oFrame;

		// для фильтров
		public string _SelectedIDList;
		public string _SelectedText;

		public string _SelectedPackingIDList;
		public string _SelectedPackingAliasText;
		private string sSelectedPackingsIDList = "";

		private string sSelectedStoresZonesSourceIDList = "";
		private string sSelectedStoresZonesTypesSourceIDList = "";
		private string sSelectedStoresZonesTargetIDList = "";
		private string sSelectedStoresZonesTypesTargetIDList = "";

		private string sSelectedUsersIDList = "";

		// для Partial-подтверждения
		private decimal? nPartialQnt = null;
		private decimal nPartialQntInFrame = 0;
		private decimal nPartialInBox = 0;
		private bool bPartialWeighting = false;
		private bool bPartialDecimalInBox = false;
		private int? nNewTrafficID = null;
		private int? nCellFinishID = null; 


		public frmTrafficsFrames()
		{
			oTrafficList = new TrafficFrame();
			oTrafficCur = new TrafficFrame();
			oFrame = new Frame();
			if (oTrafficList.ErrorNumber != 0 ||
				oTrafficCur.ErrorNumber != 0 ||
				oFrame.ErrorNumber != 0)
			{
				IsValid = false;
			}

			if (IsValid)
			{
				InitializeComponent();
			}
		}

		private void frmTrafficsFrames_Load(object sender, EventArgs e)
		{
			RFMCursorWait.Set(true);

			cboTrafficError.SelectedIndex = -1;

			grcQntFramesContents.AgrType =
			grcBoxQntFramesContents.AgrType =
			grcPalQntFramesContents.AgrType =
			grcFrameWeight.AgrType =
				EnumAgregate.Sum;

			btnClearTerms_Click(null, null);

			pnlPartial.Visible = false;

			tcList.Init();

			RFMCursorWait.Set(false);
		}

		#region Tab Restore 

		private bool tabTerms_Restore()
		{
			btnAdd.Enabled =
			btnEdit.Enabled =
			btnConfirm.Enabled =
			btnDelete.Enabled =
			btnPrint.Enabled =
			btnService.Enabled = 
				false;
			return true;
		}

		private bool tabTrafficsFrames_Restore()
		{
			grdData_Restore();
			btnAdd.Enabled = true;
			btnService.Enabled = true;

			if (grdData.Rows.Count > 0)
			{
				btnPrint.Enabled = true;
				//btnService.Enabled = true;
			}
			else
			{
				btnPrint.Enabled = false;
				//btnService.Enabled = false;
			}
			return true;
		}

		private void tcList_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (tcList.SelectedTab.Name)
			{
				case "tabTerms":
					tabTerms_Restore();
					break;
				case "tabTrafficsFrames":
					btnAdd.Enabled = true;
					btnService.Enabled = true;
					grdData.Select();
					break;
			}
		}

		#endregion Tab Restore

		#region Buttons

		private void btnAdd_Click(object sender, EventArgs e)
		{
			int? nFrameID = null;
			// если стоим на записи о неудачном подтверждении - делаем новую операцию именно для этого контейнера
			if (grdData.CurrentRow != null && !grdData.IsStatusRow(grdData.CurrentRow.Index))
			{
				DataGridViewRow r = grdData.CurrentRow;
				if (r.Cells["grcTrafficFrameErrorName"].Value != null &&
					r.Cells["grcTrafficFrameErrorName"].Value.ToString().Length > 0 &&
					r.Cells["grcDateConfirm"].Value != DBNull.Value)
				{
					if (RFMMessage.MessageBoxYesNo("Создать новую операцию транспортировки поддона с кодом " + r.Cells["grcFrameID"].Value.ToString() + "?") == DialogResult.Yes)
					{
						nFrameID = Convert.ToInt32(r.Cells["grcFrameID"].Value);
					}
				}
			}

			if (StartForm(new frmTrafficsFramesManual(nFrameID)) == DialogResult.Yes)
				grdData_Restore();
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			if (grdData.CurrentRow == null)
				return;

			// перечитаем текущее состояние задания
			oTrafficCur.ClearError();
			oTrafficCur.ClearData();
			oTrafficCur.ClearFilters();
			oTrafficCur.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			oTrafficCur.FillData();
			if (oTrafficCur.ErrorNumber != 0 || oTrafficCur.MainTable.Rows.Count != 1)
				return;

			DataRow r = oTrafficCur.MainTable.Rows[0];

			if ((bool)r["IsConfirmed"])
			{
				RFMMessage.MessageBoxError("Задание уже подтверждено.\n" +
						"Изменение невозможно.");
				return;
			}

			if (r["DateAccept"] != DBNull.Value)
			{
				if (RFMMessage.MessageBoxYesNo("Задание уже выполняется.\n\n" +
						"Можно только зарегистрировать неудачное завершение задания\nс указанием ошибки.\n\n" +
						"Продолжить?") != DialogResult.Yes)
					return;
			}

			if (StartForm(new frmTrafficsFramesEdit((int)oTrafficCur.ID)) == DialogResult.Yes)
				grdData_Restore();
		}

		private void btnConfirm_Click(object sender, EventArgs e)
		{
			if (grdData.CurrentRow == null)
				return;

			if (RFMMessage.MessageBoxYesNo("Отметить удачное завершение операции транспортировки\n(поддон устанавливается в ячейку-приемник)?") == DialogResult.Yes)
			{
				oTrafficCur.ClearError();
				oTrafficCur.ClearData();
				oTrafficCur.ClearFilters();
				oTrafficCur.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
				oTrafficCur.FillData();
				if (oTrafficCur.MainTable.Rows.Count > 0)
				{
					oTrafficCur.ConfirmData((int)oTrafficCur.ID, (int)oTrafficCur.MainTable.Rows[0]["CellTargetID"], true, null);
					if (oTrafficCur.ErrorNumber == 0)
						grdData_Restore();
				}
			}
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (grdData.CurrentRow == null) return;

			// перечитаем текущее состояние задания
			oTrafficCur.ClearError();
			oTrafficCur.ClearData();
			oTrafficCur.ClearFilters();
			oTrafficCur.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			oTrafficCur.FillData();
			if (oTrafficCur.ErrorNumber != 0 || oTrafficCur.MainTable.Rows.Count != 1) return;

			DataRow r = oTrafficCur.MainTable.Rows[0];

			if ((bool)r["IsConfirmed"])
			{
				RFMMessage.MessageBoxError("Задание уже подтверждено.\n" + "Удаление невозможно.");
				return;
			}

			if (r["DateAccept"] != DBNull.Value)
			{
				RFMMessage.MessageBoxError("Задание уже выполняется.\n" + "Удаление невозможно.");
				return;
			}

			if (RFMMessage.MessageBoxYesNo("Удалить задание на транспортировку поддона?") == DialogResult.Yes)
			{
				oTrafficCur.DeleteOne((int)oTrafficCur.ID);
				if (oTrafficCur.ErrorNumber == 0)
					grdData_Restore();
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

		public void TrafficPrepareIDList(TrafficFrame oTraffic, bool bMultiSelect)
		{
			oTraffic.ID = null;
			oTraffic.IDList = null;
			int? nTrafficID = 0;
			if (bMultiSelect && grdData.IsCheckerShow)
			{
				oTraffic.IDList = "";

				DataView dMarked = new DataView(oTrafficList.MainTable);
				dMarked.RowFilter = "IsMarked = true";
				dMarked.Sort = grdData.GridSource.Sort;
				foreach (DataRowView r in dMarked)
				{
					if (!Convert.IsDBNull(r["ID"]))
					{
						nTrafficID = (int)r["ID"];
						oTraffic.IDList = oTraffic.IDList + nTrafficID.ToString() + ",";
					}
				}
			}
			else
			{
				oTraffic.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			}
		}

		public int CalcMarkedRows()
		{
			int nCnt = 0;
			if (grdData.IsCheckerShow)
			{
				DataView dMarked = new DataView(oTrafficList.MainTable);
				dMarked.RowFilter = "IsMarked = true";
				nCnt = dMarked.Count;
			}
			return (nCnt);
		}

		#endregion

		#region TimerTick, CellsFormatting

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

			btnAdd.Enabled = 
			btnPrint.Enabled =
			btnService.Enabled = 
				true;

			oFrame.ID = 0;
			if (grdData.IsStatusRow(rowIndex))
			{
				oTrafficCur.ID = 0;
				btnConfirm.Enabled = 
				btnEdit.Enabled = 
					false;
			}
			else
			{
				DataGridViewRow r = grdData.Rows[rowIndex];
				oTrafficCur.ID = (int)r.Cells["grcID"].Value;
				bool isConfirmed = (bool)r.Cells["grcIsConfirmed"].Value;
				bool isAccepted = (r.Cells["grcDateAccept"].Value != null &&
									r.Cells["grcDateAccept"].Value != DBNull.Value);
				btnConfirm.Enabled = !isConfirmed;
				btnEdit.Enabled = !isConfirmed && !isAccepted;
				btnDelete.Enabled = !isConfirmed && !isAccepted;

				if (r.Cells["grcFrameID"].Value != DBNull.Value &&
					r.Cells["grcFrameID"].Value != null)
				{
					oFrame.ID = (int)r.Cells["grcFrameID"].Value;
				}
			}

			grdFramesContents_Restore();
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
					case "grcStatusImage":
						e.Value = Properties.Resources.Empty;
						break;
				}
				return;
			}

			switch (grdData.Columns[e.ColumnIndex].Name)
			{
				case "grcStatusImage":
					if (grdData.Rows[e.RowIndex].Cells["grcDateConfirm"].Value.ToString().Length == 0)
						e.Value = Properties.Resources.Empty;
					else
						if ((bool)grdData.Rows[e.RowIndex].Cells["grcSuccess"].Value)
							e.Value = Properties.Resources.Check;
						else
							e.Value = Properties.Resources.CheckRed;
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
				case "grcQntFramesContents":
				case "grcInBox":
					if (!Convert.IsDBNull(r.Cells["grcWeighting"].Value) &&
						Convert.ToBoolean(r.Cells["grcWeighting"].Value) ||
						!Convert.IsDBNull(e.Value) && Convert.ToDecimal(e.Value) != Convert.ToInt32(e.Value))
						e.CellStyle.Format = "### ### ### ###.000";
					else
						e.CellStyle.Format = "### ### ### ###";
					break;
			}
		}

		#endregion

		#region Restore

		private bool cboTrafficError_Restore()
		{
			oTrafficList.FillTableTrafficsFramesErrors();
			cboTrafficError.ValueMember = oTrafficList.TableTrafficsFramesErrors.Columns[0].Caption;
			cboTrafficError.DisplayMember = oTrafficList.TableTrafficsFramesErrors.Columns[1].Caption;
			cboTrafficError.DataSource = oTrafficList.TableTrafficsFramesErrors;
			return (oTrafficList.ErrorNumber == 0);
		}


		private bool grdData_Restore()
		{
			RFMCursorWait.Set(true);
			RFMCursorWait.LockWindowUpdate(FindForm().Handle);

			oTrafficCur.ID = null;
			oFrame.ID = null;

			oTrafficList.ClearError();
			oTrafficList.ClearFilters();
			oTrafficList.ID = null;
			oTrafficList.IDList = null;

			// собираем условия

			// штрих-код
			//if (txtBarCode.Text.Trim().Length > 0)
			//    oTrafficList.BarCode = txtBarCode.Text.Trim();
			// даты
			if (!dtrDates.dtpBegDate.IsEmpty)
			{
				oTrafficList.FilterDateBeg = dtrDates.dtpBegDate.Value.Date;
			}
			if (!dtrDates.dtpEndDate.IsEmpty)
			{
				oTrafficList.FilterDateEnd = dtrDates.dtpEndDate.Value.Date;
			}
			// ИСТОЧНИК
			// ячейка
			Cell oCellSource = new Cell();
			if ((txtCellSourceBarCode.Text.Trim().Length > 0) |
				(txtCellSourceAddress.Text.Trim().Length > 0))
			{
				if (txtCellSourceBarCode.Text.Trim().Length > 0)
					oCellSource.BarCode = txtCellSourceBarCode.Text.Trim();
				if (txtCellSourceAddress.Text.Trim().Length > 0)
					oCellSource.FilterAddress = txtCellSourceAddress.Text.Trim();
				oCellSource.FillData();
				if (oCellSource.MainTable.Rows.Count > 0)
				{
					StringBuilder sbCS = new StringBuilder("");
					foreach (DataRow r in oCellSource.MainTable.Rows)
						sbCS = sbCS.Append(r["ID"].ToString() + ",");
					if (sbCS.Length > 0)
						oTrafficList.FilterCellsSourceList = sbCS.ToString();
				}
				else
				{
					oTrafficList.FilterCellsSourceList = "-1";
				}
			}
			// зоны
			if (sSelectedStoresZonesSourceIDList.Length > 0)
			{
				oTrafficList.FilterStoresZonesSourceList = sSelectedStoresZonesSourceIDList;
			}
			if (sSelectedStoresZonesTypesSourceIDList.Length > 0)
			{
				oTrafficList.FilterStoresZonesTypesSourceList = sSelectedStoresZonesTypesSourceIDList;
			}
			// ПРИЕМНИК            
			// ячейка
			Cell oCellTarget = new Cell();
			if ((txtCellTargetBarCode.Text.Trim().Length > 0) |
				(txtCellTargetAddress.Text.Trim().Length > 0))
			{
				if (txtCellTargetBarCode.Text.Trim().Length > 0)
					oCellTarget.BarCode = txtCellTargetBarCode.Text.Trim();
				if (txtCellTargetAddress.Text.Trim().Length > 0)
					oCellTarget.FilterAddress = txtCellTargetAddress.Text.Trim();
				oCellTarget.FillData();
				if (oCellTarget.MainTable.Rows.Count > 0)
				{
					StringBuilder sbCT = new StringBuilder("");
					foreach (DataRow r in oCellTarget.MainTable.Rows)
						sbCT = sbCT.Append(r["ID"].ToString() + ",");
					if (sbCT.Length > 0)
						oTrafficList.FilterCellsTargetList = sbCT.ToString();
				}
				else
				{
					oTrafficList.FilterCellsTargetList = "-1";
				}
			}
			// зоны
			if (sSelectedStoresZonesTargetIDList.Length > 0)
			{
				oTrafficList.FilterStoresZonesTargetList = sSelectedStoresZonesTargetIDList;
			}
			if (sSelectedStoresZonesTypesTargetIDList.Length > 0)
			{
				oTrafficList.FilterStoresZonesTypesTargetList = sSelectedStoresZonesTypesTargetIDList;
			}

			// контейнер
			if (txtFrameBarCode.Text.Trim().Length > 0)
			{
				oTrafficList.FilterFramesBarCodeContext = txtFrameBarCode.Text.Trim();
			}
			if (txtFrameID.Text.Trim().Length > 0)
			{
				oTrafficList.FilterFramesList = txtFrameID.Text.Trim();
			}

			// пользователи
			if (sSelectedUsersIDList.Length > 0)
			{
				oTrafficList.FilterUsersList = sSelectedUsersIDList;
			}

			// выбранные товары
			if (sSelectedPackingsIDList.Length > 0)
			{
				oTrafficList.FramesContents_FilterPackingsList = sSelectedPackingsIDList;
			}

			// состояние операций
			if (optNotConfirmed.Checked)
			{
				oTrafficList.FilterConfirmed = false;
				// начало обработки
				if (optNotStarted.Checked)
				{
					oTrafficList.FilterAccepted = false;
				}
				if (optStartedNotConfirmed.Checked)
				{
					oTrafficList.FilterAccepted = true;
				}
			}

			if (optSuccess.Checked)
			{
				oTrafficList.FilterConfirmed = true;
				oTrafficList.FilterSuccess = true;
			}
			if (optNotSuccess.Checked)
			{
				oTrafficList.FilterConfirmed = true;
				oTrafficList.FilterSuccess = false;
				if (cboTrafficError.SelectedIndex > -1)
				{
					oTrafficList.FilterErrorsList = cboTrafficError.SelectedValue.ToString();
				}
			}

			// приходы-расходы
			if (txtInputBarCode.Text.Length > 0)
			{
				Input oInputFilter = new Input();
				oInputFilter.BarCode = txtInputBarCode.Text.Trim();
				oInputFilter.FillData();
				// если не нашли ни одного прихода по указанному штрих-коду, 
				// все равно должны передать "", чтобы не получить ни одного перемещения
				string sInputBarCode = "";
				foreach (DataRow r in oInputFilter.MainTable.Rows)
				{
					sInputBarCode = sInputBarCode + "," + r["ID"];
				}
				oTrafficList.FilterInputsList = sInputBarCode;
			}
			if (txtOutputBarCode.Text.Length > 0)
			{
				Output oOutputFilter = new Output();
				oOutputFilter.BarCode = txtOutputBarCode.Text.Trim();
				oOutputFilter.FillData();
				// если не нашли ни одного прихода по указанному штрих-коду, 
				// все равно должны передать "", чтобы не получить ни одного перемещения
				string sOutputBarCode = "";
				foreach (DataRow r in oOutputFilter.MainTable.Rows)
				{
					sOutputBarCode = sOutputBarCode + "," + r["ID"];
				}
				oTrafficList.FilterOutputsList = sOutputBarCode;
			}

			grdFramesContents.DataSource = null;
			grdData.GetGridState();

			oTrafficList.FillData();

			grdData.IsLockRowChanged = true;
			grdData.Restore(oTrafficList.MainTable);
			tmrRestore.Enabled = true;

			RFMCursorWait.LockWindowUpdate(IntPtr.Zero);
			RFMCursorWait.Set(false);

			return (oTrafficList.ErrorNumber == 0);
		}

		private bool grdFramesContents_Restore()
		{
			grdFramesContents.GetGridState();
			grdFramesContents.DataSource = null;
			if (grdData.Rows.Count == 0 ||
				oFrame.ID == null ||
				(grdData.CurrentRow != null && grdData.IsStatusRow(grdData.CurrentRow.Index)))
				return (true);

			oFrame.ClearError();
			oFrame.FillTableFramesContents((int)oFrame.ID);
			grdFramesContents.Restore(oFrame.TableFramesContents);
			return (oFrame.ErrorNumber == 0);
		}

		#endregion

		#region Filters Choose

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

			if (StartForm(new frmSelectID(this, oStoreZone.MainTable, "Name", "Зона склада", true)) == DialogResult.Yes)
			{
				if (_SelectedIDList == null || !_SelectedIDList.Contains(","))
				{
					btnStoresZonesClear_Click(null, null);
					return;
				}

				if (((RFMButton)sender).Name.Contains("Source"))
				{
					sSelectedStoresZonesSourceIDList = "," + _SelectedIDList;

					txtStoresZonesSourceChoosen.Text = _SelectedText;
					ttToolTip.SetToolTip(txtStoresZonesSourceChoosen, txtStoresZonesSourceChoosen.Text);
				}
				if (((RFMButton)sender).Name.Contains("Target"))
				{
					sSelectedStoresZonesTargetIDList = "," + _SelectedIDList;

					txtStoresZonesTargetChoosen.Text = _SelectedText;
					ttToolTip.SetToolTip(txtStoresZonesTargetChoosen, txtStoresZonesTargetChoosen.Text);
				}

				tabTrafficsFrames.IsNeedRestore = true;
			}

			_SelectedIDList = null;
			_SelectedText = "";
		}

		private void btnStoresZonesClear_Click(object sender, EventArgs e)
		{
			tabTrafficsFrames.IsNeedRestore = true;

			if (((RFMButton)sender).Name.Contains("Source"))
			{
				ttToolTip.SetToolTip(txtStoresZonesSourceChoosen, "не выбраны");
				txtStoresZonesSourceChoosen.Text = "";
				sSelectedStoresZonesSourceIDList = "";
			}
			if (((RFMButton)sender).Name.Contains("Target"))
			{
				ttToolTip.SetToolTip(txtStoresZonesTargetChoosen, "не выбраны");
				txtStoresZonesTargetChoosen.Text = "";
				sSelectedStoresZonesTargetIDList = "";
			}
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

				if (((RFMButton)sender).Name.Contains("Source"))
				{
					sSelectedStoresZonesTypesSourceIDList = "," + _SelectedIDList;
					txtStoresZonesTypesSourceChoosen.Text = _SelectedText;
					ttToolTip.SetToolTip(txtStoresZonesTypesSourceChoosen, txtStoresZonesTypesSourceChoosen.Text);
				}
				if (((RFMButton)sender).Name.Contains("Target"))
				{
					sSelectedStoresZonesTypesTargetIDList = "," + _SelectedIDList;
					txtStoresZonesTypesTargetChoosen.Text = _SelectedText;
					ttToolTip.SetToolTip(txtStoresZonesTypesTargetChoosen, txtStoresZonesTypesTargetChoosen.Text);
				}

				tabTrafficsFrames.IsNeedRestore = true;
			}

			_SelectedIDList = null;
			_SelectedText = "";
		}

		private void btnStoresZonesTypesClear_Click(object sender, EventArgs e)
		{
			tabTrafficsFrames.IsNeedRestore = true;

			if (((RFMButton)sender).Name.Contains("Source"))
			{
				ttToolTip.SetToolTip(txtStoresZonesTypesSourceChoosen, "не выбраны");
				sSelectedStoresZonesTypesSourceIDList = "";
				txtStoresZonesTypesSourceChoosen.Text = "";
			}
			if (((RFMButton)sender).Name.Contains("Target"))
			{
				ttToolTip.SetToolTip(txtStoresZonesTypesTargetChoosen, "не выбраны");
				sSelectedStoresZonesTypesTargetIDList = "";
				txtStoresZonesTypesTargetChoosen.Text = "";
			}
		}

		#endregion StoresZonesTypes

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

				tabTrafficsFrames.IsNeedRestore = true;
			}
			_SelectedIDList = null;
		}

		private void btnUsersClear_Click(object sender, EventArgs e)
		{
			tabTrafficsFrames.IsNeedRestore = true;

			ttToolTip.SetToolTip(txtUsersChoosen, "не выбраны");
			sSelectedUsersIDList = "";
			txtUsersChoosen.Text = "";
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

				tabTrafficsFrames.IsNeedRestore = true;
			}

			_SelectedPackingIDList = null;
			_SelectedPackingAliasText = "";
		}

		private void btnPackingsClear_Click(object sender, EventArgs e)
		{
			tabTrafficsFrames.IsNeedRestore = true;

			ttToolTip.SetToolTip(txtPackingsChoosen, "не выбраны");
			sSelectedPackingsIDList = "";
			txtPackingsChoosen.Text = "";
		}

		#endregion

		private void optNotConfirmed_CheckedChanged(object sender, EventArgs e)
		{
			pnlOpgInputsStarted.Enabled = optNotConfirmed.Checked;
		}

		private void optNotSuccess_CheckedChanged(object sender, EventArgs e)
		{
			cboTrafficError.Enabled = optNotSuccess.Checked;
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

		private void mniPrintTrafficBill_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.Rows.Count == 0)
				return;

			repTrafficFrameBill rd = new repTrafficFrameBill();
			PrintTrafficBill((DataDynamics.ActiveReports.ActiveReport3)rd);
		}

		private void PrintTrafficBill(DataDynamics.ActiveReports.ActiveReport3 rpReport)
		{
			// список операций
			TrafficFrame oTrafficPrint = new TrafficFrame();

			int nMarkedCnt = CalcMarkedRows();
			if (nMarkedCnt > 0 &&
				RFMMessage.MessageBoxYesNo("Отмечено записей: " + nMarkedCnt.ToString() + "\r\n" +
						"Напечатать лист заданий для всех отмеченных записей?") != DialogResult.Yes)
				return;

			Refresh();
			TrafficPrepareIDList(oTrafficPrint, nMarkedCnt > 0);
			oTrafficPrint.FillData();
			if (oTrafficPrint.MainTable.Rows.Count == 0)
				return;

			// печать 
			StartForm(new frmActiveReport(oTrafficPrint.MainTable, rpReport));

			// отметка печати
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

		private void mniServiceTrafficProrityUp_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			TrafficPriorityChange(1);
		}

		private void mniServiceTrafficProrityDown_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			TrafficPriorityChange(-1);
		}

		private bool TrafficPriorityChange(int nShift)
		{
			if (grdData.CurrentRow == null)
				return (false);

			// перечитаем текущее состояние задания
			oTrafficCur.ClearError();
			oTrafficCur.ClearData();
			oTrafficCur.ClearFilters();
			oTrafficCur.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			oTrafficCur.FillData();
			if (oTrafficCur.ErrorNumber != 0 || oTrafficCur.MainTable.Rows.Count != 1)
				return (false);

			DataRow r = oTrafficCur.MainTable.Rows[0];

			if (Convert.ToBoolean(r["IsConfirmed"]))
			{
				RFMMessage.MessageBoxError("Задание уже подтверждено.\n" +
						"Изменение приоритета невозможно.");
				return (false);
			}

			if (Convert.IsDBNull(r["DateAccept"]))
			{
				RFMMessage.MessageBoxError("Задание уже выполняется.\n" +
						"Изменение приоритета невозможно.");
				return (false);
			}

			int nPriorityCur = (int)r["Priority"];
			if (nShift > 0 && nPriorityCur >= 9)
			{
				RFMMessage.MessageBoxError("Текущий приоритет задания: " + nPriorityCur.ToString() + "\n" +
						"Повышение приоритета невозможно.");
				return (false);
			}
			if (nShift < 0 && nPriorityCur <= 1)
			{
				RFMMessage.MessageBoxError("Текущий приоритет задания: " + nPriorityCur.ToString() + "\n" +
						"Понижение приоритета невозможно.");
				return (false);
			}

			if (RFMMessage.MessageBoxYesNo(((nShift > 0) ? "Повысить" : "Понизить") + " приоритет задания на транспортировку?") == DialogResult.Yes)
			{
				oTrafficCur.PriorityChange((int)oTrafficCur.ID, nShift);
				if (oTrafficCur.ErrorNumber == 0)
					grdData_Restore();
			}
			return (oTrafficCur.ErrorNumber == 0);
		}

		private void mniServiceTrafficsFrameSetDateAccept_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.CurrentRow == null)
				return;

			// перечитаем текущее состояние задания
			oTrafficCur.ClearError();
			oTrafficCur.ClearData();
			oTrafficCur.ClearFilters();
			oTrafficCur.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			oTrafficCur.FillData();
			if (oTrafficCur.ErrorNumber != 0 || oTrafficCur.MainTable.Rows.Count != 1)
				return;

			DataRow r = oTrafficCur.MainTable.Rows[0];

			if (Convert.ToBoolean(r["IsConfirmed"]))
			{
				RFMMessage.MessageBoxError("Задание уже подтверждено.");
				return;
			}

			if (Convert.IsDBNull(r["UserID"]))
			{
				RFMMessage.MessageBoxError("Для задания не определен пользователь...");
				return;
			}

			if (!Convert.IsDBNull(r["DateAccept"]))
			{
				RFMMessage.MessageBoxError("Задание уже выполняется.");
				return;
			}

			if (RFMMessage.MessageBoxYesNo("Отметить начало обработки (выполнения) задания на транспортировку?") == DialogResult.Yes)
			{
				oTrafficCur.SetDateAccept((int)oTrafficCur.ID);
				if (oTrafficCur.ErrorNumber == 0)
					grdData_Restore();
			}
			return;
		}

		private void mniServiceTrafficsFrameClearDateAccept_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.CurrentRow == null)
				return;

			// перечитаем текущее состояние задания
			oTrafficCur.ClearError();
			oTrafficCur.ClearData();
			oTrafficCur.ClearFilters();
			oTrafficCur.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			oTrafficCur.FillData();
			if (oTrafficCur.ErrorNumber != 0 || oTrafficCur.MainTable.Rows.Count != 1)
				return;

			DataRow r = oTrafficCur.MainTable.Rows[0];

			if (Convert.ToBoolean(r["IsConfirmed"]))
			{
				RFMMessage.MessageBoxError("Задание уже подтверждено.");
				return;
			}

			if (Convert.IsDBNull(r["DateAccept"]))
			{
				RFMMessage.MessageBoxError("Задание еще не выполняется.");
				return;
			}

			if (RFMMessage.MessageBoxYesNo("Очистить сведения о начале обработки (выполнения) задания на транспортировку поддона\n" +
				"(время, пользователь, устройство)?") == DialogResult.Yes)
			{
				oTrafficCur.ClearDateAccept((int)oTrafficCur.ID);
				if (oTrafficCur.ErrorNumber == 0)
					grdData_Restore();
			}
			return;
		}

		private void mniServiceTrafficsFramesConfirm_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (StartForm(new frmTrafficsFramesEdit()) == DialogResult.Yes)
				grdData_Restore();
		}

		private void mniServiceTrafficsFramesForPickingCreate_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (StartForm(new frmTrafficsFramesForPickingCreate()) == DialogResult.Yes)
				grdData_Restore();
		}


		private void mniServiceConfirmPartial_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.CurrentRow == null)
				return;

			// перечитаем текущее состояние задания
			oTrafficCur.ClearError();
			oTrafficCur.ClearData();
			oTrafficCur.ClearFilters();
			oTrafficCur.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			oTrafficCur.FillData();
			if (oTrafficCur.ErrorNumber != 0 || oTrafficCur.MainTable.Rows.Count != 1)
				return;

			// запись - трафик
			DataRow r = oTrafficCur.MainTable.Rows[0];

			if (Convert.ToBoolean(r["IsConfirmed"]))
			{
				RFMMessage.MessageBoxError("Задание уже подтверждено.");
				return;
			}
			if (!Convert.IsDBNull(r["DateAccept"]))
			{
				RFMMessage.MessageBoxError("Задание уже выполняется.");
				return;
			}

			// контейнер - нормальный
			Frame oFramePartial = new Frame();
			oFramePartial.ID = Convert.ToInt32(r["FrameID"]);
			oFramePartial.FillData();
			if (oFramePartial.ErrorNumber != 0 || oFramePartial.MainTable == null ||
				oFramePartial.MainTable.Rows.Count != 1)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о контейнере...");
				return;
			}
			oFramePartial.FillTableFramesContents((int)oFramePartial.ID);
			if (oFramePartial.ErrorNumber != 0 || oFramePartial.TableFramesContents == null)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о содержимом контейнера...");
				return;
			}
			if (oFramePartial.TableFramesContents.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Контейнер не содержит товаров...\n" +
					"Подтверждение транспортировки с указанием перемещаемого количества товара невозможно.");
				return;
			}
			if (oFramePartial.TableFramesContents.Rows.Count > 1)
			{
				RFMMessage.MessageBoxError("Контейнер содержит больше одного наименования товара...\n" + 
					"Подтверждение транспортировки с указанием перемещаемого количества товара невозможно.");
				return;
			}

			// запись - сейчас в контейнере 
			DataRow cc = oFramePartial.TableFramesContents.Rows[0];

			// сейчас в контейнере 
			nPartialQntInFrame = Convert.ToDecimal(cc["Qnt"]);
			nPartialInBox = Convert.ToDecimal(cc["InBox"]);
			bPartialWeighting = Convert.ToBoolean(cc["Weighting"]);
			bPartialDecimalInBox = ((int)nPartialInBox != nPartialInBox);

			string sPartialGoodAlias = cc["GoodAlias"].ToString() + 
				((bPartialWeighting || bPartialWeighting) 
					? " (" + nPartialInBox.ToString("#####0.000") + " кг в кор.)" 
					: " (" + nPartialInBox.ToString("#####0") + " шт. в кор.)"); 

			// конечная ячейка - пикинг, меньше паллеты (?)
			Cell oCellFinishPartial = new Cell();
			oCellFinishPartial.ID = Convert.ToInt32(r["CellTargetID"]);
			oCellFinishPartial.FillData();
			if (oCellFinishPartial.ErrorNumber != 0 || oCellFinishPartial.MainTable == null ||
				oCellFinishPartial.MainTable.Rows.Count != 1)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о конечной ячейке...");
				return;
			}

			// запись - ячейка
			DataRow c = oCellFinishPartial.MainTable.Rows[0];

			if (!Convert.IsDBNull(c["ForFrames"]) && Convert.ToBoolean(c["ForFrames"]))
			{
				RFMMessage.MessageBoxError("Конечная ячейка предназначена для контейнеров...\n" + 
					"Подтверждение транспортировки с указанием перемещаемого количества товара невозможно.");
				return;
			}
			if (!Convert.ToBoolean(c["ForPicking"]))
			{
				RFMMessage.MessageBoxError("Конечная ячейка не является ячейкой пикинга...\n" +
					"Подтверждение транспортировки с указанием перемещаемого количества товара невозможно.");
				return;
			}
			if (Convert.ToDecimal(c["MaxPalletQnt"]) >= 1)
			{
				if (RFMMessage.MessageBoxYesNo("Вместимость конечной ячейки - не менее паллеты.\n" +
						"Все-таки выполнить подтверждение транспортировки с указанием перемещаемого количества товара?") != DialogResult.Yes)
					return;
			}

			if (RFMMessage.MessageBoxYesNo("Подтвердить выполнение транспортировки с указанием количества перемещаемого в конечную ячейку товара\n" + 
					"(для контейнера будет подобрано новое место и создана новая операция транспортировки)?") == DialogResult.Yes)
			{
				nCellFinishID = Convert.ToInt32(r["CellTargetID"]);

				// запрос количества
				tcList.Enabled = false;
				btnAdd.Enabled =
				btnEdit.Enabled =
				btnConfirm.Enabled =
				btnDelete.Enabled =
				btnPrint.Enabled =
				btnService.Enabled =
					false; 

				lblPartialGoodAlias.Text = sPartialGoodAlias;
				int nPartialBox_ = 0;
				decimal nPartialRestQnt_ = 0;
				if (bPartialWeighting)
				{
					nPartialBox_ = 0;
					nPartialRestQnt_ = nPartialQntInFrame;
					numPartialBox.Enabled = false;
					numPartialRestQnt.DecimalPlaces = 3; 
				}
				else
				{
					nPartialBox_ = Convert.ToInt32(Math.Floor(nPartialQntInFrame / nPartialInBox));
					nPartialRestQnt_ = nPartialQntInFrame - nPartialBox_ * nPartialInBox;
					numPartialBox.Enabled = true;
					numPartialRestQnt.DecimalPlaces = ((bPartialDecimalInBox) ? 3 : 0); 
				}
				numPartialBox.Value = nPartialBox_;
				numPartialRestQnt.Value = nPartialRestQnt_;
				
				pnlPartial.Left = btnService.Left - btnPartialGo.Left - btnPartialGo.FlatAppearance.BorderSize * 2;
				pnlPartial.Top = btnService.Top - pnlPartial.Height - btnService.FlatAppearance.BorderSize * 4;
				pnlPartial.Visible = true; 
				pnlPartial.Enabled =
					true;

				numPartialBox.Select(); 
				// ушли туда 
			}
			return;
		}

		private void btnPartialGo_Click(object sender, EventArgs e)
		{
			nPartialQnt = numPartialBox.Value * nPartialInBox + numPartialRestQnt.Value;
			if (nPartialQnt == 0)
			{
				RFMMessage.MessageBoxError("Не указано перемещаемое количество товара...");
				return;
			}

			if (nPartialQnt > nPartialQntInFrame)
			{
				RFMMessage.MessageBoxError("Перемещаемое количество превышает количество товара на поддоне...");
				return; 
			}

			if (Math.Round((decimal)nPartialQnt, 3) == Math.Round(nPartialQntInFrame, 3))
			{
				if (RFMMessage.MessageBoxYesNo("Перемещаемое количество равно количеству товара на поддоне.\n" + 
					"Весь товар будет перемещен в конечную ячейку, поддон будет разобран!\n" + 
					"Все-таки продолжить?") != DialogResult.Yes) 
					return;
			}

			nNewTrafficID = null;
			if (TrafficFrameConfirmPartial())
			{
				pnlPartial.Visible = false;
				string sText = "Операция подтверждена.\n";
				if (nNewTrafficID.HasValue && nNewTrafficID > 0)
					sText += "Создана новая операция транспортировки контейнера.";
				else
					sText += "Контейнер разобран.";
				RFMMessage.MessageBoxInfo(sText); 
				grdData_Restore();
			}
			else
			{
				pnlPartial.Visible = false;
				grdData.IsLockRowChanged = false;
				grdData_CurrentRowChanged(null);
			}

			tcList.Enabled = true;
		}

		private void btnPartialExit_Click(object sender, EventArgs e)
		{
			nPartialQnt = null;
			pnlPartial.Visible = false;
			tcList.Enabled = true;
			// включить кнопки 
			grdData.IsLockRowChanged = false;
			grdData_CurrentRowChanged(null);
		}

		private bool TrafficFrameConfirmPartial()
		{
			oTrafficCur.ConfirmPartialData((int)oTrafficCur.ID, (int)nCellFinishID, true, null, (decimal)nPartialQnt, ref nNewTrafficID);
			return (oTrafficCur.ErrorNumber == 0);
		}

		#endregion

		#region Terms Clear

		private void btnClearTerms_Click(object sender, EventArgs e)
		{
			dtrDates.dtpBegDate.Value = DateTime.Now.Date.AddDays(-7);
			dtrDates.dtpEndDate.Value = DateTime.Now.Date.AddDays(1);

			txtBarCode.Text = "";
			txtCellSourceAddress.Text = "";
			txtCellSourceBarCode.Text = "";
			txtCellTargetAddress.Text = "";
			txtCellTargetBarCode.Text = "";
			txtFrameBarCode.Text = "";

			btnStoresZonesClear_Click(btnStoresZonesSourceClear, null);
			btnStoresZonesTypesClear_Click(btnStoresZonesTypesSourceClear, null);
			btnStoresZonesClear_Click(btnStoresZonesTargetClear, null);
			btnStoresZonesTypesClear_Click(btnStoresZonesTypesTargetClear, null);

			//optStatus_Any.Checked = true;
			optNotConfirmed.Checked = true;
			optNotConfirmed_CheckedChanged(null, null);
			optNotSuccess_CheckedChanged(null, null);
			cboTrafficError.SelectedIndex = -1;

			txtInputBarCode.Text = "";
			txtOutputBarCode.Text = "";

			btnUsersClear_Click(null, null);
			btnPackingsClear_Click(null, null);

			if (Control.ModifierKeys == Keys.Shift)
			{
				dtrDates.dtpBegDate.HideControl(false);
				dtrDates.dtpEndDate.HideControl(false);
				optStatus_Any.Checked = true;
			}

			tabTrafficsFrames.IsNeedRestore = true;
		}

		#endregion

		
	}
}