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
    public partial class Admin_Attendence : Form
    {
        public Admin_Attendence()
        {
            InitializeComponent();
        }

        private void AA_Admin_Click(object sender, EventArgs e)
        {
            Admin_Home f1 = new Admin_Home();
            f1.Show();
            this.Hide();
        }

        private void AA_Student_Click(object sender, EventArgs e)
        {
            Admin_Student f1 = new Admin_Student();
            f1.Show();
            this.Hide();
        }

        private void AA_Visitor_Click(object sender, EventArgs e)
        {
            Admin_Visitor f1 = new Admin_Visitor();
            f1.Show();
            this.Hide();
        }

        private void AA_Rooms_Click(object sender, EventArgs e)
        {
            Admin_Rooms f1 = new Admin_Rooms();
            f1.Show();
            this.Hide();
        }

        private void AA_GYM_Click(object sender, EventArgs e)
        {
            Admin_GYM f1 = new Admin_GYM();
            f1.Show();
            this.Hide();
        }

        private void AA_StudentBills_Click(object sender, EventArgs e)
        {
            Admin_StudentBill f1 = new Admin_StudentBill();
            f1.Show();
            this.Hide();
        }

        private void AA_HostelExpenses_Click(object sender, EventArgs e)
        {
            Admin_HostelExpenses f1 = new Admin_HostelExpenses();
            f1.Show();
            this.Hide();
        }

        private void AA_Suggestions_Click(object sender, EventArgs e)
        {
            Admin_Suggestions f1 = new Admin_Suggestions();
            f1.Show();
            this.Hide();
        }

        private void AA_LogOut_Click(object sender, EventArgs e)
        {
            Welcome f1 = new Welcome();
            f1.Show();
            this.Close();
        }

        private void AA_MarkIOA_Click(object sender, EventArgs e)
        {
            AdminAttendence_MarkInOutAttendence f1 = new AdminAttendence_MarkInOutAttendence();
            f1.Show();
            this.Hide();
        }

        private void AA_MarkMA_Click(object sender, EventArgs e)
        {
            AdminAttendence_MarkMessAttendence f1 = new AdminAttendence_MarkMessAttendence();
            f1.Show();
            this.Hide();
        }

        private void AA_ViewIOA_Click(object sender, EventArgs e)
        {
            AdminAttendence_ViewInOutAttendence f1 = new AdminAttendence_ViewInOutAttendence();
            f1.Show();
            this.Hide();
        }

        private void AA_ViewMA_Click(object sender, EventArgs e)
        {
            AdminAttendence_ViewMessAttendence f1 = new AdminAttendence_ViewMessAttendence();
            f1.Show();
            this.Hide();
        }

        private void Admin_Attendence_Load(object sender, EventArgs e)
        {

        }
    }
}
