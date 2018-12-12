namespace WMSSuitable
{
	partial class frmCellsMassMedicationNotFrames
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
			this.btnHelp = new RFMBaseClasses.RFMButton();
			this.btnCancel = new RFMBaseClasses.RFMButton();
			this.btnSave = new RFMBaseClasses.RFMButton();
			this.btnEdit = new RFMBaseClasses.RFMButton();
			this.lblCell = new RFMBaseClasses.RFMLabel();
			this.pnlData = new RFMBaseClasses.RFMPanel();
			this.grdData = new RFMBaseClasses.RFMDataGridView();
			this.grcPackingAlias_After = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcInBox = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcGoodArticul = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcRestBox_After = new RFMBaseClasses.RFMDataGridViewTextBoxNumericColumn();
			this.grcRestQnt_After = new RFMBaseClasses.RFMDataGridViewTextBoxNumericColumn();
			this.grcGoodStateName_After = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcOwnerName_After = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcRestBox_Before = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcRestQnt_Before = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcGoodStateName_Before = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcOwnerName_Before = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcActual = new RFMBaseClasses.RFMDataGridViewCheckBoxColumn();
			this.grcWeighting = new RFMBaseClasses.RFMDataGridViewCheckBoxColumn();
			this.grcGoodGroupName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcGoodBrandName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcQnt_Before = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcQnt_After = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.lblNoteManual = new RFMBaseClasses.RFMLabel();
			this.txtNoteManual = new RFMBaseClasses.RFMTextBox();
			this.txtFixedPackingName = new RFMBaseClasses.RFMTextBox();
			this.txtFixedGoodStateName = new RFMBaseClasses.RFMTextBox();
			this.txtFixedOwnerName = new RFMBaseClasses.RFMTextBox();
			this.lblFixedPacking = new RFMBaseClasses.RFMLabel();
			this.lblCellID = new RFMBaseClasses.RFMLabel();
			this.lblFixedGoodState = new RFMBaseClasses.RFMLabel();
			this.lblFixedOwner = new RFMBaseClasses.RFMLabel();
			this.mnuEdit = new RFMBaseClasses.RFMContextMenuStrip();
			this.mniChooseGoodState = new RFMBaseClasses.RFMContextToolStripMenuItem();
			this.mniChooseOwner = new RFMBaseClasses.RFMContextToolStripMenuItem();
			this.mniClearOwner = new RFMBaseClasses.RFMContextToolStripMenuItem();
			this.pnlData.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
			this.mnuEdit.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnHelp
			// 
			this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnHelp.Image = global::WMSSuitable.Properties.Resources.Help;
			this.btnHelp.Location = new System.Drawing.Point(6, 338);
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
			this.btnCancel.Location = new System.Drawing.Point(656, 338);
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
			this.btnSave.Location = new System.Drawing.Point(606, 338);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(30, 30);
			this.btnSave.TabIndex = 1;
			this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnEdit.Image = global::WMSSuitable.Properties.Resources.Edit;
			this.btnEdit.Location = new System.Drawing.Point(106, 338);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(30, 30);
			this.btnEdit.TabIndex = 32;
			this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ttToolTip.SetToolTip(this.btnEdit, "Изменить");
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// lblCell
			// 
			this.lblCell.AutoSize = true;
			this.lblCell.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblCell.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblCell.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCell.Location = new System.Drawing.Point(2, 2);
			this.lblCell.Name = "lblCell";
			this.lblCell.Size = new System.Drawing.Size(126, 14);
			this.lblCell.TabIndex = 2;
			this.lblCell.Text = "Содержимое ячейки";
			// 
			// pnlData
			// 
			this.pnlData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlData.Controls.Add(this.grdData);
			this.pnlData.Controls.Add(this.lblNoteManual);
			this.pnlData.Controls.Add(this.txtNoteManual);
			this.pnlData.Controls.Add(this.txtFixedPackingName);
			this.pnlData.Controls.Add(this.txtFixedGoodStateName);
			this.pnlData.Controls.Add(this.txtFixedOwnerName);
			this.pnlData.Controls.Add(this.lblFixedPacking);
			this.pnlData.Controls.Add(this.lblCellID);
			this.pnlData.Controls.Add(this.lblFixedGoodState);
			this.pnlData.Controls.Add(this.lblFixedOwner);
			this.pnlData.Controls.Add(this.lblCell);
			this.pnlData.Location = new System.Drawing.Point(3, 4);
			this.pnlData.Name = "pnlData";
			this.pnlData.Size = new System.Drawing.Size(686, 328);
			this.pnlData.TabIndex = 4;
			// 
			// grdData
			// 
			this.grdData.AllowUserToAddRows = false;
			this.grdData.AllowUserToDeleteRows = false;
			this.grdData.AllowUserToOrderColumns = true;
			this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.grdData.BackgroundColor = System.Drawing.SystemColors.Window;
			this.grdData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.grdData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.grdData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.grdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grcPackingAlias_After,
            this.grcInBox,
            this.grcGoodArticul,
            this.grcRestBox_After,
            this.grcRestQnt_After,
            this.grcGoodStateName_After,
            this.grcOwnerName_After,
            this.grcRestBox_Before,
            this.grcRestQnt_Before,
            this.grcGoodStateName_Before,
            this.grcOwnerName_Before,
            this.grcActual,
            this.grcWeighting,
            this.grcGoodGroupName,
            this.grcGoodBrandName,
            this.grcQnt_Before,
            this.grcQnt_After});
			this.grdData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
			this.grdData.IsConfigInclude = true;
			this.grdData.IsMarkedAll = false;
			this.grdData.IsStatusInclude = true;
			this.grdData.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.grdData.Location = new System.Drawing.Point(3, 65);
			this.grdData.MultiSelect = false;
			this.grdData.Name = "grdData";
			this.grdData.RangedWay = ' ';
			this.grdData.RowHeadersWidth = 24;
			this.grdData.Size = new System.Drawing.Size(677, 233);
			this.grdData.TabIndex = 45;
			this.grdData.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.grdData_CellBeginEdit);
			this.grdData.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdData_CellValidated);
			this.grdData.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdData_CellFormatting);
			this.grdData.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdData_CellEndEdit);
			// 
			// grcPackingAlias_After
			// 
			this.grcPackingAlias_After.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcPackingAlias_After.DataPropertyName = "GoodAlias";
			this.grcPackingAlias_After.HeaderText = "Товар Факт";
			this.grcPackingAlias_After.Name = "grcPackingAlias_After";
			this.grcPackingAlias_After.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcPackingAlias_After.Width = 220;
			// 
			// grcInBox
			// 
			this.grcInBox.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcInBox.DataPropertyName = "InBox";
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle2.Format = "N0";
			dataGridViewCellStyle2.NullValue = null;
			this.grcInBox.DefaultCellStyle = dataGridViewCellStyle2;
			this.grcInBox.HeaderText = "В кор.";
			this.grcInBox.Name = "grcInBox";
			this.grcInBox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcInBox.Width = 50;
			// 
			// grcGoodArticul
			// 
			this.grcGoodArticul.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcGoodArticul.DataPropertyName = "GoodArticul";
			this.grcGoodArticul.HeaderText = "Артикул";
			this.grcGoodArticul.Name = "grcGoodArticul";
			this.grcGoodArticul.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcGoodArticul.Width = 80;
			// 
			// grcRestBox_After
			// 
			this.grcRestBox_After.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcRestBox_After.DataPropertyName = "RestBox_After";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle3.Format = "N0";
			this.grcRestBox_After.DefaultCellStyle = dataGridViewCellStyle3;
			this.grcRestBox_After.HeaderText = "Кор.Факт";
			this.grcRestBox_After.Name = "grcRestBox_After";
			this.grcRestBox_After.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.grcRestBox_After.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcRestBox_After.Width = 75;
			// 
			// grcRestQnt_After
			// 
			this.grcRestQnt_After.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcRestQnt_After.DataPropertyName = "RestQnt_After";
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle4.Format = "N0";
			this.grcRestQnt_After.DefaultCellStyle = dataGridViewCellStyle4;
			this.grcRestQnt_After.HeaderText = "+Штук Факт";
			this.grcRestQnt_After.Name = "grcRestQnt_After";
			this.grcRestQnt_After.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.grcRestQnt_After.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcRestQnt_After.Width = 95;
			// 
			// grcGoodStateName_After
			// 
			this.grcGoodStateName_After.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcGoodStateName_After.DataPropertyName = "GoodStateName_After";
			this.grcGoodStateName_After.HeaderText = "Состояние Факт";
			this.grcGoodStateName_After.Name = "grcGoodStateName_After";
			this.grcGoodStateName_After.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			// 
			// grcOwnerName_After
			// 
			this.grcOwnerName_After.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcOwnerName_After.DataPropertyName = "OwnerName_After";
			this.grcOwnerName_After.HeaderText = "Владелец Факт";
			this.grcOwnerName_After.Name = "grcOwnerName_After";
			this.grcOwnerName_After.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			// 
			// grcRestBox_Before
			// 
			this.grcRestBox_Before.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcRestBox_Before.DataPropertyName = "RestBox_Before";
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle5.Format = "N0";
			this.grcRestBox_Before.DefaultCellStyle = dataGridViewCellStyle5;
			this.grcRestBox_Before.HeaderText = "Кор.До";
			this.grcRestBox_Before.Name = "grcRestBox_Before";
			this.grcRestBox_Before.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcRestBox_Before.Width = 70;
			// 
			// grcRestQnt_Before
			// 
			this.grcRestQnt_Before.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcRestQnt_Before.DataPropertyName = "RestQnt_Before";
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle6.Format = "N0";
			this.grcRestQnt_Before.DefaultCellStyle = dataGridViewCellStyle6;
			this.grcRestQnt_Before.HeaderText = "+Штук До";
			this.grcRestQnt_Before.Name = "grcRestQnt_Before";
			this.grcRestQnt_Before.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcRestQnt_Before.Width = 90;
			// 
			// grcGoodStateName_Before
			// 
			this.grcGoodStateName_Before.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcGoodStateName_Before.DataPropertyName = "GoodStateName_Before";
			this.grcGoodStateName_Before.HeaderText = "Состояние До";
			this.grcGoodStateName_Before.Name = "grcGoodStateName_Before";
			this.grcGoodStateName_Before.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			// 
			// grcOwnerName_Before
			// 
			this.grcOwnerName_Before.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcOwnerName_Before.DataPropertyName = "OwnerName_Before";
			this.grcOwnerName_Before.HeaderText = "Владелец До";
			this.grcOwnerName_Before.Name = "grcOwnerName_Before";
			this.grcOwnerName_Before.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			// 
			// grcActual
			// 
			this.grcActual.DataPropertyName = "Actual";
			this.grcActual.HeaderText = "Actual";
			this.grcActual.Name = "grcActual";
			this.grcActual.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.grcActual.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcActual.Visible = false;
			// 
			// grcWeighting
			// 
			this.grcWeighting.DataPropertyName = "Weighting";
			this.grcWeighting.HeaderText = "Вес";
			this.grcWeighting.Name = "grcWeighting";
			this.grcWeighting.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcWeighting.Width = 30;
			// 
			// grcGoodGroupName
			// 
			this.grcGoodGroupName.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcGoodGroupName.DataPropertyName = "GoodGroupName";
			this.grcGoodGroupName.HeaderText = "Товарная группа";
			this.grcGoodGroupName.Name = "grcGoodGroupName";
			this.grcGoodGroupName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcGoodGroupName.Width = 200;
			// 
			// grcGoodBrandName
			// 
			this.grcGoodBrandName.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcGoodBrandName.DataPropertyName = "GoodBrandName";
			this.grcGoodBrandName.HeaderText = "Товарный бренд";
			this.grcGoodBrandName.Name = "grcGoodBrandName";
			this.grcGoodBrandName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcGoodBrandName.Width = 200;
			// 
			// grcQnt_Before
			// 
			this.grcQnt_Before.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcQnt_Before.DataPropertyName = "Qnt_Before";
			this.grcQnt_Before.HeaderText = "Qnt_Before";
			this.grcQnt_Before.Name = "grcQnt_Before";
			this.grcQnt_Before.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcQnt_Before.Visible = false;
			// 
			// grcQnt_After
			// 
			this.grcQnt_After.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcQnt_After.DataPropertyName = "Qnt_After";
			this.grcQnt_After.HeaderText = "Qnt_After";
			this.grcQnt_After.Name = "grcQnt_After";
			this.grcQnt_After.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcQnt_After.Visible = false;
			// 
			// lblNoteManual
			// 
			this.lblNoteManual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblNoteManual.AutoSize = true;
			this.lblNoteManual.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblNoteManual.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblNoteManual.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblNoteManual.Location = new System.Drawing.Point(3, 303);
			this.lblNoteManual.Name = "lblNoteManual";
			this.lblNoteManual.Size = new System.Drawing.Size(78, 14);
			this.lblNoteManual.TabIndex = 44;
			this.lblNoteManual.Text = "Примечание";
			// 
			// txtNoteManual
			// 
			this.txtNoteManual.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtNoteManual.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtNoteManual.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtNoteManual.Location = new System.Drawing.Point(85, 300);
			this.txtNoteManual.Name = "txtNoteManual";
			this.txtNoteManual.Size = new System.Drawing.Size(595, 22);
			this.txtNoteManual.TabIndex = 43;
			// 
			// txtFixedPackingName
			// 
			this.txtFixedPackingName.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtFixedPackingName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtFixedPackingName.Enabled = false;
			this.txtFixedPackingName.Location = new System.Drawing.Point(75, 42);
			this.txtFixedPackingName.Name = "txtFixedPackingName";
			this.txtFixedPackingName.Size = new System.Drawing.Size(605, 22);
			this.txtFixedPackingName.TabIndex = 41;
			// 
			// txtFixedGoodStateName
			// 
			this.txtFixedGoodStateName.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtFixedGoodStateName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtFixedGoodStateName.Enabled = false;
			this.txtFixedGoodStateName.Location = new System.Drawing.Point(456, 19);
			this.txtFixedGoodStateName.Name = "txtFixedGoodStateName";
			this.txtFixedGoodStateName.Size = new System.Drawing.Size(224, 22);
			this.txtFixedGoodStateName.TabIndex = 40;
			this.ttToolTip.SetToolTip(this.txtFixedGoodStateName, "Состояние товара, закрепленное за ячейкой");
			// 
			// txtFixedOwnerName
			// 
			this.txtFixedOwnerName.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtFixedOwnerName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtFixedOwnerName.Enabled = false;
			this.txtFixedOwnerName.Location = new System.Drawing.Point(75, 19);
			this.txtFixedOwnerName.Name = "txtFixedOwnerName";
			this.txtFixedOwnerName.Size = new System.Drawing.Size(224, 22);
			this.txtFixedOwnerName.TabIndex = 39;
			this.ttToolTip.SetToolTip(this.txtFixedOwnerName, "Хранитель, закрепленный за ячейкой");
			// 
			// lblFixedPacking
			// 
			this.lblFixedPacking.AutoSize = true;
			this.lblFixedPacking.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblFixedPacking.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblFixedPacking.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblFixedPacking.Location = new System.Drawing.Point(2, 45);
			this.lblFixedPacking.Name = "lblFixedPacking";
			this.lblFixedPacking.Size = new System.Drawing.Size(41, 14);
			this.lblFixedPacking.TabIndex = 37;
			this.lblFixedPacking.Text = "Товар";
			// 
			// lblCellID
			// 
			this.lblCellID.AutoSize = true;
			this.lblCellID.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblCellID.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblCellID.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblCellID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCellID.Location = new System.Drawing.Point(134, 2);
			this.lblCellID.Name = "lblCellID";
			this.lblCellID.Size = new System.Drawing.Size(42, 14);
			this.lblCellID.TabIndex = 29;
			this.lblCellID.Text = "CellID";
			// 
			// lblFixedGoodState
			// 
			this.lblFixedGoodState.AutoSize = true;
			this.lblFixedGoodState.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblFixedGoodState.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblFixedGoodState.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblFixedGoodState.Location = new System.Drawing.Point(381, 22);
			this.lblFixedGoodState.Name = "lblFixedGoodState";
			this.lblFixedGoodState.Size = new System.Drawing.Size(68, 14);
			this.lblFixedGoodState.TabIndex = 26;
			this.lblFixedGoodState.Text = "Состояние";
			// 
			// lblFixedOwner
			// 
			this.lblFixedOwner.AutoSize = true;
			this.lblFixedOwner.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblFixedOwner.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblFixedOwner.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblFixedOwner.Location = new System.Drawing.Point(2, 22);
			this.lblFixedOwner.Name = "lblFixedOwner";
			this.lblFixedOwner.Size = new System.Drawing.Size(67, 14);
			this.lblFixedOwner.TabIndex = 25;
			this.lblFixedOwner.Text = "Хранитель";
			// 
			// mnuEdit
			// 
			this.mnuEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniChooseGoodState,
            this.mniChooseOwner,
            this.mniClearOwner});
			this.mnuEdit.Name = "mnuPrint";
			this.mnuEdit.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.mnuEdit.ShowImageMargin = false;
			this.mnuEdit.Size = new System.Drawing.Size(167, 70);
			// 
			// mniChooseGoodState
			// 
			this.mniChooseGoodState.Name = "mniChooseGoodState";
			this.mniChooseGoodState.Size = new System.Drawing.Size(166, 22);
			this.mniChooseGoodState.Text = "Изменить состояние";
			this.mniChooseGoodState.Click += new System.EventHandler(this.mniChooseGoodState_Click);
			// 
			// mniChooseOwner
			// 
			this.mniChooseOwner.Name = "mniChooseOwner";
			this.mniChooseOwner.Size = new System.Drawing.Size(166, 22);
			this.mniChooseOwner.Text = "Изменить хранителя";
			this.mniChooseOwner.Click += new System.EventHandler(this.mniChooseOwner_Click);
			// 
			// mniClearOwner
			// 
			this.mniClearOwner.Name = "mniClearOwner";
			this.mniClearOwner.Size = new System.Drawing.Size(166, 22);
			this.mniClearOwner.Text = "Очистить хранителя";
			this.mniClearOwner.Click += new System.EventHandler(this.mniClearOwner_Click);
			// 
			// frmCellsMassMedicationNotFrames
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(692, 373);
			this.Controls.Add(this.pnlData);
			this.Controls.Add(this.btnHelp);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnEdit);
			this.hpHelp.SetHelpKeyword(this, "533");
			this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.IsModalMode = true;
			this.Name = "frmCellsMassMedicationNotFrames";
			this.hpHelp.SetShowHelp(this, true);
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Изменение содержимого ячейки";
			this.Load += new System.EventHandler(this.frmCellsMassMedicationNotFrames_Load);
			this.pnlData.ResumeLayout(false);
			this.pnlData.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
			this.mnuEdit.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

        private RFMBaseClasses.RFMButton btnSave;
		private RFMBaseClasses.RFMButton btnCancel;
		private RFMBaseClasses.RFMButton btnHelp;
		private RFMBaseClasses.RFMLabel lblCell;
		private RFMBaseClasses.RFMPanel pnlData;
		private RFMBaseClasses.RFMLabel lblFixedGoodState;
		private RFMBaseClasses.RFMLabel lblFixedOwner;
		private RFMBaseClasses.RFMLabel lblCellID;
		private RFMBaseClasses.RFMButton btnEdit;
		private RFMBaseClasses.RFMLabel lblFixedPacking;
		private RFMBaseClasses.RFMTextBox txtFixedPackingName;
		private RFMBaseClasses.RFMTextBox txtFixedGoodStateName;
		private RFMBaseClasses.RFMTextBox txtFixedOwnerName;
		private RFMBaseClasses.RFMLabel lblNoteManual;
		private RFMBaseClasses.RFMTextBox txtNoteManual;
		private RFMBaseClasses.RFMDataGridView grdData;
		private RFMBaseClasses.RFMContextMenuStrip mnuEdit;
		private RFMBaseClasses.RFMContextToolStripMenuItem mniChooseGoodState;
		private RFMBaseClasses.RFMContextToolStripMenuItem mniChooseOwner;
		private RFMBaseClasses.RFMContextToolStripMenuItem mniClearOwner;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcPackingAlias_After;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcInBox;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodArticul;
		private RFMBaseClasses.RFMDataGridViewTextBoxNumericColumn grcRestBox_After;
		private RFMBaseClasses.RFMDataGridViewTextBoxNumericColumn grcRestQnt_After;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodStateName_After;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcOwnerName_After;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcRestBox_Before;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcRestQnt_Before;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodStateName_Before;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcOwnerName_Before;
		private RFMBaseClasses.RFMDataGridViewCheckBoxColumn grcActual;
		private RFMBaseClasses.RFMDataGridViewCheckBoxColumn grcWeighting;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodGroupName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodBrandName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcQnt_Before;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcQnt_After;
	}
}