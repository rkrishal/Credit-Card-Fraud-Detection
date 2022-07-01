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
    public partial class BankLogin : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=\\Mac\Home\Desktop\MultiUserAtm\MultiUserAtm\MultiUserAtm\Database1.mdf;Integrated Security=True");
        SqlCommand cmd;

        public BankLogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            array = ShuffledArray(array);


            foreach (int s in array)
            {
                Console.WriteLine(s);
            }





        }



        protected int[] ShuffledArray(int[] myArray)
        {
            int count = myArray.Length - 1;
            int[] newArray = new int[count + 1];

            Random rnd = new Random();
            var randomNumbers = Enumerable.Range(1, count).OrderBy(i => rnd.Next()).ToArray();

            int index = 0;
            foreach (int i in randomNumbers)
            {
                newArray[index] = myArray[i];
                index++;
            }

            return newArray;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "bank" & textBox2.Text == "bank")
            {
                BankHome ss = new BankHome();
                ss.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username or Password Incorrect!");

            }

        }
    }
}
