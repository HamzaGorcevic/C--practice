using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace junski2024.Classes
{
    public class Red
    {
        int brPutnika;
        Queue<Putnik> putnici;
        private TextBlock opis;

        public TextBlock Opis { get { return opis; } set { opis = value; opis.Text = this.ToString();} }


         public Red(int br) {
            brPutnika = br;
            opis = new TextBlock();
            putnici = new Queue<Putnik>();
         }

        public void DodajURed(Putnik putnik)
        {
            if(putnici.Count < brPutnika)
            {
                putnici.Enqueue(putnik);
                Opis.Text = this.ToString();
            }
            else
            {

                throw new Exception("NEMA GDE");
            }

        }

        public Putnik IzbaciIzReda()
        {
            if(Dohvati() > 0)
            {
                Opis.Text = this.ToString();

                return putnici.Dequeue();
            }
            else
            {
                MessageBox.Show("prazan je");
                return null;
            }
        }
        public int Dohvati()
        {
            return putnici.Count;
        }
        public bool isFull()
        {
            return Dohvati() == brPutnika;
        }


        public override string ToString()
        {
            string opisString = "";
            foreach (var item in putnici)
            {
                if(item != null)
                {
                    opisString += item.ToString() + "\n";

                }
            }
            return opisString;
        }


    }
}
