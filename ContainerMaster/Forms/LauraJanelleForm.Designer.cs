namespace CCR
{
    partial class LauraJanelleForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend9 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend10 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.topCustDataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bottom5RB = new System.Windows.Forms.RadioButton();
            this.top5RB = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.salesDataGridView = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.top5GridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.catPieChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label5 = new System.Windows.Forms.Label();
            this.salesBarChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.topCustDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.top5GridView)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.catPieChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesBarChart)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(744, 500);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.topCustDataGridView);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.salesDataGridView);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.top5GridView);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(736, 474);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // topCustDataGridView
            // 
            this.topCustDataGridView.AllowUserToAddRows = false;
            this.topCustDataGridView.AllowUserToDeleteRows = false;
            this.topCustDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.topCustDataGridView.Location = new System.Drawing.Point(16, 273);
            this.topCustDataGridView.Name = "topCustDataGridView";
            this.topCustDataGridView.ReadOnly = true;
            this.topCustDataGridView.Size = new System.Drawing.Size(295, 150);
            this.topCustDataGridView.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bottom5RB);
            this.groupBox1.Controls.Add(this.top5RB);
            this.groupBox1.Location = new System.Drawing.Point(606, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(99, 62);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // bottom5RB
            // 
            this.bottom5RB.AutoSize = true;
            this.bottom5RB.Location = new System.Drawing.Point(6, 35);
            this.bottom5RB.Name = "bottom5RB";
            this.bottom5RB.Size = new System.Drawing.Size(67, 17);
            this.bottom5RB.TabIndex = 1;
            this.bottom5RB.Text = "Bottom 5";
            this.bottom5RB.UseVisualStyleBackColor = true;
            // 
            // top5RB
            // 
            this.top5RB.AutoSize = true;
            this.top5RB.Checked = true;
            this.top5RB.Location = new System.Drawing.Point(6, 11);
            this.top5RB.Name = "top5RB";
            this.top5RB.Size = new System.Drawing.Size(53, 17);
            this.top5RB.TabIndex = 0;
            this.top5RB.TabStop = true;
            this.top5RB.Text = "Top 5";
            this.top5RB.UseVisualStyleBackColor = true;
            this.top5RB.CheckedChanged += new System.EventHandler(this.top5RB_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label4.Location = new System.Drawing.Point(357, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Sales People";
            // 
            // salesDataGridView
            // 
            this.salesDataGridView.AllowUserToAddRows = false;
            this.salesDataGridView.AllowUserToDeleteRows = false;
            this.salesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.salesDataGridView.Location = new System.Drawing.Point(360, 59);
            this.salesDataGridView.Name = "salesDataGridView";
            this.salesDataGridView.ReadOnly = true;
            this.salesDataGridView.Size = new System.Drawing.Size(228, 166);
            this.salesDataGridView.TabIndex = 5;
            this.salesDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.salesDataGridView_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label2.Location = new System.Drawing.Point(13, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Top 5 Grossing Items";
            // 
            // top5GridView
            // 
            this.top5GridView.AllowUserToAddRows = false;
            this.top5GridView.AllowUserToDeleteRows = false;
            this.top5GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.top5GridView.Location = new System.Drawing.Point(13, 59);
            this.top5GridView.Name = "top5GridView";
            this.top5GridView.ReadOnly = true;
            this.top5GridView.Size = new System.Drawing.Size(298, 175);
            this.top5GridView.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label1.Location = new System.Drawing.Point(8, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Laura Janelle at a Glance";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.salesBarChart);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.catPieChart);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(736, 424);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Category\'s percentage sold";
            // 
            // catPieChart
            // 
            chartArea9.Name = "ChartArea1";
            this.catPieChart.ChartAreas.Add(chartArea9);
            legend9.Name = "Legend1";
            this.catPieChart.Legends.Add(legend9);
            this.catPieChart.Location = new System.Drawing.Point(31, 49);
            this.catPieChart.Name = "catPieChart";
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series9.Legend = "Legend1";
            series9.Name = "Series1";
            this.catPieChart.Series.Add(series9);
            this.catPieChart.Size = new System.Drawing.Size(299, 340);
            this.catPieChart.TabIndex = 5;
            this.catPieChart.Text = "Category Percent";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label5.Location = new System.Drawing.Point(13, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(219, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "Top 20 customers by total sales";
            // 
            // salesBarChart
            // 
            chartArea10.Name = "ChartArea1";
            this.salesBarChart.ChartAreas.Add(chartArea10);
            legend10.Name = "Legend1";
            this.salesBarChart.Legends.Add(legend10);
            this.salesBarChart.Location = new System.Drawing.Point(364, 49);
            this.salesBarChart.Name = "salesBarChart";
            series10.ChartArea = "ChartArea1";
            series10.Legend = "Legend1";
            series10.Name = "Series1";
            this.salesBarChart.Series.Add(series10);
            this.salesBarChart.Size = new System.Drawing.Size(338, 295);
            this.salesBarChart.TabIndex = 7;
            this.salesBarChart.Text = "salesBarChart";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(384, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Sales by date";
            // 
            // LauraJanelleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 500);
            this.Controls.Add(this.tabControl1);
            this.Name = "LauraJanelleForm";
            this.Text = "LauraJanelleForm";
            this.Load += new System.EventHandler(this.LauraJanelleForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.topCustDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.top5GridView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.catPieChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesBarChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView top5GridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView salesDataGridView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton bottom5RB;
        private System.Windows.Forms.RadioButton top5RB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart catPieChart;
        private System.Windows.Forms.DataGridView topCustDataGridView;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataVisualization.Charting.Chart salesBarChart;
    }
}