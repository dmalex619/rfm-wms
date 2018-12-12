using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

using RFMPublic;

/// <summary>
/// ������-������ ������ (Cell)
/// </summary>
namespace WMSBizObjects
{
	public class Cell : BizObject
	{
		protected string _IDList;
		/// <summary>
		/// ������ ID ����� (Cells.ID)
		/// </summary>
		[Description("������ ID ����� (Cells.ID)")]
		public string IDList { get { return _IDList; } set { _IDList = value; _NeedRequery = true; } }

		protected string _BarCode;
		/// <summary>
		/// �����-��� ������ (Cells.BarCode), ��������
		/// </summary>
		[Description("�����-��� ������ (Cells.BarCode), ��������")]
		public string BarCode { get { return _BarCode; } set { _BarCode = value; _NeedRequery = true; } }

		// �������

		protected bool? _FilterActual;
		/// <summary>
		/// ������-����: ���������� ������ (Cells.Actual)?
		/// </summary>
		[Description("������-����: ���������� ������ (Cells.Actual)")]
		public bool? FilterActual { get { return _FilterActual; } set { _FilterActual = value; _NeedRequery = true; } }

		protected bool? _FilterLocked;
		/// <summary>
		/// ������-����: ������������� ������ (Cells.Locked))?
		/// </summary>
		[Description("������-����: ������������� ������ (Cells.Locked)")]
		public bool? FilterLocked { get { return _FilterLocked; } set { _FilterLocked = value; _NeedRequery = true; } }

		protected bool? _FilterHasCellContent;
		/// <summary>
		/// ������-����: ���� ���������� ������ (Cells -> CellsContents)?
		/// </summary>
		[Description("������-����: ���� ���������� ������ (Cells -> CellsContents)")]
		public bool? FilterHasCellContent { get { return _FilterHasCellContent; } set { _FilterHasCellContent = value; _NeedRequery = true; } }

		protected bool? _FilterIsFull;
		/// <summary>
		/// ������-����: ������ ��������� ��������� (Cells, StoresZones -> MaxPalletQnt)?
		/// </summary>
		[Description("������-����: ������ ��������� ��������� (Cells, StoresZones -> MaxPalletQnt)?")]
		public bool? FilterIsFull { get { return _FilterIsFull; } set { _FilterIsFull = value; _NeedRequery = true; } }

		protected bool? _FilterTrafficsToExists;
		/// <summary>
		/// ������-����: ���� ��������������� � ������ (Cells, TrafficsFrames.CellTargetID)?
		/// </summary>
		[Description("������-����: ���� ��������������� � ������ (Cells, TrafficsFrames.CellTargetID)?")]
		public bool? FilterTrafficsToExists { get { return _FilterTrafficsToExists; } set { _FilterTrafficsToExists = value; _NeedRequery = true; } }

		protected bool? _FilterTrafficsFromExists;
		/// <summary>
		/// ������-����: ���� ��������������� �� ������ (Cells, TrafficsFrames.CellSourceID)?
		/// </summary>
		[Description("������-����: ���� ��������������� �� ������ (Cells, TrafficsFrames.CellSourceID)?")]
		public bool? FilterTrafficsFromExists { get { return _FilterTrafficsFromExists; } set { _FilterTrafficsFromExists = value; _NeedRequery = true; } }

		protected string _FilterFixedOwnersList;
		/// <summary>
		/// ������-����: ������ ID ������������� ���������� (Cells.FixedOwnerID), ����� �������
		/// </summary>
		[Description("������-����: ������ ID ������������� ���������� (Cells.FixedOwnerID), ����� �������")]
		public string FilterFixedOwnersList { get { return _FilterFixedOwnersList; } set { _FilterFixedOwnersList = value; _NeedRequery = true; } }

		protected string _FilterFixedGoodsStatesList;
		/// <summary>
		/// ������-����: ������ ID ������������� ��������� ������� (Cells.FixedGoodStateID), ����� �������
		/// </summary>
		[Description("������-����: ������ ID ������������� ��������� ������� (Cells.FixedGoodStateID), ����� �������")]
		public string FilterFixedGoodsStatesList { get { return _FilterFixedGoodsStatesList; } set { _FilterFixedGoodsStatesList = value; _NeedRequery = true; } }

		protected string _FilterFixedPackingsList;
		/// <summary>
		/// ������-����: ������ ID ������������� �������� (Cells.PackingID), ����� �������
		/// </summary>
		[Description("������-����: ������ ID ������������� �������� (Cells.PackingID), ����� �������")]
		public string FilterFixedPackingsList { get { return _FilterFixedPackingsList; } set { _FilterFixedPackingsList = value; _NeedRequery = true; } }

		protected string _FilterFixedGoodsList;
		/// <summary>
		/// ������-����: ������ ID ������������� ������� (Cells.PackingID -> Packings.GoodID), ����� �������
		/// </summary>
		[Description("������-����: ������ ID ������������� ������� (Cells.PackingID -> Packings.GoodID), ����� �������")]
		public string FilterFixedGoodsList { get { return _FilterFixedGoodsList; } set { _FilterFixedGoodsList = value; _NeedRequery = true; } }

        protected string _FilterNoteContext;
        /// <summary>
        /// ������-����: �������� ���������� � �������
        /// </summary>
        [Description("������-����: �������� ���������� � �������")]
        public string FilterNoteContext { get { return _FilterNoteContext; } set { _FilterNoteContext = value; _NeedRequery = true; } }

        protected string _FilterPalletsTypesList;
		/// <summary>
		/// ������-����: ������ ID ����� ������ (Cells.PalletTypeID), ����� �������
		/// </summary>
		[Description("������-����: ������ ID ����� ������ (Cells.PalletTypeID), ����� �������")]
		public string FilterPalletsTypesList { get { return _FilterPalletsTypesList; } set { _FilterPalletsTypesList = value; _NeedRequery = true; } }

		protected string _FilterCBuilding;
		/// <summary>
		/// ������-����: �����: ������
		/// </summary>
		[Description("������-����: �����: ������")]
		public string FilterCBuilding { get { return _FilterCBuilding; } set { _FilterCBuilding = value; _NeedRequery = true; } }

		protected string _FilterCLine;
		/// <summary>
		/// ������-����: �����: �����
		/// </summary>
		[Description("������-����: �����: �����")]
		public string FilterCLine { get { return _FilterCLine; } set { _FilterCLine = value; _NeedRequery = true; } }

		protected string _FilterCRack;
		/// <summary>
		/// ������-����: �����: �����
		/// </summary>
		[Description("������-����: �����: �����")]
		public string FilterCRack { get { return _FilterCRack; } set { _FilterCRack = value; _NeedRequery = true; } }

		protected string _FilterCLevel;
		/// <summary>
		/// ������-����: �����: �������
		/// </summary>
		[Description("������-����: �����: �������")]
		public string FilterCLevel { get { return _FilterCLevel; } set { _FilterCLevel = value; _NeedRequery = true; } }

		protected string _FilterCPlace;
		/// <summary>
		/// ������-����: �����: ������
		/// </summary>
		[Description("������-����: �����: ������")]
		public string FilterCPlace { get { return _FilterCPlace; } set { _FilterCPlace = value; _NeedRequery = true; } }

		protected string _FilterAddress;
		/// <summary>
		/// ������-����: ����� ���������
		/// </summary>
		[Description("������-����: ����� ���������")]
		public string FilterAddress { get { return _FilterAddress; } set { _FilterAddress = value; _NeedRequery = true; } }

		protected string _FilterAddressContext;
		/// <summary>
		/// ������-����: ����� ��������
		/// </summary>
		[Description("������-����: ����� ��������")]
		public string FilterAddressContext { get { return _FilterAddressContext; } set { _FilterAddressContext = value; _NeedRequery = true; } }

		protected string _FilterStoresZonesList;
		/// <summary>
		/// ������-����: ������ ID ��������� ��� (Cells.StoreZoneID), ����� �������
		/// </summary>
		[Description("������-����: ������ ID ��������� ��� (Cells.StoreZoneID), ����� �������")]
		public string FilterStoresZonesList { get { return _FilterStoresZonesList; } set { _FilterStoresZonesList = value; _NeedRequery = true; } }

		protected string _FilterStoresZonesTypesList;
		/// <summary>
		/// ������-����: ������ ID ����� ��������� ��� (Cells.StoreZoneID -> StoresZones.StoreZoneTypeID), ����� �������
		/// </summary>
		[Description("������-����: ������ ID ����� ��������� ��� (Cells.StoreZoneID -> StoresZones.StoreZoneTypeID), ����� �������")]
		public string FilterStoresZonesTypesList { get { return _FilterStoresZonesTypesList; } set { _FilterStoresZonesTypesList = value; _NeedRequery = true; } }

		protected string _FilterStoreZoneTypeShortCode;
		/// <summary>
		/// ������-����: ���������� ��� ��������� ���� (Cells.StoreZoneID -> StoresZones.StoreZoneTypeID -> StoresZonesTypes.ShortCode) 
		/// </summary>
		[Description("������-����: ���������� ��� ��������� ���� (Cells.StoreZoneID -> StoresZones.StoreZoneTypeID -> StoresZonesTypes.ShortCode) ")]
		public string FilterStoreZoneTypeShortCode { get { return _FilterStoreZoneTypeShortCode; } set { _FilterStoreZoneTypeShortCode = value; _NeedRequery = true; } }

		protected bool? _FilterStoreZoneTypeForInputs;
		/// <summary>
		/// ������-����: ������� ���� ��������� ���� "��� ��������" (Cells.StoreZoneID -> StoresZones.StoreZoneTypeID -> StoresZonesTypes.ForInputs) 
		/// </summary>
		[Description("������-����: ������� ���� ��������� ���� '��� ��������' (Cells.StoreZoneID -> StoresZones.StoreZoneTypeID -> StoresZonesTypes.ForInputs) ")]
		public bool? FilterStoreZoneTypeForInputs { get { return _FilterStoreZoneTypeForInputs; } set { _FilterStoreZoneTypeForInputs = value; _NeedRequery = true; } }

		protected bool? _FilterStoreZoneTypeForOutputs;
		/// <summary>
		/// ������-����: ������� ���� ��������� ���� "��� ��������" (Cells.StoreZoneID -> StoresZones.StoreZoneTypeID -> StoresZonesTypes.ForOutputs) 
		/// </summary>
		[Description("������-����: ������� ���� ��������� ���� '��� ��������' (Cells.StoreZoneID -> StoresZones.StoreZoneTypeID -> StoresZonesTypes.ForOutputs) ")]
		public bool? FilterStoreZoneTypeForOutputs { get { return _FilterStoreZoneTypeForOutputs; } set { _FilterStoreZoneTypeForOutputs = value; _NeedRequery = true; } }

		protected bool? _FilterStoreZoneTypeForStorage;
		/// <summary>
		/// ������-����: ������� ���� ��������� ���� "��� ��������" (Cells.StoreZoneID -> StoresZones.StoreZoneTypeID -> StoresZonesTypes.ForStorage) 
		/// </summary>
		[Description("������-����: ������� ���� ��������� ���� '��� ��������' (Cells.StoreZoneID -> StoresZones.StoreZoneTypeID -> StoresZonesTypes.ForStorage) ")]
		public bool? FilterStoreZoneTypeForStorage { get { return _FilterStoreZoneTypeForStorage; } set { _FilterStoreZoneTypeForStorage = value; _NeedRequery = true; } }

		protected bool? _FilterStoreZoneTypeForPicking;
		/// <summary>
		/// ������-����: ������� ���� ��������� ���� "��� �������" (Cells.StoreZoneID -> StoresZones.StoreZoneTypeID -> StoresZonesTypes.ForPicking) 
		/// </summary>
		[Description("������-����: ������� ���� ��������� ���� '��� �������' (Cells.StoreZoneID -> StoresZones.StoreZoneTypeID -> StoresZonesTypes.ForPicking) ")]
		public bool? FilterStoreZoneTypeForPicking { get { return _FilterStoreZoneTypeForPicking; } set { _FilterStoreZoneTypeForPicking = value; _NeedRequery = true; } }

