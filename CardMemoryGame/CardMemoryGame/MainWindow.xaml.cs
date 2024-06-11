using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CardMemoryGame
{
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        private int timerclock = 0;

        private int timerWrong = 0;

        List<TextBlock> chosenElements = new List<TextBlock>();
        System.Timers.Timer timer = new System.Timers.Timer(1000);

        System.Timers.Timer timerWeak = new System.Timers.Timer(1000);
        public int Timerclock { get { return timerclock; } set { timerclock = value; onPropertyChanged(); } }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void onPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        public MainWindow()
        {

            
            


            DataContext = this;
            InitializeComponent();
            CreateTable();
        }

        public void SetTimer()
        {

            timer.Elapsed += Timer_Elapsed;
            timer.Enabled = true;

        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Timerclock +=1;
            if (timerclock >= 30)
            {
                timer.Stop();

                MessageBox.Show("vase vreme je isteklo");
                

            }
        }

        public void CreateTable()
        {
            for (int i = 0; i < 4; i++)
            {
                ColumnDefinition columnDefinition = new ColumnDefinition();
                board.ColumnDefinitions.Add(columnDefinition);
            }
            for (int i = 0; i < 5; i++)
            {
                RowDefinition rowDefinition = new RowDefinition();
                board.RowDefinitions.Add(rowDefinition);
            }
        }


        public void StartGame()
        {

            SetTimer();
            ShuffleElements();
          

        

        }

    

        private void CheckElements()
        {
         
            if (chosenElements.Count == 2)
            {

             
                TextBlock rightTb = chosenElements[0];
                TextBlock rightTb1 = chosenElements[1];

                if (chosenElements[0].Text == chosenElements[1].Text)
                {



                    rightTb.Background = Brushes.Green;
                    rightTb1.Background = Brushes.Green;

                    rightTb.MouseDown -= TextBlock_MouseDown;
                    rightTb1.MouseDown -= TextBlock_MouseDown;
                    chosenElements.RemoveAll(x => x != null);


                }
                else
                {
                    timerWrong = 0;
                    timerWeak.Elapsed += TimerWeak_Elapsed;
                    timerWeak.Start();

                    rightTb.Background = Brushes.Red;
                    rightTb1.Background = Brushes.Red;
                }

            }
            else
            {
            }
        }

        private void TimerWeak_Elapsed(object sender, ElapsedEventArgs e)
        {
            timerWrong += 1;

            Dispatcher.Invoke(() =>
            {
                if (chosenElements.Count == 2 && chosenElements[0].Text != chosenElements[1].Text && timerWrong == 2)
                {
                    MessageBox.Show("why not");


                    TextBlock rightTb = chosenElements[0];
                    TextBlock rightTb1 = chosenElements[1];

                    rightTb.Foreground = Brushes.Gray;
                    rightTb1.Foreground = Brushes.Gray;

                    rightTb1.Background = Brushes.Gray;
                    rightTb.Background = Brushes.Gray;
                    chosenElements.RemoveAll(x => x != null);

                timerWeak.Stop();   
                    timerWrong = 0;
                }

            });
        }

        public void ShuffleElements()
        {


        
            List<List<int>> randomArray = new List<List<int>>();

            for (int i = 0; i < 4; i++)
            {
                var randomVrsta = new List<int>();
                for (int j = 0; j < 5; j++)
                {
                    if (i < 2)
                    {
                        randomVrsta.Add(i * 5 + j + 1);
                    }
                    else
                    {
                        randomVrsta.Add((i-2) * 5 + j + 1);
                    }
                }
                randomArray.Add(randomVrsta);
            }

            Random random1 = new Random();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    int randomi = random1.Next(0, 4);
                    int randomj = random1.Next(0, 5);

                    (randomArray[i][j], randomArray[randomi][randomj]) = (randomArray[randomi][randomj], randomArray[i][j]);
                }
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    TextBlock textBlock = new TextBlock();
                    textBlock.MouseDown += TextBlock_MouseDown;
                    textBlock.Text = randomArray[i][j].ToString();
                    textBlock.Margin = new Thickness(3);
                    textBlock.Background = Brushes.Gray;
                    textBlock.Foreground = Brushes.Gray;
               

                    Grid.SetColumn(textBlock, j);
                    Grid.SetRow(textBlock, i);    
                    board.Children.Add(textBlock);
                }
            }
        }

        private void TextBlock_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
           if(chosenElements.Count < 2)
            {
                TextBlock clickedTb = sender as TextBlock;
                clickedTb.Foreground = Brushes.Black;

                chosenElements.Add(clickedTb);
                CheckElements();
            }

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StartGame();

        }
    }
}
