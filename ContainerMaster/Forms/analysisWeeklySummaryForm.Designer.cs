namespace CCR.Forms
{
    partial class analysisWeeklySummaryForm
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
            this.headers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.details = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weekNumTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.goButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.headers,
            this.details});
            this.dataGridView1.Location = new System.Drawing.Point(12, 45);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(241, 378);
            this.dataGridView1.TabIndex = 0;
            // 
            // headers
            // 
            this.headers.Frozen = true;
            this.headers.HeaderText = "Summary";
            this.headers.Name = "headers";
            this.headers.ReadOnly = true;
            // 
            // details
            // 
            this.details.Frozen = true;
            this.details.HeaderText = "";
            this.details.Name = "details";
            this.details.ReadOnly = true;
            // 
            // weekNumTextBox
            // 
            this.weekNumTextBox.Location = new System.Drawing.Point(139, 16);
            this.weekNumTextBox.Name = "weekNumTextBox";
            this.weekNumTextBox.Size = new System.Drawing.Size(70, 20);
            this.weekNumTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Week Number (yyyyww)";
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(215, 14);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(38, 23);
            this.goButton.TabIndex = 3;
            this.goButton.Text = "Go";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // analysisWeeklySummaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 458);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.weekNumTextBox);
            this.Controls.Add(this.dataGridView1);
            this.Name = "analysisWeeklySummaryForm";
            this.Text = "Weekly Summary";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn headers;
        private System.Windows.Forms.DataGridViewTextBoxColumn details;
        private System.Windows.Forms.TextBox weekNumTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button goButton;
    }
}