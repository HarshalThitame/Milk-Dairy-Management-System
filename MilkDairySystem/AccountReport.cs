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

    
    public partial class AccountReport : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = HARSHAL\MSSQLSERVER01; Initial Catalog = MILK; Integrated Security = True");
        SqlCommand cmd;
        DataTable dt = new DataTable("Accounts");


        public AccountReport()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }


        private void AccountReport_Load(object sender, EventArgs e)
        {
            this.gridview.DefaultCellStyle.Font = new Font("Comic sans ms", 10);

            try
            {
                DataTable ss = new DataTable();
                ss.Columns.Add("ID");
                ss.Columns.Add("Name");
                ss.Columns.Add("Address");
                ss.Columns.Add("Mobile");
                ss.Columns.Add("Cattle");
                ss.Columns.Add("Date");



                foreach (DataRow drow in ss.Rows)
                {
                    int num = gridview.Rows.Add();
                    gridview.Rows[num].Cells[0].Value = drow["ID"].ToString();
                    gridview.Rows[num].Cells[1].Value = drow["Name"].ToString();
                    gridview.Rows[num].Cells[2].Value = drow["Address"].ToString();
                    gridview.Rows[num].Cells[3].Value = drow["Mobile"].ToString();
                    gridview.Rows[num].Cells[4].Value = drow["Cattle"].ToString();
                    gridview.Rows[num].Cells[5].Value = drow["Date"].ToString();
                }
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (cn.State == ConnectionState.Closed)
                        cn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter("select AID as 'ID',FName +'  '+LName as 'Name',Address,Mobile,Cattle,EDate as'Date' from Account", cn)) 
                    {
                        da.Fill(ss);
                        gridview.DataSource = ss;

                    }

                }


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)13)
            {
               /* DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format(" like '%{0}%'", textBox1.Text);
                gridview.DataSource = dv.ToTable();
           */ }
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
            SqlDataAdapter adapt = new SqlDataAdapter("select AID as 'ID',FName +'  '+LName as 'Name',Address,Mobile,Cattle,EDate as'Date' from Account where FName like '" + textBox1.Text + "%'", con);
               DataTable ss = new DataTable();
            adapt.Fill(ss);
            gridview.DataSource = ss;
            con.Close();

        }

        private void gridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void lblfname_Click(object sender, EventArgs e)
        {

        }

        private void lbllname_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void gridview_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
