using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbniZavrsniAna
{
    class Iznajmljivanje
    {
        public int IznajmljivanjeId { get; set; }
        public int AutomobilId { get; set; }
        public DateTime Datum_preuzimanja { get; set; }
        public DateTime Datum_vracanja { get; set; }
        public int Iznajmljivanje_klijentId { get; set; }
        public decimal Ukupna_cena { get; set; }


        public override string ToString()
        {
            return IznajmljivanjeId.ToString();
        }
        public int OpisId { get; set; }
    }

}
