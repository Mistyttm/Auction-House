using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

namespace AuctionHouse
{
    public class ProductsList
    {
        public void ListProducts(string[] args, string[] credentials){
            WriteToFile fileRead = new WriteToFile();
            MainMenu menu = new MainMenu();

            const string FILENAME = "products.csv";
            const string USERFILE = "registeredUsers.csv";
            const string TITLE = "Product List for {0}({1})";
            const string NOPRODUCTS = "You have no advertised products at the moment.";
            const string TABLEHEAD = "Item #	Product name	Description	List price	Bidder name	Bidder email	Bid amt";

            string email = credentials[0];
            string[] user = fileRead.ReadLine(USERFILE, email);
            string username = user[0];

            string[,] products = fileRead.ReadAllLines(FILENAME, email);
            
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
                    for (int j = 3; j < sortedByFirstElement.GetLength(1); j++){
                        Write($"{sortedByFirstElement[i,j]}	");
                    }
                    Write("\n");
                }
            }
            menu.clientMenu(credentials, args);
        }
    }
}