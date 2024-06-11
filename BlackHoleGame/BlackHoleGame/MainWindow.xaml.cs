using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BlackHoleGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,INotifyPropertyChanged
    {

         private ObservableCollection<Planet> planets;
        public class Planet:INotifyPropertyChanged
        {
            public int width;
            public Ellipse planet;
            public int height;
            private int top;
            private int left;
            private Brush color;
            private int saved;


            public Brush Color
            {
                get { return color; }
                set
                {
                    color = value;
                    onPropertyChanged();

                }
            }
            public int Saved
            {
                get { return saved; }
                set { saved = value;

                    onPropertyChanged();
                }
            }


            public int Left { set
                {
                    if (left != value)
                    {
                        left = value;
                        onPropertyChanged();
                    }
                } get { return left; } }

            public int Top
            {
                get { return top; }
                set
                {
                    if(top != value)
                    {
                        top = value;
                        onPropertyChanged();
                    }
                }
            }

        
            public event PropertyChangedEventHandler PropertyChanged;
            protected void onPropertyChanged([CallerMemberName] string propertyName = null)
            {
                planet.Fill = color;
                Canvas.SetLeft(planet, (double)this.left);
                Canvas.SetTop(planet, (double)this.top);

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                

            }

            public Planet(int width,int height,Brush color,int left,int top) {
                this.width= width;
                this.height= height;
                this.color = color;
                this.left = left;
                this.top = top;
                planet = new Ellipse();
                planet.Tag = this;
                planet.Width = this.width;
                planet.Height = this.height;
                planet.Fill = color;
                saved = 0;
                

                Canvas.SetLeft(planet, (double)this.left);
                Canvas.SetTop(planet, (double)this.top);


            
            }
        }
        private int gravity;
        private int intervalCount = 0;
        private int counter = 0;
        private int savedPlanets;

        // TIMERS !
        System.Timers.Timer countTimer = new System.Timers.Timer(5);
        System.Timers.Timer interval = new System.Timers.Timer(1000);


        public event PropertyChangedEventHandler PropertyChanged;
        protected void onProperyChanged([CallerMemberName] string propertyName = null)
        {

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public int SavedPlanets
        {
            get { return savedPlanets; }
            set { savedPlanets = value;

                onProperyChanged();
            }
        }

        public int Gravity
        {
            set { gravity = value; }
            get { return gravity; }
        }


        public MainWindow()
        {
            planets = new ObservableCollection<Planet>();

            savedPlanets = 0;
            InitializeComponent();
            DataContext = this;

        }

        public void StartGame()
        {
            if (startBtn.Content.ToString() == "Start")
            {
                SavedPlanets = 0;
                pauseBtn.Content = "Pause";
                startBtn.Content = "Restart";
               
                   var listToRemove =  cvGalaxy.Children.OfType<Ellipse>().Where((el) => el != cvBlackHole).ToList();
                foreach (Ellipse ellipse in listToRemove)
                {
                    cvGalaxy.Children.Remove(ellipse);
                }


                
                planets.Clear();

                interval.Elapsed -= Interval_Elapsed;
                countTimer.Elapsed -= CountTimer_Elapsed;
                interval.Elapsed += Interval_Elapsed;
                countTimer.Elapsed += CountTimer_Elapsed;
                interval.Start();
                countTimer.Start();

            }
            else
            {
                SavedPlanets = 0;
                var listToRemove = cvGalaxy.Children.OfType<Ellipse>().Where((el) => el != cvBlackHole).ToList();
                foreach (Ellipse ellipse in listToRemove)
                {
                    cvGalaxy.Children.Remove(ellipse);
                }

                planets.Clear();
                interval.Stop();

                countTimer.Stop();
                interval.Elapsed -= Interval_Elapsed;
                countTimer.Elapsed -= CountTimer_Elapsed;
                startBtn.Content = "Start";
            }


        }

   
        private void CountTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
               if(planets.Count >= 1)
                {
                    ObservableCollection<Planet> trackingList = new ObservableCollection<Planet>();
                    foreach (var item in planets)
                    {
                        if (item.Left < (int)Canvas.GetLeft(cvBlackHole) + 50)
                        {
                            item.Left += 2;
                        }
                        else if (item.Left > (int) Canvas.GetLeft(cvBlackHole)-40 && item.Left != (int)Canvas.GetLeft(cvBlackHole) + 50)
                        {
                            item.Left -= 2;
                        }


                        int blackHoleTop = (int)Canvas.GetTop(cvBlackHole);
                        int range = 50;

                        if (item.Top < blackHoleTop + range)
                        {
                            item.Top += 1;
                        }
                        else if (item.Top > blackHoleTop - range && blackHoleTop + range != item.Top)
                        {
                            item.Top -= 1;
                        }
                        


                        Point location = new Point((double)item.Left, (double)item.Top);
                        Size planetSize = new Size((double)item.width, (double)item.height);
                        Rect planetLocation = new Rect(location,planetSize);

                        Size bhSize = new Size((double)cvBlackHole.Width, (double)cvBlackHole.Height);
                        Point bhLocation = new Point((double)Canvas.GetLeft(cvBlackHole), (double)Canvas.GetTop(cvBlackHole));
                        Rect blackHoleLocation = new Rect(bhLocation,bhSize);

                        if (planetLocation.IntersectsWith(blackHoleLocation))
                        {

                            trackingList.Add(item);

                        }
                       
                    }
                    foreach (var item in trackingList)
                    {
                        planets.Remove(item);
                        cvGalaxy.Children.Remove(item.planet);


                    }
                }
            });

        }

        private void Interval_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                intervalCount++;
                if (intervalCount == gravity)
                {
                    GeneratePlanet();
                    intervalCount = 0;
                }
            });
            
        }

        public void GeneratePlanet()
        {


            Random randomSide = new Random();
            int intrandomSide = randomSide.Next(0, 2);
            int randomHorizontalSide = 0;

            if (intrandomSide == 1)
            {
                randomHorizontalSide =  randomSide.Next(600, 799);

            }
            else
            {
                 randomHorizontalSide = randomSide.Next(0, 120);

            }

            int randomVerticalSide = randomSide.Next(0, 2);

            if(randomVerticalSide == 1)
            {
                randomVerticalSide = randomSide.Next(0, 50);
            }
            else
            {
                randomVerticalSide = randomSide.Next(350, 400);
            }
            Brush color = new SolidColorBrush(Colors.Green);

            Planet planet = new Planet(30, 30, color, randomHorizontalSide, randomVerticalSide);

            planet.planet.MouseDown += Planet_MouseDown;
            cvGalaxy.Children.Add(planet.planet);
            planets.Add(planet);

        }

        private void Planet_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Random randomSide = new Random();
            int intrandomSide = randomSide.Next(0, 2);
            int randomHorizontalSide = 0;

            if (intrandomSide == 1)
            {
                randomHorizontalSide = randomSide.Next(600, 799);

            }
            else
            {
                randomHorizontalSide = randomSide.Next(0, 120);

            }

            int randomVerticalSide = randomSide.Next(0, 2);

            if (randomVerticalSide == 1)
            {
                randomVerticalSide = randomSide.Next(0, 50);
            }
            else
            {
                randomVerticalSide = randomSide.Next(350, 400);
            }

            Ellipse chosen = sender as Ellipse;

          Planet tag = chosen.Tag as Planet;

            tag.Saved++;
            tag.Left = randomHorizontalSide;
            tag.Top = randomVerticalSide;


            tag.Color = new SolidColorBrush(Colors.Red);

            if(tag.Saved == 2)
            {
                
                tag.Left = 100;
                tag.Top = 50;
                planets.Remove(tag);
                chosen.MouseDown -= Planet_MouseDown;
                SavedPlanets++;

            }

        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

   
            StartGame();


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Button button = sender as Button;
            if(button.Content.ToString() == "Pause")
            {
                foreach (Planet planet in planets)
                {
                    planet.planet.MouseDown -= Planet_MouseDown;
                }
                button.Content = "Continue";
                countTimer.Stop();
                interval.Stop();

            }
            else
            {
                foreach (Planet planet in planets)
                {
                    planet.planet.MouseDown += Planet_MouseDown;
                }
                button.Content = "Pause";

                interval.Start();
                countTimer.Start();
            }
               
        }
    }
}
