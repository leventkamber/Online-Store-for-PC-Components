﻿using System;
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
    public partial class Emplyees : Form
    {
        public Emplyees()
        {
            InitializeComponent();
        }

        private void Emplyees_Load(object sender, EventArgs e)
        {
            SqlConnection myCon = new SqlConnection(@"Data Source = LEFCHO\SQLEXPRESS; AttachDbFilename = G:\test\pc_store.mdf; Integrated Security = True; Connect Timeout = 30");
            SqlCommand cmddatabase = new SqlCommand("select id,name,lastName,city,address,telephone from Employees", myCon);
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

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
