using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.Odbc;
using System.Data.SqlClient;

namespace eStore
{
    public partial class ImportData : Form
    {
       
        public ImportData()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "txt files (*.txt)|* .txt";
            ofd.DefaultExt = "txt";

            string[] values;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filename = ofd.FileName;

                string[] filelines = File.ReadAllLines(filename);

                for (int i = 0; i < filelines.Length-1; i++)
                {
                    values = filelines[i].ToString().Split('-');
                    string[] row = new string[values.Length-1];

                    for (int j = 0; j < values.Length -1 ; j++)
                    {
                        row[j] = values[j].Trim();
                    }
                    dataGridView1.Rows.Add(row);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection myCon = new SqlConnection(@"Data Source = LEFCHO\SQLEXPRESS; AttachDbFilename = G:\test\pc_store.mdf; Integrated Security = True; Connect Timeout = 30");

            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                SqlCommand myCmd = new SqlCommand("insert into Components (name, brandId, price, categoryId) values (@name, @brandId, @price, @categoryId)", myCon);
                {

                    myCmd.Parameters.AddWithValue("id", dataGridView1.Rows[i].Cells[0].Value);
                    myCmd.Parameters.AddWithValue("@name", dataGridView1.Rows[i].Cells[1].Value);
                    myCmd.Parameters.AddWithValue("@brandId", dataGridView1.Rows[i].Cells[2].Value);
                    myCmd.Parameters.AddWithValue("@price", dataGridView1.Rows[i].Cells[3].Value);
                    myCmd.Parameters.AddWithValue("@categoryId", dataGridView1.Rows[i].Cells[4].Value);
                    myCon.Open();
                    myCmd.ExecuteNonQuery();
                    myCon.Close();
                }
            }
                    
                
            
            
        }
    }
}
