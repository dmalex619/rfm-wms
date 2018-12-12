using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

using RFMPublic; 

/// <summary>
/// Бизнес-объект Дополнительные внутрискладские операции (SalaryExtraWork)
/// </summary>
namespace WMSBizObjects
{
	public class SalaryExtraWork : BizObject 
	{
		protected string _IDList;
		/// <summary>
		/// Список ID операций (SalaryExtraWorks.ID)
		/// </summary>
		[Description("Список ID внутр.перемещений (SalaryExtraWorks.ID)")]
		public string IDList { get { return _IDList; } set { _IDList = value; _NeedRequery = true; } }

		// Фильтры
		#region Filters

		protected DateTime? _FilterDateBeg;
		/// <summary>
		/// Фильтр-поле: Начальная дата периода (SalaryExtraWorks.DateSalaryExtraWork)
		/// </summary>
		[Description("Фильтр-поле: Начальная дата периода (SalaryExtraWorks.DateSalaryExtraWork)")]
		public DateTime? FilterDateBeg { get { return _FilterDateBeg; } set { _FilterDateBeg = value; } }
		protected DateTime? _FilterDateEnd;
		/// <summary>
		/// Фильтр-поле: Конечная дата периода
		/// </summary>
		[Description("Фильтр-поле: Конечная дата периода (SalaryExtraWorks.DateSalaryExtraWork)")]
		public DateTime? FilterDateEnd { get { return _FilterDateEnd; } set { _FilterDateEnd = value; } }

		protected string _FilterSalaryExtraWorksTypesList;
		/// <summary>
		/// Фильтр-поле: Список типов внутр.перемещения (SalaryExtraWorks.SalaryExtraWorkTypeID), через запятую
		/// </summary>
		[Description("Фильтр-поле: Список типов внутр.перемещения (SalaryExtraWorks.SalaryExtraWorkTypeID), через запятую")]
		public string FilterSalaryExtraWorksTypesList { get { return _FilterSalaryExtraWorksTypesList; } set { _FilterSalaryExtraWorksTypesList = value; } }

        protected string _FilterOwnersList;
        /// <summary>
        /// Фильтр-поле: список владельцев (SalaryExtraWorks.OwnerID), через запятую
        /// </summary>
        [Description("Фильтр-поле: список владельцев (SalaryExtraWorks.OwnerID), через запятую")]
        public string FilterOwnersList { get { return _FilterOwnersList; } set { _FilterOwnersList = value; } }

        protected string _FilterUsersList;
		/// <summary>
		/// Фильтр-поле: список сотрудников (SalaryExtraWorks.UserID), через запятую
		/// </summary>
		[Description("Фильтр-поле: список сотрудников (SalaryExtraWorks.UserID), через запятую")]
		public string FilterUsersList { get { return _FilterUsersList; } set { _FilterUsersList = value; } }

		protected string _FilterWorkNameContext;
		/// <summary>
		/// Фильтр-поле: контекст названия работ (SalaryExtraWorks.WorkName)
		/// </summary>
		[Description("Фильтр-поле: контекст названия работ (SalaryExtraWorks.WorkName)?")]
		public string FilterWorkNameContext { get { return _FilterWorkNameContext; } set { _FilterWorkNameContext = value; _NeedRequery = true; } }

		#endregion Filters

		// Таблицы
		protected DataTable _TableSalaryTariffs;
		/// <summary>
		/// Тарифы по видам работ (TableSalaryTariffs)
		/// </summary>
		[Description("Тарифы по видам работ (TableSalaryTariffs)")]
		public DataTable TableSalaryTariffs { get { return _TableSalaryTariffs; } }

		// -------------------------------------

		public SalaryExtraWork() : base()
		{
			_MainTableName = "SalaryExtraWorks";
		}

		#region FillData

