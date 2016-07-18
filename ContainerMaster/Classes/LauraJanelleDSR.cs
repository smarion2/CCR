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

            System.Data.DataTable itemDT = GetData.ExecuteQuery(@"select a.stocknumber, a.stockdescription1, a.quantityonhand, a.orderynpdxam, a.productcategory, categorydescription
                                                                  from SWCCSSTOK a
                                                                  join SWCCSCATG b on a.productcategory = b.categorycode and b.locationnumber = '800'
                                                                  where a.locationnumber = '800'", connectionString);

            System.Data.DataTable dateDT = GetData.ExecuteQuery(@"select itemidstocksvc, qty, orderdate from(
                                                                            select itemidstocksvc, sum(quantityordered) as 'qty', orderdate
                                                                            from SWCCSBIL2 a    
                                                                            join SWCCSBIL1 b on b.ordernumber = a.ordernumber                                                              
                                                                            where a.locationnumber = '800' and orderdate > '6/1/2016'
                                                                            group by itemidstocksvc, orderdate
                                                                            UNION
                                                                            select itemidstocksvc, sum(quantityordered) as 'qty', orderdate 
                                                                            from SWCCSHST2 a
		                                                                    join SWCCSHST1 b on a.invoicenumber = b.invoicenumber
                                                                            where a.locationnumber = '800' and orderdate > '6/1/2016'
                                                                            group by itemidstocksvc, orderdate) x
                                                                            order by 3", connectionString);

            System.Data.DataTable dt = GetData.ExecuteQuery(@"select customernumber as 'Customer Number', billtoname as 'Customer Name', ordernumber as 'Order ID', ponumber as 'Customer PO', salespersonname as 'Sales Rep', ManagerName as 'Sales Manager', 
                                                            productcategory as 'Product purchased', termsdescription as 'Payment Method', '' as 'Credit ap received', orderdate as 'Order Date', 
			                                                totalprice as 'Order Amount', usercomment as 'Sales Location', trackingnumber as 'Tracking Number', shippingdate as 'Date Shipped' from( 
                                                select  b.customernumber, 
                                                        b.billtoname,
				                                        b.ordernumber,
				                                        b.ponumber,
				                                        a.productcategory,
														f.termsdescription,
				                                        d.salespersonname,
				                                        c.ManagerName,
				                                        b.orderdate,
				                                        b.totalprice,
														b.usercomment,
														b.shippingdate,
														e.trackingnumber														 
                                                from SWCCSBIL2 a 
                                                join SWCCSBIL1 b on b.ordernumber = a.ordernumber
												left join SWCCSSBOX e on a.ordernumber = e.externalnumber and e.trackingnumber != ''
												left join SWCCATERM f on f.termscode = b.termscode
		                                        left join IvystoneSalesPeople c on c.SalesPersonNumber = b.salesperson
		                                        left join SWCCRSMAN d on d.salespersonnumber = b.salesperson                            
                                                where b.locationnumber = '800' and orderdate > '6/1/2016' and totalprice > 0          
		              
                                                UNION ALL
		 
                                                select  b.customernumber,
				                                        b.billtoname,
                                                        b.ordernumber,
				                                        b.customerponumber,
				                                        a.category,
														f.termsdescription,
				                                        d.salespersonname,
				                                        c.ManagerName,
				                                        b.orderdate,
				                                        b.totalprice,
														b.usercomment,
														b.dateshipped as shippingdate,
														e.trackingnumber
                                                from SWCCSHST2 a 
                                                join SWCCSHST1 b on a.invoicenumber = b.invoicenumber    
												left join SWCCSSBOX e on a.invoicenumber = e.externalnumber
									            left join SWCCATERM f on f.termscode = b.termscode        
		                                        left join IvystoneSalesPeople c on c.SalesPersonNumber = b.salespersonnumber                
		                                        left join SWCCRSMAN d on d.salespersonnumber = b.salespersonnumber
                                                where b.locationnumber = '800' and orderdate > '6/1/2016' and totalprice > 0) x 
                                                group by customernumber, billtoname, ordernumber, ponumber, productcategory, salespersonname, ManagerName, orderdate, 
														totalprice, termsdescription, usercomment, trackingnumber, shippingdate
                                        
		                                        order by ordernumber", connectionString);

            dt.Columns.Add("Weekly Total").SetOrdinal(10);
            // intialize variables to get categorys in the same column and get a weekly total
            string orderIndex = dt.Rows[0]["Order Id"].ToString();
            string catColumn = dt.Rows[0]["Product purchased"].ToString();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                // if the current row is a new order number
                if (orderIndex != dt.Rows[i]["Order Id"].ToString())
                {
                    orderIndex = dt.Rows[i]["Order Id"].ToString();
                    dt.Rows[i - 1]["Product purchased"] = catColumn;
                    catColumn = dt.Rows[i]["Product purchased"].ToString();
                    if (i + 1 < dt.Rows.Count)
                    {
                        // if the next row is a duplicate row erase cat column for easy delete index
                        if (orderIndex == dt.Rows[i + 1]["Order Id"].ToString())
                        {
                            dt.Rows[i]["Product purchased"] = "";
                        }
                    }
                }
                else
                {
                    // if row is duplicate store the category in the index to be insantiated later
                    catColumn += ", " + dt.Rows[i]["Product purchased"].ToString();
                    dt.Rows[i]["Product purchased"] = "";                    
                }
                dt.Rows[dt.Rows.Count - 1]["Product purchased"] = catColumn;
            }            
            // clean up extra rows created by the cat column
            for (int i = dt.Rows.Count - 1; i > -1; i--)
            {
                if (dt.Rows[i]["Product purchased"].ToString() == "")
                {
                    dt.Rows.Remove(dt.Rows[i]);
                }
            }

            // calculate weekly totals
            bool endOfWeek = false;
            double weeklyTotal = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                weeklyTotal += Convert.ToDouble(dt.Rows[i]["Order Amount"]);
                DateTime dateIndex = Convert.ToDateTime(dt.Rows[i]["Order Date"]);
                if (i + 1 < dt.Rows.Count)
                {
                    // calculate the weekly total
                    if (dateIndex.DayOfWeek > Convert.ToDateTime(dt.Rows[i + 1]["Order Date"]).DayOfWeek)
                    {
                        endOfWeek = true;
                    }
                    if (endOfWeek == true && Convert.ToDateTime(dt.Rows[i + 1]["Order Date"]).DayOfWeek == DayOfWeek.Monday)
                    {
                        dt.Rows[i]["Weekly Total"] = weeklyTotal.ToString("c");
                        weeklyTotal = 0;
                        endOfWeek = false;
                    }
                }
                else
                {
                    dt.Rows[i]["Weekly Total"] = weeklyTotal.ToString("c");
                }
            }

            // Start 2nd sheet data manipulation
            // Get distinct Dates to create columns on itemDT
            var distinctDate = dateDT.AsEnumerable().Select(row => new
            {
                orderdate = row.Field<DateTime>("orderdate")
            }).Distinct();

            foreach (var row in distinctDate)
            {
                itemDT.Columns.Add(row.orderdate.ToString("d"));
            }

            for (int r = 0; r < itemDT.Rows.Count; r++)
            {
                for (int drow = 0; drow < dateDT.Rows.Count; drow++)
                {
                    for (int c = 6; c < itemDT.Columns.Count; c++)
                    {
                        string itemDTnum = itemDT.Rows[r][0].ToString();
                        string dateDTnum = dateDT.Rows[drow][0].ToString();
                        string column = itemDT.Columns[c].ColumnName;
                        string dateDTcol = Convert.ToDateTime(dateDT.Rows[drow][2]).ToString("d");

                        if (itemDTnum == dateDTnum && column == dateDTcol)
                        {
                            itemDT.Rows[r][c] = Convert.ToInt32(dateDT.Rows[drow][1]);
                        }
                    }
                }
            }

            DataRow totalRow = itemDT.NewRow();
            totalRow[5] = "Totals:";
            float colTotal = 0;
            for (int c = 6; c < itemDT.Columns.Count; c++)
            {
                foreach (DataRow row in itemDT.Rows)
                {
                    if (row[c] != DBNull.Value)
                        colTotal += Convert.ToInt32(row[c]);
                }
                totalRow[c] = colTotal;
                colTotal = 0;
            }

            itemDT.Rows.Add(totalRow);
            float rowTotal = 0;
            itemDT.Columns.Add("Totals:");
            for (int r = 1; r < itemDT.Rows.Count; r++)
            {
                for (int c = 6; c < itemDT.Columns.Count - 1; c++)
                {
                    if (itemDT.Rows[r][c] != DBNull.Value)
                    {
                        rowTotal += Convert.ToInt32(itemDT.Rows[r][c]);
                    }
                    itemDT.Rows[r]["Totals:"] = rowTotal;
                }
                rowTotal = 0;
            }

            string test = string.Empty;

            // ITS EXCEL TIME!!!!
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Workbooks.Add();
            //var collection = new Microsoft.Office.Interop.Excel.Worksheet[2];

            // single worksheet
            Microsoft.Office.Interop.Excel._Worksheet workSheet1 = excelApp.ActiveSheet;

            // column headings
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                workSheet1.Cells[1, (i + 1)] = dt.Columns[i].ColumnName;
            }
            // rows
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                // to do: format datetime values before printing and change order amount column to currancy
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    workSheet1.Cells[(i + 2), (j + 1)] = dt.Rows[i][j];
                }
            }

            workSheet1.Columns.AutoFit();
            Microsoft.Office.Interop.Excel.Range range = workSheet1.Range["A1", "O" + (dt.Rows.Count + 1)];
            Object missing = System.Reflection.Missing.Value;
            workSheet1.ListObjects.AddEx(XlListObjectSourceType.xlSrcRange, range, missing, Microsoft.Office.Interop.Excel.XlYesNoGuess.xlYes, missing).Name = "MyTableStyle";
            workSheet1.ListObjects.get_Item("MyTableStyle").TableStyle = "TableStyleMedium2";

            Microsoft.Office.Interop.Excel.Worksheet workSheet2;
            workSheet2 = excelApp.Worksheets.Add(
                            missing, missing, missing, missing);

            workSheet2 = excelApp.ActiveSheet;
            workSheet2.Move(After: excelApp.Sheets[excelApp.Sheets.Count]);
            for (int i = 0; i < itemDT.Columns.Count; i++)
            {
                workSheet2.Cells[1, (i + 1)] = itemDT.Columns[i].ColumnName;
            }
            // rows
            for (int i = 0; i < itemDT.Rows.Count; i++)
            {
                // to do: format datetime values before printing and change order amount column to currancy
                for (int j = 0; j < itemDT.Columns.Count; j++)
                {
                    workSheet2.Cells[(i + 2), (j + 1)] = itemDT.Rows[i][j];
                }
            }

            Range range2 = workSheet2.Range["A1", GetColumnName(itemDT.Columns.Count - 1) + (itemDT.Rows.Count + 1)];
            workSheet2.ListObjects.AddEx(XlListObjectSourceType.xlSrcRange, range2, missing, Microsoft.Office.Interop.Excel.XlYesNoGuess.xlYes, missing).Name = "MyTableStyle2";
            workSheet2.ListObjects.get_Item("MyTableStyle2").TableStyle = "TableStyleLight21";
            excelApp.Visible = true;

        }

        // wowey zowey this is neato!
        public string GetColumnName(int index)
        {
            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            var value = "";

            if (index >= letters.Length)
                value += letters[index / letters.Length - 1];

            value += letters[index % letters.Length];

            return value;
        }
    }
}
