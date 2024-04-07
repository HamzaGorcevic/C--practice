using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osnove
{
    internal class Program
    {
        public static void Clean(Slika slika)
        {
            Console.WriteLine("Slika ociscena");

        }
        static void Main(string[] args)
        {
            
            ProcesSlike slika1 = new ProcesSlike();

            ProcesSlike.PhotoProcessorHandler handler = FilteriSlike.PostaviCrvenuPozadinu;




            /*slika1.Process("image.2", handler);*/

            Console.WriteLine("\n Drugi krug sa dodatnim static funkcijama na delegatu \n");

            //Funkcije iz program je dodana u handler

            handler += Clean;
            handler += Slika.Save;
            Slika slikaI = new Slika();

            slikaI.HandleSlika(handler, slikaI);

      /*      slika1.Process("image.2", handler);*/


            Console.Read();

        }
    }
}
