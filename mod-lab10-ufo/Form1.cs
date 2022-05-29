using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mod_lab10_ufo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int FactorFunc(int a)
        {
            if (a == 0)
                return 1;
            else
                return a * FactorFunc(a - 1);
        }
        
        public double SinFunc(double x, int n)
        {
            double sin = 0;
            for (int i = 0; i < n; i++)
            {
                sin += Math.Pow(-1, i) * (Math.Pow(x * Math.PI / 180, 2 * i + 1) / FactorFunc(2 * i + 1));
            }
            return sin;
        }

        public double CosFunc(double x, int n)
        {
            double cos = 0;
            for (int i = 0; i < n; i++)
            {
                cos += Math.Pow(-1, i) * Math.Pow(x * Math.PI / 180, 2 * i) / (FactorFunc(2 * i));
            }
            return cos;
        }

        public double AtanFunc(double x, int n)
        {
            double atan = 0;
            for (int i = 1; i <= n; i++)
            {
                atan += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 1) / (2 * i - 1);
            }
            return atan;
        }

        public void PlotLine(Point x1y1, Point x2y2)
        {
            Graphics g = CreateGraphics();
            g.ScaleTransform(0.5f, 0.5f);
            g.TranslateTransform(Width / 2, Height / 2);
            double k = ((double)(x2y2.Y - x1y1.Y) / (x2y2.X-x1y1.X));
            double b = x1y1.Y - k * x1y1.X;

            g.DrawEllipse(new Pen(Color.Black, 3), x1y1.X - 3, x1y1.Y - 3, 5, 5);
            g.DrawEllipse(new Pen(Color.Red, 3), x2y2.X - 3, x2y2.Y - 3, 5, 5);

            if (x1y1.X < x2y2.X)
            {
                for (int i = x1y1.X; i < x2y2.X; i++)
                {
                    Thread.Sleep(2);
                    g.DrawEllipse(new Pen(Color.Black, 2), new RectangleF(i, (float)(k * i + b), 1, 1));
                }
            }
            else 
            {
                for (int i = x1y1.X; i > x2y2.X; i--)
                {
                    Thread.Sleep(2);
                    g.DrawEllipse(new Pen(Color.Black, 2), new RectangleF(i, (float)(k * i + b), 1, 1));
                }
            }
        }

        public void PlotLineUsingAngle(Point x1y1, Point x2y2, double accuracy, int n)
        {
            double angle = AtanFunc(Math.Abs(x2y2.Y - x1y1.Y) / (double)Math.Abs(x2y2.X - x1y1.X), n) * 180 / Math.PI;
            double dist = Math.Sqrt(Math.Pow(x2y2.Y-x1y1.Y,2)+Math.Pow(x2y2.X - x1y1.X, 2));
            double sin = SinFunc(angle, n);
            double cos = CosFunc(angle, n);

            Graphics g = CreateGraphics();
            g.ScaleTransform(0.5f, 0.5f);
            g.TranslateTransform(Width / 2, Height / 2);

            g.DrawEllipse(new Pen(Color.Black, 3), x1y1.X - 3, x1y1.Y - 3, 5, 5);
            g.DrawEllipse(new Pen(Color.Red, 3), x2y2.X - 3, x2y2.Y - 3, 5, 5);

            double x = x1y1.X;
            double y = x1y1.Y;
            while (dist >= accuracy)
            {
                Thread.Sleep(2);
                x += (x1y1.X < x2y2.X) ? 1 * cos : -1 * cos;
                y += (x1y1.Y < x2y2.Y) ? 1 * sin : -1 * sin;

                g.DrawEllipse(new Pen(Color.Black, 2), new RectangleF((int)x, (int)y, 1, 1));

                double temp = dist;
                dist = Math.Sqrt(Math.Pow(x2y2.Y - y, 2) + Math.Pow(x2y2.X - x, 2));

                if (temp<dist)
                {
                    MessageBox.Show("Не удовлетворяет заданной точности");
                    return;
                }
            }
            MessageBox.Show("Удовлетворяет заданной точности");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                string[] x1y1 = textBox1.Text.Split(';');
                string[] x2y2 = textBox2.Text.Split(';');
                Point firstPoint = new Point(Int32.Parse(x1y1[0]), Int32.Parse(x1y1[1]));
                Point secondPoint = new Point(Int32.Parse(x2y2[0]), Int32.Parse(x2y2[1]));
                PlotLine(firstPoint, secondPoint);
            }
            else
            {
                string[] x1y1 = textBox1.Text.Split(';');
                string[] x2y2 = textBox2.Text.Split(';');
                Point firstPoint = new Point(Int32.Parse(x1y1[0]), Int32.Parse(x1y1[1]));
                Point secondPoint = new Point(Int32.Parse(x2y2[0]), Int32.Parse(x2y2[1]));

                double accuracy = Int32.Parse(textBox3.Text);
                int n = Int32.Parse(textBox4.Text);

                PlotLineUsingAngle(firstPoint, secondPoint, accuracy, n);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox3.ReadOnly = false; textBox3.Visible = true;
                textBox4.ReadOnly = false; textBox4.Visible = true;

                label3.Visible = true;
                label4.Visible = true; 
            }
            else
            {
                textBox3.ReadOnly = true; textBox3.Visible = false;
                textBox4.ReadOnly = true; textBox4.Visible = false;

                label3.Visible = false;
                label4.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] x1y1 = textBox1.Text.Split(';');
            string[] x2y2 = textBox2.Text.Split(';');
            Point firstPoint = new Point(Int32.Parse(x1y1[0]), Int32.Parse(x1y1[1]));
            Point secondPoint = new Point(Int32.Parse(x2y2[0]), Int32.Parse(x2y2[1]));
            Form2 f2 = new Form2(firstPoint, secondPoint);
            f2.Show();
        }
    }
}
