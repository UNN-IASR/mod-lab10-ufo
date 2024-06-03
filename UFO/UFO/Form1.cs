using System.Drawing;
using System.Net.Http.Headers;
using System.Security.Cryptography.Pkcs;

using ScottPlot;
using ScottPlot.Palettes;

namespace UFO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            timer1.Interval = 50;
        }
        Pen cir_pen = new Pen(System.Drawing.Color.Black, 2);
        Brush brush = new SolidBrush(System.Drawing.Color.Indigo);
        float r = 10;
        float step = 10;
        float x1 = 50, y1 = 0;
        float x2 = 100, y2 = 1000;
        float xt = 0, yt = 0;
        float epsilon = 3;
        int m = 0;
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.ScaleTransform(0.2f, 0.2f);
            float w = 5 * this.ClientSize.Width;
            float h = 5 * this.ClientSize.Height;
            float w2 = w / 2;
            float h2 = h / 2;
            g.TranslateTransform(w2, h2);
            g.FillEllipse(brush, x1 - r, -y1 - r, 2 * r, 2 * r);
            g.FillEllipse(brush, x2 - r, -y2 - r, 2 * r, 2 * r);
            g.FillEllipse(brush, xt - r, -yt - r, 2 * r, 2 * r);
        }
        private void MovePoint(ref float xt, ref float yt, float x2, float y2, int n = 5)
        {
            //label1.Text = $"{Math.Abs(yt - y2) / Math.Abs(xt - x2)}";
            double angle = Atan(Math.Abs(yt - y2) / Math.Abs(xt - x2), n);
            //label1.Text = $"{angle}";
            xt += (float)(step * Cos(angle, n));
            yt += (float)(step * Sin(angle, n));
        }
        private double Atn(double x, int n = 5)
        {
            double result = 0;
            for (int k = 1; k <= n; k++)
                result += Math.Pow(-1, k - 1) * Math.Pow(x, 2 * k - 1) / (2 * k - 1);
            return result;
        }
        private double Atan(double x, int n) //
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
        private double Sin(double x, int n = 5)
        {
            double result = 0;
            for (int k = 0; k < n; k++)
                result += Math.Pow(-1, k) * Math.Pow(x, 2 * k + 1) / factorial(2 * k + 1);
            return result;
        }
        private double Cos(double x, int n = 5)
        {
            double result = 0;
            for (int k = 0; k < n; k++)
                result += Math.Pow(-1, k) * Math.Pow(x, 2 * k) / factorial(2 * k);
            return result;
        }
        private int factorial(int n)
        {
            if (n <= 1) return 1;
            return n * factorial(n - 1);
        }
        private float Distance(float x1, float y1, float x2, float y2)
        {
            float result = (float)Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            return result;
        }
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Distance(xt, yt, x2, y2) >= epsilon)
            {
                MovePoint(ref xt, ref yt, x2, y2, 15);
                m++;
                label2.Text = m.ToString();
            }
            else
            {
                timer1.Stop();
                //label1.Text = $"Пришло";
            }
            Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m = 0;
            x1 = 20;
            y1 = 30;
            x2 = 200;
            y2 = 950;
            xt = x1;
            yt = y1;
            //label1.Text = "Идёт";
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var plot = new Plot();
            plot.XLabel("Окрестность попадания");
            plot.YLabel("Количество членов ряда");
            plot.ShowLegend();
            for (float eps = 0.25f; eps < 15; eps += 0.25f)
            {
                int n = 0;
                bool res = false;
                while ((n < 17) && (!res))
                {
                    n++;
                    res = Simulate(eps, n);
                }
                plot.Add.Marker(eps, n);
            }
            label1.Text = "Граф готов";
            plot.SavePng("../../../../dia.png", 1920, 1080);
        }
        private bool Simulate(float epsilon, int n)
        {
            int i = 0;
            float x1 = 20, y1 = 30;
            float x2 = 200, y2 = 950;
            float xt = x1, yt = y1;
            float dist = Distance(xt, yt, x2, y2);
            float curDist;
            while (true)
            {
                if (dist < epsilon)
                {
                    label2.Text = i.ToString();
                    return true;
                }
                MovePoint(ref xt, ref yt, x2, y2, n);
                curDist = Distance(xt, yt, x2, y2);
                if (curDist > dist)
                {
                    label2.Text = i.ToString();
                    return false;
                }
                else dist = curDist;
                i++;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
