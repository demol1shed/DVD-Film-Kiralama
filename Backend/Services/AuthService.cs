using Backend.Context;
using Backend.Models;
using SharedLib;

namespace Backend.Services
{
    public class AuthService
    {
        public string AuthUser(SignInRequest request)
        {
            string hashedPass = DataHasher.HashSha256(request.Password);

            using (var db = new DvdContext())
            {
                var admin = db.Admins.FirstOrDefault(a => a.Username == request.Username && a.Password == hashedPass);

                if(admin != null)
                {
                    return "[+] BASARI";
                }
                return "[-] Kullanici adi veya sifre yanlis";
            }
        }

        public string RegisterUser(SignInRequest request)
        {
            using (var db = new DvdContext())
            {
                if(db.Admins.Any(a => a.Username == request.Username))
                {
                    return "[-] Hata: Bu kullanici adi zaten kullaniliyor";
                }

                string hashedPass = DataHasher.HashSha256(request.Password);

                db.Admins.Add(new Admin
                {
                    Username = request.Username,
                    Password = hashedPass
                });

                db.SaveChanges();
                Console.WriteLine("[*] Yeni kullanici kaydedildi");
                return "Kayit basarili";
            }
        }
    }
}