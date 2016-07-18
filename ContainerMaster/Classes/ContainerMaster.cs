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

        public void CreateReport()
        {
            poTable = GetData.ExecuteQuery("EXEC ContainerMasterTEST", connectionString);

            CreateContainer c = new CreateContainer();
            c.AddToDataTable(poTable, 10);

            poTable.Columns.Remove("onWater");

            DataTableToExcel.ExportToExcel(poTable);
        }
        
    }
}
