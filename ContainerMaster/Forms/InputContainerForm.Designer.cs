namespace CCR
{
    partial class InputContainerForm
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
            this.containerMasterDS = new CCR.ContainerMasterDS();
            this.dataTable1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataTable1TableAdapter = new CCR.ContainerMasterDSTableAdapters.DataTable1TableAdapter();
            this.tableAdapterManager = new CCR.ContainerMasterDSTableAdapters.TableAdapterManager();
            this.selectFileButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.EtaCalander = new System.Windows.Forms.MonthCalendar();
            this.ShippedCalander = new System.Windows.Forms.MonthCalendar();
            this.NumberOfCartons = new System.Windows.Forms.NumericUpDown();
            this.TrackingText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SupplierText = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.notesTextBox = new System.Windows.Forms.TextBox();
            this.MODlistBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.containerMasterDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfCartons)).BeginInit();
            this.SuspendLayout();
            // 
            // containerMasterDS
            // 
            this.containerMasterDS.DataSetName = "ContainerMasterDS";
            this.containerMasterDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataTable1BindingSource
            // 
            this.dataTable1BindingSource.DataMember = "DataTable1";
            this.dataTable1BindingSource.DataSource = this.containerMasterDS;
            // 
            // dataTable1TableAdapter
            // 
            this.dataTable1TableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = CCR.ContainerMasterDSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // selectFileButton
            // 
            this.selectFileButton.Location = new System.Drawing.Point(451, 421);
            this.selectFileButton.Name = "selectFileButton";
            this.selectFileButton.Size = new System.Drawing.Size(75, 23);
            this.selectFileButton.TabIndex = 0;
            this.selectFileButton.Text = "Select File";
            this.selectFileButton.UseVisualStyleBackColor = true;
            this.selectFileButton.Click += new System.EventHandler(this.selectFileButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(281, 426);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Import New Container Data(.csv):";
            // 
            // EtaCalander
            // 
            this.EtaCalander.Location = new System.Drawing.Point(235, 34);
            this.EtaCalander.MaxSelectionCount = 1;
            this.EtaCalander.Name = "EtaCalander";
            this.EtaCalander.TabIndex = 8;
            // 
            // ShippedCalander
            // 
            this.ShippedCalander.Location = new System.Drawing.Point(235, 224);
            this.ShippedCalander.MaxSelectionCount = 1;
            this.ShippedCalander.Name = "ShippedCalander";
            this.ShippedCalander.TabIndex = 9;
            // 
            // NumberOfCartons
            // 
            this.NumberOfCartons.Location = new System.Drawing.Point(15, 159);
            this.NumberOfCartons.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.NumberOfCartons.Name = "NumberOfCartons";
            this.NumberOfCartons.Size = new System.Drawing.Size(120, 20);
            this.NumberOfCartons.TabIndex = 10;
            // 
            // TrackingText
            // 
            this.TrackingText.Location = new System.Drawing.Point(15, 317);
            this.TrackingText.Name = "TrackingText";
            this.TrackingText.Size = new System.Drawing.Size(120, 20);
            this.TrackingText.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "ETA Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(235, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Container Sail Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Supplier Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Number of Cartons";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Mode of Delivery";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 301);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Tracking / Container Number";
            // 
            // SupplierText
            // 
            this.SupplierText.FormattingEnabled = true;
            this.SupplierText.Items.AddRange(new object[] {
            "Asian Art & Craft",
            "Aurient",
            "Banaras",
            "Bestone",
            "Chain Wit",
            "Creative Craft",
            "Kwan Hing",
            "Ningbo",
            "Samsom",
            "TMI",
            "Yu Ming",
            "Zhongyi"});
            this.SupplierText.Location = new System.Drawing.Point(15, 34);
            this.SupplierText.Name = "SupplierText";
            this.SupplierText.Size = new System.Drawing.Size(120, 82);
            this.SupplierText.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 372);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Notes";
            // 
            // notesTextBox
            // 
            this.notesTextBox.Location = new System.Drawing.Point(15, 388);
            this.notesTextBox.MaxLength = 200;
            this.notesTextBox.Multiline = true;
            this.notesTextBox.Name = "notesTextBox";
            this.notesTextBox.Size = new System.Drawing.Size(162, 50);
            this.notesTextBox.TabIndex = 21;
            // 
            // MODlistBox
            // 
            this.MODlistBox.FormattingEnabled = true;
            this.MODlistBox.Items.AddRange(new object[] {
            "Ocean",
            "FedEx",
            "Air Shipment Other",
            "Ocean Trucked"});
            this.MODlistBox.Location = new System.Drawing.Point(15, 224);
            this.MODlistBox.Name = "MODlistBox";
            this.MODlistBox.Size = new System.Drawing.Size(120, 56);
            this.MODlistBox.TabIndex = 22;
            // 
            // InputContainerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 463);
            this.Controls.Add(this.MODlistBox);
            this.Controls.Add(this.notesTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.SupplierText);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TrackingText);
            this.Controls.Add(this.NumberOfCartons);
            this.Controls.Add(this.ShippedCalander);
            this.Controls.Add(this.EtaCalander);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectFileButton);
            this.Name = "InputContainerForm";
            this.Text = "New Container Form";
            this.Load += new System.EventHandler(this.ContainerEditorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.containerMasterDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfCartons)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ContainerMasterDS containerMasterDS;
        private System.Windows.Forms.BindingSource dataTable1BindingSource;
        private ContainerMasterDSTableAdapters.DataTable1TableAdapter dataTable1TableAdapter;
        private ContainerMasterDSTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Button selectFileButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MonthCalendar EtaCalander;
        private System.Windows.Forms.MonthCalendar ShippedCalander;
        private System.Windows.Forms.NumericUpDown NumberOfCartons;
        private System.Windows.Forms.TextBox TrackingText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox SupplierText;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox notesTextBox;
        private System.Windows.Forms.ListBox MODlistBox;
    }
}