namespace DvdOtomasyonu
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            /*try
            {
                string testMesaji = "";
                string sunucuCevabi = SharedLib.ConnectTcp.SendData("10.112.121.96", 5000, testMesaji);
                MessageBox.Show("Sunucu Diyor ki: " + sunucuCevabi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sunucuya baglanirken bir terslik oldu! Hata: " + ex.Message);
            }
            */
            Application.Run(new Form1());  // suanlik server kapali diye test edebilmek icin direkt filmler sayfasina gonderiyorum. Normalde buraya Form1 gelmeli.
        }
    }
}