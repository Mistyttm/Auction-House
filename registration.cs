using System.Security.AccessControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;
using System.Text.RegularExpressions;

namespace AuctionHouse
{
    public class Registration
    {
        public void register(string[] args){
            // Variables
            string username = "";
            string password = "";
            string email = "";

            Checks check = new Checks();

            WriteLine("Registration");
            WriteLine("-----------------");

            // Username
            bool validInput = false;
            while (validInput == false){
                Write("Please enter your name\n> ");
                string name = ReadLine();

                // Check if name is valid
                if (string.IsNullOrEmpty(name)){
                    WriteLine("Invalid Input: The supplied value is not a valid name");
                } else {
                    username = name;
                    validInput = true;
                }
            }

            // Email
            bool validEmail = false;
            while (validEmail == false){
                Write("Please enter your email address\n> ");
                string emailInput = ReadLine();

                bool validEmailRegex = check.emailCheck(emailInput);

                // Check if email is valid
                if (validEmailRegex == true){
                    email = emailInput;
                    validEmail = true;
                }
            }

            // Password
            bool validPassword = false;
            while (validPassword == false){
                Write("Please choose a password\n> ");
                string passwordIn = ReadLine();
                bool validPassRegex = check.passwordCheck(passwordIn);

                // Check if email is valid
                if (validPassRegex == true){
                    email = passwordIn;
                    validEmail = true;
                }
            }
            string fileName = "registeredUsers.csv";
            string combinedString = username + "," + email + "," + password + "\n";
            WriteToFile.Write(fileName, combinedString.ToString());

            WriteLine("Client {0}({1}) has successfully registered at the Auction House.", username, email);

            int milliseconds = 2000;
            Thread.Sleep(milliseconds);

            MainMenu menu = new MainMenu();
            menu.menu(args);
        }
    }
}