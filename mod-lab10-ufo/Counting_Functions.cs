using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mod_lab10_ufo
{
    public class Counting_Functions
    {
        public static double OWN_DISTANT(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        public static double OWN_ARCTANG(double X_start, double Y_start, double X_end, double Y_end)
        {
            return Math.Atan((double)Math.Abs(Y_end - Y_start) / (double)Math.Abs(X_end - X_start));
        }

        public static int OWN_Factorial(int n)
        {
            if (n == 0) return 1;
            else return n * OWN_Factorial(n - 1);
        }

        public static double OWN_SIN(double angle, int n)
        {
            double sum = 0;
            for (int i = 1; i <= n; i++)
            {
                double helper = 0;
                helper = Math.Pow(-1, i - 1) * (double)Math.Pow(angle, 2 * i - 1) / OWN_Factorial(2 * i - 1);
                sum += helper;
            }
            return sum;
        }

        public static double OWN_COS(double angle, int n)
        {
            double sum = 0;
            for (int i = 1; i <= n; i++)
            {
                double helper = 0;
                helper = Math.Pow(-1, i - 1) * (double)Math.Pow(angle, 2 * i - 2) / OWN_Factorial(2 * i - 2);
                sum += helper;
            }
            return sum;
        }

    }
}
