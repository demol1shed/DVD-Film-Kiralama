using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.Json; // JSON paketlemesi icin eklendi
using SharedLib; 

namespace DvdOtomasyonu
{
    public partial class ucGiris : UserControl
    {
        public ucGiris()
        {
            InitializeComponent();
        }

        // Giris yap butonuna tıklandiginda calicacak kisim
        private void button1_Click(object sender, EventArgs e)
        {

            SignInRequest girisIstegi = new SignInRequest
            {
                RequestType = ReqCodes.CodeSignIn,
                Username = textBox1.Text,
                Password = textBox2.Text
            };

            // Paketi JSON'a ceviriyoruz
            string jsonFormatindaVeri = JsonSerializer.Serialize(girisIstegi);

            try
            {
                // Sunucuya gonderiyoruz ve cevabi aliyoruz
                string sunucudanGelenCevap = ConnectTcp.SendData("10.112.121.96", 5000, jsonFormatindaVeri);

                // Gelen cevabi ekranda mesaj kutusu olarak gosteriyoruz
                MessageBox.Show("Sunucu Diyor ki: " + sunucudanGelenCevap);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sunucuya baglanirken bir terslik oldu! Hata: " + ex.Message);
            }
        }

        private void ucGiris_Load(object sender, EventArgs e)
        {

        }
    }
}