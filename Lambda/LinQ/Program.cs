using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LinQ
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ProductRepositrory repositrory = new ProductRepositrory();

            List<Product> products = repositrory.GetProducts();

           /* Console.WriteLine($"U nasoj listi trenutno imamo {products.Count} elemenata");
            Console.WriteLine($"Artikal sa id-jem 2 je \n {repositrory.GetProducitById(2).ToString()}");

*/
            var containtName = products.Where(p => p.Name.Contains("L")).ToList();

            var cheapProducts = products.FindAll(IsCheaper);

            var cheapProducts2 = products.Where(product => product.Price < 200);

            foreach(var product in cheapProducts2)
            {
                Console.WriteLine(product.Name);
            }


            products.FirstOrDefault(p => p.Id == 5); // moze vratiti i vise elemenata
            products.SingleOrDefault(p => p.Id == 5); // sigurno vraca jedan element
            products.All(p => p.Date <= DateTime.Now); // da li su svi
            products.Any(p => p.Date <= DateTime.Now); // da li je bar jedan
            Console.WriteLine($"Ukupno ima {cheapProducts.Count} jeftinihij artikala");


            // naci proizvode koji su prodati datuma koji je uneo korisnik sa tastature
            DateTime? datetime = null;

            Console.WriteLine("Unesite zelejni datum");
            string saKonzole = Console.ReadLine();
            datetime = DateTime.Parse(saKonzole);
            DateTime d1 = datetime ?? DateTime.Now;

            if (datetime.HasValue)
            {

                List<Product> prodatiDaum = products.Where(p => p.Date == datetime).ToList();
            }

            Console.Read();
        }

        static bool IsCheaper(Product product)
        {
            if(product.Price < 300)
            {
                return true;
            }
            return false;
        }
    }
}
