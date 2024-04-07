using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductZadatak
{
    public class SMSServer
    {
        public void OnOrderComplete(Order order,ProductEventArgs args)
        {

            Console.WriteLine($"SMS: Pristigla je nova porudzbina za artikal {args.Product.Description}! ");
        }
        
    }


    public class EmailServer
    {
        public void OnOrderComplete(Order order, ProductEventArgs args)
        {
            Console.WriteLine("E-MAIL: Pristigla je nova porudzbina za artikal!");
        }

    }
}
