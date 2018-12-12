using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

using RFMPublic;

/// <summary>
/// ������-������ ������ (Output)
/// </summary>
namespace WMSBizObjects
{
	public class Output : BizObject
	{
		protected string _IDList;
		/// <summary>
		/// ������ ID �������� (Outputs.ID)
		/// </summary>
		[Description("������ ID �������� (Outputs.ID)")]
		public string IDList { get { return _IDList; } set { _IDList = value; _NeedRequery = true; } }

		protected string _BarCode;
		/// <summary>
		/// �����-��� ���������-������� (Outputs.BarCode), ��������
		/// </summary>
		[Description("�����-��� ���������-������� (Outputs.BarCode), ��������")]
		public string BarCode { get { return _BarCode; } set { _BarCode = value; _NeedRequery = true; } }

		// �������
		#region Filters

		protected string _FilterHostsList;
		/// <summary>
		/// ������-����: ������ ����� host-�� (Outputs.HostID)
		/// </summary>
		[Description("������-����: ������ ����� host-�� (Outputs.HostID)")]
		public string FilterHostsList { get { return _FilterHostsList; } set { _FilterHostsList = value; _NeedRequery = true; } }

		protected DateTime? _FilterDateBeg;
		/// <summary>
		/// ������-����: ��������� ���� ������� (Outputs.DateOutput)
		/// </summary>
		[Description("������-����: ��������� ���� ������� (Outputs.DateOutput)")]
		public DateTime? FilterDateBeg { get { return _FilterDateBeg; } set { _FilterDateBeg = value; } }

		protected DateTime? _FilterDateEnd;
		/// <summary>
		/// ������-����: �������� ���� �������
		/// </summary>
		[Description("������-����: �������� ���� ������� (Outputs.DateOutput)")]
		public DateTime? FilterDateEnd { get { return _FilterDateEnd; } set { _FilterDateEnd = value; } }

		protected DateTime? _FilterDateBegConfirm;
		/// <summary>
		/// ������-����: ���� �������������: ��������� ���� ������� (Outputs.DateConfirm)
		/// </summary>
		[Description("������-����: ���� �������������: ��������� ���� ������� (Outputs.DateConfirm)")]
		public DateTime? FilterDateBegConfirm { get { return _FilterDateBegConfirm; } set { _FilterDateBegConfirm = value; _NeedRequery = true; } }

		protected DateTime? _FilterDateEndConfirm;
		/// <summary>
		/// ������-����: ���� �������������: �������� ���� ������� (Outputs.DateConfirm)
		/// </summary>
		[Description("������-����: ���� �������������: �������� ���� ������� (Outputs.DateConfirm)")]
		public DateTime? FilterDateEndConfirm { get { return _FilterDateEndConfirm; } set { _FilterDateEndConfirm = value; _NeedRequery = true; } }

		protected string _FilterOutputsTypesList;
		/// <summary>
		/// ������-����: ������ ����� ������� (Outputs.OutputTypeID), ����� �������
		/// </summary>
		[Description("������-����: ������ ����� ������� (Outputs.OutputTypeID), ����� �������")]
		public string FilterOutputsTypesList { get { return _FilterOutputsTypesList; } set { _FilterOutputsTypesList = value; } }

		protected string _FilterPartnersList;
		/// <summary>
		/// ������-����: ������ ����������� (Outputs.PartnerID), ����� �������
		/// </summary>
		[Description("������-����: ������ ����������� (Outputs.PartnerID), ����� �������")]
		public string FilterPartnersList { get { return _FilterPartnersList; } set { _FilterPartnersList = value; } }

		protected string _FilterPartnerContext;
		/// <summary>
		/// ������-����: �������� ���������� (Outputs.PartnerID -> Partners.Name), ��������
		/// </summary>
		[Description("������-����: �������� ���������� (Outputs.PartnerID -> Partners.Name), ��������")]
		public string FilterPartnerContext { get { return _FilterPartnerContext; } set { _FilterPartnerContext = value; } }

		protected string _FilterCarAliasContext;
		/// <summary>
		/// ������-����: �������� ������ (Outputs.CarAlias), ��������
		/// </summary>
		[Description("������-����: �������� ������ (Outputs.CarAlias), ��������")]
		public string FilterCarAliasContext { get { return _FilterCarAliasContext; } set { _FilterCarAliasContext = value; } }

		protected string _FilterCarsAliasesList;
		/// <summary>
		/// ������-����: ������ �������� ����� (Outputs.CarAlias), ����� ����������� (_Settings.ssCarAliasDelimeter)
		/// </summary>
		[Description("������-����: ������ �������� ����� (Outputs.CarAlias), ����� �����������")]
		public string FilterCarsAliasesList { get { return _FilterCarsAliasesList; } set { _FilterCarsAliasesList = value; } }

		protected bool? _FilterBackDoor;
		/// <summary>
		/// ������-����: ������ ����� (Outputs.BackDoor)?
		/// </summary>
		[Description("������-����: ������ ����� (Outputs.BackDoor)?")]
		public bool? FilterBackDoor { get { return _FilterBackDoor; } set { _FilterBackDoor = value; } }

		protected string _FilterGoodsStatesList;
		/// <summary>
		/// ������-����: ������ ��������� ������ (Outputs.GoodStateID), ����� �������
		/// </summary>
		[Description("������-����: ������ ��������� ������ ������ (Outputs.GoodStateID), ����� �������")]
		public string FilterGoodsStatesList { get { return _FilterGoodsStatesList; } set { _FilterGoodsStatesList = value; } }

		protected string _FilterOwnersList;
		/// <summary>
		/// ������-����: ������ ���������� ������ (Outputs.OwnerID), ����� �������
		/// </summary>
		[Description("������-����: ������ ���������� ������ (Outputs.OwnerID), ����� �������")]
		public string FilterOwnersList { get { return _FilterOwnersList; } set { _FilterOwnersList = value; } }

		protected string _FilterPackingsList;
		/// <summary>
		/// ������-����: ������ ID �������� (OutputsGoods.PackingID), ����� �������
		/// </summary>
		[Description("������-����: ������ ID �������� (OutputsGoods.PackingID), ����� �������")]
		public string FilterPackingsList { get { return _FilterPackingsList; } set { _FilterPackingsList = value; _NeedRequery = true; } }

		protected string _FilterGoodsList;
		/// <summary>
		/// ������-����: ������ ID ������� (OutputsGoods.PackingID -> Packings.GoodID -> Goods.ID), ����� �������
		/// </summary>
		[Description("������-����: ������ ID ������� (Outputs.PackingID -> Packings.GoodID -> Goods.ID), ����� �������")]
		public string FilterGoodsList { get { return _FilterGoodsList; } set { _FilterGoodsList = value; _NeedRequery = true; } }

		protected bool? _FilterPicked;
		/// <summary>
		/// ������-����: ������� ������� (Outputs.DatePick)?
		/// </summary>
		[Description("������-����: ������� ������� (Outputs.DatePick)?")]
		public bool? FilterPicked { get { return _FilterPicked; } set { _FilterPicked = value; } }

		protected bool? _FilterConfirmed;
		/// <summary>
		/// ������-����: ������� ������������ (Outputs.DateConfirm)?
		/// </summary>
		[Description("������-����: ������� ������������ (Outputs.DateConfirm)?")]
		public bool? FilterConfirmed { get { return _FilterConfirmed; } set { _FilterConfirmed = value; } }

		protected int? _FilterOutputSelectedInfo;
		/// <summary>
		/// ������-����: ���������� � ������� ������� (Outputs -> OutputsGoods.QntSelected)
		/// 0 ������ �� ���������, 1 �� ��� ���������, 2 ��� ���������
		/// </summary>
		[Description("������-����: ���������� � ������� ������� (Outputs -> OutputsGoods.QntSelected)?")]
		public int? FilterOutputSelectedInfo { get { return _FilterOutputSelectedInfo; } set { _FilterOutputSelectedInfo = value; _NeedRequery = true; } }

