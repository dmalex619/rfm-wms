namespace WMSSuitable
{
	partial class frmTrafficsGoodsManual
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.pnlData = new RFMBaseClasses.RFMPanel();
			this.lblRestQntWished = new RFMBaseClasses.RFMLabel();
			this.numRestQntWished = new RFMBaseClasses.RFMNumericUpDown();
			this.lblBoxWished = new RFMBaseClasses.RFMLabel();
			this.numBoxWished = new RFMBaseClasses.RFMNumericUpDown();
			this.lblRestQntExists = new RFMBaseClasses.RFMLabel();
			this.numRestQntExists = new RFMBaseClasses.RFMNumericUpDown();
			this.lblBoxExists = new RFMBaseClasses.RFMLabel();
			this.numBoxExists = new RFMBaseClasses.RFMNumericUpDown();
			this.lblWished = new RFMBaseClasses.RFMLabel();
			this.dtpDateValid = new RFMBaseClasses.RFMDateTimePicker();
			this.lblDateValid = new RFMBaseClasses.RFMLabel();
			this.txtGoodState = new RFMBaseClasses.RFMTextBox();
			this.txtOwner = new RFMBaseClasses.RFMTextBox();
			this.cboGood = new RFMBaseClasses.RFMComboBox();
			this.lblExists = new RFMBaseClasses.RFMLabel();
			this.lblGood = new RFMBaseClasses.RFMLabel();
			this.lblTo = new RFMBaseClasses.RFMLabel();
			this.lblFrameGoodState = new RFMBaseClasses.RFMLabel();
			this.lblFrameOwner = new RFMBaseClasses.RFMLabel();
			this.lblFrom = new RFMBaseClasses.RFMLabel();
			this.pnlSource = new RFMBaseClasses.RFMPanel();
			this.cboCellSourceAddress = new RFMBaseClasses.RFMComboBox();
			this.lblCellSource = new RFMBaseClasses.RFMLabel();
			this.cboStoresZonesTypesSource = new RFMBaseClasses.RFMComboBox();
			this.lblStoresZonesSource = new RFMBaseClasses.RFMLabel();
			this.cboStoresZonesSource = new RFMBaseClasses.RFMComboBox();
			this.pnlTarget = new RFMBaseClasses.RFMPanel();
			this.lblCellTarget = new RFMBaseClasses.RFMLabel();
			this.cboCellTargetAddress = new RFMBaseClasses.RFMComboBox();
			this.cboStoresZonesTarget = new RFMBaseClasses.RFMComboBox();
			this.cboStoresZonesTypesTarget = new RFMBaseClasses.RFMComboBox();
			this.lblStoresZonesTarget = new RFMBaseClasses.RFMLabel();
			this.btnGo = new RFMBaseClasses.RFMButton();
			this.btnHelp = new RFMBaseClasses.RFMButton();
			this.btnCancel = new RFMBaseClasses.RFMButton();
			this.pnlData.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numRestQntWished)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numBoxWished)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numRestQntExists)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numBoxExists)).BeginInit();
			this.pnlSource.SuspendLayout();
			this.pnlTarget.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlData
			// 
			this.pnlData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
							| System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlData.Controls.Add(this.lblRestQntWished);
			this.pnlData.Controls.Add(this.numRestQntWished);
			this.pnlData.Controls.Add(this.lblBoxWished);
			this.pnlData.Controls.Add(this.numBoxWished);
			this.pnlData.Controls.Add(this.lblRestQntExists);
			this.pnlData.Controls.Add(this.numRestQntExists);
			this.pnlData.Controls.Add(this.lblBoxExists);
			this.pnlData.Controls.Add(this.numBoxExists);
			this.pnlData.Controls.Add(this.lblWished);
			this.pnlData.Controls.Add(this.dtpDateValid);
			this.pnlData.Controls.Add(this.lblDateValid);
			this.pnlData.Controls.Add(this.txtGoodState);
			this.pnlData.Controls.Add(this.txtOwner);
			this.pnlData.Controls.Add(this.cboGood);
			this.pnlData.Controls.Add(this.lblExists);
			this.pnlData.Controls.Add(this.lblGood);
			this.pnlData.Controls.Add(this.lblTo);
			this.pnlData.Controls.Add(this.lblFrameGoodState);
			this.pnlData.Controls.Add(this.lblFrameOwner);
			this.pnlData.Controls.Add(this.lblFrom);
			this.pnlData.Controls.Add(this.pnlSource);
			this.pnlData.Controls.Add(this.pnlTarget);
			this.pnlData.Location = new System.Drawing.Point(6, 6);
			this.pnlData.Name = "pnlData";
			this.pnlData.Size = new System.Drawing.Size(529, 307);
			this.pnlData.TabIndex = 0;
			// 
			// lblRestQntWished
			// 
			this.lblRestQntWished.AutoSize = true;
			this.lblRestQntWished.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblRestQntWished.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblRestQntWished.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblRestQntWished.Location = new System.Drawing.Point(339, 142);
			this.lblRestQntWished.Name = "lblRestQntWished";
			this.lblRestQntWished.Size = new System.Drawing.Size(41, 14);
			this.lblRestQntWished.TabIndex = 26;
			this.lblRestQntWished.Text = "шт./кг";
			// 
			// numRestQntWished
			// 
			this.numRestQntWished.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.numRestQntWished.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.numRestQntWished.IsNull = false;
			this.numRestQntWished.Location = new System.Drawing.Point(228, 138);
			this.numRestQntWished.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
			this.numRestQntWished.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
			this.numRestQntWished.Name = "numRestQntWished";
			this.numRestQntWished.Size = new System.Drawing.Size(110, 22);
			this.numRestQntWished.TabIndex = 25;
			this.numRestQntWished.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.ttToolTip.SetToolTip(this.numRestQntWished, "Дополнительно штук в нецелой коробке / кг");
			// 
			// lblBoxWished
			// 
			this.lblBoxWished.AutoSize = true;
			this.lblBoxWished.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblBoxWished.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblBoxWished.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblBoxWished.Location = new System.Drawing.Point(175, 142);
			this.lblBoxWished.Name = "lblBoxWished";
			this.lblBoxWished.Size = new System.Drawing.Size(47, 14);
			this.lblBoxWished.TabIndex = 24;
			this.lblBoxWished.Text = "кор. + ";
			// 
			// numBoxWished
			// 
			this.numBoxWished.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.numBoxWished.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.numBoxWished.IsNull = false;
			this.numBoxWished.Location = new System.Drawing.Point(112, 138);
			this.numBoxWished.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
			this.numBoxWished.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
			this.numBoxWished.Name = "numBoxWished";
			this.numBoxWished.Size = new System.Drawing.Size(60, 22);
			this.numBoxWished.TabIndex = 23;
			this.numBoxWished.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.ttToolTip.SetToolTip(this.numBoxWished, "количество целых коробок");
			// 
			// lblRestQntExists
			// 
			this.lblRestQntExists.AutoSize = true;
			this.lblRestQntExists.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblRestQntExists.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblRestQntExists.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblRestQntExists.Location = new System.Drawing.Point(339, 115);
			this.lblRestQntExists.Name = "lblRestQntExists";
			this.lblRestQntExists.Size = new System.Drawing.Size(41, 14);
			this.lblRestQntExists.TabIndex = 22;
			this.lblRestQntExists.Text = "шт./кг";
			// 
			// numRestQntExists
			// 
			this.numRestQntExists.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.numRestQntExists.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.numRestQntExists.Enabled = false;
			this.numRestQntExists.IsNull = false;
			this.numRestQntExists.Location = new System.Drawing.Point(228, 111);
			this.numRestQntExists.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
			this.numRestQntExists.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
			this.numRestQntExists.Name = "numRestQntExists";
			this.numRestQntExists.Size = new System.Drawing.Size(110, 22);
			this.numRestQntExists.TabIndex = 21;
			this.numRestQntExists.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.ttToolTip.SetToolTip(this.numRestQntExists, "Дополнительно штук в нецелой коробке / кг");
			// 
			// lblBoxExists
			// 
			this.lblBoxExists.AutoSize = true;
			this.lblBoxExists.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblBoxExists.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblBoxExists.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblBoxExists.Location = new System.Drawing.Point(175, 115);
			this.lblBoxExists.Name = "lblBoxExists";
			this.lblBoxExists.Size = new System.Drawing.Size(47, 14);
			this.lblBoxExists.TabIndex = 20;
			this.lblBoxExists.Text = "кор. + ";
			// 
			// numBoxExists
			// 
			this.numBoxExists.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.numBoxExists.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.numBoxExists.Enabled = false;
			this.numBoxExists.IsNull = false;
			this.numBoxExists.Location = new System.Drawing.Point(112, 111);
			this.numBoxExists.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
			this.numBoxExists.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
			this.numBoxExists.Name = "numBoxExists";
			this.numBoxExists.Size = new System.Drawing.Size(60, 22);
			this.numBoxExists.TabIndex = 19;
			this.numBoxExists.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.ttToolTip.SetToolTip(this.numBoxExists, "количество целых коробок");
			// 
			// lblWished
			// 
			this.lblWished.AutoSize = true;
			this.lblWished.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblWished.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblWished.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblWished.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblWished.Location = new System.Drawing.Point(6, 142);
			this.lblWished.Name = "lblWished";
			this.lblWished.Size = new System.Drawing.Size(88, 14);
			this.lblWished.TabIndex = 18;
			this.lblWished.Text = "Переместить";
			// 
			// dtpDateValid
			// 
			this.dtpDateValid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.dtpDateValid.CustomFormat = "dd.MM.yyyy";
			this.dtpDateValid.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.dtpDateValid.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.dtpDateValid.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpDateValid.Location = new System.Drawing.Point(112, 193);
			this.dtpDateValid.Name = "dtpDateValid";
			this.dtpDateValid.Size = new System.Drawing.Size(96, 22);
			this.dtpDateValid.TabIndex = 17;
			// 
			// lblDateValid
			// 
			this.lblDateValid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDateValid.AutoSize = true;
			this.lblDateValid.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblDateValid.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblDateValid.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblDateValid.Location = new System.Drawing.Point(6, 197);
			this.lblDateValid.Name = "lblDateValid";
			this.lblDateValid.Size = new System.Drawing.Size(90, 14);
			this.lblDateValid.TabIndex = 16;
			this.lblDateValid.Text = "Срок годности";
			// 
			// txtGoodState
			// 
			this.txtGoodState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.txtGoodState.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtGoodState.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtGoodState.Enabled = false;
			this.txtGoodState.Location = new System.Drawing.Point(350, 166);
			this.txtGoodState.Name = "txtGoodState";
			this.txtGoodState.Size = new System.Drawing.Size(160, 22);
			this.txtGoodState.TabIndex = 13;
			// 
			// txtOwner
			// 
			this.txtOwner.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtOwner.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtOwner.Enabled = false;
			this.txtOwner.Location = new System.Drawing.Point(112, 166);
			this.txtOwner.Name = "txtOwner";
			this.txtOwner.Size = new System.Drawing.Size(160, 22);
			this.txtOwner.TabIndex = 11;
			// 
			// cboGood
			// 
			this.cboGood.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.cboGood.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboGood.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboGood.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboGood.FormattingEnabled = true;
			this.cboGood.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboGood.Location = new System.Drawing.Point(112, 84);
			this.cboGood.Name = "cboGood";
			this.cboGood.Size = new System.Drawing.Size(408, 22);
			this.cboGood.TabIndex = 4;
			this.cboGood.SelectedIndexChanged += new System.EventHandler(this.cboGood_SelectedIndexChanged);
			// 
			// lblExists
			// 
			this.lblExists.AutoSize = true;
			this.lblExists.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblExists.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblExists.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblExists.Location = new System.Drawing.Point(6, 115);
			this.lblExists.Name = "lblExists";
			this.lblExists.Size = new System.Drawing.Size(102, 14);
			this.lblExists.TabIndex = 5;
			this.lblExists.Text = "Сейчас в ячейке";
			// 
			// lblGood
			// 
			this.lblGood.AutoSize = true;
			this.lblGood.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblGood.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblGood.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblGood.Location = new System.Drawing.Point(6, 87);
			this.lblGood.Name = "lblGood";
			this.lblGood.Size = new System.Drawing.Size(41, 14);
			this.lblGood.TabIndex = 2;
			this.lblGood.Text = "Товар";
			// 
			// lblTo
			// 
			this.lblTo.AutoSize = true;
			this.lblTo.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblTo.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblTo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblTo.Location = new System.Drawing.Point(6, 222);
			this.lblTo.Name = "lblTo";
			this.lblTo.Size = new System.Drawing.Size(37, 14);
			this.lblTo.TabIndex = 14;
			this.lblTo.Text = "Куда:";
			// 
			// lblFrameGoodState
			// 
			this.lblFrameGoodState.AutoSize = true;
			this.lblFrameGoodState.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblFrameGoodState.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblFrameGoodState.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblFrameGoodState.Location = new System.Drawing.Point(281, 169);
			this.lblFrameGoodState.Name = "lblFrameGoodState";
			this.lblFrameGoodState.Size = new System.Drawing.Size(68, 14);
			this.lblFrameGoodState.TabIndex = 12;
			this.lblFrameGoodState.Text = "Состояние";
			// 
			// lblFrameOwner
			// 
			this.lblFrameOwner.AutoSize = true;
			this.lblFrameOwner.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblFrameOwner.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblFrameOwner.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblFrameOwner.Location = new System.Drawing.Point(6, 169);
			this.lblFrameOwner.Name = "lblFrameOwner";
			this.lblFrameOwner.Size = new System.Drawing.Size(67, 14);
			this.lblFrameOwner.TabIndex = 10;
			this.lblFrameOwner.Text = "Хранитель";
			// 
			// lblFrom
			// 
			this.lblFrom.AutoSize = true;
			this.lblFrom.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblFrom.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblFrom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblFrom.Location = new System.Drawing.Point(6, 4);
			this.lblFrom.Name = "lblFrom";
			this.lblFrom.Size = new System.Drawing.Size(51, 14);
			this.lblFrom.TabIndex = 0;
			this.lblFrom.Text = "Откуда:";
			// 
			// pnlSource
			// 
			this.pnlSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlSource.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlSource.Controls.Add(this.cboCellSourceAddress);
			this.pnlSource.Controls.Add(this.lblCellSource);
			this.pnlSource.Controls.Add(this.cboStoresZonesTypesSource);
			this.pnlSource.Controls.Add(this.lblStoresZonesSource);
			this.pnlSource.Controls.Add(this.cboStoresZonesSource);
			this.pnlSource.Location = new System.Drawing.Point(6, 13);
			this.pnlSource.Name = "pnlSource";
			this.pnlSource.Size = new System.Drawing.Size(514, 63);
			this.pnlSource.TabIndex = 1;
			// 
			// cboCellSourceAddress
			// 
			this.cboCellSourceAddress.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboCellSourceAddress.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboCellSourceAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCellSourceAddress.FormattingEnabled = true;
			this.cboCellSourceAddress.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboCellSourceAddress.Location = new System.Drawing.Point(106, 32);
			this.cboCellSourceAddress.Name = "cboCellSourceAddress";
			this.cboCellSourceAddress.Size = new System.Drawing.Size(160, 22);
			this.cboCellSourceAddress.TabIndex = 4;
			this.cboCellSourceAddress.SelectedIndexChanged += new System.EventHandler(this.cboCellSourceAddress_SelectedIndexChanged);
			// 
			// lblCellSource
			// 
			this.lblCellSource.AutoSize = true;
			this.lblCellSource.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblCellSource.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblCellSource.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCellSource.Location = new System.Drawing.Point(2, 35);
			this.lblCellSource.Name = "lblCellSource";
			this.lblCellSource.Size = new System.Drawing.Size(47, 14);
			this.lblCellSource.TabIndex = 3;
			this.lblCellSource.Text = "Ячейка";
			// 
			// cboStoresZonesTypesSource
			// 
			this.cboStoresZonesTypesSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.cboStoresZonesTypesSource.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboStoresZonesTypesSource.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboStoresZonesTypesSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboStoresZonesTypesSource.FormattingEnabled = true;
			this.cboStoresZonesTypesSource.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboStoresZonesTypesSource.Location = new System.Drawing.Point(343, 7);
			this.cboStoresZonesTypesSource.Name = "cboStoresZonesTypesSource";
			this.cboStoresZonesTypesSource.Size = new System.Drawing.Size(160, 22);
			this.cboStoresZonesTypesSource.TabIndex = 2;
			// 
			// lblStoresZonesSource
			// 
			this.lblStoresZonesSource.AutoSize = true;
			this.lblStoresZonesSource.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblStoresZonesSource.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblStoresZonesSource.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblStoresZonesSource.Location = new System.Drawing.Point(2, 10);
			this.lblStoresZonesSource.Name = "lblStoresZonesSource";
			this.lblStoresZonesSource.Size = new System.Drawing.Size(94, 14);
			this.lblStoresZonesSource.TabIndex = 0;
			this.lblStoresZonesSource.Text = "Складская зона";
			// 
			// cboStoresZonesSource
			// 
			this.cboStoresZonesSource.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboStoresZonesSource.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboStoresZonesSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboStoresZonesSource.FormattingEnabled = true;
			this.cboStoresZonesSource.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboStoresZonesSource.Location = new System.Drawing.Point(106, 7);
			this.cboStoresZonesSource.Name = "cboStoresZonesSource";
			this.cboStoresZonesSource.Size = new System.Drawing.Size(230, 22);
			this.cboStoresZonesSource.TabIndex = 1;
			this.cboStoresZonesSource.SelectedIndexChanged += new System.EventHandler(this.cboStoresZonesSource_SelectedIndexChanged);
			// 
			// pnlTarget
			// 
			this.pnlTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlTarget.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlTarget.Controls.Add(this.lblCellTarget);
			this.pnlTarget.Controls.Add(this.cboCellTargetAddress);
			this.pnlTarget.Controls.Add(this.cboStoresZonesTarget);
			this.pnlTarget.Controls.Add(this.cboStoresZonesTypesTarget);
			this.pnlTarget.Controls.Add(this.lblStoresZonesTarget);
			this.pnlTarget.Location = new System.Drawing.Point(6, 233);
			this.pnlTarget.Name = "pnlTarget";
			this.pnlTarget.Size = new System.Drawing.Size(514, 64);
			this.pnlTarget.TabIndex = 15;
			// 
			// lblCellTarget
			// 
			this.lblCellTarget.AutoSize = true;
			this.lblCellTarget.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblCellTarget.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblCellTarget.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCellTarget.Location = new System.Drawing.Point(2, 35);
			this.lblCellTarget.Name = "lblCellTarget";
			this.lblCellTarget.Size = new System.Drawing.Size(47, 14);
			this.lblCellTarget.TabIndex = 3;
			this.lblCellTarget.Text = "Ячейка";
			// 
			// cboCellTargetAddress
			// 
			this.cboCellTargetAddress.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboCellTargetAddress.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboCellTargetAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCellTargetAddress.FormattingEnabled = true;
			this.cboCellTargetAddress.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboCellTargetAddress.Location = new System.Drawing.Point(104, 32);
			this.cboCellTargetAddress.Name = "cboCellTargetAddress";
			this.cboCellTargetAddress.Size = new System.Drawing.Size(160, 22);
			this.cboCellTargetAddress.TabIndex = 4;
			// 
			// cboStoresZonesTarget
			// 
			this.cboStoresZonesTarget.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboStoresZonesTarget.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboStoresZonesTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboStoresZonesTarget.FormattingEnabled = true;
			this.cboStoresZonesTarget.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboStoresZonesTarget.Location = new System.Drawing.Point(104, 6);
			this.cboStoresZonesTarget.Name = "cboStoresZonesTarget";
			this.cboStoresZonesTarget.Size = new System.Drawing.Size(230, 22);
			this.cboStoresZonesTarget.TabIndex = 1;
			this.cboStoresZonesTarget.SelectedIndexChanged += new System.EventHandler(this.cboStoresZonesTarget_SelectedIndexChanged);
			// 
			// cboStoresZonesTypesTarget
			// 
			this.cboStoresZonesTypesTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.cboStoresZonesTypesTarget.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboStoresZonesTypesTarget.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboStoresZonesTypesTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboStoresZonesTypesTarget.Enabled = false;
			this.cboStoresZonesTypesTarget.FormattingEnabled = true;
			this.cboStoresZonesTypesTarget.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboStoresZonesTypesTarget.Location = new System.Drawing.Point(341, 6);
			this.cboStoresZonesTypesTarget.Name = "cboStoresZonesTypesTarget";
			this.cboStoresZonesTypesTarget.Size = new System.Drawing.Size(163, 22);
			this.cboStoresZonesTypesTarget.TabIndex = 2;
			// 
			// lblStoresZonesTarget
			// 
			this.lblStoresZonesTarget.AutoSize = true;
			this.lblStoresZonesTarget.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblStoresZonesTarget.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblStoresZonesTarget.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblStoresZonesTarget.Location = new System.Drawing.Point(2, 9);
			this.lblStoresZonesTarget.Name = "lblStoresZonesTarget";
			this.lblStoresZonesTarget.Size = new System.Drawing.Size(94, 14);
			this.lblStoresZonesTarget.TabIndex = 0;
			this.lblStoresZonesTarget.Text = "Складская зона";
			// 
			// btnGo
			// 
			this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGo.Image = global::WMSSuitable.Properties.Resources.Go;
			this.btnGo.Location = new System.Drawing.Point(457, 321);
			this.btnGo.Name = "btnGo";
			this.btnGo.Size = new System.Drawing.Size(30, 30);
			this.btnGo.TabIndex = 1;
			this.btnGo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ttToolTip.SetToolTip(this.btnGo, "создать операции перемещения");
			this.btnGo.UseVisualStyleBackColor = true;
			this.btnGo.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnHelp
			// 
			this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnHelp.Image = global::WMSSuitable.Properties.Resources.Help;
			this.btnHelp.Location = new System.Drawing.Point(6, 321);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new System.Drawing.Size(30, 30);
			this.btnHelp.TabIndex = 3;
			this.btnHelp.UseVisualStyleBackColor = true;
			this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.No;
			this.btnCancel.Image = global::WMSSuitable.Properties.Resources.Exit;
			this.btnCancel.Location = new System.Drawing.Point(505, 321);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(30, 30);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// frmTrafficsGoodsManual
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(542, 357);
			this.Controls.Add(this.pnlData);
			this.Controls.Add(this.btnHelp);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnGo);
			this.hpHelp.SetHelpKeyword(this, "461");
			this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.IsModalMode = true;
			this.Name = "frmTrafficsGoodsManual";
			this.hpHelp.SetShowHelp(this, true);
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Перемещение коробок/штук";
			this.Load += new System.EventHandler(this.frmTrafficManual_Load);
			this.pnlData.ResumeLayout(false);
			this.pnlData.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numRestQntWished)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numBoxWished)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numRestQntExists)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numBoxExists)).EndInit();
			this.pnlSource.ResumeLayout(false);
			this.pnlSource.PerformLayout();
			this.pnlTarget.ResumeLayout(false);
			this.pnlTarget.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

        private RFMBaseClasses.RFMButton btnGo;
        private RFMBaseClasses.RFMButton btnCancel;
        private RFMBaseClasses.RFMButton btnHelp;
		private RFMBaseClasses.RFMPanel pnlData;
		private RFMBaseClasses.RFMLabel lblFrom;
		private RFMBaseClasses.RFMPanel pnlTarget;
		private RFMBaseClasses.RFMComboBox cboStoresZonesTypesTarget;
		private RFMBaseClasses.RFMLabel lblStoresZonesTarget;
		private RFMBaseClasses.RFMComboBox cboStoresZonesTarget;
		private RFMBaseClasses.RFMPanel pnlSource;
		private RFMBaseClasses.RFMLabel lblCellSource;
		private RFMBaseClasses.RFMComboBox cboStoresZonesTypesSource;
		private RFMBaseClasses.RFMLabel lblStoresZonesSource;
		private RFMBaseClasses.RFMComboBox cboStoresZonesSource;
		private RFMBaseClasses.RFMLabel lblFrameGoodState;
		private RFMBaseClasses.RFMLabel lblFrameOwner;
		private RFMBaseClasses.RFMComboBox cboCellSourceAddress;
		private RFMBaseClasses.RFMLabel lblTo;
		private RFMBaseClasses.RFMLabel lblExists;
		private RFMBaseClasses.RFMLabel lblGood;
		private RFMBaseClasses.RFMComboBox cboGood;
		private RFMBaseClasses.RFMComboBox cboCellTargetAddress;
		private RFMBaseClasses.RFMLabel lblCellTarget;
		private RFMBaseClasses.RFMTextBox txtGoodState;
		private RFMBaseClasses.RFMTextBox txtOwner;
		private RFMBaseClasses.RFMDateTimePicker dtpDateValid;
		private RFMBaseClasses.RFMLabel lblDateValid;
		private RFMBaseClasses.RFMLabel lblRestQntExists;
		private RFMBaseClasses.RFMNumericUpDown numRestQntExists;
		private RFMBaseClasses.RFMLabel lblBoxExists;
		private RFMBaseClasses.RFMNumericUpDown numBoxExists;
		private RFMBaseClasses.RFMLabel lblWished;
		private RFMBaseClasses.RFMLabel lblRestQntWished;
		private RFMBaseClasses.RFMNumericUpDown numRestQntWished;
		private RFMBaseClasses.RFMLabel lblBoxWished;
		private RFMBaseClasses.RFMNumericUpDown numBoxWished;
	}
}