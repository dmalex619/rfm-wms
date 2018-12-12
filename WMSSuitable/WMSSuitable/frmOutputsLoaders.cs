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
	public partial class frmOutputsLoaders : RFMFormChild
	{
		protected Output oOutput;

		private User oValidateUser;

		private StoreZone oStoreZone;
		private User oUser;

		DataTable dtOutputsLoaders = null;

		string _cMode = "";

		protected bool _bLoaded = false; 

		public frmOutputsLoaders(int nOutputID)
		{
			oValidateUser = new User();
			oOutput = new Output();
			oStoreZone = new StoreZone();
			oUser = new User();
			if (oValidateUser.ErrorNumber != 0 || 
				oOutput.ErrorNumber != 0 ||
				oStoreZone.ErrorNumber != 0 ||
				oUser.ErrorNumber != 0)
			{
				IsValid = false;
			}

			if (IsValid)
			{
				InitializeComponent();
				oOutput.ID = nOutputID;
			}
		}
		
		private void frmOutputsLoaders_Load(object sender, EventArgs e)
		{
			bool lResult = true;

			// заполнение cbo-классификаторов 
			lResult = cboValidateUser_Restore() && 
					  cboStoreZone_Restore() &&
					  cboUser_Restore() &&
					  cboBrigade_Restore();
			if (!lResult)
			{
				RFMMessage.MessageBoxError("Ошибка при заполнении классификаторов...");
			}

			if (lResult)
			{
				cboValidateUser.SelectedIndex = -1; 
				cboStoreZone.SelectedIndex = -1;
				cboUser.SelectedIndex = -1;
				cboBrigade.SelectedIndex = -1;

				// сам расход
				oOutput.FillData();
				if (oOutput.ErrorNumber != 0 || oOutput.MainTable.Rows.Count == 0)
				{
					lResult = false;
					RFMMessage.MessageBoxError("Ошибка при получении данных о расходе...");
				}

				if (lResult)
				{
					// шапка формы 
					DataRow r = oOutput.MainTable.Rows[0];
					txtID.Text = r["ID"].ToString();
					txtErpCode.Text = r["ErpCode"].ToString();
					txtDateOutput.Text = r["DateOutput"].ToString().Substring(0, 10);
					txtOutputBarCode.Text = r["BarCode"].ToString();

					txtOwnerName.Text = r["OwnerName"].ToString();
					txtPartnerName.Text = r["PartnerName"].ToString();

					txtGoodStateName.Text = r["GoodStateName"].ToString();
					txtOutputTypeName.Text = r["OutputTypeName"].ToString();
					txtCellAdress.Text = r["CellAddress"].ToString();

					// Коэффициент сложности загрузки
					numCoefficientLoad.Value = Convert.ToDecimal(r["CoefficientLoad"]);

					// фактически отгружено поддонов
					numPalletsFactQnt.Value = Convert.ToInt32(r["PalletsFactQnt"]);
				
					// проверяющий
					if (!Convert.IsDBNull(r["ValidateUserID"]))
						cboValidateUser.SelectedValue = Convert.ToInt32(r["ValidateUserID"]);

					// источник для grid
					oOutput.FillTableOutputsLoaders((int)oOutput.ID);
					if (oOutput.ErrorNumber != 0 || oOutput.TableOutputsLoaders == null)
					{
						lResult = false;
						RFMMessage.MessageBoxError("Ошибка при получении данных о сотрудниках, выполнявших загрузку товара для расхода...");
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
			int nOutputID = (int)oOutput.ID;

			// всякие проверки
			if (dtOutputsLoaders.Rows.Count == 0)
			{
				if (RFMMessage.MessageBoxYesNo("В таблице нет ни одной строки.\nСохранить пустую таблицу?") != DialogResult.Yes)
					return;
			}

			oOutput.LoadersSave(nOutputID, dtOutputsLoaders);
			//
			if (oOutput.ErrorNumber == 0)
			{
				// к-т загрузки
				decimal nCoefficientLoad = numCoefficientLoad.Value;
				if (oOutput.CoefficientLoadSave(nOutputID, nCoefficientLoad) &&
					oOutput.ErrorNumber == 0)
				{
					if (oOutput.PalletsFactQntSave(nOutputID, (int)numPalletsFactQnt.Value) &&
						oOutput.ErrorNumber == 0)
					{
						int? nValidateUserID = null;
						if (cboValidateUser.SelectedIndex >= 0 && cboValidateUser.SelectedValue != null)
							nValidateUserID = (int)cboValidateUser.SelectedValue; 
						if (oOutput.ValidateUserSave(nOutputID, nValidateUserID) &&
							oOutput.ErrorNumber == 0)
						{
							DialogResult = DialogResult.Yes;
							Dispose();
						}
					}
				}
			}
		}

	#region Restore

		private bool cboValidateUser_Restore()
		{
			oValidateUser.FillData();
			if (oValidateUser.ErrorNumber == 0 && oValidateUser.MainTable != null)
			{
				oValidateUser.MainTable.PrimaryKey = new DataColumn[] { oUser.MainTable.Columns["ID"] };

				//cboValidateUser.DataSource = oValidateUser.MainTable;
				cboValidateUser.Restore(oValidateUser.MainTable);
				cboValidateUser.ValueMember = oValidateUser.ColumnID;
				cboValidateUser.DisplayMember = oValidateUser.ColumnName;
			}
			return (oValidateUser.ErrorNumber == 0);
		}

		private bool cboStoreZone_Restore()
		{
			oStoreZone.FilterStoreZoneTypeForPicking = true;
			oStoreZone.FillData();
			if (oStoreZone.ErrorNumber == 0 && oStoreZone.MainTable != null)
			{
				DataTable dtStoreZone = oStoreZone.MainTable;
				if (chkOutlayOnly.Checked)
				{
					// оставить только те, что есть в расходе
					oOutput.FillTableOutputsGoods((int)oOutput.ID);
					if (oOutput.ErrorNumber == 0 && oOutput.TableOutputsGoods != null)
					{
						dtStoreZone = oStoreZone.MainTable.Clone();
						foreach (DataRow rSZ in oStoreZone.MainTable.Rows)
						{
							int nTableStoreZoneID = Convert.ToInt32(rSZ["ID"]);
							foreach (DataRow rOG in oOutput.TableOutputsGoods.Rows)
							{
								if (!Convert.IsDBNull(rOG["StoreZoneID"]))
								{
									if (Convert.ToInt32(rOG["StoreZoneID"]) == nTableStoreZoneID)
									{
										dtStoreZone.ImportRow(rSZ);
										break;
									}
								}
							}
						}
					}
				}
				
				cboStoreZone.ValueMember = oStoreZone.ColumnID;
				cboStoreZone.DisplayMember = oStoreZone.ColumnName;
				cboStoreZone.DataSource = dtStoreZone; //oStoreZone.MainTable;
			}
			return (oStoreZone.ErrorNumber == 0);
		}

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
			dtOutputsLoaders = CopyTable(oOutput.TableOutputsLoaders, "dtOutputsLoaders", "", "StoreZoneName, UserName");
			dtOutputsLoaders.Columns["ID"].Unique = false;
			dtOutputsLoaders.Columns["ID"].AutoIncrement = false;

			grdData.Restore(dtOutputsLoaders);
		}

	#endregion

	#region RowEnter, CellFormatting

		private void grdData_RowEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (grdData.Rows.Count == 0 || grdData.CurrentRow == null)
			{
				cboStoreZone.SelectedIndex = -1;
				cboUser.SelectedIndex = -1;
				cboBrigade.SelectedIndex = -1; 
				return;
			}

			DataRow r = ((DataRowView)grdData.Rows[e.RowIndex].DataBoundItem).Row;  
			if (!Convert.IsDBNull(r["StoreZoneID"]))
			{
				cboStoreZone.SelectedValue = Convert.ToInt32(r["StoreZoneID"]);
			}
			else
			{
				cboStoreZone.SelectedIndex = -1;
			}
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

			numCoefficientLoad.Enabled = false;

			pnlDataChange.BorderStyle = BorderStyle.Fixed3D;
			pnlDataChange.Enabled = true;

			grdData.Enabled = false;

			_cMode = "A";
			
			cboStoreZone.SelectedIndex =
			cboUser.SelectedIndex =
			cboBrigade.SelectedIndex =
				-1;
			
			cboStoreZone.SelectedIndex = -1;
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

			numCoefficientLoad.Enabled = false;

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
			int? nStoreZoneID = null;
			string sStoreZoneName = "";
			if (cboStoreZone.SelectedValue != null && cboStoreZone.SelectedIndex >= 0)
			{
				nStoreZoneID = Convert.ToInt32(cboStoreZone.SelectedValue);
				sStoreZoneName = cboStoreZone.Text;
			}
			int nUserID = Convert.ToInt32(cboUser.SelectedValue);
			string sUserName = cboUser.Text;
			int? nBrigadeID = null;
			string sBrigadeName = "";
			if (cboBrigade.SelectedValue != null && cboBrigade.SelectedIndex >= 0)
			{
				nBrigadeID = Convert.ToInt32(cboBrigade.SelectedValue);
				sBrigadeName = cboBrigade.Text;
			}

			switch (_cMode)
			{
				case "A":
					// нет ли этого пользователя/зоны
					foreach (DataRow r in dtOutputsLoaders.Rows)
					{
						if (r.RowState == DataRowState.Deleted)
							continue;

						int nTempUserID = Convert.ToInt32(r["UserID"]);
						int? nTempStoreZoneID = null;
						if (!Convert.IsDBNull(r["StoreZoneID"]))
						{ 
							nTempStoreZoneID = Convert.ToInt32(r["StoreZoneID"]);
						}

						if (nStoreZoneID == null && nTempStoreZoneID != null)
						{
							RFMMessage.MessageBoxError("Не указана зона для сотрудника,\nв то время как в таблице есть указания зоны...");
							return;
						}
						if (nStoreZoneID != null && nTempStoreZoneID == null)
						{
							RFMMessage.MessageBoxError("Указана зона для сотрудника,\nв то время как в таблице нет указания зоны...");
							return;
						}

						if (nUserID == nTempUserID &&
							(nTempStoreZoneID != null && nStoreZoneID != null && nTempStoreZoneID == nStoreZoneID ||
							 nTempStoreZoneID == null && nStoreZoneID == null) )
						{
							RFMMessage.MessageBoxError("Такой сотрудник уже включен в таблицу...");
							return;
						}
					}

					// добавляем строку в таблицу
					DataRow rAdd = dtOutputsLoaders.Rows.Add();

					rAdd["ID"] = DBNull.Value;
					if (nStoreZoneID.HasValue)
					{
						rAdd["StoreZoneID"] = nStoreZoneID;
						rAdd["StoreZoneName"] = sStoreZoneName;
					}
					else
					{
						rAdd["StoreZoneID"] = DBNull.Value;
						rAdd["StoreZoneName"] = "";
					}
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
					for (int i = 0; i < dtOutputsLoaders.Rows.Count; i++)
					{
						DataRow r = dtOutputsLoaders.Rows[i];
						if (r.RowState == DataRowState.Deleted)
							continue;
						if (r == rEdit)
							continue;// та же запись
						
						int nTempUserID = Convert.ToInt32(r["UserID"]);
						int? nTempStoreZoneID = null;
						if (!Convert.IsDBNull(r["StoreZoneID"]))
						{
							nTempStoreZoneID = Convert.ToInt32(r["StoreZoneID"]);
						}

						if (nUserID == nTempUserID)
						{
							RFMMessage.MessageBoxError("Такой сотрудник уже включен в таблицу...");
							return;
						}
						if (nStoreZoneID == null && nTempStoreZoneID != null)
						{
							RFMMessage.MessageBoxError("Не указана зона для сотрудника,\nв то время как в таблице есть указания зоны...");
							return;
						}
						if (nStoreZoneID != null && nTempStoreZoneID == null)
						{
							RFMMessage.MessageBoxError("Указана зона для сотрудника,\nв то время как в таблице нет указания зоны...");
							return;
						}
					}

					// исправляем строку в таблице
					if (nStoreZoneID.HasValue)
					{
						rEdit["StoreZoneID"] = nStoreZoneID;
						rEdit["StoreZoneName"] = cboStoreZone.Text;
					}
					else
					{
						rEdit["StoreZoneID"] = DBNull.Value;
						rEdit["StoreZoneName"] = "";
					}
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

			numCoefficientLoad.Enabled = true;

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
				dtOutputsLoaders.Rows.Remove(r);
			}

			grdData.Refresh();
			grdData.Select();
			if (grdData.Rows.Count == 0 || grdData.CurrentRow == null)
			{
				cboStoreZone.SelectedIndex =
				cboUser.SelectedIndex =
				cboBrigade.SelectedIndex =
					-1;

				cboStoreZone.SelectedIndex = -1;
				cboUser.SelectedIndex = -1;
				cboBrigade.SelectedIndex = -1;
			}
		}

	#endregion

		private void txtValidateTabNumber_TextChanged(object sender, EventArgs e)
		{
			if (txtValidateTabNumber.Text.Trim().Length == 3)
			{
				string sTabNumber = txtValidateTabNumber.Text.Trim();
				bool bFound = false;
				foreach (DataRow r in oValidateUser.MainTable.Rows)
				{
					string sBarCode = r["BarCode"].ToString();
					if (sBarCode.Substring(sBarCode.Length - 3, 3) == sTabNumber)
					{
						cboValidateUser.SelectedValue = Convert.ToInt32(r["ID"]);
						bFound = true;
						break;
					}
				}
				if (!bFound)
				{
					cboValidateUser.SelectedIndex = -1;
				}
			}
		}

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

		private void btnStoreZoneClear_Click(object sender, EventArgs e)
		{
			cboStoreZone.SelectedIndex = -1;
		}

		private void btnValidateUserClear_Click(object sender, EventArgs e)
		{
			cboValidateUser.SelectedIndex = -1;
			cboValidateUser.SelectedValue = 0;
			cboValidateUser.Text = "";
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

		private void chkOutlayOnly_CheckedChanged(object sender, EventArgs e)
		{
			cboStoreZone_Restore();
		}
	}
}