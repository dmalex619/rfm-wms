using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace WMSSuitable
{
	/// <summary>
	/// Summary description for NewActiveReport1.
	/// </summary>
	public partial class repInputBillAct : DataDynamics.ActiveReports.ActiveReport3
	{
		private int nInputID;

		public repInputBillAct(string _sWeName, string _sWeAddress)
		{
			InitializeComponent();

			txtWeName.Text = _sWeName;
			txtWeAddress.Text = _sWeAddress;
		
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
