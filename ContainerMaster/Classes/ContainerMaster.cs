using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Threading;

namespace CCR
{
    public class ContainerMaster
    {
        private DataTable poTable;
        private string connectionString = "Data Source=srv-swdb;Initial Catalog=swdb;Persist Security Info=True;User ID=swdb;Password=SouthWare99";
        //private Form prompt = new Form()
        //{
        //    Width = 500,
        //    Height = 150,
        //    FormBorderStyle = FormBorderStyle.FixedDialog,
        //    Text = "Creating Container Master",
        //    StartPosition = FormStartPosition.CenterScreen
        //};
        //private Label reportStatus = new Label() { Left = 50, Top = 20, Text = "Retriving Data from SQL server", Width = 200, AutoSize = true };
        //private ProgressBar progBar = new ProgressBar() { Left = 50, Top = 50, Width = 400 };

        public void CreateReport()
        {
            //Thread backgroundThread = new Thread(
            //    new ThreadStart(() =>
            //{
            //    Form prompt = new Form()
            //    {
            //        Width = 500,
            //        Height = 150,
            //        FormBorderStyle = FormBorderStyle.FixedDialog,
            //        Text = "Creating Container Master",
            //        StartPosition = FormStartPosition.CenterScreen
            //    };
            //    Label reportStatus = new Label() { Left = 50, Top = 20, Text = "Retriving Data from SQL server", Width = 200, AutoSize = true };
            //    ProgressBar progBar = new ProgressBar() { Left = 50, Top = 50, Width = 400 };
            //    prompt.Controls.Add(progBar);
                
            //    prompt.Controls.Add(reportStatus);
            //    prompt.Show();
            //    progBar.BeginInvoke(
            //                new Action(() =>
            //                {
            //                    progBar.Style = ProgressBarStyle.Marquee;                                
            //                }));

            poTable = GetData.ExecuteQuery("EXEC ContainerMasterTEST", connectionString);

                

            //    reportStatus.BeginInvoke(
            //                new Action(() =>
            //                {                                
            //                    reportStatus.Text = "Creating BuyReport";
            //                }));

            //    poTable.Columns.Remove("onWater");

            CreateContainer c = new CreateContainer();
            c.AddToDataTable(poTable, 10);
            poTable.Columns.Remove("onWater");
            //    //AddContainer.ToDataTable(poTable, 9);

            //    reportStatus.BeginInvoke(
            //        new Action(() =>
            //        {
            //            reportStatus.Text = "Creating Excel Document";
            //        }));
            //    prompt.Close();
            //    prompt = null;
            //}));
                DataTableToExcel.ExportToExcel(poTable);
           // backgroundThread.Start();
        }
        
    }
}
