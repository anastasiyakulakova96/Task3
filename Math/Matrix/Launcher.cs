using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MatrixOparat;
using Matrix;

namespace Task3._4
{
    class Launcher
    {

        string text;
        string[] c;
        char[] newLine = { '\n' };
        string path = Resource.path;
        public Matrix matrixA, matrixB;


        static void Main(string[] args)
        {
            Launcher launcher = new Launcher();
            MatrixOparat.MatrixOperation matrix = new MatrixOperation();

            launcher.ReadFile();
            launcher.InitMatrix();
            if (launcher.ValidateMatrixMultiplication())
            {
                double[,] res = matrix.Multiplication(launcher.matrixA.GetMatrix(), launcher.matrixB.GetMatrix());
                Matrix.Print(res);
            }


            Console.ReadLine();
        }

        public void ReadFile()
        {
            text = File.ReadAllText(path);

        }

        public void InitMatrix()
        {
            string[] lines = text.Split(newLine);

            int k = 0;
            c = lines[k].Split(' ');
            int n = Convert.ToInt32(c[0]);
            int m = Convert.ToInt32(c[1]);
            matrixA = new Matrix(n, m);

            k++;
            for (int i = 0; i < n; i++)
            {
                c = lines[k].Split(' ');
                for (int g = 0; g < c.Length; g++)
                {
                    double number = Convert.ToDouble(c[g]);
                    matrixA.Set(i, g, number);
                }
                k++;
            }

            c = lines[k].Split(' ');
            n = Convert.ToInt32(c[0]);
            m = Convert.ToInt32(c[1]);
            matrixB = new Matrix(n, m);

            k++;
            for (int i = 0; i < n; i++)
            {
                c = lines[k].Split(' ');
                for (int g = 0; g < c.Length; g++)
                {
                    double number = Convert.ToDouble(c[g]);
                    matrixB.Set(i, g, number);
                }
                k++;
            }

            Console.WriteLine("Matrix A\n" + matrixA + "\n");
            Console.WriteLine("Matrix B\n" + matrixB + "\n");
        }


        public bool ValidateMatrixMultiplication()
        {
            if (matrixA.GetMatrix().GetLength(1) == matrixB.GetMatrix().GetLength(0))
            {
                return true;
            }
            Console.WriteLine("Error!Columns matrix A != rows matrix B");
            return false;
        }
    }


    public class Matrix
    {
        int m;
        int n;
        double[,] numbers;

        public Matrix(int n, int m)
        {
            numbers = new double[n, m];
        }

        public void Set(int i, int j, double number)
        {
            numbers[i, j] = number;
        }

        public double[,] GetMatrix()
        {
            return numbers;
        }

        public override string ToString()
        {
            string matrix = "";
            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    matrix += numbers[i, j] + " ";
                }
                matrix += "\n";
            }
            return matrix;
        }


        public static void Print(double[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write("{0} ", a[i, j].ToString("0.00"));
                }
                Console.WriteLine();
            }
        }
    }

}