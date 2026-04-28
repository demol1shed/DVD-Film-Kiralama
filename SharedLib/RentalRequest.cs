namespace SharedLib
{
    public class RentalRequest
    {
        public required uint RequestType { get; set; }
        public required string Username { get; set; }
        public uint MovieId { get; set; }
    }
}