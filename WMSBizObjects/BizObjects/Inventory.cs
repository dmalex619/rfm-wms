using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

using RFMPublic;

/// <summary>
/// ������-������ ������� (��������������) (Inventory)
/// </summary>
namespace WMSBizObjects
{
	public class Inventory : BizObject
	{
		protected string _IDList;
		/// <summary>
		/// ������ ID ������� (Inventories.ID)
		/// </summary>
		[Description("������ ID ������� (Inventories.ID)")]
		public string IDList { get { return _IDList; } set { _IDList = value; _NeedRequery = true; } }

		protected string _BarCode;
		/// <summary>
		/// �����-��� ���������-������� (Inventories.BarCode), ��������
		/// </summary>
		[Description("�����-��� ���������-������� (Inventories.BarCode), ��������")]
		public string BarCode { get { return _BarCode; } set { _BarCode = value; _NeedRequery = true; } }

		// �������
		#region Filters

		protected DateTime? _FilterDateBeg;
		/// <summary>
		/// ������-����: ��������� ���� ������� (Inventories.DateInventory)
		/// </summary>
		[Description("������-����: ��������� ���� ������� (Inventories.DateInventory)")]
		public DateTime? FilterDateBeg { get { return _FilterDateBeg; } set { _FilterDateBeg = value; } }

		protected DateTime? _FilterDateEnd;
		/// <summary>
		/// ������-����: �������� ���� �������
		/// </summary>
		[Description("������-����: �������� ���� ������� (Inventories.DateInventory)")]
		public DateTime? FilterDateEnd { get { return _FilterDateEnd; } set { _FilterDateEnd = value; } }

		protected bool? _FilterConfirmed;
		/// <summary>
		/// ������-����: ������������ (Inventories.DateConfirm)?
		/// </summary>
		[Description("������-����: ������������ (Inventories.DateConfirm)?")]
		public bool? FilterConfirmed { get { return _FilterConfirmed; } set { _FilterConfirmed = value; } }

		protected DateTime? _FilterDateConfirmBeg;
		/// <summary>
		/// ������-����: ���� ������������� - ��������� ���� ������� (Inventories.DateConfirm)
		/// </summary>
		[Description("������-����: ���� ������������� - ��������� ���� ������� (Inventories.DateConfirm)")]
		public DateTime? FilterDateConfirmBeg { get { return _FilterDateConfirmBeg; } set { _FilterDateConfirmBeg = value; } }

		protected DateTime? _FilterDateConfirmEnd;
		/// <summary>
		/// ������-����: ���� ������������� - �������� ���� ������� (Inventories.DateConfirm)
		/// </summary>
		[Description("������-����: ���� ������������� - �������� ���� ������� (Inventories.DateConfirm)")]
		public DateTime? FilterDateConfirmEnd { get { return _FilterDateConfirmEnd; } set { _FilterDateConfirmEnd = value; } }

		protected bool? _FilterStarted;
		/// <summary>
		/// ������-����: ��������� ������� ������ (Inventories.DateStart)?
		/// </summary>
		[Description("������-����: ��������� ������� ������ (Inventories.DateStart)?")]
		public bool? FilterStarted { get { return _FilterStarted; } set { _FilterStarted = value; } }

		protected string _FilterCellsList;
		/// <summary>
		/// ������-����: ������ ID ����� (InventoriesCells.CellID -> Cells.ID), ����� �������
		/// </summary>
		[Description("������-����: ������ ID ����� (InventoriesCells.CellID -> Cells.ID), ����� �������")]
		public string FilterCellsList { get { return _FilterCellsList; } set { _FilterCellsList = value; _NeedRequery = true; } }

		protected string _FilterPackingsList;
		/// <summary>
		/// ������-����: ������ ID �������-�������� (InventoriesCells.PackingID -> Packings.ID), ����� �������
		/// </summary>
		[Description("������-����: ������ ID �������-�������� (InventoriesCells.PackingID -> Packings.ID), ����� �������")]
		public string FilterPackingsList { get { return _FilterPackingsList; } set { _FilterPackingsList = value; _NeedRequery = true; } }

		protected string _FilterUsersList;
		/// <summary>
		/// ������-����: ������ ID �������������, ����������� ������� (InventoriesCells.UserID -> Users.ID), ����� �������
		/// </summary>
		[Description("������-����: ������ ID �������������, ����������� ������� (InventoriesCell.UserID -> Users.ID), ����� �������")]
		public string FilterUsersList { get { return _FilterUsersList; } set { _FilterUsersList = value; _NeedRequery = true; } }

		// -- ��� ����� � �������

