namespace WMSSuitable
{
	/// <summary>
	/// Summary description for repInventoryBillBlank.
	/// </summary>
	partial class repInventoryBillBlank
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(repInventoryBillBlank));
			this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
			this.reportInfo2 = new DataDynamics.ActiveReports.ReportInfo();
			this.detail = new DataDynamics.ActiveReports.Detail();
			this.line1 = new DataDynamics.ActiveReports.Line();
			this.txtCellBarCode = new DataDynamics.ActiveReports.Barcode();
			this.Address = new DataDynamics.ActiveReports.TextBox();
			this.shape1 = new DataDynamics.ActiveReports.Shape();
			this.shape2 = new DataDynamics.ActiveReports.Shape();
			this.reportInfo1 = new DataDynamics.ActiveReports.ReportInfo();
			this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
			this.groupHeaderStoreZoneID = new DataDynamics.ActiveReports.GroupHeader();
			this.line3 = new DataDynamics.ActiveReports.Line();
			this.textBox5 = new DataDynamics.ActiveReports.TextBox();
			this.groupFooterStoreZoneName = new DataDynamics.ActiveReports.GroupFooter();
			this.line2 = new DataDynamics.ActiveReports.Line();
			this.textBox4 = new DataDynamics.ActiveReports.TextBox();
			this.textBox7 = new DataDynamics.ActiveReports.TextBox();
			this.txtDateInventory = new DataDynamics.ActiveReports.TextBox();
			this.txtBarCode = new DataDynamics.ActiveReports.Barcode();
			this.groupHeaderAll = new DataDynamics.ActiveReports.GroupHeader();
			this.textBox1 = new DataDynamics.ActiveReports.TextBox();
			this.groupFooterAll = new DataDynamics.ActiveReports.GroupFooter();
			((System.ComponentModel.ISupportInitialize)(this.reportInfo2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Address)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.reportInfo1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDateInventory)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// pageHeader
			// 
			this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.reportInfo2});
			this.pageHeader.Height = 0.1979167F;
			this.pageHeader.Name = "pageHeader";
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
			this.reportInfo2.FormatString = "Стр. {PageNumber} из {PageCount}";
			this.reportInfo2.Height = 0.1574803F;
			this.reportInfo2.Left = 6.220472F;
			this.reportInfo2.Name = "reportInfo2";
			this.reportInfo2.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: Tahoma; ";
			this.reportInfo2.Top = 0.03937008F;
			this.reportInfo2.Width = 1.181103F;
			// 
			// detail
			// 
			this.detail.ColumnSpacing = 0F;
			this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line1,
            this.txtCellBarCode,
            this.Address,
            this.shape1,
            this.shape2});
			this.detail.Height = 1.1875F;
			this.detail.KeepTogether = true;
			this.detail.Name = "detail";
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
			this.line1.LineStyle = DataDynamics.ActiveReports.LineStyle.Dot;
			this.line1.LineWeight = 1F;
			this.line1.Name = "line1";
			this.line1.Top = 1.181102F;
			this.line1.Width = 7.401575F;
			this.line1.X1 = 0.03937008F;
			this.line1.X2 = 7.440945F;
			this.line1.Y1 = 1.181102F;
			this.line1.Y2 = 1.181102F;
			// 
			// txtCellBarCode
			// 
			this.txtCellBarCode.Border.BottomColor = System.Drawing.Color.Black;
			this.txtCellBarCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.txtCellBarCode.Border.LeftColor = System.Drawing.Color.Black;
			this.txtCellBarCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.txtCellBarCode.Border.RightColor = System.Drawing.Color.Black;
			this.txtCellBarCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.txtCellBarCode.Border.TopColor = System.Drawing.Color.Black;
			this.txtCellBarCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.txtCellBarCode.CaptionPosition = DataDynamics.ActiveReports.BarCodeCaptionPosition.Below;
			this.txtCellBarCode.DataField = "CellBarCode";
			this.txtCellBarCode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.txtCellBarCode.Height = 0.658F;
			this.txtCellBarCode.Left = 0.07874016F;
			this.txtCellBarCode.Name = "txtCellBarCode";
			this.txtCellBarCode.Style = DataDynamics.ActiveReports.BarCodeStyle.EAN128FNC1;
			this.txtCellBarCode.Text = "CellBarCode";
			this.txtCellBarCode.Top = 0.07874016F;
			this.txtCellBarCode.Width = 2.834646F;
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
			this.Address.Height = 0.2755906F;
			this.Address.Left = 0.1574803F;
			this.Address.Name = "Address";
			this.Address.Style = "ddo-char-set: 204; text-align: left; font-weight: bold; font-size: 14.25pt; font-" +
				"family: Tahoma; ";
			this.Address.Text = "Address";
			this.Address.Top = 0.7874016F;
			this.Address.Width = 2.165354F;
			// 
			// shape1
			// 
			this.shape1.Border.BottomColor = System.Drawing.Color.Black;
			this.shape1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.shape1.Border.LeftColor = System.Drawing.Color.Black;
			this.shape1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.shape1.Border.RightColor = System.Drawing.Color.Black;
			this.shape1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.shape1.Border.TopColor = System.Drawing.Color.Black;
			this.shape1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.shape1.Height = 0.3937008F;
			this.shape1.Left = 2.440945F;
			this.shape1.LineWeight = 3F;
			this.shape1.Name = "shape1";
			this.shape1.RoundingRadius = 9.999999F;
			this.shape1.Top = 0.7086614F;
			this.shape1.Width = 0.4330709F;
			// 
			// shape2
			// 
			this.shape2.Border.BottomColor = System.Drawing.Color.Black;
			this.shape2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.shape2.Border.LeftColor = System.Drawing.Color.Black;
			this.shape2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.shape2.Border.RightColor = System.Drawing.Color.Black;
			this.shape2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.shape2.Border.TopColor = System.Drawing.Color.Black;
			this.shape2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.shape2.Height = 1.181102F;
			this.shape2.Left = 3.110236F;
			this.shape2.Name = "shape2";
			this.shape2.RoundingRadius = 9.999999F;
			this.shape2.Top = 0F;
			this.shape2.Width = 4.251969F;
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
			this.reportInfo1.Left = 6.062992F;
			this.reportInfo1.Name = "reportInfo1";
			this.reportInfo1.Style = "ddo-char-set: 1; text-align: right; font-size: 6pt; ";
			this.reportInfo1.Top = 0.03937008F;
			this.reportInfo1.Width = 1.338583F;
			// 
			// pageFooter
			// 
			this.pageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.reportInfo1});
			this.pageFooter.Height = 0.1875F;
			this.pageFooter.Name = "pageFooter";
			// 
			// groupHeaderStoreZoneID
			// 
			this.groupHeaderStoreZoneID.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line3,
            this.textBox5});
			this.groupHeaderStoreZoneID.DataField = "StoreZoneID";
			this.groupHeaderStoreZoneID.Height = 0.2916667F;
			this.groupHeaderStoreZoneID.Name = "groupHeaderStoreZoneID";
			// 
			// line3
			// 
			this.line3.Border.BottomColor = System.Drawing.Color.Black;
			this.line3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.line3.Border.LeftColor = System.Drawing.Color.Black;
			this.line3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.line3.Border.RightColor = System.Drawing.Color.Black;
			this.line3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.line3.Border.TopColor = System.Drawing.Color.Black;
			this.line3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.line3.Height = 0F;
			this.line3.Left = 0.03937008F;
			this.line3.LineWeight = 1F;
			this.line3.Name = "line3";
			this.line3.Top = 0.2755906F;
			this.line3.Width = 7.401575F;
			this.line3.X1 = 0.03937008F;
			this.line3.X2 = 7.440945F;
			this.line3.Y1 = 0.2755906F;
			this.line3.Y2 = 0.2755906F;
			// 
			// textBox5
			// 
			this.textBox5.Border.BottomColor = System.Drawing.Color.Black;
			this.textBox5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.textBox5.Border.LeftColor = System.Drawing.Color.Black;
			this.textBox5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.textBox5.Border.RightColor = System.Drawing.Color.Black;
			this.textBox5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.textBox5.Border.TopColor = System.Drawing.Color.Black;
			this.textBox5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.textBox5.DataField = "StoreZoneName";
			this.textBox5.Height = 0.2362205F;
			this.textBox5.Left = 0.07874016F;
			this.textBox5.Name = "textBox5";
			this.textBox5.Style = "font-weight: bold; font-style: italic; font-size: 14.25pt; font-family: Tahoma; ";
			this.textBox5.Text = "StoreZoneName";
			this.textBox5.Top = 0F;
			this.textBox5.Width = 3.110236F;
			// 
			// groupFooterStoreZoneName
			// 
			this.groupFooterStoreZoneName.Height = 0.01041667F;
			this.groupFooterStoreZoneName.Name = "groupFooterStoreZoneName";
			// 
			// line2
			// 
			this.line2.Border.BottomColor = System.Drawing.Color.Black;
			this.line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.line2.Border.LeftColor = System.Drawing.Color.Black;
			this.line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.line2.Border.RightColor = System.Drawing.Color.Black;
			this.line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.line2.Border.TopColor = System.Drawing.Color.Black;
			this.line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.line2.Height = 0F;
			this.line2.Left = 0.03937008F;
			this.line2.LineWeight = 1F;
			this.line2.Name = "line2";
			this.line2.Top = 1.102362F;
			this.line2.Width = 7.401575F;
			this.line2.X1 = 0.03937008F;
			this.line2.X2 = 7.440945F;
			this.line2.Y1 = 1.102362F;
			this.line2.Y2 = 1.102362F;
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
			this.textBox4.Height = 0.2362205F;
			this.textBox4.Left = 0.07874016F;
			this.textBox4.Name = "textBox4";
			this.textBox4.Style = "font-weight: bold; font-size: 14.25pt; font-family: Tahoma; ";
			this.textBox4.Text = "Инвентаризация ячеек";
			this.textBox4.Top = 0.03937008F;
			this.textBox4.Width = 2.440945F;
			// 
			// textBox7
			// 
			this.textBox7.Border.BottomColor = System.Drawing.Color.Black;
			this.textBox7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.textBox7.Border.LeftColor = System.Drawing.Color.Black;
			this.textBox7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.textBox7.Border.RightColor = System.Drawing.Color.Black;
			this.textBox7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.textBox7.Border.TopColor = System.Drawing.Color.Black;
			this.textBox7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.textBox7.DataField = "InventoryID";
			this.textBox7.Height = 0.2362205F;
			this.textBox7.Left = 2.519685F;
			this.textBox7.Name = "textBox7";
			this.textBox7.Style = "font-weight: bold; font-size: 14.25pt; font-family: Tahoma; ";
			this.textBox7.Text = "InventoryID";
			this.textBox7.Top = 0.03937008F;
			this.textBox7.Width = 1.496063F;
			// 
			// txtDateInventory
			// 
			this.txtDateInventory.Border.BottomColor = System.Drawing.Color.Black;
			this.txtDateInventory.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.txtDateInventory.Border.LeftColor = System.Drawing.Color.Black;
			this.txtDateInventory.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.txtDateInventory.Border.RightColor = System.Drawing.Color.Black;
			this.txtDateInventory.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.txtDateInventory.Border.TopColor = System.Drawing.Color.Black;
			this.txtDateInventory.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.txtDateInventory.Height = 0.2362205F;
			this.txtDateInventory.Left = 2.519685F;
			this.txtDateInventory.Name = "txtDateInventory";
			this.txtDateInventory.Style = "font-weight: bold; font-size: 14.25pt; font-family: Tahoma; ";
			this.txtDateInventory.Text = "DateInventory";
			this.txtDateInventory.Top = 0.2755906F;
			this.txtDateInventory.Width = 1.496063F;
			// 
			// txtBarCode
			// 
			this.txtBarCode.Border.BottomColor = System.Drawing.Color.Black;
			this.txtBarCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.txtBarCode.Border.LeftColor = System.Drawing.Color.Black;
			this.txtBarCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.txtBarCode.Border.RightColor = System.Drawing.Color.Black;
			this.txtBarCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.txtBarCode.Border.TopColor = System.Drawing.Color.Black;
			this.txtBarCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.txtBarCode.CaptionPosition = DataDynamics.ActiveReports.BarCodeCaptionPosition.Below;
			this.txtBarCode.DataField = "BarCode";
			this.txtBarCode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.txtBarCode.Height = 0.658F;
			this.txtBarCode.Left = 4.488189F;
			this.txtBarCode.Name = "txtBarCode";
			this.txtBarCode.Style = DataDynamics.ActiveReports.BarCodeStyle.EAN128FNC1;
			this.txtBarCode.Text = "BarCode";
			this.txtBarCode.Top = 0F;
			this.txtBarCode.Width = 2.834646F;
			// 
			// groupHeaderAll
			// 
			this.groupHeaderAll.CanShrink = true;
			this.groupHeaderAll.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox4,
            this.textBox7,
            this.txtDateInventory,
            this.txtBarCode,
            this.line2,
            this.textBox1});
			this.groupHeaderAll.Height = 1.145833F;
			this.groupHeaderAll.Name = "groupHeaderAll";
			this.groupHeaderAll.Format += new System.EventHandler(this.groupHeaderAll_Format);
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
			this.textBox1.CanShrink = true;
			this.textBox1.DataField = "Note";
			this.textBox1.Height = 0.3937008F;
			this.textBox1.Left = 0.07874016F;
			this.textBox1.Name = "textBox1";
			this.textBox1.Style = "";
			this.textBox1.Text = "Note";
			this.textBox1.Top = 0.6692913F;
			this.textBox1.Width = 7.283465F;
			// 
			// groupFooterAll
			// 
			this.groupFooterAll.Height = 0.01041667F;
			this.groupFooterAll.Name = "groupFooterAll";
			// 
			// repInventoryBillBlank
			// 
			this.PageSettings.DefaultPaperSize = false;
			this.PageSettings.Margins.Bottom = 0.3937008F;
			this.PageSettings.Margins.Left = 0.3937008F;
			this.PageSettings.Margins.Right = 0.3897638F;
			this.PageSettings.Margins.Top = 0.3937008F;
			this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait;
			this.PageSettings.PaperHeight = 11.69291F;
			this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
			this.PageSettings.PaperWidth = 8.267716F;
			this.PrintWidth = 7.480315F;
			this.Sections.Add(this.pageHeader);
			this.Sections.Add(this.groupHeaderAll);
			this.Sections.Add(this.groupHeaderStoreZoneID);
			this.Sections.Add(this.detail);
			this.Sections.Add(this.groupFooterStoreZoneName);
			this.Sections.Add(this.groupFooterAll);
			this.Sections.Add(this.pageFooter);
			this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-style: normal; text-decoration: none; font-weight: normal; font-size: 10pt; " +
						"color: Black; font-family: \"Tahoma\"; ddo-char-set: 204; ", "Normal"));
			this.StyleSheet.Add(new DDCssLib.StyleSheetRule("ddo-char-set: 204; font-size: 12pt; font-weight: bold; ", "Heading1", "Normal"));
			this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
						"lic; ddo-char-set: 204; ", "Heading2", "Normal"));
			this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ddo-char-set: 204; ", "Heading3", "Normal"));
			((System.ComponentModel.ISupportInitialize)(this.reportInfo2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Address)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.reportInfo1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDateInventory)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}
		#endregion

		private DataDynamics.ActiveReports.GroupHeader groupHeaderStoreZoneID;
		private DataDynamics.ActiveReports.GroupFooter groupFooterStoreZoneName;
		private DataDynamics.ActiveReports.ReportInfo reportInfo1;
		private DataDynamics.ActiveReports.Line line1;
		private DataDynamics.ActiveReports.ReportInfo reportInfo2;
		private DataDynamics.ActiveReports.Line line2;
		private DataDynamics.ActiveReports.Line line3;
		private DataDynamics.ActiveReports.TextBox textBox4;
		private DataDynamics.ActiveReports.TextBox textBox7;
		private DataDynamics.ActiveReports.TextBox txtDateInventory;
		private DataDynamics.ActiveReports.Barcode txtBarCode;
		private DataDynamics.ActiveReports.TextBox textBox5;
		private DataDynamics.ActiveReports.Barcode txtCellBarCode;
		private DataDynamics.ActiveReports.TextBox Address;
		private DataDynamics.ActiveReports.Shape shape1;
		private DataDynamics.ActiveReports.Shape shape2;
		private DataDynamics.ActiveReports.GroupHeader groupHeaderAll;
		private DataDynamics.ActiveReports.GroupFooter groupFooterAll;
		private DataDynamics.ActiveReports.TextBox textBox1;

	}
}
