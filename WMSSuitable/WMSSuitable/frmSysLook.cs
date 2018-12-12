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
	/// Форма для отображения данных таблицы
	/// </summary>
	public partial class frmSysLook : RFMFormChild
	{
		private DBTable oDBTableList = new DBTable("_Tables");
		private DBTable oDBTable = new DBTable(); // источник Grid

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

			// вызов с заданным именем таблицы
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

		//получение данных выбранной таблицы
		public void btnRefresh_Click(object sender, EventArgs e)
		{
			if (cboTables.SelectedIndex < 0 || !bLoaded)
				return;

			grdTableData.DataSource = null;

			Refresh();

			RFMCursorWait.Set(true);
			RFMCursorWait.LockWindowUpdate(FindForm().Handle);

			// имя выбранной таблицы
			DataRow rt = oDBTableList.MainTable.Rows[cboTables.SelectedIndex];
			oDBTable.MainTableName = rt["TableName"].ToString();
			oDBTable.FillNames();
			oDBTable.recordID = 0;

			// можно изменять данные через станд.режим
			bForEdit = !Convert.IsDBNull(rt["ForEdit"]) && Convert.ToBoolean(rt["ForEdit"]);
		
			// список записей и структура выбранной таблицы
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

			// ID - выводим курсовом
			grdTableData.Columns[0].HeaderCell.Style.Font = new Font(grdTableData.Font.Name, grdTableData.Font.Size, FontStyle.Bold);
			grdTableData.Columns[0].DefaultCellStyle.Font = new Font(grdTableData.Font.Name, grdTableData.Font.Size, FontStyle.Bold);

			// ширина колонок - как при AutoSize
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
				// разрешаем показывать состояние Null для CheckBox-column
				if (grdTableData.Columns[i].CellType.ToString().ToLower().Contains("check"))
				{
					((DataGridViewCheckBoxColumn)grdTableData.Columns[i]).ThreeState = true;
				}
			}

			// если это та же таблица - встать на ту же запись
			if (oDBTable.MainTableName == sTable && nRecordID > 0)
			{
				grdTableData.GridSource.Position = grdTableData.GridSource.Find(oDBTable.ColumnID, nRecordID);
			}

			// встать на grid и сохранить текущую таблицу и № записи
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

			// закрыть кнопки изменения для пустого грида; все кнопки для запрещенных таблиц
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

	#region Кнопки

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
			// добавление записи
			StartForm(new frmSysEdit(sTable, 0, this));
			//if (StartForm(new frmSysEdit(sTable, 0, this)) == DialogResult.Yes)
			//{
			//	btnRefresh_Click(null, null);
			//}
		}

		private void btnCopy_Click(object sender, EventArgs e)
		{
			// копирование записи
			if (grdTableData.CurrentRow == null) 
				return;

			// передаем код копируемой записи с "-"
			int nID = -1 * Convert.ToInt32(grdTableData.CurrentRow.Cells[oDBTable.ColumnID].Value);
			StartForm(new frmSysEdit(sTable, nID, this));
			//if (StartForm(new frmSysEdit(sTable, nID, this)) == DialogResult.Yes)
			//{
			//	btnRefresh_Click(null, null);
			//}
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			// редактирование записи
			if (grdTableData.CurrentRow == null) 
				return;

			// передаем код редактируемой записи
			int nID = Convert.ToInt32(grdTableData.CurrentRow.Cells[oDBTable.ColumnID].Value);
			StartForm(new frmSysEdit(sTable, nID, this));
			//if (StartForm(new frmSysEdit(sTable, nID, this)) == DialogResult.Yes)
			//{
			//	btnRefresh_Click(null, null);
			//}
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			// удаление записи
			if (grdTableData.CurrentRow == null) 
				return;

			// передаем код удаляемой записи
			oDBTable.recordID = Convert.ToInt32(grdTableData.CurrentRow.Cells[oDBTable.ColumnID].Value);

			if (RFMMessage.MessageBoxYesNo("Удалить запись с кодом " + oDBTable.recordID.ToString() + "\r\nиз таблицы " + oDBTable.MainTableName + " (" + oDBTable.RusTableName + ")?") == DialogResult.Yes)
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