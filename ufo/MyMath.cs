using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ufo
{
    public static class MyMath
    {
        public static int F(int n)
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        public static double Cos(double x, int n)
        {
            double result = 0;
            for (int i = 1; i <= n; i++)
            {
                result += Math.Pow(-1, i-1) * Math.Pow(x, 2 * i - 2) / F(2*i - 2);
            }
            return result;
        }

        public static double Sin(double x, int n)
        {
            double result = 0;
            for (int i = 1; i <= n; i++)
            { 
                result += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 1) / F(2 * i - 1);
            }
            return result;
        }

        public static double Atan(double x, int n)
        {
            double result = 0;

            if (x == 1)
            {
                result = Math.PI / 4;
            }
            if (x < 1)
            {
                for (int i = 0; i < n; i++)
                {
                    result += Math.Pow(-1, i) * Math.Pow(x, 2 * i + 1) / (2 * i + 1);
                }
            }
            if (x > 1) 
            {
                for (int i = 0; i < n; i++)
                {
                    result += Math.Pow(-1, i) * Math.Pow(x, (-2) * i - 1) / (2 * i + 1);    
                }
                result = Math.PI / 2 - result;
            }
            return result;
        }
    }
}
