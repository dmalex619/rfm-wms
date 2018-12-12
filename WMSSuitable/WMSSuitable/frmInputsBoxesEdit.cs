using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using WMSBizObjects;
using RFMBaseClasses;
using RFMPublic;


namespace WMSSuitable
{
	public partial class frmInputsBoxesEdit : RFMFormChild
	{
		public int? _SelectedPackingID;
		private Input oInput;
		private GoodState oGoodState;
		private Cell oCell;
		private User oUser;

		private int nInputID;
		private bool bFillDateStart = false;

		int? nHostID = null;
		private int? nUserHostID = null;


		public frmInputsBoxesEdit(int? _ID)
			: base()
		{
			oInput = new Input();
			oGoodState = new GoodState();
			oUser = new User();
			oCell = new Cell();
			IsValid = (oInput.ErrorNumber == 0 && 
						oGoodState.ErrorNumber == 0 && 
						oCell.ErrorNumber == 0 && 
						oUser.ErrorNumber == 0);
			if (IsValid)
			{
				InitializeComponent();

				if (_ID.HasValue)
					nInputID = (int)_ID;
			}
		}

		private void frmGoodsInputsEdit_Load(object sender, EventArgs e)
		{
			nUserHostID = ((RFMFormMain)Application.OpenForms[0]).UserInfo.HostID;

			dgvcQntArranged.AgrType =
			dgvcQntWished.AgrType =
			dgvcBoxArranged.AgrType =
			dgvcBoxWished.AgrType =
				EnumAgregate.Sum;

			oInput.ID = nInputID; 
			oInput.FillData();
			if (oInput.ErrorNumber != 0 || oInput.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о приходе...");
				Dispose();
			}

			bool bResult = cboCells_Restore() && cboHeavers_Restore() && cboNewGoodState_Restore() && dgvInputGoods_Restore();
			if (!bResult)
			{
				RFMMessage.MessageBoxError("Ошибка получения данных...");
				Dispose();
			}

			DataRow DroRow = oInput.MainTable.Rows[0];

			if (!Convert.IsDBNull(DroRow["HostID"]))
				nHostID = (int)DroRow["HostID"];
			if (!nHostID.HasValue && nUserHostID.HasValue)
				nHostID = nUserHostID; 
			if (nHostID.HasValue && nUserHostID.HasValue && 
				(int)nUserHostID != (int)nHostID)
			{
				RFMMessage.MessageBoxError("Несовпадение прав доступа к данным хоста...");
				Dispose();
				return;
			}

			if (DroRow["DateStart"] == DBNull.Value)
			{
				oInput.SetDateStart(nInputID);
				bFillDateStart = true;
			}
			txtDateInput.Text     = DroRow["DateInput"].ToString().Substring(0, 10);
			txtGoodStateName.Text = DroRow["GoodStateName"].ToString().Trim();
			txtInputTypeName.Text = DroRow["InputTypeName"].ToString().Trim();
			txtOwnerName.Text     = DroRow["OwnerName"].ToString().Trim();
			txtProducerName.Text  = DroRow["PartnerName"].ToString().Trim(); 
			cboHeavers.SelectedValue = ((RFMFormBase)Application.OpenForms[0]).UserInfo.UserID;
			ShowStrikes();
		}

		#region Restore
		
		private bool dgvInputGoods_Restore()
		{
			oInput.FillTableInputsGoodsItems(nInputID, false);
			if (oInput.ErrorNumber == 0)
				dgvInputGoods.Restore(oInput.TableInputsGoods);
			return (oInput.ErrorNumber == 0);
		}

		private bool cboCells_Restore()
		{
			oCell.FilterStoreZoneTypeForInputs = true;
			oCell.FillData();
			if (oCell.ErrorNumber == 0)
			{
				cboCells.ValueMember = oCell.ColumnID;
				cboCells.DisplayMember = "Address"; // oCell.ColumnName;
				cboCells.DataSource = new DataView(oCell.MainTable);
				oInput.FillTableInputsItems(nInputID);
				if (oInput.TableInputsItems != null && oInput.TableInputsItems.Rows.Count > 0)
				{
					cboCells.SelectedValue = (int)oInput.TableInputsItems.Rows[0]["CellID"];
					cboCells.Enabled = false;
				}
			}
			return (oCell.ErrorNumber == 0);
		}

