using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

using RFMPublic;

/// <summary>
/// Бизнес-объект смена (Shift)
/// </summary>
namespace WMSBizObjects
{
    public class Shift : BizObject
    {
        protected string _IDList;
        /// <summary>
        /// Список ID смен (Shifts.ID)
        /// </summary>
        [Description("Список ID смен (Shifts.ID)")]
        public string IDList { get { return _IDList; } set { _IDList = value; _NeedRequery = true; } }

        // Фильтры
        #region Filters

        protected DateTime? _FilterDateBeg;
        /// <summary>
        /// Фильтр-поле: Начальная дата периода (Shifts.DateBeg)
        /// </summary>
        [Description("Фильтр-поле: Начальная дата периода (Shifts.DateBeg)")]
        public DateTime? FilterDateBeg { get { return _FilterDateBeg; } set { _FilterDateBeg = value; } }
        protected DateTime? _FilterDateEnd;
        /// <summary>
        /// Фильтр-поле: Конечная дата периода  (Shifts.DateEnd)
        /// </summary>
        [Description("Фильтр-поле: Конечная дата периода (Shifts.DateEnd)")]
        public DateTime? FilterDateEnd { get { return _FilterDateEnd; } set { _FilterDateEnd = value; } }

        protected string _FilterMajorsList;
        /// <summary>
        /// Фильтр-поле: Список старших сотрудников в смене (Shifts.MajorID), через запятую
        /// </summary>
        [Description("Фильтр-поле: Список старших сотрудников в смене (Shifts.MajorID), через запятую")]
        public string FilterMajorsList { get { return _FilterMajorsList; } set { _FilterMajorsList = value; } }

        protected bool? _FilterIsNight;
        /// <summary>
        /// Фильтр-поле: признак дневной/ночной смены (Shifts.IsNight)
        /// </summary>
        [Description("Фильтр-поле: признак дневной/ночной смены (Shifts.IsNight)")]
        public bool? FilterIsNight { get { return _FilterIsNight; } set { _FilterIsNight = value; } }

        #endregion Filters

        public Shift() : base()
		{
			_MainTableName = "Shifts";
		}

		#region FillData

		/// <summary>
        /// получение списка смен (MainTable)
		/// </summary>
		public override bool FillData()
		{
			ClearData();

            string sqlSelect = "execute up_ShiftsFill " + 
				"@nID, @cIDList, " + 
				"@dDateBeg, @dDateEnd, " + 
				"@cMajorsList, " +
                "@bIsNight";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

            #region up_ShiftsFill parameters

            _oCommand.Parameters.Add("@nID", SqlDbType.Int);
			if (ID != null)
				_oCommand.Parameters["@nID"].Value = ID;
			else
				_oCommand.Parameters["@nID"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cIDList", SqlDbType.VarChar);
			if (_IDList != null)
				_oCommand.Parameters["@cIDList"].Value = _IDList;
			else
				_oCommand.Parameters["@cIDList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@dDateBeg", SqlDbType.SmallDateTime);
			if (_FilterDateBeg != null)
				_oCommand.Parameters["@dDateBeg"].Value = _FilterDateBeg;
			else
				_oCommand.Parameters["@dDateBeg"].Value = DBNull.Value;
			_oCommand.Parameters.Add("@dDateEnd", SqlDbType.SmallDateTime);
			if (_FilterDateEnd != null)
				_oCommand.Parameters["@dDateEnd"].Value = _FilterDateEnd;
			else
				_oCommand.Parameters["@dDateEnd"].Value = DBNull.Value;

            _oCommand.Parameters.Add("@cMajorsList", SqlDbType.VarChar);
			if (_FilterMajorsList != null)
                _oCommand.Parameters["@cMajorsList"].Value = _FilterMajorsList;
			else
                _oCommand.Parameters["@cMajorsList"].Value = DBNull.Value;

            _oCommand.Parameters.Add("@bIsNight", SqlDbType.Bit);
            if (_FilterIsNight != null)
                _oCommand.Parameters["@bIsNight"].Value = _FilterIsNight;
            else
                _oCommand.Parameters["@bIsNight"].Value = DBNull.Value;

			#endregion

			try
			{
				_MainTable = FillReadings(new SqlDataAdapter(_oCommand), _MainTable, _MainTableName);
			}
			catch (Exception ex)
			{
				_ErrorNumber = -1;
				_ErrorStr = "Ошибка при списка смен..." + Convert.ToChar(13) + ex.Message;
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
            _FilterMajorsList = null;
            _FilterIsNight = null;
			//_NeedRequery = false;
		}

		#endregion FillData

		#region Save

		/// <summary>
		/// сохранение смены
		/// </summary>
		public bool SaveData(int nShiftID)
		{
			if (_MainTable.Rows.Count == 0 || _MainTable.Rows[0] == null)
			{
				_ErrorNumber = -20;
				_ErrorStr = "Нет данных для сохранения смены...";
				RFMMessage.MessageBoxError(_ErrorStr);
				return (false);
			}

			DataRow r = _MainTable.Rows[0];

            String _sqlCommand = "execute up_ShiftsSave @nShiftID output, " +
                    "@dDateBeg, @dDateEnd, " +
					"@nMajorID, " +
					"@bIsNight, " +  
					"@cNote, " +
					"@nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(_sqlCommand, _Connect);

			#region up_ShiftsSave parameters

            SqlParameter _oParameter = _oCommand.Parameters.Add("@nShiftID", SqlDbType.Int);
			_oParameter.Value = nShiftID;
			_oParameter.Direction = ParameterDirection.InputOutput;

            _oParameter = _oCommand.Parameters.Add("@dDateBeg", SqlDbType.DateTime);
            _oParameter.Value = DateTime.Parse(r["DateBeg"].ToString());
            _oParameter = _oCommand.Parameters.Add("@dDateEnd", SqlDbType.DateTime);
            _oParameter.Value = DateTime.Parse(r["DateEnd"].ToString());

			_oParameter = _oCommand.Parameters.Add("@nMajorID", SqlDbType.Int);
            _oParameter.Value = Convert.ToInt32(r["MajorID"]);

            _oParameter = _oCommand.Parameters.Add("@bIsNight", SqlDbType.Bit);
            _oParameter.Value = Convert.ToInt32(r["IsNight"]);

			_oParameter = _oCommand.Parameters.Add("@cNote", SqlDbType.VarChar);
			_oParameter.Value = r["Note"].ToString();

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
				_ErrorStr = "Ошибка при сохранении смены...\r\n" + ex.Message;
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
                    _ErrorStr = "Ошибка при сохранении смены...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
				// при создании новой смены - получим ее код
                if (nShiftID == 0 && _oCommand.Parameters["@nShiftID"].Value != DBNull.Value)
				{
                    _ID = (int)_oCommand.Parameters["@nShiftID"].Value;
				}
			}
			return (_ErrorNumber == 0);
		}

		#endregion Save

		#region Delete

		/// <summary>
        /// удаление смены
		/// </summary>
		public bool DeleteData(int nShiftID)
		{
            String _sqlCommand = "execute up_ShiftsDelete @nShiftID, " +
					"@nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(_sqlCommand, _Connect);

			#region up_ShiftsDelete parameters

            SqlParameter _oParameter = _oCommand.Parameters.Add("@nShiftID", SqlDbType.Int);
			_oParameter.Value = nShiftID;

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
				_ErrorStr = "Ошибка при удалении смены...\r\n" + ex.Message;
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
                    _ErrorStr = "Ошибка при удалении смены...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		#endregion Delete

    }
}
