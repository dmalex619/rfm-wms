using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Threading;

using RFMBaseClasses;
using WMSBizObjects;
using RFMPublic;

namespace WMSSuitable
{
	public partial class frmReportOddmentsBalance : RFMFormChild
	{
		Report oReport = new Report(); 
		
		// для фильтров
		protected string sOwnersList, sGoodsStatesList, sPackingsList;
        protected int nMode;

		public int? _SelectedID;
		public string _SelectedIDList;
		public string _SelectedText;

		private string sSelectedGoodsStatesIDList = "";
		private string sSelectedOwnersIDList = "";

		public string _SelectedPackingIDList;
		public string _SelectedPackingAliasText;
		private string sSelectedPackingsIDList = "";

		public frmReportOddmentsBalance()
		{
			InitializeComponent();
		}

		private void frmReportOddmentsBalance_Load(object sender, EventArgs e) 
		{
			RFMCursorWait.Set(true);

			grcQntBeg.AgrType =
            grcQntPlus.AgrType =
            grcQntPlusAct.AgrType =
            grcQntMinus.AgrType =
            grcQntMinusAct.AgrType =
            grcQntEnd.AgrType =
				EnumAgregate.Sum;

			btnClearTerms_Click(null, null);

			tcList.Init();

			RFMCursorWait.Set(false);
		}

	#region Tab Restore 

		private bool tabTerms_Restore()
		{
			btnPrint.Enabled = false;
			btnDetail.Enabled = false;
			return (true);
		}

		private bool tabData_Restore()
		{
			grdData_Restore();
			btnPrint.Enabled = true;
			btnDetail.Enabled = true;
			return (true);
		}

		private void tcList_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (tcList.SelectedTab.Name)
			{
				case "tabTerms":
					tabTerms_Restore();
					break;
				case "tabData":
					grdData.Select();
					break;
			}
		}

	#endregion Tab Restore

	#region Buttons

		private void btnDetail_Click(object sender, EventArgs e)
		{
			if (grdData.CurrentRow == null)
				return;

			if (grdData.IsStatusRow(grdData.CurrentRow.Index))
				return;

			DataGridViewRow r = grdData.CurrentRow;
			int nPackingID = Convert.ToInt32(r.Cells["grcPackingID"].Value);
			int? nOwnerID = null;
			if (!Convert.IsDBNull(r.Cells["grcOwnerID"].Value))
			{ 
				nOwnerID = Convert.ToInt32(r.Cells["grcOwnerID"].Value);
			}
			int nGoodStateID = Convert.ToInt32(r.Cells["grcGoodStateID"].Value);

			StartForm(new frmReportPackingsTurnover(dtrDates.dtpBegDate.Value, dtrDates.dtpEndDate.Value,
				nPackingID, nOwnerID, nGoodStateID));
		}

		private void btnHelp_Click(object sender, EventArgs e)
		{
			RFMHelpUtilities.HelpShow(this, hpHelp);
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

	#endregion

	#region CellFormatting

		private void grdData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (grdData.DataSource == null)
				return;

			if (grdData.IsStatusRow(e.RowIndex))
			{
				e.CellStyle.BackColor = Color.Silver;
				e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);

				switch (grdData.Columns[e.ColumnIndex].Name)
				{
					case "grcQntBeg":
                    case "grcQntPlus":
                    case "grcQntPlusAct":
                    case "grcQntMinus":
                    case "grcQntMinusAct":
                    case "grcQntEnd":
					case "grcQntInCells":
					case "grcInBox":
						e.CellStyle.Format = "### ### ### ###";
						break;
					case "grcTypeImage":
						e.Value = Properties.Resources.Empty;
						break;
				}
				return;
			}

