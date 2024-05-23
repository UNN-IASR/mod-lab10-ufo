using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UFO
{
    public partial class Form1 : Form
    {
        int accuracy = 3;
        double step = 5;
        int around = 15;
        PointD ufo;
        PointD target;
        List<PointF> trail;
        double angle;
        static float scale = 0.5f;
        float k = 1 / scale;

        public struct PointD
        {
            public double X;
            public double Y;

            public PointD(int x, int y)
            {
                X = x;
                Y = y;
            }

            public PointD(double x, double y)
            {
                X = x;
                Y = y;
            }

            public int IntX
            {
                get
                {
                    return Convert.ToInt32(X);
                }
            }

            public int IntY
            {
                get
                {
                    return Convert.ToInt32(Y);
                }
            }
        }
        public int Factorial(int x)
        {
            if (x <= 1)
                return 1;
            return x * Factorial(x - 1);
        }
        public double Cos(double x, int n)
        {
            double res = 0;
            for (int i = 1; i <= n; i++)
            {
                res += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 2) / Factorial(2 * i - 2);
            }
            return res;
        }

        public double Sin(double x, int n)
        {
            double res = 0;
            for (int i = 1; i <= n; i++)
            {
                res += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 1) / Factorial(2 * i - 1);
            }
            return res;
        }
        public Form1()
        {
            InitializeComponent();
            ufo = new PointD(20, 20);
            target = new PointD(this.ClientRectangle.Right - 20, this.ClientRectangle.Bottom - 20);
            trail = new List<PointF>();
            angle = Math.Atan((double)Math.Abs(target.Y - ufo.Y) / Math.Abs(target.X - ufo.X));
            timer1.Start();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                trail.Clear();
                ufo = new PointD(e.X, e.Y);
                angle = Math.Atan((double)Math.Abs(target.Y - ufo.Y) / Math.Abs(target.X - ufo.X));
            }
            else if (e.Button == MouseButtons.Right)
            {
                target = new PointD(e.X, e.Y);
                angle = Math.Atan((double)Math.Abs(target.Y - ufo.Y) / Math.Abs(target.X - ufo.X));
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.ScaleTransform(scale, scale);

            trail.Add(new PointF(k * (ufo.IntX - 8), k * (ufo.IntY - 3)));
            if (trail.Count > 1) g.DrawCurve(new Pen(new SolidBrush(Color.DarkGreen), 2), trail.ToArray());

            g.FillEllipse(new SolidBrush(Color.Green),
                k * (ufo.IntX - 8), k * (ufo.IntY - 3), k * 16, k * 6);

            g.FillEllipse(new SolidBrush(Color.Red),
                k * (target.IntX - 5), k * (target.IntY - 5), k * 10, k * 10);
            Pen dashPen = new Pen(new SolidBrush(Color.Red), 2);
            dashPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            g.DrawEllipse(dashPen, 
                k * (target.IntX - around / 2), k * (target.IntY - around / 2), k * around, k * around);

            
        }

        public void MakeStep()
        {
            ufo.X = ufo.X + step * Cos(angle, accuracy) * (target.X < ufo.X ? -1 : 1);
            ufo.Y = ufo.Y + step * Sin(angle, accuracy) * (target.Y < ufo.Y ? -1 : 1);

            if (CheckAround())
            {

            }
        }

        public bool CheckAround()
        {
            return true;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            MakeStep();
            this.Invalidate();
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            if (target.X > this.ClientRectangle.Right)
            {
                target.X = this.ClientRectangle.Right - 20;
                angle = Math.Atan((double)Math.Abs(target.Y - ufo.Y) / Math.Abs(target.X - ufo.X));
            }
            if (target.Y > this.ClientRectangle.Bottom)
            {
                target.Y = this.ClientRectangle.Bottom - 20;
                angle = Math.Atan((double)Math.Abs(target.Y - ufo.Y) / Math.Abs(target.X - ufo.X));
            }
            if (ufo.X > this.ClientRectangle.Right)
            {
                ufo.X = 20;
                trail.Clear();
                angle = Math.Atan((double)Math.Abs(target.Y - ufo.Y) / Math.Abs(target.X - ufo.X));
            }
            if (ufo.Y > this.ClientRectangle.Bottom)
            {
                ufo.Y = 20;
                trail.Clear();
                angle = Math.Atan((double)Math.Abs(target.Y - ufo.Y) / Math.Abs(target.X - ufo.X));
            }
            
        }
    }
}
