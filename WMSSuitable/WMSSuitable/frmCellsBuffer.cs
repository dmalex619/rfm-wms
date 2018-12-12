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
	public partial class frmCellsBuffer : RFMFormChild
	{
		private Cell oCell = new Cell();
		private Cell oCellBuffer = new Cell();
		private StoreZone oStoreZoneBuffer = new StoreZone();

		protected bool _bLoaded = false;
		
		public frmCellsBuffer(Cell oCellBuf)
		{
			InitializeComponent();

			oCell = oCellBuf;
		}
		
		private void frmCellsBuffer_Load(object sender, EventArgs e)
		{
			//  заполнение cbo-классификаторов 
			bool lResult =	cboCellAddressBuffer_Restore() && 
							cboStoresZonesBuffer_Restore() &&
							cboStoresZonesTypesBuffer_Restore();
			if (!lResult)
			{
				RFMMessage.MessageBoxError("ќшибка при заполнении классификаторов (складские зоны)...");
				return;
			}

			cboStoresZonesBuffer.SelectedIndex = -1;
			cboStoresZonesTypesBuffer.SelectedIndex = -1;
			cboCellAddressBuffer.SelectedIndex = -1;

			// заполнение формы данными
			if (oCell.MainTable.Rows.Count > 1)
			{
				txtBarCode.Text = "";
				txtCellID.Text  = "";
				txtAddress.Text = "¬ыбрано €чеек: " + oCell.MainTable.Rows.Count.ToString();
			}
			else
			{
				DataRow r = oCell.MainTable.Rows[0];
				txtBarCode.Text = r["BarCode"].ToString();
				txtCellID.Text  = r["ID"].ToString();
				txtAddress.Text = r["Address"].ToString();
				if (r["BufferCellID"] != DBNull.Value)
				{
					int nBufferCellID = (int)r["BufferCellID"];
					DataRow rb = oCellBuffer.MainTable.Rows.Find(nBufferCellID);
					if (rb != null)
					{
						cboStoresZonesBuffer.SelectedValue = (int)rb["StoreZoneID"];
						cboCellAddressBuffer.SelectedValue = nBufferCellID;
					}
				}
			}
			_bLoaded = true;
			cboStoresZonesTypesBuffer.Enabled = false;
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
			int? nCellBufferID;
			if (cboCellAddressBuffer.SelectedValue == null || cboCellAddressBuffer.SelectedIndex < 0)
			{
				if (RFMMessage.MessageBoxYesNo("Ќе выбрана буферна€ €чейка.\nќчистить указание на буферную €чейку?") == DialogResult.Yes)
				{
					nCellBufferID = null;
				}
				else
				{
					return;
				}
			}
			else
			{
				nCellBufferID = (int)cboCellAddressBuffer.SelectedValue;
			}

			bool bCellBufferUpdate = chkCellsBuffersUpdate.Checked;
			int nCellID;
			int nCnt = 0;

			// перебираем строки oCell
			foreach (DataRow r in oCell.MainTable.Rows)
			{
				nCellID = (int)r["ID"];
				oCell.SetBufferCell(nCellID, nCellBufferID, bCellBufferUpdate);
				if (oCell.ErrorNumber == 0)
					nCnt++;
			}
			if (nCnt > 0)
			{

				RFMMessage.MessageBoxInfo(((nCellBufferID.HasValue) ? "”становлена" : "ќчищена") + " буферна€ €чейка дл€ " + RFMUtilities.Declen(nCnt, "€чейки", "€чеек", "€чеек") + ".");
			}
			else
			{
				RFMMessage.MessageBoxInfo("Ѕуферна€ €чейка не " + ((nCellBufferID.HasValue) ? "установлена" : "очищена") + "...");
			}
	
			if (oCell.ErrorNumber == 0 && nCnt > 0)
			{
				DialogResult = DialogResult.Yes;
				Dispose();
			}
		}

	#region Restore

		private bool cboCellAddressBuffer_Restore()
		{
			oCellBuffer.FilterStoreZoneTypeShortCode = "BUF";
			oCellBuffer.FillData();
			cboCellAddressBuffer.ValueMember = oCellBuffer.MainTable.Columns[0].Caption;
			cboCellAddressBuffer.DisplayMember = oCellBuffer.MainTable.Columns["Address"].Caption;
			DataView dvwCellBuffer = new DataView(oCellBuffer.MainTable);
			cboCellAddressBuffer.DataSource = dvwCellBuffer; 
			return (oCellBuffer.ErrorNumber == 0);
		}

		private bool cboStoresZonesBuffer_Restore()
		{
			oStoreZoneBuffer.FilterStoreZoneTypeShortCode = "BUF";
			oStoreZoneBuffer.FillData();
			cboStoresZonesBuffer.ValueMember = oStoreZoneBuffer.MainTable.Columns[0].Caption;
			cboStoresZonesBuffer.DisplayMember = oStoreZoneBuffer.MainTable.Columns[1].Caption;
			cboStoresZonesBuffer.DataSource = oStoreZoneBuffer.MainTable;
			return (oStoreZoneBuffer.ErrorNumber == 0);
		}

		private bool cboStoresZonesTypesBuffer_Restore()
		{
			oStoreZoneBuffer.FillTableStoresZonesTypes();
			cboStoresZonesTypesBuffer.ValueMember = oStoreZoneBuffer.TableStoresZonesTypes.Columns[0].Caption;
			cboStoresZonesTypesBuffer.DisplayMember = oStoreZoneBuffer.TableStoresZonesTypes.Columns[1].Caption;
			cboStoresZonesTypesBuffer.DataSource = oStoreZoneBuffer.TableStoresZonesTypes;
			return (oStoreZoneBuffer.ErrorNumber == 0);
		}

	#endregion

		private void cboCellAddressBuffer_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboCellAddressBuffer.SelectedValue != null)
			{
				txtCellBuffer.Text = "";
			}
		}

		private void btnCellBufferClear_Click(object sender, EventArgs e)
		{
			cboStoresZonesTypesBuffer.SelectedIndex = -1; 
			cboCellAddressBuffer.SelectedIndex = -1;
			txtCellBuffer.Text = "_не выбрано";
		}

		private void cboStoresZonesBuffer_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboStoresZonesBuffer.SelectedIndex < 0)
			{
				cboStoresZonesTypesBuffer.SelectedIndex = -1;
				cboCellAddressBuffer.SelectedIndex = -1;
				return;
			}

			DataRow r = oStoreZoneBuffer.MainTable.Rows.Find(cboStoresZonesBuffer.SelectedValue);
			if (r != null)
			{
				cboStoresZonesTypesBuffer.SelectedValue = (int)r["StoreZoneTypeID"];

				// перевывести список €чеек этой зоны
				((DataView)cboCellAddressBuffer.DataSource).RowFilter = "StoreZoneID = " + cboStoresZonesBuffer.SelectedValue.ToString();
				cboCellAddressBuffer.SelectedIndex = -1;
			}
		}

	}
}