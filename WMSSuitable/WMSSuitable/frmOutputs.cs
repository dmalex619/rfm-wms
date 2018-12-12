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
		private Output oOutputList; //������ ��������
		private Output oOutputCur; //������� ������

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

			// ���� �������
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
			btnAdd.Enabled = // �� ���.
			btnEdit.Enabled = // �� ���. 
			btnConfirm.Enabled =
			btnConfirmGoods.Enabled =
			btnSelect.Enabled =
			btnDelete.Enabled = // �� ���.
			btnPrint.Enabled =
			btnService.Enabled = false;
			return (true);
		}

		private bool tabData_Restore()
		{
			grdData_Restore();
			btnAdd.Enabled =
			btnEdit.Enabled =
			btnDelete.Enabled = false; // �� ���.
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
				btnAdd.Enabled = // �� ���.
				btnEdit.Enabled = // �� ���. 
				btnConfirm.Enabled =
				btnConfirmGoods.Enabled =
				btnSelect.Enabled =
				btnDelete.Enabled = // �� ���.
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
				RFMMessage.MessageBoxError("������ ��� ��������� ������ � �������...");
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
				if (RFMMessage.MessageBoxYesNo("��� �� ������ ������������ ������!\r\n" +
						"���-���� ��������� ������������� �������?") != DialogResult.Yes)
					return;
			}

			// �������� ���������� ���� �������� 
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
				RFMMessage.MessageBoxError("���� ���������������� �������� ��������������� ��� �������!\r\n" +
						"������������� ������� ����������...");
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
				RFMMessage.MessageBoxError("���� ���������������� �������� ����������� �������/���� ��� �������!\r\n" +
						"������������� ������� ����������...");
				return;
			}

			if (StartForm(new frmOutputsConfirm((int)oOutputCur.ID)) == DialogResult.Yes)
			{
				// ������ ������ � ����������� ������
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
			if (StartForm(new frmInputBoxBarCode("�����-��� �������:", "")) == DialogResult.Yes)
			{
				Refresh();
				string sBarCode = GotParam[0].ToString();
				if (sBarCode.Length > 0)
				{
					int nPosition = grdData.GridSource.Find("BarCode", sBarCode);
					if (nPosition < 0)
					{
						RFMMessage.MessageBoxError("�� �������...");
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

			// �������� �������

			// �����-���
			if (txtBarCode.Text.Trim().Length > 0)
			{
				oOutputList.BarCode = txtBarCode.Text.Trim();
			}
			// ����
			if (!dtrDates.dtpBegDate.IsEmpty)
			{
				oOutputList.FilterDateBeg = dtrDates.dtpBegDate.Value.Date;
			}
			if (!dtrDates.dtpEndDate.IsEmpty)
			{
				oOutputList.FilterDateEnd = dtrDates.dtpEndDate.Value.Date;
			}
			// ��� �������
			if (sSelectedOutputsTypesIDList.Length > 0)
			{
				oOutputList.FilterOutputsTypesList = sSelectedOutputsTypesIDList;
			}
			// ���������
			if (sSelectedGoodsStatesIDList.Length > 0)
			{
				oOutputList.FilterGoodsStatesList = sSelectedGoodsStatesIDList;
			}

			// ���� ������
			if (optIsPicked.Checked)
			{
				oOutputList.FilterPicked = true;
			}
			if (optIsNotPicked.Checked)
			{
				oOutputList.FilterPicked = false;
			}
			// ������������� �������
			if (optIsConfirmed.Checked)
			{
				oOutputList.FilterConfirmed = true;
				// ���� �������������
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

			// ������ ������
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
				oOutputList.FilterOutputSelectedInfo = 2; // 3 (����������) - ����� ��
			}

			if (optFullConfirmedInfo.Checked)
			{
				oOutputList.FilterFullConfirmed = false;  // �� ���� ����������� ����� �����
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

			// ������
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

			// ���������� 
			if (txtPartnerNameContext.Text.Trim().Length > 0)
			{
				oOutputList.FilterPartnerContext = txtPartnerNameContext.Text.Trim();
			}
			if (sSelectedPartnersIDList.Length > 0)
			{
				oOutputList.FilterPartnersList = sSelectedPartnersIDList;
			}

			// ���������
			if (sSelectedOwnersIDList.Length > 0)
			{
				oOutputList.FilterOwnersList = sSelectedOwnersIDList;
			}

			// ��������� ������
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

			ttToolTip.SetToolTip(txtPackingsChoosen, "�� �������");
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
				RFMMessage.MessageBoxError("������ ��� ��������� ������...");
				return;
			}
			if (oPartner.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("��� ������...");
				return;
			}

			if (StartForm(new frmSelectID(this, oPartner.MainTable, "Name,Actual", "���������,���.", true)) == DialogResult.Yes)
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

			ttToolTip.SetToolTip(txtPartnersChoosen, "�� �������");
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
				RFMMessage.MessageBoxError("������ ��� ��������� ������...");
				return;
			}
			if (oOwner.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("��� ������...");
				return;
			}

			if (StartForm(new frmSelectID(this, oOwner.MainTable, "Name,Actual", "��������,���.", true)) == DialogResult.Yes)
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

			ttToolTip.SetToolTip(txtOwnersChoosen, "�� �������");
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
				RFMMessage.MessageBoxError("������ ��� ��������� ������...");
				return;
			}
			if (oOutputForType.TableOutputsTypes.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("��� ������...");
				return;
			}

			if (StartForm(new frmSelectID(this, oOutputForType.TableOutputsTypes, "Name", "��� �������", true)) == DialogResult.Yes)
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

			ttToolTip.SetToolTip(txtOutputsTypesChoosen, "�� �������");
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
				RFMMessage.MessageBoxError("������ ��� ��������� ������...");
				return;
			}
			if (oGoodState.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("��� ������...");
				return;
			}

			if (StartForm(new frmSelectID(this, oGoodState.MainTable, "Name", "��������� ������", true)) == DialogResult.Yes)
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

			ttToolTip.SetToolTip(txtGoodsStatesChoosen, "�� �������");
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
				RFMMessage.MessageBoxError("������ ��� ��������� ������...");
				return;
			}
			if (oOutputForCars.TableOutputsCarsAliases.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("��� ������...");
				return;
			}

			if (StartForm(new frmSelectID(this, oOutputForCars.TableOutputsCarsAliases, "CarAlias, BackDoor", "������,���.�����", true)) == DialogResult.Yes)
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

			ttToolTip.SetToolTip(txtCarsChoosen, "�� �������");
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
					RFMMessage.MessageBoxError("������ ��� ��������� ������ (�����)...");
					return;
				}
				if (oHost.MainTable.Rows.Count == 0)
				{
					RFMMessage.MessageBoxError("��� ������ (�����)...");
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


		#region Print Bill (������� QntWished vs QntConfirmed, QntWished vs QntSelected)

		private void mniPrintOutputBill_Click(object sender, EventArgs e)
		{
			// ��������� � ����������������. (1/N)

			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.Rows.Count == 0)
				return;

			bool bAll = ((ToolStripMenuItem)sender).Name.EndsWith("All"); // ��� ���������� ������

			Output oOutputPrint = new Output();

			if (bAll)
			{
				OutputPrepareIDList(oOutputPrint, bAll);
				if (oOutputPrint.IDList == null || oOutputPrint.IDList.Length == 0)
				{
					RFMCursorWait.Set(false);
					RFMMessage.MessageBoxError("��� ���������� �������...");
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
					RFMMessage.MessageBoxError("��� ���������� ��������...");
					return;
				}

				// ������ � ���������� ���������
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
					RFMMessage.MessageBoxError("��� ������ � ������� � ���������� ��������...");
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
					RFMMessage.MessageBoxError("��� ������ � �������...");
					return;
				}

				// ������ � ������� ���������
				oOutputPrint.FillTableOutputsGoods(oOutputCur.ID);
				if (oOutputPrint.ErrorNumber != 0)
				{
					RFMCursorWait.Set(false);
					return;
				}
			}

			// ������ ������
			bool bSelected = ((ToolStripMenuItem)sender).Name.ToUpper().Contains("SELECT");

			// ������� ������� � �������
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

			// ������
			oOutputPrint.DS.Relations.Add("r1", oOutputPrint.MainTable.Columns["OutputID"],
				oOutputPrint.TableOutputsGoods.Columns["OutputID"]);
			// ��������� ������ ���� � �������-��������
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

		#region Print Bill For Confirm (�����������, ��� ������)

		private void mniPrintOutputBillForConfirm_Click(object sender, EventArgs e)
		{
			// ��������� ��� �������������, ������ (1/N)

			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.Rows.Count == 0)
				return;

			RFMCursorWait.Set(true);

			bool bAll = ((ToolStripMenuItem)sender).Name.EndsWith("All"); // ��� ���������� ������

			Output oOutputPrint = new Output();

			if (bAll)
			{
				OutputPrepareIDList(oOutputPrint, bAll);
				if (oOutputPrint.IDList == null || oOutputPrint.IDList.Length == 0)
				{
					RFMCursorWait.Set(false);
					RFMMessage.MessageBoxError("��� ���������� �������...");
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
					RFMMessage.MessageBoxError("��� ���������� ���������������� ��������...");
					return;
				}

				// ����� � �������� ��� �������� ������ 
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
					RFMMessage.MessageBoxError("��� ������ � �������...");
					return;
				}

				/*
				if (!Convert.IsDBNull(oOutputPrint.MainTable.Rows[0]["DateConfirm"]))
				{
					RFMCursorWait.Set(false);
					RFMMessage.MessageBoxError("������ ��� �����������...");
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
				RFMMessage.MessageBoxError("����� �� ������� ��� �� ��������...");
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
				RFMMessage.MessageBoxError("��� ������ � ������� � �������...");
				return;
			}

			_PrintOutputBillForConfirm(oOutputPrint);
		}

		private void _ForPrintOutputBillForConfirmAll(Output oOutputPrint)
		{
			// ������ ��� ���������! DateSelect
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
					RFMMessage.MessageBoxError("��� ���������� ���������������� ��������, ��� ������� �������� �����...");
					return;
				}
			}

			// ������� ��� ������� �� ���� �������� (����� ������������� ������� tableOutputsGoods)
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
				RFMMessage.MessageBoxError("��� ������ � ������� � ���������� ���������������� ��������...");
				return;
			}

			_PrintOutputBillForConfirm(oOutputPrint);
		}

		private void _PrintOutputBillForConfirm(Output oOutputPrint)
		{
			// �������� "���-�� ����" �� "������������� (� ��������) ����"
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

			// ���� � ���������
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

			// ���� CCQnt �������� � �������
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

			// ������ 
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

			bool bAll = ((ToolStripMenuItem)sender).Name.EndsWith("All"); // ��� ���������� ������

			Output oOutputPrint = new Output();
			TrafficFrame oTrafficPrint = new TrafficFrame();

			if (bAll)
			{
				OutputPrepareIDList(oOutputPrint, bAll);
				if (oOutputPrint.IDList == null || oOutputPrint.IDList.Length == 0)
				{
					RFMCursorWait.Set(false);
					RFMMessage.MessageBoxError("��� ���������� �������...");
					return;
				}

				// ������ ��������������� ��� ���� ���������� ��������
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
					RFMMessage.MessageBoxError("��� ������ � ���������������� ��� ���������� ��������...");
					return;
				}

				DataRow[] drs = oTrafficTemp.MainTable.Select("", "OutputID");

				oTrafficPrint.ID = -1;
				oTrafficPrint.FillData(); // �������� ������ MainTable
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
					RFMMessage.MessageBoxError("��� ������ � ���������������� �������� ��� �������...");
					return;
				}
			}

			RFMCursorWait.Set(false);

			// ������ 
			repTrafficFrameBill rd = new repTrafficFrameBill();
			StartForm(new frmActiveReport(oTrafficPrint.MainTable, rd));
		}

		#endregion Print TrafficsFrames list

		#region Print TrafficsGoods list (���-����)

		private void mniPrintTrafficsGoodsList_Click(object sender, EventArgs e)
		{
			// ���-���� (1 / N)

			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.Rows.Count == 0)
				return;

			RFMCursorWait.Set(true);

			bool bAll = ((ToolStripMenuItem)sender).Name.EndsWith("All"); // ��� ���������� ������

			Output oOutputPrint = new Output();

			if (bAll)
			{
				OutputPrepareIDList(oOutputPrint, bAll);
				if (oOutputPrint.IDList == null || oOutputPrint.IDList.Length == 0)
				{
					RFMCursorWait.Set(false);
					RFMMessage.MessageBoxError("��� ���������� �������...");
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
			// ���-���� (��� ��������������)

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
				RFMMessage.MessageBoxError("��� ��������, �� ������� �� ���������� ����� �������...");
				return;
			}

			_PrintTrafficsGoodsList(oOutputPrint, false);
		}

		private void _PrintTrafficsGoodsList(Output oOutputPrint, bool? bPrinted)
		{
			bool bPrintTrafficsFramesList = true;

			// ������� ����� ���������� ��������
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

			// ����������� ����/�������
			oOutputPrint.FillTableOutputsPickList(oOutputPrint.ID, oOutputPrint.IDList, bPrinted);
			if (oOutputPrint.ErrorNumber != 0)
			{
				RFMCursorWait.Set(false);
				return;
			}

			// ������ �� ��������������� �����������
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
				// �������� "���-�� ����" �� "������������� (� ��������) ����"
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
				RFMMessage.MessageBoxError("��� ������ � ������������ �������/���� ��� ������" +
					((oOutputPrint.MainTable.Rows.Count > 1) ? "��" : "�") + "...");
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
						" (����� ��� ������ ������ " + Convert.ToDecimal(o["BruttoWished"]).ToString("# ##0") + ")";
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
				// ���� � ���������
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
				// ���� � ���.����������� �� ��������
				t1.Columns.Add("TrafficsFramesList");
				// �������� ������ ������ ��� ������� ������ ������� (�� �������� ������, � �� �� �������)
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
							rTempX["FramesList"] = "������� (" + rTempX["FramesCnt"].ToString() + "): " + sFrameList; 
						}
					}
					// ������� ������ ������� �������(!) � ����������� � ������ ��� � ���.������� �����������

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

				// ������ 
				//repTrafficGoodBill rd = new repTrafficGoodBill();
				repOutputPickList rd = new repOutputPickList();
				StartForm(new frmActiveReport(tTableGood, rd, 1));

				// ������� ������
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
			// ���.����� �� ��������

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

			// ������� ������
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

			// �������� ����������� ��������� �����
			if (RFMMessage.MessageBoxYesNo("�������� ����������� ���������?") == DialogResult.Yes)
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
			// ������ ����� �����������, ������� �������� ��� ������ (1)

			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.CurrentRow == null)
				return;
			if (grdData.CurrentRow == null)
				return;
			if (grdData.IsStatusRow(grdData.CurrentRow.Index))
				return;

			RFMCursorWait.Set(true);

			// ������ ��������
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
				RFMMessage.MessageBoxError("��� ������ � ����� ������������ �������/���� ��� �������...");
				return;
			}
			InBoxWeighting(oTrafficPrint.MainTable);

			RFMCursorWait.Set(false);

			// ������ 
			repTrafficGoodBill rd = new repTrafficGoodBill();
			StartForm(new frmActiveReport(oTrafficPrint.MainTable, rd));
		}

		#endregion Print TrafficsGoods list (���-����)

		#region Print Complete list (��������-����, Confirmed)

		private void mniPrintCompleteList_Click(object sender, EventArgs e)
		{
			// ��������-����. (1)
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.Rows.Count == 0)
				return;

			bool bAll = ((ToolStripMenuItem)sender).Name.EndsWith("All"); // ��� ���������� ������

			Output oOutputPrint = new Output();

			if (bAll)
			{
				OutputPrepareIDList(oOutputPrint, bAll);
				if (oOutputPrint.IDList == null || oOutputPrint.IDList.Length == 0)
				{
					RFMCursorWait.Set(false);
					RFMMessage.MessageBoxError("��� ���������� �������...");
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
					RFMMessage.MessageBoxError("��� ���������� ���������������� ��������...");
					return;
				}

				// �������� ������
				// ��������� (������ �������)
				oOutputPrint.FillTableOutputsItems(oOutputCur.ID);
				if (oOutputPrint.ErrorNumber != 0)
				{
					RFMCursorWait.Set(false);
					return;
				}
				DataTable tTableOutputsItems = oOutputPrint.TableOutputsItems.Clone();

				// �������� ���������� ���� �������� 
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

					// ������� ������������ �������
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

					// ��������� � ������
					tTableOutputsItems.Merge(oOutputPrint.TableOutputsItems);
				}

				if (tTableOutputsItems.Rows.Count == 0)
				{
					RFMCursorWait.Set(false);
					RFMMessage.MessageBoxError("��� ������ � ������������ ��������...");
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
					RFMMessage.MessageBoxError("��� ������ � �������...");
					return;
				}

				// �������� ���������� ���� �������� 
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
					RFMMessage.MessageBoxError("���� ���������������� �������� ��������������� ��� �������!");
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
					RFMMessage.MessageBoxError("���� ���������������� �������� ����������� �������/���� ��� �������!");
					return;
				}


				// ������� ������������ �������
				oOutputPrint.FillTableOutputsItems(oOutputCur.ID);
				if (oOutputPrint.ErrorNumber != 0)
				{
					RFMCursorWait.Set(false);
					return;
				}
				if (oOutputPrint.TableOutputsItems.Rows.Count == 0)
				{
					RFMCursorWait.Set(false);
					RFMMessage.MessageBoxError("��� ������ � ������������ �������...");
					return;
				}
			}

			// ������� �� �� ������� 
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
							//if (RFMMessage.MessageBoxYesNo("�������� ������ ��� ������� ������ �� ��������� ��������?", false) == DialogResult.Yes)
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

			// ��������� ������ ���� � �������-��������
			oOutputPrint.DS.Relations.Add("r1", oOutputPrint.MainTable.Columns["OutputID"],
				oOutputPrint.TableOutputsItems.Columns["OutputID"]);
			RepTableColumnAdd(oOutputPrint.TableOutputsItems);

			DataTable dt = CopyTable(oOutputPrint.TableOutputsItems, "dt", "", "OutputID, IsFrame desc, StoreZoneSourceName, StoreZoneSourceID, GoodAlias, FrameID");

			RFMCursorWait.Set(false);

			repOutputCompleteList rep = new repOutputCompleteList(bStoreZoneSeparate);
			StartForm(new frmActiveReport(dt, rep));
		}

		#endregion Print Complete list (��������-����)

		#region Print Control list (���� �������� �������/����, Wished)

		private void mniPrintControlList_Click(object sender, EventArgs e)
		{
			// ����������� ���� �������� (1)

			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.Rows.Count == 0)
				return;
			if (grdData.CurrentRow == null)
				return;
			if (grdData.IsStatusRow(grdData.CurrentRow.Index))
				return;

			RFMCursorWait.Set(true);

			Output oOutputPrint = new Output();

			// ��������� ������ 
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
				RFMMessage.MessageBoxError("�� ���������� ������ �������...");
				return;
			}
			int nCellID = Convert.ToInt32(oOutputPrint.MainTable.Rows[0]["CellID"]);

			// ������� ������
			oOutputPrint.FillTableOutputsTraffics(nOutputID, true);
			if (oOutputPrint.ErrorNumber != 0)
			{
				RFMMessage.MessageBoxError("������ ��� ��������� ������ � ���������������� ������...");
				RFMCursorWait.Set(false);
				return;
			}
			// ������� �������
			oOutputPrint.FillTableOutputsTraffics(nOutputID, false);
			if (oOutputPrint.ErrorNumber != 0)
			{
				RFMMessage.MessageBoxError("������ ��� ��������� ������ � ������������ �������/����...");
				RFMCursorWait.Set(false);
				return;
			}
			if (oOutputPrint.TableOutputsTrafficsFrames.Rows.Count == 0 &&
				oOutputPrint.TableOutputsTrafficsGoods.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("��� ������ � ���������������� ������ � ������������ �������/����...");
				RFMCursorWait.Set(false);
				return;
			}

			// ������������ ������� - ���������� ��� ����������� �����������
			oOutputPrint.FillTableOutputsItems(nOutputID);
			if (oOutputPrint.ErrorNumber != 0)
			{
				RFMMessage.MessageBoxError("������ ��� ��������� ������ � ������������ �������...");
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

			// ���������� ��� ����������
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
							// ��������� �� �������� 
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
							// ��������� ��� ��������. ������� ������ �� ������������ �������
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
				RFMMessage.MessageBoxError("��� ������ � ���������������� ������ � ������������ �������/���� � �������� ������...");
				RFMCursorWait.Set(false);
				return;
			}

			InBoxWeighting(dt);

			// ����������� ���� ��� � ������
			dt.Columns["QntWished"].ColumnName = "Qnt";
			dt.Columns["BoxWished"].ColumnName = "Boxes";
			dt.Columns["RestQntWished"].ColumnName = "RestQnt";
			dt.Columns["RestBoxWished"].ColumnName = "RestBoxes";

			// ��������� ������ ���� � �������-��������
			oOutputPrint.DS.Relations.Add("r1", oOutputPrint.MainTable.Columns["OutputID"],
				dt.Columns["OutputID"]);
			RepTableColumnAdd(dt);

			DataTable dtr;
			// �������� �����-��� ������
			if (RFMMessage.MessageBoxYesNo("�������� �����-��� ������?") == DialogResult.Yes)
			{
				// ����������� ������� �� ������: ������ ���� - ����������, ������ - �������
				dtr = CopyTable(dt, "dtr", "", "IsFrame desc, GoodAlias, FrameID");
			}
			else
			{
				foreach (DataRow r in dt.Rows)
				{
					r["GoodBarCode"] = "";
				}
				// ����������� ������� �� � ����������: ������ ���� - ����������, ������ - �������
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
				r["DateConfirmText"] = (Convert.IsDBNull(r["DateConfirm"])) ? "�� �����." : "�����. " + r["DateConfirm"].ToString().Substring(0, 16);
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
                RFMMessage.MessageBoxYesNo("� ������� ������ " + RFMUtilities.Declen(RFMUtilities.Occurs(sOutputsList, ","), "������", "�������", "��������") + ".\n" +
                "��������� ������ �������������� ��� ����� / ������� / �������� �������?") == DialogResult.Yes)
            {
                StartForm(new frmReportOutputsQntDifferences(sOutputsList));
            }*/
            if (sOutputsList.Length > 0)
            {
                StartForm(new frmReportOutputsQntDifferences(sOutputsList));
            }
            else
            {
                RFMMessage.MessageBoxInfo("������� �������� �����...");
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

			// ���������� ������ � ������� �������
			int nOutputID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			oOutputCur.ClearError();
			oOutputCur.ID = nOutputID;
			oOutputCur.FillData();
			if (oOutputCur.ErrorNumber != 0)
				return;

			// �������� ����������� ����� ������
			if (oOutputCur.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("������ � ����� " + oOutputCur.ID.ToString() + " �� ������...");
				return;
			}
			if (!Convert.IsDBNull(oOutputCur.MainTable.Rows[0]["DateConfirm"]))
			{
				RFMMessage.MessageBoxError("������ � ����� " + oOutputCur.ID.ToString() + " ��� �����������...");
				return;
			}

			oOutputCur.FillTableOutputsTraffics(nOutputID, true);
			if (oOutputCur.ErrorNumber != 0)
				return;
			if (oOutputCur.TableOutputsTrafficsFrames.Rows.Count > 0)
			{
				RFMMessage.MessageBoxError("��� ������� � ����� " + oOutputCur.ID.ToString() + " ��� ������� �������� ��������������� ��������...");
				return;
			}

			oOutputCur.FillTableOutputsTraffics(nOutputID, false);
			if (oOutputCur.ErrorNumber != 0)
				return;
			if (oOutputCur.TableOutputsTrafficsGoods.Rows.Count > 0)
			{
				RFMMessage.MessageBoxError("��� ������� � ����� " + oOutputCur.ID.ToString() + " ��� ������� �������� ����������� �������/����...");
				return;
			}

			if (!Convert.IsDBNull(oOutputCur.MainTable.Rows[0]["DatePrint"]))
			{
				if (RFMMessage.MessageBoxYesNo("��������!\n\n��� ������� � ����� " + oOutputCur.ID.ToString() + " ��� ��������� ���� ������,\n" +
						"�� �������� ��������������� �������� � ����������� ����/������� �����������.\n\n" +
						"���-���� �������� ������ ������?") != DialogResult.Yes)
					return;
			}

			if (!Convert.IsDBNull(oOutputCur.MainTable.Rows[0]["CellAddress"]))
			{
				if (RFMMessage.MessageBoxYesNo("��� ������� � ����� " + oOutputCur.ID.ToString() + " ��� ������� ������ ������: " +
						oOutputCur.MainTable.Rows[0]["CellAddress"].ToString() + ".\n\n" +
						"�������� ������ ������?") != DialogResult.Yes)
					return;
			}

			// �������� ������ ��������
			int? nOutputCellID = null;
			Cell oCellOutput = new Cell();
			oCellOutput.FilterActual = true;
			oCellOutput.FilterLocked = false;
			oCellOutput.FilterStoreZoneTypeForOutputs = true;
			oCellOutput.FillData();
			if (oCellOutput.ErrorNumber != 0 || oCellOutput.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("������ ��������� ������ � ������� ��� ��������...");
				return;
			}

			// ������� ���� ����� ��������?
			if (oCellOutput.MainTable.Rows.Count == 1)
			{
				if (!Convert.IsDBNull(oOutputCur.MainTable.Rows[0]["CellID"]) &&
					Convert.ToInt32(oCellOutput.MainTable.Rows[0]["ID"]) ==
					Convert.ToInt32(oOutputCur.MainTable.Rows[0]["CellID"]))
				{
					RFMMessage.MessageBoxInfo("� ������� ������� ������������ ������ ��������: " + oCellOutput.MainTable.Rows[0]["Address"].ToString() + ".\n" +
						"� ������� ������� �� �� ������.\n" +
						"��������� �� ���������.");
					return;
				}

				if (RFMMessage.MessageBoxYesNo("� ������� ������� ������������ ������ ��������: " + oCellOutput.MainTable.Rows[0]["Address"].ToString() + ".\n" +
						"������� �� � �������� ������ ������ ��� �������?") != DialogResult.Yes)
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
					// ������� ������� �� ������ �����
					if (StartForm(new frmSelectID(this, oCellOutput.MainTable, "ID,Address,StoreZoneName,StoreZoneTypeName", "ID,�����,����,��� ����", false)) == DialogResult.Yes)
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
				RFMMessage.MessageBoxInfo("������ ������ ������ ���������� ������ ��� ����������� ������!");
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
					RFMMessage.MessageBoxError("�� ������� ���������� ������...");
					return;
				}

				if (StartForm(new frmSelectID(this, dvFramesContents.ToTable(),
												"FrameID,DateValid,BoxQnt,Qnt,Address",
												"���������, ���� ��������, ���., ��., ������", true)) == DialogResult.Yes)
				{
					if (_SelectedIDList != null)
					{
						Output OutputCur = new Output();
						OutputCur.FramesSelectManual((int)drOG.Cells["grcOutputGoodID"].Value, _SelectedIDList);
						if (OutputCur.ErrorNumber == 0)
						{
							RFMMessage.MessageBoxInfo("�������� ������ ������ ������.");
							grdOutputsGoods_Restore();
						}
					}
				}
			}
			else
			{
				RFMMessage.MessageBoxInfo("�� ��������� ������ ������ ������ ��� ������� ������...");
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
				RFMMessage.MessageBoxError("������ ��� ��������� ������ � �������...");
				return;
			}
			if (!Convert.IsDBNull(oOutput.MainTable.Rows[0]["DateConfirm"]))
			{
				RFMMessage.MessageBoxError("������ ��� �����������...");
				return;
			}

			// �������� ���������� ���� �������� 
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
				RFMMessage.MessageBoxError("���� ���������������� �������� ��������������� ��� �������!\r\n" +
						"�������� ����������...");
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
				RFMMessage.MessageBoxError("���� ���������������� �������� ����������� �������/���� ��� �������!\r\n" +
						"�������� ����������...");
				return;
			}
			// 

			if (RFMMessage.MessageBoxYesNo("���������� ���� �����/������� ������?") != DialogResult.Yes)
				return;

			Refresh();

			oOutput.SetDatePick((int)oOutput.ID);
			if (oOutput.ErrorNumber == 0)
			{
				grdData_Restore();
				RFMMessage.MessageBoxInfo("���� �����/������� ������� �����������.");
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
				RFMMessage.MessageBoxError("������ ��� ��������� ������ � �������...");
				return;
			}
			if (!Convert.ToBoolean(oOutput.MainTable.Rows[0]["IsSelecting"]))
			{
				RFMMessage.MessageBoxError("������� \"� �������\" �� ����������...");
				return;
			}

			oOutput.ClearIsSelecting((int)oOutput.ID);
			if (oOutput.ErrorNumber == 0)
			{
				grdData_Restore();
				RFMMessage.MessageBoxInfo("������� \"� �������\" ����.");
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
			// ������ ����������� �������/����
			TrafficGood oTrafficGoodTemp = new TrafficGood();
			oTrafficGoodTemp.FilterOutputsList = oOutputCur.ID.ToString();
			oTrafficGoodTemp.FillData();
			if (oTrafficGoodTemp.ErrorNumber != 0 || oTrafficGoodTemp.MainTable == null)
				return;
			if (oTrafficGoodTemp.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("��� �������� ������� ��� ����������� �������/����...");
				return; 
			}
			// ������ "������" �������������
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
				RFMMessage.MessageBoxError("��� ������ � ����������� � ������������ �������/���� ��� �������� �������...");
				return; 
			}

			// �������, ���� ����� �������� 
			int nOldUserID = 0;
			string sOldUserName = "";
			_SelectedID = null;
			if (StartForm(new frmSelectID(this, tOldUsers, "UserName", "��������� (�����������)", "���� ��������?")) == DialogResult.Yes)
			{
				if (_SelectedID.HasValue)
				{
					nOldUserID = (int)_SelectedID;
					sOldUserName = _SelectedText;
				}
			}
			if (nOldUserID == 0)
				return; 

			// ������ ����� ����������� 
			User oUser = new User();
			oUser.FillData();
			if (oUser.ErrorNumber != 0 || oUser.MainTable == null)
				return;
			if (oUser.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("��� ������ � �����������...");
				return; 
			}

			int nNewUserID = 0;
			string sNewUserName = "";
			_SelectedID = null;
			if (StartForm(new frmSelectID(this, oUser.MainTable, "Name", "��������� (������)", "�� ���� ��������?")) == DialogResult.Yes)
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
			if (RFMMessage.MessageBoxYesNo("��������� ������ ������ � ����������� � ������������ �������/���� ��� �������� �������:\n" + 
				"��������� " + sOldUserName + " �������� �� ���������� " + sNewUserName +
				" (" + RFMUtilities.Declen(dv.Count, "��������", "��������", "��������") + ")?") == DialogResult.Yes)
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

			// ������ ������� - ��� ������ ������� 

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
				RFMMessage.MessageBoxError("������ ��������� ������ � �������...");
				return;
			}

			// �����������?
			if (!Convert.IsDBNull(oOutputCur.MainTable.Rows[0]["DateConfirm"]))
			{
				RFMMessage.MessageBoxError("������ ��� �����������...");
				return;
			}

			// �������� ������
			//if (Convert.IsDBNull(oOutputCur.MainTable.Rows[0]["CellID"]))
			//{
			//   nOutputCellID = SelectOutputCell(nOutputID);
			//   if (!nOutputCellID.HasValue)
			//   {
			//      RFMMessage.MessageBoxError("�� ���������� ������ ��������...\n���������� �������� ������� ����������...");
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
					RFMMessage.MessageBoxInfo("�� ������� ������������� ��������� ������ ��������");
					return;
				}	
			}
			if (RFMMessage.MessageBoxYesNo("��������� ������ ������� �\n" +
				"������� ����������� �������� ��������������� �������� � ����������� �������/����?") == DialogResult.Yes)
			{
				Refresh();
				WaitOn(this);
				// ���� ���������
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
					RFMMessage.MessageBoxInfo("������ ������� ��� ��������.\n��� ������ ��������� ���������.");
					return;
				}

				// ���������� ������
				bool bResult = oOutputCur.SelectData(nOutputID, nOutputCellID);
				WaitOff(this);
				if (bResult && oOutputCur.ErrorNumber == 0)
				{
					// ����� ���������
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
						RFMMessage.MessageBoxInfo("������ ������� ��������.\n��� ������ ��������� ���������.");
						bSaid = true;
					}
					if (!bSaid && nNewCntSelected == nOldCntSelected)
					{
						RFMMessage.MessageBoxAttention("������ ������� ��������,\n�� �� ������� ��������� �� ������ ������.");
						bSaid = true;
					}
					if (!bSaid && nNewQntSelected > nOldQntSelected && nNewCntFullSelected < oOutputCur.TableOutputsGoods.Rows.Count)
					{
						RFMMessage.MessageBoxAttention("������ ������� ��������,\n�� �� ������� ��������� ����� �������.");
						bSaid = true;
					}
					if (!bSaid)
					{
						RFMMessage.MessageBoxInfo("������ ������� ��������.");
						bSaid = true;
					}

					// ������ ���-�����
					if (RFMMessage.MessageBoxYesNo("�������� ���� ������� �� ����������� �������/����?") == DialogResult.Yes)
					{
						mniPrintTrafficsGoodsList_Click(mniPrintTrafficsGoodsList, null);
					}

					grdData_Restore();
					tcOutputsGoods.SetAllNeedRestore(true);
				}
				else
				{
					RFMMessage.MessageBoxError("������ ���������� �������� ������� �������...");
				}
			}
		}

		private void mniSelectMarked_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.Rows.Count == 0)
				return;

			// ������ ������� - ��� ���� ���������� ������� 

			int nMarkedCnt = CalcMarkedRows();
			if (nMarkedCnt > 0)
			{
				if (RFMMessage.MessageBoxYesNo("�������� �������: " + nMarkedCnt.ToString() + "\n\n" +
						"��������� ������ ������� �\n" +
						"������� ����������� �������� ��������������� �������� � ����������� �������/����\n" +
						"��� ���� ���������� ��������?") != DialogResult.Yes)
					return;
				Refresh();

				Output oOutputSelect = new Output();
				OutputNotConfirmedPrepareIDList(oOutputSelect, nMarkedCnt > 0);
				if (oOutputSelect.IDList == null || oOutputSelect.IDList.Length == 0)
				{
					RFMMessage.MessageBoxError("��� ���������� ���������������� �������...");
					return;
				}

				OutputsSelect(oOutputSelect, true);
			}
			else
			{
				RFMMessage.MessageBoxError("��� ���������� �������...");
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
				RFMMessage.MessageBoxError("��� ��������, ��� ������� ��������� ������ �������...");
				return;
			}

			RFMCursorWait.Set(false);

			OutputsSelect(oOutputSelect, false);
		}

		private void OutputsSelect(Output oOutputSelect, bool bIsMarked)
		{
			string sAll = (bIsMarked) ? "�� ���������� ��������" : "� ��������, ��� ������� ��������� ������ �������";

			WaitOn(this);

			oOutputSelect.FillData();
			if (oOutputSelect.ErrorNumber != 0 || oOutputSelect.MainTable.Rows.Count == 0)
			{
				WaitOff(this);
				RFMMessage.MessageBoxError("������ ��������� ������ " + sAll + "...");
				return;
			}
			WaitOff(this);

			int nCnt = oOutputSelect.MainTable.Rows.Count;
			if (RFMMessage.MessageBoxYesNo("������ ������ ������� ��� " + RFMUtilities.Declen(nCnt, "�������", "��������", "��������") + "?") != DialogResult.Yes)
				return;

			Refresh();

			int nOutputID = 0;
			int? nOutputCellID = null;
											// �� �������
			int nOldCntSelected = 0;		// ����� ���� ���-�� ����������� 
			decimal nOldQntSelected = 0;	// ���� 
			int nOldCntFullSelected = 0;	// ����� ��������� �����������
			int nOldAllFullSelected = 0;	// ������� ��������� �����������
											// ����� �������
			int nNewCntSelected = 0;		// ����� ���� ���-�� ����������� 
			decimal nNewQntSelected = 0;	// ���� 
			int nNewCntFullSelected = 0;	// ����� ��������� �����������
			int nNewAllFullSelected = 0;	// ������� ��������� �����������
			int nUnSelectingCellsCount = 0; //  ���-�� �������� � ������������� ������� ��������
			string sOutputsListForPrint = "";

			// ��� ������ ������ 
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
				RFMMessage.MessageBoxInfo("�� ��� ������ �� ��������� �������� ���������� ������������� ��������� ��������...");
				return;
			}	
			if (nUnSelectingCellsCount > 0 && RFMMessage.MessageBoxYesNo("��� " + RFMUtilities.Declen(nUnSelectingCellsCount, 
						"�������", "��������", "��������") + " �� ��������� ������ ��������. \r\n���������� ������ ������?") == DialogResult.No)
					return;		
			// �������� ������ - ��� ������ ������

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

				// �����������?
				if (!Convert.IsDBNull(ro["DateConfirm"]))
				{
					nOldAllFullSelected++;
					nNewAllFullSelected++;

					ProgressRefresh(this);
					continue;
				}

				// �������� ������ �������� 
				//	nOutputCellID = null;
				//if (Convert.IsDBNull(ro["CellID"]))
				//{
				//   nOutputCellID = SelectOutputCell(nOutputID);
				//   if (!nOutputCellID.HasValue)
				//   {
				//      // �� ������ ������� ������ �������� 
				//      RFMMessage.MessageBoxError("�� ���������� ������ �������� ��� ������� � ����� " + nOutputID.ToString() + "...\n" +
				//         "���������� �������� ������� ��� ����� ������� ����������...");
				//      ProgressRefresh(this);
				//      continue;
				//   }
				//}
				//else
				//{
				//   nOutputCellID = Convert.ToInt32(ro["CellID"]);
				//}
				// ���� ��������� ������� - � ���� ������� 
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
					// ��� ��� ��������� 
					nOldAllFullSelected++;
					//RFMMessage.MessageBoxInfo("������ ������� ��� ��������.\n��� ������ ��������� ���������.");
					continue;
				}

				// ���������� ������
				bool bResult = oOutputSelectOne.SelectData(nOutputID, nOutputCellID);
				if (bResult && oOutputSelectOne.ErrorNumber == 0)
				{
					// ����� ���������
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
						// ����� ��� ��������� 
						nNewAllFullSelected++;
					}
				}
				else
				{
					RFMMessage.MessageBoxError("������ ���������� �������� ������� ������� ��� ������� � ����� " + nOutputID.ToString() + "...");
					ProgressRefresh(this);
				}

				sOutputsListForPrint += nOutputID.ToString().Trim() + ",";

				i++;
				ProgressShell(this, i);
			}
			ProgressClose(this);
			// ������ ��� ���������� ���������. ������ ��������� 

			WaitOff(this);
			bool bSaid = false;
			string sAllYx = (bIsMarked) ? "���������� " : "";
			string sAllYm = (bIsMarked) ? "���������� " : "";
			if (!bSaid && nOldAllFullSelected == oOutputSelect.MainTable.Rows.Count)
			{
				RFMMessage.MessageBoxInfo("������ ������� ��� ���� " + sAllYx + "�������� ��� ��������.\n" +
					"��� ������ �� ���� " + sAllYm + "�������� ��������� ���������.");
				bSaid = true;
			}
			if (!bSaid && nNewAllFullSelected == oOutputSelect.MainTable.Rows.Count)
			{
				RFMMessage.MessageBoxInfo("������ ������� ��� ���� " + sAllYx + "�������� ��������.\n" +
					"��� ������ �� ���� " + sAllYm + "�������� ��������� ���������.");
				bSaid = true;
			}
			if (!bSaid && nNewCntSelected == nOldCntSelected)
			{
				RFMMessage.MessageBoxAttention("������ ������� ��� ���� " + sAllYx + "�������� ��������,\n" +
					"�� �� ������� ��������� �� ������ ������.");
				bSaid = true;
			}
			if (!bSaid && nNewQntSelected > nOldQntSelected && nNewAllFullSelected < oOutputSelect.MainTable.Rows.Count)
			{
				RFMMessage.MessageBoxAttention("������ ������� ��� ���� " + sAllYx + "�������� ��������,\n" +
					"�� �� ������� ��������� ����� �������.");
				bSaid = true;
			}
			if (!bSaid)
			{
				RFMMessage.MessageBoxInfo("������ ������� ��� ���� " + sAllYx + "�������� ��������.");
				bSaid = true;
			}

			// ������ ���-�����
			if (RFMMessage.MessageBoxYesNo("�������� ���� ������� �� ����������� �������/����?") == DialogResult.Yes)
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
				RFMMessage.MessageBoxError("������ ��������� ������ � ������� ��������...");
				return (null);
			}

			// ������� ���� ����� ��������?
			if (oCellOutput.MainTable.Rows.Count == 1)
			{
				// ���� 
				nCellOutputID = Convert.ToInt32(oCellOutput.MainTable.Rows[0]["ID"]);
			}
			else
			{
				// ��������� 
				// �������: �������� ������ � ���� ������� 
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
					// �������� ������� � ����������� ���� ������ ��� �������
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
					// ������� ������� �� ������ �����
					_SelectedID = null;
					if (StartForm(new frmSelectID(this, oCellOutput.MainTable, "ID,Address,StoreZoneName,StoreZoneTypeName", "ID,�����,����,��� ����", false)) == DialogResult.Yes)
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
			// ������ ������ ������ ��� ������, ��������, �� ����� ��������
			if (grdData.Rows.Count == 0 || grdData.CurrentRow == null || !oOutputCur.ID.HasValue || 
				grdOutputsGoods.Rows.Count == 0 || grdOutputsGoods.CurrentRow == null)
				return;
			if (LastGrid.Name != "grdOutputsGoods")
			{
				RFMMessage.MessageBoxError("��� ������� ����������� ������� ������� � ������ ������� ������� � �������.");
				return;
			}

			// ��� ������
			int nOutputID = (int)oOutputCur.ID;
			Output oOutputSelect = new Output();
			oOutputSelect.ID = nOutputID;
			if (!oOutputSelect.FillData() || oOutputSelect.MainTable == null || oOutputSelect.MainTable.Rows.Count != 1)
				return;
			DataRow rO = oOutputSelect.MainTable.Rows[0];
			if (!Convert.IsDBNull(rO["DateConfirm"]))
			{
				RFMMessage.MessageBoxError("������ ��� �����������!");
				return;
			}
			// ������ ��������
			if (Convert.IsDBNull(rO["CellID"]))
			{
				if (oOutputSelect.SelectOutCell(nOutputID) != 0)
				{
					// ��� ������ ��� �� ���� - �������� ������ �������� �������
					int? nOutputCellID = null;
					Cell oCellOutput = new Cell();
					oCellOutput.FilterActual = true;
					oCellOutput.FilterLocked = false;
					oCellOutput.FilterStoreZoneTypeForOutputs = true;
					oCellOutput.FillData();
					if (oCellOutput.ErrorNumber != 0 || 
						oCellOutput.MainTable == null || oCellOutput.MainTable.Rows.Count == 0)
					{
						RFMMessage.MessageBoxError("������ ��������� ������ � ������� ��������...");
						return;
					}
					// ������� ���� ����� ��������?
					if (oCellOutput.MainTable.Rows.Count == 1)
					{
						nOutputCellID = Convert.ToInt32(oCellOutput.MainTable.Rows[0]["ID"]);
					}
					else
					{
						_SelectedID = null;
						// ������� ������� �� ������ �����
						if (StartForm(new frmSelectID(this, oCellOutput.MainTable, "ID,Address,StoreZoneName,StoreZoneTypeName", "ID,�����,����,��� ����", false)) == DialogResult.Yes)
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
						RFMMessage.MessageBoxError("�� ������� ������ �������� ��� �������...");
						return;
					}
				}
				oOutputSelect.FillData();
				rO = oOutputSelect.MainTable.Rows[0];
			}

			// ����� � �������
			DataRow rOG = ((DataRowView)grdOutputsGoods.CurrentRow.DataBoundItem).Row;
			int nOutputGoodID = Convert.ToInt32(rOG["ID"]);
			// ��� �����
			if (Convert.ToDecimal(rOG["QntConfirmed"]) > 0)
			{
				RFMMessage.MessageBoxError("����� ��� �����!");
				return;
			}
			decimal nQntWished = Convert.ToDecimal(rOG["QntWished"]), 
					nQntSelected = Convert.ToDecimal(rOG["QntSelected"]), 
					nQntPicked = Convert.ToDecimal(rOG["QntPicked"]); 
			if (nQntPicked >= nQntWished)
			{
				RFMMessage.MessageBoxError("����� ��� ������ � ������ ��������!");
				return;
			}
			if (nQntSelected >= nQntWished)
			{
				RFMMessage.MessageBoxError("����� ��� ��������!");
				return;
			}

			// ��� ������� ����� ������, � �.�. � ��������
			decimal nQntNeed = nQntWished - nQntSelected;
			decimal nBoxNeed = nQntNeed / Convert.ToDecimal(rOG["InBox"]);
			decimal nPalNeed = nBoxNeed / Convert.ToDecimal(rOG["BoxInPal"]);
			if (nPalNeed < 1)
			{
				if (RFMMessage.MessageBoxYesNo("��������� ���������� ������ - ������ �������.\n" +
					"���-���� ��������� ������ ����� ������� �� �������� ����?") != DialogResult.Yes)
					return;
			}
			bool bIsWeight = Convert.ToBoolean(rOG["Weighting"]);

			// �������� �������
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
				RFMMessage.MessageBoxError("������ ��� ��������� ������ � ����������� � ������ �������...");
				return;
			}
			if (oFrame.MainTable.Rows.Count == 0)
			{
				RFMCursorWait.Set(false);
				RFMMessage.MessageBoxError("��� ����������� � ������ �������...");
				return;
			}

			Cell oCellForFrame = new Cell();
			// �������� ������ ����������� � �� �����������
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
							// ������ �� ����� �������
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
				RFMMessage.MessageBoxError("� ������� �������� ��� ����������� � ������ �������...");
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