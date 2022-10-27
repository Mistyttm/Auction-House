using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionHouse
{
    public class Exit
    {
        // Method for exiting the program
        public void endProgram(string[] args){
            Console.WriteLine("+--------------------------------------------------+\n| Good bye, thank you for using the Auction House! |\n+--------------------------------------------------+");
            Environment.Exit(0);
        }

        // Method for logging out
        public void logOut(string[] args){
            MainMenu menu = new MainMenu();
            menu.homeMenu(args);
        }
    }
}