using System.Collections;

namespace winUfo
{
    public partial class MainForm : Form
    {
        private PointF start;
        private PointF end;
        private PointF[] points;
        int step;
        double angle;
        int n;
        double[] dists;

        public MainForm()
        {
            InitializeComponent();
            step = 5;
            n = 10;
            points = new PointF[n];
            dists = new double[n];
            entryStart.Text = "50 50";
            entryEnd.Text = "700 450";
        }

        private void fieldBox_Paint(object sender, PaintEventArgs e)
        {
            if (!Timer.Enabled) return;

            Graphics g = e.Graphics;

            for (int i = 0; i < n; i++)
            {
                points[i].X += step * (float)Cos(angle, i + 1);
                points[i].Y += step * (float)Sin(angle, i + 1);
                dists[i] = Math.Min(dists[i], points[i].DistTo(end));
                g.DrawPoint(new Pen(Color.Red, 4), points[i], 5);
            }

            if (points.All(p => p.X > fieldBox.Width + 10 || p.Y > fieldBox.Height + 10))
            {
                Timer.Enabled = false;
                runButton.Enabled = true;
                CreatePlot(Enumerable.Range(1, n).Select(x => (double)x).ToArray(), dists);
            }
        }

        private void CreatePlot(double[] dataX, double[] dataY)
        {
            formsPlot.Plot.XLabel("Precision");
            formsPlot.Plot.YLabel("Distance");
            formsPlot.Plot.Add.Scatter(dataX, dataY);
            formsPlot.Plot.Axes.AutoScale();
            formsPlot.Refresh();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            fieldBox.Invalidate();
        }

        private long Factorial(int x)
        {
            return Enumerable.Range(1, x)
                             .Aggregate(1, (acc, x) => acc * x);
        }
        private double Sin(double x, int k)
        {
            return Enumerable.Range(0, k)
                             .Aggregate(0.0, (acc, n) => 
                                acc + Math.Pow(-1, n) * Math.Pow(x, 2 * n + 1) / Factorial(2 * n + 1)
                             );
        }
        private double Cos(double x, int k)
        {
            return Enumerable.Range(0, k)
                             .Aggregate(0.0, (acc, n) => 
                                acc + Math.Pow(-1, n) * Math.Pow(x, 2 * n) / Factorial(2 * n)
                             );
        }
        private double Atan(double x, int k)
        {
            if (Math.Abs(x) > 1) return Math.Sign(x) * Math.PI / 2 - Atan(1 / x, k);
            return Enumerable.Range(1, k)
                             .Aggregate(0.0, (acc, n) => 
                                acc + Math.Pow(-1, n - 1) * Math.Pow(x, 2 * n - 1) / (2 * n - 1)
                             );
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            Bitmap back = new Bitmap(fieldBox.Width, fieldBox.Height);
            Graphics g = Graphics.FromImage(back);
            Pen p = new Pen(Color.Pink, 4);
            int[] _start = entryStart.Text.Split().Select(c => Convert.ToInt32(c)).ToArray();
            int[] _end = entryEnd.Text.Split().Select(c => Convert.ToInt32(c)).ToArray();
            start = new PointF(_start[0], _start[1]);
            end = new PointF(_end[0], _end[1]);
            g.DrawPoint(p, start, 10);
            g.DrawPoint(p, end, 10);
            fieldBox.Image = back;
            for (int i = 0; i < n; i++)
            {
                points[i] = new PointF(start.X, start.Y);
                dists[i] = fieldBox.Width;
            }
            angle = Atan((end.Y - start.Y) / (end.X - start.X), n);
            Timer.Enabled = true;
            runButton.Enabled = false;
        }
    }

    public static class Extensions
    {
        public static void DrawPoint(this Graphics g, Pen pen, PointF point, int r)
        {
            g.DrawEllipse(pen, point.X - r, point.Y - r, 2*r, 2*r);
        }
        public static double DistTo(this PointF point, PointF other)
        {
            return Math.Sqrt(Math.Pow(point.X - other.X, 2) + Math.Pow(point.Y - other.Y, 2));
        }
    }
}
