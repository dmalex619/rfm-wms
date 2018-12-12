using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace WMSSuitable
{
	/// <summary>
	/// Summary description for InputBillBarCode.
	/// </summary>
	public partial class repInputBillBarCode : DataDynamics.ActiveReports.ActiveReport3
	{

		public repInputBillBarCode()
		{
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
