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
	public partial class frmReportInputsDateValid : RFMFormChild
	{
		Report oReport = new Report();

		int nPercentDefault = 67;
		
		// для фильтров
		public int? _SelectedID;
		public string _SelectedIDList;
		public string _SelectedText;

		protected string sPartnersList, sPackingsList;
		private string sSelectedPartnersIDList = "";
		public string _SelectedPackingIDList;
		public string _SelectedPackingAliasText;
		private string sSelectedPackingsIDList = "";

		public frmReportInputsDateValid()
		{
			InitializeComponent();
		}

		private void frmReportInputsDateValid_Load(object sender, EventArgs e) 
		{
			RFMCursorWait.Set(true);

			grcQnt.AgrType =
			grcBox.AgrType =
				EnumAgregate.Sum;

			btnClearTerms_Click(null, null);

			numPercents.Value = nPercentDefault;

			RFMCursorWait.Set(false);
			tcList.Init();
		}

		private bool tabTerms_Restore()
		{
			btnPrint.Enabled = false;
			return (true);
		}

		private bool tabData_Restore()
		{
			grdData_Restore();
			btnPrint.Enabled = true;
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


	#region RowEnter, CellFormatting

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
					case "grcQnt":
					case "grcInBox":
						e.CellStyle.Format = "### ### ### ###";
						break;
				}
				return;
			}

			DataGridViewRow r = grdData.Rows[e.RowIndex];
			switch (grdData.Columns[e.ColumnIndex].Name)
			{
				case "grcQnt":
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
			}
		}

	#endregion

	#region Restore

		private bool grdData_Restore()
		{
			// собираем условия

			sPartnersList = sPackingsList = null;

			// поставщики
			if (sSelectedPartnersIDList.Length > 0)
			{
				sPartnersList = sSelectedPartnersIDList;
			}
			// выбранные товары
			if (sSelectedPackingsIDList.Length > 0)
			{
				sPackingsList = sSelectedPackingsIDList;
			}

			int? nPercents = null, nMonth = null;
			if (radPercents.Checked)
			{
				nPercents = (int)numPercents.Value;
			}
			if (radMonths.Checked)
			{
				nMonth = (int)numMonths.Value;
			}
			bool bFromNow = false;
			if (radFromNow.Checked)
			{
				bFromNow = true;
			}

			WaitOn(this);

			Good oGoods = new Good();
			oGoods.FilterPackingsIDList = sPackingsList;
			oGoods.FilterGoodsActual = true;
			oGoods.FillData();
			if (oGoods.ErrorNumber != 0)
			{
				WaitOff(this);
				return (false);
			}
			for (int i = 0; i < oGoods.MainTable.Rows.Count; i++)
			{
				if ((int)oGoods.MainTable.Rows[i]["Retention"] == 0)
				{
					WaitOff(this);
					RFMMessage.MessageBoxAttention("В отчет не попадут товары с нулевым сроком годности!");
					WaitOn(this);
					break;
				}
			}

			grdData.DataSource = null;

			oReport.ReportInputsDateValid(dtrDates.dtpBegDate.Value.Date, dtrDates.dtpEndDate.Value.Date,
				sPartnersList, sPackingsList, 
				nPercents, nMonth,
				bFromNow);

			grdData.Restore(oReport.MainTable);
			
			WaitOff(this);

			grdData.Select();

			return (oReport.ErrorNumber == 0);
		}

	#endregion

	#region Filters 

		#region Partners

		private void btnPartnersChoose_Click(object sender, EventArgs e)
		{
			_SelectedIDList = null;
			_SelectedText = "";

			Partner oPartner = new Partner();
			oPartner.FilterExistsInInputs = true;
			oPartner.FillData();
			if (oPartner.ErrorNumber != 0 || oPartner.MainTable == null)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных...");
				return;
			}
			if (oPartner.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Нет данных...");
				return;
			}

			if (StartForm(new frmSelectID(this, oPartner.MainTable, "Name,Actual", "Поставщик,Акт.", true)) == DialogResult.Yes)
			{
				if (_SelectedIDList == null || !_SelectedIDList.Contains(","))
				{
					btnPartnersClear_Click(null, null);
					return;
				}

				sSelectedPartnersIDList = "," + _SelectedIDList;

				txtPartnersChoosen.Text = _SelectedText;
				ttToolTip.SetToolTip(txtPartnersChoosen, txtPartnersChoosen.Text);

				tabData.IsNeedRestore = true;
			}

			_SelectedIDList = null;
			_SelectedText = "";
		}

		private void btnPartnersClear_Click(object sender, EventArgs e)
		{
			tabData.IsNeedRestore = true;

			ttToolTip.SetToolTip(txtPartnersChoosen, "не выбраны");
			sSelectedPartnersIDList = "";
			txtPartnersChoosen.Text = "";
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

		private void radDateValid_CheckedChanged(object sender, EventArgs e)
		{
			if (radPercents.Checked)
			{
				numPercents.Enabled = true;
				numMonths.Enabled = false;
			}
			if (radMonths.Checked)
			{
				numPercents.Enabled = false;
				numMonths.Enabled = true;
			}
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
			btnPartnersClear_Click(null, null);
			btnPackingsClear_Click(null, null);

			radPercents.Checked = true;
			numPercents.Value = 66;

			radFromDateInput.Checked = true; 

			dtrDates.dtpBegDate.Value = DateTime.Now.Date.AddMonths(-1);
			dtrDates.dtpEndDate.Value = DateTime.Now.Date;

			tabData.IsNeedRestore = true;
		}
		
	#endregion

		private void btnHelp_Click(object sender, EventArgs e)
		{
			RFMHelpUtilities.HelpShow(this, hpHelp);
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Dispose();
		}

	}
}