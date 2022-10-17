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
    public partial class Admin_Student : Form
    {
        public Admin_Student()
        {
            InitializeComponent();
        }

        private void AS_Admin_Click(object sender, EventArgs e)
        {
            Admin_Home f1 = new Admin_Home();
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

        private void AS_HotelExpenses_Click(object sender, EventArgs e)
        {
            Admin_HostelExpenses f1 = new Admin_HostelExpenses();
            f1.Show();
            this.Hide();
        }

        private void AS_Suggestions_Click(object sender, EventArgs e)
        {
            Admin_Suggestions f1 = new Admin_Suggestions();
            f1.Show();
            this.Hide();
        }

        private void AS_LogOut_Click(object sender, EventArgs e)
        {
            Welcome f1 = new Welcome();
            f1.Show();
            this.Close();
        }

        private void AS_AddStudent_Click(object sender, EventArgs e)
        {
            AdminStudent_AddStudent f1 = new AdminStudent_AddStudent();
            f1.Show();
            this.Hide();
        }

        private void AS_DeleteStudent_Click(object sender, EventArgs e)
        {
            AdminStudent_DeleteStudent f1 = new AdminStudent_DeleteStudent();
            f1.Show();
            this.Hide();
        }

        private void AS_EditStudent_Click(object sender, EventArgs e)
        {
            AdminStudent_EditStudent f1 = new AdminStudent_EditStudent();
            f1.Show();
            this.Hide();
        }

        private void AS_ViewStudent_Click(object sender, EventArgs e)
        {
            AdminStudent_ViewStudent f1 = new AdminStudent_ViewStudent();
            f1.Show();
            this.Hide();
        }

        private void AS_AddStudent_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
