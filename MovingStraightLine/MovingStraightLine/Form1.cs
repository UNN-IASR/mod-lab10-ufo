using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MovingStraightLine
{
    public partial class Form1 : Form
    {
        private int step = 0;
        private int count = 1;
        private double currentX = 0;
        private double currentY = 0;
        private double minDistance = double.MaxValue;
        private readonly List<double> distances = new List<double>();
        private readonly Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            formsPlot1.Visible = false;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.ScaleTransform(0.3F, 0.3F);
            int startX = 50;
            int startY = 100;
            int endX = 1500;
            int endY = 1000;

            Rectangle startRect = new Rectangle(startX, startY, 50, 50);
            Rectangle endRect = new Rectangle(endX, endY, 50, 50);
            graphics.DrawEllipse(Pens.Black, startRect);
            graphics.DrawEllipse(Pens.Black, endRect);

            Rectangle currentRect = new Rectangle((int)currentX, (int)currentY, 50, 50);
            graphics.DrawEllipse(new Pen(Color.Black), currentRect);
        }

        private void CreateGraph()
        {
            formsPlot1.Plot.XLabel("Count");
            formsPlot1.Plot.YLabel("Dist");
            formsPlot1.Plot.ShowLegend();
            formsPlot1.Plot.Axes.SetLimits(0, 11, 0, 100);
            formsPlot1.Refresh();
        }

        private void UpdateGraph()
        {
            int[] xValues = Enumerable.Range(1, distances.Count).ToArray();
            formsPlot1.Plot.Clear();
            formsPlot1.Plot.Add.Scatter(xValues, distances.ToArray());
            formsPlot1.Refresh();
        }

        private void UpdatePosition()
        {
            int startX = 50;
            int startY = 100;
            int endX = 1500;
            int endY = 1000;

            double angle = -Atan((Math.Abs(endY - startY) + 0.000001) / (Math.Max(Math.Abs(endX - startX), 0.000001)), 10);
            currentX = startX + step * Cos(count, angle);
            currentY = startY - step * Sin(count, angle);
            UpdateCountAndDistance(endX, endY, (int)currentX, (int)currentY);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (count > 10)
            {
                timer1.Enabled = false;
                SaveResult();
            }
            step += 25;
            UpdatePosition();
            this.Invalidate();
        }

        private void UpdateCountAndDistance(int targetX, int targetY, int currentX, int currentY)
        {
            double distance = Math.Sqrt(Math.Pow(targetX - currentX, 2) + Math.Pow(targetY - currentY, 2));

            if (distance < minDistance)
            {
                minDistance = distance;
            }
            else
            {
                minDistance = double.MaxValue;
                count++;
                currentX = 0;
                currentY = 0;
                step = 0;
                distances.Add(distance);
                UpdateGraph();
            }
        }

        private void SaveResult()
        {
            formsPlot1.Plot.SavePng("dia.png", 1920, 1080);
        }

        private double Sin(int terms, double x)
        {
            double result = 0.0;
            for (int i = 1; i <= terms; i++)
            {
                result += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 1) / Factorial(2 * i - 1);
            }
            return result;
        }

        private double Cos(int terms, double x)
        {
            double result = 0.0;
            for (int i = 1; i <= terms; i++)
            {
                result += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 2) / Factorial(2 * i - 2);
            }
            return result;
        }

        private double Atan(double x, int k)
        {
            if (Math.Abs(x) > 1)
            {
                return Math.Sign(x) * Math.PI / 2 - Atan(1 / x, k);
            }

            double result = 0.0;
            for (int n = 1; n <= k; n++)
            {
                double term = Math.Pow(-1, n - 1) * Math.Pow(x, 2 * n - 1) / (2 * n - 1);
                result += term;
            }

            return result;
        }

        private int Factorial(int n)
        {
            return (n == 0) ? 1 : n * Factorial(n - 1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!formsPlot1.Visible)
            {
                formsPlot1.Visible = true;
                CreateGraph();
                timer1.Interval = 5;
                timer1.Enabled = true;
            }
        }
    }
}