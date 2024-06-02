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
            double result = 0;
            for (int i = 0; i < precision; i++)
            {
                int sign = i % 2 == 0 ? 1 : -1;
                result += sign * Math.Pow(x, 2 * i + 1) / Factorial((ulong)(2 * i + 1));
            }
            return result;
        }

        public static double Cos(double x, int precision)
        {
            double result = 0;
            for (int i = 0; i < precision; i++)
            {
                int sign = i % 2 == 0 ? 1 : -1;
                result += sign * Math.Pow(x, 2 * i) / Factorial((ulong)(2 * i));
            }
            return result;
        }

        public static double Atan(double x, int precision)
        {
            double result = 0;
            bool isReciprocal = Math.Abs(x) > 1;
            double transformedX = isReciprocal ? 1 / x : x;

            for (int i = 0; i < precision; i++)
            {
                int sign = i % 2 == 0 ? 1 : -1;
                result += sign * Math.Pow(transformedX, 2 * i + 1) / (2 * i + 1);
            }

            if (isReciprocal)
            {
                result = Math.PI / 2 - result;
                if (x < 0)
                {
                    result = -result;
                }
            }

            return result;
        }

        public static ulong Factorial(ulong n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }

            ulong result = 1;
            for (ulong i = 2; i <= n; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}
