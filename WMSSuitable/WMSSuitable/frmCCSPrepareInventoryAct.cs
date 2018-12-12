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
	public partial class frmCCSPrepareInventoryAct : RFMFormChild
    {
        #region Fields

        private int snapshotID;

        private Partner oOwners = new Partner();
        private CellContentSnapshot oCCS = new CellContentSnapshot();

        // для фильтров
        public string _SelectedIDList;
        public string _SelectedText;

        public string _SelectedPackingIDList;
        public string _SelectedPackingAliasText;
        private string sSelectedPackingsIDList = "";

        private string sSelectedGoodsStatesIDList = "";

        private Host oHost;
        private int? nUserHostID = null;

        #endregion

        public frmCCSPrepareInventoryAct(int SnapshotID)
		{
            oHost = new Host();
            if (oHost.ErrorNumber != 0)
            {
                IsValid = false;
            }

            if (IsValid)
            {
                InitializeComponent();
            }

            snapshotID = SnapshotID;
		}

		private void frmShifts_Load(object sender, EventArgs e)
		{
            nUserHostID = ((RFMFormMain)Application.OpenForms[0]).UserInfo.HostID;

            ucSelectRecordID_Hosts.Visible =
            ucSelectRecordID_Hosts.Enabled =
                (oHost.Count() > 1 && !nUserHostID.HasValue);

            if (!cboOwners_Restore())
            {
                RFMMessage.MessageBoxError("Ошибка получения списка владельцев...");
                Dispose();
                return;
            }
        }



        #region Owners Restore

        private bool cboOwners_Restore()
        {
            oOwners.FilterOwner = true;
            oOwners.FilterActual = true;
            oOwners.FillData();

            cboOwners.ValueMember = oOwners.ColumnID;
            cboOwners.DisplayMember = oOwners.MainTable.Columns[("Name")].ToString();
            cboOwners.DataSource = oOwners.MainTable;
            cboOwners.SelectedIndex = -1;
            return (oOwners.ErrorNumber == 0);
        }

        #endregion



        #region Filters Choose

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
            }

            _SelectedIDList = null;
            _SelectedText = "";
        }

        private void btnGoodsStatesClear_Click(object sender, EventArgs e)
        {
            ttToolTip.SetToolTip(txtGoodsStatesChoosen, "не выбраны");
            sSelectedGoodsStatesIDList = "";
            txtGoodsStatesChoosen.Text = "";
        }

        #endregion GoodsStates

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
            }

            _SelectedPackingIDList = null;
            _SelectedPackingAliasText = "";
        }

        private void btnPackingsClear_Click(object sender, EventArgs e)
        {
            ttToolTip.SetToolTip(txtPackingsChoosen, "не выбраны");
            sSelectedPackingsIDList = "";
            txtPackingsChoosen.Text = "";
        }

        #endregion

        #endregion



        #region Buttons

        private void btnFilter_Click(object sender, EventArgs e)
        {
            WaitOn(this);
            grdData_Restore();
            WaitOff(this);
            grdData.Select();
        }

        private void btnExit_Click(object sender, EventArgs e)
		{
			Dispose();
		}

		private void btnHelp_Click(object sender, EventArgs e)
		{
			RFMHelpUtilities.HelpShow(this, hpHelp);
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
            if (grdData.DataSource == null || oCCS.TablePrepareInventoryAct.Rows.Count == 0)
				return;

            int nMarkedRowsCount = grdData.GetMarkedRows();
            if (nMarkedRowsCount == 0)
            {
                RFMMessage.MessageBoxError("Не отмечено ни одной записи!");
                return;
            }

            // Замена для пустого владельца
            int? nEmptyOwnerID = (int?)cboOwners.SelectedValue;
            string sEmptyOwnerName = (cboOwners.Text.Length > 0 ? cboOwners.Text : "");

            // Копирование выбранных записей во временную отсортированную таблицу
            DataTable sortedTable = CopyTable(oCCS.TablePrepareInventoryAct, 
                "GoodsForAct", 
                "Qnt <> 0 AND IsMarked = true", 
                "HostName, OwnerName, GoodStateName, GoodGroupName, GoodName");
            if (sortedTable.Rows.Count == 0)
            {
                RFMMessage.MessageBoxError("Нечего сохранять!");
                return;
            }

            // Подсчет количества создаваемых актов и проверка на пустых владельцев
            List<string> combinations = new List<string>();
            List<string> emptyHosts = new List<string>();
            string sHostName, sOwnerName, sGoodStateName, sCombination;
            foreach (DataRow r in sortedTable.Rows)
            {
                sHostName = r["HostName"].ToString();
                sOwnerName = r["OwnerName"].ToString();
                sGoodStateName = r["GoodStateName"].ToString();
                sCombination = sHostName + "$" + (sOwnerName.Length > 0 ? sOwnerName : sEmptyOwnerName) + "$" + sGoodStateName;

                if (!combinations.Contains(sCombination))
                {
                    // Добавление нового сочетания параметров акта
                    combinations.Add(sCombination);

                    // Добавление в список нового хоста для пустого владельца
                    if (sOwnerName.Length == 0)
                    {
                        if (!emptyHosts.Contains(sHostName))
                            emptyHosts.Add(sHostName);
                    }
                }
            }

            // Проверки допустимости сохранения данных
            if (emptyHosts.Count > 1)
            {
                RFMMessage.MessageBoxError("Обнаружено несколько хостов с пустым владельцем!\r\nСохранение невозможно!");
                return;
            }
            else if (emptyHosts.Count == 1 && !nEmptyOwnerID.HasValue)
            {
                RFMMessage.MessageBoxError("Не выбрана замена для актов с пустым владельцем!\r\nСохранение невозможно!");
                return;
            }
            
            // Последнее китайское предупреждение
            if (RFMMessage.MessageBoxYesNo("Создать " + RFMUtilities.Declen(combinations.Count, "акт", "акта", "актов") + 
                    "?\r\nВнимание, данная операция необратима!") != DialogResult.Yes)
                return;

            // Замена пустого владельца
            if (emptyHosts.Count > 0)
            {
                foreach (DataRow r in sortedTable.Rows)
                {
                    if (r["OwnerName"].ToString().Length == 0)
                        r["OwnerID"] = nEmptyOwnerID;
                }
            }

            // Сохранение актов
            System.IO.StringWriter writer = new System.IO.StringWriter();
            sortedTable.WriteXml(writer);

            this.Cursor = Cursors.WaitCursor;
            bool bResult = oCCS.SaveInventoryAct(snapshotID, writer.ToString(), sortedTable.TableName);
            this.Cursor = null;

            if (!bResult)
            {
                RFMMessage.MessageBoxError(oCCS.ErrorStr);
                return;
            }

            this.Close();
		}

		#endregion 

		#region Restore

		private bool grdData_Restore()
		{
            RFMCursorWait.Set(true);
            RFMCursorWait.LockWindowUpdate(FindForm().Handle);

            grdData.GetGridState();

            string sSelectedHostsIDList = "";
            if (ucSelectRecordID_Hosts.IsSelectedExist)
            {
                sSelectedHostsIDList = ucSelectRecordID_Hosts.GetIdString();
            }


            if (oCCS.FillTablePrepareInventoryAct(this.snapshotID, 
                sSelectedHostsIDList, sSelectedGoodsStatesIDList, sSelectedPackingsIDList))
            {
                grdData.Restore(oCCS.TablePrepareInventoryAct);
            }

            RFMCursorWait.LockWindowUpdate(IntPtr.Zero);
            RFMCursorWait.Set(false);

            return (oCCS.ErrorNumber == 0);
		}

        #endregion

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

    }
}
