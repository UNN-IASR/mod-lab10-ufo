using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using static System.Math;
using System.Drawing.Drawing2D;

namespace Graph
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Paint += new PaintEventHandler(Create);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }






        void Create(object sender, PaintEventArgs e)
        {
            double x1 = 0;
            double y1 = 0;
            double x2 = 100;
            double y2 = 4;
            double step = 2;
            double sx = 200;
            double sy = 10;
            int level = 2;
            Graphics d = e.Graphics;
            Pen pen = new Pen(Color.Green, 1);
            d.DrawEllipse(new Pen(Color.Black, 2), (int)x1, (int)y1, 2, 2);
            d.DrawEllipse(new Pen(Color.Black, 2), (int)x2, (int)y2, 2, 2);
            GraphicsState gs;
            gs = d.Save();
            double rr = Abs(x1 - x2) + Abs(y1 - y2);
            double yg = arctan((y2 - y1) / (x1 - x2), level);
            while (true)
            {
                y1 -= step * sin(yg, level);
                x1 += step * cos(yg, level);
                d.DrawEllipse(pen, (int)x1, (int)y1, 1, 1);
                if (Abs(x1 - x2) + Abs(y1 - y2) > rr)
                {
                    d.DrawString("Точность: " + rr.ToString(), new Font("Arial", 14), new SolidBrush(Color.Black), 300, 10);
                    break;
                }
                else
                {
                    rr = Abs(x1 - x2) + Abs(y1 - y2);
                }
            }
            d.Restore(gs);
            Thread.Sleep(2000);
            d.Clear(Color.White);
            d.DrawLine(new Pen(Color.Red, 2), 100, 400, 100, 0);
            d.DrawLine(new Pen(Color.Red, 2), 100, 400, 600, 400);
            for (int i = 0; i < 5; i++)
            {
                d.DrawLine(new Pen(Color.Black, 2), 90, 400 - (i + 1) * 100, 110, 400 - (i + 1) * 100);
                d.DrawLine(new Pen(Color.Black, 2), 100 + (i + 1) * 100, 390, 100 + (i + 1) * 100, 410);
            }
            d.DrawEllipse(new Pen(Color.Black, 2), 200, 10, 2, 2);
            for (int j = 1; j < 6; j++)
            {
                level = j;
                x1 = 30;
                y1 = 50;
                rr = Abs(x1 - x2) + Abs(y1 - y2);
                yg = arctan((y2 - y1) / (x1 - x2), level);
                while (true)
                {
                    y1 -= step * sin(yg, level);
                    x1 += step * cos(yg, level);
                    if (Abs(x1 - x2) + Abs(y1 - y2) > rr)
                    {
                        if (j != 1)
                        {
                            d.DrawLine(pen, (float)sx, (float)sy, 100 + 100 * j, 400 - (float)rr * 100);
                            sx = 100 + 100 * j;
                            sy = 400 - rr * 100;
                            d.DrawEllipse(new Pen(Color.Black, 2), 100 + 100 * j, 400 - (float)rr * 100, 2, 2);
                        }
                        break;
                    }
                    else
                    {
                        rr = Abs(x1 - x2) + Abs(y1 - y2);
                    }
                }
            }
            gs = d.Save();
            d.Restore(gs);
        }
        static int F(int x)
        {
            if (x <= 0) return 1;
            return x * F(x - 1);
        }
        double cos(double x, int level)
        {
            double res = 0;
            for (int i = 1; i < level + 1; i++)
            {
                res += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 2) / F(2 * i - 2);
            }
            return res;
        }
        double sin(double x, int level)
        {
            double res = 0;
            for (int i = 1; i < level + 1; i++)
            {
                res += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 1) / F(2 * i - 1);
            }
            return res;
        }
        double arctan(double x, int level)
        {
            double ans = 0;
            if (-1 <= x && x <= 1)
            {
                for (int i = 1; i < level + 1; i++)
                {
                    ans += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 1) / (2 * i - 1);
                }
            }
            else
            {
                if (x >= 1)
                {
                    ans += PI / 2;
                    for (int i = 0; i < level; i++)
                    {
                        ans -= Pow(-1, i) / ((2 * i + 1) * Pow(x, 2 * i + 1));
                    }
                }
                else
                {
                    ans -= PI / 2;
                    for (int i = 0; i < level; i++)
                    {
                        ans -= Pow(-1, i) / ((2 * i + 1) * Pow(x, 2 * i + 1));
                    }
                }
            }
            return ans;
        }
    }
}
