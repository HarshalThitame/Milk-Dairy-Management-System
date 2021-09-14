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
    public partial class Fat : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = HARSHAL\MSSQLSERVER01; Initial Catalog = MILK; Integrated Security = True");
        SqlCommand cmd;
        public Fat()
        {
            InitializeComponent();
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {

            if (txtFat.Text == "")
            {
                MessageBox.Show("Please, Enter Fat Pricea !!", "Milk Management System");
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source = HARSHAL\MSSQLSERVER01; Initial Catalog = MILK; Integrated Security = True");

                con.Open();
                cmd = new SqlCommand("update Fat set FATPRICE=@a1 where FID=1", con);
                cmd.Parameters.Add("a1", txtFat.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Has Saved In Database");
                con.Close();
                txtFat.Text = "";
            }
            //  SqlConnection con = new SqlConnection(@"Data Source = HARSHAL\MSSQLSERVER01; Initial Catalog = MILK; Integrated Security = True");

            con.Open();

            if (txtFatid.Text != "")
            {
                SqlCommand cmd = new SqlCommand("Select FATPRICE from Fat where FID =1", con);
                cmd.Parameters.AddWithValue("", int.Parse(txtFatid.Text));
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    txtShowFat.Text = da.GetValue(0).ToString();

                }

                con.Close();
            }

        }
        private void txtShowFat_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBackAccount_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard f2 = new Dashboard(); //this is the change, code for redirect  
            f2.ShowDialog();
        }

        private void txtFatid_TextChanged(object sender, EventArgs e)
        {

        }

        private void Fat_Load(object sender, EventArgs e)
        {
            timer1.Start();
            txttime.Text = DateTime.Now.ToLongTimeString();
            txtdate.Text = DateTime.Now.ToLongDateString();

            SqlConnection con = new SqlConnection(@"Data Source = HARSHAL\MSSQLSERVER01; Initial Catalog = MILK; Integrated Security = True");

            con.Open();

            if (txtFatid.Text != "")
            {
                SqlCommand cmd = new SqlCommand("Select FATPRICE from Fat where FID =1", con);
                cmd.Parameters.AddWithValue("", int.Parse(txtFatid.Text));
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    txtShowFat.Text = da.GetValue(0).ToString();

                }

                con.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txttime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void txtFat_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
