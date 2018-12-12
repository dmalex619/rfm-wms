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
/// Бизнес-объект Остаток (Oddment)
/// </summary>
namespace WMSBizObjects
{
	public class Oddment : BizObject
	{
		// Фильтры

		protected string _FilterOwnersList;
		/// <summary>
		/// Фильтр-поле: Список владельцев товара (Oddments.OwnerID), через запятую
		/// </summary>
		[Description("Фильтр-поле: Список владельцев товара (Oddments.OwnerID), через запятую")]
		public string FilterOwnersList { get { return _FilterOwnersList; } set { _FilterOwnersList = value; _NeedRequery = true; } }

		protected string _FilterGoodsStatesList;
		/// <summary>
		/// Фильтр-поле: Список состояний товара (Oddments.GoodStateID), через запятую
		/// </summary>
		[Description("Фильтр-поле: Список состояний товара (Oddments.GoodStateID), через запятую")]
		public string FilterGoodsStatesList { get { return _FilterGoodsStatesList; } set { _FilterGoodsStatesList = value; _NeedRequery = true; } }

		protected string _FilterPackingsList;
		/// <summary>
		/// Фильтр-поле: Список ID упаковок (Oddments.PackingID), через запятую
		/// </summary>
		[Description("Фильтр-поле: Список ID упаковок (OddmentsSavedGoods.PackingID), через запятую")]
		public string FilterPackingsList { get { return _FilterPackingsList; } set { _FilterPackingsList = value; _NeedRequery = true; } }

		protected string _FilterGoodsList;
		/// <summary>
		/// Фильтр-поле: Список ID товаров (Oddments.PackingID -> Packings.GoodID), через запятую
		/// </summary>
		[Description("Фильтр-поле: Список ID товаров (Cells.PackingID -> Packings.GoodID), через запятую")]
		public string FilterGoodsList { get { return _FilterGoodsList; } set { _FilterGoodsList = value; _NeedRequery = true; } }

		protected int? _FilterIsExists;
		/// <summary>
		/// Фильтр-поле: Товар есть в остатках (CellsContents.Qnt):  0: =0, 1: >0, -1: <0?
		/// </summary>
		[Description("Фильтр-поле: Товар есть в остатках (CellsContents.Qnt):  0: =0, 1: >0, -1: <0?")]
		public int? FilterIsExists { get { return _FilterIsExists; } set { _FilterIsExists = value; _NeedRequery = true; } }

		// Фильтры для сохраненных остатков

		protected DateTime? _FilterDataBeg;
		/// <summary>
		/// Фильтр-поле: Начальная дата периода (OddmentsSaved.DateSave)
		/// </summary>
		[Description("Фильтр-поле: Начальная дата периода (OddmentsSaved.DateSave)")]
		public DateTime? FilterDateBeg { get { return _FilterDataBeg; } set { _FilterDataBeg = value; _NeedRequery = true; } }

		protected DateTime? _FilterDataEnd;
		/// <summary>
		/// Фильтр-поле: Конечная дата периода (OddmentsSaved.DateSave)
		/// </summary>
		[Description("Фильтр-поле: Конечная дата периода (OddmentsSaved.DateSave)")]
		public DateTime? FilterDateEnd { get { return _FilterDataEnd; } set { _FilterDataEnd = value; _NeedRequery = true; } }

		protected int? _FilterCheckDateValid;
		/// <summary>
		/// Фильтр-поле: по сроку годности для расчетного остатка (CellsContents.DateValid): % осталось менее, -1 просрочен, -2 завышен
		/// </summary>
		[Description("Фильтр-поле: по сроку годности для расчетного остатка (CellsContents.DateValid): % осталось менее, -1 просрочен, -2 завышен")]
		public int? FilterCheckDateValid { get { return _FilterCheckDateValid; } set { _FilterCheckDateValid = value; _NeedRequery = true; } }

		// Таблицы

		protected DataTable _TableOddmentsDetails;
		/// <summary>
		/// Расшифровка текущих остатков по ячейкам/контейнерам
		/// </summary>
		[Description("Расшифровка текущих остатков по ячейкам/контейнерам")]
		public DataTable TableOddmentsDetails { get { return _TableOddmentsDetails; } }

