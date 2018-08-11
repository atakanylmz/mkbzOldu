using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace denemeMakbuz
{
    public partial class siraNoAyarlar : Form
    {
        public siraNoAyarlar()
        {
            InitializeComponent();
        }

        private void kaydetBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int secilen = pcKodCmb.SelectedIndex;
                string pc;
                switch (secilen)
                {
                    case 0:
                        pc = "A";
                        break;
                    case 1:
                        pc = "B";
                        break;
                    case 2:
                        pc = "C";
                        break;
                    case 3:
                        pc = "D";
                        break;
                    case 4:
                        pc = "E";
                        break;
                    case 5:
                        pc = "F";
                        break;

                    default:
                        pc = "A";
                        break;
                }
                int sira = Convert.ToInt32(siraTxt.Text);
                string sira_s = sira.ToString();
                string kullanici = genelKullaniciTxt.Text;
                if (sira < 0)
                    MessageBox.Show("Negatif Sıra No Olamaz!");
                else
                {
                    FileStream fs1 = new FileStream("kullanici.txt", FileMode.Open, FileAccess.Write);
                    StreamWriter kullaniciYazici = new StreamWriter(fs1, Encoding.GetEncoding("iso-8859-9"));
                    kullaniciYazici.WriteLine(kullanici);
                    kullaniciYazici.Close();

                    FileStream fs2 = new FileStream("pc.txt", FileMode.Open, FileAccess.Write);
                    StreamWriter pcYazici = new StreamWriter(fs2, Encoding.GetEncoding("iso-8859-9"));
                    pcYazici.WriteLine(pc);
                    pcYazici.Close();

                    FileStream fs3 = new FileStream("sira.txt", FileMode.Open, FileAccess.Write);
                    StreamWriter siraYazici = new StreamWriter(fs3, Encoding.GetEncoding("iso-8859-9"));
                    siraYazici.WriteLine(sira_s);
                    siraYazici.Close();
                    Form1 f1 = new Form1();
                    f1.Show();
                    this.Hide();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata!");
            }

        }
        private void sadeceSayiGirAyarlar(KeyPressEventArgs e1)
        {
            e1.Handled = !char.IsDigit(e1.KeyChar) && !char.IsControl(e1.KeyChar);

        }

        private void siraNoAyarlar_Load(object sender, EventArgs e)
        {
            FileStream fs1 = new FileStream("pc.txt", FileMode.Open, FileAccess.Read);
            StreamReader pcOkuyucu=new StreamReader(fs1, Encoding.GetEncoding("iso-8859-9"));
            string pcKod = pcOkuyucu.ReadLine();
            fs1.Close();
            pcOkuyucu.Close();
            pcKodCmb.SelectedItem = pcKod;
            FileStream fs2 = new FileStream("sira.txt", FileMode.Open, FileAccess.Read);
            StreamReader siraOkuyucu = new StreamReader(fs2, Encoding.GetEncoding("iso-8859-9"));
            string sira = siraOkuyucu.ReadLine();
            siraTxt.Text = sira;
            fs2.Close();
            siraOkuyucu.Close();
            FileStream fs3 = new FileStream("kullanici.txt", FileMode.Open, FileAccess.Read);
            StreamReader kullaniciOkuyucu = new StreamReader(fs3, Encoding.GetEncoding("iso-8859-9"));
            string kullanici = kullaniciOkuyucu.ReadLine();
            genelKullaniciTxt.Text = kullanici;
            fs3.Close();
            kullaniciOkuyucu.Close();
        }

        private void siraNoAyarlar_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall)
            {
                DialogResult dialog = MessageBox.Show("Programı Kapatmak İstiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else if (dialog == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void siraTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            sadeceSayiGirAyarlar(e);
        }
    }
}
