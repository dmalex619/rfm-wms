using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace WMSSuitable
{
	public partial class repInputBillGoodStateArrange : DataDynamics.ActiveReports.ActiveReport3
	{
		int nInputID;

		public repInputBillGoodStateArrange()
		{
			InitializeComponent();
		}

		private void detail_Format(object sender, EventArgs e)
		{
			nInputID = Convert.ToInt32(Fields["InputID"].Value);

			if ((decimal)Fields["QntArrangedDiff"].Value == 0)
			{
				txtQntArrangedDiff.Value =
				txtQntArrangedDiffW.Value =
				txtBoxArrangedDiff.Value = "";
				detail.BackColor = Color.Transparent;
			}

			if ((decimal)Fields["QntArrangedDiff"].Value > 0)
			{
				detail.BackColor = Color.FromArgb(50, 0, 200, 0);
			}
			if ((decimal)Fields["QntArrangedDiff"].Value < 0)
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
