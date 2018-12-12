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
	public partial class frmOddments : RFMFormChild
	{
		private Oddment oOddmentList;
		private Oddment oOddmentCur;
		private Oddment oOddmentSavedList;
		private Oddment oOddmentSavedCur;

		// для фильтров
		public int? _SelectedID;
		public string _SelectedIDList;
		public string _SelectedText;

		private string sSelectedGoodsStatesIDList = "";
		private string sSelectedOwnersIDList = "";

		public string _SelectedPackingIDList;
		public string _SelectedPackingAliasText;
		private string sSelectedPackingsIDList = "";

		protected int? nPackingID = null;
		protected int? nOwnerID = null;
		protected int? nGoodStateID = null;


		public frmOddments()
		{
			oOddmentList = new Oddment();
			oOddmentCur = new Oddment();
			oOddmentSavedList = new Oddment();
			oOddmentSavedCur = new Oddment();
			if (oOddmentList.ErrorNumber != 0 ||
				oOddmentCur.ErrorNumber != 0 ||
				oOddmentSavedList.ErrorNumber != 0 ||
				oOddmentSavedCur.ErrorNumber != 0)
			{
				IsValid = false;
			}

			if (IsValid)
			{
				InitializeComponent();
			}
		}

		private void frmOddments_Load(object sender, EventArgs e)
		{
			RFMCursorWait.Set(true);

			grcOddmentDetailQnt.AgrType =
			grcOddmentsSavedCalcQnt.AgrType =
			grcOddmentsSavedDiffQnt.AgrType =
			grcOddmentsSavedQnt.AgrType =
			grcQnt.AgrType =
			grcBoxQnt.AgrType =
			grcPalQnt.AgrType =
            grcNettoQnt.AgrType = 
			grcQntStor.AgrType =
			grcOddmentDetailQnt.AgrType =
			grcOddmentDetailBoxQnt.AgrType =
			grcOddmentDetailPalQnt.AgrType =
				EnumAgregate.Sum;

			grdData.IsStatusShow =
			grdOddmentsDetails.IsStatusShow =
				true;

			btnClearTerms_Click(null, null);

			tcList.Init();

			RFMCursorWait.Set(false);
		}

		#region Tab Restore 

		private bool tabTerms_Restore()
		{
			btnDelete.Enabled =
			btnSave.Enabled =
			btnPrint.Enabled =
			btnService.Enabled = 
				false;
			return true;
		}

		private bool tabData_Restore()
		{
			grdData_Restore();
            //btnSave.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
			if (grdData.Rows.Count > 0)
			{
				btnPrint.Enabled =
				btnService.Enabled = true;
			}
			else
			{
				btnPrint.Enabled =
				btnService.Enabled = false;
			}
			grdData.Select();
			return true;
		}

		private bool tabOddmentsSaved_Restore()
		{
			grdOddmentsSaved_Restore();
            //btnSave.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
			if (grdOddmentsSaved.Rows.Count > 0)
			{
				btnPrint.Enabled =
				btnService.Enabled = true;
			}
			else
			{
				btnPrint.Enabled =
				btnService.Enabled = false;
			}
			grdOddmentsSaved.Select();
			return true;
		}

		#endregion Tab Restore

		#region Buttons

		private void btnSave_Click(object sender, EventArgs e)
		{
			switch (tcList.SelectedTab.Name)
			{
				case "tabData":
				case "tabOddmentsSaved":
					if (RFMMessage.MessageBoxYesNo("Сохранить текущие остатки?") == DialogResult.Yes)
					{
						oOddmentSavedList.ClearError();
						int nNewOddmentSavedID = oOddmentSavedList.SaveCopyData();
						if (oOddmentSavedList.ErrorNumber == 0 && nNewOddmentSavedID > 0)
						{
							RFMMessage.MessageBoxInfo("Остатки сохранены.");
							grdOddmentsSaved_Restore();
							grdOddmentsSaved.GridSource.Position = grdOddmentsSaved.GridSource.Find(oOddmentSavedList.ColumnID, nNewOddmentSavedID);
						}
					}
					break;
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

        private void chkShowCost_Click(object sender, EventArgs e)
        {
            grcCost.Visible = chkShowCost.Checked;
        }

		#endregion

		#region TimerTick, CellFormatting

		private void grdData_CurrentRowChanged(object sender)
		{
			if (grdData.IsLockRowChanged)
				return;

			tmrRestore.Enabled = true;
		}

		private void grdOddmentsSaved_CurrentRowChanged(object sender)
		{
			if (grdOddmentsSaved.IsLockRowChanged)
				return;

			tmrRestore.Enabled = true;
		}

		private void tmrRestore_Tick(object sender, EventArgs e)
		{
			tmrRestore.Enabled = false;

			switch (tcList.SelectedTab.Name)
			{
				case "tabData":
					{
						if (grdData.CurrentRow == null)
							return;

                        //btnSave.Enabled =
                        btnSave.Enabled = false;
                        btnPrint.Enabled =
						btnService.Enabled = 
							true;

						nPackingID = nOwnerID = nGoodStateID = null;

						int rowIndex = grdData.CurrentRow.Index;

						if (grdData.IsStatusRow(rowIndex))
						{
							oOddmentCur.ID = 0;
						}
						else
						{
							DataGridViewRow r = grdData.Rows[rowIndex];
							try 
							{ 
								oOddmentCur.ID = Convert.ToInt32(r.Cells["grcID"].Value); 
							}
							catch 
							{ 
								oOddmentCur.ID = 0; 
							}

							if (!Convert.IsDBNull(r.Cells["grcPackingID"].Value))
							{
								nPackingID = Convert.ToInt32(r.Cells["grcPackingID"].Value);
							}
							if (!Convert.IsDBNull(r.Cells["grcOwnerID"].Value))
							{
								nOwnerID = Convert.ToInt32(r.Cells["grcOwnerID"].Value);
							}
							if (!Convert.IsDBNull(r.Cells["grcGoodStateID"].Value))
							{
								nGoodStateID = Convert.ToInt32(r.Cells["grcGoodStateID"].Value);
							}
						}

						grdOddmentsDetails_Restore();
						break;
					}
				case "tabOddmentsSaved":
					{
						if (grdOddmentsSaved.CurrentRow == null)
							return;

						int rowIndex = grdOddmentsSaved.CurrentRow.Index;

						if (grdOddmentsSaved.IsStatusRow(rowIndex))
						{
							oOddmentSavedCur.ID = 0;
						}
						else
						{
							oOddmentSavedCur.ID = (int)grdOddmentsSaved.Rows[rowIndex].Cells["grcOddmentsSavedID"].Value;
						}

						grdOddmentsSavedGoods_Restore();
						break;
					}
				default:
					break;
			}
		}

		private void grdData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (grdData.DataSource == null)
				return;

			RFMDataGridView grd = grdData;

			if (grd.IsStatusRow(e.RowIndex))
			{
				e.CellStyle.BackColor = Color.Silver;
				e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);

				switch (grd.Columns[e.ColumnIndex].Name)
				{
					case "grcResultImage":
						e.Value = Properties.Resources.Empty;
						break;
					case "grcQnt":
					case "grcQntStor":
					case "grcInBox":
						e.CellStyle.Format = "### ### ### ###";
						break;
				}
				return;
			}

			DataGridViewRow r = grd.Rows[e.RowIndex];
			switch (grd.Columns[e.ColumnIndex].Name)
			{
				case "grcResultImage":
					decimal nQnt = Convert.ToDecimal(r.Cells["grcQnt"].Value);
					if (nQnt > 0)
						e.Value = Properties.Resources.DotGreen;
					if (nQnt == 0)
						e.Value = Properties.Resources.DotYellow;
					if (nQnt < 0)
						e.Value = Properties.Resources.DotRed;
					break;
				case "grcQnt":
				case "grcQntStor":
				case "grcInBox":
					if (!Convert.IsDBNull(r.Cells["grcWeighting"].Value) &&
						Convert.ToBoolean(r.Cells["grcWeighting"].Value) ||
						!Convert.IsDBNull(e.Value) && Convert.ToDecimal(e.Value) != Convert.ToInt32(e.Value))
						e.CellStyle.Format = "### ### ### ###.000";
					else
						e.CellStyle.Format = "### ### ### ###";
					break;
				case "grcGoodAlias":
					if (r.Cells["grcGoodAndPackingActual"].Value != DBNull.Value && !(bool)r.Cells["grcGoodAndPackingActual"].Value)
					{
						e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Italic);
						e.CellStyle.ForeColor = Color.Gray;
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

		private void grdOddmentsDetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (grdOddmentsDetails.DataSource == null)
				return;

			RFMDataGridView grd = grdOddmentsDetails;

			if (grd.IsStatusRow(e.RowIndex))
			{
				e.CellStyle.BackColor = Color.Silver;
				e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
				switch (grd.Columns[e.ColumnIndex].Name)
				{
					case "grcOddmentDetailImage":
					case "grcLockedImage":
						e.Value = Properties.Resources.Empty;
						break;
					case "grcOddmentDetailQnt":
						e.CellStyle.Format = "### ### ### ###";
						break;
				}
				return;
			}

			DataGridViewRow r = grd.Rows[e.RowIndex];
			switch (grd.Columns[e.ColumnIndex].Name)
			{
				case "grcOddmentDetailImage":
					if (r.Cells["grcDateValidPercent"].Value == DBNull.Value)
					{
						e.Value = Properties.Resources.Empty;
					}
					else
					{
						decimal nDateValidPercent = Convert.ToDecimal(r.Cells["grcDateValidPercent"].Value);
						if (nDateValidPercent < 20)
							e.Value = Properties.Resources.Plain_R;
						if (nDateValidPercent >= 20 && nDateValidPercent < 50)
							e.Value = Properties.Resources.Plain_Y;
                        if (nDateValidPercent >= 50 && nDateValidPercent < 67)
							e.Value = Properties.Resources.Plain_G;
                        if (nDateValidPercent >= 67)
                            e.Value = Properties.Resources.Plain_B;
                    }
					break;
				case "grcLockedImage":
					if (Convert.ToBoolean(r.Cells["grcLocked"].Value))
						e.Value = Properties.Resources.Lock1;
					else
						e.Value = Properties.Resources.Empty;
					break;
				case "grcOddmentDetailQnt":
					if (!Convert.IsDBNull(r.Cells["grcOddmentDetailWeighting"].Value) &&
						Convert.ToBoolean(r.Cells["grcOddmentDetailWeighting"].Value) ||
						!Convert.IsDBNull(e.Value) && Convert.ToDecimal(e.Value) != Convert.ToInt32(e.Value))
						e.CellStyle.Format = "### ### ### ###.000";
					else
						e.CellStyle.Format = "### ### ### ###";
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

		private void grdOddmentsSaved_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (grdOddmentsSaved.DataSource == null)
				return;

			RFMDataGridView grd = grdOddmentsSaved;

			if (grd.IsStatusRow(e.RowIndex))
			{
				e.CellStyle.BackColor = Color.Silver;
				e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
			}
		}

		private void grdOddmentsSavedGoods_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (grdOddmentsSavedGoods.DataSource == null)
				return;

			RFMDataGridView grd = grdOddmentsSavedGoods;

			if (grd.IsStatusRow(e.RowIndex))
			{
				e.CellStyle.BackColor = Color.Silver;
				e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
				switch (grd.Columns[e.ColumnIndex].Name)
				{
					case "grcOddmentsSavedResultImage":
						e.Value = Properties.Resources.Empty;
						break;
					case "grcOddmentsSavedQnt":
					case "grcOddmentsSavedCalcQnt":
					case "grcOddmentsSavedDiffQnt":
					case "grcOddmentsSavedInBox":
						e.CellStyle.Format = "### ### ### ###";
						break;
				}
				return;
			}

			DataGridViewRow r = grd.Rows[e.RowIndex];
			switch (grd.Columns[e.ColumnIndex].Name)
			{
				case "grcOddmentsSavedResultImage":
					decimal nQnt = Convert.ToDecimal(r.Cells["grcOddmentsSavedQnt"].Value);
					if (nQnt > 0)
						e.Value = Properties.Resources.DotGreen;
					if (nQnt == 0)
						e.Value = Properties.Resources.DotYellow;
					if (nQnt < 0)
						e.Value = Properties.Resources.DotRed;
					break;
				case "grcOddmentsSavedQnt":
				case "grcOddmentsSavedCalcQnt":
				case "grcOddmentsSavedDiffQnt":
				case "grcOddmentsSavedInBox":
					if (!Convert.IsDBNull(r.Cells["grcOddmentsSavedWeighting"].Value) &&
						Convert.ToBoolean(r.Cells["grcOddmentsSavedWeighting"].Value) ||
						Convert.ToDecimal(e.Value) != Convert.ToInt32(e.Value))
						e.CellStyle.Format = "### ### ### ###.000";
					else
						e.CellStyle.Format = "### ### ### ###";
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

			oOddmentCur.ID = null;

			oOddmentList.ClearError();
			oOddmentList.ClearFilters();
			oOddmentList.ID = null;

			// собираем условия

			// состояние товара
			if (sSelectedGoodsStatesIDList.Length > 0)
			{
				oOddmentList.FilterGoodsStatesList = sSelectedGoodsStatesIDList;
			}
			// хранители
			if (sSelectedOwnersIDList.Length > 0)
			{
				oOddmentList.FilterOwnersList = sSelectedOwnersIDList;
			}

			// наличие 
			if (optIsExists.Checked)
				oOddmentList.FilterIsExists = 1;
			if (optNotExists.Checked)
				oOddmentList.FilterIsExists = 0;
			if (optNegative.Checked)
				oOddmentList.FilterIsExists = -1;

			// выбранные товары
			if (sSelectedPackingsIDList.Length > 0)
			{
				oOddmentList.FilterPackingsList = sSelectedPackingsIDList;
			}

			// сроки годности
			if (optDateValidLost.Checked)
			{
				oOddmentList.FilterCheckDateValid = -1;
			}
			if (optDateValidMore.Checked)
			{
				oOddmentList.FilterCheckDateValid = -2;
			}
			if (optDateValidPercent.Checked)
			{
				oOddmentList.FilterCheckDateValid = Convert.ToInt32(numDateValidPercent.Value);
			}
			//

			grdOddmentsDetails.DataSource = null;
			grdData.GetGridState();

			oOddmentList.FillData();

			grdData.IsLockRowChanged = true;
			grdData.Restore(oOddmentList.MainTable);
			tmrRestore.Enabled = true;

			RFMCursorWait.LockWindowUpdate(IntPtr.Zero);
			RFMCursorWait.Set(false);

			return (oOddmentList.ErrorNumber == 0);
		}

		private bool grdOddmentsDetails_Restore()
		{
            grdOddmentsDetails.GetGridState();
			grdOddmentsDetails.DataSource = null;
			if (grdData.Rows.Count == 0 ||
				oOddmentCur.ID == null || nPackingID == null ||
				grdData.CurrentRow != null && grdData.IsStatusRow(grdData.CurrentRow.Index))
				return (false);

			oOddmentList.ClearError();
			oOddmentList.FillTableOddmentsDetails(nOwnerID, nGoodStateID, nPackingID);
			grdOddmentsDetails.Restore(oOddmentList.TableOddmentsDetails);
			return (oOddmentList.ErrorNumber == 0);
		}

		private bool grdOddmentsSaved_Restore()
		{
			RFMCursorWait.Set(true);
			RFMCursorWait.LockWindowUpdate(FindForm().Handle);

			oOddmentSavedCur.ID = null;

			oOddmentSavedList.ClearError();
			oOddmentSavedList.ClearFilters();
			oOddmentSavedList.ID = null;

			// собираем условия

			// даты
			if (!dtrDates.dtpBegDate.IsEmpty)
			{
				oOddmentSavedList.FilterDateBeg = dtrDates.dtpBegDate.Value;
			}

			if (!dtrDates.dtpEndDate.IsEmpty)
			{
				oOddmentSavedList.FilterDateEnd = dtrDates.dtpEndDate.Value;
			}

			grdOddmentsSavedGoods.DataSource = null;
			grdOddmentsSaved.GetGridState();

			oOddmentSavedList.FillTableOddmentsSaved();

			grdOddmentsSaved.IsLockRowChanged = true;
			grdOddmentsSaved.Restore(oOddmentSavedList.TableOddmentsSaved);
			tmrRestore.Enabled = true;

			RFMCursorWait.LockWindowUpdate(IntPtr.Zero);
			RFMCursorWait.Set(false);

			return (oOddmentSavedList.ErrorNumber == 0);
		}

		private bool grdOddmentsSavedGoods_Restore()
		{
			grdOddmentsSavedGoods.GetGridState();
			grdOddmentsSavedGoods.DataSource = null;
			if (grdOddmentsSaved.Rows.Count == 0 || oOddmentSavedCur.ID == null ||
				(grdOddmentsSaved.CurrentRow != null &&
				 grdOddmentsSaved.IsStatusRow(grdOddmentsSaved.CurrentRow.Index)))
				return (false);

			oOddmentSavedList.ClearError();
			oOddmentSavedList.ClearFilters();

			// собираем условия

			// состояние товара
			if (sSelectedGoodsStatesIDList.Length > 0)
			{
				oOddmentSavedList.FilterGoodsStatesList = sSelectedGoodsStatesIDList;
			}
			// хранители
			if (sSelectedOwnersIDList.Length > 0)
			{
				oOddmentSavedList.FilterOwnersList = sSelectedOwnersIDList;
			}

			// выбранные товары
			if (sSelectedPackingsIDList.Length > 0)
			{
				oOddmentSavedList.FilterPackingsList = sSelectedPackingsIDList;
			}
			//

			oOddmentSavedList.FillTableOddmentsSavedGoods((int)oOddmentSavedCur.ID);
			
			grdOddmentsSavedGoods.Restore(oOddmentSavedList.TableOddmentsSavedGoods);

			return (oOddmentSavedList.ErrorNumber == 0);
		}

		#endregion

		#region Filters

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

				tabData.IsNeedRestore = 
				tabOddmentsSaved.IsNeedRestore = 
					true;
			}

			_SelectedIDList = null;
			_SelectedText = "";
		}

		private void btnGoodsStatesClear_Click(object sender, EventArgs e)
		{
			tabData.IsNeedRestore =
			tabOddmentsSaved.IsNeedRestore =
				true;

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
			oOwner.FillDataOwners();
			if (oOwner.ErrorNumber != 0 || oOwner.MainTable == null)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о хранителях...");
				return;
			}
			if (oOwner.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Нет данных о хранителях...");
				return;
			}

			if (StartForm(new frmSelectID(this, oOwner.MainTable, "Name,Actual", "Хранитель,Акт.", true)) == DialogResult.Yes)
			{
				if (_SelectedIDList == null || !_SelectedIDList.Contains(","))
				{
					btnOwnersClear_Click(null, null);
					return;
				}

				sSelectedOwnersIDList = "," + _SelectedIDList;

				txtOwnersChoosen.Text = _SelectedText;
				ttToolTip.SetToolTip(txtOwnersChoosen, txtOwnersChoosen.Text);

				tabData.IsNeedRestore =
				tabOddmentsSaved.IsNeedRestore =
					true;
			}

			_SelectedIDList = null;
			_SelectedText = "";
		}

		private void btnOwnersClear_Click(object sender, EventArgs e)
		{
			tabData.IsNeedRestore =
			tabOddmentsSaved.IsNeedRestore =
				true;

			ttToolTip.SetToolTip(txtOwnersChoosen, "не выбраны");
			sSelectedOwnersIDList = "";
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

				tabData.IsNeedRestore =
				tabOddmentsSaved.IsNeedRestore =
					true;
			}

			_SelectedPackingIDList = null;
			_SelectedPackingAliasText = "";
		}

		private void btnPackingsClear_Click(object sender, EventArgs e)
		{
			tabData.IsNeedRestore =
			tabOddmentsSaved.IsNeedRestore =
				true;

			ttToolTip.SetToolTip(txtPackingsChoosen, "не выбраны");
			sSelectedPackingsIDList = "";
			txtPackingsChoosen.Text = "";
		}

		#endregion

		private void optDateValidPercent_CheckedChanged(object sender, EventArgs e)
		{
			numDateValidPercent.Enabled = optDateValidPercent.Checked;
		}

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

        private void mniPrintPackingsTurnover_Click(object sender, EventArgs e)
        {
            if (grdData.CurrentRow == null ||
                nPackingID == null || nGoodStateID == null)
                return;

            StartForm(new frmReportPackingsTurnover((int)nPackingID, nOwnerID, (int)nGoodStateID));
        }

        private void mniReportBadGoods_Click(object sender, EventArgs e)
        {
            StartForm(new frmReportBadGoods());
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

		private void mniServiceTrafficFrameCreate_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			bool bReturn = false;
			if (tcList.CurrentPage.Name.ToUpper() != tabData.Name.ToUpper())
				bReturn = true;
			if (!bReturn &&
				lastGrid.Name.ToUpper() != grdOddmentsDetails.Name.ToUpper())
				bReturn = true;
			if (!bReturn &&
				(grdData.DataSource == null ||
				grdData.Rows.Count == 0 ||
				grdData.CurrentRow == null ||
				grdData.IsStatusRow(grdData.CurrentRow.Index)))
				bReturn = true;
			if (!bReturn &&
				(grdOddmentsDetails.DataSource == null ||
				grdOddmentsDetails.Rows.Count == 0 ||
				grdOddmentsDetails.CurrentRow == null ||
				grdOddmentsDetails.IsStatusRow(grdOddmentsDetails.CurrentRow.Index)))
				bReturn = true;
			if (!bReturn &&
				(grdOddmentsDetails.CurrentRow.Cells["grcFrameID"].Value == null ||
				grdOddmentsDetails.CurrentRow.Cells["grcFrameID"].Value == DBNull.Value))
				bReturn = true;
			if (bReturn)
			{
				RFMMessage.MessageBoxError("Для вызова операции перейдите в нижнюю таблицу и установите активную строку на запись о контейнере.");
				return;
			}

			int nFrameID = Convert.ToInt32(grdOddmentsDetails.CurrentRow.Cells["grcFrameID"].Value);

			TrafficFrame oTrafficTemp = new TrafficFrame();
			oTrafficTemp.FilterFramesList = nFrameID.ToString();
			oTrafficTemp.FilterConfirmed = false;
			oTrafficTemp.FillData();
			if (oTrafficTemp.ErrorNumber != 0)
				return;
			if (oTrafficTemp.MainTable.Rows.Count > 0)
			{
				RFMMessage.MessageBoxError("Для контейнера с кодом " + nFrameID.ToString() + " существуют невыполненные операции транспортировки...");
				return;
			}

			if (StartForm(new frmTrafficsFramesManual(nFrameID)) == DialogResult.Yes)
			{
				grdOddmentsDetails_Restore();
			}
		}

		#endregion

		#region Terms clear

		private void btnClearTerms_Click(object sender, EventArgs e)
		{
			dtrDates.dtpBegDate.Value = DateTime.Now.AddDays(-3).Date;
			dtrDates.dtpEndDate.Value = DateTime.Now.Date;

			btnGoodsStatesClear_Click(null, null);
			btnOwnersClear_Click(null, null);
			btnPackingsClear_Click(null, null);

			optAll.Checked = true;
			optDateValidAny.Checked = true;
			optDateValidPercent_CheckedChanged(null, null);

			tabData.IsNeedRestore = true;
			tabOddmentsSaved.IsNeedRestore = true;
		}

		#endregion

    }
}