using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

namespace AuctionHouse
{
    public class Delivery
    {
        // Method for delivery
        public void DeliveryOptions(string[] args, string[] credentials, string products){
            Menu menuOptions = new Menu(); // Access menu
            WriteToFile fileWrite = new WriteToFile(); // Access database
            MainMenu menu = new MainMenu();// Access Main Menu

            // Options for the menu
            string[] options = new string[] {"Click and collect", "Home Delivery"};

            menuOptions.menu(options, "Delivery Options");

            string choice = ReadLine();

            switch (choice){
                case "1":
                    ClickAndCollect(credentials, args, products);
                    break;
                case "2":
                    HomeDelivery(credentials, args, products);
                    break;
                default:
                    WriteLine("Invalid input");
                    DeliveryOptions(args, credentials, products);
                    break;
            }
        }

        // Click and Collect method
        private void ClickAndCollect(string[] args, string[] credentials, string products){
            WriteToFile fileWrite = new WriteToFile(); // Access database

            // Constants
            const string FILENAME = "products.csv";
            const string DELIVERYSTART = "Delivery window start (dd/mm/yyyy hh:mm)\n> ";
            const string DELIVERYEND = "Delivery window end (dd/mm/yyyy hh:mm)\n> ";
            const string ERRORSTART = "Delivery window start must be at least one hour in the future";
            const string ERROREND = "Delivery window end must be at least one hour later than the start";
            const string SUCCESS = "Thank you for your bid. If successful, the item will be provided via collection between {0} on {1} and {2} on {3}";
            

            Write(DELIVERYSTART);
            // Start of click and collect window
            string deliveryStartString = ReadLine();

            string delivery = products;

            // try to parse the input as a datetime
            try {
                DateTime deliveryStart = DateTime.Parse(deliveryStartString);
                // error handling
                if (deliveryStart < DateTime.Now.AddHours(1)){
                    WriteLine(ERRORSTART);
                    ClickAndCollect(args, credentials, products);
                } else {
                    // end of click and collect window
                    Write(DELIVERYEND);
                    string deliveryEndString = ReadLine();
                    try {
                        DateTime deliveryEnd = DateTime.Parse(deliveryEndString);
                        // error handling
                        if (deliveryEnd < deliveryStart.AddHours(1)){
                            WriteLine(ERROREND);
                            ClickAndCollect(args, credentials, products);
                        } else {
                            // add delivery info to products string
                            string COLLECT = $"Collect between {deliveryStart.ToString("HH:mm")} on {deliveryStart.ToString("dd/MM/yyyy")} and {deliveryEnd.ToString("HH:mm")} on {deliveryEnd.ToString("dd/MM/yyyy")}";
                            delivery += "‗" + COLLECT;
                            // Update database
                            fileWrite.OverWriteLine(FILENAME, products, delivery);
                            WriteLine(SUCCESS, deliveryStart.ToString("HH:mm"), deliveryStart.ToString("dd/MM/yyyy"), deliveryEnd.ToString("HH:mm"), deliveryEnd.ToString("dd/MM/yyyy"));
                        }
                    } catch (FormatException){
                        WriteLine(ERROREND);
                        ClickAndCollect(args, credentials, products);
                    }
                }
            } catch (FormatException){
                WriteLine(ERRORSTART);
                ClickAndCollect(args, credentials, products);
            }
        }

        // Home Delivery method
        private void HomeDelivery(string[] args, string[] credentials, string products){
            WriteToFile fileWrite = new WriteToFile();

            // Constants
            const string FILENAME = "products.csv";
            const string UNITNUMBER = "Please provide your delivery address.\nUnit number (0 = none):\n> ";
            const string STREETNUMBER = "Street number:\n> ";
            const string STREETNAME = "Street name:\n> ";
            const string STREETSUFFIX = "Street suffix:\n> ";
            const string CITY = "City:\n> ";
            const string STATE = "State (ACT, NSW, NT, QLD, SA, TAS, VIC, WA):\n> ";
            const string POSTCODE = "Postcode (1000 .. 9999):\n> ";
            const string SUCCESS = "Thank you for your bid. If successful, the item will be provided via delivery to {0}/{1} {2} {3} {4} {5} {6}\n> ";

            // Variables
            int unitNumber = 0;
            int streetNumber = 0;
            string streetName = "";
            string streetSuffix = "";
            string city = "";
            string state = "";
            int postcode = 0000;

            bool validUnit = false;

            // Get unit number
            while (!validUnit){
                Write(UNITNUMBER);

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

            // Get street number
            while (!validStreetNumber){
                Write(STREETNUMBER);

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

            // Get street name
            while (!validStreetName){
                Write(STREETNAME);

                streetName = Console.ReadLine();

                if (!string.IsNullOrEmpty(streetName)) {
                    validStreetName = true;
                } else {
                    WriteLine("Invalid Input: Street name must not be null");
                }
            }

            bool validStreetSuffix = false;

            // Get street suffix
            while (!validStreetSuffix){
                Write(STREETSUFFIX);

                streetSuffix = Console.ReadLine();

                if (!string.IsNullOrEmpty(streetSuffix)) {
                    validStreetSuffix = true;
                } else {
                    WriteLine("Invalid Input: Street suffix must not be null");
                }
            }

            bool validCity = false;

            // Get city
            while (!validCity){
                Write(CITY);

                city = Console.ReadLine();

                if (!string.IsNullOrEmpty(city)) {
                    validCity = true;
                } else {
                    WriteLine("Invalid Input: City must not be null");
                }
            }

            bool validState = false;

            // Get state
            while (!validState){
                Write(STATE);

                state = Console.ReadLine().ToUpper();

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

            // Get postcode
            while (!validPostcode){
                Write(POSTCODE);

                postcode = Int32.Parse(Console.ReadLine());

                if (postcode > 1000 || postcode < 9999){
                    validPostcode = true;
                } else if (postcode < 0){
                    WriteLine("Invalid Input: Postcode must be a positve integer.");
                } else {
                    WriteLine("Invalid Input: Postcode must be greater than 0.");
                }
            }

            // Update Database
            string delivery = products;
            string COLLECT = $"Deliver to {unitNumber}/{streetNumber} {streetName} {streetSuffix} {city} {state} {postcode}";
            delivery += "‗" + COLLECT;
            fileWrite.OverWriteLine(FILENAME, products, delivery);
            WriteLine(SUCCESS, unitNumber, streetNumber, streetName, streetSuffix, city, state, postcode);
        }
    }
}