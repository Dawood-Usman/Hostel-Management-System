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
    public partial class Admin_StudentBill : Form
    {
        public Admin_StudentBill()
        {
            InitializeComponent();
        }

        private void AB_Admin_Click(object sender, EventArgs e)
        {
            Admin_Home f1 = new Admin_Home();
            f1.Show();
            this.Hide();
        }

        private void AB_Student_Click(object sender, EventArgs e)
        {
            Admin_Student f1 = new Admin_Student();
            f1.Show();
            this.Hide();
        }

        private void AB_Visitor_Click(object sender, EventArgs e)
        {
            Admin_Visitor f1 = new Admin_Visitor();
            f1.Show();
            this.Hide();
        }

        private void AB_Rooms_Click(object sender, EventArgs e)
        {
            Admin_Rooms f1 = new Admin_Rooms();
            f1.Show();
            this.Hide();
        }

        private void AB_GYM_Click(object sender, EventArgs e)
        {
            Admin_GYM f1 = new Admin_GYM();
            f1.Show();
            this.Hide();
        }

        private void AB_Attendence_Click(object sender, EventArgs e)
        {
            Admin_Attendence f1 = new Admin_Attendence();
            f1.Show();
            this.Hide();
        }

        private void AB_HostelExpense_Click(object sender, EventArgs e)
        {
            Admin_HostelExpenses f1 = new Admin_HostelExpenses();
            f1.Show();
            this.Hide();
        }

        private void AB_Suggestions_Click(object sender, EventArgs e)
        {
            Admin_Suggestions f1 = new Admin_Suggestions();
            f1.Show();
            this.Hide();
        }

        private void AB_LogOut_Click(object sender, EventArgs e)
        {
            Welcome f1 = new Welcome();
            f1.Show();
            this.Close();
        }

        private void AB_UpdateHB_Click(object sender, EventArgs e)
        {
            AdminStudentBills_UpdateHostelBill f1 = new AdminStudentBills_UpdateHostelBill();
            f1.Show();
            this.Hide();
        }

        private void AB_UpdateMB_Click(object sender, EventArgs e)
        {
            AdminStudentBills_UpdateMessBill f1 = new AdminStudentBills_UpdateMessBill();
            f1.Show();
            this.Hide();
        }

        private void AB_ViewHB_Click(object sender, EventArgs e)
        {
            AdminStudentBills_ViewHostelBill f1 = new AdminStudentBills_ViewHostelBill();
            f1.Show();
            this.Hide();
        }

        private void AB_ViewMB_Click(object sender, EventArgs e)
        {
            AdminStudentBills_ViewMessBill f1 = new AdminStudentBills_ViewMessBill();
            f1.Show();
            this.Hide();
        }
    }
}
