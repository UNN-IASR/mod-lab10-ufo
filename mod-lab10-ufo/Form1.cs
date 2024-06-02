using mod_lab10_ufo;
using ScottPlot;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StraightLineMotionApp
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource _cts;
        private Pen _defaultPen = new Pen(Brushes.Black, 1);
        private Pen _motionPen = new Pen(Brushes.Blue, 1);

        public Form1()
        {
            InitializeComponent();
            _cts = new CancellationTokenSource();
        }

        private async void startButton_Click(object sender, EventArgs e)
        {
            var (startPoint, endPoint) = GetPointsFromInput();

            var graphics = panel1.CreateGraphics();
            InitializeGraphics(graphics, startPoint, endPoint);

            var finalDifference = await RunSimulation(
                start: startPoint,
                end: endPoint,
                stepSize: 10,
                threshold: 0.1,
                seriesTerms: 12,
                graphics: graphics,
                pen: _motionPen,
                cancellationToken: _cts.Token);

            MessageBox.Show(
                $"Simulation completed\nDifference: {finalDifference}",
                "Information",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            _cts.Cancel();
            _cts = new CancellationTokenSource();
        }

        private async Task<double> RunSimulation(
            PointF start,
            PointF end,
            double stepSize,
            double threshold,
            int seriesTerms,
            Graphics graphics,
            Pen pen,
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            double angle = CustomMath.Atan(Math.Abs(end.Y - start.Y) / Math.Abs(end.X - start.X), seriesTerms);

            double currentX = start.X;
            double currentY = start.Y;

            double initialDistance = Math.Sqrt(Math.Pow(end.X - currentX, 2) + Math.Pow(end.Y - currentY, 2));
            double minimalDistance = initialDistance;

            while (initialDistance > threshold)
            {
                cancellationToken.ThrowIfCancellationRequested();

                double previousX = currentX;
                double previousY = currentY;
                currentX += stepSize * CustomMath.Cos(angle, seriesTerms);
                currentY += stepSize * CustomMath.Sin(angle, seriesTerms);

                graphics.DrawLine(pen, (float)previousX, (float)previousY, (float)currentX, (float)currentY);

                initialDistance = Math.Sqrt(Math.Pow(end.X - currentX, 2) + Math.Pow(end.Y - currentY, 2));
                if (initialDistance > minimalDistance)
                {
                    break;
                }
                minimalDistance = Math.Min(initialDistance, minimalDistance);
                await Task.Delay(1, cancellationToken);
            }

            return minimalDistance;
        }

        private async void createPlotButton_Click(object sender, EventArgs e)
        {
            await GeneratePlot();
            MessageBox.Show(
                "Plot saved",
                "Information",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private async Task GeneratePlot()
        {
            var plot = new Plot();
            plot.XLabel("Hit Radius");
            plot.YLabel("Number of Series Terms");
            plot.ShowLegend();

            var seriesCounts = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };

            var (startPoint, endPoint) = GetPointsFromInput();

            var dataPoints = await CollectDataPoints(seriesCounts, startPoint, endPoint);
            var markers = plot.Add.Markers(dataPoints.Values.ToArray(), dataPoints.Keys.ToArray());
            markers.Color = new ScottPlot.Color(0, 0, 0);

            plot.SavePng("plot.png", 1920, 1080);
        }

        private async Task<Dictionary<int, double>> CollectDataPoints(
            IEnumerable<int> seriesCounts,
            PointF startPoint,
            PointF endPoint)
        {
            var graphics = panel1.CreateGraphics();
            InitializeGraphics(graphics, startPoint, endPoint);

            var results = new Dictionary<int, double>();
            foreach (var count in seriesCounts)
            {
                var difference = await RunSimulation(
                    start: startPoint,
                    end: endPoint,
                    stepSize: 10,
                    threshold: 1,
                    seriesTerms: count,
                    graphics: graphics,
                    pen: new Pen(GetRandomColor(), 1),
                    cancellationToken: _cts.Token);
                results[count] = difference;
            }
            return results;
        }

        private void InitializeGraphics(Graphics graphics, PointF start, PointF end)
        {
            graphics.TranslateTransform(panel1.Width / 2, panel1.Height / 2);
            graphics.ScaleTransform(0.2f, 0.2f);

            graphics.DrawEllipse(_defaultPen, start.X - 10, start.Y - 10, 20, 20);
            graphics.DrawEllipse(_defaultPen, end.X - 10, end.Y - 10, 20, 20);
        }

        private (PointF start, PointF end) GetPointsFromInput()
        {
            int startX = 50, startY = 0;
            int endX = 100, endY = 1000;

            if (!int.TryParse(startXTb.Text, out startX)
                || !int.TryParse(endXTb.Text, out endX)
                || !int.TryParse(startYTb.Text, out startY)
                || !int.TryParse(endYTb.Text, out endY))
            {
                throw new ArgumentException("Invalid input values");
            }

            return (new PointF(startX, startY), new PointF(endX, endY));
        }

        private static Random _random = new Random();
        private static System.Drawing.Color GetRandomColor()
        {
            int red = 100 + _random.Next(0, 155);
            int green = 100 + _random.Next(0, 155);
            int blue = 100 + _random.Next(0, 155);

            return System.Drawing.Color.FromArgb(red, green, blue);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
