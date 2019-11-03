using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Market_Otomasyonu
{
    public partial class gecmis : Form
    {
        public gecmis()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        MySqlConnection baglan = new MySqlConnection("server=localhost; database=market; uid=root; password=");
        DataTable tablo = new DataTable();
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_ara.Text == "")
                {
                    tablo.Clear();
                    baglan.Open();
                    MySqlDataAdapter adap = new MySqlDataAdapter("select * from gecmis", baglan);
                    adap.Fill(tablo);
                    dataGridView1.DataSource = tablo;
                    baglan.Close();

                }
                else
                {

                    baglan.Open();
                    DataTable tbl = new DataTable();
                    string vara, cumle;
                    vara = txt_ara.Text;
                    cumle = "Select * from gecmis where urun_adi like '%" + txt_ara.Text + "%'  or tarih  like '%" + txt_ara.Text + "%'";
                    MySqlDataAdapter adptr = new MySqlDataAdapter(cumle, baglan);
                    adptr.Fill(tbl);
                    baglan.Close();
                    dataGridView1.DataSource = tbl;
                }
                textBox1.Text = dataGridView1.RowCount.ToString();



                double toplam = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    toplam += Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                }
                label4.Text = toplam.ToString();
            }
            catch (Exception)
            {

                MessageBox.Show("BAĞLANTINIZI KONTROL EDİNİZ..");
            }
         
        }

        private void gecmis_Load(object sender, EventArgs e)
        {
            try
            {
                tablo.Clear();
                baglan.Open();
                MySqlDataAdapter adap = new MySqlDataAdapter("select * from gecmis", baglan);
                adap.Fill(tablo);
                dataGridView1.DataSource = tablo;
                baglan.Close();

                textBox1.Text = (dataGridView1.RowCount - 1).ToString();
            }
            catch (Exception)
            {

                MessageBox.Show("BAĞLANTINIZI KONTROL EDİNİZ..");
            }
         
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            satisler SS = new satisler();
            SS.Show();
            this.Hide();
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
    }
}
