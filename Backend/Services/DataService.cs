using Backend.Context;
using Backend.Models;
using SharedLib;
using System.Collections.Generic;
using System.Text.Json;

namespace Backend.Services
{
    public static class DataService
    {
        public static string RequestMovie(int id)
        {
            using (var db = new DvdContext())
            {
                var movie = db.Movies.FirstOrDefault(m => m.Id == id);

                if(movie != null)
                {
                    // Örnek bir dönüşüm bloğu
                    var movieDto = new MovieDTO
                    {
                        Id = movie.Id,
                        MovieName = movie.MovieName,
                        ReleaseYear = movie.ReleaseDate,
                        Genre = movie.Genre,
                        ImdbRating = movie.ImdbRating // Değişen kısım
                    };

                    return JsonSerializer.Serialize(movieDto);
                }

                return "[-] Hata: Film bulunamadi";
            }
        }
        public static string RequestMovie(string movieName)
        {
            using (var db = new DvdContext())
            {
                var movie = db.Movies.FirstOrDefault(m => m.MovieName.Contains(movieName));

                if(movie != null)
                {
                    // Örnek bir dönüşüm bloğu
                    var movieDto = new MovieDTO
                    {
                        Id = movie.Id,
                        MovieName = movie.MovieName,
                        ReleaseYear = movie.ReleaseDate,
                        Genre = movie.Genre,
                        ImdbRating = movie.ImdbRating // Değişen kısım
                    };
                    return JsonSerializer.Serialize(movieDto);
                }

                return "[-] Hata: Film bulunamadi";
            }
        }

        public static string RequestAllMovies()
        {
            using (var db = new DvdContext())
            {
                // Örnek bir dönüşüm bloğu
                var movieList = db.Movies.Select(movie => new MovieDTO
                {
                    Id = movie.Id,
                    MovieName = movie.MovieName,
                    ReleaseYear = movie.ReleaseDate,
                    Genre = movie.Genre,
                    ImdbRating = movie.ImdbRating // Değişen kısım
                }).ToList();

                return JsonSerializer.Serialize(movieList);
            }
        }
    }
}