using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace WMSSuitable
{
	/// <summary>
	/// Summary description for repOutputBillPallets.
	/// </summary>
	public partial class repOutputBillPallets : DataDynamics.ActiveReports.ActiveReport3
	{

		public repOutputBillPallets()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

		private void pageHeader_Format(object sender, EventArgs e)
		{
			if (Fields["DateConfirm"].Value == DBNull.Value)
			{
				txtDateConfirm.Text = "Не вып.";
			}
		}
	}
}
