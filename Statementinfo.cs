﻿using System;
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
    public partial class Statementinfo : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=\\Mac\Home\Desktop\MultiUserAtm\MultiUserAtm\MultiUserAtm\Database1.mdf;Integrated Security=True");
        SqlCommand cmd;

        public Statementinfo()
        {
            InitializeComponent();
        }

        private void Statementinfo_Load(object sender, EventArgs e)
        {
            cmd = new SqlCommand("select * from transtb", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }
    }
}
