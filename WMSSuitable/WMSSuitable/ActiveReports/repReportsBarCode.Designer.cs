namespace WMSSuitable
{
	/// <summary>
	/// Summary description for repReportsBarCode.
	/// </summary>
	partial class repReportsBarCode
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(repReportsBarCode));
			this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
			this.detail = new DataDynamics.ActiveReports.Detail();
			this.bcBarCode = new DataDynamics.ActiveReports.Barcode();
			this.reportInfo1 = new DataDynamics.ActiveReports.ReportInfo();
			this.txtInfo = new DataDynamics.ActiveReports.TextBox();
			this.line1 = new DataDynamics.ActiveReports.Line();
			this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
			this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
			this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
			this.field1 = new DataDynamics.ActiveReports.Field();
			((System.ComponentModel.ISupportInitialize)(this.reportInfo1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtInfo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// pageHeader
			// 
			this.pageHeader.Height = 0.08333334F;
			this.pageHeader.Name = "pageHeader";
			// 
			// detail
			// 
			this.detail.ColumnSpacing = 0F;
			this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.bcBarCode,
            this.reportInfo1,
            this.txtInfo,
            this.line1});
			this.detail.Height = 1.864583F;
			this.detail.Name = "detail";
			// 
			// bcBarCode
			// 
			this.bcBarCode.Border.BottomColor = System.Drawing.Color.Black;
			this.bcBarCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.bcBarCode.Border.LeftColor = System.Drawing.Color.Black;
			this.bcBarCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.bcBarCode.Border.RightColor = System.Drawing.Color.Black;
			this.bcBarCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.bcBarCode.Border.TopColor = System.Drawing.Color.Black;
			this.bcBarCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.bcBarCode.CaptionPosition = DataDynamics.ActiveReports.BarCodeCaptionPosition.Below;
			this.bcBarCode.DataField = "BarCode";
			this.bcBarCode.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.bcBarCode.Height = 0.7874016F;
			this.bcBarCode.Left = 0.1574803F;
			this.bcBarCode.Name = "bcBarCode";
			this.bcBarCode.Style = DataDynamics.ActiveReports.BarCodeStyle.Code_128auto;
			this.bcBarCode.Text = "barcode";
			this.bcBarCode.Top = 0.1968504F;
			this.bcBarCode.Width = 2.913386F;
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
			this.reportInfo1.Top = 1.653543F;
			this.reportInfo1.Width = 1.338583F;
			// 
			// txtInfo
			// 
			this.txtInfo.Border.BottomColor = System.Drawing.Color.Black;
			this.txtInfo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.txtInfo.Border.LeftColor = System.Drawing.Color.Black;
			this.txtInfo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.txtInfo.Border.RightColor = System.Drawing.Color.Black;
			this.txtInfo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.txtInfo.Border.TopColor = System.Drawing.Color.Black;
			this.txtInfo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.txtInfo.DataField = "Info";
			this.txtInfo.Height = 0.2362205F;
			this.txtInfo.Left = 0.1181102F;
			this.txtInfo.Name = "txtInfo";
			this.txtInfo.Style = "ddo-char-set: 1; text-align: left; font-weight: normal; font-size: 12pt; ";
			this.txtInfo.Text = "Info";
			this.txtInfo.Top = 1.220472F;
			this.txtInfo.Width = 7.007874F;
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
			this.line1.Left = 0.03937008F;
			this.line1.LineWeight = 1F;
			this.line1.Name = "line1";
			this.line1.Top = 1.811024F;
			this.line1.Width = 7.086614F;
			this.line1.X1 = 0.03937008F;
			this.line1.X2 = 7.125984F;
			this.line1.Y1 = 1.811024F;
			this.line1.Y2 = 1.811024F;
			// 
			// pageFooter
			// 
			this.pageFooter.Height = 0.08333334F;
			this.pageFooter.Name = "pageFooter";
			// 
			// groupHeader1
			// 
			this.groupHeader1.Height = 0.08333334F;
			this.groupHeader1.Name = "groupHeader1";
			// 
			// groupFooter1
			// 
			this.groupFooter1.Height = 0.07291666F;
			this.groupFooter1.Name = "groupFooter1";
			// 
			// field1
			// 
			this.field1.DefaultValue = null;
			this.field1.FieldType = DataDynamics.ActiveReports.FieldTypeEnum.Int32;
			this.field1.Formula = "ID";
			this.field1.Name = "field1";
			this.field1.Tag = null;
			// 
			// repReportsBarCode
			// 
			this.CalculatedFields.Add(this.field1);
			this.PageSettings.DefaultPaperSize = false;
			this.PageSettings.Margins.Bottom = 0.3937008F;
			this.PageSettings.Margins.Left = 0.3937008F;
			this.PageSettings.Margins.Right = 0.3897638F;
			this.PageSettings.Margins.Top = 0.3937008F;
			this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait;
			this.PageSettings.PaperHeight = 11.69291F;
			this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
			this.PageSettings.PaperWidth = 8.267716F;
			this.PrintWidth = 7.427083F;
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
			((System.ComponentModel.ISupportInitialize)(this.reportInfo1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtInfo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}
		#endregion

		private DataDynamics.ActiveReports.GroupHeader groupHeader1;
		private DataDynamics.ActiveReports.GroupFooter groupFooter1;
		private DataDynamics.ActiveReports.Field field1;
		private DataDynamics.ActiveReports.Barcode bcBarCode;
		private DataDynamics.ActiveReports.ReportInfo reportInfo1;
		private DataDynamics.ActiveReports.TextBox txtInfo;
		private DataDynamics.ActiveReports.Line line1;

	}
}
