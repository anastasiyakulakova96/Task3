using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mathematics;
using System.IO;
using System.Globalization;
using Logging;

namespace ConsoleApplication
{
    class Launcher
    {
        public static string countNumbersAfterVirgule = "0.00";

        private double a;
        private double b;
        private double c;
        private double descrriminant;
        private string caseSwitch = "";
        private Mathematics.Math1 math;
        private Logger logger = Logger.GetLogger();

        // double temp;
        //  public string separatorOnComputer = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
        //public string separatorFirst = ".";
        //public string separatorSecond = ",";
        //public char separatorForReplaceFirst = '.';
        //public char separatorForReplaceSecond = ',';

        static void Main(string[] args)
        {
            Launcher launcher = new Launcher();

            launcher.ChooseQuation();
            launcher.EnterCoefficients();
            launcher.Cases();
            launcher.CloseLogger();

            Console.ReadLine();
        }

        public void ChooseQuation()
        {
            do
            {
                Console.WriteLine("Please enter type of equation \n" +
                "1-linear equation \n" +
                "2-quadratic equation \n");
                caseSwitch = Console.ReadLine();
            }
            while (!((caseSwitch.Equals("1")) || (caseSwitch.Equals("2"))));
        }

        public void EnterCoefficients()
        {
            if (caseSwitch.Equals("1"))
            {
                Console.WriteLine("Plese enter first coefficient ");
                string line = null;
                while (!Double.TryParse(line = Console.ReadLine(), out a))
                {
                    logger.Log("coef a: " + line);
                    Console.WriteLine("Exception!!Please 'a'  again ");
                }
                
                Console.WriteLine("Plese enter second coefficient ");
                while (!Double.TryParse(line = Console.ReadLine(), out b))
                {
                    logger.Log("coef b: " + line);
                    Console.WriteLine("Exception!!Please 'b'  again ");
                }

                math = new Math1(a, b);
            }

            else if (caseSwitch.Equals("2"))
            {
                string line = null;
                Console.WriteLine("Plese enter first coefficient ");
                while (!Double.TryParse(line = Console.ReadLine(), out a))
                {
                    logger.Log("coef a: " + line);
                    Console.WriteLine("Exception!!Please 'a'  again ");
                }
                
                Console.WriteLine("Plese enter second coefficient ");
                while (!Double.TryParse(line = Console.ReadLine(), out b))
                {
                    logger.Log("coef b: " + line);
                    Console.WriteLine("Exception!!Please 'b'  again ");
                }
                
                Console.WriteLine("Plese enter third coefficient ");
                while (!Double.TryParse(line = Console.ReadLine(), out c))
                {
                    logger.Log("coef c: " + line);
                    Console.WriteLine("Exception!!Please 'c'  again ");
                }

                math = new Math1(a, b, c);
            }
        }

        public void Cases()
        {
            switch (caseSwitch)
            {
                case "1":
                    LinearEquation();
                    break;
                case "2":
                    QuadraticEquation();
                    break;
            }
        }

        public void LinearEquation()
        {
            if (a == 0 && b == 0)
            {
                Console.WriteLine("Equation have any solution ");
            }
            else if (a == 0)
            {
                Console.WriteLine("Equation doesn't have solutions");
            }
            else
            {
                double x = math.LinearEquation();
                logger.Log("LinearEquation:" + a + "x + " + b + " = 0");
                logger.Log("x = " + x.ToString(countNumbersAfterVirgule));
                Console.WriteLine("x = " + x.ToString(countNumbersAfterVirgule));
            }
        }

        public bool Descrriminant()
        {
            if (a == 0 && b == 0 && c == 0)
            {
                Console.WriteLine("Equation have any solution ");
            }
            else if ((a == 0 && b == 0) || a == 0)
            {
                Console.WriteLine("Equation doesn't have solutions");
            }
            else
            {
                descrriminant = math.Descrriminant();
                Console.WriteLine("Equation doesn't have solutions");
                return true;
            }
            return false;
        }

        public void QuadraticEquation()
        {

            if (Descrriminant())
            {
                Console.WriteLine("descrriminant = " + descrriminant);
                double[] result = math.QuadraticEquation(descrriminant);

                if (result == null)
                {
                    Console.WriteLine("discriminant < 0 ");
                }
                else if (result.Length == 2)
                {
                    logger.Log("QuadraticEquation: " + a + "x^2+" + b + "x+" + c + "=0");
                    logger.Log("x1 = " + result[0].ToString(countNumbersAfterVirgule));
                    logger.Log("x2 = " + result[1].ToString(countNumbersAfterVirgule));
                    Console.WriteLine("x1 = " + result[0].ToString(countNumbersAfterVirgule));
                    Console.WriteLine("x2 = " + result[1].ToString(countNumbersAfterVirgule));
                }
                else if (result.Length == 1)
                {
                    logger.Log("QuadraticEquation: " + a + "x^2+" + b + "x+" + c + "=0");
                    logger.Log("x1 = x2 = " + result[0].ToString(countNumbersAfterVirgule));
                    Console.WriteLine("x1 = x2 = " + result[0].ToString(countNumbersAfterVirgule));
                }
            }
        }

        public void CloseLogger()
        {
            logger.Close();
        }
    }
}
