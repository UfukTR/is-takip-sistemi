# İş Takip Sistemi

ASP.NET MVC ile geliştirilen modern iş takip ve yönetim sistemi.

## Özellikler

- ✅ İş Yönetimi (CRUD İşlemleri)
- ✅ Personel Yönetimi
- ✅ Birim Yönetimi
- ✅ Durum Takibi
- ✅ Responsive Bootstrap 5 Tasarımı
- ✅ SQL Server Veritabanı Entegrasyonu

## Teknolojiler

- **Framework:** ASP.NET MVC 5
- **ORM:** Entity Framework 6
- **Veritabanı:** SQL Server
- **Frontend:** Bootstrap 5
- **.NET Framework:** 4.7.2

## Kurulum

### Gereksinimler
- Visual Studio 2019 veya üzeri
- SQL Server
- .NET Framework 4.7.2

### Adımlar

1. Repository'yi klonlayın:
   ```bash
   git clone https://github.com/UfukTR/is-takip-sistemi.git
   cd is-takip-sistemi
   ```

2. NuGet Paketlerini yükleyin (Package Manager Console'da):
   ```powershell
   Install-Package EntityFramework
   Install-Package EntityFramework.SqlServer
   ```

3. Veritabanını oluşturun:
   - SQL Server Management Studio'da `IsTakipDB` veritabanını oluşturun
   - SQL script dosyasını çalıştırın (kök dizindeki SQL dosyası)

4. `Web.config` dosyasını düzenleyin (veritabanı bağlantı stringi)

5. Projeyı Visual Studio'da açın ve çalıştırın (F5)

## Proje Yapısı

```
IsTakipSistemi/
├── Models/                 # Veri modelleri
│   ├── Birimler.cs
│   ├── Durumlar.cs
│   ├── Isler.cs
│   ├── Personeller.cs
│   └── YetkiTurler.cs
├── Controllers/            # İş mantığı
│   ├── BirimController.cs
│   ├── DurumController.cs
│   ├── IslerController.cs
│   ├── PersonelController.cs
│   └── HomeController.cs
├── Views/                  # Görünümler
│   ├── Shared/
│   │   └── _Layout.cshtml
│   ├── Home/
│   ├── Isler/
│   ├── Personel/
│   ├── Birim/
│   └── Durum/
├── Data/
│   └── IsTakipDbContext.cs # Entity Framework Context
└── Web.config             # Konfigürasyon dosyası
```

## Kullanım

### Ana Sayfa
- Sisteme hoş geldiniz sayfası
- Tüm modüllere hızlı erişim

### İşler
- Yeni iş oluştur
- İşleri görüntüle
- İş detaylarını gör
- İşleri düzenle
- İşleri sil

### Personeller
- Personel ekle
- Personel bilgilerini yönet
- Birim atama
- Yetki türü atama

### Birimler
- Birim oluştur
- Birim bilgilerini düzenle
- İlişkili personelleri görüntüle

### Durumlar
- Durum tipi oluştur
- Durum bilgilerini yönet
- İlişkili işleri görüntüle

## Veritabanı Şeması

### Tablolar

#### Birimler
- `birimId` (PK, int)
- `birimAd` (nvarchar(50))

#### YetkiTurler
- `yetkiTurId` (PK, int)
- `yetkiTurAd` (nvarchar(50))

#### Personeller
- `personelId` (PK, int)
- `personelAdSoyad` (nvarchar(50))
- `personelKullaniciAd` (nvarchar(50))
- `personelParola` (nvarchar(50))
- `personelBirimId` (FK)
- `personelYetkiTurId` (FK)

#### Durumlar
- `durumId` (PK, int)
- `durumAd` (nvarchar(50))

#### Isler
- `isId` (PK, int)
- `isBaslik` (nvarchar(max))
- `isAciklama` (nvarchar(max))
- `isPersonelId` (FK)
- `iletilenTarih` (datetime)
- `yapilanTarih` (datetime)
- `isDurumId` (FK)

## İlişkiler (Relationships)

- **Personeller** → **Birimler** (Many-to-One)
- **Personeller** → **YetkiTurler** (Many-to-One)
- **Isler** → **Personeller** (Many-to-One)
- **Isler** → **Durumlar** (Many-to-One)

## Navigasyon

### Ana Menü
- Ana Sayfa
- Yönetim
  - İşler
  - Personeller
  - Birimler
  - Durumlar
- Hakkında
- İletişim

## Özellik Açıklamaları

### İş Yönetimi
- Her iş bir başlık, açıklama, ilişkili personel ve durum içerir
- İş oluşturulurken otomatik olarak "İletilen Tarih" atanır
- "Yapılan Tarih" manuel olarak güncellenebilir

### Personel Yönetimi
- Her personel bir ad-soyad, kullanıcı adı ve parola içerir
- Her personel bir birime ve yetki türüne atanabilir
- Personeller açılır liste seçimiyle işlere atanabilir

### Birim Yönetimi
- Kuruluşun departmanlarını yönetin
- Her birime kaç personel atandığını görün
- Birim detayında personel listesini görüntüleyin

### Durum Takibi
- İşlerin durumlarını tanımlayın (Yeni, Devam Ediyor, Tamamlandı, vb.)
- Durum detayında ilişkili işleri görüntüleyin

## Lisans

Bu proje MIT lisansı altında dağıtılmaktadır.

## Yazar

UfukTR

## Katkıda Bulunma

Katkılar memnuniyetle karşılanır. Lütfen bir Fork oluşturun ve Pull Request gönderin.
