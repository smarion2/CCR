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

        string fromTable;
        int numberOfFields = 0;
        int numberOfFieldsTMP = 0;
        string tables = string.Empty;
        string sqlQuery = "SELECT ";
        string fields = string.Empty;

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
                                numberOfFieldsTMP++;
                                node.Checked = true;
                                //return;
                            }
                        }
                        if (numberOfFieldsTMP > numberOfFields)
                        {
                            fromTable = node.Name;
                            numberOfFields = numberOfFieldsTMP;
                            numberOfFieldsTMP = 0;
                        }

                    }
                    else
                    {

                    }

                }
            }  

        }

        private void GetFieldTableNames()
        {
            foreach (TreeNode node in treeView1.Nodes)
            {
                if (node.Checked == true)
                {
                    tables += node.Name + ",";

                    foreach (TreeNode child in node.Nodes)
                    {
                        if (child.Checked == true)
                        {
                            child.Parent.Checked = true;
                            fields += child.Name + ", " + "as '" + child.Text + "'";
                        }
                    }
                }
            }
            fields = fields.Substring(0, fields.Length - 2);
            sqlQuery += fields + "\r\n";
            sqlQuery += "FROM " + fromTable + "\r\n";

        }

        private void CheckForJoins()
        {
            char delimiter = ',';
            tables = tables.Replace(fromTable + ",", string.Empty);
            string[] joinTables = tables.Split(delimiter);

            if (fromTable == "SWCCSBIL1")
            {
                foreach (string table in joinTables)
                {
                    if (table == "SWCCSBIL2")
                        sqlQuery += "join SWCCSBIL1 on SWCCSBIL2.ordernumber = SWCCSBIL1.ordernumber \r\n";

                }
            }
            if (fromTable == "SWCCSBIL2")
            {
                foreach (string table in joinTables)
                {
                    if (table == "SWCCSBIL1")
                        sqlQuery += "join SWCCSBIL1 on SWCCSBIL1.ordernumber = SWCSSBIL2.ordernumber \r\n";
                    if (table == "SWCCSTOK")
                        sqlQuery += "join SWCCSBIL2 on SWCCSTOK.stocknumber = SWCCSBIL2.stocknumber";
                }
            }
            
            MessageBox.Show(sqlQuery);



        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckParents();
            GetFieldTableNames();
            CheckForJoins();
        }
    }
}
