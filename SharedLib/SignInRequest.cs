using System;

namespace SharedLib
{
    public class SignInRequest
    {
        public required bool IsSignIn {get; set;} // true ise giris, false ise kayit istegi
        public required string Username {get; set;}
        public required string Password {get; set;}   
    }
}