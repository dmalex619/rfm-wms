using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

using RFMBaseClasses;
using RFMPublic;

using WMSBizObjects;

namespace WMSSuitable
{
	public partial class frmCellsReorder : RFMFormChild
	{
		private Cell oCell = new Cell();
		private StoreZone oStoreZone = new StoreZone();

		public frmCellsReorder() : base()
		{
			InitializeComponent();
		}

		private void frmCellsReorder_Load(object sender, EventArgs e)
		{
			foreach (DataGridViewColumn c in dgvCells.Columns)
				c.ReadOnly = !(c.DataPropertyName.ToUpper() == "RANK");

			trvCells_Restore();
			SetButtonStatus(false);
		}
		
		private void btnGrid_Click(object sender, EventArgs e)
		{
			dgvCells_Restore();

			if (dgvCells.Rows.Count > 0)
				dgvCells.CurrentCell = dgvCells.Rows[0].Cells["grcRank"];
		}

		private void dgvCells_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (dgvCells.DataSource == null)
				return;

			if (dgvCells.IsStatusRow(e.RowIndex))
			{
				e.CellStyle.BackColor = Color.Silver;
				e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);

				if (dgvCells.Columns[e.ColumnIndex].Name.Contains("Image"))
					e.Value = Properties.Resources.Empty;

				return;
			}

			DataGridViewRow r = dgvCells.Rows[e.RowIndex];
			switch (dgvCells.Columns[e.ColumnIndex].Name)
			{
				case "grcCellStateImage":
					if ((bool)r.Cells["grcHasCellContent"].Value)
						e.Value = Properties.Resources.Box_full;
					else
						e.Value = Properties.Resources.Empty;
					break;
				case "grcLockedImage":
					if ((bool)r.Cells["grcLocked"].Value)
						e.Value = Properties.Resources.Lock1;
					else
						e.Value = Properties.Resources.Empty;
					break;
				case "grcForFrames":
					if (r.Cells["grcIsForFrames"].Value == DBNull.Value)
						e.CellStyle.BackColor = 
						e.CellStyle.ForeColor = 
							Color.Silver;
					break;
				case "grcIsRankChanged":
					DataRow rd = ((DataRowView)dgvCells.Rows[e.RowIndex].DataBoundItem).Row;
					if (rd != null && Convert.ToInt32(rd["Rank"]) != Convert.ToInt32(rd["PreRank"]))
						e.Value = Properties.Resources.Edit;
					else
						e.Value = Properties.Resources.Empty;
					break;
			}

