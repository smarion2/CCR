using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Windows.Forms;
using LumenWorks.Framework.IO.Csv;
using System.Data.SqlClient;

namespace CCR
{
    class FixWMASN
    {
        string ediConnectionString = "Data Source=srv-edi;Initial Catalog=ediengine;Persist Security Info=True;User ID=swdb;Password=SouthWare99";
        public void Fix()
        { 
            DataTable csvTable = new DataTable("cmdata");
            OpenFileDialog openFileDialog = new OpenFileDialog();
            var dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string extension = Path.GetExtension(filePath);

                using (CsvReader csv = new CsvReader(
                                       new StreamReader(filePath), true))
                {
                    csvTable.Load(csv);
                    // count records and insert unique key to each row
                    foreach (DataRow row in csvTable.Rows)
                    {
                        try
                        {
                            using (SqlConnection con = new SqlConnection(ediConnectionString))
                            {
                                con.Open();
                                using (SqlCommand command = new SqlCommand(@"   delete b
                                                                                from OUT_856_LIN b
                                                                                join OUT_856_ORD a on a.TRANNO = b.TRANNO and a.ORDSEQNO = b.ORDSEQNO
                                                                                where PONO = '" + row[0] + "' and BUYERSKU = '" + row[1] + "'", con))
                                {
                                    command.ExecuteNonQuery();
                                }
                                con.Close();
                            }
                        }
                        catch (SystemException ex)
                        {
                            MessageBox.Show(string.Format("An error occurred: {0}", ex.Message));
                        }
                    }
                }
             }
        }
    }
}
