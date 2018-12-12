using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

using RFMPublic;

/// <summary>
/// Бизнес-объект Контрагент (Partner)
/// </summary>
/// 
namespace WMSBizObjects
{
	public class Partner : BizObject
	{
		protected string _IDList;
		/// <summary>
		/// Список ID (Partners.ID)
		/// </summary>
		[Description("Список ID (Partners.ID)")]
		public string IDList { get { return _IDList; } set { _IDList = value; _NeedRequery = true; } }

		// Фильтры
		#region Filters

		protected string _FilterHostsList;
		/// <summary>
		/// Фильтр-поле: список кодов host-ов (AuditActs.HostID)
		/// </summary>
		[Description("Фильтр-поле: список кодов host-ов (AuditActs.HostID)")]
		public string FilterHostsList { get { return _FilterHostsList; } set { _FilterHostsList = value; _NeedRequery = true; } }

		protected string _FilterNameContext;
		/// <summary>
		/// Фильтр-поле: контекст названия (Partners.Name)
		/// </summary>
		[Description("Фильтр-поле: контекст названия (Partners.Name)?")]
		public string FilterNameContext { get { return _FilterNameContext; } set { _FilterNameContext = value; _NeedRequery = true; } }

		protected bool? _FilterActual;
		/// <summary>
		/// Фильтр-поле: актуальные контрагенты (Partners.Actual)?
		/// </summary>
		[Description("Фильтр-поле: актуальные контрагенты (Partners.Actual)?")]
		public bool? FilterActual { get { return _FilterActual; } set { _FilterActual = value; _NeedRequery = true; } }

		protected bool? _FilterOwner;
		/// <summary>
		/// Фильтр-поле: владельцы товара (Partners.Owner)?
		/// </summary>
		[Description("Фильтр-поле: владельцы товара (Partners.Owner)?")]
		public bool? FilterOwner { get { return _FilterOwner; } set { _FilterOwner = value; _NeedRequery = true; } }

		protected bool? _FilterSeparatePicking;
		/// <summary>
		/// Фильтр-поле: учет остатков товара для владельцев (Partners.SeparatePicking)?
		/// </summary>
		[Description("Фильтр-поле: учет остатков товара для владельцев (Partners.SeparatePicking)?")]
		public bool? FilterSeparatePicking { get { return _FilterSeparatePicking; } set { _FilterSeparatePicking = value; _NeedRequery = true; } }

		protected bool? _FilterExistsInInputs;
		/// <summary>
		/// Фильтр-поле: партнер является поставщиком в приходах (Partners.ID -> Inputs.PartnersID)?
		/// </summary>
		[Description("Фильтр-поле: партнер является поставщиком в приходах (Partners.ID -> Inputs.PartnersID)?")]
		public bool? FilterExistsInInputs { get { return _FilterExistsInInputs; } set { _FilterExistsInInputs = value; _NeedRequery = true; } }

		#endregion Filters

		// ----------------------------

		public Partner()
			: base()
		{
			_MainTableName = "Partners";
			_ColumnID = "ID";
			_ColumnName = "Name";
		}


		public override bool FillData()
		{
			ClearData();

			string sqlSelect = "execute up_PartnersFill @nID, @cIDList, " + 
									"@cHostsList, " + 
									"@cNameContext, " +
									"@bActual, @bOwner, " +
									"@bSeparatePicking, " +
									"@bExistsInInputs";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_PartnersFill parameters

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

			_oCommand.Parameters.Add("@cNameContext", SqlDbType.VarChar);
			if (_FilterNameContext != null)
				_oCommand.Parameters["@cNameContext"].Value = _FilterNameContext;
			else
				_oCommand.Parameters["@cNameContext"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bActual", SqlDbType.Bit);
			if (_FilterActual != null)
				_oCommand.Parameters["@bActual"].Value = _FilterActual;
			else
				_oCommand.Parameters["@bActual"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bOwner", SqlDbType.Bit);
			if (_FilterOwner != null)
				_oCommand.Parameters["@bOwner"].Value = _FilterOwner;
			else
				_oCommand.Parameters["@bOwner"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bSeparatePicking", SqlDbType.Bit);
			if (_FilterSeparatePicking != null)
				_oCommand.Parameters["@bSeparatePicking"].Value = _FilterSeparatePicking;
			else
				_oCommand.Parameters["@bSeparatePicking"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bExistsInInputs", SqlDbType.Bit);
			if (_FilterExistsInInputs != null)
				_oCommand.Parameters["@bExistsInInputs"].Value = _FilterExistsInInputs;
			else
				_oCommand.Parameters["@bExistsInInputs"].Value = DBNull.Value;

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
				_ErrorStr = "Ошибка при получении списка контрагентов..." + Convert.ToChar(13) + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		// только 
		public bool FillDataOwners()
		{
			ClearData();

			string sqlSelect = "select * from V_Owners_SeparatePicking order by Name";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

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
				_ErrorStr = "Ошибка при получении списка контрагентов..." + Convert.ToChar(13) + ex.Message;
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
			_FilterNameContext = null;
			_FilterActual = null;
			_FilterOwner = null;
			_FilterSeparatePicking = null;
			_FilterExistsInInputs = null;
			//_NeedRequery = true;
		}
	}
}
