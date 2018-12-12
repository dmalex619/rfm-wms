using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using RFMBaseClasses;
using RFMPublic;
using WMSBizObjects;

namespace WMSSuitable
{
	public partial class frmShiftsAdd : RFMFormChild
    {
        #region Properties
        private Shift oShift;
        private User oUser;
        private DataTable tableShifts = new DataTable("TableShifts");
        #endregion

        public frmShiftsAdd()
		{
            oShift = new Shift();
            oUser = new User();
            if (oShift.ErrorNumber != 0 || oUser.ErrorNumber != 0)
            {
                IsValid = false;
            }

            // Заполняем таблицу пользователей для подстановки имени старшего смены
            oUser.FillData();
            if (oUser.MainTable.Rows.Count == 0)
            {
                IsValid = false;
            }

            if (IsValid)
			{
				InitializeComponent();
			}
		}

		private void frmShihtsAdd_Load (object sender, EventArgs e)
		{
            // Ищем ближайшее воскресенье
            DateTime dNextSunday = DateTime.Today;
            while (dNextSunday.DayOfWeek != DayOfWeek.Sunday)
                dNextSunday = dNextSunday.AddDays(1);
            dNextSunday = dNextSunday.AddHours(21);

            // Устанавливаем конец интервала на следующую субботу
            DateTime dNextSaturday = dNextSunday.AddDays(6);

            // Устанавливаем интервал дат
            dtpDateBeg.Value = dNextSunday;
            dtpDateEnd.Value = dNextSaturday;

            // Создаем таблицу смен
            tableShifts.Columns.Add("DateBeg", typeof(DateTime));
            tableShifts.Columns.Add("DateEnd", typeof(DateTime));
            tableShifts.Columns.Add("MajorID", typeof(int));
            tableShifts.Columns.Add("MajorName", typeof(string));
            tableShifts.Columns.Add("IsNight", typeof(bool));
            tableShifts.Columns.Add("Note", typeof(string));
            tableShifts.Columns.Add("ID", typeof(int));
        }

