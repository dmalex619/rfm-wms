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
	public partial class frmCellsAddRange : RFMFormChild
	{
		private Cell oCell = new Cell();
		
		private StoreZone oStoreZone = new StoreZone();

		protected string sStoreZonePrefix = "";
		protected string sStoreZoneSuffix = "";
		protected string sAddressMask = "";
		protected int nBuildingLen, nLineLen, nRackLen, nLevelLen, nPlaceLen;

		protected bool _bLoaded = false; 

		public frmCellsAddRange()
		{
			InitializeComponent();
		}
		
		private void frmCellsAdd_Load(object sender, EventArgs e)
		{
			//  заполнение cbo-классификаторов 
			bool lResult = cboStoresZones_Restore() &&
							  cboStoresZonesTypes_Restore();
			if (!lResult)
			{
				RFMMessage.MessageBoxError("Ошибка при заполнении классификаторов (адрес ячейки)...");
				return;
			}

			//  заполнение существующих значений параметров адреса ячейки
			lResult =	cboCBuilding_Restore() &&
						cboCLine_Restore() &&
						cboCLevelBeg_Restore() && cboCLevelEnd_Restore() &&
						cboCRackBeg_Restore() && cboCRackEnd_Restore() &&
						cboCPlaceBeg_Restore() && cboCPlaceEnd_Restore();
			if (!lResult)
			{
				RFMMessage.MessageBoxError("Ошибка при заполнении существующих значений параметров адреса...");
				return;
			}
			cboCBuilding.SelectedIndex = -1;
			cboCLine.SelectedIndex = -1;
			cboCRackBeg.SelectedIndex = -1;
			cboCRackEnd.SelectedIndex = -1;
			cboCLevelEnd.SelectedIndex = -1;
			cboCLevelBeg.SelectedIndex = -1;
			cboCPlaceBeg.SelectedIndex = -1;
			cboCPlaceEnd.SelectedIndex = -1;
			cboStoresZones.SelectedIndex = -1;
			cboStoresZonesTypes.SelectedIndex = -1; 
			
			_bLoaded = true;
			cboStoresZonesTypes.Enabled = false;
		}

		private void cboStoresZones_SelectedIndexChanged(object sender, EventArgs e)
		{
			sStoreZonePrefix = sStoreZoneSuffix = sAddressMask = "";
			nBuildingLen = nLineLen = nRackLen = nLevelLen = nPlaceLen = 0;

			DataRow r = oStoreZone.MainTable.Rows.Find(cboStoresZones.SelectedValue);
			if (r != null)
			{
				cboStoresZonesTypes.SelectedValue = (int)r["StoreZoneTypeID"];
				sStoreZonePrefix = r["NamePrefix"].ToString();
				sStoreZoneSuffix = r["NameSuffix"].ToString();

				// длина и наличие составляющих адреса
				nBuildingLen = nLevelLen = nRackLen = nLevelLen = nPlaceLen = 0;
				if (Convert.IsDBNull(r["AddressMask"]) || r["AddressMask"].ToString() == "")
				{
					Setting oSet = new Setting();
					sAddressMask = oSet.FillVariable("cAddressMask");
					if (sAddressMask == "")
					{
						RFMMessage.MessageBoxError("Не определена маска адресов ячеек...");
						return;
					}
				}
				else
				{
					sAddressMask = r["AddressMask"].ToString();
				}
				nBuildingLen = RFMUtilities.Occurs(sAddressMask, "B");
				nLineLen = RFMUtilities.Occurs(sAddressMask, "L");
				nRackLen = RFMUtilities.Occurs(sAddressMask, "R");
				nLevelLen = RFMUtilities.Occurs(sAddressMask, "V");
				nPlaceLen = RFMUtilities.Occurs(sAddressMask, "C");
				string sChar = "";
				for (int i = 0; i < sAddressMask.Length; i++)
				{
					sChar = sAddressMask.Substring(i, 1);
					if (sChar.CompareTo("A") >= 0 && sChar.CompareTo("Z") <= 0 &&
						!"BLRVC".Contains(sChar))
					{
						RFMMessage.MessageBoxError("Неверная структура маски адресов: " + sAddressMask);
						return;
					}
				}
				if (nBuildingLen + nLineLen + nRackLen + nLevelLen + nPlaceLen == 0)
				{
					RFMMessage.MessageBoxError("Неверная структура маски адресов: " + sAddressMask);
					return;
				}
				AddressPartsEnabled();

				lblAddressMask.Text = sStoreZonePrefix + sAddressMask + sStoreZoneSuffix;
			}
			else
			{
				cboStoresZonesTypes.SelectedIndex = -1;
				sStoreZonePrefix = sStoreZoneSuffix = "";
				lblAddressMask.Text = "";
			}
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
			if (cboStoresZones.SelectedValue == null || cboStoresZones.SelectedIndex < 0)
			{
				RFMMessage.MessageBoxError("Не указана складская зона...");
				return;
			}
			int nStoreZoneID = (int)cboStoresZones.SelectedValue;

			string sCBuilding = txtCBuilding.Text.Trim();
			string sCLine = txtCLine.Text.Trim();
			string sCRackBeg = txtCRackBeg.Text.Trim();
			string sCRackEnd = txtCRackEnd.Text.Trim();
			string sCLevelBeg = txtCLevelBeg.Text.Trim();
			string sCLevelEnd = txtCLevelEnd.Text.Trim();
			string sCPlaceBeg = txtCPlaceBeg.Text.Trim();
			string sCPlaceEnd = txtCPlaceEnd.Text.Trim();

			if ( (nBuildingLen > 0 && sCBuilding.Length != nBuildingLen) || 
				  (nLineLen > 0 && sCLine.Length != nLineLen) ||
				  (nRackLen > 0 && (sCRackBeg.Length != nRackLen || sCRackEnd.Length != nRackLen)) ||
				  (nLevelLen > 0 && (sCLevelBeg.Length != nLevelLen || sCLevelEnd.Length != nLevelLen)) ||
				  (nPlaceLen > 0 && (sCPlaceBeg.Length != nPlaceLen || sCPlaceEnd.Length != nPlaceLen)) )
			{
				RFMMessage.MessageBoxError("Неверное указание составляющих адреса...");
				return;
			}

			if (nRackLen > 0)
			{
				if (sCRackBeg.Length != sCRackEnd.Length || sCRackBeg.CompareTo(sCRackEnd) > 0)
				{
					RFMMessage.MessageBoxError("Неверное указание начального и конечного стояка...");
					return;
				}
			}

			if (nLevelLen > 0)
			{
				if (sCLevelBeg.Length != sCLevelEnd.Length || sCLevelBeg.CompareTo(sCLevelEnd) > 0)
				{
					RFMMessage.MessageBoxError("Неверное указание начального и конечного уровня...");
					return;
				}
			}

			if (nPlaceLen > 0)
			{
				if (sCPlaceBeg.Length != sCPlaceEnd.Length || sCPlaceBeg.CompareTo(sCPlaceEnd) > 0)
				{
					RFMMessage.MessageBoxError("Неверное указание начального и конечного паллетоместа...");
					return;
				}
			}

			// здание, линия (буквы), стояк, уровень, место - по маске
			string sEmpty = "";
			if (nBuildingLen > 0)
			{
				if (sCBuilding.Length != nBuildingLen)
				{
					RFMMessage.MessageBoxError("Неверное указание здания (" + RFMUtilities.Declen(nBuildingLen, "символ", "символа", "символа") + ")...");
					return;
				}
			}

			char cA = Convert.ToChar("A");
			char cZ = Convert.ToChar("Z");
			char c0 = Convert.ToChar("0");
			char c9 = Convert.ToChar("9");

			if (nLineLen > 0)
			{
				if (sCLine.Length != nLineLen ||
					(sEmpty.PadRight(nLineLen, cA)).CompareTo(sCLine) > 0 ||
					sCLine.CompareTo(sEmpty.PadRight(nLineLen, cZ)) > 0)
				{
					RFMMessage.MessageBoxError("Неверное указание линии (" + RFMUtilities.Declen(nLineLen, "латинская заглавная буква", "литанские заглавные буквы", "латинских заглавных букв") + ")...");
					return;
				}
			}

			Int16 nX;
			if (nRackLen > 0)
			{
				if (sCRackBeg.Length != nRackLen || 
					!Int16.TryParse(sCRackBeg, out nX) || 
					nX < 1 ||
					nX > Convert.ToInt16(sEmpty.PadRight(nRackLen, c9)))
				{
					RFMMessage.MessageBoxError("Неверное указание начального стояка (" + nRackLen.ToString().Trim() + "-значное число: " +
						(sEmpty.PadRight(nRackLen - 1, c0)) + "1" + ".." + (sEmpty.PadRight(nRackLen, c9)) + ")...");
					return;
				}
				if (sCRackEnd.Length != nRackLen ||
					!Int16.TryParse(sCRackEnd, out nX) ||
					nX < 1 ||
					nX > Convert.ToInt16(sEmpty.PadRight(nRackLen, c9)))
				{
					RFMMessage.MessageBoxError("Неверное указание конечного стояка (" + nRackLen.ToString().Trim() + "-значное число: " +
						(sEmpty.PadRight(nRackLen - 1, c0)) + "1" + ".." + (sEmpty.PadRight(nRackLen, c9)) + ")...");
					return;
				}
			}

			if (nLevelLen > 0)
			{
				if (sCLevelBeg.Length != nLevelLen ||
					!Int16.TryParse(sCLevelBeg, out nX) ||
					nX < 1 ||
					nX > Convert.ToInt16(sEmpty.PadRight(nLevelLen, c9)))
				{
					RFMMessage.MessageBoxError("Неверное указание начального уровня (" + nLevelLen.ToString().Trim() + "-значное число: " +
						(sEmpty.PadRight(nLevelLen - 1, c0)) + "1" + ".." + (sEmpty.PadRight(nLevelLen, c9)) + ")...");
					return;
				}
				if (sCLevelEnd.Length != nLevelLen ||
					!Int16.TryParse(sCLevelEnd, out nX) ||
					nX < 1 ||
					nX > Convert.ToInt16(sEmpty.PadRight(nLevelLen, c9)))
				{
					RFMMessage.MessageBoxError("Неверное указание конечного уровня (" + nLevelLen.ToString().Trim() + "-значное число: " +
						(sEmpty.PadRight(nLevelLen - 1, c0)) + "1" + ".." + (sEmpty.PadRight(nLevelLen, c9)) + ")...");
					return;
				}
			}

			if (nPlaceLen > 0)
			{
				if (sCPlaceBeg.Length != nPlaceLen ||
					!Int16.TryParse(sCPlaceBeg, out nX) ||
					nX < 1 ||
					nX > Convert.ToInt16(sEmpty.PadRight(nPlaceLen, c9)))
				{
					RFMMessage.MessageBoxError("Неверное указание начальной ячейки (паллетоместа) на уровне (" + nPlaceLen.ToString().Trim() + "-значное число: " +
						(sEmpty.PadRight(nPlaceLen - 1, c0)) + "1" + ".." + (sEmpty.PadRight(nPlaceLen, c9)) + ")...");
					return;
				}
				if (sCPlaceEnd.Length != nPlaceLen ||
					!Int16.TryParse(sCPlaceEnd, out nX) ||
					nX < 1 ||
					nX > Convert.ToInt16(sEmpty.PadRight(nPlaceLen, c9)))
				{
					RFMMessage.MessageBoxError("Неверное указание конечной ячейки (паллетоместа) на уровне (" + nPlaceLen.ToString().Trim() + "-значное число: " +
						(sEmpty.PadRight(nPlaceLen - 1, c0)) + "1" + ".." + (sEmpty.PadRight(nPlaceLen, c9)) + ")...");
					return;
				}
			}

			bool bAddThrough = chkAddThrough.Checked;
			bool bAddHoleLine = chkAddHoleLine.Checked;
			bool bAddHole = chkAddHole.Checked;

			oCell.ClearError();

			if (RFMMessage.MessageBoxYesNo("Выполняется попытка добавления ячеек: \n" +
					((nBuildingLen > 0) ? ("Здание: " + sCBuilding + "\n") : "") +
					((nLineLen > 0) ? ("Линия: " + sCLine + "\n") : "") +
					((nRackLen > 0) ? ("Стояк: c " + sCRackBeg + " по " + sCRackEnd + "\n") : "") +
					((nLevelLen > 0) ? ("Уровень: c " + sCLevelBeg + " по " + sCLevelEnd + "\n") : "") +
					((nPlaceLen > 0) ? ("Паллетоместо: c " + sCPlaceBeg + " по " + sCPlaceEnd + "\n") : "") +
					"\n" +
					"Продолжить?") == DialogResult.Yes)
			{
				int nCnt = oCell.AddRange("TEST",
						sCBuilding, sCLine,
						sCRackBeg, sCRackEnd,
						sCLevelBeg, sCLevelEnd,
						sCPlaceBeg, sCPlaceEnd,
						nStoreZoneID,
						bAddThrough, bAddHoleLine, bAddHole);
				if (oCell.ErrorNumber == 0)
				{
					if (nCnt > 0)
					{
						if (RFMMessage.MessageBoxYesNo("Можно добавить " + RFMUtilities.Declen(nCnt, "ячейку", "ячейки", "ячеек") + ".\n" +
							"Выполнить добавление?") == DialogResult.Yes)
						{
							nCnt = oCell.AddRange("ADD",
												sCBuilding, sCLine,
												sCRackBeg, sCRackEnd,
												sCLevelBeg, sCLevelEnd,
												sCPlaceBeg, sCPlaceEnd,
												nStoreZoneID,
												bAddThrough, bAddHoleLine, bAddHole);
							if (oCell.ErrorNumber == 0)
							{
								if (nCnt > 0)
								{
									RFMMessage.MessageBoxInfo("Добавлено " + RFMUtilities.Declen(nCnt, "ячейка", "ячейки", "ячеек") + ".");
									RFMMessage.MessageBoxInfo("Не забудьте добавить и назначить буферную ячейку\n" + "для добавленных ячеек.");

								}
								else
									RFMMessage.MessageBoxInfo("Ячейки не были добавлены...");
							}
						}
					}
					else
						RFMMessage.MessageBoxError("Ячейки не могут быть добавлены...");
				}

				if (oCell.ErrorNumber == 0 && nCnt > 0)
				{
					DialogResult = DialogResult.Yes;
					Dispose();
				}
			}
		}
		
	#region Restore

		private bool cboStoresZones_Restore()
		{
			oStoreZone.FilterStoreZoneTypeForStorage = true;
			oStoreZone.FillData();
			/*
			DataTable dt = oStoreZone.MainTable.Copy();
			oStoreZone.ClearFilters();
			oStoreZone.FilterStoreZoneTypeShortCode = "PICK";
			oStoreZone.FillData();
			foreach (DataRow dr in dt.Rows)
				oStoreZone.MainTable.ImportRow(dr);
			dt.Clear();
			*/
			cboStoresZones.ValueMember   = oStoreZone.MainTable.Columns[0].Caption;
			cboStoresZones.DisplayMember = oStoreZone.MainTable.Columns[1].Caption;
			cboStoresZones.DataSource    = oStoreZone.MainTable;
			return (oStoreZone.ErrorNumber == 0);
		}

		private bool cboStoresZonesTypes_Restore()
		{
			oStoreZone.FilterStoreZoneTypeForStorage = true;
			oStoreZone.FillTableStoresZonesTypes(); 
			/*
			oStoreZone.FilterStoreZoneTypeShortCode = "PICK";
			oStoreZone.FillTableStoresZonesTypes();
			DataTable dt = oStoreZone.TableStoresZonesTypes.Copy();
			oStoreZone.FilterStoreZoneTypeShortCode = "STOR";
			oStoreZone.FillTableStoresZonesTypes();
			foreach (DataRow dr in dt.Rows)
				oStoreZone.TableStoresZonesTypes.ImportRow(dr);
			dt.Clear();
			*/
			cboStoresZonesTypes.ValueMember   = oStoreZone.TableStoresZonesTypes.Columns[0].Caption;
			cboStoresZonesTypes.DisplayMember = oStoreZone.TableStoresZonesTypes.Columns[1].Caption;
			cboStoresZonesTypes.DataSource    = oStoreZone.TableStoresZonesTypes;
			return (oStoreZone.ErrorNumber == 0);
		}

		private bool cboCBuilding_Restore()
		{
			oCell.FillAddressPartTables("CBuilding");
			cboCBuilding.ValueMember = oCell.TableAddressPartCBuilding.Columns[0].Caption;
			cboCBuilding.DisplayMember = oCell.TableAddressPartCBuilding.Columns[1].Caption;
			cboCBuilding.DataSource = oCell.TableAddressPartCBuilding;
			return (oCell.ErrorNumber == 0);
		}

		private bool cboCLine_Restore()
		{
			oCell.FillAddressPartTables("CLine");
			cboCLine.ValueMember = oCell.TableAddressPartCLine.Columns[0].Caption;
			cboCLine.DisplayMember = oCell.TableAddressPartCLine.Columns[1].Caption;
			cboCLine.DataSource = oCell.TableAddressPartCLine;
			return (oCell.ErrorNumber == 0);
		}

		private bool cboCRackBeg_Restore()
		{
			oCell.FillAddressPartTables("CRack");
			cboCRackBeg.ValueMember = oCell.TableAddressPartCRack.Columns[0].Caption;
			cboCRackBeg.DisplayMember = oCell.TableAddressPartCRack.Columns[1].Caption;
			cboCRackBeg.DataSource = new DataView(oCell.TableAddressPartCRack);
			return (oCell.ErrorNumber == 0);
		}
		private bool cboCRackEnd_Restore()
		{
			if (oCell.TableAddressPartCRack == null)
				oCell.FillAddressPartTables("CRack");
			cboCRackEnd.ValueMember = oCell.TableAddressPartCRack.Columns[0].Caption;
			cboCRackEnd.DisplayMember = oCell.TableAddressPartCRack.Columns[1].Caption;
			cboCRackEnd.DataSource = new DataView(oCell.TableAddressPartCRack);
			return (oCell.ErrorNumber == 0);
		}

		private bool cboCLevelBeg_Restore()
		{
			oCell.FillAddressPartTables("CLevel");
			cboCLevelBeg.ValueMember = oCell.TableAddressPartCLevel.Columns[0].Caption;
			cboCLevelBeg.DisplayMember = oCell.TableAddressPartCLevel.Columns[1].Caption;
			cboCLevelBeg.DataSource = new DataView(oCell.TableAddressPartCLevel);
			return (oCell.ErrorNumber == 0);
		}
		private bool cboCLevelEnd_Restore()
		{
			if (oCell.TableAddressPartCLevel == null)
				oCell.FillAddressPartTables("CLevel");
			cboCLevelEnd.ValueMember = oCell.TableAddressPartCLevel.Columns[0].Caption;
			cboCLevelEnd.DisplayMember = oCell.TableAddressPartCLevel.Columns[1].Caption;
			cboCLevelEnd.DataSource = new DataView(oCell.TableAddressPartCLevel);
			return (oCell.ErrorNumber == 0);
		}

		private bool cboCPlaceBeg_Restore()
		{
			oCell.FillAddressPartTables("CPlace");
			cboCPlaceBeg.ValueMember = oCell.TableAddressPartCPlace.Columns[0].Caption;
			cboCPlaceBeg.DisplayMember = oCell.TableAddressPartCPlace.Columns[1].Caption;
			cboCPlaceBeg.DataSource = new DataView(oCell.TableAddressPartCPlace);
			return (oCell.ErrorNumber == 0);
		}
		private bool cboCPlaceEnd_Restore()
		{
			if (oCell.TableAddressPartCPlace == null)
				oCell.FillAddressPartTables("CPlace");
			cboCPlaceEnd.ValueMember = oCell.TableAddressPartCPlace.Columns[0].Caption;
			cboCPlaceEnd.DisplayMember = oCell.TableAddressPartCPlace.Columns[1].Caption;
			cboCPlaceEnd.DataSource = new DataView(oCell.TableAddressPartCPlace);
			return (oCell.ErrorNumber == 0);
		}

	#endregion

	#region Установка конечных значений при изменении начальных, Upper для линии 
		
		private void cboCBuilding_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtCBuilding.Text = cboCBuilding.Text;
		}

		private void cboCLine_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtCLine.Text = cboCLine.Text;
		}

		private void cboCRackBeg_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtCRackBeg.Text = cboCRackBeg.Text;
			if (cboCRackBeg.SelectedValue != null && 
				(cboCRackEnd.SelectedIndex < 0 || (int)cboCRackEnd.SelectedValue < (int)cboCRackBeg.SelectedValue) )
				cboCRackEnd.SelectedValue = (int)cboCRackBeg.SelectedValue;
		}

		private void cboCRackEnd_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtCRackEnd.Text = cboCRackEnd.Text;
		}

		private void cboCLevelBeg_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtCLevelBeg.Text = cboCLevelBeg.Text;
			if (cboCLevelBeg.SelectedValue != null &&
				(cboCLevelEnd.SelectedIndex < 0 || (int)cboCLevelEnd.SelectedValue < (int)cboCLevelBeg.SelectedValue))
				cboCLevelEnd.SelectedValue = (int)cboCLevelBeg.SelectedValue;
		}

		private void cboCLevelEnd_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtCLevelEnd.Text = cboCLevelEnd.Text;
		}

		private void cboCPlaceBeg_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtCPlaceBeg.Text = cboCPlaceBeg.Text;
			if (cboCPlaceBeg.SelectedValue != null &&
				(cboCPlaceEnd.SelectedIndex < 0 || (int)cboCPlaceEnd.SelectedValue < (int)cboCPlaceBeg.SelectedValue))
				cboCPlaceEnd.SelectedValue = (int)cboCPlaceBeg.SelectedValue;
		}

		private void cboCPlaceEnd_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtCPlaceEnd.Text = cboCPlaceEnd.Text;
		}

		private void txtCLine_TextChanged(object sender, EventArgs e)
		{
			txtCLine.Text = txtCLine.Text.ToUpper();
		}

		private void AddressPartsEnabled()
		{
			if (nBuildingLen == 0)
			{
				cboCBuilding.Text = txtCBuilding.Text = "";
				cboCBuilding.Enabled = txtCBuilding.Enabled = false;
			}
			else
			{
				cboCBuilding.Enabled = txtCBuilding.Enabled = true;
				txtCBuilding.MaxLength = nBuildingLen;
			}

			if (nLineLen == 0)
			{
				cboCLine.Text = txtCLine.Text = "";
				cboCLine.Enabled = txtCLine.Enabled = false;
			}
			else
			{
				cboCLine.Enabled = txtCLine.Enabled = true;
				txtCLine.MaxLength = nLineLen;
			}

			if (nRackLen == 0)
			{
				cboCRackBeg.Text = txtCRackBeg.Text =
				cboCRackEnd.Text = txtCRackEnd.Text = "";
				cboCRackBeg.Enabled = txtCRackBeg.Enabled =
				cboCRackEnd.Enabled = txtCRackEnd.Enabled = false;
			}
			else
			{
				cboCRackBeg.Enabled = txtCRackBeg.Enabled =
				cboCRackEnd.Enabled = txtCRackEnd.Enabled = true;
				txtCRackBeg.MaxLength = txtCRackEnd.MaxLength = nRackLen;
			}

			if (nLevelLen == 0)
			{
				cboCLevelBeg.Text = txtCLevelBeg.Text =
				cboCLevelEnd.Text = txtCLevelEnd.Text = "";
				cboCLevelBeg.Enabled = txtCLevelBeg.Enabled =
				cboCLevelEnd.Enabled = txtCLevelEnd.Enabled = false;
			}
			else
			{
				cboCLevelBeg.Enabled = txtCLevelBeg.Enabled =
				cboCLevelEnd.Enabled = txtCLevelEnd.Enabled = true;
				txtCLevelBeg.MaxLength = txtCLevelEnd.MaxLength = nLevelLen;
			}

			if (nPlaceLen == 0)
			{
				cboCPlaceBeg.Text = txtCPlaceBeg.Text =
				cboCPlaceEnd.Text = txtCPlaceEnd.Text = "";
				cboCPlaceBeg.Enabled = txtCPlaceBeg.Enabled =
				cboCPlaceEnd.Enabled = txtCPlaceEnd.Enabled = false;
			}
			else
			{
				cboCPlaceBeg.Enabled = txtCPlaceBeg.Enabled =
				cboCPlaceEnd.Enabled = txtCPlaceEnd.Enabled = true;
				txtCPlaceBeg.MaxLength = txtCPlaceEnd.MaxLength = nPlaceLen;
			}
		}

	#endregion 


	}
}