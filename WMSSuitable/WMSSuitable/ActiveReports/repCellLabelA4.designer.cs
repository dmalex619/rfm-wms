namespace WMSSuitable
{
	/// <summary>
	/// Summary description for repCellLabelA4.
	/// </summary>
	partial class repCellLabelA4
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(repCellLabelA4));
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.barcode1 = new DataDynamics.ActiveReports.Barcode();
            this.Address = new DataDynamics.ActiveReports.TextBox();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            this.field1 = new DataDynamics.ActiveReports.Field();
            ((System.ComponentModel.ISupportInitialize)(this.Address)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Height = 0.1968504F;
            this.pageHeader.Name = "pageHeader";
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.barcode1,
            this.Address});
            this.detail.Height = 6.510417F;
            this.detail.KeepTogether = true;
            this.detail.Name = "detail";
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
            this.barcode1.Font = new System.Drawing.Font("Tahoma", 42F, System.Drawing.FontStyle.Bold);
            this.barcode1.Height = 4.133858F;
            this.barcode1.Left = 1.205709F;
            this.barcode1.Name = "barcode1";
            this.barcode1.Style = DataDynamics.ActiveReports.BarCodeStyle.Code_128auto;
            this.barcode1.Text = "barcode1";
            this.barcode1.Top = 2.214567F;
            this.barcode1.Width = 8.489173F;
            // 
            // Address
            // 
            this.Address.Border.BottomColor = System.Drawing.Color.Black;
            this.Address.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Address.Border.LeftColor = System.Drawing.Color.Black;
            this.Address.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Address.Border.RightColor = System.Drawing.Color.Black;
            this.Address.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Address.Border.TopColor = System.Drawing.Color.Black;
            this.Address.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Address.DataField = "Address";
            this.Address.Height = 1.624016F;
            this.Address.Left = 1.205709F;
            this.Address.Name = "Address";
            this.Address.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 96pt; ";
            this.Address.Text = "Address";
            this.Address.Top = 0.4183071F;
            this.Address.Width = 8.489173F;
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0.1968504F;
            this.pageFooter.Name = "pageFooter";
            // 
            // groupHeader1
            // 
            this.groupHeader1.Height = 0.1968504F;
            this.groupHeader1.Name = "groupHeader1";
            // 
            // groupFooter1
            // 
            this.groupFooter1.Height = 0.1968504F;
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
            // repCellLabelA4
            // 
            this.CalculatedFields.Add(this.field1);
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.Margins.Bottom = 0.3937008F;
            this.PageSettings.Margins.Left = 0.3937008F;
            this.PageSettings.Margins.Right = 0.3897638F;
            this.PageSettings.Margins.Top = 0.3937008F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;
            this.PageSettings.PaperHeight = 11.69291F;
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.PaperWidth = 8.267716F;
            this.PrintWidth = 10.7874F;
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
            ((System.ComponentModel.ISupportInitialize)(this.Address)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}
		#endregion

		private DataDynamics.ActiveReports.GroupHeader groupHeader1;
        private DataDynamics.ActiveReports.GroupFooter groupFooter1;
		private DataDynamics.ActiveReports.Field field1;
        private DataDynamics.ActiveReports.Barcode barcode1;
        private DataDynamics.ActiveReports.TextBox Address;

	}
}
