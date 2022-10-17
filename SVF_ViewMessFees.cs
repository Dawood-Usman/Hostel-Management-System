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
    public partial class SVF_ViewMessFees : Form
    {
        public string cs = "Data Source=DAWOOD-WORLD\\SQLEXPRESS;Initial Catalog=Hostel_Management_System;Integrated Security=True";

        public SVF_ViewMessFees()
        {
            InitializeComponent();
            BindGridView();
        }

        private void SV_ViewMFExit_Click(object sender, EventArgs e)
        {
            Student_ViewFees f1 = new Student_ViewFees();
            f1.Show();
            this.Hide();
        }

        public void ClearTextBoxes()
        {
            MonthComboBox.Text = "";
            YearComboBox.Text = "";
            StatusComboBox.Text = "";
        }

        public bool IstextBoxesEmpty()
        {
            if (MonthComboBox.Text == "" || YearComboBox.Text == "" || StatusComboBox.Text == "")
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
            string query = "Select * FROM Mess_Fees Where Roll_No = '" + Student_Login.Current_Student + "';";
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            ViewMessFeesDGV.DataSource = data;
        }

        public void BindGridView1()
        {
            string query = "SELECT * From Mess_Fees Where MONTH(Due_Date) = " + MonthComboBox.SelectedItem + " AND YEAR(Due_Date) = " + YearComboBox.SelectedItem + " AND Roll_No = '" + Student_Login.Current_Student + "' And Status = '" + StatusComboBox.SelectedItem + "';";

            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            ViewMessFeesDGV.DataSource = data;
            con.Close();
        }

        private void VMBSearchBtn_Click(object sender, EventArgs e)
        {
            if (!IstextBoxesEmpty())
            {
                string query2 = "SELECT * FROM Mess_Fees Where MONTH(Due_Date) = @month AND YEAR(Due_Date) = @year AND Roll_No = @RN And Status = @status";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd2 = new SqlCommand(query2, con);

                cmd2.Parameters.AddWithValue("@month", MonthComboBox.SelectedItem);
                cmd2.Parameters.AddWithValue("@year", YearComboBox.SelectedItem);
                cmd2.Parameters.AddWithValue("@RN", Student_Login.Current_Student);
                cmd2.Parameters.AddWithValue("@status", StatusComboBox.SelectedItem);

                try
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
