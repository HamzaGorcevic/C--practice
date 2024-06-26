using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace junski2024.Classes
{
    public class Putnik
    {
        static int counter = 0;
        private int id;

        public Putnik() { 
        
            id = counter++;
        }

        public override string ToString()
        {
            return id.ToString();
        }
    }
}
