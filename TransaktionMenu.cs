using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Bankautomat_Projekt
{
     class TransaktionMenu : Menu

    {
        [JsonRequired]
        private Profile aktuellesProfile;

        public TransaktionMenu(Profile profile)
        {
           aktuellesProfile = profile;

        }

        public override void DisplayMenu()
        {

            Console.WriteLine($"Profil {aktuellesProfile.Name} Der akutelle Kontostand beträgt: {aktuellesProfile.Kontostand} Euro ");
            Console.WriteLine("---------------");
            Console.WriteLine();
            Console.WriteLine("Was möchten sie tun.");
            Console.WriteLine("[1] Geld Einzahlen.");
            Console.WriteLine("[2] Geld Auszahlen.");
            Console.WriteLine("[3] Kontoauszug");
            Console.WriteLine("[4] Zurück zum Startmenu");
            
           
            
        }

        public override Menu GetnextMenu()
        {
            while (true)
            {
                Console.Write("Ihre Auswahl: ");
                string? aufruf = Console.ReadLine();

                if (!int.TryParse(aufruf, out int eingabe))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Ungültige Eingabe! Bitte eine Zahl eingeben.");
                    Console.ResetColor();
                    Console.ReadKey();
                    Console.Clear();
                    DisplayMenu(); // Option: Menü neu anzeigen
                    continue; // erneut fragen
                }

                switch (eingabe)
                {

                    case 1: // Einzahlung
                        {
                            decimal betrag;
                            bool gültig = false;
                            
                                Console.WriteLine("Welchen Betrag möchten Sie einzahlen?");
                                string betragEingabe = Console.ReadLine()!;

                               //  prüfen ob Eingabe eine Zahl ist && betrag positiv
                                gültig = decimal.TryParse(betragEingabe, out betrag) && betrag > 0;

                            if (gültig)
                            {
                                aktuellesProfile.Einzahlen(betrag);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"{betrag} Euro wurden eingezahlt. Neuer Kontostand {aktuellesProfile.Kontostand} Euro");
                                Console.ResetColor();
                                Console.ReadKey();
                                DatenService.SafeProfile(aktuellesProfile);
                                return this;


                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Fehler: Bitte geben Sie eine positive Zahl ein.");
                                Console.ResetColor();
                                Console.ReadKey();
                                return this;
                            }



                            

                        }
                    case 2: // Auszahlung
                        {
                            decimal betrag;
                            bool gültig= false;

                            do
                            {
                                // prüft ob die Eigabe eine Zahl ist &&  kleiner ist als Kontostand
                                Console.WriteLine("Geben sie bitten den Betrag ein den sie Abheben möchten:");
                                string betragAuszahlen = Console.ReadLine()!;
                                gültig = decimal.TryParse(betragAuszahlen,out betrag) && (betrag < aktuellesProfile.Kontostand);

                                if (!gültig) // Wenn TryParse fehlschlägt oder betrag größer als Kontostand
                                {

                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Auszahlung fehlgeschlagen: Kontostand nicht ausreichend!");
                                    Console.WriteLine("Geben sie back ein wenn sie zum Menu zurückkehren wollen");
                                    Console.WriteLine();
                                    Console.ResetColor();
                                    string fehler = Console.ReadLine()!;

                                    if(fehler == "back")
                                    {
                                        return new TransaktionMenu(aktuellesProfile);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Geben sie back ein oder eine Zahl die sie abheben können");

                                    }
                            

                                }
                               
                            } while (!gültig);

                            aktuellesProfile.Auszahlen(betrag);
                            
                            Console.WriteLine($"Auszahlung erfolgreich der Betrag von {betrag}  Euro wurde abgebucht. Neuer Kontostand {aktuellesProfile.Kontostand} Euro");
                            Console.ReadKey();
                            DatenService.SafeProfile(aktuellesProfile);
                            return this;
                        }
                    case 3: // Kontoauszug
                        {
                            Console.WriteLine("---------------");
                            Console.WriteLine($"Kontoauszug für: {aktuellesProfile.Name}");
                            Console.WriteLine($"Aktueller Kontostand: {aktuellesProfile.Kontostand} Euro");
                            Console.WriteLine("Transaktionen:");
                            if (aktuellesProfile.NewTransaktions == null || aktuellesProfile.NewTransaktions.Count == 0)
                            {
                                Console.WriteLine("Keine Transaktionen vorhanden.");
                            }
                            else
                            {
                                foreach (var t in aktuellesProfile.NewTransaktions)
                                {
                                    Console.WriteLine($"{t.Zeitpunkt:yyyy-MM-dd HH:mm} | {t.Typ} | {t.Betrag} Euro");
                                }
                            }
                            Console.WriteLine("---------------");
                            Console.WriteLine("Beliebige Taste drücken um fortzufahren...");
                            Console.ReadKey();
                            return this;
                        }
                    case 4: // Startmenü
                        {
                            DatenService.SafeProfile(aktuellesProfile);
                            return new MainMenu();

                    }
                    default:
                        Console.WriteLine("Ungütlige Auswahl. bitte geben sie eine der verwendeten Zahlen 1 bis 4 ein, bitte erneut versuchen");
                        Console.ReadKey();
                        return this;

                }
            }
        }
    }
}
