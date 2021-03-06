﻿using System;
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
        String constr = "server=localhost;user id=tal;password=taldepo;database=tal_v4;persistsecurityinfo=True;logging=True";
        public loginPage()
        {
            InitializeComponent();
            txtpassword.PasswordChar = '$';
            txtpassword.MaxLength = 10;
        }

        private void loginPage_Load(object sender, EventArgs e)
        {
            
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                purchaseOrderForm pof = new purchaseOrderForm();
                masterUIpage mup = new masterUIpage();
                ReceiverView rv = new ReceiverView();
                
                MySqlConnection loginconn = new MySqlConnection(constr);
                MySqlDataAdapter loginadapter = new MySqlDataAdapter("select role from login where username = '" + txtusername.Text + "' and password='" + txtpassword.Text + "' ;", loginconn);
                DataTable logindatatable = new DataTable();
                loginadapter.Fill(logindatatable);

                if (logindatatable.Rows.Count == 1)
                {
                    if (logindatatable.Rows[0][0].ToString() == "admin") { this.Hide(); pof.Show(); }
                    else if (logindatatable.Rows[0][0].ToString() == "manager") { this.Hide(); mup.Show(); }
                    else if (logindatatable.Rows[0][0].ToString() == "receiver") { this.Hide(); rv.Show(); }
                    //else if(logindatatable.Rows[0][0].ToString()=="picker"){this.Hide(); pv.Show();}
                    //else if(logindatatable.Rows[0][0].ToString()=="packer"){this.Hide(); pkv.Show();}
                    else { MessageBox.Show("Login details are incorrect, Please check your details"); }

                    //if(logindatatable.Rows[0][0].ToString()=="admin"){
                    //purchaseOrderForm pof = new purchaseOrderForm(logindatatable.Rows[0][0].ToString());
                    //this.Hide();
                    //pof.Show();
                    //}

                    //pof.Controls["lblrole"].Text=logindatatable.Rows[0][0].ToString();
                }



                
                
                //MySqlConnection conn = new MySqlConnection(constr); 
                //conn.Open();
                //MySqlCommand sqlcmdchklogin = new MySqlCommand("select role from login where username = '" + txtusername.Text + "' and password='" + txtpassword.Text + "' ;", conn);
                //MySqlDataReader loginDataReader;
                
                //loginDataReader=sqlcmdchklogin.ExecuteReader();
                //int count=0;
                //while(loginDataReader.Read()){//if the entered username and pswd match then cont will go up by only 1
                //    //this would mean that the details are correct.
                //    count+=1;
                //    }
                //Console.WriteLine(loginDataReader.Read());
                //if(count==1){//if details were correct, then depending on who logs in, open a form
                //    loginDataReader.Read();
                //    loginDataReader.ToString();
                //    if (loginDataReader.Equals("admin")) { this.Hide(); pof.Show(); }
    
                //}

                //MySqlDataAdapter loginDataAdapter = new MySqlDataAdapter();
                //loginDataAdapter.SelectCommand = new MySqlCommand("select * from login where username = '" +txtusername.Text+ "' and password='" +txtpassword.Text+ "' ;",conn);
                //MySqlCommandBuilder loginCommandBuilder = new MySqlCommandBuilder(loginDataAdapter);
                //MySqlDataReader loginDataReader = new MySqlDataReader();
                
                //conn.Open();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
            //string input_username = txtbusername.Text;
            //string input_password = txtbpassword.Text;
            ////connecting to mysql database to insert into login table
            //MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            //builder.Server="localhost";
            //builder.UserID = "root";
            //builder.Password = "root";
            //builder.Database = "tal_v2";
            //MySqlConnection con = new MySqlConnection(builder.ToString());
            //con.Open();

            ////insert new user 
            //string newlogin_insert_query = "INSERT INTO login_t(loginid, password) VALUES (@loginid, @password)";
            //MySqlCommand newlogin_command = new MySqlCommand(newlogin_insert_query, con);
            //newlogin_command.CommandText = newlogin_insert_query;
            //newlogin_command.Parameters.AddWithValue("@loginid", input_username);
            //newlogin_command.Parameters.AddWithValue("@password", input_password);
            //newlogin_command.ExecuteNonQuery();
            //MessageBox.Show("new login added successfully!");
            //txtbusername.Text = "";
            //txtbpassword.Text = null;
            

        }
    }
}
