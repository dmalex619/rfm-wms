using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

using RFMPublic;

/// <summary>
/// ������-������ ������� (��������) �� ����������� �������/���� (�������) (TrafficGood)
/// </summary>
namespace WMSBizObjects
{
	public class TrafficGood : BizObject
	{
		protected string _IDList;
		/// <summary>
		/// ������ ID ������� �� ����������� �������/���� (TrafficsGoods.ID)
		/// </summary>
		[Description("������ ID ������� �� ����������� �������/���� (TrafficsGoods.ID)")]
		public string IDList { get { return _IDList; } set { _IDList = value; _NeedRequery = true; } }

		protected string _BarCode;
		/// <summary>
		/// �����-��� ������� (TrafficsGoods.BarCode), ��������
		/// </summary>
		[Description("�����-��� ������� (TrafficsGoods.BarCode), ��������")]
		public string BarCode { get { return _BarCode; } set { _BarCode = value; _NeedRequery = true; } }

		// �������

		protected DateTime? _FilterDataBeg;
		/// <summary>
		/// ������-����: ��������� ���� ������� (TrafficsGoods.DateBirth)
		/// </summary>
		[Description("������-����: ��������� ���� �������")]
		public DateTime? FilterDateBeg { get { return _FilterDataBeg; } set { _FilterDataBeg = value; _NeedRequery = true; } }

		protected DateTime? _FilterDataEnd;
		/// <summary>
		/// ������-����: �������� ���� ������� (TrafficsGoods.DateBirth)
		/// </summary>
		[Description("������-����: �������� ���� �������")]
		public DateTime? FilterDateEnd { get { return _FilterDataEnd; } set { _FilterDataEnd = value; _NeedRequery = true; } }

		protected string _FilterUsersList;
		/// <summary>
		/// ������-����: ������ ID ������������� (TrafficsGoods.UserID), ����� �������
		/// </summary>
		[Description("������-����: ������ ID ������������� (TrafficsGoods.UserID), ����� �������")]
		public string FilterUsersList { get { return _FilterUsersList; } set { _FilterUsersList = value; _NeedRequery = true; } }

		protected string _FilterDevicesList;
		/// <summary>
		/// ������-����: ������ ID ��������� (TrafficsGoods.DeviceID), ����� �������
		/// </summary>
		[Description("������-����: ������ ID ��������� (TrafficsGoods.DeviceID), ����� �������")]
		public string FilterDevicesList { get { return _FilterDevicesList; } set { _FilterDevicesList = value; _NeedRequery = true; } }

		protected string _FilterCellsSourceList;
		/// <summary>
		/// ������-����: ������ ID �����-���������� (TrafficsGoods.CellSourceID), ����� �������
		/// </summary>
		[Description("������-����: ������ ID �����-���������� (TrafficsGoods.CellSourceID), ����� �������")]
		public string FilterCellsSourceList { get { return _FilterCellsSourceList; } set { _FilterCellsSourceList = value; _NeedRequery = true; } }

		protected string _FilterCellsTargetList;
		/// <summary>
		/// ������-����: ������ ID �����-���������� (TrafficsGoods.CellTargetID), ����� �������
		/// </summary>
		[Description("������-����: ������ ID �����-���������� (TrafficsGoods.CellTargetID), ����� �������")]
		public string FilterCellsTargetList { get { return _FilterCellsTargetList; } set { _FilterCellsTargetList = value; _NeedRequery = true; } }

		protected string _FilterStoresZonesSourceList;
		/// <summary>
		/// ������-����: ������ ID ��������� ���-���������� (TrafficsGoods.CellSourceID - Cells.StoreZoneID), ����� �������
		/// </summary>
		[Description("������-����: ������ ID ��������� ���-���������� (TrafficsGoods.CellSourceID - Cells.StoreZoneID), ����� �������")]
		public string FilterStoresZonesSourceList { get { return _FilterStoresZonesSourceList; } set { _FilterStoresZonesSourceList = value; _NeedRequery = true; } }

