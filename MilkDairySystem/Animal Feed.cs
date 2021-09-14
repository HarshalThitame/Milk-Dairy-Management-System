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
using Microsoft.OData.Edm;

namespace MilkDairySystem
{
    public partial class Animal_Feed : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = HARSHAL\MSSQLSERVER01; Initial Catalog = MILK; Integrated Security = True");
        SqlCommand cmd;
        public Animal_Feed()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Animal_Feed_Load(object sender, EventArgs e)
        {
            timer1.Start();
            textBox1.Text = DateTime.Now.ToLongTimeString();
            textBox2.Text = DateTime.Now.ToString("dd-MM-yyyy");

            con.Open();
            SqlCommand cmd = new SqlCommand("Select FeedPrice from AnimalFeed where ID =@a1", con);
            cmd.Parameters.AddWithValue("a1", lbl1.Text);
            SqlDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                lblbajra.Text = da.GetValue(0).ToString();
            }
           
            con.Close();


            con.Open();
            SqlCommand cmd1 = new SqlCommand("Select FeedPrice from AnimalFeed where ID =@a2", con);
            cmd1.Parameters.AddWithValue("a2", lbl2.Text);
            SqlDataReader da1 = cmd1.ExecuteReader();
            while (da1.Read())
            {
                lblmaize.Text = da1.GetValue(0).ToString();
            }
            con.Close();


            con.Open();
            SqlCommand cmd3 = new SqlCommand("Select FeedPrice from AnimalFeed where ID =@a3", con);
            cmd3.Parameters.AddWithValue("a3", lbl3.Text);
            SqlDataReader da3 = cmd3.ExecuteReader();
            while (da3.Read())
            {
                lblsor.Text = da3.GetValue(0).ToString();
            }
            con.Close();


            con.Open();
            SqlCommand cmd4 = new SqlCommand("Select FeedPrice from AnimalFeed where ID =@a4", con);
            cmd4.Parameters.AddWithValue("a4", lbl4.Text);
            SqlDataReader da4 = cmd4.ExecuteReader();
            while (da4.Read())
            {
                lblrice.Text = da4.GetValue(0).ToString();
            }
            con.Close();


            con.Open();
            SqlCommand cmd5 = new SqlCommand("Select FeedPrice from AnimalFeed where ID =@a5", con);
            cmd5.Parameters.AddWithValue("a5", lbl5.Text);
            SqlDataReader da5 = cmd5.ExecuteReader();
            while (da5.Read())
            {
                lbloats.Text = da5.GetValue(0).ToString();
            }
            con.Close();


            con.Open();
            SqlCommand cmd6 = new SqlCommand("Select FeedPrice from AnimalFeed where ID =@a6", con);
            cmd6.Parameters.AddWithValue("a6", lbl6.Text);
            SqlDataReader da6= cmd6.ExecuteReader();
            while (da6.Read())
            {
                lblbarley.Text = da6.GetValue(0).ToString();
            }
            con.Close();


            con.Open();
            SqlCommand cmd7 = new SqlCommand("Select FeedPrice from AnimalFeed where ID =@a7", con);
            cmd7.Parameters.AddWithValue("a7", lbl7.Text);
            SqlDataReader da7 = cmd7.ExecuteReader();
            while (da7.Read())
            {
                lblcotten.Text = da7.GetValue(0).ToString();
            }
            con.Close();


            con.Open();
            SqlCommand cmd8 = new SqlCommand("Select FeedPrice from AnimalFeed where ID =@a8", con);
            cmd8.Parameters.AddWithValue("a8", lbl8.Text);
            SqlDataReader da8 = cmd8.ExecuteReader();
            while (da8.Read())
            {
                lblwheat.Text = da8.GetValue(0).ToString();
            }
            con.Close();


