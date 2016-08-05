namespace CCR
{
    partial class DSRForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.excelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.customerNumberBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.orderNumberBox = new System.Windows.Forms.TextBox();
            this.shipComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cscTextBox = new System.Windows.Forms.TextBox();
            this.notesBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(-2, 1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(941, 644);
            this.dataGridView1.TabIndex = 0;
            // 
            // excelButton
            // 
            this.excelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.excelButton.Location = new System.Drawing.Point(831, 706);
            this.excelButton.Name = "excelButton";
            this.excelButton.Size = new System.Drawing.Size(93, 23);
            this.excelButton.TabIndex = 1;
            this.excelButton.Text = "Export to Excel";
            this.excelButton.UseVisualStyleBackColor = true;
            this.excelButton.Click += new System.EventHandler(this.excelButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(366, 657);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Customer Number";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "No",
            "Yes",
            "Approved"});
            this.comboBox1.Location = new System.Drawing.Point(569, 652);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // customerNumberBox
            // 
            this.customerNumberBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.customerNumberBox.Location = new System.Drawing.Point(463, 652);
            this.customerNumberBox.Name = "customerNumberBox";
            this.customerNumberBox.Size = new System.Drawing.Size(100, 20);
            this.customerNumberBox.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.Location = new System.Drawing.Point(804, 651);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Update Credit App";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(384, 682);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Order Number";
            // 
            // orderNumberBox
            // 
            this.orderNumberBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.orderNumberBox.Location = new System.Drawing.Point(463, 677);
            this.orderNumberBox.Name = "orderNumberBox";
            this.orderNumberBox.Size = new System.Drawing.Size(100, 20);
            this.orderNumberBox.TabIndex = 8;
            // 
            // shipComboBox
            // 
            this.shipComboBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.shipComboBox.FormattingEnabled = true;
            this.shipComboBox.Items.AddRange(new object[] {
            "Yes",
            "CC",
            "Holding",
            "Picking",
            "Terms",
            "Issues",
            "No",
            " "});
            this.shipComboBox.Location = new System.Drawing.Point(569, 704);
            this.shipComboBox.Name = "shipComboBox";
            this.shipComboBox.Size = new System.Drawing.Size(121, 21);
            this.shipComboBox.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(406, 712);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "CSC Rep";
            // 
            // cscTextBox
            // 
            this.cscTextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cscTextBox.Location = new System.Drawing.Point(463, 705);
            this.cscTextBox.Name = "cscTextBox";
            this.cscTextBox.Size = new System.Drawing.Size(100, 20);
            this.cscTextBox.TabIndex = 11;
            // 
            // notesBox
            // 
            this.notesBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.notesBox.Location = new System.Drawing.Point(696, 690);
            this.notesBox.Multiline = true;
            this.notesBox.Name = "notesBox";
            this.notesBox.Size = new System.Drawing.Size(100, 35);
            this.notesBox.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(696, 674);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Notes";
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button2.Location = new System.Drawing.Point(829, 677);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Update Order";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(569, 684);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Shipped?";
            // 
            // DSRForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 733);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.notesBox);
            this.Controls.Add(this.cscTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.shipComboBox);
            this.Controls.Add(this.orderNumberBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.customerNumberBox);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.excelButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "DSRForm";
            this.Text = "DSRForm";
            this.Load += new System.EventHandler(this.DSRForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button excelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox customerNumberBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox orderNumberBox;
        private System.Windows.Forms.ComboBox shipComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox cscTextBox;
        private System.Windows.Forms.TextBox notesBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
    }
}