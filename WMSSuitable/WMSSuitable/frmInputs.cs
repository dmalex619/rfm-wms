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
	public partial class frmInputs : RFMFormChild
	{
		private Input oInputList; //список приходов
		private Input oInputCur; //текущий приход

		public string _SelectedIDList;
		public string _SelectedText;

		private string sSelectedInputsTypesIDList = "";
		private string sSelectedGoodsStatesIDList = "";
		private string sSelectedPartnersIDList = "";
		private string sSelectedOwnersIDList = "";
		private string sSelectedUsersIDList = "";

		public string _SelectedPackingIDList;
		public string _SelectedPackingAliasText;
		private string sSelectedPackingsIDList = "";

		private Host oHost;
		private int? nUserHostID = null;


		public frmInputs()
		{
			oInputList = new Input();
			oInputCur = new Input();
			if (oInputList.ErrorNumber != 0 ||
				oInputCur.ErrorNumber != 0)
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

		private void frmInputs_Load(object sender, EventArgs e)
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
			grcQntArranged.AgrType =
			grcBoxArranged.AgrType =
			grcPalArranged.AgrType =
			grcQntConfirmed.AgrType =
			grcBoxConfirmed.AgrType =
			grcPalConfirmed.AgrType =
			grcQntDiff.AgrType =
			grcBoxDiff.AgrType =
			grcPalDiff.AgrType =
			grcQntArrangedDiff.AgrType =
			grcBoxArrangedDiff.AgrType =
			grcPalArrangedDiff.AgrType =
			grcWishedQnt.AgrType =
			grcWishedBox.AgrType =
			grcWishedPal.AgrType =
			grcConfirmedBox.AgrType =
			grcConfirmedPal.AgrType =
			grcConfirmedQnt.AgrType =
			grcDiffQnt.AgrType =
			grcDiffBox.AgrType =
			grcDiffPal.AgrType =
			grcFrameQnt.AgrType =
			grcFrameBoxQnt.AgrType =
			grcFramePalQnt.AgrType =
			grcNettoWished.AgrType =
			grcBruttoWished.AgrType =
			grcNettoConfirmed.AgrType =
			grcBruttoConfirmed.AgrType =
			grcFrameWeight.AgrType =
			grcTrafficsFramesFrameWeight.AgrType =
			grcItemsQnt.AgrType =
			grcItemsBoxes.AgrType =
			grcItemsPallets.AgrType =
			grcPalletsFactQnt.AgrType = 
				EnumAgregate.Sum;

			// цвет колонок
			grdInputsGoods.ChangeColumnColor("grcQntArrangedDiff", Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(200))))), Color.Empty);
			grdInputsGoods.ChangeColumnColor("grcQntDiff", Color.Red, Color.Empty);

			grdInputsGoods.ChangeColumnColor("grcBoxArrangedDiff", Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(200))))), Color.Empty);
			grdInputsGoods.ChangeColumnColor("grcBoxDiff", Color.Red, Color.Empty);

			grdInputsGoods.ChangeColumnColor("grcPalArrangedDiff", Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(200))))), Color.Empty);
			grdInputsGoods.ChangeColumnColor("grcPalDiff", Color.Red, Color.Empty);
			//	

			btnClearTerms_Click(null, null);

			tcList.Init();
			tcInputsGoods.Init();

			txtBarCode.Select();

			RFMCursorWait.Set(false);
		}

		#region Tab Restore

		private bool tabTerms_Restore()
		{
			btnBarCodeFind.Enabled =
			btnAdd.Enabled = // не исп.
			btnDelete.Enabled =
			btnEdit.Enabled =
			btnConfirm.Enabled =
			btnArrange.Enabled =
			btnPrint.Enabled =
			btnInputBoxesEdit.Enabled =
			btnService.Enabled = false;
			return true;
		}

		private bool tabData_Restore()
		{
			grdData_Restore();
			btnAdd.Enabled = false;
			if (grdData.Rows.Count > 0)
			{
				btnPrint.Enabled =
				btnService.Enabled = true;
			}
			else
			{
				btnPrint.Enabled =
				btnDelete.Enabled =
				btnService.Enabled = false;
			}
			return true;
		}

		#region Bottom Tab Restore

		private bool tabInputsGoods_Restore()
		{
			return grdInputsGoods_Restore();
		}

		private bool tabItems_Restore()
		{
			return grdItems_Restore();
		}

		private bool tabFrames_Restore()
		{
			return grdInputsFrames_Restore();
		}

		private bool tabTrafficsFrames_Restore()
		{
			return grdTrafficsFrames_Restore();
		}

		private bool tabConfirmedGoods_Restore()
		{
			return grdInputsGoodsTotal_Restore();
		}

		private bool tabInputsUnloaders_Restore()
		{
			return grdInputsUnloaders_Restore();
		}

		#endregion Bottom Tab Restore

		private void tcList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tcList.SelectedTab.Name.ToUpper().Contains("TERMS"))
			{
				btnBarCodeFind.Enabled =
				btnAdd.Enabled = // не исп.
				btnEdit.Enabled =
				btnInputBoxesEdit.Enabled =
				btnDelete.Enabled =
				btnConfirm.Enabled =
				btnArrange.Enabled =
				btnPrint.Enabled =
				btnService.Enabled = false;
			}

			if (tcList.SelectedTab.Name.ToUpper().Contains("DATA"))
			{
				grdData.Select();
			}
		}

		#endregion Tab Restore

		#region Prepare IDList

		public void InputPrepareIDList(Input oInput, bool bMultiSelect)
		{
			oInput.ID = null;
			oInput.IDList = null;
			int? nInputID = 0;
			if (bMultiSelect && grdData.IsCheckerShow)
			{
				oInput.IDList = "";

				DataView dMarked = new DataView(oInputList.MainTable);
				dMarked.RowFilter = "IsMarked = true";
				//dMarked.Sort = ((DataView)((WMSBindingSource)grdData.DataSource).DataSource).Sort; 
				dMarked.Sort = grdData.GridSource.Sort;
				foreach (DataRowView r in dMarked)
				{
					if (!Convert.IsDBNull(r["ID"]))
					{
						nInputID = (int)r["ID"];
						oInput.IDList = oInput.IDList + nInputID.ToString() + ",";
					}
				}
			}
			else
			{
				nInputID = (int?)grdData.CurrentRow.Cells["grcID"].Value;
				if (nInputID.HasValue)
				{
					oInput.ID = nInputID;
				}
			}
		}

		#endregion Prepare IDList

		#region Buttons

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (grdData.CurrentRow == null)
				return;
			if (Convert.IsDBNull(grdData.CurrentRow.Cells["grcID"].Value))
				return;

			oInputCur.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			if (RFMMessage.MessageBoxYesNo("Удалить приход с кодом " + oInputCur.ID.ToString() + " ?") != DialogResult.Yes)
				return;

			oInputCur.ClearError();
			oInputCur.DeleteData((int)oInputCur.ID);
			if (oInputCur.ErrorNumber == 0)
			{
				grdData_Restore();
			}
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			if (StartForm(new frmInputsEdit(null)) == DialogResult.Yes)
			{
				int nInputID = (int)GotParam.GetValue(0);
				grdData_Restore();
				if (nInputID > 0)
				{
					grdData.GridSource.Position = grdData.GridSource.Find(oInputList.ColumnID, nInputID);
				}
			}
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			if (grdData.CurrentRow == null)
				return;

			if (Convert.IsDBNull(grdData.CurrentRow.Cells["grcID"].Value))
				return;

			oInputCur.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;

			// обработка начата? тот же пользователь?
			Input oInputTemp = new Input();
			oInputTemp.ID = oInputCur.ID;
			oInputTemp.FillData();
			if (oInputTemp.ErrorNumber != 0 || oInputTemp.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о текущем приходе...");
				return;
			}
			DataRow r = oInputTemp.MainTable.Rows[0];
			if (!Convert.IsDBNull(r["DateConfirm"]))
			{
				RFMMessage.MessageBoxError("Приход уже подтвержден...");
				return;
			}

			if (!Convert.IsDBNull(r["DateStart"]))
			{
				// приход уже обрабатывается кем?
				oInputTemp.FillTableInputsItems(oInputTemp.ID);
				if (oInputTemp.ErrorNumber != 0)
				{
					RFMMessage.MessageBoxError("Ошибка при получении данных о составляющих текущего прихода...");
					return;
				}
				if (oInputTemp.TableInputsItems.Rows.Count > 0)
				{
					DataRow ri = oInputTemp.TableInputsItems.Rows[oInputTemp.TableInputsItems.Rows.Count - 1]; // последняя строка
					if (!Convert.IsDBNull(ri["UserID"]) &&
						Convert.ToInt32(ri["UserID"]) != ((RFMFormBase)Application.OpenForms[0]).UserInfo.UserID)
					{
						if (RFMMessage.MessageBoxYesNo("Внимание!\n\r\n\r" +
							"Возможно, данный приход уже обрабатывается пользователем '" + ri["UserName"].ToString().Trim() + "'\n\r" +
							"(нач." + Convert.ToDateTime(r["DateStart"]).ToString("dd.MM.yyyy HH:mm") + ").\r\n\r\n" +
							"Все-таки редактировать приход?") != DialogResult.Yes)
							return;
					}
				}
			}
			Refresh();

			if (StartForm(new frmInputsEdit((int)oInputCur.ID)) == DialogResult.Yes)
			{
				grdData_Restore();
			}
		}

		private void btnInputBoxesEdit_Click(object sender, EventArgs e)
		{
			if (grdData.CurrentRow == null)
				return;

			if (Convert.IsDBNull(grdData.CurrentRow.Cells["grcID"].Value))
				return;

			oInputCur.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;

			//приход подтвержден?   
			Input oInputTemp = new Input();
			oInputTemp.ID = oInputCur.ID;
			oInputTemp.FillData();
			if (oInputTemp.ErrorNumber != 0 || oInputTemp.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о текущем приходе...");
				return;
			}
			DataRow r = oInputTemp.MainTable.Rows[0];
			if (!Convert.IsDBNull(r["DateConfirm"]))
			{
				RFMMessage.MessageBoxError("Приход уже подтвержден...");
				return;
			}

			oInputTemp.FillTableInputsItems(oInputTemp.ID);
			if (oInputTemp.ErrorNumber != 0)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных об обработанных товарах текущего прихода...");
				return;
			}
			bool bHasFrame = false;
			for (int i = 0; i < oInputTemp.TableInputsItems.Rows.Count; i++)
			{
				if (!Convert.IsDBNull(oInputTemp.TableInputsItems.Rows[i]["FrameID"]))
				{
					bHasFrame = true;
					break;
				}
			}
			if (bHasFrame)
			{
				RFMMessage.MessageBoxError("Приход содержит контейнер.\nВоспользуйтесь стандартной процедурой прихода...");
				return;
			}

			oInputTemp.FillTableInputsGoodsItems(oInputTemp.ID, false);
			if (oInputTemp.ErrorNumber != 0 || oInputTemp.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о товарах текущего прихода...");
				return;
			}
			//не принят ли уже контейнер, нет ли товара по количеству больше паллеты
			bool bIsGTF = false;
			for (int i = 0; i < oInputTemp.TableInputsGoods.Rows.Count; i++)
			{
				if ((decimal)oInputTemp.TableInputsGoods.Rows[i]["PalWished"] >= 1)
				{
					bIsGTF = true;
					break;
				}
			}
			if (bIsGTF && RFMMessage.MessageBoxYesNo("В приходе есть товары с ожидаемым количеством большим, " +
						"чем паллета.\nВсе равно продолжать?") == DialogResult.No)
				return;

			// обработка начата? тот же пользователь?
			if (!Convert.IsDBNull(r["DateStart"]))
			{
				// приход уже обрабатывается кем?
				if (oInputTemp.TableInputsItems.Rows.Count > 0)
				{
					DataRow ri = oInputTemp.TableInputsItems.Rows[oInputTemp.TableInputsItems.Rows.Count - 1]; // последняя строка
					if (!Convert.IsDBNull(ri["UserID"]) &&
						Convert.ToInt32(ri["UserID"]) != ((RFMFormBase)Application.OpenForms[0]).UserInfo.UserID)
					{
						if (RFMMessage.MessageBoxYesNo("Внимание!\n\r\n\r" +
							"Возможно, данный приход уже обрабатывается пользователем '" + ri["UserName"].ToString().Trim() + "'\n\r" +
							"(нач." + Convert.ToDateTime(r["DateStart"]).ToString("dd.MM.yyyy HH:mm") + ").\r\n\r\n" +
							"Все-таки редактировать приход?") != DialogResult.Yes)
							return;
					}
				}
			}
			Refresh();

			if (StartForm(new frmInputsBoxesEdit(oInputCur.ID)) == DialogResult.Yes)
			{
				grdData_Restore();
			}
		}

		private void btnConfirm_Click(object sender, EventArgs e)
		{
			if (grdData.CurrentRow == null)
				return;

			if (Convert.IsDBNull(grdData.CurrentRow.Cells["grcID"].Value))
				return;

			oInputCur.ClearError();
			oInputCur.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;

			oInputCur.FillTableInputsItems((int)oInputCur.ID);
			if (oInputCur.ErrorNumber != 0)
			{
				RFMMessage.MessageBoxError("Ошибка при получении составляющих прихода...");
				return;
			}
			if (oInputCur.TableInputsItems.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Нет ни одного обработанного товара!\r\n" +
						"Подтверждение невозможно...");
				return;
			}

			oInputCur.FillTableInputsGoodsItems((int)oInputCur.ID, true);
			if (oInputCur.ErrorNumber != 0)
			{
				RFMMessage.MessageBoxError("Ошибка при получении товаров в приходе...");
				return;
			}
			if (oInputCur.TableInputsGoodsTotal.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Нет ни одного товара!\r\n" +
						"Подтверждение невозможно...");
				return;
			}

			// проверки по количеству
			bool bAsked = false;
			StringBuilder sbAbsent = new StringBuilder("");
			StringBuilder sbNewsOnly = new StringBuilder("");
			StringBuilder sbWishedLess = new StringBuilder("");
			StringBuilder sbWishedMore = new StringBuilder("");
			StringBuilder sbArranged = new StringBuilder("");
			foreach (DataRow droInGoods in oInputCur.TableInputsGoodsTotal.Rows)
			{
				if (Convert.ToDecimal(droInGoods["QntArranged"]) == 0)
				{
					sbAbsent = sbAbsent.Append(droInGoods["GoodAlias"].ToString() + "\r\n");
				}
				else
				{
					if (Convert.ToDecimal(droInGoods["QntWished"]) == 0)
					{
						sbNewsOnly = sbNewsOnly.Append(droInGoods["GoodAlias"].ToString() + "\r\n");
					}
					else
					{
						if (Convert.ToDecimal(droInGoods["QntArranged"]) < Convert.ToDecimal(droInGoods["QntWished"]))
						{
							sbWishedMore = sbWishedMore.Append(droInGoods["GoodAlias"].ToString() + "\r\n");
						}
						else
						{
							if (Convert.ToDecimal(droInGoods["QntArranged"]) > Convert.ToDecimal(droInGoods["QntWished"]))
							{
								sbWishedLess = sbWishedLess.Append(droInGoods["GoodAlias"].ToString() + "\r\n");
							}
						}
					}
				}
			}

			if (sbAbsent.Length > 0)
			{
				bAsked = true;
				if (RFMMessage.MessageBoxYesNo("НЕ ВВЕДЕНЫ данные по товарам:\r\n\r\n" +
					sbAbsent + "\r\n" +
					"Все-таки подтвердить приход?") == DialogResult.No)
					return;
			}
			if (sbNewsOnly.Length > 0)
			{
				bAsked = true;
				if (RFMMessage.MessageBoxYesNo("Введены данные по НЕЗАКАЗАННЫМ товарам:\r\n\r\n" +
					sbNewsOnly + "\r\n" +
					"Все-таки подтвердить приход?") == DialogResult.No)
					return;
			}
			if (sbWishedLess.Length > 0)
			{
				bAsked = true;
				if (RFMMessage.MessageBoxYesNo("Для следующих товаров:\r\n\r\n" +
					sbWishedLess + "\r\n" +
					"подтверждаемое количество БОЛЬШЕ заказанного.\r\n\r\n" +
					"Все-таки подтвердить приход?") == DialogResult.No)
					return;
			}
			if (sbWishedMore.Length > 0)
			{
				bAsked = true;
				if (RFMMessage.MessageBoxYesNo("Для следующих товаров:\r\n\r\n" +
					sbWishedMore + "\r\n" +
					"подтверждаемое количество МЕНЬШЕ заказанного.\r\n\r\n" +
					"Все-таки подтвердить приход?") == DialogResult.No)
					return;
			}

			if (bAsked ||
				RFMMessage.MessageBoxYesNo("Подтвердить приход?") == DialogResult.Yes)
			{
				Refresh();
				WaitOn(this);
				bool bResult = oInputCur.ConfirmData((int)oInputCur.ID,
						((RFMFormBase)Application.OpenForms[0]).UserInfo.UserID);
				WaitOff(this);
				if (bResult && oInputCur.ErrorNumber == 0)
				{
					RFMMessage.MessageBoxInfo("Приход подтвержден.");
					StartForm(new frmInputsUnloaders((int)oInputCur.ID));
				}
				else
				{
					RFMMessage.MessageBoxError("Ошибка при подтверждении прихода...");
				}
				grdData_Restore();
			}
		}

		private void btnBarCodeFind_Click(object sender, EventArgs e)
		{
			if (StartForm(new frmInputBoxBarCode("Штрих-код прихода:", "")) == DialogResult.Yes)
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
			this.Dispose();
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

			tabInputsGoods.IsNeedRestore =
			tabItems.IsNeedRestore =
			tabFrames.IsNeedRestore =
			tabTrafficsFrames.IsNeedRestore =
			tabConfirmedGoods.IsNeedRestore = 
				true;

			btnBarCodeFind.Enabled =
			btnPrint.Enabled =
			btnService.Enabled = 
				true;

			if (grdData.IsStatusRow(rowIndex))
			{
				oInputCur.ID = 0;
				btnConfirm.Enabled =
				btnArrange.Enabled =
				btnDelete.Enabled =
				btnEdit.Enabled =
				btnInputBoxesEdit.Enabled = 
					false;
			}
			else
			{
				DataGridViewRow r = grdData.Rows[rowIndex];
				oInputCur.ID = (int)r.Cells["grcID"].Value;
				bool bIsConfirmed = (bool)r.Cells["grcIsConfirmed"].Value;
				bool bIsInWork = Convert.IsDBNull(r.Cells["grcDateStart"].Value);
				btnEdit.Enabled = !bIsConfirmed;
				btnConfirm.Enabled = !bIsConfirmed;

                // Исправление от 27.07.2017 Александров
                //btnArrange.Enabled = !bIsConfirmed;
                btnArrange.Enabled = true;

                btnInputBoxesEdit.Enabled = !bIsConfirmed;
				btnDelete.Enabled = bIsInWork;
			}

			tcInputsGoods.SetAllNeedRestore(true);
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
						e.Value = Properties.Resources.Empty;
						break;
				}
				return;
			}

			switch (grdData.Columns[e.ColumnIndex].Name)
			{
				case "grcIsConfirmedImage":
					if (Convert.ToBoolean(grdData.Rows[e.RowIndex].Cells["grcIsConfirmed"].Value))
						e.Value = Properties.Resources.Check;
					else
						e.Value = Properties.Resources.Empty;
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

		private void grdInputsGoods_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			RFMDataGridView grd = grdInputsGoods;

			if (grd.DataSource == null)
				return;

			if (grd.IsStatusRow(e.RowIndex))
			{
				switch (grd.Columns[e.ColumnIndex].Name)
				{
					case "grcResult":
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
				case "grcQntWished":
				case "grcQntArranged":
				case "grcQntConfirmed":
				case "grcQntDiff":
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

		private void grdInputsFrames_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			RFMDataGridView grd = grdInputsFrames;

			if (grd.DataSource == null)
				return;

			if (grd.IsStatusRow(e.RowIndex))
			{
				switch (grd.Columns[e.ColumnIndex].Name)
				{
					case "grcResultTraffic":
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
				case "grcResultTraffic":
					if (Convert.ToBoolean(r.Cells["grcHasTraffics"].Value))
					{
						if (Convert.ToBoolean(r.Cells["grcHasNotConfirmedTraffics"].Value))
							e.Value = Properties.Resources.DotYellow;
						else
							e.Value = Properties.Resources.DotGreen;
					}
					else
					{
						e.Value = Properties.Resources.DotRed;
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

		private void grdInputsGoodsTotal_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			RFMDataGridView grd = grdInputsGoodsTotal;

			if (grd.DataSource == null)
				return;

			if (grd.IsStatusRow(e.RowIndex))
			{
				return;
			}

			DataGridViewRow r = grd.Rows[e.RowIndex];
			switch (grd.Columns[e.ColumnIndex].Name)
			{
				case "grcWishedQnt":
				case "grcConfirmedQnt":
				case "grcDiffQnt":
				case "grcGoodInBox":
					if (!Convert.IsDBNull(r.Cells["grcGoodWeighting"].Value) &&
						Convert.ToBoolean(r.Cells["grcGoodWeighting"].Value) ||
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
				 grd.Columns[e.ColumnIndex].Name.Contains("Pal")) &&
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

			oInputCur.ID = null;
			
			oInputList.ClearError();
			oInputList.ClearFilters();
			oInputList.ID = null;
			oInputList.IDList = null;

			// собираем условия

			// штрих-код
			if (txtBarCode.Text.Trim().Length > 0)
			{
				oInputList.BarCode = txtBarCode.Text.Trim();
			}
			// даты
			if (!dtrDates.dtpBegDate.IsEmpty)
			{
				oInputList.FilterDateBeg = dtrDates.dtpBegDate.Value.Date;
			}
			if (!dtrDates.dtpEndDate.IsEmpty)
			{
				oInputList.FilterDateEnd = dtrDates.dtpEndDate.Value.Date;
			}
			// тип прихода
			if (sSelectedInputsTypesIDList.Length > 0)
			{
				oInputList.FilterInputsTypesList = sSelectedInputsTypesIDList;
			}
			// состояние
			if (sSelectedGoodsStatesIDList.Length > 0)
			{
				oInputList.FilterGoodsStatesList = sSelectedGoodsStatesIDList;
				if (optInputsGoodState.Checked)
				{
					oInputList.FilterGoodStateTerm = false;
				}
				if (optInputsGoodsGoodState.Checked)
				{
					oInputList.FilterGoodStateTerm = true;
				}
			}
			// поставщики
			if (sSelectedPartnersIDList.Length > 0)
			{
				oInputList.FilterPartnersList = sSelectedPartnersIDList;
			}
			if (txtPartnerNameContext.Text.Trim().Length > 0)
			{
				oInputList.FilterPartnerContext = txtPartnerNameContext.Text.Trim();
			}

			// владельцы
			if (sSelectedOwnersIDList.Length > 0)
			{
				oInputList.FilterOwnersList = sSelectedOwnersIDList;
			}

			// пользователи
			if (sSelectedUsersIDList.Length > 0)
			{
				oInputList.FilterUsersList = sSelectedUsersIDList;
			}

			// выбранные товары
			if (sSelectedPackingsIDList.Length > 0)
			{
				oInputList.FilterPackingsList = sSelectedPackingsIDList;
			}

			// состояние прихода: начало обработки, подтверждение 
			if (optIsNotConfirmed.Checked)
			{
				oInputList.FilterConfirmed = false;
				// начало обработки
				if (optNotStarted.Checked)
				{
					oInputList.FilterStarted = false;
				}
				if (optStartedNotConfirmed.Checked)
				{
					oInputList.FilterStarted = true;
				}
			}
			if (optIsConfirmed.Checked)
			{
				oInputList.FilterConfirmed = true;
				// даты подтверждения
				if (!dtrDatesConfirm.dtpBegDate.IsEmpty)
				{
					oInputList.FilterDateBegConfirm = dtrDatesConfirm.dtpBegDate.Value.Date;
				}
				if (!dtrDatesConfirm.dtpEndDate.IsEmpty)
				{
					oInputList.FilterDateEndConfirm = dtrDatesConfirm.dtpEndDate.Value.Date;
				}
				if (chkConfirmedZeroOnly.Checked)
				{
					oInputList.FilterConfirmedZero = true;
				}
			}

			// состояние контейнеров
			/*
			if (optFramesNotArranged.Checked)
			{
				oInputList.FilterFramesTrafficsCreated = true;
				oInputList.FilterFramesTrafficsConfirmed = false;
			}
			if (optFramesTrafficsNotConfirmed.Checked)
			{
				oInputList.FilterFramesTrafficsCreated = true;
				oInputList.FilterFramesTrafficsConfirmed = true;
			}
			*/
			if (optProblemFramesArrange.Checked)
			{
				oInputList.FilterFramesArrangeProblem = true;
			}
			if (optProblemTrafficsFramesConfirm.Checked)
			{
				oInputList.FilterTrafficsFramesConfirmProblem = true;
			}

			if (nUserHostID.HasValue)
			{
				oInputList.FilterHostsList = nUserHostID.ToString();
			}
			else
			{
				if (ucSelectRecordID_Hosts.IsSelectedExist)
				{
					oInputList.FilterHostsList = ucSelectRecordID_Hosts.GetIdString();
				}
			}
			//

			grdInputsGoods.DataSource = null;
			grdItems.DataSource = null;
			grdInputsFrames.DataSource = null;
			grdTrafficsFrames.DataSource = null;
			grdInputsGoodsTotal.DataSource = null;
			grdInputsUnloaders.DataSource = null;
			
			grdData.GetGridState();

			oInputList.FillData();

			grdData.IsLockRowChanged = true;
			grdData.Restore(oInputList.MainTable);
			tmrRestore.Enabled = true;

			RFMCursorWait.LockWindowUpdate(IntPtr.Zero);
			RFMCursorWait.Set(false);

			return (oInputList.ErrorNumber == 0);
		}

		private bool grdInputsGoods_Restore()
		{
			grdInputsGoods.GetGridState();
			grdInputsGoods.DataSource = null;
			if (grdData.Rows.Count == 0 ||
				oInputCur.ID == null ||
				(grdData.CurrentRow != null && grdData.IsStatusRow(grdData.CurrentRow.Index)))
				return (true);

			oInputList.FillTableInputsGoods((int)oInputCur.ID, false);

			if (chkShowSelectedGoodsOnly.Enabled && chkShowSelectedGoodsOnly.Checked &&
				sSelectedPackingsIDList != null && sSelectedPackingsIDList.Length > 0)
			{
				DataTable dt = CopyTable(oInputList.TableInputsGoods, "dt",
					"PackingID in (" + RFMPublic.RFMUtilities.NormalizeList(sSelectedPackingsIDList) + ")",
					"GoodAlias, ID");
				oInputList.TableInputsGoods.Clear();
				oInputList.TableInputsGoods.Merge(dt);
			}

			grdInputsGoods.Restore(oInputList.TableInputsGoods);
			return (oInputList.ErrorNumber == 0);
		}

		private bool grdItems_Restore()
		{
			grdItems.GetGridState();
			grdItems.DataSource = null;
			if (grdData.Rows.Count == 0 ||
				oInputCur.ID == null ||
				(grdData.CurrentRow != null && grdData.IsStatusRow(grdData.CurrentRow.Index)))
				return (true);

			oInputList.FillTableInputsItems((int)oInputCur.ID);

			if (chkShowSelectedGoodsOnly.Enabled && chkShowSelectedGoodsOnly.Checked &&
				sSelectedPackingsIDList != null && sSelectedPackingsIDList.Length > 0)
			{
				DataTable dt = CopyTable(oInputList.TableInputsItems, "dt",
					"PackingID in (" + RFMPublic.RFMUtilities.NormalizeList(sSelectedPackingsIDList) + ")",
					"ID");
				oInputList.TableInputsItems.Clear();
				oInputList.TableInputsItems.Merge(dt);
			}

			grdItems.Restore(oInputList.TableInputsItems);
			
			return (oInputList.ErrorNumber == 0);
		}

		private bool grdInputsFrames_Restore()
		{
			grdInputsFrames.GetGridState();
			grdInputsFrames.DataSource = null;
			if (grdData.Rows.Count == 0 ||
				oInputCur.ID == null ||
				(grdData.CurrentRow != null && grdData.IsStatusRow(grdData.CurrentRow.Index)))
				return (true);

			oInputList.FillTableInputsFrames((int)oInputCur.ID);
			
			grdInputsFrames.Restore(oInputList.TableInputsFrames);
			
			return (oInputList.ErrorNumber == 0);
		}

		private bool grdTrafficsFrames_Restore()
		{
			grdTrafficsFrames.GetGridState();
			grdTrafficsFrames.DataSource = null;
			if (grdData.Rows.Count == 0 ||
				oInputCur.ID == null ||
				(grdData.CurrentRow != null && grdData.IsStatusRow(grdData.CurrentRow.Index)))
				return (true);

			oInputList.FillTableInputsTraffics((int)oInputCur.ID, true);
			
			grdTrafficsFrames.Restore(oInputList.TableInputsTrafficsFrames);
			
			return (oInputList.ErrorNumber == 0);
		}

		private bool grdInputsGoodsTotal_Restore()
		{
			grdInputsGoodsTotal.GetGridState();
			grdInputsGoodsTotal.DataSource = null;
			if (grdData.Rows.Count == 0 ||
				oInputCur.ID == null ||
				(grdData.CurrentRow != null && grdData.IsStatusRow(grdData.CurrentRow.Index)))
				return (true);

			oInputList.FillTableInputsGoods((int)oInputCur.ID, true);

			if (chkShowSelectedGoodsOnly.Enabled && chkShowSelectedGoodsOnly.Checked &&
				sSelectedPackingsIDList != null && sSelectedPackingsIDList.Length > 0)
			{
				DataTable dt = CopyTable(oInputList.TableInputsGoodsTotal, "dt",
					"PackingID in (" + RFMPublic.RFMUtilities.NormalizeList(sSelectedPackingsIDList) + ")",
					"GoodAlias, InputItemID");
				oInputList.TableInputsGoodsTotal.Clear();
				oInputList.TableInputsGoodsTotal.Merge(dt);
			}

			grdInputsGoodsTotal.Restore(oInputList.TableInputsGoodsTotal);

			return (oInputList.ErrorNumber == 0);
		}

		private bool grdInputsUnloaders_Restore()
		{
			grdInputsUnloaders.GetGridState();
			grdInputsUnloaders.DataSource = null;
			if (grdData.Rows.Count == 0 ||
				oInputCur.ID == null ||
				(grdData.CurrentRow != null && grdData.IsStatusRow(grdData.CurrentRow.Index)))
				return (true);

			oInputList.FillTableInputsUnloaders((int)oInputCur.ID);
			
			grdInputsUnloaders.Restore(oInputList.TableInputsUnloaders);
			
			return (oInputList.ErrorNumber == 0);
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

		private void mniPrintInputBill_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.CurrentRow == null) return;

			RFMCursorWait.Set(true);

			Input oInputPrint = new Input();

			// получение данных 
			oInputPrint.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			oInputPrint.FillData();
			if (oInputPrint.ErrorNumber != 0)
			{
				RFMCursorWait.Set(false);
				return;
			}
			if (oInputPrint.MainTable.Rows.Count == 0)
			{
				RFMCursorWait.Set(false);
				RFMMessage.MessageBoxError("Нет данных о приходе...");
				return;
			}

			oInputPrint.FillTableInputsGoods(oInputCur.ID, true); // Total
			if (oInputPrint.ErrorNumber != 0)
			{
				RFMCursorWait.Set(false);
				return;
			}
			if (oInputPrint.TableInputsGoodsTotal.Rows.Count == 0)
			{
				string sText = "заказанных";
				if (oInputPrint.MainTable.Rows[0]["DateConfirm"] != DBNull.Value)
				{
					sText = "полученных";
				}
				RFMCursorWait.Set(false);
				RFMMessage.MessageBoxError("Нет данных о " + sText + " товарах в приходе...");
				return;
			}

			// все нужные поля - в одну таблицу
			oInputPrint.DS.Relations.Add("r1", oInputPrint.MainTable.Columns["InputID"],
				oInputPrint.TableInputsGoodsTotal.Columns["InputID"]);
			// добавляем нужные поля в таблицу-источник
			RepTableColumnAdd(oInputPrint.TableInputsGoodsTotal);

			RFMCursorWait.Set(false);

			// отчет
			repInputBill rep = new repInputBill();
			StartForm(new frmActiveReport(oInputPrint.TableInputsGoodsTotal, rep));
		}

		private void mniPrintInputBillPallets_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.CurrentRow == null)
				return;

			RFMCursorWait.Set(true);

			Input oInputPrint = new Input();

			oInputPrint.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			oInputPrint.FillData();
			if (oInputPrint.ErrorNumber != 0)
			{
				RFMCursorWait.Set(false);
				return;
			}
			if (oInputPrint.MainTable.Rows.Count == 0)
			{
				RFMCursorWait.Set(false);
				RFMMessage.MessageBoxError("Нет данных о приходе...");
				return;
			}
			if (oInputPrint.MainTable.Rows[0]["DateConfirm"] != DBNull.Value)
			{
				RFMCursorWait.Set(false);
				RFMMessage.MessageBoxError("Приход уже подтвержден...");
				return;
			}

			oInputPrint.FillTableInputsPalletsEach(oInputPrint.ID, "TableInputsGoodsPallets");
			if (oInputPrint.ErrorNumber != 0)
			{
				RFMCursorWait.Set(false);
				return;
			}
			if (oInputPrint.DS.Tables["TableInputsGoodsPallets"].Rows.Count == 0)
			{
				RFMCursorWait.Set(false);
				RFMMessage.MessageBoxError("Нет данных о заказанных товарах в приходе...");
				return;
			}
			DataTable tableInputsGoodsPallets = oInputPrint.DS.Tables["TableInputsGoodsPallets"];

			oInputPrint.DS.Relations.Add("r1", oInputPrint.MainTable.Columns["InputID"],
				tableInputsGoodsPallets.Columns["InputID"]);
			RepTableColumnAdd(tableInputsGoodsPallets);

			RFMCursorWait.Set(false);

			repInputBillPallets rep = new repInputBillPallets();
			StartForm(new frmActiveReport(tableInputsGoodsPallets, rep));
		}

		private void mniPrintInputBillBarCode_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.CurrentRow == null)
				return;

			RFMCursorWait.Set(true);

			bool bAll = ((ToolStripMenuItem)sender).Name.EndsWith("All"); // все отмеченные записи

			Input oInputPrint = new Input();

			if (bAll)
			{
				InputPrepareIDList(oInputPrint, bAll);

				oInputPrint.FillData();
				if (oInputPrint.ErrorNumber != 0)
				{
					RFMCursorWait.Set(false);
					return;
				}
				if (oInputPrint.MainTable.Rows.Count == 0)
				{
					RFMCursorWait.Set(false);
					RFMMessage.MessageBoxError("Нет отмеченных записей...");
					return;
				}

				// таблицы для товаров по всем приходам
				oInputPrint.FillTableInputsGoods(0, true);
				if (oInputPrint.ErrorNumber != 0)
				{
					RFMCursorWait.Set(false);
					return;
				}
				oInputPrint.TableInputsGoodsTotal.PrimaryKey = null;
				oInputPrint.TableInputsGoodsTotal.Columns["PackingID"].Unique = false;
				DataTable tableInputsGoodsTotal = oInputPrint.TableInputsGoodsTotal.Copy();
				foreach (DataRow r in oInputPrint.MainTable.Rows)
				{
					int nInputID = (int)r["ID"];
					oInputPrint.FillTableInputsGoods(nInputID, true);
					if (oInputPrint.ErrorNumber != 0)
					{
						RFMCursorWait.Set(false);
						return;
					}
					oInputPrint.TableInputsGoodsTotal.PrimaryKey = null;
					oInputPrint.TableInputsGoodsTotal.Columns["PackingID"].Unique = false;
					foreach (DataRow dr in oInputPrint.TableInputsGoodsTotal.Rows)
					{
						tableInputsGoodsTotal.ImportRow(dr);
					}
				}

				oInputPrint.TableInputsGoodsTotal.Clear();
				foreach (DataRow dr in tableInputsGoodsTotal.Rows)
				{
					oInputPrint.TableInputsGoodsTotal.ImportRow(dr);
				}

				if (oInputPrint.TableInputsGoodsTotal.Rows.Count == 0)
				{
					RFMCursorWait.Set(false);
					RFMMessage.MessageBoxError("Нет данных о товарах в отмеченных приходах...");
					return;
				}
			}
			else
			{
				oInputPrint.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
				oInputPrint.FillData();
				if (oInputPrint.ErrorNumber != 0)
				{
					RFMCursorWait.Set(false);
					return;
				}
				if (oInputPrint.MainTable.Rows.Count == 0)
				{
					RFMCursorWait.Set(false);
					RFMMessage.MessageBoxError("Нет данных о приходе...");
					return;
				}

				oInputPrint.FillTableInputsGoods(oInputPrint.ID, true);
				if (oInputPrint.ErrorNumber != 0)
				{
					RFMCursorWait.Set(false);
					return;
				}
				if (oInputPrint.TableInputsGoodsTotal.Rows.Count == 0)
				{
					RFMCursorWait.Set(false);
					RFMMessage.MessageBoxError("Нет данных о товарах в приходе...");
					return;
				}
			}


			// проверка корректности штрих-кодов
			// также добавление артикула к названию 
			string sGoodsBarCodesInvalid = "";
			foreach (DataRow r in oInputPrint.TableInputsGoodsTotal.Rows)
			{
				if (!RFMUtilities.IsBarCodeValid(r["GoodBarCode"].ToString()))
				{
					sGoodsBarCodesInvalid += r["GoodAlias"].ToString() + "\n";
				}
				if (r["Articul"].ToString().Length > 0)
				{
					r["GoodAlias"] = r["GoodAlias"].ToString() + Convert.ToChar(13) + Convert.ToChar(10) +
									 "Арт." + r["Articul"].ToString();
				}
			}
			if (sGoodsBarCodesInvalid.Length > 0)
			{
				RFMCursorWait.Set(false);
				RFMMessage.MessageBoxError("Некорректный штрих-код товаров в накладной:\n" + sGoodsBarCodesInvalid);
				return;
			}

			oInputPrint.DS.Relations.Add("r1", oInputPrint.MainTable.Columns["InputID"],
				oInputPrint.TableInputsGoodsTotal.Columns["InputID"]);
			RepTableColumnAdd(oInputPrint.TableInputsGoodsTotal);

			RFMCursorWait.Set(false);

			repInputBillBarCode rep = new repInputBillBarCode();
			StartForm(new frmActiveReport(oInputPrint.TableInputsGoodsTotal, rep));
		}

		private void mniPrintInputBillPickingAddress_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.CurrentRow == null)
				return;

			RFMCursorWait.Set(true);

			bool bAll = ((ToolStripMenuItem)sender).Name.EndsWith("All"); // все отмеченные записи

			Input oInputPrint = new Input();

			if (bAll)
			{
				InputPrepareIDList(oInputPrint, bAll);

				oInputPrint.FillData();
				if (oInputPrint.ErrorNumber != 0 || oInputPrint.MainTable == null)
				{
					RFMCursorWait.Set(false);
					RFMMessage.MessageBoxError("Ошибка при получении данных об отмеченных приходах...");
					return;
				}
				if (oInputPrint.MainTable.Rows.Count == 0)
				{
					RFMCursorWait.Set(false);
					RFMMessage.MessageBoxError("Нет отмеченных приходов...");
					return;
				}

				// таблицы для товаров по всем приходам
				oInputPrint.FillTableInputsGoods(0, true);
				if (oInputPrint.ErrorNumber != 0 || oInputPrint.TableInputsGoodsTotal == null)
				{
					RFMCursorWait.Set(false);
					RFMMessage.MessageBoxError("Ошибка при получении данных о товарах в отмеченных приходах...");
					return;
				}
				oInputPrint.TableInputsGoodsTotal.PrimaryKey = null;
				oInputPrint.TableInputsGoodsTotal.Columns["PackingID"].Unique = false;
				DataTable tableInputsGoodsTotal = oInputPrint.TableInputsGoodsTotal.Copy();
				foreach (DataRow r in oInputPrint.MainTable.Rows)
				{
					int nInputID = (int)r["ID"];
					oInputPrint.FillTableInputsGoods(nInputID, true);
					if (oInputPrint.ErrorNumber != 0 || oInputPrint.TableInputsGoodsTotal == null)
					{
						RFMCursorWait.Set(false);
						RFMMessage.MessageBoxError("Ошибка при получении данных о товарах в отмеченном приходе...");
						return;
					}
					tableInputsGoodsTotal.Merge(oInputPrint.TableInputsGoodsTotal);
				}

				oInputPrint.TableInputsGoodsTotal.Clear();
				oInputPrint.TableInputsGoodsTotal.Merge(tableInputsGoodsTotal); 
				if (oInputPrint.TableInputsGoodsTotal.Rows.Count == 0)
				{
					RFMCursorWait.Set(false);
					RFMMessage.MessageBoxError("Нет данных о товарах в отмеченных приходах...");
					return;
				}
			}
			else
			{
				oInputPrint.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
				oInputPrint.FillData();
				if (oInputPrint.ErrorNumber != 0 || oInputPrint.MainTable == null)
				{
					RFMCursorWait.Set(false);
					RFMMessage.MessageBoxError("Ошибка при получении данных о приходе...");
					return;
				}
				if (oInputPrint.MainTable.Rows.Count == 0)
				{
					RFMCursorWait.Set(false);
					RFMMessage.MessageBoxError("Нет данных о приходе...");
					return;
				}

				oInputPrint.FillTableInputsGoods(oInputPrint.ID, true);
				if (oInputPrint.ErrorNumber != 0 || oInputPrint.TableInputsGoodsTotal == null)
				{
					RFMCursorWait.Set(false);
					RFMMessage.MessageBoxError("Ошибка при получении данных о товарах в приходе...");
					return;
				}
				if (oInputPrint.TableInputsGoodsTotal.Rows.Count == 0)
				{
					RFMCursorWait.Set(false);
					RFMMessage.MessageBoxError("Нет данных о товарах в приходе...");
					return;
				}
			}

			oInputPrint.DS.Relations.Add("r1", oInputPrint.MainTable.Columns["InputID"],
				oInputPrint.TableInputsGoodsTotal.Columns["InputID"]);
			RepTableColumnAdd(oInputPrint.TableInputsGoodsTotal);

			RFMCursorWait.Set(false);

			repInputBillPickingAddress rep = new repInputBillPickingAddress();
			StartForm(new frmActiveReport(oInputPrint.TableInputsGoodsTotal, rep));
		}
		
		private void mniPrintInputBillGoodState_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.CurrentRow == null)
				return;

			RFMCursorWait.Set(true);

			Input oInputPrint = new Input();

			oInputPrint.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			oInputPrint.FillData();
			if (oInputPrint.ErrorNumber != 0)
			{
				RFMCursorWait.Set(false);
				return;
			}
			if (oInputPrint.MainTable.Rows.Count == 0)
			{
				RFMCursorWait.Set(false);
				RFMMessage.MessageBoxError("Нет данных о приходе...");
				return;
			}

			oInputPrint.FillTableInputsGoodsItems(oInputCur.ID, false);
			if (oInputPrint.ErrorNumber != 0)
			{
				RFMCursorWait.Set(false);
				return;
			}
			if (oInputPrint.TableInputsGoods.Rows.Count == 0)
			{
				RFMCursorWait.Set(false);
				RFMMessage.MessageBoxError("Нет данных о товарах в приходе...");
				return;
			}

			oInputPrint.DS.Relations.Add("r1", oInputPrint.MainTable.Columns["InputID"],
				oInputPrint.TableInputsGoods.Columns["InputID"]);
			RepTableColumnAdd(oInputPrint.TableInputsGoods);

			RFMCursorWait.Set(false);

			if (((ToolStripMenuItem)sender).Name.Contains("Arrange"))
			{
				repInputBillGoodStateArrange rep = new repInputBillGoodStateArrange();
				StartForm(new frmActiveReport(oInputPrint.TableInputsGoods, rep));
			}
			else
			{
				repInputBillGoodState rep = new repInputBillGoodState();
				StartForm(new frmActiveReport(oInputPrint.TableInputsGoods, rep));
			}
		}

		private void mniPrintInputAct_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.CurrentRow == null)
				return;

			RFMCursorWait.Set(true);

			Input oInputPrint = new Input();

			oInputPrint.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			oInputPrint.FillData();
			if (oInputPrint.ErrorNumber != 0)
			{
				RFMCursorWait.Set(false);
				return;
			}
			if (oInputPrint.MainTable.Rows.Count == 0)
			{
				RFMCursorWait.Set(false);
				RFMMessage.MessageBoxError("Нет данных о приходе...");
				return;
			}
			if (oInputPrint.MainTable.Rows[0]["DateConfirm"] == DBNull.Value)
			{
				RFMCursorWait.Set(false);
				RFMMessage.MessageBoxInfo("Приход еще не подтвержден...");
				return;
			}

			oInputPrint.FillTableInputsGoods(oInputCur.ID, false);
			if (oInputPrint.ErrorNumber != 0)
			{
				RFMCursorWait.Set(false);
				return;
			}
			if (oInputPrint.TableInputsGoods.Rows.Count == 0)
			{
				RFMCursorWait.Set(false);
				RFMMessage.MessageBoxError("Нет данных о товарах в приходе...");
				return;
			}

			// оставим только записи, в которых есть несовпадения
			for (int i = oInputPrint.TableInputsGoods.Rows.Count - 1; i >= 0; i--)
			{
				DataRow r = oInputPrint.TableInputsGoods.Rows[i];
				if ((decimal)r["QntWished"] == (decimal)r["QntConfirmed"])
					oInputPrint.TableInputsGoods.Rows.Remove(r);
			}
			if (oInputPrint.TableInputsGoods.Rows.Count == 0)
			{
				RFMCursorWait.Set(false);
				RFMMessage.MessageBoxInfo("Нет несовпадений...");
				return;
			}

			oInputPrint.DS.Relations.Add("r1", oInputPrint.MainTable.Columns["InputID"],
				oInputPrint.TableInputsGoods.Columns["InputID"]);
			RepTableColumnAdd(oInputPrint.TableInputsGoods);

			// название и адрес организации
			Setting oSet = new Setting();
			string sWeName = oSet.FillVariable("WeName");
			string sWeAddress = oSet.FillVariable("WeAddress");

			RFMCursorWait.Set(false);

			repInputBillAct rep = new repInputBillAct(sWeName, sWeAddress);
			StartForm(new frmActiveReport(oInputPrint.TableInputsGoods, rep));
		}

		private void RepTableColumnAdd(DataTable tTable)
		{
			tTable.Columns.Add("InputTypeName");
			tTable.Columns["InputTypeName"].Expression = "Parent([r1]).InputTypeName";
			tTable.Columns.Add("InputGoodStateName");
			tTable.Columns["InputGoodStateName"].Expression = "Parent([r1]).GoodStateName";
			tTable.Columns.Add("PartnerName");
			tTable.Columns["PartnerName"].Expression = "Parent([r1]).PartnerName";
			tTable.Columns.Add("OwnerName");
			tTable.Columns["OwnerName"].Expression = "Parent([r1]).OwnerName";
			tTable.Columns.Add("DateInput");
			tTable.Columns["DateInput"].Expression = "Parent([r1]).DateInput";
			tTable.Columns.Add("DateConfirm");
			tTable.Columns["DateConfirm"].Expression = "Parent([r1]).DateConfirm";
			tTable.Columns.Add("InputNote");
			tTable.Columns["InputNote"].Expression = "Parent([r1]).Note";
			tTable.Columns.Add("BarCode");
			tTable.Columns["BarCode"].Expression = "Parent([r1]).BarCode";
			tTable.Columns.Add("InputBarCode");
			tTable.Columns["InputBarCode"].Expression = "Parent([r1]).BarCode";
			tTable.Columns.Add("ErpCode");
			tTable.Columns["ErpCode"].Expression = "Parent([r1]).ErpCode";
			tTable.Columns.Add("InputErpCode");
			tTable.Columns["InputErpCode"].Expression = "Parent([r1]).ErpCode";

			tTable.Columns.Add("DateInputText");
			tTable.Columns.Add("DateConfirmText");
			foreach (DataRow r in tTable.Rows)
			{
				r["DateInputText"] = r["DateInput"].ToString().Substring(0, 10);
				r["DateConfirmText"] = (Convert.IsDBNull(r["DateConfirm"])) ? "Не вып." : "Вып. " + (Convert.ToDateTime(r["DateConfirm"])).ToString("dd.MM.yyyy HH:mm");
			}
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

		private void mniServiceClearDateStart_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.CurrentRow == null)
				return;

			if (Convert.IsDBNull(grdData.CurrentRow.Cells["grcID"].Value))
				return;

			// перечитаем данные о текущем приходе
			oInputCur.ClearError();
			oInputCur.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			oInputCur.FillData();
			// проверки возможности/необходжимости разблокировки прихода
			if (oInputCur.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Приход с кодом " + oInputCur.ID.ToString() + " не найден...");
				return;
			}
			if (oInputCur.MainTable.Rows[0]["DateStart"] == DBNull.Value)
			{
				RFMMessage.MessageBoxError("Приход с кодом " + oInputCur.ID.ToString() + " не заблокирован...");
				return;
			}
			if (oInputCur.MainTable.Rows[0]["DateConfirm"] != DBNull.Value)
			{
				RFMMessage.MessageBoxError("Приход с кодом " + oInputCur.ID.ToString() + " уже подтвержден...");
				return;
			}

			// разблокировка
			if (RFMMessage.MessageBoxYesNo("Разблокировать приход с кодом " + oInputCur.ID.ToString() + "?\n\n" +
				((oInputCur.MainTable.Rows[0]["DateStart"] == DBNull.Value) ? "" : "Oбработка прихода начата: " + oInputCur.MainTable.Rows[0]["DateStart"].ToString().Substring(0, 16)) + "\n\n" +
				"Убедитесь, что другие пользователи не работают с приходом!") == DialogResult.Yes)
			{
				oInputCur.ClearDateStart((int)oInputCur.ID);
				if (oInputCur.ErrorNumber == 0)
					grdData_Restore();
			}
		}

		private void mniServiceConfirmZero_Click(object sender, EventArgs e)
		{
			if (grdData.CurrentRow == null)
				return;

			if (Convert.IsDBNull(grdData.CurrentRow.Cells["grcID"].Value))
				return;

			oInputCur.ClearError();
			oInputCur.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			oInputCur.FillData();

			// проверки возможности "0"-подтверждения - по самому приходу
			if (oInputCur.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Приход с кодом " + oInputCur.ID.ToString() + " не найден...");
				return;
			}
			if (!Convert.IsDBNull(oInputCur.MainTable.Rows[0]["DateConfirm"]))
			{
				RFMMessage.MessageBoxError("Приход с кодом " + oInputCur.ID.ToString() + " уже подтвержден...");
				return;
			}
			if (!Convert.IsDBNull(oInputCur.MainTable.Rows[0]["DateStart"]))
			{
				RFMMessage.MessageBoxError("Приход с кодом " + oInputCur.ID.ToString() + " уже обрабатывается...");
				return;
			}

			// по составляющим
			oInputCur.FillTableInputsItems((int)oInputCur.ID);
			if (oInputCur.ErrorNumber != 0)
			{
				RFMMessage.MessageBoxError("Ошибка при получении составляющих прихода...");
				return;
			}
			if (oInputCur.TableInputsItems.Rows.Count != 0)
			{
				RFMMessage.MessageBoxError("В приходе уже есть обработанные товары (составляющие)...");
				return;
			}

			// по товарам
			oInputCur.FillTableInputsGoodsItems((int)oInputCur.ID, true);
			if (oInputCur.ErrorNumber != 0)
			{
				RFMMessage.MessageBoxError("Ошибка при получении товаров в приходе...");
				return;
			}
			foreach (DataRow droInGoods in oInputCur.TableInputsGoodsTotal.Rows)
			{
				if (Convert.ToDecimal(droInGoods["QntArranged"]) != 0)
				{
					RFMMessage.MessageBoxError("В приходе уже есть обработанные товары...");
					return;
				}
			}

			if (RFMMessage.MessageBoxYesNo("Отклонить приход с кодом " + oInputCur.ID.ToString() + "\n" +
					"(все товары в приходе будут подтверждены с нулевым количеством)?", false) != DialogResult.Yes)
				return;
			if (RFMMessage.MessageBoxYesNo("ВНИМАНИЕ!\n\n" +
					"Отклонение прихода является необратимой операцией!\n\n" +
					"Все-таки зарегистрировать отклонение прихода?", false) != DialogResult.Yes)
				return;

			Refresh();
			WaitOn(this);
			bool bResult = oInputCur.ConfirmData((int)oInputCur.ID,
					((RFMFormBase)Application.OpenForms[0]).UserInfo.UserID);
			WaitOff(this);
			if (bResult && oInputCur.ErrorNumber == 0)
			{
				RFMMessage.MessageBoxInfo("Приход отклонен.");
			}
			else
			{
				RFMMessage.MessageBoxError("Ошибка при отклонении прихода...");
			}
			grdData_Restore();
		}

		private void mniServicePackingsNotFixed_Click(object sender, EventArgs e)
		{
			if (grdData.Rows.Count == 0)
				return;

			string sInputsList = "";
			foreach (DataGridViewRow r in grdData.Rows)
			{
				sInputsList += r.Cells["grcID"].Value.ToString().Trim() + ",";
			}

			StartForm(new frmPackingsNotFixed(null, sInputsList, null));
		}

		private void mniServiceInputsUnloaders_Click(object sender, EventArgs e)
		{
			if (grdData.CurrentRow == null)
				return;

			oInputCur.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			if (StartForm(new frmInputsUnloaders((int)oInputCur.ID)) == DialogResult.Yes)
			{
				grdData_Restore();
			}
		}

		#endregion

		#region Menu Arrange

		private void btnArrange_Click(object sender, EventArgs e)
		{
			mnuArrange.Show(btnPrint, new Point());
		}

		private void mniFramesArrangeAll_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (grdData.CurrentRow == null)
				return;

			if (Convert.IsDBNull(grdData.CurrentRow.Cells["grcID"].Value))
				return;

			WaitOn(this);

			// получение данных 
			Input oInputArr = new Input();
			oInputArr.ID = (int)grdData.CurrentRow.Cells["grcID"].Value;
			oInputArr.FillTableInputsFrames(oInputCur.ID);
			if (oInputArr.TableInputsFrames.Rows.Count == 0)
			{
				WaitOff(this);
				RFMMessage.MessageBoxAttention("Нет данных о контейнерах в приходе...");
				return;
			}
			Frame oFrameArr = new Frame();
			int nNotNeed = 0;
			int nOK = 0;
			int nNotOK = 0;
			foreach (DataRow r in oInputArr.TableInputsFrames.Rows)
			{
				if (!(bool)r["HasTraffics"])
				{
					int nFrameID = (int)r["FrameID"];
					oFrameArr.ClearError();
					oFrameArr.Arrange(nFrameID);
					if (oFrameArr.ErrorNumber == 0)
					{
						nOK++;
					}
					else
					{
						nNotOK++;
					}
				}
				else
				{
					nNotNeed++;
				}
			}
			WaitOff(this);
			if (nNotNeed == oInputArr.TableInputsFrames.Rows.Count)
			{
				WaitOff(this);
				RFMMessage.MessageBoxInfo("Для всех контейнеров в приходе уже выполнен подбор ячеек и созданы транспортировки.");
				return;
			}

			if (nOK > 0)
			{
				RFMMessage.MessageBoxInfo("Выполнен подбор ячеек и созданы операции транспортировки для " +
						RFMUtilities.Declen(nOK, "контейнера", "контейнеров", "контейнеров") + " из " + ((int)(nOK + nNotOK)).ToString().Trim() + ".");
			}
			else
			{
				RFMMessage.MessageBoxError("Подбор ячеек не выполнен" +
					((nNotOK == 0) ? "" : " для " + RFMUtilities.Declen(nNotOK, "контейнера", "контейнеров", "контейнеров")) + "...");
			}

			grdInputsFrames_Restore();
		}

		private void mniFramesArrangeOne_Click(object sender, EventArgs e)
		{
			RFMMenuUtilities.MenuClear((ToolStripMenuItem)sender);

			if (tcInputsGoods.SelectedTab.Name != "tabFrames")
			{
				RFMMessage.MessageBoxError("Размещение одного контейнера выполняется на странице [Контейнеры]...");
				return;
			}

			if (grdInputsFrames.CurrentRow == null)
				return;

			if (grdInputsFrames.CurrentRow.Cells["grcFrameID"].Value == null ||
				grdInputsFrames.CurrentRow.Cells["grcFrameID"].Value == DBNull.Value)
			{
				return;
			}

			// получение данных 
			Frame oFrameArr = new Frame();
			oFrameArr.ID = (int)grdInputsFrames.CurrentRow.Cells["grcFrameID"].Value;
			oFrameArr.FillData();
			if (oFrameArr.MainTable.Rows.Count == 0)
				return;

			DataRow r = oFrameArr.MainTable.Rows[0];
			if (!(bool)r["HasTraffics"])
			{
				oFrameArr.ClearError();
				int nFrameID = (int)oFrameArr.ID;
				oFrameArr.Arrange(nFrameID);
				if (oFrameArr.ErrorNumber == 0)
				{
					RFMMessage.MessageBoxInfo("Выполнен подбор ячейки и создана операция транспортировки для контейнера " + nFrameID.ToString().Trim() + ".");
				}
				else
				{
					RFMMessage.MessageBoxError("Подбор ячейки не выполнен...");
				}
			}
			else
			{
				RFMMessage.MessageBoxError("уже есть операции транспортировки для контейнера...");
			}

			grdInputsFrames_Restore();
		}

		#endregion


		#region Form keys

		private void frmInputs_KeyDown(object sender, KeyEventArgs e)
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


		#region Filters Choose

		#region Users

		private void btnUsersChoose_Click(object sender, EventArgs e)
		{
			_SelectedIDList = null;
			//sSelectedUsersIDList = "";

			User oUser = new User();
			oUser.FillDataTree(false);
			if (oUser.ErrorNumber != 0 || oUser.DS.Tables["TableDataTree"] == null)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных...");
				return;
			}
			if (oUser.DS.Tables["TableDataTree"].Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Нет данных...");
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

				tabData.IsNeedRestore = true;
			}
			_SelectedIDList = null;
		}

		private void btnUsersClear_Click(object sender, EventArgs e)
		{
			tabData.IsNeedRestore = true;

			ttToolTip.SetToolTip(txtUsersChoosen, "не выбраны");
			sSelectedUsersIDList = "";
			txtUsersChoosen.Text = "";
		}

		#endregion

		#region Partners

		private void btnPartnersChoose_Click(object sender, EventArgs e)
		{
			_SelectedIDList = null;
			_SelectedText = "";

			Partner oPartner = new Partner();
			oPartner.FilterExistsInInputs = true;
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

		#region InputsTypes

		private void btnInputsTypesChoose_Click(object sender, EventArgs e)
		{
			_SelectedIDList = null;
			_SelectedText = "";

			Input oInputForType = new Input();
			oInputForType.FillTableInputsTypes();
			if (oInputForType.ErrorNumber != 0 || oInputForType.TableInputsTypes == null)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных...");
				return;
			}
			if (oInputForType.TableInputsTypes.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Нет данных...");
				return;
			}

			if (StartForm(new frmSelectID(this, oInputForType.TableInputsTypes, "Name", "Тип прихода", true)) == DialogResult.Yes)
			{
				if (_SelectedIDList == null || !_SelectedIDList.Contains(","))
				{
					btnInputsTypesClear_Click(null, null);
					return;
				}

				sSelectedInputsTypesIDList = "," + _SelectedIDList;

				txtInputsTypesChoosen.Text = _SelectedText;
				ttToolTip.SetToolTip(txtInputsTypesChoosen, txtInputsTypesChoosen.Text);

				tabData.IsNeedRestore = true;
			}

			_SelectedIDList = null;
			_SelectedText = "";
		}

		private void btnInputsTypesClear_Click(object sender, EventArgs e)
		{
			tabData.IsNeedRestore = true;

			ttToolTip.SetToolTip(txtInputsTypesChoosen, "не выбраны");
			sSelectedInputsTypesIDList = "";
			txtInputsTypesChoosen.Text = "";
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

		private void optIsConfirmed_CheckedChanged(object sender, EventArgs e)
		{
			dtrDatesConfirm.Enabled =
			chkConfirmedZeroOnly.Enabled =
				optIsConfirmed.Checked;
			dtrDatesConfirm.dtpBegDate.HideControl(optIsConfirmed.Checked);
			dtrDatesConfirm.dtpEndDate.HideControl(optIsConfirmed.Checked);
			if (!optIsConfirmed.Checked) chkConfirmedZeroOnly.Checked = false;
		}

		private void optIsNotConfirmed_CheckedChanged(object sender, EventArgs e)
		{
			pnlOpgInputsStarted.Enabled = optIsNotConfirmed.Checked;
		}

		#endregion

		#region Terms clear

		private void btnClearTerms_Click(object sender, EventArgs e)
		{
			txtBarCode.Text = "";

			dtrDates.dtpBegDate.Value = DateTime.Now.AddDays(-1).Date;
			dtrDates.dtpEndDate.Value = DateTime.Now.AddDays(7).Date;

			btnInputsTypesClear_Click(null, null);
			btnGoodsStatesClear_Click(null, null);

			txtPartnerNameContext.Text = "";
			btnPartnersClear_Click(null, null);
			btnOwnersClear_Click(null, null);
			btnUsersClear_Click(null, null);
			btnPackingsClear_Click(null, null);

			//optAll.Checked = true;
			optIsNotConfirmed.Checked = true;
			optIsConfirmed_CheckedChanged(null, null);
			chkConfirmedZeroOnly.Checked = false;
			dtrDatesConfirm.dtpBegDate.Value = DateTime.Now.AddDays(-1).Date;
			dtrDatesConfirm.dtpEndDate.Value = DateTime.Now.Date;
			dtrDatesConfirm.dtpBegDate.HideControl(false);
			dtrDatesConfirm.dtpEndDate.HideControl(false);

			optStartedAll.Checked = true;

			optFramesAll.Checked = true;

			ucSelectRecordID_Hosts.ClearData();

			if (Control.ModifierKeys == Keys.Shift)
			{
				optAll.Checked = true;
				dtrDates.dtpBegDate.HideControl(false);
				dtrDates.dtpEndDate.HideControl(false);
			}

			tabData.IsNeedRestore = true;
		}

		#endregion

	}
}