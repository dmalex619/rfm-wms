using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

using RFMPublic;

/// <summary>
/// Бизнес-объект Задание (операция) на транспортировку контейнеров (Traffic)
/// </summary>
namespace WMSBizObjects
{
	public class TrafficFrame : BizObject
	{
		protected string _IDList;
		/// <summary>
		/// Список ID заданий на транспортировку контейнеров (TrafficsFrames.ID)
		/// </summary>
		[Description("Список ID заданий на транспортировку контейнеров (TrafficsFrames.ID)")]
		public string IDList { get { return _IDList; } set { _IDList = value; _NeedRequery = true; } }

		protected string _BarCode;
		/// <summary>
		/// Штрих-код задания (TrafficsFrames.BarCode), контекст
		/// </summary>
		[Description("Штрих-код задания (TrafficsFrames.BarCode), контекст")]
		public string BarCode { get { return _BarCode; } set { _BarCode = value; _NeedRequery = true; } }

		// Фильтры

		protected DateTime? _FilterDataBeg;
		/// <summary>
		/// Фильтр-поле: Начальная дата периода (TrafficsFrames.DateBirth)
		/// </summary>
		[Description("Фильтр-поле: Начальная дата периода")]
		public DateTime? FilterDateBeg { get { return _FilterDataBeg; } set { _FilterDataBeg = value; _NeedRequery = true; } }

		protected DateTime? _FilterDataEnd;
		/// <summary>
		/// Фильтр-поле: Конечная дата периода (TrafficsFrames.DateBirth)
		/// </summary>
		[Description("Фильтр-поле: Конечная дата периода")]
		public DateTime? FilterDateEnd { get { return _FilterDataEnd; } set { _FilterDataEnd = value; _NeedRequery = true; } }

		protected string _FilterUsersList;
		/// <summary>
		/// Фильтр-поле: Список ID пользователей (TrafficsFrames.UserID), через запятую
		/// </summary>
		[Description("Фильтр-поле: Список ID пользователей (TrafficsFrames.UserID), через запятую")]
		public string FilterUsersList { get { return _FilterUsersList; } set { _FilterUsersList = value; _NeedRequery = true; } }

		protected string _FilterDevicesList;
		/// <summary>
		/// Фильтр-поле: Список ID устройств (TrafficsFrames.DeviceID), через запятую
		/// </summary>
		[Description("Фильтр-поле: Список ID устройств (TrafficsFrames.DeviceID), через запятую")]
		public string FilterDevicesList { get { return _FilterDevicesList; } set { _FilterDevicesList = value; _NeedRequery = true; } }

		protected string _FilterFramesList;
		/// <summary>
		/// Фильтр-поле: Список ID контейнеров (TrafficsFrames.FrameID), через запятую
		/// </summary>
		[Description("Фильтр-поле: список ID контейнеров (TrafficsFrames.FrameID), через запятую")]
		public string FilterFramesList { get { return _FilterFramesList; } set { _FilterFramesList = value; _NeedRequery = true; } }

		protected string _FilterFramesBarCodeContext;
		/// <summary>
		/// Фильтр-поле: Штрих-код контейнера (TrafficsFrames.FrameID -> Frames.BarCode), контекст 
		/// </summary>
		[Description("Фильтр-поле: Штрих-код контейнера (TrafficsFrames.FrameID -> Frames.BarCode), контекст")]
		public string FilterFramesBarCodeContext { get { return _FilterFramesBarCodeContext; } set { _FilterFramesBarCodeContext = value; _NeedRequery = true; } }

		protected string _FilterCellsSourceList;
		/// <summary>
		/// Фильтр-поле: Список ID ячеек-источников (TrafficsFrames.CellSourceID), через запятую
		/// </summary>
		[Description("Фильтр-поле: Список ID ячеек-источников (TrafficsFrames.CellSourceID), через запятую")]
		public string FilterCellsSourceList { get { return _FilterCellsSourceList; } set { _FilterCellsSourceList = value; _NeedRequery = true; } }

		protected string _FilterCellsTargetList;
		/// <summary>
		/// Фильтр-поле: Список ID ячеек-приемников (TrafficsFrames.CellTargetID), через запятую
		/// </summary>
		[Description("Фильтр-поле: Список ID ячеек-приемников (TrafficsFrames.CellTargetID), через запятую")]
		public string FilterCellsTargetList { get { return _FilterCellsTargetList; } set { _FilterCellsTargetList = value; _NeedRequery = true; } }

