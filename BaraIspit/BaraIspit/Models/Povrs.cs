using System;
using System.Windows.Controls;

namespace BaraIspit.Models
{
    public class Povrs
    {
        private Canvas povrsina;


        public delegate void KapJePala();

        public event KapJePala OnKapJePala;
        public Canvas Povrsnia
        {
            get => povrsina;
            set => povrsina = value;
        }

        public Povrs(int height, int width)
        {
            povrsina = new Canvas
            {
                Height = height,
                Width = width
            };
        }

        public double GetHeight()
        {
            return povrsina.Height;
        }

        public double GetWidth()
        {
            return povrsina.Width;
        }

        public void RegisterKap(Kap kap)
        {
            if( kap.X > 0 && kap.X < povrsina.Width && kap.Y > 0 && kap.Y < povrsina.Height)
            {
                Talas tls = new Talas(kap.X, kap.Y, 5);


                tls.ti = (double)kap.Q * 0.00005;

                tls.B = (float)kap.Q / 0.00005f;


                OnKapJePala += tls.Pokreni;
                Canvas.SetLeft(tls.Circle, tls.X);
                Canvas.SetTop(tls.Circle, tls.Y);


                Povrsnia.Children.Add(tls.Circle);

                OnKapJePala();
            }
        }
    }
}
