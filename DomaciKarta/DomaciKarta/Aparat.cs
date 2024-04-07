using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomaciKarta
{
    internal class Aparat
    {
        private List<Karta<object> lista = new List<Karta<object>>();

        public void DodajKartu(Karta<object> karta)
        {
            lista.Add(karta);
        }


        public override string ToString()
        {
            string word = "";
            foreach(Karta<object>karta in lista)
            {
                Console.WriteLine(karta.ToString());

            }
            return word;
        }



    }
}
