## 🛡️ C# Virüs & Antivirus 
#### Bu proje, siber güvenlik eğitim süreçlerinde zararlı yazılım mantığını ve süreç yönetimini (Process Management) görselleştirmek amacıyla geliştirilmiş bir GUI (Görsel Arayüz) simülasyonudur. Proje, konsol ekranı kullanmadan tamamen arka plan thread'leri ve Windows Form üzerinden çalışır.
### Çalıştırılabilir zip dosyası linki: https://github.com/MeralYavuzturk/VirusSimilasyonu/releases/tag/v1.0.0

### 🚀 Öne Çıkan Özellikler
* Tamamen Görsel Arayüz (GUI): Siyah konsol ekranı olmadan, profesyonel bir Windows Uygulaması (Windows Application) olarak çalışır.

* Akıllı Arka Plan Thread'i: Program başladığı anda arka planda bir iş parçacığı (Thread) oluşturarak mouse imlecini ekranın merkezine kilitler.

* Süreç Bazlı Savunma: Antivirüs modülü, sistemdeki aktif süreçleri tarayarak zararlı döngüyü tespit eder ve güvenli bir şekilde sonlandırır.

* Klavye Odaklı Kontrol: Mouse kilitliyken bile kullanıcı dostu bir deneyim için Enter tuşu ile tarama ve temizleme işlemi yapılabilir.

* Düşük Kaynak Tüketimi: Thread.Sleep(5) optimizasyonu ile CPU'yu yormadan sürekli izleme yapar.

### 🛠️ Teknik Detaylar
* Dil: C#

* Platform: .NET 8.0 (Windows)

* Mimari: Windows Forms & Multi-threading

* Önemli Metotlar: * Cursor.Position: Mouse imlecini kontrol etmek için.

* Process.Kill(): Tespit edilen zararlı süreci sonlandırmak için.

* ProcessCmdKey: Klavye kısayollarını (Enter) yakalamak için.

### 📖 Kullanım Senaryosu
1. Enfeksiyon: Uygulama açıldığı anda mouse kontrolü devre dışı kalır ve imleç merkeze sabitlenir.

2. Müdahale: Kullanıcı klavyeden Enter tuşuna basarak "Sistemi Tara ve Temizle" komutunu verir.

3. Analiz: Antivirüs süreci tarar, zararlı iş parçacığını öldürür ve kullanıcıya görsel geri bildirim (MessageBox) verir.

4. Sonuç: "SİSTEM TEMİZLENDİ" onayı alındıktan sonra program güvenli bir şekilde kapanır ve mouse serbest kalır.
### ⚠️ Eğitim Notu
* Bu yazılım sadece siber güvenlik farkındalığı oluşturmak amacıyla hazırlanmıştır. Gerçek sistemlere zarar verecek herhangi bir kod içermez.

