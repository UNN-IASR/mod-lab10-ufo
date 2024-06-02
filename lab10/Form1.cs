using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace labb10
{
    public partial class Form1 : Form
    {
        static double X1 = 10;
        static double Y1 = 10;
        static double X2 = 2500;
        static double Y2 = 1500;
        double angle = -Atan((double)Math.Abs(Y2 - Y1) / (double)Math.Abs(X2 - X1),2);
        double distance = Math.Sqrt(Math.Pow(X2 - X1, 2) + Math.Pow(Y2 - Y1, 2));
        double step = 100;
        double errorRate = 100;
        double currentX = X1;
        double currentY = Y1;
        int number = 10;
        Pen pen = new Pen(Color.Black, 5);
        Brush brush = new SolidBrush(Color.Blue);
        List<double> statErrors = new List<double>();
        public Form1()
        {
            InitializeComponent();
        }
        private double cos(double x, int n)
        {
            double result = 0;
            for (int i = 1; i <= n; i++)
            {
                result += Math.Pow(-1, i - 1) * (double)Math.Pow(x, 2 * i - 2) / factorial(2 * i - 2);
            }
            return result;
        }
        private double sin(double x, int n)
        {
            double result = 0;
            for (int i = 1; i <= n; i++)
            {
                result += Math.Pow(-1, i - 1) * (double)Math.Pow(x, 2 * i - 1) / factorial(2 * i - 1);
            }
            return result;
        }
        public static double Atan(double x, int index)
        {
            double atan = 0;
            for (int i = 0; i <= index; i++)
            {
                atan+= Math.Pow(-1, i) * Math.Pow(x, 2 * i + 1) / (2 * i + 1);
            }

            return atan;
        }
        private int factorial(int n)
        {
            if (n <= 1) return 1;
            return n * factorial(n - 1);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.ScaleTransform(0.5f, 0.5f);
            for (int index = 2; index <= number; index++)
            {
                distance = Math.Sqrt(Math.Pow((X2 - X1), 2) + Math.Pow((Y2 - Y1), 2));
                currentX = X1;
                currentY = Y1;
                angle = -Atan((double)Math.Abs(Y2 - Y1) / (double)Math.Abs(X2 - X1), index);
                while (distance > errorRate)
                {
                    currentX += step * cos(angle, index);
                    currentY -= step * sin(angle, index);
                    distance = Math.Sqrt(Math.Pow((currentX - X2), 2) + Math.Pow((currentY - Y2), 2));
                }
                statErrors.Add(distance);
            }
            chart1.Legends.Clear();
            chart1.Series[0].ChartType = SeriesChartType.Line;
            chart1.Series.Add(".");
            chart1.Series[1].ChartType = SeriesChartType.Point;
            chart1.ChartAreas[0].AxisX.Title = "Отклонение";
            chart1.ChartAreas[0].AxisY.Title = "Количество членов ряда";
            for (int i = 0; i < statErrors.Count; i++)
            {
                chart1.Series[0].Points.AddXY((int)statErrors[i], i + 2);
                chart1.Series[1].Points.AddXY((int)statErrors[i], i + 2);
            }
        }
    }
}
