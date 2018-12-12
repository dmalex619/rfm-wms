using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace WMSSuitable
{
	public partial class repForSalary : DataDynamics.ActiveReports.ActiveReport3
	{
		string sMode = "";
		bool bGroupBy = false;

		public repForSalary(string _sTitle, string _sMode, bool _bGroupBy)
		{
			InitializeComponent();

			txtTitle.Text = _sTitle;
			sMode = _sMode.ToUpper();
			bGroupBy = _bGroupBy;

			if (bGroupBy)
			{
				groupBrigadeNameFooter.Visible = false;
				groupBrigadeNameFooter.Height = 0;
			}

			Label l;
			foreach (Object o in groupHeader1.Controls)
			{
				if (o.GetType().Name == "Label")
				{
					l = (Label)o;
					l.Visible = !l.Name.ToUpper().Contains("_") || (l.Name.Substring(0, sMode.Length + 4).ToUpper() == "LBL" + sMode + "_");
					l.Top = lblBrigadeUserName.Top;
				}
			}
			groupHeader1.Height = (float)lineGroupHeaderH2.Y1 + (float)0.01;

			TextBox t;
			foreach (Object o in detail.Controls)
			{
				if (o.GetType().Name == "TextBox")
				{
					t = (TextBox)o;
					t.Visible = !t.Name.ToUpper().Contains("_") || (t.Name.Substring(0, sMode.Length + 4).ToUpper() == "TXT" + sMode + "_");
					t.Top = txtBrigadeName.Top;
				}
			}
			detail.Height = (float)lineDetailH1.Y1 + (float)0.01;

			foreach (Object o in groupBrigadeNameFooter.Controls)
			{
				if (o.GetType().Name == "TextBox")
				{
					t = (TextBox)o;
					t.Visible = !t.Name.ToUpper().Contains("_") || (t.Name.Substring(0, sMode.Length + 4).ToUpper() == "TXT" + sMode + "_");
					t.Top = lblS.Top;
				}
			}
			groupBrigadeNameFooter.Height = (float)lineGroupBrigadeNameFooterH2.Y1 + (float)0.01;

			foreach (Object o in groupFooter1.Controls)
			{
				if (o.GetType().Name == "TextBox")
				{
					t = (TextBox)o;
					t.Visible = !t.Name.ToUpper().Contains("_") || (t.Name.Substring(0, sMode.Length + 4).ToUpper() == "TXT" + sMode + "_");
					t.Top = lblSS.Top;
				}
			}
			groupFooter1.Height = (float)lblSS.Top + (float)lblSS.Height + (float)0.1;
		}
	}
}