			// неактуальные - курсивом вся строка
			if (!Convert.ToBoolean(r.Cells["grcActual"].Value))
				e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Italic);
		}

		private void dgvCells_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			if (dgvCells.IsCurrentCellDirty)
			{
				dgvCells.Invalidate();
			}
		}

		private bool dgvCells_Restore()
		{
			RFMCursorWait.Set(true);

			oCell.ClearFilters();
			oCell.IDList = null;

			if (trvCells.GetMarkedNodes() > 0)
			{
				DataTable dtMarkedCells = CopyTable((DataTable)trvCells.TreeSource.DataSource, "MarkedCells", "IsMarked AND NOT IsNode", "", new string[] { "ID" });
				string strCells = "";
				foreach (DataRow r in dtMarkedCells.Rows)
					strCells += r["ID"].ToString() + ",";
				if (strCells != null && strCells.Length > 0)
					oCell.IDList = strCells;
			}

			if (uctZones.IsSelectedExist)
			{
				DataTable dt = CopyTable(uctZones.selectData, "MarkedZones", "", "", new string[] { "ID" });
				string strZones = "";
				foreach (DataRow r in dt.Rows)
					strZones += r["ID"].ToString() + ",";
				if (strZones != null && strZones.Length > 0)
					oCell.FilterStoresZonesList = strZones;
			}

			oCell.FillData();

			if (!oCell.MainTable.Columns.Contains("PreRank"))
				oCell.MainTable.Columns.Add("PreRank", Type.GetType("System.Int32"));
			foreach (DataRow r in oCell.MainTable.Rows)
			{
				r["PreRank"] = r["Rank"];
			}

			dgvCells.Restore(oCell.MainTable);

			SetButtonStatus(dgvCells.GridSource.Count > 0);

			RFMCursorWait.Set(false);

			return (true);
		}

		private void trvCells_Restore()
		{
			RFMCursorWait.Set(true);

			if (trvCells.TreeSource != null)
				((DataTable)trvCells.TreeSource.DataSource).DataSet.Tables.Remove("dtTree");

			oCell.FillDataTree(trvCells.IsActualOnly);
			trvCells.Restore(oCell.DS.Tables["TableDataTree"]);
			trvCells.SelectedNode = trvCells.TopNode;
			trvCells.Refresh();

			RFMCursorWait.Set(false);
		}

		private void uctZones_Restore()
		{
			oStoreZone.FillData(); 
			uctZones.Restore(oStoreZone.MainTable);
		}

		private void btnEqual_Click(object sender, EventArgs e)
		{
			if (dgvCells.MarkedCount > 0)
				ChangeMarkedCells(0, (int)nudRank.Value);
			else
				ChangeCurrentCell(0, (int)nudRank.Value);
		}

		private void btnMax_Click(object sender, EventArgs e)
		{
			DataTable dt;
			if (dgvCells.MarkedCount > 0)
			{
				dt = CopyTable((DataTable)dgvCells.GridSource.DataSource, "", "IsMarked", "", new string[] { "Rank" });
				if (dt.Rows.Count > 0)
					ChangeMarkedCells(1, Convert.ToInt32(dt.Compute("MAX(Rank)", String.Empty)));
			}
			else
			{
				dt = (DataTable)dgvCells.GridSource.DataSource;
				ChangeCurrentCell(1, Convert.ToInt32(dt.Compute("MAX(Rank)", String.Empty)));
			}
		}

		private void btnMin_Click(object sender, EventArgs e)
		{
			DataTable dt;
			if (dgvCells.MarkedCount > 0)
			{
				dt = CopyTable((DataTable)dgvCells.GridSource.DataSource, "", "IsMarked", "", new string[] { "Rank" });
				if (dt.Rows.Count > 0)
					ChangeMarkedCells(2, Convert.ToInt32(dt.Compute("MIN(Rank)", String.Empty)));
			}
			else
			{
				dt = (DataTable)dgvCells.GridSource.DataSource;
				ChangeCurrentCell(2, Convert.ToInt32(dt.Compute("MIN(Rank)", String.Empty)));
			}
		}

		private void btnPlus_Click(object sender, EventArgs e)
		{
			if (dgvCells.MarkedCount > 0)
				ChangeMarkedCells(3, 1);
			else 
				ChangeCurrentCell(3, 1);
		}

		private void btnMinus_Click(object sender, EventArgs e)
		{
			if (dgvCells.MarkedCount > 0)
				ChangeMarkedCells(3, -1);
			else
				ChangeCurrentCell(3, -1);
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			DataTable dt = CopyTable((DataTable)dgvCells.GridSource.DataSource, "ChangedCells", "Rank <> PreRank", "", new string[] { "ID", "Rank" });
			if (dt.Rows.Count > 0)
			{
				string strCells = null;
				StringWriter swTable = new StringWriter();
				dt.WriteXml(swTable);
				strCells = swTable.ToString();
				if (oCell.SaveRank(strCells))
				{
					RFMMessage.MessageBoxInfo("Сохранено!");
					dgvCells_Restore();
				}
			}
			else
			{
				RFMMessage.MessageBoxInfo("Нет изменений...");
			}
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void ChangeCurrentCell(int rankMode, int rankValue)
		{
			if (dgvCells.CurrentRow == null)
				return;

			dgvCells.IsRestoring = true;

			DataRow r = ((DataRowView)dgvCells.CurrentRow.DataBoundItem).Row;
			switch (rankMode)
			{
				case 0:
				case 1:
				case 2:
					r["Rank"] = rankValue;
					break;
				case 3:
				case 4:
					r["Rank"] = ((int)r["Rank"]) + rankValue;
					break;
				default:
					break;
			}
			dgvCells.Invalidate();

			dgvCells.IsRestoring = false;
		}

		private void ChangeMarkedCells(int rankMode, int rankValue)
		{
			dgvCells.IsRestoring = true;

			RFMBindingSource bs = dgvCells.GridSource;
			int bsIndex = bs.Position;
			string bsFilter = bs.Filter;
			string sortExpres = bs.Sort;

			bs.RemoveSort();
			bs.Filter = "IsMarked";
			bs.MoveFirst();
			DataRowView drv;
			for (int i = 0; i < bs.Count; i++)
			{
				drv = (DataRowView)bs.Current;
				switch (rankMode)
				{
					case 0:
					case 1:
					case 2:
						drv["Rank"] = rankValue;
						break;
					case 3:
					case 4:
						drv["Rank"] = ((int)drv["Rank"]) + rankValue;
						break;
					default:
						break;						
				}
				bs.MoveNext();
			}
			bs.Filter = bsFilter;
			bs.Position = bsIndex;
			dgvCells.Invalidate();

			if (!String.IsNullOrEmpty(sortExpres))
				bs.Sort = sortExpres;

			if (chkClearMarkers.Checked)
				dgvCells.MarkAllRows(false);

			dgvCells.IsRestoring = false;
		}

		private void chkCellsActual_CheckedChanged(object sender, EventArgs e)
		{
			// список
			if (dgvCells.Rows.Count > 0 ||
				uctZones.txtData.Text.Trim().Length > 0 ||
				trvCells.GetMarkedNodes() > 0)
			{
				dgvCells_Restore();
			}
			// дерево
			trvCells.IsActualOnly = chkCellsActual.Checked;
			if (trvCells.TreeSource != null)
			{
				trvCells_Restore();
			}
		}

		private void btnAddressContextMark_Click(object sender, EventArgs e)
		{
			RFMCursorWait.Set(true);
			RFMCursorWait.LockWindowUpdate(FindForm().Handle);

			if (txtAddress.Text.Trim().Length > 0 && dgvCells.Rows.Count > 0)
			{
				string sAddress = txtAddress.Text.Trim().ToUpper();
				string sCellsList = "";
				foreach (DataRow r in oCell.MainTable.Rows)
				{
					if (r["Address"].ToString().ToUpper().Contains(sAddress))
						sCellsList += r["ID"].ToString() + ",";
				}
				if (sCellsList.Length > 0)
				{
					sCellsList = RFMUtilities.NormalizeList(sCellsList);
					dgvCells.MarkFromList(sCellsList);
				}
			}
			dgvCells.Refresh();

			RFMCursorWait.LockWindowUpdate(IntPtr.Zero);
			RFMCursorWait.Set(false);
		}

		private void SetButtonStatus(bool isEnabled)
		{
			nudRank.Enabled =
			btnEqual.Enabled =
			btnMax.Enabled =
			btnMin.Enabled =
			btnPlus.Enabled =
			btnMinus.Enabled =
			btnSave.Enabled =
				isEnabled;
		}

		private void frmCellsReorder_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F5:
					btnGrid_Click(null, null);
					break;
				case Keys.F1:
					btnHelp_Click(null, null);
					break;
				case Keys.W:
				case Keys.S:
					if (e.Modifiers == Keys.Control)
					{
						btnSave_Click(null, null);
					}
					break;
				case Keys.Escape:
					btnExit_Click(null, null);
					break;
			}
		}

		private void btnHelp_Click(object sender, EventArgs e)
		{

		}
	}
}