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
using System.Configuration;

namespace MilkDairySystem
{
    public partial class Update_Feed_Price : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = HARSHAL\MSSQLSERVER01; Initial Catalog = MILK; Integrated Security = True");
        SqlCommand cmd;
        DataTable dt = new DataTable();

        public Update_Feed_Price()
        {
            InitializeComponent();
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {
            if (txtid.Text != "")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select FeedName,FeedPrice from AnimalFeed where ID =@ID", con);
                cmd.Parameters.AddWithValue("@ID", int.Parse(txtid.Text));
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    txtFname.Text = da.GetValue(0).ToString();
                    txtShowprice.Text = da.GetValue(1).ToString();
                   
                }

                con.Close();
            }
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = HARSHAL\MSSQLSERVER01; Initial Catalog = MILK; Integrated Security = True");
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd = new SqlCommand("update AnimalFeed set FeedPrice=@a1 where ID='" + txtid.Text + "'", con);
            cmd.Parameters.Add("a1", txtprice.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Has Updated In Database");
            gridview.Refresh();
            con.Close();
            if (txtid.Text != "")
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("Select FeedName,FeedPrice from AnimalFeed where ID =@ID", con);
                cmd1.Parameters.AddWithValue("@ID", int.Parse(txtid.Text));
                SqlDataReader da = cmd1.ExecuteReader();
                while (da.Read())
                {
                    txtFname.Text = da.GetValue(0).ToString();
                    txtShowprice.Text = da.GetValue(1).ToString();

                }

                con.Close();
            }

            this.gridview.DefaultCellStyle.Font = new Font("Comic sans ms", 10);

            DataTable ss = new DataTable();
            ss.Columns.Add("ID");
            ss.Columns.Add("Feed Name");
            ss.Columns.Add("Feed Price");




            foreach (DataRow drow in ss.Rows)
            {
                int num = gridview.Rows.Add();
                gridview.Rows[num].Cells[0].Value = drow["ID"].ToString();
                gridview.Rows[num].Cells[1].Value = drow["Feed Name"].ToString();
                gridview.Rows[num].Cells[2].Value = drow["Feed Price"].ToString();

            }
            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (cn.State == ConnectionState.Closed)
                        cn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter("select ID,FeedName as 'Feed Name',FeedPrice as 'Feed Price' from AnimalFeed", cn))
                    {
                        da.Fill(ss);
                        gridview.DataSource = ss;


                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Update_Feed_Price_Load(object sender, EventArgs e)
        {
            panel3.BackColor = Color.FromArgb(60, 0, 0, 0);
            timer1.Start();
            txttime.Text = DateTime.Now.ToLongTimeString();
            txtdate.Text = DateTime.Now.ToLongDateString();
            this.gridview.DefaultCellStyle.Font = new Font("Comic sans ms", 10);

            DataTable ss = new DataTable();
            ss.Columns.Add("ID");
            ss.Columns.Add("Feed Name");
            ss.Columns.Add("Feed Price");




            foreach (DataRow drow in ss.Rows)
            {
                int num = gridview.Rows.Add();
                gridview.Rows[num].Cells[0].Value = drow["ID"].ToString();
                gridview.Rows[num].Cells[1].Value = drow["Feed Name"].ToString();
                gridview.Rows[num].Cells[2].Value = drow["Feed Price"].ToString();
                
            }

            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (cn.State == ConnectionState.Closed)
                        cn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter("select ID,FeedName as 'Feed Name',FeedPrice as 'Feed Price' from AnimalFeed", cn))
                    {
                        da.Fill(ss);
                        gridview.DataSource = ss;


                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtid_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtprice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtprice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard f2 = new Dashboard(); //this is the change, code for redirect  
            f2.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txttime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
