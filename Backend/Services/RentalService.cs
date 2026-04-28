using Backend.Context;
using Backend.Models;
using SharedLib;
using System;
using System.Linq;
using System.Text.Json;

namespace Backend.Services
{
    public class RentalService
    {
        public uint RentMovie(RentalRequest request)
        {
            using (var db = new DvdContext())
            {
                var movie = db.Movies.FirstOrDefault(m => m.Id == request.MovieId);
                if (movie == null) return ReqCodes.ErrorRent;

                // Aynı filmi iade etmeden tekrar kiralayamasın
                bool alreadyRented = db.Rentals.Any(r => r.Username == request.Username && r.MovieId == request.MovieId && !r.IsReturned);
                if (alreadyRented) return ReqCodes.ErrorRent;

                var rental = new Rental
                {
                    Username = request.Username,
                    MovieId = request.MovieId,
                    RentDate = DateTime.Now,
                    IsReturned = false
                };

                // Eğer TotalBorrowCount'u modelde tutmaya devam ettiysen istatistikleri artırıyoruz
                movie.TotalBorrowCount++;
                movie.TimeNotBorrowed = DateTime.Now;

                db.Rentals.Add(rental);
                db.SaveChanges();

                Console.WriteLine($"[*] {request.Username} kullanıcısı {movie.MovieName} filmini kiraladı.");
                return ReqCodes.SuccessRent;
            }
        }

        public string GetRentedMovies(string username)
        {
            using (var db = new DvdContext())
            {
                // Kullanıcının kiraladığı filmleri MovieDTO'ya çevirirken Popularity yerine ImdbRating kullanıyoruz
                var rentedMovies = db.Rentals
                    .Where(r => r.Username == username && !r.IsReturned)
                    .Join(db.Movies, r => r.MovieId, m => m.Id, (r, m) => new MovieDTO
                    {
                        Id = m.Id,
                        MovieName = m.MovieName,
                        ReleaseYear = m.ReleaseDate,
                        Genre = m.Genre,
                        ImdbRating = m.ImdbRating // <-- Popularity yerine burası geldi
                    }).ToList();

                return JsonSerializer.Serialize(rentedMovies);
            }
        }
    }
}