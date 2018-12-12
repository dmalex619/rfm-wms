using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

using RFMPublic;

/// <summary>
/// ������-������ ����� (Shift)
/// </summary>
namespace WMSBizObjects
{
    public class Shift : BizObject
    {
        protected string _IDList;
        /// <summary>
        /// ������ ID ���� (Shifts.ID)
        /// </summary>
        [Description("������ ID ���� (Shifts.ID)")]
        public string IDList { get { return _IDList; } set { _IDList = value; _NeedRequery = true; } }

        // �������
        #region Filters

        protected DateTime? _FilterDateBeg;
        /// <summary>
        /// ������-����: ��������� ���� ������� (Shifts.DateBeg)
        /// </summary>
        [Description("������-����: ��������� ���� ������� (Shifts.DateBeg)")]
        public DateTime? FilterDateBeg { get { return _FilterDateBeg; } set { _FilterDateBeg = value; } }
        protected DateTime? _FilterDateEnd;
        /// <summary>
        /// ������-����: �������� ���� �������  (Shifts.DateEnd)
        /// </summary>
        [Description("������-����: �������� ���� ������� (Shifts.DateEnd)")]
        public DateTime? FilterDateEnd { get { return _FilterDateEnd; } set { _FilterDateEnd = value; } }

        protected string _FilterMajorsList;
        /// <summary>
        /// ������-����: ������ ������� ����������� � ����� (Shifts.MajorID), ����� �������
        /// </summary>
        [Description("������-����: ������ ������� ����������� � ����� (Shifts.MajorID), ����� �������")]
        public string FilterMajorsList { get { return _FilterMajorsList; } set { _FilterMajorsList = value; } }

        protected bool? _FilterIsNight;
        /// <summary>
        /// ������-����: ������� �������/������ ����� (Shifts.IsNight)
        /// </summary>
        [Description("������-����: ������� �������/������ ����� (Shifts.IsNight)")]
        public bool? FilterIsNight { get { return _FilterIsNight; } set { _FilterIsNight = value; } }

        #endregion Filters

        public Shift() : base()
		{
			_MainTableName = "Shifts";
		}

		#region FillData

		/// <summary>
        /// ��������� ������ ���� (MainTable)
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
				_ErrorStr = "������ ��� ������ ����..." + Convert.ToChar(13) + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// ������� ������-�����
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
		/// ���������� �����
		/// </summary>
		public bool SaveData(int nShiftID)
		{
			if (_MainTable.Rows.Count == 0 || _MainTable.Rows[0] == null)
			{
				_ErrorNumber = -20;
				_ErrorStr = "��� ������ ��� ���������� �����...";
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
				_ErrorStr = "������ ��� ���������� �����...\r\n" + ex.Message;
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
                    _ErrorStr = "������ ��� ���������� �����...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
				// ��� �������� ����� ����� - ������� �� ���
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
        /// �������� �����
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
				_ErrorStr = "������ ��� �������� �����...\r\n" + ex.Message;
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
                    _ErrorStr = "������ ��� �������� �����...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		#endregion Delete

    }
}
