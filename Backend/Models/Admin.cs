namespace Backend.Models
{
    public class Admin
    {
        public int Id {get; set;}
        public required string Username {get; set;}
        public required string Password{get; set;}
    }
}