using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProbniZavrsniAna
{
    class Klijent
    {
        public int KlijentId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime Datum_rodjenja { get; set; }
        public string Br_vozacke_dozvole { get; set; }
        public string Kontakt_telefon { get; set; }

        public string Email { get; set; }

        public override string ToString()
        {
            return Ime + "  " + Prezime;
        }

       
    }
}
