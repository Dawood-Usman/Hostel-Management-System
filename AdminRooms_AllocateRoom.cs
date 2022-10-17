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
    public partial class AdminRooms_AllocateRoom : Form
    {
        public string cs = "Data Source=DAWOOD-WORLD\\SQLEXPRESS;Initial Catalog=Hostel_Management_System;Integrated Security=True";
        bool IsRollNo = false;
        bool IsRoomNo = false;
        bool IsAvailable = false;
        bool AlreadyAllocated = false;
        int Room_Strength = 0;


        public AdminRooms_AllocateRoom()
        {
            InitializeComponent();
            DisableTextBoxes();
        }

        private void AR_AllocateRoomExit_Click(object sender, EventArgs e)
        {
            Admin_Rooms f1 = new Admin_Rooms();
            f1.Show();
            this.Hide();
        }
        public void ClearTextBox()
        {
            AllocateRoomStdRNTextBox.Text = "";
            AllocateRoomRoomNoTextBox.Text = "";
            SNTextBox.Text = "";
            SRNTextBox.Text = "";
            RNTextBox.Text = "";
            BNTextBox.Text = "";
            FNTextBox.Text = "";
            HNTextBox.Text = "";
        }

        public bool IsTextBoxEmpty()
        {
            if (SNTextBox.Text == "" || SRNTextBox.Text == "" || RNTextBox.Text == "" || BNTextBox.Text == "" || FNTextBox.Text == "" || HNTextBox.Text == "" )
                return true;
            else
                return false;
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

        public void EnableTextBoxes()
        {
            SNTextBox.Enabled = true;
            SRNTextBox.Enabled = true;
            RNTextBox.Enabled = true;
            BNTextBox.Enabled = true;
            FNTextBox.Enabled = true;
            HNTextBox.Enabled = true;
        }

        private void AllocateRoomSearchBtn_Click(object sender, EventArgs e)
        {
            string query1 = "Select * From Student Where Roll_No = @SRollNo";
            string query2 = "Select * From Rooms Where Room_No = @SRoomNo";
            string query3 = "Select * From Allocated_Rooms Where Roll_No = @SRollNo";

            SqlConnection con = new SqlConnection(cs);
            
            SqlCommand cmd1 = new SqlCommand(query1, con);
            SqlCommand cmd2 = new SqlCommand(query2, con);
            SqlCommand cmd3 = new SqlCommand(query3, con);

            cmd1.Parameters.AddWithValue("@SRollNo", AllocateRoomStdRNTextBox.Text);
            cmd2.Parameters.AddWithValue("@SRoomNo", AllocateRoomRoomNoTextBox.Text);
            cmd3.Parameters.AddWithValue("@SRollNo", AllocateRoomStdRNTextBox.Text);

            if (AllocateRoomStdRNTextBox.Text != "" && AllocateRoomRoomNoTextBox.Text != "")
            {

                try
                {
                    con.Open();
                    SqlDataReader dr1 = cmd1.ExecuteReader();
                    if(dr1.HasRows)
                    {
                        IsRollNo = true;
                    }
                    else
                    {
                        IsRollNo = false;
                    }
                    con.Close();

                    con.Open();
                    SqlDataReader dr2 = cmd2.ExecuteReader();
                    if (dr2.HasRows)
                    {
                        while (dr2.Read())
                        {
                            Room_Strength = Convert.ToInt32(dr2.GetValue(3));
                        }

                        if (Room_Strength == 6)
                        {
                            IsAvailable = false;
                        }
                        else
                        {
                            IsAvailable = true;
                        }

                        IsRoomNo = true;
                    }
                    else
                    {
                        IsRoomNo = false;
                    }
                    con.Close();

                    con.Open();
                    SqlDataReader dr3 = cmd3.ExecuteReader();
                    if (dr3.HasRows)
                    {
                        AlreadyAllocated = true;
                    }
                    else
                    {
                        AlreadyAllocated = false;
                    }
                    con.Close();

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Enter Both Fields First!");
            }

            if (AllocateRoomStdRNTextBox.Text != "" && AllocateRoomRoomNoTextBox.Text != "")
            {
                if (IsRollNo == true && IsRoomNo == false)
                {
                    MessageBox.Show("No Such Room Exist!");
                }
                else if (IsRollNo == false && IsRoomNo == true)
                {
                    MessageBox.Show("No Such Student Exist!");
                }
                else if (IsRollNo == false && IsRoomNo == false)
                {
                    MessageBox.Show("No Such Student & Room Exist!");
                }
                else if (IsRollNo == true && IsRoomNo == true && IsAvailable == false && AlreadyAllocated == true)
                {
                    MessageBox.Show("Room Not Available & Room Is Already Allocated To This Student!");
                }
                else if (IsRollNo == true && IsRoomNo == true && IsAvailable == false && AlreadyAllocated == false)
                {
                    MessageBox.Show("Room Not Available!");
                }
                else if (IsRollNo == true && IsRoomNo == true && IsAvailable == true && AlreadyAllocated == true)
                {
                    MessageBox.Show("Room Already Allocated To This Student!");
                }
                else if (IsRollNo == true && IsRoomNo == true && IsAvailable == true && AlreadyAllocated == false)
                {
                    EnableTextBoxes();
                    try
                    {
                        con.Open();
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
                        SqlDataReader dr2 = cmd2.ExecuteReader();
                        if (dr2.HasRows)
                        {
                            while (dr2.Read())
                            {
                                RNTextBox.Text = dr2.GetString(0);
                                HNTextBox.Text = dr2.GetString(1);
                                FNTextBox.Text = dr2.GetValue(2).ToString();
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
        }

        private void AllocateRoomBtn_Click(object sender, EventArgs e)
        {
            if(!IsTextBoxEmpty())
            {
                string query1 = "use Hostel_Management_System; Insert Into Allocated_Rooms Values(@SRN,@RN,@BN);";
                string query2 = "use Hostel_Management_System; Update Rooms Set Room_Strength = @RS Where Room_No = @RN;";
                string query3 = "use Hostel_Management_System; Update Rooms Set Status = @status Where Room_No = @RN;";

                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd1 = new SqlCommand(query1, con);
                SqlCommand cmd2 = new SqlCommand(query2, con);
                SqlCommand cmd3 = new SqlCommand(query3, con);

                cmd1.Parameters.AddWithValue("@SRN", SRNTextBox.Text);
                cmd1.Parameters.AddWithValue("@RN", RNTextBox.Text);
                cmd1.Parameters.AddWithValue("@BN", BNTextBox.Text);

                Room_Strength += 1;
                cmd2.Parameters.AddWithValue("@RS", Room_Strength);
                cmd2.Parameters.AddWithValue("@RN", RNTextBox.Text);

                cmd3.Parameters.AddWithValue("@RN", RNTextBox.Text);
                cmd3.Parameters.AddWithValue("@status", "Not Available");

                try
                {
                    con.Open();
                    int Effected_Rows = cmd1.ExecuteNonQuery();
                    if(Effected_Rows > 0)
                    {
                        MessageBox.Show("Room Allocated Successfully!");
                        ClearTextBox();
                        DisableTextBoxes();
                        AllocateRoomStdRNTextBox.Text = "";
                        AllocateRoomRoomNoTextBox.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Room Allocation Failed!");
                    }
                    con.Close();

                    con.Open();
                    int Effected_rows = cmd2.ExecuteNonQuery();
                    if (Effected_rows < 0)
                    {
                        MessageBox.Show("Error In Updating Room Strength!");
                    }
                    con.Close();

                    if(Room_Strength == 6)
                    {
                        con.Open();
                        int effected_rows = cmd3.ExecuteNonQuery();
                        if (Effected_rows < 0)
                        {
                            MessageBox.Show("Error In Updating Room Status!");
                        }
                        con.Close();
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
        }
    }
}
