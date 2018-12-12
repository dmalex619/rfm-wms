using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

using WMSBizObjects;
using RFMBaseClasses;
using RFMPublic;

namespace WMSSuitable
{
	public partial class frmInputsUnloaders : RFMFormChild
	{
		protected Input oInput;

		private User oUser;

		DataTable dtInputsUnloaders = null;

		string _cMode = "";

		protected bool _bLoaded = false; 

		public frmInputsUnloaders(int nInputID)
		{
			oInput = new Input();
			oUser = new User();
			if (oInput.ErrorNumber != 0 ||
				oUser.ErrorNumber != 0)
			{
				IsValid = false;
			}

			if (IsValid)
			{
				InitializeComponent();
				oInput.ID = nInputID;
			}
		}
		
		private void frmInputsUnloaders_Load(object sender, EventArgs e)
		{
			bool lResult = true;

			// заполнение cbo-классификаторов 
			lResult = cboUser_Restore() &&
					  cboBrigade_Restore();
			if (!lResult)
			{
				RFMMessage.MessageBoxError("Ошибка при заполнении классификаторов...");
			}

			if (lResult)
			{
				cboUser.SelectedIndex = -1;
				cboBrigade.SelectedIndex = -1;

				// сам приход
				oInput.FillData();
				if (oInput.ErrorNumber != 0 || oInput.MainTable.Rows.Count == 0)
				{
					lResult = false;
					RFMMessage.MessageBoxError("Ошибка при получении данных о приходе...");
				}

				if (lResult)
				{
					// шапка формы 
					DataRow r = oInput.MainTable.Rows[0];
					txtID.Text = r["ID"].ToString();
					txtErpCode.Text = r["ErpCode"].ToString();
					txtDateInput.Text = r["DateInput"].ToString().Substring(0, 10);
					txtInputBarCode.Text = r["BarCode"].ToString();

					txtOwnerName.Text = r["OwnerName"].ToString();
					txtPartnerName.Text = r["PartnerName"].ToString();

					txtGoodStateName.Text = r["GoodStateName"].ToString();
					txtInputTypeName.Text = r["InputTypeName"].ToString();

					// Коэффициент сложности загрузки
					numCoefficientUnload.Value = Convert.ToDecimal(r["CoefficientUnload"]);

					// Фактически принято поддонов
					numPalletsFactQnt.Value = Convert.ToInt32(r["PalletsFactQnt"]);

					// источник для grid
					oInput.FillTableInputsUnloaders((int)oInput.ID);
					if (oInput.ErrorNumber != 0 || oInput.TableInputsUnloaders == null)
					{
						lResult = false;
						RFMMessage.MessageBoxError("Ошибка при получении данных о сотрудниках, выполнявших прием товара...");
					}

					if (lResult)
					{
						grdData_Restore();
					}
				}
			}

			if (!lResult)
			{
				Dispose();
				return;
			}

			pnlDataChange.Enabled = false;
			btnAdd.Enabled = true;
			btnEdit.Enabled = false;
			btnDelete.Enabled = false;
			btnGridSave.Enabled = false;
			btnGridUndo.Enabled = false;

			grdData.Select();

			_bLoaded = true;
		}

		private void btnHelp_Click(object sender, EventArgs e)
		{
			RFMHelpUtilities.HelpShow(this, hpHelp);
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.No;
			this.Dispose();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			int nInputID = (int)oInput.ID;

			// всякие проверки
			if (dtInputsUnloaders.Rows.Count == 0)
			{
				if (RFMMessage.MessageBoxYesNo("В таблице нет ни одной строки.\nСохранить пустую таблицу?") != DialogResult.Yes)
					return;
			}

			oInput.UnloadersSave(nInputID, dtInputsUnloaders);
			//
			if (oInput.ErrorNumber == 0)
			{
				// к-т загрузки
				decimal nCoefficientUnload = numCoefficientUnload.Value;
				if (oInput.CoefficientUnloadSave(nInputID, nCoefficientUnload) && 
					oInput.ErrorNumber == 0)
				{
					if (oInput.PalletsFactQntSave(nInputID, (int)numPalletsFactQnt.Value) &&
						oInput.ErrorNumber == 0)
					{
						DialogResult = DialogResult.Yes;
						Dispose();
					}
				}
			}
		}

	#region Restore

