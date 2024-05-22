using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace mod_lab10_ufo
{
    public partial class Form1 : Form
    {
        static int x0 = 10, y0 = 10;
        static int xk = 1400, yk = 900;
        static double x1 = x0, y1 = y0;
        static double distance = Math.Sqrt(Math.Pow(xk - x1, 2) + Math.Pow(yk - y1, 2));
        static int value = 10;
        static int step = 5;
        static int n = 5;
        double angle = Math.Atan((double)Math.Abs(yk - y0) / (double)Math.Abs(xk - x0));

        private void timer_Tick(object sender, EventArgs e)
        {
            picBoxGraph.Invalidate();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            create_graph();
        }

        private void create_graph()
        {
            chart.Series[0].Points.Clear();
            
            for (int n = 5; n >= 1; n--)
            {
                for (int value = 1; value < 100; value++)
                {
                    double x1 = x0, y1 = y0;
                    double distance = Math.Sqrt(Math.Pow(xk - x1, 2) + Math.Pow(yk - y1, 2));

                    int count = 0;
                    while (distance > value && count < 1000)
                    {
                        x1 += step * cos(angle, n);
                        y1 += step * sin(angle, n);
                        distance = Math.Sqrt(Math.Pow(xk - x1, 2) + Math.Pow(yk - y1, 2));
                        count++;
                    }
                    if (count < 1000)
                    {
                        chart.Series[0].Points.AddXY(value, n);
                        break;
                    }
                }
            }
            chart.Visible = true;
            chart.SaveImage("dia.png", ChartImageFormat.Png);

        }

        private void picBoxGraph_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.ScaleTransform(0.5f, 0.5f);
            Brush b = new SolidBrush(Color.Indigo);

            if (distance > value)
            {
                g.FillEllipse(b, x0 - 10, y0 - 10, 10 * 2, 10 * 2);
                g.FillEllipse(b, xk - value, yk - value, value * 2, value * 2);

                x1 += step * cos(angle, n);
                y1 += step * sin(angle, n);

                g.FillEllipse(b, (int)x1 - 5, (int)y1 - 5, 10, 10);

                distance = Math.Sqrt(Math.Pow(xk - x1, 2) + Math.Pow(yk - y1, 2));
            }
            else
            {
                b = new SolidBrush(Color.Green);
                g.FillEllipse(b, x0 - 10, y0 - 10, 10 * 2, 10 * 2);
                g.FillEllipse(b, xk - value, yk - value, value * 2, value * 2);
                timer.Enabled = false;
                create_graph();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            value = int.Parse(textBoxArea.Text);
            timer.Enabled = true;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private double cos(double agle, int n)
        {
            double x = 0;
            for (int i = 1; i <= n; i++)
            {
                x += Math.Pow(-1, i - 1) * (double)Math.Pow(angle, 2 * i - 2) / factorial(2 * i - 2);
            }
            return x;
        }

        private double sin(double agle, int n)
        {
            double x = 0;
            for (int i = 1; i <= n; i++)
            {
                x += Math.Pow(-1, i - 1) * (double)Math.Pow(angle, 2 * i - 1) / factorial(2 * i - 1);
            }
            return x;
        }

        private int factorial(int n)
        {
            if (n <= 1) return 1;
            return n * factorial(n - 1);
        }
    }
}
