using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUpProject
{
    public class Student:INotifyPropertyChanged
    {
        private string ime, prezime, telefon;
        private int godina;

        public int Godina
        {
            get { return godina; }  
            set { godina = value;
                onPropertyChanged();    
            } 
        }
        public string Ime
        {
            get { return ime; } 
            set { ime = value;
                onPropertyChanged();
            }
        }
        public string Prezime
        {
            get { return prezime; }
            set { prezime = value;
                onPropertyChanged();
            }
        }
        public string Telefon
        {
            get { return telefon; }
            set { telefon = value;
                onPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void onProperyChanged([])
    }
}
