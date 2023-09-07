using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniBanca
{
    internal class Movimento
    {
        public string Tipo;

        public double Importo { get; set; }

        public int NrConto;

        public Movimento() { }

        public Movimento(double importo)
        {
            Importo = importo;
        }
    }
}
