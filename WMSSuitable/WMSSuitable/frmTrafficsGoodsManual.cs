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
	public partial class frmTrafficsGoodsManual : RFMFormChild
	{
		protected TrafficGood oTraffic;
		protected TrafficGood oTrafficOld;

		protected Cell oCellSource;
		protected StoreZone oStoreZoneSource;

		protected Cell oCellTarget;
		protected StoreZone oStoreZoneTarget;
		
		protected bool _bLoaded = false;

		protected decimal _nInBox;
		protected decimal _nQntExists = 0;
		protected int? _nOwnerID;
		protected int? _nGoodStateID;
		protected bool bWeighting = false;  

		public frmTrafficsGoodsManual(int? nTrafficOldID)
		{
			oTraffic = new TrafficGood();
			oTrafficOld = new TrafficGood();
			oCellSource = new Cell();
			oStoreZoneSource = new StoreZone();
			oCellTarget = new Cell();
			oStoreZoneTarget = new StoreZone();

			if (oTraffic.ErrorNumber != 0 ||
				oCellSource.ErrorNumber != 0 ||
				oStoreZoneSource.ErrorNumber != 0 ||
				oCellTarget.ErrorNumber != 0 ||
				oStoreZoneTarget.ErrorNumber != 0)
			{ 
				IsValid = false;
			}

			if (IsValid)
			{
				InitializeComponent();
				oTrafficOld.ID = nTrafficOldID;
			}
		}
		
		private void frmTrafficManual_Load(object sender, EventArgs e)
		{
			bool bResult = true;
			
			oCellSource.ID = oCellTarget.ID = -1;
			bResult = cboStoresZonesSource_Restore() &&
					  cboStoresZonesTypesSource_Restore() &&
					  cboCellSourceAddress_Restore() && 
					  cboStoresZonesTarget_Restore() &&
					  cboStoresZonesTypesTarget_Restore() &&
					  cboCellTargetAddress_Restore();

			if (bResult)
			{
				cboCellSourceAddress.SelectedIndex =
				cboStoresZonesSource.SelectedIndex =
				cboStoresZonesTypesSource.SelectedIndex =
				cboCellTargetAddress.SelectedIndex =
				cboStoresZonesTarget.SelectedIndex =
				cboStoresZonesTypesTarget.SelectedIndex = -1;
			}

			if (oTrafficOld.ID != null)
			{
				oTrafficOld.FillData();
				if (oTrafficOld.ErrorNumber != 0 || oTrafficOld.MainTable.Rows.Count == 0)
				{
					RFMMessage.MessageBoxError("Ошибка при получении данных о текущей операции перемещения коробок/штук...");
					// просто добавляем
				}
				else
				{ 
					DataRow r = oTrafficOld.MainTable.Rows[0];
					if (r != null)
					{
						// источник
						int nCellSourceID = Convert.ToInt32(r["CellSourceID"]);
						cboStoresZonesSource.SelectedValue = Convert.ToInt32(r["StoreZoneSourceID"]);
						cboStoresZonesTypesSource.SelectedValue = Convert.ToInt32(r["StoreZoneTypeSourceID"]);
						cboCellSourceAddress.SelectedValue = nCellSourceID;

						int nPackingID = Convert.ToInt32(r["PackingID"]);
						cboGood.SelectedValue = nPackingID;

						_nInBox = Convert.ToDecimal(r["InBox"]);
						bWeighting = Convert.ToBoolean(r["Weighting"]);

						if (r["OwnerID"] != DBNull.Value)
						{
							_nOwnerID = Convert.ToInt32(r["OwnerID"]);
						}
						_nGoodStateID = Convert.ToInt32(r["GoodStateID"]);

						// данные о текущем наполнении ячейки
						oCellSource.ID = nCellSourceID;
						oCellSource.FillTableCellsContents(nCellSourceID, true);
						foreach(DataRow rCC in oCellSource.TableCellsContents.Rows)
						{
							if (Convert.ToInt32(rCC["PackingID"]) == nPackingID &&
								(rCC["OwnerID"] == DBNull.Value && _nOwnerID == null ||
								Convert.ToInt32(rCC["OwnerID"]) == _nOwnerID) &&
								Convert.ToInt32(rCC["GoodStateID"]) == _nGoodStateID)
							{
								// нашли подходящую строку (объединены по срокам годности)
								_nQntExists = Convert.ToDecimal(rCC["Qnt"]);
							}
						}

						int nBoxExists = 0;
						decimal nRestQntExists = 0;
						if (!bWeighting)
						{
							nBoxExists = Convert.ToInt32(Math.Floor(_nQntExists / _nInBox));
							nRestQntExists = _nQntExists - nBoxExists * _nInBox;
						}
						else
						{
							nRestQntExists = _nQntExists;
						}
						numBoxExists.Value = nBoxExists;
						numRestQntExists.Value = nRestQntExists;
						numRestQntExists.DecimalPlaces = (bWeighting || ((int)_nInBox != _nInBox) ? 3 : 0);

						
						decimal nQntWished = Convert.ToDecimal(r["QntWished"]);
						int nBoxWished = 0;
						decimal nRestQntWished = 0;
						if (!bWeighting)
						{
							nBoxWished = Convert.ToInt32(Math.Floor(nQntWished / _nInBox));
							nRestQntWished = nQntWished - nBoxWished * _nInBox;
						}
						else
						{
							nRestQntWished = nQntWished;
						}
						numBoxWished.Value = nBoxWished ;
						numBoxWished.Enabled = !bWeighting; 
						numRestQntWished.Value = nRestQntWished;
						numRestQntWished.DecimalPlaces = (bWeighting || ((int)_nInBox != _nInBox)) ? 3 : 0;

						txtGoodState.Text = r["GoodStateName"].ToString();
						txtOwner.Text = r["OwnerName"].ToString();
						dtpDateValid.Value = DateTime.Now.Date;
						dtpDateValid.HideControl(false);

						// приемник
						cboStoresZonesTarget.SelectedValue = Convert.ToInt32(r["StoreZoneTargetID"]);
						cboStoresZonesTypesTarget.SelectedValue = Convert.ToInt32(r["StoreZoneTypeTargetID"]);
						cboCellTargetAddress.SelectedValue = Convert.ToInt32(r["CellTargetID"]);
					}
				}
			}

			if (bResult)
				_bLoaded = true;
			else
			{
				DialogResult = DialogResult.No;
				Dispose();
			}
			cboStoresZonesTypesSource.Enabled = false;
		}

		private void btnHelp_Click(object sender, EventArgs e)
		{
			RFMHelpUtilities.HelpShow(this, hpHelp);
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.No;
			Dispose();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			int nCellSourceID = 0;
			int nCellTargetID = 0;

			string sMessage = "Создать операцию для перемещения коробок/штук\n";

			if (cboCellSourceAddress.SelectedIndex < 0)
			{
				RFMMessage.MessageBoxError("Не выбрана исходная ячейка...");
				return;
			}
			nCellSourceID = (int)cboCellSourceAddress.SelectedValue;
			sMessage = sMessage + "из ячейки " + cboCellSourceAddress.Text + " ";

			if (cboCellTargetAddress.SelectedIndex < 0)
			{
				RFMMessage.MessageBoxError("Не выбрана конечная ячейка...");
				return;
			}
			nCellTargetID = (int)cboCellTargetAddress.SelectedValue;

			if (nCellSourceID == nCellTargetID)
			{
				RFMMessage.MessageBoxError("Выбрана та же ячейка...");
				return;
			}
			sMessage = sMessage + "в ячейку " + cboCellTargetAddress.Text + "?";

			if (cboGood.SelectedIndex < 0)
			{
				RFMMessage.MessageBoxError("Не выбран товар...");
				return;
			}
			int nPackingID = (int)cboGood.SelectedValue;
			
			decimal nQntWished = numBoxWished.Value * _nInBox + numRestQntWished.Value;
			if (nQntWished == 0)
			{
				RFMMessage.MessageBoxError("Не указано количество фактически перемещаемого товара...");
				return;
			}
			if (nQntWished > _nQntExists)
			{
				if (RFMMessage.MessageBoxYesNo("Количество заказанного товара больше, чем имеется в ячейке.\nВсе-таки сохранить?") != DialogResult.Yes)
					return;
			}

			if (_nGoodStateID == null)
			{
				RFMMessage.MessageBoxError("Не определено состояние товара...");
				return;
			}

			if (RFMMessage.MessageBoxYesNo(sMessage) == DialogResult.Yes)
			{
				// не указываем срок годности
				oTraffic.CreateManual(nPackingID, nQntWished, null, (int)_nGoodStateID, _nOwnerID, nCellSourceID, nCellTargetID);
			}
			else
			{
				return;
			}

			if (oTraffic.ErrorNumber == 0)
			{
				RFMMessage.MessageBoxInfo("Создано задание на перемещение коробок/штук.");
				DialogResult = DialogResult.Yes;
				Dispose();
			}
		}

	#region Restore

		// Source 

		private bool cboCellSourceAddress_Restore()
		{
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
					RFMMessage.MessageBoxError("Нет подходящих ячеек в выбранной исходной зоне...");
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

		private bool cboStoresZonesSource_Restore()
		{
			oStoreZoneSource.FillData();
			cboStoresZonesSource.ValueMember = oStoreZoneSource.MainTable.Columns[0].Caption;
			cboStoresZonesSource.DisplayMember = oStoreZoneSource.MainTable.Columns[1].Caption;
			cboStoresZonesSource.DataSource = oStoreZoneSource.MainTable;
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

		// Target

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

		private bool cboStoresZonesTarget_Restore()
		{
			oStoreZoneTarget.FillData();
			cboStoresZonesTarget.ValueMember = oStoreZoneTarget.MainTable.Columns[0].Caption;
			cboStoresZonesTarget.DisplayMember = oStoreZoneTarget.MainTable.Columns[1].Caption;
			cboStoresZonesTarget.DataSource = oStoreZoneTarget.MainTable;
			return (oStoreZoneTarget.ErrorNumber == 0);
		}

		private bool cboStoresZonesTypesTarget_Restore()
		{
			oStoreZoneTarget.FillTableStoresZonesTypes();
			cboStoresZonesTypesTarget.ValueMember   = oStoreZoneTarget.TableStoresZonesTypes.Columns[0].Caption;
			cboStoresZonesTypesTarget.DisplayMember = oStoreZoneTarget.TableStoresZonesTypes.Columns[1].Caption;
			cboStoresZonesTypesTarget.DataSource = oStoreZoneTarget.TableStoresZonesTypes;
			return (oStoreZoneTarget.ErrorNumber == 0);
		}

		private bool cboGood_Restore()
		{
			if (cboCellSourceAddress.SelectedIndex < 0)
			{
				cboGood.Enabled = false;
				cboGood.DataSource = null;
			}
			else
			{
				cboGood.Enabled = true;
				oCellSource.ID = (int)cboCellSourceAddress.SelectedValue;
				oCellSource.FillTableCellsContents(oCellSource.ID, true);
				cboGood.ValueMember = oCellSource.TableCellsContents.Columns["PackingID"].Caption;
				cboGood.DisplayMember = oCellSource.TableCellsContents.Columns["PackingAlias"].Caption;
				cboGood.DataSource = oCellSource.TableCellsContents;
			}
			return (oCellSource.ErrorNumber == 0);
		}

	#endregion

	#region Выбор ячейки

		private void cboStoresZonesSource_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboStoresZonesSource.SelectedIndex >= 0)
			{
				DataRow sz = oStoreZoneSource.MainTable.Rows[cboStoresZonesSource.SelectedIndex];
				if (sz != null)
				{
					cboStoresZonesTypesSource.SelectedValue = Convert.ToInt32(sz["StoreZoneTypeID"]);
				}
			}
			cboCellSourceAddress_Restore();
		}

		private void cboStoresZonesTarget_SelectedIndexChanged(object sender, EventArgs e)
		{
			cboCellTargetAddress_Restore();
			if (cboStoresZonesTarget.SelectedIndex >= 0)
			{
				DataRow sz = oStoreZoneTarget.MainTable.Rows[cboStoresZonesTarget.SelectedIndex];
				if (sz != null)
				{
					cboStoresZonesTypesTarget.SelectedValue = Convert.ToInt32(sz["StoreZoneTypeID"]);
				}
			}
		}

		private void cboCellSourceAddress_SelectedIndexChanged(object sender, EventArgs e)
		{
			cboGood_Restore();
		}

		private void cboGood_SelectedIndexChanged(object sender, EventArgs e)
		{
			_nInBox = 0;
			_nQntExists = 0;
			numBoxWished.Enabled = 
			numRestQntWished.Enabled = 
				false;
			numBoxExists.Value = 
			numRestQntExists.Value = 
			numBoxWished.Value = 
			numRestQntWished.Value = 
				0;
			_nGoodStateID = 
			_nOwnerID = 
				null;
			txtGoodState.Text = 
			txtOwner.Text = 
				"";
			dtpDateValid.HideControl(false);
			if (cboGood.SelectedIndex < 0 || !cboGood.Enabled || cboGood.DataSource == null)
				return;

			DataRow r = oCellSource.TableCellsContents.Rows[cboGood.SelectedIndex];
			if (r != null)
			{
				numBoxWished.Enabled = 
				numRestQntWished.Enabled = 
					true;
				decimal nInBox = Convert.ToDecimal(r["InBox"]);
				_nInBox = nInBox;
				bWeighting = Convert.ToBoolean(r["Weighting"]);

				_nQntExists = Convert.ToDecimal(r["Qnt"]);
				int nBoxExists = 0;
				decimal nRestQntExists = 0;
				if (!bWeighting)
				{
					nBoxExists = Convert.ToInt32(Math.Floor(_nQntExists / _nInBox));
					nRestQntExists = _nQntExists - nBoxExists * _nInBox;
				}
				else
				{
					nRestQntExists = _nQntExists;
				}
				numBoxExists.Value = nBoxExists;
				numRestQntExists.Value = nRestQntExists;
				numRestQntExists.DecimalPlaces = (bWeighting || ((int)nInBox != nInBox) ? 3 : 0);

				numBoxWished.Value = nBoxExists;
				numBoxWished.Enabled = !bWeighting;
				numRestQntWished.Value = nRestQntExists;
				numRestQntWished.DecimalPlaces = (bWeighting || ((int)nInBox != nInBox) ? 3 : 0); 

				if (r["OwnerID"] == DBNull.Value)
				{
					_nOwnerID = null;
					txtOwner.Text = "";
				}
				else
				{
					_nOwnerID = (int)r["OwnerID"];
					txtOwner.Text = r["OwnerName"].ToString();
				}
				_nGoodStateID = (int)r["GoodStateID"];
				txtGoodState.Text = r["GoodStateName"].ToString();
				if (r["DateValid"] == DBNull.Value)
				{
					dtpDateValid.HideControl(false);
					dtpDateValid.Value = DateTime.Now.Date;
				}
				else
				{
					dtpDateValid.Value = Convert.ToDateTime(r["DateValid"]);
					dtpDateValid.HideControl(true);
					dtpDateValid.Enabled = false;
				}
			}
		}

	#endregion

	}
}