using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8Task2
{
    class Program
    {
        static void ReadFiles(FileInfo file, Action<FileInfo> action)
        {
            action(file);
        }

        static void GetText(FileInfo file)
        {
            string path = file.Name;
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }

        static void GetDigits(FileInfo file)
        {
            string path = file.Name;
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] words = line.Split();
                    foreach (string item in words)
                    {
                        if (item.All(char.IsDigit))
                        {
                            Console.WriteLine("{0} ", item);
                        }
                    }
                }
            }
        }

        static void ReplaceSymbols(FileInfo file)
        {
            string path = @file.Name;
            string text;
            using (StreamReader sr = new StreamReader(path))
            {
                text = sr.ReadToEnd();
            }

            text = text.Replace(",", " ");
            text = text.Replace(".", " ");
            text = text.Replace("*", " ");
            text = text.Replace("(", " ");
            text = text.Replace(")", " ");

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(text);
            }
        }
        static void Main(string[] args)
        {
            FileInfo file = new FileInfo("text.txt");
            Action<FileInfo> action;

            action = GetText;
            ReadFiles(file, action);
            action = GetDigits;
            ReadFiles(file, action);
            action = ReplaceSymbols;
            ReadFiles(file, action);
            action = GetText;
            ReadFiles(file, action);

            Console.ReadKey();
        }
    }
}
