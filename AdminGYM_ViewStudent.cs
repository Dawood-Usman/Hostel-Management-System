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
    public partial class AdminGYM_ViewStudent : Form
    {
        public string cs = "Data Source=DAWOOD-WORLD\\SQLEXPRESS;Initial Catalog=Hostel_Management_System;Integrated Security=True";

        public AdminGYM_ViewStudent()
        {
            InitializeComponent();
            BindGridView();
        }

        private void AG_ViewStudentExit_Click(object sender, EventArgs e)
        {
            Admin_GYM f1 = new Admin_GYM();
            f1.Show();
            this.Hide();
        }

        public void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "Select * From GYM;";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            GYMViewStudentDGV.DataSource = data;
        }
    }
}
