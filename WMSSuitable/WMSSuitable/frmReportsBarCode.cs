using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;

using WMSBizObjects;
using RFMBaseClasses;
using RFMPublic;

namespace WMSSuitable
{
	public partial class frmReportsBarCode : RFMFormChild
	{
		private Setting set = new Setting();
		
		public frmReportsBarCode()
		{
			InitializeComponent();
		}
		
		private void frmReportsBarCode_Load(object sender, EventArgs e)
		{

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

		private void btnGo_Click(object sender, EventArgs e)
		{
            rtxtInfo.Text = "";
            if (set.DS.Tables["_TempTable"] != null)
            {
                set.DS.Tables.Remove("_TempTable"); 
            }

			SqlConnection sqlConnect = ((RFMFormMain)(Application.OpenForms[0])).MainConnect;
			try
			{
				sqlConnect.Open();
				string sqlSelect = "exec mob_GetBarCodeInfoFull '" + txtBarCode.Text + "'";
				SqlCommand sqlCommand = new SqlCommand(sqlSelect, sqlConnect);

				SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
				adapter.Fill(set.DS, "_TempTable");

                if (set.DS.Tables["_TempTable"].Rows.Count > 0)
                {
                    rtxtInfo.Text = set.DS.Tables["_TempTable"].Rows[0][1].ToString();
                }
                else
                {
                    rtxtInfo.Text = "Нет данных...";
                }
			}
			catch (Exception ex)
			{
				RFMMessage.MessageBoxError("Ошибка при получении данных о штрих-коде:\n" + ex.Message);
			}
			finally
			{
				sqlConnect.Close();
			}
		}

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBarCode.Text = "";
            rtxtInfo.Text = "";
        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGo_Click(null, null);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataTable tableTemp = new DataTable();
            tableTemp.Columns.Add("BarCode");
            tableTemp.Columns.Add("Info");
            tableTemp.Rows.Add(txtBarCode.Text, rtxtInfo.Text);
            repReportsBarCode rd = new repReportsBarCode();
            StartForm(new frmActiveReport(tableTemp, rd));
        }

	}
}