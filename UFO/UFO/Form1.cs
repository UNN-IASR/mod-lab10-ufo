using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Schema;

namespace UFO
{
    public partial class Form1 : Form
    {
        int accuracy = 1;
        double step = 10;
        int around = 0;
        PointD ufo;
        PointD target;
        PointD start;
        List<PointF> trail;
        double angle;
        static float scale = 0.3f;
        float k = 1 / scale;
        int dirx;
        int diry;
        double minDist;
        List<float> chart;

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

        public double Arctg(double x, int n)
        {
            double res = 0;
            int isArcctg = 1;
            if (x < -1 || x > 1)
            {
                x = 1 / x;
                res = -Math.PI / 2;
                isArcctg = -1;
            }
            for (int i = 1; i <= n; i++)
            {
                res += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 1) / (2 * i - 1);
            }
            return res * isArcctg;
        }

        public Form1()
        {
            InitializeComponent();
            ufo = new PointD(20, 20);
            target = new PointD(this.pictureBox1.Width - 20, this.pictureBox1.Height - 20);
            start = new PointD(ufo.X, ufo.Y);
            trail = new List<PointF>();
            setDir();
            minDist = Dist();
            angle = Arctg((double)Math.Abs(target.Y - ufo.Y) / Math.Abs(target.X - ufo.X), accuracy);
            chart = new List<float>();
            timer1.Interval = 50;
            timer1.Start();
        }

        public double Dist() { return Math.Sqrt(Math.Pow(ufo.X - target.X, 2) + Math.Pow(ufo.Y - target.Y, 2)); }

        public void setDir()
        {
            if (ufo.X < target.X) dirx = 1;
            else dirx = -1;
            if (ufo.Y < target.Y) diry = 1;
            else diry = -1;
        }


        public void MakeStep()
        {
            ufo.X = ufo.X + step * Cos(angle, accuracy) * dirx;
            ufo.Y = ufo.Y + step * Sin(angle, accuracy) * diry;

            if (CheckMiss())
            {
                around = Convert.ToInt32(2 * minDist);

                chart.Add((float)minDist);
                this.pictureBox2.Refresh();

                ufo.X = start.X;
                ufo.Y = start.Y;
                minDist = Dist();
                accuracy++;
                angle = Arctg((double)Math.Abs(target.Y - ufo.Y) / Math.Abs(target.X - ufo.X), accuracy);
                trail.Clear();
            }
        }

        public bool CheckMiss()
        {
            bool buf = Dist() > minDist;
            minDist = Dist();
            return buf;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            MakeStep();
            this.pictureBox1.Refresh();
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            if (target.X > this.pictureBox1.Width)
            {
                target.X = this.pictureBox1.Width - 20;
                start = new PointD(ufo.X, ufo.Y);
                trail.Clear();
                minDist = Dist();
                angle = Arctg((double)Math.Abs(target.Y - ufo.Y) / Math.Abs(target.X - ufo.X), accuracy);
                setDir();
            }
            if (target.Y > this.pictureBox1.Height)
            {
                target.Y = this.pictureBox1.Height - 20;
                start = new PointD(ufo.X, ufo.Y);
                trail.Clear();
                minDist = Dist();
                angle = Arctg((double)Math.Abs(target.Y - ufo.Y) / Math.Abs(target.X - ufo.X), accuracy);
                setDir();
            }
            if (ufo.X > this.pictureBox1.Width)
            {
                ufo.X = 20;
                start = new PointD(ufo.X, ufo.Y);
                trail.Clear();
                minDist = Dist();
                angle = Arctg((double)Math.Abs(target.Y - ufo.Y) / Math.Abs(target.X - ufo.X), accuracy);
                setDir();
            }
            if (ufo.Y > this.pictureBox1.Height)
            {
                ufo.Y = 20;
                start = new PointD(ufo.X, ufo.Y);
                trail.Clear();
                minDist = Dist();
                angle = Arctg((double)Math.Abs(target.Y - ufo.Y) / Math.Abs(target.X - ufo.X), accuracy);
                setDir();
            }

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.ScaleTransform(scale, scale);

            trail.Add(new PointF(k * ufo.IntX, k * ufo.IntY));
            if (trail.Count > 1) g.DrawLines(new Pen(new SolidBrush(Color.DarkGreen), 2), trail.ToArray());

            g.FillEllipse(new SolidBrush(Color.Green),
                k * (ufo.IntX - 8), k * (ufo.IntY - 3), k * 16, k * 6);

            g.FillEllipse(new SolidBrush(Color.Red),
                k * (target.IntX - 5), k * (target.IntY - 5), k * 10, k * 10);
            Pen dashPen = new Pen(new SolidBrush(Color.Red), 2);
            dashPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            g.DrawEllipse(dashPen,
                k * (target.IntX - around / 2), k * (target.IntY - around / 2), k * around, k * around);

            g.DrawLine(new Pen(new SolidBrush(Color.IndianRed), 2), k * start.IntX, k * start.IntY, k * target.IntX, k * target.IntY);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                trail.Clear();
                start = new PointD(e.Location.X, e.Location.Y);
                ufo = new PointD(e.Location.X, e.Location.Y);
                start = new PointD(ufo.X, ufo.Y);
                minDist = Dist();
                angle = Arctg((double)Math.Abs(target.Y - ufo.Y) / Math.Abs(target.X - ufo.X), accuracy);
                setDir();
            }
            else if (e.Button == MouseButtons.Right)
            {
                target = new PointD(e.Location.X, e.Location.Y);
                start = new PointD(ufo.X, ufo.Y);
                trail.Clear();
                minDist = Dist();
                angle = Arctg((float)Math.Abs(target.Y - ufo.Y) / Math.Abs(target.X - ufo.X), accuracy);
                setDir();
            }
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int h = pictureBox2.Height;
            int w = pictureBox2.Width;
            Pen axes = new Pen(new SolidBrush(Color.Black), 3);
            axes.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            g.DrawLine(axes, 10, h - 5, 10, 10);
            g.DrawLine(axes, 5, h - 10, w - 10, h - 10);

            for (int i = 1; i < accuracy; i++)
            {
                g.DrawLine(new Pen(new SolidBrush(Color.Black), 2),
                    (w - 30) * (i) / 15 + 15, h - (h - 30) * chart[i - 1] / Max(chart) + 15,
                    (w - 30) * (i + 1) / 15 + 15, h - (h - 30) * chart[i] / Max(chart) + 15);
            }
        }

        public float Max(List<float> f)
        {
            float max = f[0];
            foreach(float m in f) { if (m > max) max = m; }
            return max;
        }
    }
}
