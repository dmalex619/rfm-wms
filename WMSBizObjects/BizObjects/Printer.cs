using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

using RFMPublic;

/// <summary>
/// Бизнес-объект Принтер (Printer)
/// </summary>
/// 
namespace WMSBizObjects
{
	public class Printer : BizObject
	{

		// Фильтры

		// ----------------------------

		public Printer()
			: base()
		{
			_MainTableName = "Printer";
			_ColumnID = "ID";
			_ColumnName = "Name";
		}


		public override bool FillData()
		{
			ClearData();

			if (_MainTable.Columns.Count == 0)
			{
				//_MainTable.Columns.Add("ID",		System.Type.GetType("System.Int16"));		// собственный № п/п
				_MainTable.Columns.Add("ID", typeof(int));	// собственный № п/п
				_MainTable.Columns.Add("DeviceID");				// ID
				_MainTable.Columns.Add("Name");					// имя 
				_MainTable.Columns.Add("Default", System.Type.GetType("System.Boolean"));		// принтер по умолчанию?
				_MainTable.Columns.Add("Local", System.Type.GetType("System.Boolean"));			// локальный?
				_MainTable.Columns.Add("Network", System.Type.GetType("System.Boolean"));		// сетевой?
				_MainTable.Columns.Add("Shared", System.Type.GetType("System.Boolean"));		// общий ресурс?
				_MainTable.Columns.Add("PortName");				// порт
				_MainTable.Columns.Add("ShareName");			// сетевое имя
				_MainTable.Columns.Add("SystemName");			// системное имя
				_MainTable.Columns.Add("ServerName");			// имя сервера
				_MainTable.Columns.Add("Comment");				// комментарий
				_MainTable.Columns.Add("Description");			// описание
				_MainTable.Columns.Add("Location");				// расположение
				_MainTable.Columns.Add("Status");				// статус
				_MainTable.Columns.Add("PrinterState", System.Type.GetType("System.UInt32"));	// состояние

				DataColumn[] pk = new DataColumn[1];
				pk[0] = _MainTable.Columns[_ColumnID];
				_MainTable.PrimaryKey = pk;
			}

			try
			{
				int i = 0;
				string queryString = "SELECT * FROM Win32_Printer";
				System.Management.ManagementObjectSearcher query;
				System.Management.ManagementObjectCollection printers;
				query = new System.Management.ManagementObjectSearcher(queryString);
				printers = query.Get();
				foreach (System.Management.ManagementObject printer in printers)
				{
					i++;

					DataRow pr = _MainTable.Rows.Add(i);
					//pr["ID"] = i;
					pr["DeviceID"] = printer["DeviceID"].ToString();
					pr["Name"] = printer["Name"].ToString();
					pr["Default"] = printer["Default"];
					pr["Local"] = printer["Local"];
					pr["Network"] = printer["Network"];
					pr["Shared"] = printer["Shared"];
					pr["PortName"] = printer["PortName"].ToString();
					pr["ShareName"] = (printer["ShareName"] == null) ? "" : printer["ShareName"].ToString();
					pr["SystemName"] = (printer["ShareName"] == null) ? "" : printer["SystemName"].ToString();
					pr["ServerName"] = (printer["ServerName"] == null) ? "" : printer["ServerName"].ToString();
					pr["Comment"] = (printer["Comment"] == null) ? "" : printer["Comment"].ToString();
					pr["Description"] = (printer["Description"] == null) ? "" : printer["Description"].ToString();
					pr["Location"] = (printer["Location"] == null) ? "" : printer["Location"].ToString();
					pr["Status"] = printer["Status"].ToString();
					pr["PrinterState"] = printer["PrinterState"];
				}
			}
			catch (Exception ex)
			{
				_ErrorNumber = -1;
				_ErrorStr = "Ошибка при получении списка принтеров..." + Convert.ToChar(13) + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}
	}
}