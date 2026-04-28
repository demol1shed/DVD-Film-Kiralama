using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Rental
    {
        [Key]
        public int Id { get; set; }
        public required string Username { get; set; } // Hangi kullanıcı kiraladı
        public uint MovieId { get; set; }
        public DateTime RentDate { get; set; }
        public bool IsReturned { get; set; }
    }
}