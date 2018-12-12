using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

using WMSBizObjects;
using WMSBaseClasses;
using WMSPublic;

namespace WMSSuitable
{
	public partial class frmTrafficsManual : WMSFormChild
	{
		private Frame oFrame = new Frame();
		
		private Cell oCellSource = new Cell();
		private Cell oBufferCellSource = new Cell();
		private StoreZone oStoreZoneSource = new StoreZone();
		
		private Cell oCellTarget = new Cell();
		private Cell oBufferCellTarget = new Cell();
		private StoreZone oStoreZoneTarget = new StoreZone();
		
		protected bool _bLoaded = false;

		public frmTrafficsManual(int? nFrameID)
		{
			InitializeComponent();
			oFrame.ID = nFrameID;
		}
		
		private void frmTrafficManual_Load(object sender, EventArgs e)
		{
			bool bResult = true;

			oCellTarget.ID = oBufferCellTarget.ID = -1; 
			bResult = cboStoresZonesSource_Restore() &&
					  cboStoresZonesTypesSource_Restore() && 
					  cboStoresZonesTarget_Restore() &&
					  cboStoresZonesTypesTarget_Restore() &&
					  cboCellTargetAddress_Restore() &&
					  cboBufferCellTargetAddress_Restore();
			oCellTarget.ID = oBufferCellTarget.ID = null; 

			if (bResult)
			{
				cboCellSourceAddress.SelectedIndex =
				cboBufferCellSourceAddress.SelectedIndex =
				cboStoresZonesSource.SelectedIndex =
				cboStoresZonesTypesSource.SelectedIndex =
				cboCellTargetAddress.SelectedIndex =
				cboBufferCellTargetAddress.SelectedIndex = -1;

				// контейнер
				if (bResult)
				{
					if (oFrame.ID.HasValue)
					{
						txtFrameBarCode.Enabled = txtFrameID4.Enabled = false;
						bResult = FrameChoose();
					}
				}

				cboCellTargetAddress.SelectedIndex =
				cboBufferCellTargetAddress.SelectedIndex =
				cboStoresZonesTarget.SelectedIndex =
				cboStoresZonesTypesTarget.SelectedIndex = -1;
			}

			if (bResult)
				_bLoaded = true;
			else
			{
				DialogResult = DialogResult.No;
				Dispose();
			}
		}

		private void btnHelp_Click(object sender, EventArgs e)
		{
			WMSHelpUtilities.HelpShow(this, hpHelp);
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.No;
			Dispose();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			int nCellTargetID = 0;
			int nStoreZoneTargetID = 0;
			string sMessage = "Создать операции для транспортировки контейнера\n";
			if (optCellTarget.Checked)
			{
				if (cboCellTargetAddress.SelectedIndex < 0)
				{
					WMSMessage.MessageBoxError("Не выбрана ячейка...");
					return;
				}
				nCellTargetID = (int)cboCellTargetAddress.SelectedValue;
				if (nCellTargetID == (int)cboCellSourceAddress.SelectedValue)
				{
					WMSMessage.MessageBoxError("Выбрана та же ячейка...");
					return;
				}
				sMessage = sMessage + "в ячейку " + cboCellTargetAddress.Text + "?";
			}
			else 
			{
				if (cboStoresZonesTarget.SelectedIndex < 0)
				{
					WMSMessage.MessageBoxError("Не выбрана складская зона...");
					return;
				}
				nStoreZoneTargetID = (int)cboStoresZonesTarget.SelectedValue;
				if (nStoreZoneTargetID == (int)cboStoresZonesSource.SelectedValue)
				{
					if (WMSMessage.MessageBoxYesNo("Выбрана та же складская зона: " + cboStoresZonesTarget.Text + "\nСоздать операции для перемещения контейнера\nв другую (ближайшую) ячейку той же складской зоны?") != DialogResult.Yes)
					{
						return;
					}
				}
				sMessage = sMessage + "в зону " + cboStoresZonesTarget.Text + "?";
			}

			if (WMSMessage.MessageBoxYesNo(sMessage) == DialogResult.Yes)
			{
				oFrame.TrafficForFrameCreateManual((int)oFrame.ID, nCellTargetID, nStoreZoneTargetID);
			}

			if (oFrame.ErrorNumber == 0)
			{
				WMSMessage.MessageBoxInfo("Создано задание на транспортировку контейнера.");
				DialogResult = DialogResult.Yes;
				Dispose();
			}
		}


