using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data.Common;


namespace talsample1
{
    public partial class loginPage : Form
    {
        public loginPage()
        {
            InitializeComponent();
        }

        private void loginPage_Load(object sender, EventArgs e)
        {
            
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string input_username = txtbusername.Text;
            string input_password = txtbpassword.Text;
            //connecting to mysql database to insert into login table
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server="localhost";
            builder.UserID = "root";
            builder.Password = "root";
            builder.Database = "tal_v2";
            MySqlConnection con = new MySqlConnection(builder.ToString());
            con.Open();

            //insert new user 
            string newlogin_insert_query = "INSERT INTO login_t(loginid, password) VALUES (@loginid, @password)";
            MySqlCommand newlogin_command = new MySqlCommand(newlogin_insert_query, con);
            newlogin_command.CommandText = newlogin_insert_query;
            newlogin_command.Parameters.AddWithValue("@loginid", input_username);
            newlogin_command.Parameters.AddWithValue("@password", input_password);
            newlogin_command.ExecuteNonQuery();
            MessageBox.Show("new login added successfully!");
            txtbusername.Text = "";
            txtbpassword.Text = null;
            

        }
    }
}
