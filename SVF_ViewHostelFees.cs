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
    public partial class SVF_ViewHostelFees : Form
    {
        public string cs = "Data Source=DAWOOD-WORLD\\SQLEXPRESS;Initial Catalog=Hostel_Management_System;Integrated Security=True";

        public SVF_ViewHostelFees()
        {
            InitializeComponent();
            BindGridView();
        }

        private void SV_ViewHFExit_Click(object sender, EventArgs e)
        {
            Student_ViewFees f1 = new Student_ViewFees();
            f1.Show();
            this.Hide();
        }

        public void ClearTextBoxes()
        {
            SemesterComboBox.Text = "";
            StatusComboBox.Text = "";
        }

        public bool IstextBoxesEmpty()
        {
            if (SemesterComboBox.Text == "" || StatusComboBox.Text == "")
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
            string query = "Select * From Hostel_Fees Where Roll_No = '" + Student_Login.Current_Student + "';";
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            ViewHostelFeesDGV.DataSource = data;
        }

        public void BindGridView1()
        {
            string query = "SELECT * From Hostel_Fees Where Semester = '" + SemesterComboBox.SelectedItem + "' AND Roll_No = '" + Student_Login.Current_Student + "' And Status = '" + StatusComboBox.SelectedItem + "';";
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            ViewHostelFeesDGV.DataSource = data;
        }

        private void VHBSearchBtn_Click(object sender, EventArgs e)
        {
            if (!IstextBoxesEmpty())
            {
                string query2 = "SELECT * FROM Hostel_Fees Where Semester = @semester AND Roll_No = @RN And Status = @status";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd2 = new SqlCommand(query2, con);

                cmd2.Parameters.AddWithValue("@semester", SemesterComboBox.SelectedItem);
                cmd2.Parameters.AddWithValue("@RN", Student_Login.Current_Student);
                cmd2.Parameters.AddWithValue("@status", StatusComboBox.Text);

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
                        MessageBox.Show("Fees Not Paid!");
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
