using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static List<I2dMuoto> lista2D = new List<I2dMuoto>();
        static List<Pallo> pallot = new List<Pallo>();
        
        static void Main(string[] args)
        {
            
            // Muodostaa 4x4 satunnaisilla arvoilla luotua oliota listaan.
            // Nämä oliot alustetaan staattiseen yllä olevaan listaan.
            LuoLista();

            // I2dMuoto = kaksiulotteinen muoto
            I2dMuoto nelio = new Nelio(4);
            I2dMuoto ympyra = new Ympyra(4);
            lista2D.Add(nelio);

            // Pallo -olion voi luoda käyttäen olemassa olevaa Ympyra oliota
            // tässä tehty I2dMuoto ympyra:lle tyyppi muunnos
            // koska Pallo konstruktorin parametriksi määritelty Ympyrä -tyyppi.
            Pallo pallo = new Pallo(ympyra as Ympyra);

            // Pallon voi myös luoda antaen parametrinä uuden säteen.
            // Tämä luo Pallo konstruktorin sisällä uuden ympyrä-olion,
            // joka sisältyy palloon..
            Pallo pallo2 = new Pallo(12.2);

            // I3dMuoto = kolmiulotteinen muoto
            I3dMuoto pallo3 = new Pallo(42);

            // Tallennetaan lista JSON-muotoiseen tiedostoon.
            Tallenna2dLista(lista2D);
            System.Console.WriteLine("Tiedot talletettu tiedostoon.");

            Console.WriteLine();


            pallot.Add(pallo);
            pallot.Add(pallo2);
            pallot.Add((Pallo)pallo3);

            // C:/temp/pallot.json
            // Talletetaan ja sarjallistetaan lista palloista JSON-muotoiseen tiedostoon.
            TalletaPallotListaTiedostoon(pallot);
            Console.WriteLine("Lista palloista talletettu tiedostoon.");
            Console.WriteLine();

            // Luodaan uusi lista Palloista lukemalla JSON-muotoon sarjallistetusta Pallo-olioista.
            List<Pallo> pallot2 = LuoPallotListaTiedostosta();
            Console.WriteLine("Luotu uusi lista tiedostosta luettuna");
            Console.WriteLine("Tiedostosta noudetut pallot:");
            foreach (Pallo p in pallot2)
            {
                Console.WriteLine(p.ToString());
            }
            Console.ReadLine();
        }



        static void LuoLista()
        {
            // Luodaan satunnaisluvun avulla for-loopin sisällä olioita, joka alustetaan listaksi.
            Random gen = new Random();
            I2dMuoto nelio, kolmio, ympyra, suorakulmio;
            int x, y;
            for (int i = 0; i < 4; i++)
            {
                x = gen.Next(100);
                y = gen.Next(95);
                nelio = new Nelio(x);
                kolmio = new Kolmio(x, y);
                ympyra = new Ympyra(x);
                suorakulmio = new Suorakulmio(x, y);
                lista2D.Add(nelio);
                lista2D.Add(kolmio);
                lista2D.Add(ympyra);
                lista2D.Add(suorakulmio);
            }
        }


        /* Sarjallistetaan lista olioista JSON muotoon. */
        static void Tallenna2dLista(List<I2dMuoto> lista)
        {
            
            using (StreamWriter sw = new StreamWriter(@"C:\temp\db.json"))
            {
                foreach (var item in lista)
                {
                    var _json = JsonConvert.SerializeObject(item);
                    sw.WriteLine(_json);
                    sw.Flush();
                }
            }
        }




        /* Sarjallistetaan lista olioista JSON muotoon. */
        static void TalletaPallotListaTiedostoon(List<Pallo> lista)
        {

            using (StreamWriter sw = new StreamWriter(@"C:\temp\pallot.json"))
            {
                string _json = JsonConvert.SerializeObject(lista, Formatting.Indented);

                sw.WriteLine(_json);
                sw.Flush();
            }
        }

        /* Luetaan olemassa olevasta json-tiedostosta */
        static List<Pallo> LuoPallotListaTiedostosta()
        {
            List<Pallo> lista = new List<Pallo>();
            string file = @"C:\temp\pallot.json";
            using (StreamReader sr = File.OpenText(file))
            {
                IEnumerable<Pallo> result = JsonConvert.DeserializeObject<IEnumerable<Pallo>>(sr.ReadToEnd());
                foreach (Pallo item in result)
                {
                    lista.Add(item);
                }
                sr.Close();
                sr.Dispose();
            }
            
            return lista;
        }
    }
}