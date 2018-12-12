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
	public partial class frmCellsMassMedicationNotFrames : RFMFormChild
	{
		protected Cell oCell;
		
		protected string _sAddress = "";

		protected int? nFixedOwnerID = null;
		protected int? nFixedGoodStateID = null;
		protected int? nFixedPackingID = null;
		protected string sFixedOwnerName = "";
		protected string sFixedGoodStateName = "";
		protected string sFixedPackingName = "";

		DataTable dtCellsContents;

		public int? _SelectedPackingID;
		public int? _SelectedID;
		public string _SelectedText;

		private Color cDefaultBackColor;

		protected bool _bLoaded = false; 


		public frmCellsMassMedicationNotFrames(int nCellID)
		{
			oCell = new Cell();
		
			if (oCell.ErrorNumber != 0)
			{
				IsValid = false;
			}

			if (IsValid)
			{
				InitializeComponent();
				oCell.ID = nCellID;
			}
		}
		
		private void frmCellsMassMedicationNotFrames_Load(object sender, EventArgs e)
		{
			bool lResult = true; 

			// параметры ячейки
			oCell.FillData();
			if (oCell.ErrorNumber != 0 || oCell.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о ячейке...");
				Dispose();
			}

			DataRow r = oCell.MainTable.Rows[0];
			if (r == null)
			{
				RFMMessage.MessageBoxError("Не определена ячейка...");
				lResult = false;
			}

			if (lResult)
			{
				// работаем только с неконтейнерными ячейками
				if (r["ForFrames"] != DBNull.Value && (bool)r["ForFrames"])
				{
					RFMMessage.MessageBoxError("Ячейка предназначена для контейнеров...");
					lResult = false;
				}
			}

			if (lResult)
			{
				_sAddress = r["Address"].ToString();
				lblCellID.Text = _sAddress + " (код " + r["ID"].ToString() + ")";

				if (r["FixedOwnerID"] != DBNull.Value && r["FixedOwnerID"] != null)
				{
					nFixedOwnerID = Convert.ToInt32(r["FixedOwnerID"]);
					txtFixedOwnerName.Text = sFixedOwnerName = r["FixedOwnerName"].ToString();
				}
				if (r["FixedGoodStateID"] != DBNull.Value && r["FixedGoodStateID"] != null)
				{
					nFixedGoodStateID = Convert.ToInt32(r["FixedGoodStateID"]);
					txtFixedGoodStateName.Text = sFixedGoodStateName = r["FixedGoodStateName"].ToString();
				}
				if (r["FixedPackingID"] != DBNull.Value && r["FixedPackingID"] != null)
				{
					nFixedPackingID = Convert.ToInt32(r["FixedPackingID"]);
					txtFixedPackingName.Text = sFixedPackingName = r["PackingAlias"].ToString(); 
				}

				// содержимое ячейки 
				oCell.FillTableMassMedicationNotFrames((int)oCell.ID);
				if (oCell.ErrorNumber == 0 && oCell.DS.Tables["TableMassMedicationNotFrames"] != null)
				{
					dtCellsContents = oCell.DS.Tables["TableMassMedicationNotFrames"];
					if (dtCellsContents.Rows.Count == 0)
					{
						RFMMessage.MessageBoxError("Ячейка пуста...");
						lResult = false; 
					}
				}
				else 
				{
					lResult = false;
				}
			}

			if (!lResult)
			{
				Dispose();
			}

			foreach (DataGridViewColumn c in grdData.Columns)
			{
				string sColumnName = c.Name.ToUpper();
				if (sColumnName.Contains("REST") && sColumnName.Contains("AFTER"))
				{
					c.ReadOnly = false;
				}
				else
				{
					c.ReadOnly = true;
				}
			}
			grcRestBox_Before.DefaultCellStyle.Format =
			grcRestBox_After.DefaultCellStyle.Format =
				"### ### ### ###";
			/*
			grcRestBox_After.IsAllowDecimal = false;
			grcRestBox_After.IsAllowNegative = false;
			grcRestQnt_After.IsAllowDecimal = true;
			grcRestQnt_After.IsAllowNegative = false;
			*/ 

			grcRestBox_After.DecimalPlaces = 0;
			grcRestBox_After.Minimum = 0;
			grcRestQnt_After.DecimalPlaces = 0;
			grcRestQnt_After.Minimum = 0;

			grcRestBox_After.HeaderCell.Style.Font = new Font(grdData.Font, FontStyle.Bold);
			grcRestQnt_After.HeaderCell.Style.Font = new Font(grdData.Font, FontStyle.Bold);

			cDefaultBackColor = grdData.DefaultCellStyle.BackColor; 

			grdData_Restore();
			grdData.Select();

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
			int nCellID = Convert.ToInt32(oCell.ID);

			// всякие проверки
			if (dtCellsContents.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("В ячейке нет ни одного товара.\nНечего сохранять...");
				return;
			}

			int nCntChanges = 0;
			foreach (DataRow r in dtCellsContents.Rows)
			{
				if (Convert.ToDecimal(r["Qnt_After"]) != Convert.ToDecimal(r["Qnt_Before"]) ||
					Convert.IsDBNull(r["OwnerID_After"]) && !Convert.IsDBNull(r["OwnerID_Before"]) || 
					!Convert.IsDBNull(r["OwnerID_After"]) && Convert.IsDBNull(r["OwnerID_Before"]) || 
					!Convert.IsDBNull(r["OwnerID_After"]) && !Convert.IsDBNull(r["OwnerID_Before"]) && Convert.ToInt32(r["OwnerID_Before"]) != Convert.ToInt32(r["OwnerID_After"]) ||  
					Convert.ToInt32(r["GoodStateID_Before"]) != Convert.ToInt32(r["GoodStateID_After"]) )
				{
					nCntChanges++;
				}
			}
			if (nCntChanges == 0)
			{
				RFMMessage.MessageBoxError("Нет изменений в содержимом ячейки.\nНечего сохранять...");
				return;
			}

			string sText = "Ячейка " + _sAddress + "\n\n" +  
				"В ячейке изменяется содержимое для " + RFMPublic.RFMUtilities.Declen(nCntChanges, "товара", "товаров", " товаров") + "." + 
				"\n\nСохранить?";
			if (RFMMessage.MessageBoxYesNo(sText) == DialogResult.Yes)
			{
				int? nUserID = ((RFMFormMain)Application.OpenForms[0]).UserID; 
				string sNoteManual = txtNoteManual.Text.Trim();
				// собственно сохранение
				oCell.MassMedicationNotFrames(nCellID, dtCellsContents, nUserID, sNoteManual);
				//
				if (oCell.ErrorNumber == 0)
				{
					DialogResult = DialogResult.Yes;
					Dispose();
				}
			}
		}

	#region Restore

		private void grdData_Restore()
		{
			grdData.Restore(dtCellsContents);
		}

	#endregion

	#region RowEnter, CellFormatting
				
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
					case "grcRestQnt_After":
					case "grcRestQnt_Before":
					case "grcInBox":
						e.CellStyle.Format = "### ### ### ###";
						break;
				}
				return;
			}

			DataGridViewRow r = grd.Rows[e.RowIndex];
			switch (grd.Columns[e.ColumnIndex].Name)
			{
				case "grcRestQnt_After":
				case "grcRestQnt_Before":
				case "grcInBox":
					if (!Convert.IsDBNull(r.Cells["grcWeighting"].Value) &&
						Convert.ToBoolean(r.Cells["grcWeighting"].Value) ||
						!Convert.IsDBNull(e.Value) && Convert.ToDecimal(e.Value) != Convert.ToInt32(e.Value))
						e.CellStyle.Format = "### ### ### ##0.000";
					else
						e.CellStyle.Format = "### ### ### ###";
					//if (Convert.IsDBNull(e.Value) || e.Value == null || (decimal)e.Value == 0) 
					//	e.Value = "";
					break;
			}
			if (!Convert.ToBoolean(r.Cells["grcActual"].Value))
			{
				e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Italic);
			}
			if (Convert.ToDecimal(r.Cells["grcQnt_After"].Value) != Convert.ToDecimal(r.Cells["grcQnt_Before"].Value))
			{
				grd.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightPink;
			}
			else
			{
				grd.Rows[e.RowIndex].DefaultCellStyle.BackColor = cDefaultBackColor;
			}
		}

		private void grdData_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
			if (grdData.Columns[e.ColumnIndex].Name.Contains("Qnt"))
			{
				DataRow dr = ((DataRowView)((DataGridViewRow)grdData.CurrentRow).DataBoundItem).Row;
				decimal nInBox = (decimal)dr["InBox"];
				((RFMDataGridViewTextBoxNumericColumn)grdData.Columns[e.ColumnIndex]).DecimalPlaces =
					(nInBox != (int)nInBox || (bool)dr["Weighting"]) ? 3 : 0;
			}
		}

		private void grdData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			RFMDataGridView grd = grdData;
			if (grd.DataSource == null || grd.CurrentRow == null || grd.RowCount == 0 || grd.Rows[e.RowIndex] == null)
				return;

			string sColName = grd.Columns[e.ColumnIndex].Name;
			DataGridViewRow grdR = grd.Rows[e.RowIndex];
			DataRow dr = ((DataRowView)grdR.DataBoundItem).Row;
			if (sColName == "grcRestQnt_After" || sColName == "grcRestBox_After")
			{
				if (dr != null)
				{
					decimal nInBox = 0, nRestQnt = 0; int nRestBox = 0;
					if (!Convert.IsDBNull(grdR.Cells["grcRestBox_After"].Value) && grdR.Cells["grcRestBox_After"].Value != null)
					{
						nRestBox = Convert.ToInt32(grdR.Cells["grcRestBox_After"].Value);
					}
					if (!Convert.IsDBNull(grdR.Cells["grcRestQnt_After"].Value) && grdR.Cells["grcRestQnt_After"].Value != null)
					{
						nRestQnt = Convert.ToDecimal(grdR.Cells["grcRestQnt_After"].Value);
					}
					nInBox = Convert.ToDecimal(dr["InBox"]);
					dr["RestQnt_After"] = nRestQnt;
					dr["RestBox_After"] = nRestBox;
					dr["Qnt_After"] = nRestBox * nInBox + nRestQnt;
					dr["Box_After"] = nRestQnt / nInBox;
					//grdData.CommitChanges();
				}
			}
		}

		private void grdData_CellValidated(object sender, DataGridViewCellEventArgs e)
		{
			RFMDataGridView grd = grdData;
			string sColName = grd.Columns[e.ColumnIndex].Name;
			DataGridViewRow grdR = grd.Rows[e.RowIndex];

			if (sColName == "grcRestQnt_After")
			{
				if (grdR.Cells["grcRestQnt_After"].Value == DBNull.Value)
				{
					grdR.Cells["grcRestQnt_After"].Value = 0;
				}
				if (Convert.ToDecimal(grdR.Cells["grcRestQnt_After"].Value) < 0)
				{
					RFMMessage.MessageBoxError("Введено неверное значение!");
					grdR.Cells["grcRestQnt_After"].Value = 0;
				}
			}
			
			if (sColName == "grcRestBox_After") 
			{
				if (grdR.Cells["grcRestBox_After"].Value == DBNull.Value)
				{
					grdR.Cells["grcRestBox_After"].Value = 0;
				}
				if (Convert.ToDecimal(grdR.Cells["grcRestBox_After"].Value) < 0)
				{
					RFMMessage.MessageBoxError("Введено неверное значение!");
					grdR.Cells["grcRestBox_After"].Value = 0;
				}
				if (Convert.ToInt32(grdR.Cells["grcRestBox_After"].Value) != 0 && 
					(grdR.Cells["grcWeighting"].Value == DBNull.Value ||
					 Convert.ToBoolean(grdR.Cells["grcWeighting"].Value)))
				{
					RFMMessage.MessageBoxError("Для весового товара вводится только вес (в колонке \"штук\")!");
					grdR.Cells["grcRestBox_After"].Value = 0;
				}
			}
		}

	#endregion

	#region GridButtons

		private void btnEdit_Click(object sender, EventArgs e)
		{
			if (grdData.DataSource == null || grdData.CurrentRow == null || grdData.RowCount == 0)
				return;

			mnuEdit.Show(btnEdit, new Point());
		}

		private void mniChooseGoodState_Click(object sender, EventArgs e)
		{
			DataGridViewRow grdR = grdData.CurrentRow;
			DataRow dr = ((DataRowView)grdR.DataBoundItem).Row;

			if (nFixedGoodStateID != null)
			{
				if (RFMMessage.MessageBoxYesNo("Ячейка закреплена за состоянием\n" + sFixedGoodStateName + "!\n" +
					"Все-таки сменить состояние?") != DialogResult.Yes)
					return;
				//dr["GoodStateID_After"] = nFixedGoodStateID;
				//dr["GoodStateName_After"] = sFixedGoodStateName;
			}

			_SelectedID = null;
			GoodState oGoodStateTemp = new GoodState();
			oGoodStateTemp.FillData();
			if (oGoodStateTemp.ErrorNumber == 0 && oGoodStateTemp.MainTable != null && oGoodStateTemp.MainTable.Rows.Count > 0)
			{
				if (StartForm(new frmSelectID(this, oGoodStateTemp.MainTable, "ID, Name, Actual", "ID, Состояние, Акт.")) == DialogResult.Yes)
				{
					if (_SelectedID != null)
					{
						// нет ли уже записи для того же товара с тем же владельцем?
						// текущая запись 
						int nCellContentID = Convert.ToInt32(dr["ID"]);
						int nPackingCurID = Convert.ToInt32(dr["PackingID"]);
						int nGoodStateCurID = Convert.ToInt32(_SelectedID); // 
						int? nOwnerCurID = null;
						if (!Convert.IsDBNull(dr["OwnerID_After"]))
							nOwnerCurID = Convert.ToInt32(dr["OwnerID_After"]);
						// перебираем записи
						int nPackingID, nGoodStateID;
						int? nOwnerID = null; 
						foreach (DataRow drC in ((DataTable)grdData.GridSource.DataSource).Rows)
						{
							nPackingID = Convert.ToInt32(drC["PackingID"]);
							nGoodStateID = Convert.ToInt32(drC["GoodStateID_After"]);
							nOwnerID = null;
							if (!Convert.IsDBNull(drC["OwnerID_After"]))
								nOwnerID = Convert.ToInt32(drC["OwnerID_After"]);

							// если что-то отличается или это та же запись - идем дальше
							if (nPackingID != nPackingCurID ||
								nGoodStateID != nGoodStateCurID ||
								nOwnerID.HasValue && !nOwnerCurID.HasValue ||
								!nOwnerID.HasValue && nOwnerCurID.HasValue ||
								nOwnerID.HasValue && nOwnerCurID.HasValue && nOwnerID != nOwnerCurID ||
								Convert.ToInt32(drC["ID"]) == nCellContentID)
								continue;

							RFMMessage.MessageBoxError("Уже есть запись о таком товаре/состоянии/хранителе...");
							return;
						}

						dr["GoodStateID_After"] = nGoodStateCurID;
						dr["GoodStateName_After"] = _SelectedText;
					}
				}
			}
			_SelectedID = null;
		}

		private void mniChooseOwner_Click(object sender, EventArgs e)
		{
			DataGridViewRow grdR = grdData.CurrentRow;
			DataRow dr = ((DataRowView)grdR.DataBoundItem).Row;
			if (nFixedOwnerID.HasValue)
			{
				if (RFMMessage.MessageBoxYesNo("Ячейка закреплена за хранителем\n" + sFixedOwnerName + "!\n" +
					"Все-таки сменить хранителя?") != DialogResult.Yes)
					return;
				//dr["OwnerID_After"] = nFixedOwnerID;
				//dr["OwnerName_After"] = sFixedOwnerName;
			}
			_SelectedID = null;

			Partner oOwnerTemp = new Partner();
			oOwnerTemp.FillDataOwners();
			if (oOwnerTemp.ErrorNumber == 0 && oOwnerTemp.MainTable != null && oOwnerTemp.MainTable.Rows.Count > 0)
			{
				if (StartForm(new frmSelectID(this, oOwnerTemp.MainTable, "ID, Name, Actual", "ID, Владелец, Акт.")) == DialogResult.Yes)
				{
					if (_SelectedID != null)
					{
						// нет ли уже записи для того же товара с тем же владельцем?
						// текущая запись 
						int nCellContentID = Convert.ToInt32(dr["ID"]);
						int nPackingCurID = Convert.ToInt32(dr["PackingID"]);
						int nGoodStateCurID = Convert.ToInt32(dr["GoodStateID_After"]);
						int? nOwnerCurID = Convert.ToInt32(_SelectedID);
						// для работы с хранителями добавляется запись "общий" с ID = 0.
						// на самом деле это Null
						if (nOwnerCurID == 0)
						{
							RFMMessage.MessageBoxError("Для установки значения \"Общий хранитель\" используйте пункт \"Очистить хранителя\".");
							return;
						}
						// перебираем записи
						int nPackingID, nGoodStateID; 
						int? nOwnerID = null;
						foreach (DataRow drC in ((DataTable)grdData.GridSource.DataSource).Rows)
						{
							nPackingID = Convert.ToInt32(drC["PackingID"]);
							nGoodStateID = Convert.ToInt32(drC["GoodStateID_After"]);
							nOwnerID = null;
							if (!Convert.IsDBNull(drC["OwnerID_After"]))
								nOwnerID = Convert.ToInt32(drC["OwnerID_After"]);

							// если что-то отличается или это та же запись - идем дальше
							if (nPackingID != nPackingCurID || 
								nGoodStateID != nGoodStateCurID ||
								!nOwnerID.HasValue ||
								nOwnerID.HasValue && nOwnerID != nOwnerCurID ||
								Convert.ToInt32(drC["ID"]) == nCellContentID)
								continue;

							RFMMessage.MessageBoxError("Уже есть запись о таком товаре/состоянии/хранителе...");
							return;
						}

						dr["OwnerID_After"] = nOwnerCurID;
						dr["OwnerName_After"] = _SelectedText;
					}
				}
			}
			_SelectedID = null;
		}

		private void mniClearOwner_Click(object sender, EventArgs e)
		{
			DataGridViewRow grdR = grdData.CurrentRow;
			DataRow dr = ((DataRowView)grdR.DataBoundItem).Row;
			if (nFixedOwnerID.HasValue)
			{
				if (RFMMessage.MessageBoxYesNo("Ячейка закреплена за хранителем\n" + sFixedOwnerName + "!\n" +
					"Все-таки очистить указание на хранителя?") != DialogResult.Yes)
					return;
				//dr["OwnerID_After"] = nFixedOwnerID;
				//dr["OwnerName_After"] = sFixedOwnerName;
			}

			// нет ли уже записи для того же товара с тем же владельцем?
			// текущая запись 
			int nCellContentID = Convert.ToInt32(dr["ID"]);
			int nPackingCurID = Convert.ToInt32(dr["PackingID"]);
			int nGoodStateCurID = Convert.ToInt32(dr["GoodStateID_After"]);
			// перебираем записи
			int nPackingID, nGoodStateID; 
			int? nOwnerID = null;
			foreach (DataRow drC in ((DataTable)grdData.GridSource.DataSource).Rows)
			{
				nPackingID = Convert.ToInt32(drC["PackingID"]);
				nGoodStateID = Convert.ToInt32(drC["GoodStateID_After"]);
				nOwnerID = null;
				if (!Convert.IsDBNull(drC["OwnerID_After"]))
					nOwnerID = Convert.ToInt32(drC["OwnerID_After"]);

				// если что-то отличается или это та же запись - идем дальше
				if (nPackingID != nPackingCurID || 
					nGoodStateID != nGoodStateCurID ||
					nOwnerID.HasValue ||
					Convert.ToInt32(drC["ID"]) == nCellContentID)
					continue;

				RFMMessage.MessageBoxError("Уже есть запись о таком товаре/состоянии для \"общего товара\"...");
				return;
			}

			dr["OwnerID_After"] = DBNull.Value;
			dr["OwnerName_After"] = "";
		}

	#endregion

	}
}