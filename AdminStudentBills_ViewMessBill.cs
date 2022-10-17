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
    public partial class AdminStudentBills_ViewMessBill : Form
    {
        public string cs = "Data Source=DAWOOD-WORLD\\SQLEXPRESS;Initial Catalog=Hostel_Management_System;Integrated Security=True";

        public AdminStudentBills_ViewMessBill()
        {
            InitializeComponent();
            BindGridView();
        }

        private void AB_ViewMBExit_Click(object sender, EventArgs e)
        {
            Admin_StudentBill f1 = new Admin_StudentBill();
            f1.Show();
            this.Hide();
        }
        public void ClearTextBoxes()
        {
            RNTextBox.Text = "";
            MonthComboBox.Text = "";
            YearComboBox.Text = "";
            StatusComboBox.Text = "";
        }

        public bool IstextBoxesEmpty()
        {
            if (RNTextBox.Text == "" || MonthComboBox.Text == "" || YearComboBox.Text == "" || StatusComboBox.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void BindGridView()
        {
            string query = "Select * FROM Mess_Fees";
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            ViewMessBillDGV.DataSource = data;
        }

        public void BindGridView1()
        {
            string query = "SELECT * From Mess_Fees Where MONTH(Due_Date) = " + MonthComboBox.SelectedItem + " AND YEAR(Due_Date) = " + YearComboBox.SelectedItem + " AND Roll_No = '" + RNTextBox.Text + "' And Status = '" + StatusComboBox.SelectedItem + "';";

            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            ViewMessBillDGV.DataSource = data;
            con.Close();
        }

        private void VMBSearchBtn_Click(object sender, EventArgs e)
        {
            bool IsStudent = false;
            if (!IstextBoxesEmpty())
            {
                string query1 = "Select * From Student Where Roll_No = @SRollNo";
                string query2 = "SELECT * FROM Mess_Fees Where MONTH(Due_Date) = @month AND YEAR(Due_Date) = @year AND Roll_No = @RN And Status = @status";

                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd1 = new SqlCommand(query1, con);
                SqlCommand cmd2 = new SqlCommand(query2, con);

                cmd1.Parameters.AddWithValue("@SRollNo", RNTextBox.Text);

                cmd2.Parameters.AddWithValue("@month", MonthComboBox.SelectedItem);
                cmd2.Parameters.AddWithValue("@year", YearComboBox.SelectedItem);
                cmd2.Parameters.AddWithValue("@RN", RNTextBox.Text);
                cmd2.Parameters.AddWithValue("@status", StatusComboBox.SelectedItem);

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
                        SqlDataReader dr2 = cmd2.ExecuteReader();
                        if (dr2.HasRows)
                        {
                            BindGridView1();
                        }
                        else
                        {
                            MessageBox.Show("Bill Not Added!");
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
