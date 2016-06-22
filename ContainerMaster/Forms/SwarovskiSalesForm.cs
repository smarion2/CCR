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
    public partial class SwarovskiSalesForm : Form
    {
        public SwarovskiSalesForm()
        {
            InitializeComponent();
        }

        private void SwarovskiSalesForm_Load(object sender, EventArgs e)
        {            
            this.sWCCSCATGTableAdapter.Fill(this.categoryDS.SWCCSCATG);
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            string fromDate = dateTimePicker1.Text;
            string toDate = dateTimePicker2.Text;
            string cats = string.Empty;

            DateTime fD = Convert.ToDateTime(fromDate);
            DateTime tD = Convert.ToDateTime(toDate);

            foreach (DataRowView cat in listBox1.SelectedItems)
            {
                cats += cat[0].ToString() + "\r\n";
            }

            ReportFilters.CatFilter(cats);
            this.SWCCSBIL2TableAdapter.Fill(this.sworvskiDS.SWCCSBIL2, fD, tD);
            ReportFilters.DropTables();
            
            this.reportViewer1.RefreshReport();
        }
    }
}
