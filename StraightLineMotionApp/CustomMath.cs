using System;

namespace StraightLineMotionApp
{
    public static class CustomMath
    {
        public const int DefaultPrecision = 8;

        public static double Sin(double x) => Sin(x, DefaultPrecision);
        public static double Cos(double x) => Cos(x, DefaultPrecision);
        public static double Atan(double x) => Atan(x, DefaultPrecision);

        public static double Sin(double x, int precision)
        {
            double res = 0;
            for (int i = 1; i <= precision; i++)
            {
                res += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 1) / Factorial(2 * (ulong)i - 1);
            }

            return res;
        }

        public static double Cos(double x, int precision)
        {
            double res = 0;
            for (int i = 1; i <= precision; i++)
            {
                res += Math.Pow(-1, i - 1)
                    * Math.Pow(x, 2 * i - 2)
                    / Factorial(2 * (ulong)i - 2);
            }

            return res;
        }

        public static double Atan(double x, int precision)
        {
            double res = 0;
            int coef = 1;
            if (Math.Abs(x) > 1)
            {
                res = Math.PI * Math.Sqrt(x * x) / (2 * x);
                coef = -1;
            }

            for (int i = 0; i <= precision; i++)
            {
                double an = 0;
                if (coef > 0)
                {
                    an = Math.Pow(-1, i) * Math.Pow(x, 2 * i + 1) / (2 * i + 1);
                }
                else
                {
                    an = Math.Pow(-1, i) * Math.Pow(x, -1 - 2 * i) / (2 * i + 1);
                }

                res += coef * an;
            }

            return res;
        }

        public static ulong Factorial(ulong x)
        {
            ulong res = 1;
            for (ulong i = 2; i <= x; i++)
            {
                res *= x;
            }

            return res;
        }
    }
}
