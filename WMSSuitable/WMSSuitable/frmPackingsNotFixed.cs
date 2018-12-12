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
	public partial class frmPackingsNotFixed : RFMFormChild
	{
		Good oPacking;
		DataTable dt;
		string sInputsList = null;
		string sOutputsList = null;
		string sPackingsList = null;

		protected Partner oOwner;
		protected GoodState oGoodState;

		public int? _SelectedID = null;
		public string _SelectedText = "";

		public frmPackingsNotFixed(string _sPackingsList, string _sInputsList, string _sOutputsList)
		{
			oPacking = new Good();
			if (oPacking.ErrorNumber != 0)
			{
				IsValid = false;
			}

			oOwner = new Partner();
			oGoodState = new GoodState();
			if (oOwner.ErrorNumber != 0 ||
				oGoodState.ErrorNumber != 0)
			{
				IsValid = false;
			}

			if (IsValid)
			{
				InitializeComponent();

				sInputsList = _sInputsList;
				sOutputsList = _sOutputsList;
				sPackingsList = _sPackingsList; 
			}
		}

		private void frmPackingsNotFixed_Load(object sender, EventArgs e)
		{
			if (!cboOwner_Restore() || !cboGoodState_Restore())
			{
				RFMMessage.MessageBoxError("Ошибка при заполнении классификаторов...");
				Dispose();
				return;
			}

			cboOwner.SelectedIndex = -1;
			cboGoodState.SelectedIndex = 0;

			btnRestore_Click(null, null);
			grdData.Select();
		}

		#region Restore

		#region Combo

		private bool cboOwner_Restore()
		{
			oOwner.FilterOwner = true;
			oOwner.FilterSeparatePicking = true;
			if (cboOwner.IsActualOnly)
				oOwner.FilterActual = true;
			else
				oOwner.FilterActual = null;
			oOwner.FillData();
			cboOwner.DataSource = oOwner.MainTable;
			cboOwner.ValueMember = oOwner.ColumnID;
			cboOwner.DisplayMember = oOwner.ColumnName;
			return (oOwner.ErrorNumber == 0);
		}

		private bool cboGoodState_Restore()
		{
			oGoodState.FillData();
			cboGoodState.DataSource = oGoodState.MainTable;
			cboGoodState.ValueMember = oGoodState.ColumnID;
			cboGoodState.DisplayMember = oGoodState.ColumnName;
			return (oGoodState.ErrorNumber == 0);
		}

		private void btnOwnerClear_Click(object sender, EventArgs e)
		{
			cboOwner.SelectedIndex = -1;
			cboOwner.SelectedValue = -1;
		}

		#endregion Combo

		private bool grdData_Restore()
		{
			bool? bPackingsActual = null;
			bool? bGoodsActual = null;
			if (chkPackingsActual.Checked)
				bPackingsActual = true;
			if (chkGoodsActual.Checked)
				bGoodsActual = true;

			int? nOwnerID = null;
			if (cboOwner.SelectedValue != null && cboOwner.SelectedIndex >= 0)
				nOwnerID = (int)cboOwner.SelectedValue;
			int? nGoodStateID = null;
			if (cboGoodState.SelectedValue != null && cboGoodState.SelectedIndex >= 0)
				nGoodStateID = Convert.ToInt32(cboGoodState.SelectedValue);

			oPacking.ClearError();
			oPacking.FillTablePackingsNotFixed(sPackingsList,
					bPackingsActual, bGoodsActual,
					sInputsList, sOutputsList, 
					nGoodStateID, nOwnerID);
			if (oPacking.ErrorNumber != 0 || oPacking.DS.Tables["TablePackingsNotFixed"] == null)
				return (false);

			dt = oPacking.DS.Tables["TablePackingsNotFixed"];
			dt.PrimaryKey = new DataColumn[] { dt.Columns["PackingID"] };

			dt.Columns.Add("CellID");
			dt.Columns.Add("Address");
			dt.Columns.Add("StoreZoneName");
			grdData.Restore(dt);

			return (oPacking.ErrorNumber == 0);
		}

		#endregion

		#region Grid

		private void grdData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (grdData.DataSource == null)
				return;

			// неактуальные - курсивом
			DataRow r = ((DataRowView)grdData.Rows[e.RowIndex].DataBoundItem).Row;
			if (!Convert.ToBoolean(r["GoodActual"]) || !Convert.ToBoolean(r["PackingActual"]))
				e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Italic);

			// весовые товары или товары с нецелым вложением в коробоку
			switch (grdData.Columns[e.ColumnIndex].Name)
			{
				case "grcInBox":
					if (!Convert.IsDBNull(r["Weighting"]) &&
						Convert.ToBoolean(r["Weighting"]) ||
						!Convert.IsDBNull(e.Value) && Convert.ToDecimal(e.Value) != Convert.ToInt32(e.Value))
					{
						e.CellStyle.Format = "### ### ### ###.000";
					}
					else
					{
						e.CellStyle.Format = "### ### ### ###";
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

		private void btnFix_Click(object sender, EventArgs e)
		{
			if (grdData.Rows.Count == 0 ||
				dt == null ||
				dt.Rows.Count == 0 ||
				grdData.CurrentRow == null)
				return;

			if (cboGoodState.SelectedIndex < 0 || cboGoodState.SelectedValue == null)
			{
				RFMMessage.MessageBoxError("Не указано состояние товара для закрепления ячейки...");
				return;
			}

			// текущий товар
			DataRow r = ((DataRowView)grdData.CurrentRow.DataBoundItem).Row;
			int nPackingID = Convert.ToInt32(r["PackingID"]); 
			int? nCellID = null;

			// список свободных ячеек
			Cell oCell = new Cell();
			oCell.FilterActual = true;
			oCell.FilterLocked = false;
			oCell.FilterStoreZoneTypeForPicking = true;
			oCell.FilterHasCellContent = false;
			oCell.FilterTrafficsFromExists = false;
			oCell.FilterTrafficsToExists = false;
			oCell.FillData();
			if (oCell.ErrorNumber != 0 || oCell.MainTable == null)
			{
				RFMMessage.MessageBoxError("Ошибка при получении списка ячеек...");
				return;
			}
			if (oCell.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Не найдены подходящие ячейки пикинга...");
				return;
			}

			DataTable dtCells = CopyTable(oCell.MainTable, "dtCells", ((chkCellsFreeOnly.Checked) ? "FixedPackingID is Null" : ""), "StoreZoneName, Address");

			// 
			_SelectedID = null;
			if (StartForm(new frmSelectID(this, dtCells, "Address, StoreZoneName, TemperatureMode, PackingAlias", "Адрес, Зона, T, Товар", false)) == DialogResult.Yes)
			{
				if (_SelectedID.HasValue)
				{
					nCellID = _SelectedID;
				}
			}
			_SelectedID = null;
			if (nCellID.HasValue)
			{
				DataColumn[] pk = new DataColumn[1];
				pk[0] = dtCells.Columns["ID"];
				dtCells.PrimaryKey = pk;

				DataRow c = dtCells.Rows.Find(nCellID);
				int? nFixedPackingOldID = null;
				if (c != null) 
				{
					// температурный режим
					string sGoodTemperatureMode = r["TemperatureMode"].ToString(); // товар
					string sCellTemperatureMode = c["TemperatureMode"].ToString(); // ячейка
					if (sCellTemperatureMode != null)
					{
						if (sCellTemperatureMode != sGoodTemperatureMode)
						{
							RFMMessage.MessageBoxError("Температурный режим выбранной ячейки (" + sCellTemperatureMode + ") не совпадает " + 
								"с требуемым температурным режимом для товара \"" + r["PackingAlias"].ToString() + "\" (" + sGoodTemperatureMode + ")...");
							return; 
						}
					}

					// 
					if (!Convert.IsDBNull(c["FixedPackingID"]) &&
						Convert.ToInt32(c["FixedPackingID"]) != nPackingID)
					{
						nFixedPackingOldID = Convert.ToInt32(c["FixedPackingID"]);
						if (RFMMessage.MessageBoxYesNo("Выбранная ячейка закреплена за товаром\n" +
								"\"" + c["PackingAlias"].ToString() + "\".\n" +
								"После закрепления данный товар останется без закрепления за ячейкой пикинга.\n\n" +
								"Продолжить?") != DialogResult.Yes)
							return;
					}

					// можно закреплять
					int? nOwnerID = null;
					if (cboOwner.SelectedValue != null && cboOwner.SelectedIndex >= 0)
						nOwnerID = (int)cboOwner.SelectedValue;
					int? nGoodStateID = null;
					if (cboGoodState.SelectedValue != null && cboGoodState.SelectedIndex >= 0)
						nGoodStateID = Convert.ToInt32(cboGoodState.SelectedValue);

					oPacking.ClearError();
					oPacking.FixedSave(nPackingID, (int)nCellID, nGoodStateID, nOwnerID);
					if (oPacking.ErrorNumber != 0)
					{
						RFMMessage.MessageBoxError("Ошибка при сохранении фиксированного закрепления товара...");
						return;
					}

					// показали текущее закрепление
					r["CellID"] = nCellID;
					r["Address"] = c["Address"].ToString();
					r["StoreZoneName"] = c["StoreZoneName"].ToString();

					// убрали из показа старое закрепление для другого товара, если оно тут было 
					if (nFixedPackingOldID.HasValue)
					{
						DataRow pOld = dt.Rows.Find(nFixedPackingOldID);
						if (pOld != null)
						{
							pOld["CellID"] = null;
							pOld["Address"] = "";
							pOld["StoreZoneName"] = "";
						}
					}
					grdData.Refresh();
				}
			}
		}

		#endregion Buttons
	
	}
}
