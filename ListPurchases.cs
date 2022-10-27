using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

namespace AuctionHouse
{
    public class ListPurchases
    {
        public void ListProducts(string[] args, string[] credentials){
            WriteToFile fileRead = new WriteToFile();
            MainMenu menu = new MainMenu();

            const string FILENAME = "sales.csv";
            const string USERFILE = "registeredUsers.csv";
            const string TITLE = "Purchased Items for {0}({1})";
            const string NOPRODUCTS = "You have no purchased products at the moment..";
            const string TABLEHEAD = "Item #	Seller email	Product name	Description	List price	Amt paid	Delivery option";

            string email = credentials[0];
            string[] user = fileRead.ReadLine(USERFILE, email);
            string username = user[0];

            string[,] products = fileRead.ReadAllLinesSold(FILENAME, email);
            
            WriteLine(TITLE, username, email);
            WriteLine("------------------------------------------------");
            if (products == null){
                WriteLine(NOPRODUCTS);
                menu.clientMenu(credentials, args);
            } else {
                WriteLine(TABLEHEAD);

                string[,] sortedByFirstElement = products.OrderBy(x => x[3]);
                int arrLength = sortedByFirstElement.GetLength(0);
                
                for (int i = 0; i < arrLength; i++){
                    
                    Write($"{i+1}	");
                    for (int j = 0; j < sortedByFirstElement.GetLength(1); j++){
                        if (sortedByFirstElement[i,j] == username || sortedByFirstElement[i,j] == email){
                            continue;
                        } else {
                            Write($"{sortedByFirstElement[i,j]}	");
                        }
                    }
                    Write("\n");
                }
            }
            menu.clientMenu(credentials, args);
        }
    }
}