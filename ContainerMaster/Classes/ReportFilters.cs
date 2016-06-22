using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CCR
{
    public static class ReportFilters
    {
        private static string delimiter = "\r\n";
        private static string connectionString = "Data Source=srv-swdb;Initial Catalog=swdb;Persist Security Info=True;User ID=swdb;Password=SouthWare99";

        private static List<string> Tables = new List<string>();

        public static void ItemFilter(string items, string locationNumber = "'900','800'")
        {
            string recursiveItem = items;
            if (items != string.Empty)
            {
                String[] splitItems = Regex.Split(items, delimiter);
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    try
                    {
                        using (SqlCommand command = new SqlCommand("CREATE TABLE ItemFilterTMP(Items char(50));", conn))
                            command.ExecuteNonQuery();

                        foreach (string item in splitItems)
                        {
                            using (SqlCommand command = new SqlCommand("INSERT INTO ItemFilterTMP VALUES (@itemID)", conn))
                            {
                                command.Parameters.AddWithValue("@itemID", item);
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        System.Threading.Thread.Sleep(500);
                        ItemFilter(recursiveItem);
                    }
                    
                }
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    try
                    {
                        using (SqlCommand command = new SqlCommand("CREATE TABLE ItemFilterTMP(Items char(50));", conn))
                            command.ExecuteNonQuery();
                        using (SqlCommand command = new SqlCommand("INSERT INTO ItemFilterTMP select stocknumber from SWCCSSTOK where locationnumber in (" + locationNumber + ") and orderynpdxam != 'Y' and orderynpdxam != 'X'", conn))
                            command.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        System.Threading.Thread.Sleep(500);
                        ItemFilter(recursiveItem);
                    }

                }

            }
            Tables.Add("ItemFilterTMP");
        }

        public static void VendorFilter(string vendors, string locationNumber = "'900','800'")
        {
            string recursiveVendors = vendors;
            if (vendors != string.Empty)
            {
                String[] splitVendors = Regex.Split(vendors, delimiter);
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand command = new SqlCommand("CREATE TABLE VendorFilterTMP(Vendors char(10));", conn))
                            command.ExecuteNonQuery();

                        foreach (string vendor in splitVendors)
                        {
                            using (SqlCommand command = new SqlCommand("INSERT INTO VendorFilterTMP VALUES (@vendor)", conn))
                            {
                                command.Parameters.AddWithValue("@vendor", vendor);
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    System.Threading.Thread.Sleep(500);
                    VendorFilter(recursiveVendors);
                }
                
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    try
                    {
                        using (SqlCommand command = new SqlCommand("CREATE TABLE VendorFilterTMP(Vendors char(10));", conn))
                            command.ExecuteNonQuery();
                        using (SqlCommand command = new SqlCommand("INSERT INTO VendorFilterTMP SELECT vendornumber from SWCCAVEND", conn))
                            command.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        System.Threading.Thread.Sleep(500);
                        VendorFilter(recursiveVendors);                        
                    }                    
                }
            }
            Tables.Add("VendorFilterTMP");
        }

        public static void CatFilter(string cats, string locationNumber = "'900','800'")
        {
            string recursiveCatFilter = cats;
            if (cats != string.Empty)
            {
                String[] splitCats = Regex.Split(cats, delimiter);
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    try
                    {
                        using (SqlCommand command = new SqlCommand("CREATE TABLE CatFilterTMP(Cats char(8));", conn))
                            command.ExecuteNonQuery();

                        foreach (string cat in splitCats)
                        {
                            using (SqlCommand command = new SqlCommand("INSERT INTO CatFilterTMP VALUES (@cat)", conn))
                            {
                                command.Parameters.AddWithValue("@cat", cat);
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        System.Threading.Thread.Sleep(500);
                        CatFilter(recursiveCatFilter);
                    }                    
                }
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    try
                    {
                        using (SqlCommand command = new SqlCommand("CREATE TABLE CatFilterTMP(Cats char(8));", conn))
                            command.ExecuteNonQuery();
                        using (SqlCommand command = new SqlCommand("INSERT INTO CatFilterTMP SELECT categorycode from SWCCSCATG", conn))
                            command.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        System.Threading.Thread.Sleep(500);
                        CatFilter(recursiveCatFilter);                        
                    }                    
                }
            }
            Tables.Add("CatFilterTMP");
        }

        public static void DropTables()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                foreach (string table in Tables)
                {
                    try
                    {
                        using (SqlCommand command = new SqlCommand("DROP TABLE " + table, conn))
                        {
                            //command.Parameters.AddWithValue("@table", table);
                            command.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLogger.LogError("Can't Drop Tables", ex.ToString());
                    }
                    
                }
            }
        }
    }
}
