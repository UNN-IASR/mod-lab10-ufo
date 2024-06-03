using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public double Factorial(int n)
        {
            var factorial = 1;
            for (int i = 1; i <= n; i++)
                factorial *= i;

            return factorial;
        }

        private double Arctg(double x, int iter)
        {
            double output = 0;
            if (x == 1) return Math.PI / 4;
            if (x > 1) output = Math.PI / 2;
            for (int i = 0; i < iter; i++)
            {
                if (x <= 1) output += Math.Pow(-1, i) * Math.Pow(x, 2 * i + 1) / (2 * i + 1);
                else output -= Math.Pow(-1, i) * Math.Pow(x, (-2) * i - 1) / (2 * i + 1);
            }
            return output;
        }

        private double Cos(double x, int iter)
        {
            double output = 0;
            for (int i = 1; i <= iter; i++)
            {
                output += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 2) / (Factorial(2 * i - 2));
            }
            return output;
        }

        private double Sin(double x, int iter)
        {
            double output = 0;
            for (int i = 1; i <= iter; i++)
            {
                output += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 1) / (Factorial(2 * i - 1));
            }
            return output;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            const double x2 = 100;
            const double y2 = 101;
            const double x1 = 250;
            const double y1 = 250;

            int coeff = 1;
            if (x1 > x2) coeff = -1;

            int step = 5;

            e.Graphics.ScaleTransform(0.1f, 0.1f);
            List<double> dataX = new List<double>();
            List<double> dataY = new List<double>();
            for (int iter = 2; iter < 15; iter++)
            {
                double x = x1;
                double y = y1;
                double angle = Arctg(Math.Abs(y2 - y1) / Math.Abs(x2 - x1), iter);
                double angle_true = angle * 180 / Math.PI;
                double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
                while (distance > 0)
                {
                    x += coeff * step * Cos(angle, iter);
                    y += coeff * step * Sin(angle, iter);
                    Rectangle rect = new Rectangle()
                    {
                        X = (int)x - step / 2,
                        Y = (int)y - step / 2,
                        Width = step,
                        Height = step
                    };
                    e.Graphics.DrawEllipse(Pens.Black, rect);
                    double new_distance = Math.Sqrt((x2 - x) * (x2 - x) + (y2 - y) * (y2 - y));
                    if (new_distance >= distance) break;
                    distance = new_distance;
                }
                dataX.Add(iter);
                dataY.Add(distance);
            }
            ScottPlot.Plot myPlot = new ScottPlot.Plot();
            myPlot.Add.Scatter(dataX, dataY);

            myPlot.SavePng("quickstart.png", 400, 300);
            e.Graphics.ResetTransform();
        }
    }
}
