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
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;


namespace MilkDairySystem
{
    public partial class Salary : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = HARSHAL\MSSQLSERVER01; Initial Catalog = MILK; Integrated Security = True");
        SqlConnection con1 = new SqlConnection(@"Data Source = HARSHAL\MSSQLSERVER01; Initial Catalog = MILK; Integrated Security = True");

        DataTable dt;
        DataTable table;
        public Salary()
        {
            InitializeComponent();
          
        }
       

        private void Salary_Load(object sender, EventArgs e)
        {

            timer1.Start();
            textBox1.Text = DateTime.Now.ToLongTimeString();
            textBox2.Text = DateTime.Now.ToLongDateString();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btngenerate_Click(object sender, EventArgs e)
        {
            if (txtacid.Text == "")
            {
                MessageBox.Show("Please, Enter your Account No !!", "Milk Management System");
            }
            else if (txtname.Text == "")
            {
                MessageBox.Show("Please, Enter your  Name !!", "Milk Management System");
            }
            else if (txtaddress.Text == "")
            {
                MessageBox.Show("Please, Enter your Address !!", "Milk Management System");
            }
            else if (txtmobile.Text == "")
            {
                MessageBox.Show("Please, Enter your Mobile", "Milk Management System");
            }
            else
            {
               con1.Open();
                if (txtacid.Text == "")
                {
                    txtfeed.Text = "";
                }
                    SqlCommand cmd1 = new SqlCommand("SELECT sum(Price) from Feed Where AID=@id", con1);

                cmd1.Parameters.AddWithValue("@id", int.Parse(txtacid.Text));
                SqlDataReader da1 = cmd1.ExecuteReader();
                while (da1.Read())
                {
                    txtfeed.Text = da1.GetValue(0).ToString();
                }
                con1.Close();
                con.Open();


                DataTable ss = new DataTable();
                ss.Columns.Add("ID");
                ss.Columns.Add("Date");
                ss.Columns.Add("Time");
                ss.Columns.Add("Cattle");
                ss.Columns.Add("Liter");
                ss.Columns.Add("Total Amount");



                foreach (DataRow drow in ss.Rows)
                {
                    int num = gridview.Rows.Add();
                    gridview.Rows[num].Cells[0].Value = drow["ID"].ToString();
                    gridview.Rows[num].Cells[1].Value = drow["Date"].ToString();
                    gridview.Rows[num].Cells[2].Value = drow["Time"].ToString();
                    gridview.Rows[num].Cells[3].Value = drow["Cattle"].ToString();
                    gridview.Rows[num].Cells[4].Value = drow["Liter"].ToString();
                    gridview.Rows[num].Cells[5].Value = drow["Total Amount"].ToString();
                }

                SqlCommand cmd = new SqlCommand("SELECT BID as 'ID',BDate as 'Date',BTime as 'Time',Cattle,Liter,TPrice as 'Total Amount' from Buy Where  BDate BETWEEN '" + dateTimePicker1.Text + "' AND '" + dateTimePicker2.Text + "' AND AID=@id", con);
                cmd.Parameters.AddWithValue("@id", int.Parse(txtacid.Text));
                SqlDataAdapter sda = new SqlDataAdapter();
                cmd.Connection = con;
                sda.SelectCommand = cmd;
               // DataTable dt1 = new DataTable();

                sda.Fill(ss);
                gridview.DataSource = ss;
                // dataGridView1.DataBind();
                ss = new DataTable();
                ss.Load(cmd.ExecuteReader());
                // con.Close();
              
              
                    con.Close();
                table = ss;

                double sum = 0;
                int sum1 = 0;
                for (int i = 0; i < gridview.Rows.Count; ++i)
                {
                    sum += Convert.ToDouble(gridview.Rows[i].Cells[5].Value);
                    sum1 += Convert.ToInt32(gridview.Rows[i].Cells[4].Value);
                }
                lbltotalprice.Text = sum.ToString();
                lbltotalliter.Text = sum1.ToString();
               
               
            }
        }
        public static string getHtml(DataTable table1)

        {
           
            try

            {


                string messageBody = "<font><h3>The following are the records:</h3> </font><br><br>";
                
                if (table1.Rows.Count == 0) return messageBody;

                string htmlTableStart = "<table style=\"border-collapse:collapse; text-align:center;\">";

                string htmlTableEnd = "</table>";

                string htmlHeaderRowStart = "<tr style=\"background-color: #6FA1D2; color:#ffffff;\">";

                string htmlHeaderRowEnd = "</tr>";

                string htmlTrStart = "<tr style=\"color: #555555;\">";

                string htmlTrend = "</tr>";

                string htmlTdStart = "<td style=\" border-color: #5c87b2; border-style:solid; border-width: thin; padding: 5px;\">";

                string htmlTdEnd = "</td>";

                messageBody += htmlTableStart;

                messageBody += htmlHeaderRowStart;

                messageBody += htmlTdStart + "ID" + htmlTdEnd;

                messageBody += htmlTdStart + "Date" + htmlTdEnd;
                messageBody += htmlTdStart + "Time" + htmlTdEnd;

                messageBody += htmlTdStart + "Cattle" + htmlTdEnd;

                messageBody += htmlTdStart + "Liter" + htmlTdEnd;

                messageBody += htmlTdStart + "Total Price" + htmlTdEnd;

                messageBody += htmlHeaderRowEnd;
                //Loop all the rows from grid vew and added to html td

                for (int i = 0; i <= table1.Rows.Count - 1; i++)

                {

                    messageBody = messageBody + htmlTrStart;

                    messageBody = messageBody + htmlTdStart + table1.Rows[i][0] + htmlTdEnd; //adding stu
                    messageBody = messageBody + htmlTdStart + table1.Rows[i][1] + htmlTdEnd; //adding DOB
                    messageBody = messageBody + htmlTdStart + table1.Rows[i][2] + htmlTdEnd; //adding Ema:
                    messageBody = messageBody + htmlTdStart + table1.Rows[i][3] + htmlTdEnd; //adding Mob:
                    messageBody = messageBody + htmlTdStart + table1.Rows[i][4] + htmlTdEnd; //adding Mob:
                    messageBody = messageBody + htmlTdStart + table1.Rows[i][5] + htmlTdEnd; //adding Mob;
                    messageBody = messageBody + htmlTrend;
                }

                messageBody = messageBody + htmlTableEnd;

                return messageBody; // return HTML Table as string from this function

            }
            catch (Exception)
            {
                return null;

            }
        }
        
        public void Email(string htmlString)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("milkdairymanagementsystem@gmail.com");
                message.To.Add(new MailAddress(Class1.ToMail));
                message.Subject = "Milk Salary "+ textBox2.Text;
                message.IsBodyHtml = true;
               
                message.Body = "<h2>   Amount : " + lbltotalprice.Text+"<br><br>  Total Liter : "+lbltotalliter.Text+"<br><br> Animal Feed Charge : -"+txtfeed.Text+ "<br><br>Bonus : " + lblbn.Text+ "<br><br>Total Amount : " + txttotal.Text+ "<br><br><br></h2>" + htmlString;

                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("milkdairymanagementsystem@gmail.com", "harshal1");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = HARSHAL\MSSQLSERVER01; Initial Catalog = MILK; Integrated Security = True");

            con.Open();
            if (txtacid.Text == "")
            {
                txtname.Text = "";
                txtaddress.Text = "";
                txtmobile.Text = "";
                txtmail.Text = "";
            }
            if (txtacid.Text != "")
            {
                SqlCommand cmd = new SqlCommand("Select FName , Address,Mobile,EMail from Account where AID =@ID", con);
                cmd.Parameters.AddWithValue("@ID", int.Parse(txtacid.Text));
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    txtname.Text = da.GetValue(0).ToString();
                    txtaddress.Text = da.GetValue(1).ToString();
                    txtmobile.Text = da.GetValue(2).ToString();
                    txtmail.Text = da.GetValue(3).ToString();
                }

                con.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtacid_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard f2 = new Dashboard(); //this is the change, code for redirect  
            f2.ShowDialog();
        }

