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
    public partial class FrmMutfak : Form
    {
        NpgsqlConnection baglanti = new
        NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=buse8597;Database=Restaurant;");
        public FrmMutfak()
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
        private void btnKategorileriGoster_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            dataGridView1.Visible = true;
            string sorgu = "select * from kategoriler";
            NpgsqlDataAdapter cmd = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            cmd.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void btnStok_Click(object sender, EventArgs e)
        {
            FrmStok yeniSayfa = new FrmStok();
            this.Hide();
            yeniSayfa.ShowDialog();
            this.Show();
        }

        private void btnUrunEkle_Click_1(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string ekle = "insert into urunler (urun_ad,kategori_no,fiyat) values (@p1,@p2,@p3)";
            NpgsqlCommand cmd = new NpgsqlCommand(ekle, baglanti);
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd.Parameters.AddWithValue("@p2", int.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@p3", int.Parse(textBox7.Text));
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ürün Eklendi");
            TextTemizle();
        }

        private void btnUrunSorgula_Click_1(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string bul = "select * from urunler where urun_no=@p1";
            NpgsqlCommand cmd = new NpgsqlCommand(bul, baglanti);
            cmd.Parameters.AddWithValue("@p1", int.Parse(textBox4.Text));
            NpgsqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox1.Text = dr[1].ToString();
                textBox2.Text = dr[2].ToString();
                textBox7.Text = dr[3].ToString();
            }

            baglanti.Close();
        }

        private void btnKategoriEkle_Click_1(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string ekle = "insert into kategoriler (kategori_ad) values (@p1)";
            NpgsqlCommand cmd = new NpgsqlCommand(ekle, baglanti);
            cmd.Parameters.AddWithValue("@p1", textBox5.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kategori Eklendi");
            TextTemizle();
        }

        private void btnKategoriSil_Click_1(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string sil = "delete from kategoriler where kategori_no=@p1";
            NpgsqlCommand cmd = new NpgsqlCommand(sil, baglanti);
            cmd.Parameters.AddWithValue("@p1", int.Parse(textBox6.Text));
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kategori Silindi");
            TextTemizle();
        }

        private void btnUrunGuncelle_Click_1(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string guncelle = "update urunler set urun_ad=@p1,kategori_no=@p3,fiyat=@p4 where urun_no=@p2";
            NpgsqlCommand cmd2 = new NpgsqlCommand(guncelle, baglanti);
            cmd2.Parameters.AddWithValue("@p2", int.Parse(textBox4.Text));
            cmd2.Parameters.AddWithValue("@p4", int.Parse(textBox7.Text));
            cmd2.Parameters.AddWithValue("@p3", int.Parse(textBox2.Text));
            cmd2.Parameters.AddWithValue("@p1", textBox1.Text);

            cmd2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ürün Güncellendi");
            TextTemizle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            dataGridView1.Visible = true;
            string sorgu = "select urun_no,urun_ad from urunler";
            NpgsqlDataAdapter cmd = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            cmd.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }
    }
}
