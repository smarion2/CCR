using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Threading;
using Excel = Microsoft.Office.Interop.Excel;
using System.Drawing;
using System.IO;

namespace CCR
{
    public class ContainerMaster
    {
        private DataTable poTable;
        private string connectionString = "Data Source=srv-swdb;Initial Catalog=swdb;Persist Security Info=True;User ID=swdb;Password=SouthWare99";

        public void CreateReport()
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "CSV | *.csv";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = Path.GetFullPath(fileDialog.FileName);
                poTable = GetData.ExecuteQuery("EXEC ContainerMasterTEST", connectionString);

                CreateContainer c = new CreateContainer();
                c.AddToDataTable(poTable, 10);
                List<Container> containerList = c.GetContainerList();

                poTable.Columns.Remove("onWater");

                StringBuilder sb = new StringBuilder();

                IEnumerable<string> columnNames = poTable.Columns.Cast<DataColumn>().
                                                  Select(column => column.ColumnName);
                sb.AppendLine(string.Join(",", columnNames));

                foreach (DataRow row in poTable.Rows)
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


                int columnToColor = 9;
                foreach (Container container in containerList)
                {
                    workSheet.Range[GetColumnName(columnToColor) + "1"].Interior.Color = ColorTranslator.ToOle(Color.FromArgb(container.RGBcolor[0], container.RGBcolor[1], container.RGBcolor[2]));
                    columnToColor++;
                }
                workSheet.Range["1:1"].Orientation = 90;
                workSheet.Range["1:1"].RowHeight = 110;
                workSheet.Range["C:C"].NumberFormat = "MM/DD/YYYY";
                workSheet.Range["D:D"].NumberFormat = "MM/DD/YYYY";
                workSheet.Range["E:E"].NumberFormat = "MM/DD/YYYY";
                workSheet.Columns.AutoFit();
                //Path.ChangeExtension(filepath, ".xlsx");
                string replace = Path.GetFileName(fileDialog.FileName).Replace(".csv", ".xlsx");
                string path = Path.GetDirectoryName(fileDialog.FileName) + "\\" + replace;
                workSheet.SaveAs(path, Excel.XlFileFormat.xlOpenXMLWorkbook, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                excelApp.Workbooks.Open(path);
                excelApp.Visible = true;
                //excelApp.Quit();
                File.Delete(filepath);
            }
            //DataTableToExcel.ExportToExcel(poTable);
        }


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
