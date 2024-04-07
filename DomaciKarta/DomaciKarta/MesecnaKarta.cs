using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomaciKarta
{
    internal class MesecnaKarta : Karta<DateTime>
    {
		private DateTime datumVazenja;
		private string ime;
        public MesecnaKarta(string ime, DateTime datumVazenja,int id):base(id)
        {

            Ime = ime;
            DatumVazenja = datumVazenja;
        }
        public string Ime
		{
			get { return ime; }
			set { ime = value; }
		}
		public DateTime DatumVazenja
		{
			get { return datumVazenja; }
			set { datumVazenja = value; }
		}

        public override bool IsValid(DateTime zadatiDatum)
        {

            if(zadatiDatum == null)
            {
                Console.WriteLine("zadati datum nije ispravan");
                return false;
            }
            if(DatumVazenja > zadatiDatum )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ProduziKartu(int month,int year)
        {
            DatumVazenja= DatumVazenja.AddMonths(month);
            DatumVazenja= DatumVazenja.AddYears(year);
        }

        public override string ToString()
        {
            return $"Karta {Ime} traje do {DatumVazenja}";
        }
    }
}
