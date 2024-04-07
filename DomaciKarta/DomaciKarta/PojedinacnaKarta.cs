using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomaciKarta
{
    internal class PojedinacnaKarta:Karta<float>
    {
		private float iznos;

		public float Iznos
		{
			get { return iznos; }
			set { iznos = value; }
		}

		public PojedinacnaKarta(int id,float iznos=50):base(id)
		{
			this.iznos = iznos;
		}

        public override bool IsValid( float uplata = 0)
        {

            if (uplata == 0)
            {
                Console.WriteLine("uplata nije validna");
                return false;
            }
            if (uplata < iznos)
            {
                Iznos -= uplata;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"Iznos karte je {Iznos}";
        }

    }
}
