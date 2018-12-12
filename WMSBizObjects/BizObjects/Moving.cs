using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

using RFMPublic; 

/// <summary>
/// ������-������ �����.����������� (Moving)
/// </summary>
namespace WMSBizObjects
{
	public class Moving : BizObject 
	{
		protected string _IDList;
		/// <summary>
		/// ������ ID �����.����������� (Movings.ID)
		/// </summary>
		[Description("������ ID �����.����������� (Movings.ID)")]
		public string IDList { get { return _IDList; } set { _IDList = value; _NeedRequery = true; } }

		// �������
		#region Filters

		protected DateTime? _FilterDateBeg;
		/// <summary>
		/// ������-����: ��������� ���� ������� (Movings.DateMoving)
		/// </summary>
		[Description("������-����: ��������� ���� ������� (Movings.DateMoving)")]
		public DateTime? FilterDateBeg { get { return _FilterDateBeg; } set { _FilterDateBeg = value; } }
		protected DateTime? _FilterDateEnd;
		/// <summary>
		/// ������-����: �������� ���� �������
		/// </summary>
		[Description("������-����: �������� ���� ������� (Movings.DateMoving)")]
		public DateTime? FilterDateEnd { get { return _FilterDateEnd; } set { _FilterDateEnd = value; } }

		protected string _FilterMovingsTypesList;
		/// <summary>
		/// ������-����: ������ ����� �����.����������� (Movings.MovingTypeID), ����� �������
		/// </summary>
		[Description("������-����: ������ ����� �����.����������� (Movings.MovingTypeID), ����� �������")]
		public string FilterMovingsTypesList { get { return _FilterMovingsTypesList; } set { _FilterMovingsTypesList = value; } }

		protected string _FilterGoodsStatesList;
		/// <summary>
		/// ������-����: ������ ��������� ������ (Movings.GoodStateID), ����� �������
		/// </summary>
		[Description("������-����: ������ ��������� ������ ������ (Movings.GoodStateID), ����� �������")]
		public string FilterGoodsStatesList { get { return _FilterGoodsStatesList; } set { _FilterGoodsStatesList = value; } }

		protected string _FilterGoodsStatesNewList;
		/// <summary>
		/// ������-����: ������ ����� ��������� ������ (Movings.GoodStateNewID), ����� �������
		/// </summary>
		[Description("������-����: ������ ����� ��������� ������ ������ (Movings.GoodStateNewID), ����� �������")]
        public string FilterGoodsStatesNewList { get { return _FilterGoodsStatesNewList; } set { _FilterGoodsStatesNewList = value; } }

		protected string _FilterOwnersList;
		/// <summary>
		/// ������-����: ������ ���������� ������ (Movings.OwnerID), ����� �������
		/// </summary>
		[Description("������-����: ������ ���������� ������ (Movings.OwnerID), ����� �������")]
		public string FilterOwnersList { get { return _FilterOwnersList; } set { _FilterOwnersList = value; } }

		protected string _FilterPackingsList;
		/// <summary>
		/// ������-����: ������ ID �������� � ������������ (Movings -> TrafficsGoods.PackingID), ����� �������
		/// </summary>
		[Description("������-����: ������ ID �������� � ������������ (Movings -> TrafficsGoods.PackingID), ����� �������")]
		public string FilterPackingsList { get { return _FilterPackingsList; } set { _FilterPackingsList = value; _NeedRequery = true; } }

		protected string _FilterGoodsList;
		/// <summary>
		/// ������-����: ������ ID ������� � ������������ (Movings -> TrafficsGoods.PackingID -> Packings.GoodID), ����� �������
		/// </summary>
		[Description("������-����: ������ ID ������� � ������������ (Movings -> TrafficsGoods.PackingID -> Packings.GoodID), ����� �������")]
		public string FilterGoodsList { get { return _FilterGoodsList; } set { _FilterGoodsList = value; _NeedRequery = true; } }

		protected string _FilterCellsSourceList;
		/// <summary>
		/// ������-����: ������ ID �����-���������� (Movings.CellSourceID), ����� �������
		/// </summary>
		[Description("������-����: ������ ID �����-���������� (Movings.CellSourceID), ����� �������")]
		public string FilterCellsSourceList { get { return _FilterCellsSourceList; } set { _FilterCellsSourceList = value; _NeedRequery = true; } }

