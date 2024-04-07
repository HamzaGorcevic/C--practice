using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temperature
{
    internal class Display
    {

        private float temp;

        public void checkForTemp(float temp)
        {

            this.temp = temp;
            Console.WriteLine($"showed temp is {this.temp} %");


        }

        
    }
}
