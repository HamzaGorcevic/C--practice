using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osnove
{
    internal class Slika
    {
		private string title;

		public string Title
		{
			get { return title; }
			set { title = value; }
		}

		public Slika() {
			title = "Nature";	
		}

		public static Slika Load(string url)
		{
			// ucitavanje slike sa interneta
			return new Slika();

		}
		public static void Save(Slika slika)
		{
			Console.WriteLine($"Snimljenej su nove promene na slici ${slika.Title}");

		}

		public void HandleSlika(ProcesSlike.PhotoProcessorHandler handler , Slika slika)
		{

			handler(slika);

		}

	}
}
