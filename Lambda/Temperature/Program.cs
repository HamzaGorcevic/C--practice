using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temperature
{
    internal class Program
    {

        public static void staticTemp(float temp)
        {
            Console.WriteLine($"static temp is {temp}");
        }
        static void Main(string[] args)
        {

            Temperature sensor = new Temperature();
            Display displayTemp = new Display();
            sensor.handleTemp += displayTemp.checkForTemp;
            sensor.handleTemp += staticTemp;

            Random random = new Random();
            float temp = random.Next(10, 100);
            sensor.tempReader(temp);
            temp = random.Next(10, 100);    
            sensor.tempReader(temp);
            temp = random.Next(10, 100);

            sensor.tempReader(temp);

            

            Console.ReadLine();
            
        }
    }
}
