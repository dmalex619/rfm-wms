using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

using RFMPublic;

/// <summary>
/// Бизнес-объект Расход (Output)
/// </summary>
namespace WMSBizObjects
{
	public class Output : BizObject
	{
		protected string _IDList;
		/// <summary>
		/// Список ID расходов (Outputs.ID)
		/// </summary>
		[Description("Список ID расходов (Outputs.ID)")]
		public string IDList { get { return _IDList; } set { _IDList = value; _NeedRequery = true; } }

		protected string _BarCode;
		/// <summary>
		/// Штрих-код документа-расхода (Outputs.BarCode), контекст
		/// </summary>
		[Description("Штрих-код документа-расхода (Outputs.BarCode), контекст")]
		public string BarCode { get { return _BarCode; } set { _BarCode = value; _NeedRequery = true; } }

		// Фильтры
		#region Filters

		protected string _FilterHostsList;
		/// <summary>
		/// Фильтр-поле: список кодов host-ов (Outputs.HostID)
		/// </summary>
		[Description("Фильтр-поле: список кодов host-ов (Outputs.HostID)")]
		public string FilterHostsList { get { return _FilterHostsList; } set { _FilterHostsList = value; _NeedRequery = true; } }

		protected DateTime? _FilterDateBeg;
		/// <summary>
		/// Фильтр-поле: Начальная дата периода (Outputs.DateOutput)
		/// </summary>
		[Description("Фильтр-поле: Начальная дата периода (Outputs.DateOutput)")]
		public DateTime? FilterDateBeg { get { return _FilterDateBeg; } set { _FilterDateBeg = value; } }

		protected DateTime? _FilterDateEnd;
		/// <summary>
		/// Фильтр-поле: Конечная дата периода
		/// </summary>
		[Description("Фильтр-поле: Конечная дата периода (Outputs.DateOutput)")]
		public DateTime? FilterDateEnd { get { return _FilterDateEnd; } set { _FilterDateEnd = value; } }

		protected DateTime? _FilterDateBegConfirm;
		/// <summary>
		/// Фильтр-поле: Дата подтверждения: начальная дата периода (Outputs.DateConfirm)
		/// </summary>
		[Description("Фильтр-поле: Дата подтверждения: начальная дата периода (Outputs.DateConfirm)")]
		public DateTime? FilterDateBegConfirm { get { return _FilterDateBegConfirm; } set { _FilterDateBegConfirm = value; _NeedRequery = true; } }

		protected DateTime? _FilterDateEndConfirm;
		/// <summary>
		/// Фильтр-поле: Дата подтверждения: конечная дата периода (Outputs.DateConfirm)
		/// </summary>
		[Description("Фильтр-поле: Дата подтверждения: конечная дата периода (Outputs.DateConfirm)")]
		public DateTime? FilterDateEndConfirm { get { return _FilterDateEndConfirm; } set { _FilterDateEndConfirm = value; _NeedRequery = true; } }

		protected string _FilterOutputsTypesList;
		/// <summary>
		/// Фильтр-поле: Список типов расхода (Outputs.OutputTypeID), через запятую
		/// </summary>
		[Description("Фильтр-поле: Список типов расхода (Outputs.OutputTypeID), через запятую")]
		public string FilterOutputsTypesList { get { return _FilterOutputsTypesList; } set { _FilterOutputsTypesList = value; } }

		protected string _FilterPartnersList;
		/// <summary>
		/// Фильтр-поле: список получателей (Outputs.PartnerID), через запятую
		/// </summary>
		[Description("Фильтр-поле: список получателей (Outputs.PartnerID), через запятую")]
		public string FilterPartnersList { get { return _FilterPartnersList; } set { _FilterPartnersList = value; } }

		protected string _FilterPartnerContext;
		/// <summary>
		/// Фильтр-поле: название получателя (Outputs.PartnerID -> Partners.Name), контекст
		/// </summary>
		[Description("Фильтр-поле: название получателя (Outputs.PartnerID -> Partners.Name), контекст")]
		public string FilterPartnerContext { get { return _FilterPartnerContext; } set { _FilterPartnerContext = value; } }

		protected string _FilterCarAliasContext;
		/// <summary>
		/// Фильтр-поле: название машины (Outputs.CarAlias), контекст
		/// </summary>
		[Description("Фильтр-поле: название машины (Outputs.CarAlias), контекст")]
		public string FilterCarAliasContext { get { return _FilterCarAliasContext; } set { _FilterCarAliasContext = value; } }

