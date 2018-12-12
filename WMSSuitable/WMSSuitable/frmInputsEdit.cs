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
	public partial class frmInputsEdit : RFMFormChild
	{
		private int ID;
		public int _ID { get { return ID; } set { ID = value; } }
		private Input oInput;
		private Partner oPartner;
		private Partner oOwner;
		private Frame oFrames;
		private Good oGoods;
		private GoodState oGoodState;
		private StoreZone oInputZone;
		private Cell oCell;
		private User oUser;

		public int? _SelectedPackingID;
		private int nEditRow = -1;
		private int? nInputItemID = null;

		private bool bDateStarted = false;
		private DateTime dDateStart = DateTime.Now;
		private bool bNewInput = false;

		int? nHostID = null;
		private int? nUserHostID = null;


		public frmInputsEdit(int? _ID)
		{
			oInput = new Input();
			oPartner = new Partner();
			oOwner = new Partner();
			oFrames = new Frame();
			oGoods = new Good();
			oGoodState = new GoodState();
			oInputZone = new StoreZone();
			oCell = new Cell();
			oUser = new User();

			if (oInput.ErrorNumber != 0 ||
				oPartner.ErrorNumber != 0 ||
				oOwner.ErrorNumber != 0 ||
				oFrames.ErrorNumber != 0 ||
				oGoods.ErrorNumber != 0 ||
				oGoodState.ErrorNumber != 0 ||
				oInputZone.ErrorNumber != 0 ||
				oUser.ErrorNumber != 0
				)
			{
				IsValid = false;
			}

			if (IsValid)
			{
				InitializeComponent();

				if (_ID.HasValue)
				{
					this.ID = (int)_ID;
				}
				else
				{
					this.ID = 0;
					bNewInput = true;
				}
			}
		}

		#region Calcs&Works

		private void Inputs_Edit_Load(object sender, EventArgs e)
		{
//			tcList.Init();
//			tabAttributes.IsNeedRestore = tabPallets.IsNeedRestore = false;

			nUserHostID = ((RFMFormMain)Application.OpenForms[0]).UserInfo.HostID;

			grcQntConfirmed_P.AgrType =
			grcBoxConfirmed_P.AgrType =
			grcPalConfirmed_P.AgrType =
				EnumAgregate.Sum;

			grcQntConfirmed.AgrType =
			grcQntWished.AgrType =
			grcBoxConfirmed.AgrType =
			grcBoxWished.AgrType =
			grcPalConfirmed.AgrType =
			grcPalWished.AgrType =
				EnumAgregate.Sum;

			pnlEditPallet.Enabled = false; 
			pnlAboutPacking.Visible = false;
			btnCalc.Visible = false;

			lblInfoGood_1.Text = lblInfoGood_2.Text = lblInfoGood_3.Text =
			lblInfoAll_1.Text = lblInfoAll_2.Text = lblInfoAll_3.Text = "";

			// заполнение cbo-классификаторов 
			oCell.FilterStoreZoneTypeForInputs = true;
			oCell.FilterActual = true;
			oCell.FilterLocked = false;
			bool lResult = cboInputsTypes_Restore()
							&& cboInputGoodState_Restore()
							&& cboInputZone_Restore()
							&& cboHeavers_Restore();
			if (lResult == false)
			{
				RFMMessage.MessageBoxError("Ошибка получения общих данных (классификаторы)...");
				this.Dispose();
			}

			// данные конкретного прихода
			if (this.ID == 0)
			{
				// новый приход, с умолчальными значениями
				// НЕ ИСП.! 
				// (nHostID не определен)
				Setting set = new Setting();
				// тип прихода 
				int nInputTypeID = Convert.ToInt32(set.FillVariable("nDefInputTypeID"));
				if (nInputTypeID == 0)
				{
					nInputTypeID = 999;
					foreach (DataRow rit in oInput.TableInputsTypes.Rows)
					{
						if ((bool)rit["Actual"])
						{
							if ((int)rit["ID"] <= nInputTypeID)
							{
								nInputTypeID = (int)rit["ID"];
							}
						}
					}
					if (nInputTypeID == 999)
						nInputTypeID = 0;
				}
				// партнер-поставщик
				int nPartnerID = Convert.ToInt32(set.FillVariable("nDefInputPartnerID"));
				if (nPartnerID == 0)
				{
					nPartnerID = 999999;
					foreach (DataRow rp in oPartner.MainTable.Rows)
					{
						if ((bool)rp["Actual"])
						{
							if ((int)rp["ID"] <= nPartnerID)
							{
								nPartnerID = (int)rp["ID"];
							}
						}
					}
					if (nPartnerID == 999999)
						nPartnerID = 0;
				}
				// партнер-владелец
				int nOwnerID = Convert.ToInt32(set.FillVariable("nDefInputOwnerID"));
				if (nOwnerID == 0)
				{
					nOwnerID = 999999;
					foreach (DataRow rp in oPartner.MainTable.Rows)
					{
						if ((bool)rp["Actual"])
						{
							if ((int)rp["ID"] <= nOwnerID)
							{
								nOwnerID = (int)rp["ID"];
							}
						}
					}
					if (nOwnerID == 999999)
						nOwnerID = 0;
				}
				// состояние товара 
				int nGoodStateID = Convert.ToInt32(set.FillVariable("nDefInputGoodStateID"));
				if (nGoodStateID == 0)
				{
					nGoodStateID = 999;
					foreach (DataRow rgs in oGoodState.MainTable.Rows)
					{
						if ((bool)rgs["Actual"] && (bool)rgs["Basic"])
						{
							if ((int)rgs["ID"] <= nGoodStateID)
							{
								nGoodStateID = (int)rgs["ID"];
							}
						}
					}
					if (nGoodStateID == 999)
						nGoodStateID = 0;
				}

				txtId.Text = "новый";
				oInput.ID = 0;
				oInput.FillData();
				if (oInput.MainTable.Rows.Count > 0)
				{
					oInput.ClearData();
				}

				DataRow rn = oInput.MainTable.Rows.Add();
				rn["DateInput"] = DateTime.Now.Date;
				rn["InputTypeID"] = nInputTypeID;
				rn["PartnerID"] = nPartnerID;
				rn["OwnerID"] = nOwnerID;
				rn["GoodStateID"] = nGoodStateID;
				rn["DateStart"] = dDateStart;
			}
			else
			{
				txtId.Text = this.ID.ToString();
				oInput.ID = (int)this.ID;
				oInput.FillData();
				if (oInput.ErrorNumber != 0 || oInput.MainTable.Rows.Count == 0)
				{
					RFMMessage.MessageBoxError("Ошибка при получении данных о приходе...");
					Dispose();
				}
				cboInputsTypes.Enabled =
				cboInputGoodState.Enabled = 
					false;
			}

			// редактирование прихода

			// присвоение начальных значений
			DataRow r = oInput.MainTable.Rows[0];
			if (!Convert.IsDBNull(r["HostID"]))
				nHostID = (int)r["HostID"];
			if (!nHostID.HasValue && nUserHostID.HasValue)
				nHostID = nUserHostID;
			if (nHostID.HasValue && nUserHostID.HasValue &&
				(int)nUserHostID != (int)nHostID)
			{
				RFMMessage.MessageBoxError("Несовпадение прав доступа к данным хоста...");
				Dispose();
				return;
			}

			if (r["DateConfirm"] == DBNull.Value)
			{
				txtDateConfirm.Text = Convert.ToString(null);
			}
			else
			{
				DateTime dDateConfirm = Convert.ToDateTime(r["DateConfirm"]);
				txtDateConfirm.Text = dDateConfirm.Date.ToShortDateString();
			}

			if (r["DateStart"] != DBNull.Value)
			{
				bDateStarted = true;
			}
			else
			{
				oInput.SetDateStart((int)oInput.ID);
			}
			
			dtpDateInput.Value = (DateTime)r["DateInput"];
			cboInputsTypes.SelectedValue = r["InputTypeID"].ToString();
			txtPartners.Text = r["PartnerName"].ToString();
			txtOwners.Text = r["OwnerName"].ToString();
			cboInputGoodState.SelectedValue = r["GoodStateID"].ToString();
			txtBarCode.Text = r["BarCode"].ToString();
			txtNote.Text = r["Note"].ToString();
			grdGoods_Restore();
			grdPallets_Restore();

			// если уже контейнеры - встать на ту же зону, 
			// если пока нет - встать на зону "Приход"
			int? nInputZone = null;
			if (oInput.TableInputsPallets.Rows.Count > 0)
			{
				nInputZone = Convert.ToInt32(oInput.TableInputsPallets.Rows[0]["StoreZoneID"]);
			}
			else
			{
				foreach (DataRow rSZ in oInputZone.MainTable.Rows)
				{
					if (rSZ["ShortCode"].ToString() == "IN")
					{
						nInputZone = Convert.ToInt32(rSZ["ID"]);
						break;
					}
				}
			}
			if (nInputZone != null)
			{
				cboInputZone.SelectedValue = nInputZone; 
			}
			oCell.FilterStoresZonesList = cboInputZone.SelectedValue.ToString();
			cboCell_Restore();

			// тек.пользователь
			cboHeavers.SelectedValue = ((RFMFormBase)Application.OpenForms[0]).UserInfo.UserID;  
		}

		private void cboGoods_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (cboGoods.OldValue == null)
				return;
			if (oInput.TableInputsGoods.PrimaryKey.Length != 0)
			{
				if (cboPalletsTypes.DataSource == null)
				{
					if (cboPalletsTypes_Restore() == false)
					{
						RFMMessage.MessageBoxError("Ошибка получения списка типов контейнеров...");
						return;
					}
				}
				if (cboGoods.SelectedIndex == -1)
					return;

				DataRow dr = null;
				for (int _i = 0; _i <= oInput.TableInputsGoods.Rows.Count; _i++)
				{
					dr = oInput.TableInputsGoods.Rows[_i];
					if ((int)cboGoods.SelectedValue == (int)dr["PackingID"])
						break;
				}
				if (dr != null && nEditRow == -1)
				{
					txtWeighting.Text = Convert.ToString(dr["Weighting"]);

					decimal nInBox = (decimal)dr["InBox"];

					numQntConfirmed.DecimalPlaces =
						((bool)dr["Weighting"] || (nInBox != (int)nInBox)) ? 3 : 0;

					numBoxInRow.Value = (int)dr["BoxInRow"];
					numInBox.Value = (decimal)dr["InBox"];
					numBoxInPal.Value = (int)dr["BoxInPal"];

					if ((bool)dr["Weighting"])
					{
						numBoxConfirmed.Value = 0;
						if ((decimal)dr["BoxWished"] < (int)dr["BoxInpal"])
							numQntConfirmed.Value = (decimal)dr["BoxWished"] * (decimal)dr["InBox"];
						else
						{
							//numQntConfirmed.Value = (decimal)dr["BoxInPal"] * (decimal)dr["InBox"];
							numQntConfirmed.Value = Convert.ToDecimal(dr["BoxInPal"]) * Convert.ToDecimal(dr["InBox"]);
						}
					}
					else
					{
						numQntConfirmed.Value = 0;
						if ((decimal)dr["BoxWished"] < (int)dr["BoxInpal"])
							numBoxConfirmed.Value = (decimal)dr["BoxWished"];
						else
							numBoxConfirmed.Value = (int)dr["BoxInPal"];
					}
				
					int _i;
					for (_i = 0; _i < oInput.TableInputsPallets.Rows.Count; _i++)
					{
						if ((int)oInput.TableInputsPallets.Rows[_i]["PackingID"] == (int)cboGoods.SelectedValue
							&& (decimal)oInput.TableInputsPallets.Rows[_i]["QntConfirmed"] > 0)
						{
							if (cboFrames.SelectedValue != null &&
								oInput.TableInputsPallets.Rows[_i]["FrameHeight"] != DBNull.Value)
							{
								numFrameHeight.Value = (decimal)oInput.TableInputsPallets.Rows[_i]["FrameHeight"];
							}
							if (oInput.TableInputsPallets.Rows[_i]["DateValid"] != DBNull.Value)
							{
								dtpDateValid.Value = (DateTime)oInput.TableInputsPallets.Rows[_i]["DateValid"];
							}
							break;
						}
					}
					if (_i == oInput.TableInputsPallets.Rows.Count)
					{
						if (numBoxInRow.Value != 0 && dr["BoxHeight"] != DBNull.Value && !(chkFrameHeightManual.Checked))
						{
							decimal nQntConfirmed = numBoxConfirmed.Value * numInBox.Value + numQntConfirmed.Value;
							numFrameHeight.Value = (decimal)dr["BoxHeight"] *
								Convert.ToDecimal(Convert.ToInt32(Convert.ToInt32(nQntConfirmed / numInBox.Value / numBoxInRow.Value))) +
								Convert.ToDecimal(0.25);
						}
						DateTime dDateValid = DateTime.Today;
						dtpDateValid.Value = dDateValid.AddDays((int)dr["Retention"]);
					}
					cboPalletsTypes.SelectedIndex = -1;
					cboPalletsTypes.SelectedValue = dr["PalletTypeID"].ToString();
				}
				if (cboGoods.SelectedIndex != -1)
				{
					pnlAboutPacking.Visible = true;
					pnlConfirmed.Visible = true;
					if ((bool)dr["Weighting"])
					{
						numBoxConfirmed.Enabled = false;
						lblQntConfirmed.Visible = false;
						lblWeightConfirmed.Visible = true;
						btnCalc.Visible = true;
						if ((decimal)dr["QntConfirmed"] > 0)
						{
							numQntConfirmed.Value = (decimal)dr["InBox"] * numBoxConfirmed.Value;
							numBoxConfirmed.Value = 0;
						}
						numQntConfirmed.Select();
					}
					else
					{
						numBoxConfirmed.Enabled = true;
						numBoxConfirmed.Select();
						lblQntConfirmed.Visible = true;
						lblWeightConfirmed.Visible = false;
						btnCalc.Visible = false;
					}
				}
			}
		}

		private void cboFrames_SelectedIndexChanged(object sender, EventArgs e)
		{
			pnlFrame.BorderStyle = BorderStyle.FixedSingle;
			if (cboGoods.DataSource == null)
			{
				cboGoods.SelectedIndex = -1;
				if (cboGoods_Restore() == false)
				{
					RFMMessage.MessageBoxError("Ошибка получения списка товаров ...");
					return;
				}
			}
			if (cboFrames.SelectedIndex != -1)
			{
				pnlGoods.Visible = true;
				if (!pnlConfirmed.Visible)
					cboGoods.SelectedIndex = -1;
				cboGoods.Select();
				dtpDateValid.HideControl(true);
				lblCreateTraffic.Visible = 
				chkCreateTraffic.Visible = 
					true;
				if (nEditRow != -1)
				{
					DataRow dr = ((DataRowView)((DataGridViewRow)grdPallets.Rows[nEditRow]).DataBoundItem).Row;
					chkCreateTraffic.Checked = (bool)dr["TrafficCreated"];
					chkCreateTraffic.Enabled = !((bool)dr["TrafficCreated"]);
				}
				else
				{
					chkCreateTraffic.Enabled = 
					chkCreateTraffic.Checked =
						true;
				}
			}
			else
			{
				lblCreateTraffic.Visible =
				chkCreateTraffic.Visible =
				chkCreateTraffic.Enabled =
				chkCreateTraffic.Checked = 
					false;
				dtpDateValid.HideControl(false);
				txtFrameCodeLast4.Text = "";
			}
		}
		
		private void tabPallets_Enter(object sender, EventArgs e)
		{
			if (cboGoodsStates.DataSource == null)
			{
				if (cboGoodsStates_Restore() == false)
				{
					RFMMessage.MessageBoxError("Ошибка получения списка состояний товаров...");
					return;
				}
			}
			if (btnAppend.Enabled)
			{
				btnDelete.Enabled =
				btnEdit.Enabled =
					(grdPallets.RowCount != 0);
			}
		}

		private void txtFrameCodeLast4_TextChanged(object sender, EventArgs e)
		{
			if (txtFrameCodeLast4.Text.Length == 4)
			{
				cboFrames.DataSource = null;
				cboFrames_Restore();
				if (oFrames.MainTable.Rows.Count == 0)
				{
					RFMMessage.MessageBoxError("Не найдено свободных контейнеров с таким кодом\n для товаров в таком состоянии...");
					cboFrames.SelectedIndex = -1;
					return;
				}
			}
		}

		private void cboInputZone_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboInputZone.OldValue != null)
			{
				oCell.ID = null;
				if (cboInputZone.SelectedIndex < 0 || cboInputZone.SelectedValue == null)
				{
					cboCell.DataSource = null;
				}
				else
				{
					oCell.FilterStoresZonesList = cboInputZone.SelectedValue.ToString();
					if (!cboCell_Restore())
					{
						cboCell.SelectedIndex = -1;
						RFMMessage.MessageBoxError("Ошибка получения ячеек выбранной зоны...");
						return;
					}
					if (oCell.MainTable.Rows.Count == 0)
					{
						cboCell.SelectedIndex = -1;
						RFMMessage.MessageBoxError("В выбранной зоне нет ячеек...");
						return;
					}
				}
			}
		}

		private void WriteInfoColums(int nPackingID)
		{
			Decimal nAllBoxConfirmed = 0;
			Decimal nAllBoxWished = 0;
			Decimal nThisBoxConfirmed = 0, nThisBoxWished = 0;
			DataRow dr;
			for( int i = 0; i < oInput.TableInputsGoods.Rows.Count; i++)
			{
				dr = oInput.TableInputsGoods.Rows[i];
				nAllBoxConfirmed += Convert.ToDecimal(dr["BoxArranged"]);
				nAllBoxWished += Convert.ToDecimal(dr["BoxWished"]);
				if (nPackingID != 0 && dr["PackingID"] != DBNull.Value && nPackingID == (int)dr["PackingID"])
				{
					nThisBoxConfirmed = Convert.ToDecimal(dr["BoxArranged"]);
					nThisBoxWished = Convert.ToDecimal(dr["BoxWished"]);
				}
			}
			lblInfoAll_1.Text = "Всего";
			lblInfoAll_2.Text = "Заказ: " + nAllBoxWished.ToString("### ### ### ###.00").Trim() + " кор.";
			lblInfoAll_3.Text = "Пришло: " + nAllBoxConfirmed.ToString("### ### ### ###.00").Trim() + " кор.";
			
			object[] KeyForFind = new object[2];
			KeyForFind[0] = nPackingID;
			KeyForFind[1] = cboGoodsStates.SelectedValue;
			dr = oInput.TableInputsGoods.Rows.Find(KeyForFind);
			if (dr != null)
			{
				lblInfoGood_1.Text = dr["GoodAlias"].ToString().TrimEnd();
                lblInfoGood_2.Text = "Заказ: " + nThisBoxWished.ToString("### ### ### ###.00").Trim() + " кор.";
                lblInfoGood_3.Text = "Пришло: " + nThisBoxConfirmed.ToString("### ### ### ###.00").Trim() + " кор.";
			}
			else
				lblInfoGood_1.Text = lblInfoGood_2.Text = lblInfoGood_3.Text = "";

			if (nThisBoxConfirmed == nThisBoxWished)
			{
				lblInfoGood_2.Font = new Font(lblInfoGood_2.Font, FontStyle.Bold);
				lblInfoGood_3.Font = new Font(lblInfoGood_3.Font, FontStyle.Bold);
			}
			else
			{
				lblInfoGood_2.Font = new Font(lblOwners.Font, frmCellsFixedEdit.DefaultFont.Style);
				lblInfoGood_3.Font = new Font(lblOwners.Font, frmCellsFixedEdit.DefaultFont.Style);
			}
		}

		private void grdGoods_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (grdGoods.DataSource == null)
				return;

			if (grdGoods.IsStatusRow(e.RowIndex))
			{
				e.CellStyle.BackColor = Color.Silver;
				e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);

				switch (grdGoods.Columns[e.ColumnIndex].Name)
				{
					case "grcResult":
						e.Value = Properties.Resources.Empty;
						break;
				}
				return;
			}

			DataGridViewRow r = grdGoods.Rows[e.RowIndex];
			switch (grdGoods.Columns[e.ColumnIndex].Name)
			{
				case "grcResult":
					if (Convert.IsDBNull(r.Cells["grcQntConfirmed"].Value) || 
						Convert.ToDecimal(r.Cells["grcQntConfirmed"].Value) == 0)
						e.Value = Properties.Resources.DotRed;
					else
					{
						if (Convert.ToDecimal(r.Cells["grcQntWished"].Value) ==
							Convert.ToDecimal(r.Cells["grcQntConfirmed"].Value))
							e.Value = Properties.Resources.DotGreen;
						else
							e.Value = Properties.Resources.DotYellow;
					}
					break;
				case "grcQntWished":
				case "grcQntConfirmed":
				case "grcBoxInPal":
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

		private void cboGoodStates_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboGoodsStates.SelectedIndex == -1)
				return;
			if ((bool)oGoodState.MainTable.Rows[cboGoodsStates.SelectedIndex]["Basic"])
			{
				chkFrameMono.Checked = true;
				chkFrameMono.Enabled = false;
			}
			else
				chkFrameMono.Enabled = true;
			chkFrameMono_CheckedChanged(sender, e);
		}

		private void chkFrameMono_CheckedChanged(object sender, EventArgs e)
		{
			txtFrameCodeLast4.Text = "";
			cboFrames.SelectedIndex = -1;
		}

		private void grdPallets_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (grdPallets.DataSource == null || e.RowIndex < 0 || grdPallets.CurrentRow == null)
				return;

			if (grdGoods.IsStatusRow(e.RowIndex))
			{
				e.CellStyle.BackColor = Color.Silver;
				e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
				string sColumnName = ((RFMDataGridView)sender).Columns[e.ColumnIndex].Name.ToUpper();
				if (sColumnName.Contains("IMAGE"))
				{
					e.Value = Properties.Resources.Empty;
				}
				return;
			}

			if ((bool)grdPallets.Rows[e.RowIndex].Cells["grcIsDisplaced"].Value == true)
				e.CellStyle.BackColor = Color.FromArgb(250, 200, 200);

			DataGridViewRow r = grdPallets.Rows[e.RowIndex];  
			switch (grdPallets.Columns[e.ColumnIndex].Name)
			{
				case "grcTrafficCreateImage":
					if (!(bool)r.Cells["grcTrafficCreateImage"].Value) 
						e.Value = Properties.Resources.Empty;
					else
					{
						if(!(bool)r.Cells["grcIsDisplaced"].Value)
							e.Value = Properties.Resources.CheckRed;
						else
							e.Value = Properties.Resources.CheckGreen;	 	
					}
					break;							
				case "grcIsFrameImage":
					if (!Convert.IsDBNull(r.Cells["grcIsFrameImage"].Value) &&
						Convert.ToBoolean(r.Cells["grcIsFrameImage"].Value))
						e.Value = Properties.Resources.Frame;
					else
						e.Value = Properties.Resources.Boxes;
					break;
				case "grcQntConfirmed_P":
				case "grcInBox_P":
					if (!Convert.IsDBNull(r.Cells["grcGoodWeighting"].Value) &&
						Convert.ToBoolean(r.Cells["grcGoodWeighting"].Value) ||
						!Convert.IsDBNull(e.Value) && Convert.ToDecimal(e.Value) != Convert.ToInt32(e.Value))
						e.CellStyle.Format = "### ### ### ###.000";
					else
						e.CellStyle.Format = "### ### ### ###";
					break;
			}
		}

		private void numQntConfirmed_Validated(object sender, EventArgs e)
		{
			if (!(chkFrameHeightManual.Checked) && cboFrames.SelectedValue != null &&
				numInBox.Value != 0 && numBoxInRow.Value != 0)
			{
				object[] KeyForFind = new object[2];
				KeyForFind[0] = cboGoods.SelectedValue;
				KeyForFind[1] = cboGoodsStates.SelectedValue;
				decimal nBoxConfirmed = numBoxConfirmed.Value + decimal.Ceiling(numQntConfirmed.Value / numInBox.Value);
				DataRow dr = oInput.TableInputsGoods.Rows.Find(KeyForFind);
				if (dr != null && dr["BoxHeight"] != DBNull.Value)
				{
					decimal nQntConfirmed = numBoxConfirmed.Value * numInBox.Value + numQntConfirmed.Value;
					numFrameHeight.Value = (decimal)dr["BoxHeight"] *
					Convert.ToDecimal(Convert.ToInt32(Convert.ToInt32(nQntConfirmed / numInBox.Value / numBoxInRow.Value))) +
					Convert.ToDecimal(0.25);
				}
			}
		}

		private void chkFrameHeightManual_CheckedChanged(object sender, EventArgs e)
		{
			if (chkFrameHeightManual.Checked)
			{
				numFrameHeight.Enabled = true;
				//				numFrameHeight.Value = 0;
			}
			else
				numFrameHeight.Enabled = false;
		}

		private void cboCell_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboCell.SelectedIndex < 0)
				return;

			DataRow droRow = oCell.MainTable.Rows.Find((int)cboCell.SelectedValue);
			if (droRow["ForFrames"] != DBNull.Value && (bool)droRow["ForFrames"] == false)
			{
				txtFrameCodeLast4.Enabled = false;
				chkFrameHeightManual.Enabled = false;
				cboPalletsTypes.Enabled = false;
			}
			else
			{
				txtFrameCodeLast4.Enabled = true;
				chkFrameHeightManual.Enabled = true;
				cboPalletsTypes.Enabled = true;
			}
		}

		private void numBoxConfirmed_Validated(object sender, EventArgs e)
		{
			if (!(chkFrameHeightManual.Checked) && cboFrames.SelectedValue != null &&
				numInBox.Value != 0 && numBoxInRow.Value != 0)
			{
				object[] KeyForFind = new object[2];
				KeyForFind[0] = cboGoods.SelectedValue;
				KeyForFind[1] = cboGoodsStates.SelectedValue;
				decimal nBoxConfirmed = numBoxConfirmed.Value + decimal.Ceiling(numQntConfirmed.Value / numInBox.Value);
				DataRow dr = oInput.TableInputsGoods.Rows.Find(KeyForFind);
				if (dr != null && dr["BoxHeight"] != DBNull.Value)
				{
					decimal nQntConfirmed = numBoxConfirmed.Value * numInBox.Value + numQntConfirmed.Value;
					numFrameHeight.Value = (decimal)dr["BoxHeight"] *
						Convert.ToDecimal(Convert.ToInt32(Convert.ToInt32(nQntConfirmed / numInBox.Value / numBoxInRow.Value))) +
						Convert.ToDecimal(0.25);
				}
			}
		}

		#endregion

		#region Restore

		private bool cboInputsTypes_Restore()
		{
			oInput.FillTableInputsTypes();
			cboInputsTypes.ValueMember = oInput.TableInputsTypes.Columns[0].Caption;
			cboInputsTypes.DisplayMember = oInput.TableInputsTypes.Columns[1].Caption;
			cboInputsTypes.DataSource = oInput.TableInputsTypes;
			return (oInput.ErrorNumber == 0);
		}
		private bool cboInputGoodState_Restore()
		{
			oGoodState.FillData();
			cboInputGoodState.ValueMember = oGoodState.ColumnID;
			cboInputGoodState.DisplayMember = oGoodState.ColumnName;
			cboInputGoodState.DataSource = new DataView(oGoodState.MainTable);
			return (oGoodState.ErrorNumber == 0);
		}
		private bool cboCell_Restore()
		{
			cboCell.DataSource = null;
			oCell.FillData();
			cboCell.ValueMember = oCell.ColumnID;
			cboCell.DisplayMember = oCell.MainTable.Columns[("Address")].ToString();
			cboCell.DataSource = oCell.MainTable;
			oCell.MainTable.PrimaryKey = new DataColumn[] { oCell.MainTable.Columns["ID"] };
			return (oCell.ErrorNumber == 0);
		}
		private bool cboInputZone_Restore()
		{
			oInputZone.FilterStoreZoneTypeForInputs = true;
			oInputZone.FillData();
			cboInputZone.ValueMember = oInputZone.ColumnID;
			cboInputZone.DisplayMember = oInputZone.ColumnName;
			cboInputZone.DataSource = oInputZone.MainTable;
			return (oInputZone.ErrorNumber == 0);
		}
		private bool grdGoods_Restore()
		{
			// товары
			oInput.FillTableInputsGoodsItems(this.ID, false);
			grdGoods.AutoGenerateColumns = false;
			oInput.TableInputsGoods.PrimaryKey = new DataColumn[] { oInput.TableInputsGoods.Columns["PackingID"],
						oInput.TableInputsGoods.Columns["GoodStateID"]};
			oInput.TableInputsGoods.Columns["ID"].AutoIncrement = true;
			grdGoods.Restore(oInput.TableInputsGoods);
			return (oInput.ErrorNumber == 0);
		}
		private bool grdPallets_Restore()
		{
			// паллеты
			oInput.FillTableInputsPallets(this.ID);
			grdPallets.AutoGenerateColumns = false;
			grdPallets.Restore(oInput.TableInputsPallets);
			grdPallets.GridSource.Filter = "QntConfirmed > 0";
			return (oInput.ErrorNumber == 0);
		}
		private bool cboPalletsTypes_Restore()
		{
			oGoods.FillTablePalletsTypes();
			cboPalletsTypes.DataSource = oGoods.TablePalletsTypes;
			cboPalletsTypes.ValueMember = oGoods.TablePalletsTypes.Columns["ID"].ToString();
			cboPalletsTypes.DisplayMember = oGoods.TablePalletsTypes.Columns["Name"].ToString();
			return (oGoods.ErrorNumber == 0);
		}
		private bool cboGoods_Restore()
		{
			if (oInput.TableInputsGoodsTotal == null)
				oInput.FillTableInputsGoods(this.ID, true);
			cboGoods.ValueMember = "PackingID";
			cboGoods.DisplayMember = "GoodAlias";
			cboGoods.DataSource = oInput.TableInputsGoodsTotal;
			return (oInput.ErrorNumber == 0);
		}
		private bool cboGoodsStates_Restore()
		{
			if (oGoodState.MainTable.Rows.Count == 0)
				oGoodState.FillData();
			cboGoodsStates.ValueMember = oGoodState.ColumnID;
			cboGoodsStates.DisplayMember = oGoodState.ColumnName;
			cboGoodsStates.DataSource = new DataView(oGoodState.MainTable);
			return (oGoodState.ErrorNumber == 0);
		}
		private bool cboFrames_Restore()
		{
			oFrames.FilterFramesStatesStr = " ,I,";
			oFrames.FilterActual = true;
			if (txtFrameCodeLast4.Text.Trim().Length  == 4)
				oFrames.BarCode = txtFrameCodeLast4.Text.Trim();
			oFrames.FillData();

			oFrames.MainTable.PrimaryKey = new DataColumn[] { oFrames.MainTable.Columns["ID"] };
			cboFrames.ValueMember = oFrames.ColumnID;
			cboFrames.DisplayMember = oFrames.ColumnName;
			cboFrames.DataSource = oFrames.MainTable;


			if (nEditRow != -1 || !chkFrameMono.Checked)
			{
				Frame oFrameTemp = new Frame();
				TrafficFrame oTrafficFrameTemp = new TrafficFrame();
				oTrafficFrameTemp.FilterInputsList = ID.ToString();
				oTrafficFrameTemp.FillData();
				string sFrameIDList = "";
				foreach (DataRow r in oTrafficFrameTemp.MainTable.Rows)
					sFrameIDList = sFrameIDList + r["FrameID"].ToString() + ",";
					
				if (sFrameIDList.Length > 0)
				{
					oFrameTemp.IDList = sFrameIDList;
					oFrameTemp.FilterFramesStatesStr = "T";
					oFrameTemp.FillData();
					DataRow drTemp;
					if (oFrameTemp.MainTable.Rows.Count > 0)
					{
						foreach (DataRow drf in oFrameTemp.MainTable.Rows)
						{

							drTemp = oFrames.MainTable.Rows.Find(drf["ID"]);
							if (drTemp == null)
								oFrames.MainTable.ImportRow(drf);
						}
					}
				}
			}
			else
			{
				if (cboFrames.Enabled)
				{
					for (int i = 0; i < oInput.TableInputsPallets.Rows.Count; i++)
					{
						if (!Convert.IsDBNull(oInput.TableInputsPallets.Rows[i]["FrameID"]))
						{
							int nFrameID = (int)oInput.TableInputsPallets.Rows[i]["FrameID"];
							for (int j = 0; j < oFrames.MainTable.Rows.Count; j++)
							{
								if (oFrames.MainTable.Rows[j].RowState != DataRowState.Deleted &&
									(int)oFrames.MainTable.Rows[j]["FrameID"] == nFrameID)
								{
									oFrames.MainTable.Rows[j].Delete();
								}
							}
						}
					}
					oFrames.MainTable.AcceptChanges();
				}
			}

			if (oFrames.MainTable.Rows.Count < 2)
				cboFrames.Enabled = false;
			else
			{
				cboFrames.Enabled = true;
				cboFrames.SelectedValue = oFrames.MainTable.Rows[oFrames.MainTable.Rows.Count - 1]["FrameID"];
			}
			return (oFrames.ErrorNumber == 0);
		}

		private bool cboHeavers_Restore()
		{
			oUser.FillData();
			cboHeavers.ValueMember = oUser.ColumnID;
			cboHeavers.DisplayMember = oUser.MainTable.Columns[("Name")].ToString();
			cboHeavers.DataSource = oUser.MainTable;
			return (oUser.ErrorNumber == 0);
		}

		#endregion

		#region Design
		private void cboFrames_Leave(object sender, EventArgs e)
		{
			pnlFrame.BorderStyle = BorderStyle.FixedSingle;
		}
		private void cboGoods_Leave(object sender, EventArgs e)
		{
			pnlGoods.BorderStyle = BorderStyle.FixedSingle;
		}
		private void cboGoods_Enter(object sender, EventArgs e)
		{
			pnlGoods.BorderStyle = BorderStyle.Fixed3D;
		}
		private void pnlFrame_Enter(object sender, EventArgs e)
		{
			DataRow dr = oCell.MainTable.Rows.Find((int)cboCell.SelectedValue);
			if (dr["ForFrames"] == DBNull.Value || !(bool)dr["ForFrames"])
			{
				if (cboGoods.DataSource == null)
				{
					cboGoods.SelectedIndex = -1;
					if (cboGoods_Restore() == false)
					{
						RFMMessage.MessageBoxError("Ошибка получения списка товаров ...");
						return;
					}
				}
				pnlGoods.Visible = true;
				if (!pnlConfirmed.Visible)
					cboGoods.SelectedIndex = -1;
				if (dr["ForFrames"] != DBNull.Value && !(bool)dr["ForFrames"])
				{
					pnlFrame.Enabled = false;
					cboGoods.Select();
				}
				else
					pnlFrame.Enabled = true;
			}

			pnlFrame.BorderStyle = BorderStyle.Fixed3D;
			pnlGoodState.BorderStyle = BorderStyle.FixedSingle;
		}
		private void pnlFrame_Leave(object sender, EventArgs e)
		{
			pnlFrame.BorderStyle = BorderStyle.FixedSingle;
		}
		private void numBoxConfirmed_Enter(object sender, EventArgs e)
		{
			pnlConfirmed.BorderStyle = BorderStyle.Fixed3D;

		}
		private void pnlBoxConfirmed_Leave(object sender, EventArgs e)
		{
			pnlConfirmed.BorderStyle = BorderStyle.FixedSingle;
		}
		private void pnlBoxConfirmed_Enter(object sender, EventArgs e)
		{
			pnlConfirmed.BorderStyle = BorderStyle.Fixed3D;
		}
		private void pnlGoods_Leave(object sender, EventArgs e)
		{
			pnlGoods.BorderStyle = BorderStyle.FixedSingle;
		}
		private void pnlGoods_Enter(object sender, EventArgs e)
		{
			pnlGoods.BorderStyle = BorderStyle.Fixed3D;
		}
		private void pnlAboutPacking_Leave(object sender, EventArgs e)
		{
			pnlAboutPacking.BorderStyle = BorderStyle.FixedSingle;
		}
		private void pnlAboutPacking_Enter(object sender, EventArgs e)
		{
			pnlAboutPacking.BorderStyle = BorderStyle.Fixed3D;
		}
		private void pnlGoodState_Enter(object sender, EventArgs e)
		{
			pnlGoodState.BorderStyle = BorderStyle.Fixed3D;
		}
		private void pnlGoodState_Leave(object sender, EventArgs e)
		{
			pnlGoodState.BorderStyle = BorderStyle.FixedSingle;
		}
		#endregion

		#region Buttons

		private void btnHelp_Click(object sender, EventArgs e)
		{
			RFMHelpUtilities.HelpShow(this, hpHelp);
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			if (RFMMessage.MessageBoxYesNo("Прервать работу с формой?") == DialogResult.No)
				return;

			if (!bDateStarted)
				oInput.ClearDateStart((int)oInput.ID);
			if (bNewInput && oInput.ID.HasValue && (int)oInput.ID > 0)
				oInput.DeleteData((int)oInput.ID);

			DialogResult = DialogResult.No;
			this.Dispose();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			bool lResult;

			oInput.ClearError();

			if (cboCell.SelectedValue == null)
			{
				RFMMessage.MessageBoxError("Не указана ячейка приемки...");
				tcList.SelectedTab = tabAttributes;
				cboCell.Select();
				return;
			}

			if (cboHeavers.SelectedValue == null)
			{
				RFMMessage.MessageBoxError("Не указан оператор погрузочной техники...");
				tcList.SelectedTab = tabAttributes;
				cboHeavers.Select();
				return;
			}

			if (cboInputGoodState.SelectedValue == null)
			{
				RFMMessage.MessageBoxError("Не указано состояние товара...");
				tcList.SelectedTab = tabAttributes;
				cboInputGoodState.Select();
				return;
			}

			if (cboInputsTypes.SelectedValue == null)
			{
				RFMMessage.MessageBoxError("Не указан тип прихода...");
				tcList.SelectedTab = tabAttributes;
				cboInputsTypes.Select();
				return;
			}

			oInput.MainTable.Rows[0]["ID"] = oInput.ID; //  txtID.Text;
			oInput.MainTable.Rows[0]["DateInput"] = dtpDateInput.Value.Date;
			oInput.MainTable.Rows[0]["GoodStateID"] = cboInputGoodState.SelectedValue;
			oInput.MainTable.Rows[0]["InputTypeID"] = cboInputsTypes.SelectedValue;
			oInput.MainTable.Rows[0]["BarCode"] = txtBarCode.Text;
			oInput.MainTable.Rows[0]["Note"] =  txtNote.Text.Trim();

			int? nUserID = (int)cboHeavers.SelectedValue;

			WaitOn(this);
			if (oInput.SaveData((int)oInput.ID))
			{
				WaitOff(this);
				if (bNewInput)
				{
					oInput.SetDateStart((int)oInput.ID, dDateStart);
				}
				if (RFMMessage.MessageBoxYesNo("Приход сохранен.\r\nЗавершить работу с формой?") == DialogResult.Yes)
				{
					MotherForm.GotParam = new object[] { (int)oInput.ID };
					DialogResult = DialogResult.Yes;
					this.Dispose();
				}
				else
				{
					bDateStarted = true;
					lResult = grdPallets_Restore();
					if (lResult == false)
					{
						RFMMessage.MessageBoxError("Ошибка получения данных...");
						this.Dispose();
					}
				}
			}
			else
			{
				WaitOff(this);
			}
		}

		private void btnAppend_Click(object sender, EventArgs e)
		{
			if (cboCell.SelectedIndex < 0 || cboCell.SelectedValue == null)
			{
				RFMMessage.MessageBoxError("Не выбрана ячейка приемки...");
				tcList.SelectedTab = tabAttributes;
				cboCell.Select();
				return;
			}
			btnEsc.Visible = true;
			btnOK.Visible = true;
			pnlEditPallet.Enabled = true;
			pnlGoodState.Visible = true;
			pnlFrame.Visible = true;
			txtFrameCodeLast4.Select();
			btnSave.Enabled = 
			btnEdit.Enabled = 
			btnAppend.Enabled = 
			btnDelete.Enabled =
			tabAttributes.Enabled = 
				false ;
			cboGoodsStates.SelectedValue = cboInputGoodState.SelectedValue;
			nEditRow = -1;
			nInputItemID = null;
			dtpDateValid.HideControl(true);
//			cboGoods.Font = new Font(cboGoods.Font.Name, cboGoods.Font.Size, FontStyle.Bold);
		}

		private void btnEsc_Click(object sender, EventArgs e)
		{
			chkFrameHeightManual.Checked = false;
			pnlEditPallet.Enabled = false;
			pnlFrame.Visible = false;
			pnlGoods.Visible = false;
			pnlAboutPacking.Visible = false;
			pnlConfirmed.Visible = false;
			pnlGoodState.Visible = false;
			btnEsc.Visible = false;
			btnOK.Visible = false;
			cboFrames.SelectedIndex = -1;
			txtFrameCodeLast4.Text = "";
			txtWeighting.Text = Convert.ToString(false);
			cboGoods.Enabled = 
			cboFrames.Enabled = 
			txtFrameCodeLast4.Enabled = 
			btnNewGood.Enabled = 
				true;
			btnSave.Enabled = 
			btnEdit.Enabled = 
			btnAppend.Enabled = 
			btnDelete.Enabled =
			tabAttributes.Enabled = 
				true;
			btnCalc.Visible = false;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (cboGoodsStates.SelectedValue == null)
			{
				RFMMessage.MessageBoxError("Укажите состояние товара!");
				cboGoodsStates.Select();
				return;
			}			
			if (cboGoods.SelectedValue == null)
			{
				RFMMessage.MessageBoxError("Укажите товар!");
				cboGoods.Select();
				return;
			}
			if (cboFrames.SelectedValue == null)
			{
				DataRow droRow = oCell.MainTable.Rows.Find((int)cboCell.SelectedValue);
				if (droRow["ForFrames"] != DBNull.Value && (bool)droRow["ForFrames"] == true)
				{
					RFMMessage.MessageBoxError("Укажите контейнер!");
					cboFrames.Select();
					return;
				}
			}
			else
			{
				if (chkFrameMono.Checked)
				{
					for (int _i = 0; _i < oInput.TableInputsPallets.Rows.Count; _i++)
					{
						DataRow droRow = oInput.TableInputsPallets.Rows[_i];
						if (droRow["FrameID"] == DBNull.Value)
							continue;
						if ((decimal)droRow["QntConfirmed"] > 0 
							 && (int)droRow["FrameID"] == (int)cboFrames.SelectedValue)
						{
							if ((int)droRow["PackingID"] != (int)cboGoods.SelectedValue)
							{
								RFMMessage.MessageBoxError("Контейнер уже использован в текущем приходе для другого товара...");
								txtFrameCodeLast4.Select();
								return;
							}
							else
							{
								if (_i != nEditRow)
								{
									RFMMessage.MessageBoxError("Контейнер уже использован в текущем приходе для такого же товара...");
									txtFrameCodeLast4.Select();
									return;
								}
							}
						}
					}
				}
			}
			if ((numQntConfirmed.Value == 0) && (numBoxConfirmed.Value == 0))
			{
				RFMMessage.MessageBoxError("Укажите количество товара!");
				numBoxConfirmed.Select();
				return;
			}
			decimal nPreviousQnt;
			DataRow dr;
			if (nEditRow == -1)
			{
				dr = oInput.TableInputsPallets.NewRow();
				nPreviousQnt = 0;
			}
			else
			{
				dr = oInput.TableInputsPallets.Rows[nEditRow];
				nPreviousQnt = (decimal)dr["QntConfirmed"];
			}

			decimal nQntConfirmed = numQntConfirmed.Value + numBoxConfirmed.Value * numInBox.Value;
			
			if (chkCreateTraffic.Enabled && chkCreateTraffic.Checked)
					WaitOn(this);
			DateTime? dDateValid;
			if (cboFrames.SelectedIndex == -1)
				dDateValid = null;
			else
				dDateValid = dtpDateValid.Value.Date;
			oInput.InputsItemsSave(nInputItemID, this.ID, (int)cboGoods.SelectedValue, (int)cboGoodsStates.SelectedValue, 
				nQntConfirmed, dDateValid, (int)cboCell.SelectedValue, (int?)cboFrames.SelectedValue,
				numFrameHeight.Value, (int)cboPalletsTypes.SelectedValue, (int)oInput.MainTable.Rows[0]["OwnerID"],
				(int?)cboHeavers.SelectedValue, null, (chkCreateTraffic.Enabled && chkCreateTraffic.Checked));
			
			WaitOff(this);
			
			if (oInput.ErrorNumber != 0)
			{
				if (oInput.ErrorNumber > -100)
				{
					oInput.ClearError();
					return;
				}
			}
			oInput.ClearError();
			grdPallets_Restore();
			grdGoods_Restore();
			
			nEditRow = -1;
			cboGoods_SelectionChangeCommitted(null, null);
			btnEsc_Click(sender, e);
			WriteInfoColums((int)cboGoods.SelectedValue);
			btnDelete.Enabled = true;
			btnEdit.Enabled = true;
			numQntConfirmed.Value = 0;
			numBoxConfirmed.Value = 0;

			btnSave.Enabled = 
			btnEdit.Enabled = 
			btnAppend.Enabled =
			tabAttributes.Enabled = 
				true;
			btnCalc.Visible = false;
			cboGoods.Enabled = 
			cboFrames.Enabled = 
			txtFrameCodeLast4.Enabled = 
			btnNewGood.Enabled = 
				true;
		}

		private void btnNewGood_Click(object sender, EventArgs e)
		{
			_SelectedPackingID = null;
			if (StartForm(new frmSelectOnePacking(this, false, nHostID)) == DialogResult.Yes)
			{
				if (_SelectedPackingID != null)
				{
					object[] KeyForFind = new object[2];
					KeyForFind[0] = _SelectedPackingID;
					KeyForFind[1] = cboGoodsStates.SelectedValue;
					DataRow dr = oInput.TableInputsGoods.Rows.Find(KeyForFind);
					if (dr == null)
					{
						oInput.AddTableInputsGoods((int)_SelectedPackingID, (int)cboGoodsStates.SelectedValue);
						cboGoods.SelectedValue = _SelectedPackingID.ToString();
					}
					else
					{
						cboGoods.SelectedValue = _SelectedPackingID.ToString();
					}
					if (cboFrames.SelectedValue == null)
						cboGoods.Select();
					cboGoods_SelectionChangeCommitted(null, null);
				}
			}
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (RFMMessage.MessageBoxYesNo("Удалить текущую запись?") == DialogResult.Yes)
			{
				//int nFrameID;
				//if (grdPallets.CurrentRow.Cells["grcFrameID"].Value != DBNull.Value)
				//{
				//   nFrameID = (int)grdPallets.CurrentRow.Cells["grcFrameID"].Value;

				//   // можно ли удалить?
				//   Frame oFrameTemp = new Frame();
				//   oFrameTemp.ID = nFrameID;
				//   oFrameTemp.FillData();
				//   if (oFrameTemp.ErrorNumber != 0 || oFrameTemp.MainTable.Rows.Count == 0)
				//   {
				//      RFMMessage.MessageBoxError("Ошибка получения данных о контейнере...");
				//      return;
				//   }
				//   if (oFrameTemp.MainTable.Rows[0]["CellID"] != DBNull.Value &&
				//      grdPallets.CurrentRow.Cells["grcCellID"].Value != null &&
				//      grdPallets.CurrentRow.Cells["grcCellID"].Value != DBNull.Value &&
				//      Convert.ToInt32(oFrameTemp.MainTable.Rows[0]["CellID"]) != (int)grdPallets.CurrentRow.Cells["grcCellID"].Value)
				//   {
				//      RFMMessage.MessageBoxError("Контейнер уже перемещен...\nУдаление невозможно.");
				//      return;
				//   }

				//   TrafficFrame oTrafficFrameTemp = new TrafficFrame();
				//   oTrafficFrameTemp.FilterFramesList = nFrameID.ToString();
				//   oTrafficFrameTemp.FilterInputsList = this.ID.ToString();
				//   oTrafficFrameTemp.FillData();
				//   for (int _i = 0; _i < oTrafficFrameTemp.MainTable.Rows.Count; _i++)
				//   {
				//      if (oTrafficFrameTemp.MainTable.Rows[_i]["DateConfirm"] != DBNull.Value ||
				//         oTrafficFrameTemp.MainTable.Rows[_i]["DateAccept"] != DBNull.Value)
				//      {
				//         RFMMessage.MessageBoxError("Контейнер уже перемещен...\nУдаление невозможно.");
				//         return;
				//      }
				//   }
				//  ПРОВЕРКИ ПЕРЕНЕСЕНЫ В ХР. ПРОЦЕДУРУ!
				
				DataRowView drv = (DataRowView)grdPallets.CurrentRow.DataBoundItem;
				nInputItemID = (int)drv["InputItemID"];
				if (oInput.DeleteItem(nInputItemID))
				{
					grdPallets_Restore();
					grdGoods_Restore();
					if (grdPallets.RowCount == 0)
						WriteInfoColums(0);
					else
						WriteInfoColums(int.Parse(oInput.TableInputsPallets.Rows[0]["PackingID"].ToString()));
					btnDelete.Enabled =
					btnEdit.Enabled =
						(grdPallets.RowCount != 0);
					cboFrames.SelectedIndex = -1;
				}
				oInput.ClearError();
			}
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			DataRow dr = null;
			nEditRow = -1;
			int nCellID = (int)grdPallets.CurrentRow.Cells["grcCellID"].Value;
			string cCellAdress = (string)grdPallets.CurrentRow.Cells["grcCellAddress"].Value;
			if (nCellID != (int)cboCell.SelectedValue)
			{
				if ( !txtFrameCodeLast4.Enabled && 
						grdPallets.CurrentRow.Cells["grcFrameID"].Value != DBNull.Value )
				{
					RFMMessage.MessageBoxError("Текущая ячейка прихода не предназначена для контейнеров...\r\n" +
						"Редактирование невозможно.");
					return;
				}
				
				if (RFMMessage.MessageBoxYesNo("Внимание!\r\n\r\n" +
						"Для товара была указана ячейка прихода: " + cCellAdress.Trim() + ".\r\n" +
						"Будет сохранена текущая ячейка прихода: " + cboCell.Text.Trim() + "\r\n\r\n" +
						"Продолжить?") == DialogResult.No)
					return;
				else
					pnlFrame_Enter(null,null);
			}
			//if (grdPallets.CurrentRow.Cells["grcFrameID"].Value != DBNull.Value)
			//{
			//   int nFrameID = (int)grdPallets.CurrentRow.Cells["grcFrameID"].Value;
			//   Frame oFrameTemp = new Frame();
			//   oFrameTemp.ID = nFrameID;
			//   oFrameTemp.FillData();
			//   if (oFrameTemp.ErrorNumber != 0 || oFrameTemp.MainTable.Rows.Count == 0)
			//   {
			//      RFMMessage.MessageBoxError("Ошибка получения данных о контейнере...");
			//      return;
			//   }
			//   if (oFrameTemp.MainTable.Rows[0]["CellID"] != DBNull.Value &&
			//      grdPallets.CurrentRow.Cells["grcCellID"].Value != null &&
			//      grdPallets.CurrentRow.Cells["grcCellID"].Value != DBNull.Value &&
			//      Convert.ToInt32(oFrameTemp.MainTable.Rows[0]["CellID"]) != (int)grdPallets.CurrentRow.Cells["grcCellID"].Value)
			//   {
			//      RFMMessage.MessageBoxError("Контейнер уже перемещен...\nРедактирование невозможно.");
			//      return;
			//   }
			//   TrafficFrame oTrafficFrameTemp = new TrafficFrame();
			//   oTrafficFrameTemp.FilterFramesList = nFrameID.ToString();
			//   oTrafficFrameTemp.FilterInputsList = this.ID.ToString();
			//   oTrafficFrameTemp.FillData();
			//   for (int _i = 0; _i < oTrafficFrameTemp.MainTable.Rows.Count; _i++)
			//   {
			//      if (oTrafficFrameTemp.MainTable.Rows[_i]["DateConfirm"] != DBNull.Value ||
			//         oTrafficFrameTemp.MainTable.Rows[_i]["DateAccept"] != DBNull.Value)
			//      {
			//         RFMMessage.MessageBoxError("Контейнер уже перемещен...\nРедактирование невозможно.");
			//         return;
			//      }
			//   }
			//   int nGoodStateID = (int)grdPallets.CurrentRow.Cells["grcGoodStateID"].Value;
			//   int nPackingIDID = (int)grdPallets.CurrentRow.Cells["grcPackingID"].Value;
			//}
			//  ПРОВЕРКИ ПЕРЕНЕСЕНЫ В ХР. ПРОЦЕДУРУ !

			nEditRow = grdPallets.CurrentRow.Index;
			dr = ((DataRowView)((DataGridViewRow)grdPallets.Rows[nEditRow]).DataBoundItem).Row;
			nInputItemID = (int)dr["InputItemID"];
			if (nEditRow != -1)
			{
				if ((dr["DateValid"] != DBNull.Value))
				{
					dtpDateValid.Value = (DateTime)dr["DateValid"];
					dtpDateValid.HideControl(true);
				}
				else
				{
					dtpDateValid.HideControl(false);
				}
				numInBox.Value = (decimal)dr["InBox"];
				numBoxInPal.Value = Convert.ToDecimal(dr["BoxInPal"]);
				cboGoodsStates.Text = dr["GoodStateName"].ToString();
				numBoxInRow.Value = Convert.ToDecimal(dr["BoxInRow"]);
				txtWeighting.Text = dr["Weighting"].ToString();
				cboGoodsStates.SelectedValue = dr["GoodStateID"].ToString();
				if (dr["FrameID"] != DBNull.Value)
				{
					string cFrame = dr["FrameID"].ToString().Trim().PadLeft(4, '0');
					txtFrameCodeLast4.Text = (cFrame.Substring(cFrame.Length - 4, 4));
					//					txtFrameCodeLast4_TextChanged(null, null);
					cboFrames.SelectedValue = (int)dr["FrameID"];
					numFrameHeight.Value = (decimal)dr["FrameHeight"];
					lblCreateTraffic.Visible = chkCreateTraffic.Visible = true;
					chkCreateTraffic.Checked = (bool)dr["TrafficCreated"];
					chkCreateTraffic.Enabled = !((bool)dr["TrafficCreated"]);
				}
				else
				{
					lblCreateTraffic.Visible = 
					chkCreateTraffic.Visible = 
					chkCreateTraffic.Enabled = 
					chkCreateTraffic.Checked = 
						false;
				}
				cboGoods.SelectedValue = dr["PackingID"].ToString();
				cboPalletsTypes.SelectedValue = dr["PalletTypeID"].ToString();
				if (Convert.ToBoolean(txtWeighting.Text))
				{
					numQntConfirmed.DecimalPlaces = 3;
					numQntConfirmed.Value = (decimal)dr["QntConfirmed"];
					numBoxConfirmed.Value = 0;
				}
				else
				{
					numQntConfirmed.DecimalPlaces = 0;
					numQntConfirmed.Value = (decimal)dr["QntConfirmed"] - 
						decimal.Floor((decimal)dr["BoxConfirmed"]) * (decimal)dr["InBox"];
					numBoxConfirmed.Value = decimal.Floor((decimal)dr["BoxConfirmed"]);
				}
				if (cboFrames.SelectedValue == null)
				{
					if (cboGoods.DataSource == null)
						cboGoods_Restore();
					cboGoods.SelectedIndex = -1;
					cboGoods.SelectedValue = dr["PackingID"].ToString();
					pnlGoods.Visible = true;
					cboGoods.Select();
				}
				cboGoods_SelectionChangeCommitted(null, null);
				if (dr["FrameID"] != DBNull.Value)
					cboGoods.Enabled = 
					btnNewGood.Enabled = 
						false;
				else
					cboGoods.Enabled =
					btnNewGood.Enabled =
						true;

				cboFrames.Enabled =
				txtFrameCodeLast4.Enabled =
					false;

				if (numQntConfirmed.Value > 0)
					numQntConfirmed.Select();
				else
					numBoxConfirmed.Select();

				btnSave.Enabled = 
				btnEdit.Enabled = 
				btnDelete.Enabled = 
				btnAppend.Enabled = 
				tabAttributes.Enabled = 
					false;

				btnEsc.Visible = 
				btnOK.Visible = 
					true;
				pnlEditPallet.Enabled = true;
				pnlAboutPacking.BorderStyle = BorderStyle.FixedSingle;
				pnlGoodState.Visible = true;
				pnlFrame.Visible = true;
			}
		}

		#endregion

		#region Form keys

		private void frmInputsEdit_KeyDown(object sender, KeyEventArgs e)
		{
			if (tcList.SelectedTab.Name == "tabPallets" && btnAppend.Enabled &&
				e.KeyCode == Keys.N && e.Modifiers == Keys.Control)
			{
				btnAppend_Click(null, null);
				return;
			}

			if (tcList.SelectedTab.Name == "tabPallets" && btnOK.Enabled &&
				e.KeyCode == Keys.W && e.Modifiers == Keys.Control)
			{
				btnOK_Click(null, null);
				return;
			}

			if (tcList.SelectedTab.Name == "tabPallets" && btnNewGood.Enabled &&
				e.KeyCode == Keys.Add) // Plus на цифровой клавиатуре
			{
				btnNewGood_Click(null, null);
				return;
			}

			if (tcList.SelectedTab.Name == "tabPallets" && btnCalc.Visible &&
				e.KeyCode == Keys.U && e.Modifiers == Keys.Control)
			{
				btnCalc_Click(null, null);
				return;
			}

			if (tcList.SelectedTab.Name == "tabPallets" && btnSave.Enabled &&
				e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
			{
				btnSave_Click(null, null);
				return;
			}
		}

		#endregion

		#region empty Restore

		private bool tabAttributes_Restore()
		{
			return (true);
		}

		private bool tabPallets_Restore()
		{
			return (true);
		}

		#endregion empty Restore

		private void btnCalc_Click(object sender, EventArgs e)
		{
			// весовой - подставляем ранее сохраненный список значений 
			if (StartProgram.ParamStore != null)
			{
				for (int i = 0; i < StartProgram.ParamStore.GetLength(0); i++)
				{
					StartProgram.ParamStore.SetValue(null, i);
				}
			}
			//string sValuesList = txtValuesList.Text.Trim();
			string sValuesList = "";
			if (new frmCounter(false, 3, "Весовой товар (кг)", sValuesList).ShowDialog() == DialogResult.Yes)
			{
				if (StartProgram.ParamStore.GetValue(1) == null)
				{
					StartProgram.ParamStore.SetValue(0, 1);
				}

				// само значение
				decimal nQnt = 0;
				bool bResult = decimal.TryParse(StartProgram.ParamStore.GetValue(1).ToString(), out nQnt);
				if (bResult) // && nQnt > 0
					numQntConfirmed.Value = nQnt;

				if (StartProgram.ParamStore.GetValue(0) == null)
				{
					StartProgram.ParamStore.SetValue("", 0);
				}

				//список введенных значений
				sValuesList = StartProgram.ParamStore.GetValue(0).ToString();
				//if (sValuesList.Substring(0, 1) == ",")
				//	txtValuesList.Text = sValuesList.Substring(1);
				//else
				//	txtValuesList.Text = sValuesList;
			}
			numQntConfirmed.Select();		
			if (StartProgram.ParamStore != null)
			{
				for (int i = 0; i < StartProgram.ParamStore.GetLength(0); i++)
				{
					StartProgram.ParamStore.SetValue(null, i);
				}
			}
		}

		private void pnlConfirmed_VisibleChanged(object sender, EventArgs e)
		{
			if (cboFrames.SelectedIndex == -1)
				lblCreateTraffic.Visible = chkCreateTraffic.Checked = chkCreateTraffic.Enabled = chkCreateTraffic.Visible = false;
			else
			{
				if (nEditRow == -1)
					lblCreateTraffic.Visible = chkCreateTraffic.Checked = chkCreateTraffic.Enabled = chkCreateTraffic.Visible = true;
			}		
		}
	}
}