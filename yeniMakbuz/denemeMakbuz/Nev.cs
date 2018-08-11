using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace denemeMakbuz
{
    class Nev
    {
        public string[] nevSatirAyarla(string nev)
        {
            string[] yeniNev = new string[6];
            for (int i = 0; i < 6; i++)
            {
                yeniNev[i] = "";
            }
            int boy = nev.Length;
            if (boy < 40)
            {
                yeniNev[0] = nev;
            }
            else if (boy < 80)
            {
                yeniNev[0] = nev.Substring(0, 40);
                yeniNev[1] = nev.Substring(40, boy - 40);
            }
            else if (boy < 120)
            {
                yeniNev[0] = nev.Substring(0, 40);
                yeniNev[1] = nev.Substring(40, 40);
                yeniNev[2] = nev.Substring(80, boy - 80);
            }
            else if (boy < 160)
            {
                yeniNev[0] = nev.Substring(0, 40);
                yeniNev[1] = nev.Substring(40, 40);
                yeniNev[2] = nev.Substring(80, 40);
                yeniNev[3] = nev.Substring(120, boy - 120);
            }
            else if(boy<200)
            {
                yeniNev[0] = nev.Substring(0, 40);
                yeniNev[1] = nev.Substring(40, 40);
                yeniNev[2] = nev.Substring(80, 40);
                yeniNev[3] = nev.Substring(120, 40);
                yeniNev[4] = nev.Substring(160, boy - 160);
            }
            else
            {
                yeniNev[0] = nev.Substring(0, 40);
                yeniNev[1] = nev.Substring(40, 40);
                yeniNev[2] = nev.Substring(80, 40);
                yeniNev[3] = nev.Substring(120, 40);
                yeniNev[4] = nev.Substring(160, 40);
                yeniNev[5] = nev.Substring(200, boy-200);
            }
            return yeniNev;
        }
    }
}
