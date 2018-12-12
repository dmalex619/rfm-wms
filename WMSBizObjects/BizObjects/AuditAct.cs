using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

using RFMPublic;

/// <summary>
/// Бизнес-объект Акт (вызывает изменение количества товаров, исп. ячейку Lost&Found) (AuditAct)
/// </summary>
namespace WMSBizObjects
{
	public class AuditAct : BizObject
	{
		protected string _IDList;
		/// <summary>
		/// Список ID актов (AuditActs.ID)
		/// </summary>
		[Description("Список ID актов (AuditActs.ID)")]
		public string IDList { get { return _IDList; } set { _IDList = value; _NeedRequery = true; } }

		// Фильтры
		#region Filters

		protected string _FilterHostsList;
		/// <summary>
		/// Фильтр-поле: список кодов host-ов (AuditActs.HostID)
		/// </summary>
		[Description("Фильтр-поле: список кодов host-ов (AuditActs.HostID)")]
		public string FilterHostsList { get { return _FilterHostsList; } set { _FilterHostsList = value; _NeedRequery = true; } }

		protected DateTime? _FilterDateBeg;
		/// <summary>
		/// Фильтр-поле: Начальная дата периода (AuditActs.DateAuditAct)
		/// </summary>
		[Description("Фильтр-поле: Начальная дата периода (AuditActs.DateAuditAct)")]
		public DateTime? FilterDateBeg { get { return _FilterDateBeg; } set { _FilterDateBeg = value; } }

		protected DateTime? _FilterDateEnd;
		/// <summary>
		/// Фильтр-поле: Конечная дата периода
		/// </summary>
		[Description("Фильтр-поле: Конечная дата периода (AuditActs.DateAuditAct)")]
		public DateTime? FilterDateEnd { get { return _FilterDateEnd; } set { _FilterDateEnd = value; } }

		protected bool? _FilterConfirmed;
		/// <summary>
		/// Фильтр-поле: подтверждено (AuditActs.DateConfirm)?
		/// </summary>
		[Description("Фильтр-поле: подтверждено (AuditActs.DateConfirm)?")]
		public bool? FilterConfirmed { get { return _FilterConfirmed; } set { _FilterConfirmed = value; } }

		protected string _FilterOwnersList;
		/// <summary>
		/// Фильтр-поле: Список владельцев товара (AuditActs.OwnerID), через запятую
		/// </summary>
		[Description("Фильтр-поле: Список владельцев товара (AuditActs.OwnerID), через запятую")]
		public string FilterOwnersList { get { return _FilterOwnersList; } set { _FilterOwnersList = value; _NeedRequery = true; } }

		protected string _FilterGoodsStatesList;
		/// <summary>
		/// Фильтр-поле: Список состояний товара (AuditActs.GoodStateID, AuditActsGoods.GoodStateID), через запятую
		/// </summary>
		[Description("Фильтр-поле: Список состояний товара (AuditActs.GoodStateID, AuditActsGoods.GoodStateID), через запятую")]
		public string FilterGoodsStatesList { get { return _FilterGoodsStatesList; } set { _FilterGoodsStatesList = value; _NeedRequery = true; } }

		// -- для товаров
		protected string _FilterPackingsList;
		/// <summary>
		/// Фильтр-поле: Список ID упаковок (AuditActsGoods.PackingID), через запятую
		/// </summary>
		[Description("Фильтр-поле: Список ID упаковок (AuditActsGoods.PackingID), через запятую")]
		public string FilterPackingsList { get { return _FilterPackingsList; } set { _FilterPackingsList = value; _NeedRequery = true; } }

		protected string _FilterGoodsList;
		/// <summary>
		/// Фильтр-поле: Список ID товаров (AuditActsGoods.PackingID -> Packings.GoodID -> Goods.ID), через запятую
		/// </summary>
		[Description("Фильтр-поле: Список ID товаров (AuditActsGoods.PackingID -> Packings.GoodID -> Goods.ID), через запятую")]
		public string FilterGoodsList { get { return _FilterGoodsList; } set { _FilterGoodsList = value; _NeedRequery = true; } }

		#endregion Filters

		// Таблицы
		#region Tables

