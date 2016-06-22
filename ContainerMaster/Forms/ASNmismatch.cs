using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCR
{
    public partial class ASNmismatch : Form
    {
        public ASNmismatch()
        {
            InitializeComponent();
        }

        private void ASNmismatch_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ediengineDataSet._856tmp' table. You can move, or remove it, as needed.
            this._856tmpTableAdapter.Fill(this.ediengineDataSet._856tmp);
            //string date = "3/5/2016";
           // DateTime ddate = Convert.ToDateTime(date);
            //ReportParameter poNO = new ReportParameter("poNumber", "");
            //ReportParameter invNO = new ReportParameter("invNumber", "");
            //ReportParameter invDate = new ReportParameter("invDate", date );
            //this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { null, null });
            this.reportViewer1.RefreshReport();
        }
    }
}
