using System;
using static System.Console;


namespace AuctionHouse
{
    public class Program
    {
        static void Main(string[] args)
        {
            WriteToFile createFile = new WriteToFile(); // Access Database
            MainMenu menu = new MainMenu(); // Access MainMenu

            // Check if registeredUsers file exists
            if (!File.Exists("databases/registeredUsers.csv")) {
                createFile.CreateFile("registeredUsers.csv");
            }

            // Check if products file exists
            if (!File.Exists("databases/products.csv")){
                createFile.CreateFile("products.csv");
            }

            // Check if bids file exists
            if (!File.Exists("databases/sales.csv")) {
                createFile.CreateFile("sales.csv");
            }

            WriteLine("+------------------------------+\n| Welcome to the Auction House |\n+------------------------------+\n");

            menu.homeMenu(args);
        }
    }
}