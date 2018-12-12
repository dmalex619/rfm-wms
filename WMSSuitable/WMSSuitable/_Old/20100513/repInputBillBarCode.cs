using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace WMSSuitable
{
	public partial class repInputBillBarCode : DataDynamics.ActiveReports.ActiveReport3
	{
		private int nInputID;
		private double nNormRetention = (double)2 / (double)3;
        private string sAddress;
        private decimal nCellHeight;

		public repInputBillBarCode()
		{
			InitializeComponent();
		}

		private void detail_Format(object sender, EventArgs e)
		{
			nInputID = Convert.ToInt32(Fields["InputID"].Value);

			if (Fields["Retention"].Value != DBNull.Value && Convert.ToInt32(Fields["Retention"].Value) != 0)
			{
				txtNormDateValid.Text =  (Convert.ToDateTime(Fields["DateInput"].Value)).AddDays((double)Math.Floor((double)(Convert.ToInt32(Fields["Retention"].Value) * nNormRetention))).ToString("dd.MM.yyyy");
			}
			else
			{
				txtNormDateValid.Text = "";
			}

            sAddress = Convert.ToString(Fields["Address"].Value);
            if (sAddress.Length > 0)
            {
                nCellHeight = Convert.ToDecimal(Fields["CellHeight"].Value);
                txtAddress.Text = (sAddress + " (" + nCellHeight.ToString("##0.00") + "ì)");
            }
            else txtAddress.Text = "";
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