        private void chkIfShift3Exits_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIfShift3Exits.Checked)
            {
                lblShift3Hours.Visible = numShift3Hours.Visible = true;
                numShift1Hours.Maximum = numShift2Hours.Maximum = 22;
                numShift3Hours.Value = numShift3Hours.Minimum = 1;
            }
            else
            {
                lblShift3Hours.Visible = numShift3Hours.Visible = false;
                numShift1Hours.Maximum = numShift2Hours.Maximum = 23;
                numShift3Hours.Value = numShift3Hours.Minimum = 0;
                numShift2Hours.Value = 24 - numShift1Hours.Value - numShift3Hours.Minimum;
            }
        }

        #region NumericUpDown

        private void numShift1Hours_ValueChanged(object sender, EventArgs e)
        {
            numShift3Hours.Value = numShift3Hours.Minimum;
            numShift2Hours.Value = 24 - numShift1Hours.Value - numShift3Hours.Minimum;
        }

        private void numShift2Hours_ValueChanged(object sender, EventArgs e)
        {
            if (chkIfShift3Exits.Checked)
            {
                if (24 - numShift1Hours.Value - numShift2Hours.Value >= numShift3Hours.Minimum)
                {
                    numShift3Hours.Value = 24 - numShift1Hours.Value - numShift2Hours.Value;
                }
                else
                {
                    numShift3Hours.Value = numShift3Hours.Minimum;
                    numShift1Hours.Value = 24 - numShift2Hours.Value - numShift3Hours.Minimum;
                }
            }
            else
            {
                numShift1Hours.Value = 24 - numShift2Hours.Value - numShift3Hours.Minimum;
            }
        }

        private void numShift3Hours_ValueChanged(object sender, EventArgs e)
        {
            if (24 - numShift1Hours.Value - numShift3Hours.Value >= numShift2Hours.Minimum)
            {
                numShift2Hours.Value = 24 - numShift1Hours.Value - numShift3Hours.Value;
            }
            else
            {
                numShift2Hours.Value = numShift2Hours.Minimum;
                numShift1Hours.Value = 24 - numShift2Hours.Value - numShift3Hours.Value;
            }
        }
        
        #endregion

        #region Grid

        private bool grdData_Restore()
        {
            RFMCursorWait.Set(true);
            RFMCursorWait.LockWindowUpdate(FindForm().Handle);

            tableShifts.Clear();

            // Получение количества смен в день
            int nShiftsPerDay = (chkIfShift3Exits.Checked ? 3 : 2);
            int[] aShiftsDuration = new int[nShiftsPerDay];
            aShiftsDuration[0] = (int)numShift1Hours.Value;
            aShiftsDuration[1] = (int)numShift2Hours.Value;
            if (nShiftsPerDay == 3) aShiftsDuration[2] = (int)numShift3Hours.Value;

            DateTime dDateBeg, dDateEnd;
            bool bIsNight;
            int nShiftsCount = 0;

            // Погнали заполнять таблицу
            dDateBeg = dtpDateBeg.Value;
            while (true)
            {
                dDateEnd = dDateBeg.AddHours(aShiftsDuration[nShiftsCount % nShiftsPerDay]);
                bIsNight = ((dDateBeg.Day != dDateEnd.Day || dDateBeg.Hour >= 20) ? true : false);

                // Заполнение строки данных
                DataRow r = tableShifts.NewRow();
                r["ID"] = nShiftsCount;
                r["DateBeg"] = dDateBeg;
                r["DateEnd"] = dDateEnd;
                r["MajorName"] = "";
                r["IsNight"] = bIsNight;
                r["Note"] = "";
                tableShifts.Rows.Add(r);

                // Проверка на окончание цикла
                if (dDateEnd >= dtpDateEnd.Value) break;

                dDateBeg = dDateEnd;
                nShiftsCount++;
            }

            grdData.GetGridState();

            grdData.Restore(tableShifts);

            RFMCursorWait.LockWindowUpdate(IntPtr.Zero);
            RFMCursorWait.Set(false);

            return true;
        }

        private void grdData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
			if (grdData.DataSource == null || grdData.CurrentRow == null || grdData.RowCount == 0)
				return;

			string ColName = grdData.Columns[e.ColumnIndex].Name;

            if (ColName == "grcMajorID")
            {
                // Получение кода старшего смены
                int nMajorID = 0;
				DataGridViewRow dgrv = grdData.Rows[e.RowIndex];
                int.TryParse(dgrv.Cells["grcMajorID"].Value.ToString(), out nMajorID);
                if (nMajorID == 0)
                {
                    dgrv.Cells["grcMajorID"].Value = DBNull.Value;
                    dgrv.Cells["grcMajorName"].Value = "";
                    return;
                }

                // Поиск ФИО (сброс значения в случае неверного значения)
                string sMajorName = "";
                foreach (DataRow r in oUser.MainTable.Rows)
                {
                    if (Convert.ToInt32(r["ID"]) == nMajorID)
                    {
                        sMajorName = r["Name"].ToString();
                        break;
                    }
                }
                if (String.IsNullOrEmpty(sMajorName))
                {
                    dgrv.Cells["grcMajorID"].Value = DBNull.Value;
                    dgrv.Cells["grcMajorName"].Value = "";
                }
                else
                {
                    dgrv.Cells["grcMajorName"].Value = sMajorName;
                }
            }
        }

        #endregion

        #region Buttons

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (dtpDateBeg.Value > dtpDateEnd.Value)
            {
                MessageBox.Show("Задан некорректный интервал!");
                return;
            }

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

		private void btnSave_Click(object sender, EventArgs e)
		{
			// Проверить наличие записей
            if (tableShifts.Rows.Count == 0)
                return;

            // Проверить заполненность старших смен
            foreach (DataRow r in tableShifts.Rows)
            {
                if (r["MajorName"].ToString().Length == 0)
                {
                    MessageBox.Show("Не заполнены данные о старших сотрудниках в смене");
                    return;
                }
            }

            // Для сохранения данных обнуляем oShift.MainTable и добавляем одну пустую строку
            oShift.ClearData();
            oShift.ID = -1;
            oShift.FillData();
            DataRow newRow = oShift.MainTable.NewRow();
            oShift.MainTable.Rows.Add(newRow);

            // Сохраняем данные
            foreach (DataRow r in tableShifts.Rows)
            {
                oShift.MainTable.Rows[0]["ID"] = 0;
                oShift.MainTable.Rows[0]["DateBeg"] = r["DateBeg"];
                oShift.MainTable.Rows[0]["DateEnd"] = r["DateEnd"];
                oShift.MainTable.Rows[0]["MajorID"] = r["MajorID"];
                oShift.MainTable.Rows[0]["IsNight"] = r["IsNight"];
                oShift.MainTable.Rows[0]["Note"] = r["Note"];

                WaitOn(this);
                oShift.ClearError();
                bool bResult = oShift.SaveData(0);
                WaitOff(this);
                if (!bResult | oShift.ErrorNumber != 0)
                {
                    RFMMessage.MessageBoxError("Ошибка сохранения данных о сменах...");
                    return;
                }
            }

            RFMMessage.MessageBoxInfo("Данные сохранены");
            DialogResult = DialogResult.Yes;
            Dispose();
        }

        #endregion
    }
}
