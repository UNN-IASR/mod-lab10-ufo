using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace LineDrawing
{
    public partial class Form1 : Form
    {
        static double x0 = 100, y0 = 250;
        static double x2 = 1000, y2 = 700;
        static double step = 1;
        static int n = 10;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            double x1 = x0, y1 = y0;

            Graphics g = e.Graphics;
            g.ScaleTransform(0.5f, 0.5f);

            Pen p1 = new Pen(Color.Red, 2);
            Brush b1 = new SolidBrush(Color.Blue);

            g.FillEllipse(b1, (int)x1 - 20, (int)y1 - 20, 40, 40);
            g.FillEllipse(b1, (int)x2 - 20, (int)y2 - 20, 40, 40);
            g.DrawString("Город А " , new Font("Times new roman", 25), Brushes.Black, new PointF((int)x1 + 30, (int)y1 - 30));
            g.DrawString("Город B ", new Font("Times new roman", 25), Brushes.Black, new PointF((int)x2 - 30, (int)y2 - 60));


            double sum = Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
            double distance = Math.Sqrt(Math.Pow(Math.Abs(x1 - x2), 2) + Math.Pow(Math.Abs(y1 - y2), 2));

            double alpha = -myArctg((y2 - y1) / (x2 - x1), n);


            while (distance <= sum)
            {

                x1 += step * myCos(alpha, n);
                y1 -= step * mySin(alpha, n);

                g.DrawEllipse(p1, (int)x1, (int)y1, 1, 1);

                distance = Math.Sqrt(Math.Pow(Math.Abs(x1 - x2), 2) + Math.Pow(Math.Abs(y1 - y2), 2));

                if (distance < sum)
                    sum = distance;
            }


            List<double> points = new List<double>();
            for (int i = 2; i <= 10; i++)
            {
                x1 = x0;
                y1 = y0;
                sum = Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
                distance = Math.Sqrt(Math.Pow(Math.Abs(x1 - x2), 2) + Math.Pow(Math.Abs(y1 - y2), 2));
                alpha = -myArctg((y2 - y1) / (x2 - x1), i);

                while (distance <= sum)
                {

                    x1 = x1 + step * myCos(alpha, i);
                    y1 = y1 - step * mySin(alpha, i);

                    distance = Math.Sqrt(Math.Pow(Math.Abs(x1 - x2), 2) + Math.Pow(Math.Abs(y1 - y2), 2));

                    if (distance < sum)
                        sum = distance;
                }
                points.Add(sum);
            }

            Form2 f2 = new Form2(points);
            f2.Show();
        }

        int myFactorial(int a)
        {
            if (a == 0 || a == 1)
            {
                return 1;
            }
            else
            {
                return a * myFactorial(a - 1);
            }
        }

        double mySin(double x, int n)
        {
            double sin = 0;
            for (int i = 1; i <= n; i++)
            {
                sin += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 1) / myFactorial(2 * i - 1);
            }
            return sin;
        }

        double myCos(double x, int n)
        {
            double cos = 0;
            for (int i = 1; i <= n; i++)
            {
                cos += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i -2) / myFactorial(2 * i - 2);
            }
            return cos;
        }

        double myArctg(double x, int n)
        {
            double arctg = 0;
            for (int i = 1; i <= n; i++)
            {
                arctg += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 1) /(2 * i - 1);
            }

            return arctg;
        }
    }
}
