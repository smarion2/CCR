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
    public partial class YoYReportForm : Form
    {
        public YoYReportForm()
        {
            InitializeComponent();
        }

        private void YoYReportForm_Load(object sender, EventArgs e)
        {
        }

        private void runReport_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yoyDS.DataTable1' table. You can move, or remove it, as needed.
            this.DataTable1TableAdapter.Fill(this.yoyDS.DataTable1, customerTextBox.Text);
            this.reportViewer1.RefreshReport();
        }
    }
}
