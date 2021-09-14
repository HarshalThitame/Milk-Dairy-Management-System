using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkDairySystem
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();

        }
        SqlConnection con = new SqlConnection(@"Data Source = HARSHAL\MSSQLSERVER01; Initial Catalog = MILK; Integrated Security = True");

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            //panel3.BackColor = Color.FromArgb(60, 0, 0, 0);

            lblfname.Text = Form1.rcby;

            timer1.Start();
            textBox1.Text = DateTime.Now.ToLongTimeString();
            textBox2.Text = DateTime.Now.ToLongDateString();
            
            
            con.Open();

            SqlCommand cmd1 = new SqlCommand("SELECT sum(Liter) from Buy ", con);

            SqlDataReader da1 = cmd1.ExecuteReader();
            while (da1.Read())
            {
                label7.Text = da1.GetValue(0).ToString() + " Ltr";
            }
            con.Close();

            con.Open();


            string strDateFormat = null;
            // DateTime datetime = Convert.ToDateTime(Date.Text);
         //   DateTime date = DateTime.ParseExact(label6.Text, strDateFormat, CultureInfo.InvariantCulture);
                SqlCommand cmd = new SqlCommand("SELECT sum(Liter) from Buy where BDate=(CONVERT(varchar(10),getdate(),110))", con);
                 // cmd.Parameters.AddWithValue("@date",Convert.ToDateTime(label6.Text));
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    
                        label8.Text = da.GetValue(0).ToString() + " Ltr";
                }
            
            con.Close();

            con.Open();

            SqlCommand cmd2 = new SqlCommand("SELECT count(AID) from Account ", con);

            SqlDataReader da2 = cmd2.ExecuteReader();
            while (da2.Read())
            {
                label9.Text = da2.GetValue(0).ToString() + " Farmers";
            }
            con.Close();

        }

        private void nEWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddAccount f2 = new AddAccount(); //this is the change, code for redirect  
            f2.ShowDialog();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f2 = new Form1(); //this is the change, code for redirect  
            f2.ShowDialog();
        }

        private void aDDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddUser f2 = new AddUser(); //this is the change, code for redirect  
            f2.ShowDialog();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void fATPRICEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Fat f2 = new Fat(); //this is the change, code for redirect  
            f2.ShowDialog();
        }

        private void bUYMILKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            BuyMilk f2 = new BuyMilk(); //this is the change, code for redirect  
            f2.ShowDialog();
        }

        private void sALARYToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Salary f2 = new Salary(); //this is the change, code for redirect  
            f2.ShowDialog();
        }

        private void lbluser_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Exit?...", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                Application.Exit();

            }
        }

        private void eDITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditAccount f2 = new EditAccount(); //this is the change, code for redirect  
            f2.ShowDialog();
        }

        private void rEPORTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserReport f2 = new UserReport(); //this is the change, code for redirect  
            f2.ShowDialog();

        }

        private void rEPORTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AccountReport f2 = new AccountReport(); //this is the change, code for redirect  
            f2.ShowDialog();

        }

        private void aCCOUNTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AccountReport f2 = new AccountReport(); //this is the change, code for redirect  
            f2.ShowDialog();

        }

        private void eDITToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Animal_Feed f2 = new Animal_Feed(); //this is the change, code for redirect  
            f2.ShowDialog();
        }

        private void fEEDPRICEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Update_Feed_Price f2 = new Update_Feed_Price(); //this is the change, code for redirect  
            f2.ShowDialog();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel3_DoubleClick(object sender, EventArgs e)
        {

        }

        private void panel4_DoubleClick(object sender, EventArgs e)
        {
            this.Hide();
            AccountReport f2 = new AccountReport(); //this is the change, code for redirect  
            f2.ShowDialog();
        }

        private void uSERToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserReport f2 = new UserReport(); //this is the change, code for redirect  
            f2.ShowDialog();
        }

        private void sALARYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Salary f2 = new Salary(); //this is the change, code for redirect  
            f2.ShowDialog();
        }

        private void mILKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Milk_Report f2 = new Milk_Report(); //this is the change, code for redirect  
            f2.ShowDialog();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void salaryToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Salary_Report f2 = new Salary_Report(); //this is the change, code for redirect  
            f2.ShowDialog();
        }

        private void sOLDMILKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sell_Report f2 = new Sell_Report(); //this is the change, code for redirect  
            f2.ShowDialog();
        }

        private void sELLMILKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sell_Milk f2 = new Sell_Milk(); //this is the change, code for redirect  
            f2.ShowDialog();
        }

        private void aDDSELLERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            add_seller f2 = new add_seller(); //this is the change, code for redirect  
            f2.ShowDialog();
        }
    }
}
