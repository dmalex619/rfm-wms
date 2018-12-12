using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using RFMBaseClasses;
using RFMPublic;
using WMSBizObjects;

namespace WMSSuitable
{
	public partial class frmSalaryTariffsEdit : RFMFormChild
	{
		private int? nID;
		private SalaryExtraWork oSalaryTariff;

		public frmSalaryTariffsEdit(int? _nID)
		{
			if (_nID.HasValue)
				nID = (int)_nID;
			else
				nID = 0; 

			oSalaryTariff = new SalaryExtraWork();
			if (oSalaryTariff.ErrorNumber != 0)
			{
				IsValid = false;
			}

			if (IsValid)
			{
				InitializeComponent();
			}
		}

		private void frmSalaryTariffsEdit_Load (object sender, EventArgs e)
		{
			bool blResult = true;

			if (nID > 0)
			{
				// редактирование
				oSalaryTariff.FillTableSalaryTariffs(nID);
			}
			else
			{
				if (nID < 0)
				{
					// копирование
					oSalaryTariff.FillTableSalaryTariffs(-nID);
					oSalaryTariff.TableSalaryTariffs.Rows[0]["ID"] = 0;
					nID = 0;
				}
				else
				{
					//nID == 0)
					// новая запись
					oSalaryTariff.FillTableSalaryTariffs(0);
					oSalaryTariff.TableSalaryTariffs.Rows.Add();
					oSalaryTariff.TableSalaryTariffs.Rows[0]["ID"] = 0;
				}
			}

			if (oSalaryTariff.ErrorNumber != 0)
			{
				blResult = false;
			}

			if (blResult)
			{
				if (oSalaryTariff.TableSalaryTariffs.Rows.Count != 1)
				{
					RFMMessage.MessageBoxError("Ошибка при получении данных о тарифах...");
					blResult = false;
				}
			}

			if (blResult)
			{
				DataRow r = oSalaryTariff.TableSalaryTariffs.Rows[0];
				dtpDateBeg.Value = Convert.ToDateTime(r["DateBeg"]).Date;
				numInputsItemsRelative.Value = Convert.ToDecimal(r["InputsItemsRelative"]);
				numAccInputsOperations.Value = Convert.ToDecimal(r["AccInputsOperations"]);
				numMovesUpOperations.Value = Convert.ToDecimal(r["MovesUpOperations"]);
				numMovesDownOperations.Value = Convert.ToDecimal(r["MovesDownOperations"]);
				numMovesFloorOperations.Value = Convert.ToDecimal(r["MovesFloorOperations"]);
				numPickOutputsLines.Value = Convert.ToDecimal(r["PickOutputsLines"]);
				numPickOutputsBoxes.Value = Convert.ToDecimal(r["PickOutputsBoxes"]);
				numPickOutputsNetto.Value = Convert.ToDecimal(r["PickOutputsNetto"]);
				numOutputsLines.Value = Convert.ToDecimal(r["OutputsLines"]);
				numOutputsBoxes.Value = Convert.ToDecimal(r["OutputsBoxes"]);
				numOutputsNetto.Value = Convert.ToDecimal(r["OutputsNetto"]);
				numValidateOutputsLines.Value = Convert.ToDecimal(r["ValidateOutputsLines"]);
				numValidateOutputsBoxes.Value = Convert.ToDecimal(r["ValidateOutputsBoxes"]);
				numValidateOutputsNetto.Value = Convert.ToDecimal(r["ValidateOutputsNetto"]);
				numMovingsBoxes.Value = Convert.ToDecimal(r["MovingsBoxes"]);
				numInventoriesCells.Value = Convert.ToDecimal(r["InventoriesCells"]);
			}
			else
			{
				Dispose();
			}
		}
		
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
			// Проверить наличие записи на ту же дату
			DateTime dDate = dtpDateBeg.Value.Date;
			SalaryExtraWork oSalaryTemp = new SalaryExtraWork();
			oSalaryTemp.FillTableSalaryTariffs();
			foreach (DataRow sr in oSalaryTemp.TableSalaryTariffs.Rows)
			{ 
				DateTime dExistDate = Convert.ToDateTime(sr["DateBeg"]);
				if (dDate.CompareTo(dExistDate) == 0 &&
					(int)sr["ID"] != nID)
				{
					RFMMessage.MessageBoxError("Уже есть тарифы на указанную дату...");
					return;
				}
			}

			DataRow r = oSalaryTariff.TableSalaryTariffs.Rows[0];
			r["DateBeg"] = dDate;
			r["InputsItemsRelative"] = numInputsItemsRelative.Value;
			r["AccInputsOperations"] = numAccInputsOperations.Value;
			r["MovesUpOperations"] = numMovesUpOperations.Value;
			r["MovesDownOperations"] = numMovesDownOperations.Value;
			r["MovesFloorOperations"] = numMovesFloorOperations.Value;
			r["PickOutputsLines"] = numPickOutputsLines.Value;
			r["PickOutputsBoxes"] = numPickOutputsBoxes.Value;
			r["PickOutputsNetto"] = numPickOutputsNetto.Value;
			r["OutputsLines"] = numOutputsLines.Value;
			r["OutputsBoxes"] = numOutputsBoxes.Value;
			r["OutputsNetto"] = numOutputsNetto.Value;
			r["ValidateOutputsLines"] = numValidateOutputsLines.Value;
			r["ValidateOutputsBoxes"] = numValidateOutputsBoxes.Value;
			r["ValidateOutputsNetto"] = numValidateOutputsNetto.Value;
			r["MovingsBoxes"] = numMovingsBoxes.Value;
			r["InventoriesCells"] = numInventoriesCells.Value;
			r["UserID"] = ((RFMFormBase)Application.OpenForms[0]).UserInfo.UserID;

			oSalaryTariff.ClearError();
			oSalaryTariff.SaveTariffs(ref nID);
			if (oSalaryTariff.ErrorNumber == 0)
			{
				if (oSalaryTariff.ErrorNumber == 0 && nID > 0)
				{
					MotherForm.GotParam = new object[] { nID };
					DialogResult = DialogResult.Yes;
					Dispose();
				}
			}
		}
	}
}
