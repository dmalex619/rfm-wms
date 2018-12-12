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
	public partial class frmCellsGeometryEdit : RFMFormChild
	{
		private Cell oCell = new Cell();
		
		private Good oGood = new Good();

		protected bool _bLoaded = false; 


		public frmCellsGeometryEdit(Cell oCellGeometry)
		{
			InitializeComponent();

			oCell = oCellGeometry;
		}

		
		private void frmCellsGeometryEdit_Load(object sender, EventArgs e)
		{
			//  ���������� cbo-��������������� 
			bool lResult = cboPalletsTypes_Restore();
			if (!lResult)
			{
				RFMMessage.MessageBoxError("������ ��� ���������� ��������������� (��������� ������)...");
				return;
			}

			DataRow r = oCell.MainTable.Rows[0];
			if (r == null)
			{
				RFMMessage.MessageBoxError("�� ������� ������ ��� ������ � ����� " + r["ID"].ToString() + " � ������� �����...");
				return;
			}

			// ��������� �������� �� ������ ������

			if (r["PalletTypeID"].Equals(DBNull.Value))
			{
				cboPalletsTypes.SelectedIndex = -1;
				txtPalletsTypes.Text = "_�� �������";
			}
			else
			{
				cboPalletsTypes.SelectedValue = r["PalletTypeID"];
			}

			if (r["MaxWeight"].Equals(DBNull.Value))
			{
				numMaxWeight.Value = 0;
				numMaxWeight.IsNull = true;
				txtMaxWeight.Text = "_�� ����������";
			}
			else
			{
				numMaxWeight.Value = (decimal)r["MaxWeight"];
			}

			if (r["CellWidth"].Equals(DBNull.Value))
			{
				numCellWidth.Value = 0;
				numCellWidth.IsNull = true;
				txtCellWidth.Text = "_�� ����������";
			}
			else
			{
				numCellWidth.Value = (decimal)r["CellWidth"];
			}

			if (r["CellHeight"].Equals(DBNull.Value))
			{
				numCellHeight.Value = 0;
				numCellHeight.IsNull = true;
				txtCellHeight.Text = "_�� ����������";
			}
			else
			{
				numCellHeight.Value = (decimal)r["CellHeight"];
			}

			if (r["MaxPalletQnt"].Equals(DBNull.Value))
			{
				numMaxPalletQnt.Value = 0;
				numMaxPalletQnt.IsNull = true;
				txtMaxPalletQnt.Text = "_�� ����������";
			}
			else
			{
				numMaxPalletQnt.Value = (decimal)r["MaxPalletQnt"];
			}

			if (r["StoreZoneMaxPalletQnt"].Equals(DBNull.Value))
			{
				numStoreZoneMaxPalletQnt.Value = 0;
				numStoreZoneMaxPalletQnt.IsNull = true;
				txtStoreZoneMaxPalletQnt.Text = "_�� ����������";
			}
			else
			{
				numStoreZoneMaxPalletQnt.Value = (decimal)r["StoreZoneMaxPalletQnt"];
			}

			// -------
			if (oCell.MainTable.Rows.Count == 1)
			{
				// ������� ���� ������
				txtBarCode.Text = r["BarCode"].ToString();
				txtCellID.Text  = r["ID"].ToString();
				txtAddress.Text = r["Address"].ToString();

				chkPalletsTypes.Visible = false;
				chkMaxWeight.Visible = false;
				chkCellWidth.Visible = false;
				chkCellHeight.Visible = false;
				chkMaxPalletQnt.Visible = false;
			}
			else
			{ 
				// ������� ��������� �����
				txtBarCode.Text = "";
				txtCellID.Text  = "";
				txtAddress.Text = "������� �����: " + oCell.MainTable.Rows.Count.ToString();

				foreach (DataRow rx in oCell.MainTable.Rows)
				{
					if (cboPalletsTypes.SelectedIndex == -1 && !rx["PalletTypeID"].Equals(DBNull.Value) ||
						cboPalletsTypes.SelectedIndex >= 0 && rx["PalletTypeID"].Equals(DBNull.Value) ||
						cboPalletsTypes.SelectedIndex >= 0 && ((int)cboPalletsTypes.SelectedValue != (int)rx["PalletTypeID"]))
					{
						cboPalletsTypes.SelectedIndex = -1;
						txtPalletsTypes.Text = "...������ ��������...";
					}
					
					if (numMaxWeight.Value != (decimal)rx["MaxWeight"])
					{
						numMaxWeight.Value = 0;
						txtMaxWeight.Text = "...������ ��������....";
					}
					
					if (numCellWidth.Value != (decimal)rx["CellWidth"])
					{
						numCellWidth.Value = 0;
						txtCellWidth.Text = "...������ ��������....";
					}
					
					if (numCellHeight.Value != (decimal)rx["CellHeight"])
					{
						numCellHeight.Value = 0;
						txtCellHeight.Text = "...������ ��������....";
					}

					if (numMaxPalletQnt.Value == 0 && numMaxPalletQnt.IsNull && !rx["MaxPalletQnt"].Equals(DBNull.Value) ||
						numMaxPalletQnt.Value != 0 && rx["MaxPalletQnt"].Equals(DBNull.Value) ||
						numMaxPalletQnt.Value != 0 && numMaxPalletQnt.Value != (Decimal)rx["MaxPalletQnt"])
					{
						numMaxPalletQnt.Value = 0;
						txtMaxPalletQnt.Text = "...������ ��������....";
					}
					
					if (numStoreZoneMaxPalletQnt.Value == 0 && numStoreZoneMaxPalletQnt.IsNull && !rx["StoreZoneMaxPalletQnt"].Equals(DBNull.Value) ||
						numStoreZoneMaxPalletQnt.Value != 0 && rx["StoreZoneMaxPalletQnt"].Equals(DBNull.Value) ||
						numStoreZoneMaxPalletQnt.Value != 0 && numStoreZoneMaxPalletQnt.Value != (Decimal)rx["StoreZoneMaxPalletQnt"])
					{
						numStoreZoneMaxPalletQnt.Value = 0;
						txtStoreZoneMaxPalletQnt.Text = "...������ ��������....";
					}
				}

				chkMaxWeight_CheckedChanged(null, null);
				chkPalletsTypes_CheckedChanged(null, null);
				chkCellWidth_CheckedChanged(null, null);
				chkCellHeight_CheckedChanged(null, null);
				chkMaxPalletQnt_CheckedChanged(null, null);
			}

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
			bool? bMaxWeightUpdate = false;
			bool? bPalletTypeIDUpdate = false;
			bool? bCellWidthUpdate = false;
			bool? bCellHeightUpdate = false;
			bool? bMaxPalletQntUpdate = false; 

			if (oCell.MainTable.Rows.Count == 1)
			{
				// ���� ������
				bMaxWeightUpdate = bPalletTypeIDUpdate = 
				bCellWidthUpdate = bCellHeightUpdate = 
				bMaxPalletQntUpdate = true;
			}
			else
			{
				// ��������� �����, ��� ������
				bPalletTypeIDUpdate = chkPalletsTypes.Checked	&& (txtPalletsTypes.Text.Trim().Length == 0	|| txtPalletsTypes.Text.Substring(0, 3) != "...");
				bMaxWeightUpdate	= chkMaxWeight.Checked		&& (txtMaxWeight.Text.Trim().Length == 0	|| txtMaxWeight.Text.Substring(0, 3) != "...");
				bCellWidthUpdate	= chkCellWidth.Checked		&& (txtCellWidth.Text.Trim().Length == 0	|| txtCellWidth.Text.Substring(0, 3) != "...");
				bCellHeightUpdate	= chkCellHeight.Checked		&& (txtCellHeight.Text.Trim().Length == 0	|| txtCellHeight.Text.Substring(0, 3) != "...");
				bMaxPalletQntUpdate = chkMaxPalletQnt.Checked	&& (txtMaxPalletQnt.Text.Trim().Length == 0	|| txtMaxPalletQnt.Text.Substring(0, 3) != "...");
			}
			foreach (DataRow rx in oCell.MainTable.Rows)
			{
				rx["PalletTypeID"] = (cboPalletsTypes.SelectedValue == null || (int)cboPalletsTypes.SelectedIndex < 0 ? DBNull.Value : cboPalletsTypes.SelectedValue);

				if (numMaxWeight.IsNull && numMaxWeight.Value == 0)
					rx["MaxWeight"] = DBNull.Value;
				else
					rx["MaxWeight"] = numMaxWeight.Value;
				
				if (numCellWidth.IsNull && numCellWidth.Value == 0)
					rx["CellWidth"] = DBNull.Value; 
				else
					rx["CellWidth"] = numCellWidth.Value;
				
				if (numCellHeight.IsNull && numCellHeight.Value == 0)
					rx["CellHeight"] = DBNull.Value;
				else
					rx["CellHeight"] = numCellHeight.Value;

				if (numMaxPalletQnt.IsNull && numMaxPalletQnt.Value == 0) 
					rx["MaxPalletQnt"] = DBNull.Value;
				else
					rx["MaxPalletQnt"] = numMaxPalletQnt.Value;

				oCell.GeometrySave((int)rx["ID"], bMaxWeightUpdate, bPalletTypeIDUpdate, bCellWidthUpdate, bCellHeightUpdate, bMaxPalletQntUpdate);

			}
			if (oCell.ErrorNumber == 0)
			{
				DialogResult = DialogResult.Yes;
				Dispose();
			}
		}

	#region Restore

		private bool cboPalletsTypes_Restore()
		{
			oGood.FillTablePalletsTypes();
			cboPalletsTypes.ValueMember = oGood.TablePalletsTypes.Columns[0].Caption;
			cboPalletsTypes.DisplayMember = oGood.TablePalletsTypes.Columns[1].Caption;
			cboPalletsTypes.DataSource = oGood.TablePalletsTypes;
			return (oGood.ErrorNumber == 0);
		}

	#endregion

	#region ����� ����� ���������� � Null (��� �������, ����� �������� � ������) 
		
		private void btnPalletsTypesClear_Click(object sender, EventArgs e)
		{
			cboPalletsTypes.SelectedIndex = -1;
			txtPalletsTypes.Text = "_�� �������";
		}

		private void btnMaxPalletQntClear_Click(object sender, EventArgs e)
		{
			numMaxPalletQnt.Value = 0;
			numMaxPalletQnt.IsNull = true; 
			txtMaxPalletQnt.Text = "_�� ����������";
		}

	#endregion

	#region ��������� �������� ��� ������������� ������ �����
		
		private void chkMaxWeight_CheckedChanged(object sender, EventArgs e)
		{
			numMaxWeight.Enabled = chkMaxWeight.Checked;
		}

		private void chkPalletsTypes_CheckedChanged(object sender, EventArgs e)
		{
			cboPalletsTypes.Enabled = btnPalletsTypesClear.Enabled = chkPalletsTypes.Checked;
		}

		private void chkCellWidth_CheckedChanged(object sender, EventArgs e)
		{
			numCellWidth.Enabled = chkCellWidth.Checked;
		}

		private void chkCellHeight_CheckedChanged(object sender, EventArgs e)
		{
			numCellHeight.Enabled = chkCellHeight.Checked;
		}

		private void chkMaxPalletQnt_CheckedChanged(object sender, EventArgs e)
		{
			numMaxPalletQnt.Enabled = btnMaxPalletQntClear.Enabled = chkMaxPalletQnt.Checked;
		}

	#endregion

	#region ��������� ��������

		private void cboPalletsTypes_SelectedIndexChanged(object sender, EventArgs e)
		{
			// ����� ������ ������ � ������������ � ������� �������
			if (!_bLoaded)
				return;

			if (cboPalletsTypes.SelectedIndex >= 0)
			{
				if (oCell.MainTable.Rows.Count == 1)
				{
					// ���� ������
					numCellWidth.Value = (decimal)oGood.TablePalletsTypes.Rows.Find((int)cboPalletsTypes.SelectedValue)["PalletWidth"];
				}
				else
				{
					// ��������� �����
					if (RFMMessage.MessageBoxYesNo("�������� ������ � ������ ������ � ������������ � ������� �������?") == DialogResult.Yes)
					{
						chkCellWidth.Checked = true;
						numCellWidth.Value = (decimal)oGood.TablePalletsTypes.Rows.Find((int)cboPalletsTypes.SelectedValue)["PalletWidth"];
					}
				}
				txtPalletsTypes.Text = "";
			}

		}

		private void numMaxWeight_ValueChanged(object sender, EventArgs e)
		{
			if (numMaxWeight.Value > 0)
			{
				numMaxWeight.IsNull = false;
				txtMaxWeight.Text = "";
			}
		}

		private void numCellWidth_ValueChanged(object sender, EventArgs e)
		{
			if (numCellWidth.Value > 0)
			{
				numCellWidth.IsNull = false;
				txtCellWidth.Text = "";
			}
		}

		private void numCellHeight_ValueChanged(object sender, EventArgs e)
		{
			if (numCellHeight.Value > 0)
			{
				numCellHeight.IsNull = false;
				txtCellHeight.Text = "";
			}
		}

		private void numMaxPalletQnt_ValueChanged(object sender, EventArgs e)
		{
			if (numMaxPalletQnt.Value > 0)
			{
				numMaxPalletQnt.IsNull = false;
				txtMaxPalletQnt.Text = "";
			}
		}

		private void txtField_TextChanged(object sender, EventArgs e)
		{
			// �� ���.
			((TextBox)sender).Visible = (((TextBox)sender).Text.Length > 0);
		}

	#endregion

	}
}