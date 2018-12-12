namespace WMSSuitable
{
    /// <summary>
    /// Summary description for repOldCellsContents.
    /// </summary>
    partial class repOldCellsContents
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(repOldCellsContents));
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.lblReportHeader = new DataDynamics.ActiveReports.Label();
            this.line1 = new DataDynamics.ActiveReports.Line();
            this.reportInfo1 = new DataDynamics.ActiveReports.ReportInfo();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.CellBarCode = new DataDynamics.ActiveReports.Barcode();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.txtPackingName = new DataDynamics.ActiveReports.TextBox();
            this.txtBoxes = new DataDynamics.ActiveReports.TextBox();
            this.lblBoxes = new DataDynamics.ActiveReports.Label();
            this.lblDateValid = new DataDynamics.ActiveReports.Label();
            this.txtDateValid = new DataDynamics.ActiveReports.TextBox();
            this.txtGoodStateName = new DataDynamics.ActiveReports.TextBox();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.reportInfo2 = new DataDynamics.ActiveReports.ReportInfo();
            this.txtCellAddress = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.lblReportHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportInfo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPackingName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBoxes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBoxes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDateValid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateValid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGoodStateName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportInfo2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCellAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblReportHeader,
            this.line1,
            this.reportInfo1});
            this.pageHeader.Height = 0.3149606F;
            this.pageHeader.Name = "pageHeader";
            // 
            // lblReportHeader
            // 
            this.lblReportHeader.Border.BottomColor = System.Drawing.Color.Black;
            this.lblReportHeader.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblReportHeader.Border.LeftColor = System.Drawing.Color.Black;
            this.lblReportHeader.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblReportHeader.Border.RightColor = System.Drawing.Color.Black;
            this.lblReportHeader.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblReportHeader.Border.TopColor = System.Drawing.Color.Black;
            this.lblReportHeader.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblReportHeader.Height = 0.1968504F;
            this.lblReportHeader.HyperLink = null;
            this.lblReportHeader.Left = 0.03937008F;
            this.lblReportHeader.Name = "lblReportHeader";
            this.lblReportHeader.Style = "ddo-char-set: 1; font-weight: bold; font-size: 11pt; font-family: Tahoma; ";
            this.lblReportHeader.Text = "Список ячеек высотной зоны со старыми паллетами";
            this.lblReportHeader.Top = 0.0492126F;
            this.lblReportHeader.Width = 4.478346F;
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
            this.line1.Top = 0.2755905F;
            this.line1.Width = 7.362205F;
            this.line1.X1 = 0.03937008F;
            this.line1.X2 = 7.401575F;
            this.line1.Y1 = 0.2755905F;
            this.line1.Y2 = 0.2755905F;
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
            this.reportInfo1.Left = 6.225394F;
            this.reportInfo1.Name = "reportInfo1";
            this.reportInfo1.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: Tahoma; ";
            this.reportInfo1.Top = 0.0492126F;
            this.reportInfo1.Width = 1.181103F;
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.CellBarCode,
            this.line2,
            this.txtPackingName,
            this.txtBoxes,
            this.lblBoxes,
            this.lblDateValid,
            this.txtDateValid,
            this.txtGoodStateName,
            this.txtCellAddress});
            this.detail.Height = 0.6299213F;
            this.detail.Name = "detail";
            // 
            // CellBarCode
            // 
            this.CellBarCode.Border.BottomColor = System.Drawing.Color.Black;
            this.CellBarCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CellBarCode.Border.LeftColor = System.Drawing.Color.Black;
            this.CellBarCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CellBarCode.Border.RightColor = System.Drawing.Color.Black;
            this.CellBarCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CellBarCode.Border.TopColor = System.Drawing.Color.Black;
            this.CellBarCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CellBarCode.DataField = "CellBarCode";
            this.CellBarCode.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CellBarCode.Height = 0.472441F;
            this.CellBarCode.Left = 0.03937008F;
            this.CellBarCode.Name = "CellBarCode";
            this.CellBarCode.Style = DataDynamics.ActiveReports.BarCodeStyle.Code_128auto;
            this.CellBarCode.Text = "barcode1";
            this.CellBarCode.Top = 0.03937008F;
            this.CellBarCode.Width = 1.968504F;
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
            this.line2.Left = 0.0492126F;
            this.line2.LineWeight = 1F;
            this.line2.Name = "line2";
            this.line2.Top = 0.5511811F;
            this.line2.Width = 7.357284F;
            this.line2.X1 = 0.0492126F;
            this.line2.X2 = 7.406496F;
            this.line2.Y1 = 0.5511811F;
            this.line2.Y2 = 0.5511811F;
            // 
            // txtPackingName
            // 
            this.txtPackingName.Border.BottomColor = System.Drawing.Color.Black;
            this.txtPackingName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPackingName.Border.LeftColor = System.Drawing.Color.Black;
            this.txtPackingName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPackingName.Border.RightColor = System.Drawing.Color.Black;
            this.txtPackingName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPackingName.Border.TopColor = System.Drawing.Color.Black;
            this.txtPackingName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPackingName.DataField = "PackingName";
            this.txtPackingName.Height = 0.1968504F;
            this.txtPackingName.Left = 3.665354F;
            this.txtPackingName.MultiLine = false;
            this.txtPackingName.Name = "txtPackingName";
            this.txtPackingName.Style = "font-weight: bold; font-family: Tahoma; ";
            this.txtPackingName.Text = "PackingName";
            this.txtPackingName.Top = 0.03937008F;
            this.txtPackingName.Width = 3.740158F;
            // 
            // txtBoxes
            // 
            this.txtBoxes.Border.BottomColor = System.Drawing.Color.Black;
            this.txtBoxes.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBoxes.Border.LeftColor = System.Drawing.Color.Black;
            this.txtBoxes.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBoxes.Border.RightColor = System.Drawing.Color.Black;
            this.txtBoxes.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBoxes.Border.TopColor = System.Drawing.Color.Black;
            this.txtBoxes.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBoxes.DataField = "Boxes";
            this.txtBoxes.Height = 0.1968504F;
            this.txtBoxes.Left = 3.986221F;
            this.txtBoxes.MultiLine = false;
            this.txtBoxes.Name = "txtBoxes";
            this.txtBoxes.OutputFormat = resources.GetString("txtBoxes.OutputFormat");
            this.txtBoxes.Style = "text-align: right; font-weight: bold; font-family: Tahoma; ";
            this.txtBoxes.Text = "Boxes";
            this.txtBoxes.Top = 0.3149607F;
            this.txtBoxes.Width = 0.472441F;
            // 
            // lblBoxes
            // 
            this.lblBoxes.Border.BottomColor = System.Drawing.Color.Black;
            this.lblBoxes.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblBoxes.Border.LeftColor = System.Drawing.Color.Black;
            this.lblBoxes.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblBoxes.Border.RightColor = System.Drawing.Color.Black;
            this.lblBoxes.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblBoxes.Border.TopColor = System.Drawing.Color.Black;
            this.lblBoxes.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblBoxes.Height = 0.1968504F;
            this.lblBoxes.HyperLink = null;
            this.lblBoxes.Left = 3.666339F;
            this.lblBoxes.MultiLine = false;
            this.lblBoxes.Name = "lblBoxes";
            this.lblBoxes.Style = "ddo-char-set: 1; font-weight: normal; font-size: 10pt; font-family: Tahoma; ";
            this.lblBoxes.Text = "Кор.:";
            this.lblBoxes.Top = 0.3149607F;
            this.lblBoxes.Width = 0.3543307F;
            // 
            // lblDateValid
            // 
            this.lblDateValid.Border.BottomColor = System.Drawing.Color.Black;
            this.lblDateValid.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDateValid.Border.LeftColor = System.Drawing.Color.Black;
            this.lblDateValid.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDateValid.Border.RightColor = System.Drawing.Color.Black;
            this.lblDateValid.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDateValid.Border.TopColor = System.Drawing.Color.Black;
            this.lblDateValid.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDateValid.Height = 0.1968504F;
            this.lblDateValid.HyperLink = null;
            this.lblDateValid.Left = 4.92126F;
            this.lblDateValid.MultiLine = false;
            this.lblDateValid.Name = "lblDateValid";
            this.lblDateValid.Style = "ddo-char-set: 1; font-weight: normal; font-size: 10pt; font-family: Tahoma; ";
            this.lblDateValid.Text = "СГ:";
            this.lblDateValid.Top = 0.3149606F;
            this.lblDateValid.Width = 0.2952755F;
            // 
            // txtDateValid
            // 
            this.txtDateValid.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDateValid.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDateValid.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDateValid.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDateValid.Border.RightColor = System.Drawing.Color.Black;
            this.txtDateValid.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDateValid.Border.TopColor = System.Drawing.Color.Black;
            this.txtDateValid.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDateValid.DataField = "DateValid";
            this.txtDateValid.Height = 0.1968504F;
            this.txtDateValid.Left = 5.216536F;
            this.txtDateValid.MultiLine = false;
            this.txtDateValid.Name = "txtDateValid";
            this.txtDateValid.OutputFormat = resources.GetString("txtDateValid.OutputFormat");
            this.txtDateValid.Style = "text-align: left; font-weight: bold; font-family: Tahoma; ";
            this.txtDateValid.Text = "DateValid";
            this.txtDateValid.Top = 0.3149607F;
            this.txtDateValid.Width = 0.8661417F;
            // 
            // txtGoodStateName
            // 
            this.txtGoodStateName.Border.BottomColor = System.Drawing.Color.Black;
            this.txtGoodStateName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGoodStateName.Border.LeftColor = System.Drawing.Color.Black;
            this.txtGoodStateName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGoodStateName.Border.RightColor = System.Drawing.Color.Black;
            this.txtGoodStateName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGoodStateName.Border.TopColor = System.Drawing.Color.Black;
            this.txtGoodStateName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGoodStateName.DataField = "GoodStateName";
            this.txtGoodStateName.Height = 0.1968504F;
            this.txtGoodStateName.Left = 6.44685F;
            this.txtGoodStateName.MultiLine = false;
            this.txtGoodStateName.Name = "txtGoodStateName";
            this.txtGoodStateName.Style = "font-weight: bold; font-family: Tahoma; ";
            this.txtGoodStateName.Text = "GoodStateName";
            this.txtGoodStateName.Top = 0.3149607F;
            this.txtGoodStateName.Width = 0.984252F;
            // 
            // pageFooter
            // 
            this.pageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.reportInfo2});
            this.pageFooter.Height = 0.1968504F;
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
            this.reportInfo2.Left = 5.750246F;
            this.reportInfo2.Name = "reportInfo2";
            this.reportInfo2.Style = "ddo-char-set: 1; text-align: right; font-size: 6pt; ";
            this.reportInfo2.Top = 0.03937008F;
            this.reportInfo2.Width = 1.65625F;
            // 
            // txtCellAddress
            // 
            this.txtCellAddress.Border.BottomColor = System.Drawing.Color.Black;
            this.txtCellAddress.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCellAddress.Border.LeftColor = System.Drawing.Color.Black;
            this.txtCellAddress.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCellAddress.Border.RightColor = System.Drawing.Color.Black;
            this.txtCellAddress.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCellAddress.Border.TopColor = System.Drawing.Color.Black;
            this.txtCellAddress.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCellAddress.DataField = "CellAddress";
            this.txtCellAddress.Height = 0.3149606F;
            this.txtCellAddress.Left = 2.165354F;
            this.txtCellAddress.MultiLine = false;
            this.txtCellAddress.Name = "txtCellAddress";
            this.txtCellAddress.Style = "text-align: left; font-weight: bold; font-size: 16pt; font-family: Tahoma; ";
            this.txtCellAddress.Text = "CellAddress";
            this.txtCellAddress.Top = 0.1181102F;
            this.txtCellAddress.Width = 1.377953F;
            // 
            // repOldCellsContents
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
            this.Sections.Add(this.detail);
            this.Sections.Add(this.pageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                        "l; font-size: 10pt; color: Black; ddo-char-set: 204; ", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                        "lic; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this.lblReportHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportInfo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPackingName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBoxes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBoxes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDateValid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateValid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGoodStateName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportInfo2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCellAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.Label lblReportHeader;
        private DataDynamics.ActiveReports.Barcode CellBarCode;
        private DataDynamics.ActiveReports.Line line1;
        private DataDynamics.ActiveReports.Line line2;
        private DataDynamics.ActiveReports.TextBox txtPackingName;
        private DataDynamics.ActiveReports.TextBox txtBoxes;
        private DataDynamics.ActiveReports.Label lblBoxes;
        private DataDynamics.ActiveReports.Label lblDateValid;
        private DataDynamics.ActiveReports.TextBox txtDateValid;
        private DataDynamics.ActiveReports.TextBox txtGoodStateName;
        private DataDynamics.ActiveReports.ReportInfo reportInfo2;
        private DataDynamics.ActiveReports.ReportInfo reportInfo1;
        private DataDynamics.ActiveReports.TextBox txtCellAddress;
    }
}
