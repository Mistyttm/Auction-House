using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

namespace AuctionHouse
{
    public class ProductAdvertisement
    {
        public void advertise(string[] credentials, string[] args){
            WriteToFile productFile = new WriteToFile();
            Checks check = new Checks();
            MainMenu menu = new MainMenu();

            const string FILENAME = "products.csv";
            const string USERFILE = "registeredUsers.csv";
            const string TITLE = "Product Advertisement for {0}({1})";
            const string PRICEERROR = "Invalid Input: A currency value is requred, e.g. $54.95, $9.99, $2314.15.";
            const string NAMEERROR = "Invalid Input: Name cannot be empty";
            const string DESCRIPTIONERROR = "Invalid Input: Description cannot be empty";
            const string SUCCESS = "Successfully added product {0}, {1}, {2}.";

            string email = credentials[0];
            string[] user = productFile.ReadLine(USERFILE, email);
            string username = user[0];

            string name = "";
            string description = "";
            string price = "";

            WriteLine(TITLE, username, email);
            WriteLine("------------------------------------------------");

            bool validName = false;
            while (validName == false){
                Write("Product Name:\n> ");
                name = ReadLine();
                if (string.IsNullOrEmpty(name)){
                    WriteLine(NAMEERROR);
                } else {
                    validName = true;
                }
            }

            bool validDescription = false;
            while (validDescription == false){
                Write("Product Description:\n> ");
                description = ReadLine();
                if (string.IsNullOrEmpty(description) && description != name){
                    WriteLine(DESCRIPTIONERROR);
                } else {
                    validDescription = true;
                }
            }

            bool validPrice = false;
            while (validPrice == false) {
                Write("Product Price (d.cc)\n> ");
                price = ReadLine();
                if (check.priceCheck(price) == false){
                    WriteLine(PRICEERROR);
                } else {
                    int dollarIndex = price.IndexOf("$");
                    if (dollarIndex == -1) {
                        int priceInt = Int32.Parse(price);
                        if (priceInt > 0 && check.priceCheck("$" + priceInt) == true) {
                            price = "$" + price;
                            validPrice = true;
                        } else {
                            WriteLine(PRICEERROR);
                        }
                    } else if (dollarIndex != 1) {
                        if (check.priceCheck(price) == true){
                            string noDollar = price.Remove(dollarIndex, 1);
                            double priceInt = Convert.ToDouble(noDollar);
                            if (priceInt >= 0) {
                                validPrice = true;
                            } else {
                                WriteLine(PRICEERROR);
                            }
                        }
                    } else {
                        WriteLine(PRICEERROR);
                    }
                }
            }

            string productID = "";
            bool validID = false;
            while (validID == false){
                productID = check.GenerateID();
                string product = productFile.ReadVariable(FILENAME, productID);
                if (product == "Error"){
                    validID = true;
                } else {
                    productID = check.GenerateID();
                }
            }

            productFile.Write(FILENAME, productID + "," + username + "," + email + "," + name + "," + description + "," + price + "," + "No Bids,No Bids,$0.00");
            WriteLine(SUCCESS, name, description, price);

            menu.clientMenu(credentials, args);

        }
    }
}