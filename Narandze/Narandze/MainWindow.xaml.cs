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
using static Narandze.MainWindow;

namespace Narandze
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public class Orange:INotifyPropertyChanged
        {
            private int id;
            private bool zdrava;
            private string oznaka;


            public Ellipse Ellipse { get; }



            public bool Zdrava
            {
                get { return zdrava; }
                set {if (zdrava != value)
                    {
                        zdrava = value;
                        OnPropertyChanged();
                        UpdateEllipseColor();
                    }

                }
            }
            private void UpdateEllipseColor()
            {
                if (Ellipse != null)
                {
                    Ellipse.Fill = zdrava ? Brushes.Orange : Brushes.Brown;
                }
            }
            public Orange(bool zdrava, string oznaka,Ellipse ellipse)
            {
                this.id = idIncrement++;
                this.zdrava= zdrava;
                this.oznaka = oznaka;
                this.Ellipse = ellipse;
                UpdateEllipseColor();


            }
            public event PropertyChangedEventHandler PropertyChanged;

            protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }


        }
        public class Lista
        {
           public ObservableCollection<ObservableCollection<Orange>> lista;

            public Lista()
            {
                lista = new ObservableCollection<ObservableCollection<Orange>>();

            }

        }
        static int idIncrement = 0;

        private int rows;
        private int columns;
            Unos unos = new Unos();
        Lista lista = new Lista();

        public MainWindow()
        {
            unos.Show();
            unos.onloadData += Unos_onloadData;


         

            InitializeComponent();
        }

        private void Unos_onloadData()
        {
            rows = unos.rowsValue;
            columns = unos.columnsValues;

            if (rows != 0 && columns != 0)
            {
                CreateTable();
                CreateOranges();
                
            }
        }

        public void CreateTable()
        {
            grGajba.RowDefinitions.Clear();
            grGajba.ColumnDefinitions.Clear();
            for(int c=0;c<columns; c++)
            {
                ColumnDefinition columnDefinition = new ColumnDefinition();
                grGajba.ColumnDefinitions.Add(columnDefinition);
            };

            for(int i = 0; i < rows; i++)
            {
                RowDefinition rowDefinition = new RowDefinition();
                grGajba.RowDefinitions.Add(rowDefinition);

            }

        }

    
        public void CreateOranges()
        {

            Random r = new Random();

            for (int i=0;i<rows;i++)
            {
                ObservableCollection<Orange> redNarandzi = new ObservableCollection<Orange>();
                
                for (int j = 0; j < columns; j++)
                {
                    Ellipse ellipse = new Ellipse();
                    int pokvarena = r.Next(1,100);
                    bool pokvarenaBool = pokvarena > 20;

               
                    Orange orange = new Orange(pokvarenaBool, "oznaka",ellipse);
                    ellipse.Width = 30;
                    ellipse.Height = 30;
                   
                    Grid.SetRow(ellipse, i);
                    Grid.SetColumn(ellipse, j);
                    grGajba.Children.Add(ellipse);
                    redNarandzi.Add(orange);
                }
                lista.lista.Add(redNarandzi);
            }
        }

        
        public void PokvariOranges(Lista lista)
        {
            var ruinedOranger = new List<(int i,int j)>();
            for(int i= 0; i < lista.lista.Count; i++)
            {
                for(int j= 0; j < lista.lista[i].Count; j++)
                {

                    if (!lista.lista[i][j].Zdrava)
                    {
                        ruinedOranger.Add((i, j));
                    }
                }
            }

          
            foreach(var (i,j)in ruinedOranger) {

                if (j < lista.lista[i].Count - 1)
                {
                    lista.lista[i][j + 1].Zdrava = false;


                }
                if (i < lista.lista.Count - 1)
                {
                    lista.lista[i + 1][j].Zdrava = false;
                }

                if (j > 0)
                {
                    lista.lista[i][j - 1].Zdrava = false;
                }
                if (i > 0)
                {
                    lista.lista[i - 1][j].Zdrava = false;

                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PokvariOranges(lista);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
