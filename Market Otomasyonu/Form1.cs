using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Market_Otomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.BackColor = Color.Transparent;
           
        }
        int aaa = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {

            aaa++;
            if (aaa == 140)
            {
                aaa = 0;
                textBox3.Text = "    --HOŞ GELDİNİZ--   ";

            }


            if (aaa == 70)
            {
                textBox3.Text = "    --ALUS YAZILIM--   ";
            }
            if (textBox3.Text != "")
            {
                textBox3.Text = textBox3.Text.Substring(1) + textBox3.Text.Substring(0, 1);
            }
           
            
        }
   MySqlConnection baglan = new MySqlConnection("server=localhost; database=market; uid=root; password=");
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (comboBox1.Text == "Admin")
                {
                    baglan.Open();
                    using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM admin where username='" + textBox1.Text + "' and password='" + textBox2.Text + "'", baglan))
                    {
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count == 1)
                        {

                            islem formac = new islem();
                            formac.Text = textBox1.Text;
                            formac.Show();
                            this.Hide();

                        }
                        else
                        {
                            MessageBox.Show("YANLIŞ KULLANICI GİRİŞİ!!!!!!");
                        }

                    }
                    baglan.Close();
                }

                else if (comboBox1.Text == "Personel")
                {
                    baglan.Open();
                    using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM personel where username='" + textBox1.Text + "' and password='" + textBox2.Text + "'", baglan))
                    {
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count == 1)
                        {

                            satisler formac = new satisler();
                            formac.LBLPERSONEL.Text = textBox1.Text;
                            formac.Show();
                            this.Hide();

                        }
                        else
                        {
                            MessageBox.Show("YANLIŞ KULLANICI GİRİŞİ!!!!!!");
                        }

                    }
                    baglan.Close();
                }
                else
                {
                    MessageBox.Show("lutfen yetkiyi seciniz");
                }

            }
            catch (Exception)
            {

                MessageBox.Show("BAĞLANTI HATASI");
            }
           

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("BU PROGRAMIN TÜM HAKLARI ALUS YAZILIMA AİTTİR. BU PROGRAMIN KOPYANILMASI VEYA BAŞKASINA SATILMASI DURUMUNDA HER 2 BİLGİSAYARDAKİ PROGRAM KAPATILACAK VE HUKUKSAL İŞLEM BAŞLATILACAKTIR... ");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
