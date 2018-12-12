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
	public partial class frmFramesEdit : RFMFormChild
	{
		private Frame oFrame = new Frame();
		
		private Good oGood = new Good();

		protected bool _bLoaded = false;
		
		public frmFramesEdit(Frame oFrameEdit)
		{
			InitializeComponent();

			oFrame = oFrameEdit;
		}

		
		private void frmFramesEdit_Load(object sender, EventArgs e)
		{
			//  заполнение cbo-классификаторов 
			bool lResult = cboPalletsTypes_Restore();
			if (!lResult)
			{
				RFMMessage.MessageBoxError("Ошибка при заполнении классификаторов (геометрия контейнера)...");
				return;
			}

			DataRow r = oFrame.MainTable.Rows[0];
			if (r == null)
			{
				RFMMessage.MessageBoxError("Не найдена запись для контейнера с кодом " + r["ID"].ToString() + " в таблице контейнеров...");
				return;
			}

			// заполняем элементы по первой ячейке

			if (r["PalletTypeID"] == DBNull.Value)
			{
				cboPalletsTypes.SelectedIndex = -1;
			}
			else
			{
				cboPalletsTypes.SelectedValue = (int)r["PalletTypeID"];
			}

			if (r["FrameHeight"] == DBNull.Value)
			{
				numFrameHeight.Value = 0;
			}
			else
			{
				numFrameHeight.Value = Convert.ToDecimal(r["FrameHeight"]);
			}

			// -------
			if (oFrame.MainTable.Rows.Count == 1)
			{
				// выбран один контейнер
				txtBarCode.Text = r["BarCode"].ToString();
				txtFrameID.Text = r["ID"].ToString();
				txtCnt.Text = "Выбрано контейнеров: 1";

				chkPalletsTypes.Visible = false;
				chkFrameHeight.Visible = false;
			}
			else
			{ 
				// выбрано несколько контейнеров
				txtBarCode.Text = "";
				txtFrameID.Text = "";
				txtCnt.Text = "Выбрано контейнеров: " + oFrame.MainTable.Rows.Count.ToString();

				foreach (DataRow rx in oFrame.MainTable.Rows)
				{
					if (cboPalletsTypes.SelectedIndex == -1 && rx["PalletTypeID"] != DBNull.Value ||
						cboPalletsTypes.SelectedIndex >= 0 && rx["PalletTypeID"] == DBNull.Value ||
						cboPalletsTypes.SelectedIndex >= 0 && ((int)cboPalletsTypes.SelectedValue != (int)rx["PalletTypeID"]))
					{
						cboPalletsTypes.SelectedIndex = -1;
						txtPalletsTypes.Text = "...разные значения...";
					}

					if (numFrameHeight.Value != -1 && rx["FrameHeight"] != DBNull.Value ||
						numFrameHeight.Value >= 0 && rx["FrameHeight"] == DBNull.Value ||
						numFrameHeight.Value >= 0 && (numFrameHeight.Value != Convert.ToDecimal(rx["FrameHeight"])))
					{
						numFrameHeight.Value = 0;
						txtFrameHeight.Text = "...разные значения...";
					}
				}

				chkPalletsTypes_CheckedChanged (null, null);
				chkFrameHeight_CheckedChanged(null, null);
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
			if (cboPalletsTypes.Enabled && cboPalletsTypes.SelectedIndex < 0)
			{
				RFMMessage.MessageBoxError("Не выбран тип поддона...");
				return;
			}

			bool? bPalletTypeIDUpdate = null;
			bool? bFrameHeightUpdate = null;

			if (oFrame.MainTable.Rows.Count == 1)
			{
				// один контейнер
				bPalletTypeIDUpdate = bFrameHeightUpdate = true;
			}
			else
			{
				// несколько контейнеров, для каждого
				bPalletTypeIDUpdate = chkPalletsTypes.Checked && (txtPalletsTypes.Text.Trim().Length == 0 || txtPalletsTypes.Text.Substring(0, 3) != "...");
				bFrameHeightUpdate = chkFrameHeight.Checked && (numFrameHeight.Enabled && numFrameHeight.Value != 0 || txtFrameHeight.Text.Substring(0, 3) != "...");
			}
			foreach (DataRow rx in oFrame.MainTable.Rows)
			{
				rx["PalletTypeID"] = (int)cboPalletsTypes.SelectedValue;
				rx["FrameHeight"] = numFrameHeight.Value; ;

				oFrame.GeometrySave((int)rx["ID"], bPalletTypeIDUpdate, bFrameHeightUpdate);
			}
			if (oFrame.ErrorNumber == 0)
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

	#region Включение элеметов при множественном выборе ячеек

		private void chkPalletsTypes_CheckedChanged(object sender, EventArgs e)
		{
			cboPalletsTypes.Enabled = chkPalletsTypes.Checked;
		}

		private void chkFrameHeight_CheckedChanged(object sender, EventArgs e)
		{
			numFrameHeight.Enabled = chkFrameHeight.Checked;
		}
	
	#endregion

	#region Изменение значений

		private void cboPalletsTypes_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!_bLoaded)
				return;

			if (cboPalletsTypes.SelectedIndex >= 0)
			{
				txtPalletsTypes.Text = "";
			}
		}

		private void numFrameHeight_ValueChanged(object sender, EventArgs e)
		{
			if (!_bLoaded)
				return;

			if (numFrameHeight.Value >= 0)
			{
				txtFrameHeight.Text = "";
			}
		}

	#endregion

	}
}