using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;

namespace WMSBizObjects
{
	/// <summary>
	/// ����� ��� ��������� ������ ���������� � ��.
	/// </summary>
	public class SqlLink
	{
		#region ������ ����������

		protected string _ConnStr = null;
		/// <summary>
		/// ������ ���������� � ��.
		/// </summary>

		[Category("WMS")]
		[Description("���������� ������ ���������� � ��")]
		public string ConnStr
		{
			get { return _ConnStr; }
		}

		#endregion

		#region ��������� �� ������

		protected string _ErrorStr = "";
		/// <summary>
		/// ��������� � ������� ������ ���������� � ��.
		/// </summary>
		[Category("WMS")]
		[Description("���������� ��������� � ������� ������ ���������� � ��")]
		public string ErrorStr
		{
			get { return _ErrorStr; }
		}

		#endregion

		/// <summary>
		/// ����������� ������� "������ ����������".
		/// ��������� �������� ConnStr � ������ ���������� �������� �������,
		/// ���� �������� ErrorStr � ������ ������.
		/// </summary>
		[Category("WMS")]
		[Description("����������� ������� SqlLink")]
		public SqlLink()
		{
			// ��������� ������ ����������
			Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			ConnectionStringsSection csSection = config.ConnectionStrings;
			for (int i = 0; i < ConfigurationManager.ConnectionStrings.Count; i++)
			{
				ConnectionStringSettings cs = csSection.ConnectionStrings[i];
				if (cs.Name == "WMSConnectionString")
					_ConnStr = cs.ConnectionString;
			}
			// �������� ���������� ������ ������� ����������
			if (String.IsNullOrEmpty(_ConnStr))
			{
				_ConnStr = null;
				_ErrorStr = "�� ������� ���������� ������ ���������� � ����� ������������.";
				return;
			}

			// �������� ����������
			try
			{
				SqlConnection sqlConnect = new SqlConnection(_ConnStr);
				sqlConnect.Open();
				sqlConnect.Close();
			}
			catch
			{
				_ErrorStr = "C����� ���������� �������� �������� ������.";
				_ConnStr = null;
			}
			return;
		}
	}
}