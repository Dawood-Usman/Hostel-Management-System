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
    public partial class AdminStudent_EditStudent : Form
    {
        public string cs = "Data Source=DAWOOD-WORLD\\SQLEXPRESS;Initial Catalog=Hostel_Management_System;Integrated Security=True";

        public AdminStudent_EditStudent()
        {
            InitializeComponent();
            DisableTextBoxes();
        }

        private void AS_EditStudentExit_Click(object sender, EventArgs e)
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

        public void DisableTextBoxes()
        {
            FNTextBox.Enabled = false;
            CnicTextBox.Enabled = false;
            RNTextBox.Enabled = false;
            PassTextBox.Enabled = false;
            CNTextBox.Enabled = false;
            PNTextBox.Enabled = false;
            AddressTextBox.Enabled = false;
            GenderComboBox.Enabled = false;
        }

        public void EnableTextBoxes()
        {
            FNTextBox.Enabled = true;
            CnicTextBox.Enabled = true;
            RNTextBox.Enabled = true;
            PassTextBox.Enabled = true;
            CNTextBox.Enabled = true;
            PNTextBox.Enabled = true;
            AddressTextBox.Enabled = true;
            GenderComboBox.Enabled = true;
        }

        private void EditStdSearchBtn_Click(object sender, EventArgs e)
        {
            string query = "Select * From Student Where Roll_No = @Roll_No;";

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();

            if (ESRollNoTextBox.Text != "")
            {
                try
                {
                    cmd.Parameters.AddWithValue("@Roll_No", ESRollNoTextBox.Text);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        EnableTextBoxes();
                        while (dr.Read())
                        {
                            FNTextBox.Text = dr.GetString(0);
                            CnicTextBox.Text = dr.GetString(1);
                            RNTextBox.Text = dr.GetString(2);
                            PassTextBox.Text = dr.GetString(3);
                            CNTextBox.Text = dr.GetString(4);
                            PNTextBox.Text = dr.GetString(5);
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

        private void EditStudentBtn_Click(object sender, EventArgs e)
        {
            if (!IsTextBoxEmpty())
            {
                string query1 = "Update Student Set Name = @F_name, Cnic = @Cnic, Roll_No = @Roll_No, Password = @Pass, Contact_No = @C_No, Parents_No = @P_No, Address = @Address, Gender = @Gender Where Roll_No = @SRoll_No;";
                string query2 = "Update Student_Login Set Roll_No = @Roll_No, Password = @Pass Where Roll_No = @SRoll_No;";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(query1, con);

                cmd.Parameters.AddWithValue("@SRoll_No", ESRollNoTextBox.Text);

                cmd.Parameters.AddWithValue("@F_name", FNTextBox.Text);
                cmd.Parameters.AddWithValue("@Cnic", CnicTextBox.Text);
                cmd.Parameters.AddWithValue("@Roll_No", RNTextBox.Text);
                cmd.Parameters.AddWithValue("@Pass", PassTextBox.Text);
                cmd.Parameters.AddWithValue("@C_No", CNTextBox.Text);
                cmd.Parameters.AddWithValue("@P_No", PNTextBox.Text);
                cmd.Parameters.AddWithValue("@Address", AddressTextBox.Text);
                cmd.Parameters.AddWithValue("@Gender", GenderComboBox.SelectedItem);

                con.Open();

                try
                {
                    int Effected_Rows = cmd.ExecuteNonQuery();
                    if (Effected_Rows > 0)
                    {
                        SqlCommand cmd1 = new SqlCommand(query2, con);

                        cmd1.Parameters.AddWithValue("@SRoll_No", ESRollNoTextBox.Text);
                        cmd1.Parameters.AddWithValue("@Roll_No", RNTextBox.Text);
                        cmd1.Parameters.AddWithValue("@Pass", PassTextBox.Text);
                        cmd1.ExecuteNonQuery();

                        MessageBox.Show("Student Updated Successfully!");
                        ESRollNoTextBox.Text = "";
                        ClearTextBox();
                        DisableTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Student Updation Failed!");
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
