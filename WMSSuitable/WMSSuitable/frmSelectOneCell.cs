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
	// форма дл€ выбора одной или нескольких записей о €чейках
	// возвращает в родительскую форму:
	// с пометкой:  string _SelectedCellIDList (список кодов отмеченных записей, через зап€тую, вида: 1,2,23,) 
	// без пометки: int _SelectedCellID (код текущей записи)
	// string _SelectedCellAddressText (список адресов первых 3-х отмеченных €чеек)

	public partial class frmSelectOneCell : RFMFormChild
	{

		private Form parentForm;
		private bool useCheck;

		private Cell oCells = new Cell();
		private Cell oCellsTree = new Cell();
		private Cell oCellAddress = new Cell();
		private StoreZone oStoreZone = new StoreZone();

		// дл€ фильтров
		public string _SelectedIDList = null;
		public string _SelectedText = "";
		private string sSelectedStorezZonesIDList = null;

		private string sStoresZonesList = null; 

		public frmSelectOneCell(Form _parentForm)
		{
			InitializeComponent();
			
			parentForm = _parentForm;
			useCheck = false;
		}

		public frmSelectOneCell(Form _parentForm, bool _useCheck)
		{
			InitializeComponent();

			parentForm = _parentForm;
			useCheck = _useCheck;

			grdData.IsCheckerInclude = _useCheck;
			grdData.IsCheckerShow = _useCheck;
		}

		public frmSelectOneCell(Form _parentForm, bool _useCheck, string _sStoresZonesList)
		{
			InitializeComponent();

			parentForm = _parentForm;
			useCheck = _useCheck;

			grdData.IsCheckerInclude = _useCheck;
			grdData.IsCheckerShow = _useCheck;

			sStoresZonesList = _sStoresZonesList;
		}

		private void frmSelectOneCell_Load(object sender, EventArgs e)
		{
			if (useCheck)
				Text = "¬ыберите несколько €чеек";
			else
				Text = "¬ыберите €чейку";

			bool lResult = cboCBuilding_Restore() &&
						cboCLine_Restore() &&
						cboCLevel_Restore() &&
						cboCRack_Restore() &&
						cboCPlace_Restore();

			oStoreZone.FillData();
			oStoreZone.FillTableStoresZonesTypes();

			if (sStoresZonesList != null)
			{
				string sStoresZonesText = "";
				foreach (DataRow sz in oStoreZone.MainTable.Rows)
				{
					if (((string)("," + sStoresZonesList + ",")).Contains("," + sz["ID"].ToString().Trim() + ","))
						sStoresZonesText += ", " + sz["Name"].ToString();  
				}
				if (sStoresZonesText.Substring(0, 1) == ",")
					sStoresZonesText = sStoresZonesText.Substring(2).Trim();
				txtStoresZonesChoosen.Text = sStoresZonesText; 
			}

			cntData.SplitterDistance = 0;
			cntData.Panel1MinSize = 0;
			//lblTreeWait.Visible = false;
		}

		private void btnFilter_Click(object sender, EventArgs e)
		{
			WaitOn(this);
			grdData_Restore();
			WaitOff(this);

			grdData.Select();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			txtStoresZonesChoosen.Text = "";
			txtCellBarCode.Text = "";
			txtCellAddress.Text = "";

			cboCBuilding.SelectedIndex = -1;
			cboCLine.SelectedIndex = -1;
			cboCRack.SelectedIndex = -1;
			cboCLevel.SelectedIndex = -1;
			cboCPlace.SelectedIndex = -1;

			tvwCells.MarkAllItems(false);
		}

		private void btnGo_Click(object sender, EventArgs e)
		{
			// возвращаем код выбранной €чейки в родительскую форму, поле _SelectedCellID / _SelectedCellsIDList
			string _SelectedCellsIDList = null;
			int? _SelectedCellID = null;
			string _SelectedCellAddressText = "";

			if (grdData.Rows.Count > 0)
			{
				if (useCheck && grdData.IsCheckerShow)
				{
					// список ID 
					_SelectedCellsIDList = "";
					_SelectedCellAddressText = "";

					DataView dMarked = new DataView(oCells.MainTable);
					dMarked.RowFilter = "IsMarked = true";
					dMarked.Sort = grdData.GridSource.Sort;
					int i = 0;
					int nFirstCntRecords = 3; // количество первых записей дл€ наборного текстового значени€
					foreach (DataRowView r in dMarked)
					{
						if (!Convert.IsDBNull(r["ID"]))
						{
							_SelectedCellsIDList += r["ID"].ToString() + ",";
						}

						if (i < nFirstCntRecords)
						{
							_SelectedCellAddressText += r["Address"].ToString().Trim() + ", ";
						}
						else
						{
							if (i == nFirstCntRecords)
							{
								_SelectedCellAddressText += "...";
							}
						}
						i++;
					}
					if (_SelectedCellsIDList.Length == 0)
					{
						// нет отметок - берем текущую запись
						if (grdData.CurrentRow != null)
						{
							_SelectedCellsIDList = grdData.CurrentRow.Cells["grcID"].Value.ToString() + ",";
							_SelectedCellAddressText = grdData.CurrentRow.Cells["grcAddress"].Value.ToString();
						}
					}

					// приводим наборное текстовое поле к виду: (5) раз, два, три, ...
					if (_SelectedCellsIDList.Length == 0)
					{
						_SelectedCellsIDList = null;
						_SelectedCellAddressText = "";
					}
					else
					{
						_SelectedCellAddressText = _SelectedCellAddressText.Trim();
						if (_SelectedCellAddressText.Substring(_SelectedCellAddressText.Length - 1, 1) == ",")
						{
							_SelectedCellAddressText = _SelectedCellAddressText.Substring(0, _SelectedCellAddressText.Length - 1);
						}
						_SelectedCellAddressText = "(" + RFMUtilities.Occurs(_SelectedCellsIDList, ",").ToString() + "): " +
							_SelectedCellAddressText;
					}

					RFMUtilities.SetFormField(parentForm, "_SelectedCellsIDList", _SelectedCellsIDList);
					RFMUtilities.SetFormField(parentForm, "_SelectedCellAddressText", _SelectedCellAddressText);
				}
				else
				{
					// ID текущей строки
					if (grdData.CurrentRow != null)
					{
						_SelectedCellID = (int)grdData.CurrentRow.Cells["grcID"].Value;
						_SelectedCellAddressText = grdData.CurrentRow.Cells["grcAddress"].Value.ToString() + ",";
					}

					RFMUtilities.SetFormField(parentForm, "_SelectedCellID", _SelectedCellID);
					RFMUtilities.SetFormField(parentForm, "_SelectedCellAddressText", _SelectedCellAddressText);
				}
			}
			else
			{
				RFMMessage.MessageBoxInfo("Ќе выбрано ни одной €чейки...");
			}

			DialogResult = DialogResult.Yes;
			Dispose();
		}

		private void btnHelp_Click(object sender, EventArgs e)
		{
			RFMHelpUtilities.HelpShow(this, hpHelp);
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			Dispose();
		}

	#region Tree

		private void btnTree_Click(object sender, EventArgs e)
		{
			WaitOn(this);
			tvwCells_Restore();
			cntData.SplitterDistance = 200;
			WaitOff(this);
		}

		private void tvwCells_Restore()
		{
			if (tvwCells.TreeSource != null)
				((DataTable)tvwCells.TreeSource.DataSource).DataSet.Tables.Remove("dtTree");

			oCells.FillDataTree(tvwCells.IsActualOnly);
			tvwCells.Restore(oCells.DS.Tables["TableDataTree"]);
			tvwCells.SelectedNode = tvwCells.TopNode;
			tvwCells.Refresh();
		}
	
	#endregion 

	#region Grid CellFormat
	
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
					case "grcCellStateImage":
					case "grcLockedImage":
						e.Value = Properties.Resources.Empty;
						break;
				}
				return;
			}

			DataGridViewRow r = grdData.Rows[e.RowIndex];
			switch (grdData.Columns[e.ColumnIndex].Name)
			{
				case "grcCellStateImage":
					if ((bool)r.Cells["grcHasCellContent"].Value)
					{
						e.Value = Properties.Resources.Box_full;
					}
					else
					{
						e.Value = Properties.Resources.Empty;
					}
					break;
				case "grcLockedImage":
					if ((bool)r.Cells["grcLocked"].Value)
					{
						e.Value = Properties.Resources.Lock1;
					}
					else
					{
						e.Value = Properties.Resources.Empty;
					}
					break;
				case "grcForFrames":
					if (r.Cells["grcIsForFrames"].Value == DBNull.Value)
					{
						e.CellStyle.BackColor = Color.Silver;
						e.CellStyle.ForeColor = Color.Silver;
					}
					break;
			}

			// неактуальные - курсивом
			if (!Convert.ToBoolean(r.Cells["grcActual"].Value))
				e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Italic);
		}

	#endregion 

	#region Form keys

		private void frmSelectOneCell_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F5:
					btnFilter_Click(null, null);
					break;
				case Keys.F1:
					btnHelp_Click(null, null);
					break;
				case Keys.W:
				case Keys.S:
					if (e.Modifiers == Keys.Control)
					{
						btnGo_Click(btnGo, null);
					}
					break;
				case Keys.Escape:
					btnExit_Click(null, null);
					break;
			}
		}

	#endregion
		
	#region ¬ыбор скл.зоны

		private void btnStorezZonesChoose_Click(object sender, EventArgs e)
		{
			_SelectedIDList = null;
			_SelectedText = "";

			sSelectedStorezZonesIDList = null;

			if (StartForm(new frmSelectID(this, oStoreZone.TableStoresZones, "Name,StoreZoneTypeName,Actual", "—кладска€ зона,“ип зоны,јкт.", true)) == DialogResult.Yes)
			{
				sSelectedStorezZonesIDList = "," + _SelectedIDList;
				txtStoresZonesChoosen.Text = _SelectedText;

				sStoresZonesList = null;
			}

			_SelectedIDList = null;
			_SelectedText = "";
		}

	#endregion 

	#region TextBox Upper

		private void txtCellAddress_TextChanged(object sender, EventArgs e)
		{
			RFMTextBox txtField = (RFMTextBox)sender;
			int sSelectionStart = txtField.SelectionStart;
			txtField.Text = txtField.Text.ToUpper();
			//txtField.Select(txtField.Text.Length, 0);
			txtField.Select(sSelectionStart, 0);
		}

	#endregion

	#region Actual

		private void chkCellsActual_CheckedChanged(object sender, EventArgs e)
		{
			tvwCells.IsActualOnly = chkCellsActual.Checked;
			if (tvwCells.Visible && tvwCells.TreeSource != null)
			{
				tvwCells_Restore();
			}
		}

	#endregion Actual

	#region Restore

		private void grdData_Restore()
		{
			oCells.ClearFilters();
			oCells.ID = null;
			oCells.IDList = null;

			// собираем услови€
			if (sSelectedStorezZonesIDList != null)
				oCells.FilterStoresZonesList = sSelectedStorezZonesIDList;
			else
			{
				if (sStoresZonesList != null)
					oCells.FilterStoresZonesList = sStoresZonesList;
			}

			if (txtCellAddress.Text.Trim().Length > 0)
				oCells.FilterAddressContext = txtCellAddress.Text.Trim();
			if (txtCellBarCode.Text.Trim().Length > 0)
				oCells.BarCode = txtCellBarCode.Text.Trim();

			if (cboCBuilding.Text.Trim().Length > 0)
				oCells.FilterCBuilding = cboCBuilding.Text.Trim();
			if (cboCLine.Text.Trim().Length > 0)
				oCells.FilterCLine = cboCLine.Text.Trim();
			if (cboCRack.Text.Trim().Length > 0)
				oCells.FilterCRack = cboCRack.Text.Trim();
			if (cboCLevel.Text.Trim().Length > 0)
				oCells.FilterCLevel = cboCLevel.Text.Trim();
			if (cboCPlace.Text.Trim().Length > 0)
				oCells.FilterCPlace = cboCPlace.Text.Trim();

			if (chkCellsActual.Checked)
				oCells.FilterActual = true;

			// дерево
			if (tvwCells.Visible && tvwCells.TreeSource != null && tvwCells.GetMarkedNodes() > 0)
			{
				tvwCells.TreeSource.Filter = "IsMarked";
				tvwCells.TreeSource.MoveFirst();
				for (int i = 0; i < tvwCells.TreeSource.Count; i++)
				{
					oCells.IDList = oCells.IDList + "," + ((DataRowView)tvwCells.TreeSource.Current)["ID"];
					tvwCells.TreeSource.MoveNext();
				}
				tvwCells.TreeSource.RemoveFilter();
			}

			grdData.DataSource = null;
			oCells.FillData();
			grdData.Restore(oCells.MainTable);
		}

		#region CellAddress Combos

		private bool cboCBuilding_Restore()
		{
			oCellAddress.FillAddressPartTables("CBuilding");
			cboCBuilding.ValueMember = oCellAddress.TableAddressPartCBuilding.Columns[0].Caption;
			cboCBuilding.DisplayMember = oCellAddress.TableAddressPartCBuilding.Columns[1].Caption;
			cboCBuilding.DataSource = oCellAddress.TableAddressPartCBuilding;
			return (oCellAddress.ErrorNumber == 0);
		}
		private bool cboCLine_Restore()
		{
			oCellAddress.FillAddressPartTables("CLine");
			cboCLine.ValueMember = oCellAddress.TableAddressPartCLine.Columns[0].Caption;
			cboCLine.DisplayMember = oCellAddress.TableAddressPartCLine.Columns[1].Caption;
			cboCLine.DataSource = oCellAddress.TableAddressPartCLine;
			return (oCellAddress.ErrorNumber == 0);
		}
		private bool cboCRack_Restore()
		{
			oCellAddress.FillAddressPartTables("CRack");
			cboCRack.ValueMember = oCellAddress.TableAddressPartCRack.Columns[0].Caption;
			cboCRack.DisplayMember = oCellAddress.TableAddressPartCRack.Columns[1].Caption;
			cboCRack.DataSource = new DataView(oCellAddress.TableAddressPartCRack);
			return (oCellAddress.ErrorNumber == 0);
		}
		private bool cboCLevel_Restore()
		{
			oCellAddress.FillAddressPartTables("CLevel");
			cboCLevel.ValueMember = oCellAddress.TableAddressPartCLevel.Columns[0].Caption;
			cboCLevel.DisplayMember = oCellAddress.TableAddressPartCLevel.Columns[1].Caption;
			cboCLevel.DataSource = new DataView(oCellAddress.TableAddressPartCLevel);
			return (oCellAddress.ErrorNumber == 0);
		}
		private bool cboCPlace_Restore()
		{
			oCellAddress.FillAddressPartTables("CPlace");
			cboCPlace.ValueMember = oCellAddress.TableAddressPartCPlace.Columns[0].Caption;
			cboCPlace.DisplayMember = oCellAddress.TableAddressPartCPlace.Columns[1].Caption;
			cboCPlace.DataSource = new DataView(oCellAddress.TableAddressPartCPlace);
			return (oCellAddress.ErrorNumber == 0);
		}
		
		#endregion CellAddress Combos

	#endregion #Restore

	}
}