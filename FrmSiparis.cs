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
    public partial class FrmSiparis : Form
    {
        string urunfiyati;
        int tutar;
        string hesapNo;
        string tarih;
        string siparisNo;
        public void TextTemizle()
        {
            foreach (Control item in this.Controls)
            {
                if (item.GetType().ToString() == "System.Windows.Forms.TextBox") item.Text = "";
            }
        }
        NpgsqlConnection baglanti = new
        NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=buse8597;Database=Restaurant");
        public FrmSiparis()
        {
            InitializeComponent();
        }
    
        private void btnSiparisAl_Click_1(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string bul = "select fiyat from urunler where urun_no=@p1";
            NpgsqlCommand cmdd = new NpgsqlCommand(bul, baglanti);
            cmdd.Parameters.AddWithValue("@p1", int.Parse(textBox2.Text));
            
            NpgsqlDataReader dr = cmdd.ExecuteReader();
           
                while (dr.Read())
                {
                    urunfiyati = dr[0].ToString();
                }
                baglanti.Close();
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string bul2 = "select * from stok where urun_no=@p1";
                NpgsqlCommand cmda = new NpgsqlCommand(bul2, baglanti);
                cmda.Parameters.AddWithValue("@p1", int.Parse(textBox2.Text));
                NpgsqlDataReader dr2 = cmda.ExecuteReader();
                if (!dr2.Read())
                {
                    MessageBox.Show("Ürün tükenmiştir!");
                    baglanti.Close();
                    TextTemizle();
                }
                else
                {
                    baglanti.Close();
                    if (baglanti.State == ConnectionState.Closed)
                        baglanti.Open();
                    string ekle = "insert into siparisler (siparis_no,urun_no,adet,servisturu_no) values (@p4,@p2,@p3,@p1)";
                    NpgsqlCommand cmd = new NpgsqlCommand(ekle, baglanti);
                    int comboServis = int.Parse(comboBox1.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@p1", comboServis);
                    cmd.Parameters.AddWithValue("@p2", int.Parse(textBox2.Text));
                    cmd.Parameters.AddWithValue("@p3", int.Parse(textBox4.Text));
                    cmd.Parameters.AddWithValue("@p4", int.Parse(textBox3.Text));

                    cmd.ExecuteNonQuery();
                    baglanti.Close();

                    if (baglanti.State == ConnectionState.Closed)
                        baglanti.Open();
                    string bul22 = "insert into islemler (masa_no,siparis_no,durum) values (@p1,@p2,@p3)";
                    NpgsqlCommand cmd2 = new NpgsqlCommand(bul22, baglanti);
                    int comboMasa = int.Parse(comboBox2.SelectedItem.ToString());
                    cmd2.Parameters.AddWithValue("@p1", comboMasa);
                    cmd2.Parameters.AddWithValue("@p2", int.Parse(textBox3.Text));
                    cmd2.Parameters.AddWithValue("@p3", false);
                    cmd2.ExecuteNonQuery();
                    baglanti.Close();


                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string siparis = "update masalar set durum=@p1 where masa_no=@p2";
                NpgsqlCommand cmdr = new NpgsqlCommand(siparis, baglanti);
                cmdr.Parameters.AddWithValue("@p1", true);
                cmdr.Parameters.AddWithValue("@p2", comboMasa);
                cmdr.ExecuteNonQuery();
                baglanti.Close();


                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();

                string time = "select current_timestamp";
                NpgsqlCommand cmd4 = new NpgsqlCommand(time, baglanti);
                NpgsqlDataReader dt = cmd4.ExecuteReader();
                while (dt.Read())
                {
                    tarih = dt[0].ToString();
                }
                baglanti.Close();
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string hesap = "insert into hesaplar (siparis_no,odemeturu_no,indirim,toplam_tutar,hesap,tarih,durum) values (@p2,@p3,@p4,@p5,@p6,@p7,@p8)";
                NpgsqlCommand cmde = new NpgsqlCommand(hesap, baglanti);
                cmde.Parameters.AddWithValue("@p2", int.Parse(textBox3.Text));
                cmde.Parameters.AddWithValue("@p3", 1);
                cmde.Parameters.AddWithValue("@p4", 0); 
                cmde.Parameters.AddWithValue("@p5", tutar); 
                cmde.Parameters.AddWithValue("@p7", tarih);
                cmde.Parameters.AddWithValue("@p6", tutar);
                cmde.Parameters.AddWithValue("@p8", false);

                cmde.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Sipariş Alındı");
                    TextTemizle();

            }

                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string sorgu = "SELECT * FROM urunler ";

            NpgsqlDataAdapter cmd = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            cmd.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

      
        private void FrmSiparis_Load(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string bul = "select * from servis_turleri";

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
