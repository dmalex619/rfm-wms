using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RFMBaseClasses;
using WMSBizObjects;
using RFMPublic;

namespace WMSSuitable
{
	public partial class frmMovingsEdit : RFMFormChild
	{
		private int nMovingID;
		private Moving oMoving; 
		private Partner oOwner;
		private GoodState oGoodState;
		private GoodState oGoodStateNew;
		private Cell oCellSource;
		protected StoreZone oStoreZoneSource;
		private Cell oCellTarget;
		protected StoreZone oStoreZoneTarget;

		DataTable dtStoreZoneSource;
		DataTable dtStoreZoneTarget;

		public string _SelectedIDList;
		public string _SelectedText;
		private string sSelectedOutputsIDList = "";

		public string _SelectedPackingIDList;
		public string _SelectedPackingAliasText;
		private string sSelectedPackingIDList = "";

		bool _bLoaded = false;
		bool _bInWork = false;

		public frmMovingsEdit(int? _nMovingID)
		{
			oMoving = new Moving();
			oOwner = new Partner();
			oGoodState = new GoodState();
			oGoodStateNew = new GoodState();
			oCellSource = new Cell();
			oStoreZoneSource = new StoreZone();
			oCellTarget = new Cell();
			oStoreZoneTarget = new StoreZone();
			if (oMoving.ErrorNumber != 0 || 
				oOwner.ErrorNumber != 0 || 
				oGoodState.ErrorNumber != 0	||
				oGoodStateNew.ErrorNumber != 0 || 
				oCellSource.ErrorNumber != 0 ||
				oStoreZoneSource.ErrorNumber != 0 ||
				oCellTarget.ErrorNumber != 0 ||
				oStoreZoneTarget.ErrorNumber != 0)  
				IsValid = false;
			if (IsValid)
			{
				InitializeComponent();

				if (_nMovingID.HasValue)
					nMovingID = (int)_nMovingID;
				else
					nMovingID = 0;
			}
		}

		private void frmMovingsEdit_Load(object sender, EventArgs e)
		{
			bool blResult = cboMovingsTypes_Restore() && 
				cboOwners_Restore() && 
				cboGoodState_Restore() &&
				cboGoodStateNew_Restore() &&
				cboStoresZonesSource_Restore() &&
				cboStoresZonesTypesSource_Restore() &&
				cboStoresZonesTarget_Restore() &&
				cboStoresZonesTypesTarget_Restore();
			if (!blResult)
			{
				RFMMessage.MessageBoxError("Ошибка получения данных классификаторов...");
				Dispose();
			}

			cboMovingsTypes.SelectedIndex =
			cboOwners.SelectedIndex =
			cboGoodState.SelectedIndex =
			cboGoodStateNew.SelectedIndex =
			cboStoresZonesSource.SelectedIndex =
			cboStoresZonesTypesSource.SelectedIndex =
			cboCellSourceAddress.SelectedIndex =
			cboStoresZonesTarget.SelectedIndex =
			cboStoresZonesTypesTarget.SelectedIndex =
			cboCellTargetAddress.SelectedIndex =
				-1;

			if (nMovingID != 0)
			{
				oMoving.ID = nMovingID;
				oMoving.FillData();
				if (oMoving.ErrorNumber != 0 || oMoving.MainTable.Rows.Count == 0)
				{
					RFMMessage.MessageBoxError("Ошибка при получении данных о внутрискладском перемещении...");
					Dispose();
				}

				DataRow droRow = oMoving.MainTable.Rows[0];
				// поля
				txtID.Text = droRow["ID"].ToString();
				dtpDateMoving.Value = Convert.ToDateTime(droRow["DateMoving"]).Date;
				cboMovingsTypes.SelectedValue = (int)droRow["MovingTypeID"];
				if (!Convert.IsDBNull(droRow["OwnerID"]))
					cboOwners.SelectedValue = (int)droRow["OwnerID"];
				if (!Convert.IsDBNull(droRow["GoodStateID"]))
					cboGoodState.SelectedValue = (int)droRow["GoodStateID"];
				if (!Convert.IsDBNull(droRow["GoodStateNewID"]))
					cboGoodStateNew.SelectedValue = (int)droRow["GoodStateNewID"];
				txtNote.Text = droRow["Note"].ToString();
				
				// ячейка-источник
				cboStoresZonesTypesSource.SelectedValue = (int)droRow["StoreZoneTypeSourceID"];
				cboStoresZonesSource.SelectedValue = (int)droRow["StoreZoneSourceID"];
				cboCellSourceAddress.SelectedValue = (int)droRow["CellSourceID"];

				// товары (но это не источник грида)
				oMoving.FillTableMovingsGoods((int)nMovingID);
				if (oMoving.ErrorNumber != 0 || oMoving.TableMovingsGoods == null)
				{
					RFMMessage.MessageBoxError("Ошибка при получении данных о товарах в внутрискладском перемещении...");
					Dispose();
				}

				// целевая ячейка
				int? nCellTargetID = null;
				int? nStoreZoneTargetID = null; 
				if (oMoving.TableMovingsGoods.Rows.Count > 0)
				{
					if (!Convert.IsDBNull(oMoving.TableMovingsGoods.Rows[0]["CellTargetID"]))
					{
						nCellTargetID = Convert.ToInt32(oMoving.TableMovingsGoods.Rows[0]["CellTargetID"]);
					}
					if (!Convert.IsDBNull(oMoving.TableMovingsGoods.Rows[0]["StoreZoneTargetID"]))
					{
						nStoreZoneTargetID = Convert.ToInt32(oMoving.TableMovingsGoods.Rows[0]["StoreZoneTargetID"]);
					}
				}

				if ((bool)droRow["ToOneCell"])
				{
					optToOneCell.Checked = true;
					// ячейка, которую мы взяли из списка товаров
					if (nStoreZoneTargetID.HasValue)
					{
						cboStoresZonesTarget.SelectedValue = (int)nStoreZoneTargetID;
					}
					if (nCellTargetID.HasValue)
					{ 
						cboCellTargetAddress.SelectedValue = (int)nCellTargetID; 
					}
				}
				else
				{
					optToPicking.Checked = true;
				}

				cboMovingsTypes.Enabled =
				cboOwners.Enabled =
				cboGoodState.Enabled =
				cboGoodStateNew.Enabled =
				pnlOpgMovingsTypes.Enabled =
				pnlSource.Enabled = 
				pnlTarget.Enabled = 
					false;

				dgvMovingsGoods_Restore();
			}
			else
			{
				txtID.Text = "новое";
				dtpDateMoving.Value = DateTime.Now.Date;
				cboMovingsTypes.SelectedIndex = 0;
				cboMovingsTypes_SelectedIndexChanged(null, null);

				cboOwners.SelectedIndex = -1;
				cboGoodState.SelectedIndex = 0;
				cboGoodStateNew.SelectedIndex = 0;

				cboCellSourceAddress.SelectedIndex =
				cboStoresZonesSource.SelectedIndex =
				cboStoresZonesTypesSource.SelectedIndex =
					-1;
			}

			foreach (DataGridViewColumn c in dgvMovingsGoods.Columns)
			{
				string sColName = c.Name.ToUpper();
				if (!sColName.Contains("WISHED") && !sColName.Contains("MARKED"))
				{
					c.ReadOnly = true;
				}
			}
			dgrcQnt.AgrType =
			dgrcQntWished.AgrType =
			dgrcBox.AgrType =
			dgrcBoxWished.AgrType =
				EnumAgregate.Sum;

			SetInWork();

			_bLoaded = true;
		}

