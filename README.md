# 🧾 Fatura Uygulaması

## 📌 Proje Açıklaması

Bu uygulama, kullanıcıların kolayca fatura oluşturup yönetebilmesini sağlayan bir **C# Windows Forms** projesidir. Ürün veya hizmet detaylarının girilmesine, toplamların hesaplanmasına, PDF çıktısı alınmasına ve ek bilgilerin yönetilmesine olanak tanır. Ayrıca dijital imza/mühür gibi detaylar da desteklenmektedir.

---

## 🚀 Özellikler

- Fatura başlık ve kalem bilgilerini düzenleme
- PDF formatında fatura oluşturma (`InvoiceDocument.cs`)
- Alıcı ve banka bilgileri için ek form (`AdditionalInfoForm.cs`)
- SQL Server LocalDB ile veritabanı desteği
- Otomatik toplam hesaplama
- Dijital imza/mühür görseli ekleme desteği

---

## 🛠️ Kullanılan Teknolojiler

- **C#**
- **Windows Forms**
- **iText (PDF işlemleri için)**
- **SQL Server LocalDB**

---

## ⚙️ Kurulum ve Çalıştırma

### 🔑 Önkoşullar

- **Visual Studio 2019** veya üzeri
- **.NET Framework 4.7.2** veya daha güncel sürüm

### 📝 Kurulum Adımları

1. **Projeyi Klonlayın veya İndirin**
   ```bash
   git clone <proje_deposu_url>
   ```

   Alternatif olarak ZIP dosyasını indirip çıkarabilirsiniz.

2. **Projeyi Visual Studio'da Açın**

   * Visual Studio'yu başlatın.
   * `Dosya > Aç > Proje/Çözüm` adımlarını izleyin.
   * `Fatureapp.csproj` dosyasını seçin.

3. **Veritabanı Kurulumu**

   * `DB.mdf` ve `DB_log.ldf` dosyaları proje dizininde mevcuttur.
   * Visual Studio içinden `Sunucu Gezgini` veya `SQL Server Nesne Gezgini` ile ekleyin.
   * `App.config` dosyasındaki connection string'in güncel ve doğru olduğundan emin olun.

4. **Bağımlılıkları Yükleyin**

   * NuGet paketleri proje açıldığında otomatik yüklenmelidir.
   * Aksi durumda: `Çözüm Gezgini > Sağ Tık > NuGet Paketlerini Yönet…` menüsünden eksik paketleri (özellikle `iTextSharp`) yükleyin.

5. **Projeyi Derleyin**

   * `Yapı > Çözümü Yeniden Oluştur` adımıyla projenizi derleyin.

### ▶️ Uygulamayı Başlatma

* `Başlat` (yeşil ▶️ düğme) ile uygulamayı çalıştırabilirsiniz.
* Alternatif olarak `bin\Debug` veya `bin\Release` klasöründeki `Fatureapp.exe` çalıştırılabilir.

---

## 📦 Setup (Kurulum Dosyası)

Uygulamayı hızlıca denemek için hazırlanmış kurulum dosyasını aşağıdaki linkten indirebilirsiniz:

👉 [Fatura Uygulaması Kurulum Dosyası](https://drive.google.com/file/d/1AG2Xbcet86JwIHDR0stCSlcrq5FlS3SG/view?usp=sharing)

### 📝 Kurulum Notu
- Kurulum dosyasını indirdikten sonra çalıştırın
- Windows Defender veya antivirüs yazılımınız uyarı verebilir (normal bir durumdur)
- Kurulum tamamlandıktan sonra masaüstünden veya başlat menüsünden uygulamayı çalıştırabilirsiniz

---

## 🧪 Kullanım

Uygulama açıldığında, `invoice.cs` ana formu görüntülenecektir. Buradan fatura bilgilerini girip PDF oluşturabilir, `AdditionalInfoForm` üzerinden ek bilgi ve banka bilgilerini tanımlayabilirsiniz.

### Temel Kullanım Adımları:
1. Fatura bilgilerini girin (müşteri, ürün/hizmet detayları)
2. Gerekirse ek bilgi formundan banka bilgilerini ekleyin
3. PDF olarak faturayı oluşturun ve kaydedin

---

## 🤝 Katkı Sağlama

Katkıda bulunmak isterseniz, öncelikle bir konu (issue) oluşturarak önerinizi paylaşın. Daha sonra bir **Pull Request (PR)** gönderebilirsiniz.

---



## 📧 İletişim

Her türlü geri bildirim ve soru için proje yöneticisine ulaşabilirsiniz.
hadi244588@gmail.com

---

## 🔧 Sorun Giderme

### Yaygın Sorunlar:
- **Veritabanı bağlantı hatası**: App.config dosyasındaki connection string'i kontrol edin
- **PDF oluşturma hatası**: iTextSharp paketinin doğru yüklendiğinden emin olun
- **Kurulum sorunu**: Yönetici olarak çalıştırmayı deneyin

### Sistem Gereksinimleri:
- Windows 10 veya üzeri
- .NET Framework 4.7.2 veya üzeri
- En az 100 MB boş disk alanı
