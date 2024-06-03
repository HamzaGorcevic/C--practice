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

namespace TreeView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Student s1 = new Student() { Name = "Hamza", Surname = "Gorcevic", Avarage = 10 };
            Student s2 = new Student() { Name = "Dzenan", Surname = "Demirovic", Avarage = 9 };
            Student s3 = new Student() { Name = "Andrej", Surname = "Rumenic", Avarage = 9 };
            Student s4 = new Student() { Name = "Andrej", Surname = "Rumenic", Avarage = 9 };

            SProgram sProgram = new SProgram() { Title = "Softversko Inz" };

            SProgram sProgram2 = new SProgram(){Title = "Racunarska Tehnika"};

            sProgram.Students.Add(s1);
            sProgram2.Students.Add(s2);
            sProgram2.Students.Add(s3);
            sProgram2.Students.Add(s4);

            List<SProgram> programi = new List<SProgram>
            {
                sProgram2,
                sProgram
            };

            trvStavke.ItemsSource =programi;




        

        }
    }
}
