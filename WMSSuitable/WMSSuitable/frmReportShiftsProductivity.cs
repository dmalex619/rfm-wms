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
	public partial class frmReportShiftsProductivity : RFMFormChild
    {
        #region Fields
        private Partner oPartner;
        DataSet dsReport = new DataSet();
        #endregion

        public frmReportShiftsProductivity()
		{
            oPartner = new Partner();
            if (oPartner.ErrorNumber != 0)
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
            // Устанавливаем конец интервала на последнюю субботу
            DateTime dPrevSaturday = DateTime.Today;
            while (dPrevSaturday.DayOfWeek != DayOfWeek.Saturday)
                dPrevSaturday = dPrevSaturday.AddDays(-1);
            dPrevSaturday = dPrevSaturday.AddHours(21);

            // Ищем предыдущее воскресенье
            DateTime dPrevSunday = dPrevSaturday.AddDays(-6);

            // Устанавливаем интервал дат
            dtpDateBeg.Value = dPrevSunday;
            dtpDateEnd.Value = dPrevSaturday;
		}

		#region Buttons

        private void btnFilter_Click(object sender, EventArgs e)
        {
            WaitOn(this);
            Grids_Restore();
            WaitOff(this);
            dgvMajors.Select();
        }

        private void btnExit_Click(object sender, EventArgs e)
		{
			Dispose();
		}

		private void btnHelp_Click(object sender, EventArgs e)
		{
			RFMHelpUtilities.HelpShow(this, hpHelp);
		}

		#endregion 

		#region Restore

        private bool Grids_Restore()
        {
            RFMCursorWait.Set(true);
            RFMCursorWait.LockWindowUpdate(FindForm().Handle);

            // Собираем условия
            string sMode = (optPicking.Checked ? "P" : "L");
            string sOwnersList = (ucSelectRecordID_Owners.IsSelectedExist ? ucSelectRecordID_Owners.GetIdString() : null);
            bool? bWeightingGoods;
            if (optWeighting.Checked) bWeightingGoods = true;
            else if (optNonWeighting.Checked) bWeightingGoods = false;
            else bWeightingGoods = null;

            // Вызываем отчет
            Report oReport = new Report();
            oReport.ReportShiftsProductivity(sMode, dtpDateBeg.Value, dtpDateEnd.Value, sOwnersList, bWeightingGoods);

            // Обновляем таблицы
            if (oReport.ErrorNumber == 0)
            {
                dgvMajors.Restore(oReport.DS.Tables[0]);
                dgvUsers.Restore(oReport.DS.Tables[1]);
            }
            else
            {
                dgvMajors.Restore(null);
                dgvUsers.Restore(null);
            }

            RFMCursorWait.LockWindowUpdate(IntPtr.Zero);
            RFMCursorWait.Set(false);

            return true;
        }

        private void ucSelectRecordID_Owners_Restore()
        {
            if (ucSelectRecordID_Owners.sourceData == null)
            {
                RFMCursorWait.Set(true);
                oPartner.FilterOwner = true;
                oPartner.FillData();
                RFMCursorWait.Set(false);
                if (oPartner.ErrorNumber != 0 || oPartner.MainTable == null)
                {
                    RFMMessage.MessageBoxError("Ошибка при получении данных (владельцы)...");
                    return;
                }
                if (oPartner.MainTable.Rows.Count == 0)
                {
                    RFMMessage.MessageBoxError("Нет данных (владельцы)...");
                    return;
                }

                ucSelectRecordID_Owners.Restore(oPartner.MainTable);
            }
            else
            {
                ucSelectRecordID_Owners.Restore();
            }
        }

        #endregion
	}
}
