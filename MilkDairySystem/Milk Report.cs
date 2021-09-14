using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkDairySystem
{
    public partial class Milk_Report : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = HARSHAL\MSSQLSERVER01; Initial Catalog = MILK; Integrated Security = True");
        SqlCommand cmd;
        DataTable dt = new DataTable("Buy");
        public Milk_Report()
        {
            InitializeComponent();
        }

        private void Milk_Report_Load(object sender, EventArgs e)
        {

            this.gridview.DefaultCellStyle.Font = new Font("Comic sans ms", 10);

           
                DataTable ss = new DataTable();
                ss.Columns.Add("ID");
                ss.Columns.Add("Account");
                ss.Columns.Add("Date");
                ss.Columns.Add("Time");
                ss.Columns.Add("Cattle");
                ss.Columns.Add("Liter");
                ss.Columns.Add("Fat");
                ss.Columns.Add("Price");
                ss.Columns.Add("Total Price");



                foreach (DataRow drow in ss.Rows)
                {
                    int num = gridview.Rows.Add();
                    gridview.Rows[num].Cells[0].Value = drow["ID"].ToString();
                    gridview.Rows[num].Cells[1].Value = drow["Account"].ToString();
                    gridview.Rows[num].Cells[2].Value = drow["Date"].ToString();
                    gridview.Rows[num].Cells[3].Value = drow["Time"].ToString();
                    gridview.Rows[num].Cells[4].Value = drow["Cattle"].ToString();
                    gridview.Rows[num].Cells[5].Value = drow["Liter"].ToString();
                    gridview.Rows[num].Cells[6].Value = drow["Fat"].ToString();
                    gridview.Rows[num].Cells[7].Value = drow["Price"].ToString();
                    gridview.Rows[num].Cells[8].Value = drow["Total Price"].ToString();
                }
                try
                {
                    using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                    {
                        if (cn.State == ConnectionState.Closed)
                            cn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter("select BID as 'Id',Account.FName+' '+LName as'Account', Buy.BDate as 'Date',Buy.BTime as 'Time',Buy.Cattle,Buy.Liter,Buy.Fat,Buy.Price,Buy.TPrice as 'Total Price' from Buy,Account where Account.AID=Buy.AID", cn))
                        {
                            da.Fill(dt);
                            gridview.DataSource = dt;


                        }

                    }
                

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            
        }   

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("Account like '%{0}%'", textBox1.Text);
                gridview.DataSource = dv.ToTable();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard f2 = new Dashboard(); //this is the change, code for redirect  
            f2.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("select BID as 'Id',Account.FName+' '+LName as'Account', Buy.BDate as 'Date',Buy.BTime as 'Time',Buy.Cattle,Buy.Liter,Buy.Fat,Buy.Price,Buy.TPrice as 'Total Price' from Buy,Account where Account.AID=Buy.AID and FName like '" + textBox1.Text + "%'", con);
            DataTable ss = new DataTable();
            adapt.Fill(ss);
            gridview.DataSource = ss;
            con.Close();
        }
    }
}
