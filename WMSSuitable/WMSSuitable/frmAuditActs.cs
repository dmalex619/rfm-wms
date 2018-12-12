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
	public partial class frmAuditActs : RFMFormChild
	{
		private AuditAct oAuditActList; //список приходов
		private AuditAct oAuditActCur;  //текущий приход

		// для фильтров
		public string _SelectedIDList;
		public string _SelectedText;

		public string _SelectedPackingIDList;
		public string _SelectedPackingAliasText;
		private string sSelectedPackingsIDList = "";

		private string sSelectedGoodsStatesIDList = "";
		private string sSelectedOwnerIDList = "";

		private Host oHost;
		private int? nUserHostID = null;


		public frmAuditActs()
		{
			oAuditActList = new AuditAct();
			oAuditActCur = new AuditAct();
			if (oAuditActList.ErrorNumber != 0 ||
				oAuditActCur.ErrorNumber != 0)
			{
				IsValid = false;
			}

			oHost = new Host();
			if (oHost.ErrorNumber != 0)
			{
				IsValid = false;
			}

			if (IsValid)
			{
				InitializeComponent();
			}
		}

		private void frmAuditActs_Load(object sender, EventArgs e)
		{
			RFMCursorWait.Set(true);

			nUserHostID = ((RFMFormMain)Application.OpenForms[0]).UserInfo.HostID;

			lblHosts.Visible =
			ucSelectRecordID_Hosts.Visible =
			ucSelectRecordID_Hosts.Enabled =
				(oHost.Count() > 1 && !nUserHostID.HasValue);

            grcBoxConfirmed.AgrType =
                grcPalConfirmed.AgrType =
                grcQntConfirmed.AgrType = EnumAgregate.Sum;

			btnClearTerms_Click(null, null);

			tcList.Init();
			tcAuditActs.Init();

			RFMCursorWait.Set(false);
		}

		#region Tab Restore 

		private bool tabTerms_Restore()
		{
			btnAdd.Enabled = 
			btnDelete.Enabled = 
			btnEdit.Enabled =
			btnConfirm.Enabled =
			btnPrint.Enabled =
			btnService.Enabled = 
				false;
			return true;
		}

		private bool tabData_Restore()
		{
			grdData_Restore();
			btnAdd.Enabled = false;
			if (grdData.Rows.Count > 0)
			{
				btnEdit.Enabled =
				btnDelete.Enabled =
				btnConfirm.Enabled =
					false; // все из host
				btnPrint.Enabled =
				btnService.Enabled = 
					true;
			}
			else
			{
				btnEdit.Enabled =
				btnConfirm.Enabled =
				btnDelete.Enabled =
				btnPrint.Enabled =
				btnService.Enabled = 
					false;
			}
			return true;
		}

		private bool tabAuditActsGoods_Restore()
		{
			return grdAuditActsGoods_Restore();
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

			btnAdd.Enabled =
			btnEdit.Enabled =
			btnDelete.Enabled =
			btnConfirm.Enabled =
				false; // все приходит из host

			if (grdData.CurrentRow == null)
				return;

			int rowIndex = grdData.CurrentRow.Index;

			if (grdData.IsStatusRow(rowIndex))
			{
				oAuditActCur.ID = 0;
				btnPrint.Enabled =
				btnService.Enabled = 
					false;
			}
			else
			{
				DataGridViewRow r = grdData.Rows[rowIndex];
				oAuditActCur.ID = (int)r.Cells["grcID"].Value;
				btnPrint.Enabled =
				btnService.Enabled = 
					true;
			}

			tcAuditActs.SetAllNeedRestore(true);
		}

		private void grdData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (grdData.DataSource == null)
				return;

			if (grdData.IsStatusRow(e.RowIndex))
			{
				if (grdData.Columns[e.ColumnIndex].Name.Contains("Image"))
				{
					e.Value = Properties.Resources.Empty;
				}
				return;
			}

			DataRow dr = ((DataRowView)grdData.Rows[e.RowIndex].DataBoundItem).Row; 
			switch (grdData.Columns[e.ColumnIndex].Name)
			{
				case "grcIsConfirmedImage":
					if (Convert.ToBoolean(dr["IsConfirmed"]))
						e.Value = Properties.Resources.Check;
					else
						e.Value = Properties.Resources.Empty;
					break;
			}
		}

		private void grdAuditActsGoods_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			RFMDataGridView grd = grdAuditActsGoods;

			if (grd.DataSource == null)
				return;

			if (grd.IsStatusRow(e.RowIndex))
			{
				if (grd.Columns[e.ColumnIndex].Name.Contains("Image"))
				{
					e.Value = Properties.Resources.Empty;
				}
				return;
			}

			DataGridViewRow r = grd.Rows[e.RowIndex];
			switch (grd.Columns[e.ColumnIndex].Name)
			{
				case "grcResultImage":
					if (Convert.ToInt32(r.Cells["grcQntConfirmed"].Value) > 0)
						e.Value = Properties.Resources.Plus;
					else
					{
						if (Convert.ToDecimal(r.Cells["grcQntConfirmed"].Value) < 0)
						{
							e.Value = Properties.Resources.Minus;
						}
						else
						{
							e.Value = Properties.Resources.Empty;
						}
					}
					break;
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

		#endregion

		#region Restore

		private bool grdData_Restore()
		{
			RFMCursorWait.Set(true);
			RFMCursorWait.LockWindowUpdate(FindForm().Handle);

			oAuditActCur.ClearError();
			oAuditActCur.ID = null;

			oAuditActList.ClearError();
			oAuditActList.ClearFilters();
			oAuditActList.ID = null;
			oAuditActList.IDList = null;

			// собираем условия

			// даты
			if (!dtrDates.dtpBegDate.IsEmpty)
			{
				oAuditActList.FilterDateBeg = dtrDates.dtpBegDate.Value.Date;
			}
			if (!dtrDates.dtpEndDate.IsEmpty)
			{
				oAuditActList.FilterDateEnd = dtrDates.dtpEndDate.Value.Date;
			}

			// состояние
			if (sSelectedGoodsStatesIDList.Length > 0)
			{
				oAuditActList.FilterGoodsStatesList = sSelectedGoodsStatesIDList;
			}

			// владельцы
			if (sSelectedOwnerIDList.Length > 0)
			{
				oAuditActList.FilterOwnersList = sSelectedOwnerIDList;
			}

			// выбранные товары
			if (sSelectedPackingsIDList.Length > 0)
			{
				oAuditActList.FilterPackingsList = sSelectedPackingsIDList;
			}

			if (nUserHostID.HasValue)
			{
				oAuditActList.FilterHostsList = nUserHostID.ToString();
			}
			else
			{
				if (ucSelectRecordID_Hosts.IsSelectedExist)
				{
					oAuditActList.FilterHostsList = ucSelectRecordID_Hosts.GetIdString();
				}
			}
			//

			grdAuditActsGoods.DataSource = null;
			grdData.GetGridState();

			oAuditActList.FillData();

			grdData.IsLockRowChanged = true;
			grdData.Restore(oAuditActList.MainTable);

			tmrRestore.Enabled = true;

			RFMCursorWait.LockWindowUpdate(IntPtr.Zero);
			RFMCursorWait.Set(false);

			return (oAuditActList.ErrorNumber == 0);
		}

		private bool grdAuditActsGoods_Restore()
		{
			grdAuditActsGoods.GetGridState(); 
			grdAuditActsGoods.DataSource = null;
			if (grdData.Rows.Count == 0 ||
				oAuditActCur.ID == null ||
				(grdData.CurrentRow != null && grdData.IsStatusRow(grdData.CurrentRow.Index)))
				return (true);

			oAuditActList.FillTableAuditActsGoods((int)oAuditActCur.ID);

			if (chkShowSelectedGoodsOnly.Enabled && chkShowSelectedGoodsOnly.Checked &&
				sSelectedPackingsIDList != null && sSelectedPackingsIDList.Length > 0)
			{
				DataTable dt = CopyTable(oAuditActList.TableAuditActsGoods, "dt",
					"PackingID in (" + RFMPublic.RFMUtilities.NormalizeList(sSelectedPackingsIDList) + ")",
					"GoodAlias, ID");
				oAuditActList.TableAuditActsGoods.Clear();
				oAuditActList.TableAuditActsGoods.Merge(dt);
			}

			grdAuditActsGoods.Restore(oAuditActList.TableAuditActsGoods);
			return (oAuditActList.ErrorNumber == 0);
		}

		#endregion

		#region Menu Print

		private void btnPrint_Click(object sender, EventArgs e)
		{
			mnuPrint.Show(btnPrint, new Point());
		}

		#endregion

		#region Menu Service

		private void btnService_Click(object sender, EventArgs e)
		{
			if (grdData.DataSource == null ||
				grdData.Rows.Count == 0)
				return;

			if (grdData.IsStatusRow(grdData.CurrentRow.Index))
				return;
			
			if (LastGrid.Name.ToUpper() != "grdAuditActsGoods".ToUpper())
				return;

			if (grdAuditActsGoods.DataSource == null ||
				grdAuditActsGoods.Rows.Count == 0)
				return;

			if (grdAuditActsGoods.IsStatusRow(grdAuditActsGoods.CurrentRow.Index))
				return;

			mnuService.Show(btnService, new Point());
		}

		private void GoodsOperations()
		{
			DataRow r = ((DataRowView)grdData.CurrentRow.DataBoundItem).Row;
			DataRow rg = ((DataRowView)grdAuditActsGoods.CurrentRow.DataBoundItem).Row; 

			int nPackingID = Convert.ToInt32(rg["PackingID"]);
			int nGoodStateID = Convert.ToInt32(r["GoodStateID"]);
			int? nOwnerID = null;
			if (!Convert.IsDBNull(r["OwnerID"]))
			{
				nOwnerID = Convert.ToInt32(r["OwnerID"]);
			}

			StartForm(new frmReportPackingsTurnover(nPackingID, nOwnerID, nGoodStateID));
		}

		#endregion

		#region Filters Choose

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
			oOwner.FilterOwner = true;
			oOwner.FilterActual = true;
			oOwner.FillData();
			if (oOwner.ErrorNumber != 0 || oOwner.MainTable == null)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о владельцах...");
				return;
			}
			if (oOwner.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Нет данных о владельцах...");
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

		#endregion

		#region Hosts

		private void ucSelectRecordID_Hosts_Restore()
		{
			if (ucSelectRecordID_Hosts.sourceData == null)
			{
				RFMCursorWait.Set(true);
				oHost.FillData();
				RFMCursorWait.Set(false);
				if (oHost.ErrorNumber != 0 || oHost.MainTable == null)
				{
					RFMMessage.MessageBoxError("Ошибка при получении данных (хосты)...");
					return;
				}
				if (oHost.MainTable.Rows.Count == 0)
				{
					RFMMessage.MessageBoxError("Нет данных (хосты)...");
					return;
				}

				ucSelectRecordID_Hosts.Restore(oHost.MainTable);
			}
			else
			{
				ucSelectRecordID_Hosts.Restore();
			}
		}

		#endregion Hosts

		#endregion

		#region Terms clear

		private void btnClearTerms_Click(object sender, EventArgs e)
		{
			dtrDates.dtpBegDate.Value = DateTime.Now.AddDays(-7).Date;
			dtrDates.dtpEndDate.Value = DateTime.Now.Date;

			btnGoodsStatesClear_Click(null, null);
			btnOwnersClear_Click(null, null);
			btnPackingsClear_Click(null, null);

			ucSelectRecordID_Hosts.ClearData();

			if (Control.ModifierKeys == Keys.Shift)
			{
				dtrDates.dtpBegDate.HideControl(false);
				dtrDates.dtpEndDate.HideControl(false);
			}

			tabData.IsNeedRestore = true;
		}

		#endregion

        private void cntTerms_Paint(object sender, PaintEventArgs e)
        {

        }

	}
}