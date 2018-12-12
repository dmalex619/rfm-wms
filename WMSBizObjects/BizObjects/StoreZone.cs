using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

using RFMPublic;

/// <summary>
/// ������-������ ��������� ���� (StoreZone, StoreZoneType)
/// </summary>

namespace WMSBizObjects
{
	public class StoreZone : BizObject
	{
		/// <summary>
		/// ID ������ ��������� ���� (StoreZone)
		/// </summary>
		[Description("ID ������ ��������� ���� (StoreZone)")]
		public int? StoreZoneID { get { return ID; } set { ID = value; } }

		/// <summary>
		/// ID ������ ��� ��������� ���� (StoreZoneType)
		/// </summary>
		[Description("ID ������ ��� ��������� ���� (StoreZoneType)")]
		public int? StoreZoneTypeID;

		protected bool? _FilterStoreZoneActual;
		/// <summary>
		/// ������-����: ���������� ����?
		/// </summary>
		[Description("������-����: ���������� ����?")]
		public bool? FilterStoreZoneActual { get { return _FilterStoreZoneActual; } set { _FilterStoreZoneActual = value; _NeedRequery = true; } }

		protected bool? _FilterStoreZoneTypeActual;
		/// <summary>
		/// ������-����: ���������� ���� ���?
		/// </summary>
		[Description("������-����: ���������� ���� ���?")]
		public bool? FilterStoreZoneTypeActual { get { return _FilterStoreZoneTypeActual; } set { _FilterStoreZoneTypeActual = value; _NeedRequery = true; } }

		protected string _FilterStoreZoneTypeShortCode;
		/// <summary>
		/// ������-����: ���������� ��� ���� ����
		/// </summary>
		[Description("������-����: ���������� ��� ���� ����")]
		public string FilterStoreZoneTypeShortCode { get { return _FilterStoreZoneTypeShortCode; } set { _FilterStoreZoneTypeShortCode = value; _NeedRequery = true; } }

		protected bool? _FilterStoreZoneTypeForFrames;
		/// <summary>
		/// ������-����: ������ ��� �����������?
		/// </summary>
		[Description("������-����: ������ ��� �����������?")]
		public bool? FilterStoreZoneTypeForFrames { get { return _FilterStoreZoneTypeForFrames; } set { _FilterStoreZoneTypeForFrames = value; _NeedRequery = true; } }

		protected bool? _FilterStoreZoneTypeForStorage;
		/// <summary>
		/// ������-����: ������ ��� ��������������� ��������?
		/// </summary>
		[Description("������-����: ������ ��� ��������������� ��������?")]
		public bool? FilterStoreZoneTypeForStorage { get { return _FilterStoreZoneTypeForStorage; } set { _FilterStoreZoneTypeForStorage = value; _NeedRequery = true; } }

		protected bool? _FilterStoreZoneTypeForPicking;
		/// <summary>
		/// ������-����: ������ ��� �������?
		/// </summary>
		[Description("������-����: ������ ��� �������?")]
		public bool? FilterStoreZoneTypeForPicking { get { return _FilterStoreZoneTypeForPicking; } set { _FilterStoreZoneTypeForPicking = value; _NeedRequery = true; } }

		protected bool? _FilterStoreZoneTypeForInputs;
		/// <summary>
		/// ������-����: ������ ��� �������?
		/// </summary>
		[Description("������-����: ������ ��� �������?")]
		public bool? FilterStoreZoneTypeForInputs { get { return _FilterStoreZoneTypeForInputs; } set { _FilterStoreZoneTypeForInputs = value; _NeedRequery = true; } }

		protected bool? _FilterStoreZoneTypeForOutputs;
		/// <summary>
		/// ������-����: ������ ��� �������?
		/// </summary>
		[Description("������-����: ������ ��� �������?")]
		public bool? FilterStoreZoneTypeForOutputs { get { return _FilterStoreZoneTypeForOutputs; } set { _FilterStoreZoneTypeForOutputs = value; _NeedRequery = true; } }

		protected DataTable _TableStoresZones;
		/// <summary>
		/// ������� ��������� ��� (StoresZones, =MainTable)
		/// </summary>
		[Description("������� ��������� ��� StoresZones")]
		public DataTable TableStoresZones { get { return _TableStoresZones; } }

		protected DataTable _TableStoresZonesTypes;
		/// <summary>
		/// ������� ����� ��������� ��� (StoresZonesTypes)
		/// </summary>
		[Description("������� ����� ��������� ��� StoresZonesTypes")]
		public DataTable TableStoresZonesTypes { get { return _TableStoresZonesTypes; } }

		// -------------------

		public StoreZone()
			: base()
		{
			_MainTableName = "StoresZones";
			_ColumnID = "ID";
			_ColumnName = "Name";
		}

