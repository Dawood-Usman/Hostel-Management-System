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
    public partial class AdminRooms_EditRoom : Form
    {
        public string cs = "Data Source=DAWOOD-WORLD\\SQLEXPRESS;Initial Catalog=Hostel_Management_System;Integrated Security=True";

        public AdminRooms_EditRoom()
        {
            InitializeComponent();
            DisableTextBoxes();
        }

        private void AR_EditRoomExit_Click(object sender, EventArgs e)
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
            NOBTextBox.Text = "";
            NOTTextBox.Text = "";
            NOCTextBox.Text = "";
            ChairsTextBox.Text = "";
            NOFTextBox.Text = "";
        }

        public bool IsTextBoxEmpty()
        {
            if (RNTextBox.Text == "" || HNTextBox.Text == "" || FNTextBox.Text == "" || NOBTextBox.Text == "" || NOTTextBox.Text == "" || NOCTextBox.Text == "" || ChairsTextBox.Text == "" || NOFTextBox.Text == "")
                return true;
            else
                return false;
        }

        public void DisableTextBoxes()
        {
            RNTextBox.Enabled = false;
            HNTextBox.Enabled = false;
            FNTextBox.Enabled = false;
            NOBTextBox.Enabled = false;
            NOTTextBox.Enabled = false;
            NOCTextBox.Enabled = false;
            ChairsTextBox.Enabled = false;
            NOFTextBox.Enabled = false;
        }

        public void EnableTextBoxes()
        {
            RNTextBox.Enabled = true;
            HNTextBox.Enabled = true;
            FNTextBox.Enabled = true;
            NOBTextBox.Enabled = true;
            NOTTextBox.Enabled = true;
            NOCTextBox.Enabled = true;
            ChairsTextBox.Enabled = true;
            NOFTextBox.Enabled = true;
        }


        private void EditRoomSearchBtn_Click(object sender, EventArgs e)
        {
            string query = "Select * From Rooms Where Room_No = @SRoom_No;";

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();

            if (EditRoomsSearchTextBox.Text != "")
            {
                try
                {
                    cmd.Parameters.AddWithValue("@SRoom_No", EditRoomsSearchTextBox.Text);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        EnableTextBoxes();
                        while (dr.Read())
                        {
                            RNTextBox.Text = dr.GetString(0);
                            HNTextBox.Text = dr.GetString(1);
                            FNTextBox.Text = dr.GetValue(2).ToString();
                            NOBTextBox.Text = dr.GetValue(4).ToString();
                            NOTTextBox.Text = dr.GetValue(5).ToString();
                            NOCTextBox.Text = dr.GetValue(6).ToString();
                            ChairsTextBox.Text = dr.GetValue(7).ToString();
                            NOFTextBox.Text = dr.GetValue(8).ToString();
                        }
                    }
                    else
                    {
                        ClearTextBox();
                        DisableTextBoxes();
                        MessageBox.Show("Room Not Exist!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Enter Room No First!");
            }
            con.Close();
        }

        private void EditRoomBtn_Click(object sender, EventArgs e)
        {
            if (!IsTextBoxEmpty())
            {
                string query1 = "use Hostel_Management_System; Update Rooms Set Room_No = @RN, Hall_Name = @HN, Floor_No = @FN, No_Of_Beds = @NOB,No_Of_Tables = @NOT,No_Of_CupBoards = @NOC, No_Of_Chairs = @Chairs, No_Of_Fans = @NOF;";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(query1, con);

                cmd.Parameters.AddWithValue("@RN", RNTextBox.Text);
                cmd.Parameters.AddWithValue("@HN", HNTextBox.Text);
                cmd.Parameters.AddWithValue("@FN", FNTextBox.Text);
                cmd.Parameters.AddWithValue("@NOB", NOBTextBox.Text);
                cmd.Parameters.AddWithValue("@NOT", NOTTextBox.Text);
                cmd.Parameters.AddWithValue("@NOC", NOCTextBox.Text);
                cmd.Parameters.AddWithValue("@Chairs", ChairsTextBox.Text);
                cmd.Parameters.AddWithValue("@NOF", NOFTextBox.Text);

                con.Open();

                try
                {
                    int Effected_Rows = cmd.ExecuteNonQuery();
                    if (Effected_Rows > 0)
                    {
                        MessageBox.Show("Room Updated Successfully!");
                        EditRoomsSearchTextBox.Text = "";
                        ClearTextBox();
                        DisableTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Room Updation Failed!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                con.Close();
            }
            else
            {
                MessageBox.Show("Search Room First!");
            }
        }
    }
}
