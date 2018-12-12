using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

using WMSBizObjects;
using WMSBaseClasses;
using WMSPublic;

namespace WMSSuitable
{
	public partial class frmCellsMedication : WMSFormChild
	{
		private Cell oCell = new Cell();
		private Frame oFrame = new Frame();
		private Good oGood = new Good();
		private Partner oOwner = new Partner();
		private GoodState oGoodState = new GoodState();
		protected bool _bForFrames = false;
		protected decimal _nMaxPalletQnt = 0;
		protected int? _nFixedOwnerID = null;
		protected int? _nFixedGoodStateID = null;
		protected string _cMode = "";

		Frame oFrameAdd = new Frame(); // при добавлении

		public int? _SelectedPackingID;

		protected bool _bLoaded = false; 

		public frmCellsMedication(int nCellID)
		{
			InitializeComponent();

			oCell.ID = nCellID;
		}
		
		private void frmCellsMedication_Load(object sender, EventArgs e)
		{
			oCell.FillData();
			DataRow r = oCell.MainTable.Rows[0];
			_bForFrames = (bool)r["ForFrames"];
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
				}
			}
			if (r["FixedOwnerID"] != DBNull.Value)
			{
				_nFixedOwnerID = (int)r["FixedOwnerID"];
			}
			if (r["FixedGoodStateID"] != DBNull.Value)
			{
				_nFixedGoodStateID = (int)r["FixedGoodStateID"];
			}

			oCell.FillTableCellsContents(oCell.ID, false);
			oCell.TableCellsContents.Columns.Add("FrameNew", Type.GetType("System.Boolean"));
			oCell.TableCellsContents.Columns.Add("Changes", Type.GetType("System.String"));
			foreach (DataRow rd in oCell.TableCellsContents.Rows)
				rd["Changes"] = "";

			bsCellsContents.DataSource = new DataView(oCell.TableCellsContents);
			grdCellsContents.DataSource = bsCellsContents; ;
			bsCellsContents.Position = 0;

			bool lResult = true; 
			if (_bForFrames)
			{
				optFrame.Checked = true;
				lResult = cboFrame_Restore();
			}
			else
			{
				optNotFrame.Checked = true;
			}
			if (lResult) 
			{
				//  заполнение cbo-классификаторов 
				lResult = cboGood_Restore() &&
						  cboOwner_Restore() && 
						  cboGoodState_Restore() ;
			}
			if (!lResult)
			{
				WMSMessage.MessageBoxError("Ошибка при заполнении классификаторов (контейнеры, товары)...");
				return;
			}
			cboFrame.SelectedValue = -1;
			cboGood.SelectedValue = -1;
			cboOwner.SelectedValue = -1;
			cboGoodState.SelectedValue = -1;

			pnlDataChange.Enabled = false;
			btnAdd.Enabled = true;
			btnEdit.Enabled = false;
			btnDelete.Enabled = false;
			btnGridSave.Enabled = false;
			btnGridUndo.Enabled = false;

			_bLoaded = true;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.No;
			this.Dispose();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (true) 
			{
				// всякие проверки
				// ля-ля

				//oCell.ContentsChange(oCell.ID);
			}
			if (oCell.ErrorNumber == 0)
			{
				DialogResult = DialogResult.Yes;
				Dispose();
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

		private void btnPackings_Click(object sender, EventArgs e)
		{
			_SelectedPackingID = null;
			if (StartForm(new frmSelectOnePacking(this, false)) == DialogResult.Yes)
			{
				if (_SelectedPackingID != null)
				{
					cboGood.SelectedValue = (int)_SelectedPackingID;
				}
				_SelectedPackingID = null;
			}
		}

	#endregion

	#region RowEnter, CellFormatting

		private void grdCellsContents_RowEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (grdCellsContents.IsStatusRow(e.RowIndex))
			{
				cboFrame.SelectedValue = -1;
				cboGood.SelectedValue = -1;
				numQnt.Value = 0;
				cboOwner.SelectedValue = -1;
				cboGoodState.SelectedValue = -1;
				return;
			}

			DataGridViewRow r = grdCellsContents.Rows[e.RowIndex];

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
			numQnt.DecimalPlaces = ((bool)r.Cells["grcWeighting"].Value) ? 3 : 0;
			if (r.Cells["grcOwnerID"].Value != null && r.Cells["grcOwnerID"].Value != DBNull.Value)
				cboOwner.SelectedValue = (int)r.Cells["grcOwnerID"].Value;
			else
				cboOwner.SelectedValue = -1;
			if (r.Cells["grcGoodStateID"].Value != null && r.Cells["grcGoodStateID"].Value != DBNull.Value)
				cboGoodState.SelectedValue = (int)r.Cells["grcGoodStateID"].Value;
			else
				cboGoodState.SelectedValue = -1;

			btnEdit.Enabled = true;
			btnDelete.Enabled = true;
		}
				
