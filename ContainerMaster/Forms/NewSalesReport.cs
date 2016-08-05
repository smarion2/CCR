using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace CCR
{
    public partial class NewSalesReport : Form
    {
        public NewSalesReport()
        {
            InitializeComponent();
        }

        string connectionString = "Data Source=srv-swdb;Initial Catalog=swdb;Persist Security Info=True;User ID=swdb;Password=SouthWare99";
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime fromDate = fromDateTimePicker.Value;
            DateTime toDate = toDateTimePicker.Value;



            DataTable dt = GetData.ExecuteQuery(@"select billtoname, sum(quantitytoship) as 'UnitsShipped', sum(unitprice) as 'UnitsShippedPrice', category
                                                    from SWCCSHST2 a
                                                    join SWCCSHST1 b on a.invoicenumber = b.invoicenumber
                                                    where b.invoicedate between @0 and @1
                                                    group by billtoname, category
                                                    order by 1", connectionString, fromDate.ToString(), toDate.ToString());

            foreach(DataRow row in dt.Rows)
            {
                row[0] = "\"" + row[0].ToString() + "\"";
            }

            DataTableToExcel.ExportToExcel(dt);
        }
    }
}
