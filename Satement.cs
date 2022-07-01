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
    public partial class Satement : Form
    {

        public string accno, bal;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=\\Mac\Home\Desktop\MultiUserAtm\MultiUserAtm\MultiUserAtm\Database1.mdf;Integrated Security=True");
        SqlCommand cmd;

        public Satement()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Text = "BALANCE : " + bal;


            cmd = new SqlCommand("select * from transtb where date between '" + dateTimePicker1.Text + "' and  '" + dateTimePicker2.Text + "' and Accno='" + accno + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();

        }

        private void Satement_Load(object sender, EventArgs e)
        {
         //   label1.Text = accno;


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

        private void button2_Click(object sender, EventArgs e)
        {
           
        }
    }
}
