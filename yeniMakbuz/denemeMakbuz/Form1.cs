using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Print objelerinin
// bulundugu kutuphane
using System.Drawing.Printing;

using System.IO;
namespace denemeMakbuz
{
    public partial class Form1 : Form
    {
        PrintDocument pDoc;
        TutarIslem tutarIslemler;
        public Form1()
        {
            InitializeComponent();
            pDoc = new PrintDocument();
            // Print event'i yaratiliyor.
            dosyadanOku();
            pDoc.PrintPage += new PrintPageEventHandler(pDoc_Yazdir);
            tutarIslemler = new TutarIslem();

            string gun = DateTime.Now.Day.ToString();
            string ay = DateTime.Now.Month.ToString();
            string yil = DateTime.Now.Year.ToString();
            gunLbl.Text = gun;
            ayLbl.Text = ay;
            yilLbl.Text = yil;
        }
        decimal tl;
        int x = 0, y = 0;
        int aylar = 0;
        string[] yeniNev;
        string sira;
        string pcKod;
        private void dosyadanOku()
        {
            FileStream fs1 = new FileStream("pc.txt", FileMode.Open, FileAccess.Read);
            StreamReader pcOkuyucu = new StreamReader(fs1,Encoding.GetEncoding("iso-8859-9"));
            pcKod = pcOkuyucu.ReadLine();
            fs1.Close();
            pcOkuyucu.Close();
            cihazKodLbl.Text = pcKod;
            FileStream fs2 = new FileStream("sira.txt", FileMode.Open, FileAccess.Read);
            StreamReader siraOkuyucu = new StreamReader(fs2, Encoding.GetEncoding("iso-8859-9"));
            sira = siraOkuyucu.ReadLine();
            int sira_i = Convert.ToInt32(sira);
            sira = sira_i.ToString();
            if (sira_i < 10)
                sira = "0000"+sira;
            else if (sira_i < 100)
                sira = "000" + sira;
            else if (sira_i < 1000)
                sira = "00" + sira;
            else if (sira_i < 10000)
                sira = "0" + sira;

            siraNoLbl.Text = sira;
            fs2.Close();
            siraOkuyucu.Close();
        }