		protected int? _FilterOutputTrafficsInfo;
		/// <summary>
		/// ������-����: ���������� �� ��������� ��������������� �����������/����������� �������/���� (Outputs -> TrafficsFrames.OutputID, TrafficsGoods.OutputID)? 
		/// 0 ��� �� ���������, 1 ��������� �� ���������, 2 ��� ���������
		/// </summary>
		[Description("������-����: ���������� �� ��������� ��������������� �����������/����������� �������/����?")]
		public int? FilterOutputTrafficsInfo { get { return _FilterOutputTrafficsInfo; } set { _FilterOutputTrafficsInfo = value; _NeedRequery = true; } }

		protected bool? _FilterFullConfirmed;
		/// <summary>
		/// ������-����: ������� ������������ ��������� (OutputsGoods.QntConfirmed >= QntSelected)?
		/// </summary>
		[Description("������-����: ������� ������������ ��������� (OutputsGoods.QntConfirmed >= QntSelected)?")]
		public bool? FilterFullConfirmed { get { return _FilterFullConfirmed; } set { _FilterFullConfirmed = value; } }

		#endregion Filters

		// �������
		#region Tables

		protected DataTable _TableOutputsGoods;
		/// <summary>
		/// ������ ������� � ������� (TableOutputsGoods)
		/// </summary>
		[Description("������ ������� � ������� (TableOutputsGoods)")]
		public DataTable TableOutputsGoods { get { return _TableOutputsGoods; } }

		protected DataTable _TableOutputsItems;
		/// <summary>
		/// ������ ������������ ������� (TableOutputsItems)
		/// </summary>
		[Description("������ ������������ ������� (TableOutputsItems)")]
		public DataTable TableOutputsItems { get { return _TableOutputsItems; } }

		protected DataTable _TableOutputsPallets;
		/// <summary>
		/// ������ ������ � ������� - ��� ��������� 
		/// </summary>
		[Description("������ ������ � ������� - ��� ���������")]
		public DataTable TableOutputsPallets { get { return _TableOutputsPallets; } }

		protected DataTable _TableOutputsFrames;
		/// <summary>
		/// ������ ����������� � �������
		/// </summary>
		[Description("������ ����������� � �������")]
		public DataTable TableOutputsFrames { get { return _TableOutputsFrames; } }

		protected DataTable _TableOutputsTrafficsFrames;
		/// <summary>
		/// ������ �������� �� ��������������� ����������� � �������
		/// </summary>
		[Description("������ �������� �� ��������������� ����������� � �������")]
		public DataTable TableOutputsTrafficsFrames { get { return _TableOutputsTrafficsFrames; } }

		protected DataTable _TableOutputsTrafficsGoods;
		/// <summary>
		/// ������ �������� �� ����������� �������/���� � �������
		/// </summary>
		[Description("������ �������� �� ��������������� ����������� � �������")]
		public DataTable TableOutputsTrafficsGoods { get { return _TableOutputsTrafficsGoods; } }

		protected DataTable _TableOutputsPickList;
		/// <summary>
		/// ������ �������� ��� ������������ ���-����� � �������
		/// </summary>
		[Description("������ �������� ��� ������������ ���-����� � �������")]
		public DataTable TableOutputsPickList { get { return _TableOutputsPickList; } }

		protected DataTable _TableOutputsTypes;
		/// <summary>
		/// ������� ����� ��������
		/// </summary>
		[Description("������� ����� �������� (TableOutputsTypes)")]
		public DataTable TableOutputsTypes { get { return _TableOutputsTypes; } }

		protected DataTable _TableOutputsCarsAliases;
		/// <summary>
		/// ������� �������� ����� � �������� 
		/// </summary>
		[Description("������� �������� ����� � �������� (TableOutputsCarsAliases)")]
		public DataTable TableOutputsCarsAliases { get { return _TableOutputsCarsAliases; } }

		protected DataTable _TableOutputsLoaders;
		/// <summary>
		/// ������� �����������, ����������� �������� ������ � ������
		/// </summary>
		[Description("������� �����������, ����������� �������� ������ � ������ (TableOutputsLoaders)")]
		public DataTable TableOutputsLoaders { get { return _TableOutputsLoaders; } }

		#endregion Tables

		// -------------------------------------

		public Output()
			: base()
		{
			_MainTableName = "Outputs";
		}

		#region FillData

