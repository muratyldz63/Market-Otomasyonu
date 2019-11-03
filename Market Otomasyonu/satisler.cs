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
    public partial class satisler : Form
    {
        public satisler()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

        }
       
        MySqlConnection baglan = new MySqlConnection("server=localhost; database=market; uid=root; password=");
        DataTable tablo = new DataTable();
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
              
                baglan.Open();
                MySqlDataAdapter adap = new MySqlDataAdapter("select * from urunler where barkod_no='"+textBox2.Text+"'", baglan);
                adap.Fill(tablo);
                dataGridView1.DataSource = tablo;
                baglan.Close();
                
            }
            catch (Exception)
            {

                MessageBox.Show("bağlantı hatası"); ;
            }
            try
            {
                baglan.Open();
                MySqlCommand komu = new MySqlCommand("select * from urunler where barkod_no='" + textBox2.Text + "'", baglan);
                MySqlDataReader oku = komu.ExecuteReader();
                while (oku.Read())
                {
                    LBLURUNAD.Text = oku["urun_adi"].ToString();
                    lblFiyat.Text = oku["fiyat"].ToString();
                    stok=Convert.ToInt16(oku["stok"].ToString());
                    textBox1.Text = (Convert.ToDouble(textBox1.Text) + Convert.ToDouble(lblFiyat.Text)).ToString();
                }
                baglan.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("ürün bulunamadı");
            }


     
            EKLE();
          
            


        }
        string tarih, saat;
        int stok;

        public void EKLE()
        {
            try
            {
                baglan.Open();
                using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM urunler where barkod_no='" + textBox2.Text + "'", baglan))
                {
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    baglan.Close();
                    if (count >= 1)
                    {
                        tarih = DateTime.Now.ToLongDateString();
                        saat = DateTime.Now.ToLongTimeString();
                        baglan.Open();
                        MySqlCommand cmmm = new MySqlCommand("INSERT INTO gecmis (urun_adi, barkod_no, fiyat,tarih,saat,personel_ad) VALUES ('" + LBLURUNAD.Text + "','" + textBox2.Text + "' ,'" + lblFiyat.Text + "', '" + tarih + "' , '" + saat + "', '"+LBLPERSONEL.Text+"' )", baglan);
                        cmmm.ExecuteNonQuery();
                        baglan.Close();


                        stok--;
                         baglan.Open();
                        MySqlCommand hom=new MySqlCommand("update urunler set stok='"+stok+"' where barkod_no='" + textBox2.Text + "'", baglan);
                         hom.ExecuteNonQuery();
                        baglan.Close();


                    }
                    else
                    {
                        MessageBox.Show("Ürün Bulunamadı...");
                    }








                }



               
            }
            catch (Exception)
            {

                MessageBox.Show("bağlantı hatası"); ;
            }
           

            
          
          
        }
    

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult cikis = new DialogResult();

            cikis = MessageBox.Show("ALIŞVERİŞİ BİTİRMEK  İSTEDİĞİNİZE EMİN MİSİNİZ?", "UYARI", MessageBoxButtons.YesNo);



            if (cikis == DialogResult.Yes)
            {
                MessageBox.Show("MUŞTERİDEN " + textBox1.Text + "'TL ALMALISINIZ");
                textBox1.Text = "00";
                textBox2.Clear();
                lblFiyat.Text = "";
                LBLURUNAD.Text = "";
                tablo.Clear();
            }
        }

        string iid,urunad,fiyat,barkod;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int secilii = dataGridView1.SelectedCells[0].RowIndex;
                iid = dataGridView1.Rows[secilii].Cells[1].Value.ToString();
                urunad = dataGridView1.Rows[secilii].Cells[2].Value.ToString();

                barkod = dataGridView1.Rows[secilii].Cells[3].Value.ToString();
                fiyat = dataGridView1.Rows[secilii].Cells[4].Value.ToString();
                stok = Convert.ToInt16(dataGridView1.Rows[secilii].Cells[5].Value.ToString());

                DialogResult cikis = new DialogResult();

                cikis = MessageBox.Show("İPTAL ETMEK İSTEDİĞİNİMİZE EMİNMİSİNİZ?", "UYARI", MessageBoxButtons.YesNo);



                if (cikis == DialogResult.Yes)
                {


                    textBox1.Text = (Convert.ToDouble(textBox1.Text) - Convert.ToDouble(fiyat)).ToString();

                    sil21();

                    baglan.Open();
                    MySqlCommand komu = new MySqlCommand("select * from urunler where barkod_no='" + textBox2.Text + "'", baglan);
                    MySqlDataReader oku = komu.ExecuteReader();
                    while (oku.Read())
                    {
                        stok = Convert.ToInt16(oku["stok"].ToString());
                        
                    }
                    baglan.Close();









                    stok++; ;


                 
                    baglan.Open();
                    MySqlCommand hom = new MySqlCommand("update urunler set stok='" + stok + "' where barkod_no='" + textBox2.Text + "'", baglan);
                    hom.ExecuteNonQuery();
                    baglan.Close();
                    

                    //dataGridView1.Rows[secilii].Cells[0].ErrorText= "İPtal edildi";

                    //seciliyi silme komutu// ve kaldırma     

                    int selectedIndex = dataGridView1.CurrentCell.RowIndex;
                    if (selectedIndex > -1)
                    {
                        dataGridView1.Rows.RemoveAt(selectedIndex);
                        dataGridView1.Refresh();
                    }


                }
            }
            catch (Exception)
            {

                MessageBox.Show("bağlantı hatası"); ;
            }
            
        }
     string asss;
        public void sil21()
     {
         try
         {
             baglan.Open();
             MySqlCommand komu = new MySqlCommand("select * FROM gecmis WHERE id=(select MAX(id) from gecmis where barkod_no='" + barkod + "')", baglan);
             MySqlDataReader oku = komu.ExecuteReader();
             while (oku.Read())
             {
                 asss = oku["id"].ToString();
             }
             baglan.Close();






             baglan.Open();
             MySqlCommand ccmm = new MySqlCommand("DELETE FROM gecmis WHERE id='" + asss + "'", baglan);
             ccmm.ExecuteNonQuery();
             baglan.Close();
         }
         catch (Exception)
         {

             MessageBox.Show("bağlantı hatası"); ;
         }
            
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void satisler_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblFiyat_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LBLURUNAD_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            gecmis gc = new gecmis();
            gc.Show();
            this.Hide();
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
        int aaa = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {

            aaa++;
            if (aaa == 140)
            {
                aaa = 0;
                textBox4.Text = "    --HOŞ GELDİNİZ--   ";

            }


            if (aaa == 70)
            {
                textBox4.Text = "    --ALUS YAZILIM--   ";
            }
            if (textBox4.Text != "")
            {
                textBox4.Text = textBox4.Text.Substring(1) + textBox4.Text.Substring(0, 1);
            }
        }

    }
}
