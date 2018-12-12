namespace WMSSuitable
{
	/// <summary>
	/// Summary description for repInventoryEmpty.
	/// </summary>
	partial class repInventoryEmpty
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(repInventoryEmpty));
			this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
			this.reportInfo2 = new DataDynamics.ActiveReports.ReportInfo();
			this.textBox4 = new DataDynamics.ActiveReports.TextBox();
			this.textBox7 = new DataDynamics.ActiveReports.TextBox();
			this.txtDateInventory = new DataDynamics.ActiveReports.TextBox();
			this.line2 = new DataDynamics.ActiveReports.Line();
			this.textBox1 = new DataDynamics.ActiveReports.TextBox();
			this.label1 = new DataDynamics.ActiveReports.Label();
			this.label3 = new DataDynamics.ActiveReports.Label();
			this.line4 = new DataDynamics.ActiveReports.Line();
			this.line3 = new DataDynamics.ActiveReports.Line();
			this.txtBarCode = new DataDynamics.ActiveReports.Barcode();
			this.line5 = new DataDynamics.ActiveReports.Line();
			this.line7 = new DataDynamics.ActiveReports.Line();
			this.line8 = new DataDynamics.ActiveReports.Line();
			this.line9 = new DataDynamics.ActiveReports.Line();
			this.line10 = new DataDynamics.ActiveReports.Line();
			this.line11 = new DataDynamics.ActiveReports.Line();
			this.line12 = new DataDynamics.ActiveReports.Line();
			this.detail = new DataDynamics.ActiveReports.Detail();
			this.reportInfo1 = new DataDynamics.ActiveReports.ReportInfo();
			this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
			((System.ComponentModel.ISupportInitialize)(this.reportInfo2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDateInventory)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.reportInfo1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// pageHeader
			// 
			this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.reportInfo2,
            this.textBox4,
            this.textBox7,
            this.txtDateInventory,
            this.line2,
            this.textBox1,
            this.label1,
            this.label3,
            this.line4,
            this.line3,
            this.txtBarCode,
            this.line5,
            this.line7,
            this.line8,
            this.line9,
            this.line10,
            this.line11,
            this.line12});
			this.pageHeader.Height = 9.875F;
			this.pageHeader.Name = "pageHeader";
			this.pageHeader.Format += new System.EventHandler(this.pageHeader_Format);
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
			this.textBox4.Left = 0.03937008F;
			this.textBox4.Name = "textBox4";
			this.textBox4.Style = "font-weight: bold; font-size: 14.25pt; font-family: Tahoma; ";
			this.textBox4.Text = "Инвентаризация ячеек";
			this.textBox4.Top = 0.2362205F;
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
			this.textBox7.Left = 2.480315F;
			this.textBox7.Name = "textBox7";
			this.textBox7.Style = "font-weight: bold; font-size: 14.25pt; font-family: Tahoma; ";
			this.textBox7.Text = "InventoryID";
			this.textBox7.Top = 0.2362205F;
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
			this.txtDateInventory.Left = 2.480315F;
			this.txtDateInventory.Name = "txtDateInventory";
			this.txtDateInventory.Style = "font-weight: bold; font-size: 14.25pt; font-family: Tahoma; ";
			this.txtDateInventory.Text = "DateInventory";
			this.txtDateInventory.Top = 0.511811F;
			this.txtDateInventory.Width = 1.496063F;
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
			this.line2.Top = 1.338583F;
			this.line2.Width = 7.401575F;
			this.line2.X1 = 0.03937008F;
			this.line2.X2 = 7.440945F;
			this.line2.Y1 = 1.338583F;
			this.line2.Y2 = 1.338583F;
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
			this.textBox1.Left = 0.03937008F;
			this.textBox1.Name = "textBox1";
			this.textBox1.Style = "";
			this.textBox1.Text = "Note";
			this.textBox1.Top = 0.9055119F;
			this.textBox1.Width = 7.283465F;
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
			this.label1.Left = 0.07874016F;
			this.label1.Name = "label1";
			this.label1.Style = "";
			this.label1.Text = "Ячейка";
			this.label1.Top = 1.377953F;
			this.label1.Width = 0.8267717F;
			// 
			// label3
			// 
			this.label3.Border.BottomColor = System.Drawing.Color.Black;
			this.label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.label3.Border.LeftColor = System.Drawing.Color.Black;
			this.label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.label3.Border.RightColor = System.Drawing.Color.Black;
			this.label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.label3.Border.TopColor = System.Drawing.Color.Black;
			this.label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.label3.Height = 0.1968504F;
			this.label3.HyperLink = null;
			this.label3.Left = 1.259843F;
			this.label3.Name = "label3";
			this.label3.Style = "";
			this.label3.Text = "Проблема";
			this.label3.Top = 1.377953F;
			this.label3.Width = 0.8267717F;
			// 
			// line4
			// 
			this.line4.Border.BottomColor = System.Drawing.Color.Black;
			this.line4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.line4.Border.LeftColor = System.Drawing.Color.Black;
			this.line4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.line4.Border.RightColor = System.Drawing.Color.Black;
			this.line4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.line4.Border.TopColor = System.Drawing.Color.Black;
			this.line4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.line4.Height = 0F;
			this.line4.Left = 0.03937008F;
			this.line4.LineWeight = 1F;
			this.line4.Name = "line4";
			this.line4.Top = 1.574803F;
			this.line4.Width = 7.401575F;
			this.line4.X1 = 0.03937008F;
			this.line4.X2 = 7.440945F;
			this.line4.Y1 = 1.574803F;
			this.line4.Y2 = 1.574803F;
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
			this.line3.Height = 8.503937F;
			this.line3.Left = 1.181102F;
			this.line3.LineWeight = 1F;
			this.line3.Name = "line3";
			this.line3.Top = 1.338583F;
			this.line3.Width = 0F;
			this.line3.X1 = 1.181102F;
			this.line3.X2 = 1.181102F;
			this.line3.Y1 = 1.338583F;
			this.line3.Y2 = 9.84252F;
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
			this.txtBarCode.Left = 4.606299F;
			this.txtBarCode.Name = "txtBarCode";
			this.txtBarCode.Style = DataDynamics.ActiveReports.BarCodeStyle.EAN128FNC1;
			this.txtBarCode.Text = "BarCode";
			this.txtBarCode.Top = 0.2362205F;
			this.txtBarCode.Width = 2.834646F;
			// 
			// line5
			// 
			this.line5.Border.BottomColor = System.Drawing.Color.Black;
			this.line5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.line5.Border.LeftColor = System.Drawing.Color.Black;
			this.line5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.line5.Border.RightColor = System.Drawing.Color.Black;
			this.line5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.line5.Border.TopColor = System.Drawing.Color.Black;
			this.line5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.line5.Height = 0F;
			this.line5.Left = 0.03937008F;
			this.line5.LineStyle = DataDynamics.ActiveReports.LineStyle.Dash;
			this.line5.LineWeight = 1F;
			this.line5.Name = "line5";
			this.line5.Top = 2.755905F;
			this.line5.Width = 7.401575F;
			this.line5.X1 = 0.03937008F;
			this.line5.X2 = 7.440945F;
			this.line5.Y1 = 2.755905F;
			this.line5.Y2 = 2.755905F;
			// 
			// line7
			// 
			this.line7.Border.BottomColor = System.Drawing.Color.Black;
			this.line7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.line7.Border.LeftColor = System.Drawing.Color.Black;
			this.line7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.line7.Border.RightColor = System.Drawing.Color.Black;
			this.line7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.line7.Border.TopColor = System.Drawing.Color.Black;
			this.line7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.line7.Height = 0F;
			this.line7.Left = 0.03937008F;
			this.line7.LineStyle = DataDynamics.ActiveReports.LineStyle.Dash;
			this.line7.LineWeight = 1F;
			this.line7.Name = "line7";
			this.line7.Top = 3.937008F;
			this.line7.Width = 7.401575F;
			this.line7.X1 = 0.03937008F;
			this.line7.X2 = 7.440945F;
			this.line7.Y1 = 3.937008F;
			this.line7.Y2 = 3.937008F;
			// 
			// line8
			// 
			this.line8.Border.BottomColor = System.Drawing.Color.Black;
			this.line8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.line8.Border.LeftColor = System.Drawing.Color.Black;
			this.line8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.line8.Border.RightColor = System.Drawing.Color.Black;
			this.line8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.line8.Border.TopColor = System.Drawing.Color.Black;
			this.line8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.line8.Height = 0F;
			this.line8.Left = 0.03937008F;
			this.line8.LineStyle = DataDynamics.ActiveReports.LineStyle.Dash;
			this.line8.LineWeight = 1F;
			this.line8.Name = "line8";
			this.line8.Top = 5.11811F;
			this.line8.Width = 7.401575F;
			this.line8.X1 = 0.03937008F;
			this.line8.X2 = 7.440945F;
			this.line8.Y1 = 5.11811F;
			this.line8.Y2 = 5.11811F;
			// 
			// line9
			// 
			this.line9.Border.BottomColor = System.Drawing.Color.Black;
			this.line9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.line9.Border.LeftColor = System.Drawing.Color.Black;
			this.line9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.line9.Border.RightColor = System.Drawing.Color.Black;
			this.line9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.line9.Border.TopColor = System.Drawing.Color.Black;
			this.line9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.line9.Height = 0F;
			this.line9.Left = 0.03937008F;
			this.line9.LineStyle = DataDynamics.ActiveReports.LineStyle.Dash;
			this.line9.LineWeight = 1F;
			this.line9.Name = "line9";
			this.line9.Top = 6.299213F;
			this.line9.Width = 7.401575F;
			this.line9.X1 = 0.03937008F;
			this.line9.X2 = 7.440945F;
			this.line9.Y1 = 6.299213F;
			this.line9.Y2 = 6.299213F;
			// 
			// line10
			// 
			this.line10.Border.BottomColor = System.Drawing.Color.Black;
			this.line10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.line10.Border.LeftColor = System.Drawing.Color.Black;
			this.line10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.line10.Border.RightColor = System.Drawing.Color.Black;
			this.line10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.line10.Border.TopColor = System.Drawing.Color.Black;
			this.line10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.line10.Height = 0F;
			this.line10.Left = 0.03937008F;
			this.line10.LineStyle = DataDynamics.ActiveReports.LineStyle.Dash;
			this.line10.LineWeight = 1F;
			this.line10.Name = "line10";
			this.line10.Top = 7.480315F;
			this.line10.Width = 7.401575F;
			this.line10.X1 = 0.03937008F;
			this.line10.X2 = 7.440945F;
			this.line10.Y1 = 7.480315F;
			this.line10.Y2 = 7.480315F;
			// 
			// line11
			// 
			this.line11.Border.BottomColor = System.Drawing.Color.Black;
			this.line11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.line11.Border.LeftColor = System.Drawing.Color.Black;
			this.line11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.line11.Border.RightColor = System.Drawing.Color.Black;
			this.line11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.line11.Border.TopColor = System.Drawing.Color.Black;
			this.line11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.line11.Height = 0F;
			this.line11.Left = 0.03937008F;
			this.line11.LineStyle = DataDynamics.ActiveReports.LineStyle.Dash;
			this.line11.LineWeight = 1F;
			this.line11.Name = "line11";
			this.line11.Top = 8.661418F;
			this.line11.Width = 7.401575F;
			this.line11.X1 = 0.03937008F;
			this.line11.X2 = 7.440945F;
			this.line11.Y1 = 8.661418F;
			this.line11.Y2 = 8.661418F;
			// 
			// line12
			// 
			this.line12.Border.BottomColor = System.Drawing.Color.Black;
			this.line12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.line12.Border.LeftColor = System.Drawing.Color.Black;
			this.line12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.line12.Border.RightColor = System.Drawing.Color.Black;
			this.line12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.line12.Border.TopColor = System.Drawing.Color.Black;
			this.line12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.line12.Height = 0F;
			this.line12.Left = 0.03937008F;
			this.line12.LineStyle = DataDynamics.ActiveReports.LineStyle.Dash;
			this.line12.LineWeight = 1F;
			this.line12.Name = "line12";
			this.line12.Top = 9.84252F;
			this.line12.Width = 7.401575F;
			this.line12.X1 = 0.03937008F;
			this.line12.X2 = 7.440945F;
			this.line12.Y1 = 9.84252F;
			this.line12.Y2 = 9.84252F;
			// 
			// detail
			// 
			this.detail.ColumnSpacing = 0F;
			this.detail.Height = 0.03125F;
			this.detail.KeepTogether = true;
			this.detail.Name = "detail";
			this.detail.NewPage = DataDynamics.ActiveReports.NewPage.Before;
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
			// repInventoryEmpty
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
			this.Sections.Add(this.detail);
			this.Sections.Add(this.pageFooter);
			this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-style: normal; text-decoration: none; font-weight: normal; font-size: 10pt; " +
						"color: Black; font-family: \"Tahoma\"; ddo-char-set: 204; ", "Normal"));
			this.StyleSheet.Add(new DDCssLib.StyleSheetRule("ddo-char-set: 204; font-size: 12pt; font-weight: bold; ", "Heading1", "Normal"));
			this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
						"lic; ddo-char-set: 204; ", "Heading2", "Normal"));
			this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ddo-char-set: 204; ", "Heading3", "Normal"));
			this.FetchData += new DataDynamics.ActiveReports.ActiveReport3.FetchEventHandler(this.repInventoryEmpty_FetchData);
			((System.ComponentModel.ISupportInitialize)(this.reportInfo2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDateInventory)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.reportInfo1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}
		#endregion

		private DataDynamics.ActiveReports.ReportInfo reportInfo1;
		private DataDynamics.ActiveReports.ReportInfo reportInfo2;
		private DataDynamics.ActiveReports.TextBox textBox4;
		private DataDynamics.ActiveReports.TextBox textBox7;
		private DataDynamics.ActiveReports.TextBox txtDateInventory;
		private DataDynamics.ActiveReports.Line line2;
		private DataDynamics.ActiveReports.TextBox textBox1;
		private DataDynamics.ActiveReports.Label label1;
		private DataDynamics.ActiveReports.Label label3;
		private DataDynamics.ActiveReports.Line line4;
		private DataDynamics.ActiveReports.Line line3;
		private DataDynamics.ActiveReports.Barcode txtBarCode;
		private DataDynamics.ActiveReports.Line line5;
		private DataDynamics.ActiveReports.Line line7;
		private DataDynamics.ActiveReports.Line line8;
		private DataDynamics.ActiveReports.Line line9;
		private DataDynamics.ActiveReports.Line line10;
		private DataDynamics.ActiveReports.Line line11;
		private DataDynamics.ActiveReports.Line line12;

	}
}
