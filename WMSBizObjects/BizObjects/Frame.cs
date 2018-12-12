using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

using RFMPublic;

/// <summary>
/// Бизнес-объект Контейнер (Frame)
/// </summary>
namespace WMSBizObjects
{
	public class Frame : BizObject 
	{
		protected string _IDList;
		/// <summary>
		/// Список ID контейнеров (Frames.ID)
		/// </summary>
		[Description("Список ID контейнеров (Frames.ID)")]
		public string IDList { get { return _IDList; } set { _IDList = value; _NeedRequery = true; } }

		protected string _BarCode;
		/// <summary>
		/// Штрих-код контейнера (Frames.BarCode)
		/// </summary>
		[Description("Штрих-код контейнера (Frames.BarCode), контекст")]
		public string BarCode { get { return _BarCode; } set { _BarCode = value; _NeedRequery = true; } }

		// Фильтры

		protected bool? _FilterActual;
		/// <summary>
		/// Фильтр-поле: Актуальные контейнеры (Frames.Actual)?
		/// </summary>
		[Description("Фильтр-поле: Актуальные контейнеры (Frames.Actual)?")]
		public bool? FilterActual { get { return _FilterActual; } set { _FilterActual = value; _NeedRequery = true; } }

		protected bool? _FilterLocked;
		/// <summary>
		/// Фильтр-поле: Блокированные контейнеры (Frames.Locked)?
		/// </summary>
		[Description("Фильтр-поле: Блокированные контейнеры (Frames.Locked)")]
		public bool? FilterLocked { get { return _FilterLocked; } set { _FilterLocked = value; _NeedRequery = true; } }

		protected bool? _FilterHasFrameContent;
		/// <summary>
		/// Фильтр-поле: Есть наполнение контейнера (Frames -> CellsContents)?
		/// </summary>
		[Description("Фильтр-поле: Есть наполнение контейнера (Frames -> CellsContents)")]
		public bool? FilterHasFrameContent { get { return _FilterHasFrameContent; } set { _FilterHasFrameContent = value; _NeedRequery = true; } }

		protected bool? _FilterStereo;
		/// <summary>
		/// Фильтр-поле: Не монотовар (CellsContents, cnt())?
		/// </summary>
		[Description("Фильтр-поле: Не монотовар (CellsContents, cnt())?")]
		public bool? FilterStereo { get { return _FilterStereo; } set { _FilterStereo = value; _NeedRequery = true; } }

		protected string _FilterOwnersList;
		/// <summary>
		/// Фильтр-поле: Список ID владельцев (Frames.OwnerID), через запятую
		/// </summary>
		[Description("Фильтр-поле: Список ID владельцев (Frames.OwnerID), через запятую")]
		public string FilterOwnersList { get { return _FilterOwnersList; } set { _FilterOwnersList = value; _NeedRequery = true; } }

		protected string _FilterGoodsStatesList;
		/// <summary>
		/// Фильтр-поле: Список ID состояний товаров (Frames.GoodStateID), через запятую
		/// </summary>
		[Description("Фильтр-поле: Список ID состояний товаров (Frames.GoodStateID), через запятую")]
		public string FilterGoodsStatesList { get { return _FilterGoodsStatesList; } set { _FilterGoodsStatesList = value; _NeedRequery = true; } }
		
		protected string _FilterFramesStatesStr;
		/// <summary>
		/// Фильтр-поле: Список статусов контейнеров (Frames.State), без разделителя
		/// </summary>
		[Description("Фильтр-поле: Список статусов контейнеров (Frames.State), без разделителя")]
		public string FilterFramesStatesStr { get { return _FilterFramesStatesStr; } set { _FilterFramesStatesStr = value; _NeedRequery = true; } }

        protected int? _FilterInputID;
        /// <summary>
        /// Фильтр-поле: ID прихода, в котором был получен данный контейнер
        /// </summary>
        [Description("Фильтр-поле: ID прихода, в котором был получен данный контейнер")]
        public int? FilterInputID { get { return _FilterInputID; } set { _FilterInputID = value; } }

		protected DataTable _TableFramesContents;
		/// <summary>
		/// таблица содержимого контейнеров (TableFramesContents)
		/// </summary>
		[Description("Таблица содержимого контейнеров (TableFramesContents)")]
		public DataTable TableFramesContents { get { return _TableFramesContents; } }

