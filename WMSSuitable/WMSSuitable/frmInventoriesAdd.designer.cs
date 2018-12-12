namespace WMSSuitable
{
	partial class frmInventoriesAdd 
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
			this.txtCellsChoosen = new RFMBaseClasses.RFMTextBox();
			this.btnCellsClear = new RFMBaseClasses.RFMButton();
			this.btnCellsChoose = new RFMBaseClasses.RFMButton();
			this.txtPackingsChoosen = new RFMBaseClasses.RFMTextBox();
			this.btnPackingsClear = new RFMBaseClasses.RFMButton();
			this.btnPackingsChoose = new RFMBaseClasses.RFMButton();
			this.btnClear = new RFMBaseClasses.RFMButton();
			this.btnFilter = new RFMBaseClasses.RFMButton();
			this.chkShowContents = new RFMBaseClasses.RFMCheckBox();
			this.pnlData = new RFMBaseClasses.RFMPanel();
			this.chkForStorageOnly = new RFMBaseClasses.RFMCheckBox();
			this.lblRestBoxes = new RFMBaseClasses.RFMLabel();
			this.numRestBoxes = new RFMBaseClasses.RFMNumericUpDown();
			this.chkRestBoxes = new RFMBaseClasses.RFMCheckBox();
			this.lblDateValidPercent = new RFMBaseClasses.RFMLabel();
			this.numDateValidPercent = new RFMBaseClasses.RFMNumericUpDown();
			this.pnlPackings = new RFMBaseClasses.RFMPanel();
			this.lblPackings = new RFMBaseClasses.RFMLabel();
			this.pnlCells = new RFMBaseClasses.RFMPanel();
			this.lblCellsSelect = new RFMBaseClasses.RFMLabel();
			this.txtNote = new RFMBaseClasses.RFMTextBox();
			this.lblNote = new RFMBaseClasses.RFMLabel();
			this.lblDateInventory = new RFMBaseClasses.RFMLabel();
			this.dtpDateInventory = new RFMBaseClasses.RFMDateTimePicker();
			this.chkDateValidPercent = new RFMBaseClasses.RFMCheckBox();
			this.btnHelp = new RFMBaseClasses.RFMButton();
			this.btnSave = new RFMBaseClasses.RFMButton();
			this.btnCancel = new RFMBaseClasses.RFMButton();
			this.grdCells = new RFMBaseClasses.RFMDataGridView();
			this.grcCellAddress = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcStoreZoneName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcStoreZoneTypeName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcCellBarCode = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcGoodAlias = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcInBox = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcQnt = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcBoxes = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcWeight = new RFMBaseClasses.RFMDataGridViewCheckBoxColumn();
			this.grcDateValid = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcCellID = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.pnlData.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numRestBoxes)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numDateValidPercent)).BeginInit();
			this.pnlPackings.SuspendLayout();
			this.pnlCells.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdCells)).BeginInit();
			this.SuspendLayout();
			// 
			// txtCellsChoosen
			// 
			this.txtCellsChoosen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtCellsChoosen.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtCellsChoosen.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtCellsChoosen.Enabled = false;
			this.txtCellsChoosen.Location = new System.Drawing.Point(1, 3);
			this.txtCellsChoosen.Name = "txtCellsChoosen";
			this.txtCellsChoosen.OldValue = "";
			this.txtCellsChoosen.Size = new System.Drawing.Size(580, 22);
			this.txtCellsChoosen.TabIndex = 0;
			this.ttToolTip.SetToolTip(this.txtCellsChoosen, "Контекст названия поставщика");
			// 
			// btnCellsClear
			// 
			this.btnCellsClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCellsClear.Image = global::WMSSuitable.Properties.Resources.DeleteAll;
			this.btnCellsClear.Location = new System.Drawing.Point(612, 1);
			this.btnCellsClear.Name = "btnCellsClear";
			this.btnCellsClear.Size = new System.Drawing.Size(26, 24);
			this.btnCellsClear.TabIndex = 2;
			this.ttToolTip.SetToolTip(this.btnCellsClear, "Очистить выбор ячеек");
			this.btnCellsClear.UseVisualStyleBackColor = true;
			this.btnCellsClear.Click += new System.EventHandler(this.btnCellsClear_Click);
			// 
			// btnCellsChoose
			// 
			this.btnCellsChoose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCellsChoose.Image = global::WMSSuitable.Properties.Resources.Detail;
			this.btnCellsChoose.Location = new System.Drawing.Point(584, 1);
			this.btnCellsChoose.Name = "btnCellsChoose";
			this.btnCellsChoose.Size = new System.Drawing.Size(26, 24);
			this.btnCellsChoose.TabIndex = 1;
			this.ttToolTip.SetToolTip(this.btnCellsChoose, "Выбор ячеек");
			this.btnCellsChoose.UseVisualStyleBackColor = true;
			this.btnCellsChoose.Click += new System.EventHandler(this.btnCellsChoose_Click);
			// 
			// txtPackingsChoosen
			// 
			this.txtPackingsChoosen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtPackingsChoosen.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtPackingsChoosen.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtPackingsChoosen.Enabled = false;
			this.txtPackingsChoosen.Location = new System.Drawing.Point(1, 3);
			this.txtPackingsChoosen.Name = "txtPackingsChoosen";
			this.txtPackingsChoosen.OldValue = "";
			this.txtPackingsChoosen.Size = new System.Drawing.Size(580, 22);
			this.txtPackingsChoosen.TabIndex = 0;
			this.ttToolTip.SetToolTip(this.txtPackingsChoosen, "Контекст названия поставщика");
			// 
			// btnPackingsClear
			// 
			this.btnPackingsClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPackingsClear.Image = global::WMSSuitable.Properties.Resources.DeleteAll;
			this.btnPackingsClear.Location = new System.Drawing.Point(612, 2);
			this.btnPackingsClear.Name = "btnPackingsClear";
			this.btnPackingsClear.Size = new System.Drawing.Size(26, 24);
			this.btnPackingsClear.TabIndex = 2;
			this.ttToolTip.SetToolTip(this.btnPackingsClear, "Очистить выбор товаров");
			this.btnPackingsClear.UseVisualStyleBackColor = true;
			this.btnPackingsClear.Click += new System.EventHandler(this.btnPackingsClear_Click);
			// 
			// btnPackingsChoose
			// 
			this.btnPackingsChoose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPackingsChoose.Image = global::WMSSuitable.Properties.Resources.Detail;
			this.btnPackingsChoose.Location = new System.Drawing.Point(584, 2);
			this.btnPackingsChoose.Name = "btnPackingsChoose";
			this.btnPackingsChoose.Size = new System.Drawing.Size(26, 24);
			this.btnPackingsChoose.TabIndex = 1;
			this.ttToolTip.SetToolTip(this.btnPackingsChoose, "Выбор товаров");
			this.btnPackingsChoose.UseVisualStyleBackColor = true;
			this.btnPackingsChoose.Click += new System.EventHandler(this.btnPackingsChoose_Click);
			// 
			// btnClear
			// 
			this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClear.Image = global::WMSSuitable.Properties.Resources.DeleteAll;
			this.btnClear.Location = new System.Drawing.Point(699, 119);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(30, 30);
			this.btnClear.TabIndex = 87;
			this.ttToolTip.SetToolTip(this.btnClear, "Очистить условия");
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// btnFilter
			// 
			this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFilter.Image = global::WMSSuitable.Properties.Resources.Go_Blue;
			this.btnFilter.Location = new System.Drawing.Point(649, 119);
			this.btnFilter.Name = "btnFilter";
			this.btnFilter.Size = new System.Drawing.Size(30, 30);
			this.btnFilter.TabIndex = 86;
			this.ttToolTip.SetToolTip(this.btnFilter, "Добавить к списку ячейки, соответствующие условиям");
			this.btnFilter.UseVisualStyleBackColor = true;
			this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
			// 
			// chkShowContents
			// 
			this.chkShowContents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.chkShowContents.AutoSize = true;
			this.chkShowContents.Location = new System.Drawing.Point(471, 130);
			this.chkShowContents.Name = "chkShowContents";
			this.chkShowContents.Size = new System.Drawing.Size(99, 18);
			this.chkShowContents.TabIndex = 88;
			this.chkShowContents.Text = "содержимое";
			this.chkShowContents.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ttToolTip.SetToolTip(this.chkShowContents, "показать содержимое ячеек");
			this.chkShowContents.UseVisualStyleBackColor = true;
			this.chkShowContents.CheckedChanged += new System.EventHandler(this.chkShowContents_CheckedChanged);
			// 
			// pnlData
			// 
			this.pnlData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlData.Controls.Add(this.chkForStorageOnly);
			this.pnlData.Controls.Add(this.chkShowContents);
			this.pnlData.Controls.Add(this.btnClear);
			this.pnlData.Controls.Add(this.btnFilter);
			this.pnlData.Controls.Add(this.lblRestBoxes);
			this.pnlData.Controls.Add(this.numRestBoxes);
			this.pnlData.Controls.Add(this.chkRestBoxes);
			this.pnlData.Controls.Add(this.lblDateValidPercent);
			this.pnlData.Controls.Add(this.numDateValidPercent);
			this.pnlData.Controls.Add(this.pnlPackings);
			this.pnlData.Controls.Add(this.lblPackings);
			this.pnlData.Controls.Add(this.pnlCells);
			this.pnlData.Controls.Add(this.lblCellsSelect);
			this.pnlData.Controls.Add(this.txtNote);
			this.pnlData.Controls.Add(this.lblNote);
			this.pnlData.Controls.Add(this.lblDateInventory);
			this.pnlData.Controls.Add(this.dtpDateInventory);
			this.pnlData.Controls.Add(this.chkDateValidPercent);
			this.pnlData.Location = new System.Drawing.Point(3, 4);
			this.pnlData.Name = "pnlData";
			this.pnlData.Size = new System.Drawing.Size(736, 155);
			this.pnlData.TabIndex = 0;
			// 
			// chkForStorageOnly
			// 
			this.chkForStorageOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.chkForStorageOnly.AutoSize = true;
			this.chkForStorageOnly.Checked = true;
			this.chkForStorageOnly.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkForStorageOnly.Location = new System.Drawing.Point(471, 106);
			this.chkForStorageOnly.Name = "chkForStorageOnly";
			this.chkForStorageOnly.Size = new System.Drawing.Size(168, 18);
			this.chkForStorageOnly.TabIndex = 89;
			this.chkForStorageOnly.Text = "только ячейки хранения";
			this.chkForStorageOnly.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ttToolTip.SetToolTip(this.chkForStorageOnly, "разрешен выбор только ячеек хранения (высотная зона, ручей, пикинг)");
			this.chkForStorageOnly.UseVisualStyleBackColor = true;
			// 
			// lblRestBoxes
			// 
			this.lblRestBoxes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblRestBoxes.AutoSize = true;
			this.lblRestBoxes.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblRestBoxes.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblRestBoxes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblRestBoxes.Location = new System.Drawing.Point(394, 131);
			this.lblRestBoxes.Name = "lblRestBoxes";
			this.lblRestBoxes.Size = new System.Drawing.Size(31, 14);
			this.lblRestBoxes.TabIndex = 85;
			this.lblRestBoxes.Text = "кор.";
			// 
			// numRestBoxes
			// 
			this.numRestBoxes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.numRestBoxes.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.numRestBoxes.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.numRestBoxes.IsNull = false;
			this.numRestBoxes.Location = new System.Drawing.Point(335, 128);
			this.numRestBoxes.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
			this.numRestBoxes.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
			this.numRestBoxes.Name = "numRestBoxes";
			this.numRestBoxes.Size = new System.Drawing.Size(56, 22);
			this.numRestBoxes.TabIndex = 83;
			this.numRestBoxes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// chkRestBoxes
			// 
			this.chkRestBoxes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.chkRestBoxes.AutoSize = true;
			this.chkRestBoxes.Location = new System.Drawing.Point(92, 130);
			this.chkRestBoxes.Name = "chkRestBoxes";
			this.chkRestBoxes.Size = new System.Drawing.Size(179, 18);
			this.chkRestBoxes.TabIndex = 84;
			this.chkRestBoxes.Text = "с остатком коробок менее";
			this.chkRestBoxes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.chkRestBoxes.UseVisualStyleBackColor = true;
			this.chkRestBoxes.CheckedChanged += new System.EventHandler(this.chkRestBoxes_CheckedChanged);
			// 
			// lblDateValidPercent
			// 
			this.lblDateValidPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblDateValidPercent.AutoSize = true;
			this.lblDateValidPercent.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblDateValidPercent.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblDateValidPercent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblDateValidPercent.Location = new System.Drawing.Point(394, 108);
			this.lblDateValidPercent.Name = "lblDateValidPercent";
			this.lblDateValidPercent.Size = new System.Drawing.Size(19, 14);
			this.lblDateValidPercent.TabIndex = 80;
			this.lblDateValidPercent.Text = "%";
			// 
			// numDateValidPercent
			// 
			this.numDateValidPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.numDateValidPercent.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.numDateValidPercent.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.numDateValidPercent.IsNull = false;
			this.numDateValidPercent.Location = new System.Drawing.Point(335, 104);
			this.numDateValidPercent.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
			this.numDateValidPercent.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
			this.numDateValidPercent.Name = "numDateValidPercent";
			this.numDateValidPercent.Size = new System.Drawing.Size(56, 22);
			this.numDateValidPercent.TabIndex = 4;
			this.numDateValidPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// pnlPackings
			// 
			this.pnlPackings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlPackings.Controls.Add(this.txtPackingsChoosen);
			this.pnlPackings.Controls.Add(this.btnPackingsClear);
			this.pnlPackings.Controls.Add(this.btnPackingsChoose);
			this.pnlPackings.Location = new System.Drawing.Point(90, 75);
			this.pnlPackings.Name = "pnlPackings";
			this.pnlPackings.Size = new System.Drawing.Size(640, 27);
			this.pnlPackings.TabIndex = 41;
			// 
			// lblPackings
			// 
			this.lblPackings.AutoSize = true;
			this.lblPackings.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblPackings.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblPackings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblPackings.Location = new System.Drawing.Point(42, 82);
			this.lblPackings.Name = "lblPackings";
			this.lblPackings.Size = new System.Drawing.Size(47, 14);
			this.lblPackings.TabIndex = 40;
			this.lblPackings.Text = "товары";
			// 
			// pnlCells
			// 
			this.pnlCells.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlCells.Controls.Add(this.txtCellsChoosen);
			this.pnlCells.Controls.Add(this.btnCellsClear);
			this.pnlCells.Controls.Add(this.btnCellsChoose);
			this.pnlCells.Location = new System.Drawing.Point(90, 50);
			this.pnlCells.Name = "pnlCells";
			this.pnlCells.Size = new System.Drawing.Size(640, 27);
			this.pnlCells.TabIndex = 39;
			// 
			// lblCellsSelect
			// 
			this.lblCellsSelect.AutoSize = true;
			this.lblCellsSelect.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblCellsSelect.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblCellsSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCellsSelect.Location = new System.Drawing.Point(4, 57);
			this.lblCellsSelect.Name = "lblCellsSelect";
			this.lblCellsSelect.Size = new System.Drawing.Size(85, 14);
			this.lblCellsSelect.TabIndex = 7;
			this.lblCellsSelect.Text = "Выбор ячеек:";
			// 
			// txtNote
			// 
			this.txtNote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtNote.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtNote.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtNote.Location = new System.Drawing.Point(91, 28);
			this.txtNote.Name = "txtNote";
			this.txtNote.Size = new System.Drawing.Size(638, 22);
			this.txtNote.TabIndex = 6;
			// 
			// lblNote
			// 
			this.lblNote.AutoSize = true;
			this.lblNote.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblNote.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblNote.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblNote.Location = new System.Drawing.Point(4, 31);
			this.lblNote.Name = "lblNote";
			this.lblNote.Size = new System.Drawing.Size(78, 14);
			this.lblNote.TabIndex = 5;
			this.lblNote.Text = "Примечание";
			// 
			// lblDateInventory
			// 
			this.lblDateInventory.AutoSize = true;
			this.lblDateInventory.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblDateInventory.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblDateInventory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblDateInventory.Location = new System.Drawing.Point(4, 8);
			this.lblDateInventory.Name = "lblDateInventory";
			this.lblDateInventory.Size = new System.Drawing.Size(83, 14);
			this.lblDateInventory.TabIndex = 3;
			this.lblDateInventory.Text = "Дата ревизии";
			// 
			// dtpDateInventory
			// 
			this.dtpDateInventory.CustomFormat = "dd.MM.yyyy";
			this.dtpDateInventory.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.dtpDateInventory.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.dtpDateInventory.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpDateInventory.Location = new System.Drawing.Point(91, 4);
			this.dtpDateInventory.Name = "dtpDateInventory";
			this.dtpDateInventory.Size = new System.Drawing.Size(98, 22);
			this.dtpDateInventory.TabIndex = 4;
			// 
			// chkDateValidPercent
			// 
			this.chkDateValidPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.chkDateValidPercent.AutoSize = true;
			this.chkDateValidPercent.Location = new System.Drawing.Point(92, 106);
			this.chkDateValidPercent.Name = "chkDateValidPercent";
			this.chkDateValidPercent.Size = new System.Drawing.Size(244, 18);
			this.chkDateValidPercent.TabIndex = 82;
			this.chkDateValidPercent.Text = "с оставшимся сроком годности менее";
			this.chkDateValidPercent.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.chkDateValidPercent.UseVisualStyleBackColor = true;
			this.chkDateValidPercent.CheckedChanged += new System.EventHandler(this.chkDateValidPercent_CheckedChanged);
			// 
			// btnHelp
			// 
			this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnHelp.Image = global::WMSSuitable.Properties.Resources.Help;
			this.btnHelp.Location = new System.Drawing.Point(6, 387);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new System.Drawing.Size(30, 30);
			this.btnHelp.TabIndex = 3;
			this.btnHelp.UseVisualStyleBackColor = true;
			this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Image = global::WMSSuitable.Properties.Resources.Save;
			this.btnSave.Location = new System.Drawing.Point(655, 387);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(30, 30);
			this.btnSave.TabIndex = 1;
			this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Image = global::WMSSuitable.Properties.Resources.Exit;
			this.btnCancel.Location = new System.Drawing.Point(705, 387);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(30, 30);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// grdCells
			// 
			this.grdCells.AllowUserToAddRows = false;
			this.grdCells.AllowUserToDeleteRows = false;
			this.grdCells.AllowUserToOrderColumns = true;
			this.grdCells.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.grdCells.BackgroundColor = System.Drawing.SystemColors.Window;
			this.grdCells.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.grdCells.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.grdCells.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdCells.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grcCellAddress,
            this.grcStoreZoneName,
            this.grcStoreZoneTypeName,
            this.grcCellBarCode,
            this.grcGoodAlias,
            this.grcInBox,
            this.grcQnt,
            this.grcBoxes,
            this.grcWeight,
            this.grcDateValid,
            this.grcCellID});
			this.grdCells.IsCheckerInclude = true;
			this.grdCells.IsConfigInclude = true;
			this.grdCells.IsMarkedAll = false;
			this.grdCells.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.grdCells.Location = new System.Drawing.Point(3, 162);
			this.grdCells.MultiSelect = false;
			this.grdCells.Name = "grdCells";
			this.grdCells.RangedWay = ' ';
			this.grdCells.RowHeadersWidth = 24;
			this.grdCells.Size = new System.Drawing.Size(736, 220);
			this.grdCells.TabIndex = 4;
			this.grdCells.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdCells_CellFormatting);
			// 
			// grcCellAddress
			// 
			this.grcCellAddress.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcCellAddress.DataPropertyName = "Address";
			this.grcCellAddress.HeaderText = "Адрес";
			this.grcCellAddress.Name = "grcCellAddress";
			this.grcCellAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			// 
			// grcStoreZoneName
			// 
			this.grcStoreZoneName.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcStoreZoneName.DataPropertyName = "StoreZoneName";
			this.grcStoreZoneName.HeaderText = "Скл.зона";
			this.grcStoreZoneName.Name = "grcStoreZoneName";
			this.grcStoreZoneName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcStoreZoneName.Width = 120;
			// 
			// grcStoreZoneTypeName
			// 
			this.grcStoreZoneTypeName.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcStoreZoneTypeName.DataPropertyName = "StoreZoneTypeName";
			this.grcStoreZoneTypeName.HeaderText = "Тип скл.зоны";
			this.grcStoreZoneTypeName.Name = "grcStoreZoneTypeName";
			this.grcStoreZoneTypeName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			// 
			// grcCellBarCode
			// 
			this.grcCellBarCode.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcCellBarCode.DataPropertyName = "BarCode";
			this.grcCellBarCode.HeaderText = "ШК ячейки";
			this.grcCellBarCode.Name = "grcCellBarCode";
			this.grcCellBarCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcCellBarCode.ToolTipText = "Штрих-код ячейки";
			this.grcCellBarCode.Width = 130;
			// 
			// grcGoodAlias
			// 
			this.grcGoodAlias.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcGoodAlias.DataPropertyName = "GoodAlias";
			this.grcGoodAlias.HeaderText = "Товар";
			this.grcGoodAlias.Name = "grcGoodAlias";
			this.grcGoodAlias.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcGoodAlias.Width = 200;
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
			this.grcInBox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcInBox.Width = 50;
			// 
			// grcQnt
			// 
			this.grcQnt.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcQnt.DataPropertyName = "Qnt";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle3.Format = "N0";
			this.grcQnt.DefaultCellStyle = dataGridViewCellStyle3;
			this.grcQnt.HeaderText = "Штук";
			this.grcQnt.Name = "grcQnt";
			this.grcQnt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcQnt.Width = 70;
			// 
			// grcBoxes
			// 
			this.grcBoxes.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcBoxes.DataPropertyName = "Boxes";
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle4.Format = "N1";
			this.grcBoxes.DefaultCellStyle = dataGridViewCellStyle4;
			this.grcBoxes.HeaderText = "Кор.";
			this.grcBoxes.Name = "grcBoxes";
			this.grcBoxes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcBoxes.ToolTipText = "Коробок";
			this.grcBoxes.Width = 60;
			// 
			// grcWeight
			// 
			this.grcWeight.DataPropertyName = "Weighting";
			this.grcWeight.HeaderText = "Вес?";
			this.grcWeight.Name = "grcWeight";
			this.grcWeight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcWeight.ToolTipText = "Весовой товар?";
			this.grcWeight.Width = 30;
			// 
			// grcDateValid
			// 
			this.grcDateValid.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcDateValid.DataPropertyName = "DateValid";
			this.grcDateValid.HeaderText = "Срок годн.";
			this.grcDateValid.Name = "grcDateValid";
			this.grcDateValid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcDateValid.Width = 80;
			// 
			// grcCellID
			// 
			this.grcCellID.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcCellID.DataPropertyName = "CellID";
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle5.Format = "N0";
			dataGridViewCellStyle5.NullValue = null;
			this.grcCellID.DefaultCellStyle = dataGridViewCellStyle5;
			this.grcCellID.HeaderText = "ID ячейки";
			this.grcCellID.Name = "grcCellID";
			this.grcCellID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcCellID.ToolTipText = "Код ячейки";
			this.grcCellID.Visible = false;
			this.grcCellID.Width = 80;
			// 
			// frmInventoriesAdd
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(742, 423);
			this.Controls.Add(this.grdCells);
			this.Controls.Add(this.pnlData);
			this.Controls.Add(this.btnHelp);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.hpHelp.SetHelpKeyword(this, "911");
			this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.hpHelp.SetHelpString(this, "");
			this.IsModalMode = true;
			this.Name = "frmInventoriesAdd";
			this.hpHelp.SetShowHelp(this, true);
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Ревизия";
			this.Load += new System.EventHandler(this.frmInventoriesAdd_Load);
			this.pnlData.ResumeLayout(false);
			this.pnlData.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numRestBoxes)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numDateValidPercent)).EndInit();
			this.pnlPackings.ResumeLayout(false);
			this.pnlPackings.PerformLayout();
			this.pnlCells.ResumeLayout(false);
			this.pnlCells.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdCells)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private RFMBaseClasses.RFMPanel pnlData;
		private RFMBaseClasses.RFMButton btnHelp;
		private RFMBaseClasses.RFMButton btnSave;
		private RFMBaseClasses.RFMButton btnCancel;
		private RFMBaseClasses.RFMLabel lblDateInventory;
		private RFMBaseClasses.RFMDateTimePicker dtpDateInventory;
		private RFMBaseClasses.RFMLabel lblCellsSelect;
		private RFMBaseClasses.RFMTextBox txtNote;
		private RFMBaseClasses.RFMLabel lblNote;
		private RFMBaseClasses.RFMPanel pnlCells;
		private RFMBaseClasses.RFMTextBox txtCellsChoosen;
		private RFMBaseClasses.RFMButton btnCellsClear;
		private RFMBaseClasses.RFMButton btnCellsChoose;
		private RFMBaseClasses.RFMPanel pnlPackings;
		private RFMBaseClasses.RFMTextBox txtPackingsChoosen;
		private RFMBaseClasses.RFMButton btnPackingsClear;
		private RFMBaseClasses.RFMButton btnPackingsChoose;
		private RFMBaseClasses.RFMLabel lblPackings;
		private RFMBaseClasses.RFMLabel lblDateValidPercent;
		private RFMBaseClasses.RFMNumericUpDown numDateValidPercent;
		private RFMBaseClasses.RFMLabel lblRestBoxes;
		private RFMBaseClasses.RFMNumericUpDown numRestBoxes;
		private RFMBaseClasses.RFMCheckBox chkRestBoxes;
		private RFMBaseClasses.RFMCheckBox chkDateValidPercent;
		private RFMBaseClasses.RFMButton btnClear;
		private RFMBaseClasses.RFMButton btnFilter;
		private RFMBaseClasses.RFMDataGridView grdCells;
		private RFMBaseClasses.RFMCheckBox chkShowContents;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcCellAddress;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcStoreZoneName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcStoreZoneTypeName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcCellBarCode;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodAlias;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcInBox;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcQnt;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcBoxes;
		private RFMBaseClasses.RFMDataGridViewCheckBoxColumn grcWeight;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcDateValid;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcCellID;
		private RFMBaseClasses.RFMCheckBox chkForStorageOnly;

	}
}