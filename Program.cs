using System;
using static System.Console;


namespace AuctionHouse
{
    public class Program
    {
        static void Main(string[] args)
        {
            MainMenu menu = new MainMenu();
            menu.menu(args);
        }
    }
}