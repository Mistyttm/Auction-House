using System;
using static System.Console;


namespace AuctionHouse
{
    public class Program
    {
        static void Main(string[] args)
        {
            WriteToFile createFile = new WriteToFile();
            MainMenu menu = new MainMenu();


            const string USERHEADER = "name,email,password,oneTimeSignIn,unitNumber,streetNumber,streetName,streetSuffix,city,state,postcode";
            const string PRODUCTSHEADER = "itemID,advertiserName,advertiserEmail,productName,description,listPrice,bidderName,bidderEmail,bidAmt";

            if (!File.Exists("databases/registeredUsers.csv")) {
                createFile.CreateFile("registeredUsers.csv", USERHEADER);
            }

            if (!File.Exists("databases/products.csv")){
                createFile.CreateFile("products.csv", PRODUCTSHEADER);
            }

            menu.homeMenu(args);
        }
    }
}