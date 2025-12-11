using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Bankautomat_Projekt
{
    class Transaktion
    {
        public string Typ { get; set; }
        public decimal Betrag { get; set; }
        public DateTime Zeitpunkt { get; set; }

        public Transaktion(string typ, decimal betrag, DateTime zeit)
        {
            Typ = typ;
            Betrag = betrag;
            Zeitpunkt = zeit;
        }

        public override string ToString()
        {
            return ($"Typ: {Typ} | Zeitpunkt: {Zeitpunkt.ToShortDateString()} | Betrag: {Betrag} Euro.");
        }
    }
}