		private bool cboUser_Restore()
		{
			oUser.FillData();
			if (oUser.ErrorNumber == 0 && oUser.MainTable != null)
			{
				oUser.MainTable.PrimaryKey = new DataColumn[] { oUser.MainTable.Columns["ID"] };

				cboUser.DataSource = oUser.MainTable;
				cboUser.ValueMember = oUser.ColumnID;
				cboUser.DisplayMember = oUser.ColumnName;
			}
			return (oUser.ErrorNumber == 0);
		}

		private bool cboBrigade_Restore()
		{
			oUser.FillTableBrigades();
			if (oUser.ErrorNumber == 0 && oUser.TableBrigades != null)
			{
				cboBrigade.ValueMember = "ID"; // oUser.TableBrigades.Columns[0].ColumnName;
				cboBrigade.DisplayMember = "Name"; // oUser.TableBrigades.Columns[1].ColumnName;
				cboBrigade.DataSource = oUser.TableBrigades;
			}
			return (oUser.ErrorNumber == 0);
		}

		private void grdData_Restore()
		{
			dtInputsUnloaders = CopyTable(oInput.TableInputsUnloaders, "dtInputsUnloaders", "", "UserName");
			dtInputsUnloaders.Columns["ID"].Unique = false;
			dtInputsUnloaders.Columns["ID"].AutoIncrement = false;

			grdData.Restore(dtInputsUnloaders);
		}

	#endregion

	#region RowEnter, CellFormatting

		private void grdData_RowEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (grdData.Rows.Count == 0 || grdData.CurrentRow == null)
			{
				cboUser.SelectedIndex = -1;
				cboBrigade.SelectedIndex = -1; 
				return;
			}

			DataRow r = ((DataRowView)grdData.Rows[e.RowIndex].DataBoundItem).Row;  
			cboUser.SelectedValue = Convert.ToInt32(r["UserID"]);
			if (!Convert.IsDBNull(r["BrigadeID"]))
			{
				cboBrigade.SelectedValue = Convert.ToInt32(r["BrigadeID"]);
			}
			else
			{
				cboBrigade.SelectedIndex = -1;
			}
			txtTabNumber.Text = "";

			btnEdit.Enabled = true;
			btnDelete.Enabled = true;
		}
				
	#endregion

	#region GridButtons

		private void btnAdd_Click(object sender, EventArgs e)
		{
			// добавление 

			btnSave.Enabled = false;
			btnAdd.Enabled = false;
			btnEdit.Enabled = false;
			btnDelete.Enabled = false;
			btnGridSave.Enabled = true;
			btnGridUndo.Enabled = true;

			numCoefficientUnload.Enabled = false;

			pnlDataChange.BorderStyle = BorderStyle.Fixed3D;
			pnlDataChange.Enabled = true;

			grdData.Enabled = false;

			_cMode = "A";
			
			cboUser.SelectedIndex =
			cboBrigade.SelectedIndex =
				-1;
			
			cboUser.SelectedIndex = -1;
			cboBrigade.SelectedIndex = -1;

			txtTabNumber.Select();
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			// изменение
			if (grdData.CurrentRow == null)
				return;

			btnSave.Enabled = false;
			btnAdd.Enabled = false;
			btnEdit.Enabled = false;
			btnDelete.Enabled = false;
			btnGridSave.Enabled = true;
			btnGridUndo.Enabled = true;

			numCoefficientUnload.Enabled = false;

			pnlDataChange.BorderStyle = BorderStyle.Fixed3D;
			pnlDataChange.Enabled = true;

			grdData.Enabled = false;

			_cMode = "E";
		}

