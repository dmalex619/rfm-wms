using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace WMSSuitable
{
	public partial class repInventoryBillBlank : DataDynamics.ActiveReports.ActiveReport3
	{

		public repInventoryBillBlank()
		{
			InitializeComponent();
		}

		private void groupHeaderAll_Format(object sender, EventArgs e)
		{
			txtDateInventory.Text = (Convert.ToDateTime(Fields["DateInventory"].Value)).ToString("dd.MM.yyyy");
		}
	}
}
