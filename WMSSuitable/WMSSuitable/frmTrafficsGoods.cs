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
	public partial class frmTrafficsGoods : RFMFormChild
	{
		private TrafficGood oTrafficList;
		private TrafficGood oTrafficCur;

		// ��� ��������
		public string _SelectedIDList;
		public string _SelectedText;

		public string _SelectedPackingIDList = null;
		public string _SelectedPackingAliasText = "";
		private string sSelectedPackingIDList = "";

		private string sSelectedStoresZonesSourceIDList = "";
		private string sSelectedStoresZonesTypesSourceIDList = "";
		private string sSelectedStoresZonesTargetIDList = "";
		private string sSelectedStoresZonesTypesTargetIDList = "";

		private string sSelectedUsersIDList = "";

		public int? _SelectedID;


		public frmTrafficsGoods()
		{
			oTrafficList = new TrafficGood();
			oTrafficCur = new TrafficGood();
			if (oTrafficList.ErrorNumber != 0 ||
				oTrafficCur.ErrorNumber != 0)
			{
				IsValid = false;
			}

			if (IsValid)
			{
				InitializeComponent();
			}
		}

		private void frmTrafficsGoods_Load(object sender, EventArgs e)
		{
			RFMCursorWait.Set(true);

			grcQntWished.AgrType =
			grcBoxWished.AgrType =
			grcQntConfirmed.AgrType =
			grcBoxConfirmed.AgrType =
				EnumAgregate.Sum;

			btnClearTerms_Click(null, null);

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
			btnService.Enabled = false;
			txtBarCode.Select();
			return true;
		}

		private bool tabTrafficsGoods_Restore()
		{
			grdData_Restore();
			btnAdd.Enabled = true;
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
			return true;
		}

		private void tcList_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (tcList.SelectedTab.Name)
			{
				case "tabTerms":
					tabTerms_Restore();
					break;
				case "tabTrafficsGoods":
					btnAdd.Enabled = true;
					grdData.Select();
					break;
			}
		}

		#endregion Tab Restore

		#region Buttons

		private void btnAdd_Click(object sender, EventArgs e)
		{
			int? nTrafficOldID = null;
			// ���� ����� �� ������ c ��������� ��������������, ������ ����� �������� ����� ��
			if (grdData.CurrentRow != null && !grdData.IsStatusRow(grdData.CurrentRow.Index))
			{
				DataGridViewRow r = grdData.CurrentRow;
				if (r.Cells["grcTrafficGoodErrorName"].Value != null &&
					r.Cells["grcTrafficGoodErrorName"].Value.ToString().Length > 0 &&
					r.Cells["grcDateConfirm"].Value != DBNull.Value)
				{
					if (RFMMessage.MessageBoxYesNo("������� �������� ����������� �������/���� �� ������ �������?") == DialogResult.Yes)
					{
						nTrafficOldID = Convert.ToInt32(r.Cells["grcID"].Value);
					}
				}
			}

			if (StartForm(new frmTrafficsGoodsManual(nTrafficOldID)) == DialogResult.Yes)
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
				RFMMessage.MessageBoxError("������� ��� �����������.\n" +
						"��������� ����������.");
				return;
			}

			if (StartForm(new frmTrafficsGoodsEdit((int)oTrafficCur.ID)) == DialogResult.Yes)
				grdData_Restore();
		}

		private void btnConfirm_Click(object sender, EventArgs e)
		{
			if (grdData.CurrentRow == null)
				return;

			if (RFMMessage.MessageBoxYesNo("�������� ������� ���������� �������� ����������� �������/����\n(����� ����������� � ������-���������)?") == DialogResult.Yes)
			{
				oTrafficCur.ClearError();
				oTrafficCur.ClearData();
				oTrafficCur.ClearFilters();
				oTrafficCur.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
				oTrafficCur.FillData();
				if (oTrafficCur.MainTable.Rows.Count > 0)
				{
					decimal nQntConfirmed = Convert.ToDecimal(oTrafficCur.MainTable.Rows[0]["QntWished"]);
					oTrafficCur.ConfirmData((int)oTrafficCur.ID, nQntConfirmed, false, true, null);
					if (oTrafficCur.ErrorNumber == 0)
						grdData_Restore();
				}
			}
		}

		private void btnDelete_Click(object sender, EventArgs e)
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
						"�������� ����������.");
				return;
			}

			if (r["DateAccept"] != DBNull.Value)
			{
				RFMMessage.MessageBoxError("������� ��� �����������.\n" +
						"�������� ����������.");
				return;
			}

			if (RFMMessage.MessageBoxYesNo("������� ������� �� ����������� �������/����?") == DialogResult.Yes)
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

		public void TrafficPrepareIDList(TrafficGood oTraffic, bool bMultiSelect)
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

		#region RowEnter, CellsFormatting

		private void grdData_RowEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (e == null || e.RowIndex < 0)
				return;

			btnPrint.Enabled =
			btnService.Enabled = 
				true;

			if (grdData.IsStatusRow(e.RowIndex))
			{
				oTrafficCur.ID = 0;
				btnConfirm.Enabled = 
				btnEdit.Enabled = 
					false;
			}
			else
			{
				DataGridViewRow r = grdData.Rows[e.RowIndex];
				oTrafficCur.ID = (int)r.Cells["grcID"].Value;
				bool isConfirmed = (bool)r.Cells["grcIsConfirmed"].Value;
				bool isAccepted = (r.Cells["grcDateAccept"].Value != null &&
									r.Cells["grcDateAccept"].Value != DBNull.Value);
				bool isForOutput = (r.Cells["grcOutputID"].Value != null &&
					r.Cells["grcOutputID"].Value != DBNull.Value);
				bool isFromFrame = (r.Cells["grcFrameID"].Value != DBNull.Value);
				btnConfirm.Enabled = !isConfirmed && (!isForOutput || isFromFrame);
				btnEdit.Enabled = !isConfirmed && !isAccepted && (!isForOutput || isFromFrame);
				btnDelete.Enabled = !isConfirmed && !isAccepted;
			}
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
					case "grcQntWished":
					case "grcQntConfirmed":
					case "grcInBox":
						e.CellStyle.Format = "### ### ### ###";
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
				case "grcQntWished":
				case "grcInBox":
				case "grcQntConfirmed":
					DataGridViewRow r = grdData.Rows[e.RowIndex];
					if (!Convert.IsDBNull(r.Cells["grcWeighting"].Value) &&
						Convert.ToBoolean(r.Cells["grcWeighting"].Value) ||
						!Convert.IsDBNull(e.Value) && Convert.ToDecimal(e.Value) != Convert.ToInt32(e.Value))
						e.CellStyle.Format = "### ### ### ###.000";
					else
						e.CellStyle.Format = "### ### ### ###";
					break;
			}

			if (grdData.Columns[e.ColumnIndex].Name == "grcQntConfirmed")
			{
				if (Convert.ToDecimal(e.Value) == 0)
					e.Value = "";
			}
		}

		#endregion

		#region Restore

		private bool grdData_Restore()
		{
			RFMCursorWait.Set(true);
			RFMCursorWait.LockWindowUpdate(FindForm().Handle);

			oTrafficCur.ID = null;

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
			oCellTarget.ClearData();
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

			// ��������� ��������
			if (optNotConfirmed.Checked)
			{
				oTrafficList.FilterConfirmed = false;
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
					sInputBarCode = sInputBarCode + "," + r["ID"].ToString();
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
					sOutputBarCode = sOutputBarCode + "," + r["ID"].ToString();
				}
				oTrafficList.FilterOutputsList = sOutputBarCode;
			}

			// ������������
			if (sSelectedUsersIDList.Length > 0)
			{
				oTrafficList.FilterUsersList = sSelectedUsersIDList;
			}
			// ��������� ������
			if (sSelectedPackingIDList.Length > 0)
			{
				oTrafficList.FilterPackingsList = sSelectedPackingIDList;
			}
			//
			
			grdData.GetGridState();

			oTrafficList.FillData();

			grdData.IsLockRowChanged = true;
			grdData.Restore(oTrafficList.MainTable);

			//grdData.GridSource.Sort = "ID desc";
			
			RFMCursorWait.LockWindowUpdate(IntPtr.Zero);
			RFMCursorWait.Set(false);

			return (oTrafficList.ErrorNumber == 0);
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

				tabTrafficsGoods.IsNeedRestore = true;
			}

			_SelectedIDList = null;
			_SelectedText = "";
		}

		private void btnStoresZonesClear_Click(object sender, EventArgs e)
		{
			tabTrafficsGoods.IsNeedRestore = true;

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

				tabTrafficsGoods.IsNeedRestore = true;
			}

			_SelectedIDList = null;
			_SelectedText = "";
		}

		private void btnStoresZonesTypesClear_Click(object sender, EventArgs e)
		{
			tabTrafficsGoods.IsNeedRestore = true;

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

				tabTrafficsGoods.IsNeedRestore = true;
			}
			_SelectedIDList = null;
		}

		private void btnUsersClear_Click(object sender, EventArgs e)
		{
			tabTrafficsGoods.IsNeedRestore = true;

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

				sSelectedPackingIDList = "," + _SelectedPackingIDList;
				txtPackingsChoosen.Text = _SelectedPackingAliasText;
				ttToolTip.SetToolTip(txtPackingsChoosen, txtPackingsChoosen.Text);

				tabTrafficsGoods.IsNeedRestore = true;
			}

			_SelectedPackingIDList = null;
			_SelectedPackingAliasText = "";
		}

		private void btnPackingsClear_Click(object sender, EventArgs e)
		{
			tabTrafficsGoods.IsNeedRestore = true;

			ttToolTip.SetToolTip(txtPackingsChoosen, "�� �������");
			sSelectedPackingIDList = "";
			txtPackingsChoosen.Text = "";
		}

		#endregion

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

		private void mniPrintTrafficBill_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.Rows.Count == 0)
				return;

			repTrafficGoodBill rd = new repTrafficGoodBill();
			PrintTrafficBill((DataDynamics.ActiveReports.ActiveReport3)rd);
		}

		private void PrintTrafficBill(DataDynamics.ActiveReports.ActiveReport3 rpReport)
		{
			// ������ ��������
			TrafficGood oTrafficPrint = new TrafficGood();
			int nMarkedCnt = CalcMarkedRows();
			if (nMarkedCnt > 0 &&
				RFMMessage.MessageBoxYesNo("�������� �������: " + nMarkedCnt.ToString() + "\r\n" +
						"���������� ���� ������� ��� ���� ���������� �������?") != DialogResult.Yes)
				return;
			TrafficPrepareIDList(oTrafficPrint, nMarkedCnt > 0);
			oTrafficPrint.FillData();
			if (oTrafficPrint.MainTable.Rows.Count == 0)
				return;

			DataView dv = new DataView(oTrafficPrint.MainTable);
			dv.Sort = "OutputID, CellTargetAddress, StoreZoneSourceID, CellSourceRank, CellSourceAddress, GoodAlias";
			DataTable tTable = dv.ToTable();

			// ������ 
			StartForm(new frmActiveReport(tTable, rpReport));
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

			if ((bool)r["IsConfirmed"])
			{
				RFMMessage.MessageBoxError("������� ��� ������������.\n" +
						"��������� ���������� ����������.");
				return (false);
			}

			if (r["DateAccept"] != DBNull.Value)
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

		private void mniServiceTrafficsGoodSetDateAccept_Click(object sender, EventArgs e)
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

			if (!Convert.IsDBNull(r["DateAccept"]))
			{
				RFMMessage.MessageBoxError("������� ��� �����������.");
				return;
			}

			if (Convert.IsDBNull(r["UserID"]))
			{
				RFMMessage.MessageBoxError("��� ������� �� ��������� ���������-�����������...");
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

		private void mniServiceTrafficsGoodClearDateAccept_Click(object sender, EventArgs e)
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

			if (RFMMessage.MessageBoxYesNo("�������� �������� � ������ ��������� (����������) ������� �� ����������� �������/����\n" +
				"(�����, ���������, ����������)?") == DialogResult.Yes)
			{
				oTrafficCur.ClearDateAccept((int)oTrafficCur.ID);
				if (oTrafficCur.ErrorNumber == 0)
					grdData_Restore();
			}
			return;
		}

		private void mniServiceTrafficGoodChangeUser_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.DataSource == null || grdData.Rows.Count == 0)
				return;

			// ������� ������ ��� ��� ����������
			string sText = "���������������� ����������, ������������ ";
			int nCnt = CalcMarkedRows();
			if (nCnt == 0)
			{
				if (grdData.CurrentRow == null || grdData.IsStatusRow(grdData.CurrentRow.Index))
					return; 

				sText += "������� �����������";
				nCnt = 1;
			}
			else
			{ 
				sText += RFMUtilities.Declen(nCnt, "���������� �����������", "���������� �����������", "���������� �����������");
			}
			sText += " �������/����?";
			if (RFMMessage.MessageBoxYesNo(sText) == DialogResult.Yes)
			{
				// ������ ����������� 
				User oUser = new User();
				oUser.FilterActual = true;
				oUser.FillData();
				if (oUser.ErrorNumber != 0 || oUser.MainTable == null)
				{
					RFMMessage.MessageBoxError("������ ��� ��������� ������ � �����������...");
					return;
				}
				if (oUser.MainTable.Rows.Count == 0)
				{
					RFMMessage.MessageBoxError("��� ������ � �����������...");
					return;
				}

				int nNewUserID = 0;
				string sNewUserName = "";
				_SelectedID = null;
				if (StartForm(new frmSelectID(this, oUser.MainTable, "Name", "���������", "���������, ����������� �����������")) == DialogResult.Yes)
				{
					if (_SelectedID.HasValue)
					{
						nNewUserID = (int)_SelectedID;
						sNewUserName = _SelectedText;
					}
				}
				if (nNewUserID == 0)
					return;

				TrafficGood oTrafficGoodForChangeUser = new TrafficGood();
				TrafficPrepareIDList(oTrafficGoodForChangeUser, true);
				if (!oTrafficGoodForChangeUser.ID.HasValue && 
					(oTrafficGoodForChangeUser.IDList == null || oTrafficGoodForChangeUser.IDList.Length == 0))
				{
					oTrafficGoodForChangeUser.ID = Convert.ToInt32(grdData.CurrentRow.Cells["grcID"].Value);
				}
				oTrafficGoodForChangeUser.FillData();
				if (oTrafficGoodForChangeUser.ErrorNumber != 0 || oTrafficGoodForChangeUser.MainTable == null)
				{
					RFMMessage.MessageBoxError("������ ��� ��������� ������ � ������������ �������/����...");
					return;
				}
				if (oTrafficGoodForChangeUser.MainTable.Rows.Count == 0)
				{
					RFMMessage.MessageBoxError("��� ������ � ��������� ������������ �������/����...");
					return;
				}

				// ��� ���� ������ � ����������� � ��������� ������������?
				int nOldUsersCnt = 0;
				foreach (DataRow tr in oTrafficGoodForChangeUser.MainTable.Rows)
				{
					if (!Convert.IsDBNull(tr["UserID"]))
						nOldUsersCnt++;
				}
				if (nOldUsersCnt > 0)
				{
					if (oTrafficGoodForChangeUser.MainTable.Rows.Count == 1)
					{
						// ���� �����������
						if (RFMMessage.MessageBoxYesNo("��� ���������� ����������� ��� ��������������� ���������.\n" +
							"���-���� ���������������� ������ ���������� \"" + sNewUserName + "\"?") != DialogResult.Yes)
							return;
					}
					else
					{ 
						// �� ���� �����������
						if (RFMMessage.MessageBoxYesNo("��� " + nOldUsersCnt.ToString().Trim() + " �� " + RFMUtilities.Declen(nCnt, " ���������� �����������", "��������� �����������", "��������� �����������") + " �������/���� ��� ��������������� ���������.\n" +
							"���-���� ���������������� ������ ���������� \"" + sNewUserName + "\" ��� ���� " + RFMUtilities.Declen(nCnt, " ���������� �����������", "��������� �����������", "��������� �����������") + " �������/����?") != DialogResult.Yes)
							return;
					}
				}

				foreach (DataRow tr in oTrafficGoodForChangeUser.MainTable.Rows)
				{ 
					oTrafficGoodForChangeUser.UserChange((int)tr["ID"], nNewUserID);
				}

				grdData_Restore();
			}
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

			btnStoresZonesClear_Click(btnStoresZonesSourceClear, null);
			btnStoresZonesTypesClear_Click(btnStoresZonesTypesSourceClear, null);
			btnStoresZonesClear_Click(btnStoresZonesTargetClear, null);
			btnStoresZonesTypesClear_Click(btnStoresZonesTypesTargetClear, null);

			optNotConfirmed.Checked = true;

			txtInputBarCode.Text = "";
			txtOutputBarCode.Text = "";

			btnUsersClear_Click(null, null);
			btnPackingsClear_Click(null, null);

			if (Control.ModifierKeys == Keys.Shift)
			{
				optStatus_Any.Checked = true;
				dtrDates.dtpBegDate.HideControl(false);
				dtrDates.dtpEndDate.HideControl(false);
			}

			tabTrafficsGoods.IsNeedRestore = true;
		}

		#endregion

	}
}