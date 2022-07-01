using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MultiUserAtm
{
    public partial class NewJointUser : Form
    {
        public NewJointUser()
        {
            InitializeComponent();
        }
        public string Accno;


        private void NewJointUser_Load(object sender, EventArgs e)
        {
            comboBox1.Text = Accno;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            joinuser jj = new joinuser();
            jj.accnum = Accno;
            jj.us = "JointAcc";

            jj.umail = textBox5.Text;
            jj.umobile = textBox4.Text;
            jj.Show();

        }
    }
}