		#region Restore

		private bool dgvMovingsGoods_Restore()
		{
			if (cboGoodState.SelectedValue == null || cboGoodState.SelectedIndex < 0)
			{
				RFMMessage.MessageBoxError("Не выбрано текущее состояние товара...");
				return false;
			}
			if (cboCellSourceAddress.SelectedValue == null || cboCellSourceAddress.SelectedIndex < 0)
			{
				RFMMessage.MessageBoxError("Не выбрана ячейка-источник...");
				return false;
			}
			if (optToOneCell.Checked && 
				(cboCellTargetAddress.SelectedValue == null || cboCellTargetAddress.SelectedIndex < 0))
			{
				RFMMessage.MessageBoxError("Не выбрана целевая ячейка...");
				return false;
			}

			int nCellSourceID = (int)cboCellSourceAddress.SelectedValue;
			int nGoodStateID = (int)cboGoodState.SelectedValue;
			int nGoodStateNewID = (int)cboGoodStateNew.SelectedValue;
			int? nOwnerID = null;
			if (cboOwners.SelectedIndex >= 0)
			{
				nOwnerID = (int)cboOwners.SelectedValue;
			}
			int? nCellTargetID = null;
			if (cboCellTargetAddress.SelectedIndex >= 0)
			{
				nCellTargetID = (int)cboCellTargetAddress.SelectedValue;
			}

			string sOutputsIDList = null;
			if (chkNotInOutputs.Checked)
			{
				sOutputsIDList = "-1";
			}
			else
			{
				if (sSelectedOutputsIDList.Length > 0)
				{
					sOutputsIDList = sSelectedOutputsIDList;
				}
			}
			oMoving.FillTableMovingsGoodsInCell(nCellSourceID, nGoodStateID, nGoodStateNewID, nOwnerID, nCellTargetID, 
				((sSelectedPackingIDList.Length > 0) ? sSelectedPackingIDList : null),
				sOutputsIDList, 
				nMovingID);

			dgvMovingsGoods.Restore(oMoving.TableMovingsGoods);

			// закрыть начальные условия
			if (dgvMovingsGoods.Rows.Count > 0)
			{
				cboMovingsTypes.Enabled =
				cboOwners.Enabled =
				cboGoodState.Enabled =
				cboGoodStateNew.Enabled =
				pnlSource.Enabled =
				pnlTarget.Enabled =
					false;
			}
			else
			{
				cboMovingsTypes.Enabled =
				cboOwners.Enabled =
				cboGoodState.Enabled =
				cboGoodStateNew.Enabled =
				pnlSource.Enabled = 
				cboStoresZonesSource.Enabled =
				//cboCellSourceAddress.Enabled =
					true;
				if (optToOneCell.Checked) 
				{
					pnlTarget.Enabled =  
					cboStoresZonesTarget.Enabled =
					//cboCellTargetAddress.Enabled =
						true;
				}
			}
			return (oMoving.ErrorNumber == 0);
		}

		private bool cboMovingsTypes_Restore()
		{
			oMoving.FillTableMovingsTypes();
			if (oMoving.ErrorNumber == 0)
			{
				cboMovingsTypes.ValueMember = oMoving.TableMovingsTypes.Columns[0].ColumnName;
				cboMovingsTypes.DisplayMember = oMoving.TableMovingsTypes.Columns[1].ColumnName;
				cboMovingsTypes.DataSource = new DataView(oMoving.TableMovingsTypes);

				if (oMoving.TableMovingsTypes.Rows.Count == 0)
				{ 
					RFMMessage.MessageBoxError("Не определены типы внутрискладских перемещений...");
					return (false); 
				}
			}
			return (oMoving.ErrorNumber == 0);
		}

