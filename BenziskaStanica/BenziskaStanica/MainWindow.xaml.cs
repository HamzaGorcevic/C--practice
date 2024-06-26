using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BenziskaStanica
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
/* POTREBNO HARDKODIRATI ID OD 4 pumpe koja svaka benzinska ima , i kod ce readiti*/
    public partial class MainWindow : Window,INotifyPropertyChanged
    {


        BenziskaStanicaEntities context = new BenziskaStanicaEntities();

        ObservableCollection<Automobil> automobils = new ObservableCollection<Automobil>();

        public ObservableCollection<Automobil> automobilsQueue;

        public ObservableCollection<Automobil> AutomobilsQueue { set { automobilsQueue = value; onPropertyChanged(); } get { return automobilsQueue; } }



        System.Timers.Timer timer= new System.Timers.Timer(400);
        System.Timers.Timer pumpaTimer = new System.Timers.Timer(1500);
        public Benzinska benziska;

        public Pumpa pumpa1;
        public Pumpa pumpa2;
        public Pumpa pumpa3;
        public Pumpa pumpa4;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void onPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));   
        }
        public MainWindow()
        {

            DataContext = this;

            Autoput nautoput = new Autoput();

            Benzinska nbezniska = new Benzinska();

            Pumpa nPumpa1 = new Pumpa
            {
                id = 1
            };
            Pumpa nPuma2 = new Pumpa
            {
                id=2
            };
            Pumpa nPumpa3 = new Pumpa
            {
                id=3
            };
            Pumpa nPumpa4 = new Pumpa
            {
                id=4
            };
            Automobil nAuto = new Automobil();
            nAuto.rezervoar = 130;
            nAuto.idBenziske = nbezniska.id;

            
            nbezniska.Pumpas.Add(nPuma2);
            nbezniska.Pumpas.Add(nPumpa1);
            nbezniska.Pumpas.Add(nPumpa3);
            nbezniska.Pumpas.Add(nPumpa4);
            nautoput.Benzinskas.Add(nbezniska);
            context.Autoputs.Add(nautoput);
            context.SaveChanges();



            
            var autoput = context.Autoputs.FirstOrDefault();

            benziska = new Benzinska();

            if (autoput != null)
            {
                benziska = autoput.Benzinskas.FirstOrDefault();
                if (benziska != null)
                {
                    AutomobilsQueue = new ObservableCollection<Automobil>(benziska.Automobils);

                    var pumpe = context.Pumpas.Where(pump => pump.idBenzinske == benziska.id).ToList();
                    if (pumpe.Count >= 4)
                    {
                        pumpa1 = pumpe[0];
                        pumpa2 = pumpe[1];
                        pumpa3 = pumpe[2];
                        pumpa4 = pumpe[3];
                    }

                    timer.Elapsed += Timer_Elapsed;
                    timer.Start();

                    pumpaTimer.Elapsed += PumpaTimer_Elapsed;
                    pumpaTimer.Start();
                }
                else
                {
                    MessageBox.Show("Benziska je null");
                }
            }
            else
            {
                MessageBox.Show("Autoput je null");
            }
            Automobil defaultAuto = new Automobil();
            defaultAuto.gorivo = 21;
            defaultAuto.rezervoar = 100;
            defaultAuto.idBenziske = benziska.id;
            InitializeComponent();
            timer.Start();
            timer.Elapsed += Timer_Elapsed;

            pumpaTimer.Start();
            pumpaTimer.Elapsed += PumpaTimer_Elapsed;
        }

        private void PumpaTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                if (automobilsQueue.Count >= 4)
                {

                    if (PocniPunjenje())
                    {

                        PuniAuto(pumpa1.Automobil);
                        PuniAuto(pumpa2.Automobil);
                        PuniAuto(pumpa3.Automobil);
                        PuniAuto(pumpa4.Automobil);

                    };


                }
            });
        }


            public void PuniAuto(Automobil trAuto)
        {

            
      
                if (trAuto.gorivo < trAuto.rezervoar)
                {
                    trAuto.gorivo += 11;

                string idPumpe = $"tbPumpa{trAuto.idPumpe}";

                TextBlock pumpaPuni = this.FindName((string)idPumpe) as TextBlock;


                pumpaPuni.Text = trAuto.id.ToString();
                pumpaPuni.Width = (double)trAuto.gorivo;

                }
                else
                {
                    automobils.Remove(trAuto);
                }

            
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

            Dispatcher.Invoke(() =>
            {
                if (automobilsQueue.Count < 20)
                {

                    Random random = new Random();
                    int rez = random.Next(100, 190);
                    int gor = rez * random.Next(10, 30) / 100;


                    Automobil noviAuto = new Automobil
                    {
                        idBenziske = benziska.id,
                        rezervoar = rez,
                        gorivo = gor
                    };



                    benziska.Automobils.Add(noviAuto);
                    context.SaveChanges();


                    AutomobilsQueue.Add(noviAuto);

                }
            });

        }


        public bool PocniPunjenje()
        {
            int lastIndex = automobilsQueue.Count;

            if (lastIndex >= 4)
            {
                pumpa1.Automobil = automobilsQueue[lastIndex - 1];
                pumpa1.Automobil.idPumpe = 1;

                automobilsQueue.RemoveAt(lastIndex - 1);

                lastIndex--;

                pumpa2.Automobil = automobilsQueue[lastIndex - 1];
                pumpa2.Automobil.idPumpe = 2;

                automobilsQueue.RemoveAt(lastIndex - 1);

                lastIndex--;

                pumpa3.Automobil = automobilsQueue[lastIndex - 1];
                pumpa3.Automobil.idPumpe = 3;

                automobilsQueue.RemoveAt(lastIndex - 1);

                lastIndex--;

                pumpa4.Automobil = automobilsQueue[lastIndex - 1];
                pumpa4.Automobil.idPumpe =4;

                automobilsQueue.RemoveAt(lastIndex - 1);

                context.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
