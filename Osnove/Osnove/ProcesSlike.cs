using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Osnove
{
    internal class ProcesSlike
    {

        // delegat posmatramo kao pointer na funkciju
        public delegate void PhotoProcessorHandler(Slika photo);

        public void Process(string url,PhotoProcessorHandler handler)
        {
            Slika slika = Slika.Load(url);
            Console.WriteLine("Ucitali smo baznu sliku. Krecemo sa izmenama");
            Thread.Sleep(3000);

            handler(slika);
         
            

        }

        
    }
}
