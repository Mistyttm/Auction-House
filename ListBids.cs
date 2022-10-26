using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

namespace AuctionHouse
{
    public class ListBids
    {
        public void ViewBids(string[] args, string[] credentials){
            WriteToFile fileRead = new WriteToFile();
            MainMenu menu = new MainMenu();
            SellBids sell = new SellBids();

            const string FILENAME = "products.csv";
            const string USERFILE = "registeredUsers.csv";
            const string TITLE = "List Product Bids for {0}({1})";
            const string ERROR = "No bids were found";
            const string TABLEHEAD = "Item #	Product name	Description	List price	Bidder name	Bidder email	Bid amt";

            string email = credentials[0];
            string[] user = fileRead.ReadLine(USERFILE, email);
            string username = user[0];

            string[,] products = fileRead.ReadBids(FILENAME, email);

            if (products == null){
                WriteLine(ERROR);
                menu.clientMenu(credentials, args);
            } else {
                WriteLine(TITLE, credentials[0], username);
                WriteLine("------------------------------------------------");
                WriteLine(TABLEHEAD);

                string[,] sortedByFirstElement = products.OrderBy(x => x[3]);
                int arrLength = sortedByFirstElement.GetLength(0);
                
                for (int i = 0; i < arrLength; i++){
                    
                    Write($"{i+1}	");
                    for (int j = 3; j < sortedByFirstElement.GetLength(1); j++){
                        Write($"{sortedByFirstElement[i,j]}	");
                    }
                    Write("\n");
                }
            }
            sell.SellBegin(args, credentials, products);
        }
    }
}