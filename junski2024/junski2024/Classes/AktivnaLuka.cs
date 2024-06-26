using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace junski2024.Classes
{
    public class AktivnaLuka
    {

        private string ime;

        private int tsr;

        private DispatcherTimer timer;

        public Red redPutnika;
        private int brPutnika;


        private CheckBox checkBox;

        private StackPanel lukaPodloga;

        private Putnik putnikKojiCeka;

        public StackPanel LukaPodloga { get {  return lukaPodloga; } 
        set { lukaPodloga = value; }
        }

        public AktivnaLuka(string ime,int br, int tsr)
        {
            checkBox = new CheckBox();
            checkBox.Click += CheckBox_Click;
            TextBlock tbIme = new TextBlock();
            redPutnika = new Red(br);
            tbIme.Text = ime;


            lukaPodloga = new StackPanel();

            lukaPodloga.Children.Add(tbIme);
            lukaPodloga.Children.Add(checkBox);
            lukaPodloga.Children.Add(redPutnika.Opis);


            brPutnika = br;
            Random random = new Random();
            int randomNumber = random.Next(0, 100);

            if(randomNumber < 50) {
            this.tsr = tsr + tsr * (20/100) ;

            }
            else
            {
                this.tsr = tsr - tsr *(20/100);
            }
            timer = new DispatcherTimer();
            timer.Interval =  new TimeSpan(tsr);

            timer.Tick += Timer_Tick;
        }

        private void CheckBox_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (checkBox.IsChecked == true)
            {
                Otvori();
            }
            else
            {
                Zatvori();
            }
            
        }

        public void Otvori()
        {
            timer.Start();

        }
        public void Zatvori()
        {
            timer.Stop();
        }

        public Putnik DohvatiPutnikaKojiCeka()
        {
            return putnikKojiCeka;
        }
        public int BrPutnika()
        {
            return redPutnika.Dohvati();

        }




        private void Timer_Tick(object sender, EventArgs e)
        {
            if (brPutnika <= redPutnika.Dohvati())
            {
                MessageBox.Show("pun");
                Zatvori();

            }
            else
            {
                if (redPutnika.Dohvati() < brPutnika)
                {
                    Putnik putnik = new Putnik();
                    putnikKojiCeka = putnik;
                    redPutnika.DodajURed(putnik);
                }
                else
                {
                    timer.Stop();
                }

            }
           
          

                

           
        }
    }
}
