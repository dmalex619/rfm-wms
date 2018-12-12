using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

using RFMPublic;

/// <summary>
/// ������-������ �����-�������� (Good, Packing)
/// </summary>

namespace WMSBizObjects
{
	public class Good : BizObject
	{
		/// <summary>
		/// ID ������ ����� (Goods)
		/// </summary>
		[Description("ID ������ ����� (Goods)")]
		public int? GoodID;
		/// <summary>
		/// ID ������ �������� (Packings)
		/// </summary>
		[Description("ID ������ �������� (Packings)")]
		public int? PackingID;

		// �������
		#region Filters

		protected string _FilterGoodsIDList;
		/// <summary>
		/// ������-����: ������ ID �������
		/// </summary>
		[Description("������-����: ������ ID �������")]
		public string FilterGoodsIDList { get { return _FilterGoodsIDList; } set { _FilterGoodsIDList = value; _NeedRequery = true; } }

		protected string _FilterPackingsIDList;
		/// <summary>
		/// ������-����: ������ ID ��������
		/// </summary>
		[Description("������-����: ������ ID ��������")]
		public string FilterPackingsIDList { get { return _FilterPackingsIDList; } set { _FilterPackingsIDList = value; _NeedRequery = true; } }

		protected string _FilterHostsList;
		/// <summary>
		/// ������-����: ������ ����� host-��
		/// </summary>
		[Description("������-����: ������ ����� host-��")]
		public string FilterHostsList { get { return _FilterHostsList; } set { _FilterHostsList = value; _NeedRequery = true; } }

		protected bool? _FilterGoodsActual;
		/// <summary>
		/// ������-����: ���������� ������?
		/// </summary>
		[Description("������-����: ���������� ������?")]
		public bool? FilterGoodsActual { get { return _FilterGoodsActual; } set { _FilterGoodsActual = value; _NeedRequery = true; } }

		protected bool? _FilterPackingsActual;
		/// <summary>
		/// ������-����: ���������� ��������?
		/// </summary>
		[Description("������-����: ���������� ��������?")]
		public bool? FilterPackingsActual { get { return _FilterPackingsActual; } set { _FilterPackingsActual = value; _NeedRequery = true; } }

		protected string _FilterGoodBarCode;
		/// <summary>
		/// ������-����: �����-��� ������
		/// </summary>
		[Description("������-����: �����-��� ������")]
		public string FilterGoodBarCode { get { return _FilterGoodBarCode; } set { _FilterGoodBarCode = value; _NeedRequery = true; } }

		protected string _FilterPackingBarCode;
		/// <summary>
		/// ������-����: �����-��� ��������
		/// </summary>
		[Description("������-����: �����-��� ��������")]
		public string FilterPackingBarCode { get { return _FilterPackingBarCode; } set { _FilterPackingBarCode = value; _NeedRequery = true; } }

		protected string _FilterGoodNameContext;
		/// <summary>
		/// ������-����: �������� ������ (��������)
		/// </summary>
		[Description("������-����: �������� ������ (��������)")]
		public string FilterGoodNameContext { get { return _FilterGoodNameContext; } set { _FilterGoodNameContext = value; _NeedRequery = true; } }

		protected string _FilterGoodsGroupsList;
		/// <summary>
		/// ������-����: ������ �������� ����� (����� �������)
		/// </summary>
		[Description("������-����: ������ �������� ����� (����� �������)")]
		public string FilterGoodsGroupsList { get { return _FilterGoodsGroupsList; } set { _FilterGoodsGroupsList = value; _NeedRequery = true; } }

		protected string _FilterGoodsBrandsList;
		/// <summary>
		/// ������-����: ������ ������� (����� �������)
		/// </summary>
		[Description("������-����: ������ ������� (����� �������)")]
		public string FilterGoodsBrandsList { get { return _FilterGoodsBrandsList; } set { _FilterGoodsBrandsList = value; _NeedRequery = true; } }

		protected DataTable _TableGoodsGroups;
		/// <summary>
		/// ������� �������� �����
		/// </summary>
		[Description("������� �������� �����")]
		public DataTable TableGoodsGroups { get { return _TableGoodsGroups; } }

		protected bool? _TableGoodsGroups_FilterActual;
		/// <summary>
		/// ������-���� ��� ������� �������� ����� : ������������
		/// </summary>
		[Description("������-���� ��� ������� �������� ����� : ������������")]
		public bool? TableGoodsGroups_FilterActual { get { return _TableGoodsGroups_FilterActual; } set { _TableGoodsGroups_FilterActual = value; _NeedRequery = true; } }