		private bool cboOwners_Restore()
		{
			oOwner.FillDataOwners();
			if (oOwner.ErrorNumber == 0)
			{
				cboOwners.ValueMember = oOwner.ColumnID;
				cboOwners.DisplayMember = oOwner.ColumnName;
				cboOwners.DataSource = oOwner.MainTable;
			}
			return (oOwner.ErrorNumber == 0);
		}

		private bool cboGoodState_Restore()
		{
			oGoodState.FillData();
			if (oMoving.ErrorNumber == 0)
			{
				cboGoodState.ValueMember = oGoodState.ColumnID;
				cboGoodState.DisplayMember = oGoodState.ColumnName;
				cboGoodState.DataSource = oGoodState.MainTable;
			}
			return (oGoodState.ErrorNumber == 0);
		}

		private bool cboGoodStateNew_Restore()
		{
			oGoodStateNew.FillData();
			if (oMoving.ErrorNumber == 0)
			{
				cboGoodStateNew.ValueMember = oGoodStateNew.ColumnID;
				cboGoodStateNew.DisplayMember = oGoodStateNew.ColumnName;
				cboGoodStateNew.DataSource = oGoodStateNew.MainTable;
			}
			return (oGoodStateNew.ErrorNumber == 0);
		}

		// Source

		private bool cboStoresZonesSource_Restore()
		{
			oStoreZoneSource.FilterStoreZoneTypeForFrames = false;
			oStoreZoneSource.FillData();
			dtStoreZoneSource = CopyTable(oStoreZoneSource.MainTable, "dtStoreZoneSource", "Special = false", "");
			cboStoresZonesSource.ValueMember = dtStoreZoneSource.Columns[0].Caption;
			cboStoresZonesSource.DisplayMember = dtStoreZoneSource.Columns[1].Caption;
			cboStoresZonesSource.DataSource = dtStoreZoneSource;
			return (oStoreZoneSource.ErrorNumber == 0);
		}

		private bool cboStoresZonesTypesSource_Restore()
		{
			oStoreZoneSource.FillTableStoresZonesTypes();
			cboStoresZonesTypesSource.ValueMember = oStoreZoneSource.TableStoresZonesTypes.Columns[0].Caption;
			cboStoresZonesTypesSource.DisplayMember = oStoreZoneSource.TableStoresZonesTypes.Columns[1].Caption;
			cboStoresZonesTypesSource.DataSource = oStoreZoneSource.TableStoresZonesTypes;
			return (oStoreZoneSource.ErrorNumber == 0);
		}

		private bool cboCellSourceAddress_Restore()
		{
			/*
			cboCellSourceAddress.ValueMember = oCellSource.MainTable.Columns[0].Caption;
			cboCellSourceAddress.DisplayMember = oCellSource.MainTable.Columns["Address"].Caption;
			cboCellSourceAddress.DataSource = oCellSource.MainTable;
			return (oCellSource.ErrorNumber == 0);
			*/
	
			oCellSource.ClearError();
			oCellSource.ClearFilters();

			if (cboStoresZonesSource.SelectedIndex < 0)
			{
				cboCellSourceAddress.Enabled = false;
				cboCellSourceAddress.DataSource = null;
				return (false);
			}
			oCellSource.ID = null;
			oCellSource.FilterActual = true;
			oCellSource.FilterLocked = false;
			oCellSource.FilterStoresZonesList = cboStoresZonesSource.SelectedValue.ToString();
			oCellSource.FilterForFrames = false;
			oCellSource.FillData();
			if (oCellSource.MainTable.Rows.Count == 0)
			{
				cboCellSourceAddress.Enabled = false;
				cboCellSourceAddress.DataSource = null;
				if (_bLoaded)
				{
					RFMMessage.MessageBoxError("Нет подходящих ячеек в выбранной конечной зоне...");
				}
			}
			else
			{
				cboCellSourceAddress.Enabled = true;
				cboCellSourceAddress.ValueMember = oCellSource.MainTable.Columns[0].Caption;
				cboCellSourceAddress.DisplayMember = oCellSource.MainTable.Columns["Address"].Caption;
				cboCellSourceAddress.DataSource = oCellSource.MainTable;
			}
			return (oCellSource.ErrorNumber == 0);
		}

		// Target

		private bool cboStoresZonesTarget_Restore()
		{
			oStoreZoneTarget.FilterStoreZoneTypeForFrames = false;
			oStoreZoneTarget.FillData();
			dtStoreZoneTarget = CopyTable(oStoreZoneTarget.MainTable, "dtStoreZoneTarget", "Special = false", "");
			cboStoresZonesTarget.ValueMember = dtStoreZoneTarget.Columns[0].Caption;
			cboStoresZonesTarget.DisplayMember = dtStoreZoneTarget.Columns[1].Caption;
			cboStoresZonesTarget.DataSource = dtStoreZoneTarget;
			return (oStoreZoneTarget.ErrorNumber == 0);
		}

		private bool cboStoresZonesTypesTarget_Restore()
		{
			oStoreZoneTarget.FillTableStoresZonesTypes();
			cboStoresZonesTypesTarget.ValueMember = oStoreZoneTarget.TableStoresZonesTypes.Columns[0].Caption;
			cboStoresZonesTypesTarget.DisplayMember = oStoreZoneTarget.TableStoresZonesTypes.Columns[1].Caption;
			cboStoresZonesTypesTarget.DataSource = oStoreZoneTarget.TableStoresZonesTypes;
			return (oStoreZoneTarget.ErrorNumber == 0);
		}

