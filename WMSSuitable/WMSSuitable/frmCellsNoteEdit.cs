using System;
using System.Data;
using System.Windows.Forms;

using WMSBizObjects;
using RFMBaseClasses;
using RFMPublic;

namespace WMSSuitable
{
	public partial class frmCellsNoteEdit : RFMFormChild
	{
		private Cell oCell = new Cell();
        private String sIDList = "";

		public frmCellsNoteEdit(Cell oCellNote)
		{
			InitializeComponent();

			oCell = oCellNote;
            if (oCell.ID != null)
            {
                this.Text += "������ " + oCell.BarCode;
                sIDList = oCell.ID.ToString();
            }
            else { 
                this.Text += oCell.MainTable.Rows.Count.ToString() + " �������";
                sIDList = oCell.IDList;
            }
        }

		private void frmCellsNoteEdit_Load(object sender, EventArgs e)
		{
			DataRow r = oCell.MainTable.Rows[0];
			if (r == null)
			{
				RFMMessage.MessageBoxError("�� ������� ������ ��� ������ � ����� " + r["ID"].ToString() + " � ������� �����...");
				return;
			}

            // ��������� �������� �� ������ ������
            txtNote.Text = r["Note"].ToString();
            txtNote.Focus();
            txtNote.SelectAll();

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
            oCell.SaveNote(txtNote.Text, sIDList);
            if (oCell.ErrorNumber == 0)
			{
				DialogResult = DialogResult.Yes;
				Dispose();
			}
		}
	}
}