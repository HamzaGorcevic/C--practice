using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace extenssionMetode
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var text = "Danas ucimo osnove programiranja C# be osnoca see ne moze dalje";
            var num = 2;
            /*    var shortString = StringHelper.ShortString(text, num);*/
            /*            Console.WriteLine(shortString);*/



            StringBuilder sb = new StringBuilder("Hamza");
            sb.AddLetter('!');
            Console.WriteLine(sb);
            Console.Read();
        }
    }
}
