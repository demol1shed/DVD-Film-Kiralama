using System;
using System.Text.Json;
using Azure.Core;
using Backend.Services;
using SharedLib;

class Program
{
    static void Main()
    {
        ConnectTcp.StartServer(5000, ProcessIncomingRequest);
    }

    static uint ProcessIncomingRequest(string jsonData)
    {
        Console.WriteLine("[*] Info: Json talebi geldi");

        try
        {
            Console.WriteLine(jsonData);
            SignInRequest? request = JsonSerializer.Deserialize<SignInRequest>(jsonData);

            if(request == null)
            {
                Console.WriteLine("[-] Hata: Gecersiz format hatasi");
                return ReqCodes.Error;
            }
             
            AuthService authService = new AuthService();
            
            if(request.RequestType == ReqCodes.CodeSignIn)
            {
                return authService.AuthUser(request);
            }
            else if(request.RequestType == ReqCodes.CodeRegister)
            {
                return authService.RegisterUser(request);
            }
            else
            {
                Console.WriteLine("[*] Beklenmeyen talep kodu");
                return ReqCodes.Error;
            }
            
        }catch (Exception ex)
        {
            Console.WriteLine($"[-] Hata: Sunucu hatasi - {ex.Message}");
            return ReqCodes.Error;
        }
    }
}