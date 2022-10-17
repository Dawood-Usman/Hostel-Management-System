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
    public partial class AdminHome_ViewAdmin : Form
    {
        public string cs = "Data Source=DAWOOD-WORLD\\SQLEXPRESS;Initial Catalog=Hostel_Management_System;Integrated Security=True";

        public AdminHome_ViewAdmin()
        {
            InitializeComponent();
            BindGridView();
        }

        private void AH_ViewAdminExit_Click(object sender, EventArgs e)
        {
            Admin_Home f1 = new Admin_Home();
            f1.Show();
            this.Hide();
        }

        public void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "Select * From Admin;";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            ViewAdminsDGV.DataSource = data;
        }
    }
}
