using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RFMBaseClasses;
using RFMPublic;

using WMSBizObjects;

namespace WMSSuitable 
{
	/// <summary>
	/// ����� ��� ����������� ������ �������
	/// </summary>
	public partial class frmSysLook : RFMFormChild
	{
		private DBTable oDBTableList = new DBTable("_Tables");
		private DBTable oDBTable = new DBTable(); // �������� Grid

		private string sTable = "";
		public int nRecordID = 0;
		private bool bForEdit = false;

		private bool bLoaded = false;

		public frmSysLook()
		{
			InitializeComponent();
		}

		public frmSysLook(string _sTable)
		{
			if (_sTable != null)
			{
				sTable = _sTable;
			}
			InitializeComponent();
		}

		private void frmSysLook_Load(object sender, EventArgs e)
		{
			grdTableData.AutoGenerateColumns = true;

			oDBTableList.recordID = null;
			oDBTableList.FillData();

			cboTables.DataSource = oDBTableList.MainTable;
			cboTables.DisplayMember = oDBTableList.ColumnName;
			cboTables.ValueMember = oDBTableList.ColumnID;
			cboTables.SelectedIndex = -1;

			oDBTable.recordID = null;

			bLoaded = true;

			// ����� � �������� ������ �������
			if (sTable.Length > 0)
			{
				foreach (DataRow r in oDBTableList.MainTable.Rows)
				{
					if (r["Name"].ToString().ToUpper() == sTable.ToUpper())
					{
						cboTables.SelectedValue = Convert.ToInt32(r["ID"]);
						cboTables.Enabled = false;
						btnRefresh.Enabled = false;
						btnRefresh_Click(null, null);
						break;
					}
				}
			}

		}

		//��������� ������ ��������� �������
		public void btnRefresh_Click(object sender, EventArgs e)
		{
			if (cboTables.SelectedIndex < 0 || !bLoaded)
				return;

			grdTableData.DataSource = null;

			Refresh();

			RFMCursorWait.Set(true);
			RFMCursorWait.LockWindowUpdate(FindForm().Handle);

			// ��� ��������� �������
			DataRow rt = oDBTableList.MainTable.Rows[cboTables.SelectedIndex];
			oDBTable.MainTableName = rt["TableName"].ToString();
			oDBTable.FillNames();
			oDBTable.recordID = 0;

			// ����� �������� ������ ����� �����.�����
			bForEdit = !Convert.IsDBNull(rt["ForEdit"]) && Convert.ToBoolean(rt["ForEdit"]);
		
			// ������ ������� � ��������� ��������� �������
			oDBTable.ClearError();
			oDBTable.GetRecordsList(null, false);
			oDBTable.GetStructure(false);
			if (oDBTable.ErrorNumber != 0)
			{
				RFMCursorWait.LockWindowUpdate(IntPtr.Zero);
				RFMCursorWait.Set(false);
				return;
			}

			grdTableData.Restore(oDBTable.MainTable);

			for(int i = 0; i < oDBTable.MainTable.Columns.Count; i++)
			{
				grdTableData.Columns[i].HeaderText = oDBTable.TableStructure.Rows[i]["FieldDescription"].ToString();
				if (oDBTable.TableStructure.Rows[i]["FieldTypeChar"].ToString() == "N")
				{
					grdTableData.Columns[i].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
				}
				if (Convert.ToBoolean(oDBTable.TableStructure.Rows[i]["Is_FKID"].ToString()))
				{
					grdTableData.Columns[i].DefaultCellStyle.Font = new Font(grdTableData.Font.Name, grdTableData.Font.Size, FontStyle.Italic);
					grdTableData.Columns[i].HeaderCell.Style.Font = new Font(grdTableData.Font.Name, grdTableData.Font.Size, FontStyle.Italic);
				}
				grdTableData.Columns[i].Resizable = DataGridViewTriState.NotSet;
				grdTableData.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
			}

			// ID - ������� ��������
			grdTableData.Columns[0].HeaderCell.Style.Font = new Font(grdTableData.Font.Name, grdTableData.Font.Size, FontStyle.Bold);
			grdTableData.Columns[0].DefaultCellStyle.Font = new Font(grdTableData.Font.Name, grdTableData.Font.Size, FontStyle.Bold);

			// ������ ������� - ��� ��� AutoSize
			grdTableData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			for(int i = 0; i < grdTableData.Columns.Count; i ++)
			{
				grdTableData.Columns[i].Tag = grdTableData.Columns[i].Width.ToString();
			}
			grdTableData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
			for(int i = 0; i < grdTableData.Columns.Count; i ++)
			{
				grdTableData.Columns[i].Width = Convert.ToInt32(grdTableData.Columns[i].Tag);
				grdTableData.Columns[i].Tag = "";
				// ��������� ���������� ��������� Null ��� CheckBox-column
				if (grdTableData.Columns[i].CellType.ToString().ToLower().Contains("check"))
				{
					((DataGridViewCheckBoxColumn)grdTableData.Columns[i]).ThreeState = true;
				}
			}

			// ���� ��� �� �� ������� - ������ �� �� �� ������
			if (oDBTable.MainTableName == sTable && nRecordID > 0)
			{
				grdTableData.GridSource.Position = grdTableData.GridSource.Find(oDBTable.ColumnID, nRecordID);
			}

			// ������ �� grid � ��������� ������� ������� � � ������
			grdTableData.Select();
			sTable = oDBTable.MainTableName;
			if (grdTableData.CurrentRow != null)
			{
				nRecordID = Convert.ToInt32(grdTableData.CurrentRow.Cells[0].Value);
			}
			else
			{
				nRecordID = 0;
			}

			// ������� ������ ��������� ��� ������� �����; ��� ������ ��� ����������� ������
			if (grdTableData.Rows.Count == 0)
			{
				btnAdd.Enabled = bForEdit;
				btnCopy.Enabled =
				btnEdit.Enabled =
				btnDelete.Enabled =
					false;
			}
			else
			{
				btnAdd.Enabled = 
				btnCopy.Enabled = 
				btnEdit.Enabled = 
				btnDelete.Enabled = 
					bForEdit; 
			}

			RFMCursorWait.LockWindowUpdate(IntPtr.Zero);
			RFMCursorWait.Set(false);
		}

