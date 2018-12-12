using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

using RFMPublic;

/// <summary>
/// ������-������ ������������ (User)
/// </summary>
/// 
namespace WMSBizObjects
{
	public class User : BizObject
	{
		/// <summary>
		/// ID ������ ������������ (_Users.ID)
		/// </summary>
		[Description("ID ������ ������������ (_Users.ID)")]
		public int? UserID { get { return ID; } set { ID = value; } }

		/// <summary>
		/// ID ������ ���� (_Roles.ID)
		/// </summary>
		[Description("ID ������ ���� (_Roles.ID)")]
		public int? RoleID;

		protected string _IDList;
		/// <summary>
		/// ������ ID ������������� (_Users.ID)
		/// </summary>
		[Description("������ ID ������������� (_Users.ID)")]
		public string IDList { get { return _IDList; } set { _IDList = value; _NeedRequery = true; } }

		// �������

		protected bool? _FilterActual;
		/// <summary>
		/// ������-����: ������������
		/// </summary>
		[Description("������-����: A����������� (Users.Actual)")]
		public bool? FilterActual { get { return _FilterActual; } set { _FilterActual = value; _NeedRequery = true; } }

		protected string _BarCode;
		/// <summary>
		/// �����-��� ������������ (Users.BarCode), ��������
		/// </summary>
		[Description("�����-��� ������������ (Users.BarCode), ��������")]
		public string BarCode { get { return _BarCode; } set { _BarCode = value; _NeedRequery = true; } }

		protected string _FilterBrigadesList;
		/// <summary>
		/// ������-����: ������ ������ (����� �������)
		/// </summary>
		[Description("������-����: ������ ������ (����� �������)")]
		public string FilterBrigadesList { get { return _FilterBrigadesList; } set { _FilterBrigadesList = value; _NeedRequery = true; } }

		protected bool? _FilterRoleActual;
		/// <summary>
		/// ������-����: ���������� ����?
		/// </summary>
		[Description("������-����: ���������� ����?")]
		public bool? FilterRoleActual { get { return _FilterRoleActual; } set { _FilterRoleActual = value; _NeedRequery = true; } }

		protected DataTable _TableBrigades;
		/// <summary>
		/// ������� ������
		/// </summary>
		[Description("������� ������")]
		public DataTable TableBrigades { get { return _TableBrigades; } }

		protected DataTable _TableRoles;
		/// <summary>
		/// ������� ���������������� ����� _Roles
		/// </summary>
		[Description("������� ���������������� ����� _Roles")]
		public DataTable TableRoles { get { return _TableRoles; } }

		protected DataTable _TableUsersRoles;
		/// <summary>
		/// ������� ���������� �����-������������� _UsersRoles
		/// </summary>
		[Description("������� ���������� �����-������������� _UsersRoles")]
		public DataTable TableUsersRoles { get { return _TableUsersRoles; } }

		protected DataTable _TableRolesForUser;
		/// <summary>
		/// ������� ����� ��� ������ ������������ (� ����� IsUsed)
		/// </summary>
		[Description("������� ����� ��� ������ ������������ (� ����� IsUsed)")]
		public DataTable TableRolesForUser { get { return _TableRolesForUser; } }

		// ----------------------------

		public User()
			: base()
		{
			_MainTableName = "User";
			_ColumnID = "ID";
			_ColumnName = "Name";
		}


