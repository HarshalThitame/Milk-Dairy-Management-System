using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkDairySystem
{
    public partial class Sell_Milk : Form
    {
        public Sell_Milk()
        {
            InitializeComponent();
        }
        public void ClearTextBoxes(Control.ControlCollection ctrlCollection)
        {
            foreach (Control ctrl in ctrlCollection)
            {
                if (ctrl is TextBoxBase)
                {
                    ctrl.Text = String.Empty;
                }
                else
                {
                    ClearTextBoxes(ctrl.Controls);
                }
            }
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txttmilk_TextChanged(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection(@"Data Source = HARSHAL\MSSQLSERVER01; Initial Catalog = MILK; Integrated Security = True");
        SqlCommand cmd;
        private void Sell_Milk_Load(object sender, EventArgs e)
        {
           
            string Sql = "select Fname+' ' +Lname from Seller";
            SqlCommand cmd11 = new SqlCommand(Sql, con);
            //SqlCommand cmd11 = new SqlCommand();
            SqlDataAdapter da11 = new SqlDataAdapter(cmd11);
            DataSet ds = new DataSet();
            da11.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                comboBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());


            panel3.BackColor = Color.FromArgb(60, 0, 0, 0);
            timer1.Start();
            txtime.Text = DateTime.Now.ToLongTimeString();
            txtdate.Text = DateTime.Now.ToLongDateString();
            con.Open();
            SqlCommand cmd = new SqlCommand("Select sum(Liter) from Buy", con);
            SqlDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                txttmilk.Text = da.GetValue(0).ToString();
            }

            con.Close();
            con.Open();
            SqlCommand cmd1 = new SqlCommand("select cast(avg(Fat) as decimal(10,2)) from Buy", con);
            SqlDataReader da1 = cmd1.ExecuteReader();
            while (da1.Read())
            {
                txtafat.Text = da1.GetValue(0).ToString();
            }

            con.Close();
            if (txttmilk.Text.Length > 0 && txtafat.Text.Length > 0 )
            {
                double v1 = Convert.ToDouble(txtafat.Text);
                double v2 = 7;
                double v3 = v1 * v2;
                txtprice.Text = v3.ToString();
            }

            if (txttmilk.Text.Length > 0 && txtafat.Text.Length > 0)
            {
                double v1 = Convert.ToDouble(txttmilk.Text);
                double v2 = Convert.ToDouble(txtprice.Text);
                double v3 = v1 * v2;
                txttamount.Text = v3.ToString();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard f2 = new Dashboard(); //this is the change, code for redirect  
            f2.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                if (txtAddress.Text == "")
                {
                    MessageBox.Show("Please, Enter Address", "Milk Management System");

                }
                else if (txtmail.Text == "")
                {
                    _ = MessageBox.Show(text: "Please, Enter E-Mail", "Milk Management System");

                }
                else if (txttmilk.Text == "" || txttmilk.Text == "0")
                {
                    _ = MessageBox.Show(text: " Milk Tank is Empty.!!!", "Oh No");

                }
                else
                {
                    con.Open();
                    cmd = new SqlCommand("insert into Sell(SName,SAddress,SMail,TotalMilk,AvgFat,Price,Amount,Date) values('" + comboBox1.Text + "','" + txtAddress.Text + "','" + txtmail.Text + "','" + txttmilk.Text + "','" + txtafat.Text + "','" + txtprice.Text + "','" + txttamount.Text + "','" + txtdate.Text + "' )", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Milk Sold.", "  ", MessageBoxButtons.OK);
                    ClearTextBoxes(this.Controls);
                    con.Close();
                    /*
                    con.Open();
                    string query2 = "delete from Buy  ";
                    SqlDataAdapter sda2 = new SqlDataAdapter(query2, con);
                    sda2.SelectCommand.ExecuteNonQuery();
                    // MessageBox.Show("Delete Successfully...!!!!!!");

                    con.Close();
                */
                } 
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard f2 = new Dashboard(); //this is the change, code for redirect  
            f2.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source = HARSHAL\MSSQLSERVER01; Initial Catalog = MILK; Integrated Security = True");

            con.Open();
#pragma warning disable CS0252 // Possible unintended reference comparison; left hand side needs cast
            if (comboBox1.SelectedItem == "")
#pragma warning restore CS0252 // Possible unintended reference comparison; left hand side needs cast
            {
                txtAddress.Text = "";
                //comboCattle.SelectedItem = "";
                txtmail.Text = "";
                //txtlname.Text = "";
               // txtname.Text = "";

            }
            if (comboBox1.Text != "")
            {
                SqlCommand cmd = new SqlCommand("Select  Address ,Mail from Seller where Fname+' '+Lname ='"+comboBox1.SelectedItem+"'", con);
               // cmd.Parameters.AddWithValue("@ID", int.Parse(comboBox1.Text));
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    txtAddress.Text = da.GetValue(0).ToString();
                    txtmail.Text = da.GetValue(1).ToString();
                    //   comboCattle.Items.Add(da[3].ToString());
                }

                con.Close();
            }

        }
    }
}
