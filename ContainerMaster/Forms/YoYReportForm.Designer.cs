namespace CCR
{
    partial class YoYReportForm
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.customerTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.runReport = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.yoyDS = new CCR.yoyDS();
            this.DataTable1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataTable1TableAdapter = new CCR.yoyDSTableAdapters.DataTable1TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.yoyDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // customerTextBox
            // 
            this.customerTextBox.Location = new System.Drawing.Point(12, 39);
            this.customerTextBox.Name = "customerTextBox";
            this.customerTextBox.Size = new System.Drawing.Size(100, 20);
            this.customerTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Customer Number";
            // 
            // runReport
            // 
            this.runReport.Location = new System.Drawing.Point(12, 66);
            this.runReport.Name = "runReport";
            this.runReport.Size = new System.Drawing.Size(100, 23);
            this.runReport.TabIndex = 2;
            this.runReport.Text = "Run Report";
            this.runReport.UseVisualStyleBackColor = true;
            this.runReport.Click += new System.EventHandler(this.runReport_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource3.Name = "yoyReportData";
            reportDataSource3.Value = this.DataTable1BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CCR.yoyReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(118, -1);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(640, 477);
            this.reportViewer1.TabIndex = 3;
            // 
            // yoyDS
            // 
            this.yoyDS.DataSetName = "yoyDS";
            this.yoyDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DataTable1BindingSource
            // 
            this.DataTable1BindingSource.DataMember = "DataTable1";
            this.DataTable1BindingSource.DataSource = this.yoyDS;
            // 
            // DataTable1TableAdapter
            // 
            this.DataTable1TableAdapter.ClearBeforeFill = true;
            // 
            // YoYReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 473);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.runReport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.customerTextBox);
            this.Name = "YoYReportForm";
            this.Text = "YoYReportForm";
            this.Load += new System.EventHandler(this.YoYReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.yoyDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox customerTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button runReport;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource DataTable1BindingSource;
        private yoyDS yoyDS;
        private yoyDSTableAdapters.DataTable1TableAdapter DataTable1TableAdapter;
    }
}