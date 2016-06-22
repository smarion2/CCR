namespace CCR
{
    partial class ItemImageForm
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
            this.qtyAvaliCheckBox = new System.Windows.Forms.CheckBox();
            this.msrpCheckBox = new System.Windows.Forms.CheckBox();
            this.wholesaleCheckBox = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataTable1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.itemImageDS = new CCR.itemImageDS();
            this.DataTable1TableAdapter = new CCR.itemImageDSTableAdapters.DataTable1TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemImageDS)).BeginInit();
            this.SuspendLayout();
            // 
            // qtyAvaliCheckBox
            // 
            this.qtyAvaliCheckBox.AutoSize = true;
            this.qtyAvaliCheckBox.Checked = true;
            this.qtyAvaliCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.qtyAvaliCheckBox.Location = new System.Drawing.Point(12, 361);
            this.qtyAvaliCheckBox.Name = "qtyAvaliCheckBox";
            this.qtyAvaliCheckBox.Size = new System.Drawing.Size(88, 17);
            this.qtyAvaliCheckBox.TabIndex = 0;
            this.qtyAvaliCheckBox.Text = "Qty Avaliable";
            this.qtyAvaliCheckBox.UseVisualStyleBackColor = true;
            // 
            // msrpCheckBox
            // 
            this.msrpCheckBox.AutoSize = true;
            this.msrpCheckBox.Checked = true;
            this.msrpCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.msrpCheckBox.Location = new System.Drawing.Point(12, 385);
            this.msrpCheckBox.Name = "msrpCheckBox";
            this.msrpCheckBox.Size = new System.Drawing.Size(57, 17);
            this.msrpCheckBox.TabIndex = 1;
            this.msrpCheckBox.Text = "MSRP";
            this.msrpCheckBox.UseVisualStyleBackColor = true;
            // 
            // wholesaleCheckBox
            // 
            this.wholesaleCheckBox.AutoSize = true;
            this.wholesaleCheckBox.Checked = true;
            this.wholesaleCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.wholesaleCheckBox.Location = new System.Drawing.Point(12, 409);
            this.wholesaleCheckBox.Name = "wholesaleCheckBox";
            this.wholesaleCheckBox.Size = new System.Drawing.Size(76, 17);
            this.wholesaleCheckBox.TabIndex = 2;
            this.wholesaleCheckBox.Text = "Wholesale";
            this.wholesaleCheckBox.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 69);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 251);
            this.textBox1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 447);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Run";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 335);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Column Visable?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Item Numbers";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            reportDataSource1.Name = "imageDS";
            reportDataSource1.Value = this.DataTable1BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CCR.itemImage.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(127, 2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(763, 525);
            this.reportViewer1.TabIndex = 7;
            // 
            // DataTable1BindingSource
            // 
            this.DataTable1BindingSource.DataMember = "DataTable1";
            this.DataTable1BindingSource.DataSource = this.itemImageDS;
            // 
            // itemImageDS
            // 
            this.itemImageDS.DataSetName = "itemImageDS";
            this.itemImageDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DataTable1TableAdapter
            // 
            this.DataTable1TableAdapter.ClearBeforeFill = true;
            // 
            // ItemImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 525);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.wholesaleCheckBox);
            this.Controls.Add(this.msrpCheckBox);
            this.Controls.Add(this.qtyAvaliCheckBox);
            this.Name = "ItemImageForm";
            this.Text = "ItemImageForm";
            this.Load += new System.EventHandler(this.ItemImageForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemImageDS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox qtyAvaliCheckBox;
        private System.Windows.Forms.CheckBox msrpCheckBox;
        private System.Windows.Forms.CheckBox wholesaleCheckBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource DataTable1BindingSource;
        private itemImageDS itemImageDS;
        private itemImageDSTableAdapters.DataTable1TableAdapter DataTable1TableAdapter;
    }
}