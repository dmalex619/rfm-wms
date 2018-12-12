using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Cleverence.Warehouse.Com;

namespace Exchange_SWMS_LW
{
    public partial class frmExchange : Form
    {
        protected Cleverence.Warehouse.StorageConnector _LW = new Cleverence.Warehouse.StorageConnector();
        protected DataTable _dt = new DataTable();
        protected int _step = 0;

        public frmExchange()
        {
            InitializeComponent();
        }

        private void frmExchange_Load(object sender, EventArgs e)
        {
            bool _Result = false;

            // Соединение с "Легким складом"
            try
            {
                _LW.InitializeServerConnection("http://localhost/Cleverence.Warehouse.DataService/DataStorage.asmx");
                _Result = _LW.CheckConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (!_Result) this.Dispose();
            
            // Создание таблицы
            _dt.Columns.Add("Step", typeof(Int16));
            _dt.Columns.Add("Time", typeof(DateTime));
            _dt.Columns.Add("DocsCount", typeof(Int16));
            _dt.Columns.Add("FinishCount", typeof(Int16));
            _dt.Columns.Add("InProcCount", typeof(Int16));

            // Привязка таблицы к Grid
            dgvMain.DataSource = _dt;
            dgvMain.Sort(dgvMain.Columns["colStep"], ListSortDirection.Descending);
            
            // Запуск таймера обмена
            tmrExchange.Start();
        }

        private void tmrExchange_Tick(object sender, EventArgs e)
        {
            Cleverence.Warehouse.DocumentCollection Docs;
            Docs = _LW.GetDocuments("", false);

            int _Finished = 0, _InProcess = 0, _Modified = 0;

            foreach (Cleverence.Warehouse.Document doc in Docs)
            {
                if (doc.Finished) _Finished++;
                if (doc.InProcess) _InProcess++;
                if (doc.Modified) _Modified++;
            }

            _dt.Rows.Add(new object[] { _step++, DateTime.Now, Docs.Count, _Finished, _InProcess });
            dgvMain.CurrentCell = dgvMain.Rows[0].Cells[0];
            // MessageBox.Show(_dt.Rows.Count.ToString());
        }
    }
}