		protected string _FilterCarsAliasesList;
		/// <summary>
		/// Фильтр-поле: список названий машин (Outputs.CarAlias), через разделитель (_Settings.ssCarAliasDelimeter)
		/// </summary>
		[Description("Фильтр-поле: список названий машин (Outputs.CarAlias), через разделитель")]
		public string FilterCarsAliasesList { get { return _FilterCarsAliasesList; } set { _FilterCarsAliasesList = value; } }

		protected bool? _FilterBackDoor;
		/// <summary>
		/// Фильтр-поле: задняя дверь (Outputs.BackDoor)?
		/// </summary>
		[Description("Фильтр-поле: задняя дверь (Outputs.BackDoor)?")]
		public bool? FilterBackDoor { get { return _FilterBackDoor; } set { _FilterBackDoor = value; } }

		protected string _FilterGoodsStatesList;
		/// <summary>
		/// Фильтр-поле: список состояний товара (Outputs.GoodStateID), через запятую
		/// </summary>
		[Description("Фильтр-поле: список состояний товара товара (Outputs.GoodStateID), через запятую")]
		public string FilterGoodsStatesList { get { return _FilterGoodsStatesList; } set { _FilterGoodsStatesList = value; } }

		protected string _FilterOwnersList;
		/// <summary>
		/// Фильтр-поле: список владельцев товара (Outputs.OwnerID), через запятую
		/// </summary>
		[Description("Фильтр-поле: список владельцев товара (Outputs.OwnerID), через запятую")]
		public string FilterOwnersList { get { return _FilterOwnersList; } set { _FilterOwnersList = value; } }

		protected string _FilterPackingsList;
		/// <summary>
		/// Фильтр-поле: Список ID упаковок (OutputsGoods.PackingID), через запятую
		/// </summary>
		[Description("Фильтр-поле: Список ID упаковок (OutputsGoods.PackingID), через запятую")]
		public string FilterPackingsList { get { return _FilterPackingsList; } set { _FilterPackingsList = value; _NeedRequery = true; } }

		protected string _FilterGoodsList;
		/// <summary>
		/// Фильтр-поле: Список ID товаров (OutputsGoods.PackingID -> Packings.GoodID -> Goods.ID), через запятую
		/// </summary>
		[Description("Фильтр-поле: Список ID товаров (Outputs.PackingID -> Packings.GoodID -> Goods.ID), через запятую")]
		public string FilterGoodsList { get { return _FilterGoodsList; } set { _FilterGoodsList = value; _NeedRequery = true; } }

		protected bool? _FilterPicked;
		/// <summary>
		/// Фильтр-поле: расходы собраны (Outputs.DatePick)?
		/// </summary>
		[Description("Фильтр-поле: расходы собраны (Outputs.DatePick)?")]
		public bool? FilterPicked { get { return _FilterPicked; } set { _FilterPicked = value; } }

		protected bool? _FilterConfirmed;
		/// <summary>
		/// Фильтр-поле: расходы подтверждены (Outputs.DateConfirm)?
		/// </summary>
		[Description("Фильтр-поле: расходы подтверждены (Outputs.DateConfirm)?")]
		public bool? FilterConfirmed { get { return _FilterConfirmed; } set { _FilterConfirmed = value; } }

		protected int? _FilterOutputSelectedInfo;
		/// <summary>
		/// Фильтр-поле: Информация о подборе товаров (Outputs -> OutputsGoods.QntSelected)
		/// 0 ничего не подобрано, 1 не все подобрано, 2 все подобрано
		/// </summary>
		[Description("Фильтр-поле: Информация о подборе товаров (Outputs -> OutputsGoods.QntSelected)?")]
		public int? FilterOutputSelectedInfo { get { return _FilterOutputSelectedInfo; } set { _FilterOutputSelectedInfo = value; _NeedRequery = true; } }

		protected int? _FilterOutputTrafficsInfo;
		/// <summary>
		/// Фильтр-поле: Информация об операциях транспортировки контейнеров/перемещения коробок/штук (Outputs -> TrafficsFrames.OutputID, TrafficsGoods.OutputID)? 
		/// 0 все не выполнены, 1 некоторые не выполнены, 2 все выполнены
		/// </summary>
		[Description("Фильтр-поле: Информация об операциях транспортировки контейнеров/перемещения коробок/штук?")]
		public int? FilterOutputTrafficsInfo { get { return _FilterOutputTrafficsInfo; } set { _FilterOutputTrafficsInfo = value; _NeedRequery = true; } }

