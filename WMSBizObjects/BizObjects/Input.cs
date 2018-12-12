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
/// Бизнес-объект Приход (Input)
/// </summary>
namespace WMSBizObjects
{
	public class Input : BizObject
	{
		protected string _IDList;
		/// <summary>
		/// Список ID приходов (Inputs.ID)
		/// </summary>
		[Description("Список ID приходов (Inputs.ID)")]
		public string IDList { get { return _IDList; } set { _IDList = value; _NeedRequery = true; } }

		protected string _BarCode;
		/// <summary>
		/// Штрих-код документа-прихода (Inputs.BarCode), контекст
		/// </summary>
		[Description("Штрих-код документа-прихода (Inputs.BarCode), контекст")]
		public string BarCode { get { return _BarCode; } set { _BarCode = value; _NeedRequery = true; } }

		// Фильтры
		#region Filters

		protected string _FilterHostsList;
		/// <summary>
		/// Фильтр-поле: список кодов host-ов (Inputs.HostID)
		/// </summary>
		[Description("Фильтр-поле: список кодов host-ов (Inputs.HostID)")]
		public string FilterHostsList { get { return _FilterHostsList; } set { _FilterHostsList = value; _NeedRequery = true; } }

		protected DateTime? _FilterDateBeg;
		/// <summary>
		/// Фильтр-поле: Дата ожидаемого прихода: начальная дата периода (Inputs.DateInput)
		/// </summary>
		[Description("Фильтр-поле: Дата ожидаемого прихода: начальная дата периода (Inputs.DateInput)")]
		public DateTime? FilterDateBeg { get { return _FilterDateBeg; } set { _FilterDateBeg = value; _NeedRequery = true; } }

		protected DateTime? _FilterDateEnd;
		/// <summary>
		/// Фильтр-поле: Дата ожидаемого прихода: конечная дата периода (Inputs.DateInput)
		/// </summary>
		[Description("Фильтр-поле: Дата ожидаемого прихода: конечная дата периода (Inputs.DateInput)")]
		public DateTime? FilterDateEnd { get { return _FilterDateEnd; } set { _FilterDateEnd = value; _NeedRequery = true; } }

		protected DateTime? _FilterDateBegConfirm;
		/// <summary>
		/// Фильтр-поле: Дата подтверждения: начальная дата периода (Inputs.DateConfirm)
		/// </summary>
		[Description("Фильтр-поле: Дата подтверждения: начальная дата периода (Inputs.DateConfirm)")]
		public DateTime? FilterDateBegConfirm { get { return _FilterDateBegConfirm; } set { _FilterDateBegConfirm = value; _NeedRequery = true; } }

		protected DateTime? _FilterDateEndConfirm;
		/// <summary>
		/// Фильтр-поле: Дата подтверждения: конечная дата периода (Inputs.DateConfirm)
		/// </summary>
		[Description("Фильтр-поле: Дата подтверждения: конечная дата периода (Inputs.DateConfirm)")]
		public DateTime? FilterDateEndConfirm { get { return _FilterDateEndConfirm; } set { _FilterDateEndConfirm = value; _NeedRequery = true; } }

		protected string _FilterInputsTypesList;
		/// <summary>
		/// Фильтр-поле: Список типов прихода (Inputs.InputTypeID), через запятую
		/// </summary>
		[Description("Фильтр-поле: Список типов прихода (Inputs.InputTypeID), через запятую")]
		public string FilterInputsTypesList { get { return _FilterInputsTypesList; } set { _FilterInputsTypesList = value; _NeedRequery = true; } }

		protected string _FilterPartnersList;
		/// <summary>
		/// Фильтр-поле: Список поставщиков (Inputs.PartnerID), через запятую
		/// </summary>
		[Description("Фильтр-поле: Список поставщиков (Inputs.PartnerID), через запятую")]
		public string FilterPartnersList { get { return _FilterPartnersList; } set { _FilterPartnersList = value; _NeedRequery = true; } }

		protected string _FilterPartnerContext;
		/// <summary>
		/// Фильтр-поле: Название поставщика (Inputs.PartnerID -> Partnres.Name), контекст
		/// </summary>
		[Description("Фильтр-поле: Название поставщика (Inputs.PartnerID -> Partnres.Name), контекст")]
		public string FilterPartnerContext { get { return _FilterPartnerContext; } set { _FilterPartnerContext = value; _NeedRequery = true; } }

		protected string _FilterOwnersList;
		/// <summary>
		/// Фильтр-поле: Список владельцев товара (Inputs.OwnerID), через запятую
		/// </summary>
		[Description("Фильтр-поле: Список владельцев товара (Inputs.OwnerID), через запятую")]
		public string FilterOwnersList { get { return _FilterOwnersList; } set { _FilterOwnersList = value; _NeedRequery = true; } }

		protected string _FilterGoodsStatesList;
		/// <summary>
		/// Фильтр-поле: Список состояний товара (Inputs.GoodStateID, InputsGoods.GoodStateID), через запятую
		/// </summary>
		[Description("Фильтр-поле: Список состояний товара (Inputs.GoodStateID, InputsGoods.GoodStateID), через запятую")]
		public string FilterGoodsStatesList { get { return _FilterGoodsStatesList; } set { _FilterGoodsStatesList = value; _NeedRequery = true; } }

		protected bool? _FilterGoodStateTerm;
		/// <summary>
		/// Фильтр-поле: Список состояний для приходов (0) или для товаров в приходах (1)?
		/// </summary>
		[Description("Фильтр-поле: Список состояний для приходов (0) или для товаров в приходах (1)?")]
		public bool? FilterGoodStateTerm { get { return _FilterGoodStateTerm; } set { _FilterGoodStateTerm = value; _NeedRequery = true; } }

		protected string _FilterPackingsList;
		/// <summary>
		/// Фильтр-поле: Список ID упаковок (InputsGoods.PackingID), через запятую
		/// </summary>
		[Description("Фильтр-поле: Список ID упаковок (InputsGoods.PackingID), через запятую")]
		public string FilterPackingsList { get { return _FilterPackingsList; } set { _FilterPackingsList = value; _NeedRequery = true; } }

		protected string _FilterGoodsList;
		/// <summary>
		/// Фильтр-поле: Список ID товаров (InputsGoods.PackingID -> Packings.GoodID -> Goods.ID), через запятую
		/// </summary>
		[Description("Фильтр-поле: Список ID товаров (InputsGoods.PackingID -> Packings.GoodID -> Goods.ID), через запятую")]
		public string FilterGoodsList { get { return _FilterGoodsList; } set { _FilterGoodsList = value; _NeedRequery = true; } }

		protected bool? _FilterStarted;
		/// <summary>
		/// Фильтр-поле: Начата обработка прихода (Inputs.DateStart)?
		/// </summary>
		[Description("Фильтр-поле: Начата обработка прихода (Inputs.DateStart)?")]
		public bool? FilterStarted { get { return _FilterStarted; } set { _FilterStarted = value; _NeedRequery = true; } }

