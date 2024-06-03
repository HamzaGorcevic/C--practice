using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Connecting_XAML_C_
{
    public class Student : INotifyPropertyChanged
    {
        private int year;

        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public int Year
        {
            get { return year; }
            set
            {
                year = value; OnPropertyChanged();
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged.Invoke(this,new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
