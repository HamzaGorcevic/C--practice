using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductZadatak
{
    internal class Program
    {

        public delegate int justTesting(int a, int b);

        public  int Saberi(int a, int b)
        {
            Console.WriteLine("sabrano");
            return a + b;
        }
        public int Pomnozi(int a, int b) {

            Console.WriteLine("Pomnozeno");

            test();
            return a + b;
        }
        public void test()
        {
            Console.WriteLine("hamza");
        }

        static void Main(string[] args)


        {
            Program program = new Program();
            program.Pomnozi(1, 2);
/*
            justTesting justTest = Saberi;
            justTest += Pomnozi;
            justTest(5,6);

            */

            
            Product product = new Product
            {
                Id = 1,
                Description = "Laptop lenovo p1"

            };


            SMSServer sms = new SMSServer();
            EmailServer email = new EmailServer();
            Console.WriteLine("does it work");
            Order order = new Order();
            order.OrderEvent += sms.OnOrderComplete;
            order.OrderEvent += email.OnOrderComplete;

            /*order.Process(product);*/

            Console.ReadLine();

        }
    }
}
