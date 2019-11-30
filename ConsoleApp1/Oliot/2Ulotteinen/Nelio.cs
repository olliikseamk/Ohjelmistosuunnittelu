using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Nelio : KaksiUlotteinenMuoto
    {
        public string tyyppi { get; set; }
        public double sivunPituus;
        public double lavistajanPituus { get; set; }
        public double pintaAla { get; set; }

        // Pinta-ala property lasketaan heti konstruktorissa, rajapintaan määritetyssä ja 
        // isäntä-luokalta peritystä LaskePintaAla() -metodilla.

        public Nelio(double sivunPituus)
        {
            this.tyyppi = this.GetType().FullName;
            this.sivunPituus = sivunPituus;
            this.lavistajanPituus = 2 * sivunPituus * Math.Sin(45);
            this.pintaAla = LaskePintaAla();
        }

        public override double LaskePintaAla()
        {
            return sivunPituus * 2;
        }

    }
}
