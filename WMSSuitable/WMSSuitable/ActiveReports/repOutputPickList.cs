using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

using System.Data;
using WMSBizObjects;

namespace WMSSuitable
{
	/// <summary>
	/// Summary description for repOutputPickList
	/// </summary>
	public partial class repOutputPickList : DataDynamics.ActiveReports.ActiveReport3
	{
		private int nOutputID = 0;
        private string sChargeOrder = "";

		private float nTxtGoodAliasWidth;
        private float nDetailHeight;
        
        private DateTime? dDateOutput;
        private decimal nQntConfirmed;
		private decimal nRestQntConfirmed;
		private decimal nRestQntWished;
        private decimal nInBox;
		private bool bWeighting = false;
		private bool bPrintDecimals = false;
		private bool bExistsNewTrafficsGoods = false;

		private decimal nAllBox = 0;
		private decimal nAllAdd = 0;

        private Font fFontGoodAlias;
        private string sCellSourceLine = "";
        private char cLine;
        private int nLineCode;

		public repOutputPickList()
		{
			InitializeComponent();

			nTxtGoodAliasWidth = txtGoodAlias.Width;
			fFontGoodAlias = txtGoodAlias.Font;
            nDetailHeight = detail.Height;
		}

		private void detail_Format(object sender, EventArgs e)
		{
            nOutputID = Convert.ToInt32(Fields["OutputID"].Value);
            sChargeOrder = Fields["ChargeOrder"].Value.ToString();
			nInBox = Convert.ToDecimal(Fields["InBox"].Value);
			nQntConfirmed = Convert.ToDecimal(Fields["QntConfirmed"].Value);
			nRestQntConfirmed = Convert.ToDecimal(Fields["RestQntConfirmed"].Value);
			nRestQntWished = Convert.ToDecimal(Fields["RestQntWished"].Value);
			bWeighting = Convert.ToBoolean(Fields["Weighting"].Value);
			bPrintDecimals = Convert.ToBoolean(Fields["PrintDecimals"].Value);

			if (bPrintDecimals)
			{
				txtInBox.Text = nInBox.ToString("### ##0.000");
				txtRestQntWished.Text = nRestQntWished.ToString("### ##0.000");
				txtQntConfirmed.Text = nRestQntConfirmed.ToString("### ##0.000");
			}
			else
			{
				txtInBox.Text = nInBox.ToString("### ### ###");
				txtRestQntWished.Text = nRestQntWished.ToString("### ### ###");
				txtQntConfirmed.Text = nRestQntConfirmed.ToString("### ### ###");
			}

            // факт
			if (nQntConfirmed == 0)
			{
				txtQntConfirmed.Text = txtBoxConfirmed.Text = "";
			}
			/*
			else
			{
				if (bWeighting)
				{
					txtBoxConfirmed.Text = "";
					txtQntConfirmed.Value = (nQntConfirmed > 0) ? nQntConfirmed.ToString("### ##0.000") : "";
				}
				else
				{
					decimal nBoxConfirmed = Math.Floor(nQntConfirmed / nInBox);
					txtBoxConfirmed.Text = (nBoxConfirmed > 0) ? nBoxConfirmed.ToString() : "";
					nQntConfirmed = nQntConfirmed - nBoxConfirmed * nInBox;
					txtQntConfirmed.Value = (nQntConfirmed > 0) ? nQntConfirmed.ToString() : "";
				}
			}
			*/ 

            if (!Convert.IsDBNull(Fields["DateOutput"].Value)) 
                dDateOutput = Convert.ToDateTime(Fields["DateOutput"].Value);
            else 
                dDateOutput = null;

			if (!Convert.IsDBNull(Fields["ExistsNewTrafficsGoods"].Value))
				bExistsNewTrafficsGoods = Convert.ToBoolean(Fields["ExistsNewTrafficsGoods"].Value);
			else
				bExistsNewTrafficsGoods = false;

            if (!Convert.IsDBNull(Fields["DatePrint"].Value))
                txtPrinted.Text = "#";
            else
                txtPrinted.Text = "";

			txtGoodAlias.Font = fFontGoodAlias;
			if (Fields["ZeroQntNote"].Value.ToString() != "")
			{
				txtGoodAlias.Font = new Font(txtGoodAlias.Font, FontStyle.Bold | FontStyle.Italic); 
			}

			nAllBox += Convert.ToDecimal(Fields["RestBoxWished"].Value) + Convert.ToDecimal(Fields["TrafficsFramesAddBox"].Value);
			nAllAdd += Convert.ToDecimal(Fields["RestQntWished"].Value) + Convert.ToDecimal(Fields["TrafficsFramesAddRestQnt"].Value);

			// да, не хочется сюда - но больше некуда
			if (bWeighting)
			{
				txtStoreZoneRestQnt.OutputFormat =
				txtStoreZoneTrafficsFramesAddBoxW.OutputFormat =
				txtStoreZoneAllAdd.OutputFormat =
					"### ### ##0.000";

				lblFooterBox.Text = "По складу кг:";
				lblFooterInFrames.Text = "Кг в целых паллетах:";

				txtStoreZoneTrafficsFramesAddBoxW.Visible = true;
				txtStoreZoneAllBox.Visible = false;
				txtStoreZoneAllAdd.Visible = true;
			}
			else
			{
				txtStoreZoneRestQnt.OutputFormat =
				txtStoreZoneTrafficsFramesAddBoxW.OutputFormat =
				txtStoreZoneAllAdd.OutputFormat =
					"### ### ###";

				lblFooterBox.Text = "По складу коробок:";
				lblFooterInFrames.Text = "Коробок в целых паллетах:";

				txtStoreZoneTrafficsFramesAddBoxW.Visible = false;
				txtStoreZoneAllBox.Visible = true;
				txtStoreZoneAllAdd.Visible = false;
            }

            // Изменение цвета фона в зависимости от "четности" линии
            sCellSourceLine = Fields["CellSourceCLine"].Value.ToString();
            if (sCellSourceLine.Length == 0)
            {
                txtCellSourceAddress.BackColor = Color.Transparent;
            }
            else
            {
                cLine = Convert.ToChar(sCellSourceLine.Substring(0,1));
                nLineCode = Convert.ToInt32(cLine);
                if (nLineCode % 2 == 0)
            {
                sCellSourceLine = Fields["CellSourceCLine"].Value.ToString();
                txtCellSourceAddress.BackColor = Color.Gainsboro;
            }
            else txtCellSourceAddress.BackColor = Color.Transparent;
            }
		}

