using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab10_ufo
{
    public partial class FormUfo : Form
    {
        static int x0, y0;
        static int x2, y2;
        static double x1, y1;
        static double distance;
        static int value;
        static int step;
        static int n;
        double angle;

        public FormUfo()
        {
            InitializeComponent();
            x0 = 100; y0 = 900;
            x2 = 1400; y2 = 100;
            x1 = x0; y1 = y0;
            distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            angle = Math.Atan((double)Math.Abs(y2 - y0) / (double)Math.Abs(x2 - x0));
            value = 10;
            step = 5;
            n = 5;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            picBoxGraph.Invalidate();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            CreateGraph();
        }

        private void picBoxGraph_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.ScaleTransform(0.5f, 0.5f);
            Brush brush = new SolidBrush(Color.Red);

            if (distance > value)
            {
                graphics.FillEllipse(brush, x0 - 10, y0 - 10, 10 * 2, 10 * 2);
                graphics.FillEllipse(brush, x2 - value, y2 - value, value * 2, value * 2);

                x1 += step * Cos(angle, n);
                y1 -= step * Sin(angle, n);

                graphics.FillEllipse(brush, (int)x1 - 5, (int)y1 - 5, 10, 10);

                distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            }
            else
            {
                brush = new SolidBrush(Color.Green);
                graphics.FillEllipse(brush, x0 - 10, y0 - 10, 10 * 2, 10 * 2);
                graphics.FillEllipse(brush, x2 - value, y2 - value, value * 2, value * 2);
                timer.Enabled = false;
                CreateGraph();
            }
        }

        private void CreateGraph()
        {
            chart.Series[0].Points.Clear();
            chart.Series.Add(".");
            chart.Series[1].ChartType = SeriesChartType.Point;

            for (int n = 5; n >= 1; n--)
            {
                for (int value = 1; value < 100; value++)
                {
                    double x1 = x0, y1 = y0;
                    double distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));

                    int count = 0;
                    while (distance > value && count < 1000)
                    {
                        x1 += step * Cos(angle, n);
                        y1 -= step * Sin(angle, n);
                        distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
                        count++;
                    }
                    if (count < 1000)
                    {
                        chart.Series[0].Points.AddXY(value, n);
                        chart.Series[1].Points.AddXY(value, n);
                        break;
                    }
                }
            }
            chart.Visible = true;
            chart.SaveImage("dia.png", ChartImageFormat.Png);

        }

        private double Cos(double agle, int n)
        {
            double x = 0;
            for (int i = 1; i <= n; i++)
            {
                x += Math.Pow(-1, i - 1) * (double)Math.Pow(angle, 2 * i - 2) / Factorial(2 * i - 2);
            }
            return x;
        }

        private double Sin(double agle, int n)
        {
            double x = 0;
            for (int i = 1; i <= n; i++)
            {
                x += Math.Pow(-1, i - 1) * (double)Math.Pow(angle, 2 * i - 1) / Factorial(2 * i - 1);
            }
            return x;
        }

        private int Factorial(int n)
        {
            int fact = 1;
            for (int i = 1; i <= n; i++)
            {
                fact *= i;
            }
            return fact;
        }
    }
}