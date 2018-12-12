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
	public partial class frmReportBadGoods : RFMFormChild
    {
        #region Properties

        // для фильтров
        public int? _SelectedID;
        public string _SelectedIDList;
        public string _SelectedText;

        private int restPercent = 30;
        private string sSelectedOwnersIDList = "";

        #endregion

        public frmReportBadGoods()
		{
            if (IsValid)
			{
				InitializeComponent();

                grcBoxes.AgrType = grcNetto.AgrType = EnumAgregate.Sum;
			}
		}

        #region Grid

        private bool grdData_Restore()
        {
            RFMCursorWait.Set(true);
            RFMCursorWait.LockWindowUpdate(FindForm().Handle);

            // Погнали заполнять таблицу
            Report oReport = new Report();
            if (sSelectedOwnersIDList.Length > 0)
            {
                if (sSelectedOwnersIDList.StartsWith(","))
                    sSelectedOwnersIDList = sSelectedOwnersIDList.Substring(1, sSelectedOwnersIDList.Length - 1);
                if (sSelectedOwnersIDList.EndsWith(","))
                    sSelectedOwnersIDList = sSelectedOwnersIDList.Substring(0, sSelectedOwnersIDList.Length - 1);
            }
            oReport.ReportBadGoods(restPercent, sSelectedOwnersIDList);

            // Обновляем таблицы
            if (oReport.ErrorNumber == 0)
            {
                grdData.Restore(oReport.DS.Tables[0]);
            }
            else
            {
                grdData.Restore(null);
            }

            RFMCursorWait.LockWindowUpdate(IntPtr.Zero);
            RFMCursorWait.Set(false);
            
            return true;
        }

        #endregion

        #region Buttons

        private void btnGo_Click(object sender, EventArgs e)
        {
            restPercent = (int)numRestPrc.Value;

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

        private void btnOwnersChoose_Click(object sender, EventArgs e)
        {
            _SelectedIDList = null;
            _SelectedText = "";

            Partner oOwner = new Partner();
            oOwner.FillDataOwners();
            if (oOwner.ErrorNumber != 0 || oOwner.MainTable == null)
            {
                RFMMessage.MessageBoxError("Ошибка при получении данных о хранителях...");
                return;
            }
            if (oOwner.MainTable.Rows.Count == 0)
            {
                RFMMessage.MessageBoxError("Нет данных о хранителях...");
                return;
            }

            if (StartForm(new frmSelectID(this, oOwner.MainTable, "Name,Actual", "Хранитель,Акт.", true)) == DialogResult.Yes)
            {
                if (_SelectedIDList == null || !_SelectedIDList.Contains(","))
                {
                    btnOwnersClear_Click(null, null);
                    return;
                }

                sSelectedOwnersIDList = "," + _SelectedIDList;

                txtOwnersChoosen.Text = _SelectedText;
                ttToolTip.SetToolTip(txtOwnersChoosen, txtOwnersChoosen.Text);
            }

            _SelectedIDList = null;
            _SelectedText = "";
        }

        private void btnOwnersClear_Click(object sender, EventArgs e)
        {
            sSelectedOwnersIDList = "";
            txtOwnersChoosen.Text = "";
        }

        #endregion
    }
}
