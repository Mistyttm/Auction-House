using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using static System.Console;

namespace AuctionHouse
{
    public class WriteToFile{
        public static void Write(string fileName, string text){
            using (StreamWriter sw = File.AppendText(fileName))
            {
                sw.WriteLine(text);
            }
        }

        public string Read(string fileName, string text){
            string output = "";
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = "";
                bool found = false;
                while ((s = sr.ReadLine()) != null && found == false)
                {
                    if (s.Contains(text)){
                        string[] words = s.Split(',');
                        int inputWord = Array.IndexOf(words, text); 
                        output = words[inputWord];
                        found = true;
                    } else {
                        output = "Error";
                    }
                }
            }
            return output;
        }
    }
}