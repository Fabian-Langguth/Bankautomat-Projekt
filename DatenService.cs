using System.IO;
using Newtonsoft.Json;

namespace Bankautomat_Projekt
{
    static class DatenService
    {
        private const string Ordnername = "BankProfileDaten"; // const = Konstante unveränderbar

        private static string BasisPfad() // Basispfad zum Ornder
        {
            string desktopPfad = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string zielPfad = Path.Combine(desktopPfad, Ordnername);
            return zielPfad;
        }
        

        private static string CreateOrdner() // Erstellt  den Ordner
        {
            string ordnerName = "BankProfileDaten";
            string desktopPfad = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string zielPfad = Path.Combine(desktopPfad,ordnerName);
            Directory.CreateDirectory(zielPfad);
            return zielPfad;
        }

      
        public static void CreateProfile(Profile profile) // Erstellt ein Profil und speichert es
        {
            string jsonString = JsonConvert.SerializeObject(profile);
            string basisOrdner = CreateOrdner();
            string jsonPfad = Path.Combine(CreateOrdner(), profile.Name + ".prof");
            File.WriteAllText(jsonPfad, jsonString);
            
        }


        public static void SafeProfile(Profile profile) // Speichert das aktuelle Profil
        {
            string jsonPfad = Path.Combine(BasisPfad(), profile.Name + ".prof");
            string jsonString = JsonConvert.SerializeObject(profile, Formatting.Indented);
            File.WriteAllText(jsonPfad, jsonString);
        }
        public static Profile LoadProfile(string profileName) // Laden des Profils
        {
            
            string jsonPfad = Path.Combine(BasisPfad(), profileName + ".prof");
          
            try
            {

                string jsonString = File.ReadAllText(jsonPfad);
                Profile? profile = JsonConvert.DeserializeObject<Profile>(jsonString);
                 if (File.Exists(jsonPfad)) 
                
                if(profile != null)
                {
                    return profile;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Fehler beim Laden vom {profileName}: {e.Message}");
                Console.ReadKey();
                return null; 
            }
            return null;
              
        }

            public static List<string> GetAllProfileNames() // Liste für alle Profile im Ordner
        {
                string zielPfad = BasisPfad(); // Pfad für den Desktop Ordner

                string[] filePaths = Directory.GetFiles(zielPfad, "*.prof");

                List<string> profileNames = new List<string>();
                foreach (string filePath in filePaths)
            {
               
                string fileName = Path.GetFileName(filePath);

               
                string profileName = Path.GetFileNameWithoutExtension(fileName);

                profileNames.Add(profileName);
            }

                return profileNames;
        }
    }

}

