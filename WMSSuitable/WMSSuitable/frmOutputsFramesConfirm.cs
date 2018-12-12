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
	public partial class frmOutputsFramesConfirm : RFMFormChild
	{
		private int ID;
		private Output oOutput;
		private User oUsers;
		private BindingSource bsTrafficsFrames = new BindingSource();
		private Cell oCell;

		public frmOutputsFramesConfirm(int? _ID)
		{
			oOutput = new Output();
			oUsers = new User();
			oCell = new Cell();
			if (oOutput.ErrorNumber != 0 ||
				oUsers.ErrorNumber != 0 ||
				oCell.ErrorNumber != 0)
			{
				IsValid = false;
			}

			if (IsValid)
			{
				InitializeComponent();

				if (_ID.HasValue)
				{
					oOutput.ID = (int)ID;
					ID = (int)_ID;
				}
				
				dgvOutputFramesShipment.ReadOnly = false;
				foreach (DataGridViewColumn c in dgvOutputFramesShipment.Columns)
				{
					c.ReadOnly = !(c.Name.Contains("Check"));
				}
			}
		}

		private void frmOutputEdit_Load(object sender, EventArgs e)
		{
			bool blResult = cboHeavers_Restore();
			if (!blResult)
			{
				RFMMessage.MessageBoxError("Ошибка получения списка грузчиков...");
				Dispose();
			}

			// сам расход 
			oOutput.ID = ID;
			oOutput.FillData();
			if (oOutput.ErrorNumber != 0 || oOutput.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о расходе...");
				Dispose();
			}

			// транспортировки контейнеров в расходе
			oOutput.FillTableOutputsTraffics(ID, true);
			if (oOutput.ErrorNumber != 0)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о транспортировках поддонов для расхода...");
				Dispose();
				return;
			}
			if (oOutput.TableOutputsTrafficsFrames.Rows.Count == 0)
			{
				RFMMessage.MessageBoxInfo("Для расхода не создано транспортировок поддонов.\n\r" +
					"Нечего подтверждать...");
				Dispose();
				return;
			}

			//
			DataRow r = oOutput.MainTable.Rows[0];
			txtID.Text = r["ID"].ToString();
			txtErpCode.Text = r["ErpCode"].ToString();
			txtDateOutput.Text = r["DateOutput"].ToString().Substring(0, 10);
			txtOutputBarCode.Text = r["BarCode"].ToString(); 

			txtOwnerName.Text = r["OwnerName"].ToString();
			txtPartnerName.Text = r["PartnerName"].ToString();

			txtGoodStateName.Text = r["GoodStateName"].ToString(); 
			txtOutputTypeName.Text = r["OutputTypeName"].ToString();
			txtCellAdress.Text = r["CellAddress"].ToString();

			btnSelect_Click(null, null);
		}


		private void btnSelect_Click(object sender, EventArgs e)
		{
			if (!dgvOuputsShipment_Restore())
			{
				RFMMessage.MessageBoxError("Ошибка получения данных об транспортировках поддонов...");
				Dispose();
			}
		}

		#region Restore

		private bool dgvOuputsShipment_Restore()
		{
			oOutput.FillTableOutputsTraffics(ID, true);
			dgvOutputFramesShipment.Restore(oOutput.TableOutputsTrafficsFrames);
			if (chkUnConfirmed.Checked)
			{
				dgvOutputFramesShipment.GridSource.Filter = "IsConfirmed = false";
			}
			else
			{
				dgvOutputFramesShipment.GridSource.Filter = null;
			}
			return (oOutput.ErrorNumber == 0);
		}

		private bool cboHeavers_Restore()
		{
			oUsers.FillData();
			cboHeavers.ValueMember = oUsers.ColumnID;
			cboHeavers.DisplayMember = oUsers.MainTable.Columns[("Name")].ToString();
			cboHeavers.DataSource = oUsers.MainTable;
			return (oUsers.ErrorNumber == 0);
		}

		#endregion

		#region Cell...

		private void dgvOutputFramesShipment_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (dgvOutputFramesShipment.DataSource == null || dgvOutputFramesShipment.CurrentRow == null)
				return;

			DataRow droRow = oOutput.TableOutputsTrafficsFrames.Rows.Find(
					(int)dgvOutputFramesShipment.Rows[e.RowIndex].Cells["dgrcID"].Value);
		
			if (droRow == null)
				return;

			if ((bool)droRow["IsConfirmed"])
				e.CellStyle.BackColor = Color.FromArgb(250, 200, 200);
		}

		private void dgvOutputFramesShipment_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
		{
			if (dgvOutputFramesShipment.DataSource == null || e.RowIndex == -1 || e.ColumnIndex == -1)
				return;

			DataRow droRow = oOutput.TableOutputsTrafficsFrames.Rows.Find(
					(int)dgvOutputFramesShipment.Rows[e.RowIndex].Cells["dgrcID"].Value);

			if (droRow == null)
				return;

			if ((bool)droRow["IsConfirmed"] &&
				dgvOutputFramesShipment.Columns["dgrcCheck"].Index == e.ColumnIndex)
			{
				using (
						Brush gridBrush = new SolidBrush(this.dgvOutputFramesShipment.GridColor),
						backColorBrush = new SolidBrush(e.CellStyle.BackColor))
				{
					using (Pen gridLinePen = new Pen(gridBrush))
					{
						e.Graphics.FillRectangle(backColorBrush, e.CellBounds);

						e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left,
							e.CellBounds.Bottom - 1, e.CellBounds.Right - 1,
							e.CellBounds.Bottom - 1);

						e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1,
							 e.CellBounds.Top, e.CellBounds.Right - 1,
							e.CellBounds.Bottom);
						e.Handled = true;
					}
				}
			}
		}

		private void dgvOutputFramesShipment_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if (dgvOutputFramesShipment.Columns[e.ColumnIndex].Name == "dgrcCheck")
			{
				DataRow droRow = oOutput.TableOutputsTrafficsFrames.Rows.Find(
						(int)dgvOutputFramesShipment.Rows[e.RowIndex].Cells["dgrcID"].Value);
				if (droRow != null)
				{
					droRow["Checked"] = (bool)dgvOutputFramesShipment.Rows[e.RowIndex].Cells["dgrcCheck"].Value;
				}
			}
		}

		#endregion 

		private void btnExit_Click(object sender, EventArgs e)
		{
			Dispose();
		}

		private void btnHelp_Click(object sender, EventArgs e)
		{
			RFMHelpUtilities.HelpShow(this, hpHelp);
		}

		private void btnCheckAll_Click(object sender, EventArgs e)
		{
			CheckAll(true);
		}

		private void btnUnCheckAll_Click(object sender, EventArgs e)
		{
			CheckAll(false);
		}

		private void CheckAll(bool isChecked)
		{
			if (dgvOutputFramesShipment.Rows.Count == 0)
				return;

			RFMCursorWait.LockWindowUpdate(FindForm().Handle);

			foreach (DataGridViewRow rg in dgvOutputFramesShipment.Rows)
			{
				DataRow r = oOutput.TableOutputsTrafficsFrames.Rows.Find(Convert.ToInt32(rg.Cells["dgrcID"].Value));
				if (r != null)
				{
					r["Checked"] = isChecked;
				}
			}
			dgvOutputFramesShipment.Refresh();

			RFMCursorWait.LockWindowUpdate(IntPtr.Zero);
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (cboHeavers.SelectedIndex < 0 || cboHeavers.SelectedValue == null)
			{
				RFMMessage.MessageBoxError("Не указан грузчик...");
				return; 
			}

			bool lChecked = false;
			foreach (DataRow r in oOutput.TableOutputsTrafficsFrames.Rows)
			{
				if ((bool)r["Checked"] && !(bool)r["IsConfirmed"])
					lChecked = true; 
			}
			if (!lChecked)
			{
				RFMMessage.MessageBoxError("Не отмечено ни одной транспортировки...");
				return; 
			}

			if (RFMMessage.MessageBoxYesNo("Подтвердить транспортировки поддонов?") == DialogResult.Yes)
			{
				Refresh();
				WaitOn(this);
				oOutput.ClearError();
				bool bResult = oOutput.ConfirmTraffics(ID, true, null, (int)cboHeavers.SelectedValue, oOutput.TableOutputsTrafficsFrames);
				WaitOff(this);
				if (bResult && oOutput.ErrorNumber == 0)
				{
					RFMMessage.MessageBoxInfo("Подтверждены транспортировки поддонов.");
					Dispose();
				}
				else
				{
					RFMMessage.MessageBoxError("Ошибка подтверждения транспортировок поддонов...");
				}
			}
		}

	}
}
	