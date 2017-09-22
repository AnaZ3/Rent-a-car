using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbniZavrsniAna
{
    class Tip
    {
        public int TipId { get; set; }
        public string Naziv_tipa { get; set; }

        public override string ToString()
        {
            return Naziv_tipa;
        }
    }
}
