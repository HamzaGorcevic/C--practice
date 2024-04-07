using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_vezbe_2
{
    internal class Igra
    {
        public void Igraj()
        {
            Igrac igrac = new Igrac();
            Racunar racunar = new Racunar();

            int brPogodaka = 0, brGenerisanja = 0;
            while (true)
            {
                igrac.GetBroj();
                if (igrac.GetBroj1() == -1)
                    break;
                racunar.GetBroj();
                brGenerisanja++;
                if (igrac.GetBroj1() == racunar.Broj)
                {
                    brPogodaka++;
                }

            }

            float procenat = (float)brPogodaka / brGenerisanja * 100;
            Console.WriteLine($"Igrac je pogodio {brPogodaka} puta");
            Console.WriteLine($"Procenat pogadjanja je {procenat}%");

        }


    }
}
