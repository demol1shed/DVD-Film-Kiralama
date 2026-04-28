using Backend.Context;
using Backend.Models;
using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Backend.Services
{
    public static class MovieSeeder
    {
        public static void Seed(string filePath)
        {
            using var db = new DvdContext();

            // Eğer veritabanında zaten film varsa tekrar yüklemeyi atla
            if (db.Movies.Any())
            {
                Console.WriteLine("[DB] Sistemde yüklü filmler bulunuyor, seeder işlemi atlandı.");
                return; 
            }

            Console.WriteLine("[DB] Veri dosyasından film verileri yükleniyor...");

            var config = new CsvConfiguration(CultureInfo.InvariantCulture) 
            {
                HasHeaderRecord = true,
                MissingFieldFound = null // Eksik kolon okunduğunda çökmesini engeller
            };
            
            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, config);

            csv.Read();
            csv.ReadHeader();

            while (csv.Read())
            {
                try
                {
                    var movie = new Movie
                    {
                        MovieName = csv.GetField("Movie Title") ?? "Bilinmiyor",
                        // CSV'deki yazım yanlışına (Realease) sadık kalarak okuyoruz
                        ReleaseDate = csv.GetField<int>("Year of Realease"), 
                        Genre = csv.GetField("Genre") ?? "Bilinmeyen Tür",
                        ImdbRating = csv.GetField<double>("Movie Rating"),
                        TotalBorrowCount = 0,
                        TimeNotBorrowed = DateTime.Now
                    };

                    db.Movies.Add(movie);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[-] Satır okunurken bir hata oluştu ve atlandı: {ex.Message}");
                }
            }

            // Döngü bittikten sonra tüm filmleri tek seferde veritabanına kaydediyoruz
            db.SaveChanges();
            Console.WriteLine("[+] Film verileri başarıyla veritabanına aktarıldı.");
        }
    }
}