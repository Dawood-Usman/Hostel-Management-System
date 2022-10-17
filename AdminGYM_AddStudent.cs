﻿using System;
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
    public partial class AdminGYM_AddStudent : Form
    {
        public string cs = "Data Source=DAWOOD-WORLD\\SQLEXPRESS;Initial Catalog=Hostel_Management_System;Integrated Security=True";

        public AdminGYM_AddStudent()
        {
            InitializeComponent();
            DisableTextBoxes();
        }

        private void AG_AddStudentExit_Click(object sender, EventArgs e)
        {
            Admin_GYM f1 = new Admin_GYM();
            f1.Show();
            this.Hide();
        }

        public void ClearTextBox()
        {
            FNTextBox.Text = "";
            CnicTextBox.Text = "";
            RNTextBox.Text = "";
            HeightTextBox.Text = "";
            CNTextBox.Text = "";
            WeightTextBox.Text = "";
            AddressTextBox.Text = "";
            GenderComboBox.SelectedItem = "";
        }

        public bool IsTextBoxEmpty()
        {
            if (FNTextBox.Text == "" || CnicTextBox.Text == "" || RNTextBox.Text == "" || HeightTextBox.Text == "" || CNTextBox.Text == "" || WeightTextBox.Text == "" || AddressTextBox.Text == "" || GenderComboBox.Text == "")
                return true;
            else
                return false;
        }

        public void DisableTextBoxes()
        {
            FNTextBox.Enabled = false;
            CnicTextBox.Enabled = false;
            RNTextBox.Enabled = false;
            HeightTextBox.Enabled = false;
            CNTextBox.Enabled = false;
            WeightTextBox.Enabled = false;
            AddressTextBox.Enabled = false;
            GenderComboBox.Enabled = false;
        }

        public void EnableTextBoxes()
        {
            FNTextBox.Enabled = true;
            CnicTextBox.Enabled = true;
            RNTextBox.Enabled = true;
            HeightTextBox.Enabled = true;
            CNTextBox.Enabled = true;
            WeightTextBox.Enabled = true;
            AddressTextBox.Enabled = true;
            GenderComboBox.Enabled = true;
        }

        private void GymAddStdSearchBtn_Click(object sender, EventArgs e)
        {
            string query = "Select * From Student Where Roll_No = @SRoll_No;";

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();

            if (GYMASSearchTextBox.Text != "")
            {
                try
                {
                    cmd.Parameters.AddWithValue("@SRoll_No", GYMASSearchTextBox.Text);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        EnableTextBoxes();
                        while (dr.Read())
                        {
                            FNTextBox.Text = dr.GetString(0);
                            CnicTextBox.Text = dr.GetString(1);
                            RNTextBox.Text = dr.GetString(2);
                            HeightTextBox.Text = "";
                            CNTextBox.Text = dr.GetString(4);
                            WeightTextBox.Text = "";
                            AddressTextBox.Text = dr.GetString(6);
                            GenderComboBox.SelectedItem = dr.GetString(7);
                        }
                    }
                    else
                    {
                        ClearTextBox();
                        DisableTextBoxes();
                        MessageBox.Show("Student Of Such UserName Not Exist!");
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
            con.Close();
        }

        private void AddStudentBtn_Click(object sender, EventArgs e)
        {
            string query1 = "use Hostel_Management_System; Insert Into GYM Values(@F_name,@Cnic, @Roll_No, @Height, @C_No, @Weight, @Address, @Gender);";
           
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(query1, con);

            cmd.Parameters.AddWithValue("@F_name", FNTextBox.Text);
            cmd.Parameters.AddWithValue("@Cnic", CnicTextBox.Text);
            cmd.Parameters.AddWithValue("@Roll_No", RNTextBox.Text);
            cmd.Parameters.AddWithValue("@Height", HeightTextBox.Text);
            cmd.Parameters.AddWithValue("@C_No", CNTextBox.Text);
            cmd.Parameters.AddWithValue("@Weight", WeightTextBox.Text);
            cmd.Parameters.AddWithValue("@Address", AddressTextBox.Text);
            cmd.Parameters.AddWithValue("@Gender", GenderComboBox.SelectedItem);

            con.Open();

            if (!IsTextBoxEmpty())
            {
                try
                {
                    int Rows_Effected = cmd.ExecuteNonQuery();
                    if (Rows_Effected > 0)
                    {
                        MessageBox.Show("Student Added Successfully!");
                        ClearTextBox();
                        DisableTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Student Not Added!");
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
