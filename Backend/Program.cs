using System;
using System.Text.Json;
using SharedLib;

class Program
{
    static void Main()
    {
        ConnectTcp.StartServer(5000, ProcessIncomingRequest);
    }

    static string ProcessIncomingRequest(string jsonData)
    {
        Console.WriteLine("Json talebi geldi: " + jsonData);

        // TODO: json'u deserialize et, bilgileri hashle, db'den kontrol et.
        SignInRequest? signInInfo = JsonSerializer.Deserialize<SignInRequest>(jsonData);

        if(signInInfo == null)
        {
            return "null data geldi";
        }
        else
        {
            return $"gelen isim {signInInfo.Username}";
        }
    }
}