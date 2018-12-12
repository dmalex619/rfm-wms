using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace WMSBizObjects
{
	/// <summary>
	/// ������� ����� ������-�������.
	/// </summary>
	public abstract class BizObject
	{
		// ���������� �������
		protected SqlConnection _Connect;

		protected DataSet _DS = new DataSet();
		/// <summary>
		/// ������������ ������ � �������.
		/// </summary>
		[Category("WMS")]
		[Description("���������� ����� ������, �������������� ������-��������")]
		public DataSet DS
		{
			get { return _DS; }
		}

		protected int? _ID = null;
		/// <summary>
		/// ID ������� 
		/// </summary>
		[Category("WMS")]
		[Description("ID �������")]
		public int? ID
		{
			get { return _ID; }
			set { _ID = value; }
		}
		/// <summary>
		/// ������� ���������� �������.
		/// </summary>
		[Category("WMS")]
		[Description("���������� <true> ��� ���������� ������� � <false> ��� ������")]
		public bool IsSingleObject
		{
			get { return (_ID.HasValue); }
		}

		protected string _MainTableName = "MainTable";
		/// <summary>
		/// ��� ������� ������� ������-�������.
		/// </summary>
		[Category("WMS")]
		[Description("��� ������� ������� ������-�������")]
		public string MainTableName
		{
			get { return _MainTableName; }
			set { _MainTableName = value; }
		}

		protected DataTable _MainTable;
		/// <summary>
		/// ������� MainTable � ds - �������� ������ ������-�������.
		/// </summary>
		[Category("WMS")]
		[Description("������� MainTable � ds - �������� ������ ������-�������")]
		public DataTable MainTable
		{
			get { return _MainTable; }
			set { _MainTable = value; }
		}

		protected bool _NeedRequery;
		/// <summary>
		/// ��������� ���������� ������� ������� ������-�������?
		/// </summary>
		[Category("WMS")]
		[Description("��������� ���������� ������� ������� ������-�������?")]
		public bool NeedRequery
		{
			get { return _NeedRequery; }
			set { _NeedRequery = value; }
		}

		protected string _ColumnID = "ID";
		/// <summary>
		/// �������� ID-����
		/// </summary>
		[Category("WMS")]
		[Description("�������� ID-����")]
		public string ColumnID
		{
			get { return _ColumnID; }
			set { _ColumnID = value; }
		}

		protected string _ColumnName = "Name";
		/// <summary>
		/// �������� ���� ������������
		/// </summary>
		[Category("WMS")]
		[Description("�������� ���� ������������")]
		public string ColumnName
		{ 
			get { return _ColumnName; }
			set { _ColumnName = value; }
		}

		protected string _SelectOrderBy = "";
		/// <summary>
		/// ������� ���������� ��� select � FillData
		/// </summary>
		[Category("WMS")]
		[Description("�������������� ������� ��� select � FillData")]
		public string SelectOrderBy
		{
			get { return _SelectOrderBy; }
			set { _SelectOrderBy = value; }
		}

		protected int _ErrorNumber = 0;
		/// <summary>
		/// ��� ������ 
		/// </summary>
		[Category("WMS")]
		[Description("��� ������")]
		public int ErrorNumber
		{
			get { return _ErrorNumber; }
			set { _ErrorNumber = value; }
		}

		protected string _ErrorStr = "";
		/// <summary>
		/// ����� ������ 
		/// </summary>
		[Category("WMS")]
		[Description("����� ������")]
		public string ErrorStr
		{
			get { return _ErrorStr; }
			set { _ErrorStr = value; }
		}

		// --------------------------------------------------------------------------------

		/// <summary>
		/// ������� ����������� ������-�������.
		/// ������������� ������ ���������� � ������� ������ ���������� � ��.
		/// </summary>
		public BizObject()
		{
			SqlLink sqlLink = new SqlLink();
			if (sqlLink.ConnStr == null)
			{
				_ErrorNumber = 1;
				MessageBox.Show(sqlLink.ErrorStr, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			_Connect = new SqlConnection(sqlLink.ConnStr);

			// ������� _MainTable (_ds.Tables[MainTable]) - ��� �������
			_DS.Tables.Add(_MainTableName);
			_MainTable = _DS.Tables[_MainTableName];

			_ID = null;
		}

		public BizObject(int SingleObjectID) : this()
		{
			_ID = SingleObjectID;
		}

		/// <summary>
		/// ��������� ��������� ��������� ������ ��� ������-������� _ds._MainTable
		/// � �������������� select �� ��������������� ������� ��_ServerTable.
		/// </summary>
		public abstract bool FillData();

		/// <summary>
		/// ������� ��������� ��������� ������ ��� ������-������� �� ������� ��.
		/// ������� ������� � ������ MainTable � ��������� ds
		/// </summary>
		public bool ClearData()
		{
			if ((_MainTable != null) && (_MainTable.Rows.Count > 0))
				_MainTable.Clear();
			return true;
		}

		/// <summary>
		/// ������� ���� ������ � ��������� ds
		/// </summary>
		public bool ClearData(bool Full)
		{
			foreach (DataTable _Table in _DS.Tables)
				_Table.Clear();
			return true;
		}

		/// <summary>
		/// ������� ������
		/// </summary>
		public void ClearError()
		{
			_ErrorNumber = 0;
			_ErrorStr = "";
		}

		public DataTable FillReadings(SqlDataAdapter da, DataTable dt, string dtName)
		{
			if (DS.Tables.Contains(dtName))
				DS.Tables.Remove(dtName);
			dt = new DataTable(dtName);
            
            try { da.Fill(dt); }
            catch (Exception ex) { }

			DS.Tables.Add(dt);
			return (dt);
		}
		public void FillReadings(SqlDataAdapter da)
		{
			DS.Tables.Clear();
			da.Fill(DS);
		}
			
	}
}