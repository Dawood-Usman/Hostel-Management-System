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
    public partial class AdminStudent_AddStudent : Form
    {
        public string cs = "Data Source=DAWOOD-WORLD\\SQLEXPRESS;Initial Catalog=Hostel_Management_System;Integrated Security=True";

        public AdminStudent_AddStudent()
        {
            InitializeComponent();
        }

        private void AS_AddStudentExit_Click(object sender, EventArgs e)
        {
            Admin_Student f1 = new Admin_Student();
            f1.Show();
            this.Hide();
        }

        public void ClearTextBox()
        {
            FNTextBox.Text = "";
            CnicTextBox.Text = "";
            RNTextBox.Text = "";
            PassTextBox.Text = "";
            CNTextBox.Text = "";
            PNTextBox.Text = "";
            AddressTextBox.Text = "";
            GenderComboBox.SelectedItem = "";
        }

        public bool IsTextBoxEmpty()
        {
            if (FNTextBox.Text == "" || CnicTextBox.Text == "" || RNTextBox.Text == "" || PassTextBox.Text == "" || CNTextBox.Text == "" || PNTextBox.Text == "" || AddressTextBox.Text == "" || GenderComboBox.SelectedItem == "")
                return true;
            else
                return false;
        }

        private void AddStudentBtn_Click(object sender, EventArgs e)
        {
            string query1 = "use Hostel_Management_System; Insert Into Student Values(@F_name,@Cnic, @Roll_No, @Pass, @C_No, @P_No, @Address, @Gender);";
            string query2 = "use Hostel_Management_System; Insert Into Student_Login Values(@Roll_No, @Pass);";

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(query1, con);

            cmd.Parameters.AddWithValue("@F_name", FNTextBox.Text);
            cmd.Parameters.AddWithValue("@Cnic", CnicTextBox.Text);
            cmd.Parameters.AddWithValue("@Roll_No", RNTextBox.Text);
            cmd.Parameters.AddWithValue("@Pass", PassTextBox.Text);
            cmd.Parameters.AddWithValue("@C_No", CNTextBox.Text);
            cmd.Parameters.AddWithValue("@P_No", PNTextBox.Text);
            cmd.Parameters.AddWithValue("@Address", AddressTextBox.Text);
            cmd.Parameters.AddWithValue("@Gender", GenderComboBox.SelectedItem);

            con.Open();

            if (!IsTextBoxEmpty())
            {
                try
                {
                    int Rows_Effected = cmd.ExecuteNonQuery();
                    if (Rows_Effected > 0)
                    {
                        MessageBox.Show("Student Added Successfully!");
                        SqlCommand cmd1 = new SqlCommand(query2, con);
                        cmd1.Parameters.AddWithValue("@Roll_No", RNTextBox.Text);
                        cmd1.Parameters.AddWithValue("@Pass", PassTextBox.Text);
                        cmd1.ExecuteNonQuery();
                        ClearTextBox();
                        FNTextBox.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Student Not Added!");
                        FNTextBox.Focus();
                    }
                }
                catch (Exception ex)
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
