namespace CCR
{
    partial class BarcodeForm
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
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.barcode = new System.Windows.Forms.GroupBox();
            this.encodingComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.widthTextBox = new System.Windows.Forms.TextBox();
            this.heightTextBox = new System.Windows.Forms.TextBox();
            this.previewButton = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.fontTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(310, 172);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // barcode
            // 
            this.barcode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.barcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barcode.Location = new System.Drawing.Point(310, 0);
            this.barcode.Name = "barcode";
            this.barcode.Size = new System.Drawing.Size(348, 172);
            this.barcode.TabIndex = 36;
            this.barcode.TabStop = false;
            this.barcode.Text = "Sample Barcode";
            // 
            // encodingComboBox
            // 
            this.encodingComboBox.FormattingEnabled = true;
            this.encodingComboBox.Items.AddRange(new object[] {
            "UPC-A",
            "UPC-E",
            "UPC 2 Digit Ext.",
            "UPC 5 Digit Ext.",
            "EAN-13",
            "JAN-13",
            "EAN-8",
            "ITF-14",
            "Interleaved 2 of 5",
            "Standard 2 of 5",
            "Codabar",
            "PostNet",
            "Bookland/ISBN",
            "Code 11",
            "Code 39",
            "Code 39 Extended",
            "Code 39 Mod 43",
            "Code 93",
            "Code 128",
            "Code 128-A",
            "Code 128-B",
            "Code 128-C",
            "LOGMARS",
            "MSI",
            "Telepen",
            "FIM",
            "Pharmacode"});
            this.encodingComboBox.Location = new System.Drawing.Point(13, 35);
            this.encodingComboBox.Name = "encodingComboBox";
            this.encodingComboBox.Size = new System.Drawing.Size(121, 21);
            this.encodingComboBox.TabIndex = 2;
            this.encodingComboBox.Text = "UPC-A";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Encoding";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(167, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Width";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(208, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "x";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(222, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Height";
            // 
            // widthTextBox
            // 
            this.widthTextBox.Location = new System.Drawing.Point(170, 35);
            this.widthTextBox.Name = "widthTextBox";
            this.widthTextBox.Size = new System.Drawing.Size(32, 20);
            this.widthTextBox.TabIndex = 7;
            this.widthTextBox.Text = "300";
            // 
            // heightTextBox
            // 
            this.heightTextBox.Location = new System.Drawing.Point(225, 36);
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.Size = new System.Drawing.Size(36, 20);
            this.heightTextBox.TabIndex = 8;
            this.heightTextBox.Text = "150";
            // 
            // previewButton
            // 
            this.previewButton.Location = new System.Drawing.Point(16, 101);
            this.previewButton.Name = "previewButton";
            this.previewButton.Size = new System.Drawing.Size(75, 46);
            this.previewButton.TabIndex = 9;
            this.previewButton.Text = "Preview Changes";
            this.previewButton.UseVisualStyleBackColor = true;
            this.previewButton.Click += new System.EventHandler(this.previewButton_Click);
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(115, 103);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(75, 42);
            this.createButton.TabIndex = 10;
            this.createButton.Text = "Create Barcodes";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(113, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Font Size";
            // 
            // fontTextBox
            // 
            this.fontTextBox.Location = new System.Drawing.Point(170, 62);
            this.fontTextBox.Name = "fontTextBox";
            this.fontTextBox.Size = new System.Drawing.Size(32, 20);
            this.fontTextBox.TabIndex = 38;
            this.fontTextBox.Text = "10";
            // 
            // BarcodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 172);
            this.Controls.Add(this.fontTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.previewButton);
            this.Controls.Add(this.heightTextBox);
            this.Controls.Add(this.widthTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.encodingComboBox);
            this.Controls.Add(this.barcode);
            this.Controls.Add(this.splitter1);
            this.Name = "BarcodeForm";
            this.Text = "BarcodeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.GroupBox barcode;
        private System.Windows.Forms.ComboBox encodingComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox widthTextBox;
        private System.Windows.Forms.TextBox heightTextBox;
        private System.Windows.Forms.Button previewButton;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox fontTextBox;
    }
}