using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using WMSBizObjects;

namespace WMSSuitable
{
	/// <summary>
	/// Summary description for repTrafficFrameBillForOutput
	/// </summary>
	public partial class repTrafficFrameBillForOutput : DataDynamics.ActiveReports.ActiveReport3
	{
		private int nOutputID;
 
		public repTrafficFrameBillForOutput()
		{
			InitializeComponent();
		}

		private void detail_Format(object sender, EventArgs e)
		{
			nOutputID = Convert.ToInt32(Fields["OutputID"].Value);
		}

		private void pageHeader_BeforePrint(object sender, EventArgs e)
		{
			if (Convert.ToInt16(txtPageNumber.Text) > Convert.ToInt16(txtPageCount.Text))
			{
				reportInfo1.Visible = false;
				txtReportInfoProblem.Visible = true; 
				txtReportInfoProblem.Text = reportInfo1.FormatString.Replace("{PageNumber}", txtPageNumber.Text).Replace("{PageNumber}", txtPageCount.Text);
			}
		}

		private void pageFooter_Format(object sender, EventArgs e)
		{
			txtOutputIDFooter.Text = nOutputID.ToString();
		}

	}
}
