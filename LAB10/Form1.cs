using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace LAB10
{
    public partial class Form1 : Form
    {
        private Thread thread;

        public Form1()
        {
            InitializeComponent();
        }

        public void Anglear(object obj)
        {
            var arr = obj as int[];
            var x2 = arr[0];
            var y2 = arr[1];
            var n = arr[2];
            var error = arr[3];
            var x1 = 0;
            var y1 = 0;
            double x = 0, y = 0;
            var step = 5;
            var pen = new Pen(Color.Black, 3);
            var pen2 = new Pen(Color.Red, 7);
            var pen3 = new Pen(Color.Blue, 7);
            double angle = Math.Atan(Math.Abs(y2 - y1) / (double)Math.Abs(x2 - x1)) * 180 / Math.PI;
            double distance = Math.Sqrt(Math.Pow(y2 - y1, 2) + Math.Pow(x2 - x1, 2));
            double sin = Sin(angle, n);
            double cos = Cos(angle, n);
            Graphics graphics = CreateGraphics();
            graphics.TranslateTransform(Width / 2 + 20, Height / 2 - 10);
            graphics.ScaleTransform(0.5f, 0.5f);
            graphics.DrawEllipse(pen3, x2 - error / 2, y2 - error / 2, error * 2, error * 2);

            while (distance > error)
            {
                Thread.Sleep(50);
                x += step * cos;
                y += step * sin;
                graphics.DrawLine(pen, new Point(x1, y1), new Point(x2, y2));
                graphics.DrawEllipse(pen2, new Rectangle((int)x, (int)y, 1, 1));
                var previousDistance = distance;
                distance = Math.Sqrt(Math.Pow(y2 - y, 2) + Math.Pow(x2 - x, 2));

                if (previousDistance < distance)
                {
                    MessageBox.Show("Промах");

                    return;
                }
            }

            MessageBox.Show("Попадание");
        }


        private double Sin(double angle, int n)
        {
            double sin = 0;

            for (int i = 0; i < n; ++i)
            {
                var factorial = 1;

                for (int j = 0; j < 2 * (i + 1); ++j)
                {
                    if (i == 0)
                    {
                        break;
                    }

                    factorial *= (j + 1);
                }

                if (i % 2 == 0)
                {
                    sin += Math.Pow(angle / 180 * Math.PI, 2 * i + 1) / factorial;
                }
                else
                {
                    sin -= Math.Pow(angle / 180 * Math.PI, 2 * i + 1) / factorial;
                }
            }

            return sin;
        }

        private double Cos(double angle, int error)
        {
            double cos = 0;

            for (int i = 0; i < error; ++i)
            {
                var factorial = 1;

                for (int j = 0; j < 2 * i; ++j)
                {
                    factorial *= (j + 1);
                }

                if (i % 2 == 0)
                {
                    cos += Math.Pow(angle / 180 * Math.PI, 2 * i) / factorial;
                }
                else
                {
                    cos -= Math.Pow(angle / 180 * Math.PI, 2 * i) / factorial;
                }
            }

            return cos;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Введено некорректное значение");

                return;
            }

            thread = new Thread(Anglear);
            thread.Start(new int[] { Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text), Int32.Parse(textBox3.Text), Int32.Parse(textBox4.Text) });
        }
    }
}
