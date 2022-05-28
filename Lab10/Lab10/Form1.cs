using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Lab10
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            tbPrecision.Enabled = false;
            tbReqTerms.Enabled = false;
        }

        private void PleaseStart_Click(object sender, EventArgs e)
        {
            int temp = 0;
            float tempF = 0;
            uint tempU = 0;
            if (!Int32.TryParse(tbX1.Text, out temp)
             || !Int32.TryParse(tbY1.Text, out temp)
             || !Int32.TryParse(tbX2.Text, out temp)
             || !Int32.TryParse(tbY2.Text, out temp)
             || (MethodComboBox.SelectedIndex == 1
                    && (!float.TryParse(tbPrecision.Text, out tempF) || !uint.TryParse(tbReqTerms.Text, out tempU) || tempU == 0)))
            {
                MessageBox.Show("Неправильно введены данные");
                return;
            }

            Point Start = new Point(int.Parse(tbX1.Text), int.Parse(tbY1.Text));
            Point End = new Point(int.Parse(tbX2.Text), int.Parse(tbY2.Text));

            switch (MethodComboBox.SelectedIndex)
            {
                case 0:
                    UseLineEquation(Start, End);
                    break;

                case 1:
                    int TermCount = int.Parse(tbReqTerms.Text);
                    float Precision = float.Parse(tbPrecision.Text);
                    UseDifferentialApproach(Start, End, Precision, TermCount);
                    break;

                default:
                    break;
            }
        }

        private void tbXY_CheckChar(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!(Char.IsDigit(ch) || ch == (char)Keys.Back || ch == '-'))
            {
                e.Handled = true;
            }
        }

        private void tbPrecision_CheckChar(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!(Char.IsDigit(ch) || ch == (char)Keys.Back || ch == ',' || ch == '.'))
            {
                e.Handled = true;
            }
        }

        private void UseLineEquation(Point Start, Point End)
        {
            if(End.X - Start.X < 0.01)
            {
                MessageBox.Show("Прямая не может быть вертикалью");
                return;
            }

            double k = ((double)(End.Y - Start.Y)) / (End.X - Start.X);
            double h = Start.Y - k * Start.X;

            Graphics graphics = GetScaledGraphics();
            graphics.DrawEllipse(new Pen(Color.Blue, 5), End.X - 5, End.Y - 5, 10, 10);
            graphics.DrawEllipse(new Pen(Color.Green, 5), Start.X - 5, Start.Y - 5, 10, 10);

            int step = (End.X > Start.X) ? 1 : -1;

            int X = Start.X;
            while (X != End.X)
            {
                Thread.Sleep(16);
                graphics.DrawEllipse(new Pen(Color.Red, 5), new RectangleF(X, (float)(k * X + h), 1, 1));
                X += step;
            }
        }

        public void UseDifferentialApproach(Point Start, Point End, float Precision, int RequiredTerms)
        {
            double x = Start.X;
            double y = Start.Y;
            int step_mult = 1;

            Pen black_pen = new Pen(Color.Black, 5);
            Pen blue_pen = new Pen(Color.Black, 5);
            Pen green_pen = new Pen(Color.Green, 5);
            Pen red_pen = new Pen(Color.Red, 5);

            // not slope!
            double angle = Atan(Math.Abs(End.Y - Start.Y) / (double)Math.Abs(End.X - Start.X), RequiredTerms) * 180 / Math.PI;

            double distance = Math.Sqrt(Math.Pow(End.Y - Start.Y, 2) + Math.Pow(End.X - Start.X, 2));

            double sine = Sin(angle, RequiredTerms);
            double cosine = Cos(angle, RequiredTerms);

            Graphics graphics = GetScaledGraphics();

            graphics.DrawEllipse(red_pen, End.X - Precision, End.Y - Precision, Precision * 2, Precision * 2);
            graphics.DrawEllipse(black_pen, Start.X - 5, Start.Y - 5, 10, 10);

            int Xstep = (End.X > Start.X) ? 1 : -1;
            int Ystep = (End.Y > Start.Y) ? 1 : -1;

            while (distance > Precision)
            {
                x += Xstep * (cosine * step_mult);
                y += Ystep * (sine * step_mult);

                graphics.DrawEllipse(black_pen, (int)x, (int)y, 2, 2);
                double PrevDistance = distance;
                distance = Math.Sqrt(Math.Pow(End.Y - y, 2) + Math.Pow(End.X - x, 2));

                if (PrevDistance < distance)
                {
                    MessageBox.Show("Не попали в окрестность точки");
                    return;
                }
            }
            MessageBox.Show("Передвижение закончено в пределах заданной окрестности точки");
        }

        private Graphics GetScaledGraphics()
        {
            Graphics result = CreateGraphics();

            result.TranslateTransform(Width / 2, Height / 2);
            result.ScaleTransform(0.5f, 0.5f);

            return result;
        }

        private void MethodComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool enabledness = false;

            if (MethodComboBox.SelectedIndex == 1)
                enabledness = true;

            tbPrecision.Enabled = enabledness;
            tbReqTerms.Enabled = enabledness;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen blue_pen = new Pen(Color.Turquoise, 4);
            Graphics graphics = GetScaledGraphics();

            // draw axes
            graphics.DrawLine(blue_pen, new Point(0, 10000), new Point(0, -10000));
            graphics.DrawLine(blue_pen, new Point(-10000, 0), new Point(10000, 0));
        }

        int fact(int n)
        {
            int retval = 1;
            if (n <= 1) return retval;
            for (int i = 2; i <= n; i++)
                retval *= i;
            return retval;
        }

        private double Sin(double in_angle, int TermCount)
        {
            double retval = 0;
            for (int i = 0; i < TermCount; i++)
            {
                int factorial = fact(2 * i + 1); // Передайте им, что я не хотел этого делать
                retval += Math.Pow(-1, i) * (Math.Pow(in_angle * Math.PI / 180, 2 * i + 1) / factorial);
            }
            return retval;
        }
        private double Cos(double in_angle, int TermCount)
        {
            double retval = 0;
            for (int i = 0; i < TermCount; i++)
            {
                int factorial = fact(2 * i);
                retval += Math.Pow(-1, i) * (Math.Pow(in_angle * Math.PI / 180, 2 * i) / factorial);
            }
            return retval;
        }

        double Atan(double tangent, int TermCount)
        {
            double retval = 0;
            if (-1 <= tangent && tangent <= 1)
            {
                for (int i = 0; i < TermCount; i++)
                {
                    retval += Math.Pow(-1, i) * Math.Pow(tangent, 2 * i + 1) / (2 * i + 1);
                }
            }
            else
            {
                int sign;
                if (tangent >= 1) sign = 1;
                else sign = -1;

                retval = sign * Math.PI / 2;
                for (int i = 0; i < TermCount; i++)
                {
                    retval -= Math.Pow(-1, i) / ((2 * i + 1) * Math.Pow(tangent, 2 * i + 1));
                }
            }
            return retval;
        }
    }
}
