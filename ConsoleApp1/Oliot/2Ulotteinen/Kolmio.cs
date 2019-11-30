using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Kolmio : KaksiUlotteinenMuoto
    {
        public string tyyppi { get; set; }
        public double kanta { get; set; }
        public double korkeus { get; set; }
        public double pintaAla { get; set; }

        // Pinta-ala property lasketaan heti konstruktorissa, rajapintaan määritetyssä ja 
        // isäntä-luokalta peritystä LaskePintaAla() -metodilla.

        public Kolmio(double kanta, double korkeus)
        {
            this.tyyppi = this.GetType().FullName;
            this.kanta = kanta;
            this.korkeus = korkeus;
            this.pintaAla = LaskePintaAla();
        }

        public override double LaskePintaAla()
        {
            return kanta * korkeus / 2;
        }
    }
}
