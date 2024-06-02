using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScottPlot;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        
        private SolidBrush brush = new SolidBrush(System.Drawing.Color.Crimson);
        private Pen pen = new Pen(System.Drawing.Color.Green);
        List<double> dists = new List<double>();
        private int x1 = 50;
        private int y1 = 50;
        private int x2 = 1000;
        private int y2 = 1000;
        int InitialStep = 0;
        int degree = 1;
        double x3 = 0;
        double y3 = 0;
        double minDistance = double.MaxValue;
        public Form1()
        {
            InitializeComponent();
            formsPlot1.Visible = false;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            Random rnd = new Random();
            Graphics g = e.Graphics;
            DrawEllipses(g);
            x3 = x1;
            y3 = y1;
            UpdatePosition();
            Rectangle rect3 = new Rectangle((int)x3, (int)y3, 30, 30);
            g.DrawEllipse(new Pen(new SolidBrush(System.Drawing.Color.Purple),1), rect3);
        }

        private void UpdatePosition()
        {
            double angle = -Math.Atan2(y2 - y1, x2 - x1);
            x3 += InitialStep * Cos(degree, angle);
            y3 -= InitialStep * Sin(degree, angle);
            CheckDistance();
        }


        private void DrawEllipses(Graphics g)
        {
            g.ScaleTransform(0.3F, 0.3F);

            Rectangle rect1 = new Rectangle(x1, y1, 30, 30);
            Rectangle rect2 = new Rectangle(x2, y2, 30, 30);

            g.DrawEllipse(pen, rect1);
            g.DrawEllipse(pen, rect2);
        }
        private void CreateGraph()
        {
            formsPlot1.Plot.XLabel("Count");
            formsPlot1.Plot.YLabel("Dist");
            formsPlot1.Plot.ShowLegend();
            int[] mass = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            formsPlot1.Plot.Add.Scatter(mass, dists.ToArray());
            formsPlot1.Refresh();
            formsPlot1.Plot.SavePng("dia.png", 1920, 1080);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (degree == 11)
            {
                formsPlot1.Visible = true;
                timer1.Enabled = false;
                CreateGraph();
            }
            InitialStep += 10;
            this.Invalidate();
        }

        private void CheckDistance()
        {
            double distance = CalculateDistance(x2, y2, x3, y3);
            if (distance < minDistance) minDistance = distance;
            else
            {
                dists.Add(distance);
                minDistance = double.MaxValue;
                degree++;
                x3 = 0;
                y3 = 0;
                InitialStep = 0;
               
            }
        }

        private double CalculateDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
        private double Sin(int degree, double x)
        {
            double sin = 0.0;
            for (int n = 0; n < degree; n++)
            {
                sin+= Math.Pow(-1, n) * (Math.Pow(x, 2 * n + 1) / Factorial(2 * n + 1));
            }
            return sin;
        }
        private double Cos(int degree, double x)
        {
            double cos = 0.0;
            for (int n = 0; n < degree; n++)
            {
                cos += Math.Pow(-1, n) * Math.Pow(x, 2 * n) / Factorial(2 *n);
            }
            return cos;
        }
        private int Factorial(int n)
        {
            if (n == 0) {
                return 1;
            }
            return n * Factorial(n - 1);
        }


    }
}