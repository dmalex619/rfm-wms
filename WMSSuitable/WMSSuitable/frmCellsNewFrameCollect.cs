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
	public partial class frmCellsNewFrameCollect : RFMFormChild
	{
		protected Cell oCellSource;
		protected Cell oCellTarget;
		protected StoreZone oStoreZoneTarget;
		protected Frame oFrame;
		protected Good oGood;

		protected string _sAddress = "";
		public int? _SelectedPackingID;

		DataTable tCellContent;

		protected bool _bLoaded = false;

		protected bool bOK = false;
		protected bool bDoubleClick = false;

		public frmCellsNewFrameCollect(int nCellID, DataTable _tCellContent)
		{
			oCellSource = new Cell();
			oCellTarget = new Cell();
			oStoreZoneTarget = new StoreZone();
			oFrame = new Frame();
			if (oCellSource.ErrorNumber != 0 ||
				oCellTarget.ErrorNumber != 0 ||
				oStoreZoneTarget.ErrorNumber != 0 ||
				oFrame.ErrorNumber != 0)
			{ 
				IsValid = false;
			}

			if (IsValid)
			{
				InitializeComponent();

				oCellSource.ID = nCellID;
				tCellContent = _tCellContent;
			}
		}
		
		private void frmCellsNewFrameCollect_Load(object sender, EventArgs e)
		{

			bool lResult = true;

			// параметры ячейки
			oCellSource.FillData();
			if (oCellSource.ErrorNumber != 0 || oCellSource.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о ячейке...");
				lResult = false;
			}

			if (lResult)
			{
				DataRow r = oCellSource.MainTable.Rows[0];
				if (r == null)
				{
					RFMMessage.MessageBoxError("Не определена исходная ячейка...");
					lResult = false;
				}

				/*
				if (lResult)
				{
					// работаем только с контейнерными ячейками
					if (r["ForFrames"] != DBNull.Value && !(bool)(r["ForFrames"]))
					{
						WMSMessage.MessageBoxError("Исходная ячейка не предназначена для контейнеров...");
						lResult = false;
					}
				}
				*/

				if (lResult)
				{
					_sAddress = r["Address"].ToString();
					lblCellID.Text = _sAddress + " (код " + r["ID"].ToString() + ")";
				}

				if (lResult)
				{
					tCellContent.Columns.Add("QntCollect", Type.GetType("System.Decimal"));
					tCellContent.Columns.Add("BoxCollect", Type.GetType("System.Decimal"));
					foreach (DataRow rd in tCellContent.Rows)
					{
						rd["QntCollect"] = rd["BoxCollect"] = 0;
					}

					grdCellsContents_Restore();
				}
			}

			if (lResult)
			{
				//  заполнение cbo-классификаторов для приемника 
				lResult = cboStoresZonesTarget_Restore() &&
						  cboStoresZonesTypesTarget_Restore() &&
						  cboCellTargetAddress_Restore();
				oCellTarget.ID = null; 
				if (!lResult)
				{
					RFMMessage.MessageBoxError("Ошибка при заполнении классификаторов (контейнеры, товары)...");
				}
			}

			if (lResult)
			{
				lblPackingName.Text = "";
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

			grcBoxQnt.AgrType =
			grcQnt.AgrType =
			grcPalQnt.AgrType =
			grcBoxCollect.AgrType =
			grcQntCollect.AgrType =
				EnumAgregate.Sum;
			numBoxQnt.Minimum = numRestQnt.Minimum = 0;


			pnlDataChange.Enabled = false;
			btnGridSave.Enabled = false;
			btnGridUndo.Enabled = false;

			optCreateTraffic_CheckedChanged(null, null);

			grdCellsContents.Select();

			_bLoaded = true;
			cboStoresZonesTypesTarget.Enabled = false;
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
			// контейнер?
			if (txtFrameBarCode.Text.Length == 0 || oFrame.ID == null)
			{
				RFMMessage.MessageBoxError("Не выбран контейнер...");
				return;
			}

			oFrame.FillData();
			if (oFrame.ErrorNumber != 0 || oFrame.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о контейнере...");
				return;
			}

			DataRow rFr = oFrame.MainTable.Rows[0];
			if (rFr["PalletTypeID"] == DBNull.Value || Convert.ToDecimal(rFr["FrameHeight"]) == 0)
			{
				RFMMessage.MessageBoxError("Не заданы геометрические характеристики контейнера...");
				btnFrameEdit_Click(null, null);
				return;
			}
			int nFrameID = (int)oFrame.ID;

			// выбранный товар?
			decimal nSelectedCnt = 0;
			int nSelectedRows = 0;
			string sPackingList = ",";
			foreach (DataRow r in tCellContent.Rows)
			{
				if (Convert.ToDecimal(r["QntCollect"]) != 0)
				{
					nSelectedCnt = nSelectedCnt + Convert.ToDecimal(r["QntCollect"]);
					nSelectedRows++;
					if (!sPackingList.Contains("," + r["PackingID"].ToString().Trim() + ","))
					{
						sPackingList = sPackingList + r["PackingID"].ToString().Trim() + ",";
					}
				}
			}
			if (nSelectedCnt == 0)
			{
				RFMMessage.MessageBoxError("Не выбраны товары для сбора в контейнер.\nНечего сохранять...");
				return;
			}

			if (!chkStereo.Checked && RFMPublic.RFMUtilities.Occurs(sPackingList, ",") > 2)
			{
				RFMMessage.MessageBoxError("В контейнере не может быть собран разный товар...");
				return;
			}

			// траффик? ячейка?
			bool bCreateTraffic = false;
			bool bDirectToCell = false; 
			int? nCellTargetID = null;

			if (optNotCreateTraffic.Checked ||
				optCreateTrafficAccommodation.Checked ||
				optCreateTrafficCell.Checked)
			{ 
				// контейнер остается в той же ячейке, по крайней мере пока
				Cell oCellTemp = new Cell();
				oCellTemp.ID = oCellSource.ID;
				oCellTemp.FillData();
				if (oCellTemp.ErrorNumber != 0 || oCellTemp.MainTable.Rows.Count == 0)
				{
					RFMMessage.MessageBoxError("Ошибка при получении данных об исходной ячейке...");
					return;
				}
				if (oCellTemp.MainTable.Rows[0]["ForFrames"] != DBNull.Value && !Convert.ToBoolean(oCellTemp.MainTable.Rows[0]["ForFrames"]))
				{
					RFMMessage.MessageBoxError("Исходная ячейка не предназначена для контейнеров...");
					return;
				}
			}
			
			if (optCreateTrafficAccommodation.Checked)
			{
				// подбор ячейки по правилам
				bCreateTraffic = true;
			}

			if (optCreateTrafficCell.Checked || 
				optDirectToCell.Checked)
			{
				// создать трафик в выбранную ячейку
				if (optCreateTrafficCell.Checked)
				{
					bCreateTraffic = true;
				}
				// напрямую в ячейку
				if (optDirectToCell.Checked)
				{
					bDirectToCell = true;
				}
				
				// выбрать ячейку
				if (cboCellTargetAddress.SelectedValue == null || cboCellTargetAddress.SelectedIndex < 0)
				{
					RFMMessage.MessageBoxError("Не выбрана ячейка, в которой следует разместить контейнер...");
					return;
				}

				Cell oCellTemp = new Cell();
				oCellTarget.ID = Convert.ToInt32(cboCellTargetAddress.SelectedValue);
				oCellTemp.ID = oCellTarget.ID;
				oCellTemp.FillData();
				if (oCellTemp.ErrorNumber != 0 || oCellTemp.MainTable.Rows.Count == 0)
				{
					RFMMessage.MessageBoxError("Ошибка при получении данных о конечной ячейке...");
					return;
				}
				if (oCellTemp.MainTable.Rows[0]["ForFrames"] != DBNull.Value && !Convert.ToBoolean(oCellTemp.MainTable.Rows[0]["ForFrames"]))
				{
					RFMMessage.MessageBoxError("Конечная ячейка не предназначена для контейнеров...");
					return;
				}

				nCellTargetID = (int)cboCellTargetAddress.SelectedValue;
			}

			// собственно сохранение
			DataTable tCellContentSelected = tCellContent.Clone();
			foreach(DataRow r in tCellContent.Rows)
			{
				if (Convert.ToDecimal(r["QntCollect"]) > 0)
				{
					tCellContentSelected.ImportRow(r);
				}
			}
			if (tCellContentSelected.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Не найдены товары для сбора в контейнер.\nНечего сохранять...");
				return;
			}

			string sText = "";
			if (bCreateTraffic)
			{
				sText = sText + " и создать операцию транспортировки для контейнера";
			}
			if (bDirectToCell)
			{
				sText = sText + " и выполнить размещение в ячейке";
			}
			if (RFMMessage.MessageBoxYesNo("Выполнить сбор товаров в контейнер" + sText + "?") == DialogResult.Yes)
			{
				int nUserID = ((RFMFormBase)Application.OpenForms[0]).UserInfo.UserID;

				// собственно сохранение
				oCellSource.NewFrameCollect(nFrameID, tCellContentSelected, bCreateTraffic, bDirectToCell, nCellTargetID, nUserID);
				//
				if (oCellSource.ErrorNumber == 0 || oCellSource.ErrorNumber < -100)
				{
					DialogResult = DialogResult.Yes;
					Dispose();
				}
			}
		}


	#region RowEnter, CellFormatting

		private void grdCellsContents_RowEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (grdCellsContents.IsStatusRow(e.RowIndex))
			{
				lblPackingName.Text = "";
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
				nQnt = (decimal)r.Cells["grcQnt"].Value;
				nInBox = (decimal)r.Cells["grcInBox"].Value;
				bDecimalInBox = ((int)nInBox != nInBox);
			}
			if (bWeighting)
			{
				numBoxQnt.Value = 0;
				numRestQnt.DecimalPlaces = 3;
				numRestQnt.Value = nQnt;
			}
			else
			{
				numBoxQnt.Value = System.Math.Floor(nQnt / nInBox);
				numRestQnt.DecimalPlaces = ((bDecimalInBox) ? 3 : 0);
				numRestQnt.Value = nQnt - (System.Math.Floor(nQnt / nInBox) * nInBox);
			}

			if (r.Cells["grcPackingID"].Value != null &&
				r.Cells["grcPackingID"].Value != DBNull.Value)
			{
				lblPackingName.Text = r.Cells["grcGoodAlias"].Value.ToString() + " " +
										r.Cells["grcInBox"].Value.ToString();
			}
			else
			{
				lblPackingName.Text = "";
			}
			if (r.Cells["grcDateValid"].Value != null &&
				r.Cells["grcDateValid"].Value != DBNull.Value)
			{
				dtpDateValid.Value = (DateTime)r.Cells["grcDateValid"].Value;
				dtpDateValid.HideControl(true);
			}
			else
			{
				dtpDateValid.Value = DateTime.Now.Date;
				dtpDateValid.HideControl(false);
			}

			btnEdit.Enabled = true;
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
					case "grcQntCollect":
					case "grcInBox":
						e.CellStyle.Format = "### ### ### ###";
						break;
					case "grcBoxCollect":
						e.CellStyle.Format = "### ### ### ###.#";
						break;
					case "grcChangesImage":
						e.Value = Properties.Resources.Empty;
						break;
				}
				return;
			}

			DataGridViewRow r = grd.Rows[e.RowIndex];
			switch (grd.Columns[e.ColumnIndex].Name)
			{
				case "grcQnt":
				case "grcQntCollect":
				case "grcInBox":
					if (!Convert.IsDBNull(r.Cells["grcWeighting"].Value) &&
						Convert.ToBoolean(r.Cells["grcWeighting"].Value) ||
						!Convert.IsDBNull(e.Value) && Convert.ToDecimal(e.Value) != Convert.ToInt32(e.Value))
						e.CellStyle.Format = "### ### ### ###.000";
					else
						e.CellStyle.Format = "### ### ### ###";
					break;
				case "grcBoxCollect":
					e.CellStyle.Format = "### ### ### ###.#";
					break;
			}
		}

	#endregion

	#region GridButtons

		private void btnEdit_Click(object sender, EventArgs e)
		{
			// изменение количества товара

			if (grdCellsContents.CurrentRow == null)
			{
				bOK = false;
				return;
			}

			// если моноконтейнер - чтобы не нажать больше одного раза
			if (!chkStereo.Checked)
			{
				int nPackingID = (int)grdCellsContents.CurrentRow.Cells["grcPackingID"].Value;
				int nCurrentRowIndex = grdCellsContents.CurrentRow.Index;
				int nRowIndex = 0;
				foreach (DataRow r in tCellContent.Rows)
				{
					if (nRowIndex != nCurrentRowIndex)
					{
						if (Convert.ToInt32(r["PackingID"]) != nPackingID && Convert.ToDecimal(r["QntCollect"]) != 0)
						{
							RFMMessage.MessageBoxError("В контейнере не может быть собран разный товар...");
							bOK = false;
							return;
						}
					}
					nRowIndex++;
				}
			}

			if (bDoubleClick)
				return;

			btnSave.Enabled = false;
			btnEdit.Enabled = false;
			btnGridSave.Enabled = true;
			btnGridUndo.Enabled = true;

			pnlDataChange.BorderStyle = BorderStyle.Fixed3D;
			pnlDataChange.Enabled = true;

			numBoxQnt.Enabled = (!(bool)grdCellsContents.CurrentRow.Cells["grcWeighting"].Value);
			numRestQnt.Enabled = true;
			dtpDateValid.Enabled = true;

			grdCellsContents.Enabled = false;

			if (numBoxQnt.Enabled)
				numBoxQnt.Select();
			else
				numRestQnt.Select(); 
		}

		private void btnGridSave_Click(object sender, EventArgs e)
		{
			if (numBoxQnt.Value <= 0 && numRestQnt.Value <= 0)
			{
				if (RFMMessage.MessageBoxYesNo("Не указано количество товара...\r\nИсключить данный товар из контейнера?") != DialogResult.Yes) 
					return;
			}

			if (dtpDateValid.IsEmpty)
			{ 
				RFMMessage.MessageBoxError("Не указан срок годности для товара на поддоне...");
				dtpDateValid.HideControl(true);
				dtpDateValid.Select();
				return;
			}

			// сохранить в DataTable
			decimal nQnt = 0, nInBox = 0,
				nRestQnt = numRestQnt.Value, nBoxQnt = numBoxQnt.Value;
			DateTime? dDateValid = null;
			if (!dtpDateValid.IsEmpty)
				dDateValid = dtpDateValid.Value.Date;

			// исправляем строку в таблице
			//DataRow rCEdit = tCellContent.Rows[grdCellsContents.GridSource.Position];
			DataRow rCEdit = ((DataRowView)grdCellsContents.GridSource.Current).Row;

			decimal nQntNow = (decimal)rCEdit["Qnt"];
			nInBox = (decimal)rCEdit["InBox"];
			nQnt = nBoxQnt * nInBox + nRestQnt;

			if (nQnt > nQntNow)
			{
				RFMMessage.MessageBoxError("Указано количество большее, чем есть в ячейке...");
				return;
			}

			rCEdit["QntCollect"] = nQnt;
			rCEdit["BoxCollect"] = nQnt / nInBox;
			if (dDateValid == null)
				rCEdit["DateValid"] = DBNull.Value;
			else
				rCEdit["DateValid"] = dDateValid;

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
			if (grdCellsContents.CurrentRow != null)
				grdCellsContents_RowEnter(grdCellsContents, new DataGridViewCellEventArgs(0, grdCellsContents.CurrentRow.Index));
		}

		private void grdCellsContents_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (grdCellsContents.IsStatusRow(e.RowIndex))
				return;

			bDoubleClick = true;
			bOK = true;
			btnEdit_Click(null, null);
			if (bOK)
			{
				btnGridSave_Click(null, null);
			}
			bDoubleClick = false;
		}

	#endregion

	#region Restore

		private void grdCellsContents_Restore()
		{
			grdCellsContents.Restore(tCellContent);
		}

		// Target
		private bool cboCellTargetAddress_Restore()
		{
			oCellTarget.ClearError();
			oCellTarget.ClearFilters();
			oCellTarget.ID = null;
			if (cboStoresZonesTarget.SelectedIndex < 0)
			{
				cboCellTargetAddress.Enabled = false;
				cboCellTargetAddress.DataSource = null;
				return (false);
			}
			oCellTarget.FilterActual = true;
			oCellTarget.FilterLocked = false;
			oCellTarget.FilterForFrames = true;
			oCellTarget.FilterStoresZonesList = cboStoresZonesTarget.SelectedValue.ToString();
			oCellTarget.FillData();
			if (oCellTarget.MainTable.Rows.Count == 0)
			{
				cboCellTargetAddress.Enabled = false;
				cboCellTargetAddress.DataSource = null;
				if (_bLoaded)
				{
					RFMMessage.MessageBoxError("Нет подходящих ячеек в выбранной конечной зоне...");
				}
			}
			else
			{
				cboCellTargetAddress.Enabled = true;
				cboCellTargetAddress.ValueMember = oCellTarget.MainTable.Columns[0].Caption;
				cboCellTargetAddress.DisplayMember = oCellTarget.MainTable.Columns["Address"].Caption;
				cboCellTargetAddress.DataSource = oCellTarget.MainTable;
			}
			return (oCellTarget.ErrorNumber == 0);
		}

		private bool cboStoresZonesTarget_Restore()
		{
			oStoreZoneTarget.FillData();
			cboStoresZonesTarget.ValueMember = oStoreZoneTarget.MainTable.Columns[0].Caption;
			cboStoresZonesTarget.DisplayMember = oStoreZoneTarget.MainTable.Columns[1].Caption;
			cboStoresZonesTarget.DataSource = oStoreZoneTarget.MainTable;
			return (oStoreZoneTarget.ErrorNumber == 0);
		}

		private bool cboStoresZonesTypesTarget_Restore()
		{
			oStoreZoneTarget.FillTableStoresZonesTypes();
			cboStoresZonesTypesTarget.ValueMember   = oStoreZoneTarget.TableStoresZonesTypes.Columns[0].Caption;
			cboStoresZonesTypesTarget.DisplayMember = oStoreZoneTarget.TableStoresZonesTypes.Columns[1].Caption;
			cboStoresZonesTypesTarget.DataSource = oStoreZoneTarget.TableStoresZonesTypes;
			return (oStoreZoneTarget.ErrorNumber == 0);
		}

		private bool FrameChoose()
		{
			WaitOn(this);

			bool bResult = true;

			oFrame.FillData();
			if (oFrame.MainTable.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Не найдена запись для контейнера с кодом " + oFrame.ID.ToString() + "...");
				bResult = false;
			}
			else 
			{
				DataRow r = oFrame.MainTable.Rows[0];
				if (r["CellID"] != DBNull.Value)
				{
					RFMMessage.MessageBoxError("Контейнер уже размещен в ячейке " + r["CellAddress"].ToString() + "...");
					bResult = false;
				}
				if (bResult)
				{
					oFrame.FillTableFramesContents((int)oFrame.ID);
					if (oFrame.TableFramesContents.Rows.Count > 0)
					{
						RFMMessage.MessageBoxError("Контейнер уже содержит товар...");
						bResult = false;
					}
				}
				// контейнер
				txtFrameBarCode.Text = r["BarCode"].ToString();
				bResult = (oFrame.ErrorNumber == 0);
			}

			WaitOff(this);
			return (bResult);
		}

	#endregion

	#region Выбор контейнера 

		private void txtFrameID4_TextChanged(object sender, EventArgs e)
		{
			if (txtFrameID4.Text.Length == 4)
			{ 
				// ищем подходящий контейнер
				Frame oFrameTemp = new Frame();
				oFrameTemp.FilterActual = true;
				oFrameTemp.FilterHasFrameContent = false;
				oFrameTemp.FillData();
				if (oFrameTemp.MainTable.Rows.Count > 0)
				{
					for (int i = oFrameTemp.MainTable.Rows.Count - 1; i >= 0; i--)
					{
						DataRow r = oFrameTemp.MainTable.Rows[i];
						if (r["BarCode"].ToString().EndsWith(txtFrameID4.Text.Trim()))
						{
							oFrameTemp.ID = Convert.ToInt32(r["ID"]);
							break;
						}
					}
				}
				if (oFrameTemp.ID == null)
				{
					RFMMessage.MessageBoxError("Нет доступных контейнеров с таким кодом...");
					txtFrameBarCode.Text = txtFrameID4.Text = "";
					oFrame.ID = null;
					return;
				}
				else
				{
					oFrame.ID = oFrameTemp.ID;
					if (!FrameChoose())
					{
						txtFrameBarCode.Text = txtFrameID4.Text = "";
						oFrame.ID = null;
					}
				}
			}
		}

		private void txtFrameBarCode_Validating(object sender, CancelEventArgs e)
		{
			if (txtFrameBarCode.Text.Length > 0)
			{
				Frame oFrameTemp = new Frame();
				oFrameTemp.FilterActual = true;
				oFrameTemp.FilterHasFrameContent = false;
				oFrameTemp.FillData();
				if (oFrameTemp.MainTable.Rows.Count > 0)
				{
					for (int i = oFrameTemp.MainTable.Rows.Count - 1; i >= 0; i--)
					{
						DataRow r = oFrameTemp.MainTable.Rows[i];
						if (r["BarCode"].ToString().Contains(txtFrameBarCode.Text.Trim()))
						{
							oFrameTemp.ID = Convert.ToInt32(r["ID"]);
							break;
						}
					}
				}
				if (oFrameTemp.ID == null)
				{
					RFMMessage.MessageBoxError("Нет доступных контейнеров с таким кодом...");
					txtFrameBarCode.Text = txtFrameID4.Text = "";
					oFrame.ID = null;
					return;
				}
				else
				{
					oFrame.ID = oFrameTemp.ID;
					if (!FrameChoose())
					{
						txtFrameBarCode.Text = txtFrameID4.Text = "";
						oFrame.ID = null;
					}
				}
			}
		}

		private void txtFrameBarCode_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				txtFrameBarCode_Validating(null, null);
		}

		#region Изменение геометрии контейнера

		private void btnFrameEdit_Click(object sender, EventArgs e)
		{
			if (oFrame.ID == null)
				return;

			StartForm(new frmFramesEdit(oFrame));
		}

		#endregion

	#endregion

	#region Выбор ячейки-приемника

		private void optCreateTraffic_CheckedChanged(object sender, EventArgs e)
		{
			if (optCreateTrafficCell.Checked || optDirectToCell.Checked)
			{
				cboStoresZonesTarget.Enabled =
				cboCellTargetAddress.Enabled = 
					true;
				if (cboStoresZonesTarget.SelectedIndex < 0)
				{
					cboStoresZonesTarget_SelectedIndexChanged(null, null);
				}
			}
			else
			{
				cboStoresZonesTarget.Enabled =
				cboCellTargetAddress.Enabled =
					false;
				cboStoresZonesTarget.SelectedIndex = 
				cboCellTargetAddress.SelectedIndex =
					-1; 
			}
		}

		private void cboStoresZonesTarget_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboStoresZonesTarget.SelectedIndex < 0 || !cboStoresZonesTarget.Enabled)
			{
				cboStoresZonesTypesTarget.SelectedIndex = -1;
				cboCellTargetAddress.SelectedIndex = -1;
				cboCellTargetAddress.Enabled = false;
				return;
			}

			DataRow zt = oStoreZoneTarget.MainTable.Rows[cboStoresZonesTarget.SelectedIndex];
			if (zt != null)
			{
				cboStoresZonesTypesTarget.SelectedValue = (int)zt["StoreZoneTypeID"];
				// перевывести список ячеек этой зоны
				cboCellTargetAddress_Restore();
				cboCellTargetAddress.SelectedIndex = -1;
				//cboCellTargetAddress.Enabled = true;
			}
		}

		private void cboCellTargetAddress_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboCellTargetAddress.SelectedValue != null && cboCellTargetAddress.SelectedIndex >= 0)
			{
				DataRow ct = oCellTarget.MainTable.Rows.Find((int)cboCellTargetAddress.SelectedValue);
				if (ct == null)
				{
					RFMMessage.MessageBoxError("Не найдена запись для ячейки-приемника с кодом " + ct["ID"].ToString() + "...");
					cboCellTargetAddress.SelectedIndex = -1;
				}
			}
		}

	#endregion

	}
}