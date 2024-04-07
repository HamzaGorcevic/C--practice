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

namespace Zadatak2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public class Opstina
    {

        public int postBr { get; set; }
        public string nazivOp { get; set; }
        public int brojSt { get; set; }
    }
    public partial class MainWindow : Window
    {

            List<Opstina>opsitine = new List<Opstina>();
        public MainWindow()
        {
            InitializeComponent();
            spButtons.Visibility = Visibility.Hidden;

        }

        private float IzracunajProsek()
        {
            float s = 0;
            for(int i=0; i < lvOpstine.Items.Count; i++)
            {
                s += (lvOpstine.Items[i] as Opstina).brojSt;
            }
            if(lvOpstine.Items.Count > 0)
            {
                float prosek = s / lvOpstine.Items.Count;
                return prosek; 
            }

            return 0;
        }

        // dodati proveru prilikom opsine ne moze 2 puta isti post br

        public void dodajOpstinu(object sender , EventArgs e)
        {

            int postBr;
            int brojSt;

            MessageBox.Show(txtPB.Text);
            if (string.IsNullOrEmpty(txtPB.Text) || !int.TryParse(txtPB.Text, out postBr)) {
                MessageBox.Show("Unestie ispravan postanski broj");
                return;
            }
            if (string.IsNullOrEmpty(txtNO.Text))
            {
                MessageBox.Show("Unestie  naziv");
                return;

            }
            if (string.IsNullOrEmpty(txtBS.Text) || !int.TryParse(txtBS.Text, out brojSt))
            {
                MessageBox.Show("unestie ispravan broj");
                return;
            }

            string nazivOp = txtNO.Text;

            Opstina o = new Opstina
            {
                brojSt = brojSt,
                postBr = postBr,
                nazivOp = nazivOp
            };

            Opstina opstina = opsitine.FirstOrDefault(el => el.postBr == postBr);

        
            
         
            opsitine.Add(o);

            lvOpstine.ItemsSource = null;
            lvOpstine.ItemsSource = opsitine;
            txtPBS.Text =IzracunajProsek().ToString();
            txtBS.Text = "";
            txtPB.Text = "";
            txtNO.Text = "";
        }

        public void closeBtn(object sender, EventArgs e)
        {

            this.Close();
        }  


        public void odbijBrisanje(object sender,EventArgs e)
        {
            spButtons.Visibility = Visibility.Hidden;


        }

        public void potvrdiBrisanje(object sender,EventArgs e)
        {
            int index = lvOpstine.SelectedIndex;

            if (index > -1)
            {
                Opstina izbOpstinu = opsitine[index];
                opsitine.Remove(izbOpstinu);
                lvOpstine.ItemsSource = null;
                lvOpstine.ItemsSource = opsitine;
                txtPBS.Text = IzracunajProsek().ToString();

            }


        }



        public void izbOpstinu (object sender , EventArgs e)
        {
            spButtons.Visibility = Visibility.Visible;


        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Space)
            {
                MessageBox.Show("space is pressed \n ");
                this.Close();

            }

        }
    }
}
