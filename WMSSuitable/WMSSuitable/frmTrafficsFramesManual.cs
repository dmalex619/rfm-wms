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
	public partial class frmTrafficsFramesManual : RFMFormChild
	{
		protected TrafficFrame oTraffic;

		protected Frame oFrame;
	
		protected Cell oCellSource;
		protected Cell oBufferCellSource;
		protected StoreZone oStoreZoneSource;
		
		protected Cell oCellTarget;
		protected Cell oBufferCellTarget;
		protected StoreZone oStoreZoneTarget;
		
		protected bool _bLoaded = false;

		public frmTrafficsFramesManual(int? nFrameID)
		{
			oTraffic = new TrafficFrame();
			oFrame = new Frame();
			oCellSource = new Cell();
			oBufferCellSource = new Cell();
			oStoreZoneSource = new StoreZone();
			oCellTarget = new Cell();
			oBufferCellTarget = new Cell();
			oStoreZoneTarget = new StoreZone();

			if (oTraffic.ErrorNumber != 0 ||
				oFrame.ErrorNumber != 0 ||
				oCellSource.ErrorNumber != 0 ||
				oBufferCellSource.ErrorNumber != 0 ||
				oStoreZoneSource.ErrorNumber != 0 ||
				oCellTarget.ErrorNumber != 0 ||
				oBufferCellTarget.ErrorNumber != 0 ||
				oStoreZoneTarget.ErrorNumber != 0)
			{
				IsValid = false;
			}

			if (IsValid)
			{
				InitializeComponent();
				oFrame.ID = nFrameID;
			}
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
			{
				_bLoaded = true;
				optCellTarget_CheckedChanged(null, null);
			}
			else
			{
				DialogResult = DialogResult.No;
				Dispose();
			}
			txtFrameOwner.Enabled = 
			cboBufferCellSourceAddress.Enabled =
			cboStoresZonesSource.Enabled =
			cboBufferCellTargetAddress.Enabled =
			cboStoresZonesTypesSource.Enabled =
			cboStoresZonesTypesTarget.Enabled =	false;
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
			int? nCellTargetID = null;
			bool bFrameDestroy = chkFrameDestroy.Checked;
			int nPriority = (int)numPriority.Value;
			string sMessage = "Создать операции для транспортировки контейнера\n";
			if (optCellTarget.Checked)
			{
				if (cboCellTargetAddress.SelectedIndex < 0)
				{
					RFMMessage.MessageBoxError("Не выбрана ячейка...");
					return;
				}
				nCellTargetID = (int)cboCellTargetAddress.SelectedValue;
				if (nCellTargetID == (int)cboCellSourceAddress.SelectedValue)
				{
					RFMMessage.MessageBoxError("Выбрана та же ячейка...");
					return;
				}
				sMessage += "в ячейку " + cboCellTargetAddress.Text;
			}
			else
			{
				sMessage += "в подходящую ячейку длительного хранения";
			}
			if (bFrameDestroy)
			{
				sMessage += "\n" + "(при выполнении операции контейнер будет разобран)";
			}
			sMessage += "?";

			if (RFMMessage.MessageBoxYesNo(sMessage) == DialogResult.Yes)
			{
				oTraffic.ClearError();
				oTraffic.CreateManual((int)oFrame.ID, nCellTargetID, nPriority, bFrameDestroy);

				if (oTraffic.ErrorNumber == 0)
				{
					//RFMMessage.MessageBoxInfo("Создано задание на транспортировку поддона.");
					DialogResult = DialogResult.Yes;
					Dispose();
				}
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
			oCellTarget.ClearError();
			oCellTarget.ClearFilters();

			if (cboStoresZonesTarget.SelectedIndex < 0)
			{
				cboCellTargetAddress.Enabled = 
				chkFrameDestroy.Enabled = false;
				cboCellTargetAddress.DataSource = null;
				return (false);
			}
			oCellTarget.ID = null;
			oCellTarget.FilterActual = true;
			oCellTarget.FilterLocked = false;
			oCellTarget.FilterStoresZonesList = cboStoresZonesTarget.SelectedValue.ToString();
			oCellTarget.FilterForFrames = !chkFrameDestroy.Checked;
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

			oFrame.ClearError();
			oFrame.FillData();
			DataRow r = oFrame.MainTable.Rows[0];
			if (r == null)
			{
				RFMMessage.MessageBoxError("Не найдена запись для контейнера с кодом " + r["ID"].ToString() + "...");
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
				if (Convert.IsDBNull(r["CellID"]))
				{
					RFMMessage.MessageBoxError("Не опеределена ячейка, в которой находится контейнер...");
					bResult = false;
				}

				if (bResult)
				{
					oCellSource.ID = Convert.ToInt32(r["CellID"]);
					oCellSource.FillData();
					DataRow rcs = oCellSource.MainTable.Rows[0];
					if (rcs == null)
					{
						RFMMessage.MessageBoxError("Не найдена ячейка, в которой находится контейнер...");
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
				string sBarCodeEnd = txtFrameID4.Text.Trim();
				oFrameTemp.BarCode = sBarCodeEnd;
				oFrameTemp.FilterActual = true;
				oFrameTemp.FilterHasFrameContent = true;
				//oFrameTemp.FilterFramesStatesStr = "S"; 
				oFrameTemp.FillData();
				if (oFrameTemp.MainTable.Rows.Count > 0)
				{
					if (oFrameTemp.MainTable.Rows.Count == 1)
					{
						if (oFrameTemp.MainTable.Rows[0]["BarCode"].ToString().EndsWith(sBarCodeEnd))
							oFrameTemp.ID = Convert.ToInt32(oFrameTemp.MainTable.Rows[0]["ID"]);
					}
					else
					{
						DataView dvTemp = new DataView(oFrameTemp.MainTable);
						dvTemp.RowFilter = "substring(BarCode, len(BarCode) - " + sBarCodeEnd.Length.ToString() + " + 1, " + sBarCodeEnd.Length.ToString() + ") = '" + sBarCodeEnd + "'";
						DataTable dtTemp = dvTemp.ToTable();
						if (dtTemp.Rows.Count > 1)
						{
							RFMMessage.MessageBoxAttention("Внимание!\n\n" +
								"Найдено несколько актуальных контейнеров с указанным окончанием штрих-кода " +
								"(" + dtTemp.Rows.Count.ToString() + ")");
							// подставляем последний
							oFrameTemp.ID = Convert.ToInt32(dtTemp.Rows[dtTemp.Rows.Count - 1]["ID"]);
						}
					}
				}
				if (oFrameTemp.ID == null)
				{
					RFMMessage.MessageBoxError("Нет доступных контейнеров с таким кодом...");
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
					RFMMessage.MessageBoxError("Нет доступных контейнеров с таким кодом...");
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
			cboStoresZonesTarget.Enabled = 
			cboCellTargetAddress.Enabled = 
			chkFrameDestroy.Enabled =
				optCellTarget.Checked;
			cboStoresZonesTarget.SelectedValue = 
			cboBufferCellTargetAddress.SelectedValue = -1;	
		}

		private void cboStoresZonesTarget_SelectionChangeCommited(object sender, EventArgs e)
		{
			if (cboStoresZonesTarget.SelectedIndex < 0)
			{
				cboCellTargetAddress.SelectedIndex =
				cboBufferCellTargetAddress.SelectedIndex = 
				cboStoresZonesTypesTarget.SelectedIndex = -1;
				cboCellTargetAddress.Enabled = 
				cboBufferCellTargetAddress.Enabled =
				cboStoresZonesSource.Enabled = false;
				return;
			}

			DataRow zt = oStoreZoneTarget.MainTable.Rows.Find(cboStoresZonesTarget.SelectedValue);
			if (zt != null)
			{
				cboStoresZonesTypesTarget.SelectedValue = (int)zt["StoreZoneTypeID"];
				// перевывести список ячеек этой зоны
				cboCellTargetAddress_Restore();
				cboCellTargetAddress.SelectedIndex = -1;
			}
		}

		private void chkFrameDestroy_CheckedChanged(object sender, EventArgs e)
		{
			cboStoresZonesTarget_SelectionChangeCommited(null, null);
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
					RFMMessage.MessageBoxError("Не найдена запись для ячейки-приемника с кодом " + ct["ID"].ToString() + "...");
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

		private void txtFrameBarCode_TextChanged(object sender, EventArgs e)
		{

		}

	}
}