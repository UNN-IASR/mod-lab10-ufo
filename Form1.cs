using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScottPlot;

namespace tochno10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            int x1 = 150;
            int y1 = 180;
            int x2 = 13050;
            int y2 = 9611;
            int step = 50;
            int sizze = 100; //размер точки

            List<double> x_N = new List<double>();
            int indexX = 0;
            List<double> y_radius = new List<double>();
            int indexY = 0;

            double distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));

            //Настраиваем масштабы полотна
            Graphics g = e.Graphics;
            g.ScaleTransform(0.05f, 0.05f);

            //СОздаём кисти и перья
            Pen pen = new Pen(System.Drawing.Color.Black, 1);
            Pen pen2 = new Pen(System.Drawing.Color.Black, 2);
            Brush brushStart = new SolidBrush(System.Drawing.Color.Green);
            Brush brushEnd = new SolidBrush(System.Drawing.Color.Red);
            Brush brushNow = new SolidBrush(System.Drawing.Color.Blue);


            for (int value = 10; value <= 300; value += 10)  
            {
                y_radius.Add(value);
                indexY++;
                //точки начала и конца
                Rectangle startPoint = new Rectangle(x1, y1, sizze, sizze);
                Rectangle endPoint = new Rectangle(x2, y2, sizze, sizze);
                Rectangle endRadius = new Rectangle(x2 - (int)(value / 2), y2 - (int)(value / 2), sizze + (int)(value), sizze + (int)(value));
                double angle = -Math.Atan((double)Math.Abs(y2 - y1) / (double)Math.Abs(x2 - x1));

                for (int n = 1; n <= 15; n++)
                {
                    double x = x1;
                    double y = y1;

                    double oldDistant = distance + 1.0;
                    while ((distance > value) && (oldDistant > distance))
                    {
                        if (oldDistant > distance)
                        {
                            oldDistant = distance;
                        }
                        //System.Threading.Thread.Sleep(10);
                        x += step * CosTeilor(n, angle);
                        y -= step * SinTeilor(n, angle);
                        g.Clear(System.Drawing.Color.White);

                        //Рисуем точку начала
                        g.DrawEllipse(pen, startPoint);
                        g.FillEllipse(brushStart, startPoint);
                        
                        //И точку конца
                        g.DrawEllipse(pen, endPoint);
                        g.FillEllipse(brushEnd, endPoint);
                        g.DrawEllipse(pen2, endRadius);

                        //Текущая точка
                        g.DrawEllipse(pen, (int)x, (int)y, sizze, sizze);
                        g.FillEllipse(brushNow, (int)x, (int)y, sizze, sizze);
                        distance = Math.Sqrt(Math.Pow(x - x2, 2) + Math.Pow(y - y2, 2));
                    }

                    if (distance < value)
                    { 
                        x_N.Add(n);
                        indexX++;
                        break;
                    }
                }
                
            }


            button1.Enabled = true;
            Plot myPlot = new Plot();
            myPlot.Add.Scatter(y_radius, x_N);
            myPlot.ShowLegend();
            myPlot.YLabel("Точность");
            myPlot.XLabel("Диаметр поля попадания");
            myPlot.SavePng("plot.png", 1800, 1000);

        }
        public double SinTeilor(int n, double angle)
        {
            double sin = 0.0;
            for (int i = 1; i <= n; i++)
            {
                sin += (double)(Math.Pow(-1, i - 1) * Math.Pow(angle, 2 * i - 1)) / Factorial(2 * i - 1);
            }
            return sin;
        }

        public double CosTeilor(int n, double angle)
        {
            double cos = 0.0;
            for (int i = 1; i <= n; i++)
            {
                cos += (double)(Math.Pow(-1, i - 1) * Math.Pow(angle, 2 * i - 2)) / Factorial(2 * i - 2);
            }
            return cos;
        }
        public long Factorial(long n)
        {
            if (n <= 1)
                return 1;
            else
                return n * Factorial(n - 1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
        }
    }
}
