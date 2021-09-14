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
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;


        public Form1()
        {
            InitializeComponent();
            con.ConnectionString = @"Data Source=HARSHAL\MSSQLSERVER01;Initial Catalog=MILK;Integrated Security=True";
        }
        public static string FName;
        public static string rcby
        {
            get{ return FName;}
            set { FName = value; }
        }
        


        private void Form1_Load(object sender, EventArgs e)
        {
            
            timer1.Start();
            label1.Text = DateTime.Now.ToLongTimeString();
            label3.Text = DateTime.Now.ToString("dd-MMMM-yyyy");
            lblday.Text = DateTime.Now.ToString("dddd");

        }

        private void txtUserEnter(object sender, EventArgs e)
        {
            if(txtUsername.Text.Equals(@"Username"))
            {
                txtUsername.Text = "";
            }
        }

        private void txtUserLeave(object sender, EventArgs e)
        {
            if (txtUsername.Text.Equals(""))
            {
                txtUsername.Text = @"Username";
            }
        }

      
        private void txtPassEnter(object sender, EventArgs e)
        {
            if(txtPassword.Text.Equals("Password"))
            {
                txtPassword.Text = "";
            }
        }

        private void txtPassLeave(object sender, EventArgs e)
        {
            if (txtPassword.Text.Equals(""))
            {
                txtPassword.Text = "Password";
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

                rcby = lblfname.Text;

            string user = txtUsername.Text;
            string pass = txtPassword.Text;
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT * FROM Login where username='" + txtUsername.Text + "' AND password='" + txtPassword.Text + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Login Successfull", "Congrats", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Dashboard f2 = new Dashboard(); //this is the change, code for redirect  
                f2.ShowDialog();
            }
            else
            {

                MessageBox.Show("Incorrect Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            con.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Exit?...", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                Application.Exit();

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtUsername_OnValueChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = HARSHAL\MSSQLSERVER01; Initial Catalog = MILK; Integrated Security = True");

            con.Open();
            if (txtUsername.Text == "")
            {
                lblfname.Text = "";
                lbllname.Text = "";
            }
            if (txtUsername.Text != "")
            {
                SqlCommand cmdd = new SqlCommand("Select FName+' '+ LName from Login where username =@ID", con);
                cmdd.Parameters.AddWithValue("@ID", txtUsername.Text);
                SqlDataReader da = cmdd.ExecuteReader();
                while (da.Read())
                {
                    lblfname.Text = da.GetValue(0).ToString();
                   // lbllname.Text = da.GetValue(1).ToString();

                }

                con.Close();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
