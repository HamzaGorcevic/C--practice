using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerNasledjivanja
{
    class RedovniLet : Let
    {

        private int brMestaUAvionu;

        public int BrMestaUAvionu
        {
            get { return brMestaUAvionu; }
            set { brMestaUAvionu = value; }
        }

        public RedovniLet(string polaznaDestinacija, string dolaznaDestinacija, DateTime datumVremePoletanja, int brRezervisanihMesta, int brMestaUAvionu) : base(polaznaDestinacija, dolaznaDestinacija, datumVremePoletanja, brRezervisanihMesta)
        {
            this.brMestaUAvionu = brMestaUAvionu;
            

        }


        public override bool Rezervisi()
        {

            Console.WriteLine($"Broj mesta brMesta:{brMestaUAvionu},brRez:{BrRezervisanihMesta}");
            if (brMestaUAvionu > BrRezervisanihMesta)
            {
                BrRezervisanihMesta++;
                return true;
            }
            Console.WriteLine("Nema mesta");
            return false;
        }

      
        public override string ToString()
        {
            return $"na redovnom letu od {PolaznaDestinacija} do {DolaznaDestinacija} koji leti {DatumVemePoletanja:dd.MM.yyyy HH.mm:ss}" +
                $" ima {BrRezervisanihMesta} rezervisanih mesta,od ukupno{brMestaUAvionu}";
        }
       
    }
}
