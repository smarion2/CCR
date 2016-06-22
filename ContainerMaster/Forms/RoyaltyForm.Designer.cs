namespace CCR
{
    partial class RoyaltyForm
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
            this.royaltyTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.royaltyDS = new CCR.royaltyDS();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.runButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.royaltyTableAdapter = new CCR.royaltyDSTableAdapters.royaltyTableAdapter();
            this.fromDatePicker = new System.Windows.Forms.DateTimePicker();
            this.toDatePicker = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.royaltyTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.royaltyDS)).BeginInit();
            this.SuspendLayout();
            // 
            // royaltyTableBindingSource
            // 
            this.royaltyTableBindingSource.DataMember = "royaltyTable";
            this.royaltyTableBindingSource.DataSource = this.royaltyDS;
            // 
            // royaltyDS
            // 
            this.royaltyDS.DataSetName = "royaltyDS";
            this.royaltyDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-195, -14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "To Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-195, -76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "From Date";
            // 
            // runButton
            // 
            this.runButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.runButton.Location = new System.Drawing.Point(-195, 341);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(93, 31);
            this.runButton.TabIndex = 10;
            this.runButton.Text = "Run Report";
            this.runButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "From Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "To Date:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 183);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "Run Report";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "royaltyDS";
            reportDataSource1.Value = this.royaltyTableBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CCR.RoyaltyReport.rdlc";
            this.reportViewer1.LocalReport.ReportPath = "";
            this.reportViewer1.Location = new System.Drawing.Point(108, 3);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(539, 324);
            this.reportViewer1.TabIndex = 21;
            // 
            // royaltyTableAdapter
            // 
            this.royaltyTableAdapter.ClearBeforeFill = true;
            // 
            // fromDatePicker
            // 
            this.fromDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fromDatePicker.Location = new System.Drawing.Point(3, 58);
            this.fromDatePicker.Name = "fromDatePicker";
            this.fromDatePicker.Size = new System.Drawing.Size(99, 20);
            this.fromDatePicker.TabIndex = 22;
            // 
            // toDatePicker
            // 
            this.toDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.toDatePicker.Location = new System.Drawing.Point(3, 132);
            this.toDatePicker.Name = "toDatePicker";
            this.toDatePicker.Size = new System.Drawing.Size(99, 20);
            this.toDatePicker.TabIndex = 23;
            // 
            // RoyaltyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 328);
            this.Controls.Add(this.toDatePicker);
            this.Controls.Add(this.fromDatePicker);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.runButton);
            this.Name = "RoyaltyForm";
            this.Text = "Royalty Form";
            this.Load += new System.EventHandler(this.Royalty_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.royaltyTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.royaltyDS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource royaltyTableBindingSource;
        private royaltyDSTableAdapters.royaltyTableAdapter royaltyTableAdapter;
        private royaltyDS royaltyDS;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.DateTimePicker fromDatePicker;
        private System.Windows.Forms.DateTimePicker toDatePicker;
    }
}