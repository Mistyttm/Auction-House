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

            // Regexes
            string emailRegex = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            string passwordRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";


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
                var match = Regex.Match(emailInput, emailRegex);

                // Check if email is valid
                if (!match.Success){
                    WriteLine("Invalid Input: The supplied value is not a valid email address");
                } else {
                    email = emailInput;
                    validEmail = true;
                }
            }

            // Password
            bool validPassword = false;
            while (validPassword == false){
                Write("Please choose a password\n> ");
                string passwordIn = ReadLine();
                var match = Regex.Match(passwordIn, passwordRegex);

                // Check if password is valid
                if (!match.Success){
                    WriteLine("Invalid Input: The supplied value is not a valid password");
                } else {
                    password = passwordIn;
                    validPassword = true;
                }
            }

            WriteLine(username);
            WriteLine(email);
            WriteLine(password);

        }
    }
}