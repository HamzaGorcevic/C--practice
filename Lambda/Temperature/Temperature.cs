using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Temperature
{
    internal class Temperature
    {
        public delegate void delegateTemperature(float temp);


        public float Temp { get; set; }


       public event delegateTemperature handleTemp;

        public void tempReader(float temp)
        {
            
            handleTemp(temp);
        }

    







    }
}