		protected bool? _FilterFullConfirmed;
		/// <summary>
		/// Фильтр-поле: расходы подтверждены полнлстью (OutputsGoods.QntConfirmed >= QntSelected)?
		/// </summary>
		[Description("Фильтр-поле: расходы подтверждены полнлстью (OutputsGoods.QntConfirmed >= QntSelected)?")]
		public bool? FilterFullConfirmed { get { return _FilterFullConfirmed; } set { _FilterFullConfirmed = value; } }

		#endregion Filters

		// Таблицы
		#region Tables

		protected DataTable _TableOutputsGoods;
		/// <summary>
		/// Список товаров в расходе (TableOutputsGoods)
		/// </summary>
		[Description("Список товаров в расходе (TableOutputsGoods)")]
		public DataTable TableOutputsGoods { get { return _TableOutputsGoods; } }

		protected DataTable _TableOutputsItems;
		/// <summary>
		/// Список составляющих расхода (TableOutputsItems)
		/// </summary>
		[Description("Список составляющих расхода (TableOutputsItems)")]
		public DataTable TableOutputsItems { get { return _TableOutputsItems; } }

		protected DataTable _TableOutputsPallets;
		/// <summary>
		/// Список паллет в расходе - для обработки 
		/// </summary>
		[Description("Список паллет в расходе - для обработки")]
		public DataTable TableOutputsPallets { get { return _TableOutputsPallets; } }

		protected DataTable _TableOutputsFrames;
		/// <summary>
		/// Список контейнеров в расходе
		/// </summary>
		[Description("Список контейнеров в расходе")]
		public DataTable TableOutputsFrames { get { return _TableOutputsFrames; } }

		protected DataTable _TableOutputsTrafficsFrames;
		/// <summary>
		/// Список операций по транспортировке контейнеров в расходе
		/// </summary>
		[Description("Список операций по транспортировке контейнеров в расходе")]
		public DataTable TableOutputsTrafficsFrames { get { return _TableOutputsTrafficsFrames; } }

		protected DataTable _TableOutputsTrafficsGoods;
		/// <summary>
		/// Список операций по перемещению коробок/штук в расходе
		/// </summary>
		[Description("Список операций по транспортировке контейнеров в расходе")]
		public DataTable TableOutputsTrafficsGoods { get { return _TableOutputsTrafficsGoods; } }

		protected DataTable _TableOutputsPickList;
		/// <summary>
		/// Список операций для формирования пик-листа в расходе
		/// </summary>
		[Description("Список операций для формирования пик-листа в расходе")]
		public DataTable TableOutputsPickList { get { return _TableOutputsPickList; } }

		protected DataTable _TableOutputsTypes;
		/// <summary>
		/// Таблица типов расходов
		/// </summary>
		[Description("Таблица типов расходов (TableOutputsTypes)")]
		public DataTable TableOutputsTypes { get { return _TableOutputsTypes; } }

		protected DataTable _TableOutputsCarsAliases;
		/// <summary>
		/// Таблица названий машин в расходах 
		/// </summary>
		[Description("Таблица названий машин в расходах (TableOutputsCarsAliases)")]
		public DataTable TableOutputsCarsAliases { get { return _TableOutputsCarsAliases; } }

		protected DataTable _TableOutputsLoaders;
		/// <summary>
		/// Таблица сотрудников, выполнявших загрузку товара в машины
		/// </summary>
		[Description("Таблица сотрудников, выполнявших загрузку товара в машины (TableOutputsLoaders)")]
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
		/// получение списка расходов (MainTable)
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

			//поля для поиска через Список товаров (OutputsGoods)

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
				_ErrorStr = "Ошибка при получении списка расходов..." + Convert.ToChar(13) + ex.Message;
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
		/// заполнение таблицы типов расходов (TableOutputsTypes)
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
				_ErrorStr = "Ошибка при получении списка типов расходов..." + Convert.ToChar(13) + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		#endregion OutputsTypes

		#region OutputsGoods

