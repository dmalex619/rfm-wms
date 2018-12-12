namespace WMSSuitable
{
	/// <summary>
	/// Summary description for repFrameLabel.
	/// </summary>
	partial class repFrameLabel
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(repFrameLabel));
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.barcode1 = new DataDynamics.ActiveReports.Barcode();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.line1 = new DataDynamics.ActiveReports.Line();
            this.label2 = new DataDynamics.ActiveReports.Label();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.reportInfo1 = new DataDynamics.ActiveReports.ReportInfo();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            this.field1 = new DataDynamics.ActiveReports.Field();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportInfo1)).BeginInit();
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
            this.textBox1,
            this.barcode1,
            this.label1,
            this.line1,
            this.label2,
            this.textBox2});
            this.detail.Height = 0.9270833F;
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
            this.textBox1.Height = 0.1968505F;
            this.textBox1.Left = 5F;
            this.textBox1.Name = "textBox1";
            this.textBox1.Style = "ddo-char-set: 204; font-weight: bold; font-size: 12pt; ";
            this.textBox1.Text = "ID";
            this.textBox1.Top = 0.0625F;
            this.textBox1.Width = 0.8267717F;
            // 
            // barcode1
            // 
            this.barcode1.Border.BottomColor = System.Drawing.Color.Black;
            this.barcode1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.barcode1.Border.LeftColor = System.Drawing.Color.Black;
            this.barcode1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.barcode1.Border.RightColor = System.Drawing.Color.Black;
            this.barcode1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.barcode1.Border.TopColor = System.Drawing.Color.Black;
            this.barcode1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.barcode1.CaptionPosition = DataDynamics.ActiveReports.BarCodeCaptionPosition.Below;
            this.barcode1.DataField = "BarCode";
            this.barcode1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.barcode1.Height = 0.7086614F;
            this.barcode1.Left = 0.1875F;
            this.barcode1.Name = "barcode1";
            this.barcode1.Style = DataDynamics.ActiveReports.BarCodeStyle.Code_128auto;
            this.barcode1.Text = "barcode1";
            this.barcode1.Top = 0.0625F;
            this.barcode1.Width = 3.149606F;
            // 
            // label1
            // 
            this.label1.Border.BottomColor = System.Drawing.Color.Black;
            this.label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.LeftColor = System.Drawing.Color.Black;
            this.label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.RightColor = System.Drawing.Color.Black;
            this.label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.TopColor = System.Drawing.Color.Black;
            this.label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Height = 0.1968504F;
            this.label1.HyperLink = null;
            this.label1.Left = 4F;
            this.label1.Name = "label1";
            this.label1.Style = "font-weight: bold; font-size: 12pt; ";
            this.label1.Text = "FrameID: ";
            this.label1.Top = 0.0625F;
            this.label1.Width = 0.8661418F;
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
            this.line1.Left = 0F;
            this.line1.LineWeight = 1F;
            this.line1.Name = "line1";
            this.line1.Top = 0.875F;
            this.line1.Width = 6.3125F;
            this.line1.X1 = 0F;
            this.line1.X2 = 6.3125F;
            this.line1.Y1 = 0.875F;
            this.line1.Y2 = 0.875F;
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
            this.label2.Height = 0.1968504F;
            this.label2.HyperLink = null;
            this.label2.Left = 4F;
            this.label2.Name = "label2";
            this.label2.Style = "ddo-char-set: 1; font-weight: bold; font-size: 11pt; ";
            this.label2.Text = "DateBirth:";
            this.label2.Top = 0.375F;
            this.label2.Width = 0.984252F;
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
            this.textBox2.DataField = "=DateBirth.ToString().Substring(0, 10)";
            this.textBox2.Height = 0.1968504F;
            this.textBox2.Left = 5F;
            this.textBox2.Name = "textBox2";
            this.textBox2.Style = "ddo-char-set: 1; font-weight: bold; font-size: 11pt; ";
            this.textBox2.Text = "DateBirth";
            this.textBox2.Top = 0.375F;
            this.textBox2.Width = 1.417323F;
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
            this.reportInfo1.Left = 5.078741F;
            this.reportInfo1.Name = "reportInfo1";
            this.reportInfo1.Style = "ddo-char-set: 1; text-align: right; font-size: 6pt; ";
            this.reportInfo1.Top = 0.03937008F;
            this.reportInfo1.Width = 1.338583F;
            // 
            // pageFooter
            // 
            this.pageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.reportInfo1});
            this.pageFooter.Height = 0.2291667F;
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
            // repFrameLabel
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
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportInfo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}
		#endregion

		private DataDynamics.ActiveReports.GroupHeader groupHeader1;
		private DataDynamics.ActiveReports.GroupFooter groupFooter1;
		private DataDynamics.ActiveReports.TextBox textBox1;
		private DataDynamics.ActiveReports.Field field1;
		private DataDynamics.ActiveReports.Barcode barcode1;
		private DataDynamics.ActiveReports.Label label1;
		private DataDynamics.ActiveReports.ReportInfo reportInfo1;
		private DataDynamics.ActiveReports.Line line1;
		private DataDynamics.ActiveReports.Label label2;
		private DataDynamics.ActiveReports.TextBox textBox2;

	}
}
