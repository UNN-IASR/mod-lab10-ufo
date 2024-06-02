using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal static class MathTrigonometry
    {
        static private double Factorial(int n)
        {
            double res = 1;

            if (n < 1)
                return res;

            for (int i = 1; i <= n; i++)
                res *= i;
            return res;
        }
        static public double Sin(double x, int n)
        {
            double res = 0;
            int sign = 1;

            for (int i = 0; i < n; i++)
            {
                res += sign * Math.Pow(x, 2 * i + 1) / Factorial(2 * i + 1);
                sign *= -1;
            }

            return res;
        }

        static public double Cos(double x, int n)
        {
            double res = 0;
            int sign = 1;

            for (int i = 0; i < n; i++)
            {
                res += sign * Math.Pow(x, 2 * i) / Factorial(2 * i);
                sign *= -1;
            }

            return res;
        }

        static public double Atan(double x, int n)
        {
            double res = 0;
            int sign = 1;

            if (Math.Abs(x) > 1)
            {
                res = Math.PI / 2;
                x = 1 / x;
                sign = -1;
            }


            for (int i = 0; i < n; i++)
            {
                res += sign * Math.Pow(x, 2 * i + 1) / (2 * i + 1);
                sign *= -1;
            }

            return res;
        }
    }
}