	#region Restore

		// Source 

		private bool cboCellSourceAddress_Restore()
		{
			//oCellSource.FillData();
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
			oCellTarget.FillData();
			cboCellTargetAddress.ValueMember = oCellTarget.MainTable.Columns[0].Caption;
			cboCellTargetAddress.DisplayMember = oCellTarget.MainTable.Columns["Address"].Caption;
			cboCellTargetAddress.DataSource = oCellTarget.MainTable;
			return (oCellTarget.ErrorNumber == 0);
		}

		private bool cboBufferCellTargetAddress_Restore()
		{
			oBufferCellTarget.FillData();
			cboBufferCellTargetAddress.ValueMember = oBufferCellTarget.MainTable.Columns[0].Caption;
			cboBufferCellTargetAddress.DisplayMember = oBufferCellTarget.MainTable.Columns["Address"].Caption;
			cboBufferCellTargetAddress.DataSource = oBufferCellTarget.MainTable;
			return (oBufferCellTarget.ErrorNumber == 0);
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

		private bool FrameChoose()
		{
			WaitOn(this);

			bool bResult = true;

			oFrame.FillData();
			DataRow r = oFrame.MainTable.Rows[0];
			if (r == null)
			{
				WMSMessage.MessageBoxError("Не найдена запись для контейнера с кодом " + r["ID"].ToString() + "...");
				bResult = false;
			}
			else 
			{
				// контейнер
				txtFrameBarCode.Text = r["BarCode"].ToString();
				txtFrameOwner.Text = r["OwnerName"].ToString();
				txtFrameGoodState.Text = r["GoodStateName"].ToString();
				chkStereo.Checked = (bool)r["Stereo"];
				bResult = (oFrame.ErrorNumber == 0);
			}
			if (bResult)
			{
				// ячейка-источник
				oCellSource.ID = (int)r["CellID"];
				oCellSource.FillData(); 
				DataRow rcs = oCellSource.MainTable.Rows[0];
				if (rcs == null)
				{
					WMSMessage.MessageBoxError("Не найдена ячейка, в которой находится контейнер...");
					bResult = false;
				}
				else
				{
					cboCellSourceAddress.SelectedValue = oCellSource.ID;
					cboStoresZonesSource.SelectedValue = (int)rcs["StoreZoneID"];
					cboStoresZonesTypesSource.SelectedValue = (int)rcs["StoreZoneTypeID"];
					if (rcs["BufferCellID"] == DBNull.Value)
					{
						oBufferCellSource.ID = null;
						cboBufferCellSourceAddress.SelectedIndex = -1;
					}
					else
					{
						oBufferCellSource.ID = (int)rcs["BufferCellID"];
						oBufferCellSource.FillData();
					}
				}
			}

			if (bResult)
			{
				bResult = cboCellSourceAddress_Restore() &&
						  cboBufferCellSourceAddress_Restore();
			}

			WaitOff(this);
			return (bResult);
		}

	#endregion

	#region Выбор контейнера 

		private void txtFrameID4_TextChanged(object sender, EventArgs e)
		{
			if (txtFrameID4.Text.Length == 4)
			{ 
				// ищем подходящий контейнер
				Frame oFrameTemp = new Frame();
				oFrameTemp.FilterActual = true;
				oFrameTemp.FilterHasFrameContent = true;
				oFrameTemp.FillData();
				if (oFrameTemp.MainTable.Rows.Count > 0)
				{
					for (int i = oFrameTemp.MainTable.Rows.Count - 1; i >= 0; i--)
					{
						DataRow r = oFrameTemp.MainTable.Rows[i];
						if (r["BarCode"].ToString().EndsWith(txtFrameID4.Text.Trim()))
						{
							oFrameTemp.ID = Convert.ToInt32(r["ID"]);
							break;
						}
					}
				}
				if (oFrameTemp.ID == null)
				{
					WMSMessage.MessageBoxError("Нет доступных контейнеров с таким кодом...");
					txtFrameBarCode.Text = txtFrameID4.Text = "";
					return;
				}
				else
				{
					oFrame.ID = oFrameTemp.ID;
					FrameChoose();
				}
			}
		}

		private void txtFrameBarCode_Validating(object sender, CancelEventArgs e)
		{
			if (txtFrameBarCode.Text.Length > 0)
			{
				Frame oFrameTemp = new Frame();
				oFrameTemp.FilterActual = true;
				oFrameTemp.FilterHasFrameContent = true;
				oFrameTemp.FillData();
				if (oFrameTemp.MainTable.Rows.Count > 0)
				{
					for (int i = oFrameTemp.MainTable.Rows.Count - 1; i >= 0; i--)
					{
						DataRow r = oFrameTemp.MainTable.Rows[i];
						if (r["BarCode"].ToString().Contains(txtFrameBarCode.Text.Trim()))
						{
							oFrameTemp.ID = Convert.ToInt32(r["ID"]);
							break;
						}
					}
				}
				if (oFrameTemp.ID == null)
				{
					WMSMessage.MessageBoxError("Нет доступных контейнеров с таким кодом...");
					txtFrameBarCode.Text = txtFrameID4.Text = "";
					return;
				}
				else
				{
					oFrame.ID = oFrameTemp.ID;
					FrameChoose();
				}
			}
		}

		private void txtFrameBarCode_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				txtFrameBarCode_Validating(null, null);
		}