		protected bool? _FilterForFrames;
		/// <summary>
		/// ������-����: ������� "��� �����������" [�.�.Null] (Cells.StoreZoneID -> StoresZones.StoreZoneTypeID -> StoresZonesTypes.ForFrames) 
		/// </summary>
		[Description("������-����: ������� '��� �����������' [�.�.Null] (Cells.StoreZoneID -> StoresZones.StoreZoneTypeID -> StoresZonesTypes.ForFrames) ")]
		public bool? FilterForFrames { get { return _FilterForFrames; } set { _FilterForFrames = value; _NeedRequery = true; } }

		protected string _FilterCellsStatesStr;
		/// <summary>
		/// ������-����: ������ ���������� �������� ����� (Cells.State), ��� �����������
		/// </summary>
		[Description("������-����: ������ ���������� �������� ����� (Cells.State), ��� �����������")]
		public string FilterCellsStatesStr { get { return _FilterCellsStatesStr; } set { _FilterCellsStatesStr = value; _NeedRequery = true; } }

		protected Decimal? _FilterMaxWeightBeg;
		/// <summary>
		/// ������-����: max ���������� ��� � ������ (��) (Cells.MaxWeight), ��
		/// </summary>
		[Description("������-����: max ���������� ��� � ������ (��) (Cells.MaxWeight), ��")]
		public Decimal? FilterMaxWeightBeg { get { return _FilterMaxWeightBeg; } set { _FilterMaxWeightBeg = value; _NeedRequery = true; } }

		protected Decimal? _FilterMaxWeightEnd;
		/// <summary>
		/// ������-����: max ���������� ��� � ������ (��) (Cells.MaxWeight), ��
		/// </summary>
		[Description("������-����: max ���������� ��� � ������ (��) (Cells.MaxWeight), ��")]
		public Decimal? FilterMaxWeightEnd { get { return _FilterMaxWeightEnd; } set { _FilterMaxWeightEnd = value; _NeedRequery = true; } }

		protected Decimal? _FilterCellHeightBeg;
		/// <summary>
		/// ������-����: ������ ������ (�) (Cells.CellHeight), ��
		/// </summary>
		[Description("������-����: ������ ������ (�) (Cells.CellHeight), ��")]
		public Decimal? FilterCellHeightBeg { get { return _FilterCellHeightBeg; } set { _FilterCellHeightBeg = value; _NeedRequery = true; } }

		protected Decimal? _FilterCellHeightEnd;
		/// <summary>
		/// ������-����: ������ ������ (�) (Cells.CellHeight), ��
		/// </summary>
		[Description("������-����: ������ ������ (�) (Cells.CellHeight), ��")]
		public Decimal? FilterCellHeightEnd { get { return _FilterCellHeightEnd; } set { _FilterCellHeightEnd = value; _NeedRequery = true; } }

		protected Decimal? _FilterCellWidthBeg;
		/// <summary>
		/// ������-����: ������ ������ (�) (Cells.CellWidth), ��
		/// </summary>
		[Description("������-����: ������ ������ (�) (Cells.CellWidth), ��")]
		public Decimal? FilterCellWidthBeg { get { return _FilterCellWidthBeg; } set { _FilterCellWidthBeg = value; _NeedRequery = true; } }

		protected Decimal? _FilterCellWidthEnd;
		/// <summary>
		/// ������-����: ������ ������ (�) (Cells.CellWidth), ��
		/// </summary>
		[Description("������-����: ������ ������ (�) (Cells.CellWidth), ��")]
		public Decimal? FilterCellWidthEnd { get { return _FilterCellWidthEnd; } set { _FilterCellWidthEnd = value; _NeedRequery = true; } }

		// ��� ����������� ----------------------------------------------------------

		protected DataTable _TableCellsContents;
		/// <summary>
		/// ������� ����������� ����� (CellsContents)
		/// </summary>
		[Description("������� ����������� ����� (CellsContents)")]
		public DataTable TableCellsContents { get { return _TableCellsContents; } }

		/// ��� ������� ����������� �����: ���������� ���������� �������?
		protected bool? _CellsContents_NeedRequery;

		protected int? _CellContentID;
		/// <summary>
		/// ������-���� ������� ����������� �����: ID ������ ���������� ������ (CellsContents.ID)
		/// </summary>
		[Description("������-���� ������� ����������� �����: ID ������ ���������� ������ (CellsContents.ID)")]
		public int? CellContentID { get { return _CellContentID; } set { _CellContentID = value; _CellsContents_NeedRequery = true; } }

		protected string _CellsContents_FilterOwnersList;
		/// <summary>
		/// ������-���� ������� ����������� �����: ������ ID ������������ ���������� (CellsContents.OwnerID), ����� �������
		/// </summary>
		[Description("������-���� ������� ����������� �����: ������ ID ������������ ���������� (CellsContents.OwnerID), ����� �������")]
		public string CellsContents_FilterOwnersList { get { return _CellsContents_FilterOwnersList; } set { _CellsContents_FilterOwnersList = value; _CellsContents_NeedRequery = true; } }

		protected string _CellsContents_FilterGoodsStatesList;
		/// <summary>
		/// ������-���� ������� ����������� �����: ������ ID ������������ ��������� ������� (CellsContents.GoodStateID), ����� �������
		/// </summary>
		[Description("������-���� ������� ����������� �����: ������ ID ������������ ��������� ������� (CellsContents.GoodStateID), ����� �������")]
		public string CellsContents_FilterGoodsStatesList { get { return _CellsContents_FilterGoodsStatesList; } set { _CellsContents_FilterGoodsStatesList = value; _CellsContents_NeedRequery = true; } }

		protected string _CellsContents_FilterPackingsList;
		/// <summary>
		/// ������-���� ������� ����������� �����: ������ ID ������������ �������� (CellsContents.PackingID), ����� �������
		/// </summary>
		[Description("������-���� ������� ����������� �����: ������ ID ������������ �������� (CellsContents.PackingID), ����� �������")]
		public string CellsContents_FilterPackingsList { get { return _CellsContents_FilterPackingsList; } set { _CellsContents_FilterPackingsList = value; _CellsContents_NeedRequery = true; } }

		protected string _CellsContents_FilterGoodsList;
		/// <summary>
		/// ������-���� ������� ����������� �����: ������ ID ������������ ������� (CellsContents.PackingID -> Packings.GoodID), ����� �������
		/// </summary>
		[Description("������-���� ������� ����������� �����: ������ ID ������������ ������� (CellsContents.PackingID - >Packings.GoodID), ����� �������")]
		public string CellsContents_FilterGoodsList { get { return _CellsContents_FilterGoodsList; } set { _CellsContents_FilterGoodsList = value; _CellsContents_NeedRequery = true; } }

		protected string _CellsContents_FilterFramesList;
		/// <summary>
		/// ������-���� ������� ����������� �����: ������ ID ����������� (CellsContents.FrameID), ����� �������
		/// </summary>
		[Description("������-���� ������� ����������� �����: ������ ID ����� ������ (Cells.PalletTypeID), ����� �������")]
		public string CellsContents_FilterFramesList { get { return _CellsContents_FilterFramesList; } set { _CellsContents_FilterFramesList = value; _CellsContents_NeedRequery = true; } }

		protected int? _CellsContents_FilterCheckDateValid;
		/// <summary>
		/// ������-���� ������� ����������� �����: �� ����� �������� (CellsContents.DateValid): % �������� �����, -1 ���������, -2 �������
		/// </summary>
		[Description("������-���� ������� ����������� �����: �� ����� �������� (CellsContents.DateValid): % �������� �����, -1 ���������, -2 �������")]
		public int? CellsContents_FilterCheckDateValid { get { return _CellsContents_FilterCheckDateValid; } set { _CellsContents_FilterCheckDateValid = value; _CellsContents_NeedRequery = true; } }

		// ��� ������� --------------------------------------------------------

		protected DataTable _TableCellsHistory;
		/// <summary>
		/// ������� ������� ����� (CellsHistory)
		/// </summary>
		[Description("������� ������� ����� (CellsHistory)")]
		public DataTable TableCellsHistory { get { return _TableCellsHistory; } }

		/// ��� ������� ������� �����: ���������� ���������� �������?
		protected bool? _CellsHistory_NeedRequery;

		protected DateTime? _CellsHistory_FilterDataBeg;
		/// <summary>
		/// ������-����: ��������� ���� �������
		/// </summary>
		[Description("������-����: ��������� ���� �������")]
		public DateTime? CellsHistory_FilterDateBeg { get { return _CellsHistory_FilterDataBeg; } set { _CellsHistory_FilterDataBeg = value; _CellsHistory_NeedRequery = true; } }

		protected DateTime? _CellsHistory_FilterDataEnd;
		/// <summary>
		/// ������-����: �������� ���� ������� 
		/// </summary>
		[Description("������-����: �������� ���� �������")]
		public DateTime? CellsHistory_FilterDateEnd { get { return _CellsHistory_FilterDataEnd; } set { _CellsHistory_FilterDataEnd = value; _CellsHistory_NeedRequery = true; } }

		/// <summary>
		/// ������-����: ������ ����������� ������ (CellsChanges))?
		/// </summary>
		protected bool? _CellsHistory_FilterCellsChanges;
		[Description("������-����: ����������� ������ (CellsChanges)?")]
		public bool? CellsHistory_FilterCellsChanges { get { return _CellsHistory_FilterCellsChanges; } set { _CellsHistory_FilterCellsChanges = value; _CellsHistory_NeedRequery = true; } }

		// ��� ������� - ������� -----------------------------------------------------

		protected DataTable _TableAddressPartCBuilding;
		/// <summary>
		/// ������� ������ (������ �����) (_TableAddressPartCBuilding)
		/// </summary>
		[Description("������� ������ (������ �����) (_TableAddressPartCBuilding)")]
		public DataTable TableAddressPartCBuilding { get { return _TableAddressPartCBuilding; } }

		protected DataTable _TableAddressPartCLine;
		/// <summary>
		/// ������� ����� (������ �����) (_TableAddressPartCBuilding)
		/// </summary>
		[Description("������� ����� (������ �����) (_TableAddressPartCBuilding)")]
		public DataTable TableAddressPartCLine { get { return _TableAddressPartCLine; } }

		protected DataTable _TableAddressPartCRack;
		/// <summary>
		/// ������� ������ (������ �����) (_TableAddressPartCBuilding)
		/// </summary>
		[Description("������� ������ (������ �����) (_TableAddressPartCBuilding)")]
		public DataTable TableAddressPartCRack { get { return _TableAddressPartCRack; } }

		protected DataTable _TableAddressPartCLevel;
		/// <summary>
		/// ������� ������ (������ �����) (_TableAddressPartCBuilding)
		/// </summary>
		[Description("������� ������ (������ �����) (_TableAddressPartCBuilding)")]
		public DataTable TableAddressPartCLevel { get { return _TableAddressPartCLevel; } }

		protected DataTable _TableAddressPartCPlace;
		/// <summary>
		/// ������� ������������ (������ �����) (_TableAddressPartCBuilding)
		/// </summary>
		[Description("������� ������������ (������ �����) (_TableAddressPartCBuilding)")]
		public DataTable TableAddressPartCPlace { get { return _TableAddressPartCPlace; } }

		protected DataTable _TableAddressPartCBuildingCLine;
		/// <summary>
		/// ������� ������ + ����� (������ �����) (_TableAddressPartCBuildingCLine)
		/// </summary>
		[Description("������� ������ + ����� (������ �����) (_TableAddressPartCBuildingCLine)")]
		public DataTable TableAddressPartCBuildingCLine { get { return _TableAddressPartCBuildingCLine; } }

		// ��� ������� ----------------------------------------------------------

		protected DataTable _TableReport;
		/// <summary>
		/// ������� ��� ������� �� �������
		/// </summary>
		[Description("������� ��� ������� �� �������")]
		public DataTable TableReport { get { return _TableReport; } }

		// -------------------

		public Cell()
			: base()
		{
			_MainTableName = "Cells";
			_ColumnID = "ID";
			_ColumnName = "BarCode";
		}


