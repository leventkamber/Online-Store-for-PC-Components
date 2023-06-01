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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }
        Components component;
        private void компютрърниКомпонентиИПериферияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (component == null)
            {
                component = new Components();
                component.MdiParent = this;
                component.FormClosed += Component_FormClosed;
                component.Show();
            }
            else
            {
                component.Activate();
            }
        }

        private void Component_FormClosed(object sender, FormClosedEventArgs e)
        {
            component = null;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }
        fullBrandDescription fbd;
        private void описаниеНаКомпютъренКомпонентИлиПериферияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fbd == null)
            {
                fbd = new fullBrandDescription();
                fbd.MdiParent = this;
                fbd.FormClosed += Fbd_FormClosed;
                fbd.Show();
            }
            else
            {
                fbd.Activate();
            }
        }

        private void Fbd_FormClosed(object sender, FormClosedEventArgs e)
        {
            throw new NotImplementedException();
        }

        Brands brand;
        private void маркиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (brand == null)
            {
                brand = new Brands();
                brand.MdiParent = this;
                brand.FormClosed += Brand_FormClosed;
                brand.Show();
            }
            else
            {
                brand.Activate();
            }
        }

        private void Brand_FormClosed(object sender, FormClosedEventArgs e)
        {
            brand = null;
        }

        Clients client;
        private void клиентиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (client == null)
            {
                client = new Clients();
                client.MdiParent = this;
                client.FormClosed += Client_FormClosed;
                client.Show();
            }
            else
            {
                client.Activate();
            }
        }

        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            client = null;
        }
        Clients_ client_;
        private void клиентиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (client_ == null)
            {
                client_ = new Clients_();
                client_.MdiParent = this;
                client_.FormClosed += Client__FormClosed;
                client_.Show();
            }
            else
            {
                client_.Activate();
            }
        }

        private void Client__FormClosed(object sender, FormClosedEventArgs e)
        {
            client_ = null;
        }

        Emplyees employee;
        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            if (employee == null)
            {
                employee = new Emplyees();
                employee.MdiParent = this;
                employee.FormClosed += Employee_FormClosed;
                employee.Show();
            }
            else
            {
                employee.Activate();
            }
        }

        private void Employee_FormClosed(object sender, FormClosedEventArgs e)
        {
            employee = null;
        }
        CategoryCount catCount;
        private void бройКатегорииИБройНаАртикулитеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (catCount == null)
            {
                catCount = new CategoryCount();
                catCount.MdiParent = this;
                catCount.FormClosed += CatCount_FormClosed;
                catCount.Show();
            }
            else
            {
                catCount.Activate();
            }
        }

        private void CatCount_FormClosed(object sender, FormClosedEventArgs e)
        {
            catCount = null;
        }

        Orders order;
        private void продажбиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (order == null)
            {
                order = new Orders();
                order.MdiParent = this;
                order.FormClosed += Order_FormClosed;
                order.Show();
            }
            else
            {
                order.Activate();
            }
        }

        private void Order_FormClosed(object sender, FormClosedEventArgs e)
        {
            order = null;
        }

        ImportData import;
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (import == null)
            {
                import = new ImportData();
                import.MdiParent = this;
                import.FormClosed += Import_FormClosed;
                import.Show();
            }
            else
            {
                import.Activate();
            }

        }

        private void Import_FormClosed(object sender, FormClosedEventArgs e)
        {
            import = null;
        }

        ExportData export;
        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (export == null)
            {
                export = new ExportData();
                export.MdiParent = this;
                export.FormClosed += Export_FormClosed;
                export.Show();
            }
            else
            {
                export.Activate();
            }
        }

        private void Export_FormClosed(object sender, FormClosedEventArgs e)
        {
            export = null;
        }

    }
}