		protected DataTable _TableOddmentsSaved;
		/// <summary>
		/// Сохраненные остатки (шапки)
		/// </summary>
		[Description("Сохраненные остатки (шапки)")]
		public DataTable TableOddmentsSaved { get { return _TableOddmentsSaved; } }

		protected DataTable _TableOddmentsSavedGoods;
		/// <summary>
		/// Сохраненные остатки (товары)
		/// </summary>
		[Description("Сохраненные остатки (товары)")]
		public DataTable TableOddmentsSavedGoods { get { return _TableOddmentsSavedGoods; } }

		// -------------------------------------

		public Oddment()
			: base()
		{
			_MainTableName = "Oddments";
		}

		/// <summary>
		/// получение списка приходов (MainTable)
		/// </summary>
		public override bool FillData()
		{
			ClearData();

			string sqlSelect = "execute up_OddmentsFill " +
					"@nID, " +
					"@cOwnersList, @cGoodsStatesList, " +
					"@cPackingsList, @cGoodsList, " +
					"@nIsExists, @nCheckDateValid";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_OddmentsFill parameters

			_oCommand.Parameters.Add("@nID", SqlDbType.Int);
			if (_ID.HasValue)
				_oCommand.Parameters["@nID"].Value = _ID;
			else
				_oCommand.Parameters["@nID"].Value = DBNull.Value;

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

			_oCommand.Parameters.Add("@nIsExists", SqlDbType.Int);
			if (_FilterIsExists != null)
				_oCommand.Parameters["@nIsExists"].Value = _FilterIsExists;
			else
				_oCommand.Parameters["@nIsExists"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@nCheckDateValid", SqlDbType.Int);
			if (_FilterCheckDateValid != null)
				_oCommand.Parameters["@nCheckDateValid"].Value = _FilterCheckDateValid;
			else
				_oCommand.Parameters["@nCheckDateValid"].Value = DBNull.Value;

			#endregion

			try
			{
				_MainTable = FillReadings(new SqlDataAdapter(_oCommand), _MainTable, _MainTableName);
				_NeedRequery = false;
			}
			catch (Exception ex)
			{
				_ErrorNumber = -1;
				_ErrorStr = "Ошибка при получении списка остатков...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// очистка фильтр-полей
		/// </summary>
		public void ClearFilters()
		{
			_FilterOwnersList = null;
			_FilterGoodsStatesList = null;
			_FilterPackingsList = null;
			_FilterGoodsList = null;
			_FilterDataBeg = null;
			_FilterDataEnd = null;
			_FilterIsExists = null;
			_FilterCheckDateValid = null;
			//_NeedRequery = true;
		}

		/// <summary>
		/// получение таблицы расшифровок текущих остатков (TableOddmentsDetails)
		/// </summary>
		public bool FillTableOddmentsDetails(int? nOwnerID, int? nGoodStateID, int? nPackingID)
		{
			string sqlSelect = "execute up_OddmentsDetailsFill " +
					"@nOwnerID, @nGoodStateID, @nPackingID, " +
					"0, @nCheckDateValid";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_OddmentsDetailsFill parameters

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

			_oCommand.Parameters.Add("@nPackingID", SqlDbType.Int);
			if (nPackingID.HasValue)
				_oCommand.Parameters["@nPackingID"].Value = nPackingID;
			else
				_oCommand.Parameters["@nPackingID"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@nCheckDateValid", SqlDbType.Int);
			if (_FilterCheckDateValid != null)
				_oCommand.Parameters["@nCheckDateValid"].Value = _FilterCheckDateValid;
			else
				_oCommand.Parameters["@nCheckDateValid"].Value = DBNull.Value;

			#endregion

			try
			{
				_TableOddmentsDetails = FillReadings(new SqlDataAdapter(_oCommand), _TableOddmentsDetails, "TableOddmentsDetails");
				_NeedRequery = false;
			}
			catch (Exception ex)
			{
				_ErrorNumber = -1;
				_ErrorStr = "Ошибка при получении расшифровок текущих остатков...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// получение списка сохраненных остатков (TableOddmentsSavedGoods)
		/// </summary>
		public bool FillTableOddmentsSaved()
		{
			return (_FillTableOddmentsSaved(null, false));
		}

		public bool FillTableOddmentsSavedGoods(int nOddmentSavedID)
		{
			return (_FillTableOddmentsSaved(nOddmentSavedID, true));
		}

		private bool _FillTableOddmentsSaved(int? nOddmentSavedID, bool bGoods)
		{
			string sqlSelect = "execute up_OddmentsSavedFill " +
					"@bGoods, @nOddmentSavedID, " +
					"@dDateBeg, @dDateEnd, " +
					"@cOwnersList, @cGoodsStatesList, " +
					"@cPackingsList, @cGoodsList";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_OddmentsSavedFill parameters

			_oCommand.Parameters.Add("@bGoods", SqlDbType.Bit);
			_oCommand.Parameters["@bGoods"].Value = bGoods;

			_oCommand.Parameters.Add("@nOddmentSavedID", SqlDbType.Int);
			if (nOddmentSavedID.HasValue)
				_oCommand.Parameters["@nOddmentSavedID"].Value = nOddmentSavedID;
			else
				_oCommand.Parameters["@nOddmentSavedID"].Value = DBNull.Value;

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

			try
			{
				if (bGoods)
					_TableOddmentsSavedGoods = FillReadings(new SqlDataAdapter(_oCommand), _TableOddmentsSavedGoods, "TableOddmentsSavedGoods");
				else
					_TableOddmentsSaved = FillReadings(new SqlDataAdapter(_oCommand), _TableOddmentsSaved, "TableOddmentsSaved");

				_NeedRequery = false;
			}
			catch (Exception ex)
			{
				_ErrorNumber = -1;
				_ErrorStr = "Ошибка при получении списка сохраненных остатков...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// сохранение копии остатков (срез)
		/// </summary>
		public int SaveCopyData()
		{
			int nNewOddmentSavedID = 0;

			string _sqlCommand = "execute up_OddmentsSaveCopy @nNewOddmentSavedID output, " +
									"@nError output, @cErrorStr output";
			SqlCommand _oCommand = new SqlCommand(_sqlCommand, _Connect);
			_oCommand.CommandTimeout = 0;

			#region up_OddmentsSaveCopy parameters

			_oCommand.Parameters.Add("@nNewOddmentSavedID", SqlDbType.Int);
			_oCommand.Parameters["@nNewOddmentSavedID"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@nNewOddmentSavedID"].Value = DBNull.Value;

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
				_ErrorStr = "Ошибка при попытке сохранения копии остатков...\r\n" + ex.Message;
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
					_ErrorStr = "Ошибка при сохранении копии остатков...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
				else
				{
					nNewOddmentSavedID = (int)_oCommand.Parameters["@nNewOddmentSavedID"].Value;
				}
			}
			return (nNewOddmentSavedID);
		}

		#region Get CellsContents Qnt

		/// <summary>
		/// расчетный остаток по ячейкам
		/// </summary>
		public decimal GetCellsContentsQnt(int nPackingID, int nGoodStateID, int? nOwnerID,
			bool bIncludeDefectCellQnt, bool bIncludeLostFoundCellQnt)
		{
			decimal nCCQnt = 0;

			if (_DS.Tables["tTabelCellsContentsQnt"] != null)
			{
				_DS.Tables.Remove("tTabelCellsContentsQnt");
			}

			string sqlSelect = "select .dbo.GetCellsContentsQnt(";
			sqlSelect += nPackingID.ToString() + ", ";
			sqlSelect += nGoodStateID.ToString() + ", ";
			if (nOwnerID.HasValue)
				sqlSelect += nOwnerID.ToString() + ", ";
			else
				sqlSelect += "Null, ";
			sqlSelect += (bIncludeDefectCellQnt) ? "1, " : "0, ";
			sqlSelect += (bIncludeLostFoundCellQnt) ? "1 " : "0 ";
			sqlSelect += ") as Qnt";

			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			try
			{
				SqlDataAdapter adapter = new SqlDataAdapter(_oCommand);
				adapter.Fill(_DS, "tTabelCellsContentsQnt");
				if (_DS.Tables["tTabelCellsContentsQnt"] != null &&
					_DS.Tables["tTabelCellsContentsQnt"].Rows.Count > 0)
				{
					nCCQnt = Convert.ToDecimal(_DS.Tables["tTabelCellsContentsQnt"].Rows[0]["Qnt"]);
				}
			}
			catch (Exception ex)
			{
				_ErrorNumber = -101;
				_ErrorStr = "Ошибка при получении остатка..." + Convert.ToChar(13) + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (nCCQnt);
		}

		#endregion

	}
}
