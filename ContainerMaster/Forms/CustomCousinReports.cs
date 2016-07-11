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

        string sqlQuery = "SELECT ";
        Table fromTable = new Table();
        // Create dictionarys of the relations for each table
        Dictionary<string, string> SWCCSBIL1relations = new Dictionary<string, string>();
        Dictionary<string, string> SWCCSBIL2relations = new Dictionary<string, string>();
        Dictionary<string, string> SWCCSSTOKrelations = new Dictionary<string, string>();
        Dictionary<string, string> SWCCSPO1relations = new Dictionary<string, string>();

        List<TreeNode> fields = new List<TreeNode>();

        List<Table> tableList = new List<Table>();

        // make sure to check the parent node if any children have been seleted. 
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

        private void InitilizeTableRealtions(Table table)
        {
            if (table.tableName == "SWCCSBIL1") { table.tableRelationList.Add(SWCCSBIL1relations); }
            if (table.tableName == "SWCCSBIL2") { table.tableRelationList.Add(SWCCSBIL2relations); }
            if (table.tableName == "SWCCSSTOK") { table.tableRelationList.Add(SWCCSSTOKrelations); }
            if (table.tableName == "SWCCSPO1")  { table.tableRelationList.Add(SWCCSPO1relations);  }
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
                    foreach(Table alreadyJoined in tableList)
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
            sqlQuery = "SELECT ";

            //foreach (Table table in tableList)
            //{
            //    foreach (string fields in table.fields)
            //    {
            //        if (table.initilized)
            //            sqlQuery += fields + ", \r\n";
            //        else
            //            MessageBox.Show("Could not join " + table.tableName + "\r\n Fields selected for this table will be dropped");
            //    }
            //}
            //sqlQuery += "FROM " + fromTable.tableName + "\r\n";
            //foreach (Table tableJoins in tableList)
            //{
            //    if (tableJoins.fromTable == false)
            //        sqlQuery += tableJoins.joinStatement + "\r\n";
            //}
            //MessageBox.Show(sqlQuery);
            //sqlQuery = string.Empty;
            //tableList.Clear();
            //fromTable = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            //CreateRelations();

            CheckForJoins();
            CreateQuery();
        }

        private void CustomCousinReports_Load(object sender, EventArgs e)
        {
            SWCCSBIL1relations.Add("SWCCSBIL2", "join SWCCSBIL2 on SWCCSBIL2.ordernumber = SWCCSBIL1.ordernumber");

            SWCCSBIL2relations.Add("SWCCSBIL1", "join SWCCSBIL1 on SWCCSBIL1.ordernumber = SWCCSBIL2.ordernumber");
            SWCCSBIL2relations.Add("SWCCSSTOK", "join SWCCSSTOK on SWCCSSTOK.stocknumber = SWCCSBIL2.stockordered");

            SWCCSSTOKrelations.Add("SWCCSBIL2", "join SWCCSBIL2 on SWCCSBIL2.stockordered = SWCCSSTOK.stocknumber");

            SWCCSPO1relations.Add("SWCCSPO2", "join SWCCSPO2 on SWCCSPO2.ponumber = SWCCSPO1.ponumber");

        }

        List<TreeNode> orderByNodes = new List<TreeNode>();
        private void filtersButton_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            CreateTables(); 
            foreach (Table tables in tableList)
            {
                foreach (TreeNode node in tables.fields)
                {
                    listBox1.Items.Add(node);
                    
                }
            }
        }

        private void CreateComboBox(int row, TreeNode field)
        {
            DataGridViewComboBoxCell CBCell = new DataGridViewComboBoxCell();
            CBCell = dataGridView1.Rows[0].Cells[1] as DataGridViewComboBoxCell;
            CBCell.Items.Add(field);
        }

        private void addOrderButton_Click(object sender, EventArgs e)
        {
            listBox2.Items.Add(listBox1.SelectedItem);
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void removeOrderButton_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(listBox2.SelectedItem);
            listBox2.Items.Remove(listBox2.SelectedItem);
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

