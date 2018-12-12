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
	public partial class frmCellsFixedEdit : RFMFormChild
	{
		private Cell oCell = new Cell();
		
		private Partner oOwner = new Partner();
		private GoodState oGoodState = new GoodState();
		private Good oPacking = new Good();

		public int? _SelectedPackingID;

		protected bool _bLoaded = false;
		
		public frmCellsFixedEdit(Cell oCellFixed)
		{
			InitializeComponent();

			oCell = oCellFixed;
		}

		
		private void frmCellsFixedEdit_Load(object sender, EventArgs e)
		{
			//  заполнение cbo-классификаторов 
			bool lResult = cboOwners_Restore() &&
							  cboGoodsStates_Restore() &&
							  cboPackings_Restore();
			if (!lResult)
			{
				RFMMessage.MessageBoxError("Ошибка при заполнении классификаторов (фиксированные закрепления ячейки)...");
				return;
			}

			DataRow r = oCell.MainTable.Rows[0];
			if (r == null)
			{
				RFMMessage.MessageBoxError("Не найдена запись для ячейки с кодом " + r["ID"].ToString() + " в таблице ячеек...");
				return;
			}

			// заполняем элементы по первой ячейке

			if (r["FixedOwnerID"].Equals(DBNull.Value))
			{
				cboOwners.SelectedIndex = -1;
				txtOwners.Text = "_Нет закрепления";
			}
			else
			{
				cboOwners.SelectedValue = Convert.ToInt32(r["FixedOwnerID"]);
			}

			if (r["FixedGoodStateID"].Equals(DBNull.Value))
			{
				cboGoodsStates.SelectedIndex = -1;
				txtGoodsStates.Text = "_Нет закрепления";
			}
			else
			{
				cboGoodsStates.SelectedValue = Convert.ToInt32(r["FixedGoodStateID"]);
			}

			if (r["FixedPackingID"].Equals(DBNull.Value))
			{
				cboPackings.SelectedIndex = -1;
				txtPackingAlias.Text = "";
				txtPackings.Text = "_Нет закрепления";
			}
			else
			{
				cboPackings.SelectedValue = Convert.ToInt32(r["FixedPackingID"]);
				txtPackingAlias.Text = r["GoodAlias"].ToString();
			}

			// -------
			if (oCell.MainTable.Rows.Count == 1)
			{
				// выбрана одна ячейка
				txtBarCode.Text = r["BarCode"].ToString();
				txtCellID.Text  = r["ID"].ToString();
				txtAddress.Text = r["Address"].ToString();

				chkOwners.Visible = false;
				chkGoodsStates.Visible = false;
				chkPackings.Visible = false;

				btnPackingsChoose.Left = txtPackingAlias.Left - btnPackingsChoose.Width - 5;
			}
			else
			{ 
				// выбрано несколько ячеек
				txtBarCode.Text = "";
				txtCellID.Text  = "";
				txtAddress.Text = "Выбрано ячеек: " + oCell.MainTable.Rows.Count.ToString();

				foreach (DataRow rx in oCell.MainTable.Rows)
				{
					if (cboOwners.SelectedIndex == -1 && !rx["FixedOwnerID"].Equals(DBNull.Value) ||
						cboOwners.SelectedIndex >= 0 && rx["FixedOwnerID"].Equals(DBNull.Value) ||
						cboOwners.SelectedIndex >= 0 && ((int)cboOwners.SelectedValue != (int)rx["FixedOwnerID"]))
					{
						cboOwners.SelectedIndex = -1;
						txtOwners.Text = "...разные значения...";
					}
					
					if (cboGoodsStates.SelectedIndex == -1 && !rx["FixedGoodStateID"].Equals(DBNull.Value) ||
						cboGoodsStates.SelectedIndex >= 0 && rx["FixedGoodStateID"].Equals(DBNull.Value) ||
						cboGoodsStates.SelectedIndex >= 0 && ((int)cboGoodsStates.SelectedValue != (int)rx["FixedGoodStateID"]))
					{
						cboGoodsStates.SelectedIndex = -1;
						txtGoodsStates.Text = "...разные значения...";
					}
					
					if (cboPackings.SelectedIndex == -1 && !rx["FixedPackingID"].Equals(DBNull.Value) ||
						cboPackings.SelectedIndex >= 0 && rx["FixedPackingID"].Equals(DBNull.Value) ||
						cboPackings.SelectedIndex >= 0 && ((int)cboPackings.SelectedValue != (int)rx["FixedPackingID"]))
					{
						cboPackings.SelectedIndex = -1;
						txtPackingAlias.Text = "";
						txtPackings.Text = "...разные значения...";
					}
				}

				chkOwners_CheckedChanged(null, null);
				chkGoodsStates_CheckedChanged(null, null);
				chkPackings_CheckedChanged(null, null);
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
			bool? bFixedOwnerIDUpdate = false;
			bool? bFixedGoodStateIDUpdate = false;
			bool? bFixedPackingIDUpdate = false;

			if (oCell.MainTable.Rows.Count == 1)
			{
				// одна ячейка
				bFixedOwnerIDUpdate = bFixedGoodStateIDUpdate = bFixedPackingIDUpdate = true;
			}
			else
			{
				// несколько ячеек, для каждой
				bFixedOwnerIDUpdate		= chkOwners.Checked		 && (txtOwners.Text.Trim().Length == 0		|| txtOwners.Text.Substring(0, 3) != "...");
				bFixedGoodStateIDUpdate = chkGoodsStates.Checked && (txtGoodsStates.Text.Trim().Length == 0 || txtGoodsStates.Text.Substring(0, 3) != "...");
				bFixedPackingIDUpdate	= chkPackings.Checked	 && (txtPackings.Text.Trim().Length == 0	|| cboPackings.Text.Substring(0, 3) != "...");
			}
			foreach (DataRow rx in oCell.MainTable.Rows)
			{
				rx["FixedOwnerID"]		= (cboOwners.SelectedValue == null		|| (int)cboOwners.SelectedIndex < 0		 ? DBNull.Value : cboOwners.SelectedValue);
				rx["FixedGoodStateID"]	= (cboGoodsStates.SelectedValue == null || (int)cboGoodsStates.SelectedIndex < 0 ? DBNull.Value : cboGoodsStates.SelectedValue);
				rx["FixedPackingID"]	= (cboPackings.SelectedValue == null	|| (int)cboPackings.SelectedIndex < 0	 ? DBNull.Value : cboPackings.SelectedValue);

				oCell.FixedSave((int)rx["ID"], bFixedOwnerIDUpdate, bFixedGoodStateIDUpdate, bFixedPackingIDUpdate);
			}
			if (oCell.ErrorNumber == 0)
			{
				DialogResult = DialogResult.Yes;
				Dispose();
			}
		}

	#region Restore
	
		private bool cboOwners_Restore()
		{
			oOwner.FilterOwner = true;
			oOwner.FilterSeparatePicking = true;
			oOwner.FillData();
			cboOwners.ValueMember = oOwner.ColumnID;
			cboOwners.DisplayMember = oOwner.ColumnName;
			cboOwners.DataSource = oOwner.MainTable;
			return (oOwner.ErrorNumber == 0);
		}
		
		private bool cboGoodsStates_Restore()
		{
			oGoodState.FillData();
			cboGoodsStates.ValueMember = oGoodState.ColumnID;
			cboGoodsStates.DisplayMember = oGoodState.ColumnName;
			cboGoodsStates.DataSource = oGoodState.MainTable;
			return (oGoodState.ErrorNumber == 0);
		}

		private bool cboPackings_Restore()
		{
			oPacking.FillData();
			cboPackings.ValueMember = oPacking.MainTable.Columns["PackingID"].Caption;
			cboPackings.DisplayMember = oPacking.MainTable.Columns["PackingAlias"].Caption;
			cboPackings.DataSource = oPacking.MainTable;
			return (oPacking.ErrorNumber == 0);
		}

		private void btnPackingsChoose_Click(object sender, EventArgs e)
		{
			_SelectedPackingID = null;
			if (StartForm(new frmSelectOnePacking(this)) == DialogResult.Yes)
			{
				if (_SelectedPackingID != null)
				{
					cboPackings.SelectedValue = _SelectedPackingID.ToString();
					txtPackingAlias.Text = cboPackings.Text;
				}
			}
		}
	
	#endregion

	#region Сброс закрепления в Null
		
		private void btnOwnersClear_Click(object sender, EventArgs e)
		{
			cboOwners.SelectedIndex = -1;
			txtOwners.Text = "_Нет закрепления";
		}
		private void btnGoodsStatesClear_Click(object sender, EventArgs e)
		{
			cboGoodsStates.SelectedIndex = -1;
			txtGoodsStates.Text = "_Нет закрепления";
		}
		private void btnPackingsClear_Click(object sender, EventArgs e)
		{
			cboPackings.SelectedIndex = -1;
			txtPackingAlias.Text = "";
			txtPackings.Text = "_Нет закрепления";
			_SelectedPackingID = null;
		}
	
	#endregion

	#region Включение элеметов при множественном выборе ячеек

		private void chkOwners_CheckedChanged(object sender, EventArgs e)
		{
			cboOwners.Enabled = btnOwnersClear.Enabled = chkOwners.Checked;
		}

		private void chkGoodsStates_CheckedChanged(object sender, EventArgs e)
		{
			cboGoodsStates.Enabled = btnGoodsStatesClear.Enabled = chkGoodsStates.Checked;
		}

		private void chkPackings_CheckedChanged(object sender, EventArgs e)
		{
			btnPackingsClear.Enabled = btnPackingsChoose.Enabled = chkPackings.Checked;
		}
	
	#endregion

	#region Изменение значений

		private void cboOwners_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!_bLoaded)
				return;

			if (cboOwners.SelectedIndex >= 0)
			{
				txtOwners.Text = "";
			}
		}

		private void cboGoodsStates_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!_bLoaded)
				return;

			if (cboGoodsStates.SelectedIndex >= 0)
			{
				txtGoodsStates.Text = "";
			}
		}

		private void cboPackings_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!_bLoaded)
				return;

			if (cboPackings.SelectedIndex >= 0)
			{
				txtPackings.Text = "";
				txtPackingAlias.Text = cboPackings.Text;
			}
		}

		private void txtField_TextChanged(object sender, EventArgs e)
		{
			// не исп.
			((TextBox)sender).Visible = (((TextBox)sender).Text.Length > 0);
		}

	#endregion

	}
}