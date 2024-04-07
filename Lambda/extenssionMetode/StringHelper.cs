using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace extenssionMetode
{
    public static class StringHelper
    {

        //"Danas ucimo osnove programskog jezika C#. Bez osnova se ne mode dalje!",5
        //"Danas ucimo onsove programskog jezika ..."


        public static string ShortString(this string text, int numWords)
        {
            if (numWords <= 0)
            {
                return text;
            }

            var words = text.Split(' ');
            var list = string.Join(" ", words.Take(numWords));

      
            return list;


        }

         // this is not possible because strings are not mutable , but we can do something similar with stringBuilder

        /*public static void AddLetter(this string text,char letter)
        {
            text = text + letter;
        }*/

        public static void AddLetter(this StringBuilder sb,char letter)
        {
            sb.Append(letter);
            
        }

    }
}
