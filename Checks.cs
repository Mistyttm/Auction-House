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
            string passwordRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&\,])[A-Za-z\d@$!%*?&\,]{8,}$";

            var match = Regex.Match(pass, passwordRegex);

                // Check if email is valid
                if (!match.Success){
                    WriteLine("Invalid Input: The supplied value is not a valid password");
                } else {
                    output = true;
                }

            return output;
        }
    }
}