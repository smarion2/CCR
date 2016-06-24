using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCR
{
    public partial class SwarovskiSalesForm : Form
    {
        public SwarovskiSalesForm()
        {
            InitializeComponent();
        }

        private void SwarovskiSalesForm_Load(object sender, EventArgs e)
        {
            this.sWCCSCATGTableAdapter.Fill(this.categoryDS.SWCCSCATG);
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            string fromDate = dateTimePicker1.Text;
            string toDate = dateTimePicker2.Text;
            string cats = string.Empty;
            string location = string.Empty;
            string connectionString = "Data Source=srv-swdb;Initial Catalog=swdb;Persist Security Info=True;User ID=swdb;Password=SouthWare99";
            if (radioButton700.Checked == true)
            {
                location = "700";
            }
            else if (radioButton800.Checked == true)
            {
                location = "800";
            }
            else if (radioButton900.Checked == true)
            {
                location = "900";
            }

            DateTime fD = Convert.ToDateTime(fromDate);
            DateTime tD = Convert.ToDateTime(toDate);

            foreach (DataRowView cat in listBox1.SelectedItems)
            {
                cats += cat[0].ToString() + "\r\n";
            }

            ReportFilters.CatFilter(cats);
            ReportFilters.ItemFilter(ItemFiltertextBox.Text);
            DataTable dt = GetData.ExecuteQuery(@"SELECT  billtoname,
                                           sum(quantitytoship) as 'UnitsShipped',
                                           sum(unitprice * quantitytoship) as 'UnitsShippedPrice',
                                           category
                                   FROM SWCCSHST2 b
                                  join SWCCSHST1 a on a.invoicenumber = b.invoicenumber
                                  where itemidstocksvc in (select Items from ItemFilterTMP) and category in (select Cats from CatFilterTMP) and b.locationnumber = @0 and a.invoicedate >= @1 and a.invoicedate <= @2
                                  group by billtoname, category", connectionString, location, fromDate, toDate);
            ReportFilters.DropTables();
            DataTableToExcel.ExportToExcel(dt);            

        }
    }
}
