# DVD / Film Kiralama Otomasyonu

Bu proje, farklı işletim sistemleri (Ubuntu 24.04 ve Windows 11) üzerinde çalışan, TCP/IP tabanlı istemci-sunucu (client-server) mimarisine sahip bir DVD ve film kiralama otomasyonudur. Sadece yerel ağ üzerinden port haberleşmesi ve veritabanı entegrasyonu odaklı geliştirilmiştir.

## Kullanılan Teknolojiler

* **Veritabanı:** Docker üzerinde çalışan Microsoft SQL Server.
* **Backend:** Ubuntu üzerinde çalışan .NET 10 (C#) konsol uygulaması.
* **Frontend:** Windows üzerinde çalışan C# WinForms (.NET 10).
* **Haberleşme:** Ham TCP/IP protokolü ve JSON Serileştirme.
* **ORM:** Entity Framework Core (Code-First yaklaşımı ve LINQ).

## Proje Yapısı

Sistem, kod tekrarını önlemek amacıyla her iki tarafın da referans aldığı ortak bir kütüphane etrafında şekillenmiştir:

* **SharedLib:** `SignInRequest`, `RentalRequest`, `MovieDTO` gibi veri transfer objelerini ve sunucu-istemci arasındaki TCP iletişim metodlarını (`ConnectTcp`) barındıran çekirdek sınıf kütüphanesi.
* **Backend:** 5000 portunu dinleyen, veritabanı işlemlerini (EF Core) ve uygulamanın iş mantığını (Auth, Rental, Data servisleri) yürüten sunucu.
* **Frontend:** Kullanıcı arayüzünü barındıran, TCP üzerinden sunucuya istek atıp dönen JSON cevaplarını işleyen masaüstü istemcisi.
* **dvdOtotmasyonDB:** Veritabanı altyapısını hızlıca ayağa kaldırmak için hazırlanan Docker yapılandırması.

## Özellikler

* **Kullanıcı Yetkilendirme:** SHA-256 şifreleme algoritması ile güvenli kullanıcı kaydı ve sisteme giriş.
* **Otomatik Veri Yükleme (Seeding):** Sunucu ilk ayağa kalktığında dışarıdan bir CSV dosyasını okuyarak film kütüphanesini otomatik olarak veritabanına aktarır.
* **Film Listeleme ve Arama:** Sistemdeki tüm filmleri listeleyebilme; isim, tür veya ID'ye göre anlık arama/filtreleme.
* **Kiralama Mekanizması:** İstemci üzerinden seçilen filmi kiralayabilme. Sistem, bir kullanıcının aynı filmi iade etmeden tekrar kiralamasına izin vermez.
* **Kullanıcı Paneli:** Giriş yapan kullanıcının "Kiraladıklarım" sekmesi altından sadece kendi hesabına tanımlı aktif kiralık filmleri görüntüleyebilmesi.

## Kurulum ve Çalıştırma

### 1. Veritabanı
* `dvdOtotmasyonDB` klasörü içinde bir `.env` dosyası oluşturun. İçerisine `DB_PORT` ve `DB_PASSWORD` değişkenlerini tanımladıktan sonra konteyneri başlatın:
```bash
docker-compose up -d
```

### Backend (Ubuntu 24.04)
* `Backend` klasörü içerisinde bir `appsettings.json` dosyası oluşturup/düzenleyip veritabanı bağlantı cümlenizi `DefaultConnection` olarak ayarlayın.
* `Program.cs` içerisindeki `MovieSeeder.Seed("/yol/filmler.csv")` metodunda bulunan CSV dosya yolunu kendi sisteminize göre güncelleyin.
* Terminal üzerinden sunucuyu başlatın.
```bash
cd Backend
dotnet run 
```

### Frontend (Windows 11)
* `Frontend` klasöründeki WinForms dosyalarında (`ucGiris.cs`, `ucKayit.cs`, `ucFilmler.cs`, `ucKiraliklar.cs`) yer alan `ConnectTcp.SendData("x.x.x.x", xxxx, ...)` satırındaki IP adresini, Backend uygulamasının ağ üzerinde yer aldığı güncel local IP adresiyle değiştirin.
* VisualStudio ile `DvdOtomasyonu.slnx` üzerinden projeyi derleyip çalıştırın.

## **Önemli Not:**
**Yerel ağ haberleşmesinin sağlanabilmesi için Backend'in çalıştığı makinede `UFW` veya `iptables` üzerinden 5000 portuna gelecek olan bağlantılara (`Inbound`) izin verilmiş olması gerekmektedir.**


## Gelecekte Eklenebilecekler
Gelecekte eklenmesi muhtemel olan güncellemeler güvenlik odaklı olacaktır.

* **Anti MITM Şifreleme Güncellemeleri:** Projede anlık olarak SSL/TLS veya uçtan uca şifreleme mekanizması bulunmadığından Backend server'ı **sniffing, MITM** gibi saldırılara açıktır.
* **Unsalted Hashing/Zayıf Şifre Problemi:** Projede SHA-256 tabanlı hashing algoritmamızda **salting** kullanılmaması dolayısıyla **Rainbow table** gibi saldırılar mümkündür. Aynı zamanda kullanıcıya şifresinin zayıflığı hakkında bilgi verilmemesi **brute forcing** tabanlı şifre tahmini saldırılarına açıktır.
* **Güvensiz Deserialization:** TCP üzerinden gelen JSON verileri nesnelere dönüşürken, güvensiz dönüştürme sonucunda **RCE**'ye izin verebilir.
