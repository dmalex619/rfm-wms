using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

using RFMPublic;

/// <summary>
/// ������-������ ���������� (Device, DeviceType)
/// </summary>

namespace WMSBizObjects
{
	public class Device : BizObject
	{
		/// <summary>
		/// ID ������ ���������� (Devices)
		/// </summary>
		[Description("ID ������ ���������� (Devices)")]
		public int? DeviceID { get { return ID; } set { ID = value; } }

		/// <summary>
		/// ID ������ ��� ���������� (DevicesTypes)
		/// </summary>
		[Description("ID ������ ��� ���������� (DevicesTypes)")]
		public int? DeviceTypeID;

		protected bool? _FilterDeviceActual;
		/// <summary>
		/// ������-����: A��������� ���������� (Devices.Actual)?
		/// </summary>
		[Description("������-����: A��������� ���������� (Devices.Actual)?")]
		public bool? FilterDeviceActual { get { return _FilterDeviceActual; } set { _FilterDeviceActual = value; _NeedRequery = true; } }

		protected bool? _FilterDeviceTypeActual;
		/// <summary>
		/// ������-����: A��������� ���� ��������� (DevicesTypes.Actual)?
		/// </summary>
		[Description("������-����: A��������� ���� ��������� (DevicesTypes.Actual)?")]
		public bool? FilterDeviceTypeActual { get { return _FilterDeviceTypeActual; } set { _FilterDeviceTypeActual = value; _NeedRequery = true; } }

		protected bool? _FilterDeviceAvailable;
		/// <summary>
		/// ������-����: ��������� ���������� (Devices.Available)?
		/// </summary>
		[Description("������-����: ��������� ���������� (Devices.Available)?")]
		public bool? FilterDeviceAvailable { get { return _FilterDeviceAvailable; } set { _FilterDeviceAvailable = value; _NeedRequery = true; } }

		protected string _FilterDevicesTypesList;
		/// <summary>
		/// ������-����: ������ ����� ��������� (Devices.DeviceTypeID), ����� �������
		/// </summary>
		[Description("������-����: ������ ����� ��������� (Devices.DeviceTypeID), ����� �������")]
		public string FilterDevicesTypesList { get { return _FilterDevicesTypesList; } set { _FilterDevicesTypesList = value; } }

		protected DataTable _TableDevices;
		/// <summary>
		/// ������� ��������� (Devices, =MainTable)
		/// </summary>
		[Description("������� ��������� Devices")]
		public DataTable TableDevices { get { return _TableDevices; } }

		protected DataTable _TableDevicesTypes;
		/// <summary>
		/// ������� ����� ��������� (DevicesTypes)
		/// </summary>
		[Description("������� ����� ��������� DevicesTypes")]
		public DataTable TableDevicesTypes { get { return _TableDevicesTypes; } }

		// -------------------

		public Device()
			: base()
		{
			_MainTableName = "Devices";
			_ColumnID = "ID";
			_ColumnName = "Name";
		}

		//��������� ������� ���������
		public override bool FillData()
		{
			ClearData();

			string sqlSelect = "execute up_DevicesFill @nId, @bActual, " +
									"@bAvailable, @cDevicesTypesList";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_DevicesFill parameters

			_oCommand.Parameters.Add("@nId", SqlDbType.Int);
			if (ID != null)
				_oCommand.Parameters["@nId"].Value = ID;
			else
				_oCommand.Parameters["@nId"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bActual", SqlDbType.Bit);
			if (_FilterDeviceActual != null)
				_oCommand.Parameters["@bActual"].Value = _FilterDeviceActual;
			else
				_oCommand.Parameters["@bActual"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bAvailable", SqlDbType.Bit);
			if (_FilterDeviceAvailable != null)
				_oCommand.Parameters["@bAvailable"].Value = _FilterDeviceAvailable;
			else
				_oCommand.Parameters["@bAvailable"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cDevicesTypesList", SqlDbType.VarChar);
			if (_FilterDevicesTypesList != null)
				_oCommand.Parameters["@cDevicesTypesList"].Value = _FilterDevicesTypesList;
			else
				_oCommand.Parameters["@cDevicesTypesList"].Value = DBNull.Value;

			#endregion

			try
			{
				_MainTable = FillReadings(new SqlDataAdapter(_oCommand), _MainTable, _MainTableName);
				_NeedRequery = false;
			}
			catch (Exception ex)
			{
				_ErrorNumber = -1;
				_ErrorStr = "������ ��� ��������� ������ ���������..." + Convert.ToChar(13) + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// ������� ������-�����
		/// </summary>
		public void ClearFilters()
		{
			_FilterDeviceActual = null;
			_FilterDeviceTypeActual = null;
			_FilterDeviceAvailable = null;
			_FilterDevicesTypesList = null;
			//_NeedRequery = false;
		}

		/// <summary>
		/// ��������� ������� ����� ��������� (TableDeviceTypes)
		/// </summary>
		public bool FillTableDeviceTypes()
		{
			string sqlSelect = "select DT.ID, DT.Name, " +
					"DT.Actual " +
				"from DevicesTypes DT " +
				"where 1 = 1 ";
			StringBuilder sb = new StringBuilder(sqlSelect);
			if (_FilterDeviceTypeActual != null)
				sb.Append(" and DT.Actual = " + ((bool)_FilterDeviceTypeActual ? "1" : "0"));
			if (_FilterDevicesTypesList != null)
				sb.Append(" and charindex(',' + ltrim(str(DT.ID)) + ',', ',' + '" + _FilterDevicesTypesList + "' + ',') > 0 ");
			sb.Append(" order by DT.Name, DT.ID");
			SqlCommand _oCommand = new SqlCommand(sb.ToString(), _Connect);
			try
			{
				_TableDevicesTypes = FillReadings(new SqlDataAdapter(_oCommand), _TableDevicesTypes, "TableDevicesTypes");
			}
			catch (Exception ex)
			{
				_ErrorNumber = -11;
				_ErrorStr = "������ ��� ��������� ������ ����� ���������..." + Convert.ToChar(13) + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}
	}
}