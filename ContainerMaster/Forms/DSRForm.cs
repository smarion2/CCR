using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCR
{
    public partial class DSRForm : Form
    {
        public DSRForm()
        {
            InitializeComponent();
        }
        string connectionString = "Data Source=srv-swdb;Initial Catalog=swdb;Persist Security Info=True;User ID=swdb;Password=SouthWare99";
        System.Data.DataTable orders;
        System.Data.DataTable invoices;
        private void DSRForm_Load(object sender, EventArgs e)
        {
            orders = GetData.ExecuteQuery(@"select      b.customernumber as 'Customer Number', 
                                                        b.billtoname as 'Customer Name',
			                                            b.ordernumber as 'Order ID',
			                                            b.ponumber as 'Customer PO',
			                                            d.salespersonname as 'Sales Rep',
			                                            c.ManagerName as 'Sales Manager',
			                                            a.productcategory as 'Product purchased',
			                                            f.termsdescription as 'Payment Method',
			                                            g.CreditAppReceived as 'Credit ap received',
			                                            b.orderdate as 'Order Date',
			                                            b.totalprice as 'Order Amount',
			                                            b.usercomment as 'Sales Location',
			                                            h.Shipped as 'Shipped',
			                                            b.shippingdate as 'Date Shipped',			
			                                            h.Notes as 'Notes',
			                                            h.CSCrep as 'CSC Rep',
			                                            e.trackingnumber as 'Tracking Number'														 
                                        from SWCCSBIL2 a 
                                        join SWCCSBIL1 b on b.ordernumber = a.ordernumber
                                        left join SWCCSSBOX e on a.ordernumber = e.externalnumber and e.trackingnumber != ''
                                        left join SWCCATERM f on f.termscode = b.termscode
                                        left join IvystoneSalesPeople c on c.SalesPersonNumber = b.salesperson
                                        left join SWCCRSMAN d on d.salespersonnumber = b.salesperson
                                        left join LJCreditApp g on g.CustomerNumber = LTRIM(b.customernumber)
                                        left join LJOrderInfo h on h.OrderNumber = b.ordernumber                            
                                        where b.locationnumber = '800' and orderdate > '6/1/2016' and totalprice > 0
                                        group by b.customernumber, billtoname, b.ordernumber, ponumber, productcategory, salespersonname, ManagerName, orderdate, 
			                                        totalprice, termsdescription, usercomment, trackingnumber, b.shippingdate, g.CreditAppReceived, h.Shipped, h.Notes, h.CSCrep
                                        order by b.ordernumber", connectionString);

            invoices = GetData.ExecuteQuery(@"select    b.customernumber as 'Customer Number',
			                                b.billtoname as 'Customer Name',			
                                            b.ordernumber as 'Order ID',
                                            b.invoicenumber,
			                                b.customerponumber as 'Customer PO',
			                                d.salespersonname as 'Sales Rep',
			                                c.ManagerName as 'Sales Manager',
			                                a.category as 'Product purchased',
			                                f.termsdescription as 'Payment Method',
			                                g.CreditAppReceived as 'Credit ap recieved',			
			                                b.orderdate as 'Order Date',
			                                b.totalprice as 'Order Amount',
			                                b.usercomment as 'Sales Location',
			                                h.Shipped as 'Shipped',
			                                b.dateshipped as 'Date Shipped',			
			                                h.Notes as 'Notes',
			                                h.CSCrep as 'CSC Rep',
			                                e.trackingnumber as 'Tracking Number'	
                                from SWCCSHST2 a 
                                join SWCCSHST1 b on a.invoicenumber = b.invoicenumber    
                                left join SWCCSSBOX e on a.invoicenumber = e.externalnumber
                                left join SWCCATERM f on f.termscode = b.termscode        
                                left join IvystoneSalesPeople c on c.SalesPersonNumber = b.salespersonnumber                
                                left join SWCCRSMAN d on d.salespersonnumber = b.salespersonnumber
                                left join LJCreditApp g on g.CustomerNumber = LTRIM(b.customernumber)
                                left join LJOrderInfo h on h.OrderNumber = b.ordernumber                     
                                where b.locationnumber = '800' and orderdate > '6/1/2016' and totalprice > 0
                                group by b.customernumber, billtoname, b.ordernumber, customerponumber, category, salespersonname, ManagerName, orderdate, 
			                                termsdescription, usercomment, dateshipped, trackingnumber, shippingdate, b.invoicenumber, b.totalprice, g.CreditAppReceived, h.Notes, h.CSCrep, h.Shipped
                                order by b.invoicenumber desc", connectionString);

            System.Data.DataTable finalDoc = new System.Data.DataTable();
            foreach (DataColumn column in orders.Columns)
            {
                finalDoc.Columns.Add(column.ColumnName, column.DataType);
            }


            // group category column from Sales orders THANKS RICK!!!
            string orderIndex = string.Empty;
            foreach (DataRow row in orders.Rows)
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
            orderIndex = string.Empty;
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
            finalDoc.Columns.Add("Weekly Total").SetOrdinal(11);
            dataGridView1.Columns[10].DefaultCellStyle.Format = "c";
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
            foreach(DataRow row in finalDoc.Rows)
            {
                dataGridView1.Rows.Add(row.ItemArray);
            }
            //dataGridView1.DataSource = finalDoc;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            DataTable order = new DataTable();
            order.Columns.Add("OrderNumber");
            order.Columns.Add("Shipped");
            order.Columns.Add("Notes");
            order.Columns.Add("CSCRep");
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                order.Rows.Add(row.Cells["ordernumber"].Value, row.Cells["Shipped"].Value, row.Cells["Notes"].Value, row.Cells["CSCrep"].Value);
            }
            order.Rows[order.Rows.Count - 1].Delete();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(@"Create Table LJOrderInfoTMP(OrderNumber char(10),
                                                             Shipped char(10),
                                                             Notes nvarchar(max),
                                                             CSCRep nchar(10))", conn);
                    SqlCommand sp = new SqlCommand("UpdateDSR");
                    sp.CommandType = CommandType.StoredProcedure;
                    sp.Connection = conn;

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlBulkCopy bulkcopy = new SqlBulkCopy(connectionString))
                    {
                        bulkcopy.DestinationTableName = "LJOrderInfoTMP";
                        bulkcopy.ColumnMappings.Add("OrderNumber", "OrderNumber");
                        bulkcopy.ColumnMappings.Add("Shipped", "Shipped");
                        bulkcopy.ColumnMappings.Add("Notes", "Notes");
                        bulkcopy.ColumnMappings.Add("CSCRep", "CSCRep");
                        bulkcopy.WriteToServer(order);
                    }

                    sp.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.LogError("Could not create table for DSR", ex.ToString());
                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(@"IF NOT EXISTS(select customernumber from LJCreditApp where LTRIM(CustomerNumber) = @textbox)
                                                      INSERT INTO LJCreditApp VALUES(@textbox, @combobox)
                                                      else
                                                      UPDATE LJCreditApp SET CreditAppReceived = @combobox where CustomerNumber = @textbox", conn);
                    cmd.Parameters.AddWithValue("@textbox", textBox1.Text);
                    cmd.Parameters.AddWithValue("@combobox", comboBox1.SelectedItem);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
