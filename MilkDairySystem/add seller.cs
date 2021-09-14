using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkDairySystem
{
    public partial class add_seller : Form
    {
        public add_seller()
        {
            InitializeComponent();
        }
         SqlConnection con = new SqlConnection(@"Data Source = HARSHAL\MSSQLSERVER01; Initial Catalog = MILK; Integrated Security = True");
            SqlCommand cmd;
            string Account;
        private void btnBackAccount_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard f2 = new Dashboard(); //this is the change, code for redirect  
            f2.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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
          
            else
            {
                if (txtMobile.Text.Length == 10)
                {

                    try
                    {
                        con.Open();
                        cmd = new SqlCommand("insert into Seller(FName,LName,Address,Mail,Mobile,Date) values('" + txtFname.Text + "','" + txtLname.Text + "','" + txtAddress.Text + "','" + txtmail.Text + "','" + txtMobile.Text + "','" + Date.Now + "' )", con);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Seller Added");
                        con.Close();
                        txtMobile.Text = "";
                        txtmail.Text = "";
                        txtLname.Text = "";
                        txtFname.Text = "";
                        txtFname.Focus();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error");
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter Only 10 Digit");
                }


            }
        }
    }
}
