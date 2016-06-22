namespace CCR
{
    partial class SwarovskiSalesForm
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.SWCCSBIL2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sworvskiDS = new CCR.sworvskiDS();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.SWCCSBIL2TableAdapter = new CCR.sworvskiDSTableAdapters.SWCCSBIL2TableAdapter();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.sWCCSCATGBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.categoryDS = new CCR.categoryDS();
            this.sWCCSCATGTableAdapter = new CCR.categoryDSTableAdapters.SWCCSCATGTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.SWCCSBIL2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sworvskiDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sWCCSCATGBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryDS)).BeginInit();
            this.SuspendLayout();
            // 
            // SWCCSBIL2BindingSource
            // 
            this.SWCCSBIL2BindingSource.DataMember = "SWCCSBIL2";
            this.SWCCSBIL2BindingSource.DataSource = this.sworvskiDS;
            // 
            // sworvskiDS
            // 
            this.sworvskiDS.DataSetName = "sworvskiDS";
            this.sworvskiDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource2.Name = "swarovskiDS";
            reportDataSource2.Value = this.SWCCSBIL2BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CCR.SwarovskiSalesReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(204, 1);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(515, 514);
            this.reportViewer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "From Date";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.AllowDrop = true;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(63, 15);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(100, 20);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "To Date:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(67, 66);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(95, 20);
            this.dateTimePicker2.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(88, 462);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Run Report";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SWCCSBIL2TableAdapter
            // 
            this.SWCCSBIL2TableAdapter.ClearBeforeFill = true;
            // 
            // listBox1
            // 
            this.listBox1.DataSource = this.sWCCSCATGBindingSource;
            this.listBox1.DisplayMember = "categorydescription";
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(16, 107);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox1.Size = new System.Drawing.Size(147, 316);
            this.listBox1.TabIndex = 6;
            this.listBox1.ValueMember = "categorycode";
            // 
            // sWCCSCATGBindingSource
            // 
            this.sWCCSCATGBindingSource.DataMember = "SWCCSCATG";
            this.sWCCSCATGBindingSource.DataSource = this.categoryDS;
            // 
            // categoryDS
            // 
            this.categoryDS.DataSetName = "categoryDS";
            this.categoryDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sWCCSCATGTableAdapter
            // 
            this.sWCCSCATGTableAdapter.ClearBeforeFill = true;
            // 
            // SwarovskiSalesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 516);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "SwarovskiSalesForm";
            this.Text = "SwarovskiSalesForm";
            this.Load += new System.EventHandler(this.SwarovskiSalesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SWCCSBIL2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sworvskiDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sWCCSCATGBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryDS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource SWCCSBIL2BindingSource;
        private sworvskiDS sworvskiDS;
        private sworvskiDSTableAdapters.SWCCSBIL2TableAdapter SWCCSBIL2TableAdapter;
        private System.Windows.Forms.ListBox listBox1;
        private categoryDS categoryDS;
        private System.Windows.Forms.BindingSource sWCCSCATGBindingSource;
        private categoryDSTableAdapters.SWCCSCATGTableAdapter sWCCSCATGTableAdapter;
    }
}