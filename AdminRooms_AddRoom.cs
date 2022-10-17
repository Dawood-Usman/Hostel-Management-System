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
    public partial class AdminRooms_AddRoom : Form
    {
        public string cs = "Data Source=DAWOOD-WORLD\\SQLEXPRESS;Initial Catalog=Hostel_Management_System;Integrated Security=True";

        public AdminRooms_AddRoom()
        {
            InitializeComponent();
            RSTextBox.Text = "0";
            StatusComboBox.Text = "Available";
        }

        private void AR_AddRoomExit_Click(object sender, EventArgs e)
        {
            Admin_Rooms f1 = new Admin_Rooms();
            f1.Show();
            this.Hide();
        }

        public void ClearTextBox()
        {
            RNTextBox.Text = "";
            HNTextBox.Text = "";
            FNTextBox.Text = "";
            RSTextBox.Text = "";
            NOBTextBox.Text = "";
            NOTTextBox.Text = "";
            NOCTextBox.Text = "";
            ChairsTextBox.Text = "";
            NOFTextBox.Text = "";
            StatusComboBox.Text = "";
        }

        public bool IsTextBoxEmpty()
        {
            if (RNTextBox.Text == "" || HNTextBox.Text == "" || FNTextBox.Text == "" || RSTextBox.Text == "" || NOBTextBox.Text == "" || NOTTextBox.Text == "" || NOCTextBox.Text == "" || ChairsTextBox.Text == "" || NOFTextBox.Text == "" || StatusComboBox.Text == "")
                return true;
            else
                return false;
        }

        private void AddRoomsBtn_Click(object sender, EventArgs e)
        {
            string query1 = "use Hostel_Management_System; Insert Into Rooms Values(@RN,@HN, @FN, @RS, @NOB, @NOT, @NOC, @Chairs, @NOF, @Status);";
          
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(query1, con);

            cmd.Parameters.AddWithValue("@RN", RNTextBox.Text);
            cmd.Parameters.AddWithValue("@HN", HNTextBox.Text);
            cmd.Parameters.AddWithValue("@FN", FNTextBox.Text);
            cmd.Parameters.AddWithValue("@RS", 0);
            cmd.Parameters.AddWithValue("@NOB", NOBTextBox.Text);
            cmd.Parameters.AddWithValue("@NOT", NOTTextBox.Text);
            cmd.Parameters.AddWithValue("@NOC", NOCTextBox.Text);
            cmd.Parameters.AddWithValue("@Chairs", ChairsTextBox.Text);
            cmd.Parameters.AddWithValue("@NOF", NOFTextBox.Text);
            cmd.Parameters.AddWithValue("@Status", "Available");

            con.Open();
            
            if (!IsTextBoxEmpty())
            {
                try
                {
                    int Rows_Effected = cmd.ExecuteNonQuery();
                    if (Rows_Effected > 0)
                    {
                        MessageBox.Show("Room Added Successfully!");
                        ClearTextBox();
                        RNTextBox.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Room Not Added!");
                        FNTextBox.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Fill All Fields!");
            }

            con.Close();
        }
    }
}
