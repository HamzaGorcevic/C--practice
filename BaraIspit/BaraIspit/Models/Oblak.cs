using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace BaraIspit.Models
{
    public class Oblak
    {
        private int interval;

        private DispatcherTimer timer;

        private double height;
        private double width;


        private int x;
        private int y;
        public Rectangle povrsina;



        public delegate void KapPalaDelegae(Kap kap);
        public event KapPalaDelegae OnKapaPala;
        

        public Canvas oblakCv;

        public Oblak(int interval,double height,double width) {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(interval);

            povrsina=new Rectangle();
            timer.Tick += Timer_Tick;
            this.interval = interval;
            this.height = height;
            this.width = width;
         
            povrsina.Focusable= true;
            Canvas.SetTop(povrsina,0);
            Canvas.SetLeft(povrsina, x);
        }

        public void Povrsina_KeyDown()
        {
            MessageBox.Show("en");
       
                MessageBox.Show("enter");
                if (x > 20 && x < 500)
                {
                    x += 20;
                    Canvas.SetLeft(povrsina, x);
                }

            
        }

        public void Zapocni()
        {
            timer.Start();

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            Random random = new Random();


            int randomX = random.Next(0, (int)width);
            int randomY = random.Next(0, 300);

            Kap kap = new Kap(randomX, randomY, 2);
            OnKapaPala.Invoke(kap);

            
        }

    }
}