		protected int? _FrameContentID;
		/// <summary>
		/// Фильтр-поле таблицы содержимого контейнеров: ID записи Содержимое контейнера (CellsContents.ID)
		/// </summary>
		[Description("Фильтр-поле таблицы содержимого контейнеров: ID записи Содержимое контейнера (CellsContents.ID)")]
		public int? FrameContentID { get { return _FrameContentID; } set { _FrameContentID = value; _NeedRequery = true; } }

		// фильтры по содержимому

		protected string _FramesContents_FilterPackingsList;
		/// <summary>
		/// Фильтр-поле таблицы содержимого контейнеров: Список ID упаковок (CellsContents.PackingID), через запятую
		/// </summary>
		[Description("Фильтр-поле таблицы содержимого контейнеров: Список ID упаковок (CellsContents.PackingID), через запятую")]
		public string FramesContents_FilterPackingsList { get { return _FramesContents_FilterPackingsList; } set { _FramesContents_FilterPackingsList = value; _FramesContents_NeedRequery = true; } }

		protected string _FramesContents_FilterGoodsList;
		/// <summary>
		/// Фильтр-поле таблицы содержимого контейнеров: Список ID товаров (CellsContents.PackingID -> Packings.GoodID), через запятую
		/// </summary>
		[Description("Фильтр-поле таблицы содержимого контейнеров: Список ID товаров (CellsContents.PackingID - >Packings.GoodID), через запятую")]
		public string FramesContents_FilterGoodsList { get { return _FramesContents_FilterGoodsList; } set { _FramesContents_FilterGoodsList = value; _FramesContents_NeedRequery = true; } }

		protected DateTime? _FramesContents_FilterDateValidLess;
		/// <summary>
		/// Фильтр-поле таблицы содержимого контейнеров: Срок годности (дата) (CellsContents.DateValid), не более
		/// </summary>
		[Description("Фильтр-поле таблицы содержимого контейнеров: Срок годности (дата) (CellsContents.DateValid), не более")]
		public DateTime? FramesContents_FilterDateValidLess { get { return _FramesContents_FilterDateValidLess; } set { _FramesContents_FilterDateValidLess = value; _FramesContents_NeedRequery = true; } }

		protected string _FramesContents_FilterCellsList;
		/// <summary>
		/// Фильтр-поле таблицы содержимого контейнеров: Список ID ячеек (CellsContents.CellID), через запятую
		/// </summary>
		[Description("Фильтр-поле таблицы содержимого контейнеров: Список ID ячеек (CellsContents.CellID), через запятую")]
		public string FramesContents_FilterCellsList { get { return _FramesContents_FilterCellsList; } set { _FramesContents_FilterCellsList = value; _FramesContents_NeedRequery = true; } }

		// фильтры по геометрии

		protected Decimal? _FilterHeightBeg;
		/// <summary>
		/// Фильтр-поле: высота контейнера (м) (Frames.Height), от
		/// </summary>
		[Description("Фильтр-поле: высота контейнера (м) (Frames.Height), от")]
		public Decimal? FilterHeightBeg { get { return _FilterHeightBeg; } set { _FilterHeightBeg = value; _NeedRequery = true; } }

		protected Decimal? _FilterHeightEnd;
		/// <summary>
		/// Фильтр-поле: высота контейнера (м) (Frames.Height), до
		/// </summary>
		[Description("Фильтр-поле: высота контейнера (м) (Frames.Height), до")]
		public Decimal? FilterHeightEnd { get { return _FilterHeightEnd; } set { _FilterHeightEnd = value; _NeedRequery = true; } }

		protected Decimal? _FilterWeightBeg;
		/// <summary>
		/// Фильтр-поле: вес контейнера (кг) (.dbo.GetFrameWeight(Frames.ID)), от
		/// </summary>
		[Description("Фильтр-поле: вес контейнера (кг) (.dbo.GetFrameWeight(Frames.ID)), от")]
		public Decimal? FilterWeightBeg { get { return _FilterWeightBeg; } set { _FilterWeightBeg = value; _NeedRequery = true; } }

		protected Decimal? _FilterWeightEnd;
		/// <summary>
		/// Фильтр-поле: вес контейнера (кг) (.dbo.GetFrameWeight(Frames.ID)), до
		/// </summary>
		[Description("Фильтр-поле: вес контейнера (кг) (.dbo.GetFrameWeight(Frames.ID)), до")]
		public Decimal? FilterWeightEnd { get { return _FilterWeightEnd; } set { _FilterWeightEnd = value; _NeedRequery = true; } }

