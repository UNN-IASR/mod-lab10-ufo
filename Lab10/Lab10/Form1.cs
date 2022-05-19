using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Lab10
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            textBoxForValue.Enabled = false;
            textBoxForColSteps.Enabled = false;
        }

        public void WithAngle(Point startPoint, Point endPoint, float accuracy, int numberOfMembers)
        {
            double x = startPoint.X, y = startPoint.Y;
            int step = 1;

            Pen pen = new Pen(Color.Black, 2);
            Pen pen2 = new Pen(Color.Green, 5);
            Pen pen3 = new Pen(Color.Red, 5);


            double angle = Atan(Math.Abs(endPoint.Y - startPoint.Y) / 
                (double)Math.Abs(endPoint.X - startPoint.X), numberOfMembers) * 180 / Math.PI;
            double length = Math.Sqrt(Math.Pow(endPoint.Y - startPoint.Y, 2) + Math.Pow(endPoint.X - startPoint.X, 2));
            double sin = Sin(angle, numberOfMembers);
            double cos = Cos(angle, numberOfMembers);

            Graphics graphics = changeGraphics();

            graphics.DrawEllipse(new Pen(Color.Blue, 5), endPoint.X - accuracy, endPoint.Y - accuracy, accuracy * 2, accuracy * 2);
            graphics.DrawEllipse(new Pen(Color.Green, 5), startPoint.X - 5, startPoint.Y - 5, 10, 10);

            int stepForX = (endPoint.X > startPoint.X) ? 1 : -1;
            int stepForY = (endPoint.Y > startPoint.Y) ? 1 : -1;

            while (length > accuracy)
            {
                x += stepForX * (step * cos);
                y += stepForY * (step * sin);

                graphics.DrawEllipse(new Pen(Color.Red, 5), (int)x, (int)y, 1, 1);
                double previousLength = length;
                length = Math.Sqrt(Math.Pow(endPoint.Y - y, 2) + Math.Pow(endPoint.X - x, 2));

                if (previousLength < length)
                {
                    MessageBox.Show("Промах не в норме");
                    return;
                }
            }
            MessageBox.Show("Промах в норме");
        }

        private void LineEquation(Point startPoint, Point endPoint)
        {
            if(endPoint.X - startPoint.X == 0)
            {
                MessageBox.Show("k = бесконечноти");
                return;
            }

            double k = ((double)(endPoint.Y - startPoint.Y)) / (endPoint.X - startPoint.X);
            double b = startPoint.Y - k * startPoint.X;

            Graphics graphics = changeGraphics();
            graphics.DrawEllipse(new Pen(Color.Blue, 5), endPoint.X - 5, endPoint.Y - 5, 10, 10);
            graphics.DrawEllipse(new Pen(Color.Green, 5), startPoint.X - 5, startPoint.Y - 5, 10, 10);

            int step = (endPoint.X > startPoint.X) ? 1 : -1;

            int currentX = startPoint.X;
            while(currentX != endPoint.X)
            {
                Thread.Sleep(20);
                graphics.DrawEllipse(new Pen(Color.Red, 5), new RectangleF(currentX, (float)(k * currentX + b), 1, 1));
                currentX += step;
            }
        }

        double Atan(double tangent, int numberOfMembers)
        {
            double atan = 0;
            if (-1 <= tangent && tangent <= 1)
            {
                for (int i = 0; i < numberOfMembers; i++)
                {
                    atan += Math.Pow(-1, i) * Math.Pow(tangent, 2 * i + 1) / (2 * i + 1);
                }
            }
            else
            {
                int coef = (tangent >= 1) ? 1 : -1;
                atan = coef * Math.PI / 2;
                for(int i = 0; i < numberOfMembers; i++)
                {
                    atan -= Math.Pow(-1, i) / ((2 * i + 1) * Math.Pow(tangent, 2 * i + 1)); 
                }
            }
            return atan;
        }

        int Factorial(int n)
        {
            if (n == 0) return 1;

            return n * Factorial(n - 1);
        }

        private double Sin(double angle, int numberOfMembers)
        {
            double sin = 0;
            for (int i = 0; i < numberOfMembers; i++)
            {
                int factorial = Factorial(2 * i + 1);

                sin += Math.Pow(-1, i) * (Math.Pow(angle * Math.PI / 180, 2 * i + 1) / factorial);
            }
            return sin;
        }

        private double Cos(double angle, int colsteps)
        {
            double cos = 0;
            for (int i = 0; i < colsteps; i++)
            {
                int factorial = Factorial(2 * i);

                cos += Math.Pow(-1, i) * Math.Pow(angle * Math.PI / 180, 2 * i) / factorial;
            }
            return cos;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            //ввести ограничения на кнопки
            if (textBoxForX1.Text == "" || textBoxForY1.Text == "" || textBoxForX2.Text == "" || textBoxForY2.Text == "" 
                || (comboBox1.SelectedIndex == 1 && (textBoxForValue.Text == "" || textBoxForColSteps.Text == "")))
            {
                MessageBox.Show("Неправильно введены данные");
                return;
            }

            Point startingPoint = new Point(int.Parse(textBoxForX1.Text), int.Parse(textBoxForY1.Text));
            Point endPoint = new Point(int.Parse(textBoxForX2.Text), int.Parse(textBoxForY2.Text));

            switch(comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        LineEquation(startingPoint, endPoint);
                        break;
                    }
                case 1:
                    {
                        float accuracy = float.Parse(textBoxForValue.Text);
                        int numberOfMembers = int.Parse(textBoxForColSteps.Text);
                        WithAngle(startingPoint, endPoint, accuracy, numberOfMembers);
                        break;
                    }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private Graphics changeGraphics()
        {
            Graphics graphics = CreateGraphics();
            graphics.TranslateTransform(Width / 2, Height / 2);
            graphics.ScaleTransform(0.5f, 0.5f);
            return graphics;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen blackPen = new Pen(Color.Black, 1);
            Graphics graphics = changeGraphics();
            graphics.DrawLine(blackPen, new Point(-1000, 0), new Point(1000, 0));
            graphics.DrawLine(blackPen, new Point(0, 1000), new Point(0, -1000));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 1)
            {
                textBoxForValue.Enabled = true;
                textBoxForColSteps.Enabled = true;
            }
            else
            {
                textBoxForValue.Enabled = false;
                textBoxForColSteps.Enabled = false;
            }
        }

        private void textBoxForX1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8 && number != '-')
            {
                e.Handled = true;
            }
        }

        private void textBoxForValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8 && number != ',')
            {
                e.Handled = true;
            }
        }
    }
}
