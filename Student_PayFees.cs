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
    public partial class Student_PayFees : Form
    {
        public Student_PayFees()
        {
            InitializeComponent();
        }

        private void SP_Home_Click(object sender, EventArgs e)
        {
            Student_Home f1 = new Student_Home();
            f1.Show();
            this.Hide();
        }

        private void SP_Rooms_Click(object sender, EventArgs e)
        {
            Student_Rooms f1 = new Student_Rooms();
            f1.Show();
            this.Hide();
        }

        private void SP_GYM_Click(object sender, EventArgs e)
        {
            Student_GYM f1 = new Student_GYM();
            f1.Show();
            this.Hide();
        }

        private void SP_Attendence_Click(object sender, EventArgs e)
        {
            Student_Attendence f1 = new Student_Attendence();
            f1.Show();
            this.Hide();
        }

        private void SP_ViewFees_Click(object sender, EventArgs e)
        {
            Student_ViewFees f1 = new Student_ViewFees();
            f1.Show();
            this.Hide();
        }

        private void SP_Suggestions_Click(object sender, EventArgs e)
        {
            Student_Suggestions f1 = new Student_Suggestions();
            f1.Show();
            this.Hide();
        }

        private void SP_LogOut_Click(object sender, EventArgs e)
        {
            Welcome f1 = new Welcome();
            f1.Show();
            this.Close();
        }

        private void SP_PayHFees_Click(object sender, EventArgs e)
        {
            SPF_PayHostelFees f1 = new SPF_PayHostelFees();
            f1.Show();
            this.Hide();
        }

        private void SP_PayMFees_Click(object sender, EventArgs e)
        {
            SPF_PayMessFees f1 = new SPF_PayMessFees();
            f1.Show();
            this.Hide();
        }
    }
}
