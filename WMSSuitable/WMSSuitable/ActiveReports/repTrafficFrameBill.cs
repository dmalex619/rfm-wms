using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using WMSBizObjects;

namespace WMSSuitable
{
	/// <summary>
	/// Summary description for repTrafficFrameBill
	/// </summary>
	public partial class repTrafficFrameBill : DataDynamics.ActiveReports.ActiveReport3
	{

		public repTrafficFrameBill()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

		private void detail_Format(object sender, EventArgs e)
		{
			string s = "00000" + Fields["FrameID"].Value.ToString().Trim();
			txtFrameID5.Text = s.Substring(s.Length - 5, 5);
			if (Fields["DateConfirm"].Value == DBNull.Value)
			{
				txtDateConfirm.Text = "";
			}
			Frame oFrame = new Frame();
			oFrame.ID = Convert.ToInt32(Fields["FrameID"].Value);
			oFrame.FillTableFramesContents(oFrame.ID);
			if (oFrame.TableFramesContents.Rows.Count > 0)
			{
				txtGoodAlias.Text = oFrame.TableFramesContents.Rows[0]["GoodAlias"].ToString();
				if (oFrame.TableFramesContents.Rows[0]["DateValid"] != DBNull.Value)
					txtDateValid.Text = "до " + oFrame.TableFramesContents.Rows[0]["DateValid"].ToString().Substring(0, 10);
				else
					txtDateValid.Text = "";
			}
			else
				txtGoodAlias.Text = txtDateValid.Text = ""; 
		}
	}
}
