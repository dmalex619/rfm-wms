namespace WMSSuitable
{
	partial class frmTrafficsFramesEdit
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
			this.btnCancel = new RFMBaseClasses.RFMButton();
			this.btnSave = new RFMBaseClasses.RFMButton();
			this.btnHelp = new RFMBaseClasses.RFMButton();
			this.pnlData = new RFMBaseClasses.RFMPanel();
			this.txtFrameID4 = new RFMBaseClasses.RFMTextBoxNumeric();
			this.cboDevice = new RFMBaseClasses.RFMComboBox();
			this.lblFrameGoodState = new RFMBaseClasses.RFMLabel();
			this.lblFrameOwner = new RFMBaseClasses.RFMLabel();
			this.txtFrameGoodState = new RFMBaseClasses.RFMTextBox();
			this.chkStereo = new RFMBaseClasses.RFMCheckBox();
			this.txtFrameOwner = new RFMBaseClasses.RFMTextBox();
			this.lblTarget = new RFMBaseClasses.RFMLabel();
			this.lblFrom = new RFMBaseClasses.RFMLabel();
			this.txtFrameBarCode = new RFMBaseClasses.RFMTextBoxBarCode();
			this.lblFrame = new RFMBaseClasses.RFMLabel();
			this.numPriority = new RFMBaseClasses.RFMNumericUpDown();
			this.lblPriority = new RFMBaseClasses.RFMLabel();
			this.cboUser = new RFMBaseClasses.RFMComboBox();
			this.lblDevice = new RFMBaseClasses.RFMLabel();
			this.lblUser = new RFMBaseClasses.RFMLabel();
			this.pnlTarget = new RFMBaseClasses.RFMPanel();
			this.lblBufferCellTarget = new RFMBaseClasses.RFMLabel();
			this.cboBufferCellTargetAddress = new RFMBaseClasses.RFMComboBox();
			this.lblCellTarget = new RFMBaseClasses.RFMLabel();
			this.cboCellTargetAddress = new RFMBaseClasses.RFMComboBox();
			this.cboStoresZonesTarget = new RFMBaseClasses.RFMComboBox();
			this.cboStoresZonesTypesTarget = new RFMBaseClasses.RFMComboBox();
			this.lblStoresZonesTarget = new RFMBaseClasses.RFMLabel();
			this.pnlSource = new RFMBaseClasses.RFMPanel();
			this.lblBufferCellSource = new RFMBaseClasses.RFMLabel();
			this.cboBufferCellSourceAddress = new RFMBaseClasses.RFMComboBox();
			this.cboCellSourceAddress = new RFMBaseClasses.RFMComboBox();
			this.lblCellSource = new RFMBaseClasses.RFMLabel();
			this.cboStoresZonesTypesSource = new RFMBaseClasses.RFMComboBox();
			this.lblStoresZonesSource = new RFMBaseClasses.RFMLabel();
			this.cboStoresZonesSource = new RFMBaseClasses.RFMComboBox();
			this.pnlTrafficError = new RFMBaseClasses.RFMPanel();
			this.lblLockCell = new RFMBaseClasses.RFMLabel();
			this.chkLockCellSource = new RFMBaseClasses.RFMCheckBox();
			this.chkLockFrame = new RFMBaseClasses.RFMCheckBox();
			this.lblLock = new RFMBaseClasses.RFMLabel();
			this.chkLockCellFinish = new RFMBaseClasses.RFMCheckBox();
			this.pnlOpt = new RFMBaseClasses.RFMPanel();
			this.cboTrafficError = new RFMBaseClasses.RFMComboBox();
			this.optError = new RFMBaseClasses.RFMRadioButton();
			this.optCellTarget = new RFMBaseClasses.RFMRadioButton();
			this.optBufferCellTarget = new RFMBaseClasses.RFMRadioButton();
			this.optBufferCellSource = new RFMBaseClasses.RFMRadioButton();
			this.optNoChanges = new RFMBaseClasses.RFMRadioButton();
			this.pnlData.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numPriority)).BeginInit();
			this.pnlTarget.SuspendLayout();
			this.pnlSource.SuspendLayout();
			this.pnlTrafficError.SuspendLayout();
			this.pnlOpt.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Image = global::WMSSuitable.Properties.Resources.Exit;
			this.btnCancel.Location = new System.Drawing.Point(506, 419);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(30, 30);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Image = global::WMSSuitable.Properties.Resources.Save;
			this.btnSave.Location = new System.Drawing.Point(456, 419);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(30, 30);
			this.btnSave.TabIndex = 1;
			this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnHelp
			// 
			this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnHelp.Image = global::WMSSuitable.Properties.Resources.Help;
			this.btnHelp.Location = new System.Drawing.Point(5, 419);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new System.Drawing.Size(30, 30);
			this.btnHelp.TabIndex = 3;
			this.btnHelp.UseVisualStyleBackColor = true;
			this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
			// 
			// pnlData
			// 
			this.pnlData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlData.Controls.Add(this.txtFrameID4);
			this.pnlData.Controls.Add(this.cboDevice);
			this.pnlData.Controls.Add(this.lblFrameGoodState);
			this.pnlData.Controls.Add(this.lblFrameOwner);
			this.pnlData.Controls.Add(this.txtFrameGoodState);
			this.pnlData.Controls.Add(this.chkStereo);
			this.pnlData.Controls.Add(this.txtFrameOwner);
			this.pnlData.Controls.Add(this.lblTarget);
			this.pnlData.Controls.Add(this.lblFrom);
			this.pnlData.Controls.Add(this.txtFrameBarCode);
			this.pnlData.Controls.Add(this.lblFrame);
			this.pnlData.Controls.Add(this.numPriority);
			this.pnlData.Controls.Add(this.lblPriority);
			this.pnlData.Controls.Add(this.cboUser);
			this.pnlData.Controls.Add(this.lblDevice);
			this.pnlData.Controls.Add(this.lblUser);
			this.pnlData.Controls.Add(this.pnlTarget);
			this.pnlData.Controls.Add(this.pnlSource);
			this.pnlData.Controls.Add(this.pnlTrafficError);
			this.pnlData.Location = new System.Drawing.Point(5, 5);
			this.pnlData.Name = "pnlData";
			this.pnlData.Size = new System.Drawing.Size(533, 408);
			this.pnlData.TabIndex = 0;
			// 
			// txtFrameID4
			// 
			this.txtFrameID4.Location = new System.Drawing.Point(118, 3);
			this.txtFrameID4.MaxLength = 4;
			this.txtFrameID4.Name = "txtFrameID4";
			this.txtFrameID4.OldValue = null;
			this.txtFrameID4.Size = new System.Drawing.Size(50, 22);
			this.txtFrameID4.TabIndex = 1;
			this.ttToolTip.SetToolTip(this.txtFrameID4, "Код контейнера (4 знака, с ведущими нулями)");
			this.txtFrameID4.TextChanged += new System.EventHandler(this.txtFrameID4_TextChanged);
			// 
			// cboDevice
			// 
			this.cboDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cboDevice.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboDevice.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboDevice.FormattingEnabled = true;
			this.cboDevice.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboDevice.Location = new System.Drawing.Point(355, 199);
			this.cboDevice.Name = "cboDevice";
			this.cboDevice.Size = new System.Drawing.Size(162, 22);
			this.cboDevice.TabIndex = 14;
			// 
			// lblFrameGoodState
			// 
			this.lblFrameGoodState.AutoSize = true;
			this.lblFrameGoodState.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblFrameGoodState.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblFrameGoodState.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblFrameGoodState.Location = new System.Drawing.Point(283, 31);
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
			this.lblFrameOwner.Location = new System.Drawing.Point(7, 31);
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
			this.txtFrameGoodState.Location = new System.Drawing.Point(355, 28);
			this.txtFrameGoodState.Name = "txtFrameGoodState";
			this.txtFrameGoodState.Size = new System.Drawing.Size(162, 22);
			this.txtFrameGoodState.TabIndex = 7;
			// 
			// chkStereo
			// 
			this.chkStereo.AutoSize = true;
			this.chkStereo.Enabled = false;
			this.chkStereo.Location = new System.Drawing.Point(356, 4);
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
			this.txtFrameOwner.Enabled = false;
			this.txtFrameOwner.Location = new System.Drawing.Point(118, 28);
			this.txtFrameOwner.Name = "txtFrameOwner";
			this.txtFrameOwner.Size = new System.Drawing.Size(160, 22);
			this.txtFrameOwner.TabIndex = 5;
			// 
			// lblTarget
			// 
			this.lblTarget.AutoSize = true;
			this.lblTarget.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblTarget.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblTarget.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblTarget.Location = new System.Drawing.Point(7, 121);
			this.lblTarget.Name = "lblTarget";
			this.lblTarget.Size = new System.Drawing.Size(37, 14);
			this.lblTarget.TabIndex = 9;
			this.lblTarget.Text = "Куда:";
			// 
			// lblFrom
			// 
			this.lblFrom.AutoSize = true;
			this.lblFrom.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblFrom.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblFrom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblFrom.Location = new System.Drawing.Point(7, 48);
			this.lblFrom.Name = "lblFrom";
			this.lblFrom.Size = new System.Drawing.Size(51, 14);
			this.lblFrom.TabIndex = 8;
			this.lblFrom.Text = "Откуда:";
			// 
			// txtFrameBarCode
			// 
			this.txtFrameBarCode.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtFrameBarCode.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtFrameBarCode.Location = new System.Drawing.Point(172, 3);
			this.txtFrameBarCode.MaxLength = 18;
			this.txtFrameBarCode.Name = "txtFrameBarCode";
			this.txtFrameBarCode.Size = new System.Drawing.Size(178, 22);
			this.txtFrameBarCode.TabIndex = 2;
			this.ttToolTip.SetToolTip(this.txtFrameBarCode, "Штрих-код контейнера");
			this.txtFrameBarCode.Validating += new System.ComponentModel.CancelEventHandler(this.txtFrameBarCode_Validating);
			this.txtFrameBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFrameBarCode_KeyDown);
			// 
			// lblFrame
			// 
			this.lblFrame.AutoSize = true;
			this.lblFrame.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblFrame.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblFrame.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblFrame.Location = new System.Drawing.Point(7, 6);
			this.lblFrame.Name = "lblFrame";
			this.lblFrame.Size = new System.Drawing.Size(69, 14);
			this.lblFrame.TabIndex = 0;
			this.lblFrame.Text = "Контейнер";
			// 
			// numPriority
			// 
			this.numPriority.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.numPriority.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.numPriority.IsNull = false;
			this.numPriority.Location = new System.Drawing.Point(118, 224);
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
			this.numPriority.Size = new System.Drawing.Size(47, 22);
			this.numPriority.TabIndex = 16;
			this.numPriority.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numPriority.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// lblPriority
			// 
			this.lblPriority.AutoSize = true;
			this.lblPriority.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblPriority.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblPriority.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblPriority.Location = new System.Drawing.Point(11, 226);
			this.lblPriority.Name = "lblPriority";
			this.lblPriority.Size = new System.Drawing.Size(69, 14);
			this.lblPriority.TabIndex = 15;
			this.lblPriority.Text = "Приоритет";
			// 
			// cboUser
			// 
			this.cboUser.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboUser.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboUser.FormattingEnabled = true;
			this.cboUser.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboUser.Location = new System.Drawing.Point(118, 199);
			this.cboUser.Name = "cboUser";
			this.cboUser.Size = new System.Drawing.Size(160, 22);
			this.cboUser.TabIndex = 12;
			// 
			// lblDevice
			// 
			this.lblDevice.AutoSize = true;
			this.lblDevice.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblDevice.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblDevice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblDevice.Location = new System.Drawing.Point(283, 202);
			this.lblDevice.Name = "lblDevice";
			this.lblDevice.Size = new System.Drawing.Size(72, 14);
			this.lblDevice.TabIndex = 13;
			this.lblDevice.Text = "Устройство";
			this.ttToolTip.SetToolTip(this.lblDevice, "Максимально допустимый вес");
			// 
			// lblUser
			// 
			this.lblUser.AutoSize = true;
			this.lblUser.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblUser.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblUser.Location = new System.Drawing.Point(11, 202);
			this.lblUser.Name = "lblUser";
			this.lblUser.Size = new System.Drawing.Size(85, 14);
			this.lblUser.TabIndex = 11;
			this.lblUser.Text = "Пользователь";
			// 
			// pnlTarget
			// 
			this.pnlTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlTarget.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlTarget.Controls.Add(this.lblBufferCellTarget);
			this.pnlTarget.Controls.Add(this.cboBufferCellTargetAddress);
			this.pnlTarget.Controls.Add(this.lblCellTarget);
			this.pnlTarget.Controls.Add(this.cboCellTargetAddress);
			this.pnlTarget.Controls.Add(this.cboStoresZonesTarget);
			this.pnlTarget.Controls.Add(this.cboStoresZonesTypesTarget);
			this.pnlTarget.Controls.Add(this.lblStoresZonesTarget);
			this.pnlTarget.Location = new System.Drawing.Point(6, 133);
			this.pnlTarget.Name = "pnlTarget";
			this.pnlTarget.Size = new System.Drawing.Size(518, 60);
			this.pnlTarget.TabIndex = 10;
			// 
			// lblBufferCellTarget
			// 
			this.lblBufferCellTarget.AutoSize = true;
			this.lblBufferCellTarget.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblBufferCellTarget.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblBufferCellTarget.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblBufferCellTarget.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblBufferCellTarget.Location = new System.Drawing.Point(301, 33);
			this.lblBufferCellTarget.Name = "lblBufferCellTarget";
			this.lblBufferCellTarget.Size = new System.Drawing.Size(44, 14);
			this.lblBufferCellTarget.TabIndex = 8;
			this.lblBufferCellTarget.Text = "Буфер";
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
			this.cboBufferCellTargetAddress.Location = new System.Drawing.Point(346, 30);
			this.cboBufferCellTargetAddress.Name = "cboBufferCellTargetAddress";
			this.cboBufferCellTargetAddress.Size = new System.Drawing.Size(164, 22);
			this.cboBufferCellTargetAddress.TabIndex = 10;
			// 
			// lblCellTarget
			// 
			this.lblCellTarget.AutoSize = true;
			this.lblCellTarget.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblCellTarget.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblCellTarget.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCellTarget.Location = new System.Drawing.Point(3, 33);
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
			this.cboCellTargetAddress.Location = new System.Drawing.Point(109, 30);
			this.cboCellTargetAddress.Name = "cboCellTargetAddress";
			this.cboCellTargetAddress.Size = new System.Drawing.Size(160, 22);
			this.cboCellTargetAddress.TabIndex = 5;
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
			this.cboStoresZonesTarget.Location = new System.Drawing.Point(109, 5);
			this.cboStoresZonesTarget.Name = "cboStoresZonesTarget";
			this.cboStoresZonesTarget.Size = new System.Drawing.Size(234, 22);
			this.cboStoresZonesTarget.TabIndex = 1;
			// 
			// cboStoresZonesTypesTarget
			// 
			this.cboStoresZonesTypesTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cboStoresZonesTypesTarget.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboStoresZonesTypesTarget.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboStoresZonesTypesTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboStoresZonesTypesTarget.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cboStoresZonesTypesTarget.FormattingEnabled = true;
			this.cboStoresZonesTypesTarget.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboStoresZonesTypesTarget.Location = new System.Drawing.Point(346, 5);
			this.cboStoresZonesTypesTarget.Name = "cboStoresZonesTypesTarget";
			this.cboStoresZonesTypesTarget.Size = new System.Drawing.Size(164, 22);
			this.cboStoresZonesTypesTarget.TabIndex = 2;
			// 
			// lblStoresZonesTarget
			// 
			this.lblStoresZonesTarget.AutoSize = true;
			this.lblStoresZonesTarget.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblStoresZonesTarget.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblStoresZonesTarget.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblStoresZonesTarget.Location = new System.Drawing.Point(3, 8);
			this.lblStoresZonesTarget.Name = "lblStoresZonesTarget";
			this.lblStoresZonesTarget.Size = new System.Drawing.Size(94, 14);
			this.lblStoresZonesTarget.TabIndex = 0;
			this.lblStoresZonesTarget.Text = "Складская зона";
			// 
			// pnlSource
			// 
			this.pnlSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlSource.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlSource.Controls.Add(this.lblBufferCellSource);
			this.pnlSource.Controls.Add(this.cboBufferCellSourceAddress);
			this.pnlSource.Controls.Add(this.cboCellSourceAddress);
			this.pnlSource.Controls.Add(this.lblCellSource);
			this.pnlSource.Controls.Add(this.cboStoresZonesTypesSource);
			this.pnlSource.Controls.Add(this.lblStoresZonesSource);
			this.pnlSource.Controls.Add(this.cboStoresZonesSource);
			this.pnlSource.Location = new System.Drawing.Point(6, 58);
			this.pnlSource.Name = "pnlSource";
			this.pnlSource.Size = new System.Drawing.Size(518, 60);
			this.pnlSource.TabIndex = 9;
			// 
			// lblBufferCellSource
			// 
			this.lblBufferCellSource.AutoSize = true;
			this.lblBufferCellSource.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblBufferCellSource.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblBufferCellSource.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblBufferCellSource.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblBufferCellSource.Location = new System.Drawing.Point(301, 33);
			this.lblBufferCellSource.Name = "lblBufferCellSource";
			this.lblBufferCellSource.Size = new System.Drawing.Size(44, 14);
			this.lblBufferCellSource.TabIndex = 8;
			this.lblBufferCellSource.Text = "Буфер";
			// 
			// cboBufferCellSourceAddress
			// 
			this.cboBufferCellSourceAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cboBufferCellSourceAddress.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboBufferCellSourceAddress.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboBufferCellSourceAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboBufferCellSourceAddress.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cboBufferCellSourceAddress.FormattingEnabled = true;
			this.cboBufferCellSourceAddress.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboBufferCellSourceAddress.Location = new System.Drawing.Point(346, 30);
			this.cboBufferCellSourceAddress.Name = "cboBufferCellSourceAddress";
			this.cboBufferCellSourceAddress.Size = new System.Drawing.Size(164, 22);
			this.cboBufferCellSourceAddress.TabIndex = 10;
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
			this.cboCellSourceAddress.Location = new System.Drawing.Point(109, 30);
			this.cboCellSourceAddress.Name = "cboCellSourceAddress";
			this.cboCellSourceAddress.Size = new System.Drawing.Size(160, 22);
			this.cboCellSourceAddress.TabIndex = 5;
			// 
			// lblCellSource
			// 
			this.lblCellSource.AutoSize = true;
			this.lblCellSource.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblCellSource.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblCellSource.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCellSource.Location = new System.Drawing.Point(3, 33);
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
			this.cboStoresZonesTypesSource.Location = new System.Drawing.Point(346, 5);
			this.cboStoresZonesTypesSource.Name = "cboStoresZonesTypesSource";
			this.cboStoresZonesTypesSource.Size = new System.Drawing.Size(164, 22);
			this.cboStoresZonesTypesSource.TabIndex = 2;
			// 
			// lblStoresZonesSource
			// 
			this.lblStoresZonesSource.AutoSize = true;
			this.lblStoresZonesSource.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblStoresZonesSource.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblStoresZonesSource.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblStoresZonesSource.Location = new System.Drawing.Point(3, 8);
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
			this.cboStoresZonesSource.Location = new System.Drawing.Point(109, 5);
			this.cboStoresZonesSource.Name = "cboStoresZonesSource";
			this.cboStoresZonesSource.Size = new System.Drawing.Size(234, 22);
			this.cboStoresZonesSource.TabIndex = 1;
			// 
			// pnlTrafficError
			// 
			this.pnlTrafficError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlTrafficError.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlTrafficError.Controls.Add(this.lblLockCell);
			this.pnlTrafficError.Controls.Add(this.chkLockCellSource);
			this.pnlTrafficError.Controls.Add(this.chkLockFrame);
			this.pnlTrafficError.Controls.Add(this.lblLock);
			this.pnlTrafficError.Controls.Add(this.chkLockCellFinish);
			this.pnlTrafficError.Controls.Add(this.pnlOpt);
			this.pnlTrafficError.Location = new System.Drawing.Point(6, 250);
			this.pnlTrafficError.Name = "pnlTrafficError";
			this.pnlTrafficError.Size = new System.Drawing.Size(518, 150);
			this.pnlTrafficError.TabIndex = 17;
			// 
			// lblLockCell
			// 
			this.lblLockCell.AutoSize = true;
			this.lblLockCell.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblLockCell.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblLockCell.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblLockCell.Location = new System.Drawing.Point(236, 127);
			this.lblLockCell.Name = "lblLockCell";
			this.lblLockCell.Size = new System.Drawing.Size(47, 14);
			this.lblLockCell.TabIndex = 19;
			this.lblLockCell.Text = "ячейку";
			// 
			// chkLockCellSource
			// 
			this.chkLockCellSource.AutoSize = true;
			this.chkLockCellSource.Location = new System.Drawing.Point(289, 126);
			this.chkLockCellSource.Name = "chkLockCellSource";
			this.chkLockCellSource.Size = new System.Drawing.Size(81, 18);
			this.chkLockCellSource.TabIndex = 18;
			this.chkLockCellSource.Text = "исходную";
			this.chkLockCellSource.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.chkLockCellSource.UseVisualStyleBackColor = true;
			// 
			// chkLockFrame
			// 
			this.chkLockFrame.AutoSize = true;
			this.chkLockFrame.Location = new System.Drawing.Point(289, 107);
			this.chkLockFrame.Name = "chkLockFrame";
			this.chkLockFrame.Size = new System.Drawing.Size(87, 18);
			this.chkLockFrame.TabIndex = 17;
			this.chkLockFrame.Text = "контейнер";
			this.chkLockFrame.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.chkLockFrame.UseVisualStyleBackColor = true;
			// 
			// lblLock
			// 
			this.lblLock.AutoSize = true;
			this.lblLock.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblLock.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblLock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblLock.Location = new System.Drawing.Point(204, 108);
			this.lblLock.Name = "lblLock";
			this.lblLock.Size = new System.Drawing.Size(79, 14);
			this.lblLock.TabIndex = 16;
			this.lblLock.Text = "блокировать";
			// 
			// chkLockCellFinish
			// 
			this.chkLockCellFinish.AutoSize = true;
			this.chkLockCellFinish.Location = new System.Drawing.Point(376, 126);
			this.chkLockCellFinish.Name = "chkLockCellFinish";
			this.chkLockCellFinish.Size = new System.Drawing.Size(82, 18);
			this.chkLockCellFinish.TabIndex = 9;
			this.chkLockCellFinish.Text = "конечную";
			this.chkLockCellFinish.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.chkLockCellFinish.UseVisualStyleBackColor = true;
			// 
			// pnlOpt
			// 
			this.pnlOpt.Controls.Add(this.cboTrafficError);
			this.pnlOpt.Controls.Add(this.optError);
			this.pnlOpt.Controls.Add(this.optCellTarget);
			this.pnlOpt.Controls.Add(this.optBufferCellTarget);
			this.pnlOpt.Controls.Add(this.optBufferCellSource);
			this.pnlOpt.Controls.Add(this.optNoChanges);
			this.pnlOpt.Location = new System.Drawing.Point(3, 1);
			this.pnlOpt.Name = "pnlOpt";
			this.pnlOpt.Size = new System.Drawing.Size(507, 105);
			this.pnlOpt.TabIndex = 8;
			// 
			// cboTrafficError
			// 
			this.cboTrafficError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cboTrafficError.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboTrafficError.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboTrafficError.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboTrafficError.FormattingEnabled = true;
			this.cboTrafficError.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboTrafficError.Location = new System.Drawing.Point(286, 81);
			this.cboTrafficError.Name = "cboTrafficError";
			this.cboTrafficError.Size = new System.Drawing.Size(218, 22);
			this.cboTrafficError.TabIndex = 5;
			this.cboTrafficError.SelectedIndexChanged += new System.EventHandler(this.cboTrafficError_SelectedIndexChanged);
			// 
			// optError
			// 
			this.optError.AutoSize = true;
			this.optError.Location = new System.Drawing.Point(3, 83);
			this.optError.Name = "optError";
			this.optError.Size = new System.Drawing.Size(281, 18);
			this.optError.TabIndex = 4;
			this.optError.TabStop = true;
			this.optError.Text = "задание не может быть выполнено, ошибка:";
			this.optError.UseVisualStyleBackColor = true;
			this.optError.CheckedChanged += new System.EventHandler(this.optError_CheckedChanged);
			// 
			// optCellTarget
			// 
			this.optCellTarget.AutoSize = true;
			this.optCellTarget.Location = new System.Drawing.Point(3, 63);
			this.optCellTarget.Name = "optCellTarget";
			this.optCellTarget.Size = new System.Drawing.Size(277, 18);
			this.optCellTarget.TabIndex = 3;
			this.optCellTarget.TabStop = true;
			this.optCellTarget.Text = "контейнер установлен в ячейке-приемнике";
			this.optCellTarget.UseVisualStyleBackColor = true;
			// 
			// optBufferCellTarget
			// 
			this.optBufferCellTarget.AutoSize = true;
			this.optBufferCellTarget.Location = new System.Drawing.Point(3, 43);
			this.optBufferCellTarget.Name = "optBufferCellTarget";
			this.optBufferCellTarget.Size = new System.Drawing.Size(338, 18);
			this.optBufferCellTarget.TabIndex = 2;
			this.optBufferCellTarget.TabStop = true;
			this.optBufferCellTarget.Text = "контейнер установлен в буферной ячейке приемника";
			this.optBufferCellTarget.UseVisualStyleBackColor = true;
			// 
			// optBufferCellSource
			// 
			this.optBufferCellSource.AutoSize = true;
			this.optBufferCellSource.Location = new System.Drawing.Point(3, 23);
			this.optBufferCellSource.Name = "optBufferCellSource";
			this.optBufferCellSource.Size = new System.Drawing.Size(335, 18);
			this.optBufferCellSource.TabIndex = 1;
			this.optBufferCellSource.TabStop = true;
			this.optBufferCellSource.Text = "контейнер установлен в буферной ячейке источника";
			this.optBufferCellSource.UseVisualStyleBackColor = true;
			// 
			// optNoChanges
			// 
			this.optNoChanges.AutoSize = true;
			this.optNoChanges.Location = new System.Drawing.Point(3, 3);
			this.optNoChanges.Name = "optNoChanges";
			this.optNoChanges.Size = new System.Drawing.Size(268, 18);
			this.optNoChanges.TabIndex = 0;
			this.optNoChanges.TabStop = true;
			this.optNoChanges.Text = "контейнер находится в ячейке-источнике";
			this.optNoChanges.UseVisualStyleBackColor = true;
			// 
			// frmTrafficsFramesEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(542, 454);
			this.Controls.Add(this.btnHelp);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.pnlData);
			this.hpHelp.SetHelpKeyword(this, "412");
			this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.IsModalMode = true;
			this.Name = "frmTrafficsFramesEdit";
			this.hpHelp.SetShowHelp(this, true);
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Задание на транспортировку поддона";
			this.Load += new System.EventHandler(this.frmTrafficsFramesEdit_Load);
			this.pnlData.ResumeLayout(false);
			this.pnlData.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numPriority)).EndInit();
			this.pnlTarget.ResumeLayout(false);
			this.pnlTarget.PerformLayout();
			this.pnlSource.ResumeLayout(false);
			this.pnlSource.PerformLayout();
			this.pnlTrafficError.ResumeLayout(false);
			this.pnlTrafficError.PerformLayout();
			this.pnlOpt.ResumeLayout(false);
			this.pnlOpt.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

        private RFMBaseClasses.RFMButton btnSave;
        private RFMBaseClasses.RFMButton btnCancel;
        private RFMBaseClasses.RFMButton btnHelp;
		private RFMBaseClasses.RFMPanel pnlData;
        private RFMBaseClasses.RFMLabel lblUser;
        private RFMBaseClasses.RFMLabel lblPriority;
        private RFMBaseClasses.RFMComboBox cboUser;
		private RFMBaseClasses.RFMLabel lblDevice;
		private RFMBaseClasses.RFMNumericUpDown numPriority;
		private RFMBaseClasses.RFMLabel lblFrameGoodState;
		private RFMBaseClasses.RFMLabel lblFrameOwner;
		private RFMBaseClasses.RFMTextBox txtFrameGoodState;
		private RFMBaseClasses.RFMCheckBox chkStereo;
		private RFMBaseClasses.RFMTextBox txtFrameOwner;
		private RFMBaseClasses.RFMLabel lblTarget;
		private RFMBaseClasses.RFMLabel lblFrom;
		private RFMBaseClasses.RFMPanel pnlSource;
		private RFMBaseClasses.RFMComboBox cboCellSourceAddress;
		private RFMBaseClasses.RFMLabel lblCellSource;
		private RFMBaseClasses.RFMComboBox cboStoresZonesTypesSource;
		private RFMBaseClasses.RFMLabel lblStoresZonesSource;
		private RFMBaseClasses.RFMComboBox cboStoresZonesSource;
		private RFMBaseClasses.RFMTextBoxBarCode txtFrameBarCode;
		private RFMBaseClasses.RFMLabel lblFrame;
		private RFMBaseClasses.RFMPanel pnlTarget;
		private RFMBaseClasses.RFMLabel lblCellTarget;
		private RFMBaseClasses.RFMComboBox cboCellTargetAddress;
		private RFMBaseClasses.RFMComboBox cboStoresZonesTarget;
		private RFMBaseClasses.RFMComboBox cboStoresZonesTypesTarget;
		private RFMBaseClasses.RFMLabel lblStoresZonesTarget;
		private RFMBaseClasses.RFMComboBox cboDevice;
		private RFMBaseClasses.RFMPanel pnlTrafficError;
		private RFMBaseClasses.RFMLabel lblBufferCellSource;
		private RFMBaseClasses.RFMComboBox cboBufferCellSourceAddress;
		private RFMBaseClasses.RFMLabel lblBufferCellTarget;
		private RFMBaseClasses.RFMComboBox cboBufferCellTargetAddress;
		private RFMBaseClasses.RFMPanel pnlOpt;
		private RFMBaseClasses.RFMRadioButton optBufferCellSource;
		private RFMBaseClasses.RFMRadioButton optNoChanges;
		private RFMBaseClasses.RFMComboBox cboTrafficError;
		private RFMBaseClasses.RFMRadioButton optError;
		private RFMBaseClasses.RFMRadioButton optCellTarget;
		private RFMBaseClasses.RFMRadioButton optBufferCellTarget;
		private RFMBaseClasses.RFMCheckBox chkLockCellFinish;
		private RFMBaseClasses.RFMTextBoxNumeric txtFrameID4;
		private RFMBaseClasses.RFMCheckBox chkLockFrame;
		private RFMBaseClasses.RFMLabel lblLock;
		private RFMBaseClasses.RFMLabel lblLockCell;
		private RFMBaseClasses.RFMCheckBox chkLockCellSource;
	}
}