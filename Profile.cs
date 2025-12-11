using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bankautomat_Projekt
{
    class Profile
    {
        public string Name { get; set; } = null!;
        public decimal Kontostand { get; private set; } // Verändern das Kontos nur  hier möglich, abrufen von überall

        public List<Transaktion> NewTransaktions { get; set; } = new List<Transaktion>(); // Liste der Transaktionen wird mit in die Datei geschrieben für Kontoauszüge

        public Profile(string name, decimal kontostand)
        {
            Name = name;
            Kontostand = kontostand;
        }

        public void Einzahlen(decimal betrag)
        {

            if (betrag <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Der Betrag muss positiv sein.");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            this.Kontostand += betrag;
            Transaktion transaktion = new Transaktion("Einzahlung", betrag, DateTime.Now);
            NewTransaktions.Add(transaktion);
        }

        public bool Auszahlen(decimal betrag)
        {
            if (this.Kontostand < betrag)
            {
                return false; // Auszahlung nicht möglich
            }

            this.Kontostand -= betrag;
            Transaktion transaktion = new Transaktion("Auszahlung", betrag, DateTime.Now);
            NewTransaktions.Add(transaktion);
            return true;
        }
    }
}
