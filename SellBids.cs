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

            string choice = ReadLine().ToLower();

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

        private void SellProduct(string[] args, string[] credentials, string[,] bids){
            WriteToFile fileRead = new WriteToFile();
            MainMenu menu = new MainMenu();

            const string FILENAME = "products.csv";
            const string SALESFILE = "sales.csv";
            const string PRODUCT = "Please enter an integer between 1 and {0}:\n> ";
            const string CONFIRM = "You have sold {0} to {1} for {2}.";

            Write(PRODUCT, bids.GetLength(0));
            string product = ReadLine();
            string[] soldProduct = new string[8];

            int productBid = 0;

            try {
                productBid = Convert.ToInt32(product) - 1;
                if (productBid > bids.GetLength(0) || productBid < 0){
                    WriteLine("Invalid Input");
                    SellProduct(args, credentials, bids);
                }
            } catch {
                WriteLine("Invalid Input");
                SellProduct(args, credentials, bids);
            }
            string productString = "";
            for (int i = 0; i < bids.GetLength(1); i++){
                productString += bids[productBid, i] + "‗";
            }

            soldProduct[0] = bids[productBid, 2]; // seller email
            soldProduct[1] = bids[productBid, 3]; // product name
            soldProduct[2] = bids[productBid, 4]; // description
            soldProduct[3] = bids[productBid, 5]; // List Price
            soldProduct[4] = bids[productBid, 8]; // amount paid
            soldProduct[5] = bids[productBid, 6]; // user
            soldProduct[6] = bids[productBid, 7]; // email
            soldProduct[7] = bids[productBid, 9]; // date

            string soldProductString = "";
            for (int i = 0; i < soldProduct.GetLength(0); i++){
                soldProductString += soldProduct[i] + "‗";
            }

            soldProductString = soldProductString.TrimEnd('‗');

            fileRead.Write(SALESFILE, soldProductString);

            productString = productString.Remove(productString.Length - 1, 1);
            fileRead.RemoveLine(FILENAME, productString);

            WriteLine(CONFIRM, soldProduct[3], soldProduct[0], soldProduct[5]);

            menu.clientMenu(credentials, args);
        }
    }
}