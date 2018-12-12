using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

using RFMPublic;

/// <summary>
/// ������-������ ������ "������" ������ (OldCellsContents)
/// </summary>
namespace WMSBizObjects
{
	public class OldCellsContents : BizObject
	{
		protected DataTable _TableCells;
		/// <summary>
		/// ������� �����
		/// </summary>
		[Description("������� �����")]
		public DataTable TableCells { get { return _TableCells; } }

		// ----------------------------

		public OldCellsContents()
			: base()
		{
			_MainTableName = "OldCellsContents";
			_ColumnID = "ID";
			_ColumnName = "CellAddress";
		}

		public override bool FillData()
		{
			ClearData();

			string sqlSelect = "exec up_OldCellsContentsFill";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			try
			{
				_MainTable = FillReadings(new SqlDataAdapter(_oCommand), _MainTable, _MainTableName);
				_NeedRequery = false;
			}
			catch (Exception ex)
			{
				_ErrorNumber = -1;
				_ErrorStr = "������ ��� ��������� ������ ������ ������..." + Convert.ToChar(13) + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}
	}
}