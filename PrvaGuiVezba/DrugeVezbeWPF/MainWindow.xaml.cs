using System;
using System.Collections.Generic;
using System.Linq;
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

namespace DrugeVezbeWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
     
        private int _cols;
        private int _rows;
        private Button[,] buttons;


        public int Rows
        {
            get { return _rows; }

            set
            {
                _rows = value;

                PodesiDugmice();
            }
        }
        public int Cols {
            get { return _cols; }
            
            set { _cols = value;

                PodesiDugmice();
            }
        }

        private void PodesiDugmice()
        {
            buttons = new Button[_rows, _cols];
            int i, j;
            for (i = 0; i < _rows; i++)
            {
                for (j = 0; j < _cols; j++)
                {

                    buttons[i, j] = new Button();


                    if (i % 2==0 && j % 2 == 0 || i%2!=0 && j%2!=0 )
                    {
                        buttons[i, j].Background = Brushes.Black;
                        buttons[i, j].Foreground = Brushes.White;
                    }
                    else
                    {
                        buttons[i, j].Background = Brushes.White;
                        buttons[i, j].Foreground = Brushes.Black;




                    }
                    buttons[i, j].Content = $"{(char)(72 - i)} {j+1}";
                    buttons[i, j].Click += Dugme_click;
                    var sirira = this.Width / Cols;
                    var visina = this.Height / Rows;

                    buttons[i, j].Width = sirira;
                    buttons[i, j].Height = visina;
               

                    Canvas.SetLeft(buttons[i, j],j*sirira);
                    Canvas.SetTop(buttons[i, j], i * visina);
                    this.podloga.Children.Add(buttons[i, j]);
                }
            }
        }

        private void Dugme_click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            MessageBox.Show(btn.Content.ToString());
        }

        public MainWindow()
        {
            InitializeComponent();
            _cols = 8;
            Rows = 8;



        }



    }
}