		protected string _FilterStoresZonesTargetList;
		/// <summary>
		/// ������-����: ������ ID ��������� ���-���������� (TrafficsGoods.CellTargetID -> Cells.StoreZoneID), ����� �������
		/// </summary>
		[Description("������-����: ������ ID ��������� ���-���������� (TrafficsGoods.CellTargetID -> Cells.StoreZoneID), ����� �������")]
		public string FilterStoresZonesTargetList { get { return _FilterStoresZonesTargetList; } set { _FilterStoresZonesTargetList = value; _NeedRequery = true; } }

		protected string _FilterStoresZonesTypesSourceList;
		/// <summary>
		/// ������-����: ������ ID ����� ��������� ���-���������� (TrafficsGoods.CellSourceID -> Cells.StoreZoneID -> StoresZones.StoreZoneTypeID), ����� �������
		/// </summary>
		[Description("������-����: ������ ID ����� ��������� ���-���������� (TrafficsGoods.CellSourceID -> Cells.StoreZoneID -> StoresZones.StoreZoneTypeID), ����� �������")]
		public string FilterStoresZonesTypesSourceList { get { return _FilterStoresZonesTypesSourceList; } set { _FilterStoresZonesTypesSourceList = value; _NeedRequery = true; } }

		protected string _FilterStoresZonesTypesTargetList;
		/// <summary>
		/// ������-����: ������ ID ����� ��������� ���-���������� (TrafficsGoods.CellTargetID -> Cells.StoreZoneID -> StoresZones.StoreZoneTypeID), ����� �������
		/// </summary>
		[Description("������-����: ������ ID ����� ��������� ���-���������� (TrafficsGoods.CellTargetID -> Cells.StoreZoneID -> StoresZones.StoreZoneTypeID), ����� �������")]
		public string FilterStoresZonesTypesTargetList { get { return _FilterStoresZonesTypesTargetList; } set { _FilterStoresZonesTypesTargetList = value; _NeedRequery = true; } }

		protected bool? _FilterConfirmed;
		/// <summary>
		/// ������-����: ������� ��������� (TrafficsGoods.DateConfirm)?
		/// </summary>
		[Description("������-����: ������� ��������� (TrafficsGoods.DateConfirm)?")]
		public bool? FilterConfirmed { get { return _FilterConfirmed; } set { _FilterConfirmed = value; _NeedRequery = true; } }

        protected bool? _FilterPrinted;
        /// <summary>
        /// ������-����: ������� ����������� (TrafficsGoods.DatePrint)?
        /// </summary>
        [Description("������-����: ������� ����������� (TrafficsGoods.DatePrint)?")]
        public bool? FilterPrinted { get { return _FilterPrinted; } set { _FilterPrinted = value; _NeedRequery = true; } }

        protected bool? _FilterCritical;
		/// <summary>
		/// ������-����: ����� ������� ��� ��������� ��������������� (TrafficsGoods.Critical)?
		/// </summary>
		[Description("������-����: ����� ������� ��� ��������� ��������������� (TrafficsGoods.Critical)?")]
		public bool? FilterCritical { get { return _FilterCritical; } set { _FilterCritical = value; _NeedRequery = true; } }

		protected bool? _FilterSuccess;
		/// <summary>
		/// ������-����: ������� ��������� (TrafficsGoods.Success)?
		/// </summary>
		[Description("������-����: ������� ��������� (TrafficsGoods.Success)?")]
		public bool? FilterSuccess { get { return _FilterSuccess; } set { _FilterSuccess = value; _NeedRequery = true; } }

		protected string _FilterPackingsList;
		/// <summary>
		/// ������-����: ������ ID �������� (TrafficsGoods.PackingID), ����� �������
		/// </summary>
		[Description("������-����: ������ ID �������� (TrafficsGoods.PackingID), ����� �������")]
		public string FilterPackingsList { get { return _FilterPackingsList; } set { _FilterPackingsList = value; _NeedRequery = true; } }

