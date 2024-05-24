using System.Drawing.Drawing2D;
using System;
using System.Drawing;
using System.Windows.Forms;
using ScottPlot;
using System.Security;

namespace ufo
{
    public partial class Form1 : Form
    {
        private const int CanvasWidth = 800;
        private const int CanvasHeight = 600;
        private const int PointRadius = 5;
        private const int TargetRadius = 20;

        private PointF startPoint = new PointF(50, 50);
        private PointF endPoint = new PointF(700, 500);
        private PointF currentPoint;
        private int seriesTerms = 1;

        private Graphics g;
        private Pen pen = new Pen(System.Drawing.Color.Black);
        private SolidBrush brush = new SolidBrush(System.Drawing.Color.Blue);

        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        private List<double> distances = new List<double>();

        public Form1()
        {
            InitializeComponent();
            InitializeGraphics();
        }

        private void InitializeGraphics()
        {
            Bitmap bmp = new Bitmap(CanvasWidth, CanvasHeight);
            g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(System.Drawing.Color.White);
            pictureBox1.Image = bmp;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MoveToPoint(startPoint);
            DrawTarget(endPoint);
            MoveObject();
        }

        private void MoveToPoint(PointF point)
        {
            currentPoint = point;
            g.FillEllipse(brush, currentPoint.X - PointRadius, currentPoint.Y - PointRadius, 2 * PointRadius, 2 * PointRadius);
            pictureBox1.Refresh();
        }

        private void DrawTarget(PointF target)
        {
            g.DrawEllipse(pen, target.X - TargetRadius, target.Y - TargetRadius, 2 * TargetRadius, 2 * TargetRadius);
            pictureBox1.Refresh();
        }

        private void MoveObject()
        {
            timer.Interval = 1;
            timer.Tick += (s, e) =>
            {
                if (seriesTerms == 11)
                {
                    timer.Stop();
                    MessageBox.Show("Calculations have been made!");
                    CreateGraph();
                    return;
                }

                float dx = endPoint.X - currentPoint.X;
                float dy = endPoint.Y - currentPoint.Y;

                if (currentPoint.X >= endPoint.X && currentPoint.Y >= endPoint.Y)
                {
                    seriesTerms++;
                    float xR = Math.Abs(currentPoint.X - endPoint.X);
                    float yR = Math.Abs(currentPoint.Y - endPoint.Y);
                    float dist = (float)Math.Sqrt(Math.Pow(xR, 2) + Math.Pow(yR, 2));
                    currentPoint = startPoint;
                    distances.Add(dist);
                }

                dx = endPoint.X - currentPoint.X;
                dy = endPoint.Y - currentPoint.Y;

                double angle = Math.Atan2(dy, dx);
                double distance = Math.Sqrt(dx * dx + dy * dy);
                double moveDistance = Math.Min(5, distance);

                double cosX = Cos(angle, seriesTerms);
                double sinX = Sin(angle, seriesTerms);
                double newX = currentPoint.X + moveDistance * cosX;
                double newY = currentPoint.Y + moveDistance * sinX;

                MoveToPoint(new PointF((float)newX, (float)newY));
            };

            timer.Start();
        }

        private double Cos(double x, int n)
        {
            double result = 0;
            for (int i = 0; i < n; i++)
            {
                result += Math.Pow(-1, i) * Math.Pow(x, 2 * i) / Factorial(2 * i);
            }
            return result;
        }

        private double Sin(double x, int n)
        {
            double result = 0;
            for (int i = 0; i < n; i++)
            {
                result += Math.Pow(-1, i) * Math.Pow(x, 2 * i + 1) / Factorial(2 * i + 1);
            }
            return result;
        }

        private long Factorial(int n)
        {
            if (n <= 1)
                return 1;
            return n * Factorial(n - 1);
        }

        private void CreateGraph()
        {
            Plot plt = new Plot();
            plt.XLabel("n");
            plt.YLabel("distance");
            int[] mass = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var scatter = plt.Add.Scatter(mass, distances.ToArray());
            formsPlot1.Plot.Add.Scatter(mass, distances.ToArray());
            formsPlot1.Refresh();
            plt.SavePng("dia.png", 1920, 1080);
        }
    }
}