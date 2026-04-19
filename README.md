# DVD / Film Kiralama Otomasyonu

Bu proje, farklı işletim sistemleri (Ubuntu 24.04 ve Windows 11) üzerinde çalışan bir DVD kiralama otomasyonunun temel mimarisini oluşturmaktadır. Proje, sadece yerel ağ üzerinden port haberleşmesi ve veritabanı entegrasyonuna odaklanan bir istemci-sunucu (client-server) yapısıdır.

## Kullanılan Teknolojiler

* **Veritabanı:** Docker üzerinde çalışan Microsoft SQL Server.
* **Backend:** Ubuntu 24.04 üzerinde C# uygulaması.
* **Frontend:** Windows 11 üzerinde C# WinForms.
* **Haberleşme:** TCP/IP protokolü ve JSON Serileştirme.
* **ORM:** Entity Framework Core (LINQ destekli).

## Proje Yapısı

Kod tekrarını önlemek için projenin merkezinde her iki tarafın da referans aldığı bir kütüphane bulunmaktadır:

* **SharedLib:** Ortak kullanılan `SignInRequest` modellerini ve TCP iletişim metodlarını barındıran sınıf kütüphanesi.
* **Backend:** Veritabanı sorgularını ve iş mantığını yöneten sunucu tarafı.
* **Frontend:** Kullanıcı arayüzünü barındıran istemci tarafı.
* **dvdOtomasyonDB:** SQL Server altyapısını kuran Docker yapılandırması.

## Mevcut Durum (Geliştirme Aşaması)

Proje henüz tamamlanmamış olup aktif geliştirme sürecindedir:
* **TCP Altyapısı:** Backend ve Frontend arasında port üzerinden mesaj alışverişi aktif durumdadır.
* **Veritabanı Şeması:** EF Core Migrations ile temel tablolar oluşturulmuş ve Docker üzerinden erişim sağlanmıştır.
* **İş Mantığı:** Kullanıcı girişindeki SHA256 hashleme ve filmlerin listelenmesi gibi backend fonksiyonları henüz yazım aşamasındadır.
* **Arayüz/UI:** WinForms tarafında tasarımlar başlangıç seviyesindedir.

## Nasıl Çalıştırılır?

### 1. Veritabanı (Ubuntu 24.04)
`dvdOtomasyonDB` klasöründe bir `.env` dosyası oluşturup şifrelerinizi tanımladıktan sonra:
```bash
docker-compose up -d
```

### 2. Backend (Ubuntu 24.04)
`.NET CLI` kullanarak sunucuyu başlatın:
```bash
cd Backend
dotnet run
```

### 3. Frontend (Windows 11)
Visual Studıo 2022 ile `DvdOtomasyonu.csproj` dosyasını açın ve `SharedLib` referansının bağlı olduğundan emin olduktan sonra projeyi çalıştırın.

## ***Not: Yerel ağ haberleşmesi için Backend'in çalıştığı makinenin IP adresi ve port izinleri (UFW) kontrol edilmelidir.***
