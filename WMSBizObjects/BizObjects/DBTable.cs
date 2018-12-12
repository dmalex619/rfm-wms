using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

using RFMPublic;

/// <summary>
/// Бизнес-объект Таблица данных (DBTable)
/// </summary>
/// 
namespace WMSBizObjects
{
	public class DBTable : BizObject
	{
		protected string _RusTableName;
		/// <summary>
		/// Русское название (описание) таблицы
		/// </summary>
		[Description("Русское название (описание) таблицы")]
		public string RusTableName { get { return _RusTableName; } set { _RusTableName = value; _NeedRequery = true; } }

		protected string _FullTableName;
		/// <summary>
		/// Полное название таблицы: лат (рус) 
		/// </summary>
		[Description("Полное название таблицы: лат (рус)")]
		public string FullTableName { get { return _FullTableName; } set { _FullTableName = value; _NeedRequery = true; } }

		protected int? _recordID;
		/// <summary>
		/// ID записи выбранной таблицы
		/// </summary>
		[Description("ID записи выбранной таблицы")]
		public int? recordID { get { return _recordID; } set { _recordID = value; _NeedRequery = true; } }

		protected DataTable _TableStructure;
		/// <summary>
		/// Структура выбранной таблицы данных
		/// </summary>
		[Description("Структура выбранной таблицы данных")]
		public DataTable TableStructure { get { return _TableStructure; } }

		protected DataTable _TableRecordToSave;
		/// <summary>
		/// Запись с данными для сохранения
		/// </summary>
		[Description("Запись с данными для сохранения")]
		public DataTable TableRecordToSave { get { return _TableRecordToSave; } }


		public DBTable()
			: base()
		{
			_MainTableName = "_Tables";
			_ColumnID = "ID";
			_ColumnName = "Name";
		}

		public DBTable(string sMainTableName)
			: this()
		{
			_MainTableName = sMainTableName;
		}


