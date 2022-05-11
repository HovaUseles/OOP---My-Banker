using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOP___My_Banker
{
    internal class FileHandler
    {
        /// <summary>
        /// Path to look for files
        /// </summary>
        private string filePath;
        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        public FileHandler(string path)
        {
            filePath = path;
        }

        public string[] GetFirstNames()
        {
            return File.ReadAllLines(FilePath + "FirstNames.txt");
        }

        public string[] GetLastNames()
        {
            return File.ReadAllLines(FilePath + "LastNames.txt");
        }

        public string GetRandomFirstName()
        {
            string[] fNames = GetFirstNames();
            Random random = new Random();
            return fNames[random.Next(fNames.Length)];       
        }

        public string GetRandomLastName()
        {
            string[] lNames = GetLastNames();
            Random random = new Random();
            return lNames[random.Next(lNames.Length)];
        }
    }
}
