using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerNasledjivanja
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AvioKompanija kompanija = new AvioKompanija(10);

            RedovniLet r1 = new RedovniLet("BG", "ZG", new DateTime(2023, 2, 25, 10, 0,0), 0, 100);

            RedovniLet r2 = new RedovniLet("SR", "CA", new DateTime(2023, 2, 15, 10, 0,0), 100, 111);

            Charter c1 = new Charter("BG", "ZG", new DateTime(2023, 2, 25, 10, 0,0), 10, 100,50);


            kompanija.DodajLet(r1);
            kompanija.DodajLet(r2);
            kompanija.DodajLet(c1);

            Console.WriteLine(kompanija.ToString());


            kompanija.RezervisiKart("BG", "ZG", new DateTime(2023, 2, 25, 10, 0,0));
            kompanija.RezervisiKart("BG", "CG", new DateTime(2023, 2, 25, 10, 0,0));

            string info = kompanija.ToString();
            Console.WriteLine(info);


            Console.ReadLine();


        }
    }
}
