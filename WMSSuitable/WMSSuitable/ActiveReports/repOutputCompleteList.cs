using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace WMSSuitable
{
	public partial class repOutputCompleteList : DataDynamics.ActiveReports.ActiveReport3
	{
		private int nOutputID;

		//private float nGroupHeaderIsFrameHeight;
		private float nGroupHeaderStoreZoneSourceIDHeight;
		Font oDetailFont;
		bool bStoreZoneSeparated;

		// ��� Fetch
		int _nOutputID = 0;
        string _sChargeOrder = "";
		DateTime? _dOutputDateConfirm = null;
		bool _bIsFrame = false;
		int _nOutputSelectedInfo = 0;
		int _nOutputTrafficsInfo = 0;
		decimal _nQnt = 0;
		DateTime? _dDateValid = null;


		public repOutputCompleteList(bool bStoreZoneSeparate)
		{
			InitializeComponent();

			//nGroupHeaderIsFrameHeight = groupHeaderIsFrame.Height;
			nGroupHeaderStoreZoneSourceIDHeight = groupHeaderStoreZoneSourceID.Height;
			oDetailFont = txtGoodAlias.Font;

			bStoreZoneSeparated = bStoreZoneSeparate;

			if (bStoreZoneSeparated)
			{
				groupFooterIsFrame.NewPage = NewPage.Before;
				groupHeaderStoreZoneSourceID.NewPage = NewPage.Before;
			}
		}

		private void groupHeaderIsFrame_Format(object sender, EventArgs e)
		{
			if (_bIsFrame)
			{
				lblIsFrame.Text = "�������:";
				//groupHeaderIsFrame.Height = nGroupHeaderIsFrameHeight;
			}
			else
			{
				lblIsFrame.Text = "�������:";
				//groupHeaderIsFrame.Height = 0; 
			}
		}

		private void groupHeaderStoreZoneSourceID_Format(object sender, EventArgs e)
		{
			if (_bIsFrame)
			{
				groupHeaderStoreZoneSourceID.Height = 0;
			}
			else
			{
				groupHeaderStoreZoneSourceID.Height = nGroupHeaderStoreZoneSourceIDHeight;
			}
		}


		private void groupOutputID_Format(object sender, EventArgs e)
		{
			string sStateText = "";
			if (_dOutputDateConfirm.HasValue)
			{
				sStateText += "�����." + ((DateTime)_dOutputDateConfirm).ToString("dd.MM.yyyy") + " ";
			}
			else
			{
				// ��� ������ ��� ��������� � ��� ����������� ���������
				switch (_nOutputSelectedInfo)
				{
					case (0):
						//sStateText += "����� �� ��������. "; 
						break;
					case (1):
						sStateText += "�� ���� ����� ��������. ";
						break;
					case (2):
						//sStateText += "���� ����� ��������. ";
						break;
				}
				switch (_nOutputTrafficsInfo)
				{
					case (0):
						//sStateText += "����������� �������/������ �� ���������. "; 
						break;
					case (1):
						//sStateText += "�� ��� ����������� �������/������ ���������";
						break;
					case (2):
						//sStateText += "�� ��� ����������� �������/������ ���������.";
						break;
				}
			}
			txtStateText.Text = sStateText;
		}

		private void detail_Format(object sender, EventArgs e)
		{
			//nOutputID = Convert.ToInt32(Fields["OutputID"].Value);
			nOutputID = _nOutputID;
			if (!_dDateValid.HasValue)
			{
				txtDateValid.Text = "";
			}
			else
			{
				txtDateValid.Text = _dDateValid.ToString().Substring(0, 10);
			}
			if (_nQnt == 0)
			{
				txtGoodAlias.Font = new Font(oDetailFont, FontStyle.Strikeout);
			}
			else
			{
				txtGoodAlias.Font = new Font(oDetailFont, FontStyle.Regular);
			}
		}

		private void pageFooter_Format(object sender, EventArgs e)
		{
			txtOutputIDFooter.Text = nOutputID.ToString();
            txtChargeOrder.Text = _sChargeOrder;
		}

		// ------------

		private void repOutputCompleteList_FetchData(object sender, FetchEventArgs eArgs)
		{
			_nOutputID = Convert.ToInt32(Fields["OutputID"].Value);
			_bIsFrame = Convert.ToBoolean(Fields["IsFrame"].Value);
			if (!Convert.IsDBNull(Fields["OutputDateConfirm"].Value))
				_dOutputDateConfirm = Convert.ToDateTime(Fields["OutputDateConfirm"].Value);
			else
				_dOutputDateConfirm = null;
			_nOutputSelectedInfo = Convert.ToInt32(Fields["OutputSelectedInfo"].Value);
			_nOutputTrafficsInfo = Convert.ToInt32(Fields["OutputTrafficsInfo"].Value);
			if (!Convert.IsDBNull(Fields["DateValid"].Value))
				_dDateValid = Convert.ToDateTime(Fields["DateValid"].Value);
			else
				_dDateValid = null;
			_nQnt = Convert.ToDecimal(Fields["Qnt"].Value);
            _sChargeOrder = Fields["ChargeOrder"].Value.ToString();
		}
	}
}
