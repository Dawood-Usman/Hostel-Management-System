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
    public partial class AdminRooms_DeallocateRooms : Form
    {
        public string cs = "Data Source=DAWOOD-WORLD\\SQLEXPRESS;Initial Catalog=Hostel_Management_System;Integrated Security=True";

        bool IsStudent = false;
        bool IsAllocated = false;
        string SRN = "";
        int Room_Strength = 0;

        public AdminRooms_DeallocateRooms()
        {
            InitializeComponent();
            DisableTextBoxes();
        }

        private void AR_DeallocateRoomExit_Click(object sender, EventArgs e)
        {
            Admin_Rooms f1 = new Admin_Rooms();
            f1.Show();
            this.Hide();
        }

        public void ClearTextBox()
        {
            DeallocateRoomStdSearchTextBox.Text = "";
            SNTextBox.Text = "";
            SRNTextBox.Text = "";
            RNTextBox.Text = "";
            BNTextBox.Text = "";
            FNTextBox.Text = "";
            HNTextBox.Text = "";
        }

        public bool IsTextBoxEmpty()
        {
            if (SNTextBox.Text == "" || SRNTextBox.Text == "" || RNTextBox.Text == "" || BNTextBox.Text == "" || FNTextBox.Text == "" || HNTextBox.Text == "")
                return true;
            else
                return false;
        }

        public void EnableTextBoxes()
        {
            SNTextBox.Enabled = true;
            SRNTextBox.Enabled = true;
            RNTextBox.Enabled = true;
            BNTextBox.Enabled = true;
            FNTextBox.Enabled = true;
            HNTextBox.Enabled = true;
        }

        public void DisableTextBoxes()
        {
            SNTextBox.Enabled = false;
            SRNTextBox.Enabled = false;
            RNTextBox.Enabled = false;
            BNTextBox.Enabled = false;
            FNTextBox.Enabled = false;
            HNTextBox.Enabled = false;
        }

        private void DeallocateRoomStdSearchBtn_Click(object sender, EventArgs e)
        {
            string query1 = "Select * From Student Where Roll_No = @SRollNo";
            string query2 = "Select * From Allocated_Rooms Where Roll_No = @SRollNo";
            string query3 = "Select * From Rooms Where Room_No = @SRoomNo";

            SqlConnection con = new SqlConnection(cs);

            SqlCommand cmd1 = new SqlCommand(query1, con);
            SqlCommand cmd2 = new SqlCommand(query2, con);
            SqlCommand cmd3 = new SqlCommand(query3, con);

            cmd1.Parameters.AddWithValue("@SRollNo", DeallocateRoomStdSearchTextBox.Text);
            cmd2.Parameters.AddWithValue("@SRollNo", DeallocateRoomStdSearchTextBox.Text);

            if (DeallocateRoomStdSearchTextBox.Text != "")
            {
                try
                {

                    con.Open();
                    SqlDataReader dr1 = cmd1.ExecuteReader();
                    if(dr1.HasRows)
                    {
                        IsStudent = true;
                    }
                    else
                    {
                        IsStudent = false;
                    }
                    con.Close();

                    if(IsStudent == true)
                    {
                        con.Open();
                        SqlDataReader dr2 = cmd2.ExecuteReader();
                        if (dr2.HasRows)
                        {
                            while(dr2.Read())
                            {
                                SRN = dr2.GetString(1);
                            }
                            IsAllocated = true;
                        }
                        else
                        {
                            IsAllocated = false;
                        }
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("No Such Student Exist!");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Enter Roll No First!");
            }

            if(IsAllocated == false && IsStudent == true)
            {
                MessageBox.Show("No Room Is Allocated To This Student Yet!");
            }
            
            if(IsStudent == true && IsAllocated == true)
            {
                EnableTextBoxes();
                try
                {
                    con.Open();
                    cmd3.Parameters.AddWithValue("@SRoomNo", SRN);
                    SqlDataReader dr1 = cmd1.ExecuteReader();
                    if (dr1.HasRows)
                    {
                        while (dr1.Read())
                        {
                            SNTextBox.Text = dr1.GetString(0);
                            SRNTextBox.Text = dr1.GetString(2);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error!");
                    }
                    con.Close();

                    con.Open();
                    SqlDataReader Dr2 = cmd3.ExecuteReader();
                    if (Dr2.HasRows)
                    {
                        while (Dr2.Read())
                        {
                            RNTextBox.Text = Dr2.GetString(0);
                            HNTextBox.Text = Dr2.GetString(1);
                            FNTextBox.Text = Dr2.GetValue(2).ToString();
                            Room_Strength = Convert.ToInt32(Dr2.GetValue(3));
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error! " + SRN);
                    }
                    con.Close();

                    con.Open();
                    SqlDataReader dr3 = cmd2.ExecuteReader();
                    if (dr3.HasRows)
                    {
                        while (dr3.Read())
                        {
                            BNTextBox.Text = dr3.GetValue(2).ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error!");
                    }
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DeallocateRoomBtn_Click(object sender, EventArgs e)
        {
            if (!IsTextBoxEmpty())
            {
                string query1 = "Delete From Allocated_Rooms Where Roll_No = @SRN";
                string query2 = "Update Rooms Set Room_Strength = @RS, Status = @status Where Room_No = @SRoomNo";

                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd1 = new SqlCommand(query1, con);
                SqlCommand cmd2 = new SqlCommand(query2, con);

                cmd1.Parameters.AddWithValue("@SRN", DeallocateRoomStdSearchTextBox.Text);

                Room_Strength -= 1;
                cmd2.Parameters.AddWithValue("@RS",Room_Strength);
                cmd2.Parameters.AddWithValue("@status", "Available");
                cmd2.Parameters.AddWithValue("@SRoomNo", SRN);


                try
                {
                    con.Open();
                    int Effected_Rows = cmd1.ExecuteNonQuery();
                    if (Effected_Rows > 0)
                    {
                        MessageBox.Show("Room De-Allocated Successfully!");
                        ClearTextBox();
                        DisableTextBoxes();
                        DeallocateRoomStdSearchTextBox.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Room De-Allocation Failed!");
                    }
                    con.Close();

                    con.Open();
                    int Effected_rows = cmd2.ExecuteNonQuery();
                    if (Effected_rows < 0)
                    {
                        MessageBox.Show("Error In Updating Room Strength!");
                    }
                    con.Close();
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
        }
    }
}