		/// <summary>
		/// ��������� ������ �������� (MainTable)
		/// </summary>
		public override bool FillData()
		{
			ClearData();

			string sqlSelect = "execute up_OutputsFill " +
				"@nID, @cIDList, " +
				"@cHostsList, " + 
				"@cBarCode, @bPicked, @bConfirmed, " +
				"@dDateBeg, @dDateEnd, " +
				"@dDateBegConfirm, @dDateEndConfirm, " +
				"@cOutputsTypesList, " +
				"@cGoodsStatesList, @cOwnersList, " +
				"@cPartnersList, @cPartnerContext, " +
				"@cCarAliasContext, @cCarsAliasesList, @bBackDoor, " +
				"@cPackingsList, @cGoodsList, " +
				"@nOutputSelectedInfo, @nOutputTrafficsInfo, @bOutputFullConfirmedInfo";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_OutputsFill parameters

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

			_oCommand.Parameters.Add("@cHostsList", SqlDbType.VarChar);
			if (_FilterHostsList != null)
				_oCommand.Parameters["@cHostsList"].Value = _FilterHostsList;
			else
				_oCommand.Parameters["@cHostsList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cBarCode", SqlDbType.VarChar);
			if (BarCode != null)
				_oCommand.Parameters["@cBarCode"].Value = BarCode;
			else
				_oCommand.Parameters["@cBarCode"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bPicked", SqlDbType.Bit);
			if (_FilterPicked != null)
				_oCommand.Parameters["@bPicked"].Value = _FilterPicked;
			else
				_oCommand.Parameters["@bPicked"].Value = DBNull.Value;

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

			_oCommand.Parameters.Add("@dDateBegConfirm", SqlDbType.SmallDateTime);
			if (_FilterDateBegConfirm.HasValue)
				_oCommand.Parameters["@dDateBegConfirm"].Value = _FilterDateBegConfirm;
			else
				_oCommand.Parameters["@dDateBegConfirm"].Value = DBNull.Value;
			_oCommand.Parameters.Add("@dDateEndConfirm", SqlDbType.SmallDateTime);
			if (_FilterDateEndConfirm.HasValue)
				_oCommand.Parameters["@dDateEndConfirm"].Value = _FilterDateEndConfirm;
			else
				_oCommand.Parameters["@dDateEndConfirm"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cOutputsTypesList", SqlDbType.VarChar);
			if (_FilterOutputsTypesList != null)
				_oCommand.Parameters["@cOutputsTypesList"].Value = _FilterOutputsTypesList;
			else
				_oCommand.Parameters["@cOutputsTypesList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cGoodsStatesList", SqlDbType.VarChar);
			if (_FilterGoodsStatesList != null)
				_oCommand.Parameters["@cGoodsStatesList"].Value = _FilterGoodsStatesList;
			else
				_oCommand.Parameters["@cGoodsStatesList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cOwnersList", SqlDbType.VarChar);
			if (_FilterOwnersList != null)
				_oCommand.Parameters["@cOwnersList"].Value = _FilterOwnersList;
			else
				_oCommand.Parameters["@cOwnersList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cPartnersList", SqlDbType.VarChar);
			if (_FilterPartnersList != null)
				_oCommand.Parameters["@cPartnersList"].Value = _FilterPartnersList;
			else
				_oCommand.Parameters["@cPartnersList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cPartnerContext", SqlDbType.VarChar);
			if (_FilterPartnerContext != null)
				_oCommand.Parameters["@cPartnerContext"].Value = _FilterPartnerContext;
			else
				_oCommand.Parameters["@cPartnerContext"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cCarAliasContext", SqlDbType.VarChar);
			if (_FilterCarAliasContext != null)
				_oCommand.Parameters["@cCarAliasContext"].Value = _FilterCarAliasContext;
			else
				_oCommand.Parameters["@cCarAliasContext"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cCarsAliasesList", SqlDbType.VarChar);
			if (_FilterCarsAliasesList != null)
				_oCommand.Parameters["@cCarsAliasesList"].Value = _FilterCarsAliasesList;
			else
				_oCommand.Parameters["@cCarsAliasesList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bBackDoor", SqlDbType.Bit);
			if (_FilterBackDoor != null)
				_oCommand.Parameters["@bBackDoor"].Value = _FilterBackDoor;
			else
				_oCommand.Parameters["@bBackDoor"].Value = DBNull.Value;

			#region up_OutputsFill OutputsGoods-paramaters

			//���� ��� ������ ����� ������ ������� (OutputsGoods)

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

			_oCommand.Parameters.Add("@nOutputSelectedInfo", SqlDbType.Int);
			if (_FilterOutputSelectedInfo.HasValue)
				_oCommand.Parameters["@nOutputSelectedInfo"].Value = _FilterOutputSelectedInfo;
			else
				_oCommand.Parameters["@nOutputSelectedInfo"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@nOutputTrafficsInfo", SqlDbType.Int);
			if (_FilterOutputTrafficsInfo.HasValue)
				_oCommand.Parameters["@nOutputTrafficsInfo"].Value = _FilterOutputTrafficsInfo;
			else
				_oCommand.Parameters["@nOutputTrafficsInfo"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bOutputFullConfirmedInfo", SqlDbType.Bit);
			
			if (_FilterFullConfirmed != null)
				_oCommand.Parameters["@bOutputFullConfirmedInfo"].Value = _FilterFullConfirmed;
			else
				_oCommand.Parameters["@bOutputFullConfirmedInfo"].Value = DBNull.Value;

			#endregion

			try
			{
				_MainTable = FillReadings(new SqlDataAdapter(_oCommand), _MainTable, _MainTableName);
				_NeedRequery = false;
			}
			catch (Exception ex)
			{
				_ErrorNumber = -1;
				_ErrorStr = "������ ��� ��������� ������ ��������..." + Convert.ToChar(13) + ex.Message;
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
			_FilterHostsList = null;
			_FilterDateBeg = null;
			_FilterDateEnd = null;
			_FilterDateBegConfirm = null;
			_FilterDateEndConfirm = null;
			_FilterOutputsTypesList = null;
			_FilterGoodsStatesList = null;
			_FilterOwnersList = null;
			_FilterPartnersList = null;
			_FilterPartnerContext = null;
			_FilterCarAliasContext = null;
			_FilterCarsAliasesList = null;
			_FilterBackDoor = null;
			_FilterPicked = null;
			_FilterConfirmed = null;
			_FilterPackingsList = null;
			_FilterGoodsList = null;
			_FilterOutputSelectedInfo = null;
			_FilterOutputTrafficsInfo = null;
			_FilterFullConfirmed = null; 
			//_NeedRequery = false;
		}

		#endregion FillData


		#region OutputsTypes

		/// <summary>
		/// ���������� ������� ����� �������� (TableOutputsTypes)
		/// </summary>
		public bool FillTableOutputsTypes()
		{
			string sqlSelect = "select OT.ID, OT.Name, " +
					"OT.OwnerID, Ow.Name as OwnerName, " +
					"OT.GoodStateID, GS.Name as GoodStateName, " +
					"OT.CellID, C.Address as CellAddress, " +
					"OT.Actual " +
				"from OutputsTypes OT " +
				"left join Partners Ow on OT.OwnerID = Ow.ID " +
				"left join GoodsStates GS on OT.GoodStateID = GS.ID " +
				"left join Cells C on OT.CEllID = C.ID " +
				"order by OT.Name";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			try
			{
				_TableOutputsTypes = FillReadings(new SqlDataAdapter(_oCommand), _TableOutputsGoods, "TableOutputsTypes");
			}
			catch (Exception ex)
			{
				_ErrorNumber = -11;
				_ErrorStr = "������ ��� ��������� ������ ����� ��������..." + Convert.ToChar(13) + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		#endregion OutputsTypes

		#region OutputsGoods

		/// <summary>
		/// ���������� ������� ������� � ������� (TableOutputsGoods)
		/// </summary>
		public bool FillTableOutputsGoods(int? nOutputID)
		{
			if (!nOutputID.HasValue & !_ID.HasValue)
			{
				_ErrorNumber = -12;
				_ErrorStr = "������������ �����:\r\n������ ��� ��������� ������ ������� � �������...";
				RFMMessage.MessageBoxError(_ErrorStr);
				return (false);
			}
			if (!nOutputID.HasValue)
				nOutputID = _ID;

			string sqlSelect = "execute up_OutputsGoodsFill @nOutputID, @nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_OutputsGoodsFill parameters

			_oCommand.Parameters.Add("@nOutputID", SqlDbType.Int);
			_oCommand.Parameters["@nOutputID"].Value = nOutputID;

			_oCommand.Parameters.Add("@nError", SqlDbType.Int);
			_oCommand.Parameters["@nError"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@nError"].Value = 0;

			_oCommand.Parameters.Add("@cErrorText", SqlDbType.VarChar, 200);
			_oCommand.Parameters["@cErrorText"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@cErrorText"].Value = "";

			#endregion

			try
			{
				_TableOutputsGoods = FillReadings(new SqlDataAdapter(_oCommand), _TableOutputsGoods, "TableOutputsGoods");

				// primarykey
				//DataColumn[] pk = new DataColumn[1];
				//pk[0] = _TableOutputsGoods.Columns["PackingID"];
				//_TableOutputsGoods.PrimaryKey = pk;
			}
			catch (Exception ex)
			{
				_ErrorNumber = -4;
				_ErrorStr = "������ ��� ��������� ������ ������� � �������...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			if (_ErrorNumber == 0)
			{
				_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
				if (_ErrorNumber != 0)
				{
					_ErrorStr = "������ ��� ��������� ������ ������� � �������...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// ���������� ������� ������� � ������� ��� �������������! (TableOutputsGoods)
		/// </summary>
		public bool FillTableOutputsGoodsAnytime(int? nOutputID)
		{
			if (!nOutputID.HasValue & !_ID.HasValue)
			{
				_ErrorNumber = -12;
				_ErrorStr = "������������ �����:\r\n������ ��� ��������� ������ ������� � �������...";
				RFMMessage.MessageBoxError(_ErrorStr);
				return (false);
			}
			if (!nOutputID.HasValue)
				nOutputID = _ID;

			string sqlSelect = "execute up_OutputsGoodsFillAnytime @nOutputID, " +
				"@nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_OutputsGoodsFillAnytime parameters

			_oCommand.Parameters.Add("@nOutputID", SqlDbType.Int);
			_oCommand.Parameters["@nOutputID"].Value = nOutputID;

			_oCommand.Parameters.Add("@nError", SqlDbType.Int);
			_oCommand.Parameters["@nError"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@nError"].Value = 0;

			_oCommand.Parameters.Add("@cErrorText", SqlDbType.VarChar, 200);
			_oCommand.Parameters["@cErrorText"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@cErrorText"].Value = "";

			#endregion

			try
			{
				_TableOutputsGoods = FillReadings(new SqlDataAdapter(_oCommand), _TableOutputsGoods, "TableOutputsGoods");
			}
			catch (Exception ex)
			{
				_ErrorNumber = -4;
				_ErrorStr = "������ ��� ��������� ������ ������� � �������...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			if (_ErrorNumber == 0)
			{
				_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
				if (_ErrorNumber != 0)
				{
					_ErrorStr = "������ ��� ��������� ������ ������� � �������...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		#endregion OutputsGoods

		#region OutputsItems

		/// <summary>
		/// ���������� ������� ������������ � ������� (TableOutputsItems)
		/// </summary>
		public bool FillTableOutputsItems(int? nOutputID)
		{
			if (!nOutputID.HasValue & !_ID.HasValue)
			{
				_ErrorNumber = -15;
				_ErrorStr = "������������ �����:\r\n������ ��� ��������� ������ ������������ � �������...";
				RFMMessage.MessageBoxError(_ErrorStr);
				return (false);
			}
			if (!nOutputID.HasValue)
				nOutputID = _ID;

			string sqlSelect = "execute up_OutputsItemsFill @nOutputID, @nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_OutputsItemsFill parameters

			_oCommand.Parameters.Add("@nOutputID", SqlDbType.Int);
			_oCommand.Parameters["@nOutputID"].Value = nOutputID;

			_oCommand.Parameters.Add("@nError", SqlDbType.Int);
			_oCommand.Parameters["@nError"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@nError"].Value = 0;

			_oCommand.Parameters.Add("@cErrorText", SqlDbType.VarChar, 200);
			_oCommand.Parameters["@cErrorText"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@cErrorText"].Value = "";

			#endregion

			try
			{
				_TableOutputsItems = FillReadings(new SqlDataAdapter(_oCommand), _TableOutputsItems, "TableOutputsItems");
			}
			catch (Exception ex)
			{
				_ErrorNumber = -5;
				_ErrorStr = "������ ��� ��������� ������ ������������ � �������...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			if (_ErrorNumber == 0)
			{
				_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
				if (_ErrorNumber != 0)
				{
					_ErrorStr = "������ ��� ��������� ������ ������������ � �������...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		#endregion OutputsItems

		#region OutputsPallets

		/// <summary>
		/// ���������� ������� ������ � ������� (TableOutputsPallets)
		/// </summary>
		public bool FillTableOutputsPallets(int? nOutputID)
		{
			if (!nOutputID.HasValue & !_ID.HasValue)
			{
				_ErrorNumber = -14;
				_ErrorStr = "������������ �����:\r\n������ ��� ��������� ������ ������� � �������...";
				RFMMessage.MessageBoxError(_ErrorStr);
				return (false);
			}
			if (!nOutputID.HasValue)
				nOutputID = _ID;

			string sqlSelect = "execute up_OutputsPalletsFill @nOutputId, @nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_OutputsPalletsFill parameters

			_oCommand.Parameters.Add("@nOutputId", SqlDbType.Int);
			_oCommand.Parameters["@nOutputId"].Value = nOutputID;

			_oCommand.Parameters.Add("@nError", SqlDbType.Int);
			_oCommand.Parameters["@nError"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@nError"].Value = 0;

			_oCommand.Parameters.Add("@cErrorText", SqlDbType.VarChar, 200);
			_oCommand.Parameters["@cErrorText"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@cErrorText"].Value = "";

			#endregion

			try
			{
				_TableOutputsPallets = FillReadings(new SqlDataAdapter(_oCommand), _TableOutputsPallets, "TableOutputsPallets");
			}
			catch (Exception ex)
			{
				_ErrorNumber = -4;
				_ErrorStr = "������ ��� ��������� ������ ������ � �������...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			if (_ErrorNumber == 0)
			{
				_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
				if (_ErrorNumber != 0)
				{
					_ErrorStr = "������ ��� ��������� ������ ������ � �������...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		#endregion OutputsPallets

		#region OutputsFrames

		/// <summary>
		/// ���������� ������� ����������� � ������� (TableOutputsFrames)
		/// </summary>
		public bool FillTableOutputsFrames(int? nOutputID)
		{
			if (!nOutputID.HasValue & !_ID.HasValue)
			{
				_ErrorNumber = -15;
				_ErrorStr = "������������ �����:\r\n������ ��� ��������� ������ ����������� � �������...";
				RFMMessage.MessageBoxError(_ErrorStr);
				return (false);
			}
			if (!nOutputID.HasValue)
				nOutputID = _ID;

			string sqlSelect = "execute up_OutputsFramesFill @nOutputID, " +
									"@nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_OutputsFramesFill parameters

			_oCommand.Parameters.Add("@nOutputID", SqlDbType.Int);
			_oCommand.Parameters["@nOutputID"].Value = nOutputID;

			_oCommand.Parameters.Add("@nError", SqlDbType.Int);
			_oCommand.Parameters["@nError"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@nError"].Value = 0;

			_oCommand.Parameters.Add("@cErrorText", SqlDbType.VarChar, 200);
			_oCommand.Parameters["@cErrorText"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@cErrorText"].Value = "";

			#endregion

			try
			{
				_TableOutputsFrames = FillReadings(new SqlDataAdapter(_oCommand), _TableOutputsFrames, "TableOutputsFrames");
			}
			catch (Exception ex)
			{
				_ErrorNumber = -5;
				_ErrorStr = "������ ��� ��������� ������ ����������� � �������...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			if (_ErrorNumber == 0)
			{
				_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
				if (_ErrorNumber != 0)
				{
					_ErrorStr = "������ ��� ��������� ������ ����������� � �������...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		#endregion OutputsFrames

		#region OutputsPallets - �� ��������

		/// <summary>
		/// ���������� ������� ������� � ������� - �� ��������!
		/// </summary>
		public bool FillTableOutputsPalletsEach(int? nOutputID, string sTableOutputsGoodsPallets)
		{
			if (!nOutputID.HasValue & !_ID.HasValue)
			{
				_ErrorNumber = -12;
				_ErrorStr = "������������ �����:\r\n������ ��� ��������� ������ ������� �� �������� � �������...";
				RFMMessage.MessageBoxError(_ErrorStr);
				return (false);
			}
			if (!nOutputID.HasValue)
				nOutputID = _ID;

			string sqlSelect = "execute up_OutputsPalletsEachFill @nOutputID, @nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_OutputsGoodsFill parameters

			_oCommand.Parameters.Add("@nOutputID", SqlDbType.Int);
			_oCommand.Parameters["@nOutputID"].Value = nOutputID;

			_oCommand.Parameters.Add("@nError", SqlDbType.Int);
			_oCommand.Parameters["@nError"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@nError"].Value = 0;

			_oCommand.Parameters.Add("@cErrorText", SqlDbType.VarChar, 200);
			_oCommand.Parameters["@cErrorText"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@cErrorText"].Value = "";

			#endregion

			try
			{
				FillReadings(new SqlDataAdapter(_oCommand), null, sTableOutputsGoodsPallets);
			}
			catch (Exception ex)
			{
				_ErrorNumber = -4;
				_ErrorStr = "������ ��� ��������� ������ ������� �� �������� � �������...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			if (_ErrorNumber == 0)
			{
				_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
				if (_ErrorNumber != 0)
				{
					_ErrorStr = "������ ��� ��������� ������ ������� �� �������� � �������...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		#endregion OutputsPallets

		#region OutputsTraffics

		/// <summary>
		/// ���������� ������� �������� ���������������/����������� ����/������� � ������� (TableOutputsTrafficsFrames, TableOutputsTrafficsGoods)
		/// </summary>
		public bool FillTableOutputsTraffics(int? nOutputID, bool bFrameMode)
		{
			string sText = (bFrameMode) ? "�������� ��������������� �����������" : "�������� ����������� �������/����";

			if (!nOutputID.HasValue & !_ID.HasValue)
			{
				_ErrorNumber = -21;
				_ErrorStr = "������������ �����:\r\n������ ��� ��������� ������ " + sText + " � �������...";
				RFMMessage.MessageBoxError(_ErrorStr);
				return (false);
			}
			if (!nOutputID.HasValue)
				nOutputID = _ID;

			string sqlSelect = "execute up_OutputsTrafficsFill @nOutputID, @bFrameMode";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_OutputsGoodsFill parameters

			_oCommand.Parameters.Add("@nOutputID", SqlDbType.Int);
			_oCommand.Parameters["@nOutputID"].Value = nOutputID;

			_oCommand.Parameters.Add("@bFrameMode", SqlDbType.Bit);
			_oCommand.Parameters["@bFrameMode"].Value = bFrameMode;

			#endregion

			try
			{
				SqlDataAdapter adapter = new SqlDataAdapter(_oCommand);
				if (bFrameMode)
				{
					_TableOutputsTrafficsFrames = FillReadings(new SqlDataAdapter(_oCommand), _TableOutputsTrafficsFrames, "TableOutputsTrafficsFrames");

					DataColumn[] pk = new DataColumn[1];
					pk[0] = _TableOutputsTrafficsFrames.Columns["ID"];
					_TableOutputsTrafficsFrames.PrimaryKey = pk;
				}
				else
				{
					_TableOutputsTrafficsGoods = FillReadings(new SqlDataAdapter(_oCommand), _TableOutputsTrafficsGoods, "TableOutputsTrafficsGoods");

					DataColumn[] pk = new DataColumn[1];
					pk[0] = _TableOutputsTrafficsGoods.Columns["ID"];
					_TableOutputsTrafficsGoods.PrimaryKey = pk;
				}
			}
			catch (Exception ex)
			{
				_ErrorNumber = -4;
				_ErrorStr = "������ ��� ��������� ������ " + sText + " � �������...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// ���������� ������� �������� ��������������� ��� ���-�����
		/// </summary>
		public bool FillTableOutputsTrafficsFramesContains(string sOutputsList)
		{
			string sqlSelect = "execute up_OutputsTrafficsFramesContentsFill @cOutputsList";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_OutputsTrafficsFramesContainsFill parameters

			_oCommand.Parameters.Add("@cOutputsList", SqlDbType.VarChar);
			if (sOutputsList != null)
				_oCommand.Parameters["@cOutputsList"].Value = sOutputsList;
			else
				_oCommand.Parameters["@cOutputsList"].Value = DBNull.Value;

			#endregion

			try
			{
				FillReadings(new SqlDataAdapter(_oCommand), null, "TableOutputsTrafficsFramesContains");
			}
			catch (Exception ex)
			{
				_ErrorNumber = -10;
				_ErrorStr = "������ ��� ��������� ������ �������� ��������������� ����������� � ��������...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// ���������� ������� ��� ������������ ���-����� � ������� (TableOutputsPickList)
		/// </summary>
		public bool FillTableOutputsPickList(int? nOutputID, string sOutputIDList, bool? bPrinted)
		{
			if (_DS.Tables["TableOutputsPickList"] != null)
			{
				_DS.Tables.Remove("TableOutputsPickList");
				_TableOutputsPickList = null;
			}

			string sqlSelect = "execute up_OutputsPickListFill " +
					"@nOutputID, @cOutputIDList, @bPrinted";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);
			_oCommand.CommandTimeout = 0;

			#region up_OutputsGoodsFill parameters

			_oCommand.Parameters.Add("@nOutputID", SqlDbType.Int);
			if (nOutputID.HasValue)
				_oCommand.Parameters["@nOutputID"].Value = nOutputID;
			else
				_oCommand.Parameters["@nOutputID"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cOutputIDList", SqlDbType.VarChar);
			if (sOutputIDList != null)
				_oCommand.Parameters["@cOutputIDList"].Value = sOutputIDList;
			else
				_oCommand.Parameters["@cOutputIDList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bPrinted", SqlDbType.Bit);
			if (bPrinted.HasValue)
				_oCommand.Parameters["@bPrinted"].Value = bPrinted;
			else
				_oCommand.Parameters["@bPrinted"].Value = DBNull.Value;

			#endregion

			try
			{
				_TableOutputsPickList = FillReadings(new SqlDataAdapter(_oCommand), _TableOutputsPickList, "TableOutputsPickList");
			}
			catch (Exception ex)
			{
				_ErrorNumber = -4;
				_ErrorStr = "������ ��� ��������� ������ �������� ��� ������������ ���-����� � �������...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		#endregion OutputsTraffics

		#region OutputsCarsAliases

		/// <summary>
		/// ���������� ������� �������� ����� � �������� (TableOutputsCarsAliases)
		/// </summary>
		public bool FillTableOutputsCarsAliases(DateTime? dDateBeg, DateTime? dDateEnd, string sCarAliasContext)
		{
			string sqlSelect = "execute up_OutputsCarsAliasesFill " +
				"@dDateBeg, @dDateEnd, " +
				"@cCarAliasContext ";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_OutputsCarsAliasesFill parameters

			_oCommand.Parameters.Add("@dDateBeg", SqlDbType.SmallDateTime);
			if (dDateBeg != null)
				_oCommand.Parameters["@dDateBeg"].Value = dDateBeg;
			else
				_oCommand.Parameters["@dDateBeg"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@dDateEnd", SqlDbType.SmallDateTime);
			if (dDateEnd != null)
				_oCommand.Parameters["@dDateEnd"].Value = dDateEnd;
			else
				_oCommand.Parameters["@dDateEnd"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cCarAliasContext", SqlDbType.VarChar);
			if (sCarAliasContext != null)
				_oCommand.Parameters["@cCarAliasContext"].Value = sCarAliasContext;
			else
				_oCommand.Parameters["@cCarAliasContext"].Value = DBNull.Value;

			#endregion

			try
			{
				_TableOutputsCarsAliases = FillReadings(new SqlDataAdapter(_oCommand), _TableOutputsCarsAliases, "TableOutputsCarsAliases");
			}
			catch (Exception ex)
			{
				_ErrorNumber = -21;
				_ErrorStr = "������ ��� ��������� ������ ����� � ��������..." + Convert.ToChar(13) + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		#endregion OutputsCarsAliases

		#region OutputsLoaders

		/// <summary>
		/// ���������� ������� ����������� ������ � ������ (TableOutputsLoaders)
		/// </summary>
		public bool FillTableOutputsLoaders(int? nOutputID)
		{
			if (!nOutputID.HasValue & !_ID.HasValue)
			{
				_ErrorNumber = -16;
				_ErrorStr = "������������ �����:\r\n������ ��� ��������� ������ �����������, ����������� �������� ������ ��� �������...";
				RFMMessage.MessageBoxError(_ErrorStr);
				return (false);
			}
			if (!nOutputID.HasValue)
				nOutputID = _ID;

			string sqlSelect = "execute up_OutputsLoadersFill @nOutputID, " +
									"@nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_OutputsLoadersFill parameters

			_oCommand.Parameters.Add("@nOutputID", SqlDbType.Int);
			_oCommand.Parameters["@nOutputID"].Value = nOutputID;

			_oCommand.Parameters.Add("@nError", SqlDbType.Int);
			_oCommand.Parameters["@nError"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@nError"].Value = 0;

			_oCommand.Parameters.Add("@cErrorText", SqlDbType.VarChar, 200);
			_oCommand.Parameters["@cErrorText"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@cErrorText"].Value = "";

			#endregion

			try
			{
				_TableOutputsLoaders = FillReadings(new SqlDataAdapter(_oCommand), _TableOutputsLoaders, "TableOutputsLoaders");
			}
			catch (Exception ex)
			{
				_ErrorNumber = -5;
				_ErrorStr = "������ ��� ��������� ������ �����������, ����������� �������� ������ ��� �������...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			if (_ErrorNumber == 0)
			{
				_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
				if (_ErrorNumber != 0)
				{
					_ErrorStr = "������ ��� ��������� ������ �����������, ����������� �������� ������ ��� �������...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		#endregion OutputsLoaders

		/// <summary>
		/// ��������� ������ ID �� ������ ERP-����� 
		/// </summary>
		public string FillIDListByErpCodeList(string sErpCodesList)
		{
			if (sErpCodesList == null)
				return (null);
			if (sErpCodesList == "")
				return ("");

			string sIDList = "";

			if (sErpCodesList.Substring(0, 1) == ",")
				sErpCodesList.Substring(1);
			if (sErpCodesList.Substring(sErpCodesList.Length - 1, 1) == ",")
				sErpCodesList.Substring(0, sErpCodesList.Length - 1);

			string sqlSelect = "select ID from Outputs with (nolock) " +
				"where rtrim(ltrim(ERPCode)) in ('" + sErpCodesList + "')" +
				"order by ID";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			try
			{
				FillReadings(new SqlDataAdapter(_oCommand), null, "TableTemp");

				if (_DS.Tables["TableTemp"] != null && _DS.Tables["TableTemp"].Rows.Count > 0)
				{
					foreach (DataRow r in _DS.Tables["TableTemp"].Rows)
						sIDList += r["ID"].ToString().Trim() + ",";
				}
			}
			catch (Exception ex)
			{
				_ErrorNumber = -71;
				_ErrorStr = "������ ��� ��������� ������ ����� ��������..." + Convert.ToChar(13) + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (sIDList);
		}

		#region Save

		/// <summary>
		/// ����������-������������� �������
		/// </summary>
		public bool SaveData(int nOutputID)
		{
			return SaveData(nOutputID, 0);
		}

		public bool SaveData(int nOutputID, int nHostID)
		{
			if (_MainTable.Rows.Count == 0 || _MainTable.Rows[0] == null)
			{
				_ErrorNumber = -20;
				_ErrorStr = "��� ������ ��� ���������� �������...";
				RFMMessage.MessageBoxError(_ErrorStr);
				return (false);
			}

			DataRow r = _MainTable.Rows[0];

			// � �������������� ��������� ������: "�������" � "����"
			try
			{
				_Connect.Open();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -1;
				_ErrorStr = "������ ��� ���������� � ��������...\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
				return (false);
			}

			RFMUtilities.DataTableToTempTable(TableOutputsPallets, "#OutputsPallets", _Connect);

			String _sqlCommand = "execute up_OutputsSave @nOutputID output, " +
					"@nHostID, " + 
					"@dDateOutput, " +
					"@nOutputTypeID, " +
					"@nOwnerID, @nGoodStateID, " +
					"@nCellID, " +
					"@cNote, @cBarCode, " +
					"@nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(_sqlCommand, _Connect);

			#region up_OutputsSave parameters

			SqlParameter _oParameter = _oCommand.Parameters.Add("@nOutputID", SqlDbType.Int);
			_oParameter.Value = nOutputID;
			_oParameter.Direction = ParameterDirection.InputOutput;

			_oParameter = _oCommand.Parameters.Add("@nHostID", SqlDbType.Int);
			_oParameter.Value = nHostID;

			_oParameter = _oCommand.Parameters.Add("@dDateOutput", SqlDbType.DateTime);
			_oParameter.Value = DateTime.Parse(r["DateOutput"].ToString());

			_oParameter = _oCommand.Parameters.Add("@nOutputTypeID", SqlDbType.Int);
			_oParameter.Value = Int32.Parse(r["OutputTypeID"].ToString());

			_oParameter = _oCommand.Parameters.Add("@nOwnerID", SqlDbType.Int);
			_oParameter.Value = Int32.Parse(r["OwnerID"].ToString());

			_oParameter = _oCommand.Parameters.Add("@nGoodStateID", SqlDbType.Int);
			_oParameter.Value = Int32.Parse(r["GoodStateID"].ToString());

			_oParameter = _oCommand.Parameters.Add("@nCellID", SqlDbType.Int);
			_oParameter.Value = Int32.Parse(r["CellID"].ToString());

			_oParameter = _oCommand.Parameters.Add("@cNote", SqlDbType.VarChar);
			_oParameter.Value = DBNull.Value;

			_oParameter = _oCommand.Parameters.Add("@cBarCode", SqlDbType.VarChar);
			if (r["BarCode"] == null)
				_oParameter.Value = DBNull.Value;
			else
				_oParameter.Value = r["BarCode"].ToString();

			_oParameter = _oCommand.Parameters.Add("@nError", SqlDbType.Int);
			_oParameter.Direction = ParameterDirection.InputOutput;
			_oParameter.Value = 0;

			_oParameter = _oCommand.Parameters.Add("@cErrorText", SqlDbType.VarChar, 200);
			_oParameter.Direction = ParameterDirection.InputOutput;
			_oParameter.Value = "";

			#endregion

			try
			{
				_oCommand.ExecuteScalar();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -10;
				_ErrorStr = "������ ��� ���������� �������...\r\n" + ex.Message;
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
					_ErrorStr = "������ ��� ���������� �������...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
				// ��� �������� ������ ������� - ������� ��� ���
				if (nOutputID == 0 && _oCommand.Parameters["@nOutputID"].Value != DBNull.Value)
				{
					_ID = (int)_oCommand.Parameters["@nOutputID"].Value;
				}
			}
			return (_ErrorNumber == 0);
		}

		#endregion Save


		#region Select ������

		/// <summary>
		/// ������ ����������� � �������/���� ��� �������, �������� �����������
		/// </summary>
		public bool SelectData(int nOutputID, int? nOutputCellID)
		{
			string _sqlCommand = "execute up_OutputsSelect @nOutputID, @nOutputCellID, " +
									"@nError output, @cErrorStr output";
			SqlCommand _oCommand = new SqlCommand(_sqlCommand, _Connect);
			_oCommand.CommandTimeout = 0;

			// �����������, ���� deadlock ��� ������ ������ - ��� ������ �������� "� �������"
			string _sqlUpdate = "update Outputs set IsSelecting = 0 where ID = " + @nOutputID.ToString().Trim();
			SqlCommand _osqlUpdate = new SqlCommand(_sqlUpdate, _Connect);

			int nAttenpts = 10; // ����� ��������� ������� ��� ������ 

			#region up_OutputsSelect parameters

			SqlParameter _oParameter = _oCommand.Parameters.Add("@nOutputID", SqlDbType.Int);
			_oParameter.Value = nOutputID;

			_oParameter = _oCommand.Parameters.Add("@nOutputCellID", SqlDbType.Int);
			if (nOutputCellID.HasValue)
				_oParameter.Value = nOutputCellID;
			else
				_oParameter.Value = DBNull.Value;

			_oParameter = _oCommand.Parameters.Add("@nError", SqlDbType.Int);
			_oParameter.Direction = ParameterDirection.InputOutput;
			_oParameter.Value = 0;

			_oParameter = _oCommand.Parameters.Add("@cErrorStr", SqlDbType.VarChar, 200);
			_oParameter.Direction = ParameterDirection.InputOutput;
			_oParameter.Value = "";

			#endregion

			for (int i = 0; i < nAttenpts; i++)
			{
				try
				{
					_Connect.Open();
					_oCommand.ExecuteScalar();
				}
				catch (Exception ex)
				{
					if (((SqlException)ex).Errors.Count == 1 && ((SqlException)ex).Errors[0].Number == 1205) //  deadlock!
					{
						_ErrorNumber = 1205;
					}
					else
					{
						_ErrorNumber = -11;
						_ErrorStr = "������ ��� ������� ����������� � �������� �������� ����������� ��� �������...\r\n" + ex.Message;
						RFMMessage.MessageBoxError(_ErrorStr);
					}
					// ����� ������� "� �������"
					_osqlUpdate.ExecuteScalar();
				}
				finally
				{
					_Connect.Close();
				}

				if (_ErrorNumber == 1205)
				{
					ClearError();
					continue;
				}
				else
					break;
			}
			if (_ErrorNumber == 0)
			{
				_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
				if (_ErrorNumber != 0)
				{
					_ErrorStr = "������ ��� ������� ������� � �������� �������� ����������� ��� �������...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

	/// <summary>
	/// ������ ������ ��������
	/// </summary>
	/// 
	public int SelectOutCell(int nOutputID)
	{
		string _sqlCommand = "execute up_OutputsSelectCell @nOutputID, @bUnSuccess output, " +
								"@nError output, @cErrorStr output";
		SqlCommand _oCommand = new SqlCommand(_sqlCommand, _Connect);
		_oCommand.CommandTimeout = 0;

		bool bUnSuccess = false;

		#region up_OutputsSelectCell parameters

		SqlParameter _oParameter = _oCommand.Parameters.Add("@nOutputID", SqlDbType.Int);
		_oParameter.Value = nOutputID;

		_oParameter = _oCommand.Parameters.Add("@bUnSuccess", SqlDbType.Bit);
		_oParameter.Direction = ParameterDirection.InputOutput;
		_oParameter.Value = bUnSuccess;

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
			_ErrorNumber = -21;
			_ErrorStr = "������ ��� ������� ������ ��������...\r\n"  + ex.Message;
			RFMMessage.MessageBoxError(_ErrorStr);
		}
		finally
		{
			_Connect.Close();
		}

		if (_ErrorNumber == 0)
		{
			_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
			bUnSuccess = (bool)_oCommand.Parameters["@bUnSuccess"].Value;
			if (_ErrorNumber != 0)
			{
				_ErrorStr = "������ ��� ������� ����� ��������...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
				if (_ErrorNumber != 0)
				{
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
		}

		int nResult;
		if ( _ErrorNumber != 0) nResult = -1;
		else
		{
			if (bUnSuccess) nResult = 1;
			else nResult = 0;
		}
		return (nResult);	
	}

		/// <summary>
		/// ������ ������ ����������� ��� ����������� ������ �������
		/// </summary>
		public bool FramesSelectManual(int nOutputGoodID, string sFramesList)
		{
			string _sqlCommand = "execute up_OutputsFramesSelectManual @nOutputGoodID, @cFramesList, " +
									"@nError output, @cErrorStr output";
			SqlCommand _oCommand = new SqlCommand(_sqlCommand, _Connect);
			_oCommand.CommandTimeout = 0;

			#region up_OutputsFramesSelectManual parameters

			SqlParameter _oParameter = _oCommand.Parameters.Add("@nOutputGoodID", SqlDbType.Int);
			_oParameter.Value = nOutputGoodID;

			_oParameter = _oCommand.Parameters.Add("@cFramesList", SqlDbType.VarChar);
			_oParameter.Value = sFramesList;

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
				_ErrorNumber = -12;
				_ErrorStr = "������ ��� ������ ������� ����������� � �������� �������� ��������������� ��� �������...\r\n" + ex.Message;
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
					_ErrorStr = "������ ��� ������ ������� ����������� � �������� �������� ��������������� ��� �������...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// ������� ������� ���������� ���������� ��� ������ � ������� (���������� �� ���������� ����������)
		/// </summary>
		public bool OutputGoodTrafficFrameCreate(int nOutputGoodID, int nFrameID)
		{
			string _sqlCommand = "execute up_OutputsGoodsTrafficsFramesCreate @nOutputGoodID, @nFrameID, " +
									"@nError output, @cErrorStr output";
			SqlCommand _oCommand = new SqlCommand(_sqlCommand, _Connect);
			_oCommand.CommandTimeout = 0;

			#region up_OutputsGoodsTrafficsFramesCreate parameters

			SqlParameter _oParameter = _oCommand.Parameters.Add("@nOutputGoodID", SqlDbType.Int);
			_oParameter.Value = nOutputGoodID;

			_oParameter = _oCommand.Parameters.Add("@nFrameID", SqlDbType.Int);
			_oParameter.Value = nFrameID;

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
				_ErrorNumber = -13;
				_ErrorStr = "������ ��� ������� �������� ��������������� ���������� ��� ������ � �������...\r\n" + ex.Message;
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
					_ErrorStr = "������ ��� �������� ��������������� ���������� ��� ������ � �������...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// ������� ������� ���������� ���������� ������ �� ���������� ���������� ��� ������ � �������
		/// </summary>
		public bool OutputGoodTrafficGoodFromFrameCreate(int nOutputGoodID, int nFrameID, int nPackingID, decimal nQnt)
		{
			string _sqlCommand = "execute up_OutputsGoodsTrafficsGoodsFromFrameCreate @nOutputGoodID, @nFrameID, " +
									"@nPackingID, @nQnt, " + 
									"@nError output, @cErrorStr output";
			SqlCommand _oCommand = new SqlCommand(_sqlCommand, _Connect);
			_oCommand.CommandTimeout = 0;

			#region up_OutputsGoodsTrafficsFramesCreate parameters

			SqlParameter _oParameter = _oCommand.Parameters.Add("@nOutputGoodID", SqlDbType.Int);
			_oParameter.Value = nOutputGoodID;

			_oParameter = _oCommand.Parameters.Add("@nFrameID", SqlDbType.Int);
			_oParameter.Value = nFrameID;

			_oParameter = _oCommand.Parameters.Add("@nPackingID", SqlDbType.Int);
			_oParameter.Value = nPackingID;

			_oParameter = _oCommand.Parameters.Add("@nQnt", SqlDbType.Decimal);
			_oParameter.Precision = 12;
			_oParameter.Scale = 3;
			_oParameter.Value = nQnt;
			
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
				_ErrorNumber = -14;
				_ErrorStr = "������ ��� ������� �������� ����������� �������/���� �� ���������� ��� ������ � �������...\r\n" + ex.Message;
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
					_ErrorStr = "������ ��� �������� ����������� �������/���� �� ���������� ��� ������ � �������...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}
		//

		/// <summary>
		/// ������������� �������
		/// </summary>
		public bool ConfirmData(int nOutputID, int nConfirmUserID, DataTable tOutputsGoods)
		{
			string _sqlCommand = "execute up_OutputsConfirm @nOutputID, @nConfirmUserID, " +
									"@nError output, @cErrorStr output ";
			SqlCommand _oCommand = new SqlCommand(_sqlCommand, _Connect);
			_oCommand.CommandTimeout = 0;

			#region up_OutputsConfirm parameters

			SqlParameter _oParameter = _oCommand.Parameters.Add("@nOutputID", SqlDbType.Int);
			_oParameter.Value = nOutputID;

			_oParameter = _oCommand.Parameters.Add("@nConfirmUserID", SqlDbType.Int);
			_oParameter.Value = nConfirmUserID;

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
				RFMUtilities.DataTableToTempTable(tOutputsGoods, "#OutputsGoods", _Connect);
				_oCommand.ExecuteScalar();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -11;
				_ErrorStr = "������ ��� ������� ������������� �������...\r\n" + ex.Message;
				//WMSMessage.MessageBoxError(_ErrorStr);
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
					_ErrorStr = "������ ��� ������������� �������...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
					if (_ErrorNumber > 0)
					{
						RFMMessage.MessageBoxError(_ErrorStr);
					}
				}
			}
			return (_ErrorNumber == 0);
		}

		#endregion Select

		#region Confirm

		/// <summary>
		/// ������������� �������� � �����������
		/// </summary>
		public bool ConfirmTraffics(int nOutputID, bool bFrameMode, bool? bMinusAllowed, int nUserID, DataTable dtGoods)
		{
			string _sqlCommand = "execute up_OutputsTrafficsConfirm @nOutputID, " +
									"@bFrameMode, @bMinusAllowed, " +
									"@nUserID, " +
									"@nError output, @cErrorStr output";
			SqlCommand _oCommand = new SqlCommand(_sqlCommand, _Connect);
			_oCommand.CommandTimeout = 0;

			#region  up_OutputTrafficsConfirm parameters

			SqlParameter _oParameter = _oCommand.Parameters.Add("@nOutputID", SqlDbType.Int);
			_oParameter.Value = nOutputID;

			_oParameter = _oCommand.Parameters.Add("@bFrameMode", SqlDbType.Bit);
			_oParameter.Value = bFrameMode;

			_oParameter = _oCommand.Parameters.Add("@bMinusAllowed", SqlDbType.Bit);
			if (bMinusAllowed.HasValue)
				_oParameter.Value = bMinusAllowed;
			else
				_oParameter.Value = DBNull.Value;

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
				RFMUtilities.DataTableToTempTable(dtGoods, (bFrameMode) ? "#FramesConfirmed" : "#GoodsConfirmed", _Connect);
				_oCommand.ExecuteScalar();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -11;
				_ErrorStr = "������ ��� ������������� " + ((bFrameMode) ? "��������������� �����������" : "����������� �������/����") + "...\r\n" + ex.Message;
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
					_ErrorStr = "������ ��� ������������� " + ((bFrameMode) ? "��������������� �����������" : "����������� �������/����") + "...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		#endregion Confirm

		#region Delete

		/// <summary>
		/// �������� �������
		/// </summary>
		public bool DeleteData(int nOutputID)
		{
			String _sqlCommand = "execute up_OutputsDelete @nOutputID, " +
					"@nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(_sqlCommand, _Connect);

			#region up_OutputsSave parameters

			SqlParameter _oParameter = _oCommand.Parameters.Add("@nOutputID", SqlDbType.Int);
			_oParameter.Value = nOutputID;
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
				_ErrorStr = "������ ��� �������� �������...\r\n" + ex.Message;
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
					_ErrorStr = "������ ��� �������� �������...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		public bool SetCell(int nOutputID, int nCellID)
		{
			string sqlSelect = "execute up_OutputsSetCell @nOutputID, @nCellID, " +
									"@nError output, @cErrorStr output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_OutputsSetCell paramaters

			_oCommand.Parameters.Add("@nOutputID", SqlDbType.Int);
			_oCommand.Parameters["@nOutputID"].Value = nOutputID;

			_oCommand.Parameters.Add("@nCellID", SqlDbType.Int);
			_oCommand.Parameters["@nCellID"].Value = nCellID;

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
				_ErrorNumber = -11;
				_ErrorStr = "������ ��� ��������� ������ �������� ��� ������� � ����� " + nCellID.ToString() + "...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr); // RaiseError
			}
			finally
			{
				_Connect.Close();
			}
			_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
			if (_ErrorNumber != 0)
			{
				_ErrorStr = "������ ��� ��������� ������ �������� ��� � ����� " + nCellID.ToString() + "...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		#endregion Delete

		#region SetDateTime

		/// <summary>
		/// �������� ����� ������ ��������� �������
		/// </summary>
		public bool SetDateStart(int nOutputID)
		{
			string sqlCommand = "update Outputs " +
				"set DateStart = GetDate() " +
				"where ID = " + nOutputID.ToString() + " and DateStart is Null";
			SqlCommand _oCommand = new SqlCommand(sqlCommand, _Connect);
			try
			{
				_Connect.Open();
				_oCommand.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -23;
				_ErrorStr = "������ ��� ������� ������� ������ ��������� �������...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// �������� ����� ������ ��������� ������� - ����������
		/// </summary>
		public bool SetDateStart(int nOutputID, DateTime dDateStart)
		{
			string sqlCommand = "set dateformat dmy " +
				"update Outputs " +
					"set DateStart = '" + dDateStart.ToString("dd.MM.yyyy HH:mm") + "' " +
					"where ID = " + nOutputID.ToString() + " and DateStart is Null";
			SqlCommand _oCommand = new SqlCommand(sqlCommand, _Connect);
			try
			{
				_Connect.Open();
				_oCommand.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -23;
				_ErrorStr = "������ ��� ������� ������� ������ ��������� �������...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// �������� ����� ������ ��������� �������
		/// </summary>
		public bool ClearDateStart(int nOutputID)
		{
			string sqlCommand = "update Outputs " +
				"set DateStart = Null " +
				"where ID = " + nOutputID.ToString() + " ";
			SqlCommand _oCommand = new SqlCommand(sqlCommand, _Connect);
			try
			{
				_Connect.Open();
				_oCommand.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -24;
				_ErrorStr = "������ ��� ������� ������� ������ ��������� �������...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// �������� ����� ������ ���������� �� �������
		/// </summary>
		public bool SetDatePrint(int nOutputID)
		{
			string sqlCommand = "update Outputs " +
				"set DatePrint = GetDate() " +
				"where ID = " + nOutputID.ToString() + " and DatePrint is Null";
			SqlCommand _oCommand = new SqlCommand(sqlCommand, _Connect);
			try
			{
				_Connect.Open();
				_oCommand.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -24;
				_ErrorStr = "������ ��� ������� ������� ������ ��������� �� �������...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// ���������� ����� �����/������� ������ ��� �������
		/// </summary>
		public bool SetDatePick(int nOutputID)
		{
			string _sqlCommand = "execute up_OutputsSetDatePick @nOutputID, @nError output, @cErrorStr output";
			SqlCommand _oCommand = new SqlCommand(_sqlCommand, _Connect);
			_oCommand.CommandTimeout = 0;

			#region up_OutputsSetDatePick parameters

			SqlParameter _oParameter = _oCommand.Parameters.Add("@nOutputID", SqlDbType.Int);
			_oParameter.Value = nOutputID;

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
				_ErrorNumber = -41;
				_ErrorStr = "������ ��� ��������� ���� �����/������� ������...\r\n" + ex.Message;
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
					_ErrorStr = "���� �����/������� ������ �� �����������...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
					RFMMessage.MessageBoxInfo(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// ���������� ����� �����/������� ������ ��� �������
		/// </summary>
		public bool ClearIsSelecting(int nOutputID)
		{
			string _sqlUpdate = "update Outputs set IsSelecting = 0 where ID = " + @nOutputID.ToString().Trim();
			SqlCommand _osqlUpdate = new SqlCommand(_sqlUpdate, _Connect);

			try
			{
				_Connect.Open();
				_osqlUpdate.ExecuteScalar();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -42;
				_ErrorStr = "������ ��� ������ �������� \"� �������\"...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			return (_ErrorNumber == 0);
		}

		#endregion SetDateTime

		#region Loaders

		public bool LoadersSave(int nOutputID, DataTable tOutputsLoaders)
		{
			string sqlSelect = "execute up_OutputsLoadersSave @nOutputID, " +
									"@nError output, @cErrorStr output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_OutputsLoadersSave paramaters

			_oCommand.Parameters.Add("@nOutputID", SqlDbType.Int);
			_oCommand.Parameters["@nOutputID"].Value = nOutputID;

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
				RFMUtilities.DataTableToTempTable(tOutputsLoaders, "#OutputsLoaders", _Connect);
				_oCommand.ExecuteScalar();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -21;
				_ErrorStr = "������ ��� ���������� ������ � �����������, ����������� �������� ������ ��� ������� � ����� " + nOutputID.ToString() + "...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr); // RaiseError
			}
			finally
			{
				_Connect.Close();
			}
			_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
			if (_ErrorNumber != 0)
			{
				_ErrorStr = "������ ��� ���������� ������ � �����������, ����������� �������� ������ ��� ������� � ����� " + nOutputID.ToString() + "...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		public bool CoefficientLoadSave(int nOutputID, decimal nCoefficientLoad)
		{
			string sqlSelect = "update Outputs " +
				"set CoefficientLoad = " + nCoefficientLoad.ToString("#####0.0") + " " + 
				"where ID = " + nOutputID.ToString();
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			try
			{
				_Connect.Open();
				_oCommand.ExecuteScalar();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -22;
				_ErrorStr = "������ ��� ���������� ������������ ��������� �������� ��� ������� � ����� " + nOutputID.ToString() + "...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr); 
			}
			finally
			{
				_Connect.Close();
			}
			return (_ErrorNumber == 0);
		}

		public bool PalletsFactQntSave(int nOutputID, int nPalletsFactQnt)
		{
			string sqlSelect = "update Outputs " +
				"set PalletsFactQnt = " + nPalletsFactQnt.ToString("#####0") + " " +
				"where ID = " + nOutputID.ToString();
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			try
			{
				_Connect.Open();
				_oCommand.ExecuteScalar();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -23;
				_ErrorStr = "������ ��� ���������� ����� ����������� �������� ��� ������� � ����� " + nOutputID.ToString() + "...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			return (_ErrorNumber == 0);
		}

		public bool ValidateUserSave(int nOutputID, int? nValidateUserID)
		{
			string sqlSelect = "update Outputs " +
				"set ValidateUserID = " + ((nValidateUserID.HasValue) ? ((int)nValidateUserID).ToString("#####0") : "Null") + " " +
				"where ID = " + nOutputID.ToString();
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			try
			{
				_Connect.Open();
				_oCommand.ExecuteScalar();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -24;
				_ErrorStr = "������ ��� ���������� ������ � ����������� ���������� ��� ������� � ����� " + nOutputID.ToString() + "...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			return (_ErrorNumber == 0);
		}

		#endregion Loaders

	}
}
