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
    
    public partial class FrmGiris : Form
    {
        //private int _personelId;
        //private int _personelGorevId;
        //private string _personelAd;
        //private string _personelSoyad;
        //private string _personelDurum;
        //private string _personelUsername;
        //private string _personelPassword;
        NpgsqlConnection baglanti = new
        NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=buse8597;Database=Restaurant;");
        bool result = false;
        string islem;
        string tarih;
        string adminNo;
        public FrmGiris()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if(baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string username = textBox1.Text;
            string password = textBox2.Text;
            textBox2.Text = "";
            textBox2.PasswordChar = '*';
            NpgsqlCommand command = new NpgsqlCommand("select * from admin where username= '" + username + "' and password= '" + password + "' ", baglanti);
            NpgsqlDataReader dr = command.ExecuteReader();
            if (dr.Read()) {
                MessageBox.Show("Giriş başarılı!");
                baglanti.Close();
      
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
                string bul2 = "select * from admin where username=@p1";
                NpgsqlCommand cmd5 = new NpgsqlCommand(bul2, baglanti);
                cmd5.Parameters.AddWithValue("@p1", username);
                NpgsqlDataReader dm = cmd5.ExecuteReader();
                while (dm.Read())
                {
                    adminNo = dm[0].ToString();
                }
                baglanti.Close();

                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string ekle = "insert into admin_hareketleri(admin_no,tarih) values (@p1,@p2)";
                NpgsqlCommand cmd = new NpgsqlCommand(ekle, baglanti);
                cmd.Parameters.AddWithValue("@p1", int.Parse(adminNo));
                cmd.Parameters.AddWithValue("@p2", tarih);
                cmd.ExecuteNonQuery();
                baglanti.Close();

                FrmMenu yeniSayfa = new FrmMenu();
                this.Hide();
                yeniSayfa.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Hatalı giriş!!!");
                baglanti.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
      
            FrmPersonel yeniSayfa = new FrmPersonel();
            this.Hide();
            yeniSayfa.ShowDialog();
            this.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            FrmAdminKayit yeniSayfa = new FrmAdminKayit();
            this.Hide();
            yeniSayfa.ShowDialog();
            this.Show();
        }


    }
}
