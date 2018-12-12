namespace WMSSuitable
{
	/// <summary>
	/// Summary description for OutputBillBarCode.
	/// </summary>
	partial class repOutputBillBarCode
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(repOutputBillBarCode));
			this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
			this.reportInfo1 = new DataDynamics.ActiveReports.ReportInfo();
			this.label4 = new DataDynamics.ActiveReports.Label();
			this.label5 = new DataDynamics.ActiveReports.Label();
			this.label8 = new DataDynamics.ActiveReports.Label();
			this.label9 = new DataDynamics.ActiveReports.Label();
			this.line2 = new DataDynamics.ActiveReports.Line();
			this.label1 = new DataDynamics.ActiveReports.Label();
			this.OutputID = new DataDynamics.ActiveReports.TextBox();
			this.textBox4 = new DataDynamics.ActiveReports.TextBox();
			this.txtDateConfirm = new DataDynamics.ActiveReports.TextBox();
			this.label12 = new DataDynamics.ActiveReports.Label();
			this.textBox19 = new DataDynamics.ActiveReports.TextBox();
			this.label3 = new DataDynamics.ActiveReports.Label();
			this.textBox3 = new DataDynamics.ActiveReports.TextBox();
			this.textBox11 = new DataDynamics.ActiveReports.TextBox();
			this.label11 = new DataDynamics.ActiveReports.Label();
			this.textBox10 = new DataDynamics.ActiveReports.TextBox();
			this.textBox7 = new DataDynamics.ActiveReports.TextBox();
			this.barcode1 = new DataDynamics.ActiveReports.Barcode();
			this.line5 = new DataDynamics.ActiveReports.Line();
			this.detail = new DataDynamics.ActiveReports.Detail();
			this.txtPackingName1 = new DataDynamics.ActiveReports.TextBox();
			this.txtQntWished1 = new DataDynamics.ActiveReports.TextBox();
			this.textBox1 = new DataDynamics.ActiveReports.TextBox();
			this.textBox5 = new DataDynamics.ActiveReports.TextBox();
			this.textBox6 = new DataDynamics.ActiveReports.TextBox();
			this.line1 = new DataDynamics.ActiveReports.Line();
			this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
			this.reportInfo2 = new DataDynamics.ActiveReports.ReportInfo();
			this.groupOutputID = new DataDynamics.ActiveReports.GroupHeader();
			this.groupOutputIDFooter = new DataDynamics.ActiveReports.GroupFooter();
			this.textBox14 = new DataDynamics.ActiveReports.TextBox();
			this.textBox15 = new DataDynamics.ActiveReports.TextBox();
			this.textBox18 = new DataDynamics.ActiveReports.TextBox();
			this.line3 = new DataDynamics.ActiveReports.Line();
			this.line4 = new DataDynamics.ActiveReports.Line();
			((System.ComponentModel.ISupportInitialize)(this.reportInfo1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.OutputID)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDateConfirm)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textBox19)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textBox10)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPackingName1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtQntWished1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.reportInfo2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textBox14)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textBox15)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textBox18)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// pageHeader
			// 
			this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.reportInfo1,
            this.label4,
            this.label5,
            this.label8,
            this.label9,
            this.line2,
            this.label1,
            this.OutputID,
            this.textBox4,
            this.txtDateConfirm,
            this.label12,
            this.textBox19,
            this.label3,
            this.textBox3,
            this.textBox11,
            this.label11,
            this.textBox10,
            this.textBox7,
            this.barcode1,
            this.line5});
			this.pageHeader.Height = 1.979167F;
			this.pageHeader.Name = "pageHeader";
			this.pageHeader.Format += new System.EventHandler(this.pageHeader_Format);
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
			this.reportInfo1.FormatString = "Стр. {PageNumber} из {PageCount}";
			this.reportInfo1.Height = 0.1968504F;
			this.reportInfo1.Left = 6.220472F;
			this.reportInfo1.Name = "reportInfo1";
			this.reportInfo1.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: Tahoma; ";
			this.reportInfo1.SummaryGroup = "groupHeader1";
			this.reportInfo1.Top = 0F;
			this.reportInfo1.Width = 1.181103F;
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
			this.label4.Left = 0.07874016F;
			this.label4.Name = "label4";
			this.label4.Style = "ddo-char-set: 1; font-size: 8pt; ";
			this.label4.Text = "Товар, упаковка";
			this.label4.Top = 1.771654F;
			this.label4.Width = 2.874016F;
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
			this.label5.Left = 4.055118F;
			this.label5.Name = "label5";
			this.label5.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; ";
			this.label5.Text = "Штук";
			this.label5.Top = 1.771654F;
			this.label5.Width = 0.6299213F;
			// 
			// label8
			// 
			this.label8.Border.BottomColor = System.Drawing.Color.Black;
			this.label8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.label8.Border.LeftColor = System.Drawing.Color.Black;
			this.label8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.label8.Border.RightColor = System.Drawing.Color.Black;
			this.label8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.label8.Border.TopColor = System.Drawing.Color.Black;
			this.label8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.label8.Height = 0.1574803F;
			this.label8.HyperLink = null;
			this.label8.Left = 4.80315F;
			this.label8.Name = "label8";
			this.label8.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; ";
			this.label8.Text = "Кор.";
			this.label8.Top = 1.771654F;
			this.label8.Width = 0.4330707F;
			// 
			// label9
			// 
			this.label9.Border.BottomColor = System.Drawing.Color.Black;
			this.label9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.label9.Border.LeftColor = System.Drawing.Color.Black;
			this.label9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.label9.Border.RightColor = System.Drawing.Color.Black;
			this.label9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.label9.Border.TopColor = System.Drawing.Color.Black;
			this.label9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.label9.Height = 0.1574803F;
			this.label9.HyperLink = null;
			this.label9.Left = 5.393701F;
			this.label9.Name = "label9";
			this.label9.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; ";
			this.label9.Text = "Пал.";
			this.label9.Top = 1.771654F;
			this.label9.Width = 0.4330709F;
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
			this.line2.Top = 1.968504F;
			this.line2.Width = 7.401575F;
			this.line2.X1 = 0.03937008F;
			this.line2.X2 = 7.440945F;
			this.line2.Y1 = 1.968504F;
			this.line2.Y2 = 1.968504F;
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
			this.label1.Style = "ddo-char-set: 1; font-weight: normal; font-size: 11pt; font-family: Tahoma; ";
			this.label1.Text = "Приход";
			this.label1.Top = 0.07874016F;
			this.label1.Width = 0.8661418F;
			// 
			// OutputID
			// 
			this.OutputID.Border.BottomColor = System.Drawing.Color.Black;
			this.OutputID.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.OutputID.Border.LeftColor = System.Drawing.Color.Black;
			this.OutputID.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.OutputID.Border.RightColor = System.Drawing.Color.Black;
			this.OutputID.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.OutputID.Border.TopColor = System.Drawing.Color.Black;
			this.OutputID.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.OutputID.DataField = "OutputID";
			this.OutputID.Height = 0.1968504F;
			this.OutputID.Left = 1.181102F;
			this.OutputID.Name = "OutputID";
			this.OutputID.Style = "ddo-char-set: 1; font-weight: bold; font-size: 11pt; ";
			this.OutputID.Text = "OutputID";
			this.OutputID.Top = 0.07874016F;
			this.OutputID.Width = 0.8661418F;
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
			this.textBox4.DataField = "=DateOutput.ToString().Substring(0, 10)";
			this.textBox4.Height = 0.1968504F;
			this.textBox4.Left = 1.181102F;
			this.textBox4.MultiLine = false;
			this.textBox4.Name = "textBox4";
			this.textBox4.OutputFormat = resources.GetString("textBox4.OutputFormat");
			this.textBox4.Style = "ddo-char-set: 1; font-weight: bold; font-size: 11pt; white-space: nowrap; ";
			this.textBox4.Text = "DateOutput";
			this.textBox4.Top = 0.3149606F;
			this.textBox4.Width = 0.984252F;
			// 
			// txtDateConfirm
			// 
			this.txtDateConfirm.Border.BottomColor = System.Drawing.Color.Black;
			this.txtDateConfirm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.txtDateConfirm.Border.LeftColor = System.Drawing.Color.Black;
			this.txtDateConfirm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.txtDateConfirm.Border.RightColor = System.Drawing.Color.Black;
			this.txtDateConfirm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.txtDateConfirm.Border.TopColor = System.Drawing.Color.Black;
			this.txtDateConfirm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.txtDateConfirm.DataField = "=(DateConfirm = System.DBNull.Value) ? \"\" : \"Вып. \"+DateConfirm.ToString().Substr" +
				"ing(0, 16)";
			this.txtDateConfirm.Height = 0.1968504F;
			this.txtDateConfirm.Left = 0.07874016F;
			this.txtDateConfirm.MultiLine = false;
			this.txtDateConfirm.Name = "txtDateConfirm";
			this.txtDateConfirm.OutputFormat = resources.GetString("txtDateConfirm.OutputFormat");
			this.txtDateConfirm.Style = "ddo-char-set: 1; font-weight: bold; font-size: 11pt; font-family: Tahoma; white-s" +
				"pace: nowrap; ";
			this.txtDateConfirm.Text = "DateConfirm";
			this.txtDateConfirm.Top = 0.5511811F;
			this.txtDateConfirm.Width = 2.322835F;
			// 
			// label12
			// 
			this.label12.Border.BottomColor = System.Drawing.Color.Black;
			this.label12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.label12.Border.LeftColor = System.Drawing.Color.Black;
			this.label12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.label12.Border.RightColor = System.Drawing.Color.Black;
			this.label12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.label12.Border.TopColor = System.Drawing.Color.Black;
			this.label12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.label12.Height = 0.1968504F;
			this.label12.HyperLink = null;
			this.label12.Left = 0.07874016F;
			this.label12.Name = "label12";
			this.label12.Style = "ddo-char-set: 204; font-weight: normal; font-size: 11.25pt; font-family: Tahoma; " +
				"";
			this.label12.Text = "Тип прихода";
			this.label12.Top = 0.7874016F;
			this.label12.Width = 1.023622F;
			// 
			// textBox19
			// 
			this.textBox19.Border.BottomColor = System.Drawing.Color.Black;
			this.textBox19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.textBox19.Border.LeftColor = System.Drawing.Color.Black;
			this.textBox19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.textBox19.Border.RightColor = System.Drawing.Color.Black;
			this.textBox19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.textBox19.Border.TopColor = System.Drawing.Color.Black;
			this.textBox19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.textBox19.DataField = "OutputTypeName";
			this.textBox19.Height = 0.1968504F;
			this.textBox19.Left = 1.181102F;
			this.textBox19.Name = "textBox19";
			this.textBox19.Style = "ddo-char-set: 204; font-weight: bold; font-size: 11.25pt; ";
			this.textBox19.Text = "OutputTypeName";
			this.textBox19.Top = 0.7874016F;
			this.textBox19.Width = 4.645669F;
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
			this.label3.Left = 0.07874016F;
			this.label3.Name = "label3";
			this.label3.Style = "ddo-char-set: 1; font-weight: normal; font-size: 11pt; font-family: Tahoma; ";
			this.label3.Text = "Владелец";
			this.label3.Top = 1.023622F;
			this.label3.Width = 1.141732F;
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
			this.textBox3.DataField = "OwnerName";
			this.textBox3.Height = 0.1968504F;
			this.textBox3.Left = 1.181102F;
			this.textBox3.Name = "textBox3";
			this.textBox3.Style = "ddo-char-set: 1; font-weight: bold; font-size: 11pt; ";
			this.textBox3.Text = "OwnerName";
			this.textBox3.Top = 1.023622F;
			this.textBox3.Width = 4.645669F;
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
			this.textBox11.DataField = "OutputGoodStateName";
			this.textBox11.Height = 0.1968504F;
			this.textBox11.Left = 5.157481F;
			this.textBox11.Name = "textBox11";
			this.textBox11.Style = "ddo-char-set: 204; text-align: right; font-weight: bold; font-size: 11.25pt; ";
			this.textBox11.Text = "OutputGoodStateName";
			this.textBox11.Top = 0.7874016F;
			this.textBox11.Width = 2.244095F;
			// 
			// label11
			// 
			this.label11.Border.BottomColor = System.Drawing.Color.Black;
			this.label11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.label11.Border.LeftColor = System.Drawing.Color.Black;
			this.label11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.label11.Border.RightColor = System.Drawing.Color.Black;
			this.label11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.label11.Border.TopColor = System.Drawing.Color.Black;
			this.label11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.label11.Height = 0.1968504F;
			this.label11.HyperLink = null;
			this.label11.Left = 5.787402F;
			this.label11.Name = "label11";
			this.label11.Style = "ddo-char-set: 0; font-weight: normal; font-size: 11pt; font-family: Tahoma; ";
			this.label11.Text = "Код в УС:";
			this.label11.Top = 0.4330709F;
			this.label11.Width = 0.7086613F;
			// 
			// textBox10
			// 
			this.textBox10.Border.BottomColor = System.Drawing.Color.Black;
			this.textBox10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.textBox10.Border.LeftColor = System.Drawing.Color.Black;
			this.textBox10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.textBox10.Border.RightColor = System.Drawing.Color.Black;
			this.textBox10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.textBox10.Border.TopColor = System.Drawing.Color.Black;
			this.textBox10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.textBox10.DataField = "OutputErpCode";
			this.textBox10.Height = 0.1968504F;
			this.textBox10.Left = 6.496063F;
			this.textBox10.Name = "textBox10";
			this.textBox10.Style = "ddo-char-set: 204; font-weight: bold; font-size: 11.25pt; ";
			this.textBox10.Text = "OutputErpCode";
			this.textBox10.Top = 0.4330709F;
			this.textBox10.Width = 0.9055117F;
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
			this.textBox7.DataField = "OutputNote";
			this.textBox7.Height = 0.3937008F;
			this.textBox7.Left = 0.07874016F;
			this.textBox7.Name = "textBox7";
			this.textBox7.Style = "";
			this.textBox7.Text = "OutputNote";
			this.textBox7.Top = 1.259843F;
			this.textBox7.Width = 7.283465F;
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
			this.barcode1.CheckSumEnabled = false;
			this.barcode1.DataField = "BarCode";
			this.barcode1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.barcode1.Height = 0.658F;
			this.barcode1.Left = 2.598425F;
			this.barcode1.Name = "barcode1";
			this.barcode1.Style = DataDynamics.ActiveReports.BarCodeStyle.EAN128FNC1;
			this.barcode1.Text = "barcode1";
			this.barcode1.Top = 0.07874016F;
			this.barcode1.Width = 3.149606F;
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
			this.line5.LineWeight = 1F;
			this.line5.Name = "line5";
			this.line5.Top = 1.692913F;
			this.line5.Width = 7.401575F;
			this.line5.X1 = 0.03937008F;
			this.line5.X2 = 7.440945F;
			this.line5.Y1 = 1.692913F;
			this.line5.Y2 = 1.692913F;
			// 
			// detail
			// 
			this.detail.ColumnSpacing = 0F;
			this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtPackingName1,
            this.txtQntWished1,
            this.textBox1,
            this.textBox5,
            this.textBox6,
            this.line1});
			this.detail.Height = 0.6354167F;
			this.detail.Name = "detail";
			// 
			// txtPackingName1
			// 
			this.txtPackingName1.Border.BottomColor = System.Drawing.Color.Black;
			this.txtPackingName1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.txtPackingName1.Border.LeftColor = System.Drawing.Color.Black;
			this.txtPackingName1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.txtPackingName1.Border.RightColor = System.Drawing.Color.Black;
			this.txtPackingName1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.txtPackingName1.Border.TopColor = System.Drawing.Color.Black;
			this.txtPackingName1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.txtPackingName1.DataField = "PackingAlias";
			this.txtPackingName1.Height = 0.4330709F;
			this.txtPackingName1.Left = 0.07874016F;
			this.txtPackingName1.Name = "txtPackingName1";
			this.txtPackingName1.Style = "";
			this.txtPackingName1.Text = "txtPackingName1";
			this.txtPackingName1.Top = 0.03937008F;
			this.txtPackingName1.Width = 3.582677F;
			// 
			// txtQntWished1
			// 
			this.txtQntWished1.Border.BottomColor = System.Drawing.Color.Black;
			this.txtQntWished1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.txtQntWished1.Border.LeftColor = System.Drawing.Color.Black;
			this.txtQntWished1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.txtQntWished1.Border.RightColor = System.Drawing.Color.Black;
			this.txtQntWished1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.txtQntWished1.Border.TopColor = System.Drawing.Color.Black;
			this.txtQntWished1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.txtQntWished1.DataField = "=(Weighting)?\"\":QntWished";
			this.txtQntWished1.Height = 0.1968504F;
			this.txtQntWished1.Left = 3.740157F;
			this.txtQntWished1.Name = "txtQntWished1";
			this.txtQntWished1.OutputFormat = resources.GetString("txtQntWished1.OutputFormat");
			this.txtQntWished1.Style = "text-align: right; ";
			this.txtQntWished1.Text = "txtQntWished1";
			this.txtQntWished1.Top = 0.03937008F;
			this.txtQntWished1.Width = 0.905512F;
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
			this.textBox1.DataField = "=(Weighting)?QntWished:\"\"";
			this.textBox1.Height = 0.1968504F;
			this.textBox1.Left = 3.661417F;
			this.textBox1.Name = "textBox1";
			this.textBox1.OutputFormat = resources.GetString("textBox1.OutputFormat");
			this.textBox1.Style = "text-align: right; ";
			this.textBox1.Text = "txtQntWished1";
			this.textBox1.Top = 0.03937008F;
			this.textBox1.Width = 0.9842522F;
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
			this.textBox5.DataField = "BoxWished";
			this.textBox5.Height = 0.1968504F;
			this.textBox5.Left = 4.645669F;
			this.textBox5.Name = "textBox5";
			this.textBox5.OutputFormat = resources.GetString("textBox5.OutputFormat");
			this.textBox5.Style = "text-align: right; ";
			this.textBox5.Text = "txtBoxWished1";
			this.textBox5.Top = 0.03937008F;
			this.textBox5.Width = 0.6692915F;
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
			this.textBox6.DataField = "PalWished";
			this.textBox6.Height = 0.1968504F;
			this.textBox6.Left = 5.314961F;
			this.textBox6.Name = "textBox6";
			this.textBox6.OutputFormat = resources.GetString("textBox6.OutputFormat");
			this.textBox6.Style = "text-align: right; ";
			this.textBox6.Text = "txtPalWishedS";
			this.textBox6.Top = 0.03937008F;
			this.textBox6.Width = 0.511811F;
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
			this.line1.Top = 0.5905512F;
			this.line1.Width = 7.401575F;
			this.line1.X1 = 0.03937008F;
			this.line1.X2 = 7.440945F;
			this.line1.Y1 = 0.5905512F;
			this.line1.Y2 = 0.5905512F;
			// 
			// pageFooter
			// 
			this.pageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.reportInfo2});
			this.pageFooter.Height = 0.2083333F;
			this.pageFooter.Name = "pageFooter";
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
			this.reportInfo2.FormatString = "{RunDateTime:dd.MM.yyyy HH:mm}";
			this.reportInfo2.Height = 0.1145833F;
			this.reportInfo2.Left = 5.748032F;
			this.reportInfo2.Name = "reportInfo2";
			this.reportInfo2.Style = "ddo-char-set: 1; text-align: right; font-size: 6pt; ";
			this.reportInfo2.Top = 0.07874016F;
			this.reportInfo2.Width = 1.65625F;
			// 
			// groupOutputID
			// 
			this.groupOutputID.DataField = "OutputID";
			this.groupOutputID.Height = 0.05208333F;
			this.groupOutputID.Name = "groupOutputID";
			this.groupOutputID.NewPage = DataDynamics.ActiveReports.NewPage.Before;
			// 
			// groupOutputIDFooter
			// 
			this.groupOutputIDFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox14,
            this.textBox15,
            this.textBox18,
            this.line3,
            this.line4});
			this.groupOutputIDFooter.Height = 0.3125F;
			this.groupOutputIDFooter.Name = "groupOutputIDFooter";
			// 
			// textBox14
			// 
			this.textBox14.Border.BottomColor = System.Drawing.Color.Black;
			this.textBox14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.textBox14.Border.LeftColor = System.Drawing.Color.Black;
			this.textBox14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.textBox14.Border.RightColor = System.Drawing.Color.Black;
			this.textBox14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.textBox14.Border.TopColor = System.Drawing.Color.Black;
			this.textBox14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.textBox14.DataField = "PalWished";
			this.textBox14.Height = 0.1968504F;
			this.textBox14.Left = 5.314961F;
			this.textBox14.Name = "textBox14";
			this.textBox14.OutputFormat = resources.GetString("textBox14.OutputFormat");
			this.textBox14.Style = "text-align: right; font-weight: bold; ";
			this.textBox14.SummaryGroup = "groupOutputID";
			this.textBox14.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
			this.textBox14.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
			this.textBox14.Text = "txtPalWished";
			this.textBox14.Top = 0.07874016F;
			this.textBox14.Width = 0.511811F;
			// 
			// textBox15
			// 
			this.textBox15.Border.BottomColor = System.Drawing.Color.Black;
			this.textBox15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.textBox15.Border.LeftColor = System.Drawing.Color.Black;
			this.textBox15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.textBox15.Border.RightColor = System.Drawing.Color.Black;
			this.textBox15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.textBox15.Border.TopColor = System.Drawing.Color.Black;
			this.textBox15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.textBox15.DataField = "BoxWished";
			this.textBox15.Height = 0.1968504F;
			this.textBox15.Left = 4.645669F;
			this.textBox15.Name = "textBox15";
			this.textBox15.OutputFormat = resources.GetString("textBox15.OutputFormat");
			this.textBox15.Style = "text-align: right; font-weight: bold; ";
			this.textBox15.SummaryGroup = "groupOutputID";
			this.textBox15.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
			this.textBox15.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
			this.textBox15.Text = "txtBoxWished1";
			this.textBox15.Top = 0.07874016F;
			this.textBox15.Width = 0.6692913F;
			// 
			// textBox18
			// 
			this.textBox18.Border.BottomColor = System.Drawing.Color.Black;
			this.textBox18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.textBox18.Border.LeftColor = System.Drawing.Color.Black;
			this.textBox18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.textBox18.Border.RightColor = System.Drawing.Color.Black;
			this.textBox18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.textBox18.Border.TopColor = System.Drawing.Color.Black;
			this.textBox18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
			this.textBox18.DataField = "QntWished";
			this.textBox18.Height = 0.1968504F;
			this.textBox18.Left = 3.661417F;
			this.textBox18.Name = "textBox18";
			this.textBox18.OutputFormat = resources.GetString("textBox18.OutputFormat");
			this.textBox18.Style = "text-align: right; font-weight: bold; ";
			this.textBox18.SummaryGroup = "groupOutputID";
			this.textBox18.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
			this.textBox18.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
			this.textBox18.Text = "txtQntWished1";
			this.textBox18.Top = 0.07874016F;
			this.textBox18.Width = 0.9842522F;
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
			this.line3.Top = 0.03937008F;
			this.line3.Width = 7.401575F;
			this.line3.X1 = 0.03937008F;
			this.line3.X2 = 7.440945F;
			this.line3.Y1 = 0.03937008F;
			this.line3.Y2 = 0.03937008F;
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
			this.line4.Top = 0F;
			this.line4.Width = 7.401575F;
			this.line4.X1 = 0.03937008F;
			this.line4.X2 = 7.440945F;
			this.line4.Y1 = 0F;
			this.line4.Y2 = 0F;
			// 
			// repOutputBillBarCode
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
			this.PrintWidth = 7.480315F;
			this.Sections.Add(this.pageHeader);
			this.Sections.Add(this.groupOutputID);
			this.Sections.Add(this.detail);
			this.Sections.Add(this.groupOutputIDFooter);
			this.Sections.Add(this.pageFooter);
			this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-style: normal; text-decoration: none; font-weight: normal; font-size: 10pt; " +
						"color: Black; font-family: \"Tahoma\"; ddo-char-set: 204; ", "Normal"));
			this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-weight: bold; ddo-char-set: 204; font-size: 12pt; ", "Heading1", "Normal"));
			this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
						"lic; ", "Heading2", "Normal"));
			this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"));
			((System.ComponentModel.ISupportInitialize)(this.reportInfo1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.OutputID)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDateConfirm)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textBox19)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textBox10)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPackingName1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtQntWished1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.reportInfo2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textBox14)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textBox15)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textBox18)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}
		#endregion

		private DataDynamics.ActiveReports.GroupHeader groupOutputID;
		private DataDynamics.ActiveReports.GroupFooter groupOutputIDFooter;
		private DataDynamics.ActiveReports.ReportInfo reportInfo1;
		private DataDynamics.ActiveReports.TextBox txtPackingName1;
		private DataDynamics.ActiveReports.TextBox txtQntWished1;
		private DataDynamics.ActiveReports.TextBox textBox1;
		private DataDynamics.ActiveReports.TextBox textBox5;
		private DataDynamics.ActiveReports.TextBox textBox6;
		private DataDynamics.ActiveReports.Label label4;
		private DataDynamics.ActiveReports.Label label5;
		private DataDynamics.ActiveReports.Label label9;
		private DataDynamics.ActiveReports.Label label8;
		private DataDynamics.ActiveReports.ReportInfo reportInfo2;
		private DataDynamics.ActiveReports.Line line2;
		private DataDynamics.ActiveReports.TextBox textBox14;
		private DataDynamics.ActiveReports.TextBox textBox15;
		private DataDynamics.ActiveReports.TextBox textBox18;
		private DataDynamics.ActiveReports.Line line3;
		private DataDynamics.ActiveReports.Line line4;
		private DataDynamics.ActiveReports.Line line1;
		private DataDynamics.ActiveReports.Label label1;
		private DataDynamics.ActiveReports.TextBox OutputID;
		private DataDynamics.ActiveReports.TextBox textBox4;
		private DataDynamics.ActiveReports.TextBox txtDateConfirm;
		private DataDynamics.ActiveReports.Label label12;
		private DataDynamics.ActiveReports.TextBox textBox19;
		private DataDynamics.ActiveReports.Label label3;
		private DataDynamics.ActiveReports.TextBox textBox3;
		private DataDynamics.ActiveReports.TextBox textBox11;
		private DataDynamics.ActiveReports.Label label11;
		private DataDynamics.ActiveReports.TextBox textBox10;
		private DataDynamics.ActiveReports.TextBox textBox7;
		private DataDynamics.ActiveReports.Barcode barcode1;
		private DataDynamics.ActiveReports.Line line5;
	}
}
