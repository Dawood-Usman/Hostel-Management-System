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
    public partial class Admin_Visitor : Form
    {
        public Admin_Visitor()
        {
            InitializeComponent();
        }

        private void AV_Admin_Click(object sender, EventArgs e)
        {
            Admin_Home f1 = new Admin_Home();
            f1.Show();
            this.Hide();
        }

        private void AV_Student_Click(object sender, EventArgs e)
        {
            Admin_Student f1 = new Admin_Student();
            f1.Show();
            this.Hide();
        }

        private void AV_Rooms_Click(object sender, EventArgs e)
        {
            Admin_Rooms f1 = new Admin_Rooms();
            f1.Show();
            this.Hide();
        }

        private void AV_GYM_Click(object sender, EventArgs e)
        {
            Admin_GYM f1 = new Admin_GYM();
            f1.Show();
            this.Hide();
        }

        private void AV_Attendence_Click(object sender, EventArgs e)
        {
            Admin_Attendence f1 = new Admin_Attendence();
            f1.Show();
            this.Hide();
        }

        private void AV_StudentBills_Click(object sender, EventArgs e)
        {
            Admin_StudentBill f1 = new Admin_StudentBill();
            f1.Show();
            this.Hide();
        }

        private void AV_HostelExpenses_Click(object sender, EventArgs e)
        {
            Admin_HostelExpenses f1 = new Admin_HostelExpenses();
            f1.Show();
            this.Hide();
        }

        private void AV_Suggestions_Click(object sender, EventArgs e)
        {
            Admin_Suggestions f1 = new Admin_Suggestions();
            f1.Show();
            this.Hide();
        }

        private void AV_Logout_Click(object sender, EventArgs e)
        {
            Welcome f1 = new Welcome();
            f1.Show();
            this.Close();
        }

        private void AV_AddVisitor_Click(object sender, EventArgs e)
        {
            AdminVisitor_AddVisitor f1 = new AdminVisitor_AddVisitor();
            f1.Show();
            this.Hide();
        }

        private void AV_DeleteVisitor_Click(object sender, EventArgs e)
        {
            AdminVisitor_DeleteVisitor f1 = new AdminVisitor_DeleteVisitor();
            f1.Show();
            this.Hide();
        }

        private void AV_EditVisitor_Click(object sender, EventArgs e)
        {
            AdminVisitor_EditVisitor f1 = new AdminVisitor_EditVisitor();
            f1.Show();
            this.Hide();
        }

        private void AV_ViewVisitor_Click(object sender, EventArgs e)
        {
            AdminVisitor_ViewVisitor f1 = new AdminVisitor_ViewVisitor();
            f1.Show();
            this.Hide();
        }
    }
}
