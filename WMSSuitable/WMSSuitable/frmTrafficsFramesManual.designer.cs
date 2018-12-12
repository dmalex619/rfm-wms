namespace WMSSuitable
{
	partial class frmTrafficsFramesManual
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
            this.numPriority = new RFMBaseClasses.RFMNumericUpDown();
            this.txtFrameBarCode = new RFMBaseClasses.RFMTextBoxBarCode();
            this.lblPriority = new RFMBaseClasses.RFMLabel();
            this.txtFrameID4 = new RFMBaseClasses.RFMTextBoxNumeric();
            this.lblTo = new RFMBaseClasses.RFMLabel();
            this.lblFrameGoodState = new RFMBaseClasses.RFMLabel();
            this.lblFrameOwner = new RFMBaseClasses.RFMLabel();
            this.txtFrameGoodState = new RFMBaseClasses.RFMTextBox();
            this.chkStereo = new RFMBaseClasses.RFMCheckBox();
            this.txtFrameOwner = new RFMBaseClasses.RFMTextBox();
            this.lblFrom = new RFMBaseClasses.RFMLabel();
            this.pnlSource = new RFMBaseClasses.RFMPanel();
            this.cboBufferCellSourceAddress = new RFMBaseClasses.RFMComboBox();
            this.cboCellSourceAddress = new RFMBaseClasses.RFMComboBox();
            this.lblCellSource = new RFMBaseClasses.RFMLabel();
            this.lblBufferCellSource = new RFMBaseClasses.RFMLabel();
            this.cboStoresZonesTypesSource = new RFMBaseClasses.RFMComboBox();
            this.lblStoresZonesSource = new RFMBaseClasses.RFMLabel();
            this.cboStoresZonesSource = new RFMBaseClasses.RFMComboBox();
            this.lblFrame = new RFMBaseClasses.RFMLabel();
            this.pnlTarget = new RFMBaseClasses.RFMPanel();
            this.lblCellTarget = new RFMBaseClasses.RFMLabel();
            this.cboCellTargetAddress = new RFMBaseClasses.RFMComboBox();
            this.lblStoresZonesTarget = new RFMBaseClasses.RFMLabel();
            this.cboBufferCellTargetAddress = new RFMBaseClasses.RFMComboBox();
            this.lblBufferCellTarget = new RFMBaseClasses.RFMLabel();
            this.cboStoresZonesTarget = new RFMBaseClasses.RFMComboBox();
            this.cboStoresZonesTypesTarget = new RFMBaseClasses.RFMComboBox();
            this.pnlOpgTarget = new RFMBaseClasses.RFMPanel();
            this.chkFrameDestroy = new RFMBaseClasses.RFMCheckBox();
            this.optStoreZoneTarget = new RFMBaseClasses.RFMRadioButton();
            this.optCellTarget = new RFMBaseClasses.RFMRadioButton();
            this.btnGo = new RFMBaseClasses.RFMButton();
            this.btnHelp = new RFMBaseClasses.RFMButton();
            this.btnCancel = new RFMBaseClasses.RFMButton();
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPriority)).BeginInit();
            this.pnlSource.SuspendLayout();
            this.pnlTarget.SuspendLayout();
            this.pnlOpgTarget.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlData
            // 
            this.pnlData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlData.Controls.Add(this.numPriority);
            this.pnlData.Controls.Add(this.txtFrameBarCode);
            this.pnlData.Controls.Add(this.lblPriority);
            this.pnlData.Controls.Add(this.txtFrameID4);
            this.pnlData.Controls.Add(this.lblTo);
            this.pnlData.Controls.Add(this.lblFrameGoodState);
            this.pnlData.Controls.Add(this.lblFrameOwner);
            this.pnlData.Controls.Add(this.txtFrameGoodState);
            this.pnlData.Controls.Add(this.chkStereo);
            this.pnlData.Controls.Add(this.txtFrameOwner);
            this.pnlData.Controls.Add(this.lblFrom);
            this.pnlData.Controls.Add(this.pnlSource);
            this.pnlData.Controls.Add(this.lblFrame);
            this.pnlData.Controls.Add(this.pnlTarget);
            this.pnlData.Location = new System.Drawing.Point(6, 6);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(565, 273);
            this.pnlData.TabIndex = 0;
            // 
            // numPriority
            // 
            this.numPriority.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.numPriority.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.numPriority.InputMask = "#";
            this.numPriority.IsNull = false;
            this.numPriority.Location = new System.Drawing.Point(403, 6);
            this.numPriority.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numPriority.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPriority.Name = "numPriority";
            this.numPriority.RealPlaces = 1;
            this.numPriority.Size = new System.Drawing.Size(41, 22);
            this.numPriority.TabIndex = 18;
            this.numPriority.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numPriority.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // txtFrameBarCode
            // 
            this.txtFrameBarCode.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtFrameBarCode.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFrameBarCode.Location = new System.Drawing.Point(142, 6);
            this.txtFrameBarCode.MaxLength = 18;
            this.txtFrameBarCode.Name = "txtFrameBarCode";
            this.txtFrameBarCode.Size = new System.Drawing.Size(172, 22);
            this.txtFrameBarCode.TabIndex = 2;
            this.ttToolTip.SetToolTip(this.txtFrameBarCode, "Штрих-код контейнера");
            this.txtFrameBarCode.TextChanged += new System.EventHandler(this.txtFrameBarCode_TextChanged);
            this.txtFrameBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFrameBarCode_KeyDown);
            this.txtFrameBarCode.Validating += new System.ComponentModel.CancelEventHandler(this.txtFrameBarCode_Validating);
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblPriority.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblPriority.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPriority.Location = new System.Drawing.Point(329, 9);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(69, 14);
            this.lblPriority.TabIndex = 17;
            this.lblPriority.Text = "Приоритет";
            // 
            // txtFrameID4
            // 
            this.txtFrameID4.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtFrameID4.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFrameID4.Location = new System.Drawing.Point(85, 6);
            this.txtFrameID4.MaxLength = 4;
            this.txtFrameID4.Name = "txtFrameID4";
            this.txtFrameID4.Size = new System.Drawing.Size(50, 22);
            this.txtFrameID4.TabIndex = 1;
            this.txtFrameID4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ttToolTip.SetToolTip(this.txtFrameID4, "Код контейнера (4 знака, с ведущими нулями)");
            this.txtFrameID4.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtFrameID4.TextChanged += new System.EventHandler(this.txtFrameID4_TextChanged);
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblTo.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblTo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTo.Location = new System.Drawing.Point(7, 144);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(37, 14);
            this.lblTo.TabIndex = 10;
            this.lblTo.Text = "Куда:";
            // 
            // lblFrameGoodState
            // 
            this.lblFrameGoodState.AutoSize = true;
            this.lblFrameGoodState.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblFrameGoodState.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblFrameGoodState.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFrameGoodState.Location = new System.Drawing.Point(238, 39);
            this.lblFrameGoodState.Name = "lblFrameGoodState";
            this.lblFrameGoodState.Size = new System.Drawing.Size(68, 14);
            this.lblFrameGoodState.TabIndex = 6;
            this.lblFrameGoodState.Text = "Состояние";
            // 
            // lblFrameOwner
            // 
            this.lblFrameOwner.AutoSize = true;
            this.lblFrameOwner.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblFrameOwner.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblFrameOwner.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFrameOwner.Location = new System.Drawing.Point(7, 39);
            this.lblFrameOwner.Name = "lblFrameOwner";
            this.lblFrameOwner.Size = new System.Drawing.Size(67, 14);
            this.lblFrameOwner.TabIndex = 4;
            this.lblFrameOwner.Text = "Хранитель";
            // 
            // txtFrameGoodState
            // 
            this.txtFrameGoodState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFrameGoodState.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtFrameGoodState.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFrameGoodState.Enabled = false;
            this.txtFrameGoodState.Location = new System.Drawing.Point(312, 35);
            this.txtFrameGoodState.Name = "txtFrameGoodState";
            this.txtFrameGoodState.Size = new System.Drawing.Size(132, 22);
            this.txtFrameGoodState.TabIndex = 7;
            // 
            // chkStereo
            // 
            this.chkStereo.AutoSize = true;
            this.chkStereo.Enabled = false;
            this.chkStereo.Location = new System.Drawing.Point(455, 38);
            this.chkStereo.Name = "chkStereo";
            this.chkStereo.Size = new System.Drawing.Size(102, 18);
            this.chkStereo.TabIndex = 3;
            this.chkStereo.Text = "разный товар";
            this.chkStereo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkStereo.UseVisualStyleBackColor = true;
            // 
            // txtFrameOwner
            // 
            this.txtFrameOwner.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtFrameOwner.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFrameOwner.Location = new System.Drawing.Point(85, 35);
            this.txtFrameOwner.Name = "txtFrameOwner";
            this.txtFrameOwner.Size = new System.Drawing.Size(143, 22);
            this.txtFrameOwner.TabIndex = 5;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblFrom.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblFrom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFrom.Location = new System.Drawing.Point(7, 65);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(51, 14);
            this.lblFrom.TabIndex = 8;
            this.lblFrom.Text = "Откуда:";
            // 
            // pnlSource
            // 
            this.pnlSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSource.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlSource.Controls.Add(this.cboBufferCellSourceAddress);
            this.pnlSource.Controls.Add(this.cboCellSourceAddress);
            this.pnlSource.Controls.Add(this.lblCellSource);
            this.pnlSource.Controls.Add(this.lblBufferCellSource);
            this.pnlSource.Controls.Add(this.cboStoresZonesTypesSource);
            this.pnlSource.Controls.Add(this.lblStoresZonesSource);
            this.pnlSource.Controls.Add(this.cboStoresZonesSource);
            this.pnlSource.Location = new System.Drawing.Point(7, 75);
            this.pnlSource.Name = "pnlSource";
            this.pnlSource.Size = new System.Drawing.Size(548, 62);
            this.pnlSource.TabIndex = 9;
            // 
            // cboBufferCellSourceAddress
            // 
            this.cboBufferCellSourceAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboBufferCellSourceAddress.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.cboBufferCellSourceAddress.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.cboBufferCellSourceAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBufferCellSourceAddress.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboBufferCellSourceAddress.FormattingEnabled = true;
            this.cboBufferCellSourceAddress.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
            this.cboBufferCellSourceAddress.Location = new System.Drawing.Point(347, 6);
            this.cboBufferCellSourceAddress.Name = "cboBufferCellSourceAddress";
            this.cboBufferCellSourceAddress.Size = new System.Drawing.Size(192, 22);
            this.cboBufferCellSourceAddress.TabIndex = 3;
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
            this.cboCellSourceAddress.Location = new System.Drawing.Point(105, 6);
            this.cboCellSourceAddress.Name = "cboCellSourceAddress";
            this.cboCellSourceAddress.Size = new System.Drawing.Size(160, 22);
            this.cboCellSourceAddress.TabIndex = 1;
            // 
            // lblCellSource
            // 
            this.lblCellSource.AutoSize = true;
            this.lblCellSource.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblCellSource.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblCellSource.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCellSource.Location = new System.Drawing.Point(6, 9);
            this.lblCellSource.Name = "lblCellSource";
            this.lblCellSource.Size = new System.Drawing.Size(47, 14);
            this.lblCellSource.TabIndex = 0;
            this.lblCellSource.Text = "Ячейка";
            // 
            // lblBufferCellSource
            // 
            this.lblBufferCellSource.AutoSize = true;
            this.lblBufferCellSource.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblBufferCellSource.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblBufferCellSource.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBufferCellSource.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBufferCellSource.Location = new System.Drawing.Point(300, 9);
            this.lblBufferCellSource.Name = "lblBufferCellSource";
            this.lblBufferCellSource.Size = new System.Drawing.Size(44, 14);
            this.lblBufferCellSource.TabIndex = 2;
            this.lblBufferCellSource.Text = "Буфер";
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
            this.cboStoresZonesTypesSource.Location = new System.Drawing.Point(347, 31);
            this.cboStoresZonesTypesSource.Name = "cboStoresZonesTypesSource";
            this.cboStoresZonesTypesSource.Size = new System.Drawing.Size(192, 22);
            this.cboStoresZonesTypesSource.TabIndex = 6;
            // 
            // lblStoresZonesSource
            // 
            this.lblStoresZonesSource.AutoSize = true;
            this.lblStoresZonesSource.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblStoresZonesSource.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblStoresZonesSource.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStoresZonesSource.Location = new System.Drawing.Point(6, 34);
            this.lblStoresZonesSource.Name = "lblStoresZonesSource";
            this.lblStoresZonesSource.Size = new System.Drawing.Size(94, 14);
            this.lblStoresZonesSource.TabIndex = 4;
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
            this.cboStoresZonesSource.Location = new System.Drawing.Point(105, 31);
            this.cboStoresZonesSource.Name = "cboStoresZonesSource";
            this.cboStoresZonesSource.Size = new System.Drawing.Size(234, 22);
            this.cboStoresZonesSource.TabIndex = 5;
            // 
            // lblFrame
            // 
            this.lblFrame.AutoSize = true;
            this.lblFrame.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblFrame.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblFrame.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFrame.Location = new System.Drawing.Point(7, 9);
            this.lblFrame.Name = "lblFrame";
            this.lblFrame.Size = new System.Drawing.Size(69, 14);
            this.lblFrame.TabIndex = 0;
            this.lblFrame.Text = "Контейнер";
            // 
            // pnlTarget
            // 
            this.pnlTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTarget.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlTarget.Controls.Add(this.lblCellTarget);
            this.pnlTarget.Controls.Add(this.cboCellTargetAddress);
            this.pnlTarget.Controls.Add(this.lblStoresZonesTarget);
            this.pnlTarget.Controls.Add(this.cboBufferCellTargetAddress);
            this.pnlTarget.Controls.Add(this.lblBufferCellTarget);
            this.pnlTarget.Controls.Add(this.cboStoresZonesTarget);
            this.pnlTarget.Controls.Add(this.cboStoresZonesTypesTarget);
            this.pnlTarget.Controls.Add(this.pnlOpgTarget);
            this.pnlTarget.Location = new System.Drawing.Point(7, 155);
            this.pnlTarget.Name = "pnlTarget";
            this.pnlTarget.Size = new System.Drawing.Size(548, 108);
            this.pnlTarget.TabIndex = 11;
            // 
            // lblCellTarget
            // 
            this.lblCellTarget.AutoSize = true;
            this.lblCellTarget.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblCellTarget.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblCellTarget.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCellTarget.Location = new System.Drawing.Point(58, 80);
            this.lblCellTarget.Name = "lblCellTarget";
            this.lblCellTarget.Size = new System.Drawing.Size(47, 14);
            this.lblCellTarget.TabIndex = 2;
            this.lblCellTarget.Text = "ячейка";
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
            this.cboCellTargetAddress.Location = new System.Drawing.Point(105, 77);
            this.cboCellTargetAddress.Name = "cboCellTargetAddress";
            this.cboCellTargetAddress.Size = new System.Drawing.Size(160, 22);
            this.cboCellTargetAddress.TabIndex = 2;
            this.cboCellTargetAddress.SelectedIndexChanged += new System.EventHandler(this.cboCellTargetAddress_SelectedIndexChanged);
            // 
            // lblStoresZonesTarget
            // 
            this.lblStoresZonesTarget.AutoSize = true;
            this.lblStoresZonesTarget.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblStoresZonesTarget.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblStoresZonesTarget.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStoresZonesTarget.Location = new System.Drawing.Point(12, 55);
            this.lblStoresZonesTarget.Name = "lblStoresZonesTarget";
            this.lblStoresZonesTarget.Size = new System.Drawing.Size(93, 14);
            this.lblStoresZonesTarget.TabIndex = 0;
            this.lblStoresZonesTarget.Text = "складская зона";
            // 
            // cboBufferCellTargetAddress
            // 
            this.cboBufferCellTargetAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboBufferCellTargetAddress.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.cboBufferCellTargetAddress.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.cboBufferCellTargetAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBufferCellTargetAddress.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboBufferCellTargetAddress.FormattingEnabled = true;
            this.cboBufferCellTargetAddress.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
            this.cboBufferCellTargetAddress.Location = new System.Drawing.Point(347, 77);
            this.cboBufferCellTargetAddress.Name = "cboBufferCellTargetAddress";
            this.cboBufferCellTargetAddress.Size = new System.Drawing.Size(192, 22);
            this.cboBufferCellTargetAddress.TabIndex = 5;
            // 
            // lblBufferCellTarget
            // 
            this.lblBufferCellTarget.AutoSize = true;
            this.lblBufferCellTarget.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblBufferCellTarget.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblBufferCellTarget.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBufferCellTarget.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBufferCellTarget.Location = new System.Drawing.Point(300, 82);
            this.lblBufferCellTarget.Name = "lblBufferCellTarget";
            this.lblBufferCellTarget.Size = new System.Drawing.Size(44, 14);
            this.lblBufferCellTarget.TabIndex = 4;
            this.lblBufferCellTarget.Text = "Буфер";
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
            this.cboStoresZonesTarget.Location = new System.Drawing.Point(105, 52);
            this.cboStoresZonesTarget.Name = "cboStoresZonesTarget";
            this.cboStoresZonesTarget.Size = new System.Drawing.Size(234, 22);
            this.cboStoresZonesTarget.TabIndex = 1;
            this.cboStoresZonesTarget.SelectionChangeCommitted += new System.EventHandler(this.cboStoresZonesTarget_SelectionChangeCommited);
            // 
            // cboStoresZonesTypesTarget
            // 
            this.cboStoresZonesTypesTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboStoresZonesTypesTarget.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.cboStoresZonesTypesTarget.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.cboStoresZonesTypesTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStoresZonesTypesTarget.FormattingEnabled = true;
            this.cboStoresZonesTypesTarget.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
            this.cboStoresZonesTypesTarget.Location = new System.Drawing.Point(347, 52);
            this.cboStoresZonesTypesTarget.Name = "cboStoresZonesTypesTarget";
            this.cboStoresZonesTypesTarget.Size = new System.Drawing.Size(192, 22);
            this.cboStoresZonesTypesTarget.TabIndex = 2;
            // 
            // pnlOpgTarget
            // 
            this.pnlOpgTarget.Controls.Add(this.chkFrameDestroy);
            this.pnlOpgTarget.Controls.Add(this.optStoreZoneTarget);
            this.pnlOpgTarget.Controls.Add(this.optCellTarget);
            this.pnlOpgTarget.Location = new System.Drawing.Point(4, 3);
            this.pnlOpgTarget.Name = "pnlOpgTarget";
            this.pnlOpgTarget.Size = new System.Drawing.Size(334, 48);
            this.pnlOpgTarget.TabIndex = 3;
            // 
            // chkFrameDestroy
            // 
            this.chkFrameDestroy.AutoSize = true;
            this.chkFrameDestroy.Location = new System.Drawing.Point(170, 25);
            this.chkFrameDestroy.Name = "chkFrameDestroy";
            this.chkFrameDestroy.Size = new System.Drawing.Size(148, 18);
            this.chkFrameDestroy.TabIndex = 4;
            this.chkFrameDestroy.Text = "разобрать контейнер";
            this.chkFrameDestroy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkFrameDestroy.UseVisualStyleBackColor = true;
            this.chkFrameDestroy.CheckedChanged += new System.EventHandler(this.chkFrameDestroy_CheckedChanged);
            // 
            // optStoreZoneTarget
            // 
            this.optStoreZoneTarget.AutoSize = true;
            this.optStoreZoneTarget.Checked = true;
            this.optStoreZoneTarget.IsChanged = true;
            this.optStoreZoneTarget.Location = new System.Drawing.Point(3, 4);
            this.optStoreZoneTarget.Name = "optStoreZoneTarget";
            this.optStoreZoneTarget.Size = new System.Drawing.Size(314, 18);
            this.optStoreZoneTarget.TabIndex = 0;
            this.optStoreZoneTarget.TabStop = true;
            this.optStoreZoneTarget.Text = "любая подходящая ячейка длительного хранения";
            this.optStoreZoneTarget.UseVisualStyleBackColor = true;
            this.optStoreZoneTarget.CheckedChanged += new System.EventHandler(this.optCellTarget_CheckedChanged);
            // 
            // optCellTarget
            // 
            this.optCellTarget.AutoSize = true;
            this.optCellTarget.Location = new System.Drawing.Point(3, 24);
            this.optCellTarget.Name = "optCellTarget";
            this.optCellTarget.Size = new System.Drawing.Size(135, 18);
            this.optCellTarget.TabIndex = 1;
            this.optCellTarget.Text = "конкретная ячейка";
            this.optCellTarget.UseVisualStyleBackColor = true;
            this.optCellTarget.CheckedChanged += new System.EventHandler(this.optCellTarget_CheckedChanged);
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Image = global::WMSSuitable.Properties.Resources.Go;
            this.btnGo.Location = new System.Drawing.Point(504, 287);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(30, 30);
            this.btnGo.TabIndex = 1;
            this.btnGo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ttToolTip.SetToolTip(this.btnGo, "Создать операцию транспортировки контейнера");
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHelp.Image = global::WMSSuitable.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(6, 287);
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
            this.btnCancel.Location = new System.Drawing.Point(541, 287);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(30, 30);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmTrafficsFramesManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(578, 323);
            this.Controls.Add(this.pnlData);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnGo);
            this.hpHelp.SetHelpKeyword(this, "411");
            this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.IsModalMode = true;
            this.Name = "frmTrafficsFramesManual";
            this.hpHelp.SetShowHelp(this, true);
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Транспортировка поддона";
            this.Load += new System.EventHandler(this.frmTrafficManual_Load);
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPriority)).EndInit();
            this.pnlSource.ResumeLayout(false);
            this.pnlSource.PerformLayout();
            this.pnlTarget.ResumeLayout(false);
            this.pnlTarget.PerformLayout();
            this.pnlOpgTarget.ResumeLayout(false);
            this.pnlOpgTarget.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private RFMBaseClasses.RFMButton btnGo;
        private RFMBaseClasses.RFMButton btnCancel;
        private RFMBaseClasses.RFMButton btnHelp;
		private RFMBaseClasses.RFMPanel pnlData;
		private RFMBaseClasses.RFMLabel lblFrame;
		private RFMBaseClasses.RFMLabel lblFrom;
		private RFMBaseClasses.RFMPanel pnlTarget;
		private RFMBaseClasses.RFMComboBox cboStoresZonesTypesTarget;
		private RFMBaseClasses.RFMLabel lblStoresZonesTarget;
		private RFMBaseClasses.RFMComboBox cboStoresZonesTarget;
		private RFMBaseClasses.RFMPanel pnlSource;
		private RFMBaseClasses.RFMLabel lblCellSource;
		private RFMBaseClasses.RFMLabel lblBufferCellSource;
		private RFMBaseClasses.RFMComboBox cboStoresZonesTypesSource;
		private RFMBaseClasses.RFMLabel lblStoresZonesSource;
		private RFMBaseClasses.RFMComboBox cboStoresZonesSource;
		private RFMBaseClasses.RFMTextBox txtFrameGoodState;
		private RFMBaseClasses.RFMCheckBox chkStereo;
		private RFMBaseClasses.RFMTextBox txtFrameOwner;
		private RFMBaseClasses.RFMLabel lblFrameGoodState;
		private RFMBaseClasses.RFMLabel lblFrameOwner;
		private RFMBaseClasses.RFMPanel pnlOpgTarget;
		private RFMBaseClasses.RFMRadioButton optStoreZoneTarget;
		private RFMBaseClasses.RFMRadioButton optCellTarget;
		private RFMBaseClasses.RFMComboBox cboCellSourceAddress;
		private RFMBaseClasses.RFMComboBox cboCellTargetAddress;
		private RFMBaseClasses.RFMComboBox cboBufferCellSourceAddress;
		private RFMBaseClasses.RFMLabel lblTo;
		private RFMBaseClasses.RFMComboBox cboBufferCellTargetAddress;
		private RFMBaseClasses.RFMLabel lblBufferCellTarget;
		private RFMBaseClasses.RFMTextBoxNumeric txtFrameID4;
		private RFMBaseClasses.RFMTextBoxBarCode txtFrameBarCode;
		private RFMBaseClasses.RFMLabel lblCellTarget;
		private RFMBaseClasses.RFMCheckBox chkFrameDestroy;
		private RFMBaseClasses.RFMNumericUpDown numPriority;
		private RFMBaseClasses.RFMLabel lblPriority;
	}
}