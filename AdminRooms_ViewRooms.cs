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
    public partial class AdminRooms_ViewRooms : Form
    {
        public string cs = "Data Source=DAWOOD-WORLD\\SQLEXPRESS;Initial Catalog=Hostel_Management_System;Integrated Security=True";

        public AdminRooms_ViewRooms()
        {
            InitializeComponent();
            BindGridView();
        }

        private void AR_ViewRoomExit_Click(object sender, EventArgs e)
        {
            Admin_Rooms f1 = new Admin_Rooms();
            f1.Show();
            this.Hide();
        }
        public void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "Select Room_No , Hall_Name AS Hall , Floor_No As Floor, Room_Strength AS Strength, No_Of_Beds AS Beds,No_Of_Tables As Tables,No_Of_CupBoards As CupBoards, No_Of_Chairs AS Chairs, No_Of_Fans AS Fans, Status From Rooms;";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            ViewRoomsDGV.DataSource = data;
        }

    }
}
