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
    public partial class AdminVisitor_DeleteVisitor : Form
    {
        public string cs = "Data Source=DAWOOD-WORLD\\SQLEXPRESS;Initial Catalog=Hostel_Management_System;Integrated Security=True";

        public AdminVisitor_DeleteVisitor()
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

        private void DVSearchBtn_Click(object sender, EventArgs e)
        {
            string query = "Select * From Visitor Where Visitor_ID = @V_ID;";

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();

            if (DVSeacrchVIDTextBox.Text != "")
            {
                try
                {
                    cmd.Parameters.AddWithValue("@V_ID", DVSeacrchVIDTextBox.Text);
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

        private void DeleteVisitorBtn_Click(object sender, EventArgs e)
        {
            if (!IsTextBoxEmpty())
            {
                string query1 = "Delete From Visitor Where Visitor_ID = @V_ID";
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(query1, con);

                cmd.Parameters.AddWithValue("@V_ID", DVSeacrchVIDTextBox.Text);

                con.Open();

                try
                {
                    int Effected_Rows = cmd.ExecuteNonQuery();
                    if (Effected_Rows > 0)
                    {
                        MessageBox.Show("Visitor Deleted Successfully!");
                        DVSeacrchVIDTextBox.Text = "";
                        ClearTextBox();
                        DisableTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Visitor Deletion Failed!");
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
