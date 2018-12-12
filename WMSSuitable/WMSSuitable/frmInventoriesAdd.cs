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
	public partial class frmInventoriesAdd : RFMFormChild
	{
		private Inventory oInventory;
		private Cell oCells;

		public string _SelectedCellsIDList;
		public string _SelectedCellAddressText;
		private string sSelectedCellsIDList = "";

		public string _SelectedPackingIDList;
		public string _SelectedPackingAliasText;
		private string sSelectedPackingsIDList = "";

		DataTable dt = null; // источник данных дл€ Grid

		public frmInventoriesAdd(int nInventoryID)
		{
			oInventory = new Inventory();
			oCells = new Cell();
			if (oInventory.ErrorNumber != 0 ||
				oCells.ErrorNumber != 0)
			{
				IsValid = false;
			}
			oInventory.ID = nInventoryID;

			if (IsValid)
			{
				InitializeComponent();
			}
		}

		private void frmInventoriesAdd_Load(object sender, EventArgs e)
		{
			bool bResult = true;

			btnClear_Click(null, null);

			grdCells.IsCheckerShow = true;

			chkDateValidPercent_CheckedChanged(null, null);
			chkRestBoxes_CheckedChanged(null, null);
			chkShowContents_CheckedChanged(null, null);

			foreach (DataGridViewColumn c in grdCells.Columns)
			{
				if (!c.Name.Contains("Marked"))
					c.ReadOnly = true;
			}

			if (bResult)
			{
				oInventory.FillData();
				if (oInventory.ErrorNumber != 0 || oInventory.MainTable == null)
				{
					RFMMessage.MessageBoxError("ќшибка получени€ данных о ревизии...");
					bResult = false;
				}
			}
			if (bResult)
			{
				if (oInventory.ID == 0)
				{
					Text = Text + ": добавление";

					if (oInventory.MainTable.Rows.Count > 0)
					{
						RFMMessage.MessageBoxError("ќшибка получени€ данных о новой ревизии...");
						bResult = false;
					}
					else
					{
						oInventory.MainTable.Rows.Add();
					}
				}
				else
				{
					Text = Text + " (" + oInventory.ID.ToString() + ")";

					if (oInventory.MainTable.Rows.Count != 1)
					{
						RFMMessage.MessageBoxError("ќшибка получени€ данных о ревизии с кодом " + oInventory.ID.ToString() + "...");
						bResult = false;
					}
					else
					{
						DataRow r = oInventory.MainTable.Rows[0];
						dtpDateInventory.Value = Convert.ToDateTime(r["DateInventory"]);
						txtNote.Text = r["Note"].ToString();
					}
				}
			}
			txtNote.Select();

			if (!bResult)
			{
				Dispose();
			}
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
			oInventory.ClearError();

			// отмеченные €чейки
			DataTable dt = new DataTable();
			dt.Columns.Add("CellID", Type.GetType("System.Int32"));
			foreach (DataGridViewRow r in grdCells.Rows)
			{ 
				DataRow rd = ((DataRowView)r.DataBoundItem).Row;
				if (Convert.ToBoolean(rd["IsMarked"]))
				{ 
					dt.Rows.Add(rd["CellID"]);
				}
			}
			if (dt.Rows.Count == 0)
			{
				if (RFMMessage.MessageBoxYesNo("Ќе выбрано ни одной €чейки...\n¬се-таки сохранить?") != DialogResult.Yes)
					return;
			}

			DataRow r_ = oInventory.MainTable.Rows[0];
			r_["DateInventory"] = dtpDateInventory.Value.Date;
			r_["Note"] = txtNote.Text.Trim();

			oInventory.SaveData((int)oInventory.ID, dt);

			if (oInventory.ErrorNumber == 0)
			{
				MotherForm.GotParam = new object[] { (int)oInventory.ID };

				DialogResult = DialogResult.Yes;
				Dispose();
			}
		}

		private void grdCells_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (grdCells.DataSource == null)
				return;

			if (grdCells.IsStatusRow(e.RowIndex))
			{
				switch (grdCells.Columns[e.ColumnIndex].Name)
				{
					case "grcQnt":
					case "grcInBox":
						e.CellStyle.Format = "### ### ### ###";
						break;
				}
				return;
			}

			DataGridViewRow r = grdCells.Rows[e.RowIndex];
			switch (grdCells.Columns[e.ColumnIndex].Name)
			{
				case "grcQnt":
				case "grcInBox":
					if (!Convert.IsDBNull(r.Cells["grcWeight"].Value) &&
						Convert.ToBoolean(r.Cells["grcWeight"].Value) ||
						!Convert.IsDBNull(e.Value) && Convert.ToDecimal(e.Value) != Convert.ToInt32(e.Value))
						e.CellStyle.Format = "### ### ### ##0.000";
					else
						e.CellStyle.Format = "### ### ### ###";
					break;
			}

		}

	#region Filters
	
		private void btnFilter_Click(object sender, EventArgs e)
		{
			grdCells_Restore();
			grdCells.Select();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			btnCellsClear_Click(null, null);
			btnPackingsClear_Click(null, null);
			chkDateValidPercent.Checked = false;
			chkRestBoxes.Checked = false;
		}

		#region Cells

		private void btnCellsChoose_Click(object sender, EventArgs e)
		{
			_SelectedCellsIDList = null;
			_SelectedCellAddressText = "";

			if (StartForm(new frmSelectOneCell(this, true)) == DialogResult.Yes)
			{
				if (_SelectedCellsIDList == null || !_SelectedCellsIDList.Contains(","))
				{
					btnCellsClear_Click(null, null);
					return;
				}

				sSelectedCellsIDList = "," + _SelectedCellsIDList;


				txtCellsChoosen.Text = _SelectedCellAddressText;
				ttToolTip.SetToolTip(txtCellsChoosen, txtCellsChoosen.Text);
			}

			_SelectedCellsIDList = null;
			_SelectedCellAddressText = "";
		}

		private void btnCellsClear_Click(object sender, EventArgs e)
		{
			ttToolTip.SetToolTip(txtCellsChoosen, "не выбраны");
			sSelectedCellsIDList = "";
			txtCellsChoosen.Text = "";
		}

		#endregion Cells

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

		#endregion Packings

		#region Checkers

		private void chkDateValidPercent_CheckedChanged(object sender, EventArgs e)
		{
			numDateValidPercent.Enabled = chkDateValidPercent.Checked;
		}

		private void chkRestBoxes_CheckedChanged(object sender, EventArgs e)
		{
			numRestBoxes.Enabled = chkRestBoxes.Checked;
		}

		#endregion Checkes

	#endregion Filters 

	#region Restore

		private void grdCells_Restore()
		{
			WaitOn(this);

			oCells.ClearFilters();
			oCells.ID = null;
			oCells.IDList = null;

			// собираем услови€
			oCells.FilterActual = true;
			// выбранные €чейки
			if (sSelectedCellsIDList.Length > 0)
			{
				oCells.IDList = sSelectedCellsIDList;
			}
			// выбранные товары -  в €чейках
			if (sSelectedPackingsIDList.Length > 0)
			{
				oCells.CellsContents_FilterPackingsList = sSelectedPackingsIDList;
			}
			// срок годности 
			if (chkDateValidPercent.Checked)
			{
				oCells.CellsContents_FilterCheckDateValid = Convert.ToInt32(numDateValidPercent.Value);
			}

			grdCells.DataSource = null;
			oCells.FillData();
			if (oCells.MainTable.Columns["InFilter"] == null)
			{
				oCells.MainTable.Columns.Add("InFilter", Type.GetType("System.Boolean"));
			}
			if (chkShowContents.Checked)
			{
				if (oCells.MainTable.Columns["GoodAlias"] == null)
					oCells.MainTable.Columns.Add("GoodAlias", Type.GetType("System.String"));
				if (oCells.MainTable.Columns["Weighting"] == null)
					oCells.MainTable.Columns.Add("Weighting", Type.GetType("System.Boolean"));
				if (oCells.MainTable.Columns["InBox"] == null)
					oCells.MainTable.Columns.Add("InBox", Type.GetType("System.Decimal"));
				if (oCells.MainTable.Columns["Qnt"] == null)
					oCells.MainTable.Columns.Add("Qnt", Type.GetType("System.Decimal"));
				if (oCells.MainTable.Columns["Boxes"] == null)
					oCells.MainTable.Columns.Add("Boxes", Type.GetType("System.Decimal"));
				if (oCells.MainTable.Columns["DateValid"] == null)
					oCells.MainTable.Columns.Add("DateValid", Type.GetType("System.DateTime"));
			}

			// остаток кор.
			if (chkRestBoxes.Checked || chkShowContents.Checked || sSelectedPackingsIDList.Length > 0)
			{
				decimal nRestBoxes = numRestBoxes.Value;
				Cell oCellTemp = new Cell();
				foreach (DataRow r in oCells.MainTable.Rows)
				{
					// €чейки хранени€
					if (chkForStorageOnly.Checked && !Convert.ToBoolean(r["ForStorage"]))
						continue;

					oCellTemp.ID = Convert.ToInt32(r["ID"]);
					oCellTemp.FillTableCellsContents(oCellTemp.ID, false);
					if (oCellTemp.TableCellsContents.Columns["InFilter"] == null)
					{
						oCellTemp.TableCellsContents.Columns.Add("InFilter", Type.GetType("System.Boolean"));
					}
					if (oCellTemp.TableCellsContents.Rows.Count > 0)
					{ 
						// есть еще другие товары в €чейке
						// оставить только те, которые в пределах фильтра
						foreach (DataRow rcc in oCellTemp.TableCellsContents.Rows)
						{
							rcc["InFilter"] = true;
							if (sSelectedPackingsIDList.Length > 0 && 
								!sSelectedPackingsIDList.Contains("," + rcc["PackingID"].ToString() + ","))
							{
								rcc["InFilter"] = false;
							}
							if (chkRestBoxes.Checked && 
								Convert.ToDecimal(rcc["BoxQnt"]) > Convert.ToDecimal(numRestBoxes.Value))
							{
								rcc["InFilter"] = false;
							}
							if (chkDateValidPercent.Checked &&
								!Convert.IsDBNull(rcc["DateValid"]) && 
								Convert.ToDecimal(rcc["DateValidPercent"]) > Convert.ToDecimal(numDateValidPercent.Value))
							{
								rcc["InFilter"] = false;
							}
						}
						DataTable dcc = CopyTable(oCellTemp.TableCellsContents, "dcc", "InFilter = true", "");
						if (dcc.Rows.Count > 0)
						{
							DataRow rcc = dcc.Rows[0];
							r["InFilter"] = true;
							if (chkShowContents.Checked)
							{
								if (dcc.Rows.Count > 1)
								{
									r["GoodAlias"] = RFMUtilities.Declen(dcc.Rows.Count, "товар", "товара", "товаров");
								}
								else
								{
									r["GoodAlias"] = rcc["GoodAlias"];
									r["Weighting"] = rcc["Weighting"];
									r["InBox"] = rcc["InBox"];
									r["Qnt"] = rcc["Qnt"];
									r["Boxes"] = Convert.ToDecimal(rcc["Qnt"]) / Convert.ToDecimal(rcc["InBox"]);
									r["DateValid"] = rcc["DateValid"];
								}
							}
						}
					}
				}
			}

			//grdCells.Restore(CopyTable(oCells.MainTable, "dt", ((chkDateValidPercent.Checked || chkRestBoxes.Checked || sSelectedPackingsIDList.Length > 0) ? "InFilter" : ""), "StoreZoneName, Address"));
			string sFilter = "";
			if (chkDateValidPercent.Checked || chkRestBoxes.Checked || sSelectedPackingsIDList.Length > 0)
				sFilter = "InFilter";
			if (chkForStorageOnly.Checked)
			{
				if (sFilter.Length == 0) 
					sFilter = "ForStorage";
				else
					sFilter += " and ForStorage";
			}
			
			if (dt == null)
			{
				dt = CopyTable(oCells.MainTable, "dt", sFilter, "StoreZoneName, Address");
				dt.PrimaryKey = new DataColumn[] { dt.Columns["CellID"] };
			}
			else
			{
				//dt.Merge(CopyTable(oCells.MainTable, "dt", ((chkDateValidPercent.Checked || chkRestBoxes.Checked || sSelectedPackingsIDList.Length > 0) ? "InFilter" : ""), "StoreZoneName, Address"));
				DataTable dtX = CopyTable(oCells.MainTable, "dt", sFilter, "StoreZoneName, Address");
				foreach (DataRow rc in dtX.Rows)
				{
					int nCellID = Convert.ToInt32(rc["CellID"]);
					if (dt.Rows.Find(nCellID) == null)
					{
						dt.ImportRow(rc);
					}
				}
			}
			grdCells.Restore(dt);
			grdCells.MarkAllRows(true);

			WaitOff(this);
		}

		private void chkShowContents_CheckedChanged(object sender, EventArgs e)
		{
			grcGoodAlias.Visible =
			grcInBox.Visible =
			grcQnt.Visible =
			grcBoxes.Visible = 
			grcDateValid.Visible = 
			grcWeight.Visible =
				chkShowContents.Checked;

			if (sender != null && chkShowContents.Checked)
			{
				btnFilter_Click(null, null);
			}
		}

	#endregion Restore

	}
}