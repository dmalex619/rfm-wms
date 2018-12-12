using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

using RFMPublic;

/// <summary>
/// Бизнес-объект Хост (Host)
/// </summary>

namespace WMSBizObjects
{

#region Host

	public class Host : BizObject 
	{
		protected string _IDList;
		/// <summary>
		/// Список кодов ID хостов (Hosts.ID)
		/// </summary>
		[Description("Список кодов ID хостов (Hosts.ID)")]
		public string IDList { get { return _IDList; } set { _IDList = value; _NeedRequery = true; } }

		#region Фильтры

		protected string _FilterNameContext;
		/// <summary>
		/// Фильтр-поле: название хоста, контекст (Hosts.Name)
		/// </summary>
		[Description("Фильтр-поле: название хоста, контекст (Hosts.Name)")]
		public string FilterNameContext { get { return _FilterNameContext; } set { _FilterNameContext = value; _NeedRequery = true; } }

		protected string _FilterShortCode;
		/// <summary>
		/// Фильтр-поле: символьный код хоста, контекст (Hosts.ShortCode)
		/// </summary>
		[Description("Фильтр-поле: символьный код хоста, контекст (Hosts.ShortCode)")]
		public string FilterShortCode { get { return _FilterShortCode; } set { _FilterShortCode = value; _NeedRequery = true; } }

		protected bool? _FilterActual;
		/// <summary>
		/// Фильтр-поле: актуальные клиенты (Partners.Actual)?
		/// </summary>
		[Description("Фильтр-поле: актуальные клиенты (Partners.Actual)?")]
		public bool? FilterActual { get { return _FilterActual; } set { _FilterActual = value; _NeedRequery = true; } }

		#endregion Фильтры

		// -------------------
		
		public Host() : base()
		{
			_MainTableName = "Hosts";
			_ColumnID = "ID";
			_ColumnName = "Name"; 
		}

		#region FillData

		/// <summary>
		/// получение полного списка хостов в MainTable
		/// </summary>
		public override bool FillData()
		{
			ClearData();

			string sqlSelect = "execute up_HostsFill @nID, @cIDList, " +
									"@cNameContext, " +
									"@cShortCode, " + 
									"@bActual ";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_HostsFill Parameters

			SqlParameter _oParameter = _oCommand.Parameters.Add("@nID", SqlDbType.Int);
			if (_ID != null)
				_oParameter.Value = _ID;
			else
				_oParameter.Value = DBNull.Value;

			_oParameter = _oCommand.Parameters.Add("@cIDList", SqlDbType.VarChar);
			if (_IDList != null)
				_oParameter.Value = _IDList;
			else
				_oParameter.Value = DBNull.Value;

			_oParameter = _oCommand.Parameters.Add("@cNameContext", SqlDbType.VarChar, 200);
			if (_FilterNameContext != null)
				_oParameter.Value = _FilterNameContext;
			else
				_oParameter.Value = DBNull.Value;

			_oParameter = _oCommand.Parameters.Add("@cShortCode", SqlDbType.VarChar, 200);
			if (_FilterShortCode != null)
				_oParameter.Value = _FilterShortCode;
			else
				_oParameter.Value = DBNull.Value;

			_oParameter = _oCommand.Parameters.Add("@bActual", SqlDbType.Bit);
			if (_FilterActual != null)
				_oParameter.Value = _FilterActual;
			else
				_oParameter.Value = DBNull.Value;

			#endregion 

			try
			{
				_MainTable = FillReadings(new SqlDataAdapter(_oCommand), _MainTable, _MainTableName);
				_MainTable.PrimaryKey = new DataColumn[] { _MainTable.Columns[_ColumnID] };
				_NeedRequery = false;
			}
			catch (Exception ex)
			{
				_ErrorNumber = -1;
				_ErrorStr = "Ошибка при получении общего списка хостов..." + Convert.ToChar(13) + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// очистка фильтр-полей
		/// </summary>
		public void ClearFilters()
		{
			_IDList = null;

			_FilterNameContext = null;
			_FilterShortCode = null;
			_FilterActual = null;
		}

		#endregion FillData

		#region Count

		public int Count()
		{
			_FilterActual = true;
			FillData();
			return (MainTable.Rows.Count);
		}

		#endregion Count
	}

#endregion Host

}
