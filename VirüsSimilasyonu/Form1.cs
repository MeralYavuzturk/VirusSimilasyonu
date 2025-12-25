
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace VirüsSimilasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Formun klavye hareketlerini yakalaması için gerekli ayar
            this.KeyPreview = true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. ADIM: Ayarlar
            // Kendi ID'mizi alıyoruz ki program tarama yaparken yanlışlıkla kendini kapatmasın
            int selfId = Process.GetCurrentProcess().Id;

            // Proje adını buraya yaz (Solution Explorer'daki ile aynı olmalı)
            // string virusAdi = "VirüsSimilasyonu";
            string otomatikIsim = Process.GetCurrentProcess().ProcessName;

            label1.Text = "Sistem taranıyor...";
            label1.ForeColor = Color.Orange;
            this.Refresh();

            bool bulunduMu = false;

            // 2. ADIM: Tarama ve İmha
            foreach (Process p in Process.GetProcesses())
            {
                try
                {
                    // İsmi eşleşen süreci bul ama KENDİN DEĞİLSEN öldür
                    if (p.ProcessName.Equals(otomatikIsim, StringComparison.OrdinalIgnoreCase) && p.Id != selfId)
                    {
                        p.Kill();
                        bulunduMu = true;
                    }
                }
                catch { /* Sistem izin vermeyen süreçleri atla */ }
            }

            // 3. ADIM: Bildirim ve Çıkış
            if (bulunduMu)
            {
                label1.Text = "SİSTEM TEMİZLENDİ!";
                label1.ForeColor = Color.LimeGreen;
                this.Refresh();

                // Artık MessageBox kesinlikle görünecek
                MessageBox.Show("Zararlı yazılım başarıyla temizlendi! Sistem artık güvende.",
                                "Antivirüs Kalkanı",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                // Kullanıcı OK dedikten sonra her şeyi (mouse kilidini de) kapatır
                Environment.Exit(0);
            }
            else
            {
                label1.Text = "DURUM: Tehdit bulunamadı.";
                label1.ForeColor = Color.DeepSkyBlue;
                // MessageBox.Show("Aktif bir virüs bulunamadı. Lütfen proje ismini kontrol et.", "Bilgi");
                MessageBox.Show("Sistem tarandı, zararlı kalıntıları temizlendi.", "Antivirüs");
                Environment.Exit(0);
            }
        }

        // Enter tuşuna basınca butonu çalıştırır
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter || keyData == Keys.F5)
            {
                button1.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
