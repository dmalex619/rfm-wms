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
	public partial class frmSalaryExtraWorksEdit : RFMFormChild
	{
		private int? nExtraWorkID = null;
		private SalaryExtraWork oExtraWork;

		// для combobox
		private User oUser;
        private Partner oOwner;

        public int? _SelectedID;
		public string _SelectedText;

		public frmSalaryExtraWorksEdit(int? _nExtraWorkID)
		{
			if (_nExtraWorkID.HasValue)
				nExtraWorkID = (int)_nExtraWorkID;

			oExtraWork = new SalaryExtraWork();

			if (oExtraWork.ErrorNumber != 0)
				IsValid = false;

			oUser = new User();
			if (oUser.ErrorNumber != 0)
				IsValid = false;
            oOwner = new Partner();
            if (oOwner.ErrorNumber != 0)
                IsValid = false;

            if (IsValid)
				InitializeComponent();
		}
	
		private void frmSalaryExtraWorksEdit_Load (object sender, EventArgs e)
		{
			bool bResult = true; 
			
			bResult = cboUsers_Restore() && cboOwners_Restore();

			if (bResult)
			{
				oExtraWork.ID = nExtraWorkID;

				if (nExtraWorkID.HasValue)
				{
					oExtraWork.FillData();
					if (oExtraWork.ErrorNumber != 0 || oExtraWork.MainTable.Rows.Count != 1)
					{
						RFMMessage.MessageBoxError("Ошибка при получении данных о дополнительных внутрискладских работах...");
						bResult = false;
					}

					if (bResult)
					{
						dtpDateExtraWork.Value = (DateTime)oExtraWork.MainTable.Rows[0]["DateWork"];
						cboUsers.SelectedValue = (int)oExtraWork.MainTable.Rows[0]["UserID"];

                        cboOwners.SelectedIndex = -1;
                        if (!Convert.IsDBNull(oExtraWork.MainTable.Rows[0]["OwnerID"]))
                            cboOwners.SelectedValue = (int)oExtraWork.MainTable.Rows[0]["OwnerID"];
                        else
                            cboOwners.SelectedValue = -1;

                        txtExtraWork.Text = oExtraWork.MainTable.Rows[0]["WorkName"].ToString().Trim();		
						numQnt.Value = (decimal)oExtraWork.MainTable.Rows[0]["Qnt"];
						numTarif.Value = (decimal)oExtraWork.MainTable.Rows[0]["Price"];
						numAmount.Value = Math.Round((decimal)numQnt.Value * (decimal)numTarif.Value, 2);
						txtNote.Text = oExtraWork.MainTable.Rows[0]["Note"].ToString().Trim();
					}
				}
				else
				{
					// новый ExtraWork
				}
			}

			if (!bResult)
				Dispose();
			dtpDateExtraWork.Select();
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
			if (dtpDateExtraWork.IsEmpty )
			{
				RFMMessage.MessageBoxError("Укажите дату дополнительной внутрискладской работы!");
				dtpDateExtraWork.Select();
				return;
			}
			if (cboUsers.SelectedValue == null || cboUsers.SelectedIndex < 0)
			{
				RFMMessage.MessageBoxError("Укажите исполнителя!");
				cboUsers.Select();
				return;
			}
            /*
            if (cboOwners.SelectedValue == null || cboOwners.SelectedIndex < 0)
            {
                RFMMessage.MessageBoxError("Укажите владельца!");
                cboOwners.Select();
                return;
            }
            */
            if (txtExtraWork.Text.Trim() == null ||txtExtraWork.Text.Trim().Length == 0)
			{
				RFMMessage.MessageBoxError("Укажите название дополнительной внутрискладской работы!");
				txtExtraWork.Select();
				return;
			}

			if ((decimal)numQnt.Value == 0)
			{
				RFMMessage.MessageBoxError("Укажите объем дополнительной внутрискладской работы!");
				numQnt.Select();
				return;
			}

			if ((decimal)numTarif.Value == 0)
			{
				RFMMessage.MessageBoxError("Укажите тариф для дополнительной внутрискладской работы!");
				numTarif.Select();
				return;
			}

            int? nOwnerID = null;
            if (cboOwners.SelectedIndex >= 0)
            {
                nOwnerID = (int)cboOwners.SelectedValue;
            }
            
            oExtraWork.ClearError();
			oExtraWork.Save(oExtraWork.ID, (DateTime)dtpDateExtraWork.Value, txtExtraWork.Text.Trim(),
                    nOwnerID, (int)cboUsers.SelectedValue, 
                    (decimal)numQnt.Value, (decimal)numTarif.Value, txtNote.Text.Trim()); 
			if (oExtraWork.ErrorNumber == 0)
			{
				MotherForm.GotParam = new object[] { (int)oExtraWork.ID };
				DialogResult = DialogResult.Yes;
				Dispose();
			}
		}

		private void txtTabNumber_TextChanged(object sender, EventArgs e)
		{
			if (txtTabNumber.Text.Trim().Length == 3)
			{
				string sTabNumber = txtTabNumber.Text.Trim();
				bool bFound = false;
				foreach (DataRow dr in oUser.MainTable.Rows)
				{
					string sBarCode = dr["BarCode"].ToString();
					if (sBarCode.Substring(sBarCode.Length - 3, 3) == sTabNumber)
					{
						cboUsers.SelectedValue = Convert.ToInt32(dr["ID"]);
						bFound = true;
						break;
					}
				}
				if (!bFound)
				{
					cboUsers.SelectedIndex = -1;
				}
			}
		}
		
		private void numTarif_Validating(object sender, CancelEventArgs e)
		{
			numAmount.Value = Math.Round((decimal)numQnt.Value * (decimal)numTarif.Value, 2);
		}

		private bool cboUsers_Restore()
		{
			oUser.FillData();
			cboUsers.ValueMember = oUser.ColumnID;
			cboUsers.DisplayMember = oUser.MainTable.Columns[("Name")].ToString();
			cboUsers.DataSource = oUser.MainTable;
			cboUsers.SelectedIndex = -1;
			return (oUser.ErrorNumber == 0);
		}

        private bool cboOwners_Restore()
        {
            oOwner.FilterOwner = true;
            oOwner.FilterActual = true;
            oOwner.FillData();
            if (oOwner.ErrorNumber == 0)
            {
                cboOwners.ValueMember = oOwner.ColumnID;
                cboOwners.DisplayMember = oOwner.ColumnName;
                cboOwners.DataSource = oOwner.MainTable;
            }
            return (oOwner.ErrorNumber == 0);
        }

        private void btnExtraWorkSelect_Click(object sender, EventArgs e)
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
				txtExtraWork.Text = _SelectedText;
			}
			_SelectedID = null;
			_SelectedText = "";

			return;
		}

		private void numQnt_Validated(object sender, EventArgs e)
		{
			numAmount.Value = Math.Round((decimal)numQnt.Value * (decimal)numTarif.Value, 2);
		}
	}
}
