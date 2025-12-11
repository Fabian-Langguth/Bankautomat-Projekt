using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Bankautomat_Projekt;

namespace Bankautomat_Projekt
{
     class ProfileMenu : Menu  
    {
        
        
        public override void DisplayMenu()
        {
            
            Console.WriteLine("Was möchten sie tun?");
            Console.WriteLine("Geben sie bitte die gewünschte Zahl ein.");
            Console.WriteLine("[1] ein Profil Laden:");
            Console.WriteLine("[2] ein neues Profil erstellen:");
            


            
        }

        public override Menu GetnextMenu()
        {
            int eingabe;
            


            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out eingabe))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(" Ungütlige Eingabe! Bitte nur eine Ganzzahl 1 oder 2 eingeben.");
                    Console.ResetColor();
                    Console.WriteLine("Drücke eine Taste zum Fortfahren..");
                    Console.ReadKey();
                    Console.Clear();
                    return new ProfileMenu();

                    
                }


                switch (eingabe)
                {
                    case 1:
                        {
                            Console.WriteLine("Vorhandene Profile");
                            List<string> profileNames = DatenService.GetAllProfileNames();

                            if(profileNames.Count == 0) // Keine Profile
                            {
                                Console.WriteLine("Es sind keine Profile vorhanden. Bitte erstellen sie ein Profil");
                                Console.ReadKey();
                                break;
                            }
                            foreach(string name in profileNames) // Gibt die AKutell im Ordner befindeten Namen zurück
                            {
                                Console.WriteLine(name);
                            }
                            Console.WriteLine("-------------------------------------");
                            Console.WriteLine("Welches Profil soll geladen werden? ");
                            Console.WriteLine("Zum abbrechen bitte [\"back\"] schreiben. ");
                            string usereingabe = Console.ReadLine()!;


                            if (!string.IsNullOrWhiteSpace(usereingabe) && usereingabe.ToLower() == "back")
                            {
                                Console.WriteLine("Beliebige Taste drücken um zum Hauptmenü zurückzukehren.");
                                Console.ReadKey();
                                return new ProfileMenu();
                                
                            }
                            else
                            {
                                

                                Profile? profil = DatenService.LoadProfile(usereingabe);

                                if (profil != null)
                                {
                                    //  Profil erfolgreich geladen.


                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"Das Profil '{profil.Name}' wurde erfolgreich geladen.");
                                    Console.WriteLine("Beliebige Taste drücken zum fortführen");
                                    Console.ResetColor();
                                    
                                    Console.ReadKey();
                                    //  Menüwechsel zum TransaktionMenu wobei das geladene Profil übergeben wird.
                                    return new TransaktionMenu(profil);
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"\nFehler: Das Profil '{usereingabe}' konnte nicht gefunden oder geladen werden.");
                                    Console.ResetColor();
                                    Console.ReadKey();
                                    return new ProfileMenu();
                                }
                                                     
                                

                            }


                        }
                    case 2:
                        {
                            Console.WriteLine("----- Neues Profil erstellen -----");
                            string profileNameEingabe;
                            while (true)
                            {
                                Console.WriteLine("Wie soll das Profil heißen: ");
                                 profileNameEingabe = Console.ReadLine()!;

                                if (ProfileNameCheck(profileNameEingabe)) // Name ist gültig
                                {
                                    break;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Fehler: Der Profilname darf nicht leer sein und muss mindestens 4 Buchstaben enthalten.");
                                    Console.ResetColor();
                                    Console.ReadKey();


                                }

                            }

                            Profile neuesProfil = new Profile(profileNameEingabe, 0); // Profil wird erstellt und Kontostand auf 0 initalisiert
                            

                            DatenService.CreateProfile(neuesProfil);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Profil {profileNameEingabe} wurde erfolgreich angelegt.");
                            Console.ResetColor();
                            Console.WriteLine("Beliebige Taste drücken um zu Hauptmenü zurückzukehren.");
                            
                            Console.ReadKey();
                            return new MainMenu();
                            
                           
                        }
                   
                }

            }

        } private  static bool ProfileNameCheck(string input) // Prüft auf Eingabe ohne Sonderzeichen und Zahlen


        {
            if(input.Length < 4) {  return false; }
            if (string.IsNullOrWhiteSpace(input))
            {
                return false; // Leer ist ungültig
            }
            foreach (char c in input)
            {
                if(!char.IsLetter(c) && c !=' ')
                {
                    return false; // Zeichen ist ungültig
                }
            }
            return true;


        }
    }
}

