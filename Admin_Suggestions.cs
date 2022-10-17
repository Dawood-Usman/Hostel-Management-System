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
    public partial class Admin_Suggestions : Form
    {
        public string cs = "Data Source=DAWOOD-WORLD\\SQLEXPRESS;Initial Catalog=Hostel_Management_System;Integrated Security=True";

        public Admin_Suggestions()
        {
            InitializeComponent();
            BindGridView();
        }

        private void AS_Admin_Click(object sender, EventArgs e)
        {
            Admin_Home f1 = new Admin_Home();
            f1.Show();
            this.Hide();
        }

        private void AS_Student_Click(object sender, EventArgs e)
        {
            Admin_Student f1 = new Admin_Student();
            f1.Show();
            this.Hide();
        }

        private void AS_Visitor_Click(object sender, EventArgs e)
        {
            Admin_Visitor f1 = new Admin_Visitor();
            f1.Show();
            this.Hide();
        }

        private void AS_Rooms_Click(object sender, EventArgs e)
        {
            Admin_Rooms f1 = new Admin_Rooms();
            f1.Show();
            this.Hide();
        }

        private void AS_GYM_Click(object sender, EventArgs e)
        {
            Admin_GYM f1 = new Admin_GYM();
            f1.Show();
            this.Hide();
        }

        private void AS_Attendence_Click(object sender, EventArgs e)
        {
            Admin_Attendence f1 = new Admin_Attendence();
            f1.Show();
            this.Hide();
        }

        private void AS_StudentBills_Click(object sender, EventArgs e)
        {
            Admin_StudentBill f1 = new Admin_StudentBill();
            f1.Show();
            this.Hide();
        }

        private void AS_HostelExpenses_Click(object sender, EventArgs e)
        {
            Admin_HostelExpenses f1 = new Admin_HostelExpenses();
            f1.Show();
            this.Hide();
        }

        private void AS_LogOut_Click(object sender, EventArgs e)
        {
            Welcome f1 = new Welcome();
            f1.Show();
            this.Close();
        }

        public void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "Select * From Suggestions;";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            ViewSuggestionsDGV.DataSource = data;
        }

    }
}
