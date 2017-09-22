using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbniZavrsniAna
{
    class Automobil
    {
        public int AutomobilId { get; set; }
        public int TipId { get; set; }
        public string Brend { get; set; }
        public string Model { get; set; }
        public int Godina_proizvodnje { get; set; }
        public string Boja { get; set; }
        public decimal Cena_po_danu { get; set; }
        public int StanjeId { get; set; }
        public int Kapacitet_sedista { get; set; }
        public int Broj_vrata { get; set; }
        public string Vrsta_menjaca { get; set; }
        public string Tip_goriva { get; set; }


        public override string ToString()
        {
            //return Brend + " " + Model;
           return $"{Brend} {Model}";
           
        }

        public string PrikaziStanje
        {
            get
            {
                string stanje = "";
                if (StanjeId == 1)
                {
                    stanje = "slobodan";
                }
                else
                {
                    stanje = "zauzet";
                }
                return stanje;
            }
        }


    }
}
