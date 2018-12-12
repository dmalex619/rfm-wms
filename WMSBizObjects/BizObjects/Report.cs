using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

using RFMPublic;

/// <summary>
/// Бизнес-объект Отчет (Report)
/// </summary>
/// 
namespace WMSBizObjects
{
	public class Report : BizObject
	{
		protected DataTable _TableReport;
		/// <summary>
		/// Таблица данных - результат отчета, дополнительно к MainTable
		/// </summary>
		[Description("Таблица данных - результат отчета, дополнительно к MainTable")]
		public DataTable TableReport { get { return _TableReport; } }

		// ----------------------------

		public Report() : base()
		{
			_MainTableName = "Report";
		}

		public override bool FillData()
		{
			ClearData();
			return (_ErrorNumber == 0);
		}

		public void ClearTableReport()
		{
			if (_DS.Tables["TableReport"] != null)
				_DS.Tables.Remove("TableReport");
			_TableReport = null;
		}

		// -- REPORTS ---------------------------------------------------------------

		/// <summary>
		/// История операций с ячейками / контейнерами
		/// </summary>
		public bool ReportCellsFramesHistory
			(DataTable tableCells, DataTable tableFrames,
			DateTime? dDateBeg, DateTime? dDateEnd,
			bool bTraffics, bool bChanges,
			string sOwnersList, string sGoodsStatesList, string sPackingsList, string sUsersList)
		{
			ClearData();

			string sqlSelect;
			SqlCommand _oCommand;

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

			// по таблице ячеек
			if (tableCells.Rows.Count > 0)
			{
				// оставляем из переданной таблицы только одну колонку CellID
				for (int i = tableCells.Columns.Count - 1; i >= 0; i--)
				{
					if (tableCells.Columns[i].ColumnName != "ID" &&
						tableCells.Columns[i].ColumnName != "CellID")
						tableCells.Columns.Remove(tableCells.Columns[i]);
				}
				if (!RFMUtilities.DataTableToTempTable(tableCells, "#CellsIDList", _Connect))
				{
					RFMMessage.MessageBoxError("Ошибка при подготовке временной таблицы ячеек (история)...");
					_Connect.Close();
					return (false);
				}
			}
			else
			{
				sqlSelect = "if object_id('tempdb..#CellsIDList') is not Null " +
								"drop table #CellsIDList";
				try
				{
					_oCommand = new SqlCommand(sqlSelect, _Connect);
					_oCommand.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					_ErrorNumber = -2;
					_ErrorStr = "Ошибка при очистке временной таблицы ячеек...\n" + ex.Message;
					RFMMessage.MessageBoxError(_ErrorStr);
					_Connect.Close();
					return (false);
				}
			}

			if (tableFrames.Rows.Count > 0)
			{
				// оставляем из переданной таблицы только одну колонку FrameID
				for (int i = tableFrames.Columns.Count - 1; i >= 0; i--)
				{
					if (tableFrames.Columns[i].ColumnName != "ID" &&
						tableFrames.Columns[i].ColumnName != "FrameID")
						tableFrames.Columns.Remove(tableFrames.Columns[i]);
				}
				if (!RFMUtilities.DataTableToTempTable(tableFrames, "#FramesIDList", _Connect))
				{
					RFMMessage.MessageBoxError("Ошибка при подготовке временной таблицы контейнеров (история)...");
					_Connect.Close();
					return (false);
				}
			}
			else
			{
				sqlSelect = "if object_id('tempdb..#FramesIDList') is not Null " +
								"drop table #FramesIDList";
				try
				{
					_oCommand = new SqlCommand(sqlSelect, _Connect);
					_oCommand.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					_ErrorNumber = -3;
					_ErrorStr = "Ошибка при очистке временной таблицы контейнеров...\n" + ex.Message;
					RFMMessage.MessageBoxError(_ErrorStr);
					_Connect.Close();
					return (false);
				}
			}

			sqlSelect = "execute up_ReportCellsFramesHistory " +
									"@dDateBeg, @dDateEnd, " +
									"@bTraffics, @bChanges, " +
									"@cOwnersList, @cGoodsStatesList, " +
									"@cPackingsList, @cUsersList";
			_oCommand = new SqlCommand(sqlSelect, _Connect);
			_oCommand.CommandTimeout = 0;

			#region up_ReportCellsFramesHistory paramaters

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

			_oCommand.Parameters.Add("@bTraffics", SqlDbType.Bit);
			_oCommand.Parameters["@bTraffics"].Value = bTraffics;

			_oCommand.Parameters.Add("@bChanges", SqlDbType.Bit);
			_oCommand.Parameters["@bChanges"].Value = bChanges;

			_oCommand.Parameters.Add("@cOwnersList", SqlDbType.VarChar);
			if (sOwnersList != null)
				_oCommand.Parameters["@cOwnersList"].Value = sOwnersList;
			else
				_oCommand.Parameters["@cOwnersList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cGoodsStatesList", SqlDbType.VarChar);
			if (sGoodsStatesList != null)
				_oCommand.Parameters["@cGoodsStatesList"].Value = sGoodsStatesList;
			else
				_oCommand.Parameters["@cGoodsStatesList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cPackingsList", SqlDbType.VarChar);
			if (sPackingsList != null)
				_oCommand.Parameters["@cPackingsList"].Value = sPackingsList;
			else
				_oCommand.Parameters["@cPackingsList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cUsersList", SqlDbType.VarChar);
			if (sUsersList != null)
				_oCommand.Parameters["@cUsersList"].Value = sUsersList;
			else
				_oCommand.Parameters["@cUsersList"].Value = DBNull.Value;

			#endregion

			try
			{
				_MainTable = FillReadings(new SqlDataAdapter(_oCommand), _MainTable, _MainTableName);
				_NeedRequery = false;
			}
			catch (Exception ex)
			{
				_ErrorNumber = -10;
				_ErrorStr = "Ошибка при получении истории ячеек/контейнеров...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			return (_ErrorNumber == 0);
		}


		// --------------------------------------------------------------------

		/// <summary>
		/// Операции транспортировки
		/// </summary>
		public bool ReportTraffics
			(string sMode,
			DataTable tableCellsSource, DataTable tableCellsTarget, 
			DateTime? dDateBegBirth, DateTime? dDateEndBirth,
			DateTime? dDateBegConfirm, DateTime? dDateEndConfirm,
			bool? bConfirmed, bool? bSuccess, string sErrorsList, 
			string sUsersList, string sDevicesList, 
			string sFrameBarCodeContext,
			string sPackingsList
			)
		{
			ClearData();

			string sqlSelect;
			SqlCommand _oCommand;
			bool bConnectOpen = false;

			// по таблице ячеек-источников
			if (tableCellsSource.Rows.Count > 0)
			{
				if (!bConnectOpen)
				{
					try
					{
						_Connect.Open();
						bConnectOpen = true;
					}
					catch (Exception ex)
					{
						_ErrorNumber = -1;
						_ErrorStr = "Ошибка при соединении с сервером...\n" + ex.Message;
						RFMMessage.MessageBoxError(_ErrorStr);
						return (false);
					}
				}
				// оставляем из переданной таблицы только одну колонку CellID
				for (int i = tableCellsSource.Columns.Count - 1; i >= 0; i--)
				{
					if (tableCellsSource.Columns[i].ColumnName != "ID" &&
						tableCellsSource.Columns[i].ColumnName != "CellID")
						tableCellsSource.Columns.Remove(tableCellsSource.Columns[i]);
				}
				if (!RFMUtilities.DataTableToTempTable(tableCellsSource, "#CellsSourceIDList", _Connect))
				{
					RFMMessage.MessageBoxError("Ошибка при подготовке временной таблицы ячеек-источников...");
					return (false);
				}
			}

			// по таблице ячеек-приемников
			if (tableCellsTarget.Rows.Count > 0)
			{
				if (!bConnectOpen)
				{
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
				}
				// оставляем из переданной таблицы только одну колонку CellID
				for (int i = tableCellsTarget.Columns.Count - 1; i >= 0; i--)
				{
					if (tableCellsTarget.Columns[i].ColumnName != "ID" &&
						tableCellsTarget.Columns[i].ColumnName != "CellID")
						tableCellsTarget.Columns.Remove(tableCellsTarget.Columns[i]);
				}
				if (!RFMUtilities.DataTableToTempTable(tableCellsTarget, "#CellsTargetIDList", _Connect))
				{
					RFMMessage.MessageBoxError("Ошибка при подготовке временной таблицы ячеек-приемников...");
					return (false);
				}
			}

			sqlSelect = "execute up_ReportTraffics " +
									"@cMode, " +
									"@dDateBegBirth, @dDateEndBirth, " +
									"@dDateBegConfirm, @dDateEndConfirm, " +
									"@bConfirmed, @bSuccess, @cErrorsList, " +
									"@cUsersList, @cDevicesList, " +
									"@cFrameBarCodeContext, " +
									"@cPackingsList";
			_oCommand = new SqlCommand(sqlSelect, _Connect);
			_oCommand.CommandTimeout = 0;

			#region up_ReportTraffics paramaters

			_oCommand.Parameters.Add("@cMode", SqlDbType.VarChar);
			if (sMode != null)
				_oCommand.Parameters["@cMode"].Value = sMode;
			else
				_oCommand.Parameters["@cMode"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@dDateBegBirth", SqlDbType.SmallDateTime);
			if (dDateBegBirth != null)
				_oCommand.Parameters["@dDateBegBirth"].Value = dDateBegBirth;
			else
				_oCommand.Parameters["@dDateBegBirth"].Value = DBNull.Value;
			_oCommand.Parameters.Add("@dDateEndBirth", SqlDbType.SmallDateTime);
			if (dDateEndBirth != null)
				_oCommand.Parameters["@dDateEndBirth"].Value = dDateEndBirth;
			else
				_oCommand.Parameters["@dDateEndBirth"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@dDateBegConfirm", SqlDbType.SmallDateTime);
			if (dDateBegConfirm != null)
				_oCommand.Parameters["@dDateBegConfirm"].Value = dDateBegConfirm;
			else
				_oCommand.Parameters["@dDateBegConfirm"].Value = DBNull.Value;
			_oCommand.Parameters.Add("@dDateEndConfirm", SqlDbType.SmallDateTime);
			if (dDateEndConfirm != null)
				_oCommand.Parameters["@dDateEndConfirm"].Value = dDateEndConfirm;
			else
				_oCommand.Parameters["@dDateEndConfirm"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bConfirmed", SqlDbType.Bit);
			if (bConfirmed != null)
				_oCommand.Parameters["@bConfirmed"].Value = bConfirmed;
			else
				_oCommand.Parameters["@bConfirmed"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bSuccess", SqlDbType.Bit);
			if (bSuccess != null)
				_oCommand.Parameters["@bSuccess"].Value = bSuccess;
			else
				_oCommand.Parameters["@bSuccess"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cErrorsList", SqlDbType.VarChar);
			if (sErrorsList != null)
				_oCommand.Parameters["@cErrorsList"].Value = sErrorsList;
			else
				_oCommand.Parameters["@cErrorsList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cUsersList", SqlDbType.VarChar);
			if (sUsersList != null)
				_oCommand.Parameters["@cUsersList"].Value = sUsersList;
			else
				_oCommand.Parameters["@cUsersList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cDevicesList", SqlDbType.VarChar);
			if (sDevicesList != null)
				_oCommand.Parameters["@cDevicesList"].Value = sDevicesList;
			else
				_oCommand.Parameters["@cDevicesList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cFrameBarCodeContext", SqlDbType.VarChar);
			if (sFrameBarCodeContext != null)
				_oCommand.Parameters["@cFrameBarCodeContext"].Value = sFrameBarCodeContext;
			else
				_oCommand.Parameters["@cFrameBarCodeContext"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cPackingsList", SqlDbType.VarChar);
			if (sPackingsList != null)
				_oCommand.Parameters["@cPackingsList"].Value = sPackingsList;
			else
				_oCommand.Parameters["@cPackingsList"].Value = DBNull.Value;

			#endregion

			try
			{
				_MainTable = FillReadings(new SqlDataAdapter(_oCommand), _MainTable, _MainTableName);
				_NeedRequery = false;
			}
			catch (Exception ex)
			{
				_ErrorNumber = -1;
				_ErrorStr = "Ошибка при получении операций транспортировки/перемещения...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			return (_ErrorNumber == 0);
		}


		// --------------------------------------------------------------------

		/// <summary>
		/// Оборотная ведомость (остатки и операции за период)
		/// </summary>
		public bool ReportOddmentsBalance
			(DateTime? dDateBeg, DateTime? dDateEnd,
			string sOwnersList, string sGoodsStatesList, string sPackingsList, 
			bool bGroupOwner, int nMode)
		{
			ClearData();

			string sqlSelect = "execute up_ReportOddmentsBalance " +
									"@dDateBeg, @dDateEnd, " +
									"@cOwnersList, @cGoodsStatesList, @cPackingsList, " +
									"@bGroupOwner, @nMode";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);
			_oCommand.CommandTimeout = 0;

			#region up_ReportOddmentsBalance paramaters

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

			_oCommand.Parameters.Add("@cOwnersList", SqlDbType.VarChar);
			if (sOwnersList != null)
				_oCommand.Parameters["@cOwnersList"].Value = sOwnersList;
			else
				_oCommand.Parameters["@cOwnersList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cGoodsStatesList", SqlDbType.VarChar);
			if (sGoodsStatesList != null)
				_oCommand.Parameters["@cGoodsStatesList"].Value = sGoodsStatesList;
			else
				_oCommand.Parameters["@cGoodsStatesList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cPackingsList", SqlDbType.VarChar);
			if (sPackingsList != null)
				_oCommand.Parameters["@cPackingsList"].Value = sPackingsList;
			else
				_oCommand.Parameters["@cPackingsList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bGroupOwner", SqlDbType.VarChar);
			_oCommand.Parameters["@bGroupOwner"].Value = bGroupOwner;

            _oCommand.Parameters.Add("@nMode", SqlDbType.TinyInt);
            _oCommand.Parameters["@nMode"].Value = nMode;
            #endregion

			try
			{
				_MainTable = FillReadings(new SqlDataAdapter(_oCommand), _MainTable, _MainTableName);
				_NeedRequery = false;
			}
			catch (Exception ex)
			{
				_ErrorNumber = -1;
				_ErrorStr = "Ошибка при получении остатков/операций за период...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}


		// --------------------------------------------------------------------

		/// <summary>
		/// Карточка товара
		/// </summary>
		public bool ReportPackingsTurnover
			(DateTime? dDateBeg, DateTime? dDateEnd,
			int nPackingID, int? nOwnerID, int nGoodStateID, 
			ref decimal nQntBeg, ref decimal nQntEnd)
		{
			ClearData();

			string sqlSelect = "execute up_ReportPackingsTurnover " +
									"@dDateBeg, @dDateEnd, " +
									"@nPackingID, @nOwnerID, @nGoodStateID, " +
									"@nQntBeg output, @nQntEnd output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);
			_oCommand.CommandTimeout = 0;

			#region up_ReportPackingsTurnover paramaters

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

			_oCommand.Parameters.Add("@nPackingID", SqlDbType.Int);
			_oCommand.Parameters["@nPackingID"].Value = nPackingID;

			_oCommand.Parameters.Add("@nOwnerID", SqlDbType.Int);
			if (nOwnerID.HasValue)
				_oCommand.Parameters["@nOwnerID"].Value = nOwnerID;
			else
				_oCommand.Parameters["@nOwnerID"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@nGoodStateID", SqlDbType.Int);
			_oCommand.Parameters["@nGoodStateID"].Value = nGoodStateID;

			_oCommand.Parameters.Add("@nQntBeg", SqlDbType.Decimal);
			_oCommand.Parameters["@nQntBeg"].Precision = 15;
			_oCommand.Parameters["@nQntBeg"].Scale = 3;
			_oCommand.Parameters["@nQntBeg"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@nQntBeg"].Value = 0;

			_oCommand.Parameters.Add("@nQntEnd", SqlDbType.Decimal);
			_oCommand.Parameters["@nQntEnd"].Precision = 15;
			_oCommand.Parameters["@nQntEnd"].Scale = 3;
			_oCommand.Parameters["@nQntEnd"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@nQntEnd"].Value = 0;

			#endregion

			try
			{
				_MainTable = FillReadings(new SqlDataAdapter(_oCommand), _MainTable, _MainTableName);
				_NeedRequery = false;
			}
			catch (Exception ex)
			{
				_ErrorNumber = -1;
				_ErrorStr = "Ошибка при получении операций с товаром за период...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}

			nQntBeg = Convert.ToDecimal(_oCommand.Parameters["@nQntBeg"].Value);
			nQntEnd = Convert.ToDecimal(_oCommand.Parameters["@nQntEnd"].Value);

			return (_ErrorNumber == 0);
		}


		// --------------------------------------------------------------------

		/// <summary>
		/// Приход контейнеров
		/// </summary>
		public bool ReportInputsFrames
			(DateTime? dDateBegBirth, DateTime? dDateEndBirth,
			DateTime? dDateBegConfirm, DateTime? dDateEndConfirm,
			bool? bConfirmed, 
			string sUsersList, 
			string sFrameBarCodeContext,
			string sPackingsList)
		{
			ClearData();
			ClearError();

			string sqlSelect;
			SqlCommand _oCommand;

			sqlSelect = "execute up_ReportInputsFrames " +
									"@dDateBegBirth, @dDateEndBirth, " +
									"@dDateBegConfirm, @dDateEndConfirm, " +
									"@bConfirmed, " +
									"@cUsersList, " +
									"@cFrameBarCodeContext, " +
									"@cPackingsList";
			_oCommand = new SqlCommand(sqlSelect, _Connect);
			_oCommand.CommandTimeout = 0;

			#region up_ReportInputsFrames paramaters

			_oCommand.Parameters.Add("@dDateBegBirth", SqlDbType.SmallDateTime);
			if (dDateBegBirth != null)
				_oCommand.Parameters["@dDateBegBirth"].Value = dDateBegBirth;
			else
				_oCommand.Parameters["@dDateBegBirth"].Value = DBNull.Value;
			_oCommand.Parameters.Add("@dDateEndBirth", SqlDbType.SmallDateTime);
			if (dDateEndBirth != null)
				_oCommand.Parameters["@dDateEndBirth"].Value = dDateEndBirth;
			else
				_oCommand.Parameters["@dDateEndBirth"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@dDateBegConfirm", SqlDbType.SmallDateTime);
			if (dDateBegConfirm != null)
				_oCommand.Parameters["@dDateBegConfirm"].Value = dDateBegConfirm;
			else
				_oCommand.Parameters["@dDateBegConfirm"].Value = DBNull.Value;
			_oCommand.Parameters.Add("@dDateEndConfirm", SqlDbType.SmallDateTime);
			if (dDateEndConfirm != null)
				_oCommand.Parameters["@dDateEndConfirm"].Value = dDateEndConfirm;
			else
				_oCommand.Parameters["@dDateEndConfirm"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bConfirmed", SqlDbType.Bit);
			if (bConfirmed != null)
				_oCommand.Parameters["@bConfirmed"].Value = bConfirmed;
			else
				_oCommand.Parameters["@bConfirmed"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cUsersList", SqlDbType.VarChar);
			if (sUsersList != null)
				_oCommand.Parameters["@cUsersList"].Value = sUsersList;
			else
				_oCommand.Parameters["@cUsersList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cFrameBarCodeContext", SqlDbType.VarChar);
			if (sFrameBarCodeContext != null)
				_oCommand.Parameters["@cFrameBarCodeContext"].Value = sFrameBarCodeContext;
			else
				_oCommand.Parameters["@cFrameBarCodeContext"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cPackingsList", SqlDbType.VarChar);
			if (sPackingsList != null)
				_oCommand.Parameters["@cPackingsList"].Value = sPackingsList;
			else
				_oCommand.Parameters["@cPackingsList"].Value = DBNull.Value;

			#endregion

			try
			{
				_MainTable = FillReadings(new SqlDataAdapter(_oCommand), _MainTable, _MainTableName);
				_NeedRequery = false;
			}
			catch (Exception ex)
			{
				_ErrorNumber = -1;
				_ErrorStr = "Ошибка при получении списка контейнеров в приходах...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			return (_ErrorNumber == 0);
		}

		// --------------------------------------------------------------------

		/// <summary>
		/// сроки годности в приходах
		/// </summary>
		public bool ReportInputsDateValid
			(DateTime? dDateBeg, DateTime? dDateEnd,
			string sPartnersList, 
			string sPackingsList, 
			int? nPercents,
			int? nMonths,
			bool bFromNow
			)
		{
			ClearData();
			ClearError();

			string sqlSelect;
			SqlCommand _oCommand;

			sqlSelect = "execute up_ReportInputsDateValid " +
									"@dDateBeg, @dDateEnd, " +
									"@cPartnersList, " +
									"@cPackingsList, " +
									"@nPercents, @nMonths, " +
									"@bFromNow ";
			_oCommand = new SqlCommand(sqlSelect, _Connect);
			_oCommand.CommandTimeout = 0;

			#region up_ReportInputsDateValid paramaters

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

			_oCommand.Parameters.Add("@cPartnersList", SqlDbType.VarChar);
			if (sPartnersList != null)
				_oCommand.Parameters["@cPartnersList"].Value = sPartnersList;
			else
				_oCommand.Parameters["@cPartnersList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cPackingsList", SqlDbType.VarChar);
			if (sPackingsList != null)
				_oCommand.Parameters["@cPackingsList"].Value = sPackingsList;
			else
				_oCommand.Parameters["@cPackingsList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@nPercents", SqlDbType.Int);
			if (nPercents != null)
				_oCommand.Parameters["@nPercents"].Value = nPercents;
			else
				_oCommand.Parameters["@nPercents"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@nMonths", SqlDbType.Int);
			if (nMonths != null)
				_oCommand.Parameters["@nMonths"].Value = nMonths;
			else
				_oCommand.Parameters["@nMonths"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bFromNow", SqlDbType.Bit);
			_oCommand.Parameters["@bFromNow"].Value = bFromNow;

			#endregion

			try
			{
				_MainTable = FillReadings(new SqlDataAdapter(_oCommand), _MainTable, _MainTableName);
				_NeedRequery = false;
			}
			catch (Exception ex)
			{
				_ErrorNumber = -1;
				_ErrorStr = "Ошибка при получении списка товаров с сроками годности в приходах...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			return (_ErrorNumber == 0);
		}


		// --------------------------------------------------------------------

		/// <summary>
		/// Отчет по выполненным операциям (для з/п)
		/// </summary>

		public bool ReportForSalary
			(string sMode,
			DateTime? dDateBeg, DateTime? dDateEnd,
			string sDetailMode,
            /*bool bGroupBy,*/
            string sGroupBy,
            string sUsersList,
			string sInputsTypesList,
			string sOutputsTypesList, 
			string sOwnersList)
		{
			ClearData();
			ClearError();

			string sqlSelect;
			SqlCommand _oCommand;

			sqlSelect = "execute up_ReportForSalary " +
									"@cMode, " +
									"@dDateBeg, @dDateEnd, " +
									"@cDetailMode, " +
                                    /*"@bGroupBy, " +*/
                                    "@sGroupBy, " +
                                    "@cUsersList, " +
									"@cInputsTypesList, " +
									"@cOutputsTypesList, " + 
									"@cOwnersList";
			_oCommand = new SqlCommand(sqlSelect, _Connect);
			_oCommand.CommandTimeout = 0;

			#region up_ReportForSalary paramaters

			_oCommand.Parameters.Add("@cMode", SqlDbType.VarChar);
			_oCommand.Parameters["@cMode"].Value = sMode;

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

			_oCommand.Parameters.Add("@cDetailMode", SqlDbType.VarChar);
			_oCommand.Parameters["@cDetailMode"].Value = sDetailMode;

            /*_oCommand.Parameters.Add("@bGroupBy", SqlDbType.Bit);
            _oCommand.Parameters["@bGroupBy"].Value = bGroupBy;*/
            _oCommand.Parameters.Add("@sGroupBy", SqlDbType.VarChar);
            _oCommand.Parameters["@sGroupBy"].Value = sGroupBy;

			_oCommand.Parameters.Add("@cUsersList", SqlDbType.VarChar);
			if (sUsersList != null)
				_oCommand.Parameters["@cUsersList"].Value = sUsersList;
			else
				_oCommand.Parameters["@cUsersList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cInputsTypesList", SqlDbType.VarChar);
			if (sInputsTypesList != null)
				_oCommand.Parameters["@cInputsTypesList"].Value = sInputsTypesList;
			else
				_oCommand.Parameters["@cInputsTypesList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cOutputsTypesList", SqlDbType.VarChar);
			if (sOutputsTypesList != null)
				_oCommand.Parameters["@cOutputsTypesList"].Value = sOutputsTypesList;
			else
				_oCommand.Parameters["@cOutputsTypesList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cOwnersList", SqlDbType.VarChar);
			if (sOwnersList != null)
				_oCommand.Parameters["@cOwnersList"].Value = sOwnersList;
			else
				_oCommand.Parameters["@cOwnersList"].Value = DBNull.Value;

			#endregion

			try
			{
				if (_DS.Tables.Contains(_MainTableName))
					_DS.Tables.Remove(_MainTableName);
				_MainTable = null;

				SqlDataAdapter adapter = new SqlDataAdapter(_oCommand);
				adapter.Fill(_DS, _MainTableName);
				_MainTable = _DS.Tables[_MainTableName];
				_NeedRequery = false;
			}
			catch (Exception ex)
			{
				_ErrorNumber = -1;
				_ErrorStr = "Ошибка при получении списка операций...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			return (_ErrorNumber == 0);
		}


        public bool ReportPickFreeRills()
        {
            ClearData();
            ClearError();

            string sqlSelect;
            SqlCommand _oCommand;

            sqlSelect = "execute up_ReportPickFreeRills";
            _oCommand = new SqlCommand(sqlSelect, _Connect);
            _oCommand.CommandTimeout = 0;
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(_oCommand);
                FillReadings(adapter);
                _NeedRequery = false;
            }
            catch (Exception ex)
            {
                _ErrorNumber = -1;
                _ErrorStr = "Ошибка при получении списка операций...\r\n" + ex.Message;
                RFMMessage.MessageBoxError(_ErrorStr);
            }
            finally
            {
                _Connect.Close();
            }
            return (_ErrorNumber == 0);
        }

		// отчет о невыданных товарах
		public bool ReportOutputsQntDifferences
            (string sOutputsList, string sUnit, bool bGroupByPacking, bool bIncludeWeighting, decimal nWeightDiffPrc,
			 string sQntFieldName1, string sQntFieldName2)
		{
			ClearData();
			ClearError();

			string sqlSelect;
			SqlCommand _oCommand;

			sqlSelect = "execute up_ReportOutputsQntDifferences " +
									"@cOutputsList, " +
                                    "@cUnit, " +
                                    "@bGroupByPacking, " +
                                    "@bIncludeWeighting, " +
									"@nWeightDiffPrc, " + 
									"@cQntFieldName1, " +
									"@cQntFieldName2";
			_oCommand = new SqlCommand(sqlSelect, _Connect);
			_oCommand.CommandTimeout = 0;

			#region up_ReportOutputsQntDifferences paramaters

			SqlParameter _oParameter = _oCommand.Parameters.Add("@cOutputsList", SqlDbType.VarChar);
			if (sOutputsList != null)
				_oParameter.Value = sOutputsList;
			else
				_oParameter.Value = DBNull.Value;

            _oParameter = _oCommand.Parameters.Add("@cUnit", SqlDbType.VarChar);
            _oParameter.Value = sUnit;

            _oParameter = _oCommand.Parameters.Add("@bGroupByPacking", SqlDbType.Bit);
            _oParameter.Value = bGroupByPacking;

            _oParameter = _oCommand.Parameters.Add("@bIncludeWeighting", SqlDbType.Bit);
			_oParameter.Value = bIncludeWeighting;

			_oParameter = _oCommand.Parameters.Add("@nWeightDiffPrc", SqlDbType.Decimal);
			_oParameter.Precision = 15;
			_oParameter.Scale = 3;
			_oParameter.Value = nWeightDiffPrc;

			_oParameter = _oCommand.Parameters.Add("@cQntFieldName1", SqlDbType.VarChar);
			_oParameter.Value = sQntFieldName1;

			_oParameter = _oCommand.Parameters.Add("@cQntFieldName2", SqlDbType.VarChar);
			_oParameter.Value = sQntFieldName2;

			#endregion

			try
			{
				if (_DS.Tables.Contains(_MainTableName))
					_DS.Tables.Remove(_MainTableName);
				_MainTable = null;

				SqlDataAdapter adapter = new SqlDataAdapter(_oCommand);
				adapter.Fill(_DS, _MainTableName);
				_MainTable = _DS.Tables[_MainTableName];
				_NeedRequery = false;
			}
			catch (Exception ex)
			{
				_ErrorNumber = -1;
				_ErrorStr = "Ошибка при получении списка расхождений при подборе/сборе/выдаче товаров...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			return (_ErrorNumber == 0);
		}

        public bool ReportShiftsProductivity
            (string Mode, DateTime? DateBeg, DateTime? DateEnd, string OwnersList, bool? WeightingGoods
            )
        {
            ClearData();
            ClearError();

            string sqlSelect;
            SqlCommand _oCommand;

            sqlSelect = "execute up_ReportShiftsProductivity " +
                                    "@cMode, " +
                                    "@dDateBeg, " +
                                    "@dDateEnd, " +
                                    "@cOwnersList, " +
                                    "@bWeightingGoods";
            _oCommand = new SqlCommand(sqlSelect, _Connect);
            _oCommand.CommandTimeout = 0;

            #region up_ReportShiftsProductivity paramaters

            SqlParameter _oParameter;

            _oParameter = _oCommand.Parameters.Add("@cMode", SqlDbType.VarChar);
            _oParameter.Value = Mode;

            _oParameter = _oCommand.Parameters.Add("@dDateBeg", SqlDbType.DateTime);
            _oParameter.Value = DateBeg;
            _oParameter = _oCommand.Parameters.Add("@dDateEnd", SqlDbType.DateTime);
            _oParameter.Value = DateEnd;

            _oParameter = _oCommand.Parameters.Add("@cOwnersList", SqlDbType.VarChar);
            if (OwnersList != null) _oParameter.Value = OwnersList;
            else _oParameter.Value = DBNull.Value;

            _oParameter = _oCommand.Parameters.Add("@bWeightingGoods", SqlDbType.Bit);
            if (WeightingGoods != null) _oParameter.Value = WeightingGoods;
            else _oParameter.Value = DBNull.Value;

            #endregion

            try
            {
                _DS.Reset();

                SqlDataAdapter adapter = new SqlDataAdapter(_oCommand);
                adapter.Fill(_DS);
            }
            catch (Exception ex)
            {
                _ErrorNumber = -1;
                _ErrorStr = "Ошибка при расчете отчета о товарах с плохими сроками годности...\r\n" + ex.Message;
                RFMMessage.MessageBoxError(_ErrorStr);
            }
            finally
            {
                _Connect.Close();
            }
            return (_ErrorNumber == 0);
        }

        public bool ReportBadGoods(int RestPercent, string OwnersList)
        {
            ClearData();
            ClearError();

            string sqlSelect;
            SqlCommand _oCommand;

            sqlSelect = "select	" + 
                    "IsNull(O.Name, '') as OwnerName, " + 
                    "GG.Name as GroupName, G.Alias as GoodName, G.ERPCode as GoodERPCode, G.Articul, " + 
                    "P.InBox, GS.Name as GoodStateName, " +
	    	        "CC.DateValid, DateDiff(Day, GetDate(), CC.DateValid) as Rest, " +
		            "DateDiff(Day, GetDate(), CC.DateValid) * 100 / G.Retention as RestPrc, " +
		            "sum(CC.Qnt / P.InBox) as Boxes, sum(CC.Qnt * G.Netto) as Netto, min(G.Cost) as Cost " +
	            "from CellsContents CC with (nolock) " +
                "inner join Cells C with (nolock) on CC.CellID = C.ID " +
                "inner join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID " +
                "inner join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT.ID " +
                "left join Partners O with (nolock) on CC.OwnerID = O.ID " + 
	            "inner join Packings P with (nolock) on CC.PackingID = P.ID " + 
	            "inner join Goods G with (nolock) on P.GoodID = G.ID " + 
	            "inner join GoodsGroups GG with (nolock) on G.GoodGroupID = GG.ID " + 
	            "inner join GoodsStates GS with (nolock) on CC.GoodStateID = GS.ID " + 
	            "where	SZT.Special = 0 and " +
                (String.IsNullOrEmpty(OwnersList) ? "" : "IsNull(CC.OwnerID, 0) in (" + OwnersList + ") and ") + 
			            "CC.FrameID is not Null and " +
                        "CC.DateValid is not Null and " +
                        "G.Retention > 0 and " + 
	        		    "DateDiff(Day, GetDate(), CC.DateValid) * 100 / G.Retention <= " + RestPercent.ToString() +
                " group by IsNull(O.Name, ''), GG.Name, G.Alias, G.ERPCode, G.Articul, P.InBox, GS.Name, G.Retention, CC.DateValid " + 
	            "order by 1,2,3,4,5,6";
            _oCommand = new SqlCommand(sqlSelect, _Connect);
            _oCommand.CommandTimeout = 0;

            try
            {
                _DS.Reset();

                SqlDataAdapter adapter = new SqlDataAdapter(_oCommand);
                adapter.Fill(_DS);
            }
            catch (Exception ex)
            {
                _ErrorNumber = -1;
                _ErrorStr = "Ошибка при расчете отчета о товарах с плохими сроками годности...\r\n" + ex.Message;
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
