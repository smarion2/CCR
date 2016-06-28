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
        // datatables for tab 1
        DataTable top5DT;
        DataTable salesDT;
        DataTable custDT;
        // start datatables for tab 2
        DataTable catDT;
        DataTable barChartDT;
        string salesQuery = @"  select top 5 salespersonname as 'Sales Person', sum(totalprice) as 'Sales Amount'
                                    from SWCCSBIL1 a
                                    join SWCCRSMAN b on a.salesperson = b.salespersonnumber
                                    where locationnumber = '800' and salesperson != 'ZZZ'
                                    group by salesperson, salespersonname
                                    order by 2 desc";
        private void LauraJanelleForm_Load(object sender, EventArgs e)
        {
            top5DT = GetData.ExecuteQuery(@"select top 5 itemidstocksvc as 'Stock Number', lineitemdesc1 as 'Desc', sum(unitprice - unitcost) as 'Gross Amount'
                                              from SWCCSBIL2
                                              where locationnumber = '800'
                                              group by itemidstocksvc, lineitemdesc1
                                              order by 3 desc", connectionString);


            catDT = GetData.ExecuteQuery(@"  select productcategory as 'Category', count(1) as 'sum'
                                              from SWCCSBIL2
                                              where locationnumber = '800'
                                              group by productcategory
                                              order by 2 desc", connectionString);

            barChartDT = GetData.ExecuteQuery(@"select orderdate as 'Order Date', sum(totalprice) as 'Total Sales' from( 
                                                    select  b.orderdate, 
				                                            sum(b.totalprice) as totalprice
                                                    from SWCCSBIL1 b                   
                                                    where b.locationnumber = '800'             
		                                            group by orderdate		              

                                                    UNION all		 

                                                    select b.orderdate,
				                                            sum(b.totalprice) as totalprice				
                                                    from SWCCSHST1 b           
                                                    where b.locationnumber = '800'
		                                            group by b.orderdate) x 
                                            where totalprice > 0
                                            group by orderdate
                                            order by 1 ", connectionString);

            custDT = GetData.ExecuteQuery(@"select customernumber as 'Customer Number', billtoname as 'Customer Name', sum(totalprice) as 'Total Sales' from( 
                                            select  b.customernumber, 
                                                    b.billtoname,
				                                    sum(b.totalprice) as totalprice
                                            from SWCCSBIL2 a 
                                            join SWCCSBIL1 b on b.ordernumber = a.ordernumber                         
                                            where b.locationnumber = '800'             
		                                    group by customernumber, billtoname
		              
                                            UNION
		 
                                            select b.customernumber,
				                                    b.billtoname,			
				                                    sum(b.totalprice) as totalprice
                                            from SWCCSHST2 a 
                                            join SWCCSHST1 b on a.invoicenumber = b.invoicenumber            
                                            where b.locationnumber = '800'
		                                    group by b.customernumber, billtoname) x 
		                                    where totalprice > 0
                                            group by customernumber, billtoname
		                                    order by 3 desc", connectionString);

            salesDT = GetData.ExecuteQuery(salesQuery, connectionString);

            salesDataGridView.RowHeadersVisible = false;
            salesDataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            salesDataGridView.DataSource = salesDT;
            top5GridView.RowHeadersVisible = false;
            top5GridView.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            top5GridView.DataSource = top5DT;
            topCustDataGridView.RowHeadersVisible = false;
            topCustDataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            topCustDataGridView.DataSource = custDT;

            top5GridView.Columns[2].DefaultCellStyle.Format = "c";
            salesDataGridView.Columns[1].DefaultCellStyle.Format = "c";
            topCustDataGridView.Columns[2].DefaultCellStyle.Format = "c";

            // fill the pie chart
            int catSum = Convert.ToInt32(catDT.Compute("Sum(sum)", "sum > 0"));
            int pointIndex = 0;
            foreach (DataRow row in catDT.Rows)
            {
                
                double value = Convert.ToDouble(row[1]);                     
                catPieChart.Series[0].Points.Add(value);
                var point = catPieChart.Series[0].Points[pointIndex];
                //point.AxisLabel = row[0].ToString();
                point.LegendText = string.Format("{0} {1:0}%", row[0].ToString(), value/catSum * 100);
                pointIndex++;
            }

            // fill the bar chart
            int salesChartIndex = 0;
            salesBarChart.Series[0].IsVisibleInLegend = false;
            foreach (DataRow row in barChartDT.Rows)
            {
                double value = Convert.ToDouble(row[1]);
                salesBarChart.Series[0].Points.Add(value);
                var point = salesBarChart.Series[0].Points[salesChartIndex];
                DateTime date = (DateTime)row[0];
                point.AxisLabel = date.ToString("MM/dd/yyyy");
                point.LegendText = row[0].ToString();
                point.Label = row[1].ToString();
                salesChartIndex++;
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

        private void salesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (salesDataGridView.SelectedCells.Count > 0)
            {
                int selectedRowIndex = salesDataGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = salesDataGridView.Rows[selectedRowIndex];

                string a = Convert.ToString(selectedRow.Cells["salespersonname"].Value);

                DataTable dt = GetData.ExecuteQuery(@"  select a.ManagerName, Title, Address, Phone, Fax, Cell, Email
                                                          from IvystoneManagers a
                                                          join IvystoneSalesPeople b on a.ManagerName = b.ManagerName
                                                          join SWCCRSMAN c on c.salespersonnumber = b.SalesPersonNumber
                                                          where c.salespersonname = @0", connectionString, a);

                MessageBox.Show("Manager Name: " + dt.Rows[0][0].ToString() + "\r\n" +
                                 "Title: " + dt.Rows[0][1].ToString() + "\r\n" +
                                 "Address: " + dt.Rows[0][2].ToString() + "\r\n" +
                                 "Phone: " + dt.Rows[0][3].ToString() + "\r\n" +
                                 "Fax: " + dt.Rows[0][4].ToString() + "\r\n" + 
                                 "Cell: " + dt.Rows[0][5].ToString() + "\r\n" +
                                 "Email: " + dt.Rows[0][6].ToString());

            }
        }
    }
}
