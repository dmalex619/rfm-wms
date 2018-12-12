using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace WMSSuitable
{
	public partial class repPackings : DataDynamics.ActiveReports.ActiveReport3
	{

		public repPackings()
		{
			InitializeComponent();

			txtUserAlias.Text = ((RFMBaseClasses.RFMFormBase)System.Windows.Forms.Application.OpenForms[0]).UserInfo.UserAlias;
		}

		private void detail_Format(object sender, EventArgs e)
		{
			if (Convert.ToBoolean(Fields["Weighting"].Value) ||
				Convert.ToDecimal(Fields["InBox"].Value) != Convert.ToInt32(Fields["InBox"].Value))
				txtInBox.OutputFormat = "### ###.000";
		}
	}
}
