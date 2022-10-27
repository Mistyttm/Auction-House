using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

namespace AuctionHouse
{
    public class Delivery
    {
        public void DeliveryOptions(string[] args, string[] credentials, string products){
            Menu menuOptions = new Menu();
            WriteToFile fileWrite = new WriteToFile();
            MainMenu menu = new MainMenu();

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

        private void ClickAndCollect(string[] args, string[] credentials, string products){
            WriteToFile fileWrite = new WriteToFile();

            const string FILENAME = "products.csv";
            const string DELIVERYSTART = "Delivery window start (dd/mm/yyyy hh:mm)\n> ";
            const string DELIVERYEND = "Delivery window end (dd/mm/yyyy hh:mm)\n> ";
            const string ERRORSTART = "Delivery window start must be at least one hour in the future";
            const string ERROREND = "Delivery window end must be at least one hour later than the start";
            const string SUCCESS = "Thank you for your bid. If successful, the item will be provided via collection between {0} on {1} and {2} on {3}";
            

            Write(DELIVERYSTART);
            string deliveryStartString = ReadLine();

            string delivery = products;

            try {
                DateTime deliveryStart = DateTime.Parse(deliveryStartString);
                if (deliveryStart < DateTime.Now.AddHours(1)){
                    WriteLine(ERRORSTART);
                    ClickAndCollect(args, credentials, products);
                } else {
                    Write(DELIVERYEND);
                    string deliveryEndString = ReadLine();
                    try {
                        DateTime deliveryEnd = DateTime.Parse(deliveryEndString);
                        if (deliveryEnd < deliveryStart.AddHours(1)){
                            WriteLine(ERROREND);
                            ClickAndCollect(args, credentials, products);
                        } else {
                            string COLLECT = $"Collect between {deliveryStart.ToString("HH:mm")} on {deliveryStart.ToString("dd/MM/yyyy")} and {deliveryEnd.ToString("HH:mm")} on {deliveryEnd.ToString("dd/MM/yyyy")}";
                            delivery += "‗" + COLLECT;
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

        private void HomeDelivery(string[] args, string[] credentials, string products){
            WriteLine("HomeDelivery");
        }
    }
}