		protected string _FilterStoresZonesSourceList;
		/// <summary>
		/// Фильтр-поле: Список ID складских зон-источников (TrafficsFrames.CellSourceID - Cells.StoreZoneID), через запятую
		/// </summary>
		[Description("Фильтр-поле: Список ID складских зон-источников (TrafficsFrames.CellSourceID - Cells.StoreZoneID), через запятую")]
		public string FilterStoresZonesSourceList { get { return _FilterStoresZonesSourceList; } set { _FilterStoresZonesSourceList = value; _NeedRequery = true; } }

		protected string _FilterStoresZonesTargetList;
		/// <summary>
		/// Фильтр-поле: Список ID складских зон-приемников (TrafficsFrames.CellTargetID -> Cells.StoreZoneID), через запятую
		/// </summary>
		[Description("Фильтр-поле: Список ID складских зон-приемников (TrafficsFrames.CellTargetID -> Cells.StoreZoneID), через запятую")]
		public string FilterStoresZonesTargetList { get { return _FilterStoresZonesTargetList; } set { _FilterStoresZonesTargetList = value; _NeedRequery = true; } }

		protected string _FilterStoresZonesTypesSourceList;
		/// <summary>
		/// Фильтр-поле: Список ID типов складских зон-источников (TrafficsFrames.CellSourceID -> Cells.StoreZoneID -> StoresZones.StoreZoneTypeID), через запятую
		/// </summary>
		[Description("Фильтр-поле: Список ID типов складских зон-источников (TrafficsFrames.CellSourceID -> Cells.StoreZoneID -> StoresZones.StoreZoneTypeID), через запятую")]
		public string FilterStoresZonesTypesSourceList { get { return _FilterStoresZonesTypesSourceList; } set { _FilterStoresZonesTypesSourceList = value; _NeedRequery = true; } }

		protected string _FilterStoresZonesTypesTargetList;
		/// <summary>
		/// Фильтр-поле: Список ID типов складских зон-приемников (TrafficsFrames.CellTargetID -> Cells.StoreZoneID -> StoresZones.StoreZoneTypeID), через запятую
		/// </summary>
		[Description("Фильтр-поле: Список ID типов складских зон-приемников (TrafficsFrames.CellTargetID -> Cells.StoreZoneID -> StoresZones.StoreZoneTypeID), через запятую")]
		public string FilterStoresZonesTypesTargetList { get { return _FilterStoresZonesTypesTargetList; } set { _FilterStoresZonesTypesTargetList = value; _NeedRequery = true; } }

		protected bool? _FilterConfirmed;
		/// <summary>
		/// Фильтр-поле: Задания выполнены (TrafficsFrames.DateConfirm)?
		/// </summary>
		[Description("Фильтр-поле: Задания выполнены (TrafficsFrames.DateConfirm)?")]
		public bool? FilterConfirmed { get { return _FilterConfirmed; } set { _FilterConfirmed = value; _NeedRequery = true; } }

		protected bool? _FilterAccepted;
		/// <summary>
		/// Фильтр-поле: Задания начаты (TrafficsFrames.DateAccept)?
		/// </summary>
		[Description("Фильтр-поле: Задания начаты (TrafficsFrames.DateAccept)?")]
		public bool? FilterAccepted { get { return _FilterAccepted; } set { _FilterAccepted = value; _NeedRequery = true; } }

		protected bool? _FilterSuccess;
		/// <summary>
		/// Фильтр-поле: успешно завершено (TrafficsFrames.Success)?
		/// </summary>
		[Description("Фильтр-поле: успешно завершено?")]
		public bool? FilterSuccess { get { return _FilterSuccess; } set { _FilterSuccess = value; _NeedRequery = true; } }

		protected string _FramesContents_FilterPackingsList;
		/// <summary>
		/// Фильтр-поле таблицы содержимого контейнеров: Список ID упаковок (CellsContents.PackingID), через запятую
		/// </summary>
		[Description("Фильтр-поле таблицы содержимого контейнеров: Список ID упаковок (CellsContents.PackingID), через запятую")]
		public string FramesContents_FilterPackingsList { get { return _FramesContents_FilterPackingsList; } set { _FramesContents_FilterPackingsList = value; _NeedRequery = true; } }

		protected string _FramesContents_FilterGoodsList;
		/// <summary>
		/// Фильтр-поле таблицы содержимого контейнеров: Список ID товаров (CellsContents.PackingID -> Packings.GoodID), через запятую
		/// </summary>
		[Description("Фильтр-поле таблицы содержимого контейнеров: Список ID товаров (CellsContents.PackingID - >Packings.GoodID), через запятую")]
		public string FramesContents_FilterGoodsList { get { return _FramesContents_FilterGoodsList; } set { _FramesContents_FilterGoodsList = value; _NeedRequery = true; } }