		//��������� ������� ������ ����� 
		public override bool FillData()
		{
			ClearData();

			string sqlSelect = "execute up_CellsFill @nID, @cIDList, " +
				"@cBarCode, @bActual, @bLocked, @bHasCellContent, @bIsFull, " +
				"@bTrafficsToExists, @bTrafficsFromExists, " +
                "@cFixedOwnersList, @cFixedGoodsStatesList, @cCellsStatesStr, @cCellNoteContext, " +
				"@cCBuilding, @cCLine, @cCRack, @cCLevel, @cCPlace, @cAddress, @cAddressContext, " +
				"@cStoresZonesList, @cStoresZonesTypesList, @cStoreZoneTypeShortCode, " +
				"@bForInputs, @bForOutputs, @bForStorage, @bForPicking, @bForFrames, " +
				"@cFixedPackingsList, @cFixedGoodsList, @cPalletsTypesList, " +
				"@nMaxWeightBeg, @nMaxWeightEnd, " +
				"@nCellHeightBeg, @nCellHeightEnd, " +
				"@nCellWidthBeg, @nCellWidthEnd, " +
				"@cCellsContentsOwnersList, @cCellsContentsGoodsStatesList, " +
				"@cCellsContentsPackingsList, @cCellsContentsGoodsList, " +
				"@cCellsContentsFramesList, " +
				"@nCheckDateValid";

			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);
			_oCommand.CommandTimeout = 0;

			#region up_CellsFill parameters

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

