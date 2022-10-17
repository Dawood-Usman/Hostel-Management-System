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
    public partial class Admin_HostelExpenses : Form
    {
        public string cs = "Data Source=DAWOOD-WORLD\\SQLEXPRESS;Initial Catalog=Hostel_Management_System;Integrated Security=True";

        public Admin_HostelExpenses()
        {
            InitializeComponent();
            BindGridView();
        }

        private void AH_Admin_Click(object sender, EventArgs e)
        {
            Admin_Home f1 = new Admin_Home();
            f1.Show();
            this.Hide();
        }

        private void AH_Student_Click(object sender, EventArgs e)
        {
            Admin_Student f1 = new Admin_Student();
            f1.Show();
            this.Hide();
        }

        private void AH_Visitor_Click(object sender, EventArgs e)
        {
            Admin_Visitor f1 = new Admin_Visitor();
            f1.Show();
            this.Hide();
        }

        private void AH_Rooms_Click(object sender, EventArgs e)
        {
            Admin_Rooms f1 = new Admin_Rooms();
            f1.Show();
            this.Hide();
        }

        private void AH_GYM_Click(object sender, EventArgs e)
        {
            Admin_GYM f1 = new Admin_GYM();
            f1.Show();
            this.Hide();
        }

        private void AH_Attendence_Click(object sender, EventArgs e)
        {
            Admin_Attendence f1 = new Admin_Attendence();
            f1.Show();
            this.Hide();
        }

        private void AH_StudentBills_Click(object sender, EventArgs e)
        {
            Admin_StudentBill f1 = new Admin_StudentBill();
            f1.Show();
            this.Hide();
        }

        private void AH_Suggestions_Click(object sender, EventArgs e)
        {
            Admin_Suggestions f1 = new Admin_Suggestions();
            f1.Show();
            this.Hide();
        }

        private void AH_LogOut_Click(object sender, EventArgs e)
        {
            Welcome f1 = new Welcome();
            f1.Show();
            this.Close();
        }

        public void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "Select * From Hostel_Expenses;";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            ViewHostelExpensesDGV.DataSource = data;
        }

        public void EmptyTextBoxes()
        {
            DescriptionTextBox.Text = "";
            AccountComboBox.Text = "";
            CategoryComboBox.Text = "";
            AmountTextBox.Text = "";

        }

        public bool IsTextBoxesEmpty()
        {
            if (DescriptionTextBox.Text == "" || AccountComboBox.Text == "" || CategoryComboBox.Text == "" || AmountTextBox.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void AddExpenseBtn_Click(object sender, EventArgs e)
        {
            if(!IsTextBoxesEmpty())
            {
                string query = "INSERT INTO Hostel_Expenses VALUES(@Desc, @Acc, @categ, @amount);";
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(query,con);

                cmd.Parameters.AddWithValue("@Desc",DescriptionTextBox.Text);
                cmd.Parameters.AddWithValue("@Acc", AccountComboBox.SelectedItem);
                cmd.Parameters.AddWithValue("@categ", CategoryComboBox.SelectedItem);
                cmd.Parameters.AddWithValue("@amount", AmountTextBox.Text);

                con.Open();
                try
                {
                    int Effected_Rows = cmd.ExecuteNonQuery();
                    if(Effected_Rows > 0)
                    {
                        BindGridView();
                        EmptyTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Expense Not Added!");
                    }
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("Fill All Fields!");
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
