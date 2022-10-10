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

        public static void Read(string fileName, string text, string output){
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    if (s.Contains("," + text + ",")){
                        string[] words = s.Split(',');
                        int inputWord = Array.IndexOf(words, text); 
                        output = words[inputWord];
                    }
                }
            }
        }
    }
}