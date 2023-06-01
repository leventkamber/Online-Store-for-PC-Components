using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Windows.Forms;

namespace eStore
{
    class Export : Connection
    {
        public DataTable Tab = new DataTable();
        public Export()
        {
            
        }
        public DataTable GetData()
        {
            Tab = base.loadData();
            return Tab;
        }
        public void To_Text()
        {
            try
            {
                string fileName = null;
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "TXT files|* .txt";
                saveFileDialog.FileName = "Components.txt";
                if(saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveFileDialog.FileName;
                }
                using(StreamWriter sw = new StreamWriter(fileName))
                {
                    FileInfo fi = new FileInfo(fileName);
                    StringBuilder sb = new StringBuilder();
                    foreach (DataRow row in Tab.Rows)
                    {
                        for (int i = 0; i < Tab.Columns.Count; i++)
                        {
                            sb.AppendFormat("{0}-", row[i].ToString());
                            
                        }
                        sb.AppendLine("");
                    }
                    sw.WriteLine(sb.ToString());
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Export to Txt Error");
            } 
            
        }
    }
}
