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
	public partial class frmReportPackingsTurnover : RFMFormChild
	{
		private Report oReport;  

		private Good oGood;
		private GoodState oGoodState;
		private Partner oOwner;  

		DateTime dDateBeg, dDateEnd;
		int nPackingID;
		int? nOwnerID;
		int nGoodStateID;

		decimal nQntBeg, nQntEnd;

		private bool bWeighting; 
		
		public frmReportPackingsTurnover(DateTime _dDateBeg, DateTime _dDateEnd, 
				int _nPackingID, int? _nOwnerID, int _nGoodStateID)
		{
			oReport = new Report();
			oGood = new Good();
			oGoodState = new GoodState();
			oOwner = new Partner();
			if (oReport.ErrorNumber != 0 ||
				oGood.ErrorNumber != 0 || 
				oGoodState.ErrorNumber != 0 ||
				oOwner.ErrorNumber != 0) 
				IsValid = false;
			if (IsValid)
			{
				InitializeComponent();

				dDateBeg = _dDateBeg;
				dDateEnd = _dDateEnd;
				nPackingID = _nPackingID;
				nOwnerID = _nOwnerID;
				nGoodStateID = _nGoodStateID;

				grcQntPlus.AgrType =
				grcQntMinus.AgrType = 
					EnumAgregate.Sum;
			}
		}

		public frmReportPackingsTurnover(int _nPackingID, int? _nOwnerID, int _nGoodStateID) : 
            this(DateTime.Now.Date, DateTime.Now.Date, _nPackingID, _nOwnerID, _nGoodStateID)
		{
		}

		private void frmReportPackingsTurnover_Load(object sender, EventArgs e)
		{
			oGood.PackingID = nPackingID;
			oGood.FillData();
			if (oGood.ErrorNumber != 0)
				return;
			if (oGood.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о товаре...");
				return;
			}

			DataRow r = oGood.MainTable.Rows[0];
			bWeighting = !Convert.IsDBNull(r["Weighting"]) && Convert.ToBoolean(r["Weighting"]) ||
						 !Convert.IsDBNull(r["InBox"]) && Convert.ToDecimal(r["InBox"]) != Convert.ToInt32(r["InBox"]);
			if (bWeighting)
			{
				numInBox.DecimalPlaces =
				numQntBeg.DecimalPlaces =
				numQntEnd.DecimalPlaces =
					3;
				grcQntPlus.DefaultCellStyle.Format =
				grcQntMinus.DefaultCellStyle.Format =
					"### ### ###.000";
			}
			else
			{
				numInBox.DecimalPlaces =
				numQntBeg.DecimalPlaces =
				numQntEnd.DecimalPlaces =
					0;
				grcQntPlus.DefaultCellStyle.Format =
				grcQntMinus.DefaultCellStyle.Format =
					"### ### ###";
			}

			txtGoodAlias.Text = oGood.MainTable.Rows[0]["GoodAlias"].ToString();
			numInBox.Value = Convert.ToDecimal(oGood.MainTable.Rows[0]["InBox"]);

			oGoodState.ID = nGoodStateID;
			oGoodState.FillData();
			if (oGoodState.ErrorNumber != 0)
				return;
			if (oGoodState.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о состоянии товара...");
				return;
			}
			txtGoodStateName.Text = oGoodState.MainTable.Rows[0]["Name"].ToString();

			if (nOwnerID.HasValue)
			{
				oOwner.ID = nOwnerID;
				oOwner.FillData();
				if (oOwner.ErrorNumber != 0)
					return;
				if (oOwner.MainTable.Rows.Count == 0)
				{
					RFMMessage.MessageBoxError("Ошибка при получении данных о владельце/хранителе...");
					return;
				}
				txtOwnerName.Text = oOwner.MainTable.Rows[0]["Name"].ToString();
			}

			dtrDates.dtpBegDate.Value = dDateBeg;
			dtrDates.dtpEndDate.Value = dDateEnd;
			btnFilter_Click(null, null);

		}

		#region Buttons

		private void btnExit_Click(object sender, EventArgs e)
		{
			Dispose();
		}

		private void btnHelp_Click(object sender, EventArgs e)
		{
			RFMHelpUtilities.HelpShow(this, hpHelp);
		}

		private void btnFilter_Click(object sender, EventArgs e)
		{
            grdData.Visible = false;
            this.Refresh();
            Cursor.Current = Cursors.WaitCursor;

            grdData_Restore();
			grdData.Select();

            Cursor.Current = Cursors.Default;
            grdData.Visible = true;
            this.Refresh();
        }

		#endregion

		#region Restore

		private bool grdData_Restore()
		{
			nQntBeg = nQntEnd = 0;

			oReport.ClearError();
			oReport.ReportPackingsTurnover(dtrDates.dtpBegDate.Value, dtrDates.dtpEndDate.Value,
					nPackingID, nOwnerID, nGoodStateID, 
					ref nQntBeg, ref nQntEnd);

			grdData.Restore(oReport.MainTable);

			numQntBeg.Value = nQntBeg;
			numQntEnd.Value = nQntEnd;

			grdData.Select();

			return (oReport.ErrorNumber == 0);
		}

		#endregion

		#region CellFormatting

		private void grdData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			RFMDataGridView grd = grdData;
			if (grd.Rows[e.RowIndex] == null)
				return;

			if (grd.IsStatusRow(e.RowIndex))
			{
				e.CellStyle.BackColor = Color.Silver;
				e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);

				switch (grd.Columns[e.ColumnIndex].Name)
				{
					case "grcTypeImage":
						e.Value = Properties.Resources.Empty;
						break;
				}
				return;
			}

			DataGridViewRow r = grd.Rows[e.RowIndex];
			switch (grd.Columns[e.ColumnIndex].Name)
			{
				case "grcQntPlus":
				case "grcQntMinus":
					if (bWeighting && Convert.ToDecimal(e.Value) == 0)
					{
						e.Value = ""; 
					}
					break;
				case "grcTypeImage":
					switch (r.Cells["grcOperType"].Value.ToString())
					{
						case "I":
							e.Value = Properties.Resources.Plus;
							break;
						case "O":
							e.Value = Properties.Resources.Minus;
							break;
						default:
							e.Value = Properties.Resources.Empty;
							break;
					}
					break;
			}
		}

		#endregion 

	}
}
