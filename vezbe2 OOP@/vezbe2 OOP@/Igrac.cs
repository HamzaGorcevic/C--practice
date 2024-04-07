using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vezbe2_OOP_
{
    internal class Igrac
    {
        private int broj;

        public int GetBroj1()
        { return broj; }

        public int Broj
        {
            get { return broj; }
            set
            {
                if (value >= 1 && value <= 10)
                    broj = value;
                else
                {
                    Console.WriteLine("Neispravan unso");
                    broj = -1;
                }
            }
        }
        public void GetBroj()
        {
            Console.WriteLine("Unesite zamiljeni broj");
            string saKonzole = Console.ReadLine();
            Broj = int.Parse(saKonzole);
            Console.WriteLine(Broj);

        }
    }
}
