using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

using WMSBizObjects;
using RFMBaseClasses;
using RFMPublic;

namespace WMSSuitable
{
	public partial class frmCellsDelete : RFMFormChild
	{
		private Cell oCell = new Cell();
		
		public frmCellsDelete(Cell oCellDelete)
		{
			InitializeComponent();

			oCell = oCellDelete;
		}
		
		private void frmCellsDelete_Load(object sender, EventArgs e)
		{
			// ���������� ����� �������
			if (oCell.MainTable.Rows.Count > 1)
			{
				txtBarCode.Text = "";
				txtCellID.Text  = "";
				txtAddress.Text = "������� �����: " + oCell.MainTable.Rows.Count.ToString();
			}
			else
			{
				DataRow r = oCell.MainTable.Rows[0];
				txtBarCode.Text = r["BarCode"].ToString();
				txtCellID.Text  = r["ID"].ToString();
				txtAddress.Text = r["Address"].ToString();
			}
		}

		private void btnHelp_Click(object sender, EventArgs e)
		{
			RFMHelpUtilities.HelpShow(this, hpHelp);
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.No;
			this.Dispose();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			// ���������� ������ oCell

			int nCnt = 0;
			bool bDeleteHole = chkDeleteHole.Checked;

			// �������� ���������� ������� ��������� ������� ��������
			foreach (DataRow r in oCell.MainTable.Rows)
			{
				if (Convert.ToInt32(r["ID"]) < 0)
				{
					r["ID"] = -Convert.ToInt32(r["ID"]);
				}
			}
			oCell.ClearError();

			if (RFMMessage.MessageBoxYesNo("����������� ������� �������� " + RFMPublic.RFMUtilities.Declen(oCell.MainTable.Rows.Count, "������", "�����", "�����") + ".\n" +
					"����������?") == DialogResult.Yes)
			{
				nCnt = oCell.Delete("TEST", bDeleteHole);
				if (nCnt > 0)
				{
					if (RFMMessage.MessageBoxYesNo("����� ������� " + RFMUtilities.Declen(nCnt, "������", "������", "�����") + ".\n" +
						"��������� ��������?") == DialogResult.Yes)
					{
						nCnt = oCell.Delete("DELETE", bDeleteHole);
						if (nCnt > 0)
							RFMMessage.MessageBoxInfo("�������: " + RFMUtilities.Declen(nCnt, "������", "������", "�����") + ".");
						else
							RFMMessage.MessageBoxInfo("������ �� ���� �������...");
					}
				}
				else
				{
					RFMMessage.MessageBoxError("������ �� ����� ���� �������...");
				}

				if (oCell.ErrorNumber == 0 && nCnt > 0)
				{
					DialogResult = DialogResult.Yes;
					Dispose();
				}
			}
		}

	}
}