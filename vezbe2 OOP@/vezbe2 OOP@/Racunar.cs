using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vezbe2_OOP_
{
    internal class Racunar
    {

        private int broj;
        private Random r = new Random();

        public int Broj
        {

            get
            {
                return broj;
            }
            set
            {
                broj = value;
            }
        }


        public Racunar()
        {
            GetBroj();
        }
        public void GetBroj()
        {
            Broj = r.Next(1, 10);
        }


    }
}
