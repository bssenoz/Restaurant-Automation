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
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmSiparisDurum yeniSayfa = new FrmSiparisDurum();
            this.Hide();
            yeniSayfa.ShowDialog();
            this.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FrmPersonel yeniSayfa = new FrmPersonel();
            this.Hide();
            yeniSayfa.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmMutfak yeniSayfa = new FrmMutfak();
            this.Hide();
            yeniSayfa.ShowDialog();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmMusteri yeniSayfa = new FrmMusteri();
            this.Hide();
            yeniSayfa.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmRezervasyon yeniSayfa = new FrmRezervasyon();
            this.Hide();
            yeniSayfa.ShowDialog();
            this.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmKasa yeniSayfa = new FrmKasa();
            this.Hide();
            yeniSayfa.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmPaketServis yeniSayfa = new FrmPaketServis();
            this.Hide();
            yeniSayfa.ShowDialog();
            this.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FrmAyarlar yeniSayfa = new FrmAyarlar();
            this.Hide();
            yeniSayfa.ShowDialog();
            this.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
