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
	public partial class frmCellsFixedChanges : RFMFormChild
	{
		private Cell oCellCur;
		private Cell oCellNew;
		private Good oPacking;

		int? nPackingID = null;
		int? nCellCurID = null;
		int? nCellNewID = null;

		int? nOwnerID = null;
		int? nGoodStateID = null;

		public int? _SelectedPackingID = null;
		public int? _SelectedCellID = null; 


		public frmCellsFixedChanges(int? _nPackingID, int? _nCellCurID)
		{
			oCellCur = new Cell();
			oCellNew = new Cell();
			oPacking = new Good();
			if (oCellCur.ErrorNumber != 0 ||
				oCellNew.ErrorNumber != 0 ||
				oPacking.ErrorNumber != 0)
			{
				IsValid = false;
			}

			if (IsValid)
			{
				nPackingID = _nPackingID;
				nCellCurID = _nCellCurID;

				InitializeComponent();
			}
		}

		private bool _PackingSelect(int _nPackingID)
		{ 
			oPacking.PackingID = (int)_nPackingID;
			oPacking.FillData();
			if (oPacking.ErrorNumber != 0 || oPacking.MainTable == null || oPacking.MainTable.Rows.Count != 1)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о товаре...");
				return (false);
			}
			txtPackingAlias.Text = oPacking.MainTable.Rows[0]["Alias"].ToString();
			return (true);
		}

		private bool _CellCurSelect(int _nCellCurID)
		{
			oCellCur.ID = (int)nCellCurID;
			oCellCur.FillData();
			if (oCellCur.ErrorNumber != 0 || oCellCur.MainTable == null || oCellCur.MainTable.Rows.Count != 1)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о текущей ячейке...");
				return (false);
			}

			DataRow c = oCellCur.MainTable.Rows[0];
			txtCellCurAddress.Text = c["Address"].ToString();
			txtStoreZoneCurName.Text = c["StoreZoneName"].ToString();

			// текущий товар
			if (!Convert.IsDBNull(c["FixedPackingID"]))
			{
				nPackingID = Convert.ToInt32(c["FixedPackingID"]);
				txtPackingAlias.Text = c["PackingAlias"].ToString();
				btnPackingChoose.Enabled = false;
			}
			if (!Convert.IsDBNull(c["FixedGoodStateID"]))
			{
				nGoodStateID = Convert.ToInt32(c["FixedGoodStateID"]);
				txtGoodStateName.Text = c["FixedGoodStateName"].ToString();
			}
			else
			{
				nGoodStateID = null;
				txtGoodStateName.Text = "";
			}
			if (!Convert.IsDBNull(c["FixedOwnerID"]))
			{
				nOwnerID = Convert.ToInt32(c["FixedOwnerID"]);
				txtOwnerName.Text = c["FixedOwnerName"].ToString();
			}
			else
			{
				nOwnerID = null;
				txtOwnerName.Text = "";
			}
			return (true);
		}

		private void frmCellsFixedChanges_Load(object sender, EventArgs e)
		{
			bool bResult = true;

			if (nPackingID.HasValue)
			{
				bResult = _PackingSelect((int)nPackingID);
				if (bResult)
				{
					btnPackingChoose.Enabled = false;
				}
			}

			if (bResult)
			{
				if (nCellCurID.HasValue)
				{
					bResult = _CellCurSelect((int)nCellCurID);
				}
			}

			if (!bResult)
			{
				Dispose();
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
			// ячейка выбрана?
			if (!nCellNewID.HasValue)
			{
				RFMMessage.MessageBoxError("Не выбрана ячейка...");
				return;
			}

			// товар?
			if (!nGoodStateID.HasValue)
			{
				RFMMessage.MessageBoxError("Не определено состояние товара...");
				return;
			}

			oCellCur.FixedChange((int)nCellCurID, (int)nCellNewID, 
				(int)nPackingID, (int)nGoodStateID, nOwnerID, 
				((RFMFormBase)Application.OpenForms[0]).UserInfo.UserID);
			if (oCellCur.ErrorNumber == 0)
			{
				DialogResult = DialogResult.Yes;
				Dispose();
			}
		}

		private void btnPackingChoose_Click(object sender, EventArgs e)
		{
			_SelectedPackingID = null;
			if (StartForm(new frmSelectOnePacking(this)) == DialogResult.Yes)
			{
				if (_SelectedPackingID != null)
				{
					nPackingID = (int)_SelectedPackingID;
					_PackingSelect((int)nPackingID); 
				}
			}
		}

		private void btnCellNewChoose_Click(object sender, EventArgs e)
		{
			nCellNewID = null;
			txtCellNewAddress.Text =
			txtStoreZoneNewName.Text =
				"";
			
			_SelectedCellID = null;

			if (StartForm(new frmSelectOneCell(this)) == DialogResult.Yes)
			{
				if (_SelectedCellID != null)
				{
					int nCellNewID_Temp = (int)_SelectedCellID;

					oCellNew.ID = (int)nCellNewID_Temp;
					oCellNew.FillData();
					if (oCellNew.ErrorNumber != 0 || oCellNew.MainTable == null || oCellNew.MainTable.Rows.Count != 1)
					{
						RFMMessage.MessageBoxError("Ошибка при получении данных о новой ячейке...");
						return;
					}

					if (nCellCurID.HasValue && nCellNewID_Temp == nCellCurID)
					{
						RFMMessage.MessageBoxError("Выбрана та же ячейка...");
						return;
					}

					DataRow c = oCellNew.MainTable.Rows[0];
					// проверки - можно ли сделать закрепление в эту ячейку?

					// 1. это подходящий тип ячейки?
					if (!Convert.ToBoolean(c["ForStorage"]) || !Convert.ToBoolean(c["ForPicking"]))
					{
						RFMMessage.MessageBoxError("Ячейка имеет другой тип...");
						return;
					}

					// 2.1. есть остаток?
					oCellNew.FillTableCellsContents(nCellNewID_Temp, false);
					if (oCellNew.ErrorNumber != 0)
					{
						RFMMessage.MessageBoxError("Ошибка при анализе наличия товаров в ячейке...");
						return;
					}

					foreach (DataRow cc in oCellNew.TableCellsContents.Rows)
					{
						if (Convert.ToDecimal(cc["Qnt"]) != 0)
						{
							RFMMessage.MessageBoxError("В ячейке имеется другой товар...");
							return;
						}
					}

					// 2.2. есть трафики в/из новой ячейки 
					TrafficFrame oTrafficFrameTemp = new TrafficFrame();
					oTrafficFrameTemp.FilterConfirmed = false;

					oTrafficFrameTemp.FilterCellsTargetList = nCellNewID_Temp.ToString();
					oTrafficFrameTemp.FillData();
					if (oTrafficFrameTemp.ErrorNumber != 0)
					{
						RFMMessage.MessageBoxError("Ошибка при анализе наличия транспортировок поддонов в ячейку...");
						return;
					}
					if (oTrafficFrameTemp.MainTable.Rows.Count > 0)
					{
						RFMMessage.MessageBoxError("Есть невыполненные транспортировки поддонов в ячейку...");
						return;
					}

					oTrafficFrameTemp.FilterCellsTargetList = null;
					oTrafficFrameTemp.FilterCellsSourceList = nCellNewID_Temp.ToString();
					oTrafficFrameTemp.FillData();
					if (oTrafficFrameTemp.ErrorNumber != 0)
					{
						RFMMessage.MessageBoxError("Ошибка при анализе наличия транспортировок поддонов из ячейки...");
						return;
					}
					if (oTrafficFrameTemp.MainTable.Rows.Count > 0)
					{
						RFMMessage.MessageBoxError("Есть невыполненные транспортировки поддонов из ячейки...");
						return;
					}


					TrafficGood oTrafficGoodTemp = new TrafficGood();
					oTrafficGoodTemp.FilterConfirmed = false;

					oTrafficGoodTemp.FilterCellsTargetList = nCellNewID_Temp.ToString();
					oTrafficGoodTemp.FillData();
					if (oTrafficGoodTemp.ErrorNumber != 0)
					{
						RFMMessage.MessageBoxError("Ошибка при анализе наличия перемещений коробок в ячейку...");
						return;
					}
					if (oTrafficGoodTemp.MainTable.Rows.Count > 0)
					{
						RFMMessage.MessageBoxError("Есть невыполненные перемещения коробок в ячейку...");
						return;
					}

					oTrafficGoodTemp.FilterCellsTargetList = null;
					oTrafficGoodTemp.FilterCellsSourceList = nCellNewID_Temp.ToString();
					oTrafficGoodTemp.FillData();
					if (oTrafficGoodTemp.ErrorNumber != 0)
					{
						RFMMessage.MessageBoxError("Ошибка при анализе наличия перемещений коробок из ячейки...");
						return;
					}
					if (oTrafficGoodTemp.MainTable.Rows.Count > 0)
					{
						RFMMessage.MessageBoxError("Есть невыполненные перемещения коробок из ячейки...");
						return;
					}

					// 2. товар
					if (!Convert.IsDBNull(c["FixedPackingID"]))
					{
						int nPackingTempID = Convert.ToInt32(c["FixedPackingID"]);
						if (nPackingTempID == nPackingID)
						{
							RFMMessage.MessageBoxError("Ячейка уже закреплена за этим товаром...");
							return;
						}

						else
						{
							// ячейка закреплена за другим товаром
							if (RFMMessage.MessageBoxYesNo("Новая ячейка закреплена за другим товаром\n(" + c["PackingAlias"].ToString() + ").\n\n" +
									"Продолжить?") != DialogResult.Yes)
								return;
						}
					}

					// новая ячейка пуста и по всем отношениям нам подходит

					// спросим еще про остатки и трафики в/из текущей ячейки, если есть
					// (DateAccept проверим уже в хр_пр)
					oCellCur.FillTableCellsContents((int)nCellCurID, false);
					if (oCellCur.ErrorNumber != 0)
					{
						RFMMessage.MessageBoxError("Ошибка при анализе наличия товаров в текущей ячейке...");
						return;
					}

					foreach (DataRow cc in oCellCur.TableCellsContents.Rows)
					{
						if (Convert.ToDecimal(cc["Qnt"]) != 0)
						{
							if (RFMMessage.MessageBoxYesNo("В текущей ячейке имеется товар.\n" +
									"Весь он будет переведен в новую ячейку.\n\nПродолжить?") != DialogResult.Yes)
								return;
						}
					}


					TrafficFrame oTrafficFrameCur = new TrafficFrame();
					oTrafficFrameCur.FilterConfirmed = false;

					oTrafficFrameCur.FilterCellsTargetList = nCellCurID.ToString();
					oTrafficFrameCur.FillData();
					if (oTrafficFrameCur.ErrorNumber != 0)
					{
						RFMMessage.MessageBoxError("Ошибка при анализе наличия транспортировок поддонов в текущую ячейку...");
						return;
					}
					if (oTrafficFrameCur.MainTable.Rows.Count > 0)
					{
						if (RFMMessage.MessageBoxYesNo("Есть невыполненные транспортировки поддонов в текущую ячейку.\n" + 
								"Все они будут переведены в новую ячейку.\n\nПродолжить?") != DialogResult.Yes)
							return;
					}

					oTrafficFrameCur.FilterCellsTargetList = null; 
					oTrafficFrameCur.FilterCellsSourceList = nCellCurID.ToString();
					oTrafficFrameCur.FillData();
					if (oTrafficFrameCur.ErrorNumber != 0)
					{
						RFMMessage.MessageBoxError("Ошибка при анализе наличия транспортировок поддонов из текущей ячейки...");
						return;
					}
					if (oTrafficFrameCur.MainTable.Rows.Count > 0)
					{
						if (RFMMessage.MessageBoxYesNo("Есть невыполненные транспортировки поддонов из текущей ячейки.\n" + 
								"Все они будут переведены в новую ячейку.\n\nПродолжить?") != DialogResult.Yes)
							return;
					}


					TrafficGood oTrafficGoodCur = new TrafficGood();
					oTrafficGoodCur.FilterConfirmed = false;

					oTrafficGoodCur.FilterCellsTargetList = nCellCurID.ToString();
					oTrafficGoodCur.FillData();
					if (oTrafficGoodCur.ErrorNumber != 0)
					{
						RFMMessage.MessageBoxError("Ошибка при анализе наличия перемещений коробок в текущую ячейку...");
						return;
					}
					if (oTrafficGoodCur.MainTable.Rows.Count > 0)
					{
						if (RFMMessage.MessageBoxYesNo("Есть невыполненные перемещения коробок в текущую ячейку.\n" +
								"Все они будут переведены в новую ячейку.\n\nПродолжить?") != DialogResult.Yes)
							return;
					}

					oTrafficGoodCur.FilterCellsTargetList = null;
					oTrafficGoodCur.FilterCellsSourceList = nCellCurID.ToString();
					oTrafficGoodCur.FillData();
					if (oTrafficGoodCur.ErrorNumber != 0)
					{
						RFMMessage.MessageBoxError("Ошибка при анализе наличия перемещений коробок из ячейки...");
						return;
					}
					if (oTrafficGoodCur.MainTable.Rows.Count > 0)
					{
						if (RFMMessage.MessageBoxYesNo("Есть невыполненные перемещения коробок из текущей ячейки.\n" +
								"Все они будут переведены в новую ячейку.\n\nПродолжить?") != DialogResult.Yes)
							return;
					}
					
					// OwnerID? GoodStateID?

					nCellNewID = (int)nCellNewID_Temp;
					oCellNew.ID = nCellNewID;

					txtCellNewAddress.Text = c["Address"].ToString();
					txtStoreZoneNewName.Text = c["StoreZoneName"].ToString();

				}
			}
		}



	}
}