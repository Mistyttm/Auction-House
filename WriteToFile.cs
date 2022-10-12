using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using static System.Console;

namespace AuctionHouse
{
    public class WriteToFile{
        public void CreateFile(string filename, string header){
            Directory.CreateDirectory("databases");
            string newFile = "databases/" + filename;
            using (StreamWriter sw = File.CreateText(newFile)) {        
                sw.WriteLine(header);
            }
        }

        public void Write(string fileName, string text){
            fileName = "databases/" + fileName;
            using (StreamWriter sw = File.AppendText(fileName))
            {
                sw.WriteLine(text);
            }
        }

        public string ReadVariable(string fileName, string text){
            fileName = "databases/" + fileName;
            string output = "";
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = "";
                bool found = false;
                while ((s = sr.ReadLine()) != null && found == false)
                {
                    if (s.Contains(","+text+",")){
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

        public string[] ReadLine(string fileName, string user){
            fileName = "databases/" + fileName;
            string[] output = new string[4];
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = "";
                bool found = false;
                while ((s = sr.ReadLine()) != null && found == false)
                {
                    if (s.Contains(","+user+",")){
                        string[] words = s.Split(',');
                        output = words;
                        found = true;
                    } else {
                        output[0] = "Error";
                    }
                }
            }
            return output;
        }

        public string OverWriteLine(string fileName, string user, string text){
            fileName = "databases/" + fileName;
            string output = "";
            int lineToEdit = 0;
            string[] arrLine = File.ReadAllLines(fileName);
            int LineNumber = 0;
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = "";
                bool found = false;
                while ((s = sr.ReadLine()) != null && found == false)
                {
                    if (s.Contains(","+user+",")){
                        string[] words = s.Split(',');
                        lineToEdit = LineNumber;
                        output = "Success";
                        found = true;                   
                    } else {
                        LineNumber++;
                        output = "Error";
                    }
                }
            }
            arrLine[lineToEdit] = text;
            File.WriteAllLines(fileName, arrLine);
            return output;
        }
    }
}
