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
	// форма дл€ выбора одной или нескольких записей о товарах-упаковках 
	// возвращает в родительскую форму:
	// с пометкой:  string _SelectedPackingIDList (список кодов отмеченных записей, через зап€тую, вида: 1,2,23,) 
	// без пометки: int _SelectedPackingID (код текущей записи)
	// string _SelectedPackingAliasText (список алиасов первых 3-х отмеченных товаров)

	public partial class frmSelectOnePacking : RFMFormChild
	{
		private Form parentForm;
		private bool useCheck;

		private Good oGoods = new Good();
		private Good oGoodsTree = new Good();

		private Host oHost = new Host();
		private int? nHostID = null;
		private int? nUserHostID = null;

		// дл€ фильтров
		public string _SelectedIDList = null;
		public string _SelectedText = "";

		private DataTable tTable; 


		public frmSelectOnePacking()
		{
			InitializeComponent();

			parentForm = Application.OpenForms[0];
			useCheck = true;
		}

		public frmSelectOnePacking(Form _parentForm)
		{
			InitializeComponent();
			
			parentForm = _parentForm;
			useCheck = false;
		}

		public frmSelectOnePacking(Form _parentForm, bool _useCheck)
		{
			InitializeComponent();

			parentForm = _parentForm;
			useCheck = _useCheck;
		}

		public frmSelectOnePacking(Form _parentForm, bool _useCheck, int? _nHostID)
		{
			InitializeComponent();

			parentForm = _parentForm;
			useCheck = _useCheck;
			nHostID = _nHostID;
		}

		private void frmSelectOnePacking_Load(object sender, EventArgs e)
		{
			nUserHostID = ((RFMFormMain)Application.OpenForms[0]).UserInfo.HostID;

			if (nHostID.HasValue && nUserHostID.HasValue &&
				(int)nHostID != (int)nUserHostID)
			{
				RFMMessage.MessageBoxError("Ќесовпадение прав доступа к данным хоста...");
				Close();
				return; 
			}

			grdData.IsCheckerInclude = useCheck;
			grdData.IsCheckerShow = useCheck;

			if (useCheck)
				Text = "¬ыберите несколько товаров";
			else
				Text = "¬ыберите товар";

			oHost.FillData();
			if (nHostID.HasValue)
			{
				DataRow rh = oHost.MainTable.Rows.Find(nHostID);
				if (rh != null)
				{
					ucSelectRecordID_Hosts.txtData.Text = rh["Name"].ToString();
					ucSelectRecordID_Hosts.LstMarked = nHostID.ToString();
					ucSelectRecordID_Hosts.Enabled = false;
				}
			}
			if (nUserHostID.HasValue)
			{
				DataRow rh = oHost.MainTable.Rows.Find(nUserHostID);
				if (rh != null)
				{
					ucSelectRecordID_Hosts.txtData.Text = rh["Name"].ToString();
					ucSelectRecordID_Hosts.LstMarked = nUserHostID.ToString();
					ucSelectRecordID_Hosts.Enabled = false;
				}
			}

			if (oHost.Count() <= 1 || nUserHostID.HasValue)
			{
				lblHosts.Visible =
				ucSelectRecordID_Hosts.Visible =
				ucSelectRecordID_Hosts.Enabled =
					false;
			}

			if (WindowState != FormWindowState.Minimized)
			{
				cntData.SplitterDistance = 0;
				cntData.Panel1MinSize = 0;
			}
			//lblTreeWait.Visible = false;

            txtName.Select();
		}

		private void btnFilter_Click(object sender, EventArgs e)
		{
			WaitOn(this);
			grdData_Restore();
			WaitOff(this);
			grdData.Select();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			ucSelectRecordID_GoodsGroups.ClearData();
			ucSelectRecordID_GoodsBrands.ClearData();
			txtGoodBarCode.Text = "";
			txtName.Text = "";
			txtArticul.Text = "";
			if (ucSelectRecordID_Hosts.Visible && ucSelectRecordID_Hosts.Enabled)
				ucSelectRecordID_Hosts.ClearData();
			tvwGoods.MarkAllItems(false);
		}

		private void btnGo_Click(object sender, EventArgs e)
		{
			// возвращаем код выбранного товара/упаковки в родительскую форму, поле _SelectedPackingID

			string _SelectedPackingIDList = null;
			int? _SelectedPackingID = null;
			string _SelectedPackingAliasText = "";

			if (grdData.Rows.Count > 0)
			{
				if (useCheck && grdData.IsCheckerShow)
				{
					// список ID 
					_SelectedPackingIDList = "";
					_SelectedPackingAliasText = "";

					DataView dMarked = new DataView(tTable);
					dMarked.RowFilter = "IsMarked = true";
					dMarked.Sort = grdData.GridSource.Sort;
					int i = 0;
					int nFirstCntRecords = 3; // количество первых записей дл€ наборного текстового значени€
					foreach (DataRowView r in dMarked)
					{
						if (!Convert.IsDBNull(r["PackingID"]))
						{
							_SelectedPackingIDList += r["PackingID"].ToString() + ",";

							if (i < nFirstCntRecords)
							{
								_SelectedPackingAliasText += r["PackingAlias"].ToString().Trim() + ", ";
							}
							else
							{
								if (i == nFirstCntRecords)
								{
									_SelectedPackingAliasText += "...";
								}
							}
							i++;
						}
					}
					if (_SelectedPackingIDList.Length == 0)
					{
						// нет отметок - берем текущую запись
						if (grdData.CurrentRow != null)
						{
							_SelectedPackingIDList = grdData.CurrentRow.Cells["grcPackingID"].Value.ToString() + ",";
							_SelectedPackingAliasText = grdData.CurrentRow.Cells["grcGoodAlias"].Value.ToString().Trim();
						}
					}

					// приводим наборное текстовое поле к виду: (5) раз, два, три, ...
					if (_SelectedPackingIDList.Length == 0)
					{
						_SelectedPackingIDList = null;
						_SelectedPackingAliasText = "";
					}
					else
					{
						_SelectedPackingAliasText= _SelectedPackingAliasText.Trim();
						if (_SelectedPackingAliasText.Substring(_SelectedPackingAliasText.Length - 1, 1) == ",")
						{
							_SelectedPackingAliasText = _SelectedPackingAliasText.Substring(0, _SelectedPackingAliasText.Length - 1);
						}
						_SelectedPackingAliasText = "(" + RFMUtilities.Occurs(_SelectedPackingIDList, ",").ToString() + "): " +
							_SelectedPackingAliasText;
					}

					RFMUtilities.SetFormField(parentForm, "_SelectedPackingIDList", _SelectedPackingIDList);
					RFMUtilities.SetFormField(parentForm, "_SelectedPackingAliasText", _SelectedPackingAliasText);
				}
				else
				{
					// ID текущей строки
					if (grdData.CurrentRow != null)
					{
						_SelectedPackingID = (int)grdData.CurrentRow.Cells["grcPackingID"].Value;
						_SelectedPackingAliasText = grdData.CurrentRow.Cells["grcGoodAlias"].Value.ToString().Trim();
					}

					RFMUtilities.SetFormField(parentForm, "_SelectedPackingID", _SelectedPackingID);
					RFMUtilities.SetFormField(parentForm, "_SelectedPackingAliasText", _SelectedPackingAliasText);
				}
			}
			else
			{
				RFMMessage.MessageBoxInfo("Ќе выбрано ни одного товара...");
			}

			DialogResult = DialogResult.Yes;
			Dispose();
		}

		private void btnPrint_Click(object sender, EventArgs e)
		{
			DataTable tGoodTable;

			if (useCheck)
			{
				DataView dMarked = new DataView(tTable);
				dMarked.RowFilter = "IsMarked = true";
				if (dMarked.Count > 0)
				{
					// есть отмеченные записи
					tGoodTable = tTable.Clone();
					DataRow[] rows = tTable.Select("IsMarked = true", grdData.GridSource.Sort);
					foreach (DataRow r in rows)
					{
						tGoodTable.ImportRow(r);
					}
				}
				else
				{
					// нет отмеченных записей. выводим все
					tGoodTable = tTable;
				}
			}
			else
			{
				tGoodTable = tTable;
			}

			repPackings rep = new repPackings();
			StartForm(new frmActiveReport(tGoodTable, rep));
		}

		private void btnHelp_Click(object sender, EventArgs e)
		{
			RFMHelpUtilities.HelpShow(this, hpHelp);
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			Dispose();
		}

	#region Tree

		private void btnTree_Click(object sender, EventArgs e)
		{
			WaitOn(this);
			tvwGoods_Restore();
			cntData.SplitterDistance = 200;
			WaitOff(this);
		}

		private void tvwGoods_Restore()
		{
			if (tvwGoods.TreeSource != null)
				((DataTable)tvwGoods.TreeSource.DataSource).DataSet.Tables.Remove("dtTree");

			oGoods.FilterHostsList = null;
			if (nHostID.HasValue)
			{
				oGoods.FilterHostsList = nHostID.ToString();
			}
			else
			{
				if (ucSelectRecordID_Hosts.IsSelectedExist)
					oGoods.FilterHostsList = ucSelectRecordID_Hosts.GetIdString();
			}

			oGoods.FillDataTree("GROUP", tvwGoods.IsActualOnly);

			tvwGoods.Restore(oGoods.DS.Tables["TableDataTree"]);
			tvwGoods.SelectedNode = tvwGoods.TopNode;
			tvwGoods.Refresh();
		}

	#endregion 

	#region Grid CellFormat

		private void grdData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (grdData.DataSource == null)
				return;

			if (grdData.IsStatusRow(e.RowIndex))
			{
				e.CellStyle.BackColor = Color.Silver;
				e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
				return;
			}

			// неактуальные - курсивом
			DataGridViewRow r = grdData.Rows[e.RowIndex];
			if (!Convert.ToBoolean(r.Cells["grcGoodActual"].Value) || !Convert.ToBoolean(r.Cells["grcPackingActual"].Value))
				e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Italic);

			// весовые товары или товары с нецелым вложением в коробоку
			switch (grdData.Columns[e.ColumnIndex].Name)
			{
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
		}

	#endregion 

	#region Form keys

		private void frmSelectOnePacking_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F5:
					btnFilter_Click(null, null);
					break;
				case Keys.F1:
					btnHelp_Click(null, null);
					break;
				case Keys.W:
				case Keys.S:
					if (e.Modifiers == Keys.Control)
					{
						btnGo_Click(null, null);
					}
					break;
				case Keys.Escape:
					btnExit_Click(null, null);
					break;
			}
		}

	#endregion

	#region ¬ыбор группы, бренда, хоста

		#region GoodsGroups

		private void ucSelectRecordID_GoodsGroups_Restore()
		{
			RFMCursorWait.Set(true);
			ucSelectRecordID_GoodsGroups.sourceData = null;
			oGoods.FilterGoodsGroupsList = null;
			oGoods.FilterHostsList = null;
			if (nHostID.HasValue)
			{
				oGoods.FilterHostsList = nHostID.ToString();
			}
			else
			{
				if (ucSelectRecordID_Hosts.IsSelectedExist)
					oGoods.FilterHostsList = ucSelectRecordID_Hosts.GetIdString();
			}
			oGoods.FillTableGoodsGroups();
			RFMCursorWait.Set(false);
			if (oGoods.ErrorNumber != 0 || oGoods.TableGoodsGroups == null)
			{
				RFMMessage.MessageBoxError("ќшибка при получении данных (товарные группы)...");
				return;
			}
			if (oGoods.TableGoodsGroups.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Ќет данных (товарные группы)...");
				return;
			}

			ucSelectRecordID_GoodsGroups.Restore(oGoods.TableGoodsGroups);
		}

		#endregion GoodsGroups

		#region GoodsBrands

		private void ucSelectRecordID_GoodsBrands_Restore()
		{
			RFMCursorWait.Set(true);
			ucSelectRecordID_GoodsBrands.sourceData = null;
			oGoods.FilterGoodsBrandsList = null;
			oGoods.FilterHostsList = null;
			if (nHostID.HasValue)
			{
				oGoods.FilterHostsList = nHostID.ToString();
			}
			else
			{
				if (ucSelectRecordID_Hosts.IsSelectedExist)
					oGoods.FilterHostsList = ucSelectRecordID_Hosts.GetIdString();
			}
			oGoods.FillTableGoodsBrands();
			RFMCursorWait.Set(false);
			if (oGoods.ErrorNumber != 0 || oGoods.TableGoodsBrands == null)
			{
				RFMMessage.MessageBoxError("ќшибка при получении данных (товарные бренды)...");
				return;
			}
			if (oGoods.TableGoodsBrands.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Ќет данных (товарные бренды)...");
				return;
			}
			ucSelectRecordID_GoodsBrands.Restore(oGoods.TableGoodsBrands);
		}

		#endregion GoodsBrands

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
					RFMMessage.MessageBoxError("ќшибка при получении данных (хосты)...");
					return;
				}
				if (oHost.MainTable.Rows.Count == 0)
				{
					RFMMessage.MessageBoxError("Ќет данных (хосты)...");
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

	#endregion ¬ыбор группы, бренда, хоста

	#region Actual

		private void chkGoodsActual_CheckedChanged(object sender, EventArgs e)
		{
			tvwGoods.IsActualOnly = chkGoodsActual.Checked;
			if (tvwGoods.Visible && tvwGoods.TreeSource != null)
			{
				tvwGoods_Restore();
			}
		}

	#endregion Actual

	#region Restore

		private void grdData_Restore()
		{
			oGoods.ClearError();
			oGoods.ClearFilters();

			// собираем услови€
			if (ucSelectRecordID_GoodsGroups.IsSelectedExist)
				oGoods.FilterGoodsGroupsList = ucSelectRecordID_GoodsGroups.GetIdString();
			if (ucSelectRecordID_GoodsBrands.IsSelectedExist)
				oGoods.FilterGoodsBrandsList = ucSelectRecordID_GoodsBrands.GetIdString();

			if (txtGoodBarCode.Text.Trim().Length > 0)
				oGoods.FilterGoodBarCode = txtGoodBarCode.Text.Trim();
			if (txtName.Text.Trim().Length > 0)
				oGoods.FilterGoodNameContext = txtName.Text.Trim();

			if (chkGoodsActual.Checked)
				oGoods.FilterGoodsActual = true;
			if (chkPackingsActual.Checked)
				oGoods.FilterPackingsActual = true;

			if (nHostID.HasValue || nUserHostID.HasValue)
			{
				if (nHostID.HasValue)
					oGoods.FilterHostsList = nHostID.ToString();
				if (nUserHostID.HasValue)
					oGoods.FilterHostsList = nUserHostID.ToString();
			}
			else
			{
				if (ucSelectRecordID_Hosts.IsSelectedExist)
					oGoods.FilterHostsList = ucSelectRecordID_Hosts.GetIdString();
			}

			if (tvwGoods.Visible && tvwGoods.TreeSource != null && tvwGoods.GetMarkedNodes() > 0)
			{
				tvwGoods.TreeSource.Filter = "IsMarked";
				tvwGoods.TreeSource.MoveFirst();
				for (int i = 0; i < tvwGoods.TreeSource.Count; i++)
				{
					oGoods.FilterGoodsIDList = oGoods.FilterGoodsIDList + "," + ((DataRowView)tvwGoods.TreeSource.Current)["ID"];
					tvwGoods.TreeSource.MoveNext();
				}
				tvwGoods.TreeSource.RemoveFilter();
			}

			oGoods.FillData();

			// артикул
			if (txtArticul.Text.Trim().Length > 0)
			{
				tTable = CopyTable(oGoods.MainTable, "tTable", "Articul LIKE '*" + txtArticul.Text.Trim().ToUpper() + "*'", "");
			}
			else
			{
				tTable = oGoods.MainTable;
			}

			grdData.Restore(tTable);
		}

	#endregion Restore

	}
}