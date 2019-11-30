using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Ympyra : KaksiUlotteinenMuoto
    {
        public string tyyppi { get; set; }
        public double pii = Math.PI;
        public double sade { get; set; }
        public double halkaisija { get; set; }
        public double piiri { get; set; }
        public double pintaAla { get; set; }

        // Pinta-ala property lasketaan heti konstruktorissa, rajapintaan määritetyssä ja 
        // isäntä-luokalta peritystä LaskePintaAla() -metodilla.

        public Ympyra(double sade)
        {
            this.tyyppi = this.GetType().FullName;
            this.sade = sade;
            this.halkaisija = 2 * sade;
            this.piiri = LaskePiiri();
            this.pintaAla = LaskePintaAla();
        }
        public override double LaskePintaAla()
        {
            return pii * Math.Pow(sade, 2);
        }
        private double LaskePiiri()
        {
            return 2 * pii * sade;
        }
    }
}
