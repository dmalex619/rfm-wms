using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using System.IO;

using RFMPublic;

/// <summary>
/// ������-������ ����� �������� (CellContentSnapshot)
/// </summary>
namespace WMSBizObjects
{
	public class CellContentSnapshot : BizObject
	{
		protected string _IDList;
		/// <summary>
		/// ������ ID (CellsContentsSnapshots.ID)
		/// </summary>
		[Description("������ ID (CellsContentsSnapshots.ID)")]
		public string IDList { get { return _IDList; } set { _IDList = value; _NeedRequery = true; } }

		// �������

		protected DateTime? _FilterDateBeg;
		/// <summary>
		/// ������-����: ��������� ���� (CellsContentsSnapshots.DateBeg)
		/// </summary>
		[Description("������-����: ��������� ���� (CellsContentsSnapshots.DateBeg)")]
		public DateTime? FilterDateBeg { get { return _FilterDateBeg; } set { _FilterDateBeg = value; _NeedRequery = true; } }

		protected DateTime? _FilterDateEnd;
		/// <summary>
		/// ������-����: �������� ���� (CellsContentsSnapshots.DateEnd)
		/// </summary>
		[Description("������-����: �������� ���� (CellsContentsSnapshots.DateEnd)")]
		public DateTime? FilterDateEnd { get { return _FilterDateEnd; } set { _FilterDateEnd = value; _NeedRequery = true; } }

		protected bool? _FilterIsClosed;
		/// <summary>
		/// ������-����: ����� ������� (CellsContentsSnapshots.DateEnd is not Null)?
		/// </summary>
		[Description("������-����: ����� ������� (CellsContentsSnapshots.DateEnd is not Null)?")]
		public bool? FilterIsClosed { get { return _FilterIsClosed; } set { _FilterIsClosed = value; _NeedRequery = true; } }

		// ������� ��� ����������� ��������

		protected string _FilterCellsList;
		/// <summary>
		/// ������-����: ������ ����� (CellsContentsSnapshotsBeg|End.CellID), ����� �������
		/// </summary>
		[Description("������-����: ������ ����� (CellsContentsSnapshotsBeg|End.CellID), ����� �������")]
		public string FilterCellsList { get { return _FilterCellsList; } set { _FilterCellsList = value; _NeedRequery = true; } }

		protected string _FilterOwnersList;
		/// <summary>
		/// ������-����: ������ ���������� ������ (CellsContentsSnapshotsBeg|End.OwnerID), ����� �������
		/// </summary>
		[Description("������-����: ������ ���������� ������ (CellsContentsSnapshotsBeg|End.OwnerID), ����� �������")]
		public string FilterOwnersList { get { return _FilterOwnersList; } set { _FilterOwnersList = value; _NeedRequery = true; } }

		protected string _FilterGoodsStatesList;
		/// <summary>
		/// ������-����: ������ ��������� ������ (CellsContentsSnapshotsBeg|End.GoodStateID), ����� �������
		/// </summary>
		[Description("������-����: ������ ��������� ������ (CellsContentsSnapshotsBeg|End.GoodStateID), ����� �������")]
		public string FilterGoodsStatesList { get { return _FilterGoodsStatesList; } set { _FilterGoodsStatesList = value; _NeedRequery = true; } }

		protected string _FilterPackingsList;
		/// <summary>
		/// ������-����: ������ ID �������� (CellsContentsSnapshotsBeg|End.PackingID), ����� �������
		/// </summary>
		[Description("������-����: ������ ID �������� (CellsContentsSnapshotsBeg|End.PackingID), ����� �������")]
		public string FilterPackingsList { get { return _FilterPackingsList; } set { _FilterPackingsList = value; _NeedRequery = true; } }

		// �������

		protected DataTable _TableCellsContentsSnapshotsDetails;
		/// <summary>
		/// ����������� ����� �������� �� �������/�������
		/// </summary>
		[Description("����������� ����� �������� �� �������/�������")]
		public DataTable TableCellsContentsSnapshotsDetails { get { return _TableCellsContentsSnapshotsDetails; } }

