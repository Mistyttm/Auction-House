using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionHouse
{
    public class Exit
    {
        public void endProgram(string[] args){
            Console.WriteLine("Exit");
            Environment.Exit(0);
        }
    }
}