		//��������� ������� ��������� ��� 
		public override bool FillData()
		{
			ClearData();

			string sqlSelect = "select SZ.ID, SZ.Name, " +
					"SZT.ShortCode, SZT.AddressMask, " +
					"SZ.StoreZoneTypeID, SZT.Name as StoreZoneTypeName, " +
					"SZ.Sequence, SZ.MaxPalletQnt, SZ.Actual, " +
					"SZ.NamePrefix, SZ.NameSuffix, " +
					"SZT.ForFrames, SZT.ForStorage, SZT.ForPicking, " +
					"SZT.ForInputs, SZT.ForOutputs, " +
					"SZT.Special, " +
					"SZT.GoodsMono, " +
					"SZT.Actual as StoreZoneTypeActual " +
				"from StoresZones SZ " +
				"left join StoresZonesTypes SZT on SZ.StoreZoneTypeID = SZT.ID " +
				"where 1 = 1 ";
			StringBuilder sb = new StringBuilder(sqlSelect);
			if (StoreZoneID != null)
				sb.Append(" and SZ.ID = " + StoreZoneID.ToString());
			if (StoreZoneTypeID != null)
				sb.Append(" and SZT.ID = " + StoreZoneTypeID.ToString());
			if (_FilterStoreZoneActual != null)
				sb.Append(" and SZ.Actual = " + ((bool)_FilterStoreZoneActual ? "1" : "0"));
			if (_FilterStoreZoneTypeActual != null)
				sb.Append(" and SZT.Actual = " + ((bool)_FilterStoreZoneTypeActual ? "1" : "0"));
			if (_FilterStoreZoneTypeShortCode != null)
				sb.Append(" and charindex('" + _FilterStoreZoneTypeShortCode + "', SZT.ShortCode) > 0 ");
			if (_FilterStoreZoneTypeForFrames != null)
				sb.Append(" and isNull(SZT.ForFrames," + ((bool)_FilterStoreZoneTypeForFrames ? "1" : "0") + ") = " + ((bool)_FilterStoreZoneTypeForFrames ? "1" : "0"));
			if (_FilterStoreZoneTypeForStorage != null)
				sb.Append(" and SZT.ForStorage = " + ((bool)_FilterStoreZoneTypeForStorage ? "1" : "0"));
			if (_FilterStoreZoneTypeForPicking != null)
				sb.Append(" and SZT.ForPicking = " + ((bool)_FilterStoreZoneTypeForPicking ? "1" : "0"));
			if (_FilterStoreZoneTypeForInputs != null)
				sb.Append(" and SZT.ForInputs = " + ((bool)_FilterStoreZoneTypeForInputs ? "1" : "0"));
			if (_FilterStoreZoneTypeForOutputs != null)
				sb.Append(" and SZT.ForOutputs = " + ((bool)_FilterStoreZoneTypeForOutputs ? "1" : "0"));
			sb.Append(" order by SZ.Name, SZ.ID");
			SqlCommand _oCommand = new SqlCommand(sb.ToString(), _Connect);
			try
			{
				_MainTable = FillReadings(new SqlDataAdapter(_oCommand), _MainTable, _MainTableName);
				_TableStoresZones = _DS.Tables[_MainTableName];

				// primarykey
				DataColumn[] pk = new DataColumn[1];
				pk[0] = _MainTable.Columns[_ColumnID];
				_MainTable.PrimaryKey = pk;

				_NeedRequery = true;
			}
			catch (Exception ex)
			{
				_ErrorNumber = -1;
				_ErrorStr = "������ ��� ��������� ������ ��������� ���..." + Convert.ToChar(13) + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// ������� ������-�����
		/// </summary>
		public void ClearFilters()
		{
			_FilterStoreZoneActual = null;
			_FilterStoreZoneTypeActual = null;
			_FilterStoreZoneTypeShortCode = null;
			_FilterStoreZoneTypeForFrames = null;
			_FilterStoreZoneTypeForStorage = null;
			_FilterStoreZoneTypeForInputs = null;
			//_NeedRequery = false;
		}

		/// <summary>
		/// ��������� ������� ����� ��������� ��� (TableStoresZonesTypes)
		/// </summary>
		public bool FillTableStoresZonesTypes()
		{
			string sqlSelect = "select SZT.ID, SZT.Name, " +
					"SZT.ShortCode, SZT.AddressMask, " +
					"SZT.ForFrames, SZT.ForStorage, SZT.ForInputs, SZT.GoodsMono, " +
					"SZT.Actual " +
				"from StoresZonesTypes SZT " +
				"where 1 = 1 ";
			StringBuilder sb = new StringBuilder(sqlSelect);
			if (StoreZoneTypeID != null)
				sb.Append(" and SZT.ID = " + StoreZoneTypeID.ToString());
			if (_FilterStoreZoneTypeActual != null)
				sb.Append(" and SZT.Actual = " + ((bool)_FilterStoreZoneTypeActual ? "1" : "0"));
			if (_FilterStoreZoneTypeShortCode != null)
				sb.Append(" and charindex('" + _FilterStoreZoneTypeShortCode + "', SZT.ShortCode) > 0 ");
			if (_FilterStoreZoneTypeForFrames != null)
				sb.Append(" and SZT.ForFrames = " + ((bool)_FilterStoreZoneTypeForFrames ? "1" : "0"));
			if (_FilterStoreZoneTypeForStorage != null)
				sb.Append(" and SZT.ForStorage = " + ((bool)_FilterStoreZoneTypeForStorage ? "1" : "0"));
			if (_FilterStoreZoneTypeForInputs != null)
				sb.Append(" and SZT.ForInputs = " + ((bool)_FilterStoreZoneTypeForInputs ? "1" : "0"));
			sb.Append(" order by SZT.Name, SZT.ID");
			SqlCommand _oCommand = new SqlCommand(sb.ToString(), _Connect);
			try
			{
				_TableStoresZonesTypes = FillReadings(new SqlDataAdapter(_oCommand), _TableStoresZonesTypes, "TableStoresZonesTypes");

				// primarykey
				DataColumn[] pk = new DataColumn[1];
				pk[0] = _TableStoresZonesTypes.Columns[0];
				_TableStoresZonesTypes.PrimaryKey = pk;
			}
			catch (Exception ex)
			{
				_ErrorNumber = -11;
				_ErrorStr = "������ ��� ��������� ������ ����� ��������� ���..." + Convert.ToChar(13) + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}
	}
}