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
            this.SWCCSBIL2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.sWCCSCATGBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.categoryDS = new CCR.categoryDS();
            this.sWCCSCATGTableAdapter = new CCR.categoryDSTableAdapters.SWCCSCATGTableAdapter();
            this.ItemFiltertextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton900 = new System.Windows.Forms.RadioButton();
            this.radioButton800 = new System.Windows.Forms.RadioButton();
            this.radioButton700 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SWCCSBIL2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sWCCSCATGBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryDS)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SWCCSBIL2BindingSource
            // 
            this.SWCCSBIL2BindingSource.DataMember = "SWCCSBIL2";
            // 
            // sworvskiDS
            // 
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "From Date";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.AllowDrop = true;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(74, 28);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(95, 20);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "To Date:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(74, 58);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(95, 20);
            this.dateTimePicker2.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(241, 406);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Run Report";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SWCCSBIL2TableAdapter
            // 
            // 
            // listBox1
            // 
            this.listBox1.DataSource = this.sWCCSCATGBindingSource;
            this.listBox1.DisplayMember = "categorydescription";
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(16, 136);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox1.Size = new System.Drawing.Size(133, 264);
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
            // ItemFiltertextBox
            // 
            this.ItemFiltertextBox.Location = new System.Drawing.Point(186, 131);
            this.ItemFiltertextBox.Multiline = true;
            this.ItemFiltertextBox.Name = "ItemFiltertextBox";
            this.ItemFiltertextBox.Size = new System.Drawing.Size(130, 269);
            this.ItemFiltertextBox.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton900);
            this.groupBox1.Controls.Add(this.radioButton800);
            this.groupBox1.Controls.Add(this.radioButton700);
            this.groupBox1.Location = new System.Drawing.Point(202, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(114, 92);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Location Number";
            // 
            // radioButton900
            // 
            this.radioButton900.AutoSize = true;
            this.radioButton900.Checked = true;
            this.radioButton900.Location = new System.Drawing.Point(6, 67);
            this.radioButton900.Name = "radioButton900";
            this.radioButton900.Size = new System.Drawing.Size(43, 17);
            this.radioButton900.TabIndex = 2;
            this.radioButton900.TabStop = true;
            this.radioButton900.Text = "900";
            this.radioButton900.UseVisualStyleBackColor = true;
            // 
            // radioButton800
            // 
            this.radioButton800.AutoSize = true;
            this.radioButton800.Location = new System.Drawing.Point(6, 43);
            this.radioButton800.Name = "radioButton800";
            this.radioButton800.Size = new System.Drawing.Size(43, 17);
            this.radioButton800.TabIndex = 1;
            this.radioButton800.Text = "800";
            this.radioButton800.UseVisualStyleBackColor = true;
            // 
            // radioButton700
            // 
            this.radioButton700.AutoSize = true;
            this.radioButton700.Location = new System.Drawing.Point(6, 19);
            this.radioButton700.Name = "radioButton700";
            this.radioButton700.Size = new System.Drawing.Size(43, 17);
            this.radioButton700.TabIndex = 0;
            this.radioButton700.Text = "700";
            this.radioButton700.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Category Filter";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(186, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Item Filter";
            // 
            // SwarovskiSalesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 439);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ItemFiltertextBox);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Name = "SwarovskiSalesForm";
            this.Text = "SwarovskiSalesForm";
            this.Load += new System.EventHandler(this.SwarovskiSalesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SWCCSBIL2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sWCCSCATGBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryDS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource SWCCSBIL2BindingSource;
        private System.Windows.Forms.ListBox listBox1;
        private categoryDS categoryDS;
        private System.Windows.Forms.BindingSource sWCCSCATGBindingSource;
        private categoryDSTableAdapters.SWCCSCATGTableAdapter sWCCSCATGTableAdapter;
        private System.Windows.Forms.TextBox ItemFiltertextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton900;
        private System.Windows.Forms.RadioButton radioButton800;
        private System.Windows.Forms.RadioButton radioButton700;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}