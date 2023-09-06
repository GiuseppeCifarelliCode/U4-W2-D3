using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniBanca
{
    internal class ContoCorrente
    {
        public string NomeCorrentista { get; set; }
        public string CognomeCorrentista { get; set; }
        public DateTime DataApertura { get; set; }
        public int NrConto { get; set; }
        public double Saldo { get; set; } 

        public ContoCorrente() { }

        public ContoCorrente(string nomeCorrentista, string cognomeCorrentista)
        {
            NomeCorrentista = nomeCorrentista;
            CognomeCorrentista = cognomeCorrentista;
            DataApertura = DateTime.Now;
            Saldo = 0;
        }

        public ContoCorrente(string nomeCorrentista, string cognomeCorrentista, DateTime dataApertura, int nrConto, double saldo)
        {
            NomeCorrentista = nomeCorrentista;
            CognomeCorrentista = cognomeCorrentista;
            DataApertura = dataApertura;
            NrConto = nrConto;
            Saldo = saldo;
        }
    }
}