			DataGridViewRow r = grdData.Rows[e.RowIndex];
			switch (grdData.Columns[e.ColumnIndex].Name)
			{
				case "grcQntBeg":
                case "grcQntPlus":
                case "grcQntPlusAct":
                case "grcQntMinus":
                case "grcQntMinusAct":
                case "grcQntEnd":
				case "grcInBox":
					if (!Convert.IsDBNull(r.Cells["grcWeighting"].Value) &&
						Convert.ToBoolean(r.Cells["grcWeighting"].Value) ||
						!Convert.IsDBNull(e.Value) && Convert.ToDecimal(e.Value) != Convert.ToInt32(e.Value))
					{
						e.CellStyle.Format = "### ### ### ###.000";
					}
					else
					{
						e.CellStyle.Format = "### ### ### ###";
					}
					if (Convert.IsDBNull(e.Value) || Convert.ToDecimal(e.Value) == 0)
					{
						e.Value = "";
					}
					break;
				case "grcTypeImage":
					e.Value = Properties.Resources.Empty;
					break;
			}
		}

	#endregion

	#region Restore

		private bool grdData_Restore()
		{
			// собираем условия

			sOwnersList = sGoodsStatesList = sPackingsList = null;

			// состояния товара
			if (sSelectedGoodsStatesIDList.Length > 0)
			{
				sGoodsStatesList = sSelectedGoodsStatesIDList;
			}
			// хранители
			if (sSelectedOwnersIDList.Length > 0)
			{
				sOwnersList = sSelectedOwnersIDList;
			}
			// выбранные товары
			if (sSelectedPackingsIDList.Length > 0)
			{
				sPackingsList = sSelectedPackingsIDList;
			}

            // единица расчета
            if (optModeNetto.Checked) nMode = 4;        // кг нетто
            else if (optModePallets.Checked) nMode = 3; // паллеты
            else if (optModeBoxes.Checked) nMode = 2;   // коробки
            else if (optModePieces.Checked) nMode = 1;  // штуки

			grdData.GetGridState(); 

			oReport.ReportOddmentsBalance(dtrDates.dtpBegDate.Value.Date, dtrDates.dtpEndDate.Value.Date,
				sOwnersList, sGoodsStatesList, sPackingsList, 
				optGroupYes.Checked, nMode);

			grdData.IsLockRowChanged = true;
			grdData.Restore(oReport.MainTable);

			grcQntInCells.Visible = optGroupYes.Checked;

			grdData.Select();

			return (oReport.ErrorNumber == 0);
		}

	#endregion

	#region Filters 

		#region GoodsStates

		private void btnGoodsStatesChoose_Click(object sender, EventArgs e)
		{
			_SelectedIDList = null;
			_SelectedText = "";

			GoodState oGoodState = new GoodState();
			oGoodState.FillData();
			if (oGoodState.ErrorNumber != 0 || oGoodState.MainTable == null)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о состояниях товаров...");
				return;
			}
			if (oGoodState.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Нет данных о состояниях товаров...");
				return;
			}

			if (StartForm(new frmSelectID(this, oGoodState.MainTable, "Name", "Состояние товара", true)) == DialogResult.Yes)
			{
				if (_SelectedIDList == null || !_SelectedIDList.Contains(","))
				{
					btnGoodsStatesClear_Click(null, null);
					return;
				}

				sSelectedGoodsStatesIDList = "," + _SelectedIDList;

				txtGoodsStatesChoosen.Text = _SelectedText;
				ttToolTip.SetToolTip(txtGoodsStatesChoosen, txtGoodsStatesChoosen.Text);

				tabData.IsNeedRestore = true;
			}

			_SelectedIDList = null;
			_SelectedText = "";
		}

		private void btnGoodsStatesClear_Click(object sender, EventArgs e)
		{
			tabData.IsNeedRestore = true;

			ttToolTip.SetToolTip(txtGoodsStatesChoosen, "не выбраны");
			sSelectedGoodsStatesIDList = "";
			txtGoodsStatesChoosen.Text = "";
		}

		#endregion GoodsStates

		#region Owners

		private void btnOwnersChoose_Click(object sender, EventArgs e)
		{
			_SelectedIDList = null;
			_SelectedText = "";

			Partner oOwner = new Partner();
			if (optGroupNo.Checked)
			{
				oOwner.FilterActual = true;
				oOwner.FilterOwner = true;
				oOwner.FillData();
			}
			else
			{
				oOwner.FillDataOwners();
			}
			if (oOwner.ErrorNumber != 0 || oOwner.MainTable == null)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных...");
				return;
			}
			if (oOwner.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Нет данных...");
				return;
			}

			if (StartForm(new frmSelectID(this, oOwner.MainTable, "Name,Actual", "Владелец,Акт.", true)) == DialogResult.Yes)
			{
				if (_SelectedIDList == null || !_SelectedIDList.Contains(","))
				{
					btnOwnersClear_Click(null, null);
					return;
				}

				sSelectedOwnersIDList = "," + _SelectedIDList;

				txtOwnersChoosen.Text = _SelectedText;
				ttToolTip.SetToolTip(txtOwnersChoosen, txtOwnersChoosen.Text);

				tabData.IsNeedRestore = true;
			}

			_SelectedIDList = null;
			_SelectedText = "";
		}

		private void btnOwnersClear_Click(object sender, EventArgs e)
		{
			tabData.IsNeedRestore = true;

			ttToolTip.SetToolTip(txtOwnersChoosen, "не выбраны");
			sSelectedOwnersIDList = "";
			txtOwnersChoosen.Text = "";
		}

		#endregion

		#region Packings

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

				tabData.IsNeedRestore = true;
			}

			_SelectedPackingIDList = null;
			_SelectedPackingAliasText = "";
		}

		private void btnPackingsClear_Click(object sender, EventArgs e)
		{
			tabData.IsNeedRestore = true;

			ttToolTip.SetToolTip(txtPackingsChoosen, "не выбраны");
			sSelectedPackingsIDList = "";
			txtPackingsChoosen.Text = "";
		}

		#endregion

		private void optGroupNo_CheckedChanged(object sender, EventArgs e)
		{
			btnOwnersClear_Click(null, null);
		}

	#endregion Filters

	#region Menu Print

		private void btnPrint_Click(object sender, EventArgs e)
		{
			switch (tcList.SelectedTab.Name)
			{
				case "tabData":
					mnuPrint.Show(btnPrint, new Point());
					break;
				default:
					break;
			}
		}

		private void btnPrint_MouseClick(object sender, MouseEventArgs e)
		{
			switch (tcList.SelectedTab.Name)
			{
				case "tabData":
					mnuPrint.Show(btnPrint, new Point(e.X, e.Y));
					break;
				default:
					break;
			}
		}

	#endregion

	#region Terms clear

		private void btnClearTerms_Click(object sender, EventArgs e)
		{
			btnGoodsStatesClear_Click(null, null);
			btnOwnersClear_Click(null, null);
			btnPackingsClear_Click(null, null);

			optGroupNo.Checked = true; 

			dtrDates.dtpBegDate.Value = DateTime.Now.Date.AddMonths(-1);
			dtrDates.dtpEndDate.Value = DateTime.Now.Date;

			tabData.IsNeedRestore = true;
		}
		
	#endregion

	}
}