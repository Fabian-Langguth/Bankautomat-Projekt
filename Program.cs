// See https://aka.ms/new-console-template for more information
using System;
using Bankautomat_Projekt;

namespace Bankautomat_Projekt
{
    class Program
    {
        static void Main()
        {
            Menu currentMenu = new MainMenu();
            while (currentMenu != null)
            {
                Console.Clear();
                currentMenu.DisplayMenu();
                currentMenu = currentMenu.GetnextMenu();
            }
            Console.WriteLine("Programm beendet.");
        }
    }
}