using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace mipis10 {


    public partial class Form1 : Form {

        int n = 2;
        double x;
        double y;
        private SolidBrush brush = new SolidBrush(System.Drawing.Color.Red);
        private Pen pen2 = new Pen(System.Drawing.Color.Red, 5);
        private Pen pen3 = new Pen(System.Drawing.Color.Red, 1);
        private Pen pen = new Pen(System.Drawing.Color.Blue, 5);

        //начальные координаты точки
        double x1 = 6340;
        double y1 = 3243;
        //координаты цели
        double x2 = 100;
        double y2 = 100;

        //вспомогательные характеристики
        double distance = 1000;
        double angle;
        double accuracy = 0.1;
        List<double> acc = new List<double>();
        List<double> nn = new List<double>();
        double step = 0.1;
        public static Form2 graph;
        


        public Form1() {
            InitializeComponent();
        }

        private int Factorial(int x) {
            if (x == 0) {
                return 1;
            }
            return x * Factorial(x - 1);
        }

        private double Sin(double x) {
            int step = 1;
            int minus = 1;
            int degree = 1;
            double ans = 0;

            while (step <= n) {
                ans += minus * (Math.Pow(x, degree) / Factorial(degree));
                minus *= -1;
                degree += 2;
                step++;
            }
            return ans;
        }

        private double Cos(double x) {
            int step = 1;
            int minus = 1;
            int degree = 0;
            double ans = 0;

            while (step <= n) {
                ans += minus * (Math.Pow(x, degree) / Factorial(degree));
                minus *= -1;
                degree += 2;
                step++;
            }
            return ans;
        }

        private double Atn(double x) {
            int step = 1;
            int minus = 1;
            int degree = 1;
            double ans = 0;

            while (step <= n) {
                ans += minus * (Math.Pow(x, degree) / degree);
                minus *= -1;
                degree += 2;
                step++;
            }
            return ans;
        }

        private void contextMenuStrip1_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            g.ScaleTransform(0.5f, 0.5f);
            g.DrawLine(pen3, Convert.ToInt32(x2), Convert.ToInt32(y2), Convert.ToInt32(x1), Convert.ToInt32(y1));
            n = 2;
            for (int i = 0; i < 10; i++) {
                g.DrawEllipse(pen2, Convert.ToInt32(x2 - 1), Convert.ToInt32(y2 - 1), 2, 2);
                angle = Atn(Math.Abs(y2 - y1) / Math.Abs(x2 - x1));
                x = x1;
                y = y1;
                distance = 100000;
                while (distance > accuracy && x > 80 && y > 80) {
                    x -= step * Cos(angle);
                    y -= step * Sin(angle);
                    g.DrawEllipse(pen, Convert.ToInt32(x - 1), Convert.ToInt32(y - 1), 2, 2);
                    distance = CalculateDistance(x, y, x2, y2);
                }
                acc.Add(distance);
                nn.Add(n);
                n++;
                Invalidate();
            }

            if (graph == null) {
                graph = new Form2(nn, acc);
                graph.ShowDialog();
            }

        }

        private double CalculateDistance(double x1, double y1, double x2, double y2) {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }


        private void Form1_Load(object sender, EventArgs e) {

            //Invalidate();
        }
    }
    
}
