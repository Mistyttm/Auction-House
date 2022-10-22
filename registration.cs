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
            WriteToFile file = new WriteToFile();

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
                if (validEmailRegex == true){
                    string emailExists = file.ReadVariable("registeredUsers.csv", emailInput);
                    // Check if email is valid
                    if (emailExists == "Error"){
                        email = emailInput;
                        validEmail = true;
                    }  else {
                        WriteLine("Invalid Input: This email address already exists");
                    }
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
                    password = passwordIn;
                    validPassword = true;
                }
            }
            string fileName = "registeredUsers.csv";
            string combinedString = username + "_" + email + "_" + password + "_false_";
            WriteToFile userFile = new WriteToFile();
            userFile.Write(fileName, combinedString.ToString());

            WriteLine("Client {0}({1}) has successfully registered at the Auction House.", username, email);

            MainMenu menu = new MainMenu();
            menu.homeMenu(args);
        }
    }
}