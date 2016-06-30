using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathematics
{
    public class Math1
    { 
        public double a;
        public double b;
        public double c;
        public static double x1;
        public static double x2;
        public static double discriminant;
        public static double x1x2;

        public Math1(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        public Math1(double a, double b, double c) : this(a, b)
        {
            this.c = c;
        }

        public double LinearEquation()
        {
            return ((-b) / a);
        }

        public double Descrriminant()
        {
            return ((b * b) - 4 * a * c);
        }

        public double[] QuadraticEquation(double descrriminant)
        {
            double[] results = null;
            if (discriminant > 0)
            {
                results = new double[2];

                x1 = ((-b) + Math.Sqrt(discriminant)) / (2 * a);
                x2 = ((-b) - Math.Sqrt(discriminant)) / (2 * a);

                results[0] = x1;
                results[1] = x2;
            }
            else if (discriminant == 0)
            {
                results = new double[1];

                x1 = ((-b)) / (2 * a);

                results[0] = x1;
            }
            return results;
        }
    }
}
