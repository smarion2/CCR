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
    public partial class RoyaltyForm : Form
    {
        public RoyaltyForm()
        {
            InitializeComponent();
        }

        private void Royalty_Form_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime fromDate = fromDatePicker.Value;
            DateTime toDate = toDatePicker.Value;
            // TODO: This line of code loads data into the 'royaltyDS.royaltyTable' table. You can move, or remove it, as needed.
            this.royaltyTableAdapter.Fill(this.royaltyDS.royaltyTable, fromDate, toDate);
            //this.royaltyTableAdapter.Fill(this.royaltyDS.royaltyTable);
            this.reportViewer1.RefreshReport();

        }

    }
}
