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
        double atn(double a, int deg)
        {
            double atn = 0;
            if (a >= -1 && a <= 1)
            {
                for (int i = 1; i <= deg; i++)
                {
                    atn += Math.Pow(-1, i - 1) * Math.Pow(a, 2 * i - 1) / (2 * i - 1);
                }
            }
            else
            {
                if (a >= 1)
                {
                    atn += Math.PI / 2;
                }

                else
                {
                    atn -= Math.PI / 2;
                }

                for (int i = 0; i < deg; i++)
                {
                    atn -= Math.Pow(-1, i) / ((2 * i + 1) * Math.Pow(a, 2 * i + 1));
                }
            }
            return atn;
        }
        int factor(int n)
        {
            if (n <= 0)
                return 1;
            return n * factor(n - 1);
        }

        double si(double a, int deg)
        {
            double s = 0;
            for (int i = 1; i <= deg; i++)
            {
                s += Math.Pow(-1, i - 1) * Math.Pow(a, 2 * i - 1) / factor(2 * i - 1);
            }
            return s;
        }
        double co(double a, int deg)
        {
            double c = 0;
            for (int i = 1; i <= deg; i++)
            {
                c += Math.Pow(-1, i - 1) * Math.Pow(a, 2 * i - 2) / factor(2 * i - 2);
            }

            return c;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graf = e.Graphics;
            GraphicsState grafst;
            graf.ScaleTransform(0.5f, 0.5f);

            double xl = 40;
            double yl = 100;
            double xll = 600;
            double yll = 800;

            double X = Math.Abs(xl - xll);
            double Y = Math.Abs(yl - yll);

            double summa = X + Y;
            double way = Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));

            double lev = 1;
            double ang = atn((yll - yl) / (xl - xll), 10);

            List<double> coords = new List<double>();
            for (int i = 2; i <= 12; i++)
            {
                xl = 40;
                yl = 100;
                X = Math.Abs(xl - xll);
                Y = Math.Abs(yl - yll);
                summa = X + Y;
                way = Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
                ang = atn((yll - yl) / (xl - xll), i);

                while (way <= summa)
                {
                    xl = xl + lev * co(ang, i);
                    yl = yl - lev * si(ang, i);

                    X = Math.Abs(xl - xll);
                    Y = Math.Abs(yl - yll);

                    way = Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));

                    if (way < summa)
                        summa = way;
                }
                coords.Add(summa);
            }
            chart1.Legends.Clear();
            chart1.Series[0].ChartType = SeriesChartType.Line;
            chart1.Series.Add(".");
            chart1.Series[1].ChartType = SeriesChartType.Point;
            for (int i = 0; i < coords.Count; i++)
            {
                chart1.Series[0].Points.AddXY((int)coords[i], i + 2);
                chart1.Series[1].Points.AddXY((int)coords[i], i + 2);
            }
        }
    }
    
}
