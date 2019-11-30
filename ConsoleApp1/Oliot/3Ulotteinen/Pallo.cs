using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Pallo : KolmeUlotteinenMuoto
    {
        //public string tyyppi { get; set; }
        private Ympyra ympyra;
        public double pintaAla { get; set; }
        public double tilavuus { get; set; }
        public double piiri { get; set; }

        public Pallo()
        {

        }

        // Annetaan konstruktorille olemassa oleva ympyra olio parametriksi
        // ympyran olion kenttiä hyödyntäen luodaan uusi Pallo -olio
        public Pallo(Ympyra y)
        {
            //this.tyyppi = this.GetType().FullName;
            this.ympyra = y;
            this.pintaAla = LaskePintaAla();
            this.tilavuus = LaskeTilavuus();
            this.piiri = y.piiri;
        }
        // Tai vaihtoehtoisesti jos halutaan alustaa eri kokoisen pallo -
        // toisena vaihtoehtona on antaa parametriksi säde jolla käydään
        // ensiksi luomassa uusi Ympyra-olio jota hyödyntäen rakennetaan uusi Pallo.
        public Pallo(double sade)
        {
            //this.tyyppi = this.GetType().FullName;
            this.ympyra = new Ympyra(sade);
            this.pintaAla = LaskePintaAla();
            this.tilavuus = LaskeTilavuus();
            this.piiri = ympyra.piiri;
        }
        public double LaskePintaAla()
        {
            return 4 * ympyra.pii * Math.Pow(ympyra.sade, 2);
        }
        public override double LaskeTilavuus()
        {
            return 4 * ympyra.pii * Math.Pow(ympyra.sade, 3) / 3;
        }


        public override string ToString()
        {
            return " pinta-ala: " + pintaAla + " tilavuus: " + tilavuus + " piiri: " + piiri;
        }
    }
}
