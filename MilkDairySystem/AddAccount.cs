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
        public partial class AddAccount : Form
        {
            SqlConnection con = new SqlConnection(@"Data Source = HARSHAL\MSSQLSERVER01; Initial Catalog = MILK; Integrated Security = True");
            SqlCommand cmd;
            string Account;
            public AddAccount()
            {
                InitializeComponent();
            }

            private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {

            }

            private void panel3_Paint(object sender, PaintEventArgs e)
            {

            }

            private void panel1_Paint(object sender, PaintEventArgs e)
            {

            }
          public void ID()
            {
                try
                {
                    string aid;
                  string query="select AID from Account order by AID Desc";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if(dr.Read())
                    {
                        int id = int.Parse(dr[0].ToString()) + 1;
                        aid = id.ToString("000");
                    }
                    else if(Convert.IsDBNull(dr))
                    {
                        aid = ("001");
                    }
                    else
                    {
                        aid = ("001");
                    }
                    con.Close();
                    txtid.Text = aid.ToString();
               
                }
                catch
                {

                }
            }
            private void AddAccount_Load(object sender, EventArgs e)
            {
                ID();
                panel3.BackColor = Color.FromArgb(60, 0, 0, 0);


                timer1.Start();
                textBox1.Text = DateTime.Now.ToLongTimeString();
                textBox2.Text = DateTime.Now.ToString("yyyy'-'MM'-'dd");


            }

            private void button2_Click(object sender, EventArgs e)
            {
                this.Hide();
                Dashboard f2 = new Dashboard(); //this is the change, code for redirect  
                f2.ShowDialog();
            }

            private void btnAddAccount_Click(object sender, EventArgs e)
            {


                if (txtFname.Text == "")
                {
                    MessageBox.Show("Please, Enter your First Name !!", "Milk Management System");
                }
                else if (txtLname.Text == "")
                {
                    MessageBox.Show("Please, Enter your Last Name !!", "Milk Management System");
                }
                else if (txtAddress.Text == "")
                {
                    MessageBox.Show("Please, Enter your Address !!", "Milk Management System");
                }
                else if (txtmail.Text == "")
                {
                    MessageBox.Show("Please, Enter your EMail id", "Milk Management System");
                }
                else if (txtMobile.Text == "")
                {
                    MessageBox.Show("Please, Enter your Mobile", "Milk Management System");
                }
                else if (comboCattle.Text == "SELECT")
                {
                    MessageBox.Show("Please, Select Cattle Type", "Milk Management System");

                }
        
                else
                {
                    if (txtMobile.Text.Length == 10)
                    {

                        try
                        {
                            con.Open();
                            cmd = new SqlCommand("insert into Account(AID,FName,LName,Address,EMail,Mobile,Cattle,EDate) values('" + txtid.Text + "','" + txtFname.Text + "','" + txtLname.Text + "','" + txtAddress.Text + "','" + txtmail.Text + "','" + txtMobile.Text + "','" + comboCattle.SelectedItem + "','" + textBox2.Text + "' )", con);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Your Account No=" + txtid.Text, "CONGRATULATIONS");
                            con.Close();
                            txtMobile.Text = "";
                            txtmail.Text = "";
                            txtLname.Text = "";
                            txtFname.Text = "";
                            txtFname.Focus();
                        }
                        catch(Exception)
                        {
                            MessageBox.Show("Error");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Enter Only 10 Digit");
                    }
               

                }
                ID();
            }
            private void label1_Click(object sender, EventArgs e)
            {
           
            }

            private void lblDate_Click(object sender, EventArgs e)
            {

            }

            private void timer1_Tick(object sender, EventArgs e)
            {
                textBox1.Text = DateTime.Now.ToLongTimeString();
                timer1.Start();
            }

            private void label2_Click(object sender, EventArgs e)
            {

            }

            private void textBox2_TextChanged(object sender, EventArgs e)
            {

            }

            private void textBox1_TextChanged(object sender, EventArgs e)
            {

            }

            private void panel2_Paint(object sender, PaintEventArgs e)
            {

            }

            private void txtLname_TextChanged(object sender, EventArgs e)
            {

            }

            private void txtFname_TextChanged(object sender, EventArgs e)
            {

            }

            private void label4_Click(object sender, EventArgs e)
            {

            }

            private void txtAddress_TextChanged(object sender, EventArgs e)
            {

            }

            private void txtMobile_TextChanged(object sender, EventArgs e)
            {

            }

            private void label5_Click(object sender, EventArgs e)
            {

            }

            private void label7_Click(object sender, EventArgs e)
            {

            }

            private void label6_Click(object sender, EventArgs e)
            {

            }

            private void label8_Click(object sender, EventArgs e)
            {

            }

            private void comboCattle_SelectedIndexChanged(object sender, EventArgs e)
            {

            }

            private void label9_Click(object sender, EventArgs e)
            {

            }

            private void label3_Click(object sender, EventArgs e)
            {

            }

            private void pictureBox1_Click(object sender, EventArgs e)
            {


                this.Hide();
                Dashboard f2 = new Dashboard(); //this is the change, code for redirect  
                f2.ShowDialog();
            }
        }
    }
