using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Backend.Models
{
    public class Movie
    {
        [Key]
        public uint Id{get; set;}
        public required string MovieName{get; set;} // required = null olamaz
        public int ReleaseDate{get; set;}
        public required string Genre{get; set;} // required = null olamaz
        public uint TotalBorrowCount{get; set;}
        public DateTime TimeNotBorrowed{get; set;}

        public double Popularity
        {
            get
            {
                var timeInShelf = (DateTime.Now - TimeNotBorrowed).TotalDays;
                double logVal = Math.Log(timeInShelf + 1);

                // log degeri 0 dan buyukse odunc alim orani / log, degilse 0.
                return logVal > 0 ? TotalBorrowCount / logVal : 0;
            }
        }
    }
}
