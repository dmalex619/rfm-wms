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
	public partial class frmReportOutputsQntDifferences : RFMFormChild
	{
		private Report oReport;  
		string sOutputsList = "";

		public frmReportOutputsQntDifferences(string _sOutputsList)
		{
			oReport = new Report();
			if (oReport.ErrorNumber != 0) 
				IsValid = false;
			if (IsValid)
				InitializeComponent();

			sOutputsList = _sOutputsList;
		}

		private void frmReportOutputsQntDifferences_Load(object sender, EventArgs e)
		{
			grcQntWished.AgrType = 
			grcQntSelected.AgrType = 
			grcQntPicked.AgrType = 
			grcQntConfirmed.AgrType = 
				EnumAgregate.Sum;

			lblInfo.Text = lblInfo.Text.Replace("#", RFMUtilities.Occurs(sOutputsList, ",").ToString().Trim());
			opt1_CheckedChanged(null, null);
			//btnFilter_Click(null, null);
		}

		#region Buttons

		private void btnExit_Click(object sender, EventArgs e)
		{
			Dispose();
		}

		private void btnHelp_Click(object sender, EventArgs e)
		{
			RFMHelpUtilities.HelpShow(this, hpHelp);
		}

		private void btnFilter_Click(object sender, EventArgs e)
		{
			grdData_Restore();
		}

		private void btnExcel_Click(object sender, EventArgs e)
		{
			grdData.ExportData();
		}

		#endregion

		#region Restore

		private bool grdData_Restore()
		{
			string sQntFieldName1 = "", sQntFieldName2 = "";
			if (optWished1.Checked) sQntFieldName1 = "QntWished";
			if (optSelected1.Checked) sQntFieldName1 = "QntSelected";
			if (optPicked1.Checked) sQntFieldName1 = "QntPicked";
			if (optConfirmed1.Checked) sQntFieldName1 = "QntConfirmed";
			if (optWished2.Checked) sQntFieldName2 = "QntWished";
			if (optSelected2.Checked) sQntFieldName2 = "QntSelected";
			if (optPicked2.Checked) sQntFieldName2 = "QntPicked";
			if (optConfirmed2.Checked) sQntFieldName2 = "QntConfirmed";

			sQntFieldName1 = sQntFieldName1.ToUpper();
			sQntFieldName2 = sQntFieldName2.ToUpper();

            string sUnit = "";
            if (optUnit1.Checked) sUnit = "U";
            if (optUnit2.Checked) sUnit = "B";
            if (optUnit3.Checked) sUnit = "P";

			decimal nWeightDiffPrc = 0;
			if (numWeightDiffPrc.Enabled)
				nWeightDiffPrc = numWeightDiffPrc.Value;

			RFMCursorWait.Set(true);

			oReport.ClearError();
            oReport.ReportOutputsQntDifferences(sOutputsList, sUnit, optByPackings.Checked, 
                !chkIncludeWeighting.Checked, nWeightDiffPrc, 
				sQntFieldName1, sQntFieldName2);

			grdData.Restore(oReport.MainTable);

			grcQntPicked.Visible = sQntFieldName1.Contains("PICKED") || sQntFieldName2.Contains("PICKED");
			
			grcDateOutput.Visible =
			grcOwnerName.Visible =
			grcPartnerName.Visible = 
			grcERPCode.Visible = 
				optByOutputs.Checked;

			RFMCursorWait.Set(false);

			grdData.Select();

			return (oReport.ErrorNumber == 0);
		}

		#endregion

		#region CellFormatting

		private void grdData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			RFMDataGridView grd = grdData;
			if (grd.Rows[e.RowIndex] == null)
				return;

			string sColumnName = grd.Columns[e.ColumnIndex].Name.ToUpper();

			DataGridViewRow r = grd.Rows[e.RowIndex];

			if (sColumnName.Contains("INBOX"))
			{
				if (Convert.IsDBNull(e.Value) || Convert.ToDecimal(e.Value) == 0)
				{
					e.Value = "";
				}
				else
				{
					if (!Convert.IsDBNull(r.Cells["grcWeighting"].Value) &&
						Convert.ToBoolean(r.Cells["grcWeighting"].Value) ||
						!Convert.IsDBNull(e.Value) && Convert.ToDecimal(e.Value) != Convert.ToInt32(e.Value))
					{
						e.CellStyle.Format = "### ### ### ##0.000";
					}
					else
					{
						e.CellStyle.Format = "### ### ### ###";
					}
				}
			}

			if (sColumnName.Contains("QNT"))
			{
				if (Convert.IsDBNull(e.Value) || Convert.ToDecimal(e.Value) == 0)
				{
					e.Value = "";
				}
				else
				{
					if (optUnit1.Checked)
					{  
						if (!Convert.IsDBNull(r.Cells["grcWeighting"].Value) &&
							Convert.ToBoolean(r.Cells["grcWeighting"].Value) ||
							!Convert.IsDBNull(e.Value) && Convert.ToDecimal(e.Value) != Convert.ToInt32(e.Value))
						{
							e.CellStyle.Format = "### ### ### ##0.000";
						}
						else
						{
							e.CellStyle.Format = "### ### ### ###";
						}
					}
					if (optUnit2.Checked) // коробки
					{
						e.CellStyle.Format = "### ### ### ##0.0";
					}
					if (optUnit3.Checked) // паллеты
					{
						e.CellStyle.Format = "### ### ### ##0.00";
					}
				}
			}
		}

		#endregion 

		private void opt1_CheckedChanged(object sender, EventArgs e)
		{
			optWished2.Enabled = 			
			optSelected2.Enabled = 
			optPicked2.Enabled =
			optConfirmed2.Enabled = 
				true; 
			if (optWished1.Checked)
			{
				if (optWished2.Checked)
					optConfirmed2.Checked = true;
				optWished2.Enabled = false; 
			}
			if (optSelected1.Checked)
			{
				if (optSelected2.Checked)
					optConfirmed2.Checked = true;
				optSelected2.Enabled = false;
			}
			if (optPicked1.Checked)
			{
				if (optPicked2.Checked)
					optConfirmed2.Checked = true;
				optPicked2.Enabled = false;
			}
			if (optConfirmed1.Checked)
			{
				if (optConfirmed2.Checked)
					optWished2.Checked = true;
				optConfirmed2.Enabled = false;
			}
		}

		private void chkIncludeWeighting_CheckedChanged(object sender, EventArgs e)
		{
			numWeightDiffPrc.Enabled = !chkIncludeWeighting.Checked;
		}
	}
}
