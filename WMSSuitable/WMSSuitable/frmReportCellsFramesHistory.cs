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
	public partial class frmReportCellsFramesHistory : RFMFormChild
	{
		Report oReport; 
		Cell oCell;
		Frame oFrame;
		
		// для фильтров
		protected Good oGood;
		protected Cell oCellAddress;

		protected string sOwnersList, sGoodsStatesList, sPackingsList, sUsersList;

		public int? _SelectedID;
		public string _SelectedIDList;
		public string _SelectedText;

		private string sSelectedGoodsStatesIDList = "";
		private string sSelectedOwnersIDList = "";
		private string sSelectedUsersIDList = "";

		public string _SelectedPackingIDList;
		public string _SelectedPackingAliasText;
		private string sSelectedPackingsIDList = "";

		public string _SelectedCellsIDList;
		public string _SelectedCellAddressText;
		private string sSelectedCellsIDList = "";

		private string sSelectedStoresZonesIDList = "";
		private string sSelectedStoresZonesTypesIDList = "";

		// для спец.ячейки Lost&Found
		protected string sLostFoundAddress = null;
		protected int nLostFoundID = 0;


		public frmReportCellsFramesHistory()
		{
			oReport = new Report();
			oCell = new Cell();
			oFrame = new Frame();
			if (oReport.ErrorNumber != 0 ||
				oCell.ErrorNumber != 0 ||
				oFrame.ErrorNumber != 0)
			{
				IsValid = false;
			}
			else
			{
				oGood = new Good();
				oCellAddress = new Cell();
				if (oGood.ErrorNumber != 0 ||
					oCellAddress.ErrorNumber != 0)
				{
					IsValid = false;
				}
				else
				{
					InitializeComponent();

					grcBoxQnt.AgrType = 
					grcPalQnt.AgrType = 
					grcQnt.AgrType = 
						EnumAgregate.Sum;

					// Lost&Found. пока не используется.
					Setting oSet = new Setting();
					sLostFoundAddress = oSet.FillVariable("sLostFoundAddress");
					if (sLostFoundAddress != null && sLostFoundAddress.Length > 0)
					{
						Cell oCellLostFound = new Cell();
						oCellLostFound.FilterAddress = sLostFoundAddress;
						oCellLostFound.FillData();
						if (oCellLostFound.MainTable.Rows.Count > 0)
						{
							DataRow rclf = oCellLostFound.MainTable.Rows[0];
							if (rclf != null)
							{
								nLostFoundID = (int)rclf["ID"];
							}
						}
					}
					// Lost&Found.end
				}
			}
		}

		private void frmReportCellsFramesHistory_Load(object sender, EventArgs e) 
		{
			RFMCursorWait.Set(true);
			
			bool lResult = 
				cboCBuilding_Restore() &&
				cboCLine_Restore() &&
				cboCLevel_Restore() &&
				cboCRack_Restore() && 
				cboCPlace_Restore();
			if (!lResult)
			{
				RFMCursorWait.Set(false);
				RFMMessage.MessageBoxError("Ошибка при заполнении существующих значений параметров адреса...");
				return;
			}

			grcQnt.AgrType = 
			grcBoxQnt.AgrType =
			grcPalQnt.AgrType =
				EnumAgregate.Sum; 

			btnClearTerms_Click(null, null);

			tcList.Init();

			RFMCursorWait.Set(false);
		}

	#region Tab Restore

		private bool tabTerms_Restore()
		{
			btnPrint.Enabled = false;
			btnService.Enabled = false;
			return (true);
		}

		private bool tabHistory_Restore()
		{
			grdData_Restore();
			btnPrint.Enabled = true;
			btnService.Enabled = true;
			return (true);
		}

		private void tcList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tcList.SelectedTab.Name.ToUpper().Contains("TERMS"))
			{
				btnPrint.Enabled =
				btnService.Enabled = false;
			}
			if (tcList.SelectedTab.Name.ToUpper().Contains("HISTORY"))
			{
				grdData.Select();
			}
		}

	#endregion Tab Restore

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
					case "grcQnt":
					case "grcInBox":
						e.CellStyle.Format = "### ### ### ###";
						break;
					case "grcTypeImage":
					case "grcProblemImage":
					case "grcStatusImage":
						e.Value = Properties.Resources.Empty;
						break;
				}
				return;
			}

			DataGridViewRow r = grdData.Rows[e.RowIndex];
			switch (grdData.Columns[e.ColumnIndex].Name)
			{
				case "grcTypeImage":
					switch ((string)r.Cells["grcOperationType"].Value)
					{
						case "I":
							e.Value = Properties.Resources.Plus;
							break;
						case "O":
							e.Value = Properties.Resources.Minus;
							break;
						case "S":
							e.Value = Properties.Resources.Medication;
							break;
						default:
							e.Value = Properties.Resources.Empty;
							break;
					}
					break;
				case "grcProblemImage":
					if (r.Cells["grcErrorID"].Value == DBNull.Value)
						e.Value = Properties.Resources.Empty;
					else
						e.Value = Properties.Resources.Exclamation;
					break;
				case "grcStatusImage":
					if (r.Cells["grcErrorID"].Value == DBNull.Value)
						e.Value = Properties.Resources.Check;
					else
						e.Value = Properties.Resources.CheckRed;
					break;
				case "grcQnt":
				case "grcInBox":
					if (!Convert.IsDBNull(r.Cells["grcWeighting"].Value) &&
						Convert.ToBoolean(r.Cells["grcWeighting"].Value) ||
						!Convert.IsDBNull(e.Value) && Convert.ToDecimal(e.Value) != Convert.ToInt32(e.Value))
						e.CellStyle.Format = "### ### ### ###.000";
					else
						e.CellStyle.Format = "### ### ### ###";
					break;
				case "grcBox":
					e.CellStyle.Format = "### ### ### ###.#";
					break;
				case "grcPal":
					e.CellStyle.Format = "### ### ### ###.##";
					break;
			}
		}

	#endregion

	#region Restore

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


		private bool grdData_Restore()
		{
			RFMCursorWait.Set(true);
			RFMCursorWait.LockWindowUpdate(FindForm().Handle);
			
			// собираем условия
			DateTime? dDateBeg = null;
			DateTime? dDateEnd = null;
			if (!dtrDates.dtpBegDate.IsEmpty)
			{
				dDateBeg = dtrDates.dtpBegDate.Value.Date;
			}
			if (!dtrDates.dtpEndDate.IsEmpty)
			{
				dDateEnd = dtrDates.dtpEndDate.Value.Date;
			}
			
			// ячейки: 
			oCell.ClearError();
			oCell.ClearFilters();
			oCell.ID = null;
			oCell.IDList = null;
			oCell.NeedRequery = false;

			// выбранные ячейки
			if (sSelectedCellsIDList.Length > 0)
				oCell.IDList = sSelectedCellsIDList;

			// штрих-код
			if (txtCellBarCode.Text.Trim().Length > 0)
				oCell.BarCode = txtCellBarCode.Text.Trim();

			// зоны
			if (sSelectedStoresZonesIDList.Length > 0)
			{
				oCell.FilterStoresZonesList = sSelectedStoresZonesIDList;
			}
			if (sSelectedStoresZonesTypesIDList.Length > 0)
			{
				oCell.FilterStoresZonesTypesList = sSelectedStoresZonesTypesIDList;
			}
			// адрес
			if (txtAddress.Text.Trim().Length > 0)
			{
				oCell.FilterAddressContext = txtAddress.Text.Trim();
			}
			if (txtCBuilding.Text.Trim().Length > 0)
				oCell.FilterCBuilding = txtCBuilding.Text.Trim();
			if (txtCLine.Text.Trim().Length > 0)
				oCell.FilterCLine = txtCLine.Text.Trim();
			if (txtCRack.Text.Trim().Length > 0)
				oCell.FilterCRack = txtCRack.Text.Trim();
			if (txtCLevel.Text.Trim().Length > 0)
				oCell.FilterCLevel = txtCLevel.Text.Trim();
			if (txtCPlace.Text.Trim().Length > 0)
				oCell.FilterCPlace = txtCPlace.Text.Trim();

			if (!oCell.NeedRequery)
			{
				oCell.ID = -1;
			}
			oCell.FillData();

			// контейнеры 
			oFrame.ClearError();
			oFrame.ClearFilters();
			oFrame.ID = null;
			oFrame.IDList = null;
			oFrame.NeedRequery = false;

			// штрих-код
			if (txtFrameBarCode.Text.Trim().Length > 0)
				oFrame.BarCode = txtFrameBarCode.Text.Trim();

			if (!oFrame.NeedRequery)
			{
				oFrame.ID = -1;
			}
			oFrame.FillData();

			// остальное 
			sOwnersList = 
			sGoodsStatesList = 
			sPackingsList = 
			sUsersList = null;

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
			// пользователи
			if (sSelectedUsersIDList.Length > 0)
			{
				sUsersList = sSelectedUsersIDList;
			}
			// товары
			if (sSelectedPackingsIDList.Length > 0)
			{
				sPackingsList = sSelectedPackingsIDList;
			}

			grdData.GetGridState();

			oReport.ReportCellsFramesHistory(oCell.MainTable, oFrame.MainTable,
				dDateBeg, dDateEnd,
				chkTraffics.Checked, chkChanges.Checked,
				sOwnersList, sGoodsStatesList, sPackingsList, sUsersList);

			grdData.IsLockRowChanged = true;
			grdData.Restore(oReport.MainTable);

			RFMCursorWait.LockWindowUpdate(IntPtr.Zero);
			RFMCursorWait.Set(false);
			
			return (oReport.ErrorNumber == 0);
		}

	#endregion

	#region Filters

		#region StoresZones

		private void btnStoresZonesChoose_Click(object sender, EventArgs e)
		{
			_SelectedIDList = null;
			_SelectedText = "";

			StoreZone oStoreZone = new StoreZone();
			oStoreZone.FillData();
			if (oStoreZone.ErrorNumber != 0 || oStoreZone.MainTable == null)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о зонах склада...");
				return;
			}
			if (oStoreZone.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Нет данных о зонах склада...");
				return;
			}

			if (StartForm(new frmSelectID(this, oStoreZone.MainTable, "Name", "Зона склада", true)) == DialogResult.Yes)
			{
				if (_SelectedIDList == null || !_SelectedIDList.Contains(","))
				{
					btnStoresZonesClear_Click(null, null);
					return;
				}

				sSelectedStoresZonesIDList = "," + _SelectedIDList;

				txtStoresZonesChoosen.Text = _SelectedText;
				ttToolTip.SetToolTip(txtStoresZonesChoosen, txtStoresZonesChoosen.Text);

				tabHistory.IsNeedRestore = true;
			}

			_SelectedIDList = null;
			_SelectedText = "";
		}

		private void btnStoresZonesClear_Click(object sender, EventArgs e)
		{
			tabHistory.IsNeedRestore = true;

			ttToolTip.SetToolTip(txtStoresZonesChoosen, "не выбраны");
			sSelectedStoresZonesIDList = "";
			txtStoresZonesChoosen.Text = "";
		}

		#endregion StoresZones

		#region StoresZonesTypes

		private void btnStoresZonesTypesChoose_Click(object sender, EventArgs e)
		{
			_SelectedIDList = null;
			_SelectedText = "";

			StoreZone oStoreZone = new StoreZone();
			oStoreZone.FillTableStoresZonesTypes();
			if (oStoreZone.ErrorNumber != 0 || oStoreZone.TableStoresZonesTypes == null)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о типах зон склада...");
				return;
			}
			if (oStoreZone.TableStoresZonesTypes.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Нет данных о типах зон склада...");
				return;
			}

			if (StartForm(new frmSelectID(this, oStoreZone.TableStoresZonesTypes, "Name", "Тип скл.зоны", true)) == DialogResult.Yes)
			{
				if (_SelectedIDList == null || !_SelectedIDList.Contains(","))
				{
					btnStoresZonesTypesClear_Click(null, null);
					return;
				}

				sSelectedStoresZonesTypesIDList = "," + _SelectedIDList;

				txtStoresZonesTypesChoosen.Text = _SelectedText;
				ttToolTip.SetToolTip(txtStoresZonesTypesChoosen, txtStoresZonesTypesChoosen.Text);

				tabHistory.IsNeedRestore = true;
			}

			_SelectedIDList = null;
			_SelectedText = "";
		}

		private void btnStoresZonesTypesClear_Click(object sender, EventArgs e)
		{
			tabHistory.IsNeedRestore = true;

			ttToolTip.SetToolTip(txtStoresZonesTypesChoosen, "не выбраны");
			sSelectedStoresZonesTypesIDList = "";
			txtStoresZonesTypesChoosen.Text = "";
		}

		#endregion StoresZonesTypes

		#region Users

		private void btnUsersChoose_Click(object sender, EventArgs e)
		{
			_SelectedIDList = null;
			//sSelectedUsersIDList = "";

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
				if (_SelectedIDList == null || !_SelectedIDList.Contains(","))
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

				tabHistory.IsNeedRestore = true;
			}
			_SelectedIDList = null;
		}

		private void btnUsersClear_Click(object sender, EventArgs e)
		{
			tabHistory.IsNeedRestore = true;

			ttToolTip.SetToolTip(txtUsersChoosen, "не выбраны");
			sSelectedUsersIDList = "";
			txtUsersChoosen.Text = "";
		}

		#endregion

		#region Owners

		private void btnOwnersChoose_Click(object sender, EventArgs e)
		{
			_SelectedIDList = null;
			_SelectedText = "";

			Partner oOwner = new Partner();
			oOwner.FillDataOwners();
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

				tabHistory.IsNeedRestore = true;
			}

			_SelectedIDList = null;
			_SelectedText = "";
		}

		private void btnOwnersClear_Click(object sender, EventArgs e)
		{
			tabHistory.IsNeedRestore = true;

			ttToolTip.SetToolTip(txtOwnersChoosen, "не выбраны");
			sSelectedOwnersIDList = "";
			txtOwnersChoosen.Text = "";
		}

		#endregion

		#region GoodsStates

		private void btnGoodsStatesChoose_Click(object sender, EventArgs e)
		{
			_SelectedIDList = null;
			_SelectedText = "";

			GoodState oGoodState = new GoodState();
			oGoodState.FillData();
			if (oGoodState.ErrorNumber != 0 || oGoodState.MainTable == null)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных...");
				return;
			}
			if (oGoodState.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Нет данных...");
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

				tabHistory.IsNeedRestore = true;
			}
			
			_SelectedIDList = null;
			_SelectedText = "";
		}

		private void btnGoodsStatesClear_Click(object sender, EventArgs e)
		{
			tabHistory.IsNeedRestore = true;

			ttToolTip.SetToolTip(txtGoodsStatesChoosen, "не выбраны");
			sSelectedGoodsStatesIDList = "";
			txtGoodsStatesChoosen.Text = "";
		}

		#endregion GoodsStates

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

				tabHistory.IsNeedRestore = true;
			}

			_SelectedPackingIDList = null;
			_SelectedPackingAliasText = "";
		}

		private void btnPackingsClear_Click(object sender, EventArgs e)
		{
			tabHistory.IsNeedRestore = true;

			ttToolTip.SetToolTip(txtPackingsChoosen, "не выбраны");
			sSelectedPackingsIDList = "";
			txtPackingsChoosen.Text = "";
		}

		#endregion

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

				tabHistory.IsNeedRestore = true;
			}

			_SelectedCellsIDList = null;
			_SelectedCellAddressText = "";
		}

		private void btnCellsClear_Click(object sender, EventArgs e)
		{
			tabHistory.IsNeedRestore = true;

			ttToolTip.SetToolTip(txtCellsChoosen, "не выбраны");
			sSelectedCellsIDList = "";
			txtCellsChoosen.Text = "";
		}

		#endregion Cells

	#endregion Filters

	#region текстовые поля - фильтры

		private void txtText_TextChanged(object sender, EventArgs e)
		{
			RFMTextBox txtField = (RFMTextBox)sender;
			txtField.Text = txtField.Text.ToUpper();
			txtField.Select(txtField.Text.Length, 0);

		}

	#endregion

	#region Составляющие адреса

		private void cboCBuilding_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtCBuilding.Text = cboCBuilding.Text;
		}

		private void cboCLine_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtCLine.Text = cboCLine.Text;
		}

		private void cboCRack_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtCRack.Text = cboCRack.Text;
		}

		private void cboCLevel_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtCLevel.Text = cboCLevel.Text;
		}

		private void cboCPlace_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtCPlace.Text = cboCPlace.Text;
		}

	#endregion
		
	#region Menu Print

		private void btnPrint_Click(object sender, EventArgs e)
		{
			switch (tcList.SelectedTab.Name)
			{
				case "tabHistory":
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
				case "tabHistory":
					mnuPrint.Show(btnPrint, new Point(e.X, e.Y));
					break;
				default:
					break;
			}
		}

	#endregion

	#region Menu Service 
		
		private void btnService_Click(object sender, EventArgs e)
		{

		}

		private void btnService_MouseClick(object sender, MouseEventArgs e)
		{

		}

	#endregion 

	#region Terms clear

		private void btnClearTerms_Click(object sender, EventArgs e)
		{
			txtCellBarCode.Text = "";
			txtAddress.Text = "";
			txtCBuilding.Text = "";
			txtCLine.Text = "";
			txtCRack.Text = "";
			txtCLevel.Text = "";
			txtCPlace.Text = "";

			cboCBuilding.SelectedIndex = -1;
			cboCLine.SelectedIndex = -1;
			cboCRack.SelectedIndex = -1;
			cboCLevel.SelectedIndex = -1;
			cboCPlace.SelectedIndex = -1;

			txtFrameBarCode.Text = "";

			btnStoresZonesClear_Click(null, null);
			btnStoresZonesTypesClear_Click(null, null);
			btnCellsClear_Click(null, null);

			btnGoodsStatesClear_Click(null, null);
			btnOwnersClear_Click(null, null);
			btnUsersClear_Click(null, null);
			btnPackingsClear_Click(null, null);

			chkChanges.Checked = true;
			chkTraffics.Checked = true;

			oCell.ClearFilters();
			oCell.ClearError();
			oFrame.ClearFilters();
			oFrame.ClearError();

			dtrDates.dtpBegDate.Value = DateTime.Now.Date.AddMonths(-1);
			dtrDates.dtpEndDate.Value = DateTime.Now.Date;

			tabHistory.IsNeedRestore = true;
		}
		
	#endregion

	}
}