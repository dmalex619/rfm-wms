using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace WMSSuitable
{
	public partial class repInputBillGoodState : DataDynamics.ActiveReports.ActiveReport3
	{
		private int nInputID;

		public repInputBillGoodState()
		{
			InitializeComponent();
		}

		private void detail_Format(object sender, EventArgs e)
		{
			nInputID = Convert.ToInt32(Fields["InputID"].Value);

			if ((decimal)Fields["QntDiff"].Value > 0)
			{
				detail.BackColor = Color.LightGreen;
			}
			if ((decimal)Fields["QntDiff"].Value < 0)
			{
				detail.BackColor = Color.LightPink;
			}
		}

		private void pageFooter_Format(object sender, EventArgs e)
		{
			txtInputIDFooter.Text = nInputID.ToString();
		}
	}
}
