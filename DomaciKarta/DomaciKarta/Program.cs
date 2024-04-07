using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomaciKarta
{
    internal class Program
    {
        static void Main(string[] args)
        {

            MesecnaKarta busKarta = new MesecnaKarta("Hamza",new DateTime(2024,4,14),1);
            PojedinacnaKarta kupon = new PojedinacnaKarta(60);

            Aparat aparat = new Aparat();
            aparat.DodajKartu(busKarta);
            aparat.DodajKartu(kupon);


            Console.Read();

        }
    }
}