		protected string _FilterErrorsList;
		/// <summary>
		/// Фильтр-поле: Список ID типов ошибок (TrafficsFrames.ErrorID), через запятую
		/// </summary>
		[Description("Фильтр-поле: Список ID типов ошибок (TrafficsFrames.ErrorID), через запятую")]
		public string FilterErrorsList { get { return _FilterErrorsList; } set { _FilterErrorsList = value; _NeedRequery = true; } }

		// Tables

		protected DataTable _TableTrafficsFramesErrors;
		/// <summary>
		/// Таблица ошибок(проблем) при "отрицательном" подтверждении (TrafficsFramesErrors)
		/// </summary>
		[Description("Таблица ошибок(проблем) при _отрицательном_ подтверждении (TrafficsFramesErrors)")]
		public DataTable TableTrafficsFramesErrors { get { return _TableTrafficsFramesErrors; } }

		protected string _FilterInputsList;
		/// <summary>
		/// Фильтр-поле: Список ID приходов (TrafficsGoods.InputID), через запятую
		/// </summary>
		[Description("Фильтр-поле: приходов (TrafficsGoods.InputID), через запятую")]
		public string FilterInputsList { get { return _FilterInputsList; } set { _FilterInputsList = value; _NeedRequery = true; } }

		protected string _FilterOutputsList;
		/// <summary>
		/// Фильтр-поле: Список ID расходов (TrafficsGoods.OutputID), через запятую
		/// </summary>
		[Description("Фильтр-поле: расходов (TrafficsGoods.OutputID), через запятую")]
		public string FilterOutputsList { get { return _FilterOutputsList; } set { _FilterOutputsList = value; _NeedRequery = true; } }

		// -------------------------------------

		public TrafficFrame()
			: base()
		{
			_MainTableName = "TrafficsFrames";
		}