		protected bool? _FilterCellsStarted;
		/// <summary>
		/// ������-����: ��������� ������ ������ (InventoriesCells.Success is not Null)?
		/// </summary>
		[Description("������-����: ��������� ������ ������ (InventoriesCells.Success is not Null)?")]
		public bool? FilterCellsStarted { get { return _FilterCellsStarted; } set { _FilterCellsStarted = value; } }

		protected bool? _FilterSuccess;
		/// <summary>
		/// ������-����: ������ ���������� ������� (InventoriesCells.Success)?
		/// </summary>
		[Description("������-����: ������ ���������� ������� (InventoriesCells.Success)?")]
		public bool? FilterSuccess { get { return _FilterSuccess; } set { _FilterSuccess = value; } }

		protected int? _FilterCellContentSnapshotID;
		/// <summary>
		/// ������-����: ��� ����� �������� (InventoriesCells.CellContentSnapshotID)?
		/// </summary>
		[Description("������-����: ��� ����� �������� (InventoriesCells.CellContentSnapshotID)?")]
		public int? FilterCellContentSnapshotID { get { return _FilterCellContentSnapshotID; } set { _FilterCellContentSnapshotID = value; } }

		#endregion Filters

		// �������
		#region Tables

		protected DataTable _TableInventoriesCells;
		/// <summary>
		/// ������ ����� � ������� (TableInventoriesCells)
		/// </summary>
		[Description("������ ����� � ������� (TableInventoriesCells)")]
		public DataTable TableInventoriesCells { get { return _TableInventoriesCells; } }

		/*
		protected DataTable _TableInventoriesErrors;
		/// <summary>
		/// ������ ������� (TableInventoriesErrors)
		/// </summary>
		[Description("������ ������� (TableInventoriesErrors)")]
		public DataTable TableInventoriesErrors { get { return _TableInventoriesErrors; } }
		*/ 

		#endregion Tables

		// -------------------------------------

		public Inventory()
			: base()
		{
			_MainTableName = "Inventories";
		}

		#region FillData