		private bool cboNewGoodState_Restore()
		{
			oGoodState.FillData();
			if (oGoodState.ErrorNumber == 0)
			{
				cboNewGoodState.ValueMember = oGoodState.ColumnID;
				cboNewGoodState.DisplayMember = oGoodState.ColumnName;
				cboNewGoodState.DataSource = new DataView(oGoodState.MainTable);
			}
			return (oGoodState.ErrorNumber == 0);
		}
		
		private bool cboHeavers_Restore()
		{
			oUser.FillData();
			if (oUser.ErrorNumber == 0)
			{
				cboHeavers.ValueMember = oUser.ColumnID;
				cboHeavers.DisplayMember = oUser.MainTable.Columns[("Name")].ToString();
				cboHeavers.DataSource = oUser.MainTable;
			}
			return (oUser.ErrorNumber == 0);
		}
		
		#endregion

		#region Cell...

		private void dgvInputGoods_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (dgvInputGoods.DataSource == null || dgvInputGoods.CurrentRow == null)
				return;


			if (dgvInputGoods.IsStatusRow(e.RowIndex))
			{

				if (dgvInputGoods.Columns[e.ColumnIndex].Name.ToLower() == "dgvcimage")
				{
					e.Value = Properties.Resources.Empty;
					return;
				}
			}


			DataRow droRow = ((DataRowView)dgvInputGoods.Rows[e.RowIndex].DataBoundItem).Row;
			if (droRow == null)
				return;

			if (droRow["QntArranged"] == DBNull.Value)
				droRow["QntArranged"] = 0;

			if (dgvInputGoods.Columns[e.ColumnIndex].Name == "dgvcImage")
			{
				if ((decimal)droRow["QntArranged"] == (decimal)droRow["QntWished"])
				{
					e.Value = Properties.Resources.DotGreen;
				}
				else
				{
					if ((decimal)droRow["QntArranged"] == 0)
						e.Value = Properties.Resources.DotRed;
					else
						e.Value = Properties.Resources.DotYellow;
				}
			}

			switch (dgvInputGoods.Columns[e.ColumnIndex].Name)
			{
				case "dgvcInBox":
				case "dgvcQntWished":
				case "dgvcQntArranged":
					if (!Convert.IsDBNull(droRow["Weighting"]) &&
						Convert.ToBoolean(droRow["Weighting"]) ||
						!Convert.IsDBNull(e.Value) && Convert.ToDecimal(e.Value) != Convert.ToInt32(e.Value))
						e.CellStyle.Format = "### ### ### ##0.000";
					else
						e.CellStyle.Format = "### ### ### ###";
					break;
			}
		}

