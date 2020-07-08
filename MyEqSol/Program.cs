using System;

namespace MyEqSol
{
    class Program
    {
        static void Main(string[] args)
        {
            // My simple program to find common solution of two linear equations of two variables.

            Console.WriteLine("aX + bY = e");
            Console.WriteLine("cX + dY = f");
            Console.WriteLine("---------------");

            var eq1 = Enter3Parameters();
            var eq2 = Enter3Parameters();

            Console.WriteLine(Solution(eq1, eq2));
        }
        private static int[] Enter3Parameters()
        {
            int[] res = new int[3];
            string[] arr = new string[3];
            try
            {
                arr = Console.ReadLine().Split(' ',3);
                for (int i = 0; i < arr.Length; i++)
                {
                    res[i] = int.Parse(arr[i]);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Enter3Parameters();
            }
            return res;
        }
        // ------------------------------------------------------------------------------------------
        private static string Solution(int[] a, int[] b)
        {
            int det = 0;
            double inv = 0;

            int e = a[2];
            int f = b[2];
            double first, second;
            try
            {
                //                 a     b     c     d
                det = Determinant2(a[0], a[1], b[0], b[1]);

                if (det == 0 && e == 0 && f == 0)
                    throw new ArgumentException();

                else if (det == 0)
                    throw new FormatException();
            }
            catch (ArgumentException ex1)
            {
                return "Infinite set of solutions.";
            }

            catch (FormatException ex2)
            {
                return "No solution exists.";
            }

            inv = (double)1 / det;
            first = (double)inv * (b[1] * a[2] - a[1] * b[2]);
            second = (double)inv * (-b[0] * a[2] + a[0] * b[2]);
            
            return $"(X = {first} , Y = {second}).";
        }
        // ==========================================================/\===========================
        private static int Determinant2(int a, int b, int c, int d)
        {
            int res = a * d - b * c;
            return res;
        }
    }
}
