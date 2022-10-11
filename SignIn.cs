using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

namespace AuctionHouse
{
    public class SignIn{
        public void signIn(string[] args){
            // Sign In
            // ----------
            // Please enter your email address
            // >

            // Please enter your password
            // >

            string correctEmail = "";
            string correctPassword = "";
            string[] signedinUser = new string[2];

            bool validEmail = false;
            bool validPass = false;

            WriteLine("Sign In");
            WriteLine("----------");

            WriteToFile fileRead = new WriteToFile();
            Checks check = new Checks();

            while (validEmail == false) {
                Write("Please enter your email address\n> ");

                string email = ReadLine().ToString();
                bool regexEmail = check.emailCheck(email);

                if (regexEmail == true){
                    correctEmail = fileRead.Read("registeredUsers.csv", email);

                    if (correctEmail == "Error" || regexEmail == false){
                        WriteLine("No match found");
                    } else if (correctEmail == email && regexEmail == true){
                        signedinUser[0] = correctEmail;
                        WriteLine("Email found");

                        validEmail = true;
                    }
                }
            }

            while (validPass == false){
                Write("Please enter your password\n> ");
                string password = ReadLine();
                correctPassword = fileRead.Read("registeredUsers.csv", password);
                if (correctPassword == "Error"){
                    WriteLine("No match found");
                } else {
                    signedinUser[1] = correctPassword;
                    validPass = true;
                }
            }
                        
        }
        
    }
}