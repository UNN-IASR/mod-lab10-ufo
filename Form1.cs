namespace mod_lab10_ufo
{
    public partial class Form1 : Form
    {
        PointF XS, XE;
        PointF X;
        int step = 11;
        int i = 1;
        int k = 15;
        double minr = double.MaxValue;
        ScottPlot.Plot plot = new ScottPlot.Plot();
        Dictionary<double, double> data = new Dictionary<double, double>();
        public Form1()
        {
            InitializeComponent();
            XS = new Point(132, 44);
            XE = new Point(1295, 777);
            X = XS;
            timer1.Enabled = true;
        }

        private void DrawPoint(Graphics g, PointF p, int r)
        {
            g.DrawEllipse(new Pen(Color.Blue, 6), p.X - r, p.Y - r, 2 * r, 2 * r);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.ScaleTransform(0.5f, 0.5f);
            DrawPoint(g, XS, 10);
            DrawPoint(g, XE, 10);
            DrawPoint(g, X, 5);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Text = $"Точность: {i.ToString()}";
            double a = arctan((XE.Y - XS.Y) / (XE.X - XS.X), i);
            X.X += step * (float)cos(a, i);
            X.Y += step * (float)sin(a, i);

            this.Invalidate();

            double r = Math.Sqrt(Math.Pow(XE.X - X.X, 2) + Math.Pow(XE.Y - X.Y, 2));
            if (r < minr) minr = r;
            else
            {
                data.Add(i, minr);
                X = XS;
                minr = double.MaxValue;
                i++;
            }
            if (i == k)
            {
                plot.Add.Scatter(data.Keys.ToArray(), data.Values.ToArray());
                plot.Axes.AutoScale();
                plot.SavePng("dia.png", 1000, 1000);
                timer1.Enabled = false;
            }
        }

        private ulong fact(int x)
        {
            if (x < 2) return 1;
            return (ulong)x * fact(x-1);
        }

        private double cos(double x, int n)
        {
            double cos = 0;
            for (int i = 1; i <= n; i++)
                cos += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 2) / fact(2 * i - 2);
            return cos;
        }

        private double sin(double x, int n)
        {
            double sin = 0;
            for (int i = 1; i <= n; i++)
                sin += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 1) / fact(2 * i - 1);
            return sin;
        }

        private double arctan(double x, int n)
        {
            double arctan = 0;
            for (int i = 1; i <= n; i++)
                arctan += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 1) / (2 * i - 1);
            return arctan;
        }
    }
}
