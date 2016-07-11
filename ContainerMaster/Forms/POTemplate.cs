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
    public partial class POTemplate : Form
    {
        public POTemplate()
        {
            InitializeComponent();
        }

        private void POTemplate_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'poTemplateDS.BuyReportData' table. You can move, or remove it, as needed.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.BuyReportDataTableAdapter.Fill(this.poTemplateDS.BuyReportData, textBox1.Text);

            this.reportViewer1.RefreshReport();

        }
    }
}
