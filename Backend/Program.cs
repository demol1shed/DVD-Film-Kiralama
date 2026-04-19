using System;
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

        return "backend'e veri girisi basarili";
    }
}