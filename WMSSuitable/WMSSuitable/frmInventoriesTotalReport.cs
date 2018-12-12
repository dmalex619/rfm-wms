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
	public partial class frmInventoriesTotalReport : RFMFormChild
	{
		public string _SelectedPackingIDList;
		public string _SelectedPackingAliasText;
		private string sSelectedPackingsIDList = "";

		Inventory oInventory = new Inventory();

		public frmInventoriesTotalReport(Inventory _oInventory)
		{
			InitializeComponent();

			oInventory = _oInventory;
		}

		private void frmInventoriesTotalReport_Load(object sender, EventArgs e)
		{
			if (oInventory.IDList == null && oInventory.ID.HasValue)
				oInventory.IDList = oInventory.ID.ToString();

			grcBoxWished.AgrType =
			grcBoxConfirmed.AgrType =
			grcBoxDiff.AgrType =
			grcQntWished.AgrType =
			grcQntConfirmed.AgrType =
			grcQntDiff.AgrType =
				EnumAgregate.Sum;

			btnRestore_Click(null, null);
			grdData.Select();
		}

		#region Restore

		private bool grdData_Restore()
		{
			grdData.DataSource = null;

			oInventory.FillTableInventoriesTotalReport(oInventory.IDList, sSelectedPackingsIDList, chkDiffOnly.Checked);
			if (oInventory.DS.Tables["TableInventoriesTotalReport"] == null)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных для отчета...");
			}
			else
			{
				if (oInventory.DS.Tables["TableInventoriesTotalReport"].Rows.Count == 0)
				{
					RFMMessage.MessageBoxError("Нет данных для отчета...");
				}
			}

			grdData.Restore(oInventory.DS.Tables["TableInventoriesTotalReport"]);
			return (oInventory.ErrorNumber == 0);
		}

		#endregion

		#region Grid

		private void grdData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (grdData.DataSource == null)
				return;

			if (grdData.IsStatusRow(e.RowIndex))
			{
				return;
			}

			DataRow r = ((DataRowView)grdData.Rows[e.RowIndex].DataBoundItem).Row;
			// неактуальные - курсивом
			if (!Convert.ToBoolean(r["GoodActual"]) || !Convert.ToBoolean(r["PackingActual"]))
				e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Italic);

			// весовые товары или товары с нецелым вложением в коробоку
			switch (grdData.Columns[e.ColumnIndex].Name)
			{
				case "grcInBox":
				case "grcQntWished":
				case "grcQntConfirmed":
				case "grcQntDiff":
					if (Convert.IsDBNull(r["Weighting"]) ||
						Convert.ToBoolean(r["Weighting"]) ||
						!Convert.IsDBNull(e.Value) && Convert.ToDecimal(e.Value) != Convert.ToInt32(e.Value))
					{
						e.CellStyle.Format = "### ### ### ##0.000";
					}
					else
					{
						e.CellStyle.Format = "### ### ### ###";
					}
					break;
				case "grcBoxWished":
				case "grcBoxConfirmed":
				case "grcBoxDiff":
					if (!Convert.IsDBNull(e.Value) && Convert.ToDecimal(e.Value) == 0)
					{
						e.Value = "";
					}
					break;
			}
		}

		#endregion Grid

		#region Buttons

		private void btnExit_Click(object sender, EventArgs e)
		{
			Dispose();
		}

		private void btnHelp_Click(object sender, EventArgs e)
		{
			RFMHelpUtilities.HelpShow(this, hpHelp);
		}

		private void btnRestore_Click(object sender, EventArgs e)
		{
			grdData_Restore();
		}

		#endregion Buttons

		#region Filters 

		private void btnPackingsChoose_Click(object sender, EventArgs e)
		{
			_SelectedPackingIDList = null;
			_SelectedPackingAliasText = "";

			if (StartForm(new frmSelectOnePacking(this, true)) == DialogResult.Yes)
			{
				if (_SelectedPackingIDList == null || !_SelectedPackingIDList.Contains(","))
				{
					btnPackingsClear_Click(null, null);
					return;
				}

				sSelectedPackingsIDList = "," + _SelectedPackingIDList;
				txtPackingsChoosen.Text = _SelectedPackingAliasText;
				ttToolTip.SetToolTip(txtPackingsChoosen, txtPackingsChoosen.Text);
			}

			_SelectedPackingIDList = null;
			_SelectedPackingAliasText = "";
		}

		private void btnPackingsClear_Click(object sender, EventArgs e)
		{
			ttToolTip.SetToolTip(txtPackingsChoosen, "не выбраны");
			sSelectedPackingsIDList = "";
			txtPackingsChoosen.Text = "";
		}

		#endregion Filters

	}
}
