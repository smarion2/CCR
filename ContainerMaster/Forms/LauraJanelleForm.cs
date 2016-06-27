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
    public partial class LauraJanelleForm : Form
    {
        string connectionString = "Data Source=srv-swdb;Initial Catalog=swdb;Persist Security Info=True;User ID=swdb;Password=SouthWare99";
        public LauraJanelleForm()
        {
            InitializeComponent();
        }

        DataTable top5DT;
        DataTable catDT;
        DataTable salesDT;
        string salesQuery = @"  select top 5 salespersonname, sum(totalprice) as 'Sales Amount'
                                    from SWCCSBIL1 a
                                    join SWCCRSMAN b on a.salesperson = b.salespersonnumber
                                    where locationnumber = '800' and salesperson != 'ZZZ'
                                    group by salesperson, salespersonname
                                    order by 2 desc";
        private void LauraJanelleForm_Load(object sender, EventArgs e)
        {
            top5DT = GetData.ExecuteQuery(@"select top 5 itemidstocksvc as 'Stock Number', lineitemdesc1 as 'Desc', round(sum(unitprice - unitcost), 2) as 'Gross Amount'
                                              from SWCCSBIL2
                                              where locationnumber = '800'
                                              group by itemidstocksvc, lineitemdesc1
                                              order by 3 desc", connectionString);

            catDT = GetData.ExecuteQuery(@"  select productcategory as 'Category', count(1) as 'sum'
                                              from SWCCSBIL2
                                              where locationnumber = '800'
                                              group by productcategory
                                              order by 2 desc", connectionString);

            salesDT = GetData.ExecuteQuery(salesQuery, connectionString);
            salesDataGridView.DataSource = salesDT;
            top5GridView.DataSource = top5DT;
            int catSum = Convert.ToInt32(catDT.Compute("Sum(sum)", "sum > 0"));
            int pointIndex = 0;
            double value;
            foreach (DataRow row in catDT.Rows)
            {
                value = Convert.ToDouble(row[1]);                     
                catPieChart.Series[0].Points.Add(value);
                var point = catPieChart.Series[0].Points[pointIndex];
                //point.AxisLabel = row[0].ToString();
                point.LegendText = string.Format("{0} {1:0}%", row[0].ToString(), value/catSum * 100);
                pointIndex++;
            }

        }

        private void top5RB_CheckedChanged(object sender, EventArgs e)
        {
            if (top5RB.Checked == false)
                salesQuery = salesQuery.Replace("desc", string.Empty);
            else
                salesQuery += "desc";

            salesDT = GetData.ExecuteQuery(salesQuery, connectionString);
            salesDataGridView.DataSource = salesDT;

        }
    }
}
