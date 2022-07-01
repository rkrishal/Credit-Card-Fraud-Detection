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
    public partial class Deposit : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=\\Mac\Home\Desktop\MultiUserAtm\MultiUserAtm\MultiUserAtm\Database1.mdf;Integrated Security=True");
        SqlCommand cmd;


        public string accno;
        string bal;

        public Deposit()
        {
            InitializeComponent();
        }

        private void Deposit_Load(object sender, EventArgs e)
        {

            label1.Text = accno;

            con.Open();
            cmd = new SqlCommand("select * from regtb where Accno='" + accno + "' ", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                bal = dr["Balance"].ToString();

            }
          
            con.Close();
        }

        decimal balance, amt;

        private void button2_Click(object sender, EventArgs e)
        {
            balance = Convert.ToDecimal(bal);
           

            if (textBox1.Text != "")
            {

                amt = Convert.ToDecimal(textBox1.Text);
                balance = balance + amt;


                cmd = new SqlCommand("update regtb set Balance='" + balance + "' where Accno='" + accno + "'  ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


                cmd = new SqlCommand("insert into transtb values('" + accno + "','Deposit','" + accno + "','" + textBox1.Text + "','" + System.DateTime.Now.ToShortDateString() + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Deposit Completed!");


            }
            else
            {
                MessageBox.Show("Please Enter Deposit Amount!");

            }


        }
    }
}
