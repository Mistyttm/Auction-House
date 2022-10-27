using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using static System.Console;

namespace AuctionHouse
{
    public class WriteToFile{
        // Create a file
        public void CreateFile(string filename){
            Directory.CreateDirectory("databases");
            string newFile = "databases/" + filename;
            using (StreamWriter sw = File.CreateText(newFile)) {        
            }
        }

        // Write to a file
        public void Write(string fileName, string text){
            fileName = "databases/" + fileName;
            using (StreamWriter sw = File.AppendText(fileName))
            {
                sw.WriteLine(text);
            }
        }

        // Read a single variable from database
        public string ReadVariable(string fileName, string text){
            fileName = "databases/" + fileName;
            string output = "";
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = "";
                bool found = false;
                while ((s = sr.ReadLine()) != null && found == false)
                {
                    if (s.Contains("‗"+text+"‗")){
                        string[] words = s.Split('‗');
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

        // Read a line from database
        public string[] ReadLine(string fileName, string user){
            fileName = "databases/" + fileName;
            string[] output = new string[4];
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = "";
                bool found = false;
                while ((s = sr.ReadLine()) != null && found == false)
                {
                    if (s.Contains("‗"+user+"‗")){
                        string[] words = s.Split('‗');
                        output = words;
                        found = true;
                    } else {
                        output[0] = "Error";
                    }
                }
            }
            return output;
        }

        // Overwrite a line in a file
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
                    if (s.Contains(user)){
                        string[] words = s.Split('‗');
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

        // Calculate total lines in a file
        public int TotalLines(string fileName, string user){
            int output = 0;
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    if (s.Contains("‗"+user+"‗")){
                        string[] words = s.Split('‗');
                        if (words[7] != user){
                            output += 1;
                        }
                    }
                }
            }
            return output;
        }

        // calculate total lines in a file for a search
        public int TotalLinesSearch(string fileName, string search, string user){
            StringComparison comp = StringComparison.OrdinalIgnoreCase;
            int output = 0;
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    if (s.Contains(search, comp)){
                        string[] words = s.Split('‗');
                        if (words[2] != user){
                            output += 1;
                        }
                    }
                }
            }
            return output;
        }

        // Read all lines for a user
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
                        string[] words = s.Split('‗');
                        if (words[7] != user){
                            for(int i = 0; i < 9; i++){
                                output[counter, i] = words[i];
                            }
                            counter++;
                        }
                    }
                }
                if (counter == 0){
                    output = null;
                }
            }
            return output;
        }

        // Calculate total lines for a bid
        public int TotalLinesBids(string fileName, string user){
            int output = 0;
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    if (s.Contains("‗"+user+"‗")){
                        string[] words = s.Split('‗');
                        if (words[7] != user && words[7] != "-"){
                            output += 1;
                        }
                    }
                }
            }
            return output;
        }

        // Read all bids
        public string[,] ReadBids(string fileName, string user){
            fileName = "databases/" + fileName;
            int totalLines = TotalLinesBids(fileName, user);
            string[,] output = new string[totalLines, 10];
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = "";
                int counter = 0;
                while ((s = sr.ReadLine()) != null)
                {
                    if (s.Contains(user)){
                        string[] words = s.Split('‗');
                        if (words[7] != user && words[7] != "-"){
                            for(int i = 0; i < 10; i++){
                                output[counter, i] = words[i];
                            }
                            counter++;
                        }
                    }
                }
                if (counter == 0){
                    output = null;
                }
            }
            return output;
        }

        // Read all lines for a search
        public string[,] ReadFile(string fileName, string search, string user){
            fileName = "databases/" + fileName;
            StringComparison comp = StringComparison.OrdinalIgnoreCase;
            string[,] output;

            using (StreamReader sr = File.OpenText(fileName)){
            if (search == "ALL" || search == "all" || search == "All"){
                int totalLines = File.ReadAllLines(fileName).Length;
                output = new string[totalLines, 9];
            } else {
                int totalLines = TotalLinesSearch(fileName, search, user);
                output = new string[totalLines, 9];
            }
                string s = "";
                int counter = 0;
                while ((s = sr.ReadLine()) != null){
                    if (search == "ALL" || search == "all" || search == "All"){
                        

                        string[] words = s.Split('‗');
                        if (words[2] != user){
                            for(int i = 0; i < 9; i++){
                                output[counter, i] = words[i];
                            }
                            counter++;
                        }
                    } else if (s.Contains(search, comp)) {

                        string[] words = s.Split('‗');
                        if (words[2] != user){
                            for(int i = 0; i < 9; i++){
                                output[counter, i] = words[i];
                            }
                            counter++;
                        }
                    }
                    
                }
                if (counter == 0){
                    output = null;
                }
            }
            return output;
        }

        // Remove a line from a file
        public void RemoveLine(string filename, string ToRemove){
            filename = "databases/" + filename;
            string tempFileName = "temporary.csv";
            CreateFile(tempFileName);
            var tempFile = Path.GetTempFileName();
            var linesToKeep = File.ReadLines(filename).Where(l => l != ToRemove);

            File.WriteAllLines(tempFile, linesToKeep);

            File.Delete(filename);
            File.Move(tempFile, filename);
            File.Delete(tempFile);
        }

        // Read all sold lines
        public string[,] ReadAllLinesSold(string fileName, string user){
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
                        string[] words = s.Split('‗');
                        if (words[6] == user){
                            for(int i = 0; i < 8; i++){
                                output[counter, i] = words[i];
                            }
                            counter++;
                        }
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
