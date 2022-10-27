using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

namespace AuctionHouse
{
    public class Bidding
    {
        public void bid(string[] credentials, string[] args, string[,] products){
            WriteToFile fileRead = new WriteToFile();
            MainMenu menu = new MainMenu();
            Checks check = new Checks();
            Delivery delivery = new Delivery();

            const string FILENAME = "products.csv";
            const string USERFILE = "registeredUsers.csv";
            const string PLACEBID = "Would you like to place a bid on any of these items (yes or no)?\n> ";
            const string BIDITEM = "Please enter a non-negative integer between 1 and {0}:\n> ";
            const string BIDTITLE = "Bidding for {0} ({1}), current highest bid {2}";
            const string BID = "How much do you bid?\n> ";
            const string BIDCONFIRM = "Your bid of {0} for {1} is placed.";

            string[] user = fileRead.ReadLine(USERFILE, credentials[0]);

            Write(PLACEBID);
            string bidding = ReadLine();
            int bidItem = 0;

            if (bidding == "yes"){
                Write(BIDITEM, products.GetLength(0));
                try {
                    bidItem = Int32.Parse(ReadLine()) - 1;
                }
                catch (Exception){
                    WriteLine("Invalid input, please try again.");
                    bid(credentials, args, products);
                }
                WriteLine(BIDTITLE, products[bidItem, 3], products[bidItem, 5], products[bidItem, 8]);
                Write(BID);
                string bidPrice = ReadLine();
                string[,] newProducts = products;
                if (products[bidItem, 8] == "-" && check.priceCheck(bidPrice.ToString()) == true){
                    newProducts[bidItem, 8] = bidPrice;
                    newProducts[bidItem, 7] = credentials[0];
                    newProducts[bidItem, 6] = user[0];
                    string newProductsString = "";
                    for (int i = 0; i < 9; i++){
                        newProductsString += newProducts[bidItem, i] + "‗";
                    }
                    newProductsString = newProductsString.Remove(newProductsString.Length - 1);
                    fileRead.OverWriteLine(FILENAME, products[bidItem, 3] + "‗" + products[bidItem, 4], newProductsString);
                    WriteLine(BIDCONFIRM, bidPrice, products[bidItem, 3]);

                    delivery.DeliveryOptions(args, credentials, newProductsString);
                } else if (Decimal.Parse(bidPrice, System.Globalization.NumberStyles.Currency) > Decimal.Parse(products[bidItem, 8], System.Globalization.NumberStyles.Currency) && check.priceCheck(bidPrice)){
                    newProducts[bidItem, 8] = bidPrice;
                    newProducts[bidItem, 7] = credentials[0];
                    newProducts[bidItem, 6] = user[0];
                    string newProductsString = "";
                    for (int i = 0; i < 9; i++){
                        newProductsString += newProducts[bidItem, i] + "‗";
                    }
                    newProductsString = newProductsString.Remove(newProductsString.Length - 1);
                    fileRead.OverWriteLine(FILENAME, products[bidItem, 3] + "‗" + products[bidItem, 4], newProductsString);
                    WriteLine(BIDCONFIRM, bidPrice, products[bidItem, 3]);
                    delivery.DeliveryOptions(args, credentials, newProductsString);
                } else {
                    WriteLine("Invalid Input: Your bid must be higher than the current highest bid.");
                    bid(credentials, args, products);
                }
            } else if (bidding == "no"){
                WriteLine("Returning to main menu...");
                menu.clientMenu(credentials, args);
            } else{
                WriteLine("Invalid input, please try again.");
                bid(credentials, args, products);
            }
            menu.clientMenu(credentials, args);
        }
    }
}