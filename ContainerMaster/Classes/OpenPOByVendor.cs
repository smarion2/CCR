using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CCR
{
    class OpenPOByVendor
    {
        string connectionString = "Data Source=srv-swdb;Initial Catalog=swdb;Persist Security Info=True;User ID=swdb;Password=SouthWare99";
        public void CreateReport()
        {
            DataTable dt = GetData.ExecuteQuery(@"    select * from(
	                                                  SELECT        LTRIM(SWCCSPO2.ponumber) AS 'PO Number', RTRIM(SWCCSPO2.stocknumber) as 'Item Number', CONVERT(VARCHAR(10),SWCCSPO1.dateordered,110) as 'Date Ordered', CONVERT(VARCHAR(10),SWCCSPO2.requestedshipdate,110) as 'Required Ship Date', CONVERT(VARCHAR(10),SWCCSPO2.expectedshipdate,110) as 'Expected Date', 
				                                                SWCCSPO2.descline1 as 'Description', SWCCSPO2.vendornumber as 'Vendor', SWCCSPO2.orderquantity - SWCCSPO2.receivedtodateqty - SWCCSPO2.cancelledqty - (select isnull(sum(ab.ItemQty), 0) 
				                                                from CM_Data ab join CM_Details bc on ab.CMID = bc.CMID where ab.ItemNumber = SWCCSPO2.stocknumber and ab.PONumber = LTRIM(SWCCSPO2.ponumber) and Delivered is null) as 'Balance due', 				
				                                                SWCCSPO1.comments as 'PO Comments'              
                                                        FROM            SWCCSPO2 
                                                        JOIN SWCCSPO1 ON SWCCSPO1.ponumber = SWCCSPO2.ponumber 
                                                        LEFT JOIN SWCCSSTOK ON SWCCSSTOK.stocknumber = SWCCSPO2.stocknumber and SWCCSSTOK.locationnumber in ('900','800') 
                                                        LEFT JOIN SWCCSX005 ON SWCCSX005.stocknumber = SWCCSPO2.stocknumber and SWCCSX005.locationnumber in ('900','800')
                                                        Left JOIN SWCCXD078 ON SWCCXD078.stocknumber = SWCCSX005.stocknumber and (SWCCXD078.locationnumber in ('900','800'))
                                                        join SWCCAVEND on SWCCAVEND.vendornumber = SWCCSPO2.vendornumber and SWCCAVEND.userflag_1 = '1'
                                                        WHERE        (SWCCSPO1.status = 'O') 

                                                        group by SWCCSPO2.ponumber, SWCCSPO1.dateordered, SWCCSPO1.shipdate, SWCCSPO1.comments, SWCCSPO2.stocknumber, SWCCSPO2.expectedshipdate, SWCCSPO2.requestedshipdate, 
                                                                                 SWCCSPO2.descline1, SWCCSPO2.vendornumber, SWCCXD078.innerpkselunt, SWCCSSTOK.productcategory, SWCCSSTOK.quantityonhand, SWCCSX005.upc, 
                                                                                 SWCCSSTOK.locationnumber, SWCCSPO2.orderquantity, SWCCSPO2.receivedtodateqty, SWCCSPO2.cancelledqty
                                                        ) as innertable
                                                        where [Balance due] > 0 
                                                        ORDER BY [Item Number], [PO Number]", connectionString);

            DataTableToExcel.ExportToExcel(dt);



        }
    }
}
