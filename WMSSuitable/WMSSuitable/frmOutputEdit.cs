using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSBaseClasses;
using WMSBizObjects;

namespace WMSSuitable
{
	public partial class frmOutput : WMSFormChild
	{
		private LoginList userList;

		public frmOutput() : base()
		{
			userList = new LoginList();

			IsValid = (((BizObject)userList).ErrorNumber == 0);
			if (IsValid)
				InitializeComponent();
		}

		private void frmLogin_Load(object sender, EventArgs e)
		{
			if (!IsValid)
				return;

			tmrShow.Start();

			// Получение DataSet от бизнес-объекта
			// и привязка его к ComboBox
			userList.FillData();
			cboUserList.DataSource = userList.DS.Tables[userList.MainTableName];
			cboUserList.DisplayMember = "Name";
			cboUserList.ValueMember = "ID";
		}

		private void tmrShow_Tick(object sender, EventArgs e)
		{
			if (prbProcess.Value < prbProcess.Maximum)
				prbProcess.Value++;
			else
			{
				DialogResult = DialogResult.No;
				Dispose(true);
			}
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			// Проверка пароля
			int userId = (int)cboUserList.SelectedValue;
			if (userList.CheckPassword(userId, txtPassword.Text.Trim()))
			{
				DialogResult = DialogResult.Yes;
				WMSFormMain mainForm = (WMSFormMain)MotherForm;
				DataRow choosedRow = ((DataTable)cboUserList.DataSource).Rows[cboUserList.SelectedIndex];
				mainForm.UserId = (int)choosedRow["Id"];
				mainForm.UserAlias = (string)choosedRow["Name"];
				mainForm.UserLocPath = (string)choosedRow["LocPath"];
				mainForm.UserNetPath = (string)choosedRow["NetPath"];
				Dispose();
			}
			else
			{
				MessageBox.Show("Неверный пароль", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				//this.SuspendLayout();
				txtPassword.Text = "";
				txtPassword.Focus();
				//this.ResumeLayout();
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.No;
			Dispose();
		}
	}
}