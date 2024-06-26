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
    public class AktivanBrod
    {
        string ime;
        Red redPutnika;
        int kapacitet;

        int redosled;
        private CheckBox checkBox;

        private DispatcherTimer timerTui;
        private DispatcherTimer timerTp;
        private DispatcherTimer timerTb;

        private AktivnaLuka lukaUkrcavanje;
        private AktivnaLuka lukaIskrcavanje;

        int tpCount;
        int tbCount;
        int tui;
        int tp;
        int tb;

        StackPanel brodPodloga;
        public AktivanBrod(string ime,AktivnaLuka ukrca,AktivnaLuka iskrc ,int kapacitet, int tui, int tp, int tb)

        { 
            this.redosled=0;
            this.ime = ime;
            this.kapacitet = kapacitet;
            this.tui = tui;
            this.tp = tp;
            this.tb = tb;
            tbCount = 0;
            redosled = 0;
            tpCount = 0;
            this.lukaUkrcavanje = ukrca;
            this.lukaIskrcavanje = iskrc;

            this.brodPodloga = new StackPanel();
            redPutnika = new Red(30);
            checkBox = new CheckBox();
            checkBox.Click += CheckBox_Click;

            TextBlock tbIme = new TextBlock();
            tbIme.Text = ime;

            brodPodloga.Children.Add(tbIme);
            brodPodloga.Children.Add(checkBox);
            brodPodloga.Children.Add(redPutnika.Opis);

            timerTui = new DispatcherTimer();
            timerTp = new DispatcherTimer();    
            timerTb = new DispatcherTimer();

            timerTui.Tick += TimerTui_Tick;
            timerTui.Interval= TimeSpan.FromMilliseconds(tui);

            timerTp.Tick += TimerTp_Tick;
            timerTp.Interval= TimeSpan.FromMilliseconds(tp);

            timerTb.Tick += TimerTb_Tick;
            timerTb.Interval= TimeSpan.FromMilliseconds(tb);
        }

        private void TimerTb_Tick(object sender, EventArgs e)
        {
            tbCount++;
        }

        private void TimerTp_Tick(object sender, EventArgs e)
        {
            tpCount++;
            if(tp == tpCount)
            {
                timerTui.Start();
                timerTp.Stop();

            }
        }

        private void TimerTui_Tick(object sender, EventArgs e)
        {
            if(redosled == 0)
            {
                if (kapacitet >= redPutnika.Dohvati() && tbCount <= tb)
                {
                    redPutnika.DodajURed(lukaUkrcavanje.redPutnika.IzbaciIzReda());

                }
                else
                {
                    timerTui.Stop();
                    timerTp.Start();
                    redosled = 1;
                }
            }
            else
            {
                if(redPutnika.Dohvati() > 0)
                {
                    lukaIskrcavanje.redPutnika.DodajURed(redPutnika.IzbaciIzReda());

                }
                else
                {
                    redosled = 0;
                    timerTp.Start();
                    timerTui.Stop();
                }
            }

        }

        public void Pokreni()
        {
            timerTui.Start();
            timerTb.Start();
        }
        public void Zaustavi()
        {
            timerTui.Stop();
            timerTb.Stop();
            timerTp.Stop();

        }
        private void CheckBox_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if(checkBox.IsChecked == true)
            {
                Pokreni();

            }
            else
            {
                Zaustavi();
            }
        }

        public StackPanel BrodPodloga {  get { return brodPodloga; } }



    }
}
