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

namespace _10.lab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            List<double> accuracies = new List<double>();

            Pen pen = new Pen(Color.Purple, 40);
            Brush brush = new SolidBrush(Color.Red);
            Graphics g = e.Graphics;

            g.ScaleTransform(0.1f, 0.1f);
            for (int numberOfTerms = 2; numberOfTerms <= 10; numberOfTerms++)
            {
                double x1 = 10;
                double y1 = 10;
                double x2 = 2600;
                double y2 = 1800;
                double step = 100;
                double value = step;
                double distance = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
                double angle = -Arctg(numberOfTerms, Math.Abs(y2 - y1) / Math.Abs(x2 - x1));
                double x = x1;
                double y = y1;
                while (distance > value)
                {
                    if(numberOfTerms==10) g.DrawEllipse(pen, (int)x, (int)y, 2, 2);
                    x += step * Cos(numberOfTerms, angle);
                    y -= step * Sin(numberOfTerms, angle);
                    distance = Math.Sqrt(Math.Pow((x - x2), 2) + Math.Pow((y - y2), 2));
                }
                accuracies.Add(distance);
            }
            chart1.Legends.Clear();
            chart1.Series[0].ChartType = SeriesChartType.Line;
            chart1.Series.Add(".");
            chart1.Series[1].ChartType = SeriesChartType.Point;
            chart1.ChartAreas[0].AxisX.Title = "погрешность";
            chart1.ChartAreas[0].AxisY.Title = "количество членов ряда";
            for (int i = 0; i < accuracies.Count; i++) {
                chart1.Series[0].Points.AddXY((int)accuracies[i], i+1 );
                chart1.Series[1].Points.AddXY((int)accuracies[i], i+1 );
            }
        }
        public static long Fact(long n)
        {
            if (n == 0)
                return 1;
            else
                return n * Fact(n - 1);
        }
        public static double Sin(int numberOfTerms, double x) {
            double sin = 0.0;
            for (int n = 1; n <= numberOfTerms; n++) {
                sin +=  Math.Pow(-1, n - 1) * Math.Pow(x, 2 * n - 1) / Fact(2 * n - 1);
            }
            return sin;
        }

        public static double Cos(int numberOfTerms, double x) {
            double cos = 0.0;
            for (int n = 1; n <= numberOfTerms; n++) {
                cos +=  Math.Pow(-1, n - 1) * Math.Pow(x, 2 * n - 2) / Fact(2 * n - 2);
            }
            return cos;
        }

        public static double Arctg(int numberOfTerms, double x)
        {
            double arctg = 0;
            if (-1 <= x && x <= 1) {
                for (int n = 1; n <= numberOfTerms; n++) {
                    arctg += Math.Pow(-1, n - 1) * Math.Pow(x, 2 * n - 1) / (2 * n - 1);
                }
            } 
            else {
                if (x > 1) {
                    arctg = arctg + Math.PI / 2;
                    for (int n = 0; n < numberOfTerms; n++) {
                        arctg -=  Math.Pow(-1, n) / ((2 * n + 1) * Math.Pow(x, 2 * n + 1));
                    }
                }   
                else  {
                    arctg = arctg - Math.PI / 2;
                    for (int n = 0; n < numberOfTerms; n++) {
                        arctg -=  Math.Pow(-1, n) / ((2 * n + 1) * Math.Pow(x, 2 * n + 1));
                    }
                }
            }
            return arctg;
        }
        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
