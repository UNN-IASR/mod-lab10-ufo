// MainForm.cs
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ScottPlot;

namespace UFO
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            this.Width = 920;
            this.Height = 520;

            startX = 20;
            startY = 450;
            startPoint = new PointF(startX, startY);

            endX = 800;
            endY = 30;
            endPoint = new PointF(endX, endY);

            currentPrecision = 2;
            maxPrecisionLevel = 10;
            totalSteps = 15;

            this.Paint += new PaintEventHandler(MainForm_Paint);

            precisionLabel.Left = 20;
            precisionLabel.Top = 20;
            Controls.Add(precisionLabel);

            errorLabel.Left = (int)endX - 15;
            errorLabel.Top = (int)endY + 20;
            Controls.Add(errorLabel);

            timer.Interval = 1200;
            timer.Tick += new EventHandler(Timer_Tick);

            CalculatePath(currentPrecision);
            currentPrecision++;
            timer.Start();
        }

        int currentPrecision;
        int maxPrecisionLevel;
        int totalSteps;
        float startX, startY;
        float endX, endY;
        PointF startPoint, endPoint;

        List<PointF> pathPoints = new List<PointF>();
        List<float> errors = new List<float>();
        List<int> precisionLevels = new List<int>();

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        System.Windows.Forms.Label precisionLabel = new System.Windows.Forms.Label();
        System.Windows.Forms.Label errorLabel = new System.Windows.Forms.Label();

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (currentPrecision <= maxPrecisionLevel)
            {
                CalculatePath(currentPrecision);
                Invalidate();
                currentPrecision++;
            }
            else
            {
                List<double> errorList = new List<double>();
                foreach (var error in errors)
                    errorList.Add((double)error);

                List<double> precisionList = new List<double>();
                foreach (var precision in precisionLevels)
                    precisionList.Add((double)precision);

                ScottPlot.Plot plot = new ScottPlot.Plot();
                plot.Add.Scatter(precisionList.ToArray(), errorList.ToArray());
                plot.Title("Зависимость погрешности от числа членов ряда");
                plot.YLabel("Итоговая погрешность");
                plot.XLabel("Число слагаемых");
                plot.SavePng("dia.png", 600, 400);
                timer.Stop();
                Close();
            }
        }

        private float CalculateDistance(PointF point1, PointF point2)
        {
            return MathF.Sqrt(MathF.Pow(point2.X - point1.X, 2) + MathF.Pow(point2.Y - point1.Y, 2));
        }

        private int CalculateFactorial(int n)
        {
            int result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        private float CalculateSin(int precision, float angle)
        {
            float result = 0;
            for (int n = 1; n <= precision; n++)
            {
                result += MathF.Pow(-1, n - 1) * MathF.Pow(angle, 2 * n - 1) / CalculateFactorial(2 * n - 1);
            }
            return result;
        }

        private float CalculateCos(int precision, float angle)
        {
            float result = 0;
            for (int n = 1; n <= precision; n++)
            {
                result += MathF.Pow(-1, n - 1) * MathF.Pow(angle, 2 * n - 2) / CalculateFactorial(2 * n - 2);
            }
            return result;
        }

        private float CalculateArctg(int precision, float x)
        {
            float result = 0;
            for (int n = 1; n <= precision; n++)
            {
                result += MathF.Pow(-1, n - 1) * MathF.Pow(x, 2 * n - 1) / (2 * n - 1);
            }
            return result;
        }

        private void CalculatePath(int precision)
        {
            float angle = CalculateArctg(precision, MathF.Abs(endY - startY) / MathF.Abs(endX - startX));
            float distance = CalculateDistance(startPoint, endPoint);
            float stepSize = distance / totalSteps;

            pathPoints = new List<PointF>();
            pathPoints.Add(startPoint);
            float currentX = startPoint.X;
            float currentY = startPoint.Y;
            float currentError = distance;
            float newError = 0;

            for (int i = 0; i < totalSteps; i++)
            {
                currentX += stepSize * CalculateCos(precision, angle);
                currentY -= stepSize * CalculateSin(precision, angle);
                PointF newPoint = new PointF(currentX, currentY);
                newError = CalculateDistance(newPoint, endPoint);

                pathPoints.Add(newPoint);
                currentError = newError;
            }

            errors.Add(currentError);
            precisionLevels.Add(precision);
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            int pointDiameter = 2;
            Pen pathPen = new Pen(System.Drawing.Color.Blue, pointDiameter);
            foreach (var point in pathPoints)
            {
                graphics.DrawEllipse(pathPen, point.X - pointDiameter / 2, point.Y - pointDiameter / 2, pointDiameter, pointDiameter);
            }
            Pen endPointPen = new Pen(System.Drawing.Color.Green, 1);
            graphics.DrawEllipse(endPointPen, startX - pointDiameter / 2, startY - pointDiameter / 2, pointDiameter, pointDiameter);
            graphics.DrawEllipse(endPointPen, endX - pointDiameter / 2, endY - pointDiameter / 2, pointDiameter, pointDiameter);
            graphics.DrawLine(endPointPen, startPoint, endPoint);

            float errorRadius = errors[errors.Count - 1];
            graphics.DrawEllipse(endPointPen, endX - errorRadius, endY - errorRadius, errorRadius * 2, errorRadius * 2);
            errorLabel.Text = errorRadius.ToString();
            precisionLabel.Text = $"Точность = {precisionLevels[precisionLevels.Count - 1]}";
        }
    }
}
