using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using System.Net.Mail;

namespace MultiUserAtm
{
    public partial class UserHome1 : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=\\Mac\Home\Desktop\MultiUserAtm\MultiUserAtm\MultiUserAtm\Database1.mdf;Integrated Security=True");
        SqlCommand cmd;

        public string accno, bal , umail,umob,uname;

        public UserHome1()
        {
            InitializeComponent();
        }
        string mobile, mail;
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home hh = new Home();
            hh.Show();
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("select * from regtb where Accno='" + accno + "' ", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {



                bal = dr["Balance"].ToString();

                mobile = dr["Mobile"].ToString();
                mail = dr["Email"].ToString();

            }
            else
            {


            }
            con.Close();
            if (textBox2.Text == "")
            {

                MessageBox.Show("Enter Otp");

            }
            else
            {




                if (textBox2.Text == otp)
                {
                    balance = Convert.ToDecimal(bal);

                    amt = Convert.ToDecimal(textBox1.Text);

                    if (balance >= amt)
                    {
                        balance = balance - amt;


                        cmd = new SqlCommand("update regtb set Balance='" + balance + "' where Accno='" + accno + "'  ", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();


                        cmd = new SqlCommand("insert into transtb values('" + accno + "','Transaction','" + comboBox3.Text + "','" + textBox1.Text + "','" + System.DateTime.Now.ToShortDateString() + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Transaction Completed!");

                        string hostName = Dns.GetHostName(); // Retrive the Name of HOST  
                        Console.WriteLine(hostName);
                        // Get the IP  
                        string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
                        sendmessage(mobile, "Join Account  : " + uname + "   Transfer Account   :  " + comboBox3.Text + "   Amount : " + textBox1.Text + "  IPADDRESS  : " + myIP + " Balance Amount" + balance);
                    }
                    else
                    {
                        MessageBox.Show("Balance Low");

                    }
                }

                else
                {
                    MessageBox.Show("OTP Incorrect");

                }

            }
        }

        private void UserHome1_Load(object sender, EventArgs e)
        {

            label2.Text = accno;


            con.Open();
            cmd = new SqlCommand("select * from regtb where Accno='" + accno + "' ", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {



                bal = dr["Balance"].ToString();

                mobile = dr["Mobile"].ToString();
                mail = dr["Email"].ToString();

            }
            else
            {


            }
            con.Close();

        }


        decimal balance, amt;
        string otp;

        private void button1_Click(object sender, EventArgs e)
        {

            Random rr = new Random();
            int i = rr.Next(1111, 9999);

            otp = i.ToString();


            sendmessage(umob, "OTP :" + i.ToString());



            string to = umail;

            string from = "sampletest685@gmail.com";
            // string subject = "Key";
            // string body = TextBox1.Text;
            string password = "hneucvnontsuwgpj";
            using (MailMessage mm = new MailMessage(from, to))
            {
                mm.Subject = "OTP";
                mm.Body = "OTP :" + i.ToString();


                mm.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential(from, password);
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
                MessageBox.Show("Mail Send!");

            }
        }

        public void sendmessage(string targetno, string message)
        {

            String query = "http://bulksms.mysmsmantra.com:8080/WebSMS/SMSAPI.jsp?username=fantasy5535&password=1163974702&sendername=Sample&mobileno=" + targetno + "&message=" + message;
            WebClient client = new WebClient();
            Stream sin = client.OpenRead(query);

        }

        private void depositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Deposit dd = new Deposit();
            dd.accno = accno;
            dd.Show();
        }

        private void withrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Withraw ww = new Withraw();
            ww.accno = accno;
            ww.Show();
        }

    }
}
