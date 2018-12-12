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
	public partial class frmShifts : RFMFormChild
    {
        #region Fields
        private Shift oShift;
        private User oUser = new User();
        #endregion

        public frmShifts()
		{
            oShift = new Shift();
            if (oShift.ErrorNumber != 0)
            {
                IsValid = false;
            }

            if (IsValid)
			{
				InitializeComponent();
			}
		}

		private void frmShifts_Load(object sender, EventArgs e)
		{
            dtrDates.dtpBegDate.Value = DateTime.Now.AddDays(-7).Date;
            dtrDates.dtpEndDate.Value = DateTime.Now.AddDays(7).Date;

            grcDuration.AgrType = EnumAgregate.Sum;

            grdData_Restore();
			grdData.Select();
		}

		#region Buttons

        private void btnFilter_Click(object sender, EventArgs e)
        {
            WaitOn(this);
            grdData_Restore();
            WaitOff(this);
            grdData.Select();
        }

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
			if (StartForm(new frmShiftsAdd()) == DialogResult.Yes)
			{
				grdData_Restore();
                grdData.Select();
			}
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			/*if (grdData.CurrentRow == null || grdData.IsStatusRow(grdData.CurrentRow.Index))
				return;

			int nSalaryTariffID = (int)grdData.CurrentRow.Cells["grcID"].Value;
				
			if (StartForm(new frmShiftsEdit(nSalaryTariffID)) == DialogResult.Yes)
			{
				grdData_Restore();
			}*/
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
            if (grdData.DataSource == null || oShift.MainTable.Rows.Count == 0)
				return;

            int nMarkedRowsCount = grdData.GetMarkedRows();
            if (nMarkedRowsCount > 0 && 
                RFMMessage.MessageBoxYesNo("Удалить данные о сменах (" + nMarkedRowsCount.ToString() + " зап.)?") == DialogResult.Yes)
            {
                DataView dMarked = new DataView(oShift.MainTable);
                dMarked.RowFilter = "IsMarked = true";
                foreach (DataRowView r in dMarked)
                {
                    if (!Convert.IsDBNull(r["ID"]))
                    {
                        oShift.ClearError();
                        oShift.DeleteData((int)r["ID"]);
                    }
                }
            }
            else if (grdData.CurrentRow != null && !grdData.IsStatusRow(grdData.CurrentRow.Index) &&
                RFMMessage.MessageBoxYesNo("Удалить данные о смене?") == DialogResult.Yes)
            {
                oShift.ClearError();
                oShift.DeleteData((int)grdData.CurrentRow.Cells["grcID"].Value);
            }

            grdData_Restore();
		}

		#endregion 

		#region Restore

		private bool grdData_Restore()
		{
            RFMCursorWait.Set(true);
            RFMCursorWait.LockWindowUpdate(FindForm().Handle);

            oShift.ID = null;

            oShift.ClearError();
            oShift.ClearFilters();
            oShift.ID = null;
            oShift.IDList = null;

            // собираем условия
            // даты
            if (!dtrDates.dtpBegDate.IsEmpty)
            {
                oShift.FilterDateBeg = dtrDates.dtpBegDate.Value.Date;
            }
            if (!dtrDates.dtpEndDate.IsEmpty)
            {
                oShift.FilterDateEnd = dtrDates.dtpEndDate.Value.Date;
            }
            // старшие смен
            if (ucSelectRecordID_Majors.IsSelectedExist)
            {
                oShift.FilterMajorsList = ucSelectRecordID_Majors.GetIdString();
            }
            // смены
            if (optAll.Checked)
                oShift.FilterIsNight = null;
            else if (optNight.Checked)
                oShift.FilterIsNight = true;
            else if (optDay.Checked)
                oShift.FilterIsNight = false;


            grdData.GetGridState();

            oShift.FillData();
            grdData.Restore(oShift.MainTable);

            RFMCursorWait.LockWindowUpdate(IntPtr.Zero);
            RFMCursorWait.Set(false);

            return (oShift.ErrorNumber == 0);
		}

        private void ucSelectRecordID_Majors_Restore()
        {
            if (ucSelectRecordID_Majors.sourceData == null)
            {
                RFMCursorWait.Set(true);
                oUser.FillData();
                RFMCursorWait.Set(false);
                if (oUser.ErrorNumber != 0 || oUser.MainTable == null)
                {
                    RFMMessage.MessageBoxError("Ошибка при получении данных (сотрудники)...");
                    return;
                }
                if (oUser.MainTable.Rows.Count == 0)
                {
                    RFMMessage.MessageBoxError("Нет данных (сотрудники)...");
                    return;
                }

                ucSelectRecordID_Majors.Restore(oUser.MainTable);
            }
            else
            {
                ucSelectRecordID_Majors.Restore();
            }
        }

        #endregion
	}
}
