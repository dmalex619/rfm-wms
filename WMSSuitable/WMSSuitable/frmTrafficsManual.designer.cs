namespace WMSSuitable
{
	partial class frmTrafficsManual
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
			this.dataGridViewImageColumn1 = new WMSBaseClasses.WMSDataGridViewImageColumn();
			this.pnlData = new WMSBaseClasses.WMSPanel();
			this.txtFrameBarCode = new WMSBaseClasses.WMSTextBoxBarCode();
			this.txtFrameID4 = new WMSBaseClasses.WMSTextBox();
			this.lblTo = new WMSBaseClasses.WMSLabel();
			this.lblFrameGoodState = new WMSBaseClasses.WMSLabel();
			this.lblFrameOwner = new WMSBaseClasses.WMSLabel();
			this.txtFrameGoodState = new WMSBaseClasses.WMSTextBox();
			this.chkStereo = new WMSBaseClasses.WMSCheckBox();
			this.txtFrameOwner = new WMSBaseClasses.WMSTextBox();
			this.lblFrom = new WMSBaseClasses.WMSLabel();
			this.pnlSource = new WMSBaseClasses.WMSPanel();
			this.cboBufferCellSourceAddress = new WMSBaseClasses.WMSComboBox();
			this.cboCellSourceAddress = new WMSBaseClasses.WMSComboBox();
			this.lblCellSource = new WMSBaseClasses.WMSLabel();
			this.lblBufferCellSource = new WMSBaseClasses.WMSLabel();
			this.cboStoresZonesTypesSource = new WMSBaseClasses.WMSComboBox();
			this.lblStoresZonesSource = new WMSBaseClasses.WMSLabel();
			this.cboStoresZonesSource = new WMSBaseClasses.WMSComboBox();
			this.lblFrame = new WMSBaseClasses.WMSLabel();
			this.pnlTarget = new WMSBaseClasses.WMSPanel();
			this.cboBufferCellTargetAddress = new WMSBaseClasses.WMSComboBox();
			this.lblBufferCellTarget = new WMSBaseClasses.WMSLabel();
			this.cboStoresZonesTarget = new WMSBaseClasses.WMSComboBox();
			this.cboStoresZonesTypesTarget = new WMSBaseClasses.WMSComboBox();
			this.lblStoresZonesTarget = new WMSBaseClasses.WMSLabel();
			this.pnlOpgTarget = new WMSBaseClasses.WMSPanel();
			this.cboCellTargetAddress = new WMSBaseClasses.WMSComboBox();
			this.optStoreZoneTarget = new WMSBaseClasses.WMSRadioButton();
			this.optCellTarget = new WMSBaseClasses.WMSRadioButton();
			this.btnGo = new WMSBaseClasses.WMSButton();
			this.btnHelp = new WMSBaseClasses.WMSButton();
			this.btnCancel = new WMSBaseClasses.WMSButton();
			this.pnlData.SuspendLayout();
			this.pnlSource.SuspendLayout();
			this.pnlTarget.SuspendLayout();
			this.pnlOpgTarget.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataGridViewImageColumn1
			// 
			this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
			this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			// 
			// pnlData
			// 
			this.pnlData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlData.Controls.Add(this.txtFrameBarCode);
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
			this.pnlData.Size = new System.Drawing.Size(529, 252);
			this.pnlData.TabIndex = 0;
			// 
			// txtFrameBarCode
			// 
			this.txtFrameBarCode.Location = new System.Drawing.Point(168, 6);
			this.txtFrameBarCode.Name = "txtFrameBarCode";
			this.txtFrameBarCode.Size = new System.Drawing.Size(172, 22);
			this.txtFrameBarCode.TabIndex = 2;
			this.ttToolTip.SetToolTip(this.txtFrameBarCode, "Штрих-код контейнера");
			this.txtFrameBarCode.Validating += new System.ComponentModel.CancelEventHandler(this.txtFrameBarCode_Validating);
			this.txtFrameBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFrameBarCode_KeyDown);
			// 
			// txtFrameID4
			// 
			this.txtFrameID4.Location = new System.Drawing.Point(114, 6);
			this.txtFrameID4.MaxLength = 4;
			this.txtFrameID4.Name = "txtFrameID4";
			this.txtFrameID4.Size = new System.Drawing.Size(50, 22);
			this.txtFrameID4.TabIndex = 1;
			this.ttToolTip.SetToolTip(this.txtFrameID4, "Код контейнера (4 знака, с ведущими нулями)");
			this.txtFrameID4.TextChanged += new System.EventHandler(this.txtFrameID4_TextChanged);
			// 
			// lblTo
			// 
			this.lblTo.AutoSize = true;
			this.lblTo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblTo.Location = new System.Drawing.Point(7, 142);
			this.lblTo.Name = "lblTo";
			this.lblTo.Size = new System.Drawing.Size(37, 14);
			this.lblTo.TabIndex = 10;
			this.lblTo.Text = "Куда:";
			// 
			// lblFrameGoodState
			// 
			this.lblFrameGoodState.AutoSize = true;
			this.lblFrameGoodState.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblFrameGoodState.Location = new System.Drawing.Point(283, 37);
			this.lblFrameGoodState.Name = "lblFrameGoodState";
			this.lblFrameGoodState.Size = new System.Drawing.Size(68, 14);
			this.lblFrameGoodState.TabIndex = 6;
			this.lblFrameGoodState.Text = "Состояние";
			// 
			// lblFrameOwner
			// 
			this.lblFrameOwner.AutoSize = true;
			this.lblFrameOwner.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblFrameOwner.Location = new System.Drawing.Point(7, 37);
			this.lblFrameOwner.Name = "lblFrameOwner";
			this.lblFrameOwner.Size = new System.Drawing.Size(62, 14);
			this.lblFrameOwner.TabIndex = 4;
			this.lblFrameOwner.Text = "Владелец";
			// 
			// txtFrameGoodState
			// 
			this.txtFrameGoodState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtFrameGoodState.Enabled = false;
			this.txtFrameGoodState.Location = new System.Drawing.Point(352, 34);
			this.txtFrameGoodState.Name = "txtFrameGoodState";
			this.txtFrameGoodState.Size = new System.Drawing.Size(160, 22);
			this.txtFrameGoodState.TabIndex = 7;
			// 
			// chkStereo
			// 
			this.chkStereo.AutoSize = true;
			this.chkStereo.Enabled = false;
			this.chkStereo.Location = new System.Drawing.Point(352, 8);
			this.chkStereo.Name = "chkStereo";
			this.chkStereo.Size = new System.Drawing.Size(102, 18);
			this.chkStereo.TabIndex = 3;
			this.chkStereo.Text = "разный товар";
			this.chkStereo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.chkStereo.UseVisualStyleBackColor = true;
			// 
			// txtFrameOwner
			// 
			this.txtFrameOwner.Enabled = false;
			this.txtFrameOwner.Location = new System.Drawing.Point(114, 34);
			this.txtFrameOwner.Name = "txtFrameOwner";
			this.txtFrameOwner.Size = new System.Drawing.Size(160, 22);
			this.txtFrameOwner.TabIndex = 5;
			// 
			// lblFrom
			// 
			this.lblFrom.AutoSize = true;
			this.lblFrom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblFrom.Location = new System.Drawing.Point(7, 62);
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
			this.pnlSource.Location = new System.Drawing.Point(7, 72);
			this.pnlSource.Name = "pnlSource";
			this.pnlSource.Size = new System.Drawing.Size(512, 62);
			this.pnlSource.TabIndex = 9;
			// 
			// cboBufferCellSourceAddress
			// 
			this.cboBufferCellSourceAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cboBufferCellSourceAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboBufferCellSourceAddress.Enabled = false;
			this.cboBufferCellSourceAddress.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cboBufferCellSourceAddress.FormattingEnabled = true;
			this.cboBufferCellSourceAddress.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboBufferCellSourceAddress.Location = new System.Drawing.Point(343, 6);
			this.cboBufferCellSourceAddress.Name = "cboBufferCellSourceAddress";
			this.cboBufferCellSourceAddress.Size = new System.Drawing.Size(160, 22);
			this.cboBufferCellSourceAddress.TabIndex = 3;
			// 
			// cboCellSourceAddress
			// 
			this.cboCellSourceAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCellSourceAddress.Enabled = false;
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
			this.lblBufferCellSource.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblBufferCellSource.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblBufferCellSource.Location = new System.Drawing.Point(295, 9);
			this.lblBufferCellSource.Name = "lblBufferCellSource";
			this.lblBufferCellSource.Size = new System.Drawing.Size(44, 14);
			this.lblBufferCellSource.TabIndex = 2;
			this.lblBufferCellSource.Text = "Буфер";
			// 
			// cboStoresZonesTypesSource
			// 
			this.cboStoresZonesTypesSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cboStoresZonesTypesSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboStoresZonesTypesSource.Enabled = false;
			this.cboStoresZonesTypesSource.FormattingEnabled = true;
			this.cboStoresZonesTypesSource.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboStoresZonesTypesSource.Location = new System.Drawing.Point(343, 31);
			this.cboStoresZonesTypesSource.Name = "cboStoresZonesTypesSource";
			this.cboStoresZonesTypesSource.Size = new System.Drawing.Size(160, 22);
			this.cboStoresZonesTypesSource.TabIndex = 6;
			// 
			// lblStoresZonesSource
			// 
			this.lblStoresZonesSource.AutoSize = true;
			this.lblStoresZonesSource.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblStoresZonesSource.Location = new System.Drawing.Point(6, 34);
			this.lblStoresZonesSource.Name = "lblStoresZonesSource";
			this.lblStoresZonesSource.Size = new System.Drawing.Size(94, 14);
			this.lblStoresZonesSource.TabIndex = 4;
			this.lblStoresZonesSource.Text = "Складская зона";
			// 
			// cboStoresZonesSource
			// 
			this.cboStoresZonesSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboStoresZonesSource.Enabled = false;
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
			this.pnlTarget.Controls.Add(this.cboBufferCellTargetAddress);
			this.pnlTarget.Controls.Add(this.lblBufferCellTarget);
			this.pnlTarget.Controls.Add(this.cboStoresZonesTarget);
			this.pnlTarget.Controls.Add(this.cboStoresZonesTypesTarget);
			this.pnlTarget.Controls.Add(this.lblStoresZonesTarget);
			this.pnlTarget.Controls.Add(this.pnlOpgTarget);
			this.pnlTarget.Location = new System.Drawing.Point(7, 153);
			this.pnlTarget.Name = "pnlTarget";
			this.pnlTarget.Size = new System.Drawing.Size(512, 89);
			this.pnlTarget.TabIndex = 11;
			// 
			// cboBufferCellTargetAddress
			// 
			this.cboBufferCellTargetAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cboBufferCellTargetAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboBufferCellTargetAddress.Enabled = false;
			this.cboBufferCellTargetAddress.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cboBufferCellTargetAddress.FormattingEnabled = true;
			this.cboBufferCellTargetAddress.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboBufferCellTargetAddress.Location = new System.Drawing.Point(343, 58);
			this.cboBufferCellTargetAddress.Name = "cboBufferCellTargetAddress";
			this.cboBufferCellTargetAddress.Size = new System.Drawing.Size(160, 22);
			this.cboBufferCellTargetAddress.TabIndex = 5;
			// 
			// lblBufferCellTarget
			// 
			this.lblBufferCellTarget.AutoSize = true;
			this.lblBufferCellTarget.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblBufferCellTarget.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblBufferCellTarget.Location = new System.Drawing.Point(295, 61);
			this.lblBufferCellTarget.Name = "lblBufferCellTarget";
			this.lblBufferCellTarget.Size = new System.Drawing.Size(44, 14);
			this.lblBufferCellTarget.TabIndex = 4;
			this.lblBufferCellTarget.Text = "Буфер";
			// 
			// cboStoresZonesTarget
			// 
			this.cboStoresZonesTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboStoresZonesTarget.FormattingEnabled = true;
			this.cboStoresZonesTarget.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboStoresZonesTarget.Location = new System.Drawing.Point(105, 6);
			this.cboStoresZonesTarget.Name = "cboStoresZonesTarget";
			this.cboStoresZonesTarget.Size = new System.Drawing.Size(234, 22);
			this.cboStoresZonesTarget.TabIndex = 1;
			this.cboStoresZonesTarget.SelectedIndexChanged += new System.EventHandler(this.cboStoresZonesTarget_SelectedIndexChanged);
			// 
			// cboStoresZonesTypesTarget
			// 
			this.cboStoresZonesTypesTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cboStoresZonesTypesTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboStoresZonesTypesTarget.Enabled = false;
			this.cboStoresZonesTypesTarget.FormattingEnabled = true;
			this.cboStoresZonesTypesTarget.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboStoresZonesTypesTarget.Location = new System.Drawing.Point(343, 6);
			this.cboStoresZonesTypesTarget.Name = "cboStoresZonesTypesTarget";
			this.cboStoresZonesTypesTarget.Size = new System.Drawing.Size(160, 22);
			this.cboStoresZonesTypesTarget.TabIndex = 2;
			// 
			// lblStoresZonesTarget
			// 
			this.lblStoresZonesTarget.AutoSize = true;
			this.lblStoresZonesTarget.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblStoresZonesTarget.Location = new System.Drawing.Point(6, 9);
			this.lblStoresZonesTarget.Name = "lblStoresZonesTarget";
			this.lblStoresZonesTarget.Size = new System.Drawing.Size(94, 14);
			this.lblStoresZonesTarget.TabIndex = 0;
			this.lblStoresZonesTarget.Text = "Складская зона";
			// 
			// pnlOpgTarget
			// 
			this.pnlOpgTarget.Controls.Add(this.cboCellTargetAddress);
			this.pnlOpgTarget.Controls.Add(this.optStoreZoneTarget);
			this.pnlOpgTarget.Controls.Add(this.optCellTarget);
			this.pnlOpgTarget.Location = new System.Drawing.Point(9, 32);
			this.pnlOpgTarget.Name = "pnlOpgTarget";
			this.pnlOpgTarget.Size = new System.Drawing.Size(263, 51);
			this.pnlOpgTarget.TabIndex = 3;
			// 
			// cboCellTargetAddress
			// 
			this.cboCellTargetAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCellTargetAddress.Enabled = false;
			this.cboCellTargetAddress.FormattingEnabled = true;
			this.cboCellTargetAddress.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboCellTargetAddress.Location = new System.Drawing.Point(96, 24);
			this.cboCellTargetAddress.Name = "cboCellTargetAddress";
			this.cboCellTargetAddress.Size = new System.Drawing.Size(160, 22);
			this.cboCellTargetAddress.TabIndex = 2;
			this.cboCellTargetAddress.SelectedIndexChanged += new System.EventHandler(this.cboCellTargetAddress_SelectedIndexChanged);
			// 
			// optStoreZoneTarget
			// 
			this.optStoreZoneTarget.AutoSize = true;
			this.optStoreZoneTarget.Checked = true;
			this.optStoreZoneTarget.IsChanged = true;
			this.optStoreZoneTarget.Location = new System.Drawing.Point(3, 3);
			this.optStoreZoneTarget.Name = "optStoreZoneTarget";
			this.optStoreZoneTarget.Size = new System.Drawing.Size(211, 18);
			this.optStoreZoneTarget.TabIndex = 0;
			this.optStoreZoneTarget.TabStop = true;
			this.optStoreZoneTarget.Text = "Любая подходящая ячейка зоны";
			this.optStoreZoneTarget.UseVisualStyleBackColor = true;
			this.optStoreZoneTarget.CheckedChanged += new System.EventHandler(this.optCellTarget_CheckedChanged);
			// 
			// optCellTarget
			// 
			this.optCellTarget.AutoSize = true;
			this.optCellTarget.Location = new System.Drawing.Point(3, 27);
			this.optCellTarget.Name = "optCellTarget";
			this.optCellTarget.Size = new System.Drawing.Size(65, 18);
			this.optCellTarget.TabIndex = 1;
			this.optCellTarget.Text = "Ячейка";
			this.optCellTarget.UseVisualStyleBackColor = true;
			this.optCellTarget.CheckedChanged += new System.EventHandler(this.optCellTarget_CheckedChanged);
			// 
			// btnGo
			// 
			this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGo.Image = global::WMSSuitable.Properties.Resources.Go;
			this.btnGo.Location = new System.Drawing.Point(455, 266);
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
			this.btnHelp.Location = new System.Drawing.Point(6, 266);
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
			this.btnCancel.Location = new System.Drawing.Point(505, 266);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(30, 30);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// frmTrafficsManual
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(542, 302);
			this.Controls.Add(this.pnlData);
			this.Controls.Add(this.btnHelp);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnGo);
			this.hpHelp.SetHelpKeyword(this, "411");
			this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.IsModalMode = true;
			this.Name = "frmTrafficsManual";
			this.hpHelp.SetShowHelp(this, true);
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Транспортировка контейнера";
			this.Load += new System.EventHandler(this.frmTrafficManual_Load);
			this.pnlData.ResumeLayout(false);
			this.pnlData.PerformLayout();
			this.pnlSource.ResumeLayout(false);
			this.pnlSource.PerformLayout();
			this.pnlTarget.ResumeLayout(false);
			this.pnlTarget.PerformLayout();
			this.pnlOpgTarget.ResumeLayout(false);
			this.pnlOpgTarget.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

        private WMSBaseClasses.WMSButton btnGo;
        private WMSBaseClasses.WMSButton btnCancel;
        private WMSBaseClasses.WMSDataGridViewImageColumn dataGridViewImageColumn1;
        private WMSBaseClasses.WMSButton btnHelp;
		private WMSBaseClasses.WMSPanel pnlData;
		private WMSBaseClasses.WMSLabel lblFrame;
		private WMSBaseClasses.WMSLabel lblFrom;
		private WMSBaseClasses.WMSPanel pnlTarget;
		private WMSBaseClasses.WMSComboBox cboStoresZonesTypesTarget;
		private WMSBaseClasses.WMSLabel lblStoresZonesTarget;
		private WMSBaseClasses.WMSComboBox cboStoresZonesTarget;
		private WMSBaseClasses.WMSPanel pnlSource;
		private WMSBaseClasses.WMSLabel lblCellSource;
		private WMSBaseClasses.WMSLabel lblBufferCellSource;
		private WMSBaseClasses.WMSComboBox cboStoresZonesTypesSource;
		private WMSBaseClasses.WMSLabel lblStoresZonesSource;
		private WMSBaseClasses.WMSComboBox cboStoresZonesSource;
		private WMSBaseClasses.WMSTextBox txtFrameGoodState;
		private WMSBaseClasses.WMSCheckBox chkStereo;
		private WMSBaseClasses.WMSTextBox txtFrameOwner;
		private WMSBaseClasses.WMSLabel lblFrameGoodState;
		private WMSBaseClasses.WMSLabel lblFrameOwner;
		private WMSBaseClasses.WMSPanel pnlOpgTarget;
		private WMSBaseClasses.WMSRadioButton optStoreZoneTarget;
		private WMSBaseClasses.WMSRadioButton optCellTarget;
		private WMSBaseClasses.WMSComboBox cboCellSourceAddress;
		private WMSBaseClasses.WMSComboBox cboCellTargetAddress;
		private WMSBaseClasses.WMSComboBox cboBufferCellSourceAddress;
		private WMSBaseClasses.WMSLabel lblTo;
		private WMSBaseClasses.WMSComboBox cboBufferCellTargetAddress;
		private WMSBaseClasses.WMSLabel lblBufferCellTarget;
		private WMSBaseClasses.WMSTextBox txtFrameID4;
		private WMSBaseClasses.WMSTextBoxBarCode txtFrameBarCode;
	}
}