		protected string _FilterPalletsTypesList;
		/// <summary>
		/// Фильтр-поле: Список ID типов паллет (Cells.PalletTypeID), через запятую
		/// </summary>
		[Description("Фильтр-поле: Список ID типов паллет (Cells.PalletTypeID), через запятую")]
		public string FilterPalletsTypesList { get { return _FilterPalletsTypesList; } set { _FilterPalletsTypesList = value; _NeedRequery = true; } }

		// фильтр по дате последней операции

		protected DateTime? _FilterDateLastOperationBeg;
		/// <summary>
		/// Фильтр-поле: Дата последней операции с контейнером: начальная дата периода (Frames.DateLastOperation)
		/// </summary>
		[Description("Фильтр-поле: Дата последней операции с контейнером: начальная дата периода (Frames.DateLastOperation)")]
		public DateTime? FilterDateLastOperationBeg { get { return _FilterDateLastOperationBeg; } set { _FilterDateLastOperationBeg = value; _NeedRequery = true; } }

		protected DateTime? _FilterDateLastOperationEnd;
		/// <summary>
		/// Фильтр-поле: Дата последней операции с контенйером: конечная дата периода (Frames.DateLastOperation)
		/// </summary>
		[Description("Фильтр-поле: Дата последней операции с контенйером: конечная дата периода (Frames.DateLastOperation)")]
		public DateTime? FilterDateLastOperationEnd { get { return _FilterDateLastOperationEnd; } set { _FilterDateLastOperationEnd = value; _NeedRequery = true; } }

		
		
		protected bool? _FramesContents_NeedRequery;
		/// <summary>
		/// Для таблицы содержимого контейнеров: необходимо обновление таблицы?
		/// </summary>
		[Description("Для таблицы содержимого контейнеров: необходимо обновление таблицы?")]
		public bool? FramesContents_NeedRequery { get { return _FramesContents_NeedRequery; } set { _FramesContents_NeedRequery = value; } }

		// для истории --------------------------------------------------------

		protected DataTable _TableFramesHistory;
		/// <summary>
		/// Таблица истории контейнеров (FramesHistory)
		/// </summary>
		[Description("Таблица истории контейнеров (FramesHistory)")]
		public DataTable TableFramesHistory { get { return _TableFramesHistory; } }

		/// Для таблицы истории контейнеров: необходимо обновление таблицы?
		protected bool? _FramesHistory_NeedRequery;

		protected DateTime? _FramesHistory_FilterDataBeg;
		/// <summary>
		/// Фильтр-поле: Начальная дата периода
		/// </summary>
		[Description("Фильтр-поле: Начальная дата периода")]
		public DateTime? FramesHistory_FilterDateBeg { get { return _FramesHistory_FilterDataBeg; } set { _FramesHistory_FilterDataBeg = value; _FramesHistory_NeedRequery = true; } }

		protected DateTime? _FramesHistory_FilterDataEnd;
		/// <summary>
		/// Фильтр-поле: Конечная дата периода 
		/// </summary>
		[Description("Фильтр-поле: Конечная дата периода")]
		public DateTime? FramesHistory_FilterDateEnd { get { return _FramesHistory_FilterDataEnd; } set { _FramesHistory_FilterDataEnd = value; _FramesHistory_NeedRequery = true; } }

		/// <summary>
		/// Фильтр-поле: Только исправление ошибок (CellsChanges))?
		/// </summary>
		protected bool? _FramesHistory_FilterCellsChanges;
		[Description("Фильтр-поле: исправление ошибок (CellsChanges)?")]
		public bool? FramesHistory_FilterCellsChanges { get { return _FramesHistory_FilterCellsChanges; } set { _FramesHistory_FilterCellsChanges = value; _FramesHistory_NeedRequery = true; } }

		// -------------------

		public Frame() : base()
		{
			_MainTableName = "Frames";
			_ColumnID = "ID";
			_ColumnName = "BarCode";
		}

