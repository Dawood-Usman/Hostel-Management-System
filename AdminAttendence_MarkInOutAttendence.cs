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
    public partial class AdminAttendence_MarkInOutAttendence : Form
    {
        public string cs = "Data Source=DAWOOD-WORLD\\SQLEXPRESS;Initial Catalog=Hostel_Management_System;Integrated Security=True";
        bool IsStudent = false;
        public AdminAttendence_MarkInOutAttendence()
        {
            InitializeComponent();
        }

        private void AA_MarkIOAExit_Click(object sender, EventArgs e)
        {
            Admin_Attendence f1 = new Admin_Attendence();
            f1.Show();
            this.Hide();
        }

        public void ClearTextBoxes()
        {
            RNTextBox.Text = "";
            ATComboBox.Text = "";
            StatusComboBox.Text = "";
        }

        public bool IstextBoxesEmpty()
        {
            if(RNTextBox.Text == "" || ATComboBox.Text == "" || StatusComboBox.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void MarkAttendenceBtn_Click(object sender, EventArgs e)
        {
            if(!IstextBoxesEmpty())
            {
                string query1 = "Select * From Student Where Roll_No = @SRollNo";
                string query2 = "Insert Into InOut_Attendence Values(@RN, @AT, @AS, @Date)";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd1 = new SqlCommand(query1, con);
                SqlCommand cmd2 = new SqlCommand(query2, con);

                cmd1.Parameters.AddWithValue("@SRollNo", RNTextBox.Text);

                cmd2.Parameters.AddWithValue("@RN", RNTextBox.Text);
                cmd2.Parameters.AddWithValue("@AT", ATComboBox.SelectedItem);
                cmd2.Parameters.AddWithValue("@AS", StatusComboBox.SelectedItem);
                cmd2.Parameters.AddWithValue("@Date", DateBox.Text);

                try
                {
                    con.Open();
                    SqlDataReader dr1 = cmd1.ExecuteReader();
                    if (dr1.HasRows)
                    {
                        IsStudent = true;
                    }
                    else
                    {
                        IsStudent = false;
                    }
                    con.Close();

                    if (IsStudent == true)
                    {
                        con.Open();
                        int Effected_Rows = cmd2.ExecuteNonQuery();
                        if (Effected_Rows > 0)
                        {
                            MessageBox.Show("Attendence Added!");
                            ClearTextBoxes();
                            RNTextBox.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Attendence Not Added!");
                        }
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("No Such Student Exist!");
                        ClearTextBoxes();
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
        }
    }
}
