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
    public partial class Sell_Report : Form
    {
        public Sell_Report()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Sell_Report_Load(object sender, EventArgs e)
        {
            this.gridview.DefaultCellStyle.Font = new Font("Comic sans ms", 10);

            try
            {
                DataTable ss = new DataTable();
                ss.Columns.Add("Name");
                ss.Columns.Add("Address");
                ss.Columns.Add("E-Mail");
                ss.Columns.Add("TOtal Milk");
                ss.Columns.Add("Avarage Fat");
                ss.Columns.Add("Price / Liter");
                ss.Columns.Add("Amount");
                ss.Columns.Add("Date");




                foreach (DataRow drow in ss.Rows)
                {
                    int num = gridview.Rows.Add();
                    gridview.Rows[num].Cells[0].Value = drow["Name"].ToString();
                    gridview.Rows[num].Cells[1].Value = drow["Address"].ToString();
                    gridview.Rows[num].Cells[2].Value = drow["E-Mail"].ToString();
                    gridview.Rows[num].Cells[3].Value = drow["Total Milk"].ToString();
                    gridview.Rows[num].Cells[4].Value = drow["Avarage Fat"].ToString();
                    gridview.Rows[num].Cells[5].Value = drow["Price / Liter"].ToString();
                    gridview.Rows[num].Cells[6].Value = drow["Amount"].ToString();
                    gridview.Rows[num].Cells[7].Value = drow["Date"].ToString();

                }
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (cn.State == ConnectionState.Closed)
                        cn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter("select SName as 'Name',SAddress as 'Address',SMail as 'E-Mail',TotalMilk as 'Total Milk',AvgFat as 'Avarage Fat',Price as 'Price / Liter',Amount,Date from Sell", cn))
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard f2 = new Dashboard(); //this is the change, code for redirect  
            f2.ShowDialog();
        }
    }
}