		/// <summary>
		/// получение полного списка контейнеров
		/// </summary>
		public override bool FillData()
		{
			ClearData();

			string sqlSelect = "execute up_FramesFill @nID, @cIDList, " +
									"@cBarCode, @bActual, @bLocked, @bHasFrameContent, @bStereo, " + 
									"@cOwnersList, @cGoodsStatesList, @cFramesStatesStr, " + 
									"@cPackingsList, @cGoodsList, " + 
									"@dDateValidLess, " + 
									"@cCellsList, " + 
									"@nHeightBeg, @nHeightEnd, " + 
									"@nWeightBeg, @nWeightEnd, " + 
									"@cPalletsTypesList, " + 
									"@dDateLastOperationBeg, @dDateLastOperationEnd, " + 
                                    "@nInputID";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_FramesFill parameters 
			
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
			if (BarCode != null)
				_oCommand.Parameters["@cBarCode"].Value = BarCode;
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

			_oCommand.Parameters.Add("@bHasFrameContent", SqlDbType.Bit);
			if (_FilterHasFrameContent.HasValue)
				_oCommand.Parameters["@bHasFrameContent"].Value = _FilterHasFrameContent;
			else
				_oCommand.Parameters["@bHasFrameContent"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bStereo", SqlDbType.Bit);
			if (_FilterStereo.HasValue)
				_oCommand.Parameters["@bStereo"].Value = _FilterStereo;
			else
				_oCommand.Parameters["@bStereo"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cOwnersList", SqlDbType.VarChar);
			if (_FilterOwnersList != null)
				_oCommand.Parameters["@cOwnersList"].Value = _FilterOwnersList;
			else
				_oCommand.Parameters["@cOwnersList"].Value = DBNull.Value;
			
			_oCommand.Parameters.Add("@cGoodsStatesList", SqlDbType.VarChar);
			if (_FilterGoodsStatesList != null)
				_oCommand.Parameters["@cGoodsStatesList"].Value = _FilterGoodsStatesList;
			else
				_oCommand.Parameters["@cGoodsStatesList"].Value = DBNull.Value;
			
			_oCommand.Parameters.Add("@cFramesStatesStr", SqlDbType.VarChar);
			if (_FilterFramesStatesStr != null)
				_oCommand.Parameters["@cFramesStatesStr"].Value = _FilterFramesStatesStr;
			else
				_oCommand.Parameters["@cFramesStatesStr"].Value = DBNull.Value;

			#region up_FramesFill FramesContents-parameters

			//поля для поиска через Содержимое контейнеров (FramesContents)

			_oCommand.Parameters.Add("@cPackingsList", SqlDbType.VarChar);
			if (_FramesContents_FilterPackingsList != null)
				_oCommand.Parameters["@cPackingsList"].Value = _FramesContents_FilterPackingsList;
			else
				_oCommand.Parameters["@cPackingsList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cGoodsList", SqlDbType.VarChar);
			if (_FramesContents_FilterGoodsList != null)
				_oCommand.Parameters["@cGoodsList"].Value = _FramesContents_FilterGoodsList;
			else
				_oCommand.Parameters["@cGoodsList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@dDateValidLess", SqlDbType.SmallDateTime);
			if (_FramesContents_FilterDateValidLess != null)
				_oCommand.Parameters["@dDateValidLess"].Value = _FramesContents_FilterDateValidLess;
			else
				_oCommand.Parameters["@dDateValidLess"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cCellsList", SqlDbType.VarChar);
			if (_FramesContents_FilterCellsList != null)
				_oCommand.Parameters["@cCellsList"].Value = _FramesContents_FilterCellsList;
			else
				_oCommand.Parameters["@cCellsList"].Value = DBNull.Value;

			#endregion

			#region up_FramesFill Geometry-parameters

			//поля для поиска по геометрии контейнера

			_oCommand.Parameters.Add("@nHeightBeg", SqlDbType.Decimal);
			_oCommand.Parameters["@nHeightBeg"].Precision = 10;
			_oCommand.Parameters["@nHeightBeg"].Scale = 3;
			if (_FilterHeightBeg.HasValue)
				_oCommand.Parameters["@nHeightBeg"].Value = _FilterHeightBeg;
			else
				_oCommand.Parameters["@nHeightBeg"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@nHeightEnd", SqlDbType.Decimal);
			_oCommand.Parameters["@nHeightEnd"].Precision = 10;
			_oCommand.Parameters["@nHeightEnd"].Scale = 3;
			if (_FilterHeightEnd.HasValue)
				_oCommand.Parameters["@nHeightEnd"].Value = _FilterHeightEnd;
			else
				_oCommand.Parameters["@nHeightEnd"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@nWeightBeg", SqlDbType.Decimal);
			_oCommand.Parameters["@nWeightBeg"].Precision = 10;
			_oCommand.Parameters["@nWeightBeg"].Scale = 3;
			if (_FilterWeightBeg.HasValue)
				_oCommand.Parameters["@nWeightBeg"].Value = _FilterWeightBeg;
			else
				_oCommand.Parameters["@nWeightBeg"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@nWeightEnd", SqlDbType.Decimal);
			_oCommand.Parameters["@nWeightEnd"].Precision = 10;
			_oCommand.Parameters["@nWeightEnd"].Scale = 3;
			if (_FilterWeightEnd.HasValue)
				_oCommand.Parameters["@nWeightEnd"].Value = _FilterWeightEnd;
			else
				_oCommand.Parameters["@nWeightEnd"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cPalletsTypesList", SqlDbType.VarChar);
			if (_FilterPalletsTypesList != null)
				_oCommand.Parameters["@cPalletsTypesList"].Value = _FilterPalletsTypesList;
			else
				_oCommand.Parameters["@cPalletsTypesList"].Value = DBNull.Value;

			#endregion 

			_oCommand.Parameters.Add("@dDateLastOperationBeg", SqlDbType.SmallDateTime);
			if (_FilterDateLastOperationBeg.HasValue)
				_oCommand.Parameters["@dDateLastOperationBeg"].Value = _FilterDateLastOperationBeg;
			else
				_oCommand.Parameters["@dDateLastOperationBeg"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@dDateLastOperationEnd", SqlDbType.SmallDateTime);
			if (_FilterDateLastOperationEnd.HasValue)
				_oCommand.Parameters["@dDateLastOperationEnd"].Value = _FilterDateLastOperationEnd;
			else
				_oCommand.Parameters["@dDateLastOperationEnd"].Value = DBNull.Value;

            _oCommand.Parameters.Add("@nInputID", SqlDbType.Int);
            if (_FilterInputID.HasValue)
                _oCommand.Parameters["@nInputID"].Value = _FilterInputID;
            else
                _oCommand.Parameters["@nInputID"].Value = DBNull.Value;
            #endregion

			try
			{
				_MainTable = FillReadings(new SqlDataAdapter(_oCommand), _MainTable, _MainTableName);
				_NeedRequery = false;

				// primarykey
				DataColumn[] pk = new DataColumn[1];
				pk[0] = _MainTable.Columns[_ColumnID];
				_MainTable.PrimaryKey = pk;
			}
			catch (Exception ex)
			{
				_ErrorNumber = -1;
				_ErrorStr = "Ошибка при получении общего списка контейнеров...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}


		/// <summary>
		/// очистка фильтр-полей
		/// </summary>
		public void ClearFilters()
		{
			_BarCode = null;
			_FilterActual = null;
			_FilterLocked = null;
			_FilterFramesStatesStr = null;
			_FilterGoodsStatesList = null;
			_FilterOwnersList = null;
			_FilterStereo = null;
			_FilterHasFrameContent = null;

			_FilterHeightBeg = null;
			_FilterHeightEnd = null;
			_FilterWeightBeg = null;
			_FilterWeightEnd = null;
			_FilterPalletsTypesList = null;

			_FilterDateLastOperationBeg = null;
			_FilterDateLastOperationEnd = null;
			//_NeedRequery = true;
		}


		/// <summary>
		/// добавление контейнера в существующую таблицу (MainTable)
		/// </summary>
		public bool AddMainTable(int nFrameID)
		{
			string sqlSelect = "execute up_FramesFill @nID";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_FramesFill paramaters

			_oCommand.Parameters.Add("@nID", SqlDbType.Int);
			_oCommand.Parameters["@nID"].Value = nFrameID;
			
			#endregion

			try
			{
				SqlDataAdapter adapter = new SqlDataAdapter(_oCommand);
				adapter.Fill(_DS, _MainTableName);
				_MainTable = _DS.Tables[_MainTableName];
			}
			catch (Exception ex)
			{
				_ErrorNumber = -13;
				_ErrorStr = "Ошибка при добавлении контейнера к списку контейнеров...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		
		/// <summary>
		/// получение таблицы содержимого контейнеров (TablesFramesContents)
		/// </summary>
		public bool FillTableFramesContents(int? nFrameID)
		{
			string sqlSelect = "execute up_FramesContentsFill " +
									"@nFrameID, " +
									"@cPackingsList, @cGoodsList, " +
									"@dDateValidLess";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_FramesContentsFill parameters using

			_oCommand.Parameters.Add("@nFrameID", SqlDbType.Int);
			if (nFrameID.HasValue)
				_oCommand.Parameters["@nFrameID"].Value = nFrameID;
			else
				_oCommand.Parameters["@nFrameID"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cPackingsList", SqlDbType.VarChar);
			if (_FramesContents_FilterPackingsList != null)
				_oCommand.Parameters["@cPackingsList"].Value = _FramesContents_FilterPackingsList;
			else
				_oCommand.Parameters["@cPackingsList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cGoodsList", SqlDbType.VarChar);
			if (_FramesContents_FilterGoodsList != null)
				_oCommand.Parameters["@cGoodsList"].Value = _FramesContents_FilterGoodsList ;
			else
				_oCommand.Parameters["@cGoodsList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@dDateValidLess", SqlDbType.DateTime);
			if (_FramesContents_FilterDateValidLess != null)
				_oCommand.Parameters["@dDateValidLess"].Value = _FramesContents_FilterDateValidLess ;
			else
				_oCommand.Parameters["@dDateValidLess"].Value = DBNull.Value;

			#endregion

			try
			{
				_TableFramesContents = FillReadings(new SqlDataAdapter(_oCommand), _TableFramesContents, "TableFramesContents");
				_FramesContents_NeedRequery = false;
			}
			catch (Exception ex)
			{
				_ErrorNumber = -11;
				_ErrorStr = "Ошибка при получении содержимого контейнеров...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// очистка фильтр-полей таблицы содержимого контейнеров (TableFramesContents)
		/// </summary>
		public void ClearFramesContentsFilters()
		{
			_FramesContents_FilterGoodsList = null;
			_FramesContents_FilterPackingsList = null;
			_FramesContents_FilterDateValidLess = null;
			_FramesContents_FilterCellsList = null;
			//_FramesContents_NeedRequery = true;
		}

	#region History 
	
		// ------------------------------------------------------------------------------
		// история контейнеров (ячеек)
		// ------------------------------------------------------------------------------

		/// <summary>
		/// получение таблицы истории изменения состояния контейнеров (TablesFramesHistory)
		/// </summary>
		public bool FillTableFramesHistory(int? nFrameID)
		{

			ClearTableFramesHistory();

			string sqlSelect = "execute up_FramesHistoryFill @nFrameID, @cFramesIDList, " +
									"@dDateBeg, @dDateEnd, " +
									"@bCellsChangesOnly";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);
			_oCommand.CommandTimeout = 0;

			#region up_FramesHistoryFill paramaters

			_oCommand.Parameters.Add("@nFrameID", SqlDbType.Int);
			if (nFrameID.HasValue)
				_oCommand.Parameters["@nFrameID"].Value = nFrameID;
			else
				_oCommand.Parameters["@nFrameID"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cFramesIDList", SqlDbType.VarChar);
			if (IDList != null)
				_oCommand.Parameters["@cFramesIDList"].Value = IDList;
			else
				_oCommand.Parameters["@cFramesIDList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@dDateBeg", SqlDbType.SmallDateTime);
			if (_FramesHistory_FilterDataBeg.HasValue)
				_oCommand.Parameters["@dDateBeg"].Value = _FramesHistory_FilterDataBeg;
			else
				_oCommand.Parameters["@dDateBeg"].Value = DBNull.Value;
			_oCommand.Parameters.Add("@dDateEnd", SqlDbType.SmallDateTime);
			if (_FramesHistory_FilterDataEnd.HasValue)
				_oCommand.Parameters["@dDateEnd"].Value = _FramesHistory_FilterDataEnd;
			else
				_oCommand.Parameters["@dDateEnd"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bCellsChangesOnly", SqlDbType.Bit);
			if (_FramesHistory_FilterCellsChanges.HasValue)
				_oCommand.Parameters["@bCellsChangesOnly"].Value = _FramesHistory_FilterCellsChanges;
			else
				_oCommand.Parameters["@bCellsChangesOnly"].Value = DBNull.Value;

			#endregion

			try
			{
				SqlDataAdapter adapter = new SqlDataAdapter(_oCommand);
				adapter.Fill(_DS, "TableFramesHistory");
				_TableFramesHistory = _DS.Tables["TableFramesHistory"];
				_FramesHistory_NeedRequery = false;
			}
			catch (Exception ex)
			{
				_ErrorNumber = -12;
				_ErrorStr = "Ошибка при получении истории контейнеров...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// очистка таблицы истории контейнеров (TableFramesHistory)
		/// </summary>
		public void ClearTableFramesHistory()
		{
			if (_DS.Tables["TableFramesHistory"] != null)
				_DS.Tables.Remove("TableFramesHistory");
			_TableFramesHistory = null;
		}

		/// <summary>
		/// очистка фильтр-полей таблицы истории контейнеров (TableFramesHistory)
		/// </summary>
		public void ClearFramesHistoryFilters()
		{
			_FramesHistory_FilterDataBeg = null;
			_FramesHistory_FilterDataEnd = null;
			_FramesHistory_FilterCellsChanges = null;
			//_FramesHistory_NeedRequery = true; 
		}

	#endregion 


		// обработка контейнеров --------------------------------------------------------

		/// <summary>
		/// добавление новых контейнеров в таблицу БД, по окончании MainTable состоит из добавленных контейнеров
		/// </summary>
		public bool AddFramesEmpty(int nCnt)
		{
			ClearData();

			int nCntOk = 0;

			string sqlSelect = "insert Frames (OwnerID, GoodStateID, DateBirth, DateLastOperation, State, Actual) " + 
					"values (Null, Null, GetDate(), Null, ' ', 1) " +
					"select @@identity as _NewID";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);
			for (int i = 1; i <= nCnt; i++)
			{
				try
				{
					//FillReadings(new SqlDataAdapter(_oCommand), null, "TableNewFrames");
					SqlDataAdapter adapter = new SqlDataAdapter(_oCommand);
					adapter.Fill(_DS, "TableNewFrames");
					AddMainTable(Convert.ToInt32(_DS.Tables["TableNewFrames"].Rows[nCntOk]["_NewID"])); 
					nCntOk++;
				}
				catch (Exception ex)
				{
					_ErrorNumber = -13;
					_ErrorStr = "Ошибка при добавлении контейнера к списку контейнеров...\r\n" + ex.Message;
					RFMMessage.MessageBoxError(_ErrorStr);
					break;  
				}
			}

			RFMMessage.MessageBoxInfo("Создано новых контейнеров: " + nCntOk.ToString());

			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// размещение: подбор ячейки и создание транспортировки для перемещения в эту ячейку
		/// </summary>
		public bool Arrange(int nFrameID)
		{
			string sqlSelect = "execute up_FramesArrange " +
									"@nFrameID, @nCellID output, " +
									"@nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_FramesArrange paramaters

			_oCommand.Parameters.Add("@nFrameID", SqlDbType.Int);
			_oCommand.Parameters["@nFrameID"].Value = nFrameID;

			_oCommand.Parameters.Add("@nCellID", SqlDbType.Int);
			_oCommand.Parameters["@nCellID"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@nCellID"].Value = DBNull.Value;

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
				_ErrorStr = "Ошибка при попытке размещения контейнера...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
			if (_ErrorNumber != 0)
			{
				_ErrorStr = "Ошибка при размещении контейнера...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			else
			{
				if (_oCommand.Parameters["@nCellID"].Value == DBNull.Value)
				{
					_ErrorNumber = -11;
					_ErrorStr = "Ошибка при размещении контейнера...\r\n" + 
						"Ячейка не подобрана...";
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		public bool Medication(int nFrameID, DataTable tFrameContents, 
			int? nOwnerID, int? nGoodStateID, 
			int nCellID, 
			int? nUserID, int? nDeviceID, 
			string sNoteManual)
		{
			// создание и наполнение временной таблицы 
			try
			{
				_Connect.Open();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -1;
				_ErrorStr = "Ошибка при соединении с сервером...\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
				return (false);
			}

			if (!RFMUtilities.DataTableToTempTable(tFrameContents, "#CellsContents", _Connect))
			{
				RFMMessage.MessageBoxError("Ошибка при подготовке временной таблицы...");
				return (false);
			}


			// выполняем хр_пр изменения состояния контейнера 
			string sqlSelect = "execute up_FramesMedication @nFrameID, " +
									"@nOwnerID, @nGoodStateID, " + 
									"@nCellID, " + 
									"@nUserID, @nDeviceID, " +
									"@cNoteManual, " + 
									"@nError output, @cErrorStr output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_FramesMedication paramaters

			_oCommand.Parameters.Add("@nFrameID", SqlDbType.Int);
			_oCommand.Parameters["@nFrameID"].Value = nFrameID;

			_oCommand.Parameters.Add("@nOwnerID", SqlDbType.Int);
			if (nOwnerID.HasValue)
				_oCommand.Parameters["@nOwnerID"].Value = nOwnerID;
			else
				_oCommand.Parameters["@nOwnerID"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@nGoodStateID", SqlDbType.Int);
			if (nGoodStateID.HasValue)
				_oCommand.Parameters["@nGoodStateID"].Value = nGoodStateID;
			else
				_oCommand.Parameters["@nGoodStateID"].Value = DBNull.Value;

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
				_ErrorStr = "Ошибка при изменении состояния контейнера с кодом " + nFrameID.ToString() + "...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr); // RaiseError
			}
			finally
			{
				_Connect.Close();
			}
			_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
			if (_ErrorNumber != 0)
			{
				_ErrorStr = "Ошибка при изменении состояния контейнера с кодом " + nFrameID.ToString() + "...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}


		/// <summary>
		/// сохранение параметров (геометрия) контейнера
		/// </summary>
		public bool GeometrySave(int? nFrameID,
				bool? bPalletTypeIDUpdate, bool? bFrameHeightUpdate)
		{
			// запись в MainTable, соответствующая nFrameID (обычно 0)
			DataRow r = MainTable.Rows.Find(nFrameID);
			if (r == null)
			{
				RFMMessage.MessageBoxError("Не найдена запись с кодом " + nFrameID.ToString() + " в таблице конейтнеров...");
				return (false);
			}

			string sqlSelect = "execute up_FramesGeometrySave @nFrameID, " +
									"@nPalletTypeID, @bPalletTypeIDUpdate, " +
									"@nFrameHeight, @bFrameHeightUpdate, " +
									"@nError output, @cErrorStr output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_FramesGeometrySave paramaters

			_oCommand.Parameters.Add("@nFrameID", SqlDbType.Int);
			if (nFrameID.HasValue)
				_oCommand.Parameters["@nFrameID"].Value = nFrameID;
			else
				_oCommand.Parameters["@nFrameID"].Value = DBNull.Value;

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

			_oCommand.Parameters.Add("@nFrameHeight", SqlDbType.Decimal);
			_oCommand.Parameters["@nFrameHeight"].Precision = 10;
			_oCommand.Parameters["@nFrameHeight"].Scale = 3;
			if (r["FrameHeight"] != null)
				_oCommand.Parameters["@nFrameHeight"].Value = r["FrameHeight"];
			else
				_oCommand.Parameters["@nFrameHeight"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bFrameHeightUpdate", SqlDbType.Bit);
			if (bFrameHeightUpdate.HasValue)
				_oCommand.Parameters["@bFrameHeightUpdate"].Value = bFrameHeightUpdate;
			else
				_oCommand.Parameters["@bFrameHeightUpdate"].Value = DBNull.Value;

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
				_ErrorStr = "Ошибка при сохранении параметров контейнера (геометрия)...\r\n" + ex.Message;
				//WMSMessage.MessageBoxError(_ErrorStr); // RaisError
			}
			finally
			{
				_Connect.Close();
			}
			_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
			if (_ErrorNumber != 0)
			{
				_ErrorStr = "Ошибка при сохранении параметров контейнера (геометрия)...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// блокировка/разблокировка контейнера
		/// </summary>
		public bool SetLock(int? nFrameID, bool bLock)
		{
			string sqlSelect = "update Frames set Locked = " + (bLock ? "1" : "0") +
				"where ID = " + nFrameID.ToString();
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);
			try
			{
				_Connect.Open();
				_oCommand.ExecuteScalar();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -21;
				_ErrorStr = "Ошибка при " + (bLock ? "" : "раз") + "блокировании контейнера...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// удаление контейнера
		/// </summary>
		public bool DeleteOne(int? nFrameID)
		{
			string sqlSelect = "execute up_FramesDelete @nFrameID, " +
									"@nError output, @cErrorStr output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_FramesDelete paramaters

			_oCommand.Parameters.Add("@nFrameID", SqlDbType.Int);
			if (nFrameID.HasValue)
				_oCommand.Parameters["@nFrameID"].Value = nFrameID;
			else
				_oCommand.Parameters["@nFrameID"].Value = DBNull.Value;

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
				_ErrorStr = "Ошибка при удалении контейнера...\r\n" + ex.Message;
				//WMSMessage.MessageBoxError(_ErrorStr); // RaisError
			}
			finally
			{
				_Connect.Close();
			}
			_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
			if (_ErrorNumber != 0)
			{
				_ErrorStr = "Ошибка при удалении контейнера...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

	}
}