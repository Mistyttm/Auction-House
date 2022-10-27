using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

namespace AuctionHouse
{
    public class SignIn{
        public void signIn(string[] args){

            string correctEmail = "";
            string correctPassword = "";
            string[] signedinUser = new string[2];
        

            bool validEmail = false;
            bool validPass = false;

            WriteLine("Sign In");
            WriteLine("----------");

            WriteToFile fileRead = new WriteToFile();
            Checks check = new Checks();
            MainMenu menu = new MainMenu();

            while (validEmail == false) {
                Write("Please enter your email address\n> ");

                string email = ReadLine().ToString();
                bool regexEmail = check.emailCheck(email);

                if (regexEmail == true){
                    correctEmail = fileRead.ReadVariable("registeredUsers.csv", email);

                    if (correctEmail == "Error" || regexEmail == false){
                        WriteLine("No match found");
                    } else if (correctEmail == email && regexEmail == true){
                        signedinUser[0] = correctEmail;
                        validEmail = true;
                    }
                }
            }

            while (validPass == false){
                Write("Please enter your password\n> ");
                string password = ReadLine();
                correctPassword = fileRead.ReadVariable("registeredUsers.csv", password);
                if (correctPassword == "Error"){
                    WriteLine("No match found");
                    menu.homeMenu(args);
                } else {
                    signedinUser[1] = correctPassword;
                    validPass = true;
                }
            }

            string[] firstSignInCheck = fileRead.ReadLine("registeredUsers.csv", signedinUser[0]);

            WriteLine(firstSignInCheck[3]);

            if (validEmail == true && validPass == true && firstSignInCheck[3] == "true"){
                menu.clientMenu(signedinUser, args);
            } else if (validEmail == true && validPass == true && firstSignInCheck[3] == "false") {
                PersonalDetails details = new PersonalDetails();
                details.enterDetails(args, signedinUser);
            } else {
                menu.homeMenu(args);
            }
        }
    }
}