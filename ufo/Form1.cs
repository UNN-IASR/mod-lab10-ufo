using System.Drawing;
using System.Net.Sockets;
using System.Threading;
using System.Xaml.Permissions;

namespace ufo
{
    public partial class Form1 : Form
    {
        List<int> xl = new List<int>();
        List<double> yl = new List<double>();

        static float scale = 0.5f;
        static double x1 = 1;
        static double y1 = 1;
        static double x2 = 200 / scale;
        static double y2 = 300 / scale;
        static float step = 1 * scale;
        static int value = 50;
        static int presiction = 1;

        Thread Draw;

        void DrawPoint()
        {
            this.Invalidate();
            double angle = MyMath.Atan(Math.Abs(y2 - y1) / Math.Abs(x2 - x1), presiction);
            Pen pen = new Pen(Color.Black, 2);
            double x = x1;
            double y = y1;
            var graphics = CreateGraphics();
            graphics.ScaleTransform(scale, scale);
            double distance = 5000;

            graphics.DrawEllipse(pen, (float)(x2 - value), (float)(y2 - value), value*2, value*2);

            while (distance > value)
            {
                double xp = x;
                double yp = y;
                x += step * MyMath.Cos(angle, presiction);
                y += step * MyMath.Sin(angle, presiction);

                if (x - x2 > value || y - y2 > value)
                {
                    x1 = 1;
                    y1 = 1;
                    presiction++;
                    break;
                }
                graphics.DrawLine(pen, (float)xp, (float)yp, (float)x, (float)y);
                distance = Math.Sqrt((x2 - x) * (x2 - x) + (y2 - y) * (y2 - y));
            }
            // Thread.Sleep(100);

            if (distance <= value)
            {
                xl.Add(value);
                yl.Add(presiction);
                presiction = 1;
                value--;
            }

            if (value == 0) return;

            DrawPoint();
        }
        public Form1()
        {
            InitializeComponent();
            Draw = new Thread(DrawPoint);
        }

        private void start_button_Click(object sender, EventArgs e)
        {
            if (Draw.IsAlive == false)
            {
                Draw.Start();
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //  presiction = Int32.Parse(textBox1.Text);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            //x1 = (int)e.X; y1 = (int)e.Y;
        }

        private void stop_button_Click(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(xl.Count == 50)
            {
                ScottPlot.Plot myPlot = new();
                myPlot.Add.Scatter(xl, yl);
                myPlot.SavePng("../../../plot.png",1000,800);
            }
        }
    }
}
