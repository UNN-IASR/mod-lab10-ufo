namespace dots10
{
    public partial class Form1 : Form
    {
        int x1, y1, x2, y2;
        double x3, y3;
        (double, double)[] points;
        double[] rs;
        public Form1()
        {
            InitializeComponent();
            int n = 10;
            points = new (double, double)[n];
            rs = new double[n];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Bitmap ufo = new Bitmap(ClientSize.Width, ClientSize.Height);
            Graphics g = Graphics.FromImage(ufo);
            g.ScaleTransform(0.2f, 0.2f);
            (x1, y1) = (111, 111);
            (x2, y2) = (4581, 2591);
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = (x1, y1);
                rs[i] = int.MaxValue;
            }
            g.DrawEllipse(new Pen(Brushes.Black), x1 - 40, y1 - 40, 80, 80);
            g.DrawEllipse(new Pen(Brushes.Black), x2 - 40, y2 - 40, 80, 80);
            BackgroundImage = ufo;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.ScaleTransform(0.2f, 0.2f);
            int r = 10;
            double a = Math.Atan((double)(y2 - y1) / (x2 - x1));
            double[] rcopy = (double[])rs.Clone();
            for (int i = 0; i < points.Length; i++)
            {
                (double px, double py) = points[i];
                px += r * Cos(a, i + 1);
                py += r * Sin(a, i + 1);
                g.DrawEllipse(new Pen(Brushes.Gold), (float)px - 25, (float)py - 25, 50, 50);
                points[i] = (px, py);
                rs[i] = Math.Min(rs[i], Math.Sqrt(Math.Pow(x2 - px, 2) + Math.Pow(y2 - py, 2)));
            }
            if (rs.SequenceEqual(rcopy))
            {
                timer1.Stop();
                MessageBox.Show("DONE");
                ScottPlot.Plot dia = new ScottPlot.Plot();
                int[] xs = new int[points.Length];
                for (int i = 0; i < points.Length; i++)
                {
                    xs[i] = i + 1;
                }
                dia.Add.Scatter(xs, rs);
                dia.SavePng("dia.png", 1090, 654);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        double Sin(double x, int k)
        {
            double r = 0;
            for (int i = 1; i <= k; i++)
            {
                r += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 1) / Factorial(2 * i - 1);
            }
            return r;
        }

        double Cos(double x, int k)
        {
            double r = 0;
            for (int i = 1; i <= k; i++)
            {
                r += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 2) / Factorial(2 * i - 2);
            }
            return r;
        }

        long Factorial(int x)
        {
            long r = 1;
            for (int i = 1; i <= x; i++)
            {
                r *= i;
            }
            return r;
        }
    }
}
