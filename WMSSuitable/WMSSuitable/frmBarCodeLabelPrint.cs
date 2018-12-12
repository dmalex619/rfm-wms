using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using RFMBaseClasses;
using WMSBizObjects;
using RFMPublic; 

namespace WMSSuitable
{
	public partial class frmBarCodeLabelPrint : RFMFormChild
	{

		private Form parentForm;
		private DataTable dataTable;
		private string sType;
		private string sPrinterNamePrefer;

		private BarCodeLabel oBarCodeLabel = new BarCodeLabel();
		private Printer oPrinter = new Printer();

		public frmBarCodeLabelPrint(Form _parentForm, DataTable _dataTable)
		{
			InitializeComponent();

			parentForm = _parentForm;
			dataTable = _dataTable;
		}

		public frmBarCodeLabelPrint(Form _parentForm, DataTable _dataTable, string _sType)
			: this(_parentForm, _dataTable)
		{
			sType = _sType;
		}

		public frmBarCodeLabelPrint(Form _parentForm, DataTable _dataTable, string _sType, string _sPrinterNamePrefer)
			: this(_parentForm, _dataTable, _sType)
		{
			sPrinterNamePrefer = _sPrinterNamePrefer;
		}

		private void frmBarCodeLabelPrint_Load(object sender, EventArgs e)
		{
			WaitOn(this);
			if (!(cboBarCodeLabels_Restore() && cboPrinters_Restore()))
			{
				WaitOff(this);
				RFMMessage.MessageBoxError("Ошибка при загрузке данных для печати...");
				Dispose();
			}
			WaitOff(this);

			switch (oBarCodeLabel.MainTable.Rows.Count)
			{
				case 0:
					RFMMessage.MessageBoxError("Нет подходящих шаблонов этикеток...");
					Dispose();
					break;
				case 1:
					cboBarCodeLabels.Enabled = false;
					break;
				default:
					break;
			}

			switch (oPrinter.MainTable.Rows.Count)
			{
				case 0:
					RFMMessage.MessageBoxError("Нет доступных принтеров...");
					Dispose();
					break;
				case 1:
					cboPrinters.Enabled = false;
					break;
				default:
					// пробуем найти предпочтительный принтер
					for (int i = 0; i < oPrinter.MainTable.Rows.Count; i++)
					{
						DataRow r = oPrinter.MainTable.Rows[i];
						if (r["Name"].ToString().ToUpper().Contains(sPrinterNamePrefer.ToUpper()))
						{
							cboPrinters.SelectedIndex = i;
							break;
						}
					}
					break;
			}
		}