        private void btnemail_Click(object sender, EventArgs e)
        {

            if (txtacid.Text == "")
            {
                MessageBox.Show("Please, Enter Your Account No !!", "Milk Management System");
            }
           else if (txttotal.Text == "")
            {
                MessageBox.Show("Please, Generate Salary !!", "Milk Management System");
            }
            else
            {
                DialogResult dr = MessageBox.Show("Are You Sure", "Confirm", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    Class1.ToMail = txtmail.Text;
                try
                {
                    string htmlString = getHtml(table);
                    Email(htmlString);
                    MessageBox.Show(txtmail.Text,"Email sent");
                        con.Open();
                      SqlCommand  cmd = new SqlCommand("insert into Salary(AID,Name,FromDate,ToDate,Liter,Amount,Feedcharge,Bonus,TAmount) values('" + txtacid.Text + "','" + txtname.Text + "','" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "','" + lbltotalliter.Text + "','" + lbltotalprice.Text + "','" + txtfeed.Text + "','" + lblbn.Text + "','" + txttotal.Text + "' )", con);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show( "Salary Updated");
                        con.Close();
                        /*
                        SqlConnection con1 = new SqlConnection(@"Data Source = HARSHAL\MSSQLSERVER01; Initial Catalog = MILK; Integrated Security = True");
                        SqlCommand cmd1 = new SqlCommand();
                        con1.Open();
                        string query1 = "delete from buy where AID='"+txtacid.Text+"' and BDate between '"+dateTimePicker1.Text+"' and '"+dateTimePicker2.Text+"' ";
                        SqlDataAdapter sda1 = new SqlDataAdapter(query1, con1);
                        sda1.SelectCommand.ExecuteNonQuery();
                       // MessageBox.Show("Delete Successfully...!!!!!!");

                        con1.Close();
                        */
                        SqlConnection con2 = new SqlConnection(@"Data Source = HARSHAL\MSSQLSERVER01; Initial Catalog = MILK; Integrated Security = True");
                        SqlCommand cmd2 = new SqlCommand();
                        con2.Open();
                        string query2 = "delete from Feed where AID='" + txtacid.Text + "'  ";
                        SqlDataAdapter sda2 = new SqlDataAdapter(query2, con2);
                        sda2.SelectCommand.ExecuteNonQuery();
                        // MessageBox.Show("Delete Successfully...!!!!!!");

                        con1.Close();


                    }
                catch (Exception)
                {
                    MessageBox.Show("No Network Connection");
                }
                }
                else if (dr == DialogResult.No)
                {
                    MessageBox.Show("Cancelled");
                }
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            textBox1.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
             
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void lbltotalprice_TextChanged(object sender, EventArgs e)
        {
            if (lbltotalprice.Text.Length > 0 && txtfeed.Text.Length > 0 && txttotal.Text.Length > 0)
            {
                txttotal.Text = Convert.ToString(Convert.ToDouble(lbltotalprice.Text) - Convert.ToDouble(txtfeed.Text));
                // txtt4.Text = Convert.ToString(Convert.ToInt32(txtt1.Text) * Convert.ToInt32(txtt2.Text));
            }
            if (txtfeed.Text.Length > 0 && lbltotalprice.Text.Length == 0)
            {
                txttotal.Text = "0";
                //txtt4.Text = "0";
            }
            if (txtfeed.Text.Length == 0 && lbltotalprice.Text.Length > 0)
            {
                txttotal.Text = "0";
                //  txtt4.Text = "0";
            }
            if (txtfeed.Text.Length == 0 && lbltotalprice.Text.Length == 0)
            {
                txttotal.Text = "0";
                // txtt4.Text = "0";
            }
        }

        private void txttotal_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txttotal.Text))
            {
                txttotal.Text = "0";
            }
        }

        private void txtfeed_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtbonus.Text))
                {
                    txtbonus.Text = "0";

                }
                else
                {

                    lblbn.Text = Convert.ToString((Convert.ToDouble(txtbonus.Text) / 100) * Convert.ToDouble(lbltotalprice.Text));
                    //    txttotal.Text = Convert.ToString(Convert.ToDouble(lbltotalprice) + Convert.ToString(lblbn.Text));

                    // txtt4.Text = Convert.ToString(Convert.ToInt32(txtt1.Text) * Convert.ToInt32(txtt2.Text));

                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("", "ERROR");
            }
        }
        private void txtfeed_Click(object sender, EventArgs e)
        {
           

        }

        private void txtfeed_TextChanged_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtfeed.Text))
            {
                txtfeed.Text = "0";
            }
            else
            {
                if (lbltotalprice.Text.Length > 0 && txtfeed.Text.Length > 0 && txttotal.Text.Length > 0)
                {
                    txttotal.Text = Convert.ToString(Convert.ToDouble(lbltotalprice.Text) - Convert.ToDouble(txtfeed.Text));
                    // txtt4.Text = Convert.ToString(Convert.ToInt32(txtt1.Text) * Convert.ToInt32(txtt2.Text));
                }
                if (txtfeed.Text.Length > 0 && lbltotalprice.Text.Length == 0)
                {
                    txttotal.Text = "0";
                    //txtt4.Text = "0";
                }
                if (txtfeed.Text.Length == 0 && lbltotalprice.Text.Length > 0)
                {
                    txttotal.Text = "0";
                    //  txtt4.Text = "0";
                }
                if (txtfeed.Text.Length == 0 && lbltotalprice.Text.Length == 0)
                {
                    txttotal.Text = "0";
                    // txtt4.Text = "0";
                }
            }
        }

        private void lblbn_Click(object sender, EventArgs e)
        {

        }

        private void lblbn_TextChanged(object sender, EventArgs e)
        {
            if (lbltotalprice.Text.Length > 0 && txtfeed.Text.Length > 0 && txttotal.Text.Length > 0)
            {
                txttotal.Text = Convert.ToString(Convert.ToDouble(lbltotalprice.Text) - Convert.ToDouble(txtfeed.Text) + Convert.ToDouble(lblbn.Text));
                // txtt4.Text = Convert.ToString(Convert.ToInt32(txtt1.Text) * Convert.ToInt32(txtt2.Text));
            }
            if (txtfeed.Text.Length > 0 && lbltotalprice.Text.Length == 0)
            {
                txttotal.Text = "0";
                //txtt4.Text = "0";
            }
            if (txtfeed.Text.Length == 0 && lbltotalprice.Text.Length > 0)
            {
                txttotal.Text = "0";
                //  txtt4.Text = "0";
            }
            if (txtfeed.Text.Length == 0 && lbltotalprice.Text.Length == 0)
            {
                txttotal.Text = "0";
                // txtt4.Text = "0";
            }
        }
    }
}
