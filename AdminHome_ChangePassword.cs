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

namespace Hostel_Management_System
{
    public partial class AdminHome_ChangePassword : Form
    {
        public string cs = "Data Source=DAWOOD-WORLD\\SQLEXPRESS;Initial Catalog=Hostel_Management_System;Integrated Security=True";

        public AdminHome_ChangePassword()
        {
            InitializeComponent();
        }

        private void AH_ChangePassExit_Click(object sender, EventArgs e)
        {
            Admin_Home f1 = new Admin_Home();
            f1.Show();
            this.Hide();
        }

        public void EmptyTextBoxes()
        {
            UNTextBox.Text = "";
            CurrPassTextBox.Text = "";
            NewPassTextBox.Text = "";
            CNewPassTextBox.Text = "";
        }

        public bool IsTextBoxEmpty()
        {
            if (UNTextBox.Text == "" || CurrPassTextBox.Text == "" || NewPassTextBox.Text == "" || CNewPassTextBox.Text == "")
                return true;
            else
                return false;
        }

        private void ChangePassBtn_Click(object sender, EventArgs e)
        {
            string query1 = "Select * From Admin Where UserName = @User_Name And PassWord = @Pass_Word;";

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(query1, con);

            cmd.Parameters.AddWithValue("@User_Name", UNTextBox.Text);
            cmd.Parameters.AddWithValue("@Pass_Word", CurrPassTextBox.Text);


            if (!IsTextBoxEmpty())
            {
                try
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if(dr.HasRows)
                    {
                        con.Close();
                        if(NewPassTextBox.Text == CNewPassTextBox.Text)
                        {
                            con.Open();
                            string query2 = "Update Admin_Login Set PassWord = @Pass_Word Where UserName = @User_Name";
                            SqlCommand cmd1 = new SqlCommand(query2, con);

                            cmd1.Parameters.AddWithValue("@User_Name", UNTextBox.Text);
                            cmd1.Parameters.AddWithValue("@Pass_Word", NewPassTextBox.Text);

                            int Effected_Rows = cmd1.ExecuteNonQuery();
                            if(Effected_Rows > 0)
                            {
                                MessageBox.Show("Password Changed Successfully!");                      
                            }
                            else
                            {
                                MessageBox.Show("Password Didn't Change!");
                            }
                            EmptyTextBoxes();
                            con.Close();
                        }
                        else
                        {
                            MessageBox.Show("New Password & Confirm Password Didn't Match!");
                            EmptyTextBoxes();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Admin Of Such UserName Or Password Exist!");
                        EmptyTextBoxes();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Fill All The Fields!");
            }
        }
    }
}
