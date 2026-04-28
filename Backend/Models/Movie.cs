using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Movie
    {
        [Key]
        public uint Id{get; set;}
        public required string MovieName{get; set;} 
        public int ReleaseDate{get; set;}
        public required string Genre{get; set;} 
        public uint TotalBorrowCount{get; set;}
        public DateTime TimeNotBorrowed{get; set;}

        // Popularity hesaplaması yerine veritabanında tutulacak IMDb puanı
        public double ImdbRating {get; set;} 
    }
}