using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerNasledjivanja
{
    internal class Charter : Let
    {
        private int brMestaRedovni;
        private int brMestaVanredni;

        public int BrMestaVanredni
        {
            get { return brMestaVanredni; }
            set { brMestaVanredni = value; }
        }


        public int BrMestaRedovni
        {
            get { return brMestaRedovni; }
            set { brMestaRedovni = value; }
        }

        public Charter(string polaznaDestinacija, string dolaznaDestinacija, DateTime datumVremePoletanja, int brRezervisanihMesta, int brMestaRedovni, int brMestaVanredni) : base(polaznaDestinacija, dolaznaDestinacija, datumVremePoletanja, brRezervisanihMesta)
        {
            this.brMestaRedovni = brMestaRedovni;
            this.brMestaVanredni = brMestaVanredni;
        }

        public override bool Rezervisi()
        {
            Console.WriteLine($"Broj mesta brMesta:{brMestaRedovni + BrMestaVanredni},brRez:{BrRezervisanihMesta}");

            if (BrRezervisanihMesta <brMestaRedovni + brMestaVanredni)
            {
                BrRezervisanihMesta++;
                return true;
            }
            Console.WriteLine("Nema mesta u avionu");
            return false;
        }
        public override string ToString() {
            return $"na charter letu od {PolaznaDestinacija} do {DolaznaDestinacija} koji leti {DatumVemePoletanja:dd.MM.yyyy HH.mm:ss}" +
            $" ima {BrRezervisanihMesta} rezervisanih mesta,od ukupno {BrMestaRedovni+brMestaVanredni}";
        }
    }
}
