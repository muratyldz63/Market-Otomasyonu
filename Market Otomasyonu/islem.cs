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
    public partial class islem : Form
    {
        public islem()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void islem_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
           MySqlConnection baglan = new MySqlConnection("server=localhost; database=market; uid=root; password=");
                DataTable tablo = new DataTable();
        private void tabPage1_Click(object sender, EventArgs e)
        {
            gos();
        }
        public void textsil()
        {
            textBox1.Clear();
            textBox2.Clear(); id = "";
        }
        public void gos()
        {
            try
            {
                tablo.Clear();
                baglan.Open();
                MySqlDataAdapter adap = new MySqlDataAdapter("select * from personel", baglan);
                adap.Fill(tablo);
                dataGridView1.DataSource = tablo;
                baglan.Close();
                textsil();
            }
            catch (Exception)
            {

                MessageBox.Show("bağlantı hatası"); ;
            }
            
        }

        private void BTNEKLE_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {


                    baglan.Open();
                    using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM personel where username='" + textBox1.Text + "'", baglan))
                    {
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        baglan.Close();
                        if (count == 1)
                        {

                            MessageBox.Show("boyle bir kullanıcı adı ve şifre zaten bulunmaktadır");

                        }
                        else
                        {

                            baglan.Open();
                            MySqlCommand cmm = new MySqlCommand("INSERT INTO personel (username, password) VALUES ('" + textBox1.Text + "' , '" + textBox2.Text + "')", baglan);
                            cmm.ExecuteNonQuery();
                            baglan.Close();
                            gos();
                        }


                    }
                }
                else
                {
                    MessageBox.Show("boş bırakılamaz");
                }


            }
            catch (Exception)
            {

                MessageBox.Show("bağlantı hatası");
            }
           


        }

        private void BTNSİL_Click(object sender, EventArgs e)
        {
            try
            {

                if (id != "")
                {
                    baglan.Open();
                    MySqlCommand cmm = new MySqlCommand("delete from personel where id='" + id + "'", baglan);
                    cmm.ExecuteNonQuery();
                    baglan.Close();
                    gos();
                }
                else MessageBox.Show("lutfen secim yapınız");
            }
            catch (Exception)
            {
                
                              MessageBox.Show("bağlantı hatası");

            }
            

        }
        string id;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secili = dataGridView1.SelectedCells[0].RowIndex;
            id = dataGridView1.Rows[secili].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[secili].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secili].Cells[2].Value.ToString();
          
        }

        private void BTNGÜNCELLE_Click(object sender, EventArgs e)
        {
            try
            {
                if (id != "")
                {
                    baglan.Open();
                    MySqlCommand cmm = new MySqlCommand("update  personel set username='" + textBox1.Text + "', password='" + textBox2.Text + "'  where id='" + id + "'", baglan);
                    cmm.ExecuteNonQuery();
                    baglan.Close();
                    gos();
                }
                else MessageBox.Show("lutfen secim yapınız");
            }
            catch (Exception)
            {

                MessageBox.Show("bağlantı hatası");
            }
           
        }
        DataTable taablo = new DataTable();
        public void gos2()
        {

            try
            {
                taablo.Clear();
                baglan.Open();
                MySqlDataAdapter adap = new MySqlDataAdapter("select * from urunler", baglan);
                adap.Fill(taablo);
                dataGridView2.DataSource = taablo;
                baglan.Close();
               LBL_URUN.Text= dataGridView2.RowCount.ToString();

            }
            catch (Exception)
            {

                MessageBox.Show("bağlantı hatası"); ;
            }
        }
        private void tabPage2_Click(object sender, EventArgs e)
        {
            gos2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text != "" && textBox5.Text != "" && comboBox2.Text != "")
                {


                    baglan.Open();
                    using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM urunler where barkod_no='" + textBox3.Text + "'", baglan))
                    {
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        baglan.Close();
                        if (count == 1)
                        {

                            MessageBox.Show("   BOYLE BİR ÜRÜN ZATEN VAR");

                        }
                        else
                        {

                            baglan.Open();
                            MySqlCommand cmm = new MySqlCommand("INSERT INTO urunler (urun_adi, barkod_no, fiyat,stok) VALUES ('" + comboBox2.Text + "' , '" + textBox3.Text + "' , '" + textBox5.Text + "', '"+numericUpDown1.Value+"')", baglan);
                            cmm.ExecuteNonQuery();
                            baglan.Close();

                        }
                        gos2();

                    }
                }
                else
                {
                    MessageBox.Show("boş bırakılamaz");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Bağlantı Hatası");
            }


          


            
           

        }
        string iid;
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
             int secili = dataGridView3.SelectedCells[0].RowIndex;
            iid = dataGridView3.Rows[secili].Cells[0].Value.ToString();
            
            textBox4.Text = dataGridView3.Rows[secili].Cells[1].Value.ToString();
            textBox7.Text = dataGridView3.Rows[secili].Cells[3].Value.ToString();
            numericUpDown2.Value = Convert.ToDecimal(dataGridView3.Rows[secili].Cells[4].Value.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox4.Text != "")
                {
                    baglan.Open();
                    MySqlCommand cmm = new MySqlCommand("update  urunler set fiyat='" + textBox7.Text + "', stok='"+numericUpDown2.Value+"' where urun_adi='" + textBox4.Text + "'", baglan);
                    cmm.ExecuteNonQuery();
                    baglan.Close();
                    GOS3();
                }
                else MessageBox.Show("lutfen secim yapınız");
            }
            catch (Exception)
            {

                MessageBox.Show("bağlantı hatası");
            }
        }
        DataTable taabloo = new DataTable();
        public void GOS3()
        {

            try
            {
                taabloo.Clear();
                baglan.Open();
                MySqlDataAdapter adap = new MySqlDataAdapter("select * from urunler", baglan);
                adap.Fill(taabloo);
                dataGridView3.DataSource = taabloo;
                baglan.Close();
                label9.Text = dataGridView3.RowCount.ToString();

            }
            catch (Exception)
            {

                MessageBox.Show("bağlantı hatası"); ;
            }

        }
        private void tabPage3_Click(object sender, EventArgs e)
        {
            GOS3();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                if (iid != "")
                {
                    baglan.Open();
                    MySqlCommand cmm = new MySqlCommand("delete from urunler where id='" + iid + "'", baglan);
                    cmm.ExecuteNonQuery();
                    baglan.Close();

                    GOS3();
                }
                else MessageBox.Show("lutfen secim yapınız");
            }
            catch (Exception)
            {

                MessageBox.Show("bağlantı hatası");

            }
            

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        int aaa = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            aaa++;
        if (aaa==140)
        {
            aaa = 0;
            textBox8.Text = "    --HOŞ GELDİNİZ--   ";
           
        }


        if (aaa == 70)
            {
                textBox8.Text = "    --ALUS YAZILIM--   ";
            }
        if (textBox8.Text != "")
        {
            textBox8.Text = textBox8.Text.Substring(1) + textBox8.Text.Substring(0, 1);
        }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult cikis = new DialogResult();

            cikis = MessageBox.Show("ÇIKIŞ YAPMAK İSTEDİĞİNİZE EMİN MİSİNİZ?", "UYARI", MessageBoxButtons.YesNo);



            if (cikis == DialogResult.Yes)
            {
                Form1 AD = new Form1();
                AD.Show();
                this.Hide();
            }



           
 
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
        DataTable ttablo = new DataTable();
        DataTable ttabloo = new DataTable();
        private void tabPage4_Click(object sender, EventArgs e)
        {
            ttablo.Clear();
            baglan.Open();
            MySqlDataAdapter adap = new MySqlDataAdapter("select * from gecmis", baglan);
            adap.Fill(ttablo);
            dataGridView4.DataSource = ttablo;
            baglan.Close();

           label16.Text = (dataGridView4.RowCount - 1).ToString();
        }

        private void txt_ara_TextChanged(object sender, EventArgs e)
        {
            if (txt_ara.Text == "")
            {
                ttabloo.Clear();
                baglan.Open();
                MySqlDataAdapter adap = new MySqlDataAdapter("select * from gecmis", baglan);
                adap.Fill(ttabloo);
                dataGridView4.DataSource = ttabloo;
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
                dataGridView4.DataSource = tbl;
            }
           label16.Text = dataGridView4.RowCount.ToString();



            double toplam = 0;
            for (int i = 0; i < dataGridView4.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(dataGridView4.Rows[i].Cells[3].Value);
            }
            label11.Text = toplam.ToString();
        }
        public void listele()
        {
            baglan.Open();

              
                string sql = "SELECT * FROM urun  where kat_ad='"+comboBox1.Text+"' ";
                MySqlCommand cmd = new MySqlCommand(sql, baglan);
                MySqlDataReader rdr = cmd.ExecuteReader();

                // ComboBox'ımızı temizliyoruz.
                comboBox2.Items.Clear();

                while (rdr.Read())
                {
                  

                    comboBox2.Items.Add(rdr["urun_adi"].ToString());
                }

                baglan.Close();
               
            
           
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listele();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        int say = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            say++;

                if (say==3)
                {
;                    listele();
                    say = 0;
                    timer2.Stop();

                }
	{
		 
	}
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

            if (textBox6.Text == "")
            {
                ttabloo.Clear();
                baglan.Open();
                MySqlDataAdapter adap = new MySqlDataAdapter("select * from urunler", baglan);
                adap.Fill(ttabloo);
                dataGridView3.DataSource = ttabloo;
                baglan.Close();

            }
            else
            {

                baglan.Open();
                DataTable tbl = new DataTable();
                string vara, cumle;
                vara = textBox6.Text;
                cumle = "Select * from urunler where urun_adi like '%" + textBox6.Text+ "%'  ";
                MySqlDataAdapter adptr = new MySqlDataAdapter(cumle, baglan);
                adptr.Fill(tbl);
                baglan.Close();
                dataGridView3.DataSource = tbl;
            }
        }
        
    }
}