		protected bool? _FilterConfirmed;
		/// <summary>
		/// Фильтр-поле: Приходы подтверждены (Inputs.DateConfirm)?
		/// </summary>
		[Description("Фильтр-поле: Приходы подтверждены (Inputs.DateConfirm)?")]
		public bool? FilterConfirmed { get { return _FilterConfirmed; } set { _FilterConfirmed = value; _NeedRequery = true; } }

		protected bool? _FilterConfirmedZero;
		/// <summary>
		/// Фильтр-поле: Приходы отклонены (Inputs.DateConfirm is not Null, QntConfirmed = 0)?
		/// </summary>
		[Description("Фильтр-поле: Приходы отклонены (Inputs.DateConfirm is not null, QntConfirmed = 0)?")]
		public bool? FilterConfirmedZero { get { return _FilterConfirmedZero; } set { _FilterConfirmedZero = value; _NeedRequery = true; } }

		protected bool? _FilterFramesTrafficsCreated;
		/// <summary>
		/// Фильтр-поле: Для контейнеров созданы операции транспортировки (InputsGoods -> FramesContents -> Frames -> Traffics.FrameID)?
		/// </summary>
		[Description("Фильтр-поле: Для контейнеров созданы операции транспортировки (InputsGoods -> FramesContents -> Frames -> Traffics.FrameID)?")]
		public bool? FilterFramesTrafficsCreated { get { return _FilterFramesTrafficsCreated; } set { _FilterFramesTrafficsCreated = value; _NeedRequery = true; } }

		protected bool? _FilterFramesTrafficsConfirmed;
		/// <summary>
		/// Фильтр-поле: Для контейнеров подтверждены операции транспортировки (InputsGoods -> FramesContents -> Frames -> Traffics.FrameID)?
		/// </summary>
		[Description("Фильтр-поле: Для контейнеров подтверждены операции транспортировки (InputsGoods -> FramesContents -> Frames -> Traffics.FrameID)?")]
		public bool? FilterFramesTrafficsConfirmed { get { return _FilterFramesTrafficsConfirmed; } set { _FilterFramesTrafficsConfirmed = value; _NeedRequery = true; } }

		protected string _FilterUsersList;
		/// <summary>
		/// Фильтр-поле: Список ID пользователей, выполнявших приход (InputsItems.UserID), через запятую
		/// </summary>
		[Description("Фильтр-поле: Список ID пользователей, выполнявших приход (InputsItems.UserID), через запятую")]
		public string FilterUsersList { get { return _FilterUsersList; } set { _FilterUsersList = value; _NeedRequery = true; } }

		protected bool? _FilterFramesArrangeProblem;
		/// <summary>
		/// Фильтр-поле: Есть проблемы при подборе яччек для контенйеров?
		/// </summary>
		[Description("Фильтр-поле: Есть проблемы при подборе яччек для контенйеров?")]
		public bool? FilterFramesArrangeProblem { get { return _FilterFramesArrangeProblem; } set { _FilterFramesArrangeProblem = value; _NeedRequery = true; } }

		protected bool? _FilterTrafficsFramesConfirmProblem;
		/// <summary>
		/// Фильтр-поле: Есть проблемы при подборе яччек для контенйеров?
		/// </summary>
		[Description("Фильтр-поле: Есть проблемы при подборе яччек для контенйеров?")]
		public bool? FilterTrafficsFramesConfirmProblem { get { return _FilterTrafficsFramesConfirmProblem; } set { _FilterTrafficsFramesConfirmProblem = value; _NeedRequery = true; } }

		#endregion Filters

		#region Tables

		protected DataTable _TableInputsGoods;
		/// <summary>
		/// Список заказанных/полученных товаров в приходе (с состоянием товаров)
		/// </summary>
		[Description("Список заказанных/полученных товаров в приходе (с состоянием товаров)")]
		public DataTable TableInputsGoods { get { return _TableInputsGoods; } }

		protected DataTable _TableInputsGoodsTotal;
		/// <summary>
		/// Список заказанных/полученных товаров в приходе, без учета состояния
		/// </summary>
		[Description("Список заказанных/полученных товаров в приходе, без учета состояния")]
		public DataTable TableInputsGoodsTotal { get { return _TableInputsGoodsTotal; } }

		protected DataTable _TableInputsPallets;
		/// <summary>
		/// Список паллет в приходе - для обработки
		/// </summary>
		[Description("Список паллет в приходе - для обработки")]
		public DataTable TableInputsPallets { get { return _TableInputsPallets; } }

		protected DataTable _TableInputsFrames;
		/// <summary>
		/// Список контейнеров в приходе
		/// </summary>
		[Description("Список контейнеров в приходе")]
		public DataTable TableInputsFrames { get { return _TableInputsFrames; } }

		protected DataTable _TableInputsTrafficsFrames;
		/// <summary>
		/// Список операций по транспортировке контейнеров в приходе 
		/// </summary>
		[Description("Список операций по транспортировке контейнеров в приходе")]
		public DataTable TableInputsTrafficsFrames { get { return _TableInputsTrafficsFrames; } }

		protected DataTable _TableInputsTrafficsGoods;
		/// <summary>
		/// Список операций по перемещению коробок/штук в приходе
		/// </summary>
		[Description("Список операций по транспортировке контейнеров в приходе")]
		public DataTable TableInputsTrafficsGoods { get { return _TableInputsTrafficsGoods; } }

		protected DataTable _TableInputsItems;
		/// <summary>
		/// Список составляющих в приходе
		/// </summary>
		[Description("Список составляющих в приходе")]
		public DataTable TableInputsItems { get { return _TableInputsItems; } }

		protected DataTable _TableInputsTypes;
		/// <summary>
		/// Таблица типов приходов
		/// </summary>
		[Description("Таблица типов приходов")]
		public DataTable TableInputsTypes { get { return _TableInputsTypes; } }

		protected DataTable _TableInputsUnloaders;
		/// <summary>
		/// Таблица сотрудников, выполнявших загрузку товара в машины
		/// </summary>
		[Description("Таблица сотрудников, выполнявших загрузку товара в машины (TableInputsUnloaders)")]
		public DataTable TableInputsUnloaders { get { return _TableInputsUnloaders; } }

		#endregion Tables

		// -------------------------------------

		public Input()
			: base()
		{
			_MainTableName = "Inputs";
		}

