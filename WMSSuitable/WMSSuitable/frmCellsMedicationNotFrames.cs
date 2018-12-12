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
	public partial class frmCellsMedicationNotFrames : RFMFormChild
	{
		protected Cell oCell;
		
		protected Good oGood;
		protected Partner oOwner;
		protected GoodState oGoodState;

		protected string _sAddress = "";
		protected int? _nFixedOwnerID = null;
		protected int? _nFixedGoodStateID = null;
		protected int? _nFixedPackingID = null;

		protected Good oGoodAdd; // при добавлении
		public int? nPackingAddID; 
		public int? _SelectedPackingID;

		protected string _cMode = "";

		protected bool _bLoaded = false; 

		public frmCellsMedicationNotFrames(int nCellID)
		{
			oCell = new Cell();
			oGood = new Good();
			oOwner = new Partner();
			oGoodState = new GoodState();
			oGoodAdd = new Good();

			if (oCell.ErrorNumber != 0 || 
				oGood.ErrorNumber != 0 ||
				oOwner.ErrorNumber != 0 ||
				oGoodState.ErrorNumber != 0 ||
				oGoodAdd.ErrorNumber != 0)
			{
				IsValid = false;
			}

			if (IsValid)
			{
				InitializeComponent();
				oCell.ID = nCellID;
			}
		}
		
		private void frmCellsMedicationNotFrames_Load(object sender, EventArgs e)
		{
			bool lResult = true; 

			grcBoxQnt.AgrType = 
			grcPalQnt.AgrType = 
			grcQnt.AgrType = 
				EnumAgregate.Sum;
			numBoxQnt.Minimum = numRestQnt.Minimum = 0;

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
				// работаем только с неконтейнерными ячейками
				if (r["ForFrames"] != DBNull.Value && (bool)r["ForFrames"])
				{
					RFMMessage.MessageBoxError("Ячейка предназначена для контейнеров...");
					lResult = false;
				}
			}

			if (lResult)
			{
				_sAddress = r["Address"].ToString();
				lblCellID.Text = _sAddress + " (код " + r["ID"].ToString() + ")";

				if (r["FixedOwnerID"] != DBNull.Value && r["FixedOwnerID"] != null)
				{
					_nFixedOwnerID = Convert.ToInt32(r["FixedOwnerID"]);
					txtFixedOwnerName.Text = r["FixedOwnerName"].ToString();
				}
				if (r["FixedGoodStateID"] != DBNull.Value && r["FixedGoodStateID"] != null)
				{
					_nFixedGoodStateID = Convert.ToInt32(r["FixedGoodStateID"]);
					txtFixedGoodStateName.Text = r["FixedGoodStateName"].ToString();
				}
				if (r["FixedPackingID"] != DBNull.Value && r["FixedPackingID"] != null)
				{
					_nFixedPackingID = Convert.ToInt32(r["FixedPackingID"]);
					txtFixedPackingName.Text = r["PackingAlias"].ToString(); 
				}

				// содержимое ячейки 
				oCell.FillTableCellsContents(oCell.ID, false);
				if (oCell.ErrorNumber != 0)
					lResult = false;
			}

			if (lResult)
			{
				// если в ячейке оказались и контейнеры, и товары - оставим только товары
				bool bDiff = false;
				foreach (DataRow rd in oCell.TableCellsContents.Rows)
				{
					if (!Convert.IsDBNull(rd["FrameID"]))
					{
						bDiff = true;
						break;
					}
				}
				if (bDiff)
				{
					DataView dv = new DataView(oCell.TableCellsContents);
					dv.RowFilter = "FrameID is Null";
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
				oCell.TableCellsContents.PrimaryKey = null;
				oCell.TableCellsContents.Columns["ID"].Unique = false;

				oCell.TableCellsContents.Columns.Add("PackingNew", Type.GetType("System.Boolean"));
				oCell.TableCellsContents.Columns.Add("Changes", Type.GetType("System.String"));
				foreach (DataRow rd in oCell.TableCellsContents.Rows)
				{
					//rd["ID"] = DBNull.Value;
					rd["PackingNew"] = false;
					rd["Changes"] = "";
				}

				grdCellsContents_Restore();
			}

			if (lResult)
			{
				//  заполнение cbo-классификаторов 
				lResult = cboGood_Restore() && 
						  cboOwner_Restore() &&
						  cboGoodState_Restore();
				if (!lResult)
				{
					RFMMessage.MessageBoxError("Ошибка при заполнении классификаторов (товары)...");
				}
			}

			if (lResult)
			{
				cboOwner.SelectedValue = -1;
				cboGoodState.SelectedValue = -1;
				cboGood.SelectedValue = -1;
				txtGood.Text = "";
				numBoxQnt.Value = 0;
				numRestQnt.Value = 0; 
				dtpDateValid.Value = DateTime.Now.Date;
				dtpDateValid.HideControl(false); 
			}

			// если что-то не получилось - выход
			if (!lResult)
			{
				Dispose();
			}

			pnlDataChange.Enabled = false;
			btnAdd.Enabled = true;
			btnEdit.Enabled = false;
			btnDelete.Enabled = false;
			btnGridSave.Enabled = false;
			btnGridUndo.Enabled = false;

			grdCellsContents.Select();

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
			int nCellID = Convert.ToInt32(oCell.ID);

			// всякие проверки
			if (oCell.TableCellsContents.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("В ячейке нет ни одного товара.\nНечего сохранять...");
				return;
			}

			int nCntNoChanges = 0;
			int nCntAdd = 0;
			int nCntDel = 0;
			int nCntEdt = 0;
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
				if (r["Changes"].ToString() == "E")
				{
					nCntEdt++;
				}
				if (r["Changes"].ToString().Length == 0)
				{
					nCntNoChanges++;
				}
			}
			if (nCntAdd == 0 && nCntDel == 0 && nCntEdt == 0)
			{
				RFMMessage.MessageBoxError("Нет изменений в содержимом ячейки.\nНечего сохранять...");
				return;
			}

			string sText = "Ячейка " + _sAddress + "\n";
			if (nCntNoChanges > 0)
			{
				sText = sText + "\nВ ячейке находятся товары: " + nCntNoChanges.ToString();
			}
			if (nCntDel > 0)
			{
				sText = sText + "\nИз ячейки удаляются товары: " + nCntDel.ToString();
			}
			if (nCntAdd > 0)
			{
				sText = sText + "\nВ ячейку добавляются товары: " + nCntAdd.ToString();
			}
			if (nCntEdt > 0)
			{
				sText = sText + "\nВ ячейке изменяется количество/срок годности товаров: " + nCntEdt.ToString();
			}
			sText = sText + "\n\nСохранить?";
			if (RFMMessage.MessageBoxYesNo(sText) == DialogResult.Yes)
			{
				Refresh();
				WaitOn(this);

				int? nUserID = ((RFMFormMain)Application.OpenForms[0]).UserID; 
				int? nDeviceID = null;
				string sNoteManual = txtNoteManual.Text.Trim();
				// собственно сохранение
				oCell.MedicationNotFrames(nCellID, oCell.TableCellsContents, nUserID, nDeviceID, sNoteManual);
				//
				WaitOff(this);
				if (oCell.ErrorNumber == 0)
				{
					DialogResult = DialogResult.Yes;
					Dispose();
				}
			}
		}

	#region Restore

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
			oOwner.FilterSeparatePicking = true;
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

		private void grdCellsContents_Restore()
		{
			grdCellsContents.Restore(oCell.TableCellsContents);
		}

		private void btnPackings_Click(object sender, EventArgs e)
		{
			_SelectedPackingID = null;
			nPackingAddID = null;
			pnlDataChange.Enabled = false;
			if (StartForm(new frmSelectOnePacking(this, false)) == DialogResult.Yes)
			{
				if (_SelectedPackingID != null)
				{
					nPackingAddID = _SelectedPackingID;
					cboGood.SelectedValue = Convert.ToInt32(_SelectedPackingID);
					txtGood.Text = cboGood.Text;
				}
				_SelectedPackingID = null;

				oGoodAdd.PackingID = nPackingAddID;
				oGoodAdd.FillData();

				DataRow r = oGoodAdd.MainTable.Rows[0];
				if (r != null)
				{
					txtGood.Text = r["PackingAlias"].ToString();
					// срок годности
					if (r["Retention"] != DBNull.Value && r["Retention"] != null)
					{
						dtpDateValid.Value = DateTime.Now.Date.AddDays(Convert.ToInt32(r["Retention"]));
					}
					// весовой
					decimal nInBox = 1;
					bool bDecimalInBox = false;
					bool bWeighting = false;
					if (r["InBox"] != DBNull.Value && r["InBox"] != null)
					{
						nInBox = (decimal)r["InBox"];
						bDecimalInBox = ((int)nInBox != nInBox);
					}
					if (r["Weighting"] != DBNull.Value && r["Weighting"] != null)
					{
						bWeighting = (bool)r["Weighting"];
					}
					numRestQnt.DecimalPlaces = ((bWeighting || bDecimalInBox) ? 3 : 0);
					numRestQnt.InputMask = ((bWeighting || bDecimalInBox) ? "########0.000" : "########0");
					numRestQnt.Refresh();

					numBoxQnt.Enabled = !bWeighting; 
				}
			}
			pnlDataChange.Enabled = true;

			if (numBoxQnt.Enabled)
				numBoxQnt.Select();
			else
				numRestQnt.Select();
		}

	#endregion

	#region RowEnter, CellFormatting

		private void grdCellsContents_RowEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (grdCellsContents.IsStatusRow(e.RowIndex))
			{
				cboGood.SelectedValue = -1;
				txtGood.Text = "";
				numBoxQnt.Value = 0;
				numRestQnt.Value = 0;
				dtpDateValid.Value = DateTime.Now.Date;
				dtpDateValid.HideControl(false); 
				return;
			}

			DataGridViewRow r = grdCellsContents.Rows[e.RowIndex];

			bool bWeighting = false;
			if (r.Cells["grcWeighting"].Value != null &&
				r.Cells["grcWeighting"].Value != DBNull.Value)
			{
				bWeighting = (bool)r.Cells["grcWeighting"].Value;
			}
			decimal nQnt = 0, nInBox = 1;
			bool bDecimalInBox = false;
			if (r.Cells["grcQnt"].Value != null &&
				r.Cells["grcQnt"].Value != DBNull.Value)
			{
				nQnt = Convert.ToDecimal(r.Cells["grcQnt"].Value);
				nInBox = Convert.ToDecimal(r.Cells["grcInBox"].Value);
				bDecimalInBox = ((int)nInBox != nInBox);
			}
			if (bWeighting)
			{
				numBoxQnt.Value = 0;
				numRestQnt.DecimalPlaces = 3;
				numRestQnt.InputMask = "########0.000";
				numRestQnt.Value = nQnt;
			}
			else
			{
				numBoxQnt.Value = System.Math.Floor(nQnt / nInBox);
				numRestQnt.DecimalPlaces = ((bDecimalInBox) ? 3 : 0); ;
				numRestQnt.InputMask = ((bDecimalInBox) ? "########0.000" : "########0");
				numRestQnt.Value = nQnt - (System.Math.Floor(nQnt / nInBox) * nInBox);
			}

			if (r.Cells["grcPackingID"].Value != null &&
				r.Cells["grcPackingID"].Value != DBNull.Value)
			{
				cboGood.SelectedValue = Convert.ToInt32(r.Cells["grcPackingID"].Value);
				txtGood.Text = cboGood.Text;
			}
			else
			{
				cboGood.SelectedValue = -1;
				txtGood.Text = "";
			}
			if (r.Cells["grcDateValid"].Value != null &&
				r.Cells["grcDateValid"].Value != DBNull.Value)
			{
				dtpDateValid.Value = (DateTime)r.Cells["grcDateValid"].Value;
			}
			else
			{
				dtpDateValid.Value = DateTime.Now.Date;
			}

			if (r.Cells["grcOwnerID"].Value != null &&
				r.Cells["grcOwnerID"].Value != DBNull.Value)
			{
				cboOwner.SelectedValue = Convert.ToInt32(r.Cells["grcOwnerID"].Value);
			}
			else
			{
				cboOwner.SelectedValue = -1;
			}
			if (r.Cells["grcGoodStateID"].Value != null &&
				r.Cells["grcGoodStateID"].Value != DBNull.Value)
			{
				cboGoodState.SelectedValue = Convert.ToInt32(r.Cells["grcGoodStateID"].Value);
			}
			else
			{
				cboGoodState.SelectedValue = -1;
			}

			string cChanges = r.Cells["grcChanges"].Value.ToString().Trim();
			switch (cChanges)
			{
				case (""):
				case ("A"):
				case ("E"):
					btnEdit.Enabled = true;
					btnDelete.Enabled = true;
					break;
				case ("D"):
					btnEdit.Enabled = false;
					btnDelete.Enabled = false;
					break;
			}
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
						e.CellStyle.Format = "### ### ### ##0.000";
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
			// добавление нового товара

			btnSave.Enabled = false;
			btnAdd.Enabled = false;
			btnEdit.Enabled = false;
			btnDelete.Enabled = false;
			btnGridSave.Enabled = true;
			btnGridUndo.Enabled = true;

			pnlDataChange.BorderStyle = BorderStyle.Fixed3D;
			pnlDataChange.Enabled = true;

			if (_nFixedOwnerID.HasValue)
			{
				cboOwner.SelectedValue = (int)_nFixedOwnerID;
				cboOwner.Enabled = false;
			}
			else
			{
				cboOwner.Enabled = true;
			}
			if (_nFixedGoodStateID.HasValue)
			{
				cboGoodState.SelectedValue = (int)_nFixedGoodStateID;
				cboGoodState.Enabled = false;
			}
			else
			{
				cboGoodState.Enabled = true;
			}
			btnPackings.Enabled = true;
			numBoxQnt.Enabled = true;
			numRestQnt.Enabled = true;
			//dtpDateValid.Enabled = true;

			cboGood.SelectedValue = -1;
			txtGood.Text = "";
			numBoxQnt.Value = 0;
			numRestQnt.Value = 0;
			dtpDateValid.Value = DateTime.Now.Date;

			grdCellsContents.Enabled = false;

			lblAction.Text = "Добавление товара в ячейку";
			_cMode = "A";

			btnPackings_Click(null, null);
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			// изменение количества товара

			if (grdCellsContents.CurrentRow == null)
				return;

			btnSave.Enabled = false;
			btnAdd.Enabled = false;
			btnEdit.Enabled = false;
			btnDelete.Enabled = false;
			btnGridSave.Enabled = true;
			btnGridUndo.Enabled = true;

			pnlDataChange.BorderStyle = BorderStyle.Fixed3D;
			pnlDataChange.Enabled = true;

			cboOwner.Enabled =
			cboGoodState.Enabled =
				false;

			btnPackings.Enabled = false;
			numBoxQnt.Enabled = (!(bool)grdCellsContents.CurrentRow.Cells["grcWeighting"].Value);
			numRestQnt.Enabled = true;
			//dtpDateValid.Enabled = true;

			grdCellsContents.Enabled = false;

			if (numBoxQnt.Enabled)
				numBoxQnt.Select();
			else
				numRestQnt.Select();
  
			lblAction.Text = "Изменение количества / срока годности для товара в ячейке";
			_cMode = "E";
		}

		private void btnGridSave_Click(object sender, EventArgs e)
		{
			// всякие проверки
			if (cboGood.SelectedValue == null || cboGood.SelectedIndex < 0)
			{
				RFMMessage.MessageBoxError("Не указан товар...");
				return;
			}

			if (numBoxQnt.Value <= 0 && numRestQnt.Value <= 0)
			{
				RFMMessage.MessageBoxError("Не указано количество товара...");
				return;
			}

			if (cboGoodState.Enabled)
			{
				if (_nFixedGoodStateID != null)
				{
					if (cboGoodState.SelectedValue != null && cboGoodState.SelectedIndex >= 0 &&
						(int)cboGoodState.SelectedValue != _nFixedGoodStateID)
					{
						RFMMessage.MessageBoxError("Указанное состояния товара не совпадает с закрепленным состоянием товара для ячейки...");
						cboGoodState.Select();
						return;
					}
				}
				else
				{
					// нет фиксированного закрепления
					if (cboGoodState.SelectedIndex < 0 || cboGoodState.SelectedValue == null)
					{
						RFMMessage.MessageBoxError("Не указано состояние товара...");
						cboGoodState.Select();
						return;
					}
				}
			}

			if (cboOwner.Enabled)
			{
				if (_nFixedOwnerID != null)
				{
					if (cboOwner.SelectedValue != null && cboOwner.SelectedIndex >= 0 &&
						(int)cboOwner.SelectedValue != _nFixedOwnerID)
					{
						RFMMessage.MessageBoxError("{Указанный хранитель не совпадает с закрепленным хранителем для ячейки...");
						cboOwner.Select();
						return;
					}
				}
				else
				{
					// нет фиксированного закрепления
					if (oOwner.MainTable.Rows.Count > 0 && 
						(cboOwner.SelectedIndex < 0 || cboOwner.SelectedValue == null) )
					{
						if (RFMMessage.MessageBoxYesNo("Не указан хранитель (общий товар)...\nВсе-таки сохранить?") != DialogResult.Yes)
						{
							cboOwner.Select();
							return;
						}
					}
				}
			}

			// сохранить в DataTable
			int nPackingID = Convert.ToInt32(cboGood.SelectedValue);

			// закрепление за товаром?
			if (_nFixedPackingID != null && _nFixedPackingID != nPackingID)
			{
				if (RFMMessage.MessageBoxYesNo("Внимание!\n\nЯчейка закреплена за другим товаром!\n\nВсе-таки сохранить?") != DialogResult.Yes)
					return;
			}

			int? nOwnerID = null;
			if (cboOwner.SelectedValue != null && cboOwner.SelectedIndex >= 0)
				nOwnerID = Convert.ToInt32(cboOwner.SelectedValue);
			int? nGoodStateID = null;
			if (cboGoodState.SelectedValue != null && cboGoodState.SelectedIndex >= 0)
				nGoodStateID = Convert.ToInt32(cboGoodState.SelectedValue);

			decimal nQnt = 0, nInBox = 0,
				nRestQnt = numRestQnt.Value, nBoxQnt = numBoxQnt.Value;
			int nBoxInPal = 0;
			DateTime dDateValid = dtpDateValid.Value.Date;

			int nTempPackingID;
			DateTime? dTempDateValid;
			int nTempGoodStateID;
			int? nTempOwnerID;

			switch (_cMode)
			{
				case "A":

					// нет ли этого товара уже в ячейке?
					foreach (DataRow r in oCell.TableCellsContents.Rows)
					{
						nTempPackingID = Convert.ToInt32(r["PackingID"]);
						nTempGoodStateID = Convert.ToInt32(r["GoodStateID"]);
						if (r["OwnerID"] != null && r["OwnerID"] != DBNull.Value)
							nTempOwnerID = Convert.ToInt32(r["OwnerID"]);
						else
							nTempOwnerID = null;

						if (dtpDateValid.Enabled)
						{
							// с учетом срока годности
							if (r["DateValid"] != null && r["DateValid"] != DBNull.Value)
								dTempDateValid = (DateTime)r["DateValid"];
							else
								dTempDateValid = null;

							if (nTempPackingID == nPackingID && dTempDateValid == dDateValid && 
								nTempGoodStateID == nGoodStateID &&
								(nTempOwnerID != null && nOwnerID != null && nTempOwnerID == nOwnerID || 
								 nTempOwnerID == null && nOwnerID == null)
								)
							{
								if (r["Changes"].ToString() == "")
								{
									RFMMessage.MessageBoxError("Товар с таким сроком годности уже находится в ячейке...");
									return;
								}
								if (r["Changes"].ToString() == "A")
								{
									RFMMessage.MessageBoxError("Товар с таким сроком годности уже добавлен в ячейку...");
									return;
								}
							}
						}
						else
						{ 
							// без учета срока годности 
							if (nTempPackingID == nPackingID && 
								nTempGoodStateID == nGoodStateID &&
								(nTempOwnerID != null && nOwnerID != null && nTempOwnerID == nOwnerID || 
								 nTempOwnerID == null && nOwnerID == null)
								)
							{
								if (r["Changes"].ToString() == "" || r["Changes"].ToString() == "E")
								{
									RFMMessage.MessageBoxError("Такой товар уже находится в ячейке...");
									return;
								}
								if (r["Changes"].ToString() == "A")
								{
									RFMMessage.MessageBoxError("Такой товар уже добавлен в ячейку...");
									return;
								}
							}
						}
					}

					// выбранный товар
					DataRow rCGood = oGoodAdd.MainTable.Rows[0];

					// добавляем строку в таблицу
					DataRow rCAdd = oCell.TableCellsContents.Rows.Add();

					rCAdd["ID"] = DBNull.Value;
					rCAdd["PackingNew"] = false;

					rCAdd["PackingID"] = nPackingID;
					rCAdd["GoodAlias"] = rCGood["GoodAlias"];
					rCAdd["Weighting"] = rCGood["Weighting"];

					nInBox = Convert.ToDecimal(rCGood["InBox"]);
					rCAdd["InBox"] = nInBox;
					nQnt = nBoxQnt * nInBox + nRestQnt;
					rCAdd["Qnt"] = nQnt;

					nBoxInPal = Convert.ToInt32(rCGood["BoxInPal"]);
					rCAdd["BoxInPal"] = nBoxInPal;
					if (nInBox != 0)
					{
						rCAdd["BoxQnt"] = nQnt / nInBox;
						if (nBoxInPal != 0)
						{
							rCAdd["PalQnt"] = nQnt / nInBox / nBoxInPal;
						}
					}
					if (dtpDateValid.Enabled)
					{
						rCAdd["DateValid"] = dDateValid;
					}
					rCAdd["GoodStateID"] = nGoodStateID;
					rCAdd["GoodStateName"] = cboGoodState.Text;
					if (nOwnerID.HasValue)
					{
						rCAdd["OwnerID"] = nOwnerID;
						rCAdd["GoodStateName"] = cboOwner.Text;
					}
					else
					{
						rCAdd["OwnerID"] = DBNull.Value; // ???
					}

					rCAdd["Changes"] = "A";

					break;

				case "E":
					
					// текущая строка для исправления
					//DataRow rCEdit = oCell.TableCellsContents.Rows[grdCellsContents.GridSource.Position];
					DataRow rCEdit = ((DataRowView)grdCellsContents.GridSource.Current).Row;

					if (nBoxQnt <= 0 && nRestQnt <= 0)
					{
						if (RFMMessage.MessageBoxYesNo("Не указано количество товара...\n\nУдалить товар из ячейки?") == DialogResult.Yes)
						{
							rCEdit["Changes"] = "D";
						}
						else
							return;
					}

					// нет ли этого товара с таким же сроком годности уже в ячейке?
					for (int i = 0; i < oCell.TableCellsContents.Rows.Count; i++)
					{
						DataRow r = oCell.TableCellsContents.Rows[i];
						//if (i == grdCellsContents.GridSource.Position)
						if (r == rCEdit)
						{
							// та же запись
							continue;
						}

						nTempPackingID = Convert.ToInt32(r["PackingID"]);
						nTempGoodStateID = Convert.ToInt32(r["GoodStateID"]);
						if (r["OwnerID"] != null && r["OwnerID"] != DBNull.Value)
							nTempOwnerID = Convert.ToInt32(r["OwnerID"]);
						else
							nTempOwnerID = null;

						if (dtpDateValid.Enabled)
						{
							// с учетом срока годности 
							if (r["DateValid"] != null && r["DateValid"] != DBNull.Value)
								dTempDateValid = (DateTime)r["DateValid"];
							else
								dTempDateValid = null;

							if (nTempPackingID == nPackingID && dTempDateValid == dDateValid && 
								nTempGoodStateID == nGoodStateID &&
								(nTempOwnerID != null && nOwnerID != null && nTempOwnerID == nOwnerID || 
								 nTempOwnerID == null && nOwnerID == null)
								)
							{
								if (r["Changes"].ToString() == "" || r["Changes"].ToString() == "E")
								{
									RFMMessage.MessageBoxError("Товар с таким сроком годности уже находится в ячейке...");
									return;
								}
								if (r["Changes"].ToString() == "A")
								{
									RFMMessage.MessageBoxError("Товар с таким сроком годности уже добавлен в ячейку...");
									return;
								}
							}
						}
						else
						{
							// без учета срока годности 
							if (nTempPackingID == nPackingID &&
								nTempGoodStateID == nGoodStateID &&
								(nTempOwnerID != null && nOwnerID != null && nTempOwnerID == nOwnerID || 
								 nTempOwnerID == null && nOwnerID == null)
								)
							{
								if (r["Changes"].ToString() == "")
								{
									RFMMessage.MessageBoxError("Такой товар уже находится в ячейке...");
									return;
								}
								if (r["Changes"].ToString() == "A")
								{
									RFMMessage.MessageBoxError("Такой товар уже добавлен в ячейку...");
									return;
								}
							}
						}
					}

					// исправляем строку в таблице
					nInBox = Convert.ToDecimal(rCEdit["InBox"]);
					nQnt = nBoxQnt * nInBox + nRestQnt;
					rCEdit["Qnt"] = nQnt;

					nBoxInPal = Convert.ToInt32(rCEdit["BoxInPal"]);
					if (nInBox != 0)
					{
						rCEdit["BoxQnt"] = nQnt / nInBox;
						if (nBoxInPal != 0)
						{
							rCEdit["PalQnt"] = nQnt / nInBox / nBoxInPal;
						}
					}
					if (dtpDateValid.Enabled)
					{
						rCEdit["DateValid"] = dDateValid;
					}

					if (rCEdit["Changes"].ToString() != "A")
					{
						rCEdit["Changes"] = "E";
					}

					break;
			}

			// встать на товар
			int nPosition = grdCellsContents.GridSource.Find("PackingID", nPackingID);
			if (nPosition >= 0)
			{
				// проверить, совпадает ли состояние товара
				DataRow r = ((DataRowView)grdCellsContents.GridSource[nPosition]).Row;
				if (Convert.ToInt32(r["GoodStateID"]) == nGoodStateID)
				{
					grdCellsContents.GridSource.Position = nPosition;
				}
				else
				{
					// ищем строку с другим состоянием 
					/*
					DataRow[] rs = oCell.TableCellsContents.Select("PackingID = " + nPackingAddID.ToString() + " and GoodStateID = " + nGoodStateID);
					if (rs.Length > 0)
					{
						// не работает без сортировки
						int nPos = Array.IndexOf(oCell.TableCellsContents.Select(grdCellsContents.GridSource.Filter, grdCellsContents.GridSource.Sort), rs[0]);
					}
					*/
					foreach (DataGridViewRow dr in grdCellsContents.Rows)
					{
						if ((int)dr.Cells["grcPackingID"].Value == nPackingID && (int)dr.Cells["grcGoodStateID"].Value == nGoodStateID)
						{
							nPosition = grdCellsContents.Rows.IndexOf(dr);
							break;
						}
					}
					if (nPosition >= 0)
					{
						grdCellsContents.GridSource.Position = nPosition;
					}
				}
			}

			//

			btnGridUndo_Click(null, null);
		}

		private void btnGridUndo_Click(object sender, EventArgs e)
		{
			if (grdCellsContents.CurrentRow == null)
				return;

			pnlDataChange.BorderStyle = BorderStyle.FixedSingle;
			pnlDataChange.Enabled = false;
			grdCellsContents.Enabled = true;
			grdCellsContents.Refresh();

			btnSave.Enabled = true;
			btnGridSave.Enabled = false;
			btnGridUndo.Enabled = false;
			btnAdd.Enabled = true;

			lblAction.Text = "";
			_cMode = "";

			grdCellsContents.Select();
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (grdCellsContents.CurrentRow == null)
				return;

			//DataRow rd = oCell.TableCellsContents.Rows[grdCellsContents.GridSource.Position];
			DataRow rd = ((DataRowView)grdCellsContents.GridSource.Current).Row;
			if (RFMMessage.MessageBoxYesNo("Удалить текущий товар в ячейке?") == DialogResult.Yes)
			{
				rd["Changes"] = "D";
			}

			grdCellsContents.Select();
		}

	#endregion

	#region Хранитель cboOwner

		private void btnOwnerClear_Click(object sender, EventArgs e)
		{
			cboOwner.SelectedIndex = -1;
			cboOwner.SelectedValue = -1;
		}

	#endregion


	}
}