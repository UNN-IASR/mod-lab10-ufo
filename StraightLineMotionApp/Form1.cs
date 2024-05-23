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
        CancellationTokenSource _cts;
        Pen _pen = new Pen(Brushes.Black, 1);
        Pen _pen1 = new Pen(Brushes.Blue, 1);

        public Form1()
        {
            InitializeComponent();
            _cts = new CancellationTokenSource();
        }

        private async void startButton_Click(object sender, EventArgs e)
        {
            var (start, end) = GetStartEndPoints();

            var graphics = panel1.CreateGraphics();
            PrepareGraphics(graphics, start, end);

            var result = await Simulate(
                start: start,
                end: end,
                step: 10,
                epsilon: 0.1,
                termsCount: 12,
                g: graphics,
                _pen1,
                _cts.Token);

            MessageBox.Show(
                $"Построение завершено\nРазница: {result}", 
                "Информация", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            _cts.Cancel();
            _cts = new CancellationTokenSource();
        }

        private async Task<double> Simulate(
    PointF start,
    PointF end,
    double step,
    double epsilon,
    int termsCount,
    Graphics g,
    Pen pen,
    CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

            var angle = CustomMath.Atan(Math.Abs(end.Y - start.Y) / Math.Abs(end.X - start.X), termsCount);

            var x = (double)start.X;
            var y = (double)start.Y;

            var distance = Math.Sqrt(Math.Pow(end.X - x, 2) + Math.Pow(end.Y - y, 2));
            var minDist = distance;

            while (distance > epsilon)
            {
                token.ThrowIfCancellationRequested();
                var prevX = x;
                var prevY = y;
                x += step * CustomMath.Cos(angle, termsCount);
                y += step * CustomMath.Sin(angle, termsCount);

                g.DrawLine(pen, (float)prevX, (float)prevY, (float)x, (float)y);

                distance = Math.Sqrt(Math.Pow(end.X - x, 2) + Math.Pow(end.Y - y, 2));
                if (distance > minDist)
                {
                    break;
                }
                minDist = Math.Min(distance, minDist);
                await Task.Delay(1, token);
            }

            return minDist;
        }

        private async void createPlotButton_Click(object sender, EventArgs e)
        {
            await CreatePlot();
            MessageBox.Show(
                "График сохранен",
                "Информация",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private async Task CreatePlot()
        {
            var plot = new Plot();
            plot.XLabel("Радиус попадания");
            plot.YLabel("Количество членов ряда");
            plot.ShowLegend();

            var terms = new List<int>()
            {
                6,8,10,12
            };

            var (start, end) = GetStartEndPoints();

            var data = await GetData(terms, start, end);
            var markers = plot.Add.Markers(data.Values.ToArray(), data.Keys.ToArray());
            markers.Color = new ScottPlot.Color(0, 0, 0);

            plot.SavePng("dia.png", 1920, 1080);
        }

        private async Task<Dictionary<int, double>> GetData(
            IEnumerable<int> termsCount,
            PointF start,
            PointF end)
        {
            var graphics = panel1.CreateGraphics();
            PrepareGraphics(graphics, start, end);

            var result = new Dictionary<int, double>();
            foreach (var term in termsCount)
            {
                var diff = await Simulate(
                    start,
                    end,
                    10,
                    1,
                    term,
                    graphics,
                    new Pen(GetRandomColor(), 1),
                    _cts.Token);
                result[term] = diff;
            }
            return result;
        }

        private void PrepareGraphics(Graphics graphics, PointF start, PointF end)
        {
            graphics.TranslateTransform(panel1.Width / 2, panel1.Height / 2);
            graphics.ScaleTransform(0.2f, 0.2f);

            graphics.DrawEllipse(_pen, start.X - 10, start.Y - 10, 20, 20);
            graphics.DrawEllipse(_pen, end.X - 10, end.Y - 10, 20, 20);
        }

        private (PointF start, PointF end) GetStartEndPoints()
        {
            int startX = 50, startY = 0;
            int endX = 100, endY = 1000;

            if (!int.TryParse(startXTb.Text, out startX)
                || !int.TryParse(endXTb.Text, out endX)
                || !int.TryParse(startYTb.Text, out startY)
                || !int.TryParse(endYTb.Text, out endY))
            {
                throw new ArgumentException();
            }

            var start = new PointF(startX, startY);
            var end = new PointF(endX, endY);

            return (start, end);
        }

        private static Random _rnd = new Random();
        private static System.Drawing.Color GetRandomColor()
        {
            int red = 100 + _rnd.Next() % 155;
            int green = 100 + _rnd.Next() % 155;
            int blue = 100 + _rnd.Next() % 155;

            return System.Drawing.Color.FromArgb(red, green, blue);
        }
    }
}