		/// <summary>
		/// получение списка внутр.перемещений (MainTable)
		/// </summary>
		public override bool FillData()
		{
			ClearData();

			string sqlSelect = "execute up_SalaryExtraWorksFill " +
				"@nID, @cIDList, " +
				"@dDateBeg, @dDateEnd, " +
                "@cOwnersList, @cUsersList, " +
				"@cWorkNameContext"; 
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_SalaryExtraWorksFill parameters 

			SqlParameter oParameter = _oCommand.Parameters.Add("@nID", SqlDbType.Int);
			if (_ID != null)
				oParameter.Value = ID;
			else
				oParameter.Value = DBNull.Value;

			oParameter = _oCommand.Parameters.Add("@cIDList", SqlDbType.VarChar);
			if (_IDList != null)
				oParameter.Value = _IDList;
			else
				oParameter.Value = DBNull.Value;

			oParameter = _oCommand.Parameters.Add("@dDateBeg", SqlDbType.SmallDateTime);
			if (_FilterDateBeg != null)
				oParameter.Value = _FilterDateBeg;
			else
				oParameter.Value = DBNull.Value;

			oParameter = _oCommand.Parameters.Add("@dDateEnd", SqlDbType.SmallDateTime);
			if (_FilterDateEnd != null)
				oParameter.Value = _FilterDateEnd;
			else
				oParameter.Value = DBNull.Value;

            oParameter = _oCommand.Parameters.Add("@cOwnersList", SqlDbType.VarChar);
            if (_FilterOwnersList != null)
                oParameter.Value = _FilterOwnersList;
            else
                oParameter.Value = DBNull.Value;

            oParameter = _oCommand.Parameters.Add("@cUsersList", SqlDbType.VarChar);
			if (_FilterUsersList != null)
				oParameter.Value = _FilterUsersList;
			else
				oParameter.Value = DBNull.Value;

			oParameter = _oCommand.Parameters.Add("@cWorkNameContext", SqlDbType.VarChar);
			if (_FilterWorkNameContext != null)
				oParameter.Value = _FilterWorkNameContext;
			else
				oParameter.Value = DBNull.Value;

			#endregion

			try
			{
				_MainTable = FillReadings(new SqlDataAdapter(_oCommand), _MainTable, _MainTableName);
			}
			catch (Exception ex)
			{
				_ErrorNumber = -1;
				_ErrorStr = "Ошибка при получении списка операций..." + Convert.ToChar(13) + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// очистка фильтр-полей
		/// </summary>
		public void ClearFilters()
		{
			_FilterDateBeg = null;
			_FilterDateEnd = null;
			_FilterUsersList = null;
            _FilterOwnersList = null;
			_FilterWorkNameContext = null;
			//_NeedRequery = false;
		}

		#endregion FillData

		#region Save

		public bool Save(int? nID, 
			DateTime dDateWork, 
			string sWorkName, 
            int? nOwnerID, 
			int nUserID, 
			decimal nQnt, 
			decimal nPrice, 
			string sNote)
		{
			String _sqlCommand = "execute up_SalaryExtraWorksSave @nID output, " +
					"@dDateWork, " +
					"@cWorkName, " +
                    "@nOwnerID, " +
                    "@nUserID, " +
                    "@nQnt, " +
					"@nPrice, " +  
					"@cNote, " +
					"@nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(_sqlCommand, _Connect);

			#region up_SalaryExtraWorksSave parameters

			SqlParameter _oParameter = _oCommand.Parameters.Add("@nID", SqlDbType.Int);
			if (nID.HasValue)
				_oParameter.Value = nID;
			else
				_oParameter.Value = DBNull.Value;
			_oParameter.Direction = ParameterDirection.InputOutput;

			_oParameter = _oCommand.Parameters.Add("@dDateWork", SqlDbType.DateTime);
			_oParameter.Value = dDateWork;

			_oParameter = _oCommand.Parameters.Add("@cWorkName", SqlDbType.VarChar);
			if (sWorkName != null)
				_oParameter.Value = sWorkName; 
			else
				_oParameter.Value = "";

            _oParameter = _oCommand.Parameters.Add("@nOwnerID", SqlDbType.Int);
            if (nOwnerID != null)
                _oParameter.Value = nOwnerID;
            else
                _oParameter.Value = DBNull.Value;

            _oParameter = _oCommand.Parameters.Add("@nUserID", SqlDbType.Int);
            _oParameter.Value = nUserID;

            _oParameter = _oCommand.Parameters.Add("@nQnt", SqlDbType.Decimal);
			_oParameter.Precision = 6;
			_oParameter.Scale = 1;
			_oParameter.Value = nQnt;

			_oParameter = _oCommand.Parameters.Add("@nPrice", SqlDbType.Money);
			_oParameter.Value = nPrice;

			_oParameter = _oCommand.Parameters.Add("@cNote", SqlDbType.VarChar);
			if (sNote != null)
				_oParameter.Value = sNote;
			else
				_oParameter.Value = ""; 

			_oParameter = _oCommand.Parameters.Add("@nError", SqlDbType.Int);
			_oParameter.Direction = ParameterDirection.InputOutput;
			_oParameter.Value = 0;
			
			_oParameter = _oCommand.Parameters.Add("@cErrorText", SqlDbType.VarChar, 200);
			_oParameter.Direction = ParameterDirection.InputOutput;
			_oParameter.Value = "";

			#endregion

			try
			{
				_Connect.Open();
				_oCommand.ExecuteScalar();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -10;
				_ErrorStr = "Ошибка при сохранении операции...\r\n" + ex.Message;
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
					_ErrorStr = "Ошибка при сохранении операции...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
				// при создании новой операции - получим ее код
				if (	(!nID.HasValue && _oCommand.Parameters["@nID"].Value != DBNull.Value) ||
						(nID == 0 && _oCommand.Parameters["@nID"].Value != DBNull.Value))
				{
					_ID = (int)_oCommand.Parameters["@nID"].Value;
				}
			}
			return (_ErrorNumber == 0);
		}

		#endregion Save

		#region Delete

		public bool Delete(int nID)
		{
			String _sqlCommand = "execute up_SalaryExtraWorksDelete @nID, " +
					"@nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(_sqlCommand, _Connect);

			#region up_SalaryExtraWorksDelete parameters

			SqlParameter _oParameter = _oCommand.Parameters.Add("@nID", SqlDbType.Int);
			_oParameter.Value = nID;

			_oParameter = _oCommand.Parameters.Add("@nError", SqlDbType.Int);
			_oParameter.Direction = ParameterDirection.InputOutput;
			_oParameter.Value = 0;
			
			_oParameter = _oCommand.Parameters.Add("@cErrorText", SqlDbType.VarChar, 200);
			_oParameter.Direction = ParameterDirection.InputOutput;
			_oParameter.Value = "";

			#endregion

			try
			{
				_Connect.Open();
				_oCommand.ExecuteScalar();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -10;
				_ErrorStr = "Ошибка при удалении операции...\r\n" + ex.Message;
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
					_ErrorStr = "Ошибка при удалении операции...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		#endregion Delete

		#region SalaryTariffs

		public bool FillTableSalaryTariffs() 
		{
			return(FillTableSalaryTariffs(null, null));
		}

		public bool FillTableSalaryTariffs(int? nSalaryTariffID)
		{
			return (FillTableSalaryTariffs(nSalaryTariffID, null));
		}

		public bool FillTableSalaryTariffs(DateTime? dDate)
		{
			return (FillTableSalaryTariffs(null, dDate));
		}

		public bool FillTableSalaryTariffs(int? nSalaryTariffID, DateTime? dDate)
		{
			if (_DS.Tables["TableSalaryTariffs"] != null)
				_DS.Tables.Remove("TableSalaryTariffs");

			string sqlSelect = "execute up_SalaryTariffsFill @nID, @dDate";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			SqlParameter _oParameter = _oCommand.Parameters.Add("@nID", SqlDbType.Int);
			if (nSalaryTariffID.HasValue)
				_oParameter.Value = nSalaryTariffID;
			else
				_oParameter.Value = DBNull.Value;
			
			_oParameter = _oCommand.Parameters.Add("@dDate", SqlDbType.SmallDateTime);
			if (dDate.HasValue)
				_oParameter.Value = dDate;
			else
				_oParameter.Value = DBNull.Value;

			try
			{
				_TableSalaryTariffs = FillReadings(new SqlDataAdapter(_oCommand), _TableSalaryTariffs, "TableSalaryTariffs");
			}
			catch (Exception ex)
			{
				_ErrorNumber = -51;
				_ErrorStr = "Ошибка при получении списка тарифов на работы для расчета зарплаты..." + Convert.ToChar(13) + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		#region Save Tariffs 

		public bool SaveTariffs(ref int? nSalaryTariffID)
		{
			String _sqlCommand = "execute up_SalaryTariffsSave @nID output, " +
					"@nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(_sqlCommand, _Connect);

			#region up_SalaryTariffsSave parameters

			SqlParameter _oParameter = _oCommand.Parameters.Add("@nID", SqlDbType.Int);
			if (nSalaryTariffID.HasValue)
				_oParameter.Value = nSalaryTariffID;
			else
				_oParameter.Value = DBNull.Value;
			_oParameter.Direction = ParameterDirection.InputOutput;

			_oParameter = _oCommand.Parameters.Add("@nError", SqlDbType.Int);
			_oParameter.Direction = ParameterDirection.InputOutput;
			_oParameter.Value = 0;
			
			_oParameter = _oCommand.Parameters.Add("@cErrorText", SqlDbType.VarChar, 200);
			_oParameter.Direction = ParameterDirection.InputOutput;
			_oParameter.Value = "";

			#endregion

			try
			{
				_Connect.Open();
				RFMUtilities.DataTableToTempTable(TableSalaryTariffs, "#SalaryTariffs", _Connect);
				_oCommand.ExecuteScalar();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -52;
				_ErrorStr = "Ошибка при сохранении тарифов...\r\n" + ex.Message;
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
					_ErrorStr = "Ошибка при сохранении тарифов...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
				// при создании новой записи - получим ее код
				if (nSalaryTariffID == 0 && _oCommand.Parameters["@nID"].Value != DBNull.Value)
				{
					nSalaryTariffID = (int)_oCommand.Parameters["@nID"].Value;
				}
			}
			return (_ErrorNumber == 0);
		}

		#endregion Save Tariffs 

		#region Delete Tariffs 

		public bool DeleteTariffs(int nSalaryTariffID)
		{
			String _sqlCommand = "execute up_SalaryTariffsDelete @nID, " +
					"@nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(_sqlCommand, _Connect);

			#region up_SalaryTariffsDelete parameters

			SqlParameter _oParameter = _oCommand.Parameters.Add("@nID", SqlDbType.Int);
			_oParameter.Value = nSalaryTariffID;

			_oParameter = _oCommand.Parameters.Add("@nError", SqlDbType.Int);
			_oParameter.Direction = ParameterDirection.InputOutput;
			_oParameter.Value = 0;
			
			_oParameter = _oCommand.Parameters.Add("@cErrorText", SqlDbType.VarChar, 200);
			_oParameter.Direction = ParameterDirection.InputOutput;
			_oParameter.Value = "";

			#endregion

			try
			{
				_Connect.Open();
				_oCommand.ExecuteScalar();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -22;
				_ErrorStr = "Ошибка при удалении тарифов...\r\n" + ex.Message;
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
					_ErrorStr = "Ошибка при удалении тарифов...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		#endregion Delete Tariffs 

		#endregion

	}
}
