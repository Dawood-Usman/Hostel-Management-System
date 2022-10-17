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
    public partial class AdminVisitor_AddVisitor : Form
    {
        public string cs = "Data Source=DAWOOD-WORLD\\SQLEXPRESS;Initial Catalog=Hostel_Management_System;Integrated Security=True";

        public AdminVisitor_AddVisitor()
        {
            InitializeComponent();
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

        private void AddVisitorBtn_Click(object sender, EventArgs e)
        {
            string query1 = "use Hostel_Management_System; Insert Into Visitor Values(@F_name,@Cnic, @Visitor_ID, @Visit_Days, @C_No, @Status, @Address, @Gender);";
           
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(query1, con);

            cmd.Parameters.AddWithValue("@F_name", FNTextBox.Text);
            cmd.Parameters.AddWithValue("@Cnic", CnicTextBox.Text);
            cmd.Parameters.AddWithValue("@Visitor_ID", VIDTextBox.Text);
            cmd.Parameters.AddWithValue("@Visit_Days", VisitDaysTextBox.Text);
            cmd.Parameters.AddWithValue("@C_No", CNTextBox.Text);
            cmd.Parameters.AddWithValue("@Status", StatusComboBox.SelectedItem);
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
                        MessageBox.Show("Visitor Added Successfully!");
                        ClearTextBox();
                        FNTextBox.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Visitor Not Added!");
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