            con.Open();
            SqlCommand cmd9 = new SqlCommand("Select FeedPrice from AnimalFeed where ID =@a9", con);
            cmd9.Parameters.AddWithValue("a9", lbl9.Text);
            SqlDataReader da9 = cmd9.ExecuteReader();
            while (da9.Read())
            {
                lblcorn.Text = da9.GetValue(0).ToString();
            }
            con.Close();


            con.Open();
            SqlCommand cmd10 = new SqlCommand("Select FeedPrice from AnimalFeed where ID =@a10", con);
            cmd10.Parameters.AddWithValue("a10", lbl10.Text);
            SqlDataReader da10 = cmd10.ExecuteReader();
            while (da10.Read())
            {
                lblmixed.Text = da10.GetValue(0).ToString();
            }
            con.Close();

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(t1.Text))
            {
                t1.Text = "0";
            }

            if (lblbajra.Text.Length > 0 && t1.Text.Length > 0 && l1.Text.Length > 0)
            {
                l1.Text = Convert.ToString(Convert.ToDouble(t1.Text) * Convert.ToDouble(lblbajra.Text));
                // txtt4.Text = Convert.ToString(Convert.ToInt32(txtt1.Text) * Convert.ToInt32(txtt2.Text));
            }
            if (t1.Text.Length > 0 && lblbajra.Text.Length == 0)
            {
                l1.Text = "0";
                //txtt4.Text = "0";
            }
            if (t1.Text.Length == 0 && lblbajra.Text.Length > 0)
            {
                l1.Text = "0";
                //  txtt4.Text = "0";
            }
            if (t1.Text.Length == 0 && lblbajra.Text.Length == 0)
            {
                l1.Text = "0";
                // txtt4.Text = "0";
            }
          
        }

        private void t2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(t2.Text))
            {
                t2.Text = "0";
            }
            if (lblmaize.Text.Length > 0 && t2.Text.Length > 0 && l2.Text.Length > 0)
            {
                l2.Text = Convert.ToString(Convert.ToDouble(t2.Text) * Convert.ToDouble(lblmaize.Text));
                // txtt4.Text = Convert.ToString(Convert.ToInt32(txtt1.Text) * Convert.ToInt32(txtt2.Text));
            }
            if (t2.Text.Length > 0 && lblmaize.Text.Length == 0)
            {
                l2.Text = "0";
                //txtt4.Text = "0";
            }
            if (t2.Text.Length == 0 && lblmaize.Text.Length > 0)
            {
                l2.Text = "0";
                //  txtt4.Text = "0";
            }
            if (t2.Text.Length == 0 && lblmaize.Text.Length == 0)
            {
                l2.Text = "0";
                // txtt4.Text = "0";
            }

        }

        private void t3_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(t3.Text))
            {
                t3.Text = "0";
            }
            if (lblsor.Text.Length > 0 && t3.Text.Length > 0 && l3.Text.Length > 0)
            {
                l3.Text = Convert.ToString(Convert.ToDouble(t3.Text) * Convert.ToDouble(lblsor.Text));
                // txtt4.Text = Convert.ToString(Convert.ToInt32(txtt1.Text) * Convert.ToInt32(txtt2.Text));
            }
            if (t3.Text.Length > 0 && lblsor.Text.Length == 0)
            {
                l3.Text = "0";
                //txtt4.Text = "0";
            }
            if (t3.Text.Length == 0 && lblsor.Text.Length > 0)
            {
                l3.Text = "0";
                //  txtt4.Text = "0";
            }
            if (t3.Text.Length == 0 && lblsor.Text.Length == 0)
            {
                l1.Text = "0";
                // txtt4.Text = "0";
            }

        }

        private void t4_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(t4.Text))
            {
                t4.Text = "0";
            }
            if (lblrice.Text.Length > 0 && t4.Text.Length > 0 && l4.Text.Length > 0)
            {
                l4.Text = Convert.ToString(Convert.ToDouble(t4.Text) * Convert.ToDouble(lblrice.Text));
                // txtt4.Text = Convert.ToString(Convert.ToInt32(txtt1.Text) * Convert.ToInt32(txtt2.Text));
            }
            if (t4.Text.Length > 0 && lblrice.Text.Length == 0)
            {
                l4.Text = "0";
                //txtt4.Text = "0";
            }
            if (t4.Text.Length == 0 && lblrice.Text.Length > 0)
            {
                l4.Text = "0";
                //  txtt4.Text = "0";
            }
            if (t4.Text.Length == 0 && lblrice.Text.Length == 0)
            {
                l4.Text = "0";
                // txtt4.Text = "0";
            }

        }

        private void t5_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(t5.Text))
            {
                t5.Text = "0";
            }
            if (lbloats.Text.Length > 0 && t5.Text.Length > 0 && l5.Text.Length > 0)
            {
                l5.Text = Convert.ToString(Convert.ToDouble(t5.Text) * Convert.ToDouble(lbloats.Text));
                // txtt4.Text = Convert.ToString(Convert.ToInt32(txtt1.Text) * Convert.ToInt32(txtt2.Text));
            }
            if (t5.Text.Length > 0 && lbloats.Text.Length == 0)
            {
                l5.Text = "0";
                //txtt4.Text = "0";
            }
            if (t5.Text.Length == 0 && lbloats.Text.Length > 0)
            {
                l5.Text = "0";
                //  txtt4.Text = "0";
            }
            if (t5.Text.Length == 0 && lbloats.Text.Length == 0)
            {
                l5.Text = "0";
                // txtt4.Text = "0";
            }

        }

        private void t6_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(t6.Text))
            {
                t6.Text = "0";
            }
            if (lblbarley.Text.Length > 0 && t6.Text.Length > 0 && l6.Text.Length > 0)
            {
                l6.Text = Convert.ToString(Convert.ToDouble(t6.Text) * Convert.ToDouble(lblbarley.Text));
                // txtt4.Text = Convert.ToString(Convert.ToInt32(txtt1.Text) * Convert.ToInt32(txtt2.Text));
            }
            if (t6.Text.Length > 0 && lblbarley.Text.Length == 0)
            {
                l6.Text = "0";
                //txtt4.Text = "0";
            }
            if (t6.Text.Length == 0 && lblbarley.Text.Length > 0)
            {
                l6.Text = "0";
                //  txtt4.Text = "0";
            }
            if (t6.Text.Length == 0 && lblbarley.Text.Length == 0)
            {
                l6.Text = "0";
                // txtt4.Text = "0";
            }

        }

        private void t7_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(t7.Text))
            {
                t7.Text = "0";
            }
            if (lblcotten.Text.Length > 0 && t7.Text.Length > 0 && l7.Text.Length > 0)
            {
                l7.Text = Convert.ToString(Convert.ToDouble(t7.Text) * Convert.ToDouble(lblcotten.Text));
                // txtt4.Text = Convert.ToString(Convert.ToInt32(txtt1.Text) * Convert.ToInt32(txtt2.Text));
            }
            if (t7.Text.Length > 0 && lblcotten.Text.Length == 0)
            {
                l7.Text = "0";
                //txtt4.Text = "0";
            }
            if (t7.Text.Length == 0 && lblcotten.Text.Length > 0)
            {
                l7.Text = "0";
                //  txtt4.Text = "0";
            }
            if (t7.Text.Length == 0 && lblcotten.Text.Length == 0)
            {
                l7.Text = "0";
                // txtt4.Text = "0";
            }

        }

        private void t8_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(t8.Text))
            {
                t8.Text = "0";
            }
            if (lblwheat.Text.Length > 0 && t8.Text.Length > 0 && l8.Text.Length > 0)
            {
                l8.Text = Convert.ToString(Convert.ToDouble(t8.Text) * Convert.ToDouble(lblwheat.Text));
                // txtt4.Text = Convert.ToString(Convert.ToInt32(txtt1.Text) * Convert.ToInt32(txtt2.Text));
            }
            if (t8.Text.Length > 0 && lblwheat.Text.Length == 0)
            {
                l8.Text = "0";
                //txtt4.Text = "0";
            }
            if (t8.Text.Length == 0 && lblwheat.Text.Length > 0)
            {
                l8.Text = "0";
                //  txtt4.Text = "0";
            }
            if (t8.Text.Length == 0 && lblwheat.Text.Length == 0)
            {
                l8.Text = "0";
                // txtt4.Text = "0";
            }

        }

        private void t9_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(t9.Text))
            {
                t9.Text = "0";
            }
            if (lblcorn.Text.Length > 0 && t9.Text.Length > 0 && l9.Text.Length > 0)
            {
                l9.Text = Convert.ToString(Convert.ToDouble(t9.Text) * Convert.ToDouble(lblcorn.Text));
                // txtt4.Text = Convert.ToString(Convert.ToInt32(txtt1.Text) * Convert.ToInt32(txtt2.Text));
            }
            if (t9.Text.Length > 0 && lblcorn.Text.Length == 0)
            {
                l9.Text = "0";
                //txtt4.Text = "0";
            }
            if (t9.Text.Length == 0 && lblcorn.Text.Length > 0)
            {
                l9.Text = "0";
                //  txtt4.Text = "0";
            }
            if (t9.Text.Length == 0 && lblcorn.Text.Length == 0)
            {
                l9.Text = "0";
                // txtt4.Text = "0";
            }

        }

        private void t10_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(t10.Text))
            {
                t10.Text = "0";
            }
            if (lblmixed.Text.Length > 0 && t10.Text.Length > 0 && l10.Text.Length > 0)
            {
                l10.Text = Convert.ToString(Convert.ToDouble(t10.Text) * Convert.ToDouble(lblmixed.Text));
                // txtt4.Text = Convert.ToString(Convert.ToInt32(txtt1.Text) * Convert.ToInt32(txtt2.Text));
            }
            if (t10.Text.Length > 0 && lblmixed.Text.Length == 0)
            {
                l10.Text = "0";
                //txtt4.Text = "0";
            }
            if (t10.Text.Length == 0 && lblmixed.Text.Length > 0)
            {
                l10.Text = "0";
                //  txtt4.Text = "0";
            }
            if (t10.Text.Length == 0 && lblmixed.Text.Length == 0)
            {
                l10.Text = "0";
                // txtt4.Text = "0";
            }

        }

        private void lbltotalprice_Click(object sender, EventArgs e)
        {
           
        }

        private void l1_TextChanged(object sender, EventArgs e)
        {

        }

        private void l9_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {
            double v1 = Convert.ToDouble(l1.Text);
            double v2 = Convert.ToDouble(l2.Text);
            double v3 = Convert.ToDouble(l3.Text);
            double v4 = Convert.ToDouble(l4.Text);
            double v5 = Convert.ToDouble(l5.Text);
            double v6 = Convert.ToDouble(l6.Text);
            double v7 = Convert.ToDouble(l7.Text);
            double v8 = Convert.ToDouble(l8.Text);
            double v9 = Convert.ToDouble(l9.Text);
            double v10 = Convert.ToDouble(l10.Text);
            double v = v1 + v2 + v3 + v4 + v5 + v6 + v7 + v8 + v9 + v10;
            lbltotalprice.Text = v.ToString();

            double v11 = Convert.ToDouble(t1.Text);
            double v21 = Convert.ToDouble(t2.Text);
            double v31 = Convert.ToDouble(t3.Text);
            double v41= Convert.ToDouble(t4.Text);
            double v51= Convert.ToDouble(t5.Text);
            double v61= Convert.ToDouble(t6.Text);
            double v71= Convert.ToDouble(t7.Text);
            double v81= Convert.ToDouble(t8.Text);
            double v91= Convert.ToDouble(t9.Text);
            double v101 = Convert.ToDouble(t10.Text);
            double result = v11+ v21 + v31 + v41 + v51 + v61 + v71 + v81 + v91 + v101;
            lblquantity.Text = result.ToString();
        }

        private void txtAcNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
          (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            

        }

        private void txtAcNo_TextChanged(object sender, EventArgs e)
        {
            if(System.Text.RegularExpressions.Regex.IsMatch(txtAcNo.Text," ^ [0-9]"))
            {
                txtAcNo.Text = "";
            }
            SqlConnection con = new SqlConnection(@"Data Source = HARSHAL\MSSQLSERVER01; Initial Catalog = MILK; Integrated Security = True");

            con.Open();
            if (txtAcNo.Text == "")
            {
                lbladdress.Text = "";
                lblmail.Text = "";
                lblmobile.Text = "";
                lblcattle.Text = "";
                lblname.Text = "";
              

            }
            if (txtAcNo.Text != "")
            {
                SqlCommand cmd = new SqlCommand("Select FName+' '+LName , EMail,Mobile, Address , Cattle from Account where AID =@ID", con);
                cmd.Parameters.AddWithValue("@ID",txtAcNo.Text);
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    lblname.Text = da.GetValue(0).ToString();
                    lblmail.Text = da.GetValue(1).ToString();
                    lblmobile.Text = da.GetValue(2).ToString();
                    lbladdress.Text = da.GetValue(3).ToString();
                    lblcattle.Text = da.GetValue(4).ToString();

                }

                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                if (lblquantity.Text == "0")
                {
                    _ = MessageBox.Show(text: "Please, Calculate Total", "Milk Management System");

                }
                else
                if (lbltotalprice.Text == "0")
                {
                    _ = MessageBox.Show(text: "Please, Calculate Total", "Milk Management System");

                }
                else
                if (txtAcNo.Text == "")
                {
                    _ = MessageBox.Show(text: "Please, Enter Account No", "Milk Management System");

                }
                else
                {

                    con.Open();
                    DialogResult dr = MessageBox.Show("Are You Sure", "Confirm", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        cmd = new SqlCommand("IF EXISTS(Select * from Feed WHERE AID='" + txtAcNo.Text + "') update Feed set Quantity=Quantity+" + lblquantity.Text + ",Price=Price+" + lbltotalprice.Text + " where AID=" + txtAcNo.Text + " else insert into Feed(AID,Quantity,Price,Date) values('" + txtAcNo.Text + "','" + lblquantity.Text + "','" + lbltotalprice.Text + "', '" + Date.Now + "')", con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data has Saved In Database");

                    }
                    else if (dr == DialogResult.No)
                    {
                        MessageBox.Show("Cancelled");
                    }
                    con.Close();
                    t1.Text = "0";
                    t2.Text = "0";
                    t3.Text = "0";
                    t4.Text = "0";
                    t5.Text = "0";
                    t6.Text = "0";
                    t7.Text = "0";
                    t8.Text = "0";
                    t9.Text = "0";
                    t10.Text = "0";
                    l1.Text = "0";
                    l2.Text = "0";
                    l3.Text = "0";
                    l4.Text = "0";
                    l5.Text = "0";
                    l6.Text = "0";
                    l7.Text = "0";
                    l8.Text = "0";
                    l9.Text = "0";
                    l10.Text = "0";
                    lbltotalprice.Text = "0";
                    lblquantity.Text = "0";
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error", "", MessageBoxButtons.OKCancel);
            }
        }

        private void GvAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void t1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void t2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void t3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void t4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void t5_KeyPress(object sender, KeyPressEventArgs e)
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

        private void t6_KeyPress(object sender, KeyPressEventArgs e)
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

        private void t7_KeyPress(object sender, KeyPressEventArgs e)
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

        private void t8_KeyPress(object sender, KeyPressEventArgs e)
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

        private void t9_KeyPress(object sender, KeyPressEventArgs e)
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

        private void t10_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
