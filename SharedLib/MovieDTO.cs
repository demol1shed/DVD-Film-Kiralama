namespace SharedLib
{
    public class MovieDTO
    {
        public required uint Id {get; set;}
        public required string MovieName {get; set;}
        public int ReleaseYear {get; set;}
        public required string Genre {get; set;}
        
        // Popularity yerine ImdbRating geldi
        public double ImdbRating {get; set;}
    }
}