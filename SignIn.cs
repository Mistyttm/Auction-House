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

            while (validEmail == false) {
                Write("Please enter your email address\n> ");
                string email = ReadLine();
                WriteToFile.Read("registeredUsers.csv", email, correctEmail);
                if (correctEmail == "Error" || correctEmail ==""){
                    WriteLine("No match found");
                } else {
                    signedinUser[0] = correctEmail;
                    validEmail = true;
                }
            }

            while (validPass == false){
                Write("Please enter your password\n> ");
                string password = ReadLine();
                WriteToFile.Read("registeredUsers.csv", password, correctPassword);
                if (correctPassword == "Error"){
                    WriteLine("No match found");
                } else {
                    signedinUser[1] = correctPassword;
                }
            }
                        
        }
        
    }
}