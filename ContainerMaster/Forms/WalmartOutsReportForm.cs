using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Collections;


namespace CCR
{
    public partial class WalmartOutsReportForm : Form
    {
        public WalmartOutsReportForm()
        {
            InitializeComponent();
        }

        private void WalmartOutsReportForm_Load(object sender, EventArgs e)
        {

        }

        private void runButton_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'wmOutsReport.SWCPSBIL1' table. You can move, or remove it, as needed.
            DateTime fromDate = fromDateTimePicker.Value;
            DateTime toDate = toDateTimePicker.Value;
            
            this.SWCPSBIL1TableAdapter.Fill(this.wmOutsReport.SWCPSBIL1, fromDate, toDate);
            this.reportViewer1.RefreshReport();
        }
    }
}
