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
    public partial class Admin_Rooms : Form
    {
        public Admin_Rooms()
        {
            InitializeComponent();
        }

        private void AR_Admin_Click(object sender, EventArgs e)
        {
            Admin_Home f1 = new Admin_Home();
            f1.Show();
            this.Hide();
        }

        private void AR_Student_Click(object sender, EventArgs e)
        {
            Admin_Student f1 = new Admin_Student();
            f1.Show();
            this.Hide();
        }

        private void AR_Visitor_Click(object sender, EventArgs e)
        {
            Admin_Visitor f1 = new Admin_Visitor();
            f1.Show();
            this.Hide();
        }

        private void AR_GYM_Click(object sender, EventArgs e)
        {
            Admin_GYM f1 = new Admin_GYM();
            f1.Show();
            this.Hide();
        }

        private void AR_Attendence_Click(object sender, EventArgs e)
        {
            Admin_Attendence f1 = new Admin_Attendence();
            f1.Show();
            this.Hide();
        }

        private void AR_StudentBills_Click(object sender, EventArgs e)
        {
            Admin_StudentBill f1 = new Admin_StudentBill();
            f1.Show();
            this.Hide();
        }

        private void AR_HostelExpenses_Click(object sender, EventArgs e)
        {
            Admin_HostelExpenses f1 = new Admin_HostelExpenses();
            f1.Show();
            this.Hide();
        }

        private void AR_Suggestions_Click(object sender, EventArgs e)
        {
            Admin_Suggestions f1 = new Admin_Suggestions();
            f1.Show();
            this.Hide();
        }

        private void AR_LogOut_Click(object sender, EventArgs e)
        {
            Welcome f1 = new Welcome();
            f1.Show();
            this.Close();
        }

        private void AR_AddRoom_Click(object sender, EventArgs e)
        {
            AdminRooms_AddRoom f1 = new AdminRooms_AddRoom();
            f1.Show();
            this.Hide();
        }

        private void AR_DeleteRoom_Click(object sender, EventArgs e)
        {
            AdminRooms_DeleteRoom f1 = new AdminRooms_DeleteRoom();
            f1.Show();
            this.Hide();
        }

        private void AR_EditRoom_Click(object sender, EventArgs e)
        {
            AdminRooms_EditRoom f1 = new AdminRooms_EditRoom();
            f1.Show();
            this.Hide();
        }

        private void AR_ViewRoom_Click(object sender, EventArgs e)
        {
            AdminRooms_ViewRooms f1 = new AdminRooms_ViewRooms();
            f1.Show();
            this.Hide();
        }

        private void AR_AllocateRoom_Click(object sender, EventArgs e)
        {
            AdminRooms_AllocateRoom f1 = new AdminRooms_AllocateRoom();
            f1.Show();
            this.Hide();
        }

        private void AR_DeallocateRoom_Click(object sender, EventArgs e)
        {
            AdminRooms_DeallocateRooms f1 = new AdminRooms_DeallocateRooms();
            f1.Show();
            this.Hide();
        }
    }
}
