using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace FileWorker
{
    class Launcher
    {
        bool f = false;
        string name;
        string pathDirectory = Resource.path;
        string pathToFileForCopy = "@"+Resource.fileTwo;
        string nameFile = "nastya.txt";
        string path;
        string pathwithNameFile;


        char[] invalidPathChars = Path.GetInvalidPathChars();

        static void Main(string[] args)
        {
            Launcher launcher = new Launcher();
            //launcher.EnterNameFilder();
            launcher.CreateDirectory();
            launcher.CreateFile();
            launcher.CopyFileToFile();


            Console.ReadLine();
        }

        bool IsValidFilename(string testName)
        {
            Regex containsABadCharacter = new Regex("[" + Regex.Escape(new String(Path.GetInvalidFileNameChars()) + "]"));
            if (containsABadCharacter.IsMatch(testName))
            {
                f = false;

                return false;
            }
            else
            {
                f = true;
            }
            return true;
        }



        public string EnterNameFilder()
        {
           
            Console.WriteLine(@"Please enter name filder without /\:*?<>| ");

            while (f == false)
            {
                name = Console.ReadLine();
                if (IsValidFilename(name))
                {
                    Console.WriteLine("Name file is good");
                }
                else
                {
                    Console.WriteLine("Please enter name of file again without invalid symbol");
                }
            }


            return name;
        }


        public void CreateDirectory()
        {
            bool haveDir;
            IEnumerable<string> directs = Directory.EnumerateDirectories(pathDirectory);
            do
            {
                haveDir = false;
                string name = EnterNameFilder();
                foreach (string s in directs)
                {
                    if (s.Contains(name))
                    {
                        Console.WriteLine("this directory have");
                        haveDir = true;
                        f = false;
                        break;
                    }
                }
            }
            while (haveDir);

            path = pathDirectory + name;
            Console.WriteLine(path);
            Directory.CreateDirectory($@"{path}");

        }


        public void CreateFile()
        {
            pathwithNameFile = path + @"\" + nameFile;
            File.Create(pathwithNameFile).Close();

            Console.WriteLine(pathwithNameFile);

        }


        public void CopyFileToFile()
        {
            int i = 0;
            List<string> linesList = new List<string>();
            IEnumerable<string> lines = File.ReadLines(@"d:\forCopy.txt");
            foreach(string line in lines)
            {
                linesList.Add(line);
                Console.WriteLine(line);
                i++;
                if(i == 20)
                {
                    break;
                }
            }
            
           File.WriteAllLines(pathwithNameFile, linesList);
        }
    }

  
}
