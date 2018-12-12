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
	public partial class frmTrafficsGoodsEdit : RFMFormChild
	{
		protected TrafficGood oTraffic;
		
		protected Cell oCellSource;
		protected StoreZone oStoreZoneSource;
		
		protected Cell oCellTarget;
		protected StoreZone oStoreZoneTarget;

		protected User oUser;
		protected Device oDevice;

		protected bool _bLoaded = false;

		protected decimal _nInBox = 0;
		protected decimal _nQntWished = 0;
		protected bool bWeighting = false;
		
		public frmTrafficsGoodsEdit()
		{
			oTraffic = new TrafficGood();
			oCellSource = new Cell();
			oStoreZoneSource = new StoreZone();
			oCellTarget = new Cell();
			oStoreZoneTarget = new StoreZone();
			oUser = new User();
			oDevice = new Device();

			if (oTraffic.ErrorNumber != 0 ||
				oCellSource.ErrorNumber != 0 ||
				oStoreZoneSource.ErrorNumber != 0 ||
				oCellTarget.ErrorNumber != 0 ||
				oStoreZoneTarget.ErrorNumber != 0 ||
				oUser.ErrorNumber != 0 ||
				oDevice.ErrorNumber != 0)
			{
				IsValid = false;
			}

			if (IsValid)
			{
				InitializeComponent();
				oTraffic.ID = 0;
			}
		}

		public frmTrafficsGoodsEdit(int nTrafficID) : this()
		{
			oTraffic.ID = nTrafficID;
		}

		
		private void frmTrafficsGoodsEdit_Load(object sender, EventArgs e)
		{
			bool bResult = true;

			if (bResult)
			{
				//  заполнение cbo-классификаторов 
				bResult = cboDevice_Restore() &&
						  cboUser_Restore() &&
						  cboTrafficError_Restore() &&
						  cboStoresZonesSource_Restore() &&
						  cboStoresZonesTypesSource_Restore() &&
						  cboStoresZonesTarget_Restore() &&
						  cboStoresZonesTypesTarget_Restore();
			}

			if (bResult)
			{
				cboTrafficError.SelectedIndex = -1;
				chkLockCellFinish.Enabled = false;

				//optNoChanges.Checked = true;
				optCellTarget.Checked = true;

				bResult = TrafficChoose();
			}

			if (bResult)
			{
				Text = Text + " (код " + oTraffic.ID.ToString() + ")";
				_bLoaded = true;
			}
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
			if (oTraffic.ID == null)
			{
				RFMMessage.MessageBoxError("Не определена операция перемещения штук/коробок...");
				return; 
			}

			decimal? nQntConfirmed = numBoxConfirmed.Value * _nInBox + numRestQntConfirmed.Value;

			int? nCellFinishID = null;
			int? nTrafficErrorID = null;
			bool bLockCellFinish = false;

			if (optNoChanges.Checked)
			{
				if (RFMMessage.MessageBoxYesNo("Положение товара не меняется.\nСохранить только сведения и пользователе, устройстве и приоритете задания?") != DialogResult.Yes)
				{
					return;
				}
				nQntConfirmed = null;
			}

			if (optCellTarget.Checked)
			{
				if (cboCellTargetAddress.SelectedValue == null || cboCellTargetAddress.SelectedIndex < 0)
				{
					RFMMessage.MessageBoxError("Не определена ячейка-приемник...\nСохранение невозможно.");
					return;
				}

				if (nQntConfirmed > _nQntWished)
				{
					if (RFMMessage.MessageBoxYesNo("Количество фактически перемещенного товара больше, чем заказано.\nВсе-таки сохранить?") != DialogResult.Yes)
						return;
				}

				if (nQntConfirmed == 0)
				{
					if (RFMMessage.MessageBoxYesNo("Не указано количество фактически перемещенного товара.\nВсе-таки сохранить?") != DialogResult.Yes)
						return;
				}

				if (RFMMessage.MessageBoxYesNo("Регистрируется перемещение товара в ячейку-приемник " + cboCellTargetAddress.Text + ".\nСохранить?") == DialogResult.Yes)
				{
					nCellFinishID = (int)cboCellTargetAddress.SelectedValue;
				}
				else
				{
					return;
				}
			}

			if (optError.Checked) 
			{
				if (cboTrafficError.SelectedValue == null || cboTrafficError.SelectedIndex < 0)
				{
					RFMMessage.MessageBoxError("Не указана ошибка при неудачном выполнении задания...\nУкажите характер ошибки.");
					return;
				}
				bLockCellFinish = chkLockCellFinish.Checked;
				if (RFMMessage.MessageBoxYesNo("Регистрируется неудачное выполнение задания с ошибкой.\n" + 
					"Товар считается размещенным в ячейке-источнике " + cboCellSourceAddress.Text + ".\n" + 
					((bLockCellFinish) ? "Ячейка-приемник " + cboCellTargetAddress.Text + " блокируется.\n\n" : "")+ 
					"Сохранить?") == DialogResult.Yes)
				{
					nTrafficErrorID = (int)cboTrafficError.SelectedValue;
					nCellFinishID = (int)cboCellTargetAddress.SelectedValue;
					nQntConfirmed = 0;
				}
				else 
				{
					return;
				}
			}

			int? nUserID, nDeviceID, nPriority;
			nUserID = nDeviceID = null;
			if (cboUser.SelectedValue != null && (int)cboUser.SelectedValue > 0)
				nUserID = (int)cboUser.SelectedValue;
			if (cboDevice.SelectedValue != null && (int)cboDevice.SelectedValue > 0) 
				nDeviceID = (int)cboDevice.SelectedValue;
			nPriority = Convert.ToInt32(numPriority.Value);

			oTraffic.ClearError();
			oTraffic.SaveDataPartial((int)oTraffic.ID, nQntConfirmed, 
				nUserID, nDeviceID, nPriority, 
				nTrafficErrorID, bLockCellFinish);
			if (oTraffic.ErrorNumber == 0)
			{
				RFMMessage.MessageBoxInfo((optNoChanges.Checked) ? "Сохранено." : "Подтверждено.");
				{
					DialogResult = DialogResult.Yes;
					Dispose();
				}
			}
		}

		private void optError_CheckedChanged(object sender, EventArgs e)
		{
			cboTrafficError.Enabled = chkLockCellFinish.Enabled = optError.Checked;
		}

	#region Restore
		
		private bool cboUser_Restore()
		{
			oUser.FillData();
			cboUser.ValueMember = oUser.MainTable.Columns[0].Caption;
			cboUser.DisplayMember = oUser.MainTable.Columns["Name"].Caption;
			cboUser.DataSource = oUser.MainTable;
			return (oUser.ErrorNumber == 0);
		}

		private bool cboDevice_Restore()
		{
			oDevice.FillData();
			cboDevice.ValueMember = oDevice.MainTable.Columns[0].Caption;
			cboDevice.DisplayMember = oDevice.MainTable.Columns["Name"].Caption;
			cboDevice.DataSource = oDevice.MainTable;
			return (oDevice.ErrorNumber == 0);
		}

		private bool cboTrafficError_Restore()
		{
			oTraffic.FillTableTrafficsGoodsErrors();
			cboTrafficError.ValueMember = oTraffic.TableTrafficsGoodsErrors.Columns[0].Caption;
			cboTrafficError.DisplayMember = oTraffic.TableTrafficsGoodsErrors.Columns[1].Caption;
			cboTrafficError.DataSource = oTraffic.TableTrafficsGoodsErrors;
			return (oTraffic.ErrorNumber == 0);
		}

		// Source

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

		private bool cboCellSourceAddress_Restore()
		{
			cboCellSourceAddress.ValueMember = oCellSource.MainTable.Columns[0].Caption;
			cboCellSourceAddress.DisplayMember = oCellSource.MainTable.Columns["Address"].Caption;
			cboCellSourceAddress.DataSource = oCellSource.MainTable;
			return (oCellSource.ErrorNumber == 0);
		}

		// Target

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
			cboStoresZonesTypesTarget.ValueMember = oStoreZoneTarget.TableStoresZonesTypes.Columns[0].Caption;
			cboStoresZonesTypesTarget.DisplayMember = oStoreZoneTarget.TableStoresZonesTypes.Columns[1].Caption;
			cboStoresZonesTypesTarget.DataSource = oStoreZoneTarget.TableStoresZonesTypes;
			return (oStoreZoneTarget.ErrorNumber == 0);
		}
		private bool cboCellTargetAddress_Restore()
		{
			cboCellTargetAddress.ValueMember = oCellTarget.MainTable.Columns[0].Caption;
			cboCellTargetAddress.DisplayMember = oCellTarget.MainTable.Columns["Address"].Caption;
			cboCellTargetAddress.DataSource = oCellTarget.MainTable;
			return (oCellTarget.ErrorNumber == 0);
		}

		private bool TrafficChoose()
		{
			WaitOn(this);

			bool bResult = true;

			oTraffic.FillData();
			if (oTraffic.ErrorNumber != 0 || oTraffic.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Не найдена запись для операции перемещения коробок/штук с кодом " + oTraffic.ID.ToString() + "...");
				bResult = false;
			}
 
			if (bResult)
			{
				DataRow r = oTraffic.MainTable.Rows[0];

				// товар в операции перемещения 
				txtPackingAlias.Text = r["PackingAlias"].ToString();

				decimal nInBox = Convert.ToDecimal(r["InBox"]);
				_nInBox = nInBox;
				bWeighting = Convert.ToBoolean(r["Weighting"]);

				decimal nQntWished = Convert.ToDecimal(r["QntWished"]);
				_nQntWished = nQntWished;

				int nBoxWished = 0;
				decimal nRestQntWished = 0;
				if (!bWeighting)
				{
					nBoxWished = Convert.ToInt32(Math.Floor(nQntWished / nInBox));
					nRestQntWished = nQntWished - nBoxWished * nInBox;
				}
				else
				{
					nRestQntWished = nQntWished; 
				}
				numBoxWished.Value = 
				numBoxConfirmed.Value = 
					nBoxWished;
				numBoxConfirmed.Enabled = !bWeighting; 
				numRestQntWished.Value = 
				numRestQntConfirmed.Value = 
					nRestQntWished;
				numRestQntWished.DecimalPlaces = 
				numRestQntConfirmed.DecimalPlaces =
					((bWeighting || ((int)nInBox != nInBox)) ? 3 : 0);
				txtOwner.Text = r["OwnerName"].ToString();
				txtGoodState.Text = r["GoodStateName"].ToString();

				if (r["UserID"] == DBNull.Value || r["UserID"] == null)
					cboUser.SelectedIndex = -1;
				else
					cboUser.SelectedValue = (int)r["UserID"];

				if (r["DeviceID"] == DBNull.Value || r["DeviceID"] == null)
					cboDevice.SelectedIndex = -1;
				else
					cboDevice.SelectedValue = (int)r["DeviceID"];

				numPriority.Value = (int)r["Priority"];

				if (r["DateAccept"] != DBNull.Value)
					cboUser.Enabled = cboDevice.Enabled = false;

				// ячейка-источник
				oCellSource.ID = (int)r["CellSourceID"];
				oCellSource.FillData();
				DataRow rcs = oCellSource.MainTable.Rows[0];
				cboStoresZonesSource.SelectedValue = (int)rcs["StoreZoneID"];
				cboStoresZonesTypesSource.SelectedValue = (int)rcs["StoreZoneTypeID"];

				// ячейка-приемник
				oCellTarget.ID = (int)r["CellTargetID"];
				oCellTarget.FillData();
				DataRow rct = oCellTarget.MainTable.Rows[0];
				cboStoresZonesTarget.SelectedValue = (int)rct["StoreZoneID"];
				cboStoresZonesTypesTarget.SelectedValue = (int)rct["StoreZoneTypeID"];
				
				bResult = (oCellSource.ErrorNumber == 0) &&
						  (oCellTarget.ErrorNumber == 0);

				if (bResult)
				{
					bResult = cboCellSourceAddress_Restore() &&
							  cboCellTargetAddress_Restore();
				}
			}

			WaitOff(this);
			return (bResult);
		}

	#endregion

	}
}