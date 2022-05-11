using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Threading;
using System.Text;
using System.Windows.Forms;

namespace PointTo
{
    public partial class Form1 : Form
    {
        private Thread thread;
        public Form1()
        {
            InitializeComponent();
            Value.Enabled = false;
            ColSteps.Enabled = false;
        }

        public void WithAngle(object obj)
        {
            int[] arr = obj as int[];
            int x1 = arr[0], y1 = arr[1], x2 = arr[2],
                y2 = arr[3], value = arr[4], colsteps = arr[5];
            double x = x1, y = y1;
            int step = 5;

            Pen pen = new Pen(Color.Black, 2);
            Pen pen2 = new Pen(Color.Green, 5);
            Pen pen3 = new Pen(Color.Red, 5);


            double angle = Atan(Math.Abs(y2 - y1) / (double)Math.Abs(x2 - x1), colsteps) * 180 / Math.PI;
            double distance = Math.Sqrt(Math.Pow(y2 - y1, 2) + Math.Pow(x2 - x1, 2));
            double sin = Sin(angle, colsteps);
            double cos = Cos(angle, colsteps);

            Graphics graphics = CreateGraphics();
            graphics.TranslateTransform(Width / 2 + 20, Height / 2 - 10);
            graphics.ScaleTransform(0.5f, 0.5f);
            graphics.DrawEllipse(pen3, x2 - value / 2, y2 - value / 2, value * 2, value * 2);

            while (distance > value)
            {
                Thread.Sleep(50);
                x += step * cos;
                y += step * sin;
                graphics.DrawLine(pen, new Point(x1, y1), new Point(x2, y2));
                graphics.DrawEllipse(pen2, new Rectangle((int)x, (int)y, 1, 1));
                double previousDistance = distance;
                distance = Math.Sqrt(Math.Pow(y2 - y, 2) + Math.Pow(x2 - x, 2));

                if (previousDistance < distance)
                {
                    MessageBox.Show("Не попали :(");
                    return;
                }
            }
            MessageBox.Show("Попали :)");
        }

        public void LineEquation(object obj)
        {
            int[] arr = obj as int[];
            int x1 = arr[0], y1 = arr[1], x2 = arr[2], y2 = arr[3];
            double k = ((double)(y2 - y1)) / (x2 - x1);
            double b = y1 - k * x1;

            Graphics graphics = CreateGraphics();
            Pen pen = new Pen(Color.Black, 2);
            Pen pen2 = new Pen(Color.Green, 5);
            graphics.TranslateTransform(Width / 2 + 20, Height / 2 - 10);

            for (int x = x1; x <= x2; ++x)
            {
                Thread.Sleep(30);
                graphics.DrawLine(pen, new Point(x1, y1), new Point(x2, y2));
                graphics.DrawEllipse(pen2, new RectangleF(x, (float)(k * x + b), 1, 1));
                graphics.FillEllipse(new SolidBrush(Color.Green), new RectangleF(x, (float)(k * x + b), 1, 1));
            }
        }

        private double Sin(double angle, int colsteps)
        {
            double sin = 0;
            for (int i = 0; i < colsteps; ++i)
            {
                int factorial = 1;
                for (int j = 0; j < 2 * (i + 1); ++j)
                {
                    if (i == 0) break;
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

        private double Cos(double angle, int colsteps)
        {
            double cos = 0;
            for (int i = 0; i < colsteps; ++i)
            {
                int factorial = 1;
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

        double Atan(double angle, int colsteps)
        {
            double atan = 0;
            if (-1 <= angle && angle <= 1)
            {
                for (int i = 1; i < colsteps + 1; i++)
                {
                    atan += Math.Pow(-1, i - 1) * Math.Pow(angle, 2 * i - 1) / (2 * i - 1);
                }
            }
            else
            {
                if (angle >= 1)
                {
                    atan += Math.PI / 2;
                    for (int i = 0; i < colsteps; i++)
                    {
                        atan -= Math.Pow(-1, i) / ((2 * i + 1) * Math.Pow(angle, 2 * i + 1));
                    }
                }
                else
                {
                    atan -= Math.PI / 2;
                    for (int i = 0; i < colsteps; i++)
                    {
                        atan -= Math.Pow(-1, i) / ((2 * i + 1) * Math.Pow(angle, 2 * i + 1));
                    }
                }
            }
            return atan;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (((x1.Text == "" || y1.Text == "" || x2.Text == "" || y2.Text == "") && !AngleRB.Checked)
                || ((x1.Text == "" || y1.Text == "" || x2.Text == "" || y2.Text == "" || Value.Text == "" || ColSteps.Text == "") && AngleRB.Checked))
            {
                MessageBox.Show("Неправильно введены данные");
                return;
            }

            if (!AngleRB.Checked)
            {
                thread = new Thread(LineEquation);
                thread.Start(new int[] { Int32.Parse(x1.Text), Int32.Parse(y1.Text), 
                                         Int32.Parse(x2.Text), Int32.Parse(y2.Text) });
            }
            else
            {
                thread = new Thread(WithAngle);
                thread.Start(new int[] { Int32.Parse(x1.Text), Int32.Parse(y1.Text),
                                         Int32.Parse(x2.Text), Int32.Parse(y2.Text),
                                         Int32.Parse(Value.Text), Int32.Parse(ColSteps.Text) });
            }
        }

        private void x1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8 && number != 45)
            {
                e.Handled = true;
            }
        }

        private void y1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8 && number != 45)
            {
                e.Handled = true;
            }
        }
        private void x2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8 && number != 45)
            {
                e.Handled = true;
            }
        }

        private void y2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8 && number != 45)
            {
                e.Handled = true;
            }
        }

        private void AngleRB_CheckedChanged(object sender, EventArgs e)
        {
            if (AngleRB.Checked)
            {
                Value.Enabled = true;
                ColSteps.Enabled = true;
            }
            else
            {
                Value.Enabled = false;
                ColSteps.Enabled = false;
            }
        }

        private void Precision_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void Value_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thread != null)
            {
                thread.Join();
            }
        }
    }
}