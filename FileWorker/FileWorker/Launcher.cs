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
        bool flag = false;
        string namefolder;
        string pathDirectory = Resource.path;
        string pathToFileForCopy = Resource.fileTwo;
        string nameFile = Resource.nameFile;
        string path;
        string pathWithNameFile;


        static void Main(string[] args)
        {
            Launcher launcher = new Launcher();

            launcher.CreateDirectory();
            launcher.CreateFile();
            launcher.CopyInformationInAnitherFile();

            Console.ReadLine();
        }

        bool IsValidFilename(string name)
        {
            Regex containsABadCharacter = new Regex("[" + Regex.Escape(new String(Path.GetInvalidFileNameChars()) + "]"));

            if (containsABadCharacter.IsMatch(name))
            {
                return false;
            }
            return true;
        }


        public string EnterNameFolder()
        {
            Console.WriteLine(@"Please enter name folder without /\:*?<>| ");

            while (flag == false)
            {
                namefolder = Console.ReadLine();
                flag = IsValidFilename(namefolder);

                if (!flag)
                {
                    Console.WriteLine("Please enter name of folder again without invalid symbol");
                }
            }
            return namefolder;
        }


        public void CreateDirectory()
        {
            bool haveDir;

            IEnumerable<string> directs = Directory.EnumerateDirectories(pathDirectory); //запись всех папок

            do
            {
                haveDir = false;
                string name = EnterNameFolder();
                foreach (string s in directs)
                {
                    if (s.Contains(name))
                    {
                        Console.WriteLine("Folder with this name exist");
                        haveDir = true;
                        flag = false;
                        break;
                    }
                }
            }
            while (haveDir);

            path = pathDirectory + namefolder;

            Directory.CreateDirectory($@"{path}");
            Console.WriteLine("Folder created.Path: " + path);
        }


        public void CreateFile()
        {
            pathWithNameFile = path + @"\" + nameFile;
            File.Create(pathWithNameFile).Close();
            Console.WriteLine("Path with name of file: " + pathWithNameFile);
        }


        public List<String> CopyInformationInAnitherFile()
        {
            List<String> fileStrings = new List<String>();

            StreamReader fs = new StreamReader(pathToFileForCopy);
            String bufStr = fs.ReadLine();

            int count = 1;
            while ((bufStr != null) && (count <= 20))
            {
                fileStrings.Add(bufStr);
                bufStr = fs.ReadLine();
                count++;
            }
            File.WriteAllLines(pathWithNameFile, fileStrings);
            return fileStrings;
        }
    }
}
