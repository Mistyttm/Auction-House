using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;
using System.Text.RegularExpressions;


namespace AuctionHouse
{
    public class Checks
    {
        public bool emailCheck (string email){
            bool output = false;
            string emailRegex = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

            var match = Regex.Match(email, emailRegex);

                // Check if email is valid
                if (!match.Success){
                    WriteLine("Invalid Input: The supplied value is not a valid email address");
                } else {
                    output = true;
                }

            return output;
        }

        public bool passwordCheck (string pass){
            bool output = false;
            string passwordRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@\(\)\[\]\{\}\;\:\|'""$\-!%*?&\,\.><`~\\])[A-Za-z\d@$!%*?&'""\.><\,\(\)\-\[\]\{\}\;\:\|\\`~]{8,}$";

            var match = Regex.Match(pass, passwordRegex);

                // Check if email is valid
                if (!match.Success){
                    WriteLine("Invalid Input: The supplied value is not a valid password");
                } else {
                    output = true;
                }

            return output;
        }

        public string GenerateID (){
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string output = "";

            Random rnd = new Random();

            for (int i = 0; i < 3; i++){
                int num = rnd.Next(10);
                output += Convert.ToString(num);
            }
            output += "-";
            for (int i = 0; i < 3; i++){
                output += chars[rnd.Next(chars.Length)];
            }

            return output;
        }

        public bool priceCheck (string price){
            bool output = false;
            string priceRegex = @"^\$[0-9]+.[0-9][0-9]$";

            var match = Regex.Match(price, priceRegex);

            if (!match.Success){
                    output = false;
                } else {
                    output = true;
                }
            
            return output;
        }
    }
}