	#endregion 

	#region Выбор ячейки

		private void optCellTarget_CheckedChanged(object sender, EventArgs e)
		{
			cboCellTargetAddress.Enabled = optCellTarget.Checked;
		}

		private void cboStoresZonesTarget_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboStoresZonesTarget.SelectedIndex <= 0)
			{
				cboStoresZonesTypesTarget.SelectedIndex = -1;
				cboCellTargetAddress.SelectedIndex =
				cboBufferCellTargetAddress.SelectedIndex = -1;
				cboBufferCellTargetAddress.Enabled =
				cboCellTargetAddress.Enabled = false;
				return;
			}

			DataRow zt = oStoreZoneTarget.MainTable.Rows.Find(cboStoresZonesTarget.SelectedValue);
			if (zt != null)
			{
				cboStoresZonesTypesTarget.SelectedValue = (int)zt["StoreZoneTypeID"];
				// перевывести список ячеек этой зоны
				oCellTarget.FilterStoresZonesList = cboStoresZonesTarget.SelectedValue.ToString();
				cboCellTargetAddress_Restore();
				cboCellTargetAddress.SelectedIndex = -1;
			}
		}

		private void cboCellTargetAddress_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboCellTargetAddress.SelectedValue == null || cboCellTargetAddress.SelectedIndex < 0)
			{
				cboBufferCellTargetAddress.SelectedIndex = -1;
			}
			else
			{
				DataRow ct = oCellTarget.MainTable.Rows.Find((int)cboCellTargetAddress.SelectedValue);
				if (ct == null)
				{
					WMSMessage.MessageBoxError("Не найдена запись для ячейки-приемника с кодом " + ct["ID"].ToString() + "...");
					cboCellTargetAddress.SelectedIndex =
					cboBufferCellTargetAddress.SelectedIndex = -1;
				}
				else
				{
					if (ct["BufferCellID"] != DBNull.Value)
					{
						oBufferCellTarget.ID = (int)ct["BufferCellID"];
						cboBufferCellTargetAddress_Restore();
						cboBufferCellTargetAddress.SelectedValue = oBufferCellTarget.ID;
					}
					else
					{
						cboBufferCellTargetAddress.SelectedIndex = -1;
					}
				}
			}
		}

		#endregion

	}
}