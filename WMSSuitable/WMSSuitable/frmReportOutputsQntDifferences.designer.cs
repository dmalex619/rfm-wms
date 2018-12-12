namespace WMSSuitable
{
	partial class frmReportOutputsQntDifferences 
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
            this.grdData = new RFMBaseClasses.RFMDataGridView();
            this.btnHelp = new RFMBaseClasses.RFMButton();
            this.btnExit = new RFMBaseClasses.RFMButton();
            this.pnlTerms = new RFMBaseClasses.RFMPanel();
            this.lblUnit = new RFMBaseClasses.RFMLabel();
            this.pnlUnit = new RFMBaseClasses.RFMPanel();
            this.optUnit3 = new RFMBaseClasses.RFMRadioButton();
            this.optUnit2 = new RFMBaseClasses.RFMRadioButton();
            this.optUnit1 = new RFMBaseClasses.RFMRadioButton();
            this.lblWeightDiffPrc = new RFMBaseClasses.RFMLabel();
            this.lblWeightDif = new RFMBaseClasses.RFMLabel();
            this.numWeightDiffPrc = new RFMBaseClasses.RFMNumericUpDown();
            this.pnlGroupBy = new RFMBaseClasses.RFMPanel();
            this.optByPackings = new RFMBaseClasses.RFMRadioButton();
            this.optByOutputs = new RFMBaseClasses.RFMRadioButton();
            this.lblNotEqual = new RFMBaseClasses.RFMLabel();
            this.lblInfo = new RFMBaseClasses.RFMLabel();
            this.pnlOpts2 = new RFMBaseClasses.RFMPanel();
            this.optConfirmed2 = new RFMBaseClasses.RFMRadioButton();
            this.optPicked2 = new RFMBaseClasses.RFMRadioButton();
            this.optSelected2 = new RFMBaseClasses.RFMRadioButton();
            this.optWished2 = new RFMBaseClasses.RFMRadioButton();
            this.pnlOpts1 = new RFMBaseClasses.RFMPanel();
            this.optConfirmed1 = new RFMBaseClasses.RFMRadioButton();
            this.optPicked1 = new RFMBaseClasses.RFMRadioButton();
            this.optSelected1 = new RFMBaseClasses.RFMRadioButton();
            this.optWished1 = new RFMBaseClasses.RFMRadioButton();
            this.chkIncludeWeighting = new RFMBaseClasses.RFMCheckBox();
            this.btnFilter = new RFMBaseClasses.RFMButton();
            this.btnExcel = new RFMBaseClasses.RFMButton();
            this.grcDateOutput = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcOwnerName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcPartnerName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcERPCode = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcGoodStateName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcGoodName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcInBox = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcQntWished = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcQntSelected = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcQntPicked = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcQntConfirmed = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcGoodGroupName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcGoodBrandName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcArticul = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcGoodBarCode = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcWeighting = new RFMBaseClasses.RFMDataGridViewCheckBoxColumn();
            this.grcPickingCellAddress = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.pnlTerms.SuspendLayout();
            this.pnlUnit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWeightDiffPrc)).BeginInit();
            this.pnlGroupBy.SuspendLayout();
            this.pnlOpts2.SuspendLayout();
            this.pnlOpts1.SuspendLayout();
            this.SuspendLayout();
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
            this.grcDateOutput,
            this.grcOwnerName,
            this.grcPartnerName,
            this.grcERPCode,
            this.grcGoodStateName,
            this.grcGoodName,
            this.grcInBox,
            this.grcQntWished,
            this.grcQntSelected,
            this.grcQntPicked,
            this.grcQntConfirmed,
            this.grcGoodGroupName,
            this.grcGoodBrandName,
            this.grcArticul,
            this.grcGoodBarCode,
            this.grcWeighting,
            this.grcPickingCellAddress});
            this.grdData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdData.IsConfigInclude = true;
            this.grdData.IsMarkedAll = false;
            this.grdData.IsStatusInclude = true;
            this.grdData.IsStatusShow = true;
            this.grdData.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
            this.grdData.Location = new System.Drawing.Point(4, 120);
            this.grdData.MultiSelect = false;
            this.grdData.Name = "grdData";
            this.grdData.RangedWay = ' ';
            this.grdData.ReadOnly = true;
            this.grdData.RowHeadersWidth = 24;
            this.grdData.SelectedRowBorderColor = System.Drawing.SystemColors.Control;
            this.grdData.SelectedRowForeColor = System.Drawing.Color.Black;
            this.grdData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdData.Size = new System.Drawing.Size(733, 353);
            this.grdData.StatusRowState = ((byte)(2));
            this.grdData.TabIndex = 1;
            this.grdData.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdData_CellFormatting);
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHelp.Image = global::WMSSuitable.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(7, 480);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(32, 30);
            this.btnHelp.TabIndex = 4;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Image = global::WMSSuitable.Properties.Resources.Exit;
            this.btnExit.Location = new System.Drawing.Point(703, 480);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(32, 30);
            this.btnExit.TabIndex = 3;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pnlTerms
            // 
            this.pnlTerms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTerms.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlTerms.Controls.Add(this.lblUnit);
            this.pnlTerms.Controls.Add(this.pnlUnit);
            this.pnlTerms.Controls.Add(this.lblWeightDiffPrc);
            this.pnlTerms.Controls.Add(this.lblWeightDif);
            this.pnlTerms.Controls.Add(this.numWeightDiffPrc);
            this.pnlTerms.Controls.Add(this.pnlGroupBy);
            this.pnlTerms.Controls.Add(this.lblNotEqual);
            this.pnlTerms.Controls.Add(this.lblInfo);
            this.pnlTerms.Controls.Add(this.pnlOpts2);
            this.pnlTerms.Controls.Add(this.pnlOpts1);
            this.pnlTerms.Controls.Add(this.chkIncludeWeighting);
            this.pnlTerms.Controls.Add(this.btnFilter);
            this.pnlTerms.Location = new System.Drawing.Point(4, 5);
            this.pnlTerms.Name = "pnlTerms";
            this.pnlTerms.Size = new System.Drawing.Size(733, 112);
            this.pnlTerms.TabIndex = 0;
            // 
            // lblUnit
            // 
            this.lblUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUnit.AutoSize = true;
            this.lblUnit.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblUnit.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblUnit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUnit.Location = new System.Drawing.Point(370, 3);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(60, 14);
            this.lblUnit.TabIndex = 52;
            this.lblUnit.Text = "Расчет в:";
            // 
            // pnlUnit
            // 
            this.pnlUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlUnit.Controls.Add(this.optUnit3);
            this.pnlUnit.Controls.Add(this.optUnit2);
            this.pnlUnit.Controls.Add(this.optUnit1);
            this.pnlUnit.Location = new System.Drawing.Point(368, 20);
            this.pnlUnit.Name = "pnlUnit";
            this.pnlUnit.Size = new System.Drawing.Size(110, 70);
            this.pnlUnit.TabIndex = 51;
            // 
            // optUnit3
            // 
            this.optUnit3.AutoSize = true;
            this.optUnit3.Location = new System.Drawing.Point(5, 45);
            this.optUnit3.Name = "optUnit3";
            this.optUnit3.Size = new System.Drawing.Size(77, 18);
            this.optUnit3.TabIndex = 2;
            this.optUnit3.Text = "паллетах";
            this.optUnit3.UseVisualStyleBackColor = true;
            // 
            // optUnit2
            // 
            this.optUnit2.AutoSize = true;
            this.optUnit2.IsChanged = true;
            this.optUnit2.Location = new System.Drawing.Point(5, 25);
            this.optUnit2.Name = "optUnit2";
            this.optUnit2.Size = new System.Drawing.Size(77, 18);
            this.optUnit2.TabIndex = 1;
            this.optUnit2.Text = "коробках";
            this.optUnit2.UseVisualStyleBackColor = true;
            // 
            // optUnit1
            // 
            this.optUnit1.AutoSize = true;
            this.optUnit1.Checked = true;
            this.optUnit1.IsChanged = true;
            this.optUnit1.Location = new System.Drawing.Point(5, 5);
            this.optUnit1.Name = "optUnit1";
            this.optUnit1.Size = new System.Drawing.Size(87, 18);
            this.optUnit1.TabIndex = 0;
            this.optUnit1.TabStop = true;
            this.optUnit1.Text = "штуках / кг";
            this.optUnit1.UseVisualStyleBackColor = true;
            // 
            // lblWeightDiffPrc
            // 
            this.lblWeightDiffPrc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWeightDiffPrc.AutoSize = true;
            this.lblWeightDiffPrc.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblWeightDiffPrc.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblWeightDiffPrc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblWeightDiffPrc.Location = new System.Drawing.Point(578, 87);
            this.lblWeightDiffPrc.Name = "lblWeightDiffPrc";
            this.lblWeightDiffPrc.Size = new System.Drawing.Size(19, 14);
            this.lblWeightDiffPrc.TabIndex = 7;
            this.lblWeightDiffPrc.Text = "%";
            // 
            // lblWeightDif
            // 
            this.lblWeightDif.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWeightDif.AutoSize = true;
            this.lblWeightDif.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblWeightDif.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblWeightDif.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblWeightDif.Location = new System.Drawing.Point(503, 65);
            this.lblWeightDif.Name = "lblWeightDif";
            this.lblWeightDif.Size = new System.Drawing.Size(182, 14);
            this.lblWeightDif.TabIndex = 5;
            this.lblWeightDif.Text = "Расхождение для вес. товара:";
            // 
            // numWeightDiffPrc
            // 
            this.numWeightDiffPrc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numWeightDiffPrc.DecimalPlaces = 1;
            this.numWeightDiffPrc.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.numWeightDiffPrc.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.numWeightDiffPrc.IsNull = false;
            this.numWeightDiffPrc.Location = new System.Drawing.Point(503, 83);
            this.numWeightDiffPrc.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numWeightDiffPrc.Name = "numWeightDiffPrc";
            this.numWeightDiffPrc.Size = new System.Drawing.Size(73, 22);
            this.numWeightDiffPrc.TabIndex = 6;
            this.numWeightDiffPrc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numWeightDiffPrc.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // pnlGroupBy
            // 
            this.pnlGroupBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGroupBy.Controls.Add(this.optByPackings);
            this.pnlGroupBy.Controls.Add(this.optByOutputs);
            this.pnlGroupBy.Location = new System.Drawing.Point(503, 5);
            this.pnlGroupBy.Name = "pnlGroupBy";
            this.pnlGroupBy.Size = new System.Drawing.Size(206, 24);
            this.pnlGroupBy.TabIndex = 50;
            // 
            // optByPackings
            // 
            this.optByPackings.AutoSize = true;
            this.optByPackings.Location = new System.Drawing.Point(116, 4);
            this.optByPackings.Name = "optByPackings";
            this.optByPackings.Size = new System.Drawing.Size(89, 18);
            this.optByPackings.TabIndex = 1;
            this.optByPackings.Text = "по товарам";
            this.optByPackings.UseVisualStyleBackColor = true;
            // 
            // optByOutputs
            // 
            this.optByOutputs.AutoSize = true;
            this.optByOutputs.Checked = true;
            this.optByOutputs.IsChanged = true;
            this.optByOutputs.Location = new System.Drawing.Point(4, 4);
            this.optByOutputs.Name = "optByOutputs";
            this.optByOutputs.Size = new System.Drawing.Size(96, 18);
            this.optByOutputs.TabIndex = 0;
            this.optByOutputs.TabStop = true;
            this.optByOutputs.Text = "по заданиям";
            this.optByOutputs.UseVisualStyleBackColor = true;
            // 
            // lblNotEqual
            // 
            this.lblNotEqual.AutoSize = true;
            this.lblNotEqual.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblNotEqual.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblNotEqual.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNotEqual.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNotEqual.Location = new System.Drawing.Point(136, 55);
            this.lblNotEqual.Name = "lblNotEqual";
            this.lblNotEqual.Size = new System.Drawing.Size(64, 14);
            this.lblNotEqual.TabIndex = 2;
            this.lblNotEqual.Text = "не равно";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblInfo.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblInfo.Location = new System.Drawing.Point(5, 5);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(317, 14);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Показать товары в текущем списке расходов (#), где:";
            // 
            // pnlOpts2
            // 
            this.pnlOpts2.Controls.Add(this.optConfirmed2);
            this.pnlOpts2.Controls.Add(this.optPicked2);
            this.pnlOpts2.Controls.Add(this.optSelected2);
            this.pnlOpts2.Controls.Add(this.optWished2);
            this.pnlOpts2.Location = new System.Drawing.Point(212, 20);
            this.pnlOpts2.Name = "pnlOpts2";
            this.pnlOpts2.Size = new System.Drawing.Size(120, 87);
            this.pnlOpts2.TabIndex = 3;
            // 
            // optConfirmed2
            // 
            this.optConfirmed2.AutoSize = true;
            this.optConfirmed2.Checked = true;
            this.optConfirmed2.IsChanged = true;
            this.optConfirmed2.Location = new System.Drawing.Point(4, 65);
            this.optConfirmed2.Name = "optConfirmed2";
            this.optConfirmed2.Size = new System.Drawing.Size(110, 18);
            this.optConfirmed2.TabIndex = 3;
            this.optConfirmed2.TabStop = true;
            this.optConfirmed2.Text = "подтверждено";
            this.optConfirmed2.UseVisualStyleBackColor = true;
            // 
            // optPicked2
            // 
            this.optPicked2.AutoSize = true;
            this.optPicked2.Location = new System.Drawing.Point(4, 45);
            this.optPicked2.Name = "optPicked2";
            this.optPicked2.Size = new System.Drawing.Size(72, 18);
            this.optPicked2.TabIndex = 2;
            this.optPicked2.Text = "собрано";
            this.optPicked2.UseVisualStyleBackColor = true;
            // 
            // optSelected2
            // 
            this.optSelected2.AutoSize = true;
            this.optSelected2.Location = new System.Drawing.Point(4, 25);
            this.optSelected2.Name = "optSelected2";
            this.optSelected2.Size = new System.Drawing.Size(87, 18);
            this.optSelected2.TabIndex = 1;
            this.optSelected2.Text = "подобрано";
            this.optSelected2.UseVisualStyleBackColor = true;
            // 
            // optWished2
            // 
            this.optWished2.AutoSize = true;
            this.optWished2.IsChanged = true;
            this.optWished2.Location = new System.Drawing.Point(4, 5);
            this.optWished2.Name = "optWished2";
            this.optWished2.Size = new System.Drawing.Size(73, 18);
            this.optWished2.TabIndex = 0;
            this.optWished2.Text = "заказано";
            this.optWished2.UseVisualStyleBackColor = true;
            // 
            // pnlOpts1
            // 
            this.pnlOpts1.Controls.Add(this.optConfirmed1);
            this.pnlOpts1.Controls.Add(this.optPicked1);
            this.pnlOpts1.Controls.Add(this.optSelected1);
            this.pnlOpts1.Controls.Add(this.optWished1);
            this.pnlOpts1.Location = new System.Drawing.Point(5, 20);
            this.pnlOpts1.Name = "pnlOpts1";
            this.pnlOpts1.Size = new System.Drawing.Size(120, 87);
            this.pnlOpts1.TabIndex = 1;
            // 
            // optConfirmed1
            // 
            this.optConfirmed1.AutoSize = true;
            this.optConfirmed1.Location = new System.Drawing.Point(4, 65);
            this.optConfirmed1.Name = "optConfirmed1";
            this.optConfirmed1.Size = new System.Drawing.Size(110, 18);
            this.optConfirmed1.TabIndex = 3;
            this.optConfirmed1.Text = "подтверждено";
            this.optConfirmed1.UseVisualStyleBackColor = true;
            this.optConfirmed1.CheckedChanged += new System.EventHandler(this.opt1_CheckedChanged);
            // 
            // optPicked1
            // 
            this.optPicked1.AutoSize = true;
            this.optPicked1.Location = new System.Drawing.Point(4, 45);
            this.optPicked1.Name = "optPicked1";
            this.optPicked1.Size = new System.Drawing.Size(72, 18);
            this.optPicked1.TabIndex = 2;
            this.optPicked1.Text = "собрано";
            this.optPicked1.UseVisualStyleBackColor = true;
            this.optPicked1.CheckedChanged += new System.EventHandler(this.opt1_CheckedChanged);
            // 
            // optSelected1
            // 
            this.optSelected1.AutoSize = true;
            this.optSelected1.Location = new System.Drawing.Point(4, 25);
            this.optSelected1.Name = "optSelected1";
            this.optSelected1.Size = new System.Drawing.Size(87, 18);
            this.optSelected1.TabIndex = 1;
            this.optSelected1.Text = "подобрано";
            this.optSelected1.UseVisualStyleBackColor = true;
            this.optSelected1.CheckedChanged += new System.EventHandler(this.opt1_CheckedChanged);
            // 
            // optWished1
            // 
            this.optWished1.AutoSize = true;
            this.optWished1.Checked = true;
            this.optWished1.IsChanged = true;
            this.optWished1.Location = new System.Drawing.Point(4, 5);
            this.optWished1.Name = "optWished1";
            this.optWished1.Size = new System.Drawing.Size(73, 18);
            this.optWished1.TabIndex = 0;
            this.optWished1.TabStop = true;
            this.optWished1.Text = "заказано";
            this.optWished1.UseVisualStyleBackColor = true;
            this.optWished1.CheckedChanged += new System.EventHandler(this.opt1_CheckedChanged);
            // 
            // chkIncludeWeighting
            // 
            this.chkIncludeWeighting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkIncludeWeighting.AutoSize = true;
            this.chkIncludeWeighting.Location = new System.Drawing.Point(503, 40);
            this.chkIncludeWeighting.Name = "chkIncludeWeighting";
            this.chkIncludeWeighting.Size = new System.Drawing.Size(173, 18);
            this.chkIncludeWeighting.TabIndex = 4;
            this.chkIncludeWeighting.Text = "исключить весовой товар";
            this.chkIncludeWeighting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkIncludeWeighting.UseVisualStyleBackColor = true;
            this.chkIncludeWeighting.CheckedChanged += new System.EventHandler(this.chkIncludeWeighting_CheckedChanged);
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.Image = global::WMSSuitable.Properties.Resources.Go_Blue;
            this.btnFilter.Location = new System.Drawing.Point(694, 76);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(30, 30);
            this.btnFilter.TabIndex = 8;
            this.ttToolTip.SetToolTip(this.btnFilter, "Получить список товаров");
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.Image = global::WMSSuitable.Properties.Resources.Excel;
            this.btnExcel.Location = new System.Drawing.Point(653, 480);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(32, 30);
            this.btnExcel.TabIndex = 2;
            this.ttToolTip.SetToolTip(this.btnExcel, "Вывести в Excel");
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // grcDateOutput
            // 
            this.grcDateOutput.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcDateOutput.DataPropertyName = "DateOutput";
            dataGridViewCellStyle2.Format = "dd.MM.yyyy";
            dataGridViewCellStyle2.NullValue = null;
            this.grcDateOutput.DefaultCellStyle = dataGridViewCellStyle2;
            this.grcDateOutput.HeaderText = "Дата";
            this.grcDateOutput.Name = "grcDateOutput";
            this.grcDateOutput.ReadOnly = true;
            this.grcDateOutput.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcDateOutput.Width = 80;
            // 
            // grcOwnerName
            // 
            this.grcOwnerName.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcOwnerName.DataPropertyName = "OwnerName";
            this.grcOwnerName.HeaderText = "Владелец";
            this.grcOwnerName.Name = "grcOwnerName";
            this.grcOwnerName.ReadOnly = true;
            this.grcOwnerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // grcPartnerName
            // 
            this.grcPartnerName.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcPartnerName.DataPropertyName = "PartnerName";
            this.grcPartnerName.HeaderText = "Контрагент";
            this.grcPartnerName.Name = "grcPartnerName";
            this.grcPartnerName.ReadOnly = true;
            this.grcPartnerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcPartnerName.Width = 150;
            // 
            // grcERPCode
            // 
            this.grcERPCode.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcERPCode.DataPropertyName = "ERPCode";
            this.grcERPCode.HeaderText = "EPRCode";
            this.grcERPCode.Name = "grcERPCode";
            this.grcERPCode.ReadOnly = true;
            this.grcERPCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcERPCode.ToolTipText = "Код расхода в учетной системе";
            this.grcERPCode.Width = 130;
            // 
            // grcGoodStateName
            // 
            this.grcGoodStateName.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcGoodStateName.DataPropertyName = "GoodStateName";
            this.grcGoodStateName.HeaderText = "Состояние";
            this.grcGoodStateName.Name = "grcGoodStateName";
            this.grcGoodStateName.ReadOnly = true;
            this.grcGoodStateName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // grcGoodName
            // 
            this.grcGoodName.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcGoodName.DataPropertyName = "GoodName";
            this.grcGoodName.HeaderText = "Товар";
            this.grcGoodName.Name = "grcGoodName";
            this.grcGoodName.ReadOnly = true;
            this.grcGoodName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcGoodName.Width = 250;
            // 
            // grcInBox
            // 
            this.grcInBox.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcInBox.DataPropertyName = "InBox";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            this.grcInBox.DefaultCellStyle = dataGridViewCellStyle3;
            this.grcInBox.HeaderText = "В кор.";
            this.grcInBox.Name = "grcInBox";
            this.grcInBox.ReadOnly = true;
            this.grcInBox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcInBox.ToolTipText = "Штук/кг в коробке";
            this.grcInBox.Width = 60;
            // 
            // grcQntWished
            // 
            this.grcQntWished.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcQntWished.DataPropertyName = "QntWished";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            this.grcQntWished.DefaultCellStyle = dataGridViewCellStyle4;
            this.grcQntWished.HeaderText = "Заказано";
            this.grcQntWished.Name = "grcQntWished";
            this.grcQntWished.ReadOnly = true;
            this.grcQntWished.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcQntWished.ToolTipText = "Количество заказанного товара, штук/кг";
            this.grcQntWished.Width = 80;
            // 
            // grcQntSelected
            // 
            this.grcQntSelected.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcQntSelected.DataPropertyName = "QntSelected";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.grcQntSelected.DefaultCellStyle = dataGridViewCellStyle5;
            this.grcQntSelected.HeaderText = "Подобрано";
            this.grcQntSelected.Name = "grcQntSelected";
            this.grcQntSelected.ReadOnly = true;
            this.grcQntSelected.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcQntSelected.ToolTipText = "Количество подобранного товара, штук";
            this.grcQntSelected.Width = 80;
            // 
            // grcQntPicked
            // 
            this.grcQntPicked.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcQntPicked.DataPropertyName = "QntPicked";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            this.grcQntPicked.DefaultCellStyle = dataGridViewCellStyle6;
            this.grcQntPicked.HeaderText = "Собрано";
            this.grcQntPicked.Name = "grcQntPicked";
            this.grcQntPicked.ReadOnly = true;
            this.grcQntPicked.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcQntPicked.ToolTipText = "Количество товара, штук/кг, собранного в ячейке отгрузки";
            this.grcQntPicked.Width = 80;
            // 
            // grcQntConfirmed
            // 
            this.grcQntConfirmed.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcQntConfirmed.DataPropertyName = "QntConfirmed";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            this.grcQntConfirmed.DefaultCellStyle = dataGridViewCellStyle7;
            this.grcQntConfirmed.HeaderText = "Подтверждено";
            this.grcQntConfirmed.Name = "grcQntConfirmed";
            this.grcQntConfirmed.ReadOnly = true;
            this.grcQntConfirmed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcQntConfirmed.ToolTipText = "Количество выданного (отгруженного) товара, штук/кг";
            this.grcQntConfirmed.Width = 80;
            // 
            // grcGoodGroupName
            // 
            this.grcGoodGroupName.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcGoodGroupName.DataPropertyName = "GoodGroupName";
            this.grcGoodGroupName.HeaderText = "Товарная группа";
            this.grcGoodGroupName.Name = "grcGoodGroupName";
            this.grcGoodGroupName.ReadOnly = true;
            this.grcGoodGroupName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcGoodGroupName.Width = 150;
            // 
            // grcGoodBrandName
            // 
            this.grcGoodBrandName.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcGoodBrandName.DataPropertyName = "GoodBrandName";
            this.grcGoodBrandName.HeaderText = "Товарный бренд";
            this.grcGoodBrandName.Name = "grcGoodBrandName";
            this.grcGoodBrandName.ReadOnly = true;
            this.grcGoodBrandName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcGoodBrandName.Width = 150;
            // 
            // grcArticul
            // 
            this.grcArticul.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcArticul.DataPropertyName = "Articul";
            this.grcArticul.HeaderText = "Артикул";
            this.grcArticul.Name = "grcArticul";
            this.grcArticul.ReadOnly = true;
            this.grcArticul.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // grcGoodBarCode
            // 
            this.grcGoodBarCode.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcGoodBarCode.DataPropertyName = "GoodBarCode";
            this.grcGoodBarCode.HeaderText = "ШК товара";
            this.grcGoodBarCode.Name = "grcGoodBarCode";
            this.grcGoodBarCode.ReadOnly = true;
            this.grcGoodBarCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcGoodBarCode.ToolTipText = "Штрих-код товара";
            this.grcGoodBarCode.Width = 130;
            // 
            // grcWeighting
            // 
            this.grcWeighting.DataPropertyName = "Weighting";
            this.grcWeighting.HeaderText = "Вес?";
            this.grcWeighting.Name = "grcWeighting";
            this.grcWeighting.ReadOnly = true;
            this.grcWeighting.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcWeighting.ToolTipText = "Весовой товар?";
            this.grcWeighting.Width = 40;
            // 
            // grcPickingCellAddress
            // 
            this.grcPickingCellAddress.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcPickingCellAddress.DataPropertyName = "PickingCellAddress";
            this.grcPickingCellAddress.HeaderText = "Пикинг";
            this.grcPickingCellAddress.Name = "grcPickingCellAddress";
            this.grcPickingCellAddress.ReadOnly = true;
            this.grcPickingCellAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcPickingCellAddress.ToolTipText = "Адрес ячейки пикинга";
            this.grcPickingCellAddress.Width = 80;
            // 
            // frmReportOutputsQntDifferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 516);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.pnlTerms);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.grdData);
            this.hpHelp.SetHelpKeyword(this, "1023");
            this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.IsModalMode = true;
            this.MinimizeBox = false;
            this.Name = "frmReportOutputsQntDifferences";
            this.hpHelp.SetShowHelp(this, true);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Расхождения при подборе / сборе / выдаче товаров";
            this.Load += new System.EventHandler(this.frmReportOutputsQntDifferences_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.pnlTerms.ResumeLayout(false);
            this.pnlTerms.PerformLayout();
            this.pnlUnit.ResumeLayout(false);
            this.pnlUnit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWeightDiffPrc)).EndInit();
            this.pnlGroupBy.ResumeLayout(false);
            this.pnlGroupBy.PerformLayout();
            this.pnlOpts2.ResumeLayout(false);
            this.pnlOpts2.PerformLayout();
            this.pnlOpts1.ResumeLayout(false);
            this.pnlOpts1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private RFMBaseClasses.RFMDataGridView grdData;
		private RFMBaseClasses.RFMButton btnExit;
		private RFMBaseClasses.RFMButton btnHelp;
		private RFMBaseClasses.RFMPanel pnlTerms;
		private RFMBaseClasses.RFMButton btnFilter;
		private RFMBaseClasses.RFMCheckBox chkIncludeWeighting;
		private RFMBaseClasses.RFMPanel pnlOpts1;
		private RFMBaseClasses.RFMRadioButton optConfirmed1;
		private RFMBaseClasses.RFMRadioButton optPicked1;
		private RFMBaseClasses.RFMRadioButton optSelected1;
		private RFMBaseClasses.RFMRadioButton optWished1;
		private RFMBaseClasses.RFMPanel pnlOpts2;
		private RFMBaseClasses.RFMRadioButton optConfirmed2;
		private RFMBaseClasses.RFMRadioButton optPicked2;
		private RFMBaseClasses.RFMRadioButton optSelected2;
		private RFMBaseClasses.RFMRadioButton optWished2;
		private RFMBaseClasses.RFMLabel lblNotEqual;
		private RFMBaseClasses.RFMLabel lblInfo;
		private RFMBaseClasses.RFMPanel pnlGroupBy;
		private RFMBaseClasses.RFMRadioButton optByPackings;
		private RFMBaseClasses.RFMRadioButton optByOutputs;
		private RFMBaseClasses.RFMButton btnExcel;
		private RFMBaseClasses.RFMLabel lblWeightDif;
		private RFMBaseClasses.RFMNumericUpDown numWeightDiffPrc;
        private RFMBaseClasses.RFMLabel lblWeightDiffPrc;
        private RFMBaseClasses.RFMPanel pnlUnit;
        private RFMBaseClasses.RFMRadioButton optUnit3;
        private RFMBaseClasses.RFMRadioButton optUnit2;
        private RFMBaseClasses.RFMRadioButton optUnit1;
        private RFMBaseClasses.RFMLabel lblUnit;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcDateOutput;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcOwnerName;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcPartnerName;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcERPCode;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodStateName;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodName;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcInBox;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcQntWished;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcQntSelected;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcQntPicked;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcQntConfirmed;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodGroupName;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodBrandName;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcArticul;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodBarCode;
        private RFMBaseClasses.RFMDataGridViewCheckBoxColumn grcWeighting;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcPickingCellAddress;
	}
}

