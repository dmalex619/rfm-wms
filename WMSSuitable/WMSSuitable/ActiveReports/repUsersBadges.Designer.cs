namespace WMSSuitable
{
	/// <summary>
	/// Summary description for NewActiveReport1.
	/// </summary>
	partial class repUsersBadges
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(repUsersBadges));
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.shape1 = new DataDynamics.ActiveReports.Shape();
            this.barcode1 = new DataDynamics.ActiveReports.Barcode();
            this.txtName = new DataDynamics.ActiveReports.TextBox();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Height = 0.25F;
            this.pageHeader.Name = "pageHeader";
            // 
            // detail
            // 
            this.detail.ColumnCount = 2;
            this.detail.ColumnSpacing = 0F;
            this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.shape1,
            this.barcode1,
            this.txtName});
            this.detail.Height = 1.802083F;
            this.detail.KeepTogether = true;
            this.detail.Name = "detail";
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
            this.shape1.Height = 1.625984F;
            this.shape1.Left = 0.03937008F;
            this.shape1.LineStyle = DataDynamics.ActiveReports.LineStyle.Dot;
            this.shape1.Name = "shape1";
            this.shape1.RoundingRadius = 9.999999F;
            this.shape1.Top = 0.03937008F;
            this.shape1.Width = 3.346457F;
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
            this.barcode1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.barcode1.Height = 0.658F;
            this.barcode1.Left = 0.2362205F;
            this.barcode1.Name = "barcode1";
            this.barcode1.Style = DataDynamics.ActiveReports.BarCodeStyle.EAN128FNC1;
            this.barcode1.Text = "barcode1";
            this.barcode1.Top = 0.3149606F;
            this.barcode1.Width = 2.952756F;
            // 
            // txtName
            // 
            this.txtName.Border.BottomColor = System.Drawing.Color.Black;
            this.txtName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtName.Border.LeftColor = System.Drawing.Color.Black;
            this.txtName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtName.Border.RightColor = System.Drawing.Color.Black;
            this.txtName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtName.Border.TopColor = System.Drawing.Color.Black;
            this.txtName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtName.DataField = "Name";
            this.txtName.Height = 0.3149606F;
            this.txtName.Left = 0.2362205F;
            this.txtName.Name = "txtName";
            this.txtName.Style = "ddo-char-set: 204; text-align: center; font-weight: bold; font-size: 14.25pt; fon" +
                "t-family: Tahoma; ";
            this.txtName.Text = "Name";
            this.txtName.Top = 1.220472F;
            this.txtName.Width = 2.952756F;
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0.25F;
            this.pageFooter.Name = "pageFooter";
            // 
            // repUsersBadges
            // 
            this.PageSettings.Margins.Bottom = 0.3937008F;
            this.PageSettings.Margins.Left = 0.3937008F;
            this.PageSettings.Margins.Right = 0.3937008F;
            this.PageSettings.Margins.Top = 0.3937008F;
            this.PageSettings.PaperHeight = 11.69F;
            this.PageSettings.PaperWidth = 8.27F;
            this.PrintWidth = 7.086614F;
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.pageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                        "l; font-size: 10pt; color: Black; ddo-char-set: 204; ", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                        "lic; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}
		#endregion

		private DataDynamics.ActiveReports.Shape shape1;
		private DataDynamics.ActiveReports.Barcode barcode1;
		private DataDynamics.ActiveReports.TextBox txtName;
	}
}