		protected string _TableGoodsGroups_FilterNameContext;
		/// <summary>
		/// ������-���� ��� ������� �������� ����� : �������� ��������
		/// </summary>
		[Description("������-���� ��� ������� �������� ����� : �������� ��������")]
		public string TableGoodsGroups_FilterNameContext { get { return _TableGoodsGroups_FilterNameContext; } set { _TableGoodsGroups_FilterNameContext = value; _NeedRequery = true; } }

		protected DataTable _TableGoodsBrands;
		/// <summary>
		/// ������� �������
		/// </summary>
		[Description("������� �������")]
		public DataTable TableGoodsBrands { get { return _TableGoodsBrands; } }

		protected bool? _TableGoodsBrands_FilterActual;
		/// <summary>
		/// ������-���� ��� ������� ������� : ������������
		/// </summary>
		[Description("������-���� ��� ������� ������� : ������������")]
		public bool? TableGoodsBrands_FilterActual { get { return _TableGoodsBrands_FilterActual; } set { _TableGoodsBrands_FilterActual = value; _NeedRequery = true; } }

		protected string _TableGoodsBrands_FilterNameContext;
		/// <summary>
		/// ������-���� ��� ������� ������� : �������� ��������
		/// </summary>
		[Description("������-���� ��� ������� ������� : �������� ��������")]
		public string TableGoodsBrands_FilterNameContext { get { return _TableGoodsBrands_FilterNameContext; } set { _TableGoodsBrands_FilterNameContext = value; _NeedRequery = true; } }

		protected DataTable _TablePalletsTypes;
		/// <summary>
		/// ������� ����� �������� (PalletsTypes)
		/// </summary>
		[Description("������� ����� �������� PalletsTypes")]
		public DataTable TablePalletsTypes { get { return _TablePalletsTypes; } }

		#endregion Filters

		// -------------------

		public Good()
			: base()
		{
			_MainTableName = "Goods";
			_ColumnID = "PackingID";
			_ColumnName = "GoodAlias";
		}

