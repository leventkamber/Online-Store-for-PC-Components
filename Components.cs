using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eStore
{
    public partial class Components : Form
    {
        private Dictionary<string, int> dictionaryOfBrands;

        public Components()
        {
            InitializeComponent();
            dictionaryOfBrands = new Dictionary<string, int>();
        }

        private void Components_Load(object sender, EventArgs e)
        {
            
            SqlConnection myCon = new SqlConnection(@"Data Source = LEFCHO\SQLEXPRESS; AttachDbFilename = G:\test\pc_store.mdf; Integrated Security = True; Connect Timeout = 30");
            SqlCommand cmddatabase = new SqlCommand("select id,name from Brands", myCon);
            try
            {
                myCon.Open();
                SqlDataReader reader = cmddatabase.ExecuteReader();
                while (reader.Read())
                {
                    int brandId = reader.GetInt32(0);
                    string brandName = reader.GetString(1);

                    dictionaryOfBrands.Add(brandName, brandId);
                    comboBox1.Items.Add(brandName);
                }
                myCon.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection myCon = new SqlConnection(@"Data Source = LEFCHO\SQLEXPRESS; AttachDbFilename = G:\test\pc_store.mdf; Integrated Security = True; Connect Timeout = 30");
            
            SqlCommand cmddatabase = new SqlCommand("insert into Components (name, brandId, price) values ('" + this.textBox2.Text + "', '" + this.dictionaryOfBrands[this.comboBox1.SelectedItem.ToString()] + "', '" + this.textBox4.Text + "');", myCon);
            SqlDataReader myReader;
            try
            {
                myCon.Open();
                myReader = cmddatabase.ExecuteReader();
                MessageBox.Show("Добавено");
                while (myReader.Read())
                {
            
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void update_Click(object sender, EventArgs e)
        {
            SqlConnection myCon = new SqlConnection(@"Data Source = LEFCHO\SQLEXPRESS; AttachDbFilename = G:\test\pc_store.mdf; Integrated Security = True; Connect Timeout = 30");
            SqlCommand cmddatabase = new SqlCommand("update Components  set  name='" + this.textBox2.Text + "', brandId='" + this.dictionaryOfBrands[this.comboBox1.SelectedItem.ToString()] + "', price='" + this.textBox4.Text + "' where id='" + this.textBox1.Text + "';", myCon);
            SqlDataReader myReader;
            try
            {
                myCon.Open();
                myReader = cmddatabase.ExecuteReader();
                MessageBox.Show("Редактирано");
                while (myReader.Read())
                {
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            SqlConnection myCon = new SqlConnection(@"Data Source = LEFCHO\SQLEXPRESS; AttachDbFilename = G:\test\pc_store.mdf; Integrated Security = True; Connect Timeout = 30");
            SqlCommand cmddatabase = new SqlCommand("delete from Components  where id='" + this.textBox1.Text + "';", myCon);
            SqlDataReader myReader;
            try
            {
                myCon.Open();
                myReader = cmddatabase.ExecuteReader();
                MessageBox.Show("Изтрито");
                while (myReader.Read())
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection myCon = new SqlConnection(@"Data Source = LEFCHO\SQLEXPRESS; AttachDbFilename = G:\test\pc_store.mdf; Integrated Security = True; Connect Timeout = 30");
            SqlCommand cmddatabase = new SqlCommand("select Components.id,Components.name as 'Component Name',Brands.name as 'Brand Name' ,price from Components " +
                "INNER JOIN Brands ON Components.brandId = Brands.id", myCon);
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmddatabase;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                sda.Update(dbdataset);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
