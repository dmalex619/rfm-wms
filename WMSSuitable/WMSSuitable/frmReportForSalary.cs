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
	public partial class frmReportForSalary : RFMFormChild
    {
        #region Inner properties
        protected DateTime? dDateBeg, dDateEnd;
		protected bool bUseTimes = false;
        protected string sGroupBy = "E";
        protected string sDetailMode = "TOTAL";

		public string _SelectedIDList;
		public string _SelectedText; 
		private string sSelectedUsersIDList = "";
		private string sSelectedInputsTypesIDList = "";
		private string sSelectedOutputsTypesIDList = "";
		private string sSelectedOwnersIDList = "";

        private Report oReportInputsUnload;
        private Report oReportInputsAccept;
		private Report oReportTrafficsFramesHi;
        private Report oReportTrafficsFramesLo;
        private Report oReportOutputsPicking;
		private Report oReportOutputsLoad;
		private Report oReportOutputsValidate;
		private Report oReportMovings;
		private Report oReportInventories;
		private Report oReportSalaryExtraWorks;
		private Report oReportTotal;
		private Report oReportPieceWorks;
        #endregion
        
        public frmReportForSalary()
		{
            oReportInputsUnload = new Report();
            oReportInputsAccept = new Report();
			oReportTrafficsFramesHi = new Report();
			oReportOutputsPicking = new Report();
			oReportTrafficsFramesLo = new Report();
			oReportOutputsLoad = new Report();
			oReportOutputsValidate = new Report();
			oReportMovings = new Report();
			oReportInventories = new Report();
			oReportSalaryExtraWorks = new Report();
			oReportTotal = new Report();
			oReportPieceWorks = new Report();
            if (oReportInputsUnload.ErrorNumber != 0 ||
                oReportInputsAccept.ErrorNumber != 0 ||
				oReportTrafficsFramesHi.ErrorNumber != 0 ||
				oReportOutputsPicking.ErrorNumber != 0 ||
				oReportTrafficsFramesLo.ErrorNumber != 0 ||
				oReportOutputsLoad.ErrorNumber != 0 ||
				oReportOutputsValidate.ErrorNumber != 0 ||  
				oReportMovings.ErrorNumber != 0 ||
				oReportInventories.ErrorNumber != 0 ||
				oReportSalaryExtraWorks.ErrorNumber != 0 ||
				oReportTotal.ErrorNumber != 0 ||
				oReportPieceWorks.ErrorNumber != 0)
			{
				IsValid = false;
			}

			if (IsValid)
			{
				InitializeComponent();
			}
		}

		private void frmReportForSalary_Load(object sender, EventArgs e) 
		{
			btnClearTerms_Click(null, null);
			tcList.Init();

            grdInputsUnload.IsStatusShow =
            grdInputsAccept.IsStatusShow =
            grdTrafficsFramesHi.IsStatusShow =
			grdTrafficsFramesLo.IsStatusShow =
			grdOutputsPicking.IsStatusShow =
			grdOutputsLoad.IsStatusShow =
			grdOutputsValidate.IsStatusShow =
			grdMovings.IsStatusShow =
			grdInventories.IsStatusShow =
			grdSalaryExtraWorks.IsStatusShow =
			grdTotal.IsStatusShow =
			grdPieceWorks.IsStatusShow = 
				true;

            grcInputsUnload_BoxesCount.AgrType =
            grcInputsUnload_Netto.AgrType =
            grcInputsUnload_InputsCount.AgrType =
            grcInputsUnload_InputsItemsCount.AgrType =
            grcInputsUnload_InputsItemsRelativeCount.AgrType =
            grcInputsAccept_InputsCount.AgrType =
            grcInputsAccept_OperationsCount.AgrType =
            grcTrafficsFramesHi_OperationsCount.AgrType =
            grcTrafficsFramesHi_MovesUp.AgrType =
            grcTrafficsFramesHi_MovesDown.AgrType =
            grcTrafficsFramesLo_OperationsCount.AgrType =
			grcOutputsPicking_OutputsCount.AgrType =
			grcOutputsPicking_LinesCount.AgrType =
			grcOutputsPicking_BoxesCount.AgrType =
			grcOutputsPicking_Netto.AgrType =
			grcOutputsLoad_OutputsCount.AgrType =
			grcOutputsLoad_LinesCount.AgrType =
			grcOutputsLoad_BoxesCount.AgrType =
			grcOutputsLoad_Netto.AgrType =
			grcOutputsValidate_ValidateOutputsCount.AgrType =
			grcOutputsValidate_ValidateOutputsLinesCount.AgrType =
			grcOutputsValidate_ValidateOutputsBoxesCount.AgrType =
			grcOutputsValidate_ValidateOutputsNetto.AgrType =
			grcMovings_BoxesCount.AgrType =
			grcInventories_CellsCount.AgrType =
			grcSalaryExtraWorks_Amount.AgrType =  
				EnumAgregate.Sum;
			foreach (DataGridViewColumn  c in grdTotal.Columns)
			{
				if (c.DefaultCellStyle.Format.Contains("N"))
				{
					((RFMDataGridViewTextBoxColumn)c).AgrType = EnumAgregate.Sum;
				}
			}
			foreach (DataGridViewColumn c in grdPieceWorks.Columns)
			{
				if (c.DefaultCellStyle.Format.Contains("N"))
				{
					((RFMDataGridViewTextBoxColumn)c).AgrType = EnumAgregate.Sum;
				}
			}
		}

		private bool tabTerms_Restore()
		{
			btnPrint.Enabled = false;
			return (true);
		}

        private bool tabInputsUnload_Restore()
        {
            grdInputsUnload_Restore();
			if (grdInputsUnload.Rows.Count > 0)
	            btnPrint.Enabled = true;
            return (true);
        }

        private bool tabInputsAccept_Restore()
		{
			grdInputsAccept_Restore();
			if (grdInputsAccept.Rows.Count > 0)
				btnPrint.Enabled = true;
			return (true);
		}

		private bool tabTrafficsFramesHi_Restore()
		{
			grdTrafficsFramesHi_Restore();
			if (grdTrafficsFramesHi.Rows.Count > 0)
				btnPrint.Enabled = true;
			return (true);
		}

        private bool tabTrafficsFramesLo_Restore()
        {
            grdTrafficsFramesLo_Restore();
			if (grdTrafficsFramesLo.Rows.Count > 0)
				btnPrint.Enabled = true;
            return (true);
        }

        private bool tabOutputsPicking_Restore()
		{
			grdOutputsPicking_Restore();
			if (grdOutputsPicking.Rows.Count > 0)
				btnPrint.Enabled = true;
			return (true);
		}

		private bool tabOutputsLoad_Restore()
		{
			grdOutputsLoad_Restore();
			if (grdOutputsLoad.Rows.Count > 0)
				btnPrint.Enabled = true;
			return (true);
		}

		private bool tabOutputsValidate_Restore()
		{
			grdOutputsValidate_Restore();
			if (grdOutputsValidate.Rows.Count > 0)
				btnPrint.Enabled = true;
			return (true);
		}

		private bool tabMovings_Restore()
		{
			grdMovings_Restore();
			if (grdMovings.Rows.Count > 0)
				btnPrint.Enabled = true;
			return (true);
		}

		private bool tabInventories_Restore()
		{
			grdInventories_Restore();
			if (grdInventories.Rows.Count > 0)
				btnPrint.Enabled = true;
			return (true);
		}

		private bool tabSalaryExtraWorks_Restore()
		{
			grdSalaryExtraWorks_Restore();
			if (grdSalaryExtraWorks.Rows.Count > 0)
				btnPrint.Enabled = true;
			return (true);
		}

		private bool tabTotal_Restore()
		{
			grdTotal_Restore();
			if (grdTotal.Rows.Count > 0)
				btnPrint.Enabled = true;
			return (true);
		}

		private bool tabPieceWorks_Restore()
		{
			grdPieceWorks_Restore();
			if (grdPieceWorks.Rows.Count > 0)
				btnPrint.Enabled = true;
			return (true);
		}

		private void tcList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tcList.SelectedTab.Name.ToUpper().Contains("TERMS"))
			{
				btnPrint.Enabled = false;
			}
            if (tcList.SelectedTab.Name == tabInputsUnload.Name)
            {
                grdInputsUnload.Select();
				if (grdInputsUnload.Rows.Count > 0)
					btnPrint.Enabled = true;
            }
            if (tcList.SelectedTab.Name == tabInputsAccept.Name)
            {
                grdInputsAccept.Select();
				if (grdInputsAccept.Rows.Count > 0)
					btnPrint.Enabled = true;
			}
            if (tcList.SelectedTab.Name == tabTrafficsFramesHi.Name)
			{
				grdTrafficsFramesHi.Select();
				if (grdTrafficsFramesHi.Rows.Count > 0)
					btnPrint.Enabled = true;
			}
            if (tcList.SelectedTab.Name == tabTrafficsFramesLo.Name)
            {
                grdTrafficsFramesLo.Select();
				if (grdTrafficsFramesLo.Rows.Count > 0)
					btnPrint.Enabled = true;
			}
            if (tcList.SelectedTab.Name == tabOutputsPicking.Name)
			{
				grdOutputsPicking.Select();
				if (grdOutputsPicking.Rows.Count > 0)
					btnPrint.Enabled = true;
			}
			if (tcList.SelectedTab.Name == tabOutputsLoad.Name)
			{
				grdOutputsLoad.Select();
				if (grdOutputsLoad.Rows.Count > 0)
					btnPrint.Enabled = true;
			}
			if (tcList.SelectedTab.Name == tabOutputsValidate.Name)
			{
				grdOutputsValidate.Select();
				if (grdOutputsValidate.Rows.Count > 0)
					btnPrint.Enabled = true;
			}
			if (tcList.SelectedTab.Name == tabMovings.Name)
			{
				grdMovings.Select();
				if (grdMovings.Rows.Count > 0)
					btnPrint.Enabled = true;
			}
			if (tcList.SelectedTab.Name == tabInventories.Name)
			{
				grdInventories.Select();
				if (grdInventories.Rows.Count > 0)
					btnPrint.Enabled = true;
			}
			if (tcList.SelectedTab.Name == tabSalaryExtraWorks.Name)
			{
				grdSalaryExtraWorks.Select();
				if (grdSalaryExtraWorks.Rows.Count > 0)
					btnPrint.Enabled = true;
			}

			if (tcList.SelectedTab.Name == tabTotal.Name)
			{
				grdTotal.Select();
				if (grdTotal.Rows.Count > 0)
					btnPrint.Enabled = true;
			}
			if (tcList.SelectedTab.Name == tabPieceWorks.Name)
			{
				grdPieceWorks.Select();
				if (grdPieceWorks.Rows.Count > 0)
					btnPrint.Enabled = true;
			}
		}

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

	#region RowEnter, CellFormatting

		private void grdData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			RFMDataGridView grd = (RFMDataGridView)sender;

			if (grd.DataSource == null)
				return;

			if (grd.Rows[e.RowIndex] == null)
				return;

			if (grd.IsStatusRow(e.RowIndex))
			{
				if (grd.Columns[e.ColumnIndex].Name.ToUpper().Contains("IMAGE"))
				{
					e.Value = Properties.Resources.Empty;
				}
				return;
			}

			if (grd.Name.ToUpper().Contains("GRD")) //(grd.Name.ToUpper().Contains("TOTAL") || grd.Name.ToUpper().Contains("PIECE"))
			{
				if (grd.Columns[e.ColumnIndex].DefaultCellStyle.Format.Contains("N"))
				{
					if (Convert.IsDBNull(e.Value) || Convert.ToDecimal(e.Value) == 0)
					{
						e.Value = "";
					}
				}
			}

			/*
			switch (grd.Columns[e.ColumnIndex].Name)
			{
				case "grcUserName":
					if (grd.Rows[e.RowIndex].Cells["grcDateConfirm"].Value.ToString().Length == 0)
						e.Value = Properties.Resources.Empty;
					else
						if (Convert.ToBoolean(grd.Rows[e.RowIndex].Cells["grcSuccess"].Value))
							e.Value = Properties.Resources.Check;
						else
							e.Value = Properties.Resources.CheckRed;
					break;
			}
			*/ 
		}

	#endregion

	#region Restore

        private bool grdInputsUnload_Restore()
        {
			WaitOn(this);

			TermsSelect();

			grdInputsUnload.DataSource = null;
            
			oReportInputsUnload.ReportForSalary(
                "InputsUnload",
                dDateBeg, dDateEnd,
				sDetailMode,
                sGroupBy,
				sSelectedUsersIDList,
                sSelectedInputsTypesIDList,
                null, 
				sSelectedOwnersIDList);

			grdInputsUnload.Restore(oReportInputsUnload.MainTable);

            grcInputsUnload_UserName.Visible = !optGroupByBrigades.Checked;
            grcInputsUnload_DateConfirm.Visible = (optDetailModeDetail.Checked || optDetailModeDate.Checked);
			grcInputsUnload_ERPCode.Visible =
			grcInputsUnload_PartnerName.Visible =
				optDetailModeDetail.Checked;

			WaitOff(this);

            return (oReportInputsUnload.ErrorNumber == 0);
        }

        private bool grdInputsAccept_Restore()
		{
			WaitOn(this);

			TermsSelect();

			grdInputsAccept.DataSource = null;

			oReportInputsAccept.ReportForSalary(
				"InputsAccept",
				dDateBeg, dDateEnd,
				sDetailMode,
                sGroupBy,
				sSelectedUsersIDList, 
				sSelectedInputsTypesIDList, 
				null, 
				sSelectedOwnersIDList);
			
			grdInputsAccept.Restore(oReportInputsAccept.MainTable);

            grcInputsAccept_UserName.Visible = !optGroupByBrigades.Checked;
			grcInputsAccept_DateConfirm.Visible = (optDetailModeDetail.Checked || optDetailModeDate.Checked);
			grcInputsAccept_ERPCode.Visible =
			grcInputsAccept_PartnerName.Visible =
				optDetailModeDetail.Checked;

			WaitOff(this);

			return (oReportInputsAccept.ErrorNumber == 0);
		}

		private bool grdTrafficsFramesHi_Restore()
		{
			WaitOn(this);
			
			TermsSelect();

			grdTrafficsFramesHi.DataSource = null;

			oReportTrafficsFramesHi.ReportForSalary(
				"TrafficsFramesHi",
				dDateBeg, dDateEnd,
				sDetailMode,
                sGroupBy,
				sSelectedUsersIDList,
				null,
				null,
				sSelectedOwnersIDList);

			grdTrafficsFramesHi.Restore(oReportTrafficsFramesHi.MainTable);

            grcTrafficsFramesHi_UserName.Visible = !optGroupByBrigades.Checked;
			grcTrafficsFramesHi_DateConfirm.Visible = (optDetailModeDetail.Checked || optDetailModeDate.Checked);

			//grdTrafficsFrames.Select();

			WaitOff(this);

			return (oReportTrafficsFramesHi.ErrorNumber == 0);
		}

        private bool grdTrafficsFramesLo_Restore()
        {
			WaitOn(this);

            TermsSelect();

            grdTrafficsFramesLo.DataSource = null;

            oReportTrafficsFramesLo.ReportForSalary(
                "TrafficsFramesLo",
                dDateBeg, dDateEnd,
				sDetailMode,
                sGroupBy,
                sSelectedUsersIDList,
                null,
				sSelectedOutputsTypesIDList,
				sSelectedOwnersIDList);

            grdTrafficsFramesLo.Restore(oReportTrafficsFramesLo.MainTable);

            grcTrafficsFramesLo_UserName.Visible = !optGroupByBrigades.Checked;
			grcTrafficsFramesLo_DateConfirm.Visible = (optDetailModeDetail.Checked || optDetailModeDate.Checked);

            //grdOutputsTrafficsFrames.Select();

			WaitOff(this);

            return (oReportTrafficsFramesLo.ErrorNumber == 0);
        }

        private bool grdOutputsPicking_Restore()
		{
			WaitOn(this);

			TermsSelect();

			grdOutputsPicking.DataSource = null;

			oReportOutputsPicking.ReportForSalary(
				"OutputsPicking",
				dDateBeg, dDateEnd,
				sDetailMode,
                sGroupBy,
				sSelectedUsersIDList,
				null,
				sSelectedOutputsTypesIDList,
				sSelectedOwnersIDList);

			grdOutputsPicking.Restore(oReportOutputsPicking.MainTable);

            grcOutputsPicking_UserName.Visible = !optGroupByBrigades.Checked;
			grcOutputsPicking_DateConfirm.Visible = (optDetailModeDetail.Checked || optDetailModeDate.Checked);
			grcOutputsPicking_ERPCode.Visible =
			grcOutputsPicking_PartnerName.Visible =
			grcOutputsPicking_CarAlias.Visible = 
				optDetailModeDetail.Checked; 

			//grdOutputsTrafficsGoods.Select();

			WaitOff(this);

			return (oReportOutputsPicking.ErrorNumber == 0);
		}

		private bool grdOutputsLoad_Restore()
		{
			WaitOn(this);

			TermsSelect();

			grdOutputsLoad.DataSource = null;

			oReportOutputsLoad.ReportForSalary(
				"OutputsLoad",
				dDateBeg, dDateEnd,
				sDetailMode,
                sGroupBy,
				sSelectedUsersIDList,
				null,
				sSelectedOutputsTypesIDList,
				sSelectedOwnersIDList);

			grdOutputsLoad.Restore(oReportOutputsLoad.MainTable);

            grcOutputsLoad_UserName.Visible = !optGroupByBrigades.Checked;
			grcOutputsLoad_DateConfirm.Visible = (optDetailModeDetail.Checked || optDetailModeDate.Checked);
			grcOutputsLoad_ERPCode.Visible =
			grcOutputsLoad_PartnerName.Visible =
			grcOutputsLoad_CarAlias.Visible = 
				optDetailModeDetail.Checked;
			//grdOutputs.Select();

			WaitOff(this);

			return (oReportOutputsLoad.ErrorNumber == 0);
		}

		private bool grdOutputsValidate_Restore()
		{
			WaitOn(this);

			TermsSelect();

			grdOutputsValidate.DataSource = null;

			oReportOutputsValidate.ReportForSalary(
				"OutputsValidate",
				dDateBeg, dDateEnd,
				sDetailMode,
                sGroupBy,
				sSelectedUsersIDList,
				null,
				sSelectedOutputsTypesIDList,
				sSelectedOwnersIDList);

			grdOutputsValidate.Restore(oReportOutputsValidate.MainTable);

			grcOutputsValidate_UserName.Visible = !optGroupByBrigades.Checked;
			grcOutputsValidate_DateConfirm.Visible = (optDetailModeDetail.Checked || optDetailModeDate.Checked);
			grcOutputsValidate_ERPCode.Visible =
			grcOutputsValidate_PartnerName.Visible =
			grcOutputsValidate_CarAlias.Visible =
				optDetailModeDetail.Checked;
			//grdOutputs.Select();

			WaitOff(this);

			return (oReportOutputsValidate.ErrorNumber == 0);
		}

		private bool grdMovings_Restore()
		{
			WaitOn(this);

			TermsSelect();

			grdMovings.DataSource = null;

			oReportMovings.ReportForSalary(
				"Movings",
				dDateBeg, dDateEnd,
				sDetailMode,
                sGroupBy,
				sSelectedUsersIDList,
				null,
				null,
				sSelectedOwnersIDList);

			grdMovings.Restore(oReportMovings.MainTable);

            grcMovings_UserName.Visible = !optGroupByBrigades.Checked;
			grcMovings_DateConfirm.Visible = (optDetailModeDetail.Checked || optDetailModeDate.Checked);

			WaitOff(this);

			return (oReportMovings.ErrorNumber == 0);
		}

		private bool grdInventories_Restore()
		{
			WaitOn(this);

			TermsSelect();

			grdInventories.DataSource = null;

			oReportInventories.ReportForSalary(
				"Inventories",
				dDateBeg, dDateEnd,
				sDetailMode,
                sGroupBy,
				sSelectedUsersIDList,
				null,
				null,
				sSelectedOwnersIDList);

			grdInventories.Restore(oReportInventories.MainTable);

            grcInventories_UserName.Visible = !optGroupByBrigades.Checked;
			grcInventories_DateConfirm.Visible = (optDetailModeDetail.Checked || optDetailModeDate.Checked);

			WaitOff(this);

			return (oReportInventories.ErrorNumber == 0);
		}

		private bool grdSalaryExtraWorks_Restore()
		{
			WaitOn(this);

			TermsSelect();

			grdSalaryExtraWorks.DataSource = null;

			oReportSalaryExtraWorks.ReportForSalary(
				"SalaryExtraWorks",
				dDateBeg, dDateEnd,
				sDetailMode,
                sGroupBy,
				sSelectedUsersIDList,
				null,
				null,
				sSelectedOwnersIDList);

			grdSalaryExtraWorks.Restore(oReportSalaryExtraWorks.MainTable);

            grcSalaryExtraWorks_UserName.Visible = !optGroupByBrigades.Checked;
			grcSalaryExtraWorks_DateConfirm.Visible = (optDetailModeDetail.Checked || optDetailModeDate.Checked);

			grcSalaryExtraWorks_Price.Visible =
			grcSalaryExtraWorks_Qnt.Visible =
			grcSalaryExtraWorks_WorkName.Visible =
				optDetailModeDetail.Checked && optGroupByUsers.Checked;

			WaitOff(this);

			return (oReportSalaryExtraWorks.ErrorNumber == 0);
		}

		private bool grdTotal_Restore()
		{
			WaitOn(this);

			TermsSelect();

			grdTotal.DataSource = null;

			oReportTotal.ReportForSalary(
				"Total",
				dDateBeg, dDateEnd, 
				sDetailMode,
                sGroupBy,
				sSelectedUsersIDList,
				sSelectedInputsTypesIDList,
				sSelectedOutputsTypesIDList,
				sSelectedOwnersIDList);

			grdTotal.Restore(oReportTotal.MainTable);

            grcTotal_UserName.Visible = !optGroupByBrigades.Checked;
			grcTotal_DateConfirm.Visible = (optDetailModeDetail.Checked || optDetailModeDate.Checked);
			grcTotal_ERPCode.Visible =
			grcTotal_PartnerName.Visible =
				optDetailModeDetail.Checked;
			//grdOutputs.Select();

			WaitOff(this);

			return (oReportTotal.ErrorNumber == 0);
		}

		private bool grdPieceWorks_Restore()
		{
			WaitOn(this);

			TermsSelect();

			grdPieceWorks.DataSource = null;

			oReportPieceWorks.ReportForSalary(
				"Money",
				dDateBeg, dDateEnd,
				sDetailMode,
                sGroupBy,
				sSelectedUsersIDList,
				sSelectedInputsTypesIDList,
				sSelectedOutputsTypesIDList,
				sSelectedOwnersIDList);

			grdPieceWorks.Restore(oReportPieceWorks.MainTable);

            grcPieceWorks_UserName.Visible = !optGroupByBrigades.Checked;
			grcPieceWorks_DateConfirm.Visible = (optDetailModeDetail.Checked || optDetailModeDate.Checked);

			WaitOff(this);

			return (oReportPieceWorks.ErrorNumber == 0);
		}

		private void TermsSelect()
		{
			dDateBeg = dDateEnd = null;
			if (!bUseTimes)
			{
				if (!dtrDates.dtpBegDate.IsEmpty)
				{
					dDateBeg = dtrDates.dtpBegDate.Value.Date;
				}
				if (!dtrDates.dtpEndDate.IsEmpty)
				{
					dDateEnd = dtrDates.dtpEndDate.Value.Date;
				}
			}
			else
			{
				if (!dtrDatesTimes.dtpBegDate.IsEmpty)
				{
					dDateBeg = dtrDatesTimes.dtpBegDate.Value; 
				}
				if (!dtrDatesTimes.dtpEndDate.IsEmpty)
				{
					dDateEnd = dtrDatesTimes.dtpEndDate.Value;
				}
			}

			// группировка
			/*bGroupBy = (optGroupByBrigades.Checked); // true - по бригадам*/
            sGroupBy = (optGroupByBrigades.Checked ? "B" : (optGroupByShifts.Checked ? "S" : "E"));

			sDetailMode = "TOTAL"; // (optDetailModeTotal.Checked)
			if (optDetailModeDetail.Checked)
				sDetailMode = "DETAIL";
			if (optDetailModeDate.Checked)
				sDetailMode = "DATE";

			if (sSelectedUsersIDList != null && sSelectedUsersIDList.Length == 0)
				sSelectedUsersIDList = null;
			if (sSelectedInputsTypesIDList != null && sSelectedInputsTypesIDList.Length == 0)
				sSelectedInputsTypesIDList = null;
			if (sSelectedOutputsTypesIDList != null && sSelectedOutputsTypesIDList.Length == 0)
				sSelectedOutputsTypesIDList = null;
			if (sSelectedOwnersIDList != null && sSelectedOwnersIDList.Length == 0)
				sSelectedOwnersIDList = null;
		}

	#endregion

	#region Filters Choose

		#region Users

		private void btnUsersChoose_Click(object sender, EventArgs e)
		{
			_SelectedIDList = null;
			sSelectedUsersIDList = "";

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

				tabInputsUnload.IsNeedRestore =
				tabInputsAccept.IsNeedRestore =
				tabTrafficsFramesHi.IsNeedRestore =
				tabTrafficsFramesLo.IsNeedRestore =
				tabOutputsPicking.IsNeedRestore =
				tabOutputsLoad.IsNeedRestore =
				tabOutputsValidate.IsNeedRestore =
				tabMovings.IsNeedRestore = 
				tabInventories.IsNeedRestore = 
				tabSalaryExtraWorks.IsNeedRestore = 
				tabTotal.IsNeedRestore =
				tabPieceWorks.IsNeedRestore = 
					true;
			}

			if (sSelectedUsersIDList != null && sSelectedUsersIDList.Length == 0)
			{
				sSelectedUsersIDList = null;
			}
			_SelectedIDList = null;
		}

		private void btnUsersClear_Click(object sender, EventArgs e)
		{
			tabInputsUnload.IsNeedRestore =
			tabInputsAccept.IsNeedRestore =
			tabTrafficsFramesHi.IsNeedRestore =
			tabTrafficsFramesLo.IsNeedRestore =
			tabOutputsPicking.IsNeedRestore =
			tabOutputsLoad.IsNeedRestore =
			tabOutputsValidate.IsNeedRestore =
			tabMovings.IsNeedRestore =
			tabInventories.IsNeedRestore =
			tabSalaryExtraWorks.IsNeedRestore =
			tabTotal.IsNeedRestore =
			tabPieceWorks.IsNeedRestore =
				true;
			
			ttToolTip.SetToolTip(txtUsersChoosen, "не выбраны");
			sSelectedUsersIDList = null;
			txtUsersChoosen.Text = "";
		}

		#endregion

		#region InputsTypes

		private void btnInputsTypesChoose_Click(object sender, EventArgs e)
		{
			_SelectedIDList = null;
			_SelectedText = "";

			Input oInputForType = new Input();
			oInputForType.FillTableInputsTypes();
			if (oInputForType.ErrorNumber != 0 || oInputForType.TableInputsTypes == null)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных...");
				return;
			}
			if (oInputForType.TableInputsTypes.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Нет данных...");
				return;
			}

			if (StartForm(new frmSelectID(this, oInputForType.TableInputsTypes, "Name", "Тип прихода", true)) == DialogResult.Yes)
			{
				if (_SelectedIDList == null || !_SelectedIDList.Contains(","))
				{
					btnInputsTypesClear_Click(null, null);
					return;
				}

				sSelectedInputsTypesIDList = "," + _SelectedIDList;

				txtInputsTypesChoosen.Text = _SelectedText;
				ttToolTip.SetToolTip(txtInputsTypesChoosen, txtInputsTypesChoosen.Text);

				tabInputsUnload.IsNeedRestore =
				tabInputsAccept.IsNeedRestore =
				tabTotal.IsNeedRestore =
				tabPieceWorks.IsNeedRestore =
					true;
			}

			_SelectedIDList = null;
			_SelectedText = "";
		}

		private void btnInputsTypesClear_Click(object sender, EventArgs e)
		{
			tabInputsUnload.IsNeedRestore =
			tabInputsAccept.IsNeedRestore =
			tabTotal.IsNeedRestore =
			tabPieceWorks.IsNeedRestore =
				true;

			ttToolTip.SetToolTip(txtInputsTypesChoosen, "не выбраны");
			sSelectedInputsTypesIDList = "";
			txtInputsTypesChoosen.Text = "";
		}

		#endregion

		#region OutputsTypes

		private void btnOutputsTypesChoose_Click(object sender, EventArgs e)
		{
			_SelectedIDList = null;
			_SelectedText = "";

			Output oOutputForType = new Output();
			oOutputForType.FillTableOutputsTypes();
			if (oOutputForType.ErrorNumber != 0 || oOutputForType.TableOutputsTypes == null)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных...");
				return;
			}
			if (oOutputForType.TableOutputsTypes.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Нет данных...");
				return;
			}

			if (StartForm(new frmSelectID(this, oOutputForType.TableOutputsTypes, "Name", "Тип расхода", true)) == DialogResult.Yes)
			{
				if (_SelectedIDList == null || !_SelectedIDList.Contains(","))
				{
					btnOutputsTypesClear_Click(null, null);
					return;
				}

				sSelectedOutputsTypesIDList = "," + _SelectedIDList;

				txtOutputsTypesChoosen.Text = _SelectedText;
				ttToolTip.SetToolTip(txtOutputsTypesChoosen, txtOutputsTypesChoosen.Text);

				tabOutputsPicking.IsNeedRestore =
				tabOutputsLoad.IsNeedRestore =
				tabOutputsValidate.IsNeedRestore =
				tabTotal.IsNeedRestore =
				tabPieceWorks.IsNeedRestore =
					true;
			}

			_SelectedIDList = null;
			_SelectedText = "";
		}

		private void btnOutputsTypesClear_Click(object sender, EventArgs e)
		{
			tabOutputsPicking.IsNeedRestore =
			tabOutputsLoad.IsNeedRestore =
			tabOutputsValidate.IsNeedRestore = 
			tabTotal.IsNeedRestore =
			tabPieceWorks.IsNeedRestore =
				true;

			ttToolTip.SetToolTip(txtOutputsTypesChoosen, "не выбраны");
			sSelectedOutputsTypesIDList = "";
			txtOutputsTypesChoosen.Text = "";
		}

		#endregion 

		#region Owners

		private void btnOwnersChoose_Click(object sender, EventArgs e)
		{
			_SelectedIDList = null;
			_SelectedText = "";

			Partner oOwner = new Partner();
			oOwner.FilterOwner = true;
			// oOwner.FilterSeparatePicking = true; // если нужны только непофигисты
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

				tabInputsUnload.IsNeedRestore =
				tabInputsAccept.IsNeedRestore =
				tabOutputsPicking.IsNeedRestore =
				tabOutputsLoad.IsNeedRestore =
				tabOutputsValidate.IsNeedRestore = 
				tabMovings.IsNeedRestore =
				tabInventories.IsNeedRestore =
				tabTotal.IsNeedRestore =
				tabPieceWorks.IsNeedRestore =
					true;
			}

			_SelectedIDList = null;
			_SelectedText = "";
		}

		private void btnOwnersClear_Click(object sender, EventArgs e)
		{
			tabInputsUnload.IsNeedRestore =
			tabInputsAccept.IsNeedRestore =
			tabOutputsPicking.IsNeedRestore =
			tabOutputsLoad.IsNeedRestore =
			tabOutputsValidate.IsNeedRestore = 
			tabMovings.IsNeedRestore =
			tabInventories.IsNeedRestore =
			tabTotal.IsNeedRestore =
			tabPieceWorks.IsNeedRestore =
				true;

			ttToolTip.SetToolTip(txtOwnersChoosen, "не выбраны");
			sSelectedOwnersIDList = "";
			txtOwnersChoosen.Text = "";
		}

		#endregion

	#endregion
		
	#region Menu Print

		private void btnPrint_Click(object sender, EventArgs e)
		{
			//mnuPrint.Show(btnPrint, new Point());

			string sText = "";
			if (dDateBeg.HasValue)
			{
				sText += ((DateTime)dDateBeg).ToString("dd.MM.yyyy");
				if (dDateEnd.HasValue)
					sText += " - ";
			}
			if (dDateEnd.HasValue)
				sText += ((DateTime)dDateEnd).ToString("dd.MM.yyyy");

			switch (tcList.SelectedTab.Name)
			{
				case "tabInputsUnload":
					if (oReportInputsUnload.MainTable.Rows.Count == 0 || grdInputsUnload.Rows.Count == 0) 
						return;

					DataTable dtInputsUnload = CopyTable(oReportInputsUnload.MainTable, "dtInputsUnload", "IsNormal = true", "BrigadeName, UserName");

					repForSalary repInputsUnload = new repForSalary("Выгрузка: " + sText, "INPUTSUNLOAD", optGroupByBrigades.Checked);
					StartForm(new frmActiveReport(dtInputsUnload, repInputsUnload));
					break;

				case "tabInputsAccept":
					if (oReportInputsAccept.MainTable.Rows.Count  == 0 || grdInputsAccept.Rows.Count == 0) 
						return;

					DataTable dtInputsAccept = CopyTable(oReportInputsAccept.MainTable, "dtInputsAccept", "IsNormal = true", "BrigadeName, UserName");

					repForSalary repInputsAccept = new repForSalary("Приход: " + sText, "INPUTSACCEPT", optGroupByBrigades.Checked);
					StartForm(new frmActiveReport(dtInputsAccept, repInputsAccept));
					break;

				case "tabTrafficsFramesHi":
					if (oReportTrafficsFramesHi.MainTable.Rows.Count == 0 || grdTrafficsFramesHi.Rows.Count == 0)
						return;

					DataTable dtTrafficsFramesHi = CopyTable(oReportTrafficsFramesHi.MainTable, "dtTrafficsFramesHi", "IsNormal = true", "BrigadeName, UserName");

					repForSalary repTrafficsFramesHi = new repForSalary("Подъем/спуск паллет: " + sText, "TRAFFICSFRAMESHI", optGroupByBrigades.Checked);
					StartForm(new frmActiveReport(dtTrafficsFramesHi, repTrafficsFramesHi));
					break;

                case "tabTrafficsFramesLo":
                    if (oReportTrafficsFramesLo.MainTable.Rows.Count == 0 || grdTrafficsFramesLo.Rows.Count == 0)
                        return;

					DataTable dtTrafficsFramesLo = CopyTable(oReportTrafficsFramesLo.MainTable, "dtTrafficsFramesLo", "IsNormal = true", "BrigadeName, UserName");

					repForSalary repTrafficsFramesLo = new repForSalary("Перемещение паллет: " + sText, "TRAFFICSFRAMESLO", optGroupByBrigades.Checked);
					StartForm(new frmActiveReport(dtTrafficsFramesLo, repTrafficsFramesLo));
                    break;

                case "tabOutputsPicking":
					if (oReportOutputsPicking.MainTable.Rows.Count == 0 || grdOutputsPicking.Rows.Count == 0)
						return;

					DataTable dtOutputsPicking = CopyTable(oReportOutputsPicking.MainTable, "dtOutputsPicking", "IsNormal = true", "BrigadeName, UserName");

					repForSalary repOutputsPicking = new repForSalary("Пикинг: " + sText, "OUTPUTSPICKING", optGroupByBrigades.Checked);
					StartForm(new frmActiveReport(dtOutputsPicking, repOutputsPicking));
					break;

				case "tabOutputsLoad":
					if (oReportOutputsLoad.MainTable.Rows.Count == 0 || grdOutputsLoad.Rows.Count == 0)
						return;

					DataTable dtOutputsLoad = CopyTable(oReportOutputsLoad.MainTable, "dtOutputsLoad", "IsNormal = true", "BrigadeName, UserName");

					repForSalary repOutputsLoad = new repForSalary("Загрузка: " + sText, "OUTPUTSLOAD", optGroupByBrigades.Checked);
					StartForm(new frmActiveReport(dtOutputsLoad, repOutputsLoad));
					break;

				case "tabOutputsValidate":
					if (oReportOutputsValidate.MainTable.Rows.Count == 0 || grdOutputsValidate.Rows.Count == 0)
						return;

					DataTable dtOutputsValidate = CopyTable(oReportOutputsValidate.MainTable, "dtOutputsValidate", "IsNormal = true", "BrigadeName, UserName");

					repForSalary repOutputsValidate = new repForSalary("Контроль за загрузкой: " + sText, "OUTPUTSVALIDATE", optGroupByBrigades.Checked);
					StartForm(new frmActiveReport(dtOutputsValidate, repOutputsValidate));
					break;

				case "tabMovings":
					if (oReportMovings.MainTable.Rows.Count == 0 || grdMovings.Rows.Count == 0)
						return;

					DataTable dtMovings = CopyTable(oReportMovings.MainTable, "dtMovings", "IsNormal = true", "BrigadeName, UserName");

					repForSalary repMovings = new repForSalary("Внутрискладское перемещение коробок: " + sText, "MOVINGS", optGroupByBrigades.Checked);
					StartForm(new frmActiveReport(dtMovings, repMovings));
					break;

				case "tabInventories":
					if (oReportInventories.MainTable.Rows.Count == 0 || grdInventories.Rows.Count == 0)
						return;

					DataTable dtInventories = CopyTable(oReportInventories.MainTable, "dtInventories", "IsNormal = true", "BrigadeName, UserName");

					repForSalary repInventories = new repForSalary("Ревизия ячеек: " + sText, "INVENTORIES", optGroupByBrigades.Checked);
					StartForm(new frmActiveReport(dtInventories, repInventories));
					break;

				case "tabSalaryExtraWorks":
					if (oReportSalaryExtraWorks.MainTable.Rows.Count == 0 || grdSalaryExtraWorks.Rows.Count == 0)
						return;

					DataTable dtSalaryExtraWorks = CopyTable(oReportSalaryExtraWorks.MainTable, "dtSalaryExtraWorks", "IsNormal = true", "BrigadeName, UserName");

					repForSalary repSalaryExtraWorks = new repForSalary("Дополнительные внутрискладские работы: " + sText, "SALARYEXTRAWORKS", optGroupByBrigades.Checked);
					StartForm(new frmActiveReport(dtSalaryExtraWorks, repSalaryExtraWorks));
					break;

				default:
					break;
			}
		}

	#endregion

	#region Terms clear

		private void btnClearTerms_Click(object sender, EventArgs e)
		{
			dtrDates.dtpBegDate.Value = DateTime.Now.Date.AddDays(-7);
			dtrDates.dtpEndDate.Value = DateTime.Now.Date;

			dtrDatesTimes.dtpBegDate.Value = DateTime.Now.Date.AddDays(-1);
			dtrDatesTimes.dtpEndDate.Value = DateTime.Now.Date.AddMinutes(-1);

			chkDatesTimes.Checked = false;
			chkDatesTimes_CheckedChanged(null, null);

			optGroupByUsers.Checked = true;

			btnUsersClear_Click(null, null);
			btnInputsTypesClear_Click(null, null);
			btnOutputsTypesClear_Click(null, null);

			tabInputsUnload.IsNeedRestore =
			tabInputsAccept.IsNeedRestore =
			tabTrafficsFramesHi.IsNeedRestore =
			tabTrafficsFramesLo.IsNeedRestore =
			tabOutputsPicking.IsNeedRestore =
			tabOutputsLoad.IsNeedRestore =
			tabOutputsValidate.IsNeedRestore =
			tabMovings.IsNeedRestore =
			tabInventories.IsNeedRestore =
			tabSalaryExtraWorks.IsNeedRestore =
			tabTotal.IsNeedRestore =
			tabPieceWorks.IsNeedRestore =
				true;
		}
		
	#endregion

		private void chkDatesTimes_CheckedChanged(object sender, EventArgs e)
		{
			bUseTimes = chkDatesTimes.Checked;
			dtrDatesTimes.Visible = chkDatesTimes.Checked;
			dtrDates.Visible = !chkDatesTimes.Checked;
		}

        private void optGroupByShifts_CheckedChanged(object sender, EventArgs e)
        {
            if (optGroupByShifts.Checked)
            {
                grcInputsUnload_UserName.HeaderText =
                    grcInputsAccept_UserName.HeaderText =
                    grcTrafficsFramesHi_UserName.HeaderText =
                    grcTrafficsFramesLo_UserName.HeaderText =
                    grcOutputsPicking_UserName.HeaderText =
                    grcOutputsLoad_UserName.HeaderText =
                    grcOutputsValidate_UserName.HeaderText =
                    grcMovings_UserName.HeaderText =
                    grcInventories_UserName.HeaderText =
                    grcSalaryExtraWorks_UserName.HeaderText =
                    grcTotal_UserName.HeaderText =
                    grcPieceWorks_UserName.HeaderText =
                    "Смена";
                grcInputsUnload_BrigadeName.HeaderText =
                    grcInputsAccept_BrigadeName.HeaderText =
                    grcTrafficsFramesHi_BrigadeName.HeaderText =
                    grcTrafficsFramesLo_BrigadeName.HeaderText =
                    grcOutputsPicking_BrigadeName.HeaderText =
                    grcOutputsLoad_BrigadeName.HeaderText =
                    grcOutputsValidate_BrigadeName.HeaderText =
                    grcMovings_BrigadeName.HeaderText =
                    grcInventories_BrigadeName.HeaderText =
                    grcSalaryExtraWorks_BrigadeName.HeaderText =
                    grcTotal_BrigadeName.HeaderText =
                    grcPieceWorks_BrigadeName.HeaderText =
                    "Старший смены";
            }
            else
            {
                grcInputsUnload_UserName.HeaderText =
                    grcInputsAccept_UserName.HeaderText =
                    grcTrafficsFramesHi_UserName.HeaderText =
                    grcTrafficsFramesLo_UserName.HeaderText =
                    grcOutputsPicking_UserName.HeaderText =
                    grcOutputsLoad_UserName.HeaderText =
                    grcOutputsValidate_UserName.HeaderText =
                    grcMovings_UserName.HeaderText =
                    grcInventories_UserName.HeaderText =
                    grcSalaryExtraWorks_UserName.HeaderText =
                    grcTotal_UserName.HeaderText =
                    grcPieceWorks_UserName.HeaderText =
                    "Сотрудник";
                grcInputsUnload_BrigadeName.HeaderText =
                    grcInputsAccept_BrigadeName.HeaderText =
                    grcTrafficsFramesHi_BrigadeName.HeaderText =
                    grcTrafficsFramesLo_BrigadeName.HeaderText =
                    grcOutputsPicking_BrigadeName.HeaderText =
                    grcOutputsLoad_BrigadeName.HeaderText =
                    grcOutputsValidate_BrigadeName.HeaderText =
                    grcMovings_BrigadeName.HeaderText =
                    grcInventories_BrigadeName.HeaderText =
                    grcSalaryExtraWorks_BrigadeName.HeaderText =
                    grcTotal_BrigadeName.HeaderText =
                    grcPieceWorks_BrigadeName.HeaderText =
                    "Бригада";
            }
        }
	}
}