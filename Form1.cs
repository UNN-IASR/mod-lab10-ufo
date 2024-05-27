using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
//using ScottPlot;
//using ScottPlot.Statistics;
using ScottPlot.WinForms;

using static System.Windows.Forms.AxHost;


using System.Deployment.Application;
using System.Windows.Forms.DataVisualization.Charting;


namespace mod_lab10_ufo
{
    public partial class Form1 : Form
    {
        int x0, y0;//стартовая точка
        float x1, y1;//конечная точка
        Timer timer;
        float x, y;//промежуточные точки
        int value = 10;//требуемая точность
        int step = 5;//шаг
        Graphics gr;
    
        public Form1()
        {
            InitializeComponent();
           // typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
           //| BindingFlags.Instance | BindingFlags.NonPublic, null,
           //panel1, new object[] { true });
            x0 = panel1.ClientSize.Width/2;
            y0 = panel1.ClientSize.Height/2;
            timer = new Timer();
            x = 0; y = 0;
            
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            x1 = 250;
            y1 = -127;


            panel1.Refresh();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            panel1.Refresh();// Запрашиваем перерисовку формы
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.Refresh();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (timer.Enabled)
            {
                timer.Stop(); // Останавливаем таймер
            }
            else
            {
                timer.Start(); // Запускаем таймер
            }
        }

       

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(x0, y0);

            Pen pen = new Pen(System.Drawing.Color.Black, 3);
            e.Graphics.DrawLine(pen, new Point(-x0, 0), new Point(x0, 0));
            e.Graphics.DrawLine(pen, new Point(0, -y0), new Point(0, y0));
            //points.Add(new Point(x0, y0));
            //MoveObject(new Point_1(x0, y0), new Point_1(150, 200),7);
            e.Graphics.FillEllipse(new SolidBrush(System.Drawing.Color.Blue), (float)(x1-2.5) , (float)(y1-2.5) ,  5, 5);
            float y_0= (float)(-2.5);
            float x_0 = (float)(-2.5);
            e.Graphics.FillEllipse(new SolidBrush(System.Drawing.Color.Red), x_0, y_0, 5, 5);//отрисовываем начальную точку
            //e.Graphics.DrawLine(new Pen(Color.Black, 2), 0, 0, x1-5, y1-5);
            Line(0, 0, x1, y1);
            MoveObject(new Point_1(0, 0), new Point_1(x1,y1),7);
            //DrawFunc();
        }
        public class Point_1
        {
            public  double X { get; set; }
            public  double Y { get; set; }

            public  Point_1(double x, double y)
            {
                X = x;
                Y = y;
            }
        }

        private void MoveObject(Point_1 start, Point_1 end, int n)
        {
            gr = panel1.CreateGraphics();
            gr.TranslateTransform(x0, y0);
            double dx = end.X - start.X;
            double dy = end.Y - start.Y;

            double angle = Math.Atan2(Math.Abs(dy), Math.Abs(dx)); // Вычисляем угол между начальной и конечной точками
            //double distance = Math.Sqrt(dx * dx + dy * dy); // Вычисляем расстояние между точками

            // Используем нашу реализацию косинуса для вычисления x-координаты конечной точки
            //double endX = start.X + distance * Class1.Cos(angle, n);
             double distance = Math.Sqrt((end.X - x) * (end.X - x) + (end.Y - y) * (end.Y - y));
            // Используем нашу реализацию синуса для вычисления y-координаты конечной точки
            //double endY = start.Y + distance * Class1.Sin(angle, n);
           if (distance > value)
           {
                x += (float)(step * Class1.Cos((angle),n));
                y -= (float)(step * Class1.Sin((angle),n));
                gr.FillEllipse(new SolidBrush(System.Drawing.Color.Green), x - 2, y - 2, 2*2, 2*2);
                //distance = Math.Sqrt((end.X-x)*(end.X-x) + (end.Y - y) * (end.Y - y));
           }
           else
           {
                gr.FillEllipse(new SolidBrush(System.Drawing.Color.Green), x - 2, y - 2, 2, 2);
                gr.DrawEllipse(new Pen(System.Drawing.Color.Blue, 2), x1 - value , y1 - value , 2*value, 2*value);
                timer.Enabled = false;
                Make_Graph_png();
           }

        }
        private void Make_Graph_png()
        {

            chart1.Series[0].Points.Clear();
            chart1.Series.Add(".");
            chart1.Series[1].ChartType = SeriesChartType.Point;
            chart1.ChartAreas[0].AxisX.Title = "погрешность";
            chart1.ChartAreas[0].AxisY.Title = "количество членов ряда";
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            Dictionary<int, int>  dictionary = new Dictionary<int, int>();

            for (int n = 10; n >= 1; n--)
            {
                for (int val = 1; val < 100; val++)
                {
                    double x = 0, y = 0;  // Инициализация переменных
                    double step = 1; // Предположим, что step определен где-то выше
                    double distance = Math.Sqrt(Math.Pow(x1 - x, 2) + Math.Pow(y1 - y, 2));
                    double dx = x1 - x;
                    double dy = y1 - y;
                 
                    

                    double angle = Math.Atan2(Math.Abs(dy), Math.Abs(dx));
                    int count = 0;
                    while (distance > val && count < 1000)
                    {
                        x += (float)(step * Class1.Cos((angle), n)); // Предполагается, что Class1.Cos и Class1.Sin определены где-то выше
                        y -= (float)(step * Class1.Sin((angle), n));
                        distance = Math.Sqrt(Math.Pow(x1 - x, 2) + Math.Pow(y1 - y, 2));
                        count++;
                    }
                    if (count < 1000)
                    {
                        chart1.Series[0].Points.AddXY(n, val);
                        chart1.Series[1].Points.AddXY(n, val);
                        break;


                    }
                }
            }
            //foreach( var point in Plot_points)
            //{
            //    var scatter = plot.Add.Scatter(point.X, point.Y);
            //    scatter.Color = new ScottPlot.Color();
            //}
            chart1.Visible = true;
            chart1.SaveImage("dia.png", ChartImageFormat.Png);
        }
        private void Line(int x_start, int y_start, int x_end, int y_end)
        {
            double k = (double)(y_end - y_start) / (x_end - x_start);
            double b = y_start - k*x_start;
            for (int x = x_start; x <= x_end; x++)
                DrawPoint(x, (int)Math.Round(k * x + b));
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void Line(float x_start, float y_start, float x_end, float y_end)
        {
           
            double k = (double)(y_end - y_start) / (x_end - x_start);
            double b = y_start - k * x_start;
            for (float x = x_start; x <= x_end; x++)
            DrawPoint(x, (float)Math.Round(k * x + b));
        }
        private void DrawPoint(float x, float y)
        {
            Graphics g = panel1.CreateGraphics();
            g.TranslateTransform(x0, y0);
            g.FillEllipse(new SolidBrush(System.Drawing.Color.Red), x-2, y-2, 2, 2);
        }
        private void DrawPoint(int x, int y)
        {
            Graphics g = panel1.CreateGraphics();
            g.TranslateTransform(x0, y0);
            g.FillEllipse(new SolidBrush(System.Drawing.Color.Red), x-2, y-2, 2, 2);
        }
       
    }
}
