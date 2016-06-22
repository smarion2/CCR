namespace CCR
{
    partial class ASNmismatch
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ediengineDataSet = new CCR.ediengineDataSet();
            this._856tmpBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._856tmpTableAdapter = new CCR.ediengineDataSetTableAdapters._856tmpTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ediengineDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._856tmpBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "ediDS";
            reportDataSource1.Value = this._856tmpBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CCR.ediMismatch.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(650, 372);
            this.reportViewer1.TabIndex = 0;
            // 
            // ediengineDataSet
            // 
            this.ediengineDataSet.DataSetName = "ediengineDataSet";
            this.ediengineDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // _856tmpBindingSource
            // 
            this._856tmpBindingSource.DataMember = "856tmp";
            this._856tmpBindingSource.DataSource = this.ediengineDataSet;
            // 
            // _856tmpTableAdapter
            // 
            this._856tmpTableAdapter.ClearBeforeFill = true;
            // 
            // ASNmismatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 372);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ASNmismatch";
            this.Text = "ASN Invoice Mismatch";
            this.Load += new System.EventHandler(this.ASNmismatch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ediengineDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._856tmpBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource _856tmpBindingSource;
        private ediengineDataSet ediengineDataSet;
        private ediengineDataSetTableAdapters._856tmpTableAdapter _856tmpTableAdapter;
    }
}