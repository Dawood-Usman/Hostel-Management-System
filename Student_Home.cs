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
    public partial class Student_Home : Form
    {
        public string cs = "Data Source=DAWOOD-WORLD\\SQLEXPRESS;Initial Catalog=Hostel_Management_System;Integrated Security=True";
        public string Current_Student = Student_Login.Current_Student;
        public string Current_Student_RN;

        public static bool IsGym = false; 

        public Student_Home()
        {
            InitializeComponent();
            Show_Student_Details();
        }

        public void Show_Student_Details()
        {
            bool IsAllocated = false;
            string query1 = "Select * From Student Where Roll_No = @RN";
            string query2 = "Select * From Allocated_Rooms Where Roll_No = @RN";
            string query3 = "Select * From Rooms Where Room_No = @RoomNo";
            string query4 = "Select * From GYM Where Roll_No = @RN";


            SqlConnection con = new SqlConnection(cs);

            SqlCommand cmd1 = new SqlCommand(query1, con);
            SqlCommand cmd2 = new SqlCommand(query2, con);
            SqlCommand cmd3 = new SqlCommand(query3, con);
            SqlCommand cmd4 = new SqlCommand(query4, con);

            cmd1.Parameters.AddWithValue("@RN", Current_Student);
            cmd2.Parameters.AddWithValue("@RN", Current_Student);
            cmd4.Parameters.AddWithValue("@RN", Current_Student);

            try
            {
                con.Open();
                SqlDataReader dr1 = cmd1.ExecuteReader();
                if(dr1.HasRows)
                {
                    while(dr1.Read())
                    {
                        NameLabel.Text = dr1.GetString(0);
                        CnicLabel.Text = dr1.GetString(1);
                        RollNoLabel.Text = dr1.GetString(2);
                        PasswordLabel.Text = dr1.GetString(3);
                        ContactNoLabel.Text = dr1.GetString(4);
                        ParentsNoLabel.Text = dr1.GetString(5);
                        AddressLabel.Text = dr1.GetString(6);
                        GenderLabel.Text = dr1.GetString(7);
                    }
                }
                else
                {
                    MessageBox.Show("Error In Student Table!");
                }
                con.Close();

                con.Open();
                SqlDataReader dr2 = cmd2.ExecuteReader();
                if (dr2.HasRows)
                {
                    while (dr2.Read())
                    {
                        RoomNoLabel.Text = dr2.GetString(1);
                        BedNoLabel.Text = dr2.GetString(2);
                    }
                    IsAllocated = true;
                    Current_Student_RN = RoomNoLabel.Text;
                    cmd3.Parameters.AddWithValue("@RoomNo", Current_Student_RN);
                }
                else
                {
                    IsAllocated = false;
                }
                con.Close();

                if (IsAllocated == true)
                {
                    con.Open();
                    SqlDataReader dr3 = cmd3.ExecuteReader();
                    if (dr3.HasRows)
                    {
                        while (dr3.Read())
                        {
                            HallNameLabel.Text = dr3.GetString(1);
                            FloorNoLabel.Text = dr3.GetValue(2).ToString();
                            RoomStrengthLabel.Text = dr3.GetValue(3).ToString();
                        }
                        RoomStatusLabel.Text = "Current";
                        MessStatusLabel.Text = "Current";
                    }
                    else
                    {
                        MessageBox.Show("Error In Rooms Table!");
                    }
                    con.Close();
                }

                con.Open();
                SqlDataReader dr4 = cmd4.ExecuteReader();
                if (dr4.HasRows)
                {
                    GymStatusLabel.Text = "Current";
                    IsGym = true;
                }
                else
                {
                    GymStatusLabel.Text = "NA";
                    IsGym = false;
                }
                con.Close();

            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }

        private void SH_Rooms_Click(object sender, EventArgs e)
        {
            Student_Rooms f1 = new Student_Rooms();
            f1.Show();
            this.Hide();
        }

        private void SH_GYM_Click(object sender, EventArgs e)
        {
            Student_GYM f1 = new Student_GYM();
            f1.Show();
            this.Hide();
        }

        private void SH_Attendence_Click(object sender, EventArgs e)
        {
            Student_Attendence f1 = new Student_Attendence();
            f1.Show();
            this.Hide();
        }

        private void SH_ViewFees_Click(object sender, EventArgs e)
        {
            Student_ViewFees f1 = new Student_ViewFees();
            f1.Show();
            this.Hide();
        }

        private void SH_PayFees_Click(object sender, EventArgs e)
        {
            Student_PayFees f1 = new Student_PayFees();
            f1.Show();
            this.Hide();
        }

        private void SH_Suggestions_Click(object sender, EventArgs e)
        {
            Student_Suggestions f1 = new Student_Suggestions();
            f1.Show();
            this.Hide();
        }

        private void SH_Logout_Click(object sender, EventArgs e)
        {
            Welcome f1 = new Welcome();
            f1.Show();
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