		private bool cboCellTargetAddress_Restore()
		{
			oCellTarget.ClearError();
			oCellTarget.ClearFilters();

			if (cboStoresZonesTarget.SelectedIndex < 0)
			{
				cboCellTargetAddress.Enabled = false;
				cboCellTargetAddress.DataSource = null;
				return (false);
			}
			oCellTarget.ID = null;
			oCellTarget.FilterActual = true;
			oCellTarget.FilterLocked = false;
			oCellTarget.FilterStoresZonesList = cboStoresZonesTarget.SelectedValue.ToString();
			oCellTarget.FilterForFrames = false;
			oCellTarget.FillData();
			if (oCellTarget.MainTable.Rows.Count == 0)
			{
				cboCellTargetAddress.Enabled = false;
				cboCellTargetAddress.DataSource = null;
				if (_bLoaded)
				{
					RFMMessage.MessageBoxError("Нет подходящих ячеек в выбранной конечной зоне...");
				}
			}
			else
			{
				cboCellTargetAddress.Enabled = true;
				cboCellTargetAddress.ValueMember = oCellTarget.MainTable.Columns[0].Caption;
				cboCellTargetAddress.DisplayMember = oCellTarget.MainTable.Columns["Address"].Caption;
				cboCellTargetAddress.DataSource = oCellTarget.MainTable;
			}
			return (oCellTarget.ErrorNumber == 0);
		}

		#endregion

		#region Выбор типа перемещения, ячейки

		private void cboMovingsTypes_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboMovingsTypes.SelectedValue == null || cboMovingsTypes.SelectedIndex < 0)
			{
				pnlOpgMovingsTypes.Enabled = false;
				optToPicking.Checked = true;
				optToOneCell_CheckedChanged(null, null);
				return;
			}