		protected string _FilterGoodsList;
		/// <summary>
		/// ������-����: ������ ID ������� (TrafficsGoods.PackingID -> Packings.GoodID), ����� �������
		/// </summary>
		[Description("������-����: ������ ID ������� (TrafficsGoods.PackingID -> Packings.GoodID), ����� �������")]
		public string FilterGoodsList { get { return _FilterGoodsList; } set { _FilterGoodsList = value; _NeedRequery = true; } }

		protected string _FilterInputsList;
		/// <summary>
		/// ������-����: ������ ID �������� (TrafficsGoods.InputID), ����� �������
		/// </summary>
		[Description("������-����: �������� (TrafficsGoods.InputID), ����� �������")]
		public string FilterInputsList { get { return _FilterInputsList; } set { _FilterInputsList = value; _NeedRequery = true; } }

		protected string _FilterOutputsList;
		/// <summary>
		/// ������-����: ������ ID �������� (TrafficsGoods.OutputID), ����� �������
		/// </summary>
		[Description("������-����: �������� (TrafficsGoods.OutputID), ����� �������")]
		public string FilterOutputsList { get { return _FilterOutputsList; } set { _FilterOutputsList = value; _NeedRequery = true; } }

		protected string _FilterMovingsList;
		/// <summary>
		/// ������-����: ������ ID �����.����������� (TrafficsGoods.MovingID), ����� �������
		/// </summary>
		[Description("������-����: �����.����������� (TrafficsGoods.MovingID), ����� �������")]
		public string FilterMovingsList { get { return _FilterMovingsList; } set { _FilterMovingsList = value; _NeedRequery = true; } }

		protected string _FilterFramesList;
		/// <summary>
		/// ������-����: ������ ID �����������, �� ������� ���������� ����������� (TrafficsGoods.FrameID), ����� �������
		/// </summary>
		[Description("������-����: ������ ID �����������, �� ������� ���������� ����������� (TrafficsGoods.FrameID), ����� �������")]
		public string FilterFramesList { get { return _FilterFramesList; } set { _FilterFramesList = value; _NeedRequery = true; } }

		// Tables

		protected DataTable _TableTrafficsGoodsErrors;
		/// <summary>
		/// ������� ������(�������) ��� "�������������" ������������� (TrafficsGoodsErrors)
		/// </summary>
		[Description("������� ������(�������) ��� _�������������_ ������������� (TrafficsGoodsErrors)")]
		public DataTable TableTrafficsGoodsErrors { get { return _TableTrafficsGoodsErrors; } }

		// -------------------------------------

		public TrafficGood() : base()
		{
			_MainTableName = "TrafficsGoods";
		}

