using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace WMSSuitable
{
	public partial class repMovingBill : DataDynamics.ActiveReports.ActiveReport3
	{
		private int nMovingID;

		public repMovingBill()
		{
			InitializeComponent();
		}

		private void detail_Format(object sender, EventArgs e)
		{
			nMovingID = Convert.ToInt32(Fields["MovingID"].Value);
			detail.BackColor = Color.Transparent;
			if (!Convert.IsDBNull(Fields["DateConfirm"].Value))
			{
				if ((decimal)Fields["QntWished"].Value != (decimal)Fields["QntConfirmed"].Value)
				{
					detail.BackColor = Color.LightPink;
				}
			}
			else
			{
				txtBoxConfirmed.Text = txtQntConfirmed.Text = txtQntConfirmed1.Text = ""; 
			}
		}

		private void pageFooter_Format(object sender, EventArgs e)
		{
			txtMovingIDFooter.Text = nMovingID.ToString();
		}
	}
}
