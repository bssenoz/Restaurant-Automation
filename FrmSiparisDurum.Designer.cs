
namespace PROJE2
{
    partial class FrmSiparisDurum
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnSiparisleriGoster = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnMasaDurumu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Yellow;
            this.button1.Location = new System.Drawing.Point(546, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(220, 67);
            this.button1.TabIndex = 0;
            this.button1.Text = "SİPARİŞ AL";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSiparisleriGoster
            // 
            this.btnSiparisleriGoster.BackColor = System.Drawing.Color.CadetBlue;
            this.btnSiparisleriGoster.Location = new System.Drawing.Point(546, 163);
            this.btnSiparisleriGoster.Name = "btnSiparisleriGoster";
            this.btnSiparisleriGoster.Size = new System.Drawing.Size(220, 67);
            this.btnSiparisleriGoster.TabIndex = 1;
            this.btnSiparisleriGoster.Text = "SİPARİŞLERİ GÖSTER";
            this.btnSiparisleriGoster.UseVisualStyleBackColor = false;
            this.btnSiparisleriGoster.Click += new System.EventHandler(this.btnSiparisleriGoster_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(162, 262);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(604, 150);
            this.dataGridView1.TabIndex = 2;
            // 
            // btnMasaDurumu
            // 
            this.btnMasaDurumu.BackColor = System.Drawing.Color.CadetBlue;
            this.btnMasaDurumu.Location = new System.Drawing.Point(245, 163);
            this.btnMasaDurumu.Name = "btnMasaDurumu";
            this.btnMasaDurumu.Size = new System.Drawing.Size(220, 67);
            this.btnMasaDurumu.TabIndex = 3;
            this.btnMasaDurumu.Text = "MASA DURUMU";
            this.btnMasaDurumu.UseVisualStyleBackColor = false;
            this.btnMasaDurumu.Click += new System.EventHandler(this.btnMasaDurumu_Click);
            // 
            // FrmSiparisDurum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnMasaDurumu);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnSiparisleriGoster);
            this.Controls.Add(this.button1);
            this.Name = "FrmSiparisDurum";
            this.Text = "Form4";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSiparisleriGoster;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnMasaDurumu;
    }
}