			_oCommand.Parameters.Add("@cBarCode", SqlDbType.VarChar);
			if (_BarCode != null)
				_oCommand.Parameters["@cBarCode"].Value = _BarCode;
			else
				_oCommand.Parameters["@cBarCode"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bActual", SqlDbType.Bit);
			if (_FilterActual.HasValue)
				_oCommand.Parameters["@bActual"].Value = _FilterActual;
			else
				_oCommand.Parameters["@bActual"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bLocked", SqlDbType.Bit);
			if (_FilterLocked.HasValue)
				_oCommand.Parameters["@bLocked"].Value = _FilterLocked;
			else
				_oCommand.Parameters["@bLocked"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bHasCellContent", SqlDbType.Bit);
			if (_FilterHasCellContent.HasValue)
				_oCommand.Parameters["@bHasCellContent"].Value = _FilterHasCellContent;
			else
				_oCommand.Parameters["@bHasCellContent"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bIsFull", SqlDbType.Bit);
			if (_FilterIsFull.HasValue)
				_oCommand.Parameters["@bIsFull"].Value = _FilterIsFull;
			else
				_oCommand.Parameters["@bIsFull"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bTrafficsToExists", SqlDbType.Bit);
			if (_FilterTrafficsToExists.HasValue)
				_oCommand.Parameters["@bTrafficsToExists"].Value = _FilterTrafficsToExists;
			else
				_oCommand.Parameters["@bTrafficsToExists"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bTrafficsFromExists", SqlDbType.Bit);
			if (_FilterTrafficsFromExists.HasValue)
				_oCommand.Parameters["@bTrafficsFromExists"].Value = _FilterTrafficsFromExists;
			else
				_oCommand.Parameters["@bTrafficsFromExists"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cFixedOwnersList", SqlDbType.VarChar);
			if (_FilterFixedOwnersList != null)
				_oCommand.Parameters["@cFixedOwnersList"].Value = _FilterFixedOwnersList;
			else
				_oCommand.Parameters["@cFixedOwnersList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cFixedGoodsStatesList", SqlDbType.VarChar);
			if (_FilterFixedGoodsStatesList != null)
				_oCommand.Parameters["@cFixedGoodsStatesList"].Value = _FilterFixedGoodsStatesList;
			else
				_oCommand.Parameters["@cFixedGoodsStatesList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cCellsStatesStr", SqlDbType.VarChar);
			if (_FilterCellsStatesStr != null)
				_oCommand.Parameters["@cCellsStatesStr"].Value = _FilterCellsStatesStr;
			else
				_oCommand.Parameters["@cCellsStatesStr"].Value = DBNull.Value;
            _oCommand.Parameters.Add("@cCellNoteContext", SqlDbType.VarChar);
            if (_FilterNoteContext != null)
                _oCommand.Parameters["@cCellNoteContext"].Value = _FilterNoteContext;
            else
                _oCommand.Parameters["@cCellNoteContext"].Value = DBNull.Value;


            _oCommand.Parameters.Add("@cCBuilding", SqlDbType.VarChar);
			if (_FilterCBuilding != null)
				_oCommand.Parameters["@cCBuilding"].Value = _FilterCBuilding;
			else
				_oCommand.Parameters["@cCBuilding"].Value = DBNull.Value;
			_oCommand.Parameters.Add("@cCLine", SqlDbType.VarChar);
			if (_FilterCLine != null)
				_oCommand.Parameters["@cCLine"].Value = _FilterCLine;
			else
				_oCommand.Parameters["@cCLine"].Value = DBNull.Value;
			_oCommand.Parameters.Add("@cCRack", SqlDbType.VarChar);
			if (_FilterCRack != null)
				_oCommand.Parameters["@cCRack"].Value = _FilterCRack;
			else
				_oCommand.Parameters["@cCRack"].Value = DBNull.Value;
			_oCommand.Parameters.Add("@cCLevel", SqlDbType.VarChar);
			if (_FilterCLevel != null)
				_oCommand.Parameters["@cCLevel"].Value = _FilterCLevel;
			else
				_oCommand.Parameters["@cCLevel"].Value = DBNull.Value;
			_oCommand.Parameters.Add("@cCPlace", SqlDbType.VarChar);
			if (_FilterCPlace != null)
				_oCommand.Parameters["@cCPlace"].Value = _FilterCPlace;
			else
				_oCommand.Parameters["@cCPlace"].Value = DBNull.Value;
			_oCommand.Parameters.Add("@cAddress", SqlDbType.VarChar);
			if (_FilterAddress != null)
				_oCommand.Parameters["@cAddress"].Value = _FilterAddress;
			else
				_oCommand.Parameters["@cAddress"].Value = DBNull.Value;
			_oCommand.Parameters.Add("@cAddressContext", SqlDbType.VarChar);
			if (_FilterAddressContext != null)
				_oCommand.Parameters["@cAddressContext"].Value = _FilterAddressContext;
			else
				_oCommand.Parameters["@cAddressContext"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cStoresZonesList", SqlDbType.VarChar);
			if (_FilterStoresZonesList != null)
				_oCommand.Parameters["@cStoresZonesList"].Value = _FilterStoresZonesList;
			else
				_oCommand.Parameters["@cStoresZonesList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cStoresZonesTypesList", SqlDbType.VarChar);
			if (_FilterStoresZonesTypesList != null)
				_oCommand.Parameters["@cStoresZonesTypesList"].Value = _FilterStoresZonesTypesList;
			else
				_oCommand.Parameters["@cStoresZonesTypesList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cStoreZoneTypeShortCode", SqlDbType.VarChar);
			if (_FilterStoreZoneTypeShortCode != null)
				_oCommand.Parameters["@cStoreZoneTypeShortCode"].Value = _FilterStoreZoneTypeShortCode;
			else
				_oCommand.Parameters["@cStoreZoneTypeShortCode"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bForInputs", SqlDbType.VarChar);
			if (_FilterStoreZoneTypeForInputs != null)
				_oCommand.Parameters["@bForInputs"].Value = _FilterStoreZoneTypeForInputs;
			else
				_oCommand.Parameters["@bForInputs"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bForOutputs", SqlDbType.VarChar);
			if (_FilterStoreZoneTypeForOutputs != null)
				_oCommand.Parameters["@bForOutputs"].Value = _FilterStoreZoneTypeForOutputs;
			else
				_oCommand.Parameters["@bForOutputs"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bForStorage", SqlDbType.VarChar);
			if (_FilterStoreZoneTypeForStorage != null)
				_oCommand.Parameters["@bForStorage"].Value = _FilterStoreZoneTypeForStorage;
			else
				_oCommand.Parameters["@bForStorage"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bForPicking", SqlDbType.VarChar);
			if (_FilterStoreZoneTypeForPicking != null)
				_oCommand.Parameters["@bForPicking"].Value = _FilterStoreZoneTypeForPicking;
			else
				_oCommand.Parameters["@bForPicking"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bForFrames", SqlDbType.VarChar);
			if (_FilterForFrames != null)
				_oCommand.Parameters["@bForFrames"].Value = _FilterForFrames;
			else
				_oCommand.Parameters["@bForFrames"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cFixedPackingsList", SqlDbType.VarChar);
			if (_FilterFixedPackingsList != null)
				_oCommand.Parameters["@cFixedPackingsList"].Value = _FilterFixedPackingsList;
			else
				_oCommand.Parameters["@cFixedPackingsList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cFixedGoodsList", SqlDbType.VarChar);
			if (_FilterFixedGoodsList != null)
				_oCommand.Parameters["@cFixedGoodsList"].Value = _FilterFixedGoodsList;
			else
				_oCommand.Parameters["@cFixedGoodsList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cPalletsTypesList", SqlDbType.VarChar);
			if (_FilterPalletsTypesList != null)
				_oCommand.Parameters["@cPalletsTypesList"].Value = _FilterPalletsTypesList;
			else
				_oCommand.Parameters["@cPalletsTypesList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@nMaxWeightBeg", SqlDbType.Decimal);
			_oCommand.Parameters["@nMaxWeightBeg"].Precision = 10;
			_oCommand.Parameters["@nMaxWeightBeg"].Scale = 3;
			if (_FilterMaxWeightBeg.HasValue)
				_oCommand.Parameters["@nMaxWeightBeg"].Value = _FilterMaxWeightBeg;
			else
				_oCommand.Parameters["@nMaxWeightBeg"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@nMaxWeightEnd", SqlDbType.Decimal);
			_oCommand.Parameters["@nMaxWeightEnd"].Precision = 10;
			_oCommand.Parameters["@nMaxWeightEnd"].Scale = 3;
			if (_FilterMaxWeightEnd.HasValue)
				_oCommand.Parameters["@nMaxWeightEnd"].Value = _FilterMaxWeightEnd;
			else
				_oCommand.Parameters["@nMaxWeightEnd"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@nCellHeightBeg", SqlDbType.Decimal);
			_oCommand.Parameters["@nCellHeightBeg"].Precision = 10;
			_oCommand.Parameters["@nCellHeightBeg"].Scale = 3;
			if (_FilterCellHeightBeg.HasValue)
				_oCommand.Parameters["@nCellHeightBeg"].Value = _FilterCellHeightBeg;
			else
				_oCommand.Parameters["@nCellHeightBeg"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@nCellHeightEnd", SqlDbType.Decimal);
			_oCommand.Parameters["@nCellHeightEnd"].Precision = 10;
			_oCommand.Parameters["@nCellHeightEnd"].Scale = 3;
			if (_FilterCellHeightEnd.HasValue)
				_oCommand.Parameters["@nCellHeightEnd"].Value = _FilterCellHeightEnd;
			else
				_oCommand.Parameters["@nCellHeightEnd"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@nCellWidthBeg", SqlDbType.Decimal);
			_oCommand.Parameters["@nCellWidthBeg"].Precision = 10;
			_oCommand.Parameters["@nCellWidthBeg"].Scale = 3;
			if (_FilterCellWidthBeg.HasValue)
				_oCommand.Parameters["@nCellWidthBeg"].Value = _FilterCellWidthBeg;
			else
				_oCommand.Parameters["@nCellWidthBeg"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@nCellWidthEnd", SqlDbType.Decimal);
			_oCommand.Parameters["@nCellWidthEnd"].Precision = 10;
			_oCommand.Parameters["@nCellWidthEnd"].Scale = 3;
			if (_FilterCellWidthEnd.HasValue)
				_oCommand.Parameters["@nCellWidthEnd"].Value = _FilterCellWidthEnd;
			else
				_oCommand.Parameters["@nCellWidthEnd"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cFramesList", SqlDbType.VarChar);
			if (_CellsContents_FilterFramesList != null)
				_oCommand.Parameters["@cFramesList"].Value = _CellsContents_FilterFramesList;
			else
				_oCommand.Parameters["@cFramesList"].Value = DBNull.Value;

			#region up_CellsFill CellsContents-parameters

			//���� ��� ������ ����� ���������� ����� (CellsContents)

			_oCommand.Parameters.Add("@cCellsContentsOwnersList", SqlDbType.VarChar);
			if (_CellsContents_FilterOwnersList != null)
				_oCommand.Parameters["@cCellsContentsOwnersList"].Value = _CellsContents_FilterOwnersList;
			else
				_oCommand.Parameters["@cCellsContentsOwnersList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cCellsContentsGoodsStatesList", SqlDbType.VarChar);
			if (_CellsContents_FilterGoodsStatesList != null)
				_oCommand.Parameters["@cCellsContentsGoodsStatesList"].Value = _CellsContents_FilterGoodsStatesList;
			else
				_oCommand.Parameters["@cCellsContentsGoodsStatesList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cCellsContentsPackingsList", SqlDbType.VarChar);
			if (_CellsContents_FilterPackingsList != null)
				_oCommand.Parameters["@cCellsContentsPackingsList"].Value = _CellsContents_FilterPackingsList;
			else
				_oCommand.Parameters["@cCellsContentsPackingsList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cCellsContentsGoodsList", SqlDbType.VarChar);
			if (_CellsContents_FilterGoodsList != null)
				_oCommand.Parameters["@cCellsContentsGoodsList"].Value = _CellsContents_FilterGoodsList;
			else
				_oCommand.Parameters["@cCellsContentsGoodsList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cCellsContentsFramesList", SqlDbType.VarChar);
			if (_CellsContents_FilterFramesList != null)
				_oCommand.Parameters["@cCellsContentsFramesList"].Value = _CellsContents_FilterFramesList;
			else
				_oCommand.Parameters["@cCellsContentsFramesList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@nCheckDateValid", SqlDbType.Int);
			if (_CellsContents_FilterCheckDateValid != null)
				_oCommand.Parameters["@nCheckDateValid"].Value = _CellsContents_FilterCheckDateValid;
			else
				_oCommand.Parameters["@nCheckDateValid"].Value = DBNull.Value;

			#endregion

			#endregion

			try
			{
				_MainTable = FillReadings(new SqlDataAdapter(_oCommand), _MainTable, _MainTableName);

				// primarykey
				DataColumn[] pk = new DataColumn[1];
				pk[0] = _MainTable.Columns[_ColumnID];
				_MainTable.PrimaryKey = pk;

				_NeedRequery = false;
			}
			catch (Exception ex)
			{
				_ErrorNumber = -1;
				_ErrorStr = "������ ��� ��������� ������ ������ �����...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// ������� ������-����� MainTable
		/// </summary>
		public void ClearFilters()
		{
			_BarCode = null;
			_FilterActual = null;
			_FilterLocked = null;
			_FilterHasCellContent = null;
			_FilterIsFull = null;

			_FilterTrafficsFromExists = null;
			_FilterTrafficsToExists = null;

			_FilterCBuilding = null;
			_FilterCLine = null;
			_FilterCRack = null;
			_FilterCLevel = null;
			_FilterCPlace = null;
			_FilterAddress = null;
			_FilterAddressContext = null;

			_FilterStoresZonesList = null;
			_FilterStoresZonesTypesList = null;
			_FilterStoreZoneTypeShortCode = null;
			_FilterStoreZoneTypeForInputs = null;
			_FilterStoreZoneTypeForOutputs = null;
			_FilterStoreZoneTypeForStorage = null;
			_FilterStoreZoneTypeForPicking = null;

			_FilterFixedOwnersList = null;
			_FilterFixedGoodsStatesList = null;
			_FilterCellsStatesStr = null;
            _FilterNoteContext = null;
			_FilterFixedPackingsList = null;
			_FilterFixedGoodsList = null;
			_FilterPalletsTypesList = null;
			_FilterMaxWeightBeg = null;
			_FilterMaxWeightEnd = null;
			_FilterCellHeightBeg = null;
			_FilterCellHeightEnd = null;
			_FilterCellWidthBeg = null;
			_FilterCellWidthEnd = null;

			_FilterForFrames = null;

			//_NeedRequery = true;

			_CellsContents_FilterGoodsStatesList = null;
			_CellsContents_FilterOwnersList = null;
			_CellsContents_FilterFramesList = null;
			_CellsContents_FilterPackingsList = null;
			_CellsContents_FilterGoodsList = null;
			_CellsContents_FilterCheckDateValid = null;

			//_CellsContents_NeedRequery = true;
		}

		// --------------------------------------------------------------------
		// ���������� �����
		// --------------------------------------------------------------------

		/// <summary>
		/// ��������� ������� ����������� ����� (TablesCellsContents)
		/// </summary>
		public bool FillTableCellsContents(int? nCellID, bool? bGroup)
		{
			// ����� �������� ���������� ��� ���������� �����
			//if (!CellID.HasValue & !_ID.HasValue)
			//{
			//    _ErrorNumber = -15;
			//    _ErrorStr = "������������ �����:\r\n������ ��� ��������� ����������� ������...";
			//    WMSMessage.MessageBoxError(_ErrorStr);
			//    return (false);
			//}
			//if (!CellID.HasValue)
			//    CellID = _ID;

			string sqlSelect = "execute up_CellsContentsFill @nCellID, @bGroup, " +
									"@cPackingsList, @cGoodsList, " +
									"@cFramesList";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_CellsContentsFill paramaters

			_oCommand.Parameters.Add("@nCellID", SqlDbType.Int);
			if (nCellID.HasValue)
				_oCommand.Parameters["@nCellID"].Value = nCellID;
			else
				_oCommand.Parameters["@nCellID"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bGroup", SqlDbType.Bit);
			if (bGroup.HasValue)
				_oCommand.Parameters["@bGroup"].Value = bGroup;
			else
				_oCommand.Parameters["@bGroup"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cOwnersList", SqlDbType.VarChar);
			if (_CellsContents_FilterOwnersList != null)
				_oCommand.Parameters["@cOwnersList"].Value = _CellsContents_FilterOwnersList;
			else
				_oCommand.Parameters["@cOwnersList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cGoodsStatesList", SqlDbType.VarChar);
			if (_CellsContents_FilterGoodsStatesList != null)
				_oCommand.Parameters["@cGoodsStatesList"].Value = _CellsContents_FilterGoodsStatesList;
			else
				_oCommand.Parameters["@cGoodsStatesList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cPackingsList", SqlDbType.VarChar);
			if (_CellsContents_FilterPackingsList != null)
				_oCommand.Parameters["@cPackingsList"].Value = _CellsContents_FilterPackingsList;
			else
				_oCommand.Parameters["@cPackingsList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cGoodsList", SqlDbType.VarChar);
			if (_CellsContents_FilterGoodsList != null)
				_oCommand.Parameters["@cGoodsList"].Value = _CellsContents_FilterGoodsList;
			else
				_oCommand.Parameters["@cGoodsList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cFramesList", SqlDbType.VarChar);
			if (_CellsContents_FilterFramesList != null)
				_oCommand.Parameters["@cFramesList"].Value = _CellsContents_FilterFramesList;
			else
				_oCommand.Parameters["@cFramesList"].Value = DBNull.Value;

			#endregion

			try
			{
				_TableCellsContents = FillReadings(new SqlDataAdapter(_oCommand), _TableCellsContents, "TableCellsContents");
				_CellsContents_NeedRequery = false;

				//// primarykey
				//DataColumn[] pk = new DataColumn[1];
				//if (bGroup.HasValue && (bool)bGroup)
				//{
				//   pk[0] = _TableCellsContents.Columns["PackingID"];
				//}
				//else
				//{
				//   pk[0] = _TableCellsContents.Columns[_ColumnID];
				//}
				//_TableCellsContents.PrimaryKey = pk; 
			}
			catch (Exception ex)
			{
				_ErrorNumber = -11;
				_ErrorStr = "������ ��� ��������� ����������� �����...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// ������� ������-����� ������� ����������� ����� (TableCellsContents)
		/// </summary>
		public void ClearCellsContentsFilters()
		{
			_CellsContents_FilterOwnersList = null;
			_CellsContents_FilterGoodsStatesList = null;
			_CellsContents_FilterPackingsList = null;
			_CellsContents_FilterGoodsList = null;
			_CellsContents_FilterFramesList = null;
			//_CellsContents_NeedRequery = true; 
		}


		/// <summary>
		/// ��������� ������� ����������� ����� �� ������ ����� (TablesCellsContents)
		/// </summary>
		public bool FillTableCellsContentsList(string sCellsList)
		{
			string sqlSelect = "execute up_CellsContentsListFill @cCellsList";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_CellsContentsListFill paramaters

			_oCommand.Parameters.Add("@cCellsList", SqlDbType.VarChar);
			if (sCellsList != null)
				_oCommand.Parameters["@cCellsList"].Value = sCellsList;
			else
				_oCommand.Parameters["@cCellsList"].Value = DBNull.Value;

			#endregion

			try
			{
				_TableCellsContents = FillReadings(new SqlDataAdapter(_oCommand), _TableCellsContents, "TableCellsContents");
				_CellsContents_NeedRequery = false;
			}
			catch (Exception ex)
			{
				_ErrorNumber = -11;
				_ErrorStr = "������ ��� ��������� ����������� ����� �� ������...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}


		// ------------------------------------------------------------------------------
		// ������� �����
		// ------------------------------------------------------------------------------

		/// <summary>
		/// ��������� ������� ������� ��������� ��������� ����� (TablesCellsHistory)
		/// </summary>
		public bool FillTableCellsHistory(int? nCellID)
		{
			string sqlSelect;
			SqlCommand _oCommand;

			if (!nCellID.HasValue)
			{
				// �� ������� �����

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
				finally
				{
					// ������� �����, ����� �������� ��� � ��� �� connect
					//_Connect.Close();
				}

				// �������� ����� ����� �� ��������
				FillData();

				DataTable tCells = MainTable.Copy();
				for (int i = tCells.Columns.Count - 1; i >= 0; i--)
				{
					if (tCells.Columns[i].ColumnName == "ID")
						tCells.Columns[i].ColumnName = "CellID";
					else
						tCells.Columns.Remove(tCells.Columns[i]);
				}

				if (!RFMUtilities.DataTableToTempTable(tCells, "#CellsIDList", _Connect))
				{
					RFMMessage.MessageBoxError("������ ��� ���������� ��������� ������� ����� (�������)...");
					return (false);
				}
			}

			sqlSelect = "execute up_CellsHistoryFill @nCellID, @cCellsIDList, " +
									"@dDateBeg, @dDateEnd, " +
									"@bCellsChangesOnly";
			_oCommand = new SqlCommand(sqlSelect, _Connect);
			_oCommand.CommandTimeout = 0;

			#region up_CellsHistoryFill paramaters

			_oCommand.Parameters.Add("@nCellID", SqlDbType.Int);
			if (nCellID.HasValue)
				_oCommand.Parameters["@nCellID"].Value = nCellID;
			else
				_oCommand.Parameters["@nCellID"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cCellsIDList", SqlDbType.VarChar);
			if (IDList != null)
				_oCommand.Parameters["@cCellsIDList"].Value = IDList;
			else
				_oCommand.Parameters["@cCellsIDList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@dDateBeg", SqlDbType.SmallDateTime);
			if (_CellsHistory_FilterDataBeg.HasValue)
				_oCommand.Parameters["@dDateBeg"].Value = _CellsHistory_FilterDataBeg;
			else
				_oCommand.Parameters["@dDateBeg"].Value = DBNull.Value;
			_oCommand.Parameters.Add("@dDateEnd", SqlDbType.SmallDateTime);
			if (_CellsHistory_FilterDataEnd.HasValue)
				_oCommand.Parameters["@dDateEnd"].Value = _CellsHistory_FilterDataEnd;
			else
				_oCommand.Parameters["@dDateEnd"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bCellsChangesOnly", SqlDbType.Bit);
			if (_CellsHistory_FilterCellsChanges.HasValue)
				_oCommand.Parameters["@bCellsChangesOnly"].Value = _CellsHistory_FilterCellsChanges;
			else
				_oCommand.Parameters["@bCellsChangesOnly"].Value = DBNull.Value;

			#endregion

			try
			{
				_TableCellsHistory = FillReadings(new SqlDataAdapter(_oCommand), _TableCellsHistory, "TableCellsHistory");
				_CellsHistory_NeedRequery = false;
			}
			catch (Exception ex)
			{
				_ErrorNumber = -12;
				_ErrorStr = "������ ��� ��������� ������� �����...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// ������� ������-����� ������� ������� ����� (TableCellsHistory)
		/// </summary>
		public void ClearCellsHistoryFilters()
		{
			_CellsHistory_FilterDataBeg = null;
			_CellsHistory_FilterDataEnd = null;
			_CellsHistory_FilterCellsChanges = null;
			//_CellsHistory_NeedRequery = true; 
		}

		// --------------------------------------------------------------------------
		// ��������� �����
		// --------------------------------------------------------------------------

		/// <summary>
		/// ���������� ������������� �������� ������
		/// </summary>
		public bool FixedSave(int? nCellID,
				bool? bFixedOwnerIDUpdate, bool? bFixedGoodStateIDUpdate, bool? bFixedPackingIDUpdate)
		{
			// ������ � MainTable, ��������������� nCellID (������ 0)
			DataRow r = MainTable.Rows.Find(nCellID);
			if (r == null)
			{
				RFMMessage.MessageBoxError("�� ������� ������ � ����� " + nCellID.ToString() + " � ������� �����...");
				return (false);
			}

			string sqlSelect = "execute up_CellsFixedSave @nCellID, " +
									"@nFixedOwnerID, @bFixedOwnerIDUpdate, " +
									"@nFixedGoodStateID, @bFixedGoodStateIDUpdate, " +
									"@nFixedPackingID, @bFixedPackingIDUpdate, " +
									"@nError output, @cErrorStr output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_CellsFixedSave paramaters

			_oCommand.Parameters.Add("@nCellID", SqlDbType.Int);
			if (nCellID.HasValue)
				_oCommand.Parameters["@nCellID"].Value = nCellID;
			else
				_oCommand.Parameters["@nCellID"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@nFixedOwnerID", SqlDbType.Int);
			if (r["FixedOwnerID"] != null)
				_oCommand.Parameters["@nFixedOwnerID"].Value = r["FixedOwnerID"];
			else
				_oCommand.Parameters["@nFixedOwnerID"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bFixedOwnerIDUpdate", SqlDbType.Int);
			if (bFixedOwnerIDUpdate.HasValue)
				_oCommand.Parameters["@bFixedOwnerIDUpdate"].Value = bFixedOwnerIDUpdate;
			else
				_oCommand.Parameters["@bFixedOwnerIDUpdate"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@nFixedGoodStateID", SqlDbType.Int);
			if (r["FixedGoodStateID"] != null)
				_oCommand.Parameters["@nFixedGoodStateID"].Value = r["FixedGoodStateID"];
			else
				_oCommand.Parameters["@nFixedGoodStateID"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bFixedGoodStateIDUpdate", SqlDbType.Int);
			if (bFixedGoodStateIDUpdate.HasValue)
				_oCommand.Parameters["@bFixedGoodStateIDUpdate"].Value = bFixedGoodStateIDUpdate;
			else
				_oCommand.Parameters["@bFixedGoodStateIDUpdate"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@nFixedPackingID", SqlDbType.Int);
			if (r["FixedPackingID"] != null)
				_oCommand.Parameters["@nFixedPackingID"].Value = r["FixedPackingID"];
			else
				_oCommand.Parameters["@nFixedPackingID"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bFixedPackingIDUpdate", SqlDbType.Int);
			if (bFixedPackingIDUpdate.HasValue)
				_oCommand.Parameters["@bFixedPackingIDUpdate"].Value = bFixedPackingIDUpdate;
			else
				_oCommand.Parameters["@bFixedPackingIDUpdate"].Value = DBNull.Value;

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
				_ErrorNumber = -10;
				_ErrorStr = "������ ��� ���������� ������������� ����������� ������...\r\n" + ex.Message;
				//WMSMessage.MessageBoxError(_ErrorStr); // RaisError
			}
			finally
			{
				_Connect.Close();
			}
			_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
			if (_ErrorNumber != 0)
			{
				_ErrorStr = "������ ��� ���������� ������������� ����������� ������...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// ������� ������������� �������� ������ �� ������
		/// </summary>
		public bool FixedChange(int nCellCurID, int nCellNewID,
				int nPackingID, int nGoodStateID, int? nOwnerID,
				int nUserID)
		{
			string sqlSelect = "execute up_CellsFixedChange @nCellCurID, @nCellNewID, " +
									"@nPackingID, @nGoodStateID, @nOwnerID, " +
									"@nUserID, " +
									"@nError output, @cErrorStr output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_CellsFixedChange paramaters

			_oCommand.Parameters.Add("@nCellCurID", SqlDbType.Int);
			_oCommand.Parameters["@nCellCurID"].Value = nCellCurID;

			_oCommand.Parameters.Add("@nCellNewID", SqlDbType.Int);
			_oCommand.Parameters["@nCellNewID"].Value = nCellNewID;

			_oCommand.Parameters.Add("@nPackingID", SqlDbType.Int);
			_oCommand.Parameters["@nPackingID"].Value = nPackingID;

			_oCommand.Parameters.Add("@nGoodStateID", SqlDbType.Int);
			_oCommand.Parameters["@nGoodStateID"].Value = nGoodStateID;

			_oCommand.Parameters.Add("@nOwnerID", SqlDbType.Int);
			if (nOwnerID.HasValue)
				_oCommand.Parameters["@nOwnerID"].Value = nOwnerID;
			else
				_oCommand.Parameters["@nOwnerID"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@nUserID", SqlDbType.Int);
			_oCommand.Parameters["@nUserID"].Value = nUserID;

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
				_ErrorNumber = -10;
				_ErrorStr = "������ ��� ��������� ����������� ������...\r\n" + ex.Message;
				//WMSMessage.MessageBoxError(_ErrorStr); // RaisError
			}
			finally
			{
				_Connect.Close();
			}
			_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
			if (_ErrorNumber != 0)
			{
				_ErrorStr = "������ ��� ��������� ����������� ������...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}


		/// <summary>
		/// ���������� ���������� (���������, ����������������) ������ 
		/// </summary>
		public bool GeometrySave(int? nCellID,
				bool? bMaxWeightUpdate, bool? bPalletTypeIDUpdate, bool? bCellWidthUpdate, bool? bCellHeightUpdate,
				bool? bMaxPalletQntUpdate)
		{
			// ������ � MainTable, ��������������� nCellID (������ 0)
			DataRow r = MainTable.Rows.Find(nCellID);
			if (r == null)
			{
				RFMMessage.MessageBoxError("�� ������� ������ � ����� " + nCellID.ToString() + " � ������� �����...");
				return (false);
			}

			string sqlSelect = "execute up_CellsGeometrySave @nCellID, " +
									"@nMaxWeight, @bMaxWeightUpdate, " +
									"@nPalletTypeID, @bPalletTypeIDUpdate, " +
									"@nCellWidth, @bCellWidthUpdate, " +
									"@nCellHeight, @bCellHeightUpdate, " +
									"@nMaxPalletQnt, @bMaxPalletQntUpdate, " +
									"@nError output, @cErrorStr output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_CellsGeometrySave paramaters

			//System.Globalization.CultureInfo oldCI = System.Threading.Thread.CurrentThread.CurrentCulture;
			//System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

			_oCommand.Parameters.Add("@nCellID", SqlDbType.Int);
			if (nCellID.HasValue)
				_oCommand.Parameters["@nCellID"].Value = nCellID;
			else
				_oCommand.Parameters["@nCellID"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@nMaxWeight", SqlDbType.Decimal);
			_oCommand.Parameters["@nMaxWeight"].Precision = 10;
			_oCommand.Parameters["@nMaxWeight"].Scale = 3;
			if (r["MaxWeight"] != null)
				_oCommand.Parameters["@nMaxWeight"].Value = r["MaxWeight"];
			else
				_oCommand.Parameters["@nMaxWeight"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bMaxWeightUpdate", SqlDbType.Bit);
			if (bMaxWeightUpdate.HasValue)
				_oCommand.Parameters["@bMaxWeightUpdate"].Value = bMaxWeightUpdate;
			else
				_oCommand.Parameters["@bMaxWeightUpdate"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@nPalletTypeID", SqlDbType.Int);
			if (r["PalletTypeID"] != null)
				_oCommand.Parameters["@nPalletTypeID"].Value = r["PalletTypeID"];
			else
				_oCommand.Parameters["@nPalletTypeID"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bPalletTypeIDUpdate", SqlDbType.Bit);
			if (bPalletTypeIDUpdate.HasValue)
				_oCommand.Parameters["@bPalletTypeIDUpdate"].Value = bPalletTypeIDUpdate;
			else
				_oCommand.Parameters["@bPalletTypeIDUpdate"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@nCellWidth", SqlDbType.Decimal);
			_oCommand.Parameters["@nCellWidth"].Precision = 10;
			_oCommand.Parameters["@nCellWidth"].Scale = 3;
			if (r["CellWidth"] != null)
				_oCommand.Parameters["@nCellWidth"].Value = r["CellWidth"];
			else
				_oCommand.Parameters["@nCellWidth"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bCellWidthUpdate", SqlDbType.Bit);
			if (bCellWidthUpdate.HasValue)
				_oCommand.Parameters["@bCellWidthUpdate"].Value = bCellWidthUpdate;
			else
				_oCommand.Parameters["@bCellWidthUpdate"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@nCellHeight", SqlDbType.Decimal);
			_oCommand.Parameters["@nCellHeight"].Precision = 10;
			_oCommand.Parameters["@nCellHeight"].Scale = 3;
			if (r["CellHeight"] != null)
				_oCommand.Parameters["@nCellHeight"].Value = r["CellHeight"];
			else
				_oCommand.Parameters["@nCellHeight"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bCellHeightUpdate", SqlDbType.Bit);
			if (bCellHeightUpdate.HasValue)
				_oCommand.Parameters["@bCellHeightUpdate"].Value = bCellHeightUpdate;
			else
				_oCommand.Parameters["@bCellHeightUpdate"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@nMaxPalletQnt", SqlDbType.Decimal);
			_oCommand.Parameters["@nMaxPalletQnt"].Precision = 9;
			_oCommand.Parameters["@nMaxPalletQnt"].Scale = 2;
			if (!r["MaxPalletQnt"].Equals(DBNull.Value))
				_oCommand.Parameters["@nMaxPalletQnt"].Value = r["MaxPalletQnt"];
			else
				_oCommand.Parameters["@nMaxPalletQnt"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bMaxPalletQntUpdate", SqlDbType.Bit);
			if (bMaxPalletQntUpdate.HasValue)
				_oCommand.Parameters["@bMaxPalletQntUpdate"].Value = bMaxPalletQntUpdate;
			else
				_oCommand.Parameters["@bMaxPalletQntUpdate"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@nError", SqlDbType.Int);
			_oCommand.Parameters["@nError"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@nError"].Value = 0;

			_oCommand.Parameters.Add("@cErrorStr", SqlDbType.VarChar, 200);
			_oCommand.Parameters["@cErrorStr"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@cErrorStr"].Value = "";

			//System.Threading.Thread.CurrentThread.CurrentCulture = oldCI;

			#endregion

			try
			{
				_Connect.Open();
				_oCommand.ExecuteScalar();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -11;
				_ErrorStr = "������ ��� ���������� ���������� ������ (���������)...\r\n" + ex.Message;
				//WMSMessage.MessageBoxError(_ErrorStr); // RaiseError
			}
			finally
			{
				_Connect.Close();
			}
			_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
			if (_ErrorNumber != 0)
			{
				_ErrorStr = "������ ��� ���������� ���������� ������ (���������)...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}


		/// <summary>
		/// ���������� ���������� (�����, ����) ������
		/// </summary>
		public bool AddressSave(int? nCellID)
		{
			// ������ � MainTable, ��������������� nCellID (������ 0)
			DataRow r = MainTable.Rows.Find(nCellID);
			if (r == null)
			{
				RFMMessage.MessageBoxError("�� ������� ������ � ����� " + nCellID.ToString() + " � ������� �����...");
				return (false);
			}

			string sqlSelect = "execute up_CellsAddressSave @nCellID output, " +
									"@cCBuilding, @cCLine, @cCRack, @cCLevel, @cCPlace, " +
									"@cAddress, @nStoreZoneID, " +
									"@nError output, @cErrorStr output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_CellsAddressSave paramaters

			_oCommand.Parameters.Add("@nCellID", SqlDbType.Int);
			if (nCellID.HasValue)
				_oCommand.Parameters["@nCellID"].Value = nCellID;
			else
				_oCommand.Parameters["@nCellID"].Value = DBNull.Value;
			_oCommand.Parameters["@nCellID"].Direction = ParameterDirection.InputOutput;

			_oCommand.Parameters.Add("@cCBuilding", SqlDbType.VarChar);
			if (!r["CBuilding"].Equals(DBNull.Value))
				_oCommand.Parameters["@cCBuilding"].Value = r["CBuilding"];
			else
				_oCommand.Parameters["@cCBuilding"].Value = DBNull.Value;
			_oCommand.Parameters.Add("@cCLine", SqlDbType.VarChar);
			if (!r["CLine"].Equals(DBNull.Value))
				_oCommand.Parameters["@cCLine"].Value = r["CLine"];
			else
				_oCommand.Parameters["@cCLine"].Value = DBNull.Value;
			_oCommand.Parameters.Add("@cCRack", SqlDbType.VarChar);
			if (!r["CRack"].Equals(DBNull.Value))
				_oCommand.Parameters["@cCRack"].Value = r["CRack"];
			else
				_oCommand.Parameters["@cCRack"].Value = DBNull.Value;
			_oCommand.Parameters.Add("@cCLevel", SqlDbType.VarChar);
			if (!r["CLevel"].Equals(DBNull.Value))
				_oCommand.Parameters["@cCLevel"].Value = r["CLevel"];
			else
				_oCommand.Parameters["@cCLevel"].Value = DBNull.Value;
			_oCommand.Parameters.Add("@cCPlace", SqlDbType.VarChar);
			if (!r["CPlace"].Equals(DBNull.Value))
				_oCommand.Parameters["@cCPlace"].Value = r["CPlace"];
			else
				_oCommand.Parameters["@cCPlace"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cAddress", SqlDbType.VarChar);
			if (!r["Address"].Equals(DBNull.Value))
				_oCommand.Parameters["@cAddress"].Value = r["Address"];
			else
				_oCommand.Parameters["@cAddress"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@nStoreZoneID", SqlDbType.Int);
			if (!r["StoreZoneID"].Equals(DBNull.Value))
				_oCommand.Parameters["@nStoreZoneID"].Value = r["StoreZoneID"];
			else
				_oCommand.Parameters["@nStoreZoneID"].Value = DBNull.Value;

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
				_ErrorStr = "������ ��� ���������� ���������� ������ (�����)...\r\n" + ex.Message;
				//WMSMessage.MessageBoxError(_ErrorStr); // RaiseError
			}
			finally
			{
				_Connect.Close();
			}
			_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
			if (_ErrorNumber != 0)
			{
				_ErrorStr = "������ ��� ���������� ���������� ������ (�����)...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			if (!nCellID.HasValue)
			{
				nCellID = (int?)_oCommand.Parameters["@nCellID"].Value;
			}
			return (_ErrorNumber == 0 && nCellID.HasValue && nCellID > 0);
		}

		/// <summary>
		/// ����������/������������� ������
		/// </summary>
		public bool SetLock(int? nCellID, bool bLock)
		{
			string sqlSelect = "update Cells set Locked = " + (bLock ? "1" : "0") +
				"where ID = " + nCellID.ToString();
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);
			try
			{
				_Connect.Open();
				_oCommand.ExecuteScalar();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -21;
				_ErrorStr = "������ ��� " + (bLock ? "" : "���") + "������������ ������...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// ������������/�������������� ������
		/// </summary>
		public bool SetActual(int? nCellID, bool bActual)
		{
			string sqlSelect = "update Cells set Actual = " + (bActual ? "1" : "0") +
				"where ID = " + nCellID.ToString();
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);
			try
			{
				_Connect.Open();
				_oCommand.ExecuteScalar();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -22;
				_ErrorStr = "������ ��� " + (bActual ? "���������" : "������") + "������������ ������...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			return (_ErrorNumber == 0);
		}


		/// <summary>
		/// ��������� �������� ������ 
		/// </summary>
		public bool SetBufferCell(int nCellID, int? nBufferCellID, bool bBufferUpdate)
		{
			string sqlSelect = "execute up_CellsBuffer @nCellID, " +
									"@nBufferCellID, @bBufferUpdate, " +
									"@nError output, @cErrorStr output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_CellsBuffer paramaters

			_oCommand.Parameters.Add("@nCellID", SqlDbType.Int);
			_oCommand.Parameters["@nCellID"].Value = nCellID;

			_oCommand.Parameters.Add("@nBufferCellID", SqlDbType.Int);
			if (nBufferCellID.HasValue)
				_oCommand.Parameters["@nBufferCellID"].Value = nBufferCellID;
			else
				_oCommand.Parameters["@nBufferCellID"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bBufferUpdate", SqlDbType.Bit);
			_oCommand.Parameters["@bBufferUpdate"].Value = bBufferUpdate;

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
				_ErrorStr = "������ ��� " + ((nBufferCellID.HasValue) ? "���������" : "�������") + " �������� ������...\r\n" + ex.Message;
				//WMSMessage.MessageBoxError(_ErrorStr); // ���.RaiseError
			}
			finally
			{
				_Connect.Close();
			}
			_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
			if (_ErrorNumber != 0)
			{
				_ErrorStr = "������ ��� " + ((nBufferCellID.HasValue) ? "���������" : "�������") + " �������� ������...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}


		/// <summary>
		/// ���������� �����
		/// </summary>
		/// 
		public int AddRange(string sMode,
						string sCBuilding, string sCLine,
						string sCRackBeg, string sCRackEnd,
						string sCLevelBeg, string sCLevelEnd,
						string sCPlaceBeg, string sCPlaceEnd,
						int nStoreZoneID,
						bool bAddThrough, bool bAddHoleLine, bool bAddHole)
		{
			int nCnt = 0;

			string sqlSelect = "execute up_CellsAddRange @cMode, " +
									"@cCBuilding, @cCLine, " +
									"@cCRackBeg, @cCRackEnd, " +
									"@cCLevelBeg, @cCLevelEnd, " +
									"@cCPlaceBeg, @cCPlaceEnd, " +
									"@nStoreZoneID, " +
									"@bAddThrough, @bAddHoleLine, @bAddHole, " +
									"@nCnt output, " +
									"@nError output, @cErrorStr output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_CellsAddrRange paramaters

			_oCommand.Parameters.Add("@cMode", SqlDbType.VarChar);
			_oCommand.Parameters["@cMode"].Value = sMode;

			_oCommand.Parameters.Add("@cCBuilding", SqlDbType.VarChar);
			_oCommand.Parameters["@cCBuilding"].Value = sCBuilding;

			_oCommand.Parameters.Add("@cCLine", SqlDbType.VarChar);
			_oCommand.Parameters["@cCLine"].Value = sCLine;

			_oCommand.Parameters.Add("@cCRackBeg", SqlDbType.VarChar);
			_oCommand.Parameters["@cCRackBeg"].Value = sCRackBeg;
			_oCommand.Parameters.Add("@cCRackEnd", SqlDbType.VarChar);
			_oCommand.Parameters["@cCRackEnd"].Value = sCRackEnd;

			_oCommand.Parameters.Add("@cCLevelBeg", SqlDbType.VarChar);
			_oCommand.Parameters["@cCLevelBeg"].Value = sCLevelBeg;
			_oCommand.Parameters.Add("@cCLevelEnd", SqlDbType.VarChar);
			_oCommand.Parameters["@cCLevelEnd"].Value = sCLevelEnd;

			_oCommand.Parameters.Add("@cCPlaceBeg", SqlDbType.VarChar);
			_oCommand.Parameters["@cCPlaceBeg"].Value = sCPlaceBeg;
			_oCommand.Parameters.Add("@cCPlaceEnd", SqlDbType.VarChar);
			_oCommand.Parameters["@cCPlaceEnd"].Value = sCPlaceEnd;

			_oCommand.Parameters.Add("@nStoreZoneID", SqlDbType.Int);
			_oCommand.Parameters["@nStoreZoneID"].Value = nStoreZoneID;

			_oCommand.Parameters.Add("@bAddThrough", SqlDbType.Bit);
			_oCommand.Parameters["@bAddThrough"].Value = bAddThrough;
			_oCommand.Parameters.Add("@bAddHoleLine", SqlDbType.Bit);
			_oCommand.Parameters["@bAddHoleLine"].Value = bAddHoleLine;
			_oCommand.Parameters.Add("@bAddHole", SqlDbType.Bit);
			_oCommand.Parameters["@bAddHole"].Value = bAddHole;

			_oCommand.Parameters.Add("@nCnt", SqlDbType.Int);
			_oCommand.Parameters["@nCnt"].Value = nCnt;
			_oCommand.Parameters["@nCnt"].Direction = ParameterDirection.InputOutput;

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
				_ErrorNumber = -21;
				_ErrorStr = "������ ��� " + ((sMode == "TEST") ? "������� ����������" : "����������") + " �����...\r\n" + ex.Message;
				//WMSMessage.MessageBoxError(_ErrorStr); // RaiseError
			}
			finally
			{
				_Connect.Close();
			}
			_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
			if (_ErrorNumber != 0)
			{
				_ErrorStr = "������ ��� " + ((sMode == "TEST") ? "������� ����������" : "����������") + " �����...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			else
			{
				nCnt = (int)_oCommand.Parameters["@nCnt"].Value;
			}
			return (nCnt);
		}

		/// <summary>
		/// ���������� ����� ������ - ��� ���������� ������!
		/// </summary>
		/// 
		public int AddSpecial(string sAddress,
						string sCBuilding,
						string sCLine,
						string sCRack,
						string sCLevel,
						string sCPlace,
						int nStoreZoneID)
		{
			int nCellID = 0;

			string sqlSelect = "execute up_CellsAddSpecial @nCellID output, " +
									"@cAddress, " +
									"@cCBuilding, " +
									"@cCLine, " +
									"@cCRack, " +
									"@cCLevel, " +
									"@cCPlace, " +
									"@nStoreZoneID, " +
									"@nError output, @cErrorStr output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_CellsAddSpecial paramaters

			_oCommand.Parameters.Add("@nCellID", SqlDbType.Int);
			_oCommand.Parameters["@nCellID"].Value = 0;
			_oCommand.Parameters["@nCellID"].Direction = ParameterDirection.InputOutput;

			_oCommand.Parameters.Add("@cAddress", SqlDbType.VarChar);
			_oCommand.Parameters["@cAddress"].Value = sAddress;

			_oCommand.Parameters.Add("@cCBuilding", SqlDbType.VarChar);
			_oCommand.Parameters["@cCBuilding"].Value = sCBuilding;

			_oCommand.Parameters.Add("@cCLine", SqlDbType.VarChar);
			_oCommand.Parameters["@cCLine"].Value = sCLine;

			_oCommand.Parameters.Add("@cCRack", SqlDbType.VarChar);
			_oCommand.Parameters["@cCRack"].Value = sCRack;

			_oCommand.Parameters.Add("@cCLevel", SqlDbType.VarChar);
			_oCommand.Parameters["@cCLevel"].Value = sCLevel;

			_oCommand.Parameters.Add("@cCPlace", SqlDbType.VarChar);
			_oCommand.Parameters["@cCPlace"].Value = sCPlace;

			_oCommand.Parameters.Add("@nStoreZoneID", SqlDbType.Int);
			_oCommand.Parameters["@nStoreZoneID"].Value = nStoreZoneID;

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
				_ErrorNumber = -22;
				_ErrorStr = "������ ��� ���������� ������...\r\n" + ex.Message;
				//WMSMessage.MessageBoxError(_ErrorStr); // RaiseError
			}
			finally
			{
				_Connect.Close();
			}
			_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
			if (_ErrorNumber != 0)
			{
				_ErrorStr = "������ ��� ���������� ������...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			else
			{
				nCellID = (int)_oCommand.Parameters["@nCellID"].Value;
			}
			return (nCellID);
		}


		/// <summary>
		/// ��������� ������������ ���������� ������ 
		/// </summary>
		public bool FillAddressPartTables(string sType)
		{
			string sqlSelect = "execute up_CellsAddressPartsFill @cType, " +
									"@cCBuilding, @cCLine, @cCRack, @cCLevel, @cCPlace";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_CellsAddressPartsFill paramaters

			_oCommand.Parameters.Add("@cType", SqlDbType.VarChar);
			_oCommand.Parameters["@cType"].Value = sType;

			_oCommand.Parameters.Add("@cCBuilding", SqlDbType.VarChar);
			if (_FilterCBuilding != null)
				_oCommand.Parameters["@cCBuilding"].Value = _FilterCBuilding;
			else
				_oCommand.Parameters["@cCBuilding"].Value = DBNull.Value;
			_oCommand.Parameters.Add("@cCLine", SqlDbType.VarChar);
			if (_FilterCLine != null)
				_oCommand.Parameters["@cCLine"].Value = _FilterCLine;
			else
				_oCommand.Parameters["@cCLine"].Value = DBNull.Value;
			_oCommand.Parameters.Add("@cCRack", SqlDbType.VarChar);
			if (_FilterCRack != null)
				_oCommand.Parameters["@cCRack"].Value = _FilterCRack;
			else
				_oCommand.Parameters["@cCRack"].Value = DBNull.Value;
			_oCommand.Parameters.Add("@cCLevel", SqlDbType.VarChar);
			if (_FilterCLevel != null)
				_oCommand.Parameters["@cCLevel"].Value = _FilterCLevel;
			else
				_oCommand.Parameters["@cCLevel"].Value = DBNull.Value;
			_oCommand.Parameters.Add("@cCPlace", SqlDbType.VarChar);
			if (_FilterCPlace != null)
				_oCommand.Parameters["@cCPlace"].Value = _FilterCPlace;
			else
				_oCommand.Parameters["@cCPlace"].Value = DBNull.Value;

			#endregion

			try
			{
				SqlDataAdapter adapter = new SqlDataAdapter(_oCommand);
				if (sType == "CBuilding")
					_TableAddressPartCBuilding = FillAddressPartOneTable("TableAddressPartCBuilding", adapter);
				if (sType == "CLine")
					_TableAddressPartCLine = FillAddressPartOneTable("TableAddressPartCLine", adapter);
				if (sType == "CRack")
					_TableAddressPartCRack = FillAddressPartOneTable("TableAddressPartCRack", adapter);
				if (sType == "CLevel")
					_TableAddressPartCLevel = FillAddressPartOneTable("TableAddressPartCLevel", adapter);
				if (sType == "CPlace")
					_TableAddressPartCPlace = FillAddressPartOneTable("TableAddressPartCPlace", adapter);
				if (sType == "CBuildingCLine")
					_TableAddressPartCBuildingCLine = FillAddressPartOneTable("TableAddressPartCBuildingCLine", adapter);
			}
			catch (Exception ex)
			{
				_ErrorNumber = -12;
				_ErrorStr = "������ ��� ���������� ���������� ������ (�����)...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			return (_ErrorNumber == 0);
		}

		private DataTable FillAddressPartOneTable(string sTable, SqlDataAdapter daAdapter)
		{
			if (_DS.Tables[sTable] != null)
				_DS.Tables.Remove(sTable);
			daAdapter.Fill(_DS, sTable);
			return (_DS.Tables[sTable]);
		}

		/// <summary>
		/// �������� ������ 
		/// </summary>
		/// 
		public int Delete(string sMode, bool bDeleteHole)
		{
			// ����������� ������� #Cells
			string sqlSelect = "if object_id('Tempdb..#Cells') is not Null " +
									"drop table #Cells " +
								"select ID into #Cells from Cells where Deleted = 0";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);
			try
			{
				_Connect.Open();
				_oCommand.ExecuteScalar();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -110;
				_ErrorStr = "������ ��� �������� �������� ������� �����...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				// ������� �����, ����� �������� ��� � ��� �� connect
				//_Connect.Close();
			}

			int nCnt = 0;
			DataRow[] ar = MainTable.Select("", "ADDRESS DESC");
			foreach (DataRow r in ar)
			{
				int nCellID = (int)r["ID"];
				if (nCellID > 0)
				{
					DeleteOne(sMode, nCellID, bDeleteHole, true);
					if (_ErrorNumber == 0)
					{
						// ��� ������ ����� �������
						nCnt++;
					}
					else
					{
						// ��� ������ ������ �������
						r["ID"] = -(int)r["ID"];
					}
				}
			}

			_Connect.Close();

			return (nCnt);
		}

		public bool DeleteOne(string sMode, int nCellID, bool bDeleteHole, bool bUsePredifinedConnect)
		{
			string sqlSelect = "execute up_CellsDelete @cMode, @nCellID, @bDeleteHole, " +
									"@nError output, @cErrorStr output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_CellsDelete paramaters

			_oCommand.Parameters.Add("@cMode", SqlDbType.VarChar);
			_oCommand.Parameters["@cMode"].Value = sMode;

			_oCommand.Parameters.Add("@nCellID", SqlDbType.Int);
			_oCommand.Parameters["@nCellID"].Value = nCellID;

			_oCommand.Parameters.Add("@bDeleteHole", SqlDbType.Int);
			_oCommand.Parameters["@bDeleteHole"].Value = bDeleteHole;

			_oCommand.Parameters.Add("@nError", SqlDbType.Int);
			_oCommand.Parameters["@nError"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@nError"].Value = 0;

			_oCommand.Parameters.Add("@cErrorStr", SqlDbType.VarChar, 200);
			_oCommand.Parameters["@cErrorStr"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@cErrorStr"].Value = "";

			#endregion

			try
			{
				if (!bUsePredifinedConnect)
					_Connect.Open();
				_oCommand.ExecuteScalar();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -11;
				_ErrorStr = "������ ��� " + (sMode == "TEST" ? "������� ��������" : "��������") + " ������ � ����� " + nCellID.ToString() + "...\r\n" + ex.Message;
				//WMSMessage.MessageBoxError(_ErrorStr); // RaiseError
			}
			finally
			{
				if (!bUsePredifinedConnect)
					_Connect.Close();
			}
			_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
			if (_ErrorNumber != 0)
			{
				_ErrorStr = "������ ��� " + (sMode == "TEST" ? "������� ��������" : "��������") + " ������ � ����� " + nCellID.ToString() + "...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		#region Medication

		public bool MedicationFrames(int nCellID, DataTable tCellsContents, int? nUserID, int? nDeviceID, string sNoteManual)
		{
			// �������� � ���������� ��������� ������� 
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

			if (!RFMUtilities.DataTableToTempTable(tCellsContents, "#CellsContents", _Connect))
			{
				RFMMessage.MessageBoxError("������ ��� ���������� ��������� �������...");
				return (false);
			}


			// ��������� ��_�� ��������� ��������� ������
			string sqlSelect = "execute up_CellsMedicationFrames @nCellID, " +
									"@nUserID, @nDeviceID, " +
									"@cNoteManual, " +
									"@nError output, @cErrorStr output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_CellsMedicationFrames paramaters

			_oCommand.Parameters.Add("@nCellID", SqlDbType.Int);
			_oCommand.Parameters["@nCellID"].Value = nCellID;

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

			_oCommand.Parameters.Add("@cNoteManual", SqlDbType.VarChar);
			if (sNoteManual != null && sNoteManual.Length != 0)
				_oCommand.Parameters["@cNoteManual"].Value = sNoteManual;
			else
				_oCommand.Parameters["@cNoteManual"].Value = "";

			_oCommand.Parameters.Add("@nError", SqlDbType.Int);
			_oCommand.Parameters["@nError"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@nError"].Value = 0;

			_oCommand.Parameters.Add("@cErrorStr", SqlDbType.VarChar, 200);
			_oCommand.Parameters["@cErrorStr"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@cErrorStr"].Value = "";

			#endregion

			try
			{
				_oCommand.ExecuteScalar();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -11;
				_ErrorStr = "������ ��� ��������� ��������� ������ � ����� " + nCellID.ToString() + "...\r\n" + ex.Message;
				//WMSMessage.MessageBoxError(_ErrorStr); // RaiseError
			}
			finally
			{
				_Connect.Close();
			}
			_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
			if (_ErrorNumber != 0)
			{
				_ErrorStr = "������ ��� ��������� ��������� ������ � ����� " + nCellID.ToString() + "...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		public bool MedicationNotFrames(int nCellID, DataTable tCellsContents, int? nUserID, int? nDeviceID, string sNoteManual)
		{
			// �������� � ���������� ��������� ������� 
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

			if (!RFMUtilities.DataTableToTempTable(tCellsContents, "#CellsContents", _Connect))
			{
				RFMMessage.MessageBoxError("������ ��� ���������� ��������� �������...");
				return (false);
			}


			// ��������� ��_�� ��������� ��������� ������
			string sqlSelect = "execute up_CellsMedicationNotFrames @nCellID, " +
									"@nUserID, @nDeviceID, " +
									"@cNoteManual, " +
									"@nError output, @cErrorStr output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_CellsMedicationNotFrames paramaters

			_oCommand.Parameters.Add("@nCellID", SqlDbType.Int);
			_oCommand.Parameters["@nCellID"].Value = nCellID;

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

			_oCommand.Parameters.Add("@cNoteManual", SqlDbType.VarChar);
			if (sNoteManual != null && sNoteManual.Length != 0)
				_oCommand.Parameters["@cNoteManual"].Value = sNoteManual;
			else
				_oCommand.Parameters["@cNoteManual"].Value = "";

			_oCommand.Parameters.Add("@nError", SqlDbType.Int);
			_oCommand.Parameters["@nError"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@nError"].Value = 0;

			_oCommand.Parameters.Add("@cErrorStr", SqlDbType.VarChar, 200);
			_oCommand.Parameters["@cErrorStr"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@cErrorStr"].Value = "";

			#endregion

			try
			{
				_oCommand.ExecuteScalar();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -11;
				_ErrorStr = "������ ��� ��������� ��������� ������ � ����� " + nCellID.ToString() + "...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr); // RaiseError
			}
			finally
			{
				_Connect.Close();
			}
			_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
			if (_ErrorNumber != 0)
			{
				_ErrorStr = "������ ��� ��������� ��������� ������ � ����� " + nCellID.ToString() + "...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}


		public bool MedicationDirect(int nCellID, int nGoodStateID, int? nOwnerID,
			int nPackingID, decimal nQnt, int? nUserID, string sNoteManual)
		{
			string sqlSelect = "execute up_CellsMedicationDirect @nCellID, " +
									"@nGoodStateID, @nOwnerID, " +
									"@nPackingID, @nQnt, " +
									"@nUserID, " +
									"@cNoteManual, " +
									"@nError output, @cErrorStr output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_CellsMedicatioDirect paramaters

			_oCommand.Parameters.Add("@nCellID", SqlDbType.Int);
			_oCommand.Parameters["@nCellID"].Value = nCellID;

			_oCommand.Parameters.Add("@nGoodStateID", SqlDbType.Int);
			_oCommand.Parameters["@nGoodStateID"].Value = nGoodStateID;

			_oCommand.Parameters.Add("@nOwnerID", SqlDbType.Int);
			if (nOwnerID != null)
				_oCommand.Parameters["@nOwnerID"].Value = nOwnerID;
			else
				_oCommand.Parameters["@nOwnerID"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@nPackingID", SqlDbType.Int);
			_oCommand.Parameters["@nPackingID"].Value = nPackingID;

			_oCommand.Parameters.Add("@nQnt", SqlDbType.Decimal);
			_oCommand.Parameters["@nQnt"].Precision = 15;
			_oCommand.Parameters["@nQnt"].Scale = 3;
			_oCommand.Parameters["@nQnt"].Value = nQnt;

			_oCommand.Parameters.Add("@nUserID", SqlDbType.Int);
			if (nUserID.HasValue)
				_oCommand.Parameters["@nUserID"].Value = nUserID;
			else
				_oCommand.Parameters["@nUserID"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cNoteManual", SqlDbType.VarChar);
			if (sNoteManual != null && sNoteManual.Length != 0)
				_oCommand.Parameters["@cNoteManual"].Value = sNoteManual;
			else
				_oCommand.Parameters["@cNoteManual"].Value = "";

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
				_ErrorStr = "������ ��� ������ ��������� ��������� ������ � ����� " + nCellID.ToString() + "...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr); // RaiseError
			}
			finally
			{
				_Connect.Close();
			}
			_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
			if (_ErrorNumber != 0)
			{
				_ErrorStr = "������ ��� ������ ��������� ��������� ������ � ����� " + nCellID.ToString() + "...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		#region Mass Medication

		/// <summary>
		/// ��������� ������� ����������� ����� ��� ��������� ��������� ��������� ������ (TableMassMedicationNotFrames)
		/// </summary>
		public bool FillTableMassMedicationNotFrames(int nCellID)
		{
			string sqlSelect = "execute up_CellsMassMedicationNotFramesFill @nCellID, " +
									"@nError output, @cErrorStr output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_CellsMassMedicationNotFramesFill paramaters

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
				FillReadings(new SqlDataAdapter(_oCommand), null, "TableMassMedicationNotFrames");
			}
			catch (Exception ex)
			{
				_ErrorNumber = -11;
				_ErrorStr = "������ ��� ��������� ����������� ������ � ����� " + @nCellID.ToString() + " ��� ��������� ���������...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
			if (_ErrorNumber != 0)
			{
				_ErrorStr = "������ ��� ��������� ����������� ������ ��� ��������� ���������...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		public bool MassMedicationNotFrames(int nCellID, DataTable tCellsContents, int? nUserID, string sNoteManual)
		{
			string sqlSelect = "execute up_CellsMassMedicationNotFrames @nCellID, " +
									"@nUserID, " +
									"@cNoteManual, " +
									"@nError output, @cErrorStr output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);
			_oCommand.CommandTimeout = 0;

			#region up_CellMassMedicationNotFrames paramaters

			SqlParameter oParameter = _oCommand.Parameters.Add("@nCellID", SqlDbType.Int);
			oParameter.Value = nCellID;

			oParameter = _oCommand.Parameters.Add("@nUserID", SqlDbType.Int);
			if (nUserID.HasValue)
				oParameter.Value = nUserID;
			else
				oParameter.Value = DBNull.Value;

			oParameter = _oCommand.Parameters.Add("@cNoteManual", SqlDbType.VarChar);
			if (sNoteManual != null && sNoteManual.Length != 0)
				oParameter.Value = sNoteManual;
			else
				oParameter.Value = "";

			oParameter = _oCommand.Parameters.Add("@nError", SqlDbType.Int);
			oParameter.Direction = ParameterDirection.InputOutput;
			oParameter.Value = 0;

			oParameter = _oCommand.Parameters.Add("@cErrorStr", SqlDbType.VarChar, 200);
			oParameter.Direction = ParameterDirection.InputOutput;
			oParameter.Value = "";

			#endregion

			try
			{
				_Connect.Open();
				RFMUtilities.DataTableToTempTable(tCellsContents, "#CellsContents", _Connect);
				_oCommand.ExecuteScalar();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -11;
				_ErrorStr = "������ ��� �������� ��������� ����������� ������ � ����� " + nCellID.ToString() + "...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr); // RaiseError
			}
			finally
			{
				_Connect.Close();
			}
			_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
			if (_ErrorNumber != 0)
			{
				_ErrorStr = "������ ��� �������� ��������� ����������� ������...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		#endregion Mass Medication


		#endregion

		#region Reports

		// �������� ������������ ����������� � ������� � �������
		public bool ReportFixedErrors()
		{
			if (_DS.Tables["TableReport"] != null)
				_DS.Tables.Remove("TableReport");
			_TableReport = null;

			string sqlSelect = "execute up_CellsReportFixedErrors";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			try
			{
				SqlDataAdapter adapter = new SqlDataAdapter(_oCommand);
				adapter.Fill(_DS, "TableReport");
				_TableReport = _DS.Tables["TableReport"];
			}
			catch (Exception ex)
			{
				_ErrorNumber = -1;
				_ErrorStr = "������ ��� ��������� ������ � ������������ ������������� ����������� �����...\r\n" + ex.Message;
				//WMSMessage.MessageBoxError(_ErrorStr); // RaiseError
			}
			finally
			{
				_Connect.Close();
			}
			return (_ErrorNumber == 0);
		}

        // ����� � ������������� �����
        public bool ReportCellsFreeOccupied(string IDList)
        {
            if (_DS.Tables["TableReport"] != null)
                _DS.Tables.Remove("TableReport");
            _TableReport = null;

            string sqlSelect = "execute up_CellsReportFreeOccupied '" + IDList + "'";
            SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(_oCommand);
                adapter.Fill(_DS, "TableReport");
                _TableReport = _DS.Tables["TableReport"];
            }
            catch (Exception ex)
            {
                _ErrorNumber = -1;
                _ErrorStr = "������ ��� ��������� ������ � ������������� �����...\r\n" + ex.Message;
                //WMSMessage.MessageBoxError(_ErrorStr); // RaiseError
            }
            finally
            {
                _Connect.Close();
            }
            return (_ErrorNumber == 0);
        }

		#endregion

		#region ������� ��������� ������

		/// <summary>
		/// ��������� ����� �����������, ����������� � ������ / �������������� � ������ 
		/// </summary>
		/// <param name="nCellID">ID ������</param> 
		/// <param name="bToCell">true - ������������ � ������, false - ��������� � ������</param>
		/// <returns></returns>
		public int GetFramesQnt(int nCellID, bool bToCell)
		{
			int nQnt = 0;

			string sqlSelect = "select dbo." + ((bToCell) ? "GetFramesQntToCell" : "GetFramesQntInCell") +
					"(" + nCellID.ToString() + ") as Qnt";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			try
			{
				SqlDataAdapter adapter = new SqlDataAdapter(_oCommand);
				adapter.Fill(_DS, "_TempTable");
				nQnt = Convert.ToInt32(_DS.Tables["_TempTable"].Rows[0]["Qnt"]);
			}
			catch (Exception ex)
			{
				_ErrorNumber = -11;
				_ErrorStr = "������ ��� ��������� ������ � ������� ��������� ������ " + nCellID.ToString() + "...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (nQnt);
		}

		#endregion

		#region ���� ������ � ���������

		public bool NewFrameCollect(int nFrameID, DataTable tCellContentSelected,
			bool? bCreateTraffic, bool? bDirectToCell, int? nCellTargetID, int? nUserID)
		{
			if (_ID == null)
				return (false);

			string sqlSelect;
			SqlCommand _oCommand;

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
			finally
			{
			}

			if (!RFMUtilities.DataTableToTempTable(tCellContentSelected, "#CellContentSelected", _Connect))
			{
				RFMMessage.MessageBoxError("������ ��� ���������� ��������� ������� ����������� ����������...");
				return (false);
			}

			sqlSelect = "execute up_CellsNewFrameCollect @nCellSourceID, @nFrameID, " +
									"@bCreateTraffic, @bDirectToCell, @nCellTargetID, " +
									"@nUserID, " +
									"@nError output, @cErrorStr output";
			_oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_CellsNewFrameCollect paramaters

			_oCommand.Parameters.Add("@nCellSourceID", SqlDbType.Int);
			_oCommand.Parameters["@nCellSourceID"].Value = _ID;

			_oCommand.Parameters.Add("@nFrameID", SqlDbType.Int);
			_oCommand.Parameters["@nFrameID"].Value = nFrameID;

			_oCommand.Parameters.Add("@bCreateTraffic", SqlDbType.Bit);
			if (bCreateTraffic.HasValue)
				_oCommand.Parameters["@bCreateTraffic"].Value = bCreateTraffic;
			else
				_oCommand.Parameters["@bCreateTraffic"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bDirectToCell", SqlDbType.Bit);
			if (bDirectToCell.HasValue)
				_oCommand.Parameters["@bDirectToCell"].Value = bDirectToCell;
			else
				_oCommand.Parameters["@bDirectToCell"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@nCellTargetID", SqlDbType.Int);
			if (nCellTargetID.HasValue)
				_oCommand.Parameters["@nCellTargetID"].Value = nCellTargetID;
			else
				_oCommand.Parameters["@nCellTargetID"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@nUserID", SqlDbType.Int);
			if (nUserID.HasValue)
				_oCommand.Parameters["@nUserID"].Value = nUserID;
			else
				_oCommand.Parameters["@nUserID"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@nError", SqlDbType.Int);
			_oCommand.Parameters["@nError"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@nError"].Value = 0;

			_oCommand.Parameters.Add("@cErrorStr", SqlDbType.VarChar, 200);
			_oCommand.Parameters["@cErrorStr"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@cErrorStr"].Value = "";

			#endregion

			try
			{
				_oCommand.ExecuteScalar();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -33;
				_ErrorStr = "������ ��� ����� ������ � ���������...\r\n" + ex.Message;
				//WMSMessage.MessageBoxError(_ErrorStr); // RaiseError
			}
			finally
			{
				_Connect.Close();
			}
			_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
			if (_ErrorNumber != 0)
			{
				if (_ErrorNumber < -100)
				{
					_ErrorStr = "������ ��� �������� �������� ��������������� ���������� ����������...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
				}
				else
				{
					_ErrorStr = "������ ��� ����� ������ � ���������...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
				}
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		#endregion

		/// <summary>
		/// ��������� ������ ��� ������
		/// </summary>
		public bool FillDataTree(bool bActual)
		{
			if (_DS.Tables["TableDataTree"] != null)
				_DS.Tables.Remove("TableDataTree");

			string sqlSelect = "select * from .dbo.CellsTree(" + ((bActual) ? "1" : "0") + ") " +
				"order by ParentID, Name";
			try
			{
				SqlDataAdapter adapter = new SqlDataAdapter(sqlSelect, _Connect);
				adapter.Fill(_DS, "TableDataTree");
			}
			catch (Exception ex)
			{
				_ErrorNumber = -51;
				_ErrorStr = "������ ��� ��������� �������������� ������ (������) �����..." + Convert.ToChar(13) + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}
		
        public bool UnMarkCellIsFull(int? nID)
		{
			string sqlUpdate = " update Cells set IsFull = 0 where ID = " + Convert.ToString(nID).Trim();

			SqlCommand _oCommand = new SqlCommand(sqlUpdate, _Connect);
			try
			{
				_Connect.Open();
				_oCommand.ExecuteScalar();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -21;
				_ErrorStr = "������ ��� ������ �������� ������������� � ������...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			return (_ErrorNumber == 0);
		}

		#region Cells Rank Change

		public bool SaveRank(string strCells)
		{
			string sqlSelect = "execute up_CellsSaveRank @xCells";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_CellsSaveRank paramaters

			_oCommand.Parameters.Add("@xCells", SqlDbType.Xml);
			if (strCells != null)
				_oCommand.Parameters["@xCells"].Value = strCells;
			else
				_oCommand.Parameters["@xCells"].Value = DBNull.Value;

			#endregion

			try
			{
				_Connect.Open();
				_oCommand.ExecuteScalar();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -101;
				_ErrorStr = "������ ��� ��������� ����� �����...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			return (_ErrorNumber == 0);
		}

        #endregion Cells Rank Change

        #region Cells Save Note

        public bool SaveNote(string sNote, string sIDList)
        {
            if (String.IsNullOrEmpty(sIDList))
            {
                _ErrorNumber = -101;
                _ErrorStr = "������ ��� ��������� ���������� � �������: ������ ������ �����\r\n";
                RFMMessage.MessageBoxError(_ErrorStr);
                return false;
            }

            string sqlSelect = "execute up_CellsSaveNote @cNote, @cCellsIDList";
            SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

            #region up_CellsSaveNote paramaters

            _oCommand.Parameters.Add("@cNote", SqlDbType.VarChar);
            if (sNote != null)
                _oCommand.Parameters["@cNote"].Value = sNote;
            else
                _oCommand.Parameters["@cNote"].Value = "";
            _oCommand.Parameters.Add("@cCellsIDList", SqlDbType.VarChar);
            _oCommand.Parameters["@cCellsIDList"].Value = sIDList;

            #endregion

            try
            {
                _Connect.Open();
                _oCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                _ErrorNumber = -102;
                _ErrorStr = "������ ��� ��������� ���������� � �������...\r\n" + ex.Message;
                RFMMessage.MessageBoxError(_ErrorStr);
            }
            finally
            {
                _Connect.Close();
            }
            return (_ErrorNumber == 0);
        }

        #endregion Cells Save Note
    }
}
