using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using RFMBaseClasses;
using WMSBizObjects;

namespace WMSSuitable
{
	public partial class frmLogin : RFMFormChild
	{
		private LoginList userList;

		public frmLogin() : base()
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
			cboUserList.DisplayMember = "Name";
			cboUserList.ValueMember = "ID";
			cboUserList.DataSource = userList.DS.Tables[userList.MainTableName];

            // найти текущего пользователя
            foreach (DataRow dr in userList.DS.Tables[userList.MainTableName].Rows)
            {
                if (dr["Alias"].ToString().Length > 0 && dr["Alias"].ToString().ToUpper() == System.Environment.UserName.ToUpper())
                {
                    cboUserList.SelectedValue = Convert.ToInt32(dr["ID"]);
                    break;
                }
            }
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
				RFMFormMain mainForm = (RFMFormMain)MotherForm;
				DataRow choosedRow = ((DataTable)cboUserList.DataSource).Rows[cboUserList.SelectedIndex];
				mainForm.UserID = (int)choosedRow["Id"];
				Dispose();
			}
			else
			{
				MessageBox.Show("Неверный пароль", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				txtPassword.Text = "";
				txtPassword.Focus();
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.No;
			Dispose();
		}

		private void cboUserList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboUserList.SelectedIndex < 0 || cboUserList.DataSource == null)
			{
				picPhoto.Image = null;
				return;
			}

			WMSBizObjects.User oUser = new WMSBizObjects.User();
			oUser.ID = (int)cboUserList.SelectedValue;
			oUser.FillData();
			if (oUser.ErrorNumber == 0 && oUser.MainTable.Rows.Count > 0)
			{
				DataRow droRow = oUser.MainTable.Rows[0];
				if (!Convert.IsDBNull(droRow["Photo"]))
				{
					byte[] bsPhoto = (byte[])droRow["Photo"];
					MemoryStream ms = new MemoryStream(bsPhoto);
					try
					{
						picPhoto.Image = new Bitmap(ms);
					}
					catch (Exception ex)
					{
						RFMPublic.RFMMessage.MessageBoxError("Ошибка загрузки фото: " + ex.Message);
					}
				}
				else
				{
					picPhoto.Image = null;
				}
			}
		}
	}
}