using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mathematics;
using System.IO;
using System.Globalization;

namespace ConsoleApplication
{
    class Launcher
    {
        public double a;
        public double b;
        public double c;
        public string caseSwitch = "";
        public string pathWithNameFile;
        List<double> coefficientsList;
        public string path = Resource.path;
        public string nameFile = Resource.nameFile;

        // double temp;
        //  public string separatorOnComputer = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
        //public string separatorFirst = ".";
        //public string separatorSecond = ",";
        //public char separatorForReplaceFirst = '.';
        //public char separatorForReplaceSecond = ',';

        static void Main(string[] args)
        {
            Launcher launcher = new Launcher();
            Mathematics.Math1 math = new Mathematics.Math1();

            launcher.ChooseQuation();
            launcher.EnterCoefficients();
            math.Split(launcher.coefficientsList, launcher.caseSwitch);
            launcher.Cases();
            launcher.LogFile();

            Console.ReadLine();
        }

        public string ChooseQuation()
        {
            do
            {
                Console.WriteLine("Please enter type of equation \n" +
                "1-linear equation \n" +
                "2-quadratic equation \n");
                caseSwitch = Console.ReadLine();
            }
            while (!((caseSwitch.Equals("1")) || (caseSwitch.Equals("2"))));


            return caseSwitch;
        }

        public void Cases()
        {
            switch (caseSwitch)
            {
                case "1":
                    Math1.LinearEquation();
                    break;
                case "2":
                    Math1.QuadraticEquation();
                    break;
            }
        }


        public List<double> EnterCoefficients()
        {

            coefficientsList = new List<double>();
            if (caseSwitch.Equals("1"))
            {
                Console.WriteLine("Plese enter first coefficient ");
                while (!Double.TryParse(Console.ReadLine(), out a))
                {
                    // Console.WriteLine(temp);
                    Console.WriteLine("Exception!!Please 'a'  again ");
                }

                Console.WriteLine("Plese enter second coefficient ");
                while (!Double.TryParse(Console.ReadLine(), out b))
                {

                    Console.WriteLine("Exception!!Please 'b'  again ");
                }

                coefficientsList.Add(a);
                coefficientsList.Add(b);
            }

            else if (caseSwitch.Equals("2"))
            {
                Console.WriteLine("Plese enter first coefficient ");
                while (!Double.TryParse(Console.ReadLine(), out a))
                {
                    Console.WriteLine("Exception!!Please 'a'  again ");
                }

                Console.WriteLine("Plese enter second coefficient ");
                while (!Double.TryParse(Console.ReadLine(), out b))
                {
                    Console.WriteLine("Exception!!Please 'b'  again ");
                }

                Console.WriteLine("Plese enter third coefficient ");
                while (!Double.TryParse(Console.ReadLine(), out c))
                {
                    Console.WriteLine("Exception!!Please 'c'  again ");
                }

                coefficientsList.Add(a);
                coefficientsList.Add(b);
                coefficientsList.Add(c);
            }

            return coefficientsList;
        }


        public void LogFile()
        {
            CreateFile();
            string x = Math1.QuadraticEquation();
            StreamWriter sw = File.CreateText(pathWithNameFile);
            if (caseSwitch.Equals("1"))
            {
                sw.WriteLine("linear equation");
                sw.WriteLine(a + "x+" + b + "=0");
                double x1 = Math1.LinearEquation();
                sw.WriteLine("x=" + x1);
                // sw.WriteLine(temp);
            }
            else
            {
                sw.WriteLine("quadratic equation");
                sw.WriteLine(a + "x^2+" + b + "x+" + c + "=0");
                sw.WriteLine(x);
            }

            sw.Close();
        }


        public void CreateFile()
        {
            pathWithNameFile = path + @"\" + nameFile;
            File.Create(pathWithNameFile).Close();
            Console.WriteLine("Path with name of file: " + pathWithNameFile);
        }
    }
}
