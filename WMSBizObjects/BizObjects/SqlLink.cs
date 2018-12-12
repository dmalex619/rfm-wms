using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;

namespace WMSBizObjects
{
	/// <summary>
	/// Класс для получения строки соединения с БД.
	/// </summary>
	public class SqlLink
	{
		#region Строка соединения

		protected string _ConnStr = null;
		/// <summary>
		/// Строка соединения с БД.
		/// </summary>

		[Category("WMS")]
		[Description("Возвращает строку соединения с БД")]
		public string ConnStr
		{
			get { return _ConnStr; }
		}

		#endregion

		#region Сообщение об ошибке

		protected string _ErrorStr = "";
		/// <summary>
		/// Сообщение о причине ошибки соединения с БД.
		/// </summary>
		[Category("WMS")]
		[Description("Возвращает сообщение о причине ошибки соединения с БД")]
		public string ErrorStr
		{
			get { return _ErrorStr; }
		}

		#endregion

		/// <summary>
		/// Конструктор объекта "Строка соединения".
		/// Заполняет свойство ConnStr в случае успешности создания объекта,
		/// либо свойство ErrorStr в случае ошибки.
		/// </summary>
		[Category("WMS")]
		[Description("Конструктор объекта SqlLink")]
		public SqlLink()
		{
			// Получение строки соединения
			Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			ConnectionStringsSection csSection = config.ConnectionStrings;
			for (int i = 0; i < ConfigurationManager.ConnectionStrings.Count; i++)
			{
				ConnectionStringSettings cs = csSection.ConnectionStrings[i];
				if (cs.Name == "WMSConnectionString")
					_ConnStr = cs.ConnectionString;
			}
			// Проверка успешности поиска стороки соединения
			if (String.IsNullOrEmpty(_ConnStr))
			{
				_ConnStr = null;
				_ErrorStr = "Не удалось обнаружить строку соединения в файле конфигурации.";
				return;
			}

			// Проверка соединения
			try
			{
				SqlConnection sqlConnect = new SqlConnection(_ConnStr);
				sqlConnect.Open();
				sqlConnect.Close();
			}
			catch
			{
				_ErrorStr = "Cтрока соединения содержит неверные данные.";
				_ConnStr = null;
			}
			return;
		}
	}
}