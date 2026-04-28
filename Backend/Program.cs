using System;
using System.Text.Json;
using Backend.Services;
using SharedLib;

class Program
{
    static void Main()
    {
        // Seeder'ı başlangıçta çalıştırıyoruz
        MovieSeeder.Seed("/home/arda/Documents/Projects/GorselProje/filmler.csv");
        ConnectTcp.StartServer(5000, ProcessIncomingRequest);
    }

    // Dönüş tipini string yaptık ki hem kodları hem de JSON listelerini yollayabilelim
    static string ProcessIncomingRequest(string jsonData)
    {
        Console.WriteLine("[*] Info: Json talebi geldi");

        try
        {
            using JsonDocument doc = JsonDocument.Parse(jsonData);
            if (!doc.RootElement.TryGetProperty("RequestType", out JsonElement reqTypeElement))
            {
                return ReqCodes.Error.ToString();
            }

            uint requestType = reqTypeElement.GetUInt32();
            
            // --- 1. KULLANICI İŞLEMLERİ ---
            if (requestType == ReqCodes.CodeSignIn || requestType == ReqCodes.CodeRegister)
            {
                SignInRequest? request = JsonSerializer.Deserialize<SignInRequest>(jsonData);
                if(request == null) return ReqCodes.Error.ToString();

                AuthService authService = new AuthService();
                if (requestType == ReqCodes.CodeSignIn) return authService.AuthUser(request).ToString();
                if (requestType == ReqCodes.CodeRegister) return authService.RegisterUser(request).ToString();
            }
            
            // --- 2. KİRALAMA İŞLEMLERİ ---
            else if (requestType == ReqCodes.CodeRentMovie)
            {
                RentalRequest? request = JsonSerializer.Deserialize<RentalRequest>(jsonData);
                if(request == null) return ReqCodes.Error.ToString();

                RentalService rentalService = new RentalService();
                return rentalService.RentMovie(request).ToString();
            }
            else if (requestType == ReqCodes.CodeGetRentedMovies)
            {
                RentalRequest? request = JsonSerializer.Deserialize<RentalRequest>(jsonData);
                if(request == null) return ReqCodes.Error.ToString();

                RentalService rentalService = new RentalService();
                // Bu metot zaten doğrudan JSON string dönüyor
                return rentalService.GetRentedMovies(request.Username); 
            }
            
            // --- 3. FİLM LİSTELEME İŞLEMLERİ (DataService Bağlantısı) ---
            else if (requestType == ReqCodes.CodeGetAllMovies)
            {
                // Tüm filmleri liste halinde JSON olarak döner
                return DataService.RequestAllMovies();
            }
            else if (requestType == ReqCodes.CodeGetMovieById || requestType == ReqCodes.CodeGetMovieByName)
            {
                MovieRequest? request = JsonSerializer.Deserialize<MovieRequest>(jsonData);
                if(request == null) return ReqCodes.Error.ToString();

                if (requestType == ReqCodes.CodeGetMovieById)
                    return DataService.RequestMovie((int)request.Id);
                
                if (requestType == ReqCodes.CodeGetMovieByName)
                    return DataService.RequestMovie(request.MovieName);
            }

            Console.WriteLine("[*] Beklenmeyen talep kodu");
            return ReqCodes.Error.ToString();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[-] Hata: Sunucu hatasi - {ex.Message}");
            return ReqCodes.Error.ToString();
        }
    }
}