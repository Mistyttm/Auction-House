using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionHouse
{
    public class Delivery
    {
        public void DeliveryOptions(string[] args, string[] credentials){
            Menu menuOptions = new Menu();
            WriteToFile fileWrite = new WriteToFile();
            MainMenu menu = new MainMenu();

            string[] options = new string[] {"Click and collect", "Home Delivery"};

            menuOptions.menu(options, "Delivery Options");
        }

        private void ClickAndCollect(){}

        private void HomeDelivery(){}
    }
}