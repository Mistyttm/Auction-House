using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

namespace AuctionHouse
{
    public class MainMenu
    {
        public void menu(string[] args){
            WriteLine("Main Menu");
            WriteLine("-----------------");
            WriteLine("(1) Register");
            WriteLine("(2) Sign In");
            WriteLine("(3) Exit");
            Write("Please select an option between 1 and 3\n> ");
            

            int choice = Convert.ToInt32( ReadLine() );
            switch(choice){
                case 1:
                    Registration user = new Registration();
                    user.register(args);
                    break;
                case 2:
                    WriteLine("Sign In");
                    break;
                case 3:
                    WriteLine("Exit");
                    break;
                default:
                    WriteLine("Invalid option");
                    break;
            }
        }
    }
}