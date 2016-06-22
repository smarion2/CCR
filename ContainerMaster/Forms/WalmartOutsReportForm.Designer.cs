namespace CCR
{
    partial class WalmartOutsReportForm
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.SWCPSBIL1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wmOutsReport = new CCR.wmOutsReport();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.runButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SWCPSBIL1TableAdapter = new CCR.wmOutsReportTableAdapters.SWCPSBIL1TableAdapter();
            this.fromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.toDateTimePicker = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.SWCPSBIL1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wmOutsReport)).BeginInit();
            this.SuspendLayout();
            // 
            // SWCPSBIL1BindingSource
            // 
            this.SWCPSBIL1BindingSource.DataMember = "SWCPSBIL1";
            this.SWCPSBIL1BindingSource.DataSource = this.wmOutsReport;
            // 
            // wmOutsReport
            // 
            this.wmOutsReport.DataSetName = "wmOutsReport";
            this.wmOutsReport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer1.DocumentMapWidth = 1;
            reportDataSource1.Name = "wmOutsDS";
            reportDataSource1.Value = this.SWCPSBIL1BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CCR.WalmartOuts.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(132, 1);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(653, 503);
            this.reportViewer1.TabIndex = 0;
            // 
            // runButton
            // 
            this.runButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.runButton.Location = new System.Drawing.Point(13, 430);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(93, 31);
            this.runButton.TabIndex = 2;
            this.runButton.Text = "Run Report";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "From Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "To Date";
            // 
            // SWCPSBIL1TableAdapter
            // 
            this.SWCPSBIL1TableAdapter.ClearBeforeFill = true;
            // 
            // fromDateTimePicker
            // 
            this.fromDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fromDateTimePicker.Location = new System.Drawing.Point(12, 56);
            this.fromDateTimePicker.Name = "fromDateTimePicker";
            this.fromDateTimePicker.Size = new System.Drawing.Size(110, 20);
            this.fromDateTimePicker.TabIndex = 7;
            // 
            // toDateTimePicker
            // 
            this.toDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.toDateTimePicker.Location = new System.Drawing.Point(12, 118);
            this.toDateTimePicker.Name = "toDateTimePicker";
            this.toDateTimePicker.Size = new System.Drawing.Size(110, 20);
            this.toDateTimePicker.TabIndex = 8;
            // 
            // WalmartOutsReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 508);
            this.Controls.Add(this.toDateTimePicker);
            this.Controls.Add(this.fromDateTimePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.reportViewer1);
            this.Name = "WalmartOutsReportForm";
            this.Text = "WalmartOutsReportForm";
            this.Load += new System.EventHandler(this.WalmartOutsReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SWCPSBIL1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wmOutsReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SWCPSBIL1BindingSource;
        private wmOutsReport wmOutsReport;
        private wmOutsReportTableAdapters.SWCPSBIL1TableAdapter SWCPSBIL1TableAdapter;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker fromDateTimePicker;
        private System.Windows.Forms.DateTimePicker toDateTimePicker;
    }
}