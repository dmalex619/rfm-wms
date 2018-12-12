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
	public partial class frmReportTraffics : RFMFormChild
	{
		TrafficFrame oTrafficFrame;
		TrafficGood oTrafficGood;
		
		// для фильтров
		protected Cell oCellSource;
		protected Cell oCellTarget;

		protected DateTime? dDateBegBirth, dDateEndBirth,
							dDateBegConfirm, dDateEndConfirm;
		protected bool? bConfirmed, bSuccess;
		protected string sFrameBarCodeContext;
		protected string sErrorsList;

		public string _SelectedIDList;
		public string _SelectedText;

		private string sSelectedUsersIDList = "";

		public string _SelectedPackingIDList;
		private string sSelectedPackingsIDList = "";

		private string sSelectedStoresZonesSourceIDList = "";
		private string sSelectedStoresZonesTypesSourceIDList = "";
		private string sSelectedStoresZonesTargetIDList = "";
		private string sSelectedStoresZonesTypesTargetIDList = "";


		public frmReportTraffics()
		{
			InitializeComponent();

			oTrafficFrame = new TrafficFrame();
			oTrafficGood = new TrafficGood();
			if (oTrafficFrame.ErrorNumber != 0 ||
				oTrafficGood.ErrorNumber != 0)
			{
				IsValid = false;
			}
			else
			{
				oCellSource = new Cell();
				oCellTarget = new Cell();
				if (oCellSource.ErrorNumber != 0 ||
					oCellTarget.ErrorNumber != 0)
				{
					IsValid = false;
				}
			}
		}

		private void frmReportTraffics_Load(object sender, EventArgs e) 
		{
			RFMCursorWait.Set(true);

			bool lResult = cboTrafficError_Restore(); 
			if (!lResult)
			{
				RFMCursorWait.Set(false);
				RFMMessage.MessageBoxError("Ошибка при получении фильтров (операции транспортировки контейнеров)...");
				Dispose();
			}

			grcQntWished.AgrType =
			grcQntConfirmed.AgrType =
			grcBoxConfirmed.AgrType =
			grcBoxWished.AgrType =
			grcFrameBoxQnt.AgrType =
			grcFramePalQnt.AgrType =
			grcFrameQnt.AgrType =
			grcFrameWeight.AgrType =
				EnumAgregate.Sum;  

			btnClearTerms_Click(null, null);
			tcList.Init();

			RFMCursorWait.Set(false);
		}

	#region Tab Restore 

		private bool tabTerms_Restore()
		{
			btnPrint.Enabled = false;
			btnService.Enabled = false;
			return (true);
		}

		private bool tabTrafficsFrames_Restore()
		{
			grdTrafficsFrames_Restore();
			btnPrint.Enabled = true;
			btnService.Enabled = true;
			return (true);
		}

		private bool tabTrafficsGoods_Restore()
		{
			grdTrafficsGoods_Restore();
			btnPrint.Enabled = true;
			btnService.Enabled = true;
			return (true);
		}

		private bool tabInputsFrames_Restore()
		{
			grdInputsFrames_Restore();
			btnPrint.Enabled = false;
			btnService.Enabled = false;
			return (true);
		}

		private void tcList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tcList.SelectedTab.Name.ToUpper().Contains("TERMS"))
			{
				btnPrint.Enabled =
				btnService.Enabled = false;
			}
			if (tcList.SelectedTab.Name.ToUpper().Contains("TRAFFICSFRAMES"))
			{
				grdTrafficsFrames.Select();
			}
			if (tcList.SelectedTab.Name.ToUpper().Contains("TRAFFICSGOODS"))
			{
				grdTrafficsGoods.Select();
			}
			if (tcList.SelectedTab.Name.ToUpper().Contains("INPUTSFRAMES"))
			{
				grdInputsFrames.Select();
			}
		}

	#endregion Tab Restore

	#region Buttons

		private void btnHelp_Click(object sender, EventArgs e)
		{
			RFMHelpUtilities.HelpShow(this, hpHelp);
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

	#endregion

	#region CellFormatting

		private void grdTrafficsFrames_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			RFMDataGridView grd = grdTrafficsFrames;

			if (grd.DataSource == null)
				return;

			if (grd.Rows[e.RowIndex] == null)
				return;

			if (grd.IsStatusRow(e.RowIndex))
			{
				switch (grd.Columns[e.ColumnIndex].Name)
				{
					case "grcStatusImage":
						e.Value = Properties.Resources.Empty;
						break;
				}
				return;
			}

			switch (grd.Columns[e.ColumnIndex].Name)
			{
				case "grcStatusImage":
					if (grd.Rows[e.RowIndex].Cells["grcDateConfirm"].Value.ToString().Length == 0)
						e.Value = Properties.Resources.Empty;
					else
						if (Convert.ToBoolean(grd.Rows[e.RowIndex].Cells["grcSuccess"].Value))
							e.Value = Properties.Resources.Check;
						else
							e.Value = Properties.Resources.CheckRed;
					break;
				case "grcTrafficsFramesInBox":
					DataGridViewRow r = grd.Rows[e.RowIndex];
					if (!Convert.IsDBNull(r.Cells["grcTrafficsFramesWeighting"].Value) &&
						Convert.ToBoolean(r.Cells["grcTrafficsFramesWeighting"].Value) ||
						!Convert.IsDBNull(e.Value) && Convert.ToDecimal(e.Value) != Convert.ToInt32(e.Value))
						e.CellStyle.Format = "### ### ### ###.000";
					else
						e.CellStyle.Format = "### ### ### ###";
					break;
			}
		}

		private void grdTrafficsGoods_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			RFMDataGridView grd = grdTrafficsGoods;

			if (grd.DataSource == null)
				return;

			if (grd.Rows[e.RowIndex] == null)
				return;

			if (grd.IsStatusRow(e.RowIndex))
			{
				switch (grd.Columns[e.ColumnIndex].Name)
				{
					case "grcGStatusImage":
						e.Value = Properties.Resources.Empty;
						break;
					case "grcGQntWished":
					case "grcGQntConfirmed":
					case "grcGInBox":
						e.CellStyle.Format = "### ### ### ###";
						break;
				}
				return;
			}

			switch (grd.Columns[e.ColumnIndex].Name)
			{
				case "grcGStatusImage":
					if (grd.Rows[e.RowIndex].Cells["grcGDateConfirm"].Value.ToString().Length == 0)
						e.Value = Properties.Resources.Empty;
					else
						if (Convert.ToBoolean(grd.Rows[e.RowIndex].Cells["grcGSuccess"].Value))
							e.Value = Properties.Resources.Check;
						else
							e.Value = Properties.Resources.CheckRed;
					break;
				case "grcGQntWished":
				case "grcGQntConfirmed":
				case "grcGInBox":
					DataGridViewRow r = grd.Rows[e.RowIndex];
					if (!Convert.IsDBNull(r.Cells["grcGWeighting"].Value) &&
						Convert.ToBoolean(r.Cells["grcGWeighting"].Value) ||
						!Convert.IsDBNull(e.Value) && Convert.ToDecimal(e.Value) != Convert.ToInt32(e.Value))
						e.CellStyle.Format = "### ### ### ###.000";
					else
						e.CellStyle.Format = "### ### ### ###";
					break;
			}
		}

		private void grdInputsFrames_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			RFMDataGridView grd = grdInputsFrames;

			if (grd.DataSource == null)
				return;

			if (grd.Rows[e.RowIndex] == null)
				return;

			if (grd.IsStatusRow(e.RowIndex))
			{
				switch (grd.Columns[e.ColumnIndex].Name)
				{
					case "grcInputConfirmed":
						e.Value = Properties.Resources.Empty;
						break;
					case "grcFrameQnt":
					case "grcFrameInBox":
						e.CellStyle.Format = "### ### ### ###";
						break;
				}
				return;
			}

			DataGridViewRow r = grd.Rows[e.RowIndex];
			switch (grd.Columns[e.ColumnIndex].Name)
			{
				case "grcInputConfirmed":
					if ((r.Cells["grcInputDateConfirm"].Value != DBNull.Value))
						e.Value = Properties.Resources.Check;
					else
						e.Value = Properties.Resources.Empty;
					break;
				case "grcFrameQnt":
				case "grcFrameInBox":
					if (!Convert.IsDBNull(r.Cells["grcWeightingFrame"].Value) &&
						Convert.ToBoolean(r.Cells["grcWeightingFrame"].Value) ||
						!Convert.IsDBNull(e.Value) && Convert.ToDecimal(e.Value) != Convert.ToInt32(e.Value))
					{
						e.CellStyle.Format = "### ### ### ###.000";
					}
					else
					{
						e.CellStyle.Format = "### ### ### ###";
					}
					break;
			}

			if ((grd.Columns[e.ColumnIndex].Name.Contains("Qnt") ||
				 grd.Columns[e.ColumnIndex].Name.Contains("Box") ||
				 grd.Columns[e.ColumnIndex].Name.Contains("Pal") ||
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

		private bool cboTrafficError_Restore()
		{
			oTrafficFrame.FillTableTrafficsFramesErrors();
			cboTrafficError.ValueMember = oTrafficFrame.TableTrafficsFramesErrors.Columns[0].Caption;
			cboTrafficError.DisplayMember = oTrafficFrame.TableTrafficsFramesErrors.Columns[1].Caption;
			cboTrafficError.DataSource = oTrafficFrame.TableTrafficsFramesErrors;
			return (oTrafficFrame.ErrorNumber == 0);
		}

		private bool grdTrafficsFrames_Restore()
		{
			// собираем условия
			TermsSelect();

			grdTrafficsFrames.GetGridState();

			Report oReportTrafficsFrames = new Report();
			oReportTrafficsFrames.ReportTraffics(
				"Frames",
				oCellSource.MainTable, oCellTarget.MainTable,
				dDateBegBirth, dDateEndBirth,
				dDateBegConfirm, dDateEndConfirm,
				bConfirmed, bSuccess, sErrorsList, 
				sSelectedUsersIDList, null,
				sFrameBarCodeContext, 
				sSelectedPackingsIDList);

			grdTrafficsFrames.IsLockRowChanged = true; 
			grdTrafficsFrames.Restore(oReportTrafficsFrames.MainTable);

			return (oReportTrafficsFrames.ErrorNumber == 0);
		}

		private bool grdTrafficsGoods_Restore()
		{
			oTrafficGood.ClearError();
			oTrafficGood.ClearFilters();

			// собираем условия
			TermsSelect();

			grdTrafficsGoods.GetGridState();

			Report oReportTrafficsGoods = new Report();
			oReportTrafficsGoods.ReportTraffics("Goods",
				oCellSource.MainTable, oCellTarget.MainTable,
				dDateBegBirth, dDateEndBirth,
				dDateBegConfirm, dDateEndConfirm,
				bConfirmed, bSuccess, null, 
				sSelectedUsersIDList, null, 
				"", 
				sSelectedPackingsIDList);

			grdTrafficsGoods.IsLockRowChanged = true; 
			grdTrafficsGoods.Restore(oReportTrafficsGoods.MainTable);

			return (oReportTrafficsGoods.ErrorNumber == 0);
		}

		private bool grdInputsFrames_Restore()
		{
			// собираем условия
			TermsSelect();

			grdInputsFrames.GetGridState();

			Report oReportInputsFrames = new Report();
			oReportInputsFrames.ReportInputsFrames(
				dDateBegBirth, dDateEndBirth,
				dDateBegConfirm, dDateEndConfirm,
				bConfirmed,
				sSelectedUsersIDList, 
				sFrameBarCodeContext, 
				sSelectedPackingsIDList);

			grdInputsFrames.IsLockRowChanged = true; 
			grdInputsFrames.Restore(oReportInputsFrames.MainTable);

			return (oReportInputsFrames.ErrorNumber == 0);
		}

		private void TermsSelect()
		{
			dDateBegBirth = dDateEndBirth = null;
			if (!dtrDatesBirth.dtpBegDate.IsEmpty)
			{
				dDateBegBirth = dtrDatesBirth.dtpBegDate.Value.Date;
			}
			if (!dtrDatesBirth.dtpEndDate.IsEmpty)
			{
				dDateEndBirth = dtrDatesBirth.dtpEndDate.Value.Date;
			}

			// ИСТОЧНИК
			// ячейка
			oCellSource.ClearError();
			oCellSource.ClearData();
			oCellSource.ClearFilters();
			oCellSource.ID = null;
			oCellSource.NeedRequery = false;
			if ((txtCellSourceBarCode.Text.Trim().Length > 0) |
				(txtCellSourceAddress.Text.Trim().Length > 0))
			{
				if (txtCellSourceBarCode.Text.Trim().Length > 0)
				{
					oCellSource.BarCode = txtCellSourceBarCode.Text.Trim();
				}
				if (txtCellSourceAddress.Text.Trim().Length > 0)
				{
					oCellSource.FilterAddressContext = txtCellSourceAddress.Text.Trim();
				}
			}
			// зоны
			if (sSelectedStoresZonesSourceIDList.Length > 0)
			{
				oCellSource.FilterStoresZonesList = sSelectedStoresZonesSourceIDList;
			}
			if (sSelectedStoresZonesTypesSourceIDList.Length > 0)
			{
				oCellSource.FilterStoresZonesTypesList = sSelectedStoresZonesTypesSourceIDList;
			}
			if (!oCellSource.NeedRequery)
			{
				oCellSource.ID = -1;
			}
			oCellSource.FillData();

			// ПРИЕМНИК  
			// ячейка
			oCellTarget.ClearError();
			oCellTarget.ClearData();
			oCellTarget.ClearFilters();
			oCellTarget.ID = null;
			oCellTarget.NeedRequery = false;
			if ((txtCellTargetBarCode.Text.Trim().Length > 0) |
				(txtCellTargetAddress.Text.Trim().Length > 0))
			{
				if (txtCellTargetBarCode.Text.Trim().Length > 0)
				{
					oCellTarget.BarCode = txtCellTargetBarCode.Text.Trim();
				}
				if (txtCellTargetAddress.Text.Trim().Length > 0)
				{
					oCellTarget.FilterAddressContext = txtCellTargetAddress.Text.Trim();
				}
			}
			// зоны
			if (sSelectedStoresZonesTargetIDList.Length > 0)
			{
				oCellTarget.FilterStoresZonesList = sSelectedStoresZonesTargetIDList;
			}
			if (sSelectedStoresZonesTypesTargetIDList.Length > 0)
			{
				oCellTarget.FilterStoresZonesTypesList = sSelectedStoresZonesTypesTargetIDList;
			}
			if (!oCellTarget.NeedRequery)
			{
				oCellTarget.ID = -1;
			}
			oCellTarget.FillData();

			// контейнер
			sFrameBarCodeContext = null;
			if (txtFrameBarCode.Text.Trim().Length > 0)
			{
				sFrameBarCodeContext = txtFrameBarCode.Text.Trim();
			}

			// состояние операций
			bConfirmed = null;
			bSuccess = null;
			sErrorsList = null;
			if (optNotConfirmed.Checked)
			{
				bConfirmed = false;
			}
			if (optConfirmed.Checked)
			{
				bConfirmed = true;
			}
			if (optSuccess.Checked)
			{
				bConfirmed = true;
				bSuccess = true;
			}
			if (optNotSuccess.Checked)
			{
				bConfirmed = true;
				bSuccess = false;
				if (cboTrafficError.SelectedIndex > -1)
				{
					sErrorsList = cboTrafficError.SelectedValue.ToString();
				}
			}

			dDateBegConfirm = dDateEndConfirm = null;
			if (bConfirmed.HasValue && (bool)bConfirmed)
			{
				if (!dtrDatesConfirm.dtpBegDate.IsEmpty)
				{
					dDateBegConfirm = dtrDatesConfirm.dtpBegDate.Value.Date;
				}
				if (!dtrDatesConfirm.dtpEndDate.IsEmpty)
				{
					dDateEndConfirm = dtrDatesConfirm.dtpEndDate.Value.Date;
				}
			}
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
				tabTrafficsGoods.IsNeedRestore = true;
				tabInputsFrames.IsNeedRestore = true;
			}

			_SelectedIDList = null;
			_SelectedText = "";
		}

		private void btnStoresZonesClear_Click(object sender, EventArgs e)
		{
			tabTrafficsFrames.IsNeedRestore = true;
			tabTrafficsGoods.IsNeedRestore = true;
			tabInputsFrames.IsNeedRestore = true;

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
				tabTrafficsGoods.IsNeedRestore = true;
				tabInputsFrames.IsNeedRestore = true;
			}

			_SelectedIDList = null;
			_SelectedText = "";
		}

		private void btnStoresZonesTypesClear_Click(object sender, EventArgs e)
		{
			tabTrafficsFrames.IsNeedRestore = true;
			tabTrafficsGoods.IsNeedRestore = true;
			tabInputsFrames.IsNeedRestore = true;

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
				if (_SelectedIDList == null || RFMPublic.RFMUtilities.Occurs(_SelectedIDList, ",") == 0)
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
				tabTrafficsGoods.IsNeedRestore = true;
				tabInputsFrames.IsNeedRestore = true;
			}

			if (sSelectedUsersIDList != null && sSelectedUsersIDList.Length == 0)
			{
				sSelectedUsersIDList = null;
			}
			_SelectedIDList = null;
		}

		private void btnUsersClear_Click(object sender, EventArgs e)
		{
			tabTrafficsFrames.IsNeedRestore = true;
			tabTrafficsGoods.IsNeedRestore = true;
			tabInputsFrames.IsNeedRestore = true;

			ttToolTip.SetToolTip(txtUsersChoosen, "не выбраны");
			sSelectedUsersIDList = null;
			txtUsersChoosen.Text = "";
		}

		#endregion

		#region Packings

		private void btnPackingsChoose_Click(object sender, EventArgs e)
		{
			_SelectedPackingIDList = null;
			if (StartForm(new frmSelectOnePacking(this, true)) == DialogResult.Yes)
			{
				int nCntChoosen = RFMPublic.RFMUtilities.Occurs(_SelectedPackingIDList, ",");

				if (_SelectedPackingIDList == null || nCntChoosen == 0)
				{
					btnPackingsClear_Click(null, null);
					return;
				}

				sSelectedPackingsIDList = "," + _SelectedPackingIDList;

				Good oGoodSel = new Good();
				oGoodSel.FilterPackingsIDList = _SelectedPackingIDList;
				oGoodSel.FillData();

				string sSelectedDataText = "";
				int i = 0;
				foreach (DataRow r in oGoodSel.MainTable.Rows)
				{
					i++;
					if (i > 3)
					{
						sSelectedDataText += "...";
						break;
					}
					sSelectedDataText += ", " + r["GoodAlias"].ToString().Trim();
				}
				if (sSelectedDataText.StartsWith(","))
				{
					sSelectedDataText = sSelectedDataText.Substring(1).Trim();
				}

				txtPackingsChoosen.Text = "(" + nCntChoosen.ToString().Trim() + "): " + sSelectedDataText;
				ttToolTip.SetToolTip(txtPackingsChoosen, txtPackingsChoosen.Text);

				tabTrafficsFrames.IsNeedRestore = true;
				tabTrafficsGoods.IsNeedRestore = true;
				tabInputsFrames.IsNeedRestore = true;
			}

			if (sSelectedPackingsIDList != null && sSelectedPackingsIDList.Length == 0)
			{
				sSelectedPackingsIDList = null;
			}
			_SelectedPackingIDList = null;
		}

		private void btnPackingsClear_Click(object sender, EventArgs e)
		{
			tabTrafficsFrames.IsNeedRestore = true;
			tabTrafficsGoods.IsNeedRestore = true;
			tabInputsFrames.IsNeedRestore = true;

			ttToolTip.SetToolTip(txtPackingsChoosen, "не выбраны");
			sSelectedPackingsIDList = null;
			txtPackingsChoosen.Text = "";
		}

		#endregion

		private void optNotSuccess_CheckedChanged(object sender, EventArgs e)
		{
			cboTrafficError.Enabled = optNotSuccess.Checked;
		}

	#endregion
		
	#region Menu Print

		private void btnPrint_Click(object sender, EventArgs e)
		{
			switch (tcList.SelectedTab.Name)
			{
				case "tabTrafficsFrames":
				case "tabTrafficsGoods":
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
				case "tabTrafficsFrames":
				case "tabTrafficsGoods":
					mnuPrint.Show(btnPrint, new Point(e.X, e.Y));
					break;
				default:
					break;
			}
		}

	#endregion

	#region Terms clear

		private void btnClearTerms_Click(object sender, EventArgs e)
		{
			dtrDatesConfirm.dtpBegDate.Value = DateTime.Now.Date.AddDays(-7);
			dtrDatesConfirm.dtpEndDate.Value = DateTime.Now.Date;
			dtrDatesBirth.dtpBegDate.Value = DateTime.Now.Date.AddDays(-7);
			dtrDatesBirth.dtpEndDate.Value = DateTime.Now.Date;

			txtCellSourceAddress.Text = "";
			txtCellSourceBarCode.Text = "";
			txtCellTargetAddress.Text = "";
			txtCellTargetBarCode.Text = "";

			txtFrameBarCode.Text = "";

			//optStatus_Any.Checked = true;
			optConfirmed.Checked = true;
			optNotSuccess_CheckedChanged(null, null);
			cboTrafficError.SelectedIndex = -1;

			btnStoresZonesClear_Click(btnStoresZonesSourceClear, null);
			btnStoresZonesTypesClear_Click(btnStoresZonesTypesSourceClear, null);
			btnStoresZonesClear_Click(btnStoresZonesTargetClear, null);
			btnStoresZonesTypesClear_Click(btnStoresZonesTypesTargetClear, null);

			oCellSource.ClearFilters();
			oCellTarget.ClearFilters();

			oTrafficFrame.ClearFilters();
			oTrafficGood.ClearFilters();

			_SelectedIDList = sSelectedUsersIDList = null;
			_SelectedPackingIDList = sSelectedPackingsIDList = null;

			btnUsersClear_Click(null, null);
			btnPackingsClear_Click(null, null);

			tabTrafficsFrames.IsNeedRestore = true;
			tabTrafficsGoods.IsNeedRestore = true;
			tabInputsFrames.IsNeedRestore = true;
		}
		
	#endregion

	}
}