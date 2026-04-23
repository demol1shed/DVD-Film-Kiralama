using SharedLib;

namespace SharedLib
{
    public class MovieRequest
    {
        public required uint RequestType {get; set;}
        public string MovieName {get; set;} = string.Empty;
        public uint Id {get; set;}
    }
}