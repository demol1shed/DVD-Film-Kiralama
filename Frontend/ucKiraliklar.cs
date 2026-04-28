using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.Json;
using SharedLib;

namespace DvdOtomasyonu
{
    public partial class ucKiraliklar : UserControl
    {
        public ucKiraliklar()
        {
            InitializeComponent();

            // Ekran açıldığı an sunucudan kullanıcının kiraladığı filmleri istiyoruz
            RentalRequest istek = new RentalRequest
            {
                RequestType = ReqCodes.CodeGetRentedMovies,
                Username = Program.AktifKullanici,
                MovieId = 0 // Sadece listeleme yapacağımız için ID'ye gerek yok
            };

            string jsonIstek = JsonSerializer.Serialize(istek);

            try
            {
                // İsteği fırlat
                string jsonCevap = ConnectTcp.SendData("10.112.121.96", 5000, jsonIstek);

                // Gelen veriyi tabloya bas
                if (!string.IsNullOrEmpty(jsonCevap) && !jsonCevap.Contains("Hata") && jsonCevap != ReqCodes.Error.ToString())
                {
                    var kiralikFilmler = JsonSerializer.Deserialize<List<MovieDTO>>(jsonCevap);
                    dataGridView1.DataSource = kiralikFilmler;

                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kiraladığın filmler getirilirken bir terslik oldu: " + ex.Message);
            }
        }
    }
}