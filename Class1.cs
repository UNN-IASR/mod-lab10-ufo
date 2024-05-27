using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mod_lab10_ufo
{
    public class Class1
    {
         public static double Sin(double x, int n = 5)
        {
            double sum = 0;
            bool negative = false;
            if (x < 0) { negative = true; x = -x; } // Обрабатываем отрицательные значения
            for (int i = 1; i <= n; i += 1)
            {
                double term = Math.Pow(-1, i-1) * Math.Pow(x, 2*i-1) / Factorial(2*i-1);
                sum += term;
            }
            return negative ? -sum : sum;
        }
        public static double Cos(double x, int n = 20)
        {
            double sum = 0;
            bool negative = false;
            if (x < 0) { negative = true; x = -x; } // Обрабатываем отрицательные значения
            for (int i = 1; i <= n; i += 1)
            {
                double term = Math.Pow(-1, i-1) * Math.Pow(x, 2*i-2) / Factorial(2*i-2);
                sum += term;
            }
            return negative ? -sum : sum;
        }
        static long Factorial(int n)
        {
            if (n == 0)
                return 1;
            else
            {
                int result = 1;
                for (int i = 1; i <= n; i++)
                    result = result * i;
                return result;
            }
        }
            
    }
}
