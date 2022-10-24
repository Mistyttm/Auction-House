using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

namespace AuctionHouse
{
    public class PersonalDetails
    {
        public void Test(string[] args){
            Console.WriteLine("Test");
        }
        
        public void enterDetails(string[] args, string[] credentials){
            // Personal Details for {name}({email})
            // ------------------------------------------------------
            // Please provide your home address.
            // Unit number (0 = none):
            // >
            string[] oldDetails = new string[4];
            WriteToFile file = new WriteToFile();
            oldDetails = file.ReadLine("registeredUsers.csv", credentials[0]);
            string name = oldDetails[0];
            string email = oldDetails[1];
            string password = oldDetails[2];
            string firstTime = "true";

            int unitNumber = 0;
            int streetNumber = 0;
            string streetName = "";
            string streetSuffix = "";
            string city = "";
            string state = "";
            int postcode = 0000;

            WriteLine("Personal Details for {0}({1})", name, email);
            WriteLine("------------------------------------------------------");
            
            bool validUnit = false;

            while (!validUnit){
                WriteLine("Please provide your home address.");
                Write("Unit number (0 = none):\n> ");

                unitNumber = Int32.Parse(Console.ReadLine());

                if (unitNumber == 0){
                    validUnit = true;
                } else if (unitNumber > 0){
                    validUnit = true;
                } else if (unitNumber < 0){
                    WriteLine("Invalid Input: Unit number must be a non-negative integer.");
                }
                else{
                    WriteLine("Invalid unit number. Please try again.");
                }
            }

            bool validStreetNumber = false;

            while (!validStreetNumber){
                Write("Street number:\n> ");

                streetNumber = Int32.Parse(Console.ReadLine());

                if (streetNumber > 0){
                    validStreetNumber = true;
                } else if (streetNumber < 0){
                    WriteLine("Invalid Input: Street number must be a positve integer.");
                } else {
                    WriteLine("Invalid Input: Street number must be greater than 0.");
                }
            }

            bool validStreetName = false;

            while (!validStreetName){
                Write("Street name:\n> ");

                streetName = Console.ReadLine();

                if (!string.IsNullOrEmpty(streetName)) {
                    validStreetName = true;
                } else {
                    WriteLine("Invalid Input: Street name must not be null");
                }
            }

            bool validStreetSuffix = false;

            while (!validStreetSuffix){
                Write("Street suffix:\n> ");

                streetSuffix = Console.ReadLine();

                if (!string.IsNullOrEmpty(streetSuffix)) {
                    validStreetSuffix = true;
                } else {
                    WriteLine("Invalid Input: Street suffix must not be null");
                }
            }

            bool validCity = false;

            while (!validCity){
                Write("City:\n> ");

                city = Console.ReadLine();

                if (!string.IsNullOrEmpty(city)) {
                    validCity = true;
                } else {
                    WriteLine("Invalid Input: City must not be null");
                }
            }

            bool validState = false;

            while (!validState){
                Write("State (ACT, NSW, NT, QLD, SA, TAS, VIC, WA):\n> ");

                state = Console.ReadLine();

                switch (state){
                    case "ACT":
                        validState = true;
                        break;
                    case "NSW":
                        validState = true;
                        break;
                    case "NT":
                        validState = true;
                        break;
                    case "QLD":
                        validState = true;
                        break;
                    case "SA":
                        validState = true;
                        break;
                    case "TAS":
                        validState = true;
                        break;
                    case "VIC":
                        validState = true;
                        break;
                    case "WA":
                        validState = true;
                        break;
                    default:
                        WriteLine("Invalid Input: State must be a valid Australian state.");
                        break;
                }
            }

            bool validPostcode = false;

            while (!validPostcode){
                Write("Postcode:\n> ");

                postcode = Int32.Parse(Console.ReadLine());

                // TODO refactor this to use proper validation for postcodes if allowed

                if (postcode > 1000 || postcode < 9999){
                    validPostcode = true;
                } else if (postcode < 0){
                    WriteLine("Invalid Input: Postcode must be a positve integer.");
                } else {
                    WriteLine("Invalid Input: Postcode must be greater than 0.");
                }
            }

            string[] newDetails = new string[11];
            newDetails[0] = name;
            newDetails[1] = email;
            newDetails[2] = password;
            newDetails[3] = firstTime;
            newDetails[4] = unitNumber.ToString();
            newDetails[5] = streetNumber.ToString();
            newDetails[6] = streetName;
            newDetails[7] = streetSuffix;
            newDetails[8] = city;
            newDetails[9] = state;
            newDetails[10] = postcode.ToString();

            string newDetailsString = string.Join("_", newDetails);

            WriteToFile userFile = new WriteToFile();
            userFile.OverWriteLine("registeredUsers.csv", email, newDetailsString);

            string address = "";
            if (unitNumber == 0){
                address = streetNumber + " " + streetName + " " + streetSuffix + ", " + city + ", " + state + ", " + postcode;
            } else {
                address = unitNumber + " " + streetNumber + " " + streetName + " " + streetSuffix + ", " + city + ", " + state + ", " + postcode;
            }

            WriteLine("Address has been updated to {0}", address);

            MainMenu menu = new MainMenu();
            menu.clientMenu(credentials, args);

        }
    }
}