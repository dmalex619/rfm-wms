using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace WMSSuitable
{
	public partial class repOutputBillForConfirm : DataDynamics.ActiveReports.ActiveReport3
	{
		private int nOutputID;
        private string sChargeOrder;
		private bool bWeighting = false;
		private bool bPrintDecimals = false;

		public repOutputBillForConfirm()
		{
			InitializeComponent();
		}

		private void detail_Format(object sender, EventArgs e)
		{
			nOutputID = Convert.ToInt32(Fields["OutputID"].Value);
            sChargeOrder = Fields["ChargeOrder"].Value.ToString();
			bWeighting = Convert.ToBoolean(Fields["Weighting"].Value);
			bPrintDecimals = Convert.ToBoolean(Fields["PrintDecimals"].Value);

			if (bWeighting)
			{
				txtQntSum.OutputFormat = "### ##0.000";
			}
			else
			{
				txtQntSum.OutputFormat = "### ### ##0";
			}

            // Добавление к товару срока годности
            string sDateValid = "";
            DateTime dDateValid;
            if (DateTime.TryParse(Fields["DateValid"].Value.ToString(), out dDateValid))
                sDateValid = " (" + dDateValid.ToShortDateString() + ")";
            txtGoodAlias.Text = Fields["GoodAlias"].Value.ToString() + sDateValid;
		}

        private void groupOutputIDFooter_Format(object sender, EventArgs e)
        {
            txtChargeOrder.Text = sChargeOrder;
        }

	}
}
