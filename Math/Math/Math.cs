using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathematics
{
    public class Math1
    {
        public static double a;
        public static double b;
        public static double c;
        public static double x1;
        public static double x2;
        public static double discriminant;
        public static double x1x2;
        public static string countNumbersAfterVirgule = "0.00";

        public void Split(List<Double> coefficientsList, string caseSwitch)
        {
            if (caseSwitch.Equals("1"))
            {
                a = coefficientsList[0];
                b = coefficientsList[1];
            }
            else if (caseSwitch.Equals("2"))
            {
                a = coefficientsList[0];
                b = coefficientsList[1];
                c = coefficientsList[2];
            }
        }

        public static double LinearEquation()
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
                x1 = (-b) / a;
                Console.WriteLine("x= " + x1.ToString(countNumbersAfterVirgule));
            }
            return x1;
        }

        public static bool Descrriminant()
        {

            if (a == 0 && b == 0 && c == 0)
            {
                Console.WriteLine("Equation have any solution ");
                return false;
            }
            else if ((a == 0 && b == 0) || a == 0)
            {
                Console.WriteLine("Equation doesn't have solutions");
                return false;
            }

            else
            {
                discriminant = ((b * b) - 4 * a * c);
            }
            return true;
        }

        public static string QuadraticEquation()
        {
            bool desc = Descrriminant();
            if (desc == true)
            {
                Console.WriteLine("discriminant= " + discriminant);
                if (discriminant > 0)
                {
                    x1 = ((-b) + Math.Sqrt(discriminant)) / (2 * a);
                    x2 = ((-b) - Math.Sqrt(discriminant)) / (2 * a);
                    Console.WriteLine("x1= " + x1.ToString(countNumbersAfterVirgule));
                    Console.WriteLine("x2= " + x2.ToString(countNumbersAfterVirgule));

                    return x1 + " " + x2;
                }
                else if (discriminant == 0)
                {
                    x1 = ((-b)) / (2 * a);
                    Console.WriteLine("x1=x2= " + x1.ToString(countNumbersAfterVirgule));
                }
                else if (discriminant < 0)
                {
                    Console.WriteLine("discriminant <0 ");
                }
            }
            return x1 + "";
        }
    }
}
