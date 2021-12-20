using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJE2
{
    public partial class FrmPaketServis : Form
    {
        string urunNo;
        string urunfiyati;
        string adet;
        string tarih;
        string siparisNo;
        string siparisSayisi;
        NpgsqlConnection baglanti = new
        NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=buse8597;Database=Restaurant");
        public FrmPaketServis()
        {
            InitializeComponent();
        }
        public void TextTemizle()
        {
            foreach (Control item in this.Controls)
            {
                if (item.GetType().ToString() == "System.Windows.Forms.TextBox") item.Text = "";
            }
        }
     
        private void btnSiparisAl_Click_1(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string bul = "select * from musteriler where musteri_no=@p1";
            NpgsqlCommand cmda = new NpgsqlCommand(bul, baglanti);
            cmda.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            NpgsqlDataReader dr = cmda.ExecuteReader();
            if (!dr.Read())
            {
                MessageBox.Show("Müşteri bulunamadı! Lütfen kayıt yapın.");
                baglanti.Close();
                TextTemizle();
            }
            else
            {
                baglanti.Close();
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string bule = "select siparis_sayisi from musteriler where musteri_no=@p1";
                NpgsqlCommand cmdae = new NpgsqlCommand(bule, baglanti);
                cmda.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
                NpgsqlDataReader dre = cmda.ExecuteReader();
                while(dre.Read())
                {
                    siparisSayisi = dre[0].ToString();
                }
                int siparis_sayisi = int.Parse(siparisSayisi);
                baglanti.Close();

                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string bul2 = "select * from stok where urun_no=@p1";
                NpgsqlCommand cmdaa = new NpgsqlCommand(bul2, baglanti);
                cmdaa.Parameters.AddWithValue("@p1", int.Parse(textBox3.Text));
                NpgsqlDataReader dr2a = cmdaa.ExecuteReader();
                if (!dr2a.Read())
                {
                    MessageBox.Show("Ürün tükenmiştir!");
                    baglanti.Close();
                    comboBox1.Items.Clear();
                    TextTemizle();
                }
                else
                {
                    baglanti.Close();

                    if (baglanti.State == ConnectionState.Closed)
                        baglanti.Open();
                    string ekle = "insert into siparisler (siparis_no,urun_no,adet,servisturu_no) values (@p1,@p2,@p3,@p4)";
                    NpgsqlCommand cmd = new NpgsqlCommand(ekle, baglanti);
                    int comboServis = int.Parse(comboBox2.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@p1", int.Parse(textBox5.Text));
                    cmd.Parameters.AddWithValue("@p2", int.Parse(textBox3.Text));
                    cmd.Parameters.AddWithValue("@p3", int.Parse(textBox4.Text));
                    cmd.Parameters.AddWithValue("@p4", int.Parse(comboBox2.SelectedItem.ToString()));

                    cmd.ExecuteNonQuery();
                    baglanti.Close();

                    if (baglanti.State == ConnectionState.Closed)
                        baglanti.Open();
                    string eklep = "insert into paket_servis (personel_no,adres,musteri_no,siparis_no,durum) values (@p1,@p2,@p3,@p4,@p5)";
                    NpgsqlCommand cmdp = new NpgsqlCommand(eklep, baglanti);
                    cmdp.Parameters.AddWithValue("@p1", int.Parse(textBox8.Text));
                    cmdp.Parameters.AddWithValue("@p2", textBox2.Text);
                    cmdp.Parameters.AddWithValue("@p3", int.Parse(textBox1.Text));
                    cmdp.Parameters.AddWithValue("@p4", int.Parse(textBox5.Text));
                    cmdp.Parameters.AddWithValue("@p5", false);
                    cmdp.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Sipariş Alındı");
                    TextTemizle();
                }
            }
        }
        private void btnPaketTeslim_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();

            string time = "select current_timestamp";
            NpgsqlCommand cmd3 = new NpgsqlCommand(time, baglanti);
            NpgsqlDataReader dt = cmd3.ExecuteReader();
            while (dt.Read())
            {
                tarih = dt[0].ToString();
            }
            baglanti.Close();

            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string bull = "select siparis_no from paket_servis where paket_no=@p1";
            NpgsqlCommand cmddl = new NpgsqlCommand(bull, baglanti);
            cmddl.Parameters.AddWithValue("@p1", int.Parse(textBox6.Text));

            NpgsqlDataReader drl = cmddl.ExecuteReader();
            while (drl.Read())
            {
                siparisNo = drl[0].ToString();
            }
            int siparisno = int.Parse(siparisNo);
            baglanti.Close();

            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string bul2 = "select urun_no,adet from siparisler where siparis_no=@p1";
            NpgsqlCommand cmdd2 = new NpgsqlCommand(bul2, baglanti);
            cmdd2.Parameters.AddWithValue("@p1", siparisno);
            NpgsqlDataReader dr2 = cmdd2.ExecuteReader();
            while (dr2.Read())
            {
                urunNo = dr2[0].ToString();
                adet = dr2[1].ToString();
            }
            int urunno = int.Parse(urunNo);
            int urunadet = int.Parse(adet);
            baglanti.Close();

            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string bul = "select * from urunler where urun_no=@p1";
            NpgsqlCommand cmdd = new NpgsqlCommand(bul, baglanti);
            cmdd.Parameters.AddWithValue("@p1", urunno);

            NpgsqlDataReader dr = cmdd.ExecuteReader();
            while (dr.Read())
            {
                urunfiyati = dr[3].ToString();
            }
            int fiyat = int.Parse(urunfiyati);
            baglanti.Close();

            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string eklem = "insert into hesaplar (siparis_no,odemeturu_no,indirim,toplam_tutar,hesap,tarih,durum) values (@p2,@p3,@p4,@p5,@p6,@p7,@p8)";
            NpgsqlCommand cmdm = new NpgsqlCommand(eklem, baglanti);
            int tutar = urunadet * fiyat;
            int combo = int.Parse(comboBox1.SelectedItem.ToString());
            cmdm.Parameters.AddWithValue("@p2", siparisno);
            cmdm.Parameters.AddWithValue("@p3", combo);
            cmdm.Parameters.AddWithValue("@p4", 0);
            cmdm.Parameters.AddWithValue("@p5", tutar);
            cmdm.Parameters.AddWithValue("@p6", tutar);
            cmdm.Parameters.AddWithValue("@p7", tarih);
            cmdm.Parameters.AddWithValue("@p8", true);

            cmdm.ExecuteNonQuery();
            baglanti.Close();
      
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string guncelle = "update paket_servis set durum=@p1 where paket_no = @p2";
            NpgsqlCommand cmd2 = new NpgsqlCommand(guncelle, baglanti);
            cmd2.Parameters.AddWithValue("@p1", true);
            cmd2.Parameters.AddWithValue("@p2", int.Parse(textBox6.Text));

            cmd2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Sipariş teslim edildi");
            TextTemizle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "select * from paket_servis";
            NpgsqlDataAdapter cmd = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            cmd.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string sorgu = "SELECT * FROM paket_servis where durum=false";
            NpgsqlDataAdapter cmd = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            cmd.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }


        private void FrmPaketServis_Load(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string bul = "select * from odeme_turleri";

            DataTable dt = new DataTable();
            NpgsqlDataAdapter adp = new NpgsqlDataAdapter(bul, baglanti);
            adp.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr[0].ToString());
            }
            baglanti.Close();

            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string bul2 = "select * from servis_turleri";

            DataTable dt2 = new DataTable();
            NpgsqlDataAdapter adp2 = new NpgsqlDataAdapter(bul2, baglanti);
            adp2.Fill(dt2);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox2.Items.Add(dr[0].ToString());
            }
            baglanti.Close();
        }

    }
}
