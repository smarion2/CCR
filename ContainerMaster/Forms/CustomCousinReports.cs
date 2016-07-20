using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCR
{
    public partial class CustomCousinReports : Form
    {
        public CustomCousinReports()
        {
            InitializeComponent();
        }
        string connectionString = "Data Source=srv-swdb;Initial Catalog=swdb;Persist Security Info=True;User ID=swdb;Password=SouthWare99";
        string sqlQuery = "SELECT ";
        Table fromTable = new Table();
        // Create dictionarys of the relations for each table
        Dictionary<string, string> SWCCSBIL1relations = new Dictionary<string, string>();
        Dictionary<string, string> SWCCSBIL2relations = new Dictionary<string, string>();
        Dictionary<string, string> SWCCSSTOKrelations = new Dictionary<string, string>();
        Dictionary<string, string> SWCCSPO1relations = new Dictionary<string, string>();
        Dictionary<string, string> SWCCSPO2relations = new Dictionary<string, string>();
        Dictionary<string, string> SWCCSHST1relations = new Dictionary<string, string>();
        Dictionary<string, string> SWCCSHST2relations = new Dictionary<string, string>();

        List<TreeNode> fields = new List<TreeNode>();

        List<Table> tableList = new List<Table>();

        // make sure to check the parent node if any children have been seleted. 
        // currently not being called
        private void CheckParents()
        {
            foreach (TreeNode node in treeView1.Nodes)
            {
                if (node.Parent == null)  // if we are at the root node
                {
                    if (HasChildren)
                    {
                        for (int i = 0; i < node.Nodes.Count; i++)
                        {
                            if (node.Nodes[i].Checked == true)
                            {
                                node.Checked = true;
                            }
                        }
                    }
                }
            }
        }

        // find table with the most fields and set it as the from table
        private Table GetFromTable()
        {
            int numberOfFields = 0;
            foreach (Table table in tableList)
            {
                if (table.fields.Count > numberOfFields)
                {
                    fromTable = table;
                    numberOfFields = table.fields.Count;
                }
            }
            fromTable.fromTable = true;
            fromTable.initilized = true;
            return fromTable;
            //Table result = tableList.Find(x => x.tableName == fromTable.tableName);
        }

        private void CreateTables()
        {
            tableList.Clear();
            foreach (TreeNode node in treeView1.Nodes)
            {
                if (node.Checked == true)
                {
                    Table table = new Table();
                    table.tableName = node.Name;
                    foreach (TreeNode child in node.Nodes)
                    {
                        if (child.Checked == true)
                        {
                            child.Parent.Checked = true;
                            table.fields.Add(child);
                        }
                    }
                    tableList.Add(table);
                }
            }
            //fields = fields.Substring(0, fields.Length - 2);


        }

        private void CheckForJoins()
        {
            Table fromTable = GetFromTable();

            foreach (Table table in tableList)
            {
                InitilizeTableRealtions(table);
            }
            foreach (Table initTable in tableList)
            {
                if (initTable.fromTable == false)
                    fromTable.JoinTables(initTable);
            }
            // try to join any tables that where not initialized
            foreach (Table joinToJoin in tableList)
            {
                if (joinToJoin.initilized == false)
                {
                    foreach (Table alreadyJoined in tableList)
                    {
                        if (alreadyJoined.fromTable == false && alreadyJoined.initilized == true)
                        {
                            alreadyJoined.JoinTables(joinToJoin);
                        }
                    }
                }
            }

            //MessageBox.Show(sqlQuery);
        }


        // TO DO Come back to this later after you get the wheres and order bys working
        private void CreateQuery()
        {
            sqlQuery = "SELECT \r\n";

            foreach (Table table in tableList)
            {
                foreach (TreeNode fields in table.fields)
                {
                    if (table.initilized)
                        sqlQuery += "\t" + fields.Name + " as '" + fields.Text + "', \r\n";
                    else
                        MessageBox.Show("Could not join " + table.tableName + "\r\n Fields selected for this table will be dropped");
                }
            }
            sqlQuery = sqlQuery.Substring(0, sqlQuery.Length - 4) + "\r\n";
            sqlQuery += "FROM " + fromTable.tableName + "\r\n";
            foreach (Table tableJoins in tableList)
            {
                if (tableJoins.fromTable == false)
                    sqlQuery += tableJoins.joinStatement + "\r\n";
            }
            sqlQuery += whereClause;
            if (orderByFields.Count > 0)
            {
                sqlQuery += "Order by ";
                foreach (string orderby in orderByFields)
                {
                    sqlQuery += orderby + ",";
                }
                sqlQuery = sqlQuery.TrimEnd(',');
            }
            //MessageBox.Show(sqlQuery);
            DataTable dt = GetData.ExecuteQuery(sqlQuery, connectionString);
            if (checkBox1.Checked == true)
            {
                CreateContainer c = new CreateContainer();
                c.AddToDataTable(dt);
               // AddContainer.ToDataTable(dt);
            }
            DataTableToExcel.ExportToExcel(dt);
            sqlQuery = string.Empty;
            tableList.Clear();
            fromTable = null;
        }

        // user is done creating query time to see how it looks... 
        List<string> orderByFields = new List<string>();
        private void button1_Click(object sender, EventArgs e)
        {
            fromTable = null;            
            CreateOrderByFields();
            CreateWhereClause();
            CheckForJoins();
            CreateQuery();
        }

        string whereClause = string.Empty;
        private void CreateWhereClause()
        {
            whereClause = string.Empty;
            for (int i = 0; i < filterIndex; i++)
            {
                whereClause += dataGridView1.Rows[i].Cells[0].Value + " " + filterFields[dataGridView1.Rows[i].Cells[1].Value.ToString()].ToString() + " " + dataGridView1.Rows[i].Cells[2].Value + " '" + dataGridView1.Rows[i].Cells[3].Value + "'\r\n";
            }
        }


        // translate pretty user text to database field name
        private void CreateOrderByFields()
        {
            foreach (string item in listBox2.Items)
            {
                //string orderByField = string.Empty;
                if (filterFields.ContainsKey(item))
                {
                    orderByFields.Add(filterFields[item]);
                }
            }
        }

        // after user has selected fields create a list of them to be filtered upon
        Dictionary<string, string> filterFields = new Dictionary<string, string>();
        private void filtersButton_Click(object sender, EventArgs e)
        {
            filterFields.Clear();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            CreateTables();
            CreateFilterFields();
            foreach (KeyValuePair<string, string> fields in filterFields)
            {
                listBox1.Items.Add(fields.Key);
                CreateComboBox(0, fields);
            }
        }
        // method to populate combobox for fields to filter by?
        private void CreateComboBox(int row, KeyValuePair<string, string> fields)
        {
            DataGridViewComboBoxCell CBCell = new DataGridViewComboBoxCell();
            CBCell = dataGridView1.Rows[row].Cells[1] as DataGridViewComboBoxCell;
            CBCell.Items.Add(fields.Key);
        }

        // event for when a row is added to datagridview1
        int filterIndex = 0;
        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dataGridView1.Rows[0].Cells[0].Value = "WHERE";
            filterIndex++;
            foreach (var fields in filterFields)
            {
                CreateComboBox(filterIndex, fields);
            }
        }

        // user adds order by field
        private void addOrderButton_Click(object sender, EventArgs e)
        {
            listBox2.Items.Add(listBox1.SelectedItem);
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        // user removes order by field
        private void removeOrderButton_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(listBox2.SelectedItem);
            listBox2.Items.Remove(listBox2.SelectedItem);
        }

        private void CreateFilterFields()
        {
            foreach (Table tables in tableList)
            {
                foreach (TreeNode node in tables.fields)
                {
                    filterFields.Add(node.Text, node.Name);
                }
            }
        }

        private void CustomCousinReports_Load(object sender, EventArgs e)
        {
            SWCCSBIL1relations.Add("SWCCSBIL2", "join SWCCSBIL2 on SWCCSBIL2.ordernumber = SWCCSBIL1.ordernumber");

            SWCCSBIL2relations.Add("SWCCSBIL1", "join SWCCSBIL1 on SWCCSBIL1.ordernumber = SWCCSBIL2.ordernumber");
            SWCCSBIL2relations.Add("SWCCSSTOK", "join SWCCSSTOK on SWCCSSTOK.stocknumber = SWCCSBIL2.stockordered");
            //SWCCSBIL2relations.Add("SWCCSPO2", "join SWCCSPO2 on SWCCSPO2.stocknumber = SWCCSBIL2.stockordered");

            SWCCSSTOKrelations.Add("SWCCSBIL2", "join SWCCSBIL2 on SWCCSBIL2.stockordered = SWCCSSTOK.stocknumber");
            SWCCSSTOKrelations.Add("SWCCSPO2", "join SWCCSPO2 on SWCCSPO2.stocknumber = SWCCSSTOK.stocknumber");

            SWCCSPO1relations.Add("SWCCSPO2", "join SWCCSPO2 on SWCCSPO2.ponumber = SWCCSPO1.ponumber");

            SWCCSPO2relations.Add("SWCCSPO1", "join SWCCSPO1 on SWCCSPO1.ponumber = SWCCSPO2.ponumber");
            SWCCSPO2relations.Add("SWCCSSTOK", "join SWCCSSTOK on SWCCSSTOK.stocknumber = SWCCSPO2.stocknumber");
            //SWCCSPO2relations.Add("SWCCSBIL2", "join SWCCSBIL2 on SWCCSBIL2.stockordered = SWCCSPO2.stocknumber");

            SWCCSHST1relations.Add("SWCCSHST2", "join SWCCSHST2 on SWCCSHST2.invoicenumber = SWCCSHST1.invoicenumber");

            SWCCSHST2relations.Add("SWCCSHST1", "join SWCCSHST1 on SWCCSHST1.invoicenumber = SWCCSHST2.invoicenumber");
            SWCCSHST2relations.Add("SWCCSSTOK", "join SWCCSSTOK on SWCCSSTOK.stocknumber = SWCCSHST2.itemidstocksvc");

        }

        private void InitilizeTableRealtions(Table table)
        {
            if (table.tableName == "SWCCSBIL1") { table.tableRelationList.Add(SWCCSBIL1relations); }
            if (table.tableName == "SWCCSBIL2") { table.tableRelationList.Add(SWCCSBIL2relations); }
            if (table.tableName == "SWCCSSTOK") { table.tableRelationList.Add(SWCCSSTOKrelations); }
            if (table.tableName == "SWCCSPO1") { table.tableRelationList.Add(SWCCSPO1relations); }
            if (table.tableName == "SWCCSPO2") { table.tableRelationList.Add(SWCCSPO2relations); }
            if (table.tableName == "SWCCSHST2") { table.tableRelationList.Add(SWCCSHST2relations); }
            if (table.tableName == "SWCCSHST1") { table.tableRelationList.Add(SWCCSHST1relations); }
        }


    }



    class Table
    {
        public bool fromTable = false;
        public bool initilized = false;
        public string tableName { get; set; }

        private string _joinStatement;
        public string joinStatement { get { return this._joinStatement; } }


        public List<TreeNode> fields = new List<TreeNode>();
        public List<Dictionary<string, string>> tableRelationList = new List<Dictionary<string, string>>();

        public void JoinTables(Table tableToJoin)
        {
            foreach (Dictionary<string, string> relations in tableRelationList)
            {
                string joinStatement;
                if (relations.TryGetValue(tableToJoin.tableName, out joinStatement))
                {
                    tableToJoin._joinStatement = joinStatement;
                    tableToJoin.initilized = true;
                    break;
                }
            }
        }
    }

}

