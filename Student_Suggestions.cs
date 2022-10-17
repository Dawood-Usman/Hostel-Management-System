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
    public partial class Student_Suggestions : Form
    {
        public string cs = "Data Source=DAWOOD-WORLD\\SQLEXPRESS;Initial Catalog=Hostel_Management_System;Integrated Security=True";

        public Student_Suggestions()
        {
            InitializeComponent();
            RollNoTextBox.Text = Student_Login.Current_Student;
        }

        private void SS_Home_Click(object sender, EventArgs e)
        {
            Student_Home f1 = new Student_Home();
            f1.Show();
            this.Hide();
        }

        private void SS_Rooms_Click(object sender, EventArgs e)
        {
            Student_Rooms f1 = new Student_Rooms();
            f1.Show();
            this.Hide();
        }

        private void SS_GYM_Click(object sender, EventArgs e)
        {
            Student_GYM f1 = new Student_GYM();
            f1.Show();
            this.Hide();
        }

        private void SS_Attendence_Click(object sender, EventArgs e)
        {
            Student_Attendence f1 = new Student_Attendence();
            f1.Show();
            this.Hide();
        }

        private void SS_ViewFees_Click(object sender, EventArgs e)
        {
            Student_ViewFees f1 = new Student_ViewFees();
            f1.Show();
            this.Hide();
        }

        private void SS_PayFees_Click(object sender, EventArgs e)
        {
            Student_PayFees f1 = new Student_PayFees();
            f1.Show();
            this.Hide();
        }

        private void SS_LogOut_Click(object sender, EventArgs e)
        {
            Welcome f1 = new Welcome();
            f1.Show();
            this.Close();
        }

        public void ClearTextBoxes()
        {
            RollNoTextBox.Text = "";
            TypeComboBox.Text = "";
            SuggestionTextBox.Text = "";
        }

        public bool IsEmpty()
        {
            if(RollNoTextBox.Text == "" || TypeComboBox.Text == "" || SuggestionTextBox.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            string query1 = "Insert Into Suggestions Values(@RollNo,@SType,@SuggestionText)";

            SqlConnection con = new SqlConnection(cs);

            SqlCommand cmd1 = new SqlCommand(query1, con);
          
            cmd1.Parameters.AddWithValue("@RollNo", Student_Login.Current_Student);
            cmd1.Parameters.AddWithValue("@SType", TypeComboBox.SelectedItem);
            cmd1.Parameters.AddWithValue("@SuggestionText", SuggestionTextBox.Text);

            if (!IsEmpty())
            {
                con.Open();
                try
                {
                    int Effected_Rows = cmd1.ExecuteNonQuery();
                    if (Effected_Rows > 0)
                    {
                        MessageBox.Show("Thank You For Submitting Your " + TypeComboBox.SelectedItem + "!");
                    }
                    else
                    {
                        MessageBox.Show(TypeComboBox.SelectedItem + " Not Submitted!");
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
                con.Close();
                ClearTextBoxes();
            }
        }
    }
}
