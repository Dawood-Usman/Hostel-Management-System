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
    public partial class SPF_PayHostelFees : Form
    {
        public string cs = "Data Source=DAWOOD-WORLD\\SQLEXPRESS;Initial Catalog=Hostel_Management_System;Integrated Security=True";

        public string FStatus;
        public int FAmount;
        public bool IsMonth = false;

        public SPF_PayHostelFees()
        {
            InitializeComponent();
            RNTextBox.Text = Student_Login.Current_Student;
        }

        private void SV_PayHFExit_Click(object sender, EventArgs e)
        {
            Student_PayFees f1 = new Student_PayFees();
            f1.Show();
            this.Hide();
        }

        public void ClearTextBoxes()
        {
            RNTextBox.Text = "";
            AmountTextBox.Text = "";
            SemesterComboBox.Text = "";
            PaymentMethodComboBox.Text = "";
            TransactionRefNoTextBox.Text = "";
        }

        public bool IsTextBoxesEmpty()
        {
            if (RNTextBox.Text == "" || AmountTextBox.Text == "" || SemesterComboBox.Text == "" || PaymentMethodComboBox.Text == "" || TransactionRefNoTextBox.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Fees_Validations()
        {

            string query1 = "Select * From Hostel_Fees Where Roll_No = @SRollNo And Semester = @semester";

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd1 = new SqlCommand(query1, con);

            cmd1.Parameters.AddWithValue("@SRollNo", Student_Login.Current_Student);
            cmd1.Parameters.AddWithValue("@semester", SemesterComboBox.SelectedItem);

            con.Open();
            try
            {
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        FStatus = dr.GetString(3);
                        FAmount = Convert.ToInt32(dr.GetValue(2));
                    }
                    IsMonth = true;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            con.Close();
        }

        private void HostelFeesSubmitBtn_Click(object sender, EventArgs e)
        {
            if (!IsTextBoxesEmpty())
            {
                Fees_Validations();
                if (IsMonth == true)
                {
                    if (AmountTextBox.Text == FAmount.ToString() && FStatus == "Not Paid")
                    {
                        string query1 = "Update Hostel_Fees Set Status = 'Paid' Where Roll_No = @SRollNo And Semester = @semester";

                        SqlConnection con = new SqlConnection(cs);
                        SqlCommand cmd1 = new SqlCommand(query1, con);

                        cmd1.Parameters.AddWithValue("@SRollNo", Student_Login.Current_Student);
                        cmd1.Parameters.AddWithValue("@semester", SemesterComboBox.SelectedItem);

                        con.Open();
                        try
                        {
                            int Effected_Rows = cmd1.ExecuteNonQuery();
                            if (Effected_Rows > 0)
                            {
                                MessageBox.Show("Fees Transaction Successfull!");
                                ClearTextBoxes();
                            }
                            else
                            {
                                MessageBox.Show("Fees Transaction Error!");
                            }
                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show(Ex.Message);
                        }
                        con.Close();
                    }
                    else if (AmountTextBox.Text != FAmount.ToString() && FStatus == "Not Paid")
                    {
                        MessageBox.Show("Enter Exact Fees Amount!");
                    }
                    else if (AmountTextBox.Text == FAmount.ToString() && FStatus == "Paid")
                    {
                        MessageBox.Show("Fees Already Paid!");
                        ClearTextBoxes();
                    }
                    else if (AmountTextBox.Text != FAmount.ToString() && FStatus == "Paid")
                    {
                        MessageBox.Show("Fees Already Paid!");
                        ClearTextBoxes();
                    }
                }
                else
                {
                    MessageBox.Show("Enter Correct Semester!");
                }
            }
            else
            {
                MessageBox.Show("Fill All Fields!");
            }
            RNTextBox.Focus();
        }
    }
}
