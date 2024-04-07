using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Unesite a");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Unesite b");
            int b= int.Parse(Console.ReadLine());

            // izracunati kvadrat broja a kroz funkciju 
            // Func<int  , int ...> vrsta delegata koji vraca tip koji postavimo na pocetku

            Func<int, int> Kvadrat = w => w * w;

            Func<int, int, int> Zbir = (c, d) => c + d;

            Console.WriteLine($"Zbir brojeva a i b je {Zbir(a,b)}");

            Console.WriteLine($"Kvadrat unetog broja {a} = {Kvadrat(a)}");

                // Action<int  , string  ...> vrsta delegata koji vraca void
            Console.Read();
        }

    }
}
