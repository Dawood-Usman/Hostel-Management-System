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
    public partial class AdminHome_DeleteAdmin : Form
    {
        public string cs = "Data Source=DAWOOD-WORLD\\SQLEXPRESS;Initial Catalog=Hostel_Management_System;Integrated Security=True";

        public AdminHome_DeleteAdmin()
        {
            InitializeComponent();
            DisableTextBoxes();
        }

        private void AH_DeleteAdminExit_Click(object sender, EventArgs e)
        {
            Admin_Home f1 = new Admin_Home();
            f1.Show();
            this.Hide();
        }

        public void ClearTextBox()
        {
            FNTextBox.Text = "";
            LNTextBox.Text = "";
            UNTextBox.Text = "";
            PassTextBox.Text = "";
            EmailTextBox.Text = "";
            PhoneTextBox.Text = "";
            CnicTextBox.Text = "";
            AddressTextBox.Text = "";
        }

        public void DisableTextBoxes()
        {
            FNTextBox.Enabled = false;
            LNTextBox.Enabled = false;
            UNTextBox.Enabled = false;
            PassTextBox.Enabled = false;
            EmailTextBox.Enabled = false;
            PhoneTextBox.Enabled = false;
            CnicTextBox.Enabled = false;
            AddressTextBox.Enabled = false;

        }

        public void EnableTextBoxes()
        {
            FNTextBox.Enabled = true;
            LNTextBox.Enabled = true;
            UNTextBox.Enabled = true;
            PassTextBox.Enabled = true;
            EmailTextBox.Enabled = true;
            PhoneTextBox.Enabled = true;
            CnicTextBox.Enabled = true;
            AddressTextBox.Enabled = true;

        }

        public bool IsTextBoxEmpty()
        {
            if (FNTextBox.Text == "" || LNTextBox.Text == "" || UNTextBox.Text == "" || PassTextBox.Text == "" || EmailTextBox.Text == "" || PhoneTextBox.Text == "" || CnicTextBox.Text == "" || AddressTextBox.Text == "")
                return true;
            else
                return false;
        }

        private void DeleteAdminSearchBtn_Click(object sender, EventArgs e)
        {
            string query = "Select * From Admin Where UserName = @User_Name;";
          
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(query, con);
            
            con.Open();

            if (S_UNTextBox.Text != "")
            {
                try
                {
                    cmd.Parameters.AddWithValue("@User_Name", S_UNTextBox.Text);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        EnableTextBoxes();
                        while (dr.Read())
                        {
                            FNTextBox.Text = dr.GetString(0);
                            LNTextBox.Text = dr.GetString(1);
                            UNTextBox.Text = dr.GetString(2);
                            PassTextBox.Text = dr.GetString(3);
                            EmailTextBox.Text = dr.GetString(4);
                            PhoneTextBox.Text = dr.GetString(5);
                            CnicTextBox.Text = dr.GetString(6);
                            AddressTextBox.Text = dr.GetString(7);
                        }
                    }
                    else
                    {
                        ClearTextBox();
                        DisableTextBoxes();
                        MessageBox.Show("Admin Of Such UserName Not Exist!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Enter UserName First!");
            }

            con.Close();
        }

        private void DeleteAdminBtn_Click(object sender, EventArgs e)
        {
            if(!IsTextBoxEmpty())
            {
                string query1 = "Delete From Admin Where UserName = @User_Name;";
                string query2 = "Delete From Admin_Login Where UserName = @User_Name;";

                SqlConnection con = new SqlConnection(cs);          
                SqlCommand cmd = new SqlCommand(query1, con);
      
                cmd.Parameters.AddWithValue("@User_Name", S_UNTextBox.Text);

                con.Open();

                try
                {
                    int Effected_Rows = cmd.ExecuteNonQuery();
                    if(Effected_Rows > 0)
                    {
                        SqlCommand cmd1 = new SqlCommand(query2, con);
                        cmd1.Parameters.AddWithValue("@User_Name", S_UNTextBox.Text);
                        cmd1.ExecuteNonQuery();

                        MessageBox.Show("Admin Deleted Successfully!");
                        S_UNTextBox.Text = "";
                        ClearTextBox();
                        DisableTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Admin Deletion Failed!");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                con.Close();
            }
            else
            {
                MessageBox.Show("Search Admin First!");
            }
        }
    }
}