		//��������� ������� ������ ������� � ���������� ����������, c����� �������� � ������� ����������;
		public override bool FillData()
		{
			ClearData();

			string sqlSelect = "execute up_GoodsFill @nGoodID, @nPackingID, " +
									"@cGoodsIDList, @cPackingsIDList, " +
									"@cHostsList, " + 
									"@cGoodBarCode, @cPackingBarCode, " +
									"@bGoodsActual, @bPackingsActual, " +
									"@cGoodNameContext, " +
									"@cGoodsGroupsList, @cGoodsBrandsList";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_GoodsFill paramaters

			_oCommand.Parameters.Add("@nGoodID", SqlDbType.Int);
			if (GoodID != null)
				_oCommand.Parameters["@nGoodID"].Value = GoodID;
			else
				_oCommand.Parameters["@nGoodID"].Value = DBNull.Value;
			
			_oCommand.Parameters.Add("@nPackingID", SqlDbType.Int);
			if (PackingID != null)
				_oCommand.Parameters["@nPackingID"].Value = PackingID;
			else
				_oCommand.Parameters["@nPackingID"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cGoodsIDList", SqlDbType.VarChar);
			if (_FilterGoodsIDList != null)
				_oCommand.Parameters["@cGoodsIDList"].Value = _FilterGoodsIDList;
			else
				_oCommand.Parameters["@cGoodsIDList"].Value = DBNull.Value;
			
			_oCommand.Parameters.Add("@cPackingsIDList", SqlDbType.VarChar);
			if (_FilterPackingsIDList != null)
				_oCommand.Parameters["@cPackingsIDList"].Value = _FilterPackingsIDList;
			else
				_oCommand.Parameters["@cPackingsIDList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cHostsList", SqlDbType.VarChar);
			if (_FilterHostsList != null)
				_oCommand.Parameters["@cHostsList"].Value = _FilterHostsList;
			else
				_oCommand.Parameters["@cHostsList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cGoodBarCode", SqlDbType.VarChar, 20);
			if (_FilterGoodBarCode != null)
				_oCommand.Parameters["@cGoodBarCode"].Value = _FilterGoodBarCode;
			else
				_oCommand.Parameters["@cGoodBarCode"].Value = DBNull.Value;
			_oCommand.Parameters.Add("@cPackingBarCode", SqlDbType.VarChar, 20);
			if (_FilterPackingBarCode != null)
				_oCommand.Parameters["@cPackingBarCode"].Value = _FilterPackingBarCode;
			else
				_oCommand.Parameters["@cPackingBarCode"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bGoodsActual", SqlDbType.Bit);
			if (_FilterGoodsActual != null)
				_oCommand.Parameters["@bGoodsActual"].Value = _FilterGoodsActual;
			else
				_oCommand.Parameters["@bGoodsActual"].Value = DBNull.Value;
			_oCommand.Parameters.Add("@bPackingsActual", SqlDbType.Bit);
			if (_FilterPackingsActual != null)
				_oCommand.Parameters["@bPackingsActual"].Value = _FilterPackingsActual;
			else
				_oCommand.Parameters["@bPackingsActual"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cGoodNameContext", SqlDbType.VarChar, 200);
			if (_FilterGoodNameContext != null)
				_oCommand.Parameters["@cGoodNameContext"].Value = _FilterGoodNameContext;
			else
				_oCommand.Parameters["@cGoodNameContext"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cGoodsGroupsList", SqlDbType.VarChar);
			if (_FilterGoodsGroupsList != null)
				_oCommand.Parameters["@cGoodsGroupsList"].Value = _FilterGoodsGroupsList;
			else
				_oCommand.Parameters["@cGoodsGroupsList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cGoodsBrandsList", SqlDbType.VarChar);
			if (_FilterGoodsBrandsList != null)
				_oCommand.Parameters["@cGoodsBrandsList"].Value = _FilterGoodsBrandsList;
			else
				_oCommand.Parameters["@cGoodsBrandsList"].Value = DBNull.Value;

			#endregion

			try
			{
				_MainTable = FillReadings(new SqlDataAdapter(_oCommand), _MainTable, _MainTableName);
				try
				{
					_MainTable.PrimaryKey = new DataColumn[] { _MainTable.Columns[_ColumnID] };
				}
				catch (Exception exPK)
				{
					RFMMessage.MessageBoxError("��������!\n\n��������, ���������� ������������� ����������� ������� �� �������� �������...\n\n" + exPK.Message);
				}
				_NeedRequery = false;
			}
			catch (Exception ex)
			{
				_ErrorNumber = -1;
				_ErrorStr = "������ ��� ��������� ������ ������ �������..." + Convert.ToChar(13) + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// ������� ������-�����
		/// </summary>
		public void ClearFilters()
		{
			_FilterHostsList = null;
			_FilterGoodBarCode = null;
			_FilterGoodNameContext = null;
			_FilterGoodsActual = null;
			_FilterGoodsIDList = null;
			_FilterPackingBarCode = null;
			_FilterPackingsActual = null;
			_FilterPackingsIDList = null;
			_FilterGoodsBrandsList = null;
			_FilterGoodsGroupsList = null;
		}

		/// <summary>
		/// ��������� ������� �������� ����� (TableGoodsGroups)
		/// </summary>
		public bool FillTableGoodsGroups()
		{
			string sqlSelect = "select GG.ID, GG.Name, GG.Actual, " +
					"GG.HostID, HS.Name as HostName, " +
					"GG.ERPCode " +
				"from GoodsGroups GG with (nolock) " +
				"left join Hosts HS with (nolock) on GG.HostID = HS.ID " +
				"where 1 = 1 ";
			if (_FilterHostsList != null)
				sqlSelect += " and GG.HostID in (" + RFMUtilities.NormalizeList(_FilterHostsList) + ") ";
			if (_TableGoodsGroups_FilterActual != null)
				sqlSelect = sqlSelect + " and GG.Actual = " + ((bool)_TableGoodsGroups_FilterActual ? "1" : "0");
			if (_TableGoodsGroups_FilterNameContext != null)
				sqlSelect = sqlSelect + " and charindex(upper('" + _TableGoodsGroups_FilterNameContext + "'), upper(GG.Name)) > 0";
			if (_FilterGoodsGroupsList != null)
				sqlSelect = sqlSelect + " and charindex(',' + ltrim(str(GG.ID)) + ',', ',' + '" + _FilterGoodsGroupsList + "' + ',') > 0";
			sqlSelect = sqlSelect + " order by GG.Name";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			try
			{
				_TableGoodsGroups = FillReadings(new SqlDataAdapter(_oCommand), _TableGoodsGroups, "TableGoodsGroups");

				// primarykey
				DataColumn[] pk = new DataColumn[1];
				pk[0] = _TableGoodsGroups.Columns[0];
				_TableGoodsGroups.PrimaryKey = pk;
			}
			catch (Exception ex)
			{
				_ErrorNumber = -11;
				_ErrorStr = "������ ��� ��������� ������ �������� �����..." + Convert.ToChar(13) + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}


		/// <summary>
		/// ��������� ������� �������� ������� (TableGoodsBrands)
		/// </summary>
		public bool FillTableGoodsBrands()
		{
			string sqlSelect = "select GB.ID, GB.Name, GB.Actual, " +
					"GB.HostID, HS.Name as HostName, " +
					"GB.ERPCode " +
				"from GoodsBrands GB with (nolock) " +
				"left join Hosts HS with (nolock) on GB.HostID = HS.ID " +
				"where 1 = 1 ";
			if (_FilterHostsList != null)
				sqlSelect += " and GB.HostID in (" + RFMUtilities.NormalizeList(_FilterHostsList) + ") ";
			if (_TableGoodsBrands_FilterActual != null)
				sqlSelect = sqlSelect + " where GB.Actual = " + ((bool)_TableGoodsBrands_FilterActual ? "1" : "0");
			if (_TableGoodsBrands_FilterNameContext != null)
				sqlSelect = sqlSelect + " and charindex(upper('" + _TableGoodsBrands_FilterNameContext + "'), upper(GB.Name)) > 0";
			if (_FilterGoodsBrandsList != null)
				sqlSelect = sqlSelect + " and charindex(',' + ltrim(str(GB.ID)) + ',', ',' + '" + _FilterGoodsBrandsList + "' + ',') > 0";
			sqlSelect = sqlSelect + " order by GB.Name";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			try
			{
				_TableGoodsBrands = FillReadings(new SqlDataAdapter(_oCommand), _TableGoodsBrands, "TableGoodsBrands");

				// primarykey
				DataColumn[] pk = new DataColumn[1];
				pk[0] = _TableGoodsBrands.Columns[0];
				_TableGoodsBrands.PrimaryKey = pk;
			}
			catch (Exception ex)
			{
				_ErrorNumber = -12;
				_ErrorStr = "������ ��� ��������� ������ �������..." + Convert.ToChar(13) + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}


		/// <summary>
		/// ��������� ������� ����� �������� (TablePalletsTypes)
		/// </summary>
		public bool FillTablePalletsTypes()
		{
			string sqlSelect = "select ID, Name, " +
						"PalletWidth, PalletLength, PalletHeight, PalletWeight, " +
						"Actual " +
					"from PalletsTypes " +
					"where 1 = 1 ";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			try
			{
				_TablePalletsTypes = FillReadings(new SqlDataAdapter(_oCommand), _TablePalletsTypes, "TablePalletsTypes");

				// primarykey
				DataColumn[] pk = new DataColumn[1];
				pk[0] = _TablePalletsTypes.Columns[0];
				_TablePalletsTypes.PrimaryKey = pk;
			}
			catch (Exception ex)
			{
				_ErrorNumber = -13;
				_ErrorStr = "������ ��� ��������� ������ ����� ��������..." + Convert.ToChar(13) + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// ��������� ������ ��� ������
		/// </summary>
		public bool FillDataTree(string sMode, bool bActual)
		{
			string sqlSelect = "";
			if (_FilterHostsList != null)
				sqlSelect = "select * " +
					"from .dbo.GoodsTreeHost('" + sMode + "', " +
						(bActual ? "1" : "0") + ", " +
						"'" + _FilterHostsList + "') " +
					"order by ParentID, Name";
			else
				sqlSelect = "select * " +
					"from .dbo.GoodsTree('" + sMode + "', " +
						(bActual ? "1" : "0") + ") " +
					"order by ParentID, Name";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			try
			{
				FillReadings(new SqlDataAdapter(_oCommand), null, "TableDataTree");
			}
			catch (Exception ex)
			{
				_ErrorNumber = -21;
				_ErrorStr = "������ ��� ��������� �������������� ������ (������) �������..." + Convert.ToChar(13) + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}


		#region �������� � �������

		/// <summary>
		/// ��������� ������ �������, �� ������� ������������� �������� � ������� �������
		/// </summary>
		public bool FillTablePackingsNotFixed(string sPackingsList,
									bool? bPackingsActual, bool? bGoodsActual,
									string sInputsList, string sOutputsList, 
									int? nGoodStateID, int? nOwnerID)
		{
			string sqlSelect = "execute up_PackingsNotFixedFill " +
									"@cPackingsList, " +
									"@bPackingsActual, @bGoodsActual, " +
									"@cInputsList, @cOutputsList, " +
									"@nGoodStateID, @nOwnerID";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_PackingsNotFixedFillparamaters

			_oCommand.Parameters.Add("@cPackingsList", SqlDbType.VarChar);
			if (sPackingsList != null)
				_oCommand.Parameters["@cPackingsList"].Value = sPackingsList;
			else
				_oCommand.Parameters["@cPackingsList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bPackingsActual", SqlDbType.Bit);
			if (bPackingsActual != null)
				_oCommand.Parameters["@bPackingsActual"].Value = bPackingsActual;
			else
				_oCommand.Parameters["@bPackingsActual"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bGoodsActual", SqlDbType.Bit);
			if (bGoodsActual != null)
				_oCommand.Parameters["@bGoodsActual"].Value = bGoodsActual;
			else
				_oCommand.Parameters["@bGoodsActual"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cInputsList", SqlDbType.VarChar);
			if (sInputsList != null)
				_oCommand.Parameters["@cInputsList"].Value = sInputsList;
			else
				_oCommand.Parameters["@cInputsList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cOutputsList", SqlDbType.VarChar);
			if (sOutputsList != null)
				_oCommand.Parameters["@cOutputsList"].Value = sOutputsList;
			else
				_oCommand.Parameters["@cOutputsList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@nGoodStateID", SqlDbType.Int);
			if (nGoodStateID.HasValue) 
				_oCommand.Parameters["@nGoodStateID"].Value = nGoodStateID;
			else
				_oCommand.Parameters["@nGoodStateID"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@nOwnerID", SqlDbType.Int);
			if (nOwnerID.HasValue)
				_oCommand.Parameters["@nOwnerID"].Value = nOwnerID;
			else
				_oCommand.Parameters["@nOwnerID"].Value = DBNull.Value;

			#endregion

			try
			{
				FillReadings(new SqlDataAdapter(_oCommand), null, "TablePackingsNotFixed");
			}
			catch (Exception ex)
			{
				_ErrorNumber = -1;
				_ErrorStr = "������ ��� ��������� ������ �������, �� ������� �������������� ����������� �� �������� �������..." + Convert.ToChar(13) + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// ���������� ������������� �������� � ������ �������
		/// </summary>
		public bool FixedSave(int nPackingID, int nCellID,
				int? nGoodStateID, int? nOwnerID)
		{
			string sqlSelect = "execute up_PackingsFixedSave @nPackingID, @nCellID, " +
									"@nGoodStateID, @nOwnerID, " +
									"@nError output, @cErrorStr output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_PackingsFixedSave paramaters

			_oCommand.Parameters.Add("@nCellID", SqlDbType.Int);
			_oCommand.Parameters["@nCellID"].Value = nCellID;

			_oCommand.Parameters.Add("@nPackingID", SqlDbType.Int);
			_oCommand.Parameters["@nPackingID"].Value = nPackingID;

			_oCommand.Parameters.Add("@nGoodStateID", SqlDbType.Int);
			if (nGoodStateID.HasValue)
				_oCommand.Parameters["@nGoodStateID"].Value = nGoodStateID;
			else
				_oCommand.Parameters["@nGoodStateID"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@nOwnerID", SqlDbType.Int);
			if (nOwnerID.HasValue)
				_oCommand.Parameters["@nOwnerID"].Value = nOwnerID;
			else
				_oCommand.Parameters["@nOwnerID"].Value = DBNull.Value;

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
				_ErrorNumber = -10;
				_ErrorStr = "������ ��� ���������� ������������� ����������� ������...\r\n" + ex.Message;
				//WMSMessage.MessageBoxError(_ErrorStr); // RaisError
			}
			finally
			{
				_Connect.Close();
			}
			_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
			if (_ErrorNumber != 0)
			{
				_ErrorStr = "������ ��� ���������� ������������� ����������� ������...\r\n" + _oCommand.Parameters["@cErrorStr"].Value;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		#endregion �������� � �������

	}
}
