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
    public partial class FrmMusteri : Form
    {
        NpgsqlConnection baglanti = new
        NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=buse8597;Database=Restaurant;");
        public FrmMusteri()
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

        private void btnMusteriEkle_Click_1(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string ekle = "insert into musteriler (ad,soyad,tc_no,tel,adres,siparis_sayisi) values (@p1,@p2,@p7,@p3,@p4,@p5)";
            NpgsqlCommand cmd = new NpgsqlCommand(ekle, baglanti);
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd.Parameters.AddWithValue("@p2", textBox2.Text);
            cmd.Parameters.AddWithValue("@p7", textBox8.Text);
            cmd.Parameters.AddWithValue("@p3", textBox3.Text);
            cmd.Parameters.AddWithValue("@p4", textBox4.Text);
            cmd.Parameters.AddWithValue("@p5", 0);

            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Yeni Müşteri Eklendi");
            TextTemizle();
        }

        private void btnMusteriSorgula_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string bul = "select * from musteriler where tc_no=@p1";
            NpgsqlCommand cmd = new NpgsqlCommand(bul, baglanti);
            cmd.Parameters.AddWithValue("@p1", textBox7.Text);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            TextTemizle();
            while (dr.Read())
            {
                textBox1.Text = dr[1].ToString();
                textBox2.Text = dr[2].ToString();
                textBox3.Text = dr[5].ToString();
                textBox4.Text = dr[4].ToString();
                textBox5.Text = dr[6].ToString();
                textBox8.Text = dr[3].ToString();
            }
            if (textBox1.Text == "") MessageBox.Show("Kayıtlı müşteri bulunamadı!");
            baglanti.Close();
        }

        private void btnMusteriGuncelle_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string guncelle = "update musteriler set ad=@p1, soyad=@p2,adres=@p3,tel=@p4 where tc_no = @p5";
            NpgsqlCommand cmd2 = new NpgsqlCommand(guncelle, baglanti);
            cmd2.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd2.Parameters.AddWithValue("@p2", textBox2.Text);
            cmd2.Parameters.AddWithValue("@p3", textBox4.Text);
            cmd2.Parameters.AddWithValue("@p4", textBox3.Text);
            cmd2.Parameters.AddWithValue("@p5", textBox8.Text);

            cmd2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Müşteri Bilgileri Güncellendi");
            TextTemizle();
        }

        private void btnMusteriSil_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string sil = "delete from musteriler where tc_no=@p1";
            NpgsqlCommand cmd = new NpgsqlCommand(sil, baglanti);
            cmd.Parameters.AddWithValue("@p1", textBox8.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Müşteri Bilgileri Silindi");
            TextTemizle();
        }
    }
}
