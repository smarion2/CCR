using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CCR
{
    public class LauraJanelleDSR
    {
        string connectionString = "Data Source=srv-swdb;Initial Catalog=swdb;Persist Security Info=True;User ID=swdb;Password=SouthWare99";
        public void GenerateReport()
        {
            DataTable dt = GetData.ExecuteQuery(@"select customernumber, billtoname, ordernumber, ponumber, productcategory, salespersonname, ManagerName, orderdate, totalprice from( 
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

            string orderIndex = dt.Rows[0][2].ToString();
            string catColumn = dt.Rows[0][4].ToString();
            DateTime orderDate;
            bool endOfWeek;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (orderIndex != dt.Rows[i][2].ToString())
                {
                    orderIndex = dt.Rows[i][2].ToString();
                    dt.Rows[i - 1][4] = catColumn;
                    catColumn = dt.Rows[i][4].ToString();
                }
                else
                {
                    catColumn += ", " + dt.Rows[i][4].ToString();
                    dt.Rows[i][4] = "";
                }
            }
            string test = "";

        }
    }
}
