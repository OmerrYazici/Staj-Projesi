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

namespace BYT_Teknoloji_Kayıt_Uygulaması
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="admin" && textBox2.Text=="12345")
            {
                Form2 sayfa2 = new Form2();
                sayfa2.Show();
                this.Hide();
            }

            else
            {
                label3.Text = "Hatalı Giriş";
            }
        }
    }
}
