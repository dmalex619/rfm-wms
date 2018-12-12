using System;
using RFMBaseClasses;

namespace WMSSuitable
{
	public partial class frmMain : RFMFormMain
	{
		public frmMain() : base()
		{
			InitializeComponent();
		}

		private void mniInputs_Click(object sender, EventArgs e)
		{
			StartForm(new frmInputs());
		}

		private void mniOutputs_Click(object sender, EventArgs e)
		{
			StartForm(new frmOutputs());
		}

		private void mniAuditActs_Click(object sender, EventArgs e)
		{
			StartForm(new frmAuditActs());
		}

		private void mniInventories_Click(object sender, EventArgs e)
		{
			StartForm(new frmInventories());
		}

		private void mniCells_Click(object sender, EventArgs e)
		{
			StartForm(new frmCells());
		}

		private void mniOddments_Click(object sender, EventArgs e)
		{
			StartForm(new frmOddments());
		}

		private void mniCellsContentsSnapshots_Click(object sender, EventArgs e)
		{
			StartForm(new frmCellsContentsSnapshots());
		}

		private void mniTrafficsFrames_Click(object sender, EventArgs e)
		{
			StartForm(new frmTrafficsFrames());
		}

		private void mniTrafficsGoods_Click(object sender, EventArgs e)
		{
			StartForm(new frmTrafficsGoods());
		}

		private void mniFrames_Click(object sender, EventArgs e)
		{
			StartForm(new frmFrames());
		}

		private void mniMovings_Click(object sender, EventArgs e)
		{
			StartForm(new frmMovings());
		}

		private void mniReportBarCode_Click(object sender, EventArgs e)
		{
			StartForm(new frmReportsBarCode());
		}

		private void mniReportCellsFramesHistory_Click(object sender, EventArgs e)
		{
			StartForm(new frmReportCellsFramesHistory());
		}

		private void mniReportTraffics_Click(object sender, EventArgs e)
		{
			StartForm(new frmReportTraffics());
		}

		private void mniReportOddmentsBalance_Click(object sender, EventArgs e)
		{
			StartForm(new frmReportOddmentsBalance());
		}

		private void mniSelectOnePacking_Click(object sender, EventArgs e)
		{
			StartForm(new frmSelectOnePacking());
		}

		private void mniReportInputsDateValid_Click(object sender, EventArgs e)
		{
			StartForm(new frmReportInputsDateValid());
		}

		private void mniReportForSalary_Click(object sender, EventArgs e)
		{
			StartForm(new frmReportForSalary());
		}

		private void mniSalaryExtraWorks_Click(object sender, EventArgs e)
		{
			StartForm(new frmSalaryExtraWorks()); 
		}

		private void mniSalaryTariffs_Click(object sender, EventArgs e)
		{
			StartForm(new frmSalaryTariffs());
		}

        private void mniShifts_Click(object sender, EventArgs e)
        {
            StartForm(new frmShifts());
        }

        private void mniShiftsProductivity_Click(object sender, EventArgs e)
        {
            StartForm(new frmReportShiftsProductivity());
        }

		private void mniTables_Click(object sender, EventArgs e)
		{
			StartForm(new frmSysLook());
		}

		private void mniUsers_Click(object sender, EventArgs e)
		{
			StartForm(new frmUsers());
		}

		#region Access

		private void mniAccessMainMenu_Click(object sender, EventArgs e)
		{
			StartForm(new frmAccessMainMenu());
		}

		private void mniAccessFormsMenus_Click(object sender, EventArgs e)
		{
			StartForm(new frmAccessFormsMenus());
		}

		private void mniAccessFormsControls_Click(object sender, EventArgs e)
		{
			StartForm(new frmAccessControls());
		}

		#endregion Access

		private void mniAccessConvertation_Click(object sender, EventArgs e)
		{
			StartForm(new frmAccessConversion());
		}

		private void mniAccessClearing_Click(object sender, EventArgs e)
		{
			StartForm(new frmAccessConversion(true));
		}

	}
}