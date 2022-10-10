using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;
using System.IO;

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

            string[] signedinUser = new string[2];

            bool validEmail = false;
            bool validPass = false;

            WriteLine("Sign In");
            WriteLine("----------");

            while (validEmail == false) {
                Write("Please enter your email address\n> ");
                string email = ReadLine();
                using (StreamReader sr = File.OpenText("registeredUsers.csv")){
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        if (s.Contains("," + email + ",")){
                            string[] words = s.Split(',');
                            int inputWord = Array.IndexOf(words, email); 
                            signedinUser[0] = words[inputWord];
                            validEmail = true;
                        } else {
                            WriteLine("No Match Found!");
                        }
                    }
                }
            }

            while (validPass == false){
                Write("Please enter your password\n> ");
                string password = ReadLine();
                using (StreamReader sr = File.OpenText("registeredUsers.csv")){
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        if (s.Contains("," + password + ",")){
                            string[] words = s.Split(',');
                            int inputWord = Array.IndexOf(words, password); 
                            signedinUser[1] = words[inputWord];
                            validEmail = true;
                        } else {
                            WriteLine("No Match Found!");
                        }
                    }
                }
            }
        }
    }
}