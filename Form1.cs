using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScottPlot;

namespace DirectMove
{
    public partial class Form1 : Form
    {
        PointF startPoint, endPoint;
        PointF currentPoint;
        int stepSize = 11;
        int currentIteration = 1;
        int maxIterations = 14;
        double minDistance = double.MaxValue;
        ScottPlot.Plot plot = new ScottPlot.Plot();
        Dictionary<double, double> iterationData = new Dictionary<double, double>();

        public Form1()
        {
            InitializeComponent();
            startPoint = new Point(150, 32);
            endPoint = new Point(986, 512);
            currentPoint = startPoint;
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            this.Paint += Form1_Paint;
        }

        private void Draw_Point(Graphics g, PointF p, int r)
        {
            g.DrawEllipse(new Pen(System.Drawing.Color.Green, 4), p.X - r, p.Y - r, 2 * r, 2 * r);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.ScaleTransform(0.5f, 0.5f);
            Draw_Point(g, startPoint, 14);
            Draw_Point(g, endPoint, 14);
            Draw_Point(g, currentPoint, 7);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Text = $"Точность: {currentIteration.ToString()}";
            double angle = CalculateArctan((endPoint.Y - startPoint.Y) / (endPoint.X - startPoint.X), currentIteration);
            currentPoint.X += stepSize * (float)CalculateCosine(angle, currentIteration);
            currentPoint.Y += stepSize * (float)CalculateSine(angle, currentIteration);

            this.Invalidate();

            double distance = Math.Sqrt(Math.Pow(endPoint.X - currentPoint.X, 2) + Math.Pow(endPoint.Y - currentPoint.Y, 2));
            if (distance < minDistance)
            {
                minDistance = distance;
            }
            else
            {
                iterationData.Add(currentIteration, minDistance);
                currentPoint = startPoint;
                minDistance = double.MaxValue;
                currentIteration++;
            }

            if (currentIteration == maxIterations)
            {
                double[] xs = iterationData.Keys.Select(x => (double)x).ToArray();
                double[] ys = iterationData.Values.Select(y => (double)y).ToArray();

                plot.Add.Scatter(xs, ys);
                plot.Axes.SetLimits(1,15,0,10); // Adjust axis limits
                plot.SavePng("dia.png",900,600);
                timer1.Enabled = false;
            }
        }

        private ulong CalculateFactorial(int x)
        {
            ulong result = 1;
            for (int j = 2; j <= x; j++)
                result *= (ulong)j;
            return result;
        }

        private double CalculateCosine(double x, int n)
        {
            double cos = 0;
            for (int i = 0; i < n; i++)
                cos += Math.Pow(-1, i) * Math.Pow(x, 2 * i) / CalculateFactorial(2 * i);
            return cos;
        }

        private double CalculateSine(double x, int n)
        {
            double sin = 0;
            for (int i = 0; i < n; i++)
                sin += Math.Pow(-1, i) * Math.Pow(x, 2 * i + 1) / CalculateFactorial(2 * i + 1);
            return sin;
        }

        private double CalculateArctan(double x, int n)
        {
            double arctan = 0;
            for (int i = 0; i < n; i++)
                arctan += Math.Pow(-1, i) * Math.Pow(x, 2 * i + 1) / (2 * i + 1);
            return arctan;
        }
    }
}
