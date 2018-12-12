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
	public partial class frmUsersEdit : RFMFormChild
	{
		private int ID;
		private User oUser;
		private Host oHost;

		protected string filePhotoPath = "";
		protected bool bClearPhoto = false;


		public frmUsersEdit(int? _ID)
		{
			if (_ID.HasValue)
				ID = (int)_ID;

			oUser = new User();
			if (oUser.ErrorNumber != 0) 
				IsValid = false;

			if (IsValid)
			{
				oHost = new Host();
				if (oHost.ErrorNumber != 0)
					IsValid = false;
			}

			if (IsValid)
				InitializeComponent();
		}

		private void frmUsersEdit_Load (object sender, EventArgs e)
		{
			cboHost.Enabled = (oHost.Count() > 1);

			bool blResult = true;

			oUser.ID = this.ID;
			oUser.FillData();
			if (oUser.ErrorNumber != 0)
			{
				//RFMMessage.MessageBoxError("Ошибка при получении данных о пользователе...");
				blResult = false;
			}

			if (blResult)
			{
				if (ID != 0 && oUser.MainTable.Rows.Count != 1)
				{
					RFMMessage.MessageBoxError("Ошибка при получении данных о пользователе...");
					blResult = false;
				}
			}

			if (blResult)
			{
				if (!dgvUserRoles_Restore())
				{
					RFMMessage.MessageBoxError("Ошибка при получении данных о ролях...");
					blResult = false;
				}
			}

			if (blResult)
			{
				if (!cboBrigades_Restore())
				{
					RFMMessage.MessageBoxError("Ошибка при заполнении классификатора бригад...");
					blResult = false;
				}
			}

			if (blResult)
			{
				if (!cboHost_Restore())
				{
					RFMMessage.MessageBoxError("Ошибка при заполнении классификатора хостов...");
					blResult = false;
				}
			}

			if (blResult)
			{
				if (!((RFMFormMain)Application.OpenForms[0]).UserInfo.UserIsAdmin)
				{
					txtPassword.PasswordChar = '*';
					chkIsAdmin.Enabled = false;
				}

				cboBrigades.SelectedIndex =
				cboHost.SelectedIndex =
					-1; 

				if (ID != 0)
				{
					// существующий пользователь
					DataRow droRow = oUser.MainTable.Rows[0];
					txtUserNаme.Text = droRow["Name"].ToString();
					txtPassword.Text = droRow["Password"].ToString();
					txtAlias.Text = droRow["Alias"].ToString();
					txtLocPath.Text = droRow["LocPath"].ToString();
					txtNetPath.Text = droRow["NetPath"].ToString();
					chkIsAdmin.Checked = (Boolean)droRow["IsAdmin"];
					chkActual.Checked = (Boolean)droRow["Actual"];
					if (!Convert.IsDBNull(droRow["BrigadeID"]))
						cboBrigades.SelectedValue = Convert.ToInt32(droRow["BrigadeID"]);
					if (!Convert.IsDBNull(droRow["HostID"]))
						cboHost.SelectedValue = Convert.ToInt32(droRow["HostID"]);

					if (!Convert.IsDBNull(droRow["Photo"]))
					{
						byte[] bsPhoto = (byte[])droRow["photo"];
						MemoryStream ms = new MemoryStream(bsPhoto);
						try
						{
							picPhoto.Image = new Bitmap(ms);
						}
						catch (Exception ex)
						{
							RFMMessage.MessageBoxError("Ошибка загрузки фото: " + ex.Message);
						}
					}
				}
			}
			else
			{
				Dispose();
			}
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
			if (txtUserNаme.Text.Trim().Length == 0)
			{
				RFMMessage.MessageBoxError("Укажите имя пользователя!");
				txtUserNаme.Select();
				return;
			}

			if (txtPassword.Text.Trim().Length == 0)
			{
				if (RFMMessage.MessageBoxYesNo("Пароль пуст.\nВсе-таки сохранить?") != DialogResult.Yes)
				{
					txtPassword.Select();
					return;
				}
			}

			if (txtLocPath.Text.Trim().Length == 0)
			{
				//RFMMessage.MessageBoxError("Укажите локальный каталог!");
				//txtLocPath.Select();
				//return;
			}
			if (txtNetPath.Text.Trim().Length == 0)
			{
				//RFMMessage.MessageBoxError("Укажите сетевой каталог!");
				//txtNetPath.Select();
				//return;
			}

			if (ID == 0 && oUser.MainTable.Rows.Count == 0)
			{
				oUser.MainTable.Rows.Add();
			}

			DataRow droRow = oUser.MainTable.Rows[0];
			droRow["Name"]     = txtUserNаme.Text.Trim();
			droRow["Password"] = txtPassword.Text.Trim();
			droRow["Alias"]	   = txtAlias.Text.Trim();
			droRow["LocPath"]  = txtLocPath.Text.Trim();
			droRow["NetPath"]  = txtNetPath.Text.Trim();
			droRow["IsAdmin"]  = chkIsAdmin.Checked;
			droRow["Actual"]   = chkActual.Checked;
			if (cboBrigades.SelectedValue != null && cboBrigades.SelectedIndex >= 0)
				droRow["BrigadeID"] = Convert.ToInt32(cboBrigades.SelectedValue);
			else
				droRow["BrigadeID"] = DBNull.Value;
			if (cboHost.SelectedValue != null && cboHost.SelectedIndex >= 0)
				droRow["HostID"] = (int)cboHost.SelectedValue;
			else
				droRow["HostID"] = DBNull.Value;

			oUser.ClearError();
			oUser.SaveData(ID);

			if (oUser.ErrorNumber == 0)
			{
				// код добавленного пользователя
				if (ID == 0 && oUser.ID.HasValue && oUser.ID != 0)
				{
					ID = (int)oUser.ID;
				}

				// сохранить фото
				if (filePhotoPath != "")
				{
					FileStream fs = new FileStream(filePhotoPath, FileMode.Open, FileAccess.Read);
					BinaryReader br = new BinaryReader(fs);
					byte[] bsPhoto = br.ReadBytes((int)fs.Length);
					br.Close();
					fs.Close();
					oUser.SavePhoto(ID, bsPhoto);
				}
				else
				{
					if (bClearPhoto)
						oUser.SavePhoto(ID, null);
				}

				if (oUser.ErrorNumber == 0)
				{
					MotherForm.GotParam = new object[] { (int)oUser.ID };
					DialogResult = DialogResult.Yes;
					Dispose();
				}
			}
		}

		private void btnLoadPhoto_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();

			dlg.Title = "Загрузить фото";
			dlg.Filter = "Изображения JPEG (*.jpg)|*.jpg" + 
							"|Все файлы (*.*)|*.*";
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				try
				{
					filePhotoPath = dlg.FileName;
					picPhoto.Image = new Bitmap(dlg.OpenFile());
				}
				catch (Exception ex)
				{
					RFMMessage.MessageBoxError("Ошибка загрузки фото: " + ex.Message);
				}
			}
			dlg.Dispose();
		}

		private bool cboBrigades_Restore()
		{
			oUser.FillTableBrigades();
			cboBrigades.ValueMember = oUser.TableBrigades.Columns[0].Caption;
			cboBrigades.DisplayMember = oUser.TableBrigades.Columns[1].Caption;
			cboBrigades.DataSource = oUser.TableBrigades;
			return (oUser.ErrorNumber == 0);
		}

		private bool cboHost_Restore()
		{
			cboHost.DataSource = null;
			oHost.FillData();
			if (oHost.ErrorNumber == 0 && 
				oHost.MainTable != null &&
				oHost.MainTable.Rows.Count > 0)
			{
				cboHost.ValueMember = oHost.ColumnID;
				cboHost.DisplayMember = oHost.ColumnName;
				cboHost.Restore(oHost.MainTable);
			}
			return (oHost.ErrorNumber == 0);
		}

		private bool dgvUserRoles_Restore()
		{
			oUser.FillTableRolesForUser(this.ID);
			dgvUserRoles.Restore(oUser.TableRolesForUser);
			return (oUser.ErrorNumber == 0);
		}

		private void btnClearPhoto_Click(object sender, EventArgs e)
		{
			filePhotoPath = "";
			bClearPhoto = true;
			picPhoto.Image = null;
		}
	}
}
