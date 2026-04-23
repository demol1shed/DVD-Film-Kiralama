using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.Json; // JSON paketlemesi icin eklendi
using SharedLib; // SignInRequest ve ConnectTcp siniflarini kullanmak icin eklendi

namespace DvdOtomasyonu
{
    public partial class ucKayit : UserControl
    {
        public ucKayit()
        {
            InitializeComponent();
        }

        private void ucKayit_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SignInRequest kayitIstegi = new SignInRequest
            {
                RequestType = ReqCodes.CodeRegister,
                Username = textBox1.Text, 
                Password = textBox2.Text  
            };

            // Paketi JSON formatina ceviriyoruz ki sunucu anlayabilsin
            string jsonFormatindaVeri = JsonSerializer.Serialize(kayitIstegi);
            
            try
            {
                string sunucudanGelenCevap = ConnectTcp.SendData("10.112.121.96", 5000, jsonFormatindaVeri);

                if (uint.TryParse(sunucudanGelenCevap, out uint cevapKodu))
                {
                    if(cevapKodu == ReqCodes.Ok)
                    {
                        MessageBox.Show("Kayıt başarılı! Şimdi giriş yapabilirsiniz.");
                    }
                    else if(cevapKodu == ReqCodes.ErrorRegister)
                    {
                        MessageBox.Show("Bu kullanıcı adı zaten alınmış!");
                    }
                }
            } 
            catch (Exception ex)
            {
                MessageBox.Show("Sunucuya bağlanırken bir terslik oldu! Hata: " + ex.Message);
            }
        }
    }
}
