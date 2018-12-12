namespace WMSSuitable
{
	/// <summary>
	/// Summary description for repInventoryBillContents.
	/// </summary>
	partial class repInventoryBillContents
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(repInventoryBillContents));
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.reportInfo2 = new DataDynamics.ActiveReports.ReportInfo();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.Address = new DataDynamics.ActiveReports.TextBox();
            this.tbPackingAlias = new DataDynamics.ActiveReports.TextBox();
            this.textBox13 = new DataDynamics.ActiveReports.TextBox();
            this.tbGoodStateName = new DataDynamics.ActiveReports.TextBox();
            this.tbOwnerName = new DataDynamics.ActiveReports.TextBox();
            this.tbGoodArticul = new DataDynamics.ActiveReports.TextBox();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.label4 = new DataDynamics.ActiveReports.Label();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.textBox24 = new DataDynamics.ActiveReports.TextBox();
            this.reportInfo1 = new DataDynamics.ActiveReports.ReportInfo();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.groupHeaderStoreZoneID = new DataDynamics.ActiveReports.GroupHeader();
            this.textBox9 = new DataDynamics.ActiveReports.TextBox();
            this.textBox5 = new DataDynamics.ActiveReports.TextBox();
            this.textBox3 = new DataDynamics.ActiveReports.TextBox();
            this.textBox6 = new DataDynamics.ActiveReports.TextBox();
            this.textBox11 = new DataDynamics.ActiveReports.TextBox();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.line1 = new DataDynamics.ActiveReports.Line();
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
            ((System.ComponentModel.ISupportInitialize)(this.tbPackingAlias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGoodStateName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbOwnerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGoodArticul)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportInfo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
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
            this.detail.CanShrink = true;
            this.detail.ColumnSpacing = 0F;
            this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Address,
            this.tbPackingAlias,
            this.textBox13,
            this.tbGoodStateName,
            this.tbOwnerName,
            this.tbGoodArticul,
            this.line4});
            this.detail.Height = 0.25F;
            this.detail.KeepTogether = true;
            this.detail.Name = "detail";
            this.detail.Format += new System.EventHandler(this.detail_Format);
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
            this.Address.Height = 0.1968504F;
            this.Address.Left = 0.03937008F;
            this.Address.Name = "Address";
            this.Address.Style = "ddo-char-set: 204; text-align: left; font-weight: bold; font-size: 12pt; font-fam" +
                "ily: Tahoma; ";
            this.Address.Text = "Address";
            this.Address.Top = 0F;
            this.Address.Width = 1.023622F;
            // 
            // tbPackingAlias
            // 
            this.tbPackingAlias.Border.BottomColor = System.Drawing.Color.Black;
            this.tbPackingAlias.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tbPackingAlias.Border.LeftColor = System.Drawing.Color.Black;
            this.tbPackingAlias.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tbPackingAlias.Border.RightColor = System.Drawing.Color.Black;
            this.tbPackingAlias.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tbPackingAlias.Border.TopColor = System.Drawing.Color.Black;
            this.tbPackingAlias.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tbPackingAlias.CanShrink = true;
            this.tbPackingAlias.Height = 0.1574803F;
            this.tbPackingAlias.Left = 3.110236F;
            this.tbPackingAlias.Name = "tbPackingAlias";
            this.tbPackingAlias.Style = "font-size: 9.75pt; ";
            this.tbPackingAlias.Text = "PackingAlias";
            this.tbPackingAlias.Top = 0.03937008F;
            this.tbPackingAlias.Width = 3.188977F;
            // 
            // textBox13
            // 
            this.textBox13.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox13.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox13.Border.RightColor = System.Drawing.Color.Black;
            this.textBox13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox13.Border.TopColor = System.Drawing.Color.Black;
            this.textBox13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox13.CanShrink = true;
            this.textBox13.DataField = "FrameID";
            this.textBox13.Height = 0.1574803F;
            this.textBox13.Left = 1.023622F;
            this.textBox13.Name = "textBox13";
            this.textBox13.Style = "text-align: center; font-size: 8.25pt; ";
            this.textBox13.Text = "FrameID";
            this.textBox13.Top = 0.03937008F;
            this.textBox13.Width = 0.5511811F;
            // 
            // tbGoodStateName
            // 
            this.tbGoodStateName.Border.BottomColor = System.Drawing.Color.Black;
            this.tbGoodStateName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tbGoodStateName.Border.LeftColor = System.Drawing.Color.Black;
            this.tbGoodStateName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tbGoodStateName.Border.RightColor = System.Drawing.Color.Black;
            this.tbGoodStateName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tbGoodStateName.Border.TopColor = System.Drawing.Color.Black;
            this.tbGoodStateName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tbGoodStateName.CanShrink = true;
            this.tbGoodStateName.Height = 0.1181102F;
            this.tbGoodStateName.Left = 1.574803F;
            this.tbGoodStateName.Name = "tbGoodStateName";
            this.tbGoodStateName.Style = "text-align: left; font-size: 6pt; ";
            this.tbGoodStateName.Text = "GoodStateName";
            this.tbGoodStateName.Top = 0F;
            this.tbGoodStateName.Width = 0.6692913F;
            // 
            // tbOwnerName
            // 
            this.tbOwnerName.Border.BottomColor = System.Drawing.Color.Black;
            this.tbOwnerName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tbOwnerName.Border.LeftColor = System.Drawing.Color.Black;
            this.tbOwnerName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tbOwnerName.Border.RightColor = System.Drawing.Color.Black;
            this.tbOwnerName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tbOwnerName.Border.TopColor = System.Drawing.Color.Black;
            this.tbOwnerName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tbOwnerName.CanShrink = true;
            this.tbOwnerName.Height = 0.1181102F;
            this.tbOwnerName.Left = 1.574803F;
            this.tbOwnerName.Name = "tbOwnerName";
            this.tbOwnerName.Style = "text-align: left; font-size: 6pt; ";
            this.tbOwnerName.Text = "OwnerName";
            this.tbOwnerName.Top = 0.1181102F;
            this.tbOwnerName.Width = 0.6692913F;
            // 
            // tbGoodArticul
            // 
            this.tbGoodArticul.Border.BottomColor = System.Drawing.Color.Black;
            this.tbGoodArticul.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tbGoodArticul.Border.LeftColor = System.Drawing.Color.Black;
            this.tbGoodArticul.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tbGoodArticul.Border.RightColor = System.Drawing.Color.Black;
            this.tbGoodArticul.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tbGoodArticul.Border.TopColor = System.Drawing.Color.Black;
            this.tbGoodArticul.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tbGoodArticul.CanShrink = true;
            this.tbGoodArticul.Height = 0.1574803F;
            this.tbGoodArticul.Left = 2.322835F;
            this.tbGoodArticul.Name = "tbGoodArticul";
            this.tbGoodArticul.Style = "font-size: 9.75pt; ";
            this.tbGoodArticul.Text = "Articul";
            this.tbGoodArticul.Top = 0.03937008F;
            this.tbGoodArticul.Width = 0.7874017F;
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
            this.line4.LineStyle = DataDynamics.ActiveReports.LineStyle.Dot;
            this.line4.LineWeight = 1F;
            this.line4.Name = "line4";
            this.line4.Top = 0.2362205F;
            this.line4.Width = 7.401575F;
            this.line4.X1 = 0.03937008F;
            this.line4.X2 = 7.440945F;
            this.line4.Y1 = 0.2362205F;
            this.line4.Y2 = 0.2362205F;
            // 
            // label4
            // 
            this.label4.Border.BottomColor = System.Drawing.Color.Black;
            this.label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Border.LeftColor = System.Drawing.Color.Black;
            this.label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Border.RightColor = System.Drawing.Color.Black;
            this.label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Border.TopColor = System.Drawing.Color.Black;
            this.label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Height = 0.1574803F;
            this.label4.HyperLink = null;
            this.label4.Left = 6.456693F;
            this.label4.Name = "label4";
            this.label4.Style = "ddo-char-set: 204; text-align: right; font-style: normal; font-size: 8.25pt; ";
            this.label4.Text = "кор.";
            this.label4.Top = 0.2755906F;
            this.label4.Width = 0.2755907F;
            // 
            // label5
            // 
            this.label5.Border.BottomColor = System.Drawing.Color.Black;
            this.label5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Border.LeftColor = System.Drawing.Color.Black;
            this.label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Border.RightColor = System.Drawing.Color.Black;
            this.label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Border.TopColor = System.Drawing.Color.Black;
            this.label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Height = 0.1574803F;
            this.label5.HyperLink = null;
            this.label5.Left = 7.047244F;
            this.label5.Name = "label5";
            this.label5.Style = "ddo-char-set: 204; text-align: right; font-style: normal; font-size: 8.25pt; ";
            this.label5.Text = "шт.";
            this.label5.Top = 0.2755906F;
            this.label5.Width = 0.2755907F;
            // 
            // textBox24
            // 
            this.textBox24.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox24.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox24.Border.RightColor = System.Drawing.Color.Black;
            this.textBox24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox24.Border.TopColor = System.Drawing.Color.Black;
            this.textBox24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox24.Height = 0.1574803F;
            this.textBox24.Left = 1.023622F;
            this.textBox24.Name = "textBox24";
            this.textBox24.Style = "font-size: 8.25pt; ";
            this.textBox24.Text = "Контейнер";
            this.textBox24.Top = 0.2755906F;
            this.textBox24.Width = 0.5905512F;
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
            this.textBox9,
            this.textBox5,
            this.textBox24,
            this.label4,
            this.label5,
            this.textBox3,
            this.textBox6,
            this.textBox11,
            this.line3,
            this.line1});
            this.groupHeaderStoreZoneID.DataField = "StoreZoneID";
            this.groupHeaderStoreZoneID.Height = 0.5208333F;
            this.groupHeaderStoreZoneID.Name = "groupHeaderStoreZoneID";
            this.groupHeaderStoreZoneID.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // textBox9
            // 
            this.textBox9.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox9.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox9.Border.RightColor = System.Drawing.Color.Black;
            this.textBox9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox9.Border.TopColor = System.Drawing.Color.Black;
            this.textBox9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox9.Height = 0.1181102F;
            this.textBox9.Left = 1.653543F;
            this.textBox9.Name = "textBox9";
            this.textBox9.Style = "font-size: 6pt; ";
            this.textBox9.Text = "Владелец";
            this.textBox9.Top = 0.3937008F;
            this.textBox9.Width = 0.7086615F;
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
            this.textBox3.Height = 0.1574803F;
            this.textBox3.Left = 0.07874016F;
            this.textBox3.Name = "textBox3";
            this.textBox3.Style = "font-size: 8.25pt; ";
            this.textBox3.Text = "Ячейка";
            this.textBox3.Top = 0.2755906F;
            this.textBox3.Width = 0.7086614F;
            // 
            // textBox6
            // 
            this.textBox6.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.Border.RightColor = System.Drawing.Color.Black;
            this.textBox6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.Border.TopColor = System.Drawing.Color.Black;
            this.textBox6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.Height = 0.1574803F;
            this.textBox6.Left = 2.283465F;
            this.textBox6.Name = "textBox6";
            this.textBox6.Style = "font-size: 8.25pt; ";
            this.textBox6.Text = "Товар";
            this.textBox6.Top = 0.2755906F;
            this.textBox6.Width = 0.8267717F;
            // 
            // textBox11
            // 
            this.textBox11.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox11.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox11.Border.RightColor = System.Drawing.Color.Black;
            this.textBox11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox11.Border.TopColor = System.Drawing.Color.Black;
            this.textBox11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox11.Height = 0.1181102F;
            this.textBox11.Left = 1.653543F;
            this.textBox11.Name = "textBox11";
            this.textBox11.Style = "font-size: 6pt; ";
            this.textBox11.Text = "Состояние";
            this.textBox11.Top = 0.2755906F;
            this.textBox11.Width = 0.7086615F;
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
            this.line1.Top = 0.511811F;
            this.line1.Width = 7.401575F;
            this.line1.X1 = 0.03937008F;
            this.line1.X2 = 7.440945F;
            this.line1.Y1 = 0.511811F;
            this.line1.Y2 = 0.511811F;
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
            this.line2.Top = 0.8661418F;
            this.line2.Width = 7.401575F;
            this.line2.X1 = 0.03937008F;
            this.line2.X2 = 7.440945F;
            this.line2.Y1 = 0.8661418F;
            this.line2.Y2 = 0.8661418F;
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
            this.groupHeaderAll.Height = 0.875F;
            this.groupHeaderAll.Name = "groupHeaderAll";
            this.groupHeaderAll.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
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
            this.textBox1.Height = 0.1574803F;
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
            // repInventoryBillContents
            // 
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.Margins.Bottom = 0.1968504F;
            this.PageSettings.Margins.Left = 0.3937008F;
            this.PageSettings.Margins.Right = 0.1968504F;
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
            ((System.ComponentModel.ISupportInitialize)(this.tbPackingAlias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGoodStateName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbOwnerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGoodArticul)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportInfo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
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
		private DataDynamics.ActiveReports.ReportInfo reportInfo2;
		private DataDynamics.ActiveReports.Line line2;
		private DataDynamics.ActiveReports.Line line3;
		private DataDynamics.ActiveReports.TextBox textBox4;
		private DataDynamics.ActiveReports.TextBox textBox7;
		private DataDynamics.ActiveReports.TextBox txtDateInventory;
		private DataDynamics.ActiveReports.Barcode txtBarCode;
		private DataDynamics.ActiveReports.TextBox textBox5;
		private DataDynamics.ActiveReports.TextBox Address;
		private DataDynamics.ActiveReports.GroupHeader groupHeaderAll;
		private DataDynamics.ActiveReports.GroupFooter groupFooterAll;
		private DataDynamics.ActiveReports.TextBox textBox1;
		private DataDynamics.ActiveReports.TextBox tbPackingAlias;
		private DataDynamics.ActiveReports.Label label4;
		private DataDynamics.ActiveReports.Label label5;
		private DataDynamics.ActiveReports.TextBox textBox13;
		private DataDynamics.ActiveReports.TextBox tbGoodStateName;
		private DataDynamics.ActiveReports.TextBox textBox24;
		private DataDynamics.ActiveReports.TextBox tbOwnerName;
		private DataDynamics.ActiveReports.Line line1;
		private DataDynamics.ActiveReports.TextBox textBox3;
		private DataDynamics.ActiveReports.TextBox textBox6;
		private DataDynamics.ActiveReports.TextBox textBox11;
		private DataDynamics.ActiveReports.Line line4;
		private DataDynamics.ActiveReports.TextBox textBox9;
		private DataDynamics.ActiveReports.TextBox tbGoodArticul;

	}
}
