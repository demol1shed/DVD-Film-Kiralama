using System;
using System.Text.Json;
using Backend.Services;
using SharedLib;

class Program
{
    static void Main()
    {
        ConnectTcp.StartServer(5000, ProcessIncomingRequest);
    }

    static string ProcessIncomingRequest(string jsonData)
    {
        Console.WriteLine("[*] Info: Json talebi geldi");

        try
        {
            SignInRequest? request = JsonSerializer.Deserialize<SignInRequest>(jsonData);
            if(request == null) return "[-] Hata: Gecersiz format hatasi";
            Console.WriteLine(request);
            AuthService authService = new AuthService();
            if(request.IsSignIn == true)
            {
                return authService.AuthUser(request);
            }
            else
            {
                return authService.RegisterUser(request);
            }
            
        }catch (Exception ex)
        {
            return $"[-] Hata: Sunucu hatasi - {ex.Message}";
        }
    }
}