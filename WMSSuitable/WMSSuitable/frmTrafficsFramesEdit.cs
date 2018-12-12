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
	public partial class frmTrafficsFramesEdit : RFMFormChild
	{
		protected TrafficFrame oTraffic;
		protected Frame oFrame;

		protected Cell oCellSource;
		protected StoreZone oStoreZoneSource;
		protected Cell oBufferCellSource;

		protected Cell oCellTarget;
		protected StoreZone oStoreZoneTarget;
		protected Cell oBufferCellTarget;

		protected User oUser;
		protected Device oDevice;

		protected bool bSaved = false;
		protected bool _bLoaded = false;

		public frmTrafficsFramesEdit()
		{
			oTraffic = new TrafficFrame();
			oFrame = new Frame();
			oCellSource = new Cell();
			oStoreZoneSource = new StoreZone();
			oBufferCellSource = new Cell();
			oCellTarget = new Cell();
			oStoreZoneTarget = new StoreZone();
			oBufferCellTarget = new Cell();
			oUser = new User();
			oDevice = new Device();

			if (oTraffic.ErrorNumber != 0 ||
				oFrame.ErrorNumber != 0 ||
				oCellSource.ErrorNumber != 0 ||
				oBufferCellSource.ErrorNumber != 0 ||
				oStoreZoneSource.ErrorNumber != 0 ||
				oCellTarget.ErrorNumber != 0 ||
				oBufferCellTarget.ErrorNumber != 0 ||
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

		public frmTrafficsFramesEdit(int nTrafficID) : this()
		{
			oTraffic.ID = nTrafficID;
		}

		
		private void frmTrafficsFramesEdit_Load(object sender, EventArgs e)
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
				chkLockFrame.Enabled = 
				chkLockCellSource.Enabled = 
				chkLockCellFinish.Enabled = 
					false;

				//optNoChanges.Checked = true;
				optCellTarget.Checked = true;
				optError_CheckedChanged(null, null);

				if (oTraffic.ID > 0)
				{
					txtFrameBarCode.Enabled = txtFrameID4.Enabled = false;
					bResult = TrafficChoose();
				}
			}

			if (bResult)
			{
				if (oTraffic.ID.HasValue && oTraffic.ID != 0)
				{
					Text = Text + " (код " + oTraffic.ID.ToString() + ")";
				}
				_bLoaded = true;
			}
			else
			{
				DialogResult = DialogResult.No;
				Dispose();
			}
			cboStoresZonesSource.Enabled =
			cboCellSourceAddress.Enabled =
			cboStoresZonesTypesSource.Enabled =
			cboStoresZonesTarget.Enabled =
			cboCellTargetAddress.Enabled =
			cboStoresZonesTypesTarget.Enabled = 
			cboBufferCellTargetAddress.Enabled = false;
			
		}

		private void btnHelp_Click(object sender, EventArgs e)
		{
			RFMHelpUtilities.HelpShow(this, hpHelp);
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			if (txtFrameBarCode.Enabled && bSaved)
				DialogResult = DialogResult.Yes;
			else
				DialogResult = DialogResult.No;
			Dispose();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (oTraffic.ID == null)
			{
				RFMMessage.MessageBoxError("Не определена операция транспортировки...");
				return; 
			}

			int? nCellFinishID = null;
			int? nTrafficErrorID = null;
			bool bLockFrame = false, bLockCellSource = false, bLockCellFinish = false;

			if (optNoChanges.Checked)
			{
				if (RFMMessage.MessageBoxYesNo("Положение контейнера не меняется.\nСохранить только сведения и пользователе, устройстве и приоритете задания?") != DialogResult.Yes)
					return;
			}

			if (optBufferCellSource.Checked)
			{
				if (cboBufferCellSourceAddress.SelectedValue == null || cboBufferCellSourceAddress.SelectedIndex < 0)
				{
					RFMMessage.MessageBoxError("Не определен буфер ячейки-источника...\nСохранение невозможно.");
					return;
				}
				if (RFMMessage.MessageBoxYesNo("Регистрируется установка контейнера в буфер ячейки-источника " + cboBufferCellSourceAddress.Text + ".\nСохранить?") == DialogResult.Yes)
				{
					nCellFinishID = (int)cboBufferCellSourceAddress.SelectedValue;
				}
				else
				{
					return;
				}
			}

			if (optBufferCellTarget.Checked)
			{
				if (cboBufferCellTargetAddress.SelectedValue == null || cboBufferCellTargetAddress.SelectedIndex < 0)
				{
					RFMMessage.MessageBoxError("Не определен буфер ячейки-приемника...\nСохранение невозможно.");
					return;
				}
				if (RFMMessage.MessageBoxYesNo("Регистрируется установка контейнера в буфер ячейки-приемника " + cboBufferCellTargetAddress.Text + ".\nСохранить?") == DialogResult.Yes)
				{
					nCellFinishID = (int)cboBufferCellTargetAddress.SelectedValue;
				}
				else
				{
					return;
				}
			}

			if (optCellTarget.Checked)
			{
				if (cboCellTargetAddress.SelectedValue == null || cboCellTargetAddress.SelectedIndex < 0)
				{
					RFMMessage.MessageBoxError("Не определена ячейка-приемник...\nСохранение невозможно.");
					return;
				}
				if (RFMMessage.MessageBoxYesNo("Регистрируется установка контейнера в ячейку-приемник " + cboCellTargetAddress.Text + ".\nСохранить?") == DialogResult.Yes)
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
				
				nTrafficErrorID = (int)cboTrafficError.SelectedValue;
				nCellFinishID = (int)cboCellTargetAddress.SelectedValue;

				// код ошибки
				int nSeverity = 0;
				DataRow rErr = oTraffic.TableTrafficsFramesErrors.Rows.Find(nTrafficErrorID);
				if (rErr == null)
				{
					RFMMessage.MessageBoxError("Не найден код ошибки...");
					return;
				}
				nSeverity = Convert.ToInt32(rErr["Severity"]);
				if (nSeverity < 0)
				{ 
					// специальный код ошибки (-> Lost&Found)
					Setting oSet = new Setting();
					string sLostFoundAddress = oSet.FillVariable("sLostFoundAddress");
					if (sLostFoundAddress == null || sLostFoundAddress.Length == 0)
					{
						RFMMessage.MessageBoxError("Не найдена виртуальная ячейка Lost&Found...");
						return;
					}

					if (RFMMessage.MessageBoxYesNo("Регистрируется неудачное выполнение задания с ошибкой.\n" +
						"Выбран тип ошибки: " + cboTrafficError.Text.Trim() + ",\n" + 
						"контейнер направляется в виртуальную ячейку " + sLostFoundAddress + ".\n" + 
						"Сохранить?") != DialogResult.Yes)
					{
						return;
					}
				}
				else
				{
					bLockFrame = chkLockFrame.Checked;
					bLockCellSource = chkLockCellSource.Checked;
					bLockCellFinish = chkLockCellFinish.Checked;
					string sText = "Регистрируется неудачное выполнение задания с ошибкой.\n" +
						"Контейнер считается установленным в ячейке-источнике " + cboCellSourceAddress.Text + ".\n";
					if (bLockFrame)
					{
						sText += "Контейнер блокируется.\n";
					}
					if (bLockCellSource || bLockCellFinish)
					{
						Cell oCellTemp = new Cell();
						string sShortCode = "";
						if (bLockCellSource)
						{
							oCellTemp.ID = (int)cboCellSourceAddress.SelectedValue;
							oCellTemp.FillData();
							if (oCellTemp.ErrorNumber == 0 && oCellTemp.MainTable.Rows.Count == 1)
							{ 
								sShortCode = oCellTemp.MainTable.Rows[0]["StoreZoneTypeShortCode"].ToString();
								if (sShortCode.Contains("STOR") || sShortCode.Contains("RILL"))
								{ 
									sText += "Ячейка-источник " + cboCellSourceAddress.Text + " блокируется.\n";
								}
							}
						}
						if (bLockCellFinish)
						{
							oCellTemp.ID = (int)cboCellTargetAddress.SelectedValue;
							oCellTemp.FillData();
							if (oCellTemp.ErrorNumber == 0 && oCellTemp.MainTable.Rows.Count == 1)
							{ 
								sShortCode = oCellTemp.MainTable.Rows[0]["StoreZoneTypeShortCode"].ToString();
								if (sShortCode.Contains("STOR") || sShortCode.Contains("RILL"))
								{
									sText += "Ячейка-приемник " + cboCellTargetAddress.Text + " блокируется.\n";
								}
							}
						}
					}

					if (RFMMessage.MessageBoxYesNo(sText + "\nСохранить?") != DialogResult.Yes)
					{
						return;
					}
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
			oTraffic.SaveDataPartial((int)oTraffic.ID, nCellFinishID, nUserID, nDeviceID, nPriority, nTrafficErrorID);
			if (oTraffic.ErrorNumber == 0)
			{
				RFMMessage.MessageBoxInfo((optNoChanges.Checked) ? "Сохранено." : "Подтверждено.");
				if (txtFrameBarCode.Enabled)
				{
					bSaved = true; 
					txtFrameBarCode.Text = txtFrameID4.Text = "";
					chkStereo.Checked = false;
					txtFrameGoodState.Text = txtFrameOwner.Text = "";
					cboCellSourceAddress.SelectedIndex = 
					cboStoresZonesSource.SelectedIndex = 
					cboStoresZonesTypesSource.SelectedIndex = 
					cboBufferCellSourceAddress.SelectedIndex = 
					cboCellTargetAddress.SelectedIndex = 
					cboStoresZonesTarget.SelectedIndex =
					cboStoresZonesTypesTarget.SelectedIndex = 
					cboBufferCellTargetAddress.SelectedIndex = -1;
					txtFrameID4.Select();
				}
				else
				{
					DialogResult = DialogResult.Yes;
					Dispose();
				}
			}
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
			oTraffic.FillTableTrafficsFramesErrors();
			cboTrafficError.ValueMember = oTraffic.TableTrafficsFramesErrors.Columns[0].Caption;
			cboTrafficError.DisplayMember = oTraffic.TableTrafficsFramesErrors.Columns[1].Caption;
			cboTrafficError.DataSource = oTraffic.TableTrafficsFramesErrors;
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

		private bool cboBufferCellSourceAddress_Restore()
		{
			if (oBufferCellSource.ID.HasValue)
			{
				cboBufferCellSourceAddress.ValueMember = oBufferCellSource.MainTable.Columns[0].Caption;
				cboBufferCellSourceAddress.DisplayMember = oBufferCellSource.MainTable.Columns["Address"].Caption;
				cboBufferCellSourceAddress.DataSource = oBufferCellSource.MainTable;
				cboBufferCellSourceAddress.SelectedValue = oBufferCellSource.ID;
			}
			return (oBufferCellSource.ErrorNumber == 0);
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

		private bool cboBufferCellTargetAddress_Restore()
		{
			if (oBufferCellTarget.ID.HasValue)
			{
				cboBufferCellTargetAddress.ValueMember = oBufferCellTarget.MainTable.Columns[0].Caption;
				cboBufferCellTargetAddress.DisplayMember = oBufferCellTarget.MainTable.Columns["Address"].Caption;
				cboBufferCellTargetAddress.DataSource = oBufferCellTarget.MainTable;
				cboBufferCellTargetAddress.SelectedValue = oBufferCellTarget.ID;
			}
			return (oBufferCellTarget.ErrorNumber == 0);
		}

		private bool TrafficChoose()
		{
			WaitOn(this);

			bool bResult = true;

			oTraffic.FillData();
			DataRow r = oTraffic.MainTable.Rows[0];
			if (r == null)
			{
				RFMMessage.MessageBoxError("Не найдена запись для операции транспортировки с кодом " + r["ID"].ToString() + "...");
				bResult = false;
			}
			if (bResult)
			{
				// контейнер
				oFrame.ID = (int)r["FrameID"];
				oFrame.FillData();
				DataRow f = oFrame.MainTable.Rows[0];
				txtFrameBarCode.Text = f["BarCode"].ToString();
				txtFrameOwner.Text = f["OwnerName"].ToString();
				txtFrameGoodState.Text = f["GoodStateName"].ToString();
				chkStereo.Checked = (bool)f["Stereo"];
				bResult = (oFrame.ErrorNumber == 0);
			}
			if (bResult)
			{
				// ячейка-источник
				oCellSource.ID = (int)r["CellSourceID"];
				oCellSource.FillData();
				DataRow rcs = oCellSource.MainTable.Rows[0];
				cboStoresZonesSource.SelectedValue = (int)rcs["StoreZoneID"];
				cboStoresZonesTypesSource.SelectedValue = (int)rcs["StoreZoneTypeID"];
				if (rcs["BufferCellID"] == DBNull.Value ||
					(int)rcs["BufferCellID"] == (int)r["CellSourceID"] ||
					(int)rcs["BufferCellID"] == (int)r["CellTargetID"])
				{
					cboBufferCellSourceAddress.SelectedIndex = -1;
					optBufferCellSource.Enabled = false;
				}
				else
				{
					oBufferCellSource.ID = (int)rcs["BufferCellID"];
					oBufferCellSource.FillData();
					optBufferCellSource.Enabled = true;
				}


				// ячейка-приемник
				oCellTarget.ID = (int)r["CellTargetID"];
				oCellTarget.FillData();
				DataRow rct = oCellTarget.MainTable.Rows[0];
				cboStoresZonesTarget.SelectedValue = (int)rct["StoreZoneID"];
				cboStoresZonesTypesTarget.SelectedValue = (int)rct["StoreZoneTypeID"];
				if (rct["BufferCellID"] == DBNull.Value ||
					(int)rct["BufferCellID"] == (int)r["CellSourceID"] ||
					(int)rct["BufferCellID"] == (int)r["CellTargetID"])
				{
					cboBufferCellSourceAddress.SelectedIndex = -1;
					optBufferCellTarget.Enabled = false;
				}
				else
				{
					oBufferCellTarget.ID = (int)rct["BufferCellID"];
					oBufferCellTarget.FillData();
					optBufferCellTarget.Enabled = true;
				}
				bResult = (oCellSource.ErrorNumber == 0) &&
						  (oCellTarget.ErrorNumber == 0);
			}

			if (bResult)
			{
				bResult = cboCellSourceAddress_Restore() &&
						  cboBufferCellSourceAddress_Restore() &&
						  cboCellTargetAddress_Restore() &&
						  cboBufferCellTargetAddress_Restore();
			}

			if (bResult)
			{
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
			}

			WaitOff(this);
			return (bResult);
		}

	#endregion

	#region Error choise

		private void optError_CheckedChanged(object sender, EventArgs e)
		{
			if (optError.Checked)
			{
				cboTrafficError.Enabled = true;
				//chkLockCellFinish.Enabled = true;

				// проверим специальный код ошибки
				int nSeverity = 0;
				bool bLockCell = false;
				if (cboTrafficError.SelectedValue != null && cboTrafficError.SelectedIndex >= 0)
				{
					DataRow rErr = oTraffic.TableTrafficsFramesErrors.Rows.Find(Convert.ToInt32(cboTrafficError.SelectedValue));
					if (rErr != null)
					{
						nSeverity = Convert.ToInt32(rErr["Severity"]);
						bLockCell = Convert.ToBoolean(rErr["LockCell"]);
						chkLockCellFinish.Checked = bLockCell;
					}
				}
			}
			else
			{
				cboTrafficError.SelectedIndex = -1;  
				cboTrafficError.Enabled = false;
				chkLockCellFinish.Checked = false;
				//chkLockCellFinish.Enabled = false;
			}
		}

		private void cboTrafficError_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboTrafficError.SelectedValue != null && cboTrafficError.SelectedIndex >= 0)
			{
				//chkLockCellFinish.Enabled = true;

				// выбран тип ошибки 
				DataRow rErr = oTraffic.TableTrafficsFramesErrors.Rows.Find(Convert.ToInt32(cboTrafficError.SelectedValue));
				int? nSeverity = null;
				bool? bLockFrame = null, bLockCellSource = null, bLockCellFinish = null;
				
				if (rErr != null)
				{
					// блокировать контейнер или ячейку?
					bLockFrame = Convert.ToBoolean(rErr["LockFrame"]);
					bLockCellSource = Convert.ToBoolean(rErr["LockCellSource"]);
					bLockCellFinish = Convert.ToBoolean(rErr["LockCellTarget"]);
					// проверим специальный код ошибки
					nSeverity = Convert.ToInt32(rErr["Severity"]);
				}
				if (nSeverity != null && nSeverity < 0)
				{
					chkLockFrame.Checked = false;
					chkLockCellSource.Checked = false;
					chkLockCellFinish.Checked = false;
				}
				if (bLockFrame != null)
				{
					chkLockFrame.Checked = (bool)bLockFrame;
				}
				if (bLockCellSource != null)
				{
					chkLockCellSource.Checked = (bool)bLockCellSource;
				}
				if (bLockCellFinish != null)
				{
					chkLockCellFinish.Checked = (bool)bLockCellFinish;
				}
			}
			else
			{
				//chkLockCellFinish.Enabled = false;
			}
		}

	#endregion

	#region Выбор контейнера

		private void txtFrameID4_TextChanged(object sender, EventArgs e)
		{
			if (txtFrameID4.Text.Length == 4)
			{
				// ищем подходящий контейнер среди невыполненных операций
				oTraffic.ID = null;
				oTraffic.FilterConfirmed = false;
				oTraffic.FillData();
				if (oTraffic.MainTable.Rows.Count > 0)
				{
					foreach (DataRow r in oTraffic.MainTable.Rows)
					{
						if (r["FrameBarCode"].ToString().EndsWith(txtFrameID4.Text.Trim()))
						{
							oTraffic.ID = Convert.ToInt32(r["ID"]);
							break;
						}
					}
				}
				if (oTraffic.ID == null)
				{
					RFMMessage.MessageBoxError("Нет невыполненных операций транспортировки\nдля такого контейнера...");
					txtFrameBarCode.Text = txtFrameID4.Text = "";
					return;
				}
				else
				{
					TrafficChoose();
				}
			}
		}

		private void txtFrameBarCode_Validating(object sender, CancelEventArgs e)
		{
			if (txtFrameBarCode.Text.Length > 0)
			{
				// ищем подходящий контейнер среди невыполненных операций
				oTraffic.ID = null;
				oTraffic.FilterConfirmed = false;
				oTraffic.FillData();
				if (oTraffic.MainTable.Rows.Count > 0)
				{
					foreach (DataRow r in oTraffic.MainTable.Rows)
					{
						if (r["FrameBarCode"].ToString().Contains(txtFrameBarCode.Text.Trim()))
						{
							oTraffic.ID = Convert.ToInt32(r["ID"]);
							break;
						}
					}
				}
				if (oTraffic.ID == null)
				{
					RFMMessage.MessageBoxError("Нет невыполненных операций транспортировки\nдля такого контейнера...");
					txtFrameBarCode.Text = txtFrameID4.Text = "";
					return;
				}
				else
				{
					TrafficChoose();
				}
			}
		}

		private void txtFrameBarCode_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				txtFrameBarCode_Validating(null, null);
		}

	#endregion

	}
}