		/// <summary>
		/// заполнение таблицы товаров в расходе (TableOutputsGoods)
		/// </summary>
		public bool FillTableOutputsGoods(int? nOutputID)
		{
			if (!nOutputID.HasValue & !_ID.HasValue)
			{
				_ErrorNumber = -12;
				_ErrorStr = "Некорректный вызов:\r\nОшибка при получении списка товаров в расходе...";
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
				_ErrorStr = "Ошибка при получении списка товаров в расходе...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			if (_ErrorNumber == 0)
			{
				_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
				if (_ErrorNumber != 0)
				{
					_ErrorStr = "Ошибка при получении списка товаров в расходе...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// заполнение таблицы товаров в расходе для подтверждения! (TableOutputsGoods)
		/// </summary>
		public bool FillTableOutputsGoodsAnytime(int? nOutputID)
		{
			if (!nOutputID.HasValue & !_ID.HasValue)
			{
				_ErrorNumber = -12;
				_ErrorStr = "Некорректный вызов:\r\nОшибка при получении списка товаров в расходе...";
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
				_ErrorStr = "Ошибка при получении списка товаров в расходе...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			if (_ErrorNumber == 0)
			{
				_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
				if (_ErrorNumber != 0)
				{
					_ErrorStr = "Ошибка при получении списка товаров в расходе...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		#endregion OutputsGoods

		#region OutputsItems

		/// <summary>
		/// заполнение таблицы составляющих в расходе (TableOutputsItems)
		/// </summary>
		public bool FillTableOutputsItems(int? nOutputID)
		{
			if (!nOutputID.HasValue & !_ID.HasValue)
			{
				_ErrorNumber = -15;
				_ErrorStr = "Некорректный вызов:\r\nОшибка при получении списка составляющих в расходе...";
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
				_ErrorStr = "Ошибка при получении списка составляющих в расходе...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			if (_ErrorNumber == 0)
			{
				_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
				if (_ErrorNumber != 0)
				{
					_ErrorStr = "Ошибка при получении списка составляющих в расходе...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		#endregion OutputsItems

		#region OutputsPallets

		/// <summary>
		/// заполнение таблицы паллет в расходе (TableOutputsPallets)
		/// </summary>
		public bool FillTableOutputsPallets(int? nOutputID)
		{
			if (!nOutputID.HasValue & !_ID.HasValue)
			{
				_ErrorNumber = -14;
				_ErrorStr = "Некорректный вызов:\r\nОшибка при получении списка товаров в расходе...";
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
				_ErrorStr = "Ошибка при получении списка паллет в расходе...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			if (_ErrorNumber == 0)
			{
				_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
				if (_ErrorNumber != 0)
				{
					_ErrorStr = "Ошибка при получении списка паллет в расходе...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		#endregion OutputsPallets

		#region OutputsFrames

		/// <summary>
		/// заполнение таблицы контейнеров в расходе (TableOutputsFrames)
		/// </summary>
		public bool FillTableOutputsFrames(int? nOutputID)
		{
			if (!nOutputID.HasValue & !_ID.HasValue)
			{
				_ErrorNumber = -15;
				_ErrorStr = "Некорректный вызов:\r\nОшибка при получении списка контейнеров в расходе...";
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
				_ErrorStr = "Ошибка при получении списка контейнеров в расходе...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			if (_ErrorNumber == 0)
			{
				_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
				if (_ErrorNumber != 0)
				{
					_ErrorStr = "Ошибка при получении списка контейнеров в расходе...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		#endregion OutputsFrames

		#region OutputsPallets - по паллетам

		/// <summary>
		/// заполнение таблицы товаров в расходе - по паллетам!
		/// </summary>
		public bool FillTableOutputsPalletsEach(int? nOutputID, string sTableOutputsGoodsPallets)
		{
			if (!nOutputID.HasValue & !_ID.HasValue)
			{
				_ErrorNumber = -12;
				_ErrorStr = "Некорректный вызов:\r\nОшибка при получении списка товаров по паллетам в расходе...";
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
				_ErrorStr = "Ошибка при получении списка товаров по паллетам в расходе...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			if (_ErrorNumber == 0)
			{
				_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
				if (_ErrorNumber != 0)
				{
					_ErrorStr = "Ошибка при получении списка товаров по паллетам в расходе...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		#endregion OutputsPallets

		#region OutputsTraffics

		/// <summary>
		/// заполнение таблицы операций транспортировки/перемещений штук/коробок в расходе (TableOutputsTrafficsFrames, TableOutputsTrafficsGoods)
		/// </summary>
		public bool FillTableOutputsTraffics(int? nOutputID, bool bFrameMode)
		{
			string sText = (bFrameMode) ? "операций транспортировки контейнеров" : "операций перемещения коробок/штук";

			if (!nOutputID.HasValue & !_ID.HasValue)
			{
				_ErrorNumber = -21;
				_ErrorStr = "Некорректный вызов:\r\nОшибка при получении списка " + sText + " в расходе...";
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
				_ErrorStr = "Ошибка при получении списка " + sText + " в расходе...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// заполнение таблицы операций транспортировки для пик-листа
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
				_ErrorStr = "Ошибка при получении списка операций транспортировки контейнеров в расходах...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// заполнение таблицы для формирования пик-листа в расходе (TableOutputsPickList)
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
				_ErrorStr = "Ошибка при получении списка операций для формирования пик-листа в расходе...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		#endregion OutputsTraffics

		#region OutputsCarsAliases

		/// <summary>
		/// заполнение таблицы названий машин в расходах (TableOutputsCarsAliases)
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
				_ErrorStr = "Ошибка при получении списка машин в расходах..." + Convert.ToChar(13) + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		#endregion OutputsCarsAliases

		#region OutputsLoaders

		/// <summary>
		/// заполнение таблицы загрузчиков товара в машины (TableOutputsLoaders)
		/// </summary>
		public bool FillTableOutputsLoaders(int? nOutputID)
		{
			if (!nOutputID.HasValue & !_ID.HasValue)
			{
				_ErrorNumber = -16;
				_ErrorStr = "Некорректный вызов:\r\nОшибка при получении списка сотрудников, выполнявших загрузку товара для расхода...";
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
				_ErrorStr = "Ошибка при получении списка сотрудников, выполнявших загрузку товара для расхода...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			if (_ErrorNumber == 0)
			{
				_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
				if (_ErrorNumber != 0)
				{
					_ErrorStr = "Ошибка при получении списка сотрудников, выполнявших загрузку товара для расхода...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		#endregion OutputsLoaders

		/// <summary>
		/// получение списка ID по списку ERP-кодов 
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
				_ErrorStr = "Ошибка при получении списка кодов расходов..." + Convert.ToChar(13) + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (sIDList);
		}

		#region Save

		/// <summary>
		/// сохранение-подтверждение расхода
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
				_ErrorStr = "Нет данных для сохранения расхода...";
				RFMMessage.MessageBoxError(_ErrorStr);
				return (false);
			}

			DataRow r = _MainTable.Rows[0];

			// с использованием временных таблиц: "паллеты" и "тара"
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
				_ErrorStr = "Ошибка при сохранении расхода...\r\n" + ex.Message;
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
					_ErrorStr = "Ошибка при сохранении расхода...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
				// при создании нового расхода - получим его код
				if (nOutputID == 0 && _oCommand.Parameters["@nOutputID"].Value != DBNull.Value)
				{
					_ID = (int)_oCommand.Parameters["@nOutputID"].Value;
				}
			}
			return (_ErrorNumber == 0);
		}

		#endregion Save


		#region Select подбор

		/// <summary>
		/// подбор контейнеров и коробок/штук для расхода, создание перемещений
		/// </summary>
		public bool SelectData(int nOutputID, int? nOutputCellID)
		{
			string _sqlCommand = "execute up_OutputsSelect @nOutputID, @nOutputCellID, " +
									"@nError output, @cErrorStr output";
			SqlCommand _oCommand = new SqlCommand(_sqlCommand, _Connect);
			_oCommand.CommandTimeout = 0;

			// понадобится, если deadlock или другая ошибка - для снятия признака "в подборе"
			string _sqlUpdate = "update Outputs set IsSelecting = 0 where ID = " + @nOutputID.ToString().Trim();
			SqlCommand _osqlUpdate = new SqlCommand(_sqlUpdate, _Connect);

			int nAttenpts = 10; // число повторных попыток при ошибке 

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
						_ErrorStr = "Ошибка при подборе контейнеров и создании операций перемещения для расхода...\r\n" + ex.Message;
						RFMMessage.MessageBoxError(_ErrorStr);
					}
					// снять признак "в подборе"
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
					_ErrorStr = "Ошибка при подборе товаров и создании операций перемещения для расхода...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

	/// <summary>
	/// подбор ячейки отгрузки
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
			_ErrorStr = "Ошибка при подборе ячейки отгрузки...\r\n"  + ex.Message;
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
				_ErrorStr = "Ошибка при подборе ячйки отгрузки...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
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
		/// ручной подбор контейнеров для конкретного товара расхода
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
				_ErrorStr = "Ошибка при ручном подборе контейнеров и создании операций транспортировки для расхода...\r\n" + ex.Message;
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
					_ErrorStr = "Ошибка при ручном подборе контейнеров и создании операций транспортировки для расхода...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// задание трафика выбранного контейнера для товара в расходе (независимо от требуемого количества)
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
				_ErrorStr = "Ошибка при попытке создания транспортировки контейнера для товара в расходе...\r\n" + ex.Message;
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
					_ErrorStr = "Ошибка при создании транспортировки контейнера для товара в расходе...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// задание трафика некоторого количество товара из выбранного контейнера для товара в расходе
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
				_ErrorStr = "Ошибка при попытке создания перемещения коробок/штук из контейнера для товара в расходе...\r\n" + ex.Message;
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
					_ErrorStr = "Ошибка при создании перемещения коробок/штук из контейнера для товара в расходе...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}
		//

		/// <summary>
		/// подтверждение расхода
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
				_ErrorStr = "Ошибка при попытке подтверждения расхода...\r\n" + ex.Message;
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
					_ErrorStr = "Ошибка при подтверждении расхода...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
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
		/// Подтверждение трафиков и перемещений
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
				_ErrorStr = "Ошибка при подтверждении " + ((bFrameMode) ? "транспортировок контейнеров" : "перемещений коробок/штук") + "...\r\n" + ex.Message;
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
					_ErrorStr = "Ошибка при подтверждении " + ((bFrameMode) ? "транспортировок контейнеров" : "перемещений коробок/штук") + "...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		#endregion Confirm

		#region Delete

		/// <summary>
		/// удаление расхода
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
				_ErrorStr = "Ошибка при удалении расхода...\r\n" + ex.Message;
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
					_ErrorStr = "Ошибка при удалении расхода...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
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
				_ErrorStr = "Ошибка при изменении ячейки отгрузки для расхода с кодом " + nCellID.ToString() + "...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr); // RaiseError
			}
			finally
			{
				_Connect.Close();
			}
			_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
			if (_ErrorNumber != 0)
			{
				_ErrorStr = "Ошибка при изменении ячейки отгрузки для с кодом " + nCellID.ToString() + "...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		#endregion Delete

		#region SetDateTime

		/// <summary>
		/// отметить время начала обработки расхода
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
				_ErrorStr = "Ошибка при отметке времени начала обработки расхода...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// отметить время начала обработки расхода - конкретное
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
				_ErrorStr = "Ошибка при отметке времени начала обработки расхода...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// очистить время начала обработки расхода
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
				_ErrorStr = "Ошибка при очистке времени начала обработки расхода...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// отметить время печати документов по расходу
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
				_ErrorStr = "Ошибка при отметке времени печати документа по расходу...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// установить время сбора/подбора товара для расхода
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
				_ErrorStr = "Ошибка при установке даты сбора/подбора товара...\r\n" + ex.Message;
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
					_ErrorStr = "Дата сбора/подбора товара не установлена...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
					RFMMessage.MessageBoxInfo(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// установить время сбора/подбора товара для расхода
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
				_ErrorStr = "Ошибка при снятии признака \"в подборе\"...\r\n" + ex.Message;
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
				_ErrorStr = "Ошибка при сохранении данных о сотрудниках, выполнявших загрузку машины для расхода с кодом " + nOutputID.ToString() + "...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr); // RaiseError
			}
			finally
			{
				_Connect.Close();
			}
			_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
			if (_ErrorNumber != 0)
			{
				_ErrorStr = "Ошибка при сохранении данных о сотрудниках, выполнявших загрузку машины для расхода с кодом " + nOutputID.ToString() + "...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
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
				_ErrorStr = "Ошибка при сохранении коэффициента сложности загрузки для расхода с кодом " + nOutputID.ToString() + "...\r\n" + ex.Message;
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
				_ErrorStr = "Ошибка при сохранении числа отгруженных поддонов для расхода с кодом " + nOutputID.ToString() + "...\r\n" + ex.Message;
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
				_ErrorStr = "Ошибка при сохранении данных о проверяющем сотруднике для расхода с кодом " + nOutputID.ToString() + "...\r\n" + ex.Message;
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
