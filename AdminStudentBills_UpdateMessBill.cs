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
    public partial class AdminStudentBills_UpdateMessBill : Form
    {
        public string cs = "Data Source=DAWOOD-WORLD\\SQLEXPRESS;Initial Catalog=Hostel_Management_System;Integrated Security=True";

        public AdminStudentBills_UpdateMessBill()
        {
            InitializeComponent();
        }

        private void AB_UpdateMBExit_Click(object sender, EventArgs e)
        {
            Admin_StudentBill f1 = new Admin_StudentBill();
            f1.Show();
            this.Hide();
        }

        public void ClearTextBoxes()
        {
            MonthComboBox.Text = "";
            AmountPMTextBox.Text = "";
            StatusComboBox.Text = "";
        }

        public bool IstextBoxesEmpty()
        {
            if (MonthComboBox.Text == "" || AmountPMTextBox.Text == "" || StatusComboBox.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void UpdateMBBtn_Click(object sender, EventArgs e)
        {
            bool IsUpdated = false;
            string query1 = "INSERT INTO Mess_Fees(Roll_No) Select Roll_No FROM Student;";
            string query2 = "update Mess_Fees set Month = @month, Status = @status, Due_Date = @date, Total_Amount = ( SELECT (COUNT(Roll_No)*@amountpm) FROM Mess_Attendence GROUP BY Roll_No, status HAVING Status = 'Present' And Mess_Fees.Roll_No = Mess_Attendence.Roll_No);";

            SqlConnection con1 = new SqlConnection(cs);
            SqlConnection con2 = new SqlConnection(cs);

            SqlCommand cmd1 = new SqlCommand(query1, con1);
            SqlCommand cmd2 = new SqlCommand(query2, con2);

            cmd2.Parameters.AddWithValue("@month", MonthComboBox.SelectedItem);
            cmd2.Parameters.AddWithValue("@amountpm", AmountPMTextBox.Text);
            cmd2.Parameters.AddWithValue("@status", StatusComboBox.SelectedItem);
            cmd2.Parameters.AddWithValue("@date", DateBox.Text);

            con1.Open();

            if (!IstextBoxesEmpty())
            {
                try
                {
                    int Effected_Rows1 = cmd1.ExecuteNonQuery();
                    if (Effected_Rows1 > 0)
                    {
                        con2.Open();

                        int Effected_Rows2 = cmd2.ExecuteNonQuery();
                        if (Effected_Rows2 > 0)
                        {
                            IsUpdated = true;
                        }
                        else
                        {
                            IsUpdated = false;
                        }

                        con2.Close();
                    }
                    else
                    {
                        IsUpdated = false;
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

                con1.Close();

                if (IsUpdated == true)
                {
                    MessageBox.Show("Mess Fees Updated Successfully!");
                    ClearTextBoxes();
                    MonthComboBox.Focus();
                }
                else
                {
                    MessageBox.Show("Mess Fees Not Updated!");
                }
            }
            else
            {
                MessageBox.Show("Fill All Fields!");
            }
        }
    }
}
