using SharedLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace DvdOtomasyonu
{
    public partial class ucFilmler : UserControl
    {
        public static List<MovieDTO> KiraladigimFilmler = new List<MovieDTO>();

        // Liste yukari da ki tum butonlar/kutular buraya erisebilsin
        List<MovieDTO> vitrinFilmleri;

        public ucFilmler()
        {
            InitializeComponent();

            // Backend'den tüm filmleri getirmesini istiyoruz
            MovieRequest istek = new MovieRequest
            {
                RequestType = ReqCodes.CodeGetAllMovies,
                Id = 0,
                MovieName = ""
            };

            string jsonIstek = JsonSerializer.Serialize(istek);

            try
            {
                // İsteği yollayıp JSON listesini alıyoruz
                string jsonCevap = ConnectTcp.SendData("10.112.121.96", 5000, jsonIstek);

                // Gelen JSON verisini C# listesine çevirip tablomuza basıyoruz
                if (!string.IsNullOrEmpty(jsonCevap) && !jsonCevap.Contains("Hata"))
                {
                    vitrinFilmleri = JsonSerializer.Deserialize<List<MovieDTO>>(jsonCevap);
                    dataGridView1.DataSource = vitrinFilmleri;

                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Filmler veritabanından çekilirken hata oluştu: " + ex.Message);
            }
        }

        // Arama kutusuna her harf girildiginde otomatik calisacak tetikleyici

        private void txtArama_TextChanged_1(object sender, EventArgs e)
        {
            // buyuk/kucuk harf icin ToLower
            string arananKelime = txtArama.Text.ToLower();

            // LINQ ile filtremeyi yapiyoruz: ID
            var filtrelenmisListe = vitrinFilmleri.Where(film =>
                film.MovieName.ToLower().Contains(arananKelime) ||
                film.Genre.ToLower().Contains(arananKelime) ||
                film.Id.ToString().Contains(arananKelime)
            ).ToList();

            // Tabloyu filtrelenmis yeni listeyle guncelliyoruz
            dataGridView1.DataSource = filtrelenmisListe;
        }

        private void kiraButton_Click(object sender, EventArgs e)
        {
            // Tablodan bir film seçilmiş mi diye kontrol ediyoruz
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Seçili satırdaki filmi alıyoruz
                MovieDTO seciliFilm = (MovieDTO)dataGridView1.SelectedRows[0].DataBoundItem;

                // Kiralama paketimizi güncel RentalRequest kalıbıyla hazırlıyoruz
                RentalRequest kiraIstegi = new RentalRequest
                {
                    RequestType = ReqCodes.CodeRentMovie,
                    Username = Program.AktifKullanici, // Hafızadaki aktif kullanıcıyı yolluyoruz
                    MovieId = seciliFilm.Id
                };

                string jsonIstek = JsonSerializer.Serialize(kiraIstegi);

                try
                {
                    // Sunucuya fırlat!
                    string cevap = ConnectTcp.SendData("10.112.121.96", 5000, jsonIstek);

                    if (uint.TryParse(cevap, out uint cevapKodu) && cevapKodu == ReqCodes.SuccessRent)
                    {
                        MessageBox.Show($"{seciliFilm.MovieName} başarıyla kiralandı! Kiraladıklarım sekmesinden görebilirsiniz.", "Başarılı");
                    }
                    else
                    {
                        MessageBox.Show("Kiralama başarısız! Bu filmi zaten kiralamış olabilirsiniz.", "Uyarı");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sunucuya ulaşılamadı: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Lütfen kiralamak için tablodan bir film seçin!", "Bilgi");
            }
        }
    }
}