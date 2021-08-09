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
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-C9TA65A;Initial Catalog=bytteknoloji;Integrated Security=True");

        private void verileriGoster()
        {
            listView2.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *From Veriler", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.SubItems.Add(oku["id"].ToString());
                ekle.SubItems.Add(oku["adi"].ToString());
                ekle.SubItems.Add(oku["soyadi"].ToString());
                ekle.SubItems.Add(oku["telefon"].ToString());
                ekle.SubItems.Add(oku["marka"].ToString());
                ekle.SubItems.Add(oku["kasa"].ToString());
                ekle.SubItems.Add(oku["ariza"].ToString());

                listView2.Items.Add(ekle);
                
            }
            baglan.Close();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            verileriGoster();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            baglan.Open();

            SqlCommand komutt = new SqlCommand("insert into Veriler (id, adi, soyadi, telefon, marka, kasa, ariza) values ('" + textBox4.Text.ToString() + "','" + textBox1.Text.ToString()+ "', '"+textBox2.Text.ToString()+ "', '" + textBox3.Text.ToString() + "','" + comboBox1.Text.ToString() + "', '" + comboBox2.Text.ToString() + "', '" + richTextBox1.Text.ToString() + "')",baglan);
            komutt.ExecuteNonQuery();
            baglan.Close();
            verileriGoster();

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            richTextBox1.Text = "";
        }

        int id = 0;
        private void button4_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Delete from Veriler where id = (" + id + ")", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verileriGoster();
        }

        private void listView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           ////////////
        }

        private void listView2_MouseClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView2.SelectedItems[0].SubItems[1].Text);
            textBox4.Text = listView2.SelectedItems[0].SubItems[1].Text;
            textBox1.Text = listView2.SelectedItems[0].SubItems[2].Text;
            textBox2.Text = listView2.SelectedItems[0].SubItems[3].Text;
            textBox3.Text = listView2.SelectedItems[0].SubItems[4].Text;
            comboBox1.Text = listView2.SelectedItems[0].SubItems[5].Text;
            comboBox2.Text = listView2.SelectedItems[0].SubItems[6].Text;
            richTextBox1.Text = listView2.SelectedItems[0].SubItems[7].Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();

            SqlCommand komut = new SqlCommand("update  Veriler set id='" + textBox4.Text.ToString() + "', adi='" + textBox1.Text.ToString() + "', soyadi= '" + textBox2.Text.ToString() + "', telefon='" + textBox3.Text.ToString() + "', marka='" + comboBox1.Text.ToString() + "', kasa='" + comboBox2.Text.ToString() + "', ariza='" + richTextBox1.Text.ToString() + "' where id ="+id+"", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verileriGoster();
        }
    }
}
