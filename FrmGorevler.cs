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
    public partial class FrmGorevler : Form
    {
        NpgsqlConnection baglanti = new
        NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=buse8597;Database=Restaurant;");
        public FrmGorevler()
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
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Close();
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string ekle = "insert into personel_gorevleri (gorev_ad) values (@p1)";
            NpgsqlCommand cmd = new NpgsqlCommand(ekle, baglanti);
            cmd.Parameters.AddWithValue("@p1", textBox2.Text);
       
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Yeni Görev Eklendi");
            TextTemizle();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT personel_no," +
                "ad,soyad FROM personeller " +
                "INNER JOIN personel_gorevleri on personeller.gorev_no = personel_gorevleri.gorev_no" +
                " where gorev_ad like '%" + textBox3.Text + "%'", baglanti);

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
          
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "select * from personel_gorevleri";
            NpgsqlDataAdapter cmd = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            cmd.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }
    }
}
