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

            const string FILENAME = "products.csv";
            const string USERFILE = "registeredUsers.csv";
            const string TITLE = "List Product Bids for {0}({1})";
            const string ERROR = "No bids were found";
            const string TABLEHEAD = "|  Item #  |   Product name   |  Description   |  List price  |   Bidder name   |   Bidder email   |  Bid amt  |";
            const string TABLESEPERATOR = "| -------- | ---------------- | -------------- | ------------ | --------------- | ---------------- | --------- |";

            string email = credentials[0];

            string[,] products = fileRead.ReadBids(FILENAME, email);

            if (products == null){
                WriteLine(ERROR);
                menu.clientMenu(credentials, args);
            } else {
                WriteLine(TABLEHEAD);
                WriteLine(TABLESEPERATOR);

                string[,] sortedByFirstElement = products.OrderBy(x => x[3]);
                int arrLength = sortedByFirstElement.GetLength(0);
                
                for (int i = 0; i < arrLength; i++){
                    
                    Write($"|    {i+1}     ");
                    for (int j = 3; j < sortedByFirstElement.GetLength(1); j++){
                        Write($"| {sortedByFirstElement[i,j]} ");
                    }
                    Write("|\n");
                }
            }
            menu.clientMenu(credentials, args);
        }
    }
}