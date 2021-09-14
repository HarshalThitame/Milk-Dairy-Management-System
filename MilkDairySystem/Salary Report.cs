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
    public partial class Salary_Report : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = HARSHAL\MSSQLSERVER01; Initial Catalog = MILK; Integrated Security = True");

        public Salary_Report()
        {
            InitializeComponent();
        }

        private void Salary_Report_Load(object sender, EventArgs e)
        {
            this.gridview.DefaultCellStyle.Font = new Font("Comic sans ms", 10);

            try
            {
                DataTable ss = new DataTable();
                ss.Columns.Add("ID");
                ss.Columns.Add("Name");
                ss.Columns.Add("From Date");
                ss.Columns.Add("To Date");
                ss.Columns.Add("Liter");
                ss.Columns.Add("Amount");
                ss.Columns.Add("Feed Charge");
                ss.Columns.Add("Bonus");
                ss.Columns.Add("Total Amount");



                foreach (DataRow drow in ss.Rows)
                {
                    int num = gridview.Rows.Add();
                    gridview.Rows[num].Cells[0].Value = drow["ID"].ToString();
                    gridview.Rows[num].Cells[1].Value = drow["Name"].ToString();
                    gridview.Rows[num].Cells[2].Value = drow["From Date"].ToString();
                    gridview.Rows[num].Cells[3].Value = drow["To Date"].ToString();
                    gridview.Rows[num].Cells[4].Value = drow["Liter"].ToString();
                    gridview.Rows[num].Cells[5].Value = drow["Amount"].ToString();
                    gridview.Rows[num].Cells[6].Value = drow["Feed Charge"].ToString();
                    gridview.Rows[num].Cells[7].Value = drow["Bonus"].ToString();
                    gridview.Rows[num].Cells[8].Value = drow["Total Amount"].ToString();
                }
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (cn.State == ConnectionState.Closed)
                        cn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter("select AID as 'ID',Name,FromDate as 'From Date',ToDate as 'To Date',Liter,Amount,Feedcharge as'Feed Charge',Bonus,TAmount as'Total Amount' from Salary", cn))
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("select  AID as 'ID',Name,FromDate as 'From Date',ToDate as 'To Date',Liter,Amount,Feedcharge as'Feed Charge',Bonus,TAmount as'Total Amount'  from Salary where Name like '" + textBox1.Text + "%'", con);
            DataTable ss = new DataTable();
            adapt.Fill(ss);
            gridview.DataSource = ss;
            con.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard f2 = new Dashboard(); //this is the change, code for redirect  
            f2.ShowDialog();
        }
    }
}
