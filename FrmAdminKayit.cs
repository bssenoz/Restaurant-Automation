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
    public partial class FrmAdminKayit : Form
    {
        NpgsqlConnection baglanti = new
        NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=buse8597;Database=Restaurant;");
        public FrmAdminKayit()
        {
            InitializeComponent();
        }

        private void btnAdminKayit_Click(object sender, EventArgs e)
        {

            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string bul = "select * from personeller where personel_no=@p1";
            NpgsqlCommand cmda = new NpgsqlCommand(bul, baglanti);
            cmda.Parameters.AddWithValue("@p1", int.Parse(textBox5.Text));
            NpgsqlDataReader dr = cmda.ExecuteReader();
            if (dr.Read())
            {
                baglanti.Close();
                try
                {
                    if (baglanti.State == ConnectionState.Closed)
                        baglanti.Open();
                    string ekle = "insert into admin (personel_no,username,password) values (@p5,@p7,@p8)";
                    NpgsqlCommand cmd = new NpgsqlCommand(ekle, baglanti);
                    cmd.Parameters.AddWithValue("@p5", int.Parse(textBox5.Text));
                    cmd.Parameters.AddWithValue("@p7", textBox7.Text);
                    cmd.Parameters.AddWithValue("@p8", textBox8.Text);

                    cmd.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Kayıt Oluşturuldu");
                    FrmGiris yeniSayfa = new FrmGiris();
                    this.Hide();
                    yeniSayfa.ShowDialog();
                    this.Show();

                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }else
            {
                baglanti.Close();
                MessageBox.Show("Personel bulunamadı!");
            }
        }
    }
}