		private void dgvInputGoods_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
			if (dgvInputGoods.Columns[e.ColumnIndex].Name.Contains("Qnt"))
			{
				DataRow dr = ((DataRowView)((DataGridViewRow)dgvInputGoods.CurrentRow).DataBoundItem).Row;
				decimal nInbox = (decimal)dr["InBox"];
				((RFMDataGridViewTextBoxNumericColumn)dgvInputGoods.Columns[e.ColumnIndex]).DecimalPlaces =
					(nInbox != (int)nInbox || (bool)dr["Weighting"]) ? 3 : 0;
			}
		}

		private void dgvInputGoods_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if (oInput.TableInputsGoods.Rows.Count == 0)
				return;

			if (dgvInputGoods.IsStatusRow(e.RowIndex))
				return;

			if (dgvInputGoods.Columns[e.ColumnIndex].Name == "dgvcQntArranged" ||
				dgvInputGoods.Columns[e.ColumnIndex].Name == "dgvcBoxArranged")
			{
				DataRow droRow = ((DataRowView)dgvInputGoods.Rows[e.RowIndex].DataBoundItem).Row;
				if (droRow != null)
				{
					decimal nInbox = (decimal)droRow["InBox"];
					if (dgvInputGoods.Columns[e.ColumnIndex].Name == "dgvcQntArranged")
					{
						if (dgvInputGoods.Rows[e.RowIndex].Cells["dgvcQntArranged"].Value == DBNull.Value || 
							dgvInputGoods.Rows[e.RowIndex].Cells["dgvcQntArranged"].Value == null)
						{
							droRow["QntArranged"] = 0;
							droRow["BoxArranged"] = 0;
						}
						else
							// меняем штуки
							droRow["BoxArranged"] = (decimal)dgvInputGoods.Rows[e.RowIndex].Cells["dgvcQntArranged"].Value / nInbox;
					}

					if (dgvInputGoods.Columns[e.ColumnIndex].Name == "dgvcBoxArranged")
					{
						if (dgvInputGoods.Rows[e.RowIndex].Cells["dgvcBoxArranged"].Value == DBNull.Value ||
							dgvInputGoods.Rows[e.RowIndex].Cells["dgvcBoxArranged"].Value == null)
						{
							droRow["QntArranged"] = 0;
							droRow["BoxArranged"] = 0;
						}
						else
						{
							// меняем коробки
							if ((bool)dgvInputGoods.Rows[e.RowIndex].Cells["dgvcWeighting"].Value || 
								(int)nInbox != nInbox)
							{
								droRow["QntArranged"] = (decimal)dgvInputGoods.Rows[e.RowIndex].Cells["dgvcBoxArranged"].Value * nInbox;
							}
							else
							{
								droRow["QntArranged"] = decimal.Ceiling(decimal.Round(((decimal)dgvInputGoods.Rows[e.RowIndex].Cells["dgvcBoxArranged"].Value * nInbox), 1));
							}
						}
					}
					dgvInputGoods.CommitChanges();
					dgvInputGoods.Refresh();
					ShowStrikes();
				}
			}
		}

		private void dgvInputGoods_CellValidated(object sender, DataGridViewCellEventArgs e)
		{
		   DataGridViewRow dgr = dgvInputGoods.Rows[e.RowIndex];
		   if (dgvInputGoods.Columns[e.ColumnIndex].Name == "dgvcQntArranged")
		   {
		      if (dgr.Cells["dgvcQntArranged"].Value == DBNull.Value ||
				  dgr.Cells["dgvcQntArranged"].Value == null)
		      {
		         dgr.Cells["dgvcQntArranged"].Value = 0;
		      }
		   }

		   if (dgvInputGoods.Columns[e.ColumnIndex].Name == "dgvcBoxArranged")
		   {
		      if (dgr.Cells["dgvcBoxArranged"].Value == DBNull.Value ||
				  dgr.Cells["dgvcBoxArranged"].Value == null)
		      {
		         dgr.Cells["dgvcBoxArranged"].Value = 0;
		      }
		   }
		}


		#endregion
		
		#region Buttons

		private void btnExit_Click(object sender, EventArgs e)
		{
			if (RFMMessage.MessageBoxYesNo("Прервать работу с формой?") == DialogResult.Yes)
			{
				if (bFillDateStart)
					oInput.ClearDateStart(nInputID);
				DialogResult = DialogResult.No;
				this.Dispose();
			}
		}

		private void btnNewGood_Click(object sender, EventArgs e)
		{
			_SelectedPackingID = null;
			bool bFound = false;
			string cFoundGoodName = null, cFoundGoodStateName = null;
			if (StartForm(new frmSelectOnePacking(this, false, nHostID)) == DialogResult.Yes)
			{
				if (_SelectedPackingID != null)
				{
					int nGoodStateID = (int)cboNewGoodState.SelectedValue;
					for (int i = 0; i < oInput.TableInputsGoods.Rows.Count; i++)
					{
						if (oInput.TableInputsGoods.Rows[i]["PackingID"] == DBNull.Value)
							continue;
						if (_SelectedPackingID == (int)oInput.TableInputsGoods.Rows[i]["PackingID"] &&
							nGoodStateID == (int)oInput.TableInputsGoods.Rows[i]["GoodStateID"])
						{
							bFound = true;
							cFoundGoodName = oInput.TableInputsGoods.Rows[i]["GoodAlias"].ToString();
							cFoundGoodStateName = oInput.TableInputsGoods.Rows[i]["GoodStateName"].ToString();
							break;
						}
					}
					if (bFound)
					{
						RFMMessage.MessageBoxError("Уже есть такой товар: " + '"' + cFoundGoodName + '"'  +
							"\nв состоянии " + '"' + cFoundGoodStateName + '"');
						return;
					}
					else
					{
						//int nRow = dgvInputGoods.CurrentRow.Index;
						int nCell = dgvInputGoods.CurrentCell.ColumnIndex;
						oInput.AddTableInputsGoods((int)_SelectedPackingID, nGoodStateID);
						dgvInputGoods.Restore(oInput.TableInputsGoods);
						dgvInputGoods.CurrentCell = dgvInputGoods.Rows[dgvInputGoods.Rows.Count - 1].Cells[nCell];
						dgvInputGoods.Select();
					}
				}
			}
			return;
		}

		private void btnArrangeAll_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < oInput.TableInputsGoods.Rows.Count; i++)
			{
				oInput.TableInputsGoods.Rows[i]["QntArranged"] = oInput.TableInputsGoods.Rows[i]["QntWished"];
				oInput.TableInputsGoods.Rows[i]["BoxArranged"] = oInput.TableInputsGoods.Rows[i]["BoxWished"];
			}
			dgvInputGoods.Refresh();
			ShowStrikes();
			return;
		}

		private void btnArrangeNull_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < oInput.TableInputsGoods.Rows.Count; i++)
			{
				oInput.TableInputsGoods.Rows[i]["QntArranged"] = 0;
				oInput.TableInputsGoods.Rows[i]["BoxArranged"] = 0;
			}
			dgvInputGoods.Refresh();
			ShowStrikes();
			return;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (RFMMessage.MessageBoxYesNo("Сохранить приход?") != DialogResult.Yes)
				return;
			bool bSave = false;
			for (int i = 0; i < oInput.TableInputsGoods.Rows.Count; i++)
			{
				if ((decimal)oInput.TableInputsGoods.Rows[i]["QntArranged"] > 0)
				{
					bSave = true;
					break;
				}
			}
			if (!bSave && RFMMessage.MessageBoxYesNo("Не обработано ни одного товара!\nВсе равно сохранить приход?") == DialogResult.No)
				return;
			
			int? nUserID = null;
			if (cboHeavers.SelectedValue != null)
				nUserID = (int)cboHeavers.SelectedValue;
			int? nCellID = null;
			if (cboCells.SelectedValue != null)
				nCellID = (int)cboCells.SelectedValue;

			RFMCursorWait.Set(true);
			oInput.ClearError();
			oInput.InputsBoxesSave(nInputID, nUserID, nCellID);
			RFMCursorWait.Set(true);
			if (oInput.ErrorNumber == 0)
			{
				RFMMessage.MessageBoxInfo("Приход успешно сохранен!");
				DialogResult = DialogResult.Yes;
				this.Dispose();
			}
			return;
		}

		#endregion

		private void ShowStrikes()
		{
			int rowCount = 0;
			decimal boxCount = 0;

			if (oInput.TableInputsGoods != null)
			{
				DataView dv = new DataView(oInput.TableInputsGoods);
				dv.RowFilter = "QntArranged < QntWished";
				rowCount = dv.Count;

				for (int i = 0; i < dv.Count; i++)
				{
					if ((decimal)dv[i].Row["QntArranged"] < (decimal)dv[i].Row["QntWished"])
						boxCount += Math.Round((decimal)dv[i].Row["BoxWished"] - (decimal)dv[i].Row["BoxArranged"], 1);
				}
				lblStrikePositionsData.Text = rowCount.ToString("# ##0");
				lblStrikeBoxesData.Text = boxCount.ToString("# ##0.0");
			}
			return;
		}

	}
}