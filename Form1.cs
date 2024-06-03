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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private int step = 0;
        private int count = 1;
        private double x3 = 0;
        private const double accuracy = 0.00001;
        private double y3 = 0;
        private double MinDist = double.MaxValue;
        private List<double> Values = new List<double>();
        private readonly Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
            formsPlot1.Visible = false;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.ScaleTransform(0.3F, 0.3F);
            int x1 = 50;
            int y1 = 100;
            int x2 = 1500;
            int y2 = 1000;
            Rectangle rect1 = new Rectangle(x1, y1, 50, 50);
            Rectangle rect2 = new Rectangle(x2, y2, 50, 50);
            g.DrawEllipse(Pens.Black, rect1);
            g.DrawEllipse(Pens.Black, rect2);

            x3 = x1;
            y3 = y1;
            double angle = -Math.Atan((Math.Abs(y2 - y1) + accuracy) / (Math.Max(Math.Abs(x2 - x1), accuracy)));
            double stepMultiplier = 1.0 / Math.Sqrt(count);
            x3 += Math.Round(step * Cos(count, angle)) * stepMultiplier;
            y3 -= Math.Round(step * Sin(count, angle)) * stepMultiplier;
            ChangeCount(x2, y2, (int)x3, (int)y3);
            Rectangle rect3 = new Rectangle((int)x3, (int)y3, 50, 50);
            g.DrawEllipse(new Pen(new SolidBrush(System.Drawing.Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256))), 1), rect3);
        }

        private void CreateGraph()
        {
            formsPlot1.Plot.XLabel("Число членов ряда");
            formsPlot1.Plot.YLabel("Погрешность");
            formsPlot1.Plot.Title("График");
            formsPlot1.Plot.ShowLegend();
            int[] mass = { 1,2, 3,4, 5,6, 7, 8, 9,10 };
            formsPlot1.Plot.Add.Scatter(mass, Values.ToArray());
            formsPlot1.Plot.SavePng("dia.png", 1920, 1080);
            formsPlot1.Visible = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (count >= 11)
            {
                timer1.Enabled = false;
                CreateGraph();
            }
            step +=15;
            Invalidate();
        }

        private void ChangeCount(int x2, int y2, int x3, int y3)
        {
            float xR = x2 - x3;
            float yR = y2 - y3;
            float dist = (float)Math.Sqrt(Math.Pow(xR, 2) + Math.Pow(yR, 2));
            if (dist < MinDist)
            {
                MinDist = dist;
            }
            else
            {
                MinDist = double.MaxValue;
                count += 1;
                x3 = 0;
                y3 = 0;
                step = 0;
                Values.Add(dist);
            }
        }

        private double Sin(int count, double x)
        {
            double res = 0.0;
            for (int i = 1; i <= count; i++)
            {
                res += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 1) / (Convert.ToDouble(Factorial(2 * i - 1)));
            }
            return res;
        }

        private double Cos(int count, double x)
        {
            double res = 0.0;
            for (int i = 1; i <= count; i++)
            {
                res += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 2) / (Convert.ToDouble(Factorial(2 * i - 2)));
            }
            Console.WriteLine(res);
            return res;
        }

        private int Factorial(int n)
        {
            return (n == 0) ? 1 : n * Factorial(n - 1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
    }
}