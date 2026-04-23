using Backend.Context;
using Backend.Models;
using SharedLib;

namespace Backend.Services
{
    public class AuthService
    {
        public uint AuthUser(SignInRequest request)
        {
            string hashedPass = DataHasher.HashSha256(request.Password);
            Console.WriteLine($"hashli req sifre: {hashedPass}, {request.Username}");

            using (var db = new DvdContext())
            {
                var admin = db.Admins.FirstOrDefault(a => a.Username == request.Username && a.Password == hashedPass);
                Console.WriteLine($"hashli db sifre: {admin.Password}, {admin.Username}");
                Console.WriteLine(hashedPass == admin.Password);
                if(admin != null)
                {
                    return ReqCodes.Ok;
                }
                return ReqCodes.ErrorSignIn;
            }
        }

        public uint RegisterUser(SignInRequest request)
        {
            using (var db = new DvdContext())
            {
                if(db.Admins.Any(a => a.Username == request.Username))
                {
                    return ReqCodes.ErrorRegister;
                }

                string hashedPass = DataHasher.HashSha256(request.Password);

                db.Admins.Add(new Admin
                {
                    Username = request.Username,
                    Password = hashedPass
                });

                db.SaveChanges();
                Console.WriteLine("[*] Yeni kullanici kaydedildi");
                return ReqCodes.Ok;
            }
        }
    }
}