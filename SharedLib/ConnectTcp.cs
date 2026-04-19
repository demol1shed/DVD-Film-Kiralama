using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SharedLib
{
    public static class ConnectTcp
    {
        /// <summary>
        /// Frontend icin veri gonderme metodu.
        /// </summary>
        /// <param name="ipAddr">Gonderilecek ip adresi</param>
        /// <param name="port">Ip adresindeki makinede acik olan dinleyici port</param>
        /// <param name="jsonData">Gonderilecek veri</param>
        /// <returns>Sunucunun verecegi yaniti bekler ve dondurur</returns>
        public static string SendData(string ipAddr, int port, string jsonData)
        {
            using TcpClient client = new TcpClient(ipAddr, port);
            using NetworkStream stream = client.GetStream();
            using StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            using StreamWriter writer = new StreamWriter(stream, Encoding.UTF8) {AutoFlush = true};

            writer.WriteLine(jsonData);

            return reader.ReadLine(); 
        }

        public static void StartServer(int port, Func<string, string> delegateFunc)
        {
            TcpListener server = new TcpListener(IPAddress.Any, port);
            server.Start();
            Console.WriteLine($"[*] Sunucu port {port} dinliyor");

            while (true)
            {
                using TcpClient client = server.AcceptTcpClient();
                using NetworkStream stream = client.GetStream();
                using StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                using StreamWriter writer = new StreamWriter(stream, Encoding.UTF8);

                string incomingJson = reader.ReadLine();

                if (!string.IsNullOrEmpty(incomingJson))
                {
                    string answer = delegateFunc(incomingJson);
                    writer.WriteLine(answer);
                } 
            }
        }
    }
}