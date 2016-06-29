using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Office.Interop.Excel;

namespace CCR
{
    public class LauraJanelleDSR
    {
        string connectionString = "Data Source=srv-swdb;Initial Catalog=swdb;Persist Security Info=True;User ID=swdb;Password=SouthWare99";
        public void GenerateReport()
        {
            System.Data.DataTable dt = GetData.ExecuteQuery(@"select customernumber as 'Customer Number', billtoname as 'Customer Name', ordernumber as 'Order ID', ponumber as 'Customer PO', productcategory as 'Product purchased', salespersonname as 'Sales Rep', ManagerName as 'Sales Manager', orderdate as 'Order Date', totalprice as 'Order Amount' from( 
                                                select  b.customernumber, 
                                                        b.billtoname,
				                                        b.ordernumber,
				                                        b.ponumber,
				                                        a.productcategory,
				                                        d.salespersonname,
				                                        c.ManagerName,
				                                        b.orderdate,
				                                        b.totalprice 
                                                from SWCCSBIL2 a 
                                                join SWCCSBIL1 b on b.ordernumber = a.ordernumber
		                                        left join IvystoneSalesPeople c on c.SalesPersonNumber = b.salesperson
		                                        left join SWCCRSMAN d on d.salespersonnumber = b.salesperson                            
                                                where b.locationnumber = '800' and orderdate > '6/20/2016'             
		              
                                                UNION
		 
                                                select  b.customernumber,
				                                        b.billtoname,
                                                        b.ordernumber,
				                                        b.customerponumber,
				                                        a.category,
				                                        d.salespersonname,
				                                        c.ManagerName,
				                                        b.orderdate,
				                                        b.totalprice
                                                from SWCCSHST2 a 
                                                join SWCCSHST1 b on a.invoicenumber = b.invoicenumber            
		                                        left join IvystoneSalesPeople c on c.SalesPersonNumber = b.salespersonnumber                
		                                        left join SWCCRSMAN d on d.salespersonnumber = b.salespersonnumber
                                                where b.locationnumber = '800' and orderdate > '6/20/2016') x 
		                                        where totalprice > 0 
                                                group by customernumber, billtoname, ordernumber, ponumber, productcategory, salespersonname, ManagerName, orderdate, totalprice
		                                        order by ordernumber", connectionString);

            dt.Columns.Add("Weekly Total");
            // intialize variables to get categorys in the same column and get a weekly total
            string orderIndex = dt.Rows[0][2].ToString();
            string catColumn = dt.Rows[0][4].ToString();
            bool endOfWeek = false;
            double weeklyTotal = Convert.ToDouble(dt.Rows[0][8]);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DateTime dateIndex = Convert.ToDateTime(dt.Rows[i][7]);
                // if the current row is a new order number
                if (orderIndex != dt.Rows[i][2].ToString())
                {
                    weeklyTotal += Convert.ToDouble(dt.Rows[i][8]);
                    orderIndex = dt.Rows[i][2].ToString();
                    dt.Rows[i - 1][4] = catColumn;
                    catColumn = dt.Rows[i][4].ToString();
                    if (i + 1 < dt.Rows.Count)
                    {
                        // if the next row is a duplicate row erase cat column for easy delete index
                        if (orderIndex == dt.Rows[i + 1][2].ToString())
                        {
                            dt.Rows[i][4] = "";
                        }
                    }
                }
                else
                {
                    // if row is duplicate store the category in the index to be insantiated later
                    catColumn += ", " + dt.Rows[i][4].ToString();
                    dt.Rows[i][4] = "";
                }
                if (i + 1 < dt.Rows.Count)
                {
                    // calculate the weekly total
                    if (dateIndex.DayOfWeek > Convert.ToDateTime(dt.Rows[i + 1][7]).DayOfWeek)
                    {
                        endOfWeek = true;
                    }
                    if (endOfWeek == true && Convert.ToDateTime(dt.Rows[i + 1][7]).DayOfWeek == DayOfWeek.Monday)
                    {
                        dt.Rows[i][9] = weeklyTotal.ToString("c");
                        weeklyTotal = 0;
                        endOfWeek = false;
                    }
                }
                else
                {
                    dt.Rows[i][9] = weeklyTotal.ToString("c");
                }
            }
            // clean up extra rows created by the cat column
            for (int i = dt.Rows.Count - 1; i > -1; i--)
            {
                if (dt.Rows[i][4].ToString() == "")
                {
                    dt.Rows.Remove(dt.Rows[i]);
                }
            }

            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Workbooks.Add();

            // single worksheet
            Microsoft.Office.Interop.Excel._Worksheet workSheet = excelApp.ActiveSheet;

            // column headings
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                workSheet.Cells[1, (i + 1)] = dt.Columns[i].ColumnName;
            }
            // rows
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                 // to do: format datetime values before printing and change order amount column to currancy
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    workSheet.Cells[(i + 2), (j + 1)] = dt.Rows[i][j];
                }
            }

            workSheet.Columns.AutoFit();
            Microsoft.Office.Interop.Excel.Range range = workSheet.Range["A1", "J" + (dt.Rows.Count + 1)];
            Object missing = System.Reflection.Missing.Value;
            workSheet.ListObjects.AddEx(XlListObjectSourceType.xlSrcRange, range, missing, Microsoft.Office.Interop.Excel.XlYesNoGuess.xlYes, missing).Name = "MyTableStyle";
            workSheet.ListObjects.get_Item("MyTableStyle").TableStyle = "TableStyleMedium2";
            excelApp.Visible = true;

        }
    }
}
