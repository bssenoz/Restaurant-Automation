
namespace PROJE2
{
    partial class FrmOdemeTurleri
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnOdemeTuruEkle = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnOdemeSil = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOdemeGuncelle = new System.Windows.Forms.Button();
            this.btnOdemeBul = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(150, 123);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(150, 174);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 1;
            // 
            // btnOdemeTuruEkle
            // 
            this.btnOdemeTuruEkle.BackColor = System.Drawing.Color.DarkCyan;
            this.btnOdemeTuruEkle.Location = new System.Drawing.Point(30, 240);
            this.btnOdemeTuruEkle.Name = "btnOdemeTuruEkle";
            this.btnOdemeTuruEkle.Size = new System.Drawing.Size(102, 58);
            this.btnOdemeTuruEkle.TabIndex = 2;
            this.btnOdemeTuruEkle.Text = "Ödeme Türü Ekle";
            this.btnOdemeTuruEkle.UseVisualStyleBackColor = false;
            this.btnOdemeTuruEkle.Click += new System.EventHandler(this.btnOdemeTuruEkle_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(402, 53);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(339, 189);
            this.dataGridView1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ödeme Türü";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ödeme No";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Turquoise;
            this.button1.Location = new System.Drawing.Point(531, 284);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(210, 41);
            this.button1.TabIndex = 6;
            this.button1.Text = "Ödeme Türlerini Göster";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnOdemeSil
            // 
            this.btnOdemeSil.BackColor = System.Drawing.Color.DarkCyan;
            this.btnOdemeSil.Location = new System.Drawing.Point(109, 327);
            this.btnOdemeSil.Name = "btnOdemeSil";
            this.btnOdemeSil.Size = new System.Drawing.Size(102, 57);
            this.btnOdemeSil.TabIndex = 7;
            this.btnOdemeSil.Text = "Ödeme Türü Sil";
            this.btnOdemeSil.UseVisualStyleBackColor = false;
            this.btnOdemeSil.Click += new System.EventHandler(this.btnOdemeSil_Click_1);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(134, 26);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(99, 22);
            this.textBox3.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Ödeme No";
            // 
            // btnOdemeGuncelle
            // 
            this.btnOdemeGuncelle.BackColor = System.Drawing.Color.DarkCyan;
            this.btnOdemeGuncelle.Location = new System.Drawing.Point(177, 241);
            this.btnOdemeGuncelle.Name = "btnOdemeGuncelle";
            this.btnOdemeGuncelle.Size = new System.Drawing.Size(102, 57);
            this.btnOdemeGuncelle.TabIndex = 10;
            this.btnOdemeGuncelle.Text = "Ödeme Türü Güncelle";
            this.btnOdemeGuncelle.UseVisualStyleBackColor = false;
            this.btnOdemeGuncelle.Click += new System.EventHandler(this.btnOdemeGuncelle_Click_1);
            // 
            // btnOdemeBul
            // 
            this.btnOdemeBul.BackColor = System.Drawing.Color.Turquoise;
            this.btnOdemeBul.Location = new System.Drawing.Point(254, 19);
            this.btnOdemeBul.Name = "btnOdemeBul";
            this.btnOdemeBul.Size = new System.Drawing.Size(74, 37);
            this.btnOdemeBul.TabIndex = 11;
            this.btnOdemeBul.Text = "Bul";
            this.btnOdemeBul.UseVisualStyleBackColor = false;
            this.btnOdemeBul.Click += new System.EventHandler(this.btnOdemeBul_Click_1);
            // 
            // FrmOdemeTurleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnOdemeBul);
            this.Controls.Add(this.btnOdemeGuncelle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.btnOdemeSil);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnOdemeTuruEkle);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "FrmOdemeTurleri";
            this.Text = "FrmOdemeTurleri";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnOdemeTuruEkle;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnOdemeSil;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOdemeGuncelle;
        private System.Windows.Forms.Button btnOdemeBul;
    }
}