		private void grdCellsContents_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			WMSDataGridView grd = grdCellsContents;
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
						e.CellStyle.Format = "### ###";
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
					if ((bool)r.Cells["grcWeighting"].Value)
						e.CellStyle.Format = "### ###.000";
					else
						e.CellStyle.Format = "### ###";
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
						case "AF":
						case "AP":
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
				case "AF":
				case "AP":
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
			//mnuAddCellsContents.Show(btnAdd, new Point(btnAdd.Left, btnAdd.Top));
			mnuAddCellsContents.Show(btnAdd.Left, btnAdd.Top);
		}

		private void mniAddFrame_Click(object sender, EventArgs e)
		{ 
			// добавление целого контейнера

			// ячейка предназначена для контейнеров?
			if (!_bForFrames)
			{
				WMSMessage.MessageBoxError("Ячейка не предназначена для размещения контейнеров!");
				return;
			}

			// в ячейке есть место для еще одного контейнера?
			int nFramesQnt = 0;
			foreach (DataRow dr in oCell.TableCellsContents.Rows)
			{ 
				if (dr["Changes"].ToString() != "D")
					nFramesQnt++;
			}
			if (nFramesQnt + 1 > _nMaxPalletQnt)
			{
				WMSMessage.MessageBoxError("В ячейке уже находится " + WMSPublic.WMSUtilities.Declen(nFramesQnt, "контейнер", "контейнера", "контейнеров") + ".\n" + 
					"В ячейке невозможно разместить еще один контейнер!");
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

			cboFrame.Enabled = true;
			cboGood.Enabled = false;
			numQnt.Enabled = false;
			cboGoodState.Enabled = false;
			cboOwner.Enabled = false;

			cboFrame.SelectedValue = -1;
			cboGood.SelectedValue = -1;
			numQnt.Value = 0;
			cboOwner.SelectedValue = -1;
			cboGoodState.SelectedValue = -1;
			grdCellsContents.Enabled = false;

			_cMode = "AF";
		}

		private void mniAddCellsContents_Click(object sender, EventArgs e)
		{ 
			// добавление еще одного товара: либо просто в ячейку, либо в текущий контейнер

			btnSave.Enabled = false;
			btnAdd.Enabled = false;
			btnEdit.Enabled = false;
			btnDelete.Enabled = false;
			btnGridSave.Enabled = true;
			btnGridUndo.Enabled = true;

			pnlDataChange.BorderStyle = BorderStyle.Fixed3D;
			pnlDataChange.Enabled = true;

			cboFrame.Enabled = false;
			if (_bForFrames)
			{
				// товар в контейнер, владелец и состояние остаются те же
				cboGood.Enabled = true;
				numQnt.Enabled = true;
				cboGoodState.Enabled = false;
				cboOwner.Enabled = false;
			}
			else
			{ 
				// товар в ячейку, надо выбрать владельца и состояние (если фикс.закрепление - только те же!)
				cboFrame.SelectedValue = -1;

				cboGood.Enabled = true;
				numQnt.Enabled = true;
				if (_nFixedGoodStateID != null)
				{
					cboGoodState.SelectedValue = _nFixedGoodStateID;
					cboGoodState.Enabled = false;
				}
				else
				{
					cboGoodState.SelectedValue = -1;
					cboGoodState.Enabled = true;
				}
				if (_nFixedOwnerID != null)
				{
					cboOwner.SelectedValue = _nFixedOwnerID;
					cboOwner.Enabled = false;
				}
				else
				{
					cboOwner.SelectedValue = -1; 
					cboOwner.Enabled = true;
				}
			}
			numQnt.Value = 0;
			grdCellsContents.Enabled = false;

			_cMode = "AP";
		}


		private void btnEdit_Click(object sender, EventArgs e)
		{
			cboFrame.Enabled = _bForFrames;
			grdCellsContents.Enabled = false;

			btnSave.Enabled = false;
			btnAdd.Enabled = false;
			btnEdit.Enabled = false;
			btnDelete.Enabled = false;
			btnGridSave.Enabled = true;
			btnGridUndo.Enabled = true;

			pnlDataChange.BorderStyle = BorderStyle.Fixed3D;
			pnlDataChange.Enabled = true;
			// меняем не сам контейнер, а товар в контейнере
			if (true)
			{
				cboFrame.Enabled = false;
				chkFrameNew.Enabled = false;
				cboGood.Enabled = false;
				numQnt.Enabled = true;
				cboGoodState.Enabled = false;
				cboOwner.Enabled = false;
			}
			_cMode = "E";
		}

		private void btnGridSave_Click(object sender, EventArgs e)
		{
			// сохранить в DataTable
			decimal nInBox = 0;
			int nBoxInPal = 0;

			switch (_cMode)
			{
				case "AF":
					// целый контейнер

					if (chkFrameNew.Checked)
					{
						// новый контейнер, сразу с товаром и количеством - один товар
						DataRow rFAdd = oCell.TableCellsContents.Rows.Add();

						rFAdd["ID"] = DBNull.Value;
						rFAdd["FrameID"] = -1;
						rFAdd["FrameNew"] = true;
						if (cboGood.SelectedValue != null && cboGood.SelectedValue != DBNull.Value && (int)cboGood.SelectedValue > 0)
						{
							rFAdd["PackingID"] = cboGood.SelectedValue;
							rFAdd["PackingAlias"] = cboGood.Text;
						}
						else
						{
							WMSMessage.MessageBoxError("Не указан товар!");
							return;
						}

						if (numQnt.Value != 0)
						{
							rFAdd["Qnt"] = numQnt.Value;
						}
						else
						{
							WMSMessage.MessageBoxError("Не указано количество товара!");
							return;
						}

						DataRow rFGood = oGood.MainTable.Rows.Find((int)cboGood.SelectedValue);
						rFAdd["Weighting"] = rFGood["Weighting"];
						nInBox = (decimal)rFGood["InBox"];
						nBoxInPal = (int)rFGood["BoxInPal"];
						if (nInBox != 0)
						{
							rFAdd["BoxQnt"] = (decimal)rFAdd["Qnt"] / nInBox;
							if (nBoxInPal != 0)
								rFAdd["BoxQnt"] = (decimal)rFAdd["Qnt"] / nInBox / nBoxInPal;
						}
						rFAdd["Changes"] = "A";
					}
					else
					{
						// существующий контейнер
						foreach (DataRow rc in oFrameAdd.TableFramesContents.Rows)
						{
							DataRow rCAdd = oCell.TableCellsContents.Rows.Add();
							rCAdd["ID"] = DBNull.Value;
							rCAdd["FrameID"] = cboFrame.SelectedValue;
							rCAdd["FrameNew"] = false;

							rCAdd["GoodStateID"] = rc["GoodStateID"];
							rCAdd["GoodStateName"] = rc["GoodStateName"];
							rCAdd["OwnerID"] = rc["OwnerID"];
							rCAdd["OwnerName"] = rc["OwnerName"];

							rCAdd["PackingID"] = rc["PackingID"];
							rCAdd["PackingAlias"] = rc["PackingAlias"];
							rCAdd["Qnt"] = rc["Qnt"];

							DataRow rCGood = oGood.MainTable.Rows.Find((int)cboGood.SelectedValue);
							rCAdd["Weighting"] = rCGood["Weighting"];
							nInBox = (decimal)rCGood["InBox"];
							nBoxInPal = (int)rCGood["BoxInPal"];
							if (nInBox != 0)
							{
								rCAdd["BoxQnt"] = (decimal)rCAdd["Qnt"] / nInBox;
								if (nBoxInPal != 0)
									rCAdd["BoxQnt"] = (decimal)rCAdd["Qnt"] / nInBox / nBoxInPal;
							}
							rCAdd["Changes"] = "A";
						}
					}

					break;

				case "AP":

					// товар в контейнер или в ячейку

					DataRow rPAdd = oCell.TableCellsContents.Rows.Add();

					rPAdd["ID"] = DBNull.Value;

					if (_bForFrames && cboFrame.SelectedValue != null && cboFrame.SelectedValue != DBNull.Value && (int)cboFrame.SelectedValue > 0)
						rPAdd["FrameID"] = cboFrame.SelectedValue;
					else
						rPAdd["FrameID"] = DBNull.Value;

					if (cboGood.SelectedValue != null && cboGood.SelectedValue != DBNull.Value && (int)cboGood.SelectedValue > 0)
					{
						rPAdd["PackingID"] = cboGood.SelectedValue;
						rPAdd["PackingAlias"] = cboGood.Text;
					}
					else
					{
						WMSMessage.MessageBoxError("Не указан товар!");
						return;
					}

					if (numQnt.Value != 0)
					{
						rPAdd["Qnt"] = numQnt.Value;
					}
					else
					{
						WMSMessage.MessageBoxError("Не указано количество товара!");
						return;
					}

					if (cboGoodState.SelectedValue != null && cboGoodState.SelectedValue != DBNull.Value && (int)cboGoodState.SelectedValue > 0)
					{
						rPAdd["GoodStateID"] = cboGoodState.SelectedValue;
						rPAdd["GoodStateName"] = cboGoodState.Text;
					}
					else
					{
						WMSMessage.MessageBoxError("Не указано состояние товара!");
						return;
					}

					if (cboOwner.SelectedValue != null && cboOwner.SelectedValue != DBNull.Value && (int)cboOwner.SelectedValue > 0)
					{
						rPAdd["OwnerID"] = cboOwner.SelectedValue;
						rPAdd["OwnerName"] = cboOwner.Text;
					}
					else
					{
						if (WMSMessage.MessageBoxYesNo("Не указан владелец товара!\nСохранить без указаниея владельца?") == DialogResult.Yes)
						{
							rPAdd["OwnerID"] = DBNull.Value;
							rPAdd["OwnerName"] = DBNull.Value;
						}
						else
							return;
					}

					DataRow rPGood = oGood.MainTable.Rows.Find((int)cboGood.SelectedValue);
					rPAdd["Weighting"] = rPGood["Weighting"];
					nInBox = (decimal)rPGood["InBox"];
					nBoxInPal = (int)rPGood["BoxInPal"];
					if (nInBox != 0)
					{
						rPAdd["BoxQnt"] = (decimal)rPAdd["Qnt"] / nInBox;
						if (nBoxInPal != 0)
							rPAdd["BoxQnt"] = (decimal)rPAdd["Qnt"] / nInBox / nBoxInPal;
					}

					rPAdd["Changes"] = "A";
					break;

				case "E":

					DataRow r = oCell.TableCellsContents.Rows[bsCellsContents.Position];
					if (numQnt.Value != 0)
					{
						r["Qnt"] = numQnt.Value;
					}
					else
					{
						WMSMessage.MessageBoxError("Не указано количество товара!");
						return;
					}

					nInBox = (decimal)r["InBox"];
					nBoxInPal = (int)r["BoxInPal"];
					if (nInBox != 0)
					{
						r["BoxQnt"] = (decimal)r["Qnt"] / nInBox;
						if (nBoxInPal != 0)
							r["BoxQnt"] = (decimal)r["Qnt"] / nInBox / nBoxInPal;
					}

					r["Changes"] = "E";

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

			DataRow rd = oCell.TableCellsContents.Rows[bsCellsContents.Position];
			if (_bForFrames)
			{
				// контейнеры
				if (rd["FrameID"] == null || rd["FrameID"] == DBNull.Value)
				{
					// там оказался товар без контейнера
					if (WMSMessage.MessageBoxYesNo("В ячейке, предназначенной для контейнеров, обнаружен товар!\nУдалить товар?") == DialogResult.Yes)
					{
						rd["Changes"] = "D";
					}
					return;
				}
				else
				{
					// контейнер
					int nFrameID = (int)rd["FrameID"];
					// в нем один товар?
					int nI = 0;
					foreach (DataRow r in oCell.TableCellsContents.Rows)
					{
						if ((int)r["FrameID"] == nFrameID)
						{
							nI++;
						}
					}
					if (nI > 1)
					{
						// несколько товаров в контейнере
						if (WMSMessage.MessageBoxYesNo("В контейнере находятся разные товары.\nУдалить все товары в контейнере?") == DialogResult.Yes)
						{
							foreach (DataRow r in oCell.TableCellsContents.Rows)
							{
								if ((int)r["FrameID"] == nFrameID)
								{
									r["Changes"] = "D";
								}
							}
						}
						else
						{
							if (WMSMessage.MessageBoxYesNo("Удалить только текущий товар в контейнере?") == DialogResult.Yes)
							{
								rd["Changes"] = "D";
							}
						}
					}
					else
					{
						// один товар в контейнере
						if (WMSMessage.MessageBoxYesNo("Удалить контейнер?") == DialogResult.Yes)
						{
							rd["Changes"] = "D";
						}
					}
				}
			}
			else
			{ 
				// товары
				if (WMSMessage.MessageBoxYesNo("Удалить товар?") == DialogResult.Yes)
				{
					rd["Changes"] = "D";
				}
			}
		}

	#endregion

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

	}
}