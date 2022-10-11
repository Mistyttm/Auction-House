using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

namespace AuctionHouse
{
    public class Menu
    {
        public string menu(string[] options, string title){
            string output = "";
            WriteLine(title);
            WriteLine("-----------------");
            for (int i = 0; i < options.Length; i++){
                WriteLine($"({i+1}) {options[i]}");
            }
            Write("Please select an option between 1 and {0}\n> ", options.Length);

            return output;
        }
    }
}