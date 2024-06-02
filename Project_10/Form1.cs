using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_10
{
    public partial class Form1 : Form
    {
        private Timer timer;
        Point start_point = new Point(10, 10);
        Point end_point = new Point(500f, 400f);
        Point current_point;
        float distance;
        float angle;
        int Step = 2;

        List<double> len = new List<double>();
        float min_dist;

        public Form1()
        {
            InitializeComponent();
            Initial();
            Start();
            SetupTimer();
        }
        public void Form1_Load(object sender, EventArgs e)
        {

        }

        public void Initial()
        {
            min_dist = float.MaxValue;
            distance = float.MaxValue;
            current_point = new Point(start_point.X, start_point.Y);
            angle = (float)Atan(Math.Abs(start_point.Y - end_point.Y) / Math.Abs(start_point.X - end_point.X));

        }

        private void Start()
        {
            chart1.Legends.Clear();
            chart1.Series.Add(".");
            pictureBox1.Paint += PictureBox_Paint;
            Controls.Add(pictureBox1);
        }

        private void SetupTimer()
        {
            chart1.ChartAreas[0].AxisY.Title = "Длина ряда";
            chart1.ChartAreas[0].AxisX.Title = "Отклонение";
            timer = new Timer();
            timer.Interval = 1;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        public void Daigramma()
        {
            for (int i = 0; i < len.Count; i++)
            {
                chart1.Series[0].Points.AddXY(len[i], i - 1);
                chart1.Series[1].Points.AddXY(len[i], i - 1);
            }
            timer.Stop();
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            Draw(e.Graphics);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void Draw(Graphics g)
        {
            float rad = 10f;
            float step = 10;
            if (distance > rad)
            {
                current_point.X += step * Cos(angle);
                current_point.Y += step * Sin(angle);
                distance = Calculate(current_point, end_point);
                if (min_dist > distance) min_dist = distance;
            }
            else
            {
                NewStep();
                return;
            }
            if (min_dist < distance) NewStep();

            Pen p = new Pen(Color.Black);
            g.DrawEllipse(p, start_point.X, start_point.Y, 10, 10);
            g.DrawEllipse(p, end_point.X, end_point.Y, 10, 10);
            g.DrawEllipse(p, current_point.X, current_point.Y, 10, 10);
        }
        public void NewStep()
        {
            len.Add(Math.Round(min_dist, 3));
            if (Step < 10)
            {
                Step++;
                Initial();
            }
            else Daigramma();
        }
        public float Calculate(Point p1, Point p2)
        {
            float dx = p2.X - p1.X;
            float dy = p2.Y - p1.Y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }

        int Factorial(int x)
        {
            return x == 0 ? 1 : x * Factorial(x - 1);
        }

        private float Sin(float x)
        {
            float result = 0;
            int s = 1;
            for (int i = 1; i <= Step; i++)
            {
                result += s * (float)(Math.Pow(x, 2 * i - 1) / Factorial(2 * i - 1));
                s *= -1;
            }
            return result;
        }

        private float Cos(float x)
        {
            float result = 0;
            int s = 1;
            for (int i = 1; i <= Step; i++)
            {
                result += s * (float)(Math.Pow(x, 2 * i - 2) / Factorial(2 * i - 2));
                s *= -1;
            }
            return result;
        }

        private float Atan(float x)
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
    }
    public class Point
    {
        public float X, Y;
        public Point(float x, float y)
        {
            X = x;
            Y = y;
        }
    }
}
