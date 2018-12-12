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
	public partial class frmCellsAddressEdit : RFMFormChild
	{
		private Cell oCell = new Cell();
		
		private StoreZone oStoreZone = new StoreZone();
		protected string sStoreZonePrefix = "";
		protected string sStoreZoneSuffix = "";
		protected string sAddressMask = "";
		protected int nAddressLen = 10; // max допустимая длина адреса
		protected int nBuildingLen, nLineLen, nRackLen, nLevelLen, nPlaceLen;

		protected bool _bLoaded = false; 


		public frmCellsAddressEdit(Cell oCellAddress)
		{
			InitializeComponent();

			oCell = oCellAddress;
		}
		
		private void frmCellsAddressEdit_Load(object sender, EventArgs e)
		{
			Setting s = new Setting();
			Int32.TryParse(s.FillVariable("CellAddressMaxLength"), out nAddressLen);
			if (nAddressLen <= 0)
				nAddressLen = 10;

			//  заполнение cbo-классификаторов 
			bool lResult = cboStoresZones_Restore() &&
							  cboStoresZonesTypes_Restore();
			if (!lResult)
			{
				RFMMessage.MessageBoxError("Ошибка при заполнении классификаторов (адрес ячейки)...");
				return;
			}

			lResult = cboCBuilding_Restore() &&
						cboCLine_Restore() &&
						cboCLevel_Restore() &&
						cboCRack_Restore() &&
						cboCPlace_Restore();
			if (!lResult)
			{
				RFMMessage.MessageBoxError("Ошибка при заполнении существующих значений параметров адреса...");
				return;
			}

			// заполнение формы данными (одна ячейка)
			DataRow r = oCell.MainTable.Rows[0];
			if (r == null)
			{
				RFMMessage.MessageBoxError("Не найдена запись для ячейки с кодом " + r["ID"].ToString() + " в таблице ячеек...");
				return;
			}

			lblAddressMask.Text = "";

			cboStoresZones.SelectedValue = (int)r["StoreZoneID"];
			cboStoresZonesTypes.SelectedValue = (int)r["StoreZoneTypeID"];

			txtBarCode.Text     = r["BarCode"].ToString();
			txtCellID.Text		= r["ID"].ToString(); 

			cboCBuilding.Text   = r["CBuilding"].ToString(); 
			cboCLine.Text       = r["CLine"].ToString();
			cboCRack.Text       = r["CRack"].ToString();
			cboCLevel.Text      = r["CLevel"].ToString();
			cboCPlace.Text      = r["CPlace"].ToString();
			txtAddress.Text     = r["Address"].ToString();
			txtAddress.Enabled = false;
			
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
				if (Convert.IsDBNull(r["AddressMask"]) || r["AddressMask"].ToString() == "")
				{
					// если маска адресов ячеек не указана: 
					// для массовых ячеек - по умолчальной маске, для одиночных - без маски
					if (!Convert.IsDBNull(r["ForStorage"]) && Convert.ToBoolean(r["ForStorage"]))
					{
						Setting oSet = new Setting();
						sAddressMask = oSet.FillVariable("cAddressMask");
						if (sAddressMask == "")
						{
							RFMMessage.MessageBoxError("Не определена маска адресов ячеек...");
							return;
						}
					}
				}
				else
				{
					sAddressMask = r["AddressMask"].ToString();
				}
				if (sAddressMask.Length > 0)
				{
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
							RFMMessage.MessageBoxError("Неверная структура маски адреса: " + sAddressMask);
							return;
						}
					}
					if (nBuildingLen + nLineLen + nRackLen + nLevelLen + nPlaceLen == 0)
					{
						RFMMessage.MessageBoxError("Неверная структура маски адреса: " + sAddressMask);
						return;
					}
					lblAddressMask.Text = sStoreZonePrefix + sAddressMask + sStoreZoneSuffix;
				}
				AddressPartsEnabled();
			}
			else
			{
				cboStoresZonesTypes.SelectedIndex = -1;
				sStoreZonePrefix = sStoreZoneSuffix = "";
				lblAddressMask.Text = "";
			}
			btnAddressBuild_Click(null, null);
		}

		private void chkAddressManual_CheckedChanged(object sender, EventArgs e)
		{
			txtAddress.Enabled = chkAddressManual.Checked;
		}

		private void btnAddressBuild_Click(object sender, EventArgs e)
		{
			/*
			txtAddress.Text =
				sStoreZonePrefix +
				txtCBuilding.Text.Trim() +
				txtCLine.Text.Trim() +
				txtCRack.Text.Trim() +
				txtCLevel.Text.Trim() +
				txtCPlace.Text.Trim() +
				sStoreZoneSuffix;
			*/
			if (sAddressMask.Length > 0)
			{
				string sAddress = "";
				int nAt = 0;
				sAddress = sAddressMask;
				if (nBuildingLen > 0)
				{
					nAt = sAddressMask.IndexOf("B");
					if (nAt >= 0)
					{
						sAddress = sAddress.Substring(0, nAt) + txtCBuilding.Text.Trim().PadRight(nBuildingLen, ' ') + sAddress.Substring(nAt + nBuildingLen);
					}
				}
				if (nLineLen > 0)
				{
					nAt = sAddressMask.IndexOf("L");
					if (nAt >= 0)
					{
						sAddress = sAddress.Substring(0, nAt) + txtCLine.Text.Trim().PadRight(nLineLen, ' ') + sAddress.Substring(nAt + nLineLen);
					}
				}
				if (nRackLen > 0)
				{
					nAt = sAddressMask.IndexOf("R");
					if (nAt >= 0)
					{
						sAddress = sAddress.Substring(0, nAt) + txtCRack.Text.Trim().PadRight(nRackLen, ' ') + sAddress.Substring(nAt + nRackLen);
					}
				}
				if (nLevelLen > 0)
				{
					nAt = sAddressMask.IndexOf("V");
					if (nAt >= 0)
					{
						sAddress = sAddress.Substring(0, nAt) + txtCLevel.Text.Trim().PadRight(nLevelLen, ' ') + sAddress.Substring(nAt + nLevelLen);
					}
				}
				if (nPlaceLen > 0)
				{
					nAt = sAddressMask.IndexOf("C");
					if (nAt >= 0)
					{
						sAddress = sAddress.Substring(0, nAt) + txtCPlace.Text.Trim().PadRight(nPlaceLen, ' ') + sAddress.Substring(nAt + nPlaceLen);
					}
				}
				sAddress = sAddress.Replace(" ", "");
				/*
				string sAddress = "", sEmpty = "";
				sAddress = sAddressMask;
				if (nBuildingLen > 0)
				{
					sAddress = sAddress.Replace(sEmpty.PadRight(nBuildingLen, Convert.ToChar("B")), txtCBuilding.Text.Trim());
				}
				if (nLineLen > 0)
				{
					sAddress = sAddress.Replace(sEmpty.PadRight(nLineLen, Convert.ToChar("L")), txtCLine.Text.Trim());
				}
				if (nRackLen > 0)
				{
					sAddress = sAddress.Replace(sEmpty.PadRight(nRackLen, Convert.ToChar("R")), txtCRack.Text.Trim());
				}
				if (nLevelLen > 0)
				{
					sAddress = sAddress.Replace(sEmpty.PadRight(nLevelLen, Convert.ToChar("V")), txtCLevel.Text.Trim());
				}
				if (nPlaceLen > 0)
				{
					sAddress = sAddress.Replace(sEmpty.PadRight(nPlaceLen, Convert.ToChar("C")), txtCPlace.Text.Trim());
				}
				*/
				txtAddress.Text =
					sStoreZonePrefix +
					sAddress + 
					sStoreZoneSuffix;
			}
			else
			{
				txtAddress.Text =
					sStoreZonePrefix +
					txtCBuilding.Text.Trim() +
					txtCLine.Text.Trim() +
					txtCRack.Text.Trim() +
					txtCLevel.Text.Trim() +
					txtCPlace.Text.Trim() +
					sStoreZoneSuffix;
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
			DataRow rx = oCell.MainTable.Rows[0];

			if (cboStoresZones.SelectedValue == null || cboStoresZones.SelectedIndex < 0)
			{
				RFMMessage.MessageBoxError("Не указана складская зона...");
				return;
			}
			int nStoreZoneID = (int)cboStoresZones.SelectedValue;

			string sAddress = txtAddress.Text.Trim();
			if (sAddress.Length == 0)
			{
				RFMMessage.MessageBoxError("Не указан адрес ячейки...");
				return;
			}

			// длина адреса
			if (sAddress.Length > nAddressLen)
			{
				RFMMessage.MessageBoxError("Слишком длинный адрес ячейки...");
				return;
			}

			// допустимые символы (для печати штрих-кода)
			string cCharsAvailable =
				"0123456789" +
				".:-=" +
				"ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
				"abcdefghijklmnopqrstuvwxyz";
			for (int i = 0; i < sAddress.Length; i++)
			{
				string c = sAddress.Substring(i, 1);
				if (!cCharsAvailable.Contains(c))
				{
					RFMMessage.MessageBoxError("Неверный символ в адресе ячейки: " + c + "\nДля адреса опустимы только латинские буквы и цифры.");
					return;
				}
			}

			// не исправили ли руками префикс-суффикс
			if (sStoreZonePrefix.Length > 0 && sAddress.Substring(0, sStoreZonePrefix.Length) != sStoreZonePrefix)
			{
				RFMMessage.MessageBoxError("Неверное начало адреса ячейки.\nДолжно быть: " + sStoreZonePrefix);
				return;
			}
			if (sStoreZoneSuffix.Length > 0 && sAddress.Substring(sAddress.Length - sStoreZoneSuffix.Length) != sStoreZoneSuffix)
			{
				RFMMessage.MessageBoxError("Неверное окончание адреса ячейки.\nДолжно быть: " + sStoreZoneSuffix);
				return;
			}

			string sCBuilding = txtCBuilding.Text.Trim();
			string sCLine = txtCLine.Text.Trim();
			string sCRack = txtCRack.Text.Trim();
			string sCLevel = txtCLevel.Text.Trim();
			string sCPlace = txtCPlace.Text.Trim();

			if (sCBuilding.Length == 0 &&
				sCLine.Length == 0 &&
				sCRack.Length == 0 &&
				sCLevel.Length == 0 &&
				sCPlace.Length == 0)
			{
				if (RFMMessage.MessageBoxYesNo("Не указана ни одна составляющая адреса...\nВсе-таки сохранить?") != DialogResult.Yes)
					return;
			}

			if (sAddressMask.Length > 0)
			{
				// указаны ли все нужные составляющие адреса и какая у них длина?
				if ((nBuildingLen > 0 && sCBuilding.Length != nBuildingLen) ||
					  (nLineLen > 0 && sCLine.Length != nLineLen) ||
					  (nRackLen > 0 && sCRack.Length != nRackLen) ||
					  (nLevelLen > 0 && sCLevel.Length != nLevelLen) ||
					  (nPlaceLen > 0 && sCPlace.Length != nPlaceLen))
				{
					RFMMessage.MessageBoxError("Неверное указание составляющих адреса...");
					return;
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
					if (sCRack.Length != nRackLen ||
						!Int16.TryParse(sCRack, out nX) ||
						nX < 1 ||
						nX > Convert.ToInt16(sEmpty.PadRight(nRackLen, c9)))
					{
						RFMMessage.MessageBoxError("Неверное указание стояка (" + nRackLen.ToString().Trim() + "-значное число: " +
							(sEmpty.PadRight(nRackLen - 1, c0)) + "1" + ".." + (sEmpty.PadRight(nRackLen, c9)) + ")...");
						return;
					}
				}

				if (nLevelLen > 0)
				{
					if (sCLevel.Length != nLevelLen ||
						!Int16.TryParse(sCLevel, out nX) ||
						nX < 1 ||
						nX > Convert.ToInt16(sEmpty.PadRight(nLevelLen, c9)))
					{
						RFMMessage.MessageBoxError("Неверное указание уровня (" + nLevelLen.ToString().Trim() + "-значное число: " +
							(sEmpty.PadRight(nLevelLen - 1, c0)) + "1" + ".." + (sEmpty.PadRight(nLevelLen, c9)) + ")...");
						return;
					}
				}

				if (nPlaceLen > 0)
				{
					if (sCPlace.Length != nPlaceLen ||
						!Int16.TryParse(sCPlace, out nX) ||
						nX < 1 ||
						nX > Convert.ToInt16(sEmpty.PadRight(nPlaceLen, c9)))
					{
						RFMMessage.MessageBoxError("Неверное указание ячейки (паллетоместа) на уровне (" + nPlaceLen.ToString().Trim() + "-значное число: " +
							(sEmpty.PadRight(nPlaceLen - 1, c0)) + "1" + ".." + (sEmpty.PadRight(nPlaceLen, c9)) + ")...");
						return;
					}
				}
			}

			// * собственно сохранение *
			oCell.ClearError();

			rx["StoreZoneID"] = nStoreZoneID;
			rx["Address"] = sAddress;
			rx["CBuilding"] = sCBuilding;
			rx["CLine"] = sCLine;
			rx["CRack"] = sCRack;
			rx["CLevel"] = sCLevel;
			rx["CPlace"] = sCPlace;

			oCell.AddressSave((int)rx["ID"]);
			
			if (oCell.ErrorNumber == 0)
			{
				DialogResult = DialogResult.Yes;
				Dispose();
			}
		}
		
	#region Restore

		private bool cboStoresZones_Restore()
		{
			oStoreZone.FillData(); 
			cboStoresZones.ValueMember   = oStoreZone.MainTable.Columns[0].Caption;
			cboStoresZones.DisplayMember = oStoreZone.MainTable.Columns[1].Caption;
			cboStoresZones.DataSource    = oStoreZone.MainTable;
			return (oStoreZone.ErrorNumber == 0);
		}

		private bool cboStoresZonesTypes_Restore()
		{
			oStoreZone.FillTableStoresZonesTypes(); 
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
		private bool cboCRack_Restore()
		{
			oCell.FillAddressPartTables("CRack");
			cboCRack.ValueMember = oCell.TableAddressPartCRack.Columns[0].Caption;
			cboCRack.DisplayMember = oCell.TableAddressPartCRack.Columns[1].Caption;
			cboCRack.DataSource = new DataView(oCell.TableAddressPartCRack);
			return (oCell.ErrorNumber == 0);
		}
		private bool cboCLevel_Restore()
		{
			oCell.FillAddressPartTables("CLevel");
			cboCLevel.ValueMember = oCell.TableAddressPartCLevel.Columns[0].Caption;
			cboCLevel.DisplayMember = oCell.TableAddressPartCLevel.Columns[1].Caption;
			cboCLevel.DataSource = new DataView(oCell.TableAddressPartCLevel);
			return (oCell.ErrorNumber == 0);
		}
		private bool cboCPlace_Restore()
		{
			oCell.FillAddressPartTables("CPlace");
			cboCPlace.ValueMember = oCell.TableAddressPartCPlace.Columns[0].Caption;
			cboCPlace.DisplayMember = oCell.TableAddressPartCPlace.Columns[1].Caption;
			cboCPlace.DataSource = new DataView(oCell.TableAddressPartCPlace);
			return (oCell.ErrorNumber == 0);
		}

	#endregion

	#region Составляющие адреса

		private void cboCBuilding_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtCBuilding.Text = cboCBuilding.Text;
		}

		private void cboCLine_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtCLine.Text = cboCLine.Text;
		}

		private void cboCRack_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtCRack.Text = cboCRack.Text;
		}

		private void cboCLevel_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtCLevel.Text = cboCLevel.Text;
		}

		private void cboCPlace_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtCPlace.Text = cboCPlace.Text;
		}

		private void txtCField_TextChanged(object sender, EventArgs e)
		{
			RFMTextBox s = (RFMTextBox)sender;
			if (s.Name.ToUpper().Contains("LINE"))
				s.Text = s.Text.ToUpper();

			btnAddressBuild_Click(null, null);
		}

		private void AddressPartsEnabled()
		{
			if (sAddressMask.Length > 0)
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
					cboCRack.Text = txtCRack.Text = "";
					cboCRack.Enabled = txtCRack.Enabled = false;
				}
				else
				{
					cboCRack.Enabled = txtCRack.Enabled = true;
					txtCRack.MaxLength = nRackLen;
				}

				if (nLevelLen == 0)
				{
					cboCLevel.Text = txtCLevel.Text = "";
					cboCLevel.Enabled = txtCLevel.Enabled = false;
				}
				else
				{
					cboCLevel.Enabled = txtCLevel.Enabled = true;
					txtCLevel.MaxLength = nLevelLen;
				}

				if (nPlaceLen == 0)
				{
					cboCPlace.Text = txtCPlace.Text = "";
					cboCPlace.Enabled = txtCPlace.Enabled = false;
				}
				else
				{
					cboCPlace.Enabled = txtCPlace.Enabled = true;
					txtCPlace.MaxLength = nPlaceLen;
				}
			}
			else
			{
				cboCBuilding.Enabled = txtCBuilding.Enabled = 
				cboCLine.Enabled = txtCLine.Enabled = 
				cboCRack.Enabled = txtCRack.Enabled =
				cboCLevel.Enabled = txtCLevel.Enabled =
				cboCPlace.Enabled = txtCPlace.Enabled = true;
				txtCBuilding.MaxLength = 10;
				txtCLine.MaxLength = 10;
				txtCRack.MaxLength = 10;
				txtCLevel.MaxLength = 10;
				txtCPlace.MaxLength = 10;
			}
		}

	#endregion

	}
}