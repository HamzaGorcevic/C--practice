using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace BaraIspit.Models
{
    public class Talas
    {

        private Ellipse circle;
        public  double ti;


        private List<Color> colors;

        private DispatcherTimer timer;
        private DispatcherTimer timerb;
        public Ellipse Circle
        {
            get { return   circle; }
            set { circle = value; }
        }

        private int x;

        public int X
        {
            get { return x; }
            set { x = value; }
        }
        private int y;

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        private int r;

        public int R
        {
            get { return r; }
            set { r = value; }
        }

        private float b;

        public float B
        {
            get { return b; }
            set { b = value; }
        }
        private int counter;
        public Talas(int x,int y,int r)
        {
            this.x = x;
            this.y = y;
            this.r = r;
            colors = new List<Color> { Colors.Black, Colors.Red, Colors.Blue, Colors.White };
            circle = new Ellipse();
            circle.Width = 2*r;
            circle.Height = 2 * r;
            counter = 0;

            circle.Fill = new SolidColorBrush(colors[counter]);

            timer= new DispatcherTimer();

            timer.Tick += Timer_Tick;
            timerb= new DispatcherTimer();
            timerb.Tick += Timer_Tick2;
            timerb.Interval = TimeSpan.FromSeconds(b);

            timer.Interval = TimeSpan.FromMilliseconds(ti);


        }

        public void Pokreni()
        {
            timer.Start();
            timerb.Start();
        }
        public void Prekini()
        {
            timerb.Stop();
            timer.Stop();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            circle.Width += r;
            circle.Height += r;

          
        }
        private void Timer_Tick2(object sender, EventArgs e)
        {
            if(counter >= colors.Count)
            {
                circle.Visibility = Visibility.Collapsed;
                Prekini();
            }
            circle.Fill = new SolidColorBrush(colors[counter % colors.Count]);
            
            counter++;

        }
    }
}