		/// <summary>
		/// ��������� ������ ������� (MainTable)
		/// </summary>
		public override bool FillData()
		{
			ClearData();

			string sqlSelect = "execute up_InventoriesFill " +
				"@nID, @cIDList, " +
				"@cBarCode, " +
				"@dDateBeg, @dDateEnd, " +
				"@bConfirmed, " +
				"@dDateConfirmBeg, @dDateConfirmEnd, " +
				"@bStarted, " +
				"@cCellsList, " + 
				"@cPackingsList, " +
				"@nCellContentSnapshotID";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_InventoriesFill parameters

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

			_oCommand.Parameters.Add("@cBarCode", SqlDbType.VarChar);
			if (BarCode != null)
				_oCommand.Parameters["@cBarCode"].Value = BarCode;
			else
				_oCommand.Parameters["@cBarCode"].Value = DBNull.Value;

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

			_oCommand.Parameters.Add("@dDateConfirmBeg", SqlDbType.SmallDateTime);
			if (_FilterDateConfirmBeg != null)
				_oCommand.Parameters["@dDateConfirmBeg"].Value = _FilterDateConfirmBeg;
			else
				_oCommand.Parameters["@dDateConfirmBeg"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@dDateConfirmEnd", SqlDbType.SmallDateTime);
			if (_FilterDateConfirmEnd != null)
				_oCommand.Parameters["@dDateConfirmEnd"].Value = _FilterDateConfirmEnd;
			else
				_oCommand.Parameters["@dDateConfirmEnd"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bStarted", SqlDbType.Bit);
			if (_FilterStarted != null)
				_oCommand.Parameters["@bStarted"].Value = _FilterStarted;
			else
				_oCommand.Parameters["@bStarted"].Value = DBNull.Value;

			#region up_InventoriesFill InventoriesCells-paramaters

			//���� ��� ������ ����� ������ ����� (InventoriesCells)

			_oCommand.Parameters.Add("@cCellsList", SqlDbType.VarChar);
			if (_FilterCellsList != null)
				_oCommand.Parameters["@cCellsList"].Value = _FilterCellsList;
			else
				_oCommand.Parameters["@cCellsList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cPackingsList", SqlDbType.VarChar);
			if (_FilterPackingsList != null)
				_oCommand.Parameters["@cPackingsList"].Value = _FilterPackingsList;
			else
				_oCommand.Parameters["@cPackingsList"].Value = DBNull.Value;

			#endregion

			_oCommand.Parameters.Add("@nCellContentSnapshotID", SqlDbType.Int);
			if (_FilterCellContentSnapshotID != null)
				_oCommand.Parameters["@nCellContentSnapshotID"].Value = _FilterCellContentSnapshotID;
			else
				_oCommand.Parameters["@nCellContentSnapshotID"].Value = DBNull.Value;

			#endregion

			try
			{
				_MainTable = FillReadings(new SqlDataAdapter(_oCommand), _MainTable, _MainTableName);
			}
			catch (Exception ex)
			{
				_ErrorNumber = -1;
				_ErrorStr = "������ ��� ��������� ������ �������..." + Convert.ToChar(13) + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// ������� ������-�����
		/// </summary>
		public void ClearFilters()
		{
			_BarCode = null;
			_FilterDateBeg = null;
			_FilterDateEnd = null;
			_FilterConfirmed = null;
			_FilterDateConfirmBeg = null;
			_FilterDateConfirmEnd = null;
			_FilterStarted = null;
			_FilterCellsList = null;
			_FilterPackingsList = null;
			_FilterCellsStarted = null;
			_FilterSuccess = null;
			_FilterCellContentSnapshotID = null; 
			//_NeedRequery = false;
		}

		#endregion FillData

		#region Table InventoriesCells

		/// <summary>
		/// ���������� ������� ����� � ������� (TableInventoriesCells)
		/// </summary>
		public bool FillTableInventoriesCells(int? nInventoryID)
		{
			if (!nInventoryID.HasValue & !_ID.HasValue)
			{
				_ErrorNumber = -4;
				_ErrorStr = "������������ �����:\r\n������ ��� ��������� ������ ����� � �������...";
				RFMMessage.MessageBoxError(_ErrorStr);
				return (false);
			}
			if (!nInventoryID.HasValue)
				nInventoryID = _ID;

			string sqlSelect = "execute up_InventoriesCellsFill @nInventoryID, " +
									"@bCellStarted, @bSuccess, " +
									"@cCellsList, " +
									"@cUsersList, " +
									"@nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_InventoriesCellsFill parameters

			_oCommand.Parameters.Add("@nInventoryID", SqlDbType.Int);
			_oCommand.Parameters["@nInventoryID"].Value = nInventoryID;

			_oCommand.Parameters.Add("@bCellStarted", SqlDbType.Bit);
			if (_FilterCellsStarted != null)
				_oCommand.Parameters["@bCellStarted"].Value = _FilterCellsStarted;
			else
				_oCommand.Parameters["@bCellStarted"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bSuccess", SqlDbType.Bit);
			if (_FilterSuccess != null)
				_oCommand.Parameters["@bSuccess"].Value = _FilterSuccess;
			else
				_oCommand.Parameters["@bSuccess"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cCellsList", SqlDbType.VarChar);
			if (_FilterCellsList != null)
				_oCommand.Parameters["@cCellsList"].Value = _FilterCellsList;
			else
				_oCommand.Parameters["@cCellsList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cUsersList", SqlDbType.VarChar);
			if (_FilterUsersList != null)
				_oCommand.Parameters["@cUsersList"].Value = _FilterUsersList;
			else
				_oCommand.Parameters["@cUsersList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@nError", SqlDbType.Int);
			_oCommand.Parameters["@nError"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@nError"].Value = 0;

			_oCommand.Parameters.Add("@cErrorText", SqlDbType.VarChar, 200);
			_oCommand.Parameters["@cErrorText"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@cErrorText"].Value = "";

			#endregion

			try
			{
				_TableInventoriesCells = FillReadings(new SqlDataAdapter(_oCommand), _TableInventoriesCells, "TableInventoriesCells");

				// primarykey
				DataColumn[] pk = new DataColumn[1];
				pk[0] = _TableInventoriesCells.Columns["ID"];
				_TableInventoriesCells.PrimaryKey = pk;
			}
			catch (Exception ex)
			{
				_ErrorNumber = -5;
				_ErrorStr = "������ ��� ��������� ������ ����� � �������...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			if (_ErrorNumber == 0)
			{
				_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
				if (_ErrorNumber != 0)
				{
					_ErrorStr = "������ ��� ��������� ������ ����� � �������...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		#endregion Table InventoriesCells

		#region Tables

		/*
		#region Table InventoriesErrors

		/// <summary>
		/// ���������� ������� ������ ������� (TableInventoriesErrors)
		/// </summary>
		public bool FillTableInventoriesErrors()
		{
			string sqlSelect = "select ID, Name " +
									"from InventoriesErrors with (nolock) " +
									"order by ID";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			try
			{
				_TableInventoriesErrors = FillReadings(new SqlDataAdapter(_oCommand), _TableInventoriesErrors, "TableInventoriesErrors");

				// primarykey
				DataColumn[] pk = new DataColumn[1];
				pk[0] = _TableInventoriesErrors.Columns["ID"];
				_TableInventoriesErrors.PrimaryKey = pk;
			}
			catch (Exception ex)
			{
				_ErrorNumber = -7;
				_ErrorStr = "������ ��� ��������� ������ ������ �������...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		#endregion Table InventoriesErrors
		*/
		
		#endregion Tables


		#region Save

		/// <summary>
		/// ���������� ������� �� ������� ����� 
		/// </summary>
		public bool SaveData(int nInventoryID, DataTable tTable)
		{
			if (_MainTable.Rows.Count == 0 || _MainTable.Rows[0] == null)
			{
				_ErrorNumber = -10;
				_ErrorStr = "��� ������ ��� ���������� �������...";
				RFMMessage.MessageBoxError(_ErrorStr);
				return (false);
			}

			// � �������������� ��������� ������� �����
			// ��������� ��������� � ��� �����, ������ �����
			/*
			if (tTable.Rows.Count == 0)
			{
				_ErrorNumber = -11;
				_ErrorStr = "�� ������� ������ ��� ���������� �������...";
				RFMMessage.MessageBoxError(_ErrorStr);
				return (false);
			}
			*/

			// ��� �����
			DataRow r = _MainTable.Rows[0];

			string _sqlCommand = "execute up_InventoriesSave @nInventoryID output, " +
									"@dDateInventory, @cNote, " +
									"@nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(_sqlCommand, _Connect);

			#region up_InventoriesSave parameters

			SqlParameter _oParameter = _oCommand.Parameters.Add("@nInventoryID", SqlDbType.Int);
			_oParameter.Value = nInventoryID;
			_oParameter.Direction = ParameterDirection.InputOutput;

			_oParameter = _oCommand.Parameters.Add("@dDateInventory", SqlDbType.DateTime);
			_oParameter.Value = DateTime.Parse(r["DateInventory"].ToString());

			_oParameter = _oCommand.Parameters.Add("@cNote", SqlDbType.VarChar);
			_oParameter.Value = r["Note"].ToString();

			_oParameter = _oCommand.Parameters.Add("@nError", SqlDbType.Int);
			_oParameter.Direction = ParameterDirection.InputOutput;
			_oParameter.Value = 0;

			_oParameter = _oCommand.Parameters.Add("@cErrorText", SqlDbType.VarChar, 200);
			_oParameter.Direction = ParameterDirection.InputOutput;
			_oParameter.Value = "";

			#endregion

			try
			{
				_Connect.Open();
				RFMUtilities.DataTableToTempTable(tTable, "#InventoriesCells", _Connect);
				_oCommand.ExecuteScalar();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -12;
				_ErrorStr = "������ ��� ���������� �������...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			if (_ErrorNumber == 0)
			{
				_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
				if (_ErrorNumber != 0)
				{
					_ErrorStr = "������ ��� ���������� �������...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
				// ��� �������� ����� ������� - ������� �� ���
				if (nInventoryID == 0 && _oCommand.Parameters["@nInventoryID"].Value != DBNull.Value)
				{
					_ID = (int)_oCommand.Parameters["@nInventoryID"].Value;
				}
			}
			return (_ErrorNumber == 0);
		}

		#endregion Save

		#region Confirm

		/// <summary>
		/// ������������� ���� ������� ������� - ��� ���������� ��������� (��� �������� � ������ ���������� �������)
		/// </summary>
		public bool ConfirmEasy(int nInventoryID, int @nUserID)
		{
			string _sqlCommand = "execute up_InventoriesConfirmEasy @nInventoryID, " +
									"@nUserID, " +
									"@nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(_sqlCommand, _Connect);
			_oCommand.CommandTimeout = 0;

			#region  up_InventoryConfirmEasy parameters

			SqlParameter _oParameter = _oCommand.Parameters.Add("@nInventoryID", SqlDbType.Int);
			_oParameter.Value = nInventoryID;

			_oParameter = _oCommand.Parameters.Add("@nUserID", SqlDbType.Int);
			_oParameter.Value = nUserID;

			_oParameter = _oCommand.Parameters.Add("@nError", SqlDbType.Int);
			_oParameter.Direction = ParameterDirection.InputOutput;
			_oParameter.Value = 0;

			_oParameter = _oCommand.Parameters.Add("@cErrorText", SqlDbType.VarChar, 200);
			_oParameter.Direction = ParameterDirection.InputOutput;
			_oParameter.Value = "";

			#endregion

			try
			{
				_Connect.Open();
				_oCommand.ExecuteScalar();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -15;
				_ErrorStr = "������ ��� ������������� �������...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			if (_ErrorNumber == 0)
			{
				_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
				if (_ErrorNumber != 0)
				{
					_ErrorStr = "������ ��� ������������� �������...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		#endregion Confirm

		#region Delete

		/// <summary>
		/// �������� ������� �������
		/// </summary>
		public bool DeleteData(int nInventoryID)
		{
			string _sqlCommand = "execute up_InventoriesDelete @nInventoryID, " +
									"@nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(_sqlCommand, _Connect);

			#region up_InventoriesDelete parameters

			SqlParameter _oParameter = _oCommand.Parameters.Add("@nInventoryID", SqlDbType.Int);
			_oParameter.Value = nInventoryID;

			_oParameter = _oCommand.Parameters.Add("@nError", SqlDbType.Int);
			_oParameter.Direction = ParameterDirection.InputOutput;
			_oParameter.Value = 0;

			_oParameter = _oCommand.Parameters.Add("@cErrorText", SqlDbType.VarChar, 200);
			_oParameter.Direction = ParameterDirection.InputOutput;
			_oParameter.Value = "";

			#endregion

			try
			{
				_Connect.Open();
				_oCommand.ExecuteScalar();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -20;
				_ErrorStr = "������ ��� ������� �������� �������...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			if (_ErrorNumber == 0)
			{
				_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
				if (_ErrorNumber != 0)
				{
					_ErrorStr = "������ ��� �������� �������...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// �������� ����� ������ � ������ ������� 
		/// </summary>
		public bool DeleteData(int nInventoryID, int nCellID)
		{
			string _sqlCommand = "execute up_InventoriesCellsDelete @nInventoryID, @nCellID, " +
									"@nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(_sqlCommand, _Connect);

			#region up_InventoriesDelete parameters

			SqlParameter _oParameter = _oCommand.Parameters.Add("@nInventoryID", SqlDbType.Int);
			_oParameter.Value = nInventoryID;

			_oParameter = _oCommand.Parameters.Add("@nCellID", SqlDbType.Int);
			_oParameter.Value = nCellID;

			_oParameter = _oCommand.Parameters.Add("@nError", SqlDbType.Int);
			_oParameter.Direction = ParameterDirection.InputOutput;
			_oParameter.Value = 0;

			_oParameter = _oCommand.Parameters.Add("@cErrorText", SqlDbType.VarChar, 200);
			_oParameter.Direction = ParameterDirection.InputOutput;
			_oParameter.Value = "";

			#endregion

			try
			{
				_Connect.Open();
				_oCommand.ExecuteScalar();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -21;
				_ErrorStr = "������ ��� ������� �������� ������ �� ������ �������...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			finally
			{
				_Connect.Close();
			}
			if (_ErrorNumber == 0)
			{
				_ErrorNumber = (int)_oCommand.Parameters["@nError"].Value;
				if (_ErrorNumber != 0)
				{
					_ErrorStr = "������ ��� �������� ������ �� ������ �������...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		#endregion Delete

		#region TotalReport

		/// <summary>
		/// ����� ������ ������� � ���������� �������x (TableInventoriesTotalReport)
		/// </summary>
		public bool FillTableInventoriesTotalReport(string sIDList, string sPackingsList, bool bDiffOnly)
		{
			string sqlSelect = "execute up_InventoriesTotalReport " +
									"@cIDList, @cPackingsList, @bDiffOnly";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_InventoriesTotalReport parameters

			_oCommand.Parameters.Add("@cIDList", SqlDbType.VarChar);
			if (sIDList != null)
				_oCommand.Parameters["@cIDList"].Value = sIDList;
			else
				_oCommand.Parameters["@cIDList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cPackingsList", SqlDbType.VarChar);
			if (sPackingsList != null && sPackingsList.Length > 0)
				_oCommand.Parameters["@cPackingsList"].Value = sPackingsList;
			else
				_oCommand.Parameters["@cPackingsList"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bDiffOnly", SqlDbType.Bit);
			_oCommand.Parameters["@bDiffOnly"].Value = bDiffOnly;

			#endregion

			try
			{
				FillReadings(new SqlDataAdapter(_oCommand), null, "TableInventoriesTotalReport");
			}
			catch (Exception ex)
			{
				_ErrorNumber = -25;
				_ErrorStr = "������ ��� ��������� ������ ������� � ��������...\r\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		#endregion TotalReport

	}
}
