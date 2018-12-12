namespace WMSSuitable
{
	partial class frmTrafficsGoodsEdit
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
			this.lblRestQntConfirmed = new RFMBaseClasses.RFMLabel();
			this.numRestQntConfirmed = new RFMBaseClasses.RFMNumericUpDown();
			this.lblBoxConfirmed = new RFMBaseClasses.RFMLabel();
			this.numBoxConfirmed = new RFMBaseClasses.RFMNumericUpDown();
			this.lblConfirmed = new RFMBaseClasses.RFMLabel();
			this.txtPackingAlias = new RFMBaseClasses.RFMTextBox();
			this.lblRestQntWished = new RFMBaseClasses.RFMLabel();
			this.numRestQntWished = new RFMBaseClasses.RFMNumericUpDown();
			this.lblBoxWished = new RFMBaseClasses.RFMLabel();
			this.numBoxWished = new RFMBaseClasses.RFMNumericUpDown();
			this.lblWished = new RFMBaseClasses.RFMLabel();
			this.lblGood = new RFMBaseClasses.RFMLabel();
			this.cboDevice = new RFMBaseClasses.RFMComboBox();
			this.lblGoodState = new RFMBaseClasses.RFMLabel();
			this.lblOwner = new RFMBaseClasses.RFMLabel();
			this.txtGoodState = new RFMBaseClasses.RFMTextBox();
			this.txtOwner = new RFMBaseClasses.RFMTextBox();
			this.lblTarget = new RFMBaseClasses.RFMLabel();
			this.lblFrom = new RFMBaseClasses.RFMLabel();
			this.numPriority = new RFMBaseClasses.RFMNumericUpDown();
			this.lblPriority = new RFMBaseClasses.RFMLabel();
			this.cboUser = new RFMBaseClasses.RFMComboBox();
			this.lblDevice = new RFMBaseClasses.RFMLabel();
			this.lblUser = new RFMBaseClasses.RFMLabel();
			this.pnlTarget = new RFMBaseClasses.RFMPanel();
			this.lblCellTarget = new RFMBaseClasses.RFMLabel();
			this.cboCellTargetAddress = new RFMBaseClasses.RFMComboBox();
			this.cboStoresZonesTarget = new RFMBaseClasses.RFMComboBox();
			this.cboStoresZonesTypesTarget = new RFMBaseClasses.RFMComboBox();
			this.lblStoresZonesTarget = new RFMBaseClasses.RFMLabel();
			this.pnlSource = new RFMBaseClasses.RFMPanel();
			this.cboCellSourceAddress = new RFMBaseClasses.RFMComboBox();
			this.lblCellSource = new RFMBaseClasses.RFMLabel();
			this.cboStoresZonesTypesSource = new RFMBaseClasses.RFMComboBox();
			this.lblStoresZonesSource = new RFMBaseClasses.RFMLabel();
			this.cboStoresZonesSource = new RFMBaseClasses.RFMComboBox();
			this.pnlTrafficError = new RFMBaseClasses.RFMPanel();
			this.chkLockCellFinish = new RFMBaseClasses.RFMCheckBox();
			this.pnlOpt = new RFMBaseClasses.RFMPanel();
			this.cboTrafficError = new RFMBaseClasses.RFMComboBox();
			this.optError = new RFMBaseClasses.RFMRadioButton();
			this.optCellTarget = new RFMBaseClasses.RFMRadioButton();
			this.optNoChanges = new RFMBaseClasses.RFMRadioButton();
			this.pnlData.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numRestQntConfirmed)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numBoxConfirmed)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numRestQntWished)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numBoxWished)).BeginInit();
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
			this.btnCancel.Location = new System.Drawing.Point(505, 424);
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
			this.btnSave.Location = new System.Drawing.Point(455, 424);
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
			this.btnHelp.Location = new System.Drawing.Point(6, 424);
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
			this.pnlData.Controls.Add(this.lblRestQntConfirmed);
			this.pnlData.Controls.Add(this.numRestQntConfirmed);
			this.pnlData.Controls.Add(this.lblBoxConfirmed);
			this.pnlData.Controls.Add(this.numBoxConfirmed);
			this.pnlData.Controls.Add(this.lblConfirmed);
			this.pnlData.Controls.Add(this.txtPackingAlias);
			this.pnlData.Controls.Add(this.lblRestQntWished);
			this.pnlData.Controls.Add(this.numRestQntWished);
			this.pnlData.Controls.Add(this.lblBoxWished);
			this.pnlData.Controls.Add(this.numBoxWished);
			this.pnlData.Controls.Add(this.lblWished);
			this.pnlData.Controls.Add(this.lblGood);
			this.pnlData.Controls.Add(this.cboDevice);
			this.pnlData.Controls.Add(this.lblGoodState);
			this.pnlData.Controls.Add(this.lblOwner);
			this.pnlData.Controls.Add(this.txtGoodState);
			this.pnlData.Controls.Add(this.txtOwner);
			this.pnlData.Controls.Add(this.lblTarget);
			this.pnlData.Controls.Add(this.lblFrom);
			this.pnlData.Controls.Add(this.numPriority);
			this.pnlData.Controls.Add(this.lblPriority);
			this.pnlData.Controls.Add(this.cboUser);
			this.pnlData.Controls.Add(this.lblDevice);
			this.pnlData.Controls.Add(this.lblUser);
			this.pnlData.Controls.Add(this.pnlTarget);
			this.pnlData.Controls.Add(this.pnlSource);
			this.pnlData.Controls.Add(this.pnlTrafficError);
			this.pnlData.Location = new System.Drawing.Point(6, 6);
			this.pnlData.Name = "pnlData";
			this.pnlData.Size = new System.Drawing.Size(531, 410);
			this.pnlData.TabIndex = 0;
			// 
			// lblRestQntConfirmed
			// 
			this.lblRestQntConfirmed.AutoSize = true;
			this.lblRestQntConfirmed.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblRestQntConfirmed.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblRestQntConfirmed.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblRestQntConfirmed.Location = new System.Drawing.Point(340, 58);
			this.lblRestQntConfirmed.Name = "lblRestQntConfirmed";
			this.lblRestQntConfirmed.Size = new System.Drawing.Size(41, 14);
			this.lblRestQntConfirmed.TabIndex = 11;
			this.lblRestQntConfirmed.Text = "шт./кг";
			// 
			// numRestQntConfirmed
			// 
			this.numRestQntConfirmed.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.numRestQntConfirmed.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.numRestQntConfirmed.IsNull = false;
			this.numRestQntConfirmed.Location = new System.Drawing.Point(229, 54);
			this.numRestQntConfirmed.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
			this.numRestQntConfirmed.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
			this.numRestQntConfirmed.Name = "numRestQntConfirmed";
			this.numRestQntConfirmed.Size = new System.Drawing.Size(110, 22);
			this.numRestQntConfirmed.TabIndex = 10;
			this.numRestQntConfirmed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.ttToolTip.SetToolTip(this.numRestQntConfirmed, "Дополнительно штук в нецелой коробке / кг");
			// 
			// lblBoxConfirmed
			// 
			this.lblBoxConfirmed.AutoSize = true;
			this.lblBoxConfirmed.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblBoxConfirmed.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblBoxConfirmed.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblBoxConfirmed.Location = new System.Drawing.Point(184, 58);
			this.lblBoxConfirmed.Name = "lblBoxConfirmed";
			this.lblBoxConfirmed.Size = new System.Drawing.Size(47, 14);
			this.lblBoxConfirmed.TabIndex = 9;
			this.lblBoxConfirmed.Text = "кор. + ";
			// 
			// numBoxConfirmed
			// 
			this.numBoxConfirmed.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.numBoxConfirmed.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.numBoxConfirmed.IsNull = false;
			this.numBoxConfirmed.Location = new System.Drawing.Point(118, 54);
			this.numBoxConfirmed.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
			this.numBoxConfirmed.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
			this.numBoxConfirmed.Name = "numBoxConfirmed";
			this.numBoxConfirmed.Size = new System.Drawing.Size(60, 22);
			this.numBoxConfirmed.TabIndex = 8;
			this.numBoxConfirmed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.ttToolTip.SetToolTip(this.numBoxConfirmed, "количество целых коробок");
			// 
			// lblConfirmed
			// 
			this.lblConfirmed.AutoSize = true;
			this.lblConfirmed.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblConfirmed.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblConfirmed.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblConfirmed.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblConfirmed.Location = new System.Drawing.Point(7, 58);
			this.lblConfirmed.Name = "lblConfirmed";
			this.lblConfirmed.Size = new System.Drawing.Size(89, 14);
			this.lblConfirmed.TabIndex = 7;
			this.lblConfirmed.Text = "Перемещено";
			// 
			// txtPackingAlias
			// 
			this.txtPackingAlias.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtPackingAlias.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtPackingAlias.Enabled = false;
			this.txtPackingAlias.Location = new System.Drawing.Point(118, 4);
			this.txtPackingAlias.Name = "txtPackingAlias";
			this.txtPackingAlias.Size = new System.Drawing.Size(403, 22);
			this.txtPackingAlias.TabIndex = 1;
			// 
			// lblRestQntWished
			// 
			this.lblRestQntWished.AutoSize = true;
			this.lblRestQntWished.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblRestQntWished.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblRestQntWished.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblRestQntWished.Location = new System.Drawing.Point(340, 33);
			this.lblRestQntWished.Name = "lblRestQntWished";
			this.lblRestQntWished.Size = new System.Drawing.Size(41, 14);
			this.lblRestQntWished.TabIndex = 6;
			this.lblRestQntWished.Text = "шт./кг";
			// 
			// numRestQntWished
			// 
			this.numRestQntWished.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.numRestQntWished.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.numRestQntWished.Enabled = false;
			this.numRestQntWished.IsNull = false;
			this.numRestQntWished.Location = new System.Drawing.Point(229, 29);
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
			this.numRestQntWished.TabIndex = 5;
			this.numRestQntWished.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.ttToolTip.SetToolTip(this.numRestQntWished, "Дополнительно штук в нецелой коробке / кг");
			// 
			// lblBoxWished
			// 
			this.lblBoxWished.AutoSize = true;
			this.lblBoxWished.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblBoxWished.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblBoxWished.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblBoxWished.Location = new System.Drawing.Point(184, 33);
			this.lblBoxWished.Name = "lblBoxWished";
			this.lblBoxWished.Size = new System.Drawing.Size(47, 14);
			this.lblBoxWished.TabIndex = 4;
			this.lblBoxWished.Text = "кор. + ";
			// 
			// numBoxWished
			// 
			this.numBoxWished.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.numBoxWished.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.numBoxWished.Enabled = false;
			this.numBoxWished.IsNull = false;
			this.numBoxWished.Location = new System.Drawing.Point(118, 29);
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
			this.numBoxWished.TabIndex = 3;
			this.numBoxWished.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.ttToolTip.SetToolTip(this.numBoxWished, "количество целых коробок");
			// 
			// lblWished
			// 
			this.lblWished.AutoSize = true;
			this.lblWished.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblWished.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblWished.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblWished.Location = new System.Drawing.Point(7, 33);
			this.lblWished.Name = "lblWished";
			this.lblWished.Size = new System.Drawing.Size(74, 14);
			this.lblWished.TabIndex = 2;
			this.lblWished.Text = "Количество";
			// 
			// lblGood
			// 
			this.lblGood.AutoSize = true;
			this.lblGood.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblGood.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblGood.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblGood.Location = new System.Drawing.Point(7, 7);
			this.lblGood.Name = "lblGood";
			this.lblGood.Size = new System.Drawing.Size(41, 14);
			this.lblGood.TabIndex = 0;
			this.lblGood.Text = "Товар";
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
			this.cboDevice.Location = new System.Drawing.Point(356, 255);
			this.cboDevice.Name = "cboDevice";
			this.cboDevice.Size = new System.Drawing.Size(160, 22);
			this.cboDevice.TabIndex = 23;
			// 
			// lblGoodState
			// 
			this.lblGoodState.AutoSize = true;
			this.lblGoodState.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblGoodState.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblGoodState.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblGoodState.Location = new System.Drawing.Point(283, 82);
			this.lblGoodState.Name = "lblGoodState";
			this.lblGoodState.Size = new System.Drawing.Size(68, 14);
			this.lblGoodState.TabIndex = 14;
			this.lblGoodState.Text = "Состояние";
			// 
			// lblOwner
			// 
			this.lblOwner.AutoSize = true;
			this.lblOwner.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblOwner.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblOwner.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblOwner.Location = new System.Drawing.Point(7, 82);
			this.lblOwner.Name = "lblOwner";
			this.lblOwner.Size = new System.Drawing.Size(67, 14);
			this.lblOwner.TabIndex = 12;
			this.lblOwner.Text = "Хранитель";
			// 
			// txtGoodState
			// 
			this.txtGoodState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.txtGoodState.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtGoodState.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtGoodState.Enabled = false;
			this.txtGoodState.Location = new System.Drawing.Point(355, 79);
			this.txtGoodState.Name = "txtGoodState";
			this.txtGoodState.Size = new System.Drawing.Size(160, 22);
			this.txtGoodState.TabIndex = 15;
			// 
			// txtOwner
			// 
			this.txtOwner.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtOwner.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtOwner.Enabled = false;
			this.txtOwner.Location = new System.Drawing.Point(118, 79);
			this.txtOwner.Name = "txtOwner";
			this.txtOwner.Size = new System.Drawing.Size(160, 22);
			this.txtOwner.TabIndex = 13;
			// 
			// lblTarget
			// 
			this.lblTarget.AutoSize = true;
			this.lblTarget.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblTarget.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblTarget.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblTarget.Location = new System.Drawing.Point(7, 177);
			this.lblTarget.Name = "lblTarget";
			this.lblTarget.Size = new System.Drawing.Size(37, 14);
			this.lblTarget.TabIndex = 18;
			this.lblTarget.Text = "Куда:";
			// 
			// lblFrom
			// 
			this.lblFrom.AutoSize = true;
			this.lblFrom.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblFrom.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblFrom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblFrom.Location = new System.Drawing.Point(7, 102);
			this.lblFrom.Name = "lblFrom";
			this.lblFrom.Size = new System.Drawing.Size(51, 14);
			this.lblFrom.TabIndex = 16;
			this.lblFrom.Text = "Откуда:";
			// 
			// numPriority
			// 
			this.numPriority.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.numPriority.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.numPriority.IsNull = false;
			this.numPriority.Location = new System.Drawing.Point(118, 280);
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
			this.numPriority.TabIndex = 25;
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
			this.lblPriority.Location = new System.Drawing.Point(11, 282);
			this.lblPriority.Name = "lblPriority";
			this.lblPriority.Size = new System.Drawing.Size(69, 14);
			this.lblPriority.TabIndex = 24;
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
			this.cboUser.Location = new System.Drawing.Point(118, 255);
			this.cboUser.Name = "cboUser";
			this.cboUser.Size = new System.Drawing.Size(160, 22);
			this.cboUser.TabIndex = 21;
			// 
			// lblDevice
			// 
			this.lblDevice.AutoSize = true;
			this.lblDevice.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblDevice.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblDevice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblDevice.Location = new System.Drawing.Point(283, 258);
			this.lblDevice.Name = "lblDevice";
			this.lblDevice.Size = new System.Drawing.Size(72, 14);
			this.lblDevice.TabIndex = 22;
			this.lblDevice.Text = "Устройство";
			this.ttToolTip.SetToolTip(this.lblDevice, "Максимально допустимый вес");
			// 
			// lblUser
			// 
			this.lblUser.AutoSize = true;
			this.lblUser.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblUser.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblUser.Location = new System.Drawing.Point(11, 258);
			this.lblUser.Name = "lblUser";
			this.lblUser.Size = new System.Drawing.Size(85, 14);
			this.lblUser.TabIndex = 20;
			this.lblUser.Text = "Пользователь";
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
			this.pnlTarget.Location = new System.Drawing.Point(7, 187);
			this.pnlTarget.Name = "pnlTarget";
			this.pnlTarget.Size = new System.Drawing.Size(514, 60);
			this.pnlTarget.TabIndex = 19;
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
			this.cboCellTargetAddress.Enabled = false;
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
			this.cboCellTargetAddress.TabIndex = 4;
			// 
			// cboStoresZonesTarget
			// 
			this.cboStoresZonesTarget.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboStoresZonesTarget.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboStoresZonesTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboStoresZonesTarget.Enabled = false;
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
			this.cboStoresZonesTypesTarget.Enabled = false;
			this.cboStoresZonesTypesTarget.FormattingEnabled = true;
			this.cboStoresZonesTypesTarget.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboStoresZonesTypesTarget.Location = new System.Drawing.Point(346, 5);
			this.cboStoresZonesTypesTarget.Name = "cboStoresZonesTypesTarget";
			this.cboStoresZonesTypesTarget.Size = new System.Drawing.Size(160, 22);
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
			this.pnlSource.Controls.Add(this.cboCellSourceAddress);
			this.pnlSource.Controls.Add(this.lblCellSource);
			this.pnlSource.Controls.Add(this.cboStoresZonesTypesSource);
			this.pnlSource.Controls.Add(this.lblStoresZonesSource);
			this.pnlSource.Controls.Add(this.cboStoresZonesSource);
			this.pnlSource.Location = new System.Drawing.Point(7, 111);
			this.pnlSource.Name = "pnlSource";
			this.pnlSource.Size = new System.Drawing.Size(514, 60);
			this.pnlSource.TabIndex = 17;
			// 
			// cboCellSourceAddress
			// 
			this.cboCellSourceAddress.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboCellSourceAddress.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboCellSourceAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCellSourceAddress.Enabled = false;
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
			this.cboCellSourceAddress.TabIndex = 4;
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
			this.cboStoresZonesTypesSource.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboStoresZonesTypesSource.Location = new System.Drawing.Point(346, 5);
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
			this.cboStoresZonesSource.Enabled = false;
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
			this.pnlTrafficError.Controls.Add(this.chkLockCellFinish);
			this.pnlTrafficError.Controls.Add(this.pnlOpt);
			this.pnlTrafficError.Location = new System.Drawing.Point(7, 309);
			this.pnlTrafficError.Name = "pnlTrafficError";
			this.pnlTrafficError.Size = new System.Drawing.Size(514, 91);
			this.pnlTrafficError.TabIndex = 17;
			// 
			// chkLockCellFinish
			// 
			this.chkLockCellFinish.AutoSize = true;
			this.chkLockCellFinish.Location = new System.Drawing.Point(287, 67);
			this.chkLockCellFinish.Name = "chkLockCellFinish";
			this.chkLockCellFinish.Size = new System.Drawing.Size(202, 18);
			this.chkLockCellFinish.TabIndex = 1;
			this.chkLockCellFinish.Text = "блокировать ячейку-приемник";
			this.chkLockCellFinish.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.chkLockCellFinish.UseVisualStyleBackColor = true;
			// 
			// pnlOpt
			// 
			this.pnlOpt.Controls.Add(this.cboTrafficError);
			this.pnlOpt.Controls.Add(this.optError);
			this.pnlOpt.Controls.Add(this.optCellTarget);
			this.pnlOpt.Controls.Add(this.optNoChanges);
			this.pnlOpt.Location = new System.Drawing.Point(2, 3);
			this.pnlOpt.Name = "pnlOpt";
			this.pnlOpt.Size = new System.Drawing.Size(505, 63);
			this.pnlOpt.TabIndex = 0;
			// 
			// cboTrafficError
			// 
			this.cboTrafficError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.cboTrafficError.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboTrafficError.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboTrafficError.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboTrafficError.Enabled = false;
			this.cboTrafficError.FormattingEnabled = true;
			this.cboTrafficError.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboTrafficError.Location = new System.Drawing.Point(284, 40);
			this.cboTrafficError.Name = "cboTrafficError";
			this.cboTrafficError.Size = new System.Drawing.Size(220, 22);
			this.cboTrafficError.TabIndex = 3;
			// 
			// optError
			// 
			this.optError.AutoSize = true;
			this.optError.Location = new System.Drawing.Point(3, 41);
			this.optError.Name = "optError";
			this.optError.Size = new System.Drawing.Size(281, 18);
			this.optError.TabIndex = 2;
			this.optError.TabStop = true;
			this.optError.Text = "задание не может быть выполнено, ошибка:";
			this.optError.UseVisualStyleBackColor = true;
			this.optError.CheckedChanged += new System.EventHandler(this.optError_CheckedChanged);
			// 
			// optCellTarget
			// 
			this.optCellTarget.AutoSize = true;
			this.optCellTarget.Location = new System.Drawing.Point(3, 22);
			this.optCellTarget.Name = "optCellTarget";
			this.optCellTarget.Size = new System.Drawing.Size(234, 18);
			this.optCellTarget.TabIndex = 1;
			this.optCellTarget.TabStop = true;
			this.optCellTarget.Text = "товар доставлен в ячейку-приемник";
			this.optCellTarget.UseVisualStyleBackColor = true;
			// 
			// optNoChanges
			// 
			this.optNoChanges.AutoSize = true;
			this.optNoChanges.Location = new System.Drawing.Point(3, 3);
			this.optNoChanges.Name = "optNoChanges";
			this.optNoChanges.Size = new System.Drawing.Size(239, 18);
			this.optNoChanges.TabIndex = 0;
			this.optNoChanges.TabStop = true;
			this.optNoChanges.Text = "товар находится в ячейке-источнике";
			this.optNoChanges.UseVisualStyleBackColor = true;
			// 
			// frmTrafficsGoodsEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(542, 460);
			this.Controls.Add(this.btnHelp);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.pnlData);
			this.hpHelp.SetHelpKeyword(this, "462");
			this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.IsModalMode = true;
			this.Name = "frmTrafficsGoodsEdit";
			this.hpHelp.SetShowHelp(this, true);
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Задание на перемещение коробок/штук";
			this.Load += new System.EventHandler(this.frmTrafficsGoodsEdit_Load);
			this.pnlData.ResumeLayout(false);
			this.pnlData.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numRestQntConfirmed)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numBoxConfirmed)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numRestQntWished)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numBoxWished)).EndInit();
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
		private RFMBaseClasses.RFMLabel lblGoodState;
		private RFMBaseClasses.RFMLabel lblOwner;
		private RFMBaseClasses.RFMTextBox txtGoodState;
		private RFMBaseClasses.RFMTextBox txtOwner;
		private RFMBaseClasses.RFMLabel lblTarget;
		private RFMBaseClasses.RFMLabel lblFrom;
		private RFMBaseClasses.RFMPanel pnlSource;
		private RFMBaseClasses.RFMComboBox cboCellSourceAddress;
		private RFMBaseClasses.RFMLabel lblCellSource;
		private RFMBaseClasses.RFMComboBox cboStoresZonesTypesSource;
		private RFMBaseClasses.RFMLabel lblStoresZonesSource;
		private RFMBaseClasses.RFMComboBox cboStoresZonesSource;
		private RFMBaseClasses.RFMPanel pnlTarget;
		private RFMBaseClasses.RFMLabel lblCellTarget;
		private RFMBaseClasses.RFMComboBox cboCellTargetAddress;
		private RFMBaseClasses.RFMComboBox cboStoresZonesTarget;
		private RFMBaseClasses.RFMComboBox cboStoresZonesTypesTarget;
		private RFMBaseClasses.RFMLabel lblStoresZonesTarget;
		private RFMBaseClasses.RFMComboBox cboDevice;
		private RFMBaseClasses.RFMPanel pnlTrafficError;
		private RFMBaseClasses.RFMPanel pnlOpt;
		private RFMBaseClasses.RFMRadioButton optNoChanges;
		private RFMBaseClasses.RFMComboBox cboTrafficError;
		private RFMBaseClasses.RFMRadioButton optError;
		private RFMBaseClasses.RFMRadioButton optCellTarget;
		private RFMBaseClasses.RFMCheckBox chkLockCellFinish;
		private RFMBaseClasses.RFMTextBox txtPackingAlias;
		private RFMBaseClasses.RFMLabel lblRestQntWished;
		private RFMBaseClasses.RFMNumericUpDown numRestQntWished;
		private RFMBaseClasses.RFMLabel lblBoxWished;
		private RFMBaseClasses.RFMNumericUpDown numBoxWished;
		private RFMBaseClasses.RFMLabel lblWished;
		private RFMBaseClasses.RFMLabel lblGood;
		private RFMBaseClasses.RFMLabel lblRestQntConfirmed;
		private RFMBaseClasses.RFMNumericUpDown numRestQntConfirmed;
		private RFMBaseClasses.RFMLabel lblBoxConfirmed;
		private RFMBaseClasses.RFMNumericUpDown numBoxConfirmed;
		private RFMBaseClasses.RFMLabel lblConfirmed;
	}
}