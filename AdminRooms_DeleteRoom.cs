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
    public partial class AdminRooms_DeleteRoom : Form
    {
        public string cs = "Data Source=DAWOOD-WORLD\\SQLEXPRESS;Initial Catalog=Hostel_Management_System;Integrated Security=True";

        public AdminRooms_DeleteRoom()
        {
            InitializeComponent();
            DisableTextBoxes();
        }

        private void AR_DeleteRoomExit_Click(object sender, EventArgs e)
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

        public void DisableTextBoxes()
        {
            RNTextBox.Enabled = false;
            HNTextBox.Enabled = false;
            FNTextBox.Enabled = false;
            RSTextBox.Enabled = false;
            NOBTextBox.Enabled = false;
            NOTTextBox.Enabled = false;
            NOCTextBox.Enabled = false;
            ChairsTextBox.Enabled = false;
            NOFTextBox.Enabled = false;
            StatusComboBox.Enabled = false;
        }

        public void EnableTextBoxes()
        {
            RNTextBox.Enabled = true;
            HNTextBox.Enabled = true;
            FNTextBox.Enabled = true;
            RSTextBox.Enabled = true;
            NOBTextBox.Enabled = true;
            NOTTextBox.Enabled = true;
            NOCTextBox.Enabled = true;
            ChairsTextBox.Enabled = true;
            NOFTextBox.Enabled = true;
            StatusComboBox.Enabled = true;
        }

        private void DeleteRoomsSearchBtn_Click(object sender, EventArgs e)
        {
            string query = "Select * From Rooms Where Room_No = @SRoom_No;";

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();

            if (DeleteRoomsSearchTextBox.Text != "")
            {
                try
                {
                    cmd.Parameters.AddWithValue("@SRoom_No", DeleteRoomsSearchTextBox.Text);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        EnableTextBoxes();
                        while (dr.Read())
                        {
                            RNTextBox.Text = dr.GetString(0);
                            HNTextBox.Text = dr.GetString(1);
                            FNTextBox.Text = dr.GetValue(2).ToString();
                            RSTextBox.Text = dr.GetValue(3).ToString();
                            NOBTextBox.Text = dr.GetValue(4).ToString();
                            NOTTextBox.Text = dr.GetValue(5).ToString();
                            NOCTextBox.Text = dr.GetValue(6).ToString();
                            ChairsTextBox.Text = dr.GetValue(7).ToString();
                            NOFTextBox.Text = dr.GetValue(8).ToString();
                            StatusComboBox.SelectedItem = dr.GetString(9);
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
                MessageBox.Show("Enter Rooom No First!");
            }
            con.Close();
        }

        private void DeleteRoomBtn_Click(object sender, EventArgs e)
        {
            if (!IsTextBoxEmpty())
            {
                string query1 = "Delete From Rooms Where Room_No = @SRoom_No;";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(query1, con);

                cmd.Parameters.AddWithValue("@SRoom_No", DeleteRoomsSearchTextBox.Text);

                con.Open();

                try
                {
                    int Effected_Rows = cmd.ExecuteNonQuery();
                    if (Effected_Rows > 0)
                    {
                        MessageBox.Show("Room Deleted Successfully!");
                        DeleteRoomsSearchTextBox.Text = "";
                        ClearTextBox();
                        DisableTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Room Deletion Failed!");
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
