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
    public partial class FrmServisTurleri : Form
    {
        NpgsqlConnection baglanti = new
        NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=buse8597;Database=Restaurant");
        public FrmServisTurleri()
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

        private void btnServisEkle_Click_1(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string ekle = "insert into servis_turleri (ad) values (@p1)";
            NpgsqlCommand cmd = new NpgsqlCommand(ekle, baglanti);
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Yeni Servis Türü Eklendi");
            TextTemizle();
        }

        private void btnServisBul_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string bul = "select * from servis_turleri where servisturu_no=@p1";
            NpgsqlCommand cmd = new NpgsqlCommand(bul, baglanti);
            cmd.Parameters.AddWithValue("@p1", int.Parse(textBox3.Text));
            NpgsqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox1.Text = dr[1].ToString();
            }
            baglanti.Close();
        }

        private void btnServisGoster_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "select * from servis_turleri";
            NpgsqlDataAdapter cmd = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            cmd.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void btnServisGuncelle_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string guncelle = "update servis_turleri set ad=@p1 where servisturu_no=@p2";
            NpgsqlCommand cmd2 = new NpgsqlCommand(guncelle, baglanti);
            cmd2.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd2.Parameters.AddWithValue("@p2", int.Parse(textBox3.Text));

            cmd2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Servis Türü Güncellendi");
            TextTemizle();
        }

        private void btnServisSil_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string sil = "delete from servis_turleri where servisturu_no=@p1";
            NpgsqlCommand cmd = new NpgsqlCommand(sil, baglanti);
            cmd.Parameters.AddWithValue("@p1", int.Parse(textBox3.Text));
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Servis Türü Kaldırıldı");
            TextTemizle();
        }

    }
}
