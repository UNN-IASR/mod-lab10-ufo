using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            List<double> calculation_error = new List<double>();

            Graphics g = e.Graphics;
            g.ScaleTransform(0.5f, 0.5f);

            for (int number_of_row_members = 2; number_of_row_members <= 15; number_of_row_members++)
            {
                double x1 = 159;
                double y1 = 206;
                double x2 = 1815;
                double y2 = 1150;
                double step = 50;
                double distance = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
                double angle = -Arctg(number_of_row_members, Math.Abs(y2 - y1) / Math.Abs(x2 - x1));
                double X = x1;
                double Y = y1;
                while (distance > 50) //step=50
                {
                    X += step * Cos(number_of_row_members, angle);
                    Y -= step * Sin(number_of_row_members, angle);
                    distance = Math.Sqrt(Math.Pow((X - x2), 2) + Math.Pow((Y - y2), 2));
                }
                calculation_error.Add(distance);
            }
            chart1.Legends.Clear();
            chart1.Series[0].ChartType = SeriesChartType.Line;
            chart1.Series[0].Color = Color.Red;
            chart1.Series.Add(".");
            chart1.Series[1].ChartType = SeriesChartType.Point;
            chart1.Series[1].MarkerStyle = MarkerStyle.Circle;
            chart1.Series[1].MarkerSize = 7;
            chart1.Series[1].MarkerColor = Color.DarkRed;
            chart1.Titles.Add("График зависимости точности расчетов (количество членов ряда) от радиуса зоны попадания вокруг (x2,y2)");
            chart1.ChartAreas[0].AxisX.Title = "Количество членов ряда";
            chart1.ChartAreas[0].AxisY.Title = "Погрешность";
            for (int i = 0; i < calculation_error.Count; i++)
            {
                chart1.Series[0].Points.AddXY(i + 1, (int)calculation_error[i]);
                chart1.Series[1].Points.AddXY(i + 1, (int)calculation_error[i]);
            }
            chart1.SaveImage("График.png", ChartImageFormat.Png);
        }
        public static long Fact(long n)
        {
            if (n == 0)
                return 1;
            else
                return n * Fact(n - 1);
        }
        public static double Sin(int numberOfTerms, double x)
        {
            double sin = 0.0;
            for (int n = 1; n <= numberOfTerms; n++)
            {
                sin += Math.Pow(-1, n - 1) * Math.Pow(x, 2 * n - 1) / Fact(2 * n - 1);
            }
            return sin;
        }

        public static double Cos(int numberOfTerms, double x)
        {
            double cos = 0.0;
            for (int n = 1; n <= numberOfTerms; n++)
            {
                cos += Math.Pow(-1, n - 1) * Math.Pow(x, 2 * n - 2) / Fact(2 * n - 2);
            }
            return cos;
        }

        public static double Arctg(int numberOfTerms, double x)
        {
            double arctg = 0;
            if (-1 <= x && x <= 1)
            {
                for (int n = 1; n <= numberOfTerms; n++)
                {
                    arctg += Math.Pow(-1, n - 1) * Math.Pow(x, 2 * n - 1) / (2 * n - 1);
                }
            }
            else
            {
                if (x > 1)
                {
                    arctg = arctg + Math.PI / 2;
                    for (int n = 0; n < numberOfTerms; n++)
                    {
                        arctg -= Math.Pow(-1, n) / ((2 * n + 1) * Math.Pow(x, 2 * n + 1));
                    }
                }
                else
                {
                    arctg = arctg - Math.PI / 2;
                    for (int n = 0; n < numberOfTerms; n++)
                    {
                        arctg -= Math.Pow(-1, n) / ((2 * n + 1) * Math.Pow(x, 2 * n + 1));
                    }
                }
            }
            return arctg;
        }
    }
}