		protected string _FilterStoresZonesSourceList;
		/// <summary>
		/// ������-����: ������ ID ��������� ���-���������� (Movings.CellSourceID - Cells.StoreZoneID), ����� �������
		/// </summary>
		[Description("������-����: ������ ID ��������� ���-���������� (Movings.CellSourceID - Cells.StoreZoneID), ����� �������")]
		public string FilterStoresZonesSourceList { get { return _FilterStoresZonesSourceList; } set { _FilterStoresZonesSourceList = value; _NeedRequery = true; } }

		protected string _FilterStoresZonesTypesSourceList;
		/// <summary>
		/// ������-����: ������ ID ����� ��������� ���-���������� (Movings.CellSourceID -> Cells.StoreZoneID -> StoresZones.StoreZoneTypeID), ����� �������
		/// </summary>
		[Description("������-����: ������ ID ����� ��������� ���-���������� (Movings.CellSourceID -> Cells.StoreZoneID -> StoresZones.StoreZoneTypeID), ����� �������")]
		public string FilterStoresZonesTypesSourceList { get { return _FilterStoresZonesTypesSourceList; } set { _FilterStoresZonesTypesSourceList = value; _NeedRequery = true; } }

		protected bool? _FilterConfirmed;
		/// <summary>
		/// ������-����: �����.����������� ������������ (Movings.DateConfirm)?
		/// </summary>
		[Description("������-����: �����.����������� ������������ (Movings.DateConfirm)?")]
		public bool? FilterConfirmed { get { return _FilterConfirmed; } set { _FilterConfirmed = value; } }

		protected int? _FilterMovingTrafficsInfo;
		/// <summary>
		/// ������-����: ���������� �� ������������ �������/���� (Movings -> TrafficsGoods.MovingID)
		/// 0 ��� �� ���������, 1 ��������� �� ���������, 2 ��� ���������
		/// </summary>
		[Description("������-����: ���������� �� ������������ �������/���� (Movings -> TrafficsGoods.MovingID)?")]
		public int? FilterMovingTrafficsInfo { get { return _FilterMovingTrafficsInfo; } set { _FilterMovingTrafficsInfo = value; _NeedRequery = true; } }

		#endregion Filters

		// �������
		#region Tables

		protected DataTable _TableMovingsGoods;
		/// <summary>
		/// ������ ������� �� �����.����������� (TableMovingsGoods)
		/// </summary>
		[Description("������ ������� �� �����.����������� (TableMovingsGoods)")]
		public DataTable TableMovingsGoods { get { return _TableMovingsGoods; } }

		protected DataTable _TableMovingsTrafficsGoods;
		/// <summary>
		/// ������ �������� �������/���� �� �����.����������� (TableMovingsTrafficsGoods)
		/// </summary>
		[Description("������ �������� �������/���� �� �����.����������� (TableMovingsTrafficsGoods)")]
		public DataTable TableMovingsTrafficsGoods { get { return _TableMovingsTrafficsGoods; } }

		protected DataTable _TableMovingsTypes;
		/// <summary>
		/// ������� ����� �����.�����������
		/// </summary>
		[Description("������� ����� �����.����������� (TableMovingsTypes)")]
		public DataTable TableMovingsTypes { get { return _TableMovingsTypes; } }

		#endregion Tables

		// -------------------------------------

		public Moving() : base()
		{
			_MainTableName = "Movings";
		}

		#region FillData

