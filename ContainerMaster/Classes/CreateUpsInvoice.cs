using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Forms.Design;
using System.Collections;
using System.ComponentModel.Design;


namespace CCR
{
    public static class InternationalInvoice
    {        
        public static void CreateInvoice()
        {            
            SqlConnection con;

            // CM Details
            Prompt prompt = new Prompt();
            string poNumber = prompt.ShowDialog("Enter PO number to create file for UPS", "Generate invoice file");
            string sqlQuery;

            con = new SqlConnection();
            con.ConnectionString = "Data Source=srv-swdb;Initial Catalog=swdb;Persist Security Info=True;User ID=swdb;Password=SouthWare99";
            using (con)
            {
                sqlQuery = @"select stockordered, lineitemdesc1, sum(quantitytoship) as 'quantitytoship', unitprice as 'unitprice', sum(quantitytoship * unitprice) as 'line total', countrynew, ponumber, unitofmeasure from( 
                           select a.stockordered, 
                                   a.lineitemdesc1, 
                                   a.quantitytoship as quantitytoship, 
                                   a.unitprice as unitprice, 
                                   a.quantitytoship* a.unitprice as 'line total', 
                                   c.countrynew, 
                                   b.ponumber, 
                                   a.unitofmeasure 
                           from SWCCSBIL2 a 
                           join SWCCSBIL1 b on b.ordernumber = a.ordernumber 
                           left outer join SWCCSX005 c on a.stockordered = c.stocknumber 
                           where b.ponumber = @ponumber and quantitytoship > 0 and c.locationnumber = '900'                           
                           UNION ALL 
                           select itemidstocksvc, 
                                   linhstdesc1, 
                                   quantitytoship as quantitytoship, 
                                   unitprice as unitprice, 
                                   quantitytoship* unitprice as 'Line Total', 
                                   countrynew, 
                                   customerponumber, 
                                   unitofmeasure as 'Invoice Quantity Uom' 
                           from SWCCSHST2 b 
                           join SWCCSHST1 a on a.invoicenumber = b.invoicenumber 
                           left outer join SWCCSX005 c on c.stocknumber = b.itemidstocksvc and c.locationnumber = '900' 
                           where customerponumber = @ponumber) x 
                           group by stockordered, lineitemdesc1, countrynew, ponumber, unitofmeasure, unitprice";

                try
                {
                    SqlDataAdapter adap;
                    DataSet ds = new DataSet();
                    DataTable dTable = new DataTable();
                    adap = new SqlDataAdapter(sqlQuery, con);
                    adap.SelectCommand.Parameters.AddWithValue("@ponumber", poNumber);
                    adap.Fill(dTable);
                    createFile(dTable, poNumber);
                    dTable.Clear();
                    adap.SelectCommand.Parameters.Clear();              
                }
                catch (Exception ex)
                {
                    ErrorLogger.LogError("UPS Invoice Query failed", ex.ToString());
                } 
            }
        }

        private static void createFile(DataTable dTable, string poNumber)
        {
            string importFile = "Part Code \t Dsc1 \t Dsc2 \t HS Code \t Invoice Quantity \t Unit Price \t Line Total \t Country of Origin \t VFD \t Tariff Treatment Code \t Tax Ref # \t PO# \t" +
                "Cert Orig. Type \t NAFTA Code \t Cert Org. Eff \t Cert Org. Exp. \t Annex \t OIC Rem \t Invoice Quantity UoM \t Qty for HS Code \t Qty for HS Code UoM \r\n";
            foreach (DataRow row in dTable.Rows)
            {
                string country = CountryLookUP((string)row["countrynew"]);

                importFile += (string)row["stockordered"] + "\t" + (string)row["lineitemdesc1"] + "\t" + "\t" + "\t" + row["quantitytoship"].ToString() + "\t" +
                    row["unitprice"].ToString() + "\t" + row["line total"].ToString() + "\t" + country + "\t"  + "13" + "\t" + "2" + "\t" + "\t" +
                    (string)row["ponumber"] + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "NMB" + "\r\n";
            }
            System.IO.File.WriteAllText(@"\\srv-sw\\public\\UpsInvoices\\" + poNumber + ".TXT", importFile);
            MessageBox.Show("File has been created at \\srv-sw\\public\\UpsInvoices\\" + poNumber + ".TXT", "Complete!", MessageBoxButtons.OK);
        }

        private static string CountryLookUP(string country)
        {
            country = country.Replace(" ", string.Empty);
            switch (country)
            {
                case "PORTUGAL":
                    return country = "PT";
                case "VENEZUELA":
                    return country = "VE";
                case "KOREA":
                    return country = "KR";
                case "PHILLIPPINES":
                    return country = "PH";
                case "HONG KONG":
                    return country = "HK";
                case "CHN":
                    return country = "CN";
                case "CHINA":
                    return country = "CN";
                case "TAIWAN":
                    return country = "TW";
                case "AUSTRIA":
                    return country = "AT";
                case "ROMANIA":
                    return country = "RO"; 
                case "INDONESIA":
                    return country = "ID";
                case "CZECH":
                    return country = "CZ";                
                case "JAPAN":
                    return country = "JP";
                case "USA":
                    return country = "US";
                case "INDIA":
                    return country = "IN";
            }
            return country;
        }
    }
}