using Backend.Context;
using Backend.Models;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace Backend.Services
{
    public static class MovieSeeder
    {
        public static void Seed(string filePath)
        {
            using var db = new DvdContext();

            if (db.Movies.Any())
            {
                Console.WriteLine("yuklu filmler bulunuyor.");
            }

            Console.WriteLine("[DB] Veri dosyasindan film verileri yukleniyor.");

            var config = new CsvConfiguration(CultureInfo.InvariantCulture) {HasHeaderRecord = true};
            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, config);

            csv.Read();
            csv.ReadHeader();

            /*while (csv.Read())
            {
                /*try
                {
                    /*var movie = new Movie
                    {
                        MovieName = csv.GetField("Movie Title"),
                        //ReleaseDate = csv.GetField("Year of Realease"),
                    }*/
                //}
            //}
        }
    }
}