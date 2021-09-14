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
    public partial class AnimalFeed : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = HARSHAL\MSSQLSERVER01; Initial Catalog = MILK; Integrated Security = True");
        SqlCommand cmd;
        public AnimalFeed()
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

        private void AnimalFeed_Load(object sender, EventArgs e)
        {
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
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
        }

        private void AnimalFeed_Load_1(object sender, EventArgs e)
        {
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
            SqlDataReader da6 = cmd6.ExecuteReader();
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
    }
}
