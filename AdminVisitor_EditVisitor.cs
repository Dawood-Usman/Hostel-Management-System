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
    public partial class AdminVisitor_EditVisitor : Form
    {
        public string cs = "Data Source=DAWOOD-WORLD\\SQLEXPRESS;Initial Catalog=Hostel_Management_System;Integrated Security=True";

        public AdminVisitor_EditVisitor()
        {
            InitializeComponent();
            DisableTextBoxes();
        }

        private void AV_AddVisitorExit_Click(object sender, EventArgs e)
        {
            Admin_Visitor f1 = new Admin_Visitor();
            f1.Show();
            this.Hide();
        }

        public void ClearTextBox()
        {
            FNTextBox.Text = "";
            CnicTextBox.Text = "";
            VIDTextBox.Text = "";
            VisitDaysTextBox.Text = "";
            CNTextBox.Text = "";
            StatusComboBox.Text = "";
            AddressTextBox.Text = "";
            GenderComboBox.Text = "";
        }

        public bool IsTextBoxEmpty()
        {
            if (FNTextBox.Text == "" || CnicTextBox.Text == "" || VIDTextBox.Text == "" || VisitDaysTextBox.Text == "" || CNTextBox.Text == "" || StatusComboBox.Text == "" || AddressTextBox.Text == "" || GenderComboBox.Text == "")
                return true;
            else
                return false;
        }

        public void DisableTextBoxes()
        {
            FNTextBox.Enabled = false;
            CnicTextBox.Enabled = false;
            VIDTextBox.Enabled = false;
            VisitDaysTextBox.Enabled = false;
            CNTextBox.Enabled = false;
            StatusComboBox.Enabled = false;
            AddressTextBox.Enabled = false;
            GenderComboBox.Enabled = false;
        }

        public void EnableTextBoxes()
        {
            FNTextBox.Enabled = true;
            CnicTextBox.Enabled = true;
            VIDTextBox.Enabled = true;
            VisitDaysTextBox.Enabled = true;
            CNTextBox.Enabled = true;
            StatusComboBox.Enabled = true;
            AddressTextBox.Enabled = true;
            GenderComboBox.Enabled = true;
        }

        private void EVSearchVIDBtn_Click(object sender, EventArgs e)
        {
            string query = "Select * From Visitor Where Visitor_ID = @V_ID;";

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();

            if (EVSearchVIDTextBox.Text != "")
            {
                try
                {
                    cmd.Parameters.AddWithValue("@V_ID", EVSearchVIDTextBox.Text);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        EnableTextBoxes();
                        while (dr.Read())
                        {
                            FNTextBox.Text = dr.GetString(0);
                            CnicTextBox.Text = dr.GetString(1);
                            VIDTextBox.Text = dr.GetString(2);
                            VisitDaysTextBox.Text = dr.GetString(3);
                            CNTextBox.Text = dr.GetString(4);
                            StatusComboBox.Text = dr.GetString(5);
                            AddressTextBox.Text = dr.GetString(6);
                            GenderComboBox.SelectedItem = dr.GetString(7);
                        }
                    }
                    else
                    {
                        ClearTextBox();
                        DisableTextBoxes();
                        MessageBox.Show("Visitor Of Such ID Not Exist!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Enter Visitor ID First!");
            }
            con.Close();
        }

        private void EditVisitorBtn_Click(object sender, EventArgs e)
        {
            if (!IsTextBoxEmpty())
            {
                string query1 = "Update Visitor Set Name = @F_name, Cnic = @Cnic, Visitor_ID = @V_ID, Visit_Days = @V_Days, Contact_No = @C_No, Status = @status, Address = @Address, Gender = @Gender Where Visitor_ID = @SV_ID;";
              
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(query1, con);

                cmd.Parameters.AddWithValue("@SV_ID", EVSearchVIDTextBox.Text);

                cmd.Parameters.AddWithValue("@F_name", FNTextBox.Text);
                cmd.Parameters.AddWithValue("@Cnic", CnicTextBox.Text);
                cmd.Parameters.AddWithValue("@V_ID", VIDTextBox.Text);
                cmd.Parameters.AddWithValue("@V_Days", VisitDaysTextBox.Text);
                cmd.Parameters.AddWithValue("@C_No", CNTextBox.Text);
                cmd.Parameters.AddWithValue("@status", StatusComboBox.Text);
                cmd.Parameters.AddWithValue("@Address", AddressTextBox.Text);
                cmd.Parameters.AddWithValue("@Gender", GenderComboBox.SelectedItem);

                con.Open();

                try
                {
                    int Effected_Rows = cmd.ExecuteNonQuery();
                    if (Effected_Rows > 0)
                    {
                        MessageBox.Show("Visitor Updated Successfully!");
                        EVSearchVIDTextBox.Text = "";
                        ClearTextBox();
                        DisableTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Visitor Updation Failed!");
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
                MessageBox.Show("Search Visitor First!");
            }
        }
    }
}
