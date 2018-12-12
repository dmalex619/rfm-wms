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
	public partial class frmReportForSalary : RFMFormChild
	{
		protected DateTime? dDateBeg, dDateEnd;
		protected bool bGroupBy = false;

		public string _SelectedIDList;
		public string _SelectedText; 
		private string sSelectedUsersIDList = "";
		private string sSelectedInputsTypesIDList = "";
		private string sSelectedOutputsTypesIDList = "";

		private Report oReportInputs;
		private Report oReportTrafficsFrames;
		private Report oReportOutputsTrafficsGoods;
		private Report oReportOutputsTrafficsFrames;
		private Report oReportOutputs;

		public frmReportForSalary()
		{
			oReportInputs = new Report();
			oReportTrafficsFrames = new Report();
			oReportOutputsTrafficsGoods = new Report();
			oReportOutputsTrafficsFrames = new Report();
			oReportOutputs = new Report();
			if (oReportInputs.ErrorNumber != 0 ||
				oReportTrafficsFrames.ErrorNumber != 0 ||
				oReportOutputsTrafficsGoods.ErrorNumber != 0 ||
				oReportOutputsTrafficsFrames.ErrorNumber != 0 ||
				oReportOutputs.ErrorNumber != 0)
			{
				IsValid = false;
			}

			if (IsValid)
			{
				InitializeComponent();
			}
		}

		private void frmReportForSalary_Load(object sender, EventArgs e) 
		{
			btnClearTerms_Click(null, null);
			tcList.Init();

			grdInputs.IsStatusShow = 
			grdTrafficsFrames.IsStatusShow =
			grdOutputsTrafficsGoods.IsStatusShow =
			grdOutputsTrafficsFrames.IsStatusShow =
			grdOutputs.IsStatusShow =  
				true;

			grcInputs_Lines.AgrType =
			grcInputs_Boxes.AgrType =
			grcInputs_Pallets.AgrType =
			grcInputs_Netto.AgrType =
			grcTrafficsFrames_PalletsDown.AgrType =
			grcTrafficsFrames_PalletsUp.AgrType =
			grcOutputsTrafficsGoods_Lines.AgrType =
			grcOutputsTrafficsGoods_Boxes.AgrType =
			grcOutputsTrafficsGoods_Pallets.AgrType =
			grcOutputsTrafficsGoods_Netto.AgrType =
			grcOutputsTrafficsFrames_Lines.AgrType =
			grcOutputsTrafficsFrames_Boxes.AgrType =
			grcOutputsTrafficsFrames_Pallets.AgrType =
			grcOutputsTrafficsFrames_Netto.AgrType =
			grcOutputs_Lines.AgrType =
			grcOutputs_Boxes.AgrType =
			grcOutputs_Pallets.AgrType =
			grcOutputs_Netto.AgrType =
				EnumAgregate.Sum; 
		}

		private bool tabTerms_Restore()
		{
			btnPrint.Enabled = false;
			return (true);
		}

		private bool tabInputs_Restore()
		{
			grdInputs_Restore();
			btnPrint.Enabled = true;
			return (true);
		}

		private bool tabTrafficsFrames_Restore()
		{
			grdTrafficsFrames_Restore();
			btnPrint.Enabled = true;
			return (true);
		}

		private bool tabOutputsTrafficsGoods_Restore()
		{
			grdOutputsTrafficsGoods_Restore();
			btnPrint.Enabled = true;
			return (true);
		}

		private bool tabOutputsTrafficsFrames_Restore()
		{
			grdOutputsTrafficsFrames_Restore();
			btnPrint.Enabled = true;
			return (true);
		}

		private bool tabOutputs_Restore()
		{
			grdOutputs_Restore();
			btnPrint.Enabled = true;
			return (true);
		}

		private void tcList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tcList.SelectedTab.Name.ToUpper().Contains("TERMS"))
			{
				btnPrint.Enabled = false;
			}
			if (tcList.SelectedTab.Name == tabInputs.Name)
			{
				grdInputs.Select();
			}
			if (tcList.SelectedTab.Name == tabTrafficsFrames.Name)
			{
				grdTrafficsFrames.Select();
			}
			if (tcList.SelectedTab.Name == tabOutputsTrafficsGoods.Name)
			{
				grdOutputsTrafficsGoods.Select();
			}
			if (tcList.SelectedTab.Name == tabOutputsTrafficsFrames.Name)
			{
				grdOutputsTrafficsFrames.Select();
			}
			if (tcList.SelectedTab.Name == tabOutputs.Name)
			{
				grdOutputs.Select();
			}
		}

	#region Buttons

		private void btnHelp_Click(object sender, EventArgs e)
		{
			RFMHelpUtilities.HelpShow(this, hpHelp);
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

	#endregion

	#region RowEnter, CellFormatting

		private void grdData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			RFMDataGridView grd = (RFMDataGridView)sender;

			if (grd.DataSource == null)
				return;

			if (grd.Rows[e.RowIndex] == null)
				return;

			if (grd.IsStatusRow(e.RowIndex))
			{
				if (grd.Columns[e.ColumnIndex].Name.ToUpper().Contains("IMAGE"))
				{
					e.Value = Properties.Resources.Empty;
				}
				return;
			}

			/*
			switch (grd.Columns[e.ColumnIndex].Name)
			{
				case "grcUserName":
					if (grd.Rows[e.RowIndex].Cells["grcDateConfirm"].Value.ToString().Length == 0)
						e.Value = Properties.Resources.Empty;
					else
						if (Convert.ToBoolean(grd.Rows[e.RowIndex].Cells["grcSuccess"].Value))
							e.Value = Properties.Resources.Check;
						else
							e.Value = Properties.Resources.CheckRed;
					break;
			}
			*/ 
		}

	#endregion

	#region Restore 

		private bool grdInputs_Restore()
		{
			TermsSelect();

			grdInputs.DataSource = null;

			oReportInputs.ReportForSalary(
				"Inputs",
				dDateBeg, dDateEnd,
				bGroupBy, 
				sSelectedUsersIDList, 
				sSelectedInputsTypesIDList, 
				null);
			
			grdInputs.Restore(oReportInputs.MainTable);

			grcInputs_UserName.Visible = optGroupByUsers.Checked; 

			//grdInputs.Select();

			return (oReportInputs.ErrorNumber == 0);
		}

		private bool grdTrafficsFrames_Restore()
		{
			TermsSelect();

			grdTrafficsFrames.DataSource = null;

			oReportTrafficsFrames.ReportForSalary(
				"TrafficsFrames",
				dDateBeg, dDateEnd,
				bGroupBy,
				sSelectedUsersIDList,
				null, 
				null);

			grdTrafficsFrames.Restore(oReportTrafficsFrames.MainTable);
			
			grcTrafficsFrames_UserName.Visible = optGroupByUsers.Checked;

			//grdTrafficsFrames.Select();

			return (oReportTrafficsFrames.ErrorNumber == 0);
		}

		private bool grdOutputsTrafficsGoods_Restore()
		{
			TermsSelect();

			grdOutputsTrafficsGoods.DataSource = null;

			oReportOutputsTrafficsGoods.ReportForSalary(
				"OutputsTrafficsGoods",
				dDateBeg, dDateEnd,
				bGroupBy,
				sSelectedUsersIDList,
				null, 
				sSelectedOutputsTypesIDList);

			grdOutputsTrafficsGoods.Restore(oReportOutputsTrafficsGoods.MainTable);

			grcOutputsTrafficsGoods_UserName.Visible = optGroupByUsers.Checked;
			
			//grdOutputsTrafficsGoods.Select();

			return (oReportOutputsTrafficsGoods.ErrorNumber == 0);
		}

		private bool grdOutputsTrafficsFrames_Restore()
		{
			TermsSelect();

			grdOutputsTrafficsFrames.DataSource = null;

			oReportOutputsTrafficsFrames.ReportForSalary(
				"OutputsTrafficsFrames",
				dDateBeg, dDateEnd,
				bGroupBy,
				sSelectedUsersIDList,
				null,
				sSelectedOutputsTypesIDList);

			grdOutputsTrafficsFrames.Restore(oReportOutputsTrafficsFrames.MainTable);

			grcOutputsTrafficsFrames_UserName.Visible = optGroupByUsers.Checked;

			//grdOutputsTrafficsFrames.Select();

			return (oReportOutputsTrafficsFrames.ErrorNumber == 0);
		}

		private bool grdOutputs_Restore()
		{
			TermsSelect();

			grdOutputs.DataSource = null;

			oReportOutputs.ReportForSalary(
				"Outputs",
				dDateBeg, dDateEnd,
				bGroupBy,
				sSelectedUsersIDList,
				null,
				sSelectedOutputsTypesIDList);

			grdOutputs.Restore(oReportOutputs.MainTable);

			grcOutputs_UserName.Visible = optGroupByUsers.Checked;
			//grdOutputs.Select();

			return (oReportOutputs.ErrorNumber == 0);
		}

		private void TermsSelect()
		{
			dDateBeg = dDateEnd = null;
			if (!dtrDates.dtpBegDate.IsEmpty)
			{
				dDateBeg = dtrDates.dtpBegDate.Value.Date;
			}
			if (!dtrDates.dtpEndDate.IsEmpty)
			{
				dDateEnd = dtrDates.dtpEndDate.Value.Date;
			}

			// группировка
			bGroupBy = (optGroupByBrigades.Checked); // true - по бригадам

			if (sSelectedUsersIDList != null && sSelectedUsersIDList.Length == 0)
				sSelectedUsersIDList = null;
			if (sSelectedInputsTypesIDList != null && sSelectedInputsTypesIDList.Length == 0)
				sSelectedInputsTypesIDList = null;
			if (sSelectedOutputsTypesIDList != null && sSelectedOutputsTypesIDList.Length == 0)
				sSelectedOutputsTypesIDList = null;
		}

	#endregion

	#region Filters Choose

		#region Users

		private void btnUsersChoose_Click(object sender, EventArgs e)
		{
			_SelectedIDList = null;
			sSelectedUsersIDList = "";

			User oUser = new User();
			oUser.FillDataTree(false);
			if (oUser.ErrorNumber != 0 || oUser.DS.Tables["TableDataTree"] == null)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных...");
				return;
			}
			if (oUser.DS.Tables["TableDataTree"].Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Нет данных...");
				return;
			}

			if (StartForm(new frmSelectTreeID(this, oUser.DS.Tables["TableDataTree"], true)) == DialogResult.Yes)
			{
				if (_SelectedIDList == null || RFMPublic.RFMUtilities.Occurs(_SelectedIDList, ",") == 0)
				{
					btnUsersClear_Click(null, null);
					return;
				}

				sSelectedUsersIDList = "," + _SelectedIDList;

				oUser.ClearError();
				oUser.IDList = sSelectedUsersIDList;
				oUser.FillData();
				if (oUser.ErrorNumber != 0)
				{
					btnUsersClear_Click(null, null);
					return;
				}

				int nCntChoosen = oUser.MainTable.Rows.Count;
				if (nCntChoosen == 0)
				{
					btnUsersClear_Click(null, null);
					return;
				}

				string sSelectedDataText = "";
				int i = 0;
				foreach (DataRow r in oUser.MainTable.Rows)
				{
					i++;
					if (i > 3)
					{
						sSelectedDataText += "...";
						break;
					}
					sSelectedDataText += ", " + r["Name"].ToString().Trim();
				}
				if (sSelectedDataText.StartsWith(","))
				{
					sSelectedDataText = sSelectedDataText.Substring(1).Trim();
				}

				txtUsersChoosen.Text = "(" + nCntChoosen.ToString().Trim() + "): " + sSelectedDataText;
				ttToolTip.SetToolTip(txtUsersChoosen, txtUsersChoosen.Text);

				tabInputs.IsNeedRestore =
				tabTrafficsFrames.IsNeedRestore =
				tabOutputsTrafficsGoods.IsNeedRestore =
				tabOutputsTrafficsFrames.IsNeedRestore =
				tabOutputs.IsNeedRestore =
					true;
			}

			if (sSelectedUsersIDList != null && sSelectedUsersIDList.Length == 0)
			{
				sSelectedUsersIDList = null;
			}
			_SelectedIDList = null;
		}

		private void btnUsersClear_Click(object sender, EventArgs e)
		{
			tabInputs.IsNeedRestore =
			tabTrafficsFrames.IsNeedRestore =
			tabOutputsTrafficsGoods.IsNeedRestore =
			tabOutputsTrafficsFrames.IsNeedRestore =
			tabOutputs.IsNeedRestore =
				true;

			ttToolTip.SetToolTip(txtUsersChoosen, "не выбраны");
			sSelectedUsersIDList = null;
			txtUsersChoosen.Text = "";
		}

		#endregion

		#region InputsTypes

		private void btnInputsTypesChoose_Click(object sender, EventArgs e)
		{
			_SelectedIDList = null;
			_SelectedText = "";

			Input oInputForType = new Input();
			oInputForType.FillTableInputsTypes();
			if (oInputForType.ErrorNumber != 0 || oInputForType.TableInputsTypes == null)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных...");
				return;
			}
			if (oInputForType.TableInputsTypes.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Нет данных...");
				return;
			}

			if (StartForm(new frmSelectID(this, oInputForType.TableInputsTypes, "Name", "Тип прихода", true)) == DialogResult.Yes)
			{
				if (_SelectedIDList == null || !_SelectedIDList.Contains(","))
				{
					btnInputsTypesClear_Click(null, null);
					return;
				}

				sSelectedInputsTypesIDList = "," + _SelectedIDList;

				txtInputsTypesChoosen.Text = _SelectedText;
				ttToolTip.SetToolTip(txtInputsTypesChoosen, txtInputsTypesChoosen.Text);

				tabInputs.IsNeedRestore = true;
			}

			_SelectedIDList = null;
			_SelectedText = "";
		}

		private void btnInputsTypesClear_Click(object sender, EventArgs e)
		{
			tabInputs.IsNeedRestore = true;

			ttToolTip.SetToolTip(txtInputsTypesChoosen, "не выбраны");
			sSelectedInputsTypesIDList = "";
			txtInputsTypesChoosen.Text = "";
		}

		#endregion

		#region OutputsTypes

		private void btnOutputsTypesChoose_Click(object sender, EventArgs e)
		{
			_SelectedIDList = null;
			_SelectedText = "";

			Output oOutputForType = new Output();
			oOutputForType.FillTableOutputsTypes();
			if (oOutputForType.ErrorNumber != 0 || oOutputForType.TableOutputsTypes == null)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных...");
				return;
			}
			if (oOutputForType.TableOutputsTypes.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Нет данных...");
				return;
			}

			if (StartForm(new frmSelectID(this, oOutputForType.TableOutputsTypes, "Name", "Тип расхода", true)) == DialogResult.Yes)
			{
				if (_SelectedIDList == null || !_SelectedIDList.Contains(","))
				{
					btnOutputsTypesClear_Click(null, null);
					return;
				}

				sSelectedOutputsTypesIDList = "," + _SelectedIDList;

				txtOutputsTypesChoosen.Text = _SelectedText;
				ttToolTip.SetToolTip(txtOutputsTypesChoosen, txtOutputsTypesChoosen.Text);

				tabOutputsTrafficsGoods.IsNeedRestore =
				tabOutputsTrafficsFrames.IsNeedRestore =
				tabOutputs.IsNeedRestore =
					true;
			}

			_SelectedIDList = null;
			_SelectedText = "";
		}

		private void btnOutputsTypesClear_Click(object sender, EventArgs e)
		{
			tabOutputsTrafficsGoods.IsNeedRestore =
			tabOutputsTrafficsFrames.IsNeedRestore =
			tabOutputs.IsNeedRestore =
				true;

			ttToolTip.SetToolTip(txtOutputsTypesChoosen, "не выбраны");
			sSelectedOutputsTypesIDList = "";
			txtOutputsTypesChoosen.Text = "";
		}

		#endregion 

	#endregion
		
	#region Menu Print

		private void btnPrint_Click(object sender, EventArgs e)
		{
			//mnuPrint.Show(btnPrint, new Point());

			string sText = "";
			if (dDateBeg.HasValue)
			{
				sText += ((DateTime)dDateBeg).ToString("dd.MM.yyyy");
				if (dDateEnd.HasValue)
					sText += " - ";
			}
			if (dDateEnd.HasValue)
				sText += ((DateTime)dDateEnd).ToString("dd.MM.yyyy");

			switch (tcList.SelectedTab.Name)
			{
				case "tabInputs":
					if (oReportInputs.MainTable.Rows.Count  == 0 || grdInputs.Rows.Count == 0) 
						return;

					DataTable dtInputs = CopyTable(oReportInputs.MainTable, "dtInputs", "IsNormal = true", "BrigadeName, UserName");

					repForSalary repInputs = new repForSalary("Приход: " + sText, "INPUTS", optGroupByBrigades.Checked);
					StartForm(new frmActiveReport(dtInputs, repInputs));
					break;

				case "tabTrafficsFrames":
					if (oReportTrafficsFrames.MainTable.Rows.Count == 0 || grdTrafficsFrames.Rows.Count == 0)
						return;

					DataTable dtTrafficsFrames = CopyTable(oReportTrafficsFrames.MainTable, "dtTrafficsFrames", "IsNormal = true", "BrigadeName, UserName");

					repForSalary repTrafficsFrames = new repForSalary("Съем/подъем паллет: " + sText, "TRAFFICSFRAMES", optGroupByBrigades.Checked);
					StartForm(new frmActiveReport(dtTrafficsFrames, repTrafficsFrames));
					break;

				case "tabOutputsTrafficsGoods":
					if (oReportOutputsTrafficsGoods.MainTable.Rows.Count == 0 || grdOutputsTrafficsGoods.Rows.Count == 0)
						return;

					DataTable dtOutputsTrafficsGoods = CopyTable(oReportOutputsTrafficsGoods.MainTable, "dtOutputsTrafficsGoods", "IsNormal = true", "BrigadeName, UserName");

					repForSalary repOutputsTrafficsGoods = new repForSalary("Набор - коробки: " + sText, "OUTPUTSTRAFFICSGOODS", optGroupByBrigades.Checked);
					StartForm(new frmActiveReport(dtOutputsTrafficsGoods, repOutputsTrafficsGoods));
					break;

				case "tabOutputsTrafficsFrames":
					if (oReportOutputsTrafficsFrames.MainTable.Rows.Count == 0 || grdOutputsTrafficsFrames.Rows.Count == 0)
						return;

					DataTable dtOutputsTrafficsFrames = CopyTable(oReportOutputsTrafficsFrames.MainTable, "dtOutputsTrafficsFrames", "IsNormal = true", "BrigadeName, UserName");

					repForSalary repOutputsTrafficsFrames = new repForSalary("Набор - паллеты: " + sText, "OUTPUTSTRAFFICSFRAMES", optGroupByBrigades.Checked);
					StartForm(new frmActiveReport(dtOutputsTrafficsFrames, repOutputsTrafficsFrames));
					break;

				case "tabOutputs":
					if (oReportOutputs.MainTable.Rows.Count == 0 || grdOutputs.Rows.Count == 0)
						return;

					DataTable dtOutputs = CopyTable(oReportOutputs.MainTable, "dtOutputs", "IsNormal = true", "BrigadeName, UserName");

					repForSalary repOutputs = new repForSalary("Выдача: " + sText, "OUTPUTS", optGroupByBrigades.Checked);
					StartForm(new frmActiveReport(dtOutputs, repOutputs));
					break;

				default:
					break;
			}
		}

	#endregion

	#region Terms clear

		private void btnClearTerms_Click(object sender, EventArgs e)
		{
			dtrDates.dtpBegDate.Value = DateTime.Now.Date.AddDays(-7);
			dtrDates.dtpEndDate.Value = DateTime.Now.Date;

			optGroupByUsers.Checked = true;

			btnUsersClear_Click(null, null);
			btnInputsTypesClear_Click(null, null);
			btnOutputsTypesClear_Click(null, null);

			tabInputs.IsNeedRestore =
			tabTrafficsFrames.IsNeedRestore =
			tabOutputsTrafficsGoods.IsNeedRestore =
			tabOutputsTrafficsFrames.IsNeedRestore =
			tabOutputs.IsNeedRestore =
				true;
		}
		
	#endregion

	}
}