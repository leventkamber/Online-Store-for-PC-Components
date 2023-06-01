using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace eStore
{
    class Connection
    {
        public static string connectionString { get; set; }
        public static string tableName { get; set; }
        protected string status { get; set; }
        protected SqlConnection connection;
        protected SqlCommand command;
        protected SqlDataReader dataReader;

        protected DataTable loadData()
        {
            DataTable data = null;
            try
            {
                connection = new SqlConnection(connectionString);
                string query = string.Format("select * from {0}", tableName);
                using(connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using(command = connection.CreateCommand())
                    {
                        command.CommandText = query;
                        dataReader = command.ExecuteReader();
                        data = new DataTable();
                        data.Load(dataReader);
                    }
                    
                }
                return data;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return data;
            }
        }
    }
}
