using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace WMSSuitable
{
	public partial class repInputBillPallets : DataDynamics.ActiveReports.ActiveReport3
	{
		int nInputID;

		public repInputBillPallets()
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
	}
}
