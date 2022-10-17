﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Hostel_Management_System
{
    public partial class Admin_Login : Form
    {
        public string cs = "Data Source=DAWOOD-WORLD\\SQLEXPRESS;Initial Catalog=Hostel_Management_System;Integrated Security=True";

        public Admin_Login()
        {
            InitializeComponent();
        }

        private void AdminLoginBack_Click(object sender, EventArgs e)
        {
            Welcome f1 = new Welcome();
            f1.Show();
            this.Hide();
        }

        public void ClearTextBox()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        public bool IsTextBoxEmpty()
        {
            if (textBox1.Text == "" || textBox2.Text == "")
                return true;
            else
                return false;
        }

        private void AdminLoginBtn_Click(object sender, EventArgs e)
        {
            string query = "Use Hostel_Management_System; Select * From Admin_Login Where UserName = @user_name And Password = @pass_word";

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(query,con);
            
            cmd.Parameters.AddWithValue("@user_name",textBox1.Text);
            cmd.Parameters.AddWithValue("@pass_word", textBox2.Text);
            
            con.Open();

            if (!IsTextBoxEmpty())
            {
                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows == true)
                    {
                        Admin_Home f1 = new Admin_Home();
                        f1.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Login Failed!");
                        ClearTextBox();
                        textBox1.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                con.Close();
            }
            else
            {
                MessageBox.Show("Fill All Fields!");
            }
        }
    }
}
