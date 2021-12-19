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
    public partial class FrmStok : Form
    {
        NpgsqlConnection baglanti = new
        NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=buse8597;Database=Restaurant");
        public FrmStok()
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


        private void btnStokEkle_Click_1(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string ekle = "insert into stok (urun_no,adet) values (@p1,@p2)";
            NpgsqlCommand cmd = new NpgsqlCommand(ekle, baglanti);
            cmd.Parameters.AddWithValue("@p1", int.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@p2", int.Parse(textBox3.Text));
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Eklendi");
            TextTemizle();
        }

        private void btnStokGuncelle_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string guncelle = "update stok set  urun_no=@p1,adet=@p2 where stok_no=@p3";
            NpgsqlCommand cmd2 = new NpgsqlCommand(guncelle, baglanti);
            cmd2.Parameters.AddWithValue("@p1", int.Parse(textBox2.Text));
            cmd2.Parameters.AddWithValue("@p2", int.Parse(textBox3.Text));
            cmd2.Parameters.AddWithValue("@p3", int.Parse(textBox4.Text));

            cmd2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Stok Güncellendi");
            TextTemizle();
        }

        private void btnStokBul_Click_1(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string bul = "select * from stok where stok_no=@p1";
            NpgsqlCommand cmd = new NpgsqlCommand(bul, baglanti);
            cmd.Parameters.AddWithValue("@p1", (int.Parse(textBox4.Text)));
            
            NpgsqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox2.Text = dr[1].ToString();
                textBox3.Text = dr[2].ToString();
            }
            baglanti.Close();
        }

        private void btnStokDurumu_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string sorgu = "SELECT stok_no,stok.urun_no,urun_ad,adet FROM stok INNER JOIN urunler on stok.urun_no = urunler.urun_no";

            NpgsqlDataAdapter cmd = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            cmd.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

    }
}
