using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ufo
{
    public partial class Form1 : Form
    {
        static int x0 = 100, y0 = 100;
        static int xk = 900, yk=600;
        static double x1 = x0, y1 = y0;
        int n = 1;
        double alpha;
        Chart myChart = new Chart();
        Series mySeriesOfPoint = new Series();
        double error_x = 1000, error_y = 1000;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "n = " + n.ToString();
            alpha = -Arctg((double)(yk - y0) / (double)(xk - x0), n);
        }
        int fac (int n)
        {
            if (n == 0)
                return 1;
            else
            {
                int temp = 1;
                for(int i = 1; i <= n;i++)
                    temp *= i;
                return temp;
            }
        }
        double Cos(double alpha, int n)
        {
            double temp = 0;
            for (int i = 1; i <= n; i++)
            {
                temp += Math.Pow(-1, i - 1) * (Math.Pow(alpha, 2 * i - 2)) / fac(2 * i - 2);
            }
            return temp;
        }
        double Sin(double alpha, int n)
        {
            double temp = 0;
            for (int i = 1; i <= n; ++i)
            {
                temp += Math.Pow(-1, i - 1) * (Math.Pow(alpha, 2 * i - 1)) / fac(2 * i - 1);
            }
            return temp;
        }
        double Arctg(double alpha, int n)
        {
            double temp = 0;
            for (int i = 1; i <= n; ++i)
            {
                temp = temp + Math.Pow(-1, (i - 1)) * Math.Pow(alpha, (2 * i - 1)) / (2 * i - 1);
            }
            return temp;
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
                    Graphics g = e.Graphics;
                    Brush b = new SolidBrush(Color.Indigo);
                    g.FillEllipse(b, x0 - 10, y0 - 10, 20, 20);
                    g.FillEllipse(b, xk - 10, yk - 10, 20, 20);
                    x1 += (5 * Cos(alpha, n));
                    y1 -= (5 * Sin(alpha, n));
                    g.FillEllipse(b, (int)x1 - 5, (int)y1 - 5, 10, 10);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mySeriesOfPoint.ChartType = SeriesChartType.Line;
            mySeriesOfPoint.ChartArea = "Math functions";
            myChart.Series.Add(mySeriesOfPoint);
            myChart.Parent = this;
            myChart.Dock = DockStyle.Fill;
            myChart.ChartAreas.Add(new ChartArea("Math functions"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
                timer1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled=false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (error_y>Math.Abs(yk-y1)|| error_x > Math.Abs(xk - x1))
            {
                this.Invalidate();
                error_y =Math.Abs(yk-y1);
                error_x =Math.Abs(xk-x1);
            }
            else
            {
                mySeriesOfPoint.Points.AddXY(n, Math.Abs(yk-y1-xk+x1));
                if (n==15)
                    timer1.Enabled = false;
                else
                {
                    x1 = x0;
                    y1 = y0;
                    n++;
                    error_y = 1000;
                    error_x = 1000;
                    alpha = -Arctg((double)(yk - y0) / (double)(xk - x0), n);
                    textBox1.Text = "n = " + n.ToString();
                }
                
            }
        }

        
    }
}
