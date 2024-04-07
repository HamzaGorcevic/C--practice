using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ
{
    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public DateTime Date { get; set; }


        public override string ToString()
        {
            return $"id artikla je {Id} \n Naziv artikla je {Name} \n Cena artikla je {Price}";
        }

    }
}
