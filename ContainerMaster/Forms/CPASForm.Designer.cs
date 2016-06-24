﻿namespace CCR
{
    partial class CPASForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPASForm));
            this.DataTable1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ContainerMasterDS = new CCR.ContainerMasterDS();
            this.DataTable1TableAdapter = new CCR.ContainerMasterDSTableAdapters.DataTable1TableAdapter();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.accountsRecieveableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.swarovskiSalesReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.royaltyReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yOYReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemImageReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountsPayableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.containerMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buyReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editContainersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editContainerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inputRetailSalesDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.walMartOutsReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eDIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aSNInvoiceMismatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.populateTrackingNumbersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createUPSInvoiceFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.designGADToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barcodeImageGeneratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContainerMasterDS)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataTable1BindingSource
            // 
            this.DataTable1BindingSource.DataMember = "DataTable1";
            this.DataTable1BindingSource.DataSource = this.ContainerMasterDS;
            // 
            // ContainerMasterDS
            // 
            this.ContainerMasterDS.DataSetName = "ContainerMasterDS";
            this.ContainerMasterDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DataTable1TableAdapter
            // 
            this.DataTable1TableAdapter.ClearBeforeFill = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountsRecieveableToolStripMenuItem,
            this.accountsPayableToolStripMenuItem,
            this.analysisToolStripMenuItem,
            this.accountingToolStripMenuItem,
            this.eDIToolStripMenuItem,
            this.designGADToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(969, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // accountsRecieveableToolStripMenuItem
            // 
            this.accountsRecieveableToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.swarovskiSalesReportToolStripMenuItem,
            this.royaltyReportToolStripMenuItem,
            this.yOYReportToolStripMenuItem,
            this.itemImageReportToolStripMenuItem});
            this.accountsRecieveableToolStripMenuItem.Name = "accountsRecieveableToolStripMenuItem";
            this.accountsRecieveableToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.accountsRecieveableToolStripMenuItem.Text = "Sales";
            // 
            // swarovskiSalesReportToolStripMenuItem
            // 
            this.swarovskiSalesReportToolStripMenuItem.Name = "swarovskiSalesReportToolStripMenuItem";
            this.swarovskiSalesReportToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.swarovskiSalesReportToolStripMenuItem.Text = " Quantity Sold Sales Report";
            this.swarovskiSalesReportToolStripMenuItem.Click += new System.EventHandler(this.swarovskiSalesReportToolStripMenuItem_Click);
            // 
            // royaltyReportToolStripMenuItem
            // 
            this.royaltyReportToolStripMenuItem.Name = "royaltyReportToolStripMenuItem";
            this.royaltyReportToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.royaltyReportToolStripMenuItem.Text = "Royalty Report";
            this.royaltyReportToolStripMenuItem.Click += new System.EventHandler(this.royaltyReportToolStripMenuItem_Click);
            // 
            // yOYReportToolStripMenuItem
            // 
            this.yOYReportToolStripMenuItem.Name = "yOYReportToolStripMenuItem";
            this.yOYReportToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.yOYReportToolStripMenuItem.Text = "YOY Report";
            this.yOYReportToolStripMenuItem.Click += new System.EventHandler(this.yOYReportToolStripMenuItem_Click);
            // 
            // itemImageReportToolStripMenuItem
            // 
            this.itemImageReportToolStripMenuItem.Name = "itemImageReportToolStripMenuItem";
            this.itemImageReportToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.itemImageReportToolStripMenuItem.Text = "Item Image Report";
            this.itemImageReportToolStripMenuItem.Click += new System.EventHandler(this.itemImageReportToolStripMenuItem_Click);
            // 
            // accountsPayableToolStripMenuItem
            // 
            this.accountsPayableToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportsToolStripMenuItem,
            this.editContainersToolStripMenuItem,
            this.editContainerToolStripMenuItem});
            this.accountsPayableToolStripMenuItem.Name = "accountsPayableToolStripMenuItem";
            this.accountsPayableToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.accountsPayableToolStripMenuItem.Text = "Purchasing";
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.containerMasterToolStripMenuItem,
            this.buyReportToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // containerMasterToolStripMenuItem
            // 
            this.containerMasterToolStripMenuItem.Name = "containerMasterToolStripMenuItem";
            this.containerMasterToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.containerMasterToolStripMenuItem.Text = "Container Master";
            this.containerMasterToolStripMenuItem.Click += new System.EventHandler(this.containerMasterToolStripMenuItem_Click);
            // 
            // buyReportToolStripMenuItem
            // 
            this.buyReportToolStripMenuItem.Name = "buyReportToolStripMenuItem";
            this.buyReportToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.buyReportToolStripMenuItem.Text = "Buy Report";
            this.buyReportToolStripMenuItem.Click += new System.EventHandler(this.buyReportToolStripMenuItem_Click);
            // 
            // editContainersToolStripMenuItem
            // 
            this.editContainersToolStripMenuItem.Name = "editContainersToolStripMenuItem";
            this.editContainersToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.editContainersToolStripMenuItem.Text = "New Container";
            this.editContainersToolStripMenuItem.Click += new System.EventHandler(this.editContainersToolStripMenuItem_Click);
            // 
            // editContainerToolStripMenuItem
            // 
            this.editContainerToolStripMenuItem.Name = "editContainerToolStripMenuItem";
            this.editContainerToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.editContainerToolStripMenuItem.Text = "Edit Containers";
            this.editContainerToolStripMenuItem.Click += new System.EventHandler(this.editContainerToolStripMenuItem_Click);
            // 
            // analysisToolStripMenuItem
            // 
            this.analysisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inputRetailSalesDataToolStripMenuItem,
            this.walMartOutsReportToolStripMenuItem});
            this.analysisToolStripMenuItem.Name = "analysisToolStripMenuItem";
            this.analysisToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.analysisToolStripMenuItem.Text = "Analysis";
            // 
            // inputRetailSalesDataToolStripMenuItem
            // 
            this.inputRetailSalesDataToolStripMenuItem.Name = "inputRetailSalesDataToolStripMenuItem";
            this.inputRetailSalesDataToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.inputRetailSalesDataToolStripMenuItem.Text = "Input Retail Sales Data";
            this.inputRetailSalesDataToolStripMenuItem.Click += new System.EventHandler(this.inputRetailSalesDataToolStripMenuItem_Click);
            // 
            // walMartOutsReportToolStripMenuItem
            // 
            this.walMartOutsReportToolStripMenuItem.Name = "walMartOutsReportToolStripMenuItem";
            this.walMartOutsReportToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.walMartOutsReportToolStripMenuItem.Text = "Wal-Mart Outs Report";
            this.walMartOutsReportToolStripMenuItem.Click += new System.EventHandler(this.walMartOutsReportToolStripMenuItem_Click);
            // 
            // accountingToolStripMenuItem
            // 
            this.accountingToolStripMenuItem.Name = "accountingToolStripMenuItem";
            this.accountingToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.accountingToolStripMenuItem.Text = "Accounting";
            // 
            // eDIToolStripMenuItem
            // 
            this.eDIToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aSNInvoiceMismatchToolStripMenuItem,
            this.populateTrackingNumbersToolStripMenuItem,
            this.createUPSInvoiceFileToolStripMenuItem});
            this.eDIToolStripMenuItem.Name = "eDIToolStripMenuItem";
            this.eDIToolStripMenuItem.Size = new System.Drawing.Size(36, 20);
            this.eDIToolStripMenuItem.Text = "EDI";
            // 
            // aSNInvoiceMismatchToolStripMenuItem
            // 
            this.aSNInvoiceMismatchToolStripMenuItem.Name = "aSNInvoiceMismatchToolStripMenuItem";
            this.aSNInvoiceMismatchToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.aSNInvoiceMismatchToolStripMenuItem.Text = "ASN / Invoice Mismatch";
            this.aSNInvoiceMismatchToolStripMenuItem.Click += new System.EventHandler(this.aSNInvoiceMismatchToolStripMenuItem_Click);
            // 
            // populateTrackingNumbersToolStripMenuItem
            // 
            this.populateTrackingNumbersToolStripMenuItem.Name = "populateTrackingNumbersToolStripMenuItem";
            this.populateTrackingNumbersToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.populateTrackingNumbersToolStripMenuItem.Text = "Populate Tracking Numbers";
            this.populateTrackingNumbersToolStripMenuItem.Click += new System.EventHandler(this.populateTrackingNumbersToolStripMenuItem_Click);
            // 
            // createUPSInvoiceFileToolStripMenuItem
            // 
            this.createUPSInvoiceFileToolStripMenuItem.Name = "createUPSInvoiceFileToolStripMenuItem";
            this.createUPSInvoiceFileToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.createUPSInvoiceFileToolStripMenuItem.Text = "Create UPS CA invoice file";
            this.createUPSInvoiceFileToolStripMenuItem.Click += new System.EventHandler(this.createUPSInvoiceFileToolStripMenuItem_Click);
            // 
            // designGADToolStripMenuItem
            // 
            this.designGADToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barcodeImageGeneratorToolStripMenuItem});
            this.designGADToolStripMenuItem.Name = "designGADToolStripMenuItem";
            this.designGADToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.designGADToolStripMenuItem.Text = "Design / GAD";
            // 
            // barcodeImageGeneratorToolStripMenuItem
            // 
            this.barcodeImageGeneratorToolStripMenuItem.Name = "barcodeImageGeneratorToolStripMenuItem";
            this.barcodeImageGeneratorToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.barcodeImageGeneratorToolStripMenuItem.Text = "Barcode Image Generator";
            this.barcodeImageGeneratorToolStripMenuItem.Click += new System.EventHandler(this.barcodeImageGeneratorToolStripMenuItem_Click);
            // 
            // CPASForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 557);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CPASForm";
            this.Text = "CCR";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContainerMasterDS)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource DataTable1BindingSource;
        private ContainerMasterDS ContainerMasterDS;
        private ContainerMasterDSTableAdapters.DataTable1TableAdapter DataTable1TableAdapter;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem accountsRecieveableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analysisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eDIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aSNInvoiceMismatchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inputRetailSalesDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem walMartOutsReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem populateTrackingNumbersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createUPSInvoiceFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem swarovskiSalesReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountsPayableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem containerMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buyReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editContainersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editContainerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem royaltyReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yOYReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemImageReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem designGADToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem barcodeImageGeneratorToolStripMenuItem;
    }
}
