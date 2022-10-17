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
    public partial class Student_GYM : Form
    {
        public string cs = "Data Source=DAWOOD-WORLD\\SQLEXPRESS;Initial Catalog=Hostel_Management_System;Integrated Security=True";

        public Student_GYM()
        {
            InitializeComponent();
            Fill_Data();
        }

        private void SG_Home_Click(object sender, EventArgs e)
        {
            Student_Home f1 = new Student_Home();
            f1.Show();
            this.Hide();
        }

        private void SG_Rooms_Click(object sender, EventArgs e)
        {
            Student_Rooms f1 = new Student_Rooms();
            f1.Show();
            this.Hide();
        }

        private void SG_Attendence_Click(object sender, EventArgs e)
        {
            Student_Attendence f1 = new Student_Attendence();
            f1.Show();
            this.Hide();
        }

        private void SG_ViewFees_Click(object sender, EventArgs e)
        {
            Student_ViewFees f1 = new Student_ViewFees();
            f1.Show();
            this.Hide();
        }

        private void SG_PayFees_Click(object sender, EventArgs e)
        {
            Student_PayFees f1 = new Student_PayFees();
            f1.Show();
            this.Hide();
        }

        private void SG_Suggestions_Click(object sender, EventArgs e)
        {
            Student_Suggestions f1 = new Student_Suggestions();
            f1.Show();
            this.Hide();
        }

        private void SG_LogOut_Click(object sender, EventArgs e)
        {
            Welcome f1 = new Welcome();
            f1.Show();
            this.Close();
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

        public void Fill_Data()
        {
            string query = "Select * From Student Where Roll_No = @SRoll_No;";

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();

            try
            {
                cmd.Parameters.AddWithValue("@SRoll_No", Student_Login.Current_Student);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        FNTextBox.Text = dr.GetString(0);
                        CnicTextBox.Text = dr.GetString(1);
                        RNTextBox.Text = dr.GetString(2);
                        HeightTextBox.Text = "";
                        CNTextBox.Text = dr.GetString(4);
                        WeightTextBox.Text = "";
                        AddressTextBox.Text = dr.GetString(6);
                        GenderComboBox.SelectedItem = dr.GetString(7);
                    }
                }
                else
                {
                    ClearTextBox();
                    MessageBox.Show("Student Of Such UserName Not Exist!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        private void GymRegisterBtn_Click(object sender, EventArgs e)
        {
            if (Student_Home.IsGym == false)
            {
                if (!IsTextBoxEmpty())
                {
                    string query1 = "use Hostel_Management_System; Insert Into GYM Values(@F_name,@Cnic, @Roll_No, @Height, @C_No, @Weight, @Address, @Gender);";

                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand(query1, con);

                    cmd.Parameters.AddWithValue("@F_name", FNTextBox.Text);
                    cmd.Parameters.AddWithValue("@Cnic", CnicTextBox.Text);
                    cmd.Parameters.AddWithValue("@Roll_No", RNTextBox.Text);
                    cmd.Parameters.AddWithValue("@Height", HeightTextBox.Text);
                    cmd.Parameters.AddWithValue("@C_No", CNTextBox.Text);
                    cmd.Parameters.AddWithValue("@Weight", WeightTextBox.Text);
                    cmd.Parameters.AddWithValue("@Address", AddressTextBox.Text);
                    cmd.Parameters.AddWithValue("@Gender", GenderComboBox.SelectedItem);

                    con.Open();
                    try
                    {
                        int Rows_Effected = cmd.ExecuteNonQuery();
                        if (Rows_Effected > 0)
                        {
                            MessageBox.Show("Registered Successfully!");
                            ClearTextBox();
                        }
                        else
                        {
                            MessageBox.Show("Registeration Not Failed!");
                            FNTextBox.Focus();
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
            else
            {
                MessageBox.Show("Already Registered!");
            }
        }
    }
}
