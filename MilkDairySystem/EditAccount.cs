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


namespace MilkDairySystem
{
    public partial class EditAccount : Form
    {
        public EditAccount()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtFname_TextChanged(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source = HARSHAL\MSSQLSERVER01; Initial Catalog = MILK; Integrated Security = True");

            con.Open();
            if (txtacno.Text == "")
            {
                txtAddress.Text = "";
                comboCattle.SelectedItem = "";
                txtMobile.Text="";
                txtlname.Text = "";
                txtname.Text = "";

            }
            if (txtacno.Text != "")
            {
                SqlCommand cmd = new SqlCommand("Select FName ,LName, Address ,EMail,Mobile, Cattle from Account where AID =@ID", con);
                cmd.Parameters.AddWithValue("@ID", int.Parse(txtacno.Text));
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    txtname.Text = da.GetValue(0).ToString();
                    txtlname.Text = da.GetValue(1).ToString();
                    txtAddress.Text = da.GetValue(2).ToString();
                    txtmail.Text = da.GetValue(3).ToString();
                    txtMobile.Text = da.GetValue(4).ToString();
                 //   comboCattle.Items.Add(da[3].ToString());
                }

                con.Close();
            }
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            if (comboCattle.Text == "SELECT")
            {
                MessageBox.Show("Please, Select Cattle Type", "Milk Management System");

            }

            else
            {
                SqlConnection con = new SqlConnection(@"Data Source = HARSHAL\MSSQLSERVER01; Initial Catalog = MILK; Integrated Security = True");
                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd = new SqlCommand("update Account set FName=@a1,LName=@a2,Address=@a3,EMail=@a4,Mobile=@a5,Cattle=@a6 where AID='" + txtacno.Text + "'", con);
                cmd.Parameters.Add("a1", txtname.Text);
                cmd.Parameters.Add("a2", txtlname.Text);
                cmd.Parameters.Add("a3", txtAddress.Text);
                cmd.Parameters.Add("a4", txtmail.Text);
                cmd.Parameters.Add("a5", txtMobile.Text);
                cmd.Parameters.Add("a6", comboCattle.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Has Updated In Database");
                con.Close();
                txtacno.Text = "";
                txtname.Text = "";
                txtlname.Text = "";
                txtAddress.Text = "";
                txtmail.Text = "";
                txtMobile.Text = "";

            }
        }

        private void txtacno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

        }

        private void btnBackAccount_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard f2 = new Dashboard(); //this is the change, code for redirect  
            f2.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtacno.Text == "")
            {
                MessageBox.Show("Please, Enter Your ID !!", "Milk Management System");
            }
            else
            {

                if (MessageBox.Show("Are You Sure You Want To Delete?...", "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {

                    SqlConnection con = new SqlConnection(@"Data Source = HARSHAL\MSSQLSERVER01; Initial Catalog = MILK; Integrated Security = True");
                    SqlCommand cmd = new SqlCommand();
                    con.Open();
                    string query = "delete from Account where AID='" + txtacno.Text + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Delete Successfully...!!!!!!");
                    txtacno.Text = "";
                    txtAddress.Text = "";
                    txtname.Text = "";
                    txtlname.Text = "";
                    txtMobile.Text = "";

                }
                else
                {
                    MessageBox.Show("ERROR.......");
                }
            }
        }
        private void comboCattle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void EditAccount_Load(object sender, EventArgs e)
        {
            panel3.BackColor = Color.FromArgb(60, 0, 0, 0);
            timer1.Start();
            textBox1.Text = DateTime.Now.ToLongTimeString();
            textBox2.Text = DateTime.Now.ToLongDateString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard f2 = new Dashboard(); //this is the change, code for redirect  
            f2.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
