using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.IO;

namespace CCR
{
       
    public static class DataTableToExcel
    {
        // Export DataTable into an excel file with field names in the header line
        // - Save excel file without ever making it visible if filepath is given
        // - Don't save excel file, just make it visible if no filepath is given            
        public static void ExportToExcel(this System.Data.DataTable Tbl, string ExcelFilePath = null)
        {

            try
            {
                if (Tbl == null || Tbl.Columns.Count == 0)
                    throw new Exception("ExportToExcel: Null or empty input table!\n");

                SaveFileDialog fileDialog = new SaveFileDialog();
                fileDialog.Filter = "CSV | *.csv";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filepath = Path.GetFullPath(fileDialog.FileName);
                    StringBuilder sb = new StringBuilder();
                    IEnumerable<string> columnNames = Tbl.Columns.Cast<System.Data.DataColumn>().
                                                      Select(column => column.ColumnName);
                    sb.AppendLine(string.Join(",", columnNames));

                    foreach (System.Data.DataRow row in Tbl.Rows)
                    {
                        IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                        sb.AppendLine(string.Join(",", fields));
                    }

                    File.WriteAllText(filepath, sb.ToString());
                    // open csv in Excel
                    Excel.Application excelApp = new Excel.Application();
                    Object missing = System.Reflection.Missing.Value;
                    excelApp.Workbooks.OpenText(filepath,
                                                missing, 3,
                                                Excel.XlTextParsingType.xlDelimited,
                                                Excel.XlTextQualifier.xlTextQualifierNone,
                                                missing, missing, missing, true, missing, missing, missing,
                                                missing, missing, missing, missing, missing, missing);

                    Excel._Worksheet workSheet = excelApp.ActiveSheet;
                    excelApp.ReferenceStyle = Excel.XlReferenceStyle.xlA1;
                    workSheet.Columns.AutoFit();
                    string replace = Path.GetFileName(fileDialog.FileName).Replace(".csv", ".xlsx");
                    string path = Path.GetDirectoryName(fileDialog.FileName) + "\\" + replace;
                    workSheet.SaveAs(path, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    excelApp.Workbooks.Open(path);
                    excelApp.Visible = true;
                    //excelApp.Quit();
                    File.Delete(filepath);
                }

                //// check fielpath
                //if (ExcelFilePath != null && ExcelFilePath != "")
                //{
                //    try
                //    {
                //        workSheet.SaveAs(ExcelFilePath);
                //        excelApp.Quit();
                //        MessageBox.Show("Excel file saved!");
                //    }
                //    catch (Exception ex)
                //    {
                //        throw new Exception("ExportToExcel: Excel file could not be saved! Check filepath.\n"
                //            + ex.Message);
                //    }
                //}
                //else    // no filepath is given
                //{
                //    excelApp.Visible = true;
                //}
            }
            catch (Exception ex)
            {
                throw new Exception("ExportToExcel: \n" + ex.Message);
            }
        }

    }
}
