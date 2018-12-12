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
	public partial class frmMovings : RFMFormChild
	{
		private Moving oMovingList; //список внутр.перемещений
		private Moving oMovingCur; //текущее внутр.перемещение

		// для фильтров
		private Cell oCellSource;

		public string _SelectedIDList;
		public string _SelectedText;

		public string _SelectedPackingIDList;
		public string _SelectedPackingAliasText;
		private string sSelectedPackingsIDList = "";

		private string sSelectedMovingsTypesIDList = "";
		private string sSelectedOwnerIDList = "";
		private string sSelectedGoodsStatesIDList = "";
		private string sSelectedGoodsStatesNewIDList = "";

		private string sSelectedStoresZonesIDList = "";
		private string sSelectedStoresZonesTypesIDList = "";

		public int? _SelectedID;


		public frmMovings()
		{
			oMovingList = new Moving();
			oMovingCur = new Moving();
			if (oMovingList.ErrorNumber != 0 ||
				oMovingCur.ErrorNumber != 0)
			{
				IsValid = false;
			}

			if (IsValid)
			{
				oCellSource = new Cell();
				if (oCellSource.ErrorNumber != 0)
				{
					IsValid = false;
				}
			}

			if (IsValid)
			{
				InitializeComponent();
			}
		}

		private void frmMovings_Load(object sender, EventArgs e)
		{
			RFMCursorWait.Set(true);

			//grcQntWished.AgrType = EnumAgregate.Sum;
			grcQntWished.AgrType =
			grcBoxWished.AgrType =
			grcQntConfirmed.AgrType =
			grcBoxConfirmed.AgrType =
			grcTrafficsGoodsQntWished.AgrType =
			grcTrafficsGoodsBoxWished.AgrType =
			grcTrafficsGoodsQntConfirmed.AgrType =
			grcTrafficsGoodsBoxConfirmed.AgrType =
				EnumAgregate.Sum;

			btnClearTerms_Click(null, null);

			tcList.Init();
			//tcMovingsTraffics.Init();

			RFMCursorWait.Set(false);
		}

		#region Tab Restore

		private bool tabTerms_Restore()
		{
			btnAdd.Enabled =
			btnEdit.Enabled =
			btnConfirm.Enabled =
			btnDelete.Enabled =
			btnPrint.Enabled =
			btnService.Enabled = false;
			return (true);
		}

		private bool tabData_Restore()
		{
			grdData_Restore();
			btnAdd.Enabled = true;
			if (grdData.Rows.Count > 0)
			{
				btnEdit.Enabled =
				btnDelete.Enabled =
				btnPrint.Enabled =
				btnService.Enabled =
					true;
			}
			else
			{
				btnEdit.Enabled =
				btnDelete.Enabled =
				btnPrint.Enabled =
				btnService.Enabled =
					false;
			}
			return (true);
		}

		private void tcList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tcList.SelectedTab.Name.ToUpper().Contains("TERMS"))
			{
				btnAdd.Enabled =
				btnEdit.Enabled =
				btnDelete.Enabled =
				btnConfirm.Enabled =
				btnPrint.Enabled =
				btnService.Enabled = false;
			}

			if (tcList.SelectedTab.Name.ToUpper().Contains("DATA"))
			{
				btnAdd.Enabled = true;
				grdData.Select();
			}
		}

		#region Bottom Tab Restore

		private bool tabMovingsGoods_Restore()
		{
			return grdMovingsGoods_Restore();
		}

		private bool tabTrafficsGoods_Restore()
		{
			return grdTrafficsGoods_Restore();
		}

		#endregion Bottom Tab Restore

		#endregion Tab Restore

		#region Prepare IDList

		public void MovingPrepareIDList(Moving oMoving, bool bMultiSelect)
		{
			RFMCursorWait.Set(true);

			oMoving.ID = null;
			oMoving.IDList = null;

			int? nMovingID = 0;
			if (bMultiSelect && grdData.IsCheckerShow)
			{
				oMoving.IDList = "";

				DataView dMarked = new DataView(oMovingList.MainTable);
				dMarked.RowFilter = "IsMarked = true";
				dMarked.Sort = grdData.GridSource.Sort;
				foreach (DataRowView r in dMarked)
				{
					if (!Convert.IsDBNull(r["ID"]))
					{
						nMovingID = (int)r["ID"];
						oMoving.IDList = oMoving.IDList + nMovingID.ToString() + ",";
					}
				}
			}
			else
			{
				nMovingID = (int?)grdData.CurrentRow.Cells["grcID"].Value;
				if (nMovingID.HasValue)
				{
					oMoving.ID = nMovingID;
				}
			}

			RFMCursorWait.Set(false);
		}

		public int CalcMarkedRows()
		{
			int nCnt = 0;
			if (grdData.IsCheckerShow)
			{
				DataView dMarked = new DataView(oMovingList.MainTable);
				dMarked.RowFilter = "IsMarked = true";
				nCnt = dMarked.Count;
			}
			return (nCnt);
		}

		#endregion Prepare IDList

		#region Buttons

		private void btnAdd_Click(object sender, EventArgs e)
		{
			if (StartForm(new frmMovingsEdit(null)) == DialogResult.Yes)
			{
				int nMovingID = (int)GotParam.GetValue(0);
				grdData_Restore();
				if (nMovingID > 0)
				{
					grdData.GridSource.Position = grdData.GridSource.Find(oMovingList.ColumnID, nMovingID);
				}
			}
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			if (grdData.CurrentRow == null)
				return;

			oMovingCur.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			if (StartForm(new frmMovingsEdit((int)oMovingCur.ID)) == DialogResult.Yes)
			{
				grdData_Restore();
			}
		}

		private void btnConfirm_Click(object sender, EventArgs e)
		{
			if (grdData.CurrentRow == null)
				return;

			oMovingCur.ClearError();
			oMovingCur.ClearFilters();
			oMovingCur.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			oMovingCur.FillData();
			if (oMovingCur.ErrorNumber != 0 || oMovingCur.MainTable == null || 
				oMovingCur.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о внутр.перемещении...");
				return;
			}

			DataRow mr = oMovingCur.MainTable.Rows[0];
			if (!Convert.IsDBNull(mr["DateConfirm"]))
			{
				RFMMessage.MessageBoxError("Перемещение уже подтверждено...");
				return;
			}

			if (StartForm(new frmMovingsConfirm((int)oMovingCur.ID)) == DialogResult.Yes)
			{
				// если подтверждено - пропишем пользователя, выполнявшего все перемещения коробок/штук TrafficsGoods
				MovingTrafficsGoodsChangeUser(oMovingCur);

				grdData_Restore();
			}
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (grdData.CurrentRow == null)
				return;
			if (Convert.IsDBNull(grdData.CurrentRow.Cells["grcID"].Value))
				return;

			int nMovingDeleteID = (int)grdData.CurrentRow.Cells["grcID"].Value;

			Moving oMovingDelete = new Moving();
			oMovingDelete.ID = nMovingDeleteID;
			oMovingDelete.FillData();
			if (oMovingDelete.ErrorNumber != 0 || oMovingDelete.MainTable == null || oMovingDelete.MainTable.Rows.Count != 1)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о внутреннем перемещении с кодом " + nMovingDeleteID.ToString() + "...");
				return;
			}

			oMovingDelete.FillTableMovingsTrafficsGoods(nMovingDeleteID);
			if (oMovingDelete.ErrorNumber != 0 || oMovingDelete.TableMovingsTrafficsGoods == null)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о перемещениях коробок/штук во внутреннем перемещении с кодом " + nMovingDeleteID.ToString() + "...");
				return;
			}

			DataRow ri = oMovingDelete.MainTable.Rows[0];
			if (!Convert.IsDBNull(ri["DateConfirm"]))
			{
				RFMMessage.MessageBoxError("Внутреннее перемещение уже подтверждено...");
				return;
			}

			// по трафикам - не обрабатывается ли уже что?
			foreach (DataRow ric in oMovingDelete.TableMovingsTrafficsGoods.Rows)
			{
				if (!Convert.IsDBNull(ric["DateConfirm"]))
				{
					RFMMessage.MessageBoxError("Некоторые перемещения коробок/штук уже подтверждены...");
					return;
				}
				if (!Convert.IsDBNull(ric["DateAccept"]))
				{
					RFMMessage.MessageBoxError("Некоторые перемещения коробок/штук уже обрабатываются...");
					return;
				}
			}

			if (RFMMessage.MessageBoxYesNo("Удалить внутреннее перемещение с кодом " + nMovingDeleteID.ToString() + "?") != DialogResult.Yes)
				return;

			// все проверено. можно удалять все перемещение целиком 
			oMovingDelete.DeleteData(nMovingDeleteID);
			if (oMovingDelete.ErrorNumber == 0)
			{
				grdData_Restore();
			}
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

		#region TimerTick, CellFormatting

		private void grdData_CurrentRowChanged(object sender)
		{
			if (grdData.IsLockRowChanged)
				return;

			tmrRestore.Enabled = true;
		}

		private void tmrRestore_Tick(object sender, EventArgs e)
		{
			tmrRestore.Enabled = false;

			if (grdData.CurrentRow == null)
				return;

			int rowIndex = grdData.CurrentRow.Index;

			btnPrint.Enabled =
			btnService.Enabled = 
				true;

			if (grdData.IsStatusRow(rowIndex))
			{
				oMovingCur.ID = 0;
				btnEdit.Enabled =
				btnConfirm.Enabled =
					false;
			}
			else
			{
				DataGridViewRow r = grdData.Rows[rowIndex];
				oMovingCur.ID = (int)r.Cells["grcID"].Value;
				bool bIsConfirmed = (bool)r.Cells["grcIsConfirmed"].Value;
				btnEdit.Enabled = !bIsConfirmed;
				btnDelete.Enabled = !bIsConfirmed;
				btnConfirm.Enabled = !bIsConfirmed;
			}

			tcMovingsTraffics.SetAllNeedRestore(true);
		}

		private void grdData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (grdData.DataSource == null)
				return;

			if (grdData.IsStatusRow(e.RowIndex))
			{
				switch (grdData.Columns[e.ColumnIndex].Name)
				{
					case "grcIsConfirmedImage":
					case "grcMovingTrafficsInfoImage":
						e.Value = Properties.Resources.Empty;
						break;
				}
				return;
			}

			DataGridViewRow r = grdData.Rows[e.RowIndex];
			switch (grdData.Columns[e.ColumnIndex].Name)
			{
				case "grcIsConfirmedImage":
					if ((bool)r.Cells["grcIsConfirmed"].Value)
					{
						e.Value = Properties.Resources.Check;
					}
					else
					{
						e.Value = Properties.Resources.Empty;
					}
					break;
				case "grcMovingTrafficsInfoImage":
					if (r.Cells["grcMovingTrafficsInfo"].Value.ToString().Length == 0)
					{
						e.Value = Properties.Resources.Empty;
					}
					else
					{
						switch ((int)r.Cells["grcMovingTrafficsInfo"].Value)
						{
							case 0:
								e.Value = Properties.Resources.DotRed;
								break;
							case 1:
								e.Value = Properties.Resources.DotYellow;
								break;
							case 2:
								e.Value = Properties.Resources.DotGreen;
								break;
						}
					}
					break;
			}
		}

		private void grdMovingsGoods_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			RFMDataGridView grd = grdMovingsGoods;

			if (grd.DataSource == null)
				return;

			if (grd.IsStatusRow(e.RowIndex))
			{
				switch (grd.Columns[e.ColumnIndex].Name)
				{
					case "grcResult":
						e.Value = Properties.Resources.Empty;
						break;
				}
				return;
			}

			DataGridViewRow r = grd.Rows[e.RowIndex];
			switch (grd.Columns[e.ColumnIndex].Name)
			{
				case "grcResult":
					if (Convert.ToDecimal(r.Cells["grcQntConfirmed"].Value) == 0)
						e.Value = Properties.Resources.DotRed;
					else
					{
						if (Convert.ToDecimal(r.Cells["grcQntWished"].Value) ==
								Convert.ToDecimal(r.Cells["grcQntConfirmed"].Value))
						{
							e.Value = Properties.Resources.DotGreen;
						}
						else
						{
							e.Value = Properties.Resources.DotYellow;
						}
					}
					break;
				case "grcQntWished":
				case "grcQntConfirmed":
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
					break;
			}

			if ((grd.Columns[e.ColumnIndex].Name.Contains("Qnt") ||
				 grd.Columns[e.ColumnIndex].Name.Contains("Box") ||
				 grd.Columns[e.ColumnIndex].Name.Contains("Pal")) &&
				grd.Columns[e.ColumnIndex].DefaultCellStyle.Format.Contains("N"))
			{
				if (Convert.IsDBNull(e.Value) || Convert.ToDecimal(e.Value) == 0)
				{
					e.Value = "";
				}
			}
		}

		private void grdTrafficsGoods_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			RFMDataGridView grd = grdTrafficsGoods;

			if (grd.DataSource == null)
				return;

			if (grd.IsStatusRow(e.RowIndex))
			{
				switch (grd.Columns[e.ColumnIndex].Name)
				{
					case "grcTrafficsGoodsStatusImage":
						e.Value = Properties.Resources.Empty;
						break;
					case "grcTrafficsGoodsQntWished":
					case "grcTrafficsGoodsQntConfirmed":
					case "grcTrafficsGoodsInBox":
						e.CellStyle.Format = "### ### ### ###";
						break;
				}
				return;
			}

			DataGridViewRow r = grd.Rows[e.RowIndex];
			DataGridViewColumn c = grd.Columns[e.ColumnIndex];
			switch (c.Name)
			{
				case "grcTrafficsGoodsStatusImage":
					if (r.Cells["grcTrafficsGoodsDateConfirm"].Value.ToString().Length == 0)
						e.Value = Properties.Resources.Empty;
					else
						if ((bool)r.Cells["grcTrafficsGoodsSuccess"].Value)
							if ((decimal)r.Cells["grcTrafficsGoodsQntConfirmed"].Value == 0)
								e.Value = Properties.Resources.CheckRed;
							else
								e.Value = Properties.Resources.Check;
						else
							e.Value = Properties.Resources.CheckRed;
					break;
				case "grcTrafficsGoodsQntConfirmed":
				case "grcTrafficsGoodsQntWished":
				case "grcTrafficsGoodsInBox":
					if (!Convert.IsDBNull(r.Cells["grcTrafficsGoodsWeighting"].Value) &&
						Convert.ToBoolean(r.Cells["grcTrafficsGoodsWeighting"].Value) ||
						!Convert.IsDBNull(e.Value) && Convert.ToDecimal(e.Value) != Convert.ToInt32(e.Value))
						e.CellStyle.Format = "### ### ### ###.000";
					else
						e.CellStyle.Format = "### ### ### ###";
					break;
			}
			switch (c.Name)
			{
				case "grcTrafficsGoodsQntConfirmed":
				case "grcTrafficsGoodsBoxConfirmed":
				case "grcTrafficsGoodsPalConfirmed":
					if (Convert.ToDecimal(r.Cells["grcTrafficsGoodsQntWished"].Value) != Convert.ToDecimal(r.Cells["grcTrafficsGoodsQntConfirmed"].Value))
						e.CellStyle.ForeColor = Color.Red;
					break;
			}

			if ((c.Name.Contains("Qnt") ||
				 c.Name.Contains("Box") ||
				 c.Name.Contains("Pal")) &&
				c.DefaultCellStyle.Format.Contains("N"))
			{
				if (Convert.IsDBNull(e.Value) || Convert.ToDecimal(e.Value) == 0)
				{
					e.Value = "";
				}
			}
		}

		#endregion

		#region Restore

		private bool grdData_Restore()
		{
			RFMCursorWait.Set(true);
			RFMCursorWait.LockWindowUpdate(FindForm().Handle);

			oMovingCur.ID = null;

			oMovingList.ClearError();
			oMovingList.ClearFilters();
			oMovingList.ID = null;
			oMovingList.IDList = null;

			// собираем условия

			/*
			// штрих-код
			if (txtBarCode.Text.Trim().Length > 0)
			{
				oMovingList.BarCode = txtBarCode.Text.Trim();
			}
			*/

			// даты
			if (!dtrDates.dtpBegDate.IsEmpty)
			{
				oMovingList.FilterDateBeg = dtrDates.dtpBegDate.Value.Date;
			}
			if (!dtrDates.dtpEndDate.IsEmpty)
			{
				oMovingList.FilterDateEnd = dtrDates.dtpEndDate.Value.Date;
			}
			// тип перемещения
			if (sSelectedMovingsTypesIDList.Length > 0)
			{
				oMovingList.FilterMovingsTypesList = sSelectedMovingsTypesIDList;
			}
			// состояние
			if (sSelectedGoodsStatesIDList.Length > 0)
			{
				oMovingList.FilterGoodsStatesList = sSelectedGoodsStatesIDList;
			}
			if (sSelectedGoodsStatesNewIDList.Length > 0)
			{
				oMovingList.FilterGoodsStatesNewList = sSelectedGoodsStatesNewIDList;
			}
			// владельцы
			if (sSelectedOwnerIDList.Length > 0)
			{
				oMovingList.FilterOwnersList = sSelectedOwnerIDList;
			}

			// ИСТОЧНИК
			// ячейка
			oCellSource.ClearData();
			if ((txtCellSourceBarCode.Text.Trim().Length > 0) |
				(txtCellSourceAddress.Text.Trim().Length > 0))
			{
				if (txtCellSourceBarCode.Text.Trim().Length > 0)
					oCellSource.BarCode = txtCellSourceBarCode.Text.Trim();
				if (txtCellSourceAddress.Text.Trim().Length > 0)
					oCellSource.FilterAddress = txtCellSourceAddress.Text.Trim();
				oCellSource.FillData();
				if (oCellSource.MainTable.Rows.Count > 0)
				{
					StringBuilder sbCS = new StringBuilder("");
					foreach (DataRow r in oCellSource.MainTable.Rows)
						sbCS = sbCS.Append(r["ID"].ToString() + ",");
					if (sbCS.Length > 0)
						oMovingList.FilterCellsSourceList = sbCS.ToString();
				}
				else
				{
					oMovingList.FilterCellsSourceList = "-1";
				}
			}
			// зоны
			if (sSelectedStoresZonesIDList.Length > 0)
			{
				oMovingList.FilterStoresZonesSourceList = sSelectedStoresZonesIDList;
			}
			if (sSelectedStoresZonesTypesIDList.Length > 0)
			{
				oMovingList.FilterStoresZonesTypesSourceList = sSelectedStoresZonesTypesIDList;
			}

			// подтверждение внутр.перемещения
			if (optIsConfirmed.Checked)
			{
				oMovingList.FilterConfirmed = true;
			}
			if (optIsNotConfirmed.Checked)
			{
				oMovingList.FilterConfirmed = false;
			}

			// состояние перемещений коробок/штук
			if (optTrafficsInfo0.Checked)
			{
				oMovingList.FilterMovingTrafficsInfo = 0;
			}
			if (optTrafficsInfo1.Checked)
			{
				oMovingList.FilterMovingTrafficsInfo = 1;
			}
			if (optTrafficsInfo2.Checked)
			{
				oMovingList.FilterMovingTrafficsInfo = 2;
			}

			// выбранные товары
			if (sSelectedPackingsIDList.Length > 0)
			{
				oMovingList.FilterPackingsList = sSelectedPackingsIDList;
			}
			//

			grdMovingsGoods.DataSource = null;
			grdTrafficsGoods.DataSource = null;
			grdData.GetGridState();

			oMovingList.FillData();

			grdData.IsLockRowChanged = true;
			grdData.Restore(oMovingList.MainTable);
			tmrRestore.Enabled = true;

			RFMCursorWait.LockWindowUpdate(IntPtr.Zero);
			RFMCursorWait.Set(false);

			return (oMovingList.ErrorNumber == 0);
		}

		private bool grdMovingsGoods_Restore()
		{
			grdMovingsGoods.GetGridState();
			grdMovingsGoods.DataSource = null;
			if (grdData.Rows.Count == 0 ||
				oMovingCur.ID == null ||
				grdData.CurrentRow != null && grdData.IsStatusRow(grdData.CurrentRow.Index))
				return (true);

			oMovingList.ClearError();
			oMovingList.FillTableMovingsGoods((int)oMovingCur.ID);

			if (chkShowSelectedGoodsOnly.Enabled && chkShowSelectedGoodsOnly.Checked &&
				sSelectedPackingsIDList != null && sSelectedPackingsIDList.Length > 0)
			{
				DataTable dt = CopyTable(oMovingList.TableMovingsGoods, "dt",
					"PackingID in (" + RFMPublic.RFMUtilities.NormalizeList(sSelectedPackingsIDList) + ")",
					"GoodAlias, ID");
				oMovingList.TableMovingsGoods.Clear();
				oMovingList.TableMovingsGoods.Merge(dt);
			}

			grdMovingsGoods.Restore(oMovingList.TableMovingsGoods);

			return (oMovingList.ErrorNumber == 0);
		}

		private bool grdTrafficsGoods_Restore()
		{
			grdTrafficsGoods.GetGridState();
			grdTrafficsGoods.DataSource = null;
			if (grdData.Rows.Count == 0 ||
				oMovingCur.ID == null ||
				grdData.CurrentRow != null && grdData.IsStatusRow(grdData.CurrentRow.Index))
				return (true);

			oMovingList.ClearError();
			oMovingList.FillTableMovingsTrafficsGoods((int)oMovingCur.ID);

			if (chkShowSelectedGoodsOnly.Enabled && chkShowSelectedGoodsOnly.Checked &&
				sSelectedPackingsIDList != null && sSelectedPackingsIDList.Length > 0)
			{
				DataTable dt = CopyTable(oMovingList.TableMovingsTrafficsGoods, "dt",
					"PackingID in (" + RFMPublic.RFMUtilities.NormalizeList(sSelectedPackingsIDList) + ")",
					"DateBirth, UserName, ID");
				oMovingList.TableMovingsTrafficsGoods.Clear();
				oMovingList.TableMovingsTrafficsGoods.Merge(dt);
			}

			grdTrafficsGoods.Restore(oMovingList.TableMovingsTrafficsGoods);
			return (oMovingList.ErrorNumber == 0);
		}

		#endregion Restore

		#region Filters

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

				chkShowSelectedGoodsOnly.Enabled = true;

				tabData.IsNeedRestore = true;
			}

			_SelectedPackingIDList = null;
			_SelectedPackingAliasText = "";
		}

		private void btnPackingsClear_Click(object sender, EventArgs e)
		{
			tabData.IsNeedRestore = true;

			chkShowSelectedGoodsOnly.Checked =
			chkShowSelectedGoodsOnly.Enabled =
				false;

			ttToolTip.SetToolTip(txtPackingsChoosen, "не выбраны");
			sSelectedPackingsIDList = "";
			txtPackingsChoosen.Text = "";
		}

		# endregion

		#region Owners

		private void btnOwnersChoose_Click(object sender, EventArgs e)
		{
			_SelectedIDList = null;
			_SelectedText = "";

			Partner oOwner = new Partner();
			oOwner.FilterOwner = true;
			oOwner.FilterActual = true;
			oOwner.FillData();
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

				sSelectedOwnerIDList = "," + _SelectedIDList;

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
			sSelectedOwnerIDList = "";
			txtOwnersChoosen.Text = "";
		}

		#endregion

		#region MovingsTypes

		private void btnMovingsTypesChoose_Click(object sender, EventArgs e)
		{
			_SelectedIDList = null;
			_SelectedText = "";

			Moving oMovingForType = new Moving();
			oMovingForType.FillTableMovingsTypes();
			if (oMovingForType.ErrorNumber != 0 || oMovingForType.TableMovingsTypes == null)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных...");
				return;
			}
			if (oMovingForType.TableMovingsTypes.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Нет данных...");
				return;
			}

			if (StartForm(new frmSelectID(this, oMovingForType.TableMovingsTypes, "Name", "Тип перемещения", true)) == DialogResult.Yes)
			{
				if (_SelectedIDList == null || !_SelectedIDList.Contains(","))
				{
					btnMovingsTypesClear_Click(null, null);
					return;
				}

				sSelectedMovingsTypesIDList = "," + _SelectedIDList;

				txtMovingsTypesChoosen.Text = _SelectedText;
				ttToolTip.SetToolTip(txtMovingsTypesChoosen, txtMovingsTypesChoosen.Text);

				tabData.IsNeedRestore = true;
			}

			_SelectedIDList = null;
			_SelectedText = "";
		}

		private void btnMovingsTypesClear_Click(object sender, EventArgs e)
		{
			tabData.IsNeedRestore = true;

			ttToolTip.SetToolTip(txtMovingsTypesChoosen, "не выбраны");
			sSelectedMovingsTypesIDList = "";
			txtMovingsTypesChoosen.Text = "";
		}

		#endregion MovingsTypes

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


		private void btnGoodsStatesNewChoose_Click(object sender, EventArgs e)
		{
			_SelectedIDList = null;
			_SelectedText = "";

			GoodState oGoodStateNew = new GoodState();
			oGoodStateNew.FillData();
			if (oGoodStateNew.ErrorNumber != 0 || oGoodStateNew.MainTable == null)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных...");
				return;
			}
			if (oGoodStateNew.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Нет данных...");
				return;
			}

			if (StartForm(new frmSelectID(this, oGoodStateNew.MainTable, "Name", "Состояние товара", true)) == DialogResult.Yes)
			{
				if (_SelectedIDList == null || !_SelectedIDList.Contains(","))
				{
					btnGoodsStatesNewClear_Click(null, null);
					return;
				}

				sSelectedGoodsStatesNewIDList = "," + _SelectedIDList;

				txtGoodsStatesNewChoosen.Text = _SelectedText;
				ttToolTip.SetToolTip(txtGoodsStatesNewChoosen, txtGoodsStatesNewChoosen.Text);

				tabData.IsNeedRestore = true;
			}

			_SelectedIDList = null;
			_SelectedText = "";
		}

		private void btnGoodsStatesNewClear_Click(object sender, EventArgs e)
		{
			tabData.IsNeedRestore = true;

			ttToolTip.SetToolTip(txtGoodsStatesNewChoosen, "не выбраны");
			sSelectedGoodsStatesNewIDList = "";
			txtGoodsStatesNewChoosen.Text = "";
		}

		#endregion GoodsStates

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

				tabData.IsNeedRestore = true;
			}

			_SelectedIDList = null;
			_SelectedText = "";
		}

		private void btnStoresZonesClear_Click(object sender, EventArgs e)
		{
			tabData.IsNeedRestore = true;

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

				tabData.IsNeedRestore = true;
			}

			_SelectedIDList = null;
			_SelectedText = "";
		}

		private void btnStoresZonesTypesClear_Click(object sender, EventArgs e)
		{
			tabData.IsNeedRestore = true;

			ttToolTip.SetToolTip(txtStoresZonesTypesChoosen, "не выбраны");
			sSelectedStoresZonesTypesIDList = "";
			txtStoresZonesTypesChoosen.Text = "";
		}

		#endregion StoresZonesTypes

		#endregion Filters

		#region Menu Print

		private void btnPrint_Click(object sender, EventArgs e)
		{
			mnuPrint.Show(btnPrint, new Point());
		}

		private void btnPrint_MouseClick(object sender, MouseEventArgs e)
		{
			mnuPrint.Show(btnPrint, new Point(e.X, e.Y));
		}

		private void mniPrintMovingBill_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.CurrentRow == null)
				return;

			RFMCursorWait.Set(true);

			Moving oMovingPrint = new Moving();

			// получение данных 
			oMovingPrint.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			oMovingPrint.FillData();
			if (oMovingPrint.ErrorNumber != 0)
			{
				RFMCursorWait.Set(false);
				return;
			}
			oMovingPrint.FillTableMovingsGoods(oMovingCur.ID);
			if (oMovingPrint.ErrorNumber != 0)
			{
				RFMCursorWait.Set(false);
				return;
			}

			// печать
			oMovingPrint.DS.Relations.Add("r1", oMovingPrint.MainTable.Columns["MovingID"],
				oMovingPrint.TableMovingsGoods.Columns["MovingID"]);
			// добавляем нужные поля в таблицу-источник
			RepTableColumnAdd(oMovingPrint.TableMovingsGoods);

			RFMCursorWait.Set(false);

			repMovingBill rep = new repMovingBill();
			StartForm(new frmActiveReport(oMovingPrint.DS.Tables["TableMovingsGoods"], rep));

			// отметка печати
			if (oMovingPrint.ErrorNumber == 0)
			{
				oMovingPrint.SetDatePrint((int)oMovingPrint.ID);
			}
			grdData_Restore();
		}

		private void RepTableColumnAdd(DataTable tTable)
		{
			tTable.Columns.Add("MovingTypeName").Expression = "Parent([r1]).MovingTypeName";
			tTable.Columns.Add("GoodStateName").Expression = "Parent([r1]).GoodStateName";
			tTable.Columns.Add("OwnerName").Expression = "Parent([r1]).OwnerName";
			tTable.Columns.Add("DateMoving").Expression = "Parent([r1]).DateMoving";
			tTable.Columns.Add("DateConfirm").Expression = "Parent([r1]).DateConfirm";
			tTable.Columns.Add("MovingNote").Expression = "Parent([r1]).Note";
			tTable.Columns.Add("CellSourceAddress").Expression = "Parent([r1]).CellSourceAddress";
			tTable.Columns.Add("StoreZoneSourceName").Expression = "Parent([r1]).StoreZoneSourceName";

			tTable.Columns.Add("DateMovingText");
			tTable.Columns.Add("DateConfirmText");
			foreach (DataRow r in tTable.Rows)
			{
				r["DateMovingText"] = r["DateMoving"].ToString().Substring(0, 10);
				r["DateConfirmText"] = (Convert.IsDBNull(r["DateConfirm"])) ? "Не подтв." : "Подтв. " + r["DateConfirm"].ToString().Substring(0, 16);
			}
		}


		private void mniPrintTrafficsGoodsList_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.CurrentRow == null)
				return;

			RFMCursorWait.Set(true);

			bool bAll = ((ToolStripMenuItem)sender).Name.EndsWith("All"); // все отмеченные записи

			Moving oMovingPrint = new Moving();
			TrafficGood oTrafficPrint = new TrafficGood();
			DataTable tTable;

			if (bAll)
			{
				MovingPrepareIDList(oMovingPrint, bAll);
				if (oMovingPrint.IDList == null || oMovingPrint.IDList.Length == 0)
				{
					RFMCursorWait.Set(false);
					RFMMessage.MessageBoxError("Нет отмеченных записей...");
					return;
				}
				// список перемещений для всех отмеченных внутр.перемещений
				oTrafficPrint.FilterMovingsList = oMovingPrint.IDList;
			}
			else
			{
				if (Convert.IsDBNull(grdData.CurrentRow.Cells["grcID"].Value) ||
					grdData.CurrentRow.Cells["grcID"].Value == null)
				{
					RFMCursorWait.Set(false);
					return;
				}
				oMovingPrint.ID = Convert.ToInt32(grdData.CurrentRow.Cells["grcID"].Value);
				// список перемещений для этого внутр.перемещения
				oTrafficPrint.FilterMovingsList = oMovingPrint.ID.ToString();
			}

			oMovingPrint.FillData();
			if (oMovingPrint.ErrorNumber != 0)
			{
				RFMCursorWait.Set(false);
				return;
			}

			// только подтвержденные
			oTrafficPrint.FilterConfirmed = true;
			oTrafficPrint.FillData();
			if (oTrafficPrint.ErrorNumber != 0)
			{
				RFMCursorWait.Set(false);
				return;
			}
			int nCntConfirmed = oTrafficPrint.MainTable.Rows.Count;
			// все
			oTrafficPrint.FilterConfirmed = null;
			oTrafficPrint.FillData();
			if (oTrafficPrint.ErrorNumber != 0)
			{
				RFMCursorWait.Set(false);
				return;
			}
			if (oTrafficPrint.MainTable.Rows.Count == 0)
			{
				RFMCursorWait.Set(false);
				RFMMessage.MessageBoxError("Нет данных о перемещениях коробок/штук для " + ((bAll) ? "отмеченных внутр.перемещений..." : "внутр.перемещения..."));
				return;
			}

			if (oTrafficPrint.MainTable.Rows.Count == nCntConfirmed)
			{
				// все подтверждены
				RFMCursorWait.Set(false);
				if (RFMMessage.MessageBoxYesNo("Нет данных о неподтвержденных перемещениях коробок/штук для " + ((bAll) ? "отмеченных внутр.перемещений" : "внутр.перемещения") + "...\n" +
					"Сформировать лист заданий для подтвержденных перемещений?") == DialogResult.No)
				{
					return;
				}
				Refresh();
			}
			else
			{
				if (nCntConfirmed > 0)
				{
					// есть подтвержденные 
					if (RFMMessage.MessageBoxYesNo("Выводить данные о подтвержденных перемещениях?") == DialogResult.No)
					{
						Refresh();
						oTrafficPrint.FilterConfirmed = false;
						oTrafficPrint.FillData();
					}
				}
			}

			DataView dv = new DataView(oTrafficPrint.MainTable);
			dv.Sort = "MovingID, CellTargetAddress, StoreZoneSourceName, StoreZoneSourceID, CellSourceRank, CellSourceAddress, GoodAlias";
			tTable = dv.ToTable();

			RFMCursorWait.Set(false);

			// печать 
			repTrafficGoodBill rd = new repTrafficGoodBill();
			StartForm(new frmActiveReport(tTable, rd));

			// отметка печати
			if (oTrafficPrint.ErrorNumber == 0)
			{
				DataTable dtPrint = new DataTable();
				dtPrint.Columns.Add("MovingID", Type.GetType("System.Int32"));
				DataColumn[] pk = new DataColumn[1];
				pk[0] = dtPrint.Columns[0];
				dtPrint.PrimaryKey = pk;

				foreach (DataRow r in oTrafficPrint.MainTable.Rows)
				{
					if (!Convert.IsDBNull(r["MovingID"]) &&
						dtPrint.Rows.Find(Convert.ToInt32(r["MovingID"])) == null)
					{
						oMovingPrint.SetDatePrint(Convert.ToInt32(r["MovingID"]));
						dtPrint.Rows.Add(Convert.ToInt32(r["MovingID"]));
					}
				}
				grdData_Restore();
			}
		}

		#endregion

		#region Menu Service

		private void btnService_Click(object sender, EventArgs e)
		{
			mnuService.Show(btnService, new Point());
		}
		private void btnService_MouseClick(object sender, MouseEventArgs e)
		{
			mnuService.Show(btnService, new Point(e.X, e.Y));
		}

		private void MovingTrafficsGoodsChangeUser(Moving oMovingChangeUser)
		{
			if (!oMovingChangeUser.ID.HasValue && oMovingChangeUser.IDList == null)
				return;
  
			oMovingChangeUser.FillData();
			if (oMovingChangeUser.ErrorNumber != 0 || oMovingChangeUser.MainTable == null ||
				oMovingChangeUser.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о внутрискладском перемещении (регистрация сотрудника)...");
				return;
			}
			DataRow m = oMovingChangeUser.MainTable.Rows[0];
			if (Convert.IsDBNull(m["DateConfirm"]))
			{
				// перемещение не подтверждено - выходим молча
				return;
			}

			// перемещения кор./штук
			TrafficGood oTrafficGoodTemp = new TrafficGood();
			oTrafficGoodTemp.FilterMovingsList = oMovingCur.ID.ToString();
			oTrafficGoodTemp.FillData();
			if (oTrafficGoodTemp.ErrorNumber != 0 || oTrafficGoodTemp.MainTable == null)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о перемещениях коробок/штук для текущего внутрискладского перемещения...");
				return;
			}
			if (oTrafficGoodTemp.MainTable.Rows.Count > 0)
			{
				// список сотрудников 
				User oUser = new User();
				oUser.FilterActual = true;
				oUser.FillData();
				if (oUser.ErrorNumber != 0 || oUser.MainTable == null)
				{
					RFMMessage.MessageBoxError("Ошибка при получении списка сотрудников...");
					return;
				}
				if (oUser.MainTable.Rows.Count == 0)
				{
					RFMMessage.MessageBoxError("Нет данных о сотрудниках...");
					return;
				}

				int nNewUserID = 0;
				string sNewUserName = "";
				_SelectedID = null;
				if (StartForm(new frmSelectID(this, oUser.MainTable, "Name", "Сотрудник", "Сотрудник, выполнявший перемещения")) == DialogResult.Yes)
				{
					if (_SelectedID.HasValue)
					{
						nNewUserID = (int)_SelectedID;
						sNewUserName = _SelectedText;
					}
				}
				if (nNewUserID == 0)
					return;

				if (RFMMessage.MessageBoxYesNo("Зарегистрировать сотрудника \"" + sNewUserName + "\",\n" +
					"выполнявшего " + RFMUtilities.Declen(oTrafficGoodTemp.MainTable.Rows.Count, "перемещениe", "перемещения", "перемещений") +
					" коробок/штук для текущего внутрискладского перемещения?") == DialogResult.Yes)
				{
					foreach (DataRow tr in oTrafficGoodTemp.MainTable.Rows)
					{
						oTrafficGoodTemp.UserChange((int)tr["ID"], nNewUserID);
					}
				}
			}
		}

		#endregion

		#region Terms clear

		private void btnClearTerms_Click(object sender, EventArgs e)
		{
			//txtBarCode.Text = "";

			dtrDates.dtpBegDate.Value = DateTime.Now.AddDays(-7).Date;
			dtrDates.dtpEndDate.Value = DateTime.Now.AddDays(7).Date;

			oCellSource.ClearFilters();
			txtCellSourceAddress.Text = "";
			txtCellSourceBarCode.Text = "";
			btnStoresZonesClear_Click(null, null);
			btnStoresZonesTypesClear_Click(null, null);

			optIsNotConfirmed.Checked = true;
			optTrafficsInfoAny.Checked = true;

			btnMovingsTypesClear_Click(null, null);
			btnGoodsStatesClear_Click(null, null);
			btnGoodsStatesNewClear_Click(null, null);
			btnOwnersClear_Click(null, null);
			btnPackingsClear_Click(null, null);

			if (Control.ModifierKeys == Keys.Shift)
			{
				optAllConfirmed.Checked = true;
				dtrDates.dtpBegDate.HideControl(false);
				dtrDates.dtpEndDate.HideControl(false);
			}

			tabData.IsNeedRestore = true;
		}

		#endregion

	}
}