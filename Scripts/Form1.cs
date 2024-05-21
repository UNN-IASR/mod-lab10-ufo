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

namespace Путь
{
    public partial class Form1 : Form
    {
        //private PictureBox pictureBox1;
        private Timer timer;
        MyPoint pointStart = new MyPoint(10, 15);
        MyPoint pointEnd = new MyPoint(500f, 350f);
        MyPoint pointCurrent;
        float angle;
        float distance;
        int Step = 2;
        List<double> distans = new List<double>();
        float MinDistance;
        public Form1()
        {
            this.Size = new Size(800, 600);
            
            InitializeComponent();
            Init();
            Start();
            SetupTimer();
        }
        public void Init()
        {
            MinDistance = float.MaxValue;
            distance = float.MaxValue;
            pointCurrent = new MyPoint(pointStart.X, pointStart.Y);
            angle = AngleInRadians();

        }
        private void Start()
        {
            chart1.Legends.Clear();
            chart1.Series[0].ChartType = SeriesChartType.Line;
            chart1.Series.Add(".");
            pictureBox1.Paint += PictureBox_Paint;
            Controls.Add(pictureBox1);
        }

        private void SetupTimer()
        {
            chart1.Series[1].ChartType = SeriesChartType.Point;
            chart1.ChartAreas[0].AxisX.Title = "error rate";
            chart1.ChartAreas[0].AxisY.Title = "Row length";
            timer = new Timer();
            timer.Interval = 1; // Обновление каждую секунду
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        public void Creafte()
        {
            for (int i =0 ; i <distans.Count; i++)
            {
                chart1.Series[0].Points.AddXY(distans[i], i - 1);
                chart1.Series[1].Points.AddXY(distans[i], i - 1);
            }
            timer.Stop();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            pictureBox1.Invalidate(); // Перерисовать PictureBox
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            DrawWay(e.Graphics);
        }
        private void DrawWay(Graphics g)
        {
            float Radius = 10f;
            float step = 10;
            if (distance > Radius)
            {
                pointCurrent.X += step * Cos(angle);
                pointCurrent.Y += step * Sin(angle);
                distance = CalculateDistance(pointCurrent, pointEnd);
                if(MinDistance>distance)
                {
                    MinDistance = distance;
                }
            }
            else
            {
                NewStep();
                return;
            }
            if(MinDistance<distance)
            {
                NewStep();
            }

            g.FillEllipse(Brushes.Black, pointStart.X, pointStart.Y, 10, 10);
            g.FillEllipse(Brushes.Black, pointEnd.X, pointEnd.Y, 10, 10);
            g.FillEllipse(Brushes.Black, pointCurrent.X, pointCurrent.Y, 10, 10);
        }
        public void NewStep()
        {
            distans.Add(MinDistance);
            if (Step < 10)
            {
                Step++;
                Init();
            }
            else
            {
                Creafte();
            }
        }
        public float CalculateDistance(MyPoint p1, MyPoint p2)
        {
            float dx = p2.X - p1.X;
            float dy = p2.Y - p1.Y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }

        private float AngleInRadians()
        {
            return (float)Arct(Math.Abs(pointStart.Y - pointEnd.Y) / Math.Abs(pointStart.X - pointEnd.X));
        }
        private int Factorial(int n)
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
        private float Sin(float x)
        {
            float result = 0;
            int sing = 1;
            for (int i = 1; i <= Step; i++)
            {
                result += sing * (float)(Math.Pow(x, 2 * i - 1) / Factorial(2 * i - 1));
                sing *= -1;
            }
            return result;
        }
        private float Arct(float x)
        {
            float result = 0;
            int sing = 1;
            for (int i = 1; i <= Step; i++)
            {
                result += sing * (float)(Math.Pow(x, 2 * i - 1) / (2 * i - 1));
                sing *= -1;
            }
            return result;
        }
        private float Cos(float x)
        {
            float result = 0;
            int sing = 1;
            for (int i = 1; i <= Step; i++)
            {
                result += sing * (float)(Math.Pow(x, 2 * i - 2) / Factorial(2 * i - 2));
                sing *= -1;
            }
            return result;
        }
        public void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    public class MyPoint
    {
        public float X, Y;
        public MyPoint(float x, float y)
        {
            X = x; Y = y;
        }
    }
}
