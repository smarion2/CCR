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

namespace CCR
{
    public partial class CPASForm : Form
    {
        
        public CPASForm()
        {
            InitializeComponent();
            //if (LogOnCCR.userPermission.TryGetValue("Admin", out value))
            //{
            //    menuStrip1.Enabled = true;
            //}
            //if (LogOnCCR.userPermission["SalesMenu"] > 0)
            //{
            //    swarovskiSalesReportToolStripMenuItem.Enabled = true;
            //}
            //if (LogOnCCR.userPermission["PurchMenu"] > 0)
            //{
            //    editContainersToolStripMenuItem.Enabled = true;
            //    editContainerToolStripMenuItem.Enabled = true;
            //    containerMasterToolStripMenuItem.Enabled = true;
            //    buyReportToolStripMenuItem.Enabled = true;
            //    updateCustomerCodesToolStripMenuItem.Enabled = true;
            //}
            //if (LogOnCCR.userPermission["AnalysisMenu"] > 0)
            //{
            //    inputRetailSalesDataToolStripMenuItem.Enabled = true;
            //    walMartOutsReportToolStripMenuItem.Enabled = true;
            //}
            //if (LogOnCCR.userPermission["AccountingMenu"] > 0)
            //{

            //}
            //if (LogOnCCR.userPermission["EDIMenu"] > 0)
            //{
            //    populateTrackingNumbersToolStripMenuItem.Enabled = true;
            //    aSNInvoiceMismatchToolStripMenuItem.Enabled = true;
            //    createUPSInvoiceFileToolStripMenuItem.Enabled = true;
            //}
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        ContainerMasterReportForm cmForm;
        public void containerMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmForm == null)
            {
                cmForm = new ContainerMasterReportForm();
                cmForm.MdiParent = this;
                cmForm.FormClosed += new FormClosedEventHandler(cmForm_FormClosed);
                cmForm.Show();
            }
            else
                cmForm.Activate();
        }

