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
	public partial class frmOutputs : RFMFormChild
	{
		private Output oOutputList; //список расходов
		private Output oOutputCur; //текущий расход

		public string _SelectedIDList;
		public string _SelectedText;

		private string sSelectedOutputsTypesIDList = "";
		private string sSelectedGoodsStatesIDList = "";
		private string sSelectedOwnersIDList = "";
		private string sSelectedPartnersIDList = "";

		private string sSelectedCarsAliasList = "";

		public string _SelectedPackingIDList;
		public string _SelectedPackingAliasText;
		private string sSelectedPackingsIDList = "";

		public int? _SelectedID;

		private Host oHost;
		private int? nUserHostID = null;


		public frmOutputs()
		{
			oOutputList = new Output();
			oOutputCur = new Output();
			if (oOutputList.ErrorNumber != 0 ||
				oOutputCur.ErrorNumber != 0)
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

		private void frmOutputs_Load(object sender, EventArgs e)
		{
			RFMCursorWait.Set(true);

			nUserHostID = ((RFMFormMain)Application.OpenForms[0]).UserInfo.HostID;

			lblHosts.Visible =
			ucSelectRecordID_Hosts.Visible =
			ucSelectRecordID_Hosts.Enabled =
				(oHost.Count() > 1 && !nUserHostID.HasValue);

			grcQntWished.AgrType =
			grcBoxWished.AgrType =
			grcPalWished.AgrType =
			grcQntOdd.AgrType =
			grcBoxOdd.AgrType =
			grcPalOdd.AgrType =
			grcQntSelected.AgrType =
			grcBoxSelected.AgrType =
			grcPalSelected.AgrType =
			grcQntSelDiff.AgrType =
			grcBoxSelDiff.AgrType =
			grcPalSelDiff.AgrType =
			grcQntPicked.AgrType =
			grcBoxPicked.AgrType =
			grcPalPicked.AgrType =
			grcQntConfirmed.AgrType =
			grcBoxConfirmed.AgrType =
			grcPalConfirmed.AgrType =
			grcQntDiff.AgrType =
			grcBoxDiff.AgrType =
			grcPalDiff.AgrType =
			grcFrameQnt.AgrType =
			grcFrameBoxQnt.AgrType =
			grcFramePalQnt.AgrType =
			grcTrafficsGoodsQntWished.AgrType =
			grcTrafficsGoodsBoxWished.AgrType =
			grcTrafficsGoodsQntConfirmed.AgrType =
			grcTrafficsGoodsBoxConfirmed.AgrType =
			grcNettoWished.AgrType =
			grcBruttoWished.AgrType =
			grcNettoConfirmed.AgrType =
			grcBruttoConfirmed.AgrType =
			grcItemsQnt.AgrType =
			grcItemsBoxes.AgrType =
			grcItemsPallets.AgrType =
			grcPalletsFactQnt.AgrType = 
				EnumAgregate.Sum;

			// цвет колонок
			grdOutputsGoods.ChangeColumnColor("grcQntSelDiff", Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(200))))), Color.Empty);
			grdOutputsGoods.ChangeColumnColor("grcQntPicked", Color.Green, Color.Empty);
			grdOutputsGoods.ChangeColumnColor("grcQntDiff", Color.Red, Color.Empty);

			grdOutputsGoods.ChangeColumnColor("grcBoxSelDiff", Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(200))))), Color.Empty);
			grdOutputsGoods.ChangeColumnColor("grcBoxPicked", Color.Green, Color.Empty);
			grdOutputsGoods.ChangeColumnColor("grcBoxDiff", Color.Red, Color.Empty);

			grdOutputsGoods.ChangeColumnColor("grcPalSelDiff", Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(200))))), Color.Empty);
			grdOutputsGoods.ChangeColumnColor("grcPalPicked", Color.Green, Color.Empty);
			grdOutputsGoods.ChangeColumnColor("grcPalDiff", Color.Red, Color.Empty);
	
			btnClearTerms_Click(null, null);

			tcList.Init();
			tcOutputsGoods.Init();

			txtBarCode.Select();

			RFMCursorWait.Set(false);
		}

		#region Tab Restore

		private bool tabTerms_Restore()
		{
			btnBarCodeFind.Enabled =
			btnAdd.Enabled = // не исп.
			btnEdit.Enabled = // не исп. 
			btnConfirm.Enabled =
			btnConfirmGoods.Enabled =
			btnSelect.Enabled =
			btnDelete.Enabled = // не исп.
			btnPrint.Enabled =
			btnService.Enabled = false;
			return (true);
		}

		private bool tabData_Restore()
		{
			grdData_Restore();
			btnAdd.Enabled =
			btnEdit.Enabled =
			btnDelete.Enabled = false; // не исп.
			if (grdData.Rows.Count > 0)
			{
				btnPrint.Enabled =
				btnSelect.Enabled =
				btnService.Enabled = 
					true;
			}
			else
			{
				btnPrint.Enabled =
				btnSelect.Enabled =
				btnService.Enabled = 
					false;
			}
			return (true);
		}

		private void tcList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tcList.SelectedTab.Name.ToUpper().Contains("TERMS"))
			{
				btnBarCodeFind.Enabled =
				btnAdd.Enabled = // не исп.
				btnEdit.Enabled = // не исп. 
				btnConfirm.Enabled =
				btnConfirmGoods.Enabled =
				btnSelect.Enabled =
				btnDelete.Enabled = // не исп.
				btnPrint.Enabled =
				btnService.Enabled = false;
			}

			if (tcList.SelectedTab.Name.ToUpper().Contains("DATA"))
			{
				grdData.Select();
			}
		}

		#region Bottom Tab Restore

		private bool tabOutputsGoods_Restore()
		{
			return grdOutputsGoods_Restore();
		}

		private bool tabTrafficsGoods_Restore()
		{
			return grdTrafficsGoods_Restore();
		}

		private bool tabTrafficsFrames_Restore()
		{
			return grdTrafficsFrames_Restore();
		}

		private bool tabOutputsFrames_Restore()
		{
			return grdOutputsFrames_Restore();
		}

		private bool tabItems_Restore()
		{
			return grdItems_Restore();
		}

		private bool tabOutputsLoaders_Restore()
		{
			return grdOutputsLoaders_Restore();
		}

		#endregion Bottom Tab Restore

		#endregion Tab Restore

		#region Prepare IDList

		public void OutputPrepareIDList(Output oOutput, bool bMultiSelect)
		{
			RFMCursorWait.Set(true);

			oOutput.ID = null;
			oOutput.IDList = null;

			int? nOutputID = 0;
			if (bMultiSelect && grdData.IsCheckerShow)
			{
				oOutput.IDList = "";

				DataView dMarked = new DataView(oOutputList.MainTable);
				dMarked.RowFilter = "IsMarked = true";
				dMarked.Sort = grdData.GridSource.Sort;
				foreach (DataRowView r in dMarked)
				{
					if (!Convert.IsDBNull(r["ID"]))
					{
						nOutputID = (int)r["ID"];
						oOutput.IDList = oOutput.IDList + nOutputID.ToString() + ",";
					}
				}
			}
			else
			{
				nOutputID = (int?)grdData.CurrentRow.Cells["grcID"].Value;
				if (nOutputID.HasValue)
				{
					oOutput.ID = nOutputID;
				}
			}

			RFMCursorWait.Set(false);
		}

		public void OutputNotConfirmedPrepareIDList(Output oOutput, bool bMultiSelect)
		{
			RFMCursorWait.Set(true);

			oOutput.ID = null;
			oOutput.IDList = null;

			int? nOutputID = 0;
			if (bMultiSelect && grdData.IsCheckerShow)
			{
				oOutput.IDList = "";

				DataView dMarked = new DataView(oOutputList.MainTable);
				dMarked.RowFilter = "IsMarked = true";
				dMarked.Sort = grdData.GridSource.Sort;
				foreach (DataRowView r in dMarked)
				{
					if (!Convert.IsDBNull(r["ID"]))
					{
						if (Convert.IsDBNull(r["DateConfirm"]))
						{
							nOutputID = (int)r["ID"];
							oOutput.IDList = oOutput.IDList + nOutputID.ToString() + ",";
						}
					}
				}
			}
			else
			{
				nOutputID = (int?)grdData.CurrentRow.Cells["grcID"].Value;
				if (nOutputID.HasValue)
				{
					oOutput.ID = nOutputID;
				}
			}

			RFMCursorWait.Set(false);
		}

		public int CalcMarkedRows()
		{
			int nCnt = 0;
			if (grdData.IsCheckerShow)
			{
				DataView dMarked = new DataView(oOutputList.MainTable);
				dMarked.RowFilter = "IsMarked = true";
				nCnt = dMarked.Count;
			}
			return (nCnt);
		}

		#endregion Prepare IDList

		#region Buttons

		private void btnDelete_Click(object sender, EventArgs e)
		{
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			//if (StartForm(new frmOutputsEdit(null)) == DialogResult.Yes)
			//{
			//    int nOutputID = (int)GotParam.GetValue(0);
			//    grdData_Restore();
			//    if (nOutputID > 0)
			//    {
			//        grdData.GridSource.Position = grdData.GridSource.Find(oOutputList.ColumnID, nOutputID);
			//    }
			//}
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			if (grdData.CurrentRow == null)
				return;

			oOutputCur.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			//if (StartForm(new frmOutputsEdit((int)oOutputCur.ID)) == DialogResult.Yes)
			//	grdData_Restore();
		}

		private void btnConfirm_Click(object sender, EventArgs e)
		{
			if (grdData.CurrentRow == null)
				return;

			oOutputCur.ClearError();
			oOutputCur.ClearFilters();
			oOutputCur.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			oOutputCur.FillData();
			if (oOutputCur.ErrorNumber != 0 || oOutputCur.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о расходе...");
				return;
			}

			oOutputCur.FillTableOutputsGoods((int)oOutputCur.ID);
			bool bForConfirm = false;
			foreach (DataRow Row in oOutputCur.TableOutputsGoods.Rows)
			{
				if ((decimal)Row["QntSelected"] > 0)
				{
					bForConfirm = true;
					break;
				}
			}
			if (!bForConfirm)
			{
				if (RFMMessage.MessageBoxYesNo("Нет ни одного подобранного товара!\r\n" +
						"Все-таки выполнить подтверждение расхода?") != DialogResult.Yes)
					return;
			}

			// проверка выполнения всех трафиков 
			oOutputCur.FillTableOutputsTraffics((int)oOutputCur.ID, true);
			bool bTrafficsConfirmed = true;
			foreach (DataRow Row in oOutputCur.TableOutputsTrafficsFrames.Rows)
			{
				if (Convert.IsDBNull(Row["DateConfirm"]))
				{
					bTrafficsConfirmed = false;
					break;
				}
			}
			if (!bTrafficsConfirmed)
			{
				RFMMessage.MessageBoxError("Есть неподтвержденные операции транспортировки для расхода!\r\n" +
						"Подтверждение расхода невозможно...");
				return;
			}
			oOutputCur.FillTableOutputsTraffics((int)oOutputCur.ID, false);
			foreach (DataRow Row in oOutputCur.TableOutputsTrafficsGoods.Rows)
			{
				if (Convert.IsDBNull(Row["DateConfirm"]))
				{
					bTrafficsConfirmed = false;
					break;
				}
			}
			if (!bTrafficsConfirmed)
			{
				RFMMessage.MessageBoxError("Есть неподтвержденные операции перемещения коробок/штук для расхода!\r\n" +
						"Подтверждение расхода невозможно...");
				return;
			}

			if (StartForm(new frmOutputsConfirm((int)oOutputCur.ID)) == DialogResult.Yes)
			{
				// вносим данные о загрузчиках товара
				StartForm(new frmOutputsLoaders((int)oOutputCur.ID));
				grdData_Restore();
			}
		}

		private void btnConfirmGoods_Click(object sender, EventArgs e)
		{
			if (grdData.CurrentRow == null)
				return;

			oOutputCur.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			if (StartForm(new frmOutputsGoodsConfirm((int)oOutputCur.ID)) == DialogResult.Yes)
			{
				grdData_Restore();
				tcOutputsGoods.SetAllNeedRestore(true);
			}
		}

		private void btnBarCodeFind_Click(object sender, EventArgs e)
		{
			if (StartForm(new frmInputBoxBarCode("Штрих-код расхода:", "")) == DialogResult.Yes)
			{
				Refresh();
				string sBarCode = GotParam[0].ToString();
				if (sBarCode.Length > 0)
				{
					int nPosition = grdData.GridSource.Find("BarCode", sBarCode);
					if (nPosition < 0)
					{
						RFMMessage.MessageBoxError("Не найдено...");
					}
					else
					{
						grdData.GridSource.Position = nPosition;
					}
				}
			}
		}

		private void btnHelp_Click(object sender, EventArgs e)
		{
			RFMHelpUtilities.HelpShow(this, hpHelp);
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			//			this.Dispose();
			this.Close();
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

			btnBarCodeFind.Enabled =
			btnPrint.Enabled =
			btnSelect.Enabled =
			btnService.Enabled =
				true;

			if (grdData.IsStatusRow(rowIndex))
			{
				oOutputCur.ID = 0;
				btnEdit.Enabled =
				btnConfirm.Enabled =
				btnConfirmGoods.Enabled =
				btnSelect.Enabled =
					 false;
				//return;
			}
			else
			{
				DataGridViewRow r = grdData.Rows[rowIndex];
				oOutputCur.ID = (int)r.Cells["grcID"].Value;
				bool bIsConfirmed = (bool)r.Cells["grcIsConfirmed"].Value;
				bool bIsSelected = !Convert.IsDBNull(r.Cells["grcDateSelect"].Value);
				bool bIsPicked = !Convert.IsDBNull(r.Cells["grcDatePick"].Value);
				bool bIsInWork = Convert.IsDBNull(r.Cells["grcDateStart"].Value);
				//btnSelect.Enabled = !bIsConfirmed;
				btnConfirm.Enabled = bIsPicked && !bIsConfirmed;
				btnConfirmGoods.Enabled = bIsSelected && !bIsPicked && !bIsConfirmed;
			}

			tcOutputsGoods.SetAllNeedRestore(true);
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
					case "grcOutputSelectedInfoImage":
					case "grcOutputTrafficsInfoImage":
					case "grcIsPrintedImage":
						e.Value = Properties.Resources.Empty;
						break;
				}
				return;
			}

			DataGridViewRow r = grdData.Rows[e.RowIndex];
			switch (grdData.Columns[e.ColumnIndex].Name)
			{
				case "grcIsPrintedImage":
					if (!Convert.IsDBNull(r.Cells["grcDatePrint"].Value))
					{
						e.Value = Properties.Resources.Print;
					}
					else
					{
						e.Value = Properties.Resources.Empty;
					}
					break;
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
				case "grcOutputSelectedInfoImage":
					if (r.Cells["grcOutputSelectedInfo"].Value.ToString().Length == 0)
					{
						e.Value = Properties.Resources.Empty;
					}
					else
					{
						switch ((int)r.Cells["grcOutputSelectedInfo"].Value)
						{
							case 0:
								e.Value = Properties.Resources.Plain_R;
								break;
							case 1:
								e.Value = Properties.Resources.Plain_Y;
								break;
							case 2:
								e.Value = Properties.Resources.Plain_G;
								break;
							case 3:
								e.Value = Properties.Resources.Plain_B;
								break;
						}
					}
					break;
				case "grcOutputTrafficsInfoImage":
					if (r.Cells["grcOutputTrafficsInfo"].Value.ToString().Length == 0)
					{
						e.Value = Properties.Resources.Empty;
					}
					else
					{
						switch ((int)r.Cells["grcOutputTrafficsInfo"].Value)
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

			if ((grdData.Columns[e.ColumnIndex].Name.Contains("tto") ||
				grdData.Columns[e.ColumnIndex].Name.Contains("Pal")) &&
				grdData.Columns[e.ColumnIndex].DefaultCellStyle.Format.Contains("N"))
			{
				if (Convert.IsDBNull(e.Value) || Convert.ToDecimal(e.Value) == 0)
				{
					e.Value = "";
				}
			}
		}

		private void grdOutputsGoods_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			RFMDataGridView grd = grdOutputsGoods;

			if (grd.DataSource == null)
				return;

			if (grd.IsStatusRow(e.RowIndex))
			{
				switch (grd.Columns[e.ColumnIndex].Name)
				{
					case "grcResult":
					case "grcSelResult":
						e.Value = Properties.Resources.Empty;
						break;
				}
				return;
			}

			DataGridViewRow r = grd.Rows[e.RowIndex];
			switch (grd.Columns[e.ColumnIndex].Name)
			{
				case "grcResult":
					if (Convert.ToInt32(r.Cells["grcQntConfirmed"].Value) == 0)
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
				case "grcSelResult":
					if (Convert.ToInt32(r.Cells["grcQntSelected"].Value) == 0)
						e.Value = Properties.Resources.Plain_R;
					else
					{
						if (Convert.ToDecimal(r.Cells["grcQntWished"].Value) ==
							Convert.ToDecimal(r.Cells["grcQntSelected"].Value))
						{
							e.Value = Properties.Resources.Plain_G;
						}
						else
						{
							if (Convert.ToDecimal(r.Cells["grcQntWished"].Value) >
								Convert.ToDecimal(r.Cells["grcQntSelected"].Value))
							{
								e.Value = Properties.Resources.Plain_Y;
							}
							else
							{
								e.Value = Properties.Resources.Plain_B;
							}
						}
					}
					break;
				case "grcQntWished":
				case "grcQntOdd":
				case "grcQntConfirmed":
				case "grcQntDiff":
				case "grcQntSelected":
				case "grcQntSelDiff":
				case "grcQntPicked":
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

				case "grcBoxSelected":
				case "grcPalSelected":
					if ((bool)r.Cells["grcIsExists"].Value == true)
						e.CellStyle.BackColor = Color.Yellow;
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

		private void grdTrafficsFrames_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			RFMDataGridView grd = grdTrafficsFrames;

			if (grd.DataSource == null)
				return;

			if (grd.IsStatusRow(e.RowIndex))
			{
				switch (grd.Columns[e.ColumnIndex].Name)
				{
					case "grcTrafficsFramesResult":
						e.Value = Properties.Resources.Empty;
						break;
				}
				return;
			}

			switch (grd.Columns[e.ColumnIndex].Name)
			{
				case "grcTrafficsFramesStatusImage":
					if (grd.Rows[e.RowIndex].Cells["grcTrafficsFramesDateConfirm"].Value.ToString().Length == 0)
						e.Value = Properties.Resources.Empty;
					else
						if ((bool)grd.Rows[e.RowIndex].Cells["grcTrafficsFramesSuccess"].Value)
							e.Value = Properties.Resources.Check;
						else
							e.Value = Properties.Resources.CheckRed;
					break;
			}

			if (grd.Columns[e.ColumnIndex].Name.Contains("Weight") &&
				grd.Columns[e.ColumnIndex].DefaultCellStyle.Format.Contains("N"))
			{
				if (Convert.IsDBNull(e.Value) || Convert.ToDecimal(e.Value) == 0)
				{
					e.Value = "";
				}
			}
		}

		private void grdOutputsFrames_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			RFMDataGridView grd = grdOutputsFrames;

			if (grd.DataSource == null)
				return;

			if (grd.IsStatusRow(e.RowIndex))
			{
				switch (grd.Columns[e.ColumnIndex].Name)
				{
					case "grcResultFrame":
					case "grcResultNotConfirmedFrame":
						e.Value = Properties.Resources.Empty;
						break;
					case "grcFrameQnt":
					case "grcFrameInBox":
						e.CellStyle.Format = "### ### ### ###";
						break;
				}
				return;
			}

			DataGridViewRow r = grd.Rows[e.RowIndex];
			switch (grd.Columns[e.ColumnIndex].Name)
			{
				case "grcResultFrame":
					if ((bool)r.Cells["grcHasTraffics"].Value)
					{
						e.Value = Properties.Resources.Check;
					}
					else
					{
						e.Value = Properties.Resources.Empty;
					}
					break;
				case "grcResultNotConfirmedFrame":
					if (Convert.ToBoolean(r.Cells["grcHasNotConfirmedTraffics"].Value))
					{
						e.Value = Properties.Resources.DotRed;
					}
					else
					{
						if (Convert.ToBoolean(r.Cells["grcHasTraffics"].Value))
						{
							e.Value = Properties.Resources.DotGreen;
						}
						else
						{
							e.Value = Properties.Resources.Empty;
						}
					}
					break;
				case "grcFrameQnt":
				case "grcFrameInBox":
					if (!Convert.IsDBNull(r.Cells["grcWeightingFrame"].Value) &&
						Convert.ToBoolean(r.Cells["grcWeightingFrame"].Value) ||
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
				 grd.Columns[e.ColumnIndex].Name.Contains("Pal") ||
				 grd.Columns[e.ColumnIndex].Name.Contains("Weight")) &&
				grd.Columns[e.ColumnIndex].DefaultCellStyle.Format.Contains("N"))
			{
				if (Convert.IsDBNull(e.Value) || Convert.ToDecimal(e.Value) == 0)
				{
					e.Value = "";
				}
			}
		}

		private void grdItems_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			RFMDataGridView grd = grdItems;

			if (grd.DataSource == null)
				return;

			if (grd.IsStatusRow(e.RowIndex))
			{
				switch (grd.Columns[e.ColumnIndex].Name)
				{
					case "grcItemsImage":
						e.Value = Properties.Resources.Empty;
						break;
				}
				return;
			}

			DataGridViewRow r = grd.Rows[e.RowIndex];
			switch (grd.Columns[e.ColumnIndex].Name)
			{
				case "grcItemsImage":
					if (!Convert.IsDBNull(r.Cells["grcItemsFrameID"].Value))
					{
						e.Value = Properties.Resources.Frame;
					}
					else
					{
						e.Value = Properties.Resources.Boxes;
					}
					break;
				case "grcItemsQnt":
				case "grcItemsInBox":
					if (!Convert.IsDBNull(r.Cells["grcItemsWeighting"].Value) &&
						Convert.ToBoolean(r.Cells["grcItemsWeighting"].Value) ||
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

			if ((grd.Columns[e.ColumnIndex].Name.Contains("Height") ||
				 grd.Columns[e.ColumnIndex].Name.Contains("Weight")) &&
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

			oOutputCur.ID = null;

			oOutputList.ClearError();
			oOutputList.ClearFilters();
			oOutputList.ID = null;
			oOutputList.IDList = null;

			// собираем условия

			// штрих-код
			if (txtBarCode.Text.Trim().Length > 0)
			{
				oOutputList.BarCode = txtBarCode.Text.Trim();
			}
			// даты
			if (!dtrDates.dtpBegDate.IsEmpty)
			{
				oOutputList.FilterDateBeg = dtrDates.dtpBegDate.Value.Date;
			}
			if (!dtrDates.dtpEndDate.IsEmpty)
			{
				oOutputList.FilterDateEnd = dtrDates.dtpEndDate.Value.Date;
			}
			// тип расхода
			if (sSelectedOutputsTypesIDList.Length > 0)
			{
				oOutputList.FilterOutputsTypesList = sSelectedOutputsTypesIDList;
			}
			// состояние
			if (sSelectedGoodsStatesIDList.Length > 0)
			{
				oOutputList.FilterGoodsStatesList = sSelectedGoodsStatesIDList;
			}

			// сбор товара
			if (optIsPicked.Checked)
			{
				oOutputList.FilterPicked = true;
			}
			if (optIsNotPicked.Checked)
			{
				oOutputList.FilterPicked = false;
			}
			// подтверждение расхода
			if (optIsConfirmed.Checked)
			{
				oOutputList.FilterConfirmed = true;
				// даты подтверждения
				if (!dtrDatesConfirm.dtpBegDate.IsEmpty)
				{
					oOutputList.FilterDateBegConfirm = dtrDatesConfirm.dtpBegDate.Value.Date;
				}
				if (!dtrDatesConfirm.dtpEndDate.IsEmpty)
				{
					oOutputList.FilterDateEndConfirm = dtrDatesConfirm.dtpEndDate.Value.Date;
				}
			}
			if (optIsNotConfirmed.Checked)
			{
				oOutputList.FilterConfirmed = false;
			}

			// подбор товара
			if (optSelectedInfo01.Checked)
			{
				if (chkSelectedInfo0.Checked || chkSelectedInfo1.Checked)
				{
					if (chkSelectedInfo0.Checked)
					{
						oOutputList.FilterOutputSelectedInfo = 0;
					}
					if (chkSelectedInfo1.Checked)
					{
						oOutputList.FilterOutputSelectedInfo = 1;
					}
				}
				else
				{
					oOutputList.FilterOutputSelectedInfo = -1;
				}
				
			}
			if (optSelectedInfo2.Checked)
			{
				oOutputList.FilterOutputSelectedInfo = 2; // 3 (переподбор) - здесь же
			}

			if (optFullConfirmedInfo.Checked)
			{
				oOutputList.FilterFullConfirmed = false;  // не весь подобранный товар выдан
			}
			if (optTrafficsInfo0.Checked)
			{
				oOutputList.FilterOutputTrafficsInfo = 0;
			}
			if (optTrafficsInfo1.Checked)
			{
				oOutputList.FilterOutputTrafficsInfo = 1;
			}
			if (optTrafficsInfo2.Checked)
			{
				oOutputList.FilterOutputTrafficsInfo = 2;
			}

			// машина
			if (txtCarAliasContext.Text.Trim().Length > 0)
			{
				oOutputList.FilterCarAliasContext = txtCarAliasContext.Text.Trim();
			}
			if (sSelectedCarsAliasList.Length > 0)
			{
				oOutputList.FilterCarsAliasesList = sSelectedCarsAliasList;
			}
			if (optBackDoor.Checked)
			{
				oOutputList.FilterBackDoor = true;
			}
			if (optBackDoorNot.Checked)
			{
				oOutputList.FilterBackDoor = false;
			}

			// получатели 
			if (txtPartnerNameContext.Text.Trim().Length > 0)
			{
				oOutputList.FilterPartnerContext = txtPartnerNameContext.Text.Trim();
			}
			if (sSelectedPartnersIDList.Length > 0)
			{
				oOutputList.FilterPartnersList = sSelectedPartnersIDList;
			}

			// владельцы
			if (sSelectedOwnersIDList.Length > 0)
			{
				oOutputList.FilterOwnersList = sSelectedOwnersIDList;
			}

			// выбранные товары
			if (sSelectedPackingsIDList.Length > 0)
				oOutputList.FilterPackingsList = sSelectedPackingsIDList;

			if (nUserHostID.HasValue)
			{
				oOutputList.FilterHostsList = nUserHostID.ToString();
			}
			else
			{
				if (ucSelectRecordID_Hosts.IsSelectedExist)
				{
					oOutputList.FilterHostsList = ucSelectRecordID_Hosts.GetIdString();
				}
			}
			//

			grdOutputsGoods.DataSource = null;
			grdTrafficsGoods.DataSource = null;
			grdTrafficsFrames.DataSource = null;
			grdOutputsFrames.DataSource = null;
			grdItems.DataSource = null;
			grdOutputsLoaders.DataSource = null;

			grdData.GetGridState();
			
			oOutputList.FillData();

			grdData.IsLockRowChanged = true;
			grdData.Restore(oOutputList.MainTable);
			tmrRestore.Enabled = true;

			RFMCursorWait.LockWindowUpdate(IntPtr.Zero);
			RFMCursorWait.Set(false);

			return (oOutputList.ErrorNumber == 0);
		}

		private bool grdOutputsGoods_Restore()
		{
			grdOutputsGoods.GetGridState();
			grdOutputsGoods.DataSource = null;
			if (grdData.Rows.Count == 0 ||
				oOutputCur.ID == null ||
				(grdData.CurrentRow != null && grdData.IsStatusRow(grdData.CurrentRow.Index)))
				return (true);

			oOutputList.ClearError();
			oOutputList.FillTableOutputsGoods((int)oOutputCur.ID);

			if (chkShowSelectedGoodsOnly.Enabled && chkShowSelectedGoodsOnly.Checked &&
				sSelectedPackingsIDList != null && sSelectedPackingsIDList.Length > 0)
			{
				DataTable dt = CopyTable(oOutputList.TableOutputsGoods, "dt",
					"PackingID in (" + RFMPublic.RFMUtilities.NormalizeList(sSelectedPackingsIDList) + ")",
					"GoodAlias, ID");
				oOutputList.TableOutputsGoods.Clear();
				oOutputList.TableOutputsGoods.Merge(dt);
			}

			grdOutputsGoods.Restore(oOutputList.TableOutputsGoods);

			return (oOutputList.ErrorNumber == 0);
		}

		private bool grdTrafficsGoods_Restore()
		{
			grdTrafficsGoods.GetGridState();  
			grdTrafficsGoods.DataSource = null;
			if (grdData.Rows.Count == 0 ||
				oOutputCur.ID == null ||
				grdData.CurrentRow != null && grdData.IsStatusRow(grdData.CurrentRow.Index))
				return (true);

			oOutputList.ClearError();
			oOutputList.FillTableOutputsTraffics((int)oOutputCur.ID, false);

			if (chkShowSelectedGoodsOnly.Enabled && chkShowSelectedGoodsOnly.Checked &&
				sSelectedPackingsIDList != null && sSelectedPackingsIDList.Length > 0)
			{
				DataTable dt = CopyTable(oOutputList.TableOutputsTrafficsGoods, "dt",
					"PackingID in (" + RFMPublic.RFMUtilities.NormalizeList(sSelectedPackingsIDList) + ")",
					"GoodAlias, ID");
				oOutputList.TableOutputsTrafficsGoods.Clear();
				oOutputList.TableOutputsTrafficsGoods.Merge(dt);
			}

			grdTrafficsGoods.Restore(oOutputList.TableOutputsTrafficsGoods);

			return (oOutputList.ErrorNumber == 0);
		}

		private bool grdTrafficsFrames_Restore()
		{
			grdTrafficsFrames.GetGridState(); 
			grdTrafficsFrames.DataSource = null;
			if (grdData.Rows.Count == 0 ||
				oOutputCur.ID == null ||
				grdData.CurrentRow != null && grdData.IsStatusRow(grdData.CurrentRow.Index))
				return (true);

			oOutputList.ClearError();
			oOutputList.FillTableOutputsTraffics((int)oOutputCur.ID, true);

			grdTrafficsFrames.Restore(oOutputList.TableOutputsTrafficsFrames);
			
			return (oOutputList.ErrorNumber == 0);
		}

		private bool grdOutputsFrames_Restore()
		{
			grdOutputsFrames.GetGridState(); 
			grdOutputsFrames.DataSource = null;
			if (grdData.Rows.Count == 0 ||
				oOutputCur.ID == null ||
				grdData.CurrentRow != null && grdData.IsStatusRow(grdData.CurrentRow.Index))
				return (true);

			oOutputList.ClearError();
			oOutputList.FillTableOutputsFrames((int)oOutputCur.ID);
			
			grdOutputsFrames.Restore(oOutputList.TableOutputsFrames);
			
			return (oOutputList.ErrorNumber == 0);
		}

		private bool grdItems_Restore()
		{
			grdItems.GetGridState(); 
			grdItems.DataSource = null;
			if (grdData.Rows.Count == 0 ||
				oOutputCur.ID == null ||
				(grdData.CurrentRow != null && grdData.IsStatusRow(grdData.CurrentRow.Index)))
				return (true);

			oOutputList.ClearError(); 
			oOutputList.FillTableOutputsItems((int)oOutputCur.ID);

			if (chkShowSelectedGoodsOnly.Enabled && chkShowSelectedGoodsOnly.Checked &&
				sSelectedPackingsIDList != null && sSelectedPackingsIDList.Length > 0)
			{
				DataTable dt = CopyTable(oOutputList.TableOutputsItems, "dt",
					"PackingID in (" + RFMPublic.RFMUtilities.NormalizeList(sSelectedPackingsIDList) + ")",
					"GoodAlias, OutputItemID");
				oOutputList.TableOutputsItems.Clear();
				oOutputList.TableOutputsItems.Merge(dt);
			}
			
			grdItems.Restore(oOutputList.TableOutputsItems);
			return (oOutputList.ErrorNumber == 0);
		}

		private bool grdOutputsLoaders_Restore()
		{
			grdOutputsLoaders.GetGridState();
			grdOutputsLoaders.DataSource = null;
			if (grdData.Rows.Count == 0 ||
				oOutputCur.ID == null ||
				(grdData.CurrentRow != null && grdData.IsStatusRow(grdData.CurrentRow.Index)))
				return (true);

			oOutputList.ClearError(); 
			oOutputList.FillTableOutputsLoaders((int)oOutputCur.ID);
			
			grdOutputsLoaders.Restore(oOutputList.TableOutputsLoaders);
			return (oOutputList.ErrorNumber == 0);
		}

		#endregion


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

		#endregion

		#region Partners

		private void btnPartnersChoose_Click(object sender, EventArgs e)
		{
			_SelectedIDList = null;
			_SelectedText = "";

			Partner oPartner = new Partner();
			oPartner.FilterExistsInInputs = null;
			oPartner.FillData();
			if (oPartner.ErrorNumber != 0 || oPartner.MainTable == null)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных...");
				return;
			}
			if (oPartner.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Нет данных...");
				return;
			}

			if (StartForm(new frmSelectID(this, oPartner.MainTable, "Name,Actual", "Поставщик,Акт.", true)) == DialogResult.Yes)
			{
				if (_SelectedIDList == null || !_SelectedIDList.Contains(","))
				{
					btnPartnersClear_Click(null, null);
					return;
				}

				sSelectedPartnersIDList = "," + _SelectedIDList;

				txtPartnersChoosen.Text = _SelectedText;
				ttToolTip.SetToolTip(txtPartnersChoosen, txtPartnersChoosen.Text);

				tabData.IsNeedRestore = true;
			}

			_SelectedIDList = null;
			_SelectedText = "";
		}

		private void btnPartnersClear_Click(object sender, EventArgs e)
		{
			tabData.IsNeedRestore = true;

			ttToolTip.SetToolTip(txtPartnersChoosen, "не выбраны");
			sSelectedPartnersIDList = "";
			txtPartnersChoosen.Text = "";
		}

		#endregion

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

				sSelectedOwnersIDList = "," + _SelectedIDList;

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
			sSelectedOwnersIDList = "";
			txtOwnersChoosen.Text = "";
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

				tabData.IsNeedRestore = true;
			}

			_SelectedIDList = null;
			_SelectedText = "";
		}

		private void btnOutputsTypesClear_Click(object sender, EventArgs e)
		{
			tabData.IsNeedRestore = true;

			ttToolTip.SetToolTip(txtOutputsTypesChoosen, "не выбраны");
			sSelectedOutputsTypesIDList = "";
			txtOutputsTypesChoosen.Text = "";
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

		#region Cars

		private void btnCarsChoose_Click(object sender, EventArgs e)
		{
			_SelectedIDList = null;
			_SelectedText = "";

			Output oOutputForCars = new Output();

			DateTime? dDateBeg = null;
			DateTime? dDateEnd = null;
			string sCarAliasContext = null;

			if (!dtrDates.dtpBegDate.IsEmpty)
				dDateBeg = dtrDates.dtpBegDate.Value.Date;
			if (!dtrDates.dtpEndDate.IsEmpty)
				dDateEnd = dtrDates.dtpEndDate.Value.Date;
			if (txtCarAliasContext.Text.Trim().Length > 0)
				sCarAliasContext = txtCarAliasContext.Text.Trim();

			oOutputForCars.FillTableOutputsCarsAliases(dDateBeg, dDateEnd, sCarAliasContext);
			if (oOutputForCars.ErrorNumber != 0 || oOutputForCars.TableOutputsCarsAliases == null)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных...");
				return;
			}
			if (oOutputForCars.TableOutputsCarsAliases.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Нет данных...");
				return;
			}

			if (StartForm(new frmSelectID(this, oOutputForCars.TableOutputsCarsAliases, "CarAlias, BackDoor", "Машина,Бок.дверь", true)) == DialogResult.Yes)
			{
				if (_SelectedIDList == null || !_SelectedIDList.Contains(","))
				{
					btnCarsClear_Click(null, null);
					return;
				}

				Setting oSet = new Setting();
				string sCarAliasDelimiter = oSet.FillVariable("sCarAliasDelimiter");
				if (sCarAliasDelimiter == null || sCarAliasDelimiter == "")
					sCarAliasDelimiter = "###";

				sSelectedCarsAliasList = "";

				string sCarsIDList = "," + _SelectedIDList;
				foreach (DataRow r in oOutputForCars.TableOutputsCarsAliases.Rows)
				{
					if (sCarsIDList.Contains("," + r["ID"].ToString().Trim() + ","))
					{
						sSelectedCarsAliasList += r["CarAlias"].ToString() + sCarAliasDelimiter;
					}
				}
				if (sSelectedCarsAliasList.Length > 0)
					sSelectedCarsAliasList = sCarAliasDelimiter + sSelectedCarsAliasList;

				txtCarsChoosen.Text = _SelectedText;
				ttToolTip.SetToolTip(txtCarsChoosen, txtCarsChoosen.Text);

				tabData.IsNeedRestore = true;
			}

			_SelectedIDList = null;
			_SelectedText = "";
		}

		private void btnCarsClear_Click(object sender, EventArgs e)
		{
			tabData.IsNeedRestore = true;

			ttToolTip.SetToolTip(txtCarsChoosen, "не выбраны");
			sSelectedCarsAliasList = "";
			txtCarsChoosen.Text = "";
		}

		#endregion Cars

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

		private void optSelectedInfoAny_CheckedChanged(object sender, EventArgs e)
		{
			if (optSelectedInfo01.Checked)
			{
				chkSelectedInfo0.Enabled =
				chkSelectedInfo1.Enabled =
					true;
			}
			else
			{
				chkSelectedInfo0.Enabled =
				chkSelectedInfo1.Enabled =
				chkSelectedInfo0.Checked =
				chkSelectedInfo1.Checked =
					false;
			}
		}

		private void chkSelectedInfo0_CheckedChanged(object sender, EventArgs e)
		{
			if (chkSelectedInfo0.Checked)
				chkSelectedInfo1.Checked = false;
		}

		private void chkSelectedInfo1_CheckedChanged(object sender, EventArgs e)
		{
			if (chkSelectedInfo1.Checked)
				chkSelectedInfo0.Checked = false;
		}

		private void optIsConfirmed_CheckedChanged(object sender, EventArgs e)
		{
			dtrDatesConfirm.Enabled = optIsConfirmed.Checked;
			dtrDatesConfirm.dtpBegDate.HideControl(optIsConfirmed.Checked);
			dtrDatesConfirm.dtpEndDate.HideControl(optIsConfirmed.Checked);
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


		#region Print Bill (разница QntWished vs QntConfirmed, QntWished vs QntSelected)

		private void mniPrintOutputBill_Click(object sender, EventArgs e)
		{
			// накладная с несоответствиями. (1/N)

			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.Rows.Count == 0)
				return;

			bool bAll = ((ToolStripMenuItem)sender).Name.EndsWith("All"); // все отмеченные записи

			Output oOutputPrint = new Output();

			if (bAll)
			{
				OutputPrepareIDList(oOutputPrint, bAll);
				if (oOutputPrint.IDList == null || oOutputPrint.IDList.Length == 0)
				{
					RFMCursorWait.Set(false);
					RFMMessage.MessageBoxError("Нет отмеченных записей...");
					return;
				}

				oOutputPrint.FillData();
				if (oOutputPrint.ErrorNumber != 0)
				{
					RFMCursorWait.Set(false);
					return;
				}
				if (oOutputPrint.MainTable.Rows.Count == 0)
				{
					RFMCursorWait.Set(false);
					RFMMessage.MessageBoxError("Нет отмеченных расходов...");
					return;
				}

				// товары в отмеченных накладных
				oOutputPrint.FillTableOutputsGoods(0);
				if (oOutputPrint.ErrorNumber != 0)
				{
					RFMCursorWait.Set(false);
					return;
				}

				DataTable tableOutputsGoods = oOutputPrint.TableOutputsGoods.Copy();
				foreach (DataRow r in oOutputPrint.MainTable.Rows)
				{
					int nOutputID = (int)r["ID"];
					oOutputPrint.ClearError();
					oOutputPrint.FillTableOutputsGoods(nOutputID);
					if (oOutputPrint.ErrorNumber == 0)
					{
						tableOutputsGoods.Merge(oOutputPrint.TableOutputsGoods);
					}
				}

				oOutputPrint.TableOutputsGoods.Clear();
				oOutputPrint.TableOutputsGoods.Merge(tableOutputsGoods);

				if (oOutputPrint.TableOutputsGoods.Rows.Count == 0)
				{
					RFMCursorWait.Set(false);
					RFMMessage.MessageBoxError("Нет данных о товарах в отмеченных расходах...");
					return;
				}
			}
			else
			{
				if (grdData.CurrentRow == null)
					return;
				if (grdData.IsStatusRow(grdData.CurrentRow.Index))
					return;

				oOutputPrint.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
				oOutputPrint.FillData();
				if (oOutputPrint.ErrorNumber != 0)
				{
					RFMCursorWait.Set(false);
					return;
				}
				if (oOutputPrint.MainTable.Rows.Count == 0)
				{
					RFMCursorWait.Set(false);
					RFMMessage.MessageBoxError("Нет данных о расходе...");
					return;
				}

				// товары в текущей накладной
				oOutputPrint.FillTableOutputsGoods(oOutputCur.ID);
				if (oOutputPrint.ErrorNumber != 0)
				{
					RFMCursorWait.Set(false);
					return;
				}
			}

			// только подбор
			bool bSelected = ((ToolStripMenuItem)sender).Name.ToUpper().Contains("SELECT");

			// выводим разницу в подборе
			if (bSelected)
			{
				foreach (DataRow r in oOutputPrint.TableOutputsGoods.Rows)
				{
					r["QntConfirmed"] = r["QntSelected"];
					r["QntDiff"] = r["QntSelDiff"];
					r["BoxConfirmed"] = r["BoxSelected"];
					r["BoxDiff"] = r["BoxSelDiff"];
					r["PalConfirmed"] = r["PalSelected"];
					r["PalDiff"] = r["PalSelDiff"];
				}
			}
			InBoxWeighting(oOutputPrint.TableOutputsGoods);

			// печать
			oOutputPrint.DS.Relations.Add("r1", oOutputPrint.MainTable.Columns["OutputID"],
				oOutputPrint.TableOutputsGoods.Columns["OutputID"]);
			// добавляем нужные поля в таблицу-источник
			RepTableColumnAdd(oOutputPrint.TableOutputsGoods);
			oOutputPrint.TableOutputsGoods.Columns.Add("OutputNettoConfirmed");
			oOutputPrint.TableOutputsGoods.Columns["OutputNettoConfirmed"].Expression = "Parent([r1]).NettoConfirmed";
			oOutputPrint.TableOutputsGoods.Columns.Add("OutputBruttoConfirmed");
			oOutputPrint.TableOutputsGoods.Columns["OutputBruttoConfirmed"].Expression = "Parent([r1]).BruttoConfirmed";

			RFMCursorWait.Set(false);

			repOutputBill rep = new repOutputBill(bSelected);
			StartForm(new frmActiveReport(oOutputPrint.DS.Tables["TableOutputsGoods"], rep));
		}

		#endregion Print Bill

		#region Print Bill For Confirm (загрузочная, для выдачи)

		private void mniPrintOutputBillForConfirm_Click(object sender, EventArgs e)
		{
			// накладная для подтверждения, выдачи (1/N)

			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.Rows.Count == 0)
				return;

			RFMCursorWait.Set(true);

			bool bAll = ((ToolStripMenuItem)sender).Name.EndsWith("All"); // все отмеченные записи

			Output oOutputPrint = new Output();

			if (bAll)
			{
				OutputPrepareIDList(oOutputPrint, bAll);
				if (oOutputPrint.IDList == null || oOutputPrint.IDList.Length == 0)
				{
					RFMCursorWait.Set(false);
					RFMMessage.MessageBoxError("Нет отмеченных записей...");
					return;
				}

				//oOutputPrint.FilterConfirmed = false;
				oOutputPrint.FillData();
				if (oOutputPrint.ErrorNumber != 0)
				{
					RFMCursorWait.Set(false);
					return;
				}
				if (oOutputPrint.MainTable.Rows.Count == 0)
				{
					RFMCursorWait.Set(false);
					RFMMessage.MessageBoxError("Нет отмеченных неподтвержденных расходов...");
					return;
				}

				// набор и проверка для массовой печати 
				_ForPrintOutputBillForConfirmAll(oOutputPrint);
			}
			else
			{
				if (grdData.CurrentRow == null)
					return;
				if (grdData.IsStatusRow(grdData.CurrentRow.Index))
					return;

				oOutputPrint.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
				oOutputPrint.FillData();
				if (oOutputPrint.ErrorNumber != 0)
				{
					RFMCursorWait.Set(false);
					return;
				}
				if (oOutputPrint.MainTable.Rows.Count == 0)
				{
					RFMCursorWait.Set(false);
					RFMMessage.MessageBoxError("Нет данных о расходе...");
					return;
				}

				/*
				if (!Convert.IsDBNull(oOutputPrint.MainTable.Rows[0]["DateConfirm"]))
				{
					RFMCursorWait.Set(false);
					RFMMessage.MessageBoxError("Расход уже подтвержден...");
					return;
				}
				*/
				_ForPrintOutputBillForConfirmOne(oOutputPrint);
			}
		}

		private void _ForPrintOutputBillForConfirmOne(Output oOutputPrint)
		{
			if (Convert.IsDBNull(oOutputPrint.MainTable.Rows[0]["DateSelect"]))
			{
				RFMCursorWait.Set(false);
				RFMMessage.MessageBoxError("Товар по расходу еще не подобран...");
				return;
			}

			oOutputPrint.FillTableOutputsGoodsAnytime(oOutputPrint.ID);
			if (oOutputPrint.ErrorNumber != 0)
			{
				RFMCursorWait.Set(false);
				return;
			}
			if (oOutputPrint.TableOutputsGoods.Rows.Count == 0)
			{
				RFMCursorWait.Set(false);
				RFMMessage.MessageBoxError("Нет данных о товарах в расходе...");
				return;
			}

			_PrintOutputBillForConfirm(oOutputPrint);
		}

		private void _ForPrintOutputBillForConfirmAll(Output oOutputPrint)
		{
			// только для собранных! DateSelect
			bool bExclude = false;
			string sOutputsForPrintIDList = "";
			foreach (DataRow r in oOutputPrint.MainTable.Rows)
			{
				if (!Convert.IsDBNull(r["DateSelect"]))
				{
					sOutputsForPrintIDList += r["ID"].ToString() + ",";
				}
				else
				{
					bExclude = true;
				}
			}
			if (bExclude)
			{
				oOutputPrint.FillData();
				if (oOutputPrint.ErrorNumber != 0)
				{
					RFMCursorWait.Set(false);
					return;
				}
				if (oOutputPrint.MainTable.Rows.Count == 0)
				{
					RFMCursorWait.Set(false);
					RFMMessage.MessageBoxError("Нет отмеченных неподтвержденных расходов, для которых подобран товар...");
					return;
				}
			}

			// таблицы для товаров по всем расходам (через промежуточную таблицу tableOutputsGoods)
			oOutputPrint.FillTableOutputsGoodsAnytime(0);
			if (oOutputPrint.ErrorNumber != 0)
			{
				RFMCursorWait.Set(false);
				return;
			}
			DataTable tableOutputsGoods = oOutputPrint.TableOutputsGoods.Copy();
			foreach (DataRow r in oOutputPrint.MainTable.Rows)
			{
				int nOutputID = (int)r["ID"];
				oOutputPrint.ClearError();
				oOutputPrint.FillTableOutputsGoodsAnytime(nOutputID);
				if (oOutputPrint.ErrorNumber == 0)
				{
					tableOutputsGoods.Merge(oOutputPrint.TableOutputsGoods);
				}
			}

			oOutputPrint.TableOutputsGoods.Clear();
			oOutputPrint.TableOutputsGoods.Merge(tableOutputsGoods);

			if (oOutputPrint.TableOutputsGoods.Rows.Count == 0)
			{
				RFMCursorWait.Set(false);
				RFMMessage.MessageBoxError("Нет данных о товарах в отмеченных неподтвержденных расходах...");
				return;
			}

			_PrintOutputBillForConfirm(oOutputPrint);
		}

		private void _PrintOutputBillForConfirm(Output oOutputPrint)
		{
			// заменяем "кол-во штук" на "дополнительно (к коробкам) штук"
			int nBox;
			decimal nQnt, nInBox; bool bWeighting;
			foreach (DataRow r in oOutputPrint.TableOutputsGoods.Rows)
			{
				bWeighting = Convert.ToBoolean(r["Weighting"]);
				if (bWeighting)
				{
					r["BoxWished"] = r["PalWished"] =
					r["BoxPicked"] = r["PalPicked"] = 
						0;
					r["QntWished"] = Convert.ToDecimal(r["QntWished"]) * Convert.ToDecimal(r["Netto"]);
				}
				else
				{
					nInBox = Convert.ToDecimal(r["InBox"]);
					nQnt = Convert.ToDecimal(r["QntWished"]);
					nBox = Convert.ToInt32(Math.Floor(Convert.ToDecimal(r["BoxWished"])));
					nQnt = nQnt - nBox * nInBox;
					r["BoxWished"] = nBox;
					r["QntWished"] = nQnt;

					nQnt = Convert.ToDecimal(r["QntPicked"]);
					nBox = Convert.ToInt32(Math.Floor(Convert.ToDecimal(r["BoxPicked"])));
					nQnt = nQnt - nBox * nInBox;
					r["BoxPicked"] = nBox;
					r["QntPicked"] = nQnt;
				}
				//if (nInBox != Math.Floor(nInBox))
				//{
				//	r["Weighting"] = true;
				//}
			}

			oOutputPrint.DS.Relations.Add("r1", oOutputPrint.MainTable.Columns["OutputID"],
				oOutputPrint.TableOutputsGoods.Columns["OutputID"]);
			RepTableColumnAdd(oOutputPrint.TableOutputsGoods);
			oOutputPrint.TableOutputsGoods.Columns.Add("OutputNettoWished");
			oOutputPrint.TableOutputsGoods.Columns["OutputNettoWished"].Expression = "Parent([r1]).NettoWished";
			oOutputPrint.TableOutputsGoods.Columns.Add("OutputBruttoWished");
			oOutputPrint.TableOutputsGoods.Columns["OutputBruttoWished"].Expression = "Parent([r1]).BruttoWished";
			oOutputPrint.TableOutputsGoods.Columns.Add("OutputNettoConfirmed");
			oOutputPrint.TableOutputsGoods.Columns["OutputNettoConfirmed"].Expression = "Parent([r1]).NettoConfirmed";
			oOutputPrint.TableOutputsGoods.Columns.Add("OutputBruttoConfirmed");
			oOutputPrint.TableOutputsGoods.Columns["OutputBruttoConfirmed"].Expression = "Parent([r1]).BruttoConfirmed";
			oOutputPrint.TableOutputsGoods.Columns.Add("OwnerID");
			oOutputPrint.TableOutputsGoods.Columns["OwnerID"].Expression = "Parent([r1]).OwnerID";
			oOutputPrint.TableOutputsGoods.Columns.Add("OutputCellAddress");
			oOutputPrint.TableOutputsGoods.Columns["OutputCellAddress"].Expression = "Parent([r1]).CellAddress";

			// поля с остатками
			/*
            oOutputPrint.TableOutputsGoods.Columns.Add("CCQnt", Type.GetType("System.Decimal"));
            oOutputPrint.TableOutputsGoods.Columns.Add("CCRestBoxes", Type.GetType("System.Int32"));
            oOutputPrint.TableOutputsGoods.Columns.Add("CCRestQnt", Type.GetType("System.Decimal"));
            Oddment oOddment = new Oddment();
            foreach (DataRow r in oOutputPrint.TableOutputsGoods.Rows)
            {
                int nPackingID_ = Convert.ToInt32(r["PackingID"]);
                int nGoodStateID_ = Convert.ToInt32(r["GoodStateID"]);
                int? nOwnerID_ = null;
                if (!Convert.IsDBNull(r["OwnerID"]))
                    nOwnerID_ = Convert.ToInt32(r["OwnerID"]);

                decimal nCCQnt = oOddment.GetCellsContentsQnt(nPackingID_, nGoodStateID_, nOwnerID_, true, true);
                if (nCCQnt > 0)
                {
                    r["CCQnt"] = nCCQnt;
                    decimal nInBoxCC = Convert.ToDecimal(r["InBox"]);
                    int nCCRestBoxes = Convert.ToInt32(Math.Floor(nCCQnt / nInBoxCC));
                    r["CCRestBoxes"] = (nCCRestBoxes > 999) ? 999 : nCCRestBoxes;
                    r["CCRestQnt"] = nCCQnt - nCCRestBoxes * nInBoxCC;
                }
                else
                {
                    r["CCQnt"] = r["CCRestBoxes"] = r["CCRestQnt"] = 0;
                }
            }
			*/

			// поле CCQnt получено в выборке
			//oOutputPrint.TableOutputsGoods.Columns.Add("CCQnt", Type.GetType("System.Decimal"));
			oOutputPrint.TableOutputsGoods.Columns.Add("CCRestBoxes", Type.GetType("System.Int32"));
			oOutputPrint.TableOutputsGoods.Columns.Add("CCRestQnt", Type.GetType("System.Decimal"));
			foreach (DataRow r in oOutputPrint.TableOutputsGoods.Rows)
			{
				decimal nCCQnt = Convert.ToDecimal(r["CCQnt"]);
				decimal nInBoxCC = Convert.ToDecimal(r["InBox"]);
				int nCCRestBoxes = Convert.ToInt32(Math.Floor(nCCQnt / nInBoxCC));
				r["CCRestBoxes"] = (nCCRestBoxes > 999) ? 999 : nCCRestBoxes;
				r["CCRestQnt"] = nCCQnt - nCCRestBoxes * nInBoxCC;
			}

			// AAA
            //DataTable dt = CopyTable(oOutputPrint.TableOutputsGoods, "dt", "", "OutputID, StoreZoneName, Weighting, GoodGroupName, GoodAlias");
            DataTable dt = CopyTable(oOutputPrint.TableOutputsGoods, "dt", "", "OutputID, StoreZoneName, Weighting, Rank, CLine, Address, GoodGroupName, GoodAlias");

			RFMCursorWait.Set(false);

			// печать 
			repOutputBillForConfirm rep = new repOutputBillForConfirm();
			StartForm(new frmActiveReport(dt, rep));
		}

		#endregion Print Bill For Confirm

		#region Print TrafficsFrames list

		private void mniPrintTrafficsFramesList_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.Rows.Count == 0)
				return;

			RFMCursorWait.Set(true);

			bool bAll = ((ToolStripMenuItem)sender).Name.EndsWith("All"); // все отмеченные записи

			Output oOutputPrint = new Output();
			TrafficFrame oTrafficPrint = new TrafficFrame();

			if (bAll)
			{
				OutputPrepareIDList(oOutputPrint, bAll);
				if (oOutputPrint.IDList == null || oOutputPrint.IDList.Length == 0)
				{
					RFMCursorWait.Set(false);
					RFMMessage.MessageBoxError("Нет отмеченных записей...");
					return;
				}

				// список транспортировок для всех отмеченных расходов
				TrafficFrame oTrafficTemp = new TrafficFrame();
				oTrafficTemp.FilterConfirmed = false;
				oTrafficTemp.FilterOutputsList = oOutputPrint.IDList;
				oTrafficTemp.FillData();
				if (oTrafficTemp.ErrorNumber != 0)
				{
					RFMCursorWait.Set(false);
					return;
				}
				if (oTrafficTemp.MainTable.Rows.Count == 0)
				{
					RFMCursorWait.Set(false);
					RFMMessage.MessageBoxError("Нет данных о транспортировках для отмеченных расходов...");
					return;
				}

				DataRow[] drs = oTrafficTemp.MainTable.Select("", "OutputID");

				oTrafficPrint.ID = -1;
				oTrafficPrint.FillData(); // получена пустая MainTable
				if (oTrafficPrint.ErrorNumber != 0)
				{
					RFMCursorWait.Set(false);
					return;
				}
				foreach (DataRow dr in drs)
				{
					oTrafficPrint.MainTable.ImportRow(dr);
				}
			}
			else
			{
				if (grdData.CurrentRow == null)
					return;
				if (grdData.IsStatusRow(grdData.CurrentRow.Index))
					return;

				oTrafficPrint.FilterOutputsList = grdData.CurrentRow.Cells["grcID"].Value.ToString();
				oTrafficPrint.FilterConfirmed = false;
				oTrafficPrint.FillData();
				if (oTrafficPrint.ErrorNumber != 0)
				{
					RFMCursorWait.Set(false);
					return;
				}
				if (oTrafficPrint.MainTable.Rows.Count == 0)
				{
					RFMCursorWait.Set(false);
					RFMMessage.MessageBoxError("Нет данных о транспортировках поддонов для расхода...");
					return;
				}
			}

			RFMCursorWait.Set(false);

			// печать 
			repTrafficFrameBill rd = new repTrafficFrameBill();
			StartForm(new frmActiveReport(oTrafficPrint.MainTable, rd));
		}

		#endregion Print TrafficsFrames list

		#region Print TrafficsGoods list (пик-лист)

		private void mniPrintTrafficsGoodsList_Click(object sender, EventArgs e)
		{
			// пик-лист (1 / N)

			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.Rows.Count == 0)
				return;

			RFMCursorWait.Set(true);

			bool bAll = ((ToolStripMenuItem)sender).Name.EndsWith("All"); // все отмеченные записи

			Output oOutputPrint = new Output();

			if (bAll)
			{
				OutputPrepareIDList(oOutputPrint, bAll);
				if (oOutputPrint.IDList == null || oOutputPrint.IDList.Length == 0)
				{
					RFMCursorWait.Set(false);
					RFMMessage.MessageBoxError("Нет отмеченных записей...");
					return;
				}
			}
			else
			{
				if (grdData.CurrentRow == null)
					return;
				if (grdData.IsStatusRow(grdData.CurrentRow.Index))
					return;

				if (Convert.IsDBNull(grdData.CurrentRow.Cells["grcID"].Value) ||
					grdData.CurrentRow.Cells["grcID"].Value == null)
				{
					RFMCursorWait.Set(false);
					return;
				}
				oOutputPrint.IDList = grdData.CurrentRow.Cells["grcID"].Value.ToString();
			}

			_PrintTrafficsGoodsList(oOutputPrint, null);
		}

		private void mniPrintTrafficsGoodsListNotPrinted_Click(object sender, EventArgs e)
		{
			// пик-лист (все ненапечатанные)

			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.Rows.Count == 0)
				return;

			RFMCursorWait.Set(true);

			Output oOutputPrint = new Output();

			foreach (DataGridViewRow gr in grdData.Rows)
			{
				DataRow r = ((DataRowView)gr.DataBoundItem).Row;
				if (Convert.IsDBNull(r["DatePrint"]) || Convert.ToBoolean(r["ExistsNewTrafficsGoods"]))
				{
					oOutputPrint.IDList += r["ID"] + ",";
				}
			}
			if (oOutputPrint.IDList == null || oOutputPrint.IDList.Length == 0)
			{
				RFMCursorWait.Set(false);
				RFMMessage.MessageBoxError("Нет расходов, по которым не напечатаны листы заданий...");
				return;
			}

			_PrintTrafficsGoodsList(oOutputPrint, false);
		}

		private void _PrintTrafficsGoodsList(Output oOutputPrint, bool? bPrinted)
		{
			bool bPrintTrafficsFramesList = true;

			// таблица кодов напечанных расходов
			DataTable dtPrint = new DataTable();
			dtPrint.Columns.Add("OutputID", Type.GetType("System.Int32"));
			DataColumn[] pk = new DataColumn[1];
			pk[0] = dtPrint.Columns[0];
			dtPrint.PrimaryKey = pk;
			// 

			oOutputPrint.FillData();
			if (oOutputPrint.ErrorNumber != 0)
			{
				RFMCursorWait.Set(false);
				return;
			}

			// перемещения штук/коробок
			oOutputPrint.FillTableOutputsPickList(oOutputPrint.ID, oOutputPrint.IDList, bPrinted);
			if (oOutputPrint.ErrorNumber != 0)
			{
				RFMCursorWait.Set(false);
				return;
			}

			// список на транспортировки контейнеров
			DataTable tTableFrame = null;
			oOutputPrint.FillTableOutputsTrafficsFramesContains(oOutputPrint.IDList);
			if (oOutputPrint.ErrorNumber != 0)
			{
				RFMCursorWait.Set(false);
				return;
			}

			DataTable dtFramesContains = oOutputPrint.DS.Tables["TableOutputsTrafficsFramesContains"];
			if (dtFramesContains.Rows.Count > 0)
			{
				// заменяем "кол-во штук" на "дополнительно (к коробкам) штук"
				int nBox;
				decimal nQnt, nInBox;
				foreach (DataRow r in dtFramesContains.Rows)
				{
					if (!Convert.IsDBNull(r["InBox"]))
					{
						nInBox = Convert.ToDecimal(r["InBox"]);
						nQnt = Convert.ToDecimal(r["Qnt"]);
						nBox = Convert.ToInt32(Math.Floor(Convert.ToDecimal(r["Box"])));
						nQnt = nQnt - nBox * nInBox;
						r["Box"] = nBox;
						r["Qnt"] = nQnt;
						//if (nInBox != Math.Floor(nInBox))
						//{
						//	r["Weighting"] = true;
						//}
					}
				}
			}
			// -----

			if (oOutputPrint.TableOutputsPickList.Rows.Count == 0)
			{
				RFMCursorWait.Set(false);
				RFMMessage.MessageBoxError("Нет данных о перемещениях коробок/штук для расход" +
					((oOutputPrint.MainTable.Rows.Count > 1) ? "ов" : "а") + "...");
			}
			else
			{
				//InBoxWeighting(oOutputPrint.TableOutputsPickList);

				/*
				int nOutputCurID = 0;
				oOutputPrint.MainTable.Columns.Add("StoresZonesNamesText");
				foreach (DataRow o in oOutputPrint.MainTable.Rows)
				{
					nOutputCurID = Convert.ToInt32(o["ID"]);
					o["StoresZonesNamesText"] = GetStoresZonesNames(nOutputCurID, oOutputPrint.TableOutputsPickList) +
						" (общий вес заказа брутто " + Convert.ToDecimal(o["BruttoWished"]).ToString("# ##0") + ")";
				}
				*/

				DataTable t1 = CopyTable(oOutputPrint.TableOutputsPickList, "t1", "", "");
				oOutputPrint.DS.Tables.Add(t1);
				oOutputPrint.DS.Relations.Add("r1", oOutputPrint.MainTable.Columns["OutputID"],
					t1.Columns["OutputID"]);
				t1.Columns.Add("OutputBruttoWished");
				t1.Columns["OutputBruttoWished"].Expression = "Parent([r1]).BruttoWished";
				t1.Columns.Add("CarAlias");
				t1.Columns["CarAlias"].Expression = "Parent([r1]).CarAlias";
				t1.Columns.Add("BackDoor", Type.GetType("System.Boolean"));
				t1.Columns["BackDoor"].Expression = "Parent([r1]).BackDoor";
				t1.Columns.Add("CarAliasFull");
				t1.Columns["CarAliasFull"].Expression = "Parent([r1]).CarAliasFull";
				t1.Columns.Add("ChargeOrder");
				t1.Columns["ChargeOrder"].Expression = "Parent([r1]).ChargeOrder";
				t1.Columns.Add("ExistsNewTrafficsGoods");
				t1.Columns["ExistsNewTrafficsGoods"].Expression = "Parent([r1]).ExistsNewTrafficsGoods";
				//t1.Columns.Add("StoresZonesNamesText");
				//t1.Columns["StoresZonesNamesText"].Expression = "Parent([r1]).StoresZonesNamesText";

				/*
				// поля с остатками
				t1.Columns.Add("CCQnt", Type.GetType("System.Decimal"));
				t1.Columns.Add("CCRestBoxes", Type.GetType("System.Int32"));
				t1.Columns.Add("CCRestQnt", Type.GetType("System.Decimal"));
				Oddment oOddment = new Oddment();
				foreach (DataRow r in t1.Rows)
				{
					int nPackingID_ = Convert.ToInt32(r["PackingID"]);
					int nGoodStateID_ = Convert.ToInt32(r["GoodStateID"]);
					int? nOwnerID_ = null;
					if (!Convert.IsDBNull(r["OwnerID"]))
						nOwnerID_ = Convert.ToInt32(r["OwnerID"]);

					decimal nCCQnt = oOddment.GetCellsContentsQnt(nPackingID_, nGoodStateID_, nOwnerID_, true, true);
					if (nCCQnt > 0)
					{
						r["CCQnt"] = nCCQnt;
						decimal nInBox = Convert.ToDecimal(r["InBox"]);
						int nCCRestBoxes = Convert.ToInt32(Math.Floor(nCCQnt / nInBox));
						r["CCRestBoxes"] = (nCCRestBoxes > 999) ? 999 : nCCRestBoxes;
						r["CCRestQnt"] = nCCQnt - nCCRestBoxes * nInBox;
					}
					else
					{
						r["CCQnt"] = r["CCRestBoxes"] = r["CCRestQnt"] = 0;
					}
				}
				*/

				t1.Columns.Add("CCRestBoxes", Type.GetType("System.Int32"));
				t1.Columns.Add("CCRestQnt", Type.GetType("System.Decimal"));
				foreach (DataRow r in t1.Rows)
				{
					decimal nCCQnt = Convert.ToDecimal(r["CCQnt"]);
					decimal nInBoxCC = Convert.ToDecimal(r["InBox"]);
					int nCCRestBoxes = Convert.ToInt32(Math.Floor(nCCQnt / nInBoxCC));
					r["CCRestBoxes"] = (nCCRestBoxes > 999) ? 999 : nCCRestBoxes;
					r["CCRestQnt"] = nCCQnt - nCCRestBoxes * nInBoxCC;
				}

				/*
				// поля с доп.информацией по паллетам
				t1.Columns.Add("TrafficsFramesList");
				// собираем список паллет для каждого склада пикинга (по привязке товара, а не по трафику)
				if (dtFramesContains.Rows.Count > 0)
				{
					DataTable dtFramesTemp = new DataTable();
					dtFramesTemp.Columns.Add("StoreZoneSourceID", Type.GetType("System.Int32")); 
					dtFramesTemp.Columns.Add("FramesList");
					dtFramesTemp.Columns.Add("FramesCnt", Type.GetType("System.Int32")); 
					DataColumn[] pkTemp = new DataColumn[1];
					pkTemp[0] = dtFramesTemp.Columns[0];
					dtFramesTemp.PrimaryKey = pkTemp;
					foreach(DataRow tfr in dtFramesContains.Rows)
					{
						if (!Convert.IsDBNull(tfr["StoreZonePickingID"]))
						{
							DataRow rTemp = dtFramesTemp.Rows.Find(Convert.ToInt32(tfr["StoreZonePickingID"]));
							if (rTemp == null)
							{
								rTemp = dtFramesTemp.Rows.Add(Convert.ToInt32(tfr["StoreZonePickingID"]));
								rTemp["FramesCnt"] = 0;
							}
							rTemp["FramesList"] = rTemp["FramesList"].ToString() + ", " + tfr["FrameID"].ToString() + " (" + tfr["GoodAlias"].ToString() + ")";
							rTemp["FramesCnt"] = Convert.ToInt32(rTemp["FramesCnt"]) + 1; 
						}
					}
					foreach(DataRow rTempX in dtFramesTemp.Rows)
					{
						string sFrameList = rTempX["FramesList"].ToString();
						if (sFrameList.Substring(0, 1) == ",")
						{
							sFrameList = sFrameList.Substring(1, sFrameList.Length - 1).Trim();
						}
						if (sFrameList.Length > 0)
						{
							rTempX["FramesList"] = "Паллеты (" + rTempX["FramesCnt"].ToString() + "): " + sFrameList; 
						}
					}
					// собрали список складов пикинга(!) и контейнеров и кладем его в осн.таблицу перемещений

					foreach (DataRow tgr in t1.Rows)
					{
						DataRow rTempG = dtFramesTemp.Rows.Find(Convert.ToInt32(tgr["StoreZoneSourceID"]));
						if (rTempG != null)
						{
							tgr["TrafficsFramesList"] = rTempG["FramesList"].ToString();
						}
					}
				}
				*/

				// AAA
				DataTable tTableGood = CopyTable(t1, "tTableGood", "", "OutputID, CellTargetAddress, StoreZoneSourceName, StoreZoneSourceID, Weighting, CellSourceRank, CellSourceCLine, CellSourceAddress, GoodAlias");

				RFMCursorWait.Set(false);

				// печать 
				//repTrafficGoodBill rd = new repTrafficGoodBill();
				repOutputPickList rd = new repOutputPickList();
				StartForm(new frmActiveReport(tTableGood, rd, 1));

				// отметка печати
				TrafficGood oTrafficGoodPrint = new TrafficGood();
				foreach (DataRow tg in oOutputPrint.TableOutputsPickList.Rows)
				{
					if (!Convert.IsDBNull(tg["ID"]) && Convert.ToInt32(tg["ID"]) != 0)
					{
						oTrafficGoodPrint.SetDatePrint(Convert.ToInt32(tg["ID"]));

						if (!Convert.IsDBNull(tg["OutputID"]) &&
							dtPrint.Rows.Find(Convert.ToInt32(tg["OutputID"])) == null)
						{
							dtPrint.Rows.Add(Convert.ToInt32(tg["OutputID"]));
						}
					}
				}
			}

			RFMCursorWait.Set(true);

			// ---------------------
			// доп.отчет по паллетам

			if (bPrintTrafficsFramesList && dtFramesContains.Rows.Count > 0)
			{
				tTableFrame = CopyTable(dtFramesContains, "tTableFrame", "", "OutputID, CellTargetAddress, GoodAlias, FrameID");

				oOutputPrint.DS.Tables.Add(tTableFrame);
				oOutputPrint.DS.Relations.Add("r2", oOutputPrint.MainTable.Columns["OutputID"],
					tTableFrame.Columns["OutputID"]);
				tTableFrame.Columns.Add("CarAlias");
				tTableFrame.Columns["CarAlias"].Expression = "Parent([r2]).CarAlias";
				tTableFrame.Columns.Add("CarAliasFull");
				tTableFrame.Columns["CarAliasFull"].Expression = "Parent([r2]).CarAliasFull";

				RFMCursorWait.Set(false);

				repTrafficFrameBillForOutput rdf = new repTrafficFrameBillForOutput();
				StartForm(new frmActiveReport(tTableFrame, rdf));

				foreach (DataRow tf in tTableFrame.Rows)
				{
					if (!Convert.IsDBNull(tf["OutputID"]) &&
						dtPrint.Rows.Find(Convert.ToInt32(tf["OutputID"])) == null)
					{
						dtPrint.Rows.Add(Convert.ToInt32(tf["OutputID"]));
					}
				}
			}


			RFMCursorWait.Set(false);

			// отметка печати
			/*
			if (oTrafficGoodPrint.ErrorNumber == 0)
			{
				DataTable dtPrint = new DataTable();
				dtPrint.Columns.Add("OutputID", Type.GetType("System.Int32"));
				DataColumn[] pk = new DataColumn[1];
				pk[0] = dtPrint.Columns[0];
				dtPrint.PrimaryKey = pk;

				foreach (DataRow r in oTrafficGoodPrint.MainTable.Rows)
				{
                    oTrafficGoodPrint.SetDatePrint(Convert.ToInt32(r["ID"]));

					if (!Convert.IsDBNull(r["OutputID"]) &&
						dtPrint.Rows.Find(Convert.ToInt32(r["OutputID"])) == null)
					{
						oOutputPrint.SetDatePrint(Convert.ToInt32(r["OutputID"]));
						dtPrint.Rows.Add(Convert.ToInt32(r["OutputID"]));
					}
				}
				grdData_Restore();
			}
			*/

			if (dtPrint.Rows.Count > 0)
			{
				foreach (DataRow o in dtPrint.Rows)
				{
					oOutputPrint.SetDatePrint(Convert.ToInt32(o["OutputID"]));
				}
			}

			// печатаем загрузочную накладную сразу
			if (RFMMessage.MessageBoxYesNo("Печатать загрузочную накладную?") == DialogResult.Yes)
			{
				Output oOutputPrintForConfirm = new Output();
				oOutputPrintForConfirm.ID = -1;
				oOutputPrintForConfirm.FillData();
				oOutputPrintForConfirm.MainTable.Merge(oOutputPrint.MainTable);

				_ForPrintOutputBillForConfirmAll(oOutputPrintForConfirm);
			}

			grdData_Restore();
		}

		/*
		private string GetStoresZonesNames(int nOutputCurID, DataTable dt)
		{
			string sStoresZonesNamesList = "";
			string sStoresZonesIDList = ",";
			DataRow[] dra = dt.Select("OutputID = " + nOutputCurID.ToString().Trim(), "StoreZoneSourceName");
			foreach (DataRow dr in dra)
			{
				if (!sStoresZonesIDList.Contains("," + dr["StoreZoneSourceID"].ToString().Trim() + ","))
				{
					sStoresZonesIDList += dr["StoreZoneSourceID"].ToString().Trim() + ",";
					sStoresZonesNamesList += ", " + dr["StoreZoneSourceName"].ToString().Trim();
				}
			}
			if (sStoresZonesNamesList.Length > 0 && sStoresZonesNamesList.Substring(0, 1) == ",")
			{
				sStoresZonesNamesList = sStoresZonesNamesList.Substring(1, sStoresZonesNamesList.Length - 1).Trim();
			}
			return (sStoresZonesNamesList);
		}
		*/

		private void mniPrintTrafficsGoodsListCritical_Click(object sender, EventArgs e)
		{
			// только новые перемещения, которые возникли при ошибке (1)

			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.CurrentRow == null)
				return;
			if (grdData.CurrentRow == null)
				return;
			if (grdData.IsStatusRow(grdData.CurrentRow.Index))
				return;

			RFMCursorWait.Set(true);

			// список операций
			TrafficGood oTrafficPrint = new TrafficGood();
			oTrafficPrint.FilterOutputsList = grdData.CurrentRow.Cells["grcID"].Value.ToString();
			oTrafficPrint.FilterConfirmed = false;
			oTrafficPrint.FilterCritical = true;
			oTrafficPrint.FillData();
			if (oTrafficPrint.ErrorNumber != 0)
			{
				RFMCursorWait.Set(false);
				return;
			}
			if (oTrafficPrint.MainTable.Rows.Count == 0)
			{
				RFMCursorWait.Set(false);
				RFMMessage.MessageBoxError("Нет данных о новых перемещениях коробок/штук для расхода...");
				return;
			}
			InBoxWeighting(oTrafficPrint.MainTable);

			RFMCursorWait.Set(false);

			// печать 
			repTrafficGoodBill rd = new repTrafficGoodBill();
			StartForm(new frmActiveReport(oTrafficPrint.MainTable, rd));
		}

		#endregion Print TrafficsGoods list (пик-лист)

		#region Print Complete list (комплект-лист, Confirmed)

		private void mniPrintCompleteList_Click(object sender, EventArgs e)
		{
			// комплект-лист. (1)
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.Rows.Count == 0)
				return;

			bool bAll = ((ToolStripMenuItem)sender).Name.EndsWith("All"); // все отмеченные записи

			Output oOutputPrint = new Output();

			if (bAll)
			{
				OutputPrepareIDList(oOutputPrint, bAll);
				if (oOutputPrint.IDList == null || oOutputPrint.IDList.Length == 0)
				{
					RFMCursorWait.Set(false);
					RFMMessage.MessageBoxError("Нет отмеченных записей...");
					return;
				}

				//oOutputPrint.FilterConfirmed = false;
				oOutputPrint.FillData();
				if (oOutputPrint.ErrorNumber != 0)
				{
					RFMCursorWait.Set(false);
					return;
				}
				if (oOutputPrint.MainTable.Rows.Count == 0)
				{
					RFMCursorWait.Set(false);
					RFMMessage.MessageBoxError("Нет отмеченных неподтвержденных расходов...");
					return;
				}

				// массовая печать
				// заготовка (пустая таблица)
				oOutputPrint.FillTableOutputsItems(oOutputCur.ID);
				if (oOutputPrint.ErrorNumber != 0)
				{
					RFMCursorWait.Set(false);
					return;
				}
				DataTable tTableOutputsItems = oOutputPrint.TableOutputsItems.Clone();

				// проверка выполнения всех трафиков 
				bool bTrafficsConfirmed = true;
				int nOutputPrintID;
				foreach (DataRow r in oOutputPrint.MainTable.Rows)
				{
					nOutputPrintID = Convert.ToInt32(r["ID"]);

					oOutputPrint.FillTableOutputsTraffics(nOutputPrintID, true);
					if (oOutputPrint.ErrorNumber != 0)
					{
						RFMCursorWait.Set(false);
						return;
					}
					bTrafficsConfirmed = true;
					foreach (DataRow Row in oOutputPrint.TableOutputsTrafficsFrames.Rows)
					{
						if (Convert.IsDBNull(Row["DateConfirm"]))
						{
							bTrafficsConfirmed = false;
							break;
						}
					}
					if (!bTrafficsConfirmed)
					{
						continue;
					}

					oOutputPrint.FillTableOutputsTraffics(nOutputPrintID, false);
					foreach (DataRow Row in oOutputPrint.TableOutputsTrafficsGoods.Rows)
					{
						if (Convert.IsDBNull(Row["DateConfirm"]))
						{
							bTrafficsConfirmed = false;
							break;
						}
					}
					if (!bTrafficsConfirmed)
					{
						continue;
					}

					// таблица составляющих расхода
					oOutputPrint.FillTableOutputsItems(nOutputPrintID);
					if (oOutputPrint.ErrorNumber != 0)
					{
						RFMCursorWait.Set(false);
						return;
					}
					if (oOutputPrint.TableOutputsItems.Rows.Count == 0)
					{
						continue;
					}

					// добавляем в список
					tTableOutputsItems.Merge(oOutputPrint.TableOutputsItems);
				}

				if (tTableOutputsItems.Rows.Count == 0)
				{
					RFMCursorWait.Set(false);
					RFMMessage.MessageBoxError("Нет данных о составляющих расходов...");
					return;
				}

				oOutputPrint.TableOutputsItems.Clear();
				oOutputPrint.TableOutputsItems.Merge(tTableOutputsItems);
			}
			else
			{
				if (grdData.CurrentRow == null)
					return;
				if (grdData.IsStatusRow(grdData.CurrentRow.Index))
					return;

				oOutputPrint.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
				oOutputPrint.FillData();
				if (oOutputPrint.ErrorNumber != 0)
				{
					RFMCursorWait.Set(false);
					return;
				}
				if (oOutputPrint.MainTable.Rows.Count == 0)
				{
					RFMCursorWait.Set(false);
					RFMMessage.MessageBoxError("Нет данных о расходе...");
					return;
				}

				// проверка выполнения всех трафиков 
				oOutputPrint.FillTableOutputsTraffics((int)oOutputPrint.ID, true);
				if (oOutputPrint.ErrorNumber != 0)
				{
					RFMCursorWait.Set(false);
					return;
				}
				bool bTrafficsConfirmed = true;
				foreach (DataRow Row in oOutputPrint.TableOutputsTrafficsFrames.Rows)
				{
					if (Convert.IsDBNull(Row["DateConfirm"]))
					{
						bTrafficsConfirmed = false;
						break;
					}
				}
				if (!bTrafficsConfirmed)
				{
					RFMCursorWait.Set(false);
					RFMMessage.MessageBoxError("Есть неподтвержденные операции транспортировки для расхода!");
					return;
				}
				oOutputPrint.FillTableOutputsTraffics((int)oOutputPrint.ID, false);
				foreach (DataRow Row in oOutputPrint.TableOutputsTrafficsGoods.Rows)
				{
					if (Convert.IsDBNull(Row["DateConfirm"]))
					{
						bTrafficsConfirmed = false;
						break;
					}
				}
				if (!bTrafficsConfirmed)
				{
					RFMCursorWait.Set(false);
					RFMMessage.MessageBoxError("Есть неподтвержденные операции перемещения коробок/штук для расхода!");
					return;
				}


				// таблица составляющих расхода
				oOutputPrint.FillTableOutputsItems(oOutputCur.ID);
				if (oOutputPrint.ErrorNumber != 0)
				{
					RFMCursorWait.Set(false);
					return;
				}
				if (oOutputPrint.TableOutputsItems.Rows.Count == 0)
				{
					RFMCursorWait.Set(false);
					RFMMessage.MessageBoxError("Нет данных о составляющих расхода...");
					return;
				}
			}

			// дробить ли по складам 
			bool bStoreZoneSeparate = false;
			/*
			int nStoreZoneTempID = 0;
			foreach (DataRow r in oOutputPrint.TableOutputsItems.Rows)
			{
				if (!Convert.ToBoolean(r["IsFrame"]))
				{
					if (nStoreZoneTempID == 0)
					{
						nStoreZoneTempID = Convert.ToInt32(r["StoreZoneSourceID"]);
					}
					else
					{
						if (Convert.ToInt32(r["StoreZoneSourceID"]) != nStoreZoneTempID)
						{
							RFMCursorWait.Set(false);
							//if (RFMMessage.MessageBoxYesNo("Печатать список для каждого склада на отдельной странице?", false) == DialogResult.Yes)
							//{
							//	bStoreZoneSeparate = true;
							//}
							RFMCursorWait.Set(true);
							Refresh();
							break;
						}
					}
				}
			}
			*/
			InBoxWeighting(oOutputPrint.TableOutputsItems);

			// добавляем нужные поля в таблицу-источник
			oOutputPrint.DS.Relations.Add("r1", oOutputPrint.MainTable.Columns["OutputID"],
				oOutputPrint.TableOutputsItems.Columns["OutputID"]);
			RepTableColumnAdd(oOutputPrint.TableOutputsItems);

			DataTable dt = CopyTable(oOutputPrint.TableOutputsItems, "dt", "", "OutputID, IsFrame desc, StoreZoneSourceName, StoreZoneSourceID, GoodAlias, FrameID");

			RFMCursorWait.Set(false);

			repOutputCompleteList rep = new repOutputCompleteList(bStoreZoneSeparate);
			StartForm(new frmActiveReport(dt, rep));
		}

		#endregion Print Complete list (комплект-лист)

		#region Print Control list (лист передачи коробок/штук, Wished)

		private void mniPrintControlList_Click(object sender, EventArgs e)
		{
			// контрольный лист передачи (1)

			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.Rows.Count == 0)
				return;
			if (grdData.CurrentRow == null)
				return;
			if (grdData.IsStatusRow(grdData.CurrentRow.Index))
				return;

			RFMCursorWait.Set(true);

			Output oOutputPrint = new Output();

			// получение данных 
			int nOutputID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			oOutputPrint.ID = nOutputID;
			oOutputPrint.FillData();
			if (oOutputPrint.ErrorNumber != 0 ||
				oOutputPrint.MainTable.Rows.Count != 1)
			{
				RFMCursorWait.Set(false);
				return;
			}
			if (Convert.IsDBNull(oOutputPrint.MainTable.Rows[0]["CellID"]))
			{
				RFMMessage.MessageBoxError("Не определена ячейка расхода...");
				return;
			}
			int nCellID = Convert.ToInt32(oOutputPrint.MainTable.Rows[0]["CellID"]);

			// трафики паллет
			oOutputPrint.FillTableOutputsTraffics(nOutputID, true);
			if (oOutputPrint.ErrorNumber != 0)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о транспортировках паллет...");
				RFMCursorWait.Set(false);
				return;
			}
			// трафики товаров
			oOutputPrint.FillTableOutputsTraffics(nOutputID, false);
			if (oOutputPrint.ErrorNumber != 0)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о перемещениях коробок/штук...");
				RFMCursorWait.Set(false);
				return;
			}
			if (oOutputPrint.TableOutputsTrafficsFrames.Rows.Count == 0 &&
				oOutputPrint.TableOutputsTrafficsGoods.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Нет данных о транспортировках паллет и перемещениях коробок/штук...");
				RFMCursorWait.Set(false);
				return;
			}

			// составляющие расхода - пригодятся для разобранных контейнеров
			oOutputPrint.FillTableOutputsItems(nOutputID);
			if (oOutputPrint.ErrorNumber != 0)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о составляющих расхода...");
				RFMCursorWait.Set(false);
				return;
			}

			DataTable dt = oOutputPrint.TableOutputsTrafficsGoods;
			dt.PrimaryKey = null;
			dt.Columns["FrameID"].ColumnName = "FromFrameID";
			dt.Columns["ID"].AllowDBNull = true;
			dt.Columns["ID"].Unique = false;
			dt.Columns.Remove("OwnerName");
			dt.Columns.Remove("DateOutput");
			dt.Columns.Remove("DateConfirm");
			dt.Columns.Remove("OutputBarCode");
			dt.Columns.Add("FrameID", Type.GetType("System.Int32"));
			dt.Columns.Add("IsFrame", Type.GetType("System.Boolean"));
			foreach (DataRow rtg in dt.Rows)
			{
				rtg["IsFrame"] = false;
			}

			// перебираем все контейнеры
			int nFrameID;
			Frame oFrameTemp = new Frame();
			foreach (DataRow rtf in oOutputPrint.TableOutputsTrafficsFrames.Rows)
			{
				if (Convert.ToInt32(rtf["CellTargetID"]) == nCellID)
				{
					nFrameID = Convert.ToInt32(rtf["FrameID"]);
					oFrameTemp.FillTableFramesContents(nFrameID);
					if (oFrameTemp.ErrorNumber == 0)
					{
						if (oFrameTemp.TableFramesContents.Rows.Count > 0)
						{
							// контейнер не разобран 
							foreach (DataRow rfc in oFrameTemp.TableFramesContents.Rows)
							{
								dt.ImportRow(rfc);
								DataRow lastRow = dt.Rows[dt.Rows.Count - 1];
								lastRow["IsFrame"] = true;
								lastRow["OutputID"] = nOutputID;
								lastRow["QntWished"] = rfc["Qnt"];
								lastRow["BoxWished"] = (decimal)rfc["Qnt"] / (decimal)rfc["InBox"];
								lastRow["RestBoxWished"] = Math.Floor((decimal)lastRow["BoxWished"]);
								lastRow["RestQntWished"] = (decimal)lastRow["QntWished"] - (decimal)lastRow["RestBoxWished"] * (decimal)lastRow["InBox"];
							}
						}
						else
						{
							// контейнер уже разобран. возьмем данные из составляющих расхода
							foreach (DataRow roi in oOutputPrint.TableOutputsItems.Rows)
							{
								if (!Convert.IsDBNull(roi["FrameID"]) && Convert.ToInt32(roi["FrameID"]) == nFrameID)
								{
									dt.ImportRow(roi);
									DataRow lastRow = dt.Rows[dt.Rows.Count - 1];
									dt.Rows[dt.Rows.Count - 1]["IsFrame"] = true;
									dt.Rows[dt.Rows.Count - 1]["OutputID"] = nOutputID;
									lastRow["QntWished"] = roi["Qnt"];
									lastRow["BoxWished"] = (decimal)roi["Qnt"] / (decimal)roi["InBox"];
									lastRow["RestBoxWished"] = Math.Floor((decimal)lastRow["BoxWished"]);
									lastRow["RestQntWished"] = (decimal)lastRow["QntWished"] - (decimal)lastRow["RestBoxWished"] * (decimal)lastRow["InBox"];
								}
							}
						}
					}
				}
			}
			if (dt.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Нет данных о транспортировках паллет и перемещениях коробок/штук в конечную ячейку...");
				RFMCursorWait.Set(false);
				return;
			}

			InBoxWeighting(dt);

			// переименуем поля как в отчете
			dt.Columns["QntWished"].ColumnName = "Qnt";
			dt.Columns["BoxWished"].ColumnName = "Boxes";
			dt.Columns["RestQntWished"].ColumnName = "RestQnt";
			dt.Columns["RestBoxWished"].ColumnName = "RestBoxes";

			// добавляем нужные поля в таблицу-источник
			oOutputPrint.DS.Relations.Add("r1", oOutputPrint.MainTable.Columns["OutputID"],
				dt.Columns["OutputID"]);
			RepTableColumnAdd(dt);

			DataTable dtr;
			// выводить штрих-код товара
			if (RFMMessage.MessageBoxYesNo("Выводить штрих-код товара?") == DialogResult.Yes)
			{
				// упорядочить таблицу по товару: первый лист - контейнеры, дальше - коробки
				dtr = CopyTable(dt, "dtr", "", "IsFrame desc, GoodAlias, FrameID");
			}
			else
			{
				foreach (DataRow r in dt.Rows)
				{
					r["GoodBarCode"] = "";
				}
				// упорядочить таблицу по № контейнера: первый лист - контейнеры, дальше - коробки
				dtr = CopyTable(dt, "dtr", "", "IsFrame desc, FrameID, GoodAlias");
			}

			RFMCursorWait.Set(false);

			repOutputControlList rep = new repOutputControlList();
			StartForm(new frmActiveReport(dtr, rep));
		}

		#endregion Print Control list

		private void InBoxWeighting(DataTable tTable)
		{
			if (tTable.Columns["InBox"] == null || tTable.Columns["Weighting"] == null)
				return;

			decimal nInBox;
			foreach (DataRow r in tTable.Rows)
			{
				if (!Convert.IsDBNull(r["InBox"]) && !Convert.IsDBNull(r["Weighting"]))
				{
					nInBox = Convert.ToDecimal(r["InBox"]);
					if (nInBox != Math.Floor(nInBox))
					{
						r["Weighting"] = true;
					}
				}
			}
		}

		private void RepTableColumnAdd(DataTable tTable)
		{
			tTable.Columns.Add("OutputTypeName");
			tTable.Columns["OutputTypeName"].Expression = "Parent([r1]).OutputTypeName";
			tTable.Columns.Add("OutputGoodStateName");
			tTable.Columns["OutputGoodStateName"].Expression = "Parent([r1]).GoodStateName";
			tTable.Columns.Add("OwnerName");
			tTable.Columns["OwnerName"].Expression = "Parent([r1]).OwnerName";
			tTable.Columns.Add("PartnerName");
			tTable.Columns["PartnerName"].Expression = "Parent([r1]).PartnerName";
			tTable.Columns.Add("DateOutput");
			tTable.Columns["DateOutput"].Expression = "Parent([r1]).DateOutput";
			tTable.Columns.Add("DateConfirm");
			tTable.Columns["DateConfirm"].Expression = "Parent([r1]).DateConfirm";
			tTable.Columns.Add("OutputNote");
			tTable.Columns["OutputNote"].Expression = "Parent([r1]).Note";
			tTable.Columns.Add("CarAlias");
			tTable.Columns["CarAlias"].Expression = "Parent([r1]).CarAlias";
			tTable.Columns.Add("BackDoor", Type.GetType("System.Boolean"));
			tTable.Columns["BackDoor"].Expression = "Parent([r1]).BackDoor";
			tTable.Columns.Add("CarAliasFull");
			tTable.Columns["CarAliasFull"].Expression = "Parent([r1]).CarAliasFull";
			tTable.Columns.Add("ChargeOrder");
			tTable.Columns["ChargeOrder"].Expression = "Parent([r1]).ChargeOrder";
			tTable.Columns.Add("ExistsNewTrafficsGoods");
			tTable.Columns["ExistsNewTrafficsGoods"].Expression = "Parent([r1]).ExistsNewTrafficsGoods";
			tTable.Columns.Add("BarCode");
			tTable.Columns["BarCode"].Expression = "Parent([r1]).BarCode";
			tTable.Columns.Add("OutputBarCode");
			tTable.Columns["OutputBarCode"].Expression = "Parent([r1]).BarCode";
			tTable.Columns.Add("ErpCode");
			tTable.Columns["ErpCode"].Expression = "Parent([r1]).ErpCode";
			tTable.Columns.Add("OutputErpCode");
			tTable.Columns["OutputErpCode"].Expression = "Parent([r1]).ErpCode";

			tTable.Columns.Add("DateOutputText");
			tTable.Columns.Add("DateConfirmText");
			foreach (DataRow r in tTable.Rows)
			{
				r["DateOutputText"] = r["DateOutput"].ToString().Substring(0, 10);
				r["DateConfirmText"] = (Convert.IsDBNull(r["DateConfirm"])) ? "Не подтв." : "Подтв. " + r["DateConfirm"].ToString().Substring(0, 16);
			}

			tTable.Columns.Add("OutputSelectedInfo");
			tTable.Columns["OutputSelectedInfo"].Expression = "Parent([r1]).OutputSelectedInfo";
			tTable.Columns.Add("OutputTrafficsInfo");
			tTable.Columns["OutputTrafficsInfo"].Expression = "Parent([r1]).OutputTrafficsInfo";
		}

		#region ReportOutputQntDifferences

		private void mniPrintOutputReportQntDifferences_Click(object sender, EventArgs e)
		{
			string sOutputsList = "";
			RFMCursorWait.Set(true);
			foreach (DataRow r in oOutputList.MainTable.Rows)
				sOutputsList += r["ID"].ToString().Trim() + ",";
			sOutputsList = sOutputsList.Replace(",,", ","); 
			RFMCursorWait.Set(false);

            /*if (sOutputsList.Length > 0 &&
                RFMMessage.MessageBoxYesNo("В текущем спсике " + RFMUtilities.Declen(RFMUtilities.Occurs(sOutputsList, ","), "расход", "расхода", "расходов") + ".\n" +
                "Выполнить анализ несоответствий при сборе / подборе / отгрузке товаров?") == DialogResult.Yes)
            {
                StartForm(new frmReportOutputsQntDifferences(sOutputsList));
            }*/
            if (sOutputsList.Length > 0)
            {
                StartForm(new frmReportOutputsQntDifferences(sOutputsList));
            }
            else
            {
                RFMMessage.MessageBoxInfo("Таблица расходов пуста...");
            }
        }

		#endregion ReportOutputQntDifferences

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

		private void mniServiceOutputCellChange_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.CurrentRow == null)
				return;

			// перечитаем данные о текущем расходе
			int nOutputID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			oOutputCur.ClearError();
			oOutputCur.ID = nOutputID;
			oOutputCur.FillData();
			if (oOutputCur.ErrorNumber != 0)
				return;

			// проверки возможности смены ячейки
			if (oOutputCur.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Расход с кодом " + oOutputCur.ID.ToString() + " не найден...");
				return;
			}
			if (!Convert.IsDBNull(oOutputCur.MainTable.Rows[0]["DateConfirm"]))
			{
				RFMMessage.MessageBoxError("Расход с кодом " + oOutputCur.ID.ToString() + " уже подтвержден...");
				return;
			}

			oOutputCur.FillTableOutputsTraffics(nOutputID, true);
			if (oOutputCur.ErrorNumber != 0)
				return;
			if (oOutputCur.TableOutputsTrafficsFrames.Rows.Count > 0)
			{
				RFMMessage.MessageBoxError("Для расхода с кодом " + oOutputCur.ID.ToString() + " уже созданы операции транспортировки поддонов...");
				return;
			}

			oOutputCur.FillTableOutputsTraffics(nOutputID, false);
			if (oOutputCur.ErrorNumber != 0)
				return;
			if (oOutputCur.TableOutputsTrafficsGoods.Rows.Count > 0)
			{
				RFMMessage.MessageBoxError("Для расхода с кодом " + oOutputCur.ID.ToString() + " уже созданы операции перемещения коробок/штук...");
				return;
			}

			if (!Convert.IsDBNull(oOutputCur.MainTable.Rows[0]["DatePrint"]))
			{
				if (RFMMessage.MessageBoxYesNo("Внимание!\n\nДля расхода с кодом " + oOutputCur.ID.ToString() + " уже напечатан лист набора,\n" +
						"но операции транспортировки поддонов и перемещения штук/коробок отсутствуют.\n\n" +
						"Все-таки изменить ячейку набора?") != DialogResult.Yes)
					return;
			}

			if (!Convert.IsDBNull(oOutputCur.MainTable.Rows[0]["CellAddress"]))
			{
				if (RFMMessage.MessageBoxYesNo("Для расхода с кодом " + oOutputCur.ID.ToString() + " уже выбрана ячейка набора: " +
						oOutputCur.MainTable.Rows[0]["CellAddress"].ToString() + ".\n\n" +
						"Изменить ячейку набора?") != DialogResult.Yes)
					return;
			}

			// выбираем ячейку отгрузки
			int? nOutputCellID = null;
			Cell oCellOutput = new Cell();
			oCellOutput.FilterActual = true;
			oCellOutput.FilterLocked = false;
			oCellOutput.FilterStoreZoneTypeForOutputs = true;
			oCellOutput.FillData();
			if (oCellOutput.ErrorNumber != 0 || oCellOutput.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Ошибка получения данных о ячейках для отгрузки...");
				return;
			}

			// сколько есть ячеек отгрузки?
			if (oCellOutput.MainTable.Rows.Count == 1)
			{
				if (!Convert.IsDBNull(oOutputCur.MainTable.Rows[0]["CellID"]) &&
					Convert.ToInt32(oCellOutput.MainTable.Rows[0]["ID"]) ==
					Convert.ToInt32(oOutputCur.MainTable.Rows[0]["CellID"]))
				{
					RFMMessage.MessageBoxInfo("В системе имеется единственная ячейка отгрузки: " + oCellOutput.MainTable.Rows[0]["Address"].ToString() + ".\n" +
						"В расходе указана та же ячейка.\n" +
						"Изменение не требуется.");
					return;
				}

				if (RFMMessage.MessageBoxYesNo("В системе имеется единственная ячейка отгрузки: " + oCellOutput.MainTable.Rows[0]["Address"].ToString() + ".\n" +
						"Указать ее в качестве ячейки набора для расхода?") != DialogResult.Yes)
					return;
				else
				{
					nOutputCellID = Convert.ToInt32(oCellOutput.MainTable.Rows[0]["ID"]);
				}
			}
			else
			{
				if (!nOutputCellID.HasValue)
				{
					_SelectedID = null;
					// выбрать вручную из списка ячеек
					if (StartForm(new frmSelectID(this, oCellOutput.MainTable, "ID,Address,StoreZoneName,StoreZoneTypeName", "ID,Адрес,Зона,Тип зоны", false)) == DialogResult.Yes)
					{
						nOutputCellID = Convert.ToInt32(_SelectedID);
						_SelectedID = null;
					}
				}
			}

			if (nOutputCellID.HasValue)
			{
				oOutputCur.SetCell(nOutputID, (int)nOutputCellID);
				grdData_Restore();
			}
		}

		private void mniServiceOutputGoodFramesSelectManual_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.CurrentRow == null)
				return;

			if (tcOutputsGoods.SelectedTab.Name != "tabOutputsGoods" ||
				LastGrid.Name != "grdOutputsGoods")
			{
				RFMMessage.MessageBoxInfo("Ручной подбор паллет вызывается только для конкретного товара!");
				return;
			}

			if (grdOutputsGoods.CurrentRow == null)
				return;

			DataGridViewRow drO = grdData.CurrentRow;
			DataGridViewRow drOG = grdOutputsGoods.CurrentRow;
			if ((bool)drOG.Cells["grcIsExists"].Value == true)
			{
				Frame oFrame = new Frame();
				_SelectedIDList = null;
				oFrame.FramesContents_FilterPackingsList = drOG.Cells["grcPackingID"].Value.ToString();
				oFrame.FillTableFramesContents(null);
				for (Int16 i = 0; i < oFrame.TableFramesContents.Rows.Count; i++)
				{
					oFrame.TableFramesContents.Rows[i]["BoxQnt"] = decimal.Round((decimal)oFrame.TableFramesContents.Rows[i]["BoxQnt"], 1);
				}
				Setting oSet = new Setting();
				string sLostFoundAddress = oSet.FillVariable("sLostFoundAddress");
				DataView dvFramesContents = new DataView(oFrame.TableFramesContents);
				dvFramesContents.RowFilter = "FrameState = 'S'" +
						" and GoodStateID = " + drOG.Cells["grcGoodStateID"].Value.ToString() +
						" and Address <> '" + sLostFoundAddress + "'";
				if ((bool)drO.Cells["grcSeparatePicking"].Value)
					dvFramesContents.RowFilter = dvFramesContents.RowFilter + " and OwnerID = " +
							drO.Cells["grcOwnerID"].Value.ToString();
				else
					dvFramesContents.RowFilter = dvFramesContents.RowFilter + " and OwnerID is Null ";
				if (dvFramesContents.Count == 0)
				{
					RFMMessage.MessageBoxError("Не найдено подходящих паллет...");
					return;
				}

				if (StartForm(new frmSelectID(this, dvFramesContents.ToTable(),
												"FrameID,DateValid,BoxQnt,Qnt,Address",
												"Контейнер, Срок годности, Кор., Шт., Ячейка", true)) == DialogResult.Yes)
				{
					if (_SelectedIDList != null)
					{
						Output OutputCur = new Output();
						OutputCur.FramesSelectManual((int)drOG.Cells["grcOutputGoodID"].Value, _SelectedIDList);
						if (OutputCur.ErrorNumber == 0)
						{
							RFMMessage.MessageBoxInfo("Выполнен ручной подбор паллет.");
							grdOutputsGoods_Restore();
						}
					}
				}
			}
			else
			{
				RFMMessage.MessageBoxInfo("Не требуется ручной подбор паллет для данного товара...");
			}
			return;
		}

		private void mniServiceOutputSetDatePick_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.CurrentRow == null)
				return;
			if (grdData.CurrentRow.Cells["grcID"].Value == null)
				return;

			Output oOutput = new Output();
			oOutput.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			oOutput.FillData();
			if (oOutput.ErrorNumber != 0 || oOutput.MainTable == null || oOutput.MainTable.Rows.Count != 1)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о расходе...");
				return;
			}
			if (!Convert.IsDBNull(oOutput.MainTable.Rows[0]["DateConfirm"]))
			{
				RFMMessage.MessageBoxError("Расход уже подтвержден...");
				return;
			}

			// проверка выполнения всех трафиков 
			oOutput.FillTableOutputsTraffics((int)oOutput.ID, true);
			bool bTrafficsConfirmed = true;
			foreach (DataRow Row in oOutput.TableOutputsTrafficsFrames.Rows)
			{
				if (Convert.IsDBNull(Row["DateConfirm"]))
				{
					bTrafficsConfirmed = false;
					break;
				}
			}
			if (!bTrafficsConfirmed)
			{
				RFMMessage.MessageBoxError("Есть неподтвержденные операции транспортировки для расхода!\r\n" +
						"Операция невозможна...");
				return;
			}

			oOutput.FillTableOutputsTraffics((int)oOutput.ID, false);
			foreach (DataRow Row in oOutput.TableOutputsTrafficsGoods.Rows)
			{
				if (Convert.IsDBNull(Row["DateConfirm"]))
				{
					bTrafficsConfirmed = false;
					break;
				}
			}
			if (!bTrafficsConfirmed)
			{
				RFMMessage.MessageBoxError("Есть неподтвержденные операции перемещения коробок/штук для расхода!\r\n" +
						"Операция невозможна...");
				return;
			}
			// 

			if (RFMMessage.MessageBoxYesNo("Установить дату сбора/подбора товара?") != DialogResult.Yes)
				return;

			Refresh();

			oOutput.SetDatePick((int)oOutput.ID);
			if (oOutput.ErrorNumber == 0)
			{
				grdData_Restore();
				RFMMessage.MessageBoxInfo("Дата сбора/подбора товаров установлена.");
				grdData.Select();
			}
			return;
		}

		private void mniServiceOutputsClearIsSelecting_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.CurrentRow == null)
				return;
			if (grdData.CurrentRow.Cells["grcID"].Value == null)
				return;

			Output oOutput = new Output();
			oOutput.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			oOutput.FillData();
			if (oOutput.ErrorNumber != 0 || oOutput.MainTable == null || oOutput.MainTable.Rows.Count != 1)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о расходе...");
				return;
			}
			if (!Convert.ToBoolean(oOutput.MainTable.Rows[0]["IsSelecting"]))
			{
				RFMMessage.MessageBoxError("Признак \"в подборе\" не установлен...");
				return;
			}

			oOutput.ClearIsSelecting((int)oOutput.ID);
			if (oOutput.ErrorNumber == 0)
			{
				grdData_Restore();
				RFMMessage.MessageBoxInfo("Признак \"в подборе\" снят.");
				grdData.Select();
			}
			return;
		}

		private void mniServiceOutputTrafficsFramesConfirm_Click(object sender, EventArgs e)
		{
			if (grdData.CurrentRow == null)
				return;

			oOutputCur.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			if (StartForm(new frmOutputsFramesConfirm((int)oOutputCur.ID)) == DialogResult.Yes)
			{
				grdData_Restore();
				tcOutputsGoods.SetAllNeedRestore(true);
			}
		}

		private void mniServiceOutputsLoaders_Click(object sender, EventArgs e)
		{
			if (grdData.CurrentRow == null)
				return;

			oOutputCur.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			if (StartForm(new frmOutputsLoaders((int)oOutputCur.ID)) == DialogResult.Yes)
			{
				grdData_Restore();
			}
		}

		private void mniServiceOutputsTrafficsGoodsChangeUsers_Click(object sender, EventArgs e)
		{
			if (grdData.DataSource == null || grdData.Rows.Count == 0 || grdData.CurrentRow == null)
				return;

			oOutputCur.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			// список перемещений коробок/штук
			TrafficGood oTrafficGoodTemp = new TrafficGood();
			oTrafficGoodTemp.FilterOutputsList = oOutputCur.ID.ToString();
			oTrafficGoodTemp.FillData();
			if (oTrafficGoodTemp.ErrorNumber != 0 || oTrafficGoodTemp.MainTable == null)
				return;
			if (oTrafficGoodTemp.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Для текущего расхода нет перемещений коробок/штук...");
				return; 
			}
			// список "старых" пользователей
			DataTable tOldUsers = new DataTable();
			tOldUsers.Columns.Add("ID", Type.GetType("System.Int32"));
			tOldUsers.Columns.Add("UserName"); 
			DataColumn[] pk = new DataColumn[1];
			pk[0] = tOldUsers.Columns[0];
			tOldUsers.PrimaryKey = pk;

			foreach (DataRow tr in oTrafficGoodTemp.MainTable.Rows)
			{
				if (!Convert.IsDBNull(tr["UserID"]))
				{ 
					if (tOldUsers.Rows.Find(Convert.ToInt32(tr["UserID"])) == null)
					{
						tOldUsers.Rows.Add(Convert.ToInt32(tr["UserID"]), tr["UserName"].ToString());
					}
				}
			}
			if (tOldUsers.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Нет данных о сотрудниках в перемещениях коробок/штук для текущего расхода...");
				return; 
			}

			// выбрать, кого нужно заменить 
			int nOldUserID = 0;
			string sOldUserName = "";
			_SelectedID = null;
			if (StartForm(new frmSelectID(this, tOldUsers, "UserName", "Сотрудник (перемещение)", "Кого заменяем?")) == DialogResult.Yes)
			{
				if (_SelectedID.HasValue)
				{
					nOldUserID = (int)_SelectedID;
					sOldUserName = _SelectedText;
				}
			}
			if (nOldUserID == 0)
				return; 

			// список новых сотрудников 
			User oUser = new User();
			oUser.FillData();
			if (oUser.ErrorNumber != 0 || oUser.MainTable == null)
				return;
			if (oUser.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Нет данных о сотрудниках...");
				return; 
			}

			int nNewUserID = 0;
			string sNewUserName = "";
			_SelectedID = null;
			if (StartForm(new frmSelectID(this, oUser.MainTable, "Name", "Сотрудник (замена)", "На кого заменяем?")) == DialogResult.Yes)
			{
				if (_SelectedID.HasValue)
				{
					nNewUserID = (int)_SelectedID;
					sNewUserName = _SelectedText;
				}
			}
			if (nNewUserID == 0)
				return;

			DataView dv = new DataView(oTrafficGoodTemp.MainTable, "UserID = " + nOldUserID.ToString(), "", DataViewRowState.CurrentRows);
			if (RFMMessage.MessageBoxYesNo("Выполнить замену данных о сотрудниках в перемещениях коробок/штук для текущего расхода:\n" + 
				"сотрудник " + sOldUserName + " меняется на сотрудника " + sNewUserName +
				" (" + RFMUtilities.Declen(dv.Count, "операция", "операции", "операций") + ")?") == DialogResult.Yes)
			{
				DataTable dt = dv.ToTable();
				foreach (DataRow dr in dt.Rows)
				{
					oTrafficGoodTemp.UserChange(Convert.ToInt32(dr["ID"]), nNewUserID);
				}
				grdData_Restore();
			}
		}

		#endregion


		#region Menu Select

		private void btnSelect_Click(object sender, EventArgs e)
		{
			mnuSelect.Show(btnSelect, new Point());
		}

		private void mniSelectCur_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.CurrentRow == null)
				return;
			if (grdData.Rows.Count == 0)
				return;
			if (grdData.IsStatusRow(grdData.CurrentRow.Index))
				return;

			// подбор товаров - для одного расхода 

			int nOutputID = 0;
			nOutputID = (int)grdData.CurrentRow.Cells["grcID"].Value;

			int? nOutputCellID = null;

			int nOldCntSelected = 0;
			decimal nOldQntSelected = 0;
			int nOldCntFullSelected = 0;
			//int nOldAllFullSelected = 0;
			int nNewCntSelected = 0;
			decimal nNewQntSelected = 0;
			int nNewCntFullSelected = 0;
			//int nNewAllFullSelected = 0;

			oOutputCur.ClearError();
			oOutputCur.ID = nOutputID;
			oOutputCur.FillData();
			if (oOutputCur.ErrorNumber != 0 || oOutputCur.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Ошибка получения данных о расходе...");
				return;
			}

			// подтвержден?
			if (!Convert.IsDBNull(oOutputCur.MainTable.Rows[0]["DateConfirm"]))
			{
				RFMMessage.MessageBoxError("Расход уже подтвержден...");
				return;
			}

			// проверка ячейки
			//if (Convert.IsDBNull(oOutputCur.MainTable.Rows[0]["CellID"]))
			//{
			//   nOutputCellID = SelectOutputCell(nOutputID);
			//   if (!nOutputCellID.HasValue)
			//   {
			//      RFMMessage.MessageBoxError("Не определена ячейка отгрузки...\nВыполнение операции подбора невозможно...");
			//      return;
			//   }
			//}
			//else
			//{
			//   nOutputCellID = Convert.ToInt32(oOutputCur.MainTable.Rows[0]["CellID"]);
			//}
			if (Convert.IsDBNull(oOutputCur.MainTable.Rows[0]["CellID"]))
			{
				if (oOutputCur.SelectOutCell(nOutputID) != 0)
				{
					RFMMessage.MessageBoxInfo("Не удалось автоматически подобрать ячейку отгрузки");
					return;
				}	
			}
			if (RFMMessage.MessageBoxYesNo("Выполнить подбор товаров и\n" +
				"создать необходимые операции транспортировки поддонов и перемещения коробок/штук?") == DialogResult.Yes)
			{
				Refresh();
				WaitOn(this);
				// было подобрано
				oOutputCur.FillTableOutputsGoods((int)oOutputCur.ID);
				foreach (DataRow rog in oOutputCur.TableOutputsGoods.Rows)
				{
					decimal nQntSelected = Convert.ToDecimal(rog["QntSelected"]);
					if (nQntSelected > 0)
					{
						nOldCntSelected++;
						nOldQntSelected = nOldQntSelected + nQntSelected;
						if (nQntSelected >= Convert.ToDecimal(rog["QntWished"]))
						{
							nOldCntFullSelected++;
						}
					}
				}
				if (nOldCntFullSelected == oOutputCur.TableOutputsGoods.Rows.Count)
				{
					WaitOff(this);
					RFMMessage.MessageBoxInfo("Подбор товаров уже выполнен.\nВсе товары подобраны полностью.");
					return;
				}

				// собственно подбор
				bool bResult = oOutputCur.SelectData(nOutputID, nOutputCellID);
				WaitOff(this);
				if (bResult && oOutputCur.ErrorNumber == 0)
				{
					// стало подобрано
					oOutputCur.FillTableOutputsGoods((int)oOutputCur.ID);
					foreach (DataRow rog in oOutputCur.TableOutputsGoods.Rows)
					{
						decimal nQntSelected = Convert.ToDecimal(rog["QntSelected"]);
						if (nQntSelected > 0)
						{
							nNewCntSelected++;
							nNewQntSelected = nNewQntSelected + nQntSelected;
							if (nQntSelected >= Convert.ToDecimal(rog["QntWished"]))
							{
								nNewCntFullSelected++;
							}
						}
					}

					bool bSaid = false;
					if (!bSaid && nNewCntFullSelected == oOutputCur.TableOutputsGoods.Rows.Count)
					{
						RFMMessage.MessageBoxInfo("Подбор товаров выполнен.\nВсе товары подобраны полностью.");
						bSaid = true;
					}
					if (!bSaid && nNewCntSelected == nOldCntSelected)
					{
						RFMMessage.MessageBoxAttention("Подбор товаров выполнен,\nно не удалось подобрать ни одного товара.");
						bSaid = true;
					}
					if (!bSaid && nNewQntSelected > nOldQntSelected && nNewCntFullSelected < oOutputCur.TableOutputsGoods.Rows.Count)
					{
						RFMMessage.MessageBoxAttention("Подбор товаров выполнен,\nно не удалось подобрать часть товаров.");
						bSaid = true;
					}
					if (!bSaid)
					{
						RFMMessage.MessageBoxInfo("Подбор товаров выполнен.");
						bSaid = true;
					}

					// печать пик-листа
					if (RFMMessage.MessageBoxYesNo("Печатать лист заданий на перемещение коробок/штук?") == DialogResult.Yes)
					{
						mniPrintTrafficsGoodsList_Click(mniPrintTrafficsGoodsList, null);
					}

					grdData_Restore();
					tcOutputsGoods.SetAllNeedRestore(true);
				}
				else
				{
					RFMMessage.MessageBoxError("Ошибка выполнения операции подбора товаров...");
				}
			}
		}

		private void mniSelectMarked_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.Rows.Count == 0)
				return;

			// подбор товаров - для всех отмеченных записей 

			int nMarkedCnt = CalcMarkedRows();
			if (nMarkedCnt > 0)
			{
				if (RFMMessage.MessageBoxYesNo("Отмечено записей: " + nMarkedCnt.ToString() + "\n\n" +
						"Выполнить подбор товаров и\n" +
						"создать необходимые операции транспортировки поддонов и перемещения коробок/штук\n" +
						"для всех отмеченных расходов?") != DialogResult.Yes)
					return;
				Refresh();

				Output oOutputSelect = new Output();
				OutputNotConfirmedPrepareIDList(oOutputSelect, nMarkedCnt > 0);
				if (oOutputSelect.IDList == null || oOutputSelect.IDList.Length == 0)
				{
					RFMMessage.MessageBoxError("Нет отмеченных неподтвержденных записей...");
					return;
				}

				OutputsSelect(oOutputSelect, true);
			}
			else
			{
				RFMMessage.MessageBoxError("Нет отмеченных записей...");
				return;
			}
		}

		private void mniSelectAll_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			RFMCursorWait.Set(true);

			Output oOutputSelect = new Output();

			foreach (DataGridViewRow gr in grdData.Rows)
			{
				DataRow r = ((DataRowView)gr.DataBoundItem).Row;

				if (Convert.IsDBNull(r["DateConfirm"]) /*&&
					(Convert.IsDBNull(r["OutputSelectedInfo"]) ||
					 Convert.ToInt32(r["OutputSelectedInfo"]) < 2)*/
																					)
				{
					oOutputSelect.IDList += r["ID"] + ",";
				}
			}
			if (oOutputSelect.IDList == null || oOutputSelect.IDList.Length == 0)
			{
				RFMCursorWait.Set(false);
				RFMMessage.MessageBoxError("Нет расходов, для которых требуется подбор товаров...");
				return;
			}

			RFMCursorWait.Set(false);

			OutputsSelect(oOutputSelect, false);
		}

		private void OutputsSelect(Output oOutputSelect, bool bIsMarked)
		{
			string sAll = (bIsMarked) ? "об отмеченных расходах" : "о расходах, для которых требуется подбор товаров";

			WaitOn(this);

			oOutputSelect.FillData();
			if (oOutputSelect.ErrorNumber != 0 || oOutputSelect.MainTable.Rows.Count == 0)
			{
				WaitOff(this);
				RFMMessage.MessageBoxError("Ошибка получения данных " + sAll + "...");
				return;
			}
			WaitOff(this);

			int nCnt = oOutputSelect.MainTable.Rows.Count;
			if (RFMMessage.MessageBoxYesNo("Начать подбор товаров для " + RFMUtilities.Declen(nCnt, "расхода", "расходов", "расходов") + "?") != DialogResult.Yes)
				return;

			Refresh();

			int nOutputID = 0;
			int? nOutputCellID = null;
											// до подбора
			int nOldCntSelected = 0;		// строк хоть как-то подобранных 
			decimal nOldQntSelected = 0;	// штук 
			int nOldCntFullSelected = 0;	// строк полностью подобранных
			int nOldAllFullSelected = 0;	// заказов полностью подобранных
											// после подбора
			int nNewCntSelected = 0;		// строк хоть как-то подобранных 
			decimal nNewQntSelected = 0;	// штук 
			int nNewCntFullSelected = 0;	// строк полностью подобранных
			int nNewAllFullSelected = 0;	// заказов полностью подобранных
			int nUnSelectingCellsCount = 0; //  кол-во расжодов с неопределноой ячейкой отгрузки
			string sOutputsListForPrint = "";

			// для каждой записи 
			int nCount = 0;
			int nCountAll = 0;
			bool bForSelecting = false;

			oOutputSelect.MainTable.DefaultView.Sort = "PalletsQnt desc";

			foreach (DataRow dr in oOutputSelect.MainTable.Rows)
			{
				nOutputID = Convert.ToInt32(dr["ID"]);
				if (Convert.IsDBNull(dr["CellID"]) && Convert.IsDBNull(dr["DateConfirm"]))
				{
					nCount = oOutputSelect.SelectOutCell(nOutputID);
					nCountAll ++;
					if (nCount < 0)
						return;
					else
						nUnSelectingCellsCount += nCount;	
				}
				else
				{
					if (!bForSelecting)
						bForSelecting = true;
				}	
			}
			if (!bForSelecting && (nCountAll == nUnSelectingCellsCount))
			{
				RFMMessage.MessageBoxInfo("Ни для одного из указанных расходов невозможно автоматически подобрать отгрузки...");
				return;
			}	
			if (nUnSelectingCellsCount > 0 && RFMMessage.MessageBoxYesNo("Для " + RFMUtilities.Declen(nUnSelectingCellsCount, 
						"расхода", "расходов", "расходов") + " не подобрана ячейка отгрузки. \r\nПродолжить подбор товара?") == DialogResult.No)
					return;		
			// начинаем подбор - для каждой записи

			int i = 0;
			ProgressOpen(this, nCnt);

			Output oOutputSelectOne = new Output();
			foreach (DataRow r in oOutputSelect.MainTable.Rows)
			{
				nOutputID = Convert.ToInt32(r["ID"]);

				oOutputSelectOne.ClearError();
				oOutputSelectOne.ID = nOutputID;
				oOutputSelectOne.FillData();
				DataRow ro = oOutputSelectOne.MainTable.Rows[0];

				// подтвержден?
				if (!Convert.IsDBNull(ro["DateConfirm"]))
				{
					nOldAllFullSelected++;
					nNewAllFullSelected++;

					ProgressRefresh(this);
					continue;
				}

				// проверка ячейки отгрузки 
				//	nOutputCellID = null;
				//if (Convert.IsDBNull(ro["CellID"]))
				//{
				//   nOutputCellID = SelectOutputCell(nOutputID);
				//   if (!nOutputCellID.HasValue)
				//   {
				//      // не смогли выбрать ячейку отгрузки 
				//      RFMMessage.MessageBoxError("Не определена ячейка отгрузки для расхода с кодом " + nOutputID.ToString() + "...\n" +
				//         "Выполнение операции подбора для этого расхода невозможно...");
				//      ProgressRefresh(this);
				//      continue;
				//   }
				//}
				//else
				//{
				//   nOutputCellID = Convert.ToInt32(ro["CellID"]);
				//}
				// было подобрано товаров - в этом расходе 
				nOldCntFullSelected = 0;
				oOutputSelectOne.FillTableOutputsGoods(nOutputID);
				foreach (DataRow rog in oOutputSelectOne.TableOutputsGoods.Rows)
				{
					decimal nQntSelected = Convert.ToDecimal(rog["QntSelected"]);
					if (nQntSelected > 0)
					{
						nOldCntSelected++;
						nOldQntSelected = nOldQntSelected + nQntSelected;
						if (nQntSelected >= Convert.ToDecimal(rog["QntWished"]))
						{
							nOldCntFullSelected++;
						}
					}
				}
				if (nOldCntFullSelected == oOutputSelectOne.TableOutputsGoods.Rows.Count)
				{
					// уже все подобрано 
					nOldAllFullSelected++;
					//RFMMessage.MessageBoxInfo("Подбор товаров уже выполнен.\nВсе товары подобраны полностью.");
					continue;
				}

				// собственно подбор
				bool bResult = oOutputSelectOne.SelectData(nOutputID, nOutputCellID);
				if (bResult && oOutputSelectOne.ErrorNumber == 0)
				{
					// стало подобрано
					nNewCntFullSelected = 0;
					oOutputSelectOne.FillTableOutputsGoods(nOutputID);
					foreach (DataRow rog in oOutputSelectOne.TableOutputsGoods.Rows)
					{
						decimal nQntSelected = Convert.ToDecimal(rog["QntSelected"]);
						if (nQntSelected > 0)
						{
							nNewCntSelected++;
							nNewQntSelected = nNewQntSelected + nQntSelected;
							if (nQntSelected >= Convert.ToDecimal(rog["QntWished"]))
							{
								nNewCntFullSelected++;
							}
						}
					}
					if (nNewCntFullSelected == oOutputSelectOne.TableOutputsGoods.Rows.Count)
					{
						// стало все подобрано 
						nNewAllFullSelected++;
					}
				}
				else
				{
					RFMMessage.MessageBoxError("Ошибка выполнения операции подбора товаров для расхода с кодом " + nOutputID.ToString() + "...");
					ProgressRefresh(this);
				}

				sOutputsListForPrint += nOutputID.ToString().Trim() + ",";

				i++;
				ProgressShell(this, i);
			}
			ProgressClose(this);
			// прошли все отмеченные накладные. скажем результат 

			WaitOff(this);
			bool bSaid = false;
			string sAllYx = (bIsMarked) ? "отмеченных " : "";
			string sAllYm = (bIsMarked) ? "отмеченным " : "";
			if (!bSaid && nOldAllFullSelected == oOutputSelect.MainTable.Rows.Count)
			{
				RFMMessage.MessageBoxInfo("Подбор товаров для всех " + sAllYx + "расходов уже выполнен.\n" +
					"Все товары по всем " + sAllYm + "расходам подобраны полностью.");
				bSaid = true;
			}
			if (!bSaid && nNewAllFullSelected == oOutputSelect.MainTable.Rows.Count)
			{
				RFMMessage.MessageBoxInfo("Подбор товаров для всех " + sAllYx + "расходов выполнен.\n" +
					"Все товары по всем " + sAllYm + "расходам подобраны полностью.");
				bSaid = true;
			}
			if (!bSaid && nNewCntSelected == nOldCntSelected)
			{
				RFMMessage.MessageBoxAttention("Подбор товаров для всех " + sAllYx + "расходов выполнен,\n" +
					"но не удалось подобрать ни одного товара.");
				bSaid = true;
			}
			if (!bSaid && nNewQntSelected > nOldQntSelected && nNewAllFullSelected < oOutputSelect.MainTable.Rows.Count)
			{
				RFMMessage.MessageBoxAttention("Подбор товаров для всех " + sAllYx + "расходов выполнен,\n" +
					"но не удалось подобрать часть товаров.");
				bSaid = true;
			}
			if (!bSaid)
			{
				RFMMessage.MessageBoxInfo("Подбор товаров для всех " + sAllYx + "расходов выполнен.");
				bSaid = true;
			}

			// печать пик-листа
			if (RFMMessage.MessageBoxYesNo("Печатать лист заданий на перемещение коробок/штук?") == DialogResult.Yes)
			{
				Output oOutputPrint = new Output();
				oOutputPrint.IDList = sOutputsListForPrint;

				TrafficGood oTrafficGoodPrint = new TrafficGood();
				oTrafficGoodPrint.FilterOutputsList = oOutputPrint.IDList;

				_PrintTrafficsGoodsList(oOutputPrint, null);
			}

			grdData_Restore();
			tcOutputsGoods.SetAllNeedRestore(true);
		}

		private int? SelectOutputCell(int nOutputID)
		{
			int? nCellOutputID = null;
			Cell oCellOutput = new Cell();
			oCellOutput.FilterActual = true;
			oCellOutput.FilterLocked = false;
			oCellOutput.FilterStoreZoneTypeForOutputs = true;
			oCellOutput.FillData();
			if (oCellOutput.ErrorNumber != 0 || oCellOutput.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Ошибка получения данных о ячейках отгрузки...");
				return (null);
			}

			// сколько есть ячеек отгрузки?
			if (oCellOutput.MainTable.Rows.Count == 1)
			{
				// одна 
				nCellOutputID = Convert.ToInt32(oCellOutput.MainTable.Rows[0]["ID"]);
			}
			else
			{
				// несколько 
				// сначала: поискать ячейку в типе расхода 
				Output oOutputTemp = new Output();
				oOutputTemp.ID = nOutputID;
				oOutputTemp.FillData();
				if (oOutputTemp.ErrorNumber != 0 || oOutputTemp.MainTable.Rows.Count != 1)
					return (null);

				int nOutputTypeID = Convert.ToInt32(oOutputTemp.MainTable.Rows[0]["OutputTypeID"]);
				oOutputTemp.FillTableOutputsTypes();
				foreach (DataRow rot in oOutputTemp.TableOutputsTypes.Rows)
				{
					if (Convert.ToInt32(rot["ID"]) == nOutputTypeID)
					{
						if (!Convert.IsDBNull(rot["CellID"]))
						{
							nCellOutputID = Convert.ToInt32(rot["CellID"]);
						}
						break;
					}
				}
				if (nCellOutputID.HasValue)
				{
					// проверим наличие и пригодность этой ячейки для расхода
					Cell oCellTemp = new Cell();
					oCellTemp.ID = nCellOutputID;
					oCellTemp.FillData();
					if (oCellTemp.ErrorNumber != 0 || oCellTemp.MainTable.Rows.Count == 0)
					{
						nCellOutputID = null;
					}
					else
					{
						DataRow r = oCellTemp.MainTable.Rows[0];
						if (!Convert.ToBoolean(r["ForOutputs"]) ||
							!Convert.ToBoolean(r["Actual"]) ||
							Convert.ToBoolean(r["Locked"]))
						{
							nCellOutputID = null;
						}
					}
				}

				if (!nCellOutputID.HasValue)
				{
					// выбрать вручную из списка ячеек
					_SelectedID = null;
					if (StartForm(new frmSelectID(this, oCellOutput.MainTable, "ID,Address,StoreZoneName,StoreZoneTypeName", "ID,Адрес,Зона,Тип зоны", false)) == DialogResult.Yes)
					{
						nCellOutputID = Convert.ToInt32(_SelectedID);
						_SelectedID = null;
					}
				}
			}

			return (nCellOutputID);
		}

		private void mniSelectPalletByDateValid_Click(object sender, EventArgs e)
		{
			// ручной подбор паллет для товара, например, по сроку годности
			if (grdData.Rows.Count == 0 || grdData.CurrentRow == null || !oOutputCur.ID.HasValue || 
				grdOutputsGoods.Rows.Count == 0 || grdOutputsGoods.CurrentRow == null)
				return;
			if (LastGrid.Name != "grdOutputsGoods")
			{
				RFMMessage.MessageBoxError("Для подбора контейнеров следует перейти в нижнюю таблицу товаров в расходе.");
				return;
			}

			// сам расход
			int nOutputID = (int)oOutputCur.ID;
			Output oOutputSelect = new Output();
			oOutputSelect.ID = nOutputID;
			if (!oOutputSelect.FillData() || oOutputSelect.MainTable == null || oOutputSelect.MainTable.Rows.Count != 1)
				return;
			DataRow rO = oOutputSelect.MainTable.Rows[0];
			if (!Convert.IsDBNull(rO["DateConfirm"]))
			{
				RFMMessage.MessageBoxError("Расход уже подтвержден!");
				return;
			}
			// ячейка отгрузки
			if (Convert.IsDBNull(rO["CellID"]))
			{
				if (oOutputSelect.SelectOutCell(nOutputID) != 0)
				{
					// нет вообще или не одна - выбираем ячейку отгрузки вручную
					int? nOutputCellID = null;
					Cell oCellOutput = new Cell();
					oCellOutput.FilterActual = true;
					oCellOutput.FilterLocked = false;
					oCellOutput.FilterStoreZoneTypeForOutputs = true;
					oCellOutput.FillData();
					if (oCellOutput.ErrorNumber != 0 || 
						oCellOutput.MainTable == null || oCellOutput.MainTable.Rows.Count == 0)
					{
						RFMMessage.MessageBoxError("Ошибка получения данных о ячейках отгрузки...");
						return;
					}
					// сколько есть ячеек отгрузки?
					if (oCellOutput.MainTable.Rows.Count == 1)
					{
						nOutputCellID = Convert.ToInt32(oCellOutput.MainTable.Rows[0]["ID"]);
					}
					else
					{
						_SelectedID = null;
						// выбрать вручную из списка ячеек
						if (StartForm(new frmSelectID(this, oCellOutput.MainTable, "ID,Address,StoreZoneName,StoreZoneTypeName", "ID,Адрес,Зона,Тип зоны", false)) == DialogResult.Yes)
						{
							nOutputCellID = Convert.ToInt32(_SelectedID);
							_SelectedID = null;
						}
					}
					if (nOutputCellID.HasValue)
					{
						oOutputCur.SetCell(nOutputID, (int)nOutputCellID);
					}
					else
					{
						RFMMessage.MessageBoxError("Не выбрана ячейка отгрузки для расхода...");
						return;
					}
				}
				oOutputSelect.FillData();
				rO = oOutputSelect.MainTable.Rows[0];
			}

			// товар в расходе
			DataRow rOG = ((DataRowView)grdOutputsGoods.CurrentRow.DataBoundItem).Row;
			int nOutputGoodID = Convert.ToInt32(rOG["ID"]);
			// уже выдан
			if (Convert.ToDecimal(rOG["QntConfirmed"]) > 0)
			{
				RFMMessage.MessageBoxError("Товар уже выдан!");
				return;
			}
			decimal nQntWished = Convert.ToDecimal(rOG["QntWished"]), 
					nQntSelected = Convert.ToDecimal(rOG["QntSelected"]), 
					nQntPicked = Convert.ToDecimal(rOG["QntPicked"]); 
			if (nQntPicked >= nQntWished)
			{
				RFMMessage.MessageBoxError("Товар уже собран в ячейке отгрузки!");
				return;
			}
			if (nQntSelected >= nQntWished)
			{
				RFMMessage.MessageBoxError("Товар уже подобран!");
				return;
			}

			// вот столько нужно товара, в т.ч. в паллетах
			decimal nQntNeed = nQntWished - nQntSelected;
			decimal nBoxNeed = nQntNeed / Convert.ToDecimal(rOG["InBox"]);
			decimal nPalNeed = nBoxNeed / Convert.ToDecimal(rOG["BoxInPal"]);
			if (nPalNeed < 1)
			{
				if (RFMMessage.MessageBoxYesNo("Требуемое количество товара - меньше паллеты.\n" +
					"Все-таки выполнить подбор целой паллеты из высотной зоны?") != DialogResult.Yes)
					return;
			}
			bool bIsWeight = Convert.ToBoolean(rOG["Weighting"]);

			// выбираем паллеты
			RFMCursorWait.Set(true);

			bool bSeparatePicking = Convert.ToBoolean(rO["SeparatePicking"]);
			Frame oFrame = new Frame();
			oFrame.FilterActual = true;
			oFrame.FilterFramesStatesStr = "S";
			oFrame.FilterGoodsStatesList = rOG["GoodStateID"].ToString();
			oFrame.FilterLocked = false;
			if (bSeparatePicking)
				oFrame.FilterOwnersList = rO["OwnerID"].ToString();
			else
				oFrame.FilterOwnersList = null;
			oFrame.FramesContents_FilterPackingsList = rOG["PackingID"].ToString();
			if (!oFrame.FillData() || oFrame.ErrorNumber != 0 || oFrame.MainTable == null)
			{
				RFMCursorWait.Set(false);
				RFMMessage.MessageBoxError("Ошибка при получении данных о контейнерах с нужным товаром...");
				return;
			}
			if (oFrame.MainTable.Rows.Count == 0)
			{
				RFMCursorWait.Set(false);
				RFMMessage.MessageBoxError("Нет контейнеров с нужным товаром...");
				return;
			}

			Cell oCellForFrame = new Cell();
			// собираем список контейнеров и их содержимого
			oFrame.FillTableFramesContents(-1);
			DataTable dtFramesContents = oFrame.TableFramesContents.Copy();
			dtFramesContents.Columns.Add("StoreZoneName");
			dtFramesContents.Columns.Add("StoreZoneTypeName");
			dtFramesContents.Columns.Add("IsRill", Type.GetType("System.Boolean"));
			dtFramesContents.Columns.Add("QntInTrafficsGoods", Type.GetType("System.Decimal"));
			foreach (DataRow rF in oFrame.MainTable.Rows)
			{
				if (oFrame.FillTableFramesContents((int)rF["ID"]) &&
					oFrame.TableFramesContents != null && oFrame.TableFramesContents.Rows.Count > 0)
				{
					foreach (DataRow rFC in oFrame.TableFramesContents.Rows)
					{
						if (Convert.ToInt32(rFC["PackingID"]) == Convert.ToInt32(rOG["PackingID"]) &&
							(bSeparatePicking && Convert.ToInt32(rFC["OwnerID"]) == Convert.ToInt32(rO["OwnerID"])
							||
							 !bSeparatePicking && Convert.IsDBNull(rFC["OwnerID"])
							) &&
							!Convert.IsDBNull(rFC["CellID"]))
						{
							// только из ячеек высотки
							oCellForFrame.ID = Convert.ToInt32(rFC["CellID"]);
							if (oCellForFrame.FillData() &&
								oCellForFrame.MainTable != null && oCellForFrame.MainTable.Rows.Count == 1)
							{
								DataRow rCFF = oCellForFrame.MainTable.Rows[0];
								if (Convert.ToBoolean(rCFF["ForStorage"]) &&
									Convert.ToBoolean(rCFF["Actual"]) &&
									!Convert.ToBoolean(rCFF["Locked"]))
								{
									DataTable dtTemp = CopyTable(oFrame.TableFramesContents, "dtTemp", "ID = " + rFC["ID"].ToString(), "");
									dtFramesContents.Merge(dtTemp);
									DataRow drFCCurrent = dtFramesContents.Rows[dtFramesContents.Rows.Count - 1];
									drFCCurrent["StoreZoneName"] = rCFF["StoreZoneName"].ToString();
									drFCCurrent["StoreZoneTypeName"] = rCFF["StoreZoneTypeName"].ToString();
									drFCCurrent["IsRill"] = rCFF["StoreZoneTypeShortCode"].ToString().ToUpper().Contains("RILL");
									drFCCurrent["QntInTrafficsGoods"] = rF["QntInTrafficsGoods"];
								}
							}
						}
					}
				}
			}
			if (dtFramesContents.Rows.Count == 0)
			{
				RFMCursorWait.Set(false);
				RFMMessage.MessageBoxError("В ячейках хранения нет контейнеров с нужным товаром...");
				return;
			}
			DataTable dtFramesContentsX = CopyTable(dtFramesContents, "dtFramesContentsX", "", "DateValid, Address, ByOrder");
			RFMCursorWait.Set(false);

			if (StartForm(new frmOutputsFramesSelect(oOutputSelect, nOutputGoodID, dtFramesContents)) == DialogResult.Yes)
				grdData_Restore();
		}

		#endregion Menu Select


		#region Form keys

		private void frmOutputs_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F1:
					btnHelp_Click(null, null);
					break;
				case Keys.B:
					if (tcList.CurrentPage.Name.ToUpper().Contains("DATA") &&
						grdData.Rows.Count > 0 &&
						btnBarCodeFind.Enabled)
					{
						if (e.Modifiers == Keys.Control)
						{
							btnBarCodeFind_Click(null, null);
						}
					}
					break;
			}
		}

		#endregion Form keys


		#region Terms clear

		private void btnClearTerms_Click(object sender, EventArgs e)
		{
			txtBarCode.Text = "";

			dtrDates.dtpBegDate.Value = DateTime.Now.AddDays(-1).Date;
			dtrDates.dtpEndDate.Value = DateTime.Now.AddDays(1).Date;

			dtrDatesConfirm.dtpBegDate.Value = DateTime.Now.AddDays(-1).Date;
			dtrDatesConfirm.dtpEndDate.Value = DateTime.Now.Date;
			dtrDatesConfirm.dtpBegDate.HideControl(false);
			dtrDatesConfirm.dtpEndDate.HideControl(false);

			txtCarAliasContext.Text = "";
			btnCarsClear_Click(null, null);
			optBackDoorAny.Checked = true;

			optAllPicked.Checked = true;
			//optAllConfirmed.Checked = true;
			optIsNotConfirmed.Checked = true;
			optIsConfirmed_CheckedChanged(null, null);
			optSelectedInfoAny.Checked = true;
			optSelectedInfoAny_CheckedChanged(null, null);
			optTrafficsInfoAny.Checked = true;

			btnOutputsTypesClear_Click(null, null);
			btnGoodsStatesClear_Click(null, null);
			txtPartnerNameContext.Text = "";
			btnPartnersClear_Click(null, null);
			btnOwnersClear_Click(null, null);

			btnPackingsClear_Click(null, null);

			ucSelectRecordID_Hosts.ClearData();

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