		/// <summary>
		/// ��������� ������ ������� �� ����������� �������/���� (MainTable)
		/// </summary>
		public override bool FillData()
		{
			ClearData();

			string sqlSelect = "execute up_TrafficsGoodsFill @nID, @cIDList, " +
				"@bConfirmed, @bSuccess, @bCritical, " +
				"@dDateBeg, @dDateEnd, " +
				"@cUsersList, @cDevicesList, " +
				"@cCellsSourceList, @cCellsTargetList, " +
				"@cStoresZonesSourceList, @cStoresZonesTargetList, " +
				"@cStoresZonesTypesSourceList, @cStoresZonesTypesTargetList, " + 
                "@bPrinted, " + 
				"@cPackingsList, @cGoodsList, " +
				"@cInputsList, @cOutputsList, @cMovingsList, " + 
				"@cFramesList";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_TrafficsGoodsFill parameters

			_oCommand.Parameters.Add("@nID", SqlDbType.Int);
			if (_ID.HasValue)
				_oCommand.Parameters["@nID"].Value = _ID;
			else
				_oCommand.Parameters["@nID"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cIDList", SqlDbType.VarChar);
			if (_IDList != null)
				_oCommand.Parameters["@cIDList"].Value = _IDList;
			else
				_oCommand.Parameters["@cIDList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bConfirmed", SqlDbType.Bit);
			if (_FilterConfirmed.HasValue)
				_oCommand.Parameters["@bConfirmed"].Value = _FilterConfirmed;
			else
				_oCommand.Parameters["@bConfirmed"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bSuccess", SqlDbType.Bit);
			if (_FilterSuccess.HasValue)
				_oCommand.Parameters["@bSuccess"].Value = _FilterSuccess;
			else
				_oCommand.Parameters["@bSuccess"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bCritical", SqlDbType.Bit);
			if (_FilterCritical.HasValue)
				_oCommand.Parameters["@bCritical"].Value = _FilterCritical;
			else
				_oCommand.Parameters["@bCritical"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@dDateBeg", SqlDbType.SmallDateTime);
			if (_FilterDataBeg.HasValue)
				_oCommand.Parameters["@dDateBeg"].Value = _FilterDataBeg;
			else
				_oCommand.Parameters["@dDateBeg"].Value = DBNull.Value;
			_oCommand.Parameters.Add("@dDateEnd", SqlDbType.SmallDateTime);
			if (_FilterDataEnd.HasValue)
				_oCommand.Parameters["@dDateEnd"].Value = _FilterDataEnd;
			else
				_oCommand.Parameters["@dDateEnd"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cUsersList", SqlDbType.VarChar);
			if (_FilterUsersList != null)
				_oCommand.Parameters["@cUsersList"].Value = _FilterUsersList;
			else
				_oCommand.Parameters["@cUsersList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cDevicesList", SqlDbType.VarChar);
			if (_FilterDevicesList != null)
				_oCommand.Parameters["@cDevicesList"].Value = _FilterDevicesList;
			else
				_oCommand.Parameters["@cDevicesList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cCellsSourceList", SqlDbType.VarChar);
			if (_FilterCellsSourceList != null)
				_oCommand.Parameters["@cCellsSourceList"].Value = _FilterCellsSourceList;
			else
				_oCommand.Parameters["@cCellsSourceList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cCellsTargetList", SqlDbType.VarChar);
			if (_FilterCellsTargetList != null)
				_oCommand.Parameters["@cCellsTargetList"].Value = _FilterCellsTargetList;
			else
				_oCommand.Parameters["@cCellsTargetList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cStoresZonesSourceList", SqlDbType.VarChar);
			if (_FilterStoresZonesSourceList != null)
				_oCommand.Parameters["@cStoresZonesSourceList"].Value = _FilterStoresZonesSourceList;
			else
				_oCommand.Parameters["@cStoresZonesSourceList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cStoresZonesTargetList", SqlDbType.VarChar);
			if (_FilterStoresZonesTargetList != null)
				_oCommand.Parameters["@cStoresZonesTargetList"].Value = _FilterStoresZonesTargetList;
			else
				_oCommand.Parameters["@cStoresZonesTargetList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cStoresZonesTypesSourceList", SqlDbType.VarChar);
			if (_FilterStoresZonesTypesSourceList != null)
				_oCommand.Parameters["@cStoresZonesTypesSourceList"].Value = _FilterStoresZonesTypesSourceList;
			else
				_oCommand.Parameters["@cStoresZonesTypesSourceList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cStoresZonesTypesTargetList", SqlDbType.VarChar);
			if (_FilterStoresZonesTypesTargetList != null)
				_oCommand.Parameters["@cStoresZonesTypesTargetList"].Value = _FilterStoresZonesTypesTargetList;
			else
				_oCommand.Parameters["@cStoresZonesTypesTargetList"].Value = DBNull.Value;

            _oCommand.Parameters.Add("@bPrinted", SqlDbType.Bit);
            if (_FilterPrinted.HasValue)
                _oCommand.Parameters["@bPrinted"].Value = _FilterPrinted;
            else
                _oCommand.Parameters["@bPrinted"].Value = DBNull.Value;
            
            _oCommand.Parameters.Add("@cPackingsList", SqlDbType.VarChar);
			if (_FilterPackingsList != null)
				_oCommand.Parameters["@cPackingsList"].Value = _FilterPackingsList;
			else
				_oCommand.Parameters["@cPackingsList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cGoodsList", SqlDbType.VarChar);
			if (_FilterGoodsList != null)
				_oCommand.Parameters["@cGoodsList"].Value = _FilterGoodsList;
			else
				_oCommand.Parameters["@cGoodsList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cInputsList", SqlDbType.VarChar);
			if (_FilterInputsList!= null)
				_oCommand.Parameters["@cInputsList"].Value = _FilterInputsList;
			else
				_oCommand.Parameters["@cInputsList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cOutputsList", SqlDbType.VarChar);
			if (_FilterOutputsList != null)
				_oCommand.Parameters["@cOutputsList"].Value = _FilterOutputsList;
			else
				_oCommand.Parameters["@cOutputsList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cMovingsList", SqlDbType.VarChar);
			if (_FilterMovingsList != null)
				_oCommand.Parameters["@cMovingsList"].Value = _FilterMovingsList;
			else
				_oCommand.Parameters["@cMovingsList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cFramesList", SqlDbType.VarChar);
			if (_FilterFramesList != null)
				_oCommand.Parameters["@cFramesList"].Value = _FilterFramesList;
			else
				_oCommand.Parameters["@cFramesList"].Value = DBNull.Value;

			#endregion

			try
			{
				_MainTable = FillReadings(new SqlDataAdapter(_oCommand), _MainTable, _MainTableName);
				_NeedRequery = true;
			}
			catch (Exception ex)
			{
				_ErrorNumber = -1;
				_ErrorStr = "������ ��� ��������� ������ ������� �� ����������� �������/����...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// ������� ������-�����
		/// </summary>
		public void ClearFilters()
		{
			_BarCode = null;
			_FilterSuccess = null;
			_FilterConfirmed = null;
            _FilterPrinted = null;
			_FilterDataBeg = null;
			_FilterDataEnd = null;
			_FilterUsersList = null;
			_FilterDevicesList = null;
			_FilterCellsSourceList = null;
			_FilterCellsTargetList = null;
			_FilterStoresZonesSourceList = null;
			_FilterStoresZonesTargetList = null;
			_FilterStoresZonesTypesSourceList = null;
			_FilterStoresZonesTypesTargetList = null;
			_FilterPackingsList = null;
			_FilterGoodsList = null;
			_FilterInputsList = null;
			_FilterOutputsList = null;
			_FilterMovingsList = null;
			_FilterFramesList = null;
		}

		/// <summary>
		/// ��������� ������� ������(�������) ��� ������������� ���������� (TableTrafficsGoodsErrors)
		/// </summary>
		public bool FillTableTrafficsGoodsErrors()
		{
			if (_DS.Tables["TableTrafficsGoodsErrors"] != null)
				_DS.Tables.Remove("TableTrafficsGoodsErrors");

			string sqlSelect = "select TE.ID, TE.Name, TE.Severity " +
				"from TrafficsGoodsErrors TE " +
				"where 1 = 1 ";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			try
			{
				_TableTrafficsGoodsErrors = FillReadings(new SqlDataAdapter(_oCommand), _TableTrafficsGoodsErrors, "TableTrafficsGoodsErrors");

				// primarykey
				DataColumn[] pk = new DataColumn[1];
				pk[0] = _TableTrafficsGoodsErrors.Columns[0];
				_TableTrafficsGoodsErrors.PrimaryKey = pk;
			}
			catch (Exception ex)
			{
				_ErrorNumber = -11;
				_ErrorStr = "������ ��� ��������� ������ ������(�������) ��� �������������..." + Convert.ToChar(13) + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}


		/// <summary>
		/// ������������� ���������� ������� �� ����������� �������/���� 
		/// </summary>
		public bool ConfirmData(int nTrafficID, decimal nQntConfirmed, bool bMinusAllowed, bool bSuccess, int? nTrafficErrorID)
		{
			string _sqlCommand = "execute up_TrafficsGoodsConfirm @nTrafficID, " + 
									"@bSuccess, " +
									"@nQntConfirmed, " +
									"@bMinusAllowed, " + 
									"@nTrafficErrorID, " +
									"@nError output, @cErrorStr output";

			SqlCommand _oCommand = new SqlCommand(_sqlCommand, _Connect);
			
			#region up_TrafficsGoodsConfirm parameters

			SqlParameter _oParameter = _oCommand.Parameters.Add("@nTrafficID", SqlDbType.Int);
			_oParameter.Value = nTrafficID;

			_oParameter = _oCommand.Parameters.Add("@bSuccess", SqlDbType.Bit);
			_oParameter.Value = bSuccess;

			_oParameter = _oCommand.Parameters.Add("@nQntConfirmed", SqlDbType.Int);
			_oParameter.Value = nQntConfirmed;

			_oParameter = _oCommand.Parameters.Add("@bMinusAllowed", SqlDbType.Bit);
			_oParameter.Value = bMinusAllowed;

			_oParameter = _oCommand.Parameters.Add("@nTrafficErrorID", SqlDbType.Int);
			if (nTrafficErrorID.HasValue) 
				_oParameter.Value = nTrafficErrorID;
			else
				_oParameter.Value = DBNull.Value;

			_oParameter = _oCommand.Parameters.Add("@nError", SqlDbType.Int);
			_oParameter.Direction = ParameterDirection.InputOutput;
			_oParameter.Value = 0;

			_oParameter = _oCommand.Parameters.Add("@cErrorStr", SqlDbType.VarChar, 200);
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
				_ErrorStr = "������ ��� ������������� ����������� �������/����...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			if (_ErrorNumber == 0)
			{
				_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
				if (ErrorNumber != 0)
				{
					_ErrorStr = "������ ��� ������������� ����������� �������/����...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
					//WMSMessage.MessageBoxError(_ErrorStr); //RaisError
				}
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// ��������� ���������� ������� �� ����������� �������/����
		/// </summary>
		/// <param name="nTrafficID">ID ������� �� ����������� �������/����(TrafficsGoods.ID)</param>
		/// <param name="nShift">��������� ���������� (+1, -1, ...)</param>
		/// <returns></returns>
		public bool PriorityChange(int nTrafficID, int nShift)
		{
			string sqlCommand = "update TrafficsGoods " +
				"set Priority = Priority + (" + nShift.ToString() + ") " + 
				"where ID = " + nTrafficID.ToString();
			SqlCommand _oCommand = new SqlCommand(sqlCommand, _Connect);
			try
			{
				_Connect.Open();
				_oCommand.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -2;
				_ErrorStr = "������ ��� ��������� ���������� ������� �� ����������� �������/����...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// ������� ������� ������ ��������� (����������) ������� �� ����������� �������/����
		/// </summary>
		/// <param name="nTrafficID">ID ������� �� ����������� �������/���� (TrafficsGoods.ID)</param>
		/// <returns></returns>
		public bool SetDateAccept(int nTrafficID)
		{
			string sqlCommand = "update TrafficsGoods " +
				"set DateAccept = GetDate() " +
				"where ID = " + nTrafficID.ToString();
			SqlCommand _oCommand = new SqlCommand(sqlCommand, _Connect);
			try
			{
				_Connect.Open();
				_oCommand.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -3;
				_ErrorStr = "������ ��� ������� ������� ������ ��������� ������� �� ����������� �������/���� ...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// ������� ������� ������ ��������� (����������) � ������������ ��� ������� �� ����������� �������/����
		/// </summary>
		/// <param name="nTrafficID">ID ������� �� ����������� �������/���� (TrafficsGoods.ID)</param>
		/// <returns></returns>
		public bool ClearDateAccept(int nTrafficID)
		{
			string sqlCommand = "update TrafficsGoods " +
				"set DateAccept = Null, UserID = Null, DeviceID = Null " +
				"where ID = " + nTrafficID.ToString();
			SqlCommand _oCommand = new SqlCommand(sqlCommand, _Connect);
			try
			{
				_Connect.Open();
				_oCommand.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -4;
				_ErrorStr = "������ ��� ������� ������� ������ ��������� ������� �� ����������� �������/���� ...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			return (_ErrorNumber == 0);
		}

        /// <summary>
        /// �������� ����� ������ ���������
        /// </summary>
        public bool SetDatePrint(int nTrafficID)
        {
            string sqlCommand = "update TrafficsGoods " +
                "set DatePrint = GetDate() " +
                "where ID = " + nTrafficID.ToString() + " and DatePrint is Null";
            SqlCommand _oCommand = new SqlCommand(sqlCommand, _Connect);
            try
            {
                _Connect.Open();
                _oCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                _ErrorNumber = -24;
                _ErrorStr = "������ ��� ������� ������� ������ ���������...\r\n" + ex.Message;
                RFMMessage.MessageBoxError(_ErrorStr);
            }
            finally
            {
                _Connect.Close();
            }
            return (_ErrorNumber == 0);
        }

		/// <summary>
		/// ��������� ���������� ������� �� ����������� �������/����: ������������, ����������, ������ �������������
		/// </summary>
		public bool SaveDataPartial(int nTrafficID, 
				decimal? nQntConfirmed, 
				int? nUserID, int? nDeviceID, int? nPriority, 
				int? nTrafficErrorID, bool? bLockCellFinish)
		{
			string _sqlCommand = "execute up_TrafficsGoodsSavePartial " + 
									"@nTrafficID, " +
									"@nQntConfirmed, " + 
									"@nUserID, @nDeviceID, @nPriority, " +
									"@nTrafficErrorID, @bLockCellFinish, " +
									"@nError output, @cErrorStr output";

			SqlCommand _oCommand = new SqlCommand(_sqlCommand, _Connect);

			#region up_TrafficsGoodsSavePartial parameters

			_oCommand.Parameters.Add("@nTrafficID", SqlDbType.Int);
			_oCommand.Parameters["@nTrafficID"].Value = nTrafficID;

			_oCommand.Parameters.Add("@nQntConfirmed", SqlDbType.Decimal);
			_oCommand.Parameters["@nQntConfirmed"].Precision = 18;
			_oCommand.Parameters["@nQntConfirmed"].Scale = 3;
			if (nQntConfirmed.HasValue)
				_oCommand.Parameters["@nQntConfirmed"].Value = nQntConfirmed;
			else
				_oCommand.Parameters["@nQntConfirmed"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@nUserID", SqlDbType.Int);
			if (nUserID.HasValue)
				_oCommand.Parameters["@nUserID"].Value = nUserID;
			else
				_oCommand.Parameters["@nUserID"].Value = DBNull.Value;
			
			_oCommand.Parameters.Add("@nDeviceID", SqlDbType.Int);
			if (nDeviceID.HasValue)
				_oCommand.Parameters["@nDeviceID"].Value = nDeviceID;
			else
				_oCommand.Parameters["@nDeviceID"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@nPriority", SqlDbType.Int);
			if (nPriority.HasValue)
				_oCommand.Parameters["@nPriority"].Value = nPriority;
			else
				_oCommand.Parameters["@nPriority"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@nTrafficErrorID", SqlDbType.Int);
			if (nTrafficErrorID.HasValue)
				_oCommand.Parameters["@nTrafficErrorID"].Value = nTrafficErrorID;
			else
				_oCommand.Parameters["@nTrafficErrorID"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bLockCellFinish", SqlDbType.Bit);
			if (bLockCellFinish.HasValue)
				_oCommand.Parameters["@bLockCellFinish"].Value = bLockCellFinish;
			else
				_oCommand.Parameters["@bLockCellFinish"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@nError", SqlDbType.Int);
			_oCommand.Parameters["@nError"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@nError"].Value = 0;

			_oCommand.Parameters.Add("@cErrorStr", SqlDbType.VarChar, 200);
			_oCommand.Parameters["@cErrorStr"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@cErrorStr"].Value = "";

			#endregion

			try
			{
				_Connect.Open();
				_oCommand.ExecuteScalar();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -12;
				_ErrorStr = "������ ��� ����������/����������� ������� �� ����������� �������/����...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr); //RaisError
			}
			finally
			{
				_Connect.Close();
			}
			if (_ErrorNumber == 0)
			{
				_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
				if (ErrorNumber != 0)
				{
					_ErrorStr = "������ ��� ����������/����������� ������� �� ����������� �������/����...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// �������� ������ ������� �� ����������� �������/����
		/// </summary>
		/// <param name="nTrafficID">ID ������� �� ����������� �������/���� (TrafficsGoods.ID)</param>
		/// <returns></returns>
		public bool DeleteOne(int nTrafficID)
		{
			string sqlSelect = "execute up_TrafficsGoodsDelete @nTrafficID, " +
									"@nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_TrafficsGoodsDelete paramaters

			_oCommand.Parameters.Add("@nTrafficID", SqlDbType.Int);
			_oCommand.Parameters["@nTrafficID"].Value = nTrafficID;

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
				_oCommand.ExecuteScalar();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -11;
				_ErrorStr = "������ ��� �������� ������� �� ����������� �������/���� � ����� " + nTrafficID.ToString() + "...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
			if (_ErrorNumber != 0)
			{
				_ErrorStr = "������ ��� �������� ������� �� ����������� �������/���� � ����� " + nTrafficID.ToString() + "...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// "������" �������� ��������� �����������
		/// </summary>
		public bool CreateManual(int nPackingID, decimal nQntWished, DateTime? dDateValid, 
			int nGoodStateID, int? nOwnerID, 
			int nCellSourceID, int nCellTargetID)
		{

			string sqlSelect = "execute up_TrafficsGoodsCreateManual " +
									"@nPackingID, @nQntWished, @dDateValid, " + 
									"@nGoodStateID, @nOwnerID, " +
									"@nCellSourceID, @nCellTargetID, " +
									"@nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_TrafficsFrameCreateManual paramaters

			_oCommand.Parameters.Add("@nPackingID", SqlDbType.Int);
			_oCommand.Parameters["@nPackingID"].Value = nPackingID;

			_oCommand.Parameters.Add("@nQntWished", SqlDbType.Decimal);
			_oCommand.Parameters["@nQntWished"].Precision = 18;
			_oCommand.Parameters["@nQntWished"].Scale = 3;
			_oCommand.Parameters["@nQntWished"].Value = nQntWished;

			_oCommand.Parameters.Add("@nGoodStateID", SqlDbType.Int);
			_oCommand.Parameters["@nGoodStateID"].Value = nGoodStateID;

			_oCommand.Parameters.Add("@dDateValid", SqlDbType.SmallDateTime);
			if (dDateValid.HasValue)
				_oCommand.Parameters["@dDateValid"].Value = dDateValid;
			else
				_oCommand.Parameters["@dDateValid"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@nOwnerID", SqlDbType.Int);
			if (nOwnerID.HasValue)
				_oCommand.Parameters["@nOwnerID"].Value = nOwnerID;
			else
				_oCommand.Parameters["@nOwnerID"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@nCellSourceID", SqlDbType.Int);
			_oCommand.Parameters["@nCellSourceID"].Value = nCellSourceID;

			_oCommand.Parameters.Add("@nCellTargetID", SqlDbType.Int);
			_oCommand.Parameters["@nCellTargetID"].Value = nCellTargetID;

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
				_oCommand.ExecuteScalar();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -11;
				_ErrorStr = "������ ��� ������� �������� �������� ����������� �������/����...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
			if (_ErrorNumber != 0)
			{
				_ErrorStr = "������ ��� �������� �������� ����������� �������/����...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// ��������� ������������ (����������)
		/// </summary>
		public bool UserChange(int nTrafficID, int nUserID)
		{
			string sqlCommand = "update TrafficsGoods " +
				"set UserID = " + nUserID.ToString() + " " +
				"where ID = " + nTrafficID.ToString();
			SqlCommand _oCommand = new SqlCommand(sqlCommand, _Connect);
			try
			{
				_Connect.Open();
				_oCommand.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -2;
				_ErrorStr = "������ ��� ��������� ������ � ���������� � ������� �� ����������� �������/����...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			return (_ErrorNumber == 0);
		}
	}
}
