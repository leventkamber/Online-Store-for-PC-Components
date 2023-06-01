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
    public partial class Clients : Form
    {
        public Clients()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void add_Click(object sender, EventArgs e)
        {
            SqlConnection myCon = new SqlConnection(@"Data Source = LEFCHO\SQLEXPRESS; AttachDbFilename = G:\test\pc_store.mdf; Integrated Security = True; Connect Timeout = 30");

            SqlCommand cmddatabase = new SqlCommand("insert into Clients (name, lastName, city, address, telephone) values ('" + this.textBox2.Text + "', '" + this.textBox3.Text + "', '" + this.textBox4.Text + "', '" + this.textBox5.Text + "', '" + this.textBox6.Text + "');", myCon);
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
        private void update_Click_1(object sender, EventArgs e)
        {
            SqlConnection myCon = new SqlConnection(@"Data Source = LEFCHO\SQLEXPRESS; AttachDbFilename = G:\test\pc_store.mdf; Integrated Security = True; Connect Timeout = 30");
            SqlCommand cmddatabase = new SqlCommand("update Clients  set  name='" + this.textBox2.Text + "', lastName='" + this.textBox3.Text + "', city='" + this.textBox4.Text + "', address='" + this.textBox5.Text + "', telephone='" + this.textBox6.Text + "' where id='" + this.textBox1.Text + "';", myCon);
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
        private void delete_Click_1(object sender, EventArgs e)
        {
            SqlConnection myCon = new SqlConnection(@"Data Source = LEFCHO\SQLEXPRESS; AttachDbFilename = G:\test\pc_store.mdf; Integrated Security = True; Connect Timeout = 30");
            SqlCommand cmddatabase = new SqlCommand("delete from Clients  where id='" + this.textBox1.Text + "';", myCon);
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
       
        private void button4_Click_1(object sender, EventArgs e)
        {
            SqlConnection myCon = new SqlConnection(@"Data Source = LEFCHO\SQLEXPRESS; AttachDbFilename = G:\test\pc_store.mdf; Integrated Security = True; Connect Timeout = 30");
            SqlCommand cmddatabase = new SqlCommand("select id, concat(name, ' ', lastName) AS 'Client Name',concat(city, ' ', address) AS 'Address',telephone from Clients", myCon);
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

        private void Clients_Load(object sender, EventArgs e)
        {

        }
    }
}
