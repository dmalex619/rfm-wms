using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

using RFMPublic;

/// <summary>
/// Бизнес-объект Этикетка для печати на этикеточном принтере
/// </summary>
/// 
namespace WMSBizObjects
{
	public class BarCodeLabel : BizObject
	{

		// Фильтры

		protected bool? _FilterActual;
		/// <summary>
		/// Фильтр-поле: актуальность
		/// </summary>
		[Description("Фильтр-поле: Aктуальность (BarCodeLabels.Actual)")]
		public bool? FilterActual { get { return _FilterActual; } set { _FilterActual = value; _NeedRequery = true; } }

		protected string _FilterType;
		/// <summary>
		/// Фильтр-поле: тип (2 символа)
		/// </summary>
		[Description("Фильтр-поле: тип (2 символа) (BarCodeLabels.Type)")]
		public string FilterType { get { return _FilterType; } set { _FilterType = value; _NeedRequery = true; } }


		// ----------------------------

		public BarCodeLabel()
			: base()
		{
			_MainTableName = "BarCodeLabel";
			_ColumnID = "ID";
			_ColumnName = "Name";
		}


		public override bool FillData()
		{
			ClearData();

			string sqlSelect = "execute up_BarCodeLabelsFill @nID, @cType, @bActual";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_BarCodeLabelsFill parameters

			_oCommand.Parameters.Add("@nID", SqlDbType.Int);
			if (_ID != null)
				_oCommand.Parameters["@nID"].Value = _ID;
			else
				_oCommand.Parameters["@nID"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cType", SqlDbType.VarChar);
			if (_FilterType != null)
				_oCommand.Parameters["@cType"].Value = _FilterType;
			else
				_oCommand.Parameters["@cType"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bActual", SqlDbType.Bit);
			if (_FilterActual != null)
				_oCommand.Parameters["@bActual"].Value = _FilterActual;
			else
				_oCommand.Parameters["@bActual"].Value = DBNull.Value;

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
				_ErrorStr = "Ошибка при получении списка этикеток..." + Convert.ToChar(13) + ex.Message;
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
			_FilterType = null;
			//_NeedRequery = true;
		}
	}
}
