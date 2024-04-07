using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_vezbe_2
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
            broj = r.next(1, 10);
        }


    }
}
   



}
