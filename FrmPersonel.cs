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
    public partial class FrmPersonel : Form
    {
        NpgsqlConnection baglanti = new
        NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=buse8597;Database=Restaurant;");
        string toplamPersonel;

        public FrmPersonel()
        {
            InitializeComponent();
        }

        public void PersonelEkle()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string ekle = "call PersonelEkle (:p_tc_no,:p_ad,:p_soyad,:p_gorev_no,:p_maas)";
                NpgsqlCommand cmd = new NpgsqlCommand(ekle, baglanti);
                cmd.Parameters.AddWithValue(":p_tc_no", textBox1.Text);
                if (textBox1.Text.Length != 11) MessageBox.Show("TC No 11 haneli olmalıdır!!");
                else
                {
                    cmd.Parameters.AddWithValue(":p_ad", textBox2.Text);
                    cmd.Parameters.AddWithValue(":p_soyad", textBox3.Text);
                    cmd.Parameters.AddWithValue(":p_gorev_no", int.Parse(textBox4.Text));
                    cmd.Parameters.AddWithValue(":p_maas", int.Parse(textBox5.Text));
                    cmd.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Personel Eklendi");
                }

                TextTemizle();

              } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            PersonelEkle();
        }
        public void TextTemizle()
        {
            foreach (Control item in this.Controls)
            {
                if (item.GetType().ToString() == "System.Windows.Forms.TextBox") item.Text = "";
            }
        }
        public void PersonelSil()
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string sil = "delete from personeller where tc_no=@p1";
            NpgsqlCommand cmd = new NpgsqlCommand(sil, baglanti);
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Silindi");
            TextTemizle();

            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            

        }
        private void button2_Click(object sender, EventArgs e)
        {
            PersonelSil();
        }
        public void PersonelBul()
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string bul = "select * from personeller where tc_no=@p1";
            NpgsqlCommand cmd = new NpgsqlCommand(bul, baglanti);
            cmd.Parameters.AddWithValue("@p1", (textBox10.Text));
            NpgsqlDataReader dr = cmd.ExecuteReader();
            TextTemizle();
            while (dr.Read())
            {
                textBox1.Text = dr[1].ToString();
                textBox2.Text = dr[2].ToString();
                textBox3.Text = dr[3].ToString();
                textBox4.Text = dr[4].ToString();
                textBox5.Text = dr[5].ToString();
            }
            if (textBox1.Text=="") MessageBox.Show("Kayıtlı personel bulunamadı!");
            baglanti.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            PersonelBul();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string guncelle = "update personeller set ad=@p1, soyad=@p2,gorev_no=@p3,maas=@p4 where tc_no = @p7";
            NpgsqlCommand cmd2 = new NpgsqlCommand(guncelle, baglanti);
            cmd2.Parameters.AddWithValue("@p7", textBox1.Text);
            cmd2.Parameters.AddWithValue("@p1", textBox2.Text);
            cmd2.Parameters.AddWithValue("@p2", textBox3.Text);
            cmd2.Parameters.AddWithValue("@p3", int.Parse(textBox4.Text));
            cmd2.Parameters.AddWithValue("@p4", int.Parse(textBox5.Text));

            cmd2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Güncellendi");
            TextTemizle();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string sorgu = "select * from personeller";
            NpgsqlDataAdapter cmd = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            cmd.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();

            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            listBox2.Items.Clear();
            string sorgu2 = "select toplamPersonel()";
            NpgsqlCommand cmd2a = new NpgsqlCommand(sorgu2, baglanti);
            NpgsqlDataReader dra = cmd2a.ExecuteReader();
            while (dra.Read())
            {
                toplamPersonel = dra[0].ToString();
            }
            int tpersonel = int.Parse(toplamPersonel);

            baglanti.Close();
            listBox2.Items.Add(tpersonel);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmGorevler yeniSayfa = new FrmGorevler();
            this.Hide();
            yeniSayfa.ShowDialog();
            this.Show();
        }

        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string sorgu = "select toplamPersonel()";
            NpgsqlCommand cmd2a = new NpgsqlCommand(sorgu, baglanti);
            NpgsqlDataReader dra = cmd2a.ExecuteReader();
            while (dra.Read())
            {
                toplamPersonel = dra[0].ToString();
            }
            int tpersonel = int.Parse(toplamPersonel);

            baglanti.Close();
            listBox2.Items.Add(tpersonel);
        }
    }
}