		public override bool FillData()
		{
			ClearData();

			string sqlSelect = "execute up_UsersFill @nID, @cIDList, " +
											"@cBarCode, @bActual, " +
											"@cBrigadesList";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_UsersFill parameters

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

			_oCommand.Parameters.Add("@bActual", SqlDbType.Bit);
			if (_FilterActual != null)
				_oCommand.Parameters["@bActual"].Value = _FilterActual;
			else
				_oCommand.Parameters["@bActual"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@cBrigadesList", SqlDbType.VarChar);
			if (_FilterBrigadesList != null)
				_oCommand.Parameters["@cBrigadesList"].Value = _FilterBrigadesList;
			else
				_oCommand.Parameters["@cBrigadesList"].Value = DBNull.Value;

			#endregion

			try
			{
				_MainTable = FillReadings(new SqlDataAdapter(_oCommand), _MainTable, _MainTableName);
				_NeedRequery = false;
			}
			catch (Exception ex)
			{
				_ErrorNumber = -1;
				_ErrorStr = "������ ��� ��������� ������ �������������..." + Convert.ToChar(13) + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// ������� ������-�����
		/// </summary>
		public void ClearFilters()
		{
			_FilterActual = null;
			_FilterRoleActual = null;
			UserID = null;
			RoleID = null;
			//_NeedRequery = true;
		}

		/// <summary>
		/// ���������� ������ ������������
		/// </summary>
		public bool SaveData(int nUserID)
		{
			if (_MainTable.Rows.Count == 0 || _MainTable.Rows[0] == null)
			{
				_ErrorNumber = -20;
				_ErrorStr = "�� ������ ��������� ������������...";
				RFMMessage.MessageBoxError(_ErrorStr);
				return (false);
			}

			DataRow r = _MainTable.Rows[0];

			try
			{
				_Connect.Open();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -1;
				_ErrorStr = "������ ��� ���������� � ��������...\n" + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
				return (false);
			}

			RFMUtilities.DataTableToTempTable(TableRolesForUser, "#RolesForUser", _Connect);

			string _sqlCommand = "execute up_UsersSave @nUserID output, " +
					"@cUserName, " +
					"@nBrigadeID, " +
					"@cPassword, " +
					"@cAlias, " +
					"@cLocPath, @cNetPath, " +
					"@bIsAdmin, " +
					"@bActual, " +
					"@nHostID, " + 
					"@nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(_sqlCommand, _Connect);

			#region up_UsersSave parameters

			SqlParameter _oParameter = _oCommand.Parameters.Add("@nUserID", SqlDbType.Int);
			_oParameter.Value = nUserID;
			_oParameter.Direction = ParameterDirection.InputOutput;

			_oParameter = _oCommand.Parameters.Add("@cUserName", SqlDbType.VarChar);
			_oParameter.Value = r["Name"].ToString();

			_oParameter = _oCommand.Parameters.Add("@nBrigadeID", SqlDbType.Int);
			if (r["BrigadeID"] != null && !Convert.IsDBNull(r["BrigadeID"]))
				_oParameter.Value = Convert.ToInt32(r["BrigadeID"]);
			else
				_oParameter.Value = DBNull.Value;

			_oParameter = _oCommand.Parameters.Add("@cPassword", SqlDbType.VarChar);
			_oParameter.Value = r["Password"].ToString();

			_oParameter = _oCommand.Parameters.Add("@cAlias", SqlDbType.VarChar);
			if (r["Alias"] != null)
				_oParameter.Value = r["Alias"].ToString();
			else
				_oParameter.Value = DBNull.Value;

			_oParameter = _oCommand.Parameters.Add("@cLocPath", SqlDbType.VarChar);
			_oParameter.Value = r["LocPath"].ToString();

			_oParameter = _oCommand.Parameters.Add("@cNetPath", SqlDbType.VarChar);
			_oParameter.Value = r["NetPath"].ToString();

			_oParameter = _oCommand.Parameters.Add("@bIsAdmin", SqlDbType.Bit);
			_oParameter.Value = Convert.ToBoolean(r["IsAdmin"]);

			_oParameter = _oCommand.Parameters.Add("@bActual", SqlDbType.Bit);
			_oParameter.Value = Convert.ToBoolean(r["Actual"]);

			_oParameter = _oCommand.Parameters.Add("@nHostID", SqlDbType.Int);
			if (r["HostID"] != null && !Convert.IsDBNull(r["HostID"]))
				_oParameter.Value = Convert.ToInt32(r["HostID"]);
			else
				_oParameter.Value = DBNull.Value;

			_oCommand.Parameters.Add("@nError", SqlDbType.Int);
			_oCommand.Parameters["@nError"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@nError"].Value = 0;

			_oCommand.Parameters.Add("@cErrorText", SqlDbType.VarChar, 200);
			_oCommand.Parameters["@cErrorText"].Direction = ParameterDirection.InputOutput;
			_oCommand.Parameters["@cErrorText"].Value = "";

			#endregion

			try
			{
				_oCommand.ExecuteScalar();
			}
			catch (Exception ex)
			{
				_ErrorNumber = -10;
				_ErrorStr = "������ ��� ���������� ������ ������������...\r\n" + ex.Message;
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
					_ErrorStr = "������ ��� ���������� ������ ������������...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
				// ��� �������� ������ ������������ - ������� ��� ���
				if (nUserID == 0 && _oCommand.Parameters["@nUserID"].Value != DBNull.Value)
				{
					_ID = (int)_oCommand.Parameters["@nUserID"].Value;
				}
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// ���������� ���� ������������
		/// </summary>
		public bool SavePhoto(int nUserID, byte[] bsPhoto)
		{
			string _sqlCommand = "execute up_UsersPhotoSave @nUserID, " +
					"@bPhoto, " +
					"@nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(_sqlCommand, _Connect);

			#region up_UsersPhotoSave parameters

			SqlParameter _oParameter = _oCommand.Parameters.Add("@nUserID", SqlDbType.Int);
			_oParameter.Value = nUserID;

			_oParameter = _oCommand.Parameters.Add("@bPhoto", SqlDbType.Image);
			if (bsPhoto != null)
			{
				_oParameter.Size = bsPhoto.Length;
				_oParameter.Value = bsPhoto;
			}
			else
			{
				_oParameter.Value = DBNull.Value;
			}

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
				_ErrorNumber = -12;
				_ErrorStr = "������ ��� ���������� ���� ������������...\r\n" + ex.Message;
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
					_ErrorStr = "������ ��� ���������� ���� ������������...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// �������� ������������
		/// </summary>
		public bool DeleteData(int nUserID)
		{
			String _sqlCommand = "execute up_UsersDelete @nUserID, " +
					"@nError output, @cErrorText output";
			SqlCommand _oCommand = new SqlCommand(_sqlCommand, _Connect);

			#region up_UsersDelete parameters

			SqlParameter _oParameter = _oCommand.Parameters.Add("@nUserID", SqlDbType.Int);
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
				_ErrorNumber = -10;
				_ErrorStr = "������ ��� �������� ������ � ������������...\r\n" + ex.Message;
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
					_ErrorStr = "������ ��� �������� ������ � ������������...\r\n" + _oCommand.Parameters["@cErrorText"].Value;
					RFMMessage.MessageBoxError(_ErrorStr);
				}
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// ��������� ������� ������ (TableBrigades)
		/// </summary>
		public bool FillTableBrigades()
		{
			string sqlSelect = "select ID, Name from Brigades where 1 = 1 ";
			if (_FilterBrigadesList != null)
				sqlSelect = sqlSelect + " and charindex(',' + ltrim(str(ID)) + ',', ',' + '" + _FilterBrigadesList + "' + ',') > 0";
			sqlSelect = sqlSelect + " order by Name";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			try
			{
				_TableBrigades = FillReadings(new SqlDataAdapter(_oCommand), _TableBrigades, "TableBrigades");

				// primarykey
				DataColumn[] pk = new DataColumn[1];
				pk[0] = _TableBrigades.Columns[0];
				_TableBrigades.PrimaryKey = pk;
			}
			catch (Exception ex)
			{
				_ErrorNumber = -11;
				_ErrorStr = "������ ��� ��������� ������ ������..." + Convert.ToChar(13) + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// ��������� ������� ����� (TableRoles)
		/// </summary>
		public bool FillTableRoles()
		{
			string sqlSelect = "execute up_RolesFill @nID, @bActual";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_RolesFill parameters

			_oCommand.Parameters.Add("@nID", SqlDbType.Int);
			if (ID != null)
				_oCommand.Parameters["@nID"].Value = ID;
			else
				_oCommand.Parameters["@nID"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@bActual", SqlDbType.Bit);
			if (_FilterRoleActual != null)
				_oCommand.Parameters["@bActual"].Value = _FilterRoleActual;
			else
				_oCommand.Parameters["@bActual"].Value = DBNull.Value;

			#endregion

			try
			{
				_TableRoles = FillReadings(new SqlDataAdapter(_oCommand), _TableRoles, "TableRoles");

				// primarykey
				DataColumn[] pk = new DataColumn[1];
				pk[0] = _TableRoles.Columns[0];
				_TableRoles.PrimaryKey = pk;
			}
			catch (Exception ex)
			{
				_ErrorNumber = -11;
				_ErrorStr = "������ ��� ��������� ������ ���������������� �����..." + Convert.ToChar(13) + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// ��������� ������� ���������� �����-������������� (TableUsersRoles), ������ ���������� 
		/// </summary>
		public bool FillTableUsersRoles()
		{
			string sqlSelect = "execute up_UsersRolesFill @nUserID, @nRoleID";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_UsersRolesFill parameters

			_oCommand.Parameters.Add("@nUserID", SqlDbType.Int);
			if (UserID != null)
				_oCommand.Parameters["@nUserID"].Value = UserID;
			else
				_oCommand.Parameters["@nUserID"].Value = DBNull.Value;

			_oCommand.Parameters.Add("@nRoleID", SqlDbType.Int);
			if (RoleID != null)
				_oCommand.Parameters["@nRoleID"].Value = RoleID;
			else
				_oCommand.Parameters["@nRoleID"].Value = DBNull.Value;

			#endregion

			try
			{
				_TableRoles = FillReadings(new SqlDataAdapter(_oCommand), _TableRoles, "TableUsersRoles");
			}
			catch (Exception ex)
			{
				_ErrorNumber = -12;
				_ErrorStr = "������ ��� ��������� ������ ���������� �����/�������������..." + Convert.ToChar(13) + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// ������� ������� ���������� ����� (TableUsersRoles)
		/// </summary>
		public void ClearTableUsersRoles()
		{
			if (_DS.Tables["TableUsersRoles"] != null)
				_DS.Tables.Remove("TableUsersRoles");
			_TableUsersRoles = null;
		}

		/// <summary>
		/// ��������� ������� ����� ��� ������ ������������ (TableRolesForUser), ��� ���������� ����
		/// </summary>
		public bool FillTableRolesForUser(int nUserID)
		{
			string sqlSelect = "execute up_RolesForUserFill @nUserID";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			#region up_RolesForUserFill parameters

			_oCommand.Parameters.Add("@nUserID", SqlDbType.Int);
			_oCommand.Parameters["@nUserID"].Value = UserID;

			#endregion

			try
			{
				_TableRolesForUser = FillReadings(new SqlDataAdapter(_oCommand), _TableRolesForUser, "TableRolesForUser");
			}
			catch (Exception ex)
			{
				_ErrorNumber = -13;
				_ErrorStr = "������ ��� ��������� ������ ����� ��� ������������..." + Convert.ToChar(13) + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}

		/// <summary>
		/// ��������� ������ ��� ������ (�� ��������)
		/// </summary>
		public bool FillDataTree(bool bActual)
		{
			if (_DS.Tables["TableDataTree"] != null)
				_DS.Tables.Remove("TableDataTree");

			string sqlSelect = "select * from .dbo.UsersTree(" + ((bActual) ? "1" : "0") + ") " +
				"order by ParentID, Name";
			SqlCommand _oCommand = new SqlCommand(sqlSelect, _Connect);

			try
			{
				FillReadings(new SqlDataAdapter(_oCommand), null, "TableDataTree");
			}
			catch (Exception ex)
			{
				_ErrorNumber = -21;
				_ErrorStr = "������ ��� ��������� �������������� ������ (������) �������������..." + Convert.ToChar(13) + ex.Message;
				RFMMessage.MessageBoxError(_ErrorStr);
			}
			return (_ErrorNumber == 0);
		}
	}
}