        private void pDoc_Yazdir(object sender, PrintPageEventArgs e)
        {
            // Pixel degil Milimetre kullanicahiz
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;

            // yazdirmada kullanilacak bir font olusturalim.
            Font aFont = new System.Drawing.Font("Arial", 11);

            String adSoyad = adSoyadTxt.Text;
            String apartman = apartmanAdiTxt.Text;
            String daireNo = daireNoTxt.Text;
            String nev = nevTxt.Text;
            String yonetici = yoneticiTxt.Text;

            dosyadanOku();

            //     String tarih = DateTime.Now.ToString("dd/MM/yyyy");
            int gunSayisal = DateTime.Now.Day;
            int aySayisal = DateTime.Now.Month;

            String gun,ay;
            if (gunSayisal < 10)
                gun = "0" + gunSayisal.ToString();
            else
                gun = gunSayisal.ToString();

            if (aySayisal < 10)
                ay = "0" + aySayisal.ToString();
            else
                ay = aySayisal.ToString();

            String yil = DateTime.Now.Year.ToString();

            int boyut = nev.Length;
            char[] t = new char[boyut];
            t = nev.ToCharArray();
            Nev nev1 = new Nev();
            yeniNev = nev1.nevSatirAyarla(nev);


            // stringi pDoc nesnemize yazdiralim.
            // string olarak "Deneme" verdik.
            // renk olarak brushes.black verdik ve X,Y olarak noktalarimizi belirttik.
            // ben genelde point kullanmaktan yana degilimdir gerci
            // bu yuzden tanimlamayi pointsiz yapalim.

            Image aImg = Image.FromFile("bosTahsilatMakbuzu.png");

            // Resim ekleme sol'dan 10 mm, yukardan 0 mm atliyarak
            // resmi resize etmek isterseniz bunuda bunuda
            // genislik 193 mm yukseklik 146 mm olarak atadik.
            e.Graphics.DrawImage(aImg, 10, 0,200,148);
            e.Graphics.DrawString(adSoyad, aFont, Brushes.Black, 58, 41);
            e.Graphics.DrawString(apartman, aFont, Brushes.Black, 58, 47);
            e.Graphics.DrawString(daireNo, aFont, Brushes.Black, 58, 54);

            e.Graphics.DrawString(sira, aFont, Brushes.Red, 148, 32);
            e.Graphics.DrawString(pcKod, aFont, Brushes.Red, 140, 32);

            e.Graphics.DrawString(gun, aFont, Brushes.Black, 166, 54);
            e.Graphics.DrawString(ay, aFont, Brushes.Black, 175, 54);
            e.Graphics.DrawString(yil, aFont, Brushes.Black, 184, 54);

            string yaziylaTutar = "#" + tutarIslemler.yaziyaCevir(tl) + "#";

            e.Graphics.DrawString(yaziylaTutar, aFont, Brushes.Black, 30, 109);

            e.Graphics.DrawString(yonetici, aFont, Brushes.Black, 30, 116);

            e.Graphics.DrawString(tl.ToString(), aFont, Brushes.Black, 156, 104);
            int a = 15;
            e.Graphics.DrawString(yeniNev[0], aFont, Brushes.Black, a, 72);
            e.Graphics.DrawString(yeniNev[1], aFont, Brushes.Black, a, 77);
            e.Graphics.DrawString(yeniNev[2], aFont, Brushes.Black, a, 83);
            e.Graphics.DrawString(yeniNev[3], aFont, Brushes.Black, a, 88);
            e.Graphics.DrawString(yeniNev[4], aFont, Brushes.Black, a, 93);
            e.Graphics.DrawString(yeniNev[5], aFont, Brushes.Black, a, 99);



            if (ocakChk.Checked == true)
            {
                aylar++;
                ayKoordinat();
                e.Graphics.DrawString("OCAK", aFont, Brushes.Black, x, y);
                e.Graphics.DrawString(tutar[1].ToString(), aFont, Brushes.Black, x1, y1);
            }
            if (subatChk.Checked == true)
            {
                aylar++;
                ayKoordinat();
                e.Graphics.DrawString("ŞUBAT", aFont, Brushes.Black, x, y);
                e.Graphics.DrawString(tutar[2].ToString(), aFont, Brushes.Black, x1, y1);
            }
            if (martChk.Checked == true)
            {
                aylar++;
                ayKoordinat();
                e.Graphics.DrawString("MART", aFont, Brushes.Black, x, y);
                e.Graphics.DrawString(tutar[3].ToString(), aFont, Brushes.Black, x1, y1);
            }
            if (nisanChk.Checked == true)
            {
                aylar++;
                ayKoordinat();
                e.Graphics.DrawString("NİSAN", aFont, Brushes.Black, x, y);
                e.Graphics.DrawString(tutar[4].ToString(), aFont, Brushes.Black, x1, y1);
            }
            if (mayisChk.Checked == true)
            {
                aylar++;
                ayKoordinat();
                e.Graphics.DrawString("MAYIS", aFont, Brushes.Black, x, y);
                e.Graphics.DrawString(tutar[5].ToString(), aFont, Brushes.Black, x1, y1);
            }
            if (haziranChk.Checked == true)
            {
                aylar++;
                ayKoordinat();
                e.Graphics.DrawString("HAZİRAN", aFont, Brushes.Black, x, y);
                e.Graphics.DrawString(tutar[6].ToString(), aFont, Brushes.Black, x1, y1);
            }
            if (temmuzChk.Checked == true)
            {
                aylar++;
                ayKoordinat();
                e.Graphics.DrawString("TEMMUZ", aFont, Brushes.Black, x, y);
                e.Graphics.DrawString(tutar[7].ToString(), aFont, Brushes.Black, x1, y1);
            }
            if (agustosChk.Checked == true)
            {
                aylar++;
                ayKoordinat();
                e.Graphics.DrawString("AĞUSTOS", aFont, Brushes.Black, x, y);
                e.Graphics.DrawString(tutar[8].ToString(), aFont, Brushes.Black, x1, y1);
            }
            if (eylulChk.Checked == true)
            {
                aylar++;
                ayKoordinat();
                e.Graphics.DrawString("EYLÜL", aFont, Brushes.Black, x, y);
                e.Graphics.DrawString(tutar[9].ToString(), aFont, Brushes.Black, x1, y1);
            }
            if (ekimChk.Checked == true)
            {
                aylar++;
                ayKoordinat();
                e.Graphics.DrawString("EKİM", aFont, Brushes.Black, x, y);
                e.Graphics.DrawString(tutar[10].ToString(), aFont, Brushes.Black, x1, y1);
            }
            if (kasimChk.Checked == true)
            {
                aylar++;
                ayKoordinat();
                e.Graphics.DrawString("KASIM", aFont, Brushes.Black, x, y);
                e.Graphics.DrawString(tutar[11].ToString(), aFont, Brushes.Black, x1, y1);
            }
            if (aralikChk.Checked == true)
            {
                aylar++;
                ayKoordinat();
                e.Graphics.DrawString("ARALIK", aFont, Brushes.Black, x, y);
                e.Graphics.DrawString(tutar[12].ToString(), aFont, Brushes.Black, x1, y1);
            }
            aylar = 0;
            for (int i = 0; i < 5; i++)
            {
                yeniNev[i] = "";
            }
        }
        int x1, y1;
        private void ayKoordinat()
        {
            int a = 103, b = 72;
            if (aylar == 1)
            {
                x = a;
                y = b+1;
            }
            if (aylar == 2)
            {
                x = a+24;
                y = b+1;
            }
            if (aylar == 3)
            {
                x = a;
                y = b+6;
            }
            if (aylar == 4)
            {
                x = a+24;
                y = b+6;
            }
            if (aylar == 5)
            {
                x = a;
                y = b+11;
            }
            if (aylar == 6)
            {
                x = a+24;
                y = b+11;
            }
            if (aylar == 7)
            {
                x = a;
                y = b+17;
            }
            if (aylar == 8)
            {
                x = a+24;
                y = b+17;
            }
            if (aylar == 9)
            {
                x = a;
                y = b+22;
            }
            if (aylar == 10)
            {
                x = a+24;
                y = b+22;
            }
            if (aylar == 11)
            {
                x = a;
                y = b+27;
            }
            if (aylar == 12)
            {
                x = a+24;
                y = b+27;
            }
            x1 = x + 50;
            if (aylar % 2 == 0)
                x1 = x + 45;
            y1 = y;
        }
        private void yazdirBtn_Click(object sender, EventArgs e)
        {
            try
            {
               
                tl = tutar[0];
                
                // Print Dialog olusturdugumuz zaman
                PrintDialog apDialog = new PrintDialog();

                // Hangi dokumana bagli oldugunu seceriz.
                apDialog.Document = pDoc;
                PrintPreviewDialog pdlg = new PrintPreviewDialog();
                pdlg.Document = pDoc;
                pdlg.ShowDialog();
                // ve islem okey ise


                if (apDialog.ShowDialog() == DialogResult.OK)
                {

                    // print islemi gerceklesir.
                    pDoc.Print();
                    StreamWriter siraYazici = File.CreateText("sira.txt");
                    int sira_i = Convert.ToInt32(sira);
                    sira_i++;
                    string sira_s = sira_i.ToString();

                    if (sira_i < 10)
                        sira_s = "0000" + sira_s;
                    else if (sira_i < 100)
                        sira_s = "000" + sira_s;
                    else if (sira_i < 1000)
                        sira_s = "00" + sira_s;
                    else if (sira_i < 10000)
                        sira_s = "0" + sira_s;
                    siraNoLbl.Text = sira_s;
                    siraYazici.WriteLine(sira_s);
                    siraYazici.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Tutarı sayısal bir değer giriniz!");
            }
        }
        siraNoAyarlar siraForm;
        private void siraNoAyarBtn_Click(object sender, EventArgs e)
        {
            siraForm = new siraNoAyarlar();
            siraForm.Show();
            this.Hide();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall)
            {
                DialogResult dialog = MessageBox.Show("Programı Kapatmak İstiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else if(dialog==DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void ocakChk_CheckedChanged(object sender, EventArgs e)
        {
            if (ocakChk.Checked == true)
            {
                ayBirTutarTxt.Visible = true;
            }
            else
            {
                ayBirTutarTxt.Visible = false;
            }
        }

        private void subatChk_CheckedChanged(object sender, EventArgs e)
        {
            if (subatChk.Checked == true)
            {
                ayIkiTutarTxt.Visible = true;
            }
            else
            {
                ayIkiTutarTxt.Visible = false;
            }
        }

        private void martChk_CheckedChanged(object sender, EventArgs e)
        {
            if (martChk.Checked == true)
            {
                ayUcTutarTxt.Visible = true;
            }
            else
            {
                ayUcTutarTxt.Visible = false;
            }
        }

        private void nisanChk_CheckedChanged(object sender, EventArgs e)
        {

            if (nisanChk.Checked == true)
            {
                ayDortTutarTxt.Visible = true;
            }
            else
            {
                ayDortTutarTxt.Visible = false;
            }
        }

        private void mayisChk_CheckedChanged(object sender, EventArgs e)
        {
            if (mayisChk.Checked == true)
            {
                ayBesTutarTxt.Visible = true;
            }
            else
            {
                ayBesTutarTxt.Visible = false;
            }
        }

        private void haziranChk_CheckedChanged(object sender, EventArgs e)
        {
            if (haziranChk.Checked == true)
            {
                ayAltiTutarTxt.Visible = true;
            }
            else
            {
                ayAltiTutarTxt.Visible = false;
            }
        }

        private void temmuzChk_CheckedChanged(object sender, EventArgs e)
        {
            if (temmuzChk.Checked == true)
            {
                ayYediTutarTxt.Visible = true;
            }
            else
            {
                ayYediTutarTxt.Visible = false;
            }
        }

        private void agustosChk_CheckedChanged(object sender, EventArgs e)
        {
            if (agustosChk.Checked == true)
            {
                aySekizTutarTxt.Visible = true;
            }
            else
            {
                aySekizTutarTxt.Visible = false;
            }
        }

        private void eylulChk_CheckedChanged(object sender, EventArgs e)
        {
            if (eylulChk.Checked == true)
            {
                ayDokuzTutarTxt.Visible = true;
            }
            else
            {
                ayDokuzTutarTxt.Visible = false;
            }
        }

        private void ekimChk_CheckedChanged(object sender, EventArgs e)
        {
            if (ekimChk.Checked == true)
            {
                ayOnTutarTxt.Visible = true;
            }
            else
            {
                ayOnTutarTxt.Visible = false;
            }
        }

        private void kasimChk_CheckedChanged(object sender, EventArgs e)
        {
            if (kasimChk.Checked == true)
            {
                ayOnbirTutarTxt.Visible = true;
            }
            else
            {
                ayOnbirTutarTxt.Visible = false;
            }
        }
        private void aralikChk_CheckedChanged(object sender, EventArgs e)
        {
            if (aralikChk.Checked == true)
            {
                ayOnikiTutarTxt.Visible = true;
            }
            else
            {
                ayOnikiTutarTxt.Visible = false;
            }
        }

        private void ayBirTutarTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            sadeceSayiGir(e);
           
        }

        private void ayIkiTutarTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            sadeceSayiGir(e);
        }

        private void ayUcTutarTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            sadeceSayiGir(e);
        }

