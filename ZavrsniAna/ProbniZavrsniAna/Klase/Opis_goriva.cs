using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbniZavrsniAna
{
    class Opis_goriva
    {
        public int OpisId { get; set; }
        public string Opis { get; set; }
        public decimal Cena_goriva { get; set; }

        public override string ToString()
        {
            return Opis;
        }
    }
}