		private void btnPrint_Click(object sender, EventArgs e)
		{
			// выбранная этикетка
			if (cboBarCodeLabels.SelectedValue == null || cboBarCodeLabels.SelectedIndex < 0)
			{
				RFMMessage.MessageBoxError("Не выбран шаблон этикетки...");
				return;
			}

			// выбранный принтер
			if (cboPrinters.SelectedValue == null || cboPrinters.SelectedIndex < 0)
			{
				RFMMessage.MessageBoxError("Не выбран принтер...");
				return;
			}

			DataRow rLabel = oBarCodeLabel.MainTable.Rows.Find((int)cboBarCodeLabels.SelectedValue);
			if (rLabel == null)
				return;

			DataRow rPrinter = oPrinter.MainTable.Rows.Find((int)cboPrinters.SelectedValue);
			if (rPrinter == null)
				return;

			// разбираем строку-описание шаблона этикетки
			int nCopies = Convert.ToInt32(numCopies.Value); 
			if (nCopies == 0)
				nCopies = 1;
			bool bInvert = (bool)rLabel["InvertLabel"];
			string sData = rLabel["Data"].ToString();
			string sNormalOrientationTemplate = rLabel["NormalOrientationTemplate"].ToString();
			string sInvertOrientationTemplate = rLabel["InvertOrientationTemplate"].ToString();

			string sEol = Convert.ToChar(13).ToString() + Convert.ToChar(10).ToString();
			string sOutputString = rLabel["Template"].ToString() + sEol;
			string sDataTemp = "";

			int i = 0;
			foreach (DataRow r in dataTable.Rows)
			{ 
				i++;
				// для каждой ячейки делаем добавляем строки данных
				sDataTemp = sData;
				if (sDataTemp.Contains("##InvertLabel##"))
				{
					sDataTemp = sDataTemp.Replace("##InvertLabel##", (bInvert && i%2 == 0) ? sInvertOrientationTemplate : sNormalOrientationTemplate);
				}
				if (sDataTemp.Contains("##Copies##"))
				{
					sDataTemp = sDataTemp.Replace("##Copies##", nCopies.ToString());
				}

				string sDelimiter = "#";
				string sField = "";
				while (sDataTemp.Contains("#"))
				{
					sField = GetField(sDataTemp, sDelimiter);
					if (sField.Length > 0)
					{
						try
						{
							DataColumn col = dataTable.Columns[sField];
							if (col != null)
							{
								sDataTemp = SetField(sDataTemp, sDelimiter, sField, r[sField].ToString());
							}
							else
							{
								sDataTemp = SetField(sDataTemp, sDelimiter, sField, "");
							}
						}
						catch (Exception)
						{
							sDataTemp = SetField(sDataTemp, sDelimiter, sField, "");
						}
					}
					else
					{
						break;
					}
				}

				sOutputString = sOutputString + sDataTemp + sEol; 
			}
			sOutputString = sOutputString + Convert.ToChar(12);

			// сохраняем полученную строку в файл
			string sFileName = ((RFMFormMain)Application.OpenForms[0]).UserInfo.UserLocPath;
			if (!Directory.Exists(sFileName))
			{
				sFileName = Path.GetTempPath();
			}
			sFileName += sType + "_BCLabel.txt";
			if (File.Exists(sFileName)) 
				File.Delete(sFileName);
			FileStream fs = new FileStream(sFileName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
			fs.Close();
			if (File.Exists(sFileName))
			{
				using (StreamWriter sw = new StreamWriter(sFileName, true, System.Text.Encoding.Default))
				{
					sw.Write(sOutputString);
					sw.Flush();
					sw.Close();
				}

				// получаем имя принтера, на который будем копировать файл
				string sPrinter = "";
				if ((bool)rPrinter["Network"])
				{
					sPrinter = rPrinter["SystemName"].ToString() + @"\" + rPrinter["ShareName"].ToString();
				}
				else
				{
					sPrinter = rPrinter["PortName"].ToString();
				}

				// копируем файл
				try
				{
					File.Copy(sFileName, sPrinter, true);
					RFMMessage.MessageBoxInfo("Этикетки отправлены на печать.");

					DialogResult = DialogResult.Yes;
					Dispose();
				}
				catch (Exception ex)
				{
					RFMMessage.MessageBoxError("Ошибка при отправке на печать: " + ex.Message);
				}
			}
		}

		private void btnHelp_Click(object sender, EventArgs e)
		{
			RFMHelpUtilities.HelpShow(this, hpHelp);
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.No;
			Dispose();
		}

	#region Restore

		private bool cboBarCodeLabels_Restore()
		{
			oBarCodeLabel.FilterActual = true;
			oBarCodeLabel.FilterType = sType;
			oBarCodeLabel.FillData();
			cboBarCodeLabels.ValueMember = oBarCodeLabel.ColumnID;
			cboBarCodeLabels.DisplayMember = oBarCodeLabel.ColumnName;
			DataView dvwBarCodeLabels = new DataView(oBarCodeLabel.MainTable);
			cboBarCodeLabels.DataSource = dvwBarCodeLabels;
			return (oBarCodeLabel.ErrorNumber == 0);
		}

		private bool cboPrinters_Restore()
		{
			oPrinter.FillData();
			foreach (DataRow r in oPrinter.MainTable.Rows)
			{
				r["Name"] += 
					(r["Comment"].ToString().Length > 0 ? "; " + r["Comment"] : "") +
					(r["Description"].ToString().Length > 0 ? "; " + r["Description"] : "") +
					(r["Location"].ToString().Length > 0 ? "; " + r["Location"] : "");
			}
			cboPrinters.ValueMember = oPrinter.ColumnID;
			cboPrinters.DisplayMember = oPrinter.ColumnName;
			DataView dvwPrinters = new DataView(oPrinter.MainTable);
			cboPrinters.DataSource = dvwPrinters;
			return (oPrinter.ErrorNumber == 0);
		}

	#endregion

	#region Fields

		/// <summary>
		/// поиск первого поля в #Field# в шаблоне
		/// </summary>
		private string GetField(string sStr, string sDelimiter)
		{
			int nAt = sStr.IndexOf(sDelimiter);
			if (nAt < 0)
				return ("");

			int nAt1 = sStr.Substring(nAt + 1).IndexOf(sDelimiter);
			if (nAt1 < 0)
				return ("");

			return (sStr.Substring(nAt + 1, nAt1));
		}

		/// <summary>
		/// замена в шаблоне названия поля на значение 
		/// </summary>
		private string SetField(string sStr, string sDelimiter, string sField, string sValue)
		{
			return (sStr.Replace(sDelimiter + sField + sDelimiter, sValue));
		}

	#endregion

	#region Выбор этикетки

		private void cboBarCodeLabels_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboBarCodeLabels.SelectedValue != null && (int)cboBarCodeLabels.SelectedValue > 0)
			{
				int nLabelID = (int)cboBarCodeLabels.SelectedValue;
				DataRow r = oBarCodeLabel.MainTable.Rows.Find(nLabelID);
				if (r != null)
					numCopies.Value = Convert.ToInt32(r["Copies"]);
			}
		}

	#endregion 

	}
}