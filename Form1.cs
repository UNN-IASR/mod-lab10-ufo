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
        int step = 0;
        int count = 1;
        double x3 = 0;
        double y3 = 0;
        double MinDist = double.MaxValue;
        List<double> Values = new List<double>();
        public Form1()
        {
            InitializeComponent();
            formsPlot1.Visible = false;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //отрисовываю границы
            Random rnd = new Random();
            Graphics g = e.Graphics;
            g.ScaleTransform(0.3F, 0.3F);
            int x1 = 50;
            int y1 = 100;
            int x2 = 1500;
            int y2 = 1000;
            Rectangle rect1 = new Rectangle(x1, y1, 50, 50);
            Rectangle rect2 = new Rectangle(x2, y2, 50,50);
            g.DrawEllipse(new Pen(new SolidBrush(System.Drawing.Color.Black),1), rect1);
            g.DrawEllipse(new Pen(new SolidBrush(System.Drawing.Color.Black), 1), rect2);

            // смещаем объект
            x3 = x1;
            y3 = y1;
            double angel = -Math.Atan((Math.Abs(y2 - y1) + 0.000001) / (Math.Max(Math.Abs(x2 - x1), 0.000001)));
            x3 += step * Cos(count, angel);
            y3 -= step * Sin(count, angel);
            ChangeCount(x2, y2, (int)x3, (int)y3);
            Rectangle rect3 = new Rectangle((int)x3, (int)y3, 50, 50);
            g.DrawEllipse(new Pen(new SolidBrush(System.Drawing.Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256))), 1), rect3);
        }
        private void CreateGraph()
        {
            formsPlot1.Plot.XLabel("Count");
            formsPlot1.Plot.YLabel("Dist");
            formsPlot1.Plot.ShowLegend();
            int[] mass ={1,2,3,4,5,6,7,8,9,10};
            formsPlot1.Plot.Add.Scatter(mass, Values.ToArray());
            formsPlot1.Plot.SavePng("dia.png", 1920, 1080);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (count == 11)
            {
                formsPlot1.Visible = true;
                timer1.Enabled = false;
                CreateGraph();
            }
            step += 10;
            this.Invalidate();
        }
        private void ChangeCount(int x2,int y2, int x3, int y3)
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

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
        private double Sin(int count, double x)
        {
            double res = 0.0;
            for (int i = 1; i <= count; i++)
            {
                res += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 1) / Factorial(2 * i - 1);
            }
            return res;
        }
        private double Cos(int count, double x)
        {
            double res = 0.0;
            for (int i = 1; i <= count; i++)
            {
                res += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 2) / Factorial(2 * i - 2);
            }
            return res;
        }
        private int Factorial(int n)
        {
            int res = (n == 0) ? 1 : n * Factorial(n - 1);
            return res;
        }
    }
}