
namespace PROJE2
{
    partial class FrmServisTurleri
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
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnServisEkle = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnServisGoster = new System.Windows.Forms.Button();
            this.btnServisBul = new System.Windows.Forms.Button();
            this.btnServisGuncelle = new System.Windows.Forms.Button();
            this.btnServisSil = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(173, 147);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(146, 32);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(183, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Servis Adı";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 15;
            // 
            // btnServisEkle
            // 
            this.btnServisEkle.BackColor = System.Drawing.Color.DarkCyan;
            this.btnServisEkle.Location = new System.Drawing.Point(49, 220);
            this.btnServisEkle.Name = "btnServisEkle";
            this.btnServisEkle.Size = new System.Drawing.Size(100, 54);
            this.btnServisEkle.TabIndex = 7;
            this.btnServisEkle.Text = "Servis Türü Ekle";
            this.btnServisEkle.UseVisualStyleBackColor = false;
            this.btnServisEkle.Click += new System.EventHandler(this.btnServisEkle_Click_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(420, 147);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(342, 216);
            this.dataGridView1.TabIndex = 8;
            // 
            // btnServisGoster
            // 
            this.btnServisGoster.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnServisGoster.Location = new System.Drawing.Point(589, 78);
            this.btnServisGoster.Name = "btnServisGoster";
            this.btnServisGoster.Size = new System.Drawing.Size(173, 41);
            this.btnServisGoster.TabIndex = 9;
            this.btnServisGoster.Text = "Servis Türlerini Göster";
            this.btnServisGoster.UseVisualStyleBackColor = false;
            this.btnServisGoster.Click += new System.EventHandler(this.btnServisGoster_Click);
            // 
            // btnServisBul
            // 
            this.btnServisBul.BackColor = System.Drawing.Color.DarkCyan;
            this.btnServisBul.Location = new System.Drawing.Point(270, 21);
            this.btnServisBul.Name = "btnServisBul";
            this.btnServisBul.Size = new System.Drawing.Size(85, 41);
            this.btnServisBul.TabIndex = 10;
            this.btnServisBul.Text = "Servis Bul";
            this.btnServisBul.UseVisualStyleBackColor = false;
            this.btnServisBul.Click += new System.EventHandler(this.btnServisBul_Click);
            // 
            // btnServisGuncelle
            // 
            this.btnServisGuncelle.BackColor = System.Drawing.Color.DarkCyan;
            this.btnServisGuncelle.Location = new System.Drawing.Point(186, 220);
            this.btnServisGuncelle.Name = "btnServisGuncelle";
            this.btnServisGuncelle.Size = new System.Drawing.Size(98, 54);
            this.btnServisGuncelle.TabIndex = 11;
            this.btnServisGuncelle.Text = "Servis Türü Güncelle";
            this.btnServisGuncelle.UseVisualStyleBackColor = false;
            this.btnServisGuncelle.Click += new System.EventHandler(this.btnServisGuncelle_Click);
            // 
            // btnServisSil
            // 
            this.btnServisSil.BackColor = System.Drawing.Color.DarkCyan;
            this.btnServisSil.Location = new System.Drawing.Point(115, 312);
            this.btnServisSil.Name = "btnServisSil";
            this.btnServisSil.Size = new System.Drawing.Size(92, 51);
            this.btnServisSil.TabIndex = 12;
            this.btnServisSil.Text = "Servis Türü Sil";
            this.btnServisSil.UseVisualStyleBackColor = false;
            this.btnServisSil.Click += new System.EventHandler(this.btnServisSil_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(68, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Servis No";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.btnServisBul);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Location = new System.Drawing.Point(151, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(375, 82);
            this.panel1.TabIndex = 16;
            // 
            // FrmServisTurleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnServisSil);
            this.Controls.Add(this.btnServisGuncelle);
            this.Controls.Add(this.btnServisGoster);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnServisEkle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "FrmServisTurleri";
            this.Text = "FrmServisTurleri";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnServisEkle;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnServisGoster;
        private System.Windows.Forms.Button btnServisBul;
        private System.Windows.Forms.Button btnServisGuncelle;
        private System.Windows.Forms.Button btnServisSil;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
    }
}