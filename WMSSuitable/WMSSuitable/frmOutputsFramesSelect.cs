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
	public partial class frmOutputsFramesSelect : RFMFormChild
	{
		private Output oOutput;
		private int nOutputGoodID;
		private DataTable dt;

		int nPackingID = 0;
		bool bIsWeight = false;
		decimal nInBox = 0;
		int nBoxInPal = 0;
		decimal nQntNeed = 0;
		decimal nQntRest = 0;

		bool bIsDec = false;
		string cFormat = "### ##0";

		bool bRill = false; // среди предлагаемых контейнеров есть такие, которые расположены в ячейках-ручьях

		bool bIsLoaded = false;

		private bool bValidOK = true;

		public frmOutputsFramesSelect(Output _oOutput, int _nOutputGoodID, DataTable _dt)
		{
			oOutput = _oOutput;
			nOutputGoodID = _nOutputGoodID;

			InitializeComponent();

			dt = this.CopyTable(_dt, "dt", "", "DateValid, Address, ByOrder"); 
		}

		private void frmOutputsFramesSelect_Load(object sender, EventArgs e)
		{
			RFMCursorWait.Set(true);

			// сам расход 
			DataRow r = oOutput.MainTable.Rows[0];
			txtID.Text = r["ID"].ToString();
			txtErpCode.Text = r["ErpCode"].ToString();
			txtDateOutput.Text = r["DateOutput"].ToString().Substring(0, 10);
			txtOutputBarCode.Text = r["BarCode"].ToString();

			txtOwnerName.Text = r["OwnerName"].ToString();
			txtPartnerName.Text = r["PartnerName"].ToString();

			txtGoodStateName.Text = r["GoodStateName"].ToString();
			txtOutputTypeName.Text = r["OutputTypeName"].ToString();
			txtCellAdress.Text = r["CellAddress"].ToString();

			// товар в расходе 
			DataRow rg = null; 
			// Find
			oOutput.FillTableOutputsGoods((int)oOutput.ID);
			foreach (DataRow rOG in oOutput.TableOutputsGoods.Rows)
			{
				if ((int)rOG["ID"] == nOutputGoodID)
				{
					rg = rOG;
					break;
				}
			}
			if (rg == null)
			{
				RFMCursorWait.Set(false);
				RFMMessage.MessageBoxError("Товар в расходе не найден...");
				Close();
				return;
			}

			nPackingID = (int)rg["PackingID"]; 
			txtGoodAlias.Text = rg["GoodAlias"].ToString();
			nInBox = (decimal)rg["InBox"];
			txtInBox.Text = nInBox.ToString(cFormat);
			nBoxInPal = (int)rg["BoxInPal"];
			bIsWeight = (bool)rg["Weighting"];
			bIsDec = bIsWeight || (nInBox != (int)nInBox);
			if (bIsDec)
				cFormat += ".000";
			lblInBox.Text = (bIsWeight ? "Кг" : "Штук") + " в кор.";
 
			nQntNeed = (decimal)rg["QntWished"] - (decimal)rg["QntSelected"];
			txtQntNeed.Text = nQntNeed.ToString(cFormat);
			txtBoxQntNeed.Text = ((decimal)(nQntNeed / nInBox)).ToString("### ##0.0");
			txtPalQntNeed.Text = ((decimal)(nQntNeed / nInBox / nBoxInPal)).ToString("### ##0.00");
 
			grcQnt.DefaultCellStyle.Format = cFormat;
			grcQntForMove.DecimalPlaces = (bIsDec ? 3 : 0);

			dt.Columns.Add("IsSelected", Type.GetType("System.Boolean"));
			dt.Columns.Add("IsForMove", Type.GetType("System.Boolean"));
			dt.Columns.Add("QntForMove", Type.GetType("System.Decimal"));
			dt.Columns.Add("BoxQntForMove", Type.GetType("System.Decimal"));
			dt.Columns.Add("NewArrangeForMove", Type.GetType("System.Boolean"));
			foreach (DataRow rt in dt.Rows)
			{
				if ((decimal)rt["QntInTrafficsGoods"] != 0)
				{
					rt["Qnt"] = (decimal)rt["Qnt"] - (decimal)rt["QntInTrafficsGoods"];
					rt["BoxQnt"] = (decimal)rt["Qnt"] / nInBox;
					rt["PalQnt"] = (decimal)rt["BoxQnt"] / nBoxInPal;
				}
				rt["IsSelected"] = false;
				rt["IsForMove"] = false;
				rt["QntForMove"] = 0;
				rt["BoxQntForMove"] = 0;
				rt["NewArrangeForMove"] = false;

				if (!bRill && (bool)rt["IsRill"])
					bRill = true;	
			}

			grdFrames_Restore();
			
			grcByOrderFrameInCell.Visible = bRill; 

			bIsLoaded = true;
			RFMCursorWait.Set(false);
		}

		#region Restore

		private bool grdFrames_Restore()
		{
			grdFrames.Restore(dt);
			ShowTotal();
			return (true);
		}

		#endregion

		#region Cell...

		private void grdFrames_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (!bIsLoaded)
				return;

			RFMDataGridView grd = grdFrames;
			if (grd.DataSource == null || grd.CurrentRow == null || grd.RowCount == 0)
				return;

			string sColName = grd.Columns[e.ColumnIndex].Name;
			DataGridViewRow grdr = grd.Rows[e.RowIndex];
			if (sColName.Contains("ForMove"))
			{
				if ((decimal)grdr.Cells["grcQntForMove"].Value > 0)
					e.CellStyle.BackColor = Color.FromArgb(250, 200, 200);
			}
			if (sColName.Contains("FrameID"))
			{
				if ((decimal)grdr.Cells["grcQntInTrafficsGoods"].Value != 0)
					e.CellStyle.BackColor = Color.FromArgb(200, 250, 250);
			}
		}

		private void grdFrames_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if (!bIsLoaded || grdFrames.IsRestoring)
				return;

			RFMDataGridView grd = grdFrames;
			if (grd.DataSource == null || grd.CurrentRow == null || grd.RowCount == 0)
				return;

			string sColName = grd.Columns[e.ColumnIndex].Name;
			if (!sColName.Contains("QntForMove"))
				return;

			DataGridViewRow grdr = grd.Rows[e.RowIndex];

			// пробуем переместить
			decimal nQntTemp = 0;
			decimal nQntBoxTemp = 0;

			// есть в контейнере
			decimal nQnt = (decimal)grdr.Cells["grcQnt"].Value;

			if (sColName == "grcQntForMove")
			{
				nQntTemp = (decimal)grdr.Cells["grcQntForMove"].Value;
				nQntBoxTemp = nQntTemp / nInBox;
			}
			
			if (sColName == "grcBoxQntForMove")
			{
				nQntBoxTemp = (decimal)grdr.Cells["grcBoxQntForMove"].Value;
				nQntTemp = nQntBoxTemp * nInBox;
			}

			if (nQntTemp == 0)
			{
				grdr.Cells["grcQntForMove"].Value = 0;
				grdr.Cells["grcBoxQntForMove"].Value = 0;
				grdr.Cells["grcIsForMove"].Value = false;
				grdr.Cells["grcIsSelected"].Value = false;
				bValidOK = false;
				ShowTotal();
				return;
			}

			if (nQntTemp > nQnt)
			{
				RFMMessage.MessageBoxError("Перемещаемое количество больше количества в контейнере...");
				grdr.Cells["grcQntForMove"].Value = nQnt;
				grdr.Cells["grcBoxQntForMove"].Value = nQnt / nInBox;
				grdr.Cells["grcIsForMove"].Value = false;
				bValidOK = false;
				ShowTotal();
				return;
			}

			grdr.Cells["grcQntForMove"].Value = nQntTemp;
			grdr.Cells["grcBoxQntForMove"].Value = nQntBoxTemp;
			grdr.Cells["grcIsForMove"].Value = (nQntTemp < nQnt);
			ShowTotal();
		}

		private void grdFrames_CellValidated(object sender, DataGridViewCellEventArgs e)
		{
			if (!bIsLoaded || grdFrames.IsRestoring)
				return;

			RFMDataGridView grd = grdFrames;
			string sColName = grd.Columns[e.ColumnIndex].Name;
			DataGridViewRow grdr = grd.Rows[e.RowIndex];

			if (sColName == "grcQntForMove")
			{
				if (grdr.Cells["grcQntForMove"].Value == DBNull.Value)
				{
					grdr.Cells["grcQntForMove"].Value =
					grdr.Cells["grcBoxQntForMove"].Value =
						0;
					grdr.Cells["grcIsForMove"].Value = false;
					grdr.Cells["grcIsSelected"].Value = false;
				}
			}
			if (sColName == "grcBoxQntForMove")
			{
				if (grdr.Cells["grcBoxQntForMove"].Value == DBNull.Value)
				{
					grdr.Cells["grcQntForMove"].Value =
					grdr.Cells["grcBoxQntForMove"].Value =
						0;
					grdr.Cells["grcIsForMove"].Value = false;
					grdr.Cells["grcIsSelected"].Value = false;
				}
			}
        }

		private void grdFrames_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			if (grdFrames.IsCurrentCellDirty)
			{
				string sColName = grdFrames.CurrentCell.OwningColumn.Name;

				if (sColName == "grcIsSelected")
				{
					bool bIsSelectedBefore = (bool)grdFrames.CurrentCell.Value;

					DataRow r = ((DataRowView)grdFrames.CurrentRow.DataBoundItem).Row;

					if ((bool)r["IsRill"]) // меняем отметку у контейнера в ручье
					{
						RFMCursorWait.Set(true);

						int nCellRill = (int)r["CellID"];
						int nFrameRill = (int)r["FrameID"];
						int nByOrderRill = 0;
						if (!Convert.IsDBNull(r["ByOrder"]))
							nByOrderRill = (int)r["ByOrder"]; 
						
						if (!bIsSelectedBefore) // мы собираемся отметить контейнер в ручье
						{
							// для ручьев: разрешаем брать только min доступный номер (из неподобранных и неотмеченных)
							int nByOrderMin = 0;
							// в ячейке, где находится отмечаемый контейнер, также находятся и другие контейнеры
							Cell oCellRill = new Cell();
							oCellRill.ID = nCellRill;
							if (!oCellRill.FillTableCellsContents(nCellRill, false) ||
								oCellRill.ErrorNumber != 0 || 
								oCellRill.TableCellsContents == null)
							{
									r["IsSelected"] = false;
									grdFrames.CurrentCell.OwningRow.Cells["grcIsSelected"].Value = false;
									RFMCursorWait.Set(false);
									RFMPublic.RFMMessage.MessageBoxError("Ошибка при получении данных о контейнерах в ячейке...");
									return;
							}
							
							if (oCellRill.TableCellsContents.Rows.Count > 1)
							{
								// только если в ячейке больше одного контейнера
								
								// список контейнеров, которые уже подобраны (т.е. участвуют в перемещениях, но еще не сняты с ручья)
								string sFramesSelectedIDList = "";
								Frame oFrameTemp = new Frame();
								foreach(DataRow rCC in oCellRill.TableCellsContents.Rows)
								{
									if (!Convert.IsDBNull(rCC["FrameID"]))
									{
										oFrameTemp.ClearError();
										oFrameTemp.ID = Convert.ToInt32(rCC["FrameID"]);
										oFrameTemp.FillData();
										if (oFrameTemp.ErrorNumber == 0 && 
											oFrameTemp.MainTable != null && 
											oFrameTemp.MainTable.Rows.Count == 1)
										{
											DataRow rTemp = oFrameTemp.MainTable.Rows[0];
                                            //if (rTemp["State"].ToString() == "T" || Convert.ToBoolean(rTemp["HasNotConfirmedTraffics"]))
                                            if (rTemp["State"].ToString() == "T" || Convert.ToBoolean(rTemp["HasTraffic"]))
                                                    sFramesSelectedIDList += "," + oFrameTemp.ID.ToString().Trim(); 
										}
									}
								}

								// список контейнеров, которые уже отмечены нами в текущей форме 
								DataTable dtSelected = CopyTable(dt, "dtSelected", "IsSelected and CellID = " + nCellRill.ToString() + " and FrameID <> " + nFrameRill.ToString(), "ByOrder");
								foreach(DataRow rS in dtSelected.Rows)
									sFramesSelectedIDList += "," + rS["FrameID"].ToString().Trim(); 
	
								// сейчас из ячейки можно взять контейнер с min номером (неподобранный и неотмеченный)
								DataTable dtRill = CopyTable(oCellRill.TableCellsContents, "dtRill", "FrameID is not null" + (sFramesSelectedIDList.Length > 0 ? " and FrameID not in (" + sFramesSelectedIDList.Substring(1) + ")" : ""), "ByOrder");
								if (dtRill.Rows.Count > 0 && !Convert.IsDBNull(dtRill.Rows[0]["ByOrder"]))
									nByOrderMin = Convert.ToInt32(dtRill.Rows[0]["ByOrder"]); 
								if (nByOrderRill > nByOrderMin) 
								{
									r["IsSelected"] = false;
									grdFrames.CurrentCell.OwningRow.Cells["grcIsSelected"].Value = false;
									RFMCursorWait.Set(false);
									RFMPublic.RFMMessage.MessageBoxError("Выбранный контейнер не можен быть снят с ручья,\n" +
										"так как в ручье есть контейнер с меньшим номером по порядку!");
									grdFrames.CommitChanges();
									grdFrames.Invalidate();
									return;
								}
							}
						}
						else // мы собираемся снять отметку с контейнера в ручье
						{
							// для ручьев: нельзя снять отметку, если отмечен контейнер с большим номером в той же ячейке

							// список контейнеров, которые уже отмечены нами в текущей форме 
							DataTable dtSelected1 = CopyTable(dt, "dtSelected1", "IsSelected and CellID = " + nCellRill.ToString() + " and FrameID <> " + nFrameRill.ToString() + " and ByOrder > " + nByOrderRill.ToString().Trim(), "ByOrder");
							if (dtSelected1.Rows.Count > 0)
							{
								r["IsSelected"] = true;
								grdFrames.CurrentCell.OwningRow.Cells["grcIsSelected"].Value = true;
								RFMCursorWait.Set(false);
								RFMPublic.RFMMessage.MessageBoxError("С данного контейнера нельзя снять отметку,\n" +
									"так как в ручье есть выбранный контейнер с большим номером по порядку!");
								grdFrames.CommitChanges();
								grdFrames.Invalidate();
								return;
							}
						}
						RFMCursorWait.Set(false);
					}
					// закончены проверки для ручьев

					decimal nQntTemp = (decimal)r["Qnt"];
					r["IsSelected"] = !bIsSelectedBefore;
					if (!bIsSelectedBefore)
					{
						if (nQntRest > 0 && nQntRest < nQntTemp && !(bool)r["IsRill"])
						{
							// только неподобранный остаток, который меньше контейнера
							r["QntForMove"] = nQntRest;
							r["BoxQntForMove"] = nQntRest / nInBox;
							r["IsForMove"] = true;
						}
						else
						{
							// весь контейнер целиком
							r["QntForMove"] = nQntTemp;
							r["BoxQntForMove"] = nQntTemp / nInBox;
							r["IsForMove"] = false;
						}
					}
					else
					{
						r["QntForMove"] =
						r["BoxQntForMove"] =
							0;
						r["IsForMove"] = false;
					}
					grdFrames.CommitChanges();
					grdFrames.Invalidate();
					ShowTotal(); 
				}
			}
		}

		private void grdFrames_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			DataGridViewColumn c = grdFrames.Columns[e.ColumnIndex]; 
			/*
			if (c.Name.Contains("ForMove"))
			{
				DataRow dr = ((DataRowView)((DataGridViewRow)grdFrames.CurrentRow).DataBoundItem).Row;

				if (c.Name == "grcIsForMove")
					c.ReadOnly = !(bool)dr["IsSelected"];
				else
					c.ReadOnly = !(bool)dr["IsForMove"];
			}
			*/

			if (c.Name.Contains("QntForMove"))
			{
				DataRow r = ((DataRowView)((DataGridViewRow)grdFrames.CurrentRow).DataBoundItem).Row;
				c.ReadOnly = !(bool)r["IsSelected"] || (bool)r["IsRill"];
			}
		}

		#endregion

		#region CalcTotal

        private void ShowTotal()
        {
			decimal nQntSel = 0;
			foreach (DataRow r in dt.Rows)
            {
				if (Convert.ToDecimal(r["QntForMove"]) > 0)
				{
					nQntSel += (decimal)r["QntForMove"];
				}
			}
			txtQntSel.Text = nQntSel.ToString(cFormat); 
			txtBoxQntSel.Text = ((decimal)(nQntSel / nInBox)).ToString("### ### ##0.0");
			txtPalQntSel.Text = ((decimal)(nQntSel / nInBox / nBoxInPal)).ToString("### ### ##0.00");

			nQntRest = nQntNeed - nQntSel;
			txtQntRest.Text = nQntRest.ToString(cFormat);
			txtBoxQntRest.Text = ((decimal)(nQntRest / nInBox)).ToString("### ### ##0.0");
			txtPalQntRest.Text = ((decimal)(nQntRest / nInBox / nBoxInPal)).ToString("### ### ##0.00");

			txtQntRest.BackColor =
			txtBoxQntRest.BackColor =
			txtPalQntRest.BackColor =
				(nQntRest < 0) ? Color.FromArgb(250, 200, 200) : BackColor;
        }
				
		#endregion 

		#region Buttons
		
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
			DataGridViewCellEventArgs oDgvcea = new DataGridViewCellEventArgs(grdFrames .CurrentCell.ColumnIndex, grdFrames.CurrentRow.Index);
			if (grdFrames.IsCurrentCellDirty)
			{
				bValidOK = true;
				grdFrames.CommitChanges();
				grdFrames_CellValidated(grdFrames, oDgvcea);
				grdFrames_CellEndEdit(grdFrames, oDgvcea);
				if (!bValidOK)
				{
					grdFrames.CurrentRow.Cells[grdFrames.CurrentCell.ColumnIndex].Selected = true;
					return;
				}
			}

			Refresh();
			WaitOn(this);
			oOutput.ClearError();

			int nFrameID = 0;
			int nTrafficsFramesOK = 0;
			int nTrafficsGoodsOK = 0;
			//int nTrafficsFramesCreated = 0;
			decimal nQntOK = 0;
			string sText = "";
			
			// проверки и запрос на начало выполнения операций
			foreach (DataRow r in dt.Rows)
			{
				nFrameID = (int)r["FrameID"];
				if ((bool)r["IsSelected"])
				{
					if (!(bool)r["IsForMove"])
					{
						nTrafficsFramesOK++;
						nQntOK += (decimal)r["QntForMove"];
					}
					else
					{
						if (Convert.ToDecimal(r["QntForMove"]) > 0)
						{
							nTrafficsGoodsOK++;
							nQntOK += (decimal)r["QntForMove"];
						}
					}
				}
			}
			if (nTrafficsGoodsOK != 0 || nTrafficsFramesOK != 0)
			{
				if (nTrafficsFramesOK != 0)
					sText += "Будут созданы транспортировки контейнеров: " + nTrafficsFramesOK.ToString().Trim() + "\n";
				if (nTrafficsGoodsOK != 0)
					sText += "Будут созданы перемещения коробок/штук: " + nTrafficsGoodsOK.ToString().Trim() + "\n";
				sText += "После подтверждения в ячейку отгрузки будет перемещен товар в количестве:\n" +
					nQntOK.ToString(cFormat).Trim() + (bIsWeight ? " кг" : " шт.") + ", " +
					((decimal)(nQntOK / nInBox)).ToString("### ##0.0").Trim() + " кор., " +
					((decimal)(nQntOK / nInBox / nBoxInPal)).ToString("### ##0.00").Trim() + " пал.\n\n" + 
					"Начать создание транспортировок/перемещений?";
				WaitOff(this);
				if (RFMMessage.MessageBoxYesNo(sText) != DialogResult.Yes)
					return; 
			}

			WaitOn(this);
			// начинаем 
			nTrafficsFramesOK = 0;
			nTrafficsGoodsOK = 0;
			nQntOK = 0;
			sText = "";
			foreach (DataRow r in dt.Rows)
			{
				nFrameID = (int)r["FrameID"];
				if ((bool)r["IsSelected"])
				{
					decimal nQntForMove = 0;
					if (!Convert.IsDBNull(r["QntForMove"]))
						nQntForMove = (decimal)r["QntForMove"];

					if (!(bool)r["IsForMove"])
					{
						// контейнер целиком
						if (oOutput.OutputGoodTrafficFrameCreate(nOutputGoodID, nFrameID) &&
							oOutput.ErrorNumber == 0) 
						{
							nTrafficsFramesOK++;
							nQntOK += nQntForMove;
						}
						oOutput.ClearError(); 
					}
					else
					{
						if (nQntForMove > 0)
						{
							// частично
							if (oOutput.OutputGoodTrafficGoodFromFrameCreate(nOutputGoodID, nFrameID, nPackingID, nQntForMove) &&
								oOutput.ErrorNumber == 0)
							{
								nTrafficsGoodsOK++;
								nQntOK += nQntForMove;
								if ((bool)r["NewArrangeForMove"])
								{ 
									// нужно БУДЕТ искать новое место для уменьшившегося контейнера... после подтверждения
									// пока непонятно что делать
								}
							}
							oOutput.ClearError();
						}
					}
				}
			}
			WaitOff(this);
			if (nTrafficsGoodsOK != 0 || nTrafficsFramesOK != 0)
			{
				if (nTrafficsFramesOK != 0)
					sText += "Созданы транспортировки контейнеров: " + nTrafficsFramesOK.ToString().Trim() + "\n";
				if (nTrafficsGoodsOK != 0)
					sText += "Созданы перемещения коробок штук: " + nTrafficsGoodsOK.ToString().Trim() + "\n";
				sText += "В ячейку отгрузки будет перемещен товар в количестве:\n" +
					nQntOK.ToString(cFormat).Trim() + (bIsWeight ? " кг" : " шт.") + ", " +
					((decimal)(nQntOK / nInBox)).ToString("### ##0.0").Trim() + " кор., " + 
					((decimal)(nQntOK / nInBox / nBoxInPal)).ToString("### ##0.00").Trim() + " пал.";
				WaitOff(this);
 				RFMMessage.MessageBoxInfo(sText);
				DialogResult = DialogResult.Yes;
				Dispose();
			}
			WaitOff(this);
		}

		#endregion

	}
}
