using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

using System.Data;

namespace WMSSuitable
{
	public partial class repOutputControlList : DataDynamics.ActiveReports.ActiveReport3
	{
		private int nOutputID;
		Font oDetailFont;

		// fetch 
		int _nOutputID = 0;
		bool _bIsFrame = false;
		DateTime? _dOutputDateConfirm = null;


		public repOutputControlList()
		{
			InitializeComponent();

			oDetailFont = txtGoodAlias.Font;
		}

		private void groupHeaderIsFrame_Format(object sender, EventArgs e)
		{
			if (_bIsFrame)
			{
				lblIsFrame.Text = "Паллеты:";
			}
			else
			{
				lblIsFrame.Text = "Коробки:";
			}
		}

		private void groupOutputID_Format(object sender, EventArgs e)
		{
			if (_dOutputDateConfirm.HasValue)
			{
				txtStateText.Text = "Подтв." + ((DateTime)_dOutputDateConfirm).ToString("dd.MM.yyyy");
			}
			else
			{
				txtStateText.Text = "";
			}

		}

		private void detail_Format(object sender, EventArgs e)
		{
			nOutputID = _nOutputID;
		}

		private void pageFooter_Format(object sender, EventArgs e)
		{
			txtOutputIDFooter.Text = nOutputID.ToString();
		}

		// ------------

		private void repOutputControlList_FetchData(object sender, FetchEventArgs eArgs)
		{
			_nOutputID = Convert.ToInt32(Fields["OutputID"].Value);
			_bIsFrame = Convert.ToBoolean(Fields["IsFrame"].Value);
			if (!Convert.IsDBNull(Fields["OutputDateConfirm"].Value))
				_dOutputDateConfirm = Convert.ToDateTime(Fields["OutputDateConfirm"].Value);
			else
				_dOutputDateConfirm = null;
		}

		private void repOutputControlList_DataInitialize(object sender, EventArgs e)
		{

			DataTable dt = (DataTable)this.DataSource;
			if (dt.Rows[0]["GoodBarCode"].ToString() == "")
			{
				barcodeGood.Visible = false;
				groupGoodBarCode.Height = 0;
			}
		}

	}
}
