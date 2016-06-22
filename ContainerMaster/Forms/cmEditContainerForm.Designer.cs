namespace CCR
{
    partial class cmEditContainerForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.cmDataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.createImportButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.containerMasterDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmDataGridView)).BeginInit();
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
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 36);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(865, 223);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.UpdateButton.Location = new System.Drawing.Point(669, 403);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(196, 98);
            this.UpdateButton.TabIndex = 2;
            this.UpdateButton.Text = "Update DB";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // cmDataGridView
            // 
            this.cmDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cmDataGridView.Location = new System.Drawing.Point(12, 290);
            this.cmDataGridView.Name = "cmDataGridView";
            this.cmDataGridView.Size = new System.Drawing.Size(448, 211);
            this.cmDataGridView.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(465, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Containers";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(179, 262);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Container Details";
            // 
            // createImportButton
            // 
            this.createImportButton.Location = new System.Drawing.Point(891, 36);
            this.createImportButton.Name = "createImportButton";
            this.createImportButton.Size = new System.Drawing.Size(75, 58);
            this.createImportButton.TabIndex = 6;
            this.createImportButton.Text = "Create import file";
            this.createImportButton.UseVisualStyleBackColor = true;
            this.createImportButton.Click += new System.EventHandler(this.createImportButton_Click);
            // 
            // cmEditContainerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 526);
            this.Controls.Add(this.createImportButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmDataGridView);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "cmEditContainerForm";
            this.Text = "EditContainerForm";
            this.Load += new System.EventHandler(this.cmEditContainerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.containerMasterDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ContainerMasterDS containerMasterDS;
        private System.Windows.Forms.BindingSource dataTable1BindingSource;
        private ContainerMasterDSTableAdapters.DataTable1TableAdapter dataTable1TableAdapter;
        private ContainerMasterDSTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.DataGridView cmDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button createImportButton;
    }
}