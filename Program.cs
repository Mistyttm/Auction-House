using System;
using static System.Console;


namespace AuctionHouse
{
    public class Program
    {
        static void Main(string[] args)
        {
            WriteToFile createFile = new WriteToFile();
            MainMenu menu = new MainMenu();

            if (!File.Exists("databases/registeredUsers.csv")) {
                createFile.CreateFile("registeredUsers.csv", "\n");
            }

            if (!File.Exists("databases/products.csv")){
                createFile.CreateFile("products.csv", "\n");
            }

            WriteLine("+------------------------------+\n| Welcome to the Auction House |\n+------------------------------+\n");

            menu.homeMenu(args);
        }
    }
}