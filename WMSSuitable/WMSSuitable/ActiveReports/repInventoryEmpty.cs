using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace WMSSuitable
{
	public partial class repInventoryEmpty : DataDynamics.ActiveReports.ActiveReport3
	{
		int nInventoryID;
		DateTime dDateInventory; 

		public repInventoryEmpty()
		{
			InitializeComponent();
		}

		private void pageHeader_Format(object sender, EventArgs e)
		{
			txtDateInventory.Text = dDateInventory.ToString("dd.MM.yyyy");
		}

		private void repInventoryEmpty_FetchData(object sender, FetchEventArgs eArgs)
		{
			nInventoryID = Convert.ToInt32(Fields["ID"].Value);
			dDateInventory = Convert.ToDateTime(Fields["DateInventory"].Value);
		}

	}
}
