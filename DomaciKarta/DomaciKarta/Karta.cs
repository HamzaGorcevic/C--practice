using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomaciKarta
{
    abstract class Karta<T>
    {
        private int id;
		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		public Karta(int id=0)
		{
			this.id = id;

		}
		public abstract bool IsValid(T toValidate);
	}
}
