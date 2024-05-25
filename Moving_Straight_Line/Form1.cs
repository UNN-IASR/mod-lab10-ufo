using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Moving_Straight_Line
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            List<double> accuracies = new List<double>();

            Pen pen = new Pen(Color.Purple, 40);
            Brush brush = new SolidBrush(Color.Red);
            Graphics g = e.Graphics;
            g.ScaleTransform(0.5f, 0.5f);

            for (int number_terms = 2; number_terms <= 10; number_terms++)
            {
                double x0 = 10;
                double y0 = 10;
                double xk = 2800;
                double yk = 2000;
                double step = 100;
                double value = 100;
                double distance = Math.Sqrt(Math.Pow((xk - x0), 2) + Math.Pow((yk - y0), 2));
                double angle = -arctg(number_terms, Math.Abs(yk - y0) / Math.Abs(xk - x0));
                double x1 = x0;
                double y1 = y0;

                while (distance > value)
                {
                    if (number_terms == 10) g.DrawEllipse(pen, (int)x1, (int)y1, 2, 2);
                    x1 += step * cos(number_terms, angle);
                    y1 -= step * sin(number_terms, angle);
                    distance = Math.Sqrt(Math.Pow((x1 - xk), 2) + Math.Pow((y1 - yk), 2));
                }
                accuracies.Add(distance);
            }

            chart1.Legends.Clear();
            chart1.Series[0].ChartType = SeriesChartType.Line;
            chart1.Series.Add(".");
            chart1.Series[1].ChartType = SeriesChartType.Point;
            chart1.ChartAreas[0].AxisX.Title = "Радиус точки";
            chart1.ChartAreas[0].AxisY.Title = "Члены ряда";

            for (int i = 0; i < accuracies.Count; i++)
            {
                chart1.Series[0].Points.AddXY((int)accuracies[i], i + 1);
                chart1.Series[1].Points.AddXY((int)accuracies[i], i + 1);
            }
        }

        private int factorial(int n)
        {
            if (n == 0)
                return 1;
            else
                return n * factorial(n - 1);
        }

        private double sin(int number_terms, double x)
        {
            double sin = 0.0;
            for (int n = 1; n <= number_terms; n++)
            {
                sin += Math.Pow(-1, n - 1) * Math.Pow(x, 2 * n - 1) / factorial(2 * n - 1);
            }
            return sin;
        }

        private double cos(int number_terms, double x)
        {
            double cos = 0.0;
            for (int n = 1; n <= number_terms; n++)
            {
                cos += Math.Pow(-1, n - 1) * Math.Pow(x, 2 * n - 2) / factorial(2 * n - 2);
            }
            return cos;
        }

        private double arctg(int number_terms, double x)
        {
            double arctg = 0;
            if (-1 <= x && x <= 1)
            {
                for (int n = 1; n <= number_terms; n++)
                {
                    arctg += Math.Pow(-1, n - 1) * Math.Pow(x, 2 * n - 1) / (2 * n - 1);
                }
            }
            else
            {
                if (x > 1)
                {
                    arctg = arctg + Math.PI / 2;
                    for (int n = 0; n < number_terms; n++)
                    {
                        arctg -= Math.Pow(-1, n) / ((2 * n + 1) * Math.Pow(x, 2 * n + 1));
                    }
                }
                else
                {
                    arctg = arctg - Math.PI / 2;
                    for (int n = 0; n < number_terms; n++)
                    {
                        arctg -= Math.Pow(-1, n) / ((2 * n + 1) * Math.Pow(x, 2 * n + 1));
                    }
                }
            }
            return arctg;
        }
    }
}
