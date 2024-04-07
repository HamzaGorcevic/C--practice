using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerNasledjivanja
{
    abstract class Let
    {
		private string polaznaDestinacija;
		private string dolaznaDestinacija;
        private DateTime datumVremePoletanja;
        private int brRezervisanihMesta;



        public string PolaznaDestinacija
		{
			get { return polaznaDestinacija; }
			set { polaznaDestinacija = value; }
		}

		public string DolaznaDestinacija
		{
			get { return dolaznaDestinacija; }
			set { dolaznaDestinacija = value; }
		}


		public DateTime DatumVemePoletanja
		{
			get { return datumVremePoletanja; }
			set { datumVremePoletanja = value; }
		}


		public int BrRezervisanihMesta
		{
			get { return brRezervisanihMesta; }
			set { brRezervisanihMesta = value; }
		}

        public Let(string polaznaDestinacija, string dolaznaDestinacija, DateTime datumVremePoletanja, int brRezervisanihMesta)
        {
            this.polaznaDestinacija = polaznaDestinacija;
            this.dolaznaDestinacija = dolaznaDestinacija;
            this.datumVremePoletanja = datumVremePoletanja;
            this.brRezervisanihMesta = brRezervisanihMesta;
        }

		public abstract bool Rezervisi();




      
    }
}
