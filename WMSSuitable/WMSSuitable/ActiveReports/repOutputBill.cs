using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace WMSSuitable
{
	public partial class repOutputBill : DataDynamics.ActiveReports.ActiveReport3
	{
		private int nOutputID;
        private string sChargeOrder;

		private bool bSelected;

		public repOutputBill(bool _bSelected)
		{
			InitializeComponent();
			bSelected = _bSelected;
		}

		private void detail_Format(object sender, EventArgs e)
		{
			nOutputID = Convert.ToInt32(Fields["OutputID"].Value);
            sChargeOrder = Fields["ChargeOrder"].Value.ToString();

			detail.BackColor = Color.Transparent; 
			if ((decimal)Fields["QntDiff"].Value > 0) 
				detail.BackColor = Color.LightGreen;
			if ((decimal)Fields["QntDiff"].Value < 0)
				detail.BackColor = Color.LightPink;
		}

		private void pageFooter_Format(object sender, EventArgs e)
		{
			txtOutputIDFooter.Text = nOutputID.ToString();
            txtChargeOrder.Text = sChargeOrder;
		}

		private void groupOutputID_Format(object sender, EventArgs e)
		{
			if (bSelected)
			{
				lblQntConfirmed.Text = lblQntConfirmed.Text.Replace("Факт", "Подбор");
				lblBoxConfirmed.Text = lblBoxConfirmed.Text.Replace("Факт", "Подбор");
                lblTitle1.Text = "Факт. подбор по зад.";
			}
		}

		private void groupOutputIDFooter_Format(object sender, EventArgs e)
		{
			if (bSelected)
			{
				lblTotalConfirmed.Text = lblTotalConfirmed.Text.Replace("отгружено", "подобрано");
			}
		}

	}
}
