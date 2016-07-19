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
            this.updateButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.CustomerNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordernumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salespersonname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ManagerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.termsdescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreditAppReceived = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weeklyTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usercomment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Shipped = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dateshipped = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CSCrep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trackingnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerNumber,
            this.CustomerName,
            this.ordernumber,
            this.customerPO,
            this.salespersonname,
            this.ManagerName,
            this.category,
            this.termsdescription,
            this.CreditAppReceived,
            this.orderdate,
            this.totalprice,
            this.weeklyTotal,
            this.usercomment,
            this.Shipped,
            this.dateshipped,
            this.Notes,
            this.CSCrep,
            this.trackingnumber});
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(941, 501);
            this.dataGridView1.TabIndex = 0;
            // 
            // excelButton
            // 
            this.excelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.excelButton.Location = new System.Drawing.Point(831, 507);
            this.excelButton.Name = "excelButton";
            this.excelButton.Size = new System.Drawing.Size(93, 23);
            this.excelButton.TabIndex = 1;
            this.excelButton.Text = "Export to Excel";
            this.excelButton.UseVisualStyleBackColor = true;
            // 
            // updateButton
            // 
            this.updateButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.updateButton.Location = new System.Drawing.Point(746, 508);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(73, 23);
            this.updateButton.TabIndex = 2;
            this.updateButton.Text = "Update DB";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 514);
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
            this.comboBox1.Location = new System.Drawing.Point(280, 509);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBox1.Location = new System.Drawing.Point(174, 509);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.Location = new System.Drawing.Point(407, 509);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Update Credit App";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CustomerNumber
            // 
            this.CustomerNumber.HeaderText = "Customer Number";
            this.CustomerNumber.Name = "CustomerNumber";
            this.CustomerNumber.ReadOnly = true;
            // 
            // CustomerName
            // 
            this.CustomerName.HeaderText = "Customer Name";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            // 
            // ordernumber
            // 
            this.ordernumber.HeaderText = "Order ID";
            this.ordernumber.Name = "ordernumber";
            this.ordernumber.ReadOnly = true;
            // 
            // customerPO
            // 
            this.customerPO.HeaderText = "Customer PO";
            this.customerPO.Name = "customerPO";
            this.customerPO.ReadOnly = true;
            // 
            // salespersonname
            // 
            this.salespersonname.HeaderText = "Sales Rep";
            this.salespersonname.Name = "salespersonname";
            this.salespersonname.ReadOnly = true;
            // 
            // ManagerName
            // 
            this.ManagerName.HeaderText = "Sales Manager";
            this.ManagerName.Name = "ManagerName";
            this.ManagerName.ReadOnly = true;
            // 
            // category
            // 
            this.category.HeaderText = "Product purchased";
            this.category.Name = "category";
            this.category.ReadOnly = true;
            // 
            // termsdescription
            // 
            this.termsdescription.HeaderText = "Payment Method";
            this.termsdescription.Name = "termsdescription";
            this.termsdescription.ReadOnly = true;
            // 
            // CreditAppReceived
            // 
            this.CreditAppReceived.HeaderText = "Credit ap recieved";
            this.CreditAppReceived.Name = "CreditAppReceived";
            this.CreditAppReceived.ReadOnly = true;
            this.CreditAppReceived.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // orderdate
            // 
            this.orderdate.HeaderText = "Order Date";
            this.orderdate.Name = "orderdate";
            this.orderdate.ReadOnly = true;
            // 
            // totalprice
            // 
            this.totalprice.HeaderText = "Order Amount";
            this.totalprice.Name = "totalprice";
            this.totalprice.ReadOnly = true;
            // 
            // weeklyTotal
            // 
            this.weeklyTotal.HeaderText = "Weekly Total";
            this.weeklyTotal.Name = "weeklyTotal";
            this.weeklyTotal.ReadOnly = true;
            // 
            // usercomment
            // 
            this.usercomment.HeaderText = "Sales Location";
            this.usercomment.Name = "usercomment";
            this.usercomment.ReadOnly = true;
            // 
            // Shipped
            // 
            this.Shipped.HeaderText = "Shipped";
            this.Shipped.Items.AddRange(new object[] {
            "Yes       ",
            "CC        ",
            "Holding   ",
            "Picking   ",
            "Terms     ",
            "Issues    ",
            "No        "});
            this.Shipped.Name = "Shipped";
            // 
            // dateshipped
            // 
            this.dateshipped.HeaderText = "Date Shipped";
            this.dateshipped.Name = "dateshipped";
            this.dateshipped.ReadOnly = true;
            this.dateshipped.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dateshipped.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Notes
            // 
            this.Notes.HeaderText = "Notes";
            this.Notes.Name = "Notes";
            // 
            // CSCrep
            // 
            this.CSCrep.HeaderText = "CSC Rept";
            this.CSCrep.Name = "CSCrep";
            // 
            // trackingnumber
            // 
            this.trackingnumber.HeaderText = "Tracking Number";
            this.trackingnumber.Name = "trackingnumber";
            this.trackingnumber.ReadOnly = true;
            // 
            // DSRForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 534);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.updateButton);
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
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordernumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn salespersonname;
        private System.Windows.Forms.DataGridViewTextBoxColumn ManagerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn category;
        private System.Windows.Forms.DataGridViewTextBoxColumn termsdescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreditAppReceived;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn weeklyTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn usercomment;
        private System.Windows.Forms.DataGridViewComboBoxColumn Shipped;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateshipped;
        private System.Windows.Forms.DataGridViewTextBoxColumn Notes;
        private System.Windows.Forms.DataGridViewTextBoxColumn CSCrep;
        private System.Windows.Forms.DataGridViewTextBoxColumn trackingnumber;
    }
}