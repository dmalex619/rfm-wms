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

		// для Fetch
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
				lblIsFrame.Text = "Паллеты:";
				//groupHeaderIsFrame.Height = nGroupHeaderIsFrameHeight;
			}
			else
			{
				lblIsFrame.Text = "Коробки:";
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
				sStateText += "Подтв." + ((DateTime)_dOutputDateConfirm).ToString("dd.MM.yyyy") + " ";
			}
			else
			{
				// все товары уже подобраны и все перемещения выполнены
				switch (_nOutputSelectedInfo)
				{
					case (0):
						//sStateText += "Товар не подобран. "; 
						break;
					case (1):
						sStateText += "Не весь товар подобран. ";
						break;
					case (2):
						//sStateText += "Весь товар подобран. ";
						break;
				}
				switch (_nOutputTrafficsInfo)
				{
					case (0):
						//sStateText += "Перемещения коробок/паллет не выполнены. "; 
						break;
					case (1):
						//sStateText += "Не все перемещения коробок/паллет выполнены";
						break;
					case (2):
						//sStateText += "Не все перемещения коробок/паллет выполнены.";
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
