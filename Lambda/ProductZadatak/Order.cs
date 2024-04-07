using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProductZadatak
{
    // publisher klasa

    public class ProductEventArgs
    {

        private Product product;

        public Product Product
        {
            get { return product; }

            set { product = value; }
        }

    }
    public class Order
    {
        public delegate  void OrderHandler(Order order,ProductEventArgs args );

        public event OrderHandler OrderEvent;

        public void Process(Product product)
        {
            Console.WriteLine($"Prodali smo product {product.Description}");
            Thread.Sleep(3000);
            OnOrderComplete(product);

        }

        public void OnOrderComplete(Product product) {
            if (OrderEvent != null)
                OrderEvent?.Invoke(this, new ProductEventArgs{ Product = product });
        }
    }
}
