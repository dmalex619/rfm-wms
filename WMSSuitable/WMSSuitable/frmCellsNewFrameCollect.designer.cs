namespace WMSSuitable
{
	partial class frmCellsNewFrameCollect
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			this.btnHelp = new RFMBaseClasses.RFMButton();
			this.btnCancel = new RFMBaseClasses.RFMButton();
			this.btnSave = new RFMBaseClasses.RFMButton();
			this.btnGridSave = new RFMBaseClasses.RFMButton();
			this.btnGridUndo = new RFMBaseClasses.RFMButton();
			this.btnEdit = new RFMBaseClasses.RFMButton();
			this.numRestQnt = new RFMBaseClasses.RFMNumericUpDown();
			this.numBoxQnt = new RFMBaseClasses.RFMNumericUpDown();
			this.txtFrameBarCode = new RFMBaseClasses.RFMTextBoxBarCode();
			this.txtFrameID4 = new RFMBaseClasses.RFMTextBoxNumeric();
			this.btnFrameEdit = new RFMBaseClasses.RFMButton();
			this.lblCell = new RFMBaseClasses.RFMLabel();
			this.pnlData = new RFMBaseClasses.RFMPanel();
			this.lblCellTarget = new RFMBaseClasses.RFMLabel();
			this.lblStoreZoneTarget = new RFMBaseClasses.RFMLabel();
			this.cboCellTargetAddress = new RFMBaseClasses.RFMComboBox();
			this.cboStoresZonesTarget = new RFMBaseClasses.RFMComboBox();
			this.cboStoresZonesTypesTarget = new RFMBaseClasses.RFMComboBox();
			this.lblCollect = new RFMBaseClasses.RFMLabel();
			this.chkStereo = new RFMBaseClasses.RFMCheckBox();
			this.pnlDataChange = new RFMBaseClasses.RFMPanel();
			this.lblPackingName = new RFMBaseClasses.RFMLabel();
			this.lblQnt = new RFMBaseClasses.RFMLabel();
			this.lblBoxQnt = new RFMBaseClasses.RFMLabel();
			this.dtpDateValid = new RFMBaseClasses.RFMDateTimePicker();
			this.lblDateValid = new RFMBaseClasses.RFMLabel();
			this.lblQntNew = new RFMBaseClasses.RFMLabel();
			this.lblGood = new RFMBaseClasses.RFMLabel();
			this.grdCellsContents = new RFMBaseClasses.RFMDataGridView();
			this.grcGoodAlias = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcInBox = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcQnt = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcBoxQnt = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcQntCollect = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcBoxCollect = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcDateValid = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcOwnerName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcGoodStateName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcPalQnt = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcWeighting = new RFMBaseClasses.RFMDataGridViewCheckBoxColumn();
			this.grcPackingID = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcCellsContentsID = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.lblCellID = new RFMBaseClasses.RFMLabel();
			this.pnlOptTraffic = new RFMBaseClasses.RFMPanel();
			this.optDirectToCell = new RFMBaseClasses.RFMRadioButton();
			this.optCreateTrafficAccommodation = new RFMBaseClasses.RFMRadioButton();
			this.optNotCreateTraffic = new RFMBaseClasses.RFMRadioButton();
			this.optCreateTrafficCell = new RFMBaseClasses.RFMRadioButton();
			((System.ComponentModel.ISupportInitialize)(this.numRestQnt)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numBoxQnt)).BeginInit();
			this.pnlData.SuspendLayout();
			this.pnlDataChange.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdCellsContents)).BeginInit();
			this.pnlOptTraffic.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnHelp
			// 
			this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnHelp.Image = global::WMSSuitable.Properties.Resources.Help;
			this.btnHelp.Location = new System.Drawing.Point(6, 412);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new System.Drawing.Size(30, 30);
			this.btnHelp.TabIndex = 3;
			this.btnHelp.UseVisualStyleBackColor = true;
			this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Image = global::WMSSuitable.Properties.Resources.Exit;
			this.btnCancel.Location = new System.Drawing.Point(656, 412);
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
			this.btnSave.Location = new System.Drawing.Point(606, 412);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(30, 30);
			this.btnSave.TabIndex = 1;
			this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ttToolTip.SetToolTip(this.btnSave, "Сохранить");
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnGridSave
			// 
			this.btnGridSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGridSave.Image = global::WMSSuitable.Properties.Resources.Save;
			this.btnGridSave.Location = new System.Drawing.Point(644, 178);
			this.btnGridSave.Name = "btnGridSave";
			this.btnGridSave.Size = new System.Drawing.Size(30, 30);
			this.btnGridSave.TabIndex = 6;
			this.btnGridSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ttToolTip.SetToolTip(this.btnGridSave, "Сохранить временные изменения");
			this.btnGridSave.UseVisualStyleBackColor = true;
			this.btnGridSave.Click += new System.EventHandler(this.btnGridSave_Click);
			// 
			// btnGridUndo
			// 
			this.btnGridUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGridUndo.Image = global::WMSSuitable.Properties.Resources.UnDo;
			this.btnGridUndo.Location = new System.Drawing.Point(604, 178);
			this.btnGridUndo.Name = "btnGridUndo";
			this.btnGridUndo.Size = new System.Drawing.Size(30, 30);
			this.btnGridUndo.TabIndex = 5;
			this.btnGridUndo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ttToolTip.SetToolTip(this.btnGridUndo, "Отказаться от изменений");
			this.btnGridUndo.UseVisualStyleBackColor = true;
			this.btnGridUndo.Click += new System.EventHandler(this.btnGridUndo_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEdit.Image = global::WMSSuitable.Properties.Resources.Edit;
			this.btnEdit.Location = new System.Drawing.Point(564, 178);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(30, 30);
			this.btnEdit.TabIndex = 4;
			this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ttToolTip.SetToolTip(this.btnEdit, "Включить в контейнер");
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// numRestQnt
			// 
			this.numRestQnt.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.numRestQnt.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.numRestQnt.IsNull = false;
			this.numRestQnt.Location = new System.Drawing.Point(195, 23);
			this.numRestQnt.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
			this.numRestQnt.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
			this.numRestQnt.Name = "numRestQnt";
			this.numRestQnt.Size = new System.Drawing.Size(110, 22);
			this.numRestQnt.TabIndex = 5;
			this.numRestQnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.ttToolTip.SetToolTip(this.numRestQnt, "Дополнительно штук в нецелой коробке / кг");
			// 
			// numBoxQnt
			// 
			this.numBoxQnt.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.numBoxQnt.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.numBoxQnt.IsNull = false;
			this.numBoxQnt.Location = new System.Drawing.Point(84, 23);
			this.numBoxQnt.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
			this.numBoxQnt.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
			this.numBoxQnt.Name = "numBoxQnt";
			this.numBoxQnt.Size = new System.Drawing.Size(60, 22);
			this.numBoxQnt.TabIndex = 3;
			this.numBoxQnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.ttToolTip.SetToolTip(this.numBoxQnt, "количество целых коробок");
			// 
			// txtFrameBarCode
			// 
			this.txtFrameBarCode.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtFrameBarCode.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtFrameBarCode.Location = new System.Drawing.Point(252, 234);
			this.txtFrameBarCode.MaxLength = 16;
			this.txtFrameBarCode.Name = "txtFrameBarCode";
			this.txtFrameBarCode.Size = new System.Drawing.Size(160, 22);
			this.txtFrameBarCode.TabIndex = 9;
			this.ttToolTip.SetToolTip(this.txtFrameBarCode, "Штрих-код контейнера");
			this.txtFrameBarCode.Validating += new System.ComponentModel.CancelEventHandler(this.txtFrameBarCode_Validating);
			// 
			// txtFrameID4
			// 
			this.txtFrameID4.Location = new System.Drawing.Point(199, 234);
			this.txtFrameID4.MaxLength = 4;
			this.txtFrameID4.Name = "txtFrameID4";
			this.txtFrameID4.OldValue = null;
			this.txtFrameID4.Size = new System.Drawing.Size(50, 22);
			this.txtFrameID4.TabIndex = 8;
			this.ttToolTip.SetToolTip(this.txtFrameID4, "Код контейнера (4 знака, с ведущими нулями)");
			this.txtFrameID4.TextChanged += new System.EventHandler(this.txtFrameID4_TextChanged);
			// 
			// btnFrameEdit
			// 
			this.btnFrameEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFrameEdit.Image = global::WMSSuitable.Properties.Resources.Geometry1;
			this.btnFrameEdit.Location = new System.Drawing.Point(644, 229);
			this.btnFrameEdit.Name = "btnFrameEdit";
			this.btnFrameEdit.Size = new System.Drawing.Size(30, 30);
			this.btnFrameEdit.TabIndex = 11;
			this.btnFrameEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ttToolTip.SetToolTip(this.btnFrameEdit, "Изменить тип поддона и высоту контейнера");
			this.btnFrameEdit.UseVisualStyleBackColor = true;
			this.btnFrameEdit.Click += new System.EventHandler(this.btnFrameEdit_Click);
			// 
			// lblCell
			// 
			this.lblCell.AutoSize = true;
			this.lblCell.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblCell.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblCell.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCell.Location = new System.Drawing.Point(3, 4);
			this.lblCell.Name = "lblCell";
			this.lblCell.Size = new System.Drawing.Size(126, 14);
			this.lblCell.TabIndex = 0;
			this.lblCell.Text = "Содержимое ячейки";
			// 
			// pnlData
			// 
			this.pnlData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlData.Controls.Add(this.lblCellTarget);
			this.pnlData.Controls.Add(this.lblStoreZoneTarget);
			this.pnlData.Controls.Add(this.cboCellTargetAddress);
			this.pnlData.Controls.Add(this.btnFrameEdit);
			this.pnlData.Controls.Add(this.cboStoresZonesTarget);
			this.pnlData.Controls.Add(this.cboStoresZonesTypesTarget);
			this.pnlData.Controls.Add(this.lblCollect);
			this.pnlData.Controls.Add(this.txtFrameBarCode);
			this.pnlData.Controls.Add(this.txtFrameID4);
			this.pnlData.Controls.Add(this.chkStereo);
			this.pnlData.Controls.Add(this.btnGridSave);
			this.pnlData.Controls.Add(this.btnGridUndo);
			this.pnlData.Controls.Add(this.pnlDataChange);
			this.pnlData.Controls.Add(this.btnEdit);
			this.pnlData.Controls.Add(this.grdCellsContents);
			this.pnlData.Controls.Add(this.lblCellID);
			this.pnlData.Controls.Add(this.lblCell);
			this.pnlData.Controls.Add(this.pnlOptTraffic);
			this.pnlData.Location = new System.Drawing.Point(5, 5);
			this.pnlData.Name = "pnlData";
			this.pnlData.Size = new System.Drawing.Size(681, 398);
			this.pnlData.TabIndex = 0;
			// 
			// lblCellTarget
			// 
			this.lblCellTarget.AutoSize = true;
			this.lblCellTarget.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblCellTarget.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblCellTarget.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCellTarget.Location = new System.Drawing.Point(156, 371);
			this.lblCellTarget.Name = "lblCellTarget";
			this.lblCellTarget.Size = new System.Drawing.Size(47, 14);
			this.lblCellTarget.TabIndex = 16;
			this.lblCellTarget.Text = "ячейка";
			// 
			// lblStoreZoneTarget
			// 
			this.lblStoreZoneTarget.AutoSize = true;
			this.lblStoreZoneTarget.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblStoreZoneTarget.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblStoreZoneTarget.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblStoreZoneTarget.Location = new System.Drawing.Point(156, 347);
			this.lblStoreZoneTarget.Name = "lblStoreZoneTarget";
			this.lblStoreZoneTarget.Size = new System.Drawing.Size(93, 14);
			this.lblStoreZoneTarget.TabIndex = 13;
			this.lblStoreZoneTarget.Text = "складская зона";
			// 
			// cboCellTargetAddress
			// 
			this.cboCellTargetAddress.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboCellTargetAddress.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboCellTargetAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCellTargetAddress.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboCellTargetAddress.Location = new System.Drawing.Point(252, 368);
			this.cboCellTargetAddress.Name = "cboCellTargetAddress";
			this.cboCellTargetAddress.Size = new System.Drawing.Size(160, 22);
			this.cboCellTargetAddress.TabIndex = 17;
			this.cboCellTargetAddress.SelectedIndexChanged += new System.EventHandler(this.cboCellTargetAddress_SelectedIndexChanged);
			// 
			// cboStoresZonesTarget
			// 
			this.cboStoresZonesTarget.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboStoresZonesTarget.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboStoresZonesTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboStoresZonesTarget.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboStoresZonesTarget.Location = new System.Drawing.Point(252, 344);
			this.cboStoresZonesTarget.Name = "cboStoresZonesTarget";
			this.cboStoresZonesTarget.Size = new System.Drawing.Size(160, 22);
			this.cboStoresZonesTarget.TabIndex = 14;
			this.cboStoresZonesTarget.SelectedIndexChanged += new System.EventHandler(this.cboStoresZonesTarget_SelectedIndexChanged);
			// 
			// cboStoresZonesTypesTarget
			// 
			this.cboStoresZonesTypesTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cboStoresZonesTypesTarget.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboStoresZonesTypesTarget.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboStoresZonesTypesTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboStoresZonesTypesTarget.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboStoresZonesTypesTarget.Location = new System.Drawing.Point(415, 344);
			this.cboStoresZonesTypesTarget.Name = "cboStoresZonesTypesTarget";
			this.cboStoresZonesTypesTarget.Size = new System.Drawing.Size(137, 22);
			this.cboStoresZonesTypesTarget.TabIndex = 15;
			// 
			// lblCollect
			// 
			this.lblCollect.AutoSize = true;
			this.lblCollect.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblCollect.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblCollect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCollect.Location = new System.Drawing.Point(7, 237);
			this.lblCollect.Name = "lblCollect";
			this.lblCollect.Size = new System.Drawing.Size(168, 14);
			this.lblCollect.TabIndex = 7;
			this.lblCollect.Text = "Собрать товар в контейнер ";
			// 
			// chkStereo
			// 
			this.chkStereo.AutoSize = true;
			this.chkStereo.Location = new System.Drawing.Point(456, 236);
			this.chkStereo.Name = "chkStereo";
			this.chkStereo.Size = new System.Drawing.Size(184, 18);
			this.chkStereo.TabIndex = 10;
			this.chkStereo.Text = "разный товар в контейнере";
			this.chkStereo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.chkStereo.UseVisualStyleBackColor = true;
			this.chkStereo.Visible = false;
			// 
			// pnlDataChange
			// 
			this.pnlDataChange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlDataChange.Controls.Add(this.lblPackingName);
			this.pnlDataChange.Controls.Add(this.lblQnt);
			this.pnlDataChange.Controls.Add(this.numRestQnt);
			this.pnlDataChange.Controls.Add(this.lblBoxQnt);
			this.pnlDataChange.Controls.Add(this.numBoxQnt);
			this.pnlDataChange.Controls.Add(this.dtpDateValid);
			this.pnlDataChange.Controls.Add(this.lblDateValid);
			this.pnlDataChange.Controls.Add(this.lblQntNew);
			this.pnlDataChange.Controls.Add(this.lblGood);
			this.pnlDataChange.Location = new System.Drawing.Point(3, 177);
			this.pnlDataChange.Name = "pnlDataChange";
			this.pnlDataChange.Size = new System.Drawing.Size(555, 52);
			this.pnlDataChange.TabIndex = 3;
			// 
			// lblPackingName
			// 
			this.lblPackingName.AutoSize = true;
			this.lblPackingName.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblPackingName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblPackingName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblPackingName.Location = new System.Drawing.Point(82, 4);
			this.lblPackingName.Name = "lblPackingName";
			this.lblPackingName.Size = new System.Drawing.Size(48, 14);
			this.lblPackingName.TabIndex = 1;
			this.lblPackingName.Text = "_Товар";
			// 
			// lblQnt
			// 
			this.lblQnt.AutoSize = true;
			this.lblQnt.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblQnt.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblQnt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblQnt.Location = new System.Drawing.Point(306, 27);
			this.lblQnt.Name = "lblQnt";
			this.lblQnt.Size = new System.Drawing.Size(41, 14);
			this.lblQnt.TabIndex = 6;
			this.lblQnt.Text = "шт./кг";
			// 
			// lblBoxQnt
			// 
			this.lblBoxQnt.AutoSize = true;
			this.lblBoxQnt.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblBoxQnt.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblBoxQnt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblBoxQnt.Location = new System.Drawing.Point(150, 27);
			this.lblBoxQnt.Name = "lblBoxQnt";
			this.lblBoxQnt.Size = new System.Drawing.Size(47, 14);
			this.lblBoxQnt.TabIndex = 4;
			this.lblBoxQnt.Text = "кор. + ";
			// 
			// dtpDateValid
			// 
			this.dtpDateValid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.dtpDateValid.CustomFormat = "dd.MM.yyyy";
			this.dtpDateValid.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.dtpDateValid.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.dtpDateValid.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpDateValid.Location = new System.Drawing.Point(452, 23);
			this.dtpDateValid.Name = "dtpDateValid";
			this.dtpDateValid.Size = new System.Drawing.Size(96, 22);
			this.dtpDateValid.TabIndex = 8;
			// 
			// lblDateValid
			// 
			this.lblDateValid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDateValid.AutoSize = true;
			this.lblDateValid.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblDateValid.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblDateValid.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblDateValid.Location = new System.Drawing.Point(358, 27);
			this.lblDateValid.Name = "lblDateValid";
			this.lblDateValid.Size = new System.Drawing.Size(90, 14);
			this.lblDateValid.TabIndex = 7;
			this.lblDateValid.Text = "Срок годн., до";
			// 
			// lblQntNew
			// 
			this.lblQntNew.AutoSize = true;
			this.lblQntNew.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblQntNew.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblQntNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblQntNew.Location = new System.Drawing.Point(4, 27);
			this.lblQntNew.Name = "lblQntNew";
			this.lblQntNew.Size = new System.Drawing.Size(74, 14);
			this.lblQntNew.TabIndex = 2;
			this.lblQntNew.Text = "Количество";
			// 
			// lblGood
			// 
			this.lblGood.AutoSize = true;
			this.lblGood.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblGood.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblGood.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblGood.Location = new System.Drawing.Point(4, 4);
			this.lblGood.Name = "lblGood";
			this.lblGood.Size = new System.Drawing.Size(41, 14);
			this.lblGood.TabIndex = 0;
			this.lblGood.Text = "Товар";
			// 
			// grdCellsContents
			// 
			this.grdCellsContents.AllowUserToAddRows = false;
			this.grdCellsContents.AllowUserToDeleteRows = false;
			this.grdCellsContents.AllowUserToOrderColumns = true;
			this.grdCellsContents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.grdCellsContents.BackgroundColor = System.Drawing.SystemColors.Window;
			this.grdCellsContents.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.grdCellsContents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.grdCellsContents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdCellsContents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grcGoodAlias,
            this.grcInBox,
            this.grcQnt,
            this.grcBoxQnt,
            this.grcQntCollect,
            this.grcBoxCollect,
            this.grcDateValid,
            this.grcOwnerName,
            this.grcGoodStateName,
            this.grcPalQnt,
            this.grcWeighting,
            this.grcPackingID,
            this.grcCellsContentsID});
			this.grdCellsContents.IsConfigInclude = true;
			this.grdCellsContents.IsMarkedAll = false;
			this.grdCellsContents.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.grdCellsContents.Location = new System.Drawing.Point(3, 21);
			this.grdCellsContents.MultiSelect = false;
			this.grdCellsContents.Name = "grdCellsContents";
			this.grdCellsContents.RangedWay = ' ';
			this.grdCellsContents.ReadOnly = true;
			this.grdCellsContents.RowHeadersWidth = 24;
			this.grdCellsContents.Size = new System.Drawing.Size(672, 153);
			this.grdCellsContents.TabIndex = 2;
			this.grdCellsContents.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCellsContents_RowEnter);
			this.grdCellsContents.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCellsContents_CellContentDoubleClick);
			this.grdCellsContents.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdCellsContents_CellFormatting);
			// 
			// grcGoodAlias
			// 
			this.grcGoodAlias.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcGoodAlias.DataPropertyName = "GoodAlias";
			this.grcGoodAlias.HeaderText = "Товар";
			this.grcGoodAlias.Name = "grcGoodAlias";
			this.grcGoodAlias.ReadOnly = true;
			this.grcGoodAlias.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcGoodAlias.Width = 250;
			// 
			// grcInBox
			// 
			this.grcInBox.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcInBox.DataPropertyName = "InBox";
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle2.Format = "N0";
			this.grcInBox.DefaultCellStyle = dataGridViewCellStyle2;
			this.grcInBox.HeaderText = "В кор.";
			this.grcInBox.Name = "grcInBox";
			this.grcInBox.ReadOnly = true;
			this.grcInBox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcInBox.ToolTipText = "Штук/кг в коробке";
			this.grcInBox.Width = 60;
			// 
			// grcQnt
			// 
			this.grcQnt.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcQnt.DataPropertyName = "Qnt";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle3.Format = "N3";
			dataGridViewCellStyle3.NullValue = null;
			this.grcQnt.DefaultCellStyle = dataGridViewCellStyle3;
			this.grcQnt.HeaderText = "Штук";
			this.grcQnt.Name = "grcQnt";
			this.grcQnt.ReadOnly = true;
			this.grcQnt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcQnt.Width = 80;
			// 
			// grcBoxQnt
			// 
			this.grcBoxQnt.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcBoxQnt.DataPropertyName = "BoxQnt";
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle4.Format = "N1";
			dataGridViewCellStyle4.NullValue = null;
			this.grcBoxQnt.DefaultCellStyle = dataGridViewCellStyle4;
			this.grcBoxQnt.HeaderText = "Кор.";
			this.grcBoxQnt.Name = "grcBoxQnt";
			this.grcBoxQnt.ReadOnly = true;
			this.grcBoxQnt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcBoxQnt.Width = 60;
			// 
			// grcQntCollect
			// 
			this.grcQntCollect.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcQntCollect.DataPropertyName = "QntCollect";
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle5.Format = "N3";
			this.grcQntCollect.DefaultCellStyle = dataGridViewCellStyle5;
			this.grcQntCollect.HeaderText = "Собр.штук";
			this.grcQntCollect.Name = "grcQntCollect";
			this.grcQntCollect.ReadOnly = true;
			this.grcQntCollect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcQntCollect.ToolTipText = "Собрано в контейнер штук";
			this.grcQntCollect.Width = 80;
			// 
			// grcBoxCollect
			// 
			this.grcBoxCollect.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcBoxCollect.DataPropertyName = "BoxCollect";
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle6.Format = "N1";
			this.grcBoxCollect.DefaultCellStyle = dataGridViewCellStyle6;
			this.grcBoxCollect.HeaderText = "Собр.кор.";
			this.grcBoxCollect.Name = "grcBoxCollect";
			this.grcBoxCollect.ReadOnly = true;
			this.grcBoxCollect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcBoxCollect.ToolTipText = "Собрано в контейнер коробок";
			this.grcBoxCollect.Width = 60;
			// 
			// grcDateValid
			// 
			this.grcDateValid.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcDateValid.DataPropertyName = "DateValid";
			dataGridViewCellStyle7.Format = "d";
			dataGridViewCellStyle7.NullValue = null;
			this.grcDateValid.DefaultCellStyle = dataGridViewCellStyle7;
			this.grcDateValid.HeaderText = "Срок годн.";
			this.grcDateValid.Name = "grcDateValid";
			this.grcDateValid.ReadOnly = true;
			this.grcDateValid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcDateValid.Width = 90;
			// 
			// grcOwnerName
			// 
			this.grcOwnerName.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcOwnerName.DataPropertyName = "OwnerName";
			this.grcOwnerName.HeaderText = "Хранитель";
			this.grcOwnerName.Name = "grcOwnerName";
			this.grcOwnerName.ReadOnly = true;
			this.grcOwnerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcOwnerName.Width = 150;
			// 
			// grcGoodStateName
			// 
			this.grcGoodStateName.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcGoodStateName.DataPropertyName = "GoodStateName";
			this.grcGoodStateName.HeaderText = "Состояние";
			this.grcGoodStateName.Name = "grcGoodStateName";
			this.grcGoodStateName.ReadOnly = true;
			this.grcGoodStateName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcGoodStateName.Width = 150;
			// 
			// grcPalQnt
			// 
			this.grcPalQnt.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcPalQnt.DataPropertyName = "PalQnt";
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle8.Format = "N2";
			dataGridViewCellStyle8.NullValue = null;
			this.grcPalQnt.DefaultCellStyle = dataGridViewCellStyle8;
			this.grcPalQnt.HeaderText = "Пал.";
			this.grcPalQnt.Name = "grcPalQnt";
			this.grcPalQnt.ReadOnly = true;
			this.grcPalQnt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcPalQnt.Width = 60;
			// 
			// grcWeighting
			// 
			this.grcWeighting.DataPropertyName = "Weighting";
			this.grcWeighting.HeaderText = "Вес?";
			this.grcWeighting.Name = "grcWeighting";
			this.grcWeighting.ReadOnly = true;
			this.grcWeighting.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.grcWeighting.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcWeighting.ToolTipText = "Весовой товар?";
			this.grcWeighting.Width = 40;
			// 
			// grcPackingID
			// 
			this.grcPackingID.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcPackingID.DataPropertyName = "PackingID";
			this.grcPackingID.HeaderText = "PackingID";
			this.grcPackingID.Name = "grcPackingID";
			this.grcPackingID.ReadOnly = true;
			this.grcPackingID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcPackingID.Visible = false;
			// 
			// grcCellsContentsID
			// 
			this.grcCellsContentsID.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcCellsContentsID.DataPropertyName = "ID";
			this.grcCellsContentsID.HeaderText = "ID";
			this.grcCellsContentsID.Name = "grcCellsContentsID";
			this.grcCellsContentsID.ReadOnly = true;
			this.grcCellsContentsID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcCellsContentsID.Visible = false;
			this.grcCellsContentsID.Width = 40;
			// 
			// lblCellID
			// 
			this.lblCellID.AutoSize = true;
			this.lblCellID.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblCellID.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblCellID.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblCellID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCellID.Location = new System.Drawing.Point(135, 4);
			this.lblCellID.Name = "lblCellID";
			this.lblCellID.Size = new System.Drawing.Size(42, 14);
			this.lblCellID.TabIndex = 1;
			this.lblCellID.Text = "CellID";
			// 
			// pnlOptTraffic
			// 
			this.pnlOptTraffic.Controls.Add(this.optDirectToCell);
			this.pnlOptTraffic.Controls.Add(this.optCreateTrafficAccommodation);
			this.pnlOptTraffic.Controls.Add(this.optNotCreateTraffic);
			this.pnlOptTraffic.Controls.Add(this.optCreateTrafficCell);
			this.pnlOptTraffic.Location = new System.Drawing.Point(6, 258);
			this.pnlOptTraffic.Name = "pnlOptTraffic";
			this.pnlOptTraffic.Size = new System.Drawing.Size(667, 85);
			this.pnlOptTraffic.TabIndex = 12;
			// 
			// optDirectToCell
			// 
			this.optDirectToCell.AutoSize = true;
			this.optDirectToCell.Location = new System.Drawing.Point(4, 63);
			this.optDirectToCell.Name = "optDirectToCell";
			this.optDirectToCell.Size = new System.Drawing.Size(284, 18);
			this.optDirectToCell.TabIndex = 3;
			this.optDirectToCell.Text = "разместить контейнер в конкретной ячейке:";
			this.optDirectToCell.UseVisualStyleBackColor = true;
			this.optDirectToCell.CheckedChanged += new System.EventHandler(this.optCreateTraffic_CheckedChanged);
			// 
			// optCreateTrafficAccommodation
			// 
			this.optCreateTrafficAccommodation.AutoSize = true;
			this.optCreateTrafficAccommodation.IsChanged = true;
			this.optCreateTrafficAccommodation.Location = new System.Drawing.Point(3, 23);
			this.optCreateTrafficAccommodation.Name = "optCreateTrafficAccommodation";
			this.optCreateTrafficAccommodation.Size = new System.Drawing.Size(590, 18);
			this.optCreateTrafficAccommodation.TabIndex = 1;
			this.optCreateTrafficAccommodation.Text = "создать операцию транспортировки для размещения контейнера в подходящей ячейке хр" +
				"анения";
			this.optCreateTrafficAccommodation.UseVisualStyleBackColor = true;
			this.optCreateTrafficAccommodation.CheckedChanged += new System.EventHandler(this.optCreateTraffic_CheckedChanged);
			// 
			// optNotCreateTraffic
			// 
			this.optNotCreateTraffic.AutoSize = true;
			this.optNotCreateTraffic.Checked = true;
			this.optNotCreateTraffic.IsChanged = true;
			this.optNotCreateTraffic.Location = new System.Drawing.Point(3, 4);
			this.optNotCreateTraffic.Name = "optNotCreateTraffic";
			this.optNotCreateTraffic.Size = new System.Drawing.Size(247, 18);
			this.optNotCreateTraffic.TabIndex = 0;
			this.optNotCreateTraffic.TabStop = true;
			this.optNotCreateTraffic.Text = "оставить контейнер в текущей ячейке";
			this.optNotCreateTraffic.UseVisualStyleBackColor = true;
			this.optNotCreateTraffic.CheckedChanged += new System.EventHandler(this.optCreateTraffic_CheckedChanged);
			// 
			// optCreateTrafficCell
			// 
			this.optCreateTrafficCell.AutoSize = true;
			this.optCreateTrafficCell.Location = new System.Drawing.Point(3, 43);
			this.optCreateTrafficCell.Name = "optCreateTrafficCell";
			this.optCreateTrafficCell.Size = new System.Drawing.Size(532, 18);
			this.optCreateTrafficCell.TabIndex = 2;
			this.optCreateTrafficCell.Text = "создать операцию транспортировки для размещения контейнера в конкретной ячейке:";
			this.optCreateTrafficCell.UseVisualStyleBackColor = true;
			this.optCreateTrafficCell.CheckedChanged += new System.EventHandler(this.optCreateTraffic_CheckedChanged);
			// 
			// frmCellsNewFrameCollect
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(692, 448);
			this.Controls.Add(this.pnlData);
			this.Controls.Add(this.btnHelp);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.hpHelp.SetHelpKeyword(this, "541");
			this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.IsModalMode = true;
			this.Name = "frmCellsNewFrameCollect";
			this.hpHelp.SetShowHelp(this, true);
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Сбор товаров в контейнер";
			this.Load += new System.EventHandler(this.frmCellsNewFrameCollect_Load);
			((System.ComponentModel.ISupportInitialize)(this.numRestQnt)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numBoxQnt)).EndInit();
			this.pnlData.ResumeLayout(false);
			this.pnlData.PerformLayout();
			this.pnlDataChange.ResumeLayout(false);
			this.pnlDataChange.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdCellsContents)).EndInit();
			this.pnlOptTraffic.ResumeLayout(false);
			this.pnlOptTraffic.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

        private RFMBaseClasses.RFMButton btnSave;
		private RFMBaseClasses.RFMButton btnCancel;
		private RFMBaseClasses.RFMButton btnHelp;
		private RFMBaseClasses.RFMLabel lblCell;
		private RFMBaseClasses.RFMPanel pnlData;
		private RFMBaseClasses.RFMLabel lblCellID;
		private RFMBaseClasses.RFMButton btnGridSave;
		private RFMBaseClasses.RFMButton btnGridUndo;
		private RFMBaseClasses.RFMPanel pnlDataChange;
		private RFMBaseClasses.RFMDateTimePicker dtpDateValid;
		private RFMBaseClasses.RFMLabel lblDateValid;
		private RFMBaseClasses.RFMLabel lblQntNew;
		private RFMBaseClasses.RFMLabel lblGood;
		private RFMBaseClasses.RFMButton btnEdit;
		private RFMBaseClasses.RFMDataGridView grdCellsContents;
		private RFMBaseClasses.RFMLabel lblQnt;
		private RFMBaseClasses.RFMNumericUpDown numRestQnt;
		private RFMBaseClasses.RFMLabel lblBoxQnt;
		private RFMBaseClasses.RFMNumericUpDown numBoxQnt;
		private RFMBaseClasses.RFMLabel lblPackingName;
		private RFMBaseClasses.RFMTextBoxBarCode txtFrameBarCode;
		private RFMBaseClasses.RFMTextBoxNumeric txtFrameID4;
		private RFMBaseClasses.RFMCheckBox chkStereo;
		private RFMBaseClasses.RFMLabel lblCollect;
		private RFMBaseClasses.RFMComboBox cboStoresZonesTarget;
		private RFMBaseClasses.RFMComboBox cboStoresZonesTypesTarget;
		private RFMBaseClasses.RFMComboBox cboCellTargetAddress;
		private RFMBaseClasses.RFMPanel pnlOptTraffic;
		private RFMBaseClasses.RFMRadioButton optNotCreateTraffic;
		private RFMBaseClasses.RFMRadioButton optCreateTrafficCell;
		private RFMBaseClasses.RFMButton btnFrameEdit;
		private RFMBaseClasses.RFMRadioButton optCreateTrafficAccommodation;
		private RFMBaseClasses.RFMLabel lblCellTarget;
		private RFMBaseClasses.RFMLabel lblStoreZoneTarget;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodAlias;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcInBox;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcQnt;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcBoxQnt;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcQntCollect;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcBoxCollect;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcDateValid;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcOwnerName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodStateName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcPalQnt;
		private RFMBaseClasses.RFMDataGridViewCheckBoxColumn grcWeighting;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcPackingID;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcCellsContentsID;
		private RFMBaseClasses.RFMRadioButton optDirectToCell;
	}
}