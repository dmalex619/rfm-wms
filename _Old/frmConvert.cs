using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using RFMBaseClasses;
using WMSBizObjects;
using RFMPublic;

namespace WMSSuitable
{
	public partial class frmConvert : RFMFormChild
	{
		SqlConnection sqlConnectWms = ((RFMFormMain)Application.OpenForms[0]).MainConnect;
		SqlConnection sqlConnectTrd = new SqlConnection("Data Source=LOLO_JR;Initial Catalog=Trading;Persist Security Info=True;User ID=sa;Password=lolo");

		string sFile_WHDraftsD_ToWms = "c:\\_WHDraftsD_ToWms.xml";
		//string sFile_WHDraftsD_ToWms_ret = "c:\\_WHDraftsD_ToWms_ret.xml";
		string sFile_Cells_FromWms = "c:\\_CellsEts_FromWms.xml";
		string sFile_Cells_FromWms_ret = "c:\\_CellsEts_FromWms_ret.xml";

		public frmConvert()
		{
			InitializeComponent();
		}

		private void wmsButton1_Click(object sender, EventArgs e)
		{
			string _ERPCodesList = txtInputsErpCodes.Text;
			//for (int i = 1; i < 1000; i++)
			//	_ERPCodesList += i.ToString().Trim() + ",";

			// Обязательное определение возвращаемой переменной
			//_XMLResult = "";

			// Приведение списка (очистка от начальных и конечных запятых)
			if (_ERPCodesList.StartsWith(","))
				_ERPCodesList = _ERPCodesList.Substring(1);
			if (_ERPCodesList.EndsWith(","))
				_ERPCodesList = _ERPCodesList.Substring(0, _ERPCodesList.Length - 1);

			DataSet DS = new DataSet();
			SqlDataAdapter Adapter = new SqlDataAdapter("exec ws_GetInputs '" + _ERPCodesList + "'",  sqlConnectWms);
			try
			{
				Adapter.Fill(DS);
			}
			catch (SqlException se) 
			{ 
				MessageBox.Show(se.Number.ToString() + ": " + se.Message); 
				return; 
			}

			DS.Tables[0].TableName = "Inputs";
			DS.Tables[1].TableName = "InputsGoods";
			DS.Tables[2].TableName = "InputsTares";
			DS.Relations.Add(DS.Tables[0].Columns["ID"], DS.Tables[1].Columns["InputID"]);
			DS.Relations.Add(DS.Tables[0].Columns["ID"], DS.Tables[2].Columns["InputID"]);

			// Возврат данных об успешности обновления через XML DataSet
			//System.IO.StringWriter OutWriter = new System.IO.StringWriter();
			//DS.WriteXml(OutWriter, XmlWriteMode.WriteSchema);
			
			DS.WriteXml("c:\\123.xml",  XmlWriteMode.WriteSchema);

			//_XMLResult = OutWriter.ToString();
			return;
		}


