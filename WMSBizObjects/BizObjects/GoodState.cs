using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

using RFMPublic;

/// <summary>
/// Бизнес-объект Состояние товара (GoodState)
/// </summary>

namespace WMSBizObjects
{
	public class GoodState : BizObject
	{

		protected bool? _FilterActual;
		/// <summary>
		/// Фильтр-поле: актуальные состояния товара?
		/// </summary>
		[Description("Фильтр-поле: актуальные состояния товара?")]
		public bool? FilterActual { get { return _FilterActual; } set { _FilterActual = value; } }

		protected bool? _FilterBasic;
		/// <summary>
		/// Фильтр-поле: базовые состояния товара?
		/// </summary>
		[Description("Фильтр-поле: базовые состояния товара?")]
		public bool? FilterBasic { get { return _FilterBasic; } set { _FilterBasic = value; } }

		// -------------------

		public GoodState()
			: base()
		{
			_MainTableName = "GoodState";
			_ColumnID = "ID";
			_ColumnName = "Name";
		}

		//получение таблицы складских зон 
		public override bool FillData()
		{
			ClearData();

			string sqlSelect = "select GS.ID, GS.Name, " +
					"GS.Note, " +
					"GS.Basic, GS.Actual " +
				"from GoodsStates GS " +
				"left join Partners Ow on GS.OwnerID = Ow.ID " +
				"where 1 = 1 ";
			StringBuilder sb = new StringBuilder(sqlSelect);
			if (ID != null)
				sb.Append(" and GS.ID = " + ID.ToString());
			if (_FilterActual != null)
				sb.Append(" and GS.Actual = " + ((bool)_FilterActual ? "1" : "0"));
			if (_FilterBasic != null)
				sb.Append(" and GS.Basic = " + ((bool)_FilterBasic ? "1" : "0"));
			sb.Append(" order by GS.Name, GS.ID");
			SqlCommand _oCommand = new SqlCommand(sb.ToString(), _Connect);
			try
			{
				_MainTable = FillReadings(new SqlDataAdapter(_oCommand), _MainTable, _MainTableName);
			}
			catch (Exception ex)
			{
				_ErrorNumber = -1;
				_ErrorStr = "Ошибка при получении списка состояний товара..." + Convert.ToChar(13) + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// очистка фильтр-полей
		/// </summary>
		public void ClearFilters()
		{
			_FilterActual = null;
			_FilterBasic = null;
		}
	}
}
