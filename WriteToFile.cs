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
                    if (s.Contains("_"+text+"_")){
                        string[] words = s.Split('_');
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
                    if (s.Contains("_"+user+"_")){
                        string[] words = s.Split('_');
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
                    if (s.Contains("_"+user+"_")){
                        string[] words = s.Split('_');
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

        public int TotalLines(string fileName, string user){
            int output = 0;
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    if (s.Contains("_"+user+"_")){
                        string[] words = s.Split('_');
                        output += 1;
                    }
                }
            }
            return output;
        }

        public int TotalLinesSearch(string fileName, string user){
            StringComparison comp = StringComparison.OrdinalIgnoreCase;
            int output = 0;
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    if (s.Contains(user, comp)){
                        string[] words = s.Split('_');
                        output += 1;
                    }
                }
            }
            return output;
        }

        public string[,] ReadAllLines(string fileName, string user){
            fileName = "databases/" + fileName;
            int totalLines = TotalLines(fileName, user);
            string[,] output = new string[totalLines, 9];
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = "";
                int counter = 0;
                while ((s = sr.ReadLine()) != null)
                {
                    if (s.Contains(user)){
                        string[] words = s.Split('_');
                        for(int i = 0; i < 9; i++){
                            output[counter, i] = words[i];
                        }
                        counter++;
                    }
                }
                if (counter == 0){
                    output = null;
                }
            }
            return output;
        }

        public string[,] ReadFile(string fileName, string search){
            fileName = "databases/" + fileName;
            StringComparison comp = StringComparison.OrdinalIgnoreCase;
            string[,] output;

            using (StreamReader sr = File.OpenText(fileName)){
            if (search == "ALL" || search == "all" || search == "All"){
                int totalLines = File.ReadAllLines(fileName).Length;
                output = new string[totalLines, 9];
            } else {
                int totalLines = TotalLinesSearch(fileName, search);
                output = new string[totalLines, 9];
            }
                string s = "";
                int counter = 0;
                while ((s = sr.ReadLine()) != null){
                    if (search == "ALL" || search == "all" || search == "All"){
                        

                        string[] words = s.Split('_');
                        for(int i = 0; i < 9; i++){
                            output[counter, i] = words[i];
                        }
                        counter++;
                    } else if (s.Contains(search, comp)) {

                        string[] words = s.Split('_');
                        for(int i = 0; i < 9; i++){
                            output[counter, i] = words[i];
                        }
                        counter++;
                    }
                    
                }
                if (counter == 0){
                    output = null;
                }
            }
            return output;
        }
    }
}
