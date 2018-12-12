using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace WMSSuitable
{
	public partial class repInventoryBillFull : DataDynamics.ActiveReports.ActiveReport3
	{
		DateTime? dDateInventory = null;
		public repInventoryBillFull()
		{
			InitializeComponent();
		}

		private void groupHeaderAll_Format(object sender, EventArgs e)
		{
			if (!dDateInventory.HasValue)
			{
				try { dDateInventory = Convert.ToDateTime(Fields["DateInventory"].Value); }
				catch { }
			}

			if (dDateInventory.HasValue)
				txtDateInventory.Text = (Convert.ToDateTime(dDateInventory)).ToString("dd.MM.yyyy");
			else
				txtDateInventory.Text = "";
		}

		private void detail_BeforePrint(object sender, EventArgs e)
		{
			lineH.Y1 = detail.Height - (float)0.01;
			lineH.Y2 = lineH.Y1;
		}

		private void detail_Format(object sender, EventArgs e)
		{
			dDateInventory = Convert.ToDateTime(Fields["DateInventory"].Value);
		}
	}
}
