namespace CCR
{
    partial class International_PO_log
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
            this.ponumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendornumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateordered = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shipdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalamount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.confirmed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dateconfirmed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.posent = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton900 = new System.Windows.Forms.RadioButton();
            this.radioButton800 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ponumber,
            this.vendornumber,
            this.dateordered,
            this.shipdate,
            this.comments,
            this.totalamount,
            this.confirmed,
            this.dateconfirmed,
            this.posent,
            this.notes});
            this.dataGridView1.Location = new System.Drawing.Point(1, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(874, 498);
            this.dataGridView1.TabIndex = 0;
            // 
            // ponumber
            // 
            this.ponumber.HeaderText = "PO";
            this.ponumber.Name = "ponumber";
            this.ponumber.ReadOnly = true;
            // 
            // vendornumber
            // 
            this.vendornumber.HeaderText = "Vendor";
            this.vendornumber.Name = "vendornumber";
            this.vendornumber.ReadOnly = true;
            // 
            // dateordered
            // 
            this.dateordered.HeaderText = "Order Date";
            this.dateordered.Name = "dateordered";
            this.dateordered.ReadOnly = true;
            // 
            // shipdate
            // 
            this.shipdate.HeaderText = "Required Ship Date";
            this.shipdate.Name = "shipdate";
            this.shipdate.ReadOnly = true;
            // 
            // comments
            // 
            this.comments.HeaderText = "PO Comments";
            this.comments.Name = "comments";
            this.comments.ReadOnly = true;
            // 
            // totalamount
            // 
            this.totalamount.HeaderText = "Total Cost of PO";
            this.totalamount.Name = "totalamount";
            this.totalamount.ReadOnly = true;
            // 
            // confirmed
            // 
            this.confirmed.HeaderText = "Confirmed";
            this.confirmed.Name = "confirmed";
            // 
            // dateconfirmed
            // 
            this.dateconfirmed.HeaderText = "Date Confirmed";
            this.dateconfirmed.Name = "dateconfirmed";
            this.dateconfirmed.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dateconfirmed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // posent
            // 
            this.posent.HeaderText = "New PO Notification Sent";
            this.posent.Items.AddRange(new object[] {
            "Yes",
            "No",
            "N/A"});
            this.posent.Name = "posent";
            this.posent.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.posent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // notes
            // 
            this.notes.HeaderText = "Notes";
            this.notes.Name = "notes";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.Location = new System.Drawing.Point(791, 520);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Update DB";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button2.Location = new System.Drawing.Point(650, 520);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Export to Excel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox1.Controls.Add(this.radioButton900);
            this.groupBox1.Controls.Add(this.radioButton800);
            this.groupBox1.Location = new System.Drawing.Point(535, 507);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(109, 42);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Location";
            // 
            // radioButton900
            // 
            this.radioButton900.AutoSize = true;
            this.radioButton900.Checked = true;
            this.radioButton900.Location = new System.Drawing.Point(55, 16);
            this.radioButton900.Name = "radioButton900";
            this.radioButton900.Size = new System.Drawing.Size(43, 17);
            this.radioButton900.TabIndex = 1;
            this.radioButton900.TabStop = true;
            this.radioButton900.Text = "900";
            this.radioButton900.UseVisualStyleBackColor = true;
            // 
            // radioButton800
            // 
            this.radioButton800.AutoSize = true;
            this.radioButton800.Location = new System.Drawing.Point(6, 16);
            this.radioButton800.Name = "radioButton800";
            this.radioButton800.Size = new System.Drawing.Size(43, 17);
            this.radioButton800.TabIndex = 0;
            this.radioButton800.Text = "800";
            this.radioButton800.UseVisualStyleBackColor = true;
            this.radioButton800.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // International_PO_log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 548);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "International_PO_log";
            this.Text = "International_PO_log";
            this.Load += new System.EventHandler(this.International_PO_log_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ponumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendornumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateordered;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn comments;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalamount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn confirmed;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateconfirmed;
        private System.Windows.Forms.DataGridViewComboBoxColumn posent;
        private System.Windows.Forms.DataGridViewTextBoxColumn notes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton900;
        private System.Windows.Forms.RadioButton radioButton800;
    }
}