		/// <summary>
		/// получение списка приходов (MainTable)
		/// </summary>
		public override bool FillData()
		{
			ClearData();

			string sqlSelect = "execute up_InputsFill " +
					"@nID, @cIDList, " +
					"@cHostsList, " + 
					"@cBarCode, @bConfirmed, @bConfirmedZero, @bStarted, " +
					"@dDateBeg, @dDateEnd, " +
					"@dDateBegConfirm, @dDateEndConfirm, " +
					"@cInputsTypesList, " +
					"@cPartnersList, @cPartnerContext, @cOwnersList, " +
					"@cGoodsStatesList, @bGoodStateTerm, " +
					"@bFramesTrafficCreated, @bFramesTrafficConfirmed, " +
					"@cPackingsList, @cGoodsList, " +
					"@cUsersList, " +
					"@bFramesArrangeProblem, @bTrafficsFramesConfirmProblem";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_InputsFill parameters

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

			_oCommand.Parameters.Add("@cHostsList", SqlDbType.VarChar);
			if (_FilterHostsList != null)
				_oCommand.Parameters["@cHostsList"].Value = _FilterHostsList;
			else
				_oCommand.Parameters["@cHostsList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cBarCode", SqlDbType.VarChar);
			if (_BarCode != null)
				_oCommand.Parameters["@cBarCode"].Value = _BarCode;
			else
				_oCommand.Parameters["@cBarCode"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bConfirmed", SqlDbType.Bit);
			if (_FilterConfirmed.HasValue)
				_oCommand.Parameters["@bConfirmed"].Value = _FilterConfirmed;
			else
				_oCommand.Parameters["@bConfirmed"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bConfirmedZero", SqlDbType.Bit);
			if (_FilterConfirmedZero.HasValue)
				_oCommand.Parameters["@bConfirmedZero"].Value = _FilterConfirmedZero;
			else
				_oCommand.Parameters["@bConfirmedZero"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bStarted", SqlDbType.Bit);
			if (_FilterStarted.HasValue)
				_oCommand.Parameters["@bStarted"].Value = _FilterStarted;
			else
				_oCommand.Parameters["@bStarted"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@dDateBeg", SqlDbType.SmallDateTime);
			if (_FilterDateBeg.HasValue)
				_oCommand.Parameters["@dDateBeg"].Value = _FilterDateBeg;
			else
				_oCommand.Parameters["@dDateBeg"].Value = DBNull.Value;
			
			_oCommand.Parameters.Add("@dDateEnd", SqlDbType.SmallDateTime);
			if (_FilterDateEnd.HasValue)
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

			_oCommand.Parameters.Add("@cInputsTypesList", SqlDbType.VarChar);
			if (_FilterInputsTypesList != null)
				_oCommand.Parameters["@cInputsTypesList"].Value = _FilterInputsTypesList;
			else
				_oCommand.Parameters["@cInputsTypesList"].Value = DBNull.Value;

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

			_oCommand.Parameters.Add("@bGoodStateTerm", SqlDbType.Bit);
			if (_FilterGoodStateTerm.HasValue)
				_oCommand.Parameters["@bGoodStateTerm"].Value = _FilterGoodStateTerm;
			else
				_oCommand.Parameters["@bGoodStateTerm"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bFramesTrafficCreated", SqlDbType.Bit);
			if (_FilterFramesTrafficsCreated.HasValue)
				_oCommand.Parameters["@bFramesTrafficCreated"].Value = _FilterFramesTrafficsCreated;
			else
				_oCommand.Parameters["@bFramesTrafficCreated"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bFramesTrafficConfirmed", SqlDbType.Bit);
			if (_FilterFramesTrafficsConfirmed.HasValue)
				_oCommand.Parameters["@bFramesTrafficConfirmed"].Value = _FilterFramesTrafficsConfirmed;
			else
				_oCommand.Parameters["@bFramesTrafficConfirmed"].Value = DBNull.Value;

			#region up_InputsFill InputsGoods-paramaters

			//поля для поиска через Список товаров (InputsGoods)

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

			#region up_InputsFill InputsItems-paramaters

			//поля для поиска через Список составляющих (InputsItems)

			_oCommand.Parameters.Add("@cUsersList", SqlDbType.VarChar);
			if (_FilterUsersList != null)
				_oCommand.Parameters["@cUsersList"].Value = _FilterUsersList;
			else
				_oCommand.Parameters["@cUsersList"].Value = DBNull.Value;

			#endregion

			_oCommand.Parameters.Add("@bFramesArrangeProblem", SqlDbType.Bit);
			if (_FilterFramesArrangeProblem.HasValue)
				_oCommand.Parameters["@bFramesArrangeProblem"].Value = _FilterFramesArrangeProblem;
			else
				_oCommand.Parameters["@bFramesArrangeProblem"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bTrafficsFramesConfirmProblem", SqlDbType.Bit);
			if (_FilterTrafficsFramesConfirmProblem.HasValue)
				_oCommand.Parameters["@bTrafficsFramesConfirmProblem"].Value = _FilterTrafficsFramesConfirmProblem;
			else
				_oCommand.Parameters["@bTrafficsFramesConfirmProblem"].Value = DBNull.Value;

			#endregion

			try
			{
				_MainTable = FillReadings(new SqlDataAdapter(_oCommand), _MainTable, _MainTableName);
				_NeedRequery = false;
			}
			catch (Exception ex)
			{
				_ErrorNumber = -1;
				_ErrorStr = "Ошибка при получении списка приходов...\r\n" + ex.Message;
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
			_FilterInputsTypesList = null;
			_FilterPartnersList = null;
			_FilterPartnerContext = null;
			_FilterOwnersList = null;
			_FilterConfirmed = null;
			_FilterConfirmedZero = null;
			_FilterStarted = null;
			_FilterFramesTrafficsCreated = null;
			_FilterFramesTrafficsConfirmed = null;
			_FilterPackingsList = null;
			_FilterGoodsList = null;
			_FilterGoodsStatesList = null;
			_FilterGoodStateTerm = null;
			_FilterUsersList = null;
			_FilterFramesArrangeProblem = null;
			_FilterTrafficsFramesConfirmProblem = null;
			//_NeedRequery = true;
		}

		#region FillTables 

		/// <summary>
		/// заполнение таблицы типов приходов (TableInputsTypes)
		/// </summary>
		public bool FillTableInputsTypes()
		{
			string sqlSelect = "select IT.ID, IT.Name, " +
					"IT.OwnerID, Ow.Name as OwnerName, " +
					"IT.GoodStateID, GS.Name as GoodsStatesName, " +
					"IT.Actual " +
				"from InputsTypes IT " +
				"left join Partners Ow on IT.OwnerID = Ow.ID " +
				"left join GoodsStates GS on IT.GoodStateID = GS.ID " +
				"order by IT.Name";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			try
			{
				_TableInputsTypes = FillReadings(new SqlDataAdapter(_oCommand), _TableInputsTypes, "TableInputsTypes");
			}
			catch (Exception ex)
			{
				_ErrorNumber = -11;
				_ErrorStr = "Ошибка при получении списка типов приходов...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}


		/// <summary>
		/// заполнение таблицы товаров в приходе (TableInputsGoods)
		/// </summary>
		public bool FillTableInputsGoods(int? nInputID, bool? bTotal)
		{
			if (!nInputID.HasValue & !_ID.HasValue)
			{
				_ErrorNumber = -12;
				_ErrorStr = "Некорректный вызов:\r\nОшибка при получении списка товаров в приходе...";
				RFMMessage.MessageBoxError(_ErrorStr);
				return (false);
			}
			if (!nInputID.HasValue)
				nInputID = _ID;

			if (!bTotal.HasValue)
				bTotal = false;

			string sqlSelect = "execute up_InputsGoodsFill @nInputID, @bTotal, " +
					"@nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_InputsGoodsFill parameters

			_oCommand.Parameters.Add("@nInputID", SqlDbType.Int);
			_oCommand.Parameters["@nInputID"].Value = nInputID;

			_oCommand.Parameters.Add("@bTotal", SqlDbType.Bit);
			_oCommand.Parameters["@bTotal"].Value = bTotal;

			_oCommand.Parameters.Add("@nError", SqlDbType.Int);
			_oCommand.Parameters["@nError"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@nError"].Value = 0;

			_oCommand.Parameters.Add("@cErrorText", SqlDbType.VarChar, 200);
			_oCommand.Parameters["@cErrorText"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@cErrorText"].Value = "";

			#endregion

			try
			{
				SqlDataAdapter adapter = new SqlDataAdapter(_oCommand);
				if (bTotal.HasValue && (bool)bTotal)
				{
					_TableInputsGoodsTotal = FillReadings(new SqlDataAdapter(_oCommand), _TableInputsGoodsTotal, "TableInputsGoodsTotal");

					// primarykey
					DataColumn[] pk = new DataColumn[1];
					pk[0] = _TableInputsGoodsTotal.Columns["PackingID"];
					_TableInputsGoodsTotal.PrimaryKey = pk;
				}
				else
				{
					_TableInputsGoods = FillReadings(new SqlDataAdapter(_oCommand), _TableInputsGoods, "TableInputsGoods");
				}
			}
			catch (Exception ex)
			{
				_ErrorNumber = -4;
				_ErrorStr = "Ошибка при получении списка товаров в приходе...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			if (_ErrorNumber == 0)
			{
				_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
				if (_ErrorNumber != 0)
				{
					_ErrorStr = "Ошибка при получении списка товаров в приходе...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// заполнение таблицы товаров в приходе (TableInputsGoods), с учетом неожидаемых товаров в InputsItems
		/// </summary>
		public bool FillTableInputsGoodsItems(int? nInputID, bool? bTotal)
		{
			if (!nInputID.HasValue & !_ID.HasValue)
			{
				_ErrorNumber = -12;
				_ErrorStr = "Некорректный вызов:\r\nОшибка при получении списка товаров в приходе...";
				RFMMessage.MessageBoxError(_ErrorStr);
				return (false);
			}
			if (!nInputID.HasValue)
				nInputID = _ID;

			if (!bTotal.HasValue)
				bTotal = false;

			string sqlSelect = "execute up_InputsGoodsItemsFill @nInputID, @bTotal, " +
					"@nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_InputsGoodsItemsFill parameters

			_oCommand.Parameters.Add("@nInputID", SqlDbType.Int);
			_oCommand.Parameters["@nInputID"].Value = nInputID;

			_oCommand.Parameters.Add("@bTotal", SqlDbType.Bit);
			_oCommand.Parameters["@bTotal"].Value = bTotal;

			_oCommand.Parameters.Add("@nError", SqlDbType.Int);
			_oCommand.Parameters["@nError"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@nError"].Value = 0;

			_oCommand.Parameters.Add("@cErrorText", SqlDbType.VarChar, 200);
			_oCommand.Parameters["@cErrorText"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@cErrorText"].Value = "";

			#endregion

			try
			{
				if (bTotal.HasValue && (bool)bTotal)
				{
					_TableInputsGoodsTotal = FillReadings(new SqlDataAdapter(_oCommand), _TableInputsGoodsTotal, "TableInputsGoodsTotal");

					// primarykey
					DataColumn[] pk = new DataColumn[1];
					pk[0] = _TableInputsGoodsTotal.Columns["PackingID"];
					_TableInputsGoodsTotal.PrimaryKey = pk;
				}
				else
				{
					_TableInputsGoods = FillReadings(new SqlDataAdapter(_oCommand), _TableInputsGoods, "TableInputsGoods");
				}
			}
			catch (Exception ex)
			{
				_ErrorNumber = -4;
				_ErrorStr = "Ошибка при получении списка товаров в приходе...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			if (_ErrorNumber == 0)
			{
				_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
				if (_ErrorNumber != 0)
				{
					_ErrorStr = "Ошибка при получении списка товаров в приходе...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// заполнение таблицы товаров в приходе - по паллетам!
		/// </summary>
		public bool FillTableInputsPalletsEach(int? nInputID, string sTableInputsGoodsPallets)
		{
			if (!nInputID.HasValue & !_ID.HasValue)
			{
				_ErrorNumber = -12;
				_ErrorStr = "Некорректный вызов:\r\nОшибка при получении списка товаров по паллетам в приходе...";
				RFMMessage.MessageBoxError(_ErrorStr);
				return (false);
			}
			if (!nInputID.HasValue)
				nInputID = _ID;

			string sqlSelect = "execute up_InputsPalletsEachFill @nInputID, @nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_InputsGoodsFill parameters

			_oCommand.Parameters.Add("@nInputID", SqlDbType.Int);
			_oCommand.Parameters["@nInputID"].Value = nInputID;

			_oCommand.Parameters.Add("@nError", SqlDbType.Int);
			_oCommand.Parameters["@nError"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@nError"].Value = 0;

			_oCommand.Parameters.Add("@cErrorText", SqlDbType.VarChar, 200);
			_oCommand.Parameters["@cErrorText"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@cErrorText"].Value = "";

			#endregion

			try
			{
				FillReadings(new SqlDataAdapter(_oCommand), null, sTableInputsGoodsPallets);
			}
			catch (Exception ex)
			{
				_ErrorNumber = -4;
				_ErrorStr = "Ошибка при получении списка товаров по паллетам в приходе...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			if (_ErrorNumber == 0)
			{
				_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
				if (_ErrorNumber != 0)
				{
					_ErrorStr = "Ошибка при получении списка товаров по паллетам в приходе...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// добавление товара-упаковки в таблицу товаров в приходе (TableInputsGoods)
		/// </summary>
		public bool AddTableInputsGoods(int nPackingID, int nGoodStateID)
		{
			if (_DS.Tables["TableInputsGoods"] == null)
				return (false);

			string sqlSelect = "select P.ID as PackingID, P.GoodID, " +
					"P.InBox, P.BoxInPal, P.BoxInRow, P.BoxHeight, " +
					"P.PalletTypeID, PT.Name as PalletTypeName, " +
					"G.Name as GoodName, G.Alias as GoodAlias, " +
					"G.Alias + ' (' + ltrim(str(P.InBox, 12, (case when G.Weighting = 1 then 3 else 0 end))) + ')' as PackingAlias, " +
					"G.Retention, G.Weighting, " +
					"GS.Name as GoodStateName " +
				"from Packings P " +
				"left join PalletsTypes PT on P.PalletTypeID = PT.ID " +
				"left join Goods G on P.GoodID = G.ID " +
				"left join GoodsStates GS on GS.ID = " + nGoodStateID.ToString() + " " +
				"where P.ID = " + nPackingID.ToString();
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			try
			{
				FillReadings(new SqlDataAdapter(_oCommand), null, "_TempTable");

				if (_DS.Tables["_TempTable"].Rows.Count > 0)
				{
					DataRow _tempRow = _DS.Tables["_TempTable"].Rows[0]; // отсюда берем 

					DataRow dr = TableInputsGoods.NewRow(); // сюда пишем
					dr["ID"] = 0; // null
					dr["InputGoodID"] = 0; // null
					dr["PackingID"] = nPackingID;
					dr["GoodID"] = _tempRow["GoodID"];
					dr["InBox"] = _tempRow["InBox"];
					dr["BoxInPal"] = _tempRow["BoxInPal"];
					dr["BoxInRow"] = _tempRow["BoxInRow"];
					dr["PalletTypeID"] = _tempRow["PalletTypeID"];
					dr["PalletTypeName"] = _tempRow["PalletTypeName"];
					dr["BoxHeight"] = _tempRow["BoxHeight"];
					dr["GoodName"] = _tempRow["GoodName"];
					dr["GoodAlias"] = _tempRow["GoodAlias"];
					dr["PackingAlias"] = _tempRow["PackingAlias"];
					dr["Weighting"] = _tempRow["Weighting"];
					dr["Retention"] = _tempRow["Retention"];

					dr["QntWished"] = 0;
					dr["QntConfirmed"] = 0;
					dr["QntArranged"] = 0;
					dr["BoxWished"] = 0;
					dr["BoxConfirmed"] = 0;
					dr["BoxArranged"] = 0;
					dr["PalWished"] = 0;
					dr["PalConfirmed"] = 0;
					dr["PalArranged"] = 0;

					dr["GoodStateID"] = nGoodStateID;
					dr["GoodStateName"] = _tempRow["GoodStateName"];

					//
					if (TableInputsGoods.Columns["IsNormal"] != null)
					{
						DataRow drStatus = TableInputsGoods.Rows[TableInputsGoods.Rows.Count - 1];
						if (!(bool)drStatus["IsNormal"])
							drStatus.Delete();
					}
					TableInputsGoods.Rows.Add(dr);
					// 
					if (TableInputsGoodsTotal != null)
					{
						DataRow drFind = TableInputsGoodsTotal.Rows.Find(nPackingID);

						if (drFind == null)
						{
							dr = TableInputsGoodsTotal.NewRow(); // сюда пишем
							dr["InputID"] = 0; // null
							dr["PackingID"] = nPackingID;
							dr["GoodID"] = _tempRow["GoodID"];
							dr["InBox"] = _tempRow["InBox"];
							dr["BoxInPal"] = _tempRow["BoxInPal"];
							dr["BoxInRow"] = _tempRow["BoxInRow"];
							dr["PalletTypeID"] = _tempRow["PalletTypeID"];
							dr["PalletTypeName"] = _tempRow["PalletTypeName"];
							dr["BoxHeight"] = _tempRow["BoxHeight"];
							dr["GoodName"] = _tempRow["GoodName"];
							dr["GoodAlias"] = _tempRow["GoodAlias"];
							dr["PackingAlias"] = _tempRow["PackingAlias"];
							dr["Weighting"] = _tempRow["Weighting"];
							dr["Retention"] = _tempRow["Retention"];

							dr["QntWished"] = 0;
							dr["QntConfirmed"] = 0;
							dr["QntArranged"] = 0;
							dr["BoxWished"] = 0;
							dr["BoxConfirmed"] = 0;
							dr["BoxArranged"] = 0;
							dr["PalWished"] = 0;
							dr["PalConfirmed"] = 0;
							dr["PalArranged"] = 0;

							TableInputsGoodsTotal.Rows.Add(dr);
						}
					}
				}
				_DS.Tables.Remove("_TempTable");
			}
			catch (Exception ex)
			{
				_ErrorNumber = -22;
				_ErrorStr = "Ошибка при добавлении товара в список товаров в приходе...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}


		/// <summary>
		/// заполнение таблицы паллет в приходе (TableInputsPallets)
		/// </summary>
		public bool FillTableInputsPallets(int? nInputID)
		{
			if (!nInputID.HasValue & !_ID.HasValue)
			{
				_ErrorNumber = -14;
				_ErrorStr = "Некорректный вызов:\r\nОшибка при получении списка товаров в приходе...";
				RFMMessage.MessageBoxError(_ErrorStr);
				return (false);
			}
			if (!nInputID.HasValue)
				nInputID = _ID;

			string sqlSelect = "execute up_InputsPalletsFill @nInputID, @nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_InputsPalletsFill parameters

			_oCommand.Parameters.Add("@nInputID", SqlDbType.Int);
			_oCommand.Parameters["@nInputID"].Value = nInputID;

			_oCommand.Parameters.Add("@nError", SqlDbType.Int);
			_oCommand.Parameters["@nError"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@nError"].Value = 0;

			_oCommand.Parameters.Add("@cErrorText", SqlDbType.VarChar, 200);
			_oCommand.Parameters["@cErrorText"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@cErrorText"].Value = "";

			#endregion

			try
			{
				_TableInputsPallets = FillReadings(new SqlDataAdapter(_oCommand), _TableInputsPallets, "TableInputsPallets");
			}
			catch (Exception ex)
			{
				_ErrorNumber = -4;
				_ErrorStr = "Ошибка при получении списка паллет в приходе...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			if (_ErrorNumber == 0)
			{
				_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
				if (_ErrorNumber != 0)
				{
					_ErrorStr = "Ошибка при получении списка паллет в приходе...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// заполнение таблицы контейнеров в приходе (TableInputsPallets)
		/// </summary>
		public bool FillTableInputsFrames(int? nInputID)
		{
			if (!nInputID.HasValue & !_ID.HasValue)
			{
				_ErrorNumber = -15;
				_ErrorStr = "Некорректный вызов:\r\nОшибка при получении списка контейнеров в приходе...";
				RFMMessage.MessageBoxError(_ErrorStr);
				return (false);
			}
			if (!nInputID.HasValue)
				nInputID = _ID;

			string sqlSelect = "execute up_InputsFramesFill @nInputID, @nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_InputsFramesFill parameters

			_oCommand.Parameters.Add("@nInputID", SqlDbType.Int);
			_oCommand.Parameters["@nInputID"].Value = nInputID;

			_oCommand.Parameters.Add("@nError", SqlDbType.Int);
			_oCommand.Parameters["@nError"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@nError"].Value = 0;

			_oCommand.Parameters.Add("@cErrorText", SqlDbType.VarChar, 200);
			_oCommand.Parameters["@cErrorText"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@cErrorText"].Value = "";

			#endregion

			try
			{
				_TableInputsFrames = FillReadings(new SqlDataAdapter(_oCommand), _TableInputsFrames, "TableInputsFrames");
			}
			catch (Exception ex)
			{
				_ErrorNumber = -5;
				_ErrorStr = "Ошибка при получении списка контейнеров в приходе...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			if (_ErrorNumber == 0)
			{
				_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
				if (_ErrorNumber != 0)
				{
					_ErrorStr = "Ошибка при получении списка контейнеров в приходе...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// заполнение таблицы составляющих в приходе (TableInputsItems)
		/// </summary>
		public bool FillTableInputsItems(int? nInputID)
		{
			if (!nInputID.HasValue & !_ID.HasValue)
			{
				_ErrorNumber = -15;
				_ErrorStr = "Некорректный вызов:\r\nОшибка при получении списка составляющих в приходе...";
				RFMMessage.MessageBoxError(_ErrorStr);
				return (false);
			}
			if (!nInputID.HasValue)
				nInputID = _ID;

			string sqlSelect = "execute up_InputsItemsFill @nInputID, @nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_InputsItemsFill parameters

			_oCommand.Parameters.Add("@nInputID", SqlDbType.Int);
			_oCommand.Parameters["@nInputID"].Value = nInputID;

			_oCommand.Parameters.Add("@nError", SqlDbType.Int);
			_oCommand.Parameters["@nError"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@nError"].Value = 0;

			_oCommand.Parameters.Add("@cErrorText", SqlDbType.VarChar, 200);
			_oCommand.Parameters["@cErrorText"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@cErrorText"].Value = "";

			#endregion

			try
			{
				_TableInputsItems = FillReadings(new SqlDataAdapter(_oCommand), _TableInputsItems, "TableInputsItems");
			}
			catch (Exception ex)
			{
				_ErrorNumber = -5;
				_ErrorStr = "Ошибка при получении списка составляющих в приходе...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			if (_ErrorNumber == 0)
			{
				_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
				if (_ErrorNumber != 0)
				{
					_ErrorStr = "Ошибка при получении списка составляющих в приходе...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// заполнение таблицы операций транспортировки/перемещений штук/коробок в приходе
		/// </summary>
		public bool FillTableInputsTraffics(int? nInputID, bool bFrameMode)
		{
			string sText = (bFrameMode) ? "операций транспортировки контейнеров" : "операций перемещения коробок/штук";

			if (!nInputID.HasValue & !_ID.HasValue)
			{
				_ErrorNumber = -21;
				_ErrorStr = "Некорректный вызов:\r\nОшибка при получении списка " + sText + " в приходе...";
				RFMMessage.MessageBoxError(_ErrorStr);
				return (false);
			}
			if (!nInputID.HasValue)
				nInputID = _ID;

			string sqlSelect = "execute up_InputsTrafficsFill @nInputID, @bFrameMode";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_InputsGoodsFill parameters

			_oCommand.Parameters.Add("@nInputID", SqlDbType.Int);
			_oCommand.Parameters["@nInputID"].Value = nInputID;

			_oCommand.Parameters.Add("@bFrameMode", SqlDbType.Bit);
			_oCommand.Parameters["@bFrameMode"].Value = bFrameMode;

			#endregion

			try
			{
				if (bFrameMode)
				{
					_TableInputsTrafficsFrames = FillReadings(new SqlDataAdapter(_oCommand), _TableInputsTrafficsFrames, "TableInputsTrafficsFrames");

					DataColumn[] pk = new DataColumn[1];
					pk[0] = _TableInputsTrafficsFrames.Columns["ID"];
					_TableInputsTrafficsFrames.PrimaryKey = pk;
				}
				else
				{
					_TableInputsTrafficsGoods = FillReadings(new SqlDataAdapter(_oCommand), _TableInputsTrafficsGoods, "TableInputsTrafficsGoods");

					DataColumn[] pk = new DataColumn[1];
					pk[0] = _TableInputsTrafficsGoods.Columns["ID"];
					_TableInputsTrafficsGoods.PrimaryKey = pk;
				}
			}
			catch (Exception ex)
			{
				_ErrorNumber = -4;
				_ErrorStr = "Ошибка при получении списка " + sText + " в приходе...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		#region InputsLoaders

		/// <summary>
		/// заполнение таблицы разгрузчиков товара (TableInputsUnloaders)
		/// </summary>
		public bool FillTableInputsUnloaders(int? nInputID)
		{
			if (!nInputID.HasValue & !_ID.HasValue)
			{
				_ErrorNumber = -16;
				_ErrorStr = "Некорректный вызов:\r\nОшибка при получении списка сотрудников, выполнявших прием товара...";
				RFMMessage.MessageBoxError(_ErrorStr);
				return (false);
			}
			if (!nInputID.HasValue)
				nInputID = _ID;

			string sqlSelect = "execute up_InputsUnloadersFill @nInputID, " +
									"@nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_InputsUnloadersFill parameters

			_oCommand.Parameters.Add("@nInputID", SqlDbType.Int);
			_oCommand.Parameters["@nInputID"].Value = nInputID;

			_oCommand.Parameters.Add("@nError", SqlDbType.Int);
			_oCommand.Parameters["@nError"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@nError"].Value = 0;

			_oCommand.Parameters.Add("@cErrorText", SqlDbType.VarChar, 200);
			_oCommand.Parameters["@cErrorText"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@cErrorText"].Value = "";

			#endregion

			try
			{
				_TableInputsUnloaders = FillReadings(new SqlDataAdapter(_oCommand), _TableInputsUnloaders, "TableInputsUnloaders");
			}
			catch (Exception ex)
			{
				_ErrorNumber = -5;
				_ErrorStr = "Ошибка при получении списка сотрудников, выполнявших прием товара...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			if (_ErrorNumber == 0)
			{
				_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
				if (_ErrorNumber != 0)
				{
					_ErrorStr = "Ошибка при получении списка сотрудников, выполнявших прием товара...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}



		#endregion InputsLoaders

		#endregion FillTables

		#region Save

		/// <summary>
		/// сохранение прихода
		/// </summary>
		public bool SaveData(int nInputID)
		{
			if (_MainTable.Rows.Count == 0 || _MainTable.Rows[0] == null)
			{
				_ErrorNumber = -20;
				_ErrorStr = "Нет данных для сохранения прихода...\n";
				RFMMessage.MessageBoxError(_ErrorStr);
				return (false);
			}

			DataRow r = _MainTable.Rows[0];

			String _sqlCommand = "execute up_InputsSave @nInputID, " +
					"@dDateInput, @nInputTypeID, @nPartnerID, @nOwnerID, " +
					"@nGoodStateID, " +
					"@cNote, @cBarCode, " +
					"@nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(_sqlCommand, _Connect);

			#region up_InputsSave parameters

			SqlParameter _oParameter = _oCommand.Parameters.Add("@nInputID", SqlDbType.Int);
			_oParameter.Value = nInputID;

			_oParameter = _oCommand.Parameters.Add("@dDateInput", SqlDbType.DateTime);
			_oParameter.Value = DateTime.Parse(r["DateInput"].ToString());

			_oParameter = _oCommand.Parameters.Add("@nInputTypeID", SqlDbType.Int);
			_oParameter.Value = Int32.Parse(r["InputTypeID"].ToString());

			_oParameter = _oCommand.Parameters.Add("@nPartnerID", SqlDbType.Int);
			_oParameter.Value = Int32.Parse(r["PartnerID"].ToString());

			_oParameter = _oCommand.Parameters.Add("@nOwnerID", SqlDbType.Int);
			_oParameter.Value = Int32.Parse(r["OwnerID"].ToString());

			_oParameter = _oCommand.Parameters.Add("@nGoodStateID", SqlDbType.Int);
			_oParameter.Value = Int32.Parse(r["GoodStateID"].ToString());

			_oParameter = _oCommand.Parameters.Add("@cNote", SqlDbType.VarChar);
			if (r["Note"] == null)
				_oParameter.Value = DBNull.Value;
			else
				_oParameter.Value = r["Note"].ToString();

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
				_Connect.Open();
				_oCommand.ExecuteScalar();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -10;
				_ErrorStr = "Ошибка при сохранении прихода...\r\n" + ex.Message;
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
					_ErrorStr = "Ошибка при сохранении прихода...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		public bool InputsBoxesSave(int nInputID, int? nUserID, int? nCellID)
		{
			DataRow droRow = _TableInputsGoods.Rows[0];

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

			RFMUtilities.DataTableToTempTable(_TableInputsGoods, "#TableInputsGoods", _Connect);


			String _sqlCommand = "execute up_InputsBoxesSave @nInputID, " +
					"@nUserID, @nCellID, " +
					"@nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(_sqlCommand, _Connect);

			#region up_InputsBoxesSave parameters

			SqlParameter _oParameter = _oCommand.Parameters.Add("@nInputID", SqlDbType.Int);
			_oParameter.Value = nInputID;

			_oCommand.Parameters.Add("@nUserID", SqlDbType.Int);
			if (nUserID.HasValue)
				_oCommand.Parameters["@nUserID"].Value = nUserID;
			else
				_oCommand.Parameters["@nUserID"].Value = DBNull.Value;


			_oCommand.Parameters.Add("@nCellID", SqlDbType.Int);
			if (nCellID.HasValue)
				_oCommand.Parameters["@nCellID"].Value = nCellID;
			else
				_oCommand.Parameters["@nCellID"].Value = DBNull.Value;

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
				_ErrorStr = "Ошибка при сохранении прихода...\r\n" + ex.Message;
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
					_ErrorStr = "Ошибка при сохранении прихода...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

	/// <summary>
	/// сохранение одной состовляющей прихода - InputItems
	/// </summary>
	public bool InputsItemsSave(int? nInputItemID, int nInputID, int nPackingID, int nGoodStateID,  decimal nQnt,
		DateTime? dDateValid, int nCellID, int? nFrameID, decimal nFrameHeight, int nPalletTypeID, int nOwnerID, 
		int? nUserID, int? nDeviceID, bool bFrameArrange)
	{
		String _sqlCommand = "execute up_InputsItemsSave @nInputItemID output,  @nInputID, " +
				"@nPackingID, @nGoodStateID, " +
				"@nQnt, @dDateValid, " +
				"@nCellID, @nFrameID, " + 
				"@nFrameHeight, @nPalletTypeID, " + 
				"@nOwnerID, " +
				"@nUserID, @nDeviceID, @bFrameArrange, " +
				"@nError output, @cErrorText output";
		SqlCommand _oCommand = new SqlCommand(_sqlCommand, _Connect);
		_oCommand.CommandTimeout = 0;

		#region up_InputsItemsSave parameters
		
		SqlParameter _oParameter = _oCommand.Parameters.Add("@nInputItemID", SqlDbType.Int);
		if (nInputItemID.HasValue)
			_oCommand.Parameters["@nInputItemID"].Value = nInputItemID;
		else
			_oCommand.Parameters["@nInputItemID"].Value = DBNull.Value;

		_oParameter.Direction = ParameterDirection.InputOutput;	
		
		 _oParameter = _oCommand.Parameters.Add("@nInputID", SqlDbType.Int);
		_oParameter.Value = nInputID;

		 _oParameter = _oCommand.Parameters.Add("@nPackingID", SqlDbType.Int);
		_oParameter.Value = nPackingID;

		_oParameter = _oCommand.Parameters.Add("@nGoodStateID", SqlDbType.Int);
		_oParameter.Value = nGoodStateID;

		_oParameter = _oCommand.Parameters.Add("@nQnt", SqlDbType.Decimal);
		_oParameter.Value = nQnt;
 
 		_oParameter = _oCommand.Parameters.Add("@dDateValid", SqlDbType.DateTime);
		if (dDateValid.HasValue)
			_oCommand.Parameters["@dDateValid"].Value = dDateValid;
		else
			_oCommand.Parameters["@dDateValid"].Value = DBNull.Value;

		_oParameter = _oCommand.Parameters.Add("@nCellID", SqlDbType.Int);
		_oParameter.Value = nCellID;

		_oParameter = _oCommand.Parameters.Add("@nFrameID", SqlDbType.Int);
		if (nFrameID.HasValue)
			_oCommand.Parameters["@nFrameID"].Value = nFrameID;
		else
			_oCommand.Parameters["@nFrameID"].Value = DBNull.Value;

		_oParameter = _oCommand.Parameters.Add("@nFrameHeight", SqlDbType.Decimal);
		_oParameter.Value = nFrameHeight;

		_oParameter = _oCommand.Parameters.Add("@nPalletTypeID", SqlDbType.Int);
		_oParameter.Value = nPalletTypeID;

		_oParameter = _oCommand.Parameters.Add("@nOwnerID", SqlDbType.Int);
		_oParameter.Value = nOwnerID;


		_oParameter = _oCommand.Parameters.Add("@bFrameArrange", SqlDbType.Bit);
		_oParameter.Value = bFrameArrange;

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
			_ErrorStr = "Ошибка при сохранении состовляющей прихода...\r\n" + ex.Message;
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
				_ErrorStr = "Ошибка при сохранении составляющей прихода...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
		}
		return (_ErrorNumber == 0);
	}


		#endregion Save

		#region Confirm

		/// <summary>
		/// подтверждение прихода
		/// </summary>
		public bool ConfirmData(int nInputID, int nConfirmUserID)
		{
			string _sqlCommand = "execute up_InputsConfirm @nInputID, @nConfirmUserID, " +
									"@nError output, @cErrorStr output ";
			SqlCommand _oCommand = new SqlCommand(_sqlCommand, _Connect);
			_oCommand.CommandTimeout = 0;

			#region up_InputsConfirm parameters

			SqlParameter _oParameter = _oCommand.Parameters.Add("@nInputID", SqlDbType.Int);
			_oParameter.Value = nInputID;

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
				_oCommand.ExecuteScalar();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -11;
				_ErrorStr = "Ошибка при попытке подтверждения прихода...\r\n" + ex.Message;
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
					_ErrorStr = "Ошибка при подтверждении прихода...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		#endregion Confirm

		#region Delete 

		/// <summary>
		/// удаление прихода
		/// </summary>
		public bool DeleteData(int nInputID)
		{
			String _sqlCommand = "execute up_InputsDelete @nInputID, " +
					"@nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(_sqlCommand, _Connect);

			#region up_InputsDelete parameters

			SqlParameter _oParameter = _oCommand.Parameters.Add("@nInputID", SqlDbType.Int);
			_oParameter.Value = nInputID;
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
				_ErrorStr = "Ошибка при удалении прихода...\r\n" + ex.Message;
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
					_ErrorStr = "Ошибка при удалении прихода...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}
	/// <summary>
	/// удаление единицы прихода(InputsItems)
	/// </summary>
	public bool DeleteItem(int? nInputItemID)
		{
		String _sqlCommand = "execute up_InputsItemsDelete @nInputItemID, " +
				"@nError output, @cErrorText output";
		SqlCommand _oCommand = new SqlCommand(_sqlCommand, _Connect);

		#region up_InputsItemsDelete parameters

		SqlParameter _oParameter = _oCommand.Parameters.Add("@nInputItemID", SqlDbType.Int);
		_oParameter.Value = nInputItemID;
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
			_ErrorStr = "Ошибка при состовляющей удалении прихода...\r\n" + ex.Message;
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
				_ErrorStr = "Ошибка при удалении состовляющей прихода...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
				RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
		return (_ErrorNumber == 0);
		}

		#endregion Delete

		#region Set Date Time 

		/// <summary>
		/// отметить время начала обработки прихода
		/// </summary>

		public bool SetDateStart(int nInputID)
		{
			string sqlCommand = "update Inputs " +
				"set DateStart = GetDate() " +
				"where ID = " + nInputID.ToString() + " and DateStart is Null";
			SqlCommand _oCommand = new SqlCommand(sqlCommand, _Connect);
			try
			{
				_Connect.Open();
				_oCommand.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -23;
				_ErrorStr = "Ошибка при отметке времени начала обработки прихода...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// отметить время начала обработки прихода - конкретное
		/// </summary>
		public bool SetDateStart(int nInputID, DateTime dDateStart)
		{
			string sqlCommand = "set dateformat dmy " +
				"update Inputs " +
					"set DateStart = '" + dDateStart.ToString("dd.MM.yyyy HH:mm") + "' " +
					"where ID = " + nInputID.ToString() + " and DateStart is Null";

			SqlCommand _oCommand = new SqlCommand(sqlCommand, _Connect);
			try
			{
				_Connect.Open();
				_oCommand.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -23;
				_ErrorStr = "Ошибка при отметке времени начала обработки прихода...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// очистить время начала обработки прихода
		/// </summary>
		public bool ClearDateStart(int nInputID)
		{
			String _sqlCommand = "execute up_InputsDateStartClear @nInputID, " +
					"@nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(_sqlCommand, _Connect);

			SqlParameter _oParameter = _oCommand.Parameters.Add("@nInputID", SqlDbType.Int);
			_oParameter.Value = nInputID;
			_oParameter = _oCommand.Parameters.Add("@nError", SqlDbType.Int);
			_oParameter.Direction = ParameterDirection.InputOutput;
			_oParameter.Value = 0;
			_oParameter = _oCommand.Parameters.Add("@cErrorText", SqlDbType.VarChar, 200);
			_oParameter.Direction = ParameterDirection.InputOutput;
			_oParameter.Value = "";

			//string sqlCommand = "update Inputs " +
			//   "set DateStart = Null " +
			//   "where ID = " + nInputID.ToString() + " ";
			//SqlCommand _oCommand = new SqlCommand(sqlCommand, _Connect);
			try
			{
				_Connect.Open();
				//_oCommand.ExecuteNonQuery();
				_oCommand.ExecuteScalar();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -24;
				_ErrorStr = "Ошибка при очистке времени начала обработки прихода...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			return (_ErrorNumber == 0);
		}

		#endregion Set Date Time

		#region Loaders

		public bool UnloadersSave(int nInputID, DataTable tInputsUnloaders)
		{
			string sqlSelect = "execute up_InputsUnloadersSave @nInputID, " +
									"@nError output, @cErrorStr output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_InputsUnloadersSave paramaters

			_oCommand.Parameters.Add("@nInputID", SqlDbType.Int);
			_oCommand.Parameters["@nInputID"].Value = nInputID;

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
				RFMUtilities.DataTableToTempTable(tInputsUnloaders, "#InputsUnloaders", _Connect);
				_oCommand.ExecuteScalar();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -21;
				_ErrorStr = "Ошибка при сохранении данных о сотрудниках, выполнявших прием товара для прихода с кодом " + nInputID.ToString() + "...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr); // RaiseError
			}
			finally
			{
				_Connect.Close();
			}
			_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
			if (_ErrorNumber != 0)
			{
				_ErrorStr = "Ошибка при сохранении данных о сотрудниках, выполнявших прием товара для прихода с кодом " + nInputID.ToString() + "...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		public bool CoefficientUnloadSave(int nInputID, decimal nCoefficientUnload)
		{
			string sqlSelect = "update Inputs " +
				"set CoefficientUnload = " + nCoefficientUnload.ToString("#####0.0") + " " + 
				"where ID = " + nInputID.ToString();
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			try
			{
				_Connect.Open();
				_oCommand.ExecuteScalar();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -22;
				_ErrorStr = "Ошибка при сохранении коэффициента сложности разгрузки для прихода с кодом " + nInputID.ToString() + "...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			return (_ErrorNumber == 0);
		}

		public bool PalletsFactQntSave(int nInputID, int nPalletsFactQnt)
		{
			string sqlSelect = "update Inputs " +
				"set PalletsFactQnt = " + nPalletsFactQnt.ToString("#####0") + " " +
				"where ID = " + nInputID.ToString();
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			try
			{
				_Connect.Open();
				_oCommand.ExecuteScalar();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -23;
				_ErrorStr = "Ошибка при сохранении числа принятых поддонов для прихода с кодом " + nInputID.ToString() + "...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			return (_ErrorNumber == 0);
		}

		#endregion Unloaders

	}
}