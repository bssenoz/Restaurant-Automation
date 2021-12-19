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
    public partial class FrmKasa : Form
    {
        NpgsqlConnection baglanti = new
        NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=buse8597;Database=Restaurant");
        string urunno;
        string adet;
        string urun_fiyat;
        string kasa;
        string tarih;
        int toplamtutar;
        string masano;
        public FrmKasa()
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

        private void btnHesapGetir_Click(object sender, EventArgs e)
        {
            int siparisNo = int.Parse(textBox1.Text);
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
            string bull = "select urun_no, adet from siparisler where siparis_no=@p1 ";
            NpgsqlCommand cmdd = new NpgsqlCommand(bull, baglanti);
            cmdd.Parameters.AddWithValue("@p1", siparisNo);
            NpgsqlDataReader drr = cmdd.ExecuteReader();
            while (drr.Read())
            {
                urunno = drr[0].ToString();
                adet = drr[1].ToString();
            }
            int urun_no = int.Parse(urunno);
            int tane = int.Parse(adet);
            baglanti.Close();

            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string bul = "select masa_no from islemler where siparis_no=@p1";
            NpgsqlCommand cmdw = new NpgsqlCommand(bul, baglanti);
            cmdw.Parameters.AddWithValue("@p1", siparisNo);
            NpgsqlDataReader dr = cmdw.ExecuteReader();
            while (dr.Read())
            {
                masano = dr[0].ToString();
            }
            int masa = int.Parse(masano);
            baglanti.Close();

            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string bulw = "update masalar set durum = @p2 where masa_no=@p1";
            NpgsqlCommand cmdww = new NpgsqlCommand(bulw, baglanti);
            cmdww.Parameters.AddWithValue("@p1", masa);
            cmdww.Parameters.AddWithValue("@p2", false);
            cmdww.ExecuteNonQuery();
            baglanti.Close();

            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string bulll = "select fiyat from urunler where urun_no=@p1";
            NpgsqlCommand cmddd = new NpgsqlCommand(bulll, baglanti);
            cmddd.Parameters.AddWithValue("@p1", urun_no);
            NpgsqlDataReader dre = cmddd.ExecuteReader();
            while (dre.Read())
            {
                urun_fiyat = dre[0].ToString();
            }
            int fiyat = int.Parse(urun_fiyat);
            baglanti.Close();

            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            toplamtutar = fiyat * tane;
            string ekle = "update hesaplar set odemeturu_no=@p3,indirim=@p4,toplam_tutar=@p5,hesap=@p6,tarih=@p7,durum=@p8 where siparis_no=@p1";
            NpgsqlCommand cmd = new NpgsqlCommand(ekle, baglanti);
            int combo = int.Parse(comboBox1.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@p1", siparisNo);
            cmd.Parameters.AddWithValue("@p3", combo); 
            cmd.Parameters.AddWithValue("@p4", int.Parse(textBox7.Text)); 
            cmd.Parameters.AddWithValue("@p5", toplamtutar);
            cmd.Parameters.AddWithValue("@p7", tarih);
            cmd.Parameters.AddWithValue("@p8", true);
            cmd.Parameters.AddWithValue("@p6", toplamtutar - int.Parse(textBox7.Text));
            int hesap = toplamtutar - int.Parse(textBox7.Text);
            listBox1.Items.Add(hesap);

            cmd.ExecuteNonQuery();
            baglanti.Close();
        }
        private void btnHesapOde_Click_1(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string bulll = "select kasaPara()";
            NpgsqlCommand cmddd = new NpgsqlCommand(bulll, baglanti);
            NpgsqlDataReader dre = cmddd.ExecuteReader();
            while (dre.Read())
            {
                kasa = dre[0].ToString();
            }
            int toplam = int.Parse(kasa);
            
            baglanti.Close();

            MessageBox.Show("Hesap Ödendi");
            listBox1.Items.Clear();

            listBox2.Items.Clear();
            listBox2.Items.Add(toplam);

        }

        private void FrmKasa_Load(object sender, EventArgs e)
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
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string bulll = "select kasaPara()";
            NpgsqlCommand cmddd = new NpgsqlCommand(bulll, baglanti);
            NpgsqlDataReader dre = cmddd.ExecuteReader();
            while (dre.Read())
            {
                kasa = dre[0].ToString();
            }
            int toplam = int.Parse(kasa);
            listBox2.Items.Add(toplam);
            baglanti.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string sorgu = "SELECT siparis_no,masa_no FROM islemler where durum=false";

            NpgsqlDataAdapter cmd = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            cmd.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }
     
    }
}
