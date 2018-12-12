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
	public partial class frmTrafficsFramesForPickingCreate : RFMFormChild
	{
		protected TrafficFrame oTraffic;
		protected Frame oFrame;

		protected Good oGood;
		protected int? nPackingID = null;
		protected bool bWeighting = false;
		public int? _SelectedPackingID = null;
		public string _SelectedPackingAliasText = null;

		protected Partner oOwner;
		protected GoodState oGoodState;

		protected Cell oCell;
		protected Cell oCellPicking;
		protected Cell oCellOutput;
		protected int? nCellFinishID;
		protected string sCellFinishAddress = "";

		int nPriority = 2;

		protected bool bMarkingByCnt = false;
		protected bool bMarkingByCheck = false;

		protected DataTable dt;
		
		protected bool _bLoaded = false;

		public frmTrafficsFramesForPickingCreate()
		{
			oTraffic = new TrafficFrame();
			oFrame = new Frame();
			oGood = new Good();

			if (oTraffic.ErrorNumber != 0 ||
				oFrame.ErrorNumber != 0 ||
				oGood.ErrorNumber != 0)
			{
				IsValid = false;
			}

			if (IsValid)
			{
				oCell = new Cell();
				oCellPicking = new Cell();
				oCellOutput = new Cell();
				if (oCell.ErrorNumber != 0 ||
					oCellPicking.ErrorNumber != 0 ||
					oCellOutput.ErrorNumber != 0)
				{
					IsValid = false;
				}
			}

			if (IsValid)
			{
				oOwner = new Partner();
				oGoodState = new GoodState();
				if (oOwner.ErrorNumber != 0 ||
					oGoodState.ErrorNumber != 0)
				{
					IsValid = false;
				}
			}

			if (IsValid)
			{
				InitializeComponent();
			}
		}
		
		private void frmTrafficManual_Load(object sender, EventArgs e)
		{
			bool bResult = true;

			bResult = cboGoodState_Restore() &&
					  cboOwner_Restore() && 
					  cboCellOutput_Restore();

			if (!bResult)
			{
				DialogResult = DialogResult.No;
				Dispose();
			}

			chkDateValidControl_CheckedChanged(null, null);
			grdData.IsCheckerShow = true;
			lblBoxQnt.Text = ""; 
			chkForOutput_CheckedChanged(null, null);

			cboOwner.SelectedIndex = -1;

			//btnPackings_Click(null, null);
		}

		private void btnHelp_Click(object sender, EventArgs e)
		{
			RFMHelpUtilities.HelpShow(this, hpHelp);
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.No;
			Dispose();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (grdData.DataSource == null || grdData.Rows.Count == 0)
			{
				RFMMessage.MessageBoxError("Не получен список доступных поддонов...");
				return;
			}

			// проверяем отмеченные контейнеры
			int nMarkedCnt = 0;
			foreach (DataRow r in dt.Rows)
			{
				if (!Convert.IsDBNull(r["IsMarked"]) && Convert.ToBoolean(r["IsMarked"]))
				{
					nMarkedCnt++;
				}
			}
			if (nMarkedCnt == 0)
			{
				RFMMessage.MessageBoxError("Не отмечено ни одного поддона...");
				return;
			}

			if (chkForOutput.Checked)
			{
				// в отгрузку
				if (cboCellOutput.SelectedValue == null || cboCellOutput.SelectedIndex < 0)
				{
					RFMMessage.MessageBoxError("Не выбрана ячейка отгрузки...");
					return;
				}

				Cell oCellOutputTemp = new Cell();
				oCellOutputTemp.ID = (int)cboCellOutput.SelectedValue;
				oCellOutputTemp.FillData();
				if (oCellOutputTemp.ErrorNumber != 0 || oCellOutputTemp.MainTable == null || oCellOutputTemp.MainTable.Rows.Count != 1)
				{
					RFMMessage.MessageBoxError("Ошибка при получении данных о ячейке отгрузки...");
					return;
				}
				nCellFinishID = Convert.ToInt32(oCellOutputTemp.MainTable.Rows[0]["ID"]);
				sCellFinishAddress = oCellOutputTemp.MainTable.Rows[0]["Address"].ToString();

				if (RFMMessage.MessageBoxYesNo("Создать операции транспортировки в ячейку отгрузки " + sCellFinishAddress + " для " +
						RFMPublic.RFMUtilities.Declen(nMarkedCnt, "поддона", "поддонов", "поддонов") + "?") != DialogResult.Yes)
					return;
			}
			else
			{
				if (oCellPicking.MainTable == null || oCellPicking.MainTable.Rows.Count == 0)
				{
					RFMMessage.MessageBoxError("Не определена ячейка пикинга для товара.");
					return;
				}
				nCellFinishID = Convert.ToInt32(oCellPicking.MainTable.Rows[0]["ID"]);
				sCellFinishAddress = oCellPicking.MainTable.Rows[0]["Address"].ToString();

				// в пикинг
				if (RFMMessage.MessageBoxYesNo("Создать операции транспортировки в ячейку пикинга " + sCellFinishAddress + " для " +
						RFMPublic.RFMUtilities.Declen(nMarkedCnt, "поддона", "поддонов", "поддонов") + "?") != DialogResult.Yes)
					return;
			}

			// создаем транспортировки последовательно
			int nFrameID;
			int nOK = 0;
			string sNote = txtNoteManual.Text.Trim();
			foreach (DataRow r in dt.Rows)
			{
				if (!Convert.IsDBNull(r["IsMarked"]) && Convert.ToBoolean(r["IsMarked"]))
				{
					oTraffic.ClearError();
					nFrameID = Convert.ToInt32(r["FrameID"]);
					oTraffic.CreateManualDirect(nFrameID, (int)nCellFinishID, nPriority, sNote);
					if (oTraffic.ErrorNumber == 0)
						nOK++;
				}
			}

			if (nOK > 0)
			{
				RFMMessage.MessageBoxInfo("Создано " + RFMUtilities.Declen(nOK, "задание", "задания", "заданий") + " на транспортировку поддонов в " + 
					((chkForOutput.Checked) ? "зону отгрузки" : "пикинг") + ".");
				DialogResult = DialogResult.Yes;
				Dispose();
			}
			else
			{
				RFMMessage.MessageBoxError("Задания на транспортировку поддонов в " + ((chkForOutput.Checked) ? "зону отгрузки" : "пикинг") + " не созданы.");
			}
		}


	#region Restore

		private bool grdData_Restore()
		{
			RFMCursorWait.Set(true);
			RFMCursorWait.LockWindowUpdate(FindForm().Handle);

			oFrame.ClearError();
			oFrame.ClearFilters();
			oFrame.IDList = null;

			oCell.ClearError();
			oCell.ClearFilters();
			oCell.IDList = null;

			grdData.DataSource = null;
			if (dt != null)
			{
				dt.Clear();
			}

			string sRestoreErrorText = "";

			// условия

			// сначала выберем ячейки хранения (не пикинга!): 
			// товар
			oCell.CellsContents_FilterPackingsList = nPackingID.ToString();
			// хранитель
			if (cboOwner.SelectedIndex >= 0 && cboOwner.SelectedValue != null)
			{
				oCell.CellsContents_FilterOwnersList = cboOwner.SelectedValue.ToString();
			}
			// состояние товара
			oCell.CellsContents_FilterGoodsStatesList = cboGoodState.SelectedValue.ToString();
			oCell.FilterStoreZoneTypeForStorage = true;
			oCell.FilterStoreZoneTypeForPicking = false;

			// 
			oCell.FillData();
			if (oCell.ErrorNumber != 0 || oCell.MainTable == null)
			{
				sRestoreErrorText = "Ошибка при получении данных о ячейках хранения, содержащих товар...";
			}
			if (sRestoreErrorText.Length == 0 && oCell.MainTable.Rows.Count == 0)
			{
				sRestoreErrorText = "В зоне хранения нет ячеек, содержащих товар...";
			}
			if (sRestoreErrorText.Length == 0)
			{
				// список подходящих ячеек
				string sCellsIDList = "";
				foreach (DataRow r in oCell.MainTable.Rows)
				{
					sCellsIDList += r["CellID"].ToString() + ",";
				}

				// теперь выберем контейнеры:
				// ячейки
				oFrame.FramesContents_FilterCellsList = sCellsIDList;
				// товар
				oFrame.FramesContents_FilterPackingsList = nPackingID.ToString();
				// хранитель
				if (cboOwner.SelectedIndex >= 0 && cboOwner.SelectedValue != null)
				{
					oFrame.FilterOwnersList = cboOwner.SelectedValue.ToString();
				}
				// состояние товара
				oFrame.FilterGoodsStatesList = cboGoodState.SelectedValue.ToString();
				// срок годности
				//if (chkDateValidControl.Checked && !dtpDateValid.IsEmpty)
				//{
				//	oFrame.FramesContents_FilterDateValidLess = dtpDateValid.Value.Date;
				//}
				oFrame.FilterActual = true;
				// 
				oFrame.FillData();
				if (oFrame.ErrorNumber != 0 || oFrame.MainTable == null)
				{
					sRestoreErrorText = "Ошибка при получении данных о контейнерах, содержащих товар...";
				}
				if (sRestoreErrorText.Length == 0 && oFrame.MainTable.Rows.Count == 0)
				{
					//sRestoreErrorText = "Нет поддонов с товаром " + (chkDateValidControl.Checked ? "с указанным сроком годности" : "") + " в зоне хранения...";
					sRestoreErrorText = "Нет поддонов с товаром в зоне хранения...";
				}
				if (sRestoreErrorText.Length == 0)
				{
					// уберем неподходящие 
					int nGoodStateID = (int)cboGoodState.SelectedValue;
					int? nOwnerID = null;
					if (cboOwner.SelectedIndex >= 0 && cboOwner.SelectedValue != null)
					{
						nOwnerID = (int)cboOwner.SelectedValue;
					}
					
					DataTable dtFrames = CopyTable(oFrame.MainTable, "dtFrames", "HasTraffic = false", "");

					oFrame.ClearError();
					oFrame.FillTableFramesContents(Convert.ToInt32(dtFrames.Rows[0]["FrameID"]));
					if (oFrame.ErrorNumber != 0 || oFrame.TableFramesContents == null)
					{
						sRestoreErrorText = "Ошибка при получении данных о содержимом контейнеров с товаром...";;
					}

					if (sRestoreErrorText.Length == 0)
					{
						DataTable dtContents = oFrame.TableFramesContents.Clone(); // CopyTable(oFrame.TableFramesContents, "", "", "");
						dtContents.Columns.Add("Locked", Type.GetType("System.Boolean"));
						dtContents.Columns.Add("FrameHeight", Type.GetType("System.Decimal"));
						dtContents.Columns.Add("FrameWeight", Type.GetType("System.Decimal"));
						dtContents.Columns.Add("DateLastOperation", Type.GetType("System.DateTime"));
						dtContents.Columns.Add("StoreZoneName", Type.GetType("System.String"));
						dtContents.Columns.Add("StoreZoneTypeName", Type.GetType("System.String"));

						foreach (DataRow r in dtFrames.Rows)
						{
							oFrame.ClearError();
							oFrame.FillTableFramesContents(Convert.ToInt32(r["FrameID"]));
							if (oFrame.ErrorNumber != 0 || oFrame.TableFramesContents == null)
								continue;
							if (oFrame.TableFramesContents.Rows.Count == 0)
								continue;

							foreach (DataRow rc in oFrame.TableFramesContents.Rows)
							{
								// не подходит по состоянию
								if (nGoodStateID != Convert.ToInt32(rc["GoodStateID"]))
									continue;

								// не подходит по владельцу
								if (nOwnerID == null && !Convert.IsDBNull(rc["OwnerID"]) ||
									nOwnerID != null && Convert.IsDBNull(rc["OwnerID"]) ||
									nOwnerID != null && !Convert.IsDBNull(rc["OwnerID"]) && nOwnerID != Convert.ToInt32(rc["OwnerID"]))
									continue;

								// не подходит по сроку годности 
								if (chkDateValidControl.Checked && Convert.ToDateTime(rc["DateValid"]).CompareTo(dtpDateValid.Value.Date) < 0)
									continue;

								// да, подходит 
								dtContents.ImportRow(rc);
								dtContents.Rows[dtContents.Rows.Count - 1]["Locked"] = r["Locked"];
								dtContents.Rows[dtContents.Rows.Count - 1]["FrameHeight"] = r["FrameHeight"];
								dtContents.Rows[dtContents.Rows.Count - 1]["FrameWeight"] = r["FrameWeight"];
								dtContents.Rows[dtContents.Rows.Count - 1]["DateLastOperation"] = r["DateLastOperation"];
								dtContents.Rows[dtContents.Rows.Count - 1]["StoreZoneName"] = r["StoreZoneName"];
								dtContents.Rows[dtContents.Rows.Count - 1]["StoreZoneTypeName"] = r["StoreZoneTypeName"];
							}
						}
						if (dtContents.Rows.Count == 0)
						{
							sRestoreErrorText = "Нет подходящих поддонов с товаром " + (chkDateValidControl.Checked ? "с указанным сроком годности" : "") + " в зоне хранения...";
						}

						// в dtContents собраны все подходящие контейнеры

						if (sRestoreErrorText.Length == 0)
						{
							dt = CopyTable(dtContents, "dt", "", "DateValid, FrameID");
							if (dt.Rows.Count > 0)
							{
								if (numFramesCnt.Value > dt.Rows.Count)
								{
									numFramesCnt.Value = dt.Rows.Count;
								}
							}
						}
					}
				}
			}
			if (sRestoreErrorText.Length > 0)
			{
				RFMMessage.MessageBoxError(sRestoreErrorText);
			}

			grdData.Restore(dt);
			grdData.Select();

			numFramesCnt_ValueChanged(null, null);

			RFMCursorWait.LockWindowUpdate(IntPtr.Zero);
			RFMCursorWait.Set(false);

			return (oFrame.ErrorNumber == 0);
		}

		private bool cboOwner_Restore()
		{
			oOwner.FilterOwner = true;
			oOwner.FilterSeparatePicking = true;
			oOwner.FilterActual = true;
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

		private bool cboCellOutput_Restore()
		{
			oCellOutput.FilterStoreZoneTypeForOutputs = true;
			oCellOutput.FilterActual = true;
			oCellOutput.FilterLocked = false;
			oCellOutput.FillData();
			cboCellOutput.DataSource = oCellOutput.MainTable;
			cboCellOutput.ValueMember = oCellOutput.ColumnID;
			cboCellOutput.DisplayMember = oCellOutput.MainTable.Columns["Address"].ColumnName;
			return (oCellOutput.ErrorNumber == 0);
		}

	#endregion

	#region CellFormatting

		private void grdData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (grdData.DataSource == null)
				return;

			if (grdData.IsStatusRow(e.RowIndex))
			{
				e.CellStyle.BackColor = Color.Silver;
				e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);

				switch (grdData.Columns[e.ColumnIndex].Name)
				{
					case "grcLockedImage":
						e.Value = Properties.Resources.Empty;
						break;
				}
				return;
			}

			DataGridViewRow r = grdData.Rows[e.RowIndex];
			switch (grdData.Columns[e.ColumnIndex].Name)
			{
				case "grcLockedImage":
					if ((bool)r.Cells["grcLocked"].Value)
						e.Value = Properties.Resources.Lock1;
					else
						e.Value = Properties.Resources.Empty;
					break;
				case "grcQnt":
					if (bWeighting)
						e.CellStyle.Format = "### ### ### ###.000";
					else
						e.CellStyle.Format = "### ### ### ###";
					break;
			}

			if ((grdData.Columns[e.ColumnIndex].Name.Contains("Qnt") || 
				grdData.Columns[e.ColumnIndex].Name.Contains("Height") ||
				 grdData.Columns[e.ColumnIndex].Name.Contains("Weight")) &&
				grdData.Columns[e.ColumnIndex].DefaultCellStyle.Format.Contains("N"))
			{
				if (Convert.IsDBNull(e.Value) || Convert.ToDecimal(e.Value) == 0)
				{
					e.Value = "";
				}
			}
		}

		#endregion

		private void btnFilter_Click(object sender, EventArgs e)
		{
			if (nPackingID == null || txtGood.Text.Length == 0)
			{
				RFMMessage.MessageBoxError("Не выбран товар...");
				return;
			}
			if (cboGoodState.SelectedIndex < 0 || cboGoodState.SelectedValue == null)
			{
				RFMMessage.MessageBoxError("Не указано состояние товара...");
				return;
			}
			if (chkDateValidControl.Checked && dtpDateValid.IsEmpty)
			{
				RFMMessage.MessageBoxError("Не указан минимальный срок годности...");
				return;
			}

			grdData_Restore();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			txtGood.Text = "";
			nPackingID = null;
		}

		private void btnPackings_Click(object sender, EventArgs e)
		{
			_SelectedPackingID = null;
			nPackingID = null;
			if (StartForm(new frmSelectOnePacking(this, false)) == DialogResult.Yes)
			{
				if (_SelectedPackingID != null)
				{
					// проверка наличия пикинговой ячейки для товара
					oCellPicking.ClearError();
					oCellPicking.ClearFilters();
					oCellPicking.FilterFixedPackingsList = _SelectedPackingID.ToString();
					oCellPicking.FilterStoreZoneTypeForStorage = true;
					oCellPicking.FilterStoreZoneTypeForPicking = true;
					oCellPicking.FillData();
					string sErrorText = "";
					if (oCellPicking.ErrorNumber != 0 || oCellPicking.MainTable == null)
					{
						sErrorText = "Ошибка при поиске ячейки пикинга...";
					}
					if (sErrorText.Length == 0 && oCellPicking.MainTable.Rows.Count == 0)
					{
						sErrorText = "Не найдена ячейка пикинга для товара...";
					}
					if (sErrorText.Length == 0 && oCellPicking.MainTable.Rows.Count > 1)
					{
						sErrorText = "Найдено несколько ячеек пикинга для товара...";
					}
					if (sErrorText.Length == 0)
					{
						nCellFinishID = Convert.ToInt32(oCellPicking.MainTable.Rows[0]["ID"]);
						sCellFinishAddress = oCellPicking.MainTable.Rows[0]["Address"].ToString();
						nPackingID = _SelectedPackingID;
						txtGood.Text = _SelectedPackingAliasText + ": ячейка пикинга " + oCellPicking.MainTable.Rows[0]["Address"];

						oGood.PackingID = (int)nPackingID; 
						oGood.FillData();
						if (oGood.ErrorNumber == 0 && oGood.MainTable.Rows.Count == 1)
						{
							bWeighting = Convert.ToBoolean(oGood.MainTable.Rows[0]["Weighting"]);
						}
					}
					else
					{
						RFMMessage.MessageBoxError(sErrorText);
					}
				}
				_SelectedPackingID = null;
				_SelectedPackingAliasText = null;
			}
		}

		private void chkDateValidControl_CheckedChanged(object sender, EventArgs e)
		{
			if (chkDateValidControl.Checked)
			{
				dtpDateValid.Enabled = 
				lblDateValidMin.Enabled = 
					true;
				dtpDateValid.HideControl(true);
			}
			else
			{
				dtpDateValid.Enabled =
				lblDateValidMin.Enabled = 
					false;
				dtpDateValid.HideControl(false);
			}
		}

		private void numFramesCnt_ValueChanged(object sender, EventArgs e)
		{
			if (dt == null || grdData.DataSource == null || grdData.Rows.Count == 0)
				return;

			RFMCursorWait.Set(true);
			RFMCursorWait.LockWindowUpdate(FindForm().Handle);

			bMarkingByCnt = true;

			if (numFramesCnt.Value > grdData.Rows.Count)
			{
				numFramesCnt.Value = grdData.Rows.Count;
			}

			decimal nBoxQnt = 0;
			if (!bMarkingByCheck)
			{
				grdData.MarkAllRows(false);
				for (int i = 0; i <= numFramesCnt.Value - 1; i++)
				{
					dt.Rows[i]["IsMarked"] = true;
					nBoxQnt += Convert.ToDecimal(dt.Rows[i]["BoxQnt"]);
				}
				lblBoxQnt.Text = ((decimal)(Math.Ceiling(nBoxQnt))).ToString("#########0").Trim() + " кор.";
			}

			bMarkingByCnt = false;

			RFMCursorWait.LockWindowUpdate(IntPtr.Zero);
			RFMCursorWait.Set(false);
		}

		private void grdData_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			bMarkingByCheck = true;

			if (!bMarkingByCnt)
			{
				//numFramesCnt.Value = grdData.GetMarkedRows();
				int nMarked = 0;
				decimal nBoxQnt = 0;
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					if ((bool)dt.Rows[i]["IsMarked"])
					{
						nMarked++;
						nBoxQnt += Convert.ToDecimal(dt.Rows[i]["BoxQnt"]);
					}
				}
				numFramesCnt.Value = nMarked;
				lblBoxQnt.Text = ((decimal)(Math.Ceiling(nBoxQnt))).ToString("#########0").Trim() + " кор.";
			}
			
			bMarkingByCheck = false;
		}

		private void chkForOutput_CheckedChanged(object sender, EventArgs e)
		{
			cboCellOutput.Enabled = chkForOutput.Checked;
		}

		private void btnOwnerClear_Click(object sender, EventArgs e)
		{
			cboOwner.SelectedIndex = -1;
			cboOwner.SelectedIndex = -1;
		}
	}
}