		/// <summary>
		/// Trading: Подготовка данных о съеме контейнеров
		/// </summary>
		private void wmsButton2_Click(object sender, EventArgs e)
		{
			DataSet DS = new DataSet();
			string _sqlCommand = "exec ws_WHDraftsD_ToWms";
			SqlDataAdapter Adapter = new SqlDataAdapter(_sqlCommand, sqlConnectTrd);
			try
			{
				Adapter.Fill(DS);
			}
			catch (SqlException ex)
			{
				MessageBox.Show("Ошибка:\n" + ex.Number.ToString() + ":" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			DS.Tables[0].TableName = "WHDrafts";
			DS.Tables[1].TableName = "WHDraftsGoods";
			DS.Relations.Add(DS.Tables[0].Columns["Uniq"], DS.Tables[1].Columns["WHDraft"]);

			try
			{
				DS.WriteXml(sFile_WHDraftsD_ToWms, XmlWriteMode.WriteSchema);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка:\n" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			MessageBox.Show("Подготовлен файл " + sFile_WHDraftsD_ToWms);

			return;
		}


		/// <summary>
		/// Wms: Загрузка данных о съеме контейнеров
		/// </summary>
		private void wmsButton3_Click(object sender, EventArgs e)
		{
			WaitOn(this);

			DataSet DS = new DataSet();
			if (!File.Exists(sFile_WHDraftsD_ToWms))
			{
				WaitOff(this);
				MessageBox.Show("Ошибка: Отсутствует файл для загрузки данных " + sFile_WHDraftsD_ToWms + ".\n",
						"", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			DS.ReadXml(sFile_WHDraftsD_ToWms, XmlReadMode.Auto);

			// перекладываем во временные таблицы
			try
			{
				sqlConnectWms.Open();
			}
			catch (SqlException ex)
			{
				WaitOff(this);
				MessageBox.Show("Ошибка: Не установлено соединение с сервером Wms.\n" + 
					ex.Number.ToString() + ":" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			
			RFMUtilities.DataTableToTempTable(DS.Tables[0], "#WHDrafts", sqlConnectWms);
			RFMUtilities.DataTableToTempTable(DS.Tables[1], "#WHDraftsGoods", sqlConnectWms);

			// выполняем обновление
			String _strCommand = "execute ws_UpdateCells";
			SqlCommand _sqlCommand = new SqlCommand(_strCommand, sqlConnectWms);
			try
			{
				_sqlCommand.ExecuteScalar();
			}
			catch (SqlException ex)
			{
				WaitOff(this);
				MessageBox.Show("Ошибка: Не удалось загрузить данные в Wms.\n" +
					ex.Number.ToString() + ":" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			finally
			{
				sqlConnectWms.Close();
			}
			WaitOff(this);
			MessageBox.Show("Загружены данные из файла " + sFile_WHDraftsD_ToWms, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
			return;
		}

		
		/// <summary>
		/// Wms: Подготовка данных о ячейках, размещении контейнеров, исправлении ошибок
		/// </summary>
		private void wmsButton4_Click(object sender, EventArgs e)
		{
			DataSet DS = new DataSet();
			string _sqlCommand = "exec ws_GetCellsEtc";
			SqlDataAdapter Adapter = new SqlDataAdapter(_sqlCommand, sqlConnectWms);
			try
			{
				Adapter.Fill(DS);
			}
			catch (SqlException ex)
			{
				MessageBox.Show("Ошибка:\n" + ex.Number.ToString() + ":" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			DS.Tables[0].TableName = "Cells";
			DS.Tables[1].TableName = "Traffics";
			DS.Tables[2].TableName = "Changes";

			try
			{
				DS.WriteXml(sFile_Cells_FromWms, XmlWriteMode.WriteSchema);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка:\n" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			MessageBox.Show("Подготовлен файл " + sFile_Cells_FromWms, "", MessageBoxButtons.OK, MessageBoxIcon.Information);

			return;
		}

		/// <summary>
		/// Trading: Загрузка данных о ячейках, размещении контейнеров, исправлении ошибок
		/// </summary>
		private void wmsButton5_Click(object sender, EventArgs e)
		{
			WaitOn(this);

			DataSet DS = new DataSet();
			if (!File.Exists(sFile_Cells_FromWms))
			{
				WaitOff(this);
				MessageBox.Show("Ошибка: Отсутствует файл для загрузки данных " + sFile_Cells_FromWms + ".\n", 
						"", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			DS.ReadXml(sFile_Cells_FromWms, XmlReadMode.Auto);

			// перекладываем во временные таблицы
			try
			{
				sqlConnectTrd.Open();
			}
			catch (Exception ex)
			{
				WaitOff(this);
				MessageBox.Show("Ошибка: Не установлено соединение с сервером Trading.\n" + 
						ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			RFMUtilities.DataTableToTempTable(DS.Tables[0], "#Cells", sqlConnectTrd);
			RFMUtilities.DataTableToTempTable(DS.Tables[1], "#Traffics", sqlConnectTrd);
			RFMUtilities.DataTableToTempTable(DS.Tables[2], "#Changes", sqlConnectTrd);

			// выполняем обновление из временных таблиц
			// если все нормально, обратно получим erp-коды
			DataSet DSerp = new DataSet();

			String _strCommand = "execute ws_WHStorage_FromWms";
			SqlCommand _sqlCommand = new SqlCommand(_strCommand, sqlConnectTrd);
			_sqlCommand.CommandTimeout = 0;

			SqlDataAdapter Aerp = new SqlDataAdapter(_sqlCommand);
			try
			{
				Aerp.Fill(DSerp);

				// и сохраняем полученные коды в xml
				DSerp.Tables[0].TableName = "Cells";
				DSerp.Tables[1].TableName = "Traffics";
				DSerp.Tables[2].TableName = "Changes";
				try
				{
					DSerp.WriteXml(sFile_Cells_FromWms_ret, XmlWriteMode.WriteSchema);
				}
				catch (Exception ex)
				{
					WaitOff(this);
					MessageBox.Show("Ошибка: Не удалось сохранить erp-коды, полученные из Traidng.\n" + 
							ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}
			catch (SqlException ex)
			{
				WaitOff(this);
				MessageBox.Show("Ошибка: Не удалось выполнить обновление данных в Trading.\n" + 
						ex.Number.ToString() + ":" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			finally
			{
				sqlConnectTrd.Close();
			}


			//
			// закачиваем полученные Erp-коды в Wms
			//
			if (!File.Exists(sFile_Cells_FromWms_ret))
			{
				WaitOff(this);
				MessageBox.Show("Ошибка: Отсутствует файл для загрузки полученных erp-кодов " + sFile_Cells_FromWms + ".\n", 
						"", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			DataSet DSret = new DataSet();
			DSret.ReadXml(sFile_Cells_FromWms_ret, XmlReadMode.Auto);

			// перекладываем во временные таблицы
			try
			{
				sqlConnectWms.Open();
			}
			catch (Exception ex)
			{
				WaitOff(this);
				MessageBox.Show("Ошибка: Не установлено соединение с сервером Wms.\n" + 
					ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			RFMUtilities.DataTableToTempTable(DSret.Tables[0], "#Cells", sqlConnectWms);
			RFMUtilities.DataTableToTempTable(DSret.Tables[1], "#Traffics", sqlConnectWms);
			RFMUtilities.DataTableToTempTable(DSret.Tables[2], "#Changes", sqlConnectWms);

			_strCommand = "update Cells set ErpCode = C.ErpCode " + 
									"from #Cells C " +
									"where Cells.ID = C.ID and Cells.ErpCode is Null and len(C.ErpCode) > 0; " + 
								"update Traffics set ErpCode = T.ErpCode " + 
									"from #Traffics T " +
									"where Traffics.ID = T.ID and Traffics.ErpCode is Null and len(T.ErpCode) > 0; " + 
								"update CellsChanges set ErpCode = H.ErpCode " + 
									"from #Changes H " +
									"where CellsChanges.ID = H.ID and CellsChanges.ErpCode is Null and len(H.ErpCode) > 0; ";
			_sqlCommand = new SqlCommand(_strCommand, sqlConnectWms);
			try
			{
				_sqlCommand.ExecuteScalar();
			}
			catch (SqlException ex)
			{
				WaitOff(this);
				MessageBox.Show("Ошибка: Не удалось загрузить данные в Trading и обновить erp-коды в Wms.\n" + 
					ex.Number.ToString() + ":" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			finally
			{
				sqlConnectWms.Close();
			}

			WaitOff(this);
			MessageBox.Show("Загружены данные из файла " + sFile_Cells_FromWms, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
			return;
		}

		private void frmConvert_Load(object sender, EventArgs e)
		{
			txt1.Text = "QQQQQ";
			txt2.Text = "QQQQQ";

		}
	}
}