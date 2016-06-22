using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CCR
{
    public partial class ItemImageForm : Form
    {
        public ItemImageForm()
        {
            InitializeComponent();
        }

        private void ItemImageForm_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string qty = qtyAvaliCheckBox.Checked.ToString();
            string msrp = msrpCheckBox.Checked.ToString();
            string whole = wholesaleCheckBox.Checked.ToString();

            this.reportViewer1.LocalReport.EnableExternalImages = true;
            ReportParameter qtyParm = new ReportParameter("QtyAvali", qty);
            ReportParameter msrpParm = new ReportParameter("MSRP", msrp);
            ReportParameter wholeParm = new ReportParameter("Wholesale", whole);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { qtyParm, msrpParm, wholeParm });
            ReportFilters.ItemFilter(textBox1.Text);            
            this.DataTable1TableAdapter.Fill(this.itemImageDS.DataTable1);
            ReportFilters.DropTables();
            this.reportViewer1.RefreshReport();
        }
    }
}
