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
    public partial class AdminGYM_DeleteStudent : Form
    {
        public string cs = "Data Source=DAWOOD-WORLD\\SQLEXPRESS;Initial Catalog=Hostel_Management_System;Integrated Security=True";

        public AdminGYM_DeleteStudent()
        {
            InitializeComponent();
            DisableTextBoxes();
        }

        private void AG_DeleteStudentExit_Click(object sender, EventArgs e)
        {
            Admin_GYM f1 = new Admin_GYM();
            f1.Show();
            this.Hide();
        }

        public void ClearTextBox()
        {
            FNTextBox.Text = "";
            CnicTextBox.Text = "";
            RNTextBox.Text = "";
            HeightTextBox.Text = "";
            CNTextBox.Text = "";
            WeightTextBox.Text = "";
            AddressTextBox.Text = "";
            GenderComboBox.SelectedItem = "";
        }

        public bool IsTextBoxEmpty()
        {
            if (FNTextBox.Text == "" || CnicTextBox.Text == "" || RNTextBox.Text == "" || HeightTextBox.Text == "" || CNTextBox.Text == "" || WeightTextBox.Text == "" || AddressTextBox.Text == "" || GenderComboBox.Text == "")
                return true;
            else
                return false;
        }

        public void DisableTextBoxes()
        {
            FNTextBox.Enabled = false;
            CnicTextBox.Enabled = false;
            RNTextBox.Enabled = false;
            HeightTextBox.Enabled = false;
            CNTextBox.Enabled = false;
            WeightTextBox.Enabled = false;
            AddressTextBox.Enabled = false;
            GenderComboBox.Enabled = false;
        }

        public void EnableTextBoxes()
        {
            FNTextBox.Enabled = true;
            CnicTextBox.Enabled = true;
            RNTextBox.Enabled = true;
            HeightTextBox.Enabled = true;
            CNTextBox.Enabled = true;
            WeightTextBox.Enabled = true;
            AddressTextBox.Enabled = true;
            GenderComboBox.Enabled = true;
        }

        private void GYMDeleteStdSearchBtn_Click(object sender, EventArgs e)
        {
            string query = "Select * From GYM Where Roll_No = @SRoll_No;";

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();

            if (GYMDeleteStdSearchTextBox.Text != "")
            {
                try
                {
                    cmd.Parameters.AddWithValue("@SRoll_No", GYMDeleteStdSearchTextBox.Text);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        EnableTextBoxes();
                        while (dr.Read())
                        {
                            FNTextBox.Text = dr.GetString(0);
                            CnicTextBox.Text = dr.GetString(1);
                            RNTextBox.Text = dr.GetString(2);
                            HeightTextBox.Text = dr.GetString(3);
                            CNTextBox.Text = dr.GetString(4);
                            WeightTextBox.Text = dr.GetString(5);
                            AddressTextBox.Text = dr.GetString(6);
                            GenderComboBox.SelectedItem = dr.GetString(7);
                        }
                    }
                    else
                    {
                        ClearTextBox();
                        DisableTextBoxes();
                        MessageBox.Show("Student Of Such UserName Not Exist!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Enter Roll No First!");
            }
            con.Close();
        }

        private void GymDeleteStudentBtn_Click(object sender, EventArgs e)
        {
            if (!IsTextBoxEmpty())
            {
                string query1 = "Delete From GYM Where Roll_No = @Roll_No;";
                
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(query1, con);

                cmd.Parameters.AddWithValue("@Roll_No", GYMDeleteStdSearchTextBox.Text);

                con.Open();

                try
                {
                    int Effected_Rows = cmd.ExecuteNonQuery();
                    if (Effected_Rows > 0)
                    {
                        MessageBox.Show("Student Deleted Successfully!");
                        GYMDeleteStdSearchTextBox.Text = "";
                        ClearTextBox();
                        DisableTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Student Deletion Failed!");
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
                MessageBox.Show("Search Student First!");
            }
        }
    }
}
