# Ajax Ürün Arama

Bu proje, ASP.NET MVC kullanarak basit bir Ajax ile ürün arama (autocomplete) özelliği örneğini göstermektedir. Kullanıcı, metin kutusuna harf yazdıkça, veritabanında ilgili ürünleri arar ve anında sonuçları görüntüler.

## Özellikler
- **Ajax Arama (Autocomplete)**: Kullanıcı her tuşa bastığında ilgili ürünler dinamik olarak listelenir.
- **Entity Framework 6 (EF 6) veya EF Core**: Projeye göre veritabanı bağlantısı.
- **Basit MVC Yapısı**: Kolayca anlaşılır controller, model ve view dosyaları.

## Gereksinimler
- Visual Studio 2019 veya üzeri (veya uygun bir IDE).
- .NET Framework 4.5+ (Klasik ASP.NET MVC) veya .NET 5/6+ (ASP.NET Core).
- SQL Server (LocalDB, SQL Express veya tam sürüm).

## Kurulum

### 1. Veritabanı Ayarları
SQL Server üzerinden bir veritabanı oluşturun (ör. AjaxUrunAramaDB).

**Products tablosunu oluşturun (örnek tablo yapısı):**
```sql
CREATE TABLE Products
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    Stock INT NOT NULL
);
```

**Test verileri ekleyin:**
```sql
INSERT INTO Products (Name, Price, Stock)
VALUES ('Elma', 5.0, 100), ('Armut', 4.5, 80), ('Muz', 10.0, 120);
```

**Web.config (veya appsettings.json - .NET Core için) içinde Connection String'inizi düzenleyin. Örnek:**
```xml
<connectionStrings>
  <add name="DefaultConnection"
       connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=AjaxUrunAramaDB;Integrated Security=True"
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

### 2. Projeyi Çalıştırma
- Proje dosyalarını indirin veya kopyalayın.
- Visual Studio'da projeyi açın.
- Gerekli NuGet Paketleri (Entity Framework vb.) yüklü değilse Package Manager Console üzerinden yükleyin:
  ```powershell
  Install-Package EntityFramework
  ```
- Projeyi Build edin ve çalıştırın.
- Tarayıcınızda `http://localhost:xxxx/Product/Index` adresine gidin.
- Metin kutusuna bir harf yazın, arama sonuçları anında görüntülenecektir.

## Proje Mimarisi

### Klasör Yapısı

## Önemli Dosyalar
- **Controllers/ProductController.cs**: Search action metodu, Ajax çağrısı ile ürün araması yapar.
- **Models/Product.cs**: Ürün model sınıfı (Id, Name, Price, Stock).
- **Models/ProductContext.cs**: Entity Framework DbContext sınıfı. Products DbSet'ini içerir.
- **Views/Product/Index.cshtml**: Ana sayfa. Metin kutusu ve JavaScript kodu burada yer alır.
- **Web.config**: Connection String ve uygulama yapılandırması.

## Nasıl Kullanılır
- **Arama Kutusu**: Index.cshtml sayfasındaki metin kutusuna ürünle ilgili harfleri girin.
- **Ajax Çağrısı**: JavaScript ile ProductController üzerindeki Search metoduna parametre olarak girilen kelime (term) gönderilir.
- **Sonuçlar**: Metod, Products tablosunda Name alanında geçen kayıtları JSON formatında döndürür.
- **Dinamik Liste**: Dönen sonuçlar, sayfa yenilenmeden `<ul>` ya da `<table>` içerisinde görüntülenir.


```
AjaxUrunArama
├── App_Data                # Uygulama verileri için kullanılan klasör.
├── App_Start               # Uygulama başlangıç ayarları.
├── Content                 # CSS, resim ve diğer statik içerikler.
├── Controllers             # Uygulamanın iş mantığını yöneten controller dosyaları.
│ └── ProductController.cs  # Ürün arama işlemlerini yöneten controller.
├── Models                  # Uygulamanın veri modelleri.
│ ├── Product.cs            # Ürün model sınıfı (Id, Name, Price, Stock).
│ └── ProductContext.cs     # Entity Framework DbContext sınıfı. Products DbSet’ini içerir.
├── Scripts                 # JavaScript dosyaları.
├── Views                   # Uygulamanın kullanıcı arayüzü dosyaları.
│ └── Product
│ └── Index.cshtml          # Ana sayfa. Metin kutusu ve JavaScript kodu burada yer alır.
├── Global.asax             # Uygulama başlangıç ve olay yönetimi.
├── packages.config         # Projede kullanılan NuGet paketlerinin listesi.
├── Web.config              # Connection String ve uygulama yapılandırması.
└── README.md               # Proje hakkında bilgi veren dosya.
```