		/// <summary>
		/// ��������� ������ �����.����������� (MainTable)
		/// </summary>
		public override bool FillData()
		{
			ClearData();

			string sqlSelect = "execute up_MovingsFill " + 
				"@nID, @cIDList, " + 
				"@bConfirmed, " + 
				"@dDateBeg, @dDateEnd, " + 
				"@cMovingsTypesList, " +
				"@cGoodsStatesList, @cGoodsStatesNewList, @cOwnersList, " +
				"@cCellsSourceList, @cStoresZonesSourceList, @cStoresZonesTypesSourceList, " +
				"@cPackingsList, @cGoodsList, " +
				"@nMovingTrafficsInfo";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_MovingsFill parameters 

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

			_oCommand.Parameters.Add("@bConfirmed", SqlDbType.Bit);
			if (_FilterConfirmed != null)
				_oCommand.Parameters["@bConfirmed"].Value = _FilterConfirmed;
			else
				_oCommand.Parameters["@bConfirmed"].Value = DBNull.Value;
			
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
			
			_oCommand.Parameters.Add("@cMovingsTypesList", SqlDbType.VarChar);
			if (_FilterMovingsTypesList != null)
				_oCommand.Parameters["@cMovingsTypesList"].Value = _FilterMovingsTypesList;
			else
				_oCommand.Parameters["@cMovingsTypesList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cGoodsStatesList", SqlDbType.VarChar);
			if (_FilterGoodsStatesList != null)
			    _oCommand.Parameters["@cGoodsStatesList"].Value = _FilterGoodsStatesList;
			else
			    _oCommand.Parameters["@cGoodsStatesList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cGoodsStatesNewList", SqlDbType.VarChar);
			if (_FilterGoodsStatesNewList != null)
				_oCommand.Parameters["@cGoodsStatesNewList"].Value = _FilterGoodsStatesNewList;
			else
				_oCommand.Parameters["@cGoodsStatesNewList"].Value = DBNull.Value;
			
			_oCommand.Parameters.Add("@cOwnersList", SqlDbType.VarChar);
			if (_FilterOwnersList != null)
				_oCommand.Parameters["@cOwnersList"].Value = _FilterOwnersList;
			else
				_oCommand.Parameters["@cOwnersList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cCellsSourceList", SqlDbType.VarChar);
			if (_FilterCellsSourceList != null)
				_oCommand.Parameters["@cCellsSourceList"].Value = _FilterCellsSourceList;
			else
				_oCommand.Parameters["@cCellsSourceList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cStoresZonesSourceList", SqlDbType.VarChar);
			if (_FilterStoresZonesSourceList != null)
				_oCommand.Parameters["@cStoresZonesSourceList"].Value = _FilterStoresZonesSourceList;
			else
				_oCommand.Parameters["@cStoresZonesSourceList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cStoresZonesTypesSourceList", SqlDbType.VarChar);
			if (_FilterStoresZonesTypesSourceList != null)
				_oCommand.Parameters["@cStoresZonesTypesSourceList"].Value = _FilterStoresZonesTypesSourceList;
			else
				_oCommand.Parameters["@cStoresZonesTypesSourceList"].Value = DBNull.Value;

			#region up_MovingsFill TrafficsGoods-paramaters

			//���� ��� ������ ����� ������ ������� (TrafficsGoods)

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

			#endregion

			_oCommand.Parameters.Add("@nMovingTrafficsInfo", SqlDbType.Int);
			if (_FilterMovingTrafficsInfo.HasValue)
				_oCommand.Parameters["@nMovingTrafficsInfo"].Value = _FilterMovingTrafficsInfo;
			else
				_oCommand.Parameters["@nMovingTrafficsInfo"].Value = DBNull.Value;

			#endregion

			try
			{
				_MainTable = FillReadings(new SqlDataAdapter(_oCommand), _MainTable, _MainTableName);
			}
			catch (Exception ex)
			{
				_ErrorNumber = -1;
				_ErrorStr = "������ ��� ��������� ������ �����.�����������..." + Convert.ToChar(13) + ex.Message;
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
			_FilterMovingsTypesList = null;
			_FilterGoodsStatesList = null;
			_FilterGoodsStatesNewList = null;
			_FilterOwnersList = null;
			_FilterCellsSourceList = null;
			_FilterStoresZonesSourceList = null;
			_FilterStoresZonesTypesSourceList = null;
			_FilterConfirmed = null;
			_FilterPackingsList = null;
			_FilterGoodsList = null;
			_FilterMovingTrafficsInfo = null;
			//_NeedRequery = false;
		}

		#endregion FillData

		#region Tables

		#region MovingsTypes

		/// <summary>
		/// ���������� ������� ����� �����.����������� (TableMovingsTypes)
		/// </summary>
		public bool FillTableMovingsTypes()
		{
			string sqlSelect = "select MT.ID, MT.Name, " + 
					"MT.GoodStateID, MT.ToOneCell, GS.Name as GoodStateName, " + 
					"MT.Actual " + 
				"from MovingsTypes MT " +
				"left join GoodsStates GS on MT.GoodStateID = GS.ID " + 
				"order by MT.Name";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			try
			{
				_TableMovingsTypes = FillReadings(new SqlDataAdapter(_oCommand), _TableMovingsTypes, "TableMovingsTypes");
			}
			catch (Exception ex)
			{
				_ErrorNumber = -11;
				_ErrorStr = "������ ��� ��������� ������ ����� �����.�����������..." + Convert.ToChar(13) + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		#endregion MovingsTypes

		#region MovingsGoods

		/// <summary>
		/// ���������� ������� ������� �� �����.����������� (TableMovingsGoods)
		/// </summary>
		public bool FillTableMovingsGoods(int? nMovingID)
		{
			if (!nMovingID.HasValue & !_ID.HasValue)
			{
				_ErrorNumber = -21;
				_ErrorStr = "������������ �����:\r\n������ ��� ��������� ������ ������� �� �����.�����������...";
				RFMMessage.MessageBoxError(_ErrorStr);
				return (false);
			}
			if (!nMovingID.HasValue)
				nMovingID = _ID;

			string sqlSelect = "execute up_MovingsGoodsFill @nMovingID, @nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_MovingsGoodsFill parameters

			_oCommand.Parameters.Add("@nMovingID", SqlDbType.Int);
			_oCommand.Parameters["@nMovingID"].Value = nMovingID;

			_oCommand.Parameters.Add("@nError", SqlDbType.Int);
			_oCommand.Parameters["@nError"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@nError"].Value = 0;

			_oCommand.Parameters.Add("@cErrorText", SqlDbType.VarChar, 200);
			_oCommand.Parameters["@cErrorText"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@cErrorText"].Value = "";

			#endregion

			try
			{
				_TableMovingsGoods = FillReadings(new SqlDataAdapter(_oCommand), _TableMovingsGoods, "TableMovingsGoods");

				DataColumn[] pk = new DataColumn[1];
				pk[0] = _TableMovingsGoods.Columns["ID"];
				_TableMovingsGoods.PrimaryKey = pk;
			}
			catch (Exception ex)
			{
				_ErrorNumber = -4;
				_ErrorStr = "������ ��� ��������� ������ ������� �� �����.�����������...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// ���������� ������� ������� �� �����.����������� (TableMovingsGoods) 
		/// �� ������! ������������ ��� ����� ������ �����������
		/// ���-�� ������ � ������ - � ����� Qnt, Box
		/// </summary>
		public bool FillTableMovingsGoodsInCell(int nCellSourceID,
                int? nGoodStateID, int? nGoodStateNewID, 
                int? nOwnerID, 
				int? nCellTargetID, 
				string sPackingsList, 
				string sOutputsList,  
				int? nMovingID)
		{
			string sqlSelect = "execute up_MovingsGoodsFillInCell " + 
					"@nCellSourceID, " +
                    "@nGoodStateID, @nGoodStateNewID, " + 
                    "@nOwnerID, " + 
					"@nCellTargetID, " + 
					"@cPackingsList, " +
					"@cOutputsList, " + 
					"@nMovingID, " + 
					"@nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_MovingsGoodsFillInCell parameters

			SqlParameter _oParameter = _oCommand.Parameters.Add("@nCellSourceID", SqlDbType.Int);
			_oParameter.Value = nCellSourceID;

			_oParameter = _oCommand.Parameters.Add("@nGoodStateID", SqlDbType.Int);
			if (nGoodStateID.HasValue)
				_oParameter.Value = nGoodStateID;
			else
				_oParameter.Value = DBNull.Value;

            _oParameter = _oCommand.Parameters.Add("@nGoodStateNewID", SqlDbType.Int);
            if (nGoodStateNewID.HasValue)
                _oParameter.Value = nGoodStateNewID;
            else
                _oParameter.Value = DBNull.Value;
            
            _oParameter = _oCommand.Parameters.Add("@nOwnerID", SqlDbType.Int);
			if (nOwnerID.HasValue)
				_oParameter.Value = nOwnerID;
			else
				_oParameter.Value = DBNull.Value;

			_oParameter = _oCommand.Parameters.Add("@nCellTargetID", SqlDbType.Int);
			if (nCellTargetID.HasValue)
				_oParameter.Value = nCellTargetID;
			else
				_oParameter.Value = DBNull.Value;

			_oParameter = _oCommand.Parameters.Add("@cPackingsList", SqlDbType.VarChar);
			if (sPackingsList != null)
				_oParameter.Value = sPackingsList;
			else
				_oParameter.Value = DBNull.Value;

			_oParameter = _oCommand.Parameters.Add("@cOutputsList", SqlDbType.VarChar);
			if (sOutputsList != null)
				_oParameter.Value = sOutputsList;
			else
				_oParameter.Value = DBNull.Value;

			_oParameter = _oCommand.Parameters.Add("@nMovingID", SqlDbType.Int);
			if (nMovingID.HasValue)
				_oParameter.Value = nMovingID;
			else
				_oParameter.Value = DBNull.Value;

			_oCommand.Parameters.Add("@nError", SqlDbType.Int);
			_oCommand.Parameters["@nError"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@nError"].Value = 0;

			_oCommand.Parameters.Add("@cErrorText", SqlDbType.VarChar, 200);
			_oCommand.Parameters["@cErrorText"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@cErrorText"].Value = "";

            _oCommand.CommandTimeout = 0;
			#endregion

			try
			{
				_TableMovingsGoods = FillReadings(new SqlDataAdapter(_oCommand), _TableMovingsGoods, "TableMovingsGoods");
			}
			catch (Exception ex)
			{
				_ErrorNumber = -4;
				_ErrorStr = "������ ��� ��������� ������ ������� � ������ ��� �����.�����������...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// ������� ������� ������� �� �����.����������� (TableMovingsGoods)
		/// </summary>
		public void ClearTableMovingsGoods()
		{
			if (_DS.Tables["TableMovingsGoods"] != null)
			{
				_DS.Tables.Remove("TableMovingsGoods");
				_TableMovingsGoods = null;
			}
		}
	
		#endregion MovingsGoods

		#region MovingsTraffics

		/// <summary>
		/// ���������� ������� ����������� ����/������� �� �����.����������� (TableMovingsTrafficsGoods)
		/// </summary>
		public bool FillTableMovingsTrafficsGoods(int? nMovingID)
		{
			if (!nMovingID.HasValue & !_ID.HasValue)
			{
				_ErrorNumber = -21;
				_ErrorStr = "������������ �����:\r\n������ ��� ��������� ������ ����������� �������/���� �� �����.�����������...";
				RFMMessage.MessageBoxError(_ErrorStr);
				return (false);
			}
			if (!nMovingID.HasValue)
				nMovingID = _ID;

			string sqlSelect = "execute up_TrafficsGoodsFill @cMovingsList = " + nMovingID.ToString();
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			try
			{
				_TableMovingsTrafficsGoods = FillReadings(new SqlDataAdapter(_oCommand), _TableMovingsTrafficsGoods, "TableMovingsTrafficsGoods");

				DataColumn[] pk = new DataColumn[1];
				pk[0] = _TableMovingsTrafficsGoods.Columns["ID"];
				_TableMovingsTrafficsGoods.PrimaryKey = pk;
			}
			catch (Exception ex)
			{
				_ErrorNumber = -4;
				_ErrorStr = "������ ��� ��������� ������ ����������� �������/���� �� �����.�����������...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		#endregion MovingsTraffics

		#endregion Tables

		#region Save

		/// <summary>
		/// ���������� �����.�����������
		/// </summary>
		public bool SaveData(int nMovingID, int? nCellTargetID, int nUserID)
		{
			if (_MainTable.Rows.Count == 0 || _MainTable.Rows[0] == null)
			{
				_ErrorNumber = -20;
				_ErrorStr = "��� ������ ��� ���������� �����.�����������...";
				RFMMessage.MessageBoxError(_ErrorStr);
				return (false);
			}

			DataRow r = _MainTable.Rows[0];

			String _sqlCommand = "execute up_MovingsSave @nMovingID output, " +
					"@dDateMoving, " +
					"@nMovingTypeID, " +
					"@nOwnerID, @nGoodStateID, @nGoodStateNewID, " + 
					"@nCellSourceID, " +
					"@nCellTargetID, " +  
					"@cNote, " +
					"@nUserID, " +
					"@nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(_sqlCommand, _Connect);

			#region up_MovingsSave parameters

			SqlParameter _oParameter = _oCommand.Parameters.Add("@nMovingID", SqlDbType.Int);
			_oParameter.Value = nMovingID;
			_oParameter.Direction = ParameterDirection.InputOutput;

			_oParameter = _oCommand.Parameters.Add("@dDateMoving", SqlDbType.DateTime);
			_oParameter.Value = DateTime.Parse(r["DateMoving"].ToString());

			_oParameter = _oCommand.Parameters.Add("@nMovingTypeID", SqlDbType.Int);
			_oParameter.Value = Convert.ToInt32(r["MovingTypeID"]);

			_oParameter = _oCommand.Parameters.Add("@nOwnerID", SqlDbType.Int);
			if (!Convert.IsDBNull(r["OwnerID"]))
				_oParameter.Value = Convert.ToInt32(r["OwnerID"]);
			else
				_oParameter.Value = DBNull.Value;

			_oParameter = _oCommand.Parameters.Add("@nGoodStateID", SqlDbType.Int);
			_oParameter.Value = Convert.ToInt32(r["GoodStateID"]);

			_oParameter = _oCommand.Parameters.Add("@nGoodStateNewID", SqlDbType.Int);
			_oParameter.Value = Convert.ToInt32(r["GoodStateNewID"]);

			_oParameter = _oCommand.Parameters.Add("@nCellSourceID", SqlDbType.Int);
			_oParameter.Value = Convert.ToInt32(r["CellSourceID"]);

			_oParameter = _oCommand.Parameters.Add("@nCellTargetID", SqlDbType.Int);
			if (nCellTargetID.HasValue) 
				_oParameter.Value = nCellTargetID;
			else
				_oParameter.Value = DBNull.Value;

			_oParameter = _oCommand.Parameters.Add("@cNote", SqlDbType.VarChar);
			_oParameter.Value = r["Note"].ToString();

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
				// � �������������� ��������� ������� ����������� MovingsGoods
				RFMUtilities.DataTableToTempTable(TableMovingsGoods, "#MovingsGoods", _Connect);
				_oCommand.ExecuteScalar();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -10;
				_ErrorStr = "������ ��� ���������� �����.�����������...\r\n" + ex.Message;
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
					_ErrorStr = "������ ��� ���������� �����.�����������...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
				// ��� �������� ������ �����.����������� - ������� ��� ���
				if (nMovingID == 0 && _oCommand.Parameters["@nMovingID"].Value != DBNull.Value)
				{
					_ID = (int)_oCommand.Parameters["@nMovingID"].Value;
				}
			}
			return (_ErrorNumber == 0);
		}

		#endregion Save

		#region Confirm

		/// <summary>
		/// ������������� �����������
		/// </summary>
		public bool ConfirmData(int nMovingID, int nUserID)
		{
			string _sqlCommand = "execute up_MovingsConfirm @nMovingID, @nUserID, " +
									"@nError output, @cErrorStr output";
			SqlCommand _oCommand = new SqlCommand(_sqlCommand, _Connect);
			_oCommand.CommandTimeout = 0;

			#region up_MovingsConfirm parameters

			SqlParameter _oParameter = _oCommand.Parameters.Add("@nMovingID", SqlDbType.Int);
			_oParameter.Value = nMovingID;

			_oParameter = _oCommand.Parameters.Add("@nUserID", SqlDbType.Int);
			_oParameter.Value = nUserID;

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
				RFMUtilities.DataTableToTempTable(TableMovingsGoods, "#MovingsGoods", _Connect);
				_oCommand.ExecuteScalar();
			}
			catch (Exception ex)
			{
				// ����� ������������ ��� ������, ��������� � ���� �������������. ��� ���������! 
				/*
				_ErrorNumber = -11;
				_ErrorStr = "������ ��� ������������� �����������...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
				*/
				RFMMessage.MessageBoxError(ex.Message);
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
					_ErrorStr = "������ ��� ������������� �����������...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
					if (_ErrorNumber > 0)
					{
						RFMMessage.MessageBoxError(_ErrorStr);
					}
				}
			}
			return (_ErrorNumber == 0);
		}

		#endregion Confirm

		#region Delete

		/// <summary>
		/// �������� �����.�����������
		/// </summary>
		public bool DeleteData(int nMovingID)
		{
			String _sqlCommand = "execute up_MovingsDelete @nMovingID, " +
					"@nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(_sqlCommand, _Connect);

			#region up_MovingsDelete parameters

			SqlParameter _oParameter = _oCommand.Parameters.Add("@nMovingID", SqlDbType.Int);
			_oParameter.Value = nMovingID;

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
				_ErrorStr = "������ ��� �������� �����.�����������...\r\n" + ex.Message;
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
					_ErrorStr = "������ ��� �������� �����.�����������...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		#endregion Delete

		#region SetDateTime

		/// <summary>
		/// �������� ����� ������ ��������� �����.�����������
		/// </summary>
		public bool SetDatePrint(int nMovingID)
		{
			string sqlCommand = "update Movings " +
				"set DatePrint = GetDate() " +
				"where ID = " + nMovingID.ToString() + " and DatePrint is Null";
			SqlCommand _oCommand = new SqlCommand(sqlCommand, _Connect);
			try
			{
				_Connect.Open();
				_oCommand.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -24;
				_ErrorStr = "������ ��� ������� ������� ������ ��������� �� ����������� �����������...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			return (_ErrorNumber == 0);
		}

		#endregion SetDateTime

	}
}
