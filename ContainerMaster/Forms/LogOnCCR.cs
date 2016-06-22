using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CCR
{
    public partial class LogOnCCR : Form
    {
        private string userName = string.Empty;
        private string passWord = string.Empty;
        public static Dictionary<string, int> userPermission;
        UserPermissions getPermissions = new UserPermissions();
        private string connectionString = "Data Source = srv-swdb; Initial Catalog = swdb; Persist Security Info=True;User ID = swdb; Password=SouthWare99";
        CPASForm cpasForm = new CPASForm();

        public LogOnCCR()
        {
            InitializeComponent();
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            userName = userNameTextBox.Text;
            passWord = passwordTextBox.Text;
            string query = "Select UserName, Password from CCRlogins where UserName = @0";

            DataTable dt = GetData.ExecuteQuery(query, connectionString, userName);

            if (dt.Rows[0][1].ToString() != passWord)
            {
                MessageBox.Show("User Name / Password combintation does not exists please try again", "Incorrect Login", MessageBoxButtons.OK);
            }
            else
            {
                userPermission = getPermissions.GetSecuritySettings(userName);
                cpasForm.Show();
                Visible = false;
            }              
        }
    }
}
