using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace WMSSuitable
{
	public partial class repInventoryBillContents : DataDynamics.ActiveReports.ActiveReport3
	{

		public repInventoryBillContents()
		{
			InitializeComponent();
		}

		private void groupHeaderAll_Format(object sender, EventArgs e)
		{
			txtDateInventory.Text = (Convert.ToDateTime(Fields["DateInventory"].Value)).ToString("dd.MM.yyyy");
		}

        private void detail_Format(object sender, EventArgs e)
        {
            if (Fields["PackingAlias"].Value.ToString().Length > 0)
            {
                tbOwnerName.Text = Fields["OwnerName"].Value.ToString();
                tbGoodStateName.Text = Fields["GoodStateName"].Value.ToString();
                tbGoodArticul.Text = Fields["GoodArticul"].Value.ToString();
                tbPackingAlias.Text = Fields["PackingAlias"].Value.ToString();
                tbPackingAlias.Font = new Font(tbPackingAlias.Font, FontStyle.Regular);
            }
            else
            {
                tbOwnerName.Text = Fields["FixedOwnerName"].Value.ToString();
                tbGoodStateName.Text = Fields["FixedGoodStateName"].Value.ToString();
                tbGoodArticul.Text = Fields["FixedGoodArticul"].Value.ToString();
                tbPackingAlias.Text = Fields["FixedPackingAlias"].Value.ToString();
                tbPackingAlias.Font = new Font(tbPackingAlias.Font, FontStyle.Strikeout);
            }
        }
	}
}