        private void ayDortTutarTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            sadeceSayiGir(e);
        }

        private void ayBesTutarTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            sadeceSayiGir(e);
        }

        private void ayAltiTutarTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            sadeceSayiGir(e);
        }

        private void ayYediTutarTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            sadeceSayiGir(e);
        }

        private void aySekizTutarTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            sadeceSayiGir(e);
        }

        private void ayDokuzTutarTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            sadeceSayiGir(e);
        }

        private void ayOnTutarTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            sadeceSayiGir(e);
        }

        private void ayOnbirTutarTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            sadeceSayiGir(e);
        }

        private void ayOnikiTutarTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            sadeceSayiGir(e);
        }
        int[] tutar;
        private void Form1_Load(object sender, EventArgs e)
        {
            tutar = new int[13];
            for (int i = 1; i < 13; i++)
            {
                tutar[i] = 0;
            }
            FileStream fs = new FileStream("kullanici.txt", FileMode.Open, FileAccess.Read);
            StreamReader kullaniciOkuyucu = new StreamReader(fs, Encoding.GetEncoding("iso-8859-9"));
            string kullanici = kullaniciOkuyucu.ReadLine();
            yoneticiTxt.Text = kullanici;
            fs.Close();
            kullaniciOkuyucu.Close();
        }

        private void ayBirTutarTxt_KeyUp(object sender, KeyEventArgs e)
        {
            int tl;
            string t = ayBirTutarTxt.Text;
            if (t == "" || t == null)
                tl = 0;
            else
                tl = Convert.ToInt32(t);
            tutar[1] = tl;
            toplamTutarHesapla();
            yaziylaTutarDoldur();
        }

        private void ayIkiTutarTxt_KeyUp(object sender, KeyEventArgs e)
        {

            int tl;
            string t = ayIkiTutarTxt.Text;
            if (t == "" || t == null)
                tl = 0;
            else
                tl = Convert.ToInt32(t);
            tutar[2] = tl;
            toplamTutarHesapla();
            yaziylaTutarDoldur();

        }

        private void ayUcTutarTxt_KeyUp(object sender, KeyEventArgs e)
        {
            int tl;
            string t = ayUcTutarTxt.Text;
            if (t == "" || t == null)
                tl = 0;
            else
                tl = Convert.ToInt32(t);
            tutar[3] = tl;
            toplamTutarHesapla();
            yaziylaTutarDoldur();

        }

        private void ayDortTutarTxt_KeyUp(object sender, KeyEventArgs e)
        {
            int tl;
            string t = ayDortTutarTxt.Text;
            if (t == "" || t == null)
                tl = 0;
            else
                tl = Convert.ToInt32(t);
            tutar[4] = tl;
            toplamTutarHesapla();
            yaziylaTutarDoldur();

        }

        private void ayBesTutarTxt_KeyUp(object sender, KeyEventArgs e)
        {
            int tl;
            string t = ayBesTutarTxt.Text;
            if (t == "" || t == null)
                tl = 0;
            else
                tl = Convert.ToInt32(t);
            tutar[5] = tl;
            toplamTutarHesapla();
            yaziylaTutarDoldur();

        }

        private void ayAltiTutarTxt_KeyUp(object sender, KeyEventArgs e)
        {
            int tl;
            string t = ayAltiTutarTxt.Text;
            if (t == "" || t == null)
                tl = 0;
            else
                tl = Convert.ToInt32(t);
            tutar[6] = tl;
            toplamTutarHesapla();
            yaziylaTutarDoldur();

        }

        private void ayYediTutarTxt_KeyUp(object sender, KeyEventArgs e)
        {
            int tl;
            string t = ayYediTutarTxt.Text;
            if (t == "" || t == null)
                tl = 0;
            else
                tl = Convert.ToInt32(t);
            tutar[7] = tl;
            toplamTutarHesapla();
            yaziylaTutarDoldur();

        }

        private void aySekizTutarTxt_KeyUp(object sender, KeyEventArgs e)
        {
            int tl;
            string t = aySekizTutarTxt.Text;
            if (t == "" || t == null)
                tl = 0;
            else
                tl = Convert.ToInt32(t);
            tutar[8] = tl;
            toplamTutarHesapla();
            yaziylaTutarDoldur();

        }

        private void ayDokuzTutarTxt_KeyUp(object sender, KeyEventArgs e)
        {
            int tl;
            string t = ayDokuzTutarTxt.Text;
            if (t == "" || t == null)
                tl = 0;
            else
                tl = Convert.ToInt32(t);
            tutar[9] = tl;
            toplamTutarHesapla();
            yaziylaTutarDoldur();

        }

        private void ayOnTutarTxt_KeyUp(object sender, KeyEventArgs e)
        {
            int tl;
            string t = ayOnTutarTxt.Text;
            if (t == "" || t == null)
                tl = 0;
            else
                tl = Convert.ToInt32(t);
            tutar[10] = tl;
            toplamTutarHesapla();
            yaziylaTutarDoldur();

        }

        private void ayOnbirTutarTxt_KeyUp(object sender, KeyEventArgs e)
        {
            int tl;
            string t = ayOnbirTutarTxt.Text;
            if (t == "" || t == null)
                tl = 0;
            else
                tl = Convert.ToInt32(t);
            tutar[11] = tl;
            toplamTutarHesapla();
            yaziylaTutarDoldur();

        }

        private void ayOnikiTutarTxt_KeyUp(object sender, KeyEventArgs e)
        {
            int tl;
            string t = ayOnikiTutarTxt.Text;
            if (t == "" || t == null)
                tl = 0;
            else
                tl = Convert.ToInt32(t);
            tutar[12] = tl;
            toplamTutarHesapla();
            yaziylaTutarDoldur();
        }
        private void yaziylaTutarDoldur()
        {
            yaziylaTutarLbl.Text = "#"+tutarIslemler.yaziyaCevir(tutar[0])+"#";
        }

        private void toplamTutarHesapla()
        {
            tutar[0] = 0;
            for (int i = 1; i < 13; i++)
            {
                tutar[0] += tutar[i];
            }
            toplamTutarLbl.Text = tutar[0].ToString();
        }
        private void sadeceSayiGir(KeyPressEventArgs e1)
        {
            e1.Handled = !char.IsDigit(e1.KeyChar) && !char.IsControl(e1.KeyChar);
           
        }

    }
}