		protected DataTable _TableAuditActsGoods;
		/// <summary>
		/// Список товаров в акте (TableAuditActsGoods)
		/// </summary>
		[Description("Список товаров в акте (TableAuditActsGoods)")]
		public DataTable TableAuditActsGoods { get { return _TableAuditActsGoods; } }

		#endregion Tables

		// -------------------------------------

		public AuditAct()
			: base()
		{
			_MainTableName = "AuditActs";
		}

		#region FillData

		/// <summary>
		/// получение списка актов (MainTable)
		/// </summary>
		public override bool FillData()
		{
			ClearData();

			string sqlSelect = "execute up_AuditActsFill " +
				"@nID, @cIDList, " +
				"@cHostsList, " + 
				"@dDateBeg, @dDateEnd, " +
				"@bConfirmed, " +
				"@cOwnersList, " +
				"@cGoodsStatesList, " +
				"@cPackingsList, @cGoodsList";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_AuditActsFill parameters

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

			_oCommand.Parameters.Add("@bConfirmed", SqlDbType.Bit);
			if (_FilterConfirmed != null)
				_oCommand.Parameters["@bConfirmed"].Value = _FilterConfirmed;
			else
				_oCommand.Parameters["@bConfirmed"].Value = DBNull.Value;

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

			#region up_AuditActsFill AuditActsGoods-paramaters

			//поля для поиска через Список товаров (AuditActsGoods)

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

			#endregion

			try
			{
				_MainTable = FillReadings(new SqlDataAdapter(_oCommand), _MainTable, _MainTableName);
			}
			catch (Exception ex)
			{
				_ErrorNumber = -1;
				_ErrorStr = "Ошибка при получении списка актов..." + Convert.ToChar(13) + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// очистка фильтр-полей
		/// </summary>
		public void ClearFilters()
		{
			_FilterHostsList = null;
			_FilterDateBeg = null;
			_FilterDateEnd = null;
			_FilterConfirmed = null;
			_FilterOwnersList = null;
			_FilterGoodsStatesList = null;
			_FilterPackingsList = null;
			_FilterGoodsList = null;
			//_NeedRequery = false;
		}

		#endregion FillData

		#region AuditActsGoods

		/// <summary>
		/// заполнение таблицы товаров в акте (TableAuditActsGoods)
		/// </summary>
		public bool FillTableAuditActsGoods(int? nAuditActID)
		{
			if (!nAuditActID.HasValue & !_ID.HasValue)
			{
				_ErrorNumber = -12;
				_ErrorStr = "Некорректный вызов:\r\nОшибка при получении списка товаров в акте...";
				RFMMessage.MessageBoxError(_ErrorStr);
				return (false);
			}
			if (!nAuditActID.HasValue)
				nAuditActID = _ID;

			string sqlSelect = "execute up_AuditActsGoodsFill @nAuditActID, " +
									"@nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_AuditActsGoodsFill parameters

			_oCommand.Parameters.Add("@nAuditActID", SqlDbType.Int);
			_oCommand.Parameters["@nAuditActID"].Value = nAuditActID;

			_oCommand.Parameters.Add("@nError", SqlDbType.Int);
			_oCommand.Parameters["@nError"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@nError"].Value = 0;

			_oCommand.Parameters.Add("@cErrorText", SqlDbType.VarChar, 200);
			_oCommand.Parameters["@cErrorText"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@cErrorText"].Value = "";

			#endregion

			try
			{
				_TableAuditActsGoods = FillReadings(new SqlDataAdapter(_oCommand), _TableAuditActsGoods, "_TableAuditActsGoods");

				// primarykey
				DataColumn[] pk = new DataColumn[1];
				pk[0] = _TableAuditActsGoods.Columns["ID"];
				_TableAuditActsGoods.PrimaryKey = pk;
			}
			catch (Exception ex)
			{
				_ErrorNumber = -4;
				_ErrorStr = "Ошибка при получении списка товаров в акте...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			if (_ErrorNumber == 0)
			{
				_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
				if (_ErrorNumber != 0)
				{
					_ErrorStr = "Ошибка при получении списка товаров в акте...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		#endregion AuditActsGoods

	}
}
