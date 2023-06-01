using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eStore
{
    public partial class Orders : Form
    {
        public Orders()
        {
            InitializeComponent();
        }
/*
        SELECT Orders.OrderID, Customers.CustomerName, Shippers.ShipperName
        FROM ((Orders
        INNER JOIN Customers ON Orders.CustomerID = Customers.CustomerID)
        INNER JOIN Shippers ON Orders.ShipperID = Shippers.ShipperID);*/
        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void Orders_Load(object sender, EventArgs e)
        {
            SqlConnection myCon = new SqlConnection(@"Data Source = LEFCHO\SQLEXPRESS; AttachDbFilename = G:\test\pc_store.mdf; Integrated Security = True; Connect Timeout = 30");
            SqlCommand cmddatabase = new SqlCommand("select concat(Employees.name, ' ', Employees.lastName) AS Employee, concat(Brands.name, ' ', Components.name) AS Item, Components.price, Orders.orderDate, Orders.quantity, " +
                "concat(Clients.name, ' ', Clients.lastName) AS Client, concat(Clients.city, ', ', Clients.address) AS Address, Clients.telephone from Orders " +
                "INNER JOIN Employees ON Orders.employeeId = Employees.id " +
                "INNER JOIN Components ON Orders.componentId = Components.id " +
                "INNER JOIN Clients ON Orders.clientId = Clients.id " +
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
    }
}
