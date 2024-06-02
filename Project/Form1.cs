using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace Project
{
    public partial class Form1 : Form
    {
        int distance = 50;
        Pen pen = new Pen(Color.Black, 4);

        PointF start_p = new PointF(50, 50);
        PointF end_p = new PointF(400, 700);

        PointF p1;
        PointF p2;

        int radiusPoint = 5;

        double angl;
        //int step = 50;

        public Form1()
        {
            InitializeComponent();

            Accuracy_NumericUpDown.Value = 2;
            CountSteps_NumericUpDown.Value = 10;

            StartAccuracyForAnalize_NumericUpDown.Value = 1;
            EndAccuracyForAnalize_NumericUpDown.Value = 100;
            CountStepsForAnalize_NumericUpDown.Value = 1;
            StartPointX_NumericUpDown.Value = -100000;
            StartPointY_NumericUpDown.Value = -100000;
            EndPointX_NumericUpDown.Value = 100000;
            EndPointY_NumericUpDown.Value = 100000;

        }

        int countSteps = 10;
        int nowSteps = 0;
        int n = 0;
        double step;
        int directionX;
        int directionY;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (nowSteps != countSteps)
            {
                p1.X += (float)(directionX * step * MathTrigonometry.Cos(angl, n));
                p1.Y += (float)(directionY * step * MathTrigonometry.Sin(angl, n));

                Paint_Panel.Invalidate();
                nowSteps++;
            }
            else
                timer1.Stop();
        }

        private float Distance(PointF p1, PointF p2)
        {
            return (float)Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        private double Step(PointF p1, PointF p2, int countSteps)
        {
            float dist = Distance(p1, p2);
            return dist / countSteps;
        }

        private void Start_Button_Click(object sender, EventArgs e)
        {
            Start_Button.Text = "Restart";
            p1 = start_p;
            p2 = end_p;
            n = (int)Accuracy_NumericUpDown.Value;
            directionX = p1.X < p2.X ? 1 : -1;
            directionY = p1.Y < p2.Y ? 1 : -1;

            countSteps = (int)CountSteps_NumericUpDown.Value;
            nowSteps = 0;

            step = Step(start_p, end_p, countSteps);
            angl = MathTrigonometry.Atan(Math.Abs(start_p.Y - end_p.Y) / Math.Abs(start_p.X - end_p.X), n);

            timer1.Start();
        }

        private void Paint_Panel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            GraphicsState gs;

            g.ScaleTransform(0.5f, 0.5f);

            g.DrawEllipse(pen, p1.X, p1.Y, radiusPoint, radiusPoint);
            g.DrawEllipse(pen, p2.X, p2.Y, radiusPoint, radiusPoint);
            g.DrawEllipse(pen, p2.X - distance, p2.Y - distance, distance * 2, distance * 2);

            gs = g.Save();

            g.Restore(gs);
        }

        private void StartAnalize_Button_Click(object sender, EventArgs e)
        {
            Point p_start = new Point((int)StartPointX_NumericUpDown.Value, (int)StartPointY_NumericUpDown.Value);
            Point p_end = new Point((int)EndPointX_NumericUpDown.Value, (int)EndPointY_NumericUpDown.Value);
            int start_n = (int)StartAccuracyForAnalize_NumericUpDown.Value;
            int end_n = (int)EndAccuracyForAnalize_NumericUpDown.Value;
            int countSteps = (int)CountStepsForAnalize_NumericUpDown.Value;

            Analizer analizer = new Analizer(p_start, p_end, start_n, end_n, countSteps);
        }
    }
}