using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hostel_Management_System
{
    public partial class Admin_GYM : Form
    {
        public Admin_GYM()
        {
            InitializeComponent();
        }

        private void AG_Admin_Click(object sender, EventArgs e)
        {
            Admin_Home f1 = new Admin_Home();
            f1.Show();
            this.Hide();
        }

        private void AG_Student_Click(object sender, EventArgs e)
        {
            Admin_Student f1 = new Admin_Student();
            f1.Show();
            this.Hide();
        }

        private void AG_Visitor_Click(object sender, EventArgs e)
        {
            Admin_Visitor f1 = new Admin_Visitor();
            f1.Show();
            this.Hide();
        }

        private void AG_Rooms_Click(object sender, EventArgs e)
        {
            Admin_Rooms f1 = new Admin_Rooms();
            f1.Show();
            this.Hide();
        }

        private void AG_Attendence_Click(object sender, EventArgs e)
        {
            Admin_Attendence f1 = new Admin_Attendence();
            f1.Show();
            this.Hide();
        }

        private void AG_StudentBills_Click(object sender, EventArgs e)
        {
            Admin_StudentBill f1 = new Admin_StudentBill();
            f1.Show();
            this.Hide();
        }

        private void AG_HostelExpense_Click(object sender, EventArgs e)
        {
            Admin_HostelExpenses f1 = new Admin_HostelExpenses();
            f1.Show();
            this.Hide();
        }

        private void AG_Suggestions_Click(object sender, EventArgs e)
        {
            Admin_Suggestions f1 = new Admin_Suggestions();
            f1.Show();
            this.Hide();
        }

        private void AG_LogOut_Click(object sender, EventArgs e)
        {
            Welcome f1 = new Welcome();
            f1.Show();
            this.Close();
        }

        private void AG_AddStudent_Click(object sender, EventArgs e)
        {
            AdminGYM_AddStudent f1 = new AdminGYM_AddStudent();
            f1.Show();
            this.Hide();
        }

        private void AG_DeleteStudent_Click(object sender, EventArgs e)
        {
            AdminGYM_DeleteStudent f1 = new AdminGYM_DeleteStudent();
            f1.Show();
            this.Hide();
        }

        private void AG_EditStudent_Click(object sender, EventArgs e)
        {
            AdminGYM_EditStudent f1 = new AdminGYM_EditStudent();
            f1.Show();
            this.Hide();
        }

        private void AG_ViewStudent_Click(object sender, EventArgs e)
        {
            AdminGYM_ViewStudent f1 = new AdminGYM_ViewStudent();
            f1.Show();
            this.Hide();
        }
    }
}
