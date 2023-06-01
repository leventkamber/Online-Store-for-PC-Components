using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace eStore
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            textBox4.PasswordChar = '*';
        }
        


      

        private void button2_Click(object sender, EventArgs e)
            
        {
            try
            {
                SqlConnection myCon = new SqlConnection(@"Data Source = LEFCHO\SQLEXPRESS; AttachDbFilename = G:\test\pc_store.mdf; Integrated Security = True; Connect Timeout = 30");
                //SqlConnection myCon = new SqlConnection(@"Data Source = LEFCHO\SQLEXPRESS; Initial Catalog = pc_store; Integrated Security = SSPI; Connect Timeout = 30");
                SqlCommand SelectCommand = new SqlCommand("select * from Employees_passwords where username='" + this.textBox3.Text + "' and passwords='" + this.textBox4.Text + "';", myCon);
                SqlDataReader myReader;
                myCon.Open();
                myReader = SelectCommand.ExecuteReader(); int count = 0; while (myReader.Read()) { count = count + 1; }
                if (count == 1)
                {
                    MessageBox.Show("Username and password is correct");
                    this.Hide(); //скриване на първата форма
                    MainMenu mainMenu = new MainMenu(); // деклариране на променлива f2 за нова форма
                    mainMenu.ShowDialog(); // чрез променливата се извиква втората форма
                }
                
                else if (count > 1)
                { MessageBox.Show("Dublicate username and password"); }
                else MessageBox.Show("Username and password is not correct, please try again");
                myCon.Close();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
