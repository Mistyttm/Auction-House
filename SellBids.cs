using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

namespace AuctionHouse
{
    public class SellBids
    {
        public void SellBegin(string[] args, string[] credentials, string[,] bids){
            const string SELL = "Would you like to sell something (yes or no)?\n> ";

            Write(SELL);

            string choice = ReadLine().ToLower;

            switch (choice){
                case "yes":
                    SellProduct(args, credentials, bids);
                    break;
                case "no":
                    MainMenu menu = new MainMenu();
                    menu.clientMenu(credentials, args);
                    break;
                default:
                    WriteLine("Invalid input");
                    SellBegin(args, credentials, bids);
                    break;
            }
        }

        private void SellProduct(string[] args, string[] credentials, string[] bids){
            const string PRODUCT = "Please enter an integer between 1 and {0}:\n> ";
            const string CONFIRM = "You have sold {0} to {1} for {2}.";

            Write(PRODUCT, bids.GetLength(0));
            string product = ReadLine();
            try {
                int productBid = Convert.ToInt32(product) - 1;
            } catch {
                WriteLine("Invalid input");
                SellProduct(args, credentials, bids);
            }
        }
    }
}