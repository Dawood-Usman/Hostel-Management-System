using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hostel_Management_System
{
    public partial class Student_Rooms : Form
    {
        public string cs = "Data Source=DAWOOD-WORLD\\SQLEXPRESS;Initial Catalog=Hostel_Management_System;Integrated Security=True";
      
        public Student_Rooms()
        {
            InitializeComponent();
            BindGridView();
        }

        private void SR_Home_Click(object sender, EventArgs e)
        {
            Student_Home f1 = new Student_Home();
            f1.Show();
            this.Hide();
        }

        private void SR_GYM_Click(object sender, EventArgs e)
        {
            Student_GYM f1 = new Student_GYM();
            f1.Show();
            this.Hide();
        }

        private void SR_Attendence_Click(object sender, EventArgs e)
        {
            Student_Attendence f1 = new Student_Attendence();
            f1.Show();
            this.Hide();
        }

        private void SR_ViewFees_Click(object sender, EventArgs e)
        {
            Student_ViewFees f1 = new Student_ViewFees();
            f1.Show();
            this.Hide();
        }

        private void SR_PayFees_Click(object sender, EventArgs e)
        {
            Student_PayFees f1 = new Student_PayFees();
            f1.Show();
            this.Hide();
        }

        private void SR_Suggestions_Click(object sender, EventArgs e)
        {
            Student_Suggestions f1 = new Student_Suggestions();
            f1.Show();
            this.Hide();
        }

        private void SR_LogOut_Click(object sender, EventArgs e)
        {
            Welcome f1 = new Welcome();
            f1.Show();
            this.Close();
        }

        public void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "Select Room_No , Hall_Name AS Hall , Floor_No As Floor, Room_Strength AS Strength, No_Of_Beds AS Beds,No_Of_Tables As Tables,No_Of_CupBoards As CupBoards, No_Of_Chairs AS Chairs, No_Of_Fans AS Fans, Status From Rooms Where Status = 'Available';";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            ViewAvailableRoomsDGV.DataSource = data;
        }

    }
}
