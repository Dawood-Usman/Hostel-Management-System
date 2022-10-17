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
    public partial class Admin_Home : Form
    {
        public Admin_Home()
        {
            InitializeComponent();
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

        private void AH_HostelExpenses_Click(object sender, EventArgs e)
        {
            Admin_HostelExpenses f1 = new Admin_HostelExpenses();
            f1.Show();
            this.Hide();
        }

        private void AH_Suggestions_Click(object sender, EventArgs e)
        {
            Admin_Suggestions f1 = new Admin_Suggestions();
            f1.Show();
            this.Hide();
        }

        private void AH_Logout_Click(object sender, EventArgs e)
        {
            Welcome f1 = new Welcome();
            f1.Show();
            this.Close();
        }

        private void AH_AddAdmin_Click(object sender, EventArgs e)
        {
            AdminHome_AddAdmin f1 = new AdminHome_AddAdmin();
            f1.Show();
            this.Hide();
        }

        private void AH_DeleteAdmin_Click(object sender, EventArgs e)
        {
            AdminHome_DeleteAdmin f1 = new AdminHome_DeleteAdmin();
            f1.Show();
            this.Hide();
        }

        private void AH_ViewAdmin_Click(object sender, EventArgs e)
        {
            AdminHome_ViewAdmin f1 = new AdminHome_ViewAdmin();
            f1.Show();
            this.Hide();
        }

        private void AH_ChangePassword_Click(object sender, EventArgs e)
        {
            AdminHome_ChangePassword f1 = new AdminHome_ChangePassword();
            f1.Show();
            this.Hide();
        }
    }
}
