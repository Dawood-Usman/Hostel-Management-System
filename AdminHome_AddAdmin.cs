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
    public partial class AdminHome_AddAdmin : Form
    {
        public string cs = "Data Source=DAWOOD-WORLD\\SQLEXPRESS;Initial Catalog=Hostel_Management_System;Integrated Security=True";

        public AdminHome_AddAdmin()
        {
            InitializeComponent();
        }

        private void AH_AddAdminExit_Click(object sender, EventArgs e)
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

        public bool IsTextBoxEmpty()
        {
            if (FNTextBox.Text == "" || LNTextBox.Text == "" || UNTextBox.Text == "" || PassTextBox.Text == "" || EmailTextBox.Text == "" || PhoneTextBox.Text == "" || CnicTextBox.Text == "" || AddressTextBox.Text == "")
                return true;
            else
                return false;
        }

        private void AddAdminBtn_Click(object sender, EventArgs e)
        {
            string query1 = "use Hostel_Management_System; Insert Into Admin Values(@F_name,@L_Name, @U_Name, @Pass, @Email, @P_No, @Cnic, @Address);";
            string query2 = "use Hostel_Management_System; Insert Into Admin_Login Values(@U_Name, @Pass);";

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(query1, con);

            cmd.Parameters.AddWithValue("@F_name", FNTextBox.Text);
            cmd.Parameters.AddWithValue("@L_Name", LNTextBox.Text);
            cmd.Parameters.AddWithValue("@U_Name", UNTextBox.Text);
            cmd.Parameters.AddWithValue("@Pass", PassTextBox.Text);
            cmd.Parameters.AddWithValue("@Email", EmailTextBox.Text);
            cmd.Parameters.AddWithValue("@P_No", PhoneTextBox.Text);
            cmd.Parameters.AddWithValue("@Cnic", CnicTextBox.Text);
            cmd.Parameters.AddWithValue("@Address", AddressTextBox.Text);

            con.Open();

            if (!IsTextBoxEmpty())
            {
                try
                {
                    int Rows_Effected = cmd.ExecuteNonQuery();
                    if(Rows_Effected > 0)
                    {
                        MessageBox.Show("Admin Added Successfully!");
                        SqlCommand cmd1 = new SqlCommand(query2, con);
                        cmd1.Parameters.AddWithValue("@U_Name", UNTextBox.Text);
                        cmd1.Parameters.AddWithValue("@Pass", PassTextBox.Text);
                        cmd1.ExecuteNonQuery();
                        ClearTextBox();
                        FNTextBox.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Admin Not Added!");
                        FNTextBox.Focus();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Fill All Fields!");
            }

            con.Close();
        }
    }
}
