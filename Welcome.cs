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
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void AW_AdminBtn_Click(object sender, EventArgs e)
        {
            Admin_Login f1 = new Admin_Login();
            f1.Show();
            this.Hide();
        }

        private void AW_StudentBtn_Click(object sender, EventArgs e)
        {
            Student_Login f1 = new Student_Login();
            f1.Show();
            this.Hide();
        }

        private void WelcomeCross_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TeamBtn_Click(object sender, EventArgs e)
        {
            Team f1 = new Team();
            f1.Show();
            this.Hide();
        }
    }
}
