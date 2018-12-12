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
	public partial class frmSalaryExtraWorks : RFMFormChild
	{
		private SalaryExtraWork oExtraWorkList; // список 

		public int? _SelectedID;
		public string _SelectedText, _SelectedIDList;
        public string sSelectedOwnersIDList;


		public frmSalaryExtraWorks()
		{
			oExtraWorkList = new SalaryExtraWork();
			if (oExtraWorkList.ErrorNumber != 0)
				IsValid = false;
			if (IsValid)
				InitializeComponent();
		}

		private void frmSalaryExtraWorks_Load(object sender, EventArgs e)
		{
			RFMCursorWait.Set(true);

			btnClearTerms_Click(null, null);

			tcList.Init();

			dtrDates.dtpBegDate.Select();

			RFMCursorWait.Set(false);
		}

		#region TabPages Restore

		private bool tabTerms_Restore()
		{
			btnAdd.Enabled =
			btnEdit.Enabled =
			btnDelete.Enabled =
			btnPrint.Enabled =
			btnService.Enabled = false;

			dtrDates.DtpBegDate.Select();

			return (true);
		}

		private bool tabSalaryExtraWorks_Restore()
		{
			dgvExtraWorks_Restore();
			btnAdd.Enabled = true;
			if (dgvExtraWorks.Rows.Count > 0)
			{
				btnEdit.Enabled =
				btnDelete.Enabled =
				btnPrint.Enabled =
				btnService.Enabled = true;

				dgvExtraWorks.Select();
			}
			else
			{
				btnEdit.Enabled =
				btnDelete.Enabled =
				btnPrint.Enabled =
				btnService.Enabled = false;
			}
			return (true);
		}

		#endregion TabPages Restore

		#region Restore

		private bool dgvExtraWorks_Restore()
		{
			RFMCursorWait.Set(true);
			RFMCursorWait.LockWindowUpdate(FindForm().Handle);

			oExtraWorkList.ClearError();
			oExtraWorkList.ClearFilters();
			oExtraWorkList.ID = null;
			oExtraWorkList.IDList = null;

			// собираем условия

			// даты
			if (!dtrDates.dtpBegDate.IsEmpty)
			{
				oExtraWorkList.FilterDateBeg = dtrDates.dtpBegDate.Value.Date;
			}
			if (!dtrDates.dtpEndDate.IsEmpty)
			{
				oExtraWorkList.FilterDateEnd = dtrDates.dtpEndDate.Value.Date;
			}

            oExtraWorkList.FilterOwnersList = sSelectedOwnersIDList;
            oExtraWorkList.FilterUsersList = ucSelectRecordID_Users.GetIdString();

            if (txtWorkName.Text.Trim().Length > 0)
				oExtraWorkList.FilterWorkNameContext = txtWorkName.Text.Trim();
					
			dgvExtraWorks.GetGridState();
			oExtraWorkList.FillData();
			dgvExtraWorks.IsLockRowChanged = true;
			dgvExtraWorks.Restore(oExtraWorkList.MainTable);

			RFMCursorWait.LockWindowUpdate(IntPtr.Zero);
			RFMCursorWait.Set(false);

			return (oExtraWorkList.ErrorNumber == 0);
		}

		#endregion

		#region Buttons

		private void btnAdd_Click(object sender, EventArgs e)
		{
			if (StartForm(new frmSalaryExtraWorksEdit(null)) == DialogResult.Yes)
			{
				int nExtraWorkID = (int)GotParam.GetValue(0);
				dgvExtraWorks_Restore();
				if (nExtraWorkID > 0)
					dgvExtraWorks.GridSource.Position = dgvExtraWorks.GridSource.Find(oExtraWorkList.ColumnID, nExtraWorkID);
			}
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			if (dgvExtraWorks.Rows.Count == 0 || dgvExtraWorks.CurrentRow == null)
				return;

			if (StartForm(new frmSalaryExtraWorksEdit((int)dgvExtraWorks.CurrentRow.Cells["dgvcID"].Value)) == DialogResult.Yes)
				dgvExtraWorks_Restore();
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (dgvExtraWorks.Rows.Count == 0 || dgvExtraWorks.CurrentRow == null)
				return;

			if (RFMMessage.MessageBoxYesNo("Удалить запись о дополнительной внутрискладской работе?") == DialogResult.Yes)
			{
				WaitOn(this);
				if (oExtraWorkList.Delete((int)(int)dgvExtraWorks.CurrentRow.Cells["dgvcID"].Value))
				{
					WaitOff(this);
					if (oExtraWorkList.ErrorNumber == 0)
						dgvExtraWorks_Restore();
					else
						RFMMessage.MessageBoxError("Ошибка при удалении записи о дополнительной внутрискладской работе...");
				}	
				WaitOff(this);
			}
		}

		private void btnHelp_Click(object sender, EventArgs e)
		{
			RFMHelpUtilities.HelpShow(this, hpHelp);
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Dispose();
		}

        #endregion

        #region Filters Choose

        #region Owners

        private void btnOwnersChoose_Click(object sender, EventArgs e)
        {
            _SelectedIDList = null;
            _SelectedText = "";

            Partner oOwner = new Partner();
            oOwner.FilterOwner = true;
            // oOwner.FilterSeparatePicking = true; // если нужны только непофигисты
            oOwner.FilterActual = true;
            oOwner.FillData();
            if (oOwner.ErrorNumber != 0 || oOwner.MainTable == null)
            {
                RFMMessage.MessageBoxError("Ошибка при получении данных...");
                return;
            }
            if (oOwner.MainTable.Rows.Count == 0)
            {
                RFMMessage.MessageBoxError("Нет данных...");
                return;
            }

            if (StartForm(new frmSelectID(this, oOwner.MainTable, "Name,Actual", "Владелец,Акт.", true)) == DialogResult.Yes)
            {
                if (_SelectedIDList == null || !_SelectedIDList.Contains(","))
                {
                    btnOwnersClear_Click(null, null);
                    return;
                }

                sSelectedOwnersIDList = "," + _SelectedIDList;

                txtOwnersChoosen.Text = _SelectedText;
                ttToolTip.SetToolTip(txtOwnersChoosen, txtOwnersChoosen.Text);

                tabSalaryExtraWorks.IsNeedRestore = true;
            }

            _SelectedIDList = null;
            _SelectedText = "";
        }

        private void btnOwnersClear_Click(object sender, EventArgs e)
        {
            ttToolTip.SetToolTip(txtOwnersChoosen, "не выбраны");
            sSelectedOwnersIDList = null;
            txtOwnersChoosen.Text = "";

            tabSalaryExtraWorks.IsNeedRestore = true;
        }

        #endregion Owners

        #region Users

        private void ucSelectRecordID_Users_Restore()
		{
			if (ucSelectRecordID_Users.sourceData == null)
			{
				RFMCursorWait.Set(true);
				User oUsers = new User();
				oUsers.FillDataTree(false);
				RFMCursorWait.Set(false);
				if (oUsers.ErrorNumber != 0 || oUsers.DS.Tables["TableDataTree"] == null)
				{
					RFMMessage.MessageBoxError("Ошибка при получении данных (cотрудники)...");
					return;
				}
				if (oUsers.DS.Tables["TableDataTree"].Rows.Count == 0)
				{
					RFMMessage.MessageBoxError("Нет данных (сотрудники)...");
					return;
				}

				ucSelectRecordID_Users.Restore(oUsers.DS.Tables["TableDataTree"]);
			}
			else
			{
				ucSelectRecordID_Users.Restore();
			}
		}

		#endregion Users

		private void btnWorkSelect_Click(object sender, EventArgs e)
		{
			// ранее введеные значения 
			
			SalaryExtraWork oExtraWorkTemp = new SalaryExtraWork();
			oExtraWorkTemp.FilterDateBeg = DateTime.Now.Date.AddMonths(-1);
			oExtraWorkTemp.FilterDateEnd = DateTime.Now.Date;
			oExtraWorkTemp.FillData();
			if (oExtraWorkTemp.ErrorNumber != 0 || oExtraWorkTemp.MainTable == null)
				return;
			if (oExtraWorkTemp.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Нет данных...");
				return;
			}

			DataTable dtWorkNamesDistinct = new DataTable();
			dtWorkNamesDistinct.Columns.Add("WorkName");
			System.Collections.Hashtable hash = new System.Collections.Hashtable();
			foreach (DataRow row in oExtraWorkTemp.MainTable.Rows)
				hash[row["WorkName"]] = row["WorkName"];
			foreach (object name in hash.Values)
				dtWorkNamesDistinct.Rows.Add(name);
			DataTable tdWorkNames = CopyTable(dtWorkNamesDistinct, "tdWorkNames", "WorkName > ''", "WorkName");
			if (StartForm(new frmSelectID(this, tdWorkNames, "WorkName", "Дополнительная работа", false)) == DialogResult.Yes)
			{
				if (_SelectedID == null)
				{
					return;
				}
				txtWorkName.Text = _SelectedText;
			}
			_SelectedID = null;
			_SelectedText = "";

			tabSalaryExtraWorks.IsNeedRestore = true;
 
			return;
		}

		#endregion

		#region Terms clear

		private void btnClearTerms_Click(object sender, EventArgs e)
		{
            ucSelectRecordID_Users.ClearData();
            txtWorkName.Text = "";

			dtrDates.dtpBegDate.Value = DateTime.Now.Date.AddDays(-7);
			dtrDates.dtpEndDate.Value = DateTime.Now.Date;

			if (Control.ModifierKeys == Keys.Shift)
			{
				dtrDates.dtpBegDate.HideControl(false);
				dtrDates.dtpEndDate.HideControl(false);
			}
			
			tabSalaryExtraWorks.IsNeedRestore = true;
		}

		#endregion

	}
}