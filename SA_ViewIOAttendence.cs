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
    public partial class SA_ViewIOAttendence : Form
    {
        public string cs = "Data Source=DAWOOD-WORLD\\SQLEXPRESS;Initial Catalog=Hostel_Management_System;Integrated Security=True";

        public SA_ViewIOAttendence()
        {
            InitializeComponent();
            BindGridView();
        }

        private void SA_ViewIOAExit_Click(object sender, EventArgs e)
        {
            Student_Attendence f1 = new Student_Attendence();
            f1.Show();
            this.Hide();
        }

        public void ClearTextBoxes()
        {
            MonthComboBox.Text = "";
            YearComboBox.Text = "";
        }

        public bool IstextBoxesEmpty()
        {
            if (MonthComboBox.Text == "" || YearComboBox.Text == "")
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
            string query = "Select * From InOut_Attendence Where Roll_No = '" + Student_Login.Current_Student + "';";
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            ViewIOADGV.DataSource = data;
        }

        public void BindGridView1()
        {
            string query = "SELECT * From InOut_Attendence Where MONTH(A_Date) = " + MonthComboBox.SelectedItem + " AND YEAR(A_Date) = " + YearComboBox.SelectedItem + " AND Roll_No = '" + Student_Login.Current_Student + "';";
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            ViewIOADGV.DataSource = data;
        }

        private void VIOASearchBtn_Click(object sender, EventArgs e)
        {
            if (!IstextBoxesEmpty())
            {

                string query2 = "SELECT * FROM InOut_Attendence Where MONTH(A_Date) = @month AND YEAR(A_Date) = @year AND Roll_No = @RN";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd2 = new SqlCommand(query2, con);

                cmd2.Parameters.AddWithValue("@month", MonthComboBox.SelectedItem);
                cmd2.Parameters.AddWithValue("@year", YearComboBox.SelectedItem);
                cmd2.Parameters.AddWithValue("@RN", Student_Login.Current_Student);

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
                        MessageBox.Show("Attendence Not Added!");
                    }
                    ClearTextBoxes();
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
