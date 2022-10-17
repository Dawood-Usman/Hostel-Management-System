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
    public partial class AdminStudentBills_ViewHostelBill : Form
    {
        public string cs = "Data Source=DAWOOD-WORLD\\SQLEXPRESS;Initial Catalog=Hostel_Management_System;Integrated Security=True";

        public AdminStudentBills_ViewHostelBill()
        {
            InitializeComponent();
            BindGridView();
        }

        private void AB_ViewHBExit_Click(object sender, EventArgs e)
        {
            Admin_StudentBill f1 = new Admin_StudentBill();
            f1.Show();
            this.Hide();
        }

        public void ClearTextBoxes()
        {
            RNTextBox.Text = "";
            SemesterComboBox.Text = "";
            StatusComboBox.Text = "";
        }

        public bool IstextBoxesEmpty()
        {
            if (RNTextBox.Text == "" || SemesterComboBox.Text == "" || StatusComboBox.Text == "")
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
            string query = "Select * From Hostel_Fees";
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            ViewHostelBillDGV.DataSource = data;
        }

        public void BindGridView1()
        {
            string query = "SELECT * From Hostel_Fees Where Semester = '" + SemesterComboBox.SelectedItem + "' AND Roll_No = '" + RNTextBox.Text + "' And Status = '" + StatusComboBox.SelectedItem + "';";
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            ViewHostelBillDGV.DataSource = data;
        }

        private void VHBSearchBtn_Click(object sender, EventArgs e)
        {
            bool IsStudent = false;
            if (!IstextBoxesEmpty())
            {
                string query1 = "Select * From Student Where Roll_No = @SRollNo";
                string query2 = "SELECT * FROM Hostel_Fees Where Semester = @semester AND Roll_No = @RN And Status = @status";

                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd1 = new SqlCommand(query1, con);
                SqlCommand cmd2 = new SqlCommand(query2, con);

                cmd1.Parameters.AddWithValue("@SRollNo", RNTextBox.Text);

                cmd2.Parameters.AddWithValue("@semester", SemesterComboBox.SelectedItem);
                cmd2.Parameters.AddWithValue("@RN", RNTextBox.Text);
                cmd2.Parameters.AddWithValue("@status", StatusComboBox.Text);

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
