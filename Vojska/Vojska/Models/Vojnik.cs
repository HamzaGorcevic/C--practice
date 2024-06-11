using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Vojska.Models
{
    public enum CinEnum { Razvodnik, Desetar, MladjiVodnik };

	public class Vojnik : INotifyPropertyChanged
	{

		private string ime;
		private CinEnum cin;

		public string Ime
		{
			get { return ime; }
			set { ime = value; }
		}

		private DateTime datumRodjenja;

		public event PropertyChangedEventHandler PropertyChanged;

		protected void onPropertyChanged([CallerMemberName] string property= null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

		}

        public DateTime DatumRodjenja
		{
			get { return datumRodjenja; }
			set { datumRodjenja = value; }
		}

        public CinEnum Cin
        {
            get { return cin; }
            set { cin = value;
				onPropertyChanged();			
			}	
        }


        public void UnaprediMe()
		{
			if(Cin == CinEnum.Razvodnik)
			{
				Cin = CinEnum.Desetar;

			}
			else
			{
				MessageBox.Show("Doslo je do gresek");
			}

		}






	}
}
