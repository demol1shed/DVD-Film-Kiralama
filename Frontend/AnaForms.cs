using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DvdOtomasyonu
{
    public partial class AnaForms : Form
    {
        public AnaForms()
        {
            InitializeComponent();

            // ana sayfanin acilisinda direkt filmler ekranini gosterelim diye buraya da asagidaki kodlari ekledik

            panelAnaKonteyner.Controls.Clear();

            ucFilmler filmlerEkrani = new ucFilmler();

            filmlerEkrani.Dock = DockStyle.Fill;

            panelAnaKonteyner.Controls.Add(filmlerEkrani);
        }

        private void filmButton_Click(object sender, EventArgs e)
        {
            panelAnaKonteyner.Controls.Clear();  // panelin icindeki eskiyi siliyoruz

            ucFilmler filmlerEkrani = new ucFilmler();  // yeni kullanici sahnesi olusturuyoruz

            filmlerEkrani.Dock = DockStyle.Fill;  // kullanici sahnesini panelin tamamina yayiyoruz

            panelAnaKonteyner.Controls.Add(filmlerEkrani);  // kullanici sahnesini panele ekliyoruz
        }

        private void kiraButton_Click(object sender, EventArgs e)  // ayni seyleri kiraladiklarimiz icin de yapiyoruz
        {
            panelAnaKonteyner.Controls.Clear();

            ucKiraliklar kiraliklarEkrani = new ucKiraliklar();

            kiraliklarEkrani.Dock = DockStyle.Fill;

            panelAnaKonteyner.Controls.Add(kiraliklarEkrani);
        }

        private void cikisButton_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
