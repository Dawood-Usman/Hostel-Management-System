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
    public partial class AdminAttendence_ViewMessAttendence : Form
    {
        public string cs = "Data Source=DAWOOD-WORLD\\SQLEXPRESS;Initial Catalog=Hostel_Management_System;Integrated Security=True";
        bool IsStudent = false;
        string query = "Select * From Mess_Attendence;";
        string rn;

        public AdminAttendence_ViewMessAttendence()
        {
            InitializeComponent();
            BindGridView(query);
            //BindGridView1();

        }

        private void AA_ViewMAExit_Click(object sender, EventArgs e)
        {
            Admin_Attendence f1 = new Admin_Attendence();
            f1.Show();
            this.Hide();
        }

        public void ClearTextBoxes()
        {
            RNTextBox.Text = "";
            MonthComboBox.Text = "";
            YearComboBox.Text = "";
        }

        public bool IstextBoxesEmpty()
        {
            if (RNTextBox.Text == "" || MonthComboBox.Text == "" || YearComboBox.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void BindGridView(string query)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            ViewMessAttendenceDGV.DataSource = data;
        }

        public void BindGridView1()
        {
            string query = "SELECT * From Mess_Attendence Where MONTH(A_Date) = " + MonthComboBox.SelectedItem + " AND YEAR(A_Date) = " + YearComboBox.SelectedItem + " AND Roll_No = '" + RNTextBox.Text +"';";
         
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            ViewMessAttendenceDGV.DataSource = data;
            con.Close();
        }

        private void VMASearchBtn_Click(object sender, EventArgs e)
        {
            if (!IstextBoxesEmpty())
            {
                string query1 = "Select * From Student Where Roll_No = @SRollNo";
                string query2 = "SELECT * FROM Mess_Attendence Where MONTH(A_Date) = @month AND YEAR(A_Date) = @year AND Roll_No = @RN";

                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd1 = new SqlCommand(query1, con);
                SqlCommand cmd2 = new SqlCommand(query2, con);

                cmd1.Parameters.AddWithValue("@SRollNo", RNTextBox.Text);

                cmd2.Parameters.AddWithValue("@month", MonthComboBox.SelectedItem);
                cmd2.Parameters.AddWithValue("@year", YearComboBox.SelectedItem);
                cmd2.Parameters.AddWithValue("@RN", RNTextBox.Text);
                rn = RNTextBox.Text;

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
