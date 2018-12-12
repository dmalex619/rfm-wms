using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace WMSSuitable
{
	public partial class repInputBillPickingAddress : DataDynamics.ActiveReports.ActiveReport3
	{
		private int nInputID;

		public repInputBillPickingAddress()
		{
			InitializeComponent();
		}

		private void detail_Format(object sender, EventArgs e)
		{
			nInputID = Convert.ToInt32(Fields["InputID"].Value);
		}

		private void pageFooter_Format(object sender, EventArgs e)
		{
			txtInputIDFooter.Text = nInputID.ToString();
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

	}
}