		public override bool FillData()
		{
			ClearData();

			string sqlSelect = "select *, rtrim(TableName) + ' (' + rtrim(Name) + ')' as FullTableName " +
				"from _Tables " +
				"where ForLook = 1 " +
				"order by TableName";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			try
			{
				_MainTable = FillReadings(new SqlDataAdapter(_oCommand), _MainTable, _MainTableName);

				_NeedRequery = false;
				ColumnName = "FullTableName";
			}
			catch (Exception ex)
			{
				_ErrorNumber = -1;
				_ErrorStr = "Ошибка при получении данных таблицы " + _MainTableName + "...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}


		public bool FillNames()
		{
			_RusTableName = _FullTableName = "";

			if (_MainTableName == null || _MainTableName.Length == 0)
				return (false);

			string sqlSelect = "select *, rtrim(TableName) + ' (' + rtrim(Name) + ')' as FullTableName " +
				"from _Tables " +
				"where ForLook = 1 and TableName = '" + _MainTableName + "' " +
				"order by TableName";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			try
			{
				FillReadings(new SqlDataAdapter(_oCommand), null, "TempTable");
				if (_DS.Tables["TempTable"].Rows.Count > 0)
				{
					DataRow dr = _DS.Tables["TempTable"].Rows[0];
					_FullTableName = dr["FullTableName"].ToString();
					_RusTableName = dr["Name"].ToString();
				}
				//_DS.Tables.Remove("TempTable");
			}
			catch (Exception ex)
			{
				_ErrorNumber = -1;
				_ErrorStr = "Ошибка при получении данных о таблице " + _MainTableName + "...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// список записей выбранной таблицы
		/// </summary>
		/// <param name="nID">ID нужной записи, null - все записи</param>
		/// <param name="bIsRowNumber">выгружать № строки отдельной колонкой</param>
		/// <returns></returns>
		public bool GetRecordsList(int? nID, bool bIsRowNumber)
		{
			ClearData();

			string sqlSelect = "exec sy_TableDataGet @cTable, 1, @bRowNumber, @nID, '', '', " +
									"@nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region sy_TableDataGet parameters

			_oCommand.Parameters.Add("@cTable", SqlDbType.VarChar);
			_oCommand.Parameters["@cTable"].Value = _MainTableName;

			_oCommand.Parameters.Add("@bRowNumber", SqlDbType.Bit);
			_oCommand.Parameters["@bRowNumber"].Value = bIsRowNumber;

			_oCommand.Parameters.Add("@nID", SqlDbType.Int);
			if (nID.HasValue)
				_oCommand.Parameters["@nID"].Value = Math.Abs((int)nID);
			else
				_oCommand.Parameters["@nID"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@nError", SqlDbType.Int);
			_oCommand.Parameters["@nError"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@nError"].Value = 0;

			_oCommand.Parameters.Add("@cErrorText", SqlDbType.VarChar, 200);
			_oCommand.Parameters["@cErrorText"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@cErrorText"].Value = "";

			#endregion

			try
			{
				_MainTable = FillReadings(new SqlDataAdapter(_oCommand), _MainTable, _MainTableName);

				// primarykey
				DataColumn[] pk = new DataColumn[1];
				pk[0] = _MainTable.Columns[_ColumnID];
				_MainTable.PrimaryKey = pk;

			}
			catch (Exception ex)
			{
				_ErrorNumber = -2;
				_ErrorStr = "Ошибка при получении данных таблицы " + _MainTableName + "...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			if (_ErrorNumber == 0)
			{
				_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
				if (_ErrorNumber != 0)
				{
					_ErrorStr = "Ошибка при получении данных таблицы " + _MainTableName + "...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}


		/// <summary>
		/// структура выбранной таблицы
		/// </summary>
		/// <param name="bIsRowNumber">выгружать № строки отдельной колонкой</param>
		/// <returns></returns>
		public bool GetStructure(bool bIsRowNumber)
		{
			string sqlSelect = "exec sy_TableStructureGet @cTable, 1, @bRowNumber, 1, " +
									"@nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region sy_TableStructureGet parameters

			_oCommand.Parameters.Add("@cTable", SqlDbType.VarChar);
			_oCommand.Parameters["@cTable"].Value = _MainTableName;

			_oCommand.Parameters.Add("@bRowNumber", SqlDbType.Bit);
			_oCommand.Parameters["@bRowNumber"].Value = bIsRowNumber;

			_oCommand.Parameters.Add("@nError", SqlDbType.Int);
			_oCommand.Parameters["@nError"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@nError"].Value = 0;

			_oCommand.Parameters.Add("@cErrorText", SqlDbType.VarChar, 200);
			_oCommand.Parameters["@cErrorText"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@cErrorText"].Value = "";

			#endregion

			try
			{
				_TableStructure = FillReadings(new SqlDataAdapter(_oCommand), _TableStructure, "_TableStructure");
			}
			catch (Exception ex)
			{
				_ErrorNumber = -3;
				_ErrorStr = "Ошибка при получении структуры таблицы " + _MainTableName + "...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			if (_ErrorNumber == 0)
			{
				_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
				if (_ErrorNumber != 0)
				{
					_ErrorNumber = -3;
					_ErrorStr = "Ошибка при получении структуры таблицы " + _MainTableName + "...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
				else
				{
					if (_TableStructure.Rows.Count == 0)
					{
						_ErrorNumber = -3;
						_ErrorStr = "Нет данных о структуре таблицы " + _MainTableName + "...\r\n";
						RFMMessage.MessageBoxError(_ErrorStr);
					}
				}
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// список записей классификатора для выбранной таблицы
		/// </summary>
		/// <param name="nID">ID нужной записи, null - все записи</param>
		/// <param name="bIsRowNumber">выгружать № строки отдельной колонкой</param>
		/// <returns></returns>
		public bool GetFKRecordsList(string sFKTableName, string sFKTableNameDS)
		{
			if (sFKTableNameDS.Length == 0)
				sFKTableNameDS = sFKTableName;

			string sqlSelect = "exec sy_TableDataGetSimple @cTable, @nCustomLen output, " +
									"@nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region sy_TableDataGetSimple parameters

			_oCommand.Parameters.Add("@cTable", SqlDbType.VarChar);
			_oCommand.Parameters["@cTable"].Value = sFKTableName;

			_oCommand.Parameters.Add("@nCustomLen", SqlDbType.Int);
			_oCommand.Parameters["@nCustomLen"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@nCustomLen"].Value = 0;

			_oCommand.Parameters.Add("@nError", SqlDbType.Int);
			_oCommand.Parameters["@nError"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@nError"].Value = 0;

			_oCommand.Parameters.Add("@cErrorText", SqlDbType.VarChar, 200);
			_oCommand.Parameters["@cErrorText"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@cErrorText"].Value = "";

			#endregion

			try
			{
				FillReadings(new SqlDataAdapter(_oCommand), null, sFKTableNameDS);

				// primarykey
				DataColumn[] pk = new DataColumn[1];
				pk[0] = _DS.Tables[sFKTableNameDS].Columns["ID"];
				_DS.Tables[sFKTableNameDS].PrimaryKey = pk;
			}
			catch (Exception ex)
			{
				_ErrorNumber = -4;
				_ErrorStr = "Ошибка при получении данных классификатора " + sFKTableName + " для таблицы " + _MainTableName + "...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			if (_ErrorNumber == 0)
			{
				_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
				if (_ErrorNumber != 0)
				{
					_ErrorNumber = -4;
					_ErrorStr = "Ошибка при получении данных классификатора " + sFKTableName + " для таблицы " + _MainTableName + "...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
				else
				{
					_DS.Tables[sFKTableNameDS].Columns[1].MaxLength = Convert.ToInt32(_oCommand.Parameters["@nCustomLen"].Value) + 1;
				}
			}
			return (_ErrorNumber == 0);
		}


		/// <summary>
		/// сохраняемые значения -> в таблицу TableRecordToSave
		/// </summary>
		/// <returns></returns>
		public void PrepareDataToSave()
		{
			if (_DS.Tables["TableRecordToSave"] != null)
			{
				//_DS.Tables.Remove("TableRecordToSave");
				_TableRecordToSave.Columns.Clear();
				_TableRecordToSave.Clear();
			}
			else
			{
				_DS.Tables.Add("TableRecordToSave");
			}
			_TableRecordToSave = _DS.Tables["TableRecordToSave"];
			_TableRecordToSave.Rows.Add();
		}


		/// <summary>
		/// сохранение записи
		/// </summary>
		/// <returns></returns>
		public bool RecordSave()
		{
			if (_recordID == null)
				return (false);

			int nOldID = (int)_recordID;

			// таблица ds.Tables("RecordToSave"), содержащая значения для сохранения -> XML
			System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
			_TableRecordToSave.WriteXml(oStringWriter);
			string xmlString = oStringWriter.ToString();

			string sqlSelect = "exec sy_TableDataSaveXml @cTable, @nID output, @xXml, @cTableRecordToSave, " +
									"@nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region sy_TableDataSaveXml parameters

			_oCommand.Parameters.Add("@cTable", SqlDbType.VarChar);
			_oCommand.Parameters["@cTable"].Value = _MainTableName;

			_oCommand.Parameters.Add("@nID", SqlDbType.Int);
			_oCommand.Parameters["@nID"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@nID"].Value = _recordID;

			_oCommand.Parameters.Add("@xXml", SqlDbType.Xml);
			_oCommand.Parameters["@xXml"].Value = xmlString;

			_oCommand.Parameters.Add("@cTableRecordToSave", SqlDbType.VarChar, 100);
			_oCommand.Parameters["@cTableRecordToSave"].Value = "TableRecordToSave";

			_oCommand.Parameters.Add("@nError", SqlDbType.Int);
			_oCommand.Parameters["@nError"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@nError"].Value = 0;

			_oCommand.Parameters.Add("@cErrorText", SqlDbType.VarChar, 200);
			_oCommand.Parameters["@cErrorText"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@cErrorText"].Value = "";

			#endregion

			try
			{
				_Connect.Open();
				_oCommand.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -11;
				_ErrorStr = "Ошибка при сохранении данных (xml) таблицы " + _MainTableName + "...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			if (_ErrorNumber == 0)
			{
				_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
				if (_ErrorNumber != 0)
				{
					_ErrorNumber = -11;
					_ErrorStr = "Ошибка при сохранении данных (xml) таблицы " + _MainTableName + "...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
				else
				{
					// получить код добавленной записи
					if (nOldID == 0)
					{
						if (_oCommand.Parameters["@nID"].Value != DBNull.Value)
						{
							_recordID = Convert.ToInt32(_oCommand.Parameters["@nID"].Value);
							RFMMessage.MessageBoxInfo("Запись сохранена с кодом " + _recordID.ToString());
						}
						else
						{
							_ErrorNumber = -11;
							_ErrorStr = "Ошибка при получении кода сохраненной записи в таблице " + _MainTableName + "...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
							RFMMessage.MessageBoxError(_ErrorStr);
						}
					}
				}
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// удаление записи
		/// </summary>
		/// <returns></returns>
		public bool RecordDelete()
		{
			if (_recordID == null)
				return (false);

			int nOldID = (int)_recordID;


			string sqlSelect = "exec sy_TableDataDelete @cTable, @nID, " +
									"@nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region sy_TableDataDelete parameters

			_oCommand.Parameters.Add("@cTable", SqlDbType.VarChar);
			_oCommand.Parameters["@cTable"].Value = _MainTableName;

			_oCommand.Parameters.Add("@nID", SqlDbType.Int);
			_oCommand.Parameters["@nID"].Value = _recordID;

			_oCommand.Parameters.Add("@nError", SqlDbType.Int);
			_oCommand.Parameters["@nError"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@nError"].Value = 0;

			_oCommand.Parameters.Add("@cErrorText", SqlDbType.VarChar, 200);
			_oCommand.Parameters["@cErrorText"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@cErrorText"].Value = "";

			#endregion

			try
			{
				_Connect.Open();
				_oCommand.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -12;
				_ErrorStr = "Ошибка при удалении данных из таблицы " + _MainTableName + "...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			if (_ErrorNumber == 0)
			{
				_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
				if (_ErrorNumber != 0)
				{
					_ErrorNumber = -11;
					_ErrorStr = "Ошибка при удалении данных из таблицы " + _MainTableName + "...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
				else
				{
					RFMMessage.MessageBoxInfo("Запись удалена.");
				}
			}
			return (_ErrorNumber == 0);
		}

	}
}
