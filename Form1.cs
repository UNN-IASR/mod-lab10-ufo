using System.Windows.Forms.DataVisualization.Charting;
using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Math;
using System.Drawing.Drawing2D;
using System.Linq;

namespace WinFormsApp36
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static long Factorial(int n)
        {
            long fact = 1;
            for (int i = 1; i <= n; i++)
            {
                fact *= i;
            }
            return fact;
        }

        public static double Sin(double x, int n)
        {
            double sum = 0;
            for (int i = 0; i <= n; i++)
            {
                double term = Math.Pow(-1, i) * Math.Pow(x, 2 * i + 1) / Factorial(2 * i + 1);
                sum += term;
            }
            return sum;
        }

        public static double Cos(double x, int n)
        {
            double sum = 0;
            for (int i = 0; i <= n; i++)
            {
                double term = Math.Pow(-1, i) * Math.Pow(x, 2 * i) / Factorial(2 * i);
                sum += term;
            }
            return sum;
        }

        double Arct(double x, int n)
        {
            double sum = 0;
            if (-1 <= x && x <= 1)
            {
                for (int i = 1; i < n + 1; i++)
                {
                    sum += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 1) / (2 * i - 1);
                }
            }
            else
            {
                if (x >= 1)
                {
                    sum += PI / 2;
                    for (int i = 0; i < n; i++)
                    {
                        sum -= Pow(-1, i) / ((2 * i + 1) * Pow(x, 2 * i + 1));
                    }
                }
                else
                {
                    sum -= PI / 2;
                    for (int i = 0; i < n; i++)
                    {
                        sum -= Pow(-1, i) / ((2 * i + 1) * Pow(x, 2 * i + 1));
                    }
                }
            }
            return -sum;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            List<double> kol_chlenov_ryada = new List<double> { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            List<double> radiusi = new List<double>(14);
            for (int i = (int)kol_chlenov_ryada.Min(); i <= (int)kol_chlenov_ryada.Max(); i++)
            {
                double X1 = 150;
                double Y1 = 200;
                double X2 = 2800;
                double Y2 = 2000;

                double angle = Arct(Abs(Y2 - Y1) / Abs(X2 - X1), i);
                double distance = Sqrt(Pow(X2 - X1, 2) + Pow(Y2 - Y1, 2));

                double step = 80;
                double x = X1;
                double y = Y1;
                while (distance > 80)
                {
                    x += step * Cos(angle, i);
                    y -= step * Sin(angle, i);

                    distance = Sqrt(Pow(x-X2, 2) + Pow(y-Y2, 2));
                    
                }
                radiusi.Add(distance);
            }
            
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();

            chart1.Series.Add("1");
            chart1.Series["1"].ChartType = SeriesChartType.Line;
             chart1.ChartAreas.Add("1");
            chart1.Series["1"].MarkerStyle = MarkerStyle.Circle;
            chart1.Series["1"].MarkerSize = 10;
            chart1.Series["1"].MarkerColor = Color.Black;
            chart1.Series["1"].Points.DataBindXY(kol_chlenov_ryada, radiusi);

            chart1.Series.Add("2");
            chart1.Series["2"].ChartType = SeriesChartType.Point;
            chart1.Series["2"].MarkerStyle = MarkerStyle.Circle;
            chart1.Series["2"].MarkerSize = 5;
            chart1.Series["2"].MarkerColor = Color.Red;
            chart1.Series["2"].Points.DataBindXY(kol_chlenov_ryada, radiusi);
            
            
            chart1.ChartAreas[0].AxisY.MajorGrid.Interval = 5;

            chart1.ChartAreas[0].AxisX.Minimum = kol_chlenov_ryada.Min()-1;
            chart1.ChartAreas[0].AxisX.Maximum = kol_chlenov_ryada.Max()+1;

            chart1.Titles.Add("График зависимости точности расчетов(количество членов ряда) от радиуса зоны попадания вокруг");
            chart1.ChartAreas[0].AxisX.Title = "Количество членов ряда";
            chart1.ChartAreas[0].AxisY.Title = "Радиус зоны попадания";
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            GraphicsState gs;
            g.ScaleTransform(0.3f, 0.3f);
            
            gs = g.Save();
            Pen pen = new Pen(Color.LightBlue, 6);

            g.DrawString("Моделирование движения: ", new Font("Times New Roman", 40), new SolidBrush(Color.Black), 2900, 40);
            g.DrawLine(new Pen(Color.Green, 40), 2800, 0, 2800, 2200);
            

            double X1 = 3000;
            double Y1 = 1100;
            double X2 = 3600;
            double Y2 = 300;
            g.DrawEllipse(pen, (int)X1, (int)Y1, 10, 10);
            g.DrawEllipse(pen, (int)X2, (int)Y2, 10, 10);

            Pen pen0 = new Pen(Color.Blue, 4);


            double angle = Arct(Abs(Y2 - Y1) / Abs(X2 - X1), 5);
            double distance = Math.Sqrt(Math.Pow(X2 - X1, 2) + Math.Pow(Y2 - Y1, 2));
            
            double step = 4;
            double x = X1;
            double y = Y1;

            while (distance > 15)
            {
                x += step * Cos(angle, 5);
                y += step * Sin(angle, 5);

                g.DrawEllipse(pen0, (int)x, (int)y, 10, 10);

                distance = Math.Sqrt(Math.Pow(x-X2, 2) + Math.Pow(y-Y2, 2));
            }

            g.DrawString("Сохранение формы в png : ", new Font("Times New Roman", 40), new SolidBrush(Color.Black), 2900, 1400);
            g.DrawLine(new Pen(Color.Green,30), 2800, 1300, 6000, 1300);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Рисунок .png | *.png";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                int width, height;
                width = this.Width;
                height = this.Height;
                Bitmap png = new Bitmap(width, height);
                this.DrawToBitmap(png, this.ClientRectangle);
                png.Save(sfd.FileName);
            }
        }
    }
}