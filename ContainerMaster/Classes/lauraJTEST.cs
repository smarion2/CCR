using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Office.Interop.Excel;

namespace CCR
{
    class lauraJTEST
    {
        string connectionString = "Data Source=srv-swdb;Initial Catalog=swdb;Persist Security Info=True;User ID=swdb;Password=SouthWare99";
        System.Data.DataTable orders;
        System.Data.DataTable invoices;
        public void FirstPage()
        {
            orders = GetData.ExecuteQuery(@"select      b.customernumber as 'Customer Number', 
                                                        b.billtoname as 'Customer Name',
				                                        b.ordernumber as 'Order ID',
				                                        b.ponumber as 'Customer PO',
				                                        a.productcategory as 'Product purchased',
									                    f.termsdescription as 'Payment Method',
				                                        d.salespersonname as 'Sales Rep',
				                                        c.ManagerName as 'Sales Manager',
				                                        b.orderdate as 'Order Date',
				                                        b.totalprice as 'Order Amount',
									                    b.usercomment as 'Sales Location',
									                    b.shippingdate as 'Date Shipped',
									                    e.trackingnumber as 'Tracking Number'														 
                                            from SWCCSBIL2 a 
                                            join SWCCSBIL1 b on b.ordernumber = a.ordernumber
							                left join SWCCSSBOX e on a.ordernumber = e.externalnumber and e.trackingnumber != ''
							                left join SWCCATERM f on f.termscode = b.termscode
		                                    left join IvystoneSalesPeople c on c.SalesPersonNumber = b.salesperson
		                                    left join SWCCRSMAN d on d.salespersonnumber = b.salesperson                            
                                            where b.locationnumber = '800' and orderdate > '6/1/2016' and totalprice > 0
											group by b.customernumber, billtoname, b.ordernumber, ponumber, productcategory, salespersonname, ManagerName, orderdate, 
														totalprice, termsdescription, usercomment, trackingnumber, b.shippingdate
                                            order by b.ordernumber", connectionString);

            invoices = GetData.ExecuteQuery(@"select    b.customernumber as 'Customer Number',
				                                        b.billtoname as 'Customer Name',
                                                        b.ordernumber as 'Order ID',
                                                        b.invoicenumber,
				                                        b.customerponumber as 'Customer PO',
				                                        a.category as 'Product purchased',
														f.termsdescription as 'Payment Method',
				                                        d.salespersonname as 'Sales Rep',
				                                        c.ManagerName as 'Sales Manager',
				                                        b.orderdate as 'Order Date',
				                                        b.totalprice as 'Order Amount',
														b.usercomment as 'Sales Location',
														b.dateshipped as 'Date Shipped',
														e.trackingnumber as 'Tracking Number'
                                            from SWCCSHST2 a 
                                            join SWCCSHST1 b on a.invoicenumber = b.invoicenumber    
											left join SWCCSSBOX e on a.invoicenumber = e.externalnumber
									        left join SWCCATERM f on f.termscode = b.termscode        
		                                    left join IvystoneSalesPeople c on c.SalesPersonNumber = b.salespersonnumber                
		                                    left join SWCCRSMAN d on d.salespersonnumber = b.salespersonnumber
                                            where b.locationnumber = '800' and orderdate > '6/1/2016' and totalprice > 0
											group by b.customernumber, billtoname, ordernumber, customerponumber, category, salespersonname, ManagerName, orderdate, 
														termsdescription, usercomment, dateshipped, trackingnumber, shippingdate, b.invoicenumber, b.totalprice
                                            order by b.invoicenumber desc", connectionString);

            System.Data.DataTable finalDoc = new System.Data.DataTable();
            foreach (DataColumn column in orders.Columns)
            {
                finalDoc.Columns.Add(column.ColumnName, column.DataType);
            }


            // group category column from Sales orders THANKS RICK!!!
            string orderIndex = string.Empty;
            foreach(DataRow row in orders.Rows)
            {
                if (row["Order ID"].ToString() == orderIndex)
                {
                    finalDoc.Rows[finalDoc.Rows.Count - 1]["Product purchased"] += ", " + row["Product purchased"].ToString();
                }
                else
                {
                    finalDoc.ImportRow(row);
                }
                orderIndex = row["Order ID"].ToString();
            }

            // now do the same with the invoices
            string invoiceIndex = string.Empty;
            foreach (DataRow row in invoices.Rows)
            {
                if (row["Order ID"].ToString() == orderIndex)
                {
                    finalDoc.Rows[finalDoc.Rows.Count - 1]["Product purchased"] += ", " + row["Product purchased"].ToString();
                    if (row["invoicenumber"].ToString() != invoiceIndex)
                    {
                        finalDoc.Rows[finalDoc.Rows.Count - 1]["Order Amount"] = Convert.ToDouble(finalDoc.Rows[finalDoc.Rows.Count - 1]["Order Amount"]) + Convert.ToDouble(row["Order Amount"]);
                    }
                }

                else
                {
                    finalDoc.ImportRow(row);
                }
                orderIndex = row["Order ID"].ToString();
                invoiceIndex = row["invoicenumber"].ToString();
            }

            // Create dataview to sort by date for doing the weekly tables
            DataView dv = finalDoc.DefaultView;
            dv.Sort = "[Order Date] ASC";
            finalDoc = null;
            finalDoc = dv.ToTable();
            finalDoc.Columns.Add("Weekly Total").SetOrdinal(10);
            // calculate weekly totals
            bool endOfWeek = false;
            double weeklyTotal = 0;
            for (int i = 0; i < finalDoc.Rows.Count; i++)
            {
                weeklyTotal += Convert.ToDouble(finalDoc.Rows[i]["Order Amount"]);
                DateTime dateIndex = Convert.ToDateTime(finalDoc.Rows[i]["Order Date"]);
                if (i + 1 < finalDoc.Rows.Count)
                {
                    // calculate the weekly total
                    if (dateIndex.DayOfWeek > Convert.ToDateTime(finalDoc.Rows[i + 1]["Order Date"]).DayOfWeek)
                    {
                        endOfWeek = true;
                    }
                    if (endOfWeek == true && Convert.ToDateTime(finalDoc.Rows[i + 1]["Order Date"]).DayOfWeek == DayOfWeek.Monday)
                    {
                        finalDoc.Rows[i]["Weekly Total"] = weeklyTotal.ToString("c");
                        weeklyTotal = 0;
                        endOfWeek = false;
                    }
                }
                else
                {
                    finalDoc.Rows[i]["Weekly Total"] = weeklyTotal.ToString("c");
                }
            }

            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Workbooks.Add();
            //var collection = new Microsoft.Office.Interop.Excel.Worksheet[2];

            // single worksheet
            Microsoft.Office.Interop.Excel._Worksheet workSheet1 = excelApp.ActiveSheet;

            // column headings
            for (int i = 0; i < finalDoc.Columns.Count; i++)
            {
                workSheet1.Cells[1, (i + 1)] = finalDoc.Columns[i].ColumnName;
            }
            // rows
            for (int i = 0; i < finalDoc.Rows.Count; i++)
            {
                // to do: format datetime values before printing and change order amount column to currancy
                for (int j = 0; j < finalDoc.Columns.Count; j++)
                {
                    workSheet1.Cells[(i + 2), (j + 1)] = finalDoc.Rows[i][j];
                }
            }

            workSheet1.Columns.AutoFit();
            Microsoft.Office.Interop.Excel.Range range = workSheet1.Range["A1", "O" + (finalDoc.Rows.Count + 1)];
            Object missing = System.Reflection.Missing.Value;
            workSheet1.ListObjects.AddEx(XlListObjectSourceType.xlSrcRange, range, missing, Microsoft.Office.Interop.Excel.XlYesNoGuess.xlYes, missing).Name = "MyTableStyle";
            workSheet1.ListObjects.get_Item("MyTableStyle").TableStyle = "TableStyleMedium2";

            excelApp.Visible = true;
            excelApp.Quit();

        }
    }
}
