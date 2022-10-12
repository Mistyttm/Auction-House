using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

namespace AuctionHouse
{
    public class MainMenu
    {
        public void homeMenu(string[] args){

            string[] options = new string[] {"Register", "Sign In", "Exit"};
            
            Menu menu = new Menu();
            bool pass = false;
            while (pass == false){
                menu.menu(options, "Main Menu");

                string choice = ReadLine();
                switch(choice){
                    case "1":
                        Registration user = new Registration();
                        user.register(args);
                        pass = true;
                        break;
                    case "2":
                        SignIn signin = new SignIn();
                        signin.signIn(args);
                        pass = true;
                        break;
                    case "3":
                        Exit exit = new Exit();
                        exit.endProgram(args);
                        pass = true;
                        break;
                }
            }
        }

        public void clientMenu(string[] credentials, string[] args){
            string[] clientMenu = new string[] {"Advertise Product", "View My Product List", "Search For Advertised Products", "View Bids On My Products", "View My Purchased Items", "Log Off"};
            Menu menu = new Menu();
            
            bool pass = false;

            while (pass == false) {
                menu.menu(clientMenu, "Client Menu");

                string choice = ReadLine();
                switch (choice){
                    case "1":
                        ProductAdvertisement advertisement = new ProductAdvertisement();
                        advertisement.advertise(credentials, args);
                        pass = true;
                        break;
                    case "2":
                        WriteLine("View My Product List");
                        pass = true;
                        break;
                    case "3":
                        WriteLine("Search For Advertised Products");
                        pass = true;
                        break;
                    case "4":
                        WriteLine("View Bids On My Products");
                        pass = true;
                        break;
                    case "5":
                        WriteLine("View My Purchased Items");
                        pass = true;
                        break;
                    case "6":
                        Exit exit = new Exit();
                        exit.logOut(args);
                        break;
                }
            }
        }
    }
}