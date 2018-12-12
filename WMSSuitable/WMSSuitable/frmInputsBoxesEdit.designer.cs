namespace WMSSuitable
{
	partial class frmInputsBoxesEdit
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
			this.btnExit = new RFMBaseClasses.RFMButton();
			this.dgvInputGoods = new RFMBaseClasses.RFMDataGridView();
			this.dgvcImage = new RFMBaseClasses.RFMDataGridViewImageColumn();
			this.dgvcGoodAlias = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.dgvcInBox = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.dgvcGoodStateName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.dgvcBoxWished = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.dgvcBoxArranged = new RFMBaseClasses.RFMDataGridViewTextBoxNumericColumn();
			this.dgvcQntWished = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.dgvcQntArranged = new RFMBaseClasses.RFMDataGridViewTextBoxNumericColumn();
			this.dgvcWeighting = new RFMBaseClasses.RFMDataGridViewCheckBoxColumn();
			this.dgvcGoodBarCode = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.dgvcGoodGroupName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.dgvcGoodBrandName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.pnlAttribs = new RFMBaseClasses.RFMPanel();
			this.txtProducerName = new RFMBaseClasses.RFMTextBox();
			this.lblProducerName = new RFMBaseClasses.RFMLabel();
			this.txtInputTypeName = new RFMBaseClasses.RFMTextBox();
			this.txtGoodStateName = new RFMBaseClasses.RFMTextBox();
			this.txtOwnerName = new RFMBaseClasses.RFMTextBox();
			this.txtDateInput = new RFMBaseClasses.RFMTextBox();
			this.lblGoodStateName = new RFMBaseClasses.RFMLabel();
			this.lblOwnerName = new RFMBaseClasses.RFMLabel();
			this.lblInputTypeName = new RFMBaseClasses.RFMLabel();
			this.lblDateInput = new RFMBaseClasses.RFMLabel();
			this.lblUser = new RFMBaseClasses.RFMLabel();
			this.lblCell = new RFMBaseClasses.RFMLabel();
			this.cboHeavers = new RFMBaseClasses.RFMComboBox();
			this.cboCells = new RFMBaseClasses.RFMComboBox();
			this.btnSave = new RFMBaseClasses.RFMButton();
			this.pnlNewGood = new RFMBaseClasses.RFMPanel();
			this.lblNewGood = new RFMBaseClasses.RFMLabel();
			this.btnNewGood = new RFMBaseClasses.RFMButton();
			this.cboNewGoodState = new RFMBaseClasses.RFMComboBox();
			this.btnArrangeAll = new RFMBaseClasses.RFMButton();
			this.btnArrangeNull = new RFMBaseClasses.RFMButton();
			this.lblStrikeBoxesData = new RFMBaseClasses.RFMLabel();
			this.lblStrikePositionsData = new RFMBaseClasses.RFMLabel();
			this.lblStrikeBoxes = new RFMBaseClasses.RFMLabel();
			this.lblStrikePositions = new RFMBaseClasses.RFMLabel();
			this.lblStrikes = new RFMBaseClasses.RFMLabel();
			((System.ComponentModel.ISupportInitialize)(this.dgvInputGoods)).BeginInit();
			this.pnlAttribs.SuspendLayout();
			this.pnlNewGood.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnHelp
			// 
			this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnHelp.Image = global::WMSSuitable.Properties.Resources.Help;
			this.btnHelp.Location = new System.Drawing.Point(12, 434);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new System.Drawing.Size(32, 30);
			this.btnHelp.TabIndex = 15;
			this.ttToolTip.SetToolTip(this.btnHelp, "Помощь");
			this.btnHelp.UseVisualStyleBackColor = true;
			// 
			// btnExit
			// 
			this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExit.Image = global::WMSSuitable.Properties.Resources.Exit;
			this.btnExit.Location = new System.Drawing.Point(700, 434);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(32, 30);
			this.btnExit.TabIndex = 14;
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// dgvInputGoods
			// 
			this.dgvInputGoods.AllowUserToAddRows = false;
			this.dgvInputGoods.AllowUserToDeleteRows = false;
			this.dgvInputGoods.AllowUserToOrderColumns = true;
			this.dgvInputGoods.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvInputGoods.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dgvInputGoods.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvInputGoods.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvInputGoods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvInputGoods.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcImage,
            this.dgvcGoodAlias,
            this.dgvcInBox,
            this.dgvcGoodStateName,
            this.dgvcBoxWished,
            this.dgvcBoxArranged,
            this.dgvcQntWished,
            this.dgvcQntArranged,
            this.dgvcWeighting,
            this.dgvcGoodBarCode,
            this.dgvcGoodGroupName,
            this.dgvcGoodBrandName});
			this.dgvInputGoods.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.dgvInputGoods.IsConfigInclude = true;
			this.dgvInputGoods.IsMarkedAll = false;
			this.dgvInputGoods.IsStatusInclude = true;
			this.dgvInputGoods.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.dgvInputGoods.Location = new System.Drawing.Point(6, 91);
			this.dgvInputGoods.MultiSelect = false;
			this.dgvInputGoods.Name = "dgvInputGoods";
			this.dgvInputGoods.RangedWay = ' ';
			this.dgvInputGoods.RowHeadersWidth = 24;
			this.dgvInputGoods.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dgvInputGoods.Size = new System.Drawing.Size(732, 310);
			this.dgvInputGoods.TabIndex = 16;
			this.dgvInputGoods.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvInputGoods_CellBeginEdit);
			this.dgvInputGoods.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInputGoods_CellValidated);
			this.dgvInputGoods.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvInputGoods_CellFormatting);
			this.dgvInputGoods.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInputGoods_CellEndEdit);
			// 
			// dgvcImage
			// 
			this.dgvcImage.HeaderText = "";
			this.dgvcImage.Name = "dgvcImage";
			this.dgvcImage.ReadOnly = true;
			this.dgvcImage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvcImage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.dgvcImage.Width = 20;
			// 
			// dgvcGoodAlias
			// 
			this.dgvcGoodAlias.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.dgvcGoodAlias.DataPropertyName = "GoodAlias";
			this.dgvcGoodAlias.HeaderText = "Товар";
			this.dgvcGoodAlias.Name = "dgvcGoodAlias";
			this.dgvcGoodAlias.ReadOnly = true;
			this.dgvcGoodAlias.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.dgvcGoodAlias.Width = 225;
			// 
			// dgvcInBox
			// 
			this.dgvcInBox.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.dgvcInBox.DataPropertyName = "InBox";
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle2.Format = "N0";
			dataGridViewCellStyle2.NullValue = null;
			this.dgvcInBox.DefaultCellStyle = dataGridViewCellStyle2;
			this.dgvcInBox.HeaderText = "В кор.";
			this.dgvcInBox.Name = "dgvcInBox";
			this.dgvcInBox.ReadOnly = true;
			this.dgvcInBox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.dgvcInBox.ToolTipText = "Штук/кг в коробке";
			this.dgvcInBox.Width = 50;
			// 
			// dgvcGoodStateName
			// 
			this.dgvcGoodStateName.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.dgvcGoodStateName.DataPropertyName = "GoodStateName";
			this.dgvcGoodStateName.HeaderText = "Состояние";
			this.dgvcGoodStateName.Name = "dgvcGoodStateName";
			this.dgvcGoodStateName.ReadOnly = true;
			this.dgvcGoodStateName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvcGoodStateName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.dgvcGoodStateName.ToolTipText = "Состояние товара";
			this.dgvcGoodStateName.Width = 90;
			// 
			// dgvcBoxWished
			// 
			this.dgvcBoxWished.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.dgvcBoxWished.DataPropertyName = "BoxWished";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle3.Format = "N1";
			this.dgvcBoxWished.DefaultCellStyle = dataGridViewCellStyle3;
			this.dgvcBoxWished.HeaderText = "Заказ кор.";
			this.dgvcBoxWished.Name = "dgvcBoxWished";
			this.dgvcBoxWished.ReadOnly = true;
			this.dgvcBoxWished.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvcBoxWished.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.dgvcBoxWished.ToolTipText = "Заказано коробок";
			this.dgvcBoxWished.Width = 70;
			// 
			// dgvcBoxArranged
			// 
			this.dgvcBoxArranged.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.dgvcBoxArranged.DataPropertyName = "BoxArranged";
			this.dgvcBoxArranged.DecimalPlaces = 1;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle4.Format = "N1";
			this.dgvcBoxArranged.DefaultCellStyle = dataGridViewCellStyle4;
			this.dgvcBoxArranged.HeaderText = "Факт кор.";
			this.dgvcBoxArranged.Name = "dgvcBoxArranged";
			this.dgvcBoxArranged.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvcBoxArranged.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.dgvcBoxArranged.ToolTipText = "Фактически пришло коробок";
			this.dgvcBoxArranged.Width = 70;
			// 
			// dgvcQntWished
			// 
			this.dgvcQntWished.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.dgvcQntWished.DataPropertyName = "QntWished";
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle5.Format = "N0";
			this.dgvcQntWished.DefaultCellStyle = dataGridViewCellStyle5;
			this.dgvcQntWished.HeaderText = "Заказ шт.";
			this.dgvcQntWished.Name = "dgvcQntWished";
			this.dgvcQntWished.ReadOnly = true;
			this.dgvcQntWished.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvcQntWished.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.dgvcQntWished.ToolTipText = "Заказано штук";
			this.dgvcQntWished.Width = 80;
			// 
			// dgvcQntArranged
			// 
			this.dgvcQntArranged.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.dgvcQntArranged.DataPropertyName = "QntArranged";
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle6.Format = "N0";
			this.dgvcQntArranged.DefaultCellStyle = dataGridViewCellStyle6;
			this.dgvcQntArranged.HeaderText = "Факт шт.";
			this.dgvcQntArranged.Name = "dgvcQntArranged";
			this.dgvcQntArranged.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvcQntArranged.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.dgvcQntArranged.ToolTipText = "Фактически пришло штук";
			this.dgvcQntArranged.Width = 80;
			// 
			// dgvcWeighting
			// 
			this.dgvcWeighting.DataPropertyName = "Weighting";
			this.dgvcWeighting.HeaderText = "Вес?";
			this.dgvcWeighting.Name = "dgvcWeighting";
			this.dgvcWeighting.ReadOnly = true;
			this.dgvcWeighting.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.dgvcWeighting.ToolTipText = "Весовой товар?";
			this.dgvcWeighting.Width = 40;
			// 
			// dgvcGoodBarCode
			// 
			this.dgvcGoodBarCode.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.dgvcGoodBarCode.DataPropertyName = "GoodBarCode";
			this.dgvcGoodBarCode.HeaderText = "ШК товара";
			this.dgvcGoodBarCode.Name = "dgvcGoodBarCode";
			this.dgvcGoodBarCode.ReadOnly = true;
			this.dgvcGoodBarCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.dgvcGoodBarCode.ToolTipText = "Штрих-код товара";
			this.dgvcGoodBarCode.Width = 130;
			// 
			// dgvcGoodGroupName
			// 
			this.dgvcGoodGroupName.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.dgvcGoodGroupName.DataPropertyName = "GoodGroupName";
			this.dgvcGoodGroupName.HeaderText = "Товарная группа";
			this.dgvcGoodGroupName.Name = "dgvcGoodGroupName";
			this.dgvcGoodGroupName.ReadOnly = true;
			this.dgvcGoodGroupName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.dgvcGoodGroupName.Width = 150;
			// 
			// dgvcGoodBrandName
			// 
			this.dgvcGoodBrandName.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.dgvcGoodBrandName.DataPropertyName = "GoodBrandName";
			this.dgvcGoodBrandName.HeaderText = "Товарный бренд";
			this.dgvcGoodBrandName.Name = "dgvcGoodBrandName";
			this.dgvcGoodBrandName.ReadOnly = true;
			this.dgvcGoodBrandName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.dgvcGoodBrandName.Width = 150;
			// 
			// pnlAttribs
			// 
			this.pnlAttribs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlAttribs.Controls.Add(this.txtProducerName);
			this.pnlAttribs.Controls.Add(this.lblProducerName);
			this.pnlAttribs.Controls.Add(this.txtInputTypeName);
			this.pnlAttribs.Controls.Add(this.txtGoodStateName);
			this.pnlAttribs.Controls.Add(this.txtOwnerName);
			this.pnlAttribs.Controls.Add(this.txtDateInput);
			this.pnlAttribs.Controls.Add(this.lblGoodStateName);
			this.pnlAttribs.Controls.Add(this.lblOwnerName);
			this.pnlAttribs.Controls.Add(this.lblInputTypeName);
			this.pnlAttribs.Controls.Add(this.lblDateInput);
			this.pnlAttribs.Controls.Add(this.lblUser);
			this.pnlAttribs.Controls.Add(this.lblCell);
			this.pnlAttribs.Controls.Add(this.cboHeavers);
			this.pnlAttribs.Controls.Add(this.cboCells);
			this.pnlAttribs.Location = new System.Drawing.Point(6, 6);
			this.pnlAttribs.Name = "pnlAttribs";
			this.pnlAttribs.Size = new System.Drawing.Size(732, 79);
			this.pnlAttribs.TabIndex = 19;
			// 
			// txtProducerName
			// 
			this.txtProducerName.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtProducerName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtProducerName.Enabled = false;
			this.txtProducerName.IsUserDraw = true;
			this.txtProducerName.Location = new System.Drawing.Point(544, 27);
			this.txtProducerName.Name = "txtProducerName";
			this.txtProducerName.Size = new System.Drawing.Size(180, 22);
			this.txtProducerName.TabIndex = 50;
			// 
			// lblProducerName
			// 
			this.lblProducerName.AutoSize = true;
			this.lblProducerName.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblProducerName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblProducerName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblProducerName.Location = new System.Drawing.Point(456, 30);
			this.lblProducerName.Name = "lblProducerName";
			this.lblProducerName.Size = new System.Drawing.Size(68, 14);
			this.lblProducerName.TabIndex = 49;
			this.lblProducerName.Text = "Поставщик";
			// 
			// txtInputTypeName
			// 
			this.txtInputTypeName.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtInputTypeName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtInputTypeName.Enabled = false;
			this.txtInputTypeName.IsUserDraw = true;
			this.txtInputTypeName.Location = new System.Drawing.Point(243, 3);
			this.txtInputTypeName.Name = "txtInputTypeName";
			this.txtInputTypeName.Size = new System.Drawing.Size(180, 22);
			this.txtInputTypeName.TabIndex = 48;
			// 
			// txtGoodStateName
			// 
			this.txtGoodStateName.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtGoodStateName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtGoodStateName.Enabled = false;
			this.txtGoodStateName.IsUserDraw = true;
			this.txtGoodStateName.Location = new System.Drawing.Point(544, 3);
			this.txtGoodStateName.Name = "txtGoodStateName";
			this.txtGoodStateName.Size = new System.Drawing.Size(180, 22);
			this.txtGoodStateName.TabIndex = 47;
			// 
			// txtOwnerName
			// 
			this.txtOwnerName.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtOwnerName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtOwnerName.Enabled = false;
			this.txtOwnerName.IsUserDraw = true;
			this.txtOwnerName.Location = new System.Drawing.Point(243, 27);
			this.txtOwnerName.Name = "txtOwnerName";
			this.txtOwnerName.Size = new System.Drawing.Size(180, 22);
			this.txtOwnerName.TabIndex = 46;
			// 
			// txtDateInput
			// 
			this.txtDateInput.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtDateInput.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtDateInput.Enabled = false;
			this.txtDateInput.Location = new System.Drawing.Point(45, 3);
			this.txtDateInput.Name = "txtDateInput";
			this.txtDateInput.Size = new System.Drawing.Size(87, 22);
			this.txtDateInput.TabIndex = 45;
			// 
			// lblGoodStateName
			// 
			this.lblGoodStateName.AutoSize = true;
			this.lblGoodStateName.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblGoodStateName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblGoodStateName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblGoodStateName.Location = new System.Drawing.Point(456, 7);
			this.lblGoodStateName.Name = "lblGoodStateName";
			this.lblGoodStateName.Size = new System.Drawing.Size(68, 14);
			this.lblGoodStateName.TabIndex = 44;
			this.lblGoodStateName.Text = "Состояние";
			// 
			// lblOwnerName
			// 
			this.lblOwnerName.AutoSize = true;
			this.lblOwnerName.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblOwnerName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblOwnerName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblOwnerName.Location = new System.Drawing.Point(140, 30);
			this.lblOwnerName.Name = "lblOwnerName";
			this.lblOwnerName.Size = new System.Drawing.Size(62, 14);
			this.lblOwnerName.TabIndex = 43;
			this.lblOwnerName.Text = "Владелец";
			// 
			// lblInputTypeName
			// 
			this.lblInputTypeName.AutoSize = true;
			this.lblInputTypeName.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblInputTypeName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblInputTypeName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblInputTypeName.Location = new System.Drawing.Point(140, 7);
			this.lblInputTypeName.Name = "lblInputTypeName";
			this.lblInputTypeName.Size = new System.Drawing.Size(29, 14);
			this.lblInputTypeName.TabIndex = 42;
			this.lblInputTypeName.Text = "Тип";
			// 
			// lblDateInput
			// 
			this.lblDateInput.AutoSize = true;
			this.lblDateInput.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblDateInput.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblDateInput.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblDateInput.Location = new System.Drawing.Point(6, 7);
			this.lblDateInput.Name = "lblDateInput";
			this.lblDateInput.Size = new System.Drawing.Size(33, 14);
			this.lblDateInput.TabIndex = 41;
			this.lblDateInput.Text = "Дата";
			// 
			// lblUser
			// 
			this.lblUser.AutoSize = true;
			this.lblUser.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblUser.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblUser.Location = new System.Drawing.Point(456, 55);
			this.lblUser.Name = "lblUser";
			this.lblUser.Size = new System.Drawing.Size(85, 14);
			this.lblUser.TabIndex = 22;
			this.lblUser.Text = "Пользователь";
			// 
			// lblCell
			// 
			this.lblCell.AutoSize = true;
			this.lblCell.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblCell.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblCell.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCell.Location = new System.Drawing.Point(140, 55);
			this.lblCell.Name = "lblCell";
			this.lblCell.Size = new System.Drawing.Size(100, 14);
			this.lblCell.TabIndex = 21;
			this.lblCell.Text = "Ячейка приемки";
			// 
			// cboHeavers
			// 
			this.cboHeavers.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboHeavers.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboHeavers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboHeavers.FormattingEnabled = true;
			this.cboHeavers.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboHeavers.Location = new System.Drawing.Point(544, 51);
			this.cboHeavers.Name = "cboHeavers";
			this.cboHeavers.Size = new System.Drawing.Size(180, 22);
			this.cboHeavers.TabIndex = 20;
			// 
			// cboCells
			// 
			this.cboCells.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboCells.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboCells.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCells.FormattingEnabled = true;
			this.cboCells.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboCells.Location = new System.Drawing.Point(243, 51);
			this.cboCells.Name = "cboCells";
			this.cboCells.Size = new System.Drawing.Size(180, 22);
			this.cboCells.TabIndex = 19;
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Image = global::WMSSuitable.Properties.Resources.Save;
			this.btnSave.Location = new System.Drawing.Point(650, 434);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(32, 30);
			this.btnSave.TabIndex = 20;
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// pnlNewGood
			// 
			this.pnlNewGood.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.pnlNewGood.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlNewGood.Controls.Add(this.lblNewGood);
			this.pnlNewGood.Controls.Add(this.btnNewGood);
			this.pnlNewGood.Controls.Add(this.cboNewGoodState);
			this.pnlNewGood.Location = new System.Drawing.Point(178, 430);
			this.pnlNewGood.Name = "pnlNewGood";
			this.pnlNewGood.Size = new System.Drawing.Size(446, 39);
			this.pnlNewGood.TabIndex = 23;
			// 
			// lblNewGood
			// 
			this.lblNewGood.AutoSize = true;
			this.lblNewGood.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblNewGood.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblNewGood.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblNewGood.Location = new System.Drawing.Point(6, 11);
			this.lblNewGood.Name = "lblNewGood";
			this.lblNewGood.Size = new System.Drawing.Size(213, 14);
			this.lblNewGood.TabIndex = 25;
			this.lblNewGood.Text = "Добавить новый товар в состоянии:";
			// 
			// btnNewGood
			// 
			this.btnNewGood.Image = global::WMSSuitable.Properties.Resources.Detail;
			this.btnNewGood.Location = new System.Drawing.Point(407, 3);
			this.btnNewGood.Name = "btnNewGood";
			this.btnNewGood.Size = new System.Drawing.Size(32, 30);
			this.btnNewGood.TabIndex = 24;
			this.ttToolTip.SetToolTip(this.btnNewGood, "Добавить новый товар");
			this.btnNewGood.UseVisualStyleBackColor = true;
			this.btnNewGood.Click += new System.EventHandler(this.btnNewGood_Click);
			// 
			// cboNewGoodState
			// 
			this.cboNewGoodState.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboNewGoodState.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboNewGoodState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboNewGoodState.FormattingEnabled = true;
			this.cboNewGoodState.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboNewGoodState.Location = new System.Drawing.Point(220, 7);
			this.cboNewGoodState.Name = "cboNewGoodState";
			this.cboNewGoodState.Size = new System.Drawing.Size(180, 22);
			this.cboNewGoodState.TabIndex = 23;
			// 
			// btnArrangeAll
			// 
			this.btnArrangeAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnArrangeAll.Image = global::WMSSuitable.Properties.Resources.CheckBox_Green;
			this.btnArrangeAll.Location = new System.Drawing.Point(84, 434);
			this.btnArrangeAll.Name = "btnArrangeAll";
			this.btnArrangeAll.Size = new System.Drawing.Size(32, 30);
			this.btnArrangeAll.TabIndex = 24;
			this.ttToolTip.SetToolTip(this.btnArrangeAll, "Установить фактическое количество равным ожидаемому");
			this.btnArrangeAll.UseVisualStyleBackColor = true;
			this.btnArrangeAll.Click += new System.EventHandler(this.btnArrangeAll_Click);
			// 
			// btnArrangeNull
			// 
			this.btnArrangeNull.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnArrangeNull.Image = global::WMSSuitable.Properties.Resources.CheckBox_No;
			this.btnArrangeNull.Location = new System.Drawing.Point(119, 434);
			this.btnArrangeNull.Name = "btnArrangeNull";
			this.btnArrangeNull.Size = new System.Drawing.Size(32, 30);
			this.btnArrangeNull.TabIndex = 25;
			this.ttToolTip.SetToolTip(this.btnArrangeNull, "Очистить фактическое количество");
			this.btnArrangeNull.UseVisualStyleBackColor = true;
			this.btnArrangeNull.Click += new System.EventHandler(this.btnArrangeNull_Click);
			// 
			// lblStrikeBoxesData
			// 
			this.lblStrikeBoxesData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblStrikeBoxesData.AutoSize = true;
			this.lblStrikeBoxesData.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblStrikeBoxesData.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblStrikeBoxesData.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblStrikeBoxesData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblStrikeBoxesData.Location = new System.Drawing.Point(374, 409);
			this.lblStrikeBoxesData.Name = "lblStrikeBoxesData";
			this.lblStrikeBoxesData.Size = new System.Drawing.Size(16, 14);
			this.lblStrikeBoxesData.TabIndex = 52;
			this.lblStrikeBoxesData.Text = "#";
			// 
			// lblStrikePositionsData
			// 
			this.lblStrikePositionsData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblStrikePositionsData.AutoSize = true;
			this.lblStrikePositionsData.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblStrikePositionsData.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblStrikePositionsData.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblStrikePositionsData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblStrikePositionsData.Location = new System.Drawing.Point(304, 409);
			this.lblStrikePositionsData.Name = "lblStrikePositionsData";
			this.lblStrikePositionsData.Size = new System.Drawing.Size(16, 14);
			this.lblStrikePositionsData.TabIndex = 51;
			this.lblStrikePositionsData.Text = "#";
			// 
			// lblStrikeBoxes
			// 
			this.lblStrikeBoxes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblStrikeBoxes.AutoSize = true;
			this.lblStrikeBoxes.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblStrikeBoxes.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblStrikeBoxes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblStrikeBoxes.Location = new System.Drawing.Point(342, 409);
			this.lblStrikeBoxes.Name = "lblStrikeBoxes";
			this.lblStrikeBoxes.Size = new System.Drawing.Size(31, 14);
			this.lblStrikeBoxes.TabIndex = 50;
			this.lblStrikeBoxes.Text = "кор.";
			// 
			// lblStrikePositions
			// 
			this.lblStrikePositions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblStrikePositions.AutoSize = true;
			this.lblStrikePositions.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblStrikePositions.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblStrikePositions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblStrikePositions.Location = new System.Drawing.Point(263, 409);
			this.lblStrikePositions.Name = "lblStrikePositions";
			this.lblStrikePositions.Size = new System.Drawing.Size(39, 14);
			this.lblStrikePositions.TabIndex = 49;
			this.lblStrikePositions.Text = "строк";
			// 
			// lblStrikes
			// 
			this.lblStrikes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblStrikes.AutoSize = true;
			this.lblStrikes.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblStrikes.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblStrikes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblStrikes.Location = new System.Drawing.Point(179, 409);
			this.lblStrikes.Name = "lblStrikes";
			this.lblStrikes.Size = new System.Drawing.Size(79, 14);
			this.lblStrikes.TabIndex = 48;
			this.lblStrikes.Text = "Вычеркнуто:";
			// 
			// frmInputsBoxesEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(744, 475);
			this.Controls.Add(this.dgvInputGoods);
			this.Controls.Add(this.lblStrikeBoxesData);
			this.Controls.Add(this.lblStrikePositionsData);
			this.Controls.Add(this.lblStrikeBoxes);
			this.Controls.Add(this.lblStrikePositions);
			this.Controls.Add(this.lblStrikes);
			this.Controls.Add(this.btnArrangeNull);
			this.Controls.Add(this.btnArrangeAll);
			this.Controls.Add(this.pnlNewGood);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.pnlAttribs);
			this.Controls.Add(this.btnHelp);
			this.Controls.Add(this.btnExit);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.IsModalMode = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmInputsBoxesEdit";
			this.ShowIcon = false;
			this.Text = "Приход коробками";
			this.Load += new System.EventHandler(this.frmGoodsInputsEdit_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvInputGoods)).EndInit();
			this.pnlAttribs.ResumeLayout(false);
			this.pnlAttribs.PerformLayout();
			this.pnlNewGood.ResumeLayout(false);
			this.pnlNewGood.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion


		private RFMBaseClasses.RFMButton btnHelp;
		private RFMBaseClasses.RFMButton btnExit;
		private RFMBaseClasses.RFMDataGridView dgvInputGoods;
		private RFMBaseClasses.RFMPanel pnlAttribs;
		private RFMBaseClasses.RFMComboBox cboHeavers;
		private RFMBaseClasses.RFMComboBox cboCells;
		private RFMBaseClasses.RFMButton btnSave;
		private RFMBaseClasses.RFMLabel lblCell;
		private RFMBaseClasses.RFMLabel lblUser;
		private RFMBaseClasses.RFMPanel pnlNewGood;
		private RFMBaseClasses.RFMButton btnNewGood;
		private RFMBaseClasses.RFMComboBox cboNewGoodState;
		private RFMBaseClasses.RFMButton btnArrangeAll;
		private RFMBaseClasses.RFMButton btnArrangeNull;
		private RFMBaseClasses.RFMTextBox txtInputTypeName;
		private RFMBaseClasses.RFMTextBox txtGoodStateName;
		private RFMBaseClasses.RFMTextBox txtOwnerName;
		private RFMBaseClasses.RFMTextBox txtDateInput;
		private RFMBaseClasses.RFMLabel lblGoodStateName;
		private RFMBaseClasses.RFMLabel lblOwnerName;
		private RFMBaseClasses.RFMLabel lblInputTypeName;
		private RFMBaseClasses.RFMLabel lblDateInput;
		private RFMBaseClasses.RFMTextBox txtProducerName;
		private RFMBaseClasses.RFMLabel lblProducerName;
		private RFMBaseClasses.RFMLabel lblNewGood;
		private RFMBaseClasses.RFMLabel lblStrikeBoxesData;
		private RFMBaseClasses.RFMLabel lblStrikePositionsData;
		private RFMBaseClasses.RFMLabel lblStrikeBoxes;
		private RFMBaseClasses.RFMLabel lblStrikePositions;
		private RFMBaseClasses.RFMLabel lblStrikes;
		private RFMBaseClasses.RFMDataGridViewImageColumn dgvcImage;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgvcGoodAlias;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgvcInBox;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgvcGoodStateName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgvcBoxWished;
		private RFMBaseClasses.RFMDataGridViewTextBoxNumericColumn dgvcBoxArranged;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgvcQntWished;
		private RFMBaseClasses.RFMDataGridViewTextBoxNumericColumn dgvcQntArranged;
		private RFMBaseClasses.RFMDataGridViewCheckBoxColumn dgvcWeighting;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgvcGoodBarCode;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgvcGoodGroupName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgvcGoodBrandName;

	}
}