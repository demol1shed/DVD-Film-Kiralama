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

            try{
                // Gelen string cevabı uint formatına (ReqCodes'a) dönüştürüyoruz
                if (uint.TryParse(sunucudanGelenCevap, out uint cevapKodu))
                {
                    if (cevapKodu == ReqCodes.Ok)
                    {
                        MessageBox.Show("Giriş başarılı, hoş geldiniz.");

                        this.ParentForm?.Hide(); 

                        AnaForms yeniAnaSayfa = new AnaForms(); 
                        yeniAnaSayfa.Show();
                    }
                    else if (cevapKodu == ReqCodes.ErrorSignIn)
                    {
                        MessageBox.Show("Giriş başarısız, lütfen bilgilerinizi kontrol edin.");
                    }
                    else 
                    {
                        MessageBox.Show("Sunucudan beklenmeyen bir durum kodu döndü: " + cevapKodu);
                    }
                }
                else
                {
                    MessageBox.Show("Sunucudan anlamsız bir veri geldi: " + sunucudanGelenCevap);
                }
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