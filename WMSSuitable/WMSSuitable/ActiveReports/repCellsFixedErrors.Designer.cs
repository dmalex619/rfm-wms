namespace WMSSuitable
{
	/// <summary>
	/// Summary description for repCellsFixedErrors
	/// </summary>
	partial class repCellsFixedErrors
	{
		private DataDynamics.ActiveReports.PageHeader pageHeader;
		private DataDynamics.ActiveReports.Detail detail;
		private DataDynamics.ActiveReports.PageFooter pageFooter;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
			}
			base.Dispose(disposing);
		}

		#region ActiveReport Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(repCellsFixedErrors));
			this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
			this.reportInfo3 = new DataDynamics.ActiveReports.ReportInfo();
			this.label2 = new DataDynamics.ActiveReports.Label();
			this.reportInfo2 = new DataDynamics.ActiveReports.ReportInfo();
			this.detail = new DataDynamics.ActiveReports.Detail();
			this.textBox1 = new DataDynamics.ActiveReports.TextBox();
			this.line1 = new DataDynamics.ActiveReports.Line();
			this.textBox2 = new DataDynamics.ActiveReports.TextBox();
			this.textBox3 = new DataDynamics.ActiveReports.TextBox();
			this.textBox4 = new DataDynamics.ActiveReports.TextBox();
			this.reportInfo1 = new DataDynamics.ActiveReports.ReportInfo();
			this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
			this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
			this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
			((System.ComponentModel.ISupportInitialize)(this.reportInfo3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.reportInfo2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.reportInfo1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// pageHeader
			// 
			this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.reportInfo3,
            this.label2,
            this.reportInfo2});
			this.pageHeader.Height = 0.2395833F;
			this.pageHeader.Name = "pageHeader";
			// 
			// reportInfo3
			// 
			this.reportInfo3.Border.BottomColor = System.Drawing.Color.Black;
			this.reportInfo3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.reportInfo3.Border.LeftColor = System.Drawing.Color.Black;
			this.reportInfo3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.reportInfo3.Border.RightColor = System.Drawing.Color.Black;
			this.reportInfo3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.reportInfo3.Border.TopColor = System.Drawing.Color.Black;
			this.reportInfo3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.reportInfo3.FormatString = "Стр. {PageNumber} из {PageCount}";
			this.reportInfo3.Height = 0.1574803F;
			this.reportInfo3.Left = 5.669291F;
			this.reportInfo3.Name = "reportInfo3";
			this.reportInfo3.Style = "text-align: right; ";
			this.reportInfo3.Top = 0.03937008F;
			this.reportInfo3.Width = 1.456693F;
			// 
			// label2
			// 
			this.label2.Border.BottomColor = System.Drawing.Color.Black;
			this.label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.label2.Border.LeftColor = System.Drawing.Color.Black;
			this.label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.label2.Border.RightColor = System.Drawing.Color.Black;
			this.label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.label2.Border.TopColor = System.Drawing.Color.Black;
			this.label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.label2.Height = 0.1574803F;
			this.label2.HyperLink = null;
			this.label2.Left = 0.1181102F;
			this.label2.Name = "label2";
			this.label2.Style = "font-weight: bold; ";
			this.label2.Text = "Отчет о найденных несоответствиях в ячейках";
			this.label2.Top = 0.03937008F;
			this.label2.Width = 3.503937F;
			// 
			// reportInfo2
			// 
			this.reportInfo2.Border.BottomColor = System.Drawing.Color.Black;
			this.reportInfo2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.reportInfo2.Border.LeftColor = System.Drawing.Color.Black;
			this.reportInfo2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.reportInfo2.Border.RightColor = System.Drawing.Color.Black;
			this.reportInfo2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.reportInfo2.Border.TopColor = System.Drawing.Color.Black;
			this.reportInfo2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.reportInfo2.FormatString = "{RunDateTime:dd.MM.yyyy}";
			this.reportInfo2.Height = 0.1574803F;
			this.reportInfo2.Left = 3.622047F;
			this.reportInfo2.Name = "reportInfo2";
			this.reportInfo2.Style = "font-weight: bold; ";
			this.reportInfo2.SummaryGroup = "groupHeader1";
			this.reportInfo2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
			this.reportInfo2.Top = 0.03937008F;
			this.reportInfo2.Width = 1.023622F;
			// 
			// detail
			// 
			this.detail.ColumnSpacing = 0F;
			this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox1,
            this.line1,
            this.textBox2,
            this.textBox3,
            this.textBox4});
			this.detail.Height = 0.3020833F;
			this.detail.KeepTogether = true;
			this.detail.Name = "detail";
			// 
			// textBox1
			// 
			this.textBox1.Border.BottomColor = System.Drawing.Color.Black;
			this.textBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.textBox1.Border.LeftColor = System.Drawing.Color.Black;
			this.textBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.textBox1.Border.RightColor = System.Drawing.Color.Black;
			this.textBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.textBox1.Border.TopColor = System.Drawing.Color.Black;
			this.textBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.textBox1.DataField = "ID";
			this.textBox1.Height = 0.1968504F;
			this.textBox1.Left = 0.1968504F;
			this.textBox1.Name = "textBox1";
			this.textBox1.Style = "ddo-char-set: 204; font-weight: normal; font-size: 10pt; ";
			this.textBox1.Text = "ID";
			this.textBox1.Top = 0.03937008F;
			this.textBox1.Width = 0.3543307F;
			// 
			// line1
			// 
			this.line1.Border.BottomColor = System.Drawing.Color.Black;
			this.line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.line1.Border.LeftColor = System.Drawing.Color.Black;
			this.line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.line1.Border.RightColor = System.Drawing.Color.Black;
			this.line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.line1.Border.TopColor = System.Drawing.Color.Black;
			this.line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.line1.Height = 0F;
			this.line1.Left = 0.1181102F;
			this.line1.LineWeight = 1F;
			this.line1.Name = "line1";
			this.line1.Top = 0.2755906F;
			this.line1.Width = 7.244095F;
			this.line1.X1 = 0.1181102F;
			this.line1.X2 = 7.362205F;
			this.line1.Y1 = 0.2755906F;
			this.line1.Y2 = 0.2755906F;
			// 
			// textBox2
			// 
			this.textBox2.Border.BottomColor = System.Drawing.Color.Black;
			this.textBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.textBox2.Border.LeftColor = System.Drawing.Color.Black;
			this.textBox2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.textBox2.Border.RightColor = System.Drawing.Color.Black;
			this.textBox2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.textBox2.Border.TopColor = System.Drawing.Color.Black;
			this.textBox2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.textBox2.DataField = "Address";
			this.textBox2.Height = 0.1968504F;
			this.textBox2.Left = 0.5905512F;
			this.textBox2.Name = "textBox2";
			this.textBox2.Style = "ddo-char-set: 204; font-weight: normal; font-size: 10pt; ";
			this.textBox2.Text = "Address";
			this.textBox2.Top = 0.03937008F;
			this.textBox2.Width = 1.062992F;
			// 
			// textBox3
			// 
			this.textBox3.Border.BottomColor = System.Drawing.Color.Black;
			this.textBox3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.textBox3.Border.LeftColor = System.Drawing.Color.Black;
			this.textBox3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.textBox3.Border.RightColor = System.Drawing.Color.Black;
			this.textBox3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.textBox3.Border.TopColor = System.Drawing.Color.Black;
			this.textBox3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.textBox3.DataField = "Note";
			this.textBox3.Height = 0.1968504F;
			this.textBox3.Left = 3.149606F;
			this.textBox3.Name = "textBox3";
			this.textBox3.Style = "ddo-char-set: 204; font-weight: normal; font-size: 10pt; ";
			this.textBox3.Text = "Note";
			this.textBox3.Top = 0.03937008F;
			this.textBox3.Width = 4.094488F;
			// 
			// textBox4
			// 
			this.textBox4.Border.BottomColor = System.Drawing.Color.Black;
			this.textBox4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.textBox4.Border.LeftColor = System.Drawing.Color.Black;
			this.textBox4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.textBox4.Border.RightColor = System.Drawing.Color.Black;
			this.textBox4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.textBox4.Border.TopColor = System.Drawing.Color.Black;
			this.textBox4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.textBox4.DataField = "StoreZoneName";
			this.textBox4.Height = 0.1968504F;
			this.textBox4.Left = 1.692913F;
			this.textBox4.Name = "textBox4";
			this.textBox4.Style = "ddo-char-set: 204; font-weight: normal; font-size: 10pt; ";
			this.textBox4.Text = "Address";
			this.textBox4.Top = 0.03937008F;
			this.textBox4.Width = 1.377953F;
			// 
			// reportInfo1
			// 
			this.reportInfo1.Border.BottomColor = System.Drawing.Color.Black;
			this.reportInfo1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.reportInfo1.Border.LeftColor = System.Drawing.Color.Black;
			this.reportInfo1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.reportInfo1.Border.RightColor = System.Drawing.Color.Black;
			this.reportInfo1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.reportInfo1.Border.TopColor = System.Drawing.Color.Black;
			this.reportInfo1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.reportInfo1.FormatString = "{RunDateTime:dd.MM.yyyy HH:mm}";
			this.reportInfo1.Height = 0.1181103F;
			this.reportInfo1.Left = 5.787402F;
			this.reportInfo1.Name = "reportInfo1";
			this.reportInfo1.Style = "ddo-char-set: 1; text-align: right; font-size: 6pt; ";
			this.reportInfo1.Top = 0.07874016F;
			this.reportInfo1.Width = 1.338583F;
			// 
			// pageFooter
			// 
			this.pageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.reportInfo1});
			this.pageFooter.Height = 0.2916667F;
			this.pageFooter.Name = "pageFooter";
			// 
			// groupHeader1
			// 
			this.groupHeader1.Height = 0.02083333F;
			this.groupHeader1.Name = "groupHeader1";
			// 
			// groupFooter1
			// 
			this.groupFooter1.Height = 0.03125F;
			this.groupFooter1.Name = "groupFooter1";
			// 
			// repCellsFixedErrors
			// 
			this.PageSettings.DefaultPaperSize = false;
			this.PageSettings.Margins.Bottom = 0.3937008F;
			this.PageSettings.Margins.Left = 0.3937008F;
			this.PageSettings.Margins.Right = 0.3937008F;
			this.PageSettings.Margins.Top = 0.3937008F;
			this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait;
			this.PageSettings.PaperHeight = 11.69291F;
			this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
			this.PageSettings.PaperWidth = 8.267716F;
			this.PrintWidth = 7.440945F;
			this.Sections.Add(this.pageHeader);
			this.Sections.Add(this.groupHeader1);
			this.Sections.Add(this.detail);
			this.Sections.Add(this.groupFooter1);
			this.Sections.Add(this.pageFooter);
			this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-style: normal; text-decoration: none; font-weight: normal; font-size: 10pt; " +
						"color: Black; font-family: \"Tahoma\"; ddo-char-set: 204; ", "Normal"));
			this.StyleSheet.Add(new DDCssLib.StyleSheetRule("ddo-char-set: 204; font-size: 12pt; font-weight: bold; ", "Heading1", "Normal"));
			this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
						"lic; ddo-char-set: 204; ", "Heading2", "Normal"));
			this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ddo-char-set: 204; ", "Heading3", "Normal"));
			((System.ComponentModel.ISupportInitialize)(this.reportInfo3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.reportInfo2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.reportInfo1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}
		#endregion

		private DataDynamics.ActiveReports.GroupHeader groupHeader1;
		private DataDynamics.ActiveReports.GroupFooter groupFooter1;
		private DataDynamics.ActiveReports.TextBox textBox1;
		private DataDynamics.ActiveReports.ReportInfo reportInfo1;
		private DataDynamics.ActiveReports.Line line1;
		private DataDynamics.ActiveReports.Label label2;
		private DataDynamics.ActiveReports.TextBox textBox2;
		private DataDynamics.ActiveReports.TextBox textBox3;
		private DataDynamics.ActiveReports.ReportInfo reportInfo2;
		private DataDynamics.ActiveReports.ReportInfo reportInfo3;
		private DataDynamics.ActiveReports.TextBox textBox4;

	}
}
