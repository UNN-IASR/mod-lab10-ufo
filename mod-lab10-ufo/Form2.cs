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

namespace mod_lab10_ufo
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public int FactorFunc(int a)
        {
            if (a <= 0)
                return 1;
            else
                return a * FactorFunc(a - 1);
        }

        public double SinFunc(double x, int n)
        {

            double sin = 0;
            for (int i = 0; i < n; i++)
            {
                sin += Math.Pow(-1, i) * (Math.Pow(x * Math.PI / 180, 2 * i + 1) / FactorFunc(2 * i + 1));
            }
            return sin;
        }


        public double CosFunc(double x, int n)
        {

            double cos = 0;
            for (int i = 0; i < n; i++)
            {
                cos += Math.Pow(-1, i) * Math.Pow(x * Math.PI / 180, 2 * i) / (FactorFunc(2 * i));
            }
            return cos;
        }

        public double AtanFunc(double x, int n)
        {
            double atan = 0;
            for (int i = 1; i <= n; i++)
            {
                atan += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 1) / (2 * i - 1);
            }
            return atan;
        }

        public Form2(Point firstPoint, Point secondPoint)
        {
            InitializeComponent();

            Graphics g = CreateGraphics();
            g.ScaleTransform(0.5f, 0.5f);

            chart1.Series.Add(new Series());
            chart1.ChartAreas[0].AxisX.TitleFont = new Font("Arial", 9);
            chart1.ChartAreas[0].AxisY.TitleFont = new Font("Arial", 9);

            chart1.ChartAreas[0].AxisY.Title = "Допустимая точность";
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 200;
            chart1.ChartAreas[0].AxisY.MajorGrid.Interval = 10;

            chart1.ChartAreas[0].AxisX.Title = "Количество членов";
            chart1.ChartAreas[0].AxisX.Minimum = 2;
            chart1.ChartAreas[0].AxisX.Maximum = 10;
            chart1.ChartAreas[0].AxisX.MajorGrid.Interval = 1;


            chart1.Series[0].Color = Color.Blue;
            chart1.Series[1].Color = Color.Red;
            chart1.Series[0].ChartType = SeriesChartType.Line;
            chart1.Series[1].ChartType = SeriesChartType.Point;

            List<double> accuracyList = new List<double>();

            for (int i = 2; i <= 10; i++)
            {
                double angle = AtanFunc(Math.Abs(secondPoint.Y - firstPoint.Y) / (double)Math.Abs(secondPoint.X - firstPoint.X), i) * 180 / Math.PI;
                double dist = Math.Sqrt(Math.Pow(secondPoint.Y - firstPoint.Y, 2) + Math.Pow(secondPoint.X - firstPoint.X, 2));
                double sin = SinFunc(angle, i);
                double cos = CosFunc(angle, i);

                double temp = Math.Abs(firstPoint.X - secondPoint.X) + Math.Abs(firstPoint.Y-secondPoint.Y);
                double x = firstPoint.X;
                double y = firstPoint.Y;
                while (dist <= temp)
                {
                    x += (firstPoint.X < secondPoint.X) ? 1 * cos : -1 * cos;
                    y += (firstPoint.Y < secondPoint.Y) ? 1 * sin : -1 * sin;

                    dist = Math.Sqrt(Math.Pow(secondPoint.Y - y, 2) + Math.Pow(secondPoint.X - x, 2));

                    if (dist < temp)
                    {
                        temp = dist;
                    }
                }
                accuracyList.Add(temp);
            }
            for (int i = 0; i < accuracyList.Count; i++)
            {
                chart1.Series[0].Points.AddXY(i + 2, Math.Round(accuracyList[i], 1));
                chart1.Series[1].Points.AddXY(i + 2, Math.Round(accuracyList[i], 1));
            }
        }
    }
}
