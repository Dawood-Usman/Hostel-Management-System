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
    public partial class AdminGYM_EditStudent : Form
    {
        public string cs = "Data Source=DAWOOD-WORLD\\SQLEXPRESS;Initial Catalog=Hostel_Management_System;Integrated Security=True";

        public AdminGYM_EditStudent()
        {
            InitializeComponent();
            DisableTextBoxes();
        }

        private void AG_EditStudentExit_Click(object sender, EventArgs e)
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

        private void GymEditStdSearchBtn_Click(object sender, EventArgs e)
        {
            string query = "Select * From GYM Where Roll_No = @SRoll_No;";

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();

            if (GymEditStudentSearchTextBox.Text != "")
            {
                try
                {
                    cmd.Parameters.AddWithValue("@SRoll_No", GymEditStudentSearchTextBox.Text);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        EnableTextBoxes();
                        while (dr.Read())
                        {
                            FNTextBox.Text = dr.GetString(0);
                            CnicTextBox.Text = dr.GetString(1);
                            RNTextBox.Text = dr.GetString(2);
                            HeightTextBox.Text = dr.GetValue(3).ToString();
                            CNTextBox.Text = dr.GetString(4);
                            WeightTextBox.Text = dr.GetValue(5).ToString();
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

        private void GymEditStudentBtn_Click(object sender, EventArgs e)
        {
            string query1 = "use Hostel_Management_System; Update GYM Set Name = @F_name, Cnic = @Cnic,Roll_No =  @Roll_No, Height =  @Height, Contact_No =  @C_No, Weight =  @Weight,Address =  @Address,Gender =  @Gender Where Roll_No = @SRoll_No;";

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(query1, con);

            cmd.Parameters.AddWithValue("@SRoll_No", GymEditStudentSearchTextBox.Text);

            cmd.Parameters.AddWithValue("@F_name", FNTextBox.Text);
            cmd.Parameters.AddWithValue("@Cnic", CnicTextBox.Text);
            cmd.Parameters.AddWithValue("@Roll_No", RNTextBox.Text);
            cmd.Parameters.AddWithValue("@Height", HeightTextBox.Text);
            cmd.Parameters.AddWithValue("@C_No", CNTextBox.Text);
            cmd.Parameters.AddWithValue("@Weight", WeightTextBox.Text);
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
                        MessageBox.Show("Student Updated Successfully!");
                        ClearTextBox();
                        DisableTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Student Not Updated!");
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
