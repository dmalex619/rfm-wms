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
	public partial class frmCellsMedicationFrames : RFMFormChild
	{
		protected Cell oCell = new Cell();
		protected Partner oFixedOwner = new Partner();
		protected GoodState oFixedGoodState = new GoodState();
		protected Good oFixedPacking = new Good();

		protected Frame oFrame = new Frame();
		protected Good oGood = new Good();
		protected Partner oOwner = new Partner();
		protected GoodState oGoodState = new GoodState();

		protected string _sAddress = "";
		protected decimal _nMaxPalletQnt = 0;
		protected int? _nFixedOwnerID = null;
		protected int? _nFixedGoodStateID = null;
		protected int? _nFixedPackingID = null;

		protected Frame oFrameAdd = new Frame(); // при добавлении

		protected string _cMode = "";

		protected bool _bLoaded = false; 

		public frmCellsMedicationFrames(int nCellID)
		{
			InitializeComponent();

			oCell.ID = nCellID;
		}
		
		private void frmCellsMedicationFrames_Load(object sender, EventArgs e)
		{
			bool lResult = true; 

			grcBoxQnt.AgrType = 
			grcPalQnt.AgrType = 
			grcQnt.AgrType = 
				EnumAgregate.Sum;

			// параметры ячейки
			oCell.FillData();
			if (oCell.ErrorNumber != 0 || oCell.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о ячейке...");
				Dispose();
			}

			DataRow r = oCell.MainTable.Rows[0];
			if (r == null)
			{
				RFMMessage.MessageBoxError("Не определена ячейка...");
				lResult = false;
			}

			if (lResult)
			{
				// работаем только с контейнерными ячейками
				if (r["ForFrames"] != DBNull.Value && !(bool)r["ForFrames"])
				{
					RFMMessage.MessageBoxError("Ячейка не предназначена для контейнеров...");
					lResult = false;
				}
			}

			if (lResult)
			{
				_sAddress = r["Address"].ToString();
				lblCellID.Text = _sAddress + " (код " + r["ID"].ToString() + ")";

				if (r["FixedOwnerID"] != DBNull.Value && r["FixedOwnerID"] != null)
				{
					_nFixedOwnerID = (int)r["FixedOwnerID"];
					cboFixedOwner_Restore((int)_nFixedOwnerID);
					if (cboFixedOwner.Text != null)
						RFMMessage.MessageBoxInfo("Внимание!\n\nЯчейка закреплена за хранителем:\n" + cboFixedOwner.Text);
				}
				if (r["FixedGoodStateID"] != DBNull.Value && r["FixedGoodStateID"] != null)
				{
					_nFixedGoodStateID = (int)r["FixedGoodStateID"];
					cboFixedGoodState_Restore((int)_nFixedGoodStateID);
					if (cboFixedGoodState.Text != null)
						RFMMessage.MessageBoxInfo("Внимание!\n\nЯчейка закреплена за состоянием:\n" + cboFixedGoodState.Text);
				}
				if (r["FixedPackingID"] != DBNull.Value && r["FixedPackingID"] != null)
				{
					_nFixedPackingID = (int)r["FixedPackingID"];
					cboFixedPacking_Restore((int)_nFixedPackingID);
					if (cboFixedPacking.Text != null)
						RFMMessage.MessageBoxInfo("Внимание!\n\nЯчейка закреплена за товаром:\n" + cboFixedPacking.Text);
				}

				string sMaxPalletQnt = "";
				if (r["MaxPalletQnt"] != DBNull.Value)
				{
					_nMaxPalletQnt = (decimal)r["MaxPalletQnt"];
				}
				else
				{
					if (r["StoreZoneMaxPalletQnt"] != DBNull.Value)
					{
						_nMaxPalletQnt = (decimal)r["StoreZoneMaxPalletQnt"];
					}
					else
					{
						_nMaxPalletQnt = 999999;
						sMaxPalletQnt = "не огр.";
					}
				}
				if (sMaxPalletQnt.Length == 0)
				{
					sMaxPalletQnt = (_nMaxPalletQnt - System.Math.Round(_nMaxPalletQnt, 0) != 0) ? _nMaxPalletQnt.ToString() : ((int)System.Math.Round(_nMaxPalletQnt, 0)).ToString();
				}
				lblMaxPalletQnt.Text = lblMaxPalletQnt.Text + " " + sMaxPalletQnt;

				// содержимое ячейки 
				oCell.FillTableCellsContents(oCell.ID, false);
				if (oCell.ErrorNumber != 0)
					lResult = false;
			}

			if (lResult)
			{
				// если в ячейке оказались и контейнеры и товары - оставим только контейнеры
				bool bDiff = false;
				foreach (DataRow rd in oCell.TableCellsContents.Rows)
				{
					if (Convert.IsDBNull(rd["FrameID"]))
					{
						bDiff = true;
						break;
					}
				}
				if (bDiff)
				{
					DataView dv = new DataView(oCell.TableCellsContents);
					dv.RowFilter = "FrameID is not Null";
					DataTable dt = dv.ToTable();
					oCell.TableCellsContents.Clear();
					foreach (DataRow rrd in dt.Rows)
					{
						oCell.TableCellsContents.ImportRow(rrd);
					}
				}
			}

			if (lResult)
			{
				oCell.TableCellsContents.Columns.Add("FrameNew", Type.GetType("System.Boolean"));
				oCell.TableCellsContents.Columns.Add("Changes", Type.GetType("System.String"));
				foreach (DataRow rd in oCell.TableCellsContents.Rows)
				{
					rd["FrameNew"] = false;
					rd["Changes"] = "";
				}

				grdCellsContents_Restore();
			}

			if (lResult)
			{
				lResult = cboFrame_Restore();
				if (lResult)
					//  заполнение cbo-классификаторов 
					lResult = cboGood_Restore() &&
							  cboOwner_Restore() &&
							  cboGoodState_Restore();
				if (!lResult)
				{
					RFMMessage.MessageBoxError("Ошибка при заполнении классификаторов (контейнеры, товары)...");
				}
			}

			if (lResult)
			{
				cboFrame.SelectedValue = -1;
				cboGood.SelectedValue = -1;
				cboOwner.SelectedValue = -1;
				cboGoodState.SelectedValue = -1;
				numQnt.Value = 0;
			}

			// если что-то не получилось - выход
			if (!lResult)
			{
				Dispose();
			}

			pnlDataChange.Enabled = false;
			btnAdd.Enabled = true;
			btnDelete.Enabled = false;
			btnGridSave.Enabled = false;
			btnGridUndo.Enabled = false;

			//grdCellsContents.Select();

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
			int nCellID = (int)oCell.ID;

			// всякие проверки
			if (oCell.TableCellsContents.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("В ячейке нет ни одного контейнера.\nНечего сохранять...");
				return;
			}
			int nCntNoChanges = 0;
			int nCntAdd = 0;
			int nCntDel = 0;
			foreach (DataRow r in oCell.TableCellsContents.Rows)
			{
				if (r["Changes"].ToString() == "D")
				{
					nCntDel++;
				}
				if (r["Changes"].ToString() == "A")
				{
					nCntAdd++;
				}
				if (r["Changes"].ToString().Length == 0)
				{
					nCntNoChanges++;
				}
			}
			if (nCntAdd == 0 && nCntDel == 0)
			{
				RFMMessage.MessageBoxError("В ячейке нет изменений.\nНечего сохранять...");
				return;
			}

			string sText = "Ячейка " + _sAddress + "\n";
			if (nCntNoChanges > 0)
			{
				sText = sText + "\nВ ячейке находятся контейнеры: " + nCntNoChanges.ToString();
			}
			if (nCntDel > 0)
			{
				sText = sText + "\nИз ячейки удаляются контейнеры: " + nCntDel.ToString();
			}
			if (nCntAdd > 0)
			{
				sText = sText + "\nВ ячейку добавляются контейнеры: " + nCntAdd.ToString();
			}
			sText = sText + "\n\nСохранить?";
			if (RFMMessage.MessageBoxYesNo(sText) == DialogResult.Yes)
			{
				int? nUserID = ((RFMFormMain)Application.OpenForms[0]).UserID;
				int? nDeviceID = null;
				string sNoteManual = txtNoteManual.Text.Trim();
				// собственно сохранение
				oCell.MedicationFrames(nCellID, oCell.TableCellsContents, nUserID, nDeviceID, sNoteManual);
				//
				if (oCell.ErrorNumber == 0)
				{
					DialogResult = DialogResult.Yes;
					Dispose();
				}
			}
		}

	#region Restore

		private bool cboFrame_Restore()
		{
			oFrame.FilterHasFrameContent = true; 
			oFrame.FillData();
			cboFrame.ValueMember   = oFrame.MainTable.Columns["ID"].Caption;
			cboFrame.DisplayMember = oFrame.MainTable.Columns["BarCode"].Caption;
			cboFrame.DataSource    = oFrame.MainTable;
			return (oFrame.ErrorNumber == 0);
		}

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

		private bool cboFixedOwner_Restore(int nFixedOwnerID)
		{
			oFixedOwner.ID = nFixedOwnerID;
			oFixedOwner.FillData();
			cboFixedOwner.DataSource = oFixedOwner.MainTable;
			cboFixedOwner.ValueMember = oFixedOwner.ColumnID;
			cboFixedOwner.DisplayMember = oFixedOwner.ColumnName;
			return (oFixedOwner.ErrorNumber == 0);
		}

		private bool cboFixedGoodState_Restore(int nFixedGoodState)
		{
			oFixedGoodState.ID = nFixedGoodState;
			oFixedGoodState.FillData();
			cboFixedGoodState.DataSource = oFixedGoodState.MainTable;
			cboFixedGoodState.ValueMember = oFixedGoodState.ColumnID;
			cboFixedGoodState.DisplayMember = oFixedGoodState.ColumnName;
			return (oFixedGoodState.ErrorNumber == 0);
		}

		private bool cboFixedPacking_Restore(int nFixedPacking)
		{
			oFixedPacking.ID = nFixedPacking;
			oFixedPacking.FillData();
			cboFixedPacking.DataSource = oFixedPacking.MainTable;
			cboFixedPacking.ValueMember = oFixedPacking.ColumnID;
			cboFixedPacking.DisplayMember = oFixedPacking.ColumnName;
			return (oFixedPacking.ErrorNumber == 0);
		}

		private void grdCellsContents_Restore()
		{
			grdCellsContents.Restore(oCell.TableCellsContents);
		}


	#endregion

	#region RowEnter, CellFormatting

		private void grdCellsContents_RowEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (grdCellsContents.IsStatusRow(e.RowIndex))
			{
				txtFrameID.Text = ""; 
				cboFrame.SelectedValue = -1;
				cboGood.SelectedValue = -1;
				numQnt.Value = 0;
				cboOwner.SelectedValue = -1;
				cboGoodState.SelectedValue = -1;
				return;
			}

			DataGridViewRow r = grdCellsContents.Rows[e.RowIndex];
			txtFrameID.Text = "";
			if (r.Cells["grcFrameID"].Value != null && r.Cells["grcFrameID"].Value != DBNull.Value)
				cboFrame.SelectedValue = (int)r.Cells["grcFrameID"].Value;
			else
				cboFrame.SelectedValue = -1;
			if (r.Cells["grcPackingID"].Value != null && r.Cells["grcPackingID"].Value != DBNull.Value)
				cboGood.SelectedValue = (int)r.Cells["grcPackingID"].Value;
			else
				cboGood.SelectedValue = -1;
			if (r.Cells["grcQnt"].Value != null && r.Cells["grcQnt"].Value != DBNull.Value)
				numQnt.Value = (decimal)r.Cells["grcQnt"].Value;
			else
				numQnt.Value = 0;
			if (r.Cells["grcWeighting"].Value != null && r.Cells["grcWeighting"].Value != DBNull.Value &&
					(bool)r.Cells["grcWeighting"].Value)
				numQnt.DecimalPlaces = 3;
			else
				numQnt.DecimalPlaces = 0;
			if (r.Cells["grcOwnerID"].Value != null && r.Cells["grcOwnerID"].Value != DBNull.Value)
				cboOwner.SelectedValue = (int)r.Cells["grcOwnerID"].Value;
			else
				cboOwner.SelectedValue = -1;
			if (r.Cells["grcGoodStateID"].Value != null && r.Cells["grcGoodStateID"].Value != DBNull.Value)
				cboGoodState.SelectedValue = (int)r.Cells["grcGoodStateID"].Value;
			else
				cboGoodState.SelectedValue = -1;

			btnDelete.Enabled = true;
		}
				
		private void grdCellsContents_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			RFMDataGridView grd = grdCellsContents;
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
			string sChanges = (string)r.Cells["grcChanges"].Value;
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

			// цвет строки
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
			// добавление целого контейнера
			// в ячейке есть место для еще одного контейнера?
			int nFramesQnt = 0;
			foreach (DataRow dr in oCell.TableCellsContents.Rows)
			{
				if (dr["Changes"].ToString() != "D")
				{
					nFramesQnt++;
				}
			}
			if (nFramesQnt + 1 > _nMaxPalletQnt)
			{
				RFMMessage.MessageBoxError("В ячейке уже находится " + RFMPublic.RFMUtilities.Declen(nFramesQnt, "контейнер", "контейнера", "контейнеров") + ".\n" + 
					"В ячейке невозможно разместить еще один контейнер!");
				return;
			}

			btnSave.Enabled = false;
			btnAdd.Enabled = false;
			btnDelete.Enabled = false;
			btnGridSave.Enabled = true;
			btnGridUndo.Enabled = true;

			pnlDataChange.BorderStyle = BorderStyle.Fixed3D;
			pnlDataChange.Enabled = true;

			txtFrameID.Enabled = true;
			cboFrame.Enabled = true;
			cboGood.Enabled = false;
			numQnt.Enabled = false;
			cboGoodState.Enabled = false;
			cboOwner.Enabled = false;

			txtFrameID.Text = "";
			cboFrame.SelectedValue = -1;
			cboGood.SelectedValue = -1;
			numQnt.Value = 0;
			cboOwner.SelectedValue = -1;
			cboGoodState.SelectedValue = -1;
			grdCellsContents.Enabled = false;

			_cMode = "A";
		}

		private void btnGridSave_Click(object sender, EventArgs e)
		{
			if (cboFrame.SelectedValue == null || cboFrame.SelectedIndex < 0)
				return;
			int nFrameID = (int)cboFrame.SelectedValue;

			// нет ли этого контейнера уже в ячейке?
			foreach (DataRow r in oCell.TableCellsContents.Rows)
			{
				if ((int)r["FrameID"] == nFrameID)
				{
					if (r["Changes"].ToString() == "")
					{
						RFMMessage.MessageBoxError("Контейнер уже находится в ячейке...");
						return;
					}
					if (r["Changes"].ToString() == "A")
					{
						RFMMessage.MessageBoxError("Контейнер уже добавлен в ячейку...");
						return;
					}
				}
			}

			DataRow rFrame = oFrameAdd.MainTable.Rows[0];
			if (!(bool)rFrame["HasFrameContent"])
			{
				if (RFMMessage.MessageBoxYesNo("Выбран пустой контейнер!\nВсе-таки добавить его в ячейку?") != DialogResult.Yes)
				{
					return;
				}
			}
			else
			{
				string sAddress = rFrame["CellAddress"].ToString();
				if (sAddress.Length > 0)
				{
					if (RFMMessage.MessageBoxYesNo("Выбран контейнер, который сейчас находится в ячейке " + sAddress + ".\nПеренести его в текущую ячейку?") != DialogResult.Yes)
					{
						return;
					}
				}
			}
			
			// закрепление
			// за хранителем?
			if (_nFixedOwnerID != null && cboOwner.SelectedValue != null && cboOwner.SelectedIndex >= 0 &&
					_nFixedOwnerID != (int)cboOwner.SelectedValue)
			{
				if (RFMMessage.MessageBoxYesNo("Внимание!\n\nЯчейка закреплена за другим хранителем!\n\nВсе-таки сохранить?") != DialogResult.Yes)
					return;
			}
			if (_nFixedGoodStateID != null && cboGoodState.SelectedValue != null && cboGoodState.SelectedIndex >= 0 &&
					_nFixedGoodStateID != (int)cboGoodState.SelectedValue)
			{
				if (RFMMessage.MessageBoxYesNo("Внимание!\n\nЯчейка закреплена за другим хранителем!\n\nВсе-таки сохранить?") != DialogResult.Yes)
					return;
			}
			// закрепление за товаром?
			if (_nFixedPackingID != null && cboGood.SelectedValue != null && cboGood.SelectedIndex >= 0 &&
					_nFixedPackingID != (int)cboGood.SelectedValue)
			{
				if (RFMMessage.MessageBoxYesNo("Внимание!\n\nЯчейка закреплена за другим товаром!\n\nВсе-таки сохранить?") != DialogResult.Yes)
					return;
			}
			// проверили все, что смогли. Можем сохранять. 

			// сохранить в DataTable
			int nPacking = 0;
			decimal nInBox = 0;
			int nBoxInPal = 0;

			switch (_cMode)
			{
				case "A":
					// выбран существующий контейнер
					if (oFrameAdd.TableFramesContents.Rows.Count > 0)
					{
						// контейнер с товаром?
						foreach (DataRow rc in oFrameAdd.TableFramesContents.Rows)
						{
							DataRow rCAdd = oCell.TableCellsContents.Rows.Add();

							rCAdd["ID"] = DBNull.Value;
							rCAdd["FrameID"] = nFrameID;
							rCAdd["FrameNew"] = false;

							rCAdd["GoodStateID"] = rc["GoodStateID"];
							rCAdd["GoodStateName"] = rc["GoodStateName"];
							rCAdd["OwnerID"] = rc["OwnerID"];
							rCAdd["OwnerName"] = rc["OwnerName"];

							nPacking = (int)rc["PackingID"];
							rCAdd["PackingID"] = nPacking;
							rCAdd["GoodAlias"] = rc["GoodAlias"];
							rCAdd["Qnt"] = rc["Qnt"];
							rCAdd["Weighting"] = rc["Weighting"];
							rCAdd["DateValid"] = rc["DateValid"];

							DataRow rCGood = oGood.MainTable.Rows.Find(nPacking);
							if (rCGood != null)
							{
								rCAdd["Weighting"] = rCGood["Weighting"];
								nInBox = (decimal)rCGood["InBox"];
								rCAdd["InBox"] = nInBox;
								nBoxInPal = (int)rCGood["BoxInPal"];
								if (nInBox != 0)
								{
									rCAdd["BoxQnt"] = (decimal)rCAdd["Qnt"] / nInBox;
									if (nBoxInPal != 0)
									{
										rCAdd["PalQnt"] = (decimal)rCAdd["Qnt"] / nInBox / nBoxInPal;
									}
								}
							}
							rCAdd["Changes"] = "A";
						}
					}
					else 
					{ 
						// контейнер без товаров
						DataRow rFAdd = oCell.TableCellsContents.Rows.Add();

						rFAdd["ID"] = DBNull.Value;
						rFAdd["FrameID"] = nFrameID;
						rFAdd["FrameNew"] = false;

						rFAdd["GoodStateID"] = rFrame["GoodStateID"];
						rFAdd["GoodStateName"] = rFrame["GoodStateName"];
						rFAdd["OwnerID"] = rFrame["OwnerID"];
						rFAdd["OwnerName"] = rFrame["OwnerName"];

						rFAdd["PackingID"] = DBNull.Value;
						rFAdd["GoodAlias"] = "";
						rFAdd["Weighting"] = false;
						rFAdd["Qnt"] = 0;
						rFAdd["DateValid"] = DBNull.Value;
						rFAdd["BoxQnt"] = 0;
						rFAdd["PalQnt"] = 0;

						rFAdd["Changes"] = "A";
					}

					break;
			
				case "E":
					break;
			}

			btnGridUndo_Click(null, null);
		}

		private void btnGridUndo_Click(object sender, EventArgs e)
		{
			if (grdCellsContents.CurrentRow == null)
				return;

			DataGridViewCellEventArgs ee = new DataGridViewCellEventArgs(0, grdCellsContents.CurrentRow.Index);
			grdCellsContents_RowEnter(grdCellsContents, ee);
			pnlDataChange.BorderStyle = BorderStyle.FixedSingle;
			pnlDataChange.Enabled = false;
			grdCellsContents.Enabled = true;
			grdCellsContents.Refresh();

			btnSave.Enabled = true;
			btnGridSave.Enabled = false;
			btnGridUndo.Enabled = false;
			btnAdd.Enabled = true;
			if (grdCellsContents.CurrentRow != null)
				grdCellsContents_RowEnter(grdCellsContents, new DataGridViewCellEventArgs(0, grdCellsContents.CurrentRow.Index)); 
			
			_cMode = "";
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (grdCellsContents.CurrentRow == null)
				return;

			//DataRow rd = oCell.TableCellsContents.Rows[grdCellsContents.GridSource.Position];
			DataRow rd = ((DataRowView)grdCellsContents.GridSource.Current).Row;
			int nFrameID = (int)rd["FrameID"];
			// в нем один товар?
			int nI = 0;
			foreach (DataRow r in oCell.TableCellsContents.Rows)
			{
				if (!Convert.IsDBNull(r["FrameID"]) && (int)r["FrameID"] == nFrameID)
				{
					nI++;
				}
			}
			if (nI > 1)
			{
				// несколько товаров в контейнере
				if (RFMMessage.MessageBoxYesNo("В контейнере находятся разные товары.\nУдалить все товары в контейнере?") == DialogResult.Yes)
				{
					foreach (DataRow r in oCell.TableCellsContents.Rows)
					{
						if ((int)r["FrameID"] == nFrameID)
						{
							r["Changes"] = "D";
						}
					}
				}
			}
			else
			{
				// один товар в контейнере
				if (RFMMessage.MessageBoxYesNo("Удалить контейнер?") == DialogResult.Yes)
				{
					rd["Changes"] = "D";
				}
			}
		}

	#endregion

	#region выбор контейнера cboFrame

		private void cboFrame_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboFrame.Enabled && cboFrame.SelectedIndex >= 0 && cboFrame.SelectedValue != null)
			{
				int nFrameID = (int)cboFrame.SelectedValue;

				oFrameAdd.ID = nFrameID;
				oFrameAdd.FillData();
				DataRow r = oFrameAdd.MainTable.Rows[0];
				if (r["OwnerID"] != DBNull.Value)
				{
					cboOwner.SelectedValue = (int)r["OwnerID"];
				}
				else
				{
					cboOwner.SelectedValue = -1;
				}
				if (r["GoodStateID"] != DBNull.Value)
				{
					cboGoodState.SelectedValue = (int)r["GoodStateID"];
				}
				else
				{
					cboGoodState.SelectedValue = -1;
				}

				oFrameAdd.FillTableFramesContents(nFrameID);
				if (oFrameAdd.TableFramesContents.Rows.Count == 1)
				{
					// контейнер содержит один товар
					DataRow rc = oFrameAdd.TableFramesContents.Rows[0];
					cboGood.SelectedValue = (int)rc["PackingID"];
					numQnt.Value = (decimal)rc["Qnt"];
					numQnt.DecimalPlaces = ((bool)rc["Weighting"]) ? 3 : 0;
				}
				else
				{
					// контейнер содержит несколько товаров 
					cboGood.SelectedIndex = -1;
					numQnt.Value = 0;
					numQnt.DecimalPlaces = 0;
				}
			}
		}

		private void txtFrameID_TextChanged(object sender, EventArgs e)
		{
			int nCodeLen = txtFrameID.Text.Length;
			if (nCodeLen >= 4)
			{
				DataView oFrameView = new DataView(oFrame.MainTable);
				oFrameView.RowFilter = "substring(BarCode, len(BarCode) - " + ((int)(nCodeLen - 1)).ToString() + ", " + nCodeLen.ToString() + ") = '" + txtFrameID.Text.Trim() + "'";
				if (oFrameView.Count != 0)
				{
					cboFrame.DataSource = oFrameView;
				}
				else
				{
					RFMMessage.MessageBoxError("Нет контейнеров с таким кодом...");
				}
			}
		}

	#endregion 

	}
}