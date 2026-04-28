using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SharedLib;

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

            vitrinFilmleri = new List<MovieDTO>
            {
                new MovieDTO { Id = 1, MovieName = "Yüzüklerin Efendisi", ReleaseYear = 2001, Genre = "Fantastik", Popularity = 9.8 },
                new MovieDTO { Id = 2, MovieName = "Matrix", ReleaseYear = 1999, Genre = "Bilim Kurgu", Popularity = 9.5 },
                new MovieDTO { Id = 3, MovieName = "G.O.R.A.", ReleaseYear = 2004, Genre = "Komedi", Popularity = 8.9 },
                new MovieDTO { Id = 4, MovieName = "Inception", ReleaseYear = 2010, Genre = "Bilim Kurgu", Popularity = 9.2 }
            };

            dataGridView1.DataSource = vitrinFilmleri;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
    }
}