			int nMovingTypeID = (int)cboMovingsTypes.SelectedValue;
			foreach (DataRow mtr in oMoving.TableMovingsTypes.Rows)
			{
				if (Convert.ToInt32(mtr["ID"]) == nMovingTypeID)
				{
					if (!Convert.IsDBNull(mtr["ToOneCell"]))
					{
						if (Convert.ToBoolean(mtr["ToOneCell"]))
						{
							optToOneCell.Checked = true;
						}
						else
						{
							optToPicking.Checked = true;
						}
					}
					break;
				}
			}
		}

		private void optToOneCell_CheckedChanged(object sender, EventArgs e)
		{
			if (optToOneCell.Checked)
			{
				cboStoresZonesTarget.Enabled = true;
				cboStoresZonesTarget.SelectedIndex = -1;
				cboStoresZonesTarget_SelectedIndexChanged(null, null);
			}
			else
			{
				cboStoresZonesTarget.Enabled =
				cboCellTargetAddress.Enabled =
					false;
				cboStoresZonesTypesTarget.SelectedIndex =
				cboStoresZonesTarget.SelectedIndex =
				cboCellTargetAddress.SelectedIndex =
					-1;
			}
		}

		private void cboStoresZonesSource_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboStoresZonesSource.SelectedIndex < 0)
			{
				cboCellSourceAddress.SelectedIndex =
				cboStoresZonesTypesSource.SelectedIndex =
					-1;
				cboCellSourceAddress.Enabled = false;
				return;
			}

			DataRow zt = oStoreZoneSource.MainTable.Rows.Find(cboStoresZonesSource.SelectedValue);
			if (zt != null)
			{
				cboStoresZonesTypesSource.SelectedValue = (int)zt["StoreZoneTypeID"];
				// перевывести список ячеек этой зоны
				cboCellSourceAddress_Restore();
				if (cboCellSourceAddress.Items.Count > 1)
				{
					cboCellSourceAddress.SelectedIndex = -1;
				}
				else
				{
					if (cboCellSourceAddress.Items.Count > 0)
					{
						cboCellSourceAddress.SelectedIndex = 0;
					}
				}
			}
		}

		private void cboStoresZonesTarget_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboStoresZonesTarget.SelectedIndex < 0)
			{
				cboCellTargetAddress.SelectedIndex =
				cboStoresZonesTypesTarget.SelectedIndex = 
					-1;
				cboCellTargetAddress.Enabled = false;
				return;
			}

			DataRow zt = oStoreZoneTarget.MainTable.Rows.Find(cboStoresZonesTarget.SelectedValue);
			if (zt != null)
			{
				cboStoresZonesTypesTarget.SelectedValue = (int)zt["StoreZoneTypeID"];
				// перевывести список ячеек этой зоны
				cboCellTargetAddress_Restore();
				if (cboCellTargetAddress.Items.Count > 1)
				{
					cboCellTargetAddress.SelectedIndex = -1;
				}
				else
				{
					if (cboCellTargetAddress.Items.Count > 0)
					{
						cboCellTargetAddress.SelectedIndex = 0;
					}
				}
			}
		}

		#endregion

		#region Cells

		private void dgvMovingsGoods_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (dgvMovingsGoods.DataSource == null || dgvMovingsGoods.CurrentRow == null)
				return;

			DataRow droRow = ((DataRowView)dgvMovingsGoods.Rows[e.RowIndex].DataBoundItem).Row;
			if (droRow == null)
				return;

			if (droRow["Qnt"] == DBNull.Value) 
				droRow["Qnt"] = 0;
			if (droRow["QntWished"] == DBNull.Value) 
				droRow["QntWished"] = 0;

			if ((decimal)droRow["Qnt"] != (decimal)droRow["QntWished"])
			{
				if (dgvMovingsGoods.Columns[e.ColumnIndex].Name == "dgrcQntWished" ||
					dgvMovingsGoods.Columns[e.ColumnIndex].Name == "dgrcBoxWished")
				{
					if ((decimal)droRow["QntWished"] != 0)
						e.CellStyle.BackColor = Color.FromArgb(255, 255, 128);
				}
			}

			switch (dgvMovingsGoods.Columns[e.ColumnIndex].Name)
			{
				case "dgrcInBox":
				case "dgrcQntWished":
				case "dgrcQnt":
					if (!Convert.IsDBNull(droRow["Weighting"]) &&
						Convert.ToBoolean(droRow["Weighting"]) ||
						!Convert.IsDBNull(e.Value) && Convert.ToDecimal(e.Value) != Convert.ToInt32(e.Value))
						e.CellStyle.Format = "### ### ### ##0.000";
					else
						e.CellStyle.Format = "### ### ### ###";
					break;
			}
		}

		private void dgvMovingsGoods_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
			if (dgvMovingsGoods.Columns[e.ColumnIndex].Name.Contains("Qnt"))
			{
				DataRow dr = ((DataRowView)((DataGridViewRow)dgvMovingsGoods.CurrentRow).DataBoundItem).Row;
				decimal nInBox = (decimal)dr["InBox"];
				((RFMDataGridViewTextBoxNumericColumn)dgvMovingsGoods.Columns[e.ColumnIndex]).DecimalPlaces =
					(nInBox != (int)nInBox || (bool)dr["Weighting"]) ? 3 : 0;
			}
		}

		private void dgvMovingsGoods_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if (oMoving.TableMovingsGoods.Rows.Count == 0)
				return;

			if (dgvMovingsGoods.Columns[e.ColumnIndex].Name == "dgrcQntWished" ||
				dgvMovingsGoods.Columns[e.ColumnIndex].Name == "dgrcBoxWished")
			{
				DataRow droRow = ((DataRowView)dgvMovingsGoods.CurrentRow.DataBoundItem).Row;
				if (droRow == null)
					return;

				decimal nInBox = (decimal)droRow["InBox"];
				if (dgvMovingsGoods.Columns[e.ColumnIndex].Name == "dgrcQntWished")
				{
					// меняем штуки
					droRow["BoxWished"] = (decimal)dgvMovingsGoods.Rows[e.RowIndex].Cells["dgrcQntWished"].Value / nInBox;
				}
				if (dgvMovingsGoods.Columns[e.ColumnIndex].Name == "dgrcBoxWished")
				{
					// меняем коробки
					if ((bool)dgvMovingsGoods.Rows[e.RowIndex].Cells["dgrcWeighting"].Value ||
						(int)nInBox != nInBox)
					{
						droRow["QntWished"] = (decimal)dgvMovingsGoods.Rows[e.RowIndex].Cells["dgrcBoxWished"].Value * nInBox;
					}
					else
					{
						droRow["QntWished"] = decimal.Ceiling(decimal.Round((decimal)dgvMovingsGoods.Rows[e.RowIndex].Cells["dgrcBoxWished"].Value * nInBox, 1));
					}
				}
				dgvMovingsGoods.Refresh();
			}
		}

		private void dgvMovingsGoods_CellValidated(object sender, DataGridViewCellEventArgs e)
		{
			DataGridViewRow r = dgvMovingsGoods.Rows[e.RowIndex];
			if (dgvMovingsGoods.Columns[e.ColumnIndex].Name == "dgrcQntWished" &&
					!(bool)r.Cells["dgrcWeighting"].Value &&
					(r.Cells["dgrcQntWished"].Value == DBNull.Value ||
					((decimal)r.Cells["dgrcQntWished"].Value > (decimal)r.Cells["dgrcQnt"].Value)))
			{
				if (r.Cells["dgrcQntWished"].Value == DBNull.Value)
				{
					r.Cells["dgrcQntWished"].Value = 0;
				}
				else
				{
					if (RFMMessage.MessageBoxYesNo("Введено число большее, чем количество товара в ячейке!\nВсе-таки сохранить?") != DialogResult.Yes)
						r.Cells["dgrcQntWished"].Value = r.Cells["dgrcQnt"].Value;
				}

				if (Convert.ToDecimal(r.Cells["dgrcQntWished"].Value) != 0)
					_bInWork = true;
				else
					SetInWork();
			}

			if (dgvMovingsGoods.Columns[e.ColumnIndex].Name == "dgrcBoxWished" &&
					!(bool)r.Cells["dgrcWeighting"].Value &&
					(r.Cells["dgrcBoxWished"].Value == DBNull.Value ||
					((decimal)r.Cells["dgrcBoxWished"].Value > (decimal)r.Cells["dgrcBox"].Value)))
			{
				if (r.Cells["dgrcBoxWished"].Value == DBNull.Value)
				{
					r.Cells["dgrcBoxWished"].Value = 0;
				}
				else
				{
					if (RFMMessage.MessageBoxYesNo("Введено число большее, чем количество товара в ячейке!\nВсе-таки сохранить?") != DialogResult.Yes)
						r.Cells["dgrcBoxWished"].Value = r.Cells["dgrcBox"].Value;
				}

				if (Convert.ToDecimal(r.Cells["dgrcBoxWished"].Value) != 0)
					_bInWork = true;
				else
					SetInWork();
			}
			dgvMovingsGoods.Refresh();
		}

		#endregion Cells

		#region Buttons 

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
			if (cboMovingsTypes.SelectedValue == null || cboMovingsTypes.SelectedIndex < 0)
			{
				RFMMessage.MessageBoxError("Не выбран тип внутрискладского перемещения...");
				return;
			}
			int nMovingTypeID = (int)cboMovingsTypes.SelectedValue;

			if (cboGoodState.SelectedValue == null || cboGoodState.SelectedIndex < 0)
			{
				RFMMessage.MessageBoxError("Не выбрано состояние товара...");
				return;
			}
			if (cboGoodStateNew.SelectedValue == null || cboGoodStateNew.SelectedIndex < 0)
			{
				RFMMessage.MessageBoxError("Не выбрано новое состояние товара...");
				return;
			}
			if (cboCellSourceAddress.SelectedValue == null || cboCellSourceAddress.SelectedIndex < 0)
			{
				RFMMessage.MessageBoxError("Не выбрана ячейка-источник...");
				return;
			}

			if (Convert.ToInt32(cboGoodStateNew.SelectedValue) != Convert.ToInt32(cboGoodState.SelectedValue))
			{
				if (RFMMessage.MessageBoxYesNo("Новое состояние товара не совпадает с текущим...\nВсе-таки сохранить перемещение?") != DialogResult.Yes)
				{
					return;
				}
			}

            int nGoodStateID = (int)cboGoodState.SelectedValue;
            int nGoodStateNewID = (int)cboGoodStateNew.SelectedValue;

			int? nOwnerID = null;
			if (cboOwners.SelectedIndex >= 0)
			{
				nOwnerID = (int)cboOwners.SelectedValue;
			}

			if (cboCellSourceAddress.SelectedValue == null || cboCellSourceAddress.SelectedIndex < 0)
			{
				RFMMessage.MessageBoxError("Не выбрана ячейка-источник...");
				return;
			}
			int nCellSourceID = (int)cboCellSourceAddress.SelectedValue;

			int? nCellTargetID = null;
			if (optToOneCell.Checked)
			{
				if (cboCellTargetAddress.SelectedValue == null || cboCellTargetAddress.SelectedIndex < 0)
				{
					RFMMessage.MessageBoxError("Не выбрана целевая ячейка...");
					return;
				}
				nCellTargetID = (int)cboCellTargetAddress.SelectedValue;

				if (nCellSourceID == nCellTargetID)
				{
					RFMMessage.MessageBoxError("Целевая ячейка совпадает с ячейкой-источником...");
					return;
				}

				// проверка по привязкам
				int? nFixedPackingID = null;
				int? nFixedGoodStateID = null;
				int? nFixedOwnerID = null;
				Cell oOneCell = new Cell();
				oOneCell.ID = nCellTargetID;
				oOneCell.FillData();
				if (oOneCell.ErrorNumber != 0 || oOneCell.MainTable == null || oOneCell.MainTable.Rows.Count != 1)
				{
					RFMMessage.MessageBoxError("Ошибка при проверке фиксированных закреплений целевой ячейки...");
					return;
				}
				DataRow ocr = oOneCell.MainTable.Rows[0];
				if (!Convert.IsDBNull(ocr["FixedPackingID"]))
				{
					nFixedPackingID = Convert.ToInt32(ocr["FixedPackingID"]);
				}
				if (!Convert.IsDBNull(ocr["FixedGoodStateID"]))
				{
					nFixedGoodStateID = Convert.ToInt32(ocr["FixedGoodStateID"]);
				}
				if (!Convert.IsDBNull(ocr["FixedOwnerID"]))
				{
					nFixedOwnerID = Convert.ToInt32(ocr["FixedOwnerID"]);
				}

				if (nFixedPackingID.HasValue || nFixedGoodStateID.HasValue || nFixedOwnerID.HasValue)
				{
					foreach (DataRow dro in oMoving.TableMovingsGoods.Rows)
					{
						if (Convert.ToDecimal(dro["QntWished"]) > 0)
						{
							if (nFixedPackingID.HasValue && Convert.ToInt32(dro["PackingID"]) != (int)nFixedPackingID || 
								nFixedGoodStateID.HasValue && nGoodStateID != (int)nFixedGoodStateID ||
								nFixedOwnerID.HasValue && nOwnerID.HasValue && (int)nOwnerID != (int)nFixedOwnerID)
							{
								RFMMessage.MessageBoxError("Товар " + dro["GoodAlias"] + " не может быть перемещен в выбранную ячейку\n" + 
									"из-за несоответствия фиксированных закреплений (товар/состояние/владелец)...");
								return;
							}
						}
					}
				}
			}

			SetInWork();
			if (!_bInWork)
			{
				RFMMessage.MessageBoxError("Не выбрано ни одного товара...");
				return;
			}

			int j = 0;
            StringBuilder sbNoCell = new StringBuilder("");
            StringBuilder sbCellLess = new StringBuilder("");
			foreach (DataRow dro in oMoving.TableMovingsGoods.Rows)
			{
				if (Convert.ToDecimal(dro["QntWished"]) > 0)
				{
					j++;

                    if (Convert.IsDBNull(dro["CellTargetID"]) || dro["CellTargetID"] == null || Convert.ToInt32(dro["CellTargetID"]) == 0)
                    {
                        sbNoCell = sbNoCell.Append(dro["GoodAlias"].ToString() + "\r\n");
                    }
					if (Convert.ToDecimal(dro["QntWished"]) > Convert.ToDecimal(dro["Qnt"]))
					{
						sbCellLess = sbCellLess.Append(dro["GoodAlias"].ToString() + "\r\n");
					}
				}
			}
            if (sbNoCell.Length > 0)
            {
                RFMMessage.MessageBoxError("Для следующих товаров:\n" + sbNoCell + "не определена конечная ячейка.\n\n" +
                    "Перемещение невозможно.");
                return;
            }
            if (sbCellLess.Length > 0)
			{
				if (RFMMessage.MessageBoxYesNo("Для следующих товаров:\n" + sbCellLess + "количество в исходной ячейке меньше, чем запрашиваемое количество.\n\n" +
					"Все-таки сохранить внутрискладское перемещение?") != DialogResult.Yes)
					return;
			}

			if (nMovingID == 0)
			{
				oMoving.ClearError();
				oMoving.ID = 0;
				oMoving.FillData();
				if (oMoving.ErrorNumber != 0 || oMoving.MainTable == null)
				{
					RFMMessage.MessageBoxError("Ошибка при попытке сохранения нового внутрискладского перемещения...");
					return;
				}
				oMoving.MainTable.Rows.Add();
			}

			oMoving.MainTable.Rows[0]["DateMoving"] = dtpDateMoving.Value.Date;
			oMoving.MainTable.Rows[0]["MovingTypeID"] = nMovingTypeID;
			oMoving.MainTable.Rows[0]["GoodStateID"] = nGoodStateID;
            oMoving.MainTable.Rows[0]["GoodStateNewID"] = nGoodStateNewID;
            if (nOwnerID.HasValue)
				oMoving.MainTable.Rows[0]["OwnerID"] = nOwnerID;
			else 
				oMoving.MainTable.Rows[0]["OwnerID"] = DBNull.Value;
			oMoving.MainTable.Rows[0]["CellSourceID"] = nCellSourceID;
			oMoving.MainTable.Rows[0]["Note"] = txtNote.Text.Trim(); 

			Refresh();
			WaitOn(this);
			oMoving.ClearError();
			bool bResult = oMoving.SaveData(nMovingID, nCellTargetID, 
					((RFMFormBase)Application.OpenForms[0]).UserInfo.UserID);
			WaitOff(this);
			if (bResult && oMoving.ErrorNumber == 0)
			{
				MotherForm.GotParam = new object[] { ((oMoving.ID.HasValue) ? (int)oMoving.ID : 0) };

				DialogResult = DialogResult.Yes;
				Dispose();
			}
			else
			{
				RFMMessage.MessageBoxError("Ошибка сохранения внутрискладского перемещения...");
				// не выходить из формы
			}
		}

		#region AddButtons

		private void btnGoodsFill_Click(object sender, EventArgs e)
		{
			SetInWork();
			if (dgvMovingsGoods.Rows.Count > 0 && _bInWork)
			{
				if (RFMMessage.MessageBoxYesNo("Все выбранные товары будут потеряны!\nВсе-таки обновить список товаров в ячейке?") != DialogResult.Yes)
					return;
			}
			dgvMovingsGoods_Restore();
		}

		private void btnGoodsClear_Click(object sender, EventArgs e)
		{
			dgvMovingsGoods.DataSource = null;
			oMoving.ClearTableMovingsGoods();
			_bInWork= false;
		}

		private void btnMovingAll_Click(object sender, EventArgs e)
		{
			if (oMoving.TableMovingsGoods == null || oMoving.TableMovingsGoods.Rows.Count == 0)
				return; 

			foreach (DataRow r in oMoving.TableMovingsGoods.Rows)
			{
				if (Convert.ToDecimal(r["Qnt"]) > 0)
				{
					r["QntWished"] = r["Qnt"];
					r["BoxWished"] = r["Box"];
					_bInWork = true;
				}
			}
		}

		private void btnMovingNull_Click(object sender, EventArgs e)
		{
			if (oMoving.TableMovingsGoods == null || oMoving.TableMovingsGoods.Rows.Count == 0)
				return;
			
			foreach (DataRow r in oMoving.TableMovingsGoods.Rows)
			{
				r["QntWished"] =
				r["BoxWished"] =
					0;
			}
			_bInWork = false;
		}

		#endregion Add Buttons

		#endregion Buttons

		private void SetInWork()
		{
			_bInWork = false;

			if (oMoving.TableMovingsGoods == null)
				return;

			foreach (DataRow r in oMoving.TableMovingsGoods.Rows)
			{
				if (Convert.ToDecimal(r["QntWished"]) != 0)
				{
					_bInWork = true;
				}
			}
		}

		#region Packings Choose

		private void btnPackingsChoose_Click(object sender, EventArgs e)
		{
			_SelectedPackingIDList = null;
			_SelectedPackingAliasText = "";

			if (StartForm(new frmSelectOnePacking(this, true)) == DialogResult.Yes)
			{
				if (_SelectedPackingIDList == null || !_SelectedPackingIDList.Contains(","))
				{
					btnPackingsClear_Click(null, null);
					return;
				}

				sSelectedPackingIDList = "," + _SelectedPackingIDList;
				txtPackingsChoosen.Text = _SelectedPackingAliasText;
				ttToolTip.SetToolTip(txtPackingsChoosen, txtPackingsChoosen.Text);
			}

			_SelectedPackingIDList = null;
			_SelectedPackingAliasText = "";
		}

		private void btnPackingsClear_Click(object sender, EventArgs e)
		{
			ttToolTip.SetToolTip(txtPackingsChoosen, "не выбраны");
			sSelectedPackingIDList = "";
			txtPackingsChoosen.Text = "";
		}

		#endregion Packings Choose

		#region Outputs Choose 

		private void btnOutputsChoose_Click(object sender, EventArgs e)
		{
			_SelectedIDList = null;
			_SelectedText = "";

			Output oOutput = new Output();
			WaitOn(this);
			// фильтры
			//oOutput.FilterConfirmed = false;
			oOutput.FilterDateBeg = DateTime.Now.Date.AddDays(-2);
			oOutput.FillData();
			WaitOff(this);
			if (oOutput.ErrorNumber != 0 || oOutput.MainTable == null)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных...");
				return;
			}
			if (oOutput.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Нет данных...");
				return;
			}

			if (StartForm(new frmSelectID(this, oOutput.MainTable,
				"DateOutput, ERPCode, DateConfirm, OutputTypeName, PartnerName, CarAlias, BackDoor, Note, CellAddress, OutputID",
				"Дата, ERPCode, Подтв., Тип, Клиент, Машина, ЗД, Примечание, Ячейка отгр., ID", true)) == DialogResult.Yes)
			{
				if (_SelectedIDList == null || !_SelectedIDList.Contains(","))
				{
					btnOutputsClear_Click(null, null);
					return;
				}

				sSelectedOutputsIDList = "," + _SelectedIDList;

				_SelectedText = "";
				oOutput.IDList = sSelectedOutputsIDList;
				oOutput.FillData();

				// список ERP-кодов показать
				int nFirstCntRecords = 3;
				int i = 0;
				foreach (DataRow r in oOutput.MainTable.Rows)
				{
					if (i < nFirstCntRecords)
					{
						_SelectedText += r["ERPCode"].ToString() + ", "; 
					}
					else
					{
						if (i == nFirstCntRecords)
						{
							_SelectedText += "...";
						}
					}
					i++;
				}
				_SelectedText = _SelectedText.Trim();
				if (_SelectedText.Substring(_SelectedText.Length - 1, 1) == ",")
				{
					_SelectedText = _SelectedText.Substring(0, _SelectedText.Length - 1);
				}
				if (_SelectedText.Length > 0)
				{
					_SelectedText = "(" + RFMUtilities.Occurs(_SelectedIDList, ",").ToString() + "): " +
						_SelectedText.Trim();
				}

				txtOutputsChoosen.Text = _SelectedText;
				ttToolTip.SetToolTip(txtOutputsChoosen, txtOutputsChoosen.Text);
			}

			_SelectedIDList = null;
			_SelectedText = "";
		}

		private void btnOutputsClear_Click(object sender, EventArgs e)
		{
			ttToolTip.SetToolTip(txtOutputsChoosen, "не выбраны");
			sSelectedOutputsIDList = "";
			txtOutputsChoosen.Text = "";
		}

		private void btnOutputsErpCodes_Click(object sender, EventArgs e)
		{
			_SelectedIDList = null;
			_SelectedText = "";

			if (StartForm(new frmInputBoxString("Список ERP-кодов расходов (через запятую):", "")) == DialogResult.Yes)
			{
				string sErpCodesList = GotParam[0].ToString();

				Output oOutputTemp = new Output();
				oOutputTemp.IDList = oOutputTemp.FillIDListByErpCodeList(sErpCodesList);
				oOutputTemp.FillData();
				if (oOutputTemp.MainTable.Rows.Count == 0)
				{
					RFMMessage.MessageBoxInfo("Нет расходов...");
					ttToolTip.SetToolTip(txtOutputsChoosen, "не выбраны");
					sSelectedOutputsIDList = "";
					txtOutputsChoosen.Text = "";
					return;
				}

				sSelectedOutputsIDList = oOutputTemp.IDList;

				// список ERP-кодов показать
				int nFirstCntRecords = 3;
				int i = 0;
				foreach (DataRow r in oOutputTemp.MainTable.Rows)
				{
					if (i < nFirstCntRecords)
					{
						_SelectedText += r["ERPCode"].ToString() + ", ";
					}
					else
					{
						if (i == nFirstCntRecords)
						{
							_SelectedText += "...";
						}
					}
					i++;
				}
				_SelectedText = _SelectedText.Trim();
				if (_SelectedText.Substring(_SelectedText.Length - 1, 1) == ",")
				{
					_SelectedText = _SelectedText.Substring(0, _SelectedText.Length - 1);
				}
				if (_SelectedText.Length > 0)
				{
					_SelectedText = "(" + oOutputTemp.MainTable.Rows.Count.ToString() + "): " +
						_SelectedText.Trim();
				}

				txtOutputsChoosen.Text = _SelectedText;
				ttToolTip.SetToolTip(txtOutputsChoosen, txtOutputsChoosen.Text);
			}
			else
			{
				ttToolTip.SetToolTip(txtOutputsChoosen, "не выбраны");
				sSelectedOutputsIDList = "";
				txtOutputsChoosen.Text = "";
			}

		}

		#endregion Outputs Choose

		private void btnGridClear_Click(object sender, EventArgs e)
		{
			if (dgvMovingsGoods.Rows.Count > 0)
			{
				foreach (DataGridViewRow r in dgvMovingsGoods.Rows)
				{
					if (Convert.ToDecimal(r.Cells["dgrcQntWished"].Value) != 0)
					{
						if (RFMMessage.MessageBoxYesNo("Внимание!\n\nТаблица будет очищена, введенные данные будут утеряны!\n\nПродолжить?") != DialogResult.Yes)
							return;
						else
							break;
					}
				}
			}
			dgvMovingsGoods.DataSource = null;
			oMoving.ClearTableMovingsGoods();
			_bInWork = false;

			cboMovingsTypes.Enabled =
			cboOwners.Enabled =
			cboGoodState.Enabled =
			cboGoodStateNew.Enabled =
			pnlSource.Enabled =  
			cboStoresZonesSource.Enabled =
			//cboCellSourceAddress.Enabled =
				true;
			if (optToOneCell.Checked)
			{
				pnlTarget.Enabled = 
				cboStoresZonesTarget.Enabled =
				//cboCellTargetAddress.Enabled =
					true;
			}
		}

		private void chkNotInOutputs_CheckedChanged(object sender, EventArgs e)
		{
			if (chkNotInOutputs.Checked)
			{
				pnlOutputs.Enabled = 
				btnOutputsErpCodes.Enabled = 
					false;
				btnOutputsClear_Click(null, null);
			}
			else
			{
				pnlOutputs.Enabled =
				btnOutputsErpCodes.Enabled = 
					true;
			}
		}
	}
}
