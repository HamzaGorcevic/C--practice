using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Common;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RabbitGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int matrixLength;

        private ObservableCollection<Figure> figures1;
        private ObservableCollection<Figure> figures2;  

        public ObservableCollection<Figure> Figures1 { set { figures1 = value; } get { return figures1;} }
        public ObservableCollection<Figure> Figures2 { set { figures2 = value; } get { return figures2; } }

        public int turn = 0;
        public Circle ChoosenFigure;

        public abstract class  Figure
        {
            public int i;
            public int j;
            public int canMoveLeft;
            public int canMoveRight;
            public int canMoveUp;
            public int canMoveDown;
            public int canMoveDiagonal;
            public Brush color;


            
            public Figure(int i,int j,int canMoveLeft,int canMoveRight, int canMoveUp,int canMoveDown,int canMoveDiagonal, Brush color)
            {
                this.i = i; 
                this.j = j;
                this.canMoveLeft = canMoveLeft;
                this.canMoveRight = canMoveRight;
                this.canMoveUp = canMoveUp;
                this.canMoveDown = canMoveDown;
                this.canMoveDiagonal = canMoveDiagonal;
                this.color = color;
            }

            public abstract void MoveFigure();
        }
        public class Circle : Figure,INotifyPropertyChanged
        {
            public Ellipse shape;

            public event PropertyChangedEventHandler PropertyChanged;

        
            public int I
            {
                get { return i; }
                set { i = value;
                    Grid.SetRow(shape, i);
                    onPropertyChanged();
                }
            }
            public int J
            {
                get { return j; }
                set { j = value;
                    Grid.SetColumn(shape, j);
                    onPropertyChanged();
                }
            }
            protected void onPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            public Circle(int i, int j, int canMoveLeft, int canMoveRight, int canMoveUp, int canMoveDown, int canMoveDiagonal,Brush color) : base(i, j, canMoveLeft, canMoveRight, canMoveUp, canMoveDown, canMoveDiagonal,color)
            {
                shape = new Ellipse
                {
                    Fill = color
                };

            }

            public override void MoveFigure()
            {

                
            }
        }
     
        public class Triangle : Figure
        {
            public Ellipse shape;
            public Triangle(int i, int j, int canMoveLeft, int canMoveRight, int canMoveUp, int canMoveDown, int canMoveDiagonal, Brush color) : base(i, j, canMoveLeft, canMoveRight, canMoveUp, canMoveDown, canMoveDiagonal, color)
            {
                shape = new Ellipse
                {
                    Fill = color
                };

            }

            public override void MoveFigure()
            {


            }
        }
        public class Square : Figure
        {
            public Ellipse shape;
            public Square(int i, int j, int canMoveLeft, int canMoveRight, int canMoveUp, int canMoveDown, int canMoveDiagonal, Brush color) : base(i, j, canMoveLeft, canMoveRight, canMoveUp, canMoveDown, canMoveDiagonal, color)
            {
                shape = new Ellipse
                {
                    Fill = color
                };

            }

            public override void MoveFigure()
            {


            }
        }

        public int MatrixLength
        {
            get { return matrixLength; }
            set { matrixLength = value; }
        }

        public MainWindow()
        {

            ChoosenFigure = new Circle(0,0,0,0,0,0,0,null);
            
            figures1=new ObservableCollection   <Figure>();
            figures2=new ObservableCollection <Figure>();
            matrixLength = 8;
            InitializeComponent();
            CreateBoard();
            PlaceFigures();
        }

        public void CreateBoard()
        {
            
            for(int j =0; j < matrixLength; j++)
            {
                RowDefinition row = new RowDefinition();
                ColumnDefinition column = new ColumnDefinition();
                gridBoard.ColumnDefinitions.Add(column);
                gridBoard.RowDefinitions.Add(row);

            }

            for(int i= 0; i < matrixLength; i++)
            {
                for (int j= 0; j < matrixLength; j++)
                {
                    TextBlock field = new TextBlock();

                    field.MouseDown += Field_MouseDown;

                    if((i+j) % 2 == 0)
                    {
                        field.Background = Brushes.Black;

                    }
                    else
                    {
                        field.Background= Brushes.White;
                    }

                    Grid.SetColumn(field, i);
                    Grid.SetRow(field, j);
                    gridBoard.Children.Add(field);

                }
            }


        }
        public void PlaceFigures()
        {
            Circle figure1 = new Circle(0, 3, 3, 3, 3, 3, 0, Brushes.Purple);
            Circle figure2 = new Circle(0, 1, 3, 3, 3, 3, 0, Brushes.Purple);
            Circle figure3 = new Circle(0, 0, 3,3, 3, 3, 0, Brushes.Purple);
            figures1.Add(figure1);
            figures1.Add(figure2);
            figures1.Add(figure3);


            Circle figure21 = new Circle(7, 2, 3, 3, 3, 3, 0, Brushes.Blue);
            Circle figure22 = new Circle(7, 1, 3, 3, 3, 3, 0, Brushes.Blue);
            Circle figure23 = new Circle(7, 3, 3, 3, 3, 3, 0, Brushes.Blue);


            figures2.Add(figure21);
            figures2.Add(figure23);
            figures2.Add(figure22);


            foreach (Circle item in figures2)
            {
                Grid.SetColumn(item.shape,item.j);
                Grid.SetRow(item.shape, item.i);

                item.shape.MouseDown += Shape_MouseDown;
                item.shape.Tag = item;
                gridBoard.Children.Add(item.shape);
                

            }

            foreach (Circle item in figures1)
            {
                Grid.SetColumn(item.shape, item.j);
                Grid.SetRow(item.shape, item.i);
                item.shape.Tag = item;

                item.shape.MouseDown += Shape_MouseDown;

                gridBoard.Children.Add(item.shape);



            }


        }
        public bool checkElementOnGrid(int x, int y, Brush color)
        {
            return  !gridBoard.Children.Cast<UIElement>().Any(el =>
                el is Ellipse ellipse &&
                Grid.GetRow(el) == x &&
                Grid.GetColumn(el) == y &&
                ellipse.Fill == color);
        }

        private void Shape_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Ellipse circle = (Ellipse)sender;
            Circle parentObject = (Circle)circle.Tag;

            ChoosenFigure.shape = circle;

            List<Rectangle> rects = gridBoard.Children.OfType<Rectangle>().Where((el)=>el.Tag=="showCase").ToList();

            foreach (var item in rects)
            {
                gridBoard.Children.Remove(item);
                
            }


            for (int i = parentObject.j +1; i <= parentObject.j + parentObject.canMoveRight; i++)
            {

                if (i >= 0 && i < 8 && checkElementOnGrid(parentObject.i,i,circle.Fill))
                {

                    Rectangle choosenDest = new Rectangle();
                    choosenDest.Fill = Brushes.Red;

                    
                    choosenDest.Tag = "showCase";

                    Grid.SetRow(choosenDest, parentObject.i);
                    Grid.SetColumn(choosenDest, i);
                    gridBoard.Children.Add(choosenDest);
                }
            }

            for (int i = parentObject.j -1;  i >= parentObject.j - parentObject.canMoveLeft  ; i-- )
            {

                if (i >= 0 && i < 8 && checkElementOnGrid(parentObject.i, i, circle.Fill))
                {
                    Rectangle choosenDest = new Rectangle();
                    choosenDest.Fill = Brushes.Red;
                    choosenDest.Tag = "showCase";

                    choosenDest.MouseDown += ChoosenDest_MouseDown;

                    Grid.SetRow(choosenDest, parentObject.i);
                    Grid.SetColumn(choosenDest, i);
                    gridBoard.Children.Add(choosenDest);
                }
            }



            for(int i=parentObject.i-1;  i >= parentObject.i - parentObject.canMoveUp; i--)
            {
                int var = parentObject.i + parentObject.canMoveUp;



                if (i >= 0 && i < 8 && checkElementOnGrid(i, parentObject.j, circle.Fill) )
                {
                    Rectangle choosenDest = new Rectangle();
                    choosenDest.Fill = Brushes.Red;
                    choosenDest.Tag = "showCase";
                    choosenDest.MouseDown += ChoosenDest_MouseDown;


                    Grid.SetRow(choosenDest, i);
                    Grid.SetColumn(choosenDest, parentObject.j);
                    gridBoard.Children.Add(choosenDest);
                }

            }
            for (int i = parentObject.i+1; i <= parentObject.i + parentObject.canMoveDown; i++)
            {
                if (i >= 0 && i < 8 && checkElementOnGrid(i, parentObject.j, circle.Fill))
                {
                    Rectangle choosenDest = new Rectangle();
                    choosenDest.Fill = Brushes.Red;
                    choosenDest.Tag = "showCase";
                    
                    choosenDest.MouseDown += ChoosenDest_MouseDown;


                    Grid.SetRow(choosenDest, i);
                    Grid.SetColumn(choosenDest, parentObject.j);
                    gridBoard.Children.Add(choosenDest);
                }

            }

        }

        private void ChoosenDest_MouseDown(object sender, MouseButtonEventArgs e)
        {
            List<Rectangle> rects = gridBoard.Children.OfType<Rectangle>().Where((el) => el.Tag == "showCase").ToList();

            foreach (var item in rects)
            {
                gridBoard.Children.Remove(item);

            }

            Rectangle rectangle = sender as Rectangle;
            int row = Grid.GetRow(rectangle);
            int column = Grid.GetColumn(rectangle);

            ChoosenFigure.I = row;
            ChoosenFigure.I = column;

        
        
        }

        private void Field_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
