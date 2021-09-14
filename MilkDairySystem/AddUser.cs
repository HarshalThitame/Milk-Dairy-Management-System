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
    public partial class AddUser : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = HARSHAL\MSSQLSERVER01; Initial Catalog = MILK; Integrated Security = True");
        SqlCommand cmd;


        public AddUser()
        {
            InitializeComponent();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            panel3.BackColor = Color.FromArgb(60, 0, 0, 0);

            timer1.Start();
            label1.Text = DateTime.Now.ToLongTimeString();
            label2.Text = DateTime.Now.ToLongDateString();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (txtUserid.Text == "")
            {
                MessageBox.Show("Please, Enter User ID", "Milk Management System");
            }
            else if (txtFname.Text == "")
            {
                MessageBox.Show("Please, Enter your First Name !!", "Milk Management System");
            }
            else if (txtLname.Text == "")
            {
                MessageBox.Show("Please, Enter your Last Name !!", "Milk Management System");
            }

            else if (txtUname.Text == "")
            {
                MessageBox.Show("Please, Enter Username", "Milk Management System");
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Please, Enter Password !!", "Milk Management System");
            }
            else
            {
                con.Open();
                cmd = new SqlCommand("insert into Login values('" + txtUserid.Text + "','" + txtFname.Text + "','" + txtLname.Text + "','" + txtemail.Text + "','" + txtaddress.Text + "','" + txtUname.Text + "','" + txtPassword.Text + "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Has Saved In Database");
                con.Close();
                txtUserid.Text = "";
                txtLname.Text = "";
                txtFname.Text = "";
                txtUname.Text = "";
                txtPassword.Text = "";
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard f2 = new Dashboard(); //this is the change, code for redirect  
            f2.ShowDialog();
        }

        private void txtUserid_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = HARSHAL\MSSQLSERVER01; Initial Catalog = MILK; Integrated Security = True");

            con.Open();
            if (txtUserid.Text == "")
            {
                txtFname.Text = "";
                txtLname.Text = "";
                txtemail.Text = "";
                txtaddress.Text = "";
                txtUname.Text = "";
                txtPassword.Text = "";

            }
            if (txtUserid.Text != "")
            {
                SqlCommand cmd = new SqlCommand("Select FName,LName,EMail,Address,username,password from Login where ID =@UID", con);
                cmd.Parameters.AddWithValue("@UID", int.Parse(txtUserid.Text));
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    txtFname.Text = da.GetValue(0).ToString();
                    txtLname.Text = da.GetValue(1).ToString();
                    txtemail.Text = da.GetValue(2).ToString();
                    txtaddress.Text = da.GetValue(3).ToString();
                    txtUname.Text = da.GetValue(4).ToString();
                    txtPassword.Text = da.GetValue(5).ToString();


                }

                con.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = HARSHAL\MSSQLSERVER01; Initial Catalog = MILK; Integrated Security = True");
             if (txtUserid.Text == "")
            {
                MessageBox.Show("Please, Enter User ID", "Milk Management System");
            }
            else if (txtFname.Text == "")
            {
                MessageBox.Show("Please, Enter your First Name !!", "Milk Management System");
            }
            else if (txtLname.Text == "")
            {
                MessageBox.Show("Please, Enter your Last Name !!", "Milk Management System");
            }
          
            else if (txtUname.Text == "")
            {
                MessageBox.Show("Please, Enter Username", "Milk Management System");
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Please, Enter Password !!", "Milk Management System");
            }
            else
            {
                con.Open();
                cmd = new SqlCommand("update Login set fName=@fn,LName=@ln, username=@un, password=@pw where ID=@UID", con);
                cmd.Parameters.AddWithValue("@fn", txtFname.Text);
                cmd.Parameters.AddWithValue("@ln", txtLname.Text);
                cmd.Parameters.AddWithValue("@un", txtUname.Text);
                cmd.Parameters.AddWithValue("@pw", txtPassword.Text);
                cmd.Parameters.AddWithValue("@UID", Convert.ToInt32(txtUserid.Text));

                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Has updated In Database");
                con.Close();
                txtUserid.Text = "";
                txtLname.Text = "";
                txtFname.Text = "";
                txtUname.Text = "";
                txtPassword.Text = "";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtUserid.Text == "")
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
                    string query = "delete from Login where ID='" + txtUserid.Text + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Delete Successfully...!!!!!!");
                    txtFname.Text = "";
                    txtLname.Text = "";
                    txtUname.Text = "";
                    txtPassword.Text = "";
                    txtaddress.Text = "";
                    txtemail.Text = "";

                }
                else
                {
                    MessageBox.Show("ERROR.......");
                }
            }
        }

        private void txtUserid_KeyPress(object sender, KeyPressEventArgs e)
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            this.Hide();
            Dashboard f2 = new Dashboard(); //this is the change, code for redirect  
            f2.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }
    }
}
