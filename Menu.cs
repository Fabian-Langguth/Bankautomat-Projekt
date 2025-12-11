using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankautomat_Projekt
{
     abstract class Menu

    {
        public Menu()
        {
            Console.Clear();
            
        }

        public abstract void DisplayMenu();

        public abstract Menu GetnextMenu();

            

    }
}

