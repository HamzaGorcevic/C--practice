using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ
{
    internal class ProductRepositrory
    {
        public static List<Product> products;

        public ProductRepositrory()
        {
            products = new List<Product>();
            products.Add(new Product { Id = 1, Name = "Hleb", Price = 32, Date = new DateTime(2024, 3, 20) });
            products.Add(new Product { Id = 2, Name = "Mila", Price = 132, Date = new DateTime(2024, 3, 18) });
            products.Add(new Product { Id = 3, Name = "Sok", Price = 222, Date = new DateTime(2024, 3, 18) });


        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public  Product GetProducitById(int id)
        {
            Product p = products.Find(x => x.Id == id);
            if (p == null)
            {
                // 
                throw new Exception("neispravan id");
            }
            return p;
        }

    }
}
