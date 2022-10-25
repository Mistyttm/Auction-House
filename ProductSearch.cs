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
            Bidding bid = new Bidding();
            MainMenu menu = new MainMenu();

            const string TITLE = "Product search for {0}({1})";
            const string SEARCHTITLE = "Search Results";
            const string TABLEHEAD = "|  Item #  |   Product name   |   Description  |  List price  |   Bidder name   |   Bidder email   |  Bid amt  |";
            const string TABLESEPERATOR = "| -------- | ---------------- | -------------- | ------------ | --------------- | ---------------- | --------- |";
            const string FILENAME = "products.csv";
            const string USERFILE = "registeredUsers.csv";
            const string ERROR = "That is an invalid search term";

            string email = credentials[0];
            string[] user = fileRead.ReadLine(USERFILE, email);
            string username = user[0];

            string searchTerm = "";

            // string[,] products = fileRead.ReadAllLines(FILENAME, searchTerm);

            WriteLine(TITLE, username, email);
            WriteLine("------------------------------------------------");

            Write("Please supply a search phrase (ALL to see all products)\n> ");

            searchTerm = ReadLine();
            if (string.IsNullOrEmpty(searchTerm)){
                WriteLine(ERROR);
            } else if (searchTerm == "All"){
                int lines = File.ReadAllLines("databases/" + FILENAME).Length;
                string[,] lineOutput = fileRead.ReadFile(FILENAME, searchTerm);
                WriteLine(SEARCHTITLE);
                WriteLine("------------------------------------------------");
                WriteLine(TABLEHEAD);
                WriteLine(TABLESEPERATOR);

                if (lineOutput == null){
                    WriteLine(Error);
                } else {
                    string[,] sortedByFirstElement = lineOutput.OrderBy(x => x[3]);
                    int arrLength = sortedByFirstElement.GetLength(0);
                    
                    for (int i = 0; i < arrLength; i++){
                        
                        Write($"|    {i+1}     ");
                        for (int j = 3; j < sortedByFirstElement.GetLength(1); j++){
                            Write($"| {sortedByFirstElement[i,j]} ");
                        }
                        Write("|\n");
                    }
                    bid.bid(credentials, args, sortedByFirstElement);
                }
            } else {
                string[,] lineOutput = fileRead.ReadFile(FILENAME, searchTerm);

                if (lineOutput == null){
                    WriteLine(ERROR);
                } else {
                    WriteLine(SEARCHTITLE);
                    WriteLine("------------------------------------------------");
                    WriteLine(TABLEHEAD);
                    WriteLine(TABLESEPERATOR);
                    string[,] sortedByFirstElement = lineOutput.OrderBy(x => x[3]);
                    int arrLength = sortedByFirstElement.GetLength(0);
                    
                    for (int i = 0; i < arrLength; i++){
                        
                        Write($"|    {i+1}     ");
                        for (int j = 3; j < sortedByFirstElement.GetLength(1); j++){
                            Write($"| {sortedByFirstElement[i,j]} ");
                        }
                        Write("|\n");
                    }
                    bid.bid(credentials, args, sortedByFirstElement);
                }
            }
        }
    }
}