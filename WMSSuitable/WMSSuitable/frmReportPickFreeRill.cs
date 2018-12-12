using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RFMBaseClasses;
using WMSBizObjects;
using RFMPublic;

namespace WMSSuitable
{
	public partial class frmReportPickFreeRill: RFMFormChild
	{
		private Report oReport = new Report();

		
		public frmReportPickFreeRill()
		{
			InitializeComponent();
		}

		private void frmReportPickFreeRill_Load(object sender, EventArgs e)
		{
			RFMCursorWait.Set(true);
			tcList.SelectedTab = tabForFree;
			btnGo_Click(null,null);
			RFMCursorWait.Set(false);
		}
/*
		private bool tabTerms_Restore()
		{
		}

		private bool tabForFree_Restore()
		{
		}
*/
		private void btnGo_Click(object sender, EventArgs e)
		{
			dgvGoods_Restore();
		}

		private bool dgvGoods_Restore()
		{
			oReport.ReportPickFreeRills();
			if (oReport.ErrorNumber != 0)
				return false;
			if (oReport.DS.Tables.Count ==0 || oReport.DS.Tables[0].Rows.Count == 0)
			{
				RFMMessage.MessageBoxInfo("Нет товаров для перемещения!");
				return false;
			}
			dgvGoods.Restore(oReport.DS.Tables[0]);
			tmrRestore.Enabled = true;
			return (oReport.ErrorNumber == 0);
		}
		private bool dgvCells_Restore()
		{
			if (oReport.DS.Tables[0].Rows.Count == 0)
				return false;
			int nPackingID  = (int)((DataRowView)dgvGoods.CurrentRow.DataBoundItem)["PackingID"];
			dgvCells.Restore(CopyTable(oReport.DS.Tables[1], "dtCells", "PackingID = " + nPackingID.ToString().Trim(), ""));
			return true;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Dispose();
		}

		private void tmrRestore_Tick(object sender, EventArgs e)
		{
			tmrRestore.Enabled = false;
			if (dgvGoods.IsStatusRow(dgvGoods.CurrentRow.Index))
				return;
			else
				dgvCells_Restore();

		}

		private void dgvGoods_CurrentRowChanged(object sender)
		{
			if (dgvGoods.IsLockRowChanged)
				return;
			tmrRestore.Enabled = true;

		}

	}
}