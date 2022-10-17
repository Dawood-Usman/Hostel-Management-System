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
    public partial class Student_ViewFees : Form
    {
        public Student_ViewFees()
        {
            InitializeComponent();
        }

        private void SV_Home_Click(object sender, EventArgs e)
        {
            Student_Home f1 = new Student_Home();
            f1.Show();
            this.Hide();
        }

        private void SV_Rooms_Click(object sender, EventArgs e)
        {
            Student_Rooms f1 = new Student_Rooms();
            f1.Show();
            this.Hide();
        }

        private void SV_GYM_Click(object sender, EventArgs e)
        {
            Student_GYM f1 = new Student_GYM();
            f1.Show();
            this.Hide();
        }

        private void SV_Attendence_Click(object sender, EventArgs e)
        {
            Student_Attendence f1 = new Student_Attendence();
            f1.Show();
            this.Hide();
        }

        private void SV_PayFees_Click(object sender, EventArgs e)
        {
            Student_PayFees f1 = new Student_PayFees();
            f1.Show();
            this.Hide();
        }

        private void SV_Suggestions_Click(object sender, EventArgs e)
        {
            Student_Suggestions f1 = new Student_Suggestions();
            f1.Show();
            this.Hide();
        }

        private void SV_LogOut_Click(object sender, EventArgs e)
        {
            Welcome f1 = new Welcome();
            f1.Show();
            this.Close();
        }

        private void SV_ViewHFees_Click(object sender, EventArgs e)
        {
            SVF_ViewHostelFees f1 = new SVF_ViewHostelFees();
            f1.Show();
            this.Hide();
        }

        private void AA_ViewMF_Click(object sender, EventArgs e)
        {
            SVF_ViewMessFees f1 = new SVF_ViewMessFees();
            f1.Show();
            this.Hide();
        }
    }
}
