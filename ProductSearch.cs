using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

namespace AuctionHouse
{
    public class ProductSearch
    {
        public void search(string[] args, string[] credentials){
            WriteToFile fileRead = new WriteToFile();
            MainMenu menu = new MainMenu();

            const string TITLE = "Product search for {0}({1})";
            const string SEARCHTITLE = "Search Results";
            const string TABLEHEAD = "|  Item #  |   Product name   |   Description  |  List price  |   Bidder name   |   Bidder email   |  Bid amt  |";
            const string TABLESEPERATOR = "| -------- | ---------------- | -------------- | ------------ | --------------- | ---------------- | --------- |";
            const string FILENAME = "products.csv";
            const string USERFILE = "registeredUsers.csv";

            string email = credentials[0];
            string[] user = fileRead.ReadLine(USERFILE, email);
            string username = user[0];

            string searchTerm = "";

            // string[,] products = fileRead.ReadAllLines(FILENAME, searchTerm);

            WriteLine(TITLE, username, email);
            WriteLine("------------------------------------------------");

            Write("Please supply a search phrase (ALL to see all products)\n> ");

            searchTerm = ReadLine();
            if (searchTerm == "All"){
                int lines = File.ReadAllLines("myfile").Length;
            }

            menu.clientMenu(credentials, args);
        }
    }
}