		/// <summary>
		/// получение списка заданий на транспортировку контейнеров (MainTable)
		/// </summary>
		public override bool FillData()
		{
			ClearData();

			string sqlSelect = "execute up_TrafficsFramesFill " +
				"@nID, @cIDList, " +
				"@bConfirmed, @bSuccess, @cErrorsList, @bAccepted, " +
				"@dDateBeg, @dDateEnd, " +
				"@cUsersList, @cDevicesList, " +
				"@cFramesList, @cFramesBarCodeContext, " +
				"@cCellsSourceList, @cCellsTargetList, " +
				"@cStoresZonesSourceList, @cStoresZonesTargetList, " +
				"@cStoresZonesTypesSourceList, @cStoresZonesTypesTargetList, " +
				"@cPackingsList, @cGoodsList, " +
				"@cInputsList, @cOutputsList";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_TrafficsFramesFill parameters

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

			_oCommand.Parameters.Add("@cErrorsList", SqlDbType.VarChar);
			if (_FilterErrorsList != null)
				_oCommand.Parameters["@cErrorsList"].Value = _FilterErrorsList;
			else
				_oCommand.Parameters["@cErrorsList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bAccepted", SqlDbType.Bit);
			if (_FilterAccepted.HasValue)
				_oCommand.Parameters["@bAccepted"].Value = _FilterAccepted;
			else
				_oCommand.Parameters["@bAccepted"].Value = DBNull.Value;

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

			_oCommand.Parameters.Add("@cFramesList", SqlDbType.VarChar);
			if (_FilterFramesList != null)
				_oCommand.Parameters["@cFramesList"].Value = _FilterFramesList;
			else
				_oCommand.Parameters["@cFramesList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cFramesBarCodeContext", SqlDbType.VarChar);
			if (_FilterFramesBarCodeContext != null)
				_oCommand.Parameters["@cFramesBarCodeContext"].Value = _FilterFramesBarCodeContext;
			else
				_oCommand.Parameters["@cFramesBarCodeContext"].Value = DBNull.Value;

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

			#region up_TrafficsFramesFill FramesContents-parameters

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

			#endregion

			_oCommand.Parameters.Add("@cInputsList", SqlDbType.VarChar);
			if (_FilterInputsList != null)
				_oCommand.Parameters["@cInputsList"].Value = _FilterInputsList;
			else
				_oCommand.Parameters["@cInputsList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cOutputsList", SqlDbType.VarChar);
			if (_FilterOutputsList != null)
				_oCommand.Parameters["@cOutputsList"].Value = _FilterOutputsList;
			else
				_oCommand.Parameters["@cOutputsList"].Value = DBNull.Value;

			#endregion

			try
			{
				_MainTable = FillReadings(new SqlDataAdapter(_oCommand), _MainTable, _MainTableName);
				_NeedRequery = true;
			}
			catch (Exception ex)
			{
				_ErrorNumber = -1;
				_ErrorStr = "Ошибка при получении списка заданий на транспортировку контейнеров...\r\n" + ex.Message;
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
			_FilterSuccess = null;
			_FilterConfirmed = null;
			_FilterAccepted = null;
			_FilterDataBeg = null;
			_FilterDataEnd = null;
			_FilterUsersList = null;
			_FilterDevicesList = null;
			_FilterFramesList = null;
			_FilterFramesBarCodeContext = null;
			_FilterCellsSourceList = null;
			_FilterCellsTargetList = null;
			_FilterStoresZonesSourceList = null;
			_FilterStoresZonesTargetList = null;
			_FilterStoresZonesTypesSourceList = null;
			_FilterStoresZonesTypesTargetList = null;
			_FilterErrorsList = null;
			_FilterInputsList = null;
			_FilterOutputsList = null;
			_FramesContents_FilterGoodsList = null;
			_FramesContents_FilterPackingsList = null;
		}

		/// <summary>
		/// получение таблицы ошибок(проблем) при отрицательном завершении (TableTrafficsFramesErrors)
		/// </summary>
		public bool FillTableTrafficsFramesErrors()
		{
			string sqlSelect = "select TE.ID, TE.Name, " +
					"TE.LockFrame, TE.LockCellSource, TE.LockCellTarget, " +
					"TE.Severity " +
				"from TrafficsFramesErrors TE " +
				"where 1 = 1 ";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			try
			{
				_TableTrafficsFramesErrors = FillReadings(new SqlDataAdapter(_oCommand), _TableTrafficsFramesErrors, "TableTrafficsFramesErrors");

				// primarykey
				DataColumn[] pk = new DataColumn[1];
				pk[0] = _TableTrafficsFramesErrors.Columns[0];
				_TableTrafficsFramesErrors.PrimaryKey = pk;
			}
			catch (Exception ex)
			{
				_ErrorNumber = -11;
				_ErrorStr = "Ошибка при получении списка ошибок(проблем) при подтверждении..." + Convert.ToChar(13) + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}


		/// <summary>
		/// подтверждение выполнения задания на транспортировку контейнера
		/// </summary>
		public bool ConfirmData(int nTrafficID, int nCellFinishID, bool bSuccess, int? nTrafficErrorID)
		{
			string _sqlCommand = "execute up_TrafficsFramesConfirm @nTrafficID, " +
									"@bSuccess, " +
									"@nCellFinishID, " +
									"@nTrafficErrorID, " +
									"@nError output, @cErrorStr output";

			SqlCommand _oCommand = new SqlCommand(_sqlCommand, _Connect);

			#region up_TrafficsFramesConfirm parameters

			SqlParameter _oParameter = _oCommand.Parameters.Add("@nTrafficID", SqlDbType.Int);
			_oParameter.Value = nTrafficID;

			_oParameter = _oCommand.Parameters.Add("@bSuccess", SqlDbType.Bit);
			_oParameter.Value = bSuccess;

			_oParameter = _oCommand.Parameters.Add("@nCellFinishID", SqlDbType.Int);
			_oParameter.Value = nCellFinishID;

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
				_ErrorStr = "Ошибка при подтверждении выполнения задания на транспортировку контейнера...\r\n" + ex.Message;
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
					_ErrorStr = "Ошибка при подтверждении выполнения задания на транспортировку контейнера...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
					//RFMMessage.MessageBoxError(_ErrorStr); //RaisError
				}
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// подтверждение выполнения задания на транспортировку контейнера - 
		/// с указанием количества, перемещаемого в пикинг, и созданием нового трафика 
		/// </summary>
		public bool ConfirmPartialData(int nTrafficID, int nCellFinishID, bool bSuccess, int? nTrafficErrorID,
			decimal nQnt, ref int? nNewTrafficID)
		{
			string _sqlCommand = "execute up_TrafficsFramesConfirmPartial @nTrafficID, " +
									"@bSuccess, " +
									"@nCellFinishID, " +
									"@nTrafficErrorID, " +
									"@nQnt, " +
									"@nNewTrafficID output, " + 
									"@nError output, @cErrorStr output";

			SqlCommand _oCommand = new SqlCommand(_sqlCommand, _Connect);

			#region up_TrafficsFramesConfirmPartial parameters

			SqlParameter _oParameter = _oCommand.Parameters.Add("@nTrafficID", SqlDbType.Int);
			_oParameter.Value = nTrafficID;

			_oParameter = _oCommand.Parameters.Add("@bSuccess", SqlDbType.Bit);
			_oParameter.Value = bSuccess;

			_oParameter = _oCommand.Parameters.Add("@nCellFinishID", SqlDbType.Int);
			_oParameter.Value = nCellFinishID;

			_oParameter = _oCommand.Parameters.Add("@nTrafficErrorID", SqlDbType.Int);
			if (nTrafficErrorID.HasValue)
				_oParameter.Value = nTrafficErrorID;
			else
				_oParameter.Value = DBNull.Value;

			_oParameter = _oCommand.Parameters.Add("@nQnt", SqlDbType.Decimal);
			_oParameter.Precision = 12;
			_oParameter.Scale = 3;
			_oParameter.Value = nQnt;

			_oParameter = _oCommand.Parameters.Add("@nNewTrafficID", SqlDbType.Int);
			_oParameter.Direction = ParameterDirection.InputOutput;
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
				_ErrorStr = "Ошибка при подтверждении выполнения задания на транспортировку контейнера (с указанием количества)...\r\n" + ex.Message;
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
					if (_ErrorNumber < -100)
					{
						_ErrorStr = "Ошибка при подборе места и создании новой транспортировки контейнера...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
						RFMMessage.MessageBoxError(_ErrorStr); //RaisError нет!
					}
					else
					{
						_ErrorStr = "Ошибка при подтверждении выполнения задания на транспортировку контейнера (с указанием количества)...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
						RFMMessage.MessageBoxError(_ErrorStr); // вообще-то есть RaisError!
					}
				}
				else
				{
					if (!Convert.IsDBNull(_oCommand.Parameters["@nNewTrafficID"].Value))
						nNewTrafficID = (int)_oCommand.Parameters["@nNewTrafficID"].Value;
				}
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// Изменение приоритета задания на транспортировку контейнера 
		/// </summary>
		/// <param name="nTrafficID">ID задания на транспортировку контейнера(TrafficsFrames.ID)</param>
		/// <param name="nShift">Изменение приоритета (+1, -1, ...)</param>
		/// <returns></returns>
		public bool PriorityChange(int nTrafficID, int nShift)
		{
			string sqlCommand = "update TrafficsFrames " +
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
				_ErrorStr = "Ошибка при изменении приоритета\nзадания на транспортировку контейнера...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// Отметка времени начала обработки (выполнения) задания на транспортировку контейнера
		/// </summary>
		/// <param name="nTrafficID">ID задания на транспортировку контейнера (TrafficsFrames.ID)</param>
		/// <returns></returns>
		public bool SetDateAccept(int nTrafficID)
		{
			string sqlCommand = "update TrafficsFrames " +
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
				_ErrorStr = "Ошибка при отметке времени начала обработки задания на транспортировку контейнера...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// Очистка времени начала обработки (выполнения) и пользователя дял задания на транспортировку контейнера
		/// </summary>
		/// <param name="nTrafficID">ID задания на транспортировку контейнера (TrafficsFrames.ID)</param>
		/// <returns></returns>
		public bool ClearDateAccept(int nTrafficID)
		{
			string sqlCommand = "update TrafficsFrames " +
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
				_ErrorStr = "Ошибка при очистке времени начала обработки задания на транспортировку контейнера...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// изменение параметров задания на транспортировку контейнера: пользователь, устройство, ошибка подтверждения
		/// </summary>
		public bool SaveDataPartial(int nTrafficID,
				int? nCellFinishID, 
				int? nUserID, int? nDeviceID, int? nPriority, 
				int? nTrafficErrorID)
		{
			string _sqlCommand = "execute up_TrafficsFramesSavePartial @nTrafficID, " +
									"@nCellFinishID, " +
									"@nUserID, @nDeviceID, @nPriority, " +
									"@nTrafficErrorID, " +
									"@nError output, @cErrorStr output";

			SqlCommand _oCommand = new SqlCommand(_sqlCommand, _Connect);

			#region up_TrafficsFramesSavePartial parameters

			_oCommand.Parameters.Add("@nTrafficID", SqlDbType.Int);
			_oCommand.Parameters["@nTrafficID"].Value = nTrafficID;

			_oCommand.Parameters.Add("@nCellFinishID", SqlDbType.Int);
			if (nCellFinishID.HasValue)
				_oCommand.Parameters["@nCellFinishID"].Value = nCellFinishID;
			else
				_oCommand.Parameters["@nCellFinishID"].Value = DBNull.Value;

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
				_ErrorStr = "Ошибка при сохранении/регистрации задания на транспортировку контейнера...\r\n" + ex.Message;
				//RFMMessage.MessageBoxError(_ErrorStr); //RaisError
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
					_ErrorStr = "Ошибка при сохранении/регистрации задания на транспортировку контейнера...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// Удаление одного задания на транспортировку контейнера
		/// </summary>
		/// <param name="nTrafficID">ID задания на транспортировку контейнера (TrafficsFrames.ID)</param>
		/// <returns></returns>
		public bool DeleteOne(int nTrafficID)
		{
			string sqlSelect = "execute up_TrafficsFramesDelete @nTrafficID, " +
									"@nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_TrafficsFramesDelete paramaters

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
				_ErrorStr = "Ошибка при удалении задания с кодом " + nTrafficID.ToString() + " на транспортировку контейнера...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
			if (_ErrorNumber != 0)
			{
				_ErrorStr = "Ошибка при удалении задания с кодом " + nTrafficID.ToString() + " на транспортировку контейнера...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// "ручное" создание транспортировки контейнера
		/// </summary>
		public bool CreateManual(int nFrameID, int? nCellTargetID, int nPriority, bool? bFrameDestroy)
		{

			string sqlSelect = "execute up_TrafficsFramesCreateManual " +
									"@nFrameID, @nCellTargetID, @nPriority, @bFrameDestroy, " +
									"@nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_TrafficsFrameCreateManual paramaters

			_oCommand.Parameters.Add("@nFrameID", SqlDbType.Int);
			_oCommand.Parameters["@nFrameID"].Value = nFrameID;

			_oCommand.Parameters.Add("@nCellTargetID", SqlDbType.Int);
			if (nCellTargetID.HasValue)
				_oCommand.Parameters["@nCellTargetID"].Value = nCellTargetID;
			else
				_oCommand.Parameters["@nCellTargetID"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@nPriority", SqlDbType.Int);
			_oCommand.Parameters["@nPriority"].Value = nPriority;

			_oCommand.Parameters.Add("@bFrameDestroy", SqlDbType.Bit);
			if (bFrameDestroy.HasValue)
				_oCommand.Parameters["@bFrameDestroy"].Value = bFrameDestroy;
			else
				_oCommand.Parameters["@bFrameDestroy"].Value = DBNull.Value;

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
				_ErrorStr = "Ошибка при попытке создания операции транспортировки контейнера...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
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
					_ErrorStr = "Ошибка при подборе ячейки при создании операции транспортировки контейнера...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
				else
				{
					_ErrorStr = "Ошибка при создании операции транспортировки контейнера...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
				}
				//RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// "ручное" создание транспортировки контейнера, без проверок приемной ячейки
		/// </summary>
		public bool CreateManualDirect(int nFrameID, int nCellTargetID, int nPriority, string sNote)
		{
			string sqlSelect = "execute up_TrafficsFramesCreateManualDirect " +
									"@nFrameID, @nCellTargetID, " +
									"@nPriority, @cNote, " +
									"@nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_TrafficsFrameCreateManualDirect paramaters

			_oCommand.Parameters.Add("@nFrameID", SqlDbType.Int);
			_oCommand.Parameters["@nFrameID"].Value = nFrameID;

			_oCommand.Parameters.Add("@nCellTargetID", SqlDbType.Int);
			_oCommand.Parameters["@nCellTargetID"].Value = nCellTargetID;

			_oCommand.Parameters.Add("@nPriority", SqlDbType.Int);
			_oCommand.Parameters["@nPriority"].Value = nPriority;

			_oCommand.Parameters.Add("@cNote", SqlDbType.VarChar);
			_oCommand.Parameters["@cNote"].Value = sNote;

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
				_ErrorStr = "Ошибка при попытке создания операции транспортировки контейнера в ячейку...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
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
					_ErrorStr = "Ошибка при подборе ячейки при создании операции транспортировки контейнера в ячейку...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
				else
				{
					_ErrorStr = "Ошибка при создании операции транспортировки контейнера в ячейку...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
				}
				//RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}
	}
}