		private void btnGridSave_Click(object sender, EventArgs e)
		{
			// всякие проверки
			if (cboUser.SelectedValue == null || cboUser.SelectedIndex < 0)
			{
				RFMMessage.MessageBoxError("Не указан сотрудник...");
				return;
			}

			// сохранить в DataTable
			int nUserID = Convert.ToInt32(cboUser.SelectedValue);
			string sUserName = cboUser.Text;
			int? nBrigadeID = null;
			string sBrigadeName = "";
			if (cboBrigade.SelectedValue != null)
			{
				nBrigadeID = Convert.ToInt32(cboBrigade.SelectedValue);
				sBrigadeName = cboBrigade.Text;
			}

			switch (_cMode)
			{
				case "A":
					// нет ли этого пользователя
					foreach (DataRow r in dtInputsUnloaders.Rows)
					{
						if (r.RowState == DataRowState.Deleted)
							continue;

						int nTempUserID = Convert.ToInt32(r["UserID"]);
						if (nUserID == nTempUserID)
						{
							RFMMessage.MessageBoxError("Такой сотрудник уже включен в таблицу...");
							return;
						}
					}

					// добавляем строку в таблицу
					DataRow rAdd = dtInputsUnloaders.Rows.Add();

					rAdd["ID"] = DBNull.Value;
					rAdd["UserID"] = nUserID;
					rAdd["UserName"] = sUserName;
					if (nBrigadeID.HasValue)
					{
						rAdd["BrigadeID"] = nBrigadeID;
						rAdd["BrigadeName"] = sBrigadeName;
					}
					else
					{
						rAdd["BrigadeID"] = DBNull.Value;
						rAdd["BrigadeName"] = "";
					}

					break;

				case "E":
					
					// текущая строка для исправления
					DataRow rEdit = ((DataRowView)grdData.GridSource.Current).Row;

					// нет ли этого сотрудника
					for (int i = 0; i < dtInputsUnloaders.Rows.Count; i++)
					{
						DataRow r = dtInputsUnloaders.Rows[i];
						if (r.RowState == DataRowState.Deleted)
							continue;
						if (r == rEdit)
							continue;// та же запись
						
						int nTempUserID = Convert.ToInt32(r["UserID"]);
						if (nUserID == nTempUserID)
						{
							RFMMessage.MessageBoxError("Такой сотрудник уже включен в таблицу...");
							return;
						}
					}

					// исправляем строку в таблице
					rEdit["UserID"] = nUserID;
					rEdit["UserName"] = cboUser.Text;
					if (nBrigadeID.HasValue)
					{
						rEdit["BrigadeID"] = nBrigadeID;
						rEdit["BrigadeName"] = cboBrigade.Text;
					}
					else
					{
						rEdit["BrigadeID"] = DBNull.Value;
						rEdit["BrigadeName"] = "";
					}

					break;
			}

			btnGridUndo_Click(null, null);
		}

		private void btnGridUndo_Click(object sender, EventArgs e)
		{
			//if (grdData.CurrentRow == null)
			//	return;

			pnlDataChange.BorderStyle = BorderStyle.FixedSingle;
			pnlDataChange.Enabled = false;
			grdData.Enabled = true;
			grdData.Refresh();

			btnSave.Enabled = true;
			btnGridSave.Enabled = false;
			btnGridUndo.Enabled = false;
			btnAdd.Enabled = true;

			numCoefficientUnload.Enabled = true;

			_cMode = "";

			grdData.Select();
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (grdData.CurrentRow == null)
				return;

			DataRow r = ((DataRowView)grdData.CurrentRow.DataBoundItem).Row;
			if (RFMMessage.MessageBoxYesNo("Удалить запись?") == DialogResult.Yes)
			{
				dtInputsUnloaders.Rows.Remove(r);
			}

			grdData.Refresh();
			grdData.Select();
			if (grdData.Rows.Count == 0 || grdData.CurrentRow == null)
			{
				cboUser.SelectedIndex =
				cboBrigade.SelectedIndex =
					-1;

				cboUser.SelectedIndex = -1;
				cboBrigade.SelectedIndex = -1;
			}
		}

	#endregion

		private void txtTabNumber_TextChanged(object sender, EventArgs e)
		{
            if (txtTabNumber.Text.Trim().Length == 3)
            {
                string sTabNumber = txtTabNumber.Text.Trim();
                bool bFound = false;
                foreach (DataRow r in oUser.MainTable.Rows)
                { 
                    string sBarCode = r["BarCode"].ToString();
                    if (sBarCode.Substring(sBarCode.Length - 3, 3) == sTabNumber)
                    {
                        cboUser.SelectedValue = Convert.ToInt32(r["ID"]);
                        bFound = true;
						// бригада
                        break;
                    }
                }
                if (!bFound)
                {
                    cboUser.SelectedIndex = -1;
                }
            }
		}

		private void cboUser_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!_bLoaded)
				return;

			if (cboUser.SelectedValue == null | cboUser.SelectedIndex < 0)
			{
				cboBrigade.SelectedIndex = -1;
			}
			else
			{
				int? nBrigadeID = null;
				int nUserID = (int)cboUser.SelectedValue;
				DataRow u = oUser.MainTable.Rows.Find(nUserID);
				if (u != null)
				{ 
					if (!Convert.IsDBNull(u["BrigadeID"]))
					{
						nBrigadeID = Convert.ToInt32(u["BrigadeID"]);
					}
				}
				if (nBrigadeID.HasValue)
					cboBrigade.SelectedValue = (int)nBrigadeID;
				else
					cboBrigade.SelectedIndex = -1;
			}
		}

	}
}