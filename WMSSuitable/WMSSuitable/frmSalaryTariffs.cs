using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RFMBaseClasses;
using RFMPublic;
using WMSBizObjects;

namespace WMSSuitable
{
	public partial class frmSalaryTariffs : RFMFormChild
	{
		private SalaryExtraWork oSalaryTariffsList; 

		public frmSalaryTariffs()
		{
			oSalaryTariffsList = new SalaryExtraWork();
			if (oSalaryTariffsList.ErrorNumber != 0) 
				IsValid = false;
			if (IsValid)
			{
				InitializeComponent();
			}
		}

		private void frmSalaryTariffs_Load(object sender, EventArgs e)
		{
			grdData_Restore();
			grdData.Select();
		}

		#region Buttons

		private void btnExit_Click(object sender, EventArgs e)
		{
			Dispose();
		}

		private void btnHelp_Click(object sender, EventArgs e)
		{
			RFMHelpUtilities.HelpShow(this, hpHelp);
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			int nSalaryTariffID = 0;
			if (grdData.Rows.Count > 0 && grdData.CurrentRow != null)
				nSalaryTariffID = -(int)grdData.CurrentRow.Cells["grcID"].Value;

			if (StartForm(new frmSalaryTariffsEdit(nSalaryTariffID)) == DialogResult.Yes)
			{
				nSalaryTariffID = (int)GotParam.GetValue(0);
				grdData_Restore();
				if (nSalaryTariffID > 0)
				{
					grdData.GridSource.Position = grdData.GridSource.Find(oSalaryTariffsList.ColumnID, nSalaryTariffID);
					if (grdData.GridSource.Position < 0)
					{
						grdData.GridSource.MoveFirst();
					}
				}
			}
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			if (grdData.CurrentRow == null || grdData.IsStatusRow(grdData.CurrentRow.Index))
				return;

			int nSalaryTariffID = (int)grdData.CurrentRow.Cells["grcID"].Value;
				
			if (StartForm(new frmSalaryTariffsEdit(nSalaryTariffID)) == DialogResult.Yes)
			{
				grdData_Restore();
			}
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (grdData.CurrentRow == null || grdData.IsStatusRow(grdData.CurrentRow.Index))
				return;

			int nSalaryTariffID = (int)grdData.CurrentRow.Cells["grcID"].Value;

			if (RFMMessage.MessageBoxYesNo("Удалить данные о тарифах?") == DialogResult.Yes)
			{
				oSalaryTariffsList.ClearError();
				if (oSalaryTariffsList.DeleteTariffs(nSalaryTariffID) && oSalaryTariffsList.ErrorNumber == 0)
				{
					grdData_Restore();
				}
			}
		}

		#endregion 

		#region Restore

		private bool grdData_Restore()
		{
			grdData.GetGridState();

			oSalaryTariffsList.ClearError();
			oSalaryTariffsList.FillTableSalaryTariffs();
			grdData.Restore(oSalaryTariffsList.TableSalaryTariffs);

			return (oSalaryTariffsList.ErrorNumber == 0);
		}

		#endregion
	}
}
