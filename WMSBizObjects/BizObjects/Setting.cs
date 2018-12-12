using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

using RFMPublic;

/// <summary>
/// Бизнес-объект Системные настройки (Setting)
/// </summary>
/// 
namespace WMSBizObjects
{
	public class Setting : BizObject
	{

		protected string _Variable;
		/// <summary>
		/// Имя переменной 
		/// </summary>
		[Description("Имя переменной")]
		public string Variable { get { return _Variable; } set { _Variable = value; _NeedRequery = true; } }

		protected string _VarName;
		/// <summary>
		/// Описание переменной 
		/// </summary>
		[Description("Описание переменной")]
		public string VarName { get { return _VarName; } set { _VarName = value; _NeedRequery = true; } }

		protected string _VarTypeCode;
		/// <summary>
		/// Тип переменной: C, N, L, D
		/// </summary>
		[Description("Тип переменной: C, N, L, D")]
		public string VarTypeCode { get { return _VarTypeCode; } set { _VarTypeCode = value; _NeedRequery = true; } }

		protected string _VarValue;
		/// <summary>
		/// Значение переменной 
		/// </summary>
		[Description("Значение переменной")]
		public string VarValue { get { return _VarValue; } set { _VarValue = value; _NeedRequery = true; } }

		// ----------------------------

		public Setting()
			: base()
		{
			_MainTableName = "_Settings";
			_ColumnID = "ID";
			_ColumnName = "Name";
		}

		public override bool FillData()
		{
			ClearData();

			string sqlSelect = "select * from Settings";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			try
			{
				_MainTable = FillReadings(new SqlDataAdapter(_oCommand), _MainTable, _MainTableName);
				_NeedRequery = false;
			}
			catch (Exception ex)
			{
				_ErrorNumber = -1;
				_ErrorStr = "Ошибка при получении списка систменых переменных..." + Convert.ToChar(13) + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// очистка полей
		/// </summary>
		public void ClearFields()
		{
			_Variable = null;
			_VarName = null;
			_VarTypeCode = null;
			_VarValue = null;
			//_NeedRequery = true;
		}

		/// <summary>
		/// заполнение полей, возвращает string-значение Setting.Value 
		/// </summary>
		public string FillVariable(string sVariable)
		{
			ClearFields();

			string sqlSelect = "select * from _Settings where Variable = @cVariable";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			_oCommand.Parameters.Add("@cVariable", SqlDbType.VarChar, 100);
			_oCommand.Parameters["@cVariable"].Value = sVariable;

			try
			{
				_MainTable = FillReadings(new SqlDataAdapter(_oCommand), null, "TableVariable");
				if (_DS.Tables["TableVariable"].Rows.Count == 1)
				{
					_Variable = _DS.Tables["TableVariable"].Rows[0]["Variable"].ToString();
					_VarName = _DS.Tables["TableVariable"].Rows[0]["Name"].ToString();
					_VarValue = _DS.Tables["TableVariable"].Rows[0]["Value"].ToString();
					_VarTypeCode = _DS.Tables["TableVariable"].Rows[0]["Type"].ToString();
				}
			}
			catch (Exception ex)
			{
				_ErrorNumber = -1;
				_ErrorStr = "Ошибка при получении значения переменной..." + Convert.ToChar(13) + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_VarValue);
		}
	}
}