        void cmForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            cmForm = null;
        }

        InputContainerForm containerEditor;
        private void editContainersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (containerEditor == null)
            {
                containerEditor = new InputContainerForm();
                containerEditor.MdiParent = this;
                containerEditor.FormClosed += new FormClosedEventHandler(containerEditor_FormClosed);
                containerEditor.Show();
            }
            else
                containerEditor.Activate();

        }

        void containerEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            containerEditor = null;
            
        }

        cmEditContainerForm containerEditorForm;
        private void editContainerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (containerEditorForm == null)
            {
                containerEditorForm = new cmEditContainerForm();
                containerEditorForm.MdiParent = this;
                containerEditorForm.FormClosed += new FormClosedEventHandler(editContainer_FormClosed);
                containerEditorForm.Show();
            }
            else
                containerEditorForm.Activate();
        }

        void editContainer_FormClosed(object sender, FormClosedEventArgs e)
        {
            containerEditorForm = null;
        }

        BuyReportForm buyreportForm;
        private void buyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (buyreportForm == null)
            {
                buyreportForm = new BuyReportForm();
                buyreportForm.MdiParent = this;
                buyreportForm.FormClosed += new FormClosedEventHandler(buyReport_FormClosed);
                buyreportForm.Show();
            }
            else
                buyreportForm.Activate();
        }

        void buyReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            buyreportForm = null;
        }

        ASNmismatch ediForm;
        private void aSNInvoiceMismatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ediForm == null)
            {
                ediForm = new ASNmismatch();
                ediForm.MdiParent = this;
                ediForm.FormClosed += new FormClosedEventHandler(ediForm_FormClosed);
                ediForm.Show();
            }
            else
                ediForm.Activate();
        }

        private void ediForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ediForm = null;
        }

        private void inputRetailSalesDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputRetailData.WriteToDatabase();
        }

        WalmartOutsReportForm outsForm;
        private void walMartOutsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (outsForm == null)
            {
                outsForm = new WalmartOutsReportForm();
                outsForm.MdiParent = this;
                outsForm.FormClosed += new FormClosedEventHandler(outsForm_FormClosed);
                outsForm.Show();
            }
            else
                outsForm.Activate();
        }

        private void outsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            outsForm = null;
        }
        
        private void populateTrackingNumbersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopulateJASTracking.GetTrackingNumbers();
        }
        
        private void createUPSInvoiceFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InternationalInvoice.CreateInvoice();
        }

        SwarovskiSalesForm ssForm;
        private void swarovskiSalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ssForm == null)
            {
                ssForm = new SwarovskiSalesForm();
                ssForm.MdiParent = this;
                ssForm.FormClosed += new FormClosedEventHandler(ssForm_FormClosed);
                ssForm.Show();
            }

        }

        private void ssForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ssForm = null;
        }

        RoyaltyForm royal;
        private void royaltyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (royal == null)
            {
                royal = new RoyaltyForm();
                royal.MdiParent = this;
                royal.FormClosed += new FormClosedEventHandler(royal_FormClosed);
                royal.Show();
            }
        }

        private void royal_FormClosed(object sender, FormClosedEventArgs e)
        {
            royal = null;
        }

        YoYReportForm yoy;
        private void yOYReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (yoy == null)
            {
                yoy = new YoYReportForm();
                yoy.MdiParent = this;
                yoy.FormClosed += new FormClosedEventHandler(yoy_FormClosed);
                yoy.Show();
            }
        }

        private void yoy_FormClosed(object sender, FormClosedEventArgs e)
        {
            yoy = null;
        }

        ItemImageForm image;
        private void itemImageReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                image = new ItemImageForm();
                image.MdiParent = this;
                image.FormClosed += new FormClosedEventHandler(image_FormClosed);
                image.Show();
            }
        }

        private void image_FormClosed(object sender, FormClosedEventArgs e)
        {
            image = null;
        }

        BarcodeForm bar;
        private void barcodeImageGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bar == null)
            {
                bar = new BarcodeForm();
                bar.MdiParent = this;
                bar.FormClosed += new FormClosedEventHandler(bar_formClosed);
                bar.Show();
            }
        }

        private void bar_formClosed(object sender, FormClosedEventArgs e)
        {
            bar = null;
        }

        LauraJanelleForm lj;
        private void atAGlanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lj == null)
            {
                lj = new LauraJanelleForm();
                lj.MdiParent = this;
                lj.FormClosed += new FormClosedEventHandler(lj_formClosed);
                lj.Show();
            }
        }

        private void lj_formClosed(object sender, FormClosedEventArgs e)
        {
            lj = null;
        }


        CustomCousinReports ccr;
        private void customCousinReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(ccr == null)
            {
                ccr = new CustomCousinReports();
                ccr.MdiParent = this;
                ccr.FormClosed += new FormClosedEventHandler(ccr_formClosed);
                ccr.Show();
            }            
        }

        private void ccr_formClosed(object sender, FormClosedEventArgs e)
        {
            ccr = null;
        }

        DSRForm dsr;
        private void dSRReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dsr == null)
            {
                dsr = new DSRForm();
                dsr.MdiParent = this;
                dsr.FormClosed += new FormClosedEventHandler(dsr_formClosed);
                dsr.Show();
            }
            //LauraJanelleDSR dsr = new LauraJanelleDSR();
            //dsr.GenerateReport();


            //lauraJTEST dsr = new lauraJTEST();
            //dsr.FirstPage();
        }

        private void dsr_formClosed(object sender, FormClosedEventArgs e)
        {
            dsr = null; 
        }

        International_PO_log poLog;
        private void internationalPOLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (poLog == null)
            {
                poLog = new International_PO_log();
                poLog.MdiParent = this;
                poLog.FormClosed += new FormClosedEventHandler(poLog_formClosed);
                poLog.Show();
            }
        }

        private void poLog_formClosed(object sender, FormClosedEventArgs e)
        {
            poLog = null;
        }

        POTemplate poTemp;
        private void pOTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (poTemp == null)
            {
                poTemp = new POTemplate();
                poTemp.MdiParent = this;
                poTemp.FormClosed += new FormClosedEventHandler(poTemp_formClosed);
                poTemp.Show();
            }
        }

        private void poTemp_formClosed(object sender, FormClosedEventArgs e)
        {
            poTemp = null;
        }

        private void openPOByVendorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenPOByVendor po = new OpenPOByVendor();
            po.CreateReport();
        }

        NewSalesReport newSalesReport;
        private void newSalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(newSalesReport == null)
            {
                newSalesReport = new NewSalesReport();
                newSalesReport.MdiParent = this;
                newSalesReport.FormClosed += new FormClosedEventHandler(newSalesReport_formClosed);
                newSalesReport.Show();
            }
        }

        private void newSalesReport_formClosed(object sender, EventArgs e)
        {
            newSalesReport = null;
        }

        private void fixWMASNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FixWMASN asn = new FixWMASN();
            asn.Fix();
        }
    }
       
}