		private void cboTables_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboTables.SelectedIndex >= 0)
			{
				btnRefresh_Click(null, null);
			}
		}

	#region ������

		private void btnHelp_Click(object sender, EventArgs e)
		{
			RFMHelpUtilities.HelpShow(this, hpHelp);
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.No;
			Dispose();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			// ���������� ������
			StartForm(new frmSysEdit(sTable, 0, this));
			//if (StartForm(new frmSysEdit(sTable, 0, this)) == DialogResult.Yes)
			//{
			//	btnRefresh_Click(null, null);
			//}
		}

		private void btnCopy_Click(object sender, EventArgs e)
		{
			// ����������� ������
			if (grdTableData.CurrentRow == null) 
				return;

			// �������� ��� ���������� ������ � "-"
			int nID = -1 * Convert.ToInt32(grdTableData.CurrentRow.Cells[oDBTable.ColumnID].Value);
			StartForm(new frmSysEdit(sTable, nID, this));
			//if (StartForm(new frmSysEdit(sTable, nID, this)) == DialogResult.Yes)
			//{
			//	btnRefresh_Click(null, null);
			//}
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			// �������������� ������
			if (grdTableData.CurrentRow == null) 
				return;

			// �������� ��� ������������� ������
			int nID = Convert.ToInt32(grdTableData.CurrentRow.Cells[oDBTable.ColumnID].Value);
			StartForm(new frmSysEdit(sTable, nID, this));
			//if (StartForm(new frmSysEdit(sTable, nID, this)) == DialogResult.Yes)
			//{
			//	btnRefresh_Click(null, null);
			//}
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			// �������� ������
			if (grdTableData.CurrentRow == null) 
				return;

			// �������� ��� ��������� ������
			oDBTable.recordID = Convert.ToInt32(grdTableData.CurrentRow.Cells[oDBTable.ColumnID].Value);

			if (RFMMessage.MessageBoxYesNo("������� ������ � ����� " + oDBTable.recordID.ToString() + "\r\n�� ������� " + oDBTable.MainTableName + " (" + oDBTable.RusTableName + ")?") == DialogResult.Yes)
			{
				if (oDBTable.RecordDelete())
				{
					btnRefresh_Click(null, null);
				}
			}
		}

	#endregion 

	}
}