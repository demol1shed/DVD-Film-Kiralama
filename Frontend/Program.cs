namespace DvdOtomasyonu
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        // Uygulama boyunca giriþ yapan kiþinin adýný tutacak global hafýzamýz
        public static string AktifKullanici = "";

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}