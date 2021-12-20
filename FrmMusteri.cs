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
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string ekle = "call musteriEkle (:p_ad,:p_soyad,:p_tc_no,:p_tel,:p_adres,:p_siparis_sayisi)";
                NpgsqlCommand cmd = new NpgsqlCommand(ekle, baglanti);
                cmd.Parameters.AddWithValue(":p_tc_no", textBox8.Text);
                if (textBox8.Text.Length != 11) MessageBox.Show("TC No 11 haneli olmalıdır!!");
                else
                {
                    cmd.Parameters.AddWithValue(":p_ad", textBox1.Text);
                    cmd.Parameters.AddWithValue(":p_soyad", textBox2.Text);
                    cmd.Parameters.AddWithValue(":p_tel", textBox3.Text);
                    cmd.Parameters.AddWithValue(":p_adres", textBox4.Text);
                    cmd.Parameters.AddWithValue(":p_siparis_sayisi", 0);
                    cmd.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Müşteri Eklendi");
                }

                TextTemizle();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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
