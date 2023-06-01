using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eStore
{
    public partial class ExportData : Form
    {
        public ExportData()
        {
            InitializeComponent();
        }

        private string connectionString = null;
        private string tableName = null;
        Export export = null;
        private void ExportData_Load(object sender, EventArgs e)
        {
            connectionString = @"Data Source = LEFCHO\SQLEXPRESS; AttachDbFilename = G:\test\pc_store.mdf; Integrated Security = True; Connect Timeout = 30";
            tableName = "Components";
            export = new Export();
            Connection.connectionString = connectionString;
            Connection.tableName = tableName;
            dataGridView1.DataSource = export.GetData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            export.To_Text();
        }
    }
}
