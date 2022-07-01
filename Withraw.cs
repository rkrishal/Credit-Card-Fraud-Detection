using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MultiUserAtm
{
    public partial class Withraw : Form
    {
        public Withraw()
        {
            InitializeComponent();
        }


        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=\\Mac\Home\Desktop\MultiUserAtm\MultiUserAtm\MultiUserAtm\Database1.mdf;Integrated Security=True");
        SqlCommand cmd;


        public string accno;
        string bal;


        private void Withraw_Load(object sender, EventArgs e)
        {
            label1.Text = accno;


            con.Open();
            cmd = new SqlCommand("select * from regtb where Accno='" + accno + "' ", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {



                bal = dr["Balance"].ToString();



            }
            else
            {


            }
            con.Close();

        }


        decimal balance, amt;

        private void button2_Click(object sender, EventArgs e)
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


                cmd = new SqlCommand("insert into transtb values('" + accno + "','Withdraw','" + accno + "','" + textBox1.Text + "','" + System.DateTime.Now.ToShortDateString() + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Withdraw Completed!");
            }
            else
            {
                MessageBox.Show("Balance Low");

            }
        }
    }
}
