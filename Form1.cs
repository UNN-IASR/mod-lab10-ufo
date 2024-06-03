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
using System.Windows.Forms.DataVisualization.Charting;

namespace _10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double arctang(double n, int degree)
        {
            double arctg = 0;
            if (n >= -1 && n <= 1)
            {
                for (int i = 1; i <= degree; i++)
                {
                    arctg += Math.Pow(-1, i - 1) * Math.Pow(n, 2 * i - 1) / (2 * i - 1);
                }
            }
            else
            {
                if (n >= 1)
                {
                    arctg += Math.PI / 2;
                }

                else
                {
                    arctg -= Math.PI / 2;
                }

                for (int i = 0; i < degree; i++)
                {
                    arctg -= Math.Pow(-1, i) / ((2 * i + 1) * Math.Pow(n, 2 * i + 1));
                }
            }
            return arctg;
        }
        int fac(int n)
        {
            if (n <= 0)
                return 1;
            return n * fac(n - 1);
        }

        double sin(double n, int degree)
        {
            double sin = 0;
            for (int i = 1; i <= degree; i++)
            {
                sin += Math.Pow(-1, i - 1) * Math.Pow(n, 2 * i - 1) / fac(2 * i - 1);
            }
            return sin;
        }
        double cos(double n, int degree)
        {
            double cos = 0;
            for (int i = 1; i <= degree; i++)
            {
                cos += Math.Pow(-1, i - 1) * Math.Pow(n, 2 * i - 2) / fac(2 * i - 2);
            }

            return cos;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            GraphicsState gs;
            g.ScaleTransform(0.5f, 0.5f);

            double x1 = 40;
            double y1 = 100;
            double x2 = 600;
            double y2 = 800;

            double x = Math.Abs(x1 - x2);
            double y = Math.Abs(y1 - y2);

            double sum = x + y;
            double dis = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));

            double s = 1;
            double angle = arctang((y2 - y1) / (x1 - x2), 10);

            List<double> points = new List<double>();
            for (int i = 2; i <= 12; i++)
            {
                x1 = 40;
                y1 = 100;
                x = Math.Abs(x1 - x2);
                y = Math.Abs(y1 - y2);
                sum = x + y;
                dis = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
                angle = arctang((y2 - y1) / (x1 - x2), i);

                while (dis <= sum)
                {
                    x1 = x1 + s * cos(angle, i);
                    y1 = y1 - s * sin(angle, i);

                    x = Math.Abs(x1 - x2);
                    y = Math.Abs(y1 - y2);

                    dis = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));

                    if (dis < sum)
                        sum = dis;
                }
                points.Add(sum);
            }
            chart1.Legends.Clear();
            chart1.Series[0].ChartType = SeriesChartType.Line;
            chart1.Series.Add(".");
            chart1.Series[1].ChartType = SeriesChartType.Point;
            for (int i = 0; i < points.Count; i++)
            {
                chart1.Series[0].Points.AddXY((int)points[i], i + 2);
                chart1.Series[1].Points.AddXY((int)points[i], i + 2);
            }
        }
    }
    
}