        protected DataTable _TablePrepareInventoryAct;
        /// <summary>
        /// ������ ������� ��� ��������������� ����������� �� ����������� ��������������
        /// </summary>
        [Description("������ ������� ��� ��������������� ����������� �� ����������� ��������������")]
        public DataTable TablePrepareInventoryAct { get { return _TablePrepareInventoryAct; } }

		// -------------------------------------

		public CellContentSnapshot()
			: base()
		{
			_MainTableName = "CellsContentsSnapshots";

		}

		/// <summary>
		/// ��������� ������ �������� (MainTable)
		/// </summary>
		public override bool FillData()
		{
			ClearData();

			string sqlSelect = "execute up_CellsContentsSnapshotsFill " +
					"@nID, @cIDList, " +
					"@bClosed, " +
					"@dDateBeg, @dDateEnd";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_CellsContentsSnapshotsFill parameters

			SqlParameter oParameter = _oCommand.Parameters.Add("@nID", SqlDbType.Int);
			if (_ID.HasValue)
				oParameter.Value = _ID;
			else
				oParameter.Value = DBNull.Value;

			oParameter = _oCommand.Parameters.Add("@cIDList", SqlDbType.VarChar);
			if (_IDList != null)
				oParameter.Value = _IDList;
			else
				oParameter.Value = DBNull.Value;

			oParameter = _oCommand.Parameters.Add("@bClosed", SqlDbType.Bit);
			if (_FilterIsClosed != null)
				oParameter.Value = _FilterIsClosed;
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

			#endregion

			try
			{
				_MainTable = FillReadings(new SqlDataAdapter(_oCommand), _MainTable, _MainTableName);
				_NeedRequery = false;
			}
			catch (Exception ex)
			{
				_ErrorNumber = -1;
				_ErrorStr = "������ ��� ��������� ������ ����� ��������...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// ������� ������-�����
		/// </summary>
		public void ClearFilters()
		{
			_FilterIsClosed = null;
			_FilterDateBeg = null;
			_FilterDateEnd = null;

			_FilterCellsList = null;
			_FilterOwnersList = null;
			_FilterGoodsStatesList = null;
			_FilterPackingsList = null;
			//_NeedRequery = true;
		}

		/// <summary>
		/// ��������� ������� ����������� ������� �������� (TableCellsContentsSnapshotsDetails)
		/// </summary>
		public bool FillTableCellsContentsSnapshotsDetails(
			int nID, int nGroupBy, 
			bool bExcludeLostFoundBeg, bool bExcludeLostFoundEnd, 
			bool bDiffOnly, bool bInInventoryOnly)
		{
			string sqlSelect = "execute up_CellsContentsSnapshotsDetailsFill " +
				"@nID, " +
				"@nGroupBy, " +
				"@bExcludeLostFoundBeg, @bExcludeLostFoundEnd, " +
				"@bDiffOnly, " + 
				"@bInInventoryOnly, " + 
				"@cCellsList, " +
				"@cOwnersList, " +
				"@cGoodsStatesList, " +
				"@cPackingsList";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_CellsContentsSnapshotsDetailsFill parameters

			SqlParameter oParameter = _oCommand.Parameters.Add("@nID", SqlDbType.Int);
			oParameter.Value = nID;

			oParameter = _oCommand.Parameters.Add("@nGroupBy", SqlDbType.Int);
			oParameter.Value = nGroupBy;

			oParameter = _oCommand.Parameters.Add("@bExcludeLostFoundBeg", SqlDbType.Bit);
			oParameter.Value = bExcludeLostFoundBeg;

			oParameter = _oCommand.Parameters.Add("@bExcludeLostFoundEnd", SqlDbType.Bit);
			oParameter.Value = bExcludeLostFoundEnd;

			oParameter = _oCommand.Parameters.Add("@bDiffOnly", SqlDbType.Bit);
			oParameter.Value = bDiffOnly;

			oParameter = _oCommand.Parameters.Add("@bInInventoryOnly", SqlDbType.Bit);
			oParameter.Value = bInInventoryOnly;

			oParameter = _oCommand.Parameters.Add("@cCellsList", SqlDbType.VarChar);
			if (_FilterCellsList != null)
				oParameter.Value = _FilterCellsList;
			else
				oParameter.Value = DBNull.Value;

			oParameter = _oCommand.Parameters.Add("@cOwnersList", SqlDbType.VarChar);
			if (_FilterOwnersList != null)
				oParameter.Value = _FilterOwnersList;
			else
				oParameter.Value = DBNull.Value;

			oParameter = _oCommand.Parameters.Add("@cGoodsStatesList", SqlDbType.VarChar);
			if (_FilterGoodsStatesList != null)
				oParameter.Value = _FilterGoodsStatesList;
			else
				oParameter.Value = DBNull.Value;

			oParameter = _oCommand.Parameters.Add("@cPackingsList", SqlDbType.VarChar);
			if (_FilterPackingsList != null)
				oParameter.Value = _FilterPackingsList;
			else
				oParameter.Value = DBNull.Value;

			#endregion

			try
			{
				_TableCellsContentsSnapshotsDetails = FillReadings(new SqlDataAdapter(_oCommand), _TableCellsContentsSnapshotsDetails, "TableCellsContentsSnapshotsDetails");
				_NeedRequery = false;
			}
			catch (Exception ex)
			{
				_ErrorNumber = -1;
				_ErrorStr = "������ ��� ��������� ����������� ����� ��������...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

        /// <summary>
        /// ��������� ������ ������� ��� ��������������� ����������� �� ����������� ��������������
        /// </summary>
        public bool FillTablePrepareInventoryAct(int nID, string sHostsIDList, string sGoodsStatesIDList, string sPackingsIDList)
        {
            string sqlSelect = "execute up_CellsContentsSnapshotsPrepareInventoryAct " +
                "@nID, @cHostsList, @cGoodsStatesList, @cPackingsList";
            SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

            #region up_CellsContentsSnapshotsPrepareInventoryAct parameters

            SqlParameter oParameter = _oCommand.Parameters.Add("@nID", SqlDbType.Int);
            oParameter.Value = nID;

            oParameter = _oCommand.Parameters.Add("@cHostsList", SqlDbType.VarChar);
            oParameter.Value = sHostsIDList;
            oParameter = _oCommand.Parameters.Add("@cGoodsStatesList", SqlDbType.VarChar);
            oParameter.Value = sGoodsStatesIDList;
            oParameter = _oCommand.Parameters.Add("@cPackingsList", SqlDbType.VarChar);
            oParameter.Value = sPackingsIDList;

            #endregion

            try
            {
                _TablePrepareInventoryAct = FillReadings(new SqlDataAdapter(_oCommand), _TablePrepareInventoryAct, "TablePrepareInventoryAct");
                _NeedRequery = false;
            }
            catch (Exception ex)
            {
                _ErrorNumber = -1;
                _ErrorStr = "������ ��� ��������� ������ ������� ��� �����������...\r\n" + ex.Message;
                RFMMessage.MessageBoxError(_ErrorStr);
            }
            return (_ErrorNumber == 0);
        }

        public bool SaveInventoryAct(int nID, string sXML, string TableName)
        {
            string sqlSelect = "execute up_AuditActsCreateFromInventoryAct " +
                "@nID, @cXML, @cElementName, @nError output, @cErrorText output";
            SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

            #region up_AuditActsCreateFromInventoryAct parameters

            SqlParameter oParameter = _oCommand.Parameters.Add("@nID", SqlDbType.Int);
            oParameter.Value = nID;

            oParameter = _oCommand.Parameters.Add("@cXML", SqlDbType.VarChar);
            oParameter.Value = sXML;
            oParameter = _oCommand.Parameters.Add("@cElementName", SqlDbType.VarChar);
            oParameter.Value = TableName;

            oParameter = _oCommand.Parameters.Add("@nError", SqlDbType.Int);
            oParameter.Direction = ParameterDirection.InputOutput;
            oParameter.Value = 0;

            oParameter = _oCommand.Parameters.Add("@cErrorText", SqlDbType.VarChar, 200);
            oParameter.Direction = ParameterDirection.InputOutput;
            oParameter.Value = "";
            #endregion

            try
            {
                _oCommand.Connection.Open();
                _oCommand.ExecuteNonQuery();
                _oCommand.Connection.Close();
            }
            catch (Exception ex)
            {
                _ErrorNumber = -1;
                _ErrorStr = "������ ��� ��������� ������ ������� ��� �����������...\r\n" + ex.Message;
                RFMMessage.MessageBoxError(_ErrorStr);
            }
            if (_ErrorNumber == 0)
            {
                _ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
                if (_ErrorNumber != 0)
                {
                    _ErrorStr = "������ ��� ���������� �����...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
                    RFMMessage.MessageBoxError(_ErrorStr);
                }
            }
            return (_ErrorNumber == 0);
        }

		#region Create, Close

		/// <summary>
		/// �������� ����� �����
		/// </summary>
		public bool Create(int nID, int nUserID, string sNote)
		{
			string _sqlCommand = "execute up_CellsContentsSnapshotsCreate @nID output, " +
					"@nUserID, " +
					"@cNote, " +
					"@nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(_sqlCommand, _Connect);

			#region up_CellsContentsSnapshotsCreate  parameters

			SqlParameter _oParameter = _oCommand.Parameters.Add("@nID", SqlDbType.Int);
			_oParameter.Direction = ParameterDirection.InputOutput;
			_oParameter.Value = DBNull.Value;

			_oParameter = _oCommand.Parameters.Add("@nUserID", SqlDbType.Int);
			_oParameter.Value = nUserID;

			_oParameter = _oCommand.Parameters.Add("@cNote", SqlDbType.VarChar);
			_oParameter.Value = sNote;

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
				_ErrorStr = "������ ��� �������� ����� ��������...\r\n" + ex.Message;
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
					_ErrorStr = "������ ��� �������� ����� ��������...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
				// ������� ��� ��������� �����
				if (nID == 0 && _oCommand.Parameters["@nID"].Value != DBNull.Value)
				{
					_ID = (int)_oCommand.Parameters["@nID"].Value;
				}
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// �������� �����
		/// </summary>
		public bool Close(int nID, int nUserID)
		{
			string _sqlCommand = "execute up_CellsContentsSnapshotsClose @nID, " +
					"@nUserID, " +
					"@nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(_sqlCommand, _Connect);

			#region up_CellsContentsSnapshotsClose  parameters

			SqlParameter _oParameter = _oCommand.Parameters.Add("@nID", SqlDbType.Int);
			_oParameter.Value = nID;

			_oParameter = _oCommand.Parameters.Add("@nUserID", SqlDbType.Int);
			_oParameter.Value = nUserID;

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
				_ErrorNumber = -11;
				_ErrorStr = "������ ��� �������� ����� ��������...\r\n" + ex.Message;
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
					_ErrorStr = "������ ��� �������� ����� ��������...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		#endregion Create, Close

		#region Cells Inputs|Outputs Clear

		/// <summary>
		/// ������� ��������� ����� 
		/// </summary>
		public bool CellsForInputsClear(int? nUserID)
		{
			string _sqlCommand = "execute up_CellsForInputsClear @nUserID, " +
					"@nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(_sqlCommand, _Connect);

			#region up_CellsForInputsClear parameters

			SqlParameter _oParameter = _oCommand.Parameters.Add("@nUserID", SqlDbType.Int);
			if (nUserID.HasValue)
				_oParameter.Value = nUserID;
			else
				_oParameter.Value = DBNull.Value;

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
				_ErrorNumber = -51;
				_ErrorStr = "������ ��� ������� \"�������\" ��������� �����...\r\n" + ex.Message;
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
					_ErrorStr = "������ ��� \"�������\" ��������� �����...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// ������� ��������� ����� 
		/// </summary>
		public bool CellsForOutputsClear(int? nUserID)
		{
			string _sqlCommand = "execute up_CellsForOutputsClear @nUserID, " +
					"@nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(_sqlCommand, _Connect);

			#region up_CellsForOutputsClear parameters

			SqlParameter _oParameter = _oCommand.Parameters.Add("@nUserID", SqlDbType.Int);
			if (nUserID.HasValue)
				_oParameter.Value = nUserID;
			else
				_oParameter.Value = DBNull.Value;

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
				_ErrorNumber = -51;
				_ErrorStr = "������ ��� ������� \"�������\" ����� ��������...\r\n" + ex.Message;
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
					_ErrorStr = "������ ��� \"�������\" ����� ��������...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		#endregion Cells Inputs|Outputs Clear

	}
}
