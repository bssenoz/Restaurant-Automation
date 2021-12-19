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
    public partial class FrmRezervasyon : Form
    {
        NpgsqlConnection baglanti = new
        NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=buse8597;Database=Restaurant;");
        public FrmRezervasyon()
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
        private void btnRezervasyonAl_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string bul = "select * from musteriler where musteri_no=@p1";
            NpgsqlCommand cmda = new NpgsqlCommand(bul, baglanti);
            cmda.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            NpgsqlDataReader dr = cmda.ExecuteReader();
            if (!dr.Read()) {
                MessageBox.Show("Müşteri bulunamadı! Lütfen kayıt yapın.");
                baglanti.Close();
                TextTemizle();
            } else
            {
                baglanti.Close();
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string ekle = "insert into rezervasyonlar (musteri_no,masa_no,tarih,kisi_sayisi) values (@p2,@p3,@p5,@p6)";
                NpgsqlCommand cmd = new NpgsqlCommand(ekle, baglanti);
                int comboMasa = int.Parse(comboBox2.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@p2", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@p3", comboMasa);
                cmd.Parameters.AddWithValue("@p5", textBox4.Text);
                cmd.Parameters.AddWithValue("@p6", int.Parse(textBox5.Text));

                cmd.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Rezervasyon İşlemi Başarılı");
                TextTemizle();
            }
        }
        private void btnRezervasyonGuncelle_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string guncelle = "update rezervasyonlar set musteri_no=@p1, masa_no=@p2,tarih=@p4,kisi_sayisi= @p5 where rezervasyon_no = @p6";
            NpgsqlCommand cmd2 = new NpgsqlCommand(guncelle, baglanti);
            int comboMasa = int.Parse(comboBox2.SelectedItem.ToString());
            cmd2.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            cmd2.Parameters.AddWithValue("@p2", comboMasa);
            cmd2.Parameters.AddWithValue("@p4", textBox4.Text);
            cmd2.Parameters.AddWithValue("@p5", int.Parse(textBox5.Text));
            cmd2.Parameters.AddWithValue("@p6", int.Parse(textBox7.Text));

            cmd2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Rezervasyon Güncellendi");
            TextTemizle();
        }

        private void btnRezervasyonBul_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string bul = "select * from rezervasyonlar where rezervasyon_no=@p1";
            NpgsqlCommand cmd = new NpgsqlCommand(bul, baglanti);
            cmd.Parameters.AddWithValue("@p1", int.Parse(textBox7.Text));
            NpgsqlDataReader dr = cmd.ExecuteReader();
     
            while (dr.Read())
            {
                textBox1.Text = dr[1].ToString();
                comboBox2.SelectedItem = dr[2].ToString();
                textBox4.Text = dr[3].ToString();
                textBox5.Text = dr[4].ToString();
            }

            baglanti.Close();
        }

        private void btnRezervasyonSil_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string sil = "call rezervasyonSil(:p_no)";
            NpgsqlCommand cmd = new NpgsqlCommand(sil, baglanti);
            cmd.Parameters.AddWithValue(":p_no", int.Parse(textBox7.Text));
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Rezervasyon Silindi");
            TextTemizle();
        }

        private void btnRezervasyonGoster_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            baglanti.Open();
            dataGridView1.Visible = true;
            string sorgu = "select * from rezervasyonlar";
            NpgsqlDataAdapter cmd = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            cmd.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void FrmRezervasyon_Load(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string bul2 = "select * from masalar";

            DataTable dt2 = new DataTable();
            NpgsqlDataAdapter adp2 = new NpgsqlDataAdapter(bul2, baglanti);
            adp2.Fill(dt2);

            foreach (DataRow dr2 in dt2.Rows)
            {
                comboBox2.Items.Add(dr2[0].ToString());
            }
        }
    }
}
