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
using System.Net.Mail;
using System.Net;
using System.IO;
using System.IO.Ports;
using System.Threading;
using Newtonsoft.Json;


namespace MilkDairySystem
{
    public partial class BuyMilk : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = HARSHAL\MSSQLSERVER01; Initial Catalog = MILK; Integrated Security = True");
        SqlCommand cmd;
        DataTable dt;
        DataTable table;
        public BuyMilk()
        {
            InitializeComponent();
        }

        private void BuyMilk_Load(object sender, EventArgs e)
        {
            timer1.Start();
            textBox1.Text = DateTime.Now.ToLongTimeString();
            textBox2.Text = DateTime.Now.ToLongDateString();

            /*
            this.GvAccount.DefaultCellStyle.Font = new Font("Comic sans ms", 10);

            DataTable ss = new DataTable();
            ss.Columns.Add("Date");
            ss.Columns.Add("Time");
            ss.Columns.Add("Liter");
            ss.Columns.Add("Fat");
            ss.Columns.Add("Total Price");


            foreach (DataRow drow in ss.Rows)
            {
                int num = GvAccount.Rows.Add();
                GvAccount.Rows[num].Cells[0].Value = drow["Date"].ToString();
                GvAccount.Rows[num].Cells[1].Value = drow["Time"].ToString();
                GvAccount.Rows[num].Cells[2].Value = drow["Liter"].ToString();
                GvAccount.Rows[num].Cells[3].Value = drow["Fat"].ToString();
                GvAccount.Rows[num].Cells[4].Value = drow[" TotalPrice"].ToString();
            }

            SqlDataAdapter da1 = new SqlDataAdapter("select Buy.BDate as 'Date',BTime as 'Time',Buy.Liter,Buy.Fat,Buy.TPrice as 'Total Price' from Buy,Account where Buy.AID=Account.AID and BDate=(CONVERT(varchar(10),getdate(),110)) ; ", con);
            //DataTable ss1 = new DataTable();
            da1.Fill(ss);
            GvAccount.DataSource = ss;
            con.Close();
            */
            this.gridview.DefaultCellStyle.Font = new Font("Comic sans ms", 10);

            DataTable ss1 = new DataTable();
            ss1.Columns.Add("ID");
            ss1.Columns.Add("Name");
            ss1.Columns.Add("Date");
            ss1.Columns.Add("Liter");
            ss1.Columns.Add("Fat");
            ss1.Columns.Add("Total Price");



            foreach (DataRow drow in ss1.Rows)
            {
                int num = gridview.Rows.Add();
                gridview.Rows[num].Cells[0].Value = drow["ID"].ToString();
                gridview.Rows[num].Cells[1].Value = drow["Name"].ToString();
                gridview.Rows[num].Cells[2].Value = drow["Date"].ToString();
                gridview.Rows[num].Cells[3].Value = drow["Liter"].ToString();
                gridview.Rows[num].Cells[4].Value = drow["Fat"].ToString();
                gridview.Rows[num].Cells[5].Value = drow["Total Price"].ToString();
            }
            SqlDataAdapter da = new SqlDataAdapter("select Buy.AID as 'ID',Account.FName+' '+LName as 'Name',Buy.BDate as 'Date',Buy.Liter,Buy.Fat,Buy.TPrice as 'Total Price' from Buy,Account where Buy.AID=Account.AID Order by Buy.BDate ; ", con);
            //DataTable ss1 = new DataTable();
            da.Fill(ss1);
            gridview.DataSource = ss1;
            con.Close();
            txtDate.Text = DateTime.Now.ToLongDateString();

            if (DateTime.Now.Hour < 12)
            {
                txtShowAMPM.Text = "Morning";
                // lblDate.Text = Convert.ToString(DateTime.Now);
            }

            else
            {
                txtShowAMPM.Text = "Evening";
                //  lblDate.Text = Convert.ToString(DateTime.Now);
            }
            panel3.BackColor = Color.FromArgb(60, 0, 0, 0);

        }
    


        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
         /*   con.Open();
            cmd = new SqlCommand("select FName,Address,Cattle from Account where AID='" + int.Parse(txtAcNo.Text) + "'", con);
            SqlDataReader srd = cmd.ExecuteReader();
            while(srd.Read())
            {
                txtName.Text = srd.GetValue(0).ToString();
                txtAddress.Text = srd.GetValue(1).ToString();
                txtCattle.Text = srd.GetValue(2).ToString();
            }
            con.Close();
         */
        }

        private void txtAcNo_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = HARSHAL\MSSQLSERVER01; Initial Catalog = MILK; Integrated Security = True");

            con.Open();
            if (txtAcNo.Text == "")
            {
                lbladdress.Text = "";
                lblmail.Text = "";
                lblmobile.Text = "";
                lblcattle.Text = "";
                lblname.Text = "";
                txtliter.Text = "";
                txtfat.Text = "";
                txtclr.Text = "";
                txtsnf.Text = "";
                txtprice.Text = "";
                txttprice.Text = "";

            }
            if (txtAcNo.Text != "")
            {
                SqlCommand cmd = new SqlCommand("Select FName+' '+LName , EMail,Mobile, Address , Cattle from Account where AID =@ID", con);
                cmd.Parameters.AddWithValue("@ID", int.Parse(txtAcNo.Text));
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    lblname.Text = da.GetValue(0).ToString();
                    lblmail.Text = da.GetValue(1).ToString();
                    lblmobile.Text = da.GetValue(2).ToString();
                    lbladdress.Text = da.GetValue(3).ToString();
                    lblcattle.Text = da.GetValue(4).ToString();

                }
               
                con.Close();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

            if (txtclr.Text.Length > 0 && txtfat.Text.Length > 0)
            {
                txtsnf.Text = Convert.ToString((Convert.ToDouble(txtclr.Text) * 0.25) + (Convert.ToDouble(txtfat.Text) * 0.22) + 0.72);
                // txtt4.Text = Convert.ToString(Convert.ToInt32(txtt1.Text) * Convert.ToInt32(txtt2.Text));
            }
            if (txtfat.Text.Length > 0 && txtclr.Text.Length == 0)
            {
                txtsnf.Text = "0";
                //txtt4.Text = "0";
            }
            if (txtfat.Text.Length == 0 && txtclr.Text.Length > 0)
            {
                txtsnf.Text = "0";
                //  txtt4.Text = "0";
            }
            if (txtfat.Text.Length == 0 && txtclr.Text.Length == 0)
            {
                txtsnf.Text = "0";
                // txtt4.Text = "0";
            }
        }

        private void txtprice_TextChanged(object sender, EventArgs e)
        {
            if (txtprice.Text.Length > 0 && txtliter.Text.Length > 0 && txttprice.Text.Length > 0)
            {
                txttprice.Text = Convert.ToString(Convert.ToDouble(txtliter.Text) * Convert.ToDouble(txtprice.Text));
                // txtt4.Text = Convert.ToString(Convert.ToInt32(txtt1.Text) * Convert.ToInt32(txtt2.Text));
            }
            if (txtfat.Text.Length > 0 && txtclr.Text.Length == 0)
            {
                txttprice.Text = "0";
                //txtt4.Text = "0";
            }
            if (txtfat.Text.Length == 0 && txtclr.Text.Length > 0)
            {
                txttprice.Text = "0";
                //  txtt4.Text = "0";
            }
            if (txtfat.Text.Length == 0 && txtclr.Text.Length == 0)
            {
                txttprice.Text = "0";
                // txtt4.Text = "0";
            }


        }

        private void txtDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void GvAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
           

         
             if (txtliter.Text == "")
            {
                MessageBox.Show("Please, Enter Liter", "Milk Management System");
            }
            else if (txtfat.Text == "")
            {
                MessageBox.Show("Please, Enter Fat", "Milk Management System");

            }
            else if (txtprice.Text == "")
            {
                _ = MessageBox.Show(text: "Please, Enter Price", "Milk Management System");

            }
            else
            {
                DataTable ss = new DataTable();
                ss.Columns.Add("Date");
                ss.Columns.Add("Time");
                ss.Columns.Add("Liter");
                ss.Columns.Add("Fat");
                ss.Columns.Add("Price");

                DataRow row = ss.NewRow();
                row["Date"] = txtDate.Text;
                row["Time"] = txtShowAMPM.Text;
                row["Liter"] = txtliter.Text;
                row["Fat"] = txtfat.Text;
                row["Price"] = txttprice.Text;
                ss.Rows.Add(row);

                foreach (DataRow drow in ss.Rows)
                {
                    int num = GvAccount.Rows.Add();
                    GvAccount.Rows[num].Cells[0].Value = drow["Date"].ToString();
                    GvAccount.Rows[num].Cells[1].Value = drow["Time"].ToString();
                    GvAccount.Rows[num].Cells[2].Value = drow["Liter"].ToString();
                    GvAccount.Rows[num].Cells[3].Value = drow["Fat"].ToString();
                    GvAccount.Rows[num].Cells[4].Value = drow["Price"].ToString();
                }
                con.Open();
                cmd = new SqlCommand("insert into Buy(AID,BDate,BTime,Cattle,Liter,Fat,Price,TPrice) values('" + txtAcNo.Text + "','" + txtDate.Text + "','" + txtShowAMPM.Text + "','" + lblcattle.Text + "','" + txtliter.Text + "','" + txtfat.Text + "','" + txtprice.Text + "','" + txttprice.Text + "' )", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Has Saved In Database");
                con.Close();
               
            }
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select Buy.AID,FName+' '+LName as 'Name',BDate,Liter,Fat,TPrice as 'Total Price' from Buy,Account where Buy.AID=Account.AID Order by BDate ; ", con);
            DataTable ss1 = new DataTable();
            da.Fill(ss1);
            gridview.DataSource = ss1;
            con.Close();
            
        }

        private void txtfat_TextChanged(object sender, EventArgs e)
        {
                       

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
          

        }

        private void GvToday_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtAcNo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard f2 = new Dashboard(); //this is the change, code for redirect  
            f2.ShowDialog();
        }
      /*  public class Response
        {
            public string message_id { get; set; }
            public int message_count { get; set; }
            public double price { get; set; }
        }

        public class RootObject
        {
            public Response Response { get; set; }
            public string ErrorMessage { get; set; }
            public int Status { get; set; }
        }
      */
        private void btnclear_Click(object sender, EventArgs e)
        {
            
                try
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                    mail.From = new MailAddress("milkdairymanagementsystem@gmail.com");
                    mail.To.Add(new MailAddress(lblmail.Text));
                    mail.Subject = "Milk - " + txtDate.Text+" - "+txtShowAMPM.Text;
                    mail.IsBodyHtml = true;
                    string htmlBody;
                   string Price = txttprice.Text;
                    string liter = txtliter.Text;
                    string fat = txtfat.Text;
                    string clr = txtclr.Text;
                    string snf = txtsnf.Text;
                    string name=lblname.Text;
                    string id = txtAcNo.Text;
                    string mob = lblmobile.Text;
                    string addr = lbladdress.Text;
                    string email = lblmail.Text;
                    string cattle = lblcattle.Text;

                    htmlBody = "<h1 style=text-align:center>INVOICE</h1><table width=1000px; border=5><h5 style=text-align:center>ID - " + id + "<br><br>Name - " + name+ "<br><br>Cattle - "+cattle+ "<br><br><br><br></h3><h2 style=color:green>Quantity=  " + liter + " Ltr<br><br>Milk Fat= " + fat+ "%<br><br>Milk CLR= " + clr+ "<br><br>Milk SNF= " + snf+ "<br><br>Total Price=  Rs. " + Price+ "</h2><br><br><br><br><br><h2>||..............Milk  Dairy  Management  System..............||</h2></table>";
                    mail.Body = htmlBody;


                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("milkdairymanagementsystem@gmail.com", "harshal1");
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);
                   // return messageBody;
                    MessageBox.Show(lblmail.Text,"Mail Sent");
                }
                catch (Exception)
                {
                    MessageBox.Show("No Internet...?", "Something Went Wrong");
                }
            
            //  string key = txtKey.Text;
            // string secret = txtSecret.Text;
            /* string to = txtmobile.Text;
             string messages = "your_milk_total_price="+txttprice.Text;

             string sURL;


             sURL = "https://www.thetexting.com/rest/sms/json/message/send?api_key=qordao11aupt9mj&api_secret=9divifaml1aak3s&to=" + to + "&text=" + messages;

             try
             {

                 using (WebClient client = new WebClient())
                 {

                     string s = client.DownloadString(sURL);

                     var responseObject = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(s);
                     int n = responseObject.Status;
                     if (n == 3)
                     {
                         MessageBox.Show("Something went wrong with your credentials", "My Demo App");

                     }
                     else
                     {
                         MessageBox.Show("Message Send Successfully", "My Demo App");
                     }

                 }


             }
             catch (Exception ex)
             {
                 MessageBox.Show("Something went wrong with your information", "My Demo App");
                 ex.ToString();
             }*/
        }

        private void txtclr_TextChanged(object sender, EventArgs e)
        {

            if (txtclr.Text.Length > 0 && txtfat.Text.Length > 0 && txtsnf.Text.Length >0)
            {
                txtsnf.Text = Convert.ToString((Convert.ToDouble(txtclr.Text) * 0.25) + (Convert.ToDouble(txtfat.Text) * 0.22) + 0.72);
            }
            if (txtfat.Text.Length > 0 && txtclr.Text.Length == 0)
            {
                txtsnf.Text = "0";
                //txtt4.Text = "0";
            }
            if (txtfat.Text.Length == 0 && txtclr.Text.Length > 0)
            {
                txtsnf.Text = "0";
                //  txtt4.Text = "0";
            }
            if (txtfat.Text.Length == 0 && txtclr.Text.Length == 0)
            {
                txtsnf.Text = "0";
                // txtt4.Text = "0";
            }
            


        }

        private void txtsnf_TextChanged(object sender, EventArgs e)
        {
            if (txtclr.Text.Length > 0 && txtfat.Text.Length > 0 && txtsnf.Text.Length > 0)
            {
                double v1 = Convert.ToDouble(txtfat.Text);
                double v2 = Convert.ToDouble(txtsnf.Text);
                double v3 = v1 * v2;
                txtprice.Text = v3.ToString();
            }
            if (txtfat.Text.Length > 0 && txtclr.Text.Length == 0)
            {
                txtprice.Text = "0";
                //txtt4.Text = "0";
            }
            if (txtfat.Text.Length == 0 && txtclr.Text.Length > 0)
            {
                txtprice.Text = "0";
                //  txtt4.Text = "0";
            }
            if (txtfat.Text.Length == 0 && txtclr.Text.Length == 0)
            {
                txtprice.Text = "0";
                // txtt4.Text = "0";
            }
        }

        private void txtsnf_KeyPress(object sender, KeyPressEventArgs e)
        {
           

        }

        private void txtliter_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtfat_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtclr_KeyPress(object sender, KeyPressEventArgs e)
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void label2_Click(object sender, EventArgs e)
        {

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
        private void button1_Click_3(object sender, EventArgs e)
        {
            txtAcNo.Text = "";
            txtliter.Text = "";
            txtfat.Text = "";
            txtclr.Text = "";

        }
    }
}
