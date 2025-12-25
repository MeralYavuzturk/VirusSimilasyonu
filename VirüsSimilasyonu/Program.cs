/*using System;
using System.Drawing; // Bu kütüphane için projeye referans eklemek gerekebilir
using System.Windows.Forms; // Mouse kontrolü için gerekli
using System.Threading;

namespace ZarliYazilimSimulasyonu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Virüs çalışıyor... Mouse kilitlendi!");
            Console.WriteLine("Durdurmak için Antivirüs programını kullanmalısın.");

            // Ekran çözünürlüğünü alalım
             int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            // 16. ve 17. satırları şu şekilde değiştir:
           // int screenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
           // int screenHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;

            // 23. satırdaki Cursor.Position kısmını şu şekilde değiştir:
            //System.Windows.Forms.Cursor.Position = new Point(screenWidth / 2, screenHeight / 2);

            // Sonsuz döngü: Mouse'u sürekli merkeze çeker
            while (true)
            {
                // Mouse imlecini ekranın tam ortasına ışınla
                Cursor.Position = new Point(screenWidth / 2, screenHeight / 2);

                // İşlemciyi çok yormamak için çok kısa bir ara ver
                Thread.Sleep(5);
            }
        }
    }
}
*/
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using VirüsSimilasyonu;

namespace ZarliYazilimSimulasyonu
{
    static class Program
    {
        /// <summary>
        /// Uygulamanın ana giriş noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 1. ADIM: Mouse kilitleme işlemini ayrı bir kolda (Thread) başlatıyoruz.
            // Bu sayede "while(true)" döngüsü formun açılmasını engellemez.
            Thread virusThread = new Thread(() =>
            {
                // Ekran çözünürlüğünü alıyoruz
                int screenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
                int screenHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;

                while (true)
                {
                    // Mouse imlecini sürekli merkeze çeker
                    System.Windows.Forms.Cursor.Position = new Point(screenWidth / 2, screenHeight / 2);

                    // İşlemciyi korumak için kısa bekleme
                    Thread.Sleep(5);
                }
            });

            // Form kapandığında bu arka plan işleminin de durması için 'IsBackground' yapıyoruz.
            virusThread.IsBackground = true;
            virusThread.Start();

            // 2. ADIM: Antivirüs Form Ekranını başlatıyoruz.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // ÖNEMLİ: Eğer formunun adı 'Form1' değilse burayı kendi form adınla değiştir.
            Application.Run(new Form1());
        }
    }
}
