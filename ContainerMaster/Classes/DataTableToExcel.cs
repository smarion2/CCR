using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

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

                // load excel, and create a new workbook
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Workbooks.Add();

                // single worksheet
                Microsoft.Office.Interop.Excel._Worksheet workSheet = excelApp.ActiveSheet;

                // column headings
                for (int i = 0; i < Tbl.Columns.Count; i++)
                {
                    workSheet.Cells[1, (i + 1)] = Tbl.Columns[i].ColumnName;
                }
                workSheet.Range["1:1"].Orientation = 90;
                int rowCount = 1;
                // rows
                for (int i = 0; i < Tbl.Rows.Count; i++)
                {
                    rowCount++;
                    // to do: format datetime values before printing
                    for (int j = 0; j < Tbl.Columns.Count; j++)
                    {
                        workSheet.Cells[(i + 2), (j + 1)] = Tbl.Rows[i][j];
                    }
                }

                // check fielpath
                if (ExcelFilePath != null && ExcelFilePath != "")
                {
                    try
                    {
                        workSheet.SaveAs(ExcelFilePath);
                        excelApp.Quit();
                        MessageBox.Show("Excel file saved!");
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("ExportToExcel: Excel file could not be saved! Check filepath.\n"
                            + ex.Message);
                    }
                }
                else    // no filepath is given
                {
                    excelApp.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ExportToExcel: \n" + ex.Message);
            }
        }

    }
}
