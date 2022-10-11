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
            menu.menu(options, "Main Menu");

            int choice = Convert.ToInt32( ReadLine() );
            switch(choice){
                case 1:
                    Registration user = new Registration();
                    user.register(args);
                    break;
                case 2:
                    SignIn signin = new SignIn();
                    signin.signIn(args);
                    break;
                case 3:
                    Exit exit = new Exit();
                    exit.endProgram(args);
                    break;
                default:
                    WriteLine("Invalid option");
                    break;
            }
        }

        public void clientMenu(string[] options, string title, string[] credentials, string[] args){
            Menu menu = new Menu();
            menu.menu(options, title);

            int choice = Convert.ToInt32( ReadLine() );
            switch (choice){
                case 1:
                    WriteLine("Advertise Product");
                    break;
                case 2:
                    WriteLine("View My Product List");
                    break;
                case 3:
                    WriteLine("Search For Advertised Products");
                    break;
                case 4:
                    WriteLine("View Bids On My Products");
                    break;
                case 5:
                    WriteLine("View My Purchased Items");
                    break;
                case 6:
                    Exit exit = new Exit();
                    exit.logOut(args);
                    break;
            }
        }
    }
}