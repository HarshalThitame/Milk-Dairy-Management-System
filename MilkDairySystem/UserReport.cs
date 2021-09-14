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
    public partial class UserReport : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = HARSHAL\MSSQLSERVER01; Initial Catalog = MILK; Integrated Security = True");
        SqlCommand cmd;
        DataTable dt = new DataTable("Login");

        public UserReport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("select ID,FName+'  '+LName as 'Name',EMail,Address, username as 'Username', password as 'Password' from Login where FName like '" + textBox1.Text + "%'", con);
            DataTable ss = new DataTable();
            adapt.Fill(ss);
            gridview.DataSource = ss;
            con.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblfname_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lbllname_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void UserReport_Load(object sender, EventArgs e)
        {
            this.gridview.DefaultCellStyle.Font = new Font("Comic sans ms", 10);

            try
            {
                DataTable ss = new DataTable();
                ss.Columns.Add("ID");
                ss.Columns.Add("Name");
                ss.Columns.Add("EMail");
                ss.Columns.Add("Address");
                ss.Columns.Add("Username");
                ss.Columns.Add("Password");



                foreach (DataRow drow in ss.Rows)
                {
                    int num = gridview.Rows.Add();
                    gridview.Rows[num].Cells[0].Value = drow["ID"].ToString();
                    gridview.Rows[num].Cells[1].Value = drow["Name"].ToString();
                    gridview.Rows[num].Cells[2].Value = drow["EMail"].ToString();
                    gridview.Rows[num].Cells[3].Value = drow["Address"].ToString();
                    gridview.Rows[num].Cells[4].Value = drow["Username"].ToString();
                    gridview.Rows[num].Cells[5].Value = drow["Password"].ToString();
                }
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (cn.State == ConnectionState.Closed)
                        cn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter("select ID,FName+'  '+LName as 'Name',EMail,Address, username as 'Username', password as 'Password' from Login", cn))
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard f2 = new Dashboard(); //this is the change, code for redirect  
            f2.ShowDialog();
        }
    }
}
