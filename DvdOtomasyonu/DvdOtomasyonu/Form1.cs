namespace DvdOtomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // acilista karsimiza direkt giris yap ekrani gelsin diye buraya da asagidaki giris kodlarini ekledik
            panelKonteyner.Controls.Clear();
            ucGiris girisEkrani = new ucGiris();
            girisEkrani.Dock = DockStyle.Fill;
            panelKonteyner.Controls.Add(girisEkrani);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelKonteyner.Controls.Clear();  // panelin icindeki eskiyi siliyoruz

            ucGiris girisEkrani = new ucGiris();  // yeni ucGiris prefabindan bir tane uretiyoruz

            girisEkrani.Dock = DockStyle.Fill;  // panelin icini tam olarak doldursun diye

            panelKonteyner.Controls.Add(girisEkrani);  // prefabı panelin icine ekledik


        }

        private void button2_Click(object sender, EventArgs e)  // kayit ol butonu icinde ayni seyleri yapiyoruz
        {
            panelKonteyner.Controls.Clear();
            
            ucKayit kayitEkrani = new ucKayit();
            
            kayitEkrani.Dock = DockStyle.Fill;
            
            panelKonteyner.Controls.Add(kayitEkrani);
        }
    }
}