		private void pageHeader_BeforePrint(object sender, EventArgs e)
		{
			if (Convert.ToInt16(txtPageNumber.Text) > Convert.ToInt16(txtPageCount.Text))
			{
				reportInfo1.Visible = false;
				txtReportInfoProblem.Visible = true; 
				txtReportInfoProblem.Text = reportInfo1.FormatString.Replace("{PageNumber}", txtPageNumber.Text).Replace("{PageNumber}", txtPageCount.Text);
			}
		}

		private void pageFooter_Format(object sender, EventArgs e)
		{
			txtOutputIDFooter.Text = nOutputID.ToString();
            txtChargeOrder.Text = sChargeOrder;
		}

        private void groupOutputID_Format(object sender, EventArgs e)
        {
            if (nOutputID == 0)
			{
                nOutputID = Convert.ToInt32(Fields["OutputID"].Value);
			}

			//if (Fields["DateOutput"].Value != null && !Convert.IsDBNull(Fields["DateOutput"].Value))
			if (dDateOutput != null)
			{
				txtDateOutput.Text = ((DateTime)dDateOutput).ToString("dd.MM.yyyy");
			}
			else
			{
				txtDateOutput.Text = "";
			}

			//if (Convert.ToBoolean(Fields["ExistsNewTrafficsGoods"].Value))
			if (bExistsNewTrafficsGoods)
			{
				txtExistsNewTrafficsGoods.Text = "ДОП";
			}
			else
			{
				txtExistsNewTrafficsGoods.Text = "";
			}
        }


        private void detail_BeforePrint(object sender, EventArgs e)
        {
            line1.Y1 = detail.Height - (float)0.01;
            line1.Y2 = line1.Y1;

			lineH1.Y2 =
            lineH2.Y2 =
            lineH3.Y2 =
            lineH4.Y2 =
			lineH5.Y2 =
			lineH6.Y2 =
            lineHGray1.Y2 =
            lineHGray2.Y2 =
                detail.Height - (float)0.01;
        }

		private void groupWeighting_BeforePrint(object sender, EventArgs e)
		{
			if (bWeighting)
			{
				lblWishedBoxQnt.Text = lblConfirmedBoxQnt.Text = "кг";
                lineHGray1.Visible = lineHGray2.Visible = false;
			}
			else
			{
				lblWishedBoxQnt.Text = lblConfirmedBoxQnt.Text = "кор. +  штук";
                lineHGray1.Visible = lineHGray2.Visible = true;
            }
		}

		private void groupFooterWeighting_Format(object sender, EventArgs e)
		{
			txtStoreZoneAllBox.Value = nAllBox; //(Convert.ToInt32(nAllBox)).ToString();
			txtStoreZoneAllAdd.Value = nAllAdd; //(Convert.ToInt32(nAllAdd)).ToString();
			nAllBox = 0;
			nAllAdd = 0;
		}

		private void repOutputPickList_FetchData(object sender, FetchEventArgs eArgs)
		{
			bWeighting = Convert.ToBoolean(Fields["Weighting"].Value);
		}

    }
}
