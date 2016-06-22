namespace CCR
{
    partial class BuyReportForm
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
            this.BuyReportDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BuyReportDS = new CCR.BuyReportDS();
            this.BuyReportDataTableAdapter = new CCR.BuyReportDSTableAdapters.BuyReportDataTableAdapter();
            this.runReportButton = new System.Windows.Forms.Button();
            this.updateCustomerCodesButtons = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ItemFilter = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.vendorFilters = new System.Windows.Forms.TextBox();
            this.catFilters = new System.Windows.Forms.TextBox();
            this.expediteCB = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton900 = new System.Windows.Forms.RadioButton();
            this.radioButton800 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.BuyReportDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BuyReportDS)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BuyReportDataBindingSource
            // 
            this.BuyReportDataBindingSource.DataMember = "BuyReportData";
            this.BuyReportDataBindingSource.DataSource = this.BuyReportDS;
            // 
            // BuyReportDS
            // 
            this.BuyReportDS.DataSetName = "BuyReportDS";
            this.BuyReportDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // BuyReportDataTableAdapter
            // 
            this.BuyReportDataTableAdapter.ClearBeforeFill = true;
            // 
            // runReportButton
            // 
            this.runReportButton.Location = new System.Drawing.Point(432, 80);
            this.runReportButton.Name = "runReportButton";
            this.runReportButton.Size = new System.Drawing.Size(89, 41);
            this.runReportButton.TabIndex = 9;
            this.runReportButton.Text = "Run Report";
            this.runReportButton.UseVisualStyleBackColor = true;
            this.runReportButton.Click += new System.EventHandler(this.runReportButton_Click_1);
            // 
            // updateCustomerCodesButtons
            // 
            this.updateCustomerCodesButtons.Location = new System.Drawing.Point(432, 26);
            this.updateCustomerCodesButtons.Name = "updateCustomerCodesButtons";
            this.updateCustomerCodesButtons.Size = new System.Drawing.Size(89, 48);
            this.updateCustomerCodesButtons.TabIndex = 8;
            this.updateCustomerCodesButtons.Text = "Update Customer Codes";
            this.updateCustomerCodesButtons.UseVisualStyleBackColor = true;
            this.updateCustomerCodesButtons.Click += new System.EventHandler(this.updateCustomerCodesButtons_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Item Filter";
            // 
            // ItemFilter
            // 
            this.ItemFilter.Location = new System.Drawing.Point(12, 26);
            this.ItemFilter.Multiline = true;
            this.ItemFilter.Name = "ItemFilter";
            this.ItemFilter.Size = new System.Drawing.Size(112, 218);
            this.ItemFilter.TabIndex = 6;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 256);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(519, 23);
            this.progressBar1.TabIndex = 10;
            this.progressBar1.Visible = false;
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(9, 282);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(102, 13);
            this.progressLabel.TabIndex = 11;
            this.progressLabel.Text = "Creating Buy Report";
            this.progressLabel.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(160, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Vendor Filter";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(309, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Category Filter";
            // 
            // vendorFilters
            // 
            this.vendorFilters.Location = new System.Drawing.Point(163, 26);
            this.vendorFilters.Multiline = true;
            this.vendorFilters.Name = "vendorFilters";
            this.vendorFilters.Size = new System.Drawing.Size(100, 218);
            this.vendorFilters.TabIndex = 16;
            // 
            // catFilters
            // 
            this.catFilters.Location = new System.Drawing.Point(312, 26);
            this.catFilters.Multiline = true;
            this.catFilters.Name = "catFilters";
            this.catFilters.Size = new System.Drawing.Size(100, 218);
            this.catFilters.TabIndex = 17;
            // 
            // expediteCB
            // 
            this.expediteCB.AutoSize = true;
            this.expediteCB.Location = new System.Drawing.Point(432, 136);
            this.expediteCB.Name = "expediteCB";
            this.expediteCB.Size = new System.Drawing.Size(102, 17);
            this.expediteCB.TabIndex = 18;
            this.expediteCB.Text = "Expedite Report";
            this.expediteCB.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton800);
            this.groupBox1.Controls.Add(this.radioButton900);
            this.groupBox1.Location = new System.Drawing.Point(432, 160);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(102, 90);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Location Number";
            // 
            // radioButton900
            // 
            this.radioButton900.AutoSize = true;
            this.radioButton900.Checked = true;
            this.radioButton900.Location = new System.Drawing.Point(7, 20);
            this.radioButton900.Name = "radioButton900";
            this.radioButton900.Size = new System.Drawing.Size(43, 17);
            this.radioButton900.TabIndex = 0;
            this.radioButton900.TabStop = true;
            this.radioButton900.Text = "900";
            this.radioButton900.UseVisualStyleBackColor = true;
            // 
            // radioButton800
            // 
            this.radioButton800.AutoSize = true;
            this.radioButton800.Location = new System.Drawing.Point(7, 43);
            this.radioButton800.Name = "radioButton800";
            this.radioButton800.Size = new System.Drawing.Size(43, 17);
            this.radioButton800.TabIndex = 1;
            this.radioButton800.TabStop = true;
            this.radioButton800.Text = "800";
            this.radioButton800.UseVisualStyleBackColor = true;
            // 
            // BuyReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 303);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.expediteCB);
            this.Controls.Add(this.catFilters);
            this.Controls.Add(this.vendorFilters);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.runReportButton);
            this.Controls.Add(this.updateCustomerCodesButtons);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ItemFilter);
            this.Name = "BuyReportForm";
            this.Text = "BuyReportForm";
            this.Load += new System.EventHandler(this.BuyReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BuyReportDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BuyReportDS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource BuyReportDataBindingSource;
        private BuyReportDS BuyReportDS;
        private BuyReportDSTableAdapters.BuyReportDataTableAdapter BuyReportDataTableAdapter;
        private System.Windows.Forms.Button runReportButton;
        private System.Windows.Forms.Button updateCustomerCodesButtons;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ItemFilter;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox vendorFilters;
        private System.Windows.Forms.TextBox catFilters;
        private System.Windows.Forms.CheckBox expediteCB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton800;
        private System.Windows.Forms.RadioButton radioButton900;
    }
}