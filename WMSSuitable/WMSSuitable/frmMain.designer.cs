namespace WMSSuitable
{
	partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mnuMain = new RFMBaseClasses.RFMMenuStrip();
            this.mniOperationsTop = new RFMBaseClasses.RFMToolStripMenuItem();
            this.mniInputs = new RFMBaseClasses.RFMToolStripMenuItem();
            this.mniOutputs = new RFMBaseClasses.RFMToolStripMenuItem();
            this.mniAuditActs = new RFMBaseClasses.RFMToolStripMenuItem();
            this.mniStorageTop = new RFMBaseClasses.RFMToolStripMenuItem();
            this.mniCells = new RFMBaseClasses.RFMToolStripMenuItem();
            this.mniOddments = new RFMBaseClasses.RFMToolStripMenuItem();
            this.mniCellsContentsSnapshots = new RFMBaseClasses.RFMToolStripMenuItem();
            this.mniInventories = new RFMBaseClasses.RFMToolStripMenuItem();
            this.mniTrafficsMovingsTop = new RFMBaseClasses.RFMToolStripMenuItem();
            this.mniTrafficsFrames = new RFMBaseClasses.RFMToolStripMenuItem();
            this.mniTrafficsGoods = new RFMBaseClasses.RFMToolStripMenuItem();
            this.mniFrames = new RFMBaseClasses.RFMToolStripMenuItem();
            this.mniMovings = new RFMBaseClasses.RFMToolStripMenuItem();
            this.mniReferenciesTop = new RFMBaseClasses.RFMToolStripMenuItem();
            this.mniTables = new RFMBaseClasses.RFMToolStripMenuItem();
            this.mniUsers = new RFMBaseClasses.RFMToolStripMenuItem();
            this.mniReportsTop = new RFMBaseClasses.RFMToolStripMenuItem();
            this.mniSelectOnePacking = new RFMBaseClasses.RFMToolStripMenuItem();
            this.mniReportOddmentsBalance = new RFMBaseClasses.RFMToolStripMenuItem();
            this.mniReportCellsFramesHistory = new RFMBaseClasses.RFMToolStripMenuItem();
            this.mniReportTraffics = new RFMBaseClasses.RFMToolStripMenuItem();
            this.mniReportInputsDateValid = new RFMBaseClasses.RFMToolStripMenuItem();
            this.mniReportBarCode = new RFMBaseClasses.RFMToolStripMenuItem();
            this.mniForSalary = new RFMBaseClasses.RFMToolStripMenuItem();
            this.mniReportForSalary = new RFMBaseClasses.RFMToolStripMenuItem();
            this.mniSalaryExtraWorks = new RFMBaseClasses.RFMToolStripMenuItem();
            this.mniSalaryTariffs = new RFMBaseClasses.RFMToolStripMenuItem();
            this.mniShifts = new RFMBaseClasses.RFMToolStripMenuItem();
            this.mniShiftsProductivity = new RFMBaseClasses.RFMToolStripMenuItem();
            this.mniAddTop = new RFMBaseClasses.RFMToolStripMenuItem();
            this.mniAccessMainMenu = new RFMBaseClasses.RFMToolStripMenuItem();
            this.mniAccessFormsMenus = new RFMBaseClasses.RFMToolStripMenuItem();
            this.mniAccessFormsControls = new RFMBaseClasses.RFMToolStripMenuItem();
            this.mniAccessConvertation = new RFMBaseClasses.RFMToolStripMenuItem();
            this.mniAccessClearing = new RFMBaseClasses.RFMToolStripMenuItem();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(0, 439);
            this.txtStatus.OldValue = "";
            this.txtStatus.Size = new System.Drawing.Size(734, 22);
            // 
            // mnuMain
            // 
            this.mnuMain.IsAccessOn = true;
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniOperationsTop,
            this.mniStorageTop,
            this.mniTrafficsMovingsTop,
            this.mniReferenciesTop,
            this.mniReportsTop,
            this.mniAddTop});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(734, 26);
            this.mnuMain.TabIndex = 7;
            this.mnuMain.Visible = false;
            // 
            // mniOperationsTop
            // 
            this.mniOperationsTop.CmdName = "";
            this.mniOperationsTop.CmdParam = "";
            this.mniOperationsTop.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniInputs,
            this.mniOutputs,
            this.mniAuditActs});
            this.mniOperationsTop.IsForm = false;
            this.mniOperationsTop.Name = "mniOperationsTop";
            this.mniOperationsTop.Size = new System.Drawing.Size(145, 22);
            this.mniOperationsTop.Text = "Внешние операции";
            // 
            // mniInputs
            // 
            this.mniInputs.CmdName = "";
            this.mniInputs.CmdParam = "";
            this.mniInputs.IsForm = false;
            this.mniInputs.Name = "mniInputs";
            this.mniInputs.Size = new System.Drawing.Size(134, 22);
            this.mniInputs.Text = "Приходы";
            this.mniInputs.Click += new System.EventHandler(this.mniInputs_Click);
            // 
            // mniOutputs
            // 
            this.mniOutputs.CmdName = "";
            this.mniOutputs.CmdParam = "";
            this.mniOutputs.IsForm = false;
            this.mniOutputs.Name = "mniOutputs";
            this.mniOutputs.Size = new System.Drawing.Size(134, 22);
            this.mniOutputs.Text = "Расходы";
            this.mniOutputs.Click += new System.EventHandler(this.mniOutputs_Click);
            // 
            // mniAuditActs
            // 
            this.mniAuditActs.CmdName = "";
            this.mniAuditActs.CmdParam = "";
            this.mniAuditActs.IsForm = false;
            this.mniAuditActs.Name = "mniAuditActs";
            this.mniAuditActs.Size = new System.Drawing.Size(134, 22);
            this.mniAuditActs.Text = "Акты";
            this.mniAuditActs.Click += new System.EventHandler(this.mniAuditActs_Click);
            // 
            // mniStorageTop
            // 
            this.mniStorageTop.CmdName = "";
            this.mniStorageTop.CmdParam = "";
            this.mniStorageTop.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniCells,
            this.mniOddments,
            this.mniCellsContentsSnapshots,
            this.mniInventories});
            this.mniStorageTop.IsForm = false;
            this.mniStorageTop.Name = "mniStorageTop";
            this.mniStorageTop.Size = new System.Drawing.Size(58, 22);
            this.mniStorageTop.Text = "Склад";
            // 
            // mniCells
            // 
            this.mniCells.CmdName = "";
            this.mniCells.CmdParam = "";
            this.mniCells.IsForm = false;
            this.mniCells.Name = "mniCells";
            this.mniCells.Size = new System.Drawing.Size(174, 22);
            this.mniCells.Text = "Ячейки";
            this.mniCells.Click += new System.EventHandler(this.mniCells_Click);
            // 
            // mniOddments
            // 
            this.mniOddments.CmdName = "";
            this.mniOddments.CmdParam = "";
            this.mniOddments.IsForm = false;
            this.mniOddments.Name = "mniOddments";
            this.mniOddments.Size = new System.Drawing.Size(174, 22);
            this.mniOddments.Text = "Остатки";
            this.mniOddments.Click += new System.EventHandler(this.mniOddments_Click);
            // 
            // mniCellsContentsSnapshots
            // 
            this.mniCellsContentsSnapshots.CmdName = "";
            this.mniCellsContentsSnapshots.CmdParam = "";
            this.mniCellsContentsSnapshots.IsForm = false;
            this.mniCellsContentsSnapshots.Name = "mniCellsContentsSnapshots";
            this.mniCellsContentsSnapshots.Size = new System.Drawing.Size(174, 22);
            this.mniCellsContentsSnapshots.Text = "Срезы остатков";
            this.mniCellsContentsSnapshots.Click += new System.EventHandler(this.mniCellsContentsSnapshots_Click);
            // 
            // mniInventories
            // 
            this.mniInventories.CmdName = "";
            this.mniInventories.CmdParam = "";
            this.mniInventories.IsForm = false;
            this.mniInventories.Name = "mniInventories";
            this.mniInventories.Size = new System.Drawing.Size(174, 22);
            this.mniInventories.Text = "Ревизии";
            this.mniInventories.Click += new System.EventHandler(this.mniInventories_Click);
            // 
            // mniTrafficsMovingsTop
            // 
            this.mniTrafficsMovingsTop.CmdName = "";
            this.mniTrafficsMovingsTop.CmdParam = "";
            this.mniTrafficsMovingsTop.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniTrafficsFrames,
            this.mniTrafficsGoods,
            this.mniFrames,
            this.mniMovings});
            this.mniTrafficsMovingsTop.IsForm = false;
            this.mniTrafficsMovingsTop.Name = "mniTrafficsMovingsTop";
            this.mniTrafficsMovingsTop.Size = new System.Drawing.Size(113, 22);
            this.mniTrafficsMovingsTop.Text = "Перемещения";
            // 
            // mniTrafficsFrames
            // 
            this.mniTrafficsFrames.CmdName = "";
            this.mniTrafficsFrames.CmdParam = "";
            this.mniTrafficsFrames.IsForm = false;
            this.mniTrafficsFrames.Name = "mniTrafficsFrames";
            this.mniTrafficsFrames.Size = new System.Drawing.Size(341, 22);
            this.mniTrafficsFrames.Text = "Операции перемещения контейнеров";
            this.mniTrafficsFrames.Click += new System.EventHandler(this.mniTrafficsFrames_Click);
            // 
            // mniTrafficsGoods
            // 
            this.mniTrafficsGoods.CmdName = "";
            this.mniTrafficsGoods.CmdParam = "";
            this.mniTrafficsGoods.IsForm = false;
            this.mniTrafficsGoods.Name = "mniTrafficsGoods";
            this.mniTrafficsGoods.Size = new System.Drawing.Size(341, 22);
            this.mniTrafficsGoods.Text = "Операции перемещения коробок/штук";
            this.mniTrafficsGoods.Click += new System.EventHandler(this.mniTrafficsGoods_Click);
            // 
            // mniFrames
            // 
            this.mniFrames.CmdName = "";
            this.mniFrames.CmdParam = "";
            this.mniFrames.IsForm = false;
            this.mniFrames.Name = "mniFrames";
            this.mniFrames.Size = new System.Drawing.Size(341, 22);
            this.mniFrames.Text = "Контейнеры и их текущее расположение";
            this.mniFrames.Click += new System.EventHandler(this.mniFrames_Click);
            // 
            // mniMovings
            // 
            this.mniMovings.CmdName = "";
            this.mniMovings.CmdParam = "";
            this.mniMovings.IsForm = false;
            this.mniMovings.Name = "mniMovings";
            this.mniMovings.Size = new System.Drawing.Size(341, 22);
            this.mniMovings.Text = "Внутрискладские перемещения";
            this.mniMovings.Click += new System.EventHandler(this.mniMovings_Click);
            // 
            // mniReferenciesTop
            // 
            this.mniReferenciesTop.CmdName = "";
            this.mniReferenciesTop.CmdParam = "";
            this.mniReferenciesTop.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniTables,
            this.mniUsers});
            this.mniReferenciesTop.IsForm = false;
            this.mniReferenciesTop.Name = "mniReferenciesTop";
            this.mniReferenciesTop.Size = new System.Drawing.Size(104, 22);
            this.mniReferenciesTop.Text = "Справочники";
            // 
            // mniTables
            // 
            this.mniTables.CmdName = "";
            this.mniTables.CmdParam = "";
            this.mniTables.IsAccessOn = true;
            this.mniTables.IsForm = false;
            this.mniTables.Name = "mniTables";
            this.mniTables.Size = new System.Drawing.Size(166, 22);
            this.mniTables.Text = "Таблицы";
            this.mniTables.Click += new System.EventHandler(this.mniTables_Click);
            // 
            // mniUsers
            // 
            this.mniUsers.CmdName = "";
            this.mniUsers.CmdParam = "";
            this.mniUsers.IsForm = false;
            this.mniUsers.Name = "mniUsers";
            this.mniUsers.Size = new System.Drawing.Size(166, 22);
            this.mniUsers.Text = "Пользователи";
            this.mniUsers.Click += new System.EventHandler(this.mniUsers_Click);
            // 
            // mniReportsTop
            // 
            this.mniReportsTop.CmdName = "";
            this.mniReportsTop.CmdParam = "";
            this.mniReportsTop.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniSelectOnePacking,
            this.mniReportOddmentsBalance,
            this.mniReportCellsFramesHistory,
            this.mniReportTraffics,
            this.mniReportInputsDateValid,
            this.mniReportBarCode,
            this.mniForSalary});
            this.mniReportsTop.IsForm = false;
            this.mniReportsTop.Name = "mniReportsTop";
            this.mniReportsTop.Size = new System.Drawing.Size(67, 22);
            this.mniReportsTop.Text = "Отчеты";
            // 
            // mniSelectOnePacking
            // 
            this.mniSelectOnePacking.CmdName = "";
            this.mniSelectOnePacking.CmdParam = "";
            this.mniSelectOnePacking.IsForm = false;
            this.mniSelectOnePacking.Name = "mniSelectOnePacking";
            this.mniSelectOnePacking.Size = new System.Drawing.Size(315, 22);
            this.mniSelectOnePacking.Text = "Товары/упаковки";
            this.mniSelectOnePacking.Click += new System.EventHandler(this.mniSelectOnePacking_Click);
            // 
            // mniReportOddmentsBalance
            // 
            this.mniReportOddmentsBalance.CmdName = "";
            this.mniReportOddmentsBalance.CmdParam = "";
            this.mniReportOddmentsBalance.IsForm = false;
            this.mniReportOddmentsBalance.Name = "mniReportOddmentsBalance";
            this.mniReportOddmentsBalance.Size = new System.Drawing.Size(315, 22);
            this.mniReportOddmentsBalance.Text = "Остатки и операции за период";
            this.mniReportOddmentsBalance.Click += new System.EventHandler(this.mniReportOddmentsBalance_Click);
            // 
            // mniReportCellsFramesHistory
            // 
            this.mniReportCellsFramesHistory.CmdName = "";
            this.mniReportCellsFramesHistory.CmdParam = "";
            this.mniReportCellsFramesHistory.IsForm = false;
            this.mniReportCellsFramesHistory.Name = "mniReportCellsFramesHistory";
            this.mniReportCellsFramesHistory.Size = new System.Drawing.Size(315, 22);
            this.mniReportCellsFramesHistory.Text = "Операции с ячейками/контейнерами";
            this.mniReportCellsFramesHistory.Click += new System.EventHandler(this.mniReportCellsFramesHistory_Click);
            // 
            // mniReportTraffics
            // 
            this.mniReportTraffics.CmdName = "";
            this.mniReportTraffics.CmdParam = "";
            this.mniReportTraffics.IsForm = false;
            this.mniReportTraffics.Name = "mniReportTraffics";
            this.mniReportTraffics.Size = new System.Drawing.Size(315, 22);
            this.mniReportTraffics.Text = "Транспортировки и перемещения";
            this.mniReportTraffics.Click += new System.EventHandler(this.mniReportTraffics_Click);
            // 
            // mniReportInputsDateValid
            // 
            this.mniReportInputsDateValid.CmdName = "";
            this.mniReportInputsDateValid.CmdParam = "";
            this.mniReportInputsDateValid.IsForm = false;
            this.mniReportInputsDateValid.Name = "mniReportInputsDateValid";
            this.mniReportInputsDateValid.Size = new System.Drawing.Size(315, 22);
            this.mniReportInputsDateValid.Text = "Сроки годности в приходах";
            this.mniReportInputsDateValid.Click += new System.EventHandler(this.mniReportInputsDateValid_Click);
            // 
            // mniReportBarCode
            // 
            this.mniReportBarCode.CmdName = "";
            this.mniReportBarCode.CmdParam = "";
            this.mniReportBarCode.IsForm = false;
            this.mniReportBarCode.Name = "mniReportBarCode";
            this.mniReportBarCode.Size = new System.Drawing.Size(315, 22);
            this.mniReportBarCode.Text = "Информация о штрих-коде";
            this.mniReportBarCode.Click += new System.EventHandler(this.mniReportBarCode_Click);
            // 
            // mniForSalary
            // 
            this.mniForSalary.CmdName = "";
            this.mniForSalary.CmdParam = "";
            this.mniForSalary.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniReportForSalary,
            this.mniSalaryExtraWorks,
            this.mniSalaryTariffs,
            this.mniShifts,
            this.mniShiftsProductivity});
            this.mniForSalary.IsAccessOn = true;
            this.mniForSalary.IsForm = false;
            this.mniForSalary.Name = "mniForSalary";
            this.mniForSalary.Size = new System.Drawing.Size(315, 22);
            this.mniForSalary.Text = "Зарплата";
            // 
            // mniReportForSalary
            // 
            this.mniReportForSalary.CmdName = "";
            this.mniReportForSalary.CmdParam = "";
            this.mniReportForSalary.IsAccessOn = true;
            this.mniReportForSalary.IsForm = false;
            this.mniReportForSalary.Name = "mniReportForSalary";
            this.mniReportForSalary.Size = new System.Drawing.Size(351, 22);
            this.mniReportForSalary.Text = "Отчет по операциям для зарплаты";
            this.mniReportForSalary.Click += new System.EventHandler(this.mniReportForSalary_Click);
            // 
            // mniSalaryExtraWorks
            // 
            this.mniSalaryExtraWorks.CmdName = "";
            this.mniSalaryExtraWorks.CmdParam = "";
            this.mniSalaryExtraWorks.IsAccessOn = true;
            this.mniSalaryExtraWorks.IsForm = false;
            this.mniSalaryExtraWorks.Name = "mniSalaryExtraWorks";
            this.mniSalaryExtraWorks.Size = new System.Drawing.Size(351, 22);
            this.mniSalaryExtraWorks.Text = "Дополнительные внутрискладские работы";
            this.mniSalaryExtraWorks.Click += new System.EventHandler(this.mniSalaryExtraWorks_Click);
            // 
            // mniSalaryTariffs
            // 
            this.mniSalaryTariffs.CmdName = "";
            this.mniSalaryTariffs.CmdParam = "";
            this.mniSalaryTariffs.IsAccessOn = true;
            this.mniSalaryTariffs.IsForm = false;
            this.mniSalaryTariffs.Name = "mniSalaryTariffs";
            this.mniSalaryTariffs.Size = new System.Drawing.Size(351, 22);
            this.mniSalaryTariffs.Text = "Тарифы по видам работ";
            this.mniSalaryTariffs.Click += new System.EventHandler(this.mniSalaryTariffs_Click);
            // 
            // mniShifts
            // 
            this.mniShifts.CmdName = "";
            this.mniShifts.CmdParam = "";
            this.mniShifts.IsAccessOn = true;
            this.mniShifts.IsForm = false;
            this.mniShifts.Name = "mniShifts";
            this.mniShifts.Size = new System.Drawing.Size(351, 22);
            this.mniShifts.Text = "Журнал смен";
            this.mniShifts.Click += new System.EventHandler(this.mniShifts_Click);
            // 
            // mniShiftsProductivity
            // 
            this.mniShiftsProductivity.CmdName = "";
            this.mniShiftsProductivity.CmdParam = "";
            this.mniShiftsProductivity.IsForm = false;
            this.mniShiftsProductivity.Name = "mniShiftsProductivity";
            this.mniShiftsProductivity.Size = new System.Drawing.Size(351, 22);
            this.mniShiftsProductivity.Text = "Отчет о сменной производительности";
            this.mniShiftsProductivity.Click += new System.EventHandler(this.mniShiftsProductivity_Click);
            // 
            // mniAddTop
            // 
            this.mniAddTop.CmdName = "";
            this.mniAddTop.CmdParam = "";
            this.mniAddTop.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniAccessMainMenu,
            this.mniAccessFormsMenus,
            this.mniAccessFormsControls,
            this.mniAccessConvertation,
            this.mniAccessClearing});
            this.mniAddTop.IsAccessOn = true;
            this.mniAddTop.IsForm = false;
            this.mniAddTop.Name = "mniAddTop";
            this.mniAddTop.Size = new System.Drawing.Size(123, 22);
            this.mniAddTop.Text = "Дополнительно";
            // 
            // mniAccessMainMenu
            // 
            this.mniAccessMainMenu.CmdName = "";
            this.mniAccessMainMenu.CmdParam = "";
            this.mniAccessMainMenu.IsAccessOn = true;
            this.mniAccessMainMenu.IsForm = false;
            this.mniAccessMainMenu.Name = "mniAccessMainMenu";
            this.mniAccessMainMenu.Size = new System.Drawing.Size(355, 22);
            this.mniAccessMainMenu.Text = "Права доступа к главному меню";
            this.mniAccessMainMenu.Click += new System.EventHandler(this.mniAccessMainMenu_Click);
            // 
            // mniAccessFormsMenus
            // 
            this.mniAccessFormsMenus.CmdName = "";
            this.mniAccessFormsMenus.CmdParam = "";
            this.mniAccessFormsMenus.IsAccessOn = true;
            this.mniAccessFormsMenus.IsForm = false;
            this.mniAccessFormsMenus.Name = "mniAccessFormsMenus";
            this.mniAccessFormsMenus.Size = new System.Drawing.Size(355, 22);
            this.mniAccessFormsMenus.Text = "Права доступа к меню экранных форм";
            this.mniAccessFormsMenus.Visible = false;
            this.mniAccessFormsMenus.Click += new System.EventHandler(this.mniAccessFormsMenus_Click);
            // 
            // mniAccessFormsControls
            // 
            this.mniAccessFormsControls.CmdName = "";
            this.mniAccessFormsControls.CmdParam = "";
            this.mniAccessFormsControls.IsAccessOn = true;
            this.mniAccessFormsControls.IsForm = false;
            this.mniAccessFormsControls.Name = "mniAccessFormsControls";
            this.mniAccessFormsControls.Size = new System.Drawing.Size(355, 22);
            this.mniAccessFormsControls.Text = "Права доступа к элементам экранных форм";
            this.mniAccessFormsControls.Click += new System.EventHandler(this.mniAccessFormsControls_Click);
            // 
            // mniAccessConvertation
            // 
            this.mniAccessConvertation.CmdName = "";
            this.mniAccessConvertation.CmdParam = "";
            this.mniAccessConvertation.IsAccessOn = true;
            this.mniAccessConvertation.IsForm = false;
            this.mniAccessConvertation.Name = "mniAccessConvertation";
            this.mniAccessConvertation.Size = new System.Drawing.Size(355, 22);
            this.mniAccessConvertation.Text = "* Конвертация таблицы прав";
            this.mniAccessConvertation.Visible = false;
            this.mniAccessConvertation.Click += new System.EventHandler(this.mniAccessConvertation_Click);
            // 
            // mniAccessClearing
            // 
            this.mniAccessClearing.CmdName = "";
            this.mniAccessClearing.CmdParam = "";
            this.mniAccessClearing.IsAccessOn = true;
            this.mniAccessClearing.IsForm = false;
            this.mniAccessClearing.Name = "mniAccessClearing";
            this.mniAccessClearing.Size = new System.Drawing.Size(355, 22);
            this.mniAccessClearing.Text = "* Очистка таблицы прав";
            this.mniAccessClearing.Visible = false;
            this.mniAccessClearing.Click += new System.EventHandler(this.mniAccessClearing_Click);
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.mnuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(150, 100);
            this.Name = "frmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "SuitableWMS";
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.mnuMain, 0);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private RFMBaseClasses.RFMMenuStrip mnuMain;
		private RFMBaseClasses.RFMToolStripMenuItem mniOperationsTop;
		private RFMBaseClasses.RFMToolStripMenuItem mniInputs;
		private RFMBaseClasses.RFMToolStripMenuItem mniOutputs;
		private RFMBaseClasses.RFMToolStripMenuItem mniAuditActs;
		private RFMBaseClasses.RFMToolStripMenuItem mniStorageTop;
		private RFMBaseClasses.RFMToolStripMenuItem mniCells;
		private RFMBaseClasses.RFMToolStripMenuItem mniOddments;
		private RFMBaseClasses.RFMToolStripMenuItem mniTrafficsMovingsTop;
		private RFMBaseClasses.RFMToolStripMenuItem mniTrafficsFrames;
		private RFMBaseClasses.RFMToolStripMenuItem mniTrafficsGoods;
		private RFMBaseClasses.RFMToolStripMenuItem mniFrames;
		private RFMBaseClasses.RFMToolStripMenuItem mniReportsTop;
		private RFMBaseClasses.RFMToolStripMenuItem mniReportBarCode;
		private RFMBaseClasses.RFMToolStripMenuItem mniReportCellsFramesHistory;
		private RFMBaseClasses.RFMToolStripMenuItem mniReportTraffics;
		private RFMBaseClasses.RFMToolStripMenuItem mniReportOddmentsBalance;
		private RFMBaseClasses.RFMToolStripMenuItem mniSelectOnePacking;
		private RFMBaseClasses.RFMToolStripMenuItem mniReportInputsDateValid;
		private RFMBaseClasses.RFMToolStripMenuItem mniForSalary;
		private RFMBaseClasses.RFMToolStripMenuItem mniReferenciesTop;
		private RFMBaseClasses.RFMToolStripMenuItem mniTables;
		private RFMBaseClasses.RFMToolStripMenuItem mniUsers;
		private RFMBaseClasses.RFMToolStripMenuItem mniAddTop;
		private RFMBaseClasses.RFMToolStripMenuItem mniAccessMainMenu;
		private RFMBaseClasses.RFMToolStripMenuItem mniAccessFormsMenus;
		private RFMBaseClasses.RFMToolStripMenuItem mniAccessFormsControls;
		private RFMBaseClasses.RFMToolStripMenuItem mniInventories;
		private RFMBaseClasses.RFMToolStripMenuItem mniCellsContentsSnapshots;
        private RFMBaseClasses.RFMToolStripMenuItem mniMovings;
        private RFMBaseClasses.RFMToolStripMenuItem mniReportForSalary;
        private RFMBaseClasses.RFMToolStripMenuItem mniSalaryExtraWorks;
        private RFMBaseClasses.RFMToolStripMenuItem mniSalaryTariffs;
        private RFMBaseClasses.RFMToolStripMenuItem mniShifts;
        private RFMBaseClasses.RFMToolStripMenuItem mniShiftsProductivity;
		private RFMBaseClasses.RFMToolStripMenuItem mniAccessConvertation;
		private RFMBaseClasses.RFMToolStripMenuItem mniAccessClearing;

	}
}