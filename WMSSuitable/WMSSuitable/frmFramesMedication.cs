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
	public partial class frmFramesMedication : RFMFormChild
	{
		protected Frame oFrame;
		protected int? nOwnerCurID = null;
		protected int? nGoodStateCurID = null;

		protected Good oGood;
		protected Partner oOwner;
		protected GoodState oGoodState;

		protected Cell oCell;
		protected int? nCellCurID = null;
		public int? _SelectedCellID;

		protected Good oGoodAdd; // ��� ����������
		public int? nPackingAddID;
		public int? _SelectedPackingID;

		protected string _cMode = "";

		protected bool _bLoaded = false; 

		public frmFramesMedication(int nFrameID)
		{
			oFrame = new Frame();
			oGood = new Good();
			oOwner = new Partner();
			oGoodState = new GoodState();
			oCell = new Cell();
			nCellCurID = null;
			oGoodAdd = new Good();

			if (oFrame.ErrorNumber != 0 ||
				oGood.ErrorNumber != 0 ||
				oOwner.ErrorNumber != 0 ||
				oGoodState.ErrorNumber != 0 ||
				oCell.ErrorNumber != 0 ||
				oGoodAdd.ErrorNumber != 0)
			{
				IsValid = false;
			}

			if (IsValid)
			{
				InitializeComponent();
				oFrame.ID = nFrameID;
			}
		}
		
		private void frmFramesMedication_Load(object sender, EventArgs e)
		{
			bool lResult = true;

			lblAction.Text = "";
			grcBoxQnt.AgrType = 
			grcPalQnt.AgrType = 
			grcQnt.AgrType = 
				EnumAgregate.Sum;
			numBoxQnt.Minimum = numRestQnt.Minimum = 0; 
			
			// ��������� ����������
			oFrame.FillData();
			if (oFrame.ErrorNumber != 0)
			{
				RFMMessage.MessageBoxError("������ ��� ��������� ������ � ����������...");
				Dispose();
			}

			DataRow r = oFrame.MainTable.Rows[0];
			if (r == null)
			{
				RFMMessage.MessageBoxError("�� ��������� ���������...");
				lResult = false;
			}

			if (lResult)
			{
				lblCellAddress.Text = "_�� ����������";
				// � ������?
				if (r["CellID"] == DBNull.Value || r["CellID"] == null)
				{
					RFMMessage.MessageBoxAttention("�� ���������� ������, � ������� ��������� ���������...");
					nCellCurID = oCell.ID = null;
					//lResult = false;
				}
				else
				{
					nCellCurID = Convert.ToInt32(r["CellID"]);
					oCell.ID = nCellCurID;
					oCell.FillData();
					if (oCell.MainTable.Rows.Count == 1)
					{
						lblCellAddress.Text = oCell.MainTable.Rows[0]["Address"].ToString() +
								" (" + oCell.MainTable.Rows[0]["StoreZoneName"].ToString() + ")";
					}
					else
					{
						RFMMessage.MessageBoxInfo("��������!\n\n�� ������� ������ � ����� " + r["CellID"].ToString() + ",\n" + 
								"� ������� ��������������� ���������...");
						//lResult = false;
					}
				}
			}

			if (lResult)
			{
				lblFrameID.Text = r["ID"].ToString();

				// ���������� ����������
				oFrame.FillTableFramesContents(oFrame.ID);
				if (oFrame.ErrorNumber != 0)
					lResult = false;
			}

			if (lResult)
			{
				oFrame.TableFramesContents.PrimaryKey = null;
				oFrame.TableFramesContents.Columns["ID"].Unique = false;

				oFrame.TableFramesContents.Columns.Add("PackingNew", Type.GetType("System.Boolean"));
				oFrame.TableFramesContents.Columns.Add("Changes", Type.GetType("System.String"));
				foreach (DataRow rd in oFrame.TableFramesContents.Rows)
				{
					rd["Changes"] = "";
					rd["PackingNew"] = false;
				}

				grdFramesContents_Restore();
			}

			if (lResult)
			{
				//  ���������� cbo-��������������� 
				lResult = cboGood_Restore() &&
						  cboOwner_Restore() &&
						  cboGoodState_Restore();
				if (!lResult)
				{
					RFMMessage.MessageBoxError("������ ��� ���������� ��������������� (������)...");
				}
			}

			if (lResult)
			{
				cboOwner.SelectedValue = -1;
				cboGoodState.SelectedValue = -1;
				if (r["OwnerID"] != DBNull.Value && r["OwnerID"] != null)
				{
					nOwnerCurID = Convert.ToInt32(r["OwnerID"]);
					cboOwner.SelectedValue = Convert.ToInt32(r["OwnerID"]);
				}
				if (r["GoodStateID"] != DBNull.Value && r["GoodStateID"] != null)
				{
					nGoodStateCurID = Convert.ToInt32(r["GoodStateID"]);
					cboGoodState.SelectedValue = Convert.ToInt32(r["GoodStateID"]);
				}

				cboGood.SelectedValue = -1;
				txtGood.Text = "";
				numBoxQnt.Value = 0;
				numRestQnt.Value = 0; 
				dtpDateValid.Value = DateTime.Now.Date;
			}

			// ���� ���-�� �� ���������� - �����
			if (!lResult)
			{
				Dispose();
			}

			pnlDataChange.Enabled = false;
			btnAdd.Enabled = true;
			btnEdit.Enabled = false;
			btnDelete.Enabled = false;
			btnGridSave.Enabled = false;
			btnGridUndo.Enabled = false;

			grdFramesContents.Select();

			_bLoaded = true;
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
			int nFrameID = Convert.ToInt32(oFrame.ID);

			// ������ ��������
			if (cboGoodState.SelectedIndex < 0 || cboGoodState.SelectedValue == null)
			{
				RFMMessage.MessageBoxError("�� ������� ��������� ������� � ����������...");
				return;
			}

			if (oCell.ID == null || lblCellAddress.Text.StartsWith("_��"))
			{
				RFMMessage.MessageBoxError("�� ������� ������, � ������� ����������� ���������...");
				btnCellChange_Click(null, null);
				return;
			}

			if (oFrame.MainTable.Rows[0]["PalletTypeID"] == DBNull.Value ||
				oFrame.MainTable.Rows[0]["PalletTypeID"] == null)
			{
				RFMMessage.MessageBoxError("�� ���������� ��� �������/������ ����������...");
				btnFrameEdit_Click(null, null);
				return;
			}

			if (oFrame.TableFramesContents.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("� ���������� ��� �� ������ ������.\n������ ���������...");
				return;
			}

			if (cboOwner.SelectedIndex < 0 || cboOwner.SelectedValue == null)
			{
				if (RFMMessage.MessageBoxYesNo("�� ������ ��������� ���������� (����� �����)...\n���-���� ���������?") != DialogResult.Yes)
					return;
			}

			int? nOwnerID = null;
			if (cboOwner.SelectedValue != null && cboOwner.SelectedIndex >= 0)
				nOwnerID = Convert.ToInt32(cboOwner.SelectedValue);
			int? nGoodStateID = null;
			if (cboGoodState.SelectedValue != null && cboGoodState.SelectedIndex >= 0)
				nGoodStateID = Convert.ToInt32(cboGoodState.SelectedValue);
			
			int nCntNoChanges = 0;
			int nCntAdd = 0;
			int nCntDel = 0;
			int nCntEdt = 0;
			foreach (DataRow r in oFrame.TableFramesContents.Rows)
			{
				if (r["Changes"].ToString() == "D")
				{
					nCntDel++;
				}
				if (r["Changes"].ToString() == "A")
				{
					nCntAdd++;
				}
				if (r["Changes"].ToString() == "E")
				{
					nCntEdt++;
				}
				if (r["Changes"].ToString().Length == 0)
				{
					nCntNoChanges++;
				}
			}
			if (nCntAdd == 0 && nCntDel == 0 && nCntEdt == 0 &&
				nOwnerCurID == nOwnerID && nGoodStateCurID == nGoodStateID && 
				nCellCurID == oCell.ID)
			{
				RFMMessage.MessageBoxError("��� ��������� � ���������� ����������.\n������ ���������...");
				return;
			}

			string sText = "��������� " + nFrameID.ToString() + "\n";
			if (nCntNoChanges > 0)
			{
				sText = sText + "\n� ���������� ��������� ������: " + nCntNoChanges.ToString();
			}
			if (nCntDel > 0)
			{
				sText = sText + "\n�� ���������� ��������� ������: " + nCntDel.ToString();
			}
			if (nCntAdd > 0)
			{
				sText = sText + "\n� ��������� ����������� ������: " + nCntAdd.ToString();
			}
			if (nCntEdt > 0)
			{
				sText = sText + "\n� ���������� ���������� ����������/���� �������� �������: " + nCntEdt.ToString();
			}
			sText = sText + "\n\n���������?";
			if (RFMMessage.MessageBoxYesNo(sText) == DialogResult.Yes)
			{
				int? nUserID = ((RFMFormMain)Application.OpenForms[0]).UserID; 
				int? nDeviceID = null;
				int nCellID = Convert.ToInt32(oCell.ID);
				string sNoteManual = txtNoteManual.Text.Trim();
				// ���������� ����������
				oFrame.Medication(nFrameID, oFrame.TableFramesContents, nOwnerID, nGoodStateID, nCellID, nUserID, nDeviceID, sNoteManual);
				//
				if (oFrame.ErrorNumber == 0)
				{
					DialogResult = DialogResult.Yes;
					Dispose();
				}
			}
		}

	#region Restore

		private bool cboGood_Restore()
		{
			oGood.FillData(); 
			cboGood.ValueMember   = oGood.MainTable.Columns["PackingID"].Caption;
			cboGood.DisplayMember = oGood.MainTable.Columns["PackingAlias"].Caption;
			cboGood.DataSource	  = oGood.MainTable;
			return (oGood.ErrorNumber == 0);
		}

		private bool cboOwner_Restore()
		{
			oOwner.FilterOwner = true;
			oOwner.FilterSeparatePicking = true;
			if (cboOwner.IsActualOnly)
				oOwner.FilterActual = true;
			else
				oOwner.FilterActual = null;
			oOwner.FillData();
			cboOwner.DataSource = oOwner.MainTable;
			cboOwner.ValueMember = oOwner.ColumnID;
			cboOwner.DisplayMember = oOwner.ColumnName;
			return (oOwner.ErrorNumber == 0);
		}

		private bool cboGoodState_Restore()
		{
			oGoodState.FillData();
			cboGoodState.DataSource = oGoodState.MainTable;
			cboGoodState.ValueMember = oGoodState.ColumnID;
			cboGoodState.DisplayMember = oGoodState.ColumnName;
			return (oGoodState.ErrorNumber == 0);
		}

		private void grdFramesContents_Restore()
		{
			grdFramesContents.Restore(oFrame.TableFramesContents);
		}

		private void btnPackings_Click(object sender, EventArgs e)
		{
			_SelectedPackingID = null;
			nPackingAddID = null;
			pnlDataChange.Enabled = false;
			if (StartForm(new frmSelectOnePacking(this, false)) == DialogResult.Yes)
			{
				if (_SelectedPackingID != null)
				{
					nPackingAddID = _SelectedPackingID;
					cboGood.SelectedValue = Convert.ToInt32(_SelectedPackingID);
					txtGood.Text = cboGood.Text;
				}
				_SelectedPackingID = null;

				oGoodAdd.PackingID = nPackingAddID;
				oGoodAdd.FillData();

				DataRow r = oGoodAdd.MainTable.Rows[0];
				if (r != null)
				{
					txtGood.Text = r["PackingAlias"].ToString();
					// ���� ��������
					if (r["Retention"] != DBNull.Value && r["Retention"] != null)
					{
						dtpDateValid.Value = DateTime.Now.Date.AddDays(Convert.ToInt32(r["Retention"]));
					}
					// �������
					decimal nInBox = 1;
					bool bDecimalInBox = false;
					bool bWeighting = false;
					if (r["InBox"] != DBNull.Value && r["InBox"] != null)
					{
						nInBox = (decimal)r["InBox"];
						bDecimalInBox = ((int)nInBox != nInBox);
					}
					if (r["Weighting"] != DBNull.Value && r["Weighting"] != null)
					{
						bWeighting = (bool)r["Weighting"]; 
					}
					numRestQnt.DecimalPlaces = ((bWeighting || bDecimalInBox) ? 3 : 0);
					numRestQnt.InputMask = ((bWeighting || bDecimalInBox) ? "########0.000" : "########0");
					numRestQnt.Refresh();

					numBoxQnt.Enabled = (!bWeighting);
				}
			}
			pnlDataChange.Enabled = true;

			if (numBoxQnt.Enabled)
				numBoxQnt.Select();
			else
				numRestQnt.Select();
		}

	#endregion

	#region RowEnter, CellFormatting

		private void grdFramesContents_RowEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (grdFramesContents.IsStatusRow(e.RowIndex))
			{
				cboGood.SelectedValue = -1;
				txtGood.Text = "";
				numBoxQnt.Value = 0;
				numRestQnt.Value = 0; 
				dtpDateValid.Value = DateTime.Now.Date;
				return;
			}

			DataGridViewRow r = grdFramesContents.Rows[e.RowIndex];

			bool bWeighting = false;
			if (r.Cells["grcWeighting"].Value != null &&
				r.Cells["grcWeighting"].Value != DBNull.Value)
			{
				bWeighting = (bool)r.Cells["grcWeighting"].Value;
			}
			decimal nQnt = 0, nInBox = 1;
			bool bDecimalInBox = false;
			if (r.Cells["grcQnt"].Value != null &&
				r.Cells["grcQnt"].Value != DBNull.Value)
			{
				nQnt = Convert.ToDecimal(r.Cells["grcQnt"].Value);
				nInBox = Convert.ToDecimal(r.Cells["grcInBox"].Value);
				bDecimalInBox = ((int)nInBox != nInBox);
			}
			if (bWeighting)
			{
				numBoxQnt.Value = 0;
				numRestQnt.DecimalPlaces = 3;
				numRestQnt.InputMask = "########0.000";
				numRestQnt.Value = nQnt;
			}
			else
			{
				numBoxQnt.Value = System.Math.Floor(nQnt / nInBox);
				numRestQnt.DecimalPlaces = ((bDecimalInBox) ? 3 : 0);
				numRestQnt.InputMask = ((bDecimalInBox) ? "########0.000" : "########0");
				numRestQnt.Value = nQnt - (System.Math.Floor(nQnt / nInBox) * nInBox);
			}

			if (r.Cells["grcPackingID"].Value != null &&
				r.Cells["grcPackingID"].Value != DBNull.Value)
			{
				cboGood.SelectedValue = Convert.ToInt32(r.Cells["grcPackingID"].Value);
				txtGood.Text = cboGood.Text;
			}
			else
			{
				cboGood.SelectedValue = -1;
				txtGood.Text = "";
			}
			if (r.Cells["grcDateValid"].Value != null &&
				r.Cells["grcDateValid"].Value != DBNull.Value)
			{
				dtpDateValid.Value = (DateTime)r.Cells["grcDateValid"].Value;
			}
			else
			{
				dtpDateValid.Value = DateTime.Now.Date;
			}

			string cChanges = r.Cells["grcChanges"].Value.ToString().Trim();
			switch (cChanges)
			{
				case (""):
				case ("A"):
				case ("E"):
					btnEdit.Enabled = true;
					btnDelete.Enabled = true;
					break;
				case ("D"):
					btnEdit.Enabled = false;
					btnDelete.Enabled = false;
					break;
			}
		}
				
		private void grdFramesContents_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			RFMDataGridView grd = grdFramesContents;
			if (grd.Rows[e.RowIndex] == null)
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
					case "grcChangesImage":
						e.Value = Properties.Resources.Empty;
						break;
				}
				return;
			}

			DataGridViewRow r = grd.Rows[e.RowIndex];
			string sChanges = r.Cells["grcChanges"].Value.ToString();
			switch (grd.Columns[e.ColumnIndex].Name)
			{
				case "grcQnt":
				case "grcInBox":
					if (!Convert.IsDBNull(r.Cells["grcWeighting"].Value) &&
						Convert.ToBoolean(r.Cells["grcWeighting"].Value) ||
						!Convert.IsDBNull(e.Value) && Convert.ToDecimal(e.Value) != Convert.ToInt32(e.Value))
						e.CellStyle.Format = "### ### ### ###.000";
					else
						e.CellStyle.Format = "### ### ### ###";
					break;
				case "grcChangesImage":
					switch (sChanges)
					{
						case "D":
							e.Value = Properties.Resources.Minus;
							break;
						case "E":
							e.Value = Properties.Resources.Edit;
							break;
						case "A":
							e.Value = Properties.Resources.Plus;
							break;
						default:
							e.Value = Properties.Resources.Empty;
							break;
					}
					break;
			}

			// ���� ������
			switch (sChanges)
			{
				case "D":
					grd.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightPink;
					break;
				case "E":
					e.CellStyle.BackColor = Color.LightYellow;
					break;
				case "A":
					e.CellStyle.BackColor = Color.LightGreen;
					break;
				default:
					e.CellStyle.BackColor = grd.DefaultCellStyle.BackColor;
					break;
			}
		}

	#endregion

	#region GridButtons

		private void btnAdd_Click(object sender, EventArgs e)
		{
			// ���������� ������ ������

			int nCnt = 0;
			foreach (DataRow r in oFrame.TableFramesContents.Rows)
			{
				if (r["Changes"].ToString() != "D")
					nCnt++;
			}
			if (nCnt > 0)
			{
				if (RFMMessage.MessageBoxYesNo("��������!\n\r\n\r" +
						"� ���������� ��� ���� �����!\r\n" +
						"��� ���������� ������� ������ ��������� �� ����� �������������� �������������!\n\r\n\r" +
						"���-���� �������� ��� ���� ����� � ���������?") != DialogResult.Yes)
					return;
			}

			btnSave.Enabled = false;
			btnAdd.Enabled = false;
			btnEdit.Enabled = false;
			btnDelete.Enabled = false;
			btnGridSave.Enabled = true;
			btnGridUndo.Enabled = true;

			pnlDataChange.BorderStyle = BorderStyle.Fixed3D;
			pnlDataChange.Enabled = true;

			btnPackings.Enabled = true;
			numBoxQnt.Enabled = true;
			numRestQnt.Enabled = true;
			dtpDateValid.Enabled = true;
			dtpDateValid.HideControl(true); 

			cboGood.SelectedValue = -1;
			txtGood.Text = "";
			numBoxQnt.Value = 0;
			numRestQnt.Value = 0; 
			dtpDateValid.Value = DateTime.Now.Date;

			grdFramesContents.Enabled = false;

			lblAction.Text = "���������� ������ � ���������";
			_cMode = "A";

			btnPackings_Click(null, null);
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			// ��������� ���������� ������

			if (grdFramesContents.CurrentRow == null)
				return;

			btnSave.Enabled = false;
			btnAdd.Enabled = false;
			btnEdit.Enabled = false;
			btnDelete.Enabled = false;
			btnGridSave.Enabled = true;
			btnGridUndo.Enabled = true;

			pnlDataChange.BorderStyle = BorderStyle.Fixed3D;
			pnlDataChange.Enabled = true;

			btnPackings.Enabled = false;
			numBoxQnt.Enabled = (!(bool)grdFramesContents.CurrentRow.Cells["grcWeighting"].Value);
			numRestQnt.Enabled = true;
			dtpDateValid.Enabled = true;
			dtpDateValid.HideControl(true); 

			grdFramesContents.Enabled = false;

			if (numBoxQnt.Enabled)
				numBoxQnt.Select();
			else
				numRestQnt.Select();

			lblAction.Text = "��������� ���������� / ����� �������� ��� ������ � ����������";
			_cMode = "E";
		}

		private void btnGridSave_Click(object sender, EventArgs e)
		{
			if (cboGood.SelectedValue == null || cboGood.SelectedIndex < 0)
			{
				RFMMessage.MessageBoxError("�� ������ �����...");
				return;
			}

			if (numBoxQnt.Value <= 0 && numRestQnt.Value <= 0)
			{
				RFMMessage.MessageBoxError("�� ������� ���������� ������...");
				return;
			}

			// ��������� � DataTable
			int nPackingID = Convert.ToInt32(cboGood.SelectedValue);
			decimal nQnt = 0, nInBox = 0, 
					nRestQnt = numRestQnt.Value, nBoxQnt = numBoxQnt.Value;
			int nBoxInPal = 0;
			DateTime dDateValid = dtpDateValid.Value.Date;

			switch (_cMode)
			{
				case "A":

					// ��� �� ����� ������ ��� � ����������?
					int nTempPackingID;
					DateTime? dTempDateValid;
					foreach (DataRow r in oFrame.TableFramesContents.Rows)
					{
						nTempPackingID = Convert.ToInt32(r["PackingID"]);
						if (r["DateValid"] != null && r["DateValid"] != DBNull.Value)
							dTempDateValid = (DateTime)r["DateValid"];
						else 
							dTempDateValid = null;
						if (nTempPackingID == nPackingID && dTempDateValid == dDateValid)
						{
							if (r["Changes"].ToString() == "")
							{
								RFMMessage.MessageBoxError("����� � ����� ������ �������� ��� ��������� � ����������...");
								return;
							}
							if (r["Changes"].ToString() == "A")
							{
								RFMMessage.MessageBoxError("����� � ����� ������ �������� ��� �������� � ���������...");
								return;
							}
						}
					}

					// ��������� �����
					DataRow rCGood = oGoodAdd.MainTable.Rows[0];

					// ��������� ������ � �������
					DataRow rCAdd = oFrame.TableFramesContents.Rows.Add();

					rCAdd["ID"] = DBNull.Value;
					rCAdd["PackingNew"] = false;

					rCAdd["PackingID"] = nPackingID;
					rCAdd["GoodAlias"] = rCGood["GoodAlias"];
					rCAdd["Weighting"] = rCGood["Weighting"];

					nInBox = Convert.ToDecimal(rCGood["InBox"]);
					rCAdd["InBox"] = nInBox;
					nQnt = nBoxQnt * nInBox + nRestQnt;
					rCAdd["Qnt"] = nQnt;

					nBoxInPal = Convert.ToInt32(rCGood["BoxInPal"]);
					rCAdd["BoxInPal"] = nBoxInPal;
					if (nInBox != 0)
					{
						rCAdd["BoxQnt"] = nQnt / nInBox;
						if (nBoxInPal != 0)
						{
							rCAdd["PalQnt"] = nQnt / nInBox / nBoxInPal;
						}
					}
					rCAdd["DateValid"] = dDateValid;
					
					rCAdd["Changes"] = "A";
					break;

				case "E":

					// ���������� ������ � �������
					//DataRow rCEdit = oFrame.TableFramesContents.Rows[grdFramesContents.GridSource.Position];
					DataRow rCEdit = ((DataRowView)grdFramesContents.GridSource.Current).Row;

					if (nBoxQnt <= 0 && nRestQnt <= 0)
					{
						if (RFMMessage.MessageBoxYesNo("�� ������� ���������� ������...\n\n������� ����� �� ����������?") == DialogResult.Yes)
						{ 
							rCEdit["Changes"] = "D";
						}
						else
							return;
					}

					// ��� �� ����� ������ � ����� �� ������ �������� ��� � ����������?
					for (int i = 0; i < oFrame.TableFramesContents.Rows.Count; i++)
					{
						DataRow r = oFrame.TableFramesContents.Rows[i];
						//if (i == grdFramesContents.GridSource.Position)
						if (r == rCEdit)
						{
							// �� �� ������
							continue;
						}

						nTempPackingID = Convert.ToInt32(r["PackingID"]);
						if (r["DateValid"] != null && r["DateValid"] != DBNull.Value)
						{
							dTempDateValid = (DateTime)r["DateValid"];
						}
						else
						{
							dTempDateValid = null;
						}
						if (nTempPackingID == nPackingID && dTempDateValid == dDateValid)
						{
							if (r["Changes"].ToString() == "")
							{
								RFMMessage.MessageBoxError("����� � ����� ������ �������� ��� ��������� � ����������...");
								return;
							}
							if (r["Changes"].ToString() == "A")
							{
								RFMMessage.MessageBoxError("����� � ����� ������ �������� ��� �������� � ���������...");
								return;
							}
						}
					}

					// ���������� ������ � �������
					nInBox = Convert.ToDecimal(rCEdit["InBox"]);
					nQnt = nBoxQnt * nInBox + nRestQnt;
					rCEdit["Qnt"] = nQnt;

					nBoxInPal = Convert.ToInt32(rCEdit["BoxInPal"]);
					if (nInBox != 0)
					{
						rCEdit["BoxQnt"] = nQnt / nInBox;
						if (nBoxInPal != 0)
						{
							rCEdit["PalQnt"] = nQnt / nInBox / nBoxInPal;
						}
					}
					rCEdit["DateValid"] = dDateValid;

					if (rCEdit["Changes"].ToString() != "A")
					{
						rCEdit["Changes"] = "E";
					}
					break;
			}

			btnGridUndo_Click(null, null);
		}

		private void btnGridUndo_Click(object sender, EventArgs e)
		{
			if (grdFramesContents.CurrentRow == null)
				return;

			pnlDataChange.BorderStyle = BorderStyle.FixedSingle;
			pnlDataChange.Enabled = false;
			grdFramesContents.Enabled = true;
			grdFramesContents.Refresh();

			btnSave.Enabled = true;
			btnGridSave.Enabled = false;
			btnGridUndo.Enabled = false;
			btnAdd.Enabled = true;

			lblAction.Text = "";
			_cMode = "";

			grdFramesContents.Select();
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (grdFramesContents.CurrentRow == null)
				return;

			//DataRow rd = oFrame.TableFramesContents.Rows[grdFramesContents.GridSource.Position];
			DataRow rd = ((DataRowView)grdFramesContents.GridSource.Current).Row; 
			if (RFMMessage.MessageBoxYesNo("������� ������� ����� � ����������?") == DialogResult.Yes)
			{
				rd["Changes"] = "D";
			}

			grdFramesContents.Refresh();
			btnAdd.Select();
		}

	#endregion

	#region ��������� cboOwner

		private void btnOwnerClear_Click(object sender, EventArgs e)
		{
			cboOwner.SelectedIndex = -1;
			cboOwner.SelectedValue = -1;
		}

	#endregion

	#region ������

		private void btnCellChange_Click(object sender, EventArgs e)
		{
			if (sender != null)
			{
				if (RFMMessage.MessageBoxYesNo("�������� ������, � ������� ��������� ���������?") != DialogResult.Yes)
					return;
			}

			_SelectedCellID = null;
			if (StartForm(new frmSelectOneCell(this)) == DialogResult.Yes)
			{
				if (_SelectedCellID != null)
				{
					Cell oCellChoosen = new Cell();
					oCellChoosen.ID = _SelectedCellID;
					oCellChoosen.FillData();
					if (oCellChoosen.MainTable.Rows.Count == 1)
					{
						// ��������� ������
						DataRow r = oCellChoosen.MainTable.Rows[0];
						// ������� ���������
						DataRow f = oFrame.MainTable.Rows[0];

						// ����� �� ��������� ���� ��������� � ��������� ������?
						if (r["ForFrames"] != DBNull.Value && !(bool)r["ForFrames"])
						{
							RFMMessage.MessageBoxError("��������� ������ �� ������������� ��� �����������...");
							return;
						}

						decimal nMaxPalletQnt = 0;
						if (r["MaxPalletQnt"] == DBNull.Value)
						{
							if (r["StoreZoneMaxPalletQnt"] == DBNull.Value)
							{
								nMaxPalletQnt = 999999;
							}
							else 
							{
								nMaxPalletQnt = Convert.ToDecimal(r["StoreZoneMaxPalletQnt"]); 
							}
						}
						else
						{
							nMaxPalletQnt = Convert.ToDecimal(r["MaxPalletQnt"]); 
						}

						if (nMaxPalletQnt > 0 && nMaxPalletQnt < 999999)
						{
							int nFramesQntInCell = oCellChoosen.GetFramesQnt(Convert.ToInt32(oCellChoosen.ID), false);
							int nFramesQntToCell = oCellChoosen.GetFramesQnt(Convert.ToInt32(oCellChoosen.ID), true);
							if (nMaxPalletQnt < nFramesQntInCell + nFramesQntToCell + 1)
							{
								RFMMessage.MessageBoxError("��������� ������ ����� ��������� ������������ ���������� �����������: " + nMaxPalletQnt + "\n\n" + 
										"������ � ������ ��������� �����������: " + nFramesQntInCell.ToString() + "\n" + 
										"������ � ������ ������������ �����������: " + nFramesQntToCell.ToString() + "\n\n" + 
										"���������� ��� ������ ���������� � ������ ����������...");
								return;
							}
						}

						int nFramePalletTypeID = 0;
						if (f["PalletTypeID"] != DBNull.Value)
						{
							nFramePalletTypeID = Convert.ToInt32(f["PalletTypeID"]);
							if (r["PalletTypeID"] != DBNull.Value)
							{
								int nPalletTypeID = Convert.ToInt32(r["PalletTypeID"]);
								if (nPalletTypeID != nFramePalletTypeID)
								{
									RFMMessage.MessageBoxError("��� ������� � ������ �� ��������� � ����� ������� �����������...");
									return;
								}
							}
						}

						decimal nMaxWeight = Convert.ToDecimal(r["MaxWeight"]);
						// ����������� ��� ���������� = ��� ������� + ��� ������� + ��� ������
						decimal nFrameWeight = 0; 
						Good oGoodCalc = new Good();
						oGoodCalc.FillTablePalletsTypes();
						foreach (DataRow pt in oGoodCalc.TablePalletsTypes.Rows)
						{
							if (nFramePalletTypeID == Convert.ToInt32(pt["ID"]))
							{
								nFrameWeight = Convert.ToDecimal(pt["PalletWeight"]);
							}
						}
						foreach(DataRow c in oFrame.TableFramesContents.Rows)
						{
							if (c["Changes"].ToString() != "D")
							{
								oGoodCalc.PackingID = Convert.ToInt32(c["PackingID"]);
								oGoodCalc.FillData();
								DataRow g = oGoodCalc.MainTable.Rows[0];
								nFrameWeight =+ Convert.ToDecimal(c["BoxQnt"]) * Convert.ToDecimal(g["BoxWeight"]) +
										Convert.ToDecimal(c["Qnt"]) * Convert.ToDecimal(g["Netto"]);
							}
						}
						if (nMaxWeight > 0 && nFrameWeight > nMaxWeight)
						{
							if (RFMMessage.MessageBoxYesNo("����������� ���������� ��� ��� ��������� ������: " + System.Math.Round(nMaxWeight, 0).ToString() + "\n" +
									"��� ����������: " + System.Math.Round(nFrameWeight, 0).ToString() + ",\n" +
									"��� ������ ����������� ���� ��� ������ �� " + System.Math.Round((Convert.ToDecimal(nFrameWeight - nMaxWeight)), 0).ToString() + "�� \n\n" +
									"���-���� ���������?") != DialogResult.Yes)
								return;
						}

						decimal nCellHeight = Convert.ToDecimal(r["CellHeight"]);
						decimal nFrameHeight = Convert.ToDecimal(f["FrameHeight"]);
						if (nCellHeight > 0 && nFrameHeight > nCellHeight)
						{
							if (RFMMessage.MessageBoxYesNo("������ ��������� ������: " + nCellHeight.ToString() + "\n" +
									"������ ����������: " + nFrameHeight.ToString() + ",\n" +
									"��� ������ ������ ������ �� " + (Convert.ToDecimal(nFrameHeight - nCellHeight)).ToString() + " � \n\n" +
									"���-���� ���������?") != DialogResult.Yes)
								return;
						}
						
						// ����� ���������
						oCell.ID = oCellChoosen.ID;
						oCell.FillData();
						lblCellAddress.Text = oCell.MainTable.Rows[0]["Address"].ToString() +
								" (" + oCell.MainTable.Rows[0]["StoreZoneName"].ToString() + ")";

					}
				}
			}
		}

	#endregion

	#region ��������� ��������� ����������

		private void btnFrameEdit_Click(object sender, EventArgs e)
		{
			if (FrameEdit())
				oFrame.FillData();
		}

		private bool FrameEdit()
		{
			return (StartForm(new frmFramesEdit(oFrame)) == DialogResult.Yes);
		}

	#endregion 

	}
}