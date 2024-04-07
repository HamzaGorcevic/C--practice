using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerNasledjivanja
{
    internal class AvioKompanija
    {
		private Let[] letovi;
		private int brLetova;
		private int maxBrLetova;

		public int MaxBrLetova
		{
			get { return maxBrLetova; }
			set { maxBrLetova = value; }
		}

		public int BrLetova
		{
			get { return brLetova; }
			set { brLetova = value; }
		}
		

		public Let[] Letovi
		{
			get { return letovi; }
			set { letovi = value; }
		}

        public AvioKompanija(int maxBrLetova)
        {
            this.maxBrLetova = maxBrLetova;
            this.brLetova = 0;
			letovi = new Let[maxBrLetova];
        }
		// dodavanje leta
		// rezervisi let
		// brisanje leta
		// sortiranje letova po datumu
		// to strin metoda

		public void DodajLet(Let let)
		{
			// let je referenca kad god ga promenimo promenice se i u glavnom nizu
			if(brLetova == maxBrLetova)
			{
				return;
			}
			if(let is Charter)
			{
				Charter temp = let as Charter;
				letovi[brLetova++] = new Charter(temp.PolaznaDestinacija, temp.DolaznaDestinacija,
					temp.DatumVemePoletanja, temp.BrRezervisanihMesta, 
					temp.BrMestaRedovni, temp.BrMestaVanredni);
			}
			else
			{
                RedovniLet temp = let as RedovniLet;

                letovi[brLetova++] = new RedovniLet(
				
                    temp.PolaznaDestinacija,
                    temp.DolaznaDestinacija,
                    temp.DatumVemePoletanja,
                    temp.BrRezervisanihMesta,
					temp.BrMestaUAvionu

                    );

            }
			
		}
		public void BrisanjeLeta(Let let)
		{
			int index = -1;
			for(int i = 0; i < brLetova; i++)
			{
				if (letovi[i].PolaznaDestinacija == let.PolaznaDestinacija &&
					letovi[i].DolaznaDestinacija == let.DolaznaDestinacija &&
					letovi[i].DatumVemePoletanja == let.DatumVemePoletanja)
				{
					index = 1;break;

				}
			}
			if(index > -1)
			{
				for(int i = index; i < brLetova - 1; i++)
				{
					letovi[i] = letovi[i + 1];
				}
				BrLetova--;
			}
			
		}

		public void RezervisiKart(string pd,string dd,DateTime dv)
		{
			for(int i = 0; i < brLetova; i++)
			{
				if (letovi[i].PolaznaDestinacija == pd && letovi[i].DolaznaDestinacija ==dd && letovi[i].DatumVemePoletanja == dv)
				{
					if (letovi[i].Rezervisi() == true)
					{
						return;
					}
				}
			}
		}

		public void PoredjajLetove()
		{
			for(int i = 0; i < brLetova; i++)
			{
				for(int j = 0; j < brLetova; j++)
				{
					if (letovi[i].BrRezervisanihMesta < letovi[j].BrRezervisanihMesta)
					{
                        (letovi[j], letovi[i]) = (letovi[i], letovi[j]);
                    }

                }
			}
		}
        public override string ToString()
        {

			string s = "Podaci o avio kopmpaniji " + Environment.NewLine;

			for(int i = 0; i < brLetova; i++)
			{
				s += letovi[i].ToString() + Environment.NewLine;
			}
			return s;

        }
    }
}
