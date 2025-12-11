using System;

namespace Bankautomat_Projekt
{
    class MainMenu : Menu
    {
        public override void DisplayMenu()
        {
            Console.WriteLine("Willkommen bei ihrem Bank Institut:");
            Console.WriteLine("Was möchten sie tun?");
            Console.WriteLine("Geben sie bitte die gewünschte Zahl ein.");
            Console.WriteLine("[1] Zum ProfileMenu");
            Console.WriteLine("[2] Karte Ausgeben");
            Console.Write("Eingabe: ");
        }

        public override Menu GetnextMenu()
        {
            string? eingabe = Console.ReadLine();
            if (int.TryParse(eingabe, out int input))
            {
                switch (input)
                {
                    case 1: 
                        { 
                            return new ProfileMenu();
                        }
                    case 2:
                        {


                            Console.WriteLine("Ihre Karte wird ausgegeben, vielen dank für ihren Besuch.");
                            Console.ReadKey();
                            Environment.Exit(0);
                            return null;
                        }
                    default:
                        {
                            Console.WriteLine("Ungültige Auswahl. Drücke eine Taste.");
                            Console.ReadKey();
                            return this;
                        }
                }
            }

            Console.WriteLine("Ungültige Eingabe. Drücke eine Taste.");
            Console.ReadKey();
            return this;
        }
    }
}

