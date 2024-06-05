using System;
using System.Collections.Generic;
using System.Drawing;
using static System.Math;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing.Drawing2D;

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        List<int> number_members = new List<int>();
        List<double> dist = new List<double>();
        public Form1()
        {
            InitializeComponent();
        }
        private static int fact(int value)
        {
            if (value == 0)
                return 1;
            else
                return value * fact(value - 1);
        }

        private static double Sin(int n, double x)
        {
            double sinys = 0;
            for (int i = 1; i <= n; i++)
            {
                sinys += Pow(-1, i - 1) * Pow(x, 2 * i - 1) / fact(2 * i - 1);
            }
            return sinys;
        }

        private static double Cos(int n, double x)
        {
            double cosinys = 0;
            for (int i = 1; i <= n; i++)
            {
                cosinys += Pow(-1, i - 1) * Pow(x, 2 * i - 2) / fact(2 * i - 2);
            }
            return cosinys;
        }

        double Atan(int n, double x)
        {
            double arctan = 0;
            if (-1 <= x && x <= 1)
            {
                for (int i = 1; i < n + 1; i++)
                {
                    arctan += Pow(-1, i - 1) * Pow(x, 2 * i - 1) / (2 * i - 1);
                }
            }
            else
            {
                if (x >= 1)
                {
                    arctan += PI / 2;
                    for (int i = 0; i < n; i++)
                    {
                        arctan -= Pow(-1, i) / ((2 * i + 1) * Pow(x, 2 * i + 1));
                    }
                }
                else
                {
                    arctan -= PI / 2;
                    for (int i = 0; i < n; i++)
                    {
                        arctan -= Pow(-1, i) / ((2 * i + 1) * Pow(x, 2 * i + 1));
                    }
                }
            }
            return -arctan;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 2; i <= 11; i++)
            {
                double X1 = 150;
                double Y1 = 295;
                double X2 = 2255;
                double Y2 = 1450;

                double angle = Atan(i, Abs(Y2 - Y1) / Abs(X2 - X1));
                double distance = Sqrt(Pow(X2 - X1, 2) + Pow(Y2 - Y1, 2));

                double step = 20;
                double x = X1;
                double y = Y1;
                while (distance > step)
                {
                    x += step * Cos(i, angle);
                    y -= step * Sin(i, angle);

                    double new_distance = Sqrt(Pow(x - X2, 2) + Pow(y - Y2, 2));
                    if (new_distance > distance) break;
                    distance = new_distance;

                }
                number_members.Add(i);
                dist.Add(distance);
            }
            chart1.Legends.Clear();
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();

            chart1.Series.Add("_");
            chart1.Series["_"].ChartType = SeriesChartType.Spline;
            chart1.ChartAreas.Add("_");
            chart1.Series["_"].Color = Color.Black;
            chart1.Series["_"].Points.DataBindXY(number_members, dist);

            chart1.Series.Add(".");
            chart1.Series["."].ChartType = SeriesChartType.Point;
            chart1.Series["."].MarkerStyle = MarkerStyle.Circle;
            chart1.Series["."].MarkerSize = 7;
            chart1.Series["."].MarkerColor = Color.Black;
            chart1.Series["."].Points.DataBindXY(number_members, dist);

            //chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            //chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.MajorGrid.Interval = 1;
            chart1.ChartAreas[0].AxisY.MajorGrid.Interval = 5;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 12;

            chart1.Titles.Add("Graph of the dependence of the calculation accuracy (number of row members) on the radius of the hit zone around point");
            chart1.ChartAreas[0].AxisX.Title = "Number of row members";
            chart1.ChartAreas[0].AxisY.Title = "The radius of the hit zone";
            chart1.SaveImage("dia.png", ChartImageFormat.Png);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            GraphicsState gs;
            g.ScaleTransform(0.5f, 0.5f);

            gs = g.Save();
        }
    }
}
