using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

using System.Data;
using WMSBizObjects;

namespace WMSSuitable
{
	/// <summary>
	/// Summary description for repTrafficGoodBill
	/// </summary>
	public partial class repTrafficGoodBill : DataDynamics.ActiveReports.ActiveReport3
	{
		private int nOutputID = 0;
        private string sChargeOrder = "";

		private float nTxtGoodAliasWidth;
        private float nDetailHeight;
        
        private DateTime? dDateOutput;
        private decimal nQntConfirmed;
        private decimal nInBox;

		public repTrafficGoodBill()
		{
			InitializeComponent();

			nTxtGoodAliasWidth = txtGoodAlias.Width;
            nDetailHeight = detail.Height;
		}

		private void detail_Format(object sender, EventArgs e)
		{
            nOutputID = Convert.ToInt32(Fields["OutputID"].Value);
            sChargeOrder = Fields["ChargeOrder"].Value.ToString();

            // 
			nQntConfirmed = Convert.ToDecimal(Fields["QntConfirmed"].Value); 
			if (nQntConfirmed == 0)
			{
				txtQntConfirmed.Text = txtBoxConfirmed.Text = "";
			}
			else
			{ 
				nInBox = Convert.ToDecimal(Fields["InBox"].Value);
				decimal nBoxConfirmed = Math.Floor(nQntConfirmed / nInBox);
				txtBoxConfirmed.Text = (nBoxConfirmed > 0) ? nBoxConfirmed.ToString() : "";
				nQntConfirmed = nQntConfirmed - nBoxConfirmed * nInBox;
				txtQntConfirmed.Value = (nQntConfirmed > 0) ? nQntConfirmed.ToString() : "";
			}

            if (!Convert.IsDBNull(Fields["DateOutput"].Value)) 
                dDateOutput = Convert.ToDateTime(Fields["DateOutput"].Value);
            else 
                dDateOutput = null;

            if (!Convert.IsDBNull(Fields["DatePrint"].Value))
                txtPrinted.Text = "#";
            else
                txtPrinted.Text = "";
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
            txtChargeOrder.Text = sChargeOrder;
		}

        private void groupOutputID_Format(object sender, EventArgs e)
        {
            if (nOutputID == 0)
                nOutputID = Convert.ToInt32(Fields["OutputID"].Value);

            if (Fields["DateOutput"].Value != null && !Convert.IsDBNull(Fields["DateOutput"].Value))
            {
                txtDateOutput.Text = ((DateTime)Fields["DateOutput"].Value).ToString("dd.MM.yyyy");
            }
            else
            {
                txtDateOutput.Text = "";
            }

            if (Convert.ToBoolean(Fields["ExistsNewTrafficsGoods"].Value))
                txtExistsNewTrafficsGoods.Text = "дно";
            else
                txtExistsNewTrafficsGoods.Text = "";
        }

        private void detail_BeforePrint(object sender, EventArgs e)
        {
            line1.Y1 = detail.Height - (float)0.01;
            line1.Y2 = line1.Y1; 
        }
    }
}
