using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
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
using static Domaci2.MainWindow;

namespace Domaci2
{

    public partial class MainWindow : Window
    {

        private string readDataPath = "taxiData.txt";
        private string writeDataPath = "taxiDataOutput.txt";
        public struct Taxi
        {
            public string VehicleType { get; set; }
            public string TaxiName { get; set; }
            public double PricePerKm { get; set; }
            public string Availability { get; set; }
            public Taxi(string vehicleType, string taxiName, double pricePerKm, string availability)
            {
                VehicleType = vehicleType;
                TaxiName = taxiName;
                PricePerKm = pricePerKm;
                Availability = availability;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            generateRandomData();
        }

        void generateRandomData()
        {

            try
            {

            var fs = new FileStream(readDataPath, FileMode.OpenOrCreate, FileAccess.Write);
            var sw = new StreamWriter(fs);

            Random random = new Random();

            string[] vehicleTypes = { "limuzina", "karavan" };
            string[] taxiNames = { "Pink", "Plavi", "Super", "Max", "Beli" };
            double[] pricesPerKm = { 3.5, 4.0, 4.5, 5.0, 5.5 ,2.5};
            string[] availabilities = { "+", "-" };

            for (int i = 0; i < 5; i++) 
            {
                string vehicleType = vehicleTypes[random.Next(vehicleTypes.Length)];
                string taxiName = taxiNames[random.Next(taxiNames.Length)];
                double pricePerKm = pricesPerKm[random.Next(pricesPerKm.Length)];
                string availability = availabilities[random.Next(availabilities.Length)];
                sw.WriteLine($"{vehicleType},{taxiName},{pricePerKm},{availability}");
            }

                sw.Close();
                fs.Close();

            }
            catch
            {
                MessageBox.Show("Greska pri otvaranju fajla");
            }
            


        }

        void AddIntoGrid(Taxi taxi) {
            TaxiesDataGrid.Items.Add(taxi);
        }


        private void GetData(string vehicleType)
        {
            var fs = new FileStream(readDataPath, FileMode.Open, FileAccess.Read);
            var sr = new StreamReader(fs);

            var fs1 = new FileStream(writeDataPath, FileMode.OpenOrCreate, FileAccess.Write);
            var sw = new StreamWriter(fs1);

            sw.BaseStream.SetLength(0);

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                string[] data = line.Split(',');
                if (data.Length > 3)
                {
                    string availability = data[3] == "+" ? "slobodan" : "zauzet";

                    if (vehicleType == data[0])
                    {
                       sw.WriteLine($"{data[0]}, {data[1]}, {data[2]}, {availability}");
                       
                    }
                }
            }

            sw.Close();
            fs1.Close();

            sr.Close();
            fs.Close();
            ShowDataInGrid();
        }
        private void ShowDataInGrid()
        {
            FileStream fs = new FileStream(writeDataPath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            TaxiesDataGrid.Items.Clear();
           


            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] data = line.Split(',');
                double price = double.Parse(data[2]);

                Taxi noviTaxt = new Taxi(data[0], data[1], price, data[3]);
                    AddIntoGrid(noviTaxt);
            }
            fs.Close();
            sr.Close();
        }
        

         private string CalculateKM()
        {
            var cheapest = TaxiesDataGrid.Items.Cast<Taxi>().OrderBy(taxi => taxi.PricePerKm).FirstOrDefault();
            int novac;
            string cheapestString;

            if (int.TryParse(tbMoney.Text, out novac) || cheapest.PricePerKm > novac)
            {
                cheapestString = $"Najeftini taxi je '{cheapest.TaxiName} ' i precicete , {novac / cheapest.PricePerKm}km\n";
                return cheapestString;

            }
            else
            {

                MessageBox.Show("Uneli ste prenisku cenu ili pogresan zapis");
                tbMoney.Focus();
                return "";
            }
        }
        private string CompanyMoney()
        {
            if(TaxiesDataGrid.Items.Count > 0) {
                int freeTaxi = 0;

                double countPrice = 0;
                foreach (Taxi item in TaxiesDataGrid.Items)
                {
                    if (item.Availability.Trim().ToLower() == "zauzet")
                    {
                        countPrice += item.PricePerKm * 0.1;
                    }
                    else
                    {
                        freeTaxi++;

                    }

                }



                return $"Kompanija ce zaraditi {double.Parse(tbMoney.Text) * (countPrice / 100)} po kilometru \nBroj slobodnih taksija je {freeTaxi}";
            }
            return "Nema dostupnih taxi-ja";
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (FileStream fs = new FileStream(writeDataPath, FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        string cheapestTaxi = CalculateKM();
                        string companyEarnings = CompanyMoney();
                        tbCompany.Text = companyEarnings;
                        tbTaxi.Text = cheapestTaxi;
                        sw.WriteLine(companyEarnings);
                        sw.WriteLine(cheapestTaxi);
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške prilikom pisanja u datoteku: {ex.Message}");
            }
        }


        private void CbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)cbType.SelectedItem;
            string selectedType = selectedItem.Content.ToString();
                GetData(selectedType);
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(writeDataPath);
        }
    }
}
