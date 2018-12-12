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
	public partial class frmTrafficsFrames : RFMFormChild
	{
		private TrafficFrame oTrafficList;
		private TrafficFrame oTrafficCur;
		private Frame oFrame;

		// ��� ��������
		public string _SelectedIDList;
		public string _SelectedText;

		public string _SelectedPackingIDList;
		public string _SelectedPackingAliasText;
		private string sSelectedPackingsIDList = "";

		private string sSelectedStoresZonesSourceIDList = "";
		private string sSelectedStoresZonesTypesSourceIDList = "";
		private string sSelectedStoresZonesTargetIDList = "";
		private string sSelectedStoresZonesTypesTargetIDList = "";

		private string sSelectedUsersIDList = "";

		// ��� Partial-�������������
		private decimal? nPartialQnt = null;
		private decimal nPartialQntInFrame = 0;
		private decimal nPartialInBox = 0;
		private bool bPartialWeighting = false;
		private bool bPartialDecimalInBox = false;
		private int? nNewTrafficID = null;
		private int? nCellFinishID = null; 


		public frmTrafficsFrames()
		{
			oTrafficList = new TrafficFrame();
			oTrafficCur = new TrafficFrame();
			oFrame = new Frame();
			if (oTrafficList.ErrorNumber != 0 ||
				oTrafficCur.ErrorNumber != 0 ||
				oFrame.ErrorNumber != 0)
			{
				IsValid = false;
			}

			if (IsValid)
			{
				InitializeComponent();
			}
		}

		private void frmTrafficsFrames_Load(object sender, EventArgs e)
		{
			RFMCursorWait.Set(true);

			cboTrafficError.SelectedIndex = -1;

			grcQntFramesContents.AgrType =
			grcBoxQntFramesContents.AgrType =
			grcPalQntFramesContents.AgrType =
			grcFrameWeight.AgrType =
				EnumAgregate.Sum;

			btnClearTerms_Click(null, null);

			pnlPartial.Visible = false;

			tcList.Init();

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
			btnService.Enabled = 
				false;
			return true;
		}

		private bool tabTrafficsFrames_Restore()
		{
			grdData_Restore();
			btnAdd.Enabled = true;
			btnService.Enabled = true;

			if (grdData.Rows.Count > 0)
			{
				btnPrint.Enabled = true;
				//btnService.Enabled = true;
			}
			else
			{
				btnPrint.Enabled = false;
				//btnService.Enabled = false;
			}
			return true;
		}

		private void tcList_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (tcList.SelectedTab.Name)
			{
				case "tabTerms":
					tabTerms_Restore();
					break;
				case "tabTrafficsFrames":
					btnAdd.Enabled = true;
					btnService.Enabled = true;
					grdData.Select();
					break;
			}
		}

		#endregion Tab Restore

		#region Buttons

		private void btnAdd_Click(object sender, EventArgs e)
		{
			int? nFrameID = null;
			// ���� ����� �� ������ � ��������� ������������� - ������ ����� �������� ������ ��� ����� ����������
			if (grdData.CurrentRow != null && !grdData.IsStatusRow(grdData.CurrentRow.Index))
			{
				DataGridViewRow r = grdData.CurrentRow;
				if (r.Cells["grcTrafficFrameErrorName"].Value != null &&
					r.Cells["grcTrafficFrameErrorName"].Value.ToString().Length > 0 &&
					r.Cells["grcDateConfirm"].Value != DBNull.Value)
				{
					if (RFMMessage.MessageBoxYesNo("������� ����� �������� ��������������� ������� � ����� " + r.Cells["grcFrameID"].Value.ToString() + "?") == DialogResult.Yes)
					{
						nFrameID = Convert.ToInt32(r.Cells["grcFrameID"].Value);
					}
				}
			}

			if (StartForm(new frmTrafficsFramesManual(nFrameID)) == DialogResult.Yes)
				grdData_Restore();
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			if (grdData.CurrentRow == null)
				return;

			// ���������� ������� ��������� �������
			oTrafficCur.ClearError();
			oTrafficCur.ClearData();
			oTrafficCur.ClearFilters();
			oTrafficCur.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			oTrafficCur.FillData();
			if (oTrafficCur.ErrorNumber != 0 || oTrafficCur.MainTable.Rows.Count != 1)
				return;

			DataRow r = oTrafficCur.MainTable.Rows[0];

			if ((bool)r["IsConfirmed"])
			{
				RFMMessage.MessageBoxError("������� ��� ������������.\n" +
						"��������� ����������.");
				return;
			}

			if (r["DateAccept"] != DBNull.Value)
			{
				if (RFMMessage.MessageBoxYesNo("������� ��� �����������.\n\n" +
						"����� ������ ���������������� ��������� ���������� �������\n� ��������� ������.\n\n" +
						"����������?") != DialogResult.Yes)
					return;
			}

			if (StartForm(new frmTrafficsFramesEdit((int)oTrafficCur.ID)) == DialogResult.Yes)
				grdData_Restore();
		}

		private void btnConfirm_Click(object sender, EventArgs e)
		{
			if (grdData.CurrentRow == null)
				return;

			if (RFMMessage.MessageBoxYesNo("�������� ������� ���������� �������� ���������������\n(������ ��������������� � ������-��������)?") == DialogResult.Yes)
			{
				oTrafficCur.ClearError();
				oTrafficCur.ClearData();
				oTrafficCur.ClearFilters();
				oTrafficCur.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
				oTrafficCur.FillData();
				if (oTrafficCur.MainTable.Rows.Count > 0)
				{
					oTrafficCur.ConfirmData((int)oTrafficCur.ID, (int)oTrafficCur.MainTable.Rows[0]["CellTargetID"], true, null);
					if (oTrafficCur.ErrorNumber == 0)
						grdData_Restore();
				}
			}
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (grdData.CurrentRow == null) return;

			// ���������� ������� ��������� �������
			oTrafficCur.ClearError();
			oTrafficCur.ClearData();
			oTrafficCur.ClearFilters();
			oTrafficCur.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			oTrafficCur.FillData();
			if (oTrafficCur.ErrorNumber != 0 || oTrafficCur.MainTable.Rows.Count != 1) return;

			DataRow r = oTrafficCur.MainTable.Rows[0];

			if ((bool)r["IsConfirmed"])
			{
				RFMMessage.MessageBoxError("������� ��� ������������.\n" + "�������� ����������.");
				return;
			}

			if (r["DateAccept"] != DBNull.Value)
			{
				RFMMessage.MessageBoxError("������� ��� �����������.\n" + "�������� ����������.");
				return;
			}

			if (RFMMessage.MessageBoxYesNo("������� ������� �� ��������������� �������?") == DialogResult.Yes)
			{
				oTrafficCur.DeleteOne((int)oTrafficCur.ID);
				if (oTrafficCur.ErrorNumber == 0)
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

		public void TrafficPrepareIDList(TrafficFrame oTraffic, bool bMultiSelect)
		{
			oTraffic.ID = null;
			oTraffic.IDList = null;
			int? nTrafficID = 0;
			if (bMultiSelect && grdData.IsCheckerShow)
			{
				oTraffic.IDList = "";

				DataView dMarked = new DataView(oTrafficList.MainTable);
				dMarked.RowFilter = "IsMarked = true";
				dMarked.Sort = grdData.GridSource.Sort;
				foreach (DataRowView r in dMarked)
				{
					if (!Convert.IsDBNull(r["ID"]))
					{
						nTrafficID = (int)r["ID"];
						oTraffic.IDList = oTraffic.IDList + nTrafficID.ToString() + ",";
					}
				}
			}
			else
			{
				oTraffic.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			}
		}

		public int CalcMarkedRows()
		{
			int nCnt = 0;
			if (grdData.IsCheckerShow)
			{
				DataView dMarked = new DataView(oTrafficList.MainTable);
				dMarked.RowFilter = "IsMarked = true";
				nCnt = dMarked.Count;
			}
			return (nCnt);
		}

		#endregion

		#region TimerTick, CellsFormatting

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

			btnAdd.Enabled = 
			btnPrint.Enabled =
			btnService.Enabled = 
				true;

			oFrame.ID = 0;
			if (grdData.IsStatusRow(rowIndex))
			{
				oTrafficCur.ID = 0;
				btnConfirm.Enabled = 
				btnEdit.Enabled = 
					false;
			}
			else
			{
				DataGridViewRow r = grdData.Rows[rowIndex];
				oTrafficCur.ID = (int)r.Cells["grcID"].Value;
				bool isConfirmed = (bool)r.Cells["grcIsConfirmed"].Value;
				bool isAccepted = (r.Cells["grcDateAccept"].Value != null &&
									r.Cells["grcDateAccept"].Value != DBNull.Value);
				btnConfirm.Enabled = !isConfirmed;
				btnEdit.Enabled = !isConfirmed && !isAccepted;
				btnDelete.Enabled = !isConfirmed && !isAccepted;

				if (r.Cells["grcFrameID"].Value != DBNull.Value &&
					r.Cells["grcFrameID"].Value != null)
				{
					oFrame.ID = (int)r.Cells["grcFrameID"].Value;
				}
			}

			grdFramesContents_Restore();
		}

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
					case "grcStatusImage":
						e.Value = Properties.Resources.Empty;
						break;
				}
				return;
			}

			switch (grdData.Columns[e.ColumnIndex].Name)
			{
				case "grcStatusImage":
					if (grdData.Rows[e.RowIndex].Cells["grcDateConfirm"].Value.ToString().Length == 0)
						e.Value = Properties.Resources.Empty;
					else
						if ((bool)grdData.Rows[e.RowIndex].Cells["grcSuccess"].Value)
							e.Value = Properties.Resources.Check;
						else
							e.Value = Properties.Resources.CheckRed;
					break;
			}

			if ((grdData.Columns[e.ColumnIndex].Name.Contains("Height") ||
				 grdData.Columns[e.ColumnIndex].Name.Contains("Weight")) &&
				grdData.Columns[e.ColumnIndex].DefaultCellStyle.Format.Contains("N"))
			{
				if (Convert.IsDBNull(e.Value) || Convert.ToDecimal(e.Value) == 0)
				{
					e.Value = "";
				}
			}
		}

		private void grdFramesContents_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			RFMDataGridView grd = ((RFMDataGridView)sender);
			if (grd.DataSource == null)
				return;

			if (grd.IsStatusRow(e.RowIndex))
			{
				e.CellStyle.BackColor = Color.Silver;
				e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);

				switch (grd.Columns[e.ColumnIndex].Name)
				{
					case "grcQnt":
					case "grcInBox":
						e.CellStyle.Format = "### ### ### ###";
						break;
				}
				return;
			}

			DataGridViewRow r = grd.Rows[e.RowIndex];
			switch (grd.Columns[e.ColumnIndex].Name)
			{
				case "grcQntFramesContents":
				case "grcInBox":
					if (!Convert.IsDBNull(r.Cells["grcWeighting"].Value) &&
						Convert.ToBoolean(r.Cells["grcWeighting"].Value) ||
						!Convert.IsDBNull(e.Value) && Convert.ToDecimal(e.Value) != Convert.ToInt32(e.Value))
						e.CellStyle.Format = "### ### ### ###.000";
					else
						e.CellStyle.Format = "### ### ### ###";
					break;
			}
		}

		#endregion

		#region Restore

		private bool cboTrafficError_Restore()
		{
			oTrafficList.FillTableTrafficsFramesErrors();
			cboTrafficError.ValueMember = oTrafficList.TableTrafficsFramesErrors.Columns[0].Caption;
			cboTrafficError.DisplayMember = oTrafficList.TableTrafficsFramesErrors.Columns[1].Caption;
			cboTrafficError.DataSource = oTrafficList.TableTrafficsFramesErrors;
			return (oTrafficList.ErrorNumber == 0);
		}


		private bool grdData_Restore()
		{
			RFMCursorWait.Set(true);
			RFMCursorWait.LockWindowUpdate(FindForm().Handle);

			oTrafficCur.ID = null;
			oFrame.ID = null;

			oTrafficList.ClearError();
			oTrafficList.ClearFilters();
			oTrafficList.ID = null;
			oTrafficList.IDList = null;

			// �������� �������

			// �����-���
			//if (txtBarCode.Text.Trim().Length > 0)
			//    oTrafficList.BarCode = txtBarCode.Text.Trim();
			// ����
			if (!dtrDates.dtpBegDate.IsEmpty)
			{
				oTrafficList.FilterDateBeg = dtrDates.dtpBegDate.Value.Date;
			}
			if (!dtrDates.dtpEndDate.IsEmpty)
			{
				oTrafficList.FilterDateEnd = dtrDates.dtpEndDate.Value.Date;
			}
			// ��������
			// ������
			Cell oCellSource = new Cell();
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
						oTrafficList.FilterCellsSourceList = sbCS.ToString();
				}
				else
				{
					oTrafficList.FilterCellsSourceList = "-1";
				}
			}
			// ����
			if (sSelectedStoresZonesSourceIDList.Length > 0)
			{
				oTrafficList.FilterStoresZonesSourceList = sSelectedStoresZonesSourceIDList;
			}
			if (sSelectedStoresZonesTypesSourceIDList.Length > 0)
			{
				oTrafficList.FilterStoresZonesTypesSourceList = sSelectedStoresZonesTypesSourceIDList;
			}
			// ��������            
			// ������
			Cell oCellTarget = new Cell();
			if ((txtCellTargetBarCode.Text.Trim().Length > 0) |
				(txtCellTargetAddress.Text.Trim().Length > 0))
			{
				if (txtCellTargetBarCode.Text.Trim().Length > 0)
					oCellTarget.BarCode = txtCellTargetBarCode.Text.Trim();
				if (txtCellTargetAddress.Text.Trim().Length > 0)
					oCellTarget.FilterAddress = txtCellTargetAddress.Text.Trim();
				oCellTarget.FillData();
				if (oCellTarget.MainTable.Rows.Count > 0)
				{
					StringBuilder sbCT = new StringBuilder("");
					foreach (DataRow r in oCellTarget.MainTable.Rows)
						sbCT = sbCT.Append(r["ID"].ToString() + ",");
					if (sbCT.Length > 0)
						oTrafficList.FilterCellsTargetList = sbCT.ToString();
				}
				else
				{
					oTrafficList.FilterCellsTargetList = "-1";
				}
			}
			// ����
			if (sSelectedStoresZonesTargetIDList.Length > 0)
			{
				oTrafficList.FilterStoresZonesTargetList = sSelectedStoresZonesTargetIDList;
			}
			if (sSelectedStoresZonesTypesTargetIDList.Length > 0)
			{
				oTrafficList.FilterStoresZonesTypesTargetList = sSelectedStoresZonesTypesTargetIDList;
			}

			// ���������
			if (txtFrameBarCode.Text.Trim().Length > 0)
			{
				oTrafficList.FilterFramesBarCodeContext = txtFrameBarCode.Text.Trim();
			}
			if (txtFrameID.Text.Trim().Length > 0)
			{
				oTrafficList.FilterFramesList = txtFrameID.Text.Trim();
			}

			// ������������
			if (sSelectedUsersIDList.Length > 0)
			{
				oTrafficList.FilterUsersList = sSelectedUsersIDList;
			}

			// ��������� ������
			if (sSelectedPackingsIDList.Length > 0)
			{
				oTrafficList.FramesContents_FilterPackingsList = sSelectedPackingsIDList;
			}

			// ��������� ��������
			if (optNotConfirmed.Checked)
			{
				oTrafficList.FilterConfirmed = false;
				// ������ ���������
				if (optNotStarted.Checked)
				{
					oTrafficList.FilterAccepted = false;
				}
				if (optStartedNotConfirmed.Checked)
				{
					oTrafficList.FilterAccepted = true;
				}
			}

			if (optSuccess.Checked)
			{
				oTrafficList.FilterConfirmed = true;
				oTrafficList.FilterSuccess = true;
			}
			if (optNotSuccess.Checked)
			{
				oTrafficList.FilterConfirmed = true;
				oTrafficList.FilterSuccess = false;
				if (cboTrafficError.SelectedIndex > -1)
				{
					oTrafficList.FilterErrorsList = cboTrafficError.SelectedValue.ToString();
				}
			}

			// �������-�������
			if (txtInputBarCode.Text.Length > 0)
			{
				Input oInputFilter = new Input();
				oInputFilter.BarCode = txtInputBarCode.Text.Trim();
				oInputFilter.FillData();
				// ���� �� ����� �� ������ ������� �� ���������� �����-����, 
				// ��� ����� ������ �������� "", ����� �� �������� �� ������ �����������
				string sInputBarCode = "";
				foreach (DataRow r in oInputFilter.MainTable.Rows)
				{
					sInputBarCode = sInputBarCode + "," + r["ID"];
				}
				oTrafficList.FilterInputsList = sInputBarCode;
			}
			if (txtOutputBarCode.Text.Length > 0)
			{
				Output oOutputFilter = new Output();
				oOutputFilter.BarCode = txtOutputBarCode.Text.Trim();
				oOutputFilter.FillData();
				// ���� �� ����� �� ������ ������� �� ���������� �����-����, 
				// ��� ����� ������ �������� "", ����� �� �������� �� ������ �����������
				string sOutputBarCode = "";
				foreach (DataRow r in oOutputFilter.MainTable.Rows)
				{
					sOutputBarCode = sOutputBarCode + "," + r["ID"];
				}
				oTrafficList.FilterOutputsList = sOutputBarCode;
			}

			grdFramesContents.DataSource = null;
			grdData.GetGridState();

			oTrafficList.FillData();

			grdData.IsLockRowChanged = true;
			grdData.Restore(oTrafficList.MainTable);
			tmrRestore.Enabled = true;

			RFMCursorWait.LockWindowUpdate(IntPtr.Zero);
			RFMCursorWait.Set(false);

			return (oTrafficList.ErrorNumber == 0);
		}

		private bool grdFramesContents_Restore()
		{
			grdFramesContents.GetGridState();
			grdFramesContents.DataSource = null;
			if (grdData.Rows.Count == 0 ||
				oFrame.ID == null ||
				(grdData.CurrentRow != null && grdData.IsStatusRow(grdData.CurrentRow.Index)))
				return (true);

			oFrame.ClearError();
			oFrame.FillTableFramesContents((int)oFrame.ID);
			grdFramesContents.Restore(oFrame.TableFramesContents);
			return (oFrame.ErrorNumber == 0);
		}

		#endregion

		#region Filters Choose

		#region StoresZones

		private void btnStoresZonesChoose_Click(object sender, EventArgs e)
		{
			_SelectedIDList = null;
			_SelectedText = "";

			StoreZone oStoreZone = new StoreZone();
			oStoreZone.FillData();
			if (oStoreZone.ErrorNumber != 0 || oStoreZone.MainTable == null)
			{
				RFMMessage.MessageBoxError("������ ��� ��������� ������ � ����� ������...");
				return;
			}
			if (oStoreZone.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("��� ������ � ����� ������...");
				return;
			}

			if (StartForm(new frmSelectID(this, oStoreZone.MainTable, "Name", "���� ������", true)) == DialogResult.Yes)
			{
				if (_SelectedIDList == null || !_SelectedIDList.Contains(","))
				{
					btnStoresZonesClear_Click(null, null);
					return;
				}

				if (((RFMButton)sender).Name.Contains("Source"))
				{
					sSelectedStoresZonesSourceIDList = "," + _SelectedIDList;

					txtStoresZonesSourceChoosen.Text = _SelectedText;
					ttToolTip.SetToolTip(txtStoresZonesSourceChoosen, txtStoresZonesSourceChoosen.Text);
				}
				if (((RFMButton)sender).Name.Contains("Target"))
				{
					sSelectedStoresZonesTargetIDList = "," + _SelectedIDList;

					txtStoresZonesTargetChoosen.Text = _SelectedText;
					ttToolTip.SetToolTip(txtStoresZonesTargetChoosen, txtStoresZonesTargetChoosen.Text);
				}

				tabTrafficsFrames.IsNeedRestore = true;
			}

			_SelectedIDList = null;
			_SelectedText = "";
		}

		private void btnStoresZonesClear_Click(object sender, EventArgs e)
		{
			tabTrafficsFrames.IsNeedRestore = true;

			if (((RFMButton)sender).Name.Contains("Source"))
			{
				ttToolTip.SetToolTip(txtStoresZonesSourceChoosen, "�� �������");
				txtStoresZonesSourceChoosen.Text = "";
				sSelectedStoresZonesSourceIDList = "";
			}
			if (((RFMButton)sender).Name.Contains("Target"))
			{
				ttToolTip.SetToolTip(txtStoresZonesTargetChoosen, "�� �������");
				txtStoresZonesTargetChoosen.Text = "";
				sSelectedStoresZonesTargetIDList = "";
			}
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
				RFMMessage.MessageBoxError("������ ��� ��������� ������ � ����� ��� ������...");
				return;
			}
			if (oStoreZone.TableStoresZonesTypes.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("��� ������ � ����� ��� ������...");
				return;
			}

			if (StartForm(new frmSelectID(this, oStoreZone.TableStoresZonesTypes, "Name", "��� ���.����", true)) == DialogResult.Yes)
			{
				if (_SelectedIDList == null || !_SelectedIDList.Contains(","))
				{
					btnStoresZonesTypesClear_Click(null, null);
					return;
				}

				if (((RFMButton)sender).Name.Contains("Source"))
				{
					sSelectedStoresZonesTypesSourceIDList = "," + _SelectedIDList;
					txtStoresZonesTypesSourceChoosen.Text = _SelectedText;
					ttToolTip.SetToolTip(txtStoresZonesTypesSourceChoosen, txtStoresZonesTypesSourceChoosen.Text);
				}
				if (((RFMButton)sender).Name.Contains("Target"))
				{
					sSelectedStoresZonesTypesTargetIDList = "," + _SelectedIDList;
					txtStoresZonesTypesTargetChoosen.Text = _SelectedText;
					ttToolTip.SetToolTip(txtStoresZonesTypesTargetChoosen, txtStoresZonesTypesTargetChoosen.Text);
				}

				tabTrafficsFrames.IsNeedRestore = true;
			}

			_SelectedIDList = null;
			_SelectedText = "";
		}

		private void btnStoresZonesTypesClear_Click(object sender, EventArgs e)
		{
			tabTrafficsFrames.IsNeedRestore = true;

			if (((RFMButton)sender).Name.Contains("Source"))
			{
				ttToolTip.SetToolTip(txtStoresZonesTypesSourceChoosen, "�� �������");
				sSelectedStoresZonesTypesSourceIDList = "";
				txtStoresZonesTypesSourceChoosen.Text = "";
			}
			if (((RFMButton)sender).Name.Contains("Target"))
			{
				ttToolTip.SetToolTip(txtStoresZonesTypesTargetChoosen, "�� �������");
				sSelectedStoresZonesTypesTargetIDList = "";
				txtStoresZonesTypesTargetChoosen.Text = "";
			}
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
				RFMMessage.MessageBoxError("������ ��� ��������� ������...");
				return;
			}
			if (oUser.DS.Tables["TableDataTree"].Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("��� ������...");
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

				tabTrafficsFrames.IsNeedRestore = true;
			}
			_SelectedIDList = null;
		}

		private void btnUsersClear_Click(object sender, EventArgs e)
		{
			tabTrafficsFrames.IsNeedRestore = true;

			ttToolTip.SetToolTip(txtUsersChoosen, "�� �������");
			sSelectedUsersIDList = "";
			txtUsersChoosen.Text = "";
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

				tabTrafficsFrames.IsNeedRestore = true;
			}

			_SelectedPackingIDList = null;
			_SelectedPackingAliasText = "";
		}

		private void btnPackingsClear_Click(object sender, EventArgs e)
		{
			tabTrafficsFrames.IsNeedRestore = true;

			ttToolTip.SetToolTip(txtPackingsChoosen, "�� �������");
			sSelectedPackingsIDList = "";
			txtPackingsChoosen.Text = "";
		}

		#endregion

		private void optNotConfirmed_CheckedChanged(object sender, EventArgs e)
		{
			pnlOpgInputsStarted.Enabled = optNotConfirmed.Checked;
		}

		private void optNotSuccess_CheckedChanged(object sender, EventArgs e)
		{
			cboTrafficError.Enabled = optNotSuccess.Checked;
		}

		#endregion

		#region Menu Print

		private void btnPrint_Click(object sender, EventArgs e)
		{
			mnuPrint.Show(btnPrint, new Point());
		}

		private void btnPrint_MouseClick(object sender, MouseEventArgs e)
		{
			mnuPrint.Show(btnPrint, new Point(e.X, e.Y));
		}

		private void mniPrintTrafficBill_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.Rows.Count == 0)
				return;

			repTrafficFrameBill rd = new repTrafficFrameBill();
			PrintTrafficBill((DataDynamics.ActiveReports.ActiveReport3)rd);
		}

		private void PrintTrafficBill(DataDynamics.ActiveReports.ActiveReport3 rpReport)
		{
			// ������ ��������
			TrafficFrame oTrafficPrint = new TrafficFrame();

			int nMarkedCnt = CalcMarkedRows();
			if (nMarkedCnt > 0 &&
				RFMMessage.MessageBoxYesNo("�������� �������: " + nMarkedCnt.ToString() + "\r\n" +
						"���������� ���� ������� ��� ���� ���������� �������?") != DialogResult.Yes)
				return;

			Refresh();
			TrafficPrepareIDList(oTrafficPrint, nMarkedCnt > 0);
			oTrafficPrint.FillData();
			if (oTrafficPrint.MainTable.Rows.Count == 0)
				return;

			// ������ 
			StartForm(new frmActiveReport(oTrafficPrint.MainTable, rpReport));

			// ������� ������
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

		private void mniServiceTrafficProrityUp_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			TrafficPriorityChange(1);
		}

		private void mniServiceTrafficProrityDown_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			TrafficPriorityChange(-1);
		}

		private bool TrafficPriorityChange(int nShift)
		{
			if (grdData.CurrentRow == null)
				return (false);

			// ���������� ������� ��������� �������
			oTrafficCur.ClearError();
			oTrafficCur.ClearData();
			oTrafficCur.ClearFilters();
			oTrafficCur.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			oTrafficCur.FillData();
			if (oTrafficCur.ErrorNumber != 0 || oTrafficCur.MainTable.Rows.Count != 1)
				return (false);

			DataRow r = oTrafficCur.MainTable.Rows[0];

			if (Convert.ToBoolean(r["IsConfirmed"]))
			{
				RFMMessage.MessageBoxError("������� ��� ������������.\n" +
						"��������� ���������� ����������.");
				return (false);
			}

			if (Convert.IsDBNull(r["DateAccept"]))
			{
				RFMMessage.MessageBoxError("������� ��� �����������.\n" +
						"��������� ���������� ����������.");
				return (false);
			}

			int nPriorityCur = (int)r["Priority"];
			if (nShift > 0 && nPriorityCur >= 9)
			{
				RFMMessage.MessageBoxError("������� ��������� �������: " + nPriorityCur.ToString() + "\n" +
						"��������� ���������� ����������.");
				return (false);
			}
			if (nShift < 0 && nPriorityCur <= 1)
			{
				RFMMessage.MessageBoxError("������� ��������� �������: " + nPriorityCur.ToString() + "\n" +
						"��������� ���������� ����������.");
				return (false);
			}

			if (RFMMessage.MessageBoxYesNo(((nShift > 0) ? "��������" : "��������") + " ��������� ������� �� ���������������?") == DialogResult.Yes)
			{
				oTrafficCur.PriorityChange((int)oTrafficCur.ID, nShift);
				if (oTrafficCur.ErrorNumber == 0)
					grdData_Restore();
			}
			return (oTrafficCur.ErrorNumber == 0);
		}

		private void mniServiceTrafficsFrameSetDateAccept_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.CurrentRow == null)
				return;

			// ���������� ������� ��������� �������
			oTrafficCur.ClearError();
			oTrafficCur.ClearData();
			oTrafficCur.ClearFilters();
			oTrafficCur.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			oTrafficCur.FillData();
			if (oTrafficCur.ErrorNumber != 0 || oTrafficCur.MainTable.Rows.Count != 1)
				return;

			DataRow r = oTrafficCur.MainTable.Rows[0];

			if (Convert.ToBoolean(r["IsConfirmed"]))
			{
				RFMMessage.MessageBoxError("������� ��� ������������.");
				return;
			}

			if (Convert.IsDBNull(r["UserID"]))
			{
				RFMMessage.MessageBoxError("��� ������� �� ��������� ������������...");
				return;
			}

			if (!Convert.IsDBNull(r["DateAccept"]))
			{
				RFMMessage.MessageBoxError("������� ��� �����������.");
				return;
			}

			if (RFMMessage.MessageBoxYesNo("�������� ������ ��������� (����������) ������� �� ���������������?") == DialogResult.Yes)
			{
				oTrafficCur.SetDateAccept((int)oTrafficCur.ID);
				if (oTrafficCur.ErrorNumber == 0)
					grdData_Restore();
			}
			return;
		}

		private void mniServiceTrafficsFrameClearDateAccept_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.CurrentRow == null)
				return;

			// ���������� ������� ��������� �������
			oTrafficCur.ClearError();
			oTrafficCur.ClearData();
			oTrafficCur.ClearFilters();
			oTrafficCur.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			oTrafficCur.FillData();
			if (oTrafficCur.ErrorNumber != 0 || oTrafficCur.MainTable.Rows.Count != 1)
				return;

			DataRow r = oTrafficCur.MainTable.Rows[0];

			if (Convert.ToBoolean(r["IsConfirmed"]))
			{
				RFMMessage.MessageBoxError("������� ��� ������������.");
				return;
			}

			if (Convert.IsDBNull(r["DateAccept"]))
			{
				RFMMessage.MessageBoxError("������� ��� �� �����������.");
				return;
			}

			if (RFMMessage.MessageBoxYesNo("�������� �������� � ������ ��������� (����������) ������� �� ��������������� �������\n" +
				"(�����, ������������, ����������)?") == DialogResult.Yes)
			{
				oTrafficCur.ClearDateAccept((int)oTrafficCur.ID);
				if (oTrafficCur.ErrorNumber == 0)
					grdData_Restore();
			}
			return;
		}

		private void mniServiceTrafficsFramesConfirm_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (StartForm(new frmTrafficsFramesEdit()) == DialogResult.Yes)
				grdData_Restore();
		}

		private void mniServiceTrafficsFramesForPickingCreate_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (StartForm(new frmTrafficsFramesForPickingCreate()) == DialogResult.Yes)
				grdData_Restore();
		}


		private void mniServiceConfirmPartial_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.CurrentRow == null)
				return;

			// ���������� ������� ��������� �������
			oTrafficCur.ClearError();
			oTrafficCur.ClearData();
			oTrafficCur.ClearFilters();
			oTrafficCur.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			oTrafficCur.FillData();
			if (oTrafficCur.ErrorNumber != 0 || oTrafficCur.MainTable.Rows.Count != 1)
				return;

			// ������ - ������
			DataRow r = oTrafficCur.MainTable.Rows[0];

			if (Convert.ToBoolean(r["IsConfirmed"]))
			{
				RFMMessage.MessageBoxError("������� ��� ������������.");
				return;
			}
			if (!Convert.IsDBNull(r["DateAccept"]))
			{
				RFMMessage.MessageBoxError("������� ��� �����������.");
				return;
			}

			// ��������� - ����������
			Frame oFramePartial = new Frame();
			oFramePartial.ID = Convert.ToInt32(r["FrameID"]);
			oFramePartial.FillData();
			if (oFramePartial.ErrorNumber != 0 || oFramePartial.MainTable == null ||
				oFramePartial.MainTable.Rows.Count != 1)
			{
				RFMMessage.MessageBoxError("������ ��� ��������� ������ � ����������...");
				return;
			}
			oFramePartial.FillTableFramesContents((int)oFramePartial.ID);
			if (oFramePartial.ErrorNumber != 0 || oFramePartial.TableFramesContents == null)
			{
				RFMMessage.MessageBoxError("������ ��� ��������� ������ � ���������� ����������...");
				return;
			}
			if (oFramePartial.TableFramesContents.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("��������� �� �������� �������...\n" +
					"������������� ��������������� � ��������� ������������� ���������� ������ ����������.");
				return;
			}
			if (oFramePartial.TableFramesContents.Rows.Count > 1)
			{
				RFMMessage.MessageBoxError("��������� �������� ������ ������ ������������ ������...\n" + 
					"������������� ��������������� � ��������� ������������� ���������� ������ ����������.");
				return;
			}

			// ������ - ������ � ���������� 
			DataRow cc = oFramePartial.TableFramesContents.Rows[0];

			// ������ � ���������� 
			nPartialQntInFrame = Convert.ToDecimal(cc["Qnt"]);
			nPartialInBox = Convert.ToDecimal(cc["InBox"]);
			bPartialWeighting = Convert.ToBoolean(cc["Weighting"]);
			bPartialDecimalInBox = ((int)nPartialInBox != nPartialInBox);

			string sPartialGoodAlias = cc["GoodAlias"].ToString() + 
				((bPartialWeighting || bPartialWeighting) 
					? " (" + nPartialInBox.ToString("#####0.000") + " �� � ���.)" 
					: " (" + nPartialInBox.ToString("#####0") + " ��. � ���.)"); 

			// �������� ������ - ������, ������ ������� (?)
			Cell oCellFinishPartial = new Cell();
			oCellFinishPartial.ID = Convert.ToInt32(r["CellTargetID"]);
			oCellFinishPartial.FillData();
			if (oCellFinishPartial.ErrorNumber != 0 || oCellFinishPartial.MainTable == null ||
				oCellFinishPartial.MainTable.Rows.Count != 1)
			{
				RFMMessage.MessageBoxError("������ ��� ��������� ������ � �������� ������...");
				return;
			}

			// ������ - ������
			DataRow c = oCellFinishPartial.MainTable.Rows[0];

			if (!Convert.IsDBNull(c["ForFrames"]) && Convert.ToBoolean(c["ForFrames"]))
			{
				RFMMessage.MessageBoxError("�������� ������ ������������� ��� �����������...\n" + 
					"������������� ��������������� � ��������� ������������� ���������� ������ ����������.");
				return;
			}
			if (!Convert.ToBoolean(c["ForPicking"]))
			{
				RFMMessage.MessageBoxError("�������� ������ �� �������� ������� �������...\n" +
					"������������� ��������������� � ��������� ������������� ���������� ������ ����������.");
				return;
			}
			if (Convert.ToDecimal(c["MaxPalletQnt"]) >= 1)
			{
				if (RFMMessage.MessageBoxYesNo("����������� �������� ������ - �� ����� �������.\n" +
						"���-���� ��������� ������������� ��������������� � ��������� ������������� ���������� ������?") != DialogResult.Yes)
					return;
			}

			if (RFMMessage.MessageBoxYesNo("����������� ���������� ��������������� � ��������� ���������� ������������� � �������� ������ ������\n" + 
					"(��� ���������� ����� ��������� ����� ����� � ������� ����� �������� ���������������)?") == DialogResult.Yes)
			{
				nCellFinishID = Convert.ToInt32(r["CellTargetID"]);

				// ������ ����������
				tcList.Enabled = false;
				btnAdd.Enabled =
				btnEdit.Enabled =
				btnConfirm.Enabled =
				btnDelete.Enabled =
				btnPrint.Enabled =
				btnService.Enabled =
					false; 

				lblPartialGoodAlias.Text = sPartialGoodAlias;
				int nPartialBox_ = 0;
				decimal nPartialRestQnt_ = 0;
				if (bPartialWeighting)
				{
					nPartialBox_ = 0;
					nPartialRestQnt_ = nPartialQntInFrame;
					numPartialBox.Enabled = false;
					numPartialRestQnt.DecimalPlaces = 3; 
				}
				else
				{
					nPartialBox_ = Convert.ToInt32(Math.Floor(nPartialQntInFrame / nPartialInBox));
					nPartialRestQnt_ = nPartialQntInFrame - nPartialBox_ * nPartialInBox;
					numPartialBox.Enabled = true;
					numPartialRestQnt.DecimalPlaces = ((bPartialDecimalInBox) ? 3 : 0); 
				}
				numPartialBox.Value = nPartialBox_;
				numPartialRestQnt.Value = nPartialRestQnt_;
				
				pnlPartial.Left = btnService.Left - btnPartialGo.Left - btnPartialGo.FlatAppearance.BorderSize * 2;
				pnlPartial.Top = btnService.Top - pnlPartial.Height - btnService.FlatAppearance.BorderSize * 4;
				pnlPartial.Visible = true; 
				pnlPartial.Enabled =
					true;

				numPartialBox.Select(); 
				// ���� ���� 
			}
			return;
		}

		private void btnPartialGo_Click(object sender, EventArgs e)
		{
			nPartialQnt = numPartialBox.Value * nPartialInBox + numPartialRestQnt.Value;
			if (nPartialQnt == 0)
			{
				RFMMessage.MessageBoxError("�� ������� ������������ ���������� ������...");
				return;
			}

			if (nPartialQnt > nPartialQntInFrame)
			{
				RFMMessage.MessageBoxError("������������ ���������� ��������� ���������� ������ �� �������...");
				return; 
			}

			if (Math.Round((decimal)nPartialQnt, 3) == Math.Round(nPartialQntInFrame, 3))
			{
				if (RFMMessage.MessageBoxYesNo("������������ ���������� ����� ���������� ������ �� �������.\n" + 
					"���� ����� ����� ��������� � �������� ������, ������ ����� ��������!\n" + 
					"���-���� ����������?") != DialogResult.Yes) 
					return;
			}

			nNewTrafficID = null;
			if (TrafficFrameConfirmPartial())
			{
				pnlPartial.Visible = false;
				string sText = "�������� ������������.\n";
				if (nNewTrafficID.HasValue && nNewTrafficID > 0)
					sText += "������� ����� �������� ��������������� ����������.";
				else
					sText += "��������� ��������.";
				RFMMessage.MessageBoxInfo(sText); 
				grdData_Restore();
			}
			else
			{
				pnlPartial.Visible = false;
				grdData.IsLockRowChanged = false;
				grdData_CurrentRowChanged(null);
			}

			tcList.Enabled = true;
		}

		private void btnPartialExit_Click(object sender, EventArgs e)
		{
			nPartialQnt = null;
			pnlPartial.Visible = false;
			tcList.Enabled = true;
			// �������� ������ 
			grdData.IsLockRowChanged = false;
			grdData_CurrentRowChanged(null);
		}

		private bool TrafficFrameConfirmPartial()
		{
			oTrafficCur.ConfirmPartialData((int)oTrafficCur.ID, (int)nCellFinishID, true, null, (decimal)nPartialQnt, ref nNewTrafficID);
			return (oTrafficCur.ErrorNumber == 0);
		}

		#endregion

		#region Terms Clear

		private void btnClearTerms_Click(object sender, EventArgs e)
		{
			dtrDates.dtpBegDate.Value = DateTime.Now.Date.AddDays(-7);
			dtrDates.dtpEndDate.Value = DateTime.Now.Date.AddDays(1);

			txtBarCode.Text = "";
			txtCellSourceAddress.Text = "";
			txtCellSourceBarCode.Text = "";
			txtCellTargetAddress.Text = "";
			txtCellTargetBarCode.Text = "";
			txtFrameBarCode.Text = "";

			btnStoresZonesClear_Click(btnStoresZonesSourceClear, null);
			btnStoresZonesTypesClear_Click(btnStoresZonesTypesSourceClear, null);
			btnStoresZonesClear_Click(btnStoresZonesTargetClear, null);
			btnStoresZonesTypesClear_Click(btnStoresZonesTypesTargetClear, null);

			//optStatus_Any.Checked = true;
			optNotConfirmed.Checked = true;
			optNotConfirmed_CheckedChanged(null, null);
			optNotSuccess_CheckedChanged(null, null);
			cboTrafficError.SelectedIndex = -1;

			txtInputBarCode.Text = "";
			txtOutputBarCode.Text = "";

			btnUsersClear_Click(null, null);
			btnPackingsClear_Click(null, null);

			if (Control.ModifierKeys == Keys.Shift)
			{
				dtrDates.dtpBegDate.HideControl(false);
				dtrDates.dtpEndDate.HideControl(false);
				optStatus_Any.Checked = true;
			}

			tabTrafficsFrames.IsNeedRestore = true;
		